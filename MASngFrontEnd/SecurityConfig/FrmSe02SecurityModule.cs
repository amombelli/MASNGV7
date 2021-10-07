using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Security;
using TecserSQL.Data.EDMX.TSSecurity;

namespace MASngFE.SecurityConfig
{
    public partial class FrmSe02SecurityModule : Form
    {
        public FrmSe02SecurityModule(int modo = 0)
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------
        private string _role = null;
        private string _user = null;
        private List<TSecRoleAssignment> _roleAssign = new List<TSecRoleAssignment>();
        //------------------------------------------------------------------------------
        private void UsuarioSeleccion()
        {
            this.dgvAsignacion.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacion_CellEnter);
            this.dgvSinAsignar.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinAsignar_CellEnter);
            roleAssignBs.DataSource = new TsSecurityMng().GetListRoleAssignment(_user, _role, false);
            roleSinAssignBs.DataSource = new TsSecurityMng().GetListRoleSinAsignacion(_user);
            dgvAsignacion.ClearSelection();
            dgvSinAsignar.ClearSelection();
            txtUserSelected.Text = _user;
            txtRoleSelected.Text = _role;
            this.dgvAsignacion.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacion_CellEnter);
            this.dgvSinAsignar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinAsignar_CellEnter);

            //btnEditUser.Enabled = _user != null;

        }
        private void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            _role = cmbRole.SelectedIndex == -1 ? null : cmbRole.SelectedValue.ToString();
            _user = cmbUsuario.SelectedIndex == -1 ? null : cmbUsuario.SelectedValue.ToString();
            UsuarioSeleccion();
        }
        private void cmbUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (cmbUsuario.SelectedValue == null)
            {
                if (string.IsNullOrEmpty(cmbUsuario.Text))
                {
                    _user = null;
                    //e.Cancel = false;
                }
                else
                {
                    if (cmbUsuario.Text != string.Empty)
                        e.Cancel = true;
                }
            }
            UsuarioSeleccion();

        }
        private void RoleSeleccion()
        {
            this.dgvAsignacion.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacion_CellEnter);
            this.dgvSinAsignar.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinAsignar_CellEnter);
            roleAssignBs.DataSource = new TsSecurityMng().GetListRoleAssignment(_user, _role, false);
            roleSinAssignBs.DataSource = new TsSecurityMng().GetListRoleSinAsignacion(_user);
            dgvAsignacion.ClearSelection();
            dgvSinAsignar.ClearSelection();
            txtUserSelected.Text = _user;
            txtRoleSelected.Text = _role;

            UsuariosSinElRoleAsignadoBs.DataSource = new TsSecurityMng().GetListOfUsersWithoutARole(_role);
            this.dgvAsignacion.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacion_CellEnter);
            this.dgvSinAsignar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinAsignar_CellEnter);

            if (ckTcode.Checked)
            {
                btnEditTcode.Enabled = _role != null;
                btnEditRole.Enabled = false;
            }
            else
            {
                btnEditRole.Enabled = _role != null;
                btnEditTcode.Enabled = false;
            }
        }
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            _role = cmbRole.SelectedIndex == -1 ? null : cmbRole.SelectedValue.ToString();
            _user = cmbUsuario.SelectedIndex == -1 ? null : cmbUsuario.SelectedValue.ToString();
            var dataRole = (TSecRole)cmbRole.SelectedItem;
            if (dataRole != null)
            {
                ckTcode.Checked = dataRole.IsTcode;
                RoleSeleccion();
            }
        }
        private void cmbRole_Validating(object sender, CancelEventArgs e)
        {
            if (cmbRole.SelectedValue == null)
            {
                if (string.IsNullOrEmpty(cmbRole.Text))
                {
                    _role = null;
                    RoleSeleccion();
                    e.Cancel = false;
                }
                else
                {
                    if (cmbRole.Text != string.Empty)
                        e.Cancel = true;
                }
            }
        }
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            var resp = new TsSecurityMng().SetAccessRole(_user, _role);
            if (resp == false)
            {
                MessageBox.Show(
                    $"Ha ocurrido un error al intentar asignar el siguiente usuario {_user} con el siguiente role {_role}",
                    @"Asignacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(
                    $"Se ha asignado correctamente el siguiente usuario {_user} con el siguiente role {_role}",
                    @"Asignacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            var resp = new TsSecurityMng().UnSetAccessRole(_user, _role);
            if (resp == false)
            {
                MessageBox.Show(
                    $"Ha ocurrido un error al intentar des-asignar el siguiente usuario {_user} con el siguiente role {_role}",
                    @"Asignacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(
                    $"Se ha des-asignado correctamente el siguiente usuario {_user} con el siguiente role {_role}",
                    @"Asignacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void FrmSecurityModule_Load(object sender, EventArgs e)
        {
            _role = null;
            _user = null;
            _roleAssign = new TsSecurityMng().GetListRoleAssignment(null, null, false).ToList();
            userBs.DataSource = new TsSecurityMng().GetListUser(true);
            roleBs.DataSource = new TsSecurityMng().GetListRole(true);
            roleAssignBs.DataSource = _roleAssign.ToList();
            cmbUsuario.SelectedIndex = -1;
            cmbRole.SelectedIndex = -1;
        }
        private void dgvAsignacion_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string nombreColumna = null;

            if (e.RowIndex < 0)
            {
                return;
            }
            nombreColumna = idRoleConRoleDgv.Name;
            var nombreRole = dgvAsignacion[dgvAsignacion.Columns[nombreColumna].Index, e.RowIndex].Value;

            if (nombreRole == null)
                return;

            _user = dgvAsignacion[dgvAsignacion.Columns[idUserConRoleDgv.Name].Index, e.RowIndex].Value.ToString();
            _role = nombreRole.ToString();
            txtRoleSelected.Text = _role;
            txtUserSelected.Text = _user;
            dgvSinAsignar.ClearSelection();
            dgvUsuariosSinElRoleAsignado.ClearSelection();


        }
        private void dgvSinAsignar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            string nombreColumna = null;

            if (e.RowIndex < 0)
            {
                return;
            }
            nombreColumna = roleSinasignarDgv.Name;
            var nombreRole = dgvSinAsignar[dgvSinAsignar.Columns[nombreColumna].Index, e.RowIndex].Value;

            if (nombreRole == null)
                return;

            _user = cmbUsuario.SelectedValue.ToString();
            _role = nombreRole.ToString();
            txtRoleSelected.Text = _role;
            txtUserSelected.Text = _user;

            dgvAsignacion.ClearSelection();
            dgvUsuariosSinElRoleAsignado.ClearSelection();
        }
        private void dgvAsignacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = senderGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                switch (cellValue)
                {
                    case "Eliminar":

                        var resp = new TsSecurityMng().UnSetAccessRole(_user, _role);
                        if (resp == false)
                        {
                            MessageBox.Show(
                                $"Ha ocurrido un error al intentar des-asignar el siguiente usuario {_user} con el siguiente role {_role}",
                                @"Asignacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(
                                $"Se ha des-asignado correctamente el siguiente usuario {_user} con el siguiente role {_role}",
                                @"Asignacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
        private void dgvSinAsignar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = senderGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                switch (cellValue)
                {
                    case "Asignar":
                        var resp = new TsSecurityMng().SetAccessRole(_user, _role);
                        if (resp == false)
                        {
                            MessageBox.Show(
                                $"Ha ocurrido un error al intentar asignar el siguiente usuario {_user} con el siguiente role {_role}",
                                @"Asignacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(
                                $"Se ha asignado correctamente el siguiente usuario {_user} con el siguiente role {_role}",
                                @"Asignacion de Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        break;


                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }


        private void btnNewRole_Click(object sender, EventArgs e)
        {
            using (var f1 = new FrmSec04RoleManagement())
            {
                var dr = f1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //Refrescar Datos
                }
            }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar el Role a Modificar", @"Role No Seleccionado", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            using (var f1 = new FrmSec04RoleManagement(cmbRole.SelectedValue.ToString()))
            {
                var dr = f1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //Refrescar Datos
                }
            }
        }

        private void btnNewTCode_Click(object sender, EventArgs e)
        {
            using (var f1 = new FrmSec03TcodeManagement())
            {
                var dr = f1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //Refrescar Datos
                }
            }
        }

        private void btnEditTcode_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar el Role -> TCODE a Modificar", @"Role No Seleccionado", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!ckTcode.Checked)
            {
                MessageBox.Show(@"El Role Seleccionado no es un TCODE", @"TCode No Seleccionado", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            using (var f1 = new FrmSec03TcodeManagement(cmbRole.SelectedValue.ToString()))
            {
                var dr = f1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //Refrescar Datos
                }
            }
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
