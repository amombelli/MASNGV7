using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmDetalle203 : Form
    {
        public FrmDetalle203(string periodo, string tipoLx)
        {
            _periodo = periodo;
            _tipoLx = tipoLx;
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------
        private readonly string _periodo;
        private readonly string _tipoLx;
        //-------------------------------------------------------------------------------


        private void FrmDetalle203_Load(object sender, EventArgs e)
        {
            t203Bs.DataSource = new VendorConcil().GetListaFacturasIngresadasT203(_periodo, _tipoLx);
        }
    }
}
