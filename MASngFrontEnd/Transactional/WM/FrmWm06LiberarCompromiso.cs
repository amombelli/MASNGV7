using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.SD;
using Tecser.Business.Transactional.WM;

namespace MASngFE.Transactional.WM
{
    public partial class FrmWm06LiberarCompromiso : Form
    {
        public FrmWm06LiberarCompromiso()
        {
            InitializeComponent();
        }

        private void FrmWm06LiberarCompromiso_Load(object sender, EventArgs e)
        {
            stockBs.DataSource = new CompromisoManager().CompletaEstructuraCompromiso();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStockList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvStockList[e.ColumnIndex, e.RowIndex].Value.ToString();
                var idStockSeleccionado = Convert.ToInt32(dgvStockList[0, e.RowIndex].Value);
                var stk = StockManager.GetStockLine(idStockSeleccionado);
                if (stk.Estado != StockStatusManager.EstadoLote.Comprometido.ToString())
                {
                    MessageBox.Show(@"El Estado del Stock no permite liberacion por este metodo",
                        @"Accion no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                switch (cellValue)
                {
                    case "Free":
                        var itemOV =
                            new SalesOrderDataManager().GetDataItemFromDb(stk.OV_Reserva.Value, stk.ReservaItem.Value);
                        if (itemOV == null)
                        {
                            MessageBox.Show(@"Ha Ocurrido un error que no permite la liberacion del material",
                                @"Orden de Venta Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (itemOV.materialPrimario == stk.Material)
                        {
                            new MmLog().LogMMChangeEstado(idStockSeleccionado, stk.Stock, stk.Estado,
                                StockStatusManager.EstadoLote.Liberado.ToString(), "WM01");
                            new CompromisoManager().FreeStockComprometidoByIdstock(idStockSeleccionado, true);
                            MessageBox.Show(@"Material has been successfully free! ", @"Liberacion de Material",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(
                                @"Existe diferencias entre el material a liberar y el material de la OV por lo que la operacion no puede ser realizada de esta manera",
                                @"Liberacion de Material NO Realizada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }
    }
}
