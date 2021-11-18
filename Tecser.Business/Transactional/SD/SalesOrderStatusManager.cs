using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.WM;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class SalesOrderStatusManager
    {
        public enum StatusHeader
        {
            Inicial,
            Emitida,
            Cerrada,
            Cancelada,
            Proceso,
        };
        public enum StatusItem
        {
            Inicial,
            Pendiente,
            Parcial,
            Despachado,
            CerradoM,
            Cancelado
        };
        public static StatusItem MapStatusItemFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = StatusItem.Pendiente.ToString();

            try
            {
                return (StatusItem)Enum.Parse(typeof(StatusItem), status, true);
            }
            catch (Exception)
            {
                return StatusItem.Inicial;
                throw;
            }
        }
        public static StatusHeader MapStatusHeaderFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = StatusHeader.Inicial.ToString();
            try
            {
                return (StatusHeader)Enum.Parse(typeof(StatusHeader), status, true);
            }
            catch (Exception)
            {
                return StatusHeader.Inicial;
                throw;
            }
        }

        /// <summary>
        /// Actualiza el Status del Header de una OV de acuerdo a todos sus items
        /// </summary>
        public static void UpdateStatusHeaderFromStatusItem(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSO);
                var i = db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).ToList();

                //Si la SO esta cancelada no actualiza status
                var statusHeader = MapStatusHeaderFromText(h.StatusOV);
                switch (statusHeader)
                {
                    case StatusHeader.Inicial:
                        break;
                    case StatusHeader.Emitida:
                        break;
                    case StatusHeader.Cerrada:
                        break;
                    case StatusHeader.Cancelada:
                        return; //no hace ningun analisis en status cancelada
                    case StatusHeader.Proceso:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var cantItems = i.Count;

                var xPendiente = 0;
                var xParcial = 0;
                var xDespachado = 0;
                var xCerradoM = 0;
                var xCancelado = 0;

                foreach (var item in i)
                {
                    var estadoItem = MapStatusItemFromText(item.StatusItem);
                    switch (estadoItem)
                    {
                        case StatusItem.Inicial:
                            break;
                        case StatusItem.Pendiente:
                            xPendiente++;
                            break;
                        case StatusItem.Parcial:
                            xParcial++;
                            break;
                        case StatusItem.Despachado:
                            xDespachado++;
                            break;
                        case StatusItem.CerradoM:
                            xCerradoM++;
                            break;
                        case StatusItem.Cancelado:
                            xCancelado++;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                if ((xPendiente + xCancelado) == cantItems)
                {
                    h.StatusOV = StatusHeader.Emitida.ToString(); //Estado Inicial
                }
                else if ((xDespachado + xCerradoM + xCancelado) == cantItems)
                {
                    h.StatusOV = StatusHeader.Cerrada.ToString();
                }
                else if (xCancelado == cantItems)
                {
                    h.StatusOV = StatusHeader.Cancelada.ToString();
                }
                else
                {
                    h.StatusOV = StatusHeader.Proceso.ToString();
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Actualiza automaticamente el estado del item de una OV de acuerdo a los KGDespachados/Pendientes
        /// Si el Status acutal es CerradoM o Cancelado no hace nada
        /// </summary>
        public static void UpdateStatusItem(int idSO, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lineaSO = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);

                if (lineaSO == null)
                    return;

                var kgPendientesDespacho = lineaSO.Cantidad - lineaSO.KGStockDespachados;
                var statusActual = MapStatusItemFromText(lineaSO.StatusItem);
                switch (statusActual)
                {
                    case StatusItem.Inicial:
                        //continua con evaluacion de Kg
                        break;
                    case StatusItem.Pendiente:
                        //continua con evaluacion de Kg
                        break;
                    case StatusItem.Parcial:
                        //continua con evaluacion de Kg
                        break;
                    case StatusItem.Despachado:
                        break;
                    case StatusItem.CerradoM:
                        return; //no actualiza
                    case StatusItem.Cancelado:
                        return; //no actualiza
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                if (kgPendientesDespacho <= 0)
                {
                    lineaSO.StatusItem = StatusItem.Despachado.ToString();
                }
                else
                {
                    lineaSO.StatusItem = lineaSO.KGStockDespachados > 0
                        ? StatusItem.Parcial.ToString()
                        : StatusItem.Pendiente.ToString();
                }
                db.SaveChanges();
            }
        }
        public static bool SetStatusItemCerradoM(int idSO, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (data == null)
                    return false;

                data.StatusItem = StatusItem.CerradoM.ToString();
                return db.SaveChanges() > 0;
            }
        }
        public static bool SetStatusItemCancelado(int idSO, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idSO && c.IDITEM == idItem);
                if (data == null)
                    return false;
                if (data.StatusItem == StatusItem.Parcial.ToString())
                {
                    data.StatusItem = StatusItem.CerradoM.ToString();
                }
                else
                {
                    data.StatusItem = StatusItem.Cancelado.ToString();
                }
                return db.SaveChanges() > 0;
            }
        }
        public static bool SetStatusSalesOrderCancelado(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSO);
                if (h == null)
                    return false;
                var i = db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).ToList();
                foreach (var item in i)
                {
                    item.StatusItem = SalesOrderStatusManager.StatusItem.Cancelado.ToString();
                    new CompromisoManager().FreeItemComprometidoByItemId(item.IDOV, item.IDITEM);
                }
                h.StatusOV = SalesOrderStatusManager.StatusHeader.Cancelada.ToString();
                return db.SaveChanges() > 0;
            }
        }
        public static bool SetStatusSalesOrderCerrado(int idSO)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idSO);
                if (h == null)
                    return false;
                var i = db.T0046_OV_ITEM.Where(c => c.IDOV == idSO).ToList();
                foreach (var item in i)
                {
                    if (item.StatusItem == StatusItem.Inicial.ToString() ||
                        item.StatusItem == StatusItem.Pendiente.ToString())
                    {
                        item.StatusItem = StatusItem.Cancelado.ToString();
                    }
                    if (item.StatusItem == StatusItem.Parcial.ToString())
                    {
                        item.StatusItem = StatusItem.CerradoM.ToString();
                    }
                    new CompromisoManager().FreeItemComprometidoByItemId(item.IDOV, item.IDITEM);
                }
                h.StatusOV = SalesOrderStatusManager.StatusHeader.Cerrada.ToString();
                return db.SaveChanges() > 0;
            }
        }
    }
}
