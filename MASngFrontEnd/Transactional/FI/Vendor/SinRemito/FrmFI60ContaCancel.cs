using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;

namespace MASngFE.Transactional.FI.Vendor.SinRemito
{
    public partial class FrmFI60ContaCancel : Form
    {
        public FrmFI60ContaCancel()
        {
            InitializeComponent();
        }

        private void FrmFI60ContaCancel_Load(object sender, EventArgs e)
        {
            txtid403.ReadOnly = false;
            txtid403.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!ValidarOk())
                return;

            var x = new CancelVendorConta();
            if (x.PermiteCancelar(Convert.ToInt32(txtid403.Text)))
            {
                x.CancelDocumento(Convert.ToInt32(txtid403.Text));
            }
        }

        public bool ValidarOk()
        {
            return true;
        }
    }
}
