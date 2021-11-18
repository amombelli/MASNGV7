using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.PP;
using Tecser.Business.Transactional.PP.BOM;
using TecserEF.Entity.DataStructure.BOM;

namespace MASngFE.MasterData.BOM
{
    public partial class FrmMDB06MassFormActivate : Form
    {
        public FrmMDB06MassFormActivate()
        {
            InitializeComponent();
        }

        private List<EstructuraMPenFormula> _data = new List<EstructuraMPenFormula>();
        private string _material;






        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {

                txtCantActivas.Text = @"0";
                txtCantInactivas.Text = @"0";
                return;
            }

            _material = cmbMaterial.SelectedValue.ToString();
            var matData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = matData.MAT_DESC;
            txtOrigen.Text = matData.ORIGEN;
            txtMtype.Text = matData.TIPO_MATERIAL;
            _data = new BOMUtilities().GetBOMContieneMateriaPrima(_material, false).OrderByDescending(c => c.UltimoUso).ToList();
            dataBs.DataSource = _data;
            txtCantActivas.Text = _data.Count(c => c.FormulaActiva).ToString();
            txtCantInactivas.Text = _data.Count(c => c.FormulaActiva == false).ToString();
        }

        private void FrmMDB06MassFormActivate_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = new MaterialMasterManager().GetCompleteListMaterialAvailable();
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;
            rbUltimoUso.Checked = true;
        }

        private void CmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbMaterial);
        }

        private void CmbMaterial_Leave(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtDescripcion.Text = null;
                txtCantActivas.Text = 0.ToString();
                txtCantInactivas.Text = 0.ToString();
                txtMtype.Text = null;
                txtOrigen.Text = null;
                dataBs.DataSource = null;
            }
        }

        private void DgvListaFormulas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)dgvListaFormulas.Rows[dgvListaFormulas.CurrentRow.Index].Cells[0];

                if (ch1.Value == null)
                    ch1.Value = false;
                switch (ch1.Value.ToString())
                {
                    case "True":
                        ch1.Value = false;
                        ch1.Style.BackColor = Color.Red;
                        break;
                    case "False":
                        ch1.Value = true;
                        ch1.Style.BackColor = Color.GreenYellow;
                        break;
                }
                dgvListaFormulas.ClearSelection();
            }
        }
        private void BtnActivar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsWithCheckedColumn = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvListaFormulas.Rows)
            {
                if (Convert.ToBoolean(row.Cells[ck.Name].Value) == true)
                {
                    rowsWithCheckedColumn.Add(row);
                }
            }

            int cantidad = rowsWithCheckedColumn.Count;
            if (cantidad == 0)
            {
                MessageBox.Show(@"No se ha seleccionado ninguna formula para desactivar",
                    @"Seleccione Formulas de la Grilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var msg = MessageBox.Show($@"Confirma la Activacion de {cantidad} formulas?", "Activacion Automatica",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            foreach (var x in rowsWithCheckedColumn)
            {
                new BOMManager().SetFormulaActiva(Convert.ToInt32(x.Cells[idFormulaDataGridViewTextBoxColumn.Name].Value));
            }
        }

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsWithCheckedColumn = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvListaFormulas.Rows)
            {
                if (Convert.ToBoolean(row.Cells[ck.Name].Value) == true)
                {
                    rowsWithCheckedColumn.Add(row);
                }
            }

            int cantidad = rowsWithCheckedColumn.Count;
            if (cantidad == 0)
            {
                MessageBox.Show(@"No se ha seleccionado ninguna formula para Desactivar",
                    @"Seleccione Formulas de la Grilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var msg = MessageBox.Show($@"Confirma la DES-ACTIVACION de {cantidad} formulas?", @"Desactivacion Automatica",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            foreach (var x in rowsWithCheckedColumn)
            {
                new BOMManager().SetFormulaInactiva(Convert.ToInt32(x.Cells[idFormulaDataGridViewTextBoxColumn.Name].Value));
            }
        }

        private void RbUltimoUso_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUltimoUso.Checked)
            {
                _data = _data.OrderByDescending(c => c.UltimoUso).ToList();
                dataBs.DataSource = _data;
            }
            else
            {
                _data = _data.OrderBy(c => c.MaterialFabricar).ToList();
                dataBs.DataSource = _data;
            }
        }
    }
}
