using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI65GastosFinancieros : Form
    {
        private readonly CustomerNd _znd;
        private readonly CustomerNd.MotivoNotaDebito _motivo;
        private readonly int _idCliente;
        private readonly string _tipoLx;

        public FrmFI65GastosFinancieros(CustomerNd znd, CustomerNd.MotivoNotaDebito motivo)
        {
            _znd = znd;
            var h = znd.GetHeader();
            _motivo = motivo;
            _idCliente = h.Cliente;
            _tipoLx = h.TIPOFACT;
            InitializeComponent();
            txtTipoDocumento.Text = h.TIPO_DOC;

        }

        private void FrmFI64GastosFinancieros_Load(object sender, EventArgs e)
        {
            txtRazonSocial.Text = new CustomerManager().GetCustomerBillToData(_idCliente).cli_rsocial;
            txtId6.Text = _idCliente.ToString();
            txtMotivo.Text = _motivo.ToString();
            txtLx.Text = _tipoLx;
            cCantidad.SetValue = 1;
            cAClientesIva.XReadOnly = true;
            if (_tipoLx == "L1")
            {
                ckCalcularIva.Checked = true;
                ckCalcularIva.AutoCheck = true;
            }
            else
            {
                ckCalcularIva.Checked = false;
                ckCalcularIva.AutoCheck = false;
            }
        }

        private void ckCalcularIva_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCalcularIva.Checked)
            {
                cAClientesIva.SetValue = cAClienteGastoFinanciero.GetValueDecimal * (decimal)0.21;
            }
            else
            {
                cAClientesIva.SetValue = 0;
            }
            cAClientesImporteTotal.SetValue = cAClientesIva.GetValueDecimal + cAClienteGastoFinanciero.GetValueDecimal;
        }

        private void cAClienteGastoFinanciero_Validated(object sender, EventArgs e)
        {
            if (ckCalcularIva.Checked)
            {
                cAClientesIva.SetValue = cAClienteGastoFinanciero.GetValueDecimal * (decimal)0.21;
            }
            else
            {
                cAClientesIva.SetValue = 0;
            }
            cAClientesImporteTotal.SetValue = cAClientesIva.GetValueDecimal + cAClienteGastoFinanciero.GetValueDecimal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAClientesMotivo.Text))
            {
                MessageBox.Show(@"Debe proveer un texto para impresion en el documento", @"Data Validation Incomplete",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cCantidad.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"La Cantidad no puede ser 0", @"Data Validation Incomplete",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cAClientesImporteTotal.GetValueDecimal <= 0)
            {
                MessageBox.Show($@"El Importe no puede ser {cAClientesImporteTotal.GetValueDecimal.ToString("C2")}", @"Data Validation Incomplete",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _znd.AddItems("GSFIN", txtAClientesMotivo.Text, cAClienteGastoFinanciero.GetValueDecimal, txtGlFinanciero.Text, ckCalcularIva.Checked, cCantidad.GetValueDecimal);
            _znd.SetTotalesInHeaderFromItems();
            //_znd.SetPeriodoAsociado(); el Periodo Asociado lo pasamos en el form de origen
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
