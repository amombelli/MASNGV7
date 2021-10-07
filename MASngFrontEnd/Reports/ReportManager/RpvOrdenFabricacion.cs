using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvOrdenFabricacion : Form
    {
        public RpvOrdenFabricacion(int numeroOF)
        {
            InitializeComponent();
            _numeroOF = numeroOF;
        }

        private readonly int _numeroOF;

        private void RpvOrdenFabricacion_Load(object sender, EventArgs e)
        {
            var data = new TecserData(GlobalApp.CnnApp).GetOrdenFabricacionReportDataSource(_numeroOF).ToList();
            var reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "DataSetOrdenFab",
                Value = data
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.RefreshReport();
        }
    }
}