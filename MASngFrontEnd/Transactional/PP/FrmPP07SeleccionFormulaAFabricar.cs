using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP07SeleccionFormulaAFabricar : Form
    {
        public FrmPP07SeleccionFormulaAFabricar(string material, int numeroOF)
        {
            InitializeComponent();
            txtMaterial.Text = material;
            _material = material;
            txtNumeroOF.Text = numeroOF.ToString();
            FormulaSeleccionada = 0;
        }

        //-------------------------------------------------------------------------------
        private readonly string _material;
        private BOMManager _bomData = new BOMManager();
        public int FormulaSeleccionada { get; private set; }
        //-------------------------------------------------------------------------------

        private void FrmPlanProduccionSeleccionFormula_Load(object sender, EventArgs e)
        {
            ckSoloFormulasActivas.Checked = true;
            this.dgvDetalleItems.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormula_CellValueChanged);
            BoMHeaderBs.DataSource = _bomData.GetListFormulasFromMaterial(_material, ckSoloFormulasActivas.Checked);
            dgvFormulas.ClearSelection();
        }

        private void dgvFormulas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            FormulaSeleccionada = Convert.ToInt32(dgvFormulas[0, e.RowIndex].Value);
            if (FormulaSeleccionada == 0)
            {
                BoMItemsBs.DataSource = null;
                return;
            }
            else
            {
                BoMItemsBs.DataSource = _bomData.GetFormulaItems(FormulaSeleccionada);
            }
            this.dgvDetalleItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormula_CellValueChanged);
        }

        private void dgvFormulas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridView dgv = (DataGridView)sender;

            FormulaSeleccionada = Convert.ToInt32(dgv[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            BoMItemsBs.DataSource = _bomData.GetFormulaItems(FormulaSeleccionada);
            CalculaTotalFormula();
        }

        private void dgvFormula_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculaTotalFormula();
        }

        private void CalculaTotalFormula()
        {
            var i = 0;
            decimal amount = 0;
            decimal porcen = 0;

            for (i = 0; i <= dgvDetalleItems.Rows.Count - 1; i++)
            {
                amount += Convert.ToDecimal(dgvDetalleItems.Rows[i].Cells[2].Value);
                porcen += Convert.ToDecimal(dgvDetalleItems.Rows[i].Cells[3].Value);
            }
            txtTotalCantidad.Text = amount.ToString("N2");
            txtTotalCantidadPorc.Text = porcen.ToString("P2");
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnSelectFormula1_Click(object sender, EventArgs e)
        {
            if (FormulaSeleccionada <= 0)
            {
                MessageBox.Show(@"Debe Seleccionar una Formula o Cancelar el Proceso de Seleccion",
                    @"Seleccion de Formula", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ckSoloFormulasActivas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloFormulasActivas.Checked)
            {
                btnSelectFormula1.Enabled = true;
                ckSoloFormulasActivas.BackColor = Color.LightGreen;
            }
            else
            {
                ckSoloFormulasActivas.BackColor = Color.LightPink;
                btnSelectFormula1.Enabled = false;
            }
            BoMHeaderBs.DataSource = _bomData.GetListFormulasFromMaterial(_material, ckSoloFormulasActivas.Checked);
            dgvFormulas.ClearSelection();
            dgvDetalleItems.ClearSelection();
            FormulaSeleccionada = 0;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
