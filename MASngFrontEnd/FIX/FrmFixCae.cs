using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;
using WebServicesAFIP;

namespace MASngFE.FIX
{
    public partial class FrmFixCae : Form
    {
        public FrmFixCae()
        {
            InitializeComponent();
        }

        private int _idFactura = 0;

        private int _idRemito = 0;
        private void txtIdFactura_Leave(object sender, EventArgs e)
        {
            btnPedirCAE.Enabled = false;
            if (string.IsNullOrEmpty(txtIdFactura.Text))
            {
                BlanqueaDatos();
                return;
            }
            _idFactura = Convert.ToInt32(txtIdFactura.Text);
            MapeaDatosFactura();

        }
        private void BlanqueaDatos()
        {

            txtRazonSocial.Text = null;
            txtImporteNeto.Text = 0.ToString("C2");
            txtCAE.Text = null;
            txtTipoDoc.Text = null;
            txtTipoOp.Text = null;
            txtidCliente.Text = null;
            txtEstadoDocumento.Text = null;
            dtpFecha.Value = DateTime.Today;
            btnPedirCAE.Enabled = false;
        }
        private void MapeaDatosFactura()
        {
            if (_idFactura == 0)
                return;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _idFactura);
                if (x == null)
                {
                    MessageBox.Show(@"La Factura no existe");
                    return;
                }

                if (txtTipoDoc.Text == @"FA")
                {
                    txtIdRemito.Text = x.IDRemito.ToString();
                    _idRemito = x.IDRemito.Value;
                }

                txtRazonSocial.Text = x.RAZONSOC;
                txtImporteNeto.Text = x.TotalFacturaN.ToString("C2");
                txtCAE.Text = x.CAE;
                txtTipoDoc.Text = x.TIPO_DOC;
                txtTipoOp.Text = x.TIPOFACT;
                txtidCliente.Text = x.Cliente.ToString();
                txtEstadoDocumento.Text = x.StatusFactura;
                dtpFecha.Value = x.FECHA;

                if (x.TIPOFACT == "L1" && string.IsNullOrEmpty(txtCAE.Text))
                {
                    btnPedirCAE.Enabled = true;
                }
            }
        }
        private void FrmFixCae_Load(object sender, EventArgs e)
        {
            btnPedirCAE.Enabled = false;
        }
        private void btnPedirCAE_Click(object sender, EventArgs e)
        {
            FacturacionElectronicaTecser fe;
            if (ckAFIP.Checked)
            {
                fe = new FacturacionElectronicaTecser(ModoEjecucion.Testeo);
            }
            else
            {
                fe = new FacturacionElectronicaTecser(ModoEjecucion.Produccion);
            }


            Cursor.Current = Cursors.WaitCursor;
            if (fe.CheckSiPermiteSolicitarCAE(_idFactura))
            {
                var dr =
                    MessageBox.Show(string.Format(
                        "Confirma que desea SOLICITAR CAE a AFIP para el documento contabilizado por IMPORTE {0}",
                        txtImporteNeto.Text), @"SOLICITUD DE CAE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                    return;
            }
            else
            {
                MessageBox.Show(@"El Documento NO SE Encuentra en condiciones de solicitar CAE",
                    @"Fallo de Condiciones para Pedir CAE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resultado = fe.SolicitudCAEFromT0400(_idFactura,null,null,null);
            Cursor.Current = Cursors.Default;
            if (resultado.Resultado == "A")
            {
                txtResultadoAFIP.Text = resultado.Resultado;
                txtCAE.Text = resultado.CAE;
                txtCAEVencimiento.Text = resultado.VencimientoCAE.ToString("d");
                txtNumeroDocumento.Text = resultado.PuntoVenta.PadLeft(4, '0') + @"-" +
                                          resultado.ComprobanteHasta.PadLeft(8, '0');
                fe.UpdateDataAfterDocumentNumberGetFromAFIP(_idFactura, resultado.PuntoVenta.PadLeft(4, '0'),
                    resultado.ComprobanteHasta.PadLeft(8, '0'), resultado.CAE, resultado.VencimientoCAE, Convert.ToInt32(txtNas.Text));
                new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _idFactura, txtNumeroDocumento.Text, false);
            }
            else
            {
                txtResultadoAFIP.Text = resultado.Resultado;
                MessageBox.Show(@"Ha Ocurrido un error al solicitar el CAE", @"Error en SOLICITUD DE CAE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnPedirCAE.Enabled = false;
        }
        private void txtIdRemito_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtIdFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtIdRemito_Leave(object sender, EventArgs e)
        {
            btnPedirCAE.Enabled = false;

            if (string.IsNullOrEmpty(txtIdRemito.Text))
            {
                _idRemito = 0;
                BlanqueaDatos();
                return;
            }

            _idRemito = Convert.ToInt32(txtIdRemito.Text);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == _idRemito);
                if (r == null)
                {
                    _idFactura = 0;
                    MessageBox.Show(@"El IDREMITO no Existe", @"Error en Datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (r.Factura == null)
                {
                    _idFactura = 0;
                    MessageBox.Show(@"El Remito no posee una Factura Asociada. No se puede continuar", @"Error en Datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                _idFactura = r.Factura.Value;
                MapeaDatosFactura();

            }
        }
        private void btnFixStatus_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show(@"Confirma pasar el documento a estado PENDIENTECAE?", @"CAMBIO DE ESTADO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (x == DialogResult.No)
                return;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var z = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _idFactura);
                z.StatusFactura = DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString();
                db.SaveChanges();
                txtEstadoDocumento.Text = DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString();
            }
        }
        private void ckAFIP_CheckedChanged(object sender, EventArgs e)
        {
            ckAFIP.BackColor = ckAFIP.Checked ? Color.Red : Color.Transparent;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimirDocumento_Click(object sender, EventArgs e)
        {
            //if (txtTipoOp.Text == @"L1")
            //{
            //    if (ckPreImpreso.Checked)
            //    {
            //        var f = new RpvFacturaL1(_idFactura, false, "", true);
            //        f.Show();
            //    }
            //    else
            //    {
            //        var f = new RpvFacturaL1_PDF(_facturaIdStruct.IdFactura, ckImprimirMensajeMora.Checked, txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked);
            //        f.Show();
            //    }
            //}
            //else
            //{
            //    var f = new RpvFacturaL2(_facturaIdStruct.IdFactura, ckSaldoTotalAdeudadoL2.Checked, ckImpresionConsolidada.Checked);
            //    f.Show();
            //}
        }
    }
}
