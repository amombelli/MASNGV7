using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;



//ESTE FORM HAY QUE REEMPLAZARLO POR FrmPP11SelectBatch O una Herencia del mismo

namespace MASngFE.Transactional.PP
{
    public partial class FrmSeleccionBatch : Form
    {

        private readonly string _modo;
        private readonly int _numeroOF;
        private readonly int _iditem;
        public string LoteSeleccioando;
        public int IdStockSeleccionado;

        public FrmSeleccionBatch(string material, decimal kgNecesarios, int numeroOF, int iditem, string modo)
        {
            InitializeComponent();
            txtMaterial.Text = material;
            txtKgRequeridos.Text = kgNecesarios.ToString("n2");
            _modo = modo;
            _numeroOF = numeroOF;
            _iditem = iditem;
        }


        private void dgvStockDisponible_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvStockDisponible[e.ColumnIndex, e.RowIndex].Value.ToString();

                switch (cellValue)
                {
                    case "SELECT":
                        //al presionar el boton SELECT 

                        if ((decimal)(dgvStockDisponible[3, e.RowIndex].Value) <
                            Convert.ToDecimal(txtKgRequeridos.Text))
                        {
                            MessageBox.Show(@"Para reservar un lote - El mismo tiene que alcanzar completamente.-",
                                @"Reserva de Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        IdStockSeleccionado = (int)dgvStockDisponible[0, e.RowIndex].Value;
                        LoteSeleccioando =
                            dgvStockDisponible[batchDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();

                        new StockBatchManagerOF().ReservaLoteOrdenFabricacionIndividual(IdStockSeleccionado, _numeroOF, _iditem, Convert.ToDecimal(txtKgRequeridos.Text));
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                        return;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private void FrmSeleccionBatch_Load(object sender, EventArgs e)
        {
            switch (_modo)
            {
                case "OF":
                    ckSoloDisponible.Checked = true;
                    {
                        var lst = new StockList().GetAllByMaterial_DisponibleProduccion(txtMaterial.Text)
                            .Where(c => c.Stock >= Convert.ToDecimal(txtKgRequeridos.Text)).ToList();
                        dgvStockDisponible.DataSource = lst;
                    }
                    break;

                case "ES":
                    ckSoloDisponible.Checked = true;
                    {
                        var lst = new StockList().GetAllByMaterial_DisponibleProduccion(txtMaterial.Text)
                            .Where(c => c.Stock >= Convert.ToDecimal(txtKgRequeridos.Text)).ToList();
                        dgvStockDisponible.DataSource = lst;
                        //txtkgUtilizar.Text = txtKgRequeridos.Text;
                        //txtkgUtilizar.ReadOnly = false;
                        //txtkgUtilizar.ForeColor = Color.Crimson;
                    }

                    break;
                default:
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtkgUtilizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
    }
}
