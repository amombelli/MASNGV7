using System;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.WM;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.WM
{
    public partial class FrmWM07LiberarReservaRE : Form
    {
        private readonly Guid? _miGuid;

        public FrmWM07LiberarReservaRE(string miGuid)
        {
            if (string.IsNullOrEmpty(miGuid))
            {
                _miGuid = null;
            }
            else
            {
                _miGuid = Guid.Parse(miGuid);
            }

            InitializeComponent();
        }

        private void FrmWM07LiberarReservaRE_Load(object sender, EventArgs e)
        {
            stockBs.DataSource = new CqStockDataManagement().CompletaEstructuraReservaRe(GlobalApp.CnnApp);
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
                if (stk.Estado != StockStatusManager.EstadoLote.ReservaRE.ToString())
                {
                    MessageBox.Show(@"El Estado del Stock no permite liberacion por este metodo",
                        @"Accion no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (stk.ReservaGUID == _miGuid)
                {
                    MessageBox.Show(
                        @"No se puede liberar esta linea porque pertenece a la preparacion de pedido en curso",
                        @"Accion no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (stk.ReservaGUID == null)
                {
                    if (stk.ReservaID != null)
                    {
                        if (stk.ReservaItem != null)
                        {
                            MessageBox.Show(
                                @"No se puede liberar esta linea porque pertenece a un Remito en preparacion",
                                @"Accion no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }

                switch (cellValue)
                {
                    case "Free":
                        var r = MessageBox.Show(@"Confirma la Liberacion de esta linea de stock?",
                            @"Confirmacion de Liberacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.No)
                            return;
                        var x = new CompromisoManager().FreeReservaRE(idStockSeleccionado);
                        if (!x)
                        {
                            MessageBox.Show(@"Ha Ocurrido un error que NO permite la liberacion del material",
                                @"Error en la Liberacion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(@"Se ha Liberado el Stock Correctamente",
                                @"Liberacion de ReservaRE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            stockBs.DataSource = new CqStockDataManagement().CompletaEstructuraReservaRe(GlobalApp.CnnApp);
                        }
                        break;
                }
            }
        }
    }
}
