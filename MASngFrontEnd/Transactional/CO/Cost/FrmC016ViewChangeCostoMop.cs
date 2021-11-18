using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;
using TSControls;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmC016ViewChangeCostoMop : Form
    {
        private readonly string _material;
        private decimal mfgNow = 0;
        private decimal mfgSaved = 0;
        private decimal cr = 0;

        public FrmC016ViewChangeCostoMop(string material)
        {
            _material = material;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmC016ViewChangeCostoMop_Load(object sender, EventArgs e)
        {
            //var mfg = new CostoManufactura();
            txtMaterial.Text = _material;
            var crMaterial = new CostRollManager().GetRegistroCostRoll(_material);
            txtFechaCR.Text = crMaterial.CostRollDate.ToString("g");
            txtFechaCosto.Text = crMaterial.CostRepoDate.Value.ToString("d");
            txtMonedaCosto.Text = crMaterial.MonedaCosto;
            var matData = new MaterialMasterManager().GetPrimarioInfo(_material);
            if (matData.FORM_COSTO == null)
            {
                txtFcostNow.Text = @"????";
                txtDescripcionFormulaNow.Text = @"No Existe Formula Seleccionada";
                txtDescripcionFormulaNow.ForeColor = Color.Red;
                txtMfgNow.Text = 99999.ToString("C3");
            }
            else
            {
                txtFcostNow.Text = matData.FORM_COSTO.ToString();
                txtDescripcionFormulaNow.Text =
                    new BOMManager().GetFormulaHeader(matData.FORM_COSTO.Value).DESC_FORMULA;
                txtDescripcionFormulaNow.ForeColor = Color.Black;
                txtMfgNow.Text =
                    "??"; //mfg.CalculaMfgCostNewVersionByFcost(matData.FORM_COSTO.Value,CostoBaseManager.TipoCosto.Reposicion, matData.MonedaCosto, -1, true).USD.ToString("c3");
            }

            txtCostoCR.Text = crMaterial.CostoCR.ToString("C3");

            ckManualUpd.Checked = crMaterial.ManualUpdated;
            ckUpdAfterCR.Checked = crMaterial.UpdatedAfterCR;
            if (crMaterial.FCost == null)
            {
                txtFcost.Text = @"????";
                txtFCostDescripcion.Text = @"No Existe Formula Seleccionada";
            }
            else
            {
                txtFcost.Text = crMaterial.FCost.ToString();
                var formulaH = new BOMManager().GetFormulaHeader(crMaterial.FCost.Value);
                txtFCostDescripcion.Text = formulaH.DESC_FORMULA;
            }

            ctlFcostDiferente.SetLights = crMaterial.FCost != matData.FORM_COSTO
                ? CtlSemaforo.ColoresSemaforo.Rojo
                : CtlSemaforo.ColoresSemaforo.Verde;
            txtMfgSaved.Text = @"??"; //mfg.GetCostSaved(_material).RepoUsd.ToString("C3");
            MopBs.DataSource = new MargenDocument().GetMargenDataList(crMaterial.CostRollId.Value, txtMaterial.Text);
        }

        private void ctlNuevoCostRoll_Validated(object sender, EventArgs e)
        {
            if (ctlNuevoCostRoll.GetValueDecimal <= 0)
            {
                ctlNuevoCostRoll.SetValue = cr;
                ckManualUpd.Checked = false;
                ckUpdAfterCR.Checked = false;
            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMopOp.Rows)
            {
                row.Cells[__ck.Name].Value = true;
            }
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMopOp.Rows)
            {
                row.Cells[__ck.Name].Value = false;
            }
        }

        private void btnUpdateCR_Click(object sender, EventArgs e)
        {
            if (ctlNuevoCostRoll.GetValueDecimal == 0)
            {
                MessageBox.Show($@"No se puede definir un CR-Cost como {0.ToString("C3")}", @"CR Cost Incorrecto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FormatAndConversions.CCurrencyADecimal(txtCostoCR.Text) == ctlNuevoCostRoll.GetValueDecimal)
            {
                MessageBox.Show($@"No se ha modificado el Costo CR", @"CR Cost Sin Modificacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvMopOp.Rows.Count == 0)
            {
                var m = MessageBox.Show(
                    $@"No Existe ninguna Operacion del material que esta actualizando. Confirma la utiizacion del costo {ctlNuevoCostRoll.GetValueDecimal.ToString("C3")} a partir de este momento?",
                    @"Modificacion de CR-Mfg", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.No)
                    return;
            }

            List<int> data = new List<int>();
            foreach (DataGridViewRow row in dgvMopOp.Rows)
            {
                if (row.Cells[__ck.Name].Value != null)
                {
                    if ((bool)row.Cells[__ck.Name].Value == true)
                    {
                        data.Add(Convert.ToInt32(row.Cells[dataGridViewTextBoxColumn1.Name].Value));
                        //MessageBox.Show($"modifico # {row.Cells[dataGridViewTextBoxColumn1.Name].Value}");
                    }
                }
            }

            if (data.Count == 0)
            {
                var m = MessageBox.Show(
                    $@"No Existe ninguna Operacion del material Seleccionado. Confirma la utiizacion del costo {ctlNuevoCostRoll.GetValueDecimal.ToString("C3")} a partir de este momento, pero sin modificar la historia?",
                    @"Modificacion de CR-Mfg", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.No)
                    return;
            }
            else
            {
                var m = MessageBox.Show(
                    $@"Ha Seleccionado {data.Count} Operaciones para Actualizar el CR. Confirma la utiizacion del costo {ctlNuevoCostRoll.GetValueDecimal.ToString("C3")} a partir de este momento?",
                    @"Modificacion de CR-Mfg", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (m == DialogResult.No)
                    return;
            }

            new CostRollManager().UpdateMfgCostAfterCrRun(_material, ctlNuevoCostRoll.GetValueDecimal,
                ckManualUpd.Checked, ckUpdAfterCR.Checked);
            foreach (var itemz in data)
            {
                new MargenDocument().UpdateMfgCr(itemz, (decimal)ctlNuevoCostRoll.GetValueDecimal);
            }
        }

        private void btnUseMfgAsCr_Click(object sender, EventArgs e)
        {
            mfgNow = FormatAndConversions.CCurrencyADecimal(txtMfgNow.Text);
            mfgSaved = FormatAndConversions.CCurrencyADecimal(txtMfgSaved.Text);
            cr = FormatAndConversions.CCurrencyADecimal(txtCostoCR.Text);

            if (mfgNow == cr)
            {
                MessageBox.Show(@"No se puede modificar el costo CR porque el costo Mfg es el Mismo",
                    @"Datos No Guardados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var r = MessageBox.Show($@"Confirma copiar el costo {mfgNow.ToString("C3")} como nuevo costo CR? (presione luego boton modificar costo CR para hacer efectivo el cambio)",
                @"Confirmacion Costo Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            ctlNuevoCostRoll.SetValue = mfgNow;
            ckUpdAfterCR.Checked = true;
            ckUpdAfterCR.ForeColor = Color.Green;
            ckManualUpd.Checked = false;
            ckManualUpd.ForeColor = Color.Black;
        }
    }
}
