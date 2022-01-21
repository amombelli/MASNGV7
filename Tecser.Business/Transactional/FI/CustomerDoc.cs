using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public abstract class CustomerDoc
    {
        protected string DocumentoAutorizadoPor = "Sin Asignar";
        protected ManageDocumentType.TipoDocumento TipoDocumento;
        protected string MotivoDocumentoString;
        protected int? IdAlternativo = null; //id1 Pasado como parametro por ejemplo IdCheque [Rechazo]
        protected GestionT400 T400;
        protected GestionT300 T300 = new GestionT300();
        public int? IdFacturaAsociada { get; private set; } //Para CAE
        public DateTime? PeriodoDesde { get; private set; } //Para CAE
        public DateTime? PeriodoHasta { get; private set; } //Para CAE
        public string NumeroDocumentoAsociado { get; private set; }
        public void SetDocumentoAsociado(int idDocumentoAsociado)
        {
            if (idDocumentoAsociado > 0)
            {
                IdFacturaAsociada = idDocumentoAsociado;
                PeriodoDesde = null;
                PeriodoHasta = null;
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    var h = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idDocumentoAsociado);
                    if (h != null)
                        NumeroDocumentoAsociado = h.TIPO_DOC + "/" + h.NumeroDoc;
                    if (T300.H3 != null)
                    {
                        T300.H3.idFacturaAsociada = IdFacturaAsociada;
                        T300.H3.PeriodoAjusteDesde = PeriodoDesde;
                        T300.H3.PeriodoAjusteHasta = PeriodoHasta;
                        var h3 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == T300.H3.IDH);
                        if (h3 != null)
                        {
                            h3.idFacturaAsociada = IdFacturaAsociada;
                            h3.PeriodoAjusteDesde = PeriodoDesde;
                            h3.PeriodoAjusteHasta = PeriodoHasta;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        public void SetPeriodoAsociado(DateTime periodoDesde, DateTime periodoHasta)
        {
            IdFacturaAsociada = null;
            NumeroDocumentoAsociado = null;
            PeriodoDesde = periodoDesde;
            PeriodoHasta = periodoHasta;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (T300.H3 != null)
                {
                    T300.H3.idFacturaAsociada = IdFacturaAsociada;
                    T300.H3.PeriodoAjusteDesde = PeriodoDesde;
                    T300.H3.PeriodoAjusteHasta = PeriodoHasta;
                    var h3 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == T300.H3.IDH);
                    if (h3 != null)
                    {
                        h3.idFacturaAsociada = IdFacturaAsociada;
                        h3.PeriodoAjusteDesde = PeriodoDesde;
                        h3.PeriodoAjusteHasta = PeriodoHasta;
                        db.SaveChanges();
                    }
                }
            }
        }
        public int Id400 { get; protected set; }
        public int Id300 { get; protected set; }
        public enum TipoLx
        {
            L1,
            L2
        };
        public TipoLx MapLxFromString(string tipo)
        {
            if (tipo == "L1")
                return TipoLx.L1;
            return TipoLx.L2;
        }

        public int GetId400()
        {
            return T400.H4.IDFACTURA;
        }
        public int GetId300()
        {
            return T300.H3.IDH;
        }
        public T0400_FACTURA_H GetHeader()
        {
            return T400.H4;
        }
        public T0300_NCD_H GetHeader300()
        {
            return T300.H3;
        }
        public List<T0401_FACTURA_I> GetItems()
        {
            return T400.I4.ToList();
        }
        public TotalesCustomerFi GetTotalesFromHeader()
        {
            return T400.MapH4ImportesToImportes();
        }
        public TotalesCustomerFi SetTotalesInHeaderFromItems()
        {
            T400.MapImportesFromItems();
            return T400.MapH4ImportesToImportes();
        }
        public void AddItems(string item, string itemDescripcion, decimal importe, string gl,
            bool aplicaIva21, decimal cantidad = 1, string moneda = "ARS", string gli = null)
        {
            T400.AddItemsMemory(item, itemDescripcion, cantidad, moneda, importe, gl, gli, aplicaIva21, 0, null, null);
        }
        public void SetAutorizacionDocumento(string autorizacion)
        {
            T300.UpdateAutorizacionDocumento(autorizacion);
        }
        public DocumentFIStatusManager.StatusHeader Registrar(string comentario, bool usarValorAbusoluto = false)
        {
            Id400 = T400.Registrar(usarValorAbusoluto);
            T300.CreaHeaderMemoria(T400.H4, comentario, MotivoDocumentoString, IdFacturaAsociada, PeriodoDesde, PeriodoHasta, IdAlternativo, DocumentoAutorizadoPor);
            Id300 = T300.Registra();
            T400.UpdateIdNcd(Id300);
            return new DocumentFIStatusManager().MapStatusHeaderFromText(T400.H4.StatusFactura);
        }
        public void CreaHeader(ManageDocumentType.TipoDocumento tipoDoc, int idCliente, string tipoLx,
            DateTime fechaDocumento, decimal tc, string zTerm, string glAR, bool impactaVentas, string autorizadoPor,
            string monedaDocumento = "ARS", int? idAlternativo = null)
        {
            TipoDocumento = tipoDoc;
            T400.AddHeaderMemory(TipoDocumento, idCliente, tipoLx, fechaDocumento, tc, zTerm, glAR, impactaVentas, null,
                monedaDocumento);
            IdAlternativo = idAlternativo;
            DocumentoAutorizadoPor = autorizadoPor;
        }
        public static List<T0400_FACTURA_H> GetListaDocumentosSeleccionar(int idCliente, string tipo,
            bool includeFactura, bool includeNc, bool includeNd, bool includeAjustes, bool includeCreditoX,
            bool includeDebitoX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var l = db.T0400_FACTURA_H.Where(c => c.Cliente == idCliente && c.TIPOFACT == tipo).ToList();
                if (!includeFactura)
                {
                    l.RemoveAll(c => c.TIPO_DOC.Contains("FA"));
                    l.RemoveAll(c => c.TIPO_DOC.Contains("FM"));
                }

                if (!includeNc)
                {
                    l.RemoveAll(c => c.TIPO_DOC.Contains("NC"));
                    l.RemoveAll(c => c.TIPO_DOC.Contains("CM"));
                }

                if (!includeNd)
                {
                    l.RemoveAll(c => c.TIPO_DOC.Contains("ND"));
                    l.RemoveAll(c => c.TIPO_DOC.Contains("DM"));
                }

                if (!includeAjustes)
                {
                    l.RemoveAll(c => c.TIPO_DOC.Contains("AJ"));
                }

                if (!includeCreditoX)
                {
                    l.RemoveAll(c => c.TIPO_DOC.Contains("CX"));
                }

                if (!includeDebitoX)
                {
                    l.RemoveAll(c => c.TIPO_DOC.Contains("DX"));
                }

                return l.OrderByDescending(c => c.FECHA).ToList();
            }
        }

    }
}
