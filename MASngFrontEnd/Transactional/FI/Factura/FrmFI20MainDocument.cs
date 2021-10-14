using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.ContaFromDocuments;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Customers;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.FI.MainDocumentData.Customer;
using Tecser.Business.Transactional.SD;
using Tecser.Business.WebServices;
using TecserEF.Entity;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.Factura
{
    public partial class FrmFI20MainDocument : Form
    {
        public FrmFI20MainDocument(List<FsRDataStructure> data)
        {
            //modo FSR
            _modo = 5;
            _tipoDocumento = ManageDocumentType.TipoDocumento.FacturaVentaA;
            _data = data;
            _idRemito = 0;
            InitializeComponent();
        }
        public FrmFI20MainDocument(int modo, int idRemito, ManageDocumentType.TipoDocumento tipoDocumento)
        {
            _modo = modo;
            _idRemito = idRemito;
            _tipoDocumento = tipoDocumento;
            InitializeComponent();
        }

        private readonly List<FsRDataStructure> _data = new List<FsRDataStructure>();
        private readonly int _modo;
        private readonly int _idRemito;
        private string _tipoLx;
        private decimal _exchangeRate;
#pragma warning disable CS0414 // The field 'FrmFacturaMain.importeDescuento' is assigned but its value is never used
        private decimal importeDescuento = 0;
#pragma warning restore CS0414 // The field 'FrmFacturaMain.importeDescuento' is assigned but its value is never used
        private decimal _alicuotaPercepcion = 0;
        private MainDocumentBase.FacturaId _facturaIdStruct;
        private ManageDocumentType.TipoDocumento _tipoDocumento;
        private List<T0401_FACTURA_I> _itemF = new List<T0401_FACTURA_I>();
        private TotalCustomerFactura _importeTotalManager;
        private CustomerMainDocument _docData;

        private void ConfiguracionInicial()
        {
            txtMoneda.ReadOnly = true; //Momentaneamente NO permitimos cambiar la moneda de la factura 
            txtMoneda.Text = @"ARS";
            dgvItemFacturaARS.ReadOnly = true;
            dgvItemsFacturaUSD.ReadOnly = true;
            dgvItemsFacturaUSD.Visible = false;
            dgvItemFacturaARS.Visible = true;
            //
            txtCodigoAprobacion.PasswordChar = '\u25CF';
            txtMonedaTotales.Text = txtMoneda.Text;
            txtMonedaTotales.BackColor = Color.PaleGreen;
            rbMonedaFactura.Checked = true;
            //
            dgvItemsFacturaUSD.DataSource = t0401FACTURAIBindingSource;
            dgvItemFacturaARS.DataSource = t0401FACTURAIBindingSource;
            //
        }
        private void FrmFacturaMain_Load(object sender, EventArgs e)
        {
            ConfiguracionInicial();
            switch (_modo)
            {
                case 1:
                    MapRemitoDataToForm();
                    if (_facturaIdStruct.IdFactura > 0)
                    {
                        MapFacturaDataToForm();
                    }
                    else
                    {
                        if (_tipoLx == @"L1")
                        {
                            cmbTipoDocumento.Items.Add("Factura A");
                            cmbTipoDocumento.Items.Add("Factura B");
                            //cmbTipoDocumento.Items.Add("Factura M");
                            cmbTipoDocumento.SelectedItem = "Factura A";
                        }
                        else
                        {
                            cmbTipoDocumento.Items.Add("Presupuesto X");
                            cmbTipoDocumento.SelectedItem = "Presupuesto X";
                        }

                        cmbTipoDocumento.Enabled = true;
                        CreateNewDocumentT400_T401InMemory(); //aca esta all in memoria
                        MapTotalesFromMemoryToForm();
                        var h = _docData.GetHeaderData();
                        _exchangeRate = h.TC;
                    }
                    AccionEstadoDocumento();
                    AccionFormatoSegunTipoLx();
                    break;
                case 2:
                    //no hay modo 2
                    break;
                case 3:
                // no hay modo 3
                case 5:
                    //modo FSR - Facturacion Sin Remito
                    MapFsRDataToForm();
                    if (_facturaIdStruct.IdFactura > 0)
                    {
                        MapFacturaDataToForm();
                    }
                    else
                    {
                        if (_tipoLx == @"L1")
                        {
                            cmbTipoDocumento.Items.Add("Factura A");
                            cmbTipoDocumento.Items.Add("Factura B");
                            //cmbTipoDocumento.Items.Add("Factura M");
                            cmbTipoDocumento.SelectedItem = "Factura A";
                        }
                        else
                        {
                            cmbTipoDocumento.Items.Add("Presupuesto X");
                            cmbTipoDocumento.SelectedItem = "Presupuesto X";
                        }

                        cmbTipoDocumento.Enabled = true;
                        CreateNewDocumentT400_T401InMemory(); //aca esta all in memoria
                        MapTotalesFromMemoryToForm();
                        var h = _docData.GetHeaderData();
                        _exchangeRate = h.TC;
                    }
                    AccionEstadoDocumento();
                    AccionFormatoSegunTipoLx();
                    break;
                default:
                    break;
            }
        }
        private void AccionEstadoDocumento()
        {
            var estadoDocumento = new DocumentFIStatusManager().MapStatusHeaderFromText(txtEstadoDocumento.Text);
            //

            //deshabilito all
            btnImprimirFactura.Enabled = false;
            btnAgregarItems.Enabled = false;
            btnContabilizar.Enabled = false;
            btnARBA.Enabled = false;
            btnVerRemito.Enabled = false;
            btnSolicitarCAE.Enabled = false;
            btnEnviarEmail.Enabled = false;
            btnSetEstadoInicial.Enabled = false;
            //btnImprimirFactura.Enabled = true; //remover            
            btnReimprimirDocumento.Enabled = false;
            btnCancelarContabilizacion.Enabled = false;
            btnSetEstadoRegistrado.Enabled = false;
            dgvItemFacturaARS.Enabled = false;
            dgvItemsFacturaUSD.Enabled = false;
            txtCodigoAprobacion.ReadOnly = true;
            txtTc.ReadOnly = true;
            txtDescuentoPorcentaje.ReadOnly = true;
            txtImporteDescuento.ReadOnly = true;

            dtpFechaFactura.Enabled = false;
            //------------------------------------------

            switch (estadoDocumento)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    //Este estado los datos estan solamente en memoria [Inicial]
                    txtCodigoAprobacion.ReadOnly = false;
                    dtpFechaFactura.Enabled = true;
                    txtTc.ReadOnly = false;
                    txtDescuentoPorcentaje.ReadOnly = false;
                    txtImporteDescuento.ReadOnly = false;
                    //
                    btnAgregarItems.Enabled = true;
                    btnSetEstadoRegistrado.Enabled = true;
                    break;

                case DocumentFIStatusManager.StatusHeader.Registrada:
                    btnContabilizar.Enabled = true;
                    btnSetEstadoInicial.Enabled = true;
                    break;

                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    _importeTotalManager = new TotalCustomerFactura(_facturaIdStruct.IdFactura, txtMoneda.Text);
                    _importeTotalManager.GetTotalesFromTable400();
                    MapValoresImportesAlForm();

                    if (txtLx.Text == @"L1")
                    {
                        btnSolicitarCAE.Enabled = true;
                        btnCancelarContabilizacion.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show(@"Este mensaje es para debug. no debiera pasar por este estado!", @"MENSAJE PARA DESARROLLADOR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //Se supone que directamente pasa en L2 de Registrada --> Aprobada
                    }
                    break;

                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    _importeTotalManager = new TotalCustomerFactura(_facturaIdStruct.IdFactura, txtMoneda.Text);
                    _importeTotalManager.GetTotalesFromTable400();
                    MapValoresImportesAlForm();

                    if (txtLx.Text == @"L2")
                    {
                        btnCancelarContabilizacion.Enabled = true;
                    }
                    else
                    {
                        //Si la factura es L1 no se puede cancelar sino que hay que hacer una NC.
                        //Porque la factura ya tiene CAE.-
                    }
                    btnImprimirFactura.Enabled = true;
                    btnEnviarEmail.Enabled = true;
                    break;

                case DocumentFIStatusManager.StatusHeader.Impresa:
                    _importeTotalManager = new TotalCustomerFactura(_facturaIdStruct.IdFactura, txtMoneda.Text);
                    _importeTotalManager.GetTotalesFromTable400();
                    MapValoresImportesAlForm();

                    btnReimprimirDocumento.Enabled = true;
                    btnEnviarEmail.Enabled = true;
                    break;

                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    _importeTotalManager = new TotalCustomerFactura(_facturaIdStruct.IdFactura, txtMoneda.Text);
                    _importeTotalManager.GetTotalesFromTable400();
                    MapValoresImportesAlForm();
                    break;

                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    _importeTotalManager = new TotalCustomerFactura(_facturaIdStruct.IdFactura, txtMoneda.Text);
                    _importeTotalManager.GetTotalesFromTable400();
                    MapValoresImportesAlForm();
                    btnSolicitarCAE.Enabled = true;



                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            // doc.UpdateTotalesInHeader(_facturaIdStruct.IdFactura, _importeTotalManager.ExchangeRate,
            //----
            //_importeTotalManager.ImporteTotalBrutoInicial, _importeTotalManager.ImporteDescuento,
            //_importeTotalManager.ImporteBaseImponible, _importeTotalManager.ImporteIva21,
            //_importeTotalManager.ImportePerRetIIBB, _importeTotalManager.ImporteTotalNetoFinal,
            //_importeTotalManager.AlicuotaPerRetIIBB, "Bs.As");
            //----

        }
        private void AccionFormatoSegunTipoLx()
        {
            if (_tipoLx == "L1")
            {
                txtIva105.Text = 0.ToString("c2");
                txtAlicuotaIIBB.BackColor = Color.LightGreen;
                txtImportePercepcion.BackColor = Color.LightGreen;
                txtIva21.BackColor = Color.LightGreen;
                txtIva105.BackColor = Color.Gray;
                txtAlicuotaIIBB.ReadOnly = false;
                txtImportePercepcion.ReadOnly = false;
                txtIva21.ReadOnly = false;
                txtIva105.ReadOnly = true;
            }
            else
            {
                txtAlicuotaIIBB.Text = 0.ToString("p2");
                txtImportePercepcion.Text = 0.ToString("C2");
                txtIva21.Text = 0.ToString("c2");
                txtIva105.Text = 0.ToString("c2");
                txtAlicuotaIIBB.BackColor = Color.Gray;
                txtImportePercepcion.BackColor = Color.Gray;
                txtIva21.BackColor = Color.Gray;
                txtIva105.BackColor = Color.Gray;
                txtAlicuotaIIBB.ReadOnly = true;
                txtImportePercepcion.ReadOnly = true;
                txtIva21.ReadOnly = true;
                txtIva105.ReadOnly = true;
                btnSolicitarCAE.Enabled = false;
                btnARBA.Enabled = false;
            }
        }

        #region Mapeo de Valores
        //---------------------------------------------------------------------------------------------|

        private bool MapFsRDataToForm()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int idOVH = _data[0].IdOV;
                int idOVI = _data[0].IdItem;
                var dataH = db.T0045_OV_HEADER.SingleOrDefault(c => c.IDOV == idOVH);
                var dataI1 =
                    db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idOVH && c.IDITEM == idOVI);
                if (dataH == null)
                    return false;

                txtId6.Text = dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.IDCLIENTE.ToString();
                txtRazonSocial.Text = dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial;
                txtFantasia.Text = dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_fantasia;
                txtEstadoRemito.Text = @"No Disponible";
                txtLx.Text = dataI1.MODO;
                txtTipoLx.Text = dataI1.MODO;
                txtNumeroCuit.Text = dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.CUIT;
                txtNumeroRemito.Text = @"0000-00000000";
                txtidRemito.Text = "";
                _tipoLx = dataI1.MODO; //ojo no sive para L5;

                txtZterm.Text = dataI1.MODO == "L1"
                    ? dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.ZTERML1
                    : dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.ZTERML2;

                txtZtermDescripcion.Text = new ZtermManager().GetDescripcionZTerm(txtZterm.Text);

                if (dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.P_IIBB == "EXENTO")
                {
                    ckExentoPercpecionARBA.Checked = true;
                    MessageBox.Show(
                        @"Atencion: Segun los datos maestros del cliente, el mismo esta exento de Percepcion ARBA. Revise la Informacion",
                        @"Exento ARBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.P_IIBBALIC != null)
                {
                    MessageBox.Show(
                        @"Atencion: Segun los datos maestros del cliente, el mismo tiene una modificacion de Alicuota de ARB. Revise vigencias y alicuota",
                        @"Modificacion Alicuota ARBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ckAlicuotaModificada.Checked = true;
                    txtAlicuotaIIBB.Text = (dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.P_IIBBALIC.Value * 100).ToString("N2");
                    _alicuotaPercepcion = Convert.ToDecimal(dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.P_IIBBALIC.Value);
                }
                ckAlicuotaModificada.Enabled = false;

                //if (dataH.Factura == null)
                {
                    _facturaIdStruct.IdFactura = 0;
                    _facturaIdStruct.IdFacturaX = 0;
                }

            }
            return true;
        }


        private bool MapRemitoDataToForm()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataH = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == _idRemito);
                if (dataH == null)
                    return false;

                txtId6.Text = dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.IDCLIENTE.ToString();
                txtRazonSocial.Text = dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial;
                txtFantasia.Text = dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_fantasia;
                txtEstadoRemito.Text = dataH.StatusRemito;
                txtLx.Text = dataH.TIPO_REMITO;
                txtTipoLx.Text = dataH.TIPO_REMITO;
                txtNumeroCuit.Text = dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.CUIT;
                txtNumeroRemito.Text = dataH.NUMREMITO;
                txtidRemito.Text = dataH.IDREMITO.ToString();
                _tipoLx = dataH.TIPO_REMITO;

                txtZterm.Text = dataH.TIPO_REMITO == "L1"
                    ? dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.ZTERML1
                    : dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.ZTERML2;

                txtZtermDescripcion.Text = new ZtermManager().GetDescripcionZTerm(txtZterm.Text);

                if (dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.P_IIBB == "EXENTO")
                {
                    ckExentoPercpecionARBA.Checked = true;
                    MessageBox.Show(
                        @"Atencion: Segun los datos maestros del cliente, el mismo esta exento de Percepcion ARBA. Revise la Informacion",
                        @"Exento ARBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.P_IIBBALIC != null)
                {
                    MessageBox.Show(
                        @"Atencion: Segun los datos maestros del cliente, el mismo tiene una modificacion de Alicuota de ARB. Revise vigencias y alicuota",
                        @"Modificacion Alicuota ARBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ckAlicuotaModificada.Checked = true;
                    txtAlicuotaIIBB.Text = (dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.P_IIBBALIC.Value * 100).ToString("N2");
                    _alicuotaPercepcion = Convert.ToDecimal(dataH.T0007_CLI_ENTREGA.T0006_MCLIENTES.P_IIBBALIC.Value);
                }
                ckAlicuotaModificada.Enabled = false;

                if (dataH.Factura == null)
                {
                    _facturaIdStruct.IdFactura = 0;
                    _facturaIdStruct.IdFacturaX = 0;
                }
                else
                {
                    _facturaIdStruct.IdFactura = (int)dataH.Factura;
                    _facturaIdStruct.IdFacturaX = 0; //se mapea en factura
                    txtIdFactura.Text = dataH.Factura.ToString();
                }
            }
            return true;
        }
        private void MapFacturaDataToForm()
        {
            var data = new CustomerInvoice("FAC", _facturaIdStruct.IdFactura);
            var headerData = data.GetHeaderData();

            txtIdFacturaX.Text = headerData.IDFACTURAX.ToString();
            txtIdFactura.Text = _facturaIdStruct.IdFactura.ToString();

            txtTipoDocumento.Text = DefineDescripcionDocumento(headerData.TIPO_DOC, headerData.TIPOFACT);
            txtEstadoDocumento.Text = new DocumentFIStatusManager().MapStatusHeaderFromText(headerData.StatusFactura).ToString().ToUpper();

            if (headerData.IdCtaCte > 0 || headerData.IdCtaCte != null)
                txtIdCtaCte.Text = headerData.IdCtaCte.ToString();

            if (headerData.FECHA != null)
                dtpFechaFactura.Value = headerData.FECHA;

            txtTc.Text = headerData.TC.ToString();
            var cliente = new CustomerManager().GetCustomerBillToData(headerData.Cliente);

            if (headerData.TIPOFACT == @"L1")
            {
                cmbTipoDocumento.Items.Add("Factura A");
                cmbTipoDocumento.Items.Add("Factura B");
                cmbTipoDocumento.Items.Add("Factura M");

                switch (headerData.TIPO_DOC)
                {
                    case "FA":
                        cmbTipoDocumento.SelectedItem = "Factura A";
                        break;
                    case "FB":
                        cmbTipoDocumento.SelectedItem = "Factura B";
                        break;
                    case "FM":
                        cmbTipoDocumento.SelectedItem = "Factura M";
                        break;
                    default:
                        MessageBox.Show($@"Atencion tipo de documento {headerData.TIPO_DOC} NO Manejado", @"Atencion",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                }


                cmbTipoDocumento.Enabled = false;
                if (string.IsNullOrEmpty(headerData.PV_AFIP))
                {
                    txtNumeroDocumento.Text = @"0000-00000000";
                    txtNumeroDocumento.BackColor = Color.Orange;
                }
                else
                {
                    txtNumeroDocumento.Text = headerData.PV_AFIP + @"-" + headerData.ND_AFIP;
                    txtNumeroDocumento.BackColor = Color.GreenYellow;
                }

                if (headerData.CAE == null)
                {
                    txtCAE.Text = @"PENDIENTE";
                    txtCAE.BackColor = Color.Orange;
                    cmbTipoDocumento.Enabled = true;
                }
                else
                {
                    txtCAE.Text = headerData.CAE;
                    txtCAE.BackColor = Color.GreenYellow;
                    cmbTipoDocumento.Enabled = false;
                }

                if (headerData.CAE_VTO != null)
                {
                    txtCAEVencimiento.Text = headerData.CAE_VTO.Value.ToString("d");
                    txtCAEVencimiento.BackColor = Color.GreenYellow;
                }
                else
                {
                    txtCAEVencimiento.BackColor = Color.Orange;
                }
            }
            else
            {
                cmbTipoDocumento.Items.Add("Presupuesto X");
                cmbTipoDocumento.SelectedItem = "Presupuesto X";
                txtNumeroDocumento.Text = headerData.Remito;
            }

            {

            }

            if (headerData.Impreso == null)
                headerData.Impreso = false;
            if (headerData.NAS != null)
                txtNAS.Text = headerData.NAS.ToString();

            ckDocumentoImpreso.Checked = headerData.Impreso;
            ckDocumentoImpreso.BackColor = ckDocumentoImpreso.Checked ? Color.GreenYellow : Color.OrangeRed;
            _itemF = data.GetItemData();
            t0401FACTURAIBindingSource.DataSource = _itemF;
            //
            txtImporteInicial.Text = headerData.TotalFacturaB.ToString("C2");
            txtImporteDescuento.Text = headerData.Descuento.Value.ToString("C2");
            txtBaseImponible.Text = headerData.TotalImpo.ToString("C2");
            txtImportePercepcion.Text = headerData.TotalIIBB.ToString("C2");
            txtAlicuotaIIBB.Text = headerData.IIBB_PORC.Value.ToString("P2");
            txtTotalFactura.Text = headerData.TotalFacturaN.ToString("C2");
            txtSubtotal.Text = (headerData.TotalFacturaB - headerData.Descuento.Value).ToString("C2");
            txtIva105.Text = 0.ToString("C2");
            txtIva21.Text = headerData.TotalIVA21.ToString("C2");
            if (headerData.TotalFacturaB == 0)
            {
                txtDescuentoPorcentaje.Text = 0.ToString("N2");
            }
            else
            {
                txtDescuentoPorcentaje.Text =
                    decimal.Round((headerData.Descuento.Value / headerData.TotalFacturaB), 2).ToString("P2");
            }
            //
        }
        private void MapValoresImportesAlForm()
        {
            var con = new FormatAndConversions();
            txtImporteInicial.Text = con.SetCurrency(_importeTotalManager.ImporteTotalBrutoInicial);
            txtImporteDescuento.Text = con.SetCurrency(_importeTotalManager.ImporteDescuento);
            txtSubtotal.Text = con.SetCurrency(_importeTotalManager.ImporteSubtotal);
            txtIva21.Text = con.SetCurrency(_importeTotalManager.ImporteIva21);
            txtAlicuotaIIBB.Text = _importeTotalManager.AlicuotaPerRetIIBB.ToString("p2");
            txtBaseImponible.Text = con.SetCurrency(_importeTotalManager.ImporteBaseImponible);
            txtImportePercepcion.Text = con.SetCurrency(_importeTotalManager.ImportePerRetIIBB);
            txtTotalFactura.Text = con.SetCurrency(_importeTotalManager.ImporteTotalNetoFinal);
        }

        #endregion


        private decimal GetIIBBPercepcion(DateTime fecha, string numeroCuit)
        {
            Cursor.Current = Cursors.WaitCursor;
            var periodo = new PeriodoConversion().GetPeriodo(fecha);
            var fechaDesde = new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(periodo);
            var fechaHasta = new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(periodo);
            var dataArba = new PadronArba();
            dataArba.Conectar(txtNumeroCuit.Text, fechaDesde, fechaHasta);
            var resultado = dataArba.AlPerc;
            Cursor.Current = Cursors.Default;
            return (decimal)resultado;
        }
        private void MapTotalesFromMemoryToForm()
        {
            if (_docData == null)
            {
                if (_facturaIdStruct.IdFactura > 0)
                {
                    _docData = new CustomerInvoice("FAC1", _facturaIdStruct.IdFactura);
                }
                else
                {
                    return;
                }
            }
            var headerData = _docData.GetHeaderData();
            //Fix Operaciones Viejas con Descuento antes de que existiera el campo DescuentoPorc
            {
                if (headerData.DescuentoPorc == null)
                    headerData.DescuentoPorc = 0;

                if (headerData.Descuento == null)
                    headerData.Descuento = 0;

                if (headerData.DescuentoPorc == 0 || headerData.Descuento != 0)
                {
                    if (headerData.TotalFacturaB == 0)
                    {
                        headerData.DescuentoPorc = 0;
                    }
                    else
                    {
                        headerData.DescuentoPorc = headerData.Descuento.Value / headerData.TotalFacturaB;
                    }
                }
            }

            if (txtMonedaTotales.Text == @"ARS")
            {
                txtImporteDescuento.Text = headerData.Descuento.Value.ToString("C2");
                txtImporteInicial.Text = headerData.TotalFacturaB.ToString("C2");
                txtBaseImponible.Text = headerData.TotalImpo.ToString("C2");
                txtSubtotal.Text = (headerData.TotalFacturaB - headerData.Descuento.Value).ToString("C2");
                txtIva21.Text = headerData.TotalIVA21.ToString("C2");
                txtImportePercepcion.Text = headerData.TotalIIBB.ToString("C2");
                txtTotalFactura.Text = headerData.TotalFacturaN.ToString("C2");
            }
            else
            {
                //moneda presentacion USD
                txtImporteDescuento.Text = (headerData.Descuento.Value / _exchangeRate).ToString("C2");
                txtImporteInicial.Text = (headerData.TotalFacturaB / _exchangeRate).ToString("C2");
                txtBaseImponible.Text = (headerData.TotalImpo / _exchangeRate).ToString("C2");
                txtSubtotal.Text = ((headerData.TotalFacturaB - headerData.Descuento.Value) / _exchangeRate).ToString("C2");
                txtIva21.Text = (headerData.TotalIVA21 / _exchangeRate).ToString("C2");
                txtImportePercepcion.Text = (headerData.TotalIIBB / _exchangeRate).ToString("C2");
                txtTotalFactura.Text = (headerData.TotalFacturaN / _exchangeRate).ToString("C2");
            }
            txtDescuentoPorcentaje.Text = headerData.TotalFacturaB == 0 ? 0.ToString("P2") : headerData.DescuentoPorc.Value.ToString("P2");

        }


        //2019.10.13 Modificacion inclusion factura "B"
        private void CreateNewDocumentT400_T401InMemory()
        {
            if (_tipoLx == "L1")
            {
                //Get Alicuota from ARBA WebService
                if (ckAlicuotaModificada.Checked == false)
                {
                    _alicuotaPercepcion = GetIIBBPercepcion(dtpFechaFactura.Value, txtNumeroCuit.Text);
                    txtAlicuotaIIBB.Text = (_alicuotaPercepcion * 100).ToString("N2");
                }
            }
            _docData = new CustomerInvoice("FAC1", 0);

            // if (_tipoDocumento == ManageDocumentType.TipoDocumento.FacturaVentaB)cmbTipoDocumento.SelectedItem = "FACTURA B"; 

            if (_tipoDocumento == ManageDocumentType.TipoDocumento.FacturaVentaA ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.FacturaVenta2 ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.FacturaVentaB ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.FacturaVentaM ||
                _tipoDocumento == ManageDocumentType.TipoDocumento.FacturaVenta2)
            {
                //se trata de una FacturaA - FacturaB - Factura M o facturaL2 [from Remito]
                txtTc.Text = new ExchangeRateManager().GetExchangeRate(dtpFechaFactura.Value).ToString("N2");
                _docData.CreateNewHeaderInMemory(_tipoDocumento, Convert.ToInt32(txtId6.Text), dtpFechaFactura.Value,
                    txtTipoLx.Text, Convert.ToDecimal(txtTc.Text), alicuotaIIBB: _alicuotaPercepcion,
                    idRemito: _idRemito);
                if (_modo == 5)
                {
                    _docData.CreateItemListFromOV_InMemory(_data);
                }
                else
                {
                    _docData.CreateItemListFromRemito_InMemory();
                }

                t0401FACTURAIBindingSource.DataSource = _docData.GetItemData().ToList();

                txtTipoDocumento.Text = _tipoDocumento.ToString();
                txtNumeroDocumento.Text = @"NO DEFINIDO";
                txtEstadoDocumento.Text = DocumentFIStatusManager.StatusHeader.Pendiente.ToString();
                txtIdCtaCte.Text = @"N/D";
                txtNAS.Text = @"N/D";
                txtIdFactura.Text = @"N/D";
                txtIdFacturaX.Text = @"N/D";
            }
            else
            {
                //No desarrollado aun una creacion de documentos que no sea desde una FacturA//FacturaL2!
                //Posiblemente esta funcion NC/ND se haga desde otro formulario.
                MessageBox.Show(@"NO DESARROLLADO");
                return;
            }
        }
        private string DefineDescripcionDocumento(string tdoc, string lx)
        {
            switch (tdoc.Trim())
            {
                case "FA":
                    return lx == "L1" ? @"FACTURA A" : @"REMITO VALORIZADO";

                case "NC":
                    return lx == "L1" ? @"NOTA CREDITO A" : @"NOTA CREDITO 2";

                case "ND":
                    return lx == "L1" ? @"NOTA DEBITO A" : @"NOTA DEBITO 2";

                case "AJ":
                    return lx == "L1" ? @"AJUSTE INTERNO" : @"AJUSTE INTERNO L2";
                case "FB":
                    return "Factura B";
                case "FM":
                    return "Factura M";
                default:
                    return @"DOCUMENTO NO MANEJADO";
            }
        }

        #region Al Modificar TC - Descuento - Fecha - AlicuotaIIBB
        //-----------------------------------------------------------------------
        private void dtpFechaFactura_ValueChanged(object sender, EventArgs e)
        {
            txtPeriodoARBA.Text = new PeriodoConversion().GetPeriodo(dtpFechaFactura.Value);
            txtAlicuotaIIBB.Text =
                new GestionPercepciones().GetAlicuotaIIBB(txtNumeroCuit.Text, txtPeriodoARBA.Text).ToString("P2");
            _exchangeRate = new ExchangeRateManager().GetExchangeRate(dtpFechaFactura.Value);
            txtTc.Text = _exchangeRate.ToString("N2");
            if (txtEstadoDocumento.Text.ToUpper() == "PENDIENTE")
            {
                _docData.RecalcValuesAfterDataChange_InMemory(_exchangeRate, FormatAndConversions.CPorcentajeADecimal(txtDescuentoPorcentaje.Text), _alicuotaPercepcion);
                MapTotalesFromMemoryToForm();
            }
            else
            {
                //UpdateExchangeRateInT0400();
                //UpdateTotalesAfterDataChanged();
            }

        }

        private void txtTc_Leave(object sender, EventArgs e)
        {

            if (_docData == null)
                return;

            _exchangeRate = Convert.ToDecimal(txtTc.Text);
            txtTc.Text = _exchangeRate.ToString("N2");

            UpdateTotalesAfterDataChanged();

            //_docData.RecalcValuesAfterDataChange_InMemory(_exchangeRate,
            //    FormatAndConversions.CPorcentajeADecimal(txtDescuentoPorcentaje.Text), _alicuotaPercepcion);
            //MapTotalesFromMemoryToForm();
            t0401FACTURAIBindingSource.DataSource = _docData.GetItemData().ToList();

            //if (_facturaIdStruct.IdFactura>0)
            //UpdateExchangeRateInT0400();
            //UpdateTotalesAfterDataChanged();
        }

        private void txtImporteDescuento_Leave(object sender, EventArgs e)
        {
            var con = new FormatAndConversions();
            var impBruto = con.GetDecimal(txtImporteInicial.Text);
            var impDescuento = con.GetDecimal(txtImporteDescuento.Text);
            txtDescuentoPorcentaje.Text = ((impDescuento / impBruto)).ToString("p2");

            if (impDescuento > impBruto)
            {
                MessageBox.Show(@"El Descuento no puede superar al valor de la factura", @"Error en valor de Descuento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtImporteDescuento.Text = @"$0.00";
                txtDescuentoPorcentaje.Text = @"0.00";
                return;
            }
            UpdateTotalesAfterDataChanged();
        }

        private void txtDescuentoPorcentaje_Leave(object sender, EventArgs e)
        {
            var con = new FormatAndConversions();
            var impBruto = con.GetCurrencyFormat_Decimal(txtImporteInicial.Text);
            var impDescuentoPorc = FormatAndConversions.CPorcentajeADecimal(txtDescuentoPorcentaje.Text);
            if (impDescuentoPorc > 1)
            {
                MessageBox.Show(@"Este atento con el valor de Descuento %", @"Error en valor de Descuento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescuentoPorcentaje.Text = 0.ToString("D2");
                txtImporteDescuento.Text = 0.ToString("C2");
                return;
            }
            decimal valorDescuento = (impDescuentoPorc * impBruto);
            txtImporteDescuento.Text = valorDescuento.ToString("c2");
            UpdateTotalesAfterDataChanged();
        }
        private void UpdateExchangeRateInT0400()
        {
            //Esta funcion existe porque al cambiar el exchange rate cambian los 
            //valores de los items y hay que recalcular el total neto
            var factu = new CustomerInvoice("FAC1", _facturaIdStruct.IdFactura);
            factu.UpdateExchangeRate(_exchangeRate);
        }
        private void UpdateTotalesAfterDataChanged()
        {
            if (_docData == null)
                return;

            var con = new FormatAndConversions();
            var descuento = con.GetCurrencyFormat_Decimal(txtImporteDescuento.Text);
            _alicuotaPercepcion = FormatAndConversions.CPorcentajeADecimal(txtAlicuotaIIBB.Text);

            _docData.RecalcValuesAfterDataChange_InMemory(_exchangeRate, FormatAndConversions.CPorcentajeADecimal(txtDescuentoPorcentaje.Text), _alicuotaPercepcion);
            MapTotalesFromMemoryToForm();
            t0401FACTURAIBindingSource.DataSource = _docData.GetItemData().ToList();
            //if (_importeTotalManager == null) return; //si el objeto no existe salir --> se crea despues.
            //_importeTotalManager.RecalculaUpdateValores(_exchangeRate, descuento, alicuotaIIBB);
            //MapValoresImportesAlForm();
        }

        #endregion


        //1.Pendiente,              //solo en memoria
        //2.Registrada,             //datos en T400
        //3.Contabilizada,          //datos en ctacte
        //4.Aprobada,               //datos en ctacte + todo listo para enviar
        //Impresa,                //este estado eliminar!
        //Cancelada,
        //PendienteCAE            //cae pendiente (solo L1)

        private bool ValidaOKContabilizar()
        {
            if (txtEstadoDocumento.Text.ToUpper() != "REGISTRADA")
                return false;

            if (txtMonedaTotales.Text != txtMoneda.Text)
            {
                MessageBox.Show(
                    @"Los importes tienen que estar expresados en la misma moneda que sera contabilizado el documento",
                    @"Diferencia en monedas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }


        #region Botones

        private void btnContabilizar_Click(object sender, EventArgs e)
        {
            if (ValidaOKContabilizar() == false)
                return;

            var dr = MessageBox.Show(
                $@"Confirma la CONTABILIZACION del Documento en Pantalla por el IMPORTE TOTAL de {txtTotalFactura.Text} ?",
                @"Contabilizacion de Documento FI", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.No)
                return;

            var factu = new CustomerInvoice("FAC1", _facturaIdStruct.IdFactura);
            factu.UpdateHeaderValues(FormatAndConversions.CCurrencyADecimal(txtImporteInicial.Text),
                FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text),
                FormatAndConversions.CCurrencyADecimal(txtBaseImponible.Text),
                FormatAndConversions.CPorcentajeADecimal(txtAlicuotaIIBB.Text),
                FormatAndConversions.CCurrencyADecimal(txtImportePercepcion.Text),
                FormatAndConversions.CCurrencyADecimal(txtTc.Text),
                FormatAndConversions.CCurrencyADecimal(txtTotalFactura.Text),
                FormatAndConversions.CCurrencyADecimal(txtIva21.Text));

            var obj = new ContaCustomerFromInvoice("FAC1", _facturaIdStruct.IdFactura);
            var conta1 = obj.ManageContabilizacionCompleta();
            txtNAS.Text = conta1.NumeroAsientoIdDocu.ToString();

            MessageBox.Show(@"Se Ha Contabilizado CORRECTAMENTE el Documento", @"Contabilizacion de Documento OK",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            factu = new CustomerInvoice("FAC1", _facturaIdStruct.IdFactura);
            txtNumeroDocumento.Text = factu.GetNumeroDocumentoCompleto();
            txtEstadoDocumento.Text = factu.GetStatusDocumento();
            if (_modo == 5)
            {
                new Fsr().UpdateKgFacturadosOV(_data, _facturaIdStruct.IdFactura);

                //Accion Margen
                new MargenDocument().AddMargenDocumentAndMapCostFromOVFsr(_data, _facturaIdStruct.IdFactura);
            }
            else
            {
                if (_tipoLx == "L1")
                {
                    new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _facturaIdStruct.IdFactura,
                        txtNumeroDocumento.Text,
                        true); //sigue marcando como PENDIENTE DE FACTURACION hasta aprobar CAE.
                }
                else
                {
                    new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _facturaIdStruct.IdFactura,
                        txtNumeroDocumento.Text, false); //marca como NO PENDIENTE DE FACTURACION
                }
                //Accion Margen
                new MargenDocument().UpdateRemito_FacturaData(_facturaIdStruct.IdFactura);
            }
            AccionEstadoDocumento();
        }

        private bool CheckAllowToPrint()
        {
            return true;
        }

        private void btnImprimirFactura_Click(object sender, EventArgs e)
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
                var f = new RpvFacturaL2(_facturaIdStruct.IdFactura, ckSaldoTotalAdeudadoL2.Checked,
                    ckImpresionConsolidada.Checked);
                f.Show();
            }
        }

        private void btnRecailculaPrecio_Click(object sender, EventArgs e)
        {
            var factu = new CustomerInvoice("FAC", Convert.ToInt32(txtIdFactura.Text));
            factu.RecalculaPrecioItemsFromSalesOrderPrice();
            t0401FACTURAIBindingSource.DataSource = _itemF.ToList();
            //dgvItemFacturaARS.DataSource = _itemF;
            // dgvItemsMonedaCotizacion.DataSource = _itemF;
            // dgvItemsFacturaUSD.DataSource = _itemF;
        }
        private void btnReimprimirDocumento_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAgregarItems_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcion no realizada", @"Funcion no realizada", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        private void btnCancelarContabilizacion_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show(@"Confirma la cancelacion del documento?", @"Cancelar Documento Contabilizado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            dr =
                MessageBox.Show(
                    @"El Documento ya se encuentra impreso" + Environment.NewLine +
                    @"Si cancela la documentacion asegurese de eliminar el Documento (Remito) ya impreso" +
                    Environment.NewLine + @"Cancela el Documento ya Contabilizado?", @"Cancelar Documento Contabilizado",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion

        #region SoloDecimal
        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtImporteDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtDescuentoPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        #endregion

        #region DataGridviews
        //------------------------------------------------------------------------
        private void dgvItemFactura_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var iditem = Convert.ToInt32(dgvItemFacturaARS[dgvItemFacturaARS.Columns["xiditem"].Index, e.RowIndex].Value);
                var descripcion = dgvItemFacturaARS[dgvItemFacturaARS.Columns["xdescripcion"].Index, e.RowIndex].Value.ToString();
                decimal kg = Convert.ToDecimal(dgvItemFacturaARS[dgvItemFacturaARS.Columns["xkg"].Index, e.RowIndex].Value);
                decimal precioUnitario = Convert.ToDecimal(dgvItemFacturaARS[dgvItemFacturaARS.Columns["xpreciounitario"].Index, e.RowIndex].Value);
                //
                _docData.UpdateItemValues_InMemory(iditem, descripcion, kg, txtMoneda.Text, precioUnitario);
                _itemF.Clear();
                _itemF.AddRange(_docData.GetItemData());
                t0401FACTURAIBindingSource.DataSource = _itemF;
                MapTotalesFromMemoryToForm();
                //



                //var factu = new CustomerInvoice("FACTU", _facturaIdStruct.IdFactura);
                //factu.UpdateDatosItemFactura(iditem, descripcion, "ARS", precioUnitario, kg);
                //var con = new FormatAndConversions();

                //_importeTotalManager.RecalculaUpdateValores(_exchangeRate,con.GetCurrencyFormat_Decimal(txtImporteDescuento.Text),con.GetDecimal(txtAlicuotaIIBB.Text));
                //MapValoresImportesAlForm();
                //_itemF.Clear();
                //_itemF.AddRange(factu.GetItemData());

            }
        }
        private void dgvItemsFacturaUSD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var iditem = Convert.ToInt32(dgvItemsFacturaUSD[dgvItemsFacturaUSD.Columns["xiditemU"].Index, e.RowIndex].Value);
                var descripcion = dgvItemsFacturaUSD[dgvItemsFacturaUSD.Columns["xdescripcionU"].Index, e.RowIndex].Value.ToString();
                decimal kg = Convert.ToDecimal(dgvItemsFacturaUSD[dgvItemsFacturaUSD.Columns["xkgU"].Index, e.RowIndex].Value);
                decimal precioUnitario = Convert.ToDecimal(dgvItemsFacturaUSD[dgvItemsFacturaUSD.Columns["xpreciounitarioU"].Index, e.RowIndex].Value);

                _docData.UpdateItemValues_InMemory(iditem, descripcion, kg, "USD", precioUnitario);
                _itemF.Clear();
                _itemF.AddRange(_docData.GetItemData());
                t0401FACTURAIBindingSource.DataSource = _itemF;
                MapTotalesFromMemoryToForm();





                //var factu = new CustomerInvoice("FACTU", _facturaIdStruct.IdFactura);
                //factu.UpdateDatosItemFactura(iditem, descripcion, "USD", precioUnitario, kg);
                //var con = new FormatAndConversions();
                //_importeTotalManager.RecalculaUpdateValores(_exchangeRate, con.GetCurrencyFormat_Decimal(txtImporteDescuento.Text), con.GetDecimal(txtAlicuotaIIBB.Text));
                //MapValoresImportesAlForm();
                //_itemF.Clear();
                //_itemF.AddRange(factu.GetItemData());
            }
        }

        #endregion

        private void txtZterm_DoubleClick(object sender, EventArgs e)
        {
            using (var f0 = new FrmSeleccionZTerm(1, Convert.ToInt32(txtId6.Text), txtLx.Text))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    txtZterm.Text = f0.zterm;
                    txtZtermDescripcion.Text = f0.ztermDescripcion;

                    using (var db = new TecserData(GlobalApp.CnnApp))
                    {
                        var header = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _facturaIdStruct.IdFactura);
                        if (header != null)
                        {
                            header.ZTERM = f0.zterm;
                        }
                        db.SaveChanges();
                    }
                }
                else
                {
                    //cancelo no hace nada.-
                }
            }
        }
        private void txtCodigoAprobacion_Leave(object sender, EventArgs e)
        {
            if (txtCodigoAprobacion.Text == @"0320")
            {
                dgvItemFacturaARS.ReadOnly = false;
                dgvItemsFacturaUSD.ReadOnly = false;
                dgvItemFacturaARS.Enabled = true;
                dgvItemsFacturaUSD.Enabled = true;
                MessageBox.Show(@"Se ha aprobado correctamente la modificacion de precios", @"Aprobacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvItemFacturaARS.ReadOnly = true;
                // dgvItemsMonedaCotizacion.ReadOnly = true;
                MessageBox.Show(@"Codigo de Autorizacion Incorrecto!", @"Aprobacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void rbMonedaFactura_CheckedChanged(object sender, EventArgs e)
        {
            rbMonedaFactura.BackColor = Color.Transparent;
            rbMonedaUSD.BackColor = Color.Transparent;

            if (rbMonedaFactura.Checked)
            {
                //moned ARS
                rbMonedaFactura.BackColor = Color.Yellow;
                dgvItemFacturaARS.Visible = true;
                dgvItemsFacturaUSD.Visible = false;
                txtMonedaTotales.Text = @"ARS";
                txtMonedaTotales.BackColor = Color.Green;
            }
            else
            {
                //moneda USD
                rbMonedaUSD.BackColor = Color.Yellow;
                dgvItemFacturaARS.Visible = false;
                dgvItemsFacturaUSD.Visible = true;
                txtMonedaTotales.Text = @"USD";
                txtMonedaTotales.BackColor = Color.Crimson;
            }

            MapTotalesFromMemoryToForm();
        }
        private void btnSolicitarCAE_Click_1(object sender, EventArgs e)
        {

            var x = new CustomerInvoice(_tipoLx, _facturaIdStruct.IdFactura);
            if (x.GetTipoDocumentoDb() != ManageDocumentType.GetSystemDocumentType(_tipoDocumento))
            {
                var resp = MessageBox.Show(@"Atencion se va a cambiar el tipo de documento registrado. Desea Continuar?",
                    "Consulta Tipo Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;

                x.UpdateDocumentType(_tipoDocumento);
            }





            var modoEjecucion = new ModoEjecucion();
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

            if (fe.CheckSiPermiteSolicitarCAE(_facturaIdStruct.IdFactura))
            {
                var dr =
                    MessageBox.Show(
                        $@"Confirma que desea SOLICITAR CAE a AFIP para el documento contabilizado por IMPORTE $ {txtTotalFactura.Text}",
                        @"SOLICITUD DE CAE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                    return;
            }
            else
            {
                MessageBox.Show(@"El Documento NO SE Encuentra en condiciones de solicitar CAE",
                    @"Fallo de Condiciones para Pedir CAE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resultado = fe.SolicitudCAEFromT0400(_facturaIdStruct.IdFactura,null,null,null);

            if (resultado.Resultado == "A")
            {
                txtCAE.Text = resultado.CAE;
                txtCAEVencimiento.Text = resultado.VencimientoCAE.ToString("d");
                txtNumeroDocumento.Text = resultado.PuntoVenta.PadLeft(4, '0') + @"-" +
                                          resultado.ComprobanteHasta.PadLeft(8, '0');

                fe.UpdateDataAfterDocumentNumberGetFromAFIP(_facturaIdStruct.IdFactura,
                    resultado.PuntoVenta.PadLeft(4, '0'),
                    resultado.ComprobanteHasta.PadLeft(8, '0'), resultado.CAE, resultado.VencimientoCAE,
                    Convert.ToInt32(txtNAS.Text));
                new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _facturaIdStruct.IdFactura,
                    txtNumeroDocumento.Text, false);

                if (string.IsNullOrEmpty(txtImportePercepcion.Text))
                    txtImportePercepcion.Text = 0.ToString("C2");

                if (FormatAndConversions.CCurrencyADecimal(txtImportePercepcion.Text) != 0)
                {
                    var idfx = Convert.ToInt32(txtIdFacturaX.Text);
                    new PercepcionesManager().AddFacturaPercepcion(idfx);
                }

                txtEstadoDocumento.Text = DocumentFIStatusManager.StatusHeader.Aprobada.ToString().ToUpper();
                AccionEstadoDocumento();
            }
            else
            {
                MessageBox.Show(
                    $@"Ha Ocurrido un error al solicitar el CAE * observacion >> {resultado.Wsfev1Observacion}",
                    @"Error en SOLICITUD DE CAE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtEstadoDocumento.Text = DocumentFIStatusManager.StatusHeader.PendienteCAE.ToString().ToUpper();
                AccionEstadoDocumento();
            }
        }
        private void txtTc_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnLeyendasFactura_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmLeyendasFactura(_facturaIdStruct.IdFactura))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ckPreImpreso.Checked = f0.CkPreimpreso;
                    ckImprimirMensajeMora.Checked = f0.CkImprimirMora;
                    ckSaldoTotalAdeudadoL2.Checked = f0.CkImprimirSaldoL2;
                    txtObservacionesAdicionalesImprimir.Text = f0.Observacion;
                }
            }
        }
        private void btnSetEstadoRegistrado_Click(object sender, EventArgs e)
        {
            var confirma = MessageBox.Show(@"Confirma la REGISTRACION del Documento?", @"Registracion de Documento",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirma == DialogResult.No)
                return;

            _facturaIdStruct = _docData.GrabaDocumentoToDatabase();

            if (new DocumentFIStatusManager().SetStatusRegistrado(_facturaIdStruct.IdFactura))
            {
                txtEstadoDocumento.Text = DocumentFIStatusManager.StatusHeader.Registrada.ToString().ToUpper();
                txtIdFactura.Text = _facturaIdStruct.IdFactura.ToString();
                txtIdFacturaX.Text = _facturaIdStruct.IdFacturaX.ToString();
                txtEstadoDocumento.BackColor = Color.GreenYellow;
                AccionEstadoDocumento();
                if (_modo == 5)
                {
                    new Fsr().SetFsrRecord(_data, _facturaIdStruct.IdFactura);
                }
                else
                {
                    new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _facturaIdStruct.IdFactura);
                }
            }
            else
            {
                MessageBox.Show(@"La Factura no pudo ser pasada a estado REGISTRADA", @"Error en Cambio de Estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnARBA_Click(object sender, EventArgs e)
        {
            var fechaDesde = new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(txtPeriodoARBA.Text);
            var fechaHasta = new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(txtPeriodoARBA.Text);

            var dataArba = new PadronArba();
            dataArba.Conectar(txtNumeroCuit.Text, fechaDesde, fechaHasta);
            txtAlicuotaIIBB.Text = dataArba.AlPerc.ToString("P");
            UpdateTotalesAfterDataChanged();

        }
        private void txtAlicuotaIIBB_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtAlicuotaIIBB_Leave(object sender, EventArgs e)
        {
            var x = (TextBox)sender;
            if (string.IsNullOrEmpty(x.Text))
                x.Text = 0.ToString("P2");

            var importe = FormatAndConversions.CPorcentajeADecimal(x.Text);
            if (importe > 100)
            {
                MessageBox.Show(@"El importe de la Alicuota es Incorrecta", @"Error en Alicuota IIBB",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                x.Text = 0.ToString("P2");
            }
            UpdateTotalesAfterDataChanged();
            //_importeTotalManager.RecalculaUpdateValores(_exchangeRate,FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text), FormatAndConversions.CPorcentajeADecimal(x.Text));
        }
        private void btnSetEstadoInicial_Click(object sender, EventArgs e)
        {
            var confirma = MessageBox.Show(@"Confirma el regreso del documento a estado PENDIENTE (se remueven los CostItems y se vuelven a generar)?", @"Registracion de Documento",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirma == DialogResult.No)
                return;

            if (new DocumentFIStatusManager().SetStatusPendiente(_facturaIdStruct.IdFactura))
            {
                txtEstadoDocumento.Text = DocumentFIStatusManager.StatusHeader.Pendiente.ToString().ToUpper();
                txtEstadoDocumento.BackColor = Color.Orange;
                new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, 0);
                txtIdFactura.Text = @"N/D";
                txtIdFacturaX.Text = @"N/D";
                _facturaIdStruct.IdFactura = 0;
                _facturaIdStruct.IdFacturaX = 0;

                CreateNewDocumentT400_T401InMemory();  //aca esta all in memoria  
                MapTotalesFromMemoryToForm();

                //_docData.
                AccionEstadoDocumento();
            }
            else
            {
                MessageBox.Show(@"La Factura no pudo ser pasada a estado REGISTRADA", @"Error en Cambio de Estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnConsolidar_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(@"Desea consolidar las lineas de la factura?", @"Consolidacion de Lineas",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            _itemF = _docData.InformacionFacturaConsolidada();
            t0401FACTURAIBindingSource.DataSource = _itemF;
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Proximamente", @"Funcionalidad Limitada", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Proximamente", @"Funcionalidad Limitada", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
                    case "Factura A":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.FacturaVentaA;
                        txtTipoDocumento.Text = _tipoDocumento.ToString();
                        break;
                    case "Factura B":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.FacturaVentaB;
                        txtTipoDocumento.Text = _tipoDocumento.ToString();
                        break;
                    case "Factura M":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.FacturaVentaM;
                        txtTipoDocumento.Text = _tipoDocumento.ToString();
                        break;
                    case "Presupuesto X":
                        _tipoDocumento = ManageDocumentType.TipoDocumento.FacturaVenta2;
                        txtTipoDocumento.Text = _tipoDocumento.ToString();
                        break;
                    default:
                        break;
                }
                if (_docData != null)
                    _docData.UpdateTipoDocumento(_tipoDocumento);


            }
        }
    }
}



