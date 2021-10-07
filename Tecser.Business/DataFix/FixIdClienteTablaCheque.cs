using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class FixIdClienteTablaCheque
    {
        public void FixIdCliente()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0154_CHEQUES.Where(c => c.IdClienteRecibido == null).OrderByDescending(c => c.IDCHEQUE).ToList();
                {
                    foreach (var ch in data)
                    {
                        var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.cli_fantasia == ch.CLIENTE);
                        if (cli != null)
                        {
                            ch.IdClienteRecibido = cli.IDCLIENTE;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        public void FixIdCliente(int idCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                {
                    var cli = db.T0006_MCLIENTES.Where(c => c.cli_fantasia == data.CLIENTE).ToList();
                    if (cli.Count > 0)
                    {
                        data.IdClienteRecibido = cli[0].IDCLIENTE;
                        db.SaveChanges();
                    }
                    else
                    {
                        cli = db.T0006_MCLIENTES.Where(c => c.cli_rsocial == data.CLIENTE).ToList();
                        if (cli.Count > 0)
                        {
                            data.IdClienteRecibido = cli[0].IDCLIENTE;
                            db.SaveChanges();
                        }
                    }

                    var x = db.T0154_CHEQUES.Where(c => c.CLIENTE == data.CLIENTE).ToList();
                    foreach (var xx in x)
                    {
                        xx.IdClienteRecibido = data.IdClienteRecibido;
                    }
                    db.SaveChanges();
                }
            }
        }



    }
}
