using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CRM
{
    public class PendientesDespacho
    {
        public class EstructuraPendientes
        {
            public int SO { get; set; }
            public string StatusH { get; set; }
            public string Cliente { get; set; }
            public string Material { get; set; }
            public decimal KgPedido { get; set; }
            public decimal Pendiente { get; set; }
            public string StatusI { get; set; }
            public DateTime? FechaOV { get; set; }
        }
        public List<EstructuraPendientes> ListaPendientes = new List<EstructuraPendientes>();
        public decimal KgPendientesDespacho { get; private set; }
        public int CantidadRegistros { get; private set; }
        public int CantidadClientesDiferentes { get; private set; }

        public PendientesDespacho()
        {
            KgPendientesDespacho = 0;
            CantidadClientesDiferentes = 0;
            CantidadRegistros = 0;
        }

        public List<EstructuraPendientes> GetPendienteDespachoMaterial(string primario, int? clienteRs = null)
        {
            var lx = new List<EstructuraPendientes>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = new List<T0046_OV_ITEM>();
                if (clienteRs == null)
                {
                    items = db.T0046_OV_ITEM.Where(c =>
                        c.materialPrimario == primario &&
                        (c.StatusItem == SalesOrderStatusManager.StatusItem.Parcial.ToString() ||
                         c.StatusItem == SalesOrderStatusManager.StatusItem.Pendiente.ToString())).ToList();
                }
                else
                {
                    items = db.T0046_OV_ITEM.Where(c =>
                        c.materialPrimario == primario && c.ClienteRZ == clienteRs.Value &&
                        (c.StatusItem == SalesOrderStatusManager.StatusItem.Parcial.ToString() ||
                         c.StatusItem == SalesOrderStatusManager.StatusItem.Pendiente.ToString())).ToList();
                }
                foreach (var p in items)
                {
                    var itx = new EstructuraPendientes()
                    {
                        Material = primario,
                        Cliente = p.T0045_OV_HEADER.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                        StatusH = p.T0045_OV_HEADER.StatusOV,
                        StatusI = p.StatusItem,
                        SO = p.IDOV,
                        KgPedido = p.Cantidad,
                        Pendiente = p.Cantidad - p.KGStockDespachados,
                        FechaOV = p.LOG_FECHA
                    };
                    lx.Add(itx);
                }
                CantidadRegistros = lx.Count;
                CantidadClientesDiferentes = 0;
                if (lx.Count > 0)
                {
                    KgPendientesDespacho = lx.Sum(c => c.Pendiente);
                    var query2 = from c in lx
                                 group c by c.Cliente;
                    CantidadClientesDiferentes = query2.Count();
                }
            }
            return lx;
        }

        public decimal KgPendienteDesapchoPrimario(string primario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0046_OV_ITEM.Where(c =>
                    c.materialPrimario == primario &&
                    (c.StatusItem == SalesOrderStatusManager.StatusItem.Parcial.ToString() ||
                     c.StatusItem == SalesOrderStatusManager.StatusItem.Pendiente.ToString())).ToList();
                decimal kgPendientes = 0;
                foreach (var x in items)
                {
                    kgPendientes = kgPendientes + (x.Cantidad - x.KGStockDespachados);
                }
                return kgPendientes;
            }
        }
    }
}
