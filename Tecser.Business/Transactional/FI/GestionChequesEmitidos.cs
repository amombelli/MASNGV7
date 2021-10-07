using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class GestionChequesEmitidos
    {
        public enum StatusChequeEmitido
        {
            Pendiente,
            Acreditado,
            Anulado,
            Vencido,
            Proximo,
            NoAcred
        };


        public StatusChequeEmitido MapStatusChequeToType(string status)
        {
            //if (String.IsNullOrEmpty(status))
            //    return StatusStockMemoria.ErrorStk;
            //if (status.ToUpper().Equals("EN PREPARACION") || status.ToUpper().Equals("EN_PREPARACION"))
            //    return StatusStockMemoria.SinStock;
            try
            {
                return (StatusChequeEmitido) Enum.Parse(typeof(StatusChequeEmitido), status, true);
            }
            catch (Exception)
            {
                return StatusChequeEmitido.Anulado;
                throw;
            }
        }

        public int SetNewRecord(string numeroCheque, DateTime fechaEmision, DateTime fechaAcreditacion,
            decimal importeCheque, string chequeBanco, int numeroOP, int idProveedor, bool isEcheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int id = 1;
                var r = db.T0159_CHEQUES_EMITIDOS.OrderByDescending(c => c.IDRecord).FirstOrDefault();
                if (r != null)
                    id = r.IDRecord + 1;
                var t = new T0159_CHEQUES_EMITIDOS()
                {
                    IDRecord = id,
                    NumeroCheque = numeroCheque,
                    FechaAcreditacion = fechaAcreditacion,
                    Proveedor = idProveedor,
                    ECheque = isEcheque,
                    BancoChequeShort = chequeBanco,
                    FechaEmision = fechaEmision,
                    ImporteCheque = importeCheque,
                    OrdenPagoNumero = numeroOP,
                    PendienteAcreditacion = true,
                    LogFechaEmison = DateTime.Now,
                    LogEmisor = GlobalApp.AppUsername,
                    FechaAcreditacionReal = null,
                    Status = StatusChequeEmitido.Pendiente.ToString()
                };
                db.T0159_CHEQUES_EMITIDOS.Add(t);
                if (db.SaveChanges() == 1)
                    return id;
                return -1;
            }
        }

        public void SetChequeAcreditado(int idRecord, DateTime fechaAcreditacionReal)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0159_CHEQUES_EMITIDOS.SingleOrDefault(c => c.IDRecord == idRecord);
                if (r == null)
                    return;
                r.FechaAcreditacionReal = fechaAcreditacionReal;
                r.Status = StatusChequeEmitido.Acreditado.ToString();
                r.PendienteAcreditacion = false;
                db.SaveChanges();
            }
        }

        public void SetChequeAnulado(int idRecord)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0159_CHEQUES_EMITIDOS.SingleOrDefault(c => c.IDRecord == idRecord);
                if (r == null)
                    return;
                r.FechaAcreditacionReal = null;
                r.Status = StatusChequeEmitido.Anulado.ToString();
                r.PendienteAcreditacion = false;
                db.SaveChanges();
            }
        }

        public void SetChequReversaAcreditacion(int idRecord)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0159_CHEQUES_EMITIDOS.SingleOrDefault(c => c.IDRecord == idRecord);
                if (r == null)
                    return;
                r.FechaAcreditacionReal = null;
                r.Status = StatusChequeEmitido.Pendiente.ToString();
                r.PendienteAcreditacion = true;
                db.SaveChanges();
            }
        }

        public void UpdateChequeNumero(int idRecord, string numeroCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0159_CHEQUES_EMITIDOS.SingleOrDefault(c => c.IDRecord == idRecord);
                if (r == null)
                    return;
                r.NumeroCheque = numeroCheque;
                db.SaveChanges();
            }
        }

        public List<T0159_CHEQUES_EMITIDOS> GetListaChequesEmitidos(bool soloPendienteAcreditacion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloPendienteAcreditacion)
                    return db.T0159_CHEQUES_EMITIDOS.Where(c => c.PendienteAcreditacion)
                        .OrderByDescending(c => c.IDRecord).ToList();
                return db.T0159_CHEQUES_EMITIDOS.OrderByDescending(c => c.IDRecord).ToList();
            }
        }

        public T0159_CHEQUES_EMITIDOS GetChequeEmitido(int idRecord)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0159_CHEQUES_EMITIDOS.SingleOrDefault(c => c.IDRecord == idRecord);
            }
        }

        public void ActualizaVencidoYProximo(int diasProximos = 5)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                DateTime hoy = DateTime.Today;
                DateTime proximo = DateTime.Today.AddDays(diasProximos);
                DateTime vencidoNoCobrados = DateTime.Today.AddMonths(-2);
                var lista = db.T0159_CHEQUES_EMITIDOS
                    .Where(c => c.PendienteAcreditacion && c.FechaAcreditacion <= proximo)
                    .OrderByDescending(c => c.FechaAcreditacion).ToList();

                foreach (var i in lista)
                {
                    if (i.FechaAcreditacion < vencidoNoCobrados)
                    {
                        i.Status = GestionChequesEmitidos.StatusChequeEmitido.NoAcred.ToString();
                    }
                    else
                    {
                        if (i.FechaAcreditacion > hoy)
                        {
                            i.Status = GestionChequesEmitidos.StatusChequeEmitido.Proximo.ToString();
                        }
                        else
                        {
                            i.Status = GestionChequesEmitidos.StatusChequeEmitido.Vencido.ToString();
                        }
                    }
                }

                db.SaveChanges();
            }
        }

    }
}
