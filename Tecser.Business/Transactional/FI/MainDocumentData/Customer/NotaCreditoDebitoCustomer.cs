using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Customer
{

    /// <summary>
    /// 2021.05.04 - Clase nueva para manejo exclusivo de Nota/Credito/Debito/Ajuste AX en T0300-T0301
    /// </summary>
    public class NotaCreditoDebitoCustomer
    {
        private T0300_NCD_H _h;
        private List<T0301_NCD_I> _i = new List<T0301_NCD_I>();
        private decimal _alicuotaIIBB;
        public enum TipoLx
        {
            L1,
            L2
        };
        public enum TipoDoc
        {
            NotaDebito,
            NotaCredito,
            DocumentoX,
            Ajuste,
        };
        public TipoLx MapLxFromString(string tipo)
        {
            if (tipo == "L1")
                return TipoLx.L1;
            return TipoLx.L2;
        }
        public string GetTdoc(TipoDoc tipoDoc)
        {
            switch (tipoDoc)
            {
                case TipoDoc.NotaDebito:
                    return "ND";
                case TipoDoc.NotaCredito:
                    return "NC";
                case TipoDoc.DocumentoX:
                    return "AX";
                case TipoDoc.Ajuste:
                    return "AJ";
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoDoc), tipoDoc, null);
            }
        }
        public decimal ImporteIVA { get; private set; }
        public decimal ImporteARS { get; private set; }
        public decimal ImporteUSD { get; private set; }
        public decimal BaseImponible { get; private set; }
        public void CreaHeaderMemory(TipoDoc tdoc, TipoLx lx, int idCliente, DateTime fecha, string comentario, string moneda = "ARS")
        {
            _h = new T0300_NCD_H();
            _h = new T0300_NCD_H()
            {
                IDH = -1,
                IdCliente = idCliente,
                ImporteARS = 0,
                ImporteUSD = 0,
                TC = new ExchangeRateManager().GetExchangeRate(fecha),
                LX = lx.ToString(),
                TDOC = GetTdoc(tdoc),
                COMENTARIO = comentario,
                FECHA = fecha,
                MON = moneda,
                RazonSocial = new CustomerManager().GetCustomerBillToData(idCliente).cli_rsocial,
                NDOC = "0000-00000000",
            };
        }

        public int AddItemMemory(decimal cantidad, string itemInterno, string descripcion, decimal unitario, bool iva,
            string gl, int? idChFacturaAplica)
        {
            if (_h.LX == "L2")
            {
                if (iva)
                    return -1;
            }

            var l1 = new T0301_NCD_I()
            {
                IDH = _h.IDH,
                IDITEM = 0,
                TDOC = _h.TDOC,
                NDOC = _h.NDOC,
                CANT = cantidad,
                ITEM = itemInterno,
                Descripcion = descripcion,
                MON = _h.MON,
                PUNITARIO = unitario,
                PTOTAL = Math.Round(unitario * cantidad, 2),
                IVA21 = iva,
                IDCHE = idChFacturaAplica,
                GL = gl
            };
            l1.PIVA = iva ? Math.Round(l1.PTOTAL * (decimal)0.21, 2) : 0;
            _i.Add(l1);
            RecalculaTotalesSegunItem();
            return _i.Count;
        }
        private void RecalculaTotalesSegunItem()
        {
            decimal importeArs = 0;
            decimal importeUsd = 0;
            decimal importeIVA = 0;
            int i = 1;
            foreach (var item in _i)
            {
                item.IDITEM = i;
                i++;
                importeIVA += item.PIVA; //Iva va en Moneda Origen.-
                if (_h.MON == "ARS")
                {
                    importeArs += (item.PTOTAL + importeIVA);
                    importeUsd += Math.Round(importeArs / _h.TC, 2);
                }
                else
                {
                    importeUsd += item.PTOTAL + importeIVA;
                    importeArs += Math.Round(importeUsd * _h.TC, 2);
                }
            }
            _h.ImporteARS = importeArs;
            _h.ImporteUSD = importeUsd;
            ImporteIVA = importeIVA;
            ImporteARS = importeArs;
            ImporteUSD = importeUsd;
        }

        /// <summary>
        /// Crea registro en T400 - From NCD  (NCD--> T400)
        /// Retorna IDFactura creado en T0400.-
        /// </summary>
        public int GenerateDocumentModuloFIRetornoCheque()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
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
                    StatusFactura = DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString(),
                    Impreso = false,
                    FacturaMoneda = "ARS",
                    TC = _h.TC,
                    TotalFacturaB = ImporteARS - ImporteIVA,
                    Descuento = 0,
                    DescuentoPorc = 0,
                    TotalImpo = 0,
                    TotalIVA21 = ImporteIVA,
                    TotalIIBB = 0,
                    IIBB_PORC = 0,
                    IIBB_TXT = null,
                    TotalFacturaN = ImporteARS,
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
                if (_h.LX == "L2")
                {
                    h.NumeroDoc = _h.NDOC;
                    h.PV_AFIP = null;
                    h.ND_AFIP = null;
                    h.StatusFactura = DocumentFIStatusManager.StatusHeader.Aprobada.ToString();
                }
                else
                {
                    h.TotalImpo = Math.Round(ImporteIVA / (decimal)0.21, 2);
                }
                db.T0400_FACTURA_H.Add(h);
                db.SaveChanges();
                foreach (var i in _i)
                {
                    var it = new T0401_FACTURA_I()
                    {
                        TC = h.TC,
                        CostoStd = 0,
                        DESC_REMITO = i.Descripcion,
                        FsrOV = null,
                        FsrOVItem = null,
                        IDFACTURAX = h.IDFACTURAX,
                        IDFactura = h.IDFACTURA,
                        GLI = null,
                        GLV = i.GL,
                        IDITEM = i.IDITEM,
                        ITEM = i.ITEM,
                        KGDESPACHADOS_R = i.CANT,
                        MONEDA_COTIZ = h.FacturaMoneda,
                        MONEDA_FACT = h.FacturaMoneda,
                        NAS = null,
                        NASSEG = null,
                        NUMFACTURA = h.NumeroDoc,
                        IVA21 = i.IVA21,
                    };
                    if (it.MONEDA_FACT == "ARS")
                    {
                        it.PRECIOU_FACT_ARS = i.PUNITARIO;
                        it.PRECIOT_FACT_ARS = i.PTOTAL;
                        it.PRECIOU_COTIZ = i.PUNITARIO;
                        it.PRECIOT_COTIZ = i.PTOTAL;
                        it.PRECIOU_FACT_USD = Math.Round(i.PUNITARIO / h.TC, 2);
                        it.PRECIOT_FACT_USD = Math.Round(i.PTOTAL / h.TC, 2);
                    }
                    else
                    {
                        it.PRECIOU_FACT_USD = i.PUNITARIO;
                        it.PRECIOT_FACT_USD = i.PTOTAL;
                        it.PRECIOU_COTIZ = i.PUNITARIO;
                        it.PRECIOT_COTIZ = i.PTOTAL;
                        it.PRECIOU_FACT_ARS = Math.Round(i.PUNITARIO * h.TC, 2);
                        it.PRECIOT_FACT_ARS = Math.Round(i.PTOTAL * h.TC, 2);
                    }
                    db.T0401_FACTURA_I.Add(it);
                }
                db.SaveChanges();
                _h.idFacturaT0400 = h.IDFACTURA;
                _h.idFacturaX = h.IDFACTURAX;
                var ncd = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _h.IDH);
                ncd.idFacturaT0400 = _h.idFacturaT0400;
                ncd.idFacturaX = _h.idFacturaX;
                db.SaveChanges();
                return h.IDFACTURA;
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

        public void UpdateDataAfterConta(string motivo, int numeroAsiento, int idCtaCte)
        {
            _h.COMENTARIO = motivo;
            _h.ASIENTO = numeroAsiento;
            _h.idCtaCte = idCtaCte;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _h.IDH);
                h.COMENTARIO = _h.COMENTARIO;
                h.ASIENTO = _h.ASIENTO;
                h.idCtaCte = _h.idCtaCte;
                db.SaveChanges();
            }
        }







        /// <summary>
        /// 
        /// </summary>
        public int SaveNewData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ix = db.T0301_NCD_I.Where(c => c.IDH == _h.IDH);
                if (ix.Any())
                {
                    db.T0301_NCD_I.RemoveRange(ix);
                    db.SaveChanges();
                }

                var hmax = db.T0300_NCD_H.Max(c => c.IDH);
                var iz = db.T0300_NCD_H.Where(c => c.TDOC == _h.TDOC && c.LX == _h.LX).ToList();
                _h.IDH = hmax + 1;
                _h.NDOC = CreateNumeroDocumento(hmax + 1, iz.Count + 1);
                _h.LOGUSER = GlobalApp.AppUsername;
                _h.LOGDATE = DateTime.Now;
                _h.TEMP = false;
                db.T0300_NCD_H.Add(_h);
                var rtnh = db.SaveChanges();
                if (rtnh > 0)
                {
                    SaveItemList(_h.IDH, _h.NDOC);
                    return _h.IDH;
                }
                return -1;
            }
        }
        public int RemoveItemsDataFromDb()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ix = db.T0301_NCD_I.Where(c => c.IDH == _h.IDH);
                if (ix.Any())
                {
                    db.T0301_NCD_I.RemoveRange(ix);
                    return db.SaveChanges();
                }
                return 0;
            }
        }
        public int RemoveHeaderDataFromDb()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int z = 0;
                var ii = db.T0301_NCD_I.Where(c => c.IDH == _h.IDH);
                if (ii.Any())
                {
                    db.T0301_NCD_I.RemoveRange(ii);
                    z = db.SaveChanges();

                }
                var ix = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _h.IDH);
                if (ix != null)
                {
                    db.T0300_NCD_H.Remove(ix);
                    return db.SaveChanges() + z;
                }
                return 0;
            }
        }
        private int SaveItemList(int idh, string numeroDoc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var il = db.T0301_NCD_I.Where(c => c.IDH == idh).ToList();
                if (il.Any())
                {
                    db.T0301_NCD_I.RemoveRange(il);
                    db.SaveChanges();
                }
                foreach (var i in _i)
                {
                    i.IDH = idh;
                    i.NDOC = numeroDoc;
                    db.T0301_NCD_I.Add(i);
                }
                return db.SaveChanges();
            }
        }

        public int AddSingleItem(T0301_NCD_I itemx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var i0 = db.T0301_NCD_I.SingleOrDefault(c => c.IDH == itemx.IDH && c.IDITEM == itemx.IDITEM);
                if (i0 != null)
                    return -1;

                db.T0301_NCD_I.Add(i0);
                return db.SaveChanges();
            }
        }

        private string CreateNumeroDocumento(int idh, int idcount)
        {
            if (_h.LX == "L1")
            {
                if (_h.TDOC == "NC" || _h.TDOC == "ND")
                {
                    //Numero Documento generado por AFIP
                    return "AFIP-" + idh.ToString("00000000");
                }
                else
                {
                    //documento ajuste internor X
                    return "0001-" + idcount.ToString("00000000");
                }
            }
            else
            {
                return "0020-" + idh.ToString("00000000");
            }
        }
        public void AddIdComprobanteAsociado(int idComprobante, bool updatedB = false)
        {
            _h.idFacturaAsociada = idComprobante;
            _h.PeriodoAjusteDesde = null;
            _h.PeriodoAjusteHasta = null;

            if (!updatedB)
                return;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _h.IDH);
                if (h == null)
                    return;
                h.idFacturaAsociada = _h.idFacturaAsociada;
                h.PeriodoAjusteDesde = null;
                h.PeriodoAjusteHasta = null;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Metodo SaveData incluye update desde el objeto de este campo
        /// </summary>
        public void AddPeriodoComprobanteAsociado(DateTime desde, DateTime hasta, bool updatedB = false)
        {
            _h.idFacturaAsociada = null;
            _h.PeriodoAjusteDesde = desde;
            _h.PeriodoAjusteHasta = hasta;
            if (!updatedB)
                return;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _h.IDH);
                if (h == null)
                    return;
                h.idFacturaAsociada = null;
                h.PeriodoAjusteDesde = _h.PeriodoAjusteDesde;
                h.PeriodoAjusteHasta = _h.PeriodoAjusteHasta;
                db.SaveChanges();
            }
        }
        public List<T0301_NCD_I> GetItemList()
        {
            return _i;
        }
        public T0300_NCD_H GetHeader()
        {
            return _h;
        }
        public void UpdateNumeroDocumentoAfterCAE(string numeroDocumento)
        {
            _h.NDOC = numeroDocumento;
            foreach (var ii in _i)
            {
                ii.NDOC = numeroDocumento;
            }
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _h.IDH);
                h.NDOC = numeroDocumento;
                db.SaveChanges();
                var i = db.T0301_NCD_I.Where(c => c.IDH == _h.IDH).ToList();
                foreach (var ii in i)
                {
                    ii.NDOC = numeroDocumento;
                }
                db.SaveChanges();
            }
        }

    }
}
