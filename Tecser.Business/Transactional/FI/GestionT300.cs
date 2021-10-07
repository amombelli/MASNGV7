using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class GestionT300
    {
        private int _idH;

        public GestionT300()
        {
            
        }

        public GestionT300(int idH)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _idH = idH;
                H3 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idH);
            }
        }

        //Variables
        public T0300_NCD_H H3 { get; private set; } = new T0300_NCD_H();
        public void CreaHeaderMemoria(T0400_FACTURA_H h, string comentario,string motivoApp, int? idFacturaAjusta, DateTime? periodoAjusteDesde, DateTime? periodoAjusteHasta, int? idSegunMotivo, string autorizadoPor)
        {
            H3 = new T0300_NCD_H()
            {
                IDH = -1,
                ImporteARS = 0,
                ImporteUSD = 0,
                COMENTARIO = comentario,
                PeriodoAjusteDesde = periodoAjusteDesde,
                PeriodoAjusteHasta = periodoAjusteHasta,
                idFacturaAsociada = idFacturaAjusta,
                //
                NDOC = h.NumeroDoc,
                LX = h.TIPOFACT,
                FECHA = h.FECHA,
                IdCliente = h.Cliente,
                LOGDATE = DateTime.Now,
                LOGUSER = GlobalApp.AppUsername,
                RazonSocial = h.RAZONSOC,
                TC = h.TC,
                TEMP = true,
                MON = h.FacturaMoneda,
                TDOC = h.TIPO_DOC,
                //
                idFacturaT0400 = h.IDFACTURA,
                idFacturaX = h.IDFACTURAX,
                Motivo = motivoApp,
                IdMotivoAsociado = idSegunMotivo,
                OperacionRevisada = false,
                AutorizadoPor = autorizadoPor,
                ASIENTO = null,
                idCtaCte = null,
            };
        }
        public int Registra()
        {
            //graba en tabla y asigna IDH 
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (H3.IDH > 0)
                {
                    var z = db.T0301_NCD_I.Where(c => c.IDH == H3.IDH).ToList();
                    foreach (var i in z)
                    {
                        db.T0301_NCD_I.Remove(i);
                        db.SaveChanges();
                    }
                    var idH = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H3.IDH);
                    if (idH != null) db.T0300_NCD_H.Remove(idH);
                    db.SaveChanges();
                }
                H3.IDH = db.T0300_NCD_H.Max(c => c.IDH) + 1;
                H3.LOGUSER = GlobalApp.AppUsername;
                H3.LOGDATE = DateTime.Now;
                db.T0300_NCD_H.Add(H3);
                if (db.SaveChanges() > 0)
                {
                    _idH = H3.IDH;
                }
                else
                {
                    _idH = -1;
                }
                return _idH;
            }
        }

        public void Unregistra()
        {
            //elimina de Db
            //graba en tabla y asigna IDH 
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (H3.IDH > 0)
                {
                    var z = db.T0301_NCD_I.Where(c => c.IDH == H3.IDH).ToList();
                    foreach (var i in z)
                    {
                        db.T0301_NCD_I.Remove(i);
                        db.SaveChanges();
                    }
                    var idH = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H3.IDH);
                    if (idH != null)
                    {
                        db.T0300_NCD_H.Remove(idH);
                        db.SaveChanges();
                    }
                }
                //reset datos registro
                _idH = -1;
                H3.IDH = -1;
                H3.TEMP = true;
                H3.idFacturaX = null;
            }
        }



        /// <summary>
        /// Actualiza Info en T300 luego de la contabilizacion (importes/asiento/temp = false)
        /// </summary>
        public void UpdateDatosAfterConta()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H3.IDH);
                var h400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == H3.idFacturaT0400.Value);
                
                //Update Importes
                if (h400.FacturaMoneda == "ARS")
                {
                    //moneda ARS
                    h.ImporteARS = Math.Round(h400.TotalFacturaN, 2);
                    h.ImporteUSD = Math.Round(h400.TotalFacturaN / h.TC, 2);
                }
                else
                {
                    //moneda USD
                    h.ImporteARS = Math.Round(h400.TotalFacturaN/h.TC, 2);
                    h.ImporteUSD = Math.Round(h400.TotalFacturaN, 2);
                }
                h.TEMP = false;
                h.ASIENTO = h400.NAS;
                db.SaveChanges();
                H3 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _idH);
            }
        }

        public void UpdateOperacionRevisada(bool revisado)
        {
            H3.OperacionRevisada = revisado;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H3.IDH);
                h.OperacionRevisada = revisado;
                db.SaveChanges();
                //si funciona reemplazar por **RegrabaDatosFromHeader**
            }
        }

        public void UpdateIdAsociadoAltearnativo(int? idAlternativo)
        {
            H3.IdMotivoAsociado = idAlternativo;
            RegrabaDatosFromHeader();
        }

        public void UpdateAutorizacionDocumento(string usuarioAutrizante)
        {
            H3.AutorizadoPor = usuarioAutrizante;
            RegrabaDatosFromHeader();
        }

        private T0300_NCD_H RegrabaDatosFromHeader()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H3.IDH);
                if (data != null)
                {
                    db.Entry(data).CurrentValues.SetValues(H3);
                    db.SaveChanges();
                }

                return H3;
            }
        }



    }
}
