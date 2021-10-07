using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.HR;
using TecserEF.Entity;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHr12PagoSyJ : Form
    {
        private readonly int _idSyJ;
        private SyJManagerNew.StatusSyJ _status;
        private readonly List<T0551_HHRR_SYJ_Items> _lst1;
        private readonly List<T0552_HHRR_SYJ_Payments> _lst2 = new List<T0552_HHRR_SYJ_Payments>();
        private decimal _importeAPagar = 0;
        private string _lx;

        public FrmHr12PagoSyJ(int idSyJ)
        {
            _idSyJ = idSyJ;
            InitializeComponent();
            _lst1 = new SyJManagerNew().GetItems(_idSyJ);
        }

        private void FrmHr12PagoSyJ_Load(object sender, EventArgs e)
        {
            t0150CUENTASBindingSource.DataSource = CuentasManager.GetCuentasDisponibleSyJ();
            t0160BANCOSBindingSource.DataSource = new BankManager().GetBankList();
            cmbBancoEmpleado.SelectedIndex = -1;
            cmbCuentaPago.SelectedIndex = -1;
            CargaSyJHeader();
        }
        private void CargaSyJHeader()
        {
            var h = new SyJManagerNew().GetHeader(_idSyJ);
            if (h == null)
            {
                MessageBox.Show(@"No se encuentra el Header", @"Ha Ocurrido un error grave de datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtIdSyJ.Text = _idSyJ.ToString();
            txtConcepto.Text = h.Concepto;
            txtEstado.Text = h.EstadoRegistro;
            _status = SyJManagerNew.MapTextToStatus(h.EstadoRegistro);
            txtFechaIngreso.Text = h.Fecha.ToString("g");
            txtPrediodoPago.Text = h.PeriodoConta;
            txtObservacion.Text = h.Observacion;
            _lx = h.LX;
            if (h.LX == "L1")
            {
                rbL1.Checked = true;
            }
            else
            {
                rbL2.Checked = true;
            }

            if (h.PeriodoQ == "Q1")
            {
                rbQ1.Checked = true;
            }
            else
            {
                if (h.PeriodoQ == "Q2")
                {
                    rbQ2.Checked = true;
                }
                else
                {
                    rbNA.Checked = true;
                }
            }
            txtImpagoHeader.Text = h.MontoAdeudado.Value.ToString("C2");
            txtTotalAPagar.Text = 0.ToString("C2");
            dgvL1.DataSource = _lst1.ToList();
            dgvL2.DataSource = _lst2.ToList();
        }
        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                txtRegistroItemSyj.Text = "";
                txtEmpleado.Text = "";
                txtAdeudado.Text = "";
                btnAddPago.Enabled = false;
                cmbCuentaPago.SelectedIndex = -1;
                ctlImportePagar.Enabled = false;
                ctlImportePagar.SetValue = 0;
                return;
            }
            txtRegistroItemSyj.Text = dgv[__itemSyj.Name, e.RowIndex].Value.ToString();
            txtEmpleado.Text = dgv[__empleado.Name, e.RowIndex].Value.ToString();
            string adeudado = dgv[__adeudado.Name, e.RowIndex].Value.ToString();
            txtAdeudado.Text = adeudado.ToString();
            ctlImportePagar.ValorMinimo = 0;
            ctlImportePagar.ValorMaximo = Convert.ToDecimal(dgv[__adeudado.Name, e.RowIndex].Value);
            ctlImportePagar.SetValue = FormatAndConversions.CCurrencyADecimal(txtAdeudado.Text);
            if (ctlImportePagar.GetValueDecimal == 0)
            {
                btnAddPago.Enabled = false;
            }
            else
            {
                btnAddPago.Enabled = true;
            }

            var datosBanco = HrMasterManagement.GetDatosPersonales(txtEmpleado.Text);
            var bankShortname = datosBanco?.Banco;
            if (bankShortname != null)
            {
                var x = new BankManager().GetBankDatabyShortname(bankShortname);
                cmbBancoEmpleado.SelectedValue = x.ID_BANCO;
            }

        }
        private void dgvDataAPagar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void cmbCuentaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuentaPago.SelectedIndex == -1)
            {
                txtGlPago.Text = null;
                cmbBancoEmpleado.SelectedIndex = -1;
                return;
            }
            else
            {
                var f = (T0150_CUENTAS)cmbCuentaPago.SelectedItem;
                txtGlPago.Text = f.GLMAP;
            }

            if (cmbCuentaPago.SelectedValue.ToString() == "ARS")
            {
                cmbBancoEmpleado.SelectedIndex = -1;
                txtBancoEmpleado.Text = @"EFE";
                cmbBancoEmpleado.Enabled = false;

            }
            else
            {
                cmbBancoEmpleado.Enabled = true;
                //banco default
                var datosBanco = HrMasterManagement.GetDatosPersonales(txtEmpleado.Text);
                var bankShortname = datosBanco?.Banco;
                if (bankShortname != null)
                {
                    cmbBancoEmpleado.SelectedValue = bankShortname;
                }
            }
        }
        private void RecalculaYSum()
        {
            int a = 1;
            foreach (var d in _lst2)
            {
                d.IDPayment = a;
                _importeAPagar += d.Importe;
                a++;
            }
            dgvL2.DataSource = _lst2.ToList();
            txtTotalAPagar.Text = _importeAPagar.ToString("C2");
        }
        private void dgvListaPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();

            int idI = Convert.ToInt32(datagridview[__idPayment.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "DEL":
                    var x = MessageBox.Show(@"Desea Eliminar este registro?", @"Eliminar Registro",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (x == DialogResult.No)
                        return;
                    var f = _lst2.Find(c => c.IDPayment == idI);
                    _lst2.Remove(f);
                    RecalculaYSum();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
        private void cmbBancoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBancoEmpleado.SelectedIndex == -1)
            {
                txtBancoEmpleado.Text = null;
            }
            else
            {
                txtBancoEmpleado.Text = cmbBancoEmpleado.SelectedValue.ToString();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidaRecordsOkContabilizar()
        {
            if (_importeAPagar <= 0)
            {
                MessageBox.Show(@"No Existe importe a Pagar", @"Sin Registros", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (_lst2.Count == 0)
            {
                MessageBox.Show(@"La Lista de Pagos esta vacia", @"Sin Registros", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }


            if (MessageBox.Show($@"Confirma el Pago de {_importeAPagar:C2} ?",
                    @"Confirmacion de Contabilizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.No)
            {
                return false;
            }

            return true;
        }
        private void btnAddPago_Click(object sender, EventArgs e)
        {
            int idRegistro;
            if (string.IsNullOrEmpty(txtRegistroItemSyj.Text))
            {
                MessageBox.Show(@"No se ha Seleccionado ningun registro", @"Registro Incompleto", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
            {
                idRegistro = Convert.ToInt32(txtRegistroItemSyj.Text);
            }

            if (cmbCuentaPago.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe seleccionar una cuenta de pago", @"Registro Incompleto", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (ctlImportePagar.GetValueDecimal == 0)
            {
                MessageBox.Show(@"Debe completar un Importe", @"Registro Incompleto", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (fechaDoc.Value == null)
            {
                MessageBox.Show(@"Debe Proveer una Fecha de Pago", @"Registro Incompleto", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtBancoEmpleado.Text))
            {
                MessageBox.Show(@"Debe Proveer una Banco Empleado o Forma de Pago", @"Registro Incompleto", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            int idx = _lst2.Count + 1;
            var t = new T0552_HHRR_SYJ_Payments()
            {
                Moneda = txtMoneda.Text,
                Shortname = txtEmpleado.Text,
                FechaPago = fechaDoc.Value.Value,
                Importe = ctlImportePagar.GetValueDecimal,
                NAS = 0,
                Observacion = txtObservacionPago.Text,
                LogUser = GlobalApp.AppUsername,
                LogDate = DateTime.Now,
                IDPayment = idx,
                IDItem = Convert.ToInt32(txtRegistroItemSyj.Text),
                GLAccount = txtGlPago.Text,
                GLDescripcion = cmbCuentaPago.SelectedValue.ToString(),
                DestinoPago = txtBancoEmpleado.Text
            };

            _lst2.Add(t);
            RecalculaYSum();
            var r = _lst1.Find(c => c.IdItem == idRegistro);
            var z = new T0551_HHRR_SYJ_Items()
            {
                Shortname = r.Shortname,
                IdItem = r.IdItem,
                IdHead = r.IdHead,
                Cantidad = r.Cantidad,
                LX = r.LX,
                NetoPagar = r.NetoPagar,
                Adeudado = r.Adeudado - ctlImportePagar.GetValueDecimal,
                Observacion = r.Observacion
            };
            _lst1.Remove(r);
            _lst1.Add(z);
            dgvL1.DataSource = _lst1.ToList();
            ctlImportePagar.SetValue = 0;
        }
        private void BtnConta_Click(object sender, EventArgs e)
        {
            if (ValidaRecordsOkContabilizar() == false)
                return;


            var idPaymentInicial = new SyJAdministracionPagos().IngresaPago(_lst2);
            if (idPaymentInicial == 0)
            {
                MessageBox.Show(@"Ha ocurrido un error al guardar los datos de pago en la aplicacion",
                    @"Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var i in _lst2)
            {
                i.IDPayment = idPaymentInicial;
                idPaymentInicial++;
            }

            var rAsiento = new AsientoSyJ(_idSyJ, "SYJp").GeneraAsientoPago(_lst2);
            if (rAsiento.IdDocu > 0)
            {
                //register
                foreach (var i in _lst2)
                {
                    new RegisterManager().AddRegisterRecord(i.GLDescripcion, fechaDoc.Value.Value, "PE",
                        _idSyJ + "@" + i.IDItem, TipoEntidad.Empleado,
                        HrMasterManagement.EmpleadoGl(i.Shortname) != null
                            ? HrMasterManagement.EmpleadoGl(i.Shortname).Value
                            : -1, $"Pago Empleado SYJ {_idSyJ}", "ARS", 0, i.Importe,
                        i.IdCheque == null ? 0 : i.IdCheque.Value, _lx, i.GLAccount, rAsiento.IdDocu, "SYJP");
                }

                decimal adeudadoAhora = 0;

                foreach (var i in _lst1)
                {
                    new SyJAdministracionPagos().UpdateSaldoPagoItems(_idSyJ, i.IdItem, i.Adeudado);
                    adeudadoAhora += i.Adeudado;
                }

                if (FormatAndConversions.CCurrencyADecimal(txtImpagoHeader.Text) > adeudadoAhora)
                {
                    _status = SyJManagerNew.StatusSyJ.PagoParcial;
                }
                else
                {
                    _status = SyJManagerNew.StatusSyJ.PagoTotal;
                }
                new SyJAdministracionPagos().UpdateStatusPago(_idSyJ, _status, adeudadoAhora);
                txtEstado.Text = _status.ToString();
                MessageBox.Show(@"Se ha Contabilizado correctamente el Pago", @"Operacion Completada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNasPago.Text = rAsiento.IdDocu.ToString();


            }
            else
            {
                //ocurrio un error en el asiento se reversa la lista de pagos
                txtNasPago.Text = null;
                foreach (var i in _lst2)
                {
                    new SyJAdministracionPagos().DeleteRecord(i.IDPayment);
                }
                MessageBox.Show(@"Ha ocurrido un error al contabilizar el registro", @"Error en Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
