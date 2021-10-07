using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;
using TSControls;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO11_ViewCostRollManufacturedDetail : Form
    {
        private readonly string _material;

        public FrmCO11_ViewCostRollManufacturedDetail(string material)
        {
            _material = material;
            InitializeComponent();
        }

        private void FrmCO11_ViewCostRollManufacturedDetail_Load(object sender, EventArgs e)
        {

           

            //var mfg = new CostoManufactura();
            rbReposicion.Checked = true;
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
                txtMfgNow.Text = @"??"; //mfg.CalculaMfgCostNewVersionByFcost(matData.FORM_COSTO.Value, CostoBaseManager.TipoCosto.Reposicion, matData.MonedaCosto, -1, true).USD.ToString("c3");
            }

            txtCostoCR.Text = rbReposicion.Checked ? crMaterial.CostoCR.ToString("C3") : 0.ToString("C3");
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
            var listaData = new CostRollExplosion().GetExplosionMaterial(_material);
            CostoBs.DataSource = listaData;
            ctlFcostDiferente.SetLights = crMaterial.FCost != matData.FORM_COSTO ? CtlSemaforo.ColoresSemaforo.Rojo : CtlSemaforo.ColoresSemaforo.Verde;
            txtMfgSaved.Text = "??"; // mfg.GetCostSaved(_material).RepoUsd.ToString("C3");
            // MopBs.DataSource = new MargenDocument().GetMargenDataList(crMaterial.CostRollId.Value, txtMaterial.Text);

        }
        private void rbReposicion_CheckedChanged(object sender, EventArgs e)
        {
            var rbx = (RadioButton)sender;
            switch (rbx.Name)
            {
                case "rbStandard":
                    xcostoUnitario.DataPropertyName = "CostoStdUsd";
                    xcostoProporcional.DataPropertyName = "CostoStdUsdProp";
                    xmanualUpd.DataPropertyName = "ManualUpdStd";
                    break;
                case "rbPpp":
                    xcostoUnitario.DataPropertyName = "";
                    xcostoProporcional.DataPropertyName = "";
                    break;
                case "rbReposicion":
                    xcostoUnitario.DataPropertyName = "CostoRepoUsd";
                    xcostoProporcional.DataPropertyName = "CostoRepoUsdProp";
                    xmanualUpd.DataPropertyName = "ManualUpdRepo";
                    break;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnModificarFormulaCosteo_Click(object sender, EventArgs e)
        {
            using (var f = new FrmCO14UpdateFCost(_material))
            {
                f.ShowDialog();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtCostoCR_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnViewMop_Click(object sender, EventArgs e)
        {
            var f = new FrmC016ViewChangeCostoMop(_material);
            f.Show();
        }
    }
}
