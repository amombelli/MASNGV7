using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.DataFix;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFi56SeleccionDocumentoAjusteTc : Form
    {
        public FrmFi56SeleccionDocumentoAjusteTc(ManageDocumentType.TipoDocumento tdoc, string lx, int idCliente)
        {
            _tdocumento = tdoc;
            _lx = lx;
            _idCliente = idCliente;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------
        private readonly ManageDocumentType.TipoDocumento _tdocumento;
        private readonly string _lx;
        private readonly int _idCliente;
        public int IdFacturaSeleccionada { get; private set; }
        public decimal NuevoTC { get; private set; }
        public string NumeroDocumentoSeleccionado { get; private set; }
        //-----------------------------------------------------------------------------

        private void FrmSeleccionDocumentoAjusteTipoCambio_Load(object sender, EventArgs e)
        {
            var clidata = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtRazonSocial.Text = clidata.cli_rsocial;
            txtFantasia.Text = clidata.cli_fantasia;
            txtId6.Text = _idCliente.ToString();

            t0400FACTURAHBindingSource.DataSource = GetTabla400401.GetListaDocumentos(_idCliente, _lx).ToList();
            dgvFactuHeader.DataSource = t0400FACTURAHBindingSource;
            dgvFactuItems.DataSource = t0401FACTURAIBindingSource;

            if (_tdocumento == ManageDocumentType.TipoDocumento.NotaDebitoVenta2 ||
                _tdocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA)
            {
                lblImporteNCD.Text = @"Importe Nota Debito";
            }
            else
            {
                lblImporteNCD.Text = @"Importe Nota Credito";
            }
        }

        private void txtNewTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void dgvFactuHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nameX = "iDFACTURADataGridViewTextBoxColumn";
                IdFacturaSeleccionada =
                    Convert.ToInt32(dgvFactuHeader[dgvFactuHeader.Columns[nameX].Index, e.RowIndex].Value);

                nameX = "tCDataGridViewTextBoxColumn";
                txtTcOri.Text =
                    Convert.ToDecimal(dgvFactuHeader[dgvFactuHeader.Columns[nameX].Index, e.RowIndex].Value)
                        .ToString("n2");

                nameX = "totalFacturaNDataGridViewTextBoxColumn";
                txtPrecioNetoOri.Text =
                    Convert.ToDecimal(dgvFactuHeader[dgvFactuHeader.Columns[nameX].Index, e.RowIndex].Value)
                        .ToString("C2");

                var ndoc = dgvFactuHeader[dgvFactuHeader.Columns["numeroDocDataGridViewTextBoxColumn"].Index, e.RowIndex].Value;
                if (ndoc != null)
                {
                    NumeroDocumentoSeleccionado = ndoc.ToString();
                }
                else
                {
                    NumeroDocumentoSeleccionado = @"9999-99999999";
                }
            }
            else
            {
                IdFacturaSeleccionada = 0;
                NumeroDocumentoSeleccionado = @"0000-00000000";
            }
            UpdateItemDataSource();
        }

        private void UpdateItemDataSource()
        {
            t0401FACTURAIBindingSource.DataSource = new CustomerInvoice("NCDX", IdFacturaSeleccionada).GetItemData();
        }

        private bool CheckTcIsValid()
        {
            var tcO = Convert.ToDecimal(txtTcOri.Text);
            var tcN = Convert.ToDecimal(txtNewTc.Text);
            txtDiferenciaPrecio.Text = 0.ToString("C2");

            if (_tdocumento == ManageDocumentType.TipoDocumento.NotaCreditoVenta2 ||
                _tdocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA)
            {
                if (tcN >= tcO)
                {
                    tt.SetToolTip(txtNewTc, "El Valor del TC es Invalido para una Nota de Credito");
                    ep.SetError(txtNewTc, "El Valor del TC es Invalido para una Nota de Credito");
                    return false;
                }
                else
                {
                    txtDiferenciaPrecio.Text =
                  (FormatAndConversions.CCurrencyADecimal(txtPrecioNetoOri.Text) -
                   FormatAndConversions.CCurrencyADecimal(txtPrecioNetoNew.Text))
                      .ToString("C2");
                    ep.SetError(txtNewTc, "");
                }
            }
            else
            {
                if (tcN <= tcO)
                {
                    tt.SetToolTip(txtNewTc, "El Valor del TC es Invalido para una Nota de Debito");
                    ep.SetError(txtNewTc, "El Valor del TC es Invalido para una Nota de Debito");
                    return false;
                }
                else
                {
                    txtDiferenciaPrecio.Text =
                  (FormatAndConversions.CCurrencyADecimal(txtPrecioNetoNew.Text) -
                   FormatAndConversions.CCurrencyADecimal(txtPrecioNetoOri.Text))
                      .ToString("C2");
                    ep.SetError(txtNewTc, "");
                }
            }
            txtNewTc.Text = tcN.ToString("N2");
            NuevoTC = tcN;
            return true;
        }

        private void txtNewTc_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewTc.Text))
            {
                txtNewTc.Text = txtTcOri.Text;
            }
            btnAceptar.Enabled = CheckTcIsValid();

            var data = new NcdCalculoDiferenciaTc().RecalculaimporteTC(IdFacturaSeleccionada,
                Convert.ToDecimal(txtNewTc.Text));
            txtPrecioNetoNew.Text = data.ImporteTotalNetoFinal.ToString("C2");

            if (_tdocumento == ManageDocumentType.TipoDocumento.NotaCreditoVenta2 ||
                _tdocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA)
            {
                txtDiferenciaPrecio.Text =
                    (FormatAndConversions.CCurrencyADecimal(txtPrecioNetoOri.Text) -
                     data.ImporteTotalNetoFinal)
                        .ToString("C2");
            }
            else
            {
                txtDiferenciaPrecio.Text =
                    (data.ImporteTotalNetoFinal -
                     FormatAndConversions.CCurrencyADecimal(txtPrecioNetoOri.Text))
                        .ToString("C2");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (CheckTcIsValid() == false)
                return;

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void txtNewTc_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewTc.Text))
            {
                tt.SetToolTip(txtNewTc,
                    "El TC no puede ser NULO. Se ha completado con el mismo valor que el TC Original");
                e.Cancel = true;
            }
            else if (CheckTcIsValid() == false)
            {
                e.Cancel = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
