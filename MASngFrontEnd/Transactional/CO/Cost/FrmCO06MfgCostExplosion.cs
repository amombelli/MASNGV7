using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO06MfgCostExplosion : Form
    {
        private readonly string _material;
        private readonly int _formulaId;
        private readonly List<CostItems> _lista;

        public FrmCO06MfgCostExplosion(string material, int formulaId)
        {
            _material = material;
            _formulaId = formulaId;
            InitializeComponent();
        }

        private void FrmCO06MfgCostExplosion_Load(object sender, EventArgs e)
        {
            txtmaterial.Text = _material;
            var matData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = matData.MAT_DESC;
            txtOrigen.Text = matData.ORIGEN;
            txtIdFormula.Text = _formulaId.ToString();
            var formData = new BOMManager().GetFormulaHeader(_formulaId);
            txtFormulaDescription.Text = formData.DESC_FORMULA;
            txtMonedaCost.Text = @"USD";
            tc.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");
            rbUC.Checked = true;

            var aMfg = new ACostoMfgNowUc(_material);
            aMfg.GetCostExplotadoAtLevelMax(formulaId: _formulaId);
            txtCostoARS.Text = aMfg.ValorARS.ToString("C3");
            txtCostoUSD.Text = aMfg.ValorUSD.ToString("C3");
            itemsBs.DataSource = aMfg.CostItems;
            headerBs.DataSource = aMfg.CostHeader;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
