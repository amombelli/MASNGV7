using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    //Nueva Clase de Gestion Documentos T400.T401
    //Factura, NC, ND, AJ
    public class XCustomerDocumentBase
    {
        protected XCustomerDocumentBase(int idCliente, string tcode)
        {
            _idCliente = idCliente;
            _tcode = tcode;
        }
        protected XCustomerDocumentBase(int idFactura)
        {
            _facturaId.IdFactura = idFactura;
            GetHeaderDataFromDb();
            _idCliente = H.Cliente;
            _tcode = "?";
            _tipoLx = H.TIPOFACT;
        }

        protected XCustomerDocumentBase()
        {

        }

        //-------------------------------------------------------------------------------
        protected int _idCliente;
        protected string _tcode;
        protected string _tipoLx;
        private T0400_FACTURA_H H = new T0400_FACTURA_H();
        private List<T0401_FACTURA_I> I = new List<T0401_FACTURA_I>();
        protected T0300_NCD_H _nh = new T0300_NCD_H();
        private List<T0301_NCD_I> _ni = new List<T0301_NCD_I>();
        private FacturaId _facturaId;
        //-------------------------------------------------------------------------------
        public enum TipoLx
        {
            L1,
            L2
        };
        public TipoLx MapLxFromString(string tipo)
        {
            if (tipo == "L1")
                return TipoLx.L1;
            return TipoLx.L2;
        }
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
            public decimal Redondeo { get; set; } //no implementado aun
        }
        public void UpdateDocumentType(ManageDocumentType.TipoDocumento tipoDocumento)
        {
            this.H.TIPO_DOC = ManageDocumentType.GetSystemDocumentType(tipoDocumento);
            this._nh.TDOC = H.TIPO_DOC;
        }



        public void CreateNewHeaderInMemory(ManageDocumentType.TipoDocumento tipoDoc, int idCliente,
            DateTime fechaDocumento,
            string tipoLx, decimal exchangeRate, decimal totalBruto = 0, decimal descuento = 0,
            decimal baseImponible = 0, decimal importeIva21 = 0, decimal importeIIBB = 0, decimal importeFinal = 0,
            decimal alicuotaIIBB = 0, string distritoIIBB = null, string moneda = "ARS", int idRemito = 0,
            string comentario = null)
        {
            _tipoLx = tipoLx;
            var header400 = new T0400_FACTURA_H
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
            header400.RAZONSOC = dataCliente.cli_rsocial;
            header400.CUIT = dataCliente.CUIT;
            header400.DIRECCION_FAC = dataCliente.Direccion_facturacion;
            header400.LOC_FAC = dataCliente.Direfactu_Localidad;

            if (header400.Descuento == 0)
                header400.DescuentoPorc = 0;

            if (idRemito > 0)
            {
                header400.IDRemito = idRemito;
                var r = new TecserData(GlobalApp.CnnApp).T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (r != null)
                    header400.Remito = r.NUMREMITO;
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
            this.H = header400;

            //mantiene H NCD
            var ncdh = new T0300_NCD_H()
            {
                IdCliente = header400.Cliente,
                RazonSocial = header400.RAZONSOC,
                COMENTARIO = comentario,
                FECHA = header400.FECHA,
                MON = header400.FacturaMoneda,
                TC = header400.TC,
                LX = _tipoLx,
                TDOC = header400.TIPO_DOC,
            };

            if (header400.FacturaMoneda == "ARS")
            {
                ncdh.ImporteARS = header400.TotalFacturaN;
                ncdh.ImporteUSD = Decimal.Round(((decimal)header400.TotalFacturaN / (decimal)header400.TC), 2);
            }
            else
            {
                ncdh.ImporteUSD = header400.TotalFacturaN;
                ncdh.ImporteARS = Decimal.Round(((decimal)header400.TotalFacturaN * (decimal)header400.TC), 2);
            }
            _nh = ncdh;
        }

        private void GetHeaderDataFromDb()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                H = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _facturaId.IdFactura);
                _nh = db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == H.IDFACTURA);
            }
        }

        public void RecalculaTotalesFromDb()
        {
            GetHeaderDataFromDb();
        }
        public ImportesT400 GetTotalesFromMemory()
        {
            decimal AlicuotaIIBB = 0;
            if (H.IIBB_PORC != null)
                AlicuotaIIBB = H.IIBB_PORC.Value;
            var resultado = new ImportesT400
            {
                ImporteIVA = H.TotalIVA21,
                BaseImponible = H.TotalImpo,
                Bruto = H.TotalFacturaB,
                NetoFinal = H.TotalFacturaN,
                ImporteDescuento = H.Descuento.Value,
                ImporteIIBB = H.TotalIIBB,
                PorDescuento = H.DescuentoPorc.Value,
                AlicuotaIIBB = AlicuotaIIBB,
            };
            return resultado;
        }
        public void UpdateObservacionesIfChanges(string observaciones)
        {
            _nh.COMENTARIO = observaciones;
        }
        public void UpdateImportesIfExchangeRateChanges(decimal exchangeRate)
        {
            H.TC = exchangeRate;
            _nh.TC = exchangeRate;
            UpdateImportes();
        }
        public void UpdateImportesIfAlicuotaIIBBChanges(decimal alicuotaIIBB)
        {
            H.IIBB_PORC = alicuotaIIBB;
            UpdateImportes();
        }
        public void UpdateImportesIfPorcentajeDescuentoChanges(decimal porcentajeDescuento)
        {
            H.DescuentoPorc = porcentajeDescuento;
            UpdateImportes();
        }
        public void UpdateImportesIfImporteDescuentoChanges(decimal importeDescuento)
        {
            H.Descuento = importeDescuento;
            H.DescuentoPorc = H.Descuento / H.TotalFacturaB;
            UpdateImportes();
        }
        private void UpdateImportes()
        {
            decimal importeBruto = 0;
            decimal importeImponible = 0;

            foreach (var item in I)
            {
                if (H.FacturaMoneda == "ARS")
                {
                    item.PRECIOU_FACT_USD = Decimal.Round(Convert.ToDecimal(item.PRECIOU_FACT_ARS / H.TC), 2);
                    item.PRECIOT_FACT_USD = Decimal.Round(Convert.ToDecimal(item.PRECIOU_FACT_ARS / H.TC), 2);
                    importeBruto += item.PRECIOT_FACT_ARS;

                    if (item.IVA21)
                    {
                        importeImponible += item.PRECIOT_FACT_ARS;
                    }
                }
                else
                {
                    item.PRECIOU_FACT_ARS = Decimal.Round(Convert.ToDecimal(item.PRECIOU_FACT_ARS * H.TC), 2);
                    item.PRECIOT_FACT_ARS = Decimal.Round(Convert.ToDecimal(item.PRECIOT_FACT_ARS * H.TC), 2);
                    importeBruto += item.PRECIOT_FACT_USD;

                    if (item.IVA21)
                    {
                        importeImponible += item.PRECIOT_FACT_USD;
                    }
                }
            }
            H.TotalFacturaB = importeBruto;

            if (H.DescuentoPorc == null)
                H.DescuentoPorc = 0;

            if (H.DescuentoPorc > 0)
            {
                H.Descuento = Decimal.Round(((decimal)importeBruto * (decimal)H.DescuentoPorc), 2);
            }

            var subtotal = importeBruto - H.Descuento.Value;
            H.TotalImpo = Decimal.Round((importeImponible - (importeImponible * H.DescuentoPorc.Value)), 2);
            H.TotalIVA21 = Decimal.Round(H.TotalImpo * (decimal)0.21, 2);
            decimal alicuotaIIBB = 0;
            if (H.IIBB_PORC != null)
                alicuotaIIBB = H.IIBB_PORC.Value;

            H.TotalIIBB = Decimal.Round((H.TotalImpo * alicuotaIIBB), 2);

            H.TotalFacturaN = subtotal + H.TotalIVA21 + H.TotalIIBB;

            decimal porcentajeDto = 0;
            if (H.Descuento != 0)
            {
                porcentajeDto = Convert.ToDecimal(H.Descuento / H.TotalFacturaB);
            }
            H.TotalImpo = Decimal.Round((importeImponible - (importeImponible * porcentajeDto)), 2);
            H.TotalIVA21 = Decimal.Round(H.TotalImpo * (decimal)0.21, 2);
            H.TotalFacturaN = H.TotalFacturaB - H.Descuento.Value + H.TotalIVA21 + H.TotalIIBB;

            //mapea a Header NCD>
            if (H.FacturaMoneda == "ARS")
            {
                _nh.ImporteARS = H.TotalFacturaN;
                _nh.ImporteUSD = Decimal.Round(((decimal)H.TotalFacturaN / (decimal)H.TC), 2);
            }
            else
            {
                _nh.ImporteUSD = H.TotalFacturaN;
                _nh.ImporteARS = Decimal.Round(((decimal)H.TotalFacturaN * (decimal)H.TC), 2);
            }
        }

        //Al agregar los items a memoria actualiza totales en H.
        public void CreateNewItemListInMemory(List<T0301_NCD_I> itemList)
        {
            var numeroItem = 1;
            I.Clear();

            foreach (var it in itemList)
            {
                var i = new T0401_FACTURA_I()
                {
                    TC = H.TC,
                    IDITEM = numeroItem,
                    KGDESPACHADOS_R = it.CANT,
                    DESC_REMITO = it.Descripcion,
                    GLI = null,
                    GLV = it.GL,
                    IVA21 = it.IVA21,
                    MONEDA_COTIZ = null,
                    ITEM = it.ITEM,
                    MONEDA_FACT = H.FacturaMoneda,
                };

                if (H.FacturaMoneda == "ARS")
                {
                    i.PRECIOU_FACT_ARS = it.PUNITARIO;
                    i.PRECIOT_FACT_ARS = it.PTOTAL;
                }
                else
                {
                    i.PRECIOU_FACT_USD = it.PUNITARIO;
                    i.PRECIOT_FACT_USD = it.PTOTAL;
                }
                numeroItem++;
                I.Add(i);
            }
            UpdateImportes();
            _ni = new List<T0301_NCD_I>(itemList);
        }

        public bool UpdateHeaderTotalesWhenAnulaFacturaCompleta(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fh = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (H.TotalFacturaB != fh.TotalFacturaB)
                {
                    return false;
                }

                if (fh.TotalIIBB > 0)
                {
                    H.TotalIIBB = fh.TotalIIBB;
                    H.IIBB_PORC = fh.IIBB_PORC;
                    H.IIBB_TXT = fh.IIBB_TXT;
                }

                if (fh.Descuento > 0 && fh.TotalFacturaB > 0)
                {
                    H.Descuento = fh.Descuento;
                    H.DescuentoPorc = fh.Descuento / fh.TotalFacturaB;
                }
                H.TotalImpo = fh.TotalImpo;
                H.TotalIVA21 = fh.TotalIVA21;

                var netoMemoria = H.TotalFacturaB - H.Descuento.Value + H.TotalIVA21 + H.TotalIIBB;
                H.TotalFacturaN = netoMemoria;
                if (fh.TotalFacturaN != netoMemoria)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Mapea la diferencia entre 2 documentos (un original) y un nuevo calculado
        /// Usado para NC por diferencia de TC.-
        /// </summary>
        private void MapTotalesHeaderDiferencia(ManageTotalesCustomerNcd precioHeader, int idFacturaOriginal)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var originalHeader = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFacturaOriginal);
                if (originalHeader == null)
                    return;
                //
                if (H.TIPO_DOC == "ND")
                {
                    H.TotalFacturaB = -originalHeader.TotalFacturaB + precioHeader.ImporteTotalBrutoInicial;
                    H.TotalFacturaN = -originalHeader.TotalFacturaN + precioHeader.ImporteTotalNetoFinal;
                    H.Descuento = originalHeader.Descuento + precioHeader.ImporteDescuento;
                    H.DescuentoPorc = precioHeader.PorcentajeDescuento;
                    H.FacturaMoneda = precioHeader.MonedaDocumento;
                    H.IIBB_PORC = precioHeader.AlicuotaPerRetIIBB;
                    H.TotalIIBB = -originalHeader.TotalIIBB + precioHeader.ImportePerRetIIBB;
                    H.TotalIVA21 = -originalHeader.TotalIVA21 + precioHeader.ImporteIva21;
                    H.TC = precioHeader.ExchangeRate;
                    H.TotalImpo = -originalHeader.TotalImpo + precioHeader.ImporteBaseImponible;
                }
                else
                {
                    H.TotalFacturaB = originalHeader.TotalFacturaB - precioHeader.ImporteTotalBrutoInicial;
                    H.TotalFacturaN = originalHeader.TotalFacturaN - precioHeader.ImporteTotalNetoFinal;
                    H.Descuento = originalHeader.Descuento - precioHeader.ImporteDescuento;
                    H.DescuentoPorc = precioHeader.PorcentajeDescuento;
                    H.FacturaMoneda = precioHeader.MonedaDocumento;
                    H.IIBB_PORC = precioHeader.AlicuotaPerRetIIBB;
                    H.TotalIIBB = originalHeader.TotalIIBB - precioHeader.ImportePerRetIIBB;
                    H.TotalIVA21 = originalHeader.TotalIVA21 - precioHeader.ImporteIva21;
                    H.TC = precioHeader.ExchangeRate;
                    H.TotalImpo = originalHeader.TotalImpo - precioHeader.ImporteBaseImponible;
                }

                //
            }
        }

        /// <summary>
        /// Usar esta funcion cuando el Header del documento NO SE CALCULA desde el agregado de CostItems sino que 'se copia' 
        /// desde un documento existente (ejemplo en variacion de Tipo de Cambio)
        /// </summary>
        public void CreateNewItemListInMemoryForDeltaPrecio(List<T0301_NCD_I> itemList,
            ManageTotalesCustomerNcd precioHeader, int idFacturaOriginal)
        {
            MapTotalesHeaderDiferencia(precioHeader, idFacturaOriginal);
            var numeroItem = 1;
            I.Clear();

            foreach (var it in itemList)
            {
                var i = new T0401_FACTURA_I()
                {
                    TC = H.TC,
                    IDITEM = numeroItem,
                    KGDESPACHADOS_R = it.CANT,
                    DESC_REMITO = it.Descripcion,
                    GLI = null,
                    GLV = it.GL,
                    IVA21 = it.IVA21,
                    MONEDA_COTIZ = null,
                    ITEM = it.ITEM,
                    MONEDA_FACT = H.FacturaMoneda,
                };

                if (H.FacturaMoneda == "ARS")
                {
                    i.PRECIOU_FACT_ARS = H.TotalFacturaB;
                    i.PRECIOT_FACT_ARS = H.TotalFacturaB;
                }
                else
                {
                    i.PRECIOU_FACT_USD = H.TotalFacturaB;
                    i.PRECIOT_FACT_USD = H.TotalFacturaB;
                }
                numeroItem++;
                I.Add(i);
            }

            //Update importe Neto en NCD Header>
            if (H.FacturaMoneda == "ARS")
            {
                _nh.ImporteARS = H.TotalFacturaN;
                _nh.ImporteUSD = Decimal.Round(((decimal)H.TotalFacturaN / (decimal)H.TC), 2);
            }
            else
            {
                _nh.ImporteUSD = H.TotalFacturaN;
                _nh.ImporteARS = Decimal.Round(((decimal)H.TotalFacturaN * (decimal)H.TC), 2);
            }
            //Add CostItems en NCD
            _ni = new List<T0301_NCD_I>(itemList);
        }

        public FacturaId GrabaDocumentoToDatabase()
        {
            var dataReturn = new FacturaId();
            var existeF400 = false;
            var existeN300 = false;

            if (H.IDFACTURA > 0)
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    //remueve items T400
                    var z = db.T0401_FACTURA_I.Where(c => c.IDFactura == H.IDFACTURA).ToList();
                    foreach (var i in z)
                    {
                        db.T0401_FACTURA_I.Remove(i);
                    }
                    //remueve items T301
                    var nch = db.T0301_NCD_I.Where(c => c.IDH == _nh.IDH).ToList();
                    foreach (var ii in nch)
                    {
                        db.T0301_NCD_I.Remove(ii);
                    }

                    var facturaH = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == H.IDFACTURA);
                    if (facturaH != null)
                    {
                        existeF400 = true;
                    }
                    //Actualiza Datos Header Factura
                    H.FechaLog = DateTime.Now;
                    H.UserLog = Environment.UserName;
                    if (existeF400)
                    {
                        facturaH.FechaLog = H.FechaLog;
                        facturaH.UserLog = H.UserLog;
                    }
                    else
                    {
                        db.T0400_FACTURA_H.Add(H);
                    }

                    var ncdH = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _nh.IDH);
                    _nh.LOGDATE = DateTime.Now;
                    _nh.LOGUSER = Environment.UserName;
                    _nh.idFacturaT0400 = H.IDFACTURA;
                    _nh.TDOC = H.TIPO_DOC;
                    _nh.TEMP = false;
                    if (ncdH != null)
                    {
                        existeN300 = true;
                    }

                    if (existeN300)
                    {
                        ncdH.TDOC = H.TIPO_DOC;

                        ncdH.COMENTARIO = _nh.COMENTARIO;
                        ncdH.ImporteARS = _nh.ImporteARS;
                        ncdH.ImporteUSD = _nh.ImporteUSD;
                        ncdH.LOGUSER = _nh.LOGUSER;
                        ncdH.LOGDATE = _nh.LOGDATE;
                        ncdH.idFacturaT0400 = _nh.idFacturaT0400;
                        ncdH.TEMP = false;
                        ncdH.idFacturaAsociada = _nh.idFacturaAsociada;
                        ncdH.PeriodoAjusteDesde = _nh.PeriodoAjusteDesde;
                        ncdH.PeriodoAjusteHasta = _nh.PeriodoAjusteHasta;
                    }
                    else
                    {
                        db.T0300_NCD_H.Add(_nh);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    //idFactura =0 (nuevo registro en T0400)
                    H.IDFACTURA = db.T0400_FACTURA_H.Max(c => c.IDFACTURA) + 1;
                    H.IDFACTURAX = GetNextIdFacturaX();
                    H.FechaLog = DateTime.Now;
                    H.UserLog = Environment.UserName;
                    db.T0400_FACTURA_H.Add(H);

                    if (_nh.IDH == 0)
                    {
                        //registro en NCD tambien nuevo
                        _nh.IDH = db.T0300_NCD_H.Max(c => c.IDH) + 1;
                        _nh.idFacturaT0400 = H.IDFACTURA;
                        _nh.LOGDATE = DateTime.Now;
                        _nh.LOGUSER = Environment.UserName;
                        db.T0300_NCD_H.Add(_nh);
                    }
                    else
                    {
                        //el registro en NCD existe - viene de reversion de registrado
                    }
                    db.SaveChanges();
                }
            }
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Tratamiento de CostItems
                var r1 = db.SaveChanges();
                var r = db.Entry(_nh).State;
                var numeroItem = 0;
                foreach (var item in I)
                {
                    numeroItem++;
                    item.IDFactura = H.IDFACTURA;
                    item.IDITEM = numeroItem;
                    item.IDFACTURAX = H.IDFACTURAX;
                    db.T0401_FACTURA_I.Add(item);
                }
                var numeroItemNCD = 0;
                foreach (var ni in _ni)
                {
                    numeroItemNCD++;
                    ni.IDH = _nh.IDH;
                    ni.IDITEM = numeroItemNCD;
                    ni.TDOC = _nh.TDOC;
                    db.T0301_NCD_I.Add(ni);
                }

                if (db.SaveChanges() != (numeroItemNCD + numeroItem))
                {
                    //ocurrio un error debiera hacer el rollback del header?
                    dataReturn.IdFacturaX = 0;
                    dataReturn.IdFactura = 0;
                    return dataReturn;
                }
                dataReturn.IdFacturaX = H.IDFACTURAX.Value;
                dataReturn.IdFactura = H.IDFACTURA;
                dataReturn.IdRemitoIdNcd = _nh.IDH;
                dataReturn.CantidadItems = numeroItemNCD;
                return dataReturn;
            }
        }
        public void SetStatusPendienteInMemory()
        {
            H.StatusFactura = DocumentFIStatusManager.StatusHeader.Pendiente.ToString();
        }
        public void UpdateT0300NCHFromT0400()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
        }
        private int GetNextIdFacturaX()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var max = db.T0400_FACTURA_H.Where(c => c.TIPOFACT == _tipoLx).Max(c => c.IDFACTURAX);
                if (max != null)
                    return (int)max + 1;
                return 1;
            }
        }
    }
}