using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MASngFE.SuperMD;
using MASngFE.Transactional.CRM;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.MasterData.Material_Master;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.VBTools;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.MasterData.Customer_Master
{
    public partial class FrmMdc02BillTo : Form
    {
        //Parametro1 
        //modo [1,2,3]
        //idCliente [-1 ninguno]
        //funcion (md)
        public FrmMdc02BillTo(int modo, int idCliente, string funcion)
        {
            //Si modo =1 > idcliente -1 (new)
            _modo = modo;
            if (_modo == 1)
                idCliente = -1;

            _funcion = funcion;
            _idCliente6 = idCliente;
            InitializeComponent();
        }

        //modo Creacion
        public FrmMdc02BillTo(int modo, string funcion)
        {
            _modo = 1;
            _funcion = "md";
            _idCliente6 = -1;
            InitializeComponent();
        }
        //----------------------------------------------------------------------------------------------------
        private readonly int _modo;
        private readonly string _funcion;
        private int _idCliente6;
        private readonly NewAddressManager addressManager = new NewAddressManager();
        private Color _colorNoDef = Color.Black;
        private readonly Color _colorOk = Color.LightGreen;
        private readonly Color _colorNo = Color.IndianRed;
        private readonly Color _colorInicial = Color.OrangeRed;
        //----------------------------------------------------------------------------------------------------

        private void FrmCustomerMasterScreen1_Load(object sender, EventArgs e)
        {
            ConfiguracionInicialControles();
            AccionSegunModo();
            AccionSegunFuncion();
        }
        private void ConfiguracionInicialControles()
        {
            txtPais.Text = @"AR";
            txtPaisDescripccion.Text = @"ARGENTINA";
            //provinciaBs.DataSource = _billAddress.GetlistadoProvincias("AR");
            //cmbFProvincia.SelectedIndex = -1;
            txtProvinciaID.BackColor = _colorInicial;
            txtLocalidadID.BackColor = _colorInicial;
            txtPartidoID.BackColor = _colorInicial;
            Zterm1Bs.DataSource = new ZtermManager().GetCompleteListOfZterms();
            Zterm2Bs.DataSource = new ZtermManager().GetCompleteListOfZterms();
            cmbZtermL1.SelectedIndex = -1;
            cmbZtermL2.SelectedIndex = -1;
            personalCobBs.DataSource = new HumanResourcesManager().GetListAllActiveCobrador();
            cmbCobrador.SelectedIndex = -1;
            txtmodo.Text = _modo.ToString();
            txtfn.Text = _funcion;
            //SeteaProperitesComboboxAddress();  //Activa los selectedIndex
        }
        private void AccionSegunModo()
        {
            btnActivarCliente.Enabled = true;
            btnInactivaCliente.Enabled = true;
            btnFEstructuraDirecciones.Enabled = true;
            switch (_modo)
            {
                case 1:
                    this.Text = @"**MDC02 - Creacion de Nuevo Cliente**";
                    cmbZtermL1.SelectedValue = "0E";
                    cmbZtermL2.SelectedValue = "0E";
                    txtLimiteCreditoMaximo.Text = 0.ToString("C2");
                    LimiteCreditoDays.Text = @"0";
                    ckActivo.Checked = true;
                    break;
                case 2:
                    LoadExistingData();
                    this.Text = $@"MDC02 - Modificacion de Cliente: {txtRazonSocial.Text} - [Datos Facturacion]";
                    break;
                case 3:
                    LoadExistingData();
                    this.Text = $@"MDC02 - Visualizacion de Cliente: {txtRazonSocial.Text} - [Datos Facturacion]";
                    btnGuardarCambios.Enabled = false;
                    tbBillTo.Enabled = false;
                    tbFiData.Enabled = false;
                    tbPayer.Enabled = false;
                    tbShipTo.Enabled = true;
                    panFIData.Enabled = false;
                    panGesco.Enabled = false;
                    panVarios.Enabled = false;
                    dgvShipTo.Enabled = true;
                    btnActivarCliente.Enabled = false;
                    btnInactivaCliente.Enabled = false;
                    btnFEstructuraDirecciones.Enabled = false;
                    btnAddShipto.Enabled = false;
                    break;
                default:
                    MessageBox.Show(@"Este modo no esta soportado por la aplicacion", @"Funcionalidad Limitada",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void AccionSegunFuncion()
        {
            switch (_funcion.ToUpper())
            {
                case "MD":
                    break;

                default:
                    MessageBox.Show($"Funcion {_funcion} Inexistente", @"Customer MD", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    break;
            }
        }
        private void LoadExistingData()
        {
            if (_idCliente6 <= 0) throw new Exception(@"Datos no Encontrados");

            var h = new CustomerManager().GetCustomerBillToData(_idCliente6);
            txtId6.Text = _idCliente6.ToString();

            ckActivo.Checked = h.ACTIVO;
            txtStatusCliente.Text = h.ACTIVO ? @"Activo" : @"Inactivo";
            semClienteActivo.SetLights =
                h.ACTIVO ? CtlSemaforo.ColoresSemaforo.Verde : CtlSemaforo.ColoresSemaforo.Rojo;
            if (h.ACTIVO)
            {
                txtStatusCliente.Text = @"Activo";
                btnActivarCliente.Visible = false;
                btnInactivaCliente.Visible = true;
                semClienteActivo.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            }
            else
            {
                txtStatusCliente.Text = @"Inactivo";
                btnActivarCliente.Visible = true;
                btnInactivaCliente.Visible = false;
                semClienteActivo.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            }

            semStatusBloqueoPedido.SetLights =
                h.BLK_PEDIDO ? CtlSemaforo.ColoresSemaforo.Rojo : CtlSemaforo.ColoresSemaforo.Verde;
            semStatusBloqueoEntrega.SetLights =
                h.BLK_DELIVERY ? CtlSemaforo.ColoresSemaforo.Rojo : CtlSemaforo.ColoresSemaforo.Verde;
            ckBloqueoEntrega.Checked = h.BLK_DELIVERY;
            ckBloqueoPedido.Checked = h.BLK_PEDIDO;

            txtRazonSocial.Text = h.cli_rsocial;
            txtFantasia.Text = h.cli_fantasia;
            txtNumeroTax.Text = h.CUIT;
            txtNombreAnterior.Text = h.NombreAnterior;

            switch (h.TTAX)
            {
                case "80":
                    cmbTipoTax.SelectedText = "CUIT";
                    txtCodigoTax.Text = @"80";
                    if (new CuitValidation().ValidarCuit(txtNumeroTax.Text))
                    {
                        txtTaxValido.Text = @"VALIDO";
                        txtTaxValido.BackColor = Color.MediumSeaGreen;
                    }
                    else
                    {
                        txtTaxValido.Text = @"INVALIDO";
                        txtTaxValido.BackColor = Color.OrangeRed;
                    }

                    break;
                case "96":
                    cmbTipoTax.SelectedText = "DNI";
                    txtCodigoTax.Text = @"96";
                    txtTaxValido.Text = @"SIN VALIDAR";
                    txtTaxValido.BackColor = Color.LightBlue;
                    txtNumeroTax.BackColor = Color.LightBlue;
                    break;
                default:
                    cmbTipoTax.SelectedText = "NI";
                    txtCodigoTax.Text = @"00";
                    txtTaxValido.Text = @"SIN VALIDAR";
                    txtTaxValido.BackColor = Color.Yellow;
                    break;
            }

            ckClienteOcasional.Checked = h.UNTIPO;

            //Panel Varios
            cmbRubro.SelectedItem = h.ClienteRubro;
            txtObservaciones.Text = h.Comentario;

            //Facturacion - Address
            txtDireccion.Text = h.Direccion_facturacion;
            txtDireccionNumero.Text = h.DireFactu_Num;
            txtCodigoPostal.Text = h.ZIP;
            txtEmailFacturacion.Text = h.EMAIL_FACTU;
            txtZona.Text = h.Direfactu_Zona;
            txtDireccionValidadaGoogleMaps.Text = h.DireccionGoogleMaps;

            if (h.Pais == null)
            {
                h.Pais = "AR";
            }

            if (h.Pais == @"AR")
                txtPaisDescripccion.Text = @"ARGENTINA";

            txtProvincia.Text = h.Direfactu_Provincia;
            txtPartido.Text = h.Direfactu_Partido;
            txtLocalidad.Text = h.Direfactu_Localidad;

            addressManager.SetValoresSinValidar(txtPais.Text, txtProvincia.Text, txtPartido.Text, txtLocalidad.Text);
            ReMapeaDireccionValidada(addressManager.GetSeleccion());
            txtCrmInfo.Text = new CRMMensajeInterno().GetMensajeInterno(_idCliente6);

            //FiDATA
            if (h.AllowL1 == null)
                h.AllowL1 = false;

            if (h.AllowL2 == null)
                h.AllowL2 = false;

            if (h.AllowL5 == null)
                h.AllowL5 = false;
            ckL1.Checked = h.AllowL1.Value;
            ckL2.Checked = h.AllowL2.Value;
            ckL5.Checked = h.AllowL5.Value;
            cmbZtermL1.SelectedValue = h.ZTERML1 ?? "0E";
            cmbZtermL2.SelectedValue = h.ZTERML2 ?? "0E";

            ckUtilizarLimiteAutomatico.Checked = h.AutoCreditLimit;
            LimiteCreditoDays.Text = h.AutoCreditLimitDays.ToString();
            txtLimiteCreditoMaximo.Text = h.Limite_credito?.ToString("C2") ?? 0.ToString("C2");
            txtDescuentoPorcentaje.Text = h.Descuento?.ToString("P2") ?? 0.ToString("P2");
            txtMotivoDescuento.Text = h.MotivoDescuento;
            //
            var cta = new CtaCteCustomer(_idCliente6);
            var deudaTotal = (cta.GetResultadoCtaCte("L1").SaldoDetalle + cta.GetResultadoCtaCte("L2").SaldoDetalle);
            if (h.Limite_credito == null)
                h.Limite_credito = 0;

            txtLimiteCreditoMaximo.Text = h.Limite_credito.Value.ToString("C2");
            ckIncluirSaldo.Checked = h.SCCL2;

            //if (deudaTotal > h.Limite_credito.Value)
            //{
            //    //redCredito.Visible = true;
            //    MessageBox.Show(
            //        @"Atencion el Cliente Excede Limite de Credito Asignado - Inicie Accion de GESCO",
            //        @"Excede Limite", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //else
            //{
            // //   greenCredito.Visible = true;
            //}


            //Datos Cobranza
            if (string.IsNullOrEmpty(h.DIRECCION_COBRO_ALT))
            {
                ckCobroDireccionFiscal.Checked = true;
                txtPDireccionCompleta.BackColor = Color.DarkSeaGreen;
            }
            else
            {
                ckCobroDireccionFiscal.Checked = false;
                txtPDireccionCompleta.Text = h.DIRECCION_COBRO_ALT;
                txtPDireccionCompleta.BackColor = Color.White;
            }

            txtPNombreContacto.Text = h.CONTACTO_COB;
            txtPTelefno1.Text = h.TELEFONO_COB;
            txtPTelefno2.Text = h.TelefonoCobranza2;
            txtPEmail.Text = h.EMAIL_COBR;
            txtPDiasPaP.Text = h.DIA_HORARIO_COBRO;

            if (h.COBRADOR != null)
            {
                cmbCobrador.SelectedValue = h.COBRADOR;
            }
            else
            {
                cmbCobrador.SelectedIndex = -1;
            }
            ckRequiereGesco.Checked = h.GC;

            //ShipTos
            var numShipto = new CustomerManager().GetNumberofShipTos(_idCliente6, true);
            txtCantidadShiptoActivo.Text = numShipto.ToString();
            if (numShipto == 0)
            {
                MessageBox.Show(@"Atencion: El Cliente no posee ningun SHIPTO activo", @"No Existe ShipTo Disponible",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            t0007Bs.DataSource = new CustomerManager().GetShipToListFromBillTo(_idCliente6,
                false);

            //Datos Log Abajo
            txtLogCreadoPor.Text = h.LogCreadoPor;
            if (h.Fecha_Ingreso != null)
                txtLogCreadoEn.Text = h.Fecha_Ingreso.Value.ToString("d");
            if (h.LogModoficadoEn != null)
                txtLogModificadoEn.Text = h.LogModoficadoEn.Value.ToString("d");
            txtLogModificadoPor.Text = h.LogModificadoPor;
            if (h.Ultimo_Movimiento != null)
                txtUltimoMovimiento.Text = h.Ultimo_Movimiento.Value.ToString("d");

            tLogBloqueoClientesBindingSource.DataSource =
                new CustomerMDActionsAndLog().GetHistorialMovimientosBloqueo(_idCliente6);

            //string address = "123 something st, somewhere";
            //address = h.Direccion_facturacion + "," + h.Direfactu_Localidad;
            //address = "Pampa 981, Valentín Alsina, Provincia de Buenos Aires";
            //string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            //WebRequest request = WebRequest.Create(requestUri);
            //WebResponse response = request.GetResponse();
            //XDocument xdoc = XDocument.Load(response.GetResponseStream());

            //XElement result = xdoc.Element("GeocodeResponse").Element("result");
            //XElement locationElement = result.Element("geometry").Element("location");
            //XElement lat = locationElement.Element("lat");
            //XElement lng = locationElement.Element("lng");

        }
        private void ReMapeaDireccionValidada(NewAddressManager.EstructuraSeleccionada data)
        {
            txtPais.Text = data.Pais;
            if (data.Pais == @"AR")
                txtPaisDescripccion.Text = @"ARGENTINA"; //hardcoded!
            txtProvincia.Text = data.Provincia;
            txtPartido.Text = data.Partido;
            txtLocalidad.Text = data.Localidad;
            txtLocalidadID.Text = null;
            txtProvinciaID.Text = null;
            txtPartidoID.Text = null;

            if (data.IdProvincia == null)
            {
                semProvincia.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtProvinciaID.BackColor = _colorNo;
            }
            else
            {
                txtProvinciaID.Text = data.IdProvincia.ToString();
                semProvincia.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtProvinciaID.BackColor = _colorOk;
            }

            if (data.IdPartido == null)
            {
                semPartido.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtPartidoID.BackColor = _colorNo;
            }
            else
            {
                txtPartidoID.Text = data.IdPartido.ToString();
                semPartido.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtPartidoID.BackColor = _colorOk;
            }

            if (data.IdLocalidad == null)
            {
                semLocalidad.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtLocalidadID.BackColor = _colorNo;
            }
            else
            {
                txtLocalidadID.Text = data.IdLocalidad.ToString();
                semLocalidad.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtLocalidadID.BackColor = _colorOk;
            }
        }
        private void btnPadronAfip_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroTax.Text))
            {
                MessageBox.Show(@"Debe proveer un numero de CUIT Validdo para visualizar los Datos del Padron Afio",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtTaxValido.Text != @"VALIDO")
            {
                MessageBox.Show(@"Debe proveer un CUIT Valido para poder utilizr esta funcion", @"Datos Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var f0 = new FrmUt01ObtieneDatosPadronAFIP(txtNumeroTax.Text, "CMD"))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (_modo != 3)
                    {
                        var _dir = txtDireccion.Text;
                        var _pro = txtProvincia.Text;
                        var _par = txtPartido.Text;
                        var _loc = txtLocalidad.Text;
                        var _zip = txtCodigoPostal.Text;
                        var _rso = txtRazonSocial.Text;

                        var rtn = f0.Estructura;
                        txtDireccion.Text = rtn.Direccion;
                        txtProvincia.Text = rtn.Provincia;
                        txtPartido.Text = null;
                        txtLocalidad.Text = rtn.Localidad;
                        txtCodigoPostal.Text = rtn.CodPostal;
                        txtRazonSocial.Text = rtn.Denominacion;

                        txtDireccion.ForeColor = txtDireccion.Text != _dir ? _colorInicial : _colorNoDef;
                        txtProvincia.ForeColor = txtProvincia.Text != _pro ? _colorInicial : _colorNoDef;
                        txtPartido.ForeColor = txtPartido.Text != _par ? _colorInicial : _colorNoDef;
                        txtLocalidad.ForeColor = txtLocalidad.Text != _loc ? _colorInicial : _colorNoDef;
                        txtCodigoPostal.ForeColor = txtCodigoPostal.Text != _zip ? _colorInicial : _colorNoDef;
                        txtRazonSocial.ForeColor = txtRazonSocial.Text != _rso ? _colorInicial : _colorNoDef;
                    }
                }
            }
        }
        private void MapeaDireccionConId(NewAddressManager.EstructuraSeleccionada data)
        {
            txtPais.Text = data.Pais;
            txtPaisDescripccion.Text = @"ARGENTINA"; //hardcoded!
            txtProvincia.Text = data.Provincia;
            txtPartido.Text = data.Partido;
            txtLocalidad.Text = data.Localidad;
            txtLocalidadID.Text = null;
            txtProvinciaID.Text = null;
            txtPartidoID.Text = null;

            if (data.IdProvincia == null)
            {
                semProvincia.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtProvinciaID.BackColor = _colorNo;
            }
            else
            {
                txtProvinciaID.Text = data.IdProvincia.ToString();
                semProvincia.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtProvinciaID.BackColor = _colorOk;
            }


            if (data.IdPartido == null)
            {
                semPartido.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtPartidoID.BackColor = _colorNo;
            }
            else
            {
                txtPartidoID.Text = data.IdPartido.ToString();
                semPartido.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtPartidoID.BackColor = _colorOk;
            }

            if (data.IdLocalidad == null)
            {
                semLocalidad.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtLocalidadID.BackColor = _colorNo;
            }
            else
            {
                txtLocalidadID.Text = data.IdLocalidad.ToString();
                semLocalidad.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtLocalidadID.BackColor = _colorOk;
            }
        }
        private void btnFEstructuraDirecciones_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmSMD01_AddressStructure(txtPais.Text, txtProvincia.Text, txtPartido.Text,
                txtLocalidad.Text, txtCodigoPostal.Text, txtZona.Text))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var z = f0.Address.GetSeleccion();
                    MapeaDireccionConId(z);
                }
            }
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            DialogResult resp = DialogResult.No;

            if (ValidateAllMandatoryFields() == false)
                return;

            if (_idCliente6 == -1)
            {
                //Alta Cliente Nuevo
                resp =
                    MessageBox.Show(
                        @"El Cliente NO tiene ningun SHIPTO asociado" + Environment.NewLine +
                        @"Desea crear un SHIPTO Automaticamente con la direccion Fiscal del Cliente?",
                        @"Creacion ShipTo Automatico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    ManejaAltaShipToAutomatica();
                }
                else
                {
                    resp =
                        MessageBox.Show(
                            @"Confirma la Creacion de BillTO sin ShipTO?" + Environment.NewLine +
                            @"Hasta que no exista el ShipTO no se podrá ingresar pedidos",
                            @"Alerta Cliente Incompleto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.Yes)
                    {
                        SetCreacionBillTo();
                        if (_idCliente6 == -1)
                        {
                            MessageBox.Show(@"Ha Ocurrido un Error en la Creacion del BillTO del Cliente",
                                @"Error en Creacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                resp = MessageBox.Show(@"Confirma la modificacion del cliente Existente?", @"Confirmacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resp == DialogResult.No)
                    return;

                //Modificacion Cliente Existente (modo2)
                var rtn = new AbmCustomerMaster().SaveT6Data(MapScreenT6());
                if (rtn == _idCliente6)
                {
                    MessageBox.Show(@"Los cambios se han guardado correctamente!", @"Modificacion de Cliente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CustomerMDActionsAndLog.ModificacionCliente(_idCliente6);
                }
                else
                {
                    if (rtn == 0)
                    {
                        MessageBox.Show(@"No se han encontrado cambios para guardar", @"Modificacion de Cliente",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(@"Ha ocurrido un error al intentar guardar los cambios del cliente",
                            @"Modificacion de Cliente",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ManejaAltaShipToAutomatica()
        {
            SetCreacionBillTo();
            var f = new FrmMdc03ShipToData(_idCliente6);
            f.ShowDialog();
            t0007Bs.DataSource = new CustomerManager().GetShipToListFromBillTo(_idCliente6,
                false);

            //SetC

            //1.- Alta del BillTo
            //2.- Alta del ShipTo (si se cancela - se borra el alta) 


            //Se realiza en forma manual desde el boton AddShipto
            //1.-Se crea el BillTo (si se cancela - se borra el alta)


        }
        private int SetCreacionBillTo()
        {
            var idClienteCreado = new AbmCustomerMaster().SaveT6Data(MapScreenT6());
            if (idClienteCreado == -1)
            {
                MessageBox.Show(@"Ha Ocurrido un error inesperado al Intentar Crear el Cliente. Intente nuevamente", @"Error en Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }

            if (_idCliente6 == -1)
            {
                _idCliente6 = idClienteCreado;
                CustomerMDActionsAndLog.CreacionCliente(_idCliente6);
            }
            txtId6.Text = _idCliente6.ToString();
            new CtaCteCustomer(_idCliente6).AddNewCtaCteSummaryRecord("L1");
            new CtaCteCustomer(_idCliente6).AddNewCtaCteSummaryRecord("L2");
            return _idCliente6;
        }
        private bool ValidateCamposPanelPrincipal()
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                MessageBox.Show(@"Debe completar la Razon Social del Cliente", @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (txtRazonSocial.Text.Length > 200)
            {
                MessageBox.Show(@"La Razon Social del Cliente no puede superar los 200 caracteres",
                    @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (string.IsNullOrEmpty(txtFantasia.Text))
            {
                MessageBox.Show(@"Debe completar el Nombre Fantasia del Cliente", @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (txtFantasia.Text.Length > 50)
            {
                MessageBox.Show(@"El Nombre Fantasia del Cliente no puede superar los 50 caracteres",
                    @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (txtNombreAnterior.Text.Length > 50)
            {
                MessageBox.Show(@"El Nombre Anterior del Cliente no puede superar los 50 caracteres",
                    @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (cmbTipoTax.Text == @"CUIT")
            {
                if (txtTaxValido.Text != @"VALIDO")
                {
                    MessageBox.Show(@"El Numero de CUIT es INVALIDO", @"Datos faltantes o invalidos",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            return true;
        }
        private bool ValidateFacturacionData()
        {
            if (ckClienteOcasional.Checked)
            {
                //validaciones que sean necesarias para un cliente ocasional
                return true;
            }

            //Validaciones Para clientes standard
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show(@"Debe completar el campo Direccion(Calle)", @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (string.IsNullOrEmpty(txtPais.Text))
            {
                MessageBox.Show(@"Debe completar el PAIS", @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (string.IsNullOrEmpty(txtProvincia.Text))
            {
                MessageBox.Show(@"Debe completar la PROVINCIA", @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(txtProvinciaID.Text))
                {
                    var msg =
                        MessageBox.Show(
                            @"La PROVINCIA NO se encuentra validada con los datos maestros" + Environment.NewLine +
                            @"Desea Continuar con datos sin validar?", @"Validacion de Datos",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                    if (msg == DialogResult.No)
                        return false;
                }
            }

            if (string.IsNullOrEmpty(txtPartido.Text))
            {
                MessageBox.Show(@"Debe completar el PARTIDO", @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(txtPartido.Text))
                {
                    var msg =
                        MessageBox.Show(
                            @"El PARTIDO NO se encuentra validada con los datos maestros" + Environment.NewLine +
                            @"Desea Continuar con datos sin validar?", @"Validacion de Datos",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                    if (msg == DialogResult.No)
                        return false;
                }
            }

            //La localidad NO es obligatoria
            if (string.IsNullOrEmpty(txtLocalidadID.Text) && !string.IsNullOrEmpty(txtLocalidad.Text))
            {
                var msg =
                    MessageBox.Show(
                        @"La LOCALIDAD no se encuentra validada con los datos maestros" + Environment.NewLine +
                        @"Desea Continuar con datos sin validar?", @"Validacion de Datos", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                    return false;
            }

            //** Esto es si la LOCALIDAD fuera OBLIGATORIA

            //if (string.IsNullOrEmpty(cmbFLocalidad.Text))
            //{
            //    MessageBox.Show(@"Debe completar la LOCALIDAD", @"Datos faltantes o invalidos",
            //        MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //    return false;
            //}
            //else
            //{
            //    if (cmbFLocalidad.SelectedValue == null)
            //    {
            //        var msg =
            //            MessageBox.Show(
            //                @"La LOCALIDAD no se encuentra validada con los datos maestros" + Environment.NewLine +
            //                @"Desea Continuar con datos sin validar?", @"Validacion de Datos", MessageBoxButtons.YesNo,
            //                MessageBoxIcon.Question);
            //        if (msg == DialogResult.No)
            //            return false;
            //    }
            //}

            return true;
        }
        private bool ValidateFiData()
        {
            if (ckClienteOcasional.Checked)
            {
                //validaciones que sean necesarias para un cliente ocasional
                return true;
            }

            if (ckL1.Checked == true || ckL2.Checked == true || ckL5.Checked == true)
            {

            }
            else
            {
                MessageBox.Show(@"No Existe ninguna condicion de venta autorizada para este Cliente", @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (ckL5.Checked == false)
            {
                //completa la condicion de pago en 0E cuando no esta autorizada
                if (ckL1.Checked == false)
                    cmbZtermL1.SelectedValue = @"0E";
                if (ckL2.Checked == false)
                    cmbZtermL2.SelectedValue = @"0E";
            }

            if (cmbZtermL1.SelectedValue == null)
            {
                MessageBox.Show(@"La condicion de Venta L1 es INEXISTENTE", @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (cmbZtermL2.SelectedValue == null)
            {
                MessageBox.Show(@"La condicion de Venta L2 es INEXISTENTE (Se coloca 0 en forma Automatica)",
                    @"Datos faltantes o invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                cmbZtermL2.SelectedValue = @"0";
                return false;
            }

            if (ckUtilizarLimiteAutomatico.Checked == false)
            {
                if (string.IsNullOrEmpty(txtLimiteCreditoMaximo.Text))
                {
                    txtLimiteCreditoMaximo.Text = 0.ToString("C2");
                }
            }

            if (string.IsNullOrEmpty(txtDescuentoPorcentaje.Text))
            {
                txtDescuentoPorcentaje.Text = 0.ToString("P2");
            }
            else
            {
                var valorP = FormatAndConversions.CPorcentajeADecimal(txtDescuentoPorcentaje.Text);
                if (valorP > 0)
                {
                    if (string.IsNullOrEmpty(txtMotivoDescuento.Text))
                    {
                        MessageBox.Show(
                            @"Debe especificar el motivo del descuento especial (Siempre o Si Pasa X Situacion)",
                            @"Datos faltantes o invalidos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
            }
            return true;
        }
        private bool ValidatePayerData()
        {
            if (ckCobroDireccionFiscal.Checked == false)
            {
                if (string.IsNullOrEmpty(txtPDireccionCompleta.Text))
                {
                    MessageBox.Show(
                        @"Debe completar la Direccion de Pago del Cliente (puede copiar la direccion fiscal)",
                        @"Datos faltantes o invalidos",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            else
            {

            }

            if (cmbZtermL1.SelectedValue.ToString() != "0" && cmbZtermL1.SelectedValue.ToString() != "0E")
            {
                if (string.IsNullOrEmpty(txtPTelefno1.Text))
                {
                    MessageBox.Show(
                        @"Si la condicion de pago L1 es diferente a 0/0E debe proveer un telefono/nombre de Contacto",
                        @"Datos faltantes o invalidos",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }

            if (cmbZtermL2.SelectedValue.ToString() != "0" && cmbZtermL2.SelectedValue.ToString() != "0E")
            {
                if (string.IsNullOrEmpty(txtPTelefno1.Text))
                {
                    MessageBox.Show(
                        @"Si la condicion de pago L2 es diferente a 0/0E debe proveer un telefono/nombre de Contacto",
                        @"Datos faltantes o invalidos",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }

            return true;
        }
        private bool ValidateAllMandatoryFields()
        {
            if (ValidateCamposPanelPrincipal() == false)
                return false;

            if (ValidateFacturacionData() == false)
                return false;

            if (ValidateFiData() == false)
                return false;

            if (ValidatePayerData() == false)
                return false;
            return true;
        }
        private void txtNumeroTax_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtNumeroTax.BackColor = Color.OrangeRed;
            txtTaxValido.Text = @"SIN VALIDAR";
            toolTip1.ToolTipTitle = "Datos Incorrectos";
            toolTip1.Show("El CUIT Provisto es Incorrecto", txtNumeroTax,
                txtNumeroTax.Location, 5000);
        }
        private void txtNumeroTax_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNumeroTax.MaskFull)
            {
                if (txtCodigoTax.Text == @"80")
                {
                    var validado = new CuitValidation().ValidarCuit(txtNumeroTax.Text);
                    if (!validado)
                    {
                        txtTaxValido.Text = @"INCORRECTO";
                        toolTip1.ToolTipTitle = "Datos Incorrectos";
                        toolTip1.Show("El CUIT Provisto es Incorrecto", txtNumeroTax,
                            txtNumeroTax.Location, 5000);
                        txtNumeroTax.BackColor = Color.OrangeRed;
                    }
                    else
                    {
                        txtTaxValido.Text = @"VALIDO";
                        txtNumeroTax.BackColor = Color.GreenYellow;
                    }
                }
                else
                {
                    txtTaxValido.Text = @"SIN VALIDAR";
                    txtNumeroTax.BackColor = Color.CornflowerBlue;
                }

            }
            else
            {
                txtTaxValido.Text = @"SIN VALIDAR";
                toolTip1.ToolTipTitle = "Datos Incorrectos";
                toolTip1.Show("Complete los 12 Digitos del CUIT para realizar la Validacion", txtNumeroTax,
                    txtNumeroTax.Location, 5000);
                txtNumeroTax.BackColor = Color.Yellow;
            }
        }

        #region Funcionalidad CombosAddress



        //    private void cmbFProvincia_SelectedIndexChanged(object sender, EventArgs e)
        //    {
        //        //ok
        //        if (cmbFProvincia.SelectedIndex == -1)
        //        {
        //            _billAddress.SetProvinciaSeleccionada(null);
        //            txtFProvinciaId.BackColor = Color.Orange;
        //            txtFProvinciaId.Text = null;
        //        }
        //        else
        //        {
        //            _billAddress.SetProvinciaSeleccionada(Convert.ToInt32(cmbFProvincia.SelectedValue));
        //            txtFProvinciaId.Text = cmbFProvincia.SelectedValue.ToString();
        //            txtFProvinciaId.BackColor = Color.LawnGreen;
        //        }

        //        partidoBs.DataSource = _billAddress.GetListadoPartido();
        //        LocalidadBs.DataSource = _billAddress.GetListadoLocalidades();
        //        cmbFPartido.SelectedIndex = -1;
        //        cmbFLocalidad.SelectedIndex = -1;
        //    }
        //    //Al Seleciconar un partido
        //    private void cmbFPartido_SelectedIndexChanged(object sender, EventArgs e)
        //    {
        //        //ok
        //        if (cmbFPartido.SelectedIndex == -1)
        //        {
        //            _billAddress.SetPartidoSeleccionado(null);
        //            txtFPartidoId.BackColor = Color.Orange;
        //            txtFPartidoId.Text = null;
        //            return;
        //        }

        //        _billAddress.SetPartidoSeleccionado(Convert.ToInt32(cmbFPartido.SelectedValue));
        //        LocalidadBs.DataSource = _billAddress.GetListadoLocalidades();
        //        cmbFLocalidad.SelectedIndex = -1;
        //        txtFPartidoId.Text = cmbFPartido.SelectedValue.ToString();
        //        txtFPartidoId.BackColor = Color.LawnGreen;
        //        txtFLocalidadId.Text = null;
        //        txtFLocalidadId.BackColor = Color.Orange;
        //    }
        //   //Al Seleccionar una Localidad
        //    private void cmbFLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        //    {
        //        if (cmbFLocalidad.SelectedIndex == -1)
        //        {
        //            _billAddress.SetLocalidadSeleccionada(null);
        //            return;
        //        }
        //        _billAddress.SetLocalidadSeleccionada(Convert.ToInt32(cmbFLocalidad.SelectedValue));
        //        txtFLocalidadId.Text = cmbFLocalidad.SelectedValue.ToString();
        //        txtFLocalidadId.BackColor = Color.LawnGreen;

        //        if (cmbFPartido.SelectedValue == null)
        //        {
        //            txtFPartidoId.Text = _billAddress.GetIdPartidoSeleccionado().ToString();
        //            this.cmbFPartido.SelectedIndexChanged -= new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);

        //            cmbFPartido.SelectedValue = _billAddress.GetIdPartidoSeleccionado();
        //            this.cmbFPartido.SelectedIndexChanged += new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);

        //            txtFPartidoId.BackColor = Color.LawnGreen;
        //        }
        //    }


        //    //Si se Borra el dato de provincia
        //    private void cmbFProvincia_Validating(object sender, CancelEventArgs e)
        //    {
        //        if (cmbFProvincia.SelectedValue == null)
        //        {
        //            _billAddress.SetProvinciaSeleccionada(null);
        //            partidoBs.DataSource = _billAddress.GetListadoPartido();
        //            LocalidadBs.DataSource = _billAddress.GetListadoLocalidades();
        //            cmbFPartido.SelectedIndex = -1;
        //            cmbFLocalidad.SelectedIndex = -1;
        //            toolTip1.ToolTipTitle = "Sin Datos en Partido";
        //            toolTip1.Show("Seleccione una Provincia para desplegar los datos de Partido", cmbFPartido,
        //                cmbFPartido.Location, 5000);
        //            txtFProvinciaId.Text = null;
        //            txtFPartidoId.Text = null;
        //            txtFLocalidadId.Text = null;

        //            txtFProvinciaId.BackColor = Color.Orange;
        //            txtFPartidoId.BackColor = Color.Orange;
        //            txtFLocalidadId.BackColor = Color.Orange;
        //        }
        //    }
        //    //Si borra el dato del Partido
        //    private void cmbFPartido_Validating(object sender, CancelEventArgs e)
        //    {
        //        if (cmbFPartido.SelectedValue == null)
        //        {
        //            _billAddress.SetPartidoSeleccionado(null);
        //            LocalidadBs.DataSource = _billAddress.GetListadoLocalidades();
        //            cmbFLocalidad.SelectedIndex = -1;
        //            txtFPartidoId.Text = null;
        //            txtFLocalidadId.Text = null;
        //            txtFPartidoId.BackColor = Color.Orange;
        //            txtFLocalidadId.BackColor = Color.Orange;
        //            return;
        //        }
        //    }
        //private void cmbFLocalidad_Validating(object sender, CancelEventArgs e)
        //    {
        //        if (cmbFLocalidad.SelectedValue == null)
        //        {
        //            txtFLocalidadId.Text = null;
        //            txtFLocalidadId.BackColor = Color.Orange;
        //        }
        //    }
        //       private void cmbFPartido_Enter(object sender, EventArgs e)
        //    {
        //        if (partidoBs.Count == 0)
        //        {
        //            toolTip1.ToolTipTitle = "Sin Datos en Partido";
        //            toolTip1.Show("Seleccione una Provincia para desplegar los datos de Partido", cmbFPartido,
        //                cmbFPartido.Location, 5000);
        //        }
        //    }
        //    private void cmbFLocalidad_Enter(object sender, EventArgs e)
        //    {
        //        if (LocalidadBs.Count == 0)
        //        {
        //            toolTip1.ToolTipTitle = "Sin Datos en Localidad";
        //            toolTip1.Show("Seleccione una Provincia para desplegar los datos de Localidad", cmbFLocalidad,
        //                cmbFLocalidad.Location, 5000);
        //        }
        //    }

        #endregion

        private T0006_MCLIENTES MapScreenT6()
        {
            var data = new T0006_MCLIENTES
            {
                IDCLIENTE = _idCliente6,
                BLK_DELIVERY = ckBloqueoEntrega.Checked,
                BLK_PEDIDO = ckBloqueoPedido.Checked,
                cli_rsocial = txtRazonSocial.Text,
                cli_fantasia = txtFantasia.Text,
                NombreAnterior = txtNombreAnterior.Text,
                CUIT = txtNumeroTax.Text,
                TTAX = txtCodigoTax.Text,
                UNTIPO = ckClienteOcasional.Checked,
                Direccion_facturacion = txtDireccion.Text,
                Pais = txtPais.Text,
                Direfactu_Provincia = txtProvincia.Text,
                Direfactu_Partido = txtPartido.Text,
                Direfactu_Localidad = txtLocalidad.Text,
                ZIP = txtCodigoPostal.Text,
                EMAIL_FACTU = txtEmailFacturacion.Text,
                DireccionGoogleMaps = txtDireccionValidadaGoogleMaps.Text,
                Direfactu_Zona = txtZona.Text,
                CONTACTO_VTA = txtContactoAdmin.Text,
                Telefono_Venta = txtTelefonoAdmin.Text,
                AllowL1 = ckL1.Checked,
                AllowL2 = ckL2.Checked,
                AllowL5 = ckL5.Checked,
                ZTERML1 = cmbZtermL1.SelectedValue.ToString(),
                ZTERML2 = cmbZtermL2.SelectedValue.ToString(),
                MotivoDescuento = txtMotivoDescuento.Text,
                DIRECCION_COBRO_ALT = txtPDireccionCompleta.Text,
                CONTACTO_COB = txtPNombreContacto.Text,
                TELEFONO_COB = txtPTelefno1.Text,
                Fax = txtPTelefno2.Text,
                EMAIL_COBR = txtPEmail.Text,
                DIA_HORARIO_COBRO = txtPDiasPaP.Text,
                GC = ckRequiereGesco.Checked,
                Comentario = txtObservaciones.Text,
                AutoCreditLimit = ckUtilizarLimiteAutomatico.Checked,
                AutoCreditLimitDays = (int)LimiteCreditoDays.GetValueDecimal,
                DireFactu_Num = txtDireccionNumero.Text,
                TelefonoCobranza2 = txtPTelefno2.Text,
                ACTIVO = ckActivo.Checked,
                SCCL2 = ckIncluirSaldo.Checked
            };

            if (!string.IsNullOrEmpty(cmbRubro.Text))
                data.ClienteRubro = cmbRubro.Text;

            if (!string.IsNullOrEmpty(cmbRubro.Text))
            {
                data.ClienteRubro = cmbRubro.SelectedItem.ToString();
            }

            if (!string.IsNullOrEmpty(txtLocalidadID.Text))
                data.IdLocalidadAddress = Convert.ToInt32(txtLocalidadID.Text);

            if (string.IsNullOrEmpty(txtLimiteCreditoMaximo.Text))
            {
                data.Limite_credito = 0;
            }
            else
            {
                data.Limite_credito =
                    (int)FormatAndConversions.CCurrencyADecimal(txtLimiteCreditoMaximo.Text);
            }

            if (string.IsNullOrEmpty(txtDescuentoPorcentaje.Text))
            {
                data.Descuento = 0;
            }
            else
            {
                data.Descuento =
                    (double)FormatAndConversions.CPorcentajeADecimal(txtDescuentoPorcentaje.Text);
            }

            if (cmbCobrador.SelectedValue != null)
                data.COBRADOR = cmbCobrador.SelectedValue.ToString();

            if (_modo == 1)
            {
                data.LogCreadoPor = GlobalApp.AppUsername;
                data.Fecha_Ingreso = DateTime.Now;
            }
            else
            {
                data.LogCreadoPor = txtLogCreadoPor.Text;
                if (!string.IsNullOrEmpty(txtLogCreadoEn.Text))
                {
                    data.Fecha_Ingreso = Convert.ToDateTime(txtLogCreadoEn.Text);
                }
            }

            if (_modo == 2)
            {
                data.LogModoficadoEn = DateTime.Now;
                data.LogModificadoPor = GlobalApp.AppUsername;
            }

            if (!string.IsNullOrEmpty(txtUltimoMovimiento.Text))
                data.Fecha_Ingreso = Convert.ToDateTime(txtUltimoMovimiento.Text);


            return data;
        }
        private void btnAddShipto_Click(object sender, EventArgs e)
        {
            if (_idCliente6 == -1)
            {
                var resp = MessageBox.Show(
                    @"Para continuar con la creacion de un ShipTO se debe crear el Cliente" + Environment.NewLine +
                    @"Desea Continuar con la creacion del Cliente?", @"Creacion de BILLTO-PAYER",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;

                if (ValidateAllMandatoryFields() == false)
                    return;
                if (SetCreacionBillTo() == -1)
                    return;
            }
            else
            {
                if (ValidateAllMandatoryFields() == false)
                    return;
                if (SetCreacionBillTo() == -1)
                    return;
            }

            using (var fshipto = new FrmMdc03ShipToData(_modo, _idCliente6, -1, _funcion))
            {
                DialogResult dr = fshipto.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    t0007Bs.DataSource = new CustomerManager().GetShipToListFromBillTo(_idCliente6, false);
                    dgvShipTo.DataSource = t0007Bs.DataSource;
                }
            }
        }
        private void ckClienteOcasional_CheckedChanged(object sender, EventArgs e)
        {
            if (ckClienteOcasional.Checked)
            {
                cmbZtermL1.Text = @"0E";
                cmbZtermL2.Text = @"0E";
                txtLimiteCreditoMaximo.Text = 0.ToString("C2");
                txtDescuentoPorcentaje.Text = 0.ToString("P2");
                ckUtilizarLimiteAutomatico.Checked = false;
                LimiteCreditoDays.SetValue = 0;
                ckL1.Checked = false;
                ckL2.Checked = true;
                ckL5.Checked = false;
                //new ReadOnlyFormControl(true, panLimiteCredito).LockOrUnlockControlsInContainer();
                new ReadOnlyFormControl(true, panGesco).LockOrUnlockControlsInContainer();
                //new ReadOnlyFormControl(true, panFiscal).LockOrUnlockControlsInContainer();
                dgvShipTo.ReadOnly = true;
                btnAddShipto.Enabled = false;
            }
            else
            {
                //new ReadOnlyFormControl(false, panLimiteCredito).LockOrUnlockControlsInContainer();
                new ReadOnlyFormControl(false, panGesco).LockOrUnlockControlsInContainer();
                //new ReadOnlyFormControl(false, panFiscal).LockOrUnlockControlsInContainer();
                dgvShipTo.ReadOnly = false;
                btnAddShipto.Enabled = true;

                //CREARSHIPTOAUTOMATICO!
            }
        }
        private void dgvShipTo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvShipTo[e.ColumnIndex, e.RowIndex].Value.ToString();
                var id7 = Convert.ToInt32(dgvShipTo[dgvShipTo.Columns[iDClienteEntregaDgv.Name].Index, e.RowIndex].Value);
                switch (cellValue)
                {
                    case "DETALLE":
                        using (var fx = new FrmMdc03ShipToData(_modo, _idCliente6, id7, _funcion))
                        {
                            DialogResult dr = fx.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                t0007Bs.DataSource = new CustomerManager().GetShipToListFromBillTo(_idCliente6,
                                    false);
                                dgvShipTo.DataSource = t0007Bs.DataSource;
                            }
                        }
                        break;
                }
            }
        }
        private void cmbTipoTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoTax.SelectedIndex != -1)
            {
                switch (cmbTipoTax.Text)
                {
                    case "NI":
                        txtNumeroTax.Mask = @"00-00000000-0";
                        txtCodigoTax.Text = @"00";
                        txtNumeroTax.Text = @"00-00000000-0";
                        txtTaxValido.Text = @"NO VALIDADO";
                        break;

                    case "CUIT":
                        txtNumeroTax.Mask = @"00-00000000-0";
                        txtCodigoTax.Text = @"80";
                        txtTaxValido.Text = @"NO VALIDADO";

                        break;

                    case "DNI":
                        txtNumeroTax.Mask = @"00-000-000";
                        txtCodigoTax.Text = @"96";
                        txtNumeroTax.Text = @"00-000-000";
                        txtTaxValido.Text = @"NO VALIDADO";
                        break;
                }
            }
        }
        private void cmbTipoTax_Validating(object sender, CancelEventArgs e)
        {
            if (cmbTipoTax.Text == null && cmbTipoTax.Text != string.Empty)
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbTipoTax, "Debe Proveer un TIPO DE TAX valido");
            }
            if (cmbTipoTax.Text == @"NI" || cmbTipoTax.Text == @"CUIT" || cmbTipoTax.Text == @"DNI")
            {
                //Valores OK
                errorProvider1.SetError(cmbTipoTax, "");
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(cmbTipoTax, "Debe Proveer un TIPO DE TAX valido");
                //no permite abandonar el campo
            }
        }
        private void cmbZtermL1_Validating(object sender, CancelEventArgs e)
        {
            //Validacion ZTerm1/2
            var campo = (ComboBox)sender;
            if (campo.SelectedValue == null)
            {
                MessageBox.Show(@"El valor de Termino de Pago no es valido", @"Error en validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        private void txtLimiteCreditoMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void cmbCobrador_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbCobrador.Text))
            {
                if (cmbCobrador.SelectedValue == null)
                {
                    errorProvider1.SetError(cmbCobrador, "El nombre del cobrador es incorrecto");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(cmbCobrador, "");
                }
            }
        }
        private void txtDescuentoPorcentaje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescuentoPorcentaje.Text))
            {
                txtDescuentoPorcentaje.Text = 0.ToString("P2");
            }
            decimal valorDto = FormatAndConversions.CPorcentajeADecimal(txtDescuentoPorcentaje.Text);
            if (valorDto < 0)
            {
                MessageBox.Show(@"Error en el % de Descuento - No puede er menor a 0%", @"Error de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
            }

            if (valorDto > (decimal)0.25)
            {
                MessageBox.Show(@"Error en el % de Descuento - No puede ser mayor a 25%", @"Error de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
            }

            txtDescuentoPorcentaje.Text = valorDto.ToString("P2");
        }
        private void txtNumeroTax_Validating(object sender, CancelEventArgs e)
        {
            if (_modo == 1)
            {
                if (txtCodigoTax.Text == @"80" || txtCodigoTax.Text == @"96")
                {
                    if (new CustomerManager().CuitIsAlreadyInDb(txtNumeroTax.Text))
                    {
                        MessageBox.Show(@"El Cliente Ya Existe en la base de datos", @"Cliente Existente",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        e.Cancel = true;
                    }
                }
            }
        }
        private void ckCobroDireccionFiscal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCobroDireccionFiscal.Checked)
            {
                txtPDireccionCompleta.Text = null;
                txtPDireccionCompleta.ReadOnly = true;
            }
            else
            {
                if (_modo < 3)
                {
                    txtPDireccionCompleta.ReadOnly = false;
                }
            }
        }
        private void tabData_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void ckUtilizarLimiteAutomatico_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void txtPTelefno1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPTelefno1.Text))
            {
                txtPTelefno1.Text = txtTelefonoAdmin.Text;
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            float width = (float)1.0;
            Pen pen = new Pen(Color.LightGray, width);
            pen.DashStyle = DashStyle.Dot;
            e.Graphics.DrawLine(pen, 0, 0, 0, panel.Height - 0);
            e.Graphics.DrawLine(pen, 0, 0, panel.Width - 0, 0);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, 0, panel.Height - 1);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, panel.Width - 1, 0);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGrabarGescoData_Click(object sender, EventArgs e)
        {
            if (_idCliente6 == -1)
            {
                MessageBox.Show(
                    @"Debido a que el Cliente es Inexistente. Primero debe grabar el cliente y luego puede agregar el texto",
                    @"Cliente Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            new CRMMensajeInterno().SetMensajeInterno(_idCliente6, txtCrmInfo.Text, true);
            MessageBox.Show(@"Los Valores se han Actualizado Correctamente!", @"Actualizacion GESCO",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnVisualizarGesco_Click(object sender, EventArgs e)
        {
            if (_idCliente6 < 0)
            {
                MessageBox.Show(@"No se puede ir a GesCo porque el Cliente aun no se encuentra creado",
                    @"Gesco No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var f = new FrmCRM03GescoMain(1, _idCliente6);
            {
                f.Show();
            }
        }
        private void btnActivarCliente_Click(object sender, EventArgs e)
        {
            //aca va el boton activar
            if (_idCliente6 < 1)
            {
                MessageBox.Show(@"El Cliente aun no se encuentra en la base de datos", @"Cliente Inexistente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resp = MessageBox.Show(@"Confirma la Activacion del Cliente?", @"Activacion del Cliente", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;
            CustomerMDActionsAndLog.ActivaCliente(_idCliente6, "Activacion de Cliente Inactivo");
            //
            txtStatusCliente.Text = @"Activo";
            txtStatusCliente.BackColor = _colorOk;
            ckActivo.Checked = true;
            semClienteActivo.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            btnActivarCliente.Visible = false;
            btnInactivaCliente.Visible = true;
            //
            var numShiptos = new CustomerManager().GetNumberofShipTos(_idCliente6, true);
            txtCantidadShiptoActivo.Text = numShiptos.ToString();
            if (numShiptos == 0)
            {
                MessageBox.Show(@"Atencion. El Cliente se encuentra activo, pero no existe ningun ShipTo Activo",
                    @"No existen ShipTos Activos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnInactivaCliente_Click(object sender, EventArgs e)
        {
            //aca va el boton inactivar
            if (_idCliente6 < 1)
            {
                MessageBox.Show(@"El Cliente aun no se encuentra en la base de datos", @"Cliente Inexistente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            //var resp = MessageBox.Show(@"Confirma la Inactivacion del Cliente?", @"Inactivacion del Cliente", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question);
            //if (resp == DialogResult.No)
            //    return;

            var z = new CtaCteCustomer(_idCliente6);
            var saldo = z.GetResultadoCtaCte("L1").SaldoResumen + z.GetResultadoCtaCte("L2").SaldoResumen;
            if (saldo > 0)
            {
                MessageBox.Show(
                    @"Atencion! No se puede Inactivar el Cliente porque el mismo tiene saldo Pendiente!" +
                    Environment.NewLine + @"Puede Bloquear Cliente hasta que el Saldo este en $0.00",
                    @"No se puede Inactivar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            var x = TsDialogo.StringDialog("Indique Motivo de Inactivacion", @"Confirmacion de Inactivacion de Cliente");
            if (x == null)
            {
                MessageBox.Show(@"No se puede inactivar sin un motivo. (Ejemplo: Cliente sin movimientos");
                return;
            }
            CustomerMDActionsAndLog.InactivaCliente(_idCliente6, x);
            txtStatusCliente.Text = @"Inactivo";
            txtStatusCliente.BackColor = _colorNo;
            ckActivo.Checked = false;
            semClienteActivo.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            btnActivarCliente.Visible = true;
            btnInactivaCliente.Visible = false;

            var numShiptos = new CustomerManager().GetNumberofShipTos(_idCliente6, true);
            txtCantidadShiptoActivo.Text = numShiptos.ToString();

        }

        private void btnAdminBloqueos_Click(object sender, EventArgs e)
        {

        }
    }
}
