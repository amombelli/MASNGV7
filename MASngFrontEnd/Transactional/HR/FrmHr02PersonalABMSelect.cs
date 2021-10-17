using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.HR;
using TecserEF.Entity;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHr02PersonalABMSelect : Form
    {
        public FrmHr02PersonalABMSelect()
        {
            InitializeComponent();
        }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var shortname = datagridview[shortnameDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "VER":
                    using (var f0 = new FrmHr03PersonalABMMain(3, shortname))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                        }
                    }

                    break;

                case "EDIT":
                    using (var f0 = new FrmHr03PersonalABMMain(2, shortname))
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
        private void FrmHR02_PersonalABMSelect_Load(object sender, EventArgs e)
        {
            AplifcaFiltro();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var f = new FrmHr03PersonalABMMain(1);
            f.Show();
        }
        private void ckActivo_CheckedChanged(object sender, EventArgs e)
        {
            AplifcaFiltro();
        }
        private void ckConLegajoRaffone_CheckedChanged(object sender, EventArgs e)
        {
            AplifcaFiltro();
        }
        private void AplifcaFiltro()
        {
            List<T0085_HHRR_PERSONAL_BASIC> l = new List<T0085_HHRR_PERSONAL_BASIC>();
            var lista1 = new HrMasterManagement().GetEmployeeListForSyJ(!ckInactivo.Checked);
            l.Clear();
            if (ckConLegajoRaffone.Checked)
            {
                l.AddRange(lista1.Where(c => !string.IsNullOrEmpty(c.LegajoRaf)));
            }

            if (ckSinLegajoRaffone.Checked)
            {
                l.AddRange(lista1.Where(c => string.IsNullOrEmpty(c.LegajoRaf)));
            }
            dgvData.DataSource = l.ToList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
