using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using TecserEF.Entity;

namespace MASngFE.MasterData.Material_Master
{
    public partial class FrmMaterialMasterAKA : Form
    {
        public FrmMaterialMasterAKA(string primario, int modo, string aka = null)
        {
            _primario = primario;
            _aka = aka;
            _modo = modo;
            InitializeComponent();
        }
        //
        private readonly string _primario;
        private readonly int _modo;
        private string _aka;
        //
        private void FrmMaterialMasterAKA_Load(object sender, EventArgs e)
        {
            txtCodigoPrimario.Text = _primario;
            txtPrimarioDescripcion.Text = new MaterialMasterManager().GetPrimarioInfo(_primario).MAT_DESC;

            if (string.IsNullOrEmpty(_aka) != true)
            {
                if (_modo == 1)
                {
                    //modo creacion AKA automatico
                    txtCodigoVenta.Text = _aka;
                    ckActivo.Checked = true;
                    cmbTipoMaterial.Text = new MaterialMasterManager().GetPrimarioInfo(_primario).TIPO_MATERIAL;
                }
                else
                {
                    LoadExistingAKAData();
                }
            }

            ConfiguraSegunModo();

        }

        private void LoadExistingAKAData()
        {
            if (string.IsNullOrEmpty(_aka) == true)
                return;

            var data = new MaterialMasterManager().GetSpecificAkaInformation(_aka);
            txtCodigoVenta.Text = data.CODVENTA;
            txtDescripcionL1.Text = data.MAT_DESC2;
            txtDescripcionL5.Text = data.MAT_DESC_L5;
            cmbTipoMaterial.Text = data.TIPO_MATERIAL;
            ckActivo.Checked = data.ACTIVO;
            txtLogFecha.Text = data.FECHA == null ? @"01/01/2010" : data.FECHA.ToString();
            txtlogUser.Text = data.LOGUSER;
            ckActivo.BackColor = ckActivo.Checked ? Color.GreenYellow : Color.Crimson;
        }
        private void ConfiguraSegunModo()
        {
            txtCodigoVenta.ReadOnly = true;
            txtDescripcionL1.ReadOnly = true;
            txtDescripcionL5.ReadOnly = true;
            ckActivo.Enabled = false;
            btnGuardar.Enabled = false;
            switch (_modo)
            {
                case 1:
                    txtCodigoVenta.ReadOnly = false;
                    txtDescripcionL1.ReadOnly = false;
                    txtDescripcionL5.ReadOnly = false;
                    ckActivo.Enabled = true;
                    ckActivo.Checked = true;
                    btnGuardar.Enabled = true;
                    t0012TIPOMATERIALBindingSource1.DataSource = new MaterialTypeManager().GetMtypeForAkaProducts();
                    cmbTipoMaterial.Text = new MaterialMasterManager().GetPrimarioInfo(_primario).TIPO_MATERIAL;
                    break;
                case 2:
                    txtDescripcionL1.ReadOnly = false;
                    txtDescripcionL5.ReadOnly = false;
                    ckActivo.Enabled = true;
                    btnGuardar.Enabled = true;
                    t0012TIPOMATERIALBindingSource1.DataSource = new MaterialTypeManager().GetMtypeForAkaProducts();
                    break;
                case 3:
                    break;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletos() == false)
                return;

            var reultado = new MaterialMasterManager().UpdateAKAInfo(MapAKAData());
            if (reultado)
            {
                MessageBox.Show(@"Se ha actualizado correctamente la informacion del material de venta",
                    @"Actualizacion de AKA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"No hay informacion para actualizar", @"Actualizacion de AKA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private T0011_MATERIALES_AKA MapAKAData()
        {
            var x = new T0011_MATERIALES_AKA
            {
                CODVENTA = txtCodigoVenta.Text,
                MAT_DESC2 = txtDescripcionL1.Text,
                MAT_DESC_L5 = txtDescripcionL5.Text,
                TIPO_MATERIAL = cmbTipoMaterial.Text,
                ACTIVO = ckActivo.Checked,
                PRIMARIO = txtCodigoPrimario.Text
            };

            return x;
        }
        private bool ValidaDatosCompletos()
        {
            if (string.IsNullOrEmpty(txtCodigoVenta.Text))
            {
                MessageBox.Show(@"Debe Completar el CODIGO DE VENTA (AKA)", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtDescripcionL1.Text))
            {
                MessageBox.Show(@"Debe Completar la descripcion del material para la venta (Remito y Factura)", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtDescripcionL5.Text))
            {
                MessageBox.Show(@"Debe Completar la descripcion del material/venta L5 (Disp.)", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(cmbTipoMaterial.Text))
            {
                MessageBox.Show(@"Debe Completar el tipo de material", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private void txtCodigoVenta_Leave(object sender, EventArgs e)
        {
            var aka = (TextBox)sender;
            if (new MaterialMasterManager().CheckIfMaterialExistInT0011(aka.Text))
            {
                MessageBox.Show(@"El Codigo de Venta ya existe", @"Material Duplicado", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                aka.Text = null;
            }
            else
            {
                aka.Text = aka.Text.ToUpper();
                _aka = aka.Text;
            }
        }
        private void txtDescripcionL1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcionL1.Text) == false)
            {
                txtDescripcionL5.Text = @"Disp." + txtDescripcionL1.Text;
            }
        }

        private void ckActivo_CheckedChanged(object sender, EventArgs e)
        {
            ckActivo.BackColor = ckActivo.Checked ? Color.GreenYellow : Color.Crimson;
        }
    }
}
