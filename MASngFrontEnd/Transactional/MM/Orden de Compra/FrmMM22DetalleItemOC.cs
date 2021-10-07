using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.MM.Orden_de_Compra
{
    public partial class FrmMM22DetalleItemOC : Form
    {
        public FrmMM22DetalleItemOC(FrmMM21DatosOC form, int idItem, int modo)
        {
            frmOcHeader = form;
            _idItem = idItem;
            _modo = modo;
            InitializeComponent();
        }

        //Consutructor para creacion de nuevo item desde RC
        public FrmMM22DetalleItemOC(FrmMM21DatosOC form, int idRc)
        {
            _modo = 5;
            _idItem = 0;
            frmOcHeader = form;
            _idRc = idRc;
            InitializeComponent();
        }

        //Consutructor para creacion de nuevo item
        public FrmMM22DetalleItemOC(FrmMM21DatosOC form)
        {
            _modo = 1;
            _idItem = 0;
            frmOcHeader = form;
            InitializeComponent();
        }

        //---------------------------------------------------------------------------
        private FrmMM21DatosOC frmOcHeader;
        private readonly int _idRc;
        private readonly int _idItem;
        private int _numeroOC;
        private readonly int _modo;
        private OrdenCompraStatusManager.StatusItem _statusItem;
        private int _idProveedor;

        //---------------------------------------------------------------------------
        private void FrmMM22DetalleItemOC_Load(object sender, EventArgs e)
        {
            rbSoloProveedor.Checked = true;
            _numeroOC = frmOcHeader._numeroOC;
            txtNumeroOC.Text = _numeroOC.ToString();
            switch (_modo)
            {
                case 1:
                    _statusItem = OrdenCompraStatusManager.StatusItem.Nuevo;
                    txtNumeroItem.Text = @"0";
                    btnUpdate.Enabled = false;
                    btnAgregarItem.Enabled = true;
                    dtpFechaEntrega.Value = DateTime.Today.AddDays(3);
                    SetSegunEstadoItem();
                    break;
                case 2:
                    txtNumeroItem.Text = _idItem.ToString();
                    btnUpdate.Enabled = true;
                    btnAgregarItem.Enabled = false;
                    var itemData = frmOcHeader.Items.SingleOrDefault(c => c.IDITEMCOMPRA == _idItem);
                    _statusItem = OrdenCompraStatusManager.MapStatusItemFromText(itemData.StatusItem);
                    SetSegunEstadoItem();
                    break;
                case 3:
                    txtNumeroItem.Text = _idItem.ToString();
                    //bloqueo todos los botones y no llamo al segun-estado
                    btnAgregarItem.Enabled = false;
                    btnCerrarItem.Enabled = false;
                    btnReAbrirItem.Enabled = false;
                    btnUpdate.Enabled = false;
                    break;
                case 5:
                    _statusItem = OrdenCompraStatusManager.StatusItem.Nuevo;
                    txtNumeroItem.Text = @"0";
                    btnUpdate.Enabled = false;
                    btnAgregarItem.Enabled = true;
                    dtpFechaEntrega.Value = DateTime.Today.AddDays(3);
                    SetSegunEstadoItem();
                    break;
                default:
                    MessageBox.Show(@"Error en el Modo de OC#", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            InicializaData();
        }

        private void SetSegunEstadoItem()
        {
            btnBorrarItem.Enabled = false;
            btnAgregarItem.Enabled = false;
            btnCerrarItem.Enabled = false;
            btnReAbrirItem.Enabled = false;
            btnUpdate.Enabled = false;
            switch (_statusItem)
            {
                case OrdenCompraStatusManager.StatusItem.Nuevo:
                    btnAgregarItem.Enabled = true;
                    break;
                case OrdenCompraStatusManager.StatusItem.Inicial:
                    btnUpdate.Enabled = true;
                    btnBorrarItem.Enabled = true;
                    break;
                case OrdenCompraStatusManager.StatusItem.Parcial:
                    btnCerrarItem.Enabled = true;
                    break;
                case OrdenCompraStatusManager.StatusItem.Completo:
                    //no permite hacer nada
                    break;
                case OrdenCompraStatusManager.StatusItem.Excedido:
                    //no permite hacer nada
                    break;
                case OrdenCompraStatusManager.StatusItem.Cancelado:

                    break;
                case OrdenCompraStatusManager.StatusItem.CompletoM:
                    btnReAbrirItem.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void InicializaData()
        {
            //Carga datos Header OC
            uTipoCambio.Init(1, 1000, 2, true, true, false);
            uPrecioUnitarioARS.Init((decimal)0.001, 10000, 2, validacionColores: false);
            uPrecioUnitarioUSD.Init((decimal)0.001, 10000, 2, validacionColores: false);
            uKgPedidos.Init((decimal)0.1, 30000, 2, true, true, true);
            _idProveedor = frmOcHeader.IdProv;
            txtProveedorId.Text = _idProveedor.ToString();
            var vendorD = new VendorManager().GetSpecificVendor(frmOcHeader.IdProv);
            txtRazonSocial.Text = vendorD.prov_rsocial;
            txtNumeroOC.Text = frmOcHeader._numeroOC > 0 ? frmOcHeader._numeroOC.ToString() : @"SIN DATOS";
            cmbMaterial.SelectedIndex = -1;

            if (_idItem == 0)
            {
                //item nuevo
                _statusItem = OrdenCompraStatusManager.StatusItem.Inicial;
                txtNumeroItem.Text = @"N/A";
                txtNumeroItem.BackColor = Color.Orange;
            }
            else
            {
                var itemData = frmOcHeader.Items.SingleOrDefault(c => c.IDITEMCOMPRA == _idItem);
                _statusItem = OrdenCompraStatusManager.MapStatusItemFromText(itemData.StatusItem);
                cmbMaterial.SelectedValue = itemData.MATERIAL;
                uKgPedidos.Text = itemData.CANTIDAD.Value.ToString();
                uPrecioUnitarioARS.Text = itemData.PRECIO_UNITARIO_P.ToString();
                uPrecioUnitarioUSD.Text = itemData.PRECIO_UNITARIO_D.ToString();
                txtObservacionItem.Text = itemData.ComentarioI_OC;
                if (itemData.FECHARECIBIDO != null)
                    dtpFechaEntrega.Value = itemData.FECHARECIBIDO.Value;
            }

            txtNumeroItem.Text = _idItem.ToString();
            txtNumeroItem.BackColor = Color.MediumSeaGreen;
            uTipoCambio.Text = frmOcHeader.txtTipoCambio.Text;
            txtStatusItem.Text = _statusItem.ToString();

            if (_modo == 5)
            {
                //modo RC
                var rc = new RcManagement().GetRequisicion(_idRc);
                if (rc.ProveedorElegido == null)
                {
                    rbSoloProveedor.Checked = true;
                    cmbMaterial.SelectedValue = rc.Material;
                    if (cmbMaterial.SelectedValue == null)
                    {
                        rbTodos.Checked = true;
                        cmbMaterial.SelectedValue = rc.Material;
                    }
                }
                else
                {
                    rbSoloProveedor.Checked = true;
                    cmbMaterial.SelectedValue = rc.Material;
                }

                uKgPedidos.Text = rc.KgRequeridos.ToString();
            }
        }

        private void rbSoloProveedor_CheckedChanged(object sender, EventArgs e)
        {
            t0010MATERIALESBindingSource.DataSource = rbSoloProveedor.Checked
                ? new MaterialMasterManager().GetListMaterialSuppliedByVendor(frmOcHeader.IdProv)
                : new MaterialTypeManager().GetListMaterialAvailableToBuy();
        }

        private void PopulateMaterialInfo()
        {
            var data = (T0010_MATERIALES)cmbMaterial.SelectedItem;
            txtDescipcionMaterial.Text = data.MAT_DESC;
            if (data.MonedaCosto == null)
                data.MonedaCosto = @"USD";

            cmbMoneda.SelectedItem = data.MonedaCosto;

            var infoR = new VendorInfoRecordManager().GetInfoRecordMaterialVendor(_idProveedor,
                cmbMaterial.SelectedValue.ToString());

            if (infoR == null)
            {
                //txtDescipcionMaterial.Text = null;
                txtCodigoProveedor.Text = null;
                txtFechaUC.Text = null;
                txtCantidadUc.Text = null;
                txtMonedaUc.Text = null;
                txtPrecioArsUc.Text = null;
                txtPrecioUsdUc.Text = null;
            }
            else
            {
                cmbMoneda.SelectedItem = infoR.MONEDAUCOMPRA;
                txtCodigoProveedor.Text = infoR.MATERIAL_PROVEEDOR;
                if (infoR.FULTIMACOMPRA != null)
                    txtFechaUC.Text = infoR.FULTIMACOMPRA.Value.ToString("d");
                if (infoR.ULTIMACANTIDAD != null)
                    txtCantidadUc.Text = infoR.ULTIMACANTIDAD.Value.ToString("N2");
                txtMonedaUc.Text = infoR.MONEDAUCOMPRA;
                if (infoR.ULTIMOTC == null || infoR.ULTIMOTC == 0)
                {
                    infoR.ULTIMOTC = 1;
                }

                if (infoR.ULTIMOPRECIO == null)
                    infoR.ULTIMOPRECIO = 0;

                if (infoR.MONEDAUCOMPRA == "ARS")
                {
                    txtPrecioArsUc.Text = infoR.ULTIMOPRECIO.Value.ToString("C2");
                    txtPrecioUsdUc.Text = (infoR.ULTIMOPRECIO.Value / infoR.ULTIMOTC.Value).ToString("C2");
                    txtPrecioArsUc.BackColor = Color.Khaki;
                    txtPrecioUsdUc.BackColor = Color.LightGray;
                }
                else
                {
                    txtPrecioArsUc.Text = (infoR.ULTIMOPRECIO.Value * infoR.ULTIMOTC.Value).ToString("C2");
                    txtPrecioUsdUc.Text = infoR.ULTIMOPRECIO.Value.ToString("C2");
                    txtPrecioUsdUc.BackColor = Color.Khaki;
                    txtPrecioArsUc.BackColor = Color.LightGray;
                }
            }
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtDescipcionMaterial.Text = null;
                txtCodigoProveedor.Text = null;
                txtFechaUC.Text = null;
                txtCantidadUc.Text = null;
                txtMonedaUc.Text = null;
                txtPrecioArsUc.Text = null;
                txtPrecioUsdUc.Text = null;
            }
            else
            {
                PopulateMaterialInfo();
            }
        }

        private void cmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbMaterial);
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMoneda.Text == @"ARS")
            {
                uPrecioUnitarioARS.BackColor = Color.GreenYellow;
                uPrecioUnitarioUSD.BackColor = Color.LightGray;
                uPrecioUnitarioARS.ReadOnly = false;
                uPrecioUnitarioUSD.ReadOnly = true;
                uPrecioUnitarioARS.Text = null;
                uPrecioUnitarioUSD.Text = null;
            }
            else
            {
                uPrecioUnitarioUSD.BackColor = Color.GreenYellow;
                uPrecioUnitarioARS.BackColor = Color.LightGray;
                uPrecioUnitarioARS.ReadOnly = true;
                uPrecioUnitarioUSD.ReadOnly = false;
                //uPrecioUnitarioARS.Enabled = false;
                //uPrecioUnitarioUSD.Enabled = true;
                uPrecioUnitarioARS.Text = null;
                uPrecioUnitarioUSD.Text = null;
            }
        }

        private void uPrecioUnitarioARS_Validated(object sender, EventArgs e)
        {
            if (uTipoCambio.ValueD == 0)
            {
                uPrecioUnitarioUSD.Text = 0.ToString("C2");
                return;
            }
            uPrecioUnitarioUSD.Text = (uPrecioUnitarioARS.ValueD / uTipoCambio.ValueD).ToString("C2");
        }

        private void uPrecioUnitarioUSD_Validated(object sender, EventArgs e)
        {
            if (uTipoCambio.ValueD == 0)
            {
                uPrecioUnitarioARS.Text = 0.ToString("C2");
                return;
            }
            uPrecioUnitarioARS.Text = (uPrecioUnitarioUSD.ValueD * uTipoCambio.ValueD).ToString("C2");
        }

        private void uTipoCambio_Validated(object sender, EventArgs e)
        {
            if (cmbMoneda.Text == @"ARS")
            {
                uPrecioUnitarioUSD.Text = (uPrecioUnitarioARS.ValueD / uTipoCambio.ValueD).ToString("C2");
            }
            else
            {
                uPrecioUnitarioARS.Text = (uPrecioUnitarioUSD.ValueD * uTipoCambio.ValueD).ToString("C2");
            }
        }



        private void BlanqueaDatos()
        {
            cmbMaterial.SelectedIndex = -1;
            txtDescipcionMaterial.Text = null;
            txtCodigoProveedor.Text = null;
            uKgPedidos.Text = 0.ToString("N2");
            uPrecioUnitarioARS.Text = 0.ToString("C2");
            uPrecioUnitarioUSD.Text = 0.ToString("C2");
            txtObservacionItem.Text = null;
            dtpFechaEntrega.Value = DateTime.Today.AddDays(3);
        }


        private bool ValidacionDatosAddItem()
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                MessageBox.Show(@"Se debe definir un Material a Comprar", @"Error en Seleccion de Mateiral", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (uKgPedidos.ValueD <= 0)
            {
                uKgPedidos.MiToolTip("Revise la cantidad de Kg");
                return false;
            }

            if (string.IsNullOrEmpty(cmbMoneda.Text))
            {
                cmbMoneda.Text = @"USD";
            }

            if (uTipoCambio.ValueD == 0)
            {
                uTipoCambio.MiToolTip("Defina un Tipo de Cambio Valido");
                return false;
            }

            if (cmbMoneda.Text == @"ARS")
            {
                if (uPrecioUnitarioARS.ValueD <= 0)
                {
                    uPrecioUnitarioARS.MiToolTip("Defina un Precio Valido en PESOS");
                    return false;
                }
            }
            else
            {
                if (uPrecioUnitarioUSD.ValueD <= 0)
                {
                    uPrecioUnitarioUSD.MiToolTip("Defina un Precio Valido en USD");
                    return false;
                }
            }

            return true;
        }

        private void MapNewItem()
        {
            var data = new T0061_OCOMPRA_I()
            {
                ALLRC = false,
                CANTIDAD = uKgPedidos.ValueD,
                ComentarioI_OC = txtObservacionItem.Text,
                MATERIAL = cmbMaterial.SelectedValue.ToString(),
                MATERIAL_PROVEEDOR = txtCodigoProveedor.Text,
                ORDENCOMPRA = _numeroOC,
                IDITEMCOMPRA = _idItem,
                StatusItem = _statusItem.ToString(),
                TC = uTipoCambio.ValueD,
                PRECIO_UNITARIO_D = uPrecioUnitarioUSD.ValueD,
                PRECIO_UNITARIO_P = uPrecioUnitarioARS.ValueD,
                FECHARECIBIDO = dtpFechaEntrega.Value,
                CANTIDAD_RECIBIDA = 0,
                IdRC = null,
                IdRCItem = 0,
            };
            data.PRECIOBASE = cmbMoneda.Text == @"ARS" ? data.PRECIO_UNITARIO_P : data.PRECIO_UNITARIO_D;
            if (_idRc > 0)
            {
                data.IdRC = _idRc;
                data.IdRCItem = 1;
                data.ALLRC = true;
            }
            frmOcHeader.Items.Add(data);
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (ValidacionDatosAddItem() == false)
                return;
            MapNewItem();
            frmOcHeader.Refrescar(true);
            MessageBox.Show(@"El Item se ha agregado correctamente a la OC#", @"Item Agregado", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            if (_modo == 5)
            {
                new OrdenCompraManager().UpdateNumeroOCinRC(_idRc, _numeroOC, _idItem);
                this.Close();
            }
            BlanqueaDatos();
        }
        private void btnCerrarItem_Click(object sender, EventArgs e)
        {
            /*cuando se recibe la totalidad se cierra el itema en forma automatica */
            new OrdenCompraStatusManager().CloseItem(_numeroOC, _idItem);
            frmOcHeader.ReloadOCData();
            this.Close();
        }
        private void btnReAbrirItem_Click(object sender, EventArgs e)
        {
            /*el item tiene que estar cerrado pero le tiene que faltar kg por recibir, sino no permite abrir*/
            var itemData = frmOcHeader.Items.SingleOrDefault(c => c.IDITEMCOMPRA == _idItem);
            if (itemData.CANTIDAD_RECIBIDA == null)
                itemData.CANTIDAD_RECIBIDA = 0;
            if (itemData.CANTIDAD_RECIBIDA.Value >= itemData.CANTIDAD)
            {
                MessageBox.Show(@"No se puede RE-ABRIR el Item porque ya se ha recibido la Totalidad de los Kg",
                    @"Error en Re-Apertura de Orden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new OrdenCompraStatusManager().OpenItem(_numeroOC, _idItem);
            frmOcHeader.ReloadOCData();
            this.Close();

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var itemData = frmOcHeader.Items.SingleOrDefault(c => c.IDITEMCOMPRA == _idItem);
            itemData.FECHARECIBIDO = dtpFechaEntrega.Value;
            itemData.PRECIO_UNITARIO_D = uPrecioUnitarioUSD.ValueD;
            itemData.PRECIO_UNITARIO_P = uPrecioUnitarioARS.ValueD;
            itemData.TC = uTipoCambio.ValueD;
            itemData.MATERIAL_PROVEEDOR = txtCodigoProveedor.Text;
            itemData.MATERIAL = cmbMaterial.SelectedValue.ToString();
            itemData.PRECIOBASE = cmbMoneda.Text == @"ARS" ? itemData.PRECIO_UNITARIO_P : itemData.PRECIO_UNITARIO_D;
            itemData.CANTIDAD = uKgPedidos.ValueD;
            itemData.ComentarioI_OC = txtObservacionItem.Text;
            frmOcHeader.Refrescar(true);

            if (_numeroOC > 0)
            {
                new OrdenCompraManager().UpdateItemData(itemData);
            }


            MessageBox.Show(
                @"El Item se ha modificado correctamente - Si la orden de Compra ya ha sido enviada al proveedor comunique los cambios si son necesarios",
                @"Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void btnBorrarItem_Click(object sender, EventArgs e)
        {
            var itemData = frmOcHeader.Items.SingleOrDefault(c => c.IDITEMCOMPRA == _idItem);
            frmOcHeader.Items.Remove(itemData);
            frmOcHeader.Refrescar(true);
            MessageBox.Show(
                @"El Item se ha eliminado de la Orden de Compra",
                @"Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
