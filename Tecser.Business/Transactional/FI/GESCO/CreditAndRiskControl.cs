using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.GESCO
{
    public class CreditAndRiskControl
    {
        public decimal GetCreditLimit(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cl = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (cl == null)
                    return 0;
                if (cl.Limite_credito == null)
                    return 0;
                return (decimal)cl.Limite_credito;
            }
        }
        public int UpdateCreditControlCcl(int idCliente, bool blkPedido, bool blkEntrega, bool allowL1, bool allowL2,
            bool allowL5, string ztermL1, string ztermL2, int limiteCredito, double descuentoPorcentaje,
            string motivoEspecialDescuento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cl = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                cl.BLK_DELIVERY = blkEntrega;
                cl.BLK_PEDIDO = blkPedido;
                cl.AllowL1 = allowL1;
                cl.AllowL2 = allowL2;
                cl.AllowL5 = allowL5;
                cl.ZTERML1 = ztermL1;
                cl.ZTERML2 = ztermL2;
                cl.Limite_credito = limiteCredito;
                cl.Descuento = descuentoPorcentaje;
                cl.MotivoDescuento = motivoEspecialDescuento;
                cl.LogModoficadoEn = DateTime.Today;
                cl.LogModificadoPor = Environment.UserName;
                return db.SaveChanges();
            }


        }
    }
}
