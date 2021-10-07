using System;
using System.Windows.Forms;
using MASngFE.MasterData.Vendor;
using Tecser.Business.MasterData;

namespace MASngFE.MasterData
{
    public partial class FrmVendorSearch : Form
    {

        private readonly VendorManager _vendor = new VendorManager();
        private readonly int _modo;

        public FrmVendorSearch()
        {
            InitializeComponent();
            _modo = 0;
        }

        public FrmVendorSearch(int modo)
        {
            InitializeComponent();
            _modo = modo;
        }

        private void RefreshDataSource()
        {
            cmbRazonSocial.DataSource = _vendor.GetCompleteListVendors(ckActiveOnly.Checked);
            cmbFantasia.DataSource = _vendor.GetCompleteListVendors(ckActiveOnly.Checked);
            cmbCuit.DataSource = _vendor.GetCompleteListVendors(ckActiveOnly.Checked);
            cmbIdVendor.DataSource = _vendor.GetCompleteListVendors(ckActiveOnly.Checked);

            cmbRazonSocial.Text = "";
            cmbFantasia.Text = "";
            cmbCuit.Text = "";
            cmbIdVendor.Text = "";


        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var f2 = new FrmMdv02VendorABMDetail(1)
            {
            };
            f2.Show();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            var f2 = new FrmMdv02VendorABMDetail(3, (int)cmbIdVendor.SelectedValue);
            {
            };
            f2.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerValoresPadronAFIP_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"En Construccion");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbIdVendor.Text) != true)
            {
                var f2 = new FrmMdv02VendorABMDetail(2, (int)cmbIdVendor.SelectedValue);
                {
                }
                ;
                f2.Show();
            }
            else
            {
                MessageBox.Show("Complete el Proveedor que desea Modificar", @"Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

        }

        #region AlCambiarCombobox
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex > 0)
            {
                cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
                cmbCuit.SelectedValue = cmbRazonSocial.SelectedValue;
                cmbIdVendor.SelectedValue = cmbRazonSocial.SelectedValue;
            }
        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFantasia.SelectedIndex > 0)
            {
                cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
                cmbCuit.SelectedValue = cmbFantasia.SelectedValue;
                cmbIdVendor.SelectedValue = cmbFantasia.SelectedValue;
            }
        }
        private void cmbCuit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFantasia.SelectedIndex > 0)
            {
                cmbRazonSocial.SelectedValue = cmbCuit.SelectedValue;
                cmbFantasia.SelectedValue = cmbCuit.SelectedValue;
                cmbIdVendor.SelectedValue = cmbCuit.SelectedValue;
            }
        }
        private void cmbID6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdVendor.SelectedIndex > 0)
            {
                cmbRazonSocial.SelectedValue = cmbIdVendor.SelectedValue;
                cmbFantasia.SelectedValue = cmbIdVendor.SelectedValue;
                cmbCuit.SelectedValue = cmbIdVendor.SelectedValue;
            }
        }
        #endregion

        private void ckActiveOnly_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataSource();
        }

        private void FrmVendorSearch_Load(object sender, EventArgs e)
        {
            switch (_modo)
            {
                case 1:
                    btnEdit.Enabled = false;
                    btnNuevo.Enabled = true;
                    btnVisualizar.Enabled = false;
                    break;
                case 2:
                    btnEdit.Enabled = true;
                    btnNuevo.Enabled = false;
                    btnVisualizar.Enabled = false;
                    break;
                case 3:
                    btnEdit.Enabled = false;
                    btnNuevo.Enabled = false;
                    btnVisualizar.Enabled = true;
                    break;
                default:
                    //Modo prueba default = 0 
                    btnEdit.Enabled = true;
                    btnNuevo.Enabled = true;
                    btnVisualizar.Enabled = true;
                    break;
            }
            ckActiveOnly.Checked = true;
            cmbRazonSocial.ValueMember = "id_prov";
            cmbRazonSocial.DisplayMember = "PROV_RSOCIAL";

            cmbFantasia.ValueMember = "id_prov";
            cmbFantasia.DisplayMember = "PROV_FANTASIA";

            cmbCuit.ValueMember = "id_prov";
            cmbCuit.DisplayMember = "NTAX1";

            cmbIdVendor.ValueMember = "id_prov";
            cmbIdVendor.DisplayMember = "ID_PROV";

            RefreshDataSource();
        }
    }
}
