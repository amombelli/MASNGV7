using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.MM;

namespace Tecser.Business.Transactional.PP
{
    public partial class FrmOrdenFabricacioAgregarItem : Form
    {

        public FrmOrdenFabricacioAgregarItem(int numeroOF)
        {
            _numeroOF = numeroOF;
            InitializeComponent();
        }
        private readonly int _numeroOF;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOrdenFabricacioAgregarItem_Load(object sender, EventArgs e)
        {
            var data = PlanProduccionListManager.GetOFData(_numeroOF);
            txtMaterialFabricar.Text = data.MATERIAL;
            txtNumeroFormula.Text = data.Formula.ToString();
            txtDescripcionFormula.Text = new BOMManager().GetFormulaHeader(data.Formula.Value).DESC_FORMULA;
            dgvStockDisponible.DataSource = ckSoloFusion.Checked == true
                ? new StockList().GetAllByMaterial(data.MATERIAL)
                : new StockList().GetAll();
        }

        private void ckSoloFusion_CheckedChanged(object sender, EventArgs e)
        {
            dgvStockDisponible.DataSource = ckSoloFusion.Checked == true
                ? new StockList().GetAllByMaterial(txtMaterialFabricar.Text)
                : new StockList().GetAll();
        }

        private void dgvStockDisponible_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvStockDisponible[e.ColumnIndex, e.RowIndex].Value.ToString();

                switch (cellValue)
                {
                    case "ADD":


                        //MessageBox.Show(@"Este boton se encuentra momentaneamente fuera de servicio",
                        //     "Boton no programado aun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
    }
}
