using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.VBTools;

namespace MASngFE.Transactional
{
    public partial class FrmDetalleDeudaProveedeor : Form
    {
        public FrmDetalleDeudaProveedeor(int idVendor)
        {
            _idVendor = idVendor;
            InitializeComponent();
        }

        private int? _idVendor;

        //-------------------------    Funcionalidad de Combos ------------------------------------
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
            txtSaldoTotal.Text = (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) + FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text)).ToString("C2");
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


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDetalleDeudaProveedeor_Load(object sender, EventArgs e)
        {
            ckSoloDocumentosConSaldo.Checked = true;
            proveedoresBs.DataSource = new VendorManager().GetCompleteVendorList();
            if (_idVendor != null)
            {
                cmbRazonSocial.SelectedValue = _idVendor;
                PopulaDatosDgv();
            }
        }

        private void ckSoloDocumentosConSaldo_CheckedChanged(object sender, EventArgs e)
        {
            PopulaDatosDgv();
        }

        private void PopulaDatosDgv()
        {
            t0203CTACTEPROVBindingSource.DataSource =
                new CtaCteVendorDetalleDocumentos().DetalleFacturasPendientePago(_idVendor.Value,
                    soloConSaldo: ckSoloDocumentosConSaldo.Checked);
        }

        private void dgvListadoDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
