using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.VBTools;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmFI42CobranzaTemporal : Form
    {
        public FrmFI42CobranzaTemporal()
        {

            InitializeComponent();
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.TextChanged += new System.EventHandler(this.txtNumeroTax_TextChanged);
            this.txtNumeroTax.DragLeave += new System.EventHandler(this.txtNumeroTax_Leave);
            this.txtCodigoTax.TextChanged += new System.EventHandler(this.txtCodigoTax_TextChanged);
            this.txtCodigoTax.Leave += new System.EventHandler(this.txtCodigoTax_Leave);
            this.cmbTipoTax.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTax_SelectedIndexChanged);
            this.cmbId6.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.SelectedIndexChanged +=
                new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.txtNumeroTax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.t0006MCLIENTESBindingSource,
                "CUIT", true));
            this.txtCodigoTax.DataBindings.Add(new System.Windows.Forms.Binding("Text",
                this.t0006MCLIENTESBindingSource,
                "TTAX", true));
            this.dgvCobranzaItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzaItems_CellValueChanged_1);
        }

        //--------------------------------------------------------------------------------------------------
        private int? _id6;
        private readonly List<T0206_COBRANZA_I> _listaCob = new List<T0206_COBRANZA_I>();
        private List<T0150_CUENTAS> _listaCuentas = new List<T0150_CUENTAS>();
        private List<T0160_BANCOS> _listaBancos = new List<T0160_BANCOS>();
        private decimal _tc;
        private decimal _importeRecibo;
        private bool _todoValidado;
        private string _tipoLx;
        private bool _pendiente = false;
        //--------------------------------------------------------------------------------------------------

        #region Funcionalidad ComboboxBusqueda

        private void txtNumeroTax_KeyUp(object sender, KeyEventArgs e)
        {
            //cuando es tipo 80 y 11 caracteres lo valida
            if (txtNumeroTax.Text.Length == 11 && txtCodigoTax.Text == @"80")
            {
                ValidaCuitCorrecto();
            }
        }
        private void txtNumeroTax_TextChanged(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtNumeroTax_Leave(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtCodigoTax_TextChanged(object sender, EventArgs e)
        {
            cmbTipoTax.Text = txtCodigoTax.Text == @"80" ? @"CUIT" : @"NI";
        }
        private void txtCodigoTax_Leave(object sender, EventArgs e)
        {
        }
        private void cmbTipoTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoTax.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                if (cmbTipoTax.Text == @"CUIT")
                {
                    txtCodigoTax.Text = @"80";
                    txtNumeroTax.BackColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    txtCodigoTax.Text = @"00";
                    txtNumeroTax.BackColor = Color.DarkGray;
                    txtNumeroTax.Text = @"00000000000";
                }
            }
        }
        private void cmbRazonSocial_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
            }
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                //BlanqueaSeleccion();
                cmbFantasia.SelectedIndex = -1;
                cmbId6.SelectedIndex = -1;
                _id6 = null;
                semDgv.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                dgvCobranzaItems.Enabled = false;
                return;
            }

            _id6 = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            ValidaCuitCorrecto();

            var ctacte = new CtaCteCustomer(_id6.Value);
            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;
            txtSaldoTotal.Text =
                (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtSaldoL2.Text)).ToString("C2");

            if (_tipoLx != null && _id6 != null)
            {
                semDgv.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                dgvCobranzaItems.Enabled = true;
            }
            else
            {
                semDgv.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                dgvCobranzaItems.Enabled = false;
            }
        }
        private void ValidaCuitCorrecto()
        {
            if (txtNumeroTax.Text.Length == 11 && txtNumeroTax.Text != @"00000000000")
            {
                if (new CuitValidation().ValidarCuit(txtNumeroTax.Text) == true)
                {
                    txtTaxValido.Text = @"VALIDO";
                    txtTaxValido.BackColor = Color.LightGreen;
                }
                else
                {
                    txtTaxValido.Text = @"INVALIDO";
                    txtTaxValido.BackColor = Color.Crimson;
                }
            }
            else
            {
                txtTaxValido.Text = @"SIN VALIDAR";
                txtTaxValido.BackColor = Color.Orange;
            }
        }
        private void BlanqueaSeleccion()
        {
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTipoTax.SelectedIndex = -1;
            cmbId6.SelectedIndex = -1;
            txtNumeroTax.Text = null;
            txtCodigoTax.Text = null;
            _id6 = null;
            //
            txtSaldoL1.Text = 0.ToString("C2");
            txtSaldoL2.Text = 0.ToString("C2");
            txtSaldoTotal.Text = 0.ToString("C2");
            //
        }
        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            var f = new FrmBusquedaAvanzadaCliente();
            f.ShowDialog();
        }
        #endregion

        private void FrmIngresoConbranzaTemporal_Load(object sender, EventArgs e)
        {
            t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo();
            t0206COBRANZAIBindingSource.DataSource = _listaCob;
            _listaCuentas = new CuentasManager().GetListCuentasAvailableCobranza();
            __cuenta.DataSource = _listaCuentas;
            _listaBancos = new BankManager().GetBankList(true);
            _tc = new ExchangeRateManager().GetExchangeRate(dtpFechaCobranza.Value);
            txtXRate.Text = _tc.ToString("N2");
            //
            cmbCobrador.DataSource = new HumanResourcesManager().GetListAllActiveCobrador();
            cmbIngresadoPor.DataSource = new HumanResourcesManager().GetListEmployees();
            cmbIngresadoPor.SelectedValue = Environment.UserName;
            cmbCobrador.SelectedIndex = -1;
            cmbRazonSocial.SelectedIndex = -1;
            //
            txtStatus.Text = CobranzaTemporalManager.StatusCobranzaTemporal.Inicial.ToString();
            btnImprimir.Enabled = false;
            AddNewRow();
            dgvCobranzaItems.Enabled = false;
            semDgv.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
        }

        private void SetDgvCell(int numeroRow, string cellName, bool readOnly, object valorCelda,
            Color? colorFore = null, Color? coloreBack = null, bool asignarValor = true)
        {
            this.dgvCobranzaItems.CellValueChanged -=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzaItems_CellValueChanged_1);
            var xcelda = dgvCobranzaItems.Rows[numeroRow].Cells[cellName];
            xcelda.ReadOnly = readOnly;
            if (readOnly)
            {
                xcelda.Style.BackColor = coloreBack ?? Color.LightGray;
                xcelda.Style.ForeColor = colorFore ?? Color.Black;
            }
            else
            {
                xcelda.Style.BackColor = coloreBack ?? Color.White;
                xcelda.Style.ForeColor = colorFore ?? Color.Navy;
            }

            if (asignarValor)
            {
                xcelda.Value = valorCelda;
            }

            dgvCobranzaItems.EndEdit();
            this.dgvCobranzaItems.CellValueChanged +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzaItems_CellValueChanged_1);
        }

        private void FormatBlockAll(int numeroRow)
        {
            SetDgvCell(numeroRow, __importe.Name, true, null);
            SetDgvCell(numeroRow, __chequeNumero.Name, true, null);
            SetDgvCell(numeroRow, __chequeFecha.Name, true, null);
            SetDgvCell(numeroRow, __isEcheque.Name, true, null);
            SetDgvCell(numeroRow, __cuit.Name, true, null);
            SetDgvCell(numeroRow, __chequeBankNumber.Name, true, null);
            SetDgvCell(numeroRow, __isInterior.Name, true, null);
            SetDgvCell(numeroRow, __chequeTitular.Name, true, null);
            SetDgvCell(numeroRow, __tc.Name, true, null, asignarValor: false);
        }
        //Formateo de propiedades segun tipo de cuenta seleccionada
        private void FormatCheque(int numeroRow)
        {
            FormatBlockAll(numeroRow);
            SetDgvCell(numeroRow, __importe.Name, false, (decimal)0);
            SetDgvCell(numeroRow, __chequeNumero.Name, false, null);
            SetDgvCell(numeroRow, __chequeFecha.Name, false, null);
            SetDgvCell(numeroRow, __isEcheque.Name, false, false);
            SetDgvCell(numeroRow, __cuit.Name, false, null);
            SetDgvCell(numeroRow, __chequeBankNumber.Name, false, null);
            SetDgvCell(numeroRow, __isInterior.Name, false, false);
            SetDgvCell(numeroRow, __chequeTitular.Name, false, null);
        }
        private void FormatEfectivo(int numeroRow)
        {
            FormatBlockAll(numeroRow);
            SetDgvCell(numeroRow, __importe.Name, false, (decimal)0);
        }
        private void FormatCuentaNoManejada(int numeroRow)
        {
            FormatBlockAll(numeroRow);
        }


        #region ControlesDgv

        //Validacion de Formatos y Valores Validos (Al Salir) - Solo Celdas Desbloqueadas
        private void dgvCobranzaItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = (DataGridView)sender;

            if (e.ColumnIndex == 0)
                return;

            if (dgv.CurrentCell.ReadOnly)
                return;

            if (e.ColumnIndex == dgv[__cuenta.Name, e.RowIndex].ColumnIndex)
            {
                if (dgv[__cuenta.Name, e.RowIndex].Value == null)
                {
                    //Si la Cuenta esta Null no continua intentando validar nada
                    return;
                }
            }

            //** Valida [Importe] >0
            if (e.ColumnIndex == dgv[__importe.Name, e.RowIndex].ColumnIndex)
            {
                var value = e.FormattedValue.ToString();
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    SetDgvCell(e.RowIndex, __importe.Name, false, (decimal)0);
                    //Si el importe era Null/Vacio lo pasamos a 0
                }
                else
                {
                    if (value.StartsWith("$") == true)
                    {
                        value = value.Remove(0, 1);
                    }

                    value = value.Trim();
                    if (!Decimal.TryParse(value, out var valueDecimal))
                    {
                        e.Cancel = true;
                        MessageBox.Show(@"El Importe debe ser un número mayor a Cero",
                            @"Error en el Formato del Importe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    //Al Validar el Importe - Completa el MontoRecibo
                    _listaCob[e.RowIndex].IMP_ITEM = valueDecimal;
                    if (_listaCob[e.RowIndex].MON_ITEM == "USD")
                    {
                        _listaCob[e.RowIndex].IMP_RECIBO = valueDecimal * _listaCob[e.RowIndex].TC_ITEM.Value;
                    }
                    else
                    {
                        _listaCob[e.RowIndex].IMP_RECIBO = valueDecimal;
                    }
                    RecalculaImporteRecibo();
                }
            }

            //** Validacion de Fecha del Cheque
            if (e.ColumnIndex == dgv[__chequeFecha.Name, e.RowIndex].ColumnIndex)
            {
                //validacion de Fecha del Cheque
                var value = e.FormattedValue.ToString();
                if (string.IsNullOrEmpty(value))
                {
                    _listaCob[e.RowIndex].CHEQUE_FECHA = null;
                    e.Cancel = true;
                    MessageBox.Show(@"La fecha no puede ser NULA", @"Error en Formato de Fecha", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (!DateTime.TryParse(value, out var valueDate))
                    {
                        MessageBox.Show(@"La Fecha no tiene un formato valido", @"Error en Formato de Fecha",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                    else
                    {
                        if (ckControlVencimientoCheque.Checked)
                        {
                            if (valueDate < DateTime.Today.AddDays(-30))
                            {
                                MessageBox.Show(@"El Cheque esta Vencido [-30 dias]", @"Error en Formato de Fecha",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                e.Cancel = true;
                            }

                            if (valueDate > DateTime.Today.AddDays(365))
                            {
                                MessageBox.Show(
                                    @"Por Normativa los Cheques no pueden ser emitidos con fechas mayores a 365 dias",
                                    @"Error en Formato de Fecha", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                e.Cancel = true;
                            }
                        }
                    }
                    _listaCob[e.RowIndex].CHEQUE_FECHA = valueDate;
                }
            }

            //**Validacion del numero de CUIT
            if (e.ColumnIndex == dgv[__cuit.Name, e.RowIndex].ColumnIndex)
            {
                string cuitValor = null;
                if (e.FormattedValue != null)
                {
                    cuitValor = e.FormattedValue.ToString();
                }
                if (string.IsNullOrEmpty(cuitValor) || cuitValor == "0")
                {
                    dgv[__cuit.Name, e.RowIndex].Style.BackColor = Color.White;
                }
                else
                {
                    dgv[__cuit.Name, e.RowIndex].Style.BackColor = new CuitValidation().ValidarCuit(cuitValor) ? Color.MediumSpringGreen : Color.Salmon;
                }
            }

            //**Validacion del numero de Banco
            if (e.ColumnIndex == dgv[__chequeBankNumber.Name, e.RowIndex].ColumnIndex)
            {
                //Completa la descripcion del BANCO
                string bankId = null;
                if (e.FormattedValue != null)
                {
                    bankId = e.FormattedValue.ToString();
                }
                var bankDescripcion = dgv[__chequeBankDescripcion.Name, e.RowIndex];
                var bancoDesc = _listaBancos.Find(c => c.ID_BANCO == bankId);
                if (bancoDesc != null)
                {
                    bankDescripcion.Style.BackColor = Color.LightGreen;
                    bankDescripcion.Style.ForeColor = Color.Black;
                    bankDescripcion.Value = bancoDesc.BCO_SHORTDESC;
                }
                else
                {
                    bankDescripcion.Style.BackColor = Color.Salmon;
                    bankDescripcion.Style.ForeColor = Color.Red;
                    bankDescripcion.Value = "Banco no Encontrado";
                }
            }
        }

        // Realiza la validacion Global del DGV para habilitar o no el boton de Confirmar
        private void dgvCobranzaItems_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var x = _listaCob[e.RowIndex];
            ValidaRowManual(e.RowIndex);
        }




        private void ValidaRowManual(int numeroRow)
        {
            bool rowValidada;
            var dataCuenta = dgvCobranzaItems.Rows[numeroRow].Cells[__cuenta.Name].Value;
            if (dataCuenta == null)
            {
                btnConfirmar.Enabled = false;
                return;
            }

            _listaCob[numeroRow].CUENTA = dataCuenta.ToString();
            switch (dataCuenta.ToString())
            {
                case "ARS":
                    rowValidada = ValidaEfectivoRowComplete(numeroRow);
                    break;
                case "USD":
                    rowValidada = ValidaEfectivoRowComplete(numeroRow);
                    break;
                case "RIB":
                    rowValidada = ValidaEfectivoRowComplete(numeroRow);
                    break;
                case "RIVA":
                    rowValidada = ValidaEfectivoRowComplete(numeroRow);
                    break;
                case "RGA":
                    rowValidada = ValidaEfectivoRowComplete(numeroRow);
                    break;
                case "CHE":
                    rowValidada = ValidaChequeRowComplete(numeroRow);
                    break;
                case "SAN":
                    rowValidada = ValidaEfectivoRowComplete(numeroRow);
                    break;
                case "GAL":
                    rowValidada = ValidaEfectivoRowComplete(numeroRow);
                    break;
                case "ICBC":
                    rowValidada = ValidaEfectivoRowComplete(numeroRow);
                    break;
                default:
                    MessageBox.Show(
                        @"Debido a que la cuenta seleccionada no es manejada por el sistema, esta linea no puede ser validada",
                        @"Cuenta Incorrecta o No Manejada por el Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rowValidada = false;
                    break;
            }

            if (rowValidada)
            {
                SetDgvCell(numeroRow, __estadoLine.Name, true, "Valido OK", Color.Navy, Color.DarkSeaGreen);
            }
            else
            {
                SetDgvCell(numeroRow, __estadoLine.Name, true, "Incompleto", Color.Red, Color.LightPink);
            }

            //---  Validacion Global ---
            btnConfirmar.Enabled = ValidacionGlobalRowsOK(null);
        }




        #endregion

        private bool ValidacionGlobalRowsOK(int? miRow)
        {
            if (_listaCob.Count == 0)
                return false;

            _todoValidado = true;
            for (var i = 0; i < dgvCobranzaItems.RowCount; i++)
            {
                var cuenta = dgvCobranzaItems[__cuenta.Name, i].Value;
                if (miRow != null && i == miRow.Value)
                    ValidaRowManual(miRow.Value);

                if (cuenta == null)
                {
                    FormatBlockAll(i);
                }
                else
                {
                    //reformateo bloqueos  
                    //FormateoBloqueoSegunCuenta(cuenta.ToString(),i);

                }
                if (dgvCobranzaItems.Rows[i].Cells[__estadoLine.Name].Value == null)
                {
                    _todoValidado = false;
                }
                else
                {
                    if (dgvCobranzaItems.Rows[i].Cells[__estadoLine.Name].Value.ToString() == "Incompleto")
                        _todoValidado = false;
                }

            }
            return _todoValidado;
        }
        private bool ValidaChequeRowComplete(int row)
        {
            if (ValidaEfectivoRowComplete(row) == false)
                return false;

            var numeroCheque = dgvCobranzaItems.Rows[row].Cells[__chequeNumero.Name].Value;
            if (numeroCheque == null)
            {
                return false;
            }

            var fechaCheque = dgvCobranzaItems.Rows[row].Cells[__chequeFecha.Name].Value;
            if (fechaCheque == null)
            {
                return false;
            }

            var cuitCheque = dgvCobranzaItems.Rows[row].Cells[__cuit.Name].Value;
            if (cuitCheque == null)
            {
                return false;
            }

            if (new CuitValidation().ValidarCuit(cuitCheque.ToString()) == false)
            {
                return false;
            }

            var bankCheque = dgvCobranzaItems.Rows[row].Cells[__chequeBankNumber.Name].Value;
            if (bankCheque == null)
            {
                return false;
            }

            var bank = _listaBancos.Find(c => c.ID_BANCO == bankCheque.ToString());
            if (bank == null)
                return false;

            return true;
        }
        private bool ValidaEfectivoRowComplete(int row)
        {
            var importeR = dgvCobranzaItems[__importeRecibo.Name, row].Value;
            if (importeR == null)
            {
                return false;
            }
            return FormatAndConversions.CCurrencyADecimal(importeR.ToString()) > 0;
        }

        private List<T1206_CobranzaConvertirItems> MapCobranzaList()
        {
            List<T1206_CobranzaConvertirItems> lista = new List<T1206_CobranzaConvertirItems>();
            foreach (var item in _listaCob)
            {
                var data = new T1206_CobranzaConvertirItems()
                {
                    idCobTem = Convert.ToInt32(txtNumeroReciboInterno.Text),
                    CuentaItem = item.CUENTA,
                    ImporteRecibo = item.IMP_RECIBO,
                    GLItem = new CuentasManager().GetGL(item.CUENTA),
                    MonedaItem = item.MON_ITEM,
                    ImporteMoneda = item.IMP_ITEM,
                    TipoCambio = item.TC_ITEM,
                    idItem = item.LINE,
                };

                if (item.CUENTA == "CHE")
                {
                    data.CodigoPostalCheque = "0000";
                    data.Cuit = item.CHEQUE_CUIT;
                    data.FechaAcreditacion = item.CHEQUE_FECHA;
                    data.NumeroBanco = item.CHEQUE_BANCO;
                    data.NumeroCheque = item.CHEQUE_NUMERO;
                    data.NumeroCuenta = null;
                    data.IdCheque = 0;
                    data.ChequeInterior = item.Che_Interior;
                    data.isEcheque = item.Che_Electronico;
                }
                lista.Add(data);
            }
            return lista;
        }
        private bool ValidaOkRegistrar()
        {
            if (_id6 == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Cliente para el ingreso de la Cobranza", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_tipoLx == null)
            {
                MessageBox.Show(@"Debe Seleccionar L1/L2", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (rbL1.Checked == false && rbL2.Checked == false)
            {
                MessageBox.Show(@"Debe Seleccionar L1/L2", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (rbL1.Checked)
            {
                if (string.IsNullOrEmpty(txtNumeroReciboProvisorioL1.Text))
                {
                    MessageBox.Show(@"En L1 debe proveer numero recibo provisorio", @"Datos Incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            if (cmbCobrador.SelectedValue == null)
            {
                MessageBox.Show(@"Debe proveer el nombre del Cobrador que recibio el dinero o hizo la cobranza",
                    @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtImporteReciboManual.Text))
            {
                txtImporteReciboManual.Text = 0.ToString("C2");
            }

            var importeManual = FormatAndConversions.CCurrencyADecimal(txtImporteReciboManual.Text);
            var importeAuto = FormatAndConversions.CCurrencyADecimal(txtImporteReciboAutomatico.Text);

            if (importeAuto != importeManual)
            {
                MessageBox.Show(
                    @"El Importe Ingresado en Forma Manual NO COINCIDE con la SUMATORIA de valores INGRESADOS!",
                    @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (!_todoValidado)
            {
                MessageBox.Show(
                    @"La Grilla no contiene ITEMS de cobranza o alguna de las lineas no se encuentran VALIDADAS",
                    @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void rbL1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbL1.Checked)
            {
                _tipoLx = "L1";
                txtNumeroReciboProvisorioL1.Enabled = true;
            }
            else
            {
                if (rbL2.Checked)
                {
                    _tipoLx = "L2";
                    txtNumeroReciboProvisorioL1.Enabled = false;
                }
                else
                {
                    _tipoLx = null;
                }
            }

            if (_tipoLx != null && cmbRazonSocial.SelectedValue != null)
            {
                semDgv.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                dgvCobranzaItems.Enabled = true;
            }
            else
            {
                semDgv.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                dgvCobranzaItems.Enabled = false;
            }
        }
        private void txtImporteReciboCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }


        #region Botones
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var f0 = new RpvReciboTemporal(Convert.ToInt32(txtNumeroReciboInterno.Text));
            f0.Show();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (_pendiente)
            {
                var resp = MessageBox.Show(@"Desea salir perdiendo los registros ingresados?",
                    @"Cobranza Temporal No Ingresada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;
            }
            dgvCobranzaItems.DataSource = null;
            this.Close();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidaOkRegistrar() == false)
                return;

            var respuesta =
                MessageBox.Show($@"Confirmar el INGRESO DE Cobranza por IMPORTE {txtImporteReciboAutomatico.Text} ?",
                    @"Ingreso Cobranza Temporal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            txtNumeroReciboInterno.Text = new CobranzaTemporalManager().SaveNewHeader(_id6.Value, _tipoLx,
                    _importeRecibo, txtNumeroReciboProvisorioL1.Text, dtpFechaCobranza.Value,
                    cmbIngresadoPor.SelectedValue.ToString(),
                    cmbCobrador.SelectedValue.ToString(), Convert.ToDecimal(txtXRate.Text), "ARS",
                    txtObservaciones.Text)
                .ToString();


            new CobranzaTemporalManager().SaveItems(Convert.ToInt32(txtNumeroReciboInterno.Text), MapCobranzaList());
            dgvCobranzaItems.Enabled = false;
            btnConfirmar.Enabled = false;
            MessageBox.Show(
                $@"La Cobranza se ha Registrado Correctamente con el Numero Interno Temporal #{txtNumeroReciboInterno.Text}",
                @"Registro de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnImprimir.Enabled = true;
            _pendiente = false;
        }
        #endregion

        private void RefreshIndice()
        {
            int xline = 1;
            foreach (var lx in _listaCob)
            {
                lx.LINE = xline;
                xline++;
            }
        }
        private void AddNewRow()
        {
            RefreshIndice();
            var generic = new T0206_COBRANZA_I()
            {
                LINE = _listaCob.Count + 1,
                IMP_ITEM = 0,
                IMP_RECIBO = 0,
            };
            _listaCob.Add(generic);
            if (_listaCob.Count == 1)
            {
                //el primer item de la lista lo bindea a la lista
                t0206COBRANZAIBindingSource.DataSource = _listaCob.ToList();
                _pendiente = true;
            }
            else
            {
                //luego ademas de bajar de la lista lo borra del Bs
                t0206COBRANZAIBindingSource.Add(generic);
            }

            FormatBlockAll(dgvCobranzaItems.RowCount - 1);
            SetDgvCell(dgvCobranzaItems.RowCount - 1, __estadoLine.Name, true, "Incompleto", Color.Red, Color.LightPink);

            if (_listaCob.Count == 1)
                btnConfirmar.Enabled = false;
            btnConfirmar.Enabled = true;
        }


        //Accion boton en DGV
        private void dgvCobranzaItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvCobranzaItems[e.ColumnIndex, e.RowIndex].Value.ToString();
                //int numeroFormula = Convert.ToInt32(dgvFormulaList[dgvFormulaList.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
                switch (cellValue)
                {
                    case "DEL":
                        {
                            var iditem = Convert.ToInt32(dgvCobranzaItems[__line.Name, e.RowIndex].Value);
                            var x = _listaCob.Find(c => c.LINE == iditem);
                            if (x == null)
                                return;

                            if (_listaCob.Count == 1)
                            {
                                MessageBox.Show(@"No es posible eliminar esta linea del recibo",
                                    @"El Recibo debe tener al menos una linea/item", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                return;
                            }
                            _listaCob.Remove(x);
                            t0206COBRANZAIBindingSource.Remove(x);
                            RefreshIndice();
                            int i = 1;
                            foreach (var xrow in dgvCobranzaItems.Rows)
                            {
                                SetDgvCell(i - 1, __line.Name, true, i);
                                i++;
                            }
                            RecalculaImporteRecibo();
                        }
                        break;
                    case "ADD":
                        if (ValidacionGlobalRowsOK(e.RowIndex))
                        {
                            AddNewRow();
                            SetNextLineChe();
                        }
                        else
                        {
                            MessageBox.Show(
                                @"No se puede agregar mas lineas hasta que todas las existentes no esten Validadas OK",
                                @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private void SetNextLineChe()
        {
            dgvCobranzaItems[__cuenta.Name, _listaCob.Count - 1].Value = "CHE";
        }

        //Al Ingresar a una celda si cuenta no esta completo bloqueo everything
        private void dgvCobranzaItems_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvCobranzaItems.CurrentCellDirtyStateChanged -= new System.EventHandler(this.dgvCobranzaItems_CurrentCellDirtyStateChanged);
            var dgv = (DataGridView)sender;

            if (dgv.CurrentCell.ReadOnly)
                return; //como la celda es readonly ya no validamos nada

            if (e.ColumnIndex == dgv[__cuenta.Name, e.RowIndex].ColumnIndex)
            {
                this.dgvCobranzaItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCobranzaItems_CurrentCellDirtyStateChanged);
            }

            if (e.ColumnIndex != dgv[__cuenta.Name, e.RowIndex].ColumnIndex)
            {
                if (dgv[__cuenta.Name, e.RowIndex].Value == null)
                {
                    FormatBlockAll(e.RowIndex);
                }
            }
        }

        //Esto dispara el evento de abajo
        private void dgvCobranzaItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCobranzaItems.IsCurrentCellDirty)
            {
                dgvCobranzaItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //Solo al cambiar el combobox
        private void dgvCobranzaItems_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            //Si la celda modificada NO ES cuenta --> return.
            if (e.ColumnIndex != dgvCobranzaItems[__cuenta.Name, e.RowIndex].ColumnIndex)
                return;
            var cb = (DataGridViewComboBoxCell)dgvCobranzaItems.Rows[e.RowIndex].Cells[1];
            if (cb.Value != null)
            {
                var cuentaInfo = _listaCuentas.SingleOrDefault(c => c.ID_CUENTA == cb.Value.ToString());
                SetDgvCell(e.RowIndex, __descripcion.Name, true, cuentaInfo.CUENTA_DESC);
                SetDgvCell(e.RowIndex, __moneda.Name, true, cuentaInfo.CUENTA_MONEDA, Color.DarkGreen);
                SetDgvCell(e.RowIndex, __line.Name, true, e.RowIndex + 1);
                SetDgvCell(e.RowIndex, __tc.Name, true, _tc);
                FormateoBloqueoSegunCuenta(cb.Value.ToString(), e.RowIndex);
                //switch (cb.Value.ToString())
                //{
                //    case "ARS":
                //        FormatEfectivo(e.RowIndex);
                //        break;
                //    case "CHE":
                //        FormatCheque(e.RowIndex);
                //        break;
                //    case "GAL":
                //        FormatEfectivo(e.RowIndex);
                //        break;
                //    case "ICBC":
                //        FormatEfectivo(e.RowIndex);
                //        break;
                //    case "SAN":
                //        FormatEfectivo(e.RowIndex);
                //        break;
                //    case "RIB":
                //        FormatEfectivo(e.RowIndex);
                //        break;
                //    case "RGA":
                //        FormatEfectivo(e.RowIndex);
                //        break;
                //    case "USD":
                //        FormatEfectivo(e.RowIndex);
                //        break;
                //    case "RIVA":
                //        FormatEfectivo(e.RowIndex);
                //        break;
                //    default:
                //        FormatCuentaNoManejada(e.RowIndex);
                //        MessageBox.Show(
                //            $@"La Cuenta {cb.Value.ToString()} no esta siendo manejada por la aplicacion." +
                //            Environment.NewLine +
                //            @"Si la requiere notifique al creador del sistema sobre este mensaje ",
                //            @"Configuracion Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        break;
                //}
                dgvCobranzaItems.Invalidate();
            }
        }
        private void FormateoBloqueoSegunCuenta(string cuenta, int rowNumber)
        {
            switch (cuenta)
            {
                case "ARS":
                    FormatEfectivo(rowNumber);
                    break;
                case "CHE":
                    FormatCheque(rowNumber);
                    break;
                case "GAL":
                    FormatEfectivo(rowNumber);
                    break;
                case "ICBC":
                    FormatEfectivo(rowNumber);
                    break;
                case "SAN":
                    FormatEfectivo(rowNumber);
                    break;
                case "RIB":
                    FormatEfectivo(rowNumber);
                    break;
                case "RGA":
                    FormatEfectivo(rowNumber);
                    break;
                case "USD":
                    FormatEfectivo(rowNumber);
                    break;
                case "RIVA":
                    FormatEfectivo(rowNumber);
                    break;
                default:
                    FormatCuentaNoManejada(rowNumber);
                    MessageBox.Show(
                        $@"La Cuenta {cuenta} no esta siendo manejada por la aplicacion." +
                        Environment.NewLine +
                        @"Si la requiere notifique al creador del sistema sobre este mensaje ",
                        @"Configuracion Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
        private void dgvCobranzaItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {


        }
        private void RecalculaImporteRecibo()
        {
            _importeRecibo = 0;
            var cantidadRowsDgv = dgvCobranzaItems.RowCount;
            for (var i = 0; i < cantidadRowsDgv; i++)
            {
                _importeRecibo += Convert.ToDecimal(dgvCobranzaItems.Rows[i].Cells[__importeRecibo.Name].Value);
            }
            txtImporteReciboAutomatico.Text = _importeRecibo.ToString("C2");

            var _importeCheck = (decimal)0;
            if (!string.IsNullOrEmpty(txtImporteReciboManual.Text))
            {
                _importeCheck = FormatAndConversions.CCurrencyADecimal(txtImporteReciboManual.Text);
            }

            var diferencia = _importeRecibo - _importeCheck;
            txtImporteDiferencia.Text = (_importeRecibo - _importeCheck).ToString("C2");
            if (diferencia == 0)
            {
                txtImporteDiferencia.BackColor = Color.LightGreen;
                txtImporteDiferencia.ForeColor = Color.Black;
            }
            else
            {
                txtImporteDiferencia.BackColor = Color.LightPink;
                txtImporteDiferencia.ForeColor = Color.Red;
            }
        }

        private void dgvCobranzaItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var dgb = (DataGridView)sender;
            var x = dgb[e.ColumnIndex, e.RowIndex].Value;
            MessageBox.Show(e.Exception.Message);
            var z = Convert.ToBoolean(x);
        }
    }
}

