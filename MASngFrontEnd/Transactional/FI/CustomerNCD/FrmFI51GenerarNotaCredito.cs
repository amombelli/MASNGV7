using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData.Customer_Master;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.ContaFromDocuments;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.Customers;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.SD;
using TSControls;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI51GenerarNotaCredito : Form
    {
        private CustomerNc _nc; //Documento Principal
        private CustomerNc _nc2; //Documento Secundario
        private bool _existeDocumentoSecundario = false; //Defualt NO
        private ModoEjecucion _modoAfip;
        private int _idCliente;
        private CustomerNc.MotivoNotaCredito _motivoCredito;
        private Lx _lx;
        private ManageDocumentType.TipoDocumento _tipoDocumento = ManageDocumentType.TipoDocumento.NoDefinido;
        private ManageDocumentType.TipoDocumento _tipoDocumento2 = ManageDocumentType.TipoDocumento.NoDefinido;
        private DocumentFIStatusManager.StatusHeader _statusDocumento = DocumentFIStatusManager.StatusHeader.Pendiente;
        private DocumentFIStatusManager.StatusHeader _statusDocumento2 = DocumentFIStatusManager.StatusHeader.Pendiente;
        private int _idRetorno = -1; //ID de Retorno de la seleccion de documento
        private bool _flagReingresarStockAlSistema = false; //retornos 
        private int IdRemitoAsociado = 0; //retorno
        private int? _idRetornoAlternativo = null;
        private decimal KgNotaCredito;
        private enum Lx
        {
            L1,
            L2,
            NoSeleccionado
        };

        public FrmFI51GenerarNotaCredito(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }

        public FrmFI51GenerarNotaCredito()
        {
            InitializeComponent();
        }

        public FrmFI51GenerarNotaCredito(int idFactura, int modo)
        {
            //todo Constructor para carga de documentos existente
            //hacer en conjunto con FI61
        }

        //fin ver si se puede borrar
        private decimal _nuevoTC = 1;

        //Inicio OK
        private void FrmFI52GenerarNotaCredito_Load(object sender, EventArgs e)
        {
            MapCustomerData();
            _lx = Lx.NoSeleccionado;
            txtStatusDocumento.Text = _statusDocumento.ToString();
            txtStatusDoc1.Text = _statusDocumento.ToString();
            txtStatusDoc2.Text = _statusDocumento2.ToString();
            PanelContabilizacion.Enabled = false;
            PanelRegistracion.Enabled = false;
            ribbonNotaCredito.ActiveTab = rTabCliente;
            cTc.SetValue = new ExchangeRateManager().GetExchangeRate(dtpFechaDocumento.Value);
        }
        private void MapCustomerData()
        {
            if (_idCliente == -1)
            {
                txtRazonSocial.Text = null;
                txtCuit.Text = null;
                cCuitOk.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtIva.Text = @"Responsable Inscripto";
                txtProvincia.Text = null;
                txtVendedor.Text = null;
            }

            var c = new CustomerManager().GetCustomerBillToData(_idCliente);
            if (c != null)
            {
                txtRazonSocial.Text = c.cli_rsocial;
                txtCuit.Text = c.CUIT;
                cCuitOk.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
                txtIva.Text = @"Responsable Inscripto";
                txtProvincia.Text = c.Direfactu_Provincia;
                var c2 = c.T0007_CLI_ENTREGA.FirstOrDefault(d => d.Activo);
                if (c2 != null)
                {
                    txtVendedor.Text = c2.Vendedor;
                }
            }
        }

        #region Acciones NC

        //aca van los redirectors de los botones

        private void rbDescuentoDocumento_Click(object sender, EventArgs e)
        {
            _motivoCredito = CustomerNc.MotivoNotaCredito.DesGeneralDocumentos;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void rbDescuentoGeneral_Click(object sender, EventArgs e)
        {
            _motivoCredito = CustomerNc.MotivoNotaCredito.DesGeneralPeriodo;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnAnulaDocumento_Click(object sender, EventArgs e)
        {
            _motivoCredito = CustomerNc.MotivoNotaCredito.AnulaDocumento;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnDevolucionParcial_Click(object sender, EventArgs e)
        {
            _motivoCredito = CustomerNc.MotivoNotaCredito.DevolucionMaterial;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnDiferenciaPrecio_Click(object sender, EventArgs e)
        {
            _motivoCredito = CustomerNc.MotivoNotaCredito.DiferenciaPrecio;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnVariacionCotizacion_Click(object sender, EventArgs e)
        {
            _motivoCredito = CustomerNc.MotivoNotaCredito.DiferenciaCambio;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnVariacionKg_Click(object sender, EventArgs e)
        {
            _motivoCredito = CustomerNc.MotivoNotaCredito.DiferenciaKg;
            RedirigeAccionDespuesPresionarBoton();
        }
        private void btnDescuentoGeneral_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Debe Seleccionar una de las 2 Opciones de Descuento General", @"Decuento General",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void RedirigeAccionDespuesPresionarBoton()
        {
            //Los botones de accion redirigen a esta funcion -- Valida -- Activa Ribbon 
            //Redirige a Accion Especifica segun el motivo/boton presionado

            if (_lx == Lx.NoSeleccionado)
            {
                MessageBox.Show(
                    @"Debe Seleccionar el tipo de Operacion (L1/L2) antes de seleccionar el Motivo General de la Nota de  Credito",
                    @"Falta Seleccion Tipo OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _motivoCredito = CustomerNc.MotivoNotaCredito.SinMotivo;
                return;
            }

            if (string.IsNullOrEmpty(txtMotivoGeneralDocumento.Text))
            {
                MessageBox.Show(@"Complete el motivo por el que se genera este documento", @"Falta Observacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _motivoCredito = CustomerNc.MotivoNotaCredito.SinMotivo;
                return;
            }

            if (cmbAutorizadoPor.SelectedItem == null)
            {
                MessageBox.Show(@"Debe indicar quien Autoriza la generacion del Documento", @"Falta Autorizante",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _motivoCredito = CustomerNc.MotivoNotaCredito.SinMotivo;
                return;
            }

            txtTipoNotaCredito.Text = _motivoCredito.ToString();
            ribbonNotaCredito.ActiveTab = rTabContabilizacion;
            PanelRegistracion.Enabled = true;
            btnUnregister.Enabled = false;
            PanelTipoNC.Enabled = false;
            tabFi2.Visible = false;
            switch (_motivoCredito)
            {
                case CustomerNc.MotivoNotaCredito.SinMotivo:
                    MessageBox.Show(@"Seleccione un Motivo de Documento para continuar", @"Falta Motivo Nota Credito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case CustomerNc.MotivoNotaCredito.AnulaDocumento:
                    FxAnulaDocumentoCompleto();
                    break;
                case CustomerNc.MotivoNotaCredito.DiferenciaPrecio:
                    FxDiferenciaPrecioItem();
                    break;
                case CustomerNc.MotivoNotaCredito.DiferenciaCambio:
                    //Todo: Falta Construir Funcion
                    //NcAjusteTCDocumentoCompleto();
                    break;
                case CustomerNc.MotivoNotaCredito.DiferenciaKg:
                    //Todo: Falta Construir Funcion
                    break;
                case CustomerNc.MotivoNotaCredito.DevolucionMaterial:
                    FxDevolucionItem();
                    //todo: construir funcion
                    break;
                case CustomerNc.MotivoNotaCredito.DesGeneralDocumentos:
                    FxDescuentoSobreDocumentos();
                    break;
                case CustomerNc.MotivoNotaCredito.DesGeneralPeriodo:
                    FxDescuentoGeneralPeriodo();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void FxDevolucionItem()
        {
            if (_lx == Lx.L1)
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Nota Credito 'A'");
                cmbTipoDocumento.SelectedItem = "Nota Credito 'A'";
            }
            else
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Nota Credito 'X'");
                cmbTipoDocumento.SelectedItem = "Nota Credito 'X'";
            }
            var autorizado = "NO-Autorizado";
            if (cmbAutorizadoPor.SelectedItem != null) autorizado = cmbAutorizadoPor.SelectedItem.Text;

            _nc = new CustomerNc(CustomerNc.MotivoNotaCredito.DevolucionMaterial);
            _nc.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", true, autorizado);

            using (var f0 = new FrmFi54NcDevolucion(_nc))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    dgv400.DataSource = _nc.GetItems();
                    MapTotalesFactura400(_nc.GetTotalesFromHeader());
                    MapHeaderDocumento1();
                    _idRetorno = f0.IdRetornoSeleccionado; //IdRegistro RTN 
                    _idRetornoAlternativo = f0.IdFacturaSeleccionada; //IdFactura link-retorno
                    KgNotaCredito = f0.KgNotaCredito;

                    if (_idRetornoAlternativo != null)
                    {
                        _nc.SetDocumentoAsociado(_idRetornoAlternativo.Value);
                    }
                    else
                    {
                        _nc.SetPeriodoAsociado(dtpFechaDocumento.Value, dtpFechaDocumento.Value);
                    }

                    //aca hacer funciona para cerrar en RTN el credito a la hora de contabilizar
                }
                else
                {
                    MessageBox.Show(@"Se Cancelo la seleccion del documento", @"Seleccion Cancelada",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //using (var f0 = new FrmFI58SeleccionDocDescuentoGeneral(_nc, _motivoCredito))
            //{
            //    DialogResult dr = f0.ShowDialog();
            //    if (dr == DialogResult.OK)
            //    {
            //        dgv400.DataSource = _nc.GetItems();
            //        MapTotalesFactura400(_nc.GetTotalesFromHeader());
            //        MapHeaderDocumento1();

            //        //var listaDocBonifica = f0.FacturaAplica;            //array de documentos y/o fechas
            //        //var listaNumerosDocu = f0.NumeroDocumentoAplica; //array de numeros documento aplica
            //        ////_nc.CargaDatosNcDescuentoGeneral(_idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "ARS", f0.ItemList);
            //        //if (listaNumerosDocu.Count == 1)
            //        //{
            //        //    _nc.AddIdComprobanteAsociado(listaDocBonifica[0]);
            //        //    _iddocumentoAnula = listaDocBonifica[0];
            //        //}
            //        //else
            //        //{
            //        //    _nc.AddPeriodoComprobanteAsociado(f0.FechaAplicaDesde.Value, f0.FechaAplicaHasta.Value);
            //        //    _periodoAnulaDesde = f0.FechaAplicaDesde;
            //        //    _periodoAnulaHasta = f0.FechaAplicaHasta;
            //        //}
            //    }
            //    else
            //    {
            //        MessageBox.Show(@"Se Cancelo la seleccion del documento", @"Seleccion Cancelada",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        /// <summary>
        /// Se anula completamente una Factura o Nota de Debito por Motivo X
        /// Siempre será un solo documento que anula un documento de contrapartida NC-> FA o ND
        /// </summary>
        private void FxAnulaDocumentoCompleto()
        {
            string autorizado = "NO-Autorizado";
            if (cmbAutorizadoPor.SelectedItem != null) autorizado = cmbAutorizadoPor.SelectedItem.Text;
            cmbTipoDocumento.Items.Clear();
            using (var f0 = new FrmFi53SeleccionFacturaAnular(_idCliente, _lx.ToString()))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _idRetorno = f0.Id400Selected.Value; //Documento T400 a Anular
                    _flagReingresarStockAlSistema = f0.ReingresarStock;
                    IdRemitoAsociado = f0.idRemitoAsociado;
                    var tdocOrigen = f0.TDoc;
                    //Selecciona el Tipo de Documento a Crear Automaticamente de acuerdo al documento a Anular
                    if (tdocOrigen == "FA" || tdocOrigen == "ND")
                    {
                        if (_lx == Lx.L1)
                        {
                            _tipoDocumento = ManageDocumentType.TipoDocumento.NotaCreditoVentaA;
                            cmbTipoDocumento.Items.Add("Nota Credito 'A'");
                            cmbTipoDocumento.SelectedItem = "Nota Credito 'A'";
                        }
                        else
                        {
                            _tipoDocumento = ManageDocumentType.TipoDocumento.NotaCreditoVenta2;
                            cmbTipoDocumento.Items.Add("Nota Credito 'X'");
                            cmbTipoDocumento.SelectedItem = "Nota Credito 'X'";
                        }
                    }
                    else
                    {
                        if (tdocOrigen == "DX")
                        {
                            _tipoDocumento = ManageDocumentType.TipoDocumento.CreditoNoFiscalCli;
                            cmbTipoDocumento.Items.Add("Documento Interno 'X'");
                            cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
                        }
                        else
                        {
                            MessageBox.Show(@"Tipo de Documento Origen no Manejado",
                                @"Error en Tipo de Documento Origen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    _nc = new CustomerNc(_motivoCredito);
                    _nc.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(),
                        dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", false, autorizado);
                    _nc.AnulaDocumentoCompleto(_idRetorno);
                    txtMotivoGeneralDocumento.BackColor = string.IsNullOrEmpty(txtMotivoGeneralDocumento.Text)
                        ? Color.LightPink
                        : Color.LightGreen;
                    txtCondicionVenta.Text = @"0E - Pago Contraentrega Documento";
                    dgv400.DataSource = _nc.GetItems();
                    MapTotalesFactura400(_nc.GetTotalesFromHeader());
                    MapHeaderDocumento1();
                    _existeDocumentoSecundario = false;

                }
            }
        }

        /// <summary>
        /// Descuento X a Aplicar a un documento o varios documentos
        /// </summary>
        private void FxDescuentoSobreDocumentos()
        {
            if (_lx == Lx.L1)
            {
                //Disposicion AFIP ND no se debe hacer para cheque pero dejamos la posibilidad
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Nota Credito 'A'");
                cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
            }
            else
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Nota Credito 'X'");
                cmbTipoDocumento.SelectedItem = "Nota Credito 'X'";
            }
            string autorizado = "NO-Autorizado";
            if (cmbAutorizadoPor.SelectedItem != null) autorizado = cmbAutorizadoPor.SelectedItem.Text;

            _nc = new CustomerNc(CustomerNc.MotivoNotaCredito.DesGeneralDocumentos);
            _nc.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", true, autorizado);
            using (var f0 = new FrmFI58SeleccionDocDescuentoGeneral(_nc, _motivoCredito))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    dgv400.DataSource = _nc.GetItems();
                    MapTotalesFactura400(_nc.GetTotalesFromHeader());
                    MapHeaderDocumento1();


                    //var listaDocBonifica = f0.FacturaAplica;            //array de documentos y/o fechas
                    //var listaNumerosDocu = f0.NumeroDocumentoAplica; //array de numeros documento aplica
                    ////_nc.CargaDatosNcDescuentoGeneral(_idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "ARS", f0.ItemList);
                    //if (listaNumerosDocu.Count == 1)
                    //{
                    //    _nc.AddIdComprobanteAsociado(listaDocBonifica[0]);
                    //    _iddocumentoAnula = listaDocBonifica[0];
                    //}
                    //else
                    //{
                    //    _nc.AddPeriodoComprobanteAsociado(f0.FechaAplicaDesde.Value, f0.FechaAplicaHasta.Value);
                    //    _periodoAnulaDesde = f0.FechaAplicaDesde;
                    //    _periodoAnulaHasta = f0.FechaAplicaHasta;
                    //}
                }
                else
                {
                    MessageBox.Show(@"Se Cancelo la seleccion del documento", @"Seleccion Cancelada",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Descuento General a Aplicar sobre un Periodo Determinado sin definir los documentos LINK
        /// </summary>
        private void FxDescuentoGeneralPeriodo()
        {
            if (_lx == Lx.L1)
            {
                //Disposicion AFIP ND no se debe hacer para cheque pero dejamos la posibilidad
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Nota Credito 'A'");
                cmbTipoDocumento.SelectedItem = "Documento Interno 'X'";
            }
            else
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Nota Credito 'X'");
                cmbTipoDocumento.SelectedItem = "Nota Credito 'X'";
            }
            string autorizado = "NO-Autorizado";
            if (cmbAutorizadoPor.SelectedItem != null) autorizado = cmbAutorizadoPor.SelectedItem.Text;
            _nc = new CustomerNc(CustomerNc.MotivoNotaCredito.DesGeneralPeriodo);
            _nc.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", true, autorizado);
            using (var f0 = new FrmFI59DescuentoGeneralPeriodoAsociado(_nc, _motivoCredito))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    dgv400.DataSource = _nc.GetItems();
                    MapTotalesFactura400(_nc.GetTotalesFromHeader());
                    MapHeaderDocumento1();


                    //_nc.SetPeriodoAsociado(f0.FechaAplicaDesde.Value, f0.FechaAplicaHasta.Value);
                    // _periodoAnulaDesde = f0.FechaAplicaDesde;
                    // _periodoAnulaHasta = f0.FechaAplicaHasta;
                }
                else
                {

                }
            }
        }

        /// <summary>
        /// Estoy por aca ahora 
        /// </summary>
        private void FxDiferenciaPrecioItem()
        {
            if (_lx == Lx.L1)
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Nota Credito 'A'");
                cmbTipoDocumento.SelectedItem = "Nota Credito 'A'";
            }
            else
            {
                cmbTipoDocumento.Items.Clear();
                cmbTipoDocumento.Items.Add("Nota Credito 'X'");
                cmbTipoDocumento.SelectedItem = "Nota Credito 'X'";
            }
            string autorizado = "NO-Autorizado";
            if (cmbAutorizadoPor.SelectedItem != null) autorizado = cmbAutorizadoPor.SelectedItem.Text;
            _nc = new CustomerNc(CustomerNc.MotivoNotaCredito.DiferenciaPrecio);
            _nc.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", true, autorizado);
            using (var f0 = new FrmFi57SeleccionDocModificacionPrecio(_nc, _motivoCredito))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {

                    dgv400.DataSource = _nc.GetItems();
                    MapTotalesFactura400(_nc.GetTotalesFromHeader());
                    MapHeaderDocumento1();

                }
                else
                {
                    MessageBox.Show(@"Se Cancelo la seleccion del documento", @"Seleccion Cancelada",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void NcAjusteTCDocumentoCompleto()
        {
            //Esta funcion es para hacer NC o ND por Ajuste en Tipo de Cambio
            //Se refiere a un solo documento
            using (var f0 = new FrmFi56SeleccionDocumentoAjusteTc(_tipoDocumento, _lx.ToString(), _idCliente))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //   _iddocumentoAnula = f0.IdFacturaSeleccionada;
                    //_numeroFacturaAnula = f0.NumeroDocumentoSeleccionado; //cambiar por numero doc
                    _nuevoTC = f0.NuevoTC;
                    //   if (_iddocumentoAnula == null) return;
                    if (_nuevoTC <= 0) return;
                    //    _nc.CargaDatosNcActualizaPrecioDiferenciaCambio(_iddocumentoAnula.Value,_nuevoTC); //nueva
                }
                else
                {
                    //se ha cancelado la seleccion

                }
            }
        }
        private void MapHeaderFa()
        {
            var h = _nc.H4;
            txtId400.Text = h.IDFACTURA.ToString();
            _statusDocumento = new DocumentFIStatusManager().MapStatusHeaderFromText(h.StatusFactura);
            txtStatusDocumento.Text = _statusDocumento.ToString();
            if (h.NAS == null)
            {
                txtNumeroAsiento.Text = @"N/D";
            }
            else
            {
                txtNumeroAsiento.Text = _nc.H4.NAS.ToString();
            }

            txtNumeroCae.Text = h.CAE;
            txtVencimientoCae.Text = h.CAE_VTO.ToString();
            if (string.IsNullOrEmpty(h.CAE))
            {
                if (txtLx.Text == @"L1")
                {
                    semCAE.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                    txtVencimientoCae.Text = null;
                    txtNumeroCae.Text = null;
                }
                else
                {
                    semCAE.SetLights = CtlSemaforo.ColoresSemaforo.Azul;
                    txtVencimientoCae.Text = null;
                    txtNumeroCae.Text = null;
                }
            }
            else
            {
                if (txtLx.Text == @"L1")
                {
                    if (_statusDocumento == DocumentFIStatusManager.StatusHeader.Aprobada)
                    {
                        semCAE.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                        txtVencimientoCae.Text = h.CAE;
                        txtNumeroCae.Text = h.CAE_VTO.ToString();
                    }
                    else
                    {
                        semCAE.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
                        txtVencimientoCae.Text = null;
                        txtNumeroCae.Text = null;
                    }
                }
                else
                {
                    semCAE.SetLights = CtlSemaforo.ColoresSemaforo.Azul;
                    txtVencimientoCae.Text = null;
                    txtNumeroCae.Text = null;
                }
            }
        }
        private void MapTotalesFactura400(TotalesCustomerFi total)
        {
            if (!total.OK)
            {
                MessageBox.Show(@"Error en calculo de Totales");
            }

            cBruto.SetValue = total.Bruto;
            cDescuento.SetValue = total.Descuento;
            cSubtotal.SetValue = total.Subtotal;
            cImponible.SetValue = total.BaseImponible;
            cIva.SetValue = total.Iva21;
            cPercepcionIIBB.SetValue = total.IIBB;
            cTotalFinal.SetValue = total.TotalFinal;
        }

        #endregion

        private void MapHeaderDocumento1()
        {
            var h = _nc.GetHeader();
            txtId400.Text = _nc.Id400.ToString();
            txtStatusDoc1.Text = h.StatusFactura;
            txtNumeroDocumento.Text = h.NumeroDoc;
            //
            var h3 = _nc.GetHeader300();
            txtSNumeroDoc1.Text = h3.NDOC;
            txtSIdNcd1.Text = h3.IDH.ToString();
            txtSDescripcionInternar1.Text = h3.COMENTARIO;
            txtSFechaRegistro1.Text = h3.FECHA.ToString("d");
            txtSImporteArs1.Text = h3.ImporteARS.ToString("C2");
            txtSImporteUsd1.Text = h3.ImporteUSD.ToString("C2");
            txtSPeriodoDesde1.Text = h3.PeriodoAjusteDesde.ToString();
            txtSPeriodoHasta1.Text = h3.PeriodoAjusteHasta.ToString();
            txtSNumeroDocAsociado1.Text = _nc.NumeroDocumentoAsociado;
            txtSIdDocumenntoAsociado.Text = h3.idFacturaAsociada.ToString();
            txtSLx1.Text = h3.LX;
        }
        private void MapHeaderDocumento2()
        {
            var h = _nc.GetHeader();
            txtId400Gasto.Text = _nc.Id400.ToString();
            txtStatusDoc2.Text = h.StatusFactura;
            txtnumeroDoc2.Text = h.NumeroDoc;
            //
            var h3 = _nc.GetHeader300();
            txtSNumeroDoc2.Text = h3.NDOC;
            txtSIdNcd2.Text = h3.IDH.ToString();
            txtSDescripcionInterna2.Text = h3.COMENTARIO;
            txtSFechaRegistro2.Text = h3.FECHA.ToString("d");
            txtSImporteArs2.Text = h3.ImporteARS.ToString("C2");
            txtSImporteUsd2.Text = h3.ImporteUSD.ToString("C2");
            txtSPeriodoDesde2.Text = h3.PeriodoAjusteDesde.ToString();
            txtSPeriodoHasta2.Text = h3.PeriodoAjusteHasta.ToString();
            txtSLx2.Text = h3.LX;
        }
        private bool OkRegistrar()
        {
            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NoDefinido)
            {
                MessageBox.Show(@"No se ha definido aun un tipo de documento a Registrar", @"Documento Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtMotivoGeneralDocumento.Text))
            {
                MessageBox.Show(@"Debe completar el motivo por el que se está generando el documento (interno)",
                    @"Fata Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tt.Show("Complete este Dato", txtMotivoGeneralDocumento, 700);
                return false;
            }

            tt.Show("", txtMotivoGeneralDocumento);
            return true;
        }
        private void SetScreenStatus()
        {
            PanelRegistracion.Enabled = false;
            PanelContabilizacion.Enabled = false;
            btnContabilizar.Enabled = false;
            btnSolicitarCae.Enabled = false;
            txtStatusDocumento.Text = _statusDocumento.ToString();
            txtStatusDoc1.Text = _statusDocumento.ToString();
            txtStatusDoc2.Text = _statusDocumento2.ToString();
            switch (_statusDocumento)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    btnRegistrar.Enabled = true;
                    btnUnregister.Enabled = false;
                    txtMotivoGeneralDocumento.Enabled = true;
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    btnRegistrar.Enabled = false;
                    btnUnregister.Enabled = true;
                    PanelContabilizacion.Enabled = true;
                    btnContabilizar.Enabled = true;
                    txtMotivoGeneralDocumento.Enabled = false;
                    break;
                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    //esta lista par ser impresa
                    break;
                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    //esta lista para ser impresa
                    txtStatusDoc1.BackColor = Color.LightGreen;
                    break;
                case DocumentFIStatusManager.StatusHeader.Impresa:
                    break;
                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    break;
                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    txtStatusDoc1.BackColor = Color.LightCoral;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (_statusDocumento2)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    break;
                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    //esta lista par ser impresa
                    break;
                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    //esta lista para ser impresa
                    //txtStatusDoc2.BackColor = Color.LightGreen;
                    break;
                case DocumentFIStatusManager.StatusHeader.Impresa:
                    break;
                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    break;
                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    //txtStatusDoc2.BackColor = Color.LightCoral;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            if (_statusDocumento2 == DocumentFIStatusManager.StatusHeader.PendienteCAE ||
                _statusDocumento == DocumentFIStatusManager.StatusHeader.PendienteCAE)
            {
                PanelContabilizacion.Enabled = true;
                btnSolicitarCae.Enabled = true;
            }
        }
        private void SolicitaCaeCompletaData(int posicionDocumento, int iddoc, int? idDocAnula, DateTime? fechaD, DateTime? fechaH)
        {
            var fe = new FacturacionElectronicaTecser(_modoAfip);
            var resultado = idDocAnula != null
                ? fe.SolicitudCAEFromT0400(iddoc, idDocAnula, null, null)
                : fe.SolicitudCAEFromT0400(iddoc, null, fechaD, fechaH);

            if (resultado.Resultado == "A")
            {
                if (posicionDocumento == 1)
                {
                    txtCae1.Text = resultado.CAE;
                    txtVencimientoCae1.Text = resultado.VencimientoCAE.ToString("d");
                    txtNumeroDocumento.Text = resultado.NumeroDocumentoOtorgadoCompleto;
                    txtNumeroDoc1.Text = resultado.NumeroDocumentoOtorgadoCompleto;
                    fe.UpdateDataAfterDocumentNumberGetFromAFIP(iddoc, resultado.PuntoVenta, resultado.ComprobanteHasta, resultado.CAE,
                        resultado.VencimientoCAE, Convert.ToInt32(txtNas1.Text));
                    _statusDocumento = DocumentFIStatusManager.StatusHeader.Aprobada;
                    //Aca van funciones que se tienen que ejecutar luego del CAE Aprobado
                    //**

                    //**
                }
                else
                {
                    txtCae2.Text = resultado.CAE;
                    txtVencimientoCae2.Text = resultado.VencimientoCAE.ToString("d");
                    txtnumeroDoc2.Text = resultado.NumeroDocumentoOtorgadoCompleto;
                    fe.UpdateDataAfterDocumentNumberGetFromAFIP(iddoc, resultado.PuntoVenta, resultado.ComprobanteHasta, resultado.CAE,
                        resultado.VencimientoCAE, Convert.ToInt32(txtNas2.Text));
                    _statusDocumento2 = DocumentFIStatusManager.StatusHeader.Aprobada;
                }

                //Chequea si hay que ingresar Percepcion IIBB
                if (posicionDocumento == 1)
                {
                    var xdoc = _nc.GetHeader();
                    if (xdoc.TotalIIBB > 0)
                    {
                        new PercepcionesManager().AddFacturaPercepcion(iddoc);
                    }
                }
                else
                {
                    var xdoc = _nc2.GetHeader();
                    if (xdoc.TotalIIBB > 0)
                    {
                        new PercepcionesManager().AddFacturaPercepcion(iddoc);
                    }
                }
                var st = new GestionT400Status(iddoc);
                st.SetAprobadaCae(resultado.CAE, resultado.VencimientoCAE, resultado.PuntoVenta, resultado.ComprobanteHasta);
                MessageBox.Show(@"El CAE se ha Aprobado. El Documento ya tiene Numero Oficial", @"CAE-AFIP OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Ha Ocurrido un error al solicitar el CAE", @"Error en SOLICITUD DE CAE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetScreenStatus();
        }
        private bool CheckAllowToPrint()
        {
            return true;
        }

        #region botones
        private void btnImprmir_Click(object sender, EventArgs e)
        {
            if (!CheckAllowToPrint())
                return;

            //if (txtTipoLx.Text == @"L1")
            //{
            //    if (ckPreImpreso.Checked)
            //    {
            //        var f = new RpvFacturaL1(_facturaIdStruct.IdFactura, ckImprimirMensajeMora.Checked,
            //            txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked, ckCodBarra.Checked);
            //        f.Show();
            //    }
            //    else
            //    {

            //    }
            //}
            //else
            //{
            //    var f = new RpvNcdl2(_facturaIdStruct.IdFactura, ckSaldoTotalAdeudadoL2.Checked,
            //        ckImpresionConsolidada.Checked);
            //    f.Show();
            //}
        }
        private void btnHojaImprenta_Click(object sender, EventArgs e)
        {
            //Impresion en Preimpreso (solo L1)
            if (_lx != Lx.L1)
            {
                MessageBox.Show(@"Opcion no Valida", @"Error en Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var f = new RpvFacturaL1(_nc.H4.IDFACTURA, ckMora.Checked,
                txtObservacionesAdicionales.Text, ckImpresionConsolidada.Checked, ckImprimirQR.Checked);
            f.Show();
        }
        private void btnImpresionCompleta_Click(object sender, EventArgs e)
        {
            //Impresion en Hoja en Blanco
            if (_lx == Lx.L1)
            {
                var f = new RpvFacturaL1_PDF(_nc.H4.IDFACTURA, ckMora.Checked, txtObservacionesAdicionales.Text,
                    ckImpresionConsolidada.Checked, ckImprimirQR.Checked);
                f.Show();
            }

            if (_lx == Lx.L2)
            {
                var f = new RpvNcdl2(_nc.H4.IDFACTURA, ckImprimirSaldoAnterior.Checked,
                    ckImpresionConsolidada.Checked);
                f.Show();
            }
        }
        private void btnPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funciono no displnible Aun", @"Work In Progress", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void btnEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funciono no displnible Aun", @"Work In Progress", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void btnElegirCliente_Click(object sender, EventArgs e)
        {
            if (_statusDocumento != DocumentFIStatusManager.StatusHeader.Pendiente)
            {
                MessageBox.Show(@"No se puede modificar el cliente en este estado del documento",
                    @"Error en Modificacion de Cliente");
                return;
            }

            using (var f0 = new FrmMdc01CustomerSearch(4, ""))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK || DialogResult == DialogResult.None)
                {
                    _idCliente = f0.ClienteSeleccionado;
                    MapCustomerData();
                }
            }
        }
        private void btnDetalleCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Aca se van a mostrar los datos detallados del cliente");
        }
        private void btnSolicitarCae_Click(object sender, EventArgs e)
        {
            _modoAfip = GlobalApp.Modo == ModoApp.Produccion ? ModoEjecucion.Produccion : ModoEjecucion.Testeo;
            if (_modoAfip == ModoEjecucion.Testeo)
            {
                MessageBox.Show(
                    @"Atencion SE esta ejecutando la aplicacion en modo TESTEO" + Environment.NewLine +
                    @"El CAE otorgado NO SERA VALIDO para fines Fiscales",
                    @"Modo Aplicacion = * TESTEO *", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (_statusDocumento == DocumentFIStatusManager.StatusHeader.PendienteCAE)
            {
                if (new FacturacionElectronicaTecser(_modoAfip).CheckSiPermiteSolicitarCAE(_nc.GetId400()) == false)
                {
                    MessageBox.Show(
                        @"El Documento No se encuentra en condiciones de solicitar CAE" + Environment.NewLine +
                        @"El Documento no esta en estado 'PendienteCAE'",
                        @"Solicitud de CAE *No Permitida*", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SolicitaCaeCompletaData(1, _nc.GetId400(), _nc.IdFacturaAsociada, _nc.PeriodoDesde, _nc.PeriodoHasta);
                    new MargenDocument().AddItemNotaCredito(_nc.GetId300());
                }
            }

            if (_statusDocumento2 == DocumentFIStatusManager.StatusHeader.PendienteCAE)
            {
                if (new FacturacionElectronicaTecser(_modoAfip).CheckSiPermiteSolicitarCAE(_nc2.GetId400()) == false)
                {
                    MessageBox.Show(
                        @"El Documento No se encuentra en condiciones de solicitar CAE" + Environment.NewLine +
                        @"El Documento no esta en estado 'PendienteCAE'",
                        @"Solicitud de CAE *No Permitida*", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SolicitaCaeCompletaData(2, _nc2.GetId400(), _nc2.IdFacturaAsociada, _nc2.PeriodoDesde,
                        _nc2.PeriodoHasta);
                    new MargenDocument().AddItemNotaCredito(_nc2.Id300);
                }
            }
        }
        private void btnContabilizar_Click(object sender, EventArgs e)
        {
            //Validar documento registrado
            if (_nc.GetId400() < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error y no se puede contabilizar el Documento #1",
                    @"Error al Intentar Contabilizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_existeDocumentoSecundario && _nc2.GetId400() < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error y no se puede contabilizar el Documento #2",
                    @"Error al Intentar Contabilizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //**  Contabilizacion de Acuerdo al Motivo 
            var zz = new ContaClienteNotaCreditoL2(_nc.GetId400(), _idCliente, txtTdoc.Text);
            switch (_motivoCredito)
            {
                case CustomerNc.MotivoNotaCredito.AnulaDocumento:
                    zz.ContabilizacionAnulaDocumentoCompleto();
                    break;
                case CustomerNc.MotivoNotaCredito.DiferenciaPrecio:
                    zz.ContabilizaCompletoHeaderND();
                    break;
                case CustomerNc.MotivoNotaCredito.DiferenciaCambio:
                    break;
                case CustomerNc.MotivoNotaCredito.DiferenciaKg:
                    break;
                case CustomerNc.MotivoNotaCredito.DevolucionMaterial:
                    zz.ContabilizaCompletoHeaderND();
                    break;
                case CustomerNc.MotivoNotaCredito.DesGeneralDocumentos:
                    zz.ContabilizaCompletoHeaderND();
                    break;
                case CustomerNc.MotivoNotaCredito.DesGeneralPeriodo:
                    zz.ContabilizaCompletoHeaderND();
                    break;
                case CustomerNc.MotivoNotaCredito.SinMotivo:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            txtIdCtaCte1.Text = zz.IdCtaCte.ToString();
            txtNas1.Text = zz.RtnAsiento.IdDocu.ToString();
            var gestionStatus = new GestionT400Status(_nc.GetId400());
            if (_lx == Lx.L1 && _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA)
            {
                //Si es NC 'A' --> va a Pendiente CAE
                _statusDocumento = gestionStatus.SetContabilizada(zz.IdCtaCte, zz.RtnAsiento.IdDocu, zz.RtnAsiento.Nasx1);
                _statusDocumento = gestionStatus.SetPendienteCae();
            }
            else
            {
                //Si es CX --> va a Contabilizada o 'L2'
                _statusDocumento = gestionStatus.SetContabilizada(zz.IdCtaCte, zz.RtnAsiento.IdDocu, zz.RtnAsiento.Nasx1);
                new MargenDocument().AddItemNotaCredito(_nc.Id300);
            }

            //****** Acciones POST-Conta Asociadas al motivo ******

            if (_motivoCredito == CustomerNc.MotivoNotaCredito.AnulaDocumento)
            {
                if (_flagReingresarStockAlSistema & IdRemitoAsociado > 0)
                {
                    var itemsRemito = RemitoItemManager.GetRemitoItemlist(IdRemitoAsociado);
                    foreach (var i in itemsRemito)
                    {
                        var rtn = new ManageRetornoMaterial().GestionDevolucion(dtpFechaDocumento.Value, _idCliente,
                            MotivoDevolucion.Motivo.ErrorAdmnistrativo, i.MATERIAL, i.BATCH, i.KGDESPACHADOS * -1,
                            "STBY", GlobalApp.AppUsername,
                            txtMotivoGeneralDocumento.Text, txtLx.Text, GlobalApp.AppUsername,
                            StockStatusManager.EstadoLote.Liberado);
                    }

                    var x = new RemitoCancelacion(IdRemitoAsociado).CancelaRemito_OV_DesdeNC();
                    if (x == false)
                    {
                        MessageBox.Show(@"Atencion no se pudo resetear el despacho en forma automatica" +
                                        Environment.NewLine +
                                        @"Notificar a Andres sobre este error y Revisar manualmente el estado de la OV y del Remito",
                            @"Alerta de Fallo de Automatizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //Anulacion de Documento(Desimputa por completo la factura - y la Autoimputa con la NC)
                var c1 = new CobranzaDesimputa();
                var ctacteDoc = c1.GetIdCtaCteFromIdDocumento(_idRetorno);
                if (c1.TieneImputacionRealizada(ctacteDoc))
                {
                    //Si el documento tiene combranza imputada la desimputa automaticamente
                    c1.DesimputaDocumento(ctacteDoc);
                }
                var imp = new CobranzaImputacion();
                imp.ImputaCobranzaBasico(ctacteDoc, zz.IdCtaCte);
                new PercepcionesManager().RemovePercepcionIIBB_FacturaAnuladaCompleta(_idRetorno);
            }

            if (_motivoCredito == CustomerNc.MotivoNotaCredito.DevolucionMaterial)
            {
                new ManageRetornoMaterial().UpdateRegistroRtnAfterNotaCredito(_idRetorno, _nc.Id300, KgNotaCredito);
            }
            SetScreenStatus();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!OkRegistrar())
                return;

            rTabDocumentos.Enabled = false;
            _statusDocumento = _nc.Registrar(txtMotivoGeneralDocumento.Text, false);
            MapHeaderDocumento1();
            if (_existeDocumentoSecundario)
            {
                _statusDocumento2 = _nc2.Registrar(txtSDescripcionInterna2.Text);
                MapHeaderDocumento2();
                MessageBox.Show(@"Se ha Registrado Correctamente el Documento IDFactura" + _nc.GetId400().ToString() +
                                Environment.NewLine +
                                @"Se ha Registrado Correctamente el Documento IDFactura" + _nc2.GetId400().ToString(),
                    @"Registracion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Se ha Registrado Correctamente el Documento IDFactura: " + _nc.GetId400().ToString(),
                    @"Registracion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SetScreenStatus();
        }
        private void btnUnregister_Click(object sender, EventArgs e)
        {
            if (_statusDocumento != DocumentFIStatusManager.StatusHeader.Registrada)
            {
                MessageBox.Show(@"El Documento no esta en estado correcto para permitir la eliminacion del Registro",
                    @"Error en Estado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var r = MessageBox.Show(@"Confirma sacar el Registro del documento en el sistema?",
                @"Eliminacion de Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
                return;

            if (_nc.DesRegistraT400())
            {
                MapHeaderFa();
                //MapHeaderNc();
                btnRegistrar.Enabled = true;
                btnUnregister.Enabled = false;
                txtMotivoGeneralDocumento.Enabled = true;
            }
        }

        #endregion

        #region funciones probadas OK

        private void rL1_Click(object sender, EventArgs e)
        {
            if (_idCliente < 1)
            {
                MessageBox.Show(@"Debe Seleccionar el Cliente antes de Continuar", @"Seleecion Incompleta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _lx = Lx.L1;
            txtLx.Text = @"L1";
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add("Nota Credito 'A'");
            cmbTipoDocumento.Items.Add("Documento Interno 'X'");
            cmbTipoDocumento.Items.Add("Ajuste Interno 'AJ'");
            cmbTipoDocumento.SelectedItem = "Nota Credito 'A'";
            zLX.Text = @"TIPO L1";
        }
        private void rL2_Click(object sender, EventArgs e)
        {
            if (_idCliente < 1)
            {
                MessageBox.Show(@"Debe Seleccionar el Cliente antes de Continuar", @"Seleecion Incompleta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _lx = Lx.L2;
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add("Nota Credito 'X'");
            cmbTipoDocumento.Items.Add("Ajuste Interno 'AJ'");
            cmbTipoDocumento.SelectedItem = "Nota Credito 'X'";
            zLX.Text = @"TIPO L2";
        }
        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lx == Lx.NoSeleccionado)
            {
                txtTdoc.Text = null;
                MessageBox.Show(@"Debe seleccionar el tipo de operacion", @"Falta Tipo LX", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (cmbTipoDocumento.SelectedIndex == -1)
            {
                txtTdoc.Text = null;
                return;
            }
            else
            {
                switch (cmbTipoDocumento.SelectedItem.ToString())
                {
                    case "Nota Credito 'A'":
                        _tipoDocumento = _lx == Lx.L1
                            ? ManageDocumentType.TipoDocumento.NotaCreditoVentaA
                            : ManageDocumentType.TipoDocumento.NotaCreditoVenta2;
                        txtTdoc.Text = @"NC";
                        break;
                    case "Documento Interno 'X'":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.CreditoNoFiscalCli;
                        txtTdoc.Text = @"CX";
                        break;
                    case "Ajuste Interno 'AJ'":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.AjusteContable;
                        txtTdoc.Text = @"AJ";
                        break;
                    case "Nota Credito 'X'":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaCreditoVenta2;
                        txtTdoc.Text = @"NC";
                        break;
                }
            }
        }

        #endregion


    }
}