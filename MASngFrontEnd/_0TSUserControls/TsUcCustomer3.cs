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

namespace MASngFE._0TSUserControls
{
    public partial class TsUcCustomer3 : UserControl
    {

        //---------------------------------------------------------------------------------------------------
        public delegate void ClienteModificadoEventHandler(object source, TsCustomerSearchEventArgs args);
        public event ClienteModificadoEventHandler ClienteModificado;
        private int? _idCliente;
        //---------------------------------------------------------------------------------------------------
        public TsUcCustomer3()
        {
            InitializeComponent();
        }

        private void TsUcCustomer3_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // do stuff here, if it involves connecting to the database
                //T0006Bs.DataSource = new CustomerManager().GetCompleteListofBillTo(tsckSoloActivo.Value);
                //BlanqueaSeleccion();
                var data = new CustomerMng2().GetCustomerList(true, CustomerMng2.OrderBy1.RazonSocial);
                CustomerBs.DataSource = data;
                cmbFantasia.DataSource = data.OrderBy(c => c.Fantasia).ToList();
            }


            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //Cuando Activo la linea de abajo da error al cargar el componente
                //T0006Bs.DataSource = new CustomerManager().GetCompleteListofBillTo(tsckSoloActivo.Value);
                //BlanqueaSeleccion();
            }
        }

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
        protected virtual void OnClienteModificado()
        {
            if (ClienteModificado != null)
            {
                ClienteModificado(this, new TsCustomerSearchEventArgs() { ClienteId = _idCliente, RazonSocial = cmbRazonSocial.Text, Fantasia = cmbFantasia.Text });
            }
        }

        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = (ComboBox) sender;

        }
    }
}
