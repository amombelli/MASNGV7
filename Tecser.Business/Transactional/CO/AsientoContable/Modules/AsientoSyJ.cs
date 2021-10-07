using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.HR;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable.Modules
{
    public class AsientoSyJ : AsientoBase
    {
        private readonly int _idSyJ;
        public AsientoSyJ(int idSyJ, string tCode) : base(tCode)
        {
            _idSyJ = idSyJ;
            H = new SyJManagerNew().GetHeader(_idSyJ);
            I = new SyJManagerNew().GetItems(_idSyJ);
        }
        private struct StructuraGlAP
        {
            public string Glap { get; set; }
            public decimal ImporteAP { get; set; }
        }
        private T0550_HHRR_SYJ_Header H;
        private List<T0551_HHRR_SYJ_Items> I;
        private List<StructuraGlAP> _listaAPs;
        private string _descripcionAP = "A/P - SyJ";
        private decimal importeTotalAP = 0;
        public IdentificacionAsiento GeneraAsientoRegistroSyJ()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _listaAPs = new List<StructuraGlAP>();
                var lstAp = new List<string>();
                foreach (var i in I)
                {
                    var e = db.T0085_HHRR_PERSONAL_BASIC.SingleOrDefault(c => c.Shortname == i.Shortname);
                    if (e.GLAP == "")
                        e.GLAP = "2.0.2.1";
                    var f = lstAp.Find(c => c.Equals(e.GLAP));
                    if (f == null)
                    {
                        lstAp.Add(e.GLAP);
                        _listaAPs.Add(
                            new StructuraGlAP()
                            {
                                Glap = e.GLAP,
                                ImporteAP = i.NetoPagar
                            });
                    }
                    else
                    {
                        var r = _listaAPs.SingleOrDefault(c => c.Glap == e.GLAP);
                        var v = _listaAPs.Find(c => c.Glap == e.GLAP);
                        decimal x = v.ImporteAP;
                        _listaAPs.Remove(v);
                        _listaAPs.Add(
                            new StructuraGlAP()
                            {
                                Glap = e.GLAP,
                                ImporteAP = v.ImporteAP + i.NetoPagar
                            });
                    }
                    importeTotalAP += i.NetoPagar;
                }

                CreaHeaderMemoria(H.LX, H.Fecha, "SYJ", _idSyJ.ToString(), H.Observacion, "ARS", importeTotalAP,
                    new ExchangeRateManager().GetExchangeRate(H.Fecha));

                foreach (var i in I)
                {
                    AddGenericCompleteSegment("SYJ", Header.REFE, Header.TIPO, i.Concepto,
                        i.Shortname + "-" + H.Concepto, null, Header.MONE_ORI,
                        DebeHaber.Debe, i.NetoPagar, base.Tcode, nombreTabla: "T0551_HHRR_SYJ_Items", idNumerico: _idSyJ);
                }

                foreach (var xx in _listaAPs)
                {
                    _descripcionAP = GLAccountManagement.GetGLDescriptionFromT135(xx.Glap);
                    AddGenericCompleteSegment("SYJ", _idSyJ.ToString(), H.LX, xx.Glap, _descripcionAP, H.Observacion, H.Moneda,
                        DebeHaber.Haber, xx.ImporteAP, Tcode, nombreTabla: "T0551_HHRR_SYJ_Items", idNumerico: _idSyJ);
                }
                return base.GrabaAsiento();
            }
        }

        public IdentificacionAsiento GeneraAsientoPago(List<T0552_HHRR_SYJ_Payments> listaPago)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lgalp = new List<string>();
                decimal importeTotalPago = 0;
                _listaAPs = new List<StructuraGlAP>();
                //sumariza GLAP 
                foreach (var i in listaPago)
                {
                    var glAPEmpleado = HrMasterManagement.EmpleadoGlap(i.Shortname);
                    var f = lgalp.Find(c => c.Equals(glAPEmpleado));
                    if (f == null)
                    {
                        lgalp.Add(glAPEmpleado);
                        _listaAPs.Add(new StructuraGlAP
                        {
                            Glap = glAPEmpleado,
                            ImporteAP = i.Importe
                        });
                    }
                    else
                    {
                        var t = _listaAPs.Find(c => c.Glap == glAPEmpleado);
                        var importeA = t.ImporteAP;
                        _listaAPs.Remove(t);
                        _listaAPs.Add(new StructuraGlAP()
                        {
                            ImporteAP = importeA + i.Importe,
                            Glap = glAPEmpleado,
                        });
                    }

                    importeTotalPago += i.Importe;
                }

                //creacion de Header
                CreaHeaderMemoria(H.LX, H.Fecha, "SYJP", _idSyJ.ToString(), "SYJP - Pago de Registro", "ARS",
                    importeTotalAP,
                    new ExchangeRateManager().GetExchangeRate(H.Fecha));

                foreach (var xx in _listaAPs)
                {
                    _descripcionAP = GLAccountManagement.GetGLDescriptionFromT135(xx.Glap);
                    AddGenericCompleteSegment("SYJP", _idSyJ.ToString(), H.LX, xx.Glap, _descripcionAP, H.Observacion,
                        H.Moneda,
                        DebeHaber.Debe, xx.ImporteAP, Tcode, nombreTabla: "T0551_HHRR_SYJ_Items", idNumerico: 0);
                }

                //items
                foreach (var i in listaPago)
                {
                    //int idPayment = db.T0552_HHRR_SYJ_Payments.SingleOrDefault(c => c.IDItem == i.IDItem).IDPayment;
                    AddGenericCompleteSegment("SYJP", Header.REFE, Header.TIPO, i.GLAccount,
                        i.GLDescripcion + " - " + i.Shortname, $"Pago IdPayment @{i.IDPayment}", Header.MONE_ORI,
                        DebeHaber.Haber, i.Importe, base.Tcode, nombreTabla: "T0552_HHRR_SYJ_Payments",
                        idNumerico: i.IDPayment);
                }
                return base.GrabaAsiento();
            }
        }
    }
}
