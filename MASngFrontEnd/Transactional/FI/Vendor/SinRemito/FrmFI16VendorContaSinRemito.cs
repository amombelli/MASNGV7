using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData;
using MASngFE.SuperMD;
using MASngFE.Transactional.FI.ContabilizacioFactura.SinRemito;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.Imputacion;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Vendor.SinRemito
{
    public partial class FrmFI16VendorContaSinRemito : Form
    {
        public FrmFI16VendorContaSinRemito(int modo = 0)
        {
            InitializeComponent();
            _modo = modo;
        }

        //Modo5 - Contabilizacion desde Agregado Automatico de documentos
        public FrmFI16VendorContaSinRemito(string cuit, string numeroDocumento, DateTime fechaDocumento,
            decimal precioU, int modo = 5)
        {
            _modo = modo;
            var vendor = new VendorManager().GetSpecificVendor(cuit);
            if (vendor != null)
            {
                _vendorId5 = vendor.id_prov;
            }
            else
            {
                MessageBox.Show(@"No se puede continuar porque no se ha encontrado un vendor registrado",
                    @"Vendor Inexistente o Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            _fechaDocumento = fechaDocumento;
            _importeTotal = precioU;
            _numeroDoc = numeroDocumento;
            _tipoLx = "L1";
            InitializeComponent();
            rbL1.Checked = true;
            mskFechaFactura.Text = completaFechaMask(_fechaDocumento.Value);
        }

        public FrmFI16VendorContaSinRemito(int modo, int idRendicion)
        {
            InitializeComponent();
            _modo = modo;
            _idRendicion = idRendicion;
        }

        //------------------------------------------------------------------------------------------------------------
        private int _vendorId;
        private int _vendorId5; //ver si se retira
        private DateTime? _fechaDocumento;
        private static DateTime _prevClick;
        private readonly List<T0404_VENDOR_FACT_I> _lItems = new List<T0404_VENDOR_FACT_I>();
        private readonly int _modo;
        private readonly int _idRendicion;
        private readonly Color _colorCkOk = Color.LightGreen;
        private readonly Color _colorCkError = Color.OrangeRed;
        private Color _colorCkSinInicializar = Color.Gold;
        private bool _cuitValidado;
        private string _numeroDoc;
        private decimal _importeTotal;
        private string _tipoLx;
        private bool _periodoOK = false;
        private bool _validacionInicial = false;
        private bool _docuNumValidado = false;
        private bool _validarDocumentoNumeroMaskCompleted = true;
        private int _signoConta = 1;
        //------------------------------------------------------------------------------------------------------------


        private string completaFechaMask(DateTime fecha)
        {
            return fecha.Day.ToString("D2") + fecha.Month.ToString("D2") +
                   fecha.Year.ToString("D4");
        }

        private void FrmContabilizacionSinRemito_Load(object sender, EventArgs e)
        {
            ConfiguraInitialData();
            if (_modo == 1 && _idRendicion > 0)
            {
                CuentasBs.DataSource = new CuentasManager().GetListaCuentasAvailableForContar(txtMoneda.Text);
                LoadRendicion();
            }

            if (_modo == 5)
            {
                //modo auto load factura from AFIP
                cmbRazonSocial.SelectedValue = _vendorId5;
                mskFechaFactura.Text = completaFechaMask(_fechaDocumento.Value);
                txtNumeroDocumento.Text = _numeroDoc;
                txtNumeroDocumento.Focus();
                txtPrecioU.Text = _importeTotal.ToString("N2");
                txtPrecioT.Text = _importeTotal.ToString("N2");
                txtPrecioU.Focus();
            }
        }

        private void LoadRendicion()
        {
            var data = new RendicionFF().GetDataRendicion(_idRendicion);
            var items = new RendicionFF().GetDataRendicionItems(_idRendicion);
            _vendorId = data.idVendor;
            cmbRazonSocial.SelectedValue = _vendorId;
            mskFechaFactura.Text = completaFechaMask(data.fechaDocumento);
            txtTc.Text = new ExchangeRateManager().GetExchangeRate(data.fechaDocumento).ToString("N2");
            txtPeriodoFI.Text = new PeriodoAvailability().CheckPeriodoOpenFI(data.fechaDocumento).ToString();
            switch (data.tipoDocumento)
            {
                case "FPA":
                    txtTipoDocumento.Text = @"FPA";
                    cmbTipoDocumento.SelectedText = "FACTURA A";
                    break;
                case "TKT":
                    cmbTipoDocumento.SelectedText = "TICKET L2";
                    txtTipoDocumento.Text = @"TKT";
                    break;
                case "ZZ":
                    cmbTipoDocumento.SelectedText = "SIN-COMPROBANTE";
                    txtTipoDocumento.Text = @"ZZ";
                    break;
                default:
                    MessageBox.Show(@"El Tipo de documento no esta configurado.- Revise manualmente", @"Tipo No Valido",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            txtNumeroDocumento.Text = data.numeroDocumento;
            txtObservacion.Text = data.Comentario;
            rbNormal.Checked = true;
            txtImporteBruto.Text = data.importeBruto.ToString("C2");
            txtImporteDescuento.Text = data.descuento.ToString("C2");
            txtSubtotal.Text = data.subtotal.ToString("C2");
            txtBaseImponible.Text = data.baseImponible.ToString("C2");
            txtIva10.Text = data.iva10.ToString("C2");
            txtIva21.Text = data.iva21.ToString("C2");
            txtIva27.Text = data.iva27.ToString("C2");
            var totalIVA = data.iva21 + data.iva10 + data.iva27;
            txtTotalIva.Text = totalIVA.ToString("C2");
            txtPercIva.Text = data.impPercIVA.ToString("C2");
            txtPercIIBB.Text = data.impPercIIBB.ToString("C2");
            txtImpuMunicipal.Text = data.impMunicipales.ToString("C2");
            txtImpuProvincial.Text = data.impProvinciales.ToString("C2");
            txtImpuInternos.Text = data.impInternos.ToString("C2");
            txtImpuOtros.Text = data.otrosImpuestos.ToString("C2");
            txtConcpetoNoGravado.Text = data.concNoGravados.ToString("C2");
            var otrosImpuestos = data.impMunicipales + data.impProvinciales + data.impInternos +
                                 data.otrosImpuestos + data.concNoGravados;

            txtTotalPercepciones.Text = (data.impPercIVA + data.impPercIIBB).ToString("C2"); //falta percepcion de ganancias
            txtTotalOtroImpuestos.Text = (otrosImpuestos).ToString("C2");
            txtImporteNetoFinal.Text = data.ImporteNetoFinal.Value.ToString("C2");
            cmbCuentaAPagar.SelectedValue = data.RendicionCuentaGLId.ToString();
            txtImporteAPagar.Text = data.ImporteNetoFinal.Value.ToString("C2");

            foreach (var i in items)
            {
                var z = new T0404_VENDOR_FACT_I()
                {
                    CANT = Convert.ToDecimal(i.cantidad),
                    IDIT = i.idItem,
                    ITEM_DESC = i.itemDescripcion,
                    MONEDA = "ARS",
                    PUNIT = i.precioUnitario,
                    PUNIT_ARS = i.precioUnitario,
                    PTOTAL_ARS = i.precioTotal,
                    GL = i.glItem,
                    IDITEM = "GENERICO",
                };
                _lItems.Add(z);
            }

            t0404VENDORFACTIBindingSource.DataSource = _lItems.ToList();
            dgvDetalleItems.DataSource = t0404VENDORFACTIBindingSource.DataSource;
        }

        private void ConfiguraInitialData()
        {
            cmbRazonSocial.Enabled = true;
            cmbFantasia.Enabled = true;
            mskFechaFactura.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNumeroDocumento.Enabled = true;
            gpbTipoContabilizacion.Enabled = true;
            rbNormal.Checked = true;
            this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            cmbRazonSocial.DataSource = new VendorManager().GetCompleteListVendors(true).OrderBy(c => c.prov_rsocial).ToList();
            cmbFantasia.DataSource = new VendorManager().GetCompleteListVendors(true).OrderBy(c => c.prov_fantasia).ToList();
            rbNormal.BackColor = Color.LightGreen;
            ckMantenerInfoRecord.Checked = false;
            ckMantenerInfoRecord.BackColor = Color.Yellow;
            ResetImportes();
            txtUsuario.Text = Environment.UserName;
            txtNumeroDocumento.ReadOnly = true;

            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            mskCuit.Text = null;
            txtIdProveedor.Text = null;
            _vendorId = -1;

            ckOkAddItems.Checked = false;
            ckVendorActivo.Checked = false;
            ckNumeroDocumentoOK.Checked = false;
            ckPeriodoOK.Checked = false;
            ckOkAddItems.Checked = false;
            ckContabilizadoOK.Checked = false;
            ckUpdate203.Checked = false;
            ckSaldosVendorOK.Checked = false;
            ckDocument403Ok.Checked = false;
            ckContabilizacinPagoOK.Checked = false;

            ckOkAddItems.BackColor = Color.Yellow;
            ckVendorActivo.BackColor = Color.Yellow;
            ckNumeroDocumentoOK.BackColor = Color.Yellow;
            ckPeriodoOK.BackColor = Color.Yellow;
            ckOkAddItems.BackColor = Color.Yellow;
            ckContabilizadoOK.BackColor = Color.Yellow;
            ckUpdate203.BackColor = Color.Yellow;
            ckSaldosVendorOK.BackColor = Color.Yellow;
            ckDocument403Ok.BackColor = Color.Yellow;
            ckContabilizacinPagoOK.BackColor = Color.Yellow;

            ckAutoIVA21.Checked = false;
            ckAutoIVA21.BackColor = Color.Yellow;

            txtId403.Text = @"0";
            txtidCtaCte.Text = @"0";
            txtNAS.Text = @"0";
            txtnumeroAsientoPago.Text = @"0";

            txtNumeroDocumento.Text = null;
            cmbTipoDocumento.Text = null;

            txtImporteAPagar.Text = 0.ToString("C2");
            cmbCuentaAPagar.SelectedIndex = -1;
            ckSoloGLCompras.Checked = true;

            _lItems.Clear();
            t0404VENDORFACTIBindingSource.DataSource = _lItems;
            dgvDetalleItems.DataSource = null;
            dgvDetalleItems.DataSource = t0404VENDORFACTIBindingSource.DataSource;
            btnNuevaContabilizacion.Enabled = false;
            btnContaOperacion.Enabled = true;
            btnPagoDirecto.Enabled = false;
            btnAddItem.Enabled = true;
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);

            t0135GLXBindingSource.DataSource = ckSoloGLCompras.Checked
                ? new GLAccountManagement().GetListGLImputacionCompras()
                : new GLAccountManagement().GetGLListPermiteImputacion();
            cmbGlImputacionItem.SelectedIndex = -1;
            txtGlDescripcionItem.Text = null;
        }

        private void UpdateDataWhenVendorIsChanged(int id)
        {
            if (_vendorId == id)
                return;

            _vendorId = id; //Convert.ToInt32(cmbRazonSocial.SelectedValue);
            ckVendorActivo.Checked = new VendorManager().GetSpecificVendor(_vendorId).ACTIVO.Value;
            ckVendorActivo.BackColor = ckVendorActivo.Checked ? Color.Lime : Color.Crimson;

            var ctacte = new CtaCteVendor(_vendorId);
            var r1 = ctacte.GetResultadoCtaCte("L1");
            var r2 = ctacte.GetResultadoCtaCte("L2");
            txtSaldoL1.Text = r1.SaldoDetalle.ToString("C2");
            txtSaldoL2.Text = r2.SaldoDetalle.ToString("C2");
            txtSaldoL1.BackColor = r1.SaldoColor;
            txtSaldoL2.BackColor = r2.SaldoColor;

            txtGlAp.Text = new GLAccountManagement().GetApVendorGl(_vendorId);
            if (_modo != 5)
            {
                mskFechaFactura.Text = "";
                _fechaDocumento = null;

            }

            _periodoOK = false;
            ckPeriodoOK.Checked = _periodoOK;
            txtPeriodoFI.Text = null;
            txtPeriodoFI.BackColor = Color.Yellow;
            txtNumeroDocumento.Text = null;
            //txtNumeroDocumento.ReadOnly = true;
            var listaInfoRecords = new VendorManager().GetListItemsProveedor(_vendorId);
            cmbDescripcionItem.DataSource = listaInfoRecords;
            if (_modo == 5)
                return;

            if (listaInfoRecords.Count != 1)
                cmbDescripcionItem.Text = null;
        }

        private T0403_VENDOR_FACT_H Map403H()
        {
            var h = new T0403_VENDOR_FACT_H
            {
                FECHA = _fechaDocumento.Value,
                IDPROV = _vendorId,
                IDINT = 0,
                TC = Convert.ToDecimal(txtTc.Text),
                BRUTO = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteBruto.Text) * _signoConta,
                DTO = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteDescuento.Text) * _signoConta,
                SUBTOTAL = new FormatAndConversions().GetCurrencyFormat_Decimal(txtSubtotal.Text) * _signoConta,
                BaseImponible = new FormatAndConversions().GetCurrencyFormat_Decimal(txtBaseImponible.Text) * _signoConta,
                IVA10 = new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva10.Text) * _signoConta,
                IVA21 = new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva21.Text) * _signoConta,
                IVA27 = new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva27.Text) * _signoConta,
                TOTALIVA = new FormatAndConversions().GetCurrencyFormat_Decimal(txtTotalIva.Text) * _signoConta,
                PerIVA = new FormatAndConversions().GetCurrencyFormat_Decimal(txtPercIva.Text) * _signoConta,
                PerIVA_Alicuota = FormatAndConversions.CPorcentajeADecimal(txtAlicIva.Text),
                PerIIBB = new FormatAndConversions().GetCurrencyFormat_Decimal(txtPercIIBB.Text) * _signoConta,
                PerIIBB_Alicuota = FormatAndConversions.CPorcentajeADecimal(txtAlicIIBB.Text),
                PerIIBB_TXT = txtDistritoIIBB.Text,

                ImpuestoMunicipal = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImpuMunicipal.Text) * _signoConta,
                ImpuestoProvincial = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImpuProvincial.Text) * _signoConta,
                IMPINT = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImpuInternos.Text) * _signoConta,
                IMPOTR = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImpuOtros.Text) * _signoConta,
                ConceptosNoGravados = new FormatAndConversions().GetCurrencyFormat_Decimal(txtConcpetoNoGravado.Text) * _signoConta,
                TotalImpuestosVarios = new FormatAndConversions().GetCurrencyFormat_Decimal(txtTotalOtroImpuestos.Text) * _signoConta,
                NETO = _importeTotal * _signoConta,
                TCODE = "CONTAR",
                GLAP = txtGlAp.Text,
                CANTKG = Convert.ToDecimal(txtKgTotalFacturados.Text) * _signoConta,
                OBSERVACION = txtObservacion.Text,
                SALDOIMPAGO = _importeTotal * _signoConta,
                MON = txtMoneda.Text,
                TFACTURA = txtTipoDocumento.Text,
                NFACTURA = _numeroDoc,
                TIPO = _tipoLx,
                IMPORI = _importeTotal * _signoConta,
                StatusDocumento = "A Validar",
                PerGS = 0,
                PerGA_Alicuota = 0,
                RedondeoFinal = new FormatAndConversions().GetCurrencyFormat_Decimal(txtRedondeoVarios.Text) * _signoConta,
            };
            return h;
        }
        private List<T0404_VENDOR_FACT_I> Map404Items(int idInterno403)
        {
            var lst = new List<T0404_VENDOR_FACT_I>();
            foreach (var i in _lItems)
            {
                var x = new T0404_VENDOR_FACT_I()
                {
                    CANT = i.CANT,
                    IDITEM = i.IDITEM,

                    ITEM_DESC = i.ITEM_DESC,
                    GL = i.GL,
                    PUNIT = i.PUNIT,
                    PTOTAL_ARS = i.PTOTAL_ARS,
                    PUNIT_ARS = i.PUNIT_ARS,
                    IDINT = 0,
                    IDIT = i.IDIT,
                    BRUTO = i.BRUTO,
                };
                lst.Add(x);
            }

            return lst;
        }

        private T0203_CTACTE_PROV MapFormDataToCtaCte203Structure()
        {
            var docu = new T0203_CTACTE_PROV()
            {
                IDCTACTE = 0,
                TDOC = txtTipoDocumento.Text,
                NUMDOC = _numeroDoc,
                DOC_INTERNO = null,
                Fecha = _fechaDocumento.Value,
                ZTERM = new VendorManager().GetZterm(_vendorId, _tipoLx),
                IDPROV = _vendorId,
                MONEDA = txtMoneda.Text,
                TC = Convert.ToDecimal(txtTc.Text),
                ZOP = false,
                TIPO = _tipoLx,
                IdFacturaX = 0,
                LogDate = DateTime.Now,
                LogUsuario = Environment.UserName,
            };
            if (txtMoneda.Text == @"ARS")
            {
                docu.IMPORTE_ORI = _importeTotal * _signoConta;
                docu.IMPORTE_ARS = _importeTotal * _signoConta;
            }
            else
            {
                docu.IMPORTE_ORI = _importeTotal * _signoConta;
                docu.IMPORTE_ARS = _importeTotal * Convert.ToDecimal(txtTc.Text) * _signoConta;
            }

            docu.SALDOFACTURA = docu.IMPORTE_ARS;
            return docu;
        }

        /// <summary>
        /// Contabiliza el documento completo (Actualizacion CtaCte, Asientos, Sub-Modulo
        /// </summary>
        private bool ContabilizacionContar()
        {
            if (rbNormal.Checked)
            {
            }

            if (rbGN.Checked)
            {
            }

            if (rbRetorno.Checked)
            {
            }

            //1 Add Factura 203 + Update deuda 204  >>retorno idctacte
            var ctacte = new CtaCteVendor(_vendorId);
            var data = MapFormDataToCtaCte203Structure();

            var idCtaCte = ctacte.AddCtaCteDetalleRecord(data.TDOC, data.TIPO, data.Fecha.Value, data.NUMDOC,
                data.DOC_INTERNO, data.MONEDA, data.IMPORTE_ORI.Value, data.TC.Value, data.SALDOFACTURA.Value, data.IMPORTE_ARS.Value,
                data.IdFacturaX.Value, data.IdFacturaX.Value);

            if (idCtaCte > 0)
            {
                txtidCtaCte.Text = idCtaCte.ToString();
                ckUpdate203.Checked = true;
                ckUpdate203.BackColor = _colorCkOk;
                ctacte.UpdateSaldoCtaCteResumen(data.TIPO, data.IMPORTE_ORI.Value, data.MONEDA, data.TC);
                var result = ctacte.GetResultadoCtaCte(data.TIPO);
                ckSaldosVendorOK.Checked = result.SaldoOK;
                ckSaldosVendorOK.BackColor = result.SaldoOK ? _colorCkOk : _colorCkError;
            }
            else
            {
                txtidCtaCte.Text = @"Error";
                ckUpdate203.Checked = false;
                ckUpdate203.BackColor = _colorCkError;
                return false;
            }

            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;

            //2. Add Record 403 + 404
            var vendorInvoice = new VendorInvoice(_vendorId, "CONTAR0");

            var data403 = Map403H();
            vendorInvoice.CreateNewHeaderInMemory(data403.TIPO, data403.FECHA, data403.MON, data403.TFACTURA,
                data403.NFACTURA,
                data403.IMPORI, data403.TC, data403.BRUTO, data403.DTO, data403.SUBTOTAL,
                data403.BaseImponible, data403.IVA10, data403.IVA21, data403.IVA27,
                data403.IMPINT,
                data403.IMPOTR, data403.PerIVA, data403.PerIVA_Alicuota.Value, data403.PerIIBB,
                data403.PerIIBB_Alicuota.Value, data403.PerIIBB_TXT, data403.ImpuestoMunicipal,
                data403.ImpuestoProvincial, data403.ConceptosNoGravados, data403.NETO, data403.GLAP,
                data403.OBSERVACION, data403.CANTKG.Value, data403.PerGS, data403.PerGA_Alicuota.Value,
                data403.RedondeoFinal, data403.StatusDocumento);



            foreach (var ix in _lItems)
            {
                vendorInvoice.AddItemInMemory(ix.CANT.Value * _signoConta, ix.ITEM_DESC, ix.MONEDA, ix.PUNIT.Value, data403.TC,
                    ix.GL);
            }

            var resultadoDoc = vendorInvoice.GrabaDocumento();

            if (resultadoDoc.IdFactura > 0 && resultadoDoc.CantidadItems > 0)
            {
                txtId403.Text = resultadoDoc.IdFactura.ToString();
                txtidFacturaX.Text = resultadoDoc.IdFacturaX.ToString();
                ckDocument403Ok.Checked = true;
                ckDocument403Ok.BackColor = _colorCkOk;
                ctacte.UpdateData403InCtaCteRecord(idCtaCte, resultadoDoc.IdFactura, resultadoDoc.IdFacturaX);
            }
            else
            {
                txtId403.Text = @"Error";
                ckDocument403Ok.Checked = false;
                ckDocument403Ok.BackColor = _colorCkError;
            }

            //Asientos Contables
            AsientoBase.IdentificacionAsiento resultadoAsientoC = new AsientoBase.IdentificacionAsiento();
            if (rbNormal.Checked)
            {
                //retornoAsiento =
                //    new AsientoVendorSpecific("CONTAR").AsientoFromVendorDocument(Convert.ToInt32(txtId403.Text));
                var asiento = new AsientoVendorDocument(resultadoDoc.IdFactura, "CONTA0");
                resultadoAsientoC = asiento.AsientoFromVendorFactura();
            }

            if (rbGN.Checked)
            {
                //Contabilizacion de Gastos GN
            }

            if (rbRetorno.Checked)
            {
                //Contabilizacion de Gastos Estructura a Empleado (si fuera diferente)
            }


            if (resultadoAsientoC.IdDocu > 0)
            {
                vendorInvoice.UpdateIdCtaCte_NAS_T403(resultadoDoc.IdFactura, idCtaCte, resultadoAsientoC.IdDocu);
                MessageBox.Show(@"La factura se ha contabilizado correctamente!", @"Contabilizacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ckContabilizadoOK.Checked = true;
                ckContabilizadoOK.BackColor = _colorCkOk;
                txtNAS.Text = resultadoAsientoC.IdDocu.ToString();
            }
            else
            {
                MessageBox.Show(@"Ocurrio un error al generar el Asiento Contable", @"Contabilizacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ckContabilizadoOK.Checked = false;
                ckContabilizadoOK.BackColor = _colorCkError;
                txtNAS.Text = @"Error";
            }

            return true;
        }

        private bool ValidaAntesContabilizacion()
        {
            if (_lItems.Count == 0)
            {
                MessageBox.Show(@"Debe agregar al menos UN item para contabilizar!", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (_importeTotal <= 0)
            {
                MessageBox.Show(@"El Importe a Contabilizar es Incorrecto", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (rbNormal.Checked == false)
            {
                //Si es Estructura o GN debe existir el empleado
                //falta hacer el chequeo
                MessageBox.Show(@"El empleado no existe o no permite imputacion de retorno", @"Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNormal.Checked)
            {
                rbNormal.BackColor = Color.PaleGreen;
                rbGN.BackColor = Color.Transparent;
                rbRetorno.BackColor = Color.Transparent;
                lblRetornoA.Visible = false;
                cmbRetornoA.Enabled = false;
            }

            if (rbGN.Checked)
            {
                rbGN.BackColor = Color.PaleGreen;
                rbNormal.BackColor = Color.Transparent;
                rbRetorno.BackColor = Color.Transparent;
                lblRetornoA.Visible = true;
                cmbRetornoA.Enabled = true;
            }

            if (rbRetorno.Checked)
            {
                rbRetorno.BackColor = Color.PaleGreen;
                rbNormal.BackColor = Color.Transparent;
                rbGN.BackColor = Color.Transparent;
                lblRetornoA.Visible = true;
                cmbRetornoA.Enabled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void ResetImportes()
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
            txtObservacion.Text = null;
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel5.Enabled = true;
        }

        private void SumaImportes(bool recalculoAutomaticoIva21, bool recalculoBaseImponible)
        {
            var id = 1;
            decimal importeBruto = 0;
            decimal totalKg = 0;
            decimal BaseImpoX = 0;
            foreach (var i in _lItems)
            {
                i.IDIT = id;
                importeBruto += i.PTOTAL_ARS.Value;
                totalKg += i.CANT.Value;
                id++;

                if (ckAutoIVA21.Checked)
                {
                    i.IVA = true;
                }
                else
                {
                    i.IVA = false;
                }

                if (i.IVA.Value)
                {
                    BaseImpoX += i.PTOTAL_ARS.Value;
                }
            }

            txtImporteBruto.Text = importeBruto.ToString("C2");
            txtKgTotalFacturados.Text = totalKg.ToString("N2");

            decimal descuento = FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text);
            decimal subtotal = importeBruto - descuento;
            txtSubtotal.Text = subtotal.ToString("C2");
            decimal baseImponible = recalculoBaseImponible ? BaseImpoX : FormatAndConversions.CCurrencyADecimal(txtBaseImponible.Text);
            if (_tipoLx == @"L1" && recalculoAutomaticoIva21)
            {
                decimal valorIva21 = baseImponible * (decimal)0.21;
                txtIva21.Text = valorIva21.ToString("C2");
            }

            txtBaseImponible.Text = baseImponible.ToString("C2");

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

            _importeTotal = subtotal + totalIVA + totalPercepciones + totalOtrosImpuestos + importeRedondeo;
            txtImporteNetoFinal.Text = _importeTotal.ToString("C2");

            if (string.IsNullOrEmpty(txtImporteIngresadoManual.Text))
                txtImporteIngresadoManual.Text = 0.ToString("c2");

            var importeManual = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteIngresadoManual.Text);
            decimal diferencia = _importeTotal - importeManual;
            txtImporteDiferencia.Text = diferencia.ToString("C2");

            if (diferencia != 0)
            {
                txtImporteDiferencia.BackColor = Color.Orange;
            }
            else
            {
                txtImporteDiferencia.BackColor = Color.DarkSeaGreen;
            }
        }

        private void txtIva27_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtImporteIngresadoManual_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtImporteIngresadoManual_Leave(object sender, EventArgs e)
        {
            SumaImportes(false, false);
        }

        private void ckMantenerInfoRecord_CheckedChanged(object sender, EventArgs e)
        {
            ckMantenerInfoRecord.BackColor = Color.Orange;
            if (ckMantenerInfoRecord.Checked)
                ckMantenerInfoRecord.BackColor = Color.LightGreen;
        }

        private void txtNumeroDocumento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show(@"Ingrese el numero de Documento de Acuerdo a la Mascara de Entrada Definida",
                @"Error en mascara/numero documento", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void txtNumeroDocumento_Leave(object sender, EventArgs e)
        {
            //
        }

        private void ActualizaItemTotal(object sender, EventArgs e)
        {
            CalculaPrecioTotalItem();
        }

        private void cmbDescripcionItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDescripcionItem.SelectedValue == null)
                return;

            var x = cmbDescripcionItem.SelectedValue.ToString();
            var r = new VendorInforRecordManager().GetInfoRecord(_vendorId, x);

            if (r == null)
                return;


            if (r.RECUERDA_PRECIO.Value)
            {
                txtPrecioU.Text = r.PRECIO_U.ToString();
            }

            cmbGlImputacionItem.Text = r.GL;
            txtGlDescripcionItem.Text = GLAccountManagement.GetGLDescriptionFromT135(r.GL);

            if (string.IsNullOrEmpty(txtCantidad.Text))
                return;

            if (string.IsNullOrEmpty(txtPrecioU.Text))
                return;

            txtPrecioT.Text =
                (Convert.ToDecimal(txtCantidad.Text) *
                 new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioU.Text)).ToString("C2");
        }

        private void cmbDescripcionItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (DateTime.Now.AddMilliseconds(-500) < _prevClick)
            {
                if (_vendorId < 1)
                {
                    MessageBox.Show(@"Para visualizar items debe primero seleccionar un proveedor", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var f2 = new FrmInfoRecordContaR(_vendorId);
                f2.ShowDialog();
            }

            _prevClick = DateTime.Now;
        }

        private void cmbGlImputacionItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (DateTime.Now.AddMilliseconds(-500) < _prevClick)
            {
                using (var f0 = new FrmCo10GLStructureTree())
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        var gl = f0.Glseleccionado;
                        cmbGlImputacionItem.SelectedItem = gl;
                        cmbGlImputacionItem.Text = gl;
                    }
                }
            }

            _prevClick = DateTime.Now;
        }

        private void txtPrecioU_TextChanged(object sender, EventArgs e)
        {
            CalculaPrecioTotalItem();
        }

        private void CalculaPrecioTotalItem()
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                txtPrecioT.Text = 0.ToString("c2");
            }

            if (string.IsNullOrEmpty(txtPrecioU.Text))
            {
                txtPrecioT.Text = 0.ToString("c2");
            }

            if (string.IsNullOrEmpty(txtCantidad.Text))
                txtCantidad.Text = @"1";

            txtPrecioT.Text =
                (new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioU.Text) *
                 Convert.ToDecimal(txtCantidad.Text)).ToString("c2");
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (ValidaAddItem() == false)
            {
                //MessageBox.Show(@"No se han dado las condiciones para agregar el item", @"Item no validado",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Exclamation);
                return;
            }
            //Una vez agregado el Primer Item Ya no Permite modificar los datos ValidacionInicial
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel5.Enabled = false;

            if (ckMantenerInfoRecord.Checked)
            {
                new VendorInforRecordManager().MantieneInforecordProveedorMaterial(_vendorId, cmbDescripcionItem.Text,
                    txtMoneda.Text, FormatAndConversions.CCurrencyADecimal(txtPrecioU.Text), cmbGlImputacionItem.Text,
                    recuerdaPrecio: true);
            }

            AddItemToLista();
            t0404VENDORFACTIBindingSource.DataSource = _lItems.ToList();
            dgvDetalleItems.DataSource = t0404VENDORFACTIBindingSource.DataSource;
            SumaImportes(ckAutoIVA21.Checked, true);
            BlanqueaItemAgregado();
        }

        private void BlanqueaItemAgregado()
        {
            txtCantidad.Text = @"1";
            cmbDescripcionItem.Text = null;
            cmbGlImputacionItem.Text = null;
            txtGlDescripcionItem.Text = null;
            txtPrecioU.Text = 0.ToString("C2");
            txtPrecioT.Text = 0.ToString("C2");
        }

        private void AddItemToLista()
        {
            var l = new T0404_VENDOR_FACT_I
            {
                CANT = Convert.ToDecimal(txtCantidad.Text),
                IDIT = _lItems.Count,
                ITEM_DESC = cmbDescripcionItem.Text,
                MONEDA = "ARS",
                PUNIT = new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioU.Text),
                PUNIT_ARS = new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioU.Text),
                PTOTAL_ARS = new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioT.Text),
                GL = cmbGlImputacionItem.Text,
            };
            _lItems.Add(l);
        }

        private bool ValidaAddItem()
        {
            if (_validacionInicial == false)
            {
                if (ValidacionPrimerItem() == false)
                {
                    return false;
                }
            }

            if (Convert.ToInt32(txtCantidad.Text) <= 0)
            {
                MessageBox.Show(@"La Cantidad/KG no puede ser menor o igual a 0", @"Error en validacion 'Step02'",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cmbDescripcionItem.Text))
            {
                MessageBox.Show(@"El item no puede ser NULO", @"Error en validacion 'Step02'",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cmbGlImputacionItem.Text))
            {
                MessageBox.Show(@"El item no tiene cuenta GL de imputacion", @"Error en validacion 'Step02'",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioU.Text) <= 0)
            {
                MessageBox.Show(@"El precio unitario no puede ser menor o igual a 0", @"Error en validacion Step02",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validacion Inicial para permitir agregar el primer Item
        /// </summary>
        private bool ValidacionPrimerItem()
        {
            _validacionInicial = false;
            ckOkAddItems.Checked = _validacionInicial;
            ckOkAddItems.BackColor = Color.Red;

            if (_vendorId <= 0)
            {
                MessageBox.Show(@"Debe seleccionar un Proveedor antes de Agregar un Item",
                    @"Datos Incompletos o Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtGlAp.Text))
            {
                MessageBox.Show(@"Error en el Proveedor - No tiene un GL-AP Asociado. Comunique de este problema a IT",
                    @"Datos Incompletos o Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (_fechaDocumento == null)
            {
                MessageBox.Show(@"Debe Completar la fecha de Documento",
                    @"Datos Incompletos o Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!_periodoOK)
            {
                MessageBox.Show(@"La Fecha del Documento es Incorrecta o el Periodo FI aun no se encuentra Abierto",
                    @"Datos Incompletos o Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbTipoDocumento.SelectedItem == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Tipo de Documento (Factura A, ...)",
                    @"Datos Incompletos o Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (_tipoLx == "L1" && _cuitValidado == false)
            {
                var x = MessageBox.Show(@"El CUIT del Proveedor parece estar incorrecto. Desea Continuar de todas formas?",
                    @"Valide la Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return false;
            }

            if (!_docuNumValidado)
            {
                MessageBox.Show(@"El Numero de Documento no es Valido",
                    @"Datos Incompletos o Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(_numeroDoc))
            {
                MessageBox.Show(@"El Numero de Documento no es Valido - Esta Vacío",
                    @"Datos Incompletos o Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (rbNormal.Checked)
            {

            }
            else
            {
                MessageBox.Show(@"Por el momento solo esta permitido IMPUTACION NORMAL EMPRESA",
                    @"Error en validacion Step01", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            //
            _validacionInicial = true;
            ckOkAddItems.Checked = true;
            ckOkAddItems.BackColor = Color.LightGreen;
            //
            return true;
        }

        private void dgvDetalleItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvDetalleItems[e.ColumnIndex, e.RowIndex].Value.ToString();
                //int numeroFormula = Convert.ToInt32(dgvFormulaList[dgvFormulaList.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "DEL":
                        {
                            var iditem = Convert.ToInt32(dgvDetalleItems[0, e.RowIndex].Value);
                            var x = _lItems.Find(c => c.IDIT == iditem);
                            if (x == null)
                                return;

                            _lItems.Remove(x);
                            SumaImportes(ckAutoIVA21.Checked, true);
                            t0404VENDORFACTIBindingSource.DataSource = _lItems.ToList();
                            dgvDetalleItems.DataSource = t0404VENDORFACTIBindingSource.DataSource;
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtBaseImponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtBaseImponible_Leave(object sender, EventArgs e)
        {
            txtBaseImponible.Text = new FormatAndConversions().SetCurrency(txtBaseImponible.Text);
        }

        private void txtTotalKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void btnNuevaContabilizacion_Click(object sender, EventArgs e)
        {
            ConfiguraInitialData();
        }

        private void btnEditProveedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdProveedor.Text))
            {
                _vendorId = 0;
            }
            else
            {
                _vendorId = Convert.ToInt32(txtIdProveedor.Text);
            }

            using (var f0 = new FrmVendorDetailData(2, _vendorId))
            {
                DialogResult dr = f0.ShowDialog();
                t0005MPROVEEDORESBindingSource.DataSource = new VendorManager().GetCompleteListVendors(false);
                cmbRazonSocial.SelectedValue = _vendorId;

                //if (dr == DialogResult.OK)
                //{
                //    cmbRazonSocial.SelectedValue = _vendorId;
                //}
                //else
                //{
                //    cmbRazonSocial.SelectedValue = _vendorId;
                //}
            }
        }

        //funciones para pago directo
        private bool ChequeaPagoDirecto()
        {
            if (string.IsNullOrEmpty(txtImporteAPagar.Text))
            {
                MessageBox.Show(@"No estan dando las condiciones para hacer el pago automatico de este item",
                    @"Pago Automatico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cmbCuentaAPagar.Text))
            {
                MessageBox.Show(
                    @"No estan dando las condiciones para hacer el pago automatico de este item.- Seleccione una cuenta",
                    @"Pago Automatico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var resp = MessageBox.Show(@"Confirma realizar el pago total con la cuenta seleccionada?",
                @"Pago Automatico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return false;
            return true;
        }

        private void btnPagoDirecto_Click(object sender, EventArgs e)
        {
            EjecutaPagoDirecto();
        }

        private void EjecutaPagoDirecto()
        {
            if (ChequeaPagoDirecto() == false)
                return;

            var importeAPagar = FormatAndConversions.CCurrencyADecimal(txtImporteAPagar.Text);
            if (importeAPagar <= 0)
            {
                MessageBox.Show(@"El importe a pagar es incorrecto!", @"importe a Pagar Incorrecto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var idFactura = Convert.ToInt32(txtId403.Text);
            var documento = new VendorInvoice("CONTAR", idFactura);
            decimal nuevoSaldoImpago = (decimal)documento.GetDocumentoHeader().SALDOIMPAGO;

            if (nuevoSaldoImpago < importeAPagar)
            {
                MessageBox.Show(
                    @"El importe a pagar no puede superar el importe Adeudado (Total) del Documento a Pagar",
                    @"Error Importe A Pagar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ctacte = new CtaCteVendor(_vendorId);

            //Genera documento PD en T0203
            if (string.IsNullOrEmpty(txtidFacturaX.Text))
                txtidFacturaX.Text = "0";
            var idCtaCtePago = ctacte.AddCtaCteDetalleRecord("PD", _tipoLx, Convert.ToDateTime(mskFechaFactura.Text),
                txtNumeroDocumento.Text, txtId403.Text, txtMoneda.Text,
                new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteAPagar.Text) * -1,
                Convert.ToDecimal(txtTc.Text), 0, idDocAlternativo: Convert.ToInt32(txtidFacturaX.Text),
                idDocumentoPrincipal: Convert.ToInt32(txtId403.Text));


            var resultadoAsiento =
                new AsientoVendorDocument(Convert.ToInt32(txtId403.Text), "CONTAR").GeneraAsientoPagoAutomaticoContar(
                    Convert.ToInt32(txtNAS.Text), cmbCuentaAPagar.SelectedValue.ToString());
            if (resultadoAsiento.IdDocu == 0)
            {
                ckContabilizacinPagoOK.BackColor = Color.Orange;
                ckContabilizacinPagoOK.Checked = false;
                txtnumeroAsientoPago.Text = @"Error";
                MessageBox.Show(@"Ha ocurrido un error al procesar el asiento de Pago", @"Asiento de Pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtnumeroAsientoPago.Text = resultadoAsiento.IdDocu.ToString();
            documento.UpdateSaldoImpagoT0403(nuevoSaldoImpago - importeAPagar);

            //new VendorContabilizacionDocumentManager().UpdateSaldoImpagoT0403(Convert.ToInt32(txtId403.Text), 0);
            new ManageVendorImputacionDocumentos().GeneraMovimientoImputacion(Convert.ToInt32(txtidCtaCte.Text),
                idCtaCtePago,
                txtGLCuentaAPagar.Text, "CONTAR", resultadoAsiento.IdDocu);

            ctacte.UpdateImporteSaldoFactura(Convert.ToInt32(txtidCtaCte.Text), 0);
            ctacte.UpdateSaldoCtaCteResumen(_tipoLx,
                new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteAPagar.Text) * -1);

            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoDetalle.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoDetalle.ToString("C2");
            txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;


            new RegisterManager().AddRegisterRecord(cmbCuentaAPagar.SelectedValue.ToString(),
                Convert.ToDateTime(mskFechaFactura.Text), "PD", txtNumeroDocumento.Text, TipoEntidad.Proveedor, _vendorId,
                "Pago Directo Realizado", txtMoneda.Text, 0,
                new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteAPagar.Text), 0, _tipoLx,
                txtGLCuentaAPagar.Text, Convert.ToInt32(txtnumeroAsientoPago.Text), "CONTAR", true);

            btnPagoDirecto.Enabled = false;
            ckContabilizacinPagoOK.Checked = true;
            ckContabilizacinPagoOK.BackColor = Color.LightGreen;
            MessageBox.Show(@"Se ha realizado el Pago Completo en forma correcta", @"Pago Completo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            cmbCuentaAPagar.SelectedIndex = -1;
            txtCuentaApagarDescripcion.Text = null;
            txtImporteAPagar.Text = 0.ToString("C2");
            txtGLCuentaAPagar.Text = null;
        }

        private void cmbFantasia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbFantasia.SelectedValue == null)
            {
                return;
            }
            else
            {
                cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
                //cmbNumeroCuit.SelectedValue = cmbFantasia.SelectedValue;
                //txtIdProveedor.Text = cmbFantasia.SelectedValue.ToString();
            }
        }

        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedValue == null)
                return;

            var idProveedor = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            var vendorData =
                new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.SingleOrDefault(c => c.id_prov == idProveedor);
            if (vendorData == null) throw new ArgumentNullException(nameof(vendorData));

            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
            mskCuit.Text = vendorData.NTAX1;

            if (new CuitValidation().ValidarCuit(vendorData.NTAX1))
            {
                txtCuitValido.BackColor = Color.GreenYellow;
                _cuitValidado = true;
            }
            else
            {
                txtCuitValido.BackColor = Color.Red;
                _cuitValidado = false;
            }

            txtIdProveedor.Text = cmbRazonSocial.SelectedValue.ToString();
            txtTipoProveedor.Text = vendorData.TIPO;
            UpdateDataWhenVendorIsChanged(Convert.ToInt32(cmbRazonSocial.SelectedValue));
        }

        private void mskCuit_Leave(object sender, EventArgs e)
        {
            if (new CuitValidation().ValidarCuit(mskCuit.Text))
            {
                txtCuitValido.BackColor = Color.GreenYellow;
                _cuitValidado = true;

                var idVendor = new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Where(c => c.NTAX1 == mskCuit.Text)
                    .ToList();
                if (idVendor.Count == 1)
                {
                    var idv = idVendor[0].id_prov;
                    cmbRazonSocial.Text = idVendor[0].prov_rsocial;
                    cmbFantasia.Text = idVendor[0].prov_fantasia;
                    txtIdProveedor.Text = idv.ToString();
                }
                else
                {
                    if (idVendor.Count > 1)
                    {
                        MessageBox.Show(@"Existe mas de un Proveedor con el mismo numero de CUIT.",
                            @"Error en Numero de CUIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(@"NO EXISTE NINGUN PROVEEDOR CON EL CUIT SELECCIONADO",
                            @"Error en Numero de CUIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                txtCuitValido.BackColor = Color.Red;
                _cuitValidado = false;
            }
        }

        private void mskCuit_Enter(object sender, EventArgs e)
        {
            _cuitValidado = false;
            txtCuitValido.BackColor = Color.Red;
        }

        private void txtNumeroDocumento_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (_validarDocumentoNumeroMaskCompleted && !txtNumeroDocumento.MaskCompleted)
            {
                e.Cancel = true;
                toolTip1.ToolTipTitle = "El Tipo de Documento requiere que la mascara de entrada este completa y validada de acuerdo al formato presentado";
                toolTip1.Show("Complete los datos del Documento en forma correcta",
                    txtNumeroDocumento,
                    txtNumeroDocumento.Location, 5000);
                _numeroDoc = null;
                return;

            }

            if (ckValidarNumeroDocumento.Checked)
            {
                if (new ValidacionVendorDocument().CheckIfDocumentAlreadyExist(_vendorId, txtNumeroDocumento.Text,
                    _tipoLx, txtTipoDocumento.Text))
                {
                    ckNumeroDocumentoOK.Checked = false;
                    ckNumeroDocumentoOK.BackColor = Color.Orange;
                    MessageBox.Show(
                        @"El numero de documento ingresado ya existe para este proveedor (Factura Duplicada)",
                        @"Factura ingresada duplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    _docuNumValidado = false;
                    txtDocuNumOk.BackColor = Color.Red;
                    txtDocuNumOk.Text = @"!";
                    _numeroDoc = null;
                }
                else
                {
                    ckNumeroDocumentoOK.Checked = true;
                    ckNumeroDocumentoOK.BackColor = Color.LightGreen;
                    _docuNumValidado = true;
                    txtDocuNumOk.BackColor = Color.GreenYellow;
                    txtDocuNumOk.Text = @"OK";
                    _numeroDoc = txtNumeroDocumento.Text;
                }
            }
            else
            {
                if (new ValidacionVendorDocument().CheckIfDocumentAlreadyExist(_vendorId, txtNumeroDocumento.Text,
                    _tipoLx, txtTipoDocumento.Text))
                {
                    ckNumeroDocumentoOK.Checked = false;
                    ckNumeroDocumentoOK.BackColor = Color.Orange;
                    MessageBox.Show(
                        @"El numero de documento ingresado ya existe para este proveedor (Factura Duplicada) pero ha seleccionado Ignorar este Error!",
                        @"Factura ingresada duplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _docuNumValidado = true;
                    txtDocuNumOk.Text = "??";
                    txtDocuNumOk.BackColor = Color.Yellow;
                    _numeroDoc = txtNumeroDocumento.Text;
                }
                else
                {
                    _docuNumValidado = true;
                    txtDocuNumOk.BackColor = Color.GreenYellow;
                    txtDocuNumOk.Text = @"OK";
                    _numeroDoc = txtNumeroDocumento.Text;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show(@"Confirma Salir de la transaccion?", @"Salir", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
                this.Close();
        }

        private void mskFechaFactura_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtFechaValidada.BackColor = Color.OrangeRed;
            _fechaDocumento = null;
            ckPeriodoOK.Checked = false;
            txtPeriodoFI.Text = null;
            txtPeriodoFI.BackColor = Color.Yellow;
            _periodoOK = false;
            toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
            toolTip1.Show("Los datos ingresados no son correctos!(verifique haber ingresado una fecha DD/MM/AAAA",
                mskFechaFactura,
                mskFechaFactura.Location, 5000);
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
                txtFechaValidada.Text = @"OK";
                _fechaDocumento = dt;
            }
            else
            {
                //invalid date
                toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
                toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA",
                    mskFechaFactura,
                    mskFechaFactura.Location, 5000);

                txtFechaValidada.BackColor = Color.OrangeRed;
                txtFechaValidada.Text = @"!";
                _fechaDocumento = null;
            }
        }

        private void mskFechaFactura_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mskFechaFactura.MaskCompleted && _fechaDocumento != null)
            {
                ValidaPeriodoOpen();
                if (_periodoOK)
                {
                    txtTc.Text = new ExchangeRateManager().GetExchangeRate(Convert.ToDateTime(mskFechaFactura.Text))
                        .ToString("n2");
                }

            }
        }

        private void ValidaPeriodoOpen()
        {
            var pOpen = new PeriodoAvailability().CheckPeriodoOpenFI(_fechaDocumento.Value);
            if (!pOpen)
            {
                MessageBox.Show(
                    @"Atencion el Periodo Contable FI no se encuentra abierto y no se puede contabilizar esta factura en la fecha ingresada",
                    @"Periodo FI Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _periodoOK = false;
                ckPeriodoOK.Checked = false;
                txtPeriodoFI.Text = @"Closed";
                txtPeriodoFI.BackColor = Color.Red;
            }
            else
            {
                _periodoOK = true;
                ckPeriodoOK.Checked = true;
                txtPeriodoFI.Text = @"Open!";
                txtPeriodoFI.BackColor = Color.LimeGreen;
            }
        }

        private void rbL1_CheckedChanged(object sender, EventArgs e)
        {
            cmbTipoDocumento.Items.Clear();
            if (rbL1.Checked)
            {
                _tipoLx = @"L1";
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "Factura A", Value = ComboboxTipoDocumento.VendorDocumentType.FPA });
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "Factura B", Value = ComboboxTipoDocumento.VendorDocumentType.FPB });
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "Factura C", Value = ComboboxTipoDocumento.VendorDocumentType.FPC });
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "Nota Credito A", Value = ComboboxTipoDocumento.VendorDocumentType.NCA });
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "Nota Debito A", Value = ComboboxTipoDocumento.VendorDocumentType.NDA });
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "Recibo C", Value = ComboboxTipoDocumento.VendorDocumentType.RPC });
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "VEP", Value = ComboboxTipoDocumento.VendorDocumentType.VEP });
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "Impuestos", Value = ComboboxTipoDocumento.VendorDocumentType.IMP });
            }
            else
            {
                _tipoLx = @"L2";
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "Ticket", Value = ComboboxTipoDocumento.VendorDocumentType.TKT });
                cmbTipoDocumento.Items.Add(new ComboboxTipoDocumento
                { Text = "Sin Comprobante", Value = ComboboxTipoDocumento.VendorDocumentType.NON });
            }

            cmbTipoDocumento.SelectedIndex = 0;
        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoDocumento.SelectedIndex < 0)
            {
                txtTipoDocumento.Text = null;
                txtNumeroDocumento.Text = null;
                _validarDocumentoNumeroMaskCompleted = true;
                return;
            }

            _validarDocumentoNumeroMaskCompleted = true;
            ckAutoIVA21.Checked = false;
            ckAutoIVA21.ForeColor = Color.Red;
            txtNumeroDocumento.ReadOnly = false;
            var tdoc = (cmbTipoDocumento.SelectedItem as ComboboxTipoDocumento).ValueZ();
            txtTipoDocumento.Text = tdoc.ToString();
            _signoConta = 1;
            switch (tdoc)
            {
                case ComboboxTipoDocumento.VendorDocumentType.FPA:
                    ckAutoIVA21.Checked = true;
                    ckAutoIVA21.ForeColor = Color.Green;
                    ckValidarNumeroDocumento.Checked = true;
                    txtNumeroDocumento.Mask = @"0000-00000000";
                    break;
                case ComboboxTipoDocumento.VendorDocumentType.FPB:
                    ckAutoIVA21.Checked = true;
                    ckAutoIVA21.ForeColor = Color.Green;
                    ckValidarNumeroDocumento.Checked = true;
                    txtNumeroDocumento.Mask = @"0000-00000000";
                    break;
                case ComboboxTipoDocumento.VendorDocumentType.FPC:
                    ckAutoIVA21.Checked = true;
                    ckAutoIVA21.ForeColor = Color.Green;
                    ckValidarNumeroDocumento.Checked = true;
                    txtNumeroDocumento.Mask = @"0000-00000000";
                    break;
                case ComboboxTipoDocumento.VendorDocumentType.RPC:
                    ckAutoIVA21.Checked = true;
                    ckAutoIVA21.ForeColor = Color.Green;
                    ckValidarNumeroDocumento.Checked = true;
                    txtNumeroDocumento.Mask = @"0000-00000000";
                    break;
                case ComboboxTipoDocumento.VendorDocumentType.NCA:
                    ckAutoIVA21.Checked = true;
                    ckAutoIVA21.ForeColor = Color.Green;
                    ckValidarNumeroDocumento.Checked = true;
                    txtNumeroDocumento.Mask = @"0000-00000000";
                    _signoConta = -1;
                    break;
                case ComboboxTipoDocumento.VendorDocumentType.NDA:
                    ckAutoIVA21.Checked = true;
                    ckAutoIVA21.ForeColor = Color.Green;
                    ckValidarNumeroDocumento.Checked = true;
                    txtNumeroDocumento.Mask = @"0000-00000000";
                    MessageBox.Show(@"NO Utilizar esta Opcion para Cheques Rechazados de Proveedores", @"ATENCION",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case ComboboxTipoDocumento.VendorDocumentType.VEP:
                    ckValidarNumeroDocumento.Checked = true;
                    txtNumeroDocumento.Mask = @"00000000000000000";
                    _validarDocumentoNumeroMaskCompleted = false;
                    break;
                case ComboboxTipoDocumento.VendorDocumentType.IMP:
                    ckValidarNumeroDocumento.Checked = false;
                    txtNumeroDocumento.Mask = @"0000000000";
                    _validarDocumentoNumeroMaskCompleted = false;
                    break;
                case ComboboxTipoDocumento.VendorDocumentType.TKT:
                    ckValidarNumeroDocumento.Checked = true;
                    txtNumeroDocumento.Mask = @"00000000000000000";
                    _validarDocumentoNumeroMaskCompleted = false;
                    break;
                case ComboboxTipoDocumento.VendorDocumentType.NON:
                    _validarDocumentoNumeroMaskCompleted = false;
                    ckValidarNumeroDocumento.Checked = false;
                    txtNumeroDocumento.Mask = @"0000-00000000";
                    txtNumeroDocumento.Text = @"0000-" + DateTime.Today.Year.ToString() +
                                              DateTime.Today.Month.ToString("D2") +
                                              DateTime.Today.Day.ToString("D2");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void mskFechaFactura_DoubleClick(object sender, EventArgs e)
        {
            mskFechaFactura.Text = completaFechaMask(DateTime.Today);
            _fechaDocumento = DateTime.Today;
            ValidaPeriodoOpen();
        }

        private void txtAlicPercIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtAlicPercIva_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = 0.ToString("P3");

            decimal valor = FormatAndConversions.CPorcentajeADecimal(txt.Text);
            txt.Text = valor.ToString("P3");
        }

        private void txtRedondeo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void ckSoloGLCompras_CheckedChanged(object sender, EventArgs e)
        {
            t0135GLXBindingSource.DataSource = ckSoloGLCompras.Checked
                ? new GLAccountManagement().GetListGLImputacionCompras()
                : new GLAccountManagement().GetGLListPermiteImputacion();
            cmbGlImputacionItem.SelectedIndex = -1;
            txtGlDescripcionItem.Text = null;
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Intente nuevamente en una versión nueva", @"Funcionalidad en Proceso...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnContaOperacion_Click(object sender, EventArgs e)
        {
            if (ValidaAntesContabilizacion() == false)
                return;

            var msg = MessageBox.Show($@"Confirma contabilizacion por importe {txtImporteNetoFinal.Text} ?",
                @"Confirmacion de Operacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
                return;

            Cursor.Current = Cursors.WaitCursor;

            if (ContabilizacionContar())
            {
                btnContaOperacion.Enabled = false;
                btnNuevaContabilizacion.Enabled = true;
                btnPagoDirecto.Enabled = false;
                if (_signoConta == 1)
                    btnPagoDirecto.Enabled = true;
                btnAddItem.Enabled = false;
                if (_modo == 1)
                {
                    //modo conversion-rendicion
                    EjecutaPagoDirecto();
                    new RendicionFF().UpdateRendicionAfterConversion(_idRendicion, Environment.UserName,
                        Convert.ToInt32(txtidCtaCte.Text), Convert.ToInt32(txtId403.Text),
                        Convert.ToInt32(txtNAS.Text));
                }
                else
                {
                    //modo normal contar
                    txtImporteAPagar.Text = txtImporteNetoFinal.Text;
                    CuentasBs.DataSource = new CuentasManager().GetListaCuentasAvailableForContar(txtMoneda.Text);
                    cmbCuentaAPagar.DataSource = CuentasBs;
                    txtImporteAPagar.Text = txtImporteNetoFinal.Text;
                    cmbCuentaAPagar.SelectedIndex = -1;
                }
            }
            else
            {
            }
            Cursor.Current = Cursors.Default;
        }

        private void txtDescuento_Validated(object sender, EventArgs e)
        {
            //validar porcentaje de descuento
        }

        private void txtBaseImponible_TextChanged(object sender, EventArgs e)
        {
            //chequea que sea un valor >0 y menor a subtotal porque los impuestsos son ingresados a mano
            //si validacion OK

            //MessageBox.Show(@"El Sistema no Recalcula IVA y Perecpeciones de acuerdo a la base imponible",
            //   @"ATENCION: Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        }

        private void MonedaValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = @"0";
            decimal valor = FormatAndConversions.CCurrencyADecimal(txt.Text);
            txt.Text = valor.ToString("C2");
        }

        private void txtImpuInternos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtRedondeoVarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, true, true);
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

        private void PorcentajeValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = @"0";
            decimal valor = Convert.ToDecimal(txt.Text);
            txt.Text = valor.ToString("P3");
        }

        private void DecimalValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = @"0";
            decimal valor = Convert.ToDecimal(txt.Text);
            txt.Text = valor.ToString("N2");
        }
    }
}
