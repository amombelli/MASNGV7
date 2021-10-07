using System;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using MASngFE.Transactional.FI.Cobranza;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.Customers;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;
using Tecser.Business.Transactional.SD;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.Factura
{
    public partial class FrmFI50DetalleDocumentoFI : Form
    {
        public FrmFI50DetalleDocumentoFI(int idFactura, int modo = 0)
        {
            _idFactura = idFactura;
            InitializeComponent();
        }

        private readonly int _idFactura;
        private int _idFacturaX;
        private int _idCliente;
        private ManageDocumentType.TipoDocumento _tipoDocumento;
        private string _tipoLx;
        private DocumentFIStatusManager.StatusHeader _estadoDocumento;
        ModoEjecucion modoAfip;
        private int? _idRemito;

        private void FrmDetalleDocumentoFI_Load(object sender, EventArgs e)
        {
            modoAfip = GlobalApp.Modo == ModoApp.Produccion ? ModoEjecucion.Produccion : ModoEjecucion.Testeo;
            LoadHeaderData();
            AccionEstadoDocumento();
        }

        private void AccionEstadoDocumento()
        {
            if (_estadoDocumento == DocumentFIStatusManager.StatusHeader.PendienteCAE)
            {
                btnSolicitarCAE1.Enabled = true;
            }
            else
            {
                btnSolicitarCAE1.Enabled = false;
            }
        }
        private void LoadHeaderData()
        {
            var h = new CustomerDocumentSearch().GetHeaderData(_idFactura);
            _idFacturaX = h.IDFACTURAX.Value;
            var cli = new CustomerManager().GetCustomerBillToData(h.Cliente);
            ckVerPreciosOV.Checked = true;
            ckVerGLAccount.Checked = false;
            ckFacturaAlter.Checked = false;
            txtRazonSocial.Text = h.RAZONSOC;
            txtFantasia.Text = cli.cli_fantasia;
            _idCliente = cli.IDCLIENTE;
            txtId6.Text = cli.IDCLIENTE.ToString();
            txtNumeroCuit.Text = cli.CUIT;
            txtDireccion.Text = cli.Direccion_facturacion;
            txtLocalidad.Text = cli.Direfactu_Localidad;
            txtProvincia.Text = cli.Direfactu_Provincia;
            txtMon.Text = h.FacturaMoneda;
            txtImporteTotal.Text = h.TotalFacturaN.ToString("c2");
            txtEstado.Text = h.StatusFactura;
            _estadoDocumento = new DocumentFIStatusManager().MapStatusHeaderFromText(h.StatusFactura);
            txtLx.Text = h.TIPOFACT;
            txtTC.Text = h.TC.ToString("N2");
            txtNumeroDocumento.Text = h.NumeroDoc;
            txtNumeroRemito.Text = h.Remito;

            if (h.TC != 0)
            {
                if (h.FacturaMoneda == "ARS")
                {
                    txtImporteUSD.Text = (h.TotalFacturaB / h.TC).ToString("C2");
                    pRECIOTFACTUSDDataGridViewTextBoxColumn.Visible = false;
                    pRECIOUFACTUSDDataGridViewTextBoxColumn.Visible = false;
                    pRECIOTFACTARSDataGridViewTextBoxColumn.Visible = true;
                    pRECIOUFACTARSDataGridViewTextBoxColumn.Visible = true;
                }
                else
                {
                    txtImporteUSD.Text = h.TotalFacturaN.ToString("C2");
                    pRECIOTFACTUSDDataGridViewTextBoxColumn.Visible = true;
                    pRECIOUFACTUSDDataGridViewTextBoxColumn.Visible = true;
                    pRECIOTFACTARSDataGridViewTextBoxColumn.Visible = false;
                    pRECIOUFACTARSDataGridViewTextBoxColumn.Visible = false;
                }
            }

            dtpFecha.Value = h.FECHA;
            _tipoDocumento = ManageDocumentType.GetTipoDocumentoFromTdocString(h.TIPO_DOC, h.TIPOFACT);
            txtTipoDoc.Text = ManageDocumentType.GetDocumentDescriptionHardCode(_tipoDocumento);
            _tipoLx = h.TIPOFACT;

            if (h.TIPOFACT == "L1")
            {
                ckImprimirSaldoL2.Enabled = false;
            }
            else
            {
                ckImprimirSaldoL2.Enabled = true;
                ckImprimirSaldoL2.Checked = true;
            }

            gLIDataGridViewTextBoxColumn.Visible = false;
            gLVDataGridViewTextBoxColumn.Visible = false;

            t0401FACTURAIBindingSource.DataSource = new CustomerDocumentSearch().GetItemData(_idFactura);
            dgvItems.ClearSelection();

            txtImporteInicial.Text = h.TotalFacturaB.ToString("C2");
            txtImporteDescuento.Text = h.Descuento.Value.ToString("C2");

            if (h.Descuento.Value > 0)
            {
                txtDescuentoPorcentaje.Text = (h.Descuento.Value / h.TotalFacturaB).ToString("P2");
            }

            txtSubtotal.Text = (h.TotalFacturaB - h.Descuento.Value).ToString("C2");
            txtBaseImponible.Text = h.TotalImpo.ToString("C2");
            txtIva21.Text = h.TotalIVA21.ToString("C2");
            txtImporteIIBB.Text = h.TotalIIBB.ToString("C2");
            txtTotalFactura.Text = h.TotalFacturaN.ToString("C2");

            if (h.IIBB_PORC == null)
            {
                txtAlicuotaIIBB.Text = 0.ToString("P2");
            }
            else
            {
                txtAlicuotaIIBB.Text = h.IIBB_PORC.Value.ToString("P2");
            }

            if (h.IdCtaCte == null)
            {
                MessageBox.Show(@"Este Documento no tiene IdCtaCte en T0400!", @"Arreglar");
                return;
            }

            txtCAE.Text = h.CAE;
            if (h.CAE_VTO != null)
                txtCAEVencimiento.Text = h.CAE_VTO.Value.ToString("d");
            txtZterm.Text = h.ZTERM;
            //
            var ctacteData = new CobranzaImputacion();
            var sinImpu = ctacteData.GetSaldoAImputar208(h.Cliente, h.TIPOFACT);
            var pendPago = ctacteData.GetSaldoImpago(h.IdCtaCte.Value);
            txtMontoSinImputar.Text = sinImpu.ToString("C2");
            txtSaldoImpago.Text = pendPago.ToString("C2");

            if (sinImpu > 0 && pendPago > 0)
            {
                btnImputar.Enabled = true;
            }
            else
            {
                btnImputar.Enabled = false;
            }
            txtNAS.Text = h.NAS.ToString();
            _idRemito = h.IDRemito;

            var info = new CobranzaUtils().GetInfoDiasPPFromTable201(h.IdCtaCte.Value);
            if (info.DiasPP_FacturaRecibo == null || info.DiasPP_ReciboPago == null)
            {
                var diasPP = new CobranzaUtils().DiasPromedioPagoFacturaImputada(h.IdCtaCte.Value);
                txtDiasPPFactura.Text = diasPP.DiasPP_FacturaRecibo.ToString();
                txtDiasPPRecibo.Text = diasPP.DiasPP_ReciboPago.ToString();
                txtDiasPPTotal.Text = (diasPP.DiasPP_FacturaRecibo + diasPP.DiasPP_ReciboPago).ToString();
                new CobranzaUtils().SetInfoDiasPPToTable201(h.IdCtaCte.Value, diasPP.DiasPP_FacturaRecibo,
                    diasPP.DiasPP_ReciboPago);
            }
            else
            {
                txtDiasPPFactura.Text = info.DiasPP_FacturaRecibo.ToString();
                txtDiasPPRecibo.Text = info.DiasPP_ReciboPago.ToString();
                txtDiasPPTotal.Text = (info.DiasPP_FacturaRecibo + info.DiasPP_ReciboPago).ToString();
            }
        }

        private void ckVerGLAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVerGLAccount.Checked)
            {
                gLIDataGridViewTextBoxColumn.Visible = true;
                gLVDataGridViewTextBoxColumn.Visible = true;
            }
            else
            {
                gLIDataGridViewTextBoxColumn.Visible = false;
                gLVDataGridViewTextBoxColumn.Visible = false;
            }
        }

        private void ckVerPreciosOV_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVerPreciosOV.Checked)
            {
                pRECIOUCOTIZDataGridViewTextBoxColumn.Visible = true;
                mONEDACOTIZDataGridViewTextBoxColumn.Visible = true;
            }
            else
            {
                pRECIOUCOTIZDataGridViewTextBoxColumn.Visible = false;
                mONEDACOTIZDataGridViewTextBoxColumn.Visible = false;
            }
        }

        private void ckFacturaAlter_CheckedChanged(object sender, EventArgs e)
        {
            if (ckFacturaAlter.Checked)
            {
                if (txtMon.Text == @"ARS")
                {
                    pRECIOTFACTUSDDataGridViewTextBoxColumn.Visible = true;
                    pRECIOUFACTUSDDataGridViewTextBoxColumn.Visible = true;
                }
                else
                {
                    pRECIOTFACTARSDataGridViewTextBoxColumn.Visible = true;
                    pRECIOUFACTARSDataGridViewTextBoxColumn.Visible = true;
                }
            }
            else
            {
                if (txtMon.Text == @"ARS")
                {
                    pRECIOTFACTUSDDataGridViewTextBoxColumn.Visible = false;
                    pRECIOUFACTUSDDataGridViewTextBoxColumn.Visible = false;
                }
                else
                {
                    pRECIOTFACTARSDataGridViewTextBoxColumn.Visible = false;
                    pRECIOUFACTARSDataGridViewTextBoxColumn.Visible = false;
                }
            }
        }

        private bool CheckAllowToPrint()
        {
            return true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!CheckAllowToPrint())
                return;

            if (txtLx.Text == @"L1")
            {
                if (ckPreimpreso.Checked)
                {
                    var f = new RpvFacturaL1(_idFactura, ckMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked, ckCodBarra.Checked);
                    f.Show();
                }
                else
                {
                    var f = new RpvFacturaL1_PDF(_idFactura, ckMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked, ckCodBarra.Checked);
                    f.Show();
                }
            }
            else
            {
                var f = new RpvNcdl2(_idFactura, ckImprimirSaldoL2.Checked,
                    ckImpresionConsolidada.Checked);
                f.Show();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImputar_Click(object sender, EventArgs e)
        {
            var f0 = new FrmImputacionCobranzas(_idCliente);
            f0.ShowDialog();
        }

        private void btnVerImputacion_Click(object sender, EventArgs e)
        {
            var f0 = new FrmFI45DetalleImputacionFactura(_idFactura);
            f0.ShowDialog();
        }


        private bool ValidaCancelacion()
        {
            if (_estadoDocumento == DocumentFIStatusManager.StatusHeader.Aprobada && _tipoLx == "L1")
            {
                MessageBox.Show(@"El Documento se encuentra con CAE generado. No se puede CANCELAR", @"Accion No Permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_tipoLx == "L1")
            {

            }
            else
            {

            }
            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!CheckAllowToPrint())
                return;

            if (txtLx.Text == @"L1")
            {
                if (ckPreimpreso.Checked)
                {
                    var f = new RpvFacturaL1(_idFactura, ckMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked, ckCodBarra.Checked);
                    f.Show();
                }
                else
                {
                    var f = new RpvFacturaL1_PDF(_idFactura, ckMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked, ckCodBarra.Checked);
                    f.Show();
                }
            }
            else
            {
                var f = new RpvNcdl2(_idFactura, ckImprimirSaldoL2.Checked,
                    ckImpresionConsolidada.Checked);
                f.Show();
            }
        }

        private void btnCancelDoc_Click(object sender, EventArgs e)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("FAC2", "CANCELDOC", true, true))
            {
                MessageBox.Show(@"El Usuario no esta habilitado para cancelar un documento", @"Permisos Insuficientes",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


            if (!ValidaCancelacion())
                return;

            var resp = MessageBox.Show(@"Confirma la Cancelacion del Documento?",
                @"Cancelacion de Documentos Contabilizados",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            var resultado = new CustomerInvoice("FAC2", 0).CancelaDocumentoFI(_idFactura);
            if (resultado)
                MessageBox.Show(@"Se ha Anulado Correctamente el Documento", @"Anulacion Exitosa", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }


        private void btnSolicitarCAE1_Click(object sender, EventArgs e)
        {
            if (new FacturacionElectronicaTecser(modoAfip).CheckSiPermiteSolicitarCAE(_idFactura) == false)
            {
                MessageBox.Show(
                    @"El Documento no se encuentra en condiciones de solicitar CAE" + Environment.NewLine +
                    @"El Documento no esta en estado 'PendienteCAE'",
                    @"Solicitud de CAE *No Permitida*", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(
                    $@"Confirma la Solicitud de CAE a AFIP para el documento contabilizado por IMPORTE $ {txtTotalFactura.Text}",
                    @"Confirmar Solicitud de CAE ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.No)
                return;

            if (modoAfip == ModoEjecucion.Testeo)
            {
                MessageBox.Show(
                    @"Atencion se esta ejecutando la aplicacion en modo TESTEO" + Environment.NewLine +
                    @"El CAE otorgado NO SERA VALIDO",
                    @"Modo Aplicacion = * TESTEO *", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            SolicitudCAE();
        }
        private void SolicitudCAE()
        {
            FEGetDataStructure resultado;
            var fe = new FacturacionElectronicaTecser(modoAfip);
            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA)
            {
                //por dispoicion AFIP se debe proveer o ID Factura Anula o Periodo Asociado
                var dataNcd = new CustomerNc(CustomerNc.MotivoNotaCredito.SinMotivo).GetT0300HeaderFromIDFactura400(_idFactura);
                if (dataNcd != null)
                {
                    resultado = fe.SolicitudCAEFromT0400(_idFactura, dataNcd.idFacturaAsociada, dataNcd.PeriodoAjusteDesde, dataNcd.PeriodoAjusteHasta);
                }
                else
                {
                    //por cambio en RG AFIP esta proxima linea no funcionara porque necesita comprobante asociado
                    resultado = fe.SolicitudCAEFromT0400(_idFactura, null, null, null);
                }
            }
            else
            {
                resultado = fe.SolicitudCAEFromT0400(_idFactura, null, null, null);
            }
            
            if (resultado.Resultado == "A")
            {
                txtCAE.Text = resultado.CAE;
                txtCAEVencimiento.Text = resultado.VencimientoCAE.ToString("d");
                txtNumeroDocumento.Text = resultado.NumeroDocumentoOtorgadoCompleto;

                fe.UpdateDataAfterDocumentNumberGetFromAFIP(_idFactura, resultado.PuntoVenta,
                    resultado.ComprobanteHasta, resultado.CAE,
                    resultado.VencimientoCAE, Convert.ToInt32(txtNAS.Text));

                if (_idRemito != null)
                {
                    new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito.Value, _idFactura,
                    txtNumeroDocumento.Text, false);
                }
                //revisar desde aca hasta abajo
                if (_tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA ||
                    _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVenta2 ||
                    _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA ||
                    _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVenta2 ||
                    _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoClientesM ||
                    _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoClientesB ||
                    _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoClientesB ||
                    _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoClientesM)
                {
                    //Se trata de una NC/ND
                    //obtener el idh desde t0300 con el idfactura
                    var idHNC = new NcdTableManager().GetIdNCDFromIdFactura(_idFactura);
                    if (idHNC > 0)
                        new NcdTableManager().UpdateOnlyDocumentNumber(idHNC, txtNumeroDocumento.Text);
                }

                if (string.IsNullOrEmpty(txtImporteIIBB.Text))
                    txtImporteIIBB.Text = 0.ToString("C2");

                if (FormatAndConversions.CCurrencyADecimal(txtImporteIIBB.Text) != 0)
                {
                    new PercepcionesManager().AddFacturaPercepcion(_idFacturaX);
                }
                _estadoDocumento = DocumentFIStatusManager.StatusHeader.Aprobada;
                txtEstado.Text = _estadoDocumento.ToString();
                txtEstado.BackColor = Color.ForestGreen;
                AccionEstadoDocumento();
            }
            else
            {
                MessageBox.Show(@"Ha Ocurrido un error al solicitar el CAE", @"Error en SOLICITUD DE CAE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AccionEstadoDocumento();
        }
    }

}