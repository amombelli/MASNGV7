using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE._UserControls
{
    public partial class UVendorSearch : UserControl
    {
        public UVendorSearch()
        {
            InitializeComponent();
            this.txtTaxNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTaxNumber_KeyUp);
            this.txtTaxNumber.TextChanged += new System.EventHandler(this.txtTaxNumber_TextChanged);
            this.txtTaxNumber.Leave += new System.EventHandler(this.txtTaxNumber_Leave);
            this.txtTaxNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T0005Bs, "NTAX1", true));
            this.txtTaxId.TextChanged += new System.EventHandler(this.txtTaxId_TextChanged);
            this.txtTaxId.Leave += new System.EventHandler(this.txtTaxId_Leave);
            this.txtTaxId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T0005Bs, "TTAX1", true));
            this.cmbTaxType.SelectedIndexChanged += new System.EventHandler(this.cmbTaxType_SelectedIndexChanged);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
        }

        //---------------------------------------------------------------------------------------------------------------------
        public int? VendorId { protected set; get; }
        public List<T0005_MPROVEEDORES> VendorList = new List<T0005_MPROVEEDORES>();
        private string _funcion;
        private readonly int _modo;
        private string _cuit;
        private bool _busquedaPorVendorType = false;
        //---------------------------------------------------------------------------------------------------------------------

        private void UVendorSearch_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
            }
        }
        //
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
                    new TecserData().T0005_MPROVEEDORES.Where(c => c.NTAX1.Contains(txtTaxNumber.Text)).ToList();
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
        //
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
                    cmbTaxType.Text = @"NO INFO";
                    break;
            }
        }
        private void txtTaxId_Leave(object sender, EventArgs e)
        {
        }
        //
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
        //
        private void cmbRazonSocial_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox) sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
            }
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedValue == null)
            {
                VendorId = null;
                _cuit = null;
                cmbFantasia.SelectedIndex = -1;
                T0005DgvBs.DataSource = VendorList.Where(c => c.id_prov == -1).ToList();
                txtVendorId.Text = null; //!
                if (_busquedaPorVendorType == false)
                    cmbVendorType.SelectedIndex = -1;
                return;
            }
            //En DGV pone solo el proveedor encontrado
            var data = (T0005_MPROVEEDORES) cmbRazonSocial.SelectedItem;
            VendorId = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
            T0005DgvBs.DataSource = VendorList.Where(c => c.id_prov == VendorId.Value).ToList();
            txtVendorId.Text = VendorId.ToString();
            _cuit = txtTaxNumber.Text;
            cmbVendorType.SelectedValue = data.TIPO;
            ValidaCuitCorrecto();
        }
        private void cmbRazonSocial_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                VendorId = null;
                txtVendorId.Text = null;
                if (cmbRazonSocial.Text.Length >= Convert.ToInt32(txtNumberVendorList.Text))
                {
                    BlanqueaSeleccion();
                    cmbRazonSocial.BackColor = Color.DarkSeaGreen;
                    T0005DgvBs.DataSource =
                        new TecserData().T0005_MPROVEEDORES.Where(
                            c => c.prov_rsocial.ToUpper().Contains(cmbRazonSocial.Text.ToUpper())).ToList();
                }
            }
        }
        //
        private void cmbFantasia_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox) sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
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
                        new TecserData().T0005_MPROVEEDORES.Where(
                            c => c.prov_fantasia.ToUpper().Contains(cmbFantasia.Text.ToUpper())).ToList();

                    if (cmbFantasia.SelectedValue != null)
                        cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
                }
            }
        }
        //
        private void txtVendorId_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtVendorId_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtVendorId.Text))
            {
                //moastrar all customers
                BlanqueaSeleccion();
                T0005DgvBs.DataSource = VendorList;
            }
            else
            {
                VendorId = Convert.ToInt32(txtVendorId.Text);
                cmbRazonSocial.SelectedValue = VendorId;
                //cmbFantasia.SelectedValue = VendorId;
                if (cmbRazonSocial.SelectedIndex == -1)
                {
                    T0005DgvBs.DataSource = VendorList.Where(c => c.id_prov == -1).ToList();
                }
                txtVendorId.BackColor = Color.LightGreen;
            }

            //if (txtTaxNumber.Text != _cuit)
            //{
            //    txtTaxNumber.BackColor = Color.DarkSeaGreen;
            //    BlanqueaSeleccion(false);
            //    T0006DgvBs.DataSource =
            //        new TecserData().T0006_MCLIENTES.Where(c => c.CUIT.Contains(txtTaxNumber.Text)).ToList();
            //}
        }
        public void InicializaUc(bool ckHabilitado = true, bool ckValue = false, Color colorPanel = default(Color))
        {
            ckSoloActivos.Enabled = ckHabilitado;
            ckSoloActivos.Checked = ckValue;
            VendorList = new VendorManager().GetCompleteVendorList(ckSoloActivos.Checked);
            T0005Bs.DataSource = VendorList;
            T0014VendorTypeBs.DataSource = new TecserData().T0014_TIPO_PROVEEDOR.ToList();
            txtNumberVendorList.Text = @"6";
            BlanqueaSeleccion();
            panel1.BackColor = colorPanel;
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
                //cmbTaxType.Text = @"NO INFO";
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
            if (blanqueaCuit)
            {
                txtTaxNumber.Text = null;
                txtTaxId.Text = null;
                txtTaxNumber.BackColor = Color.LightGray;
            }
            //
            if (blanqueaVendorType)
            {
                cmbVendorType.SelectedIndex = -1;
                txtVendorTypeDescription.Text = null;
                cmbVendorType.BackColor = Color.LightGray;
            }
        }

        private void cmbVendorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVendorType.SelectedIndex != -1)
            {
                var data = (T0014_TIPO_PROVEEDOR) cmbVendorType.SelectedItem;
                txtVendorTypeDescription.Text = data.TIPOPROV_DESC;
            }
        }
        private void cmbVendorType_Enter(object sender, EventArgs e)
        {
            _busquedaPorVendorType = true;
            this.cmbVendorType.SelectedIndexChanged += new System.EventHandler(this.cmbVendorType_SelectedIndexChanged);
        }
        //
        private void txtNumberVendorList_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtNumberVendorList_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumberVendorList.Text))
                txtVendorId.Text = @"1";
        }
        //
        private void ckSoloActivos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckSoloActivos.Checked)
            {
                ckSoloActivos.BackColor = Color.MediumSeaGreen;
            }
            else
            {
                ckSoloActivos.BackColor = Color.CornflowerBlue;
            }

            VendorList = new VendorManager().GetCompleteVendorList(ckSoloActivos.Checked, false);
            T0005Bs.DataSource = VendorList;
        }

        private void cmbVendorType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbVendorType.SelectedIndex == -1)
            {
                txtVendorTypeDescription.Text = null;
                return;
            }
            BlanqueaSeleccion(true,false);
            cmbVendorType.BackColor = Color.LightBlue;
            var x = cmbVendorType.SelectedValue.ToString();
            T0005DgvBs.DataSource =
                new VendorManager().GetListVendorByVendorType(x);

            //if (_busquedaPorVendorType)
            //{
            //    //Estoy buscando por tipo de proveedor
            //    BlanqueaSeleccion(true, false);
            //    cmbVendorType.BackColor = Color.LightBlue;
            //    var x = cmbVendorType.Text;
            //    T0005DgvBs.DataSource =
            //        new VendorManager().GetListVendorByVendorType(x);
            //    _busquedaPorVendorType = false;
            //}
            //else
            //{
            //    //El Cmb cambia debido al cambio de vendor pero no busca por Tipo
            //}
            var data = (T0014_TIPO_PROVEEDOR)cmbVendorType.SelectedItem;
            txtVendorTypeDescription.Text = data.TIPOPROV_DESC;
        }

        private void cmbFantasia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
        }
        //

    }
}

