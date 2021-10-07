using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.GESCO;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.CtaCte
{
    //2018.03.28
    //Gestion de all inforacion de Cuentas Corrientes de Clientes
    //Tablas 201,202,207,208
    public class CtaCteCustomer : CtaCteBase
    {
        protected T0201_CTACTE RecordDetalle = new T0201_CTACTE();
        protected T0202_CTACTESALDOS RecordSummary = new T0202_CTACTESALDOS();
        public CtaCteCustomer(int idCliente) : base(idCliente)
        {
            //Constructor 1
        }
        
        public List<T0201_CTACTE> GetListaMovimientosCtaCte(bool includeL1, bool includeL2, bool soloSaldoPendiente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = new List<T0201_CTACTE>();
                var rt = new List<T0201_CTACTE>();
                if (soloSaldoPendiente)
                {
                    if (includeL1)
                    {
                        x = db.T0201_CTACTE.Where(c => c.IDCLI == IdEntidad && c.TIPO == "L1" && c.SALDOFACTURA != 0).ToList();
                        rt.AddRange(x);
                    }

                    if (includeL2)
                    {
                        x = db.T0201_CTACTE.Where(c => c.IDCLI == IdEntidad && c.TIPO == "L2" && c.SALDOFACTURA != 0).ToList();
                        rt.AddRange(x);
                    }
                }
                else
                {
                    //con saldo o sin saldo
                    if (includeL1)
                    {
                        x = db.T0201_CTACTE.Where(c => c.IDCLI == IdEntidad && c.TIPO == "L1").ToList();
                        rt.AddRange(x);
                    }

                    if (includeL2)
                    {
                        x = db.T0201_CTACTE.Where(c => c.IDCLI == IdEntidad && c.TIPO == "L2").ToList();
                        rt.AddRange(x);
                    }
                }

                return rt.OrderByDescending(c => c.Fecha.Value).ToList();
            }
        }
        private decimal GetSaldoSinImputar(string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == IdEntidad && c.TIPOCUENTA == tipoLx)
                    .ToList();
                if (data.Count == 0)
                    return 0;
                return data.Sum(c => c.MONTO.Value);
            }
        }
        public override Resultado GetResultadoCtaCte(string tipoLx)
        {
            var x = new Resultado()
            {
                //Inicializa valores por default.-
                TipoLx = tipoLx,
                SaldoColor = ColorError,
                SaldoDetalle = -99999999999,
                SaldoResumen = -99999999999,
                SaldoOK = false,
                SaldoSinImputar = -99999999999,
            };

            x.SaldoSinImputar = GetSaldoSinImputar(tipoLx);


            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0201_CTACTE.Where(c => c.IDCLI == IdEntidad && c.TIPO.ToUpper().Equals(tipoLx.ToUpper()))
                        .ToList();
                if (data.Count == 0)
                {
                    x.SaldoDetalle = 0;
                }
                else
                {
                    x.SaldoDetalle = (decimal)data.Sum(c => c.SALDOFACTURA);
                }

                var dataResumen =
                    db.T0202_CTACTESALDOS.SingleOrDefault(
                        c => c.IDCLIENTE == IdEntidad && c.CUENTATIPO.ToUpper().Equals(tipoLx.ToUpper()));

                if (dataResumen == null)
                {
                    x.SaldoResumen = 0;
                }
                else
                {
                    if (dataResumen.DEUDA_TOT_ARS == null)
                        dataResumen.DEUDA_TOT_ARS = 0;
                    db.SaveChanges();
                }
                x.SaldoResumen = dataResumen == null ? 0 : dataResumen.DEUDA_TOT_ARS.Value;
                if (x.SaldoDetalle == x.SaldoResumen)
                {
                    x.SaldoOK = true;
                    x.SaldoColor = ColorOk;
                }
                else
                {
                    x.SaldoOK = false;
                    x.SaldoColor = ColorError;
                }
                return x;
            }
        }
        public override bool UpdateSaldoCtaCteResumen(string tipoLx, decimal importeConSigno, string moneda = "ARS", decimal? exchangeRate = null, DateTime? fechaUltimaFacturaEmitida=null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (exchangeRate == null) exchangeRate = new ExchangeRateManager().GetExchangeRate(DateTime.Today);

                var data = db.T0202_CTACTESALDOS.SingleOrDefault(c => c.IDCLIENTE == IdEntidad && c.CUENTATIPO == tipoLx);
                if (data == null)
                {
                    //no existe data ctacte = toma base =0;
                    var x = new T0202_CTACTESALDOS()
                    {
                        IDCLIENTE = IdEntidad,
                        CUENTATIPO = tipoLx,
                        DEUDA_USD = 0,
                        DEUDA_ARS = 0,
                        DEUDA_TOT_ARS = 0,
                        TC = exchangeRate,
                        LCREDITO = CustomerCreditLimiteManager.GetManualCreditLimit(IdEntidad),
                        NDIAS = 0,
                        NMON = "ARS",
                        NSALDO = 0,
                        UFACT = null,
                        LogDate = DateTime.Now,
                        LogUsuario = GlobalApp.AppUsername,
                        UPAGO = null,
                        FACTPEND = false,
                        NUFACTN = null
                    };
                    db.T0202_CTACTESALDOS.Add(x);
                    db.SaveChanges();
                    data = db.T0202_CTACTESALDOS.SingleOrDefault(c => c.IDCLIENTE == IdEntidad && c.CUENTATIPO == tipoLx);
                    if (data == null) return false;
                }

                if (data.DEUDA_ARS == null) data.DEUDA_ARS = 0;
                if (data.DEUDA_USD == null) data.DEUDA_USD = 0;
                if (data.DEUDA_TOT_ARS == null) data.DEUDA_TOT_ARS = 0;
                
                if (moneda == @"ARS")
                {
                    data.DEUDA_ARS += importeConSigno;
                }
                else
                {
                    data.DEUDA_USD += importeConSigno;
                }

                data.DEUDA_TOT_ARS = Math.Round((data.DEUDA_USD.Value * exchangeRate.Value) + data.DEUDA_ARS.Value, 2);
                data.TC = exchangeRate;
                data.LCREDITO = CustomerCreditLimiteManager.GetCreditLimit(IdEntidad);
                data.LogDate = DateTime.Now;
                data.LogUsuario = GlobalApp.AppUsername;
                //
                data.NDIAS = 0;
                data.NUFACTN = "0000-00000000";
                //
                if (fechaUltimaFacturaEmitida != null)
                    data.UFACT = fechaUltimaFacturaEmitida;


                return db.SaveChanges() > 0;
            }
        }
        public override int AddCtaCteDetalleRecord(string tipoDocumento, string lx, DateTime fechaDoc,
            string numeroDocumento, string strDocumentoInterno, string moneda, decimal importeOrigen, decimal exchangeRate,
            decimal saldoDocumento, decimal importeARS = 0, int idDocAlternativo = 0, int idDocumentoPrincipal = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = new T0201_CTACTE()
                {
                    IDCTACTE = db.T0201_CTACTE.Max(c => c.IDCTACTE) + 1,
                    IDCLI = IdEntidad,
                    TDOC = tipoDocumento,
                    TIPO = lx,
                    Fecha = fechaDoc,
                    NUMDOC = numeroDocumento,
                    MONEDA = moneda,
                    IMPORTE_ORI = importeOrigen,
                    LogDate = DateTime.Now,
                    LogUsuario = GlobalApp.AppUsername,
                    TC = exchangeRate,
                    DOC_INTERNO = strDocumentoInterno,
                    SALDOFACTURA = saldoDocumento,
                    CK = null,
                    IDDOC = idDocumentoPrincipal,
                    IDT1 = idDocumentoPrincipal,
                    IDT2 = idDocAlternativo,
                };
                if (x.MONEDA == "ARS")
                {
                    x.IMPORTE_ARS = importeOrigen;
                }
                else
                {
                    if (importeARS == 0)
                    {
                        x.IMPORTE_ARS = importeOrigen * exchangeRate;
                    }
                    else
                    {
                        x.IMPORTE_ARS = importeARS;
                    }
                }
                db.T0201_CTACTE.Add(x);
                return db.SaveChanges() > 0 ? x.IDCTACTE : 0;
            }
        }
        public override bool UpdateImporteSaldoFactura(int idCtaCte, decimal nuevoSaldoFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacte = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                if (ctacte == null)
                    return false;

                ctacte.SALDOFACTURA = nuevoSaldoFactura;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        
        public int AddSinImputarRecord(DateTime fecha, int idReferencia, string moneda, decimal importe, string tipoLx, string tipoDoc, string numeroRecibo, int idCtaCte, int idNcd=-1)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t208 = new T0208_COB_NO_APLICADA
                {
                    CLIENTE = IdEntidad,
                    FECHA = fecha,
                    ID = db.T0208_COB_NO_APLICADA.Max(c => c.ID) + 1,
                    IDRECIBO = idReferencia,
                    NRECIBO = numeroRecibo,
                    MONEDA = moneda,
                    MONTO = importe,
                    TIPOCUENTA = tipoLx,
                    TIPODOC = tipoDoc,   //COB o NCD
                    IDCTACTE = idCtaCte,
                };

                if (idNcd < 1)
                {
                    t208.IDNCD = null;
                }
                else
                {
                    t208.IDNCD = idNcd;
                }
                db.T0208_COB_NO_APLICADA.Add(t208);
                return db.SaveChanges() > 0 ? t208.ID : 0;
            }
        }
        



        public int AddNewRecordT207CompleteNew(string tipoDocumentoXx, string tipoLx, int idCtaCte,
            int idFactura, string numeroDocumento, int idCliente,
            int numeroSplit, DateTime fechaDocumento, string moneda, decimal montoDocumento, decimal montoRestante,
            decimal montoAplicado, int ztermDias, string numeroRecibo = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = new T0207_SPLITFACTURAS()
                {
                    INTDOC = db.T0207_SPLITFACTURAS.Max(c => c.INTDOC) + 1,
                    TDOC = tipoDocumentoXx,
                    IDCTACTE = idCtaCte,
                    IDDOC = idFactura,
                    NDOC = numeroDocumento,
                    FACTSPLIT = numeroSplit,
                    FACT_MONEDA = moneda,
                    ImporteDocumento = montoDocumento,
                    ImporteAImputar = montoRestante,
                    MontoImputado = montoAplicado,
                    TIPO = tipoLx,
                    CLIENTE = idCliente,
                    FECHA_FACT = fechaDocumento,
                    ZTERM = ztermDias,
                    FECHA_VENC = fechaDocumento.AddDays(ztermDias),
                    //DIAS_VENC
                    NRECIBO = numeroRecibo,
                    //PFECHA=
                    //XCOMENTARIO
                };
                db.T0207_SPLITFACTURAS.Add(h);
                if (db.SaveChanges() > 0)
                    return (int)h.INTDOC;
                return 0;
            }
        }
        
        private int AddRecordDocumentT207CompleteConstructor(string tipoDocumento, string tipoLx, int idCtaCte,
            int idDocumento, string numeroDocumento, int idCliente,
            int numeroSplit, DateTime fechaDocumento, string moneda, decimal montoDocumento, decimal montoRestante,
            decimal montoAplicado, int ztermDias, string numeroRecibo = null)
        {
            //todo: evaluar si no hay que mover a otro lado o reemplazar
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = new T0207_SPLITFACTURAS()
                {
                    INTDOC = db.T0207_SPLITFACTURAS.Max(c => c.INTDOC) + 1,
                    TDOC = tipoDocumento,
                    IDCTACTE = idCtaCte,
                    IDDOC = idDocumento,
                    NDOC = numeroDocumento,
                    FACTSPLIT = numeroSplit,
                    FACT_MONEDA = moneda,
                    ImporteDocumento = montoDocumento,
                    ImporteAImputar = montoRestante,
                    MontoImputado = montoAplicado,
                    TIPO = tipoLx,
                    CLIENTE = idCliente,
                    FECHA_FACT = fechaDocumento,
                    ZTERM = ztermDias,
                    FECHA_VENC = fechaDocumento.AddDays(ztermDias),
                    //DIAS_VENC
                    NRECIBO = numeroRecibo,
                    //PFECHA=
                    //XCOMENTARIO,
                    
                    
                };
                db.T0207_SPLITFACTURAS.Add(h);
                if (db.SaveChanges() > 0)
                    return (int)h.INTDOC;
                return 0;
            }
        }
        public int AddRecordDocumentT0207FromIdCtaCte(int idCtaCte)
        {
            //todo evaluar si no hay que mover a otro lado o reemplezar
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataCtaCte = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);

                if (dataCtaCte.TDOC.Contains("AJ") || dataCtaCte.TDOC.Contains("AX"))
                {
                    return AddRecordDocumentT207CompleteConstructor(dataCtaCte.TDOC, dataCtaCte.TIPO, idCtaCte, 0,
                           dataCtaCte.NUMDOC, dataCtaCte.IDCLI, 1, dataCtaCte.Fecha.Value, dataCtaCte.MONEDA,
                           dataCtaCte.IMPORTE_ARS, dataCtaCte.IMPORTE_ARS, 0, 0);
                }
                else
                {
                    var idFacturaX = 0;
                    idFacturaX = dataCtaCte.DOC_INTERNO.Contains("-") ? 0 : Convert.ToInt32(dataCtaCte.DOC_INTERNO);
                    if (idFacturaX == 0)
                    {
                        return AddRecordDocumentT207CompleteConstructor(dataCtaCte.TDOC, dataCtaCte.TIPO, idCtaCte, 0,
                            dataCtaCte.NUMDOC, dataCtaCte.IDCLI, 1, dataCtaCte.Fecha.Value, dataCtaCte.MONEDA,
                            dataCtaCte.IMPORTE_ARS, dataCtaCte.IMPORTE_ARS, 0, 0);
                    }
                    else
                    {
                        var facturaH = db.T0400_FACTURA_H.Where(c => c.IDFACTURAX == idFacturaX).ToList();

                        if (facturaH.Count() > 1)
                            throw new InvalidDataException("Existe mas de un documento con este mismo IDFACTURAX");

                        if (!facturaH.Any())
                            throw new InvalidDataException("El IdFacturaX no se corresponde con el DOC_INTERNO de T0201");


                        return AddRecordDocumentT207CompleteConstructor(facturaH[0].TIPO_DOC, dataCtaCte.TIPO, idCtaCte, idFacturaX,
                            dataCtaCte.NUMDOC, dataCtaCte.IDCLI, 1, dataCtaCte.Fecha.Value, dataCtaCte.MONEDA,
                            dataCtaCte.IMPORTE_ARS, dataCtaCte.IMPORTE_ARS, 0, 0);
                    }
                }
            }
        }
     
        //Agrega un registro nuevo de CtaCteT0202
        public override void AddNewCtaCteSummaryRecord(string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacte =
                    db.T0202_CTACTESALDOS.SingleOrDefault(c => c.IDCLIENTE == IdEntidad && c.CUENTATIPO == tipoLx);
                if (ctacte != null)
                {
                    return; //no se puede agregar registro.-
                }
                else
                {
                    var credito = new CreditAndRiskControl().GetCreditLimit(IdEntidad);
                    var x = new T0202_CTACTESALDOS()
                    {
                        CUENTATIPO = tipoLx,
                        TC = 1,
                        DEUDA_ARS = 0,
                        DEUDA_USD = 0,
                        FACTPEND = false,
                        IDCLIENTE = base.IdEntidad,
                        LCREDITO = credito,
                        LogDate = DateTime.Today,
                        LogUsuario = GlobalApp.AppUsername,
                        NDIAS = 0,
                        NMON = "ARS",
                        NSALDO = 0,
                        NUFACTN = "0000-00000000",
                        UFACT = null,
                        UPAGO = null,
                        DEUDA_TOT_ARS = 0
                    };
                    db.T0202_CTACTESALDOS.Add(x);
                }
                db.SaveChanges();
            }
        }
        public T0201_CTACTE GetRegistro201(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
            }
        }
    }
}



