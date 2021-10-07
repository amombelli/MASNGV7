using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.Cierre
{
    public class RetornaVendorConcil
    {
        public decimal ImporteEgresosREG { get; set; }
        public decimal ImporteEgresosRET { get; set; }
        public decimal ImportePagosPdOpx { get; set; }
        public decimal ImporteIngresosDocumentos403 { get; set; }
        public decimal ImporteIngresosDocumentos203 { get; set; }
        public decimal SaldoDetalle203 { get; set; }
        public decimal Saldo204Final { get; set; }
        public decimal SAldo203Final { get; set; }
        public bool SaldoVendorOK { get; set; }
        public string Periodo { get; set; }
        private decimal PagosPeriodo { get; set; }
    }

    public class EstructuraSaldosProveedores
    {
        public int VendorId { get; set; }
        public string RazonSocial { get; set; }
        public string TipoLX { get; set; }
        public string VendorType { get; set; }
        public decimal DeudaTotalARS { get; set; }
        public string TipoDoc { get; set; }
    }

    public class VendorConcil
    {
        private DateTime _fechaI;
        private DateTime _fechaD;
        private string _tipoLx;

        private List<T0203_CTACTE_PROV> _get203NotIn403 = new List<T0203_CTACTE_PROV>();
        private List<T0403_VENDOR_FACT_H> _get403NotIn203 = new List<T0403_VENDOR_FACT_H>();

        public RetornaVendorConcil ConciliacionGeneralResumen(string periodo, string tipoLx)
        {
            _tipoLx = tipoLx;
            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            _fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);
            //traia problemas con el ultimo dia + horas
            var l403_ = new List<T0403_VENDOR_FACT_H>();
            var l203_ = new List<T0203_CTACTE_PROV>();
            var l203 = new List<T0203_CTACTE_PROV>();
            var rtn = new RetornaVendorConcil();

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                rtn.Periodo = periodo;
                if (tipoLx == "L3")
                {
                    //** SIN TIPO
                }

                else
                {
                    //** CON TIPO LX

                    rtn.Saldo204Final =
                        db.T0204_CTACTESALDOS_PROV.Where(c => c.CUENTATIPO == tipoLx).Sum(c => c.DEUDA_TOT_ARS.Value);

                    rtn.SAldo203Final =
                        db.T0203_CTACTE_PROV.Where(c => c.TIPO == tipoLx && c.SALDOFACTURA != 0)
                            .Sum(c => c.SALDOFACTURA.Value);

                    if (rtn.SAldo203Final == rtn.Saldo204Final)
                        rtn.SaldoVendorOK = true;

                    l403_ = GetListaFacturasIngresadasT403(periodo, _tipoLx);
                    decimal importe = 0;
                    decimal importeNC = 0;
                    foreach (var i in l403_)
                    {
                        if (i.TFACTURA == "NC" || i.TFACTURA == "NCA")
                        {
                            if (i.NETO > 0)
                            {
                                importe = importe - i.NETO;
                                importeNC -= i.NETO;
                            }
                            else
                            {
                                importe = importe + i.NETO;
                                importeNC += i.NETO;
                            }


                        }
                        else
                        {
                            importe += i.NETO;
                        }
                    }
                    rtn.ImporteIngresosDocumentos403 = importe;

                    l203 = GetListaFacturasIngresadasT203(periodo, tipoLx);
                    rtn.ImporteIngresosDocumentos203 = l203.Sum(c => c.IMPORTE_ARS.Value);


                    //Egresos de Fondos ->REG
                    var x = GetListsaEgresosReg(periodo, _tipoLx);
                    rtn.ImporteEgresosREG = x.Sum(c => c.Monto_E.Value) - x.Sum(c => c.Monto_I.Value);

                    var listadoPagos = GetListaPagosPD_OP(periodo, _tipoLx);
                    rtn.ImportePagosPdOpx = listadoPagos.Sum(c => c.IMPORTE_ARS.Value) * -1;
                }
            }


            return rtn;
        }
        public List<T0203_CTACTE_PROV> GetListaFacturasIngresadasT203(string periodo, string tipoLx)
        {
            _tipoLx = tipoLx;
            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            _fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);
            //traia problemas con el ultimo dia + horas

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lista = db.T0203_CTACTE_PROV.Where(c => c.Fecha >= _fechaI && c.Fecha < _fechaD && c.TIPO == tipoLx)
                    .ToList();

                return lista.Where(c => c.TDOC != "OP" && c.TDOC != "PD" && c.TDOC != "OPZ").ToList();
            }
        }
        public List<T0403_VENDOR_FACT_H> GetListaFacturasIngresadasT403(string periodo, string tipoLx)
        {
            _tipoLx = tipoLx;
            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            _fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);
            //traia problemas con el ultimo dia + horas

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var all403 =
                    db.T0403_VENDOR_FACT_H.Where(c => c.FECHA >= _fechaI && c.FECHA < _fechaD && c.TIPO == tipoLx)
                        .ToList();

                var nuevaLista = all403.RemoveAll((c => c.TCODE == "SYJ"));
                return all403;


                //Tener en cuenta los signos de las NOTAS DE CREDITO
            }
        }
        public List<T0203_CTACTE_PROV> GetLista203NotIn403(string periodo, string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lista403 = GetListaFacturasIngresadasT403(periodo, tipoLx);
                var lista203 = GetListaFacturasIngresadasT203(periodo, tipoLx);
                foreach (var lx in lista203)
                {
                    if (lista403.Find(c => c.IDCTACTE == lx.IDCTACTE) == null)
                    {
                        _get203NotIn403.Add(lx);
                    }
                }
                return _get203NotIn403;
            }
        }
        public List<XREGISTER> GetListsaEgresosReg(string periodo, string tipoLx)
        {
            _tipoLx = tipoLx;
            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            _fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);
            //traia problemas con el ultimo dia + horas
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.XREGISTER.Where(c => c.Fecha >= _fechaI && c.Fecha < _fechaD && c.PC == "P" && c.TIPO == tipoLx)
                        .ToList();
            }
        }
        public List<T0203_CTACTE_PROV> GetListaPagosPD_OP(string periodo, string tipoLx)
        {
            _tipoLx = tipoLx;
            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            _fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lista = db.T0203_CTACTE_PROV.Where(c => c.Fecha >= _fechaI && c.Fecha < _fechaD && c.TIPO == tipoLx)
                    .ToList();

                return lista.Where(c => c.TDOC == "OP" || c.TDOC == "PD" || c.TDOC == "OPZ").ToList();
            }
        }
        public List<EstructuraSaldosProveedores> GetListadoSaldosFinales(string tipoLx, bool showAll = false)
        {
            _tipoLx = tipoLx;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = from sx in db.T0204_CTACTESALDOS_PROV
                           where sx.CUENTATIPO == tipoLx
                           orderby sx.IDPROV
                           select new EstructuraSaldosProveedores()
                           {
                               RazonSocial = sx.T0005_MPROVEEDORES.prov_rsocial,
                               TipoLX = tipoLx,
                               TipoDoc = "SX",
                               VendorId = sx.IDPROV,
                               VendorType = sx.T0005_MPROVEEDORES.TIPO,
                               DeudaTotalARS = sx.DEUDA_TOT_ARS.Value
                           };
                if (showAll)
                    return data.ToList();
                return data.Where(c => c.DeudaTotalARS != 0).ToList();
            }
        }

        public List<EstructuraSaldosProveedores> GetMovimientosPeriodoSeleccionado(string periodo, string tipoLx, bool showAll = false,
            bool cambiarSigno = false)
        {
            _tipoLx = tipoLx;
            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            _fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);

            var multiplicador = 1;
            if (cambiarSigno)
                multiplicador = -1;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data2 = from t in db.T0203_CTACTE_PROV
                            where t.TIPO == tipoLx && t.Fecha >= _fechaI && t.Fecha < _fechaD
                            //&& (t.TDOC == "OP" || t.TDOC == "OPZ" || t.TDOC == "PD")
                            select new EstructuraSaldosProveedores()
                            {
                                RazonSocial = t.T0005_MPROVEEDORES.prov_rsocial,
                                TipoLX = tipoLx,
                                TipoDoc = t.TDOC,
                                VendorId = t.IDPROV,
                                VendorType = t.T0005_MPROVEEDORES.TIPO,
                                DeudaTotalARS = t.IMPORTE_ARS.Value * multiplicador
                            };
                if (showAll)
                    return data2.ToList();
                return data2.Where(c => c.DeudaTotalARS != 0).ToList();
            }
        }
        public List<EstructuraSaldosProveedores> Accion(string tipoLx, string periodo)
        {
            var listadoRespuesta = new List<EstructuraSaldosProveedores>();
            _tipoLx = tipoLx;
            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            _fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);
            //traia problemas con el ultimo dia + horas

            var listaSaldos = GetListadoDetalladoComposicionSaldos(tipoLx, periodo);
            var resultConsol = from data in listaSaldos
                               group data by
                                   new
                                   {
                                       data.VendorId,
                                       data.TipoLX,
                                       data.VendorType,
                                       data.RazonSocial
                                   }
                into grp
                               select new EstructuraSaldosProveedores()
                               {
                                   VendorId = grp.Key.VendorId,
                                   TipoLX = grp.Key.TipoLX,
                                   VendorType = grp.Key.VendorType,
                                   RazonSocial = grp.Key.RazonSocial,
                                   DeudaTotalARS = grp.Sum(c => c.DeudaTotalARS),
                                   TipoDoc = "SI"
                               };
            return resultConsol.Where(c => c.DeudaTotalARS != 0).ToList();
        }
        public List<EstructuraSaldosProveedores> GetListadoDetalladoComposicionSaldos(string tipoLx, string periodo)
        {
            _tipoLx = tipoLx;
            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(periodo);
            _fechaD = new PeriodoConversion().GetFechaUltimoDiaPeriodo(periodo).AddDays(1);
            var listaSaldos = new List<EstructuraSaldosProveedores>();


            var periodoInicial = new PeriodoConversion().GetPeriodo(DateTime.Today);
            var periodoFinal = periodo;
            var periodoActual = periodoInicial;

            while (periodoActual != periodoFinal)
            {
                listaSaldos.AddRange(GetMovimientosPeriodoSeleccionado(periodoActual, _tipoLx, false, true));
                periodoActual = new PeriodoConversion().GetAnteriorPeriodo(periodoActual);
            }
            listaSaldos.AddRange(GetListadoSaldosFinales(_tipoLx, false)); //adiciona saldos finales SX
            listaSaldos.AddRange(GetMovimientosPeriodoSeleccionado(periodo, _tipoLx, false, true));
            return listaSaldos.OrderBy(c => c.VendorId).ToList();
        }
        public List<EstructuraSaldosProveedores> GetListadoSumarizadoComposicionSaldos(
            List<EstructuraSaldosProveedores> listaSaldos)
        {
            var resultConsol = from data in listaSaldos
                               group data by
                                   new
                                   {
                                       data.VendorId,
                                       data.TipoLX,
                                       data.VendorType,
                                       data.RazonSocial
                                   }
                into grp
                               select new EstructuraSaldosProveedores()
                               {
                                   VendorId = grp.Key.VendorId,
                                   TipoLX = grp.Key.TipoLX,
                                   VendorType = grp.Key.VendorType,
                                   RazonSocial = grp.Key.RazonSocial,
                                   DeudaTotalARS = grp.Sum(c => c.DeudaTotalARS),
                                   TipoDoc = "SI"
                               };
            return resultConsol.Where(c => c.DeudaTotalARS != 0).ToList();
        }
    }
}
