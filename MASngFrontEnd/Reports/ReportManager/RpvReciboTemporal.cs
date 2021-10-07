using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI.Cobranza;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvReciboTemporal : Form
    {
        public RpvReciboTemporal(int idCobTemporal)
        {
            _idCob = idCobTemporal;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------
        private readonly int _idCob;

        //-----------------------------------------------------------------------------------------------
        private void RpvReciboTemporal_Load(object sender, EventArgs e)
        {
            //**Header
            var dataHeader = new TecserData(GlobalApp.CnnApp).T1205_CobranzaConvertirHeader.Where(c => c.idCobTemp == _idCob).ToList();
            if (dataHeader.Count == 0)
            {
                MessageBox.Show(@"El documento a mostrar no existe", @"Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var reportDataSourceH = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsHeader",
                Value = dataHeader
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceH);

            //**Detalle de CostItems
            var dataItems = new CobranzaTemporalManager().GetItemsCobranzaTemporal(_idCob);
            var reportDataSourceI = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsItems",
                Value = dataItems
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceI);
            this.reportViewer1.RefreshReport();
        }
    }
}
