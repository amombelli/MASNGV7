using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.HR;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHR08PagoAdelantos : Form
    {
        public FrmHR08PagoAdelantos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idX = Convert.ToInt32(datagridview[idAdelantoDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "VER":
                    using (var f0 = new FrmHR09DetalleRegistroAdelanto(idX))
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

        private void FrmHR08PagoAdelantos_Load(object sender, EventArgs e)
        {
            t0525SueldoAdelantoBindingSource.DataSource = new ManejoAdelantos().GetListado();
        }
    }
}
