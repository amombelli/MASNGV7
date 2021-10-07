using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm06AddMetodoToPlan : Form
    {
        public FrmQm06AddMetodoToPlan(int registroInspeccion, int counterH2)
        {
            _registroInspeccion = registroInspeccion;
            _counterH2 = counterH2;
            InitializeComponent();
        }

        //---------------------------------------------------
        private readonly int _registroInspeccion;
        private readonly int _counterH2;
        //---------------------------------------------------


        private void FrmQm06AddMetodoToPlan_Load(object sender, EventArgs e)
        {
            txtIP.Text = _registroInspeccion.ToString();
            var dataPlan = new QmManageList().GetQmHeader(_registroInspeccion);
            txtPlanName.Text = dataPlan.PlanName;
            t0800CQMETODOSBindingSource.DataSource = new QmManageList().GetMetodosInspAvailableToAddToInspection(_registroInspeccion);
        }

        private void DgvListaMetodo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var metodo = datagridview[IdMetodoDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "Add":
                    var resp = MessageBox.Show($@"Confima el agregado del metodo {metodo} a la Inspeccion #{_registroInspeccion}? ",
                        @"Metodo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.No)
                        return;
                    new QmRegistroInspeccion().AddMetodoToInspectionRecord(_registroInspeccion, _counterH2, metodo, true);
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
    }
}
