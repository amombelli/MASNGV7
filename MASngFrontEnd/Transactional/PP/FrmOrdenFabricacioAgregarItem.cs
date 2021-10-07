using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Transactional.PP
{
    public partial class FrmOrdenFabricacioAgregarItem : Form
    {
        public FrmOrdenFabricacioAgregarItem()
        {
            InitializeComponent();
        }

        public FrmOrdenFabricacioAgregarItem(int numeroOF)
        {
            _numeroOF = numeroOF;
            InitializeComponent();
        }

        private readonly int _numeroOF;

        private void btnSalir_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0219 // The variable 'dr' is assigned but its value is never used
            var dr = DialogResult.Cancel;
#pragma warning restore CS0219 // The variable 'dr' is assigned but its value is never used
            this.Close();

        }

        private void FrmOrdenFabricacioAgregarItem_Load(object sender, EventArgs e)
        {
            var data = PlanProduccionListManager.GetOFData(_numeroOF);
            txtMaterialFabricar.Text = data.MATERIAL;
            txtNumeroFormula.Text = data.Formula.ToString();
            txtDescripcionFormula.Text = new BOMManager().GetFormulaHeader(data.Formula.Value).DESC_FORMULA;

            if (ckSoloFusion.Checked)
            {
                dgvStockDisponible.DataSource = new StockList().GetAllByMaterial(data.MATERIAL);
            }
            else
            {
                dgvStockDisponible.DataSource = new StockList().GetAll();
            }
        }

        private void ckSoloFusion_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloFusion.Checked == true)
            {
                dgvStockDisponible.DataSource = new StockList().GetAllByMaterial(txtMaterialFabricar.Text);
                cmbListaMateriales.Enabled = false;
            }
            else
            {
                dgvStockDisponible.DataSource = new StockList().GetAll();
                cmbListaMateriales.Enabled = true;
                cmbListaMateriales.DataSource = new MaterialMasterManager().GetCompleteListofMaterial();
            }
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
                        var kgStock = Convert.ToDecimal(dgvStockDisponible[3, e.RowIndex].Value);
                        var kgnecesarios = Convert.ToDecimal(dgvStockDisponible[5, e.RowIndex].Value);

                        if (kgnecesarios > kgStock)
                        {
                            MessageBox.Show(@"ATENCION: Los KG a Tomar Exceden la cantidad de KG disponibles", @"Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                        var dialogResult = MessageBox.Show(
                            @"Confirma el agregado del material para REPROCESO/FUSION?", @"Material Reproceso",
                            MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            var idAdded = new OrdenFabricacionBOMManager().AddItemFusionFormula(_numeroOF,
                                Convert.ToInt32(dgvStockDisponible[0, e.RowIndex].Value));
                            if (idAdded > 0)
                            {
                                //Se pudo agregar correctamente el material fusionado a la formulaine
                                var stockLineSelected =
                                    StockManager.GetStockLine(Convert.ToInt32(dgvStockDisponible[0, e.RowIndex].Value));

                                //Hace la reserva de stock
                                new StockBatchManagerOF().ReservaLoteOrdenFabricacionIndividual(
                                    stockLineSelected.IDStock, _numeroOF, idAdded, stockLineSelected.Stock);
                                //todo reservar el material en el stock.
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show(@"Se ha Cancelado el agregado de un material para fusion de stock", @"Alta de Material Fusion de Stock",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private void cmbListaMateriales_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvStockDisponible.DataSource =
                new StockList().GetAllByMaterial(cmbListaMateriales.SelectedValue.ToString());
        }
    }
}
