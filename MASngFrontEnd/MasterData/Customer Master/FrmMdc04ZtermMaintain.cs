using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;

namespace MASngFE.MasterData.Customer_Master
{
    public partial class FrmMdc04ZtermMaintain : Form
    {
        private readonly int _idCliente;

        public FrmMdc04ZtermMaintain(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }

        private void cmbEditDatosCliente_Click(object sender, EventArgs e)
        {
            if (cmbZtermL1.SelectedValue == null)
            {
                MessageBox.Show(@"Debe proveer una condicion de Pago L1 para grabar los datos", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbZtermL2.SelectedValue == null)
            {
                MessageBox.Show(@"Debe proveer una condicion de Pago L2 para grabar los datos", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new CustomerManager().UpdateZterm(_idCliente, cmbZtermL1.SelectedValue.ToString(),
                cmbZtermL2.SelectedValue.ToString());
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

        private void FrmMdc04ZtermMaintain_Load(object sender, EventArgs e)
        {
            zTermL1Bs.DataSource = new ZtermManager().GetCompleteListOfZterms();
            zTermL2Bs.DataSource = new ZtermManager().GetCompleteListOfZterms();
            var cust = new CustomerManager().GetCustomerBillToData(_idCliente);
            cmbZtermL1.SelectedValue = cust.ZTERML1;
            cmbZtermL2.SelectedValue = cust.ZTERML2;
            txtIdCliente.Text = _idCliente.ToString();
            txtRazonSocial.Text = cust.cli_rsocial;
            txtFantasia.Text = cust.cli_fantasia;
        }

        private void cmbZtermL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbZtermL1.SelectedValue != null)
                txtZtermL1.Text = cmbZtermL1.SelectedValue.ToString();

        }

        private void cmbZtermL2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbZtermL2.SelectedValue != null)
                txtZtermL2.Text = cmbZtermL2.SelectedValue.ToString();
        }
    }
}
