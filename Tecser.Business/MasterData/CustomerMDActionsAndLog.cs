using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData
{
    public class CustomerMDActionsAndLog
    {
        public enum AccionBloqueo
        {
            BloqueaDespacho,
            BloqueaPedido,
            InactivaCliente,
            ActivaCliente,
            DesbloqueaDespacho,
            DesbloqueaPedido,
            CreacionCliente,
            ModificacionCliente
        };

        private static void LogBloqueoClientes(int idCli, AccionBloqueo accion, string motivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t = new tLogBloqueoClientes()
                {
                    idCliente = idCli,
                    accion = accion.ToString(),
                    idLog = MaxId(),
                    logFecha = DateTime.Now,
                    logUser = GlobalApp.AppUsername,
                    motivo = motivo
                };
                db.tLogBloqueoClientes.Add(t);
                db.SaveChanges();
            }
        }
        private static int MaxId()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var x = (from y in db.tLogBloqueoClientes
                         select (int?)y.idLog).Max();

                if (x == null)
                    return 1;
                return x.Value + 1;
            };
        }
        public static void BloqueaClienteDespacho(int idCliente, string motivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (cli == null)
                    return;

                cli.BLK_DELIVERY = true;
                db.SaveChanges();
                LogBloqueoClientes(idCliente, AccionBloqueo.BloqueaDespacho, motivo);
            }
        }
        public static void BloqueaClientePedido(int idCliente, string motivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (cli == null)
                    return;

                cli.BLK_PEDIDO = true;
                db.SaveChanges();
                LogBloqueoClientes(idCliente, AccionBloqueo.BloqueaPedido, motivo);
            }
        }
        public static void DesBloqueaClienteDespacho(int idCliente, string motivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (cli == null)
                    return;

                cli.BLK_DELIVERY = false;
                db.SaveChanges();
                LogBloqueoClientes(idCliente, AccionBloqueo.DesbloqueaDespacho, motivo);
            }
        }
        public static void DesBloqueaClientePedido(int idCliente, string motivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (cli == null)
                    return;

                cli.BLK_PEDIDO = false;
                db.SaveChanges();
                LogBloqueoClientes(idCliente, AccionBloqueo.DesbloqueaPedido, motivo);
            }
        }
        public static void ActivaCliente(int idCliente, string motivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (cli == null)
                    return;

                cli.ACTIVO = true;
                db.SaveChanges();
                LogBloqueoClientes(idCliente, AccionBloqueo.ActivaCliente, motivo);
            }
        }
        public static void InactivaCliente(int idCliente, string motivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (cli == null)
                    return;
                cli.ACTIVO = false;
                db.SaveChanges();
                LogBloqueoClientes(idCliente, AccionBloqueo.InactivaCliente, motivo);
                var cli7 = db.T0007_CLI_ENTREGA.Where(c => c.IDCLIENTE == idCliente).ToList();
                foreach (var c7 in cli7)
                {
                    c7.Activo = false;
                    db.SaveChanges();
                }
            }
        }
        public static void CreacionCliente(int idCliente, string motivo = "Nuevo Cliente")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (cli == null)
                    return;
                cli.BLK_DELIVERY = false;
                cli.BLK_PEDIDO = false;
                cli.ACTIVO = false;
                db.SaveChanges();
                LogBloqueoClientes(idCliente, AccionBloqueo.CreacionCliente, motivo);
            }
        }
        public static void ModificacionCliente(int idCliente, string motivo = "Actualizacion de Datos")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (cli == null)
                    return;
                LogBloqueoClientes(idCliente, AccionBloqueo.ModificacionCliente, motivo);
            }
        }
        public List<tLogBloqueoClientes> GetHistorialMovimientosBloqueo(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.tLogBloqueoClientes.Where(c => c.idCliente == idCliente).OrderByDescending(c => c.idLog)
                    .ToList();
            }
        }
    }
}
