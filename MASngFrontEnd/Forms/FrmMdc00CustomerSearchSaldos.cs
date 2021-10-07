using System;
using MASngFE.Forms.CustomerSearchBase;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI.CtaCte;

namespace MASngFE.Forms
{
    public partial class FrmMdc00CustomerSearchSaldos : FrmMdc00CustomerSearchBase
    {
        public FrmMdc00CustomerSearchSaldos()
        {
            InitializeComponent();
        }

        private void FrmCustomerSearchSaldos_Load(object sender, EventArgs e)
        {

        }

        private void cmbRazonSocial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Id6 != null)
            {
                var ctacte = new CtaCteCustomer(base.Id6.Value);
                txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
                txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
                txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
                txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;
                txtSaldoTotal.Text =
                    (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) +
                     FormatAndConversions.CCurrencyADecimal(txtSaldoL2.Text)).ToString("C2");
            }
        }
    }
}
