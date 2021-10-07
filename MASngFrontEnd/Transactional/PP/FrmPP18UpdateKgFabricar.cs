using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP18UpdateKgFabricar : Form
    {
        private readonly int _idOf;

        public FrmPP18UpdateKgFabricar(int idOf)
        {
            _idOf = idOf;
            InitializeComponent();
        }

        private DialogResult dx = DialogResult.Ignore;


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = dx;
            this.Close();
        }

        private void FrmPP18UpdateKgFabricar_Load(object sender, EventArgs e)
        {
            txtOF.Text = _idOf.ToString();
            var dataPf = new PlanProduccionManager().GetPFLine(_idOf);
            txtMaterialFab.Text = dataPf.MATERIAL;
            txtMaterialEtiqueta.Text = dataPf.MATETIQUETA;
            txtMotivoFabricacion.Text = dataPf.PLANPARA;
            txtClienteOriginal.Text = dataPf.CLIENTE;
            txtOVnum.Text = dataPf.OV != null ? null : dataPf.OV.ToString();

            txtKgIngresoPlan.Text = dataPf.KG_FABRICAR_O.ToString("N2");
            txtKgRevisado.SetValue = dataPf.KG_FABRICAR;
            txtObservacionPlan.Text = dataPf.ObsPlaneacion;

            T0070Bs.DataSource = new PlanProduccionListManager().GetMiniListMaterialToMfg(dataPf.MATERIAL, _idOf);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtKgRevisado.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"El Valor de KG a Fabricar Revisado no puede ser 0", @"Error en Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            new PlanProduccionManager().SetKgFabricarNew(_idOf, txtKgRevisado.GetValueDecimal, txtObservacionPlan.Text);
            MessageBox.Show(@"Se ha actualizado correctamente los KG a Fabricar", @"Actualizacion Exitosa",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            dx = DialogResult.OK;
        }

        private void dgvPf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var of = Convert.ToInt32(datagridview[iDPLANDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            decimal kgSelect = Convert.ToDecimal(datagridview[kGFABRICARDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            var statusUpdated = new PlanProduccionStatusManager().GetStatusOF(of);

            switch (cellValue)
            {
                case "FUSION":

                    if (statusUpdated == PlanProduccionStatusManager.StatusOf.Cancelada)
                    {
                        MessageBox.Show(@"Esta Orden ya se encuentra cancelada", @"Funcionalidad No Permitida para una OF Cancelada",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        return;
                    }

                    if (statusUpdated == PlanProduccionStatusManager.StatusOf.Proceso)
                    {
                        MessageBox.Show(@"No se puede Cancelar esta OF ya que se encuentra en proceso",
                            @"Funcionalidad No Permitida para una OF en Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (statusUpdated == PlanProduccionStatusManager.StatusOf.Planeado)
                    {
                        MessageBox.Show(@"ATENCION: Esta OF esta planeada y podria significar que la orden ya esta en maquina. Puede realizar esta opcion pero debe asegurarse de que la Orden no entre en produccion",
                            @"Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    var msg = MessageBox.Show($@"Desea cancelar la OF# {of} y Sumar los KG a la orden {_idOf}?",
                        @"Fusion de Ordenes de Fabricacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    var kg = txtKgRevisado.GetValueDecimal + kgSelect;
                    txtKgRevisado.SetValue = kg;

                    PlanProduccionStatusManager.SetStatusCancel(of, "Unificado en OF·" + _idOf);
                    new PlanProduccionManager().SetKgFabricarNew(_idOf, txtKgRevisado.GetValueDecimal, txtObservacionPlan.Text);

                    MessageBox.Show(@"Se ha actualizado correctamente los KG a Fabricar", @"Actualizacion Exitosa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    T0070Bs.DataSource = new PlanProduccionListManager().GetMiniListMaterialToMfg(txtMaterialFab.Text, _idOf);
                    dx = DialogResult.OK;
                    break;

                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
    }
}
