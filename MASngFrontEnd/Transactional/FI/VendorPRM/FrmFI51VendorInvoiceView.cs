using System;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;
using Tecser.Business.Transactional.FI.OrdenPago;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.VendorPRM
{
    public partial class FrmFI51VendorInvoiceView : Form
    {
        public FrmFI51VendorInvoiceView(string modo, int idFactura403)
        {
            _modo = modo;
            _idFactura403 = idFactura403;
            InitializeComponent();
        }
        //----------------------------------------------------------------------------------------
        private string _modo;
        private readonly int _idFactura403;

        private void FrmFI51VendorInvoiceView_Load(object sender, EventArgs e)
        {
            this.dgvItems.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvItems_CellEnter);
            LoadInvoiceData();
        }
        //----------------------------------------------------------------------------------------

        private void LoadInvoiceData()
        {
            var invoiceD = new VendorDocuments().GetDocument(_idFactura403);
            if (invoiceD != null)
            {
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    var vendorData = new VendorManager().GetSpecificVendor(invoiceD.IDPROV);
                    txtProveedorRS.Text = vendorData.prov_rsocial;

                    txtTdoc.Text = invoiceD.TFACTURA;
                    txtNumeroDoc.Text = invoiceD.NFACTURA;
                    txtFecha.Text = invoiceD.FECHA.ToString("d");
                    txtMoneda.Text = invoiceD.MON;
                    txtTc.Text = invoiceD.TC.ToString("N2");
                    txtImporteBruto.Text = invoiceD.BRUTO.ToString("C2");
                    txtImporteNeto.Text = invoiceD.NETO.ToString("C2");
                    txtFechaConta.Text = invoiceD.LOGDATE.Value.ToString("d");
                    txtUsuarioConta.Text = invoiceD.LOGUSER;
                    txtAsiento.Text = invoiceD.NASIENTO.Value.ToString();
                    txtIdCtaCte.Text = invoiceD.IDCTACTE.Value.ToString();
                    txtSaldoImpago.Text = db.T0203_CTACTE_PROV
                        .SingleOrDefault(c => c.IDCTACTE == invoiceD.IDCTACTE.Value).SALDOFACTURA.ToString("C2");

                    dgvItems.DataSource = new VendorDocuments().GetDocumentItems(_idFactura403);
                    dgvImputacion.DataSource = new VendorDocuments().GetImputacionDocumento(invoiceD.IDCTACTE.Value);
                }
                this.dgvItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvItems_CellEnter);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DgvItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void DgvImputacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var tipoDocumento = datagridview[tDOCDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            //var activo = Convert.ToBoolean(datagridview[aCTIVODataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "Ver":
                    if (tipoDocumento != "OP")
                    {
                        MessageBox.Show(@"La forma de Pago no dispone de un documento para visualizarse",
                            @"Sin Informacion Dispoible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        var idCtaCteOP =
                            Convert.ToInt32(datagridview[cTACTE2DataGridViewTextBoxColumn.Name, e.RowIndex].Value);

                        using (var db = new TecserData(GlobalApp.CnnApp))
                        {
                            var idop = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCteOP).IDDOC.Value;
                            var header = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == idop);
                            header.DiasPPFacturas = new EstadisticasPagoOP().DiasPagoFactura(idop);
                            header.DiasPPItemsPago = new EstadisticasPagoOP().DiasPPItemsPagoDesdeFechaOP(idop);
                            db.SaveChanges();
                            using (var f0 = new RpvOrdePago(idop))
                            {
                                DialogResult dr = f0.ShowDialog();
                                if (dr == DialogResult.OK)
                                {
                                    //string custName = f0.CustomerName;
                                    //SaveToFile(custName);
                                }
                            }
                        }
                    }
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void BtnTestDiasCheque_Click(object sender, EventArgs e)
        {
            var y = new EstadisticasPagoOP();
            MessageBox.Show(y.DiasPagoFactura(400000044).ToString());
            MessageBox.Show(y.DiasPPItemsPagoDesdeFechaOP(400000044).ToString());
        }

        private void DgvImputacion_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (dgvImputacion[tDOCDataGridViewTextBoxColumn.Name, e.RowIndex] == null)
                return;


            var tDoc = dgvImputacion[tDOCDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            if (tDoc == "OP")
            {
                int idCtaCteOP = Convert.ToInt32(dgvImputacion[CTACTE2.Name, e.RowIndex].Value.ToString());
                var stat = new EstadisticasPagoOP();
                txtDiasPPItems.Text = stat.GetDiasItemsPagoFromIdCtaCte(idCtaCteOP).ToString();
                txtDiasPPDoc.Text = stat.GetDiasPagoFacturaFromIdCtaCte(idCtaCteOP).ToString();
            }
            else
            {
                txtDiasPPItems.Text = @"N/A";
                txtDiasPPDoc.Text = @"N/A";
            }
        }
    }
}
