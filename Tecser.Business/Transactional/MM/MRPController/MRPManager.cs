using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure.MRP;

namespace Tecser.Business.Transactional.MM.MRPController
{
    public class MRPManager
    {
        public List<int> GetOFList(bool statusFormulada = true, bool statusProceso = true, bool statusPlaneado = true, bool statusStandBy = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ofList = new List<int>();
                List<T0070_PLANPRODUCCION> lx;

                if (statusFormulada)
                {
                    lx = db.T0070_PLANPRODUCCION
                        .Where(c => c.STATUS == PlanProduccionStatusManager.StatusOf.Formulada.ToString()).ToList();
                    foreach (var l in lx)
                    {
                        ofList.Add(l.IDPLAN);
                    }
                }

                if (statusProceso)
                {
                    lx = db.T0070_PLANPRODUCCION
                        .Where(c => c.STATUS == PlanProduccionStatusManager.StatusOf.Proceso.ToString()).ToList();
                    foreach (var l in lx)
                    {
                        ofList.Add(l.IDPLAN);
                    }
                }

                if (statusPlaneado)
                {
                    lx = db.T0070_PLANPRODUCCION
                        .Where(c => c.STATUS == PlanProduccionStatusManager.StatusOf.Planeado.ToString()).ToList();
                    foreach (var l in lx)
                    {
                        ofList.Add(l.IDPLAN);
                    }
                }

                if (statusStandBy)
                {
                    lx = db.T0070_PLANPRODUCCION
                        .Where(c => c.STATUS == PlanProduccionStatusManager.StatusOf.StandBy.ToString()).ToList();
                    foreach (var l in lx)
                    {
                        ofList.Add(l.IDPLAN);
                    }
                }
                return ofList;
            }
        }

        private List<MRP1Struct> BOMExplossion(int idOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaData = new List<MRP1Struct>();
                var ofData = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == idOF);
                var xplosion = db.T0072_FORMULA_TEMP.Where(c => c.OF == idOF).OrderBy(c => c.idItemFormula).ToList();
                foreach (var bom in xplosion)
                {
                    var data = new MRP1Struct()
                    {
                        MaterialFab = ofData.MATERIAL,
                        OrdenFab = idOF,
                        KgFab = ofData.KG_FABRICAR,
                        StatusOF = ofData.STATUS,
                        MaterialMP = bom.Primario,
                        CantRequired = bom.CantidadKGReal.Value,
                        LoteAsignado = bom.BatchNumber,
                        StockDispProd = 0,
                        StockTotal = 0,
                        StockReservado = 0,
                        StockStatus = "NODEF"
                    };
                    listaData.Add(data);
                }
                return listaData;
            }
        }
        private List<MRP1Struct> AsignaStockQuantity(List<MRP1Struct> dataIn, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var materiaPrimaDistinct = dataIn.DistinctBy(c => c.MaterialMP).ToList();
                foreach (var mp in materiaPrimaDistinct)
                {
                    var stkDisponibleProduccion = new StockList().GetKgStockDisponibleProduccion(mp.MaterialMP, planta);
                    var stkTotalPlanta = StockList.GetKgStockTotalByMaterial(mp.MaterialMP, planta, false);


                    var listaCompleta = dataIn.Where(c => c.MaterialMP.Equals(mp.MaterialMP)).ToList();
                    foreach (var lst in listaCompleta)
                    {
                        lst.StockTotal = stkTotalPlanta;
                        lst.StockDispProd = stkDisponibleProduccion;
                        if (!string.IsNullOrEmpty(lst.LoteAsignado))
                        {
                            lst.StockReservado = lst.CantRequired;
                        }
                    }
                }
            }
            return dataIn;
        }
        public List<MRP1Struct> DoAll(bool statusFormulada = true, bool statusProceso = true, bool statusPlaneado = true, bool statusStandBy = true)
        {
            var listaCompleta = new List<MRP1Struct>();
            var listaOF = GetOFList(statusFormulada, statusProceso, statusPlaneado, statusStandBy);
            foreach (var of in listaOF)
            {
                listaCompleta.AddRange(this.BOMExplossion(of));
            }
            return this.AsignaStockQuantity(listaCompleta);
        }
        public List<MRP2Struct> SumarizaMPConsumption(List<MRP1Struct> dataIn)
        {
            List<MRP2Struct> dataOut = dataIn.GroupBy(x => x.MaterialMP)
                .Select(cl => new MRP2Struct()
                {
                    MaterialMP = cl.First().MaterialMP,
                    CantRequired = cl.Sum(c => c.CantRequired),
                    StockTotal = cl.First().StockTotal,
                    StockReservado = cl.Sum(c => c.StockReservado),
                    StockDispProd = cl.First().StockDispProd,
                    FechaHora = DateTime.Now
                }).ToList();
            return dataOut.OrderBy(c => c.MaterialMP).ToList();
        }

    }
}
