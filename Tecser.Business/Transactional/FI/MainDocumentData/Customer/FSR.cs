using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Customer
{
    public class Fsr
    {
        public List<T0006_MCLIENTES> GetListaclienteFsr()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cli = db.T0006_MCLIENTES.OrderByDescending(c => c.cli_rsocial).ToList();
                return cli;
                //aca reemplazar por funcion que liste solo los clientes habilitados para FSR
            }
        }

        public List<T0046_OV_ITEM> GetListaItemsFsr(int? idCliente = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idCliente == null)
                {
                    return db.T0046_OV_ITEM.Where(c => c.StatusItem == "Pendiente" && c.KGStockDespachados == 0)
                        .ToList();
                }
                else
                {
                    return db.T0046_OV_ITEM.Where(c =>
                            c.StatusItem == "Pendiente" && c.KGStockDespachados == 0 && c.ClienteRZ == idCliente)
                        .ToList();

                }
            }
        }

        public void SetFsrRecord(List<FsRDataStructure> data, int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int a = 0;
                foreach (var item in data)
                {
                    a++;
                    var factuData = db.T0401_FACTURA_I.SingleOrDefault(c => c.IDFactura == idFactura && c.IDITEM == a);
                    var ovData = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == item.IdOV && c.IDITEM == item.IdItem);
                    var stx = new T0049_FSR
                    {
                        IDFactura = idFactura,
                        LogDate = DateTime.Now,
                        LogUser = GlobalApp.AppUsername,
                        Moneda = "ARS",
                        IDOV = item.IdOV,
                        IDOVItem = item.IdItem,
                        Material = ovData.Material,
                        KGFacturado = ovData.Cantidad,
                        IDFacturaItem = a,
                        Precio = ovData.MODO == "L1" ? ovData.PRECIO1 : ovData.PRECIO2,
                    };
                    db.T0049_FSR.Add(stx);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateKgFacturadosOV(List<FsRDataStructure> data, int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int a = 0;
                foreach (var item in data)
                {
                    a++;
                    var factuData = db.T0401_FACTURA_I.SingleOrDefault(c => c.IDFactura == idFactura && c.IDITEM == a);
                    var ovData = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == item.IdOV && c.IDITEM == item.IdItem);
                    ovData.FSR = true;
                    ovData.KGFacturado = factuData.KGDESPACHADOS_R.Value;
                    factuData.FsrOV = item.IdOV;
                    factuData.FsrOVItem = item.IdItem;
                    db.SaveChanges();
                }

                var f400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                f400.FsrId = idFactura;
                db.SaveChanges();
            }
        }
    }

    public class FsRDataStructure
    {
        public int IdOV { get; set; }
        public int IdItem { get; set; }
    }
}

/* *   var data = from rc in db.T0068RequisicionCompra
            join oc in db.T0061_OCOMPRA_I on new { A= (int) rc.NumeroOC, B=(int) rc.ItemOC} equals new { A=oc.ORDENCOMPRA, B=oc.IDITEMCOMPRA }
                into list1
            from l1 in list1.DefaultIfEmpty()
            join proveedor in db.T0005_MPROVEEDORES on rc.ProveedorElegido equals proveedor.id_prov
                into list2
            from l2 in list2.DefaultIfEmpty()
            select new RcDataStructure()
            {
                IdRc = rc.idRc,
                Material = rc.Material,
                FechaRc = rc.FechaRc,
                StatusRc = rc.StatusRc,
                KgRC = rc.KgRequeridos,
                KgAprodados = rc.KgRequeridos,
                ObservacionItem = rc.ComentarioRc,
                IdOC = l1.ORDENCOMPRA,
                FechaOC = l1.T0060_OCOMPRA_H.FECHAOC,
                StatusOC = l1.T0060_OCOMPRA_H.STATUSOC,
                KgRecibidos = l1.CANTIDAD_RECIBIDA,
                IdProv = rc.ProveedorElegido,
                Proveedor = rc.ProveedorElegido!=null?l2.prov_rsocial:null
            };
        return data.ToList();
 * 

public List<T0006_MCLIENTES> GetClientesFSR()
{
    using (var db = new TecserData(GlobalApp.CnnApp))
    {
        var x = db.T0006_MCLIENTES.Where().ToList();
    }
}
}
}//*/
