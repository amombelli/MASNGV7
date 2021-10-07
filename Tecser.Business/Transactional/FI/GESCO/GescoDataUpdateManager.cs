using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.GESCO
{
    public class GescoDataUpdateManager
    {

        public int UpdateRetiraPasarACobrar(int idCliente, DateTime fechaCobranza)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.TAUX_G3.SingleOrDefault(c => c.IDCLI == idCliente && c.PasarACobrarFecha <= fechaCobranza && c.PasarACobrar == true);
                if (data == null)
                    return 0;

                data.PasarACobrar = false;
                data.PasarACobrarFecha = null;
                data.ULTPAGO = fechaCobranza;

                return db.SaveChanges();
            }
        }



    }
}
