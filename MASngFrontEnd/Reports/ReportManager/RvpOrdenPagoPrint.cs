using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.OrdenPago;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RvpOrdenPagoPrint : Form
    {
        private readonly int _numeroOP;
        public RvpOrdenPagoPrint(int numeroOP)
        {
            _numeroOP = numeroOP;
            InitializeComponent();
        }
        private void RvpOrdenPagoPrint_Load(object sender, EventArgs e)
        {
            var op = new OPReportDataSource(_numeroOP);
            var headerOp = op.GetHeader().ToList();
            //
            var reportDs1 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "VendorHeader",
                Value = new[] { new VendorManager().GetSpecificVendor(headerOp[0].IdProveedor) }
            };
            reportViewer1.LocalReport.DataSources.Add(reportDs1);
            //
            var rptDs2 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = headerOp,
                Name = "zOpHeader"
            };
            this.reportViewer1.LocalReport.DataSources.Add(rptDs2);
            //
            var items =new TecserData(GlobalApp.CnnApp).T0211_OrdenPagoItems.Where(c => c.IdOP == _numeroOP && c.EsCheque==false).ToList();
            var rptDs3 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = items,
                Name = "zItemsPagoEfectivoTransf"
            };
            this.reportViewer1.LocalReport.DataSources.Add(rptDs3);
            //
            var reten = new TecserData(GlobalApp.CnnApp).T0213_OrdenPagoRetenciones.Where(c => c.IdOP == _numeroOP).ToList();
            var rptDs4 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = reten,
                Name = "zRetenciones"
            };
            this.reportViewer1.LocalReport.DataSources.Add(rptDs4);
            //
            var factu = op.GetAplicacionFacturas().ToList();
                
                //new TecserData(GlobalApp.CnnApp).T0212_OrdenPagoDocumentos.Where(c => c.IdOP == _numeroOP).ToList();
            var rptDs5 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = factu,
                Name = "zImputacionAplicada"
            };
            this.reportViewer1.LocalReport.DataSources.Add(rptDs5);
            //
            var cheques = new TecserData(GlobalApp.CnnApp).T0211_OrdenPagoItems.Where(c => c.IdOP == _numeroOP && c.EsCheque == true).ToList();
            var rptDs6 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = cheques,
                Name = "zCheques"
            };
            this.reportViewer1.LocalReport.DataSources.Add(rptDs6);
            //
            var creditos = op.GetCreditosAplicados().ToList();
            var rptDs7 = new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = creditos,
                Name = "zCreditosOp"
            };
            this.reportViewer1.LocalReport.DataSources.Add(rptDs7);




            //listado de parametros





            this.reportViewer1.RefreshReport();
        }
    }
}
