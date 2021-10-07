using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.VendorNCD
{
    public partial class FrmFI85NCDPDiferenciaKg : Form
    {
        private readonly int _idVendor;
        private readonly string _tipoLx;
        public string material;
        public decimal cantidad;
        public decimal precioU;
        public decimal precioT;
        public string moneda;
        public decimal tc;
        public bool iva21;
        public string monedaConta;
        public string gl;

        public FrmFI85NCDPDiferenciaKg(int idVendor, string tipo)
        {
            _idVendor = idVendor;
            _tipoLx = tipo;
            InitializeComponent();
        }

        private void FrmFI85NCDPDiferenciaKg_Load(object sender, EventArgs e)
        {
            txtIdProveedor.Text = _idVendor.ToString();
            txtRazonSocial.Text = new VendorManager().GetSpecificVendor(_idVendor).prov_rsocial;
            this.cmbMaterial.SelectedIndexChanged -= new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            BindingSource bs = new BindingSource();
            bs.DataSource = VendorNcdManageDevoluciones.GetListaMateriales(_idVendor);
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            cmb1Moneda.SelectedItem = @"ARS";
            moneda = @"ARS";
            txt1TipoCambio.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");
            if (_tipoLx == @"L1")
            {
                ckBaseImponible.Checked = true;
                ckBaseImponible.Enabled = true;
            }
            else
            {
                ckBaseImponible.Checked = false;
                ckBaseImponible.Enabled = false;
            }
            cmbMonedaConta.SelectedItem = @"ARS";
            monedaConta = @"ARS";
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtDescripcionMaterial.Text = null;
                return;
            }

            ncdpBs.DataSource = new VendorNcdManageDevoluciones().GetDataComprasItems(_idVendor,
                cmbMaterial.SelectedValue.ToString());
            var x = MaterialMasterManager.GetSpecificPrimaryInformation(cmbMaterial.SelectedValue.ToString());

            if (x != null)
            {
                txtDescripcionMaterial.Text = x.MAT_DESC;
            }

            material = cmbMaterial.SelectedValue.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void dgvItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;

            //decimal unitUsd = Convert.ToDecimal(dgv[dgv.Columns[PUnitUsd.Name].Index, e.RowIndex].Value);
            //decimal unitArs = Convert.ToDecimal(dgv[dgv.Columns[PUnitArs.Name].Index, e.RowIndex].Value);
            txtSDocumento.Text = dgv[dgv.Columns[numeroDocumentoDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();
            txtSMoneda.Text = dgv[dgv.Columns[monedaDocDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();
            txtSCantidad.Text = dgv[dgv.Columns[cantidadDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();
            txtPrecioUArs.Text = Convert.ToDecimal(dgv[dgv.Columns[PUnitArs.Name].Index, e.RowIndex].Value).ToString("C2");
            txtPrecioUnitUSD.Text = Convert.ToDecimal(dgv[dgv.Columns[PUnitUsd.Name].Index, e.RowIndex].Value).ToString("C2");
            txtGlItem.Text = dgv[dgv.Columns[GL.Name].Index, e.RowIndex].Value.ToString();
            gl = txtGlItem.Text;
        }

        //Revision 2020.01.04
        private void cmb1PreciotTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void cmb1PrecioUnit_Validating(object sender, CancelEventArgs e)
        {
            var cmb = (TextBox)sender;
            if (string.IsNullOrEmpty(cmb.Text))
                cmb.Text = @"0";

            var valor = FormatAndConversions.CCurrencyADecimal(cmb.Text);
            cmb.Text = valor.ToString("C3");
        }
        private void cmb1Cantidad_Validating(object sender, CancelEventArgs e)
        {
            var cmb = (TextBox)sender;
            if (string.IsNullOrEmpty(cmb.Text))
                cmb.Text = @"0";

            var valor = Convert.ToDecimal(cmb.Text);
            cmb.Text = valor.ToString("N4");
        }
        private void RecalculaTotal()
        {
            if (string.IsNullOrEmpty(txt1Cantidad.Text)) return;
            if (string.IsNullOrEmpty(txt1PrecioUnit.Text)) return;

            precioU = FormatAndConversions.CCurrencyADecimal(txt1PrecioUnit.Text);
            cantidad = Convert.ToDecimal(txt1Cantidad.Text);
            precioT = precioU * cantidad;
            txt1PreciotTotal.Text = precioT.ToString("C2");

            if (string.IsNullOrEmpty(txt1TipoCambio.Text)) return;
            tc = Convert.ToDecimal(txt1TipoCambio.Text);

            if (tc <= 0)
            {
                tc = 0;
                return;
            }

            if (cmb1Moneda.SelectedItem.ToString() == @"ARS")
            {
                //precio alternativo en USD
                txt1PrecioUnitAlter.Text = (precioU / tc).ToString("C3");
                txt1PrecioTotalAlter.Text = (precioT / tc).ToString("C2");
            }
            else
            {
                //precio alternativo en ARS
                txt1PrecioUnitAlter.Text = (precioU * tc).ToString("C3");
                txt1PrecioTotalAlter.Text = (precioT * tc).ToString("C2");
            }
        }
        private void txt1TipoCambio_Leave(object sender, EventArgs e)
        {
            RecalculaTotal();
        }
        private void cmb1Moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb1Moneda.SelectedItem.ToString() == @"ARS")
            {
                //precio alternativo en USD
                Label1PrecioUnit.Text = @"Precio Unit [USD]";
                label1PrecioTotal.Text = @"Precio Total [USD]";
            }
            else
            {
                //precio alternativo en ARS
                Label1PrecioUnit.Text = @"Precio Unit [ARS]";
                label1PrecioTotal.Text = @"Precio Total [ARS]";
            }
            moneda = cmb1Moneda.SelectedItem.ToString();
            RecalculaTotal();
        }
        private bool ValidaAddOk()
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe Seleccionar un Material para Imputar la NC", @"Error en Ingreso de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cantidad <= 0)
            {
                MessageBox.Show(@"La Cantidad no puede ser menor o igual a 0", @"Error en Ingreso de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tc <= 0)
            {
                MessageBox.Show(@"El Tipo de Cambio es Invalido", @"Error en Ingreso de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (precioU <= 0)
            {
                MessageBox.Show(@"El Precio Unitario no puede ser menor o igual a 0", @"Error en Ingreso de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (precioT <= 0)
            {
                MessageBox.Show(@"El Precio Total no puede ser menor o igual a 0", @"Error en Ingreso de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidaAddOk())
                return;
            iva21 = ckBaseImponible.Checked;
            if (cmb1Moneda.SelectedItem != cmbMonedaConta.SelectedItem)
            {
                //Si la moneda del Item es diferente a la de contabilizacion.-
                //Toma los precios alternativos que son los de la otra moneda
                precioU = FormatAndConversions.CCurrencyADecimal(txt1PrecioUnitAlter.Text);
                precioT = FormatAndConversions.CCurrencyADecimal(txt1PrecioTotalAlter.Text);
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void cmbMonedaConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculaPrecioMoneda();
        }

        private void RecalculaPrecioMoneda()
        {
            monedaConta = cmbMonedaConta.SelectedItem.ToString();
            if (monedaConta == cmb1Moneda.SelectedItem.ToString())
            {

            }
            else
            {
                if (monedaConta == "ARS")
                {

                }
                else
                {

                }
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
