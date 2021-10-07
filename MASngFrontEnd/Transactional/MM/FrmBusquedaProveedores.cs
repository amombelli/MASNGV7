using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.MM;
using Tecser.Business.VBTools;

namespace MASngFE.Transactional.MM
{
    public partial class FrmBusquedaProveedores : Form
    {
        public FrmBusquedaProveedores()
        {
            InitializeComponent();
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.TextChanged += new System.EventHandler(this.txtNumeroTax_TextChanged);
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.Leave += new System.EventHandler(this.txtNumeroTax_Leave);
            this.txtCodigoTax.TextChanged += new System.EventHandler(this.txtCodigoTax_TextChanged);
            this.txtCodigoTax.Leave += new System.EventHandler(this.txtCodigoTax_Leave);
            this.cmbTipoTax.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTax_SelectedIndexChanged);
            this.cmbIdProveedor.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            _modo = 1;
            _funcion = "OC";
        }
        public FrmBusquedaProveedores(int modo, string funcion)
        {
            InitializeComponent();
            _modo = modo;
            _funcion = funcion;
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.TextChanged += new System.EventHandler(this.txtNumeroTax_TextChanged);
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.Leave += new System.EventHandler(this.txtNumeroTax_Leave);
            this.txtCodigoTax.TextChanged += new System.EventHandler(this.txtCodigoTax_TextChanged);
            this.txtCodigoTax.Leave += new System.EventHandler(this.txtCodigoTax_Leave);
            this.cmbTipoTax.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTax_SelectedIndexChanged);
            this.cmbIdProveedor.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
        }

        //-------------------------------------------------------------------------------------------
        private int? _idVendor = null;
        private readonly int _modo;
        private readonly string _funcion;
        //-------------------------------------------------------------------------------------------

        #region Funcionalidad de Combos
        ///**Funcionalidad validacion / CUIT
        private void txtNumeroTax_KeyUp(object sender, KeyEventArgs e)
        {
            //cuando es tipo 80 y 11 caracteres lo valida
            if (txtNumeroTax.Text.Length == 11 && txtCodigoTax.Text == @"80")
            {
                ValidaCuitCorrecto();
            }
        }
        private void txtNumeroTax_TextChanged(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtNumeroTax_Leave(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtCodigoTax_TextChanged(object sender, EventArgs e)
        {
            cmbTipoTax.Text = txtCodigoTax.Text == @"80" ? @"CUIT" : @"NI";
        }
        private void txtCodigoTax_Leave(object sender, EventArgs e)
        {

        }

        private void cmbTipoTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoTax.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                if (cmbTipoTax.Text == @"CUIT")
                {
                    txtCodigoTax.Text = @"80";
                    txtNumeroTax.BackColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    txtCodigoTax.Text = @"00";
                    txtNumeroTax.BackColor = Color.DarkGray;
                    txtNumeroTax.Text = @"00000000000";
                }
            }
        }
        private void cmbRazonSocial_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
            }
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedValue == null)
            {
                //BlanqueaSeleccion();
                _idVendor = null;
                return;
            }
            _idVendor = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            txtGLAp.Text = new GLAccountManagement().GetApVendorGl(_idVendor.Value);
            ValidaCuitCorrecto();

            if (_idVendor != null)
            {
                OCHeaderBS.DataSource =
                    new OrdenCompraManager().GetListofOrdenCompraByVendor(_idVendor.Value);
            }



        }
        private void ValidaCuitCorrecto()
        {
            if (txtNumeroTax.Text.Length == 11 && txtNumeroTax.Text != @"00000000000")
            {
                if (new CuitValidation().ValidarCuit(txtNumeroTax.Text) == true)
                {
                    txtTaxValido.Text = @"VALIDO";
                    txtTaxValido.BackColor = Color.LightGreen;
                }
                else
                {
                    txtTaxValido.Text = @"INVALIDO";
                    txtTaxValido.BackColor = Color.Crimson;
                }
            }
            else
            {
                txtTaxValido.Text = @"SIN VALIDAR";
                txtTaxValido.BackColor = Color.Orange;
            }
            //  }
        }
        private void BlanqueaSeleccion()
        {
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTipoTax.SelectedIndex = -1;
            cmbIdProveedor.SelectedIndex = -1;
            txtNumeroTax.Text = null;
            txtCodigoTax.Text = null;
            OCHeaderBS.DataSource = null;
            _idVendor = null;

        }
        #endregion

        private void InicializaForm()
        {
            t0005MPROVEEDORESBindingSource.DataSource = new VendorManager().GetCompleteVendorList(ckSoloActivo.Checked, ckSoloPermitidos.Checked);
            ckSoloActivo.Checked = true;
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTipoTax.SelectedIndex = -1;
            cmbIdProveedor.SelectedIndex = -1;
            btn1.Enabled = false;
            btn2.Enabled = false;
            _idVendor = null;
            txtNumeroTax.Text = null;
            txtCodigoTax.Text = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ckSoloPermitidos_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataSoruce();
        }
        private void FrmBusquedaProveedores_Load(object sender, EventArgs e)
        {
            InicializaForm();
            ConfiguraScreenByFuncion();
            ConfiguraScreenByModo();
            //ConfiguraComboBox();
            //RefreshDataSoruce();

        }
        private void ConfiguraComboBox()
        {
        }
        private void RefreshDataSoruce()
        {
            t0005MPROVEEDORESBindingSource.DataSource = new VendorManager().GetCompleteVendorList(ckSoloActivo.Checked, ckSoloPermitidos.Checked);
            //cmbFantasia.DataSource = new VendorManager().GetCompleteVendorList(ckSoloActivo.Checked, ckSoloPermitidos.Checked);
            //cmbIdProveedor.DataSource = new VendorManager().GetCompleteVendorList(ckSoloActivo.Checked, ckSoloPermitidos.Checked);

            if (string.IsNullOrEmpty(cmbIdProveedor.SelectedValue.ToString()) != true)
            {
                OCHeaderBS.DataSource =
                    new OrdenCompraManager().GetListofOrdenCompraByVendor(Convert.ToInt32(cmbIdProveedor.SelectedValue));
            }
        }
        private void RefreshDataSorucePorTipoVendor()
        {
            //if (string.IsNullOrEmpty(cmbTipoProveedor.SelectedValue.ToString()) != null)
            //{
            //    var ds = new List<T0005_MPROVEEDORES>();
            //    ds = new VendorManager().GetListVendorByVendorType(cmbTipoProveedor.SelectedValue.ToString(),
            //        ckSoloActivo.Checked);
            //    if (ds.Any() == true)
            //    {
            //        cmbProvRazonSocial.DataSource = ds;
            //        cmbProvFantasia.DataSource = ds;
            //        cmbCUIT.DataSource = ds;
            //    }
            //}
        }


        private void ConfiguraScreenByModo()
        {

        }

        private void ConfiguraScreenByFuncion()
        {
            switch (_funcion)
            {
                case "OC":
                    btn1.Visible = true;
                    btn2.Visible = false;
                    dgvDetalleOC.Visible = true;
                    switch (_modo)
                    {
                        case 1:
                            btn1.Text = "Nueva OC";
                            btn1.Enabled = true;
                            break;
                        case 2:
                            btn1.Visible = false;   //Se selecciona desde el dgv.
                            break;
                        case 3:
                            break;
                        default:
                            MostrarMensaje("Modo no Mantenido", "Error", MessageBoxIcon.Error);
                            return;
                    }


                    break;
                default:
                    MostrarMensaje("Funcion no mantenida", "error");
                    return;
            }
        }




        private void ckSoloActivo_CheckedChanged(object sender, EventArgs e)
        {
            RefreshDataSoruce();
        }

        private void cmbProvRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbProvRazonSocial.SelectedIndex > 0)
            //{
            //    cmbProvFantasia.SelectedValue = cmbProvRazonSocial.SelectedValue;
            //    cmbCUIT.SelectedValue = cmbProvRazonSocial.SelectedValue;
            //    txtIdProveedor.Text = cmbProvRazonSocial.SelectedValue.ToString();
            //    cmbTipoProveedor.SelectedValue =
            //        new VendorManager().GetSpecificVendor(Convert.ToInt32(cmbProvRazonSocial.SelectedValue)).TIPO;

            //    if (string.IsNullOrEmpty(txtIdProveedor.Text) != true)
            //    {
            //        OCHeaderBS.DataSource =
            //            new OrdenCompraManager().GetListofOrdenCompraByVendor(Convert.ToInt32(txtIdProveedor.Text));
            //    }
            //}
        }






        private void MostrarMensaje(string texto, string titulo, MessageBoxIcon icono = MessageBoxIcon.Error)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, icono);

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //Nueva Orden de Compra
            if (_idVendor == null)
            {
                MostrarMensaje("Debe Seleccionar un proveedor para continuar", "Datos Incompletos",
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                var f2 = new FrmOrdenCompraMain(1, _idVendor.Value);
                f2.Show();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            //Ver Info Records Materiales x Proveedor
            MessageBox.Show(@"Funcionalidad No Realizada Aun");
        }

        private void dgvDetalleOC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (senderGrid.Columns[e.ColumnIndex].Name)
                {
                    case "btnVisualizar":
                        int modoItem;
                        var numeroOC =
                            Convert.ToInt32(dgvDetalleOC[iDORDENCOMPRADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                        if (_modo < 3)
                        {
                            modoItem = 2;
                        }
                        else
                        {
                            modoItem = 3;
                        }

                        var f2 = new FrmOrdenCompraMain(modoItem, numeroOC);
                        f2.ShowDialog();
                        break;
                    default:
                        break;
                }
#pragma warning disable CS0219 // The variable 'a' is assigned but its value is never used
                var a = 1;
#pragma warning restore CS0219 // The variable 'a' is assigned but its value is never used
                var x = senderGrid.Columns[e.ColumnIndex].Name;

                //TODO - Button Clicked - Execute Code Here
            }
        }

        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {

        }

        private void cmbFantasia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cmbFantasia.SelectedValue == null && cmbFantasia.Text != string.Empty)
            {
                e.Cancel = true;
            }
            else
            {
                _idVendor = Convert.ToInt32(cmbFantasia.SelectedValue);
                cmbRazonSocial.SelectedValue = _idVendor;
            }
        }

    }
}
