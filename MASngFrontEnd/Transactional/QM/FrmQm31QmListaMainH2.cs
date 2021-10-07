using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm31QmListaMainH2 : Form
    {
        public FrmQm31QmListaMainH2(int idReg)
        {
            _idReg = idReg;
            InitializeComponent();
        }
        //------------------------------------------------------------------------
        private readonly int _idReg;
        private int _counterSeleccionado;
        //------------------------------------------------------------------------
        private void FrmQm31QmListaMainH2_Load(object sender, EventArgs e)
        {
            txtIR.Text = _idReg.ToString();
            t0806QMIRecordH2BindingSource.DataSource = new QmRegistroInspeccionH1H2().GetListadoH2(_idReg);
            var data = new QmRegistroInspeccionH1H2().GetRegistroH1(_idReg);
            txtIplan.Text = data.IdPlan;
            txtPlanDescription.Text = new QmMasterIplan().GetPlanHeader(data.IdPlan).DESCRIPCION;
            txtMaterial.Text = data.Material;
            txtLote.Text = data.Lote;
            txtKgInspeccion.Text = data.KGTotalBatch.ToString("N2");
            txtDocNumber.Text = data.DocNumber;
            txtDocTipo.Text = data.DocID;
            txtOrigen.Text = data.Origen;

        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var counter = Convert.ToInt32(datagridview[idCounterDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "View":
                    using (var f0 = new FrmQm32DetallePlanInspeccion(_idReg, counter))
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
        private void BtnCambiarLote_Click(object sender, EventArgs e)
        {

        }
        private void BtnSplitRegistro_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmQm33SplitRegistroInspeccion(_idReg, _counterSeleccionado))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //LoadData();
                }
                else
                {
                    MessageBox.Show(@"Se ha cancelado el SPLIT del Registro de Inspeccion", @"Accion Cancelada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                t0806QMIRecordH2BindingSource.DataSource = new QmRegistroInspeccionH1H2().GetListadoH2(_idReg);
            }
        }
        private void DgvLista_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            _counterSeleccionado = Convert.ToInt32(dgvLista[idCounterDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
        }
    }
}
