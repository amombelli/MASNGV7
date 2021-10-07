using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP12DetalleIngresoTemporal : Form
    {
        public FrmPP12DetalleIngresoTemporal(int numeroOF)
        {
            _numeroOF = numeroOF;
            InitializeComponent();
            txtNumeroOF.ReadOnly = true;
        }

        //-----------------------------------------------------------------------------
        private readonly int _numeroOF;

        //-----------------------------------------------------------------------------



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPP12DetalleIngresoTemporal_Load(object sender, EventArgs e)
        {
            dgvIngresoTemporal.DataSource =
                new PlanProduccionManager().GetListMovimientosIngresoProduccion(_numeroOF).ToList();
            CargaOFData();
            cmbOperario.DataSource = new HumanResourcesManager().GetListAllActiveOperario().ToList();
            cmbRecurso.DataSource = new RecursosProduccion().GetListRecursosProduccion().ToList();
            cmbOperario.SelectedIndex = -1;
            cmbRecurso.SelectedIndex = -1;

        }

        private void CargaOFData()
        {
            var dataOf = PlanProduccionListManager.GetOFData(_numeroOF);
            txtNumeroOF.Text = _numeroOF.ToString();
            txtMaterialFabricado.Text = dataOf.MATERIAL;
            txtEstadoOF.Text = dataOf.STATUS;
            txtCantidadKgIngresados.Text = dataOf.KG_Fabricados.ToString("N2");
        }

        private void btnCancelarDescuentoMP_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcionalidad en Proceso de desarrollo", @"Intente nuevamente mas tarde",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnActualizarDatosIngresos_Click(object sender, EventArgs e)
        {
            if (cmbRecurso.SelectedValue == null)
            {
                MessageBox.Show(@"Debe proveer un Recursos Valido para actualizar los datos", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbOperario.SelectedValue == null)
            {
                MessageBox.Show(@"Debe proveer un Operario Valido para actualizar los datos", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var msg = MessageBox.Show(@"Confirma la Actualizacion de los datos Temporales?", @"Modificacion de Datos",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
                return;

            new MmLog().UpdateIngresoTemporal(Convert.ToInt32(txtIdMovimiento.Text), dtpFechaMovimiento.Value, Convert.ToInt32(cmbRecurso.SelectedValue), cmbOperario.SelectedValue.ToString(), txtComentario.Text);

            MessageBox.Show(@"Los Datos se han Actualizado Correctamente", @"Modificacion de Datos",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvIngresoTemporal.DataSource =
                new PlanProduccionManager().GetListMovimientosIngresoProduccion(_numeroOF).ToList();
        }

        private void dgvIngresoTemporal_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
#pragma warning disable CS0219 // The variable 'nombreColumna' is assigned but its value is never used
            string nombreColumna = null;
#pragma warning restore CS0219 // The variable 'nombreColumna' is assigned but its value is never used

            if (e.RowIndex < 0)
            {
                return;
            }
            var idMovmiento =
                Convert.ToInt32(dgv[dgv.Columns[iDMOVIMIENTODataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value);
            txtIdMovimiento.Text = idMovmiento.ToString();
            txtNumeroLote.Text =
                dgv[dgv.Columns[bATCHDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();
            txtKgIngresados.Text =
                dgv[dgv.Columns[cANTIDADDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();
            txtComentario.Text =
                dgv[dgv.Columns[cOMENTARIODataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();
            txtUbicacion.Text = dgv[dgv.Columns[sLOCDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();
            txtEstadoLote.Text =
                dgv[dgv.Columns[bATCHSTDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();

            cmbRecurso.SelectedValue =
                dgv[dgv.Columns[rECURSODataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value;

            var data42 = MmLog.GetT0042Line(idMovmiento);
            if (data42 != null)
            {
                cmbOperario.SelectedValue = data42.OPERADOR;
            }
            else
            {
                cmbOperario.SelectedIndex = -1;
            }
        }
    }
}



