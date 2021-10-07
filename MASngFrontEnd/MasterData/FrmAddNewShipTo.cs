using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using TecserEF.Entity;

namespace MASngFE.MasterData
{
    public partial class FrmAddNewShipTo : Form
    {
        public FrmAddNewShipTo(int id6)
        {
            InitializeComponent();
            _id6 = id6;
            ConfiguraCombobox();
            AsignaDatasource_DefaultValues();

        }

        private readonly int _id6;
        private readonly AddressManager _addressShip = new AddressManager("AR");
        public T0007_CLI_ENTREGA CustomerT7 = new T0007_CLI_ENTREGA();

        private enum AddressCombo
        {
            Pais,
            Provincia,
            Partido,
            Localidad
        };

        private bool ValidaDatosMandatoriosCompletos()
        {
            if (string.IsNullOrEmpty(txtDireccion.Text))
                return MensajeErrorDatos("Debe Completar la Direccion");

            if (string.IsNullOrEmpty(txtDescripcionShipto.Text))
                return MensajeErrorDatos(@"Debe Completar la Descripcion del Cliente-Entrega");



            return true;
        }

        private bool MensajeErrorDatos(string mensajeError)
        {
            MessageBox.Show(mensajeError, @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void MapFormStructure()
        {
            CustomerT7.IDCLIENTE = Convert.ToInt32(txtId6.Text);
            CustomerT7.Activo = ckDireccionActiva.Checked;
            CustomerT7.CKTRANSPORTE = ckTransporte.Checked;
            CustomerT7.ClienteEntregaDesc = txtDescripcionShipto.Text;
            if (ckTransporte.Checked == true)
            {
                CustomerT7.TRANSPORTE_ID = Convert.ToInt32(txtIdTransporte);
            }
            else
            {
                CustomerT7.TRANSPORTE_ID = null;
            }

            CustomerT7.Direccion_Entrega = txtDireccion.Text;
            CustomerT7.Pais = txtPais.Text;
            CustomerT7.DireEntre_Provincia = cmbProvincia.Text;
            CustomerT7.Direccion_EntregaPartido = cmbPartido.Text;
            CustomerT7.DireEntre_Localidad = cmbLocalidad.Text;
            if (cmbLocalidad.SelectedValue != null)
                CustomerT7.IdLocalidadAddress = Convert.ToInt32(cmbLocalidad.SelectedValue);

            CustomerT7.ZIP = txtCodigoPostal.Text;
            CustomerT7.DireEntre_Zona = txtZona.Text;
            CustomerT7.EntregaHorarios = txtHorarioEntrega.Text;

            CustomerT7.Contacto = txtContacto.Text;
            CustomerT7.Telefono_Entrega = txtTelefono1.Text;
            CustomerT7.Fax = txtTelefono2.Text;
            if (cmbVendedor.SelectedValue != null)
                CustomerT7.Vendedor = cmbVendedor.SelectedValue.ToString();

            if (string.IsNullOrEmpty(txtId7.Text) == false)
            {
                CustomerT7.ID_CLI_ENTREGA = Convert.ToInt32(txtId7.Text);
            }
        }
        private void FrmAddNewShipTo_Load(object sender, EventArgs e)
        {
            LoadBillToData();
        }
        private void LoadBillToData()
        {
            var billToData = new CustomerManager().GetCustomerBillToData(_id6);
            if (billToData == null)
                return;
            {
                txtId6.Text = _id6.ToString();
                txtRazonSocial.Text = billToData.cli_rsocial.ToString();
                txtFantasia.Text = billToData.cli_fantasia;
            }
        }
        private void UnBindComboboxAddressShipTo()
        {
            this.cmbProvincia.SelectedIndexChanged -= new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            this.cmbPartido.SelectedIndexChanged -= new System.EventHandler(this.cmbPartido_SelectedIndexChanged);
            this.cmbLocalidad.SelectedIndexChanged -= new System.EventHandler(this.cmbLocalidad_SelectedIndexChanged);
        }
        private void BindComboboxAddressShipTo()
        {
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            this.cmbPartido.SelectedIndexChanged += new System.EventHandler(this.cmbPartido_SelectedIndexChanged);
            this.cmbLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbLocalidad_SelectedIndexChanged);
            Console.WriteLine("Bind Controles Again");
        }
        private void ConfiguraCombobox()
        {
            cmbProvincia.ValueMember = "id";
            cmbProvincia.DisplayMember = "REGION";

            cmbPartido.ValueMember = "id";
            cmbPartido.DisplayMember = "PARTIDO";

            cmbLocalidad.ValueMember = "id";
            cmbLocalidad.DisplayMember = "LOCALIDAD";

            cmbVendedor.ValueMember = "ID_VEND";
            cmbVendedor.DisplayMember = "SHORTNAME";

            cmbTransporte.ValueMember = "id_prov";
            cmbTransporte.DisplayMember = "prov_rsocial";
        }

        private void AsignaDatasource_DefaultValues()
        {
            UnBindComboboxAddressShipTo();
            txtPais.Text = @"AR";
            cmbProvincia.DataSource = _addressShip.DatasourceRegion;
            cmbPartido.DataSource = _addressShip.DataSourcePartido;
            cmbLocalidad.DataSource = _addressShip.DatasourceLocalidad;
            //
            cmbProvincia.SelectedValue = _addressShip.GetSelectedRegion();
            cmbPartido.Text = null;
            cmbLocalidad.Text = null;
            BindComboboxAddressShipTo();
            //  
            cmbVendedor.DataSource = new HumanResourcesManager().GetListAllActiveVendedor();
            cmbTransporte.DataSource =
                new VendorManager().GetCompleteListVendors().Where(c => c.TIPO.ToUpper().Equals("TRANSP")).ToList();

            cmbTransporte.Enabled = false;
            txtIdTransporte.Text = null;
            cmbTransporte.Text = null;

            cmbVendedor.Text = null;
            ckDireccionActiva.Checked = true;
        }

        private void ReasignaDatasourceAddressComboShipTo(AddressCombo valorCombo)
        {
            UnBindComboboxAddressShipTo();
            switch (valorCombo)
            {
                case AddressCombo.Pais:

                    break;

                case AddressCombo.Provincia:
                    cmbProvincia.DataSource = _addressShip.DatasourceRegion;
                    cmbLocalidad.DataSource = _addressShip.DatasourceLocalidad;
                    cmbPartido.DataSource = _addressShip.DataSourcePartido;


                    cmbPartido.Text = "";
                    cmbLocalidad.Text = "";
                    break;

                case AddressCombo.Partido:
                    cmbProvincia.DataSource = _addressShip.DatasourceRegion;
                    cmbLocalidad.DataSource = _addressShip.DatasourceLocalidad;
                    cmbPartido.DataSource = _addressShip.DataSourcePartido;
                    cmbProvincia.SelectedValue = _addressShip.GetSelectedRegion();

                    cmbLocalidad.Text = "";
                    break;

                case AddressCombo.Localidad:
                    cmbProvincia.DataSource = _addressShip.DatasourceRegion;
                    cmbLocalidad.DataSource = _addressShip.DatasourceLocalidad;
                    cmbPartido.DataSource = _addressShip.DataSourcePartido;

                    cmbPartido.SelectedValue = _addressShip.GetSelectedPartido();
                    cmbPartido.Text =
                        _addressShip.DataSourcePartido.Find(c => c.Id.Equals(Convert.ToInt32(cmbPartido.SelectedValue)))
                            .Partido;
                    cmbProvincia.SelectedValue = _addressShip.GetSelectedRegion();
                    break;
            }
            BindComboboxAddressShipTo();
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            _addressShip.SetRegion(Convert.ToInt32(cmbProvincia.SelectedValue));
            ReasignaDatasourceAddressComboShipTo(AddressCombo.Provincia);
        }

        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartido.Text != null)
            {
                _addressShip.SetPartido(Convert.ToInt32(cmbPartido.SelectedValue));
                ReasignaDatasourceAddressComboShipTo(AddressCombo.Partido);
            }
        }

        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocalidad.Text != null)
            {
                _addressShip.SetLocalidad(Convert.ToInt32(cmbLocalidad.SelectedValue));
                ReasignaDatasourceAddressComboShipTo(AddressCombo.Localidad);
            }
        }

        private void ckTransporte_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTransporte.Checked == true)
            {
                cmbTransporte.Enabled = true;
            }
            else
            {
                cmbTransporte.Enabled = false;
                cmbTransporte.Text = null;
                txtIdTransporte.Text = null;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Confirma el agregado de un nuevo SHIPTO", @"New ShipTo Confirmation",
                MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                if (ValidaDatosMandatoriosCompletos())
                {
                    MapFormStructure();
                    int id7 = new CustomerManager().SaveShipToData(CustomerT7);
                    if (id7 > 0)
                    {
                        MessageBox.Show(string.Format(@"Se ha mantenido correctamente el cliente {0}", id7),
                            @"Creacion/Actualizacion de SHIPTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            @"Ha Ocurrido un error al grabar el SHIPTO - No se actualizaron datos del Cliente",
                            @"Creacion/Actualizacion de SHIPTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
            }
            else
            {
                //No confirmo la creacion del SHIPTO 
            }
        }

        private void cmbTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransporte.SelectedIndex > -1)
            {
                txtIdTransporte.Text = cmbTransporte.SelectedValue.ToString();
            }
            else
            {
                txtIdTransporte.Text = null;
                cmbTransporte.Text = null;
            }
        }

        private void btnAddTransporte_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcionalidad no realizada aun");
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDatosTecser_Click(object sender, EventArgs e)
        {
            txtCodigoPostal.Text = @"1752";
            txtDireccion.Text = @"CERRITO 3475";
            cmbProvincia.SelectedValue = 1;
            cmbPartido.SelectedValue = 65;
            cmbLocalidad.SelectedValue = 502;
            txtIdLocalidad.Text = @"502";
        }
    }
}
