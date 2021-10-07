using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm30QmListaMainH1 : Form
    {
        public FrmQm30QmListaMainH1()
        {
            InitializeComponent();
        }

        private void FrmQm30QmListaMainH1_Load(object sender, EventArgs e)
        {
            t0805QMIRecordH1BindingSource.DataSource = new QmRegistroInspeccionH1H2().GetListadoH1();
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
            var idReg = Convert.ToInt32(datagridview[idIRecDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "View":
                    using (var f0 = new FrmQm31QmListaMainH2(idReg))
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
    }
}
