using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class Totales
    {
        public decimal Bruto { get; private set; }
        public decimal Descuento { get; private set; }
        public decimal PorcentajeDescuento { get; private set; }
        public decimal Subtotal { get; private set; }
        public decimal BaseImponible { get; private set; }
        public decimal NoImponible { get; private set; }
        public decimal Iva21 { get; private set; }
        public decimal AlicuotaIIBB { get; private set; }
        public decimal IIBB { get; private set; }
        public decimal TotalImpuestos { get; private set; }
        public decimal TotalFinal { get; private set; }
        public bool OK;

        /// <summary>
        /// Mapea los Importes desde el Header ya calculado a la estructura
        /// </summary>
        public void MapImportesFrom400Header(T0400_FACTURA_H h)
        {
            OK = false;
            Bruto = h.TotalFacturaB;
            Descuento = h.Descuento ?? 0;
            if (Bruto == 0)
            {
                PorcentajeDescuento = 0;
                Subtotal = 0;
                NoImponible = 0;
                BaseImponible = 0;
            }
            else
            {
                PorcentajeDescuento = Descuento / Bruto;
                Subtotal = Bruto - Descuento;
                BaseImponible = BaseImponible;
                NoImponible = Subtotal - BaseImponible;
                Iva21 = h.TotalIVA21;
            }

            AlicuotaIIBB = h.IIBB_PORC ?? 0;
            IIBB = h.TotalIIBB;
            TotalImpuestos = Iva21 + IIBB;
            TotalFinal = h.TotalFacturaN;
            if (h.TotalFacturaN == (Subtotal + Iva21 + IIBB))
                OK = true;
        }
        


        /// <summary>
        /// Calcula y Mapea los importes desde los Items
        /// </summary>
        public void MapImportesFromItems400(List<T0401_FACTURA_I> items, decimal alicuotaIIBB = 0,
            decimal descuentoImporte = 0, decimal descuentoPorcentaje = 0)
        {
            decimal baseImpo = 0;
            decimal importeBruto = 0;
            foreach (var i in items)
            {
                if (i.MONEDA_FACT == "ARS")
                {
                    if (i.IVA21)
                    {
                        baseImpo += i.PRECIOT_FACT_ARS;
                    }

                    importeBruto += i.PRECIOT_FACT_ARS;
                }
                else
                {
                    //calculo en moneda de facturacion USD
                    if (i.IVA21)
                    {
                        baseImpo += i.PRECIOT_FACT_USD;
                    }

                    importeBruto += i.PRECIOT_FACT_USD;
                }
            }

            Bruto = importeBruto;
            //Manejo de Descuento
            if (descuentoImporte != 0 || descuentoPorcentaje != 0)
            {
                //Tiene prioridad el porcentaje al valor
                if (descuentoPorcentaje != 0)
                {
                    Descuento = Math.Round(Bruto * descuentoPorcentaje, 2);
                    PorcentajeDescuento = descuentoPorcentaje;
                }
                else
                {
                    //descuento por monto fijo
                    Descuento = descuentoImporte;
                    PorcentajeDescuento = Math.Round(descuentoImporte / Bruto, 4);
                }
            }

            Subtotal = Bruto - Descuento;
                decimal porcentajeImponibleAntesDescuento = Math.Round(baseImpo / Bruto, 4);
                BaseImponible = Math.Round(Subtotal * porcentajeImponibleAntesDescuento, 2);
                NoImponible = Subtotal - BaseImponible;
                Iva21 = Math.Round(BaseImponible * (decimal) 0.21, 2);
                AlicuotaIIBB = Math.Round(alicuotaIIBB, 4);
                IIBB = Math.Round(baseImpo * AlicuotaIIBB, 2);
                TotalImpuestos = Iva21 + IIBB;
                TotalFinal = Subtotal + TotalImpuestos;
                OK = true;
  
        }



        /// <summary>
        /// Funcion que mapea todos los importes en ARS
        /// </summary>
        public void MapImportesFromItems301_PlusImpuestos(List<T0301_NCD_I> items, decimal tc,decimal alicuotaIIBB = 0,
            decimal descuentoImporte = 0, decimal descuentoPorcentaje = 0)
        {
            decimal baseImpoArs = 0;
            decimal importeBruto = 0;
            foreach (var i in items)
            {
                if (i.MON == "ARS")
                {
                    if (i.IVA21)
                    {
                        baseImpoArs += i.PTOTAL;
                    }
                    importeBruto += i.PTOTAL;
                }
                else
                {
                    //calculo en moneda de facturacion USD
                    if (i.IVA21)
                    {
                        baseImpoArs += i.PTOTAL*tc;
                    }
                    importeBruto += i.PTOTAL*tc;
                }
            }
            Bruto = importeBruto;
            //Manejo de Descuento
            if (descuentoImporte != 0 || descuentoPorcentaje != 0)
            {
                //Tiene prioridad el porcentaje al valor
                if (descuentoPorcentaje != 0)
                {
                    Descuento = Math.Round(Bruto * descuentoPorcentaje, 2);
                    PorcentajeDescuento = descuentoPorcentaje;
                }
                else
                {
                    //descuento por monto fijo
                    Descuento = descuentoImporte;
                    PorcentajeDescuento = Math.Round(descuentoImporte / Bruto, 4);
                }
            }

            Subtotal = Bruto - Descuento;
            decimal porcentajeImponibleAntesDescuento = Math.Round(baseImpoArs / Bruto, 4);
            BaseImponible = Math.Round(Subtotal * porcentajeImponibleAntesDescuento, 2);
            NoImponible = Subtotal - BaseImponible;
            Iva21 = Math.Round(BaseImponible * (decimal)0.21, 2);
            AlicuotaIIBB = Math.Round(alicuotaIIBB, 4);
            IIBB = Math.Round(baseImpoArs * AlicuotaIIBB, 2);
            TotalImpuestos = Iva21 + IIBB;
            TotalFinal = Subtotal + TotalImpuestos;
            OK = true;
        }
    }
    
    /// <summary>
    /// Nueva Clase de Gestion de Notas de Debito 2021.07.10
    /// </summary>

    public class CustomerNc:CustomerDoc
    {
        public CustomerNc(MotivoNotaCredito xmotivo)
        {
            T400= new GestionT400(GestionT400.SignoRegistracion.Negativo);
            _motivoDocumento = xmotivo;
            motivoDocumentoString = xmotivo.ToString();
        }

        public CustomerNc()
        {
            //usado para funcion MAP-
        }

        public CustomerNc(int idFactura)
        {
            //hacer constructor - para 
            //todo: hacer en conjunto con customernd
        }

        
        public enum MotivoNotaCredito
        {
            AnulaDocumento,
            DiferenciaPrecio,
            DiferenciaCambio,
            DiferenciaKg,
            DevolucionMaterial,
            DesGeneralDocumentos,
            DesGeneralPeriodo,
            SinMotivo
        };
        public MotivoNotaCredito MapMotivoFromTextoToType(string motivo)
        {
            if (String.IsNullOrEmpty(motivo))
                return MotivoNotaCredito.SinMotivo;
            try
            {
                return (MotivoNotaCredito)Enum.Parse(typeof(MotivoNotaCredito), motivo, true);
            }
            catch (Exception)
            {
                return MotivoNotaCredito.SinMotivo;
                throw;
            }
        }
        private MotivoNotaCredito _motivoDocumento;
        
        /// <summary>
        /// De acuerdo a <ITEM> se puede manejar la descripción que va a salir
        /// 
        /// </summary>
        public void AnulaDocumentoCompleto(int idDocumentoOrigen)
        {
            //primero Crear Header
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var docOri = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idDocumentoOrigen);
                var itemOri = db.T0401_FACTURA_I.Where(c => c.IDFactura == idDocumentoOrigen).ToList();

                SetDocumentoAsociado(idDocumentoOrigen);
                T300.H3.IdMotivoAsociado = IdFacturaAsociada;
                
                foreach (var it in itemOri)
                {
                    //Una anulacion de NC con ND se toma como si la cotizacion hubiese sido en pesos y se recalcula el valor USD segun el TC del día de la fecha de emision de ND
                    string itemDescOri = it.DESC_REMITO;
                    string newDescription;
                    string item = it.ITEM;
                    if (it.ITEM == "DESCGRAL")
                    {
                        newDescription = "Anulacion #" + itemDescOri + $"# NC {docOri.NumeroDoc}";
                    }
                    else
                    {
                        if (itemDescOri.StartsWith("**") || itemDescOri.StartsWith("##"))
                        {
                            itemDescOri = itemDescOri.Substring(2);
                            newDescription = "*" + itemDescOri;
                        }
                        else
                        {
                            if (itemDescOri.StartsWith("*") || itemDescOri.StartsWith("#"))
                            {
                                itemDescOri = itemDescOri.Substring(1);
                                newDescription = "%" + itemDescOri;
                            }
                            else
                            {
                                newDescription = $"* Anulacion {it.DESC_REMITO}";
                                item = it.ITEM;
                            }
                        }
                    }

                    //validacion de longitud de descripcion
                    var descripcionLen = newDescription.Length;
                    if (descripcionLen >= 199)
                    {
                        newDescription = newDescription.Substring(0, 199);
                    }

                    //Documento de contrapartida cambia siempre el signo 
                    decimal cantidadI = it.KGDESPACHADOS_R.Value;
                    if (cantidadI == 0) cantidadI = 1;
                    cantidadI = cantidadI * -1;
                    
                    T400.AddItemsMemory(item, newDescription, cantidadI, "ARS", it.PRECIOU_FACT_ARS, it.GLV, it.GLI,
                        it.IVA21, it.CostoStd, null, null, null);

                }

                //Luego de Agregar Items - Coloca exacto los importes del documento original
                T400.H4.Descuento = docOri.Descuento;
                T400.H4.DescuentoPorc = docOri.DescuentoPorc;
                T400.H4.TotalFacturaB = docOri.TotalFacturaB;
                T400.H4.TotalImpo = docOri.TotalImpo;
                T400.H4.TotalIVA21 = docOri.TotalIVA21;
                T400.H4.TotalIIBB = docOri.TotalIIBB;
                T400.H4.TotalFacturaN = docOri.TotalFacturaN;
                T400.H4.IIBB_PORC = docOri.IIBB_PORC;
                T400.H4.IIBB_TXT = docOri.IIBB_TXT;
                T400.H4.Tax2Alicuota = docOri.Tax2Alicuota;
                T400.H4.Tax2Descripcion = docOri.Tax2Descripcion;
                T400.H4.Tax2Importe = docOri.Tax2Importe;
                T400.MapH4ImportesToImportes();
            }
        }

       




        //Fin de Revision

        public T0400_FACTURA_H H4 = new T0400_FACTURA_H();
        public List<T0401_FACTURA_I> I4 = new List<T0401_FACTURA_I>();
        public T0300_NCD_H H3 = new T0300_NCD_H();
        public List<T0301_NCD_I> I3 = new List<T0301_NCD_I>();
        private Totales _total = new Totales();
       
        private DocumentFIStatusManager.StatusHeader _status400;
        
        
        /// <summary>
        /// Copia datos basicos de la factura enviada
        /// Blanquea Importes a 0.- + ID a 0
        /// Asigna mismo TC y mismo numero Remito
        /// </summary>
        private void CreaT400HeaderBasadoEnDocumentoExistente(int idFacturaACopiar, string TdocAGenerar)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _status400 = DocumentFIStatusManager.StatusHeader.Pendiente;
                var h = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFacturaACopiar);
                H4 = new T0400_FACTURA_H
                {
                    TIPO_DOC = TdocAGenerar,
                    TIPOFACT = h.TIPOFACT, //LX
                    FECHA = DateTime.Today,
                    Cliente = h.Cliente,
                    RAZONSOC = h.RAZONSOC,
                    CUIT = h.CUIT,
                    DIRECCION_FAC = h.DIRECCION_FAC,
                    LOC_FAC = h.LOC_FAC,
                    StatusFactura = DocumentFIStatusManager.StatusHeader.Pendiente.ToString(),
                    Impreso = false,
                    FacturaMoneda = h.FacturaMoneda,
                    TC = h.TC,
                    Remito = h.Remito,
                    //
                    TotalFacturaB = 0,
                    Descuento = 0,
                    TotalImpo = 0,
                    TotalIVA21 = 0,
                    TotalIIBB = 0,
                    TotalFacturaN = 0,
                    IIBB_PORC = 0,
                    RE = h.RE,
                    DescuentoPorc = 0,
                    IDFACTURA = 0,
                    IDFACTURAX = null,
                    PV_AFIP = null,
                    ND_AFIP = null,
                    FechaLog = DateTime.Now,
                    UserLog = GlobalApp.AppUsername,
                };
                AsignaNumeroDocumentoTemporal();
            }
        }

        private void AsignaNumeroDocumentoTemporal()
        {
            if (H4 != null)
            {
                if (H4.TIPOFACT == "L1")
                {
                    H4.NumeroDoc = "AFIP" + "-" + H4.IDFACTURA.ToString("D8");
                }
                else
                {
                    H4.NumeroDoc = "MOMB" + "-" + H4.IDFACTURA.ToString("D8");
                }

                foreach (var I in I4)
                {
                    I.NUMFACTURA = H4.NumeroDoc;
                }

                if (H3 != null)
                {
                    H3.NDOC = H4.NumeroDoc;
                }

                foreach (var i in I3)
                {
                    i.NDOC = H4.NumeroDoc;
                }
            }
            else
            {
                //Arranca por header NC - asigna primero aca??
            }
        }

        /// <summary>
        /// Inicializa un Header T400 con los datos basicos del Cliente - LX
        /// </summary>
        private void InicializaHeaderT400_BasicCustomer(int idCliente, string tdocAGenerar, string lx, DateTime fechaDocumento,decimal tc, string facturaMoneda="ARS")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _status400 = DocumentFIStatusManager.StatusHeader.Pendiente;
                var cli = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);
                H4 = new T0400_FACTURA_H
                {
                    TIPO_DOC = tdocAGenerar,
                    TIPOFACT = lx,
                    FECHA = fechaDocumento,
                    Cliente = idCliente,
                    RAZONSOC = cli.cli_rsocial,
                    CUIT = cli.CUIT,
                    DIRECCION_FAC = cli.Direccion_facturacion,
                    LOC_FAC = cli.Direfactu_Localidad,
                    StatusFactura = DocumentFIStatusManager.StatusHeader.Pendiente.ToString(),
                    Impreso = false,
                    FacturaMoneda = facturaMoneda,
                    TC = tc,
                    Remito = null,
                    //
                    TotalFacturaB = 0,
                    Descuento = 0,
                    TotalImpo = 0,
                    TotalIVA21 = 0,
                    TotalIIBB = 0,
                    TotalFacturaN = 0,
                    IIBB_PORC = 0,
                    RE = true,
                    DescuentoPorc = 0,
                    IDFACTURA = 0,
                    IDFACTURAX = null,
                    PV_AFIP = null,
                    ND_AFIP = null,
                    FechaLog = DateTime.Now,
                    UserLog = GlobalApp.AppUsername,
                };
  //              _asignacionNumerosDocumentosFI.AsignaNumeroDocumentoTemporal();
            }
        }

        /// <summary>
        /// Recalcula valores nuevos solo para items cotizados en USD
        /// </summary>
        public void CargaDatosNcActualizaPrecioDiferenciaCambio(int idFacturaAnula, decimal nuevoTc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Carga Header de factura original y blanquea datos nuevos
                _status400 = DocumentFIStatusManager.StatusHeader.Pendiente;
                CreaT400HeaderBasadoEnDocumentoExistente(idFacturaAnula,"NC");
               
                var items = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFacturaAnula).ToList();
                int numeroItem = 1;
                I4.Clear();
                foreach (var i in items)
                {
                    if (i.MONEDA_COTIZ == "USD")
                    {
                        var t = new T0401_FACTURA_I()
                        {
                            IDITEM = numeroItem,
                            ITEM = i.ITEM,
                            DESC_REMITO = "*Ajuste precio *" + i.DESC_REMITO,
                            KGDESPACHADOS_R = i.KGDESPACHADOS_R,
                            MONEDA_FACT = i.MONEDA_FACT,
                            MONEDA_COTIZ = i.MONEDA_COTIZ,
                            IVA21 = i.IVA21,
                            PRECIOU_COTIZ = i.PRECIOU_COTIZ, //es en USD
                            PRECIOT_COTIZ = i.PRECIOT_COTIZ, //es en USD
                            PRECIOU_FACT_USD = i.PRECIOU_FACT_USD,
                            PRECIOT_FACT_USD = i.PRECIOT_FACT_USD,
                            PRECIOU_FACT_ARS = Math.Abs(i.PRECIOU_FACT_ARS - Math.Round(i.PRECIOU_COTIZ * nuevoTc,2)),
                            PRECIOT_FACT_ARS = Math.Abs(i.PRECIOT_FACT_ARS - Math.Round(i.PRECIOT_COTIZ * nuevoTc, 2)),
                            GLV = i.GLV,
                            GLI = i.GLI,
                            CostoStd = i.CostoStd,
                            FsrOV = null,
                            FsrOVItem = null,
                            TC = H4.TC,
                            IDFACTURAX = null,
                            IDFactura = 0,
                            NAS = null,
                            NASSEG = null,
                            NUMFACTURA = H4.NumeroDoc,
                        };
                        numeroItem++;
                        I4.Add(t);
                    }
                }
                _total.MapImportesFromItems400(I4,H4.IIBB_PORC.Value,H4.DescuentoPorc.Value);
                H4.TotalFacturaB = _total.Bruto;
                H4.Descuento = _total.Descuento;
                H4.TotalImpo = _total.BaseImponible;
                H4.TotalIVA21 = _total.Iva21;
                H4.TotalIIBB = _total.IIBB;
                H4.TotalFacturaN = _total.TotalFinal;
                H4.DescuentoPorc = _total.PorcentajeDescuento;
                GeneraTemporal300FromTemporal400();     //Header 300
                H3.idFacturaAsociada = idFacturaAnula;
            }
        }
        public void CargaDatosNcDesdeListaItems(int idFacturaModifica, List<T0401_FACTURA_I> itemsUpdate)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _status400 = DocumentFIStatusManager.StatusHeader.Pendiente;
                CreaT400HeaderBasadoEnDocumentoExistente(idFacturaModifica, "NC");
                foreach (var i in itemsUpdate)
                {
                    var t = new T0401_FACTURA_I()
                    {
                        IDITEM = i.IDITEM,
                        ITEM = i.ITEM,
                        DESC_REMITO = i.DESC_REMITO,
                        KGDESPACHADOS_R = i.KGDESPACHADOS_R * -1,
                        MONEDA_FACT = i.MONEDA_FACT,
                        MONEDA_COTIZ = i.MONEDA_COTIZ,
                        IVA21 = i.IVA21,
                        PRECIOU_COTIZ = i.PRECIOU_COTIZ,
                        PRECIOT_COTIZ = i.PRECIOT_COTIZ,
                        PRECIOU_FACT_ARS = i.PRECIOU_FACT_ARS,
                        PRECIOT_FACT_ARS = i.PRECIOT_FACT_ARS,
                        PRECIOU_FACT_USD = i.PRECIOU_FACT_USD,
                        PRECIOT_FACT_USD = i.PRECIOT_FACT_USD,
                        GLV = i.GLV,
                        GLI = i.GLI,
                        CostoStd = i.CostoStd,
                        FsrOV = null,
                        FsrOVItem = null,
                        TC = H4.TC,
                        IDFACTURAX = null,
                        IDFactura = 0,
                        NAS = null,
                        NASSEG = null,
                        NUMFACTURA = H4.NumeroDoc,
                    };
                    I4.Add(t);
                }

                //
                _total.MapImportesFromItems400(I4, H4.IIBB_PORC.Value, 0);
                H4.TotalFacturaB = _total.Bruto;
                H4.Descuento = _total.Descuento;
                H4.TotalImpo = _total.BaseImponible;
                H4.TotalIVA21 = _total.Iva21;
                H4.TotalIIBB = _total.IIBB;
                H4.TotalFacturaN = _total.TotalFinal;
                H4.DescuentoPorc = _total.PorcentajeDescuento;
                GeneraTemporal300FromTemporal400(); //Header 300
                H3.idFacturaAsociada = idFacturaModifica;
            }
        }
        public void CargaDatosNcAnulaDocumentoCompleto(int idFacturaAnula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _status400 = DocumentFIStatusManager.StatusHeader.Pendiente;
                CreaT400HeaderBasadoEnDocumentoExistente(idFacturaAnula, "NC");
                //Al Header Basico le actualiza los valores de la factura anterior
                var h = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFacturaAnula);

                H4.TotalFacturaB = h.TotalFacturaB - h.Descuento.Value;
                H4.Descuento = 0;
                H4.TotalImpo = h.TotalImpo;
                H4.TotalIVA21 = h.TotalIVA21;
                H4.TotalIIBB = h.TotalIIBB;
                H4.TotalFacturaN = h.TotalFacturaN;
                H4.IIBB_PORC = h.IIBB_PORC;
                var items = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFacturaAnula).ToList();
                foreach (var i in items)
                {
                    var t = new T0401_FACTURA_I()
                    {
                        IDITEM = i.IDITEM,
                        ITEM = i.ITEM,
                        DESC_REMITO = "* " + i.DESC_REMITO,
                        KGDESPACHADOS_R = i.KGDESPACHADOS_R * -1,
                        MONEDA_FACT = i.MONEDA_FACT,
                        MONEDA_COTIZ = i.MONEDA_COTIZ,
                        IVA21 = i.IVA21,
                        PRECIOU_COTIZ = i.PRECIOU_COTIZ,
                        PRECIOT_COTIZ = i.PRECIOT_COTIZ,
                        PRECIOU_FACT_ARS = i.PRECIOU_FACT_ARS,
                        PRECIOT_FACT_ARS = i.PRECIOT_FACT_ARS,
                        PRECIOU_FACT_USD = i.PRECIOU_FACT_USD,
                        PRECIOT_FACT_USD = i.PRECIOT_FACT_USD,
                        GLV = i.GLV,
                        GLI = i.GLI,
                        CostoStd = i.CostoStd,
                        FsrOV = null,
                        FsrOVItem = null,
                        TC = H4.TC,
                        IDFACTURAX = null,
                        IDFactura = 0,
                        NAS = null,
                        NASSEG = null,
                        NUMFACTURA = H4.NumeroDoc,
                    };
                    I4.Add(t);
                }
                //
                GeneraTemporal300FromTemporal400(); //Header 300
                H3.idFacturaAsociada = idFacturaAnula;
            }
        }
        //public void CargaDatosNcDescuentoGeneral(int idCliente,string tipoLx,DateTime fechaDocumento, decimal tc,string moneda, List<T0401_FACTURA_I> itemsAdd)
        //{
        //    //No cambia signo
        //    InicializaHeaderT400_BasicCustomer(idCliente,"NC",tipoLx,fechaDocumento,tc,moneda);
        //    foreach (var i in itemsAdd)
        //    {
        //        var t = new T0401_FACTURA_I()
        //        {
        //            IDITEM = i.IDITEM,
        //            ITEM = i.ITEM,
        //            DESC_REMITO = i.DESC_REMITO,
        //            KGDESPACHADOS_R = i.KGDESPACHADOS_R,
        //            MONEDA_FACT = i.MONEDA_FACT,
        //            MONEDA_COTIZ = i.MONEDA_COTIZ,
        //            IVA21 = i.IVA21,
        //            PRECIOU_COTIZ = i.PRECIOU_COTIZ,
        //            PRECIOT_COTIZ = i.PRECIOT_COTIZ,
        //            PRECIOU_FACT_ARS = i.PRECIOU_FACT_ARS,
        //            PRECIOT_FACT_ARS = i.PRECIOT_FACT_ARS,
        //            PRECIOU_FACT_USD = i.PRECIOU_FACT_USD,
        //            PRECIOT_FACT_USD = i.PRECIOT_FACT_USD,
        //            GLV = i.GLV,
        //            GLI = i.GLI,
        //            CostoStd = i.CostoStd,
        //            FsrOV = null,
        //            FsrOVItem = null,
        //            TC = H4.TC,
        //            IDFACTURAX = null,
        //            IDFactura = 0,
        //            NAS = null,
        //            NASSEG = null,
        //            NUMFACTURA = H4.NumeroDoc,
        //        };
        //        I4.Add(t);
        //    }
        //    //
        //    _total.MapImportesFromItems400(I4, H4.IIBB_PORC.Value, 0);
        //    H4.TotalFacturaB = _total.Bruto;
        //    H4.Descuento = _total.Descuento;
        //    H4.TotalImpo = _total.BaseImponible;
        //    H4.TotalIVA21 = _total.Iva21;
        //    H4.TotalIIBB = _total.IIBB;
        //    H4.TotalFacturaN = _total.TotalFinal;
        //    H4.DescuentoPorc = _total.PorcentajeDescuento;
        //    GeneraTemporal300FromTemporal400(); //Header 300
        //    H3.idFacturaAsociada=0;
        //}

        /// <summary>
        /// Genera la estructura de T300 desde T400.
        /// </summary>
        private void GeneraTemporal300FromTemporal400()
        {
            H3 = new T0300_NCD_H()
            {
                IDH = 0,
                TDOC = H4.TIPO_DOC,
                NDOC = H4.NumeroDoc,
                LX = H4.TIPOFACT,
                MON = H4.FacturaMoneda,
                IdCliente = H4.Cliente,
                RazonSocial = H4.RAZONSOC,
                FECHA = H4.FECHA,
                TC = H4.TC,
                ImporteARS = H4.TotalFacturaN,
                ImporteUSD = H4.TotalFacturaN / H4.TC,
                LOGDATE = DateTime.Now,
                LOGUSER = GlobalApp.CnnApp,
                TEMP = true,
                idFacturaT0400 = null,
                idCtaCte = null,
                idFacturaX = null,
                idFacturaAsociada = null,
                PeriodoAjusteDesde = null,
                PeriodoAjusteHasta = null,
            };
            foreach (var i in I4)
            {
                var t = new T0301_NCD_I()
                {
                    IDH = 0,
                    IDITEM = i.IDITEM,
                    TDOC = H4.TIPO_DOC,
                    NDOC = H4.NumeroDoc,
                    CANT = i.KGDESPACHADOS_R.Value,
                    ITEM = i.ITEM,
                    Descripcion = i.DESC_REMITO,
                    MON = H4.FacturaMoneda,
                    PUNITARIO = H4.FacturaMoneda == "ARS" ? i.PRECIOU_FACT_ARS : i.PRECIOU_FACT_USD,
                    PTOTAL = H4.FacturaMoneda == "ARS" ? i.PRECIOT_FACT_ARS : i.PRECIOT_FACT_USD,
                    IVA21 = i.IVA21,
                    PIVA = 0,
                    GL = i.GLV,
                    IDCHE = null,
                };
                if (t.IVA21)
                    t.PIVA = decimal.Round(t.PTOTAL * (decimal) 0.21, 2);
                I3.Add(t);
            }
        }
        public void RegistraT400()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (H4.IDFACTURA > 0)
                {
                    //Elimino datos Existentes en T400
                    var z = db.T0401_FACTURA_I.Where(c => c.IDFactura == H4.IDFACTURA).ToList();
                    foreach (var i in z)
                    {
                        db.T0401_FACTURA_I.Remove(i);
                        db.SaveChanges();
                    }
                    var facturaH = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == H4.IDFACTURA);
                    if (facturaH != null) db.T0400_FACTURA_H.Remove(facturaH);
                    db.SaveChanges();
                    H4.StatusFactura = DocumentFIStatusManager.StatusHeader.Registrada.ToString();
                    H4.FechaLog = DateTime.Now;
                    H4.UserLog = Environment.UserName;
                    db.T0400_FACTURA_H.Add(H4);
                }
                else
                {
                    H4.IDFACTURA = db.T0400_FACTURA_H.Max(c => c.IDFACTURA) + 1;
                    H4.IDFACTURAX = GetNextIdFacturaX(H4.TIPOFACT);
                    H4.FechaLog = DateTime.Now;
                    H4.UserLog = Environment.UserName;
                    H4.StatusFactura = DocumentFIStatusManager.StatusHeader.Registrada.ToString();
                    AsignaNumeroDocumentoTemporal();
                    db.T0400_FACTURA_H.Add(H4);
                    if (db.SaveChanges() == 0)
                    {
                        Id400 = -1;
                    }
                    else
                    {
                        Id400 = H4.IDFACTURA;
                    }
                }
                var numeroItem = 0;
                var _c = db.T0401_FACTURA_I.Where(c => c.IDFactura == H4.IDFACTURA).ToList();
                if (_c.Any())
                {
                    db.T0401_FACTURA_I.RemoveRange(_c);
                    var y = db.SaveChanges();
                }

                foreach (var item in I4)
                {
                    numeroItem++;
                    item.IDFactura = H4.IDFACTURA;
                    item.IDITEM = numeroItem;
                    item.IDFACTURAX = H4.IDFACTURAX;
                }
                db.T0401_FACTURA_I.AddRange(I4);
                db.SaveChanges();
                _status400 =DocumentFIStatusManager.StatusHeader.Registrada;
            }
        }
        public bool DesRegistraT400()
        {
            if (H4.IDFACTURA <= 0)
                return false;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var i4 = db.T0401_FACTURA_I.Where(c => c.IDFactura == H4.IDFACTURA).ToList();
                db.T0401_FACTURA_I.RemoveRange(i4);
                db.SaveChanges();
                var h4 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == H4.IDFACTURA);
                db.T0400_FACTURA_H.Remove(h4);
                H4.IDFACTURA = 0;
                H4.IDFACTURAX = null;
                H4.NumeroDoc = null;
                _status400 = DocumentFIStatusManager.StatusHeader.Pendiente;
                H4.StatusFactura = _status400.ToString();
                foreach (var ii in I4)
                {
                    ii.IDFactura = 0;
                    ii.IDFACTURAX = null;
                    ii.NUMFACTURA = null;
                }
                var i3 = db.T0301_NCD_I.Where(c => c.IDH == H3.IDH).ToList();
                db.T0301_NCD_I.RemoveRange(i3);
                db.SaveChanges();
                var h3 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H3.IDH);
                db.T0300_NCD_H.Remove(h3);
                db.SaveChanges();
                h3.IDH = 0;
                h3.NDOC = null;
                h3.idFacturaT0400 = null;
                h3.idFacturaX = null;
                foreach (var ii in I3)
                {
                    ii.IDH = 0;
                    ii.NDOC = null;
                }
            }
            return true;
        }
        
        /// <summary>
        /// Registra 300/301 despues de haber registrado T400/401 
        /// </summary>
        public void RegistraT300_AfterT400(string motivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (H3.IDH > 0)
                {
                    //Elimino datos Existentes en T300/t301
                    var z = db.T0301_NCD_I.Where(c => c.IDH == H3.IDH).ToList();
                    foreach (var i in z)
                    {
                        db.T0301_NCD_I.Remove(i);
                        db.SaveChanges();
                    }
                    var NcdH = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H3.IDH);
                    if (NcdH != null) db.T0300_NCD_H.Remove(NcdH);
                    db.SaveChanges();
                    H3.idFacturaT0400 = H4.IDFACTURA;
                    H3.idFacturaX = H4.IDFACTURA;
                    H3.LOGDATE = DateTime.Now;
                    H3.LOGUSER = Environment.UserName;
                    db.T0300_NCD_H.Add(H3);
                }
                else
                {
                    H3.COMENTARIO = motivo;
                    H3.idFacturaT0400 = H4.IDFACTURA;
                    H3.idFacturaX = H4.IDFACTURAX;
                    H3.IDH = db.T0300_NCD_H.Max(c => c.IDH) + 1;
                    H3.NDOC = H4.NumeroDoc; //Si es L1 lleva el mismo numero que en T400.-
                    H3.LOGUSER = GlobalApp.AppUsername;
                    H3.LOGDATE = DateTime.Now;
                    db.T0300_NCD_H.Add(H3);
                    if (db.SaveChanges() > 0)
                    {
                        Id300 = H3.IDH;
                    }
                    else
                    {
                        Id300 = -1;
                    }
                }

                //
                var numeroItem = 1;
                foreach (var item in I3)
                {
                    item.IDH = H3.IDH;
                    item.IDITEM = numeroItem;
                    db.T0301_NCD_I.Add(item);
                    numeroItem++;
                }
                db.SaveChanges();
            }
        }
        private int GetNextIdFacturaX(string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var max = db.T0400_FACTURA_H.Where(c => c.TIPOFACT == tipoLx).Max(c => c.IDFACTURAX);
                if (max != null)
                    return (int) max + 1;
                return 1;
            }
        }
        public Totales GetTotales()
        {
            _total.MapImportesFrom400Header(H4);
            return _total;
        }



        public void CompletaDatosAfterConta(int nas, int idctacte)
        {
            H4.NAS = nas;
            H4.IdCtaCte = idctacte;
            H3.idCtaCte = idctacte;
            H3.ASIENTO = nas;
        }

        public static T0400_FACTURA_H Get400Header(int idfactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idfactura);
            }
        }
        public static List<T0401_FACTURA_I> Get401Items(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
            }
        }
        public static T0401_FACTURA_I Get401Item(int idFactura,int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0401_FACTURA_I.SingleOrDefault(c => c.IDFactura == idFactura && c.IDITEM == idItem);
            }
        }
     

        public void AddIdComprobanteAsociado(int idComprobante, bool updatedTablaSql = false)
        {
            H3.idFacturaAsociada = idComprobante;
            H3.PeriodoAjusteDesde = null;
            H3.PeriodoAjusteHasta = null;
            if (!updatedTablaSql)
                return;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H3.IDH);
                if (h == null)
                    return;
                h.idFacturaAsociada = H3.idFacturaAsociada;
                h.PeriodoAjusteDesde = null;
                h.PeriodoAjusteHasta = null;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Metodo SaveData incluye update desde el objeto de este campo
        /// </summary>
      

        public T0300_NCD_H GetT0300HeaderFromIDFactura400(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == idFactura);
            }
        }




    }
}
