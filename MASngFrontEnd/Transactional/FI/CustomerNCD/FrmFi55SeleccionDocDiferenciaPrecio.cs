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
    public partial class FrmFi55SeleccionDocDiferenciaPrecio : Form
    {
        public FrmFi55SeleccionDocDiferenciaPrecio(ManageDocumentType.TipoDocumento tdoc, string lx, int idCliente)
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
        public int IdItemSeleccionado { get; private set; }
        public decimal NuevoPrecioUnitario { get; private set; }
        //-----------------------------------------------------------------------------

        private void FrmSeleccionDocAjustePrecioU_Load(object sender, EventArgs e)
        {
            var clidata = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtRazonSocial.Text = clidata.cli_rsocial;
            txtFantasia.Text = clidata.cli_fantasia;
            txtId6.Text = _idCliente.ToString();

            t0400FACTURAHBindingSource.DataSource = GetTabla400401.GetListaDocumentos(_idCliente, _lx).ToList();
            dgvFactuHeader.DataSource = t0400FACTURAHBindingSource;
            dgvFactuItems.DataSource = t0401FACTURAIBindingSource;
        }

        private void dgvFactuHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nameX = iDFACTURADataGridViewTextBoxColumn.Name.ToString();
                IdFacturaSeleccionada =
                    Convert.ToInt32(dgvFactuHeader[dgvFactuHeader.Columns[nameX].Index, e.RowIndex].Value);

                nameX = tCDataGridViewTextBoxColumn.Name.ToString();
                txtTC.Text =
                    Convert.ToDecimal(dgvFactuHeader[dgvFactuHeader.Columns[nameX].Index, e.RowIndex].Value)
                        .ToString("N2");

                nameX = totalFacturaNDataGridViewTextBoxColumn.Name.ToString();
                txtPrecioNetoOri.Text =
                    Convert.ToDecimal(dgvFactuHeader[dgvFactuHeader.Columns[nameX].Index, e.RowIndex].Value)
                        .ToString("C2");

                nameX = facturaMonedaDataGridViewTextBoxColumn.Name.ToString();
                txtMonedaPrecio.Text =
                    dgvFactuHeader[dgvFactuHeader.Columns[nameX].Index, e.RowIndex].Value.ToString();

                txtMonedaPrecioNew.Text = txtMonedaPrecio.Text;
            }
            else
            {
                IdFacturaSeleccionada = 0;
            }
            UpdateItemDataSource();
        }

        private void UpdateItemDataSource()
        {
            t0401FACTURAIBindingSource.DataSource = new CustomerInvoice("NCDX", IdFacturaSeleccionada).GetItemData();
        }

        private void dgvFactuItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (txtMonedaPrecio.Text == @"ARS")
                {
                    string nameX = "pRECIOUFACTARSDataGridViewTextBoxColumn";
                    txtPrecioUnitarioOri.Text =
                        Convert.ToInt32(dgvFactuItems[dgvFactuItems.Columns[nameX].Index, e.RowIndex].Value)
                            .ToString("C2");

                    //nameX = totalFacturaNDataGridViewTextBoxColumn.Name.ToString();
                    //txtPrecioNetoOri.Text =
                    //    Convert.ToInt32(dgvFactuHeader[dgvFactuHeader.Columns[nameX].Index, e.RowIndex].Value)
                    //        .ToString("C2");

                    nameX = IDITEM.Name.ToString();
                    IdItemSeleccionado =
                        Convert.ToInt32(dgvFactuItems[dgvFactuItems.Columns[nameX].Index, e.RowIndex].Value);


                    txtPrecioOriUsd.Text =
                        (FormatAndConversions.CCurrencyADecimal(txtPrecioUnitarioOri.Text) /
                         Convert.ToDecimal(txtTC.Text)).ToString("C2");

                }
                else
                {
                    //la factura esta en USD!
                }
            }
            else
            {
                IdFacturaSeleccionada = 0;
            }
            //UpdateItemDataSource();
        }
        private void txtNewPrecioUnitario_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtNewPrecioUnitario_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPrecioUnitario.Text))
            {
                txtNewPrecioUnitario.Text = txtPrecioUnitarioOri.Text;
            }
            txtNewPrecioUnitario.Text = FormatAndConversions.CCurrencyADecimal(txtNewPrecioUnitario.Text).ToString("C2");
            btnAceptar.Enabled = CheckPrecioUnitarioIsValid();

            txtPrecioUnitarioUSD.Text =
                (FormatAndConversions.CCurrencyADecimal(txtNewPrecioUnitario.Text) /
                 Convert.ToDecimal(txtTC.Text)).ToString("C2");

            var data = new NcdCalculoDiferenciaTc().RecalculaimporteUnitPriceChanged(IdFacturaSeleccionada, IdItemSeleccionado,
                FormatAndConversions.CCurrencyADecimal(txtNewPrecioUnitario.Text));
            txtPrecioNetoNew.Text = data.ImporteTotalNetoFinal.ToString("C2");
            txtDiferenciaPrecio.Text =
                (FormatAndConversions.CCurrencyADecimal(txtPrecioNetoOri.Text) - data.ImporteTotalNetoFinal)
                    .ToString("C2");
        }
        private bool CheckPrecioUnitarioIsValid()
        {
            decimal puO = FormatAndConversions.CCurrencyADecimal(txtPrecioUnitarioOri.Text);
            decimal puN = FormatAndConversions.CCurrencyADecimal(txtNewPrecioUnitario.Text);
            txtDiferenciaPrecio.Text = 0.ToString("C2");

            if (_tdocumento == ManageDocumentType.TipoDocumento.NotaCreditoVenta2 ||
                _tdocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA)
            {
                if (puN >= puO)
                {
                    MessageBox.Show(@"El precio unitario nuevo es invalido para realizar Nota de Credito",
                        @"Coloque un Precio Unitario correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewPrecioUnitario.Text = txtPrecioUnitarioOri.Text;
                    return false;
                }
            }
            else
            {
                if (puN <= puO)
                {
                    MessageBox.Show(@"El precio unitario nuevo es invalido para realizar Nota de Debito",
                        @"Coloque un Precio Unitario correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNewPrecioUnitario.Text = txtPrecioUnitarioOri.Text;
                    return false;
                }
            }
            txtNewPrecioUnitario.Text = puN.ToString("C2");
            NuevoPrecioUnitario = puN;
            return true;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (CheckPrecioUnitarioIsValid() == false)
                return;

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
    }
}
