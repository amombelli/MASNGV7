using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI.CtaCte;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    //new 2018.04.06
    /// <summary>
    /// Funciones para contabilziacion de documento completo VENDOR desde documento FI
    /// Por medio de transacciones CONTAR, CONTA1
    /// Recordar que gestion 201,202,207,208 no se hace desde aca, sino que solo
    /// es la Invocacion de los metodos.
    /// </summary>
    public class ContaVendorFromInvoice : ContaVendorDocument
    {
        public ContaVendorFromInvoice(int idFactura, string tcode) : base(tcode)
        {
            base.IdFactura = idFactura;
            LoadDataInObjectMemory();
            SetTipoDocumento();


        }

        protected sealed override void LoadDataInObjectMemory()
        {
            base.LoadDataInObjectMemory();
        }

        protected override void AddRecordCtaCteDetalle201207()
        {
            var data = new CtaCteVendor(IdEntidad);
            var idCtaCte = data.AddCtaCteDetalleRecord(TipoDocSystem, TipoLx, H403.FECHA, H403.NFACTURA,
                IdFactura.ToString(), H403.MON, H403.IMPORI, H403.TC, H403.IMPORI, 0,
                IdFacturaX, H403.IDINT);
            base.IdCtaCte = idCtaCte;
        }

        protected override void SetTipoDocumento()
        {
            //vamos a usar directamente el tipo de Factura (A,C,TK,VEP,IMP...)
            //en este caso no mapea contra T605 para simplificar.
            TipoDocSystem = H403.TFACTURA;
        }

        protected override ReturnContaVendorDocument ManageContabilizacionCompleta()
        {
            var resultado = new ReturnContaVendorDocument();

            AddRecordCtaCteDetalle201207(); //+Record T201
            base.UpdateCtaCteSaldo(TipoLx, H403.MON, H403.IMPORI, H403.TC); //+Record T202
            resultado.IdCtaCte = base.IdCtaCte;

            var asiento = new AsientoVendorDocument(IdFactura, base.Tcode);
            asiento.AsientoFromVendorFactura();

            //Actualiza Status 0400
            return resultado;
        }
    }
}
