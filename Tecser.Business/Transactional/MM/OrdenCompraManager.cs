using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.MM
{
    public class OrdenCompraManager
    {
        public int GetCantidadItemsOC(int numeroOC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0061_OCOMPRA_I.Where(c => c.ORDENCOMPRA == numeroOC).ToList();
                return items.Any() ? items.Count : 0;
            }
        }
        public decimal GetCantidadKgOc(int numeroOC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0061_OCOMPRA_I.Where(c => c.ORDENCOMPRA == numeroOC).ToList();
                return items.Any() ? items.Sum(c => c.CANTIDAD.Value) : 0;
            }
        }
        public List<T0061_OCOMPRA_I> GetListaItemsPendienteEntrega()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x =
                    db.T0061_OCOMPRA_I.Where(
                        c =>
                            (c.StatusItem == OrdenCompraStatusManager.StatusItem.Inicial.ToString() ||
                             c.StatusItem == OrdenCompraStatusManager.StatusItem.Parcial.ToString() ||
                             c.StatusItem == OrdenCompraStatusManager.StatusItem.Excedido.ToString()) &&
                            (c.T0060_OCOMPRA_H.STATUSOC == OrdenCompraStatusManager.StatusHeader.Emitida.ToString() ||
                             c.T0060_OCOMPRA_H.STATUSOC == OrdenCompraStatusManager.StatusHeader.Proceso.ToString()))
                        .ToList();
                return x;
            }
        }

        /// <summary>
        /// Una vez que una OC este en estado de EMITIDA no permitira su modificacion para evitar que una OC# enviada
        /// a un proveedor sea modificada luego:- Habra que cancelarla.
        /// </summary>
        public int EmiteOrdenCompra(T0060_OCOMPRA_H header, List<T0061_OCOMPRA_I> items)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                header.IDORDENCOMPRA = db.T0060_OCOMPRA_H.Max(c => c.IDORDENCOMPRA) + 1;
                header.LogDate = DateTime.Now;
                header.LogUser = GlobalApp.AppUsername;
                header.TotalOC = UpdateTotalOC(items, header.MONEDAOC);
                header.STATUSOC = OrdenCompraStatusManager.StatusHeader.Emitida.ToString();
                db.T0060_OCOMPRA_H.Add(header);
                db.SaveChanges();

                foreach (var i in items)
                {
                    i.ORDENCOMPRA = header.IDORDENCOMPRA;
                    i.CANTIDAD_RECIBIDA = 0;
                    i.StatusItem = OrdenCompraStatusManager.StatusItem.Inicial.ToString();
                    db.T0061_OCOMPRA_I.Add(i);
                    db.SaveChanges();
                    if (i.IdRC != null)
                    {
                        new OrdenCompraManager().UpdateNumeroOCinRC(i.IdRC.Value, i.ORDENCOMPRA, i.IDITEMCOMPRA);
                        new RcStatusManagement().SetOCGenerada(i.IdRC.Value, i.ORDENCOMPRA, i.IDITEMCOMPRA);
                    }
                }
            }
            return header.IDORDENCOMPRA;
        }
        private decimal UpdateTotalOC(List<T0061_OCOMPRA_I> items, string monedaOC)
        {
            decimal precioTotalMoneda = 0;
            foreach (var i in items)
            {
                if (monedaOC == "ARS")
                {
                    precioTotalMoneda += i.PRECIO_UNITARIO_P.Value * i.CANTIDAD.Value;
                }
                else
                {
                    precioTotalMoneda += i.PRECIO_UNITARIO_D.Value * i.CANTIDAD.Value;
                }
            }
            return precioTotalMoneda;
        }
        public void UpdateItemData(T0061_OCOMPRA_I item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0061_OCOMPRA_I.SingleOrDefault(
                        c => c.IDITEMCOMPRA == item.IDITEMCOMPRA && c.ORDENCOMPRA == item.ORDENCOMPRA);
                db.Entry(data).CurrentValues.SetValues(item);
                db.SaveChanges();
            }
        }
        public List<OrdenCompraDgvCompleteo> GetListOCCompletaCompletoByVendor(int idVendor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rtn = new List<OrdenCompraDgvCompleteo>();
                var data1 = from ocHeader in db.T0060_OCOMPRA_H
                            where ocHeader.PROVEEDOR == idVendor
                            join prov in db.T0005_MPROVEEDORES on ocHeader.PROVEEDOR.Value equals prov.id_prov
                            select new OrdenCompraDgvCompleteo()
                            {
                                RazonSocial = prov.prov_rsocial,
                                FECHAOC = ocHeader.FECHAOC,
                                IDORDENCOMPRA = ocHeader.IDORDENCOMPRA,
                                STATUSOC = ocHeader.STATUSOC,
                                TC = ocHeader.TC,
                                TotalOC = ocHeader.TotalOC,
                                ObservacionOC = ocHeader.ObservacionOC,
                                LogUser = ocHeader.LogUser,
                                LogDate = ocHeader.LogDate,
                                MONEDAOC = ocHeader.MONEDAOC,
                                FECHA_RECIBIDO = ocHeader.FECHA_RECIBIDO,
                                PROVEEDOR = ocHeader.PROVEEDOR
                            };
                return data1.OrderByDescending(c => c.IDORDENCOMPRA).ToList();

                //var data = from rc in db.T0068RequisicionCompra
                //        join oc in db.T0061_OCOMPRA_I on rc.NumeroOC equals oc.ORDENCOMPRA
                //            into list1
                //        from l1 in list1.DefaultIfEmpty()
                //        select new RcDataStructure()
                //        {
                //            IdRc = rc.idRc,
                //            Material = rc.Material,
                //            FechaRc = rc.FechaRc,
                //            StatusRc = rc.StatusRc,
                //            KgRC = rc.KgRequeridos,
                //            KgAprodados = rc.KgRequeridos,
                //            ObservacionItem = rc.ComentarioRc,
                //            IdOC = l1.ORDENCOMPRA,
                //            FechaOC = l1.T0060_OCOMPRA_H.FECHAOC,
                //            StatusOC = l1.T0060_OCOMPRA_H.STATUSOC,
                //            KgRecibidos = l1.CANTIDAD_RECIBIDA
                //        };
                //    return data.ToList();
            }
        }
        public List<OrdenCompraDgvCompleteo> GetListOCCompletaCompleto(int recordMax = 50)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rtn = new List<OrdenCompraDgvCompleteo>();
                var data1 = from ocHeader in db.T0060_OCOMPRA_H
                            join prov in db.T0005_MPROVEEDORES on ocHeader.PROVEEDOR.Value equals prov.id_prov
                            select new OrdenCompraDgvCompleteo()
                            {
                                RazonSocial = prov.prov_rsocial,
                                FECHAOC = ocHeader.FECHAOC,
                                IDORDENCOMPRA = ocHeader.IDORDENCOMPRA,
                                STATUSOC = ocHeader.STATUSOC,
                                TC = ocHeader.TC,
                                TotalOC = ocHeader.TotalOC,
                                ObservacionOC = ocHeader.ObservacionOC,
                                LogUser = ocHeader.LogUser,
                                LogDate = ocHeader.LogDate,
                                MONEDAOC = ocHeader.MONEDAOC,
                                FECHA_RECIBIDO = ocHeader.FECHA_RECIBIDO,
                                PROVEEDOR = ocHeader.PROVEEDOR
                            };
                return data1.OrderByDescending(c => c.IDORDENCOMPRA).ToList();

                //var data = from rc in db.T0068RequisicionCompra
                //        join oc in db.T0061_OCOMPRA_I on rc.NumeroOC equals oc.ORDENCOMPRA
                //            into list1
                //        from l1 in list1.DefaultIfEmpty()
                //        select new RcDataStructure()
                //        {
                //            IdRc = rc.idRc,
                //            Material = rc.Material,
                //            FechaRc = rc.FechaRc,
                //            StatusRc = rc.StatusRc,
                //            KgRC = rc.KgRequeridos,
                //            KgAprodados = rc.KgRequeridos,
                //            ObservacionItem = rc.ComentarioRc,
                //            IdOC = l1.ORDENCOMPRA,
                //            FechaOC = l1.T0060_OCOMPRA_H.FECHAOC,
                //            StatusOC = l1.T0060_OCOMPRA_H.STATUSOC,
                //            KgRecibidos = l1.CANTIDAD_RECIBIDA
                //        };
                //    return data.ToList();
            }
        }
        public List<T0060_OCOMPRA_H> GerListOC(int recordMax = 50)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0060_OCOMPRA_H.OrderByDescending(c => c.IDORDENCOMPRA).Take(recordMax).ToList();
            }
        }
        /// <summary>
        /// Devuelve la lista de items en estado EMITIDA de una OC.I para un vendor especifico
        /// </summary>
        public List<T0061_OCOMPRA_I> GetListItemsDisponiblesIngresoByVendor(int vendorId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result =
                    db.T0061_OCOMPRA_I.Where(
                        c => (c.StatusItem.ToUpper().Equals("INICIAL") || c.StatusItem.ToUpper().Equals("PARCIAL"))
                        && c.T0060_OCOMPRA_H.PROVEEDOR == vendorId);

                return result.ToList();
            }
        }
        public T0060_OCOMPRA_H GetDataOcHeader(int numeroOC)
        {
            return new TecserData(GlobalApp.CnnApp).T0060_OCOMPRA_H.SingleOrDefault(c => c.IDORDENCOMPRA == numeroOC);
        }
        public List<T0060_OCOMPRA_H> GetListofOrdenCompraByVendor(int idproveeedor)
        {
            return new TecserData(GlobalApp.CnnApp).T0060_OCOMPRA_H.Where(c => c.PROVEEDOR == idproveeedor).OrderByDescending(x => x.IDORDENCOMPRA).ToList();
        }
        public T0061_OCOMPRA_I GetDataOCItem(int numeroOC, int idItem)
        {
            return new TecserData(GlobalApp.CnnApp).T0061_OCOMPRA_I.SingleOrDefault(c => c.ORDENCOMPRA == numeroOC && c.IDITEMCOMPRA == idItem);
        }
        public List<T0061_OCOMPRA_I> GetListItemsOC(int numeroOC)
        {
            return new TecserData(GlobalApp.CnnApp).T0061_OCOMPRA_I.Where(c => c.ORDENCOMPRA == numeroOC).OrderBy(c => c.IDITEMCOMPRA).ToList();
        }
        /// <summary>
        /// Actualiza el importe de la Orden de Compra
        /// </summary>
        private void UpdateImporteTotalOC(int numeroOC)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0060_OCOMPRA_H.SingleOrDefault(c => c.IDORDENCOMPRA == numeroOC);
                var items = db.T0061_OCOMPRA_I.Where(c => c.ORDENCOMPRA == numeroOC);
                decimal importeOC = 0;
                foreach (var item in items)
                {
                    if (item.StatusItem != "Cancelado")
                    {
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
                db.SaveChanges();
            }
        }
        public int UpdateItemOrdenCompra(T0061_OCOMPRA_I item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0061_OCOMPRA_I.SingleOrDefault(c => c.IDITEMCOMPRA == item.IDITEMCOMPRA && c.ORDENCOMPRA == item.ORDENCOMPRA);
                int iditem;
                if (data == null || item.IDITEMCOMPRA == 0)
                {
                    //new item
                    item.IDITEMCOMPRA = GetNextIdItemCompra();
                    db.T0061_OCOMPRA_I.Add(item);
                    iditem = item.IDITEMCOMPRA;
                }
                else
                {
                    //item existente
                    db.Entry(data).CurrentValues.SetValues(item);
                    iditem = item.IDITEMCOMPRA;
                }
                if (db.SaveChanges() > 0)
                {
                    return iditem;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Si el item estaba en estado inicial lo borra directamente
        /// </summary>
        public bool CancelaItemOrdenCompra(int numeroOC, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item = db.T0061_OCOMPRA_I.SingleOrDefault(c => c.IDITEMCOMPRA == idItem && c.ORDENCOMPRA == numeroOC);
                if (item.StatusItem == "Inicial")
                {
                    db.T0061_OCOMPRA_I.Remove(item);
                }
                db.SaveChanges();
                UpdateImporteTotalOC(numeroOC);
            }

            return true;
        }

        public int InicializaOC(T0060_OCOMPRA_H h)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                h.IDORDENCOMPRA = db.T0060_OCOMPRA_H.Max(c => c.IDORDENCOMPRA) + 1;
                h.STATUSOC = OrdenCompraStatusManager.StatusHeader.Proceso.ToString();
                db.T0060_OCOMPRA_H.Add(h);
                if (db.SaveChanges() > 0)
                    return h.IDORDENCOMPRA;
                return -1;
            }
        }
        private int GetNextIdItemCompra()
        {
            return new TecserData(GlobalApp.CnnApp).T0061_OCOMPRA_I.Max(c => c.IDITEMCOMPRA) + 1;
        }


        public void UpdateNumeroOCinRC(int numeroRc, int numeroOc, int numeroItemOc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rc = db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == numeroRc);
                rc.NumeroOC = numeroOc;
                rc.ItemOC = numeroItemOc;
                db.SaveChanges();
            }
        }
    }
}
