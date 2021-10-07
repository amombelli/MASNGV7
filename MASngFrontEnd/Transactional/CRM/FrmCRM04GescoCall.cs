using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CRM;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmCRM04GescoCall : Form
    {

        //------------------------------------------------------------------------------------------
        private readonly int _idCliente;
        public int IdRegistro { get; private set; }
        private Gesco.DireccionMensaje _origenContacto;
        private Gesco.MotivoContacto _motivoContacto;
        private bool _motivoSeleccionado = false;
        private DateTime? FechaAcordadaPagoOriginal;

        //------------------------------------------------------------------------------------------
        public FrmCRM04GescoCall(int idCliente)
        {
            _idCliente = idCliente;
            IdRegistro = 0;
            InitializeComponent();
        }
        public FrmCRM04GescoCall(int idCliente, int idRegistro)
        {
            _idCliente = idCliente;
            IdRegistro = idRegistro;
            InitializeComponent();
        }

        private void FrmCRM04GescoCall_Load(object sender, EventArgs e)
        {
            txtDiasPago.Init(0, 300, 0);
            txtDiasProximaLlamada.Init(0, 300, 0);
            ckClienteEmpresa.Checked = false;
            ckEmpresaCliente.Checked = false;
            ckInterno.Checked = false;
            cmbMetodoContacto.SelectedItem = null;
            cFechaContacto.Value = DateTime.Today;
            //
            rbPago.Enabled = false;
            rbReconfirmaFecha.Enabled = false;
            rbCancelaPago.Enabled = false;
            rbConciliaCta.Enabled = false;
            rbCondicionPago.Enabled = false;
            rbEnvioFactura.Enabled = false;
            rbOtro.Enabled = false;
            //
            grpMotivoContacto.Enabled = false; //Se habilita al seleccionar origen
            panelCancelPago.Enabled = false; //Se habilita segun opciones Motivo
            panelFechaPago.Enabled = false; //Se habilita segun opciones Motivo
            panelNextCall.Enabled = false;

            txtMensaje.Enabled = false;

            txtDiasPago.Init(0, 300, 0);
            txtDiasProximaLlamada.Init(0, 300, 0);

            MapCustomerData();
            if (IdRegistro > 0)
            {
                //aca mapear valores del registro modo visualizacion
                LoadExistingData();
                return;
            }
            MapHeaderData();
            btnGuardar.Enabled = false;
        }

        private void LoadExistingData()
        {
            //Deshabilita todos los EventHandler
            this.ckClienteEmpresa.CheckedChanged -= new System.EventHandler(this.OrigenDeContacto_CheckedChanged);
            this.ckEmpresaCliente.CheckedChanged -= new System.EventHandler(this.OrigenDeContacto_CheckedChanged);
            this.ckInterno.CheckedChanged -= new System.EventHandler(this.OrigenDeContacto_CheckedChanged);
            this.rbPago.CheckedChanged -= new System.EventHandler(this.rbOtro_CheckedChanged);
            this.rbReconfirmaFecha.CheckedChanged -= new System.EventHandler(this.rbOtro_CheckedChanged);
            this.rbCancelaPago.CheckedChanged -= new System.EventHandler(this.rbOtro_CheckedChanged);
            this.rbConciliaCta.CheckedChanged -= new System.EventHandler(this.rbOtro_CheckedChanged);
            this.rbCondicionPago.CheckedChanged -= new System.EventHandler(this.rbOtro_CheckedChanged);
            this.rbEnvioFactura.CheckedChanged -= new System.EventHandler(this.rbOtro_CheckedChanged);
            this.rbOtro.CheckedChanged -= new System.EventHandler(this.rbOtro_CheckedChanged);
            this.ckCompromisoPago.CheckedChanged -= new System.EventHandler(this.ckCompromisoPago_CheckedChanged);
            btnGuardar.Enabled = false;
            ckCuentaCorrienteConciliadaOk.AutoCheck = false;
            ckCuentaCorrientePresentaDiferencias.AutoCheck = false;
            panelNextCall.Enabled = false;
            var info = new Gesco().VerLlamada(_idCliente, IdRegistro);

            _origenContacto = new Gesco().MapDireccionMensajeFromString(info.TipoMensajeECI);

            switch (_origenContacto)
            {
                case Gesco.DireccionMensaje.Interno:
                    ckInterno.Checked = true;
                    break;
                case Gesco.DireccionMensaje.ClienteEmpresa:
                    ckClienteEmpresa.Checked = true;
                    break;
                case Gesco.DireccionMensaje.EmpresaCliente:
                    ckEmpresaCliente.Checked = true;
                    break;
                default:
                    break;
            }

            switch (info.MotivoPrincipalContacto)
            {
                case 0:
                    rbPago.Checked = true;
                    break;
                case 1:
                    rbReconfirmaFecha.Checked = true;
                    break;
                case 2:
                    rbCancelaPago.Checked = true;
                    break;
                case 3:
                    rbConciliaCta.Checked = true;
                    break;
                case 4:
                    rbCondicionPago.Checked = true;
                    break;
                case 5:
                    rbEnvioFactura.Checked = true;
                    break;
                default:
                    rbOtro.Checked = true;
                    break;
            }
            cmbMetodoContacto.SelectedItem = info.MedioContacto;
            cFechaContacto.Value = info.FechaRegistro;
            txtPersonaContactada.Text = info.ContactoCliente;
            txtMensaje.Text = info.MensajeIO;
            if (info.FechaCompromisoPago.HasValue)
            {
                cFechaPagoConfirmada.Value = info.FechaCompromisoPago;
                ckCompromisoPago.Checked = true;
            }

            ckPagoCancelado.Checked = info.CanceloPago;
            ckFechaPagoModificada.Checked = info.FechaPagoModificada;
            txtMensajeCancel.Text = info.CanceloMotivo;
            ckCuentaCorrienteConciliadaOk.Checked = info.CuentaConciliadaOK;
            ckCuentaCorrientePresentaDiferencias.Checked = info.CuentaConDiferencias;
            if (info.ProximaLlamadaFecha.HasValue)
            {
                ctFechaProximaLlamada.Value = info.ProximaLlamadaFecha.Value;
            }


        }


        private void MapCustomerData()
        {
            var cust = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtRazonSocial.Text = cust.cli_rsocial;
            txtTelefonoCobranza.Text = cust.TELEFONO_COB;
            txtDiasHorarioPago.Text = cust.DIA_HORARIO_COBRO;
            txtContactoPaP.Text = cust.CONTACTO_COB;
            txtEmailPagoAProv.Text = cust.EMAIL_COBR;
            txtDireccionRetiroPago.Text = cust.DIRECCION_COBRO_ALT;
        }
        private void MapHeaderData()
        {
            var h = new Gesco().GetHeader(_idCliente);
            ckLlamadaPendiente.Checked = h.RequestCall;
            ckSeRequiereConciliacionCuenta.Checked = h.RequestConciliation;
            ckClienteTienePagoListo.Checked = h.PagoConfirmado;

            if (h.PagoConfirmado)
            {
                FechaAcordadaPagoOriginal = h.FechaPagoConfirmado;
                cNuevaFechaPago.Value = h.FechaPagoConfirmado;
            }

            if (ckLlamadaPendiente.Checked)
                ckLlamadaPendiente.BackColor = Color.Yellow;

            if (ckSeRequiereConciliacionCuenta.Checked)
                ckSeRequiereConciliacionCuenta.BackColor = Color.Yellow;

            if (ckClienteTienePagoListo.Checked)
                ckClienteTienePagoListo.BackColor = Color.Yellow;
        }
        private void OrigenDeContacto_CheckedChanged(object sender, EventArgs e)
        {
            this.ckClienteEmpresa.CheckedChanged -= new System.EventHandler(this.OrigenDeContacto_CheckedChanged);
            this.ckEmpresaCliente.CheckedChanged -= new System.EventHandler(this.OrigenDeContacto_CheckedChanged);
            this.ckInterno.CheckedChanged -= new System.EventHandler(this.OrigenDeContacto_CheckedChanged);

            var ck = (CheckBox)sender;
            ckClienteEmpresa.Checked = false;
            ckEmpresaCliente.Checked = false;
            ckInterno.Checked = false;
            switch (ck.Name)
            {
                case "ckClienteEmpresa":
                    ckClienteEmpresa.Checked = true;
                    _origenContacto = Gesco.DireccionMensaje.ClienteEmpresa;
                    break;

                case "ckEmpresaCliente":
                    ckEmpresaCliente.Checked = true;
                    _origenContacto = Gesco.DireccionMensaje.EmpresaCliente;
                    break;

                case "ckInterno":
                    ckInterno.Checked = true;
                    _origenContacto = Gesco.DireccionMensaje.Interno;
                    break;
                default:
                    break;
            }

            this.ckClienteEmpresa.CheckedChanged += new System.EventHandler(this.OrigenDeContacto_CheckedChanged);
            this.ckEmpresaCliente.CheckedChanged += new System.EventHandler(this.OrigenDeContacto_CheckedChanged);
            this.ckInterno.CheckedChanged += new System.EventHandler(this.OrigenDeContacto_CheckedChanged);

            //Habilita Motivos de Contacto
            grpMotivoContacto.Enabled = true;
            btnGuardar.Enabled = true;
            SetPermitidosSegunMotivoContacto();
        }
        private void SetPermitidosSegunMotivoContacto()
        {
            //De acuerdo al Origen del llamado activa/desactiva los motivos de contacto *rb
            rbPago.Enabled = true;
            rbReconfirmaFecha.Enabled = true;
            rbCancelaPago.Enabled = true;
            rbConciliaCta.Enabled = true;
            rbCondicionPago.Enabled = true;
            rbEnvioFactura.Enabled = true;
            rbOtro.Enabled = true;

            if (ckClienteTienePagoListo.Checked)
            {
                //si tiene pago listo NO permitirá agregar otra fecha de pago
                rbPago.Enabled = false;
            }
            else
            {
                //si no hay pago listo no puede cancelar un pago
                //no se puede reconfirmar fecha
                rbCancelaPago.Enabled = false;
                rbReconfirmaFecha.Enabled = false;
            }

            if (_origenContacto == Gesco.DireccionMensaje.ClienteEmpresa)
            {
                rbPago.Enabled = false;
                rbCondicionPago.Enabled = false;
            }

            if (_origenContacto == Gesco.DireccionMensaje.EmpresaCliente)
            {
                rbEnvioFactura.Enabled = false;
            }

            if (_origenContacto == Gesco.DireccionMensaje.Interno)
            {
                rbCancelaPago.Enabled = false;
                rbEnvioFactura.Enabled = false;
            }
        }

        private void ckCompromisoPago_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCompromisoPago.Checked == false)
            {
                //Al Retirar compromiso de pago si tenia un valor ingresado lo borra
                if (cFechaPagoConfirmada.Value != null)
                {
                    var r = MessageBox.Show(@"Desea Borrar la fecha de Pago ingresada?", @"Retiro de Fecha de Pago",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        cFechaPagoConfirmada.Value = null;
                        txtDiasPago.Text = @"0";
                        ckPagoCancelado.Checked = false;
                        ckFechaPagoModificada.Checked = false;
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Complete Fecha de Pago y el CheckBox se completara en forma automatica", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                ckCompromisoPago.Checked = false;
            }
        }
        private void txtDiasDecimal_Validated(object sender, EventArgs e)
        {
            if (cFechaContacto.Value == null)
            {
                cFechaContacto.Value = DateTime.Today;
            }
            ctFechaProximaLlamada.Value = cFechaContacto.Value.Value.AddDays(Convert.ToInt32(txtDiasProximaLlamada.ValueD));
        }

        private bool ValidarAccionOkToSave()
        {
            if ((ckClienteEmpresa.Checked || ckEmpresaCliente.Checked || ckInterno.Checked) == false)
            {
                MessageBox.Show(@"Debe completar el Iniciador de la Comunicacion",
                    @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (_motivoSeleccionado == false)
            {
                MessageBox.Show(@"Debe completar el Motivo Principal del Contacto",
                    @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (cmbMetodoContacto.SelectedItem == null)
            {
                MessageBox.Show(@"Debe completar el Metodo de Contacto",
                    @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (cFechaContacto.Value == null)
            {
                MessageBox.Show(@"Debe completar la fecha de Contacto (Doble Click = Hoy)",
                    @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (_origenContacto != Gesco.DireccionMensaje.Interno)
            {
                if (string.IsNullOrEmpty(txtPersonaContactada.Text))
                {
                    MessageBox.Show(
                        @"El nombre de la persona contactada esta en blanco. Coloque '?' si no sabe con quien habló o doble click para copiar el nombre de contacto 'default' o complete con el nombre correcto",
                        @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtMensaje.Text))
            {
                MessageBox.Show(
                    @"Debe Completar un mensaje Enviado/Recibido para permitir realizar un seguimiento",
                    @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (ckCompromisoPago.Checked)
            {
                if (cFechaPagoConfirmada.Value == null)
                {
                    MessageBox.Show(
                        @"Debe completar la fecha de compromiso de Pago. Valide la Direccion de Cobro/Horarios",
                        @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (cFechaPagoConfirmada.Value != null)
            {
                if (ckCompromisoPago.Checked == false)
                {
                    MessageBox.Show(
                        @"Confirme que existe un compromiso de Pago (Ha Completado Fecha de Pago!)",
                        @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (ckPagoCancelado.Checked)
            {
                if (string.IsNullOrEmpty(txtMensajeCancel.Text))
                {
                    MessageBox.Show(
                        @"Complete quien ha indicado que el pago esta cancelado y el motivo del cliente",
                        @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (ctFechaProximaLlamada.Value != null)
            {
                if ((Convert.ToInt32(txtDiasProximaLlamada.ValueD) < 0) ||
                    Convert.ToInt32(txtDiasProximaLlamada.ValueD) > 60)
                {
                    MessageBox.Show(
                        @"La fecha para la agendar una proxima llamada es Incorrecta",
                        @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (ckCuentaCorrienteConciliadaOk.Checked && ckCuentaCorrientePresentaDiferencias.Checked)
            {
                MessageBox.Show(
                    @"Los valores de los CheckBox de 'ACCIONES REALIZADAS' son inconsistentes",
                    @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (ckCuentaCorrienteConciliadaOk.Checked)
            {
                var x = MessageBox.Show(@"Confirma que conciliado la cuenta con el cliente y la misma se encuentra OK?",
                    @"Cuenta Conciliada OK", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return false;
            }

            if (ckCuentaCorrientePresentaDiferencias.Checked)
            {
                var x = MessageBox.Show(@"Confirma que la cuenta corriente presenta difrencias aun no resueltas?",
                    @"Cuenta con DIFERENCIAS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return false;
            }

            if (_motivoSeleccionado == false)
            {
                MessageBox.Show(
                    @"Debe Seleccionar un Motivo de Contacto",
                    @"Los datos no estan completos y no se puede continuar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarAccionOkToSave())
                return;

            IdRegistro = new Gesco().AgregarRegistro(_idCliente, cFechaContacto.Value.Value, txtPersonaContactada.Text,
                cmbMetodoContacto.SelectedItem.ToString(), _origenContacto, txtMensaje.Text, cFechaPagoConfirmada.Value,
                ckPagoCancelado.Checked, txtMensajeCancel.Text, ctFechaProximaLlamada.Value,
                ckCuentaCorrienteConciliadaOk.Checked, ckCuentaCorrientePresentaDiferencias.Checked, txtMensajeCobrador.Text, _motivoContacto, ckFechaPagoModificada.Checked, cNuevaFechaPago.Value);

            if (IdRegistro > 0)
            {
                MessageBox.Show(@"El Registro se ha guardado correctamente", @"Operacion Completada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }

            if (!string.IsNullOrEmpty(txtMensajeCobrador.Text))
                new Gesco().UpdateMensajeCobradorHeader(_idCliente, txtMensajeCobrador.Text);

            this.Close();
        }

        //-------------------------------------------------------------------------------------
        //Acciones segun el RB seleccionado
        //-------------------------------------------------------------------------------------
        private void rbOtro_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            txtMensajeCancel.Text = null; //borra mensaje cancel al cambiar el RB
            panelNextCall.Enabled = true;
            panelFechaPago.Enabled = false;
            panelCancelPago.Enabled = false;
            switch (rb.Name)
            {
                case "rbPago":
                    txtMensaje.Enabled = true;
                    txtMensaje.Text = @"Pago confirmado.-";
                    _motivoContacto = Gesco.MotivoContacto.ReclamoPago;
                    panelFechaPago.Enabled = true;
                    break;
                case "rbReconfirmaFecha":
                    txtMensaje.Enabled = true;
                    txtMensajeCancel.Enabled = true;
                    txtMensaje.Text = @"Se valida fecha de Pago";
                    _motivoContacto = Gesco.MotivoContacto.ReconfirmaFecha;
                    panelCancelPago.Enabled = true;
                    break;
                case "rbCancelaPago":
                    txtMensaje.Enabled = false;
                    txtMensajeCancel.Enabled = true;
                    txtMensajeCancel.ReadOnly = false;
                    txtMensaje.Text = @"Se modifica fecha de Pago";
                    txtMensajeCancel.Enabled = true;
                    _motivoContacto = Gesco.MotivoContacto.CancelaPago;
                    panelCancelPago.Enabled = true;

                    break;
                case "rbConciliaCta":
                    txtMensaje.Enabled = true;
                    txtMensaje.Text = @"";
                    _motivoContacto = Gesco.MotivoContacto.ConciliaCuenta;
                    if (ckClienteTienePagoListo.Checked)
                    {
                        panelCancelPago.Enabled = true;
                    }
                    else
                    {
                        panelFechaPago.Enabled = true;
                    }
                    break;
                case "rbCondicionPago":
                    txtMensaje.Enabled = true;
                    txtMensaje.Text = @"Se reclama condicion pago cobranza #";
                    _motivoContacto = Gesco.MotivoContacto.CondicionPago;
                    break;
                case "rbEnvioFactura":
                    txtMensaje.Enabled = true;
                    if (ckClienteTienePagoListo.Checked)
                    {
                        panelCancelPago.Enabled = true;
                    }
                    else
                    {
                        panelFechaPago.Enabled = true;
                    }
                    _motivoContacto = Gesco.MotivoContacto.ReclamaEnvioFactura;
                    break;
                case "rbOtro":
                    txtMensaje.Enabled = true;
                    _motivoContacto = Gesco.MotivoContacto.Otro;
                    if (ckClienteTienePagoListo.Checked)
                    {
                        panelCancelPago.Enabled = true;
                    }
                    else
                    {
                        panelFechaPago.Enabled = true;
                    }
                    break;
            }
            _motivoSeleccionado = true;
        }


        private void ActualizaFechaPago()
        {
            this.ckCompromisoPago.CheckedChanged -= new System.EventHandler(this.ckCompromisoPago_CheckedChanged);

            if (cFechaPagoConfirmada.Value == null)
            {
                return;
            }

            if (ckClienteTienePagoListo.Checked)
            {
                var resp = MessageBox.Show(
                    @"El Cliente ya tiene un pago confirmado. Si acepta la fecha se estará modificando la fecha de Pago. Desea Continuar?",
                    @"Modificacion de Fecha de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                {
                    ckCompromisoPago.Checked = false;
                    txtDiasPago.Text = @"0";
                    cFechaPagoConfirmada.Value = null;
                }
                else
                {
                    ckFechaPagoModificada.Checked = true;
                    ckCompromisoPago.Checked = true;
                    ckPagoCancelado.Checked = false;
                }
            }
            else
            {
                //El Cliente no tenia ningun pago listo - Se agrega nueva fecha de Pago
                ckCompromisoPago.Checked = true;
            }

            this.ckCompromisoPago.CheckedChanged += new System.EventHandler(this.ckCompromisoPago_CheckedChanged);
        }
        private void txtDiasPago_Validated(object sender, EventArgs e)
        {
            if (cFechaContacto.Value == null)
            {
                cFechaContacto.Value = DateTime.Today;
            }

            cFechaPagoConfirmada.Value = cFechaContacto.Value.Value.AddDays(Convert.ToInt32(txtDiasPago.ValueD));
            ActualizaFechaPago();
        }
        private void cFechaPagoConfirmada_Validated(object sender, EventArgs e)
        {
            if (cFechaContacto.Value == null)
            {
                cFechaContacto.Value = DateTime.Today;
            }

            if (cFechaPagoConfirmada.Value == null)
                return;

            DateTime oldDate = cFechaPagoConfirmada.Value.Value;
            DateTime newDate = cFechaContacto.Value.Value;
            TimeSpan ts = newDate - oldDate;
            int differenceInDays = ts.Days;
            txtDiasPago.Text = differenceInDays.ToString();
            ActualizaFechaPago();
        }
        private void txtPersonaContactada_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContactoPaP.Text))
            {
                txtPersonaContactada.Text = @"?";
            }
            else
            {
                txtPersonaContactada.Text = txtContactoPaP.Text;
            }
        }
        private void btnCancelarFechaPago_Click(object sender, EventArgs e)
        {
            this.ckCompromisoPago.CheckedChanged -= new System.EventHandler(this.ckCompromisoPago_CheckedChanged);
            if (ckClienteTienePagoListo.Checked)
            {
                txtMensajeCancel.ReadOnly = false;
                ckPagoCancelado.Checked = true;
                ckCompromisoPago.Checked = false;
                ckFechaPagoModificada.Checked = false;
                cNuevaFechaPago.Value = FechaAcordadaPagoOriginal;
                txtMensajeCancel.Text = @"Cliente Cancelo Pago";
            }
            else
            {
                //Este path no deberia ocurrir porque el boton tendria que estar deshabilitado
                MessageBox.Show(@"No se puede cancelar Pago porque el Cliente no tiene Pago Listo",
                    @"Accion No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMensajeCancel.Text = null;
                txtMensajeCancel.Enabled = false;
                ckPagoCancelado.Checked = false;
            }
            this.ckCompromisoPago.CheckedChanged += new System.EventHandler(this.ckCompromisoPago_CheckedChanged);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void cNuevaFechaPago_Validated(object sender, EventArgs e)
        {
            if (cNuevaFechaPago.Value != null)
            {
                if (cNuevaFechaPago.Value != FechaAcordadaPagoOriginal)
                {
                    MessageBox.Show(@"Se ha Modificado la Fecha de Pago. Notifique correctamente al Cobrador", @"Fecha de Pago Modificada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ckFechaPagoModificada.Checked = true;
                    ckPagoCancelado.Checked = false;
                    txtMensajeCancel.Text = null;
                }
            }
        }

        private void cmbEditDatosCliente_Click(object sender, EventArgs e)
        {

        }
    }
}
