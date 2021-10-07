using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity.DataStructure.BOM;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO05SeleccionaFormulaCosteo : Form
    {
        public FrmCO05SeleccionaFormulaCosteo(string material)
        {
            _material = material;
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------
        private readonly string _material;
        private int? _fCostAlmacenada;
        private int? _formulaSeleccionadaNew;
        private List<StxBomHeaderWithCost> _data;
        //---------------------------------------------------------------------------------

        private void FrmCO05SeleccionaFormulaCosteo_Load(object sender, EventArgs e)
        {
            this.dgvHeader.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHeader_CellEnter);
            this.ckSoloFormulasActivas.CheckedChanged -= new System.EventHandler(this.CkSoloFormulasActivas_CheckedChanged);
            //Inicializa Screen
            ckSoloFormulasActivas.Checked = true;

            txtMaterial.Text = _material;
            var matdata = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = matdata.MAT_DESC;
            txtOrigen.Text = matdata.ORIGEN;
            txtMtype.Text = matdata.TIPO_MATERIAL;
            txtTC.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");
            cmbMonedaCosto.SelectedItem = matdata.MonedaCosto;

            if (matdata.FORM_COSTO == null || matdata.FORM_COSTO <= 0)
            {
                _fCostAlmacenada = null;
                txtFormulaFCOST.Text = null;
                MessageBox.Show(@"Atencion NO existe una formula para costeo seleccionada", @"FCOST Inexistente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFormulaDescription.Text = @"FCOST NO Seleccionada";
                //return;
            }
            else
            {
                _fCostAlmacenada = matdata.FORM_COSTO;
                txtFormulaFCOST.Text = _fCostAlmacenada.ToString();
                txtFormulaDescription.Text = new BOMManager().GetFormulaHeader(_fCostAlmacenada.Value).DESC_FORMULA;
            }
            this.dgvHeader.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHeader_CellEnter);
            _data = new BOMManager().GetListFormulasFromMaterialWithCostStructure(_material, ckSoloFormulasActivas.Checked);
            BoMHeaderBs.DataSource = _data;
            this.ckSoloFormulasActivas.CheckedChanged += new System.EventHandler(this.CkSoloFormulasActivas_CheckedChanged);
            PopulaCosto();
            SeleccionayColoreaDgv();
        }
        private void PopulaCosto()
        {
            ACostoMfg xmfg;
            xmfg = new ACostoMfgNowUc(_material);
            foreach (var item in _data)
            {
                xmfg.SetFCost(item.ID_FORMULA);
                xmfg.GetCost();
                item.Complex = xmfg.LevelMax;
                item.MfgCostArs = xmfg.ValorARS;
                item.MfgCostUsd = xmfg.ValorUSD;
            }
        }

        private void SeleccionayColoreaDgv()
        {
            dgvHeader.ClearSelection();
            if (_fCostAlmacenada != null)
            {
                var seleccion = false;
                for (var i = 0; i < dgvHeader.Rows.Count; i++)
                {

                    int fcostX = Convert.ToInt32(dgvHeader.Rows[i].Cells[iDFORMULADataGridViewTextBoxColumn.Name].Value);
                    if (fcostX == _fCostAlmacenada.Value)
                    {
                        dgvHeader.Rows[i].Selected = true;
                        seleccion = true;
                    }



                    if (Convert.ToBoolean(dgvHeader.Rows[i].Cells[aCTIVADataGridViewTextBoxColumn.Name].Value))
                    {
                        for (var p = 0; p < dgvHeader.Columns.Count; p++)
                        {
                            dgvHeader.Rows[i].Cells[p].Style.BackColor = Color.LightYellow;
                        }
                        //dgvHeader.Rows[i].Cells[aCTIVADataGridViewTextBoxColumn.Name].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        for (var p = 0; p < dgvHeader.Columns.Count; p++)
                        {
                            dgvHeader.Rows[i].Cells[p].Style.BackColor = Color.LightGray;
                        }
                        //dgvHeader.Rows[i].Cells[aCTIVADataGridViewTextBoxColumn.Name].Style.BackColor = Color.LightGray;
                    }
                }

                if (seleccion == false)
                {
                    MessageBox.Show(@"Atencion la Formula Seleccionada para Costeo NO se encuentra activa",
                        @"FCOST Inactiva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void DgvHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var idFormula = Convert.ToInt32(dgvHeader[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            BoMItemsBs.DataSource = new BOMManager().GetFormulaItems(idFormula);
            _formulaSeleccionadaNew = Convert.ToInt32(dgvHeader[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            dgvItems.ClearSelection();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Al modificar la seleccion de formula en el DgV
        private void DgvHeader_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            _formulaSeleccionadaNew = Convert.ToInt32(datagridview[iDFORMULADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            //if (ckRecalculoCosto.Checked)
            //    CalculoCostoMemoria(_formulaSeleccionadaNew.Value);
        }

        /// <summary>
        /// Actualizacion de FCOST
        /// </summary>
        private void BtnModificarFormulaCosteo_Click(object sender, EventArgs e)
        {
            if (_fCostAlmacenada == _formulaSeleccionadaNew)
            {
                MessageBox.Show(@"La Formula Seleccionada es la misma que ya estaba seleccionada!", @"FCOST sin Modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resp = MessageBox.Show(@"Confirma la modificacion de la formula de Costeo [FCOST]?", @"Modificacion de FCOST",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resp == DialogResult.No)
                return;
            var rtn = new BFcostManager().SetFcostInMaterialMaster(_material, _formulaSeleccionadaNew);
            if (rtn == false)
            {
                MessageBox.Show(@"Existió un error al setear la formula en el Material Master");
                return;
            }
            txtFormulaFCOST.Text = _formulaSeleccionadaNew.Value.ToString();
            txtFormulaDescription.Text = new BOMManager().GetFormulaHeader(_formulaSeleccionadaNew.Value).DESC_FORMULA;
            MessageBox.Show(@"Se ha Actualizado Correctamente la Info de FCOST.", @"FCOST Actualizada",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CkSoloFormulasActivas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloFormulasActivas.Checked)
            {
                _data = new BOMManager().GetListFormulasFromMaterialWithCostStructure(_material, true);
            }
            else
            {
                _data = new BOMManager().GetListFormulasFromMaterialWithCostStructure(_material, false);
            }
            BoMHeaderBs.DataSource = _data;
            PopulaCosto();
            SeleccionayColoreaDgv();
        }

        private void BtnExplosionCompleta_Click(object sender, EventArgs e)
        {
            if (_formulaSeleccionadaNew == null)
            {
                MessageBox.Show(
                    @"No Existe una Formula [FCOST] Seleccionada para poder visualizar la explosion completa de formula",
                    @"FCOST No Seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }


            using (var f = new FrmCO06MfgCostExplosion(_material, _formulaSeleccionadaNew.Value))
            {
                f.ShowDialog();
            }
        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
    }
}
