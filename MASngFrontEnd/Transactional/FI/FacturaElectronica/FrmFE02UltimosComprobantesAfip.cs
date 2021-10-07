using System;
using System.Windows.Forms;
using Tecser.Business.Tools;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.FacturaElectronica
{
    public partial class FrmFE02UltimosComprobantesAfip : Form
    {
        public FrmFE02UltimosComprobantesAfip(int x = 0)
        {
            InitializeComponent();
        }

        private void btnUltimosComprobantes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPuntoVenta.Text))
            {
                MessageBox.Show(@"Debe completar el punto de venta (ejemplo = 4", @"Faltante de Punto de Venta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var modoEjecucion = ckProduccion.Checked ? ModoEjecucion.Produccion : ModoEjecucion.Testeo;
            var fe = new FacturaElectronicaWs(modoEjecucion);
            fe.SoloConnectToCheck(new WsaaManagement(modoEjecucion));
            txtAPPServer.Text = fe.StatusServerApp;
            txtDbServer.Text = fe.StatusServerDb;
            txtAuthServer.Text = fe.StatusServerAuth;

            if (fe.StatusServerApp == "OK")
            {
                var resultado = fe.ObtieneUltimosComprobantesAFIP(Convert.ToInt32(txtPuntoVenta.Text));
                txtUltimaFactura.Text = resultado.UltimaFactura.ToString();
                txtUltimaNC.Text = resultado.UltimaNotaCredito.ToString();
                txtUltimaND.Text = resultado.UltimaNotaDebito.ToString();
            }
            //afip.ObtieneDatosComprobanteAFIP(TipoComprobante.Factura,4,11369);
        }


        private void txtPuntoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
