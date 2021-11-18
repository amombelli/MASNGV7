using System;
using System.ComponentModel;
using System.Windows.Forms;
using MASngFE.Transactional.CO.Asiento;
using Tecser.Business.DataFix;
using Tecser.Business.Tools;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;
using Tecser.Business.Transactional.FI;
using TSControls;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCo31VendorClosing : Form
    {
        public FrmCo31VendorClosing(int modo = 0)
        {
            InitializeComponent();
            ckL1.Checked = true;
        }

        //-------------------------------------------------------------------------------------------------
        private string _tipoLx;
        private VendorConcil _vc;
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
                toolTip1.Show("The data you supplied must be a valid date in the format mm/dd/yyyy.", txtPeriodo, 0,
                    -20,
                    5000);
            }
            else
            {
                //Now that the type has passed basic type validation, enforce more specific type rules.
                DateTime userDate = (DateTime) e.ReturnValue;
                if (userDate < DateTime.Now)
                {
                    toolTip1.ToolTipTitle = "Invalid Date";
                    toolTip1.Show("The date in this field must be greater than today's date.", txtPeriodo, 0, -20,
                        5000);
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
        //
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnRun_Click(object sender, EventArgs e)
        {
            _vc=new VendorConcil(txtPeriodo.Text,_tipoLx);

            //** Conciliacion A/P
            var Ap = _vc.ConciliaAP();
            if (Ap.ResultadoOK)
            {
                cIconoA0.Set = CIconos.Verde;
            }
            else
            {
                cIconoA0.Set = CIconos.Equis;
            }
            txtAp203.Text = Ap.Saldo203.ToString("C2");
            txtAp204.Text = Ap.Saldo204.ToString("C2");
            // falta ... Visaulizar saldos finales de proveedores 
            //----

            //** A1 Documentos Registrados
            var a1 = _vc.ConciliaDocConta();
            if (a1.ConcialiacionOK)
            {
                cIconoA1.Set = CIconos.Verde;
                btnResolverA1.Enabled = false;
            }
            else
            {
                cIconoA1.Set = CIconos.Equis;
                btnResolverA1.Enabled = true;
            }

            txtA1DocumentosIngresados.Text = a1.Importe403.ToString("C2");
            txtA1SaldoPendPago.Text = a1.SaldoPendientePago.ToString("C2");

            //**A2 Pagos y Egresos Realizados
            var a2 = _vc.ConciliaPagos();
            if (a2.ConciliacionOk)
            {
                cIconoA2.Set = CIconos.Verde;
            }
            else
            {
                cIconoA2.Set = CIconos.Equis;
            }

            txtA2PagoGenerado.Text = a2.PagosEmitidos.ToString("C2");
            txtB2EgresoPeriodo.Text = a2.PagosRealizados.ToString("C2");
            txtC2EmisionCheques.Text = a2.ChequesEmitidos.ToString("C2");
            txtC21EmitidoAcreditado.Text = a2.ChequesPeriodoAcreditados.ToString("C2");
            txtC22EmitidoNoAcreditado.Text = a2.ChequesPeriodoNoAcreditado.ToString("C2");
            txtD2AcreditadoDiferido.Text = a2.AcreditacionDiferida.ToString("C2");
            if (a2.ChequesEmitidos == (a2.ChequesPeriodoAcreditados + a2.ChequesPeriodoNoAcreditado))
            {
                ciconoc22.Set = CIconos.LamparitaGreen;
            }
            else
            {
                ciconoc22.Set = CIconos.Equis;
            }
            return;
            
        }

        private void btnVerAsiento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroAsiento.Text))
                return;

            var f = new FrmAsientoContableDetalle(Convert.ToInt32(txtNumeroAsiento.Text));
            f.Show();
        }

        
        private void txtFacturasIngresadasT203_DoubleClick(object sender, EventArgs e)
        {

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

        private void txtEgresosOPX_PD_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new GestionChequesEmitidos().Fix00();
            //new GestionChequesEmitidos().fixdataErrorFecha();
        }

        private void btn2A_Click(object sender, EventArgs e)
        {
            using (var f = new FrmCo34DetallesEgresosReg(txtPeriodo.Text, _tipoLx))
            {
                f.ShowDialog();
            }
        }

        private void btnConciliacionEgresos_Click(object sender, EventArgs e)
        {
            using (var f = new FrmCo37ConciliaEgresos(txtPeriodo.Text, _tipoLx))
            {
                f.ShowDialog();
            }
        }

        private void btnResolverA1_Click(object sender, EventArgs e)
        {
            //boton para resolver conflicto de documentos registrados
            //ver saldo docregistrado203 vs. docregistrado403.
        }

        private void btnDocumentosRegistrados_Click(object sender, EventArgs e)
        {
            using (var f = new FrmDetalle403(txtPeriodo.Text, _tipoLx))
            {
                f.ShowDialog();
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            var f = new FrmCo35ResumenPagosCtaCte(txtPeriodo.Text, _tipoLx);
            f.Show();
        }

        private void txtAp203_DoubleClick(object sender, EventArgs e)
        {
            using (var f = new FrmDetalle203(txtPeriodo.Text, _tipoLx))
            {
                f.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
