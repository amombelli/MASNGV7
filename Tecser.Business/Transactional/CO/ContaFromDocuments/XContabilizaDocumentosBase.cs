using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    //2018.07.08 Esta clase intenta ser la version nueva para 
    //Contabilizar documentos (NC,ND,AJ,FA) 
    //Hoy FA no se hace desde aca!! pero estaria bueno migrarlo es mas sencillo.

    /// <summary>
    /// 2021-05.04 --> Clase Base Contabilizacion de Documentos con Base en T400.-
    /// No Sirve para Ajustes o Documentos X sin referente en T400.-
    /// </summary>
    public abstract class XContabilizaDocumentosBase
    {
        protected XContabilizaDocumentosBase(int idx)
        {
            _idFactura = idx;
            LoadHeader400();
        }

        //----------------------------------------------------------------------------
        protected int Signo;
        protected readonly int _idFactura;
        protected T0400_FACTURA_H H;
        protected CtaCteCustomer DataCtaCte;
        protected ReturnContaCustomerDocument VariablesProgreso = new ReturnContaCustomerDocument();
        public struct ReturnContaCustomerDocument
        {
            //estructura de retorno
            public int IdFactura;
            public decimal IdFacturaX;
            public int IdCtaCte;
            public bool DocumentoEncontrado;
            public ManageDocumentType.TipoDocumento TipoDoc;
            public int NumeroAsientoIdDocu;
            public decimal NumeroAsientoX1X2;
            public string NumeroDocumentoCompleto;
        }
        private void LoadHeader400()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                H = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _idFactura);
                DataCtaCte = new CtaCteCustomer(H.Cliente);
                VariablesProgreso.IdFactura = H.IDFACTURA;
                VariablesProgreso.IdFacturaX = H.IDFACTURAX.Value;
                VariablesProgreso.NumeroDocumentoCompleto = H.NumeroDoc; //al registrar vamos a generar el numero
            }
        }
        protected void AddRecordCtaCteDetalle201()
        {
            VariablesProgreso.IdCtaCte = DataCtaCte.AddCtaCteDetalleRecord(H.TIPO_DOC, H.TIPOFACT, H.FECHA,
                VariablesProgreso.NumeroDocumentoCompleto, H.IDFACTURAX.ToString(), H.FacturaMoneda, H.TotalFacturaN * Signo,
                H.TC, H.TotalFacturaN * Signo, idDocumentoPrincipal: H.IDFACTURA, idDocAlternativo: H.IDFACTURAX.Value);
        }
        protected void UpdateSaldoCtaCte202()
        {
            DataCtaCte.UpdateSaldoCtaCteResumen(H.TIPOFACT, H.TotalFacturaN * Signo, H.FacturaMoneda, H.TC);
        }
        protected void AddRecordCtaCteImputacion207()
        {
            DataCtaCte.AddRecordDocumentT0207FromIdCtaCte(VariablesProgreso.IdCtaCte);
        }
        public abstract ReturnContaCustomerDocument ContabilizacionCompleta(); //override 
        private string DefineNumeroDocumento()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (H.TIPOFACT == "L2")
                {
                    switch (H.TIPO_DOC)
                    {
                        case "ND":
                            var x = db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == H.IDFACTURA);
                            if (x == null)
                                return "ERROR";
                            return H.TIPO_DOC + "-" + x.IDH;
                        case "NC":
                            var y = db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == H.IDFACTURA);
                            if (y == null)
                                return "ERROR";
                            return H.TIPO_DOC + "-" + y.IDH;
                        case "FA":
                            return H.Remito;
                        default:
                            return "DOC-NO-DEFINIDO";
                    }
                }
                else
                {
                    if (H.StatusFactura == DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString())
                    {
                        return "IDFX-" + H.IDFACTURAX;
                    }

                    if (H.StatusFactura == DocumentFIStatusManager.StatusHeader.Registrada.ToString())
                    {
                        return "IDFX-" + H.IDFACTURAX;
                    }
                    return H.PV_AFIP + H.ND_AFIP;
                }
            }
        }
        protected void UpdateT0400AfterContabilizacion()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                H.IdCtaCte = VariablesProgreso.IdCtaCte;
                H.NAS = VariablesProgreso.NumeroAsientoIdDocu;
                H.NASX1X2 = VariablesProgreso.NumeroAsientoX1X2;

                var r400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == H.IDFACTURA);
                r400.IdCtaCte = H.IdCtaCte;
                r400.NAS = H.NAS;
                r400.NASX1X2 = H.NASX1X2;

                if (H.TIPOFACT == "L1")
                {
                    H.StatusFactura = DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString();
                    r400.StatusFactura = DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString();
                }
                else
                {
                    H.StatusFactura = DocumentFIStatusManager.StatusHeader.Aprobada.ToString();
                    r400.StatusFactura = DocumentFIStatusManager.StatusHeader.Aprobada.ToString();
                }

                var r401 = db.T0401_FACTURA_I.Where(c => c.IDFactura == H.IDFACTURA).ToList();
                foreach (var r in r401)
                {
                    r.NAS = H.NAS;
                }
                db.SaveChanges();
            }
        }
    }
}
