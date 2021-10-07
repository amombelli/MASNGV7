using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.HR;
using TSControls;

namespace MASngFE.SecurityConfig
{
    public partial class FrmSS11AddComboFunction : Form
    {
        public FrmSS11AddComboFunction()
        {
            InitializeComponent();
        }

        private void FrmSS11AddComboFunction_Load(object sender, EventArgs e)
        {
            dgv1.DataSource = HRComboManager.GetListaFuncionesCombo().ToList();
            cmbEmpleado.Items.AddRange(HrDisponibilidadYPermisos.ListadoCompletoEmpleados().ToArray());
            dgv1.ClearSelection();
        }

        private void txtNombreFuncion_Validated(object sender, EventArgs e)
        {

        }

        private void txtNombreFuncion_Validating(object sender, CancelEventArgs e)
        {
            var t = (TextBox) sender;
            if (string.IsNullOrEmpty(t.Text))
            {
                cicon1.Set = CIconos.Azul;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                return;
            }

            if (HRComboManager.ExisteFuncion(t.Text))
            {
                cicon1.Set = CIconos.Rojo;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                return;
            }
            cicon1.Set = CIconos.Verde;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreFuncion.Text))
            {
                MessageBox.Show(@"Debe proveer un Nombre para la funcion", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show(@"Debe proveer una descripcion para la funcion", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            new HRComboManager().Addfuncion(txtNombreFuncion.Text.ToUpper(), txtDescripcion.Text);
            dgv1.DataSource = HRComboManager.GetListaFuncionesCombo().ToList();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView) sender;
            if (e.RowIndex > 0)
            {
                txtNombreFuncion.Text = dgv[__code.Name, e.RowIndex].Value.ToString();
                txtDescripcion.Text = dgv[__Descripcion.Name, e.RowIndex].Value.ToString();
                dgv2.DataSource = HRComboManager.GetListaAsignacionesPorFuncion(txtNombreFuncion.Text).ToList();
            }
        }





        private void btnAddEmpleado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreFuncion.Text))
            {
                MessageBox.Show(@"Debe Seleccionar una funcion para Asignar al Empleado", @"Datos Invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (string.IsNullOrEmpty(cmbEmpleado.SelectedItem.ToString()))
            {
                MessageBox.Show(@"Debe Seleccionar un Empleado para Asignar a la Funcion", @"Datos Invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var r = HRComboManager.ExisteAsignacion(txtNombreFuncion.Text, cmbEmpleado.SelectedItem.ToString());
            if (r)
            {
                MessageBox.Show(@"La Asignacion de Este Empleado a Esta funciona Ya Existe", @"Datos Invalidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cicon2.Set = CIconos.Rojo;
                return;
            }
            else
            {
                cicon2.Set = CIconos.Verde;
            }
            new HRComboManager().AddAsignacion(cmbEmpleado.SelectedItem.ToString().ToUpper(),txtNombreFuncion.Text);
            dgv2.DataSource = HRComboManager.GetListaAsignacionesPorFuncion(txtNombreFuncion.Text).ToList();


        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex == -1)
            {
                cicon2.Set = CIconos.Azul;
                return;
            }

            if (string.IsNullOrEmpty(txtNombreFuncion.Text))
            {
                cicon2.Set = CIconos.Azul;
                return;
            }

            var r =HRComboManager.ExisteAsignacion(txtNombreFuncion.Text, cmbEmpleado.SelectedItem.ToString());
            if (r)
            {
                cicon2.Set = CIconos.Rojo;
            }
            else
            {
                cicon2.Set = CIconos.Verde;
            }
        }



        private void cmbEmpleado_Validating(object sender, CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedItem == null && !string.IsNullOrEmpty(combo.Text))
                e.Cancel = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView) sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var nombreBoton = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            switch (nombreBoton)
            {
                case "DEL":
                    var fx = dgv[__2Funcion.Name, e.RowIndex].Value.ToString();
                    var shortname = dgv[__2Shortname.Name, e.RowIndex].Value.ToString();
                    HRComboManager.DeleteAsignacion(shortname,fx);
                    dgv2.DataSource = HRComboManager.GetListaAsignacionesPorFuncion(txtNombreFuncion.Text).ToList();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
    }
}
