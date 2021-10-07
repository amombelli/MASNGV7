using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using MASngFE.SuperMD;
using MASngFE.Transactional.FI.Factura;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.ContaFromDocuments;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Customers;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.MM;
using Tecser.Business.VBTools;
using TecserEF.Entity;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFi52NotaCreditoDebitoCliente : Form
    {
        public FrmFi52NotaCreditoDebitoCliente(int idCliente, string tipoLx, ManageDocumentType.TipoDocumento tipoDocumento,
            string indicador)
        {
            _idCliente = idCliente;
            _tipoLx = tipoLx;
            _estado = DocumentFIStatusManager.StatusHeader.Pendiente;
            _tipoDocumento = tipoDocumento;
            _indicador = indicador;
            _facturaIdStruct.IdFactura = 0;
            InitializeComponent();
        }

        //constructor usado cuando el documento esta en estado ++
        public FrmFi52NotaCreditoDebitoCliente(int idNcd)
        {
            _facturaIdStruct.IdRemitoIdNcd = idNcd;
            _facturaIdStruct.IdFactura = new NcdTableManager().GetIdFacturaFromNcd(idNcd);
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------
        private int _idCliente;
        private string _tipoLx;
        private DocumentFIStatusManager.StatusHeader _estado;
        private ManageDocumentType.TipoDocumento _tipoDocumento;
        private readonly string _indicador;
        private List<T0301_NCD_I> _listaItems = new List<T0301_NCD_I>();
        private XCustomerNcd _docData;
        private XCustomerDocumentBase.FacturaId _facturaIdStruct;
        private int? _idChequeRechazado = null;
        private int? _idFacturaSeleccionada = null; //Anular o Devolver parcial
        private int? _idItemFacturaSeleccionada = null; //Anular o Devolver parcial
        private decimal _kgSeleccionados = 0;
        private decimal _nuevoTC = 0;
        private decimal _nuevoPrecioU = 0;
        private List<Devolucion> _listaDevolucionKg = new List<Devolucion>();
        ModoEjecucion _modoAfip;
        //----------------------------------------------------------------------------------------------------
        private void FrmNotaDebito_Load(object sender, EventArgs e)
        {
            _modoAfip = GlobalApp.Modo == ModoApp.Produccion ? ModoEjecucion.Produccion : ModoEjecucion.Testeo;
            switch (_tipoDocumento)
            {
                case ManageDocumentType.TipoDocumento.NotaCreditoVentaA:
                    cmbTipoDocumento.Items.Add("Nota Credito A");
                    cmbTipoDocumento.Items.Add("Nota Credito B");
                    cmbTipoDocumento.Items.Add("Nota Credito M");
                    this.Text = @"Nota de Credito a Clientes ";
                    cmbTipoDocumento.SelectedItem = "Nota Credito A";
                    break;

                case ManageDocumentType.TipoDocumento.NotaCreditoVenta2:
                    cmbTipoDocumento.Items.Add("Nota Credito X");
                    cmbTipoDocumento.SelectedItem = "Nota Credito X";
                    cmbTipoDocumento.Enabled = false;
                    this.Text = @"Nota de Credito a Clientes ";
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoVentaA:
                    cmbTipoDocumento.Items.Add("Nota Debito A");
                    cmbTipoDocumento.Items.Add("Nota Debito B");
                    cmbTipoDocumento.Items.Add("Nota Debito M");
                    this.Text = @"Nota de Debito a Clientes ";
                    cmbTipoDocumento.SelectedItem = "Nota Debito A";
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoVenta2:
                    cmbTipoDocumento.Items.Add("Nota Debito X");
                    cmbTipoDocumento.SelectedItem = "Nota Debito X";
                    cmbTipoDocumento.Enabled = false;
                    this.Text = @"Nota de Debito a Clientes ";
                    break;
                default:
                    this.Text = @"AJUSTE INTERNO a CLIENTES";
                    break;
            }

            txtAlicuotaIIBB.Text = 0.ToString("P4");
            txtImporteIIBB.Text = 0.ToString("C2");
            txtImporteDescuento.Text = 0.ToString("C2");
            txtDescuentoPorcentaje.Text = 0.ToString("P2");
            txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(dtpFechaDocumento.Value).ToString("N2");
            if (_facturaIdStruct.IdFactura == 0)
            {
                CreateNewDocumentT400_T401InMemory();
                LoadHeaderDataFromMasterData();
                AccionSegunIndicadorInicial();
            }
            else
            {
                LoadInitialDataFromExistingDocument();
                _docData = new XCustomerNcd(_facturaIdStruct.IdFactura);
                _docData.CreateNewItemListInMemory(_listaItems);
                t0301NCDIBindingSource.DataSource = _listaItems.ToList();
                if (_estado == DocumentFIStatusManager.StatusHeader.Pendiente)
                {
                    LoadHeaderDataFromMasterData();
                }
                else
                {
                    LoadHeaderDataFromDocumento();
                    LoadTotalesFromHeader400();
                }
            }
            SegunTipoDocumento();
            AccionEstadoDocumento();
            MapTotalesFromMemory();
        }

        private void LoadTotalesFromHeader400()
        {
            _docData.RecalculaTotalesFromDb();
        }


        //1.-Funcion principal para asignar el metodo que genera en forma
        //Automatica los items de la Nc/d
        private void AccionSegunIndicadorInicial()
        {
            switch (_indicador)
            {
                case "CHR":
                    AccionNdChqRechazado(); //hacer ND solo gastos + mover a interfaz retorno cheque
                    break;
                case "AFACTU":
                    AccionNcAnulaFacturaCompleta(); //alta idf asociada
                    break;
                case "DEVKG": //alta idf asociada
                    AccionNcMaterial_Kg();
                    break;
                case "DIFTCNC":
                    AccionNcAjusteTC();
                    break;
                case "DIFPRNC":
                    AccionNcDiferenciaPrecio();
                    break;
                case "DTOGRALVTA":
                    AccionDtoGeneralVentas();
                    break;
                case "NDDIFTC":
                    AccionNcAjusteTC();
                    break;
                case "NDOTRO":
                    AccionNdOtrosConceptos();
                    break;
                default:
                    MessageBox.Show(@"Atencion El Tipo de Documento no tiene una Accion Predefinida", @"Informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
        private void LoadInitialDataFromExistingDocument()
        {
            //los datos se cargan siempre desde el documento en T300
            var ncdData = new NcdTableManager().GetNCDHData(_facturaIdStruct.IdRemitoIdNcd);
            if (ncdData == null)
            {
                MessageBox.Show(@"No se puede continuar porque los datos estan incompletos/mal mantenidos",
                    @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            var t400Data = new CustomerInvoice("NCD", _facturaIdStruct.IdFactura).GetHeaderData();
            txtNumeroDocumento.Text = ncdData.NDOC;
            txtTipoCambio.Text = t400Data.TC.ToString("N2");
            txtComentarioInterno.Text = ncdData.COMENTARIO;
            _estado = new DocumentFIStatusManager().MapStatusHeaderFromText(t400Data.StatusFactura);
            _idCliente = t400Data.Cliente;
            _listaItems = new NcdTableManager().GetItemList(_facturaIdStruct.IdRemitoIdNcd);
            _tipoLx = t400Data.TIPOFACT;
            txtIdNCD.Text = _facturaIdStruct.IdRemitoIdNcd.ToString();
            txtIdFactura.Text = _facturaIdStruct.IdFactura.ToString();
            txtTipoLx.Text = _tipoLx;
            _tipoDocumento = ManageDocumentType.GetTipoDocumentoFromTdocString(ncdData.TDOC, _tipoLx);


        }
        private void CreateNewDocumentT400_T401InMemory()
        {
            //La factura no existe en T0400 la crea en memoria
            if (_tipoLx == "L1")
            {
                //**no hago nada con respecto a IIBB porque la mayoria no lleva nada**
                //_alicuotaPercepcion = GetIIBBPercepcion(dtpFechaFactura.Value, txtNumeroCuit.Text);
                //txtAlicuotaIIBB.Text = (_alicuotaPercepcion * 100).ToString("N2");
            }

            //Atencion: El sistema ingresa como nota de debito 1 o 2 y nota de credito 1 o 2
            //Luego se configura desde el tipo de documento si es A,B,M, 
            //No se puede configurar despues si es nota de credito o debito



            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVenta2 ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVenta2)
            {
                //se trata de una NOTA DE DEBITO L1/L2
                _docData = new XCustomerNcd(_idCliente, "NCD");

                //por default pone TIPO A


                _docData.CreateNewHeaderInMemory(_tipoDocumento, _idCliente, dtpFechaDocumento.Value, _tipoLx,
                    Convert.ToDecimal(txtTipoCambio.Text),
                    descuento: FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text),
                    alicuotaIIBB: FormatAndConversions.CPorcentajeADecimal(txtAlicuotaIIBB.Text), idRemito: 0);

                _docData.CreateNewItemListInMemory(_listaItems);
            }
            else
            {
                MessageBox.Show(@"El Tipo de documento ingresado no se encuentra desarrollado. Comunique al Administrador", @"Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }
        private void LoadHeaderDataFromMasterData()
        {
            txtTipoLx.Text = _tipoLx;
            txtTipoLx.BackColor = _tipoLx == "L1" ? Color.GreenYellow : Color.Crimson;

            var ncdData = new NcdTableManager().GetNCDHData(_facturaIdStruct.IdRemitoIdNcd);

            var cli = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtIdCliente.Text = _idCliente.ToString();
            txtRazonSocial.Text = cli.cli_rsocial;
            txtFantasia.Text = cli.cli_fantasia;
            txtCuit.Text = cli.CUIT;

            if (new CuitValidation().ValidarCuit(txtCuit.Text))
            {
                txtCuitValidado.BackColor = Color.GreenYellow;
            }
            else
            {
                txtCuitValidado.BackColor = Color.Red;
                if (_tipoLx == "L1")
                {
                    MessageBox.Show(@"Atencion el CUIT no se encuentra validado!", @"Error en CUIT", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            txtEstadoDocumento.Text = _estado.ToString();
            txtNumeroDocumento.Text = @"NO-ASIGNADO";
            //txtNumeroDocumento.Text = ncdData.NDOC;
            //txtTipoDocumento.Text = _tipoDocumento.ToString();
            dtpFechaDocumento.Value = DateTime.Today;
            txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(dtpFechaDocumento.Value).ToString("N2");

            txtDireccionFiscal.Text = cli.Direccion_facturacion;
            txtLocalidad.Text = cli.Direfactu_Localidad;
            txtProvincia.Text = cli.Direfactu_Provincia;
            txtCP.Text = cli.ZIP;

            if (_tipoLx == @"L1")
            {
                txtZtermId.Text = cli.ZTERML1;
                txtZterm.Text = new ZtermManager().GetDescripcionZTerm(cli.ZTERML1);
            }
            else
            {
                txtZtermId.Text = cli.ZTERML2;
                txtZterm.Text = new ZtermManager().GetDescripcionZTerm(cli.ZTERML2);
            }
        }
        private void LoadHeaderDataFromDocumento()
        {
            txtTipoLx.BackColor = _tipoLx == "L1" ? Color.GreenYellow : Color.Crimson;
            var t400Data = new CustomerInvoice("NCD", _facturaIdStruct.IdFactura).GetHeaderData();
            txtTdoc.Text = t400Data.TIPO_DOC;
            _tipoDocumento = ManageDocumentType.GetTipoDocumentoFromTdocString(t400Data.TIPO_DOC, _tipoLx);
            cmbTipoDocumento.Items.Add(_tipoDocumento.ToString());
            var cli = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtIdCliente.Text = _idCliente.ToString();
            txtRazonSocial.Text = cli.cli_rsocial;
            txtFantasia.Text = cli.cli_fantasia;
            txtCuit.Text = cli.CUIT;

            if (new CuitValidation().ValidarCuit(txtCuit.Text))
            {
                txtCuitValidado.BackColor = Color.GreenYellow;
            }
            else
            {
                txtCuitValidado.BackColor = Color.Red;
            }

            var ncdH = new ZContaNotaCreditoConT400(_facturaIdStruct.IdRemitoIdNcd,  _facturaIdStruct.IdFactura).GetDocumentoHeader();
            //   txtNumeroDocumento.Text = ncdH.NDOC;
            txtEstadoDocumento.Text = _estado.ToString();

            if (_tipoLx == "L1")
            {
                txtNumeroDocumento.Text = t400Data.PV_AFIP + "-" + t400Data.ND_AFIP;
            }
            else
            {

            }

            // txtNumeroDocumento.Text = @"NO-ASIGNADO";
            //txtTipoDocumento.Text = _tipoDocumento.ToString();
            dtpFechaDocumento.Value = t400Data.FECHA;
            txtTipoCambio.Text = t400Data.TC.ToString("C2");
            txtDireccionFiscal.Text = cli.Direccion_facturacion;
            txtLocalidad.Text = cli.Direfactu_Localidad;
            txtProvincia.Text = cli.Direfactu_Provincia;
            txtCP.Text = cli.ZIP;

            txtZterm.Text = _tipoLx == "L1" ? cli.ZTERML1 : cli.ZTERML2;
        }
        private void SegunTipoDocumento()
        {
            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVenta2 ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA)
            {

            }

            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVenta2 ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA)
            {

            }

        }
        private void AccionEstadoDocumento()
        {
            btnSolicitarCAE.Enabled = false;
            btnSetContabilizada.Enabled = false;
            btnSetRegistrado.Enabled = false;
            btnImprimir.Enabled = true;
            dgvItems.Enabled = false;
            dtpFechaDocumento.Enabled = false;
            txtTipoCambio.ReadOnly = true;
            btnArba.Enabled = false;
            txtDescuentoPorcentaje.ReadOnly = true;
            txtImporteDescuento.ReadOnly = true;
            btnSetEstadoInicial.Enabled = false;
            btnCancelar.Enabled = false;
            txtComentarioInterno.ReadOnly = true;
            switch (_estado)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    btnSetRegistrado.Enabled = true;
                    dgvItems.Enabled = true;
                    dtpFechaDocumento.Enabled = true;
                    txtTipoCambio.ReadOnly = false;
                    txtDescuentoPorcentaje.ReadOnly = false;
                    txtImporteDescuento.ReadOnly = false;
                    if (_tipoLx == "L1")
                    {
                        btnArba.Enabled = true;
                    }
                    txtComentarioInterno.ReadOnly = false;
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    btnSetEstadoInicial.Enabled = true;
                    btnSetContabilizada.Enabled = true;
                    txtComentarioInterno.ReadOnly = false;
                    break;
                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    break;
                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    break;
                case DocumentFIStatusManager.StatusHeader.Impresa:
                    break;
                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    break;
                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    btnSolicitarCAE.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #region botones

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (_estado == DocumentFIStatusManager.StatusHeader.Pendiente && _facturaIdStruct.IdRemitoIdNcd > 0)
            {
                if (MessageBox.Show(
                    @"Confirma que desea Salir? Esta accion eliminara toda la informacion de este documento y tendra que comenzarlo nuevamente",
                    @"Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    new NcdTableManager().RemoveNcdTableData(_facturaIdStruct.IdRemitoIdNcd);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        private void btnChequeRechazado_Click(object sender, EventArgs e)
        {
            AccionNdChqRechazado();
        }
        private void btnSetRegistrado_Click(object sender, EventArgs e)
        {
            if (!ValidaRegistradoOK())
                return;

            var confirma = MessageBox.Show(@"Confirma la REGISTRACION del Documento?", @"Registracion de Documento",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirma == DialogResult.No)
                return;
            _facturaIdStruct = _docData.GrabaDocumentoToDatabase();

            if (new DocumentFIStatusManager().SetStatusRegistrado(_facturaIdStruct.IdFactura))
            {
                txtEstadoDocumento.Text = DocumentFIStatusManager.StatusHeader.Registrada.ToString().ToUpper();
                txtIdFactura.Text = _facturaIdStruct.IdFactura.ToString();
                txtIdFactura.BackColor = Color.GreenYellow;
                txtIdNCD.Text = _facturaIdStruct.IdRemitoIdNcd.ToString();
                txtIdNCD.BackColor = Color.GreenYellow;
                //txtIdFacturaX.Text = _facturaIdStruct.IdFacturaX.ToString();
                txtEstadoDocumento.BackColor = Color.GreenYellow;
                _estado = DocumentFIStatusManager.StatusHeader.Registrada;
                AccionEstadoDocumento();
                _docData.UpdateT0300NCHFromT0400();
                //new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _facturaIdStruct.IdFactura);
                cmbTipoDocumento.Enabled = false;
            }
            else
            {
                MessageBox.Show(@"La Factura no pudo ser pasada a estado REGISTRADA", @"Error en Cambio de Estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSetEstadoInicial_Click(object sender, EventArgs e)
        {
            var confirma =
                MessageBox.Show(
                    @"Confirma el regreso del documento a estado PENDIENTE (se permite modificacion de valores)?",
                    @"Registracion de Documento",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirma == DialogResult.No)
                return;

            if (new DocumentFIStatusManager().SetStatusPendiente(_facturaIdStruct.IdFactura))
            {
                txtEstadoDocumento.Text = DocumentFIStatusManager.StatusHeader.Pendiente.ToString().ToUpper();
                _estado = DocumentFIStatusManager.StatusHeader.Pendiente;
                txtEstadoDocumento.BackColor = Color.Orange;
                txtIdFactura.Text = @"N/D";
                txtIdNCD.Text = _facturaIdStruct.IdRemitoIdNcd.ToString();
                txtIdNCD.BackColor = Color.Red;
                _facturaIdStruct.IdFactura = 0;
                _facturaIdStruct.IdFacturaX = 0;
                _docData.SetStatusPendienteInMemory();
                cmbTipoDocumento.Enabled = true;
            }
            AccionEstadoDocumento();
        }
        private void btnSetContabilizada_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(@"Confirma la Contabilizacion de este documento?",
                @"Contabilizacion de Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;


            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVenta2 ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoClientesB ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoClientesM)
            {
                var conta = new XContabilizaNotaDebito(_facturaIdStruct.IdFactura).ContabilizacionCompleta();
                if (conta.IdCtaCte > 0)
                {
                    txtIdCtaCte.Text = conta.IdCtaCte.ToString();
                    txtNAS.Text = conta.NumeroAsientoIdDocu.ToString();
                    txtNumeroDocumento.Text = conta.NumeroDocumentoCompleto;

                    new NcdTableManager().UpdateDataAfterConta(_facturaIdStruct.IdRemitoIdNcd,
                        conta.NumeroDocumentoCompleto, conta.IdCtaCte,
                        conta.IdFacturaX, conta.NumeroAsientoIdDocu);

                    var listaChR = new ChequeRechazadoManager().GetListaChequesRechazadosEnNotaDebito(_facturaIdStruct.IdRemitoIdNcd);
                    foreach (var l in listaChR)
                    {
                        new ChequeRechazadoManager().CompleteChrDataAfterContabilizacionNotaDebito(
                            l, conta.NumeroAsientoIdDocu, conta.NumeroDocumentoCompleto);
                    }

                }
                else
                {
                    MessageBox.Show(@"Ha Ocurrido un error Grave durante la contabilizacion. Notifique a IT Urgente",
                        @"Error en Contabilizacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var conta = new ZContaNotaCreditoConT400(_facturaIdStruct.IdRemitoIdNcd,_facturaIdStruct.IdFactura).ContabilizacionCompleta();
                if (conta.IdCtaCte > 0)
                {
                    txtIdCtaCte.Text = conta.IdCtaCte.ToString();
                    txtNAS.Text = conta.NumeroAsientoIdDocu.ToString();

                    new NcdTableManager().UpdateDataAfterConta(_facturaIdStruct.IdRemitoIdNcd,
                        conta.NumeroDocumentoCompleto, conta.IdCtaCte,
                        conta.IdFacturaX, conta.NumeroAsientoIdDocu);
                }
                else
                {
                    MessageBox.Show(@"Ha Ocurrido un error Grave durante la contabilizacion. Notifique a IT Urgente",
                        @"Error en Contabilizacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            MessageBox.Show(@"Se ha contabilizado correctamente el documento", @"Contabilizacion Correcta",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_tipoLx == "L1")
            {
                _estado = DocumentFIStatusManager.StatusHeader.PendienteCAE;
                MessageBox.Show(@"Recuerde solicitar el CAE!", @"Aviso al Usuario", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                _estado = DocumentFIStatusManager.StatusHeader.Aprobada;
            }

            if (_listaDevolucionKg.Count > 0)
            {
                foreach (var dev in _listaDevolucionKg)
                {
                    new ManageRetornoMaterial().UpdateNumeroNc(dev.IdDev, txtNumeroDocumento.Text, dev.Kg);
                }
            }



            txtEstadoDocumento.Text = _estado.ToString();

            //_docData.UpdateAsientoData(conta.IdCtaCte, conta.NumeroAsientoIdDocu, conta.NumeroAsientoX1X2);
            AccionEstadoDocumento();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var f = new FrmFI25RefacturacionDocumento();
            f.Show();
        }

        #endregion


        #region AccionSegunIndicador

        private void AddRegistroNDOtrosConceptos()
        {
            using (var f0 = new FrmNcdAddOtherConcept(_idCliente, _tipoLx, _tipoDocumento))
            {
                var dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    AddRegistroItemNcd(f0.item, f0.descripcion, f0.cantidad, f0.precioU, f0.glventas);
                }
            }
        }


        private void AddRegistroItemNcd(string item, string descripcion, decimal cantidad, decimal precioUnitario, string gl, string moneda = "ARS")
        {
            var iva21 = _tipoLx == "L1";

            var data = new T0301_NCD_I()
            {
                MON = moneda,
                //IDITEM = AsignaNumeroItem(),
                CANT = cantidad,
                Descripcion = descripcion,
                GL = gl,
                IDCHE = null,
                ITEM = item,
                IVA21 = iva21,
                PUNITARIO = precioUnitario,
                PTOTAL = precioUnitario * cantidad,
            };
            _listaItems.Add(data);
            MapTotalesFromMemory();
        }

        private void AccionNcMaterial_Kg()
        {
            //Esta funcion es para hacer NC por Devolucion de KG ya facturados.-
            //por una cuestion de control solo se puede hacer despues de haber ingresado la devolucion.-

            //using (var f0 = new FrmFi54NcDevolucion(_idCliente, _tipoLx))
            //{
            //    DialogResult dr = f0.ShowDialog();
            //    if (dr == DialogResult.OK)
            //    {
            //        _idFacturaSeleccionada = f0.IdFactura;
            //        _kgSeleccionados = f0.KgNotaCredito;
            //        _idItemFacturaSeleccionada = f0.IdFacturaItem;
            //        if (f0.IdDevolucion > 0)
            //        {
            //            var itemDev = new Devolucion
            //            {
            //                IdDev = f0.IdDevolucion,
            //                Kg = f0.KgNotaCredito
            //            };

            //            _listaDevolucionKg.Add(itemDev);
            //        }


            //        if (_idFacturaSeleccionada == null)
            //            return;

            //        if (_idItemFacturaSeleccionada == null)
            //            return;

            //        if (_kgSeleccionados <= 0)
            //            return;


                    

            //        AddRegistroItemNcd((int)_idFacturaSeleccionada, (int)_idItemFacturaSeleccionada, _kgSeleccionados);
            //        AsignaNumeroItem();
            //        _docData.CreateNewItemListInMemory(_listaItems); //:)
            //        t0301NCDIBindingSource.DataSource = _listaItems.ToList();
            //        MapTotalesFromMemory();
            //    }
            //}
        }
        
        private void AccionNcAnulaFacturaCompleta()
        {
            using (var f0 = new FrmFi53SeleccionFacturaAnular(_idCliente, _tipoLx))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _idFacturaSeleccionada = f0.Id400Selected; 
                    if (_idFacturaSeleccionada == null) return;
                    AddItemsFacturaAnulada(_idFacturaSeleccionada.Value);
                    AsignaNumeroItem();
                    _docData.CreateNewItemListInMemory(_listaItems);
                    _docData.AddDocumentoAsociado(_idFacturaSeleccionada.Value);  //modificacion RG
                    var r = _docData.UpdateHeaderTotalesWhenAnulaFacturaCompleta(_idFacturaSeleccionada.Value);
                    if (r == false)
                    {
                        MessageBox.Show(@"Hay una diferencia en los totales de los documentos/contra-documento",
                            @"Error en Totales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    t0301NCDIBindingSource.DataSource = _listaItems.ToList();
                }
            }
            btnAddMaterialKg.Enabled = false;
            btnAddOther.Enabled = false;
            btnChequeRechazado.Enabled = false;
        }
        private void AccionNdChqRechazado()
        {
            using (var f0 = new FrmSeleccionChequeRechazadoCliente(_idCliente, _tipoLx))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _idChequeRechazado = f0.IdChequeSeleccionado;
                    if (_idChequeRechazado == null)
                        return;

                    AddChequeRechazado((int)_idChequeRechazado);
                    AddRegistroGastosBancarios();
                    AsignaNumeroItem();
                    _docData.CreateNewItemListInMemory(_listaItems); //:)
                    t0301NCDIBindingSource.DataSource = _listaItems.ToList();
                }
            }
        }
        private void AccionNcDiferenciaPrecio()
        {
            //Esta funcion es para hacer NC por diferencia de Precio
            using (var f0 = new FrmFi55SeleccionDocDiferenciaPrecio(_tipoDocumento, _tipoLx, _idCliente))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _idFacturaSeleccionada = f0.IdFacturaSeleccionada;
                    _idItemFacturaSeleccionada = f0.IdItemSeleccionado;
                    _nuevoPrecioU = f0.NuevoPrecioUnitario;
                    if (_idFacturaSeleccionada == null)
                        return;
                    if (_nuevoPrecioU <= 0)
                        return;

                    

                    AddRecordDiferenciaPrecioUnitario(_idFacturaSeleccionada.Value, _idItemFacturaSeleccionada.Value, _nuevoPrecioU);
                    AsignaNumeroItem();
                    _docData.CreateNewItemListInMemory(_listaItems);
                    t0301NCDIBindingSource.DataSource = _listaItems.ToList();
                    MapTotalesFromMemory();
                }
            }
        }





        //ND Otros Conceptos - Permite agregar items sueltos simil factura
        private void AccionNdOtrosConceptos()
        {
            AddRegistroNDOtrosConceptos();
            AsignaNumeroItem();
            t0301NCDIBindingSource.DataSource = _listaItems.ToList();
            MapTotalesFromMemory();
        }

        private void AccionDtoGeneralVentas()
        {
            AddRegistroDescuentoGeneralVentas();
            AsignaNumeroItem();
            t0301NCDIBindingSource.DataSource = _listaItems.ToList();

            //Esta funcion es para hacer NC por descuento general en facturacion

        }


        private void AccionNcAjusteTC()
        {
            //Esta funcion es para hacer NC o ND por Ajuste en Tipo de Cambio
            using (var f0 = new FrmFi56SeleccionDocumentoAjusteTc(_tipoDocumento, _tipoLx, _idCliente))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _idFacturaSeleccionada = f0.IdFacturaSeleccionada;
                    _nuevoTC = f0.NuevoTC;

                    if (_idFacturaSeleccionada == null)
                        return;

                    if (_nuevoTC <= 0)
                        return;

                    // new FixFactuPreciosToNewModel().FixFacturaPrecios(_idFacturaSeleccionada.Value);
                    AddRecordDiferenciaPorTipoCambio(_idFacturaSeleccionada.Value, _nuevoTC);
                    AsignaNumeroItem();
                    // _docData.CreateNewItemListInMemoryForDeltaPrecio(_listaItems); //:)
                    t0301NCDIBindingSource.DataSource = _listaItems.ToList();
                }
            }
        }
        #endregion
        private int AsignaNumeroItem()
        {
            if (_listaItems.Count == 0)
                return 1;
            int item = 1;
            foreach (var i in _listaItems)
            {
                i.IDITEM = item;
                item++;
            }
            return item;
        }

        #region Acciones Predefinidas



        private void AddRegistroDescuentoGeneralVentas()
        {
            var data = new T0301_NCD_I()
            {
                MON = "ARS",
                IDITEM = AsignaNumeroItem(),
                CANT = 1,
                Descripcion = "Descuento",
                GL = "4.1.3",
                IDCHE = null,
                ITEM = "DESCGRAL",
                IVA21 = false,
                PUNITARIO = 0,
                PTOTAL = 0,
                //PIVA = 0,
            };

            if (_tipoLx == "L1")
            {
                data.IVA21 = true;
            }

            _listaItems.Add(data);
            MapTotalesFromMemory();
        }



        //
        private void AddRecordDiferenciaPrecioUnitario(int idFactura, int idItem, decimal nuevoPrecioU)
        {
            var importesHeader = new NcdCalculoDiferenciaTc().RecalculaimporteUnitPriceChanged(idFactura, idItem, nuevoPrecioU);
            var headerFacturaOri = GetTabla400401.GetDatosFactura(idFactura);
            var precioAnterior = headerFacturaOri.TotalFacturaN;
            var nuevoPrecio = importesHeader.ImporteTotalNetoFinal;
            var variacionPrecio = precioAnterior - nuevoPrecio;
            var iva21 = headerFacturaOri.TIPOFACT == "L1";

            var itemData = new CustomerInvoice("NCDX", idFactura).GetItemData(idItem);
            var descripcion = $"Dif.Precio {itemData.ITEM} x {itemData.KGDESPACHADOS_R} Kg";
            var data = new T0301_NCD_I()
            {
                MON = importesHeader.MonedaDocumento,
                //IDITEM = AsignaNumeroItem(),
                CANT = 0,
                Descripcion = descripcion,
                GL = "4.1.4.1", //GL de Diferencia por NCD
                IDCHE = null,
                ITEM = "ZAJCC",
                IVA21 = iva21,
                PUNITARIO = variacionPrecio,
                PTOTAL = variacionPrecio,
            };
            _listaItems.Add(data);
            //_docData.CreateNewItemListInMemoryForDeltaPrecio(_listaItems, importesHeader, idFactura); //:)
            //var z = _docData.GetTotalesFromMemory();
            //  _listaItems[_listaItems.Count - 1].PUNITARIO = z.Bruto;
            //   _listaItems[_listaItems.Count - 1].PTOTAL = z.Bruto;
            MapTotalesFromMemory();

        }

        private void AddRecordDiferenciaPorTipoCambio(int idFactura, decimal nuevoTC)
        {
            var importesHeader = new NcdCalculoDiferenciaTc().RecalculaimporteTC(idFactura, nuevoTC);
            var headerFacturaOri = GetTabla400401.GetDatosFactura(idFactura);
            var precioAnterior = headerFacturaOri.TotalFacturaN;
            var nuevoPrecio = importesHeader.ImporteTotalNetoFinal;
            decimal variacionPrecio = 0;
            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVentaA ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoVenta2)
            {
                variacionPrecio = precioAnterior - nuevoPrecio;
            }
            else
            {
                variacionPrecio = nuevoPrecio - precioAnterior;
            }

            var iva21 = headerFacturaOri.TIPOFACT == "L1";
            var descripcion = "Diferencia de precio por var. Tipo de Cambio";

            var data = new T0301_NCD_I()
            {
                MON = importesHeader.MonedaDocumento,
                IDITEM = AsignaNumeroItem(),
                CANT = 0,
                Descripcion = descripcion,
                GL = "4.1.4.1", //GL de Diferencia por NCD
                IDCHE = null,
                ITEM = "ZAJCC",
                IVA21 = iva21,
                PUNITARIO = variacionPrecio,
                PTOTAL = variacionPrecio,
            };
            _listaItems.Add(data);
            _docData.CreateNewItemListInMemoryForDeltaPrecio(_listaItems, importesHeader, idFactura); //:)
            var z = _docData.GetTotalesFromMemory();
            _listaItems[_listaItems.Count - 1].PUNITARIO = z.Bruto;
            _listaItems[_listaItems.Count - 1].PTOTAL = z.Bruto;
            MapTotalesFromMemory();

        }
        private void AddRegistroItemNcd(int idFactura, int idItem, decimal kg)
        {
            var dataH = GetTabla400401.GetDatosFactura(idFactura);
            var dataItem = new NcdSeleccionItemsKg().GetDatosFacturaItem(idFactura, idItem);
            var numeroDocumento = new CustomerInvoice("NCD", idFactura).GetNumeroDocumentoCompleto();
            var descripcion = $"** {dataItem.DESC_REMITO} S/Doc: {dataH.TIPO_DOC} # {numeroDocumento}";

            var data = new T0301_NCD_I()
            {
                MON = dataH.FacturaMoneda,
                IDITEM = AsignaNumeroItem(),
                CANT = kg * -1,
                Descripcion = descripcion,
                GL = dataItem.GLV,
                IDCHE = null,
                ITEM = dataItem.ITEM,
                IVA21 = dataItem.IVA21,
                PUNITARIO = dataItem.PRECIOU_FACT_ARS,
                PTOTAL = dataItem.PRECIOU_FACT_ARS * kg,
            };
            _listaItems.Add(data);
            MapTotalesFromMemory();
        }


        /// <summary>
        /// Funcion Agrega Registro Anulacion de Factura
        /// </summary>
        private void AddItemsFacturaAnulada(int idFacturaAnula)
        {
            var dataF = GetTabla400401.GetDatosFactura(idFacturaAnula);
            var numeroDocumento = new CustomerInvoice("NCD", idFacturaAnula).GetNumeroDocumentoCompleto();
            var descripcion = $"Anulacion Documento: {dataF.TIPO_DOC} # {numeroDocumento}";
            var dataI = GetTabla400401.GetItemsDocumentoSeleccionado(idFacturaAnula).ToList();
            foreach (var i in dataI)
            {
                var data = new T0301_NCD_I()
                {
                    MON = dataF.FacturaMoneda,
                    IDITEM = AsignaNumeroItem(),
                    CANT = i.KGDESPACHADOS_R.Value * -1,
                    Descripcion = "**" + i.DESC_REMITO,
                    GL = i.GLV,
                    IDCHE = idFacturaAnula,
                    ITEM = i.ITEM,
                    IVA21 = i.IVA21,
                    PUNITARIO = i.PRECIOU_FACT_ARS,
                    PTOTAL = i.PRECIOT_FACT_ARS,
                };
                _listaItems.Add(data);
            }
            MapTotalesFromMemory();
        }
        private void AddChequeRechazado(int idchequeR)
        {
            var datach = new ChequesManager().GetCheque(idchequeR);
            var descripcion =
                $"Rechazo Ch.# {datach.CHE_NUMERO} Banco {datach.T0160_BANCOS.BCO_SHORTDESC} - Importe {datach.IMPORTE.Value.ToString("C2")}";
            var data = new T0301_NCD_I()
            {
                MON = "ARS",
                IDITEM = AsignaNumeroItem(),
                CANT = 1,
                Descripcion = descripcion,
                GL = "1.0.0.8",
                IDCHE = idchequeR,
                ITEM = "CHRECH",
                IVA21 = false,
                PUNITARIO = datach.IMPORTE.Value,
                PTOTAL = datach.IMPORTE.Value,
                PIVA = 0,
            };
            _listaItems.Add(data);
            MapTotalesFromMemory();
        }
        private void AddRegistroGastosBancarios()
        {
            var data = new T0301_NCD_I()
            {
                MON = "ARS",
                IDITEM = AsignaNumeroItem(),
                CANT = 1,
                Descripcion = "Gastos Bancarios",
                GL = "4.5.2",
                IDCHE = null,
                ITEM = "GSBAN",
                IVA21 = false,
                PUNITARIO = 0,
                PTOTAL = 0,
                //PIVA = 0,
            };

            if (_tipoLx == "L1")
            {
                data.IVA21 = true;
            }

            _listaItems.Add(data);
            MapTotalesFromMemory();
        }

        #endregion

        //Boton Borrar en DGV
        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvItems[e.ColumnIndex, e.RowIndex].Value.ToString();
                switch (cellValue)
                {
                    case "DEL":
                    {
                        var iditem = Convert.ToInt32(dgvItems[0, e.RowIndex].Value);
                        var x = _listaItems.Find(c => c.IDITEM == iditem);
                        _listaItems.Remove(x);
                        AsignaNumeroItem();
                        _docData.CreateNewItemListInMemory(_listaItems); //:)
                        t0301NCDIBindingSource.DataSource = _listaItems.ToList();
                        MapTotalesFromMemory();
                    }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        //Edicion de Item en DGV
        private void dgvItems_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if ((senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) == false && e.RowIndex >= 0)
            {
                var iditem = Convert.ToInt32(dgvItems[0, e.RowIndex].Value);
                using (var f0 = new FrmCustomerNcdEditItem(_listaItems, iditem, _tipoLx))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        _listaItems = f0._list;
                        t0301NCDIBindingSource.DataSource = _listaItems.ToList();
                        _docData.CreateNewItemListInMemory(_listaItems); //:)
                        MapTotalesFromMemory();
                    }
                }
            }
        }
        private void MapTotalesFromMemory()
        {
            var resultado = _docData.GetTotalesFromMemory();
            txtImporteInicial.Text = resultado.Bruto.ToString("C2");
            txtDescuentoPorcentaje.Text = resultado.PorDescuento.ToString("P2");
            txtImporteDescuento.Text = resultado.ImporteDescuento.ToString("C2");
            txtSubtotal.Text = (resultado.Bruto - resultado.ImporteDescuento).ToString("C2");
            txtBaseImponible.Text = resultado.BaseImponible.ToString("C2");
            txtIva21.Text = resultado.ImporteIVA.ToString("C2");
            txtIva105.Text = 0.ToString("C2");
            txtAlicuotaIIBB.Text = resultado.AlicuotaIIBB.ToString("P2");
            //txtImporteIIBB.Text = resultado.PercepcionIIBB.ToString("C2");
            txtTotalFactura.Text = resultado.NetoFinal.ToString("C2");
            txtImportePercepcion.Text = resultado.ImporteIIBB.ToString("C2");
        }
        private bool ValidaRegistradoOK()
        {
            if (_listaItems.Count == 0)
            {
                MessageBox.Show(@"El documento no contiene Items", @"Datos Incompletos or Erroneos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #region Acciones TextBox
        private void txtDescuentoPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtDescuentoPorcentaje_Leave(object sender, EventArgs e)
        {
            var dtoIndice = FormatAndConversions.CPorcentajeADecimal(txtDescuentoPorcentaje.Text);
            txtImporteDescuento.Text =
                (FormatAndConversions.CCurrencyADecimal(txtImporteInicial.Text) * dtoIndice).ToString("C2");
            txtDescuentoPorcentaje.Text = dtoIndice.ToString("P2");
            _docData.UpdateImportesIfPorcentajeDescuentoChanges(dtoIndice);
            MapTotalesFromMemory();
        }
        private void txtImporteDescuento_Leave(object sender, EventArgs e)
        {
            txtDescuentoPorcentaje.Text =
                (FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text) /
                 FormatAndConversions.CCurrencyADecimal(txtImporteInicial.Text)).ToString("P2");

            txtImporteDescuento.Text =
                FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text).ToString("C2");
            _docData.UpdateImportesIfImporteDescuentoChanges(
                FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text));
            MapTotalesFromMemory();
        }
        private void txtAlicuotaIIBB_Leave(object sender, EventArgs e)
        {
            var por = FormatAndConversions.CPorcentajeADecimal(txtAlicuotaIIBB.Text);
            txtImporteIIBB.Text =
                (por * FormatAndConversions.CCurrencyADecimal(txtBaseImponible.Text)).ToString("C2");
            _docData.UpdateImportesIfAlicuotaIIBBChanges(por);
            MapTotalesFromMemory();
        }
        private void txtAlicuotaIIBB_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtImporteIIBB_Leave(object sender, EventArgs e)
        {
            var importe = FormatAndConversions.CCurrencyADecimal(txtImporteIIBB.Text);
            txtImporteIIBB.Text = importe.ToString("C2");
            MapTotalesFromMemory();
        }
        private void dtpFechaDocumento_ValueChanged(object sender, EventArgs e)
        {
            txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(dtpFechaDocumento.Value).ToString("C2");
            _docData.UpdateImportesIfExchangeRateChanges(
                FormatAndConversions.CCurrencyADecimal(txtTipoCambio.Text));
        }
        private void txtTipoCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtTipoCambio_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipoCambio.Text))
            {
                MessageBox.Show(@"El tipo de cambio es incorrecto. Se coloca el TC Default", @"Tipo de Cambio Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            _docData.UpdateImportesIfExchangeRateChanges(Convert.ToDecimal(txtTipoCambio.Text));
        }
        private void txtComentarioInterno_Leave(object sender, EventArgs e)
        {
            _docData.UpdateObservacionesIfChanges(txtComentarioInterno.Text);
        }


        #endregion
        private bool PermiteSolicitarCAE()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _facturaIdStruct.IdFactura);
                if (data == null)
                    return false;

                if (data.TIPOFACT != "L1")
                    return false;

                if (data.StatusFactura.ToUpper() !=
                    DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString().ToUpper())
                    return false;

                if (string.IsNullOrEmpty(data.CAE))
                    return true;
                return false;
            }
        }

        private void SolicitudCAE()
        {
            var fe = new FacturacionElectronicaTecser(_modoAfip);
            FEGetDataStructure resultado;
            if (_idFacturaSeleccionada != null)
            {
                resultado = fe.SolicitudCAEFromT0400(_facturaIdStruct.IdFactura, _idFacturaSeleccionada,null,null);
            }
            else
            {
                resultado = fe.SolicitudCAEFromT0400(_facturaIdStruct.IdFactura, null, dtpFechaDocumento.Value, null);
            }
            
            if (resultado.Resultado == "A")
            {
                txtCAE.Text = resultado.CAE;
                txtCAEVencimiento.Text = resultado.VencimientoCAE.ToString("d");
                txtNumeroDocumento.Text = resultado.NumeroDocumentoOtorgadoCompleto;

                fe.UpdateDataAfterDocumentNumberGetFromAFIP(_facturaIdStruct.IdFactura,
                    resultado.PuntoVenta, resultado.ComprobanteHasta, resultado.CAE,
                    resultado.VencimientoCAE, Convert.ToInt32(txtNAS.Text));

                //Funcion unicamente para NCD nunca va a tener Remito Asociado
                //new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _facturaIdStruct.IdFactura,txtNumeroDocumento.Text, false);
                //

                //Funcion unicamente para NCD no necesita chequear el tipo de documento
                new NcdTableManager().UpdateOnlyDocumentNumber(_facturaIdStruct.IdRemitoIdNcd, txtNumeroDocumento.Text);

                if (string.IsNullOrEmpty(txtImportePercepcion.Text))
                    txtImportePercepcion.Text = 0.ToString("C2");

                if (FormatAndConversions.CCurrencyADecimal(txtImportePercepcion.Text) != 0)
                {
                    var idfx = Convert.ToInt32(_facturaIdStruct.IdFacturaX);
                    new PercepcionesManager().AddFacturaPercepcion(idfx);
                }
                _estado = DocumentFIStatusManager.StatusHeader.Aprobada;
                txtEstadoDocumento.Text = _estado.ToString();
                txtEstadoDocumento.BackColor = Color.ForestGreen;
                AccionEstadoDocumento();
            }
            else
            {
                MessageBox.Show(@"Ha Ocurrido un error al solicitar el CAE", @"Error en SOLICITUD DE CAE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AccionEstadoDocumento();
        }
        private void btnSolicitarCAE_Click(object sender, EventArgs e)
        {
            if (new FacturacionElectronicaTecser(_modoAfip).CheckSiPermiteSolicitarCAE(_facturaIdStruct.IdFactura) == false)
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

            if (_modoAfip == ModoEjecucion.Testeo)
            {
                MessageBox.Show(
                    @"Atencion se esta ejecutando la aplicacion en modo TESTEO" + Environment.NewLine +
                    @"El CAE otorgado NO SERA VALIDO",
                    @"Modo Aplicacion = * TESTEO *", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            SolicitudCAE();
        }
        private bool CheckAllowToPrint()
        {
            return true;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!CheckAllowToPrint())
                return;

            if (txtTipoLx.Text == @"L1")
            {
                if (ckPreImpreso.Checked)
                {
                    var f = new RpvFacturaL1(_facturaIdStruct.IdFactura, ckImprimirMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked, ckCodBarra.Checked);
                    f.Show();
                }
                else
                {
                    var f = new RpvFacturaL1_PDF(_facturaIdStruct.IdFactura, ckImprimirMensajeMora.Checked,
                        txtObservacionesAdicionalesImprimir.Text, ckImpresionConsolidada.Checked, ckCodBarra.Checked);
                    f.Show();
                }
            }
            else
            {
                var f = new RpvNcdl2(_facturaIdStruct.IdFactura, ckSaldoTotalAdeudadoL2.Checked,
                    ckImpresionConsolidada.Checked);
                f.Show();
            }
        }

        private void btnAddMaterialKg_Click(object sender, EventArgs e)
        {
            AccionNcMaterial_Kg();
        }

        private void btnAddOther_Click(object sender, EventArgs e)
        {
            AccionSegunIndicadorInicial();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRegistroGastosBancarios();
        }


        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoDocumento.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                switch (cmbTipoDocumento.SelectedItem.ToString())
                {
                    case "Nota Credito A":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaCreditoVentaA;
                        //txtTipoDocumento.Text = _tipoDocumento.ToString();
                        txtTdoc.Text = @"NC";
                        break;
                    case "Nota Credito B":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaCreditoClientesB;
                        //txtTipoDocumento.Text = _tipoDocumento.ToString();
                        txtTdoc.Text = @"CB";
                        break;

                    case "Nota Credito M":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaCreditoClientesM;
                        //txtTipoDocumento.Text = _tipoDocumento.ToString();
                        txtTdoc.Text = @"CM";
                        break;

                    case "Nota Debito A":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaDebitoVentaA;
                        //txtTipoDocumento.Text = _tipoDocumento.ToString();
                        txtTdoc.Text = @"ND";
                        break;

                    case "Nota Debito B":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaDebitoClientesB;
                        //txtTipoDocumento.Text = _tipoDocumento.ToString();
                        txtTdoc.Text = @"DB";
                        break;

                    case "Nota Debito M":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaDebitoClientesM;
                        //txtTipoDocumento.Text = _tipoDocumento.ToString();
                        txtTdoc.Text = @"DM";
                        break;

                    case "Nota Debito X":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaDebitoVenta2;
                        //txtTipoDocumento.Text = _tipoDocumento.ToString();
                        txtTdoc.Text = @"D2";
                        break;
                    case "Nota Credito X":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaCreditoVenta2;
                        //txtTipoDocumento.Text = _tipoDocumento.ToString();
                        txtTdoc.Text = @"C2";
                        break;
                }

            }
            if (_docData != null)
            {
                _docData.UpdateDocumentType(_tipoDocumento);
            }
        }


        private void txtZterm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void txtObservacionesAdicionalesImprimir_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnArba_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateZterm_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmMdz01ZtermStructure(5, txtZtermId.Text))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    txtZtermId.Text = f0.Condicion;
                    txtZterm.Text = new ZtermManager().GetDescripcionZTerm(f0.Condicion);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_estado == DocumentFIStatusManager.StatusHeader.Pendiente && _facturaIdStruct.IdRemitoIdNcd > 0)
            {
                if (MessageBox.Show(
                    @"Confirma que desea Salir? Esta accion eliminara toda la informacion de este documento y tendra que comenzarlo nuevamente",
                    @"Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    new NcdTableManager().RemoveNcdTableData(_facturaIdStruct.IdRemitoIdNcd);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}