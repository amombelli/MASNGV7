using Tecser.Business.Transactional.CO.AsientoContable;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    public class XContabilizaNotaDebito : XContabilizaDocumentosBase
    {
        public XContabilizaNotaDebito(int idFactura) : base(idFactura)
        {
            Signo = 1;
        }


        public override ReturnContaCustomerDocument ContabilizacionCompleta()
        {
            base.AddRecordCtaCteDetalle201();
            base.AddRecordCtaCteImputacion207();
            base.UpdateSaldoCtaCte202();

            var asiento = new AsCustomerDocument(VariablesProgreso.IdFactura, "NCD");
            var asientoResultado = asiento.AsientoFromCustomerNotaDebito();
            VariablesProgreso.NumeroAsientoIdDocu = asientoResultado.IdDocu;
            VariablesProgreso.NumeroAsientoX1X2 = asientoResultado.NasX1;
            UpdateT0400AfterContabilizacion();
            return VariablesProgreso;
        }
    }
}
