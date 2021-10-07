using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.MM
{
    public partial class FrmMM30IcOLD : Form
    {
        public FrmMM30IcOLD()
        {
            InitializeComponent();
        }

        public FrmMM30IcOLD(int modo)
        {
            InitializeComponent();
        }

        private T0005_MPROVEEDORES _vendorSelected = new T0005_MPROVEEDORES();
        private void ConfiguraComboBoxes()
        {
            var estado = new StockEstadoManager().GetListEstadoDisponibleIc();
            cmbEstadoStock.ValueMember = "IDESTADO";
            cmbEstadoStock.DisplayMember = "ESTADO";
            cmbEstadoStock.DataSource = new StockEstadoManager().GetListEstadoDisponibleIc();

            cmbMaterial.ValueMember = "IDMATERIAL";
            cmbMaterial.DisplayMember = "IDMATERIAL";
            cmbMaterial.DataSource = new MaterialTypeManager().GetListMaterialAvailableToBuy();

            cmbProveedorFantasia.ValueMember = "ID_PROV";
            cmbProveedorFantasia.DisplayMember = "PROV_FANTASIA";
            cmbProveedorFantasia.DataSource = new VendorManager().GetListVendorsWithOrdenCompra();

            cmbProveedorRazonSocial.ValueMember = "ID_PROV";
            cmbProveedorRazonSocial.DisplayMember = "PROV_RSOCIAL";
            cmbProveedorRazonSocial.DataSource = new VendorManager().GetListVendorsWithOrdenCompra();

            cmbUbicacionStock.ValueMember = "SLOC";
            cmbUbicacionStock.DisplayMember = "SLOC_DESC";
            cmbUbicacionStock.DataSource = new Ubicaciones().GetUbicacionesStockDisponibleProduccion(txtPlanta.Text);

            cmbRecibidoPor.ValueMember = "ID_VEND";
            cmbRecibidoPor.DisplayMember = "SHORTNAME";
            cmbRecibidoPor.DataSource = new HumanResourcesManager().GetListAllActivePermiteControlIc();
            cmbRecibidoPor.SelectedValue = "JF";

        }
        private void cmbProveedorRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedorRazonSocial.SelectedIndex >= 0)
            {
                txtIdProveedor.Text = cmbProveedorRazonSocial.SelectedValue.ToString();
                _vendorSelected = new VendorManager().GetSpecificVendor(Convert.ToInt32(txtIdProveedor.Text));
                txtTipoProveedor.Text = _vendorSelected.TIPO;
                cmbProveedorFantasia.SelectedValue = cmbProveedorRazonSocial.SelectedValue;

                DetalleOrdenCompraBS.DataSource =
                    new OrdenCompraManager().GetListItemsDisponiblesIngresoByVendor(_vendorSelected.id_prov).ToList();
                dgvDetalleOCItems.DataSource = DetalleOrdenCompraBS;
            }
        }
        private void cmbProveedorFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedorFantasia.SelectedIndex >= 0)
            {
                txtIdProveedor.Text = cmbProveedorFantasia.SelectedValue.ToString();
                _vendorSelected = new VendorManager().GetSpecificVendor(Convert.ToInt32(txtIdProveedor.Text));
                txtTipoProveedor.Text = _vendorSelected.TIPO;
                cmbProveedorRazonSocial.SelectedValue = cmbProveedorFantasia.SelectedValue;
                DetalleOrdenCompraBS.DataSource =
                    new OrdenCompraManager().GetListItemsDisponiblesIngresoByVendor(_vendorSelected.id_prov).ToList();
                dgvDetalleOCItems.DataSource = DetalleOrdenCompraBS;
            }
        }
        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex >= 0)
            {
                //txtIdProveedor.Text = cmbProveedorFantasia.SelectedValue.ToString();
                //_vendorSelected = new VendorManager().GetSpecificVendor(Convert.ToInt32(txtIdProveedor.Text));
                //txtTipoProveedor.Text = _vendorSelected.TIPO;
                //cmbProveedorRazonSocial.SelectedValue = cmbProveedorFantasia.SelectedValue;
                //DetalleOrdenCompraBS.DataSource =
                //    new OrdenCompraManager().GetListItemsDisponiblesIngresoByVendor(_vendorSelected.id_prov).ToList();
                //dgvDetalleOCItems.DataSource = DetalleOrdenCompraBS;
                //   MessageBox.Show(@"Esta funcionalidad aun no se encuentra implementada", @"Funcionalidad no implementada",
                //      MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool ValidarDatosCompletos()
        {
            if (string.IsNullOrEmpty(txtNumeroOC.Text))
            {
                MessageBox.Show(@"Para poder ingresar material se debe seleccionar una orden de compra",
                    @"Ingreso de Stock con Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtIdProveedor.Text))
            {
                MessageBox.Show(@"Debe seleccionar un proveedor", @"Validacion de Datos Completos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtMaterialOC.Text))
            {
                MessageBox.Show(@"Debe seleccionar un Material desde OC", @"Validacion de Datos Completos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtKGRecibidos.Text))
            {
                MessageBox.Show(@"Debe Completar KG Ingresados (numerico >0)", @"Validacion de Datos Completos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (Convert.ToDecimal(txtKGRecibidos.Text) <= 0)
            {
                MessageBox.Show(@"La Cantidad de Kg Ingresada no es correcta", @"Validacion de Datos Completos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (String.IsNullOrEmpty(txtNumeroRemito.Text))
            {
                MessageBox.Show(@"Debe Completar el numero de Remito de ingreso", @"Validacion de Datos Completos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtNumeroRemito.Text.Length < 13)
            {
                MessageBox.Show(@"El numero de remito es INCORRECTO - Complete con 0000 donde corresponda.", @"Validacion de Datos Completos Formato 0000-00000000",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (String.IsNullOrEmpty(txtLoteTecser.Text))
            {
                MessageBox.Show(@"Debe Completar el numero de LOTE (Tecser)", @"Validacion de Datos Completos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (String.IsNullOrEmpty(cmbRecibidoPor.Text))
            {
                MessageBox.Show(@"Debe Completar Responsable que Recibio la mercaderia",
                    @"Validacion de Datos Completos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        //Mapea Form a Item
        private T0063_ITEMS_OC_INGRESADOS MapIngresoFormDb(T0063_ITEMS_OC_INGRESADOS ingresoIc)
        {
            var ocI = new OrdenCompraManager().GetDataOCItem(Convert.ToInt32(txtNumeroOC.Text),
                Convert.ToInt32(txtNumeroItem.Text));

            var ocH = new OrdenCompraManager().GetDataOcHeader(Convert.ToInt32(txtNumeroOC.Text));

            var vendor = new VendorManager().GetSpecificVendor(ingresoIc.PROVEEDOR.Value);

            //IngresoIC.ID=
            ingresoIc.PROVEEDOR = Convert.ToInt32(txtIdProveedor.Text);
            ingresoIc.PCUIT = vendor.NTAX1;
            ingresoIc.PRAZONSOCIAL = vendor.prov_rsocial;
            ingresoIc.FECHA_OC = ocH.FECHAOC;
            ingresoIc.NUM_OC = ocI.ORDENCOMPRA;
            ingresoIc.FECHA_IN = dtpFechaEntrega.Value;
            ingresoIc.FechaRemitoReal = dtpFechaRemito.Value;
            ingresoIc.IDMATERIAL = txtMaterialOC.Text;
            ingresoIc.CANTIDAD = Convert.ToInt32(txtKGRecibidos.Text);
            ingresoIc.MON_OC = ocH.MONEDAOC;
            ingresoIc.TC = ocI.TC;
            //
            ingresoIc.PRECIO_U_ARS = ocI.PRECIO_UNITARIO_P;
            ingresoIc.PRECIO_U_USD = ocI.PRECIO_UNITARIO_D;
            ingresoIc.PRECIO_T_ARS = ingresoIc.CANTIDAD * ingresoIc.PRECIO_U_ARS;
            ingresoIc.PRECIO_T_USD = ingresoIc.CANTIDAD * ingresoIc.PRECIO_U_USD;
            ingresoIc.NREMITO = txtNumeroRemito.Text;
            ingresoIc.RespControlRecepcion = cmbRecibidoPor.Text;
            ingresoIc.CONTA = false;

            //IngresoIC.NFACTURA=
            //IngresoIC.CONTA_CANT=
            //IngresoIC.CONTA_U_ARS=
            //IngresoIC.CONTA_U_USD=
            //IngresoIC.CONTA_TOTAL=
            //IngresoIC.ADDED=
            //IngresoIC.CCOSTO=
            //IngresoIC.ZINCLUIR=
            ingresoIc.GL = "0.0.0.0";
            ingresoIc.TIPO = "L0";
            //IngresoIC.NASIENTO=
            ingresoIc.ID40 = 0;
            //IngresoIC.NP=
            //IngresoIC.REPRO=
            //IngresoIC.MATERIALFAB=
            //IngresoIC.KGFAB=
            //IngresoIC.KGENTREGA=
            //IngresoIC.STATUSNP=
            return ingresoIc;
        }
        private T0061_OCOMPRA_I MapItemOCFormDb(T0061_OCOMPRA_I items)
        {

            items.FECHARECIBIDO = dtpFechaEntrega.Value;  //Todo: Remover al elminar MAS
            items.REMITO = txtNumeroRemito.Text;  //Todo: Remover al elminar MAS
            items.ComentarioI_RE = txtComentarioRecepecion.Text; //Todo: Remover al elminar MAS
            items.CANTIDAD_RECIBIDA = Convert.ToDecimal(txtKGRecibidos.Text) + Convert.ToDecimal(txtKGRecibidosOC.Text);
            items.StatusItem = ckEntregaParcial.Checked == true ? "Parcial" : "Cerrado";
            return items;
        }
        private void FrmIngresoStockOrdenCompra_Load(object sender, EventArgs e)
        {
            ConfiguraComboBoxes();
        }
        private void btnIngresoStock_Click(object sender, EventArgs e)
        {
            if (ValidarDatosCompletos() == false)
                return;

            var ocManager = new OrdenCompraManager();
            var iC = new IngresoStockManager(Convert.ToInt32(txtNumeroOC.Text), Convert.ToInt32(txtNumeroItem.Text));

            var resp =
                MessageBox.Show(
                    $"Confirma el Ingreso de Stock de Producto  {txtMaterialOC.Text} - Cantidad de Kg {txtKGRecibidos.Text}", @"Confirmacion Ingreso de Stock",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
            {
                return;
            }

            var dataItemOC = new T0061_OCOMPRA_I();
            dataItemOC = MapItemOCFormDb(dataItemOC); //todo: mandar a actualizar

            iC.ManageIngresoStock(dtpFechaEntrega.Value, dtpFechaRemito.Value, txtNumeroRemito.Text,
                Convert.ToDecimal(txtKGRecibidos.Text), txtLoteTecser.Text,
                StockStatusManager.MapStatusFromText(cmbEstadoStock.Text), cmbUbicacionStock.SelectedValue.ToString(),
                ckEntregaParcial.Checked, cmbRecibidoPor.Text, ckReproceso.Checked, txtComentarioRecepecion.Text,
                txtMaterialOC.Text);

            MessageBox.Show(@"SE HA INGRESADO CORRECTAMENTE EL STOCK AL SISTEMA", @"Ingreso de Stock Correcto",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            BlanqueaDatos();
        }
        private void BlanqueaDatos()
        {
            dtpFechaEntrega.Value = DateTime.Today;
            dtpFechaRemito.Value = DateTime.Today;
            txtNumeroRemito.Text = null;
            cmbRecibidoPor.Text = null;
            txtComentarioRecepecion.Text = null;
            txtKGRecibidos.Text = null;
            txtLoteTecser.Text = null;
            txtPlanInspeccion.Text = null;
            ckEntregaParcial.Checked = false;
            ckLiberarStock.Checked = false;
            ckReproceso.Checked = false;
            txtNumeroOC.Text = null;
            txtNumeroItem.Text = null;
            txtMaterialOC.Text = null;
            txtKGOrdenCompra.Text = @"0.00";
            txtKGRecibidos.Text = @"0.00";
            txtKGRestanteEntrega.Text = @"0.00";
            txtComentarioOC.Text = null;
            cmbProveedorFantasia.Text = null;
            cmbProveedorRazonSocial.Text = null;
            txtProveedorContacto.Text = null;
            txtProveedorTelefono.Text = null;
            txtTipoProveedor.Text = null;
            txtIdProveedor.Text = null;
            txtNumeroOC.Text = null;
            txtStatusItem.Text = null;
            txtProveedor.Text = null;
            dgvDetalleOCItems.DataSource = null;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtKGRecibidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void btnCancelarStock_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no se encuentra habilitada", @"Funcionalidad no habilitada",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //todo Implementar
        }
        private void txtKGRecibidos_Leave(object sender, EventArgs e)
        {
            ckEntregaParcial.Checked = false;
            if (string.IsNullOrEmpty(txtKGRecibidos.Text))
                txtKGRecibidos.Text = @"0.00";
            try
            {
                var kgAlreadyReceived = Convert.ToDecimal(txtKGRecibidosOC.Text);
                var kgReceivingNow = Convert.ToDecimal(txtKGRecibidos.Text);
                var kgOC = Convert.ToDecimal(txtKGOrdenCompra.Text);
                if ((kgAlreadyReceived + kgReceivingNow) < kgOC)
                {
                    var dr =
                        MessageBox.Show(
                            @"La CANTIDAD de KG recibida aún no completa la OC." + Environment.NewLine +
                            @"Desea dejar la OC Abierta para una futura recepcion?", @"RECEPCCION PARCIAL",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    ckEntregaParcial.Checked = dr != DialogResult.No;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void DetalleOrdenCompraBS_PositionChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKGRecibidosOC.Text))
                txtKGRecibidosOC.Text = @"0.00";

            if (String.IsNullOrEmpty(txtKGOrdenCompra.Text))
                txtKGOrdenCompra.Text = @"0.00";

            txtKGRestanteEntrega.Text =
                (Convert.ToDecimal(txtKGOrdenCompra.Text) - Convert.ToDecimal(txtKGRecibidosOC.Text)).ToString("N2");

            txtKGRestanteEntrega.BackColor = Convert.ToDecimal(txtKGRestanteEntrega.Text) > 0 ? Color.GreenYellow : Color.OrangeRed;
        }
        private void DetalleOrdenCompraBS_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKGRecibidosOC.Text))
                txtKGRecibidosOC.Text = @"0.00";

            if (string.IsNullOrEmpty(txtKGOrdenCompra.Text))
                txtKGOrdenCompra.Text = @"0.00";

            txtKGRestanteEntrega.Text =
                (Convert.ToDecimal(txtKGOrdenCompra.Text) - Convert.ToDecimal(txtKGRecibidosOC.Text)).ToString("N2");

            txtKGRestanteEntrega.BackColor = Convert.ToDecimal(txtKGRestanteEntrega.Text) > 0 ? Color.GreenYellow : Color.OrangeRed;

        }



        private void txtProveedor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (txtProveedor.Text.Length > "")
            //{

            //}
        }

        private void txtLoteTecser_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
