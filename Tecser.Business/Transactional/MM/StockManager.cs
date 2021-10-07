using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;
using TecserSQL.Data.GenericRepo;
using TecserSQL.Data.TransactionalData;
using GlobalApp = Tecser.Business.MainApp.GlobalApp;

namespace Tecser.Business.Transactional.MM
{
    //aca estamos reemplazando por stock base y sus heredados.
    public class StockManager
    {
        private readonly StockStatusManager _stockStatusManager = new StockStatusManager();

        //Remueve stock que este con valores dentro del margen establecido
        private void RemoveStockInZero(string material = null, decimal margen = (decimal)0.09)
        {
            if (margen > (decimal)0.49)
            {
                //El margen no puede ser mayor que 0.49
                throw new Exception("El Margen no puede ser mayor que 0.49");
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataDelete = new List<T0030_STOCK>();

                if (string.IsNullOrEmpty(material))
                {
                    dataDelete = db.T0030_STOCK.Where(c => c.Stock >= margen * -1 && c.Stock <= margen).ToList();
                }
                else
                {
                    dataDelete =
                        db.T0030_STOCK.Where(
                            c =>
                                c.Material.ToUpper().Equals(material.ToUpper()) && c.Stock >= margen * -1 &&
                                c.Stock <= margen).ToList();
                }


                foreach (var item in dataDelete)
                {
                    if (item.Stock != 0)
                        new MmLog().LogMovimientoT40(item.Material, DateTime.Today, 300, "AJ", "AUTO", item.Stock * -1,
                            "AUTO", item.SLOC, item.Estado, "E", "L1", item.Batch);
                }
                db.T0030_STOCK.RemoveRange(dataDelete);
                db.SaveChanges();
            }
        }
        private void UpdateKgStockLine(int idStock, decimal newKg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (data != null)
                {
                    data.Stock = newKg;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        public bool DeleteStockLine(int idStock)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (stk == null)
                    return false;

                db.T0030_STOCK.Remove(stk);
                try
                {
                    return db.SaveChanges() > 0;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }
        private int NewLine(string material, string numeroLote, decimal kg, string estado, string sLoc, string planta,
            string documento = null, int ovReserva = 0, int despacho = 0, int idStock = 0)
        {
            var stk = new T0030_STOCK
            {
                IDStock = idStock > 0 ? idStock : GetNextId(),
                Material = material,
                Batch = numeroLote,
                Stock = kg,
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

        /// <summary>
        /// Copia una linea de Stock (origen) a una nueva
        /// Regresa el IdStock de la nueva linea - Devuelve -1 si el stock origen no existe
        /// </summary>
        private int CopyStockLine(int origenIdStock, decimal newKg = 0, string newEstado = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == origenIdStock);
                if (stk == null) return -1;

                if (newKg == 0)
                    newKg = (decimal)stk.Stock; //Todo: tendria que ser not null

                var xEstado = newEstado ?? stk.Estado;

                var resultado = this.NewLine(stk.Material, stk.Batch, newKg, xEstado, stk.SLOC, stk.PLTN);

                if (db.SaveChanges() > 0)
                    return resultado;
                return -1;
            }
        }
        public void OptimizaStockLiberado(string materialPrimario = null, string planta = "CERR")
        {
            //this.RemoveStockInZero(materialPrimario);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (materialPrimario == null)
                {
                    //Optimizacion para toda la tabla
                    //Todo: Hacer funcion.
                }
                //if (materialPrimario == "MPPVCGR")
                //{
                //    var x = 1;
                //}
                else
                {
                    var listaMaterialEstadoLoteUbicacion =
                        new StockList().GetGroupByMaterialEstadoLoteUbicacion(materialPrimario);
                    if (listaMaterialEstadoLoteUbicacion == null)
                        return; //No hay nada que hacer

                    foreach (var item in listaMaterialEstadoLoteUbicacion)
                    {
                        if (item.Estado.ToUpper().Equals("LIBERADO"))
                        {
                            //  if (item.Lote == "TECSER20310")
                            //    return;
                            var listaStk = new StockList().GetAllByMaterialEstadoLoteUbicacion(item.Primario,
                                item.Estado, item.Lote, item.SLoc);

                            if (listaStk.Count > 1)
                            {
                                this.UpdateKgStockLine(listaStk[0].IDStock, item.TotalKg);
                                for (var x = 1; x < listaStk.Count; x++)
                                {
                                    this.DeleteStockLine(listaStk[x].IDStock);
                                }
                            }
                        }
                    }
                }
            }
        }
        public List<SimpleStock> GetStockByMaterial(string material)
        {
            var result = new List<SimpleStock>();
            if (material != null)
            {
                string materialPrimario = new MaterialMasterManager().GetPrimarioFromAka(material);
                if (materialPrimario == "@")
                    result.Add(new SimpleStock(null, null, 0, null));
                else
                {
                    var singleOrDefault =
                        new StockData(GlobalApp.CnnApp).GetTotalStock_byMaterial(materialPrimario).SingleOrDefault();
                    if (singleOrDefault != null)
                    {
                        result.Add(singleOrDefault);
                    }
                    else
                    {
                        result.Add(new SimpleStock(null, null, 0, null));
                    }
                }
            }
            else
            {
                var lista = new StockData(GlobalApp.CnnApp).GetTotalStock_byMaterial().ToList();
                result.AddRange(lista.Select(item => item));
            }
            return result;
        }
        public List<SimpleStock> GetTotalStockByMaterial_ByEstado(string primario = null)
        {
            var result = new List<SimpleStock>();
            if (primario != null)
            {
                string materialPrimario = new MaterialMasterManager().GetPrimarioFromAka(primario);
                if (materialPrimario == "@")
                    result.Add(new SimpleStock(null, null, 0, null));
                else
                {
                    var resultByMaterial =
                        new StockData(GlobalApp.CnnApp).GetTotalStock_byMaterialEstado(materialPrimario).ToList();
                    result.AddRange(resultByMaterial.Select(item => item));
                    //que pasa si es null el resultado??
                }
            }
            else
            {
                var lista = new StockData(GlobalApp.CnnApp).GetTotalStock_byMaterialEstado().ToList();
                result.AddRange(lista.Select(item => item));
            }
            return result;
        }
        public List<T0030_STOCK> GetListaStockT0030(string material = null)
        {
            if (material == null)
            {
                return new Repository<T0030_STOCK>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
            }
            else
            {
                string primario = new MaterialMasterManager().GetPrimarioFromAka(material);
                if (primario != "@")
                    return
                        new Repository<T0030_STOCK>(new TecserData(GlobalApp.CnnApp)).Find(c => c.Material.ToUpper().Equals(primario))
                            .ToList();
                return null;
            }
        }
        public static T0030_STOCK GetStockLine(int idStock)
        {
            return new Repository<T0030_STOCK>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.IDStock == idStock);
        }
        public int DuplicaLineaStock(int idStockOrigen, decimal kgDestino)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkOri = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStockOrigen);
                if (stkOri != null)
                {
                    var newStk = new T0030_STOCK
                    {
                        Batch = stkOri.Batch,
                        Estado = stkOri.Estado == "ReservaRE" ? stkOri.EstadoAnteriorReserva : stkOri.Estado
                    };


                    newStk.Estado = stkOri.Estado;
                    newStk.IDStock = GetNextId();
                    newStk.Material = stkOri.Material;
                    newStk.Stock = kgDestino;
                    newStk.SLOC = stkOri.SLOC;
                    newStk.PLTN = stkOri.PLTN;
                    db.T0030_STOCK.Add(newStk);

                    if (db.SaveChanges() > 0)
                        return newStk.IDStock;
                    return -1;
                }
                return -1;
            }
        }

        /// <summary>
        /// Dada una linea de stock - coloca los Kg Requeridos en la linea stock indicada y genera una nueva linea con la diferencia de KG.
        /// Retorna -1 si no se puede hacer el split o 0 si no precisa hacer split o no grabo nada. - Sino, retorna el NUEVO STOCKID
        /// <returns></returns>
        public int SplitStock(int idStock, decimal kgRequeridos)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (stk != null)
                {
                    if (stk.Stock < kgRequeridos)
                        return -1; //No puede hacer un split

                    if (stk.Stock == kgRequeridos)
                        return 0; //No precisa hacer split

                    var newStkId = this.DuplicaLineaStock(idStock, (stk.Stock - kgRequeridos));
                    stk.Stock = kgRequeridos;
                    if (db.SaveChanges() > 0)
                        return newStkId;
                    return 0;
                }

                return -1; //No existe linea de stock
            }
        }

        /// <summary>
        /// Dada una linea de stock (idstock) asigna en esa linea los KG+ESTADO+IDReserva asignados y si es necesario
        /// Hace un split de la linea de stock con los valores correspondientes. - 
        /// </summary>
        /// 
        public void TomaLineaStock(int idstock, decimal kgNecesarios, StockStatusManager.EstadoLote estadoLoteTomado,
            int? reservadoOV = 0, int? reservadoOF = 0, string remitoGuid = null, int? reservaId = 0,
            int? reservaItem = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                if (stk != null)
                {
                    var kgRestantes = decimal.Round((decimal)(stk.Stock - kgNecesarios), 2);
                    if (kgRestantes < 0)
                    {
                        throw new ApplicationException("Los Kg de stock no son necesarios");
                    }

                    if (kgRestantes == 0)
                    {
                        //Toma la linea completa de stock 
                        stk.EstadoAnteriorReserva = stk.Estado;
                        stk.Estado = estadoLoteTomado.ToString();
                        if (reservadoOV != 0)
                            stk.OV_Reserva = reservadoOV;

                        if (reservadoOF != 0)
                            stk.ReservaOF = reservadoOF;

                        if (string.IsNullOrEmpty(remitoGuid) == false)
                            stk.ReservaGUID = new Guid(remitoGuid);

                        if (reservaId != 0)
                            stk.ReservaID = reservaId;

                        if (reservaItem != 0)
                            stk.ReservaItem = reservaItem;

                        stk.Documento = null;
                        stk.UltimoMovimiento = null;
                    }
                    else
                    {
                        //Toma la linea seleciconada con los valores asingados y genera una nueva linea de stock con la diferencia
                        var newidStock = this.SplitStock(idstock, kgNecesarios);
                        stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                        stk.EstadoAnteriorReserva = stk.Estado;
                        stk.Estado = Convert.ToString(estadoLoteTomado);
                        if (reservadoOV != 0)
                            stk.OV_Reserva = reservadoOV;

                        if (reservadoOF != 0)
                            stk.ReservaOF = reservadoOF;

                        if (string.IsNullOrEmpty(remitoGuid) == false)
                            stk.ReservaGUID = new Guid(remitoGuid);

                        if (reservaId != 0)
                            stk.ReservaID = reservaId;

                        if (reservaItem != 0)
                            stk.ReservaItem = reservaItem;

                        stk.Documento = null;
                        stk.UltimoMovimiento = null;
                    }
                    db.SaveChanges();
                }
            }
        }

        public void SeleccionaLineaStockParaReversacion(int idstock, decimal kgNecesarios)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                if (stk != null)
                {
                    var kgRestantes = decimal.Round((decimal)(kgNecesarios - stk.Stock), 2);
                    if (kgRestantes < 0)
                    {
                        var newidStock = this.SplitStock(idstock, kgNecesarios);
                        stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                        stk.EstadoAnteriorReserva = stk.Estado;
                        stk.Estado = StockStatusManager.EstadoLote.Reservado.ToString();
                        stk.OV_Reserva = -9999;
                        stk.Documento = null;
                        stk.UltimoMovimiento = null;
                        kgRestantes = 0;

                        //throw new ApplicationException("Los Kg de stock no son necesarios");
                    }
                    else
                    {
                        //Toma la linea completa de stock
                        stk.Estado = StockStatusManager.EstadoLote.Reservado.ToString();
                        stk.OV_Reserva = -9999;
                        stk.Documento = null;
                        stk.UltimoMovimiento = null;
                    }

                    db.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Log en Tabla T0040
        /// </summary>
        /// <returns>id40</returns>
        public int AddNewStock_withLogT40(string codigoPrimario, string numeroLote, decimal kg,
            StockStatusManager.EstadoLote estadoLote,
            string ubicacionSloc, DateTime fechaMovimiento, MmLog.TipoMovimiento tipoMovimiento, string numeroDocumento,
            string tCode, string lx, string documentoStock = null, int recursoProduccion = 0, int idCli = 0,
            int idPro = 0, string comentarioMovimiento = null, string nombreTablaReferencia = null,
            int referenciaNumerica = 0, string referenciaTexto = null, string texto1 = null, string glVenta = null,
            int nasX1 = 0, int nasX2 = 0)
        {
            var newIdStock = new StockData(GlobalApp.CnnApp).NewLine(codigoPrimario, numeroLote, kg,
                estadoLote.ToString(), ubicacionSloc, "CERR", documentoStock);
            //todo: Reempleazar CERR por planta desde SLOC

            var xdoc = MmLog.TipoDocumentoFromTipoMovimiento(tipoMovimiento).Trim();
            if (string.IsNullOrEmpty(xdoc))
            {
                xdoc = "OF";
            }

            if (newIdStock <= 0) return 0;
            var idLogT40 = new MmLog().LogMovimientoT40(codigoPrimario, fechaMovimiento, Convert.ToInt32(tipoMovimiento),
                xdoc, numeroDocumento, kg, tCode, ubicacionSloc, estadoLote.ToString(), "I", lx, numeroLote,
                recursoProduccion, idCli, idPro, comentarioMovimiento, nombreTablaReferencia, referenciaNumerica,
                referenciaTexto, texto1, glVenta, nasX1, nasX2);
            return idLogT40;
        }


        public int GetLoteRestringido(string material, string lote, decimal cantidad)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (lote.EndsWith("/1"))
                {
                    lote = lote.Replace("/1", "");
                }

                string estado = StockStatusManager.EstadoLote.Restringido.ToString();
                var stk = db.T0030_STOCK.SingleOrDefault(c =>
                    c.Material == material && c.Batch == lote &&
                    c.Estado == estado && c.Stock == cantidad);
                if (stk != null)
                    return stk.IDStock;
                return -1;
            }
        }

        public void ChangeNumeroLote(int idstk, string newLote, string observacion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstk);
                stk.Batch = newLote;
                new MmLog().LogMMChangeLoteNumber(idstk, stk.Stock, stk.Batch, newLote, "QM04", comentario: observacion);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Esta funcion es parte de QM para pasar un lote 'Restringido' a Estado FE/LIBERADO
        /// </summary>
        public void ChangeStatusFromRestringido(string material, string lote, StockStatusManager.EstadoLote estadoLote, string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (lote.EndsWith("/1"))
                {
                    lote = lote.Replace("/1", "");
                    //Si el lote termina en /1 debiera existir sin la /?
                }

                var stkX = db.T0030_STOCK.Where(c =>
                    c.Material == material && c.Estado == StockStatusManager.EstadoLote.Restringido.ToString() &&
                    c.Batch == lote).ToList();

                foreach (var st in stkX)
                {
                    new MmLog().LogMMChangeEstado(st.IDStock, st.Stock, st.Estado, estadoLote.ToString(), "QM04",
                        comentario: comentario);
                    st.Estado = estadoLote.ToString();
                    db.SaveChanges();
                }
            }
        }

        public StockStatusManager.EstadoLote GetEstadoLote(string material, string lote)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (lote.EndsWith("/1"))
                {
                    lote = lote.Replace("/1", "");
                    //Si el lote termina en /1 debiera existir sin la /?
                }

                List<T0030_STOCK> distinctStatus = db.T0030_STOCK.Where(c => c.Material == material && c.Batch == lote).GroupBy(p => p.Estado).Select(g => g.FirstOrDefault()).ToList();
                if (distinctStatus.Count > 1)
                {
                    MessageBox.Show(@"OJOOOOOOOO: El material-lote tiene mas de un estado!");
                    return StockStatusManager.EstadoLote.Reservado;
                }
                return StockStatusManager.MapStatusFromText(distinctStatus[0].Estado);
            }
        }
    }
}


