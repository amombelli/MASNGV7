using System;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Tecser.Business.MainApp;
using Tecser.Business.Network;
using Tecser.Business.Tools;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvReciboCobranzaOficial : Form
    {
        public RpvReciboCobranzaOficial(int idCobranza, bool generarPdf = false, bool verReporte = false,
            string emailSendTo = null)
        {
            _idCob = idCobranza;
            _generarPdf = generarPdf;
            _verReporte = verReporte;
            _emailSendTo = emailSendTo;
            InitializeComponent();
        }

        //--------------------------------------------------------------------------
        private readonly int _idCob;
        private readonly bool _generarPdf;
        private readonly bool _verReporte;
        private readonly string _emailSendTo;
        //--------------------------------------------------------------------------
        private void RpvReciboCobranzaOficial_Load(object sender, EventArgs e)
        {
            //Header de Recibo
            var dataHeader = new TecserData(GlobalApp.CnnApp).T0205_COBRANZA_H.Where(c => c.IDCOB == _idCob).ToList();
            if (dataHeader.Count == 0)
            {
                MessageBox.Show(@"El documento a mostrar no existe", @"Error en datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var reportDataSourceH = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsReciboHeader",
                Value = dataHeader
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceH);

            //Detalle de CostItems
            var dataItems = new FillCobranzaItemStructureDetaill().FillData(_idCob, GlobalApp.CnnApp);
            var reportDataSourceI = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsItemsCobranza",
                Value = dataItems
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceI);

            //Datos Cliente
            var idCliente = dataHeader[0].IdCliente.Value;
            var dataCli = new TecserData(GlobalApp.CnnApp).T0006_MCLIENTES.Where(c => c.IDCLIENTE == idCliente).ToList();
            var reportds2 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsCliente",
                Value = dataCli
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportds2);

            //Parametros
            Microsoft.Reporting.WinForms.ReportParameter[] parameters =
                new Microsoft.Reporting.WinForms.ReportParameter[1];

            var numerosEnLetras = new NumeroToLetras().Enletras(dataHeader[0].Monto.ToString());
            string obs1 = "La cantidad de PESOS " + dataHeader[0].Monto.ToString("C2") + " (" + numerosEnLetras +
                          "), según el detalle que sigue a continuacion:";

            parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parObservacion", obs1);

            //Configuracion Reporte-Margenes
            this.reportViewer1.LocalReport.SetParameters(parameters);
            var pg = new PageSettings
            {
                Margins =
                {
                    Left = 20,
                    Right = 20,
                    Top = 20,
                    Bottom = 20
                }
            };
            this.reportViewer1.SetPageSettings(pg);
            var archivoPdf = dataCli[0].cli_rsocial + "-" + dataHeader[0].NRECIBOOFI + ".pdf";

            if (_generarPdf)
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;

                byte[] bytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);

                using (FileStream fs = new FileStream(archivoPdf, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    MessageBox.Show(@"Se ha Generado el PDF en forma correcta", @"Generacion de PDF",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                if (string.IsNullOrEmpty(_emailSendTo) == false)
                {
                    var body =
                        "<p>Estimado Cliente, enviamos adjunto el <b> recibo oficial </b> de su pago.<p> <p>Muchas Gracias <p><p> Mombelli e Hijos SRL<p>";

                    new EmailManager().SendEmail(_emailSendTo, dataCli[0].cli_rsocial, "ventas@mombellisrl.com.ar",
                        "TecserMasterbatch", "ventas@mombellisrl.com.ar", null, "Envio Recibo de Pago", body, false,
                        "ventas@mastertecser.com.ar", archivoPdf);

                    MessageBox.Show(@"Se ha enviado correctamente el Email", @"Envio de Email", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

            if (_verReporte)
            {
                this.reportViewer1.RefreshReport();
            }
            else
            {
                this.Close();
            }
        }
    }
}
