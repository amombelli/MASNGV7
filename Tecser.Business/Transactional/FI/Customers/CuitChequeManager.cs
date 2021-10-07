using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using WebServicesAFIP;

namespace Tecser.Business.Transactional.FI.Customers
{
    public class CuitChequeManager
    {
        public string GetDescripcionCuit(string numeroCuit, bool buscaWebservices = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cuit = db.T0157_INFOCUITCHEQUE.SingleOrDefault(c => c.CUIT == numeroCuit.Trim());
                if (cuit == null)
                {
                    return InsertCuit(numeroCuit, buscaWebservices);
                }
                else
                {
                    if (!string.IsNullOrEmpty(cuit.NOMBRE) || buscaWebservices != true) return null;
                    var padron = new PadronAfipWsA5(ModoEjecucion.Produccion);
                    var data = padron.ObtieneDatosPadronA5(numeroCuit);
                    if (data.Denominacion == null) return null;
                    if (data.Denominacion.Length > 45)
                    {
                        data.Denominacion.Substring(0, 48);
                    }
                    cuit.NOMBRE = data.Denominacion;
                    db.SaveChanges();
                    return cuit.NOMBRE;
                }
            }
        }
        private string InsertCuit(string numeroCuit, bool buscaWebservices)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = new T0157_INFOCUITCHEQUE()
                {
                    CUIT = numeroCuit,
                };
                if (buscaWebservices)
                {
                    var padron = new PadronAfipWsA5(ModoEjecucion.Produccion);
                    var data1 = padron.ObtieneDatosPadronA5(numeroCuit);
                    data.NOMBRE = data1.Denominacion;
                }
                db.T0157_INFOCUITCHEQUE.Add(data);
                db.SaveChanges();
                return data.NOMBRE;
            }
        }
    }
}
