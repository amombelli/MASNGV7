using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.TOOLS;
using TecserEF.Entity;
using GlobalApp = Tecser.Business.MainApp.GlobalApp;

/// <summary>
/// caducar esta clase
/// todo: caducar esta clase!!
/// </summary>

namespace Tecser.Business.Transactional.CO
{
    public class AsientoContableManager
    {
        public T0601_DOCU_H H;
        private List<T0602_DOCU_S> I = new List<T0602_DOCU_S>();
        public AsientoContableManager()
        {

        }
        public AsientoContableManager(TecserData context)
        {
            H = new T0601_DOCU_H();
        }
        public AsientoContableManager(string tipoLX, DateTime fechaDoc)
        {
            H = new T0601_DOCU_H
            {
                TIPO = tipoLX,
                FECHA = fechaDoc,
                MES = new PeriodoConversion().GetMesMm(fechaDoc),
                YEAR = new PeriodoConversion().GetYearYyyy(fechaDoc)
            };
        }
        public void LoadAsientoInMemory(int numeroAsiento)
        {

            var vendor = new VendorManager().GetSpecificVendor(241); //temporal para pasar el TecserData(GlobalApp.CnnApp) context

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataH = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == numeroAsiento);
                if (dataH != null)
                {
                    H = dataH;
                    I = db.T0602_DOCU_S.Where(c => c.IDDOCU == numeroAsiento).ToList();
                }
            }
        }

        public void GrabaHeader(T0601_DOCU_H header)
        {
            new TecserSQL.Data.TransactionalData.AsientoContable(GlobalApp.CnnApp).GrabaHeader(header);
        }

        public void CreaHeaderMemoria(DateTime fechaDoc, string tipoLX, string tipoDocumento = "00",
            string numeroDocumento = "0000-00000000", string moneda = "ARS", string headerText = null)
        {

            H.TIPO = tipoLX;
            H.MONE_ORI = moneda;
            H.FECHA = fechaDoc.Date;
            H.MES = new PeriodoConversion().GetMesMm(fechaDoc);
            H.YEAR = new PeriodoConversion().GetYearYyyy(fechaDoc);
            SetNewAsientoNumber();
            H.REFE = numeroDocumento;
            H.DOCUTIPO = tipoDocumento;
            //Header.IDDOCU = 0; >>Definido desde SetNewAsientoNumber
            //Header.NASX1 = 0;  >>Definido desde SetNewAsientoNumber
            //Header.NASX2 = 0;  >>Definido desde SetNewAsientoNumber
            H.HeaderText = headerText;
            H.CK = false; //Significa que es temporal
            H.TC = new ExchangeRateManager().GetExchangeRate(fechaDoc);

            //Log
            H.FECHA_HOY = DateTime.Today;
            H.LOG_USER = Environment.UserName;
            H.FechaOP = DateTime.Now;
            H.StatusCancel = false;
        }

        private int GetNextSegmentoIdFromMemory()
        {
            return I.Count() + 1;
        }



        public void AddItemInMemoria(string gl, string moneda, string tipoDocumento, string numeroDocumento,
            decimal importeDebe, decimal importeHaber, string descripcion1, string descripcion2, string tCode,
            int idProveedor = 0, int idCliente = 0, string referenciaTableName = null, string referenciaIdTexto = null,
            int referenciaIdNumerico = 0, decimal kg = 0, int idTabla40 = 0, string material = null, int idDocuLink = 0,
            string centroCosto = null, bool ck = false, string status = null)
        {
            var item = new T0602_DOCU_S();

            item.IDDOCU = H.IDDOCU;
            item.IDSEG = GetNextSegmentoIdFromMemory();
            item.MES = H.MES;
            item.YEAR = H.YEAR;
            //Item.CUENTA= ** no en uso
            item.MONE_ORI = moneda;
            item.TC = H.TC;
            //Item.IMPORTE_ORI=  ** no en uso
            //Item.IMPORTE_ARS=  ** no en uso 
            item.SEGTEXT = descripcion1;
            item.SEGTEXT2 = descripcion2;
            //Item.DC=
            item.DOCUTIPO = tipoDocumento;
            item.REFE = numeroDocumento;
            if (idProveedor > 0)
            {
                item.PROV = idProveedor.ToString();
                item.CLIPROV_DESC = new VendorManager().GetSpecificVendor(idProveedor).prov_rsocial;
            }

            if (idCliente > 0)
            {
                item.CLIENTE = idCliente.ToString();
                item.CLIPROV_DESC = new CustomerManager().GetCustomerBillToData(idCliente).cli_rsocial;
            }

            item.LOG_USER = Environment.UserName;
            item.FECHA_HOY = DateTime.Today;
            item.DEBE = importeDebe;
            item.HABER = importeHaber;
            item.GL = gl;

            item.PERIODO = new PeriodoConversion().GetPeriodo(Convert.ToDateTime(H.FECHA));
            item.TIPO = H.TIPO;
            item.TCODE = tCode;

            if (idDocuLink > 0)
            {
                item.ALINK = idDocuLink;
            }

            item.REF_ALT_TBLID = referenciaTableName;
            if (string.IsNullOrEmpty(referenciaIdTexto) == false)
            {
                item.REF_ALT_IDTXT = referenciaIdTexto;
            }

            if (referenciaIdNumerico > 0)
            {
                item.REF_ALT_IDNUM = referenciaIdNumerico.ToString();
            }

            if (kg > 0)
            {
                item.KGMAT = kg;
            }

            if (string.IsNullOrEmpty(material) == false)
            {
                item.MATERIAL = material;
            }

            if (idTabla40 > 0)
            {
                item.ID40 = idTabla40;
            }

            item.NASX1 = H.NASX1;
            item.NASX2 = H.NASX2;
            item.HORA_OP = DateTime.Now;

            //Item.UPDUSER=
            //Item.GLL3=
            //Item.GLORI=
            if (String.IsNullOrEmpty(centroCosto) == false)
            {
                item.CC = centroCosto;
            }

            if (String.IsNullOrEmpty(status) == false)
            {
                item.ST = status;
            }

            item.CK = ck;
            I.Add(item);

        }

        private static int GetNextNumeroAsientoIdDocu()
        {
            return new TecserData(GlobalApp.CnnApp).T0601_DOCU_H.Max(c => c.IDDOCU) + 1;
        }

        private void SetNewAsientoNumber()
        {
            var vendor = new VendorManager().GetSpecificVendor(241); //temporal para pasar el TecserData(GlobalApp.CnnApp) context
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataAsn = new T0004_ASN();
                switch (H.TIPO)
                {
                    case "L1":
                        dataAsn.PRE = "1";
                        dataAsn.TIPO = "1";
                        break;
                    case "L2":
                        dataAsn.PRE = "8";
                        dataAsn.TIPO = "2";
                        break;

                    default:
                        MessageBox.Show(@"Error no manejado en tipo de documento TipoLX!");
                        H.IDDOCU = 0;
                        H.NASX1 = -1;
                        H.NASX2 = -1;
                        break;
                }

                var data =
                    db.T0004_ASN.SingleOrDefault(
                        c => c.XYEAR == H.YEAR.Substring(2, 2) && c.TIPO == H.TIPO.Substring(1, 1));
                if (data == null)
                {
                    dataAsn.ASN = 0;
                    dataAsn.XYEAR = H.YEAR.Substring(2, 2);
                    dataAsn.XDOC = "AS";
                    dataAsn.NASX1X2 =
                        Convert.ToDecimal(dataAsn.PRE.ToString() + dataAsn.XYEAR + H.MES.ToString() + "00000");
                    db.T0004_ASN.Add(dataAsn);
                    db.SaveChanges();
                    H.NASX1 = Convert.ToDecimal(dataAsn.NASX1X2);
                    H.NASX2 = 0;
                    H.IDDOCU = GetNextNumeroAsientoIdDocu();
                }
                else
                {
                    var asn = Convert.ToString(data.ASN + 1);
                    var numeroAsiento = data.PRE.ToString() + data.XYEAR + H.MES.ToString() +
                                        asn.PadLeft(5, '0');

                    data.ASN = (short?)(data.ASN + 1);
                    dataAsn.NASX1X2 = Convert.ToDecimal(numeroAsiento);
                    db.SaveChanges();
                    H.NASX1 = Convert.ToDecimal(dataAsn.NASX1X2); //**move to decimal
                    H.NASX2 = data.ASN;
                    H.IDDOCU = GetNextNumeroAsientoIdDocu();
                }
            }
        }



        public bool GrabaAsientoCompletoDb()
        {
            if (CheckIfAsientoIsOK() != true)
                return false;
            return new TecserSQL.Data.TransactionalData.AsientoContable(GlobalApp.CnnApp).GrabaAsientoCompleto(H, I);
        }

        /// <summary>
        /// Chequea Importes y que Debe = Haber
        /// </summary>
        private bool CheckIfAsientoIsOK()
        {
            //todo: Completar la funcion.

            decimal sumaDebe = 0;
            decimal sumaHaber = 0;
            foreach (var item in I)
            {
                sumaDebe = sumaDebe + Convert.ToDecimal(item.DEBE);
                sumaHaber = sumaHaber + Convert.ToDecimal(item.HABER);
            }

            if (sumaDebe != sumaHaber) return false;

            H.TOT_ARS = sumaDebe;
            H.TOT_ORI = sumaDebe;
            return true;
        }

        public void ChangeAsientoCobranzaType(string numeroRecibo, string nuevoTipoAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ash = db.T0601_DOCU_H.SingleOrDefault(c => c.REFE == numeroRecibo && c.DOCUTIPO == "PA");
                if (ash != null)
                {
                    ash.TIPO = nuevoTipoAsiento;
                    var asi = db.T0602_DOCU_S.Where(c => c.IDDOCU == ash.IDDOCU).ToList();
                    foreach (var it in asi)
                    {
                        it.TIPO = nuevoTipoAsiento;
                    }
                    db.SaveChanges();
                }
            }
        }

        public void ChangeAsientoCobranzaCustomer(string numeroRecibo, int nuevoCustomer)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ash = db.T0601_DOCU_H.SingleOrDefault(c => c.REFE == numeroRecibo && c.DOCUTIPO == "PA");
                if (ash != null)
                {

                    var asi = db.T0602_DOCU_S.Where(c => c.IDDOCU == ash.IDDOCU).ToList();
                    foreach (var it in asi)
                    {
                        it.CLIENTE = nuevoCustomer.ToString();
                    }
                    db.SaveChanges();
                }
            }
        }




    }
}



