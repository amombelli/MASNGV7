using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.MM
{
    public class StockList
    {
        /// <summary>
        /// Obtiene all stock (T30) por planta 
        /// </summary>
        public List<T0030_STOCK> GetAll(string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0030_STOCK.Where(c => c.T0028_SLOC.PLTN.Equals(planta)).ToList();
            }
        }

        /// <summary>
        /// Obtiene all stock (T30) por material - planta
        /// </summary>
        public List<T0030_STOCK> GetAllByMaterial(string material, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0030_STOCK.Where(
                        c => c.Material.ToUpper().Equals(material.ToUpper()) && c.T0028_SLOC.PLTN.Equals(planta))
                        .ToList();
            }
        }

        /// <summary>
        /// Lista Stock
        /// </summary>
        public List<T0030_STOCK> GetAllByMaterialEstadoLoteUbicacion(string material, string estado, string numeroLote,
            string sLoc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0030_STOCK.Where(c => c.Material.ToUpper().Equals(material.ToUpper()) &&
                                                 c.Estado.ToUpper().Equals(estado.ToUpper()) &&
                                                 c.Batch.ToUpper().Equals(numeroLote.ToUpper()) &&
                                                 c.SLOC.ToUpper().Equals(sLoc.ToUpper())).ToList();
            }
        }

        /// <summary>
        /// Obtiene stock x Material + Estado + Lote + Ubicacion (usado principalmente para optimizacion de stock)
        /// </summary>
        public IList<MediumStockStructure> GetGroupByMaterialEstadoLoteUbicacion(string materialPrimario = null,
            string estado = "LIBERADO", string numeroLote = null, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (materialPrimario == null)
                {
                    //Todos los materiales 
                    var result = from stk in db.T0030_STOCK
                                 group stk by new { stk.Material, stk.Estado, stk.Batch, stk.SLOC, stk.T0028_SLOC.PLTN }
                        into grp
                                 where grp.Key.PLTN.ToUpper().Equals(planta.ToUpper())
                                 orderby grp.Key.Material
                                 select new MediumStockStructure()
                                 {
                                     Primario = grp.Key.Material,
                                     Estado = grp.Key.Estado,
                                     Lote = grp.Key.Batch,
                                     TotalKg = (decimal)grp.Sum(x => x.Stock),
                                     SLoc = grp.Key.SLOC,
                                     Planta = grp.Key.PLTN,
                                 };
                    return result.ToList();
                }
                else
                {
                    //Un Material especifico
                    var result = from stk in db.T0030_STOCK
                                 group stk by new { stk.Material, stk.Estado, stk.Batch, stk.SLOC, stk.T0028_SLOC.PLTN }
                        into grp
                                 where
                                     grp.Key.Material.ToUpper().Equals(materialPrimario.ToUpper()) &&
                                     grp.Key.PLTN.ToUpper().Equals(planta.ToUpper()) //&&
                                                                                     //grp.Key.Estado.ToUpper().Equals(estado.ToUpper())
                                 orderby grp.Key.Material
                                 select new MediumStockStructure()
                                 {
                                     Primario = grp.Key.Material,
                                     Estado = grp.Key.Estado,
                                     Lote = grp.Key.Batch,
                                     TotalKg = (decimal)grp.Sum(x => x.Stock),
                                     SLoc = grp.Key.SLOC,
                                     Planta = grp.Key.PLTN,
                                 };
                    return result.ToList();
                }
            }
        }


        //TODO Agregar un campo en T0029 AVAILABLE TO BE USED IN PRODUCTION
        public List<T0030_STOCK> GetAllByMaterial_DisponibleProduccion(string material, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0030_STOCK.Where(
                        c =>
                            c.Material.ToUpper().Equals(material.ToUpper()) && c.T0028_SLOC.PLTN == planta &&
                            c.T0029_ESTADO_STOCK.AvailableStateForIP && c.T0028_SLOC.AllowProduction)
                        .OrderBy(c => c.Stock)
                        .ToList();
            }
        }

        /// <summary>
        /// Retorna KG totales de un material disponible para produccion
        /// </summary>
        public decimal GetKgStockDisponibleProduccion(string material, string planta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = from stk in db.T0030_STOCK
                             group stk by
                                 new
                                 {
                                     stk.Material,
                                     stk.Stock,
                                     stk.T0028_SLOC.PLTN,
                                     stk.T0028_SLOC.AllowProduction,
                                     stk.T0029_ESTADO_STOCK.AvailableStateForIP
                                 }
                    into grp
                             where
                                 grp.Key.AllowProduction && grp.Key.AvailableStateForIP &&
                                 grp.Key.Material.ToUpper().Equals(material.ToUpper()) && grp.Key.PLTN == planta
                             select new
                             {
                                 kg = grp.Sum(x => x.Stock)
                             };

                decimal totalKg = 0;

                foreach (var x in result)
                {
                    totalKg += x.kg;
                }

                return totalKg;
            }
        }

        /// <summary>
        /// Reingenieria de funcion que devuelve KG total de un material para una planta determinada
        /// incluyendo o excluyendo ubicaciones que comienzan con "PER*'
        /// </summary>
        public static decimal GetKgStockTotalByMaterial(string material, string planta = "CERR",
            bool incluyePerdido = true)
        {
            //modificado 2019.10.22 incluye Perdido (excluye)
            decimal resultado = 0;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (incluyePerdido)
                {
                    var zx = from stock in db.T0030_STOCK
                             where stock.Material == material && stock.T0028_SLOC.PLTN == planta
                             group stock by new
                             {
                                 stock.Material,
                                 stock.SLOC,
                             }
                        into grp
                             select new
                             {
                                 kg = grp.Sum(x => x.Stock)
                             };
                    foreach (var item in zx)
                    {
                        resultado += item.kg;
                    }
                }
                else
                {
                    var zx = from stock in db.T0030_STOCK
                             where stock.Material == material && stock.T0028_SLOC.PLTN == planta
                             group stock by new
                             {
                                 stock.Material,
                                 stock.SLOC,
                             }
                        into grp
                             where grp.Key.SLOC.Contains("PER") == false
                             select new
                             {
                                 kg = grp.Sum(x => x.Stock)
                             };
                    foreach (var item in zx)
                    {
                        resultado += item.kg;
                    }
                }

                return resultado;
            }
        }

        //var result = from stk in db.T0030_STOCK
        //            group stk by
        //                new
        //                {
        //                    stk.Material,
        //                    stk.Stock,
        //                    stk.T0028_SLOC.PLTN,
        //                }
        //            into grp
        //            where
        //               grp.Key.Material.ToUpper().Equals(material.ToUpper()) && grp.Key.PLTN == planta
        //            select new
        //            {
        //                kg = grp.Sum(x => x.Stock)
        //            };

        //        decimal totalKg = 0;

        //        foreach (var x in result)
        //        {
        //            totalKg += x.kg;
        //        }

        //        return totalKg;
        //    }
        //}

        public List<StockLoteEstadoUbicacion> GetAllStockDispoProduccionStructura(string material, string planta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = from stk in db.T0030_STOCK
                             where stk.Material.ToUpper().Equals(material.ToUpper()) && stk.T0028_SLOC.PLTN.Equals(planta)
                             select new StockLoteEstadoUbicacion()
                             {
                                 Material = stk.Material,
                                 Estado = stk.Estado,
                                 EstadoDispoProd = stk.T0029_ESTADO_STOCK.AvailableStateForIP,
                                 Lote = stk.Batch,
                                 Planta = stk.T0028_SLOC.PLTN,
                                 SLOC = stk.SLOC,
                                 SLocDispoProd = stk.T0028_SLOC.AllowProduction,
                                 TotalKg = (decimal)stk.Stock

                             };
                return result.ToList();
            }
        }

        public List<T0030_STOCK> GetAllReserveOF(int idplan)
        {
            return new TecserData(GlobalApp.CnnApp).T0030_STOCK.Where(c => c.ReservaOF == idplan).ToList();
        }

        public decimal GetKgStockDisponibleDespacho(string material, string planta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = from stk in db.T0030_STOCK
                             group stk by
                                 new
                                 {
                                     stk.Material,
                                     stk.Stock,
                                     stk.T0028_SLOC.PLTN,
                                     stk.T0028_SLOC.AllowDelivery,
                                     stk.Estado
                                 }
                    into grp
                             where
                                 grp.Key.AllowDelivery && grp.Key.Estado.ToUpper().Equals("LIBERADO") &&
                                 grp.Key.Material.ToUpper().Equals(material.ToUpper()) && grp.Key.PLTN == planta
                             select new
                             {
                                 kg = grp.Sum(x => x.Stock)
                             };

                decimal totalKg = 0;

                foreach (var x in result)
                {
                    totalKg += x.kg;
                }

                return totalKg;
            }
        }

        public List<T0030_STOCK> GetAllByMaterial_DisponibleDespacho(string material, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0030_STOCK.Where(
                        c =>
                            c.Material.ToUpper().Equals(material.ToUpper()) && c.T0028_SLOC.PLTN == planta &&
                            c.Estado.ToUpper().Equals("LIBERADO") && c.T0028_SLOC.AllowDelivery)
                        .OrderBy(c => c.Stock)
                        .ToList();
            }
        }



    }
}
