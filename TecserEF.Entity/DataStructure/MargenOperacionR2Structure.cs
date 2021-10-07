using System;
using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    //Nueva estructura de Operaciones - Agrega campos sobre Tabla Estandar
    public class MargenOperacionR2Structure : T0140_MargenOperacion
    {
        public string MType { get; set; }
        //public string Vendedor { get; set; }
    }

    public static class MargenOperacionR2
    {
        public static List<MargenOperacionR2Structure> GetMargenOPDataDgvComplete(string cadConexion,
            DateTime? fechaRemitoDesde)
        {
            using (var db = new TecserData(cadConexion))
            {
                if (fechaRemitoDesde == null)
                {
                    var query = from info in db.T0140_MargenOperacion
                                join m in db.T0010_MATERIALES on info.Material equals m.IDMATERIAL
                                join cliEntrega in db.T0007_CLI_ENTREGA on info.IdClienteEntrega equals cliEntrega
                                    .ID_CLI_ENTREGA
                                select new MargenOperacionR2Structure()
                                {
                                    MType = m.TIPO_MATERIAL,
                                    IdCliente = info.IdCliente,
                                    Material = info.Material,
                                    IdFactura = info.IdFactura,
                                    Cantidad = info.Cantidad,
                                    PrecioTotal = info.PrecioTotal,
                                    IdItem = info.IdItem,
                                    PrecioCobradoTotal = info.PrecioCobradoTotal,
                                    CostoTotalAdd = info.CostoTotalAdd,
                                    DiasAcreditacionValores = info.DiasAcreditacionValores,
                                    FacturaNum = info.FacturaNum,
                                    PrecioU = info.PrecioU,
                                    CRVersion = info.CRVersion,
                                    CostoTotal = info.CostoTotal,
                                    CostoMfg = info.CostoMfg,
                                    CostoStadistico = info.CostoStadistico,
                                    IdRemito = info.IdRemito,
                                    CostoUAdd = info.CostoUAdd,
                                    TipoLX = info.TipoLX,
                                    PrecioU1 = info.PrecioU1,
                                    PrecioU2 = info.PrecioU2,
                                    PorcentajeCobrado = info.PorcentajeCobrado,
                                    FechaRemito = info.FechaRemito,
                                    RemitoNum = info.RemitoNum,
                                    TCFactura = info.TCFactura,
                                    MonCosto = info.MonCosto,
                                    MargenOperacionFinal = info.MargenOperacionFinal,
                                    ClienteRs = info.ClienteRs,
                                    CostMapDate = info.CostMapDate,
                                    MargenOperacionVenta = info.MargenOperacionVenta,
                                    DiasReciboPago = info.DiasReciboPago,
                                    FechaFactura = info.FechaFactura,
                                    MargenOperaconVentaUnitario = info.MargenOperaconVentaUnitario,
                                    Vendedor = info.Vendedor,
                                    IdClienteEntrega = info.IdClienteEntrega
                                };
                    return query.OrderByDescending(c => c.FechaRemito.Value).ToList();
                }
                else
                {
                    var query = from info in db.T0140_MargenOperacion
                                join m in db.T0010_MATERIALES on info.Material equals m.IDMATERIAL
                                join cliEntrega in db.T0007_CLI_ENTREGA on info.IdClienteEntrega equals cliEntrega
                                    .ID_CLI_ENTREGA
                                where info.FechaRemito >= fechaRemitoDesde
                                select new MargenOperacionR2Structure()
                                {
                                    MType = m.TIPO_MATERIAL,
                                    IdCliente = info.IdCliente,
                                    Material = info.Material,
                                    IdFactura = info.IdFactura,
                                    Cantidad = info.Cantidad,
                                    PrecioTotal = info.PrecioTotal,
                                    IdItem = info.IdItem,
                                    PrecioCobradoTotal = info.PrecioCobradoTotal,
                                    CostoTotalAdd = info.CostoTotalAdd,
                                    DiasAcreditacionValores = info.DiasAcreditacionValores,
                                    FacturaNum = info.FacturaNum,
                                    PrecioU = info.PrecioU,
                                    CRVersion = info.CRVersion,
                                    CostoTotal = info.CostoTotal,
                                    CostoMfg = info.CostoMfg,
                                    CostoStadistico = info.CostoStadistico,
                                    IdRemito = info.IdRemito,
                                    CostoUAdd = info.CostoUAdd,
                                    TipoLX = info.TipoLX,
                                    PrecioU1 = info.PrecioU1,
                                    PrecioU2 = info.PrecioU2,
                                    PorcentajeCobrado = info.PorcentajeCobrado,
                                    FechaRemito = info.FechaRemito,
                                    RemitoNum = info.RemitoNum,
                                    TCFactura = info.TCFactura,
                                    MonCosto = info.MonCosto,
                                    MargenOperacionFinal = info.MargenOperacionFinal,
                                    ClienteRs = info.ClienteRs,
                                    CostMapDate = info.CostMapDate,
                                    MargenOperacionVenta = info.MargenOperacionVenta,
                                    DiasReciboPago = info.DiasReciboPago,
                                    FechaFactura = info.FechaFactura,
                                    MargenOperaconVentaUnitario = info.MargenOperaconVentaUnitario,
                                    Vendedor = info.Vendedor,
                                    IdClienteEntrega = info.IdClienteEntrega
                                };
                    return query.OrderByDescending(c => c.FechaRemito.Value).ToList();
                }
            }
        }
    }
}