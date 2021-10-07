using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Security;

namespace MASngFE.MasterData.Vendor
{
    //ROLE > VMSAVECONTACT (Permite grabar contact info VM)
    public partial class FrmMdv03VendorInfo : Form
    {
        public FrmMdv03VendorInfo(int idVendor)
        {
            _idVendor = idVendor;
            InitializeComponent();
        }

        private readonly int _idVendor;

        private void FrmMdv03VendorInfo_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = TsSecurityMng.CheckToEnableButton("VMSAVECONTACT");
            if (TsSecurityMng.CheckToEnableButton("VMSAVECONTACT"))
            {
                txtRazonSocial.Enabled = true;
                txtFantasia.Enabled = true;
                txtVendorId.Enabled = true;
                txtTelefono1.Enabled = true;
                txtTelefono2.Enabled = true;
                txtContacto.Enabled = true;
                txtEmailPedido.Enabled = true;
            }
            var data = new VendorManager().GetSpecificVendor(_idVendor);
            txtRazonSocial.Text = data.prov_rsocial;
            txtFantasia.Text = data.prov_fantasia;
            txtVendorId.Text = _idVendor.ToString();
            txtTelefono1.Text = data.Telefono;
            txtTelefono2.Text = data.Fax;
            txtContacto.Text = data.Contacto;
            txtEmailPedido.Text = data.EMAIL;
            txtVendorType.Text = data.TIPO;
            txtCuit.Text = data.NTAX1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            new VendorManager().SaveContactInfo(_idVendor, txtContacto.Text, txtTelefono1.Text,
                txtTelefono2.Text, txtEmailPedido.Text);
            MessageBox.Show(@"Se han Actualizado los datos de contacto", @"Info Actualizada", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
