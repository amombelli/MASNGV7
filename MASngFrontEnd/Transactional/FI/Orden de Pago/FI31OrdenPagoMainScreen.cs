using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MasterData.Vendor_Master;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.OrdenPago;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FI31OrdenPagoMainScreen : Form
    {
        private int _numeroOP;
        private readonly int _mode;
        private int _idVendor;
        private string _tipoLx;
        private OrdenPagoCreateNew _xop;
        private bool _creditosCargados;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        
        //Constructores
        public FI31OrdenPagoMainScreen(int idVendor)
        {
            _idVendor = idVendor;
            _xop = new OrdenPagoCreateNew(_idVendor, "L0");
            _numeroOP = -1;
            _mode = 1;
            _creditosCargados = false;
            InitializeComponent();
        }
        public FI31OrdenPagoMainScreen(int numeroOp, int mode)
        {
            _numeroOP = numeroOp;
            _mode = mode;
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        //
        private void FI31OrdenPagoMainScreen_Load(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case 1:
                    txtTipoOp.Text = null;
                    txtNumeroOP.Text = null;
                    txtEstadoOP.Text = _xop.StatusOP.ToString();
                    cmbMoneda.SelectedItem = "ARS";
                    cmbMoneda.Enabled = false;
                    txtTipodeCambio.SetValue = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                    LoadVendorData();
                    break;
                case 2:
                    //modo edicion OP
                    _xop = new OrdenPagoCreateNew(_numeroOP);
                    LoadOrdenPagoData();
                    break;
                case 3:
                    //modo visualizacion OP
                    _xop = new OrdenPagoCreateNew(_numeroOP);
                    LoadOrdenPagoData();
                    break;
            }
        }
        private void LoadOrdenPagoData()
        {
            //this.class
            _idVendor = _xop.VendorId;
            _tipoLx = _xop.TipoLx;
            _creditosCargados = false;
            //
            LoadVendorData();
            dtpFechaOP.Value = _xop.FechaOP;
            txtTipodeCambio.SetValue = _xop.TC;
            cmbMoneda.SelectedItem = _xop.Moneda;
            txtNumeroOP.Text = _numeroOP.ToString();
            txtEstadoOP.Text = _xop.StatusOP.ToString();
            txtTipoOp.Text = _xop.TipoLx;
            //
            dgv1Documentos.DataSource = new PopulateOrdenPagoStructures().PopulateFacturasInOp(_xop.FacturasOP).ToList();
            dgv2ItemsPago.DataSource = _xop.ItemsPagoOP.ToList();
            dgv3Creditos.DataSource = _xop.Creditos.ToList();
            dgv4Retenciones.DataSource = _xop.Retenciones.ToList();
            //
            bTotalDocumentos.DisplayValue = _xop.Header.ImporteFacturas;
            bTotalImputadoADocumentos.DisplayValue = _xop.Header.ImporteTotalImputado;
            bPendienteImputacionADocumentos.DisplayValue =
                bTotalDocumentos.GetValueDecimal - bTotalImputadoADocumentos.GetValueDecimal;
                
               
            //

            bTotalRetenciones.DisplayValue = _xop.Header.ImporteRetenciones;
            bTotalEfectivo.DisplayValue = _xop.Header.ImporteEfectivo;
            bTotalCheques.DisplayValue = _xop.Header.ImporteCheques;
            bTotalOtros.DisplayValue = _xop.Header.ImporteOtros;
            bTotalCreditos.DisplayValue = _xop.Header.ImporteCreditos;
            //
            MapValoresHeader();
        }
        private void SetLx(string lx,bool autocalculoAlicuota)
        {
            if (_xop.StatusOP != OrdenPagoStatus.StatusOP.Inicial) return;
            _tipoLx = lx;
            if (_tipoLx == "L1")
            {
                if (autocalculoAlicuota)
                {
                    cAlicuotaIIBB.XReadOnly = false; //calcular alicuota por sistema
                    Cursor.Current = Cursors.WaitCursor;
                    var retencionIIBB = new Retenciones().GetAlicuotaRetencionIIBB(txtNumeroCUIT.Text,
                            new PeriodoConversion().GetPeriodo(dtpFechaOP.Value.Date))
                        .ToString(CultureInfo.InvariantCulture);
                    Cursor.Current = Cursors.Default;
                    var data = Convert.ToDecimal(retencionIIBB);
                    cAlicuotaIIBB.SetValue = data;
                }
                else
                {
                    cAlicuotaIIBB.XReadOnly = false;
                }
            }
            else
            {
                cAlicuotaIIBB.XReadOnly = true;
                cAlicuotaIIBB.SetValue = 0;
            }
            txtTipoOp.Text = _tipoLx;
        }
        private void LoadVendorData()
        {
            var d = VendorMng2.GetVendor(_idVendor);
            txtRazonSocial.Text = d.RazonSocial;
            txtNumeroCUIT.Text = d.Cuit;
            //si se agregan mas campos del vendor mapear aqui
            
        }
        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMoneda.SelectedItem.ToString() == "USD")
            {
                MessageBox.Show(@"Solo permitido Orden de Pago en ARS", @"Moneda no permitida", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                cmbMoneda.SelectedItem = @"ARS";
                cmbMoneda.Enabled = false;
            }
        }
        private void BlockParamentrosHeaderOP()
        {
            if (_xop.Header == null)
            {
                //Inicializacion de header con parametros iniciales
                _xop.Moneda = cmbMoneda.SelectedItem.ToString();
                _xop.FechaOP = dtpFechaOP.Value;
                _xop.TC = txtTipodeCambio.GetValueDecimal;
                dtpFechaOP.Enabled = false;
                txtTipodeCambio.XReadOnly = true;
                cmbMoneda.Enabled = false;
                rbtnTipoLx.Enabled = false;
            }
            //ver si fuese el caso que se necesitan cambiar parametros
            //una vez que el header este defindo?
        }
        
        #region BotonesMain
        private void rbtnDocumentosPendPago_Click(object sender, EventArgs e)
        {
            if (_xop.Header == null) 
            {
                BlockParamentrosHeaderOP(); 
                //Falta determinar Lx que será realizado durante el agregado de Factura
            }
            else
            {
                //Los Parametros que se definen al agregar el primer elemento ya se han definido
            }
            using (var f = new FrmFI33DocumentosPendientesPago(_idVendor, 1, _xop.TipoLx))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    if (f.NumeroDgv == 1)
                    {
                        //Carga de Facturas a OP
                        var x=_xop.AddFacturasToOP(f.IdCtaCteSeleccion);
                        if (x == false)
                        {
                            MessageBox.Show(@"No se pudo agregar el documento porque el documento ya existe en esta OP",
                                @"Error en Alta de Documento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (_tipoLx == "L0" || _tipoLx==null) SetLx(_xop.Header.Lx, ckAutoGetAlicuotaIIBB.Checked);
                        bTotalDocumentos.DisplayValue = _xop.Header.ImporteFacturas;
                        
                        if (_creditosCargados == false)
                        {
                            //los creditos se cargan al agregar facturas 
                            _creditosCargados = true;
                            dgv3Creditos.DataSource = _xop.Creditos.ToList();
                        }
                        dgv3Creditos.DataSource = _xop.Creditos.ToList();
                        _xop.ImputacionAutomatica();
                        dgv1Documentos.DataSource = new PopulateOrdenPagoStructures().PopulateFacturasInOp(_xop.FacturasOP).ToList();
                        MapValoresHeader();
                    }
                    else
                    {
                        //Carga de Creditos a OP

                    }
                }
                else
                {

                }
            }


        }
        private void rbtnAddRetencionGanancias_Click(object sender, EventArgs e)
        {
        }
        private void rbtnAddRetencionArba_Click(object sender, EventArgs e)
        {
            if (_xop.TipoLx == "L2")
            {
                MessageBox.Show(@"Retencionens solo pueden ser agregadas en una Orden de Pago de Tipo [L1]",
                    @"Tipo LX Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_xop.Header == null)
            {
                if (_xop.TipoLx == "L0")
                {
                    var r = MessageBox.Show(@"Desea definir automaticamente esta Orden de Pago como tipo [L1]?",
                        @"Tipo LX no definido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (r == DialogResult.No)
                        return;
                    _tipoLx = "L1";
                    txtTipoOp.Text = _tipoLx;
                }
                //incializa header OP
                _xop.InicializaHeader(_idVendor,_tipoLx,dtpFechaOP.Value,cmbMoneda.SelectedItem.ToString(),txtTipodeCambio.GetValueDecimal,false);
                dtpFechaOP.Enabled = false;
                txtTipodeCambio.XReadOnly = true;
                cmbMoneda.Enabled = false;
                rbtnTipoLx.Enabled = false;
            }
            
            using (var f = new FrmFI36Retenciones(OrdenPagoCreateNew.TipoRetencion.Arba))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _xop.AddRetencion(OrdenPagoCreateNew.TipoRetencion.Arba,f.BaseImpo,f.Importe,f.Alicuota);
                    bTotalRetenciones.DisplayValue = _xop.Header.ImporteRetenciones;
                    _xop.ImputacionAutomatica();
                    dgv4Retenciones.DataSource = _xop.Retenciones.ToList();
                    dgv1Documentos.DataSource = new PopulateOrdenPagoStructures().PopulateFacturasInOp(_xop.FacturasOP).ToList();
                    dgv3Creditos.DataSource = _xop.Creditos.ToList();
                    MapValoresHeader();
                }
                else
                {

                }
            }
        }
        private void rbtnAddPesos_Click(object sender, EventArgs e)
        {
            if (!CheckHeaderNull_AddItemsPago()) return;
            using (var f = new FrmFI35AddCashToOP(txtRazonSocial.Text, "ARS", cmbMoneda.SelectedItem.ToString()))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _xop.AddImporteCashToOP(f.Importe, "ARS");
                    OperacionesAddItemsPago();
                    bTotalEfectivo.DisplayValue = bTotalEfectivo.GetValueDecimal + f.Importe;
                }
                else
                {

                }
            }
        }
        private void rbtAddUsd_Click(object sender, EventArgs e)
        {

        }
        private void rbtTransfGalicia_Click(object sender, EventArgs e)
        {

        }
        private void rbtTransfSantander_Click(object sender, EventArgs e)
        {

        }
        private void rbtTransfOtrosBancos_Click(object sender, EventArgs e)
        {

        }
        private void rbtChequesTerceros_Click(object sender, EventArgs e)
        {
            var f = new FrmFi37AddChequesToOp(_tipoLx, this, _xop.ListaIdChequesOp);
            if (f.ShowDialog() == DialogResult.OK)
            {
                //Los cheques se van agregando desde el FI37 .- 
                //No hacer nada
            }
        }
        private void rbtEmisionChequeFisico_Click(object sender, EventArgs e)
        {
            var f = new FrmFI39AddChequeEmitidoPropioToOp(this,1);
            if (f.ShowDialog() == DialogResult.OK)
            {
                //Los cheques se van agregando desde el FI39 .- 
                //No hacer nada
            }
        }
        private void rbtEmisionEcheque_Click(object sender, EventArgs e)
        {
            var f = new FrmFI39AddChequeEmitidoPropioToOp(this, 2);
            if (f.ShowDialog() == DialogResult.OK)
            {
                //Los cheques se van agregando desde el FI39 .- 
                //No hacer nada
            }
        }
        private void rbtCuentaGL_Click(object sender, EventArgs e)
        {

        }
        private void rbtCompensacionCliente_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void OperacionesAddItemsPago()
        {
            _xop.ImputacionAutomatica();
            MapValoresHeader();
            dgv2ItemsPago.DataSource = _xop.ItemsPagoOP.ToList();
            dgv1Documentos.DataSource = new PopulateOrdenPagoStructures().PopulateFacturasInOp(_xop.FacturasOP).ToList();
            dgv3Creditos.DataSource = _xop.Creditos.ToList();
        }
        private bool CheckHeaderNull_AddItemsPago()
        {
            if (_xop.Header != null) return true;
            if (_xop.TipoLx == "L0")
            {
                MessageBox.Show(@"Debe definir el tipo de la Orden de Pago [L1/L2] antes de continuar",
                    @"Seleccione el Tipo de OP [L1/L2]", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //inicializa header completo
            _xop.InicializaHeader(_idVendor, _tipoLx, dtpFechaOP.Value, cmbMoneda.SelectedItem.ToString(), txtTipodeCambio.GetValueDecimal,false);
            dtpFechaOP.Enabled = false;
            txtTipodeCambio.XReadOnly = true;
            cmbMoneda.Enabled = false;
            rbtnTipoLx.Enabled = false;
            return true;
        }
        public void AddChequeCarteraToOp(int idcheque)
        {
            _xop.AddChequeCarteraToOp(idcheque);
            OperacionesAddItemsPago();
            bTotalCheques.DisplayValue = _xop.Header.ImporteCheques;
        }

        public void AddChequeEmitido(string cuenta, DateTime fechaAcreditacion, string numeroCheque, bool esECheque, decimal importe)
        {
            _xop.AddChequeEmitido(cuenta,fechaAcreditacion,numeroCheque,esECheque,importe);
            OperacionesAddItemsPago();
            bTotalCheques.DisplayValue = _xop.Header.ImporteCheques;
        }

        #region DataGridviews
        private void dgvItemsPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dx = (DataGridView)sender;
            if (!(dx.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = dx[e.ColumnIndex, e.RowIndex].Value.ToString();
            var item = Convert.ToInt32(dx[_2Item.Name, e.RowIndex].Value);
            string cuenta = dx[_2cuenta.Name, e.RowIndex].Value.ToString();
            bool esCheque = Convert.ToBoolean(dx[_2EsCheque.Name, e.RowIndex].Value);
            decimal importe = Convert.ToDecimal(dx[_2ImporteOP.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "DEL":
                    _xop.RemoveItemPago(item);
                    _xop.ImputacionAutomatica();
                    MapValoresHeader();
                    dgv2ItemsPago.DataSource = _xop.ItemsPagoOP.Count == 0 ? null : _xop.ItemsPagoOP;
                    dgv1Documentos.DataSource = new PopulateOrdenPagoStructures().PopulateFacturasInOp(_xop.FacturasOP).ToList();
                    if (cuenta == "ARS" || cuenta == "USD")
                    {
                        //efectivos
                        bTotalEfectivo.DisplayValue = bTotalEfectivo.GetValueDecimal - importe;
                    }
                    else
                    {
                        if (esCheque)
                        {
                            //cuentas cheque
                            bTotalCheques.DisplayValue = bTotalCheques.GetValueDecimal - importe;
                        }
                        else
                        {
                            //otras cuentas
                            bTotalOtros.DisplayValue = bTotalOtros.GetValueDecimal - importe;
                        }
                    }
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }

        }
        private void dgvRetencionens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dx = (DataGridView)sender;
            if (!(dx.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = dx[e.ColumnIndex, e.RowIndex].Value.ToString();
            var item = Convert.ToInt32(dx[_3IdItem.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "EDIT":
                    var data = _xop.Retenciones.SingleOrDefault(c => c.IdItemRetencion == item);
                    using (var f = new FrmFI36Retenciones(data.RetencionTipo, data.BaseImponibleCalculo, data.Alicuota,
                        data.ImporteRetencion, data.GL))
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            _xop.UpdateRetencion(item,f.BaseImpo,f.Alicuota,f.Importe);
                            bTotalRetenciones.DisplayValue = _xop.Header.ImporteRetenciones;
                            _xop.ImputacionAutomatica();
                            dgv4Retenciones.DataSource = _xop.Retenciones.ToList();
                            dgv1Documentos.DataSource = new PopulateOrdenPagoStructures()
                                .PopulateFacturasInOp(_xop.FacturasOP).ToList();
                            dgv3Creditos.DataSource = _xop.Creditos.ToList();
                            MapValoresHeader();
                        }
                    }
                    break;
                case "DEL":
                    _xop.RemoveRetencion(item);
                    _xop.ImputacionAutomatica();
                    bTotalRetenciones.DisplayValue = _xop.Header.ImporteRetenciones;
                    dgv4Retenciones.DataSource = _xop.Retenciones.ToList();
                    dgv1Documentos.DataSource = new PopulateOrdenPagoStructures().PopulateFacturasInOp(_xop.FacturasOP).ToList();
                    MapValoresHeader();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
        private void dgvDocOp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dx = (DataGridView)sender;
            if (!(dx.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = dx[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idctacte = Convert.ToInt32(dx[_idCtaCte1.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "DEL":
                    _xop.RemoveFacturasOP(idctacte);
                    _xop.ImputacionAutomatica();
                    MapValoresHeader();
                    dgv1Documentos.DataSource = new PopulateOrdenPagoStructures().PopulateFacturasInOp(_xop.FacturasOP).ToList();
                    dgv3Creditos.DataSource = _xop.Creditos.ToList();
                    bTotalDocumentos.DisplayValue = _xop.Header.ImporteFacturas;
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
                    
            }
        }
        private void dgvCreditosPendienteImputacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dx = (DataGridView)sender;
            if (!(dx.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = dx[e.ColumnIndex, e.RowIndex].Value.ToString();
            var id = Convert.ToInt32(dx[_3id.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "DEL":
                    _xop.RemoveCredito(id);
                    _xop.ImputacionAutomatica();
                    MapValoresHeader();
                    dgv1Documentos.DataSource = new PopulateOrdenPagoStructures().PopulateFacturasInOp(_xop.FacturasOP).ToList();
                    dgv3Creditos.DataSource = _xop.Creditos.ToList();
                    bTotalCreditos.DisplayValue = _xop.Header.ImporteCreditos;
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;

            }
        }
        #endregion
        private void rbtnSetL1_Click(object sender, EventArgs e)
        {
            _xop.TipoLx = "L1";
            SetLx("L1",true);
            rbtnTipoLx.Text = @"Tipo L1";
        }
        private void rbtnSetL2_Click(object sender, EventArgs e)
        {
            _xop.TipoLx = "L2";
            SetLx("L2",false);
            rbtnTipoLx.Text = @"Tipo L2";
        }
        private void rbtnRemoverCreditosAnteriores_Click(object sender, EventArgs e)
        {
        }
        private void rbAsignarCreditosAOP_Click(object sender, EventArgs e)
        {

        }
        private void c(object sender, PaintEventArgs e)
        {

        }
        private void z(object sender, EventArgs e)
        {

        }
        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void ctlDisplayNumbers24_Load(object sender, EventArgs e)
        {

        }
        private void MapValoresHeader()
        {
            aRetenciones.DisplayValue = _xop.Header.ImporteRetenciones;
            aCreditosIncluidos.DisplayValue = _xop.Header.ImporteCreditos;
            aEfectivoCheques.DisplayValue = _xop.Header.ImporteEfectivo+_xop.Header.ImporteCheques;
            aOtrosValoresOP.DisplayValue = _xop.Header.ImporteOtros;
            aImporteTotalOP.DisplayValue = _xop.Header.ImporteOrdenPago;
            aFacturasOP.DisplayValue = _xop.Header.ImporteFacturas;
            if (_xop.Header.RequiereImputacion)
            {
                aTotalImputado.BackColor = Color.LightSalmon; 
                aPendienteImputacion.BackColor= Color.LightSalmon;
            }
            else
            {
                aTotalImputado.DisplayValue = _xop.Header.ImporteTotalImputado;
                aPendienteImputacion.DisplayValue = _xop.Header.ImporteTotalNoImputado;
                aPendienteImputacion.BackColor =
                    aPendienteImputacion.GetValueDecimal != 0 ? Color.LightSalmon : Color.WhiteSmoke;
                aTotalImputado.BackColor = Color.WhiteSmoke;
            }

            if (_xop.Header.ImporteSaldoImpago < 0)
            {
                lSaldoTexto.Text = @"Saldo A Favor";
                lSaldoTexto.BackColor = Color.MintCream;
                lSaldoTexto.ForeColor = Color.SeaGreen;
            }
            //else
            {
                lSaldoTexto.Text = @"Saldo Impago";
                lSaldoTexto.BackColor = Color.LavenderBlush;
                lSaldoTexto.ForeColor = Color.Crimson;
            }
            aSaldoImpago.DisplayValue = _xop.Header.ImporteSaldoImpago;

            bTotalCreditos.DisplayValue = _xop.Header.ImporteCreditos;
            bCreditoPendienteImputar.DisplayValue = _xop.Header.CreditoPendienteImputar;
            bTotalImputadoADocumentos.DisplayValue = _xop.Header.ImporteTotalImputado;
            bPendienteImputacionADocumentos.DisplayValue = _xop.Header.ImporteTotalNoImputado;
        }
        private void rbtnGenerar_Click(object sender, EventArgs e)
        {
            var resultadoValidacion = new OrdenPagoValidaGenerar(_xop).ValidacionGenerar();
            if (resultadoValidacion.IsAllOkGenerar)
            {
                var y = MessageBox.Show(@"La Orden de Pago esta lista para ser generada" + Environment.NewLine +
                                        @"Desea continuar con la generacion?", @"Orden de Pago Status OK",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (y == DialogResult.No)
                    return;

                //Validacion satisfactoria -- procede a generar
                GenerarOrdenPago();
            }
            else
            {
                var x = MessageBox.Show(@"No se puede generar la Orden de Pago porque no estan dadas las condiciones" + Environment.NewLine +
                                @"Desea visualizar un detalle de Errores?",
                    @"Orden de Pago No OK", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (x == DialogResult.No)
                    return;

                //todo:hacer display de errores


            }
        }
        private void GenerarOrdenPago()
        {
            var res=_xop.GeneraOrdenPago();
            if (res)
            {
                _xop.SetGenerada();
                MessageBox.Show($@"Se ha generado correctamente la OP# {OPNumeroConversion.GetNumeroOP(_xop.Header.NumeroOP, _xop.Header.Lx)}",
                    @"Generacion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($@"Ha Ocurrido un Error Inesperado en la generacion del OP# {OPNumeroConversion.GetNumeroOP(_xop.Header.NumeroOP, _xop.Header.Lx)}",
                    @"Generacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtEstadoOP.Text = _xop.StatusOP.ToString();
        }
        private void rbtnAsignarNumeroOP_Click(object sender, EventArgs e)
        {
            if (_xop.StatusOP != OrdenPagoStatus.StatusOP.Inicial)
            {
                MessageBox.Show(@"El Estado de la Orden de Pago no permite la generacion de numero",
                    @"Estado OP Incompatible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_tipoLx == @"L1" || _tipoLx == @"L2")
            {
                if (_xop.Header == null)
                {
                    _xop.InicializaHeader(_idVendor, _tipoLx, dtpFechaOP.Value, cmbMoneda.SelectedItem.ToString(),
                        txtTipodeCambio.GetValueDecimal, false);
                    dtpFechaOP.Enabled = false;
                    txtTipodeCambio.XReadOnly = true;
                    cmbMoneda.Enabled = false;
                    rbtnTipoLx.Enabled = false;
                }

                if (_xop.AsignaNumeroOrdenPago())
                {
                    _numeroOP = _xop.Header.NumeroOP;
                    txtNumeroOP.Text = _numeroOP.ToString();
                    txtEstadoOP.Text = _xop.StatusOP.ToString();
                    //refresacar botones.
                }
                else
                {
                    MessageBox.Show(@"No se ha podido asignar numero de Orden de Pago debido a algun error desconocido",
                        @"Error en Asignacion de #", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(@"No se puede asignar numero porque no se ha definido el tipo de OP [L1/L2]",
                    @"Falta Tipo OP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void rbtnExit_Click(object sender, EventArgs e)
        {
            if (_xop.StatusOP == OrdenPagoStatus.StatusOP.Proceso)
            {
                var r = MessageBox.Show(
                    @"La Orden de Pago podria contener datos que aun no fueron guardados" + Environment.NewLine +
                    @"Confirma la Salida sin Guardar los cambios?", @"Oden de Pago en Proceso", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return;
                this.Close();
            }

            if (_xop.StatusOP == OrdenPagoStatus.StatusOP.Inicial)
            {
                if (_xop.Header==null) this.Close();
                if (_xop.FacturasOP.Any())
                {
                    var r = MessageBox.Show(
                        @"La Orden de Pago contiene Facturas" + Environment.NewLine +
                        @"Confirma la Salida sin Guardar los cambios?", @"Oden de Pago en Proceso", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.No)
                        return;
                    this.Close();
                }

                if (_xop.ItemsPagoOP.Any())
                {
                    var r = MessageBox.Show(
                        @"La Orden de Pago contiene Items de Pago (Efectivo/Cheques)" + Environment.NewLine +
                        @"Confirma la Salida sin Guardar los cambios?", @"Oden de Pago en Proceso", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (r == DialogResult.No)
                        return;
                    this.Close();
                }
            }

        }
        private void rbtnSaveAndExit_Click(object sender, EventArgs e)
        {

            if (_xop.StatusOP == OrdenPagoStatus.StatusOP.Inicial)
            {
                var r = MessageBox.Show(
                    @"Se generará un numero de OP# y se guardarn los datos" + Environment.NewLine +
                    @"Confirma el paso de OP a Status Proceso", @"Oden de Pago Inicial", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return;
                if (_xop.AsignaNumeroOrdenPago())
                {
                    _numeroOP = _xop.Header.NumeroOP;
                    MessageBox.Show($@"Se ha Asignado el numero de OP# {OPNumeroConversion.GetNumeroOP(_xop.Header.NumeroOP, _xop.Header.Lx)}", @"Grabacion de Orden de Pago",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
                else
                {
                    MessageBox.Show(
                        @"Los datos de la Orden de Pago no estan completos y la misma no puede ser guardada",
                        @"Error en Grabacion de Orden de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (_xop.StatusOP == OrdenPagoStatus.StatusOP.Proceso)
            {
                var r = MessageBox.Show(
                    @"Confirma la grabacion de datos para continuar en otro momento?" , @"Oden de Pago en Proceso", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return;

                if (_xop.UpdateOrdenPagoData())
                {
                    MessageBox.Show(@"Los Datos han sido actualizados correctamente", @"Actualizacion OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
                else
                {
                    MessageBox.Show(@"Error en la Actualizacion de Datos", @"Ocurrio un error inesperado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void rbtnPrintOP_Click(object sender, EventArgs e)
        {
            var f = new RvpOrdenPagoPrint(_xop.Header.NumeroOP);
            f.Show();
        }
    }
}
