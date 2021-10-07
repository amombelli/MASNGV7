using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.VBTools;

namespace MASngFE.Transactional.FI.VendorNCD
{
    public partial class FrmFI80VendorNcdScreen1 : Form
    {
        public FrmFI80VendorNcdScreen1(int modo)
        {
            InitializeComponent();
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.TextChanged += new System.EventHandler(this.txtNumeroTax_TextChanged);
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.Leave += new System.EventHandler(this.txtNumeroTax_Leave);
            this.txtCodigoTax.TextChanged += new System.EventHandler(this.txtCodigoTax_TextChanged);
            this.txtCodigoTax.Leave += new System.EventHandler(this.txtCodigoTax_Leave);
            this.cmbTipoTax.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTax_SelectedIndexChanged);
            this.cmbIdProveedor.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
        }

        //-------------------------------------------------------------------------------------------
        private int? _idVendor = null;
        private string _tipoLx;
        private ManageDocumentType.TipoDocumento _tipoDocumento;
        private string _indicador;
        //-------------------------------------------------------------------------------------------

        #region Funcionalidad de Combos

        //1.-Definir Variable private int? IdVendor;
        //2.-Atencion cmbRazonSocial_TextUpdate asignado a 3 Combos

        ///**Funcionalidad validacion / CUIT
        private void txtNumeroTax_KeyUp(object sender, KeyEventArgs e)
        {
            //cuando es tipo 80 y 11 caracteres lo valida
            if (txtNumeroTax.Text.Length == 11 && txtCodigoTax.Text == @"80")
            {
                ValidaCuitCorrecto();
            }
        }

        private void txtNumeroTax_TextChanged(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }

        private void txtNumeroTax_Leave(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }

        private void txtCodigoTax_TextChanged(object sender, EventArgs e)
        {
            cmbTipoTax.Text = txtCodigoTax.Text == @"80" ? @"CUIT" : @"NI";
        }

        private void txtCodigoTax_Leave(object sender, EventArgs e)
        {
        }

        private void cmbTipoTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoTax.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                if (cmbTipoTax.Text == @"CUIT")
                {
                    txtCodigoTax.Text = @"80";
                    txtNumeroTax.BackColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    txtCodigoTax.Text = @"00";
                    txtNumeroTax.BackColor = Color.DarkGray;
                    txtNumeroTax.Text = @"00000000000";
                }
            }
        }

        private void cmbRazonSocial_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
            }
        }

        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                //BlanqueaSeleccion();
                _idVendor = null;
                return;
            }
            _idVendor = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            txtGLAp.Text = new GLAccountManagement().GetApVendorGl(_idVendor.Value);
            ValidaCuitCorrecto();

            var ctacte = new CtaCteVendor(_idVendor.Value);
            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;
            txtSaldoTotal.Text =
                (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text)).ToString("C2");
        }

        private void ValidaCuitCorrecto()
        {
            if (txtNumeroTax.Text.Length == 11 && txtNumeroTax.Text != @"00000000000")
            {
                if (new CuitValidation().ValidarCuit(txtNumeroTax.Text) == true)
                {
                    txtTaxValido.Text = @"VALIDO";
                    txtTaxValido.BackColor = Color.LightGreen;
                }
                else
                {
                    txtTaxValido.Text = @"INVALIDO";
                    txtTaxValido.BackColor = Color.Crimson;
                }
            }
            else
            {
                txtTaxValido.Text = @"SIN VALIDAR";
                txtTaxValido.BackColor = Color.Orange;
            }
            //  }
        }

        private void BlanqueaSeleccion()
        {
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTipoTax.SelectedIndex = -1;
            cmbIdProveedor.SelectedIndex = -1;
            txtNumeroTax.Text = null;
            txtCodigoTax.Text = null;
        }

        /// <summary>
        /// Blanqueo de seleccion - asigando a todos los Combobox!
        /// </summary>
        #endregion
        private void FrmVendorNCDMain_Load(object sender, EventArgs e)
        {
            InicializaForm();
        }

        private void InicializaForm()
        {
            t0005MPROVEEDORESBindingSource.DataSource = new VendorManager().GetCompleteListVendors();
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTipoTax.SelectedIndex = -1;
            txtSaldoL1.Text = 0.ToString("C2");
            txtSaldoTotal.Text = 0.ToString("C2");
            txtSaldoL2.Text = 0.ToString("C2");
            btnNuevoDocumento.Enabled = false;
            grpMotivoNotaCredito.Visible = false;
            grpMotivoNotaDebito.Visible = false;
            grpTipoDocumento.Visible = false;
            grpTipoLx.Focus();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool HabilitaBotonContinuar()
        {
            if (_idVendor != null)
            {
                return true;
            }
            return false;
        }

        #region seleccion de Checkbox

        //SELECCION TIPO [LX]
        private void rbTipoL1_CheckedChanged_1(object sender, EventArgs e)
        {
            _tipoLx = rbTipoL1.Checked ? "L1" : "L2";
            grpTipoDocumento.Visible = true;
        }

        //SELECCION DE TIPO DE DOCUMENTO
        private void rbNC_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = grpTipoDocumento.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);

            if (checkedButton == null)
            {
                btnNuevoDocumento.Enabled = false;
                return;
            }

            switch (checkedButton.Name)
            {
                case "rbNC":
                    grpMotivoNotaCredito.Visible = true;
                    grpMotivoNotaDebito.Visible = false;

                    var ckNc = grpMotivoNotaCredito.Controls.OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);

                    btnNuevoDocumento.Enabled = ckNc != null && HabilitaBotonContinuar();
                    _tipoDocumento = _tipoLx == "L1"
                        ? ManageDocumentType.TipoDocumento.NotaCreditoProveedorA
                        : ManageDocumentType.TipoDocumento.NotaCreditoProveedor2;

                    break;
                case "rbND":
                    grpMotivoNotaDebito.Visible = true;
                    grpMotivoNotaCredito.Visible = false;

                    var ckNd = grpMotivoNotaDebito.Controls.OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);

                    btnNuevoDocumento.Enabled = ckNd != null && HabilitaBotonContinuar();
                    _tipoDocumento = _tipoLx == "L1"
                        ? ManageDocumentType.TipoDocumento.NotaDebitoProveedorA
                        : ManageDocumentType.TipoDocumento.NotaDebitoProveedor2;

                    break;
                case "rbAI":
                    grpMotivoNotaDebito.Visible = false;
                    grpMotivoNotaCredito.Visible = false;

                    btnNuevoDocumento.Enabled = false;
                    //var ckAI = grpMotivoNotaDebito.Controls.OfType<RadioButton>()
                    //    .FirstOrDefault(r => r.Checked);

                    //btnNuevoDocumento.Enabled = ckAI != null && HabilitaBotonContinuar();

                    break;
                default:
                    break;
            }
        }

        //MOTIVOS DE NOTA DE DEBITO
        private void rbchr_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = grpMotivoNotaDebito.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            //var customer = new Customers();
            switch (checkedButton.Name)
            {
                case "rbchr":
                    _indicador = "CHR";
                    break;
                case "rbdifcambio":
                    _indicador = "NDDIFCAMBIO";
                    break;
                case "rbdifprecio":

                    break;
                case "rbkgfactu":
                    break;
                case "rbndotro":
                    break;

                default:
                    break;
            }

            var ckMnd = grpMotivoNotaDebito.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            btnNuevoDocumento.Enabled = ckMnd != null && HabilitaBotonContinuar();
        }

        //MOTIVOS DE NOTA DE CREDITO
        private void rbncotro_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = grpMotivoNotaCredito.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            //var customer = new Customers();
            if (checkedButton == null)
                return;

            switch (checkedButton.Name)
            {
                case "rbncanulafactu":
                    _indicador = "AFACTU";
                    break;
                case "rbncdifcambio":
                    _indicador = "DIFTCNC";
                    break;
                case "rbncdifprecio":
                    _indicador = "DIFPRNC";
                    break;
                case "rbncdifkg":
                    _indicador = "DEVKG";
                    break;
                case "rbncotro":
                    break;

                default:
                    break;
            }

            var ckMnc = grpMotivoNotaCredito.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            btnNuevoDocumento.Enabled = ckMnc != null && HabilitaBotonContinuar();
        }

        #endregion


        private void btnNuevoDocumento_Click(object sender, EventArgs e)
        {
            var f = new FrmFI81VendorNcdMain(_idVendor.Value, _tipoLx, _tipoDocumento, _indicador);
            f.Show();
        }


    }
}

