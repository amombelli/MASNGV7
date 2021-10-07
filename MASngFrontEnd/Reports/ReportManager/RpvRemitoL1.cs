using System;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportDataSource;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvRemitoL1 : Form
    {
        public RpvRemitoL1(int idRemito)
        {
            _idRemito = idRemito;
            InitializeComponent();
        }
        private readonly int _idRemito;

        private void RpvRemitoL1_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
            var x = new VendorManager().GetSpecificVendor(263);

            var m = new dsRemitoL2();
            int idRemito = _idRemito;

            //Header
            var dataReport = new TecserData(GlobalApp.CnnApp).T0055_REMITO_H.Where(c => c.IDREMITO == idRemito).ToList();
            var reportDataSourceH = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceH.Name = "DataSetHeader";
            reportDataSourceH.Value = dataReport;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceH);

            //Cliente T7
            var idCliente = dataReport[0].CODCLIENTREGA;
            var dataClienteT7 = new TecserData(GlobalApp.CnnApp).T0007_CLI_ENTREGA.Where(c => c.ID_CLI_ENTREGA == idCliente).ToList();
            var reportDataSourceT7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceT7.Name = "DataSetT7";
            reportDataSourceT7.Value = dataClienteT7;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceT7);

            //Cliente T6
            var idCliente6 = dataClienteT7[0].IDCLIENTE;
            var dataClienteT6 = new TecserData(GlobalApp.CnnApp).T0006_MCLIENTES.Where(c => c.IDCLIENTE == idCliente6).ToList();
            var reportDataSourceT6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceT6.Name = "DataSetT6";
            reportDataSourceT6.Value = dataClienteT6;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceT6);

            //CostItems
            var dataItem = new TecserData(GlobalApp.CnnApp).T0057_REMITO_I_PRINT.Where(c => c.IDREMITO == idRemito).ToList();
            var reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource2.Name = "DataSetItems";
            reportDataSource2.Value = dataItem;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            //ZTerm
            var ztermL1 = dataClienteT6[0].ZTERML1;
            var dataZterm = new TecserData(GlobalApp.CnnApp).T0019_ZTERM.Where(c => c.ZTERM == ztermL1).ToList();
            var reportDataSourceZTerm = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceZTerm.Name = "DataSetZterm";
            reportDataSourceZTerm.Value = dataZterm;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceZTerm);

            this.reportViewer1.RefreshReport();

        }
    }
}
