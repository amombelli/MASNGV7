using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class GestionChequesEmitidos
    {
        public struct StatsChequesEmitidosPeriodo
        {
            public decimal TotEmitidoPeriodo;
            public decimal TotAcreditado;
            public decimal TotNoAcreditado;
            public decimal TotAcreditadoEmisionDiferida;
            public decimal TotAcreditadoEmitidoPeriodo;
        }

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
            decimal importeCheque, string chequeBanco, int numeroOP, int idProveedor, bool isEcheque, int nasEmision,
            string lx)
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
                    Status = StatusChequeEmitido.Pendiente.ToString(),
                    NasEmision = nasEmision,
                    LX = lx,
                    IdRegister = -1
                };
                db.T0159_CHEQUES_EMITIDOS.Add(t);
                if (db.SaveChanges() == 1)
                    return id;
                return -1;
            }
        }

        public static void Update159AfterAcreditacion(int id159, int idRegister, int asientoAcred)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var xcheque = db.T0159_CHEQUES_EMITIDOS.SingleOrDefault(c => c.IDRecord == id159);
                xcheque.IdRegister = idRegister;
                xcheque.NasAcreditacion = asientoAcred;
                db.SaveChanges();
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
        

        /// <summary>
        /// Resumen de importes sobre cheques emitidos en el periodo
        /// </summary>
        public static StatsChequesEmitidosPeriodo AnalisisChequesEmitidosPeriodo(string periodo, string lx)
        {
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            var mes = fechaI.Month;
            var anio = fechaI.Year;
            var resultado = new StatsChequesEmitidosPeriodo
            {
                TotAcreditado = 0,
                TotEmitidoPeriodo = 0,
                TotNoAcreditado = 0,
                TotAcreditadoEmisionDiferida = 0
            };
            
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Listado Cheques Emitidos en Periodo - No-Cancelados
                resultado.TotEmitidoPeriodo = ImporteChequesEmitidosPeriodo(periodo, lx);
                resultado.TotNoAcreditado = ImportePendienteAcreditacionPeriodo(periodo, lx);
                resultado.TotAcreditadoEmisionDiferida = ImporteAcreditadoConEmisionDiferida(periodo, lx);
                resultado.TotAcreditado = ImporteAcreditadoPeriodo(periodo, lx);
                resultado.TotAcreditadoEmitidoPeriodo = resultado.TotAcreditado - resultado.TotAcreditadoEmisionDiferida;
                return resultado;
            }
        }

        public static decimal ImporteAcreditadoPeriodo(string periodo, string lx)
        {
            //Acreditados en el periodo - emitido en cualquier periodo
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            var mes = fechaI.Month;
            var anio = fechaI.Year;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0159_CHEQUES_EMITIDOS.Where(c => c.Status == StatusChequeEmitido.Acreditado.ToString() && (
                    c.FechaAcreditacionReal.Value.Month == mes &&
                    c.FechaAcreditacionReal.Value.Year == anio)).ToList();
                if (!ch.Any()) return 0;
                if (lx == "L1" || lx == "L2")
                {
                    var c1 = ch.Where(c => c.LX == lx).ToList();
                    if (!c1.Any()) 
                        return 0;
                    return c1.Sum(c => c.ImporteCheque);
                }
                else
                {
                    return ch.Sum(c => c.ImporteCheque);
                }
            }
        }
        public static decimal ImporteChequesEmitidosPeriodo(string periodo, string lx)
        {
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            var mes = fechaI.Month;
            var anio = fechaI.Year;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0159_CHEQUES_EMITIDOS.Where(c =>
                    c.FechaEmision.Month == mes && c.FechaEmision.Year == anio &&
                    c.Status != StatusChequeEmitido.Anulado.ToString()).ToList();
                if (!ch.Any()) return 0;
                if (lx == "L1" || lx == "L2")
                {
                    var x = ch.Where(c => c.LX == lx).ToList();
                    if (!x.Any()) return 0;
                    return x.Sum(c => c.ImporteCheque);
                }
                else
                {
                    return ch.Sum(c => c.ImporteCheque);
                }
            }
        }
        public static decimal ImportePendienteAcreditacionPeriodo(string periodo, string lx)
        {
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            var mes = fechaI.Month;
            var anio = fechaI.Year;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                decimal Suma = 0;
                List<T0159_CHEQUES_EMITIDOS> chEmitido;
                List<T0159_CHEQUES_EMITIDOS> chPend;
                List<T0159_CHEQUES_EMITIDOS> chAcredOP;

                if (lx == "L1" || lx == "L2")
                {
                    chEmitido = db.T0159_CHEQUES_EMITIDOS.Where(c =>
                        c.FechaEmision.Month == mes && c.FechaEmision.Year == anio && c.LX == lx &&
                        (c.Status != StatusChequeEmitido.Anulado.ToString())).ToList();
                }
                else
                {
                    chEmitido = db.T0159_CHEQUES_EMITIDOS.Where(c =>
                        c.FechaEmision.Month == mes && c.FechaEmision.Year == anio &&
                        (c.Status != StatusChequeEmitido.Anulado.ToString())).ToList();
                }
                
                chPend = chEmitido.Where(c => c.PendienteAcreditacion).ToList();
                if (chPend.Any()) Suma = chPend.Sum(c => c.ImporteCheque);
                chAcredOP = chEmitido.Where(c =>
                            c.PendienteAcreditacion == false &&
                            ((c.FechaAcreditacionReal.Value.Month != mes) ||
                             (c.FechaAcreditacionReal.Value.Month == mes &&
                              c.FechaAcreditacionReal.Value.Year != anio)))
                        .ToList();

                if (chAcredOP.Any()) Suma += chAcredOP.Sum(c => c.ImporteCheque);
                return Suma;
            }
        }
        public static decimal ImporteAcreditadoConEmisionDiferida(string periodo, string lx)
        {
            DateTime fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            var mes = fechaI.Month;
            var anio = fechaI.Year;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0159_CHEQUES_EMITIDOS.Where(c =>
                    (c.FechaEmision.Month != mes || (c.FechaEmision.Month==mes && c.FechaEmision.Year!=anio)) &&
                    c.Status == StatusChequeEmitido.Acreditado.ToString() && (c.FechaAcreditacionReal.Value.Month== mes && c.FechaAcreditacionReal.Value.Year==anio)).ToList();
                
                if (!ch.Any()) return 0;
                if (lx == "L1")
                {
                    var c1 = ch.Where(c => c.LX == "L1").ToList();
                    if (c1.Any())
                        return c1.Sum(c => c.ImporteCheque);
                    return 0;
                }
                else
                {
                    if (lx == "L2")
                    {
                        var c2 = ch.Where(c => c.LX == "L2").ToList();
                        if (c2.Any())
                            return c2.Sum(c => c.ImporteCheque);
                        return 0;
                    }
                    else
                    {
                        return ch.Sum(c => c.ImporteCheque);
                    }
                }
            }
        }



        //Funciones de FIX
        public void fixDataErrors2()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var a = db.T0159_CHEQUES_EMITIDOS.Where(c => c.LogEmisor.Contains("@") == false).ToList();
                foreach (var i in a)
                {
                    var f = db.XREGISTER.SingleOrDefault(c => c.ST != null && c.CH_ID == i.IDRecord);
                    if (f != null)
                    {
                        i.LogEmisor = i.LogEmisor + "@" + f.IDT.ToString();
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show($@"Revisar {i.IDRecord}");
                    }
                }
            }
        }
        public void fixdataErrorFecha()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0159_CHEQUES_EMITIDOS.Where(c =>
                    c.Status == StatusChequeEmitido.Acreditado.ToString()).ToList();
                foreach (var i in ch)
                {
                    var reg1 = db.XREGISTER.Where(c =>
                        c.Ref == i.OrdenPagoNumero.ToString() && c.Monto_E == i.ImporteCheque).ToList();

                    if (!reg1.Any())
                    {
                        Console.WriteLine("no encontre id- {i.IDRecord}");
                    }
                    else
                    {
                        if (reg1.Count() == 1)
                        {
                            i.LogEmisor = i.LogEmisor + "@" + reg1[0].IDT.ToString();
                            reg1[0].CH_ID = i.IDRecord;
                            reg1[0].CH_BCO = i.BancoChequeShort;
                            reg1[0].ST = "B";
                            reg1[0].CH_FEC = i.FechaAcreditacion;
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(reg1[0].ST))
                            {
                                MessageBox.Show($@"Revisar Manualmente {i.IDRecord}");
                            }

                            //estos los hice yo manualmente.- 
                        }

                        db.SaveChanges();
                    }
                }

            }
        }
        public void Fix00()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0159_CHEQUES_EMITIDOS.Where(c => c.IdRegister > 0).ToList();
                foreach (var i in ch)
                {
                    var reg = db.XREGISTER.SingleOrDefault(c => c.IDT == i.IdRegister);
                    if (i.OrdenPagoNumero.ToString() != reg.Ref || i.ImporteCheque != reg.Monto_E)
                    {
                        MessageBox.Show(@"Atencion nunmero OP no coincide");
                    }
                    else
                    {
                        DateTime fechaRegister = Convert.ToDateTime(reg.Fecha.Value);
                        DateTime fechaAcredita = Convert.ToDateTime(i.FechaAcreditacionReal.Value);

                        if (fechaRegister != fechaAcredita)
                        {
                            MessageBox.Show($"Diferencia fecha. Acred= {fechaAcredita} -- Register = {fechaRegister}");
                        }
                        //reg.Descripcion = $@"Acreditacion Ch. Propio #{i.NumeroCheque}";
                        //reg.ST = "ACR";
                        //reg.CH_BCO = i.BancoChequeShort;
                        //reg.CH_FEC = i.FechaAcreditacion;
                        //reg.CH_ID = i.IDRecord;
                        //i.NasAcreditacion = reg.NAS;
                        //db.SaveChanges();
                    }

                }
            }
        }
        public void Fix001()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0159_CHEQUES_EMITIDOS.Where(c => c.IdRegister > 0).ToList();
                foreach (var i in ch)
                {
                    var reg = db.XREGISTER.SingleOrDefault(c => c.IDT == i.IdRegister);
                    if (i.OrdenPagoNumero.ToString() != reg.Ref || i.ImporteCheque != reg.Monto_E)
                    {
                        MessageBox.Show(@"Atencion nunmero OP no coincide");
                    }
                    else
                    {
                        reg.Descripcion = $@"Acreditacion Ch. Propio #{i.NumeroCheque}";
                        reg.ST = "ACR";
                        reg.CH_BCO = i.BancoChequeShort;
                        reg.CH_FEC = i.FechaAcreditacion;
                        reg.CH_ID = i.IDRecord;
                        i.NasAcreditacion = reg.NAS;
                        db.SaveChanges();
                    }

                }
            }
        }

    }
}
