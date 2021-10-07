using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvOrdenCompra : Form
    {
        public RpvOrdenCompra()
        {
            InitializeComponent();
        }

        private readonly int _numeroOC;

        public RpvOrdenCompra(int numeroOC)
        {
            InitializeComponent();
            _numeroOC = numeroOC;
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {
            var headerOC =
                new TecserData(GlobalApp.CnnApp).T0060_OCOMPRA_H.Where(c => c.IDORDENCOMPRA == _numeroOC).ToList();
            var vendorId = headerOC[0].PROVEEDOR.Value;

            var provData =
                new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Where(c => c.id_prov == vendorId).ToList();
            var rptDs1 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = provData,
                Name = "VendorH"
            };
            this.reportViewer1.LocalReport.DataSources.Add(rptDs1);


            var rptDs2 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = headerOC,
                Name = "OrdenCompraH"
            };
            this.reportViewer1.LocalReport.DataSources.Add(rptDs2);

            var ItemData = new OrdenCompraManager().GetListItemsOC(_numeroOC).ToList();
            var rptDs3 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = ItemData,
                Name = "OrdenCompraI"
            };
            this.reportViewer1.LocalReport.DataSources.Add(rptDs3);
            this.reportViewer1.RefreshReport();
        }

    }
}
