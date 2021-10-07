using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using MASngFE.Transactional.MM.Requisicin;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.MM.Orden_de_Compra
{
    public partial class FrmMM21DatosOC : Form
    {
        private readonly int _idRc;
        private readonly string _material;
        private readonly decimal _kg;

        public FrmMM21DatosOC(int numeroOC, int modo)
        {
            //visalizar/editar OC Existente
            _numeroOC = numeroOC;
            _modo = modo;
            InitializeComponent();
        }

        public FrmMM21DatosOC(int idProveedor)
        {
            //creacion OC
            _modo = 1;
            IdProv = idProveedor;
            InitializeComponent();
        }

        public FrmMM21DatosOC(int idProveedor, int idRc, string material, decimal kg)
        {
            _idRc = idRc;
            _material = material;
            _kg = kg;
            _modo = 5;
            IdProv = idProveedor;
            InitializeComponent();
        }

        //------------------------------------------------------------------------------
        public int _numeroOC { get; private set; }
        public int IdProv { get; private set; }
        private readonly int _modo; //modo 1-2-3
        private OrdenCompraStatusManager.StatusHeader _statusOC;
        public List<T0061_OCOMPRA_I> Items = new List<T0061_OCOMPRA_I>();
        //------------------------------------------------------------------------------

        public void Refrescar(bool reAsignaitem)
        {
            if (reAsignaitem)
                ReasignaNumeroItemsOC();

            t0061Bs.DataSource = Items.ToList();
            dgvDetalleItemsOc.Refresh();
            dgvDetalleItemsOc.Update();
        }
        private void FrmMM21DatosOC_Load(object sender, EventArgs e)
        {
            dgvDetalleItemsOc.DataSource = t0061Bs;
            switch (_modo)
            {
                case 1:
                    _statusOC = OrdenCompraStatusManager.StatusHeader.Inicial;
                    OcHeaderDataNew();
                    LoadVendorData();
                    SetSegunEstadoOC();
                    break;
                case 2:
                    Text = Text + @" " + -_numeroOC;
                    LoadOCHeaderData();
                    LoadVendorData();
                    SetSegunEstadoOC();
                    t0061Bs.DataSource = new OrdenCompraManager().GetListItemsOC(_numeroOC);
                    Items = new OrdenCompraManager().GetListItemsOC(_numeroOC);
                    break;
                case 3:
                    LoadOCHeaderData();
                    Text = Text + @" " + -_numeroOC;
                    LoadVendorData();
                    SetSegunEstadoOC();
                    LockToMode3();
                    t0061Bs.DataSource = new OrdenCompraManager().GetListItemsOC(_numeroOC);
                    Items = new OrdenCompraManager().GetListItemsOC(_numeroOC);
                    break;
                case 5:
                    //desde RC
                    _statusOC = OrdenCompraStatusManager.StatusHeader.Inicial;
                    OcHeaderDataNew();
                    LoadVendorData();
                    SetSegunEstadoOC();
                    //txtComentarioOC.Text = @"Requiscion Compra #" + _idRc.ToString();
                    using (var fd = new FrmMM22DetalleItemOC(this, _idRc))
                    {
                        fd.ShowDialog();
                    }
                    break;
                default:
                    return;
            }
        }

        public void ReloadOCData()
        {
            LoadOCHeaderData();
            Items = new OrdenCompraManager().GetListItemsOC(_numeroOC);
            t0061Bs.DataSource = Items;
        }

        private void SetSegunEstadoOC()
        {
            dtpFechaEmision.Enabled = false;
            txtMonedaOC.ReadOnly = true;
            txtTipoCambio.ReadOnly = true;
            txtComentarioOC.ReadOnly = true;
            btnAddItems.Enabled = false;
            btnEmitir.Enabled = false;

            switch (_statusOC)
            {
                case OrdenCompraStatusManager.StatusHeader.Inicial:
                    btnAddItems.Enabled = true;
                    btnEmitir.Enabled = true;
                    btnCancelarOC.Enabled = true;
                    dtpFechaEmision.Enabled = true;
                    txtMonedaOC.ReadOnly = false;
                    txtTipoCambio.ReadOnly = false;
                    txtComentarioOC.ReadOnly = false;
                    break;
                case OrdenCompraStatusManager.StatusHeader.Emitida:
                    btnCancelarOC.Enabled = true;
                    btnImprimir.Enabled = true;
                    break;
                case OrdenCompraStatusManager.StatusHeader.Proceso:
                    btnImprimir.Enabled = true;
                    break;
                case OrdenCompraStatusManager.StatusHeader.Cerrada:
                    break;
                case OrdenCompraStatusManager.StatusHeader.Cancelada:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void LockToMode3()
        {
            dtpFechaEmision.Enabled = false;
            txtMonedaOC.ReadOnly = true;
            txtTipoCambio.ReadOnly = true;
            txtComentarioOC.ReadOnly = true;
            btnAddItems.Enabled = false;
            btnEmitir.Enabled = false;
        }
        private void LoadVendorData()
        {
            var d = new VendorManager().GetSpecificVendor(IdProv);
            txtRazonSocial.Text = d.prov_rsocial;
            txtFantasia.Text = d.prov_fantasia;
            txtEmail.Text = d.EMAIL;
            txtCUIT.Text = d.NTAX1;
            txtTelefono1.Text = d.Telefono;
            txtTelefono2.Text = d.Fax;
            txtNombreContacto.Text = d.Contacto;
        }
        private void LoadOCHeaderData()
        {
            var d = new OrdenCompraManager().GetDataOcHeader(_numeroOC);
            txtEstadoOC.Text = d.STATUSOC;
            _statusOC = OrdenCompraStatusManager.MapStatusHeaderFromText(d.STATUSOC);
            txtCantItems.Text = new OrdenCompraManager().GetCantidadItemsOC(_numeroOC).ToString();
            txtTotalKg.Text = new OrdenCompraManager().GetCantidadKgOc(_numeroOC).ToString("N2");
            dtpFechaEmision.Value = d.FECHAOC.Value;
            txtMonedaOC.Text = d.MONEDAOC;
            txtTipoCambio.Text = d.TC.Value.ToString("N2");
            txtFechaCierre.Text = null;
            txtCreadaPor.Text = d.LogUser;
            txtComentarioOC.Text = d.ObservacionOC;
            txtNumeroOC.Text = _numeroOC.ToString();
            IdProv = d.PROVEEDOR.Value;
        }
        private void OcHeaderDataNew()
        {
            txtEstadoOC.Text = _statusOC.ToString();
            txtCantItems.Text = @"0";
            txtTotalKg.Text = 0.ToString("N2");
            dtpFechaEmision.Value = DateTime.Now;
            txtMonedaOC.Text = @"ARS";
            txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(dtpFechaEmision.Value).ToString("N2");
            txtFechaCierre.Text = null;
            txtCreadaPor.Text = GlobalApp.AppUsername;
            txtComentarioOC.Text = @"Auto RC#" + _idRc;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            var f = new FrmMM20BuscadorOC();
            f.Show();
        }
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            using (var fd = new FrmMM22DetalleItemOC(this))
            {
                fd.ShowDialog();
            }
            //solo valido para modo 1.2
        }
        private void dgvDetalleItemsOc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idItem = Convert.ToInt32(datagridview[iDITEMCOMPRADataGridViewTextBoxColumn.Name, e.RowIndex].Value);

            var modoX = _modo <= 2 ? 2 : 3;

            switch (cellValue)
            {
                case "VER":

                case "Edit":
                    var fx1 = new FrmMM22DetalleItemOC(this, idItem, modoX);
                    fx1.Show();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            //chequear estado permite emitir
            //chequear items >0
            //emitirOC >> genera ocnumber, enumera items,graba header, graba items

            if (_statusOC != OrdenCompraStatusManager.StatusHeader.Inicial)
            {
                MessageBox.Show(@"El estado de la OC# no permite su EMISION", @"Error en estado de OC",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Items.Count == 0)
            {
                MessageBox.Show(@"No se puede emitir una OC sin CostItems", @"Error en Emision de OC", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var resp = MessageBox.Show(@"Confirma la Emision/Generacion de esta Orden de Compra?",
                @"Emision de Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            ReasignaNumeroItemsOC();
            _numeroOC = new OrdenCompraManager().EmiteOrdenCompra(MapHeaderDataToStructure(), Items);
            if (_numeroOC > 0)
            {
                txtNumeroOC.Text = _numeroOC.ToString();
                _statusOC = OrdenCompraStatusManager.StatusHeader.Emitida;
                txtEstadoOC.Text = _statusOC.ToString();
                UpdateInfoRecordAllItems();
                MessageBox.Show(
                    $@"Se ha emitido correctamente la OC# {_numeroOC} .- Recuerde enviarla por email al proveedor correspondiente",
                    @"Emision de OC#", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    $@"Ha Ocurrido un Error al intentar emitir la OC",
                    @"Erorr en Emision de OC#", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetSegunEstadoOC();
        }

        private void UpdateInfoRecordAllItems()
        {
            foreach (var i in Items)
            {
                if (i.StatusItem == OrdenCompraStatusManager.StatusItem.Inicial.ToString())
                {
                    var monedaItem = i.PRECIOBASE == i.PRECIO_UNITARIO_P ? "ARS" : "USD";
                    new VendorInfoRecordManager().UpdateInfoRecordEmisionOC(IdProv, i.MATERIAL, i.MATERIAL_PROVEEDOR,
                        i.CANTIDAD.Value, monedaItem, i.PRECIOBASE.Value, i.TC.Value);
                }
            }
        }



        private T0060_OCOMPRA_H MapHeaderDataToStructure()
        {
            var h = new T0060_OCOMPRA_H
            {
                IDORDENCOMPRA = _numeroOC,
                FECHAOC = dtpFechaEmision.Value,
                MONEDAOC = txtMonedaOC.Text,
                ObservacionOC = txtComentarioOC.Text,
                PROVEEDOR = IdProv,
                STATUSOC = _statusOC.ToString(),
                TC = Convert.ToDecimal(txtTipoCambio.Text)
            };
            return h;

        }

        private void ReasignaNumeroItemsOC()
        {
            var id = 1;
            foreach (var i in Items)
            {
                i.IDITEMCOMPRA = id;
                id++;
            }
        }



        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var y = new RpvOrdenCompra(_numeroOC);
            y.Show();
        }
        private void btnCancelarOC_Click(object sender, EventArgs e)
        {
            if (_statusOC == OrdenCompraStatusManager.StatusHeader.Inicial ||
                _statusOC == OrdenCompraStatusManager.StatusHeader.Emitida)
            {
                var msg = MessageBox.Show(@"Desea Cancelar la Orden de Compra?", @"Cancelacion", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (msg == DialogResult.No)
                    return;
            }
            else
            {
                MessageBox.Show(
                    @"El Estado de la OC no permite cancelacion. [Para cerrar la OC debe hacerlo desde los CostItems]",
                    @"No se puede Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            new OrdenCompraStatusManager().CancelCompleteOC(_numeroOC);
            ReloadOCData();
        }

        private void txtTipoCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtTipoCambio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTipoCambio.Text))
                txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");

            if (Convert.ToDecimal(txtTipoCambio.Text) == 0)
            {
                txtTipoCambio.Text = new ExchangeRateManager().GetExchangeRate(DateTime.Today).ToString("N2");
            }
        }

        private void btnAddFromRC_Click(object sender, EventArgs e)
        {
            using (var f = new FrmMM56RcPendientePorProveedor(this, _numeroOC, IdProv))
            {
                f.ShowDialog();
            }
        }
    }
}
