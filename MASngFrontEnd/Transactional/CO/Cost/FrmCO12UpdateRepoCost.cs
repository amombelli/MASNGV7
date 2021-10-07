using System;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.Costos;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCo12UpdateRepoCost : Form
    {
        private readonly string _material;
        public FrmCo12UpdateRepoCost(string material)
        {
            _material = material;
            InitializeComponent();
        }
        private void btnSetNew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Confirma la Actualizacion de Costo Ultima Compra Manual?", @"Modificaicon de Costo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (cPrecioUcNew.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"El nuevo precico es incorrecto", @"Operacion Cancelada", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (FormatAndConversions.CCurrencyADecimal(txtPrecioCompra.Text) == cPrecioUcNew.GetValueDecimal)
            {
                MessageBox.Show(@"No hay variacion de Precio", @"Operacion Cancelada", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var cost = new ACostoRepo(_material);
            var moneda = Monedas.GetMonedaType(txtMoneda.Text);
            cost.UpdateExistingCost(moneda, cPrecioUcNew.GetValueDecimal);
        }
        private void FrmCO12UpdateRepoCost_Load(object sender, EventArgs e)
        {
            txtMaterial.Text = _material;
            var cost = new ACostoRepo(_material);
            cost.GetCost();
            if (cost.Encontrado)
            {
                txtOrigen.Text = cost.RecordT0036.Origen;
                txtMoneda.Text = cost.RecordT0036.MonedaCosto;
                cTc.SetValue = cost.RecordT0036.TCConversion;
                txtPrecioCompra.Text = cost.RecordT0036.MonedaCosto == "USD"
                    ? cost.RecordT0036.CostoUCUsd.ToString("C3")
                    : cost.RecordT0036.CostoUCArs.ToString("C3");
                txtKgCompra.Text = cost.DatosUc.KgUCompra.ToString("N2");
            }
            else
            {
                MessageBox.Show(@"Costo No encontrado", @"Error en Costo T0036", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
