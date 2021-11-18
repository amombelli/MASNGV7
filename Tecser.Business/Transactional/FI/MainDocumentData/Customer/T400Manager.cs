using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Customer
{
    //Nueva clase que pretende emprolijar complejidades de herencia de otras clases
    //Fecha 2020-03-14
    public class T400Manager
    {
        public struct FacturaId
        {
            public int IdFactura { get; set; }
            public decimal IdFacturaX { get; set; }
            public int CantidadItems { get; set; }
            public int IdRemitoIdNcd { get; set; }
        }
        public struct ImportesT400
        {
            public decimal Bruto { get; set; }
            public decimal PorDescuento { get; set; }
            public decimal ImporteDescuento { get; set; }
            public decimal BaseImponible { get; set; }
            public decimal ImporteIVA { get; set; }
            public decimal ImporteIIBB { get; set; }
            public decimal NetoFinal { get; set; }
            public decimal AlicuotaIIBB { get; set; }
        }
        public T0400_FACTURA_H GetDocumentHeader(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
            }
        }
        public List<T0401_FACTURA_I> GetDocumentItems(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
            }
        }
        private int GetNextIdFacturaX(string lx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var max = db.T0400_FACTURA_H.Where(c => c.TIPOFACT == lx).Max(c => c.IDFACTURAX);
                if (max != null)
                    return (int)max + 1;
                return 1;
            }
        }

        public void CreateFromNcdId(int idh, decimal importeIIBB = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var _h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idh);
                var _i = db.T0301_NCD_I.SingleOrDefault(c => c.IDH == idh);

                var cliente = new CustomerManager().GetCustomerBillToData(_h.IdCliente);
                var h = new T0400_FACTURA_H()
                {
                    IDFACTURAX = GetNextIdFacturaX(_h.LX),
                    IDFACTURA = db.T0400_FACTURA_H.Max(c => c.IDFACTURA) + 1,
                    PV_AFIP = "0000",
                    ND_AFIP = "00000000",
                    TIPO_DOC = _h.TDOC,
                    TIPOFACT = _h.LX,
                    FECHA = _h.FECHA,
                    Cliente = _h.IdCliente,
                    RAZONSOC = _h.RazonSocial,
                    CUIT = cliente.CUIT,
                    DIRECCION_FAC = cliente.Direccion_facturacion,
                    LOC_FAC = cliente.Direfactu_Localidad,
                    StatusFactura = DocumentFIStatusManager.StatusHeader.Pendiente.ToString(),
                    Impreso = false,
                    FacturaMoneda = "ARS",
                    TC = _h.TC,
                    TotalFacturaB = 0,
                    Descuento = 0,
                    DescuentoPorc = 0,
                    TotalImpo = 0,
                    TotalIVA21 = 0,
                    TotalIIBB = 0,
                    IIBB_PORC = 0,
                    IIBB_TXT = null,
                    TotalFacturaN = 0,
                    CAE = null,
                    CAE_VTO = null,
                    UserLog = GlobalApp.AppUsername,
                    FechaLog = DateTime.Now,
                    IDRemito = null,
                    Remito = null,
                    NAS = null,
                    NASX1X2 = null,
                    OR = null,
                    RE = false,
                    ID = null,
                    IdCtaCte = null,
                    NumeroDoc = "0000-00000000",
                    FsrId = null
                };

            }
        }




    }
}
