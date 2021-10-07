using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.CtaCte
{

    //Clase para gestion de Limite de Credito Cliente
    public class CustomerCreditLimiteManager
    {
        public static decimal GetAutoCreditLimit(int idCliente, int days)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                DateTime fechaMin = DateTime.Today.AddDays(-days);
                DateTime fechaMax = DateTime.Today;                 //Ver si conviene Hoy - 1
                var data = db.T0201_CTACTE.Where(c => c.IDCLI == idCliente && c.Fecha.Value >= fechaMin && c.Fecha.Value < fechaMax && c.TDOC != "CO").ToList();

                if (!data.Any())
                    return 0;
                return data.Sum(c => c.IMPORTE_ARS);
            }
        }

        public static decimal GetManualCreditLimit(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (data.Limite_credito == null)
                    return 0;
                return (decimal)data.Limite_credito.Value;
            }
        }

        /// <summary>
        /// Obtiene el Limite de Credito en forma manual/automatica de acuerdo a la configuracion
        /// </summary>
        public static decimal GetCreditLimit(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                if (data.AutoCreditLimit)
                    return GetAutoCreditLimit(idCliente, data.AutoCreditLimitDays);
                return GetManualCreditLimit(idCliente);
            }
        }

        public void UpdateCreditLimitValue(int idCliente, int limiteCreditoManual, bool autoCalculo, int days)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                data.Limite_credito = limiteCreditoManual;
                data.AutoCreditLimit = autoCalculo;
                data.AutoCreditLimitDays = days;
                db.SaveChanges();
            }
        }
    }
}
