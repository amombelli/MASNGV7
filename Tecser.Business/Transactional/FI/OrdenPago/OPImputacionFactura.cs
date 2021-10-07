using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.OrdenPago
{
    public class OPImputaFacturas
    {
        public OPImputaFacturas(int idOP)
        {
            _idOP = idOP;
        }

        private readonly int _idOP;

        public void ImputaFacturasOP()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var importeItemsPago = new OPImportesManagement(_idOP).GetImporteTotalItemsPago_ExcluidoRetenciones();
                //if (importeItemsPago == 0)
                //    return;

                var factu = db.T0213_OP_FACT.Where(c => c.IDOP == _idOP).ToList();
                foreach (var item in factu)
                {
                    decimal valorIIBB = 0;
                    decimal valorGS = 0;
                    if (item.RetencionIIBB != null)
                        valorIIBB = item.RetencionIIBB.Value;

                    if (item.RetencionGS != null)
                        valorGS = item.RetencionGS.Value;

                    var importeFacturaImputar = item.FACT_SALDO_IMPUTAR - valorIIBB - valorGS;

                    if (importeFacturaImputar >= importeItemsPago)
                    {
                        item.FACT_IMPUTADO = importeItemsPago;
                        importeItemsPago = 0;
                    }
                    else
                    {
                        item.FACT_IMPUTADO = importeFacturaImputar;
                        importeItemsPago = (decimal)(importeItemsPago - importeFacturaImputar);
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
