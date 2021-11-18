using System;
using System.ComponentModel;
using System.Windows.Forms;
using MASngFE.Transactional.CO.Asiento;
using Tecser.Business.DataFix;
using Tecser.Business.Tools;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;
using TSControls;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCo31VendorClosing : Form
    {
        public FrmCo31VendorClosing(int modo = 0)
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------
        private string _tipoLx;
        //-------------------------------------------------------------------------------------------------


        private void FrmCierreProveedores_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtPeriodo.Text = new PeriodoConversion().GetPeriodo(Convert.ToDateTime(txtFecha.Text));
            txtFechaDesde.Text = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text).ToShortDateString();
            txtFechaHasta.Text = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text).ToShortDateString();
            ckL1.Checked = true;
            ckL2.Checked = false;

 
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
        private void ckL1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL1.Checked)
            {
                _tipoLx = ckL2.Checked ? "L3" : "L1";
            }
            else
            {
                _tipoLx = ckL2.Checked ? "L2" : "L0";
            }
        }
        private void ckL2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL2.Checked)
            {
                _tipoLx = ckL1.Checked ? "L3" : "L2";
            }
            else
            {
                _tipoLx = ckL1.Checked ? "L1" : "L0";
            }
        }
        private void txtPeriodo_Validating(object sender, CancelEventArgs e)
        {
            txtFechaDesde.Text = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text).ToString("d");
            txtFechaHasta.Text = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text).ToString("d");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (_tipoLx == "L0")
            {
                MessageBox.Show(@"Debe completar L1/L2 para continuar", @"Error en LX", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
           

            var rtn = new VendorConcil().ConciliacionGeneralResumen(txtPeriodo.Text, _tipoLx);

            if (rtn.SaldoVendorOK)
            {
               // pConciliacionGreen.Visible = true;
            }
            else
            {
                //pConciliacionRed.Visible = true;
            }

            txtConcilSaldoT203.Text = rtn.SAldo203Final.ToString("C2");
            txtConcilSaldoT204.Text = rtn.Saldo204Final.ToString("C2");
            cSem203_204.SetLights = rtn.SAldo203Final - rtn.Saldo204Final == 0
                ? CtlSemaforo.ColoresSemaforo.Verde
                : CtlSemaforo.ColoresSemaforo.Rojo;


            txtFacturasIngresadasT403.Text = rtn.ImporteIngresosDocumentos403.ToString("C2");
            txtFacturasIngresadasT203.Text = rtn.ImporteIngresosDocumentos203.ToString("C2");
            cSem403_203.SetLights = rtn.ImporteIngresosDocumentos403 - rtn.ImporteIngresosDocumentos203 == 0
                ? CtlSemaforo.ColoresSemaforo.Verde
                : CtlSemaforo.ColoresSemaforo.Rojo;


            txtEgresosReg.Text = rtn.ImporteEgresosREG.ToString("C2");
            txtEgresosOPX_PD.Text = rtn.ImportePagosPdOpx.ToString("C2");

            cSemRegOPx.SetLights = rtn.ImporteEgresosREG - rtn.ImportePagosPdOpx == 0
                ? CtlSemaforo.ColoresSemaforo.Verde
                : CtlSemaforo.ColoresSemaforo.Rojo;



            MessageBox.Show(@"Fin del Proceso", @"Fin", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnVerAsiento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroAsiento.Text))
                return;

            var f = new FrmAsientoContableDetalle(Convert.ToInt32(txtNumeroAsiento.Text));
            f.Show();
        }

        private void txtFacturasIngresadasT403_DoubleClick(object sender, EventArgs e)
        {
            using (var f = new FrmDetalle403(txtPeriodo.Text, _tipoLx))
            {
                f.ShowDialog();
            }
        }



        private void txtFacturasIngresadasT203_DoubleClick(object sender, EventArgs e)
        {
            using (var f = new FrmDetalle203(txtPeriodo.Text, _tipoLx))
            {
                f.ShowDialog();
            }
        }

        private void btnSaldosCuentaCorriente_Click(object sender, EventArgs e)
        {
            var f = new FrmCO14SaldosAP(txtPeriodo.Text, _tipoLx);
            f.Show();
        }

        private void txtEgresosReg_DoubleClick(object sender, EventArgs e)
        {
            var f = new FrmCo34DetallesEgresosReg(txtPeriodo.Text, _tipoLx);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FixOrdenPagoModelo2019().FixPdOPSignoErrado();
        }

        private void txtTotalesOPXPD_DoubleClick(object sender, EventArgs e)
        {
            var f = new FrmCo35ResumenPagosCtaCte(txtPeriodo.Text, _tipoLx);
            f.Show();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            var f = new FrmCO13Conciliacion203204();
            f.Show();
        }


        private void btnConciliaDiferencias_Click(object sender, EventArgs e)
        {
            var f = new FrmCo36ConciliaDiferenciasEgresos(txtPeriodo.Text,_tipoLx);
            f.Show();
        }
    }
}
