using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO14UpdateFCost : Form
    {
        private readonly string _material;
        private int? _fCostAlmacenada = null;
        private int? _formulaSeleccionadaNew;

        public FrmCO14UpdateFCost(string material)
        {
            _material = material;
            InitializeComponent();
        }

        private void FrmCO14UpdateFCost_Load(object sender, EventArgs e)
        {
            this.dgvHeader.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeader_CellEnter);
            this.ckSoloFormulasActivas.CheckedChanged += new System.EventHandler(this.ckSoloFormulasActivas_CheckedChanged);
            this.ckRecalculoCosto.CheckedChanged -= new System.EventHandler(this.ckRecalculoCosto_CheckedChanged);

            txtMaterial.Text = _material;
            var primario = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtMaterialDescripcion.Text = primario.DescripcionTecnicaLab;
            cmbMonedaCosto.SelectedItem = primario.MonedaCosto;
            ckSoloFormulasActivas.Checked = true;

            //mapea costo CR
            var cr = new CostRollManager().GetRegistroCostRoll(_material);
            if (cr == null)
            {
                MessageBox.Show(@"Atencion: No Existe informacion de costo en el Cost Roll Activo", @"CR No Disponible",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                txtMonedaCR.Text = cr.MonedaCosto;
                txtCostoCR.Text = cr.CostoCR.ToString("C3");
            }


            _fCostAlmacenada = primario.FORM_COSTO;
            txtFormulaFCOST.Text = primario.FORM_COSTO.ToString();
            if (_fCostAlmacenada != null)
            {
                var formSelected = new BOMManager().GetFormulaHeader(_fCostAlmacenada.Value);
                txtFormulaDescription.Text = formSelected.DESC_FORMULA;
            }
            else
            {
                MessageBox.Show(@"Atencion no existe una formula para costeo seleccionada", @"FCOST Inexistente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFormulaDescription.Text = @"FCOST NO Seleccionada";
            }
            this.dgvHeader.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeader_CellEnter);
            BoMHeaderBs.DataSource = new BOMManager().GetListFormulasFromMaterial(_material, ckSoloFormulasActivas.Checked);
            this.ckSoloFormulasActivas.CheckedChanged += new System.EventHandler(this.ckSoloFormulasActivas_CheckedChanged);
            this.ckRecalculoCosto.CheckedChanged += new System.EventHandler(this.ckRecalculoCosto_CheckedChanged);
            SeleccionayColoreaDgv();
            if (_fCostAlmacenada != null)
                CalculoCostoMemoria(_fCostAlmacenada.Value);

        }

        private void SeleccionayColoreaDgv()
        {
            if (_fCostAlmacenada != null)
            {
                var seleccion = false;
                dgvHeader.ClearSelection();
                for (var i = 0; i < dgvHeader.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvHeader.Rows[i].Cells[iDFORMULADataGridViewTextBoxColumn.Name].Value) ==
                        _fCostAlmacenada.Value)
                    {
                        dgvHeader.Rows[i].Selected = true;
                        seleccion = true;
                    }

                    if (Convert.ToBoolean(dgvHeader.Rows[i].Cells[aCTIVADataGridViewTextBoxColumn.Name].Value))
                    {
                        dgvHeader.Rows[i].Cells[aCTIVADataGridViewTextBoxColumn.Name].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dgvHeader.Rows[i].Cells[aCTIVADataGridViewTextBoxColumn.Name].Style.BackColor = Color.Orange;
                    }
                }

                if (seleccion == false)
                {
                    MessageBox.Show(@"Atencion la Formula Seleccionada para Costeo NO se encuentra activa",
                        @"FCOST Inactiva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvHeader_Enter(object sender, EventArgs e)
        {

        }

        private void ckSoloFormulasActivas_CheckedChanged(object sender, EventArgs e)
        {
            BoMHeaderBs.DataSource =
                new BOMManager().GetListFormulasFromMaterial(_material, ckSoloFormulasActivas.Checked);
            SeleccionayColoreaDgv();
        }

        private void ckRecalculoCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckRecalculoCosto.Checked)
            {
                CalculoCostoMemoria(_formulaSeleccionadaNew.Value);
            }
            else
            {

            }
        }

        private void dgvHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var idFormula = Convert.ToInt32(dgvHeader[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            BoMItemsBs.DataSource = new BOMManager().GetFormulaItems(idFormula);
            _formulaSeleccionadaNew = Convert.ToInt32(dgvHeader[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            dgvItems.ClearSelection();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculoCostoMemoria(int formulaCalculo)
        {
            if (formulaCalculo < 0)
                return;

            if (string.IsNullOrEmpty(txtTC.Text))
                txtTC.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");

            if (cmbMonedaCosto.SelectedItem == null)
                cmbMonedaCosto.SelectedItem = "USD";

            //var costoMfg = new CostMfgMemoria();
            //costoMfg.CalculaMfgCost(formulaCalculo, cmbMonedaCosto.SelectedItem.ToString(),
            //    Convert.ToDecimal(txtTC.Text));

            txtCostoARS.Text = @"??";//costoMfg.CostoARS.ToString("C2");
            txtCostoUSD.Text = @"??";//costoMfg.CostoUSD.ToString("C2");
        }
    }
}
