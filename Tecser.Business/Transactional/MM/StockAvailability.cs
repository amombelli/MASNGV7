using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    //Esta clase maneja to_do lo relacionado con la disponibilidad de un stock
    //Listados, etc.

    public class StockAvilability
    {
        public double AvailableStockForProduccion(string material, string planta)
        {
            var primario = new MaterialMasterManager().GetPrimarioFromAka(material);
            if (primario == "@")
                return 0;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from stk in db.T0030_STOCK
                            group stk by
                                new
                                {
                                    stk.Material,
                                    stk.T0028_SLOC.PLTN,
                                    stk.T0029_ESTADO_STOCK.StockAvailable,
                                    stk.T0028_SLOC.AllowProduction
                                }
                    into grp
                            where
                                grp.Key.PLTN.ToUpper().Equals(planta.ToUpper()) && grp.Key.AllowProduction == true &&
                                grp.Key.StockAvailable == true && grp.Key.Material.ToUpper().Equals(primario.ToUpper())
                            select new
                            {
                                TotalKG = grp.Sum(x => x.Stock)
                            };


                if (query.FirstOrDefault() == null)
                {
                    return 0;
                }
                else
                {
                    return (double)query.FirstOrDefault().TotalKG;
                }
            }
        }

        //Funcion que calula el stock disponiblie para ser despachado por:
        //1. Disponible ubicacion 
        //2. Disponible estado
        public double AvailableStockForDespacho(string material, string planta = "CERR")
        {
            var primario = new MaterialMasterManager().GetPrimarioFromAka(material);
            if (primario == "@")
                return 0;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from stk in db.T0030_STOCK
                            group stk by
                                new
                                {
                                    stk.Material,
                                    stk.T0028_SLOC.PLTN,
                                    stk.T0029_ESTADO_STOCK.StockAvailable,
                                    stk.T0028_SLOC.AllowDelivery
                                }
                    into grp
                            where
                                grp.Key.PLTN.ToUpper().Equals(planta.ToUpper()) && grp.Key.AllowDelivery == true &&
                                grp.Key.StockAvailable == true && grp.Key.Material.ToUpper().Equals(primario.ToUpper())
                            select new
                            {
                                TotalKG = grp.Sum(x => x.Stock)
                            };


                if (query.FirstOrDefault() == null)
                {
                    return 0;
                }
                else
                {
                    return (double)query.FirstOrDefault().TotalKG;
                }
            }
        }

        /// <summary>
        /// Funcion que retornar el stock total disponible en la planta (incluye reservado o comprometido)
        /// </summary>
        /// <param name="material"> si es AKA se transforma a Primario</param>
        /// <param name="planta"> Planta donde buscar</param>
        /// <returns></returns>
        public double TotalStockInPlant(string material, string planta = "CERR")
        {
            var primario = new MaterialMasterManager().GetPrimarioFromAka(material);
            if (primario == "@")
                return 0;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from stk in db.T0030_STOCK
                            group stk by
                                new
                                {
                                    stk.Material,
                                    stk.T0028_SLOC.PLTN,
                                }
                    into grp
                            where
                                grp.Key.PLTN.ToUpper().Equals(planta.ToUpper()) &&
                                grp.Key.Material.ToUpper().Equals(primario.ToUpper())
                            select new
                            {
                                TotalKG = grp.Sum(x => x.Stock)
                            };


                if (query.FirstOrDefault() == null)
                {
                    return 0;
                }
                else
                {
                    return (double)query.FirstOrDefault().TotalKG;
                }
            }
        }


        public decimal TotalStockInSloc(string sloc, string planta = "CERR", string material = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (material == null)
                {
                    var rt1 = db.T0030_STOCK.Where(c => c.SLOC.ToUpper().Equals(sloc.ToUpper()) && c.PLTN == planta).ToList();
                    if (rt1.Count == 0)
                        return 0;
                    return rt1.Sum(c => c.Stock);
                }
                else
                {
                    var rt1 = db.T0030_STOCK.Where(c => c.SLOC.ToUpper().Equals(sloc.ToUpper()) && c.PLTN == planta && c.Material == material).ToList();
                    if (rt1.Count == 0)
                        return 0;
                    return rt1.Sum(c => c.Stock);
                }
            }
        }
    }
}
