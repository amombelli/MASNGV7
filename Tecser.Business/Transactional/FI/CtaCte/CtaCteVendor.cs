using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.CtaCte
{
    //public class Gestion Cuenta Corriente
    //Tablas 201,202,203,204,207,208
    public class CtaCteVendor : CtaCteBase
    {
        public CtaCteVendor(int idCliProv) : base(idCliProv)
        {

        }

        public override Resultado GetResultadoCtaCte(string tipoLx)
        {
            var x = new Resultado()
            {
                TipoLx = tipoLx,
                SaldoColor = ColorError,
                SaldoDetalle = -99999999999,
                SaldoResumen = -99999999999,
                SaldoOK = false,
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0203_CTACTE_PROV.Where(c => c.IDPROV == IdEntidad && c.TIPO.ToUpper().Equals(tipoLx.ToUpper()))
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
                    db.T0204_CTACTESALDOS_PROV.SingleOrDefault(
                        c => c.IDPROV == IdEntidad && c.CUENTATIPO.ToUpper().Equals(tipoLx.ToUpper()));

                //if (dataResumen.DEUDA_TOT_ARS == null)
                //    dataResumen.DEUDA_TOT_ARS = 0;


                if (dataResumen == null)
                {
                    x.SaldoResumen = 0;
                }
                else
                {
                    if (dataResumen.DEUDA_TOT_ARS == null)
                    {
                        x.SaldoResumen = 0;
                    }
                    else
                    {
                        x.SaldoResumen = dataResumen.DEUDA_TOT_ARS.Value;
                    }
                }

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
        public override bool UpdateSaldoCtaCteResumen(string tipoLx, decimal importeConSigno, string moneda = "ARS", decimal? exchangeRate = null, DateTime? fechaUltimaFactura = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0204_CTACTESALDOS_PROV.SingleOrDefault(c => c.IDPROV == IdEntidad && c.CUENTATIPO == tipoLx);
                if (data == null)
                {
                    AddNewCtaCteSummaryRecord(tipoLx);
                    data = db.T0204_CTACTESALDOS_PROV.SingleOrDefault(c => c.IDPROV == IdEntidad && c.CUENTATIPO == tipoLx);
                }

                if (exchangeRate == null)
                    exchangeRate = data.TC;

                if (moneda == "ARS")
                {
                    data.DEUDA_ARS += importeConSigno;
                }
                else
                {
                    data.DEUDA_USD += importeConSigno;
                }
                data.DEUDA_TOT_ARS = (data.DEUDA_USD * exchangeRate) + data.DEUDA_ARS;
                return db.SaveChanges() > 0;
            }
        }

        public override int AddCtaCteDetalleRecord(string tipoDocumento, string lx, DateTime fechaDoc,
            string numeroDocumento, string docInterno, string moneda, decimal importeOrigen, decimal exchangeRate,
            decimal saldoDocumento, decimal importeARS = 0, int idDocAlternativo = 0, int idDocumentoPrincipal = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = new T0203_CTACTE_PROV()
                {
                    IDCTACTE = db.T0203_CTACTE_PROV.Max(c => c.IDCTACTE) + 1,
                    IDPROV = IdEntidad,
                    TDOC = tipoDocumento,
                    TIPO = lx,
                    Fecha = fechaDoc,
                    NUMDOC = numeroDocumento,
                    MONEDA = moneda,
                    IMPORTE_ORI = importeOrigen,
                    LogDate = DateTime.Now,
                    LogUsuario = Environment.UserName,
                    TC = exchangeRate,
                    DOC_INTERNO = docInterno,
                    SALDOFACTURA = saldoDocumento,
                    ZTERM = new VendorManager().GetZterm(IdEntidad, lx),
                    ZOP = false,
                    IDDOC = idDocumentoPrincipal,
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

                if (idDocAlternativo > 0)
                    x.IdFacturaX = idDocAlternativo;

                db.T0203_CTACTE_PROV.Add(x);

                if (db.SaveChanges() > 0)
                    return x.IDCTACTE;
                return 0;
            }
        }
        public override bool UpdateImporteSaldoFactura(int idCtaCte, decimal nuevoSaldoFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                if (ctacte == null)
                    return false;

                ctacte.SALDOFACTURA = nuevoSaldoFactura;
                return db.SaveChanges() > 0;
            }
        }
        public override void AddNewCtaCteSummaryRecord(string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacte =
                    db.T0204_CTACTESALDOS_PROV.SingleOrDefault(c => c.IDPROV == IdEntidad && c.CUENTATIPO == tipoLx);
                if (ctacte != null)
                    return; //no se puede agregar registro.-

                var x = new T0204_CTACTESALDOS_PROV()
                {
                    CUENTATIPO = tipoLx,
                    TC = 1,
                    DEUDA_ARS = 0,
                    DEUDA_USD = 0,
                    IDPROV = base.IdEntidad,
                    LCREDITO = 1,
                    LogDate = DateTime.Today,
                    LogUsuario = Environment.UserDomainName,
                    NDIAS = 0,
                    NMON = "ARS",
                    NSALDO = 1,
                    NUFACTN = "0000-00000000",
                    UFACT = DateTime.Today,
                    UPAGO = DateTime.Today,
                    //FACTPEND = facturaPendiente,
                    DEUDA_TOT_ARS = 0,
                };
                db.T0204_CTACTESALDOS_PROV.Add(x);
                db.SaveChanges();
            }
        }

        public void UpdateData403InCtaCteRecord(int idCtaCte, int idFactura, decimal idFacturaX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var record = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                record.IdFacturaX = Convert.ToInt32(idFacturaX);
                record.DOC_INTERNO = idFactura.ToString();
                db.SaveChanges();
            }
        }



    }
}
