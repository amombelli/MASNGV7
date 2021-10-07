using System;
using System.Windows.Forms;
using Tecser.Business.DataFix;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.GestionCheques
{
    public partial class FrmFI55GestionChequeDetalle : Form
    {
        public FrmFI55GestionChequeDetalle(int idCheque)
        {
            _idCheque = idCheque;
            InitializeComponent();
        }

        private readonly int _idCheque;
        private int idCtaCte;
        private int idCliente;
        private int idT400;


        private void FrmFI55GestionChequeDetalle_Load(object sender, EventArgs e)
        {
            BsPersonal.DataSource = new HumanResourcesManager().GetListAllActiveCobrador();
            var datosCh = new ChequesManager().GetCheque(_idCheque);
            txtBanco.Text = datosCh.T0160_BANCOS.BCO_SHORTDESC;
            txtNumeroCheque.Text = datosCh.CHE_NUMERO;
            txtFechaAcreditacion.Text = datosCh.CHE_FECHA.ToString("d");
            txtImporte.Text = datosCh.IMPORTE.Value.ToString("C2");

            var datosRech = new ChequeRechazadoManager().GetRegistroChequeRech(_idCheque);
            txtFechaRechazo.Text = datosRech.FECHA_RE.Value.ToString("d");
            txtMotivoRechazo.Text = datosRech.MOTIVO_RE;
            idCliente = datosRech.IDCLIENTE;
            var datosCli = new CustomerManager().GetCustomerBillToData(idCliente);
            txtClienteRazonSocial.Text = datosCli.cli_rsocial;
            txtFechaRecibido.Text = datosCh.FECHA_RECIBIDO.ToString("d");
            // Difference in days, hours, and minutes.
            TimeSpan ts = datosRech.FECHA_RE.Value - datosCh.FECHA_RECIBIDO;
            int differenceInDays = ts.Days;
            txtDiasBicicleta.Text = (differenceInDays.ToString("N"));

            if (datosRech.IdNCT400 == 0)
            {
                idT400 = 0;
                idCtaCte = 0;
            }
            else
            {
                idT400 = datosRech.IdNCT400;
                var datosT400 = new CustomerInvoice("CHR2", datosRech.IdNCT400).GetHeaderData();
                txtTdoc.Text = datosT400.TIPO_DOC;
                if (datosT400.TIPOFACT == "L1")
                {
                    txtNumeroDoc.Text = datosT400.PV_AFIP + @"-" + datosT400.ND_AFIP;
                }
                else
                {
                    txtNumeroDoc.Text = datosT400.Remito;
                }
                txtFechaNd.Text = datosT400.FECHA.ToString("d");
                txtImpoteNd.Text = datosT400.TotalFacturaN.ToString("C2");
                int idCtaCte = datosT400.IdCtaCte.Value;
                txtImporteSaldoNd.Text =
                    new CtaCteCustomer(idCliente).GetRegistro201(idCtaCte).SALDOFACTURA.ToString("C2");
                ts = datosT400.FECHA - datosRech.FECHA_RE.Value;
                differenceInDays = ts.Days;
                txtDiasInactivos.Text = (differenceInDays.ToString("N"));
            }

            if (datosRech.ChequeEntregado == false)
            {
                ctlEntregado.Value = false;
                cmbEntregadoPor.SelectedIndex = -1;
                ctlFechaEntrega.Value = null;
                ts = datosRech.FECHA_RE.Value - DateTime.Today;
                txtDiasDemoraEntrega.Text = ts.Days.ToString("N");
                //
                btnSetEntregado.Enabled = true;
                btnUnsetEntrega.Enabled = false;
            }
            else
            {
                ctlEntregado.Value = true;
                ctlFechaEntrega.Value = datosRech.FechaEntregado.Value;
                cmbEntregadoPor.SelectedValue = datosRech.EntregadoPor;

                TimeSpan ts1 = datosRech.FECHA_RE.Value - datosRech.FechaEntregado.Value;
                differenceInDays = ts1.Days;
                txtDiasDemoraEntrega.Text = (differenceInDays.ToString("N"));
                //
                btnSetEntregado.Enabled = false;
                btnUnsetEntrega.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnSetEntregado_Click(object sender, EventArgs e)
        {
            if (ctlFechaEntrega.Value == null)
            {
                MessageBox.Show(@"Debe completar la fecha de entrega del cheque", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (ctlFechaEntrega.Value > DateTime.Today.AddDays(1))
            {
                MessageBox.Show(@"La fecha de entrega del cheque es incorrecta", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (ctlFechaEntrega.Value < DateTime.Today.AddDays(-3))
            {
                MessageBox.Show(@"La fecha de entrega del cheque es incorrecta", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (cmbEntregadoPor.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe completar el nombre de quien entrego el cheque", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            var resp = MessageBox.Show(@"Confirma la Entrega del Cheque al Cliente?", @"Confirmacion de Entrega",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;
            new ChequeRechazadoManager().SetRechazoEntregado(_idCheque, ctlFechaEntrega.Value.Value, cmbEntregadoPor.SelectedValue.ToString());
            btnSetEntregado.Enabled = false;
            btnUnsetEntrega.Enabled = true;
            ctlEntregado.Value = true;
        }

        private void btnUnsetEntrega_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(@"Confirma la NO-Entrega del Cheque al Cliente?", @"Confirmacion de Entrega",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;
            new ChequeRechazadoManager().UnSetRechazoEntregado(_idCheque);
            btnSetEntregado.Enabled = true;
            btnUnsetEntrega.Enabled = false;
            ctlEntregado.Value = false;

        }

        private void btnFixID400_Click(object sender, EventArgs e)
        {
            new FixCompletaIdT400EnTablaCheRechazado().AFixCompletaIdT400EnTablaCheRechazado(_idCheque);
            FrmFI55GestionChequeDetalle_Load(sender, e);

        }
    }
}