using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using TecserEF.Entity;

namespace MASngFE.SuperMD
{
    public partial class FrmMaterialTypeManager : Form
    {
        public FrmMaterialTypeManager()
        {
            InitializeComponent();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletosSave() == false)
            {
                // MessageBox.Show(@"Para grabar debe completar los datos obligatorios", @"Error en Grabacion de Datos",
                //      MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultado = new MaterialTypeManager().SaveMaterialTypeData(MapScreenData());
            if (resultado > 0)
            {
                MessageBox.Show(@"Los Datos se han grabado correctamente", @"Operacion Exitosa", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"No se han encontrado cambios para guardar", @"Datos no guardados", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
        private bool ValidaDatosCompletosSave()
        {
            int respuesta = 0;

            respuesta += ValidaSinDatos(txtMaterialType);
            respuesta += ValidaSinDatos(txtMaterialTypeDescription);
            respuesta += ValidaSinDatos(txtMRPGeneraDocumento);
            if (ckDisponibleNotaPedido.Checked)
                respuesta += ValidaSinDatos(txtGLVenta, "Debe completar GL Venta para este material que permite venta");

            if (ckStockManagement.Checked)
                respuesta += ValidaSinDatos(txtGLInventario,
                    "Debe completar GL Inventario para este material con control Inventario");

            EsteticaPaneles(panPropiedades);
            EsteticaPaneles(panComportamiento);

            return respuesta == 0;
        }
        private int ValidaSinDatos(Control control, string texto = "Datos Incompletos o Incorrectos")
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                ActivaToolTip(control, texto);
                control.BackColor = Color.LightCoral;
                return 1;
            }
            control.BackColor = Color.White;
            return 0;
        }
        private void ActivaToolTip(Control control, string texto)
        {
            TextBox txt = (TextBox)control;
            toolTip1.ToolTipTitle = "Datos Incompletos o Incorrectos";
            toolTip1.Show(texto, txt, txt.Location, 5000);
            //MessageBox.Show(control.Name);
        }
        private T0011_MaterialType MapScreenData()
        {
            var data = new T0011_MaterialType()
            {
                //GL = txtGLInventario.Text,
                //COMENTARIOS = txtComentario.Text,
                //DEF_UNIT = txtDefaultUnit.Text,
                //DESCRIPCION = txtMaterialTypeDescription.Text,
                //DISPO_BOM = ckDisponibleBOM.Checked,
                //DISPO_FA = ckDisponibleFactura.Checked,
                //DISPO_NP = ckDisponibleNotaPedido.Checked,
                //DISPO_OC = ckDisponibleOC.Checked,
                //DISPO_OF = ckDisponibleOF.Checked,
                //DISPO_RE = ckDisponibleRemito.Checked,
                //DISPO_RE_2 = ckDisponibleRemitoL2.Checked,
                //DOC_GEN = txtMRPGeneraDocumento.Text,
                //GLV = txtGLVenta.Text,
                //MGADD = Convert.ToDecimal(txtControlCostoAdded.Text),
                //MGMULT = Convert.ToDecimal(txtControlCostoMultiplicador),
                //MM_AKA = ckPermiteAKA.Checked,
                //MM_BASE = ckBase.Checked,
                //MM_BATCH_DF = ckBatchManagementDefault.Checked,
                //MM_COLOR = ckColor.Checked,
                //STOCK = ckStockManagement.Checked,
                //SLOC_DEF = txtSlocDefault.Text,
                //TIPO_MATERIAL = txtMaterialType.Text,
            };
            return data;
        }
        private void MapDatosDbToScreen()
        {
            var data = new MaterialTypeManager().GetMtype(cmbMaterialType.SelectedValue.ToString());
            if (data == null)
            {
                BlanqueaDatos();
                return;
            }

            ////if (data.STOCK == null)
            ////    data.STOCK = false;

            ////if (data.MM_COLOR == null)
            ////    data.MM_COLOR = false;

            ////if (data.MM_BASE == null)
            ////    data.MM_BASE = false;

            ////if (data.MM_BATCH_DF == null)
            ////    data.MM_BATCH_DF = false;

            ////if (data.MM_AKA == null)
            ////    data.MM_AKA = false;

            ////if (data.DISPO_NP == null)
            ////    data.DISPO_NP = false;

            ////if (data.DISPO_RE == null)
            ////    data.DISPO_RE = false;

            ////if (data.DISPO_RE_2 == null)
            ////    data.DISPO_RE_2 = false;

            ////if (data.DISPO_FA == null)
            ////    data.DISPO_FA = false;

            ////if (data.DISPO_BOM == null)
            ////    data.DISPO_BOM = false;

            ////if (data.DISPO_OC == null)
            ////    data.DISPO_OC = false;

            ////if (data.DISPO_OF == null)
            ////    data.DISPO_OF = false;

            //////
            ////txtMaterialType.Text = data.TIPO_MATERIAL;
            ////txtMaterialTypeDescription.Text = data.DESCRIPCION;
            ////ckStockManagement.Checked = data.STOCK;
            //////
            ////ckColor.Checked = data.MM_COLOR;
            ////ckBase.Checked = data.MM_BASE;
            ////ckBatchManagementDefault.Checked = data.MM_BATCH_DF;
            ////ckPermiteAKA.Checked = data.MM_AKA;
            ////txtMRPGeneraDocumento.Text = data.DOC_GEN;
            //////
            ////txtControlCostoMultiplicador.Text = data.MGMULT.ToString();
            ////txtControlCostoAdded.Text = data.MGADD.ToString();

            //////

            ////if (data.GL == null)
            ////{
            ////    cmbGLI.SelectedValue = "CUENTA NO DEFINIDA";
            ////    txtGLInventario.Text = @"0.0.0.0";
            ////}
            ////else
            ////{
            ////    cmbGLI.SelectedValue = data.GL;
            ////}


            ////if (data.GLV == null)
            ////{
            ////    cmbGLV.SelectedValue = "CUENTA NO DEFINIDA";
            ////    txtGLVenta.Text = @"0.0.0.0";
            ////}
            ////else
            ////{
            ////    cmbGLV.SelectedValue = data.GLV;
            ////}

            //////txtGLInventario.Text = data.GL;
            //////txtGLInventarioDescription.Text = GLAccountManagement.GetGLDescriptionFromT135(data.GL);
            //////txtGLVenta.Text = data.GLV;
            //////txtGLVentaDescription.Text = GLAccountManagement.GetGLDescriptionFromT135(data.GLV);
            //////
            ////ckDisponibleNotaPedido.Checked = data.DISPO_NP;
            ////ckDisponibleRemito.Checked = data.DISPO_RE;
            ////ckDisponibleRemitoL2.Checked = data.DISPO_RE_2;
            ////ckDisponibleFactura.Checked = data.DISPO_FA;
            ////ckDisponibleBOM.Checked = data.DISPO_BOM;
            ////ckDisponibleOF.Checked = data.DISPO_OF;
            ////ckDisponibleOC.Checked = data.DISPO_OC;
            //////
            ////txtComentario.Text = data.COMENTARIOS;
            ////txtDefaultUnit.Text = data.DEF_UNIT;
            ////txtSlocDefault.Text = data.SLOC_DEF;

            EsteticaPaneles(panPropiedades);
            EsteticaPaneles(panComportamiento);
        }
        private void BlanqueaDatos()
        {
            txtMaterialType.Text = null;
            txtMaterialTypeDescription.Text = null;
            ckStockManagement.Checked = false;

            ckColor.Checked = false;
            ckBase.Checked = false;
            ckBatchManagementDefault.Checked = false;
            ckPermiteAKA.Checked = false;
            txtMRPGeneraDocumento.Text = null;

            txtControlCostoMultiplicador.Text = @"0";
            txtControlCostoAdded.Text = @"0";

            cmbGLV.SelectedValue = "CUENTA NO DEFINIDA";
            cmbGLI.SelectedValue = "CUENTA NO DEFINIDA";
            txtGLInventario.Text = @"0.0.0.0";
            txtGLVenta.Text = @"0.0.0.0";


            ckDisponibleNotaPedido.Checked = false;
            ckDisponibleRemito.Checked = false;
            ckDisponibleRemitoL2.Checked = false;
            ckDisponibleFactura.Checked = false;
            ckDisponibleBOM.Checked = false;
            ckDisponibleOF.Checked = false;
            ckDisponibleOC.Checked = false;

            txtComentario.Text = null;
            txtSlocDefault.Text = null;
            txtDefaultUnit.Text = null;
        }
        private void btnNuevoTipo_Click(object sender, EventArgs e)
        {
            txtMaterialType.Enabled = true;
            cmbMaterialType.SelectedIndex = -1;
        }
        private void txtControlCostoMultiplicador_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void cmbMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterialType.SelectedIndex != -1)
            {
                MapDatosDbToScreen();
                txtMaterialType.Enabled = false;
            }
            else
            {
                BlanqueaDatos();
            }
            EsteticaPaneles(panPropiedades);
            EsteticaPaneles(panComportamiento);
        }
        private void FrmMaterialTypeManager_Load(object sender, EventArgs e)
        {
            MaterialTypeBs.DataSource = new MaterialTypeManager().GetListMtype();
            cmbMaterialType.SelectedIndex = -1;
            t0135GLVBs.DataSource = new GLAccountManagement().GetListGLImputacionVentas();
            t0135GLIBs.DataSource = new GLAccountManagement().GetListGLInventario();
            cmbGLI.SelectedIndex = -1;
            cmbGLV.SelectedIndex = -1;
        }
        private void EsteticaPaneles(Panel panX)
        {
            foreach (Control c in panX.Controls)
            {
                if (c is CheckBox)
                {
                    var ck = (CheckBox)c;
                    ck.BackColor = ck.Checked ? Color.MediumSeaGreen : Color.RosyBrown;
                }
            }
        }
        private void cmbGLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGLV.SelectedIndex == -1)
            {
                txtGLVenta.Text = @"0.0.0.0";
            }
            else
            {
                txtGLVenta.Text = cmbGLV.SelectedValue.ToString();
            }
        }
        private void cmbGLI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGLI.SelectedIndex == -1)
            {
                txtGLInventario.Text = @"0.0.0.0";
            }
            else
            {
                txtGLInventario.Text = cmbGLI.SelectedValue.ToString();
            }
        }
    }
}

