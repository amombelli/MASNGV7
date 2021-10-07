using System;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;
using TecserEF.Entity;
using TSControls;
using WebServicesAFIP;
using Environment = System.Environment;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MASngFE.Transactional.FI.GestionCheques
{
    public partial class FrmChr2 : Form
    {
        private int _idTracker;
        private readonly int _idCheque;
        private readonly FrmCrh.AccionCheque _accion;
        private TipoDoc _tipoDocumentoGenerar;
        private string _descripcionItemCheque = null;
        private readonly T0154_CHEQUES _datosCheque;
        private int _idCliente;
        private string _glCheque;
        private NotaCreditoDebitoCustomer _zdoc2;  //Se inicializa al crear el primer item
        private NotaCreditoDebitoCustomer _zdoc1;  //Se inicializa al crear el primer item
        //*************************************************************************************************************************
        private enum TipoDoc
        {
            NoSeleccionado,
            NotaDebito,
            DocumentoX,
            Ambos
        };
        
        public FrmChr2(int idCheque, FrmCrh.AccionCheque accion)
        {
            _idCheque = idCheque;
            _accion = accion;
            _datosCheque = new ChequesManager().GetCheque(_idCheque);
            InitializeComponent();
        }
        private void FrmChr2_Load(object sender, EventArgs e)
        {
            //Determina Texto del Cheque
            txtStatusDoc1.Text = @"No Incializado";
            txtStatusDoc2.Text = @"No Incializado";
            txtStatusDoc1.BackColor = Color.LightGray;
            txtStatusDoc2.BackColor = Color.LightGray;
            panelBotones.BackColor = Color.DeepPink;
            panelGasto.BackColor = Color.Black;
            panelGasto.Enabled = false;
            btnAddGastos.Enabled = false;
            btnContabilizar.Enabled = false;
            btnSolicitarCae.Enabled = false;
            btnImprimir.Enabled = false;
            cFechaTransaccion.ObtieneTCAuto = true;
            cFechaTransaccion.Value = DateTime.Today;
            cTc.SetValue = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            lconta.BackColor =Color.White;
            lcae.BackColor=Color.White;
            limprimir.BackColor = Color.White;
            switch (_accion)
            {
                case FrmCrh.AccionCheque.NoSeleccionado:
                    break;
                case FrmCrh.AccionCheque.RetornoAClienteSr:
                    _descripcionItemCheque = $"Devolucion Cheque # {_datosCheque.CHE_NUMERO} - Bco {_datosCheque.T0160_BANCOS.BCO_SHORTDESC}";
                    _glCheque = "1.0.0.5";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            MapChequeData();
        }
        private void MapChequeData()
        {
            icono1Documento.Set = CIconos.TrianguloNaranja;
            _idCliente = _datosCheque.IdClienteRecibido.Value;
            var Cliente = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtClienteRs.Text = Cliente.cli_rsocial;
            txtIdCheque.Text = _idCheque.ToString();
            txtIdCliente.Text = _idCliente.ToString();
            txtLx.Text = _datosCheque.TIPO_REC;
            cChFechaRecibido.Value = _datosCheque.FECHA_RECIBIDO;
            cChFechaAcreditacion.Value = _datosCheque.CHE_FECHA;
            txtChBanco.Text = _datosCheque.T0160_BANCOS.BCO_SHORTDESC;
            cChImporte.SetValue = _datosCheque.IMPORTE.Value;

            if (txtLx.Text == @"L2")
            {
                btnNotaDebito.Enabled = false;
                btnDocumentoX.Enabled = false;
                panelGasto.BackColor= Color.White;
                btnAddGastos.Enabled = true;
                panelGasto.Enabled = true;
                icono1Documento.Set = CIconos.Tilde;
                _tipoDocumentoGenerar = TipoDoc.DocumentoX;
                InicializaChequeLista1();
                btnContabilizar.Enabled = true;
                lconta.BackColor = Color.GreenYellow;
            }
            else
            {
                //Puede ser cualquier opcion
                btnNotaDebito.Enabled = true;
                btnDocumentoX.Enabled = true;
                icono1Documento.Set = CIconos.TrianguloNaranja;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNotaDebito_Click(object sender, EventArgs e)
        {
            _tipoDocumentoGenerar = TipoDoc.NotaDebito;
            SeleccionDocumentoOk();
        }
        private void btnDocumentoX_Click(object sender, EventArgs e)
        {
            _tipoDocumentoGenerar = TipoDoc.DocumentoX;
            SeleccionDocumentoOk();
        }
        private void SeleccionDocumentoOk()
        {
            //Creacion de documento por seleccion por boton.
            btnNotaDebito.Enabled = false;
            btnDocumentoX.Enabled = false;
            icono1Documento.Set = CIconos.Tilde;
            if (_tipoDocumentoGenerar == TipoDoc.NotaDebito)
            {
                InicializaChequeLista2();  //ND
                btnContabilizar.Enabled = true;
                lconta.BackColor = Color.GreenYellow;
            }
            else
            {
                InicializaChequeLista1(); //Dccumento X
                btnContabilizar.Enabled = true;
                btnSolicitarCae.Enabled = false;
                lconta.BackColor = Color.GreenYellow;
            }
            panelGasto.BackColor = Color.White;
            btnAddGastos.Enabled = true;
            panelGasto.Enabled = true;
        }
        private void InicializaChequeLista1()
        {
            //Documento X (L1 o L2)
            txtStatusDoc1.Text = @"En Proceso";
            txtStatusDoc1.BackColor = Color.LightGreen;
            if (_zdoc1 == null)
            {
                _zdoc1 = new NotaCreditoDebitoCustomer();
                _zdoc1.CreaHeaderMemory(NotaCreditoDebitoCustomer.TipoDoc.DocumentoX, _zdoc1.MapLxFromString(txtLx.Text), _idCliente, cFechaTransaccion.Value.Value, txtMotivoDevolucion.Text);
            }
            _zdoc1.AddItemMemory(1, "ZCHRECH", _descripcionItemCheque, _datosCheque.IMPORTE.Value, false, _glCheque, _idCliente);
            MapeaTotales();
        }
        private void InicializaChequeLista2()
        {
            //Nota Debito L1
            txtStatusDoc2.Text = @"En Proceso";
            txtStatusDoc2.BackColor = Color.LightGreen;
            if (_zdoc2 == null)
            {
                _zdoc2 = new NotaCreditoDebitoCustomer();
                _zdoc2.CreaHeaderMemory(NotaCreditoDebitoCustomer.TipoDoc.NotaDebito, _zdoc2.MapLxFromString(txtLx.Text), _idCliente, cFechaTransaccion.Value.Value, txtMotivoDevolucion.Text);
            }
            _zdoc2.AddItemMemory(1, "ZCHRECH", _descripcionItemCheque, _datosCheque.IMPORTE.Value, false, _glCheque, _idCliente);
            MapeaTotales();
        }
        private void MapeaTotales()
        {
            if (_zdoc1 != null)
            {
                var h = _zdoc1.GetHeader();
                if (h.MON == "ARS")
                {
                    cImporteBruto1.SetValue = _zdoc1.ImporteARS - _zdoc1.ImporteIVA;
                    cImporteTotal1.SetValue = _zdoc1.ImporteARS;
                    cImporteIva1.SetValue = _zdoc1.ImporteIVA;
                }
                else
                {
                    cImporteBruto2.SetValue = _zdoc1.ImporteUSD - _zdoc1.ImporteIVA;
                    cImporteTotal2.SetValue = _zdoc1.ImporteUSD;
                    cImporteIva1.SetValue = _zdoc1.ImporteIVA;
                }
                dgvDoc1.DataSource = _zdoc1.GetItemList();
                txtNumDoc1.Text = h.NDOC;
                txtTdoc1.Text = h.TDOC;
            }

            if (_zdoc2 != null)
            {
                var h = _zdoc2.GetHeader();
                if (h.MON == "ARS")
                {
                    cImporteBruto2.SetValue = _zdoc2.ImporteARS - _zdoc2.ImporteIVA;
                    cImporteTotal2.SetValue = _zdoc2.ImporteARS;
                    cImporteIva2.SetValue = _zdoc2.ImporteIVA;
                }
                else
                {
                    cImporteBruto2.SetValue = _zdoc2.ImporteUSD - _zdoc2.ImporteIVA;
                    cImporteTotal2.SetValue = _zdoc2.ImporteUSD;
                    cImporteIva1.SetValue = _zdoc2.ImporteIVA;
                }
                dgvDoc2.DataSource = _zdoc2.GetItemList();
                txtNumDoc2.Text = h.NDOC;
                txtTdoc2.Text = h.TDOC;
            }
        }
        private void btnAddGastos_Click(object sender, EventArgs e)
        {
            if (!rb1GastoBancario.Checked && !rb1GastoFinanciero.Checked)
            {
                MessageBox.Show(@"Debe Seleccionar Tipo Gasto", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }

            if (cImporteAdd.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"El Importe del Gasto no puede ser $0.00", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtDescripcionAdd.Text))
            {
                MessageBox.Show(@"La Descripcion del Gasto/Concepto no puede ser nulo", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }

            if (txtLx.Text == @"L1")
            {
                if (_tipoDocumentoGenerar == TipoDoc.DocumentoX)
                {
                    var r = MessageBox.Show(
                        @"Desea continuar creando una Nota de Debito 'A' solo para los gastos + IVA?",
                        @"Gastos No Pueden ser creados en Documento X'", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.No)
                        return;
                    //Acepta crear los Gastos en Cuenta1 -
                    txtStatusDoc2.Text = @"En Proceso";
                    txtStatusDoc2.BackColor = Color.LightGreen;
                    _tipoDocumentoGenerar = TipoDoc.Ambos;
                }

                if (_zdoc2 == null)
                {
                    _zdoc2 = new NotaCreditoDebitoCustomer();
                    _zdoc2.CreaHeaderMemory(NotaCreditoDebitoCustomer.TipoDoc.NotaDebito,_zdoc2.MapLxFromString(txtLx.Text), _idCliente,cFechaTransaccion.Value.Value,txtMotivoDevolucion.Text);
                }
                _zdoc2.AddItemMemory(1, txtItemAdd.Text, txtDescripcionAdd.Text, cImporteAdd.GetValueDecimal, true,
                        txtGlAdd.Text, null);
            }
            else
            {
                //L2
                _zdoc1.AddItemMemory(1, txtItemAdd.Text, txtDescripcionAdd.Text, cImporteAdd.GetValueDecimal, false,
                    txtGlAdd.Text, null);
            }
            MapeaTotales();
        }
        private void rb1GastoBancario_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton) sender;
            if (rb.Checked==false)return;

            if (rb1GastoBancario.Checked)
            {
                txtDescripcionAdd.Text = @"Gastos Bancarios";
                txtItemAdd.Text = @"GSBAN";
                txtGlAdd.Text = @"4.5.2";
            }
            else
            {
                //Gastos Financiero
                txtDescripcionAdd.Text = @"Gastos Finacieros por Gestion Cheque";
                txtItemAdd.Text = @"GSBAN";
                txtGlAdd.Text = @"4.5.2";
            }
        }
        private void btnContabilizar_Click(object sender, EventArgs e)
        {
            if (!ValidaContaOK())
                return;
            RegistraOperacionTracker();
            if (_tipoDocumentoGenerar == TipoDoc.Ambos)
            {
                _zdoc2.AddPeriodoComprobanteAsociado(Convert.ToDateTime(cChFechaRecibido.Value.Value), Convert.ToDateTime(cChFechaRecibido.Value.Value));
                txtidncd1.Text = _zdoc1.SaveNewData().ToString();
                txtidncd2.Text = _zdoc2.SaveNewData().ToString();
                 var idF =_zdoc2.GenerateDocumentModuloFIRetornoCheque(); //solo si afecta a facturacion agrega documento en T400
                var idCtaCte1 = new CustomerNcdAjustes().UpdateCtaCteDesdeNCD(_zdoc1.GetHeader().IDH);
                var AsientoRtn1 = new AsientoGenerico("CHR").AsientoDevolucionChequeAClienteSr(_zdoc1.GetHeader().IDH);
                //
                var idCtaCte2 = new CustomerNcdAjustes().UpdateCtaCteDesdeNCD(_zdoc2.GetHeader().IDH);
                var AsientoRtn2 = new AsientoGenerico("CHR").AsientoDevolucionChequeAClienteSr(_zdoc2.GetHeader().IDH);
                //
                txtidctacte1.Text = idCtaCte1.ToString();
                txtidctacte2.Text = idCtaCte2.ToString();
                txtAsn1.Text = AsientoRtn1.IdDocu.ToString();
                txtAsn2.Text = AsientoRtn2.IdDocu.ToString();
                txtIdFactura.Text = idF.ToString();
                iconoStatusDoc2.Set = CIconos.Tilde;
                iconoStatusDoc1.Set = CIconos.Tilde;
                txtStatusDoc1.Text = @"Contabilizado";
                txtStatusDoc2.Text = @"Pendiente CAE";
                txtStatusDoc1.BackColor = Color.LimeGreen;
                txtStatusDoc2.BackColor = Color.Yellow;
                _zdoc1.UpdateDataAfterConta(txtMotivoDevolucion.Text, AsientoRtn1.IdDocu, idCtaCte1);
                _zdoc2.UpdateDataAfterConta(txtMotivoDevolucion.Text, AsientoRtn2.IdDocu, idCtaCte2);
                btnContabilizar.Enabled = false;
                btnSolicitarCae.Enabled = true;
                lconta.BackColor = Color.White;
                lcae.BackColor = Color.GreenYellow;
            }
            else
            {
                if (_tipoDocumentoGenerar == TipoDoc.NotaDebito)
                {
                    _zdoc2.AddPeriodoComprobanteAsociado(Convert.ToDateTime(cChFechaRecibido.Value.Value), Convert.ToDateTime(cChFechaRecibido.Value.Value));
                    txtidncd2.Text = _zdoc2.SaveNewData().ToString();
                    var idF=_zdoc2.GenerateDocumentModuloFIRetornoCheque(); //solo si afecta a facturacion agrega documento en T400

                    var idCtaCte2 = new CustomerNcdAjustes().UpdateCtaCteDesdeNCD(_zdoc2.GetHeader().IDH);
                    var AsientoRtn2 = new AsientoGenerico("CHR").AsientoDevolucionChequeAClienteSr(_zdoc2.GetHeader().IDH);
                    
                    txtidctacte2.Text = idCtaCte2.ToString();
                    txtAsn2.Text = AsientoRtn2.IdDocu.ToString();
                    txtIdFactura.Text = idF.ToString();
                    iconoStatusDoc2.Set = CIconos.Tilde;
                    txtStatusDoc2.Text = @"Pendiente CAE";
                    txtStatusDoc2.BackColor = Color.Yellow;
                    _zdoc2.UpdateDataAfterConta(txtMotivoDevolucion.Text, AsientoRtn2.IdDocu, idCtaCte2);
                    btnContabilizar.Enabled = false;
                    btnSolicitarCae.Enabled = true;
                    lconta.BackColor = Color.White;
                    lcae.BackColor = Color.GreenYellow;
                }
                else
                {
                    txtidncd1.Text = _zdoc1.SaveNewData().ToString(); //no vamos a mapear en T400 los documentos X
                    var idCtaCte1 = new CustomerNcdAjustes().UpdateCtaCteDesdeNCD(_zdoc1.GetHeader().IDH);
                    var AsientoRtn1 = new AsientoGenerico("CHR").AsientoDevolucionChequeAClienteSr(_zdoc1.GetHeader().IDH);
                    txtidctacte1.Text = idCtaCte1.ToString();
                    txtAsn1.Text = AsientoRtn1.IdDocu.ToString();
                    iconoStatusDoc1.Set = CIconos.Tilde;
                    txtStatusDoc1.Text = @"Contabilizado";
                    txtStatusDoc1.BackColor = Color.LimeGreen;
                    _zdoc1.UpdateDataAfterConta(txtMotivoDevolucion.Text, AsientoRtn1.IdDocu, idCtaCte1);
                    btnContabilizar.Enabled = false;
                    btnSolicitarCae.Enabled = false;
                    btnImprimir.Enabled = true;
                    lconta.BackColor = Color.White;
                    lcae.BackColor = Color.White;
                    limprimir.BackColor= Color.GreenYellow;
                }
            }
        }
        private void RegistraOperacionTracker()
        {
            string cuentaDestino = null;
            _idTracker = new ChequeRechazadoManager().AddChrTracker(_idCheque,_datosCheque.T0160_BANCOS.BCO_SHORTDESC
                , _datosCheque.IMPORTE.Value, "EnCartera", _datosCheque.IdClienteRecibido.ToString(), "RetornoCliente", cuentaDestino,
                "RetornoCliente", txtMotivoDevolucion.Text, "ND#");
            if (_idTracker < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Generar el Tracker del Cheque - Reintente Nuevamente",
                    @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new ChequeRechazadoManager().DeleteTracker(_idTracker);
                _idTracker = -1;
            }
            txtIdTracker.Text = _idTracker.ToString();
        }
        private bool ValidaContaOK()
        {
            if (_zdoc1 == null && _zdoc2 == null)
            {
                MessageBox.Show(@"No Hay Elementos/Items para Contabilizar", @"Sin Elementos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            bool flag = false;
            if (_zdoc1 != null)
            {
                if (_zdoc1.GetItemList().Count > 0)
                {
                    flag = true;
                }
                else
                {
                    _zdoc1 = null;
                }
            }

            if (_zdoc2 != null)
            {
                if (_zdoc2.GetItemList().Count > 0)
                {
                    flag = true;
                }
                else
                {
                    _zdoc2 = null;
                }
            }

            if (!flag)
            {
                MessageBox.Show(@"No Hay Elementos/Items para Contabilizar", @"Sin Elementos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (_tipoDocumentoGenerar == TipoDoc.Ambos)
            {
                if (_zdoc1 ==null || _zdoc2 == null)
                {
                    MessageBox.Show(@"Se ha Seleccionado Contabilizacion Mixta (ND+AX) pero una de las listas esta vacia o los importes son $0.00", @"Error en Listas", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                
                if (cImporteTotal1.GetValueDecimal == 0 || cImporteTotal2.GetValueDecimal==0)
                {
                    MessageBox.Show(@"Se ha Seleccionado Contabilizacion Mixta (ND+AX) pero una de las listas esta vacia o los importes son $0.00", @"Error en Listas", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (_tipoDocumentoGenerar == TipoDoc.DocumentoX)
            {
                if (_zdoc1 ==null)
                {
                    MessageBox.Show(@"La lista de Items Documento AX esta vacia", @"Error en Listas", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (cImporteTotal1.GetValueDecimal == 0)
                {
                    MessageBox.Show(@"Los Items de Documento AX tienen importe $0.00", @"Error en Listas", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (_tipoDocumentoGenerar == TipoDoc.NotaDebito)
            {
                if (_zdoc2 ==null)
                {
                    MessageBox.Show(@"La lista de Items Documento ND esta vacia", @"Error en Listas", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (cImporteTotal2.GetValueDecimal == 0)
                {
                    MessageBox.Show(@"Los Items de Documento ND tienen importe $0.00", @"Error en Listas", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtMotivoDevolucion.Text))
            {
                MessageBox.Show(@"Debe escribir el motivo de la devolucion del cheque al cliente", @"Faltan Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtMotivoDevolucion,"Complete la Informacion");
                return false;
            }
            errorProvider1.SetError(txtMotivoDevolucion, "");
            
            if (_tipoDocumentoGenerar == TipoDoc.Ambos)
            {
                var r = MessageBox.Show(@"Se van a Generar 2 Documentos" + Environment.NewLine +
                                        $@"Doc 'AX INTERNO' Importe ${cImporteTotal1.GetValueDecimal}" +
                                        Environment.NewLine +
                                        $@"Doc 'ND VVVAFIP' Importe ${cImporteTotal2.GetValueDecimal}" +
                                        Environment.NewLine +
                                        @"Confirma la Contabilizacion ?", @"Confirmacion de Documentos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return false;
            }

            if (_tipoDocumentoGenerar == TipoDoc.NotaDebito)
            {
                var r = MessageBox.Show(@"Se van a Generar 1 Documento Fiscal 'Nota de Debito" + Environment.NewLine +
                                        $@"ND 'A' Importe ${cImporteTotal2.GetValueDecimal}" + Environment.NewLine +
                                        @"Confirma la Contabilizacion ?", @"Confirmacion de Documentos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return false;


            }

            if (_tipoDocumentoGenerar == TipoDoc.DocumentoX)
            {
                var r = MessageBox.Show(@"Se van a Generar 1 Documento NO FISCAL" + Environment.NewLine +
                                        $@"Documento 'AX' Importe ${cImporteTotal1.GetValueDecimal}" + Environment.NewLine +
                                        @"Confirma la Contabilizacion ?", @"Confirmacion de Documentos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return false;
            }
            return true;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (_tipoDocumentoGenerar == TipoDoc.Ambos)
            {
                var f = new RpvDocumentoX1L1RetornoCheque(_zdoc1.GetHeader().IDH);
                f.Show();
            }
            else
            {
                if (_tipoDocumentoGenerar == TipoDoc.NotaDebito)
                {

                }
                else
                {
                    if (txtLx.Text == @"L1")
                    {
                        //Solo Documento X Formal
                        var f = new RpvDocumentoX1L1RetornoCheque(_zdoc1.GetHeader().IDH);
                        f.Show();
                    }
                }
            }
        }
        private void btnSolicitarCae_Click(object sender, EventArgs e)
        {
            var idFactura = Convert.ToInt32(txtIdFactura.Text);
            ModoEjecucion modoEjecucion;
            if (GlobalApp.Modo == ModoApp.Produccion)
            {
                modoEjecucion = ModoEjecucion.Produccion;
            }
            else
            {
                modoEjecucion = ModoEjecucion.Testeo;
                var rpt = MessageBox.Show(
                    @"Atencion se esta ejecutando la aplicacion en modo TESTEO. El CAE otorgado NO SERA VALIDO. Desea Continuar?",
                    @"Modo APP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpt == DialogResult.No)
                    return;
            }
            var fe = new FacturacionElectronicaTecser(modoEjecucion);

            if (fe.CheckSiPermiteSolicitarCAE(idFactura))
            {
                var dr =
                    MessageBox.Show(
                        $@"Confirma que desea SOLICITAR CAE a AFIP para el documento contabilizado por IMPORTE $ {cImporteTotal2.GetValueDecimal} ?",
                        @"Solicitud de CAE AFIP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                    return;
            }
            else
            {
                MessageBox.Show(@"El Documento NO SE Encuentra en condiciones de solicitar CAE",
                    @"Fallo de Condiciones para Pedir CAE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resultado = fe.SolicitudCAEFromT0400(idFactura, null,cChFechaRecibido.Value.Value,null);
            if (resultado.Resultado == "A")
            {
                txtCaeNumero.Text = resultado.CAE;
                txtCaeVencimiento.Text = resultado.VencimientoCAE.ToString("d");
                txtNumDoc2.Text = resultado.PuntoVenta.PadLeft(4, '0') + @"-" +
                                          resultado.ComprobanteHasta.PadLeft(8, '0');
                fe.UpdateDataAfterDocumentNumberGetFromAFIP(idFactura, resultado.PuntoVenta.PadLeft(4, '0'),
                    resultado.ComprobanteHasta.PadLeft(8, '0'), resultado.CAE, resultado.VencimientoCAE, Convert.ToInt32(txtAsn2.Text));
                txtStatusDoc2.Text = DocumentFIStatusManager.StatusHeader.Aprobada.ToString();
                txtStatusDoc2.BackColor = Color.LimeGreen;
                btnSolicitarCae.Enabled = false;
                MessageBox.Show(@"Se ha generado CAE Correctamente", @"Obtencion de CAE", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _zdoc2.UpdateNumeroDocumentoAfterCAE(txtNumDoc2.Text);
                dgvDoc2.DataSource = _zdoc2.GetItemList();
                btnImprimir.Enabled = true;
                
            }
            else
            {
                MessageBox.Show(
                    $@"Ha Ocurrido un error al solicitar el CAE * observacion >> {resultado.Wsfev1Observacion}",
                    @"Error en SOLICITUD DE CAE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStatusDoc2.Text = DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString().ToUpper();
            }
            
        }
        private void cFechaTransaccion_Validated(object sender, EventArgs e)
        {
            cTc.SetValue = new ExchangeRateManager().GetExchangeRate(cFechaTransaccion.Value.Value);
        }
    }
}
