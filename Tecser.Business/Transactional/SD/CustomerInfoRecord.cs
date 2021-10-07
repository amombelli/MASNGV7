using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class CustomerInfoRecord
    {

        public List<RtnMaterialVerySimple> GetMaterialList(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rx = from materialAKA in db.T0011_MATERIALES_AKA
                         join CustomerInfoRecord in db.T0047_MATERIAL_CLIENTE on materialAKA.CODVENTA equals
                             CustomerInfoRecord.MATERIAL
                         where CustomerInfoRecord.CLIENTE == idCliente && materialAKA.ACTIVO == true
                         select new RtnMaterialVerySimple()
                         {
                             Activo = materialAKA.ACTIVO,
                             Material = materialAKA.CODVENTA,
                             Descripcion = materialAKA.MAT_DESC2,
                             Primario = materialAKA.PRIMARIO,
                             CodigoCliente = CustomerInfoRecord.MATERIAL_CLI
                         };
                return rx.ToList();
            }
        }


        public List<T0011_MATERIALES_AKA> MaterialList(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //var l1 = db.T0011_MATERIALES_AKA.Where(c => c.ACTIVO == true && c.T0047_MATERIAL_CLIENTE.Any(d=>d.CLIENTE == idCliente)).ToList();

                var resultado = from materialAKA in db.T0011_MATERIALES_AKA
                                join customerInforecord in db.T0047_MATERIAL_CLIENTE on materialAKA.CODVENTA equals customerInforecord.MATERIAL
                                where customerInforecord.CLIENTE == idCliente
                                select materialAKA;

                return resultado.ToList();
            }
        }

        public T0047_MATERIAL_CLIENTE InfoRecordClienteMaterial(int idCliente, string materialAKA)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0047_MATERIAL_CLIENTE.SingleOrDefault(
                        c => c.CLIENTE == idCliente && c.MATERIAL.ToUpper().Equals(materialAKA.ToUpper()));
                return data;
            }
        }

        public void UpdateInfoRecord(T0047_MATERIAL_CLIENTE dataIn, int salesOrderNumber)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0047_MATERIAL_CLIENTE.SingleOrDefault(c => c.CLIENTE == dataIn.CLIENTE && c.MATERIAL == dataIn.MATERIAL);
                if (data == null)
                {
                    //Alta de Inforecord
                    dataIn.ACTIVO = true;
                    dataIn.FECHA_ALTA = DateTime.Now;
                    dataIn.FLAG_ALTA = "AUTO OV @" + salesOrderNumber;
                    db.T0047_MATERIAL_CLIENTE.Add(dataIn);
                    db.SaveChanges();
                }
                else
                {
                    //actualizacion de inforecord
                    data.ACTIVO = dataIn.ACTIVO;
                    data.MATERIAL_CLI = dataIn.MATERIAL_CLI;
                    //
                    if ((data.PRECIO1 + data.PRECIO2) != (dataIn.PRECIO1 + dataIn.PRECIO2))
                    {
                        //actualizacion de precio
                        data.FechaModificacionAnterior = data.FECHA_MODI_PRECIO;
                        data.FECHA_MODI_PRECIO = DateTime.Now;
                        data.MonedaAnteriorCotizacion = data.MONEDAUCOMPRA;
                        data.PrecioAnterior = data.PRECIO1 + data.PRECIO2;
                    }
                    //Actualiza esta compra
                    data.MONEDAUCOMPRA = dataIn.MONEDAUCOMPRA;
                    data.PRECIO1 = dataIn.PRECIO1;
                    data.PRECIO2 = dataIn.PRECIO2;
                    data.modo = dataIn.modo;
                    data.ULTIMOTC = dataIn.ULTIMOTC;
                    db.SaveChanges();
                }
            }
        }
    }
}
