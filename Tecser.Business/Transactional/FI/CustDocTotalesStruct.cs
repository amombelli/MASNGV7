namespace Tecser.Business.Transactional.FI
{
    public class CustDocTotalesStruct
    {
        protected CustDocTotalesStruct(int idFactura, string monedaDocumento = "ARS")
        {
            IdFactura = idFactura;
            MonedaDocumento = monedaDocumento;
            ImporteTotalBrutoInicial = 0;
            ImporteDescuento = 0;
            PorcentajeDescuento = 0;
            ImporteSubtotal = 0;
            ImporteBaseImponible = 0;
            ImporteIva21 = 0;
            ImporteIva105 = 0;
            ImporteIva27 = 0;
            AlicuotaPerRetIIBB = 0;
            ImportePerRetIIBB = 0;
            ImportePerRetIVA = 0;
            ImporteImpuestosInternos = 0;
            ImporteImpuestosMunicipales = 0;
            ImporteOtrosImpuestos = 0;
            ImporteTotalNetoFinal = 0;
            ExchangeRate = 1;
        }

        protected int IdFactura { get; }
        public decimal ImporteTotalBrutoInicial;
        public decimal ImporteDescuento;
        public decimal PorcentajeDescuento;
        public decimal ImporteSubtotal;
        public decimal ImporteBaseImponible;
        public decimal ImporteIva21;
        public decimal ImporteIva105;
        public decimal ImporteIva27;
        public decimal AlicuotaPerRetIIBB;
        public decimal ImportePerRetIIBB;
        public decimal ImportePerRetIVA;
        public decimal ImporteImpuestosInternos;
        public decimal ImporteImpuestosMunicipales;
        public decimal ImporteOtrosImpuestos;
        public decimal ImporteTotalNetoFinal;
        public decimal ExchangeRate;
        public string MonedaDocumento;
    }
}