using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmNcdAddOtherConcept : Form
    {
        private readonly int _idcLiente;
        private readonly string _tipoLx;
        private readonly ManageDocumentType.TipoDocumento _tipoDocumento;
        public string item;
        public string descripcion;
        public decimal cantidad;
        public decimal precioU;
        public string glventas;

        public FrmNcdAddOtherConcept(int idcLiente, string tipoLx, ManageDocumentType.TipoDocumento tipoDocumento)
        {
            _idcLiente = idcLiente;
            _tipoLx = tipoLx;
            _tipoDocumento = tipoDocumento;
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidaToSave())
                return;

            item = cmbItem.SelectedValue.ToString();
            descripcion = txtDescripcionItem.Text;
            cantidad = Convert.ToDecimal(txtCantidad.Text);
            precioU = Convert.ToDecimal(txtPrecioUnitario.Text);
            glventas = cmbGLV.SelectedValue.ToString();

            //mapear aca a variables publicas
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void FrmNCDAddOtherConcept_Load(object sender, EventArgs e)
        {
            LoadInitialData();
        }

        private bool ValidaToSave()
        {
            bool rtn = true;
            Validaciones.BlanqueaEp(cmbItem, ep);
            Validaciones.BlanqueaEp(cmbGLV, ep);
            Validaciones.BlanqueaEp(txtPrecioUnitario, ep);
            Validaciones.BlanqueaEp(txtCantidad, ep);

            if (cmbItem.SelectedValue == null)
            {
                Validaciones.SetErrorErrorPrivider(cmbItem, ep);
                rtn = false;
            }

            if (cmbGLV.SelectedValue == null)
            {
                Validaciones.SetErrorErrorPrivider(cmbGLV, ep);
                rtn = false;
            }

            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                Validaciones.SetErrorErrorPrivider(txtCantidad, ep);
                rtn = false;
            }

            if (Convert.ToDecimal(txtCantidad.Text) <= 0)
            {
                Validaciones.SetErrorErrorPrivider(txtCantidad, ep, "La Cantidad no puede ser igual o inferior a CERO");
                rtn = false;
            }

            if (string.IsNullOrEmpty(txtPrecioUnitario.Text))
            {
                Validaciones.SetErrorErrorPrivider(txtPrecioUnitario, ep, "El precio unitario no puede estar vavio");
                rtn = false;
            }

            if (FormatAndConversions.CCurrencyADecimal(txtPrecioUnitario.Text) <= 0)
            {
                Validaciones.SetErrorErrorPrivider(txtPrecioUnitario, ep,
                    "El precio unitario no puede ser igual o menor a CERO");
                rtn = false;
            }


            return rtn;
        }
        private void LoadInitialData()
        {
            GlBs.DataSource = new GLAccountManagement().GetListGLImputacionVentas();
            MaterialBs.DataSource = new MaterialMasterManager().GetCompleteListofAka(true);
            txtIdCliente.Text = _idcLiente.ToString();
            txtRazonSocial.Text = new CustomerManager().GetCustomerBillToData(_idcLiente).cli_rsocial;
            txtTipoDocumento.Text = _tipoDocumento.ToString();
            txtLx.Text = _tipoLx;
            //
            cmbGLV.SelectedIndex = -1;
            cmbItem.SelectedIndex = -1;
            txtDescripcionItem.Text = null;
            txtGlDescripcion.Text = null;
            txtCantidad.Text = 0.ToString("n2");
            txtPrecioUnitario.Text = 0.ToString("n2");
            txtPrecioTotal.Text = 0.ToString("n2");
        }
        private void txtPrecioTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {

        }

        private void ActualizaPrecioTotal()
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
                txtCantidad.Text = 0.ToString("n2");

            if (string.IsNullOrEmpty(txtPrecioUnitario.Text))
                txtPrecioUnitario.Text = 0.ToString("C2");

            txtPrecioTotal.Text = (Convert.ToDecimal(txtCantidad.Text) *
                                   FormatAndConversions.CCurrencyADecimal(txtPrecioUnitario.Text)).ToString
                ("C2");
        }
        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            ActualizaPrecioTotal();
        }
        private void txtPrecioUnitario_Validating(object sender, CancelEventArgs e)
        {
            ActualizaPrecioTotal();
        }
        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItem.SelectedIndex == -1)
            {
                txtDescripcionItem.Text = null;
                cmbGLV.SelectedIndex = -1;
                txtGlDescripcion.Text = null;
            }
            else
            {
                txtDescripcionItem.Text =
                    new MaterialMasterManager().GetDescripcionItemVenta(cmbItem.SelectedValue.ToString(), _tipoLx,
                        _tipoLx);

                string GLVenta = GLAccountManagement.GetGLVentaMaterialMaster(cmbItem.SelectedValue.ToString());
                cmbGLV.SelectedValue = GLVenta;
                if (cmbGLV.SelectedValue != null)
                    txtGlDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(cmbGLV.SelectedValue.ToString());
            }
        }
    }
}
