using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.MainDocumentData;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvFacturaL1_PDF : Form
    {
        public RpvFacturaL1_PDF(int idFactura, bool imprimirMsgMora, string observacionAdicional, bool ckInfoConsolidada, bool incluyeBarras)
        {
            _idFactura = idFactura;
            _ckInfoConsolidada = ckInfoConsolidada;
            _ckMora = imprimirMsgMora;
            _observacion = observacionAdicional;
            _incluyeBarras = incluyeBarras;
            InitializeComponent();
        }
        private readonly int _idFactura;
        private readonly bool _ckMora;
        private readonly string _observacion;
        private readonly bool _ckInfoConsolidada;
        private string tipoLetracomprobante;
        private bool _incluyeBarras;

        private void RpvFacturaL1_Preimpreso_Load(object sender, EventArgs e)
        {
            //**Header
            var dataHeader = new TecserData(GlobalApp.CnnApp).T0400_FACTURA_H.Where(c => c.IDFACTURA == _idFactura).ToList();
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
            List<T0401_FACTURA_I> dataItems;
            if (_ckInfoConsolidada)
            {
                var data = new CustomerInvoice("X", _idFactura);
                dataItems = data.InformacionFacturaConsolidada();
            }
            else
            {
                dataItems = new TecserData(GlobalApp.CnnApp).T0401_FACTURA_I.Where(c => c.IDFactura == _idFactura).ToList();
            }
            var reportDataSourceI = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsItems",
                Value = dataItems
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceI);

            //**Descripcion ZTerm - Si no tiene Zterm le pone 0E por default
            var zterm = string.IsNullOrEmpty(dataHeader[0].ZTERM) ? "0E" : dataHeader[0].ZTERM;
            var dataZTerm = new TecserData(GlobalApp.CnnApp).T0019_ZTERM.Where(c => c.ZTERM == zterm).ToList();
            var reportds2 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsZTerm",
                Value = dataZTerm
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportds2);

            //Texto variable y Parametros

            DateTime fechaF = dataHeader[0].FECHA.Date;
            decimal preciousD = (decimal)dataHeader[0].TotalFacturaN / (decimal)dataHeader[0].TC;
            string obs1 =
                string.Format("Por motivos fiscales este documento esta emitido en PESOS [ARS] equivalentes a: {0} DOLARES ESTADOUNIDENSES, considerándose el tipo de cambio vendedor vigente al {1} de {2}, siendo este valor en PESOS susceptible a la variación del tipo de cambio al momento de efectuarse la ACREDITACION DEL PAGO", preciousD.ToString("N2"), fechaF.Date.ToString("d"), dataHeader[0].TC);


            string codigo = null;
            string tipoDocumento = null;
            string letraDocumento = null;
            switch (dataHeader[0].TIPO_DOC)
            {
                case "FA":
                    tipoDocumento = "FACTURA";
                    codigo = "Cod.001";
                    letraDocumento = "A";
                    break;
                case "NC":
                    tipoDocumento = "NOTA DE CREDITO";
                    codigo = "Cod.003";
                    letraDocumento = "A";
                    break;
                case "ND":
                    tipoDocumento = "NOTA DE DEBITO";
                    codigo = "Cod.002";
                    letraDocumento = "A";
                    break;
                case "FM":
                    tipoDocumento = "FACTURA";
                    codigo = "Cod.051";
                    letraDocumento = "M";
                    break;
                case "CB":
                    tipoDocumento = "NOTA DE CREDITO";
                    codigo = "Cod.008";
                    letraDocumento = "B";
                    break;
                case "CM":
                    tipoDocumento = "NOTA DE CREDITO";
                    codigo = "Cod.053";
                    letraDocumento = "M";
                    break;
                case "DB":
                    tipoDocumento = "NOTA DE DEBITO";
                    codigo = "Cod.007";
                    letraDocumento = "B";
                    break;
                case "DM":
                    tipoDocumento = "NOTA DE DEBITO";
                    codigo = "Cod.052";
                    letraDocumento = "M";
                    break;
                case "DX":
                    tipoDocumento = "DEBITO NO FISCAL";
                    codigo = "Cod.000";
                    letraDocumento = "X";
                    obs1 = "DOCUMENTO NO FISCAL";
                    _incluyeBarras = false;
                    break;
                case "CX":
                    tipoDocumento = "CREDITO NO FISCAL";
                    codigo = "Cod.000";
                    letraDocumento = "X";
                    obs1 = "DOCUMENTO NO FISCAL";
                    _incluyeBarras = false;
                    break;
            }

            string textoIIBB = null;

            if (dataHeader[0].TotalIIBB > 0)
            {
                textoIIBB = string.Format("Perc.IIBB BsAs. Alic {0}", dataHeader[0].IIBB_PORC.Value.ToString("P2"));
            }
            else
            {
                textoIIBB = "Perc.IIBB BsAs. Alic 0%";
            }


            string mora = null;
            if (_ckMora)
            {
                mora = "Por mora se devengara un interese de un 4% mensual";
            }
            string obs2 = _observacion;
            string archivoBarra;

            //Esto se reemplaza por codigo QR
            if (_incluyeBarras)
            {
                //string fileBarra = new CodigoBarrasAfip().GeneraCodigoBarras(_idFactura);
                //archivoBarra = @"file:\\\" + fileBarra + ".jpg";
                var Qr = new AfipQrCodeManager();
                var z = Qr.GeneraCodigoQrFacturas(_idFactura, true);
                if (z != null)
                {
                    archivoBarra = @"file:\\\" + Qr.GetCompleteFilename();
                }
                else
                {
                    //aca poner un file fake
                    archivoBarra = @"file:\\\" + AppDomain.CurrentDomain.BaseDirectory + @"fiu.jpg";
                }
            }
            else
            {
                //archivoBarra = @"file:\\\" + AppDomain.CurrentDomain.BaseDirectory + @"fiu.jpg";
                archivoBarra = @"file:\\\" + AppDomain.CurrentDomain.BaseDirectory + @"fiu.jpg";

            }

            Microsoft.Reporting.WinForms.ReportParameter[] parameters =
                new Microsoft.Reporting.WinForms.ReportParameter[8];
            parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parObserv1", obs1);
            parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("parObserv2", obs2);
            parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("parTdocCod", codigo);
            parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("parTdocDesc", tipoDocumento);
            parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("parMora", mora);
            parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("parIIBB", textoIIBB);
            parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("parBarraPath", archivoBarra);
            parameters[7] = new Microsoft.Reporting.WinForms.ReportParameter("parLetraDocumento", letraDocumento);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
