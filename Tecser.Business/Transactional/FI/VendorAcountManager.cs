using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class VendorAccountManager
    {
        public VendorAccountManager()
        {
        }
        //por supuesto caducarla!!
        public VendorAccountManager(int idVendor)
        {
            _idVendor = idVendor;
        }

        private int _idVendor;
        public bool SaldoL1OK;
        public bool SaldoL2OK;
        public Color ColorSaldoL1;
        public Color ColorSaldoL2;

        public decimal GetSaldoL1FromT0203(int idVendor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = from saldo in db.T0203_CTACTE_PROV
                             group saldo by new { saldo.IDPROV, saldo.TIPO }
                    into grp
                             where grp.Key.TIPO.Equals("L1") && grp.Key.IDPROV == idVendor
                             select new
                             {
                                 Saldo = grp.Sum(x => x.SALDOFACTURA)
                             };
                return result.FirstOrDefault() == null ? 0 : result.FirstOrDefault().Saldo;
            }
        }
        public decimal GetSaldoL2FromT0203(int idVendor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var result = from saldo in db.T0203_CTACTE_PROV
                             group saldo by new { saldo.IDPROV, saldo.TIPO }
                    into grp
                             where grp.Key.TIPO.Equals("L2") && grp.Key.IDPROV == idVendor
                             select new
                             {
                                 Saldo = grp.Sum(x => x.SALDOFACTURA)
                             };
                if (result.FirstOrDefault() == null)
                {
                    return 0;
                }
                else
                {
                    return result.FirstOrDefault().Saldo;
                }
            }
        }

        /// <summary>
        /// Devuelve el Saldo del Proveedor desde la tabla T0204[TOTALES] y setea variable SaldoL1OK en true o false si coincide con el detalle T0203. Setea tambien color para el textbox
        /// </summary>
        /// <returns></returns>
        public decimal GetSaldoL1(int idVendor)
        {
            decimal resultadoSaldo = 0;

            var result =
                new TecserData(GlobalApp.CnnApp).T0204_CTACTESALDOS_PROV.SingleOrDefault(
                    c => c.IDPROV == idVendor && c.CUENTATIPO.ToUpper() == "L1");
            if (result != null)
            {
                if (result.DEUDA_TOT_ARS == null)
                {
                    resultadoSaldo = (decimal)0;
                }
                else
                {
                    resultadoSaldo = (decimal)result.DEUDA_TOT_ARS;
                }
            }


            if (resultadoSaldo == GetSaldoL1FromT0203(idVendor))
            {
                SaldoL1OK = true;
                ColorSaldoL1 = Color.GreenYellow;
            }
            else
            {
                SaldoL1OK = false;
                ColorSaldoL1 = Color.Red;
            }
            return resultadoSaldo;
        }
        /// <summary>
        /// Devuelve el Saldo del Proveedor desde la tabla T0204[TOTALES] y setea variable SaldoL1OK en true o false si coincide con el detalle T0203. Setea tambien color para el textbox
        /// </summary>
        /// <param name="idVendor"></param>
        /// <returns></returns>
        public decimal GetSaldoL2(int idVendor)
        {
            decimal resultadoSaldo = 0;
            var result =
                new TecserData(GlobalApp.CnnApp).T0204_CTACTESALDOS_PROV.SingleOrDefault(
                    c => c.IDPROV == idVendor && c.CUENTATIPO.ToUpper() == "L2");
            if (result != null)
            {
                if (result.DEUDA_TOT_ARS == null)
                {
                    resultadoSaldo = (decimal)0.00;
                }
                else
                {
                    resultadoSaldo = (decimal)result.DEUDA_TOT_ARS;
                }

            }

            if (resultadoSaldo == GetSaldoL2FromT0203(idVendor))
            {
                SaldoL2OK = true;
                ColorSaldoL2 = Color.GreenYellow;
            }
            else
            {
                SaldoL2OK = false;
                ColorSaldoL2 = Color.Red;
            }
            return resultadoSaldo;
        }

        public List<T0203_CTACTE_PROV> DetalleFacturasPendientePago(int idProveedor, string lx = null)
        {
            if (string.IsNullOrEmpty(lx) == true)
            {
                var lista =
                    new TecserData(GlobalApp.CnnApp).T0203_CTACTE_PROV.Where(c => c.IDPROV == idProveedor && c.SALDOFACTURA != 0)
                        .OrderBy(c => c.Fecha)
                        .ToList();
                return lista;
            }
            else
            {
                var lista =
                    new TecserData(GlobalApp.CnnApp).T0203_CTACTE_PROV.Where(
                        c => c.IDPROV == idProveedor && c.SALDOFACTURA != 0 && c.TIPO.ToUpper().Equals(lx.ToUpper()))
                        .OrderBy(c => c.Fecha)
                        .ToList();
                return lista;
            }
        }

        public List<T0203_CTACTE_PROV> DetalleFacturas(int idProveedor, string lx = null)
        {
            if (string.IsNullOrEmpty(lx) == true)
            {
                var lista =
                    new TecserData(GlobalApp.CnnApp).T0203_CTACTE_PROV.Where(c => c.IDPROV == idProveedor)
                        .OrderBy(c => c.Fecha)
                        .ToList();
                return lista;
            }
            else
            {
                var lista =
                    new TecserData(GlobalApp.CnnApp).T0203_CTACTE_PROV.Where(
                        c => c.IDPROV == idProveedor && c.TIPO.ToUpper().Equals(lx.ToUpper()))
                        .OrderBy(c => c.Fecha)
                        .ToList();
                return lista;
            }
        }

        /// <summary>
        /// Actualiza el saldo 204 desde un nuevo documento 203 Agregado
        /// </summary>
        /// <returns></returns>
        public bool UpdateSaldo204_FromNewDocument203Added(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data203 = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                if (data203 == null)
                    return false;

                var saldoAnterior = db.T0204_CTACTESALDOS_PROV.SingleOrDefault(
                    c => c.IDPROV == data203.IDPROV && c.CUENTATIPO.ToUpper().Equals(data203.TIPO.ToUpper()));

                if (saldoAnterior == null)
                {
                    //no existe el registro saldo T204 - Lo crea
                    var data204 = new T0204_CTACTESALDOS_PROV()
                    {
                        IDPROV = data203.IDPROV,
                        CUENTATIPO = data203.TIPO.ToUpper(),
                        LogDate = DateTime.Now,
                        LogUsuario = Environment.UserDomainName
                    };
                    if (data203.MONEDA == "ARS")
                    {
                        data204.DEUDA_ARS = data203.IMPORTE_ARS;
                        data204.DEUDA_USD = 0;
                        data204.DEUDA_TOT_ARS = data203.IMPORTE_ARS;
                    }
                    else
                    {
                        data204.DEUDA_ARS = 0;
                        data204.DEUDA_USD = data203.IMPORTE_ORI;
                        data204.DEUDA_TOT_ARS = data203.IMPORTE_ARS;
                    }
                    db.T0204_CTACTESALDOS_PROV.Add(data204);
                    if (db.SaveChanges() > 0)
                        return true;
                    return false;

                }
                else
                {
                    //Existe registro T204
                    if (data203.MONEDA == "ARS")
                    {
                        saldoAnterior.DEUDA_ARS += data203.IMPORTE_ARS;
                        saldoAnterior.DEUDA_TOT_ARS += data203.IMPORTE_ARS;
                    }
                    else
                    {
                        saldoAnterior.DEUDA_USD += data203.IMPORTE_ORI;
                        saldoAnterior.DEUDA_TOT_ARS += data203.IMPORTE_ARS;
                    }
                    saldoAnterior.TC = data203.TC;
                    saldoAnterior.UFACT = data203.Fecha;
                    saldoAnterior.NUFACTN = data203.NUMDOC;
                    saldoAnterior.LogDate = DateTime.Now;
                    saldoAnterior.LogUsuario = Environment.UserName;
                }
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        public bool UpdateSaldoCtaCte(int idProv, string lx, string moneda, decimal nuevoSaldo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var saldoDocumentos =
                    Convert.ToDecimal(
                        db.T0203_CTACTE_PROV.Where(x => x.IDPROV == idProv && x.TIPO == lx).Sum(c => c.SALDOFACTURA));

                var provCtaCte =
                    db.T0204_CTACTESALDOS_PROV.SingleOrDefault(c => c.CUENTATIPO == lx && c.IDPROV == idProv);


                if (provCtaCte == null)
                {
                    var data = new T0204_CTACTESALDOS_PROV
                    {
                        IDPROV = idProv,
                        CUENTATIPO = lx,
                        LogDate = DateTime.Now,
                        LogUsuario = Environment.UserDomainName
                    };

                    if (moneda == "ARS")
                    {
                        data.DEUDA_ARS = nuevoSaldo;
                        data.DEUDA_USD = 0;
                        data.DEUDA_TOT_ARS = nuevoSaldo;
                    }
                    else
                    {
                        data.DEUDA_ARS = 0;
                        data.DEUDA_USD = nuevoSaldo;
                        data.DEUDA_TOT_ARS = nuevoSaldo * new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                    }
                    db.T0204_CTACTESALDOS_PROV.Add(data);
                }
                else
                {
                    if (moneda == "ARS")
                    {
                        provCtaCte.DEUDA_ARS = nuevoSaldo;
                        provCtaCte.DEUDA_TOT_ARS = provCtaCte.DEUDA_USD *
                                                   new ExchangeRateManager().GetExchangeRate(DateTime.Today) +
                                                   provCtaCte.DEUDA_ARS;
                    }
                    else
                    {
                        provCtaCte.DEUDA_USD = nuevoSaldo;
                        provCtaCte.DEUDA_TOT_ARS = provCtaCte.DEUDA_USD *
                                                   new ExchangeRateManager().GetExchangeRate(DateTime.Today) +
                                                   provCtaCte.DEUDA_ARS;
                    }
                }

                db.SaveChanges();
                return saldoDocumentos == nuevoSaldo;
                //Si los saldos de la suma de documentos = al nuevo saldo 
                //Devuelve true;
            }
        }
        public int AddDocumentT203(T0203_CTACTE_PROV docu)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                docu.IDCTACTE = db.T0203_CTACTE_PROV.Max(c => c.IDCTACTE) + 1;
                docu.LogDate = DateTime.Now;
                docu.LogUsuario = Environment.UserName;
                db.T0203_CTACTE_PROV.Add(docu);
                if (db.SaveChanges() > 0)
                    return docu.IDCTACTE;
                return -1;
            }
        }
        private bool AddDocumentT0204(T0204_CTACTESALDOS_PROV data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var check =
                    db.T0204_CTACTESALDOS_PROV.SingleOrDefault(
                        c => c.IDPROV == data.IDPROV && c.CUENTATIPO.ToUpper().Equals(data.CUENTATIPO.ToUpper()));
                if (check != null)
                    return false;  //ya existe

                data.LogDate = DateTime.Now;
                data.LogUsuario = Environment.UserName;
                db.T0204_CTACTESALDOS_PROV.Add(data);
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }


    }
}
