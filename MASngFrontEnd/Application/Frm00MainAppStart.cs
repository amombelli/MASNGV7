using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Forms;
using MASngFE.Forms.CustomerSearchBase;
using MASngFE.Forms.VendorSearchBase;
using MASngFE.MasterData;
using MASngFE.MasterData.BOM;
using MASngFE.MasterData.Vendor;
using MASngFE.SecurityConfig;
using MASngFE.Transactional.CO.Cost;
using MASngFE.Transactional.CO.GL;
using MASngFE.Transactional.CRM;
using MASngFE.Transactional.FI;
using MASngFE.Transactional.FI.Cobranza;
using MASngFE.Transactional.FI.CustomerNCD;
using MASngFE.Transactional.FI.Factura;
using MASngFE.Transactional.FI.FondoFijo;
using MASngFE.Transactional.FI.GestionCheques;
using MASngFE.Transactional.FI.TaxModule;
using MASngFE.Transactional.FI.Vendor.SinRemito;
using MASngFE.Transactional.FI.VendorPRM;
using MASngFE.Transactional.HR;
using MASngFE.Transactional.MM;
using MASngFE.Transactional.MM.MRP;
using MASngFE.Transactional.MM.Requisicin;
using MASngFE.Transactional.QM;
using MASngFE.Transactional.SD;
using MASngFE.Transactional.SD.Hoja_de_Ruta;
using MASngFE.Transactional.SD.Remito;
using Tecser.Business.MainApp;
using Tecser.Business.Network;
using Tecser.Business.Security;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Cobranza;
using TecserEF.Entity;

namespace MASngFE.Application
{
    public partial class Frm00MainAppStart : RibbonForm
    {
        public Frm00MainAppStart()
        {
            InitializeComponent();
        }

        private int _pswError = 0;


        private void FrmMain_Load(object sender, EventArgs e)
        {
            GlobalApp.Tcode = "MAIN";
            stbarTcode.Text = GlobalApp.Tcode;
            stbarUsername.Text = GlobalApp.AppUsername + @" [" + Environment.UserName + "] ";
            stbarComputer.Text = @" Computer: " + Environment.MachineName + @" IP: " +
                                 IpAddress.GetIpV4Address(Environment.MachineName);
            stbarAppVersion.Text = @"App Version: " + GlobalApp.AppVersion;
            stbarModo.Text = @"INDEFINIDO";

            switch (GlobalApp.Modo)
            {
                case Tecser.Business.MainApp.ModoApp.Produccion:
                    stbarModo.Text = @"PRODUCCION";
                    MessageBox.Show(@"Atencion: Esta ingresando al Sistema de Gestion MAS.NG en Modo Productivo",
                        @"ENTORNO PRODUCTIVO PR1", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case Tecser.Business.MainApp.ModoApp.Desarrollo:
                case ModoApp.Desarrollo2:
                    stbarModo.Text = @"DESARROLLO";
                    stbarModo.ForeColor = Color.Red;
                    break;
                case Tecser.Business.MainApp.ModoApp.Testeo:
                    stbarModo.Text = @"TESTEO";
                    stbarModo.ForeColor = Color.Yellow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            dgvTcodeList.DataSource = new TcodeManager().GetTcodeList();
            tabControl1.Visible = false;
            dgvTcodeList.Visible = false;
            panelBoton1.Location = new Point(3, 221);
        }

        private void RunNewTransaction(string tCode)
        {
            var tcode = new TcodeManager(tCode);
            switch (tcode.ResultadoRun)
            {
                case TcodeManager.TcodeResponse.TxInvalida:
                    MessageBox.Show(@"Compruebe el nombre tipeado y reintente nuevamente",
                        @"El Nombre de la Transaccion es Invalido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stbarTcode.Text = @"TX*INVALID";
                    break;
                case TcodeManager.TcodeResponse.SinPermisos:
                    MessageBox.Show(@"El Usuario no tiene permisos suficientes para ejecutar esta transaccion",
                        @"Error en Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stbarTcode.Text = @"NOTAUTHORIZED";
                    break;
                case TcodeManager.TcodeResponse.ErrorConfig:
                    MessageBox.Show(@"Error 3. -Transaccion no manejada debido a error en Config de Path",
                        @"Error en Config", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    stbarTcode.Text = @"ERROR";
                    break;
                case TcodeManager.TcodeResponse.TxOK:
                    if (tcode.TipoTransaccion() == "FORM")
                    {
                        stbarTcode.Text = GlobalApp.Tcode;
                        if (tcode.FormToOpen != null)
                        {
                            var f = tcode.FormToOpen;
                            f.Show();
                        }
                    }
                    break;
            }
        }



        private void RunTransaction()
        {
            var xTcode = new TcodeManager();
            var response = xTcode.ValidateTransactionBeforeRun(GlobalApp.Tcode);

            //Si es FORM tiene que hacer la validacion del namespace en este assembly-
            //Obtengo el tipo en el FrontEnd y lo mando para la clase de Business
            if (response != TcodeManager.TcodeResponse.TxInvalida)
            {
                if (xTcode.TipoTransaccion() == "FORM")
                {
                    var myType = Type.GetType(xTcode.GetFormPath());
                    xTcode.SetType(myType);
                    if (myType == null)
                    {
                        response = TcodeManager.TcodeResponse.ErrorConfig;
                    }
                }
            }

            switch (response)
            {
                case TcodeManager.TcodeResponse.TxInvalida:
                    MessageBox.Show(@"El Nombre de la Transaccion es invalido", @"Error en Transaccion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stbarTcode.Text = @"TX*INVALID";
                    break;
                case TcodeManager.TcodeResponse.SinPermisos:
                    MessageBox.Show(@"El Usuario no tiene permisos suficientes para ejecutar esta transaccion",
                        @"Error en Permisos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    stbarTcode.Text = @"NOTAUTHORIZED";
                    break;
                case TcodeManager.TcodeResponse.ErrorConfig:
                    MessageBox.Show(@"Error 3. -Transaccion no manejada debido a error en Config de Path",
                        @"Error en Config", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    stbarTcode.Text = @"TX*OUTOFSERVICE";
                    break;
                case TcodeManager.TcodeResponse.TxOK:

                    if (xTcode.TipoTransaccion() == "FORM")
                    {
                        var f = xTcode.LunchFormOpen();
                        stbarTcode.Text = GlobalApp.Tcode;
                        f.Show();
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void btnRemisionCliente_Click(object sender, EventArgs e)
        {
            var f = new FrmSD06SeleccionRemisionCliente();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new FrmCentroPreparacionRemitos();
            f.Show();
        }
        
        private void btnCentroEntregas_Click(object sender, EventArgs e)
        {
            var f0 = new FrmCentroPreparacionHojaRuta();
            f0.Show();
        }
        
        private void button24_Click(object sender, EventArgs e)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("FACT3", "FACTUSEARCH", true, true))
            {
                return;
            }

            var f0 = new FrmCustomerDocumentSearch();
            f0.Show();
        }
        

        private void button15_Click_1(object sender, EventArgs e)
        {
            new Email2().SendEmail();
        }

        
        private void button27_Click(object sender, EventArgs e)
        {
            var f0 = new FrmImputacionFF();
            f0.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            var fx = new FrmFondoFijoConversion();
            fx.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("COBT", "COBITMP", true, true))
            {
                return;
            }

            var f = new FrmFI42CobranzaTemporal();
            f.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            var f = new FrmFI43ConversionCobranzas();
            f.Show();
        }


        private void btnDevelopmentForm_Click(object sender, EventArgs e)
        {
            var f = new FrmDevelopmentForm();
            f.Show();
        }
        
        private void FrmMainAppStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            var resp = MessageBox.Show(@"Confirma el cierre de MASNg V2",
                @"Confirmacion de Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var y = new FrmFI40AjusteSaldoCliente(6);
            y.Show();
            //var x = new FrmPP30CalculoBOM(4799);
            //x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var x = new FrmVendorSearchBase();

            //var x = new FrmTestUserControl();
            x.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f = new FrmForm1();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var x = new FrmApp13CheckWebServicesConfig();
            x.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var f = new FrmFI78ImportacionComprobantesAFIP();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var f = new FrmArba02();
            f.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            var f = new FrmFI50VendorPRMMain();
            f.Show();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            var f = new FrmQm04IpList();
            f.Show();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            var f = new FrmQm21AddRegistroInspeccion();
            f.Show();

            var f2 = new FrmQm30QmListaMainH1();
            f2.Show();
        }

        private void BtnMRPTest_Click(object sender, EventArgs e)
        {
            var f = new FrmMRP02();
            f.Show();
        }
        

        private void Button12_Click(object sender, EventArgs e)
        {
            new FrmCO02_Reposicion().Show();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            new FrmCO03_Manufactura().Show();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            new FrmCO07CostoStandard().Show();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            new FrmMDB05SearchByMP().Show();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            new FrmMDB06MassFormActivate().Show();
        }
        
        private void button17_Click_1(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            //new FixCompletaIdT400EnTablaCheRechazado();
            var f = new FrmFI53GestionChequeRechazado();
            f.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var f = new FrmFI54GestionEntregaRechazos();
            f.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //new RemitoL5Manager().SetRemitoL2L5(30631);

            //new FixCompletaIdT400EnTablaCheRechazado().FixIdCtaCteOldRecordChr();
            //new FixCompletaIdT400EnTablaCheRechazado().FixCompletaChequeRechEntregado();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            var f = new FrmHR05SYJH();
            f.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            var f = new FrmHR07AnticiposLoad();
            f.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            var f = new FrmHR08PagoAdelantos();
            f.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            var f = new FrmFI60ContaCancel();
            f.Show();
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            var f = new FrmCO30GLS();
            f.Show();
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            var f = new FrmCO20AbmGLAccounts();
            f.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("RC1", "RC1"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios", @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var f = new FrmMM55RequisicionMain();
                f.Show();
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("RC3", "RC3"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios", @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                var f = new FrmMM54RequisicionList();
                f.Show();
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            new FrmFI25RefacturacionDocumento().Show();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            var f = new FrmCRM03GescoMain();
            f.Show();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            var f = new FrmCRM02GescoSelect();
            f.Show();
        }
        

        private void button37_Click(object sender, EventArgs e)
        {
            var f = new FrmCRM06GescoCtaCteEstiloCliente();
            f.Show();
        }

        private void button36_Click_1(object sender, EventArgs e)
        {
            //var q = new FrmSD02SalesOrderMain(0);




            //var w = new ControlsInForm().GetAll(q,typeof(TextBox));

            //new ControlsInForm().GetTextBoxInForm(typeof(FrmSD02SalesOrderMain));
            ////var z = new ControlsInForm().GetAll(FrmSD02SalesOrderMain,TextBox);
            //////var z = new ListOfControls(FrmSD02SalesOrderMain);
            //////GetAll(FrmSD02SalesOrderMain, Text);
            //////var 0 = z.GetAll(FrmSD02SalesOrderMain, TextBox);
            /////
            ///// 
            //var xxxx = new ControlesEnFormularios(q);
            //var p= xxxx.GetListOfControls();

            var f0 = new FrmApp02ControlsInForms();
            f0.Show();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            var f = new FrmCo08CostManageControlCenter();
            f.Show();
        }

        private void button39_Click(object sender, EventArgs e)
        {

            //new CostRollManager().FixFcostAutomaticamente();
            //using (var db = new TecserData(GlobalApp.CnnApp))
            //{
            //    var rL5 = db.T0055_REMITO_H.Where(c => c.RLINK != null).OrderByDescending(c => c.IDREMITO).Take(10)
            //        .ToList();
            //    foreach (var il5 in rL5)
            //    {
            //        new MargenDocument().AddMargenDocumentAndMapCost(il5.IDREMITO);
            //    }
            //}



            //int a = 30328;
            //int b = 30328;
            ////30304 - 304113

            //for (var i = a; i <= b; i++)
            //{
            //    new MargenDocument().AddMargenDocumentAndMapCost(i);

            //}

            ////    //
            //new MargenDocument().UpdateRemito_FacturaData(31358);
            //new MargenDocument().UpdateStatusCobranza(31358);


            var f = new FrmCO13MargenResumen();
            f.Show();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            var f = new FrmFI60ExchangeRage();
            f.Show();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            var f = new FrmSD05CentroDespacho();
            f.Show();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            var f = new FRMFI90_FSR();
            f.Show();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            var f = new FrmMM67FasonExternoMain();
            f.Show();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            var f = new FrmHr10CargaSyj();
            f.Show();

        }

        private void button47_Click(object sender, EventArgs e)
        {
            var f = new FrmHr02PersonalABMSelect();
            f.Show();

        }

        private void button48_Click(object sender, EventArgs e)
        {
            var f = new FrmHr11ListaSyJ();
            f.Show();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            var f = new f1delete();
            f.Show();

        }

        private void button50_Click(object sender, EventArgs e)
        {
            var f = new FrmCrh();
            f.Show();
        }

 
        private void button52_Click(object sender, EventArgs e)
        {
            var p = new AcostoMfgCr();
            p.GetCostXplodAll("CNE001");
            Debug.Print(p.CostHeader[0].CostoUsd.ToString());
        }

        private void button53_Click(object sender, EventArgs e)
        {
            var f = new FrmFI55ChequesEmitidos();
            f.Show();
        }

        private void button54_Click(object sender, EventArgs e)
        {

            //Funcion para Regenerar automaticamente todos los cheques 
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                DateTime fechaDesde = DateTime.Today.AddDays(-200);
                var listaOP = db.T0210_OP_H.Where(c => c.OPFECHA > fechaDesde).ToList();
                foreach (var it in listaOP)
                {
                    var op = new OrdenPagoManageDatos(it.IDOP);
                    op.RegistraChequesEmitidos(it.NAS.Value);
                }

                MessageBox.Show(@"Termine");
            }
        }
        

        private void btnDesimputarCtaCte_Click(object sender, EventArgs e)
        {
            var y = MessageBox.Show(@"Confirma desimputacion documento?", "X", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (y == DialogResult.No) return;
            var f = new CobranzaDesimputa().DesimputaDocumento(52965);
        }


        private void btnXRemito_Click(object sender, EventArgs e)
        {

        }

     
        private void btnConfirmTCode_Click(object sender, EventArgs e)
        {
            GlobalApp.Tcode = txtNTcode.Text.ToUpper();
            SecurityLog.LogTransactionIn(GlobalApp.Tcode); //Loguea transaccion ingresada.-
            RunTransaction();
            stbarTcode.Text = GlobalApp.Tcode;
        }


        //Botonos Ribbon
        private void rbtnNotaCreditoCliente_Click(object sender, EventArgs e)
        {
            var f = new FrmFI51GenerarNotaCredito(961);
            f.Show();
        }

        private void rbtNotaDebitoCliente_Click(object sender, EventArgs e)
        {
            var f = new FrmFI61GenerarNotaDebito(961);
            f.Show();
        }

        private void rbtnAjusteCliente_Click(object sender, EventArgs e)
        {
            var f = new FrmFI71AjustesFI();
            f.Show();
        }

        private void rbtnRequisicionCompra_Click(object sender, EventArgs e)
        {

        }

        private void rbtnIC_Click(object sender, EventArgs e)
        {

        }

        private void rbtnNuevaOC_Click(object sender, EventArgs e)
        {

        }

        private void rbtnVerOrdenCompra_Click(object sender, EventArgs e)
        {

        }

        private void rbtnCrearNP_Click(object sender, EventArgs e)
        {

        }

        private void button51_Click_2(object sender, EventArgs e)
        {
            var f = new FrmFI48ImputacionCobranza();
            f.Show();
        }

        private void rbAddComboFunction_Click(object sender, EventArgs e)
        {
            var f = new FrmSS11AddComboFunction();
            f.Show();
        }

        private void rbAssignPersonalCombo_Click(object sender, EventArgs e)
        {

        }

        private void rbtnDevoluciones_Click(object sender, EventArgs e)
        {

        }

        private void rbtnPF_Click(object sender, EventArgs e)
        {
            // aca va el PF1    
        }

        private void rbtnLogNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtNewUser.TextBoxText))
            {
                MessageBox.Show(@"Nombre de Usuario Invalido", @"Error de Acceso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (string.IsNullOrEmpty(rtxtNewPassword.TextBoxText))
            {
                MessageBox.Show(@"Contraseña Invalida", @"Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (TsSecurityMng.CheckUsernamePasswordOK(rtxtNewUser.TextBoxText, rtxtNewPassword.Text))
            {
                //Usuario validado
                GlobalApp.AppUsername = rtxtNewUser.Text;
                _pswError = 0;
                stbarUsername.Text = GlobalApp.AppUsername + @" [" + Environment.UserName + "] ";
            }
            else
            {
                _pswError++;
                MessageBox.Show(@"Usuario o Password incorrecta Repetidamente", @"Error en Acceso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (_pswError == 3)
                {
                    this.Close();
                }
                return;
            }
        }


        private void btnViewListaTcode_Click(object sender, EventArgs e)
        {
            panelBoton1.Location = new Point(411, 221);
            dgvTcodeList.Visible = true;

        }

        private void btnHideListaTcode_Click(object sender, EventArgs e)
        {
            dgvTcodeList.Visible = false;
            panelBoton1.Location = new Point(3, 221);

        }

        private void btnSeleccionEspecial_Click(object sender, EventArgs e)
        {
            if (tabControl1.Visible)
            {
                tabControl1.Visible = false;
            }
            else
            {
                tabControl1.Visible = true;
            }
        }
        
        private void rbtnXRate_Click(object sender, EventArgs e)
        {
            var f = new FrmFI60ExchangeRage();
            f.Show();
        }

        private void rbtnFactuSearch_Click(object sender, EventArgs e)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("FACT3", "FACTUSEARCH", true, true))
            {
                return;
            }

            var f0 = new FrmCustomerDocumentSearch();
            f0.Show();
        }

        private void rbtnFacturacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Aca va la facturaion");
            //rediseñar interface
        }

        private void button54_Click_2(object sender, EventArgs e)
        {
            var n = 49304904;
            var d = 13049;
            var c = (n / d).ToString("D0");
            var f = 338493849.ToString("D");
        }

        private void rbChequeRechazadoBanco_Click(object sender, EventArgs e)
        {
            var f = new FrmFI52RechazarChequeEntidadFinanciera();
            f.Show();
        }
        private void rbGestionRechazo_Click(object sender, EventArgs e)
        {
            var f = new FrmFI54GestionEntregaRechazos();
            f.Show();
        }
        private void rbNuevoCliennte_Click(object sender, EventArgs e)
        {
            RunNewTransaction("CL1");
        }
        private void rbEditarClientne_Click(object sender, EventArgs e)
        {
            RunNewTransaction("CL2");
        }
        private void rbVerCliente_Click(object sender, EventArgs e)
        {
            RunNewTransaction("CL3");
        }
        private void rbCrearMaterial_Click(object sender, EventArgs e)
        {
            RunNewTransaction("MM1");
        }

        private void button63_Click(object sender, EventArgs e)
        {
            var f = new FrmMdv02VendorABMDetail(1);
            f.Show();

        }

        private void rbTaxModuleConfig_Click(object sender, EventArgs e)
        {
            var f = new FrmFI13TaxConfig();
            f.Show();
        }

        private void btnTestCustomerSearchControl_Click(object sender, EventArgs e)
        {
            var f = new FrmCustomerSearchTest();
            f.Show();

        }

        private void rbExitMAS_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
