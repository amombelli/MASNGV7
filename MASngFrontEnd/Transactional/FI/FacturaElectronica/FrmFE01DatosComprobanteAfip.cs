using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.FacturaElectronica
{
    public partial class FrmFE01DatosComprobanteAfip : Form
    {
        public FrmFE01DatosComprobanteAfip(int modo = 0)
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BlanueaData()
        {
            txtAuthServer.Text = @"-";
            txtAPPServer.Text = @"-";
            txtDbServer.Text = @"-";
            txtCuit1.Text = null;
            txtImporteT1.Text = null;
            txtImporteT2.Text = null;
            txtDescT1.Text = null;
            txtDescT2.Text = null;
            txtAlic1.Text = null;
            txtAlic2.Text = null;
            txtBaseI1.Text = null;
            txtBaseI2.Text = null;
            txtIva.Text = null;
            txtCae.Text = null;
            txtFechaVencimientoCAE.Text = null;
            txtRazonSocial.Text = null;
            txtFechaDoc.Text = null;
            txtImporte.Text = null;
            pCodigoBarraCAE.Image = null;

        }


        private void btnUltimosComprobantes_Click(object sender, EventArgs e)
        {
            if (cmbTipoComprobante.SelectedItem == null)
            {
                MessageBox.Show(@"Debe un tipo de Documento Valido", @"Datos Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtSuc.Text))
            {
                MessageBox.Show(@"Debe proveer una Sucursal/Punto de Venta valido (ejemplo: 4)",
                    @"Error en Punto de Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtDocumento.Text))
            {
                MessageBox.Show(@"Debe proveer un numero de comprobnte",
                    @"Error en numero de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var modoEjecucion = ckProduccion.Checked ? ModoEjecucion.Produccion : ModoEjecucion.Testeo;
            var fe = new FacturaElectronicaWs(modoEjecucion);
            var tipoComprobante = new TipoComprobante();
            switch (cmbTipoComprobante.SelectedItem.ToString())
            {
                case "FA":
                    tipoComprobante = TipoComprobante.Factura;
                    break;
                case "NC":
                    tipoComprobante = TipoComprobante.NotaCredito;
                    break;
                case "ND":
                    tipoComprobante = TipoComprobante.NotaDebito;
                    break;
                default:
                    MessageBox.Show(@"El Tipo de Comprobante es incorrecto!", @"Tipo de Comprobante Erroneo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            BlanueaData();
            var r = fe.ObtieneDatosComprobanteAFIP(tipoComprobante, Convert.ToInt32(txtSuc.Text),
                Convert.ToInt32(txtDocumento.Text));

            txtAPPServer.Text = fe.StatusServerApp;
            txtDbServer.Text = fe.StatusServerDb;
            txtAuthServer.Text = fe.StatusServerAuth;

            if (fe.StatusServerApp != "OK")
            {
                MessageBox.Show(@"No se puede obtener la informacion porque no se pudo conectar con el server AFIP",
                    @"Error Server APP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            txtCae.Text = r.CAE;
            txtCuit1.Text = r.DocNumero;
            txtFechaVencimientoCAE.Text = r.VencimientoCAE.ToString("d");

            txtImporte.Text = r.ImporteTotal.ToString("C2");
            txtIva.Text = r.ImporteIva.ToString("C2");
            txtFechaDoc.Text = r.FechaComprobante.ToString("d");
            txtRazonSocial.Text = new TecserData(GlobalApp.CnnApp).T0006_MCLIENTES.Where(c => c.CUIT == txtCuit1.Text).ToList()[0].cli_rsocial;
            if (r.TributosDetalle.Count > 0)
            {
                int i = 1;
                foreach (var trib in r.TributosDetalle)
                {
                    if (i == 1)
                    {
                        txtDescT1.Text = trib.Descripcion;
                        txtImporteT1.Text = trib.Importe;
                        txtAlic1.Text = trib.Alicuota;
                        txtBaseI1.Text = trib.BaseImponible;
                    }
                    if (i == 2)
                    {
                        txtDescT2.Text = trib.Descripcion;
                        txtImporteT2.Text = trib.Importe;
                        txtAlic2.Text = trib.Alicuota;
                        txtBaseI2.Text = trib.BaseImponible;
                    }
                    if (i == 3)
                    {
                        MessageBox.Show(@"Existen mas tributos pero no han sido cargados!", @"", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    i++;
                }
            }
            //
            DateTime fecha1 = Convert.ToDateTime(txtFechaVencimientoCAE.Text);
            string fechaAfip = fecha1.ToString("yyyyMMdd");
            string sucursal4 = txtSuc.Text.PadLeft(4, '0');
            string documento8 = txtDocumento.Text.PadLeft(8, '0');
            string pathBarra1 = AppDomain.CurrentDomain.BaseDirectory + @"Barras\" + sucursal4 + documento8;
            string pathBarra = @"c:\fe\pyaf\" + sucursal4 + documento8;
            new CodigoBarrasAfip().GeneraCodigoBarras("30709669091", tipoComprobante, sucursal4, txtCae.Text, fechaAfip,
                pathBarra1);

            //
            pCodigoBarraCAE.Image = Image.FromFile(pathBarra1 + ".png");
        }

        private void txtSuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
    }
}
