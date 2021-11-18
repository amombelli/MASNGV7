using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;

namespace MASngFE._0TSUserControls
{
    public partial class TsUcCustomerSearch1 : UserControl
    {
        //Delegate and Events : 
        //1. Define a delegate
        //2. Define an event bases on that delegate
        //3. Raise the event
        public delegate void ClienteModificadoEventHandler(object source, TsCustomerSearchEventArgs args);
        public event ClienteModificadoEventHandler ClienteModificado;

        public TsUcCustomerSearch1()
        {
            InitializeComponent();
        }
        private int? _idCliente;

        //-----------------------------------------------------------------------

        public int? ClienteId
        {
            get => _idCliente;
            set
            {
                _idCliente = value;
                if (value == null)
                {
                    cmbRazonSocial.SelectedValue = -1;
                }
                else
                {
                    cmbRazonSocial.SelectedValue = value;
                }
            }
        }
        //-----------------------------------------------------------------------

        private void InitData()
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //do connection stuff here
                T0006Bs.DataSource = new CustomerManager().GetCompleteListofBillTo(tsckSoloActivo.Value);
            }
        }

        protected virtual void OnClienteModificado()
        {
            if (ClienteModificado != null)
            {
                ClienteModificado(this, new TsCustomerSearchEventArgs() { ClienteId = _idCliente, RazonSocial = cmbRazonSocial.Text, Fantasia = cmbFantasia.Text });
            }
        }

        private void BlanqueaSeleccion()
        {
            cmbRazonSocial.BackColor = Color.LightGray;
            cmbFantasia.BackColor = Color.LightGray;
            txtCustomerId6.BackColor = Color.LightGray;
            //
            cmbRazonSocial.SelectedIndex = -1;
            txtCustomerId6.Text = null;
            _idCliente = null;
        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void ClienteTextUpdate(object sender, EventArgs e)
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
                _idCliente = null;
                cmbFantasia.SelectedIndex = -1;
                return;

            }
            _idCliente = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
            txtCustomerId6.Text = _idCliente.ToString();
            OnClienteModificado();
        }
        private void tsckSoloActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //do connection stuff here
                T0006Bs.DataSource = new CustomerManager().GetCompleteListofBillTo(tsckSoloActivo.Value);
                BlanqueaSeleccion();
            }

        }
        private void SoloEntero(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtCustomerId6_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerId6.Text))
            {
                BlanqueaSeleccion();
            }
            else
            {
                _idCliente = Convert.ToInt32(txtCustomerId6.Text);
                cmbRazonSocial.SelectedValue = _idCliente;
                if (cmbRazonSocial.SelectedIndex == -1)
                {

                }
                txtCustomerId6.BackColor = Color.PaleGreen;
            }
        }
        private void TsCustomerSearchSimple_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // do stuff here, if it involves connecting to the database
                T0006Bs.DataSource = new CustomerManager().GetCompleteListofBillTo(tsckSoloActivo.Value);
                BlanqueaSeleccion();
            }


            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //Cuando Activo la linea de abajo da error al cargar el componente
                //T0006Bs.DataSource = new CustomerManager().GetCompleteListofBillTo(tsckSoloActivo.Value);
                //BlanqueaSeleccion();
            }
        }
    }
}
