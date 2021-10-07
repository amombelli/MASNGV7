using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MASngFE.SuperMD;
using MASngFE.Transactional.FI.ContabilizacioFactura.SinRemito;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.FondoFijo
{
    public partial class FrmImputacionFF : Form
    {
        public FrmImputacionFF()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------------
        private int _vendorId;
        private static DateTime _prevClick;
        private readonly List<T0407_RendicionFF_I> _lItems = new List<T0407_RendicionFF_I>();
        private DateTime? _fechaDocumento = null;
        private readonly Color _colorCkOk = Color.LightGreen;
        private readonly Color _colorCkError = Color.OrangeRed;
        private Color _colorCkSinInicializar = Color.Gold;
#pragma warning disable CS0414 // The field 'FrmImputacionFF._cuitValidado' is assigned but its value is never used
        private bool _cuitValidado;
#pragma warning restore CS0414 // The field 'FrmImputacionFF._cuitValidado' is assigned but its value is never used

        //--------------------------------------------------------------------------
        private void ConfiguraInitialData()
        {
            //
            cmbRazonSocial.Enabled = true;
            cmbFantasia.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNumeroDocumento.Enabled = true;

            if (ckSoloVendorActivo.Checked)
            {
                cmbRazonSocial.DataSource =
                    new VendorManager().GetCompleteListVendors(true).OrderBy(c => c.prov_rsocial).ToList();
                cmbFantasia.DataSource =
                    new VendorManager().GetCompleteListVendors(true).OrderBy(c => c.prov_fantasia).ToList();
            }
            else
            {
                cmbRazonSocial.DataSource =
                    new VendorManager().GetCompleteListVendors(false).OrderBy(c => c.prov_rsocial).ToList();
                cmbFantasia.DataSource =
                    new VendorManager().GetCompleteListVendors(false).OrderBy(c => c.prov_fantasia).ToList();
            }


            t0150CUENTASBindingSource.DataSource = new CuentasManager().GetListaCuentasFondoFijo();
            cmbCuentaFF.SelectedIndex = -1;

            ckMantenerInfoRecord.Checked = false;
            ckMantenerInfoRecord.BackColor = Color.Yellow;
            ResetImportes();

            txtNumeroDocumento.ReadOnly = true;

            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            mskCuit.Text = null;
            txtIdProveedor.Text = null;
            _vendorId = -1;

            ckAutoIVA21.Checked = false;
            ckAutoIVA21.BackColor = Color.Yellow;

            txtId403.Text = @"0";
            txtidCtaCte.Text = @"0";
            txtNAS.Text = @"0";
            txtNumeroDocumento.Text = null;
            cmbTipoDocumento.Text = null;
            txtStatusRendicion.Text = RendicionFF.StatusRendicion.Temporal.ToString();

            t0135GLXFFBindingSource.DataSource = new RendicionFF().GetListGLforFF();
            cmbGlImputacionItem.SelectedIndex = -1;

            _lItems.Clear();
            t0407RendicionFFIBindingSource.DataSource = _lItems;
            //dgvDetalleItems.DataSource = null;
            //dgvDetalleItems.DataSource = t0404VENDORFACTIBindingSource.DataSource;
            btnIngresarRendicion.Enabled = true;
            btnAddItem.Enabled = true;

            txtPrecioU.Text = 0.ToString("C2");
            txtPrecioT.Text = 0.ToString("C2");

            t0085PERSONALBindingSource.DataSource = new HumanResourcesManager().GetListEmployees();
            bsPersonal2.DataSource = new HumanResourcesManager().GetListEmployees();
            cmbUserName.DataSource = new HumanResourcesManager().GetListEmployees();
            cmbAprobadoPor.DataSource = new HumanResourcesManager().GetListEmployees();
            cmbRendicionAprobada.DataSource = new HumanResourcesManager().GetListEmployees();
            cmbRendicionAprobada.SelectedIndex = -1;
            cmbAprobadoPor.SelectedIndex = -1;
            cmbUserName.SelectedValue = Environment.UserName;
        }
        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoDocumento.SelectedIndex < 0)
            {
                txttipoLx.Text = null;
                txtNumeroDocumento.ReadOnly = true;
                return;
            }
            ckAutoIVA21.Checked = false;
            ckAutoIVA21.BackColor = Color.DarkOrange;
            txtNumeroDocumento.ReadOnly = false;
            txttipoLx.Text = @"L1";

            switch (cmbTipoDocumento.Text)
            {
                case "FACTURA A":
                    txtNumeroDocumento.Text = null;
                    txtNumeroDocumento.Mask = @"0000-00000000";
                    txtTipoDocumento.Text = @"FPA";
                    ckAutoIVA21.Checked = true;
                    ckAutoIVA21.BackColor = Color.Gold;
                    HabilitaImpuestos(true);
                    break;
                case "TICKET L2":
                    txtNumeroDocumento.Text = null;
                    txtNumeroDocumento.Mask = @"0000-00000000";
                    txtTipoDocumento.Text = @"TKT";
                    txttipoLx.Text = @"L2";
                    HabilitaImpuestos(false);
                    break;
                case "VALE CAJA":
                    txtNumeroDocumento.Text = @"0000-00000000";
                    txtTipoDocumento.Text = @"ZZ";
                    txttipoLx.Text = @"L2";
                    HabilitaImpuestos(false);
                    break;
            }
        }
        private void HabilitaImpuestos(bool habilita)
        {
            txtBaseImponible.Enabled = habilita;
            txtIva105.Enabled = habilita;
            txtIva21.Enabled = habilita;
            txtIva27.Enabled = habilita;
            txtPercepcionIva.Enabled = habilita;
            txtPercepcionIIBB.Enabled = habilita;
            txtImpuestosMunicipales.Enabled = habilita;
            txtImpuestosProvinciales.Enabled = habilita;
            txtImpuestosInternos.Enabled = habilita;
            txtOtrosImpuestos.Enabled = habilita;
            txtConceptosNoGrabados.Enabled = habilita;
            txtAlicPercIva.Enabled = habilita;
            txtAlicperIIBB.Enabled = habilita;
            txtIIBBDistrito.Enabled = habilita;

        }
        private void txtNumeroDocumento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show(@"El numero de factura no cumple con la mascara definida",
                @"Error en mascara/numero documento", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        private void txtNumeroDocumento_Leave(object sender, EventArgs e)
        {
            if (new ValidacionVendorDocument().CheckIfDocumentAlreadyExist(_vendorId, txtNumeroDocumento.Text, txttipoLx.Text, txtTipoDocumento.Text))
            {
                MessageBox.Show(@"El numero de documento ingresado ya existe para este proveedor (Factura Duplicada)",
                    @"Factura ingresada duplicada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            }
        }
        private void cmbCuentaFF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuentaFF.SelectedIndex == -1)
            {
                txtSaldoFF.Text = 0.ToString("C2");
            }
            else
            {
                var pendienteImputar =
                    Convert.ToDecimal(
                        new CuentasManager().GetSaldoCuentaPendienteConversion(cmbCuentaFF.SelectedValue.ToString()));

                txtPendienteImputar.Text = pendienteImputar.ToString("C2");
                var saldoFF = new CuentasManager().GetSaldoCuenta(cmbCuentaFF.SelectedValue.ToString());
                txtSaldoFF.Text = (saldoFF - pendienteImputar).ToString("C2");
            }
        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFantasia.SelectedValue == null)
            {
                return;
            }
            else
            {
                cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
            }
        }
        private void mskCuit_Enter(object sender, EventArgs e)
        {
            _cuitValidado = false;

        }
        private void mskCuit_Leave(object sender, EventArgs e)
        {
            if (new CuitValidation().ValidarCuit(mskCuit.Text))
            {
                _cuitValidado = true;
                var idVendor = new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Where(c => c.NTAX1 == mskCuit.Text).ToList();
                if (idVendor.Count == 1)
                {
                    var idv = idVendor[0].id_prov;
                    cmbRazonSocial.Text = idVendor[0].prov_rsocial;
                    cmbFantasia.Text = idVendor[0].prov_fantasia;
                    txtIdProveedor.Text = idv.ToString();
                }
                else
                {
                    if (idVendor.Count > 1)
                    {
                        MessageBox.Show(@"Existe mas de un Proveedor con el mismo numero de CUIT.",
                            @"Error en Numero de CUIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(@"NO EXISTE NINGUN PROVEEDOR CON EL CUIT SELECCIONADO",
                            @"Error en Numero de CUIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                _cuitValidado = false;
            }
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void ActualizaItemTotal(object sender, EventArgs e)
        {
            CalculaPrecioTotalItem();
        }
        private void CalculaPrecioTotalItem()
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                txtPrecioT.Text = 0.ToString("c2");
            }

            if (string.IsNullOrEmpty(txtPrecioU.Text))
            {
                txtPrecioT.Text = 0.ToString("c2");
            }

            txtPrecioT.Text =
                (new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioU.Text) *
                 Convert.ToDecimal(txtCantidad.Text)).ToString("c2");
        }
        private void cmbDescripcionItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDescripcionItem.SelectedValue == null)
                return;

            var x = cmbDescripcionItem.SelectedValue.ToString();
            var r = new VendorInforRecordManager().GetInfoRecord(_vendorId, x);

            if (r == null)
                return;


            if (r.RECUERDA_PRECIO.Value)
            {
                txtPrecioU.Text = r.PRECIO_U.ToString();
            }

            cmbGlImputacionItem.Text = r.GL;
            txtGLAccount.Text = GLAccountManagement.GetGLDescriptionFromT135(r.GL);

            if (string.IsNullOrEmpty(txtCantidad.Text))
                return;

            if (string.IsNullOrEmpty(txtPrecioU.Text))
                return;

            txtPrecioT.Text =
                (Convert.ToDecimal(txtCantidad.Text) *
                 new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioU.Text)).ToString("C2");

        }
        private void cmbDescripcionItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (DateTime.Now.AddMilliseconds(-500) < _prevClick)
            {
                if (_vendorId < 1)
                {
                    MessageBox.Show(@"Para visualizar items debe primero seleccionar un proveedor", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var f2 = new FrmInfoRecordContaR(_vendorId);
                f2.ShowDialog();
            }
            _prevClick = DateTime.Now;
        }
        private void txtPrecioU_TextChanged(object sender, EventArgs e)
        {
            CalculaPrecioTotalItem();
        }
        private void cmbGlImputacionItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (DateTime.Now.AddMilliseconds(-500) < _prevClick)
            {
                using (var f0 = new FrmCo10GLStructureTree())
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        var gl = f0.Glseleccionado;
                        cmbGlImputacionItem.SelectedItem = gl;
                        cmbGlImputacionItem.Text = gl;
                    }
                }
            }
            _prevClick = DateTime.Now;
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (ValidaAddItem() == false)
            {
                MessageBox.Show(@"No se han dado las condiciones para agregar el item", @"Item no validado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            if (ckMantenerInfoRecord.Checked)
            {
                new VendorInforRecordManager().MantieneInforecordProveedorMaterial(_vendorId, cmbDescripcionItem.Text,
                    txtMoneda.Text, FormatAndConversions.CCurrencyADecimal(txtPrecioU.Text), cmbGlImputacionItem.Text, recuerdaPrecio: true);
            }

            AddItemToLista();
            t0407RendicionFFIBindingSource.DataSource = _lItems.ToList();
            SumaImportes(ckAutoIVA21.Checked);
            BlanqueaItemAgregado();
        }
        private void AddItemToLista()
        {
            var l = new T0407_RendicionFF_I()
            {
                item = "GENERICO",
                cantidad = Convert.ToDecimal(txtCantidad.Text),
                idItem = _lItems.Count,
                itemDescripcion = cmbDescripcionItem.Text,
                precioUnitario = new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioU.Text),
                precioTotal = new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioT.Text),
                glItem = cmbGlImputacionItem.Text,

            };

            if (txttipoLx.Text == @"L1" && ckAutoIVA21.Checked)
            {
                l.aplicaIva = true;
            }
            _lItems.Add(l);


            //    decimal valorIva21 = l.PTOTAL_ARS.Value*(decimal) 0.21;
            //    decimal valorAnterior = new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva21.Text);

            //    txtIva21.Text = (valorIva21 + valorAnterior).ToString("c2");
            //}

        }
        private void BlanqueaItemAgregado()
        {
            txtCantidad.Text = @"1";
            cmbDescripcionItem.Text = null;
            cmbGlImputacionItem.Text = null;
            txtGLAccount.Text = null;
            txtPrecioU.Text = 0.ToString("C2");
            txtPrecioT.Text = 0.ToString("C2");
        }
        private void SumaImportes(bool recalculaIVA21)
        {
            decimal importeBruto = 0;
            var id = 1;
            decimal totalKg = 0;
            foreach (var i in _lItems)
            {
                i.idItem = id;
                importeBruto += i.precioTotal;
                totalKg += i.cantidad;
                id++;
            }

            txtTotalCantidad.Text = totalKg.ToString("n2");
            txtTotalBrutoInicial.Text = importeBruto.ToString("c2");
            decimal importe = 0;
            importe = new FormatAndConversions().GetCurrencyFormat_Decimal(txtTotalBrutoInicial.Text) -
                      new FormatAndConversions().GetCurrencyFormat_Decimal(txtDescuento.Text);
            txtSubtotal.Text = new FormatAndConversions().SetCurrency(importe);
            txtBaseImponible.Text = txtSubtotal.Text;

            if (txttipoLx.Text == @"L1" && recalculaIVA21)
            {
                decimal valorIva21 = importe * (decimal)0.21;
                txtIva21.Text = valorIva21.ToString("C2");
            }

            txtTotalIva.Text =
                new FormatAndConversions().SetCurrency(
                    new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva105.Text) +
                    new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva21.Text) +
                    new FormatAndConversions().GetCurrencyFormat_Decimal(txtIva27.Text));

            decimal importesImpuesto = 0;
            importesImpuesto += FormatAndConversions.CCurrencyADecimal(txtPercepcionIva.Text);
            importesImpuesto += FormatAndConversions.CCurrencyADecimal(txtPercepcionIIBB.Text);
            importesImpuesto += FormatAndConversions.CCurrencyADecimal(txtImpuestosMunicipales.Text);
            importesImpuesto += FormatAndConversions.CCurrencyADecimal(txtImpuestosProvinciales.Text);
            importesImpuesto += FormatAndConversions.CCurrencyADecimal(txtImpuestosInternos.Text);
            importesImpuesto += FormatAndConversions.CCurrencyADecimal(txtOtrosImpuestos.Text);
            importesImpuesto += FormatAndConversions.CCurrencyADecimal(txtConceptosNoGrabados.Text);
            txtTotalImpuestos.Text = importesImpuesto.ToString("c2");

            txtImporteTotalAuto.Text =
                new FormatAndConversions().SetCurrency(
                    new FormatAndConversions().GetCurrencyFormat_Decimal(txtSubtotal.Text) +
                    new FormatAndConversions().GetCurrencyFormat_Decimal(txtTotalIva.Text) + importesImpuesto);

            if (string.IsNullOrEmpty(txtImporteIngresadoManual.Text))
                txtImporteIngresadoManual.Text = 0.ToString("c2");

            var importeManual = new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteIngresadoManual.Text);

            txtImporteDiferencia.Text =
                (new FormatAndConversions().GetCurrencyFormat_Decimal(txtImporteTotalAuto.Text) - importeManual)
                    .ToString("C2");

            txtImporteDiferencia.BackColor = Color.Orange;

            txtTotalImpuestosConIva.Text =
                (importesImpuesto + new FormatAndConversions().GetCurrencyFormat_Decimal(txtTotalIva.Text)).ToString(
                    "C2");

            if (FormatAndConversions.CCurrencyADecimal(txtImporteDiferencia.Text) == 0)
                txtImporteDiferencia.BackColor = Color.LightGreen;
        }
        private bool ValidaAddItem()
        {
            if (ckOkAddItems.Checked == false)
            {
                if (ValidaStep01() == false)
                {
                    return false;
                }
            }

            if (Convert.ToInt32(txtCantidad.Text) <= 0)
            {
                MessageBox.Show(@"La Cantidad no puede ser menor o igual a 0", @"Error en validacion Step02",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cmbDescripcionItem.Text))
            {
                MessageBox.Show(@"El item no puede ser nulo ", @"Error en validacion Step02",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cmbGlImputacionItem.Text))
            {
                MessageBox.Show(@"El item no tiene cuenta GL de imputacion", @"Error en validacion Step02",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioU.Text) <= 0)
            {
                MessageBox.Show(@"El precio unitario no puede ser menor o igual a 0", @"Error en validacion Step02",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ValidaStep01()
        {
            //ckOkAddItems.Checked = false;
            //ckOkAddItems.BackColor = Color.Orange;
            //if (ckVendorActivo.Checked == false)
            //{
            //    MessageBox.Show(@"El Vendor no se encuentra activo", @"Error en validacion Step01", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    return false;
            //}

            //if (ckNumeroDocumentoOK.Checked == false)
            //{
            //    var resp = MessageBox.Show(@"El numero de documento (Factura) es se encuentra duplicado o es incorrecto. Desea continuar de todas formas?", @"Error en validacion Step01",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Question);
            //    return resp == DialogResult.Yes;
            //}

            //if (ckPeriodoOK.Checked == false)
            //{
            //    MessageBox.Show(@"El Periodo no se encuentra abierto para contabilizar", @"Error en validacion Step01",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    return false;
            //}

            //if (rbNormal.Checked)
            //{

            //}
            //else
            //{
            //    MessageBox.Show(@"Por el momento solo esta permitido IMPUTACION NORMAL EMPRESA",
            //        @"Error en validacion Step01", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    return false;
            //}

            //ckOkAddItems.Checked = true;
            //ckOkAddItems.BackColor = Color.LightGreen;

            //cmbRazonSocial.Enabled = false;
            //cmbFantasia.Enabled = false;
            //dtpFechaFactura.Enabled = false;
            //cmbTipoDocumento.Enabled = false;
            //txtNumeroDocumento.Enabled = false;
            //gpbTipoContabilizacion.Enabled = false;
            return true;
        }
        private void dgvDetalleItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvDetalleItems[e.ColumnIndex, e.RowIndex].Value.ToString();
                //int numeroFormula = Convert.ToInt32(dgvFormulaList[dgvFormulaList.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "DEL":
                        {
                            var iditem = Convert.ToInt32(dgvDetalleItems[1, e.RowIndex].Value);
                            var x = _lItems.Find(c => c.idItem == iditem);
                            if (x == null)
                                return;

                            _lItems.Remove(x);
                            SumaImportes(ckAutoIVA21.Checked);
                            t0407RendicionFFIBindingSource.DataSource = _lItems.ToList();
                            //dgvDetalleItems.DataSource = t0404VENDORFACTIBindingSource.DataSource;
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
        private void FrmImputacionFF_Load(object sender, EventArgs e)
        {
            ConfiguraInitialData();
            ResetImportes();
        }
        private void ResetImportes()
        {
            txtTotalBrutoInicial.Text = 0.ToString("c2");
            txtDescuento.Text = 0.ToString("c2");
            txtSubtotal.Text = 0.ToString("c2");
            txtIva105.Text = 0.ToString("c2");
            txtIva21.Text = 0.ToString("c2");
            txtIva27.Text = 0.ToString("c2");
            txtTotalIva.Text = 0.ToString("c2");
            txtPercepcionIva.Text = 0.ToString("c2");
            txtPercepcionIIBB.Text = 0.ToString("c2");
            txtImpuestosMunicipales.Text = 0.ToString("c2");
            txtImpuestosProvinciales.Text = 0.ToString("c2");
            txtImpuestosInternos.Text = 0.ToString("c2");
            txtOtrosImpuestos.Text = 0.ToString("c2");
            txtConceptosNoGrabados.Text = 0.ToString("c2");
            txtTotalImpuestos.Text = 0.ToString("c2");
            txtImporteTotalAuto.Text = 0.ToString("c2");
            txtImporteIngresadoManual.Text = 0.ToString("c2");
            txtImporteDiferencia.Text = 0.ToString("c2");
            txtTotalImpuestosConIva.Text = 0.ToString("C2");
            txtBaseImponible.Text = 0.ToString("c2");
            txtAlicPercIva.Text = 0.ToString("P2");
            txtAlicperIIBB.Text = 0.ToString("P2");
            txtTotalCantidad.Text = @"0";
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedValue == null)
                return;

            var idProveedor = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            var vendorData = new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.SingleOrDefault(c => c.id_prov == idProveedor);
            if (vendorData == null) throw new ArgumentNullException(nameof(vendorData));

            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
            mskCuit.Text = vendorData.NTAX1;

            if (new CuitValidation().ValidarCuit(vendorData.NTAX1))
            {
                //txtCuitValido.BackColor = Color.GreenYellow;
                _cuitValidado = true;
            }
            else
            {
                // txtCuitValido.BackColor = Color.Red;
                _cuitValidado = false;
            }

            txtIdProveedor.Text = cmbRazonSocial.SelectedValue.ToString();
            txtTipoProveedor.Text = vendorData.TIPO;

            UpdateDataWhenVendorIsChanged(Convert.ToInt32(cmbRazonSocial.SelectedValue));

        }
        private void UpdateDataWhenVendorIsChanged(int id)
        {
            // if (cmbRazonSocial.SelectedValue == null)
            //   return;

            // this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            if (_vendorId == id)
                return;

            _vendorId = id;//Convert.ToInt32(cmbRazonSocial.SelectedValue);
                           //ckVendorActivo.Checked = new VendorManager().GetSpecificVendor(_vendorId).ACTIVO.Value;
                           // ckVendorActivo.BackColor = ckVendorActivo.Checked ? Color.Lime : Color.Crimson;

            //var ctacte = new CtaCteVendor(_vendorId);
            //var r1 = ctacte.GetResultadoCtaCte("L1");
            //var r2 = ctacte.GetResultadoCtaCte("L2");
            //txtSaldoL1.Text = r1.SaldoDetalle.ToString("C2");
            //txtSaldoL2.Text = r2.SaldoDetalle.ToString("C2");
            //txtSaldoL1.BackColor = r1.SaldoColor;
            //txtSaldoL2.BackColor = r2.SaldoColor;

            txtGlAp.Text = new GLAccountManagement().GetApVendorGl(_vendorId);
            txtNumeroDocumento.Text = null;
            txtNumeroDocumento.ReadOnly = true;
            cmbDescripcionItem.DataSource = new VendorManager().GetListItemsProveedor(_vendorId);
            cmbDescripcionItem.Text = null;

            //this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);

        }
        private void mskFechaFactura_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParseExact(mskFechaFactura.Text,
                "d/M/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                //valid date
                txtFechaValidada.BackColor = Color.GreenYellow;
                _fechaDocumento = dt;
            }
            else
            {
                //invalid date
                toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
                toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA", mskFechaFactura,
                    mskFechaFactura.Location, 5000);

                txtFechaValidada.BackColor = Color.OrangeRed;
                _fechaDocumento = null;
            }
        }
        private void mskFechaFactura_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            txtFechaValidada.BackColor = Color.OrangeRed;
            _fechaDocumento = null;

            toolTip1.ToolTipTitle = "Ingreso de Datos Incorrectos";
            toolTip1.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA", mskFechaFactura,
                mskFechaFactura.Location, 5000);
        }
        private void mskFechaFactura_Validated(object sender, EventArgs e)
        {
            if (_fechaDocumento == null)
            {
                txtFechaValidada.BackColor = Color.PaleVioletRed;
                txtFechaValidada.Text = @"ERROR";
                return;
            }
            var periodoOpen = new PeriodoAvailability().CheckPeriodoOpenFI(_fechaDocumento.Value);
            if (periodoOpen)
            {
                txtFechaValidada.BackColor = Color.GreenYellow;
                txtFechaValidada.Text = @"OPEN";
            }
            else
            {
                txtFechaValidada.BackColor = Color.Red;
                txtFechaValidada.Text = @"CLOSE";
            }
        }
        private void cmbCuentaFF_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCuentaFF.SelectedValue == null && cmbCuentaFF.Text != string.Empty)
                e.Cancel = true;
        }
        private bool CheckAllowingresoRendicion()
        {
            if (_lItems.Count == 0)
            {
                MessageBox.Show(@"Debe ingresar CostItems", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (FormatAndConversions.CCurrencyADecimal(txtImporteTotalAuto.Text) <= 0)
            {
                MessageBox.Show(@"Debe ingresar CostItems con Monto mayor a CERO", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtGlAp.Text))
            {
                MessageBox.Show(@"El Proveedor Ingresado no Tiene GLAP asignada", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cmbAprobadoPor.Text))
            {
                MessageBox.Show(@"Debe confirmar quien APROBO el Gasto", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnIngresarRendicion_Click(object sender, EventArgs e)
        {
            if (CheckAllowingresoRendicion() == false)
                return;

            CreaHeaderDb();

        }
        private void CreateItemsDb(int idRendicion)
        {
            var ix = 1;
            var listadoItems = new List<T0407_RendicionFF_I>();
            foreach (var i in _lItems)
            {
                var item = new T0407_RendicionFF_I()
                {
                    item = i.item,
                    idRendicion = idRendicion,
                    idItem = ix,
                    cantidad = i.cantidad,
                    aplicaIva = i.aplicaIva,
                    glItem = i.glItem,
                    itemDescripcion = i.itemDescripcion,
                    precioTotal = i.precioTotal,
                    precioUnitario = i.precioUnitario,
                };
                listadoItems.Add(item);
                ix++;
            }
            var x = new RendicionFF().CreaRendicionItems(listadoItems);
        }
        private void CreaHeaderDb()
        {
            var h = new T0406_RendicionFF_H()
            {
                tipoLx = txttipoLx.Text,
                idVendor = _vendorId,
                GLAP = txtGlAp.Text,
                RendicionCuentaGL = txtGlFondoFijo.Text,
                RendicionCuentaGLId = cmbCuentaFF.SelectedValue.ToString(),
                StatusRendicion = RendicionFF.StatusRendicion.Ingresado.ToString(),
                alicPercIIBB = FormatAndConversions.CPorcentajeADecimal(txtAlicperIIBB.Text),
                alicPercIVA = FormatAndConversions.CPorcentajeADecimal(txtAlicPercIva.Text),
                baseImponible = FormatAndConversions.CCurrencyADecimal(txtBaseImponible.Text),
                concNoGravados = FormatAndConversions.CCurrencyADecimal(txtConceptosNoGrabados.Text),
                LogFecha = DateTime.Now,
                LogUser = Environment.UserName,
                descuento = FormatAndConversions.CCurrencyADecimal(txtDescuento.Text),
                fechaDocumento = _fechaDocumento.Value,
                impInternos = FormatAndConversions.CCurrencyADecimal(txtImpuestosInternos.Text),
                impMunicipales = FormatAndConversions.CCurrencyADecimal(txtImpuestosMunicipales.Text),
                impProvinciales = FormatAndConversions.CCurrencyADecimal(txtImpuestosProvinciales.Text),
                importeBruto = FormatAndConversions.CCurrencyADecimal(txtTotalBrutoInicial.Text),
                impPercIIBB = FormatAndConversions.CCurrencyADecimal(txtPercepcionIIBB.Text),
                impPercIVA = FormatAndConversions.CCurrencyADecimal(txtPercepcionIva.Text),
                iva10 = FormatAndConversions.CCurrencyADecimal(txtIva105.Text),
                iva21 = FormatAndConversions.CCurrencyADecimal(txtIva21.Text),
                iva27 = FormatAndConversions.CCurrencyADecimal(txtIva27.Text),
                otrosImpuestos = FormatAndConversions.CCurrencyADecimal(txtOtrosImpuestos.Text),
                subtotal = FormatAndConversions.CCurrencyADecimal(txtSubtotal.Text),
                razonSocial = cmbRazonSocial.SelectedValue.ToString(),
                moneda = txtMoneda.Text,
                numeroDocumento = txtNumeroDocumento.Text,
                tipoDocumento = txtTipoDocumento.Text,
                gastoAutorizadoPor = cmbAprobadoPor.SelectedValue.ToString(),
                Comentario = txtObservaciones.Text,
                ImporteNetoFinal = FormatAndConversions.CCurrencyADecimal(txtImporteTotalAuto.Text),
            };
            var x = new RendicionFF().CreaRendicionHeader(h);
            if (x == 0)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Guardar los Datos", @"Error en Grabado de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStatusRendicion.Text = RendicionFF.StatusRendicion.Error.ToString();
            }
            else
            {
                MessageBox.Show($"Se ha ingresado correctamente la rendicion numero# {x}", @"Rendicion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtStatusRendicion.Text = RendicionFF.StatusRendicion.Ingresado.ToString();
                txtNumeroRendicion.Text = x.ToString();
                CreateItemsDb(x);
                btnIngresarRendicion.Enabled = false;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
