using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Customers
{
    public class ManageSinImputar
    {
        public ManageSinImputar(int idCliente)
        {
            _idCliente = idCliente;
        }

        private readonly int _idCliente;

        public decimal GetSaldosSinImputar()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == _idCliente).Sum(c => c.MONTO);
                if (data == null)
                    return 0;
                return data.Value;
            }
        }

    }
}
