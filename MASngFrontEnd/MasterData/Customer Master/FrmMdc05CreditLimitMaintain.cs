using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;

namespace MASngFE.MasterData.Customer_Master
{
    public partial class FrmMdc05CreditLimitMaintain : Form
    {
        private readonly int _idCliente;

        public FrmMdc05CreditLimitMaintain(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }

        private void FrmMdc05CreditLimitMaintain_Load(object sender, EventArgs e)
        {
            var cust = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtIdCliente.Text = _idCliente.ToString();
            txtRazonSocial.Text = cust.cli_rsocial;
            txtFantasia.Text = cust.cli_fantasia;
            txtZtermL1.Text = cust.ZTERML1;
            txtZtermL2.Text = cust.ZTERML2;
            uLimiteCredito.Init(0, 10000000, true, false, true);
            if (cust.Limite_credito == null)
            {
                uLimiteCredito.Text = null;
            }
            else
            {
                uLimiteCredito.ValueD = (decimal)cust.Limite_credito.Value;
            }
        }

        private void cmbEditDatosCliente_Click(object sender, EventArgs e)
        {
            if (ckAutoCredit.Checked)
            {
                if (ctlDaysCreditLimit.GetValueDecimal == 0)
                {
                    MessageBox.Show(@"Debe Asignar un valor de dias de credito", @"Informacion Inconsistente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                if (ctlDaysCreditLimit.GetValueDecimal == 0)
                {
                    MessageBox.Show(
                        @"Las condiciones de limite de credito estan establecidads en Pago Contraentrega ya que el Limite de Credito es CERO",
                        @"Limite de Credito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            new CustomerManager().UdpdateCreditLimite(_idCliente, uLimiteCredito.ValueD, ckAutoCredit.Checked, (int)ctlDaysCreditLimit.GetValueDecimal);
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void ckAutoCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAutoCredit.Checked)
            {
                if (uLimiteCredito.ValueD > 0)
                {
                    MessageBox.Show(
                        @"Existe un valor de Limite de Credito Asignado. Si quiere utilizar el valor AUTO debe colocar el valor asignado en $0.00 o de lo contrario se utilizara siempre el valor que resuelte menor de los dos",
                        @"Limite de Credito Asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void uLimiteCredito_Validated(object sender, EventArgs e)
        {
            if (uLimiteCredito.ValueD > 0 && ckAutoCredit.Checked)
            {
                MessageBox.Show(
                    @"Existe un valor de Limite de Credito Asignado. Si quiere utilizar el valor AUTO debe colocar el valor asignado en $0.00 o de lo contrario se utilizara siempre el valor que resuelte menor de los dos",
                    @"Limite de Credito Asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
