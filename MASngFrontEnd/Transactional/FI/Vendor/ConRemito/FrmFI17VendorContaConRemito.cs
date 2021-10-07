using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI.ContabilizacionProveedores;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Vendor.ConRemito
{
    //FI07 - Contabilizacion de Facturas Proveedores con REMITO
    //TCODE: CONTA1
    //
    public partial class FrmFI17VendorContaConRemito : Form
    {
        public FrmFI17VendorContaConRemito(int modo = 0)
        {
            _modo = modo;
            InitializeComponent();
        }

        //Variables
        //-------------------------------------------------------------------------------------------------------------
        private List<T0005_MPROVEEDORES> _masterList = new List<T0005_MPROVEEDORES>();
        public int? IdVendor { get; private set; }
        public decimal ImporteContabilizar { get; private set; }
        public decimal TipoCampio { get; private set; }
        public string MonedaFactura { get; private set; }
        public int IdItem { get; set; }
        private int _modo;
        public readonly List<ItemFactura> Items = new List<ItemFactura>();
        public T0403_VENDOR_FACT_H HeaderData;
        private DateTime? _fechaDocumento = null;
        private bool _cuitValidado;
        private string _numeroDoc;
        private string _tipoDocumento;
        private string _tipoLx;
        private bool _periodoOK = false;
        private bool _docuNumValidado = false;
        private bool _validarDocumentoNumeroMaskCompleted = true;
        private Color _colorValidacionOk = Color.LightGreen;
        private Color _colorValidacionFail = Color.IndianRed;
        private bool _validacionInicial = false;
        //-------------------------------------------------------------------------------------------------------------


        //-------------------------    Funcionalidad de Combos ------------------------------------

        #region Funcionalidad de Combos

        ///**Funcionalidad validacion / CUIT
        private void txtNumeroTax_KeyUp(object sender, KeyEventArgs e)
        {
            //cuando es tipo 80 y 11 caracteres lo valida
            if (txtNumeroTax.Text.Length == 11 && txtCodigoTax.Text == @"80")
            {
                ValidaCuitCorrecto();
            }
        }

        private void txtNumeroTax_TextChanged(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }

        private void txtNumeroTax_Leave(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }

        private void txtCodigoTax_TextChanged(object sender, EventArgs e)
        {
            cmbTipoTax.Text = txtCodigoTax.Text == @"80" ? @"CUIT" : @"NI";
        }

        private void txtCodigoTax_Leave(object sender, EventArgs e)
        {
        }

        private void cmbTipoTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoTax.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                if (cmbTipoTax.Text == @"CUIT")
                {
                    txtCodigoTax.Text = @"80";
                    txtNumeroTax.BackColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    txtCodigoTax.Text = @"00";
                    txtNumeroTax.BackColor = Color.DarkGray;
                    txtNumeroTax.Text = @"00000000000";
                }
            }
        }

        private void cmbRazonSocial_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
            }
        }

        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                //BlanqueaSeleccion();
                IdVendor = null;
                return;
            }

            IdVendor = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            txtGLAp.Text = new GLAccountManagement().GetApVendorGl(IdVendor.Value);
            ValidaCuitCorrecto();

            var ctacte = new CtaCteVendor(IdVendor.Value);
            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;
            txtSaldoTotal.Text =
                (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text)).ToString("C2");
        }

        private void ValidaCuitCorrecto()
        {
            if (txtNumeroTax.Text.Length == 11 && txtNumeroTax.Text != @"00000000000")
            {
                if (new CuitValidation().ValidarCuit(txtNumeroTax.Text) == true)
                {
                    txtTaxValido.Text = @"VALIDO";
                    txtTaxValido.BackColor = Color.LightGreen;
                    _cuitValidado = true;
                }
                else
                {
                    txtTaxValido.Text = @"INVALIDO";
                    txtTaxValido.BackColor = Color.Crimson;
                    _cuitValidado = false;
                }
            }
            else
            {
                txtTaxValido.Text = @"SIN VALIDAR";
                txtTaxValido.BackColor = Color.Orange;
            }

            //  }
        }

        private void BlanqueaSeleccion()
        {
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTipoTax.SelectedIndex = -1;
            cmbIdProveedor.SelectedIndex = -1;
            txtNumeroTax.Text = null;
            txtCodigoTax.Text = null;
            IdVendor = null;
        }

        /// <summary>
        /// Blanqueo de seleccion - asigando a todos los Combobox!
        /// </summary>

        //Fin Funcionalidad Combobox!

        #endregion

        private void FrmContabilizacionProveedorConRemito_Load(object sender, EventArgs e)
        {
            _masterList = new VendorManager().GetListVendorPendienteContabilizacionRemito().ToList();
            t0005MPROVEEDORESBindingSource.DataSource = _masterList;
            this.txtTipoCambio.TextChanged -= new System.EventHandler(this.txtTipoCambio_TextChanged);
            itemFacturaBindingSource.DataSource = Items;
            TipoCampio = 0;
            txtTipoCambio.Text = TipoCampio.ToString("n4");
            MonedaFactura = "ARS";
            cmbMonedaFactura.Text = @"ARS";
            ImporteContabilizar = 0;
            BlanqueaSeleccion();
            this.txtTipoCambio.TextChanged += new System.EventHandler(this.txtTipoCambio_TextChanged);
            _validacionInicial = false;
        }

        public void RefrescaDgv()
        {
            itemFacturaBindingSource.DataSource = Items.ToList();
            dgvItemsRemito.DataSource = itemFacturaBindingSource;
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            var fx = new FrmBusquedaAvanzadaProveedor();
            fx.ShowDialog();
        }

        private bool ValidaAddItem()
        {
            _validacionInicial = false;
            if (IdVendor == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Proveedor para poder continuar", @"Datos Faltantes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtGLAp.Text))
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


            if (rbL1.Checked == false && rbL2.Checked == false)
            {
                MessageBox.Show(@"Debe Seleccionar si Documento es L1 o L2", @"Datos Faltantes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (rbL1.Checked)
            {
                if (rbFA.Checked == false && rbFB.Checked == false && rbFC.Checked == false)
                {
                    MessageBox.Show(@"Debe Seleccionar el Tipo de Documento", @"Datos Faltantes",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                if (rbF2.Checked == false)
                {
                    MessageBox.Show(@"Debe Seleccionar el Tipo de Documento", @"Datos Faltantes",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
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

            if (TipoCampio <= 0)
            {
                MessageBox.Show(
                    @"Debe Seleccionar el tipo de cambio correcto (de acuerdo a la factura) ya que es neceario para calcular el precio unitario en USD del material a contabilizar",
                    @"Datos Faltantes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (ImporteContabilizar <= 0)
            {
                MessageBox.Show(
                    @"Debe Completar el Importe de la Factura a Contabilizar antes de Continuar (Validacion)",
                    @"Datos Faltantes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _validacionInicial = true;
            return true;

        }
        private void btnAddItemsRemito_Click(object sender, EventArgs e)
        {

            if (ValidaAddItem() == false)
            {
                return;
            }

            //Una vez agregado el Primer Item Ya no Permite modificar los datos ValidacionInicial
            panel1.Enabled = false;
            panel3.Enabled = false;

            if (Items.Count == 0)
            {
                //inicializa
                HeaderData = new T0403_VENDOR_FACT_H
                {
                    TIPO = rbL1.Checked ? "L1" : "L2",
                    IDPROV = IdVendor.Value,
                    FECHA = _fechaDocumento.Value,
                    NFACTURA = _numeroDoc,
                    GLAP = txtGLAp.Text,
                    MON = MonedaFactura,
                    PROVRS = cmbIdProveedor.Text,
                    PRTAX1 = txtNumeroTax.Text,
                    TC = TipoCampio,
                    TFACTURA = "A"
                };
            }

            using (var f0 = new FrmFI21AddItemToFactura(this, -1))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (Items.Count > 0)
                    {
                        panel1.Enabled = false;
                        grpTipo.Enabled = false;
                        txtImporteNetoFacturaARS.ReadOnly = true;
                    }
                    else
                    {
                        panel1.Enabled = true;
                        grpTipo.Enabled = true;
                        txtImporteNetoFacturaARS.ReadOnly = true;
                    }
                }
            }


        }
        private void btnContabilizar_Click(object sender, EventArgs e)
        {
            if (ValidaAntesContabilizacion() == false)
                return;

            if (ValidacionContabilizar() == false)
                return;

            var resp = MessageBox.Show(
                $"Confirma la contabilizacion del documento por un importe total de {ImporteContabilizar.ToString("C2")}?",
                @"Contabilizacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;
            ManageContabilizacionCompleta();
            btnContabilizar.Enabled = false;

        }






        private void txtTipoCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void rbL1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbL1.Checked)
            {
                grpL2.Visible = false;
                grpL1.Visible = true;

                txtNumeroDocumento.Mask = @"0000-00000000";
                _tipoLx = "L1";
            }
            else
            {
                // grpL1.Visible = false;
                grpL2.Visible = true;
                txtNumeroDocumento.Mask = null;
                _tipoLx = "L2";
                grpL2.BringToFront();
                panel3.SendToBack();
                grpL1.SendToBack();
                grpL2.BringToFront();
            }
        }

        private void rbF2_CheckedChanged(object sender, EventArgs e)
        {
            _tipoDocumento = "FP2";
            txtTipoDocumento.Text = _tipoDocumento;
        }

        private void rbFA_CheckedChanged(object sender, EventArgs e)
        {
            _tipoDocumento = "FPA";
            txtTipoDocumento.Text = _tipoDocumento;
        }

        private void rbFB_CheckedChanged(object sender, EventArgs e)
        {
            _tipoDocumento = "FPB";
            txtTipoDocumento.Text = _tipoDocumento;
        }

        private void rbFC_CheckedChanged(object sender, EventArgs e)
        {
            _tipoDocumento = "FPC";
            txtTipoDocumento.Text = _tipoDocumento;
        }


        private bool ValidaAntesContabilizacion()
        {
            if (Items.Count == 0)
            {
                MessageBox.Show(@"Debe agregar al menos 1 (UN item) para contabilizar!", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (ImporteContabilizar <= 0)
            {
                MessageBox.Show(@"El Importe de la Factura es Incorrecto",
                    @"Error en Importe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (FormatAndConversions.CCurrencyADecimal(txtImporteNetoFinal.Text) != ImporteContabilizar)
            {
                MessageBox.Show(@"El Importe de la Factura no coincide con los Saldos Calculados/Ingresados",
                    @"Diferencia de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (IdVendor == null || IdVendor <= 0)
            {
                MessageBox.Show(@"El Proveedor seleccionado es INVALIDO o INEXISTENTE",
                    @"Error en Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtGLAp.Text))
            {
                MessageBox.Show(@"El Proveedor seleccionado NO POSEE un GL AP",
                    @"Error en Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }







            var gl = true;
            foreach (var i in Items)
            {
                if (string.IsNullOrEmpty(i.GL))
                {
                    gl = false;
                }
            }

            if (gl == false)
            {
                MessageBox.Show(@"Existen ITEMS a contabilizar sin su CORRESPONDIENTE GL Account",
                    @"Error en Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;


        }


        private bool ValidacionContabilizar()
        {
            if (Items.Count == 0)
            {
                MessageBox.Show(@"Debe Agregar CostItems a la Factura parar poder Contabilizar!",
                    @"Factura SIN CostItems",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (FormatAndConversions.CCurrencyADecimal(txtImporteNetoFinal.Text) != ImporteContabilizar)
            {
                MessageBox.Show(@"El Importe de la Factura no coincide con los Saldos Calculados/Ingresados",
                    @"Diferencia de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (IdVendor == null || IdVendor <= 0)
            {
                MessageBox.Show(@"El Proveedor seleccionado es INVALIDO o INEXISTENTE",
                    @"Error en Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtGLAp.Text))
            {
                MessageBox.Show(@"El Proveedor seleccionado NO POSEE un GL AP",
                    @"Error en Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            var gl = true;
            foreach (var i in Items)
            {
                if (string.IsNullOrEmpty(i.GL))
                {
                    gl = false;
                }
            }

            if (gl == false)
            {
                MessageBox.Show(@"Existen ITEMS a contabilizar sin su CORRESPONDIENTE GL Account",
                    @"Error en Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private T0203_CTACTE_PROV MapFormDataToCtaCte203Structure()
        {
            var docu = new T0203_CTACTE_PROV()
            {
                IDCTACTE = 0,
                TDOC = _tipoDocumento,
                NUMDOC = txtNumeroDocumento.Text,
                DOC_INTERNO = null,
                Fecha = _fechaDocumento,
                ZTERM = new VendorManager().GetZterm(IdVendor.Value, _tipoLx),
                IDPROV = IdVendor.Value,
                MONEDA = cmbMonedaFactura.SelectedItem.ToString(),
                TC = TipoCampio,
                ZOP = false,
                TIPO = _tipoLx,
                IdFacturaX = 0,
                LogDate = DateTime.Now,
                LogUsuario = GlobalApp.AppUsername,
            };
            if (cmbMonedaFactura.SelectedItem.ToString() == @"ARS")
            {
                //importe ORI =ARS
                docu.IMPORTE_ORI = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteNetoFinal.Text);
                docu.IMPORTE_ARS = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteNetoFinal.Text);
            }
            else
            {
                //importe ORI =USD
                docu.IMPORTE_ORI = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteNetoFinal.Text);
                docu.IMPORTE_ARS =
                    decimal.Round(
                        (new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteNetoFinal.Text) * TipoCampio),
                        2);
            }

            docu.SALDOFACTURA = docu.IMPORTE_ARS;
            return docu;
        }

        private T0403_VENDOR_FACT_H Map403H()
        {
            var h = new T0403_VENDOR_FACT_H
            {
                FECHA = _fechaDocumento.Value,
                IDPROV = IdVendor.Value,
                IDINT = 0,
                TC = TipoCampio,
                BRUTO = FormatAndConversions.CCurrencyADecimal(txtImporteBruto.Text),
                DTO = FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text),
                SUBTOTAL = FormatAndConversions.CCurrencyADecimal(txtSubtotal.Text),
                BaseImponible = FormatAndConversions.CCurrencyADecimal(txtBaseImponible.Text),
                IVA10 = FormatAndConversions.CCurrencyADecimal(txtIva10.Text),
                IVA21 = FormatAndConversions.CCurrencyADecimal(txtIva21.Text),
                IVA27 = FormatAndConversions.CCurrencyADecimal(txtIva27.Text),
                TOTALIVA = FormatAndConversions.CCurrencyADecimal(txtTotalIva.Text),
                PerIVA = FormatAndConversions.CCurrencyADecimal(txtPercIva.Text),
                PerIVA_Alicuota = FormatAndConversions.CPorcentajeADecimal(txtAlicIva.Text),
                PerIIBB = FormatAndConversions.CCurrencyADecimal(txtPercIIBB.Text),
                PerIIBB_Alicuota = FormatAndConversions.CPorcentajeADecimal(txtAlicIIBB.Text),
                PerIIBB_TXT = txtDistritoIIBB.Text,
                PerGS = FormatAndConversions.CCurrencyADecimal(txtPercGs.Text),
                PerGA_Alicuota = FormatAndConversions.CPorcentajeADecimal(txtAlicIIBB.Text),
                ImpuestoMunicipal = FormatAndConversions.CCurrencyADecimal(txtImpuMunicipal.Text),
                ImpuestoProvincial = FormatAndConversions.CCurrencyADecimal(txtImpuProvincial.Text),
                IMPINT = FormatAndConversions.CCurrencyADecimal(txtImpuInternos.Text),
                IMPOTR = FormatAndConversions.CCurrencyADecimal(txtImpuOtros.Text),
                ConceptosNoGravados = FormatAndConversions.CCurrencyADecimal(txtConcpetoNoGravado.Text),
                TotalImpuestosVarios = FormatAndConversions.CCurrencyADecimal(txtTotalOtroImpuestos.Text),
                NETO = FormatAndConversions.CCurrencyADecimal(txtImporteNetoFinal.Text),
                TCODE = "CONTA1",
                GLAP = txtGLAp.Text,
                CANTKG = Convert.ToDecimal(txtKgTotalFacturados.Text),
                OBSERVACION = txtObservaciones.Text,
                SALDOIMPAGO = FormatAndConversions.CCurrencyADecimal(txtImporteNetoFinal.Text),
                MON = cmbMonedaFactura.SelectedItem.ToString(),
                TFACTURA = _tipoDocumento,
                NFACTURA = txtNumeroDocumento.Text,
                TIPO = _tipoLx,
                IMPORI = FormatAndConversions.CCurrencyADecimal(txtImporteNetoFinal.Text),
                StatusDocumento = @"A Validar",
                RedondeoFinal = FormatAndConversions.CCurrencyADecimal(txtRedondeoVarios.Text),
            };
            return h;
        }

        private void ManageContabilizacionCompleta()
        {
            //1 Add Factura 203 + Update deuda 204
            // Retorono IDCTACTE + Saldos Actualizados
            var ctacte = new CtaCteVendor(IdVendor.Value);
            var data = MapFormDataToCtaCte203Structure();
            var idCtaCte = ctacte.AddCtaCteDetalleRecord(data.TDOC, _tipoLx, data.Fecha.Value, data.NUMDOC,
                data.DOC_INTERNO,
                data.MONEDA, data.IMPORTE_ORI.Value, data.TC.Value, data.SALDOFACTURA.Value, data.IMPORTE_ARS.Value,
                data.IdFacturaX.Value, data.IdFacturaX.Value);

            if (idCtaCte > 0)
            {
                txtIdCtaCte.Text = idCtaCte.ToString();
                ctacte.UpdateSaldoCtaCteResumen(_tipoLx, data.IMPORTE_ORI.Value, data.MONEDA, data.TC);
            }
            else
            {
                txtIdCtaCte.Text = @"Error";
            }

            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;

            //2. Add Record [403 + 404]
            var vendorInvoice = new VendorInvoice((int)IdVendor, "CONTAR1");

            var data403 = Map403H();
            vendorInvoice.CreateNewHeaderInMemory(data403.TIPO, data403.FECHA, data403.MON, data403.TFACTURA,
                data403.NFACTURA, data403.IMPORI, data403.TC, data403.BRUTO, data403.DTO,
                data403.SUBTOTAL,
                data403.BaseImponible, data403.IVA10, data403.IVA21, data403.IVA27,
                data403.IMPINT, data403.IMPOTR, data403.PerIVA, data403.PerIVA_Alicuota.Value,
                data403.PerIIBB, data403.PerIIBB_Alicuota.Value, data403.PerIIBB_TXT,
                data403.ImpuestoMunicipal,
                data403.ImpuestoProvincial, data403.ConceptosNoGravados, data403.NETO, data403.GLAP,
                data403.OBSERVACION, data403.CANTKG.Value, data403.PerGS, data403.PerGA_Alicuota, data403.RedondeoFinal,
                data403.StatusDocumento);

            foreach (var ix in Items)
            {
                vendorInvoice.AddItemInMemory(ix.CantidadFacturar, ix.Material, MonedaFactura, ix.PrecioU_MonFact,
                    data403.TC, ix.GL);

                //Manejo de Costo Reposicion - UC
                if (ix.UpdatePrecioUc)
                {
                    var costoRepo = new ACostoRepo(ix.Material, ix.TC);
                    costoRepo.SaveCost(IdVendor.Value, ix.CantidadFacturar, Monedas.GetMonedaType(ix.MonedaPrecioUc), ix.PrecioUnitarioUc, _fechaDocumento.Value);
                }
                else
                {
                    MessageBox.Show(@"No se ha actualizado el costo unitario debido a su seleccion",
                        @"info sobre Costos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                decimal unitCostUSD = 0;
                decimal unitCostARS = 0;
                if (MonedaFactura == "ARS")
                {
                    unitCostARS = ix.PrecioU_MonFact;
                    unitCostUSD = decimal.Round(ix.PrecioU_USD, 3);
                }
                else
                {
                    unitCostARS = decimal.Round((ix.PrecioU_MonFact / TipoCampio), 3);
                    unitCostUSD = decimal.Round(ix.PrecioU_USD, 3);
                }

                new ManageContaConRemito().UpdateContabilizacionDatat0063(ix.Id63, unitCostARS, unitCostUSD,
                    ix.CantidadFacturar, txtNumeroDocumento.Text, ix.IncluirEVP, _tipoLx, TipoCampio, ix.GL);

                new ManageContaConRemito().UpdateTabla40(ix.Id63, _tipoLx);

            }

            var resultadoDoc = vendorInvoice.GrabaDocumento();
            if (resultadoDoc.IdFactura > 0 && resultadoDoc.CantidadItems > 0)
            {
                //txtId403.Text = resultadoDoc.IdFactura.ToString();
                //txtidFacturaX.Text = resultadoDoc.IdFacturaX.ToString();
                // ckDocument403Ok.Checked = true;
                //ckDocument403Ok.BackColor = _colorCkOk;
                ctacte.UpdateData403InCtaCteRecord(idCtaCte, resultadoDoc.IdFactura, resultadoDoc.IdFacturaX);
            }
            else
            {
                // txtId403.Text = @"Error";
                //  ckDocument403Ok.Checked = false;
                // ckDocument403Ok.BackColor = _colorCkError;
            }

            //Asientos Contables
            AsientoBase.IdentificacionAsiento resultadoAsientoC = new AsientoBase.IdentificacionAsiento();

            //retornoAsiento =
            //    new AsientoVendorSpecific("CONTAR").AsientoFromVendorDocument(Convert.ToInt32(txtId403.Text));
            var asiento = new AsientoVendorDocument(resultadoDoc.IdFactura, "CONTA1");
            resultadoAsientoC = asiento.AsientoFromVendorFactura();

            if (resultadoAsientoC.IdDocu > 0)
            {
                vendorInvoice.UpdateIdCtaCte_NAS_T403(resultadoDoc.IdFactura, idCtaCte, resultadoAsientoC.IdDocu);
                MessageBox.Show(@"La factura se ha contabilizado correctamente!", @"Contabilizacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // ckContabilizadoOK.Checked = true;
                //   ckContabilizadoOK.BackColor = _colorCkOk;
                txtNas.Text = resultadoAsientoC.IdDocu.ToString();



            }
            else
            {
                MessageBox.Show(@"Ocurrio un error al generar el Asiento Contable", @"Contabilizacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ckContabilizadoOK.Checked = false;
                //ckContabilizadoOK.BackColor = _colorCkError;
                txtNas.Text = @"Error";
            }
            //actualiza tabla history
            new RepoHistoryManager().AddManualRecord(resultadoDoc.IdFactura);
            //  return true;
        }

        private void txtImporteNetoFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtImporteNetoFactura_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipoCambio.Text))
            {
                txtTipoCambio.Text = 0.ToString("N4");
            }

            var tipoCambio = Convert.ToDecimal(txtTipoCambio.Text);

            if (string.IsNullOrEmpty(txtImporteNetoFacturaARS.Text))
            {
                txtImporteNetoFacturaARS.Text = 0.ToString("C2");
            }

            ImporteContabilizar = FormatAndConversions.CCurrencyADecimal(txtImporteNetoFacturaARS.Text);
            txtImporteNetoFacturaARS.Text = ImporteContabilizar.ToString("C2");


            if (string.IsNullOrEmpty(txtImporteNetoFacturaUSD.Text))
            {
                txtImporteNetoFacturaUSD.Text = 0.ToString("C2");
            }

            var importeNetoUSD = FormatAndConversions.CCurrencyADecimal(txtImporteNetoFacturaUSD.Text);
            txtImporteNetoFacturaUSD.Text = importeNetoUSD.ToString("C2");

            if (tipoCambio == 0)
            {
                if (importeNetoUSD > 0)
                {
                    //calculamos TC
                    tipoCambio = (ImporteContabilizar / importeNetoUSD);
                    txtTipoCambio.Text = tipoCambio.ToString("N4");
                }
                else
                {
                    //no tengo ni tipo de cambio / ni importe en USD
                }
            }
            else
            {

                //calculamos el importe en USD
                importeNetoUSD = ImporteContabilizar / tipoCambio;
                txtImporteNetoFacturaUSD.Text = importeNetoUSD.ToString("C2");
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
                txtFechaValidada.BackColor = Color.DarkSeaGreen;
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
                _fechaDocumento = null;
            }
        }

        private void mskFechaFactura_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtFechaValidada.BackColor = Color.OrangeRed;
            _fechaDocumento = null;

            toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
            toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA",
                mskFechaFactura,
                mskFechaFactura.Location, 5000);
        }

        private void txtTipoCambio_TextChanged(object sender, EventArgs e)
        {



            //Antes recalculaba el precio pero para faciliar la logica al agregar un item
            //bloqueamos cambiar los datos del Header del documento

            //foreach (var i in CostItems)
            //{
            //    i.PrecioU_USD = (i.PrecioU_MonFact / TipoCampio);
            //}
            //dgvItemsRemito.DataSource = itemFacturaBindingSource;
        }

        private void txtTipoCambio_DoubleClick(object sender, EventArgs e)
        {
            if (_fechaDocumento == null)
            {
                MessageBox.Show(
                    @"Para poder completar automaticamente el tipo de cambio debe ingresar primero una fecha valida",
                    @"AutoComplete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show(
                @"Se ha colocado un tipo de cambio automatico de acuerdo a la fecha de la factura ingresda",
                @"AutoComplete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(_fechaDocumento.Value).ToString("N2");
        }

        private void txtImporteNetoFactura_DoubleClick(object sender, EventArgs e)
        {
            txtImporteNetoFacturaARS.Enabled = true;
            txtImporteNetoFacturaARS.ReadOnly = false;
        }

        private void txtImporteNetoUSD_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtImporteNetoUSD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtImporteNetoFacturaUSD.Text))
            {
                txtImporteNetoFacturaUSD.Text = 0.ToString("C2");
            }

            if (string.IsNullOrEmpty(txtTipoCambio.Text))
            {
                txtTipoCambio.Text = 1.ToString("N4");
            }


            var importenetoUSD = FormatAndConversions.CCurrencyADecimal(txtImporteNetoFacturaUSD.Text);
            txtImporteNetoFacturaUSD.Text = importenetoUSD.ToString("C2");

            var tipodeCambio = Convert.ToDecimal(txtTipoCambio.Text);

            if (tipodeCambio == 0)
            {
                //calculo el tipo de cambio (si tengo valor ARS y USD)
                if (importenetoUSD != 0)
                {
                    txtTipoCambio.Text = (ImporteContabilizar / importenetoUSD).ToString("N2");
                }
                else
                {
                    //el importe en USD =>0 y el TC tambien. No hago nada
                }
            }
            else
            {
                if (importenetoUSD == 0)
                {
                    MessageBox.Show(
                        @"No se puede obtener el nuevo TC desde los importes porque el importe ingresado en USD es 0",
                        @"Error al obtener el TC de la factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                //tengo TC - Calculo el valor en ARS
                var importeRevisadoARS = (importenetoUSD * tipodeCambio);
                var importeActualARS = FormatAndConversions.CCurrencyADecimal(txtImporteNetoFacturaARS.Text);
                var nuevoTC = decimal.Round(importeActualARS / importenetoUSD, 4);

                if (TipoCampio == nuevoTC)
                {
                    //Al redondear el TC el valor es el mismo. No hago nada y no recaluclo importes con los nuevos decimales
                }
                else
                {
                    txtTipoCambio.Text = nuevoTC.ToString("n2");
                    MessageBox.Show(
                        @"Atencion se ha modificado el TC para cumplir con los valores de importes del documento. Revise el nuevo TC para asegurarse que es correcto",
                        @"Actualizacion del TC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //txtImporteNetoFactura.Text = (importenetoUSD*tipodeCambio).ToString("C2");
                //ImporteNetoFactura = importenetoUSD*tipodeCambio;
            }
        }

        private void dgvItemsRemito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            //var activo = Convert.ToBoolean(datagridview[aCTIVODataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "Liberar":
                    //using (var f0 = new FrmMaterialMasterAKA(primario, _modo, aka))
                    //{
                    //    DialogResult dr = f0.ShowDialog();
                    //    if (dr == DialogResult.OK)
                    //    {
                    //        //string custName = f0.CustomerName;
                    //        //SaveToFile(custName);
                    //    }
                    //}

                    break;


                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void cmbMonedaFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtImporteNetoFacturaARS.Text = 0.ToString("C2");
            txtImporteNetoFacturaUSD.Text = 0.ToString("C2");
            txtImporteNetoFacturaARS.ReadOnly = true;
            txtImporteNetoFacturaUSD.ReadOnly = true;

            if (cmbMonedaFactura.SelectedItem == null)
            {
                MonedaFactura = "ARS";
                //txtMon1.Text = @"ARS";
                //txtMon2.Text = @"USD";
                //LM1.Text = @"Completar Importe Factura [ARS]";
                //LM2.Text = @"Completar Importe Factura [USD]*";
                return;
            }

            if (cmbMonedaFactura.SelectedItem.ToString() == "USD")
            {
                MonedaFactura = "USD";
                txtImporteNetoFacturaUSD.ReadOnly = false;
                //txtMon2.Text = @"ARS";
                //txtMon1.Text = @"USD";
            }
            else
            {
                MonedaFactura = "ARS";
                txtImporteNetoFacturaARS.ReadOnly = false;
                //txtMon1.Text = @"ARS";
                //txtMon2.Text = @"USD";
            }
        }

        private void txtNumeroDocumento_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IdVendor == null)
                return;
            if (txtNumeroDocumento.MaskCompleted == false)
            {
                e.Cancel = true;
                MessageBox.Show(@"Debe completar el numero de documento completo", @"Numero Documento Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (new ValidacionVendorDocument().CheckIfDocumentAlreadyExist(IdVendor.Value, txtNumeroDocumento.Text,
                _tipoLx, _tipoDocumento))
            {
                MessageBox.Show(@"Ya Existe un documento con este numero ingresado para este proveedor",
                    @"Documento Repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mskFechaFactura_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mskFechaFactura.MaskCompleted)
            {
                var pOpen = new PeriodoAvailability().CheckPeriodoOpenFI(_fechaDocumento.Value);
                if (!pOpen)
                {
                    MessageBox.Show(
                        @"Atencion el Periodo Contable FI no se encuentra abierto y no se puede contabilizar esta factura en la fecha ingresada",
                        @"Periodo FI Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _periodoOK = false;
                    txtPeriodoFI.Text = @"CLOSE";
                }
                else
                {
                    _periodoOK = true;
                    txtPeriodoFI.Text = @"OPEN";
                }
            }
        }

        private void txtTipoCambio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipoCambio.Text))
                txtTipoCambio.Text = 0.ToString("n4");

            TipoCampio = Convert.ToDecimal(txtTipoCambio.Text);
            txtTipoCambio.Text = TipoCampio.ToString("N4");

            if (TipoCampio <= 0)
            {
                MessageBox.Show(@"El tipo de Cambio es Incorrecto!", @"Error en Tipo de Cambio", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                TipoCampio = 1;
                txtTipoCambio.Text = 1.ToString("N4");
            }
        }
        //

        private void NumeroDecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void NumeroDecimalNegativoKeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, true, true);
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

        public void CalculaValoresFooter(bool recalculaAuto = true)
        {
            decimal bruto = 0;
            decimal baseI = 0;
            decimal Kg = 0;
            var descuento = string.IsNullOrEmpty(txtImporteDescuento.Text)
                ? 0
                : FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text);

            txtImporteDescuento.Text = descuento.ToString("C2");
            foreach (var it in Items)
            {
                Kg += it.CantidadFacturar;
                bruto += it.PrecioT_MonFact;
                if (it.IncluyeBaseImponible)
                    baseI += it.PrecioT_MonFact;
            }

            if (bruto == 0)
                return;

            decimal descuentoPor = descuento / bruto;
            txtKgTotalFacturados.Text = Kg.ToString("N2");
            txtImporteBruto.Text = bruto.ToString("C2");
            baseI = baseI - (baseI * descuentoPor);
            txtBaseImponible.Text = baseI.ToString("c2");
            txtSubtotal.Text = (bruto - descuento).ToString("C2");
            if (recalculaAuto)
            {
                txtIva21.Text = (baseI * (decimal)0.21).ToString("c2");

                if (string.IsNullOrEmpty(txtIva10.Text))
                    txtIva10.Text = 0.ToString("c2");

                if (string.IsNullOrEmpty(txtIva27.Text))
                    txtIva27.Text = 0.ToString("c2");
            }

            txtTotalIva.Text =
                (FormatAndConversions.CCurrencyADecimal(txtIva10.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtIva21.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtIva27.Text)).ToString("C2");

            if (string.IsNullOrEmpty(txtPercIIBB.Text))
            {
                txtPercIIBB.Text = 0.ToString("C2");
                txtAlicIIBB.Text = 0.ToString("P2");
            }

            if (string.IsNullOrEmpty(txtPercIva.Text))
            {
                txtPercIva.Text = 0.ToString("C2");
                txtAlicIva.Text = 0.ToString("P2");
            }

            if (string.IsNullOrEmpty(txtPercGs.Text))
            {
                txtPercGs.Text = 0.ToString("C2");
            }

            txtTotalPercepciones.Text =
                (FormatAndConversions.CCurrencyADecimal(txtPercIIBB.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtPercIva.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtPercGs.Text)).ToString("C2");


            if (string.IsNullOrEmpty(txtImpuMunicipal.Text))
            {
                txtImpuMunicipal.Text = 0.ToString("C2");
            }

            if (string.IsNullOrEmpty(txtImpuProvincial.Text))
            {
                txtImpuProvincial.Text = 0.ToString("C2");
            }

            if (string.IsNullOrEmpty(txtImpuInternos.Text))
            {
                txtImpuInternos.Text = 0.ToString("C2");
            }

            if (string.IsNullOrEmpty(txtImpuOtros.Text))
            {
                txtImpuOtros.Text = 0.ToString("C2");
            }

            if (string.IsNullOrEmpty(txtConcpetoNoGravado.Text))
            {
                txtConcpetoNoGravado.Text = 0.ToString("C2");
            }

            txtTotalOtroImpuestos.Text =
                (FormatAndConversions.CCurrencyADecimal(txtImpuMunicipal.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtImpuProvincial.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtImpuInternos.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtImpuOtros.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtConcpetoNoGravado.Text)).ToString("C2");


            txtImporteNetoFinal.Text =
                (FormatAndConversions.CCurrencyADecimal(txtSubtotal.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtTotalIva.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtTotalPercepciones.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtTotalOtroImpuestos.Text)).ToString("C2");


            decimal redondeo = 0;
            decimal importeItems = 0;
            foreach (var ix in Items)
            {
                importeItems += (ix.PrecioU_MonFact * ix.CantidadFacturar);
            }

            redondeo = FormatAndConversions.CCurrencyADecimal(txtImporteBruto.Text) - importeItems;
            txtRedondeoVarios.Text = redondeo.ToString("C2");
        }


        public void SumaImportes(bool recalculoAutomaticoIva21, bool recalculoBaseImponible)
        {
            var id = 1;
            decimal importeBruto = 0;
            decimal totalKg = 0;
            decimal BaseImpoX = 0;
            decimal descuento = FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text);

            foreach (var it in Items)
            {
                totalKg += it.CantidadFacturar;
                importeBruto += it.PrecioT_MonFact;
                if (it.IncluyeBaseImponible)
                    BaseImpoX += it.PrecioT_MonFact;
            }

            if (importeBruto == 0)
                return;
            decimal descuentoPor = descuento / importeBruto;

            if (recalculoAutomaticoIva21)
            {
                txtIva21.Text = (BaseImpoX * (decimal)0.21).ToString("c2");

                if (string.IsNullOrEmpty(txtIva10.Text))
                    txtIva10.Text = 0.ToString("c2");

                if (string.IsNullOrEmpty(txtIva27.Text))
                    txtIva27.Text = 0.ToString("c2");
            }

            txtImporteBruto.Text = importeBruto.ToString("C2");
            txtKgTotalFacturados.Text = totalKg.ToString("N2");


            decimal subtotal = importeBruto - descuento;
            txtSubtotal.Text = subtotal.ToString("C2");
            decimal baseImponible = recalculoBaseImponible
                ? BaseImpoX
                : FormatAndConversions.CCurrencyADecimal(txtBaseImponible.Text);
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

            ImporteContabilizar = subtotal + totalIVA + totalPercepciones + totalOtrosImpuestos + importeRedondeo;
            txtImporteNetoFinal.Text = ImporteContabilizar.ToString("C2");


        }
        private void MonedaValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = @"0";
            decimal valor = FormatAndConversions.CCurrencyADecimal(txt.Text);
            txt.Text = valor.ToString("C2");
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


        #region ControlDeFecha
        private string completaFechaMask(DateTime fecha)
        {
            return DateTime.Today.Day.ToString("D2") + DateTime.Today.Month.ToString("D2") +
                   DateTime.Today.Year.ToString("D4");
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
                txtPeriodoFI.Text = @"Closed";
                txtPeriodoFI.BackColor = _colorValidacionFail;
            }
            else
            {
                _periodoOK = true;
                txtPeriodoFI.Text = @"Open!";
                txtPeriodoFI.BackColor = _colorValidacionOk;
            }
        }
        private void FechaDoubleClick(object sender, EventArgs e)
        {
            mskFechaFactura.Text = completaFechaMask(DateTime.Today);
            _fechaDocumento = DateTime.Today;
            ValidaPeriodoOpen();
        }
        private void FechaMaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtFechaValidada.BackColor = _colorValidacionFail;
            _fechaDocumento = null;
            txtPeriodoFI.Text = null;
            txtPeriodoFI.BackColor = _colorValidacionFail;
            _periodoOK = false;
            toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
            toolTip1.Show("Los datos ingresados no son correctos!(verifique haber ingresado una fecha DD/MM/AAAA",
                mskFechaFactura,
                mskFechaFactura.Location, 5000);
        }
        private void FechaTypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParseExact(mskFechaFactura.Text,
                "d/M/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                //valid date
                txtFechaValidada.BackColor = _colorValidacionOk;
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

                txtFechaValidada.BackColor = _colorValidacionFail;
                txtFechaValidada.Text = @"!";
                _fechaDocumento = null;
            }
        }
        private void FechaValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mskFechaFactura.MaskCompleted && _fechaDocumento != null)
            {
                ValidaPeriodoOpen();
                if (_periodoOK)
                {
                    TipoCampio = new ExchangeRateManager().GetExchangeRate(Convert.ToDateTime(mskFechaFactura.Text));
                    txtTipoCambio.Text = TipoCampio.ToString("N2");

                }

            }
        }
        #endregion

        #region ControlNumeroDeDocumento
        private void DocumentoMaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show(@"Ingrese el numero de Documento de Acuerdo a la Mascara de Entrada Definida",
                @"Error en mascara/numero documento", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        private void DocumentoLeave(object sender, TypeValidationEventArgs e)
        {
            //
        }
        private void DocumentoValidating(object sender, System.ComponentModel.CancelEventArgs e)
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
                if (new ValidacionVendorDocument().CheckIfDocumentAlreadyExist(IdVendor.Value, txtNumeroDocumento.Text,
                    _tipoLx, _tipoDocumento))
                {
                    MessageBox.Show(
                        @"El numero de documento ingresado ya existe para este proveedor (Factura Duplicada)",
                        @"Factura ingresada duplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    _docuNumValidado = false;
                    txtDocuNumOk.BackColor = _colorValidacionFail;
                    txtDocuNumOk.Text = @"!";
                    _numeroDoc = null;
                }
                else
                {
                    _docuNumValidado = true;
                    txtDocuNumOk.BackColor = _colorValidacionOk;
                    txtDocuNumOk.Text = @"OK";
                    _numeroDoc = txtNumeroDocumento.Text;
                }
            }
            else
            {
                if (new ValidacionVendorDocument().CheckIfDocumentAlreadyExist(IdVendor.Value, txtNumeroDocumento.Text,
                    _tipoLx, _tipoDocumento))
                {
                    MessageBox.Show(
                        @"El numero de documento ingresado ya existe para este proveedor (Factura Duplicada) pero ha seleccionado Ignorar este Error!",
                        @"Factura ingresada duplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _docuNumValidado = true;
                    txtDocuNumOk.Text = @"??";
                    txtDocuNumOk.BackColor = Color.Crimson;
                    _numeroDoc = txtNumeroDocumento.Text;
                }
                else
                {
                    _docuNumValidado = true;
                    txtDocuNumOk.BackColor = _colorValidacionOk;
                    txtDocuNumOk.Text = @"OK";
                    _numeroDoc = txtNumeroDocumento.Text;
                }
            }
        }
        #endregion


    }
}
