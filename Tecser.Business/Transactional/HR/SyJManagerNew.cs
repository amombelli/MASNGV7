using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.HR
{
    /// <summary>
    /// Clase nueva para manejar la nueva interface de SYJ 
    /// 2021.03.21
    /// </summary>
    public class SyJManagerNew
    {
        public enum StatusSyJ
        {
            Inicial,
            Registrado,
            Contabilizado,
            PagoParcial,
            PagoTotal,
            Cancelado
        };

        public static StatusSyJ MapTextToStatus(string status)
        {
            if (status == "En Proceso")
                status = "Proceso";

            if (string.IsNullOrEmpty(status))
                status = StatusSyJ.Cancelado.ToString();
            try
            {
                return (StatusSyJ)Enum.Parse(typeof(StatusSyJ), status, true);
            }
            catch (Exception)
            {
                return StatusSyJ.Cancelado;
                throw;
            }
        }
        public List<T0550_HHRR_SYJ_Header> GetHeaders()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0550_HHRR_SYJ_Header.OrderByDescending(c => c.ID).ToList();
            }
        }
        public T0550_HHRR_SYJ_Header GetHeader(int idSyJ)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0550_HHRR_SYJ_Header.SingleOrDefault(c => c.ID == idSyJ);
            }
        }
        public List<T0551_HHRR_SYJ_Items> GetItems(int idSyj)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0551_HHRR_SYJ_Items.Where(c => c.IdHead == idSyj).ToList();
            }
        }
        public T0551_HHRR_SYJ_Items GetItem(int idSyj, int idI)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0551_HHRR_SYJ_Items.SingleOrDefault(c => c.IdItem == idI && c.IdHead == idSyj);
            }
        }
        public int AddItemList(int idH, List<T0551_HHRR_SYJ_Items> items)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var idI = 1;
                int a = 0;
                decimal apagar = 0;
                decimal impago = 0;
                var th = db.T0550_HHRR_SYJ_Header.SingleOrDefault(c => c.ID == idH);
                if (th == null)
                    return 0;

                var ti = db.T0551_HHRR_SYJ_Items.OrderByDescending(c => c.IdItem).FirstOrDefault();
                if (ti != null)
                    idI = ti.IdItem + 1;

                foreach (var i in items)
                {
                    var t = new T0551_HHRR_SYJ_Items()
                    {
                        LX = i.LX,
                        IdItem = idI,
                        Shortname = i.Shortname,
                        BasicoUnit = i.BasicoUnit,
                        IdHead = idH,
                        ModoLiquidacion = i.ModoLiquidacion,
                        Concepto = i.Concepto,
                        Imponible = i.Imponible,
                        NoImponible = i.NoImponible,
                        Observacion = i.Observacion,
                        Descuentos = i.Descuentos,
                        Descuentos2 = i.Descuentos2,
                        Adeudado = i.Adeudado,
                        NetoPagar = i.NetoPagar,
                        Adicional2 = i.Adicional2,
                        LogDateCreado = DateTime.Now,
                        LogUserCreado = GlobalApp.AppUsername,
                        Cantidad = i.Cantidad
                    };
                    apagar += t.NetoPagar;
                    impago += t.Adeudado;
                    db.T0551_HHRR_SYJ_Items.Add(t);
                    db.SaveChanges();
                    idI++;
                    a++;
                }
                th.MontoAdeudado = impago;
                th.MontoTotal = apagar;
                db.SaveChanges();
                return a;
            }
        }
        public void AddItemToExistingData(int idH)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var idI = 1;
                var th = db.T0550_HHRR_SYJ_Header.SingleOrDefault(c => c.ID == idH);
                if (th == null)
                    return;

                var ti = db.T0551_HHRR_SYJ_Items.OrderByDescending(c => c.IdItem).FirstOrDefault();
                if (ti != null) idI = ti.IdItem + 1;

                var i = new T0551_HHRR_SYJ_Items()
                {
                    LX = th.LX,
                    IdItem = idI,
                    IdHead = idH,
                    //completar con el resto de la info

                };
                db.T0551_HHRR_SYJ_Items.Add(i);
                db.SaveChanges();
            }
        }
        public int CreaHeader(DateTime fecha, string periodoPago, string periodoQ, string concepto, string observacion, string lx, decimal montoTotal, string moneda = "ARS")
        {
            var id = 1;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0550_HHRR_SYJ_Header.OrderByDescending(c => c.ID).FirstOrDefault();
                if (r != null)
                    id = r.ID + 1;

                var t = new T0550_HHRR_SYJ_Header()
                {
                    Moneda = moneda,
                    LX = lx,
                    Fecha = fecha,
                    LogUser = GlobalApp.AppUsername,
                    ID = id,
                    Concepto = concepto,
                    LogDate = DateTime.Now,
                    Observacion = observacion,
                    MontoAdeudado = montoTotal,
                    MontoTotal = montoTotal,
                    PeriodoConta = periodoPago,
                    PeriodoQ = periodoQ,
                    EstadoRegistro = StatusSyJ.Registrado.ToString()
                };
                db.T0550_HHRR_SYJ_Header.Add(t);
                db.SaveChanges();
                return id;
            }

        }

        public void UpdateStatusContabilizadoOk(int idSyj, int nas)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0550_HHRR_SYJ_Header.SingleOrDefault(c => c.ID == idSyj);
                h.NAS = nas;
                h.EstadoRegistro = StatusSyJ.Contabilizado.ToString();
                db.SaveChanges();

                var i = db.T0551_HHRR_SYJ_Items.Where(c => c.IdHead == idSyj).ToList();
                foreach (var ii in i)
                {
                    ii.NAS = nas;
                }
                db.SaveChanges();
            }
        }

    }
}
