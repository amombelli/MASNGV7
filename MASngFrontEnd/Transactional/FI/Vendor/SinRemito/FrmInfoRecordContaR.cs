using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;

namespace MASngFE.Transactional.FI.ContabilizacioFactura.SinRemito
{
    public partial class FrmInfoRecordContaR : Form
    {
        public FrmInfoRecordContaR(int idProveedor)
        {
            _idProveedor = idProveedor;
            InitializeComponent();
        }

        private readonly int _idProveedor;
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmInfoRecordContaR_Load(object sender, EventArgs e)
        {
            dgvItems.DataSource = new VendorManager().GetListItemsProveedor(_idProveedor);
        }


    }
}

