using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData;
using TecserEF.Entity;


namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    //new 2018.03.28
    /// <summary>
    /// Funciones para contabilziacion de documento completo desde documento FI
    /// Recordar que gestion 201,202,207,208 no se hace desde aca, sino que solo
    /// es la Invocacion de los metodos.
    /// </summary>
    public class ContaCustomerFromInvoice : ContaCustomerDocument
    {
        public ContaCustomerFromInvoice(string tcode, int idFactura) : base(tcode)
        {
            base.IdFactura = idFactura;
            LoadDataInObjectMemory();
            SetTipoDocumento();
            NumeroDocumento = new CustomerInvoice(tcode, idFactura).GetNumeroDocumentoCompleto();
        }

        protected sealed override void LoadDataInObjectMemory()
        {
            base.LoadDataInObjectMemory();
        }

        protected sealed override void SetTipoDocumento()
        {
            TipoDocSystem = base.H400.TIPO_DOC;
            switch (H400.TIPO_DOC)
            {
                case "FA":
                    TipoDocumento = TipoLx == "L1"
                        ? ManageDocumentType.TipoDocumento.FacturaVentaA
                        : ManageDocumentType.TipoDocumento.FacturaVenta2;
                    break;
                case "FB":
                    TipoDocumento = ManageDocumentType.TipoDocumento.FacturaVentaB;
                    break;
                case "FM":
                    TipoDocumento = ManageDocumentType.TipoDocumento.FacturaVentaM;
                    break;
                default:
                    TipoDocumento = ManageDocumentType.TipoDocumento.FacturaVentaA;
                    break;
            }
        }

        public override ReturnContaCustomerDocument ManageContabilizacionCompleta()
        {
            var resultado = new ReturnContaCustomerDocument();

            AddRecordCtaCteDetalle201207(); //+Record T201

            base.UpdateCtaCteSaldo(TipoLx, H400.FacturaMoneda, H400.TotalFacturaN, H400.TC); //+Record T202
            resultado.IdCtaCte = base.IdCtaCte;
            resultado.IdFactura = H400.IDFACTURA;
            resultado.IdFacturaX = (decimal)H400.IDFACTURAX;
            var asiento = new AsCustomerDocument(IdFactura, base.Tcode);
            var asientoResultado = asiento.AsientoFromCustomerFactura();
            resultado.NumeroAsientoIdDocu = asientoResultado.IdDocu;
            resultado.NumeroAsientoX1X2 = asientoResultado.NasX1;
            UpdateT0400AfterContabilizacion(asientoResultado.IdDocu, asientoResultado.NasX1);
            return resultado;
        }

        /// <summary>
        /// Add record in T0201 / T0207 
        /// </summary>
        protected override void AddRecordCtaCteDetalle201207()
        {
            var data = new CtaCteCustomer(IdEntidad);

            var idCtaCte = data.AddCtaCteDetalleRecord(TipoDocSystem, TipoLx, H400.FECHA, NumeroDocumento,
                IdFacturaX.ToString(), H400.FacturaMoneda, H400.TotalFacturaN, H400.TC, H400.TotalFacturaN, 0,
                IdFacturaX, IdFactura);

            data.AddRecordDocumentT0207FromIdCtaCte(idCtaCte);
            base.IdCtaCte = idCtaCte;
        }

        private void UpdateT0400AfterContabilizacion(int numeroAsiento, decimal numeroAsientoX1)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURAX == H400.IDFACTURAX);
                if (r400 == null)
                    return;

                r400.IdCtaCte = base.IdCtaCte;
                r400.NAS = numeroAsiento;
                r400.NASX1X2 = numeroAsientoX1;
                if (H400.TIPOFACT == "L1")
                {
                    r400.StatusFactura = DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString();
                }
                else
                {
                    r400.StatusFactura = DocumentFIStatusManager.StatusHeader.Aprobada.ToString();
                }
                db.SaveChanges();
            }
        }
    }
}



