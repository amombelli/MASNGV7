using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.PP
{


    /// <summary>
    /// Toda la adminsitracion de una formula para una Orden de Fabricacion (maneja T0072 y T0073)
    /// MaterialExtra => material fusion
    /// Modificado => formula modificada
    /// </summary>

    public class OrdenFabricacionBOMManager
    {
        public void UpdateT0072(int numeroOF, List<T0072_FORMULA_TEMP> data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var exist = db.T0072_FORMULA_TEMP.Where(c => c.OF == numeroOF).ToList();
                foreach (var item in exist)
                {
                    db.T0072_FORMULA_TEMP.Remove(item);
                }
                db.SaveChanges();

                var data2 = data.OrderBy(c => c.idItemFormula);
                int i = 1;
                foreach (var item in data2.Where(c => c.idItemFormula < 900).ToList())
                {
                    item.idItemFormula = i;
                    i++;
                }

                db.T0072_FORMULA_TEMP.AddRange(data2);
                db.SaveChanges();
            }
        }
        
        public void RecalculaPorcentajeRealUtilizado(int numeroOF, decimal kgMPFinal)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0072_FORMULA_TEMP.Where(c => c.OF == numeroOF).ToList();
                foreach (var item in data)
                {
                    item.CantidadPorReal = Math.Round(item.CantidadKGReal.Value / kgMPFinal, 4);
                    item.LogCierreES = DateTime.Now;
                }
                db.SaveChanges();
            }
        }

        
        /// <summary>
        /// 20170716 Agrega item para reproceso / material fusion
        /// </summary>
        public int AddItemFusionFormula(int idOrdenFabricacion, int idstock)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stock = StockManager.GetStockLine(idstock);
                var data = new T0072_FORMULA_TEMP();
                data.MaterialExtra = true;  //material fusion
                data.Modificado = false;    //formula modificada (cantidad o materiales)
                data.OF = idOrdenFabricacion;
                data.NForm = 0;
                data.Primario = stock.Material;
                data.BatchNumber = stock.Batch;
                data.CantidadBase = 0;
                data.CantidadKG = stock.Stock;
                data.CantidadKGReal = stock.Stock;
                data.CantidadPor = 0;
                data.CantidadPorReal = 0;
                data.idItemFormula = GetIdItemFormula(idOrdenFabricacion);
                db.T0072_FORMULA_TEMP.Add(data);
                return db.SaveChanges() > 0 ? data.OF : 0;
            }
        }

        public int AddItemModificarFormula(int idOrdenFabricacion, string primario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var data = new T0072_FORMULA_TEMP();
                data.MaterialExtra = false;  //material fusion
                data.Modificado = true;    //formula modificada (cantidad o materiales)
                data.OF = idOrdenFabricacion;
                data.NForm = 0;
                data.Primario = primario;
                data.BatchNumber = null;
                data.CantidadBase = 0;
                data.CantidadKG = 0;
                data.CantidadKGReal = 0;
                data.CantidadPor = 0;
                data.CantidadPorReal = 0;
                data.idItemFormula = GetIdItemFormula(idOrdenFabricacion);
                db.T0072_FORMULA_TEMP.Add(data);
                return db.SaveChanges() > 0 ? data.OF : 0;
            }
        }

        public int AddItemModificarFormula(T0072_FORMULA_TEMP data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                data.idItemFormula = GetIdItemFormula(data.OF);
                db.T0072_FORMULA_TEMP.Add(data);
                return db.SaveChanges() > 0 ? data.OF : 0;
            }
        }

        public void GetStockFormulaTemp(int idOrdenFabricacion, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fx = db.T0072_FORMULA_TEMP.Where(c => c.OF == idOrdenFabricacion).ToList();
                foreach (var f in fx)
                {
                    f.STKLiberado = new StockList().GetKgStockDisponibleProduccion(f.Primario, planta);
                    f.STKTotal = StockList.GetKgStockTotalByMaterial(f.Primario, planta);
                }
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Agrega formula a T0072 + Calcula StkTotal y Liberado
        /// </summary>
        private void AddFormulaTemporal(int idOrdenFabricacion, int idFormula, bool calculaStockDisponible = false)
        {
            var planta = PlanProduccionListManager.GetOFData(idOrdenFabricacion).PLTN;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var iditem = GetIdItemFormula(idOrdenFabricacion);
                var dataFormula = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();
                {
                    foreach (var item in dataFormula)
                    {
                        var x = new T0072_FORMULA_TEMP
                        {
                            MaterialExtra = false,  //Por default false
                            Modificado = false,     //Por default false
                            OF = idOrdenFabricacion,
                            NForm = idFormula,
                            Primario = item.ITEM,
                            CantidadPor = item.CANTIDAD_PORC,
                            CantidadBase = item.CANTIDAD,
                            CantidadKGReal = 0,
                            CantidadKG = 0,
                            BatchNumber = null,
                            idItemFormula = iditem
                        };
                        if (calculaStockDisponible)
                        {
                            x.STKTotal = StockList.GetKgStockTotalByMaterial(item.ITEM, planta);
                            x.STKLiberado = new StockList().GetKgStockDisponibleProduccion(item.ITEM, planta);
                        }
                        db.T0072_FORMULA_TEMP.Add(x);
                        iditem++;
                    }
                    db.SaveChanges();
                }
            }
        }


        public bool RemoveMaterialModificadoOAgregadoDeOF(int idOrdenFabricacion, int iditem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t72 = db.T0072_FORMULA_TEMP.SingleOrDefault(c => c.OF == idOrdenFabricacion && c.idItemFormula == iditem);
                if (t72 == null)
                    return false;

                var t73 = db.T0073_FORMULA_PRINT.SingleOrDefault(c => c.OF == idOrdenFabricacion && c.idItemFormula == iditem);
                if (t73 == null)
                    return false;

                if (t72.idStockReservado != null)
                {
                    new StockBatchManagerOF().LiberacionLoteOrdenFabricacionIndividual(idOrdenFabricacion,
                        (int)t72.idItemFormula);
                }

                db.T0072_FORMULA_TEMP.Remove(t72);
                db.T0073_FORMULA_PRINT.Remove(t73);

                db.SaveChanges();
                return true;
            }
        }

        //Cuando agrego un material (fusion) lo ponemos en columna materialextra
        public bool FormulaTieneItemModificadoOAgregado(int idOrdenFabricacion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0072_FORMULA_TEMP.Where(
                        c => c.OF == idOrdenFabricacion && (c.MaterialExtra == true || c.Modificado == true)).ToList();
                if (data.Count > 0)
                    return true;
                return false;
            }
        }



        public static int GetIdItemFormula(int idplan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0072_FORMULA_TEMP.Count(c => c.OF == idplan) + 1;
            }
        }

        public static void GetIdItemFormulaFix(int idplan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0072_FORMULA_TEMP.Where(c => c.OF == idplan).ToList();
                int i = 1;
                foreach (var item in x)
                {
                    item.idItemFormula = i;
                    i++;
                }
                db.SaveChanges();
            }
        }



        /// <summary>
        /// Remueve formula Temporal T0072 + T0073 (print)
        /// +Libera all el stock si estaba reservado.
        /// </summary>
        private void RemoveFormulaTemporal(int numeroOF, int idFormula, bool removeMaterialFusion = false, bool removeMaterialAgregado = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (removeMaterialFusion)
                {
                    var data1 =
                        db.T0072_FORMULA_TEMP.Where(c => c.OF == numeroOF && c.MaterialExtra == true)
                            .ToList();

                    foreach (var item in data1)
                    {
                        if (item.idStockReservado > 0)
                            new StockBatchManagerOF().LiberacionLoteOrdenFabricacionIndividual(numeroOF,
                                item.idItemFormula);

                        db.T0072_FORMULA_TEMP.Remove(item);
                    }
                }

                if (removeMaterialAgregado)
                {
                    var data2 =
                        db.T0072_FORMULA_TEMP.Where(c => c.OF == numeroOF && c.Modificado == true)
                            .ToList();

                    foreach (var item in data2)
                    {
                        if (item.idStockReservado > 0)
                            new StockBatchManagerOF().LiberacionLoteOrdenFabricacionIndividual(numeroOF,
                                item.idItemFormula);

                        db.T0072_FORMULA_TEMP.Remove(item);
                    }
                }

                var data =
                    db.T0072_FORMULA_TEMP.Where(
                        c => c.OF == numeroOF && (c.MaterialExtra == false || c.Modificado == false)).ToList();

                foreach (var item in data)
                {
                    if (item.idStockReservado > 0)
                        new StockBatchManagerOF().LiberacionLoteOrdenFabricacionIndividual(numeroOF,
                            item.idItemFormula);

                    db.T0072_FORMULA_TEMP.Remove(item);
                }

                db.SaveChanges();
            }
        }


        /// <summary>
        /// Remueve formula y la vuelve a ingresar. Si la Formula# ==0 Solo Remueve
        /// </summary>
        public void ManageFormulaOF(int idOrdenFabricacion, int idFormula, bool removeMaterialReproceso = false, bool removeMaterialAgregado = false, bool asignacionAutomaticaLote = false)
        {
            //No asigno el lote en forma automatica porque todavia no esta completa la cantidad a utilizar.
            RemoveFormulaTemporal(idOrdenFabricacion, idFormula, removeMaterialReproceso, removeMaterialAgregado);
            if (idFormula == 0)
                return;

            AddFormulaTemporal(idOrdenFabricacion, idFormula);

            if (asignacionAutomaticaLote == true)
                new StockBatchManagerOF().ReservaLoteOrdenFabricacionCompleta(idOrdenFabricacion);
        }


        //Funcion para generacion de formula a Imprimir
        public void ManageFormulaOfprint(int idOrdenFabricacion, List<T0072_FORMULA_TEMP> origenDatos, int numeroBatches, bool agrupoarMP = false)
        {
            var gramos = new ConfigurationKeyManager("GRMAX").GetValueData();
            if (numeroBatches >= 1)
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    //Remueve datos existentes
                    var dataPrint = db.T0073_FORMULA_PRINT.Where(c => c.OF == idOrdenFabricacion).ToList();
                    db.T0073_FORMULA_PRINT.RemoveRange(dataPrint);
                    db.SaveChanges();
                    //

                    var resultado = new List<T0072_FORMULA_TEMP>();
                    if (agrupoarMP)
                    {
                        var source = origenDatos.Where(c => c.idItemFormula < 900 && c.CantidadKG > 0).ToList();
                        var consolidado = from data in source
                                          group data by
                                              new
                                              {
                                                  data.Primario,
                                                  data.BatchNumber,
                                              }
                            into grp
                                          select new T0072_FORMULA_TEMP()
                                          {
                                              Primario = grp.Key.Primario,
                                              BatchNumber = grp.Key.BatchNumber,
                                              CantidadKGReal = grp.Sum(c => c.CantidadKGReal),
                                              CantidadBase = grp.Sum(c => c.CantidadKGReal),
                                              CantidadPor = grp.Sum(c => c.CantidadKGReal),
                                              CantidadKG = grp.Sum(c => c.CantidadKGReal),
                                              idItemFormula = 0
                                          };
                        resultado = consolidado.ToList();
                    }
                    else
                    {
                        resultado = origenDatos.Where(c => c.idItemFormula < 900 && c.CantidadKG > 0).ToList();
                    }

                    int i = 1;
                    foreach (var item in resultado)
                    {
                        var iPrint = new T0073_FORMULA_PRINT();
                        iPrint.OF = idOrdenFabricacion;
                        iPrint.NForm = item.NForm;
                        iPrint.Primario = item.Primario;
                        iPrint.CantidadBase = item.CantidadBase;
                        iPrint.CantidadPor = item.CantidadPor;
                        iPrint.CantidadKG = Decimal.Round((item.CantidadKG.Value / numeroBatches), 4);
                        iPrint.CantidadGR = Decimal.Round((item.CantidadKG.Value * 1000 / numeroBatches), 0);

                        if (iPrint.CantidadGR < Convert.ToDecimal(gramos))
                        {
                            iPrint.DISP_VALUE = 0;
                            iPrint.DISP_UNIT = "GR";
                            iPrint.DISP_VALUE2 = Decimal.Round((decimal)iPrint.CantidadGR, 0).ToString("D0");
                            iPrint.DISP_UNIT2 = "GR";
                        }
                        else
                        {
                            iPrint.DISP_VALUE = Decimal.Round((decimal)iPrint.CantidadKG, 2);
                            iPrint.DISP_UNIT = "KG";
                            iPrint.DISP_VALUE2 = null;
                            iPrint.DISP_UNIT2 = null;
                        }

                        iPrint.Modificado = item.Modificado;
                        iPrint.MaterialExtra = item.MaterialExtra;
                        iPrint.BatchNumber = item.BatchNumber;
                        iPrint.CantBatches = numeroBatches;
                        iPrint.idItemFormula = i;
                        iPrint.idStockReservado = item.idStockReservado;
                        db.T0073_FORMULA_PRINT.Add(iPrint);
                        i++;
                    }
                    db.SaveChanges();
                }
            }
        }

        public void ManageFormulaOfprintOri(int idOrdenFabricacion, int numeroBatches, bool agrupoarMP = false)
        {
            var gramos = new ConfigurationKeyManager("GRMAX").GetValueData();
            if (numeroBatches >= 1)
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    //Remueve datos existentes
                    var dataPrint = db.T0073_FORMULA_PRINT.Where(c => c.OF == idOrdenFabricacion).ToList();
                    db.T0073_FORMULA_PRINT.RemoveRange(dataPrint);
                    db.SaveChanges();
                    //
                    var dataGeneral72 = db.T0072_FORMULA_TEMP.Where(c => c.OF == idOrdenFabricacion).ToList();
                    if (dataGeneral72.Count == 0)
                        return;

                    var resultado = new List<T0072_FORMULA_TEMP>();

                    if (agrupoarMP)
                    {
                        var source = db.T0072_FORMULA_TEMP.Where(c => c.OF == idOrdenFabricacion).ToList();
                        var consolidado = from data in source
                                          group data by
                                              new
                                              {
                                                  data.Primario,
                                                  data.BatchNumber,
                                              }
                            into grp
                                          select new T0072_FORMULA_TEMP()
                                          {
                                              Primario = grp.Key.Primario,
                                              BatchNumber = grp.Key.BatchNumber,
                                              CantidadKGReal = grp.Sum(c => c.CantidadKGReal),
                                              CantidadBase = grp.Sum(c => c.CantidadKGReal),
                                              CantidadPor = grp.Sum(c => c.CantidadKGReal),
                                              CantidadKG = grp.Sum(c => c.CantidadKGReal),
                                              idItemFormula = 0
                                          };
                        resultado = consolidado.ToList();
                    }
                    else
                    {
                        resultado = db.T0072_FORMULA_TEMP.Where(c => c.OF == idOrdenFabricacion).ToList();
                    }

                    int i = 1;
                    foreach (var item in resultado)
                    {
                        var iPrint = new T0073_FORMULA_PRINT();
                        iPrint.OF = idOrdenFabricacion;
                        iPrint.NForm = item.NForm;
                        iPrint.Primario = item.Primario;
                        iPrint.CantidadBase = item.CantidadBase;
                        iPrint.CantidadPor = item.CantidadPor;
                        iPrint.CantidadKG = Decimal.Round((item.CantidadKG.Value / numeroBatches), 4);
                        iPrint.CantidadGR = Decimal.Round((item.CantidadKG.Value * 1000 / numeroBatches), 0);

                        if (iPrint.CantidadGR < Convert.ToDecimal(gramos))
                        {
                            iPrint.DISP_VALUE = 0;
                            iPrint.DISP_UNIT = "GR";
                            iPrint.DISP_VALUE2 = Decimal.Round((decimal)iPrint.CantidadGR, 0).ToString("D0");
                            iPrint.DISP_UNIT2 = "GR";
                        }
                        else
                        {
                            iPrint.DISP_VALUE = Decimal.Round((decimal)iPrint.CantidadKG, 2);
                            iPrint.DISP_UNIT = "KG";
                            iPrint.DISP_VALUE2 = null;
                            iPrint.DISP_UNIT2 = null;
                        }
                        iPrint.Modificado = item.Modificado;
                        iPrint.MaterialExtra = item.MaterialExtra;
                        iPrint.BatchNumber = item.BatchNumber;
                        iPrint.CantBatches = numeroBatches;
                        iPrint.idItemFormula = i;
                        iPrint.idStockReservado = item.idStockReservado;
                        db.T0073_FORMULA_PRINT.Add(iPrint);
                        i++;
                    }
                    db.SaveChanges();
                }
            }
        }


        public static List<T0072_FORMULA_TEMP> GetFormulaOrdenFabricacion(int idOrdenFabricacion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0072_FORMULA_TEMP.Where(c => c.OF == idOrdenFabricacion).ToList();
            }
        }

        public List<T0073_FORMULA_PRINT> GetFormulaOrdenFabricacionPrint(int idOrdenFabricacion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0073_FORMULA_PRINT.Where(c => c.OF == idOrdenFabricacion).ToList();
            }
        }


        /// <summary>
        /// Calcula la formula final para fabricar de acuerdo a la cantidad de KG 
        /// Numero de batches por default = 1 -- Graba en T0072
        /// </summary>
        public void CalculaBatchSize(int idOF, decimal totalFabricar, bool asignacionAutomaticaLote)
        {
            decimal total = 0;
            using (var db0 = new TecserData(GlobalApp.CnnApp))
            {
                var rs =
                    db0.T0072_FORMULA_TEMP.Where(c => c.OF == idOF && (c.Modificado == true || c.MaterialExtra == true))
                        .ToList();
                if (rs.Count > 0)
                {
                    //Existe al menos un item modificado manualmente por lo que no lo considera en calculo batch
                    foreach (var item in rs)
                    {
                        total += (decimal)item.CantidadKG;
                    }
                }

                var kgFormulacion = totalFabricar - total;

                rs =
                    db0.T0072_FORMULA_TEMP.Where(
                        c => c.OF == idOF && (c.Modificado == false || c.MaterialExtra == false)).ToList();
                foreach (var item in rs)
                {
                    item.CantidadKG = decimal.Round(item.CantidadPor.Value * kgFormulacion, 4);
                    item.CantidadKGReal = decimal.Round(item.CantidadPor.Value * kgFormulacion, 4);

                    new StockBatchManagerOF().LiberacionLoteOrdenFabricacionIndividual(idOF,
                        item.idItemFormula);
                }

                db0.SaveChanges();


                if (asignacionAutomaticaLote == true)
                {
                    new StockBatchManagerOF().ReservaLoteOrdenFabricacionCompleta(idOF);
                }
            }
        }


        public decimal GetTotalMateriaPrimaAUtilizar(int idOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var kg = db.T0072_FORMULA_TEMP.Where(c => c.OF == idOF).Sum(c => c.CantidadKGReal);
                return (decimal)kg;
            }

        }


        /// <summary>
        /// Update 2019-04-22
        /// Recalcula en forma automatica el tamaño del lote utilizado
        /// Material Containers no se considera ni para el calculo ni para la suma 'B*'
        /// </summary>
        public void RecalculaMateriaPrimaFormula(int idplan, decimal kgRecalculoMP)
        {
            decimal totalReproceso = 0;
            decimal totalConRecalculo = 0;
            decimal totalKgSinRecalculo = 0;
            decimal totalContainers = 0;            //Materiales con 'B'
            decimal totalPorcentajeRecalculo = 0;

            using (var db0 = new TecserData(GlobalApp.CnnApp))
            {
                var listaOFCompleta = db0.T0072_FORMULA_TEMP.Where(c => c.OF == idplan).ToList();
                var listaSinContainers =
                    listaOFCompleta.Where(c => c.Primario.ToUpper().StartsWith("B") == false).ToList();

                //Cheque Elementos Fusion
                var repro = listaSinContainers.Where(c => c.Repro && c.Added).ToList();
                if (repro.Count > 0)
                {
                    foreach (var fx in repro)
                    {
                        totalReproceso += (decimal)fx.CantidadKGReal;
                    }
                }

                //Chequeo Elementos SIN RECALCULO
                var sinRecalculo = listaSinContainers.Where(c => c.Recalculo && c.Repro == false).ToList();
                if (sinRecalculo.Count > 0)
                {
                    foreach (var srecx in sinRecalculo)
                    {
                        totalKgSinRecalculo += (decimal)srecx.CantidadKGReal;
                    }
                }

                //Chequeo Elementos Agregados con Recalculo de Formula
                var conRecalculo = listaSinContainers.Where(c => c.Recalculo == false).ToList();
                if (conRecalculo.Count > 0)
                {
                    foreach (var rx in conRecalculo)
                    {
                        totalConRecalculo += (decimal)rx.CantidadKGReal;
                        totalPorcentajeRecalculo += (decimal)rx.CantidadPor;
                    }
                }
                var kgAReformular = kgRecalculoMP - totalReproceso - totalKgSinRecalculo;
                foreach (var item in conRecalculo)
                {
                    if (totalPorcentajeRecalculo == 0)
                    {
                        item.CantidadKGReal = 0;
                    }
                    else
                    {
                        var newPorcentaje = (decimal)item.CantidadPor.Value / totalPorcentajeRecalculo;
                        item.CantidadKGReal = decimal.Round(newPorcentaje * kgAReformular, 4);
                    }
                }
                db0.SaveChanges();
                //Libera todos los lotes asignados porque cambio la cantidad de KG
                new ReservaStockOF().LiberaStockReservadoOF(idplan, true);
            }
        }



        /// <summary>
        /// Actualiza los Kg Reales utilizados de MP y libera el stock reservado (T0072 + T0030)
        /// </summary>
        public void UpdateKgReal(int idplan, int iditem, decimal newKg, bool sinRecalculo = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = db.T0072_FORMULA_TEMP.SingleOrDefault(c => c.OF == idplan && c.idItemFormula == iditem);
                if (result != null)
                {
                    result.CantidadKGReal = newKg;
                    result.Recalculo = sinRecalculo;
                    new StockBatchManagerOF().LiberacionLoteOrdenFabricacionIndividual(idplan, iditem); //al modificar la cantidad resetea la reserva de lote
                    db.SaveChanges();
                }
            }
        }


    }
}
