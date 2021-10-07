using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvBOM : Form
    {
        public RpvBOM(int numeroBOM)
        {
            _numeroBOM = numeroBOM;
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------
        private readonly int _numeroBOM;

        //---------------------------------------------------------------------------------

        private void RpvBOM_Load(object sender, EventArgs e)
        {
            var dataH = new TecserData(GlobalApp.CnnApp).T0020_FORMULA_H.Where(c => c.ID_FORMULA == _numeroBOM).ToList();
            var dataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "dsBomHeader1",
                Value = dataH
            };
            this.reportViewer1.LocalReport.DataSources.Add(dataSource1);

            var dataI = new BOMManager().GetFormulaItems(_numeroBOM);
            var dataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Name = "dsBomItem1",
                Value = dataI
            };
            this.reportViewer1.LocalReport.DataSources.Add(dataSource2);


            //var dataReport = new TecserData(GlobalApp.CnnApp).GetDataOrdenPago_byOpNum(_numeroOP).ToList();
            //var reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            //reportDataSource1.Name = "DataSet1";
            //reportDataSource1.Value = dataReport;
            //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ////
            //var dataFacturas = new TecserData(GlobalApp.CnnApp).T0213_OP_FACT.Where(c => c.IDOP == _numeroOP).ToList();
            //var reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            //reportDataSource2.Name = "DataSet2";
            //reportDataSource2.Value = dataFacturas;
            //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            ////
            //var dataFacturas1 = new TecserData(GlobalApp.CnnApp).T0213_OP_FACT.Where(c => c.IDOP == _numeroOP).ToList();
            //var reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            //reportDataSource3.Name = "Ds1";
            //reportDataSource3.Value = dataFacturas1;
            //this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);

            // reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(reportDataSource,dataFacturas);

            this.reportViewer1.RefreshReport();

        }


    }
}
