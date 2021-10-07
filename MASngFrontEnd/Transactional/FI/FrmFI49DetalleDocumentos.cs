using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.CtaCte;

namespace MASngFE.Transactional.FI
{
    public partial class FrmFI49DetalleDocumentos : Form
    {
        private readonly int _idCliente;

        public FrmFI49DetalleDocumentos(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFI49DetalleDocumentos_Load(object sender, EventArgs e)
        {
            var cust = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtIdCliente.Text = _idCliente.ToString();
            txtRazonSocial.Text = cust.cli_rsocial;
            txtFantasia.Text = cust.cli_fantasia;
            txtZtermL1.Text = cust.ZTERML1;
            txtZtermL2.Text = cust.ZTERML2;
            txtLimiteCredito.Text =
                cust.Limite_credito == null ? 0.ToString("C2") : cust.Limite_credito.Value.ToString("C2");
            var cta = new CtaCteCustomer(_idCliente);
            var r1 = cta.GetResultadoCtaCte("L1");
            var r2 = cta.GetResultadoCtaCte("L2");
            txtDeudaL1.Text = r1.SaldoDetalle.ToString("C2");
            txtDeudaL1.BackColor = r1.SaldoColor;
            txtDeudaL2.Text = r2.SaldoDetalle.ToString("C2");
            txtDeudaL2.BackColor = r2.SaldoColor;
            txtDeudaTotal.Text = (r1.SaldoDetalle + r2.SaldoDetalle).ToString("C2");
            this.ckL1.CheckedChanged -= new System.EventHandler(this.ckL1_CheckedChanged);
            this.ckL2.CheckedChanged -= new System.EventHandler(this.ckL1_CheckedChanged);
            this.ckSoloSaldoPendiente.CheckedChanged -= new System.EventHandler(this.ckL1_CheckedChanged);
            ckL1.Checked = true;
            ckL2.Checked = true;
            this.ckL1.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            this.ckL2.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            this.ckSoloSaldoPendiente.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            ckSoloSaldoPendiente.Checked = true;
            t0201CTACTEBindingSource.DataSource = new CtaCteCustomer(_idCliente).GetListaMovimientosCtaCte(true, true, true);
        }

        private void ckL1_CheckedChanged(object sender, EventArgs e)
        {
            t0201CTACTEBindingSource.DataSource = new CtaCteCustomer(_idCliente).GetListaMovimientosCtaCte(true, true, true);

        }
    }
}
