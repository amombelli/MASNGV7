using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.Security;
using TSecRole = TecserSQL.Data.EDMX.TSSecurity.TSecRole;

namespace MASngFE.SecurityConfig
{
    public partial class FrmSec04RoleManagement : Form
    {
        public FrmSec04RoleManagement(string rolename = null)
        {
            _rolename = rolename;
            _modo = _rolename == null ? 1 : 2;
            InitializeComponent();
        }

        //------------------------------------------------------------------------
        private readonly string _rolename;
        private readonly int _modo;
        //------------------------------------------------------------------------

        private void FrmNewRole_Load(object sender, EventArgs e)
        {
            if (_modo == 1)
            {
                txtRole.ReadOnly = false;
            }
            else
            {
                txtRole.ReadOnly = true;
                LoadRoleData();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletos())
            {
                new TsSecurityMng().GrabaRoleData(MapRoleFromScreen());
            }
        }

        private void txtRole_Validating(object sender, CancelEventArgs e)
        {
            //verificar si el role ya existe
            var data = new TsSecurityMng().GetRoleData(txtRole.Text);
            if (data == null)
            {
                txtRole.BackColor = Color.GreenYellow;
            }
            else
            {
                txtRole.BackColor = Color.OrangeRed;
                if (_modo == 1)
                {
                    toolTip1.ToolTipTitle = "El Role Seleccionado ya Existe";
                    toolTip1.Show("El Role Seleccionado ya Existe", txtRole,
                        txtRole.Location, 5000);
                    e.Cancel = true;
                }
            }
        }

        private bool ValidaDatosCompletos()
        {
            if (string.IsNullOrEmpty(txtRole.Text))
            {
                toolTip1.ToolTipTitle = "Datos Incompletos";
                toolTip1.Show("Debe Completar el Nombre del Role", txtRole,
                    txtRole.Location, 5000);
                return false;
            }

            if (string.IsNullOrEmpty(txtRoleDescription.Text))
            {
                toolTip1.ToolTipTitle = "Datos Incompletos";
                toolTip1.Show("Debe Completar la Descripcion del Role", txtRoleDescription,
                    txtRoleDescription.Location, 5000);
                return false;
            }

            if (string.IsNullOrEmpty(txtModulo.Text))
            {
                toolTip1.ToolTipTitle = "Datos Incompletos";
                toolTip1.Show("Debe Completar el nombre del Modulo", txtModulo,
                    txtModulo.Location, 5000);
                return false;
            }
            return true;
        }

        private void LoadRoleData()
        {
            var data = new TsSecurityMng().GetRoleData(_rolename);
            if (data == null)
                return;

            txtRole.Text = data.RoleName;
            txtRoleDescription.Text = data.RoleDescription;
            txtModulo.Text = data.Modulo;
            ckActivo.Checked = data.Activo;
        }


        private TSecRole MapRoleFromScreen()
        {
            var tabla = new TSecRole()
            {
                Activo = ckActivo.Checked,
                IsTcode = false,
                Modulo = txtModulo.Text,
                RoleDescription = txtRoleDescription.Text,
                RoleName = txtRole.Text,
                isFunction = false
            };
            return tabla;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletos())
            {
                new TsSecurityMng().GrabaRoleData(MapRoleFromScreen());
            }
        }
    }
}
