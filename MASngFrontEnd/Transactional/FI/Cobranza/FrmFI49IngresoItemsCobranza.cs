using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Customers;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmFI49IngresoItemsCobranza : Form
    {
        public FrmFI49IngresoItemsCobranza(FrmIngresoCobranza f)
        {
            _formCobranza = f;
            InitializeComponent();
        }

        private FrmIngresoCobranza _formCobranza;
        public T0206_COBRANZA_I Item { get; private set; }
        private bool _cuitValidado = false;
        private bool _fechaValidada = false;
        private DateTime? _fechaCheque = null;

        private void ConfiguraInicial()
        {
            t0150CUENTASBindingSource.DataSource = new CuentasManager().GetListCuentasAvailableCobranza();
            t0160BANCOSBindingSource.DataSource = new BankManager().GetBankList(true);
            cmbCuenta.SelectedValue = "CHE";
            ConfiguraSegunCuentaSeleccionada("CHE");
            ckConexionAfipPadron.Checked = false;
        }
        private void ResetDatos()
        {
            txtImporteEfectivo.Text = 0.ToString("C2");
            txtImporteCheque.Text = 0.ToString("C2");
            txtImporteRetencion.Text = 0.ToString("C2");
            txtImporteTransferencia.Text = 0.ToString("C2");
            txtDiasAcerditacion.Text = 0.ToString();
            mtxtCuitCheque.Text = null;
            txtNumeroCheque.Text = null;
            mskFechaAcreditacion.Text = null;
            ckChequeInterior.Checked = false;
            txtDiasAcerditacion.Text = @"0";
            txtImporteGenearlValidacion.Text = 0.ToString("C2");
            txtRetAlicuota.Text = 0.ToString("P2");
            txtRetProvincia.Text = null;
            txtNumeroBono.Text = null;
            txtImporteBono.Text = 0.ToString("C2");
            cmbBancoNumero.SelectedIndex = -1;
            txtBancoDescripcionLong.Text = null;
            txtBancoDescripcionShort.Text = null;
            ckIsEcheque.Checked = false;
        }
        private void ConfiguraSegunModo()
        {

        }
        private void FromInterfazSeleccionCuenta_Load(object sender, EventArgs e)
        {
            ConfiguraInicial();
            ConfiguraSegunModo();
        }
        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuenta.SelectedValue != null)
            {
                ConfiguraSegunCuentaSeleccionada(cmbCuenta.SelectedValue.ToString());
            }
        }
        private void ConfiguraSegunCuentaSeleccionada(string cuentaSeleccionada)
        {
            if (cmbCuenta.SelectedValue == null) return;

            panelCheque.Visible = false;
            panelEfectivo.Visible = false;
            panelRetencion.Visible = false;
            panelTransferencia.Visible = false;
            panelBono.Visible = false;
            //
            panelBono.SendToBack();
            panelCheque.SendToBack();
            panelEfectivo.SendToBack();
            panelRetencion.SendToBack();
            panelTransferencia.SendToBack();

            switch (cuentaSeleccionada)
            {
                case "ARS":
                    panelEfectivo.Visible = true;
                    txtImporteEfectivo.Focus();
                    break;

                case "USD":
                    panelEfectivo.Visible = true;
                    panelEfectivo.BringToFront();
                    txtImporteEfectivo.Focus();
                    break;

                case "CHE":
                    panelCheque.Visible = true;
                    panelCheque.BringToFront();
                    txtNumeroCheque.Focus();
                    cmbBancoNumero.SelectedIndex = -1;
                    break;

                case "GAL":
                    panelTransferencia.Visible = true;
                    txtImporteTransferencia.Focus();
                    break;

                case "SAN":
                    panelTransferencia.Visible = true;
                    txtImporteTransferencia.Focus();
                    break;

                case "ICBC":
                    panelTransferencia.Visible = true;
                    txtImporteTransferencia.Focus();
                    break;

                case "RIB":
                    panelRetencion.Visible = true;
                    txtImporteRetencion.Focus();
                    txtRetProvincia.Enabled = true;
                    break;

                case "RGA":
                    panelRetencion.Visible = true;
                    panelRetencion.BringToFront();
                    panelRetencion.Visible = true;
                    txtImporteRetencion.Focus();
                    txtRetProvincia.Text = null;
                    txtRetProvincia.Enabled = false;
                    break;

                case "BAF":
                    panelBono.Visible = true;
                    panelBono.BringToFront();
                    txtNumeroBono.Focus();
                    break;

                case "COM":
                    panelRetencion.Visible = true;
                    panelCheque.SendToBack();
                    panelEfectivo.SendToBack();
                    panelRetencion.SendToBack();
                    panelTransferencia.SendToBack();
                    panelRetencion.BringToFront();
                    panelRetencion.Visible = true;
                    txtImporteRetencion.Focus();
                    break;

                default:
                    MessageBox.Show(@"ATENCION: Cuenta no manejada notifique a IT", @"Error en configuracion",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
            }
        }

        private void txtNumeroCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void mtxtCuitCheque_Leave(object sender, EventArgs e)
        {

        }
        private void cmbBancoNumero_Validated(object sender, EventArgs e)
        {
            if (cmbBancoNumero.SelectedIndex == -1)
            {
                MessageBox.Show(@"El Valor seleccionado no pertenece a una opcion valida de Banco", @"Error en la Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBancoDescripcionLong.Text = null;
                txtBancoDescripcionShort.Text = null;
                return;
            }
        }
        private void mtxtCuitCheque_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            var x = new CuitValidation().ValidarCuit(mtxtCuitCheque.Text);
        }
        private void mtxtCuitCheque_Validated(object sender, EventArgs e)
        {
            if (new CuitValidation().ValidarCuit(mtxtCuitCheque.Text))
            {
                mtxtCuitCheque.BackColor = Color.LimeGreen;

                txtDescripcionCuit.Text = new CuitChequeManager().GetDescripcionCuit(mtxtCuitCheque.Text,
                    ckConexionAfipPadron.Checked);
                _cuitValidado = true;

                if (ckValidacionCheques.Checked)
                {
                    var data = new ChequesManager().GetChequeStats(mtxtCuitCheque.Text);
                    txtChPendientesAcred.Text = data.PendientesAcreditar.ToString();
                    txtChRecibidos.Text = data.TotalRecibidos.ToString();
                    txtChRechazados.Text = data.TotalRechazados.ToString();
                }
            }
            else
            {
                // MessageBox.Show(@"El numero de CUIT ingresado es incorrecto", @"CUIT INCORRECTO", MessageBoxButtons.OK,
                //     MessageBoxIcon.Asterisk);
                mtxtCuitCheque.BackColor = Color.OrangeRed;
                _cuitValidado = false;
            }

        }
        private bool ValidaDatosCompletos()
        {
            //Validacion de Datos antes de ACEPTAR
            if (cmbCuenta.SelectedValue == null)
            {
                MessageBox.Show(@"Debe seleccionar una CUENTA valida (Item de Cobranza)", @"Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            //Validacion General-Importe
            if (string.IsNullOrEmpty(txtImporteGenearlValidacion.Text))
            {
                MessageBox.Show(@"El importe debe ser mayor a $0.00", @"Error en Importe", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            decimal importe = FormatAndConversions.CCurrencyADecimal(txtImporteGenearlValidacion.Text);
            if (importe <= 0)
            {
                MessageBox.Show(@"El importe debe ser mayor a $0.00", @"Error en Importe", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            Item = new T0206_COBRANZA_I
            {
                CUENTA = cmbCuenta.SelectedValue.ToString(),
                ITEM_IMPUTADO = false,
                ITEM_TEMP = true,
                MON_ITEM = txtMoneda.Text,
                LINE = _formCobranza.ListOfItemsCobranza.Count + 1,
                IMP_ITEM = importe,
            };

            if (txtMoneda.Text == @"ARS")
            {
                Item.IMP_RECIBO = importe;
            }
            else
            {
                MessageBox.Show(
                    @"Por el momento seleccione una cuenta en ARS y coloque el importe al que ha sido tomado el monto en USD",
                    @"Funcionalidad Limitada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            //Validacion especifica por tipo de CUENTA
            switch (cmbCuenta.SelectedValue.ToString())
            {
                case "CHE":
                    //Validacion general para cheques

                    if (cmbBancoNumero.SelectedValue == null)
                    {
                        MessageBox.Show(@"Debe proveer el codigo de Banco", @"Validacion de Datos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (string.IsNullOrEmpty(mtxtCuitCheque.Text))
                    {
                        MessageBox.Show(@"Debe proveer el CUIT de algun firmante del cheque", @"Validacion de Datos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (_cuitValidado == false)
                    {
                        var msg =
                            MessageBox.Show(
                                @"Atencion el CUIT no se encuentra validado. Desea Continuar de todas formas?",
                                @"CUIT INVALIDO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msg == DialogResult.No)
                            return false;
                    }

                    if (ValidaChequeFecha() == false)
                        return false;

                    if (string.IsNullOrEmpty(txtNumeroCheque.Text))
                    {
                        MessageBox.Show(@"Debe Completar el numero de Cheque", @"Datos Incompletos", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;

                    }
                    //
                    Item.CHEQUE_BANCO = cmbBancoNumero.SelectedValue.ToString();
                    Item.CHEQUE_FECHA = _fechaCheque;
                    Item.CHEQUE_CUIT = mtxtCuitCheque.Text;
                    Item.CHEQUE_INTERIOR = ckChequeInterior.Checked.ToString();
                    Item.Che_Interior = ckChequeInterior.Checked;
                    Item.CHEQUE_NUMERO = txtNumeroCheque.Text;
                    Item.CHEQUE_TITULAR = txtDescripcionCuit.Text;
                    Item.IDCH = 0;
                    Item.Che_Electronico = ckIsEcheque.Checked;
                    return true;
                //

                case "RGA":
                    //Validacion general para retencion de ganancias
                    if (string.IsNullOrEmpty(txtRetAlicuota.Text))
                    {
                        MessageBox.Show(@"Debe proveer la Alicuota Aplicada en la Retencion [%]", @"Faltan Dataos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    Item.COMENTARIO = $"Alic {txtRetAlicuota.Text}";
                    break;

                case "RIB":
                    //Validacion general para retencion de IIBB
                    if (string.IsNullOrEmpty(txtRetAlicuota.Text))
                    {
                        MessageBox.Show(@"Debe proveer la Alicuota Aplicada en la Retencion [%]", @"Faltan Dataos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    if (string.IsNullOrEmpty(txtRetProvincia.Text))
                    {
                        MessageBox.Show(@"Debe completar la PROVINCIA que figura en la Retencion de IIBB", @"Faltan Dataos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    Item.COMENTARIO = $"Alic {txtRetAlicuota.Text} - Prov {txtRetProvincia.Text}";
                    break;

                case "BAF":
                    //Validacion general para bonos de AFIP
                    if (string.IsNullOrEmpty(txtNumeroBono.Text))
                    {
                        MessageBox.Show(@"Debe proveer el numero de BONO", @"Faltan Dataos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    Item.CHEQUE_NUMERO = txtNumeroBono.Text;
                    break;
                default:

                    break;
            }
            Item.COMENTARIO = $"Alic {txtRetAlicuota.Text} - Prov {txtRetProvincia.Text}";
            return true;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletos() == false)
                return;

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
        private void btnAddItemPago_Click(object sender, EventArgs e)
        {

            if (ValidaDatosCompletos() == false)
                return;

            if (_fechaValidada == false && cmbCuenta.Text == @"CHE")
            {
                MessageBox.Show(@"Revise la FECHA del Cheque antes de Continuar!", @"Fecha Inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _formCobranza.ListOfItemsCobranza.Add(Item);
            _formCobranza.UpdateListWithCalculosImportes();
            _formCobranza.CompletaFormateaDataGridView();

            ResetDatos();
            if (cmbCuenta.SelectedValue.ToString() == "CHE")
                txtNumeroCheque.Focus();
        }
        private void cmbCuenta_Validating(object sender, CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null && combo.Text != string.Empty)
                e.Cancel = true;
        }
        private void mskFechaAcreditacion_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskFechaAcreditacion.BackColor = Color.OrangeRed;
            _fechaCheque = null;
            _fechaValidada = false;

            toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
            toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA", mskFechaAcreditacion,
                mskFechaAcreditacion.Location, 5000);

        }
        private void mskFechaAcreditacion_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParseExact(mskFechaAcreditacion.Text,
                "d/M/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                //valid date
                mskFechaAcreditacion.BackColor = Color.GreenYellow;
                _fechaValidada = true;
                _fechaCheque = dt;
            }
            else
            {
                //invalid date
                toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
                toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA", mskFechaAcreditacion,
                    mskFechaAcreditacion.Location, 5000);

                mskFechaAcreditacion.BackColor = Color.OrangeRed;
                _fechaValidada = false;
                _fechaCheque = null;
            }

            if (ValidaChequeFecha() == true)
            {
                mskFechaAcreditacion.BackColor = Color.GreenYellow;
                _fechaValidada = true;
            }
            else
            {
                mskFechaAcreditacion.BackColor = Color.OrangeRed;
                _fechaValidada = false;
                txtDiasAcerditacion.Text = null;
            }

            if (_fechaValidada == false)
            {
                toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
                toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA",
                    mskFechaAcreditacion,
                    mskFechaAcreditacion.Location, 5000);
            }
        }

        private bool ValidaChequeFecha()
        {
            if (_fechaValidada == false)
            {
                MessageBox.Show(@"Debe completar la Fecha del Cheque", @"Error en Fechade Acreditacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (_fechaCheque > DateTime.Today.AddDays(365))
            {
                MessageBox.Show(@"La fecha de acreditacion excede 1 año", @"Error en fecha de Acerditacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _fechaValidada = false;
                return false;
            }
            if (_fechaCheque < DateTime.Today.AddDays(-30))
            {
                MessageBox.Show(@"El Cheque se encuentra Vencido", @"Error en fecha de Acerditacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _fechaValidada = false;
                return false;
            }
            _fechaValidada = true;
            TimeSpan ts = _fechaCheque.Value - DateTime.Today;
            txtDiasAcerditacion.Text = ts.Days.ToString();
            return true;
        }

        private void mskFechaAcreditacion_Leave(object sender, EventArgs e)
        {

        }

        private void txtNumeroCheque_TextChanged(object sender, EventArgs e)
        {

        }

        //** --  Formatos y Validaciones de Tipeo -- **

        //validaciones KeyPress Todos los Importes
        private void txtImporteRetencion_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        //validaciones Leave Todos los Importes
        private void txtImporteBono_Leave(object sender, EventArgs e)
        {
            var txtname = (TextBox)sender;
            if (string.IsNullOrEmpty(txtname.Text))
            {
                txtname.Text = 0.ToString("C2");
            }
            else
            {
                var importeDecimal = FormatAndConversions.CCurrencyADecimal(txtname.Text);
                txtname.Text = importeDecimal.ToString("C2");
            }
            txtImporteGenearlValidacion.Text = txtname.Text;
        }
        private void cmbBancoNumero_Validating(object sender, CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null && combo.Text != string.Empty)
                e.Cancel = true;
        }

        private void txtRetAlicuota_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtRetAlicuota_Enter(object sender, EventArgs e)
        {
            //
        }

        private void txtRetAlicuota_Leave(object sender, EventArgs e)
        {
            var txtname = (TextBox)sender;
            if (string.IsNullOrEmpty(txtname.Text))
            {
                txtname.Text = 0.ToString("P2");
            }
            else
            {
                var importeDecimal = FormatAndConversions.CPorcentajeADecimal(txtname.Text);
                txtname.Text = importeDecimal.ToString("P2");
            }
        }
        private void cmbBancoNumero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
