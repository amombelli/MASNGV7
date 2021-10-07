using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Vendor
{
    public class XVendorDocumentBase
    {
        public XVendorDocumentBase(int idVendor, string tcode)
        {
            _idVendor = idVendor;
            _tcode = tcode;
        }
        public XVendorDocumentBase(int idFactura)
        {
            _idF.IdFactura = idFactura;
            GetHeaderDataFromDb();
            _idVendor = H.IDPROV;
            _tcode = "?";
            _tipoLx = H.TIPO;
        }

        //-------------------------------------------------------------------------------
        private readonly int _idVendor;
        private readonly string _tcode;
        private string _tipoLx;
        private T0403_VENDOR_FACT_H H = new T0403_VENDOR_FACT_H();
        private List<T0404_VENDOR_FACT_I> I = new List<T0404_VENDOR_FACT_I>();
        private T0310_NCDP_H _NcdPH = new T0310_NCDP_H();
        private List<T0311_NCDP_I> _NcdPI = new List<T0311_NCDP_I>();
        private List<T0156_CHEQUE_RECH> _listaChR = new List<T0156_CHEQUE_RECH>();
        private VendorFacturaId _idF;

        //-------------------------------------------------------------------------------
        public struct VendorFacturaId
        {
            public int IdFactura { get; set; }
            public int IdFacturaX { get; set; }
            public decimal IdNdp { get; set; }
            public int CantidadItems { get; set; }
        }

        public struct ImportesT403
        {
            public decimal ImporteBrutoInicial { get; set; }
            public decimal PorDescuento { get; set; }
            public decimal ImporteDescuento { get; set; }
            public decimal SubTotal { get; set; }
            public decimal BaseImponible { get; set; }
            public decimal ImporteIVA10 { get; set; }
            public decimal ImporteIVA21 { get; set; }
            public decimal ImporteIVA27 { get; set; }
            public decimal TotalIva { get; set; }
            public decimal AlicoutaIVA { get; set; }
            public decimal PercepcionIVA { get; set; }
            public decimal AlicuotaIIBB { get; set; }
            public decimal PercepcionIIBB { get; set; }
            public decimal PercpecionGs { get; set; }
            public decimal AlicuptaGs { get; set; }
            public decimal TotalPercepciones { get; set; }
            public decimal ImpuestoMunicipal { get; set; }
            public decimal ImpuestoProvincial { get; set; }
            public decimal ImpuestoInterno { get; set; }
            public decimal OtrosImpuestos { get; set; }
            public decimal ConceNoGravado { get; set; }
            public decimal TotalOtrosImpuestos { get; set; }
            public decimal TotalRedondeo { get; set; }
            public decimal NetoFinal { get; set; }
        }

        public void CreateNewHeaderInMemory(string numeroDocumento, ManageDocumentType.TipoDocumento tipoDoc,
            DateTime fechaDocumento, string tipoLx, decimal exchangeRate, decimal totalBruto, decimal baseImponible,
            decimal importeFinal, decimal descuento = 0,
            decimal importeIva21 = 0, decimal importeIva10 = 0, decimal importeIva27 = 0, decimal alicuotaIIBB = 0,
            decimal importeIIBB = 0, string distritoIIBB = null, string moneda = "ARS",
            string comentario = null, decimal alicuotaPercIva = 0, decimal percpecionIva = 0, decimal kg = 0,
            string glap = "0.0.0.0", int signo = 1)
        {
            _tipoLx = tipoLx;
            var header403 = new T0403_VENDOR_FACT_H()
            {
                TFACTURA = ManageDocumentType.GetSystemDocumentType(tipoDoc),
                TIPO = tipoLx,
                FECHA = fechaDocumento,
                IDPROV = _idVendor,
                StatusDocumento = "Registrado",
                MON = moneda,
                TC = exchangeRate,
                BRUTO = totalBruto * signo,
                DTO = descuento * signo,
                BaseImponible = baseImponible * signo,
                PerIIBB = importeIIBB * signo,
                NETO = importeFinal * signo,
                PerIIBB_Alicuota = alicuotaIIBB,
                PerIIBB_TXT = distritoIIBB,
                IDCTACTE = null,
                IVA21 = importeIva21 * signo,
                IVA10 = importeIva10 * signo,
                IVA27 = importeIva27 * signo,
                PerIVA_Alicuota = alicuotaPercIva,
                PerIVA = percpecionIva * signo,
                PerGA_Alicuota = 0,
                PerGS = 0,
                OBSERVACION = comentario,
                CANTKG = kg * signo,
                GLAP = glap,
                ConceptosNoGravados = 0,
                IMPINT = 0,
                IMPOTR = 0,
                ImpuestoMunicipal = 0,
                ImpuestoProvincial = 0,
                NFACTURA = numeroDocumento,
                TCODE = _tcode,
                IMPORI = importeFinal * signo,
                SALDOIMPAGO = importeFinal * signo
            };

            header403.SUBTOTAL = header403.BRUTO - header403.DTO;
            header403.TOTALIVA = header403.IVA10 + header403.IVA21 + header403.IVA27;
            header403.TotalImpuestosVarios = header403.PerIIBB + header403.PerGS + header403.PerIVA +
                                             header403.ImpuestoProvincial + header403.ImpuestoMunicipal +
                                             header403.IMPINT + header403.IMPOTR + header403.ConceptosNoGravados;

            var dataVendor = new VendorManager().GetSpecificVendor(_idVendor);
            header403.PROVRS = dataVendor.prov_rsocial;
            header403.PRTAX1 = dataVendor.NTAX1;
            this.H = header403;

            //mantiene H NCD
            var ncdh = new T0310_NCDP_H()
            {
                NDOC = header403.NFACTURA,
                TDOC = header403.TFACTURA,
                CLINUM = header403.IDPROV,
                CLITXT = header403.PROVRS,
                COMENTARIO = comentario,
                FECHA = header403.FECHA,
                MON = header403.MON,
                TC = header403.TC,
                TIPO = _tipoLx,
            };

            if (header403.MON == "ARS")
            {
                ncdh.TOTAL_ARS_NETO = header403.NETO;
                ncdh.TOTAL_USD_NETO = Decimal.Round(((decimal)header403.NETO / (decimal)header403.TC), 2);
            }
            else
            {
                ncdh.TOTAL_USD_NETO = header403.NETO;
                ncdh.TOTAL_ARS_NETO = Decimal.Round(((decimal)header403.NETO * (decimal)header403.TC), 2);
            }
            _NcdPH = ncdh;
        }

        public void CreateListaChequesRechazadoMemoria(List<T0156_CHEQUE_RECH> lst)
        {
            _listaChR = new List<T0156_CHEQUE_RECH>(lst);
        }

        private void GetHeaderDataFromDb()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                H = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == _idF.IdFactura);
                _NcdPH = db.T0310_NCDP_H.SingleOrDefault(c => c.IdT0403 == H.IDINT);
            }
        }
        public void RecalculaTotalesFromDb()
        {
            GetHeaderDataFromDb();
        }
        public ImportesT403 GetTotalesFromMemory()
        {
            decimal alicuotaIIBB = 0;

            if (H.PerIIBB_Alicuota != null)
                alicuotaIIBB = H.PerIIBB_Alicuota.Value;

            var resultado = new ImportesT403
            {
                ImporteBrutoInicial = H.BRUTO,
                ImporteDescuento = H.DTO,
                SubTotal = H.BRUTO - H.DTO,
                BaseImponible = H.BaseImponible,
                ImporteIVA10 = H.IVA10,
                ImporteIVA21 = H.IVA21,
                ImporteIVA27 = H.IVA27,
                AlicuotaIIBB = alicuotaIIBB,
                PercepcionIIBB = H.PerIIBB,
                AlicoutaIVA = H.PerIVA_Alicuota.Value,
                PercepcionIVA = H.PerIVA,
                PercpecionGs = H.PerGS,
                ConceNoGravado = H.ConceptosNoGravados,
                ImpuestoMunicipal = H.ImpuestoMunicipal,
                ImpuestoProvincial = H.ImpuestoProvincial,
                ImpuestoInterno = H.IMPINT,
                OtrosImpuestos = H.IMPOTR,
                NetoFinal = H.NETO,
            };

            if (H.NETO != 0)
                resultado.PorDescuento = H.DTO / H.NETO;

            resultado.TotalIva = resultado.ImporteIVA10 + resultado.ImporteIVA21 + resultado.ImporteIVA27;
            resultado.TotalOtrosImpuestos = resultado.ConceNoGravado + resultado.ImpuestoInterno +
                                            resultado.ImpuestoMunicipal + resultado.ImpuestoProvincial +
                                            resultado.OtrosImpuestos + resultado.PercepcionIIBB + resultado.PercepcionIVA +
                                            resultado.PercpecionGs;
            return resultado;
        }
        public void UpdateObservacionesIfChanges(string observaciones)
        {
            _NcdPH.COMENTARIO = observaciones;
        }
        public void UpdateImportesIfExchangeRateChanges(decimal exchangeRate)
        {
            H.TC = exchangeRate;
            _NcdPH.TC = exchangeRate;
            UpdateImportes();
        }
        public void UpdateImportesIfAlicuotaIIBBChanges(decimal alicuotaIIBB)
        {
            H.PerIIBB_Alicuota = alicuotaIIBB;
            UpdateImportes();
        }
        //public void UpdateImportesIfPorcentajeDescuentoChanges(decimal porcentajeDescuento)
        //{
        //    H.DTO.Value = porcentajeDescuento;
        //    UpdateImportes();
        //}
        public void UpdateImportesIfImporteDescuentoChanges(decimal importeDescuento)
        {
            H.DTO = importeDescuento;
            UpdateImportes();
        }
        private void UpdateImportes()
        {
            decimal importeBruto = 0;
            decimal importeImponible = 0;
            foreach (var item in I)
            {
                if (H.MON == "ARS")
                {
                    item.PUNIT_USD = Decimal.Round(Convert.ToDecimal(item.PUNIT_ARS / H.TC), 2);
                    item.PTOTAL_USD = Decimal.Round(Convert.ToDecimal(item.PTOTAL_ARS / H.TC), 2);
                    importeBruto += item.PTOTAL_ARS.Value;

                    if (item.IVA.Value)
                    {
                        importeImponible += item.PTOTAL_ARS.Value;
                    }
                }
                else
                {
                    item.PUNIT_ARS = Decimal.Round(Convert.ToDecimal(item.PUNIT_USD * H.TC), 2);
                    item.PTOTAL_ARS = Decimal.Round(Convert.ToDecimal(item.PTOTAL_USD * H.TC), 2);
                    importeBruto += item.PTOTAL_USD.Value;

                    if (item.IVA.Value)
                    {
                        importeImponible += item.PTOTAL_USD.Value;
                    }
                }
            }
            H.BRUTO = importeBruto;
            decimal dtoPorcentaje = 0;
            if (H.BRUTO != 0)
            {
                dtoPorcentaje = H.DTO / H.BRUTO;
            }

            var subtotal = importeBruto - H.DTO;
            H.BaseImponible = Decimal.Round((importeImponible - (importeImponible * dtoPorcentaje)), 2);
            H.IVA21 = Decimal.Round(H.BaseImponible * (decimal)0.21, 2);
            //H.PerIIBB = Decimal.Round((H.BaseImponible * alicuotaIIBB), 2);

            H.NETO = subtotal + H.IVA21 + H.IVA10 + H.IVA27 + H.PerIIBB + H.PerIVA;

            //mapea a Header NCD>
            if (H.MON == "ARS")
            {
                _NcdPH.TOTAL_ARS_NETO = H.NETO;
                _NcdPH.TOTAL_USD_NETO = Decimal.Round(((decimal)H.NETO / (decimal)H.TC), 2);
            }
            else
            {
                _NcdPH.TOTAL_USD_NETO = H.NETO;
                _NcdPH.TOTAL_ARS_NETO = Decimal.Round(((decimal)H.NETO * (decimal)H.TC), 2);
            }
        }

        //Al agregar los items a memoria actualiza totales en H.
        public void CreateNewItemListInMemory(List<T0311_NCDP_I> itemList, int signo)
        {
            var numeroItem = 1;
            I.Clear();

            foreach (var it in itemList)
            {
                var i = new T0404_VENDOR_FACT_I()
                {
                    TC = H.TC,
                    IDITEM = it.ITEM,
                    CANT = it.CANT * signo,
                    ITEM_DESC = it.DESC,
                    GL = it.GL,
                    MONEDA = it.MON,
                    IVA = it.IVA21,
                };

                if (H.MON == "ARS")
                {
                    i.PUNIT_ARS = it.PUNITARIO;
                    i.PTOTAL_ARS = it.PTOTAL;
                }
                else
                {
                    i.PUNIT_USD = it.PUNITARIO;
                    i.PTOTAL_USD = it.PTOTAL;
                }
                numeroItem++;
                I.Add(i);
            }
            UpdateImportes();
            _NcdPI = new List<T0311_NCDP_I>(itemList);
        }


        public VendorFacturaId GrabaDocumentoToDatabase()
        {
            var dataReturn = new VendorFacturaId();
            var existeF403 = false;
            var existeN303 = false;

            if (H.IDINT > 0)
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    //Remueve items T404 si existiesen
                    var z = db.T0404_VENDOR_FACT_I.Where(c => c.IDINT == H.IDINT).ToList();
                    foreach (var i in z)
                    {
                        db.T0404_VENDOR_FACT_I.Remove(i);
                    }
                    //Remueve items T311 si existiesen
                    var nch = db.T0311_NCDP_I.Where(c => c.IDH == _NcdPH.IDH).ToList();
                    foreach (var ii in nch)
                    {
                        db.T0311_NCDP_I.Remove(ii);
                    }

                    var facturaH = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == H.IDINT);
                    if (facturaH != null)
                    {
                        existeF403 = true;
                    }
                    //Actualiza Datos Header Factura
                    H.LOGDATE = DateTime.Now;
                    H.LOGUSER = Environment.UserName;
                    if (existeF403)
                    {
                        facturaH.LOGDATE = H.LOGDATE;
                        facturaH.LOGUSER = H.LOGUSER;
                    }
                    else
                    {
                        db.T0403_VENDOR_FACT_H.Add(H);
                    }

                    var ncdH = db.T0310_NCDP_H.SingleOrDefault(c => c.IDH == _NcdPH.IDH);
                    _NcdPH.LOGDATE = DateTime.Now;
                    _NcdPH.LOGUSER = Environment.UserName;
                    _NcdPH.IdT0403 = H.IDINT;
                    _NcdPH.TEMP = false;
                    if (ncdH != null)
                    {
                        existeN303 = true;
                    }

                    if (existeN303)
                    {
                        ncdH.COMENTARIO = _NcdPH.COMENTARIO;
                        ncdH.TOTAL_ARS_NETO = _NcdPH.TOTAL_ARS_NETO;
                        ncdH.TOTAL_USD_NETO = _NcdPH.TOTAL_USD_NETO;
                        ncdH.LOGUSER = _NcdPH.LOGUSER;
                        ncdH.LOGDATE = _NcdPH.LOGDATE;
                        ncdH.IdT0403 = _NcdPH.IdT0403;
                        ncdH.TEMP = false;
                    }
                    else
                    {
                        db.T0310_NCDP_H.Add(_NcdPH);
                    }

                    //Remueve Cheques Rechazados de T0156
                    foreach (var chr in _listaChR)
                    {
                        new ChequeRechazadoManager().RemoveChequeRechazado(chr.IDCHEQUE);
                    }

                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    //idFactura =0 (nuevo registro en T0403)
                    H.IDINT = db.T0403_VENDOR_FACT_H.Max(c => c.IDINT) + 1;
                    H.IdFacturaX = GetNextIdFacturaX();
                    H.LOGDATE = DateTime.Now;
                    H.LOGUSER = Environment.UserName;
                    db.T0403_VENDOR_FACT_H.Add(H);

                    if (_NcdPH.IDH == 0)
                    {
                        //registro nurevo en NCDP [H]
                        _NcdPH.IDH = db.T0310_NCDP_H.Max(c => c.IDH) + 1;
                        _NcdPH.IdT0403 = H.IDINT;
                        _NcdPH.LOGDATE = DateTime.Now;
                        _NcdPH.LOGUSER = Environment.UserName;
                        db.T0310_NCDP_H.Add(_NcdPH);
                    }
                    else
                    {
                        //el registro en NCD existe - viene de reversion de registrado
                        //var x = 1;
                    }
                    db.SaveChanges();
                }
            }
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Tratamiento de CostItems
                var r1 = db.SaveChanges();
                var r = db.Entry(_NcdPH).State;
                var numeroItem = 0;
                foreach (var item in I)
                {
                    numeroItem++;
                    item.IDINT = H.IDINT;
                    item.IDIT = numeroItem;
                    db.T0404_VENDOR_FACT_I.Add(item);
                }
                var numeroItemNCD = 0;
                foreach (var ni in _NcdPI)
                {
                    numeroItemNCD++;
                    ni.IDH = _NcdPH.IDH;
                    ni.TEMP = false;
                    ni.IDITEM = numeroItemNCD;
                    ni.TDOC = _NcdPH.TDOC;
                    db.T0311_NCDP_I.Add(ni);
                }

                if (db.SaveChanges() != (numeroItemNCD + numeroItem))
                {
                    //ocurrio un error debiera hacer el rollback del header?
                    dataReturn.IdFacturaX = 0;
                    dataReturn.IdFactura = 0;
                    dataReturn.IdNdp = 0;
                    return dataReturn;
                }

                //Mantiene Cheques Rechazados
                foreach (var chr in _listaChR)
                {
                    new ChequeRechazadoManager().AddChequeRechazado(chr.IDCHEQUE, chr.FECHA_RE.Value, chr.MOTIVO_RE,gastos:chr.GastosOrigen,ivaGastos:chr.IVAGastosOrigen,origenRechazo:chr.OrigenRechazo);
                    new ChequeRechazadoManager().SetChequeRechazadoTablaCheque(chr.IDCHEQUE, chr.MOTIVO_RE);
                }

                dataReturn.IdFacturaX = (int)H.IdFacturaX.Value;
                dataReturn.IdFactura = H.IDINT;
                dataReturn.CantidadItems = numeroItemNCD;
                dataReturn.IdNdp = _NcdPH.IDH;
                return dataReturn;
            }
        }
        public void SetStatusPendienteInMemory()
        {
            //H.StatusFactura = DocumentFIStatusManager.StatusHeader.Pendiente.ToString();
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
                var max = db.T0403_VENDOR_FACT_H.Where(c => c.TIPO == _tipoLx).Max(c => c.IdFacturaX);
                if (max != null)
                    return (int)max + 1;
                return 1;
            }
        }
        public T0403_VENDOR_FACT_H GetHeader()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == _idF.IdFactura);

            }
        }




    }
}
