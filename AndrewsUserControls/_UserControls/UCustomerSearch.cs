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
    public partial class UCustomerSearch : UserControl
    {
        //-----------------------------------------------------------------------------------
        private int? Id6;
        public List<T0006_MCLIENTES> CustomerList = new List<T0006_MCLIENTES>();
        private string _funcion;
        private readonly int _modo;
        private string _cuit;
        //-----------------------------------------------------------------------------------

        public UCustomerSearch()
        {
            InitializeComponent();
            this.txtTaxNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTaxNumber_KeyUp);
            this.txtTaxNumber.TextChanged += new System.EventHandler(this.txtTaxNumber_TextChanged);
            this.txtTaxNumber.Leave += new System.EventHandler(this.txtTaxNumber_Leave);
            txtTaxNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T0006Bs, "CUIT", true));
            this.txtTaxId.TextChanged += new System.EventHandler(this.txtTaxId_TextChanged);
            this.txtTaxId.Leave += new System.EventHandler(this.txtTaxId_Leave);
            this.txtTaxId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T0006Bs, "TTAX", true));
            this.cmbTaxType.SelectedIndexChanged += new System.EventHandler(this.cmbTaxType_SelectedIndexChanged);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
        }

        private void UCustomerSearch_Load(object sender, EventArgs e)
        {

        }
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
                T0006DgvBs.DataSource =
                    new TecserData().T0006_MCLIENTES.Where(c => c.CUIT.Contains(txtTaxNumber.Text)).ToList();
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
            cmbTaxType.Text = txtTaxId.Text == @"80" ? @"CUIT" : @"NI";
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
                if (cmbTaxType.Text == @"CUIT")
                {
                    txtTaxId.Text = @"80";
                    txtTaxNumber.BackColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    txtTaxId.Text = @"00";
                    txtTaxNumber.BackColor = Color.DarkGray;
                    txtTaxNumber.Text = @"00000000000";
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
                Id6 = null;
                _cuit = null;
                cmbFantasia.SelectedIndex = -1;
                T0006DgvBs.DataSource = CustomerList.Where(c => c.IDCLIENTE == -1).ToList();
                return;

            }
            Id6 = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
            T0006DgvBs.DataSource = CustomerList.Where(c => c.IDCLIENTE == Id6.Value).ToList();
            txtCustomerId6.Text = Id6.ToString();
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
        private void BlanqueaSeleccion(bool blanqueaCuit = true)
        {
            //
            cmbRazonSocial.BackColor = Color.LightGray;
            cmbFantasia.BackColor = Color.LightGray;
            cmbTaxType.BackColor = Color.LightGray;
            txtCustomerId6.BackColor = Color.LightGray;
            //
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTaxType.SelectedIndex = -1;
            txtCustomerId6.Text = null;
            if (blanqueaCuit)
            {
                txtTaxNumber.Text = null;
                txtTaxId.Text = null;
                txtTaxNumber.BackColor = Color.LightGray;
            }
            Id6 = null;
        }
        private void txtNumeroClientesList_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtNumeroClientesList_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroClientesList.Text))
                txtNumeroClientesList.Text = @"1";
        }

        //Fin Funcionalidad Combobox!
        private void ckSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            ckSoloActivos.BackColor = ckSoloActivos.Checked ? Color.MediumSeaGreen : Color.CornflowerBlue;
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //do connection stuff here
                CustomerList = new CustomerManager().GetCompleteListofBillTo(ckSoloActivos.Checked);
                T0006Bs.DataSource = CustomerList;
            }
        }
        private void cmbRazonSocial_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                if (cmbRazonSocial.Text.Length >= Convert.ToInt32(txtNumeroClientesList.Text))
                {
                    BlanqueaSeleccion();
                    cmbRazonSocial.BackColor = Color.DarkSeaGreen;
                    T0006DgvBs.DataSource =
                        new TecserData().T0006_MCLIENTES.Where(
                            c => c.cli_rsocial.ToUpper().Contains(cmbRazonSocial.Text.ToUpper())).ToList();
                }
            }
        }
        private void cmbFantasia_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbFantasia.SelectedIndex == -1)
            {
                if (cmbFantasia.Text.Length >= Convert.ToInt32(txtNumeroClientesList.Text))
                {
                    //cmbRazonSocial.SelectedIndex = -1;
                    BlanqueaSeleccion();
                    cmbFantasia.BackColor = Color.DarkSeaGreen;
                    T0006DgvBs.DataSource =
                        new TecserData().T0006_MCLIENTES.Where(
                            c => c.cli_fantasia.ToUpper().Contains(cmbFantasia.Text.ToUpper())).ToList();
                }
            }
        }
        private void txtCustomerId6_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtCustomerId6_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerId6.Text))
            {
                //moastrar all customers
                BlanqueaSeleccion();
                T0006DgvBs.DataSource = CustomerList;

            }
            else
            {
                Id6 = Convert.ToInt32(txtCustomerId6.Text);
                cmbRazonSocial.SelectedValue = Id6;
                //cmbFantasia.SelectedValue = Id6;
                if (cmbRazonSocial.SelectedIndex == -1)
                {
                    T0006DgvBs.DataSource = CustomerList.Where(c => c.IDCLIENTE == -1).ToList();
                }
                txtCustomerId6.BackColor = Color.LightGreen;
            }

            //if (txtTaxNumber.Text != _cuit)
            //{
            //    txtTaxNumber.BackColor = Color.DarkSeaGreen;
            //    BlanqueaSeleccion(false);
            //    T0006DgvBs.DataSource =
            //        new TecserData().T0006_MCLIENTES.Where(c => c.CUIT.Contains(txtTaxNumber.Text)).ToList();
            //}
        }
        public void InicializaUc(bool ckHabilitado=true, bool ckValue=false,Color colorPanel =default(Color))
        {
            ckSoloActivos.Enabled = ckHabilitado;
            ckSoloActivos.Checked = ckValue;
            CustomerList = new CustomerManager().GetCompleteListofBillTo();
            T0006Bs.DataSource = CustomerList;
            txtNumeroClientesList.Text = @"6";
            BlanqueaSeleccion();
            panel1.BackColor = Color.LightBlue;
        }
    }
}
