using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.FI.Transferencias
{
    public partial class FrmFI15TransferenciasEC : Form
    {
        public FrmFI15TransferenciasEC()
        {
            InitializeComponent();
        }

        public FrmFI15TransferenciasEC(int modo)
        {
            InitializeComponent();
        }

        //todo: mapear observacion en tabla, y en reporte
        private string _corigen;
        private string _cdestino;
        private List<DatosXReg> _dataList = new List<DatosXReg>();
        private bool _headerValidado = false;
        private decimal _xrate;
        private string _tipoLx;
#pragma warning disable CS0169 // The field 'FrmTransferenciaEntreCuentas.numeroOperacion' is never used
        private string numeroOperacion;
#pragma warning restore CS0169 // The field 'FrmTransferenciaEntreCuentas.numeroOperacion' is never used
        private int _idReg;


        //-----------------------------------------------------------------------------------------------------------------
        private void FrmTransferenciaEntreCuentas_Load(object sender, EventArgs e)
        {
            ConfiguraDataInicial();
        }

        private void ConfiguraDataInicial()
        {
            bsCDestino.DataSource = new CuentasManager().GetListCuentasAvailableTransferencia();
            bsCOrigen.DataSource = new CuentasManager().GetListCuentasAvailableTransferencia();
            cmbCuentaOrigen.DataSource = bsCOrigen;
            cmbCuentaDestino.DataSource = bsCDestino;
            _headerValidado = false;
            ckHeaderValidado.Checked = false;
            ckHeaderValidado.BackColor = Color.OrangeRed;
            _xrate = new ExchangeRateManager().GetExchangeRate(dtpFechaTransaccion.Value);
            txtXRate.Text = _xrate.ToString("N2");
            DatosRegisterBs.DataSource = _dataList.ToList();
            dgvRegistroReg.DataSource = DatosRegisterBs.DataSource;
            cmbCuentaOrigen.Text = null;
            cmbCuentaDestino.Text = null;
            dgvListadoCheques.ClearSelection();
            dgvListadoCheques.CurrentCell = null;
            panelTransferenciaCheque.Visible = false;
            panelTransferenciaImporte.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddCheque.Enabled = false;

            if (cmbCuentaOrigen.SelectedValue == null)
            {
                _corigen = null;
                txtDescripcionCuentaOrigen.Text = null;
                txtMonedaOrigen.Text = null;
                return;
            }

            var dataOrigen = new CuentasManager().GetSpecificCuentaInfo(cmbCuentaOrigen.SelectedValue.ToString());
            txtDescripcionCuentaOrigen.Text = dataOrigen.CUENTA_DESC;
            txtMonedaOrigen.Text = dataOrigen.CUENTA_MONEDA;

            if (ValidaCuentaOrigen())
                ValidaCombinacionCuentas();
        }

        private void cmbCuentaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddCheque.Enabled = false;

            if (cmbCuentaDestino.SelectedValue == null)
            {
                _cdestino = null;
                txtDescripcionCuentaDestino.Text = null;
                txtMonedaDestino.Text = null;
                return;
            }

            var dataDestino = new CuentasManager().GetSpecificCuentaInfo(cmbCuentaDestino.SelectedValue.ToString());
            txtDescripcionCuentaDestino.Text = dataDestino.CUENTA_DESC;
            txtMonedaDestino.Text = dataDestino.CUENTA_MONEDA;

            if (ValidaCuentaDestino())
                ValidaCombinacionCuentas();
        }

        private bool ValidaCuentaOrigen()
        {
            panelTransferenciaCheque.Visible = false;
            panelTransferenciaImporte.Visible = true;
            ckSoloTipoSeleccionado.Visible = false;
            if (cmbCuentaOrigen.SelectedValue.ToString() == "CHE")
            {
                panelTransferenciaCheque.Visible = true;
                panelTransferenciaImporte.Visible = false;
                ckSoloTipoSeleccionado.Visible = true;
                if (ckVerSoloParaDepositar.Checked)
                {
                    BsListaCheques.DataSource =
                        new ChequesManager().GetListaChequesFiltrada("", true,
                            menorIgualaFecha: dtpFechaTransaccion.Value);
                }
                else
                {
                    BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada("", true);
                }

                dgvListadoCheques.ClearSelection();
                dgvListadoCheques.CurrentCell = null;
            }
            _corigen = cmbCuentaOrigen.SelectedValue.ToString();
            return true;
        }

        private bool ValidaCuentaDestino()
        {
            if (cmbCuentaDestino.SelectedValue.ToString() == "CHE")
            {
                MessageBox.Show(@"La cuenta valores a depositar no es una cuenta de Destino Valido",
                    @"Error en seleccion de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            _cdestino = cmbCuentaDestino.SelectedValue.ToString();
            return true;
        }

        private bool ValidaCombinacionCuentas()
        {
            btnAddCheque.Enabled = true;
            return true;
        }

        private bool ValidaDatosHeader()
        {
            if (dtpFechaTransaccion.Value > DateTime.Today.AddDays(2))
            {
                MessageBox.Show(@"No se puede ingresar una fecha mayor a mañana para realizar una transferencia",
                    @"Error en Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_corigen == null || _cdestino == null)
            {
                MessageBox.Show(@"Debe seleccionar una Cuenta Origen y una Cuenta Destino",
                    @"Error en Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_corigen == _cdestino)
            {
                MessageBox.Show(@"La Cuenta Origen debe ser diferente a la cuenta Destino",
                    @"Error en Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rbL1.Checked == false && rbL2.Checked == false)
            {
                MessageBox.Show(@"Debe Seleccionar primero el tipo de operacion L1/L2", @"Seleccione Tipo LX",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            ckHeaderValidado.Checked = true;
            ckHeaderValidado.BackColor = Color.LimeGreen;

            cmbCuentaDestino.Enabled = false;
            dtpFechaTransaccion.Enabled = false;
            grpLx.Enabled = false;
            txtMonedaImporteTransferir.Text = txtMonedaDestino.Text;
            txtMonedaImporteTransferir.BackColor = Color.GreenYellow;

            return true;
        }

        private void dtpFechaTransaccion_ValueChanged(object sender, EventArgs e)
        {
            _xrate = new ExchangeRateManager().GetExchangeRate(dtpFechaTransaccion.Value);
            txtXRate.Text = _xrate.ToString("N2");
        }
        private void RefrescaListaCheques()
        {
            if (ckSoloTipoSeleccionado.Checked)
            {
                var tipo = "L1";
                if (rbL2.Checked)
                {
                    tipo = "L2";
                }

                if (ckVerSoloParaDepositar.Checked)
                {
                    BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(tipo, true,
                        menorIgualaFecha: dtpFechaTransaccion.Value);
                }
                else
                {
                    BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(tipo, true);
                }
            }
            else
            {
                if (ckVerSoloParaDepositar.Checked)
                {
                    BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada("", true,
                        menorIgualaFecha: dtpFechaTransaccion.Value);
                }
                else
                {
                    BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada("", true);
                }
            }
        }


        private void ckSoloTipoSeleccionado_CheckedChanged(object sender, EventArgs e)
        {
            RefrescaListaCheques();
        }

        private void txtNumeroCheque_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroCheque.Text))
            {
                if (ckSoloTipoSeleccionado.Checked)
                {
                    var tipo = "L1";
                    if (rbL2.Checked)
                    {
                        tipo = "L2";
                    }

                    BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(tipo, true);
                }
                else
                {
                    BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada("", true);
                }

                return;
            }

            if (ckSoloTipoSeleccionado.Checked)
            {
                var tipo = "L1";
                if (rbL2.Checked)
                {
                    tipo = "L2";
                }

                BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(tipo, true, false,
                    txtNumeroCheque.Text);
            }
            else
            {
                BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada("", true, false,
                    txtNumeroCheque.Text);
            }
        }

        private void txtIdCheque_Leave(object sender, EventArgs e)
        {
            int idCheque = -1;
            if (string.IsNullOrEmpty(txtIdCheque.Text))
            {
                if (ckSoloTipoSeleccionado.Checked)
                {
                    var tipo = "L1";
                    if (rbL2.Checked)
                    {
                        tipo = "L2";
                    }

                    BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(tipo, true);
                }
                else
                {
                    BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada("", true);
                }

                return;
            }
            else
            {
                idCheque = Convert.ToInt32(txtIdCheque.Text);
            }

            if (ckSoloTipoSeleccionado.Checked)
            {
                var tipo = "L1";
                if (rbL2.Checked)
                {
                    tipo = "L2";
                }

                BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(tipo, true, false, "",
                    idCheque);
            }
            else
            {
                BsListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada("", true, false, "",
                    idCheque);
            }
        }

        private void rbL2_CheckedChanged(object sender, EventArgs e)
        {
            _tipoLx = rbL1.Checked ? "L1" : "L2";
            BsListaCheques.DataSource =
                new ChequesManager().GetListaChequesFiltrada(ckSoloTipoSeleccionado.Checked ? _tipoLx : "", true);
            txtNumeroOperacion.Text = new TransferenciaEntreCuentasManager().GenerateNumeroOperacion(_tipoLx);
            dgvListadoCheques.ClearSelection();
            dgvListadoCheques.CurrentCell = null;
        }

        private void rbL1_CheckedChanged(object sender, EventArgs e)
        {
            _tipoLx = rbL1.Checked ? "L1" : "L2";
            BsListaCheques.DataSource =
                new ChequesManager().GetListaChequesFiltrada(ckSoloTipoSeleccionado.Checked ? _tipoLx : "", true);
            txtNumeroOperacion.Text = new TransferenciaEntreCuentasManager().GenerateNumeroOperacion(_tipoLx);
            dgvListadoCheques.ClearSelection();
            dgvListadoCheques.CurrentCell = null;
        }

        private void btnAgregarCheque_Click(object sender, EventArgs e)
        {

        }

        private void AddChequeToTransferList(int idCheque)
        {
            var z = _dataList.Find(c => c.CHID == idCheque);
            if (z != null)
            {
                MessageBox.Show(@"El Cheque ya se encuentra agregado", @"Cheque Repetido", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var lx = "L1";
            if (rbL2.Checked)
                lx = "L2";

            var data = new ChequesManager().GetCheque(idCheque);
            var reg = new DatosXReg()
            {
                CUENTA = lx,
                IDITEM = _dataList.Count + 1,
                MONEDA = txtMonedaOrigen.Text,
                CH = true,
                CHID = idCheque,
                CHTIPO = data.TIPO,
                BCO = data.CHE_BANCO,
                BANCO = data.T0160_BANCOS.BCO_SHORTDESC,
                CONTABILIZADO = false,
                CUENTA_O = cmbCuentaOrigen.SelectedValue.ToString(),
                CUENTA_D = cmbCuentaDestino.SelectedValue.ToString(),
                GLD = new CuentasManager().GetSpecificCuentaInfo(cmbCuentaDestino.SelectedValue.ToString()).GLMAP,
                GLO = new CuentasManager().GetSpecificCuentaInfo(cmbCuentaOrigen.SelectedValue.ToString()).GLMAP,
                IDINT = 0,
            };

            if (txtMonedaOrigen.Text == txtMonedaDestino.Text)
            {
                if (txtMonedaDestino.Text == @"ARS")
                {
                    //moneda destino = ARS 
                    //moneda origen = ARS
                    reg.IMPORTE_O = data.IMPORTE.Value;
                    reg.IMPORTE_D = data.IMPORTE.Value;
                    reg.IMPORTE_ARS = data.IMPORTE.Value;
                }
                else
                {
                    //moneda destino = USD
                    //moneda origen = USD
                    reg.IMPORTE_O = data.IMPORTE.Value;
                    reg.IMPORTE_D = data.IMPORTE.Value;
                    reg.IMPORTE_ARS = data.IMPORTE.Value / _xrate;
                }
            }
            else
            {
                if (txtMonedaOrigen.Text == @"ARS")
                {
                    //moneda origen = ARS
                    //moneda destino = USD
                    reg.IMPORTE_O = data.IMPORTE.Value;
                    reg.IMPORTE_D = data.IMPORTE.Value / _xrate;
                    reg.IMPORTE_ARS = data.IMPORTE.Value;
                }
                else
                {
                    //moneda origen = USD
                    //moneda destino = ARS 
                    reg.IMPORTE_O = data.IMPORTE.Value;
                    reg.IMPORTE_D = data.IMPORTE.Value * _xrate;
                    reg.IMPORTE_ARS = data.IMPORTE.Value;
                }
            }

            _dataList.Add(reg);
            // dgvRegistroReg.DataSource = _dataList;
        }

        private void txtXRate_Leave(object sender, EventArgs e)
        {
            _xrate = string.IsNullOrEmpty(txtXRate.Text) ? 1 : Convert.ToDecimal(txtXRate.Text);
        }

        private void txtXRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void dgvRegistroReg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvRegistroReg[e.ColumnIndex, e.RowIndex].Value.ToString();
                //int numeroFormula = Convert.ToInt32(dgvFormulaList[dgvFormulaList.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "DEL":
                        {
                            //var idCheque = dgvRegistroReg[3, e.RowIndex].Value;
                            var iditem = Convert.ToInt32(dgvRegistroReg[0, e.RowIndex].Value);
                            var x = _dataList.Find(c => c.IDITEM == iditem);
                            _dataList.Remove(x);
                            RecalculaListaRegistro();
                            dgvRegistroReg.DataSource = null;
                            dgvRegistroReg.DataSource = _dataList;
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private void RecalculaListaRegistro()
        {
            decimal importeTotal = 0;
            int item = 1;
            foreach (var x in _dataList)
            {
                x.IDITEM = item++;
                importeTotal += x.IMPORTE_D;
            }

            txtImporteTransaccion.Text = importeTotal.ToString("C2");
            txtCantidadItems.Text = _dataList.Count.ToString();

            txtImporteARS.Text = txtMonedaImporteTransferir.Text == @"ARS"
                ? txtImporteTransaccion.Text
                : (FormatAndConversions.CCurrencyADecimal(txtImporteTransaccion.Text) * _xrate).ToString("C2");
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {

        }

        private bool ValidacionDatos()
        {
            if (_dataList.Count == 0)
            {
                MessageBox.Show(@"No existen items para transferir", @"Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (ValidaDisponibilidadCheques() == false)
            {
                MessageBox.Show(@"Alguno de los cheques no se encuentran disponibles en este momento",
                    @"Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                ckChequesOK.Checked = false;
                ckChequesOK.BackColor = Color.Crimson;
                return false;
            }

            ckChequesOK.Checked = true;
            ckChequesOK.BackColor = Color.LimeGreen;
            return true;
        }

        private void dgvListadoCheques_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rbL1.Checked == false && rbL2.Checked == false)
            {
                MessageBox.Show(@"Debe Seleccionar primero el tipo de operacion L1/L2", @"Seleccione Tipo LX",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ValidaDisponibilidadCheques()
        {
            foreach (var it in _dataList)
            {
                if (it.CHID <= 0) continue;

                var x = new ChequesManager().GetIfDisponible(it.CHID);
                if (x == false)
                    return false;
            }

            return true;
        }

        private XREGISTER_H MapHeaderData()
        {
            var h = new XREGISTER_H
            {
                TC = _xrate,
                CONTABILIZADO = false,
                CUENTAD = _cdestino,
                FECHA = dtpFechaTransaccion.Value,
                IDINT = 0,
                IMPORTE_TOTAL = FormatAndConversions.CCurrencyADecimal(txtImporteTransaccion.Text),
                LOG_DATE = DateTime.Now,
                LOG_USER = Environment.UserName,
                MONEDA = txtMonedaDestino.Text,
                NASIENTO = 0,
                REFNUM = txtNumeroOperacion.Text,
                TIPO = _tipoLx,
            };
            return h;
        }

        private List<XREGISTER_I> MapItemsData()
        {
            var lst = new List<XREGISTER_I>();

            foreach (var i in _dataList)
            {
                var it = new XREGISTER_I()
                {
                    IDINT = _idReg,
                    CUENTA = _tipoLx,
                    CUENTA_O = i.CUENTA_O,
                    CUENTA_D = i.CUENTA_D,
                    CONTABILIZADO = false,
                    IDITEM = i.IDITEM,
                    GLD = i.GLD,
                    GLO = i.GLO,
                    IMPORTE_O = i.IMPORTE_O,
                    IMPORTE_D = i.IMPORTE_D,
                    MONEDA = i.MONEDA,
                    IMPORTE_ARS = i.IMPORTE_ARS,
                    CH = i.CH,
                    CHID = i.CHID,
                    CHTIPO = i.CHTIPO,
                };
                lst.Add(it);
            }

            return lst;
        }

        private void ContabilizarOperacion()
        {
            var idTransaccion = new TransferenciaEntreCuentasManager().SetTransactionHeader(MapHeaderData());
            if (idTransaccion < 0)
            {
                MessageBox.Show(@"Ha Ocurrido un error y la transaccion no se ha grabado",
                    @"Error en Grabacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            txtIdTransaccion.Text = idTransaccion.ToString();
            _idReg = idTransaccion;
            if (new TransferenciaEntreCuentasManager().UpdateTransactionItems(MapItemsData()) > 0)
            {
                ckItemsSaved.Checked = true;
                ckItemsSaved.BackColor = Color.LimeGreen;
            }
            else
            {
                ckItemsSaved.Checked = false;
                ckItemsSaved.BackColor = Color.Crimson;
                return;
            }

            //**** Contabilizacion
            var asientoGenerico = new AsientoGenerico("REG");
            var numeroAsiento = asientoGenerico.CreaAsientoTransferenciaEC(idTransaccion, txtObservacion.Text);
            txtNumeroAsiento.Text = numeroAsiento.IdDocu.ToString();

            if (numeroAsiento.IdDocu > 0)
            {
                ckContabilizacionCorrecta.Checked = true;
                ckContabilizacionCorrecta.BackColor = Color.LimeGreen;
                new TransferenciaEntreCuentasManager().SetOperacionContabilizada(idTransaccion, numeroAsiento.IdDocu);
            }
            else
            {
                ckContabilizacionCorrecta.Checked = false;
                ckContabilizacionCorrecta.BackColor = Color.Crimson;

                MessageBox.Show(
                    @"Ha Ocurrido un error en la generacion del Asiento Contable y la transaccion NO se ha grabado",
                    @"Error en Grabacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            txtNumeroAsiento.BackColor = numeroAsiento.IdDocu > 0 ? Color.LimeGreen : Color.Crimson;


            //Da de baja cheques en T0154
            foreach (var i in _dataList.FindAll(c => c.CH))
            {
                new ChequesManager().UtilizaChequeEnReg(i.CHID, idTransaccion, numeroAsiento.IdDocu);
                new RegisterManager().AddRegisterRecord(i.CUENTA_O, dtpFechaTransaccion.Value, "TRX",
                    txtNumeroOperacion.Text, TipoEntidad.Transferencia, 0, "Transferencia Salida", txtMonedaOrigen.Text, 0,
                    i.IMPORTE_O, i.CHID, _tipoLx, i.GLO, numeroAsiento.IdDocu, "REG");
                new RegisterManager().AddRegisterRecord(i.CUENTA_D, dtpFechaTransaccion.Value, "TRX",
                    txtNumeroOperacion.Text, TipoEntidad.Transferencia, 0, "Transferencia Entrada", txtMonedaOrigen.Text,
                    i.IMPORTE_D, 0, i.CHID, _tipoLx, i.GLD, numeroAsiento.IdDocu, "REG");
            }

            foreach (var i in _dataList.FindAll(c => c.CH == false))
            {
                new RegisterManager().AddRegisterRecord(i.CUENTA_O, dtpFechaTransaccion.Value, "TRX",
                    txtNumeroOperacion.Text, TipoEntidad.Transferencia, 0, "Transferencia Salida", txtMonedaOrigen.Text, 0,
                    i.IMPORTE_O, 0, _tipoLx, i.GLO, numeroAsiento.IdDocu, "REG");
                new RegisterManager().AddRegisterRecord(i.CUENTA_D, dtpFechaTransaccion.Value, "TRX",
                    txtNumeroOperacion.Text, TipoEntidad.Transferencia, 0, "Transferencia Entrada", txtMonedaOrigen.Text,
                    i.IMPORTE_D, 0, 0, _tipoLx, i.GLD, numeroAsiento.IdDocu, "REG");
            }

            MessageBox.Show(@"Se ha contabilizado y transferido correctamente los valores seleccionados",
                @"Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnTransferOperacion.Enabled = false;
        }

        private void btnImprimirOperacion_Click(object sender, EventArgs e)
        {
            var f0 = new RpvTransferenciaReg(_idReg);
            f0.Show();
        }

        private void btnprintOld_Click(object sender, EventArgs e)
        {
            if (_idReg <= 0)
            {
                if (string.IsNullOrEmpty(txtIdTransaccion.Text))
                {
                    MessageBox.Show(@"Debe proveer ID Operacion", @"Falta el Id Operacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtIdTransaccion.ReadOnly = false;
                    txtIdTransaccion.Enabled = true;
                    return;
                }
                else
                {
                    if (Convert.ToInt32(txtIdTransaccion.Text) <= 0)
                    {
                        MessageBox.Show(@"Debe proveer ID Operacion", @"Falta el Id Operacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        txtIdTransaccion.ReadOnly = false;
                        txtIdTransaccion.Enabled = true;
                        return;
                    }
                }
            }

            var f0 = new RpvTransferenciaReg(Convert.ToInt32(txtIdTransaccion.Text));
            f0.Show();
        }

        private void ckVerSoloParaDepositar_CheckedChanged(object sender, EventArgs e)
        {
            RefrescaListaCheques();
        }

        private void TxtIdCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void DgvListadoCheques_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (_headerValidado == false)
            {
                if (ValidaDatosHeader() == false)
                    return;
                dtpFechaTransaccion.Enabled = false;
                cmbCuentaDestino.Enabled = false;
            }

            foreach (DataGridViewRow r in dgvListadoCheques.SelectedRows)
            {
                var idChequeSeleccionado = r.Cells[0].Value.ToString();
                AddChequeToTransferList(Convert.ToInt32(idChequeSeleccionado));
                dgvListadoCheques.Rows.Remove(r);
            }

            RecalculaListaRegistro();
            dgvRegistroReg.DataSource = null;
            dgvRegistroReg.DataSource = _dataList;
            dgvListadoCheques.ClearSelection();
            dgvListadoCheques.CurrentCell = null;
        }

        private void BtnTransferOK_Click(object sender, EventArgs e)
        {
            if (ValidacionDatos() == false)
                return;

            var resp = MessageBox.Show(
                @"Confirma la transferencia entre cuentas con los valores mostrados en pantalla?",
                @"Confirmacion de Operacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            ContabilizarOperacion();
        }

        private void BtnPrintOperacion_Click(object sender, EventArgs e)
        {
            var f0 = new RpvTransferenciaReg(_idReg);
            f0.Show();
        }

    }
}