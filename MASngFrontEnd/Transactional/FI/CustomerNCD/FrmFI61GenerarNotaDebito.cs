using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData.Customer_Master;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.ContaFromDocuments;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Customers;
using Tecser.Business.VBTools;
using TSControls;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI61GenerarNotaDebito : Form
    {
        private CustomerNd _nd;//Documento Principal
        private CustomerNd _nd2;//Documento Secundario
        private bool _existeDocumentoSecundario = false; //Defualt NO
        private ModoEjecucion _modoAfip;
        private int _idCliente;
        private CustomerNd.MotivoNotaDebito _motivoDebito;
        private Lx _lx;
        private ManageDocumentType.TipoDocumento _tipoDocumento = ManageDocumentType.TipoDocumento.NoDefinido;
        private ManageDocumentType.TipoDocumento _tipoDocumento2 = ManageDocumentType.TipoDocumento.NoDefinido;
        private DocumentFIStatusManager.StatusHeader _statusDocumento = DocumentFIStatusManager.StatusHeader.Pendiente;
        private DocumentFIStatusManager.StatusHeader _statusDocumento2 = DocumentFIStatusManager.StatusHeader.Pendiente;
        private int _idRetorno = -1; //ID de Retorno de la seleccion de documento


        public FrmFI61GenerarNotaDebito(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }
        public FrmFI61GenerarNotaDebito()
        {
            InitializeComponent();
        }
        public FrmFI61GenerarNotaDebito(int idFactura, int modo)
        {
            //todo Constructor para carga de documentos existente
        }
        private enum Lx
        {
            L1,
            L2,
            NoSeleccionado
        };

        private void FrmFI61GenerarNotaDebito_Load(object sender, EventArgs e)
        {
            MapCustomerData();
            _lx = Lx.NoSeleccionado;
            txtStatusDoc1.Text = _statusDocumento.ToString();
            rPanelContabilizacion.Enabled = false;
            rPanelRegistracion.Enabled = false;
            ribbonNotaDebito.ActiveTab = rTabCliente;
            cTc.SetValue = new ExchangeRateManager().GetExchangeRate(dtpFechaDocumento.Value);
        }
        private void MapCustomerData()
        {
            if (_idCliente == -1)
            {
                txtRazonSocial.Text = null;
                txtCuit.Text = null;
                cCuitOk.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtIva.Text = @"Responsable Inscripto";
                txtProvincia.Text = null;
                txtVendedor.Text = null;
                return;
            }

            var c = new CustomerManager().GetCustomerBillToData(_idCliente);
            if (c != null)
            {
                txtRazonSocial.Text = c.cli_rsocial;
                txtCuit.Text = c.CUIT;
                var x = new CuitValidation().ValidarCuit(c.CUIT);
                cCuitOk.SetLights = x ? CtlSemaforo.ColoresSemaforo.Verde : CtlSemaforo.ColoresSemaforo.Rojo;
                txtIva.Text = @"Responsable Inscripto";
                txtProvincia.Text = c.Direfactu_Provincia;
                var c2 = c.T0007_CLI_ENTREGA.FirstOrDefault(d => d.Activo);
                if (c2 != null)
                {
                    txtVendedor.Text = c2.Vendedor;
                }
            }
        }

        #region BotonesRibbon
        private void rL1_Click(object sender, EventArgs e)
        {
            if (_idCliente < 1)
            {
                MessageBox.Show(@"Debe Seleccionar el Cliente antes de Continuar", @"Seleecion Incompleta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _lx = Lx.L1;
            txtLx.Text = @"L1";
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add("Nota Debito 'A'");
            cmbTipoDocumento.Items.Add("Documento Interno 'X'");
            cmbTipoDocumento.Items.Add("Ajuste Interno 'AJ'");
            cmbTipoDocumento.SelectedItem = "Nota Debito 'A'";
            zLX.Text = @"TIPO L1";
        }
        private void rL2_Click(object sender, EventArgs e)
        {
            if (_idCliente < 1)
            {
                MessageBox.Show(@"Debe Seleccionar el Cliente antes de Continuar", @"Seleecion Incompleta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _lx = Lx.L2;
            txtLx.Text = @"L2";
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add("Nota Debito 'X'");
            cmbTipoDocumento.Items.Add("Ajuste Interno 'AJ'");
            cmbTipoDocumento.SelectedItem = "Nota Debito 'X'";
            zLX.Text = @"TIPO L2";
        }
        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lx == Lx.NoSeleccionado)
            {
                txtTdoc.Text = null;
                MessageBox.Show(@"Debe seleccionar el tipo de operacion", @"Falta Tipo LX", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (cmbTipoDocumento.SelectedIndex == -1)
            {
                txtTdoc.Text = null;
                return;
            }

            switch (cmbTipoDocumento.SelectedItem.ToString())
            {
                case "Nota Debito 'A'":
                    _tipoDocumento = _lx == Lx.L1
                        ? ManageDocumentType.TipoDocumento.NotaDebitoVentaA
                        : ManageDocumentType.TipoDocumento.NotaDebitoVenta2;
                    txtTdoc.Text = @"ND";
                    break;
                case "Documento Interno 'X'":
                    _tipoDocumento = ManageDocumentType.TipoDocumento.DebitoNoFiscalCli;
                    txtTdoc.Text = @"DX";
                    break;
                case "Ajuste Interno 'AJ'":
                    _tipoDocumento = ManageDocumentType.TipoDocumento.AjusteContable;
                    txtTdoc.Text = @"AJ";
                    break;
                case "Nota Debito 'X'":
                    _tipoDocumento = ManageDocumentType.TipoDocumento.NotaDebitoVenta2;
                    txtTdoc.Text = @"ND";
                    break;
            }
        }
        private void rbtnChooseCustomer_Click(object sender, EventArgs e)
        {
            if (_statusDocumento != DocumentFIStatusManager.StatusHeader.Pendiente)
            {
                MessageBox.Show(@"El Estado del documento ya no permite la modificacion del Cliente",
                    @"Error en Modificacion de Cliente");
                return;
            }

            using (var f0 = new FrmMdc01CustomerSearch(4, ""))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK || DialogResult == DialogResult.None)
                {
                    _idCliente = f0.ClienteSeleccionado;
                }
                else
                {
                    MessageBox.Show(@"Se ha cancelado la seleccion del cliente", @"Cliente No Seleccionado",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _idCliente = -1;
                }

                MapCustomerData();
            }
        }
        private void rbtnDetalleCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Este boton aun no se encuentra activo", @"Funcion en Desarrollo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!OkRegistrar())
                return;

            rTabDocumento.Enabled = false;
            _nd.Registrar(txtMotivoGeneralDocumento.Text); //registracion documento
            MapHeaderDocumento1();

            if (_existeDocumentoSecundario)
            {
                _nd2.Registrar(txtSDescripcionInterna2.Text);
                MapHeaderDocumento2();
                MessageBox.Show(@"Se ha Registrado Correctamente el Documento IDFactura" + _nd.GetId400().ToString() +
                                Environment.NewLine +
                                @"Se ha Registrado Correctamente el Documento IDFactura" + _nd2.GetId400().ToString(),
                    @"Registracion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Se ha Registrado Correctamente el Documento IDFactura" + _nd.GetId400().ToString(),
                    @"Registracion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            btnRegistrar.Enabled = false;
            btnUnregistrar.Enabled = true;
            rPanelContabilizacion.Enabled = true;
            btnSolicitarCae.Enabled = false;
            btnContabilizar.Enabled = true;
            txtMotivoGeneralDocumento.Enabled = false;
        }
        private void btnContabilizar_Click(object sender, EventArgs e)
        {
            //ver si se puede contabilizar
            if (_nd.GetId400() < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error y no se puede contabilizar el Documento #1",
                    @"Error al Intentar Contabilizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_existeDocumentoSecundario && _nd2.GetId400() < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error y no se puede contabilizar el Documento #2",
                    @"Error al Intentar Contabilizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_motivoDebito == CustomerNd.MotivoNotaDebito.AnulaDocumento)
            {
                //*** Motivo ND Anulacion completa de Nota de Credito
                var zz = new ContaClienteNotaDebitoL2(_nd.GetId400(), _idCliente, txtTdoc.Text);
                zz.ContabilizacionAnulaDocumentoCompleto();
                txtIdCtaCte1.Text = zz.IdCtaCte.ToString();
                txtNas1.Text = zz.RtnAsiento.IdDocu.ToString();
                var gestionStatus = new GestionT400Status(_nd.GetId400());
                if (_lx == Lx.L1 && _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA)
                {
                    //Si es ND --> va a Pendiente CAE
                    _statusDocumento = gestionStatus.SetContabilizada(zz.IdCtaCte, zz.RtnAsiento.IdDocu, zz.RtnAsiento.Nasx1);
                    _statusDocumento = gestionStatus.SetPendienteCae();
                }
                else
                {
                    //Si es DX --> va a Contabilizada
                    _statusDocumento = gestionStatus.SetContabilizada(zz.IdCtaCte, zz.RtnAsiento.IdDocu, zz.RtnAsiento.Nasx1);
                    new MargenDocument().AddItemNotaCredito(_nd.GetId300());
                }

            }
            else
            {
                //*** Motivo Cheque Rechazado
                //Pueden existir 2 documentos[Si tiene Gastos/IVA] *Doc1 => Cheque
                //Esta parte seguro que No Va a Operaciones
                var zz1 = new ContaClienteNotaDebitoL2(_nd.GetId400(), _idCliente, txtTdoc.Text);
                zz1.ContabilizaCompletoHeaderND();
                txtIdCtaCte1.Text = zz1.IdCtaCte.ToString();
                txtNas1.Text = zz1.RtnAsiento.IdDocu.ToString();
                var gestionStatus = new GestionT400Status(_nd.GetId400());
                if (_lx == Lx.L1 && _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA)
                {
                    //Si es ND --> va a Pendiente CAE
                    _statusDocumento = gestionStatus.SetContabilizada(zz1.IdCtaCte, zz1.RtnAsiento.IdDocu, zz1.RtnAsiento.Nasx1);
                    _statusDocumento = gestionStatus.SetPendienteCae();
                }
                else
                {
                    //Si es DX --> va a Contabilizada
                    _statusDocumento = gestionStatus.SetContabilizada(zz1.IdCtaCte, zz1.RtnAsiento.IdDocu, zz1.RtnAsiento.Nasx1);
                    //Update en Tabla T0156-Rechazo
                    new ChequeRechazadoManager().UpdateAfterContabilizacionNd(_idRetorno, Convert.ToInt32(txtNas1.Text),
                        _nd.GetId400(), txtNumeroDocumento.Text);

                }

                //Contabilizacion de segundo documento [Siempre Gastos]
                if (_existeDocumentoSecundario)
                {
                    var zz2 = new ContaClienteNotaDebitoL2(_nd2.GetId400(), _idCliente, txtTipoDocumento2.Text);
                    zz2.ContabilizaCompletoHeaderND();
                    txtNas2.Text = zz2.RtnAsiento.IdDocu.ToString();
                    txtIdCtaCte2.Text = zz2.IdCtaCte.ToString();
                    var gestionStatus2 = new GestionT400Status(_nd2.GetId400());
                    if (_lx == Lx.L1 && txtTipoDocumento2.Text == @"ND")
                    {
                        _statusDocumento2 = gestionStatus2.SetContabilizada(zz2.IdCtaCte, zz2.RtnAsiento.IdDocu,
                            zz2.RtnAsiento.Nasx1);
                        _statusDocumento2 = gestionStatus2.SetPendienteCae();
                    }
                    else
                    {
                        _statusDocumento2 = gestionStatus2.SetContabilizada(zz2.IdCtaCte, zz2.RtnAsiento.IdDocu,
                            zz2.RtnAsiento.Nasx1);
                    }
                }
            }

            //aca van acciones POST-Contabilizacion
            if (_motivoDebito == CustomerNd.MotivoNotaDebito.ChequeSinRechazo)
            {
                //cuando el cheque es devuelto se actualiza tabla cheque
                new ChequeRechazadoManager().SetChequeRechazadoTablaCheque(_idRetorno, txtMotivoGeneralDocumento.Text);
            }
            SetScreenStatus();
        }
        private void btnAnulaDocumento_Click(object sender, EventArgs e)
        {
            _motivoDebito = CustomerNd.MotivoNotaDebito.AnulaDocumento;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnChequeRechazado_Click(object sender, EventArgs e)
        {
            _motivoDebito = CustomerNd.MotivoNotaDebito.ChequeRechazado;
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add("Documento Interno 'X'");
            cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnDevChSR_Click(object sender, EventArgs e)
        {
            _motivoDebito = CustomerNd.MotivoNotaDebito.ChequeSinRechazo;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnGastosFinancieros_Click(object sender, EventArgs e)
        {
            _motivoDebito = CustomerNd.MotivoNotaDebito.GastoBancario;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnSolicitarCae_Click(object sender, EventArgs e)
        {
            _modoAfip = GlobalApp.Modo == ModoApp.Produccion ? ModoEjecucion.Produccion : ModoEjecucion.Testeo;
            if (_modoAfip == ModoEjecucion.Testeo)
            {
                MessageBox.Show(
                    @"Atencion SE esta ejecutando la aplicacion en modo TESTEO" + Environment.NewLine +
                    @"El CAE otorgado NO SERA VALIDO para fines Fiscales",
                    @"Modo Aplicacion = * TESTEO *", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (_statusDocumento == DocumentFIStatusManager.StatusHeader.PendienteCAE)
            {
                if (new FacturacionElectronicaTecser(_modoAfip).CheckSiPermiteSolicitarCAE(_nd.GetId400()) == false)
                {
                    MessageBox.Show(
                        @"El Documento No se encuentra en condiciones de solicitar CAE" + Environment.NewLine +
                        @"El Documento no esta en estado 'PendienteCAE'",
                        @"Solicitud de CAE *No Permitida*", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SolicitaCaeCompletaData(1, _nd.GetId400(), _nd.IdFacturaAsociada, _nd.PeriodoDesde, _nd.PeriodoHasta);
                    new MargenDocument().AddItemNotaCredito(_nd.GetId300());
                }
            }

            if (_statusDocumento2 == DocumentFIStatusManager.StatusHeader.PendienteCAE)
            {
                if (new FacturacionElectronicaTecser(_modoAfip).CheckSiPermiteSolicitarCAE(_nd2.GetId400()) == false)
                {
                    MessageBox.Show(
                        @"El Documento No se encuentra en condiciones de solicitar CAE" + Environment.NewLine +
                        @"El Documento no esta en estado 'PendienteCAE'",
                        @"Solicitud de CAE *No Permitida*", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SolicitaCaeCompletaData(2, _nd2.GetId400(), _nd2.IdFacturaAsociada, _nd2.PeriodoDesde,
                        _nd2.PeriodoHasta);
                    //Esta parte no va a Operaciones
                }
            }
        }
        #endregion

        #region Acciones ND
        private void RedirigeAccionDespuesPresionarBoton()
        {
            //Los botones de accion redirigen a esta funcion -- Valida -- Activa Ribbon 
            //Redirige a Accion Especifica segun el motivo/boton presionado
            if (_lx == Lx.NoSeleccionado)
            {
                MessageBox.Show(
                    @"Debe Seleccionar el tipo de Operacion (L1/L2) antes de seleccionar el Motivo General de la Nota de Debito",
                    @"Falta Seleccion Tipo OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _motivoDebito = CustomerNd.MotivoNotaDebito.SinMotivo;
                return;
            }
            txtTipoNotaDebito.Text = _motivoDebito.ToString();
            ribbonNotaDebito.ActiveTab = rTabContabilizacion;
            rPanelRegistracion.Enabled = true;
            btnUnregistrar.Enabled = false;
            switch (_motivoDebito)
            {
                case CustomerNd.MotivoNotaDebito.SinMotivo:
                    MessageBox.Show(@"Seleccione un Motivo de Documento para continuar", @"Falta Motivo Nota Debito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case CustomerNd.MotivoNotaDebito.AnulaDocumento:
                    FxAnulaDocumentoCompleto();
                    break;
                case CustomerNd.MotivoNotaDebito.ChequeRechazado:
                    FxChequeRechazado();
                    break;
                case CustomerNd.MotivoNotaDebito.ChequeSinRechazo:
                    FxDevolucionChequeSinRechazo();
                    break;
                case CustomerNd.MotivoNotaDebito.DiferenciaPrecio:
                    break;
                case CustomerNd.MotivoNotaDebito.DiferenciaCambio:
                    break;
                case CustomerNd.MotivoNotaDebito.DiferenciaKg:
                    break;
                case CustomerNd.MotivoNotaDebito.CargoGralDocumentos:
                    break;
                case CustomerNd.MotivoNotaDebito.CargoGralPeriodo:
                    break;
                case CustomerNd.MotivoNotaDebito.GastoBancario:
                    FxGastosBancariosFinancieros();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Si es Anulacion de documento completo con Nota de Debito se Refiere a Anular por Completo una Nota de Credito
        /// Siempre va a ser un solo documento de contrapartida al que se anula.
        /// </summary>
        private void FxAnulaDocumentoCompleto()
        {
            if (cmbAutorizadoPor.SelectedItem == null)
            {
                MessageBox.Show(@"Debe indicar quien Autoriza la generacion del Documento", @"Falta Autorizante",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            PanelTipoND.Enabled = false;

            cmbTipoDocumento.Items.Clear();
            tabFi2.Visible = false;
            string autorizado = "NO-Autorizado";
            if (cmbAutorizadoPor.SelectedItem != null) autorizado = cmbAutorizadoPor.SelectedItem.Text;

            using (var f0 = new FrmFI62SeleccionNcAnular(_idCliente, _lx.ToString()))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (f0.Id400Selected == null)
                    {
                        MessageBox.Show(@"No se ha seleccionado ningun documento - No se puede continuar",
                            @"Error en seleccion de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _idRetorno = f0.Id400Selected.Value; //Documento T400 a Anular
                    var tdocOrigen = f0.TDOC;
                    //Selecciona el Tipo de Documento a Crear Automaticamente de acuerdo al documento a Anular
                    if (tdocOrigen == "NC")
                    {
                        if (_lx == Lx.L1)
                        {
                            _tipoDocumento = ManageDocumentType.TipoDocumento.NotaDebitoVentaA;
                            cmbTipoDocumento.Items.Add("Nota Debito 'A'");
                            cmbTipoDocumento.SelectedItem = "Nota Debito 'A'";
                        }
                        else
                        {
                            _tipoDocumento = ManageDocumentType.TipoDocumento.NotaDebitoVenta2;
                            cmbTipoDocumento.Items.Add("Nota Debito 'X'");
                            cmbTipoDocumento.SelectedItem = "Nota Debito 'X'";
                        }
                    }
                    else
                    {
                        if (tdocOrigen == "CX")
                        {
                            _tipoDocumento = ManageDocumentType.TipoDocumento.DebitoNoFiscalCli;
                            cmbTipoDocumento.Items.Add("Documento Interno 'X'");
                            cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
                        }
                        else
                        {
                            MessageBox.Show(@"Tipo de Documento Origen no Manejado",
                                @"Error en Tipo de Documento Origen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    _nd = new CustomerNd(_motivoDebito);
                    _nd.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", false, autorizado);
                    _nd.AnulaNotaCreditoCompleta(_idRetorno);

                    txtMotivoGeneralDocumento.BackColor = string.IsNullOrEmpty(txtMotivoGeneralDocumento.Text) ? Color.LightPink : Color.LightGreen;
                    txtCondicionVenta.Text = @"0E - Pago Contraentrega Documento";

                    dgv400.DataSource = _nd.GetItems();
                    MapTotalesFactura400(_nd.GetTotalesFromHeader());
                    MapHeaderDocumento1();
                    _existeDocumentoSecundario = false;
                }
                else
                {
                    //No se selecciona documento
                    MessageBox.Show(@"No se ha seleccionado documento", @"Error en Seleccion de Documento",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Cheques Rechazados o Devolucion de Cheques a Cliente
        /// </summary>
        private void FxChequeRechazado()
        {
            PanelTipoND.Enabled = false;

            if (_lx == Lx.L1)
            {
                //Disposicion AFIP ND no se debe hacer para cheque pero dejamos la posibilidad
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Documento Interno 'X'");
                cmbTipoDocumento.Items.Add("Nota Debito 'A'");
                cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
            }
            else
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
            }
            tabFi2.Visible = false;
            string autorizado = "NO-Autorizado";
            if (cmbAutorizadoPor.SelectedItem != null) autorizado = cmbAutorizadoPor.SelectedItem.Text;
            _nd = new CustomerNd(_motivoDebito);
            _nd.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", false, autorizado);
            using (var f0 = new FrmFI63SeleccionDevolucionChequeACliente(_nd, 1, _lx.ToString())) //cambiar ch
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _idRetorno = f0.IdChequeSeleccionado.Value;
                    _nd.SetIdChequeRechazado(_idRetorno);
                    var registroRechazo = new ChequeRechazadoManager().GetRegistroChequeRech(_idRetorno);
                    txtMotivoGeneralDocumento.Text = @"Rechazo Motivo = " + registroRechazo.MOTIVO_RE;
                    txtMotivoGeneralDocumento.BackColor = Color.LightGreen;
                    txtCondicionVenta.Text = @"0E - Pago Contraentrega Documento";
                    dgv400.DataSource = _nd.GetItems();
                    MapTotalesFactura400(_nd.GetTotalesFromHeader());
                    MapHeaderDocumento1();
                    _existeDocumentoSecundario = f0._documentoAdicional;
                    if (f0._documentoAdicional)
                    {
                        _nd2 = f0.ND2;
                        _nd2.SetAutorizacionDocumento(autorizado); //seteo la autorizacion 
                        tabFi2.Visible = true;
                        dgvNotaDebitoGastos.DataSource = _nd2.GetItems();
                        MapTotalesFactura400_Gastos(_nd2.GetTotalesFromHeader());
                        MapHeaderDocumento2();
                        txtSDescripcionInterna2.Text = @"Debito x Gastos Cheque Rechazado @" + _idRetorno.ToString();
                    }
                }
                else
                {
                    _nd = null;
                    MessageBox.Show(@"Se Anulo la Seleccion del Cheque", @"Anulacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }
        }
        private void FxGastosBancariosFinancieros()
        {
            PanelTipoND.Enabled = false;

            if (_lx == Lx.L1)
            {
                //Disposicion AFIP ND no se debe hacer para cheque pero dejamos la posibilidad
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Nota Debito 'A'");
                cmbTipoDocumento.SelectedItem = "Nota Debito 'A'";
            }
            else
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Documento Interno 'X'");
                cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
            }
            tabFi2.Visible = false;
            string autorizado = "NO-Autorizado";
            if (cmbAutorizadoPor.SelectedItem != null) autorizado = cmbAutorizadoPor.SelectedItem.Text;
            _nd = new CustomerNd(_motivoDebito);
            _nd.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", false, autorizado);
            using (var f0 = new FrmFI65GastosFinancieros(_nd, _motivoDebito))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _nd.SetPeriodoAsociado(dtpFechaDocumento.Value, dtpFechaDocumento.Value);
                    txtMotivoGeneralDocumento.BackColor = Color.LightGreen;
                    txtCondicionVenta.Text = @"0E - Pago Contraentrega Documento";
                    dgv400.DataSource = _nd.GetItems();
                    MapTotalesFactura400(_nd.GetTotalesFromHeader());
                    MapHeaderDocumento1();
                }
                else
                {
                    _nd = null;
                    MessageBox.Show(@"Se Anulo la Accion", @"Anulacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }
        }
        /// <summary>
        /// Devolucion de Cheque sin rechazo
        /// </summary>
        private void FxDevolucionChequeSinRechazo()
        {
            PanelTipoND.Enabled = false;
            if (_lx == Lx.L1)
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Documento Interno 'X'");
                cmbTipoDocumento.Items.Add("Nota Debito 'A'");
                cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
            }
            else
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
            }
            var autorizado = "NO-Autorizado";
            if (cmbAutorizadoPor.SelectedItem != null) autorizado = cmbAutorizadoPor.SelectedItem.Text;
            _nd = new CustomerNd(_motivoDebito);
            _nd.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", false, autorizado);
            using (var f0 = new FrmFi64DevolucionChequeCliente(_nd))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _idRetorno = f0.IdChequeSeleccionado.Value;
                    _nd.SetIdChequeRechazado(_idRetorno);
                    txtCondicionVenta.Text = @"0E - Pago Contraentrega Documento";
                    dgv400.DataSource = _nd.GetItems();
                    MapTotalesFactura400(_nd.GetTotalesFromHeader());
                    MapHeaderDocumento1();
                    _existeDocumentoSecundario = f0._documentoAdicional;
                    if (f0._documentoAdicional)
                    {
                        _nd2 = f0.NdGastosL1;
                        _nd2.SetAutorizacionDocumento(cmbAutorizadoPor.SelectedItem.Text); //seteo la autorizacion 
                        tabFi2.Visible = true;
                        dgvNotaDebitoGastos.DataSource = _nd2.GetItems();
                        MapTotalesFactura400_Gastos(_nd2.GetTotalesFromHeader());
                        MapHeaderDocumento2();
                        txtSDescripcionInterna2.Text = @"Debito x Gastos Cheque Rechazado @" + _idRetorno.ToString();
                    }
                }
                else
                {
                    _nd = null;
                }
            }
        }
        #endregion

        private void MapTotalesFactura400(TotalesCustomerFi total)
        {
            if (!total.OK)
            {
                MessageBox.Show(@"Error en calculo de Totales");
            }

            cBruto.SetValue = total.Bruto;
            cDescuento.SetValue = total.Descuento;
            cSubtotal.SetValue = total.Subtotal;
            cImponible.SetValue = total.BaseImponible;
            cIva.SetValue = total.Iva21;
            cPercepcionIIBB.SetValue = total.IIBB;
            cTotalFinal.SetValue = total.TotalFinal;
        }
        private void MapTotalesFactura400_Gastos(TotalesCustomerFi total)
        {
            if (!total.OK)
            {
                MessageBox.Show(@"Error en calculo de Totales");
            }

            cBrutoGastos.SetValue = total.Bruto;
            cDescuentoGasto.SetValue = total.Descuento;
            cSubtotalGasto.SetValue = total.Subtotal;
            cImponibleGasto.SetValue = total.BaseImponible;
            cIvaGasto.SetValue = total.Iva21;
            cIibbGasto.SetValue = total.IIBB;
            cNetoGasto.SetValue = total.TotalFinal;
        }
        private void MapHeaderDocumento2()
        {
            var h2 = _nd2.GetHeader();
            txtTipoDocumento2.Text = h2.TIPO_DOC;
            txtnumeroDoc2.Text = h2.NumeroDoc;
            txtStatusDoc2.Text = h2.StatusFactura;
            txtId400Gasto.Text = _nd2.Id400.ToString();
            //
            txtIdNcd2.Text = _nd2.Id300.ToString();
            //
            var h3 = _nd2.GetHeader300();
            txtSNumeroDoc2.Text = h3.NDOC;
            txtSIdNcd2.Text = h3.IDH.ToString();
            txtSDescripcionInterna2.Text = h3.COMENTARIO;
            txtSFechaRegistro2.Text = h3.FECHA.ToString("d");
            txtSImporteArs2.Text = h3.ImporteARS.ToString("C2");
            txtSImporteUsd2.Text = h3.ImporteUSD.ToString("C2");
            txtSPeriodoDesde2.Text = h3.PeriodoAjusteDesde.ToString();
            txtSPeriodoHasta2.Text = h3.PeriodoAjusteHasta.ToString();
            txtSIdFacturaAsociada2.Text = _nd2.NumeroDocumentoAsociado;
            txtSLx2.Text = h3.LX;
        }
        private void MapHeaderDocumento1()
        {
            var h = _nd.GetHeader();
            txtId400.Text = _nd.Id400.ToString();
            txtStatusDoc1.Text = h.StatusFactura;
            txtNumeroDocumento.Text = h.NumeroDoc;
            //
            var h3 = _nd.GetHeader300();
            txtSNumeroDoc1.Text = h3.NDOC;
            txtSIdNcd1.Text = h3.IDH.ToString();
            txtSDescripcionInternar1.Text = h3.COMENTARIO;
            txtSFechaRegistro1.Text = h3.FECHA.ToString("d");
            txtSImporteArs1.Text = h3.ImporteARS.ToString("C2");
            txtSImporteUsd1.Text = h3.ImporteUSD.ToString("C2");
            txtSPeriodoDesde1.Text = h3.PeriodoAjusteDesde.ToString();
            txtSPeriodoHasta1.Text = h3.PeriodoAjusteHasta.ToString();
            txtSIdFacturaAsociada1.Text = _nd.NumeroDocumentoAsociado;
            txtSLx1.Text = h3.LX;
        }
        private bool OkRegistrar()
        {
            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NoDefinido)
            {
                MessageBox.Show(@"No se ha definido aun un tipo de documento a Registrar", @"Documento Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtMotivoGeneralDocumento.Text))
            {
                MessageBox.Show(@"Debe completar el motivo por el que se está generando el documento (interno)",
                    @"Fata Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tt.Show("Complete este Dato", txtMotivoGeneralDocumento, 700);
                return false;
            }
            tt.Show("", txtMotivoGeneralDocumento);
            return true;
        }

        private void SetScreenStatus()
        {
            rPanelRegistracion.Enabled = false;
            rPanelContabilizacion.Enabled = false;
            btnContabilizar.Enabled = false;
            btnSolicitarCae.Enabled = false;

            txtStatusDoc1.Text = _statusDocumento.ToString();
            txtStatusDoc2.Text = _statusDocumento2.ToString();
            switch (_statusDocumento)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    break;
                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    //esta lista par ser impresa
                    break;
                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    //esta lista para ser impresa
                    txtStatusDoc1.BackColor = Color.LightGreen;
                    break;
                case DocumentFIStatusManager.StatusHeader.Impresa:
                    break;
                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    break;
                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    txtStatusDoc1.BackColor = Color.LightCoral;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (_statusDocumento2)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    break;
                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    //esta lista par ser impresa
                    break;
                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    //esta lista para ser impresa
                    txtStatusDoc2.BackColor = Color.LightGreen;
                    break;
                case DocumentFIStatusManager.StatusHeader.Impresa:
                    break;
                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    break;
                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    txtStatusDoc2.BackColor = Color.LightCoral;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_statusDocumento2 == DocumentFIStatusManager.StatusHeader.PendienteCAE ||
                _statusDocumento == DocumentFIStatusManager.StatusHeader.PendienteCAE)
            {
                rPanelContabilizacion.Enabled = true;
                btnSolicitarCae.Enabled = true;
            }
        }
        private void SolicitaCaeCompletaData(int posicionDocumento, int iddoc, int? idDocAnula, DateTime? fechaD, DateTime? fechaH)
        {
            var fe = new FacturacionElectronicaTecser(_modoAfip);
            var resultado = idDocAnula != null
                ? fe.SolicitudCAEFromT0400(iddoc, idDocAnula, null, null)
                : fe.SolicitudCAEFromT0400(iddoc, null, fechaD, fechaH);

            if (resultado.Resultado == "A")
            {
                if (posicionDocumento == 1)
                {
                    txtCae1.Text = resultado.CAE;
                    txtVencimientoCae1.Text = resultado.VencimientoCAE.ToString("d");
                    txtNumeroDocumento.Text = resultado.NumeroDocumentoOtorgadoCompleto;
                    txtNumeroDoc1.Text = resultado.NumeroDocumentoOtorgadoCompleto;
                    fe.UpdateDataAfterDocumentNumberGetFromAFIP(iddoc, resultado.PuntoVenta, resultado.ComprobanteHasta, resultado.CAE,
                        resultado.VencimientoCAE, Convert.ToInt32(txtNas1.Text));
                    _statusDocumento = DocumentFIStatusManager.StatusHeader.Aprobada;
                    if (_motivoDebito == CustomerNd.MotivoNotaDebito.ChequeRechazado)
                    {
                        //En este caso el CHRECH se hizo por ND 
                        new ChequeRechazadoManager().UpdateAfterContabilizacionNd(_idRetorno,
                            Convert.ToInt32(txtNas1.Text),
                            iddoc, txtNumeroDocumento.Text);
                    }
                }
                else
                {
                    txtCae2.Text = resultado.CAE;
                    txtVencimientoCae2.Text = resultado.VencimientoCAE.ToString("d");
                    txtnumeroDoc2.Text = resultado.NumeroDocumentoOtorgadoCompleto;
                    fe.UpdateDataAfterDocumentNumberGetFromAFIP(iddoc, resultado.PuntoVenta, resultado.ComprobanteHasta, resultado.CAE,
                        resultado.VencimientoCAE, Convert.ToInt32(txtNas2.Text));
                    _statusDocumento2 = DocumentFIStatusManager.StatusHeader.Aprobada;
                }

                //Chequea si hay que ingresar Percepcion IIBB
                if (posicionDocumento == 1)
                {
                    var xdoc = _nd.GetHeader();
                    if (xdoc.TotalIIBB > 0)
                    {
                        new PercepcionesManager().AddFacturaPercepcion(iddoc);
                    }
                }
                else
                {
                    var xdoc = _nd2.GetHeader();
                    if (xdoc.TotalIIBB > 0)
                    {
                        new PercepcionesManager().AddFacturaPercepcion(iddoc);
                    }
                }
                var st = new GestionT400Status(iddoc);
                st.SetAprobadaCae(resultado.CAE, resultado.VencimientoCAE, resultado.PuntoVenta, resultado.ComprobanteHasta);
                SetScreenStatus();
            }
            else
            {
                MessageBox.Show(@"Ha Ocurrido un error al solicitar el CAE", @"Error en SOLICITUD DE CAE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
