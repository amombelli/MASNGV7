using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.ContabilizacionProveedores
{
    public class ManageContaConRemito
    {
        public void UpdateTabla40(int id63, string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t63 = db.T0063_ITEMS_OC_INGRESADOS.SingleOrDefault(c => c.ID == id63);
                if (t63 == null)
                    return;

                var t40 = db.T0040_MAT_MOVIMIENTOS.SingleOrDefault(c => c.IDMOVIMIENTO == t63.ID40.Value);
                t40.TIPO = tipoLx;
                db.SaveChanges();
            }
        }

        public void UpdateContabilizacionDatat0063(int id63, decimal costoARS, decimal costoUSD, decimal cantidad,
            string numeroFactura, bool addCostoEv, string tipoLx, decimal tipoCambio, string glAccount)
        {
            //costoEV >> esta operacion se agrega o no a la evolucion de costos.
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0063_ITEMS_OC_INGRESADOS.SingleOrDefault(c => c.ID == id63);
                if (data == null)
                    return;
                data.TC = tipoCambio;
                data.CONTA = true;
                data.CONTA_U_ARS = costoARS;
                data.CONTA_U_USD = costoUSD;
                data.CONTA_CANT = cantidad;
                data.ZINCLUIR = addCostoEv;
                data.NFACTURA = numeroFactura;
                data.TIPO = tipoLx;
                data.ADDED = false;
                data.GL = glAccount;
                //Updated Later: NASIENTO|ID40|
                db.SaveChanges();
            }
        }
    }
}
