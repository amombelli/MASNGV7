using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace MASngFE.Transactional.MM
{
    public partial class FrmGeneraOrdenProcesoMolienda : Form
    {
        public FrmGeneraOrdenProcesoMolienda(int modo = 0)
        {
            _modo = modo;
            InitializeComponent();
        }

        private int _idCliente6;
        private int _idCliente7;
        private int _idVendor;
        private int _id63;
        private int _idSO;
        private List<T0011_MATERIALES_AKA> _list;
        private string _numeroRemito;
        private int _idt40;
        private T0046_OV_ITEM _itemOV;
        private string _modolx;
        private decimal _kgFabricar;
        private int _modo;

        private void dgvListaIngreso_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtKgAFabricar.Text = 0.ToString("N2");
            txtKgMerma.Text = 0.ToString("N2");
            txtPorcentajeMerma.Text = 0.ToString("P2");
            cmbMaterialAFabricar.SelectedIndex = -1;
            if (e.RowIndex >= 0)
            {
                _id63 =
                    Convert.ToInt32(
                        dgvListaIngreso[dgvListaIngreso.Columns[iDDataGridViewTextBoxColumn.Name].Index, e.RowIndex]
                            .Value);

                var id40 = dgvListaIngreso[dgvListaIngreso.Columns[ID40.Name].Index, e.RowIndex].Value;
                _numeroRemito =
                    dgvListaIngreso[dgvListaIngreso.Columns[nREMITODataGridViewTextBoxColumn.Name].Index, e.RowIndex]
                        .Value.ToString();

                if (id40 != null)
                {
                    _idt40 = Convert.ToInt32(id40);
                    txtLoteIngreso.Text = MmLog.GetT40Line(_idt40).BATCH;
                }
                else
                {
                    txtLoteIngreso.Text = null;
                }
            }
        }

        private void FrmGeneraOrdenProcesoMolienda_Load(object sender, EventArgs e)
        {
            t0005MPROVEEDORESBindingSource.DataSource = new ReprocesoManagement().GetListadoProveedoresReproceso();
            _list = new MaterialMasterManager().GetCompleteListofAka(true);
            if (ckSoloRepro.Checked)
            {
                t0011MATERIALESAKABindingSource.DataSource = _list.Where(c => c.CODVENTA.StartsWith("R")).ToList();
            }
            else
            {
                t0011MATERIALESAKABindingSource.DataSource = _list;
            }
            dtpFechaCompromiso.Value = DateTime.Today.AddDays(5);
            cmbRazonSocialProveedor.SelectedIndex = -1;
            txtIdProveedor.Text = null;
            cmbMaterialAFabricar.SelectedIndex = -1;
        }

        private void cmbRazonSocialProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocialProveedor.SelectedIndex == -1)
            {
                _idVendor = 0;
                return;
            }
            _idVendor = Convert.ToInt32(cmbRazonSocialProveedor.SelectedValue);
        }

        private void txtId6_TextChanged(object sender, EventArgs e)
        {
            //al asignarse automaticamente el IdCliente6 Desde el proveedor
            if (string.IsNullOrEmpty(txtId6.Text))
            {
                MessageBox.Show(@"No se puede asociar este proveedor con un cliente", @"Error en Datos Proveedor",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _idCliente6 = 0;
                _idCliente7 = 0;
                return;
            }
            _idCliente6 = Convert.ToInt32(txtId6.Text);
            var cli = new CustomerManager().GetCustomerBillToData(_idCliente6);
            txtClienteRazonSocial.Text = cli.cli_rsocial;
            var shiptos = new CustomerManager().GetShipToListFromBillTo(_idCliente6, true);
            if (shiptos.Count > 1)
            {
                using (var f0 = new FrmCustomerShipToSelection(_idCliente6))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        _idCliente7 = f0.SelectedCustomer;
                    }
                    else
                    {
                        MessageBox.Show(
                            @"Se ha cancelado la seleccion de SHIPTO" + Environment.NewLine + @"No se puede continuar",
                            @"Seleccion de SHIPTO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        _idCliente7 = 0;
                    }
                }
            }
            else
            {
                //Existe un solo shipto!
                _idCliente7 = shiptos[0].ID_CLI_ENTREGA;
                txtClienteEntrega.Text = shiptos[0].ClienteEntregaDesc;
            }

            if (_idCliente7 == 0)
            {
                txtClienteEntrega.Text = @"Cliente no Encontrado!";
                txtId7.Text = @"ND";
            }
            else
            {
                var cli7 = new CustomerManager().GetCustomerShipToData(_idCliente7);
                txtClienteEntrega.Text = cli7.ClienteEntregaDesc;
                txtId7.Text = shiptos[0].ID_CLI_ENTREGA.ToString();
                t0063ITEMSOCINGRESADOSBindingSource.DataSource =
                    new ReprocesoManagement().GetLstMaterialesIngresadosByVendor(_idVendor);
            }
        }

        private void txtPorcentajeMerma_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtKgAFabricar_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgAFabricar.Text))
                txtKgAFabricar.Text = 0.ToString("N2");

            if (string.IsNullOrEmpty(txtCantidadRecibida.Text))
                txtCantidadRecibida.Text = 0.ToString("N2");

            var valor = Convert.ToDecimal(txtKgAFabricar.Text);
            var kgreci = Convert.ToDecimal(txtCantidadRecibida.Text);
            if (valor > kgreci)
            {
                MessageBox.Show(@"Los Kg a Fabricar no pueden ser mayores a los Kg Recibidos", @"Kg a Fabricar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            var kgMerma = kgreci - valor;
            decimal porcentajeMerma = 0;

            if (kgreci == 0)
            {
                txtPorcentajeMerma.Text = 1.ToString("P2");
                txtKgMerma.Text = 0.ToString("N2");
            }
            else
            {
                porcentajeMerma = decimal.Round((kgMerma / kgreci), 2);
                txtKgMerma.Text = (kgreci - valor).ToString("N2");
                txtPorcentajeMerma.Text = ((kgreci - valor) / kgreci).ToString("P2");
            }

            txtKgAFabricar.Text = valor.ToString("N2");
            CalculaTotales();

            if (porcentajeMerma > (decimal)0.1)
            {
                var msg = MessageBox.Show(@"Confirma alta de produccion con MERMA tan Alta?", @"Merma demasiado Elevada",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                    e.Cancel = true;
            }
            _kgFabricar = valor;
        }

        private void txtPorcentajeMerma_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPorcentajeMerma.Text))
                txtPorcentajeMerma.Text = 0.ToString("P2");

            decimal valorpor = FormatAndConversions.CPorcentajeADecimal(txtPorcentajeMerma.Text);
            decimal kgreci = Convert.ToDecimal(txtCantidadRecibida.Text);

            if (valorpor > (decimal)0.1)
            {
                MessageBox.Show(@"El Valor de Merma NO PUEDE superar el 10%", @"Kg a Fabricar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            txtKgMerma.Text = (kgreci * valorpor).ToString("n2");
            txtKgAFabricar.Text = (kgreci - (kgreci * valorpor)).ToString("N2");
            _kgFabricar = (kgreci - (kgreci * valorpor));
            txtPorcentajeMerma.Text = valorpor.ToString("P2");
            CalculaTotales();
        }

        private void txtKgMerma_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgMerma.Text))
                txtKgMerma.Text = 0.ToString("N2");

            decimal valorMerma = Convert.ToDecimal(txtKgMerma.Text);
            decimal kgReci = Convert.ToDecimal(txtCantidadRecibida.Text);

            if (valorMerma > (kgReci * (decimal)0.1))
            {
                MessageBox.Show(@"El Valor de KG de Merma NO PUEDE superar el 10% de los KG Recibidos", @"Kg a Fabricar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            if (valorMerma < 0)
            {
                MessageBox.Show(@"Confirma MERMA MENOR A CERO (Kg Adicionales por Agregado de MP)", @"Kg a Fabricar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

            txtKgMerma.Text = valorMerma.ToString("N2");
            txtKgAFabricar.Text = (kgReci - valorMerma).ToString("N2");

            if (kgReci == 0)
            {
                txtPorcentajeMerma.Text = 1.ToString("P2");
            }
            else
            {
                txtPorcentajeMerma.Text = (valorMerma / kgReci).ToString("P2");
            }
            _kgFabricar = kgReci - valorMerma;
            CalculaTotales();
        }

        private void ckSoloRepro_CheckedChanged(object sender, EventArgs e)
        {
            t0011MATERIALESAKABindingSource.DataSource = ckSoloRepro.Checked
                ? _list.Where(c => c.CODVENTA.StartsWith("R")).ToList()
                : _list;
        }

        private void rbL1_CheckedChanged(object sender, EventArgs e)
        {
            txtPrecioL1.Text = 0.ToString("C2");
            txtPrecioL2.Text = 0.ToString("C2");
            txtPrecioTotalSinIVA.Text = 0.ToString("C2");
            txtPrecioTotal.Text = 0.ToString("C2");
            if (rbL1.Checked)
            {
                txtPrecioL1.Enabled = true;
                txtPrecioL2.Enabled = false;
                _modolx = "L1";
            }
            else
            {
                if (rbL2.Checked)
                {
                    txtPrecioL1.Enabled = false;
                    txtPrecioL2.Enabled = true;
                    _modolx = "L2";
                }
                else
                {
                    //L5
                    txtPrecioL1.Enabled = true;
                    txtPrecioL2.Enabled = true;
                    _modolx = "L5";
                }
            }
        }

        private void txtPrecioL1_Leave(object sender, EventArgs e)
        {
            var text = (TextBox)sender;

            text.Text = FormatAndConversions.CCurrencyADecimal(text.Text).ToString("C2");
            CalculaTotales();
        }

        private void CalculaTotales()
        {
            if (string.IsNullOrEmpty(txtPrecioL1.Text))
            {
                txtPrecioL1.Text = 0.ToString("C2");
            }

            if (string.IsNullOrEmpty(txtPrecioL2.Text))
            {
                txtPrecioL2.Text = 0.ToString("C2");
            }

            if (string.IsNullOrEmpty(txtKgAFabricar.Text))
            {
                txtKgAFabricar.Text = 0.ToString("N2");
            }

            txtPrecioTotal.Text =
                (FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text)).ToString("C2");
            //
            txtPrecioTotalSinIVA.Text = ((FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) +
                                          FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text)) *
                                         Convert.ToDecimal(txtKgAFabricar.Text)).ToString("C2");
            //
        }

        private bool ValidarDatosCompletos()
        {
            if (_idCliente6 <= 0)
            {
                MessageBox.Show(@"Debe seleccionar un Proveedor (Ingreso de Material)", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_idCliente7 <= 0)
            {
                MessageBox.Show(@"Debe seleccionar un Cliente (Cliente > Facturar)", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbMaterialAFabricar.SelectedValue == null)
            {
                MessageBox.Show(@"Debe seleccionar un Material para Fabricar", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbMaterialAFabricar.Text == null)
            {
                MessageBox.Show(@"Debe seleccionar un Material para Fabricar", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_kgFabricar <= 0)
            {
                MessageBox.Show(@"Los Kg a Fabricar son Incorrectos", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(_modolx))
            {
                MessageBox.Show(@"Debe Seleccionar un modo de Facturacion LX", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (FormatAndConversions.CCurrencyADecimal(txtPrecioTotal.Text) <= 0)
            {
                MessageBox.Show(@"El Precio Total es Incorrecto", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cmbMoneda.Text))
            {
                MessageBox.Show(@"Debe Seleccionar una MONEDA", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void MapeaItemOV(string prioridad = "BAJA", bool urgente = false)
        {
            _itemOV = new T0046_OV_ITEM
            {
                Cantidad = Convert.ToDecimal(txtKgAFabricar.Text),
                StatusItem = SalesOrderStatusManager.StatusItem.Inicial.ToString(),
                ClienteRZ = _idCliente6,
                IDITEM = 1,
                IDOV = _idSO,
                LOG_FECHA = DateTime.Now,
                LOG_USER = Environment.UserName,
                MODO = _modolx,
                Material = cmbMaterialAFabricar.Text,
                Material_Cli = cmbMaterialAFabricar.SelectedValue.ToString(),
                FechaCompromiso = dtpFechaCompromiso.Value,
                MonedaCotiz = cmbMoneda.Text,
                ObservacionItem = txtComentarioOV.Text,
                PRECIO1 = FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text),
                PRECIO2 = FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text),
                PrecioUnitario =
                    FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text) +
                    FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text),
                //Todo: En sistema viejo preciounitario el el precio total y en L5, precio2 es la parte2
                PRIORIDAD = prioridad,
                CK = urgente,
                materialPrimario = cmbMaterialAFabricar.SelectedValue.ToString(),
                KGStockComprometido = 0,
                KGStockDespachados = 0,
                FlagStockComprometido = false,
                AutorizoPrecioCero = null,
                MotivoPrecioCero = null,
            };

            if (new SalesOrderDataManager().AgregaItemSalesOrder(_itemOV))
            {
                //Map data to InfoRecord
                var cliData = new T0047_MATERIAL_CLIENTE()
                {
                    CLIENTE = _idCliente6,
                    MATERIAL = cmbMaterialAFabricar.Text,
                    MATERIAL_CLI = cmbMaterialAFabricar.SelectedValue.ToString(),
                    PRECIO1 = FormatAndConversions.CCurrencyADecimal(txtPrecioL1.Text),
                    PRECIO2 = FormatAndConversions.CCurrencyADecimal(txtPrecioL2.Text),
                    modo = _modolx,
                    MONEDAUCOMPRA = cmbMoneda.Text,
                    ULTIMACANTIDAD = Convert.ToDecimal(txtKgAFabricar.Text)
                };

                new CustomerInfoRecord().UpdateInfoRecord(cliData, _idSO);

                MessageBox.Show(@"El Item se ha agregado a la Orden de Venta en forma Satisfactoria", @"Item Agregado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosCompletos() == false)
                return;

            var resp = MessageBox.Show(@"Confirma el Ingreso de la Orden de Proceso + Orden de Venta?", @"Confirmacion",
                MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;

            _idSO = new SalesOrderDataManager().InicializaSalesOrderDb(_idCliente7,
                SalesOrderStatusManager.StatusHeader.Emitida.ToString());

            var cli7 = new CustomerManager().GetCustomerShipToData(_idCliente7);

            MapeaItemOV();

            new SalesOrderDataManager().EmiteSalesOrder(_idSO, DateTime.Today, txtComentarioOV.Text,
                cli7.Vendedor, "RE#" + _numeroRemito, "PERSONA");
            //new SalesOrderDataManager().EmiteSalesOrder(_idSO); //revisar aca porque lo modifique ver lineas de abajo 20200728
            //ix = new SalesOrderDataManager().EmiteSalesOrder(NumeroSO, dtpFechaSO.Value, txtComentarioSalesOrder.Text, cmbVendedor.Text, txtNumeroOC.Text, cmbMetodoIngreso.Text);


            txtNumeroOV.Text = _idSO.ToString();
            MmLog.UpdateTipoLx(_idt40, _modolx);
            new ReprocesoManagement().SetContabilizado(_id63, _idSO, _modolx);

            MessageBox.Show(@"Se ha ingresado correctamente la Orden de Proceso", @"Procesamiento de Molienda",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            BlanqueaDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckViewAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckViewAll.Checked)
            {
                btnGenerar.Enabled = false;
                t0063ITEMSOCINGRESADOSBindingSource.DataSource =
                  new ReprocesoManagement().GetLstMaterialesIngresadosByVendor(_idVendor, false);
            }
            else
            {
                btnGenerar.Enabled = true;
                t0063ITEMSOCINGRESADOSBindingSource.DataSource =
                  new ReprocesoManagement().GetLstMaterialesIngresadosByVendor(_idVendor);
            }
            BlanqueaDatos();
        }

        private void BlanqueaDatos()
        {
            cmbMaterialAFabricar.SelectedIndex = -1;
            txtKgAFabricar.Text = 0.ToString("N2");
            txtKgMerma.Text = 0.ToString("N2");
            txtPorcentajeMerma.Text = 0.ToString("P2");
            txtPrecioL1.Text = 0.ToString("C2");
            txtPrecioL2.Text = 0.ToString("C2");
            txtPrecioTotal.Text = 0.ToString("C2");
            txtPrecioTotalSinIVA.Text = 0.ToString("C2");
            txtComentarioOV.Text = null;
            txtComentarioPF.Text = null;
            _idSO = 0;
            _itemOV = null;
            this._kgFabricar = 0;
        }

        private void cmbMaterialAFabricar_Validating(object sender, CancelEventArgs e)
        {
            if (cmbMaterialAFabricar.SelectedValue == null && cmbMaterialAFabricar.Text != string.Empty)
                e.Cancel = true;
        }

        private void cmbMoneda_Validating(object sender, CancelEventArgs e)
        {

            if (cmbMoneda.Text == @"ARS" || cmbMoneda.Text == @"USD")
            { }
            else
            {
                e.Cancel = true;
            }


            //if (cmbMoneda.SelectedValue == null && cmbMoneda.Text != string.Empty)
            //    e.Cancel = true;
        }

        private void cmbMoneda_Validated(object sender, EventArgs e)
        {

        }
    }
}
