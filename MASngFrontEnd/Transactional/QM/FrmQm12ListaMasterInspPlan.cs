using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm12ListaMasterInspPlan : Form
    {
        public FrmQm12ListaMasterInspPlan()
        {
            InitializeComponent();
        }

        private void FrmQM02ListaIP_Load(object sender, EventArgs e)
        {
            t0801CQIPBindingSource.DataSource = new QmMasterData().GetPlanHeaderList();
        }

        private void DgvIP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            string plan = datagridview[iDPLANDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "Detalle":
                    using (var f0 = new FrmQm13MasterIPlanDetalle(plan))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                            t0801CQIPBindingSource.DataSource = new QmMasterData().GetPlanHeaderList();

                        }
                    }
                    t0801CQIPBindingSource.DataSource = new QmMasterData().GetPlanHeaderList();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSavePlan_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show(@"Desea crear un nuevo Plan de Inspeccion Maestro?", @"Creacion de nuevo MIP",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            using (var f = new FrmQm13MasterIPlanDetalle(1))
            {
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    t0801CQIPBindingSource.DataSource = new QmMasterData().GetPlanHeaderList();
                }
            }
        }
    }
}
