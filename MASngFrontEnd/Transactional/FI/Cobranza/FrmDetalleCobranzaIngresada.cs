using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Network;
using Tecser.Business.Transactional.FI.Cobranza;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmDetalleCobranzaIngresada : Form
    {
        public FrmDetalleCobranzaIngresada(int idCobranza)
        {
            _idCobranza = idCobranza;
            InitializeComponent();
        }

        private readonly int _idCobranza;
        private int _idCliente;
        private void FrmDetalleCobranzaIngresada_Load(object sender, EventArgs e)
        {
            t0206COBRANZAIBindingSource.DataSource = new CobranzaSearch().GetItemsFromCobranza(_idCobranza);
            LoadHeaderData();
        }

        private void LoadHeaderData()
        {
            var cobH = new CobranzaSearch().GetCobranzaHeader(_idCobranza);
            var cli = new CustomerManager().GetCustomerBillToData(cobH.IdCliente.Value);
            var ctacte = new CobranzaUtils().GetT0201FromCobranza(_idCobranza);
            if (ctacte != null)
            {
                txtMontoPendienteImputacion.Text = Math.Abs(ctacte.SALDOFACTURA).ToString("C2");
                if (ctacte.SALDOFACTURA == 0)
                {
                    ckCobranzaImputada.Checked = true;
                    ckCobranzaImputada.BackColor = Color.GreenYellow;
                    btnImputarCobranza.Enabled = false;
                    btnImputarAutomatico.Enabled = false;
                    txtMontoPendienteImputacion.BackColor = Color.GreenYellow;
                }
                else
                {
                    ckCobranzaImputada.Checked = false;
                    ckCobranzaImputada.BackColor = Color.Orange;
                    btnImputarCobranza.Enabled = true;
                    btnImputarAutomatico.Enabled = true;
                    txtMontoPendienteImputacion.BackColor = Color.Orange;
                }
            }
            else
            {
                ckCobranzaImputada.BackColor = Color.Pink;
                txtMontoPendienteImputacion.Text = @"Error!";
            }
            txtRazonSocial.Text = cli.cli_rsocial;
            txtFantasia.Text = cli.cli_fantasia;
            _idCliente = cli.IDCLIENTE;
            txtId6.Text = cli.IDCLIENTE.ToString();
            txtIdCob.Text = _idCobranza.ToString();
            txtFecha.Text = cobH.FECHA.ToString("d");
            txtImporte.Text = cobH.Monto.ToString("C2");
            txtMoneda.Text = cobH.MON;
            txtReciboInterno.Text = cobH.NRECIBO;
            txtReciboOficial.Text = cobH.NRECIBOOFI;
            txtComentario.Text = cobH.ReciboDesc;
            txtLx.Text = cobH.CUENTA;
            txtDiasPP.Text = cobH.DIAS_PP.ToString();
            txtLogDate.Text = cobH.LogDate.ToString("g");
            txtLogUser.Text = cobH.LogUser.ToString();
            ckCancel.Checked = cobH.DOC_CANCELADO;
            if (ckCancel.Checked)
                ckCancel.BackColor = Color.Red;

            txtNombreRecibo.Text = (txtRazonSocial.Text.Trim()) + @"-" + txtReciboOficial.Text + @".pdf";
            txtEmailCobranza.Text = cli.EMAIL_COBR;
            try
            {
                txtNombreRecibo.BackColor = System.IO.File.Exists(txtNombreRecibo.Text) ? Color.GreenYellow : Color.Orange;
            }
            catch (Exception)
            {

                throw new Exception("error en archivo");
            }


        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"La Funcion de Cancelar una Cobranza no está disponible", @"Funcion no Disponible",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            string body = "<p>Estimado Cliente, enviamos adjunto el <b> recibo oficial </b> de su pago.<p> <p>Muchas Gracias <p><p> Mombelli e Hijos SRL<p>";

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.SendCompleted += new System.Net.Mail.SendCompletedEventHandler(client_SendCompleted);

            var nombreCliente = txtRazonSocial.Text.Truncate(20);
            string direccionEnviarA = null;
            direccionEnviarA = "amombelli@gmail.com";
            //direccionEnviarA = txtEmailCobranza.Text;
            MessageBox.Show($@"El mail se esta enviando a :{direccionEnviarA}");
            new EmailManager().SendEmail(direccionEnviarA, nombreCliente, "tecsermasterbatch.app@gmail.com", "Tecser Masterbatch", null, null, "Recibo de Pago", body,
                false, "ventas@mombellisrl.com.ar", txtNombreRecibo.Text);
        }
        void client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
                MessageBox.Show(@"Successful");
            else
                MessageBox.Show(@"Error: " + e.Error.ToString());
        }
        private void btnGenerarPdf_Click(object sender, EventArgs e)
        {
            var f = new RpvReciboCobranzaOficial(_idCobranza, true);
            f.Show();
        }
        private void btnVerImprimir_Click(object sender, EventArgs e)
        {
            var f = new RpvReciboCobranzaOficial(_idCobranza, false, true);
            f.Show();
        }
        private void btnImputarCobranza_Click(object sender, EventArgs e)
        {
            var f0 = new FrmImputacionCobranzas(_idCliente);
            f0.Show();
        }

        private void btnImputarAutomatico_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (!new CobranzaImputacion().ImputaCobranzaAutomatica(_idCobranza, ModoImputacion.Completa) == false)
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

        }

        private void btnVerDetalleImputacion_Click(object sender, EventArgs e)
        {
            var f0 = new FrmFi103DetalleImpuXRecibo(_idCobranza);
            f0.ShowDialog();
        }

        private void btnRecalculoDiasPP_Click(object sender, EventArgs e)
        {
            var diaPP = new CobranzaUtils().CalculoDiasPromedioPago(_idCobranza);
            var pregunta = MessageBox.Show($"Nuevos DiasPP Calculados=  {diaPP}. Guardamos estos valores en la Tabla?",
                @"Recalculo DiasPP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pregunta == DialogResult.Yes)
            {
                new CobranzaUtils().GuardaDiasPP_TCobranza(_idCobranza, diaPP);
            }
        }
    }
}
