using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI.GESCO;
using Tecser.Business.VBTools;

namespace MASngFE.Transactional.FI.GESCO
{
    public partial class FrmGestionCreditosClientesMain : Form
    {
        public FrmGestionCreditosClientesMain(int modo, int id6)
        {
            _id6 = id6;
            _modo = modo;
            InitializeComponent();
        }

        //--------------------------------------------------------------------
        private readonly int _id6;
        private readonly int _modo;
        //--------------------------------------------------------------------

        private void FrmGestionCreditosClientesMain_Load(object sender, EventArgs e)
        {
            ZTermL1.DataSource = new ZtermManager().GetCompleteListOfZterms();
            ZtermL2.DataSource = new ZtermManager().GetCompleteListOfZterms();
            cmbZtermL1.SelectedValue = -1;
            cmbZtermL2.SelectedValue = -1;
            LoadCustomerMDHeader();
        }

        private void LoadCustomerMDHeader()
        {
            var climd = new CustomerManager().GetCustomerBillToData(_id6);
            txtId6.Text = _id6.ToString();
            txtRazonSocial.Text = climd.cli_rsocial;
            txtFantasia.Text = climd.cli_fantasia;
            txtNumeroTax.Text = climd.CUIT;
            txtEstado.Text = climd.ACTIVO ? "ACTIVO" : "INACTIVO";

            if (new CuitValidation().ValidarCuit(climd.CUIT))
            {
                cmbTipoTax.SelectedItem = "CUIT";
                txtTaxValido.Text = @"VALIDADO";
                txtCodigoTax.Text = @"80";
            }
            else
            {
                cmbTipoTax.SelectedItem = "NI";
                txtTaxValido.Text = @"SIN VALIDAR";
                txtCodigoTax.Text = @"00";
            }

            if (climd.AllowL1 == null)
                climd.AllowL1 = false;

            if (climd.AllowL2 == null)
                climd.AllowL2 = false;

            if (climd.AllowL5 == null)
                climd.AllowL5 = false;



            ckBloqueoEntrega.Checked = climd.BLK_DELIVERY;
            ckBloqueoPedido.Checked = climd.BLK_PEDIDO;

            ckL1.Checked = climd.AllowL1.Value;
            ckL2.Checked = climd.AllowL2.Value;
            ckL5.Checked = climd.AllowL5.Value;

            cmbZtermL1.SelectedValue = climd.ZTERML1;
            cmbZtermL2.SelectedValue = climd.ZTERML2;

            txtLimiteCreditoMaximo.Text = climd.Limite_credito.Value.ToString("C2");

            if (climd.Descuento == null)
                climd.Descuento = 0;
            txtDescuentoPorcentaje.Text = climd.Descuento.Value.ToString("P2");
            txtMotivoDescuento.Text = climd.MotivoDescuento;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cmbZtermL1.SelectedValue == null)
            {
                cmbZtermL1.SelectedValue = "0E";
            }

            if (cmbZtermL2.SelectedValue == null)
            {
                cmbZtermL2.SelectedValue = "0E";
            }

            var resp = new CreditAndRiskControl().UpdateCreditControlCcl(_id6, ckBloqueoPedido.Checked,
                ckBloqueoEntrega.Checked, ckL1.Checked, ckL2.Checked, ckL5.Checked, cmbZtermL1.SelectedValue.ToString(),
                cmbZtermL2.SelectedValue.ToString(),
                Convert.ToInt32(FormatAndConversions.CCurrencyADecimal(txtLimiteCreditoMaximo.Text)),
                Convert.ToDouble(FormatAndConversions.CPorcentajeADecimal(txtDescuentoPorcentaje.Text)),
                txtMotivoDescuento.Text);

            if (resp > 0)
            {
                MessageBox.Show(@"Se han modificado los datos del Cliente", @"Modificacion Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"NO SE han modificado los datos del Cliente", @"Modificacion Inexistente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }
    }
}
