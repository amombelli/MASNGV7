using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm01MetodoInspeccionList : Form
    {
        public FrmQm01MetodoInspeccionList()
        {
            InitializeComponent();
        }

        private void DgvListaMetodo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var nombreBoton = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var metodo = datagridview[IdMetodoDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            switch (nombreBoton)
            {
                case "Update":
                    using (var f0 = new FrmQm02NuevoMetodoInspeccion(metodo, 2))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            t0800CQMETODOSBindingSource.DataSource = new QmMetodoInspeccion().GetMetodosList();
                        }
                    }
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void BtnCrearMetodo_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmQm02NuevoMetodoInspeccion())
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    t0800CQMETODOSBindingSource.DataSource = new QmMetodoInspeccion().GetMetodosList();
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmQm01MetodoList_Load(object sender, EventArgs e)
        {
            t0800CQMETODOSBindingSource.DataSource = new QmMetodoInspeccion().GetMetodosList();
        }
    }
}
