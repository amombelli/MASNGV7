using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.MasterData.Vendor_Master;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI.TaxModule;
using Tecser.Business.VBTools;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;
using TSControls;
using WebServicesAFIP;

namespace MASngFE.MasterData.Vendor
{
    public partial class FrmMdv02VendorABMDetail : Form
    {
        private readonly string _cuit;
        private int _modo;
        private int _idvendor;
        private bool _validacionOK;

        public FrmMdv02VendorABMDetail(int modo, int idvendor = -1)
        {
            _modo = modo;
            if (modo == 1)
            {
                _idvendor = -1;
            }
            else
            {
                _idvendor = idvendor;
                if (idvendor<1) this.Close();
            }
            InitializeComponent();
        }
        public FrmMdv02VendorABMDetail(string cuit)
        {
            //Por modulo de creacion autmatica
            _cuit = cuit;
            _modo = 6;
            InitializeComponent();
            mtxtNumeroDocumento.Text = _cuit;
            cmbTipoDocumento.SelectedItem = "CUIT";
            //HAY QUE PONER EL 80?
        }
        
        private void FrmMdv02VendorABMDetail_Load(object sender, EventArgs e)
        {
            cIconoClienteExiste.Set = CIconos.Amarillo;
            cValidacionCuit.Set = CIconos.Information;
            cValidacionExistencia.Set = CIconos.Information;
            cmbTipoProveedor.DataSource = new VendorManager().GetVendorTypeList(true);
            cmbTipoProveedor.SelectedIndex = -1;
            cmbZtermL1.DataSource = new ZtermManager().GetCompleteListOfZterms();
            cmbZtermL2.DataSource = new ZtermManager().GetCompleteListOfZterms();
            cmbZtermL1.SelectedValue = "0E";
            cmbZtermL2.SelectedIndex = -1;
            cmbZtermL2.Enabled = false;
            
            switch (_modo)
            {
                case 1:
                    btnGrabar.Enabled = true;
                    ckActivo.Checked = true;
                    break;
                case 2:
                    LoadExistingData();
                    btnGrabar.Enabled = true;
                    break;
                case 3:
                    LoadExistingData();
                    btnGrabar.Enabled = false;
                    break;
                case 6:
                    break;
            }

        }
        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoDocumento.SelectedIndex == -1)
            {
                txtTipoDocumento.Text = null;
                mtxtNumeroDocumento.Text = null;
                mtxtNumeroDocumento.Enabled = false;
                cValidacionCuit.Set = CIconos.TrianguloNaranja;
                return;
            }

            ValResult(cmbTipoDocumento);
            mtxtNumeroDocumento.Enabled = true;
            switch (cmbTipoDocumento.SelectedItem.ToString())
            {
                case "DNI":
                    txtTipoDocumento.Text = @"96";
                    mtxtNumeroDocumento.Mask = @"00000000";
                    mtxtNumeroDocumento.Text = null;
                    break;
                case "CUIT":
                    txtTipoDocumento.Text = @"80";
                    mtxtNumeroDocumento.Mask = @"00-00000000-0";
                    mtxtNumeroDocumento.Text = null;
                    break;
                case "CUIL":
                    txtTipoDocumento.Text = @"86";
                    mtxtNumeroDocumento.Mask = @"00-00000000-0";
                    mtxtNumeroDocumento.Text = null;
                    break;
                case "NI":
                    txtTipoDocumento.Text = @"00";
                    mtxtNumeroDocumento.Mask = @"00-00000000-0";
                    mtxtNumeroDocumento.Text = @"00-000000000-0";
                    mtxtNumeroDocumento.Enabled = false;
                    break;
            }
        }
        private void cmbTipoProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoProveedor.SelectedIndex == -1)
            {
                txtDescripcionTipoProveedor.Text = null;
                txtGlSpecific.Text = null;
                txtGlVendorType.Text = null;
                ckEntregaRemito.Checked = false;
                ckTipoActivo.Checked = false;
                return;
            }

            var vtype = VendorManager.GetDataVendorType(cmbTipoProveedor.SelectedValue.ToString());
            txtDescripcionTipoProveedor.Text = vtype.TIPOPROV_DESC;
            ckEntregaRemito.Checked = vtype.EntregaRemito;
            ckTipoActivo.Checked = vtype.Activo;
            txtGlVendorType.Text = vtype.GL;
        }
        private void cmbZtermL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = (ComboBox) sender;
            if (cmb.SelectedIndex == -1)
            {
                txtZtermL1Descripcion.Text = null;
                return;
            }

            var data = (T0019_ZTERM) cmb.SelectedItem;
            txtZtermL1Descripcion.Text = data.ZTERMDESC;
        }
        private void cmbZtermL2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = (ComboBox) sender;
            if (cmb.SelectedIndex == -1)
            {
                txtZtermL2Descripcion.Text = null;
                return;
            }

            var data = (T0019_ZTERM) cmb.SelectedItem;
            txtZtermL2Descripcion.Text = data.ZTERMDESC;
        }
        private bool ValResult(Control ob, string error = null)
        {
            if (string.IsNullOrEmpty(error))
            {
                ep.SetError(ob, "");
                ob.BackColor = Color.White;
                return true;
            }
            else
            {
                ep.SetError(ob, error);
                ob.BackColor = Color.Thistle;
                _validacionOK = false;
                return false;
            }
        }
        private void SetExentoGanancias()
        {
            if (ckExentoRetencionGanancias.Checked)
            {
                TaxModuleVendorManager.AssignTaxToVendor(_idvendor, "EXRETGS", true, dtRGsExentoDesde.Value,
                    dtRGsExentoHasta.Value, txtNumeroCertificadoRgs.Text);
            }
            else
            {
                TaxModuleVendorManager.AssignTaxToVendor(_idvendor, "EXRETGS", false,
                    DateTime.Today.AddYears(-10), DateTime.Today.AddYears(-10), null);
            }
        }
        private void SetExentoARBA()
        {
            if (ckExentoArba.Checked)
            {
                TaxModuleVendorManager.AssignTaxToVendor(_idvendor, "EXRETIIBB", true, dtArbaExentoDesde.Value,
                    dtArbaExentoHasta.Value, txtNumeroCertificadoARBA.Text);
            }
            else
            {
                TaxModuleVendorManager.AssignTaxToVendor(_idvendor, "EXRETIIBB", false,
                    DateTime.Today.AddYears(-10), DateTime.Today.AddYears(-10), null);
            }
        }

        private T0005_MPROVEEDORES MapScreenToDb()
        {
            var infoAddress = ctlAddress1.GetData();
            var t = new T0005_MPROVEEDORES()
            {
                prov_rsocial = txtRazonSocial.Text,
                prov_fantasia = txtFantasia.Text,
                id_prov = _idvendor,
                ACTIVO = ckActivo.Checked,
                TTAX1 = txtTipoDocumento.Text,
                NTAX1 = mtxtNumeroDocumento.Text,
                TIPO = cmbTipoProveedor.SelectedValue?.ToString(),
                GL = txtGlSpecific.Text,
                Contacto = txtContacto.Text,
                Telefono = txtTelefono1.Text,
                Fax = txtTelefono2.Text,
                EMAIL = txtEmailPedido.Text,
                Dire_Pais = infoAddress.Pais,
                Direccion = txtDireccion.Text,
                Dire_Localidad = infoAddress.Localidad,
                Dire_CodPostal = txtCodigoPostal.Text,
                Partido = infoAddress.Partido,
                COMENTARIO = txtObservaciones.Text,
                Dire_Provincia = infoAddress.Provincia,
                ZTERM = cmbZtermL1.SelectedValue.ToString(),
                BANK_ACC = txtCuentaBanco.Text,
                Cliente =string.IsNullOrEmpty(txtIdCliente.Text)?(int?)null:Convert.ToInt32(txtIdCliente.Text),
                CONDI_IVA = txtCondicionIVA.Text,
                IdLocalidadAddress = infoAddress.IdLocalidad,
            };
            return t;
        }
        private void txtRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                ValResult((TextBox)txtRazonSocial, "Razon Social no puede estar vacia");
            }
            else
            {
                if (txtRazonSocial.Text.Length < 3)
                {
                    ValResult((TextBox)txtRazonSocial, "Razon Social no puede tener menos de 3 caracteres");
                }
                else
                {
                    ValResult(txtRazonSocial);
                }
            }
        }
        private void txtFantasia_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFantasia.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtRazonSocial.Text))
                {
                    txtFantasia.Text = txtRazonSocial.Text;
                    ValResult(txtFantasia);
                }
                else
                {
                    ValResult((TextBox)txtFantasia, "El Nombre Fantasia no puede estar vacio");
                }
            }
            else
            {
                ValResult(txtFantasia);
            }
        }
        private void cmbTipoDocumento_Validating(object sender, CancelEventArgs e)
        {
            if (cmbTipoDocumento.SelectedItem == null && !string.IsNullOrEmpty(cmbTipoDocumento.Text))
            {
                txtTipoDocumento.Text = null;
                mtxtNumeroDocumento.Text = null;
                mtxtNumeroDocumento.Enabled = false;
                cValidacionCuit.Set = CIconos.TrianguloNaranja;
                ValResult((ComboBox)cmbTipoDocumento, "Debe seleccionar un tipo de documento de la lista");
                e.Cancel = true;
                return;
            }

            if (string.IsNullOrEmpty(cmbTipoDocumento.Text))
            {
                txtTipoDocumento.Text = null;
                mtxtNumeroDocumento.Text = null;
                mtxtNumeroDocumento.Enabled = false;
                cValidacionCuit.Set = CIconos.TrianguloNaranja;
                ValResult((ComboBox)cmbTipoDocumento, "Debe seleccionar un tipo de documento de la lista");
                e.Cancel = true;
                return;
            }
            ValResult(txtRazonSocial);
        }
        private void mtxtNumeroDocumento_Validating(object sender, CancelEventArgs e)
        {
            if (!mtxtNumeroDocumento.MaskCompleted)
            {
                if (string.IsNullOrEmpty(cmbTipoDocumento.Text))
                {
                    //como el tipo de documento esta vacio - permito
                    ValResult((MaskedTextBox) mtxtNumeroDocumento);
                    cValidacionCuit.Set = CIconos.Amarillo;
                }
                else
                {
                    ValResult((MaskedTextBox) mtxtNumeroDocumento, "El # no puede estar vacio [00000...]");
                    cValidacionCuit.Set = CIconos.Rojo;
                    return;
                }
            }

            if (txtTipoDocumento.Text == @"00")
            {
                ValResult((MaskedTextBox)mtxtNumeroDocumento);
                cValidacionCuit.Set = CIconos.Amarillo;
                return;
            }
            
            if (txtTipoDocumento.Text == @"80")
            {
                if (mtxtNumeroDocumento.Text == @"00000000000")
                {
                    ValResult((MaskedTextBox)mtxtNumeroDocumento, "El CUIT provisto es incorrecto");
                    cValidacionCuit.Set = CIconos.Rojo;
                    return;
                }

                var y = new CuitValidation().ValidarCuit(mtxtNumeroDocumento.Text);
                if (y == false)
                {
                    ValResult((MaskedTextBox)mtxtNumeroDocumento, "El CUIT provisto es incorrecto");
                    cValidacionCuit.Set = CIconos.Rojo;
                    return;
                }
                ValResult((MaskedTextBox)mtxtNumeroDocumento);
                cValidacionCuit.Set = CIconos.Verde;
            }
            
            if (_modo == 1 && mtxtNumeroDocumento.Text != @"00000000000")
            {
                //validar si el proveedor ya existe en la base
                if (new VendorManager().CheckIfCuitExist(mtxtNumeroDocumento.Text) && string.IsNullOrEmpty(mtxtNumeroDocumento.Text) != true)
                {
                    MessageBox.Show(@"El Proveedor ya se encuentra en la base de datos", @"Proveedor Existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtxtNumeroDocumento.Text = "";
                    ValResult((MaskedTextBox)mtxtNumeroDocumento, "Se ha blanqueado el numero de CUIT porque el proveedor ya existe en el sistema");
                    cIconoClienteExiste.Set = CIconos.Rojo;
                }
                else
                {
                    cIconoClienteExiste.Set = CIconos.Tilde;
                    ValResult(mtxtNumeroDocumento);
                }
            }



        }
        private void cmbTipoProveedor_Validating(object sender, CancelEventArgs e)
        {
            if (cmbTipoProveedor.SelectedValue == null && !string.IsNullOrEmpty(cmbTipoProveedor.Text))
            {
                ValResult(cmbTipoProveedor, "El Tipo de Proveedor seleccionado es Inexistente");
            }
            else
            {
                if (string.IsNullOrEmpty(cmbTipoProveedor.Text))
                {
                    ValResult(cmbTipoProveedor, "Debe seleccionar un tipo de proveedor");
                }
                else
                {
                    ValResult(cmbTipoProveedor);
                }
            }
        }
        private void cmbTipoDocumento_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void mtxtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_modo < 3)
            {
                if (string.IsNullOrEmpty(txtTipoDocumento.Text))
                {
                    ValResult(mtxtNumeroDocumento,
                        "Antes de Ingresar un numero de Documento, debe seleccionar el Tipo de Documento");
                    e.Handled = true;
                    mtxtNumeroDocumento.Text = null;
                    return;
                }
            }
        }
        private void LoadExistingData()
        {
            var p = new VendorManager().GetSpecificVendor(_idvendor);
            if (p == null)
            {
                //blanquear screeen
                return;
            }

            txtRazonSocial.Text = p.prov_rsocial;
            txtFantasia.Text = p.prov_fantasia;
            txtVendorId.Text = p.id_prov.ToString();
            mtxtNumeroDocumento.Text = p.NTAX1;
            if (p.ACTIVO == null || p.ACTIVO == false)
            {
                ckActivo.Checked = false;
            }
            else
            {
                ckActivo.Checked = true;
            }

            if (p.TTAX1 == null) p.TTAX1 = "00";

            switch (p.TTAX1)
            {
                case "80":
                case "CUIT":
                    cmbTipoDocumento.SelectedItem = "CUIT";
                    txtTipoDocumento.Text = @"80";
                    txtCondicionIVA.Text = @"RI";
                    break;
                case "00":
                    cmbTipoDocumento.SelectedItem = "NI";
                    txtTipoDocumento.Text = @"00";
                    txtCondicionIVA.Text = @"XX";
                    break;
                case "86":
                    cmbTipoDocumento.SelectedItem = "CUIL";
                    txtTipoDocumento.Text = @"86";
                    txtCondicionIVA.Text = @"XX";
                    break;
                case "96":
                    cmbTipoDocumento.SelectedItem = "DNI";
                    txtTipoDocumento.Text = @"96";
                    txtCondicionIVA.Text = @"XX";
                    break;
            }

            cmbTipoProveedor.SelectedValue = p.TIPO;
            //hace falta mapear? o va al cmb?
            //sino mapear glvendor, ck

            txtGlSpecific.Text = p.GL;
            if (p.Cliente != null)
            {
                txtIdCliente.Text = p.Cliente.Value.ToString();
                var c = new CustomerManager().GetCustomerBillToData(p.Cliente.Value);
                txtClienteRazonSocial.Text = c.cli_rsocial;
            }

            txtObservaciones.Text = p.COMENTARIO;

            //Datos Direccion
            txtDireccion.Text = p.Direccion;
            txtCodigoPostal.Text = p.Dire_CodPostal;
            txtContacto.Text = p.Contacto;
            txtTelefono1.Text = p.Telefono;
            txtTelefono2.Text = p.Fax;
            txtEmailPedido.Text = p.EMAIL;

            if (p.IdLocalidadAddress != null)
            {
                ctlAddress1.CargaControl(p.IdLocalidadAddress.Value);
            }
            else
            {
                ctlAddress1.CargaControl(p.Dire_Pais, p.Dire_Provincia, p.Partido, p.Dire_Localidad);
            }


            //Tax Data---
            var rgs = TaxModuleVendorManager.GetTaxForVendor(_idvendor, "EXRETGS");
            if (rgs == null)
            {
                ckExentoRetencionGanancias.Checked = false;
                txtNumeroCertificadoRgs.Text = null;
                dtRGsExentoDesde.Value = DateTime.Today.AddYears(-10);
                dtRGsExentoHasta.Value = DateTime.Today.AddYears(-10);
            }
            else
            {
                ckExentoRetencionGanancias.Checked = rgs.Exento;
                dtRGsExentoDesde.Value = rgs.FechaDesde;
                dtRGsExentoHasta.Value = rgs.FechaHasta;
                txtNumeroCertificadoRgs.Text = rgs.Certificado;
            }

            var rgArba = TaxModuleVendorManager.GetTaxForVendor(_idvendor, "EXRETIIBB");
            if (rgArba == null)
            {
                ckExentoRetencionGanancias.Checked = false;
                txtNumeroCertificadoRgs.Text = null;
                dtRGsExentoDesde.Value = DateTime.Today.AddYears(-10);
                dtRGsExentoHasta.Value = DateTime.Today.AddYears(-10);
            }
            else
            {
                ckExentoRetencionGanancias.Checked = rgArba.Exento;
                dtRGsExentoDesde.Value = rgArba.FechaDesde;
                dtRGsExentoHasta.Value = rgArba.FechaHasta;
                txtNumeroCertificadoRgs.Text = rgArba.Certificado;
            }

            //Datos de Pago
            if (string.IsNullOrEmpty(p.ZTERM))
            {
                cmbZtermL1.SelectedValue = "0E";
            }
            else
            {
                cmbZtermL1.SelectedValue = p.ZTERM;
            }

            txtCuentaBanco.Text = p.BANK_ACC;
            txtIdRaffone.Text = p.IDRAF;

            txtLogUsuario.Text = p.LOG_USER;
            if (p.Fecha_Ingreso != null)
            {
                txtLogFecha.Text = p.Fecha_Ingreso.Value.ToString("d");
            }

            if (p.Ultimo_Movimiento != null)
            {
                txtUltimoMovimiento.Text = p.Ultimo_Movimiento.Value.ToString("d");
            }

            if (p.LOG_DATE != null)
            {
                txtLogDate.Text = p.LOG_DATE.Value.ToString("g");
            }
            mtxtNumeroDocumento.Text = p.NTAX1;
        }
        private void btnAutoComplete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtNumeroDocumento.Text))
            {
                MessageBox.Show(@"Debe completar el numero de CUIT para poder obtener la info desde el WebServices",
                    @"WebService AFIP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtTipoDocumento.Text != @"80")
            {
                MessageBox.Show(@"Esta funcionalidad funciona unicamente para CUIT validados",
                    @"WebService AFIP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var f = new FrmAPP04_DatosPadron(mtxtNumeroDocumento.Text, txtTipoDocumento.Text))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (f.IdLocalidad > 0)
                    {
                        ctlAddress1.CargaControl(f.IdLocalidad);
                    }
                    else
                    {
                        ctlAddress1.CargaControl("AR", f.cn.Provincia, "", f.cn.Localidad);
                    }
                    
                    if (f.cn.Estado != "ACTIVO")
                    {
                        MessageBox.Show(@"El CUIT del proveedor se encuentra INACTIVO en AFIP", @"Atencion Proveedor INACTIVO",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    txtRazonSocial.Text = f.cn.Denominacion;
                    txtRazonSocial.ForeColor = Color.Red;
                    if (string.IsNullOrEmpty(txtFantasia.Text))
                    {
                        txtFantasia.Text = f.cn.Denominacion;
                        txtFantasia.ForeColor = Color.Red;
                    }

                    txtDireccion.Text = f.cn.Direccion;
                    txtDireccion.ForeColor = Color.Red;
                    txtCodigoPostal.Text = f.cn.CodPostal;
                    txtCodigoPostal.ForeColor = Color.Red;
                   
                    if (f.cn.TipoDocumento == 80)
                    {
                        cmbTipoDocumento.SelectedItem = "CUIT";
                        txtCondicionIVA.Text = @"RI";
                        txtCondicionIVA.ForeColor = Color.Red;
                    }
                }
            }


            //var r = MessageBox.Show(@"Desea obtener los datos del proveedor desde el Padron AFIP?", @"WebService AFIP",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (r == DialogResult.No) return;

            //Cursor.Current = Cursors.WaitCursor;
            //var cn = new PadronAfipWsA5(ModoEjecucion.Produccion).ObtieneDatosPadronA5(mtxtNumeroDocumento.Text);
            //if (string.IsNullOrEmpty(cn.Denominacion))
            //{
            //    MessageBox.Show(
            //        $@"No se pudieron obetner datos del CUIT {mtxtNumeroDocumento.Text} en forma automatica",
            //        @"Error en Info Retornada", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return;
            //}

           
            Cursor.Current = Cursors.Default;


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            _validacionOK = true;
            this.ValidateChildren();
            if (_validacionOK)
            {
                var data = MapScreenToDb();
                var resultado = new VendorManager().GuardaCambiosVendor(MapScreenToDb());
                if (resultado < 0)
                {
                    MessageBox.Show(@"Error al Crear o Actualizar el Vendor", @"Error Inesperado", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                if (resultado == 0)
                {
                    MessageBox.Show(@"Los datos se han Actualizado Correctamente", @"Actualizacion de Datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (resultado > 0)
                {
                    MessageBox.Show(@"Se ha creado correctamente el Proveedor con el siguiente numero: #" + resultado,
                        @"Creacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _idvendor = resultado;
                    txtVendorId.Text = _idvendor.ToString();
                    if (_modo == 1)
                        _modo = 2;
                    LoadExistingData();
                }
            }
            else
            {
                MessageBox.Show(@"Los datos no están completos o están incorrectos" + Environment.NewLine + "" +
                                @"El Proveedor sera grabado cuando todos los errores esten solucionados",
                    @"No se Grabo el Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtRazonSocial_Enter(object sender, EventArgs e)
        {
            var contro = (TextBox) sender;
            if (_modo < 3 || _modo>5)
            {
                contro.ForeColor = Color.Black;
            }

        }

        private void txtCondicionIVA_Validated(object sender, EventArgs e)
        {
            if (txtCondicionIVA.Text != @"RI")
            {
                if (MessageBox.Show(@"Confirma valor distinto a RI ?", @"Confirmacion de Valor Ingresado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    txtCondicionIVA.Text = @"RI";
                }
            }
        }

        private void mtxtNumeroDocumento_Validated(object sender, EventArgs e)
        {
            if (_modo < 3 || _modo == 6)
            {
                if (txtTipoDocumento.Text == @"80")
                {
                    var p = new CustomerManager().ReturnCustomerByCuit(mtxtNumeroDocumento.Text, "80");
                    if (p != null)
                    {
                        txtIdCliente.Text = p.IDCLIENTE.ToString();
                        txtClienteRazonSocial.Text = p.cli_rsocial;
                        txtIdCliente.BackColor = Color.LightGoldenrodYellow;
                        txtClienteRazonSocial.BackColor= Color.LightGoldenrodYellow;
                        var r = MessageBox.Show(
                            @"Se ha encontrado a este proveedor dado de alta como cliente en nuestro sistema" +
                            Environment.NewLine + @"Desea traer la inforamcion disponible?",
                            @"Proveedor Existente como Cliente", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            txtFantasia.Text = p.cli_fantasia + @"[P]";
                            txtRazonSocial.Text = p.cli_rsocial;
                            cmbTipoDocumento.SelectedItem = "CUIT";
                            txtCondicionIVA.Text = @"RI";
                            txtTelefono1.Text = p.Telefono_Venta;
                            txtDireccion.Text = p.Direccion_facturacion;
                            txtCodigoPostal.Text = p.ZIP;
                            if (p.IdLocalidadAddress != null)
                            {
                                ctlAddress1.CargaControl(p.IdLocalidadAddress.Value);
                            }
                            else
                            {
                                ctlAddress1.CargaControl(p.Pais, p.Direfactu_Provincia, p.Direfactu_Partido,
                                    p.Direfactu_Localidad);
                            }
                            txtFantasia.ForeColor = Color.Red;
                            txtRazonSocial.ForeColor = Color.Red;
                            txtCondicionIVA.ForeColor = Color.Red;
                            txtDireccion.ForeColor = Color.Red;
                            txtCodigoPostal.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
