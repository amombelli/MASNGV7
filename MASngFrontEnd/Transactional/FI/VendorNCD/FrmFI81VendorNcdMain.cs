using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.CO.ContaFromDocuments;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;
using Tecser.Business.VBTools;
using TecserEF.Entity;


namespace MASngFE.Transactional.FI.VendorNCD
{
    public partial class FrmFI81VendorNcdMain : Form
    {
        public FrmFI81VendorNcdMain(int idNcd)
        {
            //carga de NCDP Existente
            _idNcd = idNcd;
            InitializeComponent();
        }

        public FrmFI81VendorNcdMain(int idVendor, string tipoLx, ManageDocumentType.TipoDocumento tipoDocumento, string indicador)
        {
            //Creacion de NCDP
            _idVendor = idVendor;
            _tipoLx = tipoLx;
            _estado = DocumentFIStatusManager.StatusHeader.Pendiente;
            _tipoDocumento = tipoDocumento;
            _indicador = indicador;
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------
        private int _idVendor;
        private string _tipoLx;
        private DocumentFIStatusManager.StatusHeader _estado;
        private ManageDocumentType.TipoDocumento _tipoDocumento;
        private readonly string _indicador;
        private List<T0311_NCDP_I> _listaItems = new List<T0311_NCDP_I>();
#pragma warning disable CS0649 // Field 'FrmVendorNcd._id403' is never assigned to, and will always have its default value 0
        private int _id403;
#pragma warning restore CS0649 // Field 'FrmVendorNcd._id403' is never assigned to, and will always have its default value 0
        private int _idNcd;
        private XVendorDocumentBase.VendorFacturaId _docReturn;
        private List<T0156_CHEQUE_RECH> _listaChRechazado = new List<T0156_CHEQUE_RECH>();
        private decimal _ivaGastos = 0;
        private string _tdoc;
        private int signo = 1;
        private DateTime? _fechaDocumento = null;
        private DateTime fechaRechazo;
        private decimal _importeContabilizar;
        private XVendorDocumentBase _docData;

        private int? _idChequeRechazado = null;
#pragma warning disable CS0414 // The field 'FrmVendorNcd._idFacturaSeleccionada' is assigned but its value is never used
        private int? _idFacturaSeleccionada = null; //Anular o Devolver parcial
#pragma warning restore CS0414 // The field 'FrmVendorNcd._idFacturaSeleccionada' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FrmVendorNcd._idItemFacturaSeleccionada' is assigned but its value is never used
        private int? _idItemFacturaSeleccionada = null; //Anular o Devolver parcial
#pragma warning restore CS0414 // The field 'FrmVendorNcd._idItemFacturaSeleccionada' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FrmVendorNcd._kgSeleccionados' is assigned but its value is never used
        private decimal _kgSeleccionados = 0;
#pragma warning restore CS0414 // The field 'FrmVendorNcd._kgSeleccionados' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FrmVendorNcd._nuevoTC' is assigned but its value is never used
        private decimal _nuevoTC = 0;
#pragma warning restore CS0414 // The field 'FrmVendorNcd._nuevoTC' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FrmVendorNcd._nuevoPrecioU' is assigned but its value is never used
        private decimal _nuevoPrecioU = 0;
#pragma warning restore CS0414 // The field 'FrmVendorNcd._nuevoPrecioU' is assigned but its value is never used

        //-----------------------------------------------------------------------


        /// <summary>
        /// Nota de Debito A,2 - Nota de Credito A,2 - Ajuste + / Ajuste -
        /// </summary>
        private void FrmVendorNCD_Load(object sender, EventArgs e)
        {
            _tdoc = ManageDocumentType.GetSystemDocumentType(_tipoDocumento);
            if (_tipoLx == "L2")
            {
                panelIva.Enabled = false;
                panelPercepciones.Enabled = false;
                panelOtrosImpuestos.Enabled = false;
            }

            switch (_tipoDocumento)
            {
                case ManageDocumentType.TipoDocumento.NotaCreditoProveedorA:
                case ManageDocumentType.TipoDocumento.NotaCreditoProveedor2:
                    this.Text = @"FI81- Nota de Credito de Proveedores";
                    signo = -1;
                    break;
                case ManageDocumentType.TipoDocumento.NotaDebitoProveedorA:
                case ManageDocumentType.TipoDocumento.NotaDebitoProveedor2:
                    this.Text = @"FI81- Nota de Debito de Proveedores";
                    signo = 1;
                    break;
                case ManageDocumentType.TipoDocumento.AjusteSaldoNegativo:
                case ManageDocumentType.TipoDocumento.AjusteSaldoPositivo:
                    this.Text = @"FI81 - Ajuste Interno a Proveedores";
                    break;
                default:
                    MessageBox.Show($@"Tipo de Documento {_tipoDocumento} No Manejado");
                    this.Close();
                    break;
            }

            txtSignoConta.Text = signo.ToString();
            txtTdoc.Text = _tdoc;
            txtGLAP.Text = new GLAccountManagement().GetApVendorGl(_idVendor);
            InicializaImportes();

            if (_id403 == 0)
            {
                //Documento Nuevo
                LoadVendorMasterDataDetails();
                cmbMoneda.SelectedItem = "ARS"; //default Conta =ARS
                cmbMoneda.Enabled = false;
                txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");
                //Abre Ventanas de acuerdo al tipo-motivo de NC/ND
                AccionSegunIndicadorInicial();
            }
            else
            {
                //Carga Documento Existente
                LoadInitialDataFromExistingDocument();
                _docData = new XVendorDocumentBase(_id403);
                _docData.CreateNewItemListInMemory(_listaItems, signo);
                t0311NCDPIBindingSource.DataSource = _listaItems.ToList();
                if (_estado == DocumentFIStatusManager.StatusHeader.Pendiente)
                {
                    LoadVendorMasterDataDetails();

                }
                else
                {
                    LoadHeaderDataFromDocumento();
                    LoadTotalesFromHeader400();
                }
            }
            SegunTipoDocumento();
            AccionEstadoDocumento();
        }
        private void InicializaImportes()
        {
            txtImporteBruto.Text = 0.ToString("C2");
            txtImporteDescuento.Text = 0.ToString("C2");
            txtSubtotal.Text = 0.ToString("C2");
            txtBaseImponible.Text = 0.ToString("C2");
            txtTotalIva.Text = 0.ToString("C2");
            txtTotalPercepciones.Text = 0.ToString("C2");
            txtTotalOtroImpuestos.Text = 0.ToString("C2");
            txtImporteNetoFinal.Text = 0.ToString("C2");
            txtIva10.Text = 0.ToString("C2");
            txtIva21.Text = 0.ToString("C2");
            txtIva27.Text = 0.ToString("C2");
            txtPercIIBB.Text = 0.ToString("C2");
            txtPercIva.Text = 0.ToString("C2");
            txtPercGs.Text = 0.ToString("C2");
            txtAlicIIBB.Text = 0.ToString("P3");
            txtAlicIva.Text = 0.ToString("P3");
            txtAlicGs.Text = 0.ToString("P3");
            txtDistritoIIBB.Text = null;
            txtImpuMunicipal.Text = 0.ToString("C2");
            txtImpuProvincial.Text = 0.ToString("C2");
            txtImpuInternos.Text = 0.ToString("C2");
            txtImpuOtros.Text = 0.ToString("C2");
            txtConcpetoNoGravado.Text = 0.ToString("C2");
            txtRedondeoVarios.Text = 0.ToString("C2");
            txtKgTotalFacturados.Text = 0.ToString("N2");
            txtComentarioInterno.Text = null;

        }
        private void CreateNewDocumentT403_T404InMemory()
        {
            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoProveedorA ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoProveedor2 ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoProveedorA ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.NotaCreditoProveedor2)
            {
                if (string.IsNullOrEmpty(txtKgTotalFacturados.Text))
                    txtKgTotalFacturados.Text = 0.ToString("N2");

                //se trata de una NOTA DE DEBITO o de NOTA DE CREDITO
                _docData = new XVendorDocumentBase(_idVendor, "NCDP");
                _docData.CreateNewHeaderInMemory(txtNumeroDocumento.Text, _tipoDocumento, _fechaDocumento.Value,
                    _tipoLx, Convert.ToDecimal(txtTipoCambio.Text),
                    FormatAndConversions.CCurrencyADecimal(txtImporteBruto.Text),
                    FormatAndConversions.CCurrencyADecimal(txtBaseImponible.Text),
                    FormatAndConversions.CCurrencyADecimal(txtImporteNetoFinal.Text),
                    FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text),
                    FormatAndConversions.CCurrencyADecimal(txtIva21.Text),
                    FormatAndConversions.CCurrencyADecimal(txtIva10.Text),
                    FormatAndConversions.CCurrencyADecimal(txtIva27.Text),
                    FormatAndConversions.CPorcentajeADecimal(txtAlicIIBB.Text),
                    FormatAndConversions.CCurrencyADecimal(txtPercIIBB.Text), txtDistritoIIBB.Text,
                    cmbMoneda.SelectedItem.ToString(), txtComentarioInterno.Text,
                    FormatAndConversions.CPorcentajeADecimal(txtAlicIva.Text),
                    FormatAndConversions.CCurrencyADecimal(txtPercIva.Text),
                    Convert.ToDecimal(txtKgTotalFacturados.Text),
                    txtGLAP.Text, signo = 1);
                //20200310 - se agrega signo=1 para manejar signo negativo en nc
                _docData.CreateNewItemListInMemory(_listaItems, signo);
                _docData.CreateListaChequesRechazadoMemoria(_listaChRechazado);
            }
            else
            {
                MessageBox.Show(@"No se ha desarrollado nada para AJUSTES AUN");
                return;
            }
        }
        private void LoadVendorMasterDataDetails()
        {
            txtTipoLx.Text = _tipoLx;
            txtTipoLx.BackColor = _tipoLx == "L1" ? Color.GreenYellow : Color.Crimson;
            var vendor = new VendorManager().GetSpecificVendor(_idVendor);
            txtIdVendor.Text = _idVendor.ToString();
            txtRazonSocial.Text = vendor.prov_rsocial;
            txtFantasia.Text = vendor.prov_fantasia;
            txtCuit.Text = vendor.NTAX1;
            txtTipoProveedor.Text = vendor.TIPO;

            if (new CuitValidation().ValidarCuit(txtCuit.Text))
            {
                txtCuitValidado.BackColor = Color.LimeGreen;
                txtCuitValidado.Text = @"OK";
            }
            else
            {
                txtCuitValidado.BackColor = Color.Red;
                txtCuitValidado.Text = @"!";
                if (_tipoLx == "L1")
                {
                    MessageBox.Show(@"Atencion el CUIT no se encuentra validado!", @"Error en CUIT", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            txtEstadoDocumento.Text = _estado.ToString();
            txtTipoDocumento.Text = ManageDocumentType.GetDocumentDescriptionHardCode(_tipoDocumento);
            txtZterm.Text = _tipoLx == "L1" ? vendor.ZTERM : vendor.ZTERM;
        }
        private void LoadHeaderDataFromDocumento()
        {
            txtTipoLx.BackColor = _tipoLx == "L1" ? Color.GreenYellow : Color.Crimson;

            var t403Data = new XVendorDocumentBase(_id403).GetHeader();
            var vendorData = new VendorManager().GetSpecificVendor(_idVendor);
            txtIdVendor.Text = _idVendor.ToString();
            txtRazonSocial.Text = vendorData.prov_rsocial;
            txtFantasia.Text = vendorData.prov_fantasia;
            txtCuit.Text = vendorData.TTAX1;

            if (new CuitValidation().ValidarCuit(txtCuit.Text))
            {
                txtCuitValidado.BackColor = Color.GreenYellow;
            }
            else
            {
                txtCuitValidado.BackColor = Color.Red;
            }

            var ncdH = new ZContaNotaCreditoConT400(_idNcd,_id403).GetDocumentoHeader();
            //   txtNumeroDocumento.Text = ncdH.NDOC;
            txtEstadoDocumento.Text = _estado.ToString();

            if (_tipoLx == "L1")
            {
                txtNumeroDocumento.Text = t403Data.NFACTURA;
            }
            else
            {

            }

            // txtNumeroDocumento.Text = @"NO-ASIGNADO";
            txtTipoDocumento.Text = _tipoDocumento.ToString();
            _fechaDocumento = t403Data.FECHA;
            mskFechaFactura.Text = _fechaDocumento.Value.ToString("d");
            txtTipoCambio.Text = t403Data.TC.ToString("C2");
            txtZterm.Text = _tipoLx == "L1" ? vendorData.ZTERM : vendorData.ZTERM;
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

            if (_tipoDocumento == ManageDocumentType.TipoDocumento.AjusteSaldoPositivo)
            {

            }

            if (_tipoDocumento == ManageDocumentType.TipoDocumento.AjusteSaldoNegativo)
            {

            }

        }

        #region Accion Segun Indicador

        private void AccionSegunIndicadorInicial()
        {
            switch (_indicador)
            {
                case "CHR":
                    AccionNdChqRechazado();
                    break;
                case "NDDIFCAMBIO":
                    AccionNdDiferenciaCambio();
                    break;
                //case "AFACTU":
                //    AccionNcAnulaFacturaCompleta();
                //    break;
                case "DEVKG":
                    AccionNcMaterial_Kg();
                    break;
                //case "DIFTCNC":
                //    AccionNcAjusteTC();
                //    break;
                //case "DIFPRNC":
                //    AccionNcDiferenciaPrecio();
                //    break;
                default:
                    MessageBox.Show(@"Atencion El Tipo de Documento no tiene una Accion Predefinida", @"Informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
        private void AccionNdChqRechazado()
        {
            using (var f0 = new FrmFI82SeleccionChequeRechazadoVendor(_idVendor, _tipoLx))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _idChequeRechazado = f0._idChequeSeleccionado;

                    if (_idChequeRechazado == null)
                        return;
                    fechaRechazo = f0.FechaRechazo;
                    AddChequeRechazado((int)_idChequeRechazado, f0.MotivoChequeRechazado);
                    AddRegistroGastosBancarios(f0.GastosCheque, f0.IVAGastosCheque);
                    _ivaGastos += f0.IVAGastosCheque;

                    var ix = _listaChRechazado.Find(c => c.IDCHEQUE == f0._idChequeSeleccionado.Value);
                    if (ix != null)
                    {
                        ix.GastosOrigen = f0.GastosCheque;
                        ix.IVAGastosOrigen = f0.IVAGastosCheque;
                        ix.OrigenRechazo = "NCDP@" +txtRazonSocial.Text +"@ND#" + txtNumeroDocumento.Text;
                    }
                    AsignaNumeroItem();
                    t0311NCDPIBindingSource.DataSource = _listaItems.ToList();
                    CalculaPreciosFromNcMemoria();
                }
            }
        }

        /// <summary>
        /// Devolucion de Material o Facturacion
        /// </summary>
        private void AccionNcMaterial_Kg()
        {
            using (var f0 = new FrmFI85NCDPDiferenciaKg(_idVendor, _tipoLx))
            {
                var dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {

                    var cantidad = f0.cantidad;
                    var material = f0.material;
                    var precioU = f0.precioU;
                    var precioT = f0.precioT;
                    var moneda = f0.monedaConta;
                    var tc = f0.tc;
                    var aplicaBaseImponible = f0.iva21;
                    decimal importeIVA = 0;
                    var glItem = f0.gl;

                    cmbMoneda.SelectedItem = f0.monedaConta;
                    txtTipoCambio.Text = tc.ToString("N2");

                    if (aplicaBaseImponible)
                    {
                        importeIVA = (decimal)0.21 * precioT;
                    }
                    AddMaterialDevolucion(material, cantidad, moneda, precioU, precioT, importeIVA, glItem);
                    AsignaNumeroItem();
                    t0311NCDPIBindingSource.DataSource = _listaItems.ToList();
                    CalculaPreciosFromNcMemoria();
                }
                else
                {
                    MessageBox.Show(@"La Accion ha sido cancelada", @"No se han agregado items", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void AccionNdDiferenciaCambio()
        {
            var data = new T0311_NCDP_I()
            {
                MON = "ARS",
                IDITEM = AsignaNumeroItem(),
                CANT = 1,
                DESC = "Ajuste Por Diferencia Cambio",
                GL = "4.5.2",
                IDCH = null,
                CHR = false,
                ITEM = "DIFTC",
                PUNITARIO = 0,
                PTOTAL = 0,
                TEMP = true,
                PIVA = 0
            };
            data.IVA21 = false;
            _listaItems.Add(data);
            t0311NCDPIBindingSource.DataSource = _listaItems.ToList();

            //MapTotalesFromMemory();            
        }
        private void CalculaPreciosFromNcMemoria()
        {
            decimal bruto = 0;
            decimal baseImponible = 0;
#pragma warning disable CS0219 // The variable 'iva' is assigned but its value is never used
            decimal iva = 0;
#pragma warning restore CS0219 // The variable 'iva' is assigned but its value is never used
            foreach (var l in _listaItems)
            {
                bruto += l.PTOTAL.Value;
                if (l.IVA21.Value)
                    baseImponible += l.PTOTAL.Value;
            }

            var total = new XVendorDocumentBase.ImportesT403()
            {
                ImporteBrutoInicial = bruto,
                ImporteDescuento = 0,
                PorDescuento = 0,
                SubTotal = bruto,
                BaseImponible = baseImponible,
                ImporteIVA10 = 0,
                ImporteIVA21 = baseImponible * (decimal)0.21,
                ImporteIVA27 = 0,
                TotalIva = baseImponible * (decimal)0.21,
                PercepcionIIBB = 0,
                PercepcionIVA = 0,
                PercpecionGs = 0,
                AlicuotaIIBB = 0,
                AlicoutaIVA = 0,
                AlicuptaGs = 0,
                TotalPercepciones = 0,
                ImpuestoMunicipal = 0,
                ImpuestoProvincial = 0,
                ImpuestoInterno = 0,
                OtrosImpuestos = 0,
                ConceNoGravado = 0,
                TotalOtrosImpuestos = 0,
                TotalRedondeo = 0,
                NetoFinal = bruto + (baseImponible * (decimal)0.21),
            };
            //
            MapTotalesFromMemory(total);
            //
        }
        private void AddChequeRechazado(int idchequeR, string motivoRechazo)
        {
            fechaRechazo = _fechaDocumento == null ? DateTime.Today : _fechaDocumento.Value;
            var datach = new ChequesManager().GetCheque(idchequeR);
            var dataChr = new T0156_CHEQUE_RECH()
            {
                IDCLIENTE = datach.IdClienteRecibido.Value,
                BANCO_SN = datach.T0160_BANCOS.BCO_SHORTDESC,
                IDCHEQUE = idchequeR,
                TIPO = datach.TIPO_REC,
                FECHA_CH = datach.CHE_FECHA,
                CLIENTERS = datach.CLIENTE,
                FECHA_RE = fechaRechazo,
                IMPORTE = datach.IMPORTE.Value,
                MOTIVO_RE = motivoRechazo,
                NUMERO = datach.CHE_NUMERO,
                LOG_DATE = DateTime.Now,
                LOG_USER = Environment.UserName,
            };
            _listaChRechazado.Add(dataChr);

            var descripcion =
                $"Rechazo Ch.# {datach.CHE_NUMERO} Banco {datach.T0160_BANCOS.BCO_SHORTDESC} - Importe {datach.IMPORTE.Value.ToString("C2")}";
            var data = new T0311_NCDP_I()
            {
                MON = "ARS",
                IDITEM = AsignaNumeroItem(),
                CANT = 1,
                DESC = descripcion,
                GL = "1.0.0.8",
                ITEM = "CHRECH",
                IVA21 = false,
                PUNITARIO = datach.IMPORTE.Value,
                PTOTAL = datach.IMPORTE.Value,
                PIVA = 0,
                TEMP = true,
                CHR = true,
                IDCH = idchequeR,
            };
            _listaItems.Add(data);
            //MapTotalesFromMemory();
        }
        private void AddRegistroGastosBancarios(decimal gastos, decimal ivaGastos)
        {
            //TODO: aca hacer que si los gastos son 0 no agregue
            var data = new T0311_NCDP_I()
            {
                MON = "ARS",
                IDITEM = AsignaNumeroItem(),
                CANT = 1,
                DESC = "Gastos Bancarios",
                GL = "4.5.2",
                IDCH = null,
                CHR = false,
                ITEM = "GSBAN",
                PUNITARIO = gastos,
                PTOTAL = gastos,
                TEMP = true,
                PIVA = ivaGastos
            };
            data.IVA21 = ivaGastos > 0;
            _listaItems.Add(data);
            //MapTotalesFromMemory();
        }
        private void AddMaterialDevolucion(string material, decimal cantidad, string moneda, decimal precioU, decimal precioT, decimal importeIva, string gl)
        {
            var data = new T0311_NCDP_I()
            {
                MON = moneda,
                IDITEM = AsignaNumeroItem(),
                CANT = cantidad,
                DESC = "Devolucion/Reintegro " + material,
                GL = gl,
                IDCH = null,
                CHR = false,
                ITEM = material,
                PUNITARIO = precioU,
                PTOTAL = precioT,
                TEMP = true,
                PIVA = importeIva

            };
            data.IVA21 = importeIva > 0;
            _listaItems.Add(data);
            _kgSeleccionados += cantidad;
            txtKgTotalFacturados.Text = _kgSeleccionados.ToString("N2");
        }
        
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
        #endregion
        private void AccionEstadoDocumento()
        {

            //disabled all buttons
            btnSetRegistrado.Enabled = false;
            dgvItems.Enabled = false;
            mskFechaFactura.Enabled = false;
            txtTipoCambio.ReadOnly = true;
            txtImporteDescuento.ReadOnly = true;
            //btnSetEstadoInicial.Enabled = false;
            btnCancelar.Enabled = false;
            txtComentarioInterno.ReadOnly = true;
            switch (_estado)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    btnSetRegistrado.Enabled = true;
                    dgvItems.Enabled = true;
                    mskFechaFactura.Enabled = true;
                    txtTipoCambio.ReadOnly = false;
                    txtImporteDescuento.ReadOnly = false;
                    if (_tipoLx == "L1")
                    {

                    }
                    txtComentarioInterno.ReadOnly = false;
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    // btnSetEstadoInicial.Enabled = true;
                    // btnSetContabilizada.Enabled = true;
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

                    btnCancelar.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void LoadInitialDataFromExistingDocument()
        {
            //los datos se cargan siempre desde el documento en T300
            var ncdData = new NcdTableManager().GetNCDHData(_idNcd);
            if (ncdData == null)
            {
                MessageBox.Show(@"No se puede continuar porque los datos estan incompletos/mal mantenidos",
                    @"Error en Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            var t400Data = new CustomerInvoice("NCD", _idNcd).GetHeaderData();
            _id403 = t400Data.IDFACTURA;
            txtNumeroDocumento.Text = ncdData.NDOC;
            txtTipoCambio.Text = t400Data.TC.ToString("N2");
            txtComentarioInterno.Text = ncdData.COMENTARIO;
            _estado = new DocumentFIStatusManager().MapStatusHeaderFromText(t400Data.StatusFactura);
            _idVendor = t400Data.Cliente;
            //_listaItems = new NcdTableManager().GetItemList(_docReturn.IdRemitoIdNcd);
            _tipoLx = t400Data.TIPOFACT;
            txtIdNCD.Text = _idNcd.ToString();
            txtIdFactura.Text = _id403.ToString();
            txtTipoLx.Text = _tipoLx;
            if (_tipoLx == "L1")
            {
                switch (ncdData.TDOC)
                {
                    case "ND":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaDebitoVentaA;
                        break;
                    case "NC":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaCreditoVentaA;
                        break;
                    default:
                        //mapear algun ajuste?
                        break;
                }
            }
            else
            {
                switch (ncdData.TDOC)
                {
                    case "ND":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaDebitoVenta2;
                        break;
                    case "NC":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.NotaCreditoVenta2;
                        break;
                    default:
                        //mapear algun ajuste?
                        break;
                }
            }
        }
        private void LoadTotalesFromHeader400()
        {
            _docData.RecalculaTotalesFromDb();
        }
        private void MapTotalesFromMemory(XVendorDocumentBase.ImportesT403 resultado)
        {
            txtImporteBruto.Text = resultado.ImporteBrutoInicial.ToString("C2");
            txtImporteDescuento.Text = resultado.ImporteDescuento.ToString("C2");
            txtSubtotal.Text = (resultado.ImporteBrutoInicial - resultado.ImporteDescuento).ToString("C2");
            txtBaseImponible.Text = resultado.BaseImponible.ToString("C2");
            txtTotalIva.Text = (resultado.ImporteIVA21 + resultado.ImporteIVA10 + resultado.ImporteIVA27).ToString("C2");
            txtTotalPercepciones.Text =
                (resultado.PercepcionIIBB + resultado.PercepcionIVA + resultado.PercpecionGs).ToString("C2");
            txtTotalOtroImpuestos.Text =
                (resultado.ImpuestoMunicipal + resultado.ImpuestoProvincial + resultado.ImpuestoInterno +
                 resultado.OtrosImpuestos + resultado.ConceNoGravado).ToString("C2");
            txtImporteNetoFinal.Text = resultado.NetoFinal.ToString("C2");

            txtIva21.Text = resultado.ImporteIVA21.ToString("C2");
            txtIva10.Text = resultado.ImporteIVA10.ToString("C2");
            txtIva27.Text = resultado.ImporteIVA27.ToString("C2");
            txtAlicIIBB.Text = resultado.AlicuotaIIBB.ToString("P2");
            txtPercIIBB.Text = resultado.PercepcionIIBB.ToString("C2");
            txtPercIva.Text = resultado.PercepcionIVA.ToString("C2");
            txtAlicIva.Text = resultado.AlicoutaIVA.ToString("P2");
            txtPercGs.Text = resultado.PercpecionGs.ToString("C2");

            txtImpuMunicipal.Text = resultado.ImpuestoMunicipal.ToString("C2");
            txtImpuProvincial.Text = resultado.ImpuestoProvincial.ToString("c2");
            txtImpuInternos.Text = resultado.ImpuestoInterno.ToString("C2");
            txtImpuOtros.Text = resultado.OtrosImpuestos.ToString("C2");
            txtConcpetoNoGravado.Text = resultado.ConceNoGravado.ToString("C2");

        }
        private bool ValidaRegistradoOK()
        {
            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
            {
                MessageBox.Show(@"Debe proveer un numero de documento", @"Error en FECHA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_fechaDocumento == null)
            {
                MessageBox.Show(@"Debe proveer una FECHA DE DOCUMENTO en el Formato Indicado", @"Error en FECHA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtTipoCambio.Text))
            {
                MessageBox.Show(@"Debe proveer un TIPO DE CAMBIO", @"Error en TC",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtNumeroDocumento.MaskCompleted == false)
            {
                MessageBox.Show(@"Debe proveer un NUMERO DE DOCUMENTO en el Formato Indicado", @"Error en numero de documento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (new PeriodoAvailability().CheckPeriodoOpenFI(_fechaDocumento.Value) == false)
            {
                MessageBox.Show(@"El Periodo para Registrar NO se encuentra Abierto", @"Error en Periodo FI",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
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
                            if (x.CHR == true)
                            {
                                var idchequeR = Convert.ToInt32(x.IDCH);
                                var lstchr = _listaChRechazado.Find(c => c.IDCHEQUE == idchequeR);
                                _listaChRechazado.Remove(lstchr);
                            }
                            _listaItems.Remove(x);
                            AsignaNumeroItem();
                            //_docData.CreateNewItemListInMemory(_listaItems); //:)
                            CalculaPreciosFromNcMemoria();
                            t0311NCDPIBindingSource.DataSource = _listaItems.ToList();
                            //MapTotalesFromMemory(_docData.GetTotalesFromMemory());
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (_estado == DocumentFIStatusManager.StatusHeader.Pendiente && _idNcd > 0)
            {
                if (MessageBox.Show(
                    @"Confirma que desea Salir? Esta accion eliminara toda la informacion de este documento y tendra que comenzarlo nuevamente",
                    @"Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    new VendorNcdManager().RemoveFromNcdp(_idNcd);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        private T0203_CTACTE_PROV MapFormDataToCtaCte203Structure()
        {
            var docu = new T0203_CTACTE_PROV()
            {
                IDCTACTE = 0,
                TDOC = txtTdoc.Text,
                NUMDOC = txtNumeroDocumento.Text,
                DOC_INTERNO = _docReturn.IdNdp.ToString(),
                Fecha = _fechaDocumento.Value,
                ZTERM = new VendorManager().GetZterm(_idVendor, _tipoLx),
                IDPROV = _idVendor,
                MONEDA = cmbMoneda.SelectedItem.ToString(),
                TC = Convert.ToDecimal(txtTipoCambio.Text),
                ZOP = false,
                TIPO = _tipoLx,
                IdFacturaX = _docReturn.IdFacturaX,
                LogDate = DateTime.Now,
                LogUsuario = Environment.UserDomainName
            };
            if (cmbMoneda.SelectedItem.ToString() == @"ARS")
            {
                docu.IMPORTE_ORI = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteNetoFinal.Text) * signo;
                docu.IMPORTE_ARS = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteNetoFinal.Text) * signo;

            }
            else
            {
                docu.IMPORTE_ORI = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteNetoFinal.Text) * signo;
                docu.IMPORTE_ARS = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteNetoFinal.Text) * signo *
                                   Convert.ToDecimal(txtTipoCambio.Text);
            }
            docu.SALDOFACTURA = docu.IMPORTE_ARS;
            return docu;
        }
        private void dgvItems_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if ((senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) == false && e.RowIndex >= 0)
            {
                var iditem = Convert.ToInt32(dgvItems[0, e.RowIndex].Value);
                var item = dgvItems[2, e.RowIndex].Value.ToString();
                if (item == "CHRECH")
                {
                    MessageBox.Show(@"Este Item no puede ser modificado", @"Edicion no Permitida", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                using (var f0 = new FrmVendorNcdEditItem(_listaItems, iditem, _tipoLx))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        _listaItems = f0._list;
                        t0311NCDPIBindingSource.DataSource = _listaItems.ToList();
                        //_docData.CreateNewItemListInMemory(_listaItems); //:)
                        CalculaPreciosFromNcMemoria();
                    }
                }
            }
        }
        private void mskFechaFactura_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParseExact(mskFechaFactura.Text,
                "d/M/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                //valid date
                txtFechaValidada.BackColor = Color.GreenYellow;
                _fechaDocumento = dt;
            }
            else
            {
                //invalid date
                toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
                toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA", mskFechaFactura,
                    mskFechaFactura.Location, 5000);

                txtFechaValidada.BackColor = Color.OrangeRed;
                _fechaDocumento = null;
            }
        }
        private void mskFechaFactura_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtFechaValidada.BackColor = Color.OrangeRed;
            _fechaDocumento = null;

            toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
            toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA", mskFechaFactura,
                mskFechaFactura.Location, 5000);

        }
        private void mskFechaFactura_Validating(object sender, CancelEventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParseExact(mskFechaFactura.Text,
                "d/M/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                //valid date
                txtFechaValidada.BackColor = Color.GreenYellow;
                _fechaDocumento = dt;
            }
            else
            {
                //invalid date
                toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
                toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA", mskFechaFactura,
                    mskFechaFactura.Location, 5000);

                txtFechaValidada.BackColor = Color.OrangeRed;
                _fechaDocumento = null;
            }
        }
        private void txtIConceptosNoGrav_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void btnChequeRechazado_Click(object sender, EventArgs e)
        {
            AccionNdChqRechazado();
        }
        private void txtIDto_Validated(object sender, EventArgs e)
        {
            //al validar descuento recalcula!
        }
        
        #region Botones

        private void btnSetRegistrado_Click(object sender, EventArgs e)
        {
            if (!ValidaRegistradoOK())
                return;

            if (_id403 == 0)
            {
                CreateNewDocumentT403_T404InMemory(); //Con Data Inicial (Totales en 0)

            }

            var confirma = MessageBox.Show(@"Confirma la REGISTRACION/CONTABILIZACION del Documento?", @"Registracion de Documento",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirma == DialogResult.No)
                return;
            _docReturn = _docData.GrabaDocumentoToDatabase();
            txtEstadoDocumento.Text = DocumentFIStatusManager.StatusHeader.Registrada.ToString().ToUpper();
            txtIdFactura.Text = _docReturn.IdFactura.ToString();
            txtIdFactura.BackColor = Color.GreenYellow;
            txtIdNCD.Text = _docReturn.IdNdp.ToString();
            txtIdNCD.BackColor = Color.GreenYellow;
            txtEstadoDocumento.BackColor = Color.GreenYellow;
            _estado = DocumentFIStatusManager.StatusHeader.Registrada;
            AccionEstadoDocumento();
            
            //Comienza Contabilizacion de Factura Proveedor
            
            //1 Add Factura 203 + Update deuda 204  >>retorno idctacte
            var ctacte = new CtaCteVendor(_idVendor);
            var data = MapFormDataToCtaCte203Structure();
            var idCtaCte = ctacte.AddCtaCteDetalleRecord(data.TDOC, data.TIPO, data.Fecha.Value, data.NUMDOC, data.DOC_INTERNO,
                data.MONEDA, data.IMPORTE_ORI.Value, data.TC.Value, data.SALDOFACTURA.Value, data.IMPORTE_ARS.Value, data.IdFacturaX.Value, data.IdFacturaX.Value);

            if (idCtaCte > 0)
            {
                txtIdCtaCte.Text = idCtaCte.ToString();
                ctacte.UpdateSaldoCtaCteResumen(data.TIPO, data.IMPORTE_ORI.Value, data.MONEDA, data.TC);
                var result = ctacte.GetResultadoCtaCte(data.TIPO);
            }
            else
            {
                txtIdCtaCte.Text = @"Error";
                txtIdCtaCte.BackColor = Color.Orange;
            }

            //2. Add Record 403 + 404
            var vendorInvoice = new VendorInvoice(_idVendor, "NCDP");


            //Asientos Contables
            AsientoBase.IdentificacionAsiento resultadoAsientoC = new AsientoBase.IdentificacionAsiento();
            var asiento = new AsientoVendorDocument(_docReturn.IdFactura, "NCDP");
            resultadoAsientoC = asiento.AsientoFromVendorFactura();

            if (resultadoAsientoC.IdDocu > 0)
            {
                vendorInvoice.UpdateIdCtaCte_NAS_T403(_docReturn.IdFactura, idCtaCte, resultadoAsientoC.IdDocu);
                MessageBox.Show(@"El Documento se Ha Contabilizado CORRECTAMENTE!", @"Contabilizacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNAS.Text = resultadoAsientoC.IdDocu.ToString();
            }
            else
            {
                MessageBox.Show(@"Ocurrio un error al generar el Asiento Contable", @"Contabilizacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNAS.Text = @"Error";
            }

            txtEstadoDocumento.Text = _estado.ToString();
            AccionEstadoDocumento();
        }
        
        #endregion

        private void label17_Click(object sender, EventArgs e)
        {

        }
        private void txtGLAP_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void MonedaValidating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = @"0";
            decimal valor = FormatAndConversions.CCurrencyADecimal(txt.Text);
            txt.Text = valor.ToString("C2");
        }
        private void PorcentajeValidating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = @"0";
            decimal valor = Convert.ToDecimal(txt.Text);
            txt.Text = valor.ToString("P3");
        }
        private void DecimalValidating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = @"0";
            decimal valor = Convert.ToDecimal(txt.Text);
            txt.Text = valor.ToString("N2");
        }
        private void txtIBaseImponible_Validated(object sender, EventArgs e)
        {
            //chequea que sea un valor >0 y menor a subtotal porque los impuestsos son ingresados a mano
            //si validacion OK

            MessageBox.Show(@"El Sistema no Recalcula IVA y Perecpeciones de acuerdo a la base imponible",
                @"ATENCION: Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void RecalculoLeave(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.Text = new FormatAndConversions().SetCurrency(t.Text);
            if (t.Name == "txtImporteDescuento")
            {
                SumaImportes(false, true);
                MessageBox.Show(
                    @"Es posible que se haya modificado la Base Imponible pero los valores de Impuestos no se han recalculado en forma automatica",
                    @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SumaImportes(false, false);
            }

            var n = t.Name;
            if (t.ReadOnly)
                return;
            if (string.IsNullOrEmpty(t.Text) || FormatAndConversions.CCurrencyADecimal(t.Text) == 0)
            {
                t.BackColor = Color.White;
            }
            else
            {
                t.BackColor = Color.PaleGreen;
            }


        }
        private decimal RecalculaBaseImponible()
        {
            decimal valor = 0;
            foreach (var items in _listaItems)
            {
                if (items.IVA21.Value)
                {
                    valor += items.PTOTAL.Value;
                }
            }
            return valor;
        }
        private void SumaImportes(bool recalculoAutomaticoIva21, bool recalculoBaseImponible)
        {
            decimal importeBruto = FormatAndConversions.CCurrencyADecimal(txtImporteBruto.Text);
            if (string.IsNullOrEmpty(txtKgTotalFacturados.Text))
                txtKgTotalFacturados.Text = 0.ToString("N2");

            decimal totalKg = Convert.ToDecimal(txtKgTotalFacturados.Text);
            decimal descuento = FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text);
            decimal subtotal = importeBruto - descuento;
            txtSubtotal.Text = subtotal.ToString("C2");
            decimal baseImponible = recalculoBaseImponible ? RecalculaBaseImponible() : FormatAndConversions.CCurrencyADecimal(txtBaseImponible.Text);
            if (_tipoLx == @"L1" && recalculoAutomaticoIva21)
            {
                decimal valorIva21 = baseImponible * (decimal)0.21;
                txtIva21.Text = valorIva21.ToString("C2");
            }

            decimal totalIVA = FormatAndConversions.CCurrencyADecimal(txtIva10.Text) +
                               FormatAndConversions.CCurrencyADecimal(txtIva21.Text) +
                               FormatAndConversions.CCurrencyADecimal(txtIva27.Text);

            txtTotalIva.Text = totalIVA.ToString("C2");

            decimal totalPercepciones = FormatAndConversions.CCurrencyADecimal(txtPercIIBB.Text) +
                                        FormatAndConversions.CCurrencyADecimal(txtPercIva.Text) +
                                        FormatAndConversions.CCurrencyADecimal(txtPercGs.Text);
            txtTotalPercepciones.Text = totalPercepciones.ToString("C2");

            decimal totalOtrosImpuestos = FormatAndConversions.CCurrencyADecimal(txtImpuMunicipal.Text) +
                                       FormatAndConversions.CCurrencyADecimal(txtImpuProvincial.Text) +
                                       FormatAndConversions.CCurrencyADecimal(txtImpuInternos.Text) +
                                       FormatAndConversions.CCurrencyADecimal(txtImpuOtros.Text) +
                                       FormatAndConversions.CCurrencyADecimal(txtConcpetoNoGravado.Text);

            txtTotalOtroImpuestos.Text = totalOtrosImpuestos.ToString("C2");

            decimal importeRedondeo = FormatAndConversions.CCurrencyADecimal(txtRedondeoVarios.Text);
            txtRedondeoVarios.Text = importeRedondeo.ToString("C2");

            _importeContabilizar = subtotal + totalIVA + totalPercepciones + totalOtrosImpuestos + importeRedondeo;
            txtImporteNetoFinal.Text = _importeContabilizar.ToString("C2");
        }
        private void PercepcionesValidated(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            decimal baseImpo;

            if (string.IsNullOrEmpty(txtBaseImponible.Text))
            {
                return;
            }

            baseImpo = FormatAndConversions.CCurrencyADecimal(txtBaseImponible.Text);
            if (baseImpo == 0)
                return;

            decimal alicuota = FormatAndConversions.CCurrencyADecimal(txt.Text) / baseImpo;
            switch (txt.Name)
            {
                case "txtPercIIBB":
                    txtAlicIIBB.Text = alicuota.ToString("P3");
                    break;
                case "txtPercGs.Text":
                    txtAlicGs.Text = alicuota.ToString("P3");
                    break;
                case "txtPercIva":
                    txtAlicIva.Text = alicuota.ToString("P3");
                    break;
            }
        }
        private void txtRedondeoVarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, true, true);
        }
    }
}
