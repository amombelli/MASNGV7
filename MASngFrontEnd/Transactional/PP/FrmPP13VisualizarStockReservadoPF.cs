using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP13VisualizarStockReservadoPF : Form
    {
        public FrmPP13VisualizarStockReservadoPF(int numeroOF)
        {
            _numeroOF = numeroOF;
            InitializeComponent();
        }

        private int _numeroOF;

        private void btnLiberarOrden_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show(@"Desea Liberar todo el stock Reservado para esta OF?",
                @"Liberar Stock Reservado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            new ReservaStockOF().LiberaStockReservadoOF(_numeroOF, true);
            dgvStockReservado.DataSource = new StockList().GetAllReserveOF(_numeroOF); //Refresca DGV

        }

        private void FrmPP13VisualizarStockReservadoPF_Load(object sender, EventArgs e)
        {
            dgvStockReservado.DataSource = new StockList().GetAllReserveOF(_numeroOF);
        }
    }

}
