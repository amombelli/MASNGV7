using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE.Forms.VendorSearchBase
{
    public partial class FrmVendorSearchBase : Form
    {
        public FrmVendorSearchBase()
        {
            InitializeComponent();

            //
            this.txtTaxNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTaxNumber_KeyUp);
            this.txtTaxNumber.TextChanged += new System.EventHandler(this.txtTaxNumber_TextChanged);
            this.txtTaxNumber.Leave += new System.EventHandler(this.txtTaxNumber_Leave);
            this.txtTaxNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T0005Bs, "NTAX1", true));
            //
            this.txtTaxId.TextChanged += new System.EventHandler(this.txtTaxId_TextChanged);
            this.txtTaxId.Leave += new System.EventHandler(this.txtTaxId_Leave);
            this.txtTaxId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T0005Bs, "TTAX1", true));
            //
            this.cmbTaxType.SelectedIndexChanged += new System.EventHandler(this.cmbTaxType_SelectedIndexChanged);
            //
            //this.cmbId6.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            //
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);

        }

        //-----------------------------------------------------------------------------------
        protected int? VendorId;
        private List<T0005_MPROVEEDORES> _venodrList = new List<T0005_MPROVEEDORES>();
#pragma warning disable CS0169 // The field 'FrmVendorSearchBase._funcion' is never used
        private string _funcion;
#pragma warning restore CS0169 // The field 'FrmVendorSearchBase._funcion' is never used
#pragma warning disable CS0169 // The field 'FrmVendorSearchBase._modo' is never used
        private readonly int _modo;
#pragma warning restore CS0169 // The field 'FrmVendorSearchBase._modo' is never used
        private string _cuit;
        //-----------------------------------------------------------------------------------

        private void FrmVendorSearchBase_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //do connection stuff here
                _venodrList = new VendorManager().GetCompleteVendorList();
                T0005Bs.DataSource = _venodrList;
                t0014TIPOPROVEEDORBindingSource.DataSource = new VendorManager().GetVendorTypeList().ToList();
                ckSoloActivos.Checked = true;
                txtNumberVendorList.Text = @"3";
                BlanqueaSeleccion();
                this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            }
        }


        #region ComboFunctions

        private void txtTaxNumber_KeyUp(object sender, KeyEventArgs e)
        {
            //cuando es tipo 80 y 11 caracteres valida el TAX Number
            if (txtTaxNumber.Text.Length == 11 && txtTaxId.Text == @"80")
            {
                ValidaCuitCorrecto();
            }
            if (txtTaxNumber.Text != _cuit)
            {
                txtTaxNumber.BackColor = Color.DarkSeaGreen;
                BlanqueaSeleccion(false);
                T0005DgvBs.DataSource =
                    new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Where(c => c.NTAX1.Contains(txtTaxNumber.Text)).ToList();
            }
        }
        private void txtTaxNumber_TextChanged(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtTaxNumber_Leave(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtTaxId_TextChanged(object sender, EventArgs e)
        {

            switch (txtTaxId.Text)
            {
                case "80":
                    cmbTaxType.Text = @"CUIT";
                    break;
                case "96":
                    cmbTaxType.Text = @"DNI";
                    break;
                default:
                    cmbTaxType.Text = @"NI";
                    break;
            }
        }
        private void txtTaxId_Leave(object sender, EventArgs e)
        {

        }
        private void cmbTaxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTaxType.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                switch (cmbTaxType.Text)
                {
                    case "CUIT":
                        txtTaxId.Text = @"80";
                        txtTaxNumber.BackColor = Color.LightGoldenrodYellow;
                        break;
                    case "DNI":
                        txtTaxId.Text = @"96";
                        txtTaxNumber.BackColor = Color.LightSkyBlue;
                        break;
                    case "00":
                        txtTaxId.Text = @"00";
                        txtTaxNumber.BackColor = Color.DarkGray;
                        txtTaxNumber.Text = @"00000000000";
                        break;
                    default:
                        txtTaxId.Text = @"00";
                        txtTaxNumber.BackColor = Color.DarkGray;
                        txtTaxNumber.Text = @"00000000000";
                        break;
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
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                VendorId = null;
                _cuit = null;
                cmbFantasia.SelectedIndex = -1;
                T0005DgvBs.DataSource = _venodrList.Where(c => c.id_prov == -1).ToList();
                return;

            }
            VendorId = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
            T0005DgvBs.DataSource = _venodrList.Where(c => c.id_prov == VendorId.Value).ToList();
            txtVendorId.Text = VendorId.ToString();
            _cuit = txtTaxNumber.Text;
            ValidaCuitCorrecto();
        }
        private void ValidaCuitCorrecto()
        {
            if (txtTaxNumber.Text.Length == 11 && txtTaxNumber.Text != @"00000000000")
            {
                if (new CuitValidation().ValidarCuit(txtTaxNumber.Text) == true)
                {
                    txtTaxStatus.Text = @"VALIDO";
                    txtTaxStatus.BackColor = Color.LightGreen;
                }
                else
                {
                    txtTaxStatus.Text = @"INVALIDO";
                    txtTaxStatus.BackColor = Color.Crimson;
                }
            }
            else
            {
                txtTaxStatus.Text = @"SIN VALIDAR";
                txtTaxStatus.BackColor = Color.LightBlue;
            }
        }
        private void BlanqueaSeleccion(bool blanqueaCuit = true, bool blanqueaVendorType = true)
        {
            //
            cmbRazonSocial.BackColor = Color.LightGray;
            cmbFantasia.BackColor = Color.LightGray;
            cmbTaxType.BackColor = Color.LightGray;
            txtVendorId.BackColor = Color.LightGray;
            //
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTaxType.SelectedIndex = -1;

            txtVendorId.Text = null;

            if (blanqueaCuit)
            {
                txtTaxNumber.Text = null;
                txtTaxId.Text = null;
                txtTaxNumber.BackColor = Color.LightGray;
            }

            if (blanqueaVendorType)
            {
                cmbTipoProveedor.SelectedIndex = -1;
                txtTipoProveedorDescripcion.Text = null;
                cmbTipoProveedor.BackColor = Color.LightGray;
            }
            VendorId = null;
        }
        private void txtNumeroClientesList_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtNumeroClientesList_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumberVendorList.Text))
                txtVendorId.Text = @"1";
        }


        //Fin Funcionalidad Combobox!

        #endregion


        private void ckSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloActivos.Checked)
            {
                ckSoloActivos.BackColor = Color.MediumSeaGreen;
            }
            else
            {
                ckSoloActivos.BackColor = Color.CornflowerBlue;
            }

            _venodrList = new VendorManager().GetCompleteVendorList(ckSoloActivos.Checked, false);
            T0005Bs.DataSource = _venodrList;
        }
        private void cmbRazonSocial_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                if (cmbRazonSocial.Text.Length >= Convert.ToInt32(txtNumberVendorList.Text))
                {
                    BlanqueaSeleccion();
                    cmbRazonSocial.BackColor = Color.DarkSeaGreen;
                    T0005DgvBs.DataSource =
                        new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Where(
                            c => c.prov_rsocial.ToUpper().Contains(cmbRazonSocial.Text.ToUpper())).ToList();
                }
            }
        }
        private void cmbFantasia_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbFantasia.SelectedIndex == -1)
            {
                if (cmbFantasia.Text.Length >= Convert.ToInt32(txtNumberVendorList.Text))
                {
                    //cmbRazonSocial.SelectedIndex = -1;
                    BlanqueaSeleccion();
                    cmbFantasia.BackColor = Color.DarkSeaGreen;
                    T0005DgvBs.DataSource =
                        new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Where(
                            c => c.prov_fantasia.ToUpper().Contains(cmbFantasia.Text.ToUpper())).ToList();
                }
            }
        }

        private void txtCustomerId6_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtCustomerId6_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtVendorId.Text))
            {
                //moastrar all customers
                BlanqueaSeleccion();
                T0005DgvBs.DataSource = _venodrList;

            }
            else
            {
                VendorId = Convert.ToInt32(txtVendorId.Text);
                cmbRazonSocial.SelectedValue = VendorId;
                //cmbFantasia.SelectedValue = VendorId;
                if (cmbRazonSocial.SelectedIndex == -1)
                {
                    T0005DgvBs.DataSource = _venodrList.Where(c => c.id_prov == -1).ToList();
                }
                txtVendorId.BackColor = Color.LightGreen;
            }

            //if (txtTaxNumber.Text != _cuit)
            //{
            //    txtTaxNumber.BackColor = Color.DarkSeaGreen;
            //    BlanqueaSeleccion(false);
            //    T0006DgvBs.DataSource =
            //        new TecserData(GlobalApp.CnnApp).T0006_MCLIENTES.Where(c => c.CUIT.Contains(txtTaxNumber.Text)).ToList();
            //}
        }
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFantasia.SelectedValue != null)
                cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
        }

        private void cmbTipoProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoProveedor.SelectedIndex == -1)
            {
                txtTipoProveedorDescripcion.Text = null;
                return;
            }
            BlanqueaSeleccion(true, false);
            cmbTipoProveedor.BackColor = Color.LightBlue;
            var x = cmbTipoProveedor.Text;
            T0005DgvBs.DataSource =
                new VendorManager().GetListVendorByVendorType(x);
        }
    }
}
