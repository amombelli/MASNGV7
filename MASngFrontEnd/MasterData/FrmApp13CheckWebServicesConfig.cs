using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.TOOLS;
using Tecser.Business.VBTools;
using Tecser.Business.WebServices;
using WebServicesAFIP;

namespace MASngFE.MasterData
{
    public partial class FrmApp13CheckWebServicesConfig : Form
    {

        public string CuitConsultar { get; set; }

        public FrmApp13CheckWebServicesConfig()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------
        private ModoEjecucion _entorno;
        //-----------------------------------------------------------------------------------------

        private void frmDatosPadronAFIP_Load(object sender, EventArgs e)
        {
            ckTesteo.Checked = true;
            _entorno = ModoEjecucion.Testeo;

            txtPeriodo.Text = new PeriodoConversion().GetPeriodo(DateTime.Today);
        }
        private void ConexionAfip(string cuitConsultar = "30709669091")
        {
            var modo = ModoEjecucion.Produccion;
            if (ckTesteo.Checked)
                modo = ModoEjecucion.Testeo;

            var cn = new PadronAfipWsA5(modo).ObtieneDatosPadronA5(cuitConsultar);
            txtRazonSocial1.Text = cn.Denominacion;

            if (cn.Estado != "ACTIVO")
            {
                MessageBox.Show(@"CUIT del cliente no se encuentra ACTIVO en la AFIP", @"CLIENTE INACTIVO",
                    MessageBoxButtons.OK);
                // ckContribuyenteActivo.Checked = false;
            }
            else
            {
                // ckContribuyenteActivo.Checked = true;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //cae

            //if (cmbTipoComprobante.SelectedItem.ToString() == null)
            //{
            //    MessageBox.Show(@"Seleccione el tipo de Comprobante");
            //    return;
            //}



            //var z = new FacturaElectronicaWs(ModoEjecucion.Produccion);
            //TipoComprobante tipoComprobante = TipoComprobante.Factura;
            //switch (cmbTipoComprobante.SelectedItem.ToString())
            //{
            //    case "FA":
            //        tipoComprobante = TipoComprobante.Factura;
            //        break;
            //    case "NC":
            //        tipoComprobante = TipoComprobante.NotaCredito;
            //        break;
            //    case "ND":
            //        tipoComprobante = TipoComprobante.NotaDebito;
            //        break;
            //}
            //var r = z.ObtieneDatosComprobanteAFIP(tipoComprobante, Convert.ToInt32(txtSuc.Text), Convert.ToInt32(txtDocumento.Text));

            //txtCae.Text = r.CAE;
            //txtCuit1.Text = r.DocNumero;
            ////txtVto.Text = r.VencimientoCAE.ToString("d");
            //txtImporte.Text = r.ImporteTotal.ToString("N2");
            //var padron = new PadronAfipWs(ModoEjecucion.Produccion).ObtenerDatosPadron(r.DocNumero);
            //txtRazonSocial.Text = padron.Denominacion;
            ////txtFechaComprobante.Text = r.FechaComprobante.ToString("d");
            ////txtIVA.Text = r.ImporteIva.ToString("n2");
            //if (r.TributosDetalle.Count > 0)
            //{
            //   // txtDescripcionTtributo.Text = r.TributosDetalle[0].Descripcion;
            //    //txtImporteTributo.Text = r.TributosDetalle[0].Importe;
            //}

            //var periodo = new PeriodoConversion().GetPeriodo(DateTime.Today);
            //var iibb = new PadronArba();
            //iibb.Conectar(txtCuit1.Text, new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(periodo),
            //    new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(periodo));

            //txtPercepcion.Text = iibb.AlPerc.ToString("P2");
            //txtRetencion.Text = iibb.AlRete.ToString("P2");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //iibb
        }

        private void ckTesteo_CheckedChanged(object sender, EventArgs e)
        {
            _entorno = ckTesteo.Checked ? ModoEjecucion.Testeo : ModoEjecucion.Produccion;
        }

        private void btnCheckPadron_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCUIT0.Text))
            {
                MessageBox.Show(@"Debe completar el CUIT para chequear el Padron AFIP", @"Check-Padron",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!new CuitValidation().ValidarCuit(txtCUIT0.Text))
            {
                MessageBox.Show(@"Debe Proveer un numero de CUIT Valido", @"Check-Padron",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var cn = new PadronAfipWsA5(_entorno).ObtieneDatosPadronA5(txtCUIT0.Text);

            //var cn = new PadronAfipWsA5(ModoEjecucion.Produccion).ObtenerDatosPadron(cuitConsultar);
            txtRazonSocial1.Text = cn.Denominacion;

            // var cn = new PadronAfipWsA5(_entorno).ObtenerDatosPadron(txtCUIT0.Text);
            txtRazonSocial1.Text = cn.Denominacion;
        }

        private void txtCUIT0_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!new CuitValidation().ValidarCuit(txtCUIT0.Text))
            {
                MessageBox.Show(@"Debe Proveer un numero de CUIT Valido", @"Check-Padron",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCUIT0.BackColor = Color.Orange;
                e.Cancel = true;
                return;
            }
            txtCUIT0.BackColor = Color.MediumSeaGreen;
        }
        private void btnConsultaCae_Click(object sender, EventArgs e)
        {
            if (cmbTipoComprobante.SelectedItem == null)
            {
                MessageBox.Show(@"Debe Proveer un numero de CUIT Valido", @"Check-Padron",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var z = new FacturaElectronicaWs(_entorno);
            var tipoComprobante = TipoComprobante.Factura;
            switch (cmbTipoComprobante.SelectedItem.ToString())
            {
                case "FA":
                    tipoComprobante = TipoComprobante.Factura;
                    break;
                case "NC":
                    tipoComprobante = TipoComprobante.NotaCredito;
                    break;
                case "ND":
                    tipoComprobante = TipoComprobante.NotaDebito;
                    break;
                default:
                    MessageBox.Show(@"El Tipo de Comprobante es incorrecto!", @"Tipo de Comprobante Erroneo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            var r = z.ObtieneDatosComprobanteAFIP(tipoComprobante, Convert.ToInt32(txtSuc.Text), Convert.ToInt32(txtDocumento.Text));

            txtCae.Text = r.CAE;
            txtCuit1.Text = r.DocNumero;
            txtFechaComprobante.Text = r.FechaComprobante.ToString("d");

            //txtVto.Text = r.VencimientoCAE.ToString("d");
            txtImporte.Text = r.ImporteTotal.ToString("N2");
            var cn = new PadronAfipWsA5(_entorno).ObtieneDatosPadronA5(txtCuit1.Text);
            txtRazonSocial.Text = cn.Denominacion;
            //var cn = new PadronAfipWsA5(ModoEjecucion.Produccion).ObtenerDatosPadron(cuitConsultar);
            //txtRazonSocial1.Text = cn.Denominacion;

            //var padron = new PadronAfipWs(ModoEjecucion.Produccion).ObtenerDatosPadron(r.DocNumero);
            //txtRazonSocial.Text = padron.Denominacion;
            ////txtFechaComprobante.Text = r.FechaComprobante.ToString("d");
            ////txtIVA.Text = r.ImporteIva.ToString("n2");
            //if (r.TributosDetalle.Count > 0)
            //{
            //    // txtDescripcionTtributo.Text = r.TributosDetalle[0].Descripcion;
            //    //txtImporteTributo.Text = r.TributosDetalle[0].Importe;
            //}

            var periodo = new PeriodoConversion().GetPeriodo(DateTime.Today);
            var iibb = new PadronArba();
            iibb.Conectar(txtCuit1.Text, new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(periodo),
                new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(periodo));

            txtPercepcion.Text = iibb.AlPerc.ToString("P2");
            txtRetencion.Text = iibb.AlRete.ToString("P2");
        }

        private void btnConsultaIIBB_Click(object sender, EventArgs e)
        {
            //var periodo = new PeriodoConversion().GetPeriodo(DateTime.Today);

            if (string.IsNullOrEmpty(txtCuit2.Text))
            {
                MessageBox.Show(@"Debe completar el CUIT para chequear el Padron ARBA", @"Check-Padron",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!new CuitValidation().ValidarCuit(txtCuit2.Text))
            {
                MessageBox.Show(@"Debe Proveer un numero de CUIT ARBA", @"Check-Padron",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var iibb = new PadronArba();
            iibb.Conectar(txtCuit2.Text, new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(txtPeriodo.Text),
                new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(txtPeriodo.Text));

            txtPercepcion.Text = iibb.AlPerc.ToString("P2");
            txtRetencion.Text = iibb.AlRete.ToString("P2");
        }

        private void txtCuit2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!new CuitValidation().ValidarCuit(txtCuit2.Text))
            {
                MessageBox.Show(@"Debe Proveer un numero de CUIT Valido", @"Check-Padron",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCuit2.BackColor = Color.Orange;
                e.Cancel = true;
                return;
            }
            txtCuit2.BackColor = Color.MediumSeaGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
