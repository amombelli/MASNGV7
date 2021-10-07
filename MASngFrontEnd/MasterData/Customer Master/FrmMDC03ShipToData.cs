using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MASngFE.SuperMD;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.MasterData.Material_Master;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using TecserEF.Entity;
using TSControls;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MASngFE.MasterData.Customer_Master
{
    public partial class FrmMdc03ShipToData : Form
    {
        public FrmMdc03ShipToData(int modo, int idCliente6, int idCliente7, string funcion)
        {
            _modo = modo;
            _idCliente6 = idCliente6;
            _idCliente7 = idCliente7;
            _funcion = funcion;
            InitializeComponent();
        }


        //creacion de nuevo shipto
        public FrmMdc03ShipToData(int idCliente6)
        {
            _modo = 1;
            _idCliente6 = idCliente6;
            _idCliente7 = -1;
            _funcion = "mdcf"; //master data crea fiscal
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------
        private readonly int _idCliente6;
        private int _idCliente7;
        private readonly int _modo;
        private readonly string _funcion;
        private T0006_MCLIENTES billTo = new T0006_MCLIENTES();
        private Color colorNoDef = Color.Yellow;
        private Color colorOk = Color.LightGreen;
        private Color colorActivo = Color.ForestGreen;
        private Color colorNo = Color.IndianRed;
        private Color colorInicial = Color.LightBlue;
        private NewAddressManager addressManager = new NewAddressManager();
        //----------------------------------------------------------------------------------

        private void FrmShipToData_Load(object sender, EventArgs e)
        {
            billTo = new CustomerManager().GetCustomerBillToData(_idCliente6);
            personalHRBs.DataSource = new HumanResourcesManager().GetListAllActiveVendedor();
            proveedoresBs.DataSource = new VendorManager().GetListVendorByVendorType("TRANSP", true);
            cmbTransporte.SelectedIndex = -1;
            cmbVendedor.SelectedIndex = -1;
            ckActivo.Checked = true;
            ckEsTransporte.Checked = false;
            cmbTransporte.Enabled = false;
            ckUnTipo.Checked = false;
            LoadBillToData();
            AccionSegunModo();
            AccionSegunFuncion();
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            float width = (float)1.0;
            Pen pen = new Pen(SystemColors.ControlDarkDark, width);
            pen.DashStyle = DashStyle.Dot;
            e.Graphics.DrawLine(pen, 0, 0, 0, panel.Height - 0);
            e.Graphics.DrawLine(pen, 0, 0, panel.Width - 0, 0);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, 0, panel.Height - 1);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, panel.Width - 1, 0);
        }

        private void LoadBillToData()
        {
            txtId6_.Text = _idCliente6.ToString();
            txtRazonSocial.Text = billTo.cli_rsocial;
            txtFantasia6.Text = billTo.cli_fantasia;
            txtmodo.Text = _modo.ToString();
            txtfn.Text = _funcion;
            if (billTo.ACTIVO)
            {
                ckBillToActivo.Checked = true;
                ckBillToActivo.ForeColor = colorActivo;
            }
            else
            {
                ckBillToActivo.Checked = false;
                ckBillToActivo.ForeColor = colorNo;
            }
        }

        private void AccionSegunModo()
        {
            btnPlantaTecser.Enabled = false;
            btnCopiarFiscal.Enabled = false;
            btnEstructuraDireccion.Enabled = false;
            btnCopiarDatosContacto.Enabled = false;
            btnActivarCliente.Enabled = false;
            btnInactivaCliente.Enabled = false;
            btnGuardarCambios.Enabled = false;

            switch (_modo)
            {
                case 1:
                    btnPlantaTecser.Enabled = true;
                    btnCopiarFiscal.Enabled = true;
                    btnEstructuraDireccion.Enabled = true;
                    btnCopiarDatosContacto.Enabled = true;
                    btnActivarCliente.Enabled = true;
                    btnInactivaCliente.Enabled = true;
                    btnGuardarCambios.Enabled = true;
                    cmbVendedor.Enabled = true;
                    cmbTransporte.Enabled = true;
                    LoadExistingShipToData();
                    break;
                case 2:
                    btnPlantaTecser.Enabled = true;
                    btnCopiarFiscal.Enabled = true;
                    btnEstructuraDireccion.Enabled = true;
                    btnCopiarDatosContacto.Enabled = true;
                    btnActivarCliente.Enabled = true;
                    btnInactivaCliente.Enabled = true;
                    btnGuardarCambios.Enabled = true;
                    cmbVendedor.Enabled = true;
                    cmbTransporte.Enabled = true;
                    LoadExistingShipToData();
                    break;
                case 3:
                    cmbVendedor.Enabled = false;
                    cmbTransporte.Enabled = false;
                    LoadExistingShipToData();
                    break;
                default:
                    break;
            }
        }
        private void AccionSegunFuncion()
        {
            switch (_funcion)
            {
                case "mdcf":
                    CreaShipToFromFiscal();
                    break;
                default:
                    break;
            }
            //nada por ahora
        }
        private void CreaShipToGenericoTecserPlanta()
        {
            txtShipToDescription.Text = txtFantasia6.Text + @"Planta TS";
            ckEsTransporte.Checked = false;
            ckActivo.Checked = true;
            ckActivo.BackColor = colorOk;
            //
            txtDireccion.Text = @"Retira Cliente por: CERRITO";
            txtDireccionNumero.Text = @"3475";
            txtPais.Text = @"AR";
            txtPaisDescripccion.Text = @"ARGENTINA";
            txtProvincia.Text = @"Buenos Aires";
            txtPartido.Text = @"La Matanza";
            txtLocalidad.Text = @"Lomas del Mirador ";
            txtCodigoPostal.Text = @"1752";
            txtZona.Text = @"1";
            ckUnTipo.Checked = true;
            //
            cmbTransporte.SelectedIndex = -1;
            cmbTransporte.Enabled = false;
            //
            txtLogCreadoPor.Text = GlobalApp.AppUsername;
            txtLogCreadoEn.Text = DateTime.Today.ToString("d");
        }
        private void CreaShipToFromFiscal()
        {
            txtShipToDescription.Text = billTo.cli_fantasia + @" [FI]";
            cmbTransporte.SelectedItem = -1;
            cmbTransporte.Enabled = false;
            ckEsTransporte.Checked = false;
            ckActivo.Checked = true;
            ckActivo.BackColor = colorOk;
            ckUnTipo.Checked = false;
            //
            txtDireccion.Text = billTo.Direccion_facturacion;
            txtDireccionNumero.Text = billTo.DireFactu_Num;
            txtPais.Text = billTo.Pais;
            if (string.IsNullOrEmpty(billTo.Pais))
            {
                txtPais.Text = @"AR";
            }

            if (txtPais.Text == @"AR")
            {
                txtPaisDescripccion.Text = @"ARGENTINA";
            }
            txtProvincia.Text = billTo.Direfactu_Provincia;
            txtPartido.Text = billTo.Direfactu_Partido;
            txtLocalidad.Text = billTo.Direfactu_Localidad;
            txtCodigoPostal.Text = billTo.ZIP;
            txtZona.Text = billTo.Direfactu_Zona;
            txtDireccionValidadaGoogleMaps.Text = billTo.DireccionGoogleMaps;

            addressManager.SetValoresSinValidar(txtPais.Text, txtProvincia.Text, txtPartido.Text, txtLocalidad.Text);
            ReMapeaDireccionValidada(addressManager.GetSeleccion());

            CopiaDatosContactoFacturacion();

            txtLogCreadoPor.Text = GlobalApp.AppUsername;
            txtLogCreadoEn.Text = DateTime.Today.ToString("d");
        }
        private void LoadExistingShipToData()
        {
            if (_idCliente7 == -1)
                return;

            var sh = new CustomerManager().GetCustomerShipToData(_idCliente7);
            if (sh == null)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Intentar Traer los datos del ShipTO", @"Error de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtShipToDescription.Text = sh.ClienteEntregaDesc;
            txtidCliente7.Text = _idCliente7.ToString();
            ckActivo.Checked = sh.Activo;
            if (ckActivo.Checked)
            {
                ckActivo.BackColor = colorActivo;
                btnInactivaCliente.Visible = true;
                btnActivarCliente.Visible = false;
            }
            else
            {
                ckActivo.BackColor = colorNo;
                btnInactivaCliente.Visible = false;
                btnActivarCliente.Visible = true;
            }

            if (sh.TRANSPORTE_ID != null)
            {
                ckEsTransporte.Checked = true;
                cmbTransporte.SelectedValue = sh.TRANSPORTE_ID;
                txtIdTransporte.Text = sh.TRANSPORTE_ID.ToString();
            }
            else
            {
                ckEsTransporte.Checked = false;
                cmbTransporte.SelectedIndex = -1;
                txtIdTransporte.Text = null;
                cmbTransporte.Enabled = false;
            }

            if (string.IsNullOrEmpty(sh.Pais))
            {
                txtPais.Text = @"AR";
            }

            if (txtPais.Text == @"AR")
                txtPaisDescripccion.Text = @"ARGENTINA";
            semPais.SetLights = CtlSemaforo.ColoresSemaforo.Verde;

            txtDireccion.Text = sh.Direccion_Entrega;
            txtDireccionNumero.Text = sh.Direccion_EntregaNum;
            txtCodigoPostal.Text = sh.ZIP;
            txtZona.Text = sh.DireEntre_Zona;
            txtDireccionValidadaGoogleMaps.Text = sh.DireccionGoogleMaps;
            txtProvincia.Text = sh.DireEntre_Provincia;
            txtPartido.Text = sh.Direccion_EntregaPartido;
            txtLocalidad.Text = sh.DireEntre_Localidad;

            // ** validacion y formato de direccion

            addressManager.SetValoresSinValidar(txtPais.Text, sh.DireEntre_Provincia, sh.Direccion_EntregaPartido, sh.DireEntre_Localidad);
            ReMapeaDireccionValidada(addressManager.GetSeleccion());

            txtContactoCompras.Text = sh.Contacto;
            txtTelefonoCompras.Text = sh.Telefono_Entrega;
            txtTelefonoCompras2.Text = sh.Fax;
            txtDiasHorarioEntrega.Text = sh.EntregaHorarios;
            //
            if (sh.Vendedor != null)
            {
                cmbVendedor.SelectedValue = sh.Vendedor;
            }
            //
            ckUnTipo.Checked = sh.UNTIPO;
            //
            txtLogCreadoPor.Text = sh.Log_User;
            if (sh.Log_Date != null)
                txtLogCreadoEn.Text = sh.Log_Date.Value.ToString("d");

            if (sh.LogUserModificadoEn != null)
                txtLogModificadoEn.Text = sh.LogUserModificadoEn.Value.ToString("d");
            txtLogModificadoPor.Text = sh.LogUserModificadoPor;
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
                txtProvinciaID.BackColor = colorNo;
            }
            else
            {
                txtProvinciaID.Text = data.IdProvincia.ToString();
                semProvincia.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtProvinciaID.BackColor = colorOk;
            }


            if (data.IdPartido == null)
            {
                semPartido.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtPartidoID.BackColor = colorNo;
            }
            else
            {
                txtPartidoID.Text = data.IdPartido.ToString();
                semPartido.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtPartidoID.BackColor = colorOk;
            }

            if (data.IdLocalidad == null)
            {
                semLocalidad.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtLocalidadID.BackColor = colorNo;
            }
            else
            {
                txtLocalidadID.Text = data.IdLocalidad.ToString();
                semLocalidad.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtLocalidadID.BackColor = colorOk;
            }
        }
        private void ckEsTransporte_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEsTransporte.Checked)
            {
                cmbTransporte.Enabled = true;
            }
            else
            {
                cmbTransporte.Enabled = false;
                txtIdTransporte.Text = null;
                cmbTransporte.SelectedIndex = -1;
            }
        }

        private T0007_CLI_ENTREGA MapeaFormToStructure()
        {
            var t7 = new T0007_CLI_ENTREGA()
            {
                IDCLIENTE = _idCliente6,
                ID_CLI_ENTREGA = _idCliente7,
                ClienteEntregaDesc = txtShipToDescription.Text,
                Direccion_Entrega = txtDireccion.Text,
                Pais = txtPais.Text,
                ZIP = txtCodigoPostal.Text,
                DireEntre_Zona = txtZona.Text,
                Contacto = txtContactoCompras.Text,
                Telefono_Entrega = txtTelefonoCompras.Text,
                Fax = txtTelefonoCompras2.Text,
                Activo = ckActivo.Checked,
                CKTRANSPORTE = ckEsTransporte.Checked,
                EntregaHorarios = txtDiasHorarioEntrega.Text,
                Vendedor = cmbVendedor.Text,
                DireEntre_Provincia = txtProvincia.Text,
                Direccion_EntregaPartido = txtPartido.Text,
                DireEntre_Localidad = txtLocalidad.Text,
                Direccion_EntregaNum = txtDireccionNumero.Text,
                Log_User = txtLogCreadoPor.Text,
                DireccionGoogleMaps = txtDireccionValidadaGoogleMaps.Text,
                LogUserModificadoPor = txtLogModificadoPor.Text,
                UNTIPO = ckUnTipo.Checked,
                //DM_IDTAS = 1, eliminar de DB
            };

            if (!string.IsNullOrEmpty(txtLocalidadID.Text))
            {
                t7.IdLocalidadAddress = Convert.ToInt32(txtLocalidadID.Text);
            }
            else
            {
                t7.TRANSPORTE_ID = null;
            }

            if (!string.IsNullOrEmpty(txtIdTransporte.Text))
            {
                t7.TRANSPORTE_ID = Convert.ToInt32(txtIdTransporte.Text);
            }
            else
            {
                t7.TRANSPORTE_ID = null;
            }

            return t7;
        }

        private void btnPlantaTecser_Click(object sender, EventArgs e)
        {
            var msg =
                MessageBox.Show(
                    @"Desea crear un SHIPTO con la direccion de la planta Tecser?" + Environment.NewLine +
                    @"Esto se debe hacer unicamente cuando el cliente retira por Planta TECSER y no tenga ningun domicilio registrado",
                    @"Creacion Domicilio Generico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
                return;

            CreaShipToGenericoTecserPlanta();
            addressManager.SetValoresSinValidar(txtPais.Text, txtProvincia.Text, txtPartido.Text, txtLocalidad.Text);
            ReMapeaDireccionValidada(addressManager.GetSeleccion());

        }

        private bool ValidacionDatosOK()
        {
            bool zvalid = true;
            var vx = new ValidacionManager(this, ep, toolTip1);
            if (vx.Valida(txtShipToDescription, string.IsNullOrEmpty(txtShipToDescription.Text),
                "Debe Completar la Descripcion del Shipto (Cliente-Entrega)"))
            {
                if (!vx.Valida(txtShipToDescription,
                    new CustomerManager().CheckIfShipToDescriptionExist(_idCliente7, txtShipToDescription.Text),
                    "Ya Existe esta descripcion. Debe Seleccionar una diferente"))
                {
                    vx.Valida(txtShipToDescription, txtShipToDescription.Text.Length > 30,
                        "La Descripcion no puede ser mayor a 30 caracteres");
                }
            }

            vx.Valida(cmbTransporte, (ckEsTransporte.Checked && cmbTransporte.SelectedValue == null),
                "Si selecciona Entrega en Transporte debe seleccionar el Transporte");

            vx.Valida(txtDireccion, string.IsNullOrEmpty(txtDireccion.Text), "Debe completar Direccion de Entrega");

            vx.Valida(txtProvincia, string.IsNullOrEmpty(txtProvincia.Text), "Debe Completar Provincia");

            vx.Valida(txtProvinciaID, string.IsNullOrEmpty(txtProvinciaID.Text),
                "El Nombre de la Provincia es Invalido. Utilice el boton de Estructura para modifcar el valor");

            //Partido/Localidad no es mandatorio que sea completado pero si no esta validado lo observa

            if (!string.IsNullOrEmpty(txtPartido.Text) && string.IsNullOrEmpty(txtPartidoID.Text))
            {
                var msg =
                    MessageBox.Show(
                        @"El PARTIDO no se encuentra validado con los datos maestros" + Environment.NewLine +
                        @"Desea Continuar con estos datos sin validar?", @"Validacion de Datos",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                    zvalid = false;
            }

            if (!string.IsNullOrEmpty(txtLocalidad.Text) && string.IsNullOrEmpty(txtLocalidadID.Text))
            {
                var msg =
                    MessageBox.Show(
                        @"La LOCALIDAD no se encuentra validada con los datos maestros" + Environment.NewLine +
                        @"Desea Continuar con estos datos sin validar?", @"Validacion de Datos",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                    zvalid = false;
            }

            //Completitud Default

            if (cmbVendedor.SelectedValue == null)
            {
                cmbVendedor.SelectedValue = "GERENCIA";
            }
            return vx.GetResultadoValidacion() && zvalid;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!ValidacionDatosOK())
                return;

            if (_modo == 1)
            {
                if (new CustomerManager().CheckIfShipToAddressExist(_idCliente6, txtDireccion.Text))
                {
                    var resp = MessageBox.Show(
                        @"Existe un Domicilio para este cliente extremadamente similar. Desea Realmente crear este nuevo SHIPTO?",
                        @"Atencion: Direccion Similar Encontrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.No)
                        return;
                }
            }


            if (_idCliente7 == -1)
            {
                //Crea nuevo ShipTo
                _idCliente7 = new AbmCustomerMaster().SaveT7Data(MapeaFormToStructure());
                txtidCliente7.Text = _idCliente7.ToString();
                MessageBox.Show($@"Se ha creado correctamente el nuevo SHIPTO #{_idCliente7} ", @"Creacion de ShipTo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;


            }
            else
            {
                //Actualiza ShipTo
                var rpt = new AbmCustomerMaster().SaveT7Data(MapeaFormToStructure());
                if (rpt == _idCliente7)
                {
                    MessageBox.Show(@"Los datos del SHIPTO se han modificado correctamente", @"Modificacion de ShipTo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    if (rpt == 0)
                    {
                        MessageBox.Show(@"No se han encontrado cambios para guardar", @"Modificacion de ShipTo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        this.DialogResult = DialogResult.OK;
                        return;
                    }
                    else
                    {
                        MessageBox.Show(@"Ha Ocurrido un error al intentar guardar el SHIPTO", @"Modificacion de ShipTo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtShipToDescription_Validating(object sender, CancelEventArgs e)
        {
            //// Name is required
            //if (string.IsNullOrEmpty(txtShipToDescription.Text))
            //{
            //    ep.SetError(txtShipToDescription, "Debe proveer una descripcion para el cliente-entrega");
            //    e.Cancel = true;
            //    return;
            //}
            //// Name is Valid
            //ep.SetError(txtShipToDescription, "");
        }

        private void ValidacionForm_Wide()
        {
            foreach (Control control in Controls)
            {
                // Set focus on control
                control.Focus();
                // Validate causes the control's Validating event to be fired,
                // if CausesValidation is True
                if (!Validate())
                {
                    ep.SetError(control, "Error!");
                    DialogResult = DialogResult.None;
                    return;
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Ignore;
            return;
        }
        private void btnEstructuraDireccion_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmSMD01_AddressStructure(txtPais.Text, txtProvincia.Text, txtPartido.Text,
                txtLocalidad.Text, txtCodigoPostal.Text, txtZona.Text))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ReMapeaDireccionValidada(f0.Address.GetSeleccion());
                }
            }
        }
        private void btnInactivaCliente_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(@"Confirma la Inactivacion de este SHIPTO?", @"Confirmacion de Inactivacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;

            switch (new AbmCustomerMaster().InactivaShipTo(_idCliente7))
            {
                case -1:
                    MessageBox.Show(@"El Cliente Shipto No Existe", @"Cliente Inexistente", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
                case 0:
                    MessageBox.Show(@"El Cliente ya se encontraba Inactivo", @"Cliente Sin modificar",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 1:
                    MessageBox.Show(@"El Cliente se ha Inactivado Correctamente", @"Cliente Modificado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnInactivaCliente.Visible = false;
                    btnActivarCliente.Visible = true;
                    ckActivo.Checked = false;
                    ckActivo.BackColor = colorNo;
                    break;
            }
        }

        private void btnActivarCliente_Click(object sender, EventArgs e)
        {
            //var resp = MessageBox.Show(@"Confirma la Activacion de este SHIPTO?", @"Confirmacion de Inactivacion",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resp == DialogResult.No)
            //    return;

            switch (new AbmCustomerMaster().ActivaShipTo(_idCliente7))
            {
                case -1:
                    MessageBox.Show(@"El Cliente Shipto No Existe", @"Cliente Inexistente", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
                case 0:
                    MessageBox.Show(@"El Cliente ya se encontraba Activo", @"Cliente Sin modificar",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 1:
                    MessageBox.Show(@"El Cliente se ha ACTIVADO Correctamente", @"Cliente Modificado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnInactivaCliente.Visible = true;
                    btnActivarCliente.Visible = false;
                    ckActivo.Checked = true;
                    ckActivo.BackColor = colorOk;
                    break;
            }
        }

        private void cmbTransporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransporte.SelectedIndex == -1)
            {
                txtIdTransporte.Text = null;
            }
            else
            {
                txtIdTransporte.Text = cmbTransporte.SelectedValue.ToString();
            }
        }
        private void CopiaDatosContactoFacturacion()
        {
            txtContactoCompras.Text = billTo.CONTACTO_VTA;
            txtTelefonoCompras.Text = billTo.Telefono_Venta;
            txtTelefonoCompras2.Text = billTo.Fax;
        }
        private void btnCopiarDatosContacto_Click(object sender, EventArgs e)
        {
            var preguntar = false;
            if (!string.IsNullOrEmpty(txtContactoCompras.Text))
            {
                preguntar = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(txtTelefonoCompras.Text))
                {
                    preguntar = true;
                }
            }

            if (preguntar)
            {
                var resp = MessageBox.Show(
                    @"Existen datos de contacto. Desea sobreescribir estos datos con la inforacion de contacto de BILLTO (Facturacion)",
                    @"Confirmacion de Sobreescritura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;
            }
            CopiaDatosContactoFacturacion();

        }

        //Transporte+Vendedor
        private void cmbTransporte_Validating(object sender, CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null && combo.Text != string.Empty)
                e.Cancel = true;
        }

        private void btnCopiarFiscal_Click(object sender, EventArgs e)
        {
            var msg =
                MessageBox.Show(
                    @"Desea crear un SHIPTO copiando los datos de la direccion de Fiscal del Cliente?" + Environment.NewLine +
                    @"En este caso la direccion fiscal y la direcciòn de entrega sera la misma",
                    @"Creacion Punto de Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
                return;

            CreaShipToGenericoTecserPlanta();
            addressManager.SetValoresSinValidar(txtPais.Text, txtProvincia.Text, txtPartido.Text, txtLocalidad.Text);
            ReMapeaDireccionValidada(addressManager.GetSeleccion());
        }

        private void txtDireccion_Validated(object sender, EventArgs e)
        {

        }
    }
}
