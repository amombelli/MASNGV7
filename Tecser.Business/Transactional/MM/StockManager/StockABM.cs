namespace Tecser.Business.Transactional.MM
{
    public class StockABM : StockBase
    {
        public int AltaNewStockLine(string material, string lote, decimal cantidadKg,
            StockStatusManager.EstadoLote estadoLote, string sloc, string tcode, bool autoLog = true, string comentario = null)
        {
            var stock = StockLineConstructor(material, lote, cantidadKg, estadoLote, sloc);
            if (autoLog)
            {
                new MmLog().LogMMAltaNewStockLine(stock, material, lote, estadoLote.ToString(), sloc, cantidadKg, tcode, comentario);
            }
            return stock;
        }

        public void UpdateStockLine(int idstock, string nuevoLote)
        {

        }

        public void DeleteStockLine()
        {

        }


    }
}
