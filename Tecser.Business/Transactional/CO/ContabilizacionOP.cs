using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    public class ContabilizacionOP
    {
        public ContabilizacionOP(int numeroOP, int numeroAsientoIdocu)
        {
            _numeroOP = numeroOP;
            _numeroAsiento = numeroAsientoIdocu;
            _datosOP = new OrdenPagoManageDatos(_numeroOP);
            _datosAsiento.LoadAsientoInMemory(numeroAsientoIdocu);
        }

        private int _numeroOP;
        private int _numeroAsiento;
        private OrdenPagoManageDatos _datosOP;
        private AsientoContableManager _datosAsiento = new AsientoContableManager(new TecserData(GlobalApp.CnnApp));


        public void ContabilizaItems()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var itemsPago = db.T0212_OP_ITEM.Where(c => c.IDOP == _numeroOP).ToList();
                var cuenta = new CuentasManager();
                var subdiario = new SubdiarioCajaManager();

                string gl = "";

                //var Asiento = new AsientoContableManager(new TecserData(GlobalApp.CnnApp)).LoadAsientoInMemory()

                #region Recorre CostItems

                foreach (var item in itemsPago)
                {
                    gl = cuenta.GetGL(item.CUENTA_O);
                    switch (item.CUENTA_O)
                    {
                        case "ARS":
                            //1. Agrega item al asiento
                            _datosAsiento.AddItemInMemoria(gl, _datosOP.Header.MON_OP, "OP", _numeroOP.ToString(), 0,
                                item.IMPORTE.Value,
                                "Pago Caja ARS", null, "OPX", _datosOP.Header.PROV_ID, status: "C");
                            //2. Subdiario
                            subdiario.WriteToDb("ARS", Convert.ToDateTime(_datosOP.Header.OPFECHA),
                                SubdiarioCajaManager.PC.Proveedor,
                                _datosOP.Header.PROV_ID, "OP", _numeroOP.ToString(),
                                "Orden Pago #" + _datosOP.Header.PROV_RS,
                                _datosOP.Header.MON_OP, 0, Convert.ToDecimal(item.IMPORTE), _datosOP.Header.TIPO,
                                "OPX", _numeroAsiento, cuenta.GetGL(item.CUENTA_O));
                            break;

                        case "SAN":

                            //1. Agrega item al asiento
                            _datosAsiento.AddItemInMemoria(gl, _datosOP.Header.MON_OP, "OP", _numeroOP.ToString(), 0,
                                item.IMPORTE.Value,
                                "Pago Caja SAN", null, "OPX", _datosOP.Header.PROV_ID, status: "C");
                            //2. Subdiario
                            subdiario.WriteToDb("SAN", Convert.ToDateTime(_datosOP.Header.OPFECHA),
                                SubdiarioCajaManager.PC.Proveedor,
                                _datosOP.Header.PROV_ID, "OP", _numeroOP.ToString(),
                                "Orden Pago #" + _datosOP.Header.PROV_RS,
                                _datosOP.Header.MON_OP, 0, Convert.ToDecimal(item.IMPORTE), _datosOP.Header.TIPO,
                                "OPX", _numeroAsiento, cuenta.GetGL(item.CUENTA_O));
                            break;

                        case "CHE":

                            var cheque = new ChequesManager();
                            var datoCheque = cheque.GetCheque(item.CH_ID.Value);

                            //1. Agrega item al asiento
                            _datosAsiento.AddItemInMemoria(gl, _datosOP.Header.MON_OP, "OP", _numeroOP.ToString(), 0,
                                item.IMPORTE.Value,
                                "Pago Caja Cheque " + datoCheque.T0160_BANCOS.BCO_SHORTDESC + " #" +
                                datoCheque.CHE_NUMERO, null, "OPX", _datosOP.Header.PROV_ID, status: "C",
                                referenciaTableName: "T0154_CHEQUES", referenciaIdNumerico: Convert.ToInt32(item.CH_ID));

                            //2. Subdiario
                            subdiario.WriteToDb("CHE", Convert.ToDateTime(_datosOP.Header.OPFECHA),
                                SubdiarioCajaManager.PC.Proveedor,
                                _datosOP.Header.PROV_ID, "OP", _numeroOP.ToString(),
                                "Orden Pago #" + _datosOP.Header.PROV_RS,
                                _datosOP.Header.MON_OP, 0, Convert.ToDecimal(item.IMPORTE), _datosOP.Header.TIPO,
                                "OPX", _numeroAsiento, cuenta.GetGL(item.CUENTA_O), idCheque: item.CH_ID.Value);

                            //3. Baja Cheque
                            cheque.UtilizaChequeEnOrdenPago(item.CH_ID.Value, _numeroOP, _numeroAsiento);
                            break;

                        case "OPCRED":
                            //En OPCRED el Numero OP# credito viene en CH_NUM
                            gl = new GLAccountManagement().GetApVendorGl(_datosOP.Header.PROV_ID); //GL AP

                            //1. Agrega item al asiento
                            _datosAsiento.AddItemInMemoria(gl, _datosOP.Header.MON_OP, "OP", _numeroOP.ToString(), 0,
                                item.IMPORTE.Value,
                                "Pago con Credito a FAavor OP#" + item.CH_NUM, null, "OPX", _datosOP.Header.PROV_ID,
                                status: "C");

                            //2. Subdiario
                            subdiario.WriteToDb("OPCRED", Convert.ToDateTime(_datosOP.Header.OPFECHA),
                                SubdiarioCajaManager.PC.Proveedor,
                                _datosOP.Header.PROV_ID, "OP", _numeroOP.ToString(),
                                "Orden Pago #" + _datosOP.Header.PROV_RS,
                                _datosOP.Header.MON_OP, 0, Convert.ToDecimal(item.IMPORTE), _datosOP.Header.TIPO,
                                "OPX", _numeroAsiento, gl);

                            //3. 


                            break;
                        default:
                            MessageBox.Show(@"Cuenta no manejada" + item.CUENTA_O);
                            break;
                    }
                }

                #endregion

                #region Agrega Impuestos

                //Termino de recorrer todos los CostItems de Pago
                if (_datosOP.Header.ImporteRetIIBB > 0)
                {
                    //1. Agrega item al asiento
                    gl = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.RetencionIIBB);
                    _datosAsiento.AddItemInMemoria(gl, _datosOP.Header.MON_OP, "OP", _numeroOP.ToString(), 0,
                        Convert.ToDecimal(_datosOP.Header.ImporteRetIIBB), "Retencion IIBB BsAs", null, "OPX",
                        _datosOP.Header.PROV_ID,
                        status: "C");

                    //2. Subdiario
                    subdiario.WriteToDb("RETIIBB", Convert.ToDateTime(_datosOP.Header.OPFECHA),
                        SubdiarioCajaManager.PC.Proveedor,
                        _datosOP.Header.PROV_ID, "OP", _numeroOP.ToString(),
                        "Orden Pago #" + _datosOP.Header.PROV_RS,
                        _datosOP.Header.MON_OP, 0, Convert.ToDecimal(_datosOP.Header.ImporteRetIIBB), _datosOP.Header.TIPO,
                        "OPX", _numeroAsiento, gl);
                }

                if (_datosOP.Header.ImporteRetGS > 0)
                {
                    //1. Agrega item al asiento
                    gl = GLAccountManagement.GetGLAccount(GLAccountManagement.GLAccount.RetencionGS);
                    _datosAsiento.AddItemInMemoria(gl, _datosOP.Header.MON_OP, "OP", _numeroOP.ToString(), 0,
                        Convert.ToDecimal(_datosOP.Header.ImporteRetGS), "Retencion Ganancias", null, "OPX",
                        _datosOP.Header.PROV_ID,
                        status: "C");

                    //2. Subdiario
                    subdiario.WriteToDb("RETGS", Convert.ToDateTime(_datosOP.Header.OPFECHA),
                        SubdiarioCajaManager.PC.Proveedor,
                        _datosOP.Header.PROV_ID, "OP", _numeroOP.ToString(),
                        "Orden Pago #" + _datosOP.Header.PROV_RS,
                        _datosOP.Header.MON_OP, 0, Convert.ToDecimal(_datosOP.Header.ImporteRetGS), _datosOP.Header.TIPO,
                        "OPX", _numeroAsiento, gl);
                }

                //Asiento AP
                gl = new GLAccountManagement().GetApVendorGl(_datosOP.Header.PROV_ID);
                _datosAsiento.AddItemInMemoria(gl, _datosOP.Header.MON_OP, "OP", _numeroOP.ToString(),
                    Convert.ToDecimal(_datosOP.Header.IMP_OP), 0, "a A/P", "Pago a " + _datosOP.Header.PROV_RS, "OPX",
                    _datosOP.Header.PROV_ID,
                    status: "C");

                //No lleva Subdiario

                #endregion

                _datosAsiento.GrabaAsientoCompletoDb();
            }
        }
    }
}

