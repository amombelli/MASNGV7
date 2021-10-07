using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class VendorInfoRecordManager
    {
        public T0065_MATERIAL_PROVEEDOR GetInfoRecordMaterialVendor(int vendorId, string materialTecser)


        {
            return
                new TecserData(GlobalApp.CnnApp).T0065_MATERIAL_PROVEEDOR.SingleOrDefault(
                    c =>
                        c.ACTIVO == true && c.PROVEEDOR == vendorId &&
                        c.MATERIAL_TECSER.ToUpper().Equals(materialTecser.ToUpper()));


        }
        public bool UpdateCodigoMaterialProveedor(int idVendor, string idMaterialTecser, string codigoMaterialProveedor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = db.T0065_MATERIAL_PROVEEDOR.SingleOrDefault(c =>
                    c.PROVEEDOR == idVendor && c.MATERIAL_TECSER == idMaterialTecser);
                if (result == null)
                    return false;

                result.MATERIAL_PROVEEDOR = codigoMaterialProveedor;
                db.SaveChanges();
                return true;
            }
        }
        public void ManageAddUpdateInfoRecord(T0065_MATERIAL_PROVEEDOR data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result =
                    db.T0065_MATERIAL_PROVEEDOR.SingleOrDefault(
                        c => c.PROVEEDOR == data.PROVEEDOR && c.MATERIAL_TECSER == data.MATERIAL_TECSER);
                if (result != null)
                {
                    result.ACTIVO = true;
                    result.FULTIMACOMPRA = data.FULTIMACOMPRA;
                    result.MATERIAL_PROVEEDOR = data.MATERIAL_PROVEEDOR;
                    if (result.MONEDAUCOMPRA == data.MONEDAUCOMPRA)
                    {
                        //Misma moneda 
                        if (result.ULTIMOPRECIO != data.ULTIMOPRECIO)
                        {
                            result.FECHA_MODI_PRECIO = DateTime.Today;
                        }
                    }
                    else
                    {
                        if (data.MONEDAUCOMPRA == "ARS")
                        {
                            //antes era USD
                            if (result.ULTIMOTC == 0)
                            {
                                //el ultimo TC era 0 - Asi que no modifica el ultimo precio
                                //porque se trata de algun precio generico.-
                            }
                            else
                            {
                                if (result.ULTIMOPRECIO / result.ULTIMOTC != data.ULTIMOPRECIO)
                                {
                                    result.FECHA_MODI_PRECIO = DateTime.Today;
                                }
                            }
                        }
                        else
                        {
                            //antes era ARS
                            if (result.ULTIMOPRECIO * result.ULTIMOTC != data.ULTIMOPRECIO)
                            {
                                result.FECHA_MODI_PRECIO = DateTime.Today;
                            }
                        }
                    }
                    result.MONEDAUCOMPRA = data.MONEDAUCOMPRA;
                    result.ULTIMACANTIDAD = data.ULTIMACANTIDAD;
                    result.ULTIMOPRECIO = data.ULTIMOPRECIO;
                    result.ULTIMOTC = data.ULTIMOTC;
                    //db.Entry(data).CurrentValues.SetValues(result);
                }
                else
                {
                    data.CALIFICACION = 0;
                    data.COMENTARIO = null;
                    data.ACTIVO = true;
                    data.REQUIERAQA = false;
                    data.FECHA_MODI_PRECIO = DateTime.Today;
                    data.FECHA_ALTA = DateTime.Today;
                    data.FLAG_ALTA = "AUTO";
                    db.T0065_MATERIAL_PROVEEDOR.Add(data);
                }
                db.SaveChanges();
            }
        }
        public void UpdateInfoRecordEmisionOC(int vendorId, string materialTs, string materialProv, decimal kg, string monedaItem, decimal precioMoneda, decimal tc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d =
                    db.T0065_MATERIAL_PROVEEDOR.SingleOrDefault(
                        c => c.PROVEEDOR == vendorId && c.MATERIAL_TECSER == materialTs);
                if (d == null)
                {
                    var it = new T0065_MATERIAL_PROVEEDOR()
                    {
                        ACTIVO = true,
                        CALIFICACION = 0,
                        FECHA_ALTA = DateTime.Today,
                        FLAG_ALTA = "AUTO-OC",
                        REQUIERAQA = false,
                        PROVEEDOR = vendorId,
                        MONEDAUCOMPRA = monedaItem,
                        MATERIAL_PROVEEDOR = materialProv,
                        MATERIAL_TECSER = materialTs,
                        ULTIMACANTIDAD = kg,
                        FULTIMACOMPRA = DateTime.Today,
                        ULTIMOPRECIO = precioMoneda,
                        ULTIMOTC = tc,
                        FECHA_MODI_PRECIO = DateTime.Today,
                        COMENTARIO = null
                    };
                    db.T0065_MATERIAL_PROVEEDOR.Add(it);
                    db.SaveChanges();
                }
                else
                {
                    d.MATERIAL_PROVEEDOR = materialProv;
                    d.FULTIMACOMPRA = DateTime.Today;
                    d.ULTIMACANTIDAD = kg;

                    if (d.MONEDAUCOMPRA != monedaItem)
                    {
                        //Se esta cambiando la moneda - Hago de cuenta que se modifico el precio
                        //para simplificar la funcionalidad
#pragma warning disable CS0168 // The variable 'precioAnteriorNuevaMoneda' is declared but never used
                        decimal precioAnteriorNuevaMoneda;
#pragma warning restore CS0168 // The variable 'precioAnteriorNuevaMoneda' is declared but never used
                        d.MONEDAUCOMPRA = monedaItem;
                        d.ULTIMOPRECIO = precioMoneda;
                        d.FECHA_MODI_PRECIO = DateTime.Today;
                        d.ULTIMOTC = tc;
                    }
                    else
                    {
                        //Compra se cotiza en misma moneda
                        if (d.ULTIMOPRECIO != precioMoneda)
                        {
                            //Se ha cambiado el precio
                            d.ULTIMOPRECIO = precioMoneda;
                            d.FECHA_MODI_PRECIO = DateTime.Today;
                            d.ULTIMOTC = tc;
                        }
                        else
                        {
                            //Se mantiene el precio
                            d.ULTIMOTC = tc;
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
        public List<T0005_MPROVEEDORES> GetVendorListForMaterial(string materialTs)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var values = db.T0065_MATERIAL_PROVEEDOR
                    .Where(c => c.MATERIAL_TECSER == materialTs && c.ACTIVO.Value == true).Select(c => c.PROVEEDOR).ToList();

                return db.T0005_MPROVEEDORES.Where(c => values.Contains(c.id_prov)).ToList();





                //return db.T0005_MPROVEEDORES.Where(c=>c.id_prov =>)

                //var data1 = (from vendor in db.T0005_MPROVEEDORES 
                //        dataInforRecord in db.T0065_MATERIAL_PROVEEDOR
                //    where dataInforRecord.MATERIAL_TECSER == materialTs && dataInforRecord.ACTIVO.Value == true
                //    join vendorData in db.T0005_MPROVEEDORES on dataInforRecord.PROVEEDOR equals vendorData.id_prov
                //        into tempList
                //    from lprov in tempList.DefaultIfEmpty()
                //    select new T0005_MPROVEEDORES()).ToList();
                //return data1.ToList();
            }
        }
    }
}

