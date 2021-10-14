using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class MargenDocument
    {
        public List<T0140_MargenOperacion> GetMargenDataList(Guid costRoll, string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0140_MargenOperacion.Where(c => c.CRVersion == costRoll && c.Material == material).OrderByDescending(c => c.FechaFactura).ToList();
            }
        }
        public List<T0140_MargenOperacion> GetMargenDataList()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0140_MargenOperacion.OrderByDescending(c => c.FechaFactura).ToList();
            }
        }
        public T0140_MargenOperacion GetMargenDataRecord(int idRemito, int idRemitoItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0140_MargenOperacion.SingleOrDefault(c =>
                    c.IdRemito == idRemito && c.IdItem == idRemitoItem);
            }
        }
        

        public void AddMargenDocumentNcAnulacion()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var nc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == 2822);
                if (nc.idFacturaAsociada != null)
                {
                    //documento tiene asociada otro documento
                    var fcAsoc = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == nc.idFacturaAsociada.Value);
                    var fc = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == nc.idFacturaT0400.Value);
                    //var ope = db.T0140_MargenOperacion.Where();
                }
            }
        }

        public bool AddMargenDocumentoNcDiferenciaPrecio()
        {
            //usar para motivo = DiferenciaPrecio
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var nc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == 2823);
                if (nc.idFacturaAsociada == null) return false;

                //1.- EN NC arreglar que no va el item asociado-- y tiene que tener si o si asociado un documento
                //2. - ver por ejemplo en descuento por pago X -- meter una linea en op que sea item = DESCGRAL -> y el valor costo 0 con margen negativo
                //3.- ver como queda el tema de las imputaciones de NC a Facturas.- 

            }
            return true;
        }

        
        public void AddItemNotaCredito(int idNcHeader)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ncd = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idNcHeader);
                if (ncd == null) return;
                NcRemoveExistingData(idNcHeader);
                
                var nc400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == ncd.idFacturaT0400.Value);
                if (nc400 == null) return;
                var it400 = db.T0401_FACTURA_I.Where(c => c.IDFactura == nc400.IDFACTURA).ToList();
                decimal p1 = 0;
                decimal p2 = 0;

                if (ncd.ImporteARS > 0)
                {
                   //debito
                    var motivo = new CustomerNd(-1).MapMotivoFromTextoToType(ncd.Motivo);
                    switch (motivo)
                    {
                        case CustomerNd.MotivoNotaDebito.AnulaDocumento:
                            //esto anula una NC
                            break;
                        case CustomerNd.MotivoNotaDebito.ChequeRechazado:
                            //no va a OPERACIONES
                            break;
                        case CustomerNd.MotivoNotaDebito.ChequeSinRechazo:
                            //no va a OPERACIONES
                            break;
                        case CustomerNd.MotivoNotaDebito.DiferenciaPrecio:
                            break;
                        case CustomerNd.MotivoNotaDebito.DiferenciaCambio:
                            break;
                        case CustomerNd.MotivoNotaDebito.DiferenciaKg:
                            break;
                        case CustomerNd.MotivoNotaDebito.CargoGralDocumentos:
                            break;
                        case CustomerNd.MotivoNotaDebito.CargoGralPeriodo:
                            break;
                        case CustomerNd.MotivoNotaDebito.GastoBancario:
                            break;
                        case CustomerNd.MotivoNotaDebito.SinMotivo:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else
                {
                    //credito
                    var motivo = new CustomerNc().MapMotivoFromTextoToType(ncd.Motivo);
                    switch (motivo)
                    {
                        case CustomerNc.MotivoNotaCredito.AnulaDocumento:
                            foreach (var i in it400)
                            {
                                if (ncd.LX == "L1")
                                {
                                    p1 = i.PRECIOU_FACT_USD;
                                    p2 = 0;
                                }
                                else
                                {
                                    p2 = i.PRECIOU_FACT_USD;
                                    p1 = 0;
                                }
                                NcAddSingleItemToTable140_Complete(i.ITEM, ncd.IDH, i.IDITEM, 0, p1, p2,
                                    (p1 + p2) * i.KGDESPACHADOS_R.Value, 0, ncd.idFacturaT0400.Value, ncd.NDOC);
                            }

                            break;
                        case CustomerNc.MotivoNotaCredito.DiferenciaPrecio:
                            foreach (var i in it400)
                            {
                                if (ncd.LX == "L1")
                                {
                                    p1 = i.PRECIOU_FACT_USD;
                                    p2 = 0;
                                }
                                else
                                {
                                    p2 = i.PRECIOU_FACT_USD;
                                    p1 = 0;
                                }
                                NcAddSingleItemToTable140_Complete(i.ITEM, ncd.IDH, i.IDITEM, 0, p1, p2,
                                    (p1 + p2) * i.KGDESPACHADOS_R.Value, 0, ncd.idFacturaT0400.Value, ncd.NDOC);

                                //luego hacer update de cantiadad a CERO-
                            }
                            break;
                        case CustomerNc.MotivoNotaCredito.DiferenciaCambio:
                            break;
                        case CustomerNc.MotivoNotaCredito.DiferenciaKg:
                            break;
                        case CustomerNc.MotivoNotaCredito.DevolucionMaterial:
                            foreach (var i in it400)
                            {
                                if (ncd.LX == "L1")
                                {
                                    p1 = i.PRECIOU_FACT_USD;
                                    p2 = 0;
                                }
                                else
                                {
                                    p2 = i.PRECIOU_FACT_USD;
                                    p1 = 0;
                                }
                                NcAddSingleItemToTable140_Complete(i.ITEM, ncd.IDH, i.IDITEM, 0, p1, p2,
                                    (p1 + p2) * i.KGDESPACHADOS_R.Value, 0, ncd.idFacturaAsociada.Value, ncd.NDOC);

                            } 
                            break;
                        case CustomerNc.MotivoNotaCredito.DesGeneralDocumentos:
                            foreach (var i in it400)
                            {
                                if (ncd.LX == "L1")
                                {
                                    p1 = i.PRECIOU_FACT_USD;
                                    p2 = 0;
                                }
                                else
                                {
                                    p2 = i.PRECIOU_FACT_USD;
                                    p1 = 0;
                                }
                                NcAddSingleItemToTable140_Complete(i.ITEM, ncd.IDH, i.IDITEM, 0, p1, p2,
                                    (p1 + p2) * i.KGDESPACHADOS_R.Value, 0, ncd.idFacturaT0400.Value, ncd.NDOC);

                            }
                            break;
                        case CustomerNc.MotivoNotaCredito.DesGeneralPeriodo:
                            foreach (var i in it400)
                            {
                                if (ncd.LX == "L1")
                                {
                                    p1 = i.PRECIOU_FACT_USD;
                                    p2 = 0;
                                }
                                else
                                {
                                    p2 = i.PRECIOU_FACT_USD;
                                    p1 = 0;
                                }
                                NcAddSingleItemToTable140_Complete(i.ITEM, ncd.IDH, i.IDITEM, 0, p1, p2, (p1 + p2) * i.KGDESPACHADOS_R.Value, 0, ncd.idFacturaT0400.Value, ncd.NDOC);
                            }
                            break;
                        case CustomerNc.MotivoNotaCredito.SinMotivo:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        private bool NcRemoveExistingData(int idNcHeader)
        {
            //auxiliar para remover datos existentes
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var nc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idNcHeader);
                if (nc?.idFacturaT0400 == null) return false;
                var fAsoc = db.T0401_FACTURA_I.Where(c => c.IDFactura == nc.idFacturaT0400.Value).ToList();
                foreach (var fi in fAsoc)
                {
                    var dataExiste = db.T0140_MargenOperacion.SingleOrDefault(c =>
                        c.IdRemito == nc.IDH && c.IdItem == fi.IDITEM && c.IdFactura == nc.idFacturaT0400.Value);
                    if (dataExiste != null)
                    {
                        db.T0140_MargenOperacion.Remove(dataExiste);
                        db.SaveChanges();
                    }
                }
                return true;
            }
        }


        /// <summary>
        /// Para USAR en algun tipo de NC donde no se pueda obtener los datos directamente.-
        /// </summary>
        private bool NcAddSingleItemToTable140_Complete(string item, int ncHeader, int idItem, decimal cantidad,
            decimal precio1, decimal precio2, decimal precioTotal, decimal costoStd, int IdDocumentoT400,
            string numeroDocumento, string numeroRemito = null)
        {
            decimal costoTotalOperacionProporcional = 0;
            decimal costoEstadistico = 0;
            decimal costoAdicionalTotal = 0;
            decimal costoUnitarioAdicional = 0;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                decimal costoMfg = costoStd;

                var nc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == ncHeader);
                var crHeader = db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva);
                var clienteRs = nc.RazonSocial.Length > 30
                    ? nc.RazonSocial.Substring(0, 29)
                    : nc.RazonSocial;
                int idClienteEntrega = 0; //ver si vamos a  mandar ClienteEntrega p/paramentnro
                string Vendedor = "XX"; //ver si vamos a mandar Vendedor p/paramentro
                var stx = new T0140_MargenOperacion()
                {
                    IdRemito = nc.IDH,
                    IdItem = idItem,
                    RemitoNum = numeroRemito ?? numeroDocumento,
                    Cantidad = cantidad,
                    CostoMfg = costoMfg, //al costo del dia de la NC
                    MonCosto = "USD",
                    CostoStadistico = costoEstadistico,
                    CostoTotalAdd = costoAdicionalTotal,
                    CostoUAdd = costoUnitarioAdicional,
                    CostoTotal = costoMfg + costoEstadistico + costoUnitarioAdicional +
                                 costoTotalOperacionProporcional,
                    FacturaNum = numeroDocumento,
                    FechaFactura = nc.FECHA,
                    FechaRemito = nc.FECHA,
                    TCFactura = nc.TC,
                    TipoLX = nc.LX,
                    PrecioU1 = precio1,
                    PrecioU2 = precio2,
                    PrecioU = precio1 + precio2,
                    PrecioTotal = precioTotal,
                    PorcentajeCobrado = 0,
                    PrecioCobradoTotal = 0,
                    MargenOperacionFinal = 0,
                    MargenOperacionVenta = 0,
                    Material = item,
                    IdCliente = nc.IdCliente,
                    ClienteRs = clienteRs,
                    IdFactura = IdDocumentoT400,
                    CRVersion = crHeader.idCostRoll,
                    CostMapDate = DateTime.Now,
                    IdClienteEntrega = idClienteEntrega,
                    Vendedor = Vendedor,
                };
                stx.MargenOperacionVenta = stx.PrecioTotal - ((stx.Cantidad * stx.CostoTotal) + stx.CostoTotalAdd);
                db.T0140_MargenOperacion.Add(stx);
                db.SaveChanges();
                return true;
            }
        }


        private bool NcAddSingleItemToTable140(string item, int ncHeader,int idItem,decimal cantidad,decimal precio1, decimal precio2,int idDocumentoT400,string numeroDocumento,string numeroRemito=null)
        {
            decimal costoTotalOperacionProporcional = 0;
            decimal costoEstadistico = 0;
            decimal costoAdicionalTotal = 0;
            decimal costoUnitarioAdicional = 0;
            decimal costoMfg;
            
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var std = new ACostoStandard(item);
                std.GetCost();
                if (std.Encontrado == false || std.ValorUSD > 9999)
                {
                    var xmfgStd = new ACostoMfgNowStd(item);
                    xmfgStd.GetCost();
                    costoMfg = xmfgStd.Moneda == "ARS" ? xmfgStd.ValorARS : xmfgStd.ValorUSD;
                }
                else
                {
                    costoMfg = std.Moneda == "ARS" ? std.ValorARS : std.ValorUSD;
                }

                var nc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == ncHeader);
                var crHeader = db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva);
                var clienteRs = nc.RazonSocial.Length > 30
                    ? nc.RazonSocial.Substring(0, 29)
                    : nc.RazonSocial;
                int idClienteEntrega = 0;   //ver si vamos a  mandar ClienteEntrega p/paramentnro
                string Vendedor = "XX";     //ver si vamos a mandar Vendedor p/paramentro
                var stx = new T0140_MargenOperacion()
                {
                    IdRemito = nc.IDH,
                    IdItem = idItem,
                    RemitoNum = numeroRemito ?? numeroDocumento,
                    Cantidad = cantidad,
                    CostoMfg = costoMfg, //al costo del dia de la NC
                    MonCosto = std.Moneda,
                    CostoStadistico = costoEstadistico,
                    CostoTotalAdd = costoAdicionalTotal,
                    CostoUAdd = costoUnitarioAdicional,
                    CostoTotal = costoMfg + costoEstadistico + costoUnitarioAdicional +
                                 costoTotalOperacionProporcional,
                    FacturaNum = numeroDocumento,
                    FechaFactura = nc.FECHA,
                    FechaRemito = nc.FECHA,
                    TCFactura = nc.TC,
                    TipoLX = nc.LX,
                    PrecioU1 = precio1,
                    PrecioU2 = precio2,
                    PrecioU = precio1+precio2,
                    PrecioTotal = (precio1+precio2)*cantidad,
                    PorcentajeCobrado = 0,
                    PrecioCobradoTotal = 0,
                    MargenOperacionFinal = 0,
                    MargenOperacionVenta = 0,
                    Material = item,
                    IdCliente = nc.IdCliente,
                    ClienteRs = clienteRs,
                    IdFactura = idDocumentoT400,
                    CRVersion = crHeader.idCostRoll,
                    CostMapDate = DateTime.Now,
                    IdClienteEntrega = idClienteEntrega,
                    Vendedor = Vendedor,
                };
                stx.MargenOperacionVenta = stx.PrecioTotal - ((stx.Cantidad * stx.CostoTotal) + stx.CostoTotalAdd);
                db.T0140_MargenOperacion.Add(stx);
                db.SaveChanges();
                return true;
            }
        }


        public bool AddMargenDocumentNcModifacionKg()
        {
            //Usar para NC - Devolucion de KG **** 'DevolucionMaterial'


            //todo: poner un flag en T0400 para marcar si el registro de operaciones tiene alguna NC/ND asociada!
            //agrega los Items de las NC por devolucion de KG.- en forma separada y adicional
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var nc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == 2822);
                if (nc.idFacturaAsociada == null) return false;

                var fAsoc = db.T0401_FACTURA_I.Where(c => c.IDFactura == nc.idFacturaAsociada.Value).ToList();
                var margenOri = "";
                foreach (var fi in fAsoc)
                {
                    var dataExiste = db.T0140_MargenOperacion.SingleOrDefault(c =>
                        c.IdRemito == nc.IDH && c.IdItem == fi.IDITEM && c.IdFactura == nc.IDH);
                    if (dataExiste != null)
                    {
                        db.T0140_MargenOperacion.Remove(dataExiste);
                        db.SaveChanges();
                    }

                    decimal costoMfg;
                    var std = new ACostoStandard(fi.ITEM);
                    std.GetCost();
                    if (std.Encontrado == false || std.ValorUSD > 9999)
                    {
                        //obtener costo STD nuevo 
                        Debug.Print($"Obteniendo costo MFG-STD {fi.ITEM}");
                        var xmfgStd = new ACostoMfgNowStd(fi.ITEM);
                        xmfgStd.GetCost();
                        costoMfg = xmfgStd.Moneda == "ARS" ? xmfgStd.ValorARS : xmfgStd.ValorUSD;
                        Debug.Print($"Costo Obtenido por Mfg-STD {xmfgStd.Moneda} {costoMfg}");
                    }
                    else
                    {
                        costoMfg = std.Moneda == "ARS" ? std.ValorARS : std.ValorUSD;
                    }

                    Debug.Print($"Alta NC ID {nc.IDH}");
                    var clienteRs = nc.RazonSocial.Length > 30
                        ? nc.RazonSocial.Substring(0, 29)
                        : nc.RazonSocial;
                    decimal costoTotalOperacionProporcional = 0;
                    decimal costoEstadistico = 0;
                    decimal costoAdicionalTotal = 0;
                    decimal costoUnitarioAdicional = 0;
                    var crHeader = db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva);
                    int idClienteEntrega = 0;
                    string Vendedor = "XX";
                    var stx = new T0140_MargenOperacion()
                    {
                        IdRemito = nc.IDH,
                        IdItem = fi.IDITEM,
                        RemitoNum = fi.T0400_FACTURA_H.NumeroDoc,
                        Cantidad = fi.KGDESPACHADOS_R.Value,
                        CostoMfg = costoMfg, //al costo del dia de la NC
                        MonCosto = std.Moneda,
                        CostoStadistico = costoEstadistico,
                        CostoTotalAdd = costoAdicionalTotal,
                        CostoUAdd = costoUnitarioAdicional,
                        CostoTotal = costoMfg + costoEstadistico + costoUnitarioAdicional +
                                     costoTotalOperacionProporcional,
                        FacturaNum = fi.T0400_FACTURA_H.NumeroDoc,
                        FechaFactura = nc.FECHA,
                        FechaRemito = nc.FECHA,
                        TCFactura = nc.TC,
                        TipoLX = nc.LX,
                        PrecioU1 = 0,
                        PrecioU2 = 0,
                        PrecioU = 0,
                        PrecioTotal = 0,
                        PorcentajeCobrado = 0,
                        PrecioCobradoTotal = 0,
                        MargenOperacionFinal = 0,
                        MargenOperacionVenta = 0,
                        Material = fi.ITEM,
                        IdCliente = nc.IdCliente,
                        ClienteRs = clienteRs,
                        IdFactura = fi.IDFactura,
                        CRVersion = crHeader.idCostRoll,
                        CostMapDate = DateTime.Now,
                        IdClienteEntrega = idClienteEntrega,
                        Vendedor = Vendedor,
                    };

                    if (nc.LX == "L1")
                    {
                        stx.PrecioU1 = fi.PRECIOU_FACT_USD;
                    }
                    else
                    {
                        stx.PrecioU2 = fi.PRECIOU_FACT_USD;
                    }

                    stx.PrecioU = stx.PrecioU1 + stx.PrecioU2;
                    stx.PrecioTotal = stx.PrecioU * stx.Cantidad;
                    stx.MargenOperacionVenta = stx.PrecioTotal - ((stx.Cantidad * stx.CostoTotal) + stx.CostoTotalAdd);
                    db.T0140_MargenOperacion.Add(stx);
                    db.SaveChanges();
                }
            }
            return true;
        }



        /// <summary>
        /// Agrega documento a T0140 Margen Operativo por IdRemito
        /// 
        /// </summary>
        public bool AddMargenDocumentAndMapCost(int idRemito, bool replace = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataRemitoH = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (dataRemitoH == null)
                    return false;

                if (dataRemitoH.StatusRemito.ToUpper() != RemitoStatusManager.StatusHeader.Impreso.ToString().ToUpper())
                {
                    //solo agrega el documento cuando el remito esta impreso
                    Debug.Print($"No se agrego Remito {dataRemitoH.IDREMITO} porque no esta impreso!");
                    return false;
                }
                var dataRemitoI = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
                var dataExiste = db.T0140_MargenOperacion.Where(c => c.IdRemito == idRemito).ToList();
                if (dataExiste.Any())
                {
                    if (replace == false)
                        return true;
                    db.T0140_MargenOperacion.RemoveRange(dataExiste);
                    db.SaveChanges();
                }
                var crHeader = db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva);
                string tipoRemito = dataRemitoH.TIPO_REMITO;
                decimal costoUnitarioAdicional = 0;
                decimal costoAdicionalTotal = 0;
                decimal costoEstadistico = 0;
                foreach (var remitoItem in dataRemitoI)
                {
                    if (remitoItem.L5 == true && remitoItem.LX == "L2")
                    {
                        //El Remito L2 de un L5 no se agrega
                        Debug.Print($"No se Agrego Remito {remitoItem.IDREMITO} - Item @{remitoItem.IDITEM} Porque Item es Remito L2 de L5");
                    }
                    else
                    {
                        if (remitoItem.MATERIAL == "CGR288P")
                        {
                            var I = 1;
                        }
                        decimal costoMfg;
                        var std = new ACostoStandard(remitoItem.MATERIAL);
                        std.GetCost();
                        if (std.Encontrado == false || std.ValorUSD >9999)
                        {
                            //obtener costo STD nuevo 
                            Debug.Print($"Obteniendo costo MFG-STD {remitoItem.MATERIAL}");
                            var xmfgStd = new ACostoMfgNowStd(remitoItem.MATERIAL);
                            xmfgStd.GetCost();
                            if (xmfgStd.Moneda == "ARS")
                            {
                                costoMfg = xmfgStd.ValorARS;
                            }
                            else
                            {
                                costoMfg = xmfgStd.ValorUSD;
                            }
                            Debug.Print($"Costo Obtenido por Mfg-STD {xmfgStd.Moneda} {costoMfg}");
                        }
                        else
                        {
                            if (std.Moneda == "ARS")
                            {
                                costoMfg = std.ValorARS;
                            }
                            else
                            {
                                costoMfg = std.ValorUSD;
                            }
                        }

                        Debug.Print($"Alta Remito ID {idRemito}");
                        var clienteRs = dataRemitoH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial.Length > 30
                            ? dataRemitoH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial.Substring(0, 29)
                            : dataRemitoH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial;

                        decimal costoTotalOperacionProporcional = 0;
                        if (remitoItem.KGDESPACHADOS_R != 0)
                            costoTotalOperacionProporcional = costoAdicionalTotal / remitoItem.KGDESPACHADOS_R;

                        var stx = new T0140_MargenOperacion()
                        {
                            IdRemito = idRemito,
                            IdItem = remitoItem.IDITEM,
                            RemitoNum = dataRemitoH.NUMREMITO,
                            Cantidad = remitoItem.KGDESPACHADOS,
                            CostoMfg = costoMfg,
                            MonCosto = std.Moneda,
                            CostoStadistico = costoEstadistico,
                            CostoTotalAdd = costoAdicionalTotal,
                            CostoUAdd = costoUnitarioAdicional,
                            CostoTotal = costoMfg + costoEstadistico + costoUnitarioAdicional + costoTotalOperacionProporcional,
                            FacturaNum = "0000-00000000",
                            FechaFactura = null,
                            FechaRemito = dataRemitoH.FECHA,
                            TCFactura = 0,
                            TipoLX = dataRemitoH.TIPO_REMITO,
                            PrecioU1 = 0,
                            PrecioU2 = 0,
                            PrecioU = 0,
                            PrecioTotal = 0,
                            PorcentajeCobrado = 0,
                            PrecioCobradoTotal = 0,
                            MargenOperacionFinal = 0,
                            MargenOperacionVenta = 0,
                            Material = remitoItem.MATERIAL,
                            IdCliente = dataRemitoH.T0007_CLI_ENTREGA.IDCLIENTE,
                            ClienteRs = clienteRs,
                            IdFactura = 0,
                            CRVersion = crHeader.idCostRoll,
                            CostMapDate = DateTime.Now,
                            IdClienteEntrega = dataRemitoH.CODCLIENTREGA,
                            Vendedor = dataRemitoH.T0007_CLI_ENTREGA.Vendedor,
                        };
                        if (remitoItem.L5 == true)
                        {
                            //Este registro L5 es L1 porque L2 se saltea
                            //Hay que sumar el precio del remito L2
                            stx.PrecioU1 = remitoItem.PRECIOU_USD.Value;
                            stx.TipoLX = "L5";
                            var remitoL2 = db.T0056_REMITO_I.Where(c =>
                                c.IDREMITO == remitoItem.RLINK.Value && c.IDOV == remitoItem.IDOV &&
                                c.IDOVITEM == remitoItem.IDOVITEM).ToList();
                            decimal ksum = 0;
                            decimal precioUsd = 0;
                            foreach (var r in remitoL2)
                            {
                                ksum += r.KGDESPACHADOS_R;
                                if (r.MONEDA == "USD")
                                {
                                    precioUsd += r.PRECIOT.Value;
                                }
                                else
                                {
                                    precioUsd += (r.PRECIOT.Value * r.KGDESPACHADOS_R);
                                }
                            }
                            stx.PrecioU2 = precioUsd / ksum;
                        }
                        else
                        {
                            //No es remito L5 (L1 o L2 puro)
                            if (remitoItem.LX == "L1")
                            {
                                stx.PrecioU1 = remitoItem.PRECIOU_USD.Value;
                            }
                            else
                            {
                                stx.PrecioU2 = remitoItem.PRECIOU_USD.Value;
                            }
                        }
                        stx.PrecioU = stx.PrecioU1 + stx.PrecioU2;
                        stx.PrecioTotal = stx.PrecioU * stx.Cantidad;
                        stx.MargenOperacionVenta = stx.PrecioTotal - ((stx.Cantidad * stx.CostoTotal) + stx.CostoTotalAdd);
                        db.T0140_MargenOperacion.Add(stx);
                        db.SaveChanges();
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Actualiza el Status de Cobranza en MOP
        /// Si se envia idFactaura ==0 se realiza para todos los documentos de MOP
        /// </summary>
        public bool UpdateStatusCobranza(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<int?> idsFact = new List<int?>();
                if (idFactura == 0)
                {
                    //se ejecuta para todas las facturas con ID Factura Asignado : MODO INCIAL
                    var fact = db.T0140_MargenOperacion.Where(c => c.IdFactura > 0).ToList();
                    idsFact = db.T0140_MargenOperacion.Select(c => c.IdFactura).Distinct().Where(c => c.Value > 0).ToList();
                }
                else
                {
                    //Modo Normal
                    idsFact.Add(idFactura);
                }

                foreach (var f in idsFact)
                {
                    var rx = new CobranzaUtils().GetValorImputacion(f.Value);
                    if (rx.ValidacionPorcPago == false)
                    {
                        MessageBox.Show($@"Ha Ocurrido un Error en Validacion de Integridad IdFactura {f.Value}");
                    }

                    var f140 = db.T0140_MargenOperacion.Where(c => c.IdFactura == f.Value).ToList();
                    if (f140.Count == 0)
                    {
                        MessageBox.Show($@"Atencion no se encuentra la Factura ID: {f.Value} en Tabla Operaciones",
                            @"Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                    
                    //Reparte Informacion en las diferentes lineas de la Factura 
                    decimal importeTotalFactura = f140.Select(c => c.PrecioTotal).Sum();
                    int cantidadLineas = f140.Select(c => c.IdFactura == f.Value).Count();
                    decimal recheckCobrado = 0;
                    foreach (var f2 in f140)
                    {
                        f2.PorcentajeCobrado = rx.PorcPagoTotalArs; //se refiere al % Cobrado ARS productos 
                        decimal porcentajePonderadoLinea = 0;
                        if (importeTotalFactura != 0)
                        {
                            porcentajePonderadoLinea = Math.Round(f2.PrecioTotal / importeTotalFactura,3);
                        }
                        else
                        {
                            porcentajePonderadoLinea = Math.Round((decimal)(1/cantidadLineas),5);
                        }

                        if (f2.MonCosto == "ARS")
                        {
                            f2.PrecioCobradoTotal = Math.Round(rx.ArsCobradoProductos * porcentajePonderadoLinea, 3);
                        }
                        else
                        {
                            f2.PrecioCobradoTotal = Math.Round(rx.UsdCobradoProductos * porcentajePonderadoLinea,3);
                        }
                        f2.MargenOperacionFinal = f2.PrecioCobradoTotal - (f2.Cantidad * f2.CostoTotal);
                        f2.MargenOperaconVentaUnitario = f2.PrecioU - f2.CostoTotal;
                        recheckCobrado += f2.PrecioCobradoTotal;
                    }

                    if (Math.Round(recheckCobrado, 1) != Math.Round(rx.UsdCobradoProductos, 1))
                    {
                        MessageBox.Show($@"Atencion IDFactura {f.Value} -- La Sumatoria de Precios Imputados no Coincide");
                    }
                    db.SaveChanges();
                }
                return true;
            }
        }

        /// <summary>
        /// Mapea el IDFactura y el numero de factura al doucmento de MOP
        /// IdFActura == 0 para ejecutar y relinkear lo que no tenga Link
        /// </summary>
        public void UpdateRemito_FacturaData(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idFactura == 0)
                {
                    var listaFactu = db.T0140_MargenOperacion.Where(c => c.IdFactura == 0).ToList();
                    foreach (var item in listaFactu)
                    {
                        var fact = db.T0400_FACTURA_H.FirstOrDefault(c => c.IDRemito == item.IdRemito);
                        if (fact != null)
                        {
                            item.IdFactura = fact.IDFACTURA;
                            if (item.TipoLX == "L2")
                            {
                                item.FacturaNum = fact.Remito;
                            }
                            else
                            {
                                item.FacturaNum = fact.PV_AFIP + "-" + fact.ND_AFIP;
                            }
                            item.TCFactura = fact.TC;
                            item.FechaFactura = fact.FECHA;
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    //funcion normal a la hora de Contabilizar
                    var fact = db.T0400_FACTURA_H.FirstOrDefault(c => c.IDFACTURA == idFactura);
                    if (fact.IDRemito != null)
                    {
                        var listaRegistros = db.T0140_MargenOperacion.Where(c => c.IdRemito == fact.IDRemito).ToList();
                        foreach (var Item140 in listaRegistros)
                        {
                            Item140.IdFactura = idFactura;
                            if (fact.TIPOFACT == "L2")
                            {
                                Item140.FacturaNum = fact.Remito;
                            }
                            else
                            {
                                Item140.FacturaNum = fact.PV_AFIP + "-" + fact.ND_AFIP;
                            }
                            Item140.TCFactura = fact.TC;
                            Item140.FechaFactura = fact.FECHA;
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        //si IDRemito no esta en T0140 no se puede agergar nada desde esta funcion


                        //if (fact.IdNCD != null)
                        //{
                        //    var listaRegistro = db.T0140_MargenOperacion.Where(c => c.IdRemito == fact.IDRemito)
                        //        .ToList();
                        //    foreach (var Item140 in listaRegistro)
                        //    {
                        //        Item140.IdFactura = idFactura;
                        //        Item140.FacturaNum = fact.NumeroDoc;
                        //        Item140.TCFactura = fact.TC;
                        //        Item140.FechaFactura = fact.FECHA;
                        //        db.SaveChanges();
                        //    }
                        //}
                        //else
                        //{
                        //    //no se cuenta en T0140 con informacion de linkeo IDRemito o IDNcd
                        //}
                    }
                   
                }
            }
        }
        public void AddItemFactura(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var facturaH = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (facturaH.IDRemito == null)
                    return; // no tiene item de remito - no hace nada

                var dataRemitoH = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == facturaH.IDRemito.Value);
                //var dataRemitoI = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
                var facturaI = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
                string tipoRemito = dataRemitoH.TIPO_REMITO;
#pragma warning disable CS0168 // La variable 'monedaCosto' se ha declarado pero nunca se usa
                string monedaCosto;
#pragma warning restore CS0168 // La variable 'monedaCosto' se ha declarado pero nunca se usa
#pragma warning disable CS0168 // La variable 'costoMfg' se ha declarado pero nunca se usa
                decimal costoMfg;
#pragma warning restore CS0168 // La variable 'costoMfg' se ha declarado pero nunca se usa
#pragma warning disable CS0219 // La variable 'costoUnitarioAdicional' está asignada pero su valor nunca se usa
                decimal costoUnitarioAdicional = 0;
#pragma warning restore CS0219 // La variable 'costoUnitarioAdicional' está asignada pero su valor nunca se usa
#pragma warning disable CS0219 // La variable 'costoAdicionalTotal' está asignada pero su valor nunca se usa
                decimal costoAdicionalTotal = 0;
#pragma warning restore CS0219 // La variable 'costoAdicionalTotal' está asignada pero su valor nunca se usa
#pragma warning disable CS0219 // La variable 'costoEstadistico' está asignada pero su valor nunca se usa
                decimal costoEstadistico = 0;
#pragma warning restore CS0219 // La variable 'costoEstadistico' está asignada pero su valor nunca se usa

                foreach (var fitem in facturaI)
                {

                    if (dataRemitoH.RLINK != null)
                    {
                        if (dataRemitoH.TIPO_REMITO == "L2")
                        {
                            //parte L2 de un remito L5
                            //ignorar porque es tenido en cuenta cen parte L1.L5
                        }
                        else
                        {
                            //parte L1 de un remito L5
                            //sumarizar con parte L2 de remito L5
                        }
                    }
                    else
                    {
                        //Operacion L1/L2 pura recorrida por Item Factura
                        var stx = new T0141_MargenVenta()
                        {

                        };
                    }


                    //if (remitoItem.L5.Value == true && remitoItem.LX == "L2")
                    //{
                    //    //El Remito L2 de un L5 no se agrega
                    //}
                    //else
                    //{
                    //    var costoRepo = db.T0035_CostRoll.SingleOrDefault(c => c.Material == remitoItem.MATERIAL);
                    //    if (costoRepo == null)

                }
            }
        }

        /// <summary>
        /// Actualiza el margen T0140 cuando se cambia un costo CR
        /// </summary>
        public void UpdateCostoEnMargen(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var CrGuidActivo = new CostRollManager().GetCostRollHeaderActivo().idCostRoll;

                var data = db.T0140_MargenOperacion.Where(c => c.Material == material && (c.CRVersion == null || c.CRVersion == CrGuidActivo)).ToList();
                foreach (var d in data)
                {
                    if (d.CRVersion == null)
                    {
                        d.CRVersion = CrGuidActivo;
                    }
                    d.CostMapDate = DateTime.Now;
                    var costoRepo = db.T0035_CostRoll.SingleOrDefault(c => c.Material == d.Material);
                    if (costoRepo == null)
                    {
                        d.CostoMfg = GlobalApp.MaxCosto;
                        d.MonCosto = @"USD";
                    }
                    else
                    {
                        d.CostoMfg = costoRepo.CostoCR;
                        d.MonCosto = costoRepo.MonedaCosto;
                    }
                    decimal costoTotalOperacionProporcional = 0;
                    if (d.Cantidad != 0)
                        costoTotalOperacionProporcional = d.CostoTotalAdd / d.Cantidad;
                    d.CostoTotal = d.CostoMfg + d.CostoUAdd + d.CostoStadistico + costoTotalOperacionProporcional;
                    db.SaveChanges();
                    if (d.IdFactura > 0)
                    {
                        UpdateStatusCobranza(d.IdFactura.Value);
                    }
                }
            }
        }

        /// <summary>
        /// 2020.06.30 - Actualiza puntualmente un MOP despues de haber modificado su CR Mfg
        /// </summary>
        public void UpdateMfgCr(int idItem, decimal nuevoCostoMfg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var mop = db.T0140_MargenOperacion.SingleOrDefault(c =>
                   c.IdItem == idItem);
                mop.CostoMfg = nuevoCostoMfg;
                mop.CostoTotal = mop.CostoMfg + mop.CostoStadistico + mop.CostoUAdd +
                                 (mop.CostoTotalAdd / mop.Cantidad);
                mop.MargenOperacionVenta = mop.PrecioTotal - (mop.CostoTotal * mop.Cantidad);
                mop.MargenOperacionFinal = mop.PrecioCobradoTotal - (mop.CostoTotal * mop.Cantidad);
                db.SaveChanges();
            }
        }

        public bool AddMargenDocumentAndMapCostFromOVFsr(List<FsRDataStructure> data, int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataFactura = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                var dataExiste = db.T0140_MargenOperacion.Where(c => c.IdFactura == idFactura).ToList();
                if (dataExiste.Any())
                {
                    db.T0140_MargenOperacion.RemoveRange(dataExiste);
                    db.SaveChanges();
                }

                var crHeader = db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva);

                decimal costoUnitarioAdicional = 0;
                decimal costoAdicionalTotal = 0;
                decimal costoEstadistico = 0;

                foreach (var xdata in data)
                {
                    var ovx = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == xdata.IdOV && c.IDITEM == xdata.IdItem);
                    var costoRepo = db.T0035_CostRoll.SingleOrDefault(c => c.Material == ovx.Material);
                    string monedaCosto;
                    decimal costoMfg;
                    if (costoRepo == null)
                    {
                        costoMfg = GlobalApp.MaxCosto;
                        monedaCosto = "USD";
                    }
                    else
                    {
                        costoMfg = costoRepo.CostoCR;
                        monedaCosto = "USD";
                    }

                    string clienteRs;
                    var clienteData = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == ovx.ClienteRZ);
                    clienteRs = clienteData.cli_rsocial.Length > 30
                        ? clienteData.cli_rsocial.Substring(0, 29)
                        : clienteData.cli_rsocial;

                    decimal costoTotalOperacionProporcional = 0;
                    if (ovx.Cantidad != 0)
                        costoTotalOperacionProporcional = costoAdicionalTotal / ovx.Cantidad;

                    var stx = new T0140_MargenOperacion()
                    {
                        IdRemito = 0,
                        IdItem = 0,
                        RemitoNum = "0000-00000000",
                        Cantidad = ovx.Cantidad,
                        CostoMfg = costoMfg,
                        MonCosto = monedaCosto,
                        CostoStadistico = costoEstadistico,
                        CostoTotalAdd = costoAdicionalTotal,
                        CostoUAdd = costoUnitarioAdicional,
                        CostoTotal = costoMfg + costoEstadistico + costoUnitarioAdicional +
                                     costoTotalOperacionProporcional,
                        FacturaNum = "0000-00000000",
                        FechaFactura = dataFactura.FECHA,
                        FechaRemito = null,
                        TCFactura = 0,
                        TipoLX = dataFactura.TIPOFACT,
                        PrecioU1 = 0,
                        PrecioU2 = 0,
                        PrecioU = 0,
                        PrecioTotal = 0,
                        PorcentajeCobrado = 0,
                        PrecioCobradoTotal = 0,
                        MargenOperacionFinal = 0,
                        MargenOperacionVenta = 0,
                        Material = ovx.Material,
                        IdCliente = ovx.ClienteRZ,
                        ClienteRs = clienteRs,
                        IdFactura = 0,
                        CRVersion = crHeader.idCostRoll,
                        CostMapDate = DateTime.Now,
                        IdClienteEntrega = ovx.T0045_OV_HEADER.CLIENTE.Value
                    };

                    {
                        //No es remito L5 (L1 o L2 puro)
                        if (dataFactura.TIPOFACT == "L1")
                        {
                            stx.PrecioU1 = ovx.PRECIO1;
                        }
                        else
                        {
                            stx.PrecioU2 = ovx.PRECIO2;
                        }
                    }
                    stx.PrecioU = stx.PrecioU1 + stx.PrecioU2;
                    stx.PrecioTotal = stx.PrecioU * stx.Cantidad;
                    stx.MargenOperacionVenta = stx.PrecioTotal - ((stx.Cantidad * stx.CostoTotal) + stx.CostoTotalAdd);
                    db.T0140_MargenOperacion.Add(stx);
                    db.SaveChanges();
                }
            }
            return true;
        }
    }
}
