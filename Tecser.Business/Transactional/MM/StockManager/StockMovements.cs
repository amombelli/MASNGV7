using Tecser.Business.Transactional.CO.AsientoContable.Modules;

namespace Tecser.Business.Transactional.MM
{
    public class StockMovements : StockBase
    {
        public int MoveSloc(int idstock, decimal cantidad, string nuevaSloc, string tcode, bool logT40 = true)
        {
            base.SplitStockLineCantidad(idstock, cantidad);
            var slocOriginal = base.GetStockLine(idstock).SLOC;
            base.UpdateStockSloc(idstock, nuevaSloc);

            if (logT40)
                return new MmLog().LogMMChangeSLOC(idstock, cantidad, slocOriginal, nuevaSloc, tcode);
            return 0;
        }
        public int MoveEstado(int idstock, decimal cantidad, StockStatusManager.EstadoLote newEstado, string tcode,
            bool logT40 = true, string comentario = null)
        {
            base.SplitStockLineCantidad(idstock, cantidad);
            var estadoOriginal = base.GetStockLine(idstock).Estado;
            base.UpdateStockEstado(idstock, newEstado);

            if (logT40)
                return new MmLog().LogMMChangeEstado(idstock, cantidad, estadoOriginal, newEstado.ToString(), tcode, comentario: comentario);
            return 0;
        }
        public int ChangeLote(int idstock, decimal cantidad, string newLoteNumber, string tcode, bool logT40 = true)
        {
            base.SplitStockLineCantidad(idstock, cantidad);
            var loteOriginal = base.GetStockLine(idstock).Batch;
            base.UpdateStockLoteNumber(idstock, newLoteNumber);

            if (logT40)
                return new MmLog().LogMMChangeLoteNumber(idstock, cantidad, loteOriginal, newLoteNumber, tcode);
            return 0;
        }
        public int AjusteKgStock(int idstock, decimal cantidad, string tcode, bool logT40 = true, string comentarioAjuste = null)
        {
            var lineaStock = base.GetStockLine(idstock);
            var ajusteCantidad = cantidad - (decimal)lineaStock.Stock;
            base.UpdateStockCantidad(idstock, cantidad);

            new AsientoAjusteStock(tcode).Ajuste(lineaStock.Material, ajusteCantidad, comentarioAjuste);
            //asiento ajuste

            if (logT40)
                return new MmLog().LogMMAjusteKgStock(idstock, ajusteCantidad, tcode, comentario: comentarioAjuste);
            return 0;
        }





    }
}
