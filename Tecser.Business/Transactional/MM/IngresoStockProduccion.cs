using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class IngresoStockProduccion
    {





        /// <summary>
        /// Carga en T0030 el stock temporal ingresado - y registra en T0040 + T0042
        /// Pone OF en estado En Proceso.
        /// Actualiza KG Ingresados
        /// </summary>
        public int IngresoStockProductoFabricado(int idOF, DateTime fechaIngreso, decimal kg, string numeroLote, string sloc,
            int idRecursoProduccion, string operario, string estadoLote = "Liberado", string tcode = "ES",
            string comentario = null, DateTime? horaInicio = null, DateTime? horaFin = null, int cantidadStops = 0,
            int minutosStop = 0, int numeroPasadas = 1, bool limpiezaCabezal = false, bool limpiezaCompleta = false,
            MmLog.TipoMovimiento tipoMovimiento = MmLog.TipoMovimiento.IngresoStockProduccionTemporal)
        {
            var pf = new PlanProduccionManager();
            var dataOF = PlanProduccionListManager.GetOFData(idOF);
            var estadolote = StockStatusManager.MapStatusFromText(estadoLote);
            var id40 = new StockManager().AddNewStock_withLogT40(dataOF.MATERIAL, numeroLote, kg, estadolote, sloc,
                fechaIngreso, tipoMovimiento, idOF.ToString(), tcode, null,
                "OF" + idOF.ToString(), idRecursoProduccion, comentarioMovimiento: comentario);

            new MmLog().LogMovimientoDetalladoT42(id40, operario, horaInicio, horaFin, minutosStop, cantidadStops,
                numeroPasadas, limpiezaCabezal, limpiezaCompleta, comentario);

            var kgTotalesOF = new PlanProduccionManager().GetKgProducidosDesdeT0040(idOF);
            pf.SetNewKgTemporal(idOF, kgTotalesOF); //Ingreso KG Temporales en PF


            return id40;
        }


        public bool ChequeaStockReservadoIsOK(int idplan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0072_FORMULA_TEMP.Where(c => c.OF == idplan && string.IsNullOrEmpty(c.BatchNumber) == false).ToList();

                foreach (var item in d)
                {
                    var stk = db.T0030_STOCK.Where(c => c.ReservaOF == idplan && c.Material.Equals(item.Primario) &&
                                c.Batch.Equals(item.BatchNumber) && c.Stock == item.CantidadKGReal).ToList();

                    if (stk.Count == 0)
                        //stk
                        return true;
                    return false;
                }
            }


            return true;
        }

        /// <summary>
        /// Para un material determinado identifica si se puede asignar un lote automatico. Si se puede retorna el idstock >0
        /// Si no retorna un numero menor a 0
        /// </summary>
        /// <param name="idplan"></param>
        /// <param name="material"></param>
        /// <param name="kgRequeridos"></param>
        public int IdentificaUnicoLoteAutomaticoOF(int idplan, string material, decimal kgRequeridos)
        {
            new StockManager().OptimizaStockLiberado(material); //Optimiza Stock
                                                                //var posibleStock = new StockList().GetAllByMaterial_DisponibleProduccion(material).Where(c => c.Stock >= kgRequeridos).ToList();
            var posibleStock =
                new StockList().GetAllByMaterial_DisponibleProduccion(material).Where(c => c.Stock >= 0).ToList(); //MODIFICADO 2017.11.26
#pragma warning disable CS0168 // The variable 'accion' is declared but never used
            string accion;
#pragma warning restore CS0168 // The variable 'accion' is declared but never used

            if (posibleStock.Count == 0)
            {
                //Hay que elegir los stock en forma manual - ninguna linea cumple con stock mayor al requerido
                return 0;
            }
            else if (posibleStock.Count == 1)
            {
                //Seleccion automatica - retorna idstock!
                return posibleStock[0].IDStock;
            }
            else
            {
                //Hay muchas lineas/lotes que cumplen con lo requerido - Hay que elegir stock en forma manual
                return -1;
            }



        }


        /// <summary>
        /// Todo: la mayoria de los campos de t0042 estan allow null - 
        /// </summary>
        /// <returns></returns>
        public int SetDetalleIngresoProduccion(int idmov40, T0042_PRODUCCION_DET data, string comentarioIngresoGeneralT40)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var det = db.T0042_PRODUCCION_DET.SingleOrDefault(c => c.ID40 == idmov40);
                if (det == null)
                {

                    return new MmLog().LogMovimientoDetalladoT42(idmov40, data.OPERADOR, data.HORAI.Value, data.HORAF.Value, 0,
                        data.NUMSTOPS.Value, data.NUM_PASADAS.Value, data.LIM_CABEZAL.Value, data.LIM_COMPLETA.Value,
                        data.STOP_OBS);

                }
                else
                {
                    //Existe la info modifica los valores permitidos
                    det.HORAF = data.HORAF;
                    det.HORAI = data.HORAI;
                    det.LIM_CABEZAL = data.LIM_CABEZAL;
                    det.LIM_COMPLETA = data.LIM_COMPLETA;
                    det.NUMSTOPS = data.NUMSTOPS;
                    det.NUM_PASADAS = data.NUM_PASADAS;
                    det.OPERADOR = data.OPERADOR;
                    det.RECURSO_PROD = data.RECURSO_PROD;
                    det.STOP_OBS = data.STOP_OBS;
                    det.FECHA = data.FECHA;
                    det.TIEMPO_STOP = data.TIEMPO_STOP;
                    var t40 = db.T0040_MAT_MOVIMIENTOS.SingleOrDefault(c => c.IDMOVIMIENTO == idmov40);
                    t40.FECHAMOV = data.FECHA;
                    t40.COMENTARIO = comentarioIngresoGeneralT40;
                    t40.RECURSO = data.RECURSO_PROD;
                    db.SaveChanges();
                    return det.IDMOV;
                }
            }
        }

        public T0042_PRODUCCION_DET GetDetalleIngresoProduccion(int idmov40)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0042_PRODUCCION_DET.SingleOrDefault(c => c.ID40 == idmov40);
            }

        }
        public bool ReversionIngresoStock(int id40, int numeroOF)
        {
            //Loguea la reversion en T0040
            if (new MmLog().ReversionLogIngresoStock(id40))
            {
                var kgRevertir = MmLog.GetT40Line(id40).CANTIDAD;
                new PlanProduccionManager().FixKgOriginales(numeroOF,
                    new PlanProduccionManager().GetKgProducidosDesdeT0040(numeroOF));

                return true;
            }
            else
            {
                //El Log dio incorrecto - aborta
                return false;
            }
        }
        public bool ReversionConsumoMateriasPrimas(int numeroOF)
        {
            //Loguea la reversion en T0040
            if (new MmLog().ReversionLogConsumoMateriasPrimas(numeroOF))
            {
                //Se pudo loguear correctamente la reversion
                return true;
            }

            return false;
        }




    }
}

