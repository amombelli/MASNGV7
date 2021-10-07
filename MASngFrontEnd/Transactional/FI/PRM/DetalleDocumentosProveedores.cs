using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;

namespace MASngFE.Transactional.FI.PRM
{
    public partial class DetalleDocumentosProveedores : Form
    {
        public DetalleDocumentosProveedores(int idVendor)
        {
            _idVendor = idVendor;
            InitializeComponent();
        }


        //-----------------------------------------------------------------------------------------------
        private readonly int? _idVendor;
        //-----------------------------------------------------------------------------------------------






















        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetalleDocumentosProveedores_Load(object sender, EventArgs e)
        {
            proveedoresBs.DataSource = new VendorManager().GetCompleteVendorList();
            if (_idVendor != null)
            {
                cmbRazonSocial.SelectedValue = _idVendor;
            }
        }
    }
}
