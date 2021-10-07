using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.CtaCte;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmCRM06GescoCtaCteEstiloCliente : Form
    {
        private int _idCliente;
        private string _lx;

        public FrmCRM06GescoCtaCteEstiloCliente()
        {
            _idCliente = 0;
            InitializeComponent();
        }
        public FrmCRM06GescoCtaCteEstiloCliente(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            var x = new CtaCteEstiloCliente().GetInfo(_idCliente, dtpFechaDesde.Value, _lx);
            ctaCteCliSaldoAcumuladoStxBindingSource.DataSource = x.ToList();
        }
        private void FrmCRM06GescoCtaCteEstiloCliente_Load(object sender, EventArgs e)
        {
            tCustomerBs.DataSource = new CustomerManager().GetCompleteListofBillTo(true);

            if (_idCliente == 0)
            {
                tCustomerBs.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
                cmbCliente.SelectedIndex = -1;
            }
            else
            {
                cmbCliente.SelectedValue = _idCliente;
            }
        }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1)
                return;

            _idCliente = (int)cmbCliente.SelectedValue;
            var cust = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtCondicionPagoL1.Text = cust.ZTERML1;
            txtCondicionPagoL2.Text = cust.ZTERML2;
            var ctacte = new CtaCteCustomer(_idCliente);

            var saldoL1 = ctacte.GetResultadoCtaCte("L1").SaldoDetalle;
            var saldoL2 = ctacte.GetResultadoCtaCte("L2").SaldoDetalle;

            txtSaldoL1.Text = saldoL1.ToString("C2");
            txtSaldoL2.Text = saldoL2.ToString("C2");
            txtSaldoTotal.Text = (saldoL1 + saldoL2).ToString("C2");

            var limiteCredito = 0;
            if (cust.Limite_credito != null) limiteCredito = cust.Limite_credito.Value;
            txtLimiteCredito.Text = limiteCredito.ToString("C2");
            txtLimiteCredito.BackColor = limiteCredito < saldoL1 + saldoL2 ? Color.LightCoral : Color.LightGreen;

        }
        private void txtDias_Validated(object sender, EventArgs e)
        {
            if (txtDias.GetValueDecimal < 0)
                txtDias.SetValue = txtDias.GetValueDecimal * -1;

            dtpFechaDesde.Value = DateTime.Today.AddDays((double)txtDias.GetValueDecimal * -1);

        }
        private void dtpFechaDesde_Validated(object sender, EventArgs e)
        {

        }
        private void ckL1_CheckedChanged(object sender, EventArgs e)
        {
            var i = 0;
            if (ckL1.Checked)
            {
                i = 1;
            }

            if (ckL2.Checked)
            {
                i += 2;
            }
            _lx = "L" + i;
        }
    }
}
