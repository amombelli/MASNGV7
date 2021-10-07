using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MasterData;
using TecserEF.Entity;
using GlobalApp = Tecser.Business.MainApp.GlobalApp;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    //2018-03-20 Clase "sub-base" para todos los documentos de Vendor (T0403 + T0404)
    //Administra toda la gestion de Factura, Nota Credito, Nota Debito, Ajuste de Clientes
    public class VendorMainDocument : MainDocumentBase
    {
        protected VendorMainDocument(string tcode, int idFactura) : base(tcode, idFactura)
        {
            H.IDINT = idFactura;
            base.IdDocument = idFactura;
            if (idFactura > 0)
            {
                LoadDataObject();
            }
        }
        protected VendorMainDocument(int idVendor, string tcode) : base(idVendor, tcode)
        {
            //Constructor para crear

        }

        protected T0403_VENDOR_FACT_H H = new T0403_VENDOR_FACT_H();
        protected List<T0404_VENDOR_FACT_I> I = new List<T0404_VENDOR_FACT_I>();


        protected sealed override void LoadDataObject()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                H = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == IdDocument);
                if (H == null)
                    throw new InvalidOperationException("No Existe el registro en T0403*VENDORINVOICE");

                I = db.T0404_VENDOR_FACT_I.Where(c => c.IDINT == IdDocument).ToList();
            }
        }

        public void CreateNewHeaderInMemory(string tipoLx, DateTime fechaDocumento, string moneda, string tipoDocumento,
            string numeroDocumento, decimal importeTotalOri, decimal exchangeRate, decimal importeBrutoIni,
            decimal importeDescuento, decimal importeSubtotal, decimal importeBaseImponible, decimal importeIva105,
            decimal importeIva21, decimal importeIva27, decimal importeImpuestosInternos, decimal importeOtrosImpuestos,
            decimal importePercepcionIva, decimal? alicuotaPercepcionIva, decimal importePercepcionIIBB,
            decimal? alicuotaPercepcionIIBB, string descripcionDistritoIIBB,
            decimal importeImpMunicipal, decimal importeImpProvincial, decimal importeConceptosNoGravados,
            decimal importeNetoFinal, string glAP, string observacion, decimal cantidadKg,
            decimal importePercepcionGanancias, decimal? percGananciaAlicuota, decimal importeRedondeo,
            string statusDoc)
        {
            var vendorData = new VendorManager().GetSpecificVendor(IdEntidad);
            var h = new T0403_VENDOR_FACT_H
            {
                //IDINT asignado al grabar
                //IDCTACTE
                //NASIENTO
                //IdFacturaX
                IDPROV = IdEntidad,
                PROVRS = vendorData.prov_rsocial,
                PRTAX1 = vendorData.NTAX1,
                FECHA = fechaDocumento,
                MON = moneda,
                TFACTURA = tipoDocumento,
                NFACTURA = numeroDocumento,
                IMPORI = importeTotalOri,
                TC = exchangeRate,
                TIPO = tipoLx,
                BRUTO = importeBrutoIni,
                DTO = importeDescuento,
                SUBTOTAL = importeSubtotal,
                IVA10 = importeIva105,
                IVA21 = importeIva21,
                IMPINT = importeImpuestosInternos,
                IMPOTR = importeOtrosImpuestos,
                NETO = importeNetoFinal,
                LOGUSER = Environment.UserName,
                LOGDATE = DateTime.Now,
                TCODE = base.Tcode,
                GLAP = glAP,
                CANTKG = cantidadKg,
                OBSERVACION = observacion,
                PerIIBB_TXT = descripcionDistritoIIBB,
                BaseImponible = importeBaseImponible,
                PerIVA_Alicuota = alicuotaPercepcionIva,
                PerIVA = importePercepcionIva,
                PerGA_Alicuota = percGananciaAlicuota,
                PerGS = importePercepcionGanancias,
                PerIIBB = importePercepcionIIBB,
                PerIIBB_Alicuota = alicuotaPercepcionIIBB,
                SALDOIMPAGO = importeNetoFinal,
                IVA27 = importeIva27,
                ImpuestoMunicipal = importeImpMunicipal,
                ImpuestoProvincial = importeImpProvincial,
                ConceptosNoGravados = importeConceptosNoGravados,
                StatusDocumento = statusDoc,
                TOTALIVA = importeIva105 + importeIva21 + importeIva27,
                TotalImpuestosVarios = importePercepcionIva + importePercepcionIIBB + importePercepcionGanancias +
                                       importeConceptosNoGravados + importeImpMunicipal + importeImpProvincial +
                                       importeImpuestosInternos + importeOtrosImpuestos,
                RedondeoFinal = importeRedondeo,
            };


            //Si no informa Alicuota la Calcula en forma automatica
            if (importeBaseImponible != 0)
            {
                if (importePercepcionGanancias > 0 && percGananciaAlicuota == 0)
                {
                    H.PerGA_Alicuota = importePercepcionGanancias / importeBaseImponible;
                }

                if (importePercepcionIIBB > 0 && alicuotaPercepcionIIBB == 0)
                {
                    H.PerGA_Alicuota = importePercepcionIIBB / importeBaseImponible;
                }

                if (importePercepcionIva > 0 && alicuotaPercepcionIva == 0)
                {
                    H.PerIVA_Alicuota = importePercepcionIva / importeBaseImponible;
                }
            }

            //FIX por restriccion de diseño tabla SQL - Arreglar?
            if (h.PROVRS.Length > 50)
                h.PROVRS = h.PROVRS.Substring(0, 50);

            if (h.NFACTURA.Length > 13)
                h.NFACTURA = h.NFACTURA.Substring(0, 13);

            H = h;
        }

        public void AddItemInMemory(decimal cantidad, string itemDescripcion, string moneda, decimal precioUnitario,
            decimal exchangeRate, string glAccount, string idItem = "GENERIC")
        {
            var i = new T0404_VENDOR_FACT_I()
            {
                IDINT = H.IDINT,
                IDIT = I.Count + 1,
                ITEM_DESC = itemDescripcion,
                TC = exchangeRate,
                GL = glAccount,
                CANT = cantidad,
                IDITEM = idItem,
                MONEDA = moneda,
                //BRUTO
                //DTO
                //SUBTOTAL
                //IVA10
                //IVA21
                //RETIVA
                //RETIIBB
                //IMPINT
                //IMPOTR
                //NETO
                //PUNIT
            };
            if (i.MONEDA == "ARS")
            {
                i.PUNIT_USD = precioUnitario / exchangeRate;
                i.PUNIT_ARS = precioUnitario;
                i.PTOTAL_ARS = precioUnitario * cantidad;
                i.PTOTAL_USD = (precioUnitario / exchangeRate) * cantidad;
            }
            else
            {
                i.PUNIT_USD = precioUnitario;
                i.PUNIT_ARS = precioUnitario * exchangeRate;
                i.PTOTAL_ARS = precioUnitario * cantidad * exchangeRate;
                i.PTOTAL_USD = precioUnitario * cantidad;
            }
            I.Add(i);
        }
        public void UpdateSaldoImpagoT0403(decimal nuevoSaldoImpago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rx = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == IdDocument);
                rx.SALDOIMPAGO = nuevoSaldoImpago;
                db.SaveChanges();
            }
        }
        public void UpdateIdCtaCte_NAS_T403(int idFactura, int idCtaCte, int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == idFactura);
                t.IDCTACTE = idCtaCte;
                t.NASIENTO = numeroAsiento;
                db.SaveChanges();
            }
        }
        public FacturaId GrabaDocumento()
        {
            var dataReturn = new FacturaId();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (H.IDINT > 0)
                {
                    //documento existe - actualizamos data??
                    throw new NotImplementedException("Desarrollar actualizacion de T0403!");
                }
                else
                {
                    H.IDINT = db.T0403_VENDOR_FACT_H.Max(c => c.IDINT) + 1;
                    H.IdFacturaX = GetNextIdFacturaX(H.TIPO);
                    H.LOGDATE = DateTime.Now;
                    H.LOGUSER = Environment.UserName;
                    db.T0403_VENDOR_FACT_H.Add(H);
                }

                if (db.SaveChanges() == 0)
                {
                    dataReturn.IdFacturaX = 0;
                    dataReturn.IdFactura = 0;
                    dataReturn.CantidadItems = 0;
                    return dataReturn;
                }

                var numeroItem = 0;
                foreach (var item in I)
                {
                    numeroItem++;
                    item.IDINT = H.IDINT;
                    item.IDIT = numeroItem;
                    db.T0404_VENDOR_FACT_I.Add(item);
                }

                if (db.SaveChanges() != numeroItem)
                {
                    //ocurrio un error debiera hacer el rollback del header?
                    dataReturn.IdFacturaX = 0;
                    dataReturn.IdFactura = 0;
                    dataReturn.CantidadItems = numeroItem;
                    return dataReturn;
                }
                dataReturn.IdFacturaX = H.IdFacturaX.Value;
                dataReturn.IdFactura = H.IDINT;
                dataReturn.CantidadItems = numeroItem;
                return dataReturn;
            }
        }
        private int GetNextIdFacturaX(string tipoLx)
        {
            int constL1 = 100000000;
            int constL2 = 800000000;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (tipoLx == "L1")
                {
                    var x = (int)db.T0403_VENDOR_FACT_H.Where(c => c.TIPO == "L1").Max(c => c.IdFacturaX);
#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                    if (x == null)
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                        return constL1;
                    return x + 1;
                }
                else
                {
                    var x = (int)db.T0403_VENDOR_FACT_H.Where(c => c.TIPO == "L2").Max(c => c.IdFacturaX);
#pragma warning disable CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                    if (x == null)
#pragma warning restore CS0472 // The result of the expression is always 'false' since a value of type 'int' is never equal to 'null' of type 'int?'
                        return constL2;
                    return x + 1;

                }
            }
        }

        public T0403_VENDOR_FACT_H GetDocumentoHeader()
        {
            return H;
        }


        protected override bool AddMainDocumentHeader()
        {
            throw new NotImplementedException();
        }
        protected override bool AddMainDocumentItems()
        {
            throw new NotImplementedException();
        }


    }
}
