using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Transactional.MM.Orden_de_Compra;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI.ContabilizacionProveedores;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.FI.Vendor.ConRemito
{
    public partial class FrmFI21AddItemToFactura : Form
    {
        //Este es el Constructor Utilizado
        public FrmFI21AddItemToFactura(FrmFI17VendorContaConRemito formMain, int idItem = -1)
        {
            _idProveedor = formMain.IdVendor.Value;
            _monedaFactura = formMain.MonedaFactura;
            _tipoCambioFactura = formMain.TipoCampio;
            _idItem = idItem;
            _frmConta = formMain;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------------------------
        private readonly FrmFI17VendorContaConRemito _frmConta;
        private readonly int _idItem;
        private readonly int _idProveedor;
        private readonly string _monedaFactura;
        private decimal _tipoCambioFactura;
        private int? _idItem063 = null;
        private T0063_ITEMS_OC_INGRESADOS _data063;
        private decimal _kgFacturar = 0;
        private decimal _precioUnitarioFacturar = 0;
        public decimal TotalItemConta { get; private set; }
        public decimal TotalRedondeo { get; private set; }
        //-----------------------------------------------------------------------------------------------------------------------

        private void FrmAddItemsRemitoAFacturaProveedor_Load(object sender, EventArgs e)
        {
            if (_idItem >= 0)
            {
                MessageBox.Show(@"Funcion de acceso a Items no desarrollada aun");
                return;
            }
            var dataProveedor = new VendorManager().GetSpecificVendor(_idProveedor);
            ckUpdCodigoProveedor.Checked = true;
            txtRazonSocial.Text = dataProveedor.prov_rsocial;
            ckSinConta.Checked = true;

            txtTCFactura.Text = _tipoCambioFactura.ToString("N4");
            ctxtPrecioM1.XReadOnly = true;
            cPrecioTotalMF.XReadOnly = true;
            cPrecioTotalMF.SetValue = 0;
            txtMonDiferenciaRedondeo.Text = _frmConta.MonedaFactura;
            xDiferenciaCorreccionError.SetValue = 0;
            semCorreccionError.SetLights = CtlSemaforo.ColoresSemaforo.Verde;

            txtDiferenciaTotal.Init(0, 10000000, 2, true, false, false);


            txtDifPrecioUnitarioOC.Init(0, 10000000, 4, true, false, false);
            txtTCFactura.Init(0, 100000, 4, true, false, false);
            ckAddOperacionEvolucion.Checked = true;
            ctxtPrecioM1.Text = @"0";
            ctxtPrecioM2.Text = @"0";
            txtDifPrecioUnitarioOC.Text = @"0";
            txtPrecioTotalM1.Text = @"0";
            txtPrecioTotalM2.Text = @"0";
            txtDiferenciaTotal.Text = @"0";

            txtVariacionPrecioPorcentual.Text = 0.ToString();

            ctxtPrecioM1.BackColor = Color.Gray;
            ctxtPrecioM2.BackColor = Color.Gray;

            if (_tipoCambioFactura <= 0)
            {
                _tipoCambioFactura = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            }

            var listaRemitosX = new InterfazItemsIngresados().GetListaRemitosByVendor(_idProveedor);
            if (listaRemitosX.Count > 1)
            {
                MessageBox.Show(
                    $"Atencion Existen {listaRemitosX.Count} remitos sin contabilizar ingresados en el sistema. Recuerde seleccionar el remito correcto antes de proseguir",
                    @"Seleccion de Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cmbNumeroRemito.DataSource = listaRemitosX.ToList();
            txtVariacionMaximaTolerable.Text = @"1%";

            if (_frmConta.HeaderData.TIPO == "L2")
            {
                ckBaseImponible.Checked = false;
                ckBaseImponible.Enabled = false;
            }
            else
            {
                ckBaseImponible.Checked = true;
                ckBaseImponible.Enabled = true;
            }
        }
        private void cmbNumeroRemito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNumeroRemito.SelectedIndex == -1 || string.IsNullOrEmpty(cmbNumeroRemito.Text))
            {
                return;
            }

            dgvItemsRemito.DataSource =
                new InterfazItemsIngresados().GetListOfItemsByVendorRemito(_idProveedor, cmbNumeroRemito.Text);
        }
        private void dgvItemsRemito_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            string nombreColumna = null;

            if (e.RowIndex < 0)
            {
                _idItem063 = null;
                return;
            }
            nombreColumna = "iDDataGridViewTextBoxColumn";
            _idItem063 = Convert.ToInt32(dgv[dgv.Columns[nombreColumna].Index, e.RowIndex].Value);
            _data063 = new InterfazItemsIngresados().GetSpecificRecord((int)_idItem063);
            MapItemData();
            MapCostUcData();
        }
        private void AgregaItem()
        {
            if (_monedaFactura == cmbMonedaConta.SelectedItem.ToString())
            {
                _precioUnitarioFacturar = ctxtPrecioM1.GetValueDecimal;
            }
            else
            {
                _precioUnitarioFacturar = ctxtPrecioM2.GetValueDecimal;
            }

            TotalRedondeo = xDiferenciaCorreccionError.GetValueDecimal; //esto no sirve para nada
            TotalItemConta = cPrecioTotalMF.GetValueDecimal;
            _kgFacturar = cCantidadFacturada.GetValueDecimal;

            var it = new ItemFactura()
            {
                Id63 = _data063.ID,
                NumeroRemito = _data063.NREMITO,
                Material = _data063.IDMATERIAL,
                CantidadFacturar = _kgFacturar,
                GL = txtGlInventario.Text,
                TC = _tipoCambioFactura,
                PrecioU_MonFact = _precioUnitarioFacturar,
                PrecioT_MonFact = TotalItemConta,
                IncluirEVP = ckAddOperacionEvolucion.Checked,
                NumeroItem = _frmConta.Items.Count + 1,
                IncluyeBaseImponible = ckBaseImponible.Checked,
                MonedaPrecioUc = cmbMonedaCosto.SelectedItem.ToString(),
                UpdatePrecioUc = ckAddOperacionEvolucion.Checked
            };

            it.PrecioU_USD = cmbMonedaConta.SelectedItem.ToString() == "ARS" ? ctxtPrecioM2.GetValueDecimal : ctxtPrecioM1.GetValueDecimal;

            if (cmbMonedaCosto.SelectedItem.ToString() == cmbMonedaConta.SelectedItem.ToString())
            {
                it.PrecioUnitarioUc = ctxtPrecioM1.GetValueDecimal;
            }
            else
            {
                it.PrecioUnitarioUc = ctxtPrecioM2.GetValueDecimal;
            }
            _frmConta.Items.Add(it);
            _frmConta.RefrescaDgv();
        }

        private void MapCostUcData()
        {
            var aCosto1 = new ACostoRepo(txtMaterialTS.Text, FormatAndConversions.CCurrencyADecimal(txtTCFactura.Text));
            aCosto1.GetCost();
            if (aCosto1.DatosUc.VendorId < 1)
            {
                //no encontro la data
                txtUCFecha.Text = aCosto1.DatosUc.FechaUCompra.ToString("d");
                txtUCARS.Text = aCosto1.ValorARS.ToString("C2");
                txtUCUSD.Text = aCosto1.ValorUSD.ToString("C2");
                txtUCProveedor.Text = aCosto1.DatosUc.Proveedor;
            }
            else
            {
                txtUCFecha.Text = aCosto1.DatosUc.FechaUCompra.ToString("d");
                txtUCARS.Text = aCosto1.ValorARS.ToString("C2");
                txtUCUSD.Text = aCosto1.ValorUSD.ToString("C2");
                txtUCProveedor.Text = aCosto1.DatosUc.Proveedor;
            }
        }
        private void MapItemData()
        {
            if (_data063 == null)
            {
                MessageBox.Show(@"Ha Ocurrido un Error con este Item. No se puede cargar datos", @"Error de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Material
            txtMaterialTS.Text = _data063.IDMATERIAL;
            txtMaterialTsDescripcion.Text =
                MaterialMasterManager.GetSpecificPrimaryInformation(txtMaterialTS.Text).MAT_DESC;
            //Codigo Proveedor // inforecord
            var dataInfoRecord = new VendorInfoRecordManager().GetInfoRecordMaterialVendor(_data063.PROVEEDOR.Value,
                _data063.IDMATERIAL);
            if (dataInfoRecord != null)
            {
                txtMaterialProveedor.Text = dataInfoRecord.MATERIAL_PROVEEDOR;
                semInfoRecord.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            }
            else
            {
                semInfoRecord.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
            }

            //** Datos Recepcion IC
            txtKgIngresadosIC.Text = _data063.CANTIDAD.Value.ToString("n2");
            txtComentarioIC.Text = _data063.ObservacionIngreso;
            txtDiferenciaKgIC_Factu.Text = txtKgIngresadosIC.Text;
            semDiferenciaKg.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            txtVariacionKgIcPorcentaje.Text = 1.ToString("P2");
            cmbMonedaConta.SelectedValue = @"USD";  //Moneda ingreso precio
            cmbMonedaConta.SelectedValue = @"USD";   //Moneda registro costo unitario

            //Mapeo de datos de Orden de Compra
            var dataOC = new OrdenCompraManager().GetDataOCItem(_data063.NUM_OC.Value, _data063.IdItemOC);
            if (dataOC == null)
            {
                MessageBox.Show(
                    @"Debido a un problema de datos [Version Anterior] no se puede cargar la informacion directamente desde la OC por lo que la info unitaria puede sufrir distorsiones",
                    @"Datos Incompatibles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (_data063.MON_OC == "ARS")
                {
                    //Moneda de la OC = ARS
                    txtMonOC.Text = @"ARS";
                    if (_data063.PRECIO_U_ARS == null)
                        _data063.PRECIO_U_ARS = 0;
                    txtPrecioOC.Text = _data063.PRECIO_U_ARS.Value.ToString("C2");
                    if (_frmConta.MonedaFactura == "ARS")
                    {
                        //Moneda Factura ARS - Se compara contra el PU de la OC
                        txtMonFactura1.Text = @"ARS";
                        txtPrecioOCenMonedaFactura.Text = _data063.PRECIO_U_ARS.Value.ToString("C4");
                    }
                    else
                    {
                        //Moneda Factura USD - Se compara contra el PU-ARS convertido a USD por TC Factura
                        //Esta situacion no debiera ocurrir ya que es raro que una cotizacion la pasen en ARS y facturen en USD
                        MessageBox.Show(
                            @"Revisar la generacion de la OC porque el item esta cotizado en ARS y la factura esta contabilizada en USD",
                            @"Diferencia de Monedas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMonFactura1.Text = @"USD";
                        txtPrecioOCenMonedaFactura.Text = (_data063.PRECIO_U_ARS.Value / _tipoCambioFactura).ToString("C4");
                    }
                }
                else
                {
                    //Moneda de la OC = USD
                    txtMonOC.Text = @"USD";
                    if (_data063.PRECIO_U_USD == null)
                        _data063.PRECIO_U_USD = 0;
                    txtPrecioOC.Text = _data063.PRECIO_U_USD.Value.ToString("C2");
                    if (_frmConta.MonedaFactura == "ARS")
                    {
                        //Moneda Factura ARS - Se compara contra el PU de la OC en USD convertido a ARS por TC Factura
                        //Esta situacion es la mas normal donde la cotizacion viene en USD y se contabiliza en ARS pero
                        //recalculamos con el USD de la factura para no tener variaciones por TC
                        txtMonFactura1.Text = @"ARS";
                        txtPrecioOCenMonedaFactura.Text = (_data063.PRECIO_U_USD.Value * _tipoCambioFactura).ToString("C4");
                    }
                    else
                    {
                        //Moneda Factura USD
                        txtMonFactura1.Text = @"USD";
                        txtPrecioOCenMonedaFactura.Text = _data063.PRECIO_U_USD.Value.ToString("C4");
                    }
                }
            }
            else
            {
                //Se cargan los datos desde la OC#
                if (dataOC.PRECIOBASE == dataOC.PRECIO_UNITARIO_D)
                {
                    //moneda item OC =USD
                    txtMonOC.Text = @"USD";
                }
                else
                {
                    //moneda item OC =ARS
                    txtMonOC.Text = @"ARS";
                    if (_frmConta.MonedaFactura == "USD")
                    {
                        //Esta situacion no debiera ocurrir ya que es raro que una cotizacion la pasen en ARS y facturen en USD
                        MessageBox.Show(
                            @"Revisar la generacion de la OC porque el item esta cotizado en ARS y la factura esta contabilizada en USD",
                            @"Diferencia de Monedas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                txtPrecioOC.Text = dataOC.PRECIOBASE.Value.ToString("C3");
                if (_frmConta.MonedaFactura == "ARS")
                {
                    txtMonFactura1.Text = @"ARS";
                    txtPrecioOCenMonedaFactura.Text = dataOC.PRECIO_UNITARIO_P.Value.ToString("C3");
                }
                else
                {
                    txtMonFactura1.Text = @"USD";
                    txtPrecioOCenMonedaFactura.Text = dataOC.PRECIO_UNITARIO_D.Value.ToString("C3");
                }

            }


            //Datos Contabilizacion Item

            var infoRec = new VendorInfoRecordManager().GetInfoRecordMaterialVendor(_idProveedor, txtMaterialTS.Text);
            if (infoRec == null)
            {
                MessageBox.Show(
                    @"No Existe un Inforecord para este proveedor. Si desea puede dar de alta el Codigo Proveedor para futuras consultas",
                    @"Datos Inforecord", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (string.IsNullOrEmpty(infoRec.MATERIAL_PROVEEDOR))
                {
                    MessageBox.Show(
                        @"No Existe un Inforecord para este proveedor. Si desea puede dar de alta el Codigo Proveedor para futuras consultas",
                        @"Datos Inforecord", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtMaterialProveedor.Text = infoRec.MATERIAL_PROVEEDOR;
                }
            }
            //txtDfierenciaKgRecepcion.Text = 0.ToString("N2");
            cmbMonedaConta.SelectedValue = _frmConta.MonedaFactura;
            //dTxtCantidadFactura.Text = "0";

            if (string.IsNullOrEmpty(_data063.GL))
            {
                txtGlInventario.Text = GLAccountManagement.GetGLInventarioMaterialMaster(_data063.IDMATERIAL);
            }
            else
            {
                txtGlInventario.Text = _data063.GL;
            }
            txtGlInventarioDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlInventario.Text);
        }
        private void txtGlInventario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGlInventario.Text))
            {
                txtGlInventario.Text = @"0.0.0.0";
                txtGlInventarioDescripcion.Text = @"No Identificado";
            }
            else
            {
                txtGlInventarioDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(txtGlInventario.Text);
            }
        }
        private bool ValidaDatosCompletos()
        {

            var vx = new ValidacionManager(this, ep, toolTip1);
            if (_frmConta.Items.Find(c => c.Id63 == _idItem063) != null)
            {
                MessageBox.Show(@"Este Item ya se encuentra agregado al Remito", @"Error en Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            vx.Valida(cCantidadFacturada, _kgFacturar <= 0, "Los KG a Contabilizar deben ser mayor a CERO");
            vx.Valida(cmbMonedaConta, cmbMonedaConta.SelectedItem == null,
                "Debe Seleccionar una Moneda para el Ingreso del Precio del Material");
            vx.Valida(ctxtPrecioM1, ctxtPrecioM1.GetValueDecimal <= 0, "El Precio del Item no puede ser Igual a $0.00");
            vx.Valida(cmbMonedaCosto, cmbMonedaCosto.SelectedItem == null,
                "Debe Seleccionar una Moneda Para el Registro del Costo UC");

            if (ckAddOperacionEvolucion.Checked == false)
            {
                var r = MessageBox.Show(
                    @"Confirma que este Costo no sera tenido en cuenta para la Evolucion de Costo Repo?",
                    @"Confirmacion Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return false;
            }

            return vx.GetResultadoValidacion();

        }
        private bool ValidaDiferenciasAceptables()
        {
            //chequear diferencias entre KG Recibidos y Facturados
            //chequear diferencias entre Costo OC y Costo Facturado
            //chequear diferencias redondeo
            return true;
        }

        private void btnAddItem0_Click(object sender, EventArgs e)
        {

            if (ValidaDatosCompletos() == false)
            {
                MessageBox.Show(@"Corrija todos los Errores para continuar con la Alta del Item en Factura",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ckIgnorarDiferencias.Checked == false)
            {
                if (ValidaDiferenciasAceptables() == false)
                {
                    MessageBox.Show(
                        @"Hay diferencias de Precios y/o KG que no permiten continuar con la Contabilizacion. Se Requiere Autorizacion para continuar",
                        @"Diferencias Significativas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            AgregaItem();
            if (ckUpdCodigoProveedor.Checked)
            {
                var z = new VendorInfoRecordManager().UpdateCodigoMaterialProveedor(_idProveedor, txtMaterialTS.Text, txtMaterialProveedor.Text);
                if (!z)
                {
                    MessageBox.Show(@"No se ha podido actualizar el inforecord porque el mismo no existe",
                        @"Error en Actualizacion de InfoRecord", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            _frmConta.SumaImportes(true, true);
        }
        private void btnRegresar0_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void dgvItemsRemito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            int numeroOC = 0;
            if (datagridview[nUMOCDataGridViewTextBoxColumn.Name, e.RowIndex].Value != null)
            {
                numeroOC = Convert.ToInt32(datagridview[nUMOCDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            }


            //var activo = Convert.ToBoolean(datagridview[aCTIVODataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "VerOC":

                    using (var f0 = new FrmMM21DatosOC(numeroOC, 2))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                        }
                    }

                    break;

                case "VerIC":
                    MessageBox.Show(@"Funcionalidad en Construccion");
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void ckSinConta_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmbMonedaConta_SelectedValueChanged(object sender, EventArgs e)
        {
            //Reset Valores
            ctxtPrecioM1.SetValue = 0;
            ctxtPrecioM2.SetValue = 0;
            ctxtPrecioM1.BackColor = Color.LightGray;

            if (cmbMonedaConta.SelectedItem == null)
            {
                ctxtPrecioM1.XReadOnly = true;
                ctxtPrecioM2.XReadOnly = true;
                return;
            }

            if (cmbMonedaConta.SelectedItem.ToString() == "ARS")
            {
                txtMon1.Text = @"ARS";
                txtMon2.Text = @"USD";
                labTotalm1.Text = @"Total ARS";
                labTotalm2.Text = @"Total USD";
            }
            else
            {
                txtMon1.Text = @"USD";
                txtMon2.Text = @"ARS";
                labTotalm1.Text = @"Total USD";
                labTotalm2.Text = @"Total ARS";
            }
            RecalculaPrecioTotal();
            if (cmbMonedaConta.SelectedItem != null && _kgFacturar > 0)
            {
                ctxtPrecioM1.XReadOnly = false;
                ctxtPrecioM1.BackColor = Color.White;
            }
            else
            {
                ctxtPrecioM1.XReadOnly = true;
                ctxtPrecioM1.BackColor = Color.LightGray;
            }
        }

        private void ResetPrecioValues()
        {
            txtPrecioTotalM1.Text = 0.ToString("C2");
            txtPrecioTotalM2.Text = 0.ToString("C2");
            cPrecioTotalMF.SetValue = 0;
            ctxtPrecioM2.SetValue = 0;
            xDiferenciaCorreccionError.SetValue = 0;
            //ver que mas resetear aqui
            //Estadisticas de variacion con OC
        }
        private void RecalculaPrecioTotal()
        {
            cPrecioTotalMF.SetValue = 0;
            xDiferenciaCorreccionError.SetValue = 0;
            if (ctxtPrecioM1.GetValueDecimal <= 0)
            {
                ResetPrecioValues();
                return;
            }

            if (cmbMonedaConta.SelectedItem == null)
            {
                ResetPrecioValues();
                return;
            }

            if (_kgFacturar == 0)
            {
                ResetPrecioValues();
                return;
            }
            ctxtPrecioM1.BackColor = Color.White;

            decimal precio2 = 0;
            if (cmbMonedaConta.SelectedItem.ToString() == "ARS")
            {
                precio2 = ctxtPrecioM1.GetValueDecimal / _tipoCambioFactura;
                ctxtPrecioM2.SetValue = precio2;
            }
            else
            {
                //si el precioU se ingresa en USD
                precio2 = ctxtPrecioM1.GetValueDecimal * _tipoCambioFactura;
                ctxtPrecioM2.SetValue = precio2;
            }
            txtPrecioTotalM1.Text = (_kgFacturar * ctxtPrecioM1.GetValueDecimal).ToString("C2");
            txtPrecioTotalM2.Text = (_kgFacturar * precio2).ToString("C2");

            if (_frmConta.MonedaFactura == cmbMonedaConta.SelectedItem.ToString())
            {
                cPrecioTotalMF.SetValue = _kgFacturar * ctxtPrecioM1.GetValueDecimal;
            }
            else
            {
                cPrecioTotalMF.SetValue = _kgFacturar * precio2;
            }

            //Calculo de Diferencia de Precio
            if (txtMonOC.Text == cmbMonedaConta.Text)
            {
                //La M de la OC es la misma que la moneda de contabilizacion
                txtMonDifPrecio.Text = txtMonOC.Text;
                txtDifPrecioUnitarioOC.Text = (ctxtPrecioM1.GetValueDecimal - FormatAndConversions.CCurrencyADecimal(txtPrecioOC.Text)).ToString("C3");
                txtDiferenciaTotal.Text =
                    (FormatAndConversions.CCurrencyADecimal(txtDifPrecioUnitarioOC.Text) * _kgFacturar).ToString("C3");
                txtMonDifPrecio.Text = @"ARS";
                decimal vp = FormatAndConversions.CCurrencyADecimal(txtDifPrecioUnitarioOC.Text) /
                             FormatAndConversions.CCurrencyADecimal(txtPrecioOC.Text);
                txtVariacionPrecioPorcentual.Text = vp.ToString("P2");
            }
            else
            {
                if (txtMonOC.Text == @"ARS")
                {
                    //Moneda Contabilizacion = 'USD' / OC = 'ARS'
                    //Si contabilizo en USD la diferencia la muestro en USD.
                    decimal precioOC_USD = FormatAndConversions.CCurrencyADecimal(txtPrecioOC.Text) / txtTCFactura.ValueD;
                    txtDifPrecioUnitarioOC.Text = (ctxtPrecioM1.GetValueDecimal - precioOC_USD).ToString("C3");
                    txtDiferenciaTotal.Text =
                                    (FormatAndConversions.CCurrencyADecimal(txtDifPrecioUnitarioOC.Text) * _kgFacturar).ToString("C3");

                    txtMonDifPrecio.Text = @"USD";
                    decimal vp = ((ctxtPrecioM1.GetValueDecimal - precioOC_USD)) / precioOC_USD;
                    txtVariacionPrecioPorcentual.Text = vp.ToString("P2");
                }
                else
                {
                    //Moneda Contabilizacion = 'ARS' / OC = 'USD
                    //muestro la diferencia tambien en USD
                    decimal precioOC_USD = FormatAndConversions.CCurrencyADecimal(txtPrecioOC.Text);
                    decimal varPrecioOC = precio2 - precioOC_USD;
                    txtDifPrecioUnitarioOC.Text = (precio2 - precioOC_USD).ToString("C3");
                    txtDiferenciaTotal.Text =
                                    (FormatAndConversions.CCurrencyADecimal(txtDifPrecioUnitarioOC.Text) * _kgFacturar).ToString("C3");
                    txtMonDifPrecio.Text = @"USD";
                    decimal vp = varPrecioOC / precioOC_USD;
                    txtVariacionPrecioPorcentual.Text = vp.ToString("P2");

                }
            }
            txtMonTotalConta.Text = _monedaFactura;
            cPrecioTotalMF.SetValue = _monedaFactura == cmbMonedaConta.SelectedItem.ToString()
                ? txtPrecioTotalM1.ValueD
                : txtPrecioTotalM2.ValueD;
        }


        private void cCantidadFacturada_Validated(object sender, EventArgs e)
        {
            _kgFacturar = cCantidadFacturada.GetValueDecimal;
            var kgIc = Convert.ToDecimal(txtKgIngresadosIC.Text);
            var difKg = kgIc - cCantidadFacturada.GetValueDecimal;
            txtDiferenciaKgIC_Factu.Text = difKg.ToString("N2");
            var difKgPorcentual = difKg / kgIc;
            txtVariacionKgIcPorcentaje.Text = difKgPorcentual.ToString("P2");
            if (difKgPorcentual == 0)
            {
                semDiferenciaKg.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
            }
            else
            {
                if (difKgPorcentual < (decimal)0.5)
                {
                    semDiferenciaKg.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
                }
                else
                {
                    semDiferenciaKg.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                }
            }
            ctxtPrecioM1.XReadOnly = true;
            if (cmbMonedaConta.SelectedItem != null && _kgFacturar > 0)
            {
                ctxtPrecioM1.XReadOnly = false;
            }
            RecalculaPrecioTotal();
        }
        private void ctxtPrecioM1_Validated(object sender, EventArgs e)
        {
            //al abandonar el precioM1 
            RecalculaPrecioTotal();
            cPrecioTotalMF.XReadOnly = !(ctxtPrecioM1.GetValueDecimal > 0);
        }
        private void cPrecioTotalMF_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            decimal valorContaOriginal;
            if (_frmConta.MonedaFactura == cmbMonedaConta.SelectedItem.ToString())
            {
                valorContaOriginal = _kgFacturar * ctxtPrecioM1.GetValueDecimal;
            }
            else
            {
                valorContaOriginal = _kgFacturar * ctxtPrecioM2.GetValueDecimal;
            }
            var difRedondeo = valorContaOriginal - cPrecioTotalMF.GetValueDecimal;

            if (Math.Abs(difRedondeo) > 5)
            {
                MessageBox.Show(@"El Redondeo supera el Limite Maximo establecido.", @"Redondeo No Autorizado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
                semCorreccionError.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
            }
            else
            {
                xDiferenciaCorreccionError.Text = difRedondeo.ToString("C3");
                if (difRedondeo == 0)
                {
                    semCorreccionError.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                }
                else
                {
                    semCorreccionError.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
                }

            }
        }
    }
}

