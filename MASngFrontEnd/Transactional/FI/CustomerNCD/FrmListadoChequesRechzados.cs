using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmListadoChequesRechzados : Form
    {
        public FrmListadoChequesRechzados()
        {
            InitializeComponent();
        }

        private int? _idCliente;

        private void FrmListadoChequesRechzados_Load(object sender, EventArgs e)
        {
            t0156CHEQUERECHBindingSource.DataSource = new ChequeRechazadoManager().ListaChequeRechazadosSinNd();
            dgvListaChequesRechazados.DataSource = t0156CHEQUERECHBindingSource;
            t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            ckSinNotaDebitoRealizada.Checked = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckSinNotaDebitoRealizada_CheckedChanged(object sender, EventArgs e)
        {
            FiltroDgv();
        }

        private void FiltroDgv()
        {
            if (_idCliente == null)
            {
                if (ckSinNotaDebitoRealizada.Checked)
                {
                    t0156CHEQUERECHBindingSource.DataSource =
                        new ChequeRechazadoManager().ListaChequeRechazadosSinNd().ToList();
                }
                else
                {
                    t0156CHEQUERECHBindingSource.DataSource =
                        new ChequeRechazadoManager().ListaChequeRechazados().ToList();
                }
            }
            else
            {
                if (ckSinNotaDebitoRealizada.Checked)
                {
                    t0156CHEQUERECHBindingSource.DataSource =
                        new ChequeRechazadoManager().ListaChequeRechazadosSinNd(_idCliente).ToList();
                }
                else
                {
                    t0156CHEQUERECHBindingSource.DataSource =
                        new ChequeRechazadoManager().ListaChequeRechazados(_idCliente).ToList();
                }
            }
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                txtIdCliente.Text = null;
                FiltroDgv();
                return;
            }

            _idCliente = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            txtIdCliente.Text = cmbRazonSocial.SelectedValue.ToString();
            FiltroDgv();
        }

        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFantasia_Leave(object sender, EventArgs e)
        {
            var control = (ComboBox)sender;
            if (string.IsNullOrEmpty(control.Text))
            {
                cmbRazonSocial.SelectedIndex = -1;
            }
        }
    }
}
