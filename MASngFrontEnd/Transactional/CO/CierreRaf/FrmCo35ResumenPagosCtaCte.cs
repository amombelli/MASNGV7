using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCo35ResumenPagosCtaCte : Form
    {
        public FrmCo35ResumenPagosCtaCte(string periodo, string tipoLx)
        {
            _periodo = periodo;
            _tipoLx = tipoLx;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------
        private readonly string _periodo;
        private readonly string _tipoLx;
        //-----------------------------------------------------------------------------

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCo35ResumenPagosCtaCte_Load(object sender, EventArgs e)
        {
            txtFechaDesde.Text = new PeriodoConversion().GetFechaPrimerDiaPeriodo(_periodo).ToString("d");
            txtFechaHasta.Text = new PeriodoConversion().GetFechaUltimoDiaPeriodo(_periodo).ToString("d");
            txtLx.Text = _tipoLx;
            var listaData = new VendorConcil(_periodo,_tipoLx).GetListaPagosPD_OP(_periodo, _tipoLx);
            t203Bs.DataSource = listaData;
            txtMontoOut.Text = Math.Abs(listaData.Sum(c => c.IMPORTE_ARS)).ToString("C2");
            txtSaldoImpago.Text = Math.Abs(listaData.Sum(c => c.SALDOFACTURA)).ToString("C2");
        }

    }
}
