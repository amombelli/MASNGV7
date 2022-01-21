using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
//#prueba x de aero to dell 
//#prueba dell to aero
    public partial class FrmFI35AddCashToOP : Form
    {
        public FrmFI35AddCashToOP(string razonSocial,string cuentaId, string monedaOP)
        {
            InitializeComponent();
            txtProveedor.Text = razonSocial;
            txtMoneda.Text = monedaOP;
            var p = new CuentasManager().GetSpecificCuentaInfo(cuentaId);
            txtGLItem.Text = p.GLMAP;
            txtMonedaItem.Text = p.CUENTA_MONEDA;
        }
        public decimal Importe { get; private set; }
        private void FrmFI35AddCashToOP_Load(object sender, EventArgs e)
        {
            if (txtMonedaItem.Text == txtMoneda.Text)
            {
                ctlTasaConversion.SetValue = 1;
                ctlTasaConversion.XReadOnly = true;
            }
        }
        private void btnAddItemPago_Click(object sender, EventArgs e)
        {
            if (ctlImporte.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"No se puede agreagar el valor definido a la Orden de Pago", @"Importe Incorrecto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Importe = ctlImporte.GetValueDecimal;
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
