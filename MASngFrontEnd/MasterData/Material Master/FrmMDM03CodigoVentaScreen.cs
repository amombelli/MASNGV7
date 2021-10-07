using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.MasterData.BOM;
using Tecser.Business.MasterData.Material_Master;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.CO;
using TecserEF.Entity;

namespace MASngFE.MasterData.Material_Master
{
    public partial class FrmMdm03CodigoVentaScreen : Form
    {
        //constructor para crear un nuevo AKA (posibilidad copia primario)
        public FrmMdm03CodigoVentaScreen(string primario, AkaManager.ModoCreacionAka modoCreacion, int modo = 1)
        {
            _modo = modo;
            _primario = primario;
            _modoCreacion = modoCreacion;
            InitializeComponent();
        }

        //consutructor carga de datos de un AKA especifico.
        //modo debiera ser 2 o 3
        public FrmMdm03CodigoVentaScreen(int modo, string codigoAka)
        {
            _modo = modo;
            _aka = codigoAka;
            _primario = AkaManager.GetPrimario(_aka);
            InitializeComponent();
        }

        //--------------------------------------------------------------------
        private readonly int _modo;
        private T0010_MATERIALES _dataPrimario;
        private T0011_MaterialType _tipoMaterialSeleccionado;
        private readonly string _primario;
        private string _aka;
        private readonly AkaManager.ModoCreacionAka _modoCreacion;
        private bool _crearPrimario; //crea aka con codigo primario.
        //--------------------------------------------------------------------

        private void FrmCodigoVentaScreen_Load(object sender, EventArgs e)
        {
            this.cmbTipoMaterial.SelectedIndexChanged -= new System.EventHandler(this.cmbTipoMaterial_SelectedIndexChanged);
            TipoMaterialBs.DataSource = new MaterialTypeManager().GetMtypeForAkaProducts();
            ContainerBs.DataSource = new MaterialMasterManager().GetListaEnvases();
            GlxVentaBs.DataSource = new GLAccountManagement().GetListGLImputacionVentas();
            LoadPrimarioData();
            AccionSegunModoCarga();
            this.cmbTipoMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMaterial_SelectedIndexChanged);

        }
        private void AccionSegunModoCarga()
        {
            switch (_modo)
            {
                case 1:
                    ckActivo.Checked = true;
                    switch (_modoCreacion)
                    {
                        case AkaManager.ModoCreacionAka.CopiaPrimario:
                            txtCodigoVenta.Text = txtPrimario.Text;
                            cmbTipoMaterial.SelectedValue = txtTipoMaterialPrimario.Text;
                            cmbTipoMaterial.SelectedValue = txtTipoMaterialPrimario.Text;
                            txtGlVentaDefault.Text = _tipoMaterialSeleccionado.GLVentas;
                            if (_dataPrimario.GL != null)
                            {
                                //si a nivel primario tiene asignado un GL lo asigna en el AKA
                                cmbGlVenta.SelectedValue = _dataPrimario.GL;
                                txtGlVentaDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(_dataPrimario.GL);
                            }
                            else
                            {
                                cmbGlVenta.SelectedIndex = -1;
                                txtGlVentaDescripcion.Text = null;
                            }
                            //Descripcion default
                            txtDescripcionFactura.Text = txtDescripcionPrimario.Text.Truncate(50);
                            txtDescripcionFacturaL5.Text = (@"DISP. " + txtDescripcionPrimario.Text).Truncate(50);
                            this.cmbTipoMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbTipoMaterial_SelectedIndexChanged);
                            break;
                        case AkaManager.ModoCreacionAka.CodigoLibre:

                            break;
                        case AkaManager.ModoCreacionAka.TipoZrlb:
                            //Modo crea un ZRLB
                            cmbTipoMaterial.Text = @"ZRLB";
                            cmbTipoMaterial.Enabled = false;
                            txtDescripcionTipoMaterial.Text = @"Reembolsado/Reetiquetado de MP";
                            var tipoMat = new MaterialTypeManager().GetMtype("ZRLB");
                            txtGlVentaDefault.Text = tipoMat.GLVentas;
                            txtGlVentaDefaultDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(tipoMat.GLVentas);
                            cmbGlVenta.SelectedIndex = -1;
                            cmbGlVenta.Enabled = false;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;
                case 2:
                    LoadAkaData();
                    break;
                case 3:
                    LoadAkaData();
                    btnGrabar.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void LoadPrimarioData()
        {
            _dataPrimario = new MaterialMasterManager().GetPrimarioInfo(_primario);
            txtPrimario.Text = _dataPrimario.IDMATERIAL;
            txtDescripcionPrimario.Text = _dataPrimario.DescripcionFormulacion;
            txtTipoMaterialPrimario.Text = _dataPrimario.TIPO_MATERIAL;
            if (_dataPrimario.PesoNetoStandard != null)
                txtPesoNeto.Text = _dataPrimario.PesoNetoStandard.Value.ToString("N2");

            if (!string.IsNullOrEmpty(_dataPrimario.EmpaqueDefault))
            {
                //Tiene empaque asignado en Primario
                cmbEmpaque.SelectedValue = _dataPrimario.EmpaqueDefault;
                var dataE = (T0010_MATERIALES)cmbEmpaque.SelectedItem;
                txtDescripcionEmpaque.Text = dataE.DescripcionFormulacion;
            }
            else
            {
                //no tiene info de empaque desde primario
            }
        }
        private void LoadAkaData()
        {
            var aka = new AkaManager().GetAkaInformation(_aka);
            txtCodigoVenta.Text = aka.CODVENTA.ToUpper();
            cmbTipoMaterial.SelectedValue = aka.TIPO_MATERIAL;
            txtDescripcionFactura.Text = aka.MAT_DESC2;
            txtDescripcionFacturaL5.Text = aka.MAT_DESC_L5;

            if (cmbTipoMaterial.SelectedValue != null)
            {
                var tipoData = new MaterialTypeManager().GetMtype(cmbTipoMaterial.SelectedValue.ToString());
                txtDescripcionTipoMaterial.Text = tipoData.Descripcion;
                txtGlVentaDefault.Text = tipoData.GLVentas;
                txtGlVentaDefaultDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlVentaDefault.Text);
            }

            if (aka.GLV != null)
            {
                //tiene un GLV asignado en el AKA
                cmbGlVenta.SelectedValue = aka.GLV;
                txtGlVentaDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(aka.GLV);
            }
            else
            {
                if (!string.IsNullOrEmpty(_dataPrimario.GL))
                {
                    //Si tiene un GLV especifico en el material primario lo carga
                    cmbGlVenta.SelectedValue = _dataPrimario.GL;
                    txtGlVentaDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(aka.GLV);
                }
                else
                {
                    //al no tener un GLV especifico lo pasa a null y usa el default por el tipo
                    cmbGlVenta.SelectedIndex = -1;
                    txtGlVentaDescripcion.Text = null;
                }
            }

            //txtPesoNeto.Text = aka.T0010_MATERIALES.PesoNetoStandard.ToString();
            if (aka.Container == null)
            {
                cmbEmpaque.SelectedIndex = -1;
                txtDescripcionEmpaque.Text = null;
            }
            else
            {
                cmbEmpaque.SelectedValue = aka.Container;
                var data = (T0010_Container)cmbEmpaque.SelectedItem;
                txtDescripcionEmpaque.Text = data.ContainerDescription;
            }

            if (aka.FECHA == null)
                aka.FECHA = DateTime.Now;

            if (string.IsNullOrEmpty(txtModificadoPor.Text))
                aka.LOGUSER = GlobalApp.AppUsername;

            txtModificadoEn.Text = aka.FECHA.Value.ToString("g");
            txtModificadoPor.Text = aka.LOGUSER;
            ckActivo.Checked = aka.ACTIVO;
        }
        private void cmbTipoMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoMaterial.SelectedIndex == -1)
            {
                _tipoMaterialSeleccionado = null;
                txtGlVentaDefault.Text = null;
                txtGlVentaDefaultDescripcion.Text = null;
                return;
            }
            _tipoMaterialSeleccionado = new MaterialTypeManager().GetMtype(cmbTipoMaterial.SelectedValue.ToString());
            txtDescripcionTipoMaterial.Text = _tipoMaterialSeleccionado.Descripcion;
            txtGlVentaDefault.Text = _tipoMaterialSeleccionado.GLVentas;
            txtGlVentaDefaultDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlVentaDefault.Text);
        }
        private void txtDescripcionFactura_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcionFacturaL5.Text))
            {
                txtDescripcionFacturaL5.Text = @"Disp. " + txtDescripcionFactura.Text;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidaDatosAntesGrabar() == false)
            {
                MessageBox.Show(@"Para poder grabar este material debe primero corregir los errores mostrador",
                    @"Error en Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultadoSave = new AkaManager().UpdateAkaData(MapAkaData());
            if (resultadoSave)
            {
                if (_modoCreacion == AkaManager.ModoCreacionAka.TipoZrlb)
                {
                    if (!BOMManagerMD.CheckIfBOMExist(txtCodigoVenta.Text))
                    {
                        //No Existe formula ZRLB - La crea
                        var idF = new ZRLBManager().CreaZRLBBOM(_primario, txtCodigoVenta.Text);
                        if (idF > 0)
                        {
                            MessageBox.Show($@"Se ha creado automaticamente una Formula ZRLB con ID# {idF}",
                                @"Creacion Automatica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(@"Ha Ocurrido un Error al intentar crear la Formula ZRLB Automatica",
                                @"Error en Creacin ZRLB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                MessageBox.Show(@"Se ha guardado correctamente la informacion del codigo de Venta", @"Datos Guardados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"No se encontraron cambios para guardar", @"Datos No Guardados", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
        }
        private bool ValidaDatosAntesGrabar()
        {
            var rtn = true;
            if (string.IsNullOrEmpty(txtCodigoVenta.Text))
            {
                ep.SetError(txtCodigoVenta, "Debe proveer el nombre del material");
                rtn = false;
            }

            if (_modoCreacion != AkaManager.ModoCreacionAka.TipoZrlb)
            {
                if (cmbTipoMaterial.SelectedValue == null)
                {
                    ep.SetError(cmbTipoMaterial, "Debe proveer tipo de material de venta");
                    rtn = false;
                }
            }

            if (string.IsNullOrEmpty(txtDescripcionFactura.Text))
            {
                ep.SetError(txtDescripcionFactura, "Este dato no puede estar incompleto");
                rtn = false;
            }

            if (string.IsNullOrEmpty(txtDescripcionFacturaL5.Text))
            {
                ep.SetError(txtDescripcionFacturaL5, "Este dato no puede estar incompleto");
                rtn = false;
            }


            if (cmbGlVenta.SelectedIndex == -1)
                cmbGlVenta.SelectedItem = txtGlVentaDefault.Text;

            return rtn;
        }
        private T0011_MATERIALES_AKA MapAkaData()
        {
            var mat = new T0011_MATERIALES_AKA()
            {
                ACTIVO = ckActivo.Checked,
                CODVENTA = txtCodigoVenta.Text.ToUpper(),
                MAT_DESC2 = txtDescripcionFactura.Text,
                MAT_DESC_L5 = txtDescripcionFacturaL5.Text,
                PRIMARIO = txtPrimario.Text,
                TIPO_MATERIAL = cmbTipoMaterial.SelectedValue.ToString(),
                Container = null,
                GLV = null,
            };

            if (_modoCreacion == AkaManager.ModoCreacionAka.TipoZrlb)
                mat.TIPO_MATERIAL = "ZRLB";

            if (cmbGlVenta.SelectedValue != null)
            {
                //si se informa un GLV diferente lo guarda. Si no, no.
                if (cmbGlVenta.SelectedValue.ToString() != txtGlVentaDefault.Text)
                {
                    mat.GLV = cmbGlVenta.SelectedValue.ToString();
                }
            }
            return mat;
        }
        private void cmbGlVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGlVenta.SelectedIndex != -1)
            {
                txtGlVentaDescripcion.Text =
                    GLAccountManagement.GetGLDescriptionFromT135(cmbGlVenta.SelectedValue.ToString());
            }
        }
        private void txtCodigoVenta_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoVenta.Text))
            {
                ep.SetError(txtCodigoVenta, "Debe proveer un codigo de material de venta!");
                e.Cancel = true;
                return;
            }
            else
            {
                if (txtCodigoVenta.Text == _aka)
                {
                    return;
                }

                var existe = new AkaManager().CheckIfExistThisAKA(txtCodigoVenta.Text);
                if (existe)
                {
                    ep.SetError(txtCodigoVenta, "El Codigo provisto ya existe. Debe proveer un codigo diferente");
                    e.Cancel = true;
                    return;
                }

                if (_modoCreacion == AkaManager.ModoCreacionAka.TipoZrlb)
                {
                    if (txtCodigoVenta.Text.ToUpper().Equals(txtPrimario.Text.ToUpper()))
                    {
                        MessageBox.Show(@"En un ZRLB el codigo de venta no puede ser igual a un codigo primario!",
                            @"Error en Asignacion de Codigo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbEmpaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpaque.SelectedIndex == -1)
            {
                txtDescripcionEmpaque.Text = null;
            }
            else
            {
                var data = (T0010_Container)cmbEmpaque.SelectedItem;
                txtDescripcionEmpaque.Text = data.ContainerDescription;
            }
        }

        private void cmbTipoMaterial_Validating(object sender, CancelEventArgs e)
        {
            if (cmbTipoMaterial.SelectedValue == null && cmbTipoMaterial.Text == string.Empty)
                e.Cancel = true;

        }
    }
}