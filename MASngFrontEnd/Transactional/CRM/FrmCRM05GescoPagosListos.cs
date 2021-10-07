using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.CRM;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmCRM05GescoPagosListos : Form
    {
        public FrmCRM05GescoPagosListos()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCRM05GescoDetallePagoListo_Load(object sender, EventArgs e)
        {
            dsGescoPagoListoBindingSource.DataSource = new GescoPagoListo().GetAllData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idRecord = Convert.ToInt32(datagridview[idRecordDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "ASSIGN":
                    using (var f0 = new FrmCRM07GescoDetallePagoListo(idRecord))
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

        private void btnReportePL_Click(object sender, EventArgs e)
        {

        }
    }
}
