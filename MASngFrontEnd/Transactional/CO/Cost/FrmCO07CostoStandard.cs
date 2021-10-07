using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO07CostoStandard : Form
    {
        public FrmCO07CostoStandard()
        {
            InitializeComponent();
        }

        private string _material;


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtCostoArs.Text = 0.ToString("C2");
                txtCostoUsd.Text = 0.ToString("C2");
                txtCostoReferencia.Text = null;
                txtCostoRefArs.Text = 0.ToString("C2");
                txtCostoRefUsd.Text = 0.ToString("C2");
                txtMoneda.Text = @"USD";
                txtFecha.Text = null;
                txtCostDeterminedBy.Text = null;
                ckManualUpdated.Checked = false;
                return;
            }

            _material = cmbMaterial.SelectedValue.ToString();
            var matData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = matData.MAT_DESC;
            txtOrigen.Text = matData.ORIGEN;
            txtMtype.Text = matData.TIPO_MATERIAL;
            //

            var stdCost = new ACostoStandard(_material);
            stdCost.GetCost();
            txtCostoArs.Text = stdCost.ValorARS.ToString("C3");
            txtCostoUsd.Text = stdCost.ValorUSD.ToString("C3");
            txtMoneda.Text = stdCost.Moneda;
            txtFecha.Text = stdCost.FechaCosto.ToString("d");
            txtCostDeterminedBy.Text = stdCost.TipoCosto.ToString();

            var crCost = new CostRollManager().GetRegistroCostRoll(_material);
            if (crCost == null)
            {
                txtCostoCRArs.Text = 0.ToString("C3");
                txtCostoCRUSD.Text = 0.ToString("C3");
            }
            else
            {
                if (crCost.MonedaCosto == "USD")
                {
                    txtCostoCRUSD.Text = crCost.CostoCR.ToString("C3");
                    txtCostoCRArs.Text = Math.Round(crCost.CostoCR * tc.GetValueDecimal, 3).ToString("C3");

                }
                else
                {
                    txtCostoCRArs.Text = crCost.CostoCR.ToString("C3");
                    txtCostoCRUSD.Text = Math.Round(crCost.CostoCR / tc.GetValueDecimal, 3).ToString("C3");
                }
            }
            
            //Define costo de referencia
            if (txtOrigen.Text == @"FAB")
            {
                var mfgCost = new ACostoMfgNowUc(_material);
                if (mfgCost.FCost <= 0)
                {
                    MessageBox.Show(
                        @"No se puede obtener un costo de referencia de manufactura porque el material no tiene definido un FCOST",
                        @"Material sin FCOST", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                mfgCost.GetCost();
                txtCostoRefArs.Text = mfgCost.ValorARS.ToString("C3");
                txtCostoRefUsd.Text = mfgCost.ValorUSD.ToString("C3");
                txtFechaCostoRef.Text = mfgCost.FechaCosto.ToString("d");
                txtCostoReferencia.Text = mfgCost.TipoCosto.ToString();
            }
            else
            {
                var repoCost = new ACostoRepo(_material);
                repoCost.SetAutoFixIfRecordNotFound(true);
                repoCost.GetCost();
                txtCostoRefArs.Text = repoCost.ValorARS.ToString("C3");
                txtCostoRefUsd.Text = repoCost.ValorUSD.ToString("C3");
                txtFechaCostoRef.Text = repoCost.FechaCosto.ToString("g");
                txtCostoReferencia.Text = repoCost.TipoCosto.ToString();
            }
        }

        private void FrmCO07CostoStandard_Load(object sender, EventArgs e)
        {
            tc.SetValue = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            this.cmbMaterial.SelectedIndexChanged -= new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            BindingSource bs = new BindingSource();
            bs.DataSource = MaterialMasterManager.GetMaterialList(false);
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
        }

        private void CmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbMaterial);
        }

    }
}
