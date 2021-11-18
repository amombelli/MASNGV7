using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmFI45DetalleImputacionFactura : Form
    {
        public FrmFI45DetalleImputacionFactura(int idFactura)
        {
            _idFactura = idFactura;
            InitializeComponent();
        }

        //------------------------------------------------------------------------
        private readonly int _idFactura;
        private int _idCtaCte;

        //------------------------------------------------------------------------
        private void FrmDetalleImputacionPorFactura_Load(object sender, EventArgs e)
        {
            LoadHeaderData();
            t0207SPLITFACTURASBindingSource.DataSource =
                new CobranzaImputacion().GetListaRecibosImputanFactura(_idCtaCte);
            CalculaPorcentajeApplicacion();
        }
        private void LoadHeaderData()
        {
            var dataF = new CustomerInvoice("FAC", _idFactura).GetHeaderData();
            var cli = new CustomerManager().GetCustomerBillToData(dataF.Cliente);

            txtRazonSocial.Text = cli.cli_rsocial;
            txtFantasia.Text = cli.cli_fantasia;
            txtId6.Text = cli.IDCLIENTE.ToString();
            txtFecha.Text = dataF.FECHA.ToString("d");
            _idCtaCte = dataF.IdCtaCte.Value;
            txtLx.Text = dataF.TIPOFACT;
            txtTdoc.Text = dataF.TIPO_DOC;
            txtNumeroDoc.Text = txtLx.Text == @"L1" ? dataF.PV_AFIP + @"-" + dataF.ND_AFIP : dataF.Remito;
            txtTc.Text = dataF.TC.ToString("n2");

            var saldoPendienteDoc = new CobranzaImputacion().GetSaldoImpago(_idCtaCte);
            txtMoneda.Text = txtMon1.Text = dataF.FacturaMoneda;
            txtImporte.Text = dataF.TotalFacturaN.ToString("C2");
            var imputado = dataF.TotalFacturaN - saldoPendienteDoc;
            txtImputado.Text = imputado.ToString("C2");
            txtPorcentajeImputado.Text = (imputado / dataF.TotalFacturaN).ToString("P2");
            if (dataF.TotalFacturaN - imputado == 0)
            {
                txtImputado.BackColor = Color.GreenYellow;
            }
            else
            {
                txtImputado.BackColor = Color.Orange;
            }

            var new1 = new CobranzaUtils().GetValorImputacion(dataF.IDFACTURA);
            txtDocumentoUSD.Text = (dataF.TotalFacturaN / dataF.TC).ToString("C2");
            txtCobradoUSD.Text = new1.UsdTotalCobrado.ToString("C2");
            if (new1.UsdTotalCobrado != 0)
                txtTcCobranza.Text = ((dataF.TotalFacturaN - new1.ArsSaldoImpago) / new1.UsdTotalCobrado).ToString("N2");
        }
        private void CalculaPorcentajeApplicacion()
        {
            foreach (DataGridViewRow row in dgvLista.Rows)
            {
                // Calculate total cost.
                decimal porcentajeAppl =
                    Math.Round(((decimal)row.Cells[__montoAplicado.Name].Value /
                                (decimal)row.Cells[__importeTotal.Name].Value), 4);

                // Display the value.
                row.Cells[aplicadoPorcentaje.Name].Value = porcentajeAppl;

                // Highlight the cell if the vcalue is big.
                if (porcentajeAppl == 1)
                {
                    row.Cells[aplicadoPorcentaje.Name].Style.BackColor = Color.LightBlue;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
