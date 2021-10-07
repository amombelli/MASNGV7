using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvWmStandBy : Form
    {
        public RpvWmStandBy()
        {
            InitializeComponent();
        }

        private void RpvWmStandBy_Load(object sender, EventArgs e)
        {
            var stockData = new TecserData(GlobalApp.CnnApp).T0030_STOCK.Where(c => c.SLOC == "STBY")
                .OrderBy(c => c.Material).ToList();

            var dataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "dsStock",
                Value = stockData
            };
            this.reportViewer1.LocalReport.DataSources.Add(dataSource1);
            this.reportViewer1.RefreshReport();

        }
    }
}
