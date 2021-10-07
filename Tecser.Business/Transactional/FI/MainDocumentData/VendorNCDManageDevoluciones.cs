using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class VendorNcdManageDevoluciones
    {

        /// <summary>
        /// Dado un proveedor retorna los items contabilizados
        /// </summary>
        public static List<string> GetListaMateriales(int idProveedor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listMateriales = from header in db.T0403_VENDOR_FACT_H
                                     where header.IDPROV == idProveedor
                                     join items in db.T0404_VENDOR_FACT_I on header.IDINT equals items.IDINT
                                     select items.ITEM_DESC;

                return listMateriales.Distinct().ToList();
            }
        }

        public List<NcdpDevolucionMPStructure> GetDataComprasItems(int idProveedor, string material)
        {
            var fechaData = DateTime.Today.AddMonths(-9);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = (from header in db.T0403_VENDOR_FACT_H
                            where header.IDPROV == idProveedor && header.FECHA >= fechaData
                            join items in db.T0404_VENDOR_FACT_I on header.IDINT equals items.IDINT
                            where items.ITEM_DESC == material
                            select new NcdpDevolucionMPStructure()
                            {
                                id403 = header.IDINT,
                                id404 = items.IDIT,
                                IdProveedeor = idProveedor,
                                FechaDocumento = header.FECHA,
                                TipoDocumento = header.TFACTURA,
                                NumeroDocumento = header.NFACTURA,
                                MonedaDoc = header.MON,
                                Item = items.ITEM_DESC,
                                Cantidad = items.CANT,
                                MonedaItem = items.MONEDA,
                                PrecioUnitario = items.PUNIT,
                                TCConta = header.TC,
                                GL = items.GL,
                                PUnitArs = items.PUNIT_ARS,
                                PUnitUsd = items.PUNIT_USD
                            }).OrderByDescending(c => c.FechaDocumento).ToList();
                return data;

            }
        }

    }
}
