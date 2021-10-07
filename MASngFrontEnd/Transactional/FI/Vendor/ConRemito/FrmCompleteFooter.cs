using System;
using System.Windows.Forms;
using MASngFE.Transactional.FI.Vendor.ConRemito;

namespace MASngFE.Transactional.FI.ContabilizacioFactura.ConRemito
{
    public partial class FrmCompleteFooter : Form
    {
        public FrmCompleteFooter(FrmFI17VendorContaConRemito form)
        {
            _form = form;
            InitializeComponent();
        }

        private FrmFI17VendorContaConRemito _form;

        private void FrmCompleteFooter_Load(object sender, EventArgs e)
        {
            MapData();
        }

        private void MapData()
        {
            txtTotalBrutoInicial.Text = _form.HeaderData.BRUTO.ToString("C2");
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {

        }


    }
}
