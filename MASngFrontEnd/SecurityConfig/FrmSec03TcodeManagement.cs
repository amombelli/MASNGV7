using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using TecserSQL.Data.EDMX.TSSecurity;

namespace MASngFE.SecurityConfig
{
    public partial class FrmSec03TcodeManagement : Form
    {
        public FrmSec03TcodeManagement(string tcode = null, bool isTcode = true)
        {
            _tcode = tcode;
            _isTcode = isTcode;
            _modo = _tcode == null ? 1 : 2;
            InitializeComponent();
        }

        //------------------------------------------------------------------------
        private readonly string _tcode;
        private readonly bool _isTcode;
        private readonly int _modo;
        private ValidacionManager vx;
        //------------------------------------------------------------------------

        private void FrmNewTcode_Load(object sender, EventArgs e)
        {
            if (_modo == 1)
            {
                txtTcode.ReadOnly = false;
                if (_isTcode)
                {
                    ckIsTcode.Checked = true;
                    txtType.Text = @"FORM";
                }
                else
                {
                    ckIsTcode.Checked = false;
                    txtType.Text = @"FUNCTION";
                }
            }
            else
            {
                txtTcode.ReadOnly = true;
                LoadTcodeData();
            }
            vx = new ValidacionManager(this, ep, toolTip1);
        }
        private void LoadTcodeData()
        {
            var data = new TsSecurityMng().LoadTransactionData(_tcode);
            if (data == null)
                return;

            txtTcode.Text = _tcode;
            txtTcodeDescription.Text = data.Description;
            txtModulo.Text = data.Module;
            txtType.Text = data.Type;
            txtFunctionToCall.Text = data.FunctionToCall;
            txtNombreFormulario.Text = data.FormToCall;
            txtArg1.Text = data.Arg1;
            txtArg2.Text = data.Arg2;
            txtArg3.Text = data.Arg3;
            ctlCantidadParametros.Text = data.NumberOfParameters.ToString();
            txtNamespace.Text = data.Namespace;
            txtModo.Text = data.Modo.ToString();
            ckPermisos.Checked = data.CheckPermission;
            ckVisible.Checked = data.Visible;
            if (ckIsTcode.Checked)
            {
                txtType.Text = @"FORM";
                txtFunctionToCall.Enabled = false;
                txtNombreFormulario.Enabled = true;
            }
            else
            {
                txtType.Text = @"FUNCTION";
                txtFunctionToCall.Enabled = true;
                txtNombreFormulario.Enabled = false;
            }
        }
        private void txtModo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private T0001_TRANSACTIONS MapForm()
        {
            var data = new T0001_TRANSACTIONS()
            {
                Type = txtType.Text,
                TCode = txtTcode.Text,
                Description = txtTcodeDescription.Text,
                Visible = ckVisible.Checked,
                CheckPermission = ckPermisos.Checked,
                Modo = Convert.ToInt32(txtModo.Text),
                FormToCall = txtNombreFormulario.Text,
                Namespace = txtNamespace.Text,
                Module = txtModulo.Text,
                FunctionToCall = txtFunctionToCall.Text,
                NumberOfParameters = (int)ctlCantidadParametros.GetValueDecimal,
                Arg1 = txtArg1.Text,
                Arg2 = txtArg2.Text,
                Arg3 = txtArg3.Text
            };
            return data;
        }
        private void ChequeaFormularioExiste()
        {
            var tipo = Type.GetType(txtNamespace.Text.Trim() + "." + txtNombreFormulario.Text.Trim());
            vx.Valida(txtNombreFormulario, tipo == null, "No se encuentra el Namespace.Formulario!");
            vx.Valida(txtNamespace, tipo == null, "No se encuentra el Namespace.Formulario!");
            txtNamespace.BackColor = vx._colorResultado;
            txtNombreFormulario.BackColor = vx._colorResultado;

        }
        private bool ValidaOkToSave()
        {
            vx.ReseteaValidacion();
            var val1 = vx.Valida(txtTcode, string.IsNullOrEmpty(txtTcode.Text), "Debe Proveer un TCode/Function Valido");
            if (val1)
            {
                if (_modo == 1)
                {
                    vx.Valida(txtTcode, new TsSecurityMng().TransaccionYaExiste(txtTcode.Text),
                        "El TCode Seleccionado Ya Existe", true);
                }
            }

            vx.Valida(txtModo, string.IsNullOrEmpty(txtModo.Text), "El Modo no puede estar vacio", true);

            if (ckIsTcode.Checked)
            {
                ChequeaFormularioExiste();
            }

            return vx.GetResultadoValidacion();
        }
        private void txtNamespace_Leave(object sender, EventArgs e)
        {
            var tipo = Type.GetType(txtNamespace.Text.Trim() + "." + txtNombreFormulario.Text.Trim());
            if (tipo == null)
            {
                txtNamespace.BackColor = Color.Orange;
                btnSave.Enabled = false;
            }
            else
            {
                txtNamespace.BackColor = Color.LimeGreen;
                btnSave.Enabled = true;
                ep.SetError(txtNamespace, "");
                ep.SetError(txtNombreFormulario, "");
            }
        }
        private void txtTcode_Validating(object sender, CancelEventArgs e)
        {
            if (_modo == 1)
            {
                vx.ReseteaValidacion();
                vx.Valida(txtTcode, new TsSecurityMng().TransaccionYaExiste(txtTcode.Text), "El TCode ya Existe", true);
                e.Cancel = !vx.GetResultadoValidacion();
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Ignore;
            return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidaOkToSave())
                return;

            var rtn = new TsSecurityMng().GrabaTcode(MapForm());
            if (rtn == 1)
            {
                MessageBox.Show(@"Se ha guardado correctamente la transaccion", @"Modificacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show(@"Ha ocurrido un error al intentar guardar los datos de la transaccion", @"Modificacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerFormsInProject_Click(object sender, EventArgs e)
        {
            var x = new FormsInProject();
            x.GetAllFormsInProject();

        }
    }
}
