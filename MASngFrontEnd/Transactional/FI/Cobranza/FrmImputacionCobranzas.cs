using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.DataFix;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmImputacionCobranzas : Form
    {
        public FrmImputacionCobranzas()
        {
            InitializeComponent();
            _clienteSeleccionado = 0;
        }

        public FrmImputacionCobranzas(int idCliente)
        {
            InitializeComponent();
            _clienteSeleccionado = idCliente;
            cmbRazonSocial.SelectedValue = idCliente;
        }

        private int _clienteSeleccionado;
        private void FrmImputacionCobranzas_Load(object sender, EventArgs e)
        {
            new FixIdCtaCteT400().AddCtaCteIdInT0400();
            new FixImputacionIssues().FixIdCtaCteT0208();
            LoadData();
        }
        private void LoadData()
        {
            if (_clienteSeleccionado == 0)
            {
                this.cmbRazonSocial.SelectedIndexChanged -=
                    new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
                this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);

                cmbFantasia.DataSource = new CustomerManager().GetCompleteListofBillTo();
                cmbRazonSocial.DataSource = cmbFantasia.DataSource;
                cmbFantasia.SelectedIndex = -1;
                cmbRazonSocial.SelectedIndex = -1;
                _clienteSeleccionado = 0;
                txtIdCliente.Text = null;
                cmbFantasia.Enabled = true;
                cmbRazonSocial.Enabled = true;
                txtIdCliente.ReadOnly = false;

                this.cmbRazonSocial.SelectedIndexChanged +=
                    new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
                this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            }
            else
            {
                var clienteData = new CustomerManager().GetCustomerBillToData(_clienteSeleccionado);
                cmbFantasia.Text = clienteData.cli_fantasia;
                cmbRazonSocial.Text = clienteData.cli_rsocial;
                txtIdCliente.Text = _clienteSeleccionado.ToString();
                cmbRazonSocial.Enabled = false;
                cmbFantasia.Enabled = false;
                txtIdCliente.ReadOnly = true;
                LoadCustomerData();
                GetCobranzaData();

            }
            btnImputar.Enabled = false;
        }

        private void GetCobranzaData()
        {
            dgvCobranzas.DataSource =
                new CobranzaImputacion().GetCobranzasPendientesImputacion(_clienteSeleccionado).OrderBy(c => c.FECHA).ToList();
            dgvDocumentosAImputar.DataSource =
                new CobranzaImputacion().GetDocumentosAImputar(_clienteSeleccionado).OrderBy(c => c.FECHA_FACT).ToList();
        }

        private void BlanqueaDatosFacturasPendientesImputacion()
        {
            txtTdocImpu.Text = null;
            txtNumDocImpu.Text = null;
            txtTipoLxImpu.Text = null;
            txtIdCtaCteImpu.Text = null;
            txtSplitImpu.Text = null;
            txtIdFactura.Text = null;
            txtIdFacturaX.Text = null;
            txtMontoOriginal.Text = 0.ToString("C2");
            txtImportePendienteImpu.Text = 0.ToString("C2");
            txtImportePercepcionImpu.Text = 0.ToString("C2");
            txtPercPendientePago.Text = 0.ToString("c2");
            lblImportePercepcion.Visible = false;
        }
        private void BlanqueaDatosCobranzasAImputar()
        {
            txtIdCobranzaSeleccionada.Text = null;
            txtTipoCobSeleccionada.Text = null;
            txtIdCtaCteCobranza.Text = null;
            txtIdCob.Text = null;
            txtImporteAImputarMaximo.Text = 0.ToString("C2");
            txtImporteAImputar.Text = 0.ToString("C2");
        }
        private void BlanqueaDatosCliente()
        {
            txtZtermL1.Text = @"N/D";
            txtZtermL2.Text = @"N/D";
            txtZtermL1Desc.Text = @"NO DISPONIBLE";
            txtZtermL2Desc.Text = @"NO DISPONIBLE";
            txtDeudaL1.Text = 0.ToString("C2");
            txtDeudaL1.BackColor = Color.LightYellow;
            txtDeudaL2.Text = 0.ToString("C2");
            txtDeudaL2.BackColor = Color.LightYellow;
            txtSinImputar.Text = 0.ToString("C2");

            txtImporteAImputar.Text = 0.ToString("C2");
            txtTipoCobSeleccionada.Text = null;
            txtIdCobranzaSeleccionada.Text = null;
            txtIdFactura.Text = null;
            txtIdFacturaX.Text = null;
            txtIdCtaCteImpu.Text = null;
            txtImporteAImputarMaximo.Text = 0.ToString("C2");
            txtImportePendienteImpu.Text = 0.ToString("C2");
            txtImportePercepcionImpu.Text = 0.ToString("C2");
            txtTdocImpu.Text = null;
            txtNumDocImpu.Text = null;
            txtSplitImpu.Text = null;
            txtTipoLxImpu.Text = null;
            txtMontoOriginal.Text = 0.ToString("C2");
            txtImportePendienteImpu.Text = 0.ToString("C2");
        }
        private void LoadCustomerData()
        {
            btnImputar.Enabled = false;
            var cli = new CustomerManager().GetCustomerBillToData(Convert.ToInt32(txtIdCliente.Text));
            if (cli == null)
            {
                BlanqueaDatosCliente();
                return;
            }

            txtZtermL1.Text = cli.ZTERML1;
            txtZtermL2.Text = cli.ZTERML2;
            txtZtermL1Desc.Text = new ZtermManager().GetDescripcionZTerm(cli.ZTERML1);
            txtZtermL2Desc.Text = new ZtermManager().GetDescripcionZTerm(cli.ZTERML2);

            var ctacte = new CtaCteCustomer(_clienteSeleccionado);
            var res = ctacte.GetResultadoCtaCte("L1");
            txtDeudaL1.Text = res.SaldoDetalle.ToString("C2");
            txtDeudaL1.BackColor = res.SaldoColor;

            var res2 = ctacte.GetResultadoCtaCte("L2");
            txtDeudaL2.Text = res2.SaldoDetalle.ToString("C2");
            txtDeudaL2.BackColor = res2.SaldoColor;

            txtSinImputar.Text = new CobranzaImputacion().GetSaldoAImputar208(_clienteSeleccionado).ToString("C2");
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedValue == null)
            {
                _clienteSeleccionado = 0;
                BlanqueaDatosCliente();
                GetCobranzaData();
                return;
            }

            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
            txtIdCliente.Text = cmbRazonSocial.SelectedValue.ToString();
            _clienteSeleccionado = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            BlanqueaDatosCliente();
            LoadCustomerData();
            this.dgvDocumentosAImputar.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosAImputar_CellEnter);
            this.dgvCobranzas.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);

            GetCobranzaData();
            dgvCobranzas.ClearSelection();
            dgvDocumentosAImputar.ClearSelection();

            this.dgvDocumentosAImputar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosAImputar_CellEnter);
            this.dgvCobranzas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);

        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFantasia.SelectedValue == null)
                return;

        }

        private void dgvCobranzas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            BlanqueaDatosCobranzasAImputar();
            BlanqueaDatosFacturasPendientesImputacion();
            txtIdCobranzaSeleccionada.Text = dgvCobranzas[dgvCobranzas.Columns["iDDataGridViewTextBoxColumn"].Index, e.RowIndex].Value.ToString();
            txtIdCtaCteCobranza.Text = dgvCobranzas[dgvCobranzas.Columns["iDctactecobranza"].Index, e.RowIndex].Value.ToString();
            txtIdCob.Text = dgvCobranzas[dgvCobranzas.Columns["iDRECIBODataGridViewTextBoxColumn"].Index, e.RowIndex].Value.ToString();
            var impMax = Convert.ToDecimal(dgvCobranzas[_montoCobranza.Name, e.RowIndex].Value);
            txtImporteAImputarMaximo.Text = impMax.ToString("C2");
            txtImporteAImputar.Text = impMax.ToString("C2");
            txtImporteAImputar.BackColor = Color.GreenYellow;

            txtTipoCobSeleccionada.Text = dgvCobranzas[dgvCobranzas.Columns["tIPOCUENTADataGridViewTextBoxColumn"].Index, e.RowIndex].Value.ToString();

            dgvDocumentosAImputar.DataSource = new CobranzaImputacion().GetDocumentosAImputar(_clienteSeleccionado,
                txtTipoCobSeleccionada.Text);


        }
        private void txtImporteAImputar_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtImporteAImputarMaximo_Leave(object sender, EventArgs e)
        {

        }
        private void txtImporteAImputar_Leave(object sender, EventArgs e)
        {
            var imp = FormatAndConversions.CCurrencyADecimal(txtImporteAImputar.Text);
            var impmax = FormatAndConversions.CCurrencyADecimal(txtImporteAImputarMaximo.Text);

            if (imp > impmax)
            {
                txtImporteAImputar.Text = impmax.ToString("C2");
                MessageBox.Show(@"Atencion se ha modificado el importe a imputar al valor maximo posible",
                    @"Importe a Imputar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImporteAImputar.BackColor = Color.Orange;
            }
            else
            {
                txtImporteAImputar.Text = imp.ToString("C2");
                txtImporteAImputar.BackColor = Color.GreenYellow;
            }
        }
        private void dgvDocumentosAImputar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblImportePercepcion.Visible = false;
            txtTdocImpu.Text =
                dgvDocumentosAImputar[dgvDocumentosAImputar.Columns["tDOCDataGridViewTextBoxColumn1"].Index, e.RowIndex].Value.ToString();
            txtNumDocImpu.Text =
                dgvDocumentosAImputar[dgvDocumentosAImputar.Columns["nDOCDataGridViewTextBoxColumn"].Index, e.RowIndex].Value.ToString();
            txtIdCtaCteImpu.Text =
                dgvDocumentosAImputar[dgvDocumentosAImputar.Columns["iDCTACTEDataGridViewTextBoxColumn1"].Index, e.RowIndex].Value.ToString();
            txtSplitImpu.Text =
                dgvDocumentosAImputar[dgvDocumentosAImputar.Columns["FACTSPLIT"].Index, e.RowIndex].Value.ToString();

            var importePendienteImpu = Convert.ToDecimal(dgvDocumentosAImputar[__MontoPendiente.Name, e.RowIndex].Value);
            txtImportePendienteImpu.Text = importePendienteImpu.ToString("C2");
            txtImportePercepcionImpu.Text = 0.ToString("C2");

            var importeOriginal = Convert.ToDecimal(dgvDocumentosAImputar[__MontoOriginal.Name, e.RowIndex].Value);
            txtMontoOriginal.Text = importeOriginal.ToString("C2");

            int idCtaCteSeleccionada = Convert.ToInt32(txtIdCtaCteImpu.Text);
            var doc400 = new TecserData(GlobalApp.CnnApp).T0400_FACTURA_H.SingleOrDefault(c => c.IdCtaCte == idCtaCteSeleccionada);
            if (doc400 != null)
            {
                txtTipoLxImpu.Text = doc400.TIPOFACT;
                txtImportePercepcionImpu.Text = doc400.TotalIIBB.ToString("C2");
                txtIdFactura.Text = doc400.IDFACTURA.ToString();

                if (doc400.IDFACTURAX == null)
                {
                    txtIdFacturaX.Text = @"0";
                }
                else
                {
                    txtIdFacturaX.Text = doc400.IDFACTURAX.ToString();
                }
                var pagado = importeOriginal - importePendienteImpu;
                if (pagado > doc400.TotalIIBB)
                {
                    txtPercPendientePago.Text = 0.ToString();
                    btnImputar.Enabled = true;
                }
                else
                {
                    txtPercPendientePago.Text = doc400.TotalIIBB.ToString("C2");
                    if (FormatAndConversions.CCurrencyADecimal(txtImporteAImputar.Text) > doc400.TotalIIBB)
                    {
                        btnImputar.Enabled = true;
                    }
                    else
                    {
                        lblImportePercepcion.Visible = true;
                        //MessageBox.Show(@"El importe a imputar debe ser mayor al importe de la percepccion ARBA IIBB", @"Imposible Imputar",
                        //MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnImputar.Enabled = false;
                    }
                }
            }
            else
            {
                if (txtTdocImpu.Text == @"AJ")
                {
                    btnImputar.Enabled = true;
                }
                else
                {
                    btnImputar.Enabled = false;
                    MessageBox.Show(@"El Documento no puede imputarse por un error de integridad.- No se encuentra el IdCtaCte en T0400", @"Error de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnImputar_Click(object sender, EventArgs e)
        {
            var impu = new CobranzaImputacion();
            if (!impu.ValidacionOKImputar(Convert.ToInt32(txtIdCtaCteImpu.Text), Convert.ToInt32(txtSplitImpu.Text), Convert.ToInt32(txtIdCobranzaSeleccionada.Text)))
            {
                MessageBox.Show(
                    @"Esta Imputacion no puede realizarse porque no se cumplen las condiciones minimas para realizarse",
                    @"Error en Imputacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            impu.ImputarCobranza(Convert.ToInt32(txtIdCtaCteImpu.Text), Convert.ToInt32(txtSplitImpu.Text),
                Convert.ToInt32(txtIdCobranzaSeleccionada.Text),
                FormatAndConversions.CCurrencyADecimal(txtImporteAImputar.Text));

           var z = new CobranzaUtils().DiasPromedioPagoFacturaImputada(Convert.ToInt32(txtIdCtaCteImpu.Text));

            if (z.ErrorDetectado)
            {
                MessageBox.Show(@"Ha Ocurrido un problema en el calculo de los dias de imputacion (Pero la cobranza ha sido Imputada)", @"Error detectado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (z.ImputacionCompleta == false)
                {
                    MessageBox.Show(
                        @"Hasta que el documento este completamente imputado no se calcula la estadistica de pagos",
                        @"No se han calculado los datos de Promedio/Pago/Imputacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        $@"Dias Imputacion [Fecha Factura A Fecha de Pago]= {z.DiasPP_FacturaRecibo} " + "\n" +
                        $@"Dias Promedio Cobranza [Dias PP Pago Recibo]= {z.DiasPP_ReciboPago}" + "\n" +
                        $@"Fecha Total de Pago [Fecha Factura - Promedio Pago]={z.DiasPP_FacturaRecibo + z.DiasPP_ReciboPago}",
                        @"Estadisticas de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //Actualizacion de Margen Data
            if (!string.IsNullOrEmpty(txtIdFactura.Text))
                new MargenDocument().UpdateStatusCobranza(Convert.ToInt32(txtIdFactura.Text));
            GetCobranzaData();

        }
        private void btnVerRecibo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCob.Text) == true)
            {
                MessageBox.Show(@"Debe Seleccionar UNA Cobranza para ver el RECIBO", @"Visualizacion de Recibo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var f0 = new FrmDetalleCobranzaIngresada(Convert.ToInt32(txtIdCob.Text));
            f0.Show();
        }
        private void txtIdCliente_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCliente.Text))
                return;

            {
                cmbRazonSocial.SelectedValue = Convert.ToInt32(txtIdCliente.Text);
            }
        }
        private void btnImputacionAutomatica_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCob.Text))
            {
                MessageBox.Show(@"Debe Seleccionar MANUALMENTE la Cobranza a Imputar (Izq)", @"Fallo en Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var idCob = Convert.ToInt32(txtIdCob.Text);
            int i = 0;
            while (!new CobranzaImputacion().ImputaCobranzaAutomatica(idCob, ModoImputacion.Completa) == false)
            {
                i++;
            }

            if (i > 0)
            {
                MessageBox.Show($"Se han imputado automaticamente {i} cobranzas", @"Cobranzas Automaticas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No Se han imputado cobranzas", @"Cobranzas Automaticas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            GetCobranzaData();


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
