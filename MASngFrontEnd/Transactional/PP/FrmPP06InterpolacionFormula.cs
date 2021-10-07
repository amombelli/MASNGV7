using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP06InterpolacionFormula : Form
    {
        public FrmPP06InterpolacionFormula()
        {
            InitializeComponent();
        }

        public FrmPP06InterpolacionFormula(string primario, decimal kgCalculo)
        {
            _kgCalculo = kgCalculo;
            _primario = primario;
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------
        private decimal _kgCalculo;
        private readonly string _primario;
        private int _numeroFormula;
        private decimal kgMPCalculoReal;
        public List<T0072_FORMULA_TEMP> _lista = new List<T0072_FORMULA_TEMP>();
        //------------------------------------------------------------------------------------------
        private void FrmPP06InterpolacionFormula_Load(object sender, EventArgs e)
        {
            txtKgRecalculo.Text = _kgCalculo.ToString("N2");
            txtMaterialPrimario.Text = _primario;
            txtKgRecalculo.ReadOnly = true;

            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //para poder heredar
                ckSoloFormulaActiva.Checked = true;
                t0020Bs.DataSource = new BOMManager().GetListFormulasFromMaterial(_primario, ckSoloFormulaActiva.Checked);
            }
        }


        private void PopulateFormula()
        {
            if (cmbFormulas.SelectedValue == null)
            {
                BlanqueaInformacion();
                return;
            }

            var data = (T0020_FORMULA_H)cmbFormulas.SelectedItem;
            txtNumeroFormula.Text = data.ID_FORMULA.ToString();
            _numeroFormula = data.ID_FORMULA;

            var formData = new BOMManager().GetFormulaHeader(_numeroFormula);
            if (formData == null)
            {
                BlanqueaInformacion();
                return;
            }
            cmbFormulas.SelectedValue = formData.ID_FORMULA;
            txtUltimaUtilizacion.Text = formData.LastUsed?.ToString("D") ?? @"NO DISPONIBLE";

            var bomItemsList = new BOMManager().GetFormulaItems(_numeroFormula);
            var a = 1;

            //Al cambiar la formula remueve todos los CostItems y luego los agrega a la lista
            _lista.Clear();
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
            RecalculaFormula();
            FormatoDgv();
            btnUtilizarReemplazo.Enabled = true;
        }

        private void BlanqueaInformacion()
        {
            txtMaterialPrimario.Text = @"SELECCIONE FORMULA";
            txtNumeroFormula.Text = @"0000";
            txtUltimaUtilizacion.Text = @"NO DISPONIBLE";
            btnUtilizarReemplazo.Enabled = false;
        }

        private void RecalculaFormula(bool updateKg = true)
        {
            decimal porcentajeTotal = 0;
#pragma warning disable CS0219 // The variable 'kgCalculoFormula' is assigned but its value is never used
            decimal kgCalculoFormula = 0;
#pragma warning restore CS0219 // The variable 'kgCalculoFormula' is assigned but its value is never used

            kgMPCalculoReal = 0;

            //Calcula el porcentaje de CostItems con Recalculo %
            foreach (var it in _lista.Where(c => c.idItemFormula != 999).ToList())
            {
                if (!it.Recalculo)
                {
                    porcentajeTotal += it.CantidadPor.Value;
                }
            }

            //Calcula el valor en Kg de los CostItems sin Recalculo (Kg Fijos)
            var listaKgFijo = _lista.Where(c => c.Recalculo).ToList();
            if (listaKgFijo.Count > 0)
            {
                var kgRecalcularNew = _kgCalculo - listaKgFijo.Sum(c => c.CantidadKGReal.Value);
                if (kgRecalcularNew <= 0)
                {
                    MessageBox.Show(
                        @"El Valor de Kg Fijos [Sin Recaluclo] excede/equipara al valor de Kg A Calcular." +
                        Environment.NewLine +
                        $"Se coloca un valor generico de {listaKgFijo.Sum(c => c.CantidadKGReal.Value) * 2} Kg (Fijos *2)",
                        @"Valor Excedido",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _kgCalculo = listaKgFijo.Sum(c => c.CantidadKGReal.Value) * 2;
                    txtKgRecalculo.Text = _kgCalculo.ToString("N2");
                }
            }

            if (updateKg)
            {
                foreach (var it in _lista.Where(c => c.idItemFormula != 999).ToList())
                {
                    if (!it.Recalculo)
                    {
                        var newPorcentaje = it.CantidadPor / porcentajeTotal;
                        it.CantidadKGReal = _kgCalculo * newPorcentaje;
                    }
                    kgMPCalculoReal += it.CantidadKGReal.Value;
                }
            }
            else
            {
                foreach (var it in _lista.Where(c => c.idItemFormula != 999).ToList())
                {
                    kgMPCalculoReal += it.CantidadKGReal.Value;
                }
            }

            foreach (var it in _lista.Where(c => c.idItemFormula != 999).ToList())
            {
                if (kgMPCalculoReal == 0)
                {
                    it.CantidadKGReal = 0;
                }
                else
                {
                    it.CantidadPorReal = it.CantidadKGReal / kgMPCalculoReal;
                }
            }
            //Actualizacion linea de toales
            var item = _lista.Find(c => c.idItemFormula == 999);
            if (item == null)
            {
                _lista.Add(new T0072_FORMULA_TEMP()
                {
                    idItemFormula = 999,
                    Primario = "TOTAL >>",
                    CantidadKGReal = Decimal.Round(kgMPCalculoReal, 2),
                    CantidadPorReal = Decimal.Round(1, 2),
                });
            }
            else
            {
                item.CantidadKGReal = Decimal.Round(kgMPCalculoReal, 2);
            }
            t0072Bs.DataSource = _lista.OrderBy(c => c.idItemFormula).ToList();
            FormatoDgv();
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


        private void btnUtilizarReemplazo_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show($"Confirma el reemplazo de {_primario} por su correspondiente formula?",
                @"Reemplazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
                return;

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void ckSoloFormulaActiva_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloFormulaActiva.Checked)
            {
                ckSoloFormulaActiva.BackColor = Color.LightGreen;
            }
            else
            {
                ckSoloFormulaActiva.BackColor = Color.LightSalmon;
            }
            t0020Bs.DataSource = new BOMManager().GetListFormulasFromMaterial(_primario, ckSoloFormulaActiva.Checked);
        }

        private void cmbFormulas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormulas.SelectedIndex == -1)
            {
                txtNumeroFormula.Text = null;
                txtUltimaUtilizacion.Text = @"SIN-INFO";
                return;
            }

            PopulateFormula();
        }

        private void cmbFormulas_SelectedValueChanged(object sender, EventArgs e)
        {
            PopulateFormula();
        }
    }
}
