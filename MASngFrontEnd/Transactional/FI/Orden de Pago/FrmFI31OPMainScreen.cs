using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.Imputacion;
using Tecser.Business.Transactional.FI.OrdenPago;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI31OPMainScreen : Form
    {

        public FrmFI31OPMainScreen(int numeroOP)
        {
            //este constructor es para edicion/visualizacion
            _numeroOP = numeroOP;
            _modo = 2;
            _op = new OrdenPagoManageDatos(_numeroOP);
            InitializeComponent();
        }
        public FrmFI31OPMainScreen(int vendorId, int modo)
        {
            //este constructor es para creacion
            _vendorId = vendorId;
            _modo = 1;
            _numeroOP = 0;
            _op = new OrdenPagoManageDatos();
            InitializeComponent();
            _estadoOP = OrdenPagoStatus.StatusOP.Inicial;
        }

        //----------------------------------------------------------------------------------------
        private readonly int _modo;
        private int _numeroOP;
        private int _vendorId;
        private string _tipoLx;
        private OrdenPagoStatus.StatusOP _estadoOP;
        private List<T0203_CTACTE_PROV> _listaFacturasPendientePago;
        private OrdenPagoManageDatos _op;

        private void AccionSegunEstadoOP()
        {
            dgvFacturasPendientes.Enabled = false;
            dgvFacturasAPagar.Enabled = false;
            dgvItemsPago.Enabled = false;
            btnAddCheque.Enabled = false;
            btnAddOtraCuenta.Enabled = false;
            btnCancel.Enabled = false;
            btnGenerar.Enabled = false;
            btnSetFinalizada.Enabled = false;
            btnImprimirOrdenPago.Enabled = false;
            btnL1.Enabled = false;
            btnL2.Enabled = false;
            btnModificaRetenciones.Enabled = false;
            btnRetenciones.Enabled = false;
            dtpFechaOP.Enabled = false;
            txtTipoCambio.ReadOnly = true;
            cmbMoneda.Enabled = false;
            cmbMoneda.Text = @"ARS";
            txtComentariosOP.ReadOnly = true;
            btnCaluclarDias.Enabled = false;

            switch (_estadoOP)
            {
                case OrdenPagoStatus.StatusOP.Inicial:
                    dgvFacturasPendientes.Enabled = true;
                    dgvFacturasAPagar.Enabled = true;
                    dgvItemsPago.Enabled = true;
                    dtpFechaOP.Enabled = true;
                    txtTipoCambio.ReadOnly = false;
                    txtComentariosOP.ReadOnly = false;
                    btnL1.Enabled = true;
                    btnL2.Enabled = true;
                    break;
                case OrdenPagoStatus.StatusOP.Proceso:
                    dgvFacturasPendientes.Enabled = true;
                    dgvFacturasAPagar.Enabled = true;
                    dgvItemsPago.Enabled = true;
                    dtpFechaOP.Enabled = true;
                    txtTipoCambio.ReadOnly = false;
                    txtComentariosOP.ReadOnly = false;
                    btnModificaRetenciones.Enabled = true;
                    btnAddCheque.Enabled = true;
                    btnAddOtraCuenta.Enabled = true;
                    btnGenerar.Enabled = true;
                    btnCaluclarDias.Enabled = true;
                    break;
                case OrdenPagoStatus.StatusOP.Generada:
                    btnSetFinalizada.Enabled = true;
                    btnImprimirOrdenPago.Enabled = true;
                    btnCancel.Enabled = true;
                    btnCaluclarDias.Enabled = true;
                    break;
                case OrdenPagoStatus.StatusOP.Finalizada:
                    btnImprimirOrdenPago.Enabled = true;
                    btnCancel.Enabled = true;
                    break;
                case OrdenPagoStatus.StatusOP.Cancelada:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void ConfiguracionInicial()
        {
            dgvFacturasPendientes.DataSource = t0203CTACTEPROVBindingSource;
            dgvFacturasAPagar.DataSource = t0213OPFACTBindingSource;
            dgvItemsPago.DataSource = t0212OPITEMBindingSource;
        }
        private void RefreshDgvFacturasPendientePago()
        {
            //DGV1 - Facturas Pendientes de Pago
            _listaFacturasPendientePago = string.IsNullOrEmpty(_tipoLx)
                ? new CtaCteVendorDetalleDocumentos().DetalleFacturasPendientePago(_vendorId).ToList()
                : new CtaCteVendorDetalleDocumentos().DetalleFacturasPendientePago(_vendorId, _tipoLx).ToList();

            if (_numeroOP > 0)
            {
                foreach (var i in _op.GetDatosFacturasPagandoFromDb())
                {
                    var ls = _listaFacturasPendientePago.Find(c => c.IDCTACTE == i.IdCtaCte.Value);
                    _listaFacturasPendientePago.Remove(ls);
                }
            }
            t0203CTACTEPROVBindingSource.DataSource = _listaFacturasPendientePago.ToList();
        }
        public void RefreshDgvItemsdePago()
        {
            var lista = _op.GetDatosItemsPagoFromDb().ToList();
            t0212OPITEMBindingSource.DataSource = lista;
            txtCantidadItemsPago.Text = lista.Count.ToString();
        }
        public void RefreshDgvFacturasEnOP()
        {
            var lista = _op.GetDatosFacturasPagandoFromDb_new().ToList();
            t0213OPFACTBindingSource.DataSource = lista;
            txtNumeroDocumentosOP.Text = lista.Count.ToString();
        }
        private void FrmOrdenPagoMain_Load(object sender, EventArgs e)
        {
            ConfiguracionInicial();
            if (_modo == 2)
            {
                //modo visualizacion/edicion               
                CargaDatosOPExistente();
                LoadOrdenPagoVendorData();
                RefreshDgvFacturasPendientePago();
                RefreshDgvFacturasEnOP();
                RefreshDgvItemsdePago();
            }
            else
            {
                //modo creacion
                _estadoOP = OrdenPagoStatus.StatusOP.Inicial;
                txtEstadoOP.Text = _estadoOP.ToString();
                txtEstadoOP.BackColor = Color.Yellow;
                txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("n2");
                LoadOrdenPagoVendorData();
                RefreshDgvFacturasPendientePago();
            }
            AccionSegunEstadoOP();
        }
        private void LoadOrdenPagoVendorData()
        {
            var vendor = new VendorManager().GetSpecificVendor(_vendorId);
            txtRazonSocial.Text = vendor.prov_rsocial;
            txtIdProveddor.Text = _vendorId.ToString();
            txtTipoProveedor.Text = vendor.TIPO;
            txtNumeroCuit.Text = vendor.NTAX1;
        }
        private string SetFormatOPNumber()
        {
            if (_tipoLx == "L1")
            {
                string numeroOPCompleto = _numeroOP.ToString("D12");
                return numeroOPCompleto.Substring(0, 4) + "-" + numeroOPCompleto.Substring(4);
            }
            else
            {

            }
            return _numeroOP.ToString();
        }
        private void InicializaNuevaOrdenPago()
        {
            _numeroOP = new OPCreateAndUpdateData().CreaOPHeaderInicial(_vendorId, dtpFechaOP.Value, _tipoLx,
                cmbMoneda.Text, Convert.ToDecimal(txtTipoCambio.Text));
            txtNumeroOP.Text = SetFormatOPNumber();
            txtTipoOp.Text = _tipoLx;
            btnL1.Enabled = false;
            btnL2.Enabled = false;
            _estadoOP = OrdenPagoStatus.StatusOP.Proceso;
            txtEstadoOP.Text = OrdenPagoStatus.StatusOP.Proceso.ToString().ToUpper();
            txtEstadoOP.BackColor = OrdenPagoStatus.GetColorBackForStatus(OrdenPagoStatus.StatusOP.Proceso);

            if (_tipoLx == "L1")
            {
                // Set cursor as hourglass
                Cursor.Current = Cursors.WaitCursor;
                txtAlicuotaIIBB.Text =
                    new Retenciones().GetAlicuotaRetencionIIBB(txtNumeroCuit.Text,
                        new PeriodoConversion().GetPeriodo(dtpFechaOP.Value.Date))
                        .ToString(CultureInfo.InvariantCulture);

                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
            else
            {
                txtAlicuotaIIBB.Text = 0.ToString("N4");
                txtAlicuotaGS.Text = 0.ToString("N4");
            }
            _op = new OrdenPagoManageDatos(_numeroOP);

            if (_op.CheckIfOPCredAvailable(_vendorId, _tipoLx))
            {
                MessageBox.Show(
                    @"Existe Credito sin Imputar para este Proveedor.- Para asegurar el perfecto funcionamiento se aconseja AGREGAR todo el Saldo SIN IMPUTAR (OPCRED) Validado a esta OP",
                    @"Credito Sin Imputar Disponible [OPCRED]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private void AddDocumentToOp(int idctacte, string tipoDoc, string tipoLx)
        {
            if (string.IsNullOrEmpty(txtNumeroOP.Text))
            {
                _tipoLx = tipoLx; //setea el tipo de OP
                txtTipoOp.Text = _tipoLx;
                if (OPCanBeInitialized())
                {
                    InicializaNuevaOrdenPago();
                    AccionSegunEstadoOP();
                }
                else
                {
                    return;
                }

            }

            if (tipoDoc == "OP")
            {
                _op.AddOPCred(idctacte);

                new OPImputaFacturas(_numeroOP).ImputaFacturasOP();
                RefreshDgvItemsdePago();
            }
            else if (tipoDoc.Contains("NC"))
            {
                _op.AddNcCred(idctacte);
                new OPImputaFacturas(_numeroOP).ImputaFacturasOP();
                RefreshDgvItemsdePago();
            }
            else
            {
                _op.AddFacturaAPagar(idctacte);
                if (_tipoLx == "L1")
                {
                    if (string.IsNullOrEmpty(txtAlicuotaGS.Text))
                        txtAlicuotaGS.Text = 0.ToString("N2");
                    if (string.IsNullOrEmpty(txtAlicuotaIIBB.Text))
                        txtAlicuotaIIBB.Text = 0.ToString("N2");

                    if (txtAlicuotaIIBB.Text == 0.ToString("N2"))
                    {
                        // Set cursor as hourglass
                        Cursor.Current = Cursors.WaitCursor;
                        var retencionIIBB = new Retenciones().GetAlicuotaRetencionIIBB(txtNumeroCuit.Text,
                            new PeriodoConversion().GetPeriodo(dtpFechaOP.Value.Date))
                            .ToString(CultureInfo.InvariantCulture);
                        // Set cursor as default arrow
                        Cursor.Current = Cursors.Default;

                        var data = Convert.ToDecimal(retencionIIBB);
                        if (data != 0)
                        {
                            var resp =
                                MessageBox.Show(
                                    @"Desea calcular la retencion con el nuevo valor de Alicuota obtenido?",
                                    @"Recalculo de Alicuota", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (resp == DialogResult.Yes)
                            {
                                txtAlicuotaIIBB.Text = retencionIIBB;
                            }
                        }
                    }
                    var retencionAddede = new MngRetencionesFacturasProv().ManageCalculoRetenciones_AddFactura(
                        _numeroOP, idctacte, 100000, 0, Convert.ToDecimal(txtAlicuotaIIBB.Text), 0);
                    if (!retencionAddede)
                    {
                        MessageBox.Show(
                            @"Para su informacion esta factura tiene retenciones calculadas en otra Orden de Pago",
                            @"Informacion sobre Retenciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    new OPImputaFacturas(_numeroOP).ImputaFacturasOP();
                }
            }
            RefreshDgvFacturasPendientePago();
            RefreshDgvFacturasEnOP();
            RecalculaTotalesOP();
        }
        private bool OPCanBeInitialized()
        {
            if (_modo != 1)
                return false;

            if (_estadoOP != OrdenPagoStatus.StatusOP.Inicial)
            {
                MessageBox.Show(@"El Estado de la Orden de Pago no permite CREACION DE ORDEN DE PAGO",
                    @"Error en Comprobacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtIdProveddor.Text))
                return false;

            if (DateTime.Today.AddDays(15) < dtpFechaOP.Value)
            {
                MessageBox.Show(@"No se pueden crear OP con fecha mayor a 15 dias de la fecha actual",
                    @"Error en Comprobacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (DateTime.Today.AddDays(-45) > dtpFechaOP.Value)
            {
                var x = MessageBox.Show(@"La fecha de la OP es anterior a 45 dias lo que podria ser un error. Desea continuar de todas formas?", @"Error en Comprobacion de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return false;
            }

            if (string.IsNullOrEmpty(txtTipoOp.Text))
            {
                MessageBox.Show(@"No se ha definido Aun el tipo de OP a crear. Seleccione L1 o L2",
                    @"Error en Comprobacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(cmbMoneda.Text))
            {
                MessageBox.Show(@"No se ha definido una moneda de Orden de Pago (Seleccione ARS)",
                    @"Error en Comprobacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtTipoCambio.Text))
            {
                MessageBox.Show(@"No se ha definido un tipo de cambio (TC/Exchange Rate)",
                    @"Error en Comprobacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Agregado de Facturas Pendientes de Pago a una OP
        /// Da de alta la OP si la misma no existe aun
        /// </summary>
        private void dgvFacturasPendientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvFacturasPendientes[e.ColumnIndex, e.RowIndex].Value.ToString();
                var tipoDoc = dgvFacturasPendientes[1, e.RowIndex].Value.ToString();
                var tipoLx = dgvFacturasPendientes[7, e.RowIndex].Value.ToString();
                var numfact = dgvFacturasPendientes[2, e.RowIndex];
                var valor = Convert.ToDecimal(dgvFacturasPendientes[6, e.RowIndex].Value);
                switch (cellValue)
                {
                    case "AGREGAR":
                        {
                            DialogResult resp;
                            decimal importeCreditoOP = 0;
                            switch (tipoDoc)
                            {
                                case "NCA":
                                    //Nota de Credito
                                    importeCreditoOP = Convert.ToDecimal(dgvFacturasPendientes[6, e.RowIndex].Value);
                                    resp =
                                        MessageBox.Show(
                                            $"Confirma el Agregado de CREDITO DISPONIBLE ** NOTA DE CREDITO # {numfact.Value} por importe {Math.Abs(importeCreditoOP).ToString("C2")}?",
                                            @"Confirmacion", MessageBoxButtons.YesNo);
                                    break;

                                case "OP": //Credito OP
                                    importeCreditoOP = Convert.ToDecimal(dgvFacturasPendientes[6, e.RowIndex].Value);

                                    resp =
                                        MessageBox.Show(
                                            $"Confirma el Agregado de CREDITO DISPONIBLE OP# {numfact.Value} por importe {Math.Abs(importeCreditoOP).ToString("C2")}?",
                                            @"Confirmacion", MessageBoxButtons.YesNo);
                                    break;
                                default:
                                    var ImporteX = valor;
                                    resp =
                                        MessageBox.Show(
                                            $"Confirma agregar FACTURA {numfact.Value} por importe {valor.ToString("C2")}",
                                            @"Agregar Documento a OP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    break;
                            }

                            var idCtaCte = Convert.ToInt32(dgvFacturasPendientes[0, e.RowIndex].Value);
                            if (resp == DialogResult.No)
                                return;
                            // Set cursor as hourglass
                            Cursor.Current = Cursors.WaitCursor;
                            AddDocumentToOp(idCtaCte, tipoDoc, tipoLx);
                            // Set cursor as default arrow
                            Cursor.Current = Cursors.Default;
                            break;
                        }

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
        private void CargaDatosOPExistente()
        {
            var headerData = _op.Header;
            _vendorId = headerData.PROV_ID;

            dtpFechaOP.Value = headerData.OPFECHA.Value;
            txtTipoCambio.Text = headerData.TC.Value.ToString("n2");
            cmbMoneda.SelectedValue = headerData.MON_OP;
            if (headerData.MON_OP == null)
                cmbMoneda.SelectedValue = "ARS";
            txtComentariosOP.Text = headerData.OP_COM;
            txtNumeroOP.Text = _numeroOP.ToString();
            _estadoOP = OrdenPagoStatus.MapStatusFromText(headerData.OP_STATUS);
            txtEstadoOP.Text = _estadoOP.ToString();
            txtEstadoOP.BackColor = OrdenPagoStatus.GetColorBackForStatus(_estadoOP);
            txtTipoOp.Text = headerData.TIPO;
            _tipoLx = txtTipoOp.Text;
            if (headerData.NAS != null)
                txtNumeroAsiento.Text = headerData.NAS.Value.ToString();
            RecalculaTotalesOP();
        }

        //Elimina CostItems de Pago a una OP
        private void dgvItemsPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvItemsPago[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (cellValue == "DEL")
                {
                    //Eliminar Item de Pago de la OP
                    DialogResult dialogResult =
                        MessageBox.Show(
                            $"Desea Remover Item CUENTA # {dgvItemsPago[0, e.RowIndex].Value} por importe $ {dgvItemsPago[2, e.RowIndex].Value} ?", @"Confirmacion",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (_op.RemoveItemOrdenPago(Convert.ToInt32(dgvItemsPago[7, e.RowIndex].Value)) == true)
                        {
                            RefreshDgvItemsdePago();
                            new OPImputaFacturas(_numeroOP).ImputaFacturasOP();
                            RefreshDgvFacturasEnOP();
                            RefreshDgvFacturasPendientePago();
                            RecalculaTotalesOP();
                        }
                        else
                        {
                            MessageBox.Show(@"Error al Remover el Item de Pago de la OP", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }
        private void dgvFacturasAPagar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = senderGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                switch (cellValue)
                {
                    case "DEL":
                        //Eliminar Factura de la OP
                        DialogResult dialogResult = MessageBox.Show(String.Format("Desea Remover documento # {0} ?", dgvFacturasAPagar[2, e.RowIndex].Value), @"Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (_op.RemoveFacturaAPagarOP(Convert.ToInt32(dgvFacturasAPagar[0, e.RowIndex].Value)) == true)
                            {
                                //new MngRetencionesFacturasProv().ActualizaImporteRetencionesHeaderOPFromT0405(_numeroOP);
                                ///RecalculaDgvFacturasAPagar(); revisar esto
                            }
                            else
                            {
                                MessageBox.Show(@"Error al Remover la Factura");
                            }
                        }
                        new OPImputaFacturas(_numeroOP).ImputaFacturasOP();
                        RefreshDgvFacturasEnOP();
                        RefreshDgvFacturasPendientePago();
                        RecalculaTotalesOP();

                        //_facturasOP = new OrdenPagoManageDatos().GetDatosFacturasPagandoFromDb();
                        //dgvFacturasAPagar.DataSource = _facturasOP;

                        //_itemOp = new OrdenPagoManageDatos().GetDatosItemsPagoFromDb();
                        //dgvItemsPago.DataSource = _itemOp;
                        //RecalculaTotalesOP();


                        //remove
                        break;
                    case "VER": //other
                        MessageBox.Show(@"Proximamente se visualizaran los detalles de las facturas");
                        break;
                    default:

                        break;
                        ;
                }
            }
        }
        private void btnRetenciones_Click(object sender, EventArgs e)
        {
            var f2 = new FrmCalculoRetenciones(_numeroOP, _vendorId);
            f2.Show();
        }
        public void RecalculaTotalesOP()
        {
            var opImportes = new OPImportesManagement(_numeroOP);
            txtTotalFacturasOP.Text = opImportes.GetImporteFacturasAPagar().ToString("C2");
            txtValoresOP.Text = (opImportes.GetImporteCheques() + opImportes.GetImporteARS() + opImportes.GetImporteUSD()).ToString("C2");
            txtCreditoOP.Text = opImportes.GetImporteCreditos().ToString("C2");
            txtRetencionesIIBB.Text = opImportes.GetImporteRetencionesIIBB_FromHeaderOP().ToString("C2");
            txtRetencionesGS.Text = opImportes.GetImporteRetencionesGS_FromHeaderOP().ToString("C2");
            txtOtros.Text = opImportes.GetImporteOtros().ToString("C2");
            txtTotalOP.Text = opImportes.GetImporteOPTotal().ToString("C2");
            txtImporteOrdenPagoFinal.Text = opImportes.GetImporteOrdenPagoFinal().ToString("C2"); //new!

            var saldo = opImportes.GetImporteOPTotal() - opImportes.GetImporteFacturasAPagar();
            if (saldo > 0)
            {
                txtDifPendiente.Text = 0.ToString("C2");
                txtDifFavorTecser.Text = saldo.ToString("C2");
            }
            else
            {
                txtDifPendiente.Text = (saldo * -1).ToString("C2");
                txtDifFavorTecser.Text = 0.ToString("C2");
            }

            txtTotalImporteARS.Text = opImportes.GetImporteARS().ToString("C2");
            txtTotalImporteCheques.Text = opImportes.GetImporteCheques().ToString("C2");
            txtTotalImporteCreditos.Text = opImportes.GetImporteCreditos().ToString("C2");
            txtTotalImporteOtros.Text = opImportes.GetImporteOtros().ToString("C2");
            txtTotalmporteTotal.Text = opImportes.GetImporteTotalItemsPago_ExcluidoRetenciones().ToString("C2");
        }
        private void btnModificaRetenciones_Click(object sender, EventArgs e)
        {
            var f2 = new FrmFI33OpImputacionRetenciones(this, _numeroOP);
            {
            }
            f2.Show();
        }
        private void btnAddCheque_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroOP.Text))
            {
                if (string.IsNullOrEmpty(txtTipoOp.Text))
                {
                    MessageBox.Show(@"Debe Seleccionar un tipo OP# [L1/L2]", @"Seleccion tipo OP", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                if (OPCanBeInitialized())
                {
                    InicializaNuevaOrdenPago();
                    AccionSegunEstadoOP();
                }
                return;
            }

            using (var f2 = new FrmFI34BusquedaCheques(this, txtTipoOp.Text, "OP", _numeroOP))
            {
                DialogResult dr = f2.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    RefreshDgvFacturasEnOP();
                }
            }
        }
        private void btnAddOtraCuenta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroOP.Text))
            {
                if (string.IsNullOrEmpty(txtTipoOp.Text))
                {
                    MessageBox.Show(@"Debe Seleccionar un tipo OP# [L1/L2]", @"Seleccion tipo OP", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                if (OPCanBeInitialized())
                {
                    InicializaNuevaOrdenPago();
                    AccionSegunEstadoOP();
                }
                return;
            }
            using (var f0 = new FrmFI32OpAddItemPago(this, _numeroOP, txtTipoOp.Text))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    RefreshDgvFacturasEnOP();
                }
            }
        }
        private void btnL1_Click(object sender, EventArgs e)
        {
            txtTipoOp.Text = @"L1";
            _tipoLx = @"L1";
            dgvFacturasPendientes.DataSource = new VendorAccountManager().DetalleFacturasPendientePago(_vendorId, "L1");
            if (_estadoOP == OrdenPagoStatus.StatusOP.Inicial)
            {
                btnAddCheque.Enabled = true;
                btnAddOtraCuenta.Enabled = true;
            }
        }
        private void btnL2_Click(object sender, EventArgs e)
        {
            txtTipoOp.Text = @"L2";
            _tipoLx = @"L2";
            dgvFacturasPendientes.DataSource = new VendorAccountManager().DetalleFacturasPendientePago(_vendorId, "L2");
            if (_estadoOP == OrdenPagoStatus.StatusOP.Inicial)
            {
                btnAddCheque.Enabled = true;
                btnAddOtraCuenta.Enabled = true;
            }
        }
        private bool CheckAllowToGenerate()
        {

            if (string.IsNullOrEmpty(txtCantidadItemsPago.Text))
            {
                txtCantidadItemsPago.Text = "0";
            }

            if (string.IsNullOrEmpty(txtNumeroDocumentosOP.Text))
            {
                txtNumeroDocumentosOP.Text = "0";
            }

            var numItemsPago = Convert.ToInt32(txtCantidadItemsPago.Text);
            var numDocumentos = Convert.ToInt32(txtNumeroDocumentosOP.Text);
            var importeOP = FormatAndConversions.CCurrencyADecimal(txtTotalOP.Text);

            var f = new FormatAndConversions();

            if (numItemsPago == 0 && numDocumentos == 0)
            {
                MessageBox.Show(@"La Orden de Pago no contiene ningun Item para poder generarse", @"OP Sin CostItems",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (numDocumentos == 0 && numItemsPago > 0)
            {
                var resp =
                    MessageBox.Show(
                        @"Confirma la Generacion de una Orden de Pago sin Documentos Asociados [OP Pago a Cuenta]",
                        @"Orden de Pago a Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return false;
            }

            if (f.GetCurrencyFormat_Decimal(txtCreditoOP.Text) > 0 && numDocumentos == 0)
            {
                MessageBox.Show(@"Para Utilizar los Creditos OP# Debe Agregar Alguna Factura", @"Generacion OP",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_op.ValidaSaldosFacturaAntesGenerar() == false)
            {
                MessageBox.Show(
                    @"Debe remover todos los CostItems y volver a armar la OP porque alguna/s Facturas modificaron su Saldo Pendiente de Pago",
                    @"Diferencia de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if (_op.ValidaOPCredDisponibleAntesGenerar() == false)
            //{
            //    MessageBox.Show(
            //        @"Debe remover los OPCRED y volver a Agregarlos porque algun credito ha modificado su Saldo Pendiente de Pago",
            //        @"Diferencia de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            if (_op.CheckifAllChequesAreAvailable() == false)
            {
                MessageBox.Show(
                    @"Oppps... Debe remover los Cheques y volver a Agregarlos porque algun Cheque ya no se encuentre disponible",
                    @"Diferencia de Saldos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            _op = new OrdenPagoManageDatos(_numeroOP);

            if (_op.CheckIfOPCredAvailable(_vendorId, _tipoLx) &&
                FormatAndConversions.CCurrencyADecimal(txtTotalImporteCreditos.Text) == 0)
            {
                MessageBox.Show(
                    @"Existe Credito sin Imputar para este Proveedor.- Para asegurar el perfecto funcionamiento se aconseja AGREGAR todo el Saldo SIN IMPUTAR (OPCRED) Validado a esta OP",
                    @"Credito Sin Imputar Disponible [OPCRED]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var resp = MessageBox.Show(
                $@"Confirma Generar Orden de Pago # {txtNumeroOP.Text} por importe {txtImporteOrdenPagoFinal.Text} ?",
                @"Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                if (CheckAllowToGenerate() == false)
                    return;

                _op.UpdateValuesHeader(FormatAndConversions.CCurrencyADecimal(txtImporteOrdenPagoFinal.Text),
                    FormatAndConversions.CCurrencyADecimal(txtValoresOP.Text) +
                    FormatAndConversions.CCurrencyADecimal(txtOtros.Text),
                    FormatAndConversions.CCurrencyADecimal(txtTotalImporteCreditos.Text),
                    FormatAndConversions.CCurrencyADecimal(txtRetencionesGS.Text),
                    FormatAndConversions.CCurrencyADecimal(txtRetencionesIIBB.Text),
                    FormatAndConversions.CCurrencyADecimal(txtDifFavorTecser.Text), 0,
                    txtComentariosOP.Text);

                if (_op.Header.IMP_OP > 0)
                {
                    var asientoN = new AsientoOrdenPago(_numeroOP, "OPX");
                    var resultado = asientoN.GeneraAsientoFromOrdenPago();

                    if (resultado.IdDocu > 0)
                    {
                        txtNumeroAsiento.Text = resultado.IdDocu.ToString();
                        txtNumeroAsiento.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        MessageBox.Show(@"Ha ocurrido un error al generar el Asiento Contable", @"Error Asiento",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNumeroAsiento.BackColor = Color.Red;
                        txtNumeroAsiento.Text = @"ERR";
                    }

                    _op.SetStatusContabilizado(resultado.IdDocu);
                }
                else
                {
                    _op.SetStatusContabilizado(-1); //no hizo asiento porque fue solo imputacion
                }

                txtEstadoOP.Text = OrdenPagoStatus.StatusOP.Generada.ToString();
                _estadoOP = OrdenPagoStatus.StatusOP.Generada;
                _op.GeneraSubdiario();
                _op.ActualizaCuentasCorrientes();
                _op.RegistraChequesEmitidos(); //no se registra en REG pero se registra en Cheques Emitidos T0159
                new ManageVendorImputacionDocumentos().GeneraImputacionDesdeOP(_numeroOP);
                MessageBox.Show($@"Se ha generado correctamente la orden de pago # {_numeroOP}", @"Orden de Pago",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var stat = new EstadisticasPagoOP();
                txtDiasPPDoc.Text = stat.DiasPagoFactura(_numeroOP, true).ToString("N");
                txtDiasPPItems.Text = stat.DiasPPItemsPagoDesdeFechaOP(_numeroOP, true).ToString("N");
                decimal importeOP = FormatAndConversions.CCurrencyADecimal(txtImporteOrdenPagoFinal.Text);
                decimal importeDocs = FormatAndConversions.CCurrencyADecimal(txtTotalFacturasOP.Text);

                if (importeDocs!=0)
                    txtCoberturaOP.Text = (importeOP / importeDocs).ToString("P2");
                AccionSegunEstadoOP();
            }
        }
        private void btnImprimirOrdenPago_Click(object sender, EventArgs e)
        {
            var report = new RpvOrdePago(_numeroOP);
            report.Show();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(@"Desea Cancelar esta orden de Pago?", @"Orden de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            var cancela = new CancelaOrdenPago(_numeroOP).Cancela();

            if (cancela)
            {
                MessageBox.Show(@"Cancelacion Exitosa!");
                _estadoOP = OrdenPagoStatus.StatusOP.Cancelada;
                txtEstadoOP.Text = _estadoOP.ToString();
                AccionSegunEstadoOP();
            }
        }
        private void btnSalirOP_Click(object sender, EventArgs e)
        {
            if (_estadoOP == OrdenPagoStatus.StatusOP.Proceso)
            {
                _op.UpdateValuesHeader(FormatAndConversions.CCurrencyADecimal(txtImporteOrdenPagoFinal.Text),
                    FormatAndConversions.CCurrencyADecimal(txtValoresOP.Text),
                    FormatAndConversions.CCurrencyADecimal(txtTotalImporteCreditos.Text),
                    FormatAndConversions.CCurrencyADecimal(txtRetencionesGS.Text),
                    FormatAndConversions.CCurrencyADecimal(txtRetencionesIIBB.Text),
                    FormatAndConversions.CCurrencyADecimal(txtDifFavorTecser.Text), 0,
                    txtComentariosOP.Text);
            }
            this.Close();
        }
        private void btnSetFinalizada_Click(object sender, EventArgs e)
        {
            _op.SetStatusFinalizado();
            txtEstadoOP.Text = OrdenPagoStatus.StatusOP.Finalizada.ToString();
            _estadoOP = OrdenPagoStatus.StatusOP.Finalizada;
            AccionSegunEstadoOP();
        }


        private void txtTipoCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stat = new EstadisticasPagoOP();
            txtDiasPPDoc.Text = stat.DiasPagoFactura(_numeroOP, false).ToString("N0");
            txtDiasPPItems.Text = stat.DiasPPItemsPagoDesdeFechaOP(_numeroOP, false).ToString("N0");
            decimal importeOP = FormatAndConversions.CCurrencyADecimal(txtImporteOrdenPagoFinal.Text);
            decimal importeDocs = FormatAndConversions.CCurrencyADecimal(txtTotalFacturasOP.Text);
            txtCoberturaOP.Text = (importeOP / importeDocs).ToString("P2");
        }


        //'proceso GN?
        //'Actualiza Saldos Proveedores y Datos en 203/204
        //SetActualizaHeaderOP_Fin (AH.NASX1)
        //ActualizaSaldosProveedores_DesdeOP (Me.txtNumeroOP)
        //'Actualiza Header Orden Pago

        //Me.cmdGenerarOrdenDePago.Enabled = False
        //Me.txtEstadoOrdenPago = "GENERADA"
        //MsgBox "Orden de Pago Generado Correctamente!", vbInformation
    }
}
