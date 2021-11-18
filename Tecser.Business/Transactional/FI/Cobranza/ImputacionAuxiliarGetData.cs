using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{

    /// <summary>
    /// Auxiliar obtiene datos de posibles imputaciones cliente
    /// Facturas Pendientes etc -
    /// No vamos a realizar calculos de imputacion en esta clase sin solo Gets
    /// y Sets de Propiedades de validcion
    /// </summary>
    public class ImputacionAuxiliarGetData
    {
        public enum LX
        {
            L1,
            L2,
            SinSeleccion
        };
        public int? _idCliente { get; private set; }
        public LX _lx { get; private set; }
        public decimal CreditoSinImputarL1 { get; private set; }
        public decimal CreditoSinImputarL2 { get; private set; }
        public decimal FacturaSinImputarL1 { get; private set; }
        public decimal FacturaSinImputarL2 { get; private set; }
        public decimal FacturaSinImputarSeleccion { get; private set; }
        public int? idCobSeleccion { get; private set; }
        public decimal SaldoImputarMax { get; private set; }

        //todo: Monto >> pasar a Decimal
        public ImputacionAuxiliarGetData(int? idCliente = null, LX tipoLx = LX.SinSeleccion)
        {
            _idCliente = idCliente;
            _lx = tipoLx;
        }
        public void SetCliente(int? idCliente, bool getData = true)
        {
            _idCliente = idCliente;
            if (getData)
            {
                GetListaCobranzasSinImputar();
                GetImporteCobranzasSinImputar();
                GetImporteFacturaSinImputar();
            }
        }
        public void SetLx(string tipoLX, bool getData = true)
        {
            switch (tipoLX)
            {
                case "L1":
                    _lx = LX.L1;
                    break;
                case "L2":
                    _lx = LX.L2;
                    break;
                default:
                    _lx = LX.SinSeleccion;
                    break;
            }

            if (getData)
            {
                GetListaCobranzasSinImputar();
                GetImporteCobranzasSinImputar();
                GetImporteFacturaSinImputar();
            }
        }
        public List<T0208_COB_NO_APLICADA> GetListaCobranzasSinImputar()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return _idCliente == null
                    ? db.T0208_COB_NO_APLICADA.OrderByDescending(c => c.MONTO).ToList()
                    : db.T0208_COB_NO_APLICADA.Where(c => c.CLIENTE == _idCliente).OrderBy(c => c.FECHA).ToList();
            }
        }
        public void GetImporteCobranzasSinImputar()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (_idCliente == null)
                {
                    var x1 = db.T0208_COB_NO_APLICADA.Where(c => c.TIPOCUENTA == "L1").ToList();
                    CreditoSinImputarL1 = x1.Any() ? x1.Sum(c => c.MONTO.Value) : 0;
                    var x2 = db.T0208_COB_NO_APLICADA.Where(c => c.TIPOCUENTA == "L2").ToList();
                    CreditoSinImputarL2 = x2.Any() ? x2.Sum(c => c.MONTO.Value) : 0;
                }
                else
                {
                    var x1 = db.T0208_COB_NO_APLICADA.Where(c => c.TIPOCUENTA == "L1" && c.CLIENTE == _idCliente)
                        .ToList();
                    CreditoSinImputarL1 = x1.Any() ? x1.Sum(c => c.MONTO.Value) : 0;
                    var x2 = db.T0208_COB_NO_APLICADA.Where(c => c.TIPOCUENTA == "L2" && c.CLIENTE == _idCliente)
                        .ToList();
                    CreditoSinImputarL2 = x2.Any() ? x2.Sum(c => c.MONTO.Value) : 0;
                }
            }
        }
        public void GetImporteFacturaSinImputar()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (_idCliente == null)
                {
                    var x1 = db.T0207_SPLITFACTURAS.Where(c => c.TIPO == "L1" && c.MontoImputado == 0).ToList();
                    FacturaSinImputarL1 = x1.Any() ? x1.Sum(c => c.ImporteAImputar) : 0;
                    var x2 = db.T0207_SPLITFACTURAS.Where(c => c.TIPO == "L2" && c.MontoImputado == 0).ToList();
                    FacturaSinImputarL2 = x2.Any() ? x2.Sum(c => c.ImporteAImputar) : 0;
                }
                else
                {
                    var x1 = db.T0207_SPLITFACTURAS
                        .Where(c => c.TIPO == "L1" && c.MontoImputado == 0 && c.CLIENTE == _idCliente).ToList();
                    FacturaSinImputarL1 = x1.Any() ? x1.Sum(c => c.ImporteAImputar) : 0;
                    var x2 = db.T0207_SPLITFACTURAS
                        .Where(c => c.TIPO == "L2" && c.MontoImputado == 0 && c.CLIENTE == _idCliente).ToList();
                    FacturaSinImputarL2 = x2.Any() ? x2.Sum(c => c.ImporteAImputar) : 0;
                }
            }
        }
        public List<T0207_SPLITFACTURAS> GetListaDocumentosSinImputar()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (_idCliente == null)
                {
                    if (_lx == LX.SinSeleccion)
                    {
                        var x = db.T0207_SPLITFACTURAS.Where(c => c.MontoImputado == 0 && c.ImporteAImputar > 0).ToList();
                        FacturaSinImputarSeleccion = x.Any() ? x.Sum(c => c.ImporteAImputar) : 0;
                        return x;
                    }
                    else
                    {
                        string tipo = _lx.ToString();
                        var x = db.T0207_SPLITFACTURAS.Where(c => c.MontoImputado == 0 && c.ImporteAImputar > 0 && c.TIPO == tipo).ToList();
                        FacturaSinImputarSeleccion = x.Any() ? x.Sum(c => c.ImporteAImputar) : 0;
                        return x;
                    }
                }
                else
                {
                    if (_lx == LX.SinSeleccion)
                    {
                        var x = db.T0207_SPLITFACTURAS.Where(c => c.MontoImputado == 0 && c.ImporteAImputar > 0 && c.CLIENTE == _idCliente)
                            .ToList();
                        FacturaSinImputarSeleccion = x.Any() ? x.Sum(c => c.ImporteAImputar) : 0;
                        return x;
                    }
                    else
                    {
                        string tipo = _lx.ToString();
                        var x = db.T0207_SPLITFACTURAS
                            .Where(c => c.MontoImputado == 0 && c.ImporteAImputar > 0 && c.TIPO == tipo && c.CLIENTE == _idCliente).ToList();
                        FacturaSinImputarSeleccion = x.Any() ? x.Sum(c => c.ImporteAImputar) : 0;
                        return x;
                    }
                }
            }
        }
        public T0208_COB_NO_APLICADA SetSeleccionRegistro208(int? idCob)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                idCobSeleccion = idCob;
                if (idCob != null)
                {
                    var data = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.ID == idCob);
                    SetLx(data.TIPOCUENTA);
                    SaldoImputarMax = data.MONTO.Value;
                    return data;
                }
                else
                {
                    SetLx("??");
                    SaldoImputarMax = 0;
                    return null;
                }
            }
        }
        public void ClearSelecciones()
        {
            _idCliente = null;
            _lx = LX.SinSeleccion;
            GetListaCobranzasSinImputar();
            GetImporteCobranzasSinImputar();
            GetImporteFacturaSinImputar();
        }
    }
}
