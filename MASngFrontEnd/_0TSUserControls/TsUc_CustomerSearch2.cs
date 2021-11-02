using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData.Customer;

namespace MASngFE._0TSUserControls
{
    
    public partial class TsUcCustomerSearch2 : UserControl
    {

        public TsUcCustomerSearch2()
        {
            InitializeComponent();
        }

        public delegate void ClienteModificadoEventHandler(object source, TsCustomerSearchEventArgs args);
        public event ClienteModificadoEventHandler ClienteModificado;
        private List<StxCustomerSimple> _customerList = new List<StxCustomerSimple>();
        private int? _idCliente;
        public int? ClienteId
        {
            get => _idCliente;
            set
            {
                _idCliente = value;
                if (value == null || _idCliente == -1)
                {
                    cmbRazonSocial.SelectedValue = -1;
                }
                else
                {
                    cmbRazonSocial.SelectedValue = value;
                }
            }
        }
        protected virtual void OnClienteModificado()
        {
            if (ClienteModificado != null)
            {
                ClienteModificado(this,
                    new TsCustomerSearchEventArgs()
                    {
                        ClienteId = _idCliente,
                        RazonSocial = cmbRazonSocial.Text,
                        Fantasia = cmbFantasia.Text
                        //agregar cuit
                    }
                );
            }
        }
        private void BlanqueaSeleccion()
        {
            cmbRazonSocial.BackColor = Color.LightGray;
            cmbFantasia.BackColor = Color.LightGray;
            txtClienteId.BackColor = Color.LightGray;
            //
            cmbRazonSocial.SelectedIndex = -1;
            txtClienteId.Text = null;
            _idCliente = null;
            txtCuit.Text = null;
        }
        private void TsCustomerSearch2_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
               //var listaRazonSocial = new CustomerMng2().GetCustomerList(ckSoloClientesActivos.Checked,
               //     CustomerMng2.OrderBy1.RazonSocial).ToList();
               //StxCustomer.DataSource = listaRazonSocial.ToList();
               //cmbRazonSocial.DataSource = listaRazonSocial;
               // cmbFantasia.DataSource = listaRazonSocial.OrderBy(c => c.Fantasia).ToList();
               // BlanqueaSeleccion();
            }
            
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {

            }
        }
        private void txtClienteId_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClienteId.Text) || txtClienteId.GetValueDecimal<1)
            {
                BlanqueaSeleccion();
                return;
            }

            _idCliente = (int) txtClienteId.GetValueDecimal;
            cmbRazonSocial.SelectedValue = _idCliente;
        }
        private void ckSoloClientesActivos_CheckedChanged(object sender, EventArgs e)
        {
            var listaRazonSocial = new CustomerMng2().GetCustomerList(ckSoloClientesActivos.Checked,
                CustomerMng2.OrderBy1.RazonSocial).ToList();
            cmbRazonSocial.DataSource = listaRazonSocial;
            cmbFantasia.DataSource = listaRazonSocial.OrderBy(c => c.Fantasia).ToList();
            if (ckSoloClientesActivos.Checked)
            {
                ckSoloClientesActivos.ForeColor=Color.DarkGreen;
            }
            else
            {
                ckSoloClientesActivos.ForeColor=Color.LightPink;
            }
        }

        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            var control = (ComboBox) sender;
            if (control.SelectedIndex == -1)
            {
                _idCliente = null;
                cmbFantasia.SelectedIndex = -1;
                cmbFantasia.SelectedIndex = -1;
                txtCuit.Text = null;
                return;
            }

            _idCliente = Convert.ToInt32(control.SelectedValue);
            cmbFantasia.SelectedValue = _idCliente;
            cmbRazonSocial.SelectedValue = _idCliente;
            txtClienteId.Text = _idCliente.ToString();
            OnClienteModificado();

        }
    }
}
