using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.MasterData.Material_Master;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.MasterData.Material_Master
{
    public partial class FrmMdm01MaterialMasterMain : Form
    {

        //Constructor creacion de material
        public FrmMdm01MaterialMasterMain(int modo = 1)
        {
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("MM1", "MM2"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para ingresar a esta transaccion",
                    @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            _modo = modo;
            InitializeComponent();
        }

        //Consutrctor utilizado para crear un material desde el numero de NEL
        public FrmMdm01MaterialMasterMain(int modo, int nelNumber)
        {
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("MM1", "MM2"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para ingresar a esta transaccion",
                    @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            _modo = modo;
            _numeroNEL = nelNumber;
            _primario = new NelManager().GetData(_numeroNEL).CodigoDefinitivo;
            InitializeComponent();
        }

        //Constructor para modificacion o visualizacion de primario
        public FrmMdm01MaterialMasterMain(int modo, string primario)
        {
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("MM" + modo, "MM2"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para ingresar a esta transaccion",
                    @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            _modo = modo;
            _primario = primario;
            if (_modo < 2)
            {
                MessageBox.Show(@"El Modo suministrado no es correcto", @"Error en Modo de Acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------
        private readonly int _modo;
        private string _primario;
        private T0010_MATERIALES _primarioData;
        private T0011_MaterialType _tipoMaterialSeleccionado;
        private int _numeroNEL;
        //-----------------------------------------------------------------------------------------------


        private void FrmNewMaterialMasterMainScreen_Load(object sender, EventArgs e)
        {
            FormConfig();
            AccionSegunModo();
        }
        private void FormConfig()
        {
            this.cmbTipoMaterial.SelectedIndexChanged -= new System.EventHandler(this.cmbTipoMaterial_SelectedIndexChanged);
            MaterialTypeNewBs.DataSource = new MaterialTypeManager().GetListMtype();
            ColoresBs.DataSource = new ColoresManagement().GetColoresList();
            SlocBs.DataSource = new StorageLocationManager().ListOfLoc(true);
            GlxInventarioBs.DataSource = new GLAccountManagement().GetListGLInventario();
            GlxVentaBs.DataSource = new GLAccountManagement().GetListGLImputacionVentas();
            ContainerBs.DataSource = new MaterialMasterManager().GetListaEnvases();

            //Reset a valor Inicial
            cmbTipoMaterial.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            cmbGLInventario.SelectedIndex = -1;
            cmbGlVenta.SelectedIndex = -1;
            cmbEnvase.SelectedIndex = -1;
            cmbOrigen.Text = @"NOD";
            cmbSlocEspecificoMaterial.SelectedIndex = -1;


            txtDescripcionOF.MaxLength = 30;
            txtDescripcionTipoMaterial.MaxLength = 50;
            //
        }
        private void AccionSegunModo()
        {
            switch (_modo)
            {
                case 1:
                    //Creacion de Material - Por diseño solo acá se podra cabmiar un tipo de material
                    this.cmbTipoMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMaterial_SelectedIndexChanged);
                    if (!string.IsNullOrEmpty(_primario))
                    {
                        txtPrimario.Text = _primario;  //esto cuando se usa?
                    }

                    break;
                case 2:
                    //Modoficacion de Material
                    cmbTipoMaterial.Enabled = false; //solo en la creacion
                    txtPrimario.ReadOnly = true;
                    CargaPrimaryData();
                    BusinessRulesSegunTipoMaterial();
                    AkaBs.DataSource = new AkaManager().GetListAkaFromPrimario(_primario);
                    break;
                case 3:
                    //Visualizacion de Material
                    cmbTipoMaterial.Enabled = false; //solo en la creacion
                    txtPrimario.ReadOnly = true;
                    CargaPrimaryData();
                    BusinessRulesSegunTipoMaterial();
                    AkaBs.DataSource = new AkaManager().GetListAkaFromPrimario(_primario);
                    btnSave.Enabled = false;
                    btnNewZRLB.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        private void CargaPrimaryData()
        {
            _primarioData = new MaterialMasterManager().GetPrimarioInfo(_primario);
            if (_primarioData == null)
            {
                MessageBox.Show(@"Ha Ocurrido un error grave. No Existe informacion del Material seleccionado",
                    @"Error en Primario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            ckMaterialActivo.Checked = _primarioData.ACTIVO;
            if (_primarioData.ACTIVO)
            {
                lblCkStatus.Text = @"ACTIVO";
                lblCkStatus.ForeColor = Color.Green;
            }
            else
            {
                lblCkStatus.Text = @"INACTIVO";
                lblCkStatus.ForeColor = Color.IndianRed;
            }
            txtStatus.Text = _primarioData.Status;
            txtVistas.Text = ""; //Completar las vistas con una funcion o mapear a DB

            _tipoMaterialSeleccionado = new MaterialTypeManager().GetMtype(_primarioData.TIPO_MATERIAL);
            txtDescripcionTipoMaterial.Text = _tipoMaterialSeleccionado.Descripcion;
            txtPrimario.Text = _primario;
            txtDescripcionTecnica.Text = _primarioData.DescripcionTecnicaLab;
            txtDescripcionOF.Text = _primarioData.DescripcionFormulacion;
            cmbTipoMaterial.SelectedValue = _primarioData.TIPO_MATERIAL;
            //
            cmbCarrier.Text = _primarioData.COMPUESTO_BASE;
            cmbOrigen.Text = _primarioData.ORIGEN;
            cmbUoM.Text = _primarioData.UNIDAD;
            if (_primarioData.COLOR != null)
                cmbColor.SelectedValue = _primarioData.COLOR;
            if (_primarioData.CONCENTRACION != null)
                txtConcentracion.Text = _primarioData.CONCENTRACION.Value.ToString("P2");
            if (_primarioData.Dureza != null)
                txtDureza.Text = _primarioData.Dureza.Value.ToString("N");

            //Fi & CO Data
            if (_primarioData.FORM_COSTO != null)
            {
                txtFormulaCosteo.Text = _primarioData.FORM_COSTO.ToString();
                txtDescripcionFormulaCosteo.Text =
                    new BOMManager().GetFormulaHeader(_primarioData.FORM_COSTO.Value).DESC_FORMULA;
            }

            cmbMonedaCosto.SelectedItem = string.IsNullOrEmpty(_primarioData.MonedaCosto) ? "USD" : _primarioData.MonedaCosto;
            cmbMonedaCosto.SelectedItem = string.IsNullOrEmpty(_primarioData.MonedaCosto) ? @"USD" : _primarioData.MonedaCosto;
            ckMaterialCosteable.Checked = _tipoMaterialSeleccionado.ControlCosto;
            txtCostoRepoCR.Text = @"XX";
            txtGlVentaDefault.Text = _tipoMaterialSeleccionado.GLVentas;
            txtGlVentaDefaultDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(_tipoMaterialSeleccionado.GLVentas);
            txtGlInventarioDefault.Text = _tipoMaterialSeleccionado.GLInvetory;
            txtGlInventarioDescripcionDefault.Text = GLAccountManagement.GetGLDescriptionFromT135(_tipoMaterialSeleccionado.GLInvetory);
            if (_primarioData.GL != null)
            {
                if (_primarioData.GL != txtGlVentaDefault.Text)
                {
                    cmbGlVenta.SelectedValue = _primarioData.GL;
                    txtGlVentaDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(_primarioData.GL);
                }
                else
                {
                    //si el GL que tiene asignado a nivel material coincide con el del tipo de material
                    //no lo completa
                }
            }
            if (_primarioData.GLI != null)
            {
                if (_primarioData.GLI != txtGlInventarioDefault.Text)
                {
                    cmbGLInventario.SelectedValue = _primarioData.GLI;
                    txtGlInventarioDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(_primarioData.GLI);
                }
                else
                {
                    //si el GL Inventario que tiene asignado a nivel material coincide con el del tipo de material
                    //no lo completa
                }
            }

            //MRP & Planning Data
            if (_primarioData.TiempoReposicion != null)
                txtTiempoRepo.Text = _primarioData.TiempoReposicion.Value.ToString();

            if (_primarioData.StockMinimo != null)
                txtStockMinimo.Text = _primarioData.StockMinimo.Value.ToString();

            txtSlocIngreso.Text = _tipoMaterialSeleccionado.SLocDefault;
            cmbStockABC.Text = _primarioData.StockABC;
            txtGRP1.Text = _primarioData.MAT_GRP1;
            txtGRP2.Text = _primarioData.MAT_GRP2;
            ckBatchManagementLote.Checked = _primarioData.BATCHMNG;
            lbUnidad.Text = cmbUoM.SelectedItem.ToString();
            txtNetWeight.Text = _primarioData.PesoNetoStandard.ToString();
            if (_primarioData.EmpaqueDefault != null)
                cmbEnvase.SelectedValue = _primarioData.EmpaqueDefault;

            if (_primarioData.SlocSpecific != null)
                cmbSlocEspecificoMaterial.SelectedValue = _primarioData.SlocSpecific;

            //Log & Info Data
            txtCreadoPor.Text = _primarioData.LogCreadoUser;
            txtModificadoPor.Text = _primarioData.LogUpdateUser;
            txtCreadoEn.Text = _primarioData.LogCreadoFecha.ToString("D");
            if (_primarioData.LogUpdateUser != null)
                txtModificadoEn.Text = _primarioData.LogUpdateDate.Value.ToString("D");

            //aca carga los CK
            CargaDatosSegunTipoMaterial();

            //Lab Data
            if (_primarioData.NEL != null)
            {
                txtNEL.Text = _primarioData.NEL.Value.ToString();
                txtDesarrolladoPara.Text = _primarioData.DesarrolladoPara;
            }
            txtBomActivas.Text = @"1";
            txtPlanInspeccion.Text = _primarioData.IP;

            //Info Extendida

            var spec = new MaterialMasterSpecManager().LoadSpecData(_primario);
            new TecserData(GlobalApp.CnnApp).T0009_MATERIALSPEC.SingleOrDefault(
                c => c.IdMaterial == _primarioData.IDMATERIAL.ToUpper());

            if (spec != null)
            {
                sVistaExtendida.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                txtCasNumber.Text = spec.CASNumber;
                txtColourIndex.Text = spec.ColourIndex.ToString();
                txtPantone.Text = spec.Pantone;
                txtRAL.Text = spec.RAL;
                if (spec.CIEL != null)
                    txtCieL.Text = spec.CIEL.Value.ToString("N2");

                if (spec.CIEA != null)
                    txtCieA.Text = spec.CIEA.Value.ToString("N2");

                if (spec.CIEB != null)
                    txtCieB.Text = spec.CIEB.Value.ToString("N2");

                if (spec.Foto1 != null)
                    pbox1.Image = new ImageManager().ConvertByteToImage(spec.Foto1);
            }
            else
            {
                sVistaExtendida.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
            }
        }
        private void CargaDatosSegunTipoMaterial()
        {
            ckDisponibleNP.Checked = _tipoMaterialSeleccionado.DispSalesOrder;
            ckDisponibleOC.Checked = _tipoMaterialSeleccionado.DispOrdenCompra;
            ckDisponibleOF.Checked = _tipoMaterialSeleccionado.DispOrdenFabricacion;
            ckDisponibleBOM.Checked = _tipoMaterialSeleccionado.DispBOMItem;
            ckBatchMngDefault.Checked = _tipoMaterialSeleccionado.ControlStock;
        }

        /// <summary>
        /// Aplicacion de validaciones estrictras y reglas de negocio antes de actualizar un material
        /// </summary>
        private bool ValidationToSave()
        {
            var vx = new ValidacionManager(this, ep, toolTip1);
            if (_modo == 1)
            {
                //Validacion Unica para modo creacion
                vx.Valida(cmbTipoMaterial, cmbTipoMaterial.SelectedValue == null,
                    "Debe Seleccioanr un tipo de Material");
                if (vx.GetResultadoValidacion() == false)
                    return false; //abandona aca la validacion
            }

            vx.Valida(txtPrimario, string.IsNullOrEmpty(txtPrimario.Text), "Debe proveer un codigo de Material");
            vx.Valida(txtDescripcionTipoMaterial, string.IsNullOrEmpty(txtDescripcionTipoMaterial.Text), "La descripcion Tecnica (REAL) del material no puede estar vacia");
            vx.Valida(txtDescripcionOF, string.IsNullOrEmpty(txtDescripcionOF.Text), "Debe proveer una descripcion para impresion interna");
            vx.Valida(cmbTipoMaterial, _tipoMaterialSeleccionado == null, "Debe Seleccionar un tipo de material");
            if (vx.GetResultadoValidacion() == false)
                return false;

            //sino seguimos (aca el tipo de material ya esta provisto seguro
            vx.Valida(cmbOrigen, cmbOrigen.SelectedItem == null, "Debe proveer un Origen para el material");
            vx.Valida(cmbUoM, cmbUoM.SelectedItem == null, "Debe proveer una unidad de Medida");

            if (cmbMonedaCosto.SelectedItem == null)
                cmbMonedaCosto.SelectedItem = "USD";
            return vx.GetResultadoValidacion();
        }
        /// <summary>
        /// Accion segun la confiugracion de la tabla de tipo de materiales
        /// </summary>
        private void AccionSegunTipoMaterialByConfigTable()
        {
            if (_modo == 1)
            {
                //Acciones solo para creacion - default values segun tabla
                cmbUoM.SelectedItem = _tipoMaterialSeleccionado.DefaultUoM;
                txtGlInventarioDefault.Text = _tipoMaterialSeleccionado.GLInvetory;
                txtGlVentaDefault.Text = _tipoMaterialSeleccionado.GLVentas;
                txtGlInventarioDescripcionDefault.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlInventarioDefault.Text);
                txtGlVentaDefaultDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlVentaDefault.Text);
                cmbGLInventario.SelectedIndex = -1;
                cmbGlVenta.SelectedIndex = -1;
                ckBatchMngDefault.Checked = _tipoMaterialSeleccionado.ControlStock;
                ckBatchManagementLote.Checked = _tipoMaterialSeleccionado.ControlStock;
                ckMaterialCosteable.Checked = _tipoMaterialSeleccionado.ControlCosto;
                cmbCarrier.SelectedIndex = -1;
                cmbColor.SelectedIndex = -1;
                btnNewFormula.Enabled = _tipoMaterialSeleccionado.DispOrdenFabricacion;
                btnNewZRLB.Enabled = _tipoMaterialSeleccionado.DispSalesOrder; //si se vende tiene que tener AKA
                btnAddAkaPrimario.Enabled = _tipoMaterialSeleccionado.DispSalesOrder; //si se vende tiene que tener AKA
                btnNewAka.Enabled = _tipoMaterialSeleccionado.DispSalesOrder;    //si se vende tiene que tener AKA 
                cmbOrigen.SelectedItem = _tipoMaterialSeleccionado.OrigenDefault;
                if (_tipoMaterialSeleccionado.OrigenDefault == @"FAB" || _tipoMaterialSeleccionado.OrigenDefault == @"NOD")
                {
                    cmbOrigen.Enabled = false;
                }
            }
            else
            {
                if (_modo == 2)
                {
                    //Solo modo 2
                    btnNewFormula.Enabled = _tipoMaterialSeleccionado.DispOrdenFabricacion;
                    btnNewZRLB.Enabled = _tipoMaterialSeleccionado.DispSalesOrder;
                    btnAddAkaPrimario.Enabled = _tipoMaterialSeleccionado.DispSalesOrder;
                    btnNewAka.Enabled = _tipoMaterialSeleccionado.DispSalesOrder;

                    if (_tipoMaterialSeleccionado.DispSalesOrder)
                    {
                        var existe = new AkaManager().CheckIfExistThisAKA(_primario);
                        btnAddAkaPrimario.Enabled = !existe;
                        btnNewAka.Enabled = true;
                        btnNewZRLB.Enabled = false;
                    }
                    else
                    {
                        btnAddAkaPrimario.Enabled = false;
                        btnNewAka.Enabled = false;
                        btnNewZRLB.Enabled = true;
                    }

                }
                else
                {
                    //solo modo 3
                    btnNewFormula.Enabled = false;
                    btnNewZRLB.Enabled = false;
                    btnAddAkaPrimario.Enabled = false;
                    btnNewAka.Enabled = false;
                }
            }
            //Acciones generales
            {
                if (!_tipoMaterialSeleccionado.DispSalesOrder)
                {
                    cmbGlVenta.Enabled = false;
                    txtGlVentaDefault.ReadOnly = true;
                    cmbGlVenta.SelectedIndex = -1;
                    txtGlVentaDefaultDescripcion.Text = null;
                    txtGlVentaDefault.Text = null;
                }
                cmbMonedaCosto.Enabled = _tipoMaterialSeleccionado.ControlCosto;
            }
        }
        /// <summary>
        /// Funcion que acciona segun el tipo de material 
        /// Primero acciona el control general (por Config)
        /// </summary>
        private void BusinessRulesSegunTipoMaterial()
        {
            AccionSegunTipoMaterialByConfigTable();

            cmbCarrier.Enabled = true;//vamos a controlarlo segun el tipo
            cmbColor.Enabled = true; //vamos a controlarlo segun el tipo
            cmbEnvase.Enabled = true;
            switch (_tipoMaterialSeleccionado.Mtype)
            {
                case "COFA":
                    break;
                case "DESM":
                    cmbCarrier.Enabled = false;
                    cmbColor.Enabled = false;
                    txtConcentracion.ReadOnly = true;
                    txtDureza.ReadOnly = true;
                    break;
                case "FASON":
                    cmbCarrier.Enabled = false;
                    break;
                case "ITAD":
                    cmbCarrier.Enabled = false;
                    cmbColor.Enabled = false;
                    txtConcentracion.ReadOnly = true;
                    txtDureza.ReadOnly = true;
                    break;
                case "ITRE":
                    cmbCarrier.Enabled = false;
                    cmbColor.Enabled = false;
                    txtConcentracion.ReadOnly = true;
                    txtDureza.ReadOnly = true;
                    break;
                case "MAST":
                    break;
                case "MFBN":
                    cmbColor.DataSource = new ColoresManagement().GetColoresList()
                        .Where(c => c.ID_COLOR == "NE" || c.ID_COLOR == "BL").ToList();
                    break;
                case "MFPE":
                    cmbCarrier.SelectedItem = "PE";
                    break;
                case "MFPV":
                    cmbCarrier.SelectedItem = "PVC";
                    break;
                case "MFTR":
                    cmbCarrier.SelectedItem = "TR";
                    break;
                case "MOLI":
                    break;
                case "MPBA":
                    break;
                case "MPPG":
                    cmbCarrier.Enabled = false;
                    break;
                case "MTRBN":
                    cmbCarrier.SelectedItem = "TR";
                    cmbColor.DataSource = new ColoresManagement().GetColoresList()
                        .Where(c => c.ID_COLOR == "NE" || c.ID_COLOR == "BL").ToList();
                    break;
                case "PMIF":
                    break;
                case "POLV":
                    cmbCarrier.SelectedItem = "CaCO3";
                    break;
                case "PREV":
                    break;
                case "ZPVC":
                    cmbCarrier.SelectedItem = "PVC";
                    break;
                case "ZRLB":
                    break;
                case "EPVC":
                    cmbCarrier.SelectedItem = "PVC";
                    break;
                case "CPVC":
                    cmbCarrier.SelectedItem = "PVC";
                    break;
                case "ENVA":
                    cmbCarrier.Enabled = false;
                    cmbOrigen.Enabled = false;
                    cmbColor.Text = null;
                    cmbColor.Enabled = false;
                    txtConcentracion.Text = null;
                    txtDureza.Text = null;
                    cmbEnvase.SelectedIndex = -1;
                    cmbEnvase.Enabled = false;
                    txtConcentracion.ReadOnly = true;
                    txtDureza.ReadOnly = true;
                    break;
                default:
                    MessageBox.Show(
                        @"Atencion el Tipo de Material Seleccionado no tiene funcionalidad especifica definida",
                        @"Notifique sobre este problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }


        /// <summary>
        /// Business Rule para chequear comienzo del material
        /// </summary>
        private bool CheckBRMaterialPrefix()
        {
            if (string.IsNullOrEmpty(_tipoMaterialSeleccionado.MaterialPrefix))
            {
                //no existe business rule para este tipo de material
                return true;
            }
            var materialPrefix = _tipoMaterialSeleccionado.MaterialPrefix.Split(',');
            bool valido = false;
            foreach (string s in materialPrefix)
            {
                if (txtPrimario.Text.StartsWith(s))
                    valido = true;
            }

            return valido;
        }
        private void cmbTipoMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoMaterial.SelectedIndex == -1)
            {
                txtDescripcionTipoMaterial.Text = null;
                return;
            }
            _tipoMaterialSeleccionado = (T0011_MaterialType)cmbTipoMaterial.SelectedItem;
            //txtDescripcionTipoMaterial.Text = _tipoMaterialSeleccionado.Descripcion;
            CargaDatosSegunTipoMaterial();
            BusinessRulesSegunTipoMaterial();
            txtPrimario.Text = null;



        }
        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbColor.SelectedIndex == -1)
            {
                txtDescripcionColor.Text = null;
            }
            else
            {
                var colores = (T0013_COLORES)cmbColor.SelectedItem;
                txtDescripcionColor.Text = colores.DESCRIP_COLOR;
            }
        }

        #region Botones
        private void btnNewFormula_Click(object sender, EventArgs e)
        {
            //creacion de nueva formula.
            //0. material creado, permite formula
            //1. origen fabrcado, etc
        }
        private void btnAddAkaPrimario_Click(object sender, EventArgs e)
        {
            //verificar si existe un AKA con el codigo primario.
            var existe = new AkaManager().CheckIfExistThisAKA(_primario);
            {
                if (existe)
                {
                    MessageBox.Show(@"Puede crear otro codigo AKA, pero tiene que ser diferente al codigo PRIMARIO",
                        @"Ya Existe un codigo AKA=PRIMARIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var primarioCreado = new MaterialMasterManager().CheckIfMaterialExistInT0010(_primario);
                if (!primarioCreado)
                {
                    if (ValidationToSave() == false)
                    {
                        MessageBox.Show(@"Complete/Corrija los errores para poder grabar la informacion primaria",
                            @"Aviso datos Incompletos/Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var resultadoGrabaPrimario = new MaterialMasterManager().CreateUpdateMaterialT0010(MapMaterialT0010ScreenData());
                    if (resultadoGrabaPrimario)
                    {

                    }
                    else
                    {
                        return;
                    }
                }

                using (var f = new FrmMdm03CodigoVentaScreen(_primario, AkaManager.ModoCreacionAka.CopiaPrimario, 1))
                {
                    f.ShowDialog();
                    AkaBs.DataSource = new AkaManager().GetListAkaFromPrimario(_primario);
                }
            }
        }
        private void btnNewAka_Click(object sender, EventArgs e)
        {
            //if (ckRequiereAKA.Checked == false)
            //    return;

            if (_tipoMaterialSeleccionado.DispSalesOrder == false)
            {
                MessageBox.Show(
                    @"Lo siento... pero el tipo de mateiral seleccionado no permite la creacion de un codigo de venta",
                    @"Accion no Permitida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var primarioCreado = new MaterialMasterManager().CheckIfMaterialExistInT0010(_primario);
            if (!primarioCreado)
            {
                if (ValidationToSave() == false)
                {
                    MessageBox.Show(@"Complete/Corrija los errores para poder grabar la informacion primaria",
                        @"Aviso datos Incompletos/Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var resultadoGrabaPrimario = new MaterialMasterManager().CreateUpdateMaterialT0010(MapMaterialT0010ScreenData());
                if (resultadoGrabaPrimario)
                {

                }
                else
                {
                    return;
                }
            }

            using (var f = new FrmMdm03CodigoVentaScreen(_primario, AkaManager.ModoCreacionAka.CodigoLibre, 1))
            {
                f.ShowDialog();
                AkaBs.DataSource = new AkaManager().GetListAkaFromPrimario(_primario);
            }
        }

        #endregion

        private string SetMaterialStatus()
        {
            return "ok";
        }

        private string SetMaintainedViews()
        {
            return "M";
        }


        private void txtPrimario_Validating(object sender, CancelEventArgs e)
        {
            if (_modo == 1)
            {
                var vx = new ValidacionManager(this, ep, toolTip1);
                if (vx.Valida(txtPrimario, string.IsNullOrEmpty(txtPrimario.Text),
                    "Debe proveer un codigo de Material Primario"))
                {
                    //dio OK La validacion de NULL pero no puede ser repetido!
                    txtPrimario.Text = txtPrimario.Text.ToUpper();
                    var mat = new MaterialMasterManager().GetPrimarioInfo(txtPrimario.Text);
                    if (mat != null)
                    {
                        if (vx.Valida(txtPrimario, true,
                            "El Codigo del Material ya Existe! [Modificarlo para poder continuar"))
                        {
                            e.Cancel = true; //por diseño no se va a permitir dejar el codigo repetido
                            return;
                        }
                    }

                    if (!vx.Valida(txtPrimario, CheckBRMaterialPrefix() == false,
                        "El Codigo del Material no coincide con la Regla de Negocios para el comienzo del material"))
                    {
                        e.Cancel = true; //por diseño no se va a permitir dejar el codigo repetido
                        return;
                    }

                    if (_tipoMaterialSeleccionado.Mtype == "POLV")
                    {
                        if (!vx.Valida(txtPrimario, txtPrimario.Text.EndsWith("P") == false,
                            "El Material debe finalizar con la Letra P"))
                        {
                            e.Cancel = true; //por diseño no se va a permitir dejar el codigo repetido
                            return;
                        }
                    }

                    if (!vx.Valida(txtPrimario, txtPrimario.Text.Any(Char.IsWhiteSpace),
                        "El Material NO puede contener espacios"))
                    {
                        e.Cancel = true; //por diseño no se va a permitir dejar el codigo repetido
                        return;
                    }

                    //Dio OK - Vemos si se puede cargar info de NEL
                    _primario = txtPrimario.Text;
                    var dataFromNel = new NelManager().GetInfoFromCodigoDefinitivo(_primario);
                    if (dataFromNel != null)
                    {
                        cmbColor.SelectedValue = dataFromNel.ColorDesarrollo;
                        txtNEL.Text = dataFromNel.NEL.ToString();
                        cmbCarrier.SelectedItem = dataFromNel.BaseDesarrollo;
                        cmbOrigen.SelectedItem = "FAB";
                        txtDesarrolladoPara.Text = dataFromNel.ClienteDescripcion;
                        MessageBox.Show(@"Se han obtenido los Datos desde la Info de Desarrollo [NEL]");
                    }
                }
            }
        }

        private void dgvAkaList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvAkaList[e.ColumnIndex, e.RowIndex].Value.ToString();
                string aka =
                    dgvAkaList[dgvAkaList.Columns[cODVENTADataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value
                        .ToString();

                switch (cellValue)
                {
                    case "VER":
                        var modoX = _modo == 1 ? 2 : _modo;
                        using (var f0 = new FrmMdm03CodigoVentaScreen(modoX, aka))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                //string custName = f0.CustomerName;
                                //SaveToFile(custName);
                            }
                        }

                        break;


                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private void btnNewZRLB_Click(object sender, EventArgs e)
        {
            if (_modo == 3)
            {
                MessageBox.Show(@"En este modo no puede crearse un material ZRLB (debe pasar a modo MM1/MM2",
                    @"Error en Modo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resp =
                MessageBox.Show(
                    @"Confirma la creacion de un ZRLB Material" + Environment.NewLine +
                    @"Reembolsado/Reetiquetado de una Materia Prima", @"ZRLB Process", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;

            //Validar que se puede crear un ZRLB.-> Tiene que ser MP?

            using (var f = new FrmMdm03CodigoVentaScreen(_primario, AkaManager.ModoCreacionAka.TipoZrlb, 1))
            {
                f.ShowDialog();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.Title = @"Seleccione una Imagen/Color Material";
            pic.Filter = @"JPG|*.jpg|PNG|*.png|GIF|*.gif|BMP|*.bmp";
            pic.Multiselect = false;

            if (pic.ShowDialog() == DialogResult.OK)
            {
                this.pbox1.ImageLocation = pic.FileName;
            }
        }

        private T0010_MATERIALES MapMaterialT0010ScreenData()
        {
            if (cmbStockABC.SelectedItem == null)
                cmbStockABC.SelectedItem = "C";

            var materialData = new T0010_MATERIALES()
            {
                IDMATERIAL = txtPrimario.Text.ToUpper(),
                TIPO_MATERIAL = cmbTipoMaterial.SelectedValue.ToString(),
                ACTIVO = ckMaterialActivo.Checked,
                MATERIAL_STATUS = txtStatus.Text,
                UNIDAD = cmbUoM.Text,
                ORIGEN = cmbOrigen.SelectedItem.ToString(),
                BATCHMNG = ckBatchManagementLote.Checked,
                StockABC = cmbStockABC.SelectedItem.ToString(),
                IP = txtPlanInspeccion.Text,
                MAT_GRP1 = txtGRP1.Text,
                MAT_GRP2 = txtGRP2.Text,
                MonedaCosto = cmbMonedaCosto.SelectedItem.ToString(),
                COMPUESTO_BASE = cmbCarrier.SelectedItem?.ToString(),
                COLOR = cmbColor.SelectedValue?.ToString(),
                DescripcionFormulacion = txtDescripcionOF.Text,
                DescripcionTecnicaLab = txtDescripcionTecnica.Text,
                FORM_COSTO = null,
                CONCENTRACION = null,
                Dureza = null,
                TiempoReposicion = null,
                StockMinimo = null,
                NEL = null,
                DesarrolladoPara = txtDesarrolladoPara.Text,
                Status = SetMaterialStatus(),
                GL = null,
                GLI = null,
                MaintainedViews = SetMaintainedViews(),
                MAT_DESC = txtDescripcionOF.Text, //todo: eliminar este campo
                LogCreadoFecha = String.IsNullOrEmpty(txtCreadoEn.Text)
                    ? DateTime.Now
                    : Convert.ToDateTime(txtCreadoEn.Text),
                LogCreadoUser = txtCreadoPor.Text,
                LogUpdateUser = null,
                LogUpdateDate = null,
                SlocSpecific = "", //mapeado abajo
                EmpaqueDefault = null, //mapeado abajo
                PesoNetoStandard = null //mapea abajo
            };

            if (!string.IsNullOrEmpty(txtFormulaCosteo.Text))
                materialData.FORM_COSTO = Convert.ToInt32(txtFormulaCosteo.Text);

            if (!string.IsNullOrEmpty(txtConcentracion.Text))
                materialData.CONCENTRACION = FormatAndConversions.CPorcentajeADecimal(txtConcentracion.Text);

            if (!string.IsNullOrEmpty(txtDureza.Text))
                materialData.Dureza = Convert.ToDecimal(txtDureza.Text);

            if (!string.IsNullOrEmpty(txtTiempoRepo.Text))
                materialData.TiempoReposicion = Convert.ToInt32(txtTiempoRepo.Text);

            if (!string.IsNullOrEmpty(txtStockMinimo.Text))
                materialData.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);

            if (!string.IsNullOrEmpty(txtNEL.Text))
                materialData.NEL = Convert.ToInt32(txtNEL.Text);

            if (cmbGlVenta.SelectedValue != null)
                materialData.GL = cmbGlVenta.SelectedValue.ToString();

            if (cmbGLInventario.SelectedValue != null)
                materialData.GLI = cmbGLInventario.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(txtNetWeight.Text))
                materialData.PesoNetoStandard = Convert.ToDecimal(txtNetWeight.Text);

            if (cmbEnvase.SelectedValue != null)
                materialData.EmpaqueDefault = cmbEnvase.SelectedValue.ToString();

            if (cmbSlocEspecificoMaterial.SelectedValue != null)
                materialData.SlocSpecific = cmbSlocEspecificoMaterial.SelectedValue.ToString();


            return materialData;
        }
        private T0009_MATERIALSPEC MapMaterialT0009AditionalSpecificationScreenData()
        {
            var matspec = new T0009_MATERIALSPEC()
            {
                CASNumber = txtCasNumber.Text,
                IdMaterial = txtPrimario.Text.ToUpper(),
                Pantone = txtPantone.Text,
                RAL = txtRAL.Text,
                CIEA = null,
                CIEB = null,
                CIEL = null,
                ColourIndex = null,
            };

            if (!string.IsNullOrEmpty(txtCieA.Text))
                matspec.CIEA = Convert.ToDecimal(txtCieA.Text);

            if (!string.IsNullOrEmpty(txtCieB.Text))
                matspec.CIEB = Convert.ToDecimal(txtCieB.Text);

            if (!string.IsNullOrEmpty(txtCieL.Text))
                matspec.CIEL = Convert.ToDecimal(txtCieL.Text);

            if (!string.IsNullOrEmpty(txtColourIndex.Text))
                matspec.ColourIndex = Convert.ToDecimal(txtColourIndex.Text);

            if (pbox1.Image != null)
                matspec.Foto1 = new ImageManager().ConvertFiltoByte(pbox1.ImageLocation);

            return matspec;
        }
        private void AceptaSoloDecimal(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void AceptaSoloEntero(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void cmbGLInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGLInventario.SelectedIndex == -1)
            {
                txtGlInventarioDescripcion.Text = null;
            }
            else
            {
                txtGlInventarioDescripcion.Text =
                    GLAccountManagement.GetGLDescriptionFromT135(cmbGLInventario.SelectedValue.ToString());
            }

        }
        private void cmbGlVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGlVenta.SelectedIndex == -1)
            {
                txtGlVentaDescripcion.Text = null;
                return;
            }
            else
            {
                txtGlVentaDescripcion.Text =
                    GLAccountManagement.GetGLDescriptionFromT135(cmbGlVenta.SelectedValue.ToString());
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidationToSave() == false)
            {
                // MessageBox.Show(@"Complete/Corrija los errores para poder grabar este material",
                //     @"Aviso datos Incompletos/Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_tipoMaterialSeleccionado.DispSalesOrder)
            {
                //chequear que el material tenga codigo de venta creado
                var cantidadAKA = new AkaManager().RetornaCantidadAKA(_primario);
                if (cantidadAKA == 0)
                {
                    var rx = MessageBox.Show(@"El tipo de material seleccionado requiere la creacion de un codigo de Venta" +
                                             Environment.NewLine +
                                             @"Confirma la creacion de un codigo de ventas con codigo [Primario] a continuacion?",
                        @"Validacion de Codigo de Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rx == DialogResult.No)
                        return;

                }
            }
            var x = new MaterialMasterManager().CreateUpdateMaterialT0010(MapMaterialT0010ScreenData());
            var dspec = new MaterialMasterSpecManager().SaveSpecData(MapMaterialT0009AditionalSpecificationScreenData());
            if (x)
            {
                MessageBox.Show(@"Se ha grabado correctamente el material en pantalla", @"Datos Guardados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbOrigen_SelectedValueChanged(object sender, EventArgs e)
        {
            //al modificar el origen - ojo porque el origen define el tema de costos!
            if (cmbOrigen.SelectedIndex == -1)
            {
                txtOrigen.Text = null;
                return;
            }

            string valorOrigen = cmbOrigen.SelectedItem.ToString();
            switch (valorOrigen)
            {
                case "NAC":
                    txtOrigen.Text = @"Compra Local";
                    break;
                case "IMP":
                    txtOrigen.Text = @"Importado";
                    break;
                case "FAB":
                    txtOrigen.Text = @"Fabricado";
                    break;
                default:
                    txtOrigen.Text = @"Indeterminado";
                    break;
            }
        }
        private void cmbGLInventario_Validated(object sender, EventArgs e)
        {

        }
        private void cmbGLInventario_Validating_1(object sender, CancelEventArgs e)
        {
            var cmb = (ComboBox)sender;
            if (cmb.SelectedValue == null && cmb.Text != string.Empty)
            {
                e.Cancel = true;
            }
            else
            {

            }
        }








        private void btnActivarMaterial_Click(object sender, EventArgs e)
        {

        }

        private void btnDesactivarMaterial_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipoMaterial_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtPrimario_Enter(object sender, EventArgs e)
        {
            if (_modo == 1)
            {
                if (cmbTipoMaterial.SelectedValue == null)
                {
                    MessageBox.Show(@"Debe completar primero el Tipo de Material", @"Atencion", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    cmbTipoMaterial.Focus();
                }
            }
        }

        private void cmbEnvase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEnvase.SelectedIndex == -1)
            {
                txtDescripcionEnvase.Text = null;
                return;
            }
        }

        private void cmbEnvase_Validating(object sender, CancelEventArgs e)
        {
            if (cmbEnvase.SelectedValue == null && cmbEnvase.Text != string.Empty)
            {
                e.Cancel = true;
            }

            if (cmbEnvase.SelectedValue != null)
            {
                var data = (T0010_Container)cmbEnvase.SelectedItem;
                txtDescripcionEnvase.Text = data.ContainerDescription;
            }
            else
            {
                txtDescripcionEnvase.Text = null;
            }
        }

        private void cmbTipoMaterial_Validating(object sender, CancelEventArgs e)
        {
            if (cmbTipoMaterial.SelectedValue == null && string.IsNullOrEmpty(cmbTipoMaterial.Text))
            {
                e.Cancel = true;
                txtDescripcionTipoMaterial.Text = null;
            }
            else
            {
                if (cmbTipoMaterial.SelectedValue != null)
                {
                    var data = (T0011_MaterialType)cmbTipoMaterial.SelectedItem;
                    txtDescripcionTipoMaterial.Text = data.Descripcion;
                }
                else
                {
                    txtDescripcionTipoMaterial.Text = null;
                }
            }
        }

        private void cmbUoM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUoM.SelectedItem != null)
            {
                lbUnidad.Text = cmbUoM.SelectedItem.ToString();
            }
        }
    }
}
