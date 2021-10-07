using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmDetalleEgresosREG : Form
    {
        public FrmDetalleEgresosREG(string periodo, string tipoLx)
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
            regBs.DataSource = new VendorConcil().GetListsaEgresosReg(_periodo, _tipoLx);
        }
    }
}
