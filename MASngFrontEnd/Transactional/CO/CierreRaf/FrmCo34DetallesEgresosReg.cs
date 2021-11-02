using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCo34DetallesEgresosReg : Form
    {
        public FrmCo34DetallesEgresosReg(string periodo, string tipoLx)
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
            txtFechaDesde.Text = new PeriodoConversion().GetFechaPrimerDiaPeriodo(_periodo).ToString("d");
            txtFechaHasta.Text = new PeriodoConversion().GetFechaUltimoDiaPeriodo(_periodo).ToString("d");
            txtLx.Text = _tipoLx;
            var dataList = new VendorConcil().GetListsaEgresosReg(_periodo, _tipoLx);
            regBs.DataSource = dataList;
            txtMontoIn.Text = dataList.Sum(c => c.Monto_I.Value).ToString("C2");
            txtMontoOut.Text = dataList.Sum(c => c.Monto_E.Value).ToString("C2");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
