using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm15AsignacionMaterialIp : Form
    {
        public FrmQm15AsignacionMaterialIp(string iPlan)
        {
            _iPlan = iPlan;
            InitializeComponent();
        }

        private readonly string _iPlan;


        private void FrmQm15AsignacionMaterialIP_Load(object sender, EventArgs e)
        {
            txtIPName.Text = _iPlan;
            var qm = new QmMasterIplan();
            txtIplanDescription.Text = qm.GetPlanHeader(_iPlan).DESCRIPCION;
            RefrescaDgv();
        }

        private void RefrescaDgv()
        {
            List<string> materiales = new QmMasterIplan().GetMaterialesAsociadosPlan(_iPlan);
            dgvListaMaterialesPlan.DataSource = materiales.Select(s => new { value = s }).ToList();
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAddMaterial_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmQm16MaterialesSinAsignacionPlan(_iPlan))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    RefrescaDgv();
                }
            }
        }

        //Boton Eliminar Material
        private void DgvListaMaterialesPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var material = datagridview[1, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "Eliminar":
                    new QmMasterIplan().EliminaMaterialPlan(_iPlan, material);
                    RefrescaDgv();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
    }
}
