using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.MM.Requisicin
{
    public partial class FrmMM54RequisicionList : Form
    {
        private readonly int _mode;

        public FrmMM54RequisicionList(int mode = 3)
        {
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("RC3", "RC3"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios", @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            _mode = mode;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMM54RequisicionList_Load(object sender, EventArgs e)
        {
            rcDataStructureBindingSource.DataSource = new RcManagement().GetRcCompleteList()
                .OrderByDescending(c => c.IdRc).ToList();
        }

        private void dgvListadoRc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idRc = Convert.ToInt32(datagridview[__idRC.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "VER":
                    using (var f0 = new FrmMM55RequisicionMain(idRc))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);

                        }
                    }
                    rcDataStructureBindingSource.DataSource = new RcManagement().GetRcCompleteList()
                        .OrderByDescending(c => c.IdRc).ToList();

                    break;


                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
