using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Transactional.SD.Remito;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.CO.ContaFromDocuments;
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
    public partial class FrmFI25RefacturacionDocumento : Form
    {
        public FrmFI25RefacturacionDocumento()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------------
        private int idFacOri;
        private int _idRemito;
        private T0400_FACTURA_H _fH = new T0400_FACTURA_H();
        private List<T0401_FACTURA_I> _fI = new List<T0401_FACTURA_I>();
        private DocumentFIStatusManager.StatusHeader _statusDoc;
        private CustomerMainDocument _docData = new CustomerInvoice("RFAC", 0);
        private MainDocumentBase.FacturaId _facturaIdStruct;
        private int _idRemitoNew = 0;
        //-------------------------------------------------------------------------------------------------------------------------

        private void txtNumeroRemito_Leave(object sender, EventArgs e)
        {
            idFacOri = new Refacturacion().GetIdFacturaFromRemito(txtNumeroRemito.Text);
            if (idFacOri == 0)
            {
                MessageBox.Show(@"No se ha podido encontrar un documento con el numero ingresado", @"Datos Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                return;
            }
            if (idFacOri == -1)
            {
                MessageBox.Show(@"Existe mas de un documento con el numero ingresado (probablemente el documento ya se encuentra refacturado", @"No se Puede Anular",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                return;
            }
            MapDatosDocumentOriginal();

            //Prepara datos para el nuevo documento
            cFechaFactuNew.Value = DateTime.Today;
            txtNewTC.Text = txtTCOri.Text;
            ckChangeDocLx.Value = false;
            if (txtLxNew.Text == @"L1")
            {
                cAlicuotaIIBB.SetValue = GetIIBBPercepcion(cFechaFactuNew.Value.Value, txtCuit.Text);
            }

            _statusDoc = DocumentFIStatusManager.StatusHeader.Pendiente;
            txtStatusDocNew.Text = _statusDoc.ToString();
            RecalculaTotalesMemoria(false);
            AccionSegunEstado();



        }

        private void SetStadoInicial()
        {
            btnARBA.Enabled = false;
            btnCancelarContabilizacion.Enabled = false;
            btnContabilizar.Enabled = false;
            btnEnviarEmail.Enabled = false;
            btnImprimirFactura.Enabled = false;
            btnImprimirFactura.Enabled = false;
            btnSetEstadoInicial.Enabled = false;
            btnSetEstadoRegistrado.Enabled = true;
            btnSolicitarCAE.Enabled = false;
            btnGenerarNewRemito.Enabled = false;
        }


        private void AccionSegunEstado()
        {
            btnARBA.Enabled = false;
            btnCancelarContabilizacion.Enabled = false;
            btnContabilizar.Enabled = false;
            btnEnviarEmail.Enabled = false;
            btnImprimirFactura.Enabled = false;
            btnImprimirFactura.Enabled = false;
            btnSetEstadoInicial.Enabled = false;
            btnSetEstadoRegistrado.Enabled = false;
            btnSolicitarCAE.Enabled = false;
            btnGenerarNewRemito.Enabled = false;


            switch (_statusDoc)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    btnSetEstadoRegistrado.Enabled = true;
                    btnARBA.Enabled = true;
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    btnSetEstadoInicial.Enabled = true;
                    btnContabilizar.Enabled = true;
                    break;
                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    btnCancelarContabilizacion.Enabled = true;
                    break;
                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    btnImprimirFactura.Enabled = true;
                    break;
                case DocumentFIStatusManager.StatusHeader.Impresa:
                    btnImprimirFactura.Enabled = true;
                    break;
                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    break;
                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    btnSolicitarCAE.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private decimal GetIIBBPercepcion(DateTime fecha, string numeroCuit)
        {
            Cursor.Current = Cursors.WaitCursor;
            var periodo = new PeriodoConversion().GetPeriodo(fecha);
            var fechaDesde = new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(periodo);
            var fechaHasta = new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(periodo);
            var dataArba = new PadronArba();
            dataArba.Conectar(numeroCuit, fechaDesde, fechaHasta);
            var resultado = dataArba.AlPerc;
            Cursor.Current = Cursors.Default;
            return (decimal)resultado;
        }

        private void MapDatosDocumentOriginal()
        {
            var t400 = new T400Manager();
            _fH = t400.GetDocumentHeader(idFacOri);
            _idRemito = _fH.IDRemito.Value;
            txtClienteDescripcion.Text = _fH.RAZONSOC;
            txtIdCliente.Text = _fH.Cliente.ToString();
            txtFechaDocOri.Text = _fH.FECHA.ToString("d");
            txtLxOri.Text = _fH.TIPOFACT;
            txtTdocOri.Text = _fH.TIPO_DOC;
            if (txtLxOri.Text == @"L1")
            {
                txtNumeroFacturaOri.Text = _fH.PV_AFIP + @"-" + _fH.ND_AFIP;
            }
            else
            {
                txtNumeroFacturaOri.Text = _fH.Remito;
            }

            txtTCOri.Text = _fH.TC.ToString("N2");
            txtStatusOri.Text = _fH.StatusFactura;
            txtImporteOri.Text = _fH.TotalFacturaN.ToString("C2");
            ckChangeDocLx.Value = false;
            txtLxNew.Text = txtLxOri.Text;
            txtNewTdoc.Text = txtLxOri.Text == @"L1" ? @"FA" : @"F2";
            txtNewTC.Text = txtTCOri.Text;
            txtCaeOri.Text = _fH.CAE;
            txtCuit.Text = _fH.CUIT;
            _fI = t400.GetDocumentItems(idFacOri);
            t0401FACTURAIBindingSource.DataSource = _fI;
        }
        private void ClearData() { }
        private void FrmFI25RefacturacionDocumento_Load(object sender, EventArgs e)
        {
            txtNewTC.Init(0, 1000, 2);
        }
        private void ckChangeDocLx_CheckedChanged(object sender, EventArgs e)
        {
            if (ckChangeDocLx.Value == true)
            {
                txtLxNew.Text = txtLxOri.Text == @"L1" ? @"L2" : @"L1";
            }
            else
            {
                txtLxNew.Text = txtLxOri.Text;
            }

            if (txtLxNew.Text == @"L1")
            {
                btnARBA.Enabled = true;
                cAlicuotaIIBB.Enabled = true;
                btnGenerarNewRemito.Enabled = true;
            }
            else
            {
                btnARBA.Enabled = false;
                cAlicuotaIIBB.SetValue = 0;
                cAlicuotaIIBB.Enabled = false;
            }
        }
        private void txtNewTC_Validated(object sender, EventArgs e)
        {
            decimal valor = txtNewTC.ValueD;
            txtNewTC.BackColor = Color.White;
            if (Convert.ToDecimal(txtTCOri.Text) != valor)
            {
                var r = MessageBox.Show(@"Confirma la modificacion del Tipo de Cambio?",
                    @"Confirmacion de Modificacion de Datos", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r != DialogResult.Yes)
                    return;
            }
            txtNewTC.BackColor = Color.LightGreen;
            foreach (var item in _fI)
            {
                if (item.MONEDA_COTIZ == "USD")
                {
                    item.PRECIOU_FACT_ARS = item.PRECIOU_FACT_USD * valor;
                    item.PRECIOT_FACT_ARS = item.PRECIOT_FACT_USD * valor;
                }
            }
            t0401FACTURAIBindingSource.DataSource = _fI.ToList();
            RecalculaTotalesMemoria(false);
        }
        private void RecalculaTotalesMemoria(bool recalDtoPorcentaje = false)
        {
            decimal vInicial = _fI.Sum(c => c.PRECIOT_FACT_ARS);
            decimal vDescuento = 0;
            decimal vDescuentoPorcentaje = 0;
            if (!recalDtoPorcentaje)
            {
                vDescuentoPorcentaje = cDescPorcentaje.GetValueDecimal;
                vDescuento = vInicial * vDescuentoPorcentaje;
            }
            else
            {
                vDescuento = cDescuento.GetValueDecimal;
                vDescuentoPorcentaje = vDescuento / vInicial;
            }


            decimal vSubTotal = vInicial - vDescuento;
            decimal vAlicIIBB = cAlicuotaIIBB.GetValueDecimal;

            decimal vBaseImponible = 0;
            decimal vIva105 = 0;
            decimal vIva21 = 0;
            decimal vPerIIBB = 0;
            decimal vFinal = 0;

            foreach (var items in _fI)
            {
                if (items.IVA21)
                {
                    vBaseImponible += items.PRECIOT_FACT_ARS;
                }

                if (vDescuentoPorcentaje != 0)
                {
                    vBaseImponible = vBaseImponible - (vBaseImponible * vDescuentoPorcentaje);
                }
            }
            vIva21 = vBaseImponible * (decimal)0.21;
            vPerIIBB = vBaseImponible * cAlicuotaIIBB.GetValueDecimal;
            vFinal = vSubTotal + vIva21 + vPerIIBB;
            //
            cBrutoInicial.SetValue = vInicial;
            cDescPorcentaje.SetValue = vDescuentoPorcentaje;
            cDescuento.SetValue = vDescuento;
            cSubTotal.SetValue = vSubTotal;
            cBaseImponible.SetValue = vBaseImponible;
            cIva105.SetValue = vIva105;
            cIva21.SetValue = vIva21;
            cPercIIBB.SetValue = vPerIIBB;
            cImporteNetoFinal.SetValue = vFinal;
            //
            txtImporteFinalNew.Text = vFinal.ToString("C2");
            var difPrecio = vFinal - FormatAndConversions.CCurrencyADecimal(txtImporteOri.Text);

            txtDifPrecio.Text = difPrecio.ToString("C2");
            if (difPrecio != 0)
            {
                MessageBox.Show(
                    @"Las condiciones del documento a refacturar esta generando una diferencia de precio con respecto al documento original",
                    @"Atencion diferencia de Precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void MapeaValoresFromDb()
        {
            cAlicuotaIIBB.SetValue = _fH.IIBB_PORC.Value;
            cBrutoInicial.SetValue = _fH.TotalFacturaB;
            if (_fH.DescuentoPorc == null)
                _fH.DescuentoPorc = 0;

            cDescPorcentaje.SetValue = _fH.DescuentoPorc.Value;
            cDescuento.SetValue = _fH.Descuento.Value;
            cSubTotal.SetValue = _fH.TotalFacturaB - _fH.Descuento.Value;
            cBaseImponible.SetValue = _fH.TotalImpo;
            cIva105.SetValue = 0;
            cIva21.SetValue = _fH.TotalIVA21;
            cPercIIBB.SetValue = _fH.IIBB_PORC.Value;
            cImporteNetoFinal.SetValue = _fH.TotalFacturaN;

            if (string.IsNullOrEmpty(_fH.CAE))
            {
                txtCAEVencimiento.Text = null;
                txtCAE.Text = null;
            }
            else
            {
                txtCAEVencimiento.Text = _fH.CAE_VTO.ToString();
                txtCAE.Text = _fH.CAE;
            }

            txtImporteFinalNew.Text = "";

        }
        private void ckExentoPercpecionARBA_CheckedChanged(object sender, EventArgs e)
        {
            if (ckExentoPercpecionARBA.Checked)
            {
                cAlicuotaIIBB.SetValue = 0;
                RecalculaTotalesMemoria();
            }
        }
        private void cDescPorcentaje_Validated(object sender, EventArgs e)
        {
            RecalculaTotalesMemoria(false);
        }
        private void cDescuento_Validated(object sender, EventArgs e)
        {
            RecalculaTotalesMemoria(true);
        }





        private bool ValidaOKContabilizar()
        {

            return true;
        }






        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSetEstadoRegistrado_Click(object sender, EventArgs e)
        {
            bool requiereNewRemito = false;

            var msg = MessageBox.Show(@"Confirma el Registro del Documento?", @"Registracion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            if (txtLxNew.Text != txtLxOri.Text)
            {
                requiereNewRemito = true;

                if (_idRemitoNew == 0)
                {
                    if (txtLxNew.Text == @"L1")
                    {
                        MessageBox.Show(@"Esta Accion requiere generar un nuevo Remito L1",
                            @"Generacion de Remito Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(@"Esta Accion requiere generar un nuevo Remito L2",
                            @"Generacion de Remito Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    return;
                }
            }

            ManageDocumentType.TipoDocumento tipoDoc;
            if (txtLxNew.Text == @"L1")
            {
                tipoDoc = ManageDocumentType.TipoDocumento.FacturaVentaA;
                txtNewTdoc.Text = @"FA";
            }
            else
            {
                tipoDoc = ManageDocumentType.TipoDocumento.FacturaVenta2;
                txtNewTdoc.Text = @"F2";
            }

            int idXRemito;
            idXRemito = requiereNewRemito ? _idRemitoNew : _idRemito;

            _docData.CreateNewHeaderInMemory(tipoDoc, Convert.ToInt32(txtIdCliente.Text), cFechaFactuNew.Value.Value,
                txtLxNew.Text, txtNewTC.ValueD, cBrutoInicial.GetValueDecimal, cDescuento.GetValueDecimal,
                cBaseImponible.GetValueDecimal, cIva21.GetValueDecimal, cPercIIBB.GetValueDecimal,
                cImporteNetoFinal.GetValueDecimal, cAlicuotaIIBB.GetValueDecimal, "", @"ARS", idXRemito);
            foreach (var item in _fI)
            {
                _docData.AddItemListToMemorySimple(item.ITEM, item.DESC_REMITO, item.KGDESPACHADOS_R.Value, item.IVA21, item.MONEDA_COTIZ, item.PRECIOU_COTIZ, item.PRECIOU_FACT_ARS, item.GLI, item.GLV);
            }
            _facturaIdStruct = _docData.GrabaDocumentoToDatabase();

            if (new DocumentFIStatusManager().SetStatusRegistrado(_facturaIdStruct.IdFactura))
            {
                _statusDoc = DocumentFIStatusManager.StatusHeader.Registrada;
                txtStatusDocNew.Text = _statusDoc.ToString();
                AccionSegunEstado();
            }
            else
            {
                MessageBox.Show(@"La Factura no pudo ser pasada a estado REGISTRADA", @"Error en Cambio de Estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnSetEstadoInicial_Click(object sender, EventArgs e)
        {
            var confirma = MessageBox.Show(@"Confirma el regreso del documento a estado PENDIENTE (se remueven los CostItems y se vuelven a generar)?", @"Registracion de Documento",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirma == DialogResult.No)
                return;

            if (new DocumentFIStatusManager().SetStatusPendiente(_facturaIdStruct.IdFactura))
            {
                _statusDoc = DocumentFIStatusManager.StatusHeader.Pendiente;
                txtStatusDocNew.Text = _statusDoc.ToString();
                new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, 0);
                _facturaIdStruct.IdFactura = 0;
                _facturaIdStruct.IdFacturaX = 0;
                AccionSegunEstado();
            }
        }
        private void btnContabilizar_Click(object sender, EventArgs e)
        {
            if (ValidaOKContabilizar() == false)
                return;

            var dr = MessageBox.Show(
                $@"Confirma la CONTABILIZACION del Documento en Pantalla por el IMPORTE TOTAL de {txtImporteFinalNew.Text} ?",
                @"Contabilizacion de Documento FI", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.No)
                return;

            var factu = new CustomerInvoice("RFAC1", _facturaIdStruct.IdFactura);
            factu.UpdateHeaderValues(cBrutoInicial.GetValueDecimal, cDescuento.GetValueDecimal,
                cBaseImponible.GetValueDecimal, cAlicuotaIIBB.GetValueDecimal, cPercIIBB.GetValueDecimal,
                txtNewTC.ValueD, cImporteNetoFinal.GetValueDecimal, cIva21.GetValueDecimal);


            var obj = new ContaCustomerFromInvoice("FAC1", _facturaIdStruct.IdFactura);
            var conta1 = obj.ManageContabilizacionCompleta();
            txtNas.Text = conta1.NumeroAsientoIdDocu.ToString();

            MessageBox.Show(@"Se Ha Contabilizado CORRECTAMENTE el Documento", @"Contabilizacion de Documento OK",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            factu = new CustomerInvoice("FAC1", _facturaIdStruct.IdFactura);
            txtNumeroFactNuevo.Text = factu.GetNumeroDocumentoCompleto();
            txtStatusDocNew.Text = factu.GetStatusDocumento();
            _statusDoc = new DocumentFIStatusManager().MapStatusHeaderFromText(txtStatusDocNew.Text);
            if (txtLxNew.Text == @"L1")
            {
                new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _facturaIdStruct.IdFactura,
                    txtNumeroFactNuevo.Text, true); //sigue marcando como PENDIENTE DE FACTURACION hasta aprobar CAE.
            }
            else
            {
                new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _facturaIdStruct.IdFactura,
                    txtNumeroFactNuevo.Text, false); //marca como NO PENDIENTE DE FACTURACION
            }
            AccionSegunEstado();
        }
        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {

        }
        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {

        }
        private void btnCancelarContabilizacion_Click(object sender, EventArgs e)
        {

        }
        private void btnSolicitarCAE_Click(object sender, EventArgs e)
        {
            var x = new CustomerInvoice(txtLxNew.Text, _facturaIdStruct.IdFactura);
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
                        $@"Confirma la Solicitud de CAE a AFIP?",
                        @"Solicitud de CAE - Afip", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                txtNumeroFactNuevo.Text = resultado.PuntoVenta.PadLeft(4, '0') + @"-" +
                                          resultado.ComprobanteHasta.PadLeft(8, '0');

                fe.UpdateDataAfterDocumentNumberGetFromAFIP(_facturaIdStruct.IdFactura,
                    resultado.PuntoVenta.PadLeft(4, '0'),
                    resultado.ComprobanteHasta.PadLeft(8, '0'), resultado.CAE, resultado.VencimientoCAE,
                    Convert.ToInt32(txtNas.Text));

                new RemitoHeaderManager().UpdateIdFacturaAsociada(_idRemito, _facturaIdStruct.IdFactura,
                    txtNumeroFactNuevo.Text, false);

                if (cPercIIBB.GetValueDecimal != 0)
                {
                    var idfx = _facturaIdStruct.IdFacturaX;
                    new PercepcionesManager().AddFacturaPercepcion((int)idfx);
                }

                _statusDoc = DocumentFIStatusManager.StatusHeader.Aprobada;
                txtStatusDocNew.Text = _statusDoc.ToString();
                AccionSegunEstado();
            }
            else
            {
                MessageBox.Show(
                    $@"Ha Ocurrido un error al solicitar el CAE * observacion >> {resultado.Wsfev1Observacion}",
                    @"Error en SOLICITUD DE CAE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _statusDoc = DocumentFIStatusManager.StatusHeader.PendienteCAE;
                txtStatusDocNew.Text = _statusDoc.ToString();
                AccionSegunEstado();
            }
        }
        private void btnGenerarNewRemito_Click(object sender, EventArgs e)
        {
            using (var f = new FrmSD22RefactuRemito(_idRemito))
            {
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _idRemitoNew = f._idRemitoNew;
                    txtIdRemitoNew.Text = f._idRemitoNew.ToString();
                    txtNumeroRemitoNew.Text = f.numeroRemitoNew;
                }

                if (_idRemitoNew != 0)
                {
                    RecalculaPrecioConVariacionBaseImponible();
                }
            }
        }
        private void RecalculaPrecioConVariacionBaseImponible()
        {
            if (txtLxNew.Text != @"L1")
            {
                //remover impuestos
                cAlicuotaIIBB.SetValue = 0;
                btnARBA.Enabled = false;
                RetiraImpuestos();

            }
            else
            {
                //agregar impuestos
                cAlicuotaIIBB.SetValue = GetIIBBPercepcion(cFechaFactuNew.Value.Value, txtCuit.Text);
                btnARBA.Enabled = true;
                AgregaImpuestos();
            }
            RecalculaTotalesMemoria(false);
        }

        private void RetiraImpuestos()
        {
            foreach (var i in _fI)
            {
                i.IVA21 = false;
            }
        }

        private void AgregaImpuestos()
        {
            foreach (var i in _fI)
            {
                i.IVA21 = true;
            }
        }
    }
}
