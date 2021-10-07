using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.PP;

namespace MASngFE.MasterData.BOM
{
    public partial class FrmMdb01BomSearch : Form
    {
        public FrmMdb01BomSearch(int modo)
        {
            _modo = modo;
            InitializeComponent();
        }
        public FrmMdb01BomSearch(int modo, string primario)
        {
            _modo = modo;
            _primarioSeleccionado = primario;
            InitializeComponent();
        }

        private readonly int _modo;
        private string _primarioSeleccionado;

        //modo 1 > creacion de BOM Habilitado
        //modo 2/3 > edicion no permite agregar formula nueva

        private void FrmBOMSearch_Load(object sender, EventArgs e)
        {
            ConfiguraInitialData();
        }
        private void ConfiguraInitialData()
        {
            if (_modo == 1)
            {
                //Creacion de BOM > Lista todos los materiales
                btnNewFormula.Enabled = true;
                t0020_Combo.DataSource = new MaterialTypeManager().GetListMaterialsTobeManufacture();
            }
            else
            {
                //Edicion-Visualizacion > Lista solo materiales con BOM
                btnNewFormula.Enabled = false;
                t0020_Combo.DataSource = new BOMManager().GetListMaterialWithBOM();
            }


            if (_primarioSeleccionado != null)
            {
                //El material es provisto no deja modificarlo
                cmbMaterialFormula.Text = _primarioSeleccionado;
                cmbMaterialFormula.Enabled = false;
                t0020FORMULAHBindingSource.DataSource =
                    new BOMManager().GetListFormulasFromMaterial(_primarioSeleccionado, false);

                if (dgvFormulaList.Rows.Count > 0)
                {
                    dgvFormulaList.Visible = true;
                    txtAlternativasDispo.Text = dgvFormulaList.RowCount.ToString();
                }
                else
                {
                    MessageBox.Show(@"No se han encntrado formulas para este material", @"Sin Datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dgvFormulaList.Visible = false;
                    txtAlternativasDispo.Text = 0.ToString("n");
                }
                var md = new MaterialMasterManager().GetPrimarioInfo(_primarioSeleccionado);
                txtDescripcionTecnica.Text = md.DescripcionTecnicaLab;
            }
            else
            {
                //El Usuario DEBE seleccionar el mateiral
                //cmbMaterialFormula.DataSource = t0020FORMULAHBindingSource.DataSource;
                cmbMaterialFormula.Enabled = true;
                cmbMaterialFormula.SelectedIndex = -1;
            }
        }
        private void cmbMaterialFormula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterialFormula.SelectedIndex == -1)
            {
                txtDescripcionTecnica.Text = null;
                txtAlternativasDispo.Text = @"0";
                dgvFormulaList.Visible = false;
                return;
            }

            var md = new MaterialMasterManager().GetPrimarioInfo(cmbMaterialFormula.SelectedValue.ToString());
            txtDescripcionTecnica.Text = md.DescripcionTecnicaLab;

            t0020FORMULAHBindingSource.DataSource =
                new BOMManager().GetListFormulasFromMaterial(cmbMaterialFormula.SelectedValue.ToString(), false);

            if (dgvFormulaList.Rows.Count > 0)
            {
                dgvFormulaList.Visible = true;
                txtAlternativasDispo.Text = dgvFormulaList.RowCount.ToString();
            }
            else
            {
                dgvFormulaList.Visible = false;
                txtAlternativasDispo.Text = @"0";
            }
        }
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNewFormula_Click(object sender, EventArgs e)
        {
            if (cmbMaterialFormula.SelectedValue == null)
            {
                MessageBox.Show(@"Debe seleccionar un Material para crear su formula de produccion",
                    @"Seleccion de Materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var f = new FrmMdb02BomMainData(cmbMaterialFormula.SelectedValue.ToString()))
            {
                f.ShowDialog();
            }
        }
        private void dgvFormulaList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvFormulaList[e.ColumnIndex, e.RowIndex].Value.ToString();
                int numeroFormula = Convert.ToInt32(dgvFormulaList[dgvFormulaList.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "DETALLE":
                        using (var f0 = new FrmMdb02BomMainData(_modo, numeroFormula))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                t0020FORMULAHBindingSource.DataSource = new BOMManager().GetListFormulasFromMaterial(_primarioSeleccionado, false);
                                // dgvFormulaList.DataSource = new BOMManager().GetListFormulasFromMaterial(_primarioSeleccionado, false);
                                //    new BOMManager().GetListFormulasFromMaterial(_primarioSeleccionado, false);
                            }
                        }

                        break;


                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        //private void btnNewBOM_Click(object sender, EventArgs e)
        //{
        //    if (cmbMaterialFormula.SelectedValue == null)
        //    {
        //        var f0 = new FrmMDB02BomMainData(_modo,null);
        //        this.Close();
        //        f0.Show();
        //    }
        //    else
        //    {
        //        var f0 = new FrmMDB02BomMainData(_modo, cmbMaterialFormula.SelectedValue.ToString());
        //        this.Close();
        //        f0.Show();
        //    }
        //}


    }
}
