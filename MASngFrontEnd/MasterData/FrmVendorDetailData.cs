using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.VBTools;
using TecserEF.Entity;
using WebServicesAFIP;

namespace MASngFE.MasterData
{
    public partial class FrmVendorDetailData : Form
    {
        public FrmVendorDetailData()
        {
            InitializeComponent();
        }

        public FrmVendorDetailData(string cuit)
        {
            _modo = 6; //creacion automatica de vendor por cuit
            _cuit = cuit;
            InitializeComponent();
            txtNumeroTax.Text = _cuit;
        }
        public FrmVendorDetailData(int modo, int idProveedor)
        {
            _modo = modo;
            _idProv = idProveedor;
            InitializeComponent();
            this.btnSalir.CausesValidation = false;

        }

        private string _cuit;
        private readonly int _modo;
        private readonly int _idProv;
        private readonly ZtermManager _zterm = new ZtermManager();
        private readonly AddressManager _address = new AddressManager("AR");
        private T0005_MPROVEEDORES _vendor = new T0005_MPROVEEDORES();
        private enum AddressCombo
        {
            Pais,
            Provincia,
            Partido,
            Localidad
        };

        private void FrmVendorDetailData_Load(object sender, EventArgs e)
        {
            ConfiguraCombobox(); //Configura valuemember + 
            AsignaDatasource_DefaultValues(); //AsignaDatasource + Default Values controles
            if (_idProv > 0)
            {
                _vendor = new VendorManager().GetSpecificVendor(_idProv);
                if (_vendor.id_prov <= 0)
                {
                    MessageBox.Show("Error en la carga del vendor", "");
                    this.Close();
                }
            }


            switch (_modo)
            {
                case 1:
                    this.Text = "CREACION DE PROVEEDORES";
                    btnSalir.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnCopiarDatos.Enabled = true;
                    btnPadronAfip.Enabled = true;
                    break;
                case 2:
                    this.Text = "EDICION DE PROVEEDORES";
                    txtIdProveedor.Text = _idProv.ToString();
                    MapStructureForm(_vendor);
                    btnSalir.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnCopiarDatos.Enabled = true;
                    btnPadronAfip.Enabled = true;
                    break;
                case 3:
                    this.Text = "VISUALIZACION DE PROVEEDORES";
                    txtIdProveedor.Text = _idProv.ToString();
                    MapStructureForm(_vendor);
                    btnSalir.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCopiarDatos.Enabled = false;
                    btnPadronAfip.Enabled = false;
                    break;
                case 6:
                    //Creacion automatica de Vendors desde Interfaz x CUIT#
                    this.Text = @"MDV02 - Creacion de Proveedor Automatica";
                    MapeoRetornoAFIP();
                    cmbCondicionIVA.SelectedValue = @"RI";
                    cmbTipoVendor.SelectedIndex = -1;
                    cmbTipoTax.SelectedValue = @"CUIT";
                    txtFantasia.Text = txtRazonSocial.Text;

                    break;
            }
        }
        private void ConfiguraCombobox()
        {
            cmbProvincia.ValueMember = "id";
            cmbProvincia.DisplayMember = "REGION";

            cmbPartido.ValueMember = "id";
            cmbPartido.DisplayMember = "PARTIDO";

            cmbLocalidad.ValueMember = "id";
            cmbLocalidad.DisplayMember = "LOCALIDAD";

            cmbZterm.ValueMember = "ZTERM";
            cmbZterm.DisplayMember = "ZTERM";

            cmbCondicionIVA.ValueMember = "DESCRIPCION";
            cmbCondicionIVA.DisplayMember = "IdTipoResponsable";

            cmbTipoTax.ValueMember = "TTAX";
            cmbTipoTax.DisplayMember = "TAXDESC";

            cmbTipoVendor.ValueMember = "TIPOPROV";
            cmbTipoVendor.DisplayMember = "TIPOPROV";

            cmbGLDefault.ValueMember = "GL";
            cmbGLDefault.DisplayMember = "GL";
        }
        private void AsignaDatasource_DefaultValues()
        {
            UnBindComboboxAddress();
            txtPais.Text = "AR";
            cmbProvincia.DataSource = _address.DatasourceRegion;
            cmbPartido.DataSource = _address.DataSourcePartido;
            cmbLocalidad.DataSource = _address.DatasourceLocalidad;
            //
            cmbProvincia.SelectedValue = _address.GetSelectedRegion();
            cmbPartido.Text = "";
            cmbLocalidad.Text = "";
            BindComboboxAddress();
            //  
            cmbZterm.DataSource = _zterm.GetCompleteListOfZterms();
            cmbZterm.DataSource = _zterm.GetCompleteListOfZterms();
            cmbTipoTax.DataSource = new TaxDataManager().GetCompleteListOfTTax();
            cmbTipoVendor.DataSource = new TipoVendorManager().GetCompleteListOfVendorType();
            cmbGLDefault.DataSource = new GlAccountStructureManager().GetCompleteListaGL();
            cmbCondicionIVA.DataSource = new TipoResponsableTaxManager().GetCompleteTipoResponsableList();

            ckVendorActivo.Checked = true;
            cmbTipoTax.SelectedValue = "00";
            cmbZterm.Text = "0E";

        }
        private void UnBindComboboxAddress()
        {
            this.cmbProvincia.SelectedIndexChanged -= new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            this.cmbPartido.SelectedIndexChanged -= new System.EventHandler(this.cmbPartido_SelectedIndexChanged);
            this.cmbLocalidad.SelectedIndexChanged -= new System.EventHandler(this.cmbLocalidad_SelectedIndexChanged);
            Console.WriteLine("UNBIND Controles!");
        }
        private void BindComboboxAddress()
        {
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            this.cmbPartido.SelectedIndexChanged += new System.EventHandler(this.cmbPartido_SelectedIndexChanged);
            this.cmbLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbLocalidad_SelectedIndexChanged);
            Console.WriteLine("Bind Controles Again");
        }
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("provincia_selectedindexchanged");
            _address.SetRegion(Convert.ToInt32(cmbProvincia.SelectedValue));
            ReasignaDatasourceAddressCombo(AddressCombo.Provincia);
        }
        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPartido.Text != null)
            {
                Console.WriteLine("partido_selectedindexchanged");
                _address.SetPartido(Convert.ToInt32(cmbPartido.SelectedValue));
                ReasignaDatasourceAddressCombo(AddressCombo.Partido);
            }
        }
        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocalidad.Text != null)
            {
                Console.WriteLine("localidad_selectedindexchanged");
                _address.SetLocalidad(Convert.ToInt32(cmbLocalidad.SelectedValue));
                ReasignaDatasourceAddressCombo(AddressCombo.Localidad);
            }
        }
        private void ReasignaDatasourceAddressCombo(AddressCombo valorCombo)
        {
            UnBindComboboxAddress();
            switch (valorCombo)
            {
                case AddressCombo.Pais:

                    break;

                case AddressCombo.Provincia:
                    cmbProvincia.DataSource = _address.DatasourceRegion;
                    cmbLocalidad.DataSource = _address.DatasourceLocalidad;
                    cmbPartido.DataSource = _address.DataSourcePartido;


                    cmbPartido.Text = "";
                    cmbLocalidad.Text = "";
                    break;

                case AddressCombo.Partido:
                    cmbProvincia.DataSource = _address.DatasourceRegion;
                    cmbLocalidad.DataSource = _address.DatasourceLocalidad;
                    cmbPartido.DataSource = _address.DataSourcePartido;
                    cmbProvincia.SelectedValue = _address.GetSelectedRegion();

                    cmbLocalidad.Text = "";
                    break;

                case AddressCombo.Localidad:
                    cmbProvincia.DataSource = _address.DatasourceRegion;
                    cmbLocalidad.DataSource = _address.DatasourceLocalidad;
                    cmbPartido.DataSource = _address.DataSourcePartido;

                    cmbPartido.SelectedValue = _address.GetSelectedPartido();
                    cmbPartido.Text = _address.DataSourcePartido.Find(c => c.Id.Equals(Convert.ToInt32(cmbPartido.SelectedValue))).Partido;
                    cmbProvincia.SelectedValue = _address.GetSelectedRegion();
                    break;
            }
            BindComboboxAddress();
        }


        #region Mapeos Structura-Formulario

        private void MapStructureForm(T0005_MPROVEEDORES p)
        {
            txtIdProveedor.Text = p.id_prov.ToString();
            cmbGLDefault.Text = p.GL;
            //txtFechaAlicuotaCM05Hasta.Text= 
            //txtAlicuotaCM05.Text=
            //txtFechaGSEXentoHasta.Text=
            //txtFechaIIBBExentoHasta.Text=
            //ckExentoGS.Checked=
            //ckExentoIIBB.Checked=
            txtCBU.Text = p.BANK_ACC;
            //txtZtermDescripcion.Text=

            if (p.ZTERM != null)
                cmbZterm.Text = p.ZTERM.ToString();

            txtGLDescripcion.Text = new GlAccountStructureManager().GetGLDescription(p.GL);
            txtIDClienteRazonSocial.Text = p.Cliente.ToString();
            txtEmail.Text = p.EMAIL;
            txtTelefono2.Text = p.Telefono;
            txtTelefono1.Text = p.Fax;
            txtContacto.Text = p.Contacto;

            if (p.Dire_Localidad != null)
                cmbLocalidad.Text = p.Dire_Localidad;

            if (p.Dire_Provincia != null)
                cmbProvincia.Text = p.Dire_Provincia;

            if (p.Partido != null)
                cmbPartido.Text = p.Partido;

            txtPais.Text = p.Dire_Pais;
            txtDireccion.Text = p.Dire_Provincia;
            txtNumeroTax.Text = p.NTAX1;
            txtIDTax.Text = p.TTAX1;
            cmbTipoTax.Text = new TaxDataManager().GetTaxDescription(p.TTAX1);
            txtCondicionIVADesc.Text = new TipoResponsableTaxManager().GetDescripcionTipoResponsable(p.CONDI_IVA);
            cmbCondicionIVA.Text = p.CONDI_IVA;
            txtTipoVendorDesc.Text = new TipoVendorManager().GetDescripcionTipoVendor(p.TIPO);
            txtFantasia.Text = p.prov_fantasia;

            if (p.ACTIVO != null) ckVendorActivo.Checked = p.ACTIVO.Value;

            if (p.TIPO != null)
                cmbTipoVendor.Text = p.TIPO;

            txtRazonSocial.Text = p.prov_rsocial;
            txtCodigoPostal.Text = p.Dire_CodPostal;
            txtLogCreado.Text = p.LOG_DATE.ToString();
            txtLogUsuario.Text = p.LOG_USER;
            txtUltimoMov.Text = p.Ultimo_Movimiento.ToString();
            txtMapeoRaffone.Text = p.IDRAF;

            var color = _address.CheckDatosCorrectos(p.Dire_Pais, p.Dire_Provincia,
                         p.Dire_Localidad, p.Dire_Localidad);

            txtPais.ForeColor = color[0];
            cmbLocalidad.ForeColor = color[3];
            cmbPartido.ForeColor = color[2];
            cmbProvincia.ForeColor = color[1];

        }

        public void MapFormStructure(T0005_MPROVEEDORES p)
        {
            if (!string.IsNullOrEmpty(txtIdProveedor.Text))
                p.id_prov = Convert.ToInt32(txtIdProveedor.Text);
            p.TIPO = cmbTipoVendor.Text;
            p.prov_rsocial = txtRazonSocial.Text;
            p.prov_fantasia = txtFantasia.Text;
            p.Direccion = txtDireccion.Text;
            p.Dire_Localidad = cmbLocalidad.Text.ToString();
            p.Dire_Provincia = cmbProvincia.Text.ToString();
            p.Partido = cmbPartido.Text.ToString();
            p.Dire_CodPostal = txtCodigoPostal.Text;
            p.Dire_Pais = txtPais.Text;
            p.Telefono = txtTelefono1.Text;
            p.Fax = txtTelefono2.Text;
            p.Contacto = txtContacto.Text;
            if (string.IsNullOrEmpty(txtIDClienteRazonSocial.Text) != true)
                p.Cliente = Convert.ToInt32(txtIDClienteRazonSocial.Text);
            p.TTAX1 = cmbTipoTax.SelectedValue.ToString();
            p.NTAX1 = txtNumeroTax.Text;
            //p.TTAX2=
            //p.NTAX2=
            //p.TTAX3=
            //p.NTAX3=
            if (string.IsNullOrEmpty(txtLogCreado.Text) != true)
                p.Fecha_Ingreso = Convert.ToDateTime(txtLogCreado.Text);

            if (string.IsNullOrEmpty(txtUltimoMov.Text) != true)
                p.Ultimo_Movimiento = Convert.ToDateTime(txtUltimoMov.Text);
            //p.DMTAS=
            p.IDRAF = txtMapeoRaffone.Text;
            p.EMAIL = txtEmail.Text;
            p.REMITO = ckEntregaRemito.Checked;
            p.ZTERM = cmbZterm.SelectedValue.ToString();
            p.CONDI_IVA = cmbCondicionIVA.SelectedValue.ToString();
            p.GL = cmbGLDefault.SelectedText;
            p.LOG_USER = txtLogUsuario.Text;
            if (string.IsNullOrEmpty(txtLogCreado.Text) != true)
                p.LOG_DATE = Convert.ToDateTime(txtLogCreado.Text);
            p.BANK_ACC = txtCBU.Text;
            p.COMENTARIO = txtComentario.Text;
            p.ACTIVO = ckVendorActivo.Checked;
            //p.IdLocalidadAddress=
        }


        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletos_TipoVendor(cmbTipoVendor.Text.ToString()) == false)
            {
                MessageBox.Show("Debe Completar los datos obligatorios para poder grabar!", @"Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MapFormStructure(_vendor);
                var resultado = new VendorManager().GuardaCambiosVendor(_vendor);
                if (resultado < 0)
                    MessageBox.Show(@"Error al Crear o Actualizar el Vendor");
                if (resultado == 0)
                    MessageBox.Show(@"Se actualizaron datos");
                if (resultado > 0)
                    MessageBox.Show(@"Se ha creado correctamente el Vendor " + resultado);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCopiarDatos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDClienteRazonSocial.Text))
            {
                MessageBox.Show(@"Debe completar l codigo de cliente Razon Social para continuar", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var datosCliente = new CustomerManager().GetCustomerBillToData(Convert.ToInt32(txtIDClienteRazonSocial.Text));

            txtRazonSocial.Text = datosCliente.cli_rsocial;
            txtFantasia.Text = datosCliente.cli_fantasia;
            txtDireccion.Text = datosCliente.Direccion_facturacion;
            cmbProvincia.Text = datosCliente.Direfactu_Provincia;
            cmbLocalidad.Text = datosCliente.Direfactu_Localidad;
        }


        private void MapeoRetornoAFIP()
        {
            var retornoPadron = new PadronAfipWsA5(ModoEjecucion.Produccion).ObtieneDatosPadronA5(txtNumeroTax.Text);
            if (string.IsNullOrEmpty(retornoPadron.Denominacion))
            {
                MessageBox.Show(@"No Aparecen Datos para el Cuit provisto", @"Datos en Padrón Inexistentes",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                //mapeamos a vacio?
            }
            else
            {
                txtRazonSocial.Text = retornoPadron.Denominacion;
                //txtCUIT.Text = cn.Cuit;
                //txtIDTax.Text = Convert.ToString(cn.Tdoc);
                cmbProvincia.Text = retornoPadron.Provincia;
                cmbLocalidad.Text = retornoPadron.Localidad;
                txtCodigoPostal.Text = retornoPadron.CodPostal;
                cmbPartido.Text = null;
                txtDireccion.Text = retornoPadron.Direccion;
                txtCondicionIVADesc.Text = retornoPadron.IVA;
                cmbCondicionIVA.Text = new TipoResponsableTaxManager().GetTaxIdFromDescription(retornoPadron.IVA);

                txtRazonSocial.BackColor = Color.Gold;
                cmbProvincia.BackColor = Color.Gold;
                cmbLocalidad.BackColor = Color.Gold;
                txtCodigoPostal.BackColor = Color.Gold;
                txtDireccion.BackColor = Color.Gold;
                txtCondicionIVADesc.BackColor = Color.Gold;
                if (cmbCondicionIVA.Text == "??")
                    cmbCondicionIVA.BackColor = Color.Red;
                cmbCondicionIVA.BackColor = Color.Gold;
            }
        }

        private void btnPadronAfip_Click(object sender, EventArgs e)
        {

            var dialogResult = MessageBox.Show(@"Desea completar automaticamente los datos del Proveedor utilizando los datos de AFIP", @"Completar Datos", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            UnBindComboboxAddress();
            var cn = new PadronAfipWsA5(ModoEjecucion.Produccion).ObtieneDatosPadronA5(txtNumeroTax.Text);
            if (cn.Denominacion == "")
            {
                MessageBox.Show("No se pudo encontrar el CUIT en el Padron AFIP", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                txtRazonSocial.Text = cn.Denominacion;
                //txtCUIT.Text = cn.Cuit;
                //txtIDTax.Text = Convert.ToString(cn.Tdoc);
                cmbProvincia.Text = cn.Provincia;
                cmbLocalidad.Text = cn.Localidad;
                txtCodigoPostal.Text = cn.CodPostal;
                cmbPartido.Text = null;
                txtDireccion.Text = cn.Direccion;
                txtCondicionIVADesc.Text = cn.IVA;
                cmbCondicionIVA.Text = new TipoResponsableTaxManager().GetTaxIdFromDescription(cn.IVA);

                txtRazonSocial.BackColor = Color.Gold;
                cmbProvincia.BackColor = Color.Gold;
                cmbLocalidad.BackColor = Color.Gold;
                txtCodigoPostal.BackColor = Color.Gold;
                txtDireccion.BackColor = Color.Gold;
                txtCondicionIVADesc.BackColor = Color.Gold;
                if (cmbCondicionIVA.Text == "??")
                    cmbCondicionIVA.BackColor = Color.Red;
                cmbCondicionIVA.BackColor = Color.Gold;


                BindComboboxAddress();

                if (cn.Estado != "ACTIVO")
                {
                    MessageBox.Show(@"CUIT del cliente no se encuentra ACTIVO en la AFIP", @"CLIENTE INACTIVO",
                        MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show(@"Se han actualizado los datos correctamente desde el Servidor AFIP", @"Datos AFIP",
                        MessageBoxButtons.OK);
                }
            }
        }
        private void txtNumeroTax_TextChanged(object sender, EventArgs e)
        {
            var val = new CuitValidation();
            txtNumeroTax.BackColor = val.ValidarCuit(txtNumeroTax.Text) == true ? Color.GreenYellow : Color.OrangeRed;


            if (_modo == 1 && txtIDTax.Text != "00")
            {
                //Debemos chequear que el numero de CUIT no exista en la base
                if (new VendorManager().CheckIfCuitExist(txtNumeroTax.Text) && string.IsNullOrEmpty(txtNumeroTax.Text) != true)
                {
                    MessageBox.Show(@"El Proveedor ya se encuentra en la base de datos", @"Validacion Datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumeroTax.Text = "";
                }
            }
        }


        #region FUNCIONES DE VALIDACION DATOS COMPLETOS

        private int ValidaNoVacio(Control name, string errorMessage = "Este campo debe estar completo", bool setFocus = false, bool showErrorMessage = false)
        {
            if (string.IsNullOrEmpty(name.Text.ToString()) == true)
            {
                errorProvider1.SetError(name, errorMessage);
                if (setFocus == true) name.Focus();
                if (showErrorMessage)
                    MessageBox.Show(errorMessage, @"Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
            else
            {
                errorProvider1.SetError(name, "");
                return 0;
            }
        }

        private bool ValidaDatosCompletos_TipoVendor(string tipoVendor)
        {
            var datosCompletos = 0;
            switch (tipoVendor.Trim().ToUpper())
            {
                case "DIRECTOS":
                    {
                        datosCompletos += ValidaNoVacio(txtRazonSocial);
                        datosCompletos += ValidaNoVacio(txtFantasia);
                        datosCompletos += ValidaNoVacio(cmbTipoVendor);
                        datosCompletos += ValidaNoVacio(cmbCondicionIVA);
                        datosCompletos += ValidaNoVacio(txtDireccion);
                        datosCompletos += ValidaNoVacio(cmbProvincia);
                        datosCompletos += ValidaNoVacio(cmbLocalidad);
                        break;
                    }

                default:
                    {
                        datosCompletos += ValidaNoVacio(txtRazonSocial);
                        datosCompletos += ValidaNoVacio(txtFantasia);
                        datosCompletos += ValidaNoVacio(cmbTipoVendor);
                        break;
                    }

            }
            return datosCompletos <= 0;
        }


        private void txtFantasia_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaNoVacio(txtFantasia) > 0;
        }
        private void cmbTipoVendor_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaNoVacio(cmbTipoVendor) > 0;
        }
        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidaNoVacio(txtRazonSocial) > 0;
            e.Cancel = txtRazonSocial.Text.Length < 30;
        }

        #endregion

        private void cmbTipoVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipoVendorDesc.Text = new TipoVendorManager().GetDescripcionTipoVendor(cmbTipoVendor.Text);
        }
        private void cmbCondicionIVA_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCondicionIVADesc.Text = new TipoResponsableTaxManager().GetDescripcionTipoResponsable(cmbCondicionIVA.Text);
        }
        private void cmbZterm_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtZtermDescripcion.Text = _zterm.GetDescripcionZTerm(cmbZterm.Text);
        }
        private void cmbGLDefault_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGLDescripcion.Text = new GlAccountStructureManager().GetGLDescription(cmbGLDefault.Text);
        }

    }
}
