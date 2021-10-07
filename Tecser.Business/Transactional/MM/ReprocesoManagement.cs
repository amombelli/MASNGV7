using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class ReprocesoManagement
    {
        public List<T0005_MPROVEEDORES> GetListadoProveedoresReproceso()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0005_MPROVEEDORES.Where(c => c.TIPO == "REPRO").ToList();
            }
        }

        public List<T0063_ITEMS_OC_INGRESADOS> GetLstMaterialesIngresadosByVendor(int idProveedor = 0,
            bool soloPendienteConta = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloPendienteConta)
                {
                    return db.T0063_ITEMS_OC_INGRESADOS.Where(
                        c => c.PROVEEDOR == idProveedor && c.CONTA.Value == false && c.REPRO.Value)
                        .OrderBy(c => c.ID)
                        .ToList();
                }
                else
                {
                    return db.T0063_ITEMS_OC_INGRESADOS.Where(c => c.PROVEEDOR == idProveedor)
                        .OrderByDescending(c => c.ID)
                        .ToList();
                }
            }
        }

        public void SetContabilizado(int id63, int numeroOV, string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0063_ITEMS_OC_INGRESADOS.SingleOrDefault(c => c.ID == id63);
                x.CONTA = true;
                x.REPRO = true;
                x.NP = numeroOV;
                x.TIPO = tipoLx;
                db.SaveChanges();

            }
        }
    }
}

