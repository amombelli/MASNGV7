using System;
using System.Windows.Forms;
using MASngFE.Transactional.CRM;
using Tecser.Business.MasterData;

namespace MASngFE.Transactional.FI
{
    public partial class FrmTest1 : Form
    {
        public FrmTest1()
        {
            InitializeComponent();
        }

        private int _idClienteSeleccionado;

        private void FrmTest1_Load(object sender, EventArgs e)
        {
            //txtRazonSocial.Text = new CustomerManager().GetCustomerBillToData(6).cli_rsocial;
            T6BS.DataSource = new CustomerManager().GetCustomerBillToData(10);
            MessageBox.Show(@"Prueba OK");
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            T6BS.DataSource = new CustomerManager().GetCustomersByFantasyName(txtRazonSocial.Text);
        }

        private void dgvDatosCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _idClienteSeleccionado = Convert.ToInt32(dgvDatosCliente[0, e.RowIndex].Value);
            T6BS.DataSource = new CustomerManager().GetCustomerBillToData(_idClienteSeleccionado);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaAccion_Click(object sender, EventArgs e)
        {

            if (_idClienteSeleccionado > 0)
            {
                var f2 = new FrmNuevaAccion(_idClienteSeleccionado);
                f2.Show();
            }
        }
    }
}
