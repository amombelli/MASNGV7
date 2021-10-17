using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvImprimirOFNew : Form
    {
        private readonly int _numeroOF;
        private OFPrintData data;

        public RpvImprimirOFNew(int numeroOF)
        {
            _numeroOF = numeroOF;
            data = new OFPrintData(_numeroOF);
            InitializeComponent();
        }

        private void RpvImprimirOFNew_Load(object sender, EventArgs e)
        {
            var DataH = data.GetHeaderData().ToList();
            var items = data.GetItems().ToList();

            var headerDataSet = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "Header",
                Value = DataH
            };
            reportViewer1.LocalReport.DataSources.Add(headerDataSet);

            var itemsDataSet = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "Items",
                Value = items
            };
            reportViewer1.LocalReport.DataSources.Add(itemsDataSet);
            this.reportViewer1.RefreshReport();
        }
    }
}
