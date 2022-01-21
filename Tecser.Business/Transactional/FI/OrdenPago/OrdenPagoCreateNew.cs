using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.FI.OrdenPago
{
    /// <summary>
    /// 2021.11.24 New class to manage OPnew
    /// </summary>
    public class OrdenPagoCreateNew
    {
        public List<T0212_OrdenPagoDocumentos> FacturasOP = new List<T0212_OrdenPagoDocumentos>();
        public List<T0211_OrdenPagoItems> ItemsPagoOP = new List<T0211_OrdenPagoItems>();
        public List<T0213_OrdenPagoRetenciones> Retenciones = new List<T0213_OrdenPagoRetenciones>();
        public List<DsCreditosOP> Creditos=new List<DsCreditosOP>();
        private List<T0203_CTACTE_PROV_IMPU> ImputacionesFa = new List<T0203_CTACTE_PROV_IMPU>();
        public List<int?> ListaIdChequesOp = new List<int?>();
        public OPHeaderManager Header;
        public readonly int VendorId;
        public DateTime FechaOP;
        public decimal TC;
        public string Moneda;
        public string TipoLx;
        public string Observaciones;
        private bool _autoLoadCredito = true;
        public OrdenPagoStatus.StatusOP StatusOP { get; private set; }
        public OrdenPagoCreateNew(int idOP)
        {
            Header= new OPHeaderManager(idOP);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0210_OrdenPagoHeader.SingleOrDefault(c => c.IdOP == Header.NumeroOP);
                if (h == null) return;
                //This.Clase
                VendorId = h.IdProveedor;
                FechaOP = h.Fecha;
                TC = h.TC;
                Moneda = h.Moneda;
                TipoLx = h.Lx;
                Observaciones = h.Observacion;
                StatusOP = OrdenPagoStatus.MapStatusFromText(h.Status);
                FacturasOP = db.T0212_OrdenPagoDocumentos.Where(c => c.IdOP == Header.NumeroOP).ToList();
                ItemsPagoOP = db.T0211_OrdenPagoItems.Where(c => c.IdOP == Header.NumeroOP).ToList();
                Retenciones = db.T0213_OrdenPagoRetenciones.Where(c => c.IdOP == Header.NumeroOP).ToList();
                ImputacionesFa = db.T0203_CTACTE_PROV_IMPU.Where(c => c.NUMDOC == Header.NumeroOP.ToString() && c.TCODE.StartsWith("OP") && c.TDOC !="OPT").ToList();
                //
                var cred = db.T0203_CTACTE_PROV_IMPU.Where(c => c.NUMDOC == Header.NumeroOP.ToString() && c.TCODE == "OPQ").ToList();
                int i = 1;
                foreach (var cx in cred)
                {
                    var c1 = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == cx.CTACTE1);
                    var tcred = new DsCreditosOP()
                    {
                        IdCtaCte = cx.CTACTE1,
                        Fecha = c1.Fecha,
                        Id = i,
                        Importe = Math.Abs(c1.SALDOFACTURA),
                        NumDoc = cx.NUMDOC,
                        TDoc = c1.TDOC,
                        PendienteImputar = Math.Abs(cx.MONTO_IMPU),
                    };
                    Creditos.Add(tcred);
                    i++;
                }

                if (Creditos.Any())
                {
                    Header.SetImporteCreditoPendienteImputar(Creditos.Sum(c=>c.PendienteImputar));
                }
                else
                {
                    Header.SetImporteCreditoPendienteImputar(0);
                }

                Header.SetImporteCheques(0);
                Header.SetImporteEfectivo(0);
                Header.SetImporteOtros(0);
                decimal importeCh = 0;
                decimal importeEf = 0;

                if (ItemsPagoOP.Any())
                {
                    var x = ItemsPagoOP.Where(c => c.EsCheque).ToList();
                    foreach (var ch in x)
                    {
                        importeCh += ch.ImporteOP;
                        if (ch.ChIdCartera != null)
                        {
                            ListaIdChequesOp.Add(ch.ChIdCartera.Value);
                        }
                    }
                    Header.SetImporteCheques(importeCh);
                    
                    x = ItemsPagoOP.Where(c => c.CuentaItem == "ARS").ToList();
                    if (x.Any())
                    {
                        importeEf = x.Sum(c => c.ImporteOP);
                        Header.SetImporteEfectivo(importeEf);
                    }
                    var otros = ItemsPagoOP.Sum(c => c.ImporteOP) - importeCh - importeEf;
                    Header.SetImporteOtros(otros);
                }
            }
        }
        public OrdenPagoCreateNew(int idVendor,string lx)
        {
            StatusOP = OrdenPagoStatus.StatusOP.Inicial;
            VendorId = idVendor;
            Moneda = "ARS";
            TipoLx = "L0";
        }

        public bool UpdateOrdenPagoData()
        {
            bool headerOK = true;
            bool itemsOK = true;
            bool factuOK = true;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (Header == null) return false;
                var h = db.T0210_OrdenPagoHeader.SingleOrDefault(c => c.IdOP == Header.NumeroOP);
                if (h == null) return false;

                h.TC = Header.TipoCambio;
                h.Moneda = Header.Moneda;
                h.Fecha = Header.FechaOP;
                h.Periodo = new PeriodoConversion().GetPeriodo(FechaOP);
                h.LogDate = DateTime.Now;
                h.LogUser = GlobalApp.AppUsername;
                h.LogPreparo = GlobalApp.AppUsername;
                h.ImporteOP = Header.ImporteOrdenPago;
                h.Observacion = Observaciones;
                h.AplicaCredito = Creditos.Any();
                h.ImporteCreditosAplicados = Header.ImporteCreditos;
                h.Status = StatusOP.ToString();
                h.ImporteFacturas = Header.ImporteFacturas;
                h.SaldoSinAplicarOP = Header.ImporteSaldoImpago;
                h.Temp = true;
                h.ImporteCheques = Header.ImporteCheques;
                h.ImporteEfectivo = Header.ImporteEfectivo;
                h.ImporteOtros = Header.ImporteOtros;
                h.ImporteRetencionens = Header.ImporteRetenciones;
                headerOK= db.SaveChanges() > 0;

                var i = db.T0211_OrdenPagoItems.Where(c => c.IdOP == Header.NumeroOP).ToList();
                foreach (var item in i)
                {
                    db.T0211_OrdenPagoItems.Remove(item);
                    db.SaveChanges();
                    db.SaveChanges();
                }

                int xit = 0;
                foreach (var item in ItemsPagoOP)
                {
                    item.T0210_OrdenPagoHeader = h;
                    db.Entry(item.T0210_OrdenPagoHeader).State = EntityState.Unchanged;
                    db.T0211_OrdenPagoItems.Add(item);
                    xit+=db.SaveChanges();
                }
                itemsOK = xit == ItemsPagoOP.Count;
                
                
                var f = db.T0212_OrdenPagoDocumentos.Where(c => c.IdOP == Header.NumeroOP).ToList();
                foreach (var factu in f)
                {
                    db.T0212_OrdenPagoDocumentos.Remove(factu);
                    db.SaveChanges();
                    db.SaveChanges();
                }
                foreach (var factu in FacturasOP)
                {
                    factu.T0210_OrdenPagoHeader = h;
                    db.Entry(factu.T0210_OrdenPagoHeader).State = EntityState.Unchanged;
                    db.T0212_OrdenPagoDocumentos.Add(factu);
                    db.SaveChanges();
                }
               
                
                var r = db.T0213_OrdenPagoRetenciones.Where(c => c.IdOP == Header.NumeroOP).ToList();
                foreach (var reten in r)
                {
                    db.T0213_OrdenPagoRetenciones.Remove(reten);
                    db.SaveChanges();
                    db.SaveChanges();
                }

                foreach (var reten in Retenciones)
                {
                    reten.T0210_OrdenPagoHeader = h;
                    db.Entry(reten.T0210_OrdenPagoHeader).State = EntityState.Unchanged;
                    db.T0213_OrdenPagoRetenciones.Add(reten);
                    db.SaveChanges();
                }
               

                //imputacion de creditos temporal
                var cred = db.T0203_CTACTE_PROV_IMPU
                    .Where(c => c.TCODE == "OPQ" && c.NUMDOC == Header.NumeroOP.ToString()).ToList();
                if (cred.Any())
                {
                    db.T0203_CTACTE_PROV_IMPU.RemoveRange(cred);
                    db.SaveChanges();
                }
                db.SaveChanges();
                foreach (var cx in Creditos)
                {
                    var t = new T0203_CTACTE_PROV_IMPU()
                    {
                        CTACTE1 = cx.IdCtaCte,
                        CTACTE2 = cx.IdCtaCte, //al contabilizar -> reemplazar por idctacte.op
                        MONTO_IMPU = cx.PendienteImputar,
                        LogDate = DateTime.Today,
                        LogUser = GlobalApp.AppUsername,
                        TCODE = "OPQ",
                        GLPAGO = "0.0.0.0", //creditos
                        NAS_PAGO = null,
                        IDPROV = Header.IdProveedor,
                        TDOC = "OPT",
                        NUMDOC = Header.NumeroOP.ToString(),
                        Temp = true
                    };
                    db.T0203_CTACTE_PROV_IMPU.Add(t);
                    db.SaveChanges();
                }

                //imputacion a facturas
                var impu = db.T0203_CTACTE_PROV_IMPU.Where(c => c.TCODE == "OP0" && c.NUMDOC == Header.NumeroOP.ToString() &&  c.NAS_PAGO==null).ToList();
                if (impu.Any())
                {
                    db.T0203_CTACTE_PROV_IMPU.RemoveRange(impu);
                    db.SaveChanges();
                }
                db.SaveChanges();

                foreach (var i1 in ImputacionesFa.Where(c=>c.MONTO_IMPU>0))
                {
                    var t = new T0203_CTACTE_PROV_IMPU()
                    {
                        CTACTE1 = i1.CTACTE1,
                        CTACTE2 = i1.CTACTE2,
                        MONTO_IMPU = i1.MONTO_IMPU,
                        TDOC = i1.TDOC,
                        LogDate = DateTime.Now,
                        LogUser = GlobalApp.AppUsername,
                        NUMDOC = Header.NumeroOP.ToString(),
                        IDPROV = i1.IDPROV,
                        NAS_PAGO = i1.NAS_PAGO,
                        TCODE = "OP0",
                        GLPAGO = i1.GLPAGO,
                        Temp = true,
                    };
                    db.T0203_CTACTE_PROV_IMPU.Add(t);
                    db.SaveChanges();
                }

                return (factuOK && itemsOK && headerOK);
            }
        }
        private bool SaveHeader()
        {
            if (Header == null) return false;
            if (Header.NumeroOP <= 0) return false;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t = new T0210_OrdenPagoHeader()
                {
                    IdOP = Header.NumeroOP,
                    TC = Header.TipoCambio,
                    Moneda = Header.Moneda,
                    IdCtaCte = -1,
                    Fecha = Header.FechaOP,
                    Finalizado = false,
                    Lx = Header.Lx,
                    Nas = null,
                    Periodo = new PeriodoConversion().GetPeriodo(FechaOP),
                    LogDate = DateTime.Now,
                    LogUser = GlobalApp.AppUsername,
                    LogPreparo = GlobalApp.AppUsername,
                    LogGenero =GlobalApp.AppUsername,
                    ImporteOP = Header.ImporteOrdenPago,
                    Observacion = Observaciones,
                    AplicaCredito = Creditos.Any(),
                    ImporteCreditosAplicados = Header.ImporteCreditos,
                    IdProveedor = Header.IdProveedor,
                    Status = StatusOP.ToString(),
                    ImporteFacturas = Header.ImporteFacturas,
                    SaldoSinAplicarOP = Header.ImporteSaldoImpago,
                    Temp = true,
                    ImporteCheques = Header.ImporteCheques,
                    ImporteEfectivo = Header.ImporteEfectivo,
                    ImporteOtros = Header.ImporteOtros,
                    ImporteRetencionens = Header.ImporteRetenciones,
                    DiasPPFactura = null,
                    DiasPPItemsPago = null,
                    TipoOPDoc = "OP", //todo: ver si ser genera otro tipo de OP (ejemplo solo imputacion?)
                };
                db.T0210_OrdenPagoHeader.Add(t);
                return (db.SaveChanges() > 0);
            }
        }
        public bool AsignaNumeroOrdenPago()
        {
            if (Header == null) return false;
            if (StatusOP != OrdenPagoStatus.StatusOP.Inicial) return false;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (TipoLx == "L1")
                {
                    var data = db.T000.SingleOrDefault(c => c.ID == "OP1");
                    var numero = Convert.ToInt32(data.VALUE) + 1;
                    if (Header.SetNumeroOP(numero))
                    {
                        data.VALUE = numero.ToString();
                        db.SaveChanges();
                        StatusOP = OrdenPagoStatus.StatusOP.Proceso;
                        return SaveHeader();
                    }
                }
                else
                {
                    int xNumero;
                    var prefijoOp = "2" + new PeriodoConversion().GetYearYy(Convert.ToDateTime(Header.FechaOP)) +
                                new PeriodoConversion().GetMesMm(Convert.ToDateTime(Header.FechaOP));
                    var data = db.T0210_OP_H.FirstOrDefault(c => c.Periodo.Equals(Header.Periodo) && c.TIPO.Equals("L2"));
                    if (data != null)
                    {
                        xNumero = db.T0210_OP_H.Where(c => c.Periodo.Equals(Header.Periodo) && c.TIPO.Equals("L2"))
                            .OrderByDescending(c => c.IDOP).FirstOrDefault().IDOP + 1;
                    }
                    else
                    {
                        xNumero = Convert.ToInt32(prefijoOp + "001");
                    }
                    if (Header.SetNumeroOP(xNumero))
                    {
                        StatusOP = OrdenPagoStatus.StatusOP.Proceso;
                        return SaveHeader();
                    }
                }
                return false;
            }
        }
        private void IncializaHeader(string tipoLX,bool autoLoadCredito)
        {
            if (Header == null)
            {
                Header = new OPHeaderManager(VendorId,tipoLX,FechaOP,Moneda,TC);
                this.TipoLx = tipoLX;
                StatusOP = OrdenPagoStatus.StatusOP.Inicial;
            }

            if (Creditos.Any() == false && autoLoadCredito)
            {
                AddAllCreditosToOP();
            }
                
        }
        public void InicializaHeader(int idVendor, string lx, DateTime fechaOrdenPago, string moneda, decimal tC,bool AddCreditosAuto)
        {
            if (Header == null)
            {
                FechaOP = fechaOrdenPago;
                TC = tC;
                Moneda = moneda;
                TipoLx = lx;
                Header = new OPHeaderManager(VendorId, TipoLx, FechaOP, Moneda, TC);
                StatusOP = OrdenPagoStatus.StatusOP.Inicial;
                if (AddCreditosAuto) AddAllCreditosToOP();
            }
        }
        public void AddImporteCashToOP(decimal importe, string idCuenta, decimal tasaConversion=1)
        {
            //IncializaHeader(TipoLx);
            var P = new CuentasManager().GetSpecificCuentaInfo(idCuenta);
            if (this.Moneda == P.CUENTA_MONEDA)
                tasaConversion = 1;
            var item = new T0211_OrdenPagoItems()
            {
                MonedaItem = P.CUENTA_MONEDA,
                ChBanco = null,
                ChFecha = null,
                ChNumero = null,
                EsCheque = false,
                ECheque = false,
                IdItem = ItemsPagoOP.Count+1,
                GLCuenta = P.GLMAP,
                TextoAlterno = null,
                IdOP = Header.NumeroOP,
                ImporteOP = importe * tasaConversion,
                ImporteItem = importe,
                ChIdCartera = -1,
                CuentaItem = idCuenta
            };
            ItemsPagoOP.Add(item);
            Header.SetImportePagoCash(item.ImporteOP);
        }

        public void AddChequeEmitido(string cuenta, DateTime fechaAcreditacion, string numeroCheque, bool esECheque,decimal importe)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var P = new CuentasManager().GetSpecificCuentaInfo(cuenta);
                var item = new T0211_OrdenPagoItems()
                {
                    MonedaItem = "ARS",
                    ChBanco = cuenta,
                    ChFecha = fechaAcreditacion,
                    ChNumero = numeroCheque,
                    EsCheque = true,
                    ECheque = esECheque,
                    IdItem = ItemsPagoOP.Count + 1,
                    GLCuenta = P.GLMAP,
                    TextoAlterno = null,
                    IdOP = Header.NumeroOP,
                    ImporteOP = importe,
                    ImporteItem = importe,
                    ChIdCartera = -1,
                    CuentaItem = "CHE",
                };
                ItemsPagoOP.Add(item);
                Header.SetImportePagoCheque(item.ImporteOP);
            }
        }

        public void AddChequeCarteraToOp(int idCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                var P = new CuentasManager().GetSpecificCuentaInfo("CHE");
                var item = new T0211_OrdenPagoItems()
                {
                    MonedaItem = "ARS",
                    ChBanco = ch.CHE_BANCO,
                    ChFecha = ch.CHE_FECHA,
                    ChNumero = ch.CHE_NUMERO,
                    EsCheque = true,
                    ECheque = ch.Echeque,
                    IdItem = ItemsPagoOP.Count + 1,
                    GLCuenta = P.GLMAP,
                    TextoAlterno = null,
                    IdOP = Header.NumeroOP,
                    ImporteOP = ch.IMPORTE.Value,
                    ImporteItem = ch.IMPORTE.Value,
                    ChIdCartera = idCheque,
                    CuentaItem = "CHE",
                };
                ItemsPagoOP.Add(item);
                Header.SetImportePagoCheque(item.ImporteOP);
                ListaIdChequesOp.Add(idCheque);
            }
        }
        public void RemoveItemPago(int iditem)
        {
            var itemPago = ItemsPagoOP.SingleOrDefault(c => c.IdItem == iditem);
            if (itemPago == null) return;
            if (itemPago.EsCheque == false)
            {
                Header.RemoveImportePagoCash(itemPago.ImporteOP);
            }
            else
            {
                Header.RemoveImportePagoCheques(itemPago.ImporteOP);
                if (itemPago.ChIdCartera != null)
                {
                    var x = ListaIdChequesOp.Find(c => c.Value == itemPago.ChIdCartera.Value);
                    ListaIdChequesOp.Remove(x);
                }
            }
            ItemsPagoOP.Remove(itemPago);
            var a = 1;
            foreach (var i in ItemsPagoOP)
            {
                i.IdItem = a;
                a++;
            }
        }

        #region ManejoFacturas
        public bool AddFacturasToOP(int idctacte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fx = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idctacte);
                IncializaHeader(fx.TIPO,_autoLoadCredito); //carga creditos si existen y no fueron cargadosñlñl
                var item = new T0212_OrdenPagoDocumentos()
                {
                    IdOP = Header.NumeroOP,
                    IdCtaCte = idctacte,
                    IdFactura = Convert.ToInt32(fx.DOC_INTERNO),
                    LX = fx.TIPO,
                    ImporteOri = fx.IMPORTE_ORI,
                    TCDoc = fx.TC,
                    MonedaDoc = fx.MONEDA,
                    ImputadoOP = 0,
                    SaldoAdeudado = 0,
                };

                if (Header.Moneda == "ARS")
                {
                    item.ImporteOP = fx.IMPORTE_ARS;
                    if (fx.MONEDA == "ARS")
                    {
                        item.SaldoAdeudado = fx.SALDOFACTURA;
                        item.ImputadoOP = 0;
                    }
                    else
                    {
                        item.SaldoAdeudado = Math.Round(fx.SALDOFACTURA * fx.TC, 2);
                        item.ImputadoOP = 0;
                    }
                }
                else
                {
                    //Orden de Pago en USD
                    item.ImporteOP = Math.Round(fx.SALDOFACTURA / fx.TC, 2);
                    if (fx.MONEDA == "ARS")
                    {
                        item.SaldoAdeudado = Math.Round(fx.SALDOFACTURA / fx.TC, 2);
                        item.ImporteOP = 0;
                    }
                    else
                    {
                        item.SaldoAdeudado = fx.SALDOFACTURA;
                        item.ImporteOP = 0;
                    }
                }
                var p = FacturasOP.SingleOrDefault(c => c.IdCtaCte == item.IdCtaCte);
                if (p != null) return false;
                FacturasOP.Add(item);
                Header.SetImporteFactura(item.SaldoAdeudado);
                return true;
            }
        }
        public void RemoveFacturasOP(int idctacte)
        {
            var ix = FacturasOP.SingleOrDefault(c => c.IdCtaCte == idctacte);
            Header.RemoveImporteFactura(ix.SaldoAdeudado);
            FacturasOP.Remove(ix);
            //Desimputa all porque no  se puede saber cuanto es credito - etc
            decimal montoDesimputado = 0;
            decimal montoCreditos = 0;
            foreach (var fx in FacturasOP)
            {
                montoDesimputado += fx.ImputadoOP;
                fx.ImputadoOP = 0;
            }
            //Actualizacion de Credito
            foreach (var cx in Creditos)
            {
                montoCreditos += cx.Importe;
                cx.PendienteImputar = cx.Importe;
            }

            ImputacionesFa.Clear();
            Header.SetImporteCreditoPendienteImputar(montoCreditos);
            Header.SetValoresImputacion(0);
            
            if (FacturasOP.Any() == false)
            {
                RemoveAllCredits();
            }
        }
        #endregion

        #region ManejoRetenciones
        public enum TipoRetencion
        {
            Ganancias,
            Arba,
            IVA
        }
        public void RemoveRetencion(int iditem)
        {
            var ix = Retenciones.SingleOrDefault(c => c.IdItemRetencion == iditem);
            Header.RemoveImporteRetenciones(ix.ImporteRetencion);
            Retenciones.Remove(ix);
            int a = 1;
            foreach (var i in Retenciones)
            {
                i.IdItemRetencion = a;
                a++;
            }
        }
        public void AddRetencion(TipoRetencion tipoRetencion, decimal baseImponible, decimal importe, decimal alicuota)
        {
            string identificador;
            GLAccountManagement.GLAccount tipoImpuesto; //solo para llevar la referencia -
            switch (tipoRetencion)
            {
                case TipoRetencion.Ganancias:
                    identificador = "RGA";
                    tipoImpuesto = GLAccountManagement.GLAccount.RetencionGS;
                    break;
                case TipoRetencion.Arba:
                    identificador = "RIB";
                    tipoImpuesto = GLAccountManagement.GLAccount.RetencionIIBB;
                    break;
                case TipoRetencion.IVA:
                    identificador = "RIVA";
                    tipoImpuesto = GLAccountManagement.GLAccount.RetencionIVA;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoRetencion), tipoRetencion, null);
            }

            //var glAccount = GLAccountManagement.GetGLAccount(tipoImpuesto);
            //var glAccountDescription = GLAccountManagement.GetGLDescriptionFromT135(glAccount);
            
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cuenta = db.T0150_CUENTAS.SingleOrDefault(c => c.ID_CUENTA == identificador);
                var t = new T0213_OrdenPagoRetenciones()
                {
                    BaseImponibleCalculo = baseImponible,
                    ImporteRetencion = importe,
                    Alicuota = alicuota,
                    RetencionTipo = identificador,
                    GL = cuenta.GLMAP,
                    IdItemRetencion = Retenciones.Count + 1,
                    IdOP = -1,
                };
                Retenciones.Add(t);
                if (Header == null)
                {
                    IncializaHeader("L1",true);
                }
                Header.SetImporteRetenciones(t.ImporteRetencion);
            }
        }
        public void UpdateRetencion(int idItem, decimal baseImpo, decimal alicuota, decimal importe)
        {
            var data = Retenciones.SingleOrDefault(c => c.IdItemRetencion == idItem);
            Header.SetImporteRetenciones(data.ImporteRetencion *-1); //resta el valor existente
            data.Alicuota = alicuota;
            data.BaseImponibleCalculo = baseImpo;
            data.ImporteRetencion = importe;
            Header.SetImporteRetenciones(importe); //suma el valor existente
        }
        #endregion
        public bool DesimputacionTotal()
        {
            if (Header == null) return false;
            //recompone creditos 
            decimal creditosSinImputar = 0;

            foreach (var impu0 in ImputacionesFa)
            {
                if (impu0.TDOC == "OPC")
                {
                    var cred = Creditos.SingleOrDefault(c => c.IdCtaCte == impu0.CTACTE2);
                    cred.PendienteImputar -= impu0.MONTO_IMPU;
                    creditosSinImputar += Math.Abs(impu0.MONTO_IMPU);
                }
            }


            if (Creditos.Any())
            {
                Header.SetImporteCreditoPendienteImputar(Creditos.Sum(c => c.PendienteImputar));
            }

            //Header.SetImporteCreditoPendienteImputar(creditosSinImputar);
            Header.SetValoresImputacion(0);
            foreach (var i in FacturasOP)
            {
                i.ImputadoOP = 0; //reset imputacion
            }
            
            if (this.StatusOP == OrdenPagoStatus.StatusOP.Proceso)
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    //foreach (var impu in ImputacionesFa)
                    //{
                    //    var i = db.T0203_CTACTE_PROV_IMPU.SingleOrDefault(c =>
                    //        c.CTACTE1 == impu.CTACTE1 && c.CTACTE2 == impu.CTACTE2 && c.NUMDOC == impu.NUMDOC);
                    //    if (i != null) db.T0203_CTACTE_PROV_IMPU.Remove(i);
                    //    db.SaveChanges();
                    //}
                }
            }
            ImputacionesFa.Clear();
            return true;
        }
        public bool ImputacionAutomatica()
        {
            DesimputacionTotal();
            if (Header == null) return false;
            if (Header.ImporteFacturas <= 0) return false; //nada a donde imputar
            if ((Header.ImporteOrdenPago + Header.ImporteCreditos) <= 0) return false; //nada que imputar

            //primero imputa creditos anteriores (OP) y luego los items de pago
            var z = ImputacionesFa;
            decimal totalImputado = 0;
            foreach (var cred in Creditos)
            {
                decimal importeCred = Math.Abs(cred.PendienteImputar);
                foreach (var f in FacturasOP)
                {
                    if (importeCred > 0)
                    {
                        var xsaldoAdeudado = f.SaldoAdeudado - f.ImputadoOP;
                        decimal imputadoAhora = 0;
                        if (xsaldoAdeudado >= importeCred)
                        {
                            f.ImputadoOP += importeCred;
                            imputadoAhora = importeCred;
                            importeCred = 0;
                        }
                        else
                        {
                            f.ImputadoOP += xsaldoAdeudado;
                            imputadoAhora = xsaldoAdeudado;
                            importeCred = importeCred - xsaldoAdeudado;
                        }
                        cred.PendienteImputar = importeCred;

                        var impu = new T0203_CTACTE_PROV_IMPU()
                        {
                            CTACTE1 = f.IdCtaCte,
                            CTACTE2 = cred.IdCtaCte,    //ctacte op credito
                            TDOC = "OPC",               //OP Credito
                            GLPAGO = null,
                            LogDate = DateTime.Now,
                            LogUser = GlobalApp.AppUsername,
                            NUMDOC =  Header.NumeroOP.ToString(),
                            IDPROV = Header.IdProveedor,
                            TCODE = "OP0",
                            NAS_PAGO = null, //numero nas OP ori
                            MONTO_IMPU = imputadoAhora
                        };
                        ImputacionesFa.Add(impu);
                        totalImputado += imputadoAhora;
                    }
                }
            }
            Header.SetImporteCreditoPendienteImputar(Creditos.Any() ? Creditos.Sum(c => c.PendienteImputar) : 0);

            //ahora hacer lo mismo de arriba pero con los items de imputacion (sumarizados) + atencion retenciones
            decimal ImportesImputar = Header.ImporteOrdenPago;
            foreach (var f in FacturasOP)
            {
                if (ImportesImputar > 0)
                {
                    var xsaldoAdeudado = f.SaldoAdeudado - f.ImputadoOP;
                    decimal imputadoAhora = 0;
                    if (xsaldoAdeudado > ImportesImputar)
                    {
                        f.ImputadoOP += ImportesImputar;
                        imputadoAhora = ImportesImputar;
                        ImportesImputar = 0;
                    }
                    else
                    {
                        f.ImputadoOP += xsaldoAdeudado;
                        imputadoAhora = xsaldoAdeudado;
                        ImportesImputar = ImportesImputar - xsaldoAdeudado;
                    }

                    var impu = new T0203_CTACTE_PROV_IMPU()
                    {
                        CTACTE1 = f.IdCtaCte,       //ctacte factura que imputo
                        CTACTE2 = Header.NumeroOP,  //idctacte esta OP [aun no esta defindo]
                        TDOC = "OPT",               //OP Temporal [aun]
                        GLPAGO = null,
                        LogDate = DateTime.Now,
                        LogUser = GlobalApp.AppUsername,
                        NUMDOC = Header.NumeroOP.ToString(),
                        IDPROV = Header.IdProveedor,
                        TCODE = "OP0",
                        NAS_PAGO = null, //numero nas OP ori
                        MONTO_IMPU = imputadoAhora
                    };
                    ImputacionesFa.Add(impu);
                    totalImputado += imputadoAhora;
                }
            }
            Header.SetValoresImputacion(totalImputado);
            return true;
        }
        public void AddAllCreditosToOP()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                decimal creditosCargados = 0;
                decimal pendienteImputar = 0;
                Creditos.Clear();
                var creditosNc = db.T0203_CTACTE_PROV.Where(c => c.IDPROV == Header.IdProveedor && c.TIPO == Header.Lx && c.SALDOFACTURA<0).ToList();
                var i = 1;
                foreach (var x in creditosNc)
                {
                    if (CheckCreditoAddedInDifferentOP(x.IDCTACTE) == string.Empty)
                    {
                        var t = new DsCreditosOP()
                        {
                            Fecha = x.Fecha,
                            Importe = Math.Abs(x.SALDOFACTURA),
                            NumDoc = x.NUMDOC,
                            TDoc = x.TDOC,
                            IdCtaCte = x.IDCTACTE,
                            Id = i,
                            PendienteImputar = Math.Abs(x.SALDOFACTURA)
                        };
                        creditosCargados += t.Importe;
                        pendienteImputar += t.PendienteImputar;

                        Creditos.Add(t);
                        i++;
                    }
                }
                Header.SetImporteCredito(creditosCargados);
                Header.SetImporteCreditoPendienteImputar(Creditos.Any() ? Creditos.Sum(c => c.PendienteImputar) : 0);
            }
        }
        public void RemoveAllCredits()
        {
            Creditos.Clear();
            Header.ResetCreditos();
        }
        public void RemoveCredito(int id)
        {
            var ix = Creditos.SingleOrDefault(c => c.Id == id);
            Header.RemoveImporteCredito(ix.Importe);

            foreach (var impx in ImputacionesFa.Where(c=>c.CTACTE2 == ix.IdCtaCte))
            {
                impx.MONTO_IMPU = 0;
            }

            //var t = ImputacionesFa.FindAll(c => c.MONTO_IMPU == 0).ToList();
            //if (t.Any())
            //{
                ImputacionesFa.RemoveAll(c=>c.MONTO_IMPU==0);
            //}

            Creditos.Remove(ix);
            int a = 1;
            foreach (var i in Creditos)
            {
                i.Id = a;
                a++;
            }
            Header.SetImporteCreditoPendienteImputar(Creditos.Any() ? Creditos.Sum(c => c.PendienteImputar) : 0);
        }
        public bool GeneraOrdenPago()
        {
            if (UpdateOrdenPagoData()==false)return false;
            var proveedorRs = VendorManager.GetVendorRazonSocial(Header.IdProveedor);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //* Generacion de Asiento Contable *
                AsientoBase.IdentificacionAsiento resultado = new AsientoBase.IdentificacionAsiento();
                var asientoN = new AsientoOrdenPagoNew(Header.NumeroOP, "OP1");
                resultado = asientoN.GeneraAsientoOP();
                int nas = resultado.IdDocu;
                if (nas == 0)
                {
                    return false;
                }
                
                //* Generacion de Subdiario de Caja
                foreach (var item in ItemsPagoOP)
                {
                    var cta = new CuentasManager().GetSpecificCuentaInfo(item.CuentaItem);
                    if (item.EsCheque)
                    {
                        if (item.ChIdCartera != null)
                        {
                            if (item.ChIdCartera > 0)
                            {
                                new ChequesManager().SetNoDisponible_OP(item.ChIdCartera.Value, Header.NumeroOP, nas);
                                new SubdiarioCajaManager().WriteToDb(item.CuentaItem, Header.FechaOP,
                                    SubdiarioCajaManager.PC.Proveedor,
                                    Header.IdProveedor, "OP", Header.NumeroOP.ToString(),
                                    "OP #" + Header.NumeroOP.ToString() + " -" + proveedorRs,
                                    Header.Moneda, 0, item.ImporteItem, Header.Lx,
                                    "OP1", nas, item.GLCuenta, idCheque: item.ChIdCartera.Value);
                            }
                        }
                        else
                        {
                            //cheques emitidos propios no se registran en Reg hasta que se acrediten
                        }
                    }
                    else
                    {
                        string transferenciaOrigen;
                        if (cta.CUENTA_TIPO.ToUpper() == "TRANSF")
                        {
                            transferenciaOrigen = "Transferencia desde " + cta.CUENTA_DESC;
                        }
                        else
                        {
                            transferenciaOrigen = string.Empty;
                        }

                        new SubdiarioCajaManager().WriteToDb(item.CuentaItem, Header.FechaOP,
                            SubdiarioCajaManager.PC.Proveedor,
                            Header.IdProveedor, "OP", Header.NumeroOP.ToString(),
                            "OP #" + Header.NumeroOP.ToString() + " -" + proveedorRs,
                            Header.Moneda, 0, item.ImporteItem, Header.Lx,
                            "OP1", nas, item.GLCuenta, cuentaDestinoTransferencia: transferenciaOrigen);
                    }
                }

                //* Registracion Subdiario de Caja --> Retenciones
                foreach (var ret in Retenciones)
                {
                    //registra retenciones en REG
                    string descripcion = string.Empty;
                    switch (ret.RetencionTipo) 
                    {
                        case "RIB":
                            descripcion = "Retencion IIBB";
                            break;
                        case "RIVA":
                            descripcion = "Retencion IVA";
                            break;
                        case "RGA":
                            descripcion = "Retencion Ganancias";
                            break;
                        default:
                            break;
                    }
                    new SubdiarioCajaManager().WriteToDb(ret.RetencionTipo, Header.FechaOP,
                        SubdiarioCajaManager.PC.Proveedor,
                        Header.IdProveedor, "OP", Header.NumeroOP.ToString(),
                        "OP #" + Header.NumeroOP.ToString() + " -" + proveedorRs,
                        Header.Moneda, 0, ret.ImporteRetencion, Header.Lx,
                        "OP1", nas, ret.GL);
                }

                //-->Acutaliza Cuentas Corrientes
                var ctacte = new CtaCteVendor(Header.IdProveedor);
                var idCtaCte = ctacte.AddCtaCteDetalleRecord("OP", Header.Lx, Header.FechaOP, OPNumeroConversion.GetNumeroOP(Header.NumeroOP,Header.Lx),
                    Header.NumeroOP.ToString(), Header.Moneda, Header.ImporteOrdenPago * -1,
                    Header.TipoCambio, Header.ImporteTotalNoImputado * -1, idDocumentoPrincipal: Header.NumeroOP);
                ctacte.UpdateSaldoCtaCteResumen(Header.Lx, Header.ImporteOrdenPago * -1, Header.Moneda, Header.TipoCambio);
                Header.SetAsientoCtaCte(nas,idCtaCte);

                //-->Cheques Emitidos T0159
                foreach (var chpropio in ItemsPagoOP.Where(c=>c.EsCheque && c.ChIdCartera<=0))
                {
                    var ch = new GestionChequesEmitidos().SetNewRecord(chpropio.ChNumero, Header.FechaOP,
                        chpropio.ChFecha.Value, chpropio.ImporteItem, chpropio.ChBanco, Header.NumeroOP,
                        Header.IdProveedor, chpropio.ECheque, nas, Header.Lx);
                }

                //-->Imputaciones y Creditos 
                var c0 = db.T0203_CTACTE_PROV_IMPU
                    .Where(c => c.NUMDOC == Header.NumeroOP.ToString()).ToList();
                db.T0203_CTACTE_PROV_IMPU.RemoveRange(c0);
                db.SaveChanges();
                
                foreach (var r0 in ImputacionesFa.Where(c=>c.MONTO_IMPU>0).ToList())
                {
                    if (r0.TDOC == "OPC")
                    {
                        //Se trata de un credito -- actualiza saldo del credito (203)
                        var f = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == r0.CTACTE2);
                        f.SALDOFACTURA = f.SALDOFACTURA + r0.MONTO_IMPU;
                        db.SaveChanges();
                    }
                    else
                    {
                        //Imputacion de Valores/Retencionens a Facturas
                        r0.CTACTE2 = idCtaCte;
                        r0.TDOC = "OPI";
                    }

                    r0.NUMDOC = OPNumeroConversion.GetNumeroOP(Header.NumeroOP, Header.Lx);
                    r0.LogDate = DateTime.Now;
                    r0.LogUser = GlobalApp.AppUsername;
                    r0.NAS_PAGO = nas;
                    r0.TCODE = "OP1";
                    db.T0203_CTACTE_PROV_IMPU.Add(r0);
                    db.SaveChanges();

                    var f2 = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == r0.CTACTE1);
                    f2.SALDOFACTURA -= r0.MONTO_IMPU;
                    db.SaveChanges();
                }

                var h = db.T0210_OrdenPagoHeader.SingleOrDefault(c => c.IdOP == Header.NumeroOP);
                h.IdCtaCte = idCtaCte;
                h.Status = OrdenPagoStatus.StatusOP.Generada.ToString();
                h.Nas = nas;
                db.SaveChanges();
            }
            ////
            //aca vienen las estadisticas de pago
            //todo: paymentsStats!
            return true;
        }
        string CheckCreditoAddedInDifferentOP(int idctacteCredito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t = db.T0203_CTACTE_PROV_IMPU.SingleOrDefault(c =>
                    c.CTACTE1 == idctacteCredito && c.CTACTE2 == idctacteCredito && c.NUMDOC != Header.NumeroOP.ToString());
                if (t == null)
                    return string.Empty;
                return t.NUMDOC;
            }
        }

        /// <summary>
        /// Recalcula valores header ante desfasajes?
        /// </summary>
        private void RecalculaValoresHeader()
        {

        }
        
        public void SetGenerada()
        {
            StatusOP = OrdenPagoStatus.StatusOP.Generada;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0210_OrdenPagoHeader.SingleOrDefault(c => c.IdOP == Header.NumeroOP);
                x.Status = StatusOP.ToString();
                db.SaveChanges();
            }
        }



    }
}
