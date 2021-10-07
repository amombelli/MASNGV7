namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class NcdCalculoDiferenciaTc
    {
        public ManageTotalesCustomerNcd RecalculaimporteTC(int idFactura, decimal nuevoTC)
        {
            var x = new ManageTotalesCustomerNcd(idFactura, "ARS");
            x.GetUpdatedImporteAfterTCisChanged(nuevoTC);
            return x;
        }

        public ManageTotalesCustomerNcd RecalculaimporteUnitPriceChanged(int idFactura, int idItemFactura, decimal newUnitPrice)
        {
            var x = new ManageTotalesCustomerNcd(idFactura, "ARS");
            x.CalculaAfterUnitPriceIsChanged(idItemFactura, newUnitPrice);
            return x;
        }

    }
}
