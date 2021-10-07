using System;
using System.Windows.Forms;
using Tecser.Business.DataFix;
using Tecser.Business.Security;
using Tecser.Business.Transactional.CO.ContaFromDocuments;
using Tecser.Business.Transactional.FI;

namespace MASngFE.FIX
{
    public partial class FrmFixFacturaConta : Form
    {
        public FrmFixFacturaConta()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchMissing201_Click(object sender, EventArgs e)
        {


            dgvFacturasToFix.DataSource = new FixContabilizacionIssues().GetDataSourceFacturasSinIdCtaCte(DateTime.Today.AddDays(-90));
        }

        private void FrmFixFacturaConta_Load(object sender, EventArgs e)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("BTNFIX", "FIXCONTA"))
            {
                MessageBox.Show(@"Usuario no habilitado para ejecutar estra transaccion", @"Chequeo de Credenciales",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            t0400FACTURAHBindingSource.DataSource =
                new FixContabilizacionIssues().GetDataSourceFacturasSinIdCtaCte(DateTime.Today.AddDays(-90));
            dgvFacturasIssue.DataSource = t0400FACTURAHBindingSource;
            dgvFacturasToFix.DataSource = null;
            new FixIdCtaCteT400().AddCtaCteIdInT0400();
        }

        private void dgvFacturasToFix_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 

        }

        private void dgvFacturasToFix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvFacturasToFix[e.ColumnIndex, e.RowIndex].Value.ToString();

                switch (cellValue)
                {
                    case "FIX":
                        var idFactura = dgvFacturasToFix[dgvFacturasToFix.Columns["dgvIdFactura"].Index, e.RowIndex].Value.ToString();
                        var x0 = new ContaCustomerFromInvoice("FFIX", Convert.ToInt32(idFactura));
                        var data = x0.ManageContabilizacionCompleta();
                        new FixIdCtaCteT400().SetStatusFactura(data.IdFacturaX, DocumentFIStatusManager.StatusHeader.Aprobada);
                        MessageBox.Show(@"Se ejecuto correctamente el FIX");
                        break;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }

            }
        }
    }
}
