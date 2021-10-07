using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;

namespace MASngFE.Transactional.FI.Factura
{
    public partial class FrmSeleccionZTerm : Form
    {
        public FrmSeleccionZTerm(int modo, int idCliente, string lx)
        {
            _modo = modo;
            _idCliente = idCliente;
            _lx = lx;
            InitializeComponent();
        }

        private int _modo;
        private int _idCliente;
        private string _lx;
        public string zterm { get; private set; }
        public string ztermDescripcion { get; private set; }

        private void cmbZterm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmSeleccionZTerm_Load(object sender, EventArgs e)
        {
            txtClienteSeleccionado.Text = new CustomerManager().GetCustomerBillToData(_idCliente).cli_rsocial;
            txtLx.Text = _lx;
            t0019ZTERMBindingSource.DataSource = new ZtermManager().GetCompleteListOfZterms();
            btnUpdateMaestroClientes.Enabled = false;
            switch (_modo)
            {
                case 1:
                    btnUpdateMaestroClientes.Enabled = true;
                    break;
                case 2:
                    break;
                case 3:
                    break;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            zterm = cmbZterm.SelectedValue.ToString();
            ztermDescripcion = txtZtermDescripcion.Text;

            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void btnUpdateMaestroClientes_Click(object sender, EventArgs e)
        {
            new CustomerManager().UpdateZTermSegunLx(_idCliente, _lx, cmbZterm.SelectedValue.ToString());
            zterm = cmbZterm.SelectedValue.ToString();
            ztermDescripcion = txtZtermDescripcion.Text;


            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
