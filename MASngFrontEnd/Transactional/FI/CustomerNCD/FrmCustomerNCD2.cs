using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmCustomerNcd2 : Form
    {
        public FrmCustomerNcd2(int modo = 0)
        {
            InitializeComponent();
        }

        private int? _idCliente;

        private void FrmCustomerNCDMain_Load(object sender, EventArgs e)
        {
            InicializaForm();
        }
        private void InicializaForm()
        {
            t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            txtCuit.Text = null;
            txtSaldoL1.Text = 0.ToString("C2");
            txtSaldoTotal.Text = 0.ToString("C2");
            txtSaldoL2.Text = 0.ToString("C2");

            t0300NCDHBindingSource.DataSource = new NcdTableManager().GetCompleteNCDList().ToList();


        }

        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                txtIdCliente.Text = null;
                txtSaldoL1.Text = 0.ToString("C2");
                txtSaldoL2.Text = 0.ToString("C2");
                txtSaldoTotal.Text = 0.ToString("C2");
                txtSaldoL1.BackColor = Color.Wheat;
                txtSaldoL2.BackColor = Color.Wheat;
                txtSaldoTotal.BackColor = Color.Wheat;
                _idCliente = null;
                return;
            }

            _idCliente = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            txtIdCliente.Text = cmbRazonSocial.SelectedValue.ToString();
            var saldo = new CtaCteCustomer(Convert.ToInt32(cmbRazonSocial.SelectedValue));
            var resultadoL1 = saldo.GetResultadoCtaCte("L1");
            txtSaldoL1.Text = resultadoL1.SaldoDetalle.ToString("C2");
            txtSaldoL1.BackColor = resultadoL1.SaldoColor;

            var resultadoL2 = saldo.GetResultadoCtaCte("L2");
            txtSaldoL2.Text = resultadoL2.SaldoDetalle.ToString("C2");
            txtSaldoL2.BackColor = resultadoL2.SaldoColor;

            var resultadoTotal = (resultadoL1.SaldoDetalle + resultadoL2.SaldoDetalle);
            txtSaldoTotal.Text = resultadoTotal.ToString("C2");
            if (resultadoTotal > 0)
            {
                txtSaldoTotal.BackColor = Color.ForestGreen;
            }
            else
            {
                txtSaldoTotal.BackColor = Color.DarkOrange;
            }

        }
        private void cmbRazonSocial_Leave(object sender, EventArgs e)
        {
            var control = (ComboBox)sender;
            if (string.IsNullOrEmpty(control.Text))
            {
                cmbRazonSocial.SelectedIndex = -1;
            }
        }


        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvNCD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var cellValue = dgvOPLista[0, e.RowIndex];
            //LoadOpData(Convert.ToInt32(cellValue.Value));

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvNCD[e.ColumnIndex, e.RowIndex].Value.ToString();
                switch (cellValue)
                {
                    case "VER":
                        {
                            var idNCD = Convert.ToInt32(dgvNCD[0, e.RowIndex].Value);
                            var idFactura = new NcdTableManager().GetIdFacturaFromNcd(idNCD);
                            if (idFactura == 0)
                            {
                                MessageBox.Show(@"No se puede mostrar la informacion porque no existe en T0400",
                                    @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            var f2 = new FrmFi52NotaCreditoDebitoCliente(idNCD);
                            f2.Show();

                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }

        }

        private void btnVerChrPendientes_Click(object sender, EventArgs e)
        {
            var f = new FrmListadoChequesRechzados();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }

}
