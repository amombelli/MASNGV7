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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void LineaIzq_Click(object sender, EventArgs e)
        {

        }

        private void lineaArriba_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtMoneda_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ctlImporte_Load(object sender, EventArgs e)
        {

        }

        private void txtGLItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ctlTasaConversion_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMonedaItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
