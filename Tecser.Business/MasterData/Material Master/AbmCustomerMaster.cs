using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.Material_Master
{
    public class AbmCustomerMaster
    {

        /// <summary>
        /// Si el ID es -1 crea el BillTo y retorna el numero de cliente creado.
        /// </summary>
        /// <returns>
        ///Si retorna 0 - El cliente existente no tuvo modificaciones
        /// Si retorna -1 es porlqeu el cliente no se pudo grabar o el cliente para modificar no se encontro.
        /// </returns>
        public int SaveT6Data(T0006_MCLIENTES data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (data.IDCLIENTE == -1)
                {
                    //Creacion del BillTo
                    data.LogCreadoPor = Environment.UserName;
                    data.Fecha_Ingreso = DateTime.Now;
                    data.IDCLIENTE = db.T0006_MCLIENTES.Max(c => c.IDCLIENTE) + 1;
                    db.T0006_MCLIENTES.Add(data);
                    if (db.SaveChanges() > 0)
                        return data.IDCLIENTE;
                    return -1;
                }

                var d = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == data.IDCLIENTE);
                if (d == null)
                {
                    return -1;
                }

                data.Fecha_Ingreso = d.Fecha_Ingreso;
                data.LogCreadoPor = d.LogCreadoPor;
                db.Entry(d).CurrentValues.SetValues(data);
                d.LogModificadoPor = Environment.UserName;
                d.LogModoficadoEn = DateTime.Today;
                return db.SaveChanges() > 0 ? d.IDCLIENTE : 0;
            }
        }
        public int SaveT7Data(T0007_CLI_ENTREGA data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (data.ID_CLI_ENTREGA == -1)
                {
                    //Creacion ShipTo
                    data.Log_Date = DateTime.Now;
                    data.Log_User = GlobalApp.AppUsername;
                    data.Fecha_Ingreso = DateTime.Now;
                    data.LogUserModificadoPor = null;
                    data.LogUserModificadoEn = null;
                    data.Ultimo_Movimiento = null;

                    data.ID_CLI_ENTREGA = db.T0007_CLI_ENTREGA.Max(C => C.ID_CLI_ENTREGA) + 1;
                    db.T0007_CLI_ENTREGA.Add(data);
                    if (db.SaveChanges() > 0)
                        return data.ID_CLI_ENTREGA;
                    return -1;
                }
                var d = db.T0007_CLI_ENTREGA.SingleOrDefault(c => c.ID_CLI_ENTREGA == data.ID_CLI_ENTREGA);
                if (d == null)
                {
                    return -1;
                }
                data.LogUserModificadoPor = GlobalApp.AppUsername;
                data.LogUserModificadoEn = DateTime.Now;
                db.Entry(d).CurrentValues.SetValues(data);
                return db.SaveChanges() > 0 ? d.ID_CLI_ENTREGA : 0;
            }
        }

        public int InactivaShipTo(int id7)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0007_CLI_ENTREGA.SingleOrDefault(c => c.ID_CLI_ENTREGA == id7);
                if (cli == null)
                    return -1;

                if (cli.Activo)
                {
                    cli.Activo = false;
                    cli.LogUserModificadoPor = GlobalApp.AppUsername;
                    cli.LogUserModificadoEn = DateTime.Now;
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0; //El Cliente ya estaba Inactivo
                }
            }
        }

        public int ActivaShipTo(int id7)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0007_CLI_ENTREGA.SingleOrDefault(c => c.ID_CLI_ENTREGA == id7);
                if (cli == null)
                    return -1;

                if (cli.Activo == false)
                {
                    cli.Activo = true;
                    cli.LogUserModificadoPor = GlobalApp.AppUsername;
                    cli.LogUserModificadoEn = DateTime.Now;
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0; //El Cliente ya estaba Inactivo
                }
            }
        }
    }
}

