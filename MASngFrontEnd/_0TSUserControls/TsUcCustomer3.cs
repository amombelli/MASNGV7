using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData.Customer;
using TSControls;

namespace MASngFE._0TSUserControls
{
    public sealed partial class TsUcCustomer3 : UserControl
    {
        //---------------------------------------------------------------------------------------------------
        public delegate void ClienteModificadoEventHandler(object source, CustomerSearchUcV3Args args);
        public event ClienteModificadoEventHandler ClienteModificado;
        private int? _idCliente;
        private Color _colorLineaContorno=Color.Navy;
        private Color _colorFondoControl=Color.White;
        private const int AnchoMinimo = 577;
        private const int AltoMinimo = 91;
        public int? ClienteId
        {
            get => _idCliente;
            set
            {
                _idCliente = value;
                if (value == null || value <1)
                {
                    cmbRazonSocial.SelectedIndex = -1;
                }
                else
                {
                    cmbRazonSocial.SelectedValue = value;
                }
            }
        }
        //---------------------------------------------------------------------------------------------------
        public TsUcCustomer3()
        {
            InitializeComponent();
        }
        private void TsUcCustomer3_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.ckBusquedaLibre.CheckedChanged -= new System.EventHandler(this.ckBusquedaLibre_CheckedChanged);
                //
                ctlCustomerOk.Set = CIconos.Equis;
                ckSoloClientesActivos.Checked = true;
                ckBusquedaLibre.Checked = false;
                txtChar.SetValue = 4;
                cmbRazonSocial.SelectedIndex = -1;
                cmbFantasia.SelectedIndex = -1;
                ctlCustomerOk.Set = CIconos.Equis;
                //
                this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.ckBusquedaLibre.CheckedChanged += new System.EventHandler(this.ckBusquedaLibre_CheckedChanged);
            }
            
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {

            }
        }
        private void OnClienteModificado()
        {
            if (ClienteModificado == null) return;
            if (_idCliente < 1)
            {
                ClienteModificado(this,new CustomerSearchUcV3Args()
                {
                    ClienteId = -1,
                    RazonSocial = null,
                    Fantasia = null,
                    Cuit = null
                });
            }
            else
            {
                ClienteModificado(this, new CustomerSearchUcV3Args()
                {
                    ClienteId = _idCliente,
                    RazonSocial = cmbRazonSocial.Text,
                    Fantasia = cmbFantasia.Text,
                    Cuit = txtCuit.Text
                });
            }
        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            var combo = (ComboBox) sender;
            if (combo.SelectedValue == null)
            {
                BlanqueaCliente();
                ctlCustomerOk.Set = CIconos.Equis;
            }
            else
            {
                var data = (StxCustomerSimple) combo.SelectedItem;
                _idCliente = Convert.ToInt32(combo.SelectedValue);
                txtClienteId.SetValue = _idCliente.Value;
                cmbRazonSocial.SelectedValue = _idCliente;
                cmbFantasia.SelectedValue = _idCliente;
                txtCuit.Text = data.Cuit;
                OnClienteModificado();
                ctlCustomerOk.Set = CIconos.Verde;

            }
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
        }
        private void BlanqueaCliente()
        {
            this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            _idCliente = -1;
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            txtClienteId.SetValue = 0;
            txtClienteId.Text = null;
            txtCuit.Text = null;
            OnClienteModificado();

            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
        }
        private void txtClienteId_Validated(object sender, EventArgs e)
        {
            if (txtClienteId.GetValueDecimal <= 0)
            {
                BlanqueaCliente();
            }
            else
            {
                this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                _idCliente =(int) txtClienteId.GetValueDecimal;
                cmbRazonSocial.SelectedValue = _idCliente.Value;
                cmbFantasia.SelectedValue = _idCliente.Value;
                var data = (StxCustomerSimple)cmbRazonSocial.SelectedItem;
                if (cmbRazonSocial.SelectedValue != null)
                {
                    txtCuit.Text = data.Cuit;
                    OnClienteModificado();
                }
                else
                {
                    txtClienteId.SetValue = 0;
                    _idCliente = 0;
                    txtCuit.Text = null;
                    ctlCustomerOk.Set = CIconos.Equis;
                }

                this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            }

        }
        private void cmbFantasia_TextUpdate(object sender, EventArgs e)
        {
            var data = (ComboBox) sender;
            if (string.IsNullOrEmpty(data.Text))
            {
                BlanqueaCliente();
            }
            else
            {
                if (ckBusquedaLibre.Checked)
                {
                    if (data.Text.Length > (int) txtChar.GetValueDecimal && data.SelectedValue == null)
                    {
                        var parametroBusqueda = TsUcCustomerFreeSearch.ParametroBusqueda.RazonSocial;
                        if (data.Name == nameof(cmbFantasia))
                        {
                            parametroBusqueda = TsUcCustomerFreeSearch.ParametroBusqueda.Fantasia;
                        }
                        else
                        {
                            if (data.Name == nameof(cmbRazonSocial))
                            {
                                parametroBusqueda = TsUcCustomerFreeSearch.ParametroBusqueda.RazonSocial;
                            }
                        }
                        using (var f = new TsUcCustomerFreeSearch(parametroBusqueda,data.Text,(int) txtChar.GetValueDecimal))
                        {
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                _idCliente = f.IdCliente;
                                if (_idCliente < 1)
                                {
                                    BlanqueaCliente();
                                }
                                else
                                {
                                    cmbRazonSocial.SelectedValue = _idCliente;
                                }
                            }
                            else
                            {
                                //no se selecciono nada
                                BlanqueaCliente();
                                ctlCustomerOk.Set = CIconos.Equis;
                            }
                        }
                    }
                }
            }
        }
        private void ckSoloClientesActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloClientesActivos.Checked)
            {
                ckSoloClientesActivos.ForeColor = Color.DarkGreen;
            }
            else
            {
                ckSoloClientesActivos.ForeColor=Color.DarkBlue;
            }

            var data = new CustomerMng2().GetCustomerList(ckSoloClientesActivos.Checked, CustomerMng2.OrderBy1.RazonSocial);
            CustomerBs.DataSource = data;

            cmbFantasia.DataSource = data.OrderBy(c => c.Fantasia).ToList();
        }
        private void ckBusquedaLibre_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBusquedaLibre.Checked)
            {
                cmbRazonSocial.AutoCompleteMode = AutoCompleteMode.None;
                cmbFantasia.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
            else
            {
                cmbRazonSocial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbFantasia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }
        private void txtChar_Validated(object sender, EventArgs e)
        {

        }
        private void txtClienteId_KeyUp(object sender, KeyEventArgs e)
        {
        }
        private void txtClienteId_KeyUP_1(object source, KeyEventArgs args)
        {
           
        }
        public Color ColorContorno
        {
            get => _colorLineaContorno;
            set
            {
                _colorLineaContorno = value;
                lineD.BackColor = value;
                lineDown.BackColor = value;
                lineUp.BackColor = value;
                lineI.BackColor = value;
            }
        }
        public Color FondoControl
        {
            get => _colorFondoControl;
            set
            {
                _colorFondoControl = value;
                base.BackColor = value;
            }
        }

        private void TsUcCustomer3_Resize(object sender, EventArgs e)
        {
            if (this.Height != 91)
            {
                this.Height = 91;
            }

            if (this.Width < 577)
            {
                this.Width = 577;
            }
            lineUp.Size = new Size(this.Width,2);
            lineDown.Size = new Size(this.Width,2);
            lineD.Location = new Point(this.Width - 2,0);
        }
    }
}
