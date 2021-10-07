using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO;

namespace MASngFE.Transactional.FI
{
    public partial class FrmFI60ExchangeRage : Form
    {
        public FrmFI60ExchangeRage()
        {
            InitializeComponent();
        }

        private void FrmFI60ExchangeRage_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            xRateBs.DataSource = new ExchangeRateManager().GetXrateList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ctlXRateFactura.GetValueDecimal <= 0 || ctlXRateCobranza.GetValueDecimal <= 0 ||
                ctlXRateCobranza.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Debe Establecer todos los Tipos de Cambio", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new ExchangeRateManager().SetValues(dtpFecha.Value, ctlXRateFactura.GetValueDecimal, ctlXRateFactura2.GetValueDecimal, ctlXRateCobranza.GetValueDecimal);
            xRateBs.DataSource = new ExchangeRateManager().GetXrateList();
        }

        private void ctlXRateFactura_Validated(object sender, EventArgs e)
        {
            if (ctlXRateFactura.GetValueDecimal > 0)
            {
                ctlXRateCobranza.SetValue = ctlXRateFactura.GetValueDecimal;
                ctlXRateFactura2.SetValue = ctlXRateFactura.GetValueDecimal * (decimal)1.105;
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (new ExchangeRateManager().CheckDateExist(dtpFecha.Value))
            {
                MessageBox.Show(@"Atención: Ya Existe informacion para esta fecha", @"Datos Existentes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
