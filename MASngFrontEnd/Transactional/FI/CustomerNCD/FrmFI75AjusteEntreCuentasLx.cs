using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using TSControls;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI75AjusteEntreCuentasLx : Form
    {
        private readonly CustomerAjustes _aj1;
        private readonly CustomerAjustes _aj2;
        private readonly DateTime _fechaDocumento;
        private readonly string _autorizado;
        private readonly int _idCliente;
        private string _lxOrigen;
        private string _lxDestino;
        public string MotivoDescripcionAjuste { get; private set; }
        public FrmFI75AjusteEntreCuentasLx(CustomerAjustes aj1, CustomerAjustes aj2, int idCliente, DateTime fechaDocumento, string autorizado)
        {
            _aj1 = aj1;
            _aj2 = aj2;
            _fechaDocumento = fechaDocumento;
            _autorizado = autorizado;
            _idCliente = idCliente;
            InitializeComponent();

            var cli = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtId6.Text = idCliente.ToString();
            txtRazonSocial.Text = cli.cli_rsocial;
            txtMotivo.Text = CustomerAjustes.MotivoAjustes.TraspasoTipo.ToString();
            txtTipoDocumento.Text = @"AJ";
            _lxOrigen = "L1";
        }

        private void FrmFI75AjusteEntreCuentasLx_Load(object sender, EventArgs e)
        {
            btnRedondeo.Enabled = false;
            cSaldoL1.SetValue = new CtaCteCustomer(_idCliente).GetResultadoCtaCte("L1").SaldoResumen;
            cSaldoL2.SetValue = new CtaCteCustomer(_idCliente).GetResultadoCtaCte("L2").SaldoResumen;

            if (_lxOrigen == "L1")
            {
                rbOrigenL1.Checked = true;
            }
            else
            {
                rbOrigenL2.Checked = true;
            }

        }

        private void rbOrigenL2_CheckedChanged(object sender, EventArgs e)
        {
            var y = (RadioButton)sender;
            if (y.Checked == false) return;
            if (rbOrigenL1.Checked)
            {
                rbDestinoL2.Checked = true;
                rbDestinoL1.Checked = false;
                cSaldoMax.SetValue = cSaldoL1.GetValueDecimal;
                _lxOrigen = "L1";
                _lxDestino = "L2";
            }
            else
            {
                rbDestinoL1.Checked = true;
                rbDestinoL2.Checked = false;
                cSaldoMax.SetValue = cSaldoL2.GetValueDecimal;
                _lxOrigen = "L2";
                _lxDestino = "L1";
            }
            txtLx.Text = _lxOrigen;

            cSaldoTraspaso.SetValue = 0;
            if (cSaldoMax.GetValueDecimal == 0)
            {
                MessageBox.Show($@"El Saldo Origen {0.ToString("C2")} no permite traspaso de Saldos",
                    @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ciconoImporte.Set = CIconos.ExclamacionOrange;
                cSaldoTraspaso.XReadOnly = true;
            }
            else
            {
                ciconoImporte.Set = CIconos.LamparitaGreen;
                cSaldoTraspaso.XReadOnly = false;
                if (cSaldoMax.GetValueDecimal < 0)
                {
                    cSaldoTraspaso.ValorMaximo = 0;
                    cSaldoTraspaso.ValorMinimo = cSaldoMax.GetValueDecimal;
                }
                else
                {
                    cSaldoTraspaso.ValorMinimo = 0;
                    cSaldoTraspaso.ValorMaximo = cSaldoMax.GetValueDecimal;
                }
            }
        }

        private void cSaldoTraspaso_Validated(object sender, EventArgs e)
        {
            //ciconoImporte.Set = CIconos.Tilde;
            //btnRedondeo.Enabled = true;

        }

        private void cSaldoTraspaso_Validating(object sender, CancelEventArgs e)
        {
            //ciconoImporte.Set = CIconos.ExclamacionYellow;
            if (cSaldoTraspaso.GetValueDecimal == 0)
            {
                ciconoImporte.Set = CIconos.ExclamacionOrange;
                btnRedondeo.Enabled = false;
            }
            else
            {
                ciconoImporte.Set = CIconos.Tilde;
                btnRedondeo.Enabled = true;
            }

            //if (cSaldoTraspaso.GetValueDecimal > cSaldoMax.GetValueDecimal)
            //{
            //    MessageBox.Show(@"El Valor a Traspasar entre cuentas no puede superar el maximo de origen",
            //        @"Error en Saldo a Traspasar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    ciconoImporte.Set = CIconos.TrianguloNaranja;
            //    e.Cancel = true;
            //}
            //else
            //{
            //    ciconoImporte.Set = CIconos.Tilde;
            //    btnRedondeo.Enabled = true;
            //}
        }

        private void btnRedondeo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotivoAjuste.Text))
            {
                MessageBox.Show("Debe proveer una descripcion/motivo por la que se genera el documento",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MotivoDescripcionAjuste = txtMotivoAjuste.Text;
            var r = MessageBox.Show(@"Confirma el traspaso de saldos entre cuentas -- " + Environment.NewLine +
                                    $@"Traspaso Desde {_lxOrigen} ---> Hacia {_lxDestino} " + Environment.NewLine +
                                    $@"Importe a Traspasar = {cSaldoTraspaso.GetValueDecimal.ToString("C2")}?",
                @"Confirmacion Traspaso Entre Cuentas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;

            var xrate = new ExchangeRateManager().GetExchangeRate(_fechaDocumento);
            ManageDocumentType.TipoDocumento _tipoDocumento = ManageDocumentType.TipoDocumento.AjusteContable;
            _aj1.CreaHeader(_tipoDocumento, _idCliente, _lxOrigen, _fechaDocumento, xrate, "0E", "0.0.0.0", false, _autorizado);
            _aj2.CreaHeader(_tipoDocumento, _idCliente, _lxDestino, _fechaDocumento, xrate, "0E", "0.0.0.0", false, _autorizado);
            _aj1.AddItems("ZAJCC", $"Traspaso Saldo desde {_lxOrigen} ", cSaldoTraspaso.GetValueDecimal * -1, "7.1.1", false);
            _aj2.AddItems("ZAJCC", $"Traspaso Saldo hacia {_lxDestino} ", cSaldoTraspaso.GetValueDecimal, "7.1.1", false);
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
