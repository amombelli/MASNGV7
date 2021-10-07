using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.MM
{
    public partial class FrmOrdenCompraDetalleItem : Form
    {
        public FrmOrdenCompraDetalleItem(int numeroOC, int idItem, int modo)
        {
            InitializeComponent();
            _numeroOC = numeroOC;
            _idItem = idItem;
            _modo = modo;
        }

        private readonly int _idItem;
        private readonly int _numeroOC;
        private readonly int _modo;
#pragma warning disable CS0649 // Field 'FrmOrdenCompraDetalleItem._ocHeader' is never assigned to, and will always have its default value null
        private T0060_OCOMPRA_H _ocHeader;
#pragma warning restore CS0649 // Field 'FrmOrdenCompraDetalleItem._ocHeader' is never assigned to, and will always have its default value null

        private void HabilitaBotonSegunEstado(OrdenCompraStatusManager.StatusItem status)
        {
            switch (status)
            {
                case OrdenCompraStatusManager.StatusItem.Inicial:
                    btnCancelar.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnCerrar.Enabled = false;
                    btnUpdate.Enabled = false;
                    break;
                case OrdenCompraStatusManager.StatusItem.Parcial:
                    btnCancelar.Enabled = true;
                    btnAgregar.Enabled = false;
                    btnCerrar.Enabled = true;
                    btnUpdate.Enabled = true;
                    break;
                case OrdenCompraStatusManager.StatusItem.Completo:
                    btnCancelar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btnUpdate.Enabled = false;
                    break;
                case OrdenCompraStatusManager.StatusItem.Excedido:
                    btnCancelar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btnUpdate.Enabled = false;
                    break;
                case OrdenCompraStatusManager.StatusItem.Cancelado:
                    btnCancelar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btnUpdate.Enabled = false;
                    break;
                case OrdenCompraStatusManager.StatusItem.CompletoM:
                    btnCancelar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnCerrar.Enabled = false;
                    btnUpdate.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }
        private void FrmOrdenCompraDetalleItem_Load(object sender, EventArgs e)
        {
            InicializaData();

            switch (_modo)
            {
                case 1:
                    txtStatusItem.Text = @"Inicial";
                    txtdItem.Text = @"Sin Definir";
                    btnAgregar.Enabled = true;
                    btnUpdate.Enabled = false;
                    break;

                case 2:
                    MapDbForm();
                    HabilitaBotonSegunEstado(OrdenCompraStatusManager.MapStatusItemFromText(txtStatusItem.Text));
                    btnAgregar.Enabled = false;
                    //btnUpdate.Enabled = true;
                    break;

                case 3:
                    MapDbForm();
                    HabilitaBotonSegunEstado(OrdenCompraStatusManager.MapStatusItemFromText(txtStatusItem.Text));
                    break;

                default:
                    return;
            }
        }

        private void InicializaData()
        {

            txtIdProveedor.Text = _ocHeader.PROVEEDOR.ToString();
            txtTC.Text = _ocHeader.TC.ToString();
            txtNumeroOC.Text = _numeroOC.ToString();

            cmbMaterial.ValueMember = "IdMaterial";
            cmbMaterial.DisplayMember = "IdMaterial";
            rbSoloProveedor.Checked = true;
        }

        private void MapDbForm()
        {
            var con = new FormatAndConversions();
            if (_idItem > 0)
            {
                var itemData = new OrdenCompraManager().GetDataOCItem(_numeroOC, _idItem);
                txtStatusItem.Text = itemData.StatusItem;
                txtdItem.Text = _idItem.ToString();
                cmbMaterial.Text = itemData.MATERIAL;
                txtKg.Text = itemData.CANTIDAD.ToString();
                txtPrecioARS.Text = con.SetCurrency(itemData.PRECIO_UNITARIO_P);
                txtPrecioUSD.Text = con.SetCurrency(itemData.PRECIO_UNITARIO_D);
                if (itemData.PRECIOBASE == itemData.PRECIO_UNITARIO_P)
                    cmbMoneda.Text = "ARS";
                cmbMoneda.Text = "USD";
                txtObservacionItem.Text = itemData.ComentarioI_OC;
            }
        }

        private void rbSoloProveedor_CheckedChanged_1(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb == null) return;

            if (rb.Checked)
            {
                switch (rb.Name)
                {
                    case "rbSoloProveedor":
                        cmbMaterial.DataSource = new MaterialMasterManager().GetListMaterialSuppliedByVendor(Convert.ToInt32(txtIdProveedor.Text));

                        break;
                    case "rbTodos":
                        cmbMaterial.DataSource = new MaterialTypeManager().GetListMaterialAvailableToBuy();


                        break;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex >= 0)
            {
                txtDescripcionItem.Text = MaterialMasterManager.GetSpecificPrimaryInformation(cmbMaterial.Text).MAT_DESC;

                var infoRecord = new VendorInfoRecordManager().GetInfoRecordMaterialVendor(Convert.ToInt32(txtIdProveedor.Text), cmbMaterial.Text);

                if (infoRecord != null)
                {
                    txtUCCantidad.Text = infoRecord.ULTIMACANTIDAD.ToString();
                    txtUCFecha.Text = infoRecord.FULTIMACOMPRA.ToString();
                    txtUCMoneda.Text = infoRecord.MONEDAUCOMPRA;

                    if (infoRecord.MONEDAUCOMPRA == "ARS")
                    {
                        txtUCPrecioARS.Text = infoRecord.ULTIMOPRECIO.ToString();
                        txtUCPrecioUSD.Text = (infoRecord.ULTIMOPRECIO / infoRecord.ULTIMOTC).ToString();
                    }
                    else
                    {
                        txtUCPrecioARS.Text = (infoRecord.ULTIMOPRECIO * infoRecord.ULTIMOTC).ToString();
                        txtUCPrecioUSD.Text = infoRecord.ULTIMOPRECIO.ToString();
                    }

                    txtMaterialProveedor.Text = infoRecord.MATERIAL_PROVEEDOR;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidateInfo() == true)
            {
                if (ckUpdateInfoRecord.Checked == true)
                {
                    new VendorInfoRecordManager().ManageAddUpdateInfoRecord(MapFormToStructureT0065());
                }
                txtdItem.Text = new OrdenCompraManager().UpdateItemOrdenCompra(MapFormToStructureT0061()).ToString();
                MessageBox.Show("Item Agregado Correctamente a la ORDEN DE COMPRA", @"Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbMaterial.SelectedValue = "";
                txtPrecioARS.Text = "";
                txtPrecioUSD.Text = "";
                txtKg.Text = "";
                txtDescripcionItem.Text = "";
                txtMaterialProveedor.Text = "";
                txtStatusItem.Text = "Inicial";
            }
        }

        private bool ValidateInfo()
        {
            return true;
        }

        private T0065_MATERIAL_PROVEEDOR MapFormToStructureT0065()
        {
            var con = new FormatAndConversions();

            T0065_MATERIAL_PROVEEDOR data = new T0065_MATERIAL_PROVEEDOR();
            data.PROVEEDOR = Convert.ToInt32(txtIdProveedor.Text);
            data.MATERIAL_TECSER = cmbMaterial.Text;
            data.MATERIAL_PROVEEDOR = txtMaterialProveedor.Text;
            data.FULTIMACOMPRA = _ocHeader.FECHAOC;
            data.ULTIMACANTIDAD = con.GetDecimal(txtKg.Text);
            data.MONEDAUCOMPRA = cmbMoneda.Text;
            if (cmbMoneda.Text == @"ARS")
            {
                data.ULTIMOPRECIO = con.GetDecimal(txtPrecioARS.Text);
            }
            else
            {
                data.ULTIMOPRECIO = con.GetDecimal(txtPrecioUSD.Text);
            }
            data.ULTIMOTC = con.GetDecimal(txtTC.Text);
            //data.CALIFICACION=
            //data.COMENTARIO=
            data.ACTIVO = true;
            //data.REQUIERAQA=
            //data.FECHA_MODI_PRECIO = 
            //data.FECHA_ALTA=
            //data.FLAG_ALTA=

            return data;
        }

        private T0061_OCOMPRA_I MapFormToStructureT0061()
        {
            var con = new FormatAndConversions();
            var data = new T0061_OCOMPRA_I
            {
                IDITEMCOMPRA = txtdItem.Text == @"Sin Definir" ? 0 : _idItem,
                ORDENCOMPRA = _numeroOC,
                MATERIAL = cmbMaterial.Text,
                MATERIAL_PROVEEDOR = txtMaterialProveedor.Text,
                REQUISICION = 0,
                CANTIDAD = con.GetDecimal(txtKg.Text),
                PRECIO_UNITARIO_P = con.GetDecimal(txtPrecioARS.Text),
                PRECIO_UNITARIO_D = con.GetDecimal(txtPrecioUSD.Text)
            };
            //data.CANTIDAD_RECIBIDA =
            //data.REMITO=
            //data.FECHARECIBIDO=
            data.PRECIOBASE = cmbMoneda.Text == @"ARS" ? data.PRECIO_UNITARIO_P : data.PRECIO_UNITARIO_D;
            data.TC = con.GetDecimal(txtTC.Text);
            data.StatusItem = "Inicial";
            data.ComentarioI_OC = txtObservacionItem.Text;
            //data.ComentarioI_RE =
            data.ALLRC = false;
            return data;
        }

        private void txtPrecioUSD_Leave(object sender, EventArgs e)
        {
            var con = new FormatAndConversions();
            txtPrecioUSD.Text = con.SetCurrency(txtPrecioUSD.Text);
            txtPrecioARS.Text = con.SetCurrency((con.GetDecimal(txtPrecioUSD.Text) * con.GetDecimal(txtTC.Text)).ToString());
        }

        private void txtPrecioARS_Leave(object sender, EventArgs e)
        {
            var con = new FormatAndConversions();
            txtPrecioARS.Text = con.SetCurrency(txtPrecioARS.Text);
            txtPrecioUSD.Text = con.SetCurrency((con.GetDecimal(txtPrecioARS.Text) / con.GetDecimal(txtTC.Text)).ToString());
        }

        private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMoneda.Text == @"ARS")
            {
                txtPrecioARS.BackColor = Color.GreenYellow;
                txtPrecioUSD.BackColor = Color.SlateGray;
                txtPrecioARS.ReadOnly = false;
                txtPrecioUSD.ReadOnly = true;
            }
            else
            {
                txtPrecioUSD.BackColor = Color.GreenYellow;
                txtPrecioARS.BackColor = Color.SlateGray;
                txtPrecioARS.ReadOnly = true;
                txtPrecioUSD.ReadOnly = false;
            }
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTC.Text) > 0)
            {
                if (cmbMoneda.Text == "ARS")
                {
                    txtPrecioUSD.Text = (Convert.ToDecimal(txtPrecioARS.Text) / Convert.ToDecimal(txtTC.Text)).ToString();
                }
                else
                {
                    txtPrecioARS.Text = (Convert.ToDecimal(txtPrecioUSD.Text) * Convert.ToDecimal(txtTC.Text)).ToString();
                }
            }
        }

        private void txtKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtPrecioARS_TextChanged(object sender, EventArgs e)
        {
            //TextBox textbox = (TextBox)sender;
            //textbox.Text = new FormatAndConversions().EventoFormatoMoneda(textbox.Text);
            //textbox.Select(textbox.Text.Length, 0);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateInfo() == true)
            {
                if (ckUpdateInfoRecord.Checked == true)
                {
                    new VendorInfoRecordManager().ManageAddUpdateInfoRecord(MapFormToStructureT0065());
                }
                txtdItem.Text = new OrdenCompraManager().UpdateItemOrdenCompra(MapFormToStructureT0061()).ToString();

                MessageBox.Show("Item Agregado Correctamente a la ORDEN DE COMPRA", @"Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            new OrdenCompraManager().CancelaItemOrdenCompra(_numeroOC, _idItem);
        }
    }
}
