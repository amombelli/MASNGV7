using System;
using System.Windows.Forms;
using MASngFE.MasterData;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;

namespace MASngFE.Transactional.FI.VendorPRM
{
    public partial class FrmFI50VendorPRMMain : Form
    {
        public FrmFI50VendorPRMMain()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnCambio()
        {
            t403Bs.DataSource = new VendorDocuments().GetVendorDocuments(uVendorSearch1.VendorId.Value);
        }
        private void FrmFI50VendorPRMMain_Load(object sender, EventArgs e)
        {
            uVendorSearch1.InicializaUc();
            uVendorSearch1.Show += OnCambio;
        }

        private void BtnVendorDetail_Click(object sender, EventArgs e)
        {
            if (uVendorSearch1.VendorId == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Proveedor para poder visualizar sus datos", "Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new FrmVendorDetailData(3, uVendorSearch1.VendorId.Value))
            {
                f.ShowDialog();
            }
        }

        private void DgvListaFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idI403 = Convert.ToInt32(datagridview[iDINTDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "VER":
                    using (var f0 = new FrmFI51VendorInvoiceView("PRM", idI403))
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
