using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.Transactional.PP
{
    public class PlanProduccionManager
    {
        public enum MotivoFabricacion
        {
            Stock,
            OrdenVenta,
            Muestra
        }

        public void SetKgFabricarNew(int idOF, decimal nuevoKg, string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idOF);
                data.KG_FABRICAR = nuevoKg;
                data.ObsPlaneacion = comentario;
                db.SaveChanges();
            }
        }

        public void AsignaLoteAutomaticoT0072(int idOF)
        {
            new StockBatchManagerOF().ReservaLoteOrdenFabricacionCompleta(idOF);
        }

        public T0070_PLANPRODUCCION GetPFLine(int idOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idOF);
            }
        }

        public void SetKgRecalculo(int idOF, decimal KgRecalculo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idOF);
                data.CalculoMP = KgRecalculo;
                db.SaveChanges();
            }
        }



        /// <summary>
        /// 2020.08.02 - Se agrega funcionalidad de Aprobacion de OF para Fabricar
        /// </summary>
        public int AddPlanProduccion(string primario, string etiquetarComo, decimal kg, int numeroOv,
            DateTime fechaCompromiso, string observacionPlan, string plantaFabricacion,
            MotivoFabricacion motivoFabricaicon, string descripcionCliente, bool urgente = false, bool ofManual = false, bool autorizaFabricacion = false)
        {
            var x = new T0070_PLANPRODUCCION()
            {
                CLIENTE = descripcionCliente,
                IDPLAN = GetNextIdPlan(),
                IDPLAN_S = "1",
                MATERIAL = primario,
                MATETIQUETA = etiquetarComo,
                KG_FABRICAR = kg,
                KG_FABRICAR_O = kg,
                STATUS = PP.PlanProduccionStatusManager.StatusOf.Pendiente.ToString(),
                FPLAN = null,
                ObsPlan = observacionPlan,
                PLTN = plantaFabricacion,
                TDOC = "OF",
                CalculoMP = 0,
                CantidadBatches = 1,
                NumLote = GetNextIdPlan().ToString(),
                KG_Fabricados = 0,
                PRN = false,
                LogRecordInDate = DateTime.Now, //new
                LogRecordInUser = GlobalApp.AppUsername //new
            };


            if (urgente)
                x.ObsPlan = observacionPlan + "*URGENTE*";

            x.FLAG = ofManual ? @"Manual" : @"Auto";

            switch (motivoFabricaicon)
            {
                case MotivoFabricacion.Stock:
                    x.PLANPARA = ofManual ? "STK-M" : "STOCK";
                    break;
                case MotivoFabricacion.OrdenVenta:
                    x.PLANPARA = ofManual ? "OV-M" : "OV";
                    x.OV = numeroOv;
                    x.FCOMPROMISO = fechaCompromiso;
                    break;
                case MotivoFabricacion.Muestra:
                    x.PLANPARA = @"Sample";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(motivoFabricaicon), motivoFabricaicon, null);
            }
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                db.T0070_PLANPRODUCCION.Add(x);
                if (db.SaveChanges() > 0)
                {
                    PFLog.AddLog(x.IDPLAN, x.STATUS, $"La OF#{x.IDPLAN} ha ingresado al Plan");
                    if (autorizaFabricacion)
                        new AprobacionPlanificar().AprobarOF(x.IDPLAN, GlobalApp.Tcode);
                    return x.IDPLAN;
                }
                else
                {
                    return 0;
                }
            }
        }

        private static int GetNextIdPlan()
        {
            return new TecserData(GlobalApp.CnnApp).T0070_PLANPRODUCCION.Max(c => c.IDPLAN) + 1;
        }

        public void FixKgOriginales(int idPlan, decimal kgFabricar)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                if (data.KG_FABRICAR_O == null || data.KG_FABRICAR_O == 0)
                {
                    data.KG_FABRICAR_O = data.KG_FABRICAR;
                }

                db.SaveChanges();
            }
        }

        public void UpdateComentarioPF(int idPlan, string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                data.ObsPlan = comentario;
                db.SaveChanges();
            }
        }

        public void UpdateComentarioImpresion(int idPlan, string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                data.ObsPlaneacion = comentario;
                db.SaveChanges();
            }
        }

        public List<T0070_PLANPRODUCCION> GetListPFCompleta(int top = 100)
        {
            return new Repository<T0070_PLANPRODUCCION>(new TecserData(GlobalApp.CnnApp)).GetAll().Take(top).ToList();
        }

        //Pendiente,
        //Formulada,
        //Planeada,
        //Proceso,
        //Cerrada,
        //Cancelado,
        //StandBy,
        //Error,
        //Finalizada

        public void SetBatchSizeData(int idPlan, decimal kgFabricar, int cantidadBatches)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idPlan);
                data.KG_FABRICAR = kgFabricar;
                data.CantidadBatches = cantidadBatches;
                db.SaveChanges();
            }
        }

        public decimal GetKgProducidosDesdeT0040(int idPlan, bool soloTemporal = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                decimal? result;
                if (soloTemporal)
                {
                    result =
                        db.T0040_MAT_MOVIMIENTOS.Where(
                            c =>
                                c.TIPO_DOCUMENTO == "OF" && c.DOCUMENTO == idPlan.ToString() &&
                                (c.TIPOMOVIMIENTO == 503 || c.TIPOMOVIMIENTO == 504)).Sum(c => c.CANTIDAD);
                }
                else
                {
                    result =
                        db.T0040_MAT_MOVIMIENTOS.Where(
                                c =>
                                    c.TIPO_DOCUMENTO == "OF" && c.DOCUMENTO == idPlan.ToString() &&
                                    (c.TIPOMOVIMIENTO == 1 || c.TIPOMOVIMIENTO == 2 || c.TIPOMOVIMIENTO == 503 ||
                                     c.TIPOMOVIMIENTO == 504 || c.TIPOMOVIMIENTO == 508 || c.TIPOMOVIMIENTO == 509))
                            .Sum(c => c.CANTIDAD);
                }

                return result == null ? 0 : Convert.ToDecimal(result);
            }
        }

        /// <summary>
        /// Listado de movimientos de ingresos de materiales (Temporales + Definitivos + Reversiones + Purga por orden fabricacion)
        /// </summary>
        public List<T0040_MAT_MOVIMIENTOS> GetListMovimientosIngresoProduccion(int idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result =
                    db.T0040_MAT_MOVIMIENTOS.Where(
                        c =>
                            c.TIPO_DOCUMENTO == "OF" && c.DOCUMENTO == idPlan.ToString() &&
                            (c.TIPOMOVIMIENTO == 1 || c.TIPOMOVIMIENTO == 2 || c.TIPOMOVIMIENTO == 503 ||
                             c.TIPOMOVIMIENTO == 504 || c.TIPOMOVIMIENTO == 508 || c.TIPOMOVIMIENTO == 509)).ToList();

                return result;
            }
        }

        public List<T0040_MAT_MOVIMIENTOS> GetListMovimientosMateriasPrimasConsumidasProduccion(int idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result =
                    db.T0040_MAT_MOVIMIENTOS.Where(
                            c => c.TIPO_DOCUMENTO == "OF" && c.DOCUMENTO == idPlan.ToString() &&
                                 (c.TIPOMOVIMIENTO == 10))
                        .ToList();

                return result;
            }
        }


        //Esta funcion fue modificada para que ya no vaya acumulando los KG Cargados sino que recalcule
        //all nuevamente y actualice con el valor correcto 25.05.2019
        public void SetNewKgTemporal(int idplan, decimal kgIngresados)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idplan);
                if (result != null)
                {
                    result.KG_Fabricados = kgIngresados;
                    //if (result.KG_Fabricados == null)
                    //    result.KG_Fabricados = 0;
                    //result.KG_Fabricados += kgIngresados;
                    result.STATUS = PlanProduccionStatusManager.StatusOf.Proceso.ToString();
                    db.SaveChanges();
                }
            }
        }


        public DateTime? GetUltimaFabricacion(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var m = db.T0070_PLANPRODUCCION
                    .Where(c => c.MATERIAL == material &&
                                c.STATUS == PlanProduccionStatusManager.StatusOf.Cerrada.ToString())
                    .OrderByDescending(c => c.LogDateIProd).ToList();
                if (!m.Any())
                    return null;
                return m[0].LogDateIProd;

            }
        }
    }
}