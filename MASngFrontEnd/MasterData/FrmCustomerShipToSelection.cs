using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;

namespace MASngFE.MasterData
{
    public partial class FrmCustomerShipToSelection : Form
    {
        public FrmCustomerShipToSelection(int id6)
        {
            _id6 = id6;
            InitializeComponent();
        }

        private readonly int _id6;
        public int SelectedCustomer;

        private void FrmCustomerShipToSelection_Load(object sender, EventArgs e)
        {
            t0007CLIENTREGABindingSource.DataSource = new CustomerManager().GetShipToListFromBillTo(_id6);
            dgvShiptoList.DataSource = t0007CLIENTREGABindingSource;
            var dataCliente = new CustomerManager().GetCustomerBillToData(_id6);
            txtRazonSocial.Text = dataCliente.cli_rsocial;
            txtFantasia.Text = dataCliente.cli_fantasia;
        }

        private void dgvShiptoList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SelectedCustomer = Convert.ToInt32(dgvShiptoList[dgvShiptoList.Columns["iDCLIENTREGADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            txtSeleccion.Text = SelectedCustomer.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
