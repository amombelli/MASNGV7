using System;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportDataSource;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvPreparacionPedido : Form
    {
        public RpvPreparacionPedido(int idRemito)
        {
            InitializeComponent();
            _idRemito = idRemito;
        }

        private readonly int _idRemito;
        private void RpvPreparacionPedido_Load(object sender, EventArgs e)
        {
            //   this.reportViewer1.RefreshReport();
            var x = new VendorManager().GetSpecificVendor(263);

            var m = new dsPreparacionPedido();
            int idRemito = _idRemito;
            var dataReport = new TecserData(GlobalApp.CnnApp).T0055_REMITO_H.Where(c => c.IDREMITO == idRemito).ToList();
            var reportDataSourceH = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceH.Name = "DataSet2";
            reportDataSourceH.Value = dataReport;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceH);

            var dataItem = new TecserData(GlobalApp.CnnApp).T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();
            var reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = dataItem;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);

            var idCliente = dataReport[0].CODCLIENTREGA;
            var dataCliente = new TecserData(GlobalApp.CnnApp).T0007_CLI_ENTREGA.Where(c => c.ID_CLI_ENTREGA == idCliente).ToList();
            var reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = dataCliente;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
