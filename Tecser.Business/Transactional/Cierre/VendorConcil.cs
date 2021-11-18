using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.FI;
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

        //----------------------------------------------------------------
        private string _tipoLx;  //L1, L2 o L3
        private readonly string _periodo;
        private DateTime _fechaInicial;
        private DateTime _fechaFinal;
        private readonly int _mes;
        private readonly int _anio;
        //----------------------------------------------------------------


        public struct ResultadoAP
        {
            public decimal Saldo203;
            public decimal Saldo204;
            public bool ResultadoOK;
        }
        public struct ResultadoDocIngresados
        {
            public decimal Importe403;
            public decimal Importe203;
            public decimal SaldoPendientePago;
            public bool ConcialiacionOK;
        }
        public struct ResultadoPagos
        {
            public decimal PagosEmitidos;
            public decimal PagosRealizados;
            public decimal ChequesEmitidos;
            public decimal ChequesPeriodoAcreditados;
            public decimal ChequesPeriodoNoAcreditado;
            public decimal AcreditacionDiferida;
            public bool ConciliacionOk;
        }

        public VendorConcil(string periodo, string tipoLx)
        {
            _periodo = periodo;
            _tipoLx = tipoLx;
            _fechaInicial = new PeriodoConversion().GetFechaPrimerDiaPeriodo(_periodo);
            _fechaFinal = _fechaInicial.AddMonths(1).AddDays(-1);
            _mes = _fechaInicial.Month;
            _anio = _fechaInicial.Year;
        }


        private List<T0203_CTACTE_PROV> _get203NotIn403 = new List<T0203_CTACTE_PROV>();
        private List<T0403_VENDOR_FACT_H> _get403NotIn203 = new List<T0403_VENDOR_FACT_H>();


        public ResultadoAP ConciliaAP()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rx = new ResultadoAP()
                {
                    ResultadoOK = false,
                    Saldo203 = 0,
                    Saldo204 = 0
                };
                if (_tipoLx == "L1" || _tipoLx == "L2")
                {
                    //L1 o L2
                    rx.Saldo204 = db.T0204_CTACTESALDOS_PROV.Where(c => c.CUENTATIPO == _tipoLx)
                        .Sum(c => c.DEUDA_TOT_ARS.Value);
                    rx.Saldo203 = db.T0203_CTACTE_PROV.Where(c => c.TIPO == _tipoLx && c.SALDOFACTURA != 0)
                        .Sum(c => c.SALDOFACTURA);
                }
                else
                {
                    //Sin Tipo
                    rx.Saldo204 = db.T0204_CTACTESALDOS_PROV.Sum(c => c.DEUDA_TOT_ARS.Value);
                    rx.Saldo203 = db.T0203_CTACTE_PROV.Where(c => c.SALDOFACTURA != 0).Sum(c => c.SALDOFACTURA);
                }

                if (rx.Saldo203 == rx.Saldo204) rx.ResultadoOK = true;
                return rx;
            }
        }
        public ResultadoDocIngresados ConciliaDocConta()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rx = new ResultadoDocIngresados()
                {
                    ConcialiacionOK = false,
                    Importe203 = 0,
                    Importe403 = 0,
                    SaldoPendientePago = 0
                };
                var l403 = GetListaFacturasIngresadasT403();
                rx.Importe403 = l403.Sum(c => c.NETO);
                var l203 = GetListaFacturasIngresadasT203();
                rx.Importe203 = l203.Sum(c => c.IMPORTE_ARS);
                rx.SaldoPendientePago = l203.Sum(c => c.SALDOFACTURA);
                if (rx.Importe403 == rx.Importe203)
                    rx.ConcialiacionOK = true;
                return rx;
            }
        }
        public ResultadoPagos ConciliaPagos()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rx = new ResultadoPagos()
                {
                    PagosRealizados = 0,
                    PagosEmitidos = 0,
                    ChequesEmitidos = 0,
                    ChequesPeriodoAcreditados = 0,
                    ChequesPeriodoNoAcreditado = 0,
                    AcreditacionDiferida = 0,
                    ConciliacionOk = false,
                };

                var listaRegister = GetListsaEgresosRegister();
                if (listaRegister.Any() == false)
                {
                    rx.PagosRealizados = 0;
                }
                else
                {
                    rx.PagosRealizados = listaRegister.Sum(c => c.Monto_E.Value - c.Monto_I.Value);
                }

                var listaPagoE = GetListaPagosT203();
                if (listaPagoE.Any() == false)
                {
                    rx.PagosEmitidos = 0;
                }
                else
                {
                    rx.PagosEmitidos = listaPagoE.Sum(c => c.IMPORTE_ARS)*-1;
                }

                var che = GestionChequesEmitidos.AnalisisChequesEmitidosPeriodo(_periodo, _tipoLx);
                rx.ChequesEmitidos = che.TotEmitidoPeriodo;
                rx.ChequesPeriodoAcreditados = che.TotAcreditadoEmitidoPeriodo;
                rx.ChequesPeriodoNoAcreditado = che.TotNoAcreditado;
                rx.AcreditacionDiferida = che.TotAcreditadoEmisionDiferida;

                if (rx.PagosEmitidos - rx.ChequesEmitidos + che.TotAcreditado == rx.PagosRealizados)
                {
                    rx.ConciliacionOk = true;
                }
                else
                {
                    rx.ConciliacionOk = false;
                }
                return rx;
            }
        }

        public RetornaVendorConcil ConciliacionGeneralResumen()
        {
            var l403_ = new List<T0403_VENDOR_FACT_H>();
            var l203_ = new List<T0203_CTACTE_PROV>();
            var l203 = new List<T0203_CTACTE_PROV>();
            var rtn = new RetornaVendorConcil();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //rtn.Periodo = _periodo;
                //if (_tipoLx == "L1" || _tipoLx == "L2")
                //{
                //    //L1 o L2
                //    //rtn.Saldo204Final = db.T0204_CTACTESALDOS_PROV.Where(c => c.CUENTATIPO == _tipoLx)
                //    //    .Sum(c => c.DEUDA_TOT_ARS.Value);
                //    //rtn.SAldo203Final = db.T0203_CTACTE_PROV.Where(c => c.TIPO == _tipoLx && c.SALDOFACTURA != 0)
                //    //    .Sum(c => c.SALDOFACTURA);


                //}
                //else
                //{
                //    //Sin Tipo
                //    //rtn.Saldo204Final = db.T0204_CTACTESALDOS_PROV.Sum(c => c.DEUDA_TOT_ARS.Value);
                //    //rtn.SAldo203Final = db.T0203_CTACTE_PROV.Where(c => c.SALDOFACTURA != 0).Sum(c => c.SALDOFACTURA);


                //    l403_ = GetListaFacturasIngresadasT403();
                //    decimal importe = 0;
                //    decimal importeNC = 0;
                //    foreach (var i in l403_)
                //    {
                //        if (i.TFACTURA == "NC" || i.TFACTURA == "NCA")
                //        {
                //            if (i.NETO > 0)
                //            {
                //                importe = importe - i.NETO;
                //                importeNC -= i.NETO;
                //            }
                //            else
                //            {
                //                importe = importe + i.NETO;
                //                importeNC += i.NETO;
                //            }


                //        }
                //        else
                //        {
                //            importe += i.NETO;
                //        }
                //    }

                //    if (rtn.SAldo203Final == rtn.Saldo204Final)
                //        rtn.SaldoVendorOK = true;

                //    rtn.ImporteIngresosDocumentos403 = importe;

                //    l203 = GetListaFacturasIngresadasT203();
                //    rtn.ImporteIngresosDocumentos203 = l203.Sum(c => c.IMPORTE_ARS);


                //    //Egresos de Fondos ->REG
                //    var x = GetListsaEgresosRegister();
                //    rtn.ImporteEgresosREG = x.Sum(c => c.Monto_E.Value) - x.Sum(c => c.Monto_I.Value);

                //    var listadoPagos = GetListaPagosPD_OP(_periodo, _tipoLx);
                //    rtn.ImportePagosPdOpx = listadoPagos.Sum(c => c.IMPORTE_ARS) * -1;
                //}
            }
            return rtn;
        }



        //revisado


        public List<T0203_CTACTE_PROV> GetListaFacturasIngresadasT203()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<T0203_CTACTE_PROV> lista;
                if (_tipoLx == "L1" || _tipoLx == "L2")
                {
                    lista = db.T0203_CTACTE_PROV.Where(c => c.Fecha.Month == _mes && c.Fecha.Year ==_anio && c.TIPO==_tipoLx)
                        .ToList();
                }
                else
                {
                    //Sin tipo
                    lista = db.T0203_CTACTE_PROV.Where(c => c.Fecha.Month == _mes && c.Fecha.Year == _anio).ToList();
                }
                return lista.Where(c => c.TDOC != "OP" && c.TDOC != "PD" && c.TDOC != "OPZ").ToList();
            }
        }
        public List<T0403_VENDOR_FACT_H> GetListaFacturasIngresadasT403()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<T0403_VENDOR_FACT_H> r403; 
                if (_tipoLx == "L1" || _tipoLx == "L2")
                {
                    //con tipo
                    r403 = db.T0403_VENDOR_FACT_H
                        .Where(c => c.FECHA.Month == _mes && c.FECHA.Year == _anio && c.TIPO == _tipoLx).ToList();
                }
                else
                {
                    //sin tipo
                    r403 = db.T0403_VENDOR_FACT_H
                        .Where(c => c.FECHA.Month == _mes && c.FECHA.Year == _anio).ToList();
                }
                
                //Revisar si se va a eliminar algo (ejemplo SYJ)
                return r403;
            }
        }
        public List<T0203_CTACTE_PROV> GetListaPagosT203()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<T0203_CTACTE_PROV> lista;
                if (_tipoLx == "L1" || _tipoLx == "L2")
                {
                    lista = db.T0203_CTACTE_PROV.Where(c => c.Fecha.Month == _mes && c.Fecha.Year == _anio && c.TIPO == _tipoLx)
                        .ToList();
                }
                else
                {
                    //Sin tipo
                    lista = db.T0203_CTACTE_PROV.Where(c => c.Fecha.Month == _mes && c.Fecha.Year == _anio).ToList();
                }
                return lista.Where(c => c.TDOC == "OP" || c.TDOC == "PD" || c.TDOC == "OPZ").ToList();
            }
        }
        public List<XREGISTER> GetListsaEgresosRegister()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (_tipoLx == "L1" || _tipoLx == "L2")
                {
                    return db.XREGISTER.Where(c =>
                            c.Fecha.Value.Month == _mes && c.Fecha.Value.Year == _anio && c.PC == "P" && c.TIPO == _tipoLx).ToList();
                }
                else
                {
                    return db.XREGISTER.Where(c =>
                        c.Fecha.Value.Month == _mes && c.Fecha.Value.Year == _anio && c.PC == "P").ToList();

                }
            }
        }





        //arevisar
        public List<T0203_CTACTE_PROV> GetLista203NotIn403(string periodo, string tipoLx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lista403 = GetListaFacturasIngresadasT403();
                var lista203 = GetListaFacturasIngresadasT203();
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
                                DeudaTotalARS = t.IMPORTE_ARS * multiplicador
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
