using System;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;

namespace MASngFE.MasterData.BOM
{
    public partial class FrmBOMMaterialSelector : Form
    {
        public FrmBOMMaterialSelector(int modo, string material = null, decimal cantidad = 0)
        {
            _modo = modo;
            Material = material;
            Cantidad = cantidad;
            InitializeComponent();
        }

        private readonly int _modo;
        public string Material { get; private set; }
        public decimal Cantidad { get; private set; }
        private void FrmBOMMaterialSelector_Load(object sender, EventArgs e)
        {
            t0010MATERIALESBindingSource.DataSource =
                new MaterialTypeManager().GetListMaterialAvailableAsBOMComponenet();
            cmbMaterial.Text = Material;
            ConfiguraSegunModo();
        }
        private void ConfiguraSegunModo()
        {
            switch (_modo)
            {
                case 1:
                    cmbMaterial.Enabled = true;
                    break;

                case 2:
                    cmbMaterial.Enabled = true;
                    break;

                case 3:
                    cmbMaterial.Enabled = false;
                    btnAceptar.Enabled = false;
                    break;
            }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show(@"Para confirmar un mateiral debe seleccionar un material", @"Confirmacion de Material",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Material = cmbMaterial.Text;
            Cantidad = string.IsNullOrEmpty(txtCantidad.Text) ? 0 : Convert.ToDecimal(txtCantidad.Text);

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
