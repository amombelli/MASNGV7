using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class PFFixAddCustomerInPF
    {
        public static void FixCompletaCustomerOV()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataToFix =
                    db.T0070_PLANPRODUCCION.Where(c => c.PLANPARA.ToUpper().Equals("OV") && c.CLIENTE == null).ToList();
                int i = 0;
                foreach (var data in dataToFix)
                {
                    var ov = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == data.OV.Value);
                    if (ov != null)
                    {
                        i = i + 1;
                        data.CLIENTE = ov.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_fantasia;
                        db.SaveChanges();
                    }
                }
                if (i > 0)
                {
                    MessageBox.Show($"se han completado automaticamente {i} nombres de Cliente relacionados con Ordenes de Venta", @"Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        public static void FixCompletaTDOC()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0070_PLANPRODUCCION.Where(c => c.TDOC == null);
                foreach (var item in x)
                {
                    item.TDOC = "OF";
                }
                db.SaveChanges();
            }
        }
    }
}
