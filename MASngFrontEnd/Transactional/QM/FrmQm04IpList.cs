using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm04IpList : Form
    {
        public FrmQm04IpList()
        {
            InitializeComponent();
        }

        private void BtnSalirOP_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void FrmQMAnalisis_Load(object sender, EventArgs e)
        {
            t0810CQHBindingSource.DataSource = new QmManageList().GetListQm();
            //dgvAnalisis.DataSource = t0810CQHBindingSource.DataSource;
        }

        private void DgvAnalisis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idqm = Convert.ToInt32(datagridview[iDIDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "Detalle":
                    using (var f0 = new FrmQm05DetalleAnalisisCalidad(idqm))
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

        private void BtnPlanInspeccionMaster_Click(object sender, EventArgs e)
        {
            var f = new FrmQm12ListaMasterInspPlan();
            f.Show();
        }

        private void BtnCrearMetodo_Click(object sender, EventArgs e)
        {
            using (var f = new FrmQm02NuevoMetodoInspeccion())
            {
                f.ShowDialog();
            }
        }

        private void BtnEdicionMetodo_Click(object sender, EventArgs e)
        {
            using (var f = new FrmQm02NuevoMetodoInspeccion("COL", 2))
            {
                f.ShowDialog();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var f = new FrmQm01MetodoInspeccionList();
            f.Show();
        }

        private void BtnAddInspeccionManual_Click(object sender, EventArgs e)
        {

        }
    }
}
