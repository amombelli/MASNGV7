using System.Collections.Generic;
using System.Linq;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace TecserSQL.Data.TransactionalData
{
    public class StockData
    {
        public StockData(string conn)
        {
            GlobalApp.CnnApp = conn;
        }

        private static class GlobalApp
        {
            public static string CnnApp;
        }


        /// <summary>
        /// Devuelve el stock total por material por planta sin importar ni estado, ni lote, ni ubicacion.
        /// Si el material es null devuelve to_do
        /// </summary>
        public IList<SimpleStock> GetTotalStock_byMaterial(string primario = null, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (primario == null)
                {
                    var result = from stk in db.T0030_STOCK
                                 group stk by new { stk.Material, stk.T0028_SLOC.PLTN }
                        into grp
                                 where grp.Key.PLTN.ToUpper().Equals(planta.ToUpper())
                                 orderby grp.Key.Material
                                 select new SimpleStock
                                 {
                                     Primario = grp.Key.Material,
                                     Estado = null,
                                     TotalKg = (decimal)grp.Sum(x => x.Stock),
                                     Planta = grp.Key.PLTN,
                                 };
                    return result.ToList();
                }
                else
                {
                    var result = from stk in db.T0030_STOCK
                                 group stk by new { stk.Material, stk.T0028_SLOC.PLTN }
                        into grp
                                 where grp.Key.Material.ToUpper().Equals(primario.ToUpper()) && grp.Key.PLTN.ToUpper().Equals(planta.ToUpper())
                                 orderby grp.Key.Material
                                 select new SimpleStock
                                 {
                                     Primario = grp.Key.Material,
                                     Estado = null,
                                     TotalKg = (decimal)grp.Sum(x => x.Stock),
                                     Planta = grp.Key.PLTN,
                                 };
                    return result.ToList();
                }
            }
        }

        /// <summary>
        /// Devuelve el stock total por material-estado-planta sin importar ni el lote ni la ubicacion
        /// Si el material es null devuelve ALL materials.
        /// </summary>
        public IList<SimpleStock> GetTotalStock_byMaterialEstado(string primario = null, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (primario == null)
                {
                    var result = from stk in db.T0030_STOCK
                                 group stk by new { stk.Material, stk.Estado, stk.T0028_SLOC.PLTN }
                        into grp
                                 where grp.Key.PLTN.ToUpper().Equals(planta.ToUpper())
                                 orderby grp.Key.Material
                                 select new SimpleStock
                                 {
                                     Primario = grp.Key.Material,
                                     Estado = grp.Key.Estado,
                                     TotalKg = (decimal)grp.Sum(x => x.Stock),
                                     Planta = grp.Key.PLTN,
                                 };
                    return result.ToList();
                }
                else
                {
                    var result = from stk in db.T0030_STOCK
                                 group stk by new { stk.Material, stk.Estado, stk.T0028_SLOC.PLTN }
                        into grp
                                 where grp.Key.Material.ToUpper().Equals(primario.ToUpper()) && grp.Key.PLTN.ToUpper().Equals(planta.ToUpper())
                                 orderby grp.Key.Material
                                 select new SimpleStock
                                 {
                                     Primario = grp.Key.Material,
                                     Estado = grp.Key.Estado,
                                     TotalKg = (decimal)grp.Sum(x => x.Stock),
                                     Planta = grp.Key.PLTN,
                                 };
                    return result.ToList();
                }

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="primario"></param>
        /// <param name="planta"></param>
        /// <param name="optimizaEstado"></param>
        public void OptimizaStock(string primario = null, string planta = "CERR", string optimizaEstado = "LIBERADO")
        {
            string defaultEstado;
            if (optimizaEstado == null)
            {
                defaultEstado = "LIBERADO";
            }
            else
            {
                defaultEstado = optimizaEstado.ToUpper();
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //remove stock = 0
                var query = db.T0030_STOCK.Where(c => c.Stock == 0);
                foreach (var item in query)
                {
                    db.T0030_STOCK.Remove(item);
                }
                db.SaveChanges();

                if (primario == null)
                {
                    //Optimizacion para toda la tabla
                }
                else
                {
                    var materialEstadoLote = this.GetTotalStock_byMaterialByEstadoByLote(primario, defaultEstado, null);
                    if (materialEstadoLote != null)
                    {

                        foreach (var item in materialEstadoLote)
                        {
                            var stock =
                                db.T0030_STOCK.Where(
                                    c =>
                                        c.Material.ToUpper().Equals(item.Primario.ToUpper()) &&
                                        c.T0028_SLOC.PLTN.ToUpper().Equals(item.Planta.ToUpper()) &&
                                        c.Estado.ToUpper().Equals(item.Estado.ToUpper()) &&
                                        c.Batch.ToUpper().Equals(item.Lote.ToUpper()) &&
                                        c.SLOC.ToUpper().Equals(item.SLoc.ToUpper())).ToList();

                            if (stock.Count > 1)
                            {
                                UpdateKgStockLine(stock[0].IDStock, item.TotalKg);
                                for (var x = 1; x < stock.Count; x++)
                                {
                                    DeleteStockLine(stock[x].IDStock);
                                }
                            }
                        }
                    }
                    else
                    {
                        //nada porque no hay resultado
                    }
                }
            }
        }
        public bool UpdateKgStockLine(int idStock, decimal newKg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (query == null)
                {
                    return false;
                }
                else
                {
                    query.Stock = newKg;
                }
                return db.SaveChanges() > 0;
            }
        }
        public int NewLine(string material, string numeroLote, decimal kg, string estado, string sLoc, string planta,
            string documento = null, int ovReserva = 0, int despacho = 0, int idStock = 0)
        {


            var stk = new T0030_STOCK
            {
                IDStock = idStock > 0 ? idStock : GetNextId(),
                Material = material,
                Batch = numeroLote,
                Stock = decimal.Round(kg, 2),
                Estado = estado,
                Documento = documento,
                OV_Reserva = ovReserva,
                Despacho = despacho,
                SLOC = sLoc,
                PLTN = planta
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0030_STOCK.Add(stk);
                if (db.SaveChanges() > 0)
                {
                    return x.IDStock;
                }
                else
                {
                    return 0;
                }
            }

        }
        private int GetNextId()
        {
            return new TecserData(GlobalApp.CnnApp).T0030_STOCK.Max(c => c.IDStock) + 1;

        }

        public int CopyStockLine(int origenIdStock, decimal newKg = 0, string newEstado = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == origenIdStock);
                if (stk != null)
                {
                    decimal xKg;

                    if (newKg > 0)
                    {
                        xKg = decimal.Round(newKg, 2);
                    }
                    else
                    {
                        xKg = (decimal)stk.Stock;
                    }

                    var xEstado = newEstado ?? stk.Estado;
                    var resultado = this.NewLine(stk.Material, stk.Batch, xKg, xEstado, stk.SLOC, stk.PLTN);
                    return resultado;

                }
                else
                {
                    return -1; //No se copia nada porque el Stock no existe
                }
            }
        }

        public bool DeleteStockLine(int idStock)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);

                if (stk != null)
                {
                    db.T0030_STOCK.Remove(stk);
                    return db.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
        }



        //Utilizado para optimizacion de stock
        public IList<MediumStockStructure> GetTotalStock_byMaterialByEstadoByLote(string primario = null, string estado = null, string numeroLote = null, string planta = "CERR")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (primario == null)
                {
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
                    var result = from stk in db.T0030_STOCK
                                 group stk by new { stk.Material, stk.Estado, stk.Batch, stk.SLOC, stk.T0028_SLOC.PLTN }
                                     into grp
                                 where grp.Key.Material.ToUpper().Equals(primario.ToUpper()) && grp.Key.PLTN.ToUpper().Equals(planta.ToUpper()) && grp.Key.Estado.ToUpper().Equals(estado.ToUpper())
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
    }


    //DoCmd.RunSQL "Delete from T0030_STOCK where stock = 0"
    //If IsNull(MATERIAL) Or MATERIAL = "" Then
    //    'Ejecuta para todos los materiales
    //    DoCmd.RunSQL ("UPDATE T0030_STOCK SET T0030_STOCK.SLOC = '0000' WHERE (((T0030_STOCK.SLOC) Is Null));")
    //    SQL = "SELECT T0030_STOCK.Material, T0030_STOCK.Batch, Sum(Round([Stock],2)) AS SUMOFSTOCK, T0030_STOCK.Estado, T0030_STOCK.SLOC, First(T0030_STOCK.Documento) AS Doc, Count(T0030_STOCK.Stock) AS XCOUNT FROM T0030_STOCK GROUP BY T0030_STOCK.Material, T0030_STOCK.Batch, T0030_STOCK.Estado, T0030_STOCK.SLOC HAVING (((T0030_STOCK.Estado)='Liberado') AND ((Count(T0030_STOCK.Stock))>1));"
    //Else
    //    DoCmd.RunSQL ("UPDATE T0030_STOCK SET T0030_STOCK.SLOC = '0000' WHERE (((T0030_STOCK.Material)='" & MATERIAL & "') AND ((T0030_STOCK.SLOC) Is Null));")
    //    SQL = "SELECT T0030_STOCK.Material, T0030_STOCK.Batch, T0030_STOCK.SLOC, Sum(Round([Stock],2)) AS SUMOFSTOCK, T0030_STOCK.Estado, First(T0030_STOCK.Documento) AS Doc, Count(T0030_STOCK.Stock) AS XCOUNT FROM T0030_STOCK GROUP BY T0030_STOCK.Material, T0030_STOCK.Batch, T0030_STOCK.SLOC, T0030_STOCK.Estado HAVING (((T0030_STOCK.Material)='" & MATERIAL & "') AND ((T0030_STOCK.Estado)='Liberado') AND ((Count(T0030_STOCK.Stock))>1));"
    //End If
    //Set Rs1 = db.OpenRecordset(SQL)
    //While Not Rs1.EOF
    //    If IsNull(Rs1!SLOC) = True Then
    //         Set Rs2 = db.OpenRecordset("Select * from T0030_STOCK where material ='" & Rs1!MATERIAL & "' and batch='" & Rs1!BATCH & "' and estado='Liberado'")
    //    Else
    //         Set Rs2 = db.OpenRecordset("Select * from T0030_STOCK where material ='" & Rs1!MATERIAL & "' and batch='" & Rs1!BATCH & "' and estado='Liberado' and sloc='" & Rs1!SLOC & "'")
    //    End If
    //    Rs2.Edit
    //    Rs2!Stock = Round(Rs1!SumOfStock, 3)
    //    Rs2!OV_Reserva = Null
    //    Rs2!Despacho = 0
    //    Rs2.Update
    //    Rs2.MoveNext
    //    While Not Rs2.EOF
    //        Rs2.Delete
    //        Rs2.MoveNext
    //    Wend
    //    Rs1.MoveNext
    //Wend
    //DoCmd.SetWarnings (True)




}
