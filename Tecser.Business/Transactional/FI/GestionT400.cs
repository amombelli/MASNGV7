using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class GestionT400
    {

        /// <summary>
        /// Constructor default sin paramatros
        /// </summary>
        public GestionT400()
        {
            
        }

        /// <summary>
        /// Constructor para Load Data (sin uso por el momento)
        /// </summary>
        public GestionT400(int idFactura400)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _id400 = idFactura400;
                H4 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura400);
                I4 = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura400).ToList();
                Status = new DocumentFIStatusManager().MapStatusHeaderFromText(H4.StatusFactura);
                _tipoDocumento = ManageDocumentType.GetTipoDocumentoFromTdocString(H4.TIPO_DOC, H4.TIPOFACT);

                if (_tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVenta2 ||
                    _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA)
                {
                    _signo = -1;
                }
                else
                {
                    _signo = -1;
                }
            }
        }
        public T0400_FACTURA_H H4 { get; private set; } = new T0400_FACTURA_H();
        public List<T0401_FACTURA_I> I4 { get; private set; } = new List<T0401_FACTURA_I>();
        public DocumentFIStatusManager.StatusHeader Status { get; private set; }
        private ManageDocumentType.TipoDocumento _tipoDocumento;
        private int _id400;
        private TotalesCustomerFi _totales=new TotalesCustomerFi();
        private int _signo;
        private string _tipoDocumentoXx;
        private string _sucursalTemporal; //sucursal temporal que se asigna por TDOC al registrar
        private string _tipoLx;
        
        public bool AllowToRegister()
        {
            if (Status ==DocumentFIStatusManager.StatusHeader.Pendiente)
                return true;
            return false;
        }
        public bool AllowToUnregister()
        {
            if (Status ==DocumentFIStatusManager.StatusHeader.Registrada)
                return true;
            return false;
        }

        public void AddHeaderMemory(ManageDocumentType.TipoDocumento tipoDocumento, int idCliente, string lx, DateTime fechaDoc, decimal tc, string zterm, string glAR,bool impactaVentas, int? idRemito, string monedaDoc="ARS")
        {
            _signo = 1;  //signo default;
            _tipoDocumento = tipoDocumento;
            _tipoDocumentoXx = ManageDocumentType.GetSystemDocumentType(tipoDocumento);  //tipo documento XX (FA)
            _sucursalTemporal = "XXXX";
            _tipoLx = lx;
            //Acciones especificas y/o signos de documentos
            switch (tipoDocumento)
            {
                case ManageDocumentType.TipoDocumento.FacturaVentaA:
                    _sucursalTemporal = "AFIP";
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoVentaA:
                    _sucursalTemporal = "AFIP";
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoVentaA:
                    _sucursalTemporal = "AFIP";
                    break;
                case ManageDocumentType.TipoDocumento.ReciboCobranza:
                    break;
                case ManageDocumentType.TipoDocumento.Remito:
                    break;
                case ManageDocumentType.TipoDocumento.OrdenPago:
                    break;
                case ManageDocumentType.TipoDocumento.OrdenCompra:
                    break;
                case ManageDocumentType.TipoDocumento.NoDefinido:
                    break;
                case ManageDocumentType.TipoDocumento.FacturaVenta2:
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoVenta2:
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoVenta2:
                    break;
                case ManageDocumentType.TipoDocumento.TransferenciaEC:
                    break;
                case ManageDocumentType.TipoDocumento.Cobranza:
                    break;
                case ManageDocumentType.TipoDocumento.FacturaGastosConRemito:
                    break;
                case ManageDocumentType.TipoDocumento.FacturaGastosSinRemito:
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoProveedorA:
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoProveedorA:
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoProveedor2:
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoProveedor2:
                    break;
                case ManageDocumentType.TipoDocumento.AjusteSaldoPositivo:
                    break;
                case ManageDocumentType.TipoDocumento.AjusteSaldoNegativo:
                    break;
                case ManageDocumentType.TipoDocumento.FacturaVentaB:
                    _sucursalTemporal = "AFIP";
                    break;
                case ManageDocumentType.TipoDocumento.FacturaVentaM:
                    _sucursalTemporal = "AFIP";
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoClientesB:
                    _sucursalTemporal = "AFIP";
                    break;
                case ManageDocumentType.TipoDocumento.NotaCreditoClientesM:
                    _sucursalTemporal = "AFIP";
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoClientesB:
                    _sucursalTemporal = "AFIP";
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoClientesM:
                    _sucursalTemporal = "AFIP";
                    break;
                case ManageDocumentType.TipoDocumento.AjusteContable:
                    break;
                case ManageDocumentType.TipoDocumento.DebitoNoFiscalCli:
                    _sucursalTemporal = _tipoLx == "L1" ? "1111" : "XXXX";
                    _signo = 1;
                    break;
                case ManageDocumentType.TipoDocumento.CreditoNoFiscalCli:
                    _sucursalTemporal = _tipoLx == "L1" ? "1111" : "XXXX";
                    _signo = -1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoDocumento), tipoDocumento, null);
            }

            var cli = new CustomerManager().GetCustomerBillToData(idCliente);
            H4 = new T0400_FACTURA_H()
            {
                TIPO_DOC = _tipoDocumentoXx,
                Anulado = false,
                Impreso = false,
                IDFACTURA = -1,
                NumeroDoc = null,
                CAE = null,
                CAE_VTO = null,
                CUIT = cli.CUIT,
                Cliente = idCliente,
                DIRECCION_FAC = cli.Direccion_facturacion,
                LOC_FAC = cli.Direfactu_Localidad,
                RAZONSOC = cli.cli_rsocial,
                TC = tc,
                FacturaMoneda = monedaDoc,
                FECHA = fechaDoc,
                TIPOFACT = lx,
                FsrId = null,
                GLAR = glAR,
                IDRemito = idRemito,
                ImpactaVentas = impactaVentas,
                StatusFactura = Status.ToString(),
                ZTERM = zterm,
                //inicializa totales
                TotalFacturaB = 0,
                Descuento = 0,
                DescuentoPorc = 0,
                TotalIVA21 = 0,
                IIBB_PORC = 0,
                TotalIIBB = 0,
                Tax2Alicuota = 0,
                Tax2Importe = 0,
                Tax2Descripcion = "N/D",
                TotalFacturaN = 0,
                IIBB_TXT = "N/D",
                IdNCD = null,
                TotalImpo = 0,
                IDFACTURAX = -1,
            };
        }
        public void AddItemsMemory(string item, string itemDescripcion, decimal cantidad, string monedaCotizacion,
            decimal precioUnitarioCotizacion, string glV, string glI, bool iva21, decimal costoStd, int? fsrOv, int? fsrOVItem,
            decimal? precioUMonedaFactura = null)
        {

            if (cantidad == 0)
                cantidad = 1;

            if (string.IsNullOrEmpty(glV))
                glV = "0.0.0.0";

            if (string.IsNullOrEmpty(glI))
                glI = "0.0.0.0";

            var i = new T0401_FACTURA_I()
            {
                IDITEM = I4.Count+1,
                ITEM = item,
                DESC_REMITO = itemDescripcion,
                KGDESPACHADOS_R = cantidad,
                MONEDA_FACT = H4.FacturaMoneda,
                MONEDA_COTIZ = monedaCotizacion,
                PRECIOU_COTIZ = precioUnitarioCotizacion,
                PRECIOT_COTIZ = Math.Round(precioUnitarioCotizacion * cantidad,3),
                TC = H4.TC,
                IVA21 = iva21,
                CostoStd = costoStd,
                FsrOV = fsrOv,
                FsrOVItem = fsrOVItem,
                GLI = glI,
                GLV = glV
            };

            if (H4.FacturaMoneda == "ARS")
            {
                if (precioUMonedaFactura == null)
                {
                    //el PU-Fact no se provee - se calcula
                    if (monedaCotizacion == "USD")
                    { 
                        i.PRECIOU_FACT_ARS = Math.Round(precioUnitarioCotizacion * H4.TC, 3);
                        i.PRECIOU_FACT_USD = precioUnitarioCotizacion;
                        i.PRECIOT_FACT_ARS = precioUnitarioCotizacion * cantidad;
                        i.PRECIOT_FACT_USD = Math.Round(precioUnitarioCotizacion / H4.TC * cantidad, 3);
                    }
                    else
                    {
                        //moneda de cotizacion es ARS
                        i.PRECIOU_FACT_USD = Math.Round(precioUnitarioCotizacion / H4.TC, 3);
                        i.PRECIOU_FACT_ARS = precioUnitarioCotizacion;
                        i.PRECIOT_FACT_ARS = precioUnitarioCotizacion * cantidad;
                        i.PRECIOT_FACT_USD = Math.Round(precioUnitarioCotizacion / H4.TC * cantidad, 3);
                    }
                }
                else
                {
                    //el PU-Fact se provee -- esta opcion es rara poque se cotiza en USD y se factura el TC
                    i.PRECIOU_FACT_ARS = precioUMonedaFactura.Value;
                    i.PRECIOU_FACT_USD = Math.Round(precioUMonedaFactura.Value / H4.TC, 3);
                    i.PRECIOT_FACT_USD = Math.Round(precioUMonedaFactura.Value / H4.TC*cantidad, 3);
                    i.PRECIOT_FACT_ARS = precioUMonedaFactura.Value *cantidad;
                }
            }
            else
            {
                //Factura es en USD
                if (monedaCotizacion == "USD")
                {
                    //moneda de cotizacion es en USD
                }
                else
                {
                    //moneda de cotizacion es ARS
                }
            }
            I4.Add(i);
            MapImportesCalculadaosToH4();
        }
        
        /// <summary>
        /// Actualiza Parametros Factura y Recalcula Importes
        /// </summary>
        public void UpdateParamentrosFactura(decimal tc, decimal descuentoPorc, decimal descuento, decimal alicuotaIb, decimal alicuotaTax2)
        {
            H4.TC = tc;
            foreach (var i in I4)
            {
                i.TC = tc;
                if (i.MONEDA_COTIZ == "USD")
                {
                    //moneda de cotizacion USD
                    i.PRECIOU_FACT_ARS = Math.Round(i.PRECIOU_COTIZ * tc, 3);
                    i.PRECIOT_FACT_ARS = Math.Round(i.PRECIOT_COTIZ * tc, 3);
                }
                else
                {
                    //moneda de cotizacion = ARS
                    i.PRECIOU_FACT_USD = Math.Round(i.PRECIOU_COTIZ / tc, 3);
                    i.PRECIOT_FACT_USD = Math.Round(i.PRECIOT_COTIZ / tc, 3);
                }
            }
            H4.DescuentoPorc = descuentoPorc;
            H4.Descuento = descuento;
            H4.Tax2Alicuota = alicuotaTax2;
            H4.IIBB_PORC = alicuotaIb;
            MapImportesCalculadaosToH4();
        }
        /// <summary>
        /// Mapea en la estructura TotalesCustomerFI los valores de H4
        /// </summary>
        public TotalesCustomerFi MapH4ImportesToImportes()
        {
            _totales.MapImportesFrom400Header(H4);
            return _totales;
        }
        
        /// <summary>
        /// Calcula los Importes desde los Items y los mapea en H4 Header
        /// </summary>
        private void MapImportesCalculadaosToH4()
        {
            if (H4.IIBB_PORC == null)
                H4.IIBB_PORC = 0;

            if (H4.Descuento == null)
                H4.Descuento = 0;

            if (H4.DescuentoPorc == null)
                H4.DescuentoPorc = 0;

            _totales.CalculaTotalesFromItems(I4, H4.IIBB_PORC.Value,H4.Descuento.Value,H4.DescuentoPorc.Value,H4.Tax2Alicuota);
            H4.TotalFacturaB = _totales.Bruto;
            H4.Descuento = _totales.Descuento;
            H4.TotalImpo = _totales.BaseImponible;
            H4.TotalIVA21 = _totales.Iva21;
            H4.IIBB_PORC = _totales.AlicuotaIIBB;
            H4.TotalIIBB = _totales.IIBB;
            H4.TotalFacturaN = _totales.TotalFinal;
            H4.DescuentoPorc = _totales.PorcentajeDescuento;
            H4.Tax2Importe = _totales.Tax2;
            H4.Tax2Alicuota = _totales.AlicuotaTax2;
        }

        public TotalesCustomerFi MapImportesFromItems()
        {
            MapImportesCalculadaosToH4();
            _totales.MapImportesFrom400Header(H4);
            return _totales;
        }
        
        /// <summary>
        /// Funcion para Grabar en DB el registro de memoria
        /// </summary>
        public int Registrar(bool usarValorAbsoluto)
        {
            if (!AllowToRegister())
                return -1;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                    if (H4.IDFACTURA > 0)
                    {
                        //Si IDfactura es >0 => Ya tiene Asignado un ID --> Elimino datos Existentes en T400
                        var z = db.T0401_FACTURA_I.Where(c => c.IDFactura == H4.IDFACTURA).ToList();
                        foreach (var i in z)
                        {
                            db.T0401_FACTURA_I.Remove(i);
                            db.SaveChanges();
                        }
                        var facturaH = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == H4.IDFACTURA);
                        if (facturaH != null) db.T0400_FACTURA_H.Remove(facturaH);
                        db.SaveChanges();
                        Status = DocumentFIStatusManager.StatusHeader.Registrada;
                        H4.StatusFactura = Status.ToString();
                        H4.FechaLog = DateTime.Now;
                        H4.UserLog = Environment.UserName;
                        //Colocamos siempre el valor absoluto en DB
                        if (usarValorAbsoluto)
                        {
                            H4.TotalFacturaB = Math.Abs(H4.TotalFacturaB);
                            H4.TotalImpo = Math.Abs(H4.TotalImpo);
                            H4.TotalIVA21 = Math.Abs(H4.TotalIVA21);
                            H4.TotalIIBB = Math.Abs(H4.TotalIIBB);
                            H4.TotalFacturaN = Math.Abs(H4.TotalFacturaN);
                            H4.Tax2Importe = Math.Abs(H4.Tax2Importe);
                            if (H4.Descuento < 0) H4.Descuento = H4.Descuento * -1;
                        }
                        else
                        {
                            //utiliza los valors con signo 
                            //nuevo approach
                        }
                        db.T0400_FACTURA_H.Add(H4);
                    }
                    else
                    {
                        //Aisgna un ID400
                        H4.IDFACTURA = db.T0400_FACTURA_H.Max(c => c.IDFACTURA) + 1;
                        H4.IDFACTURAX = GetNextIdFacturaX();
                        H4.FechaLog = DateTime.Now;
                        H4.UserLog = Environment.UserName;
                        H4.StatusFactura = DocumentFIStatusManager.StatusHeader.Registrada.ToString();
                        H4.PV_AFIP = AsignaSucursalTemporal();
                        H4.ND_AFIP = AsignaNumeroTemporal();
                        H4.NumeroDoc = H4.PV_AFIP + "-" + H4.ND_AFIP;
                        H4.Anulado = false;
                        db.T0400_FACTURA_H.Add(H4);
                        if (db.SaveChanges() == 0)
                        {
                            _id400 = -1;
                            Status = DocumentFIStatusManager.StatusHeader.Pendiente;
                        }
                        else
                        {
                            _id400 = H4.IDFACTURA;
                            Status = DocumentFIStatusManager.StatusHeader.Registrada;
                        }
                        //Colocamos siempre el valor absoluto en DB
                        if (usarValorAbsoluto)
                        {
                            H4.TotalFacturaB = Math.Abs(H4.TotalFacturaB);
                            H4.TotalImpo = Math.Abs(H4.TotalImpo);
                            H4.TotalIVA21 = Math.Abs(H4.TotalIVA21);
                            H4.TotalIIBB = Math.Abs(H4.TotalIIBB);
                            H4.TotalFacturaN = Math.Abs(H4.TotalFacturaN);
                            H4.Tax2Importe = Math.Abs(H4.Tax2Importe);
                            if (H4.Descuento < 0) H4.Descuento = H4.Descuento * -1;
                        }
                        else
                        {
                            //utiliza los valors con signo 
                            //nuevo approach
                        }
                    }
                    var numeroItem = 0;
                    var _c = db.T0401_FACTURA_I.Where(c => c.IDFactura == H4.IDFACTURA).ToList();
                    if (_c.Any())
                    {
                        db.T0401_FACTURA_I.RemoveRange(_c);
                        db.SaveChanges();
                    }

                    foreach (var item in I4)
                    {
                        numeroItem++;
                        item.IDFactura = H4.IDFACTURA;
                        item.IDITEM = numeroItem;
                        item.IDFACTURAX = H4.IDFACTURAX;
                        //Colocamos valor Absoluto en los items -- solo dejamos la cantidad con signo
                        if (usarValorAbsoluto)
                        {
                            item.PRECIOU_COTIZ = Math.Abs(item.PRECIOU_COTIZ);
                            item.PRECIOT_COTIZ = Math.Abs(item.PRECIOT_COTIZ);
                            item.PRECIOU_FACT_ARS = Math.Abs(item.PRECIOU_FACT_ARS);
                            item.PRECIOT_FACT_ARS = Math.Abs(item.PRECIOT_FACT_ARS);
                            item.PRECIOU_FACT_USD = Math.Abs(item.PRECIOU_FACT_USD);
                            item.PRECIOT_FACT_USD = Math.Abs(item.PRECIOT_FACT_USD);
                        }
                        else
                        {
                            //dejamos los valores con el signo correspondiente
                        }
                    }
                    db.T0401_FACTURA_I.AddRange(I4);
                    db.SaveChanges();
                    H4.StatusFactura = Status.ToString();
                    return H4.IDFACTURA;
            }
        }
        public void UnRegistrar()
        {

        }
        
        /// <summary>
        /// Popula el IDNCD en T400
        /// </summary>
        public void UpdateIdNcd(int idncd)
        {
            H4.IdNCD = idncd;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _id400);
                d.IdNCD = idncd;
                db.SaveChanges();
            }
        }
        private int GetNextIdFacturaX()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var max = db.T0400_FACTURA_H.Where(c => c.TIPOFACT == _tipoLx).Max(c => c.IDFACTURAX);
                if (max != null)
                    return (int) max + 1;
                return 1;
            }
        }

        /// <summary>
        /// funcion Fake de paso por si acaso hay que cambiar algo en el futuro
        /// </summary>
        private string AsignaSucursalTemporal()
        {
            return _sucursalTemporal;
        }
        private string AsignaNumeroTemporal()
        {
            return H4.IDFACTURA.ToString("D8");
        }
    }
}
