using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO15DetalleMop : Form
    {
        private readonly int _iditem;
        private readonly int _idremito;
        private decimal costoTotalUnitario = 0;


        public FrmCO15DetalleMop(int iditem, int idremito)
        {
            _iditem = iditem;
            _idremito = idremito;
            InitializeComponent();
        }

        private void FrmCO15DetalleMop_Load(object sender, EventArgs e)
        {
            cmbVendedor.DataSource = new HumanResourcesManager().GetListEmployees(false);
            var record = new MargenDocument().GetMargenDataRecord(_idremito, _iditem);
            var customer = new CustomerManager().GetCustomerBillToData(record.IdCliente);
            txtCliente.Text = customer.cli_rsocial;
            txtRemito.Text = record.RemitoNum;
            txtFechaRemito.Text = record.FechaRemito.Value.ToString("d");
            cmbVendedor.SelectedValue = record.Vendedor;
            if (record.IdFactura == null)
            {
                MessageBox.Show(@"No hay informacion de facturacion aun", @"Datos no disponibles");
                txtFactura.Text = @"0000-00000000";
                txtFechaFactura.Text = "";
                txtTcFactura.Text = "";

            }
            else
            {
                txtFactura.Text = record.FacturaNum;
                txtTcFactura.Text = record.TCFactura.ToString();
                txtFechaFactura.Text = record.FechaFactura.Value.ToString("d");
                var facH = new T400Manager().GetDocumentHeader(record.IdFactura.Value);
                txtMonFact1.Text = txtMonFact2.Text = txtMonFact3.Text = facH.FacturaMoneda;
                txtImporteFacturaTotal.Text = facH.TotalFacturaN.ToString("C2");
                txtImporteImpuestos.Text = (facH.TotalIVA21 + facH.TotalIIBB).ToString("C2");
                txtDescuento.Text = facH.DescuentoPorc.Value.ToString("P2");
                txtImporteProductosFact.Text = (facH.TotalFacturaB - facH.Descuento).Value.ToString("C2");
                txtImporteProdFactUsd.Text =
                    ((facH.TotalFacturaB - facH.Descuento) / facH.TC).Value.ToString("C2");
                T401itemBs.DataSource = new T400Manager().GetDocumentItems(record.IdFactura.Value);
                if (facH.IdCtaCte != null)
                {
                    t207CobranzaBs.DataSource = new CobranzaUtils()
                        .GetListaImputacionPorCtaCteFactura(facH.IdCtaCte.Value).ToList();
                    var dataCtaCte = new CtaCteCustomer(record.IdCliente).GetRegistro201(facH.IdCtaCte.Value);
                    decimal pago = dataCtaCte.IMPORTE_ARS - dataCtaCte.SALDOFACTURA;
                    decimal impago = dataCtaCte.SALDOFACTURA;
                    txtImporteImpago.Text = impago.ToString("C2");
                    txtImportePago.Text = pago.ToString("C2");

                }
            }

            txtMaterial.Text = record.Material;
            txtMaterialDescripcion.Text = MaterialMasterManager.GetSpecificPrimaryInformation(txtMaterial.Text)
                .DescripcionTecnicaLab;
            txtLx.Text = record.TipoLX;
            txtCantidad.Text = record.Cantidad.ToString();
            txtMon1.Text = txtMon2.Text = record.MonCosto;
            txtPrecioU.Text = record.PrecioU.ToString("C2");
            txtPrecioTotal.Text = record.PrecioTotal.ToString("C2");
            //
            txtCrMfg.SetValue = record.CostoMfg;
            txtCrEstadistico.SetValue = record.CostoStadistico;
            txtCrAdd1.SetValue = record.CostoUAdd;
            txtCrAdcTot.SetValue = record.CostoTotalAdd;
            txtCrCostoTot.Text = record.CostoTotal.ToString("C2");
            costoTotalUnitario = +record.CostoMfg + record.CostoStadistico + record.CostoUAdd +
                                 (record.CostoTotalAdd / record.Cantidad);


            //
            decimal factuTotal = record.Cantidad * record.PrecioU;
            txtMPrecioFactu.Text = factuTotal.ToString("C2");
            txtMCmvTotal.Text = (costoTotalUnitario * record.Cantidad).ToString("C2");
            txtMVenta.Text = (factuTotal - (costoTotalUnitario * record.Cantidad)).ToString("C2");
            txtPorcCobrado.Text = record.PorcentajeCobrado.ToString("P2");
            txtImpCobrado.Text = record.PrecioCobradoTotal.ToString("C2");
            txtMReal.Text = (record.PrecioCobradoTotal - (costoTotalUnitario * record.Cantidad)).ToString("C2");
            //var varTR = (1 - (record.PrecioCobradoTotal / factuTotal)).ToString("P3");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }


        private void txtCrAdd1_Validated(object sender, EventArgs e)
        {
            decimal cantidad = Convert.ToDecimal(txtCantidad.Text);
            costoTotalUnitario = txtCrAdd1.GetValueDecimal + txtCrMfg.GetValueDecimal +
                                 txtCrEstadistico.GetValueDecimal +
                                 (txtCrAdcTot.GetValueDecimal / FormatAndConversions.CCurrencyADecimal(txtCantidad.Text));

            txtCrCostoTot.Text = costoTotalUnitario.ToString("C3");
            txtMCmvTotal.Text = (costoTotalUnitario * cantidad).ToString("C2");
            txtMVenta.Text = (FormatAndConversions.CCurrencyADecimal(txtMPrecioFactu.Text) - (costoTotalUnitario * cantidad)).ToString("C2");
            txtMReal.Text = (FormatAndConversions.CCurrencyADecimal(txtImpCobrado.Text) - FormatAndConversions.CCurrencyADecimal(txtMCmvTotal.Text)).ToString("C2");
            var varTR = (1 - (FormatAndConversions.CCurrencyADecimal(txtImpCobrado.Text) / FormatAndConversions.CCurrencyADecimal(txtMPrecioFactu.Text))).ToString("P3");

        }
    }
}
