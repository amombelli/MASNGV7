using System;
using System.Windows.Forms;
using Tecser.Business.DataFix;
using Tecser.Business.Tools;

namespace MASngFE.FIX
{
    public partial class FrmFixFacturaL5 : Form
    {
        public FrmFixFacturaL5()
        {
            InitializeComponent();
        }

        private void txtIdRemitoInt_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtIdRemitoInt.Text) == false)
            {
                var data = new FixFacturaL5MAS().GetCustomerFromRemitoId(Convert.ToInt32(txtIdRemitoInt.Text));
                txtRazonSocial.Text = data.RazonSocial;

                if (data.LX == "L1")
                {
                    ckRemitoL1.Checked = true;
                    ckRemitoL2.Checked = false;
                }
                else if (data.LX == "L2")
                {
                    ckRemitoL1.Checked = false;
                    ckRemitoL2.Checked = true;
                }
                else
                {
                    ckRemitoL1.Checked = false;
                    ckRemitoL2.Checked = false;
                }
                ckRemitoL5.Checked = data.L5;
                txtRlink.Text = data.Rlink.ToString();
                txtTipoRlink.Text = data.LXRlink;

            }
        }

        private void txtIdRemitoInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void FrmFixFacturaL5_Load(object sender, EventArgs e)
        {

        }

        private void txtIdRemitoInt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (ckRemitoL1.Checked == true && string.IsNullOrEmpty(txtRlink.Text) == false && txtTipoRlink.Text == "L2")
            {
                var resultado = new FixFacturaL5MAS().FixDataL5(Convert.ToInt32(txtIdRemitoInt.Text));
                if (resultado)
                {
                    MessageBox.Show("Fix Completo", @"FIX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se actualizaron registros....", @"FIX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("El ID REMITO no permite el FIX. Debe ingresar ID remito L1 de un remito L5", @"FIX",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
