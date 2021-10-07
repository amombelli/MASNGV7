using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmDetallesPagosPDOPx : Form
    {
        public FrmDetallesPagosPDOPx(string periodo, string tipoLx)
        {
            _periodo = periodo;
            _tipoLx = tipoLx;
            InitializeComponent();
        }


        //-----------------------------------------------------------------------------
        private readonly string _periodo;
        private readonly string _tipoLx;
        //-----------------------------------------------------------------------------

        private void FrmDetalleEgresosREG_Load(object sender, EventArgs e)
        {
            t203Bs.DataSource = new VendorConcil().GetListaPagosPD_OP(_periodo, _tipoLx);
        }

        private void FrmDetallesPagosPDOPx_Load(object sender, EventArgs e)
        {
            t203Bs.DataSource = new VendorConcil().GetListaPagosPD_OP(_periodo, _tipoLx);
        }
    }
}
