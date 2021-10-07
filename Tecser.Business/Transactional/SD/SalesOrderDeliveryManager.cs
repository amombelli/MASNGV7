using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    //referente a actulizacion y comportamiento de una SO desde el delivery/remito
    public class SalesOrderDeliveryManager
    {
        public bool CheckItemIsOkToShip(int idSO, int idItem, string materialPrimario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lineaSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (lineaSO == null)
                    return false;

                if (lineaSO.materialPrimario != materialPrimario)
                    return false;
            }
            return true;
        }
        public bool CheckKgIsOkToShip(int idSO, int idItem, decimal kgRemito)
        {

            decimal margenDespacho = (decimal)0.1; //margen de despacho = 10%

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lineaSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (lineaSO == null)
                    return false;

                if (lineaSO.KGStockDespachados == null)
                    lineaSO.KGStockDespachados = 0;

                var kgPendientesDespacho = lineaSO.Cantidad - lineaSO.KGStockDespachados;

                if (kgPendientesDespacho <= 0)
                    return false; //no hay kg para despachar;

                if (kgPendientesDespacho * (1 + margenDespacho) < kgRemito)
                    return false; //se supera el margen de despacho;
            }
            return true;
        }

        //Luego actualizar el status de item + header ov
        public void UpdateDeliveryQty(int idSO, int idItem, decimal kgRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lineaSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                lineaSO.KGStockDespachados += kgRemito;
                db.SaveChanges();
            }
        }
    }
}
