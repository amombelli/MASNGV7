using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class RemitoStockManager
    {
        public bool RemoveStockLineRemito(int idRemito, int idItemRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lineaStockReservado =
                    db.T0030_STOCK.SingleOrDefault(
                        c => c.Estado == "ReservaRE" && c.ReservaID == idRemito && c.ReservaItem == idItemRemito);

                if (lineaStockReservado == null)
                    return false;

                var dataRemitoItem =
                    db.T0056_REMITO_I.SingleOrDefault(c => c.IDREMITO == idRemito && c.IDITEM == idItemRemito);


                var dataRemitoHeader = dataRemitoItem.T0055_REMITO_H.TIPO_REMITO;
                int idClienteFactu = dataRemitoItem.T0055_REMITO_H.T0007_CLI_ENTREGA.IDCLIENTE;
                try
                {
                    new MmLog().LogMovimientoT40(lineaStockReservado.Material, DateTime.Today, 50, "RE",
                        dataRemitoItem.NUMREMITO, dataRemitoItem.KGDESPACHADOS * -1, "RE0", lineaStockReservado.SLOC,
                        lineaStockReservado.EstadoAnteriorReserva, "E", dataRemitoHeader, lineaStockReservado.Batch, 0,
                        idClienteFactu, refTableName: "T0056_REMITO_I", refIdnum: idRemito);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                return new StockManager().DeleteStockLine(lineaStockReservado.IDStock);
            }
        }



    }
}
