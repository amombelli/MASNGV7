using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvTransferenciaReg : Form
    {
        public RpvTransferenciaReg(int idReg)
        {
            _idReg = idReg;
            InitializeComponent();
        }

        private readonly int _idReg;
        private void RpvTransferenciaReg_Load(object sender, EventArgs e)
        {
            ////Header
            var dataReport = new TecserData(GlobalApp.CnnApp).XREGISTER_H.Where(c => c.IDINT == _idReg).ToList();
            var reportDataSourceH = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsHeader",
                Value = dataReport
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceH);

            ////CostItems
            var dataItem = new TransferenciaEntreCuentasManager().GetListOfItems(_idReg);
            var reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsItems",
                Value = dataItem
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);

            ////Data Cuenta Destino
            string idCuentaDestino = dataReport[0].CUENTAD.ToString();
            var dataCuenta = new TecserData(GlobalApp.CnnApp).T0150_CUENTAS.Where(c => c.ID_CUENTA == idCuentaDestino).ToList();
            var reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsCuenta",
                Value = dataCuenta,
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.RefreshReport();
        }
    }
}
