using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class RemitoStatusManager
    {

        //usado al momento del paso1 de remito
        public enum StatusStockMemoria
        {
            SinStock,
            StockOK,
            Reservado,
            ErrorStk,
            SinValidar,
            StockBlock
        };
        public enum StatusHeader
        {
            Inicial,
            EnPreparacion,
            Preparado,
            Error,
            Generado,
            Impreso,
            Cancelado,
            StandBy
        }
        public enum StatusItem
        {
            SinStock,
            StockOK,
            Parcial,
            ReservadoOK, //Stock Resevado OK para continuar con el Remito
            EnPreparacion,
            Confirmado, //Stock L5.L2 confirmado cuando se genera L5.L1
            Despachado, //Item Despachado OK
            Error,      //Error en item asignado (el stock no existe)
            Cancelado,  //Remito Cancelado (item)
            SinAsignar, //Sin Stock Asignado/Reservado
            ErrorStock, //Error en baja de Stock
        }
        public StatusStockMemoria MapStatusItemMemoria(string status)
        {
            if (String.IsNullOrEmpty(status))
                return StatusStockMemoria.ErrorStk;
            if (status.ToUpper().Equals("EN PREPARACION") || status.ToUpper().Equals("EN_PREPARACION"))
                return StatusStockMemoria.SinStock;
            try
            {
                return (StatusStockMemoria)Enum.Parse(typeof(StatusStockMemoria), status, true);
            }
            catch (Exception)
            {
                return StatusStockMemoria.ErrorStk;
                throw;
            }
        }

        private bool RecheckItemStock(int idStock, int idRemito, int idItemRemito, decimal cantidadKg, string numeroLote)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idStock);
                if (stk == null)
                    return false;

                if (stk.Stock != cantidadKg)
                    return false;

                if (stk.Batch != numeroLote)
                    return false;

                if (idRemito != stk.ReservaID)
                    return false;

                if (idItemRemito != stk.ReservaItem.Value)
                    return false;
            }

            return true;
        }

        public void RecheckStatusItemRemito(int idRemito, int? itemRemito = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);

                switch (h.StatusRemito.ToUpper())
                {
                    case "GENERADO":
                        return;
                    case "IMPRESO":
                        return;
                    case "CANCELADO":
                        return;



                }

                var ir = new List<T0056_REMITO_I>();
                if (itemRemito == null)
                {
                    ir = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
                }
                else
                {
                    ir = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito && c.IDITEM == itemRemito).ToList();
                }
                foreach (var i in ir)
                {
                    if (i.idStockComprometido > 0)
                    {
                        if (RecheckItemStock(i.idStockComprometido.Value, i.IDREMITO, i.IDITEM, i.KGDESPACHADOS, i.BATCH))
                        {
                            i.STATUSITEM = StatusItem.ReservadoOK.ToString();
                        }
                        else
                        {
                            i.STATUSITEM = StatusItem.Error.ToString();
                            i.GENERAR_REMITO = false;
                        }
                    }
                    else
                    {
                        //no tiene asignado idStock
                        var kgStockLiberados = new StockAvilability().AvailableStockForDespacho(i.MATERIAL);
                        if (kgStockLiberados == 0)
                        {
                            i.STATUSITEM = StatusItem.SinStock.ToString();
                        }
                        else
                        {
                            i.STATUSITEM = StatusItem.SinAsignar.ToString();
                        }


                    }
                }
                db.SaveChanges();
            }
        }

        public StatusHeader MapStatusHeaderFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                return StatusHeader.Error;
            if (status.ToUpper().Equals("EN PREPARACION") || status.ToUpper().Equals("EN_PREPARACION"))
                return StatusHeader.EnPreparacion;
            try
            {
                return (StatusHeader)Enum.Parse(typeof(StatusHeader), status, true);
            }
            catch (Exception)
            {
                return StatusHeader.Error;
                throw;
            }
        }
        public StatusItem MapStatusItemFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                status = "Error";

            try
            {
                return (StatusItem)Enum.Parse(typeof(StatusItem), status, true);
            }
            catch (Exception)
            {
                return StatusItem.Error;
                throw;
            }
        }
        public RemitoStatusManager.StatusItem ManageStatusRemito(decimal kgADespachar, decimal kgStock,
            int? idStockReserva = 0)
        {
            return RemitoStatusManager.StatusItem.SinAsignar;


            //    //
            //    return RemitoStatusManager.StatusItem.ReservadoOK;

            //if (kgStock >= kgADespachar)
            //    return RemitoStatusManager.StatusItem.StockOK;

            //if (kgStock > 0)
            //    return RemitoStatusManager.StatusItem.Parcial;

            //return RemitoStatusManager.StatusItem.SinStock;
        }
        public bool SetStatusHeaderPreparado(int idRemito, int cantidadBultos, string responsablePreparacion,
            string comentarioPreparacion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (UpdateItemStatusToReservado(idRemito))
                {
                    var data = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                    try
                    {
                        data.CANTBULTOS = cantidadBultos;
                        data.PREPAREDBY = responsablePreparacion;
                        data.COM_PREP = comentarioPreparacion;
                        data.StatusRemito = RemitoStatusManager.StatusHeader.Preparado.ToString();
                        db.SaveChanges();
                        return true;
                    }
                    catch (NullReferenceException e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        private bool UpdateItemStatusToReservado(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataItems = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito && c.GENERAR_REMITO.Value).ToList();
                foreach (var item in dataItems)
                {
                    if (item.idStockComprometido == null || item.idStockComprometido == 0)
                    {
                        item.STATUSITEM = "Error";
                        db.SaveChanges();
                        return false;
                    }

                    else
                    {
                        item.STATUSITEM = "ReservadoOK";
                    }
                }
                db.SaveChanges();
                return true;
            }
        }
        public static void SetStatusHeaderEnPreparacion(int idRemito)
        {
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    var data = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                    if (data == null)
                        return;

                    data.CANTBULTOS = 0;
                    data.PREPAREDBY = null;
                    data.StatusRemito = "EN PREPARACION";

                    //var dataItem = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
                    //foreach (var itemoI in dataItem)
                    //{
                    //    if (itemoI.STATUSITEM == "ReservadoOK")
                    //    {
                    //        itemoI.STATUSITEM = "StockOk";
                    //    }
                    //}
                    db.SaveChanges();
                }
            }
        }
        public static bool AllowRemitoGenerarSegunEstado(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var statusH = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (statusH == null)
                    return false;

                if (statusH.StatusRemito.ToUpper() == "PREPARADO")
                    return true;
                return false;
            }
        }
        public static bool AllowRemitoGenerarCheckL5(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var statusH = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (statusH == null)
                    return false;

                if (statusH.TIPO_REMITO == "L2" && statusH.RLINK != null)
                {
                    var remitoAsociado = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == statusH.RLINK.Value);
                    if (remitoAsociado == null)
                        return false;

                    {
                        if (remitoAsociado.StatusRemito.ToUpper() == "GENERADO" ||
                            remitoAsociado.StatusRemito.ToUpper() == "IMPRESO")
                            return true;
                        return false;
                    }
                }
                return true;
            }
        }
        public static bool AllowRemitoPreparar(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var statusH = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (statusH == null)
                    return false;

                if (statusH.StatusRemito.ToUpper() == "EN PREPARACION" ||
                    statusH.StatusRemito.ToUpper() == "EN_PREPARACION")
                    return true;
                return false;
            }
        }

        public static bool AllowRemitoPrepararCheckStatusItem(int idRemito)
        {
            var retorno = true;
            new RemitoStatusManager().RecheckStatusItemRemito(idRemito);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
                foreach (var i in item)
                {
                    if (i.GENERAR_REMITO.Value && i.STATUSITEM != RemitoStatusManager.StatusItem.ReservadoOK.ToString())
                    {
                        retorno = false;
                    }
                }
            }
            return retorno;
        }

        public static bool AllowRemitoDespreparar(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var statusH = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (statusH == null)
                    return false;

                if (statusH.StatusRemito.ToUpper() == "PREPARADO")
                    return true;
                return false;
            }
        }
        public static bool AllowRemitoVisualizar(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var statusH = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (statusH == null)
                    return false;

                if (statusH.StatusRemito.ToUpper() == "GENERADO" || statusH.StatusRemito.ToUpper() == "IMPRESO")
                    return true;
                return false;
            }
        }

        //todo: Fix para remover cuando el estado impreso no exista mas.
        public bool FixSetStatusGeneradoFromImpreso(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (x == null)
                    return false;

                if (x.StatusRemito.ToUpper() == "IMPRESO")
                {
                    x.StatusRemito = RemitoStatusManager.StatusHeader.Generado.ToString().ToUpper();
                    x.Impreso = true;
                    if (db.SaveChanges() > 0)
                        return true;
                    return false;
                }
                return false;

            }
        }
    }
}
