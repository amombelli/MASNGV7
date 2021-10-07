using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Transactional.CRM;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CRM;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.SD;
using Tecser.Business.Transactional.WM;
using TecserEF.Entity;

namespace MASngFE.Transactional.SD.SalesOrder
{
    public partial class FrmSD03SoDetalleItem : Form
    {
        /// <summary>
        /// Modo = 1 AddItem, 2EditItem, 3ViewItem
        /// </summary>
        public FrmSD03SoDetalleItem(FrmSD02SalesOrderMain formMain, int idItem, int modo)
        {
            _idSO = formMain.NumeroSO;
            _idItem = idItem;
            _modo = modo;
            _formSalesOrderMain = formMain;
            _idCliente6 = formMain.IdClienteT6;
            InitializeComponent();
        }
        private string _materialAka;
        private readonly int _idSO;
        private int _idItem;
        private readonly int _idCliente6;
        private readonly int _modo;
        private readonly FrmSD02SalesOrderMain _formSalesOrderMain;
        private T0047_MATERIAL_CLIENTE _infoRecord = new T0047_MATERIAL_CLIENTE();
        private SalesOrderStatusManager.StatusItem _statusItem;

        private void FrmSalesOrderItemDetail_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + @" " + _formSalesOrderMain.NumeroSO.ToString();
            txtNumeroSo.Text = _idSO.ToString();
            txtItem.Text = _idItem.ToString();
            ConfiguraDefaultValues();
            ConfiguraAccionSegunModo();
            var custX = new CustomerManager().GetCustomerBillToData(_idCliente6);

            if (custX.AllowL1 == null)
                custX.AllowL1 = false;

            if (custX.AllowL2 == null)
                custX.AllowL2 = false;

            if (custX.AllowL5 == null)
                custX.AllowL5 = false;

            if (custX.AllowL1 == false && custX.AllowL2 == false && custX.AllowL5 == false)
            {
                MessageBox.Show(@"El Cliente no posee ninguna condicion de Venta definida",
                    @"Atencion Condicion LX inexistente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }


            if (custX.AllowL1.Value == true)
            {
                cmbLX.Items.Add("L1");
            }
            if (custX.AllowL2.Value == true)
            {
                cmbLX.Items.Add("L2");
            }
            if (custX.AllowL5.Value == true)
            {
                cmbLX.Items.Add("L5");
            }
        }
        private void ConfiguraAccionSegunModo()
        {
            switch (_modo)
            {
                case 1:
                    //nuevo item
                    btnAdd.Enabled = true;
                    txtModoUso.Text = @"NUEVO ITEM";
                    txtModoUso.BackColor = Color.Blue;
                    txtStatusItem.Text = SalesOrderStatusManager.StatusItem.Inicial.ToString();
                    break;
                case 2:
                    LoadItemData();
                    switch (_statusItem)
                    {
                        case SalesOrderStatusManager.StatusItem.Inicial:
                            txtModoUso.Text = @"EDICION";
                            txtModoUso.BackColor = Color.Crimson;
                            break;
                        case SalesOrderStatusManager.StatusItem.Pendiente:
                            txtModoUso.Text = @"EDICION";
                            txtModoUso.BackColor = Color.Crimson;
                            btnCancelarItem.Enabled = true;
                            btnCancelarItem.Visible = true;
                            btnGuardarEdicion.Enabled = true;
                            break;
                        case SalesOrderStatusManager.StatusItem.Parcial:
                            txtModoUso.Text = @"EDICION LIM";
                            txtModoUso.BackColor = Color.LightSeaGreen;
                            btnCerrarManual.Enabled = true;
                            btnCerrarManual.Visible = true;
                            btnGuardarEdicion.Enabled = true;
                            break;
                        case SalesOrderStatusManager.StatusItem.Despachado:
                            txtModoUso.Text = @"VISUALIZACION";
                            txtModoUso.BackColor = Color.Yellow;
                            break;
                        case SalesOrderStatusManager.StatusItem.CerradoM:
                            txtModoUso.Text = @"VISUALIZACION";
                            txtModoUso.BackColor = Color.Yellow;
                            break;
                        case SalesOrderStatusManager.StatusItem.Cancelado:
                            txtModoUso.Text = @"VISUALIZACION";
                            txtModoUso.BackColor = Color.Yellow;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(_statusItem.ToString());
                    }
                    break;
                case 3:
                    LoadItemData();
                    txtModoUso.Text = @"VISUALIZACION";
                    txtModoUso.BackColor = Color.Yellow;
                    break;
                default:
                    break;
            }
        }
        private void LoadItemData()
        {
            var data = new SalesOrderDataManager().GetDataItemFromDb(_idSO, _idItem);
            if (data != null)
            {
                cmbMaterialAKA.Text = data.Material;
                cmbMaterialAKA.Enabled = false;
                txtCodigoCliente.Text = data.Material_Cli;
                ckSoloLlevadosPorCiente.Checked = true;
                txtStatusItem.Text = data.StatusItem;
                txtCantidad.Text = data.Cantidad.ToString("N2");
                txtKGdespachados.Text = data.KGStockDespachados.ToString("N2");
                txtKgPendienteDespacho.Text = (data.Cantidad - data.KGStockDespachados).ToString("N2");
                txtUnidadMedida.Text = @"Kg";
                cmbLX.Text = data.MODO;
                cmbLX.Enabled = false;
                cmbMoneda.Text = data.MonedaCotiz;
                cmbMoneda.Enabled = false;
                txtPrecioL1.Text = data.PRECIO1.ToString("C2");
                txtPrecioL2.Text = data.PRECIO2.ToString("C2");
                txtPrecioTotal.Text = data.PrecioUnitario.ToString("C2");
                txtKgStockReservados.Text = data.KGStockComprometido.ToString("N2");
                if (data.FechaCompromiso != null)
                    dtpFechaCompromiso.Value = data.FechaCompromiso.Value;
                txtObservacionItem.Text = data.ObservacionItem;
                cmbPrioridad.Text = data.PRIORIDAD;
                btnComprometer.Enabled = false;
                btnAdd.Enabled = false;
                btnGuardarEdicion.Enabled = false;
                btnRepetirUltimaCompra.Enabled = false;
                //
                txtTotalStockInPlant.Text = new StockAvilability().TotalStockInPlant(cmbMaterialAKA.Text, "CERR").ToString("N2");
                txtStockAvailableDelivery.Text = new StockAvilability().AvailableStockForDespacho(cmbMaterialAKA.Text, "CERR").ToString("N2");
                //
                crmCustomerDataListBindingSource.DataSource = new CrmCustomerDataList().GetData(_idCliente6, cmbMaterialAKA.Text).ToList();
                dgvCRM.DataSource = crmCustomerDataListBindingSource;
                _statusItem = SalesOrderStatusManager.MapStatusItemFromText(data.StatusItem);
            }
        }
        private void ConfiguraDefaultValues()
        {
            this.cmbMaterialAKA.SelectedIndexChanged -= new System.EventHandler(this.cmbMaterialAKA_SelectedIndexChanged);
            cmbPrioridad.Text = @"NORMAL";
            cmbMaterialAKA.ValueMember = "Material";
            cmbMaterialAKA.DisplayMember = "Material";
            ckSoloLlevadosPorCiente.Checked = true;
            cmbMaterialAKA.SelectedIndex = -1;
            this.cmbMaterialAKA.SelectedIndexChanged += new System.EventHandler(this.cmbMaterialAKA_SelectedIndexChanged);

            dtpFechaCompromiso.Value = DateTime.Now.AddDays(3);
            txtCantidad.Text = 0.ToString("N2");
            txtUnidadMedida.Text = @"KG";
            txtPrecioL1.Text = 0.ToString("N2");
            txtPrecioL2.Text = 0.ToString("N2");
            txtPrecioTotal.Text = 0.ToString("N2");
            txtKGdespachados.Text = 0.ToString("N2");
            txtKgPendienteDespacho.Text = 0.ToString("N2");
            btnComprometer.Enabled = false;
            btnAdd.Enabled = false;
            btnGuardarEdicion.Enabled = false;
            btnRepetirUltimaCompra.Enabled = false;
            btnCerrarManual.Enabled = false;
            btnCancelarItem.Enabled = false;
            btnCancelarItem.Visible = false;
            btnCerrarManual.Visible = false;
            cmbMaterialAKA.Text = null;
            txtInformacionMaterial.Text = null;
            txtCodigoCliente.Text = null;
            txtKGdespachados.Text = 0.ToString("N2");
            txtKgPendienteDespacho.Text = 0.ToString("N2");
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje + Environment.NewLine + @"Complete/Corrija el datos y vuelva a intentar.",
                @"Error en validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool ValidaDatosItemCompleto()
        {
            if (string.IsNullOrEmpty(cmbMaterialAKA.Text))
            {
                MensajeError("Debe Seleccionar un material");
                return false;
            }

            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MensajeError("Cantidad de Kg debe ser superior a 0.01");
                return false;
            }

            if (Convert.ToDecimal(txtCantidad.Text) <= 0)
            {
                MensajeError("Cantidad de Kg debe ser superior a 0.01");
                return false;
            }

            if (string.IsNullOrEmpty(cmbMoneda.Text))
            {
                MensajeError("Moneda de Cotizacion no puede estar vacia");
                return false;
            }

            if (string.IsNullOrEmpty(cmbLX.Text))
            {
                MensajeError("Condicion de Venta no puede estar vacia");
                return false;
            }

            if (dtpFechaCompromiso.Value < DateTime.Now)
            {
                MensajeError("La fecha de Compromiso no puede ser menor a la fecha de hoy");
                return false;
            }

            if ((FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) + FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text)) == 0)
            {
                var resp = MessageBox.Show(@"Confirma que le precio de venta final es = $0.00?", @"PRECIO DE VENTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                {
                    MensajeError("Corrija el Precio de Venta L1.L2");
                    return false;
                }
                else
                {
                    //todo Activar
                    //  new EmailManager().SendEmail("marcelo@mombellisrl.com.ar", "SO#" + _idSO + ">>PRECIO DE VENTA =0", "VERIFICACION DE PRECIO.");
                }
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSD04MotivosSc.MotivoSc motivoSinCargo = FrmSD04MotivosSc.MotivoSc.NoAplica;
            string autorizoSinCargo = null;

            if (cmbMaterialAKA.SelectedItem == null)
            {
                MessageBox.Show(@"No se puede agregar el Item porque aún no seleccionó el material",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Convert.ToInt32(FormatAndConversions.CCurrencyADecimal(txtPrecioTotal.Text)) == 0)
            {


                var resp = MessageBox.Show(@"Confirma el agregado del Material con Precio $0.00 ?",
                    @"Confirmacion de Precio", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resp == DialogResult.No)
                    return;

                using (var f0 = new FrmSD04MotivosSc(_idSO, 0, cmbMaterialAKA.SelectedValue.ToString(), _idCliente6))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        motivoSinCargo = f0.Motivo;
                        autorizoSinCargo = f0.Autorizo;
                    }
                    else
                    {
                        MessageBox.Show(@"Se ha cancelado la Operacion de Agregado de Material", @"Cancelacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            else
            {
                var dialog = MessageBox.Show(@"Confirma el agregado del material a la Orden de Venta?",
                    @"Material a Orden de Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.No)
                    return;
            }

            if (ValidaDatosItemCompleto() == false)
                return;

            if (string.IsNullOrEmpty(txtKgStockReservados.Text))
                txtKgStockReservados.Text = 0.ToString("N2");

            if (Convert.ToDecimal(txtStockAvailableDelivery.Text) > 0 &&
                (Convert.ToDecimal(txtKgStockReservados.Text) == 0))
            {
                var dialog = MessageBox.Show(@"Continua SIN COMPROMETER material?", @"Compromiso de Material",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;
            }

            var urgente = cmbPrioridad.Text.ToUpper() == "URGENTE";

            var itemToAdd = new T0046_OV_ITEM
            {
                Cantidad = Convert.ToDecimal(txtCantidad.Text),
                StatusItem = SalesOrderStatusManager.StatusItem.Inicial.ToString(),
                ClienteRZ = _idCliente6,
                IDITEM = _idItem,
                IDOV = _idSO,
                LOG_FECHA = DateTime.Now,
                LOG_USER = GlobalApp.AppUsername,
                MODO = cmbLX.Text,
                Material = cmbMaterialAKA.Text,
                Material_Cli = txtCodigoCliente.Text,
                FechaCompromiso = dtpFechaCompromiso.Value,
                MonedaCotiz = cmbMoneda.Text,
                ObservacionItem = txtObservacionItem.Text,
                PRECIO1 = FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text),
                PRECIO2 = FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text),
                PrecioUnitario =
                    FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) +
                    FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text),
                PRIORIDAD = cmbPrioridad.Text,
                CK = urgente,
                materialPrimario = cmbMaterialAKA.SelectedValue.ToString(),
                KGStockComprometido = Convert.ToDecimal(txtKgStockReservados.Text),
                KGStockDespachados = 0,
                FlagStockComprometido = Convert.ToDecimal(txtKgStockReservados.Text) > 0,
                AutorizoPrecioCero = autorizoSinCargo,
            };

            if (motivoSinCargo != FrmSD04MotivosSc.MotivoSc.NoAplica)
            {
                itemToAdd.MotivoPrecioCero = motivoSinCargo.ToString();
            }
            if (new SalesOrderDataManager().AgregaItemSalesOrder(itemToAdd))
            {
                _formSalesOrderMain.Items.Add(itemToAdd);

                //Map data to InfoRecord
                var cliData = new T0047_MATERIAL_CLIENTE()
                {
                    CLIENTE = _idCliente6,
                    MATERIAL = cmbMaterialAKA.Text,
                    MATERIAL_CLI = txtCodigoCliente.Text,
                    PRECIO1 = FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text),
                    PRECIO2 = FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text),
                    modo = cmbLX.Text,
                    MONEDAUCOMPRA = cmbMoneda.Text,
                    ULTIMACANTIDAD = Convert.ToDecimal(txtCantidad.Text)
                };

                new CustomerInfoRecord().UpdateInfoRecord(cliData, _idSO);

                MessageBox.Show(@"El Item se ha agregado a la Orden de Venta en forma Satisfactoria", @"Item Agregado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _formSalesOrderMain.RefrescaDgv();
                BlanqueaDatosNuevoItem();
            }
            else
            {
                MessageBox.Show(@"Ha ocurrido un error al intentar grabar el material en la Sales Order",
                    @"Error en AddItem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (_modo == 1)
            {
                if (cmbMaterialAKA.SelectedValue != null)
                {
                    var r = MessageBox.Show(
                        @"Desea volver sin agregar el material a la Orden de Venta?", @"Regresar SIN AGREGAR material", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (r == DialogResult.Yes)
                    {
                        //chequear si hay material comprometido
                        if (new CompromisoManager().isItemComprometido(_idSO, _idItem))
                        {
                            if (MessageBox.Show(@"Debido a que este Item tiene compromisos de Stock se requiere una doble confirmacion para cancelar el Item" + Environment.NewLine +
                                                @"Confirma voliver sin agregar el material a la Orden de Venta? (Se liberara el Stock Comprometido)", @"Liberacion de Material Comprometido",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                new CompromisoManager().FreeItemComprometidoByItemId(_idSO, _idItem);
                            }
                        }
                    }
                    else
                    {
                        //cancela el boton volver
                        return;
                    }
                }
                else
                {
                    //como la pantalla no tenia material seleccionado cancela el alta
                    //y permite volver sin consultar
                }
            }
            //No necesita hacer ninguna validacion en modo visualizacion
            this.Close();
        }
        private void BlanqueaDatosNuevoItem()
        {
            cmbMaterialAKA.Text = null;
            txtInformacionMaterial.Text = null;
            txtCodigoCliente.Text = null;
            txtCantidad.Text = 0.ToString("N2");
            txtUnidadMedida.Text = null;
            txtPrecioL1.Text = 0.ToString("N2");
            txtPrecioL2.Text = 0.ToString("N2");
            txtPrecioTotal.Text = 0.ToString("N2");
            txtStockAvailableDelivery.Text = null;
            txtTotalStockInPlant.Text = null;
            txtKgStockReservados.Text = 0.ToString("N2");
            btnComprometer.Enabled = false;
            txtObservacionItem.Text = null;
            cmbPrioridad.Text = @"NORMAL";
            txtStatusItem.Text = null;
            btnAdd.Enabled = true;
            _idItem = _idItem + 1;
        }

        private void ckSoloLlevadosPorCiente_CheckedChanged(object sender, EventArgs e)
        {
            cmbMaterialAKA.DataSource = ckSoloLlevadosPorCiente.Checked
                ? new CustomerInfoRecord().GetMaterialList(_idCliente6)
                : new MaterialMasterManager().GetMaterialesVentaVerySimple();
        }
        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtCantidad_Leave_1(object sender, EventArgs e)
        {
            var x = (TextBox)sender;

            if (string.IsNullOrEmpty(x.Text))
                x.Text = 0.ToString("N2");

            if (string.IsNullOrEmpty(txtPrecioL1.Text))
                txtPrecioL1.Text = 0.ToString("C2");

            if (string.IsNullOrEmpty(txtPrecioL2.Text))
                txtPrecioL2.Text = 0.ToString("C2");

            if (string.IsNullOrEmpty(txtPrecioTotal.Text))
                txtPrecioTotal.Text = 0.ToString("C2");

            decimal kg = Convert.ToDecimal(x.Text);

            if (string.IsNullOrEmpty(txtStockAvailableDelivery.Text))
                txtStockAvailableDelivery.Text = 0.ToString("n2");

            decimal kgDisponible = Convert.ToDecimal(txtStockAvailableDelivery.Text);

            if (kg > 0 && kgDisponible > 0)
            {
                btnComprometer.Enabled = true;
            }
            else
            {
                btnComprometer.Enabled = false;
            }

            txtPrecioTotalSinIVA.Text =
                (FormatAndConversions.CCurrencyADecimal(txtPrecioTotal.Text) *
                 Convert.ToDecimal(txtCantidad.Text)).ToString("C2");
        }
        private void txtPrecioL1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecioL1.Text))
            {
                txtPrecioL1.Text = 0.ToString("C2");
            }
            else
            {
                txtPrecioL1.Text = FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text).ToString("C2");
            }

            if (string.IsNullOrEmpty(txtPrecioL2.Text))
            {
                txtPrecioL2.Text = 0.ToString("C2");
            }
            else
            {
                txtPrecioL2.Text = FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text).ToString("C2");
            }

            txtPrecioTotal.Text =
                (FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text)).ToString("C2");

            txtPrecioTotalSinIVA.Text =
                ((FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text)) *
                (Convert.ToDecimal(txtCantidad.Text))).ToString("C2");

        }
        private void ResetInfoAsociadaAMaterial()
        {

        }

        private void ActualizaInfoKgStock()
        {
            txtTotalStockInPlant.Text =
                new StockAvilability().TotalStockInPlant(_materialAka, "CERR").ToString("N2");
            txtStockAvailableDelivery.Text = new StockAvilability().AvailableStockForDespacho(_materialAka, "CERR")
                .ToString("N2");
        }
        private void cmbMaterialAKA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterialAKA.SelectedIndex == -1)
            {
                _materialAka = null;
                txtCodigoPrimario.Text = null;
                txtCodigoCliente.Text = null;
                ResetInfoAsociadaAMaterial();
                return;
            }

            if (cmbMaterialAKA.SelectedValue == null)
            {
                _materialAka = null;
                return;
            }

            _materialAka = cmbMaterialAKA.SelectedValue.ToString();
            var dataMaterial = (RtnMaterialVerySimple)cmbMaterialAKA.SelectedItem;
            txtInformacionMaterial.Text = dataMaterial.Descripcion;

            txtCodigoPrimario.Text = dataMaterial.Primario;
            ActualizaInfoKgStock();
            _infoRecord = new CustomerInfoRecord().InfoRecordClienteMaterial(_idCliente6, _materialAka);
            if (_infoRecord != null)
            {
                txtCodigoCliente.Text = _infoRecord.MATERIAL_CLI;
                if (_infoRecord.FULTIMACOMPRA != null)
                    txtUpFecha.Text = _infoRecord.FULTIMACOMPRA.Value.ToString("d");

                if (_infoRecord.ULTIMOPRECIO != null)
                    txtUpCantidad_.Text = _infoRecord.ULTIMOPRECIO.Value.ToString("C2");

                if (_infoRecord.ULTIMACANTIDAD != null)
                    txtUpCantidad_.Text = _infoRecord.ULTIMACANTIDAD.Value.ToString("N2");

                txtUpMoneda.Text = _infoRecord.MONEDAUCOMPRA;
                txtUpCondicion.Text = @"SD";

                if (_infoRecord.PRECIO1 != null)
                    txtUpPrecioL1.Text = _infoRecord.PRECIO1.Value.ToString("C2");

                if (_infoRecord.PRECIO2 != null)
                    txtUpPrecioL2.Text = _infoRecord.PRECIO2.Value.ToString("C2");
            }


            //reset Ultimo Pedido
            txtUpFecha.Text = null;
            txtUpCantidad_.Text = 0.ToString("N2");
            txtUpMoneda.Text = null;
            txtUpCondicion.Text = null;
            txtUpPrecioL1.Text = 0.ToString("C2");
            txtUpPrecioL2.Text = 0.ToString("C2");
            //Carga datos de inforecord

            var c = (ComboBox)sender;

            var x = c.SelectedIndex;
            if (cmbMaterialAKA.SelectedIndex > -1)
            {


                crmCustomerDataListBindingSource.DataSource =
                    new CrmCustomerDataList().GetData(_idCliente6, txtCodigoPrimario.Text).ToList();
                if (crmCustomerDataListBindingSource.DataSource != null)
                {
                    dgvCRM.DataSource = crmCustomerDataListBindingSource;
                }

                if (string.IsNullOrEmpty(cmbMaterialAKA.SelectedValue.ToString()) == false)
                {

                    if (_infoRecord == null)
                    {
                        MessageBox.Show(@"Atencion: El Cliente esta llevando por primera vez este material.",
                            @"PRIMER PEDIDO DE MATERIAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRepetirUltimaCompra.Enabled = false;
                        txtCodigoCliente.Text = null;
                    }
                    else
                    {
                        btnRepetirUltimaCompra.Enabled = true;
                        if (_infoRecord.MATERIAL_CLI != null)
                            txtCodigoCliente.Text = _infoRecord.MATERIAL_CLI;
                    }
                }
                var pedidosPendientes = new PendientesDespacho().GetPendienteDespachoMaterial(txtCodigoPrimario.Text, _idCliente6);
                if (pedidosPendientes.Count > 0)
                {
                    using (var f = new FrmCRM08PendientePorProducto(txtCodigoPrimario.Text, _idCliente6))
                    {
                        f.ShowDialog();
                    }
                }
            }
        }
        private void btnRepetirUltimaCompra_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = txtUpCantidad_.Text;
            cmbMoneda.Text = txtUpMoneda.Text;
            txtPrecioL1.Text = txtUpPrecioL1.Text;
            txtPrecioL2.Text = txtUpPrecioL2.Text;

        }
        private void btnComprometer_Click(object sender, EventArgs e)
        {
            //if (_estaAgregado == false)
            //{
            //    //debemos agregar el material a la NP antes de comprometer
            //    var msg = MessageBox.Show(@"Antes de comprometer el material, el mismo debe ser agregado a la Nota de Pedido"+ Environment.NewLine+
            //        @"Confirma el alta de este material a la NP?",)
            //}
            using (var f0 = new FrmMM18CompromisoMaterial(_idSO, _idItem, cmbMaterialAKA.Text, Convert.ToDecimal(txtCantidad.Text)))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    txtKgStockReservados.Text = f0.KgReservados.ToString("N2");  //total reservado para el item
                    MessageBox.Show(
                        @"Se ha Reservado/Comprometido correctamente el mateiral para este Item de Nota de Pedido" +
                        Environment.NewLine + $@"La Cantidad total de Kg Comprometidos es de {f0.KgReservados.ToString("N2")} Kg",
                        @"Compromiso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(@"Se ha Cancelado la reserva de stock", @"Reserva de Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtKgStockReservados.Text = f0.KgReservados.ToString("N2");
                }
            }
        }
        private void cmbLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecioL1.Enabled = true;
            txtPrecioL2.Enabled = true;

            if (cmbLX.Text == @"L1")
            {
                txtPrecioL2.Enabled = false;
                txtPrecioL2.Text = 0.ToString("C2");
            }
            else if (cmbLX.Text == @"L2")
            {
                txtPrecioL1.Enabled = false;
                txtPrecioL1.Text = 0.ToString("C2");
            }
            else
            {
                txtPrecioL1.Enabled = true;
                txtPrecioL2.Enabled = true;
                txtPrecioL1.Text = 0.ToString("C2");
                txtPrecioL2.Text = 0.ToString("C2");
            }

            if (string.IsNullOrEmpty(txtPrecioL1.Text))
                txtPrecioL1.Text = 0.ToString("C2");

            if (string.IsNullOrEmpty(txtPrecioL2.Text))
                txtPrecioL2.Text = 0.ToString("C2");

            txtPrecioTotal.Text =
                (FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text)).ToString("C2");

            txtPrecioTotalSinIVA.Text = ((FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text)) * Convert.ToDecimal(txtCantidad.Text)).ToString("C2");

        }
        private void btnGuardarEdicion_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(@"Confirma la edición de los valores de la Nota de Pedido?",
                @"Confirmacion de Edicion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            var urgente = cmbPrioridad.Text.ToUpper() == "URGENTE";
            var itemToUpdate = new T0046_OV_ITEM
            {
                IDOV = _idSO,
                IDITEM = _idItem,

                Cantidad = Convert.ToDecimal(txtCantidad.Text),
                //StatusItem = SalesOrderStatusManager.StatusItem.Inicial.ToString(),
                //ClienteRZ = _idCliente6,
                //LOG_FECHA = DateTime.Now,
                //LOG_USER = Environment.UserDomainName,
                MODO = cmbLX.Text,
                //Material = cmbMaterialAKA.Text,
                Material_Cli = txtCodigoCliente.Text,
                FechaCompromiso = dtpFechaCompromiso.Value,
                MonedaCotiz = cmbMoneda.Text,
                ObservacionItem = txtObservacionItem.Text,
                PRECIO1 = FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text),
                PRECIO2 = FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text),
                PrecioUnitario = FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) + FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text),
                PRIORIDAD = cmbPrioridad.Text,
                CK = urgente,
                //materialPrimario = cmbMaterialAKA.SelectedValue.ToString(),
                KGStockComprometido = Convert.ToDecimal(txtKgStockReservados.Text),
                //KGStockDespachados = 0,
                FlagStockComprometido = Convert.ToDecimal(txtKgStockReservados.Text) > 0,
            };
            if (new SalesOrderDataManager().UpdateItemData(itemToUpdate))
            {
                MessageBox.Show(@"El item se ha actualizado correctamente!", @"Actualizacion de Item",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCerrarManual_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(@"Confirma cerrar este ITEM en forma Manual?" + Environment.NewLine + @"Los Kg Pendientes ya no podrán ser despachados",
                @"Confirmacion de Cierre de Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            SalesOrderStatusManager.SetStatusItemCerradoM(_idSO, _idItem);
        }
        private void btnCancelarItem_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(@"Confirma CANCELAR este ITEM ?",
                @"Confirmacion de Cierre de Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            if (new CompromisoManager().GetKgComprometidosPorSalesOrder(_idSO, _idItem) > 0)
            {
                var resp = MessageBox.Show(
                    @"El Item tiene compromisos de Stock que serán liberados. Desea Continuar con la cancelacion del Item?",
                    @"Cancelar Item de Orden de Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                {
                    return;
                }
                else
                {
                    new CompromisoManager().FreeItemComprometidoByItemId(_idSO, _idItem);
                }
            }
            SalesOrderStatusManager.SetStatusItemCancelado(_idSO, _idItem);
            MessageBox.Show(@"Se ha Cancelado Correctametne el Item", @"Cancelacion de Items", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbMaterialAKA_Validating(object sender, CancelEventArgs e)
        {
            if (cmbMaterialAKA.SelectedValue == null && cmbMaterialAKA.Text != string.Empty)
                e.Cancel = true;
        }

        private void cmbLX_Validating(object sender, CancelEventArgs e)
        {
            if (cmbLX.Text == null && cmbLX.Text != string.Empty)
                e.Cancel = true;

            if (cmbLX.Text == @"L1" || cmbLX.Text == @"L2" || cmbLX.Text == @"L5")
            {

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cmbMoneda_Validating(object sender, CancelEventArgs e)
        {
            if (cmbMoneda.Text == null && cmbLX.Text != string.Empty)
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnGestionarStock_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmMM18CompromisoMaterial(cmbMaterialAKA.Text))
            {
                DialogResult dr = f0.ShowDialog();
            }
            txtStockAvailableDelivery.Text = new StockAvilability().AvailableStockForDespacho(cmbMaterialAKA.Text, "CERR").ToString("N2");
            txtKgStockReservados.Text =
                new CompromisoManager().GetKgComprometidosPorSalesOrder(_idSO, _idItem).ToString("N2");
        }

    }
}
