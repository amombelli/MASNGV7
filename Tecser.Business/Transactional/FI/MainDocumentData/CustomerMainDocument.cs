using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    //2018-03-20 Clase "sub-base" para todos los documentos de Customer (T0400 + T0401)
    //Administra toda la gestion de Factura, Nota Credito, Nota Debito, Ajuste de Clientes
    public abstract class CustomerMainDocument : MainDocumentBase
    {
        protected CustomerMainDocument(string tcode, int idFactura) : base(tcode, idFactura)
        {
            H.IDFACTURA = idFactura; //idFactura = 0 >> aun no existe en T0400.
            base.IdDocument = idFactura;
            if (idFactura > 0)
            {
                LoadDataObject();
            }
        }

        protected T0400_FACTURA_H H = new T0400_FACTURA_H();
        protected List<T0401_FACTURA_I> I = new List<T0401_FACTURA_I>();
        protected int IdFactura { get; private set; } //caducar y acceder a la propiedad del objeto?
        private decimal IdFacturaX { get; set; }
        protected int IdCtaCte { get; set; }
        protected int IdTabla207 { get; set; }
        protected int IdCustomer { get; private set; }
        protected sealed override void LoadDataObject()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                H = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == IdDocument);
                if (H == null)
                    throw new InvalidOperationException("No Existe el registro en T0400*CUSTOMERINVOICE");

                base.TipoLX = H.TIPOFACT;

                I = db.T0401_FACTURA_I.Where(c => c.IDFactura == IdDocument).ToList();
            }
        }
        public T0400_FACTURA_H GetHeaderData()
        {
            return H;
        }
        public List<T0401_FACTURA_I> GetItemData()
        {
            return I.ToList();
        }

        public T0401_FACTURA_I GetItemData(int idItem)
        {
            return I.SingleOrDefault(c => c.IDITEM == idItem);
        }

        //Este metodo es simple porque se envia la menor cantidad de datos y el resto se calcula
        public void AddItemListToMemorySimple(string itemCode, string descripcion, decimal kg, bool iva21,
            string monedaCotizacion, decimal precioUCotiz, decimal precioUFactura, string glI, string glV)
        {
            var d = new T0401_FACTURA_I()
            {
                DESC_REMITO = descripcion,
                ITEM = itemCode,
                IVA21 = iva21,
                MONEDA_COTIZ = monedaCotizacion,
                KGDESPACHADOS_R = kg,
                MONEDA_FACT = this.H.FacturaMoneda,
                TC = this.H.TC,
                PRECIOU_COTIZ = precioUCotiz,
                GLI = glI,
                GLV = glV,
            };
            d.PRECIOT_COTIZ = precioUCotiz * kg;
            if (this.H.FacturaMoneda == @"ARS")
            {
                d.PRECIOU_FACT_ARS = precioUFactura;
                d.PRECIOT_FACT_ARS = precioUFactura * kg;
                d.PRECIOU_FACT_USD = (precioUFactura / d.TC);
                d.PRECIOT_FACT_USD = ((precioUFactura * kg) / d.TC);
            }
            else
            {
                d.PRECIOU_FACT_USD = precioUFactura;
                d.PRECIOT_FACT_USD = precioUFactura * kg;
                d.PRECIOU_FACT_ARS = (precioUFactura * d.TC);
                d.PRECIOT_FACT_ARS = ((precioUFactura * kg) * d.TC);
            }
            this.I.Add(d);
        }

        public void UpdateTipoDocumento(ManageDocumentType.TipoDocumento tipoDoc)
        {
            this.H.TIPO_DOC = ManageDocumentType.GetSystemDocumentType(tipoDoc);
            if (this.IdFactura > 0)
            {

            }
        }

        /// <summary>
        /// Funcion que crea un Header nuevo en memoria con todos los datos
        /// </summary>
        public void CreateNewHeaderInMemory(ManageDocumentType.TipoDocumento tipoDoc, int idCliente,
            DateTime fechaDocumento,
            string tipoLx, decimal exchangeRate, decimal totalBruto = 0, decimal descuento = 0,
            decimal baseImponible = 0, decimal importeIva21 = 0, decimal importeIIBB = 0, decimal importeFinal = 0,
            decimal alicuotaIIBB = 0, string distritoIIBB = null, string moneda = "ARS", int idRemito = 0)
        {
            var x = new T0400_FACTURA_H()
            {
                TIPO_DOC = ManageDocumentType.GetSystemDocumentType(tipoDoc),
                TIPOFACT = tipoLx,
                FECHA = fechaDocumento,
                Cliente = idCliente,
                StatusFactura = DocumentFIStatusManager.StatusHeader.Pendiente.ToString(),
                Impreso = false,
                FacturaMoneda = moneda,
                TC = exchangeRate,
                TotalFacturaB = totalBruto,
                Descuento = descuento,
                TotalImpo = baseImponible,
                TotalIVA21 = importeIva21,
                TotalIIBB = importeIIBB,
                TotalFacturaN = importeFinal,
                IIBB_PORC = alicuotaIIBB,
                IIBB_TXT = distritoIIBB,
                IdCtaCte = null,
                OR = null,
                RE = false,
                ID = null,
            };
            var dataCliente = new CustomerManager().GetCustomerBillToData(idCliente);
            x.RAZONSOC = dataCliente.cli_rsocial;
            x.CUIT = dataCliente.CUIT;
            x.DIRECCION_FAC = dataCliente.Direccion_facturacion;
            x.LOC_FAC = dataCliente.Direfactu_Localidad;

            if (idRemito > 0)
            {
                x.IDRemito = idRemito;
                var r = new TecserData(GlobalApp.CnnApp).T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (r != null)
                    x.Remito = r.NUMREMITO;
            }
            //Campos no mantenidos desde el Inicio
            //IDFACTURAX =,
            //IDFACTURA =,
            //PV_AFIP =,
            //ND_AFIP =,
            //ZTERM =,
            //CAE =,
            //CAE_VTO =,
            //UserLog =,
            // FechaLog =,
            this.H = x;
        }

        public void UpdateTotalesInHeader(int idFactura, decimal exchangeRate, decimal totalBruto = 0,
            decimal descuento = 0,
            decimal baseImponible = 0, decimal importeIva21 = 0, decimal importeIIBB = 0, decimal importeFinal = 0,
            decimal alicuotaIIBB = 0, string distritoIIBB = null, string moneda = "ARS")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (data == null)
                    return;

                data.TC = exchangeRate;
                data.TotalFacturaB = totalBruto;
                data.Descuento = descuento;
                data.TotalImpo = baseImponible;
                data.TotalIVA21 = importeIva21;
                data.TotalIIBB = importeIIBB;
                data.TotalFacturaN = importeFinal;
                data.IIBB_PORC = alicuotaIIBB;
                data.IIBB_TXT = distritoIIBB;
                db.SaveChanges();
            }
        }

        public void AddItemsInMemory(List<T0401_FACTURA_I> items)
        {
            I.Clear();
            I.AddRange(items);
        }

        /// <summary>
        /// Completa datos de NAS en factura
        /// </summary>
        public void CompletaDatosAsiento(int idFactura, int nAsiento, int nasX1X2)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var f = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                f.NAS = nAsiento;
                f.NASX1X2 = nasX1X2;

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Completa datos CAE,Sucursal + Documento
        /// </summary>
        public void CompletaDatosAfip(int idFactura, string numeroCae, DateTime vencimientoCae, string sucursalDocumento,
            string numeroDocumento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var f = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                f.CAE = numeroCae;
                f.CAE_VTO = vencimientoCae;
                f.PV_AFIP = sucursalDocumento;
                f.ND_AFIP = numeroDocumento;

                var item = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
                foreach (var i in item)
                {
                    i.NUMFACTURA = sucursalDocumento + "-" + numeroDocumento;
                }
                db.SaveChanges();
            }
        }

        public static void UpdateInvoiceDataAfterCAEGeneration(int idFactura, string puntoVenta, string numeroDocumento,
            string numeroCae, DateTime fechaVtoCAE)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var item = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
                foreach (var i in item)
                {
                    i.NUMFACTURA = puntoVenta + "-" + numeroDocumento;
                }
                var header = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                header.PV_AFIP = puntoVenta;
                header.ND_AFIP = numeroDocumento;
                header.CAE = numeroCae;
                header.CAE_VTO = fechaVtoCAE;

                db.SaveChanges();
            }
        }

        public string GetNumeroDocumentoCompleto()
        {
            if (TipoLX == "L1")
            {
                switch (StatusDocumento)
                {
                    case DocumentFIStatusManager.StatusHeader.Pendiente:
                        NumeroDocumento = "????-????????";
                        break;
                    case DocumentFIStatusManager.StatusHeader.Registrada:
                        NumeroDocumento = "IDFX-" + H.IDFACTURAX;
                        break;
                    case DocumentFIStatusManager.StatusHeader.Contabilizada:
                        NumeroDocumento = "IDFX-" + H.IDFACTURAX;
                        break;
                    case DocumentFIStatusManager.StatusHeader.Aprobada:
                        NumeroDocumento = H.PV_AFIP + "-" + H.ND_AFIP;
                        break;
                    case DocumentFIStatusManager.StatusHeader.Impresa:
                        NumeroDocumento = H.PV_AFIP + "-" + H.ND_AFIP;
                        break;
                    case DocumentFIStatusManager.StatusHeader.Cancelada:
                        NumeroDocumento = "IDFX-" + H.IDFACTURAX;
                        break;

                    case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                        NumeroDocumento = "IDFX-" + H.IDFACTURAX;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            else
            {
                NumeroDocumento = H.Remito;
            }
            return NumeroDocumento;
        }

        public FacturaId GrabaDocumentoToDatabase()
        {
            var dataReturn = new FacturaId();

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (H.IDFACTURA > 0)
                {
                    var z = db.T0401_FACTURA_I.Where(c => c.IDFactura == H.IDFACTURA).ToList();
                    foreach (var i in z)
                    {
                        db.T0401_FACTURA_I.Remove(i);
                        db.SaveChanges();
                    }
                    db.SaveChanges();
                    var facturaH = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == H.IDFACTURA);

                    if (facturaH != null) db.T0400_FACTURA_H.Remove(facturaH);
                    db.SaveChanges();
                    H.FechaLog = DateTime.Now;
                    H.UserLog = Environment.UserName;
                    db.T0400_FACTURA_H.Add(H);
                }
                else
                {
                    H.IDFACTURA = db.T0400_FACTURA_H.Max(c => c.IDFACTURA) + 1;
                    H.IDFACTURAX = GetNextIdFacturaX(H.TIPOFACT);
                    H.FechaLog = DateTime.Now;
                    H.UserLog = Environment.UserName;
                    db.T0400_FACTURA_H.Add(H);
                }

                if (db.SaveChanges() == 0)
                {
                    dataReturn.IdFacturaX = 0;
                    dataReturn.IdFactura = 0;
                    return dataReturn;
                }

                var numeroItem = 0;

                foreach (var item in I)
                {
                    numeroItem++;
                    item.IDFactura = H.IDFACTURA;
                    item.IDITEM = numeroItem;
                    item.IDFACTURAX = H.IDFACTURAX;
                    db.T0401_FACTURA_I.Add(item);
                }

                if (db.SaveChanges() != numeroItem)
                {
                    //ocurrio un error debiera hacer el rollback del header?
                    dataReturn.IdFacturaX = 0;
                    dataReturn.IdFactura = 0;
                    return dataReturn;
                }
                dataReturn.IdFacturaX = H.IDFACTURAX.Value;
                dataReturn.IdFactura = H.IDFACTURA;
                return dataReturn;
            }
        }

        private int GetNextIdFacturaX(string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var max = db.T0400_FACTURA_H.Where(c => c.TIPOFACT == tipoLx).Max(c => c.IDFACTURAX);
                if (max != null)
                    return (int)max + 1;
                return 1;
            }
        }

        //


        //public CustomerDocumentType TipoDocumento { get; set; }
        protected bool AddRecord208 { get; set; } = false;
        protected bool CheckDocumenInicializationOK()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == IdDocument);
                if (header400 == null)
                    return false;

                if (header400.IDFACTURAX != null) IdFacturaX = header400.IDFACTURAX.Value;
                IdCustomer = header400.Cliente;
                TipoLX = header400.TIPOFACT;
                Moneda = header400.FacturaMoneda;

                if (header400.TC == null || header400.TC == 0)
                {
                    ExchangeRate = 1;
                }
                else
                {
                    ExchangeRate = header400.TC;
                }

                ImporteOri = header400.TotalFacturaN;
                if (ModificaSigno)
                    ImporteOri = ImporteOri * -1;

                ImporteARS = Moneda == "ARS" ? ImporteOri : Math.Round(ImporteOri * ExchangeRate, 2);
                try
                {
                    StatusDocumento = new DocumentFIStatusManager().MapStatusHeaderFromText(header400.StatusFactura);
                    GetNumeroDocumentoCompleto();
                }
                catch (Exception)
                {
                    throw;
                }
                return true;
            }
        }
        protected void AddRecordCtaCteFromFactura(T0400_FACTURA_H facturaH)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                T0201_CTACTE documento201 = new T0201_CTACTE();
                documento201.IDCTACTE = db.T0201_CTACTE.Max(c => c.IDCTACTE) + 1;
                documento201.TDOC = facturaH.TIPO_DOC;
                documento201.IDDOC = IdFactura; //IDCOBRANZA
                documento201.DOC_INTERNO = facturaH.IDFACTURAX.ToString();
                documento201.NUMDOC = NumeroDocumento;
                documento201.Fecha = facturaH.FECHA;
                documento201.IDCLI = facturaH.Cliente;
                documento201.MONEDA = facturaH.FacturaMoneda;
                documento201.TC = facturaH.TC;
                documento201.IMPORTE_ORI = ImporteOri;
                documento201.IMPORTE_ARS = ImporteARS;
                documento201.SALDOFACTURA = ImporteOri;
                documento201.TIPO = facturaH.TIPOFACT;
                documento201.CK = null;
                documento201.CTACTE = 0;
                documento201.IDT1 = IdFactura; //IDFACTURA - IDCOBRANZA
                documento201.IDT2 = facturaH.IDRemito; //IdRemito - IdNCD (FA/ND = IDREMITO -- AJ/NC IDNCD)
                db.T0201_CTACTE.Add(documento201);
                this.IdCtaCte = db.SaveChanges() > 0 ? documento201.IDCTACTE : 0;

                if (IdCtaCte > 0)
                {
                    facturaH.IdCtaCte = IdCtaCte;
                    db.SaveChanges();
                }
            }
        }
        protected void AddRecordTabla207(T0400_FACTURA_H facturaH)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t207 = new T0207_SPLITFACTURAS
                {
                    TDOC = facturaH.TIPO_DOC,
                    IDCTACTE = this.IdCtaCte,
                    IDDOC = facturaH.IDFACTURAX,
                    NDOC = NumeroDocumento,
                    FACTSPLIT = 1,
                    FACT_MONEDA = facturaH.FacturaMoneda,
                    ImporteDocumento = facturaH.TotalFacturaN,
                    ImporteAImputar = facturaH.TotalFacturaN,
                    MontoImputado = 0,
                    TIPO = facturaH.TIPOFACT,
                    CLIENTE = IdCustomer,
                    FECHA_FACT = facturaH.FECHA,
                    ZTERM = null,
                    FECHA_VENC = null,
                    NRECIBO = null,
                    INTDOC = db.T0207_SPLITFACTURAS.Max(c => c.INTDOC) + 1
                };
                db.T0207_SPLITFACTURAS.Add(t207);
                IdTabla207 = db.SaveChanges() > 0 ? t207.INTDOC : 0;
            }
        }
        protected void AddRecordSinImputarT208()
        {
            //todo: REVISAR ESTA FUNCION CUANDO SE IMPLEMENTE!!!!
            //PORQUE SE USA PARA COBRANZA Y PARA NOTA DE CREDITO Y AJUSTE -

            //    var t208 = new T0208_COB_NO_APLICADA();
            //    t208.CLIENTE = IdCustomer;
            //    t208.IDRECIBO = idFactura;
            //    t208.IDNCD = r400.IDRemito; //aca viene el IdNCD desde T400
            //    t208.NRECIBO = numeroDocumento;
            //    t208.FECHA = r400.FECHA;
            //    t208.MONEDA = r400.FacturaMoneda;
            //    t208.MONTO = r400.TotalFacturaN;
            //    t208.TIPOCUENTA = r400.TIPO_DOC;
            //    t208.TIPODOC = "NC";

            //    var id208 = this.SetDataT0208(t208);
            //    if (id208 == 0)
            //    {
            //        //ocurrio un error al dar de alta la CtaCte
            //    }
            //}
        }
        public abstract void CreateItemListFromOV_InMemory(List<FsRDataStructure> data);
        public abstract void CreateItemListFromRemito_InMemory();
        public abstract void RecalcValuesAfterDataChange_InMemory(decimal exchangeRate, decimal porcentajeDescuento,
            decimal alicuotaiIBB);
        public void UpdateHeaderValues(decimal importeBrutoI, decimal importeDescuento, decimal importeImponible, decimal alicuotaPercepcionIIBB, decimal importePercepcionIIBB, decimal exchangeRate, decimal importeNetoFinal, decimal importeIVA21)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == IdDocument);
                try
                {
                    header.TotalFacturaB = importeBrutoI;
                    header.Descuento = importeDescuento;
                    header.TotalImpo = importeImponible;
                    header.IIBB_PORC = alicuotaPercepcionIIBB;
                    header.TotalIIBB = importePercepcionIIBB;
                    header.TC = exchangeRate;
                    header.TotalFacturaN = importeNetoFinal;
                    header.TotalIVA21 = importeIVA21;

                    if (importePercepcionIIBB > 0)
                    {
                        header.IIBB_TXT = @"Perc.IIBB Prov. Bs.As.";
                    }
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw new InvalidDataException("Header No Encontrado");
                }
            }
        }
        public abstract void UpdateItemValues_InMemory(int idItem, string descripcion, decimal nuevoKg, string moneda, decimal nuevoPrecioUnitario);

        public List<T0401_FACTURA_I> InformacionFacturaConsolidada()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataOri = I;
                var resultConsol = from data in dataOri
                                   group data by
                                       new
                                       {
                                           data.GLI,
                                           data.GLV,
                                           data.ITEM,
                                           data.MONEDA_FACT,
                                           data.IVA21,
                                           data.DESC_REMITO,
                                       }
                    into grp
                                   select new T0401_FACTURA_I()
                                   {
                                       GLI = grp.Key.GLI,
                                       GLV = grp.Key.GLV,
                                       ITEM = grp.Key.ITEM,
                                       MONEDA_FACT = grp.Key.MONEDA_FACT,
                                       IVA21 = grp.Key.IVA21,
                                       DESC_REMITO = grp.Key.DESC_REMITO,
                                       KGDESPACHADOS_R = grp.Sum(c => c.KGDESPACHADOS_R.Value),
                                       PRECIOT_FACT_ARS = grp.Sum(c => c.PRECIOT_FACT_ARS),
                                       PRECIOT_FACT_USD = grp.Sum(c => c.PRECIOT_FACT_USD),
                                       PRECIOU_FACT_ARS = grp.Average(c => c.PRECIOU_FACT_ARS),
                                       PRECIOU_FACT_USD = grp.Average(c => c.PRECIOU_FACT_USD),
                                   };
                return (List<T0401_FACTURA_I>)resultConsol.ToList();
            }
        }


        public bool CancelaDocumentoFI(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var f400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (!string.IsNullOrEmpty(f400.CAE))
                {
                    //No hace falta este chequeo porque se valida en FE pero lo hago por las dudas
                    return false;
                }

                //Seteamos documento en estado Cancelada
                f400.StatusFactura = DocumentFIStatusManager.StatusHeader.Cancelada.ToString();
                var idCtaCte = f400.IdCtaCte;
                var idCliente = f400.Cliente;
                var tipoLx = f400.TIPOFACT;

                var t201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                decimal importeAnula = t201.SALDOFACTURA;


                var t202 = db.T0202_CTACTESALDOS.SingleOrDefault(c =>
                    c.IDCLIENTE == idCliente && c.CUENTATIPO == tipoLx);

                if (t202.DEUDA_USD == null)
                    t202.DEUDA_USD = 0;

                if (t202.DEUDA_ARS == null)
                    t202.DEUDA_ARS = 0;
                decimal xrate = new ExchangeRateManager().GetExchangeRate(DateTime.Today);

                //Revertimos el saldo de la CtaCte!
                if (f400.FacturaMoneda == "ARS")
                {
                    t202.DEUDA_ARS = t202.DEUDA_ARS.Value - importeAnula;
                }
                else
                {
                    t202.DEUDA_USD = t202.DEUDA_USD.Value - importeAnula;
                }
                t202.DEUDA_TOT_ARS = t202.DEUDA_ARS + (t202.DEUDA_USD * xrate);
                //Eliminamos registro en T0201
                db.T0201_CTACTE.Remove(t201);


                //Si es NC esta en T0208 - Eliminamos
                var t208 = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                if (t208 != null)
                    db.T0208_COB_NO_APLICADA.Remove(t208);

                //Remueve T0207 - Imputaciones
                var t207 = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtaCte).ToList();
                foreach (var i in t207)
                {
                    db.T0207_SPLITFACTURAS.Remove(i);

                }

                var x = new AsCustomerDocument(idFactura, "FAC2").ReversaAsiento(f400.NAS.Value, "Cancelacion de Documento");
                return db.SaveChanges() > 0;

            }
        }












    }
}
