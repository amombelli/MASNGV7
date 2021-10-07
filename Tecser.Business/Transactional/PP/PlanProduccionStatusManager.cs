using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.PP
{
    public class PlanProduccionStatusManager
    {
        private readonly List<string> _statusList = new List<string>();

        public enum StatusOf
        {
            Pendiente,
            Formulada,
            Planeado,
            Proceso,
            Cerrada,
            Cancelada,
            StandBy,
            Error,
            Finalizada,
        };

        public static StatusOf MapStatusOfFromText2(string statusOf)
        {
            if (statusOf == "En Proceso")
                statusOf = "Proceso";

            if (string.IsNullOrEmpty(statusOf))
                statusOf = "Error";
            try
            {
                return (StatusOf)Enum.Parse(typeof(StatusOf), statusOf, true);
            }
            catch (Exception)
            {
                return StatusOf.Error;
                throw;
            }
        }

        /// <summary>
        /// Set Status >Formulada - Asigna #Formula --Agrega formula a T0072
        /// numeroFormula tiene que ser >0
        /// </summary>
        public static bool SetStatusFormulada(int idOF, int numeroFormula, bool asignacionAutomaticaLote)
        {
            if (numeroFormula <= 0)
                return false;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idOF);
                if (data == null)
                    return false;

                if (data.KG_FABRICAR <= 0)
                    return false;

                data.STATUS = StatusOf.Formulada.ToString();
                data.Formula = numeroFormula;
                db.SaveChanges();

                var oMng = new OrdenFabricacionBOMManager();
                oMng.ManageFormulaOF(idOF, numeroFormula, true);
                //Add formulta temp a 0072 sin calcular la cantidad batch
                oMng.CalculaBatchSize(idOF, data.KG_FABRICAR, asignacionAutomaticaLote);
                //Completa en T0072 la cantidad del batch y asigna lote automatico
                oMng.ManageFormulaOfprintOri(idOF, 1);
                PFLog.AddLog(idOF, data.STATUS, null);
                return true;
            }
        }

        public static bool SetStatusPendiente(int idOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idOF);
                if (data == null)
                    return false;

                data.STATUS = StatusOf.Pendiente.ToString();
                data.Formula = 0;
                db.SaveChanges();

                var oMng = new OrdenFabricacionBOMManager();
                oMng.ManageFormulaOF(idOF, 0, true, true);
                oMng.ManageFormulaOfprintOri(idOF, 1);
                PFLog.AddLog(idOF, data.STATUS, null);
                return true;
            }
        }

        public static void SetStatusStandBy(int idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                if (data == null)
                    return;

                data.STATUS = StatusOf.StandBy.ToString();
                PFLog.AddLog(idPlan, data.STATUS, null);
                db.SaveChanges();
            }
        }

        public static void SetStatusEnProceso(int idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                if (data == null)
                    return;

                data.STATUS = StatusOf.Proceso.ToString();
                PFLog.AddLog(idPlan, data.STATUS, null);
                db.SaveChanges();
            }
        }

        public static void SetStatusCerrado(int idPlan, int numeroBatchesFinal)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var pf = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                pf.STATUS = StatusOf.Cerrada.ToString();
                pf.LogUserIProd = Environment.UserName;
                pf.LogDateIProd = DateTime.Now;
                pf.CantidadBatches = numeroBatchesFinal;
                PFLog.AddLog(idPlan, pf.STATUS, null);
                db.SaveChanges();
            }
        }

        public static void SetStatusError(int idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var pf = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                pf.STATUS = StatusOf.Error.ToString();
                PFLog.AddLog(idPlan, pf.STATUS, null);
                db.SaveChanges();
            }
        }

        public static void SetStatusFinalizada(int idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var pf = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                pf.STATUS = StatusOf.Finalizada.ToString();
                PFLog.AddLog(idPlan, pf.STATUS, null);
                db.SaveChanges();
            }
        }

        public static void SetStatusCancel(int idPlan, string motivoCancel)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var pf = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                pf.STATUS = StatusOf.Cancelada.ToString();
                pf.CanceledReason = motivoCancel;
                pf.CanceledUser = Environment.UserName;
                db.SaveChanges();
                PFLog.AddLog(idPlan, pf.STATUS, motivoCancel);
            }
        }



        public static bool PlanearOrdenFabricacion(int idPlan, DateTime fechaPlan, int recursoProduccion,
            string operario,
            string comentarioOF, string containerId, int cantidadEnvase)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                if (data != null)
                {
                    data.FPLAN = fechaPlan;
                    data.RECURSO = recursoProduccion;
                    data.Operario = operario;
                    data.ObsPlaneacion = comentarioOF;
                    data.STATUS = StatusOf.Planeado.ToString();
                    data.Env01 = containerId;
                    data.CantEnv01 = cantidadEnvase;
                }
                PFLog.AddLog(idPlan, data.STATUS, null);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public List<string> CompletaStatusList(bool[] ckstatus)
        {
            _statusList.Clear();
            for (int i = 0; i < ckstatus.Length; i++)
            {
                if (ckstatus[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            _statusList.Add("Pendiente");
                            break;
                        case 2:
                            _statusList.Add("Formulada");
                            _statusList.Add("FORMULADO");
                            break;
                        case 3:
                            _statusList.Add("PLANEADO");
                            break;
                        case 4:
                            _statusList.Add("PROCESO");
                            _statusList.Add("EN PROCESO");
                            break;
                        case 5:
                            _statusList.Add("CERRADA");
                            break;
                        case 6:
                            _statusList.Add("CANCELADA");
                            break;
                        case 7:
                            _statusList.Add("STANDBY");
                            break;
                        case 8:
                            _statusList.Add("ERROR");
                            break;
                        case 9:
                            _statusList.Add("FINALIZADA");
                            break;
                        default:
                            _statusList.Add("");
                            break;
                    }
                }

            }

            return _statusList;
        }

        public StatusOf GetStatusOF(int idOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idOF);
                return MapStatusOfFromText2(data.STATUS);

            }
        }
    }
}




