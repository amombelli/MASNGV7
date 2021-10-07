using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;
using TSControls;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO03_Manufactura : Form
    {
        public FrmCO03_Manufactura()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CO02", "CO02"))
                return;
            _material = null;
            InitializeComponent();
            cmbMaterial.Enabled = true;
            _tipoCosto = ACosto.CostType.MfgNowUc;
        }
        public FrmCO03_Manufactura(string material, ACosto.CostType tipoCosto)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CO02", "CO02"))
                return;
            _material = material;
            InitializeComponent();
            cmbMaterial.Enabled = false;
            _tipoCosto = tipoCosto;
        }

        //----------------------------------------------------------------------
        private string _material;
        private int _fcost;
        private string _idTotalLine = "*Total*";
        private List<T0038_CostoMfgExplo> _dataDgvSingleLevel;
        private List<CostItems> _dataDgvMaxLevel;
        private ACosto.CostType _tipoCosto;
        ACostoMfg _manufacturingCost;
        //-----------------------------------------------------------------------

        private void FrmCO03_Manufactura_Load(object sender, EventArgs e)
        {
            if (_tipoCosto == ACosto.CostType.MfgNowUc)
            {
                rbUC.Checked = true;
            }
            else
            {
                rbCostoStandard.Checked = true;
            }

            rbSinExplosion.Checked = true;

            if (_material != null)
            {
                //Se provee Material
                cmbMaterial.Text = _material;
                var matData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
                txtDescripcion.Text = matData.MAT_DESC;
                txtMtype.Text = matData.TIPO_MATERIAL;
                txtIdFormula.Text = matData.FORM_COSTO.ToString();
                if (string.IsNullOrEmpty(txtIdFormula.Text))
                {
                    MessageBox.Show(@"No se ha encontrado una version de Formula FCOST para este material",
                        @"FCOST Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFormulaDescription.Text = @"Formula Inexisnte";
                }
                else
                {
                    var form = new BOMManager().GetFormulaHeader(matData.FORM_COSTO.Value);
                    txtFormulaDescription.Text = form.DESC_FORMULA;
                }
                txtOrigen.Text = matData.ORIGEN;
            }
            else
            {
                //con material nulo
                this.cmbMaterial.SelectedIndexChanged -= new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
                BindingSource bs = new BindingSource
                {
                    DataSource = MaterialMasterManager.GetMfgMaterialList(false)
                };
                cmbMaterial.DataSource = bs;
                cmbMaterial.SelectedIndex = -1;
                tc.SetValue = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            }
        }


        /// <summary>
        /// Calcula on the fly el costo de manufactura con valores de reposicion o valores STD
        /// </summary>
        private void MapeaCostoNow()
        {
            if (_material == null)
                return;

            if (_tipoCosto == ACosto.CostType.MfgNowUc)
            {
                _manufacturingCost = new ACostoMfgNowUc(_material, tc.GetValueDecimal);
            }
            else
            {
                _manufacturingCost = new ACostoMfgNowStd(_material, tc.GetValueDecimal);
            }

            txtMonedaCost.Text = _manufacturingCost.Moneda;
            _manufacturingCost.GetCost();
            txtRepoArs.Text = _manufacturingCost.ValorARS.ToString("C3");
            txtRepoUsd.Text = _manufacturingCost.ValorUSD.ToString("C3");
            txtRepoFechaUpdateCost.Text = _manufacturingCost.FechaCosto.ToString("d");
            txtLevelMax.Text = _manufacturingCost.LevelMax.ToString();
            if (rbExplosionMax.Checked)
            {
                _manufacturingCost.GetCostExplotadoAtLevelMax(tipoCostoMP: _manufacturingCost.TipoCosto);
                _dataDgvMaxLevel = _manufacturingCost.CostItems;
                var data2 = new CostItems()
                {
                    ItemMP = _idTotalLine,
                    CostoProp = 0,
                    Prop = 0,
                    Moneda = "USD"
                };
                _dataDgvMaxLevel.Add(data2);
                BsMaxLevel.DataSource = _dataDgvMaxLevel.ToList();
                FormatoGrillaMaxXplod();
            }
            else
            {
                if (_manufacturingCost.BomExplosion == null)
                {
                    MessageBox.Show(@"No hay info de epxlosion");
                    return;
                }
                _dataDgvSingleLevel = _manufacturingCost.BomExplosion;
                var data = new T0038_CostoMfgExplo()
                {
                    MaterialItem = _idTotalLine,
                    FormulaProp = 0,
                    CostoUSD = 0,
                    MonedaItem = "USD"
                };
                if (data != null)
                    _dataDgvSingleLevel.Add(data);
                BsSingleLevel.DataSource = _dataDgvSingleLevel.ToList();
                FormatoGrillaSingleXplod();
            }
        }

        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                _material = null;
                return;
            }
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;
            _material = cmbMaterial.SelectedValue.ToString();

            var materialData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = materialData.MAT_DESC;
            txtOrigen.Text = materialData.ORIGEN;
            txtMtype.Text = materialData.TIPO_MATERIAL;
            txtMonedaCost.Text = materialData.MonedaCosto;
            if (materialData.FORM_COSTO == null)
            {
                _fcost = -1;
                txtFormulaDescription.Text = @"Material SIN FCOST Asignado";
                txtIdFormula.Text = null;
                return;
            }
            else
            {
                _fcost = materialData.FORM_COSTO.Value;
                var formdata = new BOMManager().GetFormulaHeader(_fcost);
                txtFormulaDescription.Text = formdata.DESC_FORMULA;
                txtIdFormula.Text = _fcost.ToString();
            }
            MapeaCostoNow();

            if (FormatAndConversions.CCurrencyADecimal(txtCrUsd.Text) !=
                FormatAndConversions.CCurrencyADecimal(txtRepoUsd.Text))
            {
                ctlVariacionCosto.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            }
            else
            {
                ctlVariacionCosto.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            }

            //mapea costo standard
            var std = new ACostoStandard(_material, tc.GetValueDecimal);
            std.GetCost();
            txtCostoStdArs.Text = std.ValorARS.ToString("C2");
            txtCostoStdUsd.Text = std.ValorUSD.ToString("C2");
            txtCostoStdFecha.Text = std.FechaCosto.ToString("d");
            Cursor.Current = Cursors.Default;
        }
        private void RbUC_CheckedChanged(object sender, EventArgs e)
        {
            _tipoCosto = rbUC.Checked ? ACosto.CostType.MfgNowUc : ACosto.CostType.MfgNowStd;
            if (_material == null)
                return;
            MapeaCostoNow();

        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnModificarFormulaCosteo_Click(object sender, EventArgs e)
        {
            if (_material == null)
            {
                MessageBox.Show(@"Debe Seleccionar un material para visualizar la FCOST", @"Material sin Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            using (var f = new FrmCO05SeleccionaFormulaCosteo(_material))
            {
                f.ShowDialog();
            }
        }
        private void Tc_Validating(object sender, CancelEventArgs e)
        {
            if (_material != null)
            {
                // MapCostDataSaved();
            }
        }




        /// <summary>
        /// Explota formula nuevamente al hacer doble click
        /// </summary>
        private void DgvFormulaSimple_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //si el origen es fabricado abre una ventana nueva con la explosion
            var datagridview = (DataGridView)sender;
            if (datagridview.Columns[e.ColumnIndex].Index == datagridview.Columns[x2Origen.Name].Index)
            {
                if (datagridview[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    MessageBox.Show(@"Debe definir el Origen en el Material Master", @"Origen Desconocido",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (datagridview[e.ColumnIndex, e.RowIndex].Value.ToString() == "FAB")
                    {
                        var material_ = datagridview[x2Material.Name, e.RowIndex].Value.ToString();
                        using (var f0 = new FrmCO03_Manufactura(material_, _tipoCosto))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Proximamente se podra acceder al precio de reposicion", @"Sin Codificar",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void FormatoGrillaSingleXplod()
        {
            var dg = dgvFormulaSimple;
            for (var i = 0; i < dg.Rows.Count; i++)
            {
                var miRow = dg.Rows[i];
                var dOrigen = miRow.Cells[x2Origen.Name];
                var dMaterial = miRow.Cells[x2Material.Name].Value.ToString();
                var dFecha = miRow.Cells[x2fechaCosto.Name];

                //*** Formato de Linea de Totales ***
                if (dMaterial == _idTotalLine)
                {
                    //Completa Lineas Totales
                    miRow.Cells[x2Porcentaje.Name].Value = _dataDgvSingleLevel.Sum(c => c.FormulaProp);
                    miRow.Cells[x2Costo.Name].Value = txtMonedaCost.Text == @"USD" ? _dataDgvSingleLevel.Sum(c => c.PropUSD) : _dataDgvSingleLevel.Sum(c => c.PropARS);

                    //Colorea la linea de totales
                    for (var j = 0; j < dg.Columns.Count; j++)
                    {
                        dg.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        dg.Rows[i].Cells[j].Style.ForeColor = Color.DarkBlue;
                    }
                    //Pinta los Forecolor para que no se vean los valores default
                    dg.Rows[i].Cells[x2Unit.Name].Style.ForeColor = Color.Gray;
                    dg.Rows[i].Cells[x2fechaCosto.Name].Style.ForeColor = Color.Gray;
                }
                else
                {
                    //Formatea resto de rows
                    if (dOrigen.Value == null)
                    {
                        dOrigen.Style.BackColor = Color.Beige;
                    }
                    else
                    {
                        dOrigen.Style.BackColor =
                            dOrigen.Value.ToString() == "FAB" ? Color.LightGreen : Color.LightBlue;
                    }

                    if (Convert.ToDateTime(dFecha.Value).Date == Convert.ToDateTime(txtRepoFechaUpdateCost.Text).Date)
                    {
                        dFecha.Style.BackColor = Color.Linen;
                        dFecha.Style.ForeColor = Color.DarkRed;
                    }
                }
            }
            dg.Refresh();
        }
        private void FormatoGrillaMaxXplod()
        {
            var dg = dgvFormulaExplotadaMax;
            for (var i = 0; i < dg.Rows.Count; i++)
            {
                var miRow = dg.Rows[i];
                //var dOrigen = miRow.Cells[w.Name];
                var dMaterial = miRow.Cells[wMaterialMP.Name].Value.ToString();
                //var dFecha = miRow.Cells[x2fechaCosto.Name];

                //*** Formato de Linea de Totales ***
                if (dMaterial == _idTotalLine)
                {
                    //Completa Lineas Totales
                    miRow.Cells[wProporcion.Name].Value = _dataDgvMaxLevel.Where(c => c.ItemMP != _idTotalLine).Sum(c => c.Prop);
                    miRow.Cells[wCostoProporcional.Name].Value = _dataDgvMaxLevel.Where(c => c.ItemMP != _idTotalLine).Sum(c => c.CostoProp);

                    //Colorea la linea de totales
                    for (var j = 0; j < dg.Columns.Count; j++)
                    {
                        dg.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        dg.Rows[i].Cells[j].Style.ForeColor = Color.DarkBlue;
                    }
                    //Pinta los Forecolor para que no se vean los valores default
                    //dg.Rows[i].Cells[x2Unit.Name].Style.ForeColor = Color.Gray;
                    //dg.Rows[i].Cells[x2fechaCosto.Name].Style.ForeColor = Color.Gray;
                }
                else
                {
                    //Formatea resto de rows
                    //if (dOrigen.Value == null)
                    //{
                    //    dOrigen.Style.BackColor = Color.Beige;
                    //}
                    //else
                    //{
                    //    dOrigen.Style.BackColor =
                    //        dOrigen.Value.ToString() == "FAB" ? Color.LightGreen : Color.LightBlue;
                    //}

                    //if (Convert.ToDateTime(dFecha.Value).Date == Convert.ToDateTime(txtRepoFechaUpdateCost.Text).Date)
                    //{
                    //    dFecha.Style.BackColor = Color.Linen;
                    //    dFecha.Style.ForeColor = Color.DarkRed;
                    //}
                }
            }
            dg.Refresh();
        }
        private void BtnSetAsStandard_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"temporalmente fuera de servicio");

            //var msg = MessageBox.Show(@"Confirma definir este costo como standard?", @"Defnicion Costo Standard",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (msg == DialogResult.No)
            //    return;

            ////

            ////

            //MessageBox.Show(@"Se ha definido correctamente el costo como Standard", @"Defincion de Costo Standard",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void cmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null && combo.Text != string.Empty)
                e.Cancel = true;
        }
        private void rbSinExplosion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSinExplosion.Checked)
            {
                dgvFormulaExplotadaMax.Visible = false;
                dgvFormulaSimple.Visible = true;
            }
            else
            {
                dgvFormulaExplotadaMax.Visible = true;
                dgvFormulaSimple.Visible = false;

            }
            MapeaCostoNow();
        }
    }
}
