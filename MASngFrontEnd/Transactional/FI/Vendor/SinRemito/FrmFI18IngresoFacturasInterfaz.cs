using System;
using System.ComponentModel;
using System.Windows.Forms;
using MASngFE.MasterData;
using MASngFE.SuperMD;
using MASngFE.Transactional.FI.ContabilizacioFactura.SinRemito;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.Imputacion;
using Tecser.Business.Transactional.FI.MainDocumentData;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.FI.Vendor.SinRemito
{
    public partial class FrmFI18IngresoFacturasInterfaz : Form
    {
        private readonly string _cuit;
        private readonly string _tipoDocumento;
        private readonly string _numeroDocumento;
        private readonly DateTime _fecha;
        private readonly string _moneda;
        private readonly decimal _tc;
        private readonly decimal _netoGravado;
        private readonly decimal _netoNoGravado;
        private readonly decimal _iva;
        private readonly decimal _exento;
        private readonly decimal _TotalFinalARS;
        private int _idVendor;
        private decimal _variacionPrecio;
        private readonly string _tipoLx = "L1";
        private static DateTime _prevClick;
        private const string TcodeName = @"CONTAI";
        private bool _numeroDocumentoValidado = false;

        public FrmFI18IngresoFacturasInterfaz()

        {
            InitializeComponent();
        }
        public FrmFI18IngresoFacturasInterfaz(string cuit, string tipoDocumento, string numeroDocumento, DateTime fecha, string moneda, decimal tc, decimal netoGravado, decimal netoNoGravado, decimal iva, decimal exento, decimal totalFinalARS)
        {
            _cuit = cuit;
            _tipoDocumento = tipoDocumento;
            _numeroDocumento = numeroDocumento;
            _fecha = fecha;
            _moneda = moneda;
            _tc = tc;
            _netoGravado = netoGravado;
            _netoNoGravado = netoNoGravado;
            _iva = iva;
            _exento = exento;
            _TotalFinalARS = totalFinalARS;
            InitializeComponent();
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

        }
        private void FrmFI18IngresoFacturasInterfaz_Load(object sender, EventArgs e)
        {
            ResetImportes();
            var vendor = new VendorManager().GetSpecificVendor(_cuit);
            if (vendor != null)
            {
                _idVendor = vendor.id_prov;
            }
            else
            {
                var resp = MessageBox.Show(@"Desea crear este proveedor con datos automaticos del Padron?",
                    @"Proveedor No Encontrado en Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                {
                    MessageBox.Show(@"No se puede continuar porque no se ha encontrado un vendor registrado",
                        @"Vendor Inexistente o Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                using (var fx = new FrmVendorDetailData(_cuit))
                {
                    fx.ShowDialog();
                    vendor = new VendorManager().GetSpecificVendor(_cuit);
                    _idVendor = vendor.id_prov;
                }
            }

            ckRealizarPagoAuto.Checked = true;

            txtRazonSocial.Text = vendor.prov_rsocial;
            txtIdVendor.Text = _idVendor.ToString();
            txtGLAP.Text = new GLAccountManagement().GetApVendorGl(_idVendor);
            txtCUIT.Text = _cuit.ToString();
            txtNumeroDoc.Text = _numeroDocumento;
            var zdoc = _tipoDocumento.Substring(0, 1);
            switch (zdoc)
            {
                case "1":
                    txtTipoDoc.Text = @"FPA";
                    break;
                case "2":
                    txtTipoDoc.Text = @"NDA";
                    break;
                case "3":
                    txtTipoDoc.Text = @"NCA";
                    break;
                default:
                    MessageBox.Show(@"El tipo de documento no se encuentra implementado", @"Funcionalidad No Implementada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
            txtTipoDocDescripcion.Text = _tipoDocumento.Substring(3, (_tipoDocumento.Length - 4));

            if (new ValidacionVendorDocument().CheckIfDocumentAlreadyExist(_idVendor, _numeroDocumento, "L1",
                txtTipoDoc.Text))
            {
                _semNumeroDoc.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                btnNuevaContabilizacion.Enabled = false;
                _numeroDocumentoValidado = false;
            }
            else
            {
                _semNumeroDoc.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                btnNuevaContabilizacion.Enabled = true;
                _numeroDocumentoValidado = true;
            }

            txtMoneda.Text = _moneda;
            txtMonedaConta.Text = @"ARS";
            txtTc.Text = _tc.ToString("N2");
            txtFechaDocumento.Text = _fecha.ToString("d");
            if (!new PeriodoAvailability().CheckPeriodoOpenFI(_fecha))
            {
                MessageBox.Show(@"No se puede contabilizar el documento porque el periodo FI se encuentra cerrado",
                    @"Periodo FI Closed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnNuevaContabilizacion.Enabled = false;
            }

            t0135GLXBindingSource.DataSource = ckSoloGLCompras.Checked
                ? new GLAccountManagement().GetListGLImputacionCompras()
                : new GLAccountManagement().GetGLListPermiteImputacion();
            cmbGlImputacionItem.SelectedIndex = -1;
            txtGlDescripcionItem.Text = null;
            var listaInfoRecords = new VendorManager().GetListItemsProveedor(_idVendor);
            cmbDescripcionItem.DataSource = listaInfoRecords;

            txtImporteDescuento.Text = 0.ToString("C2");
            txtImporteBruto.Text = (_netoGravado + _exento).ToString("C2");
            txtConcpetoNoGravado.Text = _netoNoGravado.ToString("C2");
            txtImporteNetoFinal.Text = _TotalFinalARS.ToString("C2");
            txtIva21.Text = _iva.ToString("C2");
            txtSubtotal.Text = txtImporteBruto.Text;
            txtBaseImponible.Text = (_netoGravado).ToString("C2");
            //
            txtCantidad.Text = @"1";
            txtPrecioU.Text = txtImporteBruto.Text;
            txtPrecioT.Text = txtPrecioU.Text;
            //
            SumaImportes(false, false);
            CuentasBs.DataSource = new CuentasManager().GetListaCuentasAvailableForContar(txtMonedaConta.Text);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaContabilizacion_Click(object sender, EventArgs e)
        {
            if (_variacionPrecio != 0)
            {
                MessageBox.Show(@"No se puede contabilizar porque existe una diferencia con el valor a Ingresar",
                    @"Diferencia de Importes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ckRealizarPagoAuto.Checked)
            {
                if (cmbCuentaAPagar.SelectedIndex == -1)
                {
                    MessageBox.Show(@"Debe Seleccionar una cuenta GL de Pago", @"Cuenta No Seleccionada",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            if (string.IsNullOrEmpty(txtGlDescripcionItem.Text))
            {
                MessageBox.Show(@"Debe Completar la Descripcion del Item", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(cmbGlImputacionItem.Text))
            {
                MessageBox.Show(@"Debe Completar la Cuenta GL del Items", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            var msg = MessageBox.Show($@"Confirma contabilizacion por importe {txtImporteNetoFinal.Text} ?",
                @"Confirmacion de Operacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
                return;

            if (ckMantenerInfoRecord.Checked)
            {
                new VendorInforRecordManager().MantieneInforecordProveedorMaterial(_idVendor, cmbDescripcionItem.Text,
                    txtMoneda.Text, FormatAndConversions.CCurrencyADecimal(txtPrecioU.Text), cmbGlImputacionItem.Text,
                    recuerdaPrecio: true);
            }

            if (cmbGlImputacionItem.SelectedValue == null)
            {
                MessageBox.Show(@"Error en GL Input - null");
                return;
            }


            if (string.IsNullOrEmpty(cmbGlImputacionItem.SelectedValue.ToString()))
            {
                MessageBox.Show(@"Error en GL Input - null");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            if (ContabilizacionContar())
            {

                btnNuevaContabilizacion.Enabled = false;
                if (ckRealizarPagoAuto.Checked)
                {
                    EjecutaPagoDirecto();
                }
            }
            else
            {
            }
            Cursor.Current = Cursors.Default;
        }

        private void EjecutaPagoDirecto()
        {
            var importeAPagar = _TotalFinalARS;
            var idFactura = Convert.ToInt32(txtId403.Text);
            var documento = new VendorInvoice(TcodeName, idFactura);
            var ctacte = new CtaCteVendor(_idVendor);

            //Genera documento PD en T0203
            if (string.IsNullOrEmpty(txtidFacturaX.Text))
                txtidFacturaX.Text = @"0";

            var idCtaCtePago = ctacte.AddCtaCteDetalleRecord("PD", _tipoLx, _fecha, _numeroDocumento, txtId403.Text,
                txtMonedaConta.Text, _TotalFinalARS * -1, _tc, 0, idDocAlternativo: Convert.ToInt32(txtidFacturaX.Text),
                idDocumentoPrincipal: Convert.ToInt32(txtId403.Text));


            var resultadoAsiento =
                new AsientoVendorDocument(Convert.ToInt32(txtId403.Text), TcodeName).GeneraAsientoPagoAutomaticoContar(
                    Convert.ToInt32(txtNAS.Text), cmbCuentaAPagar.SelectedValue.ToString());
            if (resultadoAsiento.IdDocu == 0)
            {
                txtnumeroAsientoPago.Text = @"Error";
                MessageBox.Show(@"Ha ocurrido un error al procesar el asiento de Pago", @"Asiento de Pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtnumeroAsientoPago.Text = resultadoAsiento.IdDocu.ToString();
            documento.UpdateSaldoImpagoT0403(0);


            new ManageVendorImputacionDocumentos().GeneraMovimientoImputacion(Convert.ToInt32(txtidCtaCte.Text),
                idCtaCtePago,
                txtGLCuentaAPagar.Text, "CONTAR", resultadoAsiento.IdDocu);

            ctacte.UpdateImporteSaldoFactura(Convert.ToInt32(txtidCtaCte.Text), 0);
            ctacte.UpdateSaldoCtaCteResumen(_tipoLx,
                new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteAPagar.Text) * -1);

            new RegisterManager().AddRegisterRecord(cmbCuentaAPagar.SelectedValue.ToString(),
                _fecha, "PD", _numeroDocumento, TipoEntidad.Proveedor, _idVendor,
                "Pago Directo Realizado", txtMoneda.Text, 0, _TotalFinalARS, 0, _tipoLx,
                txtGLCuentaAPagar.Text, Convert.ToInt32(txtnumeroAsientoPago.Text), TcodeName, true);

            MessageBox.Show(@"Se ha realizado el Pago Completo en forma correcta", @"Pago Completo",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information);

            cmbCuentaAPagar.SelectedIndex = -1;
            txtCuentaApagarDescripcion.Text = null;
            txtImporteAPagar.Text = 0.ToString("C2");
            txtGLCuentaAPagar.Text = null;
        }

        private T0203_CTACTE_PROV MapFormDataToCtaCte203Structure()
        {
            var docu = new T0203_CTACTE_PROV()
            {
                IDCTACTE = 0,
                TDOC = txtTipoDoc.Text,
                NUMDOC = _numeroDocumento,
                DOC_INTERNO = null,
                Fecha = _fecha,
                ZTERM = new VendorManager().GetZterm(_idVendor, _tipoLx),
                IDPROV = _idVendor,
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
                docu.IMPORTE_ORI = _TotalFinalARS;
                docu.IMPORTE_ARS = _TotalFinalARS;
            }
            else
            {
                docu.IMPORTE_ORI = _TotalFinalARS;
                docu.IMPORTE_ARS = _TotalFinalARS;
            }

            docu.SALDOFACTURA = docu.IMPORTE_ARS;
            return docu;
        }



        private bool ContabilizacionContar()
        {

            //1 Add Factura 203 + Update deuda 204  >>retorno idctacte
            var ctacte = new CtaCteVendor(_idVendor);
            var data = MapFormDataToCtaCte203Structure();
            var idCtaCte = ctacte.AddCtaCteDetalleRecord(data.TDOC, data.TIPO, data.Fecha.Value, data.NUMDOC,
                data.DOC_INTERNO, data.MONEDA, data.IMPORTE_ORI.Value, data.TC.Value, data.SALDOFACTURA.Value, data.IMPORTE_ARS.Value,
                data.IdFacturaX.Value, data.IdFacturaX.Value);

            if (idCtaCte > 0)
            {
                ctacte.UpdateSaldoCtaCteResumen(data.TIPO, data.IMPORTE_ORI.Value, data.MONEDA, data.TC);
                var result = ctacte.GetResultadoCtaCte(data.TIPO);
                txtidCtaCte.Text = idCtaCte.ToString();
            }
            else
            {

                return false;
            }


            //2. Add Record 403 + 404
            var vendorInvoice = new VendorInvoice(_idVendor, "INTAFIP");

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


            vendorInvoice.AddItemInMemory(Convert.ToDecimal(txtCantidad.Text), txtGlDescripcionItem.Text, "ARS", FormatAndConversions.CCurrencyADecimal(txtPrecioU.Text), data403.TC,
                cmbGlImputacionItem.SelectedValue.ToString());


            var resultadoDoc = vendorInvoice.GrabaDocumento();

            if (resultadoDoc.IdFactura > 0 && resultadoDoc.CantidadItems > 0)
            {
                txtId403.Text = resultadoDoc.IdFactura.ToString();
                txtidFacturaX.Text = resultadoDoc.IdFacturaX.ToString();

                ctacte.UpdateData403InCtaCteRecord(idCtaCte, resultadoDoc.IdFactura, resultadoDoc.IdFacturaX);
            }
            else
            {
                txtId403.Text = @"Error";
            }

            //Asientos Contables
            AsientoBase.IdentificacionAsiento resultadoAsientoC = new AsientoBase.IdentificacionAsiento();
            var asiento = new AsientoVendorDocument(resultadoDoc.IdFactura, TcodeName);
            resultadoAsientoC = asiento.AsientoFromVendorFactura();

            if (resultadoAsientoC.IdDocu > 0)
            {
                vendorInvoice.UpdateIdCtaCte_NAS_T403(resultadoDoc.IdFactura, idCtaCte, resultadoAsientoC.IdDocu);
                MessageBox.Show(@"La factura se ha contabilizado correctamente!", @"Contabilizacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNAS.Text = resultadoAsientoC.IdDocu.ToString();
            }
            else
            {
                MessageBox.Show(@"Ocurrio un error al generar el Asiento Contable", @"Contabilizacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtNAS.Text = @"Error";
            }

            return true;
        }

        private T0403_VENDOR_FACT_H Map403H()
        {
            var h = new T0403_VENDOR_FACT_H
            {
                FECHA = _fecha,
                IDPROV = _idVendor,
                IDINT = 0,
                TC = Convert.ToDecimal(txtTc.Text),
                BRUTO = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteBruto.Text),
                DTO = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteDescuento.Text),
                SUBTOTAL = new FormatAndConversions().GetCurrencyFormat_Decimal(txtSubtotal.Text),
                BaseImponible = new FormatAndConversions().GetCurrencyFormat_Decimal(txtBaseImponible.Text),
                IVA10 = new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva10.Text),
                IVA21 = new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva21.Text),
                IVA27 = new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva27.Text),
                TOTALIVA = new FormatAndConversions().GetCurrencyFormat_Decimal(txtTotalIva.Text),
                PerIVA = new FormatAndConversions().GetCurrencyFormat_Decimal(txtPercIva.Text),
                PerIVA_Alicuota = FormatAndConversions.CPorcentajeADecimal(txtAlicIva.Text),
                PerIIBB = new FormatAndConversions().GetCurrencyFormat_Decimal(txtPercIIBB.Text),
                PerIIBB_Alicuota = FormatAndConversions.CPorcentajeADecimal(txtAlicIIBB.Text),
                PerIIBB_TXT = txtDistritoIIBB.Text,

                ImpuestoMunicipal = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImpuMunicipal.Text),
                ImpuestoProvincial = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImpuProvincial.Text),
                IMPINT = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImpuInternos.Text),
                IMPOTR = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImpuOtros.Text),
                ConceptosNoGravados = new FormatAndConversions().GetCurrencyFormat_Decimal(txtConcpetoNoGravado.Text),
                TotalImpuestosVarios = new FormatAndConversions().GetCurrencyFormat_Decimal(txtTotalOtroImpuestos.Text),
                NETO = _TotalFinalARS,
                TCODE = TcodeName,
                GLAP = txtGLAP.Text,
                CANTKG = Convert.ToDecimal(txtKgTotalFacturados.Text),
                OBSERVACION = "Interfaz AFIP - " + txtTipoDoc.Text + "@" + txtRazonSocial.Text,
                SALDOIMPAGO = _TotalFinalARS,
                MON = txtMoneda.Text,
                TFACTURA = txtTipoDoc.Text,
                NFACTURA = _numeroDocumento,
                TIPO = _tipoLx,
                IMPORI = _TotalFinalARS,
                StatusDocumento = "Intefaz",
                PerGS = 0,
                PerGA_Alicuota = 0,
                RedondeoFinal = new FormatAndConversions().GetCurrencyFormat_Decimal(txtRedondeoVarios.Text),
            };
            return h;
        }

        private void cmbDescripcionItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDescripcionItem.SelectedValue == null)
                return;

            var x = cmbDescripcionItem.SelectedValue.ToString();
            var r = new VendorInforRecordManager().GetInfoRecord(_idVendor, x);

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

        private void NumeroDecimalValidating(object sender, CancelEventArgs e)
        {

        }

        private void DecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void MonedaValidating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = @"0";
            decimal valor = FormatAndConversions.CCurrencyADecimal(txt.Text);
            txt.Text = valor.ToString("C2");
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

        private void PorcentajeValidating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = @"0";
            decimal valor = Convert.ToDecimal(txt.Text);
            txt.Text = valor.ToString("P3");
        }

        private void PercecpcionesValidated(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            decimal baseImpo = _netoGravado;
            txtBaseImponible.Text = _netoGravado.ToString("C2");

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
        private void SumaImportes(bool recalculoAutomaticoIva21, bool recalculoBaseImponible)
        {
            decimal _importeTotal;
            var id = 1;
            decimal importeBruto = 0;

            importeBruto = _netoGravado + _exento;
            decimal descuento = FormatAndConversions.CCurrencyADecimal(txtImporteDescuento.Text);
            decimal subtotal = importeBruto - descuento;
            txtSubtotal.Text = subtotal.ToString("C2");
            txtBaseImponible.Text = _netoGravado.ToString("C2");
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
            _variacionPrecio = _TotalFinalARS - _importeTotal;
            txtDiferencia.Text = _variacionPrecio.ToString("C2");
            if (_variacionPrecio != 0)
            {
                btnNuevaContabilizacion.Enabled = false;
            }
            else
            {
                if (_numeroDocumentoValidado)
                {
                    btnNuevaContabilizacion.Enabled = true;
                }
            }
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

        private void cmbDescripcionItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (DateTime.Now.AddMilliseconds(-500) < _prevClick)
            {
                if (_idVendor < 1)
                {
                    MessageBox.Show(@"Para visualizar items debe primero seleccionar un proveedor", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var f2 = new FrmInfoRecordContaR(_idVendor);
                f2.ShowDialog();
            }

            _prevClick = DateTime.Now;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void txtPrecioU_TextChanged(object sender, EventArgs e)
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

        private void ckRealizarPagoAuto_CheckedChanged(object sender, EventArgs e)
        {
            txtImporteAPagar.Text = ckRealizarPagoAuto.Checked ? _TotalFinalARS.ToString("C2") : 0.ToString("C2");
        }

        private void ckSoloGLCompras_CheckedChanged(object sender, EventArgs e)
        {
            t0135GLXBindingSource.DataSource = ckSoloGLCompras.Checked
                ? new GLAccountManagement().GetListGLImputacionCompras()
                : new GLAccountManagement().GetGLListPermiteImputacion();
        }
    }
}
