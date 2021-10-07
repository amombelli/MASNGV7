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
    public partial class RpvDocumentoX1L1RetornoCheque : Form
    {
        //Creado para Documento X - Retorno de Cheque 
        public RpvDocumentoX1L1RetornoCheque(int idNcdH)
        {
            _idNcdH = idNcdH;
            InitializeComponent();
        }
        private readonly int _idNcdH;
        private readonly string _observacion;
        private string tipoLetracomprobante;


        private void RpvFacturaL1_Preimpreso_Load(object sender, EventArgs e)
        {
            //**Header
            var dataHeader = new TecserData(GlobalApp.CnnApp).T0300_NCD_H.Where(c => c.IDH == _idNcdH).ToList();
            if (dataHeader.Count == 0)
            {
                MessageBox.Show(@"El documento a mostrar no existe", @"Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var reportDataSourceH = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "Xheader",
                Value = dataHeader
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceH);

            //**Detalle de CostItems
            var dataItems = new TecserData(GlobalApp.CnnApp).T0301_NCD_I.Where(c => c.IDH == _idNcdH).ToList();
            var reportDataSourceI = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "Xitems",
                Value = dataItems
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceI);

            //**Descripcion ZTerm --> Por default para este documento mandaremos 0E
            var zterm = "0E";
            var dataZTerm = new TecserData(GlobalApp.CnnApp).T0019_ZTERM.Where(c => c.ZTERM == zterm).ToList();
            var reportds2 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "XZterm",
                Value = dataZTerm
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportds2);

            //Texto variable y Parametros

            DateTime fechaF = dataHeader[0].FECHA.Date;
            string obs1 = "";
            string obs2 = "";
            string codigo = null;
            string tipoDocumento = null;
            string letraDocumento = null;
            int idcliente = dataHeader[0].IdCliente;
            var cliData = new TecserData(GlobalApp.CnnApp).T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idcliente);
            string cuit = cliData.CUIT;
            string direccionFiscal = cliData.Direccion_facturacion + ", " + cliData.Direfactu_Localidad; 
            
            //Documento AX 
            tipoDocumento = "NO FISCAL";
            codigo = "Cod.000";
            letraDocumento = "X";

            //switch (dataHeader[0].TIPO_DOC)
            //{
            //    case "FA":
            //        tipoDocumento = "FACTURA";
            //        codigo = "Cod.001";
            //        letraDocumento = "A";
            //        break;
            //    case "NC":
            //        tipoDocumento = "NOTA DE CREDITO";
            //        codigo = "Cod.003";
            //        letraDocumento = "A";
            //        break;
            //    case "ND":
            //        tipoDocumento = "NOTA DE DEBITO";
            //        codigo = "Cod.002";
            //        letraDocumento = "A";
            //        break;
            //    case "FM":
            //        tipoDocumento = "FACTURA";
            //        codigo = "Cod.051";
            //        letraDocumento = "M";
            //        break;
            //    case "CB":
            //        tipoDocumento = "NOTA DE CREDITO";
            //        codigo = "Cod.008";
            //        letraDocumento = "B";
            //        break;
            //    case "CM":
            //        tipoDocumento = "NOTA DE CREDITO";
            //        codigo = "Cod.053";
            //        letraDocumento = "M";
            //        break;
            //    case "DB":
            //        tipoDocumento = "NOTA DE DEBITO";
            //        codigo = "Cod.007";
            //        letraDocumento = "B";
            //        break;
            //    case "DM":
            //        tipoDocumento = "NOTA DE DEBITO";
            //        codigo = "Cod.052";
            //        letraDocumento = "M";
            //        break;
            //}

            //string textoIIBB = null;

            //if (dataHeader[0].TotalIIBB > 0)
            //{
            //    textoIIBB = string.Format("Perc.IIBB BsAs. Alic {0}", dataHeader[0].IIBB_PORC.Value.ToString("P2"));
            //}
            //else
            //{
            //    textoIIBB = "Perc.IIBB BsAs. Alic 0%";
            //}
            Microsoft.Reporting.WinForms.ReportParameter[] parameters = new Microsoft.Reporting.WinForms.ReportParameter[7];
            parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parObserv1", obs1);
            parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("parObserv2", obs2);
            parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("parTdocCod", codigo);
            parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("parTdocDesc", tipoDocumento);
            parameters[4] = new Microsoft.Reporting.WinForms.ReportParameter("parLetraDocumento", letraDocumento);
            parameters[5] = new Microsoft.Reporting.WinForms.ReportParameter("clienteDireccion", direccionFiscal);
            parameters[6] = new Microsoft.Reporting.WinForms.ReportParameter("clienteCuit", cuit);

            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
