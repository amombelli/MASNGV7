using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.HR
{
    public class SyJAdministracionPagos
    {
        public int IngresaPago(List<T0552_HHRR_SYJ_Payments> data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int id = 1;
                int idRetorno = 1;

                var r = db.T0552_HHRR_SYJ_Payments.OrderByDescending(c => c.IDPayment).FirstOrDefault();
                if (r != null)
                {
                    idRetorno = r.IDPayment + 1;
                    id = r.IDPayment + 1;
                }

                foreach (var rec in data)
                {
                    rec.IDPayment = id;
                    id++;
                }

                db.T0552_HHRR_SYJ_Payments.AddRange(data);
                if (db.SaveChanges() > 0)
                    return idRetorno;
                return 0;
            }
        }
        public void DeleteRecord(int idpayment)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0552_HHRR_SYJ_Payments.SingleOrDefault(c => c.IDPayment == idpayment);
                db.T0552_HHRR_SYJ_Payments.Remove(r);
                db.SaveChanges();
            }
        }
        public void UpdateSaldoPagoItems(int idSyJ, int idItem, decimal nuevoSaldo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var reg = db.T0551_HHRR_SYJ_Items.SingleOrDefault(c => c.IdHead == idSyJ && c.IdItem == idItem);
                reg.Adeudado = nuevoSaldo;
                db.SaveChanges();
            }
        }
        public void UpdateStatusPago(int idSyj, SyJManagerNew.StatusSyJ estado, decimal nuevoSaldoImpago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0550_HHRR_SYJ_Header.SingleOrDefault(c => c.ID == idSyj);
                h.EstadoRegistro = estado.ToString();
                h.MontoAdeudado = nuevoSaldoImpago;
                db.SaveChanges();
            }
        }

    }
}
