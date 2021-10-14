using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmCustomerNcdMain : Form
    {
        public FrmCustomerNcdMain(int modo = 0)
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------
        private int? _idCliente = null;
        private string _tipoLx;
        private ManageDocumentType.TipoDocumento _tipoDocumento;
        private string _indicador;
        //-------------------------------------------------------------------------------------------------------------

        private void FrmCustomerNCDMain_Load(object sender, EventArgs e)
        {
            InicializaForm();
        }
        private void InicializaForm()
        {
            t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            txtCuit.Text = null;
            txtSaldoL1.Text = 0.ToString("C2");
            txtSaldoTotal.Text = 0.ToString("C2");
            txtSaldoL2.Text = 0.ToString("C2");
            btnNewDocument.Enabled = false;
            grpMotivoNotaCredito.Visible = false;
            grpMotivoNotaDebito.Visible = false;
            grpMotivoAjuste.Visible = false;
            grpTipoDocumento.Visible = false;
            grpTipoLx.Focus();
        }
        private bool HabilitaBotonContinuar()
        {
            if (_idCliente != null)
            {
                return true;
            }
            return false;
        }

        #region seleccion de Checkbox

        private void rbTipoL1_CheckedChanged(object sender, EventArgs e)
        {
            _tipoLx = rbTipoL1.Checked ? "L1" : "L2";
            grpTipoDocumento.Visible = true;
        }
        private void rbNC_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = grpTipoDocumento.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);

            grpMotivoAjuste.Visible = false;
            grpMotivoNotaCredito.Visible = false;
            grpMotivoNotaDebito.Visible = false;

            if (checkedButton == null)
            {
                btnNewDocument.Enabled = false;
                return;
            }

            switch (checkedButton.Name)
            {
                case "rbNC":
                    grpMotivoNotaCredito.Visible = true;

                    var ckNc = grpMotivoNotaCredito.Controls.OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);

                    btnNewDocument.Enabled = ckNc != null && HabilitaBotonContinuar();
                    _tipoDocumento = _tipoLx == "L1"
                        ? ManageDocumentType.TipoDocumento.NotaCreditoVentaA
                        : ManageDocumentType.TipoDocumento.NotaCreditoVenta2;

                    break;
                case "rbND":
                    grpMotivoNotaDebito.Visible = true;

                    var ckNd = grpMotivoNotaDebito.Controls.OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);

                    btnNewDocument.Enabled = ckNd != null && HabilitaBotonContinuar();
                    _tipoDocumento = _tipoLx == "L1"
                        ? ManageDocumentType.TipoDocumento.NotaDebitoVentaA
                        : ManageDocumentType.TipoDocumento.NotaDebitoVenta2;

                    break;
                case "rbAI":
                    grpMotivoAjuste.Visible = true;
                    var ckAi = grpMotivoNotaDebito.Controls.OfType<RadioButton>()
                        .FirstOrDefault(r => r.Checked);
                    btnNewDocument.Enabled = false;
                    btnNewDocument.Enabled = ckAi != null && HabilitaBotonContinuar();
                    break;
                default:
                    break;
            }
        }

        //MOTIVOS DE NOTA DE DEBITO
        private void rbchr_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = grpMotivoNotaDebito.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            //var customer = new Customers();
            switch (checkedButton.Name)
            {
                case "rbchr":
                    _indicador = "CHR";
                    break;
                case "rbdifcambio":
                    _indicador = "NDDIFTC";
                    break;
                case "rbdifprecio":

                    break;
                case "rbkgfactu":
                    break;
                case "rbndotro":
                    _indicador = "NDOTRO";
                    break;

                default:
                    break;
            }

            var ckMnd = grpMotivoNotaDebito.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            btnNewDocument.Enabled = ckMnd != null && HabilitaBotonContinuar();
        }

        //MOTIVOS DE NOTA DE CREDITO
        private void rbncotro_CheckedChanged(object sender, EventArgs e)
        {

            var checkedButton = grpMotivoNotaCredito.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            //var customer = new Customers();
            if (checkedButton == null)
                return;

            switch (checkedButton.Name)
            {
                case "rbncanulafactu":
                    _indicador = "AFACTU";
                    break;
                case "rbncdifcambio":
                    _indicador = "DIFTCNC";
                    break;
                case "rbncdifprecio":
                    _indicador = "DIFPRNC";
                    break;
                case "rbncdifkg":
                    _indicador = "DEVKG";
                    break;
                case "rbncDtoGralVta":
                    _indicador = "DTOGRALVTA";
                    break;
                case "rbncotro":
                    break;

                default:
                    break;
            }

            var ckMnc = grpMotivoNotaCredito.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            btnNewDocument.Enabled = ckMnc != null && HabilitaBotonContinuar();
        }

        #endregion

        #region Botones
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevoDocumento_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                txtIdCliente.Text = null;
                txtSaldoL1.Text = 0.ToString("C2");
                txtSaldoL2.Text = 0.ToString("C2");
                txtSaldoTotal.Text = 0.ToString("C2");
                txtSaldoL1.BackColor = Color.Wheat;
                txtSaldoL2.BackColor = Color.Wheat;
                txtSaldoTotal.BackColor = Color.Wheat;
                _idCliente = null;
                return;
            }

            _idCliente = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            txtIdCliente.Text = cmbRazonSocial.SelectedValue.ToString();
            var saldo = new CtaCteCustomer(Convert.ToInt32(cmbRazonSocial.SelectedValue));
            var resultadoL1 = saldo.GetResultadoCtaCte("L1");
            txtSaldoL1.Text = resultadoL1.SaldoDetalle.ToString("C2");
            txtSaldoL1.BackColor = resultadoL1.SaldoColor;

            var resultadoL2 = saldo.GetResultadoCtaCte("L2");
            txtSaldoL2.Text = resultadoL2.SaldoDetalle.ToString("C2");
            txtSaldoL2.BackColor = resultadoL2.SaldoColor;

            var resultadoTotal = (resultadoL1.SaldoDetalle + resultadoL2.SaldoDetalle);
            txtSaldoTotal.Text = resultadoTotal.ToString("C2");
            txtSaldoTotal.BackColor = resultadoTotal > 0 ? Color.ForestGreen : Color.DarkGray;

        }
        private void cmbRazonSocial_Leave(object sender, EventArgs e)
        {
            var control = (ComboBox)sender;
            if (string.IsNullOrEmpty(control.Text))
            {
                cmbRazonSocial.SelectedIndex = -1;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewDocument_Click(object sender, EventArgs e)
        {
            if (rbAI.Checked)
            {
                if (rbTraspaso.Checked)
                {
                    var f = new FrmFI40AjusteSaldoCliente(_idCliente.Value, 1);
                    f.Show();
                }
                else
                {
                    //Ajustes de Saldo
                    var f = new FrmFI66NCDAjustes(_idCliente.Value, _tipoLx, _indicador);
                    f.Show();
                }
            }
            else
            {
                //var f = new FrmFi52NotaCreditoDebitoCliente(_idCliente.Value, _tipoLx, _tipoDocumento, _indicador);
                //f.Show();
            }
        }

        private void cmbRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbRazonSocial);
        }

        private void cmbFantasia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbFantasia);
        }

        private void rbAjusteMas_CheckedChanged(object sender, EventArgs e)
        {
            //al seleciconar motivos de ajuste (todos)
            var checkedButton = grpMotivoAjuste.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            //var customer = new Customers();
            if (checkedButton == null)
                return;

            switch (checkedButton.Name)
            {
                case "rbAjusteRedondeo":
                    _indicador = "AJ";
                    break;
                case "rbAjusteDeudasPerdidas":
                    _indicador = "AP";
                    break;
                case "rbAjusteIncobrablesConCobranza":
                    _indicador = "AI";
                    break;
                case "rbTraspaso":
                    _indicador = "AT";
                    break;
                default:
                    break;
            }

            var ckMnc = grpMotivoAjuste.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            btnNewDocument.Enabled = ckMnc != null && HabilitaBotonContinuar();
        }
    }

}
