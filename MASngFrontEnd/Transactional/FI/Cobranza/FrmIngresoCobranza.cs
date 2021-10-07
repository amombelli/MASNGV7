using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData.Customer_Master;
using MASngFE.Transactional.CRM;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.CRM;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.VBTools;
using TecserEF.Entity;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmIngresoCobranza : Form
    {
        public FrmIngresoCobranza(int modo)
        {
            _modo = modo;
            InitializeComponent();
        }

        public FrmIngresoCobranza(int modo, int idCob = 0)
        {
            //Carga de datos desde cobranza conversion
            _modo = modo;
            _idCob = idCob;
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------
        private readonly Color _ckokColor = Color.LightGreen;
        private readonly Color _ckerrorColor = Color.OrangeRed;
        private readonly int _modo;
        private int? _idCliente;
        private string _tipoLx;
        private int _idCob;
        private List<T0150_CUENTAS> _lcuenta = new List<T0150_CUENTAS>();
        private List<T0085_PERSONAL> _cobrador = new List<T0085_PERSONAL>();
        public List<T0206_COBRANZA_I> ListOfItemsCobranza = new List<T0206_COBRANZA_I>();
        private decimal _xrate = 0;
#pragma warning disable CS0414 // The field 'FrmIngresoCobranza._dataValidatedAfterDgv' is assigned but its value is never used
        private bool _dataValidatedAfterDgv = true;
#pragma warning restore CS0414 // The field 'FrmIngresoCobranza._dataValidatedAfterDgv' is assigned but its value is never used
        private T0230_GescoHeader gescoData = new T0230_GescoHeader();
        private EstructuraPadronAfipA5 cn;
        private PadronAfipWsA5 _xAfip;
        //-------------------------------------------------------------------------------------
        private void FrmIngresoCobranza_Load(object sender, EventArgs e)
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "COBI", true, true))
            {
                this.Close();
            }
            ConfiguraInicial();
            ConfiguraSegunModo();
        }

        private void ConfiguraInicial()
        {
            _lcuenta = new CuentasManager().GetListCuentasAvailableCobranza();
            var lx = new CustomerManager().GetCompleteListofBillTo(true);
            t0006MCLIENTESBindingSource.DataSource = lx;
            _cobrador = new HumanResourcesManager().GetListAllActiveCobrador();
            var newCob = new T0085_PERSONAL()
            {
                SHORTNAME = "MOTO EXT",
            };
            _cobrador.Add(newCob);
            cmbCobrador.DataSource = _cobrador;
            t0206COBRANZAIBindingSource.DataSource = ListOfItemsCobranza;
            dgvCobranza.DataSource = t0206COBRANZAIBindingSource;
            _xrate = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            txtXRate.Text = _xrate.ToString("N2");
            cmbRazonSocial.Text = null;
            cmbFantasia.Text = null;
            cmbCobrador.Text = null;
            if (ckTitularAfip.Checked)
            {
                _xAfip = new PadronAfipWsA5(ModoEjecucion.Produccion);
            }
        }
        private void ConfiguraSegunModo()
        {
            switch (_modo)
            {
                case 1:
                    t0206COBRANZAIBindingSource.DataSource = ListOfItemsCobranza;
                    break;

                case 2:
                    LoadCobranzaTemporalData();
                    break;
            }
        }


        private void SetDgvCell(int numeroRow, string cellName, bool readOnly, object valorCelda,
            Color? colorFore = null, Color? coloreBack = null, bool asignarValor = true)
        {
            //this.dgvCobranza.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranza_CellValueChanged);
            var xcelda = dgvCobranza.Rows[numeroRow].Cells[cellName];
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

            //dgvCobranza.EndEdit();
            //this.dgvCobranza.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranza_CellValueChanged);
        }

        private void FormatBlockAll(int numeroRow)
        {
            SetDgvCell(numeroRow, __linea.Name, true, null, asignarValor: false);
            SetDgvCell(numeroRow, __cuenta.Name, true, null, asignarValor: false);
            SetDgvCell(numeroRow, __bankDescripcion.Name, true, null, asignarValor: false, colorFore: Color.Navy);
            SetDgvCell(numeroRow, __titular.Name, true, null, asignarValor: false, colorFore: Color.Navy);
            SetDgvCell(numeroRow, __descripcion.Name, true, null, asignarValor: false, colorFore: Color.Navy);
            //
            SetDgvCell(numeroRow, __importe.Name, true, null, asignarValor: false);
            SetDgvCell(numeroRow, __numCheque.Name, true, null, asignarValor: false);
            SetDgvCell(numeroRow, __fechaAcred.Name, true, null, asignarValor: false);
            SetDgvCell(numeroRow, __cuit.Name, true, null, asignarValor: false);
            SetDgvCell(numeroRow, __cheInterior.Name, true, null, asignarValor: false);
            SetDgvCell(numeroRow, __chBank.Name, true, null, asignarValor: false);
            SetDgvCell(numeroRow, __Echeque.Name, true, null, asignarValor: false);
            SetDgvCell(numeroRow, __idCheque.Name, true, null, asignarValor: false);
            //
        }
        //Formateo de propiedades segun tipo de cuenta seleccionada
        private void FormatCheque(int numeroRow)
        {
            FormatBlockAll(numeroRow);
            SetDgvCell(numeroRow, __importe.Name, false, (decimal)0, asignarValor: false);
            SetDgvCell(numeroRow, __numCheque.Name, false, null, asignarValor: false);
            SetDgvCell(numeroRow, __fechaAcred.Name, false, null, asignarValor: false);
            SetDgvCell(numeroRow, __cuit.Name, false, null, asignarValor: false);
            SetDgvCell(numeroRow, __cheInterior.Name, false, false, asignarValor: false);
            SetDgvCell(numeroRow, __chBank.Name, false, false, asignarValor: false);
            SetDgvCell(numeroRow, __Echeque.Name, false, false, asignarValor: false);
        }
        private void FormatEfectivo(int numeroRow)
        {
            FormatBlockAll(numeroRow);
            SetDgvCell(numeroRow, __importe.Name, false, (decimal)0, asignarValor: false);
        }
        private void FormatCuentaNoManejada(int numeroRow)
        {
            FormatBlockAll(numeroRow);
        }



        public void CompletaFormateaDataGridView()
        {
            t0206COBRANZAIBindingSource.DataSource = ListOfItemsCobranza.ToList();
            dgvCobranza.DataSource = t0206COBRANZAIBindingSource;
            foreach (DataGridViewRow row in dgvCobranza.Rows)
            {
                //Completa descripcion de cuenta
                if (row.Cells[__descripcion.Name].Value == null)
                {
                    row.Cells[__descripcion.Name].Value = new CuentasManager()
                        .GetSpecificCuentaInfo(row.Cells[__cuenta.Name].Value.ToString()).CUENTA_DESC;
                }

                var cuentaX = row.Cells[__cuenta.Name].Value.ToString();
                switch (cuentaX)
                {
                    case "CHE":
                        FormatCheque(row.Index);
                        break;
                    default:
                        FormatEfectivo(row.Index);
                        break;
                }

                //Completa titular de cuenta/cuit
                if (row.Cells[__cuit.Name].Value != null && row.Cells[__titular.Name].Value == null &&
                    ckTitularAfip.Checked)
                {
                    //todo: pero no funciona la interfaz AFIP?
                    cn = _xAfip.ObtieneDatosPadronA5(row.Cells[__cuit.Name].Value.ToString());
                    if (string.IsNullOrEmpty(cn.Denominacion))
                    {
                        ListOfItemsCobranza[row.Index].CHEQUE_TITULAR = cn.Denominacion;
                    }
                }

                //Completa descripcion de banco
                if (row.Cells[__chBank.Name].Value != null && row.Cells[__bankDescripcion.Name].Value == null)
                {
                    row.Cells[__bankDescripcion.Name].Value = new BankManager().GetBankData(row.Cells[__chBank.Name].Value.ToString()).BCO_SHORTDESC;
                }

            }
        }

        private void dgvCobranza_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCobranza.CurrentCell.ColumnIndex == dgvCobranza[__importe.Name, e.RowIndex].ColumnIndex)
            {
                //MODIFICACION DE IMPORTE -
                UpdateListWithCalculosImportes();
                CompletaFormateaDataGridView();
                return;
            }

            //cualquier otra modificacion es permitida solamente en cuenta CHEQUES
            if (dgvCobranza.Rows[e.RowIndex].Cells[__cuenta.Name].Value.ToString() == "CHE")
            {
                if (dgvCobranza.CurrentCell.ColumnIndex == dgvCobranza[__cuit.Name, e.RowIndex].ColumnIndex)
                {
                    var nuevoCuit = dgvCobranza.CurrentCell.Value.ToString();
                    if (new CuitValidation().ValidarCuit(nuevoCuit))
                    {
                        dgvCobranza.CurrentCell.Style.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        dgvCobranza.CurrentCell.Style.BackColor = Color.Crimson;
                        _dataValidatedAfterDgv = false;
                    }
                }

                if (dgvCobranza.CurrentCell.ColumnIndex == dgvCobranza[__chBank.Name, e.RowIndex].ColumnIndex) //Banco
                {
                    var bankData = new BankManager().GetBankData(dgvCobranza.CurrentCell.Value.ToString());
                    if (bankData == null)
                    {
                        dgvCobranza.CurrentCell.Style.BackColor = Color.Crimson;
                        _dataValidatedAfterDgv = false;
                    }
                    else
                    {
                        dgvCobranza.CurrentCell.Style.BackColor = Color.GreenYellow;
                        dgvCobranza.Rows[e.RowIndex].Cells[11].Value = bankData.BCO_SHORTDESC;
                    }
                }

                if (dgvCobranza.CurrentCell.ColumnIndex == dgvCobranza[__fechaAcred.Name, e.RowIndex].ColumnIndex) //Fecha Acreditacion
                {

                }
            }
            else
            {
                MessageBox.Show(@"La cuenta no permite modificar este valor", @"Error en Actualizacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                dgvCobranza.CurrentCell.Value = null;
            }
        }

        private void cmbRazonSocial_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbRazonSocial.Text))
            {
                txtIdCliente.Text = null;
                cmbFantasia.Text = null;
            }
        }


        public void UpdateListWithCalculosImportes()
        {
            decimal totalCob = 0;

            //solo para importe recibo en pesos
            foreach (var item in ListOfItemsCobranza)
            {
                if (item.MON_ITEM != "ARS")
                {
                    item.IMP_RECIBO = item.IMP_ITEM * _xrate;
                }
                else
                {
                    item.IMP_RECIBO = item.IMP_ITEM;
                }

                totalCob = totalCob + item.IMP_RECIBO;
            }

            if (string.IsNullOrEmpty(txtImporteReciboManual.Text))
                txtImporteReciboManual.Text = 0.ToString("C2");
            txtImporteReciboIngresado.Text = totalCob.ToString("C2");

            decimal ingresadoManual = FormatAndConversions.CCurrencyADecimal(txtImporteReciboManual.Text);
            decimal valoresIngresados = FormatAndConversions.CCurrencyADecimal(txtImporteReciboIngresado.Text);
            decimal diferencia = ingresadoManual - valoresIngresados;

            txtDiferencia.Text = diferencia.ToString("C2");
            if (diferencia > 0)
            {
                txtDiferencia.BackColor = Color.Yellow;
            }
            else if (diferencia == 0)
            {
                txtDiferencia.BackColor = Color.LimeGreen;
            }
            else
            {
                txtDiferencia.BackColor = Color.Crimson;
            }
        }

        private void dtpFechaCobranza_ValueChanged(object sender, EventArgs e)
        {
            _xrate = new ExchangeRateManager().GetExchangeRate(dtpFechaCobranza.Value);
            txtXRate.Text = _xrate.ToString("N2");
        }

        private void txtXrate_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtXRate.Text))
            {
                txtXRate.Text = 1.ToString();
            }

            _xrate = Convert.ToDecimal(txtXRate.Text);
        }

        private void txtXrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtImporteReciboManual_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidaDatosHeaderCobranza())
            {
                var resp = MessageBox.Show(@"Confirma el ingreso de la Cobranza?", @"Confirmacion de Cobranza",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;

                if (_tipoLx == "L1")
                {
                    string sucu = new CobranzaUtils().GetReciboOficialSucursal();
                    string nume = new CobranzaUtils().GetNextReciboOficial();
                    txtNumeroReciboOficialL1.Text = sucu + @"-" + nume;
                    new CobranzaUtils().SaveUltimoReciboUtilizado(nume);
                }
                else
                {
                    txtNumeroReciboOficialL1.Text = null;
                }

                IngresaCobranza();

                var pl = new GescoPagoListo().GetRegistroPL(_idCliente.Value);
                if (pl == null)
                {
                    //No hay registro de PL - Solo setea la fecha de Ultima Cobranza
                    GescoPagoListo.SetFechaUltimaCobranza(_idCliente.Value, dtpFechaCobranza.Value, _tipoLx);
                }
                else
                {
                    if (dtpFechaCobranza.Value <= pl.FechaPago)
                    {
                        //Si ingresa una cobranza y hay un aviso de pago con fecha posterior pregunta si se corresponde
                        //al mismo pago para eliminarlo de PL.
                        resp = MessageBox.Show(
                            $@"Existe un Aviso de Pago con Fecha=  {pl.FechaPago.ToString("d")} - Este Pago se corresponde al Aviso Registrado?",
                            @"Borrado Flag PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resp == DialogResult.Yes)
                        {
                            new GescoPagoListo().SetPagoRegistrado(_idCliente.Value, _idCob);
                        }
                        else
                        {
                            //Solo se Registra la Fecha del Pago
                            GescoPagoListo.SetFechaUltimaCobranza(_idCliente.Value, dtpFechaCobranza.Value, _tipoLx);
                        }
                    }
                    else
                    {
                        new GescoPagoListo().SetPagoRegistrado(_idCliente.Value, Convert.ToInt32(txtIdCobranza.Text));
                    }
                }

                //var pasarCobrar =
                //    new GescoDataUpdateManager().UpdateRetiraPasarACobrar(Convert.ToInt32(txtIdCliente.Text),
                //        dtpFechaCobranza.Value);
                //if (pasarCobrar > 0)
                //{
                //    ckPasarACobrarRetirado.Checked = true;
                //    ckPasarACobrarRetirado.BackColor = Color.LimeGreen;
                //}
                //else
                //{
                //    ckPasarACobrarRetirado.Checked = false;
                //    ckPasarACobrarRetirado.BackColor = Color.Yellow;
                //}

                if (_idCob > 0 && _modo == 2)
                    new CobranzaTemporalManager().UpdateTemporalAfterCobranzaIn(_idCob,
                        Convert.ToInt32(txtIdCobranza.Text), txtNumeroReciboInterno.Text);
            }
        }

        private T0205_COBRANZA_H MapCobranzaHeader()
        {
            var h = new T0205_COBRANZA_H()
            {
                IdCliente = Convert.ToInt32(txtIdCliente.Text),
                CCK = false,
                DIAS_PP = 0,
                DOC_CANCELADO = false,
                DOC_DESIMPUTADO = false,
                IDCOB = _idCob,
                IMPRESO = false,
                MON = cmbMonedaRecibo.Text,
                Monto = FormatAndConversions.CCurrencyADecimal(txtImporteReciboIngresado.Text),
                NRECIBO = txtNumeroReciboInterno.Text,
                NRECIPROVI = txtNumeroReciboProvisorioL1.Text,
                ReciboDesc = txtObservaciones.Text,
                TC = Convert.ToDecimal(txtXRate.Text),
            };
            h.FECHA = Convert.ToDateTime(dtpFechaCobranza.Value);
            h.CUENTA = _tipoLx;

            h.LogUser = string.IsNullOrEmpty(txtLogUser.Text) ? Environment.UserDomainName : txtLogUser.Text;
            if (string.IsNullOrEmpty(txtLogIngresoFecha.Text))
            {
                txtLogIngresoFecha.Text = DateTime.Today.ToString("g");
                h.LogDate = DateTime.Today;
            }
            else
            {
                h.LogDate = Convert.ToDateTime(txtLogIngresoFecha.Text);
            }

            if (String.IsNullOrEmpty(txtNumeroAsiento.Text))
            {
                h.NASIENTO = null;
            }
            else
            {
                h.NASIENTO = Convert.ToInt32(txtNumeroAsiento.Text);
            }
            return h;
        }

        private List<T0206_COBRANZA_I> MapItemsList()
        {
            foreach (var i in ListOfItemsCobranza)
            {
                i.NRECIBO = txtNumeroReciboInterno.Text;
                i.MON_RECIBO = cmbMonedaRecibo.Text;
                i.TC_ITEM = Convert.ToDecimal(txtXRate.Text);
            }
            return ListOfItemsCobranza;
        }

        private void IngresaCobranza()
        {
            var documento = new CobranzaManagerBase(Convert.ToInt32(txtIdCliente.Text), _tipoLx);
            string monedaRecibo = "ARS";
            if (cmbMonedaRecibo.SelectedValue != null)
            {
                monedaRecibo = cmbMonedaRecibo.SelectedValue.ToString();
            }

            int diasPp = new CobranzaUtils().CalculaDiasPromedioPago(ListOfItemsCobranza, dtpFechaCobranza.Value);
            txtDpp.Text = diasPp.ToString();
            txtDpp.BackColor = Color.LightPink;
            documento.SetCobranzaHeader(txtNumeroReciboInterno.Text, txtNumeroReciboOficialL1.Text,
                txtNumeroReciboProvisorioL1.Text,
                dtpFechaCobranza.Value, monedaRecibo,
                FormatAndConversions.CCurrencyADecimal(txtImporteReciboIngresado.Text),
                Convert.ToDecimal(txtXRate.Text), txtObservaciones.Text, diasPp);

            foreach (var i in ListOfItemsCobranza)
            {
                if (i.TC_ITEM == null)
                    i.TC_ITEM = Convert.ToDecimal(txtXRate.Text);

                if (i.CUENTA == "CHE")
                {
                    var idChequeAdded = new ChequesManager().AddNewCheque(_tipoLx,
                        txtNumeroReciboInterno.Text, dtpFechaCobranza.Value, Convert.ToInt32(txtIdCliente.Text),
                        i.CHEQUE_FECHA.Value,
                        i.IMP_RECIBO, i.CHEQUE_NUMERO, i.CHEQUE_BANCO, i.Che_Interior, i.CHEQUE_CUIT,
                        i.CHEQUE_TITULAR, i.MON_ITEM, i.COMENTARIO, _idCob, Convert.ToInt32(txtIdCliente.Text), null,
                        i.Che_Electronico);

                    documento.AddCobranzaItemCheque(idChequeAdded, i.IMP_RECIBO, i.TC_ITEM.Value, i.COMENTARIO);
                }
                else
                {
                    documento.AddCobranzaItem(i.CUENTA, i.MON_ITEM, i.IMP_ITEM, i.IMP_RECIBO,
                        i.TC_ITEM.Value, i.COMENTARIO);
                }
            }

            var resultado = documento.GrabaCobranza();

            if (resultado.IdCobranza > 0)
            {
                ckHeaderOk.Checked = true;
                ckHeaderOk.BackColor = _ckokColor;
                txtIdCobranza.Text = resultado.IdCobranza.ToString();
            }
            else
            {
                ckHeaderOk.Checked = false;
                ckHeaderOk.BackColor = _ckerrorColor;
                txtIdCobranza.Text = @"Error";
                MessageBox.Show(@"Ha ocurrido un error en el registro de la Cobranza",
                    @"No se pudo crear el Header de la Cobranza",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (resultado.NumeroItems > 0)
            {
                ckItemOk.Checked = true;
                ckItemOk.BackColor = _ckokColor;
            }
            else
            {
                ckItemOk.Checked = false;
                ckItemOk.BackColor = _ckerrorColor;
                MessageBox.Show(
                    @"Ha ocurrido un error al grabar los items de la cobranza" + Environment.NewLine +
                    @"No se ha contabilizado NADA", @"Error en Cobranza CostItems", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            //Contabilizacion del Documento
            var asientoCobranza = new AsCobranza(resultado.IdCobranza, "COBI1");
            var asientoResultado = asientoCobranza.GeneraAsientoFromRecibo();

            if (asientoResultado.IdDocu < 0)
            {
                ckAsientoOk.Checked = false;
                ckAsientoOk.BackColor = Color.Red;
                MessageBox.Show(@"Ha ocurrido un error al generar el Asiento Contable" + Environment.NewLine +
                                @"No se ha contabilizado NADA", @"Error en Cobranza CostItems", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            txtIdNAS.Text = asientoResultado.IdDocu.ToString();
            txtNumeroAsiento.Text = txtIdNAS.Text;
            ckAsientoOk.Checked = true;
            ckAsientoOk.BackColor = Color.LimeGreen;


            var gestionCtaCte = new CobranzaManagerExt2(resultado.IdCobranza);


            var idCtaCte = gestionCtaCte.AddRegistrosUpdateSaldosCteCte();
            if (idCtaCte > 0)
            {
                ck201Ok.Checked = true;
                txtIdCtaCte.Text = idCtaCte.ToString();
                ck201Ok.BackColor = Color.LimeGreen;
                if (rbL1.Checked)
                {
                    var ctaCte = new CtaCteCustomer(Convert.ToInt32(txtIdCliente.Text));
                    var saldoL1 = ctaCte.GetResultadoCtaCte("L1");
                    var saldoL2 = ctaCte.GetResultadoCtaCte("L2");

                    ck202Ok.Checked = saldoL1.SaldoOK;
                    ck202Ok.BackColor = saldoL1.SaldoColor;
                    txtNewSaldoL1.Text = saldoL1.SaldoDetalle.ToString("C2");
                    txtNewSaldoL2.Text = saldoL2.SaldoDetalle.ToString("C2");
                    txtNewSaldoL1.BackColor = saldoL1.SaldoColor;
                    txtNewSaldoL2.BackColor = saldoL2.SaldoColor;
                }
                else
                {
                    var ctaCte = new CtaCteCustomer(Convert.ToInt32(txtIdCliente.Text));
                    var saldoL1 = ctaCte.GetResultadoCtaCte("L1");
                    var saldoL2 = ctaCte.GetResultadoCtaCte("L2");

                    ck202Ok.Checked = saldoL2.SaldoOK;
                    ck202Ok.BackColor = saldoL2.SaldoColor;
                    txtNewSaldoL1.Text = saldoL1.SaldoDetalle.ToString("C2");
                    txtNewSaldoL2.Text = saldoL2.SaldoDetalle.ToString("C2");
                    txtNewSaldoL1.BackColor = saldoL1.SaldoColor;
                    txtNewSaldoL2.BackColor = saldoL2.SaldoColor;
                }
            }
            else
            {
                ck201Ok.Checked = false;
                ck202Ok.Checked = false;
                ck201Ok.BackColor = Color.Red;
                ck202Ok.BackColor = Color.Red;
                MessageBox.Show(@"Ha ocurrido un error al agregar el movimineto de CtaCte " + Environment.NewLine +
                                @"Revertir", @"Error en Cobranza CostItems", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            //agrega cobranza a t0208
            if (gestionCtaCte.SetCobranzaNoImputada(idCtaCte) <= 0)
            {
                ck208Ok.Checked = false;
                ckAsientoOk.BackColor = Color.Red;
                MessageBox.Show(@"Ha ocurrido un error al registrar la cobranza no imputada" + Environment.NewLine +
                                @"Revertir", @"Error en Cobranza CostItems", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ck208Ok.Checked = true;
            ck208Ok.BackColor = Color.LimeGreen;


            gestionCtaCte.UpdateCobranzaHeaderNas(Convert.ToInt32(txtIdNAS.Text));
            gestionCtaCte.RegistraCobranzaEnRegister();

            MessageBox.Show($"Se ha Ingresado la Cobranza en forma Correcta - Dias Promedio de Pago (DPP) = {diasPp}",
                @"INGRESO DE COBRANZA CORRECTO", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

            btnIngresar.Enabled = false;
        }


        private bool ValidaDatosHeaderCobranza()
        {
            if (ListOfItemsCobranza.Count == 0)
            {
                MessageBox.Show(@"La cobranza no contine items", @"Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show(@"Debe Seleccionar un Cliente!", @"Validacion de Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cmbRazonSocial.Focus();
                return false;
            }

            if (!rbL1.Checked && !rbL2.Checked)
            {
                MessageBox.Show(@"Te olvidaste de seleccionar cobranza L1 o L2", @"Validacion de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtNumeroReciboInterno.Text))
            {
                MessageBox.Show(@"Debe indicar el numero INTERNO de recibo (SERIE)", @"Numero de Recibo en Blanco",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (string.IsNullOrEmpty(txtImporteReciboIngresado.Text))
            {
                MessageBox.Show(@"No hay importe de items", @"Validacion de Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtImporteReciboManual.Text))
            {
                MessageBox.Show(
                    @"No ha ingresado en forma manual el IMPORTE de la cobrazna. Se ha actualizado en forma automatica al valor de items ingresados!",
                    @"Valor Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtImporteReciboManual.Text = txtImporteReciboIngresado.Text;
                txtImporteReciboManual.BackColor = Color.Yellow;
            }

            var valorCobranza = FormatAndConversions.CCurrencyADecimal(txtImporteReciboManual.Text);
            var valorCobranzaIngresado =
                FormatAndConversions.CCurrencyADecimal(txtImporteReciboIngresado.Text);

            if (valorCobranza != valorCobranzaIngresado)
            {
                var resp = MessageBox.Show(
                    @"El valor de la cobranza ingresado por Ud. y el valor de los items ingresados no coinciden" +
                    Environment.NewLine +
                    @"Desea continuar de todoas formas ajustando el valor de la cobranza al valor de items ingresados?",
                    @"Valor Cobranza", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                txtImporteReciboManual.BackColor = Color.Crimson;
                if (resp == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    txtImporteReciboManual.Text = txtImporteReciboIngresado.Text;
                    txtImporteReciboManual.BackColor = Color.Yellow;
                }
            }
            else
            {
                txtImporteReciboManual.BackColor = Color.Green;
            }


            if (rbL1.Checked)
            {
                //L1
                if (string.IsNullOrEmpty(txtDeudaL1.Text))
                {
                    txtDeudaL1.Text = 0.ToString("C2");
                }

                if (string.IsNullOrEmpty(txtNumeroReciboOficialL1.Text))
                {
                    if (MessageBox.Show(
                            @"ATENCION: Debiera proveer un numero de recibo OFICIAL" + Environment.NewLine +
                            @"Desea continuar sin numero de recibo OFICIAL?", @"Numero de Recibo Oficial en Blanco",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        txtNumeroReciboOficialL1.Focus();
                        return false;
                    }
                }


                var saldoL1 = FormatAndConversions.CCurrencyADecimal(txtDeudaL1.Text);
                if (valorCobranzaIngresado > saldoL1)
                {
                    if (MessageBox.Show(
                            @"El Valor de la cobranza es mayor al saldo L1, por lo que quedará saldo a favor. Confirma que es correcto?",
                            @"Pago a Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false;
                }
            }
            else
            {
                //L2
                if (string.IsNullOrEmpty(txtDeudaL2.Text))
                {
                    txtDeudaL2.Text = 0.ToString("C2");
                }

                var saldoL2 = FormatAndConversions.CCurrencyADecimal(txtDeudaL2.Text);
                if (valorCobranzaIngresado > saldoL2)
                {
                    if (MessageBox.Show(
                            @"El Valor de la cobranza es mayor al saldo L2, por lo que quedará saldo a favor. Confirma que es correcto?",
                            @"Pago a Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false;
                }
            }

            return true;
        }

        private void txtNumeroReciboInterno_Leave(object sender, EventArgs e)
        {
            txtNumeroReciboInterno.Text = txtNumeroReciboInterno.Text.ToUpper();

            if (new CobranzaManagerBase(Convert.ToInt32(txtIdCliente.Text), _tipoLx).CheckIfReciboInternoExist(
                txtNumeroReciboInterno.Text))
            {
                txtNumeroReciboInterno.BackColor = Color.LightGreen;
            }
            else
            {
                MessageBox.Show(@"El numero de Recibo Ingresado ya Existe", @"Error en numero de SERIE/Recibo interno",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroReciboInterno.BackColor = Color.Crimson;
                txtNumeroReciboInterno.Text = null;
            }
        }

        private void cmbRazonSocial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedValue == null)
            {
                txtIdCliente.Text = null;
                _idCliente = null;
                return;
            }
            _idCliente = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            txtIdCliente.Text = cmbRazonSocial.SelectedValue.ToString();
            RemapCustomerData();
        }

        private void RemapCustomerData()
        {
            var cust = new CustomerManager().GetCustomerBillToData(_idCliente.Value);
            var cta = new CtaCteCustomer(_idCliente.Value);
            //
            txtZtermL1.Text = cust.ZTERML1;
            txtZtermL2.Text = cust.ZTERML2;
            //
            ckClienteBloqueadoEntrega.Checked = cust.BLK_DELIVERY;
            ckClienteBloqueadoPedido.Checked = cust.BLK_PEDIDO;
            //
            var r1 = cta.GetResultadoCtaCte("L1");
            var r2 = cta.GetResultadoCtaCte("L2");
            //
            txtDeudaL1.Text = r1.SaldoDetalle.ToString("C2");
            txtDeudaL1.BackColor = r1.SaldoColor;
            txtDeudaL2.Text = r2.SaldoDetalle.ToString("C2");
            txtDeudaL2.BackColor = r2.SaldoColor;
            txtDeudaTotal.Text = (r1.SaldoDetalle + r2.SaldoDetalle).ToString("C2");
            //
            if (cust.Limite_credito == null)
            {
                txtLimiteCredito.Text = null;
                lLimiteStatus.Text = @"Sin Asignar";
                lLimiteStatus.BackColor = Color.LightBlue;
            }
            else
            {
                txtLimiteCredito.Text = cust.Limite_credito.Value.ToString("C2");
                var difExcede = cust.Limite_credito.Value - r1.SaldoDetalle - r2.SaldoDetalle;
                if (difExcede > 0)
                {
                    lLimiteStatus.Text = @"OK";
                    lLimiteStatus.BackColor = Color.LightGreen;
                }
                else
                {
                    if (difExcede == 0)
                    {
                        lLimiteStatus.Text = @"OK";
                        lLimiteStatus.BackColor = Color.Yellow;
                    }
                    else
                    {
                        lLimiteStatus.Text = @"EXCEDE";
                        lLimiteStatus.BackColor = Color.LightCoral;
                    }
                }
            }

            gescoData = new Gesco().GetHeader(_idCliente.Value);
            ckGescoConciliarCuenta.Value = gescoData.RequestConciliation;
            ckGescoLlamarPago.Value = gescoData.RequestCall;
            txtGescoMensaje.Text = gescoData.MensajeInterno;
            ckPagoListo.Checked = gescoData.PagoConfirmado;
        }



        private void dgvCobranza_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            MessageBox.Show(@"el usuario quiere borrar?");
        }

        private void txtImporteReciboManual_Leave(object sender, EventArgs e)
        {
            txtImporteReciboManual.Text = string.IsNullOrEmpty(txtImporteReciboManual.Text)
                ? 0.ToString("C2")
                : FormatAndConversions.CCurrencyADecimal(txtImporteReciboManual.Text).ToString("C2");
        }

        private void rbL1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbL1.Checked)
            {
                _tipoLx = "L1";
                txtNumeroReciboProvisorioL1.Enabled = true;
                txtNumeroReciboOficialL1.Enabled = true;
                txtNumeroReciboOficialL1.Text = new CobranzaUtils().GetReciboOficialSucursal() + "-" +
                                                new CobranzaUtils().GetNextReciboOficial();
            }
        }


        private void rbL2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbL2.Checked)
            {
                _tipoLx = "L2";
                txtNumeroReciboProvisorioL1.Enabled = false;
                txtNumeroReciboOficialL1.Enabled = false;
                txtNumeroReciboOficialL1.Text = null;
                txtNumeroReciboProvisorioL1.Text = null;
            }
        }




        #region Cobranza Temporal

        private void LoadCobranzaTemporalData()
        {
            var hdata = new CobranzaTemporalManager().GetSpecificHeader(_idCob);

            cmbRazonSocial.SelectedValue = hdata.idCliente;
            if (hdata.LX == "L1")
            {
                rbL1.Checked = true;
            }
            else
            {
                rbL2.Checked = true;
            }

            if (hdata.NumeroReciboProvisorio != null)
            {
                txtNumeroReciboProvisorioL1.Text = hdata.NumeroReciboProvisorio;
            }

            cmbMonedaRecibo.SelectedValue = hdata.Moneda;
            txtImporteReciboManual.Text = hdata.ImporteRecibo.Value.ToString("C2");
            txtImporteReciboIngresado.Text = txtImporteReciboManual.Text;
            txtDiferencia.Text = 0.ToString("C2");
            if (hdata.Cobrador != null)
                cmbCobrador.SelectedValue = hdata.Cobrador;
            dtpFechaCobranza.Value = hdata.FechaIngreso;
            if (hdata.Tc != null)
                txtXRate.Text = hdata.Tc.Value.ToString("N2");
            txtObservaciones.Text = hdata.Observaciones;
            ListOfItemsCobranza = MapItemsCobranzaFromTemporal();
            t0206COBRANZAIBindingSource.DataSource = ListOfItemsCobranza;
            UpdateListWithCalculosImportes();
            CompletaFormateaDataGridView();
            txtIngresoTemporalStatus.Text = hdata.StatusRecibo;
            txtIngresoTemporalUser.Text = hdata.UserIngreso;

            if (hdata.StatusRecibo != CobranzaTemporalManager.StatusCobranzaTemporal.Ingresada.ToString())
            {
                MessageBox.Show(@"Esta cobranza temporal no puede CONTABILIZARSE porque no esta en estado Ingresada",
                    @"Error en Status de Cobranza Temporal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIngresar.Enabled = false;
            }
        }
        private List<T0206_COBRANZA_I> MapItemsCobranzaFromTemporal()
        {
            var ls = new List<T0206_COBRANZA_I>();
            var idata = new CobranzaTemporalManager().GetItemsCobranzaTemporal(_idCob);
            foreach (var i in idata)
            {
                var l0 = new T0206_COBRANZA_I()
                {
                    CUENTA = i.CuentaItem,
                    MON_ITEM = i.MonedaItem,
                    IMP_RECIBO = i.ImporteRecibo,
                    IMP_ITEM = i.ImporteMoneda.Value,
                    TC_ITEM = i.TipoCambio,
                    LINE = i.idItem,
                    CHEQUE_FECHA = i.FechaAcreditacion,
                    CHEQUE_NUMERO = i.NumeroCheque,
                    CHEQUE_BANCO = i.NumeroBanco,
                    CHEQUE_CUIT = i.Cuit,
                    CHEQUE_TITULAR = null,
                    ITEM_TEMP = true,
                    MON_RECIBO = cmbMonedaRecibo.Text,
                    Che_Interior = i.ChequeInterior,
                    Che_Electronico = i.isEcheque
                };
                ls.Add(l0);
            }

            return ls;
        }

        #endregion

        private void dgvCobranza_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvCobranza[e.ColumnIndex, e.RowIndex].Value.ToString();
                //int numeroFormula = Convert.ToInt32(dgvFormulaList[dgvFormulaList.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "DEL":
                        {
                            var iditem = Convert.ToInt32(dgvCobranza[__linea.Name, e.RowIndex].Value);
                            var x = ListOfItemsCobranza.Find(c => c.LINE == iditem);
                            if (x == null)
                                return;

                            ListOfItemsCobranza.Remove(x);
                            t0206COBRANZAIBindingSource.DataSource = ListOfItemsCobranza.ToList();
                            UpdateListWithCalculosImportes();
                            CompletaFormateaDataGridView();
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        //Validacion de Formatos y Valores validos al SALIR
        private void dgvCobranza_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (e.ColumnIndex == 0)
                return; //es fuera del Dgv

            if (dgv.CurrentCell.ReadOnly)
                return;

            //validacion de importe
            if (e.ColumnIndex == dgv[__importe.Name, e.RowIndex].ColumnIndex)
            {
                var value = e.FormattedValue.ToString();
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    e.Cancel = true;
                    MessageBox.Show(@"El Importe NO puede ser Nulo", @"Error en Importe", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    SetDgvCell(e.RowIndex, __importe.Name, false, (decimal)0);
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
                    ListOfItemsCobranza[e.RowIndex].IMP_ITEM = valueDecimal;
                    if (ListOfItemsCobranza[e.RowIndex].MON_ITEM == "USD")
                    {
                        ListOfItemsCobranza[e.RowIndex].IMP_RECIBO =
                            valueDecimal * ListOfItemsCobranza[e.RowIndex].TC_ITEM.Value;
                    }
                    else
                    {
                        ListOfItemsCobranza[e.RowIndex].IMP_RECIBO = valueDecimal;
                    }
                    UpdateListWithCalculosImportes();
                }
            }
            //validacion de Fecha de Acreditacion
            if (e.ColumnIndex == dgv[__fechaAcred.Name, e.RowIndex].ColumnIndex)
            {
                //validacion de Fecha del Cheque
                var value = e.FormattedValue.ToString();
                if (string.IsNullOrEmpty(value))
                {
                    ListOfItemsCobranza[e.RowIndex].CHEQUE_FECHA = null;
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
                        if (ckValidacionFechaAcreditacion.Checked)
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

                    ListOfItemsCobranza[e.RowIndex].CHEQUE_FECHA = valueDate;
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
        }


        private void ckTitularAfip_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTitularAfip.Checked)
            {

            }
        }



        #region Botones
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnModificaLimiteCredito_Click(object sender, EventArgs e)
        {
            if (_idCliente == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Cliente para visualizar este Detalle", @"Detalle de Cuentas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var f = new FrmMdc05CreditLimitMaintain(_idCliente.Value))
            {
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    RemapCustomerData();
                }
            }
        }
        private void btnGrabarGescoData_Click(object sender, EventArgs e)
        {
            var rsp = MessageBox.Show(@"Confirma la Modificacion de los Datos de Gesco", @"Confirmaicon de Valores GESCO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsp == DialogResult.No)
                return;
            //Request Call
            if (ckGescoLlamarPago.Value == true)
            {
                var st = new Gesco().RequestCallInternal(_idCliente.Value, true);
            }
            if (gescoData.RequestCall == true && ckGescoLlamarPago.Value == false)
            {
                rsp = MessageBox.Show(@"Realmente desea desconfirmar la llamada al Cliente?",
                    @"Deseleccion de Llamada a Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsp == DialogResult.No)
                    return;
                new Gesco().RequestCallInternal(_idCliente.Value, false);
            }

            //Request Conciliar Cuenta
            if (ckGescoConciliarCuenta.Value == true)
            {
                var st = new Gesco().RequestConciliarCuenta(_idCliente.Value, true);
            }
            if (gescoData.RequestConciliation == true && ckGescoConciliarCuenta.Value == false)
            {
                rsp = MessageBox.Show(@"Realmente desea deconfirmar el Pedido de Conciliacion de Cuenta?",
                    @"Deseleccion de Solicitud de Conciliacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsp == DialogResult.No)
                    return;
                new Gesco().RequestConciliarCuenta(_idCliente.Value, false);
            }

            //Mensaje Interno GESCO
            txtGescoMensaje.Text = new CRMMensajeInterno().GetMensajeInterno(_idCliente.Value);
            MessageBox.Show(@"Los Valores se han actualizado Correctamente!", @"Actualizacion GESCO",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            gescoData = new Gesco().GetHeader(_idCliente.Value);
        }
        private void btnVerGesco_Click(object sender, EventArgs e)
        {
            var f = new FrmCRM04GescoCall(_idCliente.Value);
            f.Show();
        }
        private void btnModificarEmail_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void btnComposicionDeDeuda_Click(object sender, EventArgs e)
        {
            if (_idCliente == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Cliente para visualizar este Detalle", @"Detalle de Cuentas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var f = new FrmFI49DetalleDocumentos(_idCliente.Value))
            {
                f.ShowDialog();
            }
        }
        private void btnImputacionCobranza_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show(@"Debe Seleccionar un Cliente!", @"Imputacion de Cobranzas", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var f0 = new FrmImputacionCobranzas(Convert.ToInt32(txtIdCliente.Text));
            f0.ShowDialog();
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmFI49IngresoItemsCobranza(this))
            {
                t0206COBRANZAIBindingSource.DataSource = ListOfItemsCobranza;
                dgvCobranza.DataSource = t0206COBRANZAIBindingSource;

                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ListOfItemsCobranza.Add(f0.Item);
                    UpdateListWithCalculosImportes();
                    CompletaFormateaDataGridView();

                    ////**
                    ////string custNamef0.CustomerName;
                    ////SaveToFile(custName);
                    ////**
                }
            }
        }
        private void btnAdministrarZterm_Click(object sender, EventArgs e)
        {
            if (_idCliente == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Cliente para visualizar este Detalle", @"Detalle de Cuentas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var f = new FrmMdc04ZtermMaintain(_idCliente.Value))
            {
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var cust = new CustomerManager().GetCustomerBillToData(_idCliente.Value);
                    txtZtermL1.Text = cust.ZTERML1;
                    txtZtermL2.Text = cust.ZTERML2;
                }
            }
        }
        private void btnVerRecibo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Esta funcionalidad aun no se encuentra desarrollada", @"Aviso", MessageBoxButtons.OK,
                MessageBoxIcon.Hand);
        }
        private void btnEnviarRecibo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Esta funcionalidad aun no se encuentra desarrollada", @"Aviso", MessageBoxButtons.OK,
                MessageBoxIcon.Hand);
        }
        #endregion
    }
}