using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm16MaterialesSinAsignacionPlan : Form
    {
        public FrmQm16MaterialesSinAsignacionPlan(string iPlan)
        {
            _iPlan = iPlan;
            InitializeComponent();
        }

        private readonly string _iPlan;

        private void FrmQm16MaterialesSinAsignacionPlan_Load(object sender, EventArgs e)
        {
            txtIPName.Text = _iPlan;
            txtIplanDescription.Text = new QmMasterIplan().GetPlanHeader(_iPlan).DESCRIPCION;
            RefrescaDgv();
        }

        public void RefrescaDgv()
        {
            List<string> materiales = new QmMasterIplan().GetMaterialesNoAsociadosPlan();
            dgvMaterialesSinPlan.DataSource = materiales.Select(s => new { value = s }).ToList();
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }


        private void DgvMaterialesSinPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var material = datagridview[1, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "Agregar":
                    new QmMasterIplan().AsociaMaterialAPlan(_iPlan, material);
                    RefrescaDgv();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
    }
}
