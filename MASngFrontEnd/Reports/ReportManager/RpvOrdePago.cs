using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvOrdePago : Form
    {
        public RpvOrdePago(int numeroOP)
        {
            InitializeComponent();
            _numeroOP = numeroOP;
        }

        private readonly int _numeroOP;
        private void RpvOrdePago_Load(object sender, EventArgs e)
        {
            //dsOrdenPago m = new dsOrdenPago();

            var dataReport = new TecserData(GlobalApp.CnnApp).GetDataOrdenPago_byOpNum(_numeroOP).ToList();
            var lx1 = dataReport.Where(c => c.CUENTA_O != "OPCRED" || c.CUENTA_O != "NC").ToList();
            var lx2 = lx1.Where(c => c.CUENTA_O != "NC").ToList();
            var reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "DataSet1",
                Value = lx2
            };

            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);


            //---------------------------------------------------------------------------------------------------------------
            //
            var dataFacturas = new TecserData(GlobalApp.CnnApp).T0213_OP_FACT.Where(c => c.IDOP == _numeroOP).ToList();
            var reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = dataFacturas;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            //

            var dataFacturas1 = new TecserData(GlobalApp.CnnApp).T0213_OP_FACT.Where(c => c.IDOP == _numeroOP).ToList();
            var reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSource3.Name = "Ds1";
            reportDataSource3.Value = dataFacturas1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);


            //Cuadro de Ordenes de Pago a Cuenta
            var dataCreditosAnteriores =
                new TecserData(GlobalApp.CnnApp).T0212_OP_ITEM.Where(c => c.IDOP == _numeroOP && (c.CUENTA_O == "OPCRED" || c.CUENTA_O == "NC")).ToList();
            var reportDs4 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "rpDs4",
                Value = dataCreditosAnteriores
            };
            reportViewer1.LocalReport.DataSources.Add(reportDs4);
            //---------------------------------------------------------------------------------------------------------------


            //Cuadro de Valores Pagando
            var dataValoresPago = new DsOrdenPagoValoresList().GetValoresOP(_numeroOP, GlobalApp.CnnApp).ToList();
            dataValoresPago = dataValoresPago.Where(c => c.Cuenta != "OPCRED").ToList();
            var dataValoresSinNC = dataValoresPago.Where(c => c.Cuenta != "NC").ToList();
            var reportDs5 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsCostItems",
                Value = dataValoresSinNC,

            };
            reportViewer1.LocalReport.DataSources.Add(reportDs5);
            //---------------------------------------------------------------------------------------------------------------


            this.reportViewer1.RefreshReport();
        }

    }
}
