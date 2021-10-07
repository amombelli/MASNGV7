using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI.MainDocumentData;
using TecserEF.Entity;

namespace MASngFE.Reports.ReportManager
{
    public partial class RpvFacturaL2 : Form
    {
        public RpvFacturaL2(int idFactura, bool ckImprimirMora, bool ckItemsConsolidados)
        {
            _idFactura = idFactura;
            _imprimirMora = ckImprimirMora;
            _itemConsolidado = ckItemsConsolidados;
            InitializeComponent();
        }

        private readonly int _idFactura;
        private readonly bool _imprimirMora;
        private readonly bool _itemConsolidado;
        private void RpvFacturaL2_Load(object sender, EventArgs e)
        {
            //Header
            var dataHeader = new TecserData(GlobalApp.CnnApp).T0400_FACTURA_H.Where(c => c.IDFACTURA == _idFactura).ToList();
            if (dataHeader.Count == 0)
            {
                MessageBox.Show(@"No Existe la factura a mostrar");
                return;
            }
            var reportDataSourceH = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsHeader",
                Value = dataHeader
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceH);

            //Datos Direccion de Entrega

            var idRemito = dataHeader[0].IDRemito;
            var cliE = new TecserData(GlobalApp.CnnApp).T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
            if (cliE == null)
                return;
            var idClienteEntrega = cliE.CODCLIENTREGA;

            var dataDireccionEntrega =
                new TecserData(GlobalApp.CnnApp).T0007_CLI_ENTREGA.Where(c => c.ID_CLI_ENTREGA == idClienteEntrega).ToList();
            var reportDataSourceEntrega = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsClienteEntrega",
                Value = dataDireccionEntrega
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceEntrega);

            //Detalle de CostItems

            //**Detalle de CostItems
            List<T0401_FACTURA_I> dataItems;
            if (_itemConsolidado)
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
                Name = "dsItemsFactura",
                Value = dataItems
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSourceI);

            //Detalle Remito H * para cantidad de bultos y obs
            var dataRemitoH = new TecserData(GlobalApp.CnnApp).T0055_REMITO_H.Where(c => c.IDREMITO == idRemito).ToList();
            var reportds3 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsRemitoH",
                Value = dataRemitoH
            };
            this.reportViewer1.LocalReport.DataSources.Add(reportds3);



            //Descripcion ZTerm
            string zterm;
            if (string.IsNullOrEmpty(dataHeader[0].ZTERM))
            {
                zterm = "0E";
            }
            else
            {
                zterm = dataHeader[0].ZTERM;
            }
            var dataZTerm = new TecserData(GlobalApp.CnnApp).T0019_ZTERM.Where(c => c.ZTERM == zterm).ToList();
            var reportds2 = new Microsoft.Reporting.WinForms.ReportDataSource
            {
                Name = "dsZterm",
                Value = dataZTerm
            };
            DateTime fechaF = dataHeader[0].FECHA.Date;
            decimal preciousD = (decimal)dataHeader[0].TotalFacturaN / (decimal)dataHeader[0].TC;
            string obs =
                string.Format("Este documento esta expresando en PESOS [ARS] que equivalen a: {0} DOLARES ESTADOUNIDENSES, considerándose el tipo de cambio vendedor vigente al {1} de {2}, siendo este valor en PESOS susceptible a la variación del tipo de cambio al momento de efectuarse la ACREDITACION DEL PAGO", preciousD.ToString("N2"), fechaF, dataHeader[0].TC);

            this.reportViewer1.LocalReport.DataSources.Add(reportds2);

            decimal? saldoL2;

            int idClienteRS = dataHeader[0].Cliente;
            var saldo = new TecserData(GlobalApp.CnnApp).T0202_CTACTESALDOS.SingleOrDefault(c => c.IDCLIENTE == idClienteRS && c.CUENTATIPO == "L2");
            if (saldo == null)
            {
                saldoL2 = null;
            }
            else
            {
                saldoL2 = saldo.DEUDA_TOT_ARS;
            }
            var verMora = @"0";
            if (_imprimirMora)
            {
                verMora = "1";
            }

            if (saldoL2 == null)
                saldoL2 = 0;

            Microsoft.Reporting.WinForms.ReportParameter[] parameters =
                new Microsoft.Reporting.WinForms.ReportParameter[4];
            parameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("parObservacion1", obs);
            parameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("parMoneda", "ARS");
            parameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("parSaldoAdeudado", saldoL2.ToString());
            parameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("parVerSaldo", verMora);
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
