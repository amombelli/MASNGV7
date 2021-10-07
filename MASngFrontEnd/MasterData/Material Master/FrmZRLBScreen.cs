using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;

namespace MASngFE.MasterData.Material_Master
{
    public partial class FrmZRLBScreen : Form
    {
        public FrmZRLBScreen()
        {
            InitializeComponent();
        }
        public string zrlbprimario { get; private set; }
        public string descripcionL1 { get; private set; }
        public string descripcionL5 { get; private set; }

        private void FrmZRLBScreen_Load(object sender, EventArgs e)
        {
            t0010MATERIALESBindingSource.DataSource = new MaterialMasterManager().GetListMaterialsAvailableForZRLB();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcionL1.Text))
            {
                MessageBox.Show(@"Debe proveer la descripcion del material para el Remito/Factura", @"Descripcion SD",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcionL5.Text))
            {
                MessageBox.Show(@"Debe proveer la descripcion del material para el Remito/Factura (L1 para Venta L5)", @"Descripcion SD",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            descripcionL1 = txtDescripcionL1.Text;
            descripcionL5 = txtDescripcionL5.Text;
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMateriaPrimaOrigen.SelectedValue != null)
                zrlbprimario = cmbMateriaPrimaOrigen.SelectedValue.ToString();
        }
        private void txtDescripcionL1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcionL1.Text) == false)
                txtDescripcionL5.Text = @"Disp." + txtDescripcionL1.Text;
        }
    }
}
