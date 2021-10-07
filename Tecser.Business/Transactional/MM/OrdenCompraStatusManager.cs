using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class OrdenCompraStatusManager
    {
        public enum StatusHeader
        {
            Inicial,    //Al arrancar la OC
            Emitida,    //Emision de OC
            Proceso,    //Se ha recibido parcial (antes era parcial)
            Cerrada,    //Se ha cerrado la OC
            Cancelada,  //Se ha cancelado la OC
        };
        public enum StatusItem
        {
            Inicial,
            Parcial,
            Completo,
            Excedido,
            Cancelado,
            CompletoM,
            Nuevo
        };

        public static StatusHeader MapStatusHeaderFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                return StatusHeader.Inicial;

            if (status.ToUpper().Equals("PARCIAL")) //FIX
                return StatusHeader.Proceso;
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
        public static StatusItem MapStatusItemFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                status = "Inicial";

            if (status == "Cerrado")
                status = StatusItem.CompletoM.ToString();

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
        public void OpenItem(int numeroOC, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item = db.T0061_OCOMPRA_I.SingleOrDefault(c => c.ORDENCOMPRA == numeroOC && c.IDITEMCOMPRA == idItem);
                if (item.CANTIDAD_RECIBIDA == null)
                    item.CANTIDAD_RECIBIDA = 0;

                if (item.CANTIDAD_RECIBIDA == 0)
                    item.StatusItem = StatusItem.Inicial.ToString();

                if (item.CANTIDAD_RECIBIDA > 0)
                    item.StatusItem = StatusItem.Parcial.ToString();

                db.SaveChanges();
                UpdateStatusHeaderFromItems(numeroOC);
            }
        }

        public void CloseItem(int numeroOC, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item = db.T0061_OCOMPRA_I.SingleOrDefault(c => c.ORDENCOMPRA == numeroOC && c.IDITEMCOMPRA == idItem);
                if (item.CANTIDAD_RECIBIDA == null)
                    item.CANTIDAD_RECIBIDA = 0;

                item.StatusItem = StatusItem.CompletoM.ToString();
                db.SaveChanges();
                UpdateStatusHeaderFromItems(numeroOC);
            }
        }

        public void CancelCompleteOC(int numeroOC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0060_OCOMPRA_H.SingleOrDefault(c => c.IDORDENCOMPRA == numeroOC);
                var items = db.T0061_OCOMPRA_I.Where(c => c.ORDENCOMPRA == numeroOC).ToList();
                foreach (var i in items)
                {
                    var statusItem = OrdenCompraStatusManager.MapStatusItemFromText(i.StatusItem);
                    if (statusItem == StatusItem.Inicial || statusItem == StatusItem.Parcial ||
                        statusItem == StatusItem.Nuevo)
                    {
                        i.StatusItem = OrdenCompraStatusManager.StatusItem.CompletoM.ToString();
                        db.SaveChanges();
                    }
                    h.STATUSOC = OrdenCompraStatusManager.StatusHeader.Cancelada.ToString();
                }
            }
        }

        public void UpdateStatusHeaderFromItems(int numeroOC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0060_OCOMPRA_H.SingleOrDefault(c => c.IDORDENCOMPRA == numeroOC);
                var items = db.T0061_OCOMPRA_I.Where(c => c.ORDENCOMPRA == numeroOC).ToList();
                if (items.Count == 0)
                {
                    header.STATUSOC = StatusHeader.Cancelada.ToString();
                    db.SaveChanges();
                    return;
                }

                var nInicial = 0;
                var nProceso = 0;
                var nCompleto = 0;
                var nCancelado = 0;
                var cantidadItems = items.Count;
                foreach (var it in items)
                {
                    var statusItem = MapStatusItemFromText(it.StatusItem);
                    switch (statusItem)
                    {
                        case StatusItem.Inicial:
                            nInicial++;
                            break;
                        case StatusItem.Parcial:
                            nProceso++;
                            break;
                        case StatusItem.Completo:
                            nCompleto++;
                            break;
                        case StatusItem.Excedido:
                            nCompleto++;
                            break;
                        case StatusItem.Cancelado:
                            nCancelado++;
                            break;
                        case StatusItem.CompletoM:
                            nCompleto++;
                            break;
                        case StatusItem.Nuevo:
                            nInicial++;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }


                if (cantidadItems == nCancelado)
                {
                    header.STATUSOC = StatusHeader.Cancelada.ToString();
                    db.SaveChanges();
                    return;
                }

                if (cantidadItems == nInicial)
                {
                    header.STATUSOC = StatusHeader.Emitida.ToString();
                    db.SaveChanges();
                    return;
                }

                if (cantidadItems == nCompleto)
                {
                    header.STATUSOC = StatusHeader.Cerrada.ToString();
                    db.SaveChanges();
                    return;
                }

                header.STATUSOC = StatusHeader.Proceso.ToString();
                db.SaveChanges();
                return;
            }
        }
        public void SetStatusHeaderToEmitida(int numeroOC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0060_OCOMPRA_H.SingleOrDefault(c => c.IDORDENCOMPRA == numeroOC);
                var items = db.T0061_OCOMPRA_I.Where(c => c.ORDENCOMPRA == numeroOC);
                decimal importeOC = 0;

                foreach (var item in items)
                {
                    if (item.StatusItem.ToUpper() == "INICIAL")
                    {
                        item.StatusItem = StatusItem.Inicial.ToString();
                        if (header.MONEDAOC == "ARS")
                        {
                            importeOC = importeOC + (item.PRECIO_UNITARIO_P.Value * item.CANTIDAD.Value);
                        }
                        else
                        {
                            importeOC = importeOC + (item.PRECIO_UNITARIO_D.Value * item.CANTIDAD.Value);
                        }
                    }
                }
                header.TotalOC = importeOC;
                header.STATUSOC = StatusHeader.Emitida.ToString();
                db.SaveChanges();
            }
        }
        public void SetSatusHeaderToCancelada(int numeroOC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0060_OCOMPRA_H.SingleOrDefault(c => c.IDORDENCOMPRA == numeroOC);
                header.STATUSOC = StatusHeader.Cancelada.ToString();
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Si KeepItemOpen = True se deja en Parcial cuando la cantidad recibida no alcanza la cantidad Pedida
        /// sino, el flag no se tiene en cuenta
        /// </summary>
        public void UpdateStatusItem(int numeroOC, int numeroItem, bool keepItemOpen)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item =
                    db.T0061_OCOMPRA_I.SingleOrDefault(c => c.ORDENCOMPRA == numeroOC && c.IDITEMCOMPRA == numeroItem);

                decimal kgRecibidos = item.CANTIDAD_RECIBIDA ?? 0;
                decimal kgPedidos = item.CANTIDAD ?? 0;

                if (kgRecibidos > kgPedidos)
                {
                    item.StatusItem = StatusItem.Excedido.ToString();
                }

                if (kgRecibidos < kgPedidos)
                {
                    item.StatusItem = keepItemOpen ? StatusItem.Parcial.ToString() : StatusItem.CompletoM.ToString();
                }

                if (kgRecibidos == kgPedidos)
                {
                    item.StatusItem = StatusItem.Completo.ToString();
                }
                db.SaveChanges();
                this.UpdateStatusHeaderFromItems(numeroOC);
            }
        }

    }
}