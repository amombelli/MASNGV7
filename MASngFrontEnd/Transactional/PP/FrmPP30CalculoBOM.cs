using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP30CalculoBOM : Form
    {
        protected FrmPP30CalculoBOM()
        {

        }
        public FrmPP30CalculoBOM(string primario)
        {
            _primario = primario;
            _modo = "MAT";
            InitializeComponent();
        }

        public FrmPP30CalculoBOM(int numeroFormula)
        {
            _numeroFormula = numeroFormula;
            _modo = "NUMFORMULA";
            InitializeComponent();
            this.dgvFormula.CellValueChanged +=
                 new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormula_CellValueChanged);
        }

        //--------------------------------------------------------------------------------------------------------
        private readonly string _primario;
        private readonly string _modo;
        private int _numeroFormula;
        public List<T0072_FORMULA_TEMP> _lista = new List<T0072_FORMULA_TEMP>();
        private decimal kgCalculoFormula;
        private decimal kgMPReal = 0;
        //--------------------------------------------------------------------------------------------------------


        private void FrmPP06CalculoInterpolacionFormulaKg_Load(object sender, EventArgs e)
        {
            ckSoloFormulaActiva.Checked = true;
            rbFijo.Checked = true;
            txtAddedProp.Text = 0.ToString("P2");
            txtAddedKg.Text = 0.ToString("N2");


            if (LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //do connection stuff here
                if (_modo == "MAT")
                {
                    LoadInfoMaterial();
                }
                else
                {
                    if (_modo == "NUMFORMULA")
                    {
                        kgCalculoFormula = 1;
                        txtKg.Text = 1.ToString("N2");
                        LoadInfoNumeroForm();
                    }
                    else
                    {
                        //
                    }
                }

            }
        }




        private void LoadInfoNumeroForm()
        {
            cmbFormulas.Text = _numeroFormula.ToString();
            cmbFormulas.Enabled = false;
            ckSoloFormulaActiva.Enabled = false;
            LoadFormulaData();
        }

        private void LoadInfoMaterial()
        {
            cmbFormulas.DataSource = new BOMManager().GetListFormulasFromMaterial(_primario, ckSoloFormulaActiva.Checked);
            txtNumeroFormula.Text = cmbFormulas.SelectedValue.ToString();
            cmbFormulas.Enabled = true;
            ckSoloFormulaActiva.Enabled = true;
            _numeroFormula = Convert.ToInt32(cmbFormulas.SelectedValue);
            LoadFormulaData();
        }

        private void LoadFormulaData()
        {
            var formData = new BOMManager().GetFormulaHeader(_numeroFormula);
            txtMaterialPrimario.Text = formData.IDMATERIAL;
            cmbFormulas.Text = formData.DESC_FORMULA;
            txtNumeroFormula.Text = formData.ID_FORMULA.ToString();
            txtUltimaUtilizacion.Text = formData.LastUsed?.ToString("D") ?? @"NO DISPONIBLE";

            var bomItemsList = new BOMManager().GetFormulaItems(_numeroFormula);
            int a = 1;
            foreach (var it in bomItemsList)
            {
                var x = new T0072_FORMULA_TEMP()
                {
                    Added = false,
                    idItemFormula = a,
                    CantidadBase = it.CANTIDAD.Value,
                    CantidadPor = it.CANTIDAD_PORC,
                    NForm = _numeroFormula,
                    Recalculo = false,
                    Primario = it.ITEM
                };
                a++;
                _lista.Add(x);
            }
            AgregaLineaTotalesDgv();
            RecalculaFormula();
            //FormatoDgv();
            // dgvFormula.DataSource = _lista.ToList();
        }
        private void RecalculaFormula(bool updateKg = true)
        {
            decimal porcentajeTotal = 0;
            kgMPReal = 0;

            foreach (var it in _lista.Where(c => c.idItemFormula != 999).ToList())
            {
                if (!it.Recalculo)
                {
                    porcentajeTotal += it.CantidadPor.Value;
                }
            }

            var x = _lista.Where(c => c.Recalculo).ToList();
            if (x.Count > 0)
            {
                kgCalculoFormula = kgCalculoFormula - x.Sum(c => c.CantidadKGReal.Value);
                if (kgCalculoFormula <= 0)
                {
                    MessageBox.Show(
                        @"El Valor de Kg Fijos excede/equipara al valor de Kg de Calculo." + Environment.NewLine +
                        $"Se coloca un valor generico de {x.Sum(c => c.CantidadKGReal.Value) * 2}", @"Valor Excedido",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kgCalculoFormula = x.Sum(c => c.CantidadKGReal.Value) * 2;
                    txtKg.Text = (x.Sum(c => c.CantidadKGReal.Value) * 2).ToString("N2");
                }
            }

            if (updateKg)
            {
                foreach (var it in _lista.Where(c => c.idItemFormula != 999).ToList())
                {
                    if (!it.Recalculo)
                    {
                        var newPorcentaje = it.CantidadPor / porcentajeTotal;
                        it.CantidadKGReal = kgCalculoFormula * newPorcentaje;
                    }
                    kgMPReal += it.CantidadKGReal.Value;
                }
            }
            else
            {
                foreach (var it in _lista.Where(c => c.idItemFormula != 999).ToList())
                {
                    kgMPReal += it.CantidadKGReal.Value;
                }
            }

            foreach (var it in _lista.Where(c => c.idItemFormula != 999).ToList())
            {
                if (kgMPReal == 0)
                {
                    it.CantidadKGReal = 0;
                }
                else
                {
                    it.CantidadPorReal = it.CantidadKGReal / kgMPReal;
                }
            }
            //Actualizacion linea de toales
            var item = _lista.Find(c => c.idItemFormula == 999);
            item.CantidadKGReal = Decimal.Round(kgMPReal, 2);
            t0072Bs.DataSource = _lista.OrderBy(c => c.idItemFormula).ToList();
            FormatoDgv();
        }
        private void AgregaLineaTotalesDgv()
        {
            //Agrega Sumarizado en DataGridview

            var existe = _lista.Find(c => c.idItemFormula == 999);
            if (existe != null)
                _lista.Remove(existe);

            _lista.Add(new T0072_FORMULA_TEMP()
            {
                idItemFormula = 999,
                Primario = "TOTAL >>",
                CantidadKGReal = Decimal.Round(kgMPReal, 2),
                CantidadPorReal = Decimal.Round(1, 2),
            });
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimirFormula_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcion no realizada");
        }

        private void txtKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtKg_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKg.Text))
                txtKg.Text = 1.ToString("N2");

            kgCalculoFormula = Convert.ToDecimal(txtKg.Text);
            RecalculaFormula();
        }

        private void FormatoDgv()
        {
            //Formato a Linea de Total
            for (var i = 0; i < dgvFormula.Columns.Count; i++)
            {
                dgvFormula.Rows[dgvFormula.Rows.Count - 1].Cells[i].Style.BackColor = Color.Gray;
                dgvFormula.Rows[dgvFormula.Rows.Count - 1].Cells[i].Style.ForeColor = Color.DarkBlue;
            }

            for (var i = 0; i < dgvFormula.Rows.Count - 1; i++)
            {
                //Si el Row es Recalculo >
                dgvFormula.Rows[i].Cells[__Recalculo.Name].Style.BackColor =
                    (bool)dgvFormula.Rows[i].Cells[__Recalculo.Name].Value == true ? Color.Red : Color.White;

                //Si el Row fue Agregado Manualmente
                dgvFormula.Rows[i].Cells[__Added.Name].Style.BackColor =
                    (bool)dgvFormula.Rows[i].Cells[__Added.Name].Value == true ? Color.MediumSeaGreen : Color.White;

                //Si el Valor KgReal =0
                dgvFormula.Rows[i].Cells[__kgReal.Name].Style.BackColor =
                    Convert.ToDecimal(dgvFormula.Rows[i].Cells[__kgReal.Name].Value) == 0
                        ? Color.LightPink
                        : Color.White;

                //Si el Valor del Porcentaje Real vs. Calculado es Diferente.
                dgvFormula.Rows[i].Cells[__porcentajeReal.Name].Style.BackColor =
                    Convert.ToDecimal(dgvFormula.Rows[i].Cells[__cantidadPor.Name].Value) ==
                    Convert.ToDecimal(dgvFormula.Rows[i].Cells[__porcentajeReal.Name].Value)
                        ? Color.White
                        : Color.LightSalmon;

                //Si es Container
                if (dgvFormula.Rows[i].Cells[primarioDataGridViewTextBoxColumn.Name].Value.ToString().StartsWith("B"))
                {
                    dgvFormula.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                    dgvFormula.Rows[i].Cells[1].Style.BackColor = Color.Gold;
                    dgvFormula.Rows[i].Cells[2].Style.BackColor = Color.Gold;
                    dgvFormula.Rows[i].Cells[3].Style.BackColor = Color.Gold;
                }
            }
        }

        private void dgvFormula_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return; //Header

            //var celdaModificada = e.ColumnIndex;
            //decimal kgReal = 0;
            //decimal kgBatch = 0;


            ////Modificando Kg-Real
            //if (dgvFormula[dgvFormula.Columns[__kgReal.Name].Index, e.RowIndex].Value==null)
            //{
            //    dgvFormula[dgvFormula.Columns[__kgReal.Name].Index, e.RowIndex].Value = 0.ToString("N2");
            //}
            //kgReal = Convert.ToDecimal(dgvFormula[dgvFormula.Columns[__kgReal.Name].Index, e.RowIndex].Value);


            //bool manualAdded = (bool) dgvFormula[dgvFormula.Columns[__Added.Name].Index, e.RowIndex].Value;
            //var iditem = (int) dgvFormula[dgvFormula.Columns[idItemFormulaDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value;
            //var itemZ = _lista.Find(c => c.idItemFormula == iditem);
            //itemZ.CantidadKGReal = kgReal;
            //if (kgReal == 0)
            //{
            //    if (manualAdded == false)
            //    {
            //        MessageBox.Show(
            //            @"Este Item ya no sera tenido en cuenta para el recalculo de formula. Para Incluirlo nuevamente en el recalculo automatico coloque un valor cualquiera diferente a CERO",
            //            @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        itemZ.Recalculo = true;
            //    }
            //    else
            //    {

            //    }
            //}
            //else
            //{
            //    if (manualAdded == false)
            //    {
            //        itemZ.Recalculo = false;
            //    }
            //    else
            //    {

            //    }
            //}
            //RecalculaPorcentajeReal();
            ////FormatoDgv();
        }

        /// <summary>
        /// Asegurarse que el dato en el DGV sera del tipo autorizado
        /// </summary>
        private void dgvFormula_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgvFormula.CurrentCell.ColumnIndex == (int)dgvFormula.Columns[__kgReal.Name].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, false);
        }

        private void dgvFormula_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; //Header

            var celdaModificada = e.ColumnIndex;
            decimal kgReal = 0;
#pragma warning disable CS0219 // The variable 'kgBatch' is assigned but its value is never used
            decimal kgBatch = 0;
#pragma warning restore CS0219 // The variable 'kgBatch' is assigned but its value is never used


            //Modificando Kg-Real
            if (dgvFormula[dgvFormula.Columns[__kgReal.Name].Index, e.RowIndex].Value == null)
            {
                dgvFormula[dgvFormula.Columns[__kgReal.Name].Index, e.RowIndex].Value = 0.ToString("N2");
            }
            kgReal = Convert.ToDecimal(dgvFormula[dgvFormula.Columns[__kgReal.Name].Index, e.RowIndex].Value);


            bool manualAdded = (bool)dgvFormula[dgvFormula.Columns[__Added.Name].Index, e.RowIndex].Value;
            var iditem =
                (int)
                    dgvFormula[dgvFormula.Columns[idItemFormulaDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value;
            var itemZ = _lista.Find(c => c.idItemFormula == iditem);
            itemZ.CantidadKGReal = kgReal;
            if (kgReal == 0)
            {
                if (manualAdded == false)
                {
                    MessageBox.Show(
                        @"Este Item ya no sera tenido en cuenta para el recalculo de formula. Para Incluirlo nuevamente en el recalculo automatico coloque un valor cualquiera diferente a CERO",
                        @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    itemZ.Recalculo = true;
                }
                else
                {
                }
            }
            else
            {
                if (manualAdded == false)
                {
                    itemZ.Recalculo = false;
                }
                else
                {
                }
            }
            RecalculaFormula(false);
        }

        private void rbFijo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFijo.Checked)
            {
                txtAddedProp.Enabled = false;
                txtAddedProp.Text = 0.ToString("P2");
                txtAddedKg.Enabled = true;
                txtAddedKg.Text = 0.ToString("N2");
            }
            else
            {
                txtAddedProp.Enabled = true;
                txtAddedProp.Text = 0.ToString("P2");
                txtAddedKg.Enabled = false;
                txtAddedKg.Text = 0.ToString("N2");
            }

        }

        private void txtAddedKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void btnAgregarItemAdicional_Click(object sender, EventArgs e)
        {
            if (ValidaAddMaterial() == false)
                return;

            decimal valorKg = 0;
            decimal valorPor = 0;
            bool recal = false;

            if (rbFijo.Checked)
            {
                recal = true;
                valorKg = Convert.ToDecimal(txtAddedKg.Text);
            }
            else
            {
                recal = false;
                valorPor = FormatAndConversions.CPorcentajeADecimal(txtAddedProp.Text);
            }

            var x = new T0072_FORMULA_TEMP()
            {
                Added = true,
                idItemFormula = _lista.Count - 1,
                CantidadBase = valorKg,
                CantidadKGReal = valorKg,
                CantidadPor = valorPor,
                NForm = -1,
                Recalculo = recal,
                Primario = cmbPrimarioAdd.SelectedValue.ToString(),
            };
            _lista.Add(x);

            if (recal)
            {
                RecalculaFormula(false);
            }
            else
            {
                RecalculaFormula();
            }
        }

        private bool ValidaAddMaterial()
        {
            decimal valor = 0;

            if (string.IsNullOrEmpty(txtAddedKg.Text))
                txtAddedKg.Text = 0.ToString("N2");

            if (string.IsNullOrEmpty(txtAddedProp.Text))
                txtAddedProp.Text = 0.ToString("P2");


            if (cmbPrimarioAdd.SelectedValue == null)
            {
                toolTip1.ToolTipTitle = "Valor Incorrecto";
                toolTip1.Show("Debe proveer Material", cmbPrimarioAdd, cmbPrimarioAdd.Location, 5000);
                return false;
            }

            if (rbFijo.Checked)
            {
                valor = Convert.ToDecimal(txtAddedKg.Text);
                if (valor <= 0)
                {
                    toolTip1.ToolTipTitle = "Valor Incorrecto";
                    toolTip1.Show("Debe proveer un valor valido de Kg", txtAddedKg, txtAddedKg.Location, 5000);
                    return false;
                }
            }
            else
            {
                valor = FormatAndConversions.CPorcentajeADecimal(txtAddedProp.Text);
                if (valor <= 0)
                {
                    toolTip1.ToolTipTitle = "Valor Incorrecto";
                    toolTip1.Show("Debe proveer un valor valido de %", txtAddedProp, txtAddedProp.Location, 5000);
                    return false;
                }

                if (valor > 1)
                {
                    toolTip1.ToolTipTitle = "Valor Incorrecto";
                    toolTip1.Show("Debe proveer un valor valido de %", txtAddedProp, txtAddedProp.Location, 5000);
                    return false;
                }
            }



            return true;
        }

        private void cmbPrimarioAdd_Enter(object sender, EventArgs e)
        {
            if (cmbPrimarioAdd.Items.Count == 0)
            {
                t0010MATERIALESBindingSource.DataSource = new MaterialMasterManager().GetCompleteListofMaterial(true);
            }
        }

        private void cmbPrimarioAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrimarioAdd.SelectedIndex == -1)
            {
                txtDescripcionMaterialAdd.Text = null;
                return;
            }

            T0010_MATERIALES valor = (T0010_MATERIALES)cmbPrimarioAdd.SelectedItem;
            txtDescripcionMaterialAdd.Text = valor.MAT_DESC;
        }

        private void cmbPrimarioAdd_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPrimarioAdd.Text) && cmbPrimarioAdd.SelectedValue == null)
            {
                toolTip1.ToolTipTitle = "Valor Incorrecto";
                toolTip1.Show("El Material no es un material valido de TecserEnterprise!", cmbPrimarioAdd, cmbPrimarioAdd.Location, 5000);
                e.Cancel = true;
            }
            if (cmbPrimarioAdd.SelectedValue == null)
                txtDescripcionMaterialAdd.Text = null;
        }

        private void btnUtilizarReemplazo_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;

        }

        private void cmbFormulas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
