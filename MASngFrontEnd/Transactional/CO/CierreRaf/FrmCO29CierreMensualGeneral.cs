using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MASngFE.Application;
using MASngFE.Transactional.Cierre;
using Tecser.Business.Tools;
using Tecser.Business.TOOLS;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCo29CierreMensualGeneral : Form
    {
        private string _tipoLx;
        public FrmCo29CierreMensualGeneral()
        {
            InitializeComponent();
        }

        private void FrmCo29CierreMensualGeneral_Load(object sender, EventArgs e)
        {
            dtpFechaHoy.Value = DateTime.Today;
            txtPeriodo.Text = new PeriodoConversion().GetPeriodo(dtpFechaHoy.Value);
            dtpFechaInicial.Value = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text);
            dtpFechaFinal.Value = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text);
            ckL1.Checked = true;
            ckL2.Checked = false;
        }

        private void txtPeriodo_Validating(object sender, CancelEventArgs e)
        {
            dtpFechaInicial.Value = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text);
            dtpFechaFinal.Value = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text);
        }

        private void ckL2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL1.Checked == ckL2.Checked)
            {
                _tipoLx = ckL1.Checked == true ? @"L3" : @"L0";
            }
            else
            {
                _tipoLx = ckL1.Checked ? @"L1" : @"L2";
            }
            txtLx.Text = _tipoLx;
        }

        private void txtPeriodo_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Invalid Date";
                toolTip1.Show("The data you supplied must be a valid date in the format mm/dd/yyyy.", txtPeriodo, 0, -20,
                    5000);
            }
            else
            {
                //Now that the type has passed basic type validation, enforce more specific type rules.
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate < DateTime.Now)
                {
                    toolTip1.ToolTipTitle = "Invalid Date";
                    toolTip1.Show("The date in this field must be greater than today's date.", txtPeriodo, 0, -20, 5000);
                    e.Cancel = true;
                }
            }
        }

        private void txtCantidadPeriodos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void btnStockCheques_Click(object sender, EventArgs e)
        {
            var f = new FrmCO32ChequesCarteraCierre(dtpFechaInicial.Value,dtpFechaFinal.Value, _tipoLx);
            f.Show();
        }

        private void btnDetalleVentas_Click(object sender, EventArgs e)
        {
            var f = new FrmCO33DetalleLibroVentas(txtPeriodo.Text, _tipoLx);
            f.Show();
        }

        private void btnDetalleCompras_Click(object sender, EventArgs e)
        {
            var f = new FrmCO34DetalleComprasMP(txtPeriodo.Text,_tipoLx);
            f.Show();
        }

        private void btnDetalleGastos_Click(object sender, EventArgs e)
        {
            var f = new FRMCO35DetalleGastosIndirectos(txtPeriodo.Text,_tipoLx);
            f.Show();
        }

        private void btnCtacteClientes_Click(object sender, EventArgs e)
        {

        }

        private void btnCtaCteProveedores_Click(object sender, EventArgs e)
        {

        }

        private void btnDetalleCobranzas_Click(object sender, EventArgs e)
        {
            var f = new FrmCO36DetalleCobranzassPorCliente(txtPeriodo.Text, _tipoLx);
            f.Show();
        }

        private void btnImportacionAFIP_Click(object sender, EventArgs e)
        {
            var f = new FrmFI78ImportacionComprobantesAFIP();
            f.Show();
        }

        private void btnDetalleDirectos_Click(object sender, EventArgs e)
        {
            var f = new FrmCO37DetalleComprasDirectos(txtPeriodo.Text, _tipoLx);
            f.Show();
        }
    }
}
