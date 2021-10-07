using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.HR;
using TecserEF.Entity;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHr10CargaSyj : Form
    {
        private int _modo;
        private int _idSyj;
        private List<T0551_HHRR_SYJ_Items> _datalist;
        private T0550_HHRR_SYJ_Header _header;
        private bool _headerOK;
        private readonly decimal? _defaultValue = 0;
        string defaultFormattedValue = "0"; //Some default formatted value
        private SyJManagerNew.StatusSyJ _status;

        public FrmHr10CargaSyj()
        {
            _modo = 1;
            _datalist = new List<T0551_HHRR_SYJ_Items>();
            InitializeComponent();
            txtEstado.Text = SyJManagerNew.StatusSyJ.Inicial.ToString();
            txtApagar.Text = 0.ToString("C2");
            txtPendientePago.Text = 0.ToString("C2");
            _status = SyJManagerNew.StatusSyJ.Inicial;
        }
        public FrmHr10CargaSyj(int modo, int idSyj)
        {
            _modo = modo;
            _idSyj = idSyj;
            InitializeComponent();
            _datalist = new SyJManagerNew().GetItems(_idSyj);
            _header = new SyJManagerNew().GetHeader(_idSyj);
            _headerOK = _header != null;
            _status = SyJManagerNew.MapTextToStatus(_header.EstadoRegistro);
            LoadExistingData();
        }

        private void FrmHR10_CargaSYJ_Load(object sender, EventArgs e)
        {
            btnIngresar.Enabled = false;
            btnConta.Enabled = false;
            btnPay.Enabled = false;
            PersonalBs.DataSource = new HrMasterManagement().GetEmployeeListForSyJ(true);
            cmbEmpleado.SelectedIndex = -1;

            if (_modo == 3)
            {
                btnConta.Enabled = false;
                btnAddEmployee.Enabled = false;
                btnIngresar.Enabled = false;
            }
        }

        private void LoadExistingData()
        {
            fechaDoc.Value = _header.Fecha;
            ctlPeriodoPago.Text = _header.PeriodoConta;
            if (_header.LX == "L1")
            {
                rbL1.Checked = true;
            }
            else
            {
                rbL2.Checked = true;
            }

            switch (_header.PeriodoQ)
            {
                case "Q1":
                    rbQ1.Checked = true;
                    break;
                case "Q2":
                    rbQ2.Checked = true;
                    break;
                default:
                    rbNA.Checked = true;
                    break;
            }

            //aca va el concepto

            txtDescripcion.Text = _header.Observacion;
            txtEstado.Text = _status.ToString();
            txtSyjId.Text = _idSyj.ToString();
            txtLogUser.Text = _header.LogUser;
            txtLogDate.Text = _header.LogDate.ToString("g");
            txtNas.Text = _header.NAS.ToString();
            txtApagar.Text = _header.MontoTotal.Value.ToString("C2");
            txtPendientePago.Text = _header.MontoAdeudado.Value.ToString("C2");
            dgvData.DataSource = _datalist;

            if (_status == SyJManagerNew.StatusSyJ.Contabilizado || _status == SyJManagerNew.StatusSyJ.PagoParcial)
                btnPay.Enabled = true;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var id = Convert.ToInt32(datagridview[idItemDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "DEL":
                    var q = MessageBox.Show(@"Confirmar la eliminacion de este registro?", @"Borrado de Registro",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (q == DialogResult.No)
                        return;
                    ElimnaRecord(id);
                    break;
                case "VER":
                    MessageBox.Show(@"Todavia no esta resuelto");
                    //        using (var f0 = new FrmMaterialMasterAKA(primario, _modo, aka))
                    //        {
                    //            DialogResult dr = f0.ShowDialog();
                    //            if (dr == DialogResult.OK)
                    //            {
                    //                //string custName = f0.CustomerName;
                    //                //SaveToFile(custName);
                    //            }
                    //        }
                    break;

                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void ElimnaRecord(int id)
        {
            var index = _datalist.SingleOrDefault(c => c.IdItem == id);
            _datalist.Remove(index);
            ReindexAndSum();
            dgvData.DataSource = _datalist.OrderByDescending(c => c.IdItem).ToList();
        }
        private void ReindexAndSum()
        {
            decimal sumPagar = 0;
            decimal sumPendi = 0;
            int index = 1;
            foreach (var a in _datalist)
            {
                a.IdItem = index;
                sumPagar += a.NetoPagar;
                sumPendi += a.Adeudado;
                index++;
            }
            txtPendientePago.Text = sumPendi.ToString("C2");
            txtApagar.Text = sumPagar.ToString("C2");
            if (sumPagar > 0)
                btnIngresar.Enabled = true;
        }
        /// <summary>
        /// Validacion de datos completos para poder contabilizar
        /// </summary>
        private bool ValidaRegistroOKIngreso()
        {
            if (_headerOK == false)
            {
                MessageBox.Show(@"El Registro no tiene informaicon para poder Ingresar", @"Error en Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!_datalist.Any())
            {
                MessageBox.Show(@"No Hay Items para contabilizar", @"Datos Incompletos o Erroneos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (FormatAndConversions.CCurrencyADecimal(txtApagar.Text) == 0)
            {
                MessageBox.Show(@"No Existe monto a Pagar", @"Monto a Pagar CERO", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private void btnConta_Click(object sender, EventArgs e)
        {
            ContabilizaSyj();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BloqueaDatosHeader()
        {
            fechaDoc.Enabled = false;
            ctlPeriodoPago.Enabled = false;
            grpLx.Enabled = false;
            grLiquidacion.Enabled = false;
            grpConcepto.Enabled = false;
        }
        private bool ConceptoCompleto()
        {
            if (grpConcepto.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked) == null)
                return false;
            return true;

        }
        private SyJConceptos.HrConceptos? MapConcepto()
        {
            var xconcepto = grpConcepto.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (xconcepto == null)
                return null;

            switch (xconcepto.Name)
            {
                case "rbSalario":
                    return SyJConceptos.HrConceptos.Salario;
                case "rbSAC":
                    return SyJConceptos.HrConceptos.SAC;
                case "rbVacaciones":
                    return SyJConceptos.HrConceptos.Vacaciones;
                case "rbFinal":
                    return SyJConceptos.HrConceptos.LiquidacionFinal;
                case "rbAnticipo":
                    return SyJConceptos.HrConceptos.Anticipo;
                case "rbPrestamo":
                    return SyJConceptos.HrConceptos.Prestamo;
                case "rbDevolucion":
                    return SyJConceptos.HrConceptos.Devolucion;
                case "rbViaticos":
                    return SyJConceptos.HrConceptos.Viaticos;
                case "rbComisiones":
                    return SyJConceptos.HrConceptos.Comisiones;
                case "rbHonorario":
                    return SyJConceptos.HrConceptos.Honorarios;
                case "rbDividendo":
                    return SyJConceptos.HrConceptos.DividendosSrl;
                case "rbBonos":
                    return SyJConceptos.HrConceptos.Bonos;
                default:
                    return null;
            }
        }
        private bool ValidaHeader()
        {
            if (fechaDoc.Value == null)
            {
                MessageBox.Show(@"Debe completar la Fecha de Contabilizacion", @"Datos Header Incompletos o Erroneos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ctlPeriodoPago.Periodo == null)
            {
                MessageBox.Show(@"Debe completar el Periodo de Pago/Imputacion", @"Datos Header Incompletos o Erroneos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rbL1.Checked == false && rbL2.Checked == false)
            {
                MessageBox.Show(@"Debe Seleccionar el Tipo de Operacion [L1.L2]",
                    @"Datos Header Incompletos o Erroneos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (rbQ1.Checked == false && rbQ2.Checked == false && rbNA.Checked == false)
            {
                MessageBox.Show(@"Debe completar Periodo de Pago [Q1.Q2.NA]", @"Datos Header Incompletos o Erroneos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!ConceptoCompleto())
            {
                MessageBox.Show(@"Debe Seleccionar un Concepto de Registro", @"Datos Header Incompletos o Erroneos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                var x = MessageBox.Show(
                    @"No Hay una observacion para este registro SYJ - Desea Continuar con una observacion generica?",
                    @"Observacion/Comentario Incompleto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.Yes)
                {

                    txtDescripcion.Text = @"Periodo Pago: " + ctlPeriodoPago.Periodo;
                }
                else
                {
                    return false;
                }
            }

            _headerOK = true;
            BloqueaDatosHeader();
            _header = new T0550_HHRR_SYJ_Header()
            {
                Moneda = "ARS",
                LX = rbL1.Checked ? "L1" : "L2",
                ID = 1,
                Fecha = fechaDoc.Value.Value,
                LogUser = GlobalApp.AppUsername,
                LogDate = DateTime.Now,
                EstadoRegistro = "INICIAL",
                MontoAdeudado = 0,
                MontoTotal = 0,
                NAS = null,
                Observacion = txtDescripcion.Text,
                PeriodoConta = ctlPeriodoPago.Periodo,
                PeriodoQ = rbQ1.Checked ? "Q1" : (rbL2.Checked ? "Q2" : "NA"),
                Concepto = MapConcepto().ToString(),
            };
            return true;
        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe Seleccionar un Empleado", @"Empleado No Seleccionado", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return;
            }
            AgregaEmpleado(cmbEmpleado.SelectedValue.ToString());
        }
        private void AgregaEmpleado(string shortname)
        {
            if (_header == null)
            {
                //Si el Header es Null lo valida primero
                if (!ValidaHeader())
                    return;
            }

            if (ConceptoCompleto() == false)
            {
                MessageBox.Show(@"Debe Seleccionar un Concepto de Pago [SYJ] antes de continuar",
                    @"No se puede agregar Empleado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(shortname))
            {
                MessageBox.Show(@"No hay ningun empleado para agregar al listado", @"No se puede agregar Empleado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_datalist.SingleOrDefault(c => c.Shortname == shortname) != null)
            {
                MessageBox.Show($@"El Empleado {shortname} ya Existe en la Lista", @"No se puede agregar Empleado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var enumConcepto = MapConcepto();
            if (enumConcepto == null)
            {
                MessageBox.Show($@"Ha Ocurrido un Error con el Concepto Seleccionado", @"No se puede agregar Empleado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var conceptoGl = SyJConceptos.ReturnGL(enumConcepto.Value);
            var empleadoGL = HrMasterManagement.EmpleadoGl(shortname);
            var glCompleto = conceptoGl + empleadoGL;

            if (GLAccountManagement.GetGLDescriptionFromT135(glCompleto) == "Cuenta Inexistente")
            {
                MessageBox.Show($@"La cuenta GL {glCompleto} para el Empleado-Concepto no existe", @"No se puede agregar Empleado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal valorBasicoDefault = 0;
            if (enumConcepto == SyJConceptos.HrConceptos.Salario || enumConcepto == SyJConceptos.HrConceptos.Anticipo ||
                enumConcepto == SyJConceptos.HrConceptos.SAC || enumConcepto == SyJConceptos.HrConceptos.Vacaciones)
            {
                var empl = HrMasterManagement.GetBasicData(shortname);
                if (empl.PosicionID != null)
                {
                    var x = HrPosicionesManagement.GetPosicion(empl.PosicionID.Value);
                    valorBasicoDefault = x.TipoLiquidacion == "MENSUAL" ? x.ValorMensual : x.ValorHora;
                }
            }

            //Las Validaciones para agregar un empleado estan completas
            var rec = new T0551_HHRR_SYJ_Items()
            {
                LX = _header.LX,
                IdHead = _idSyj,
                Concepto = glCompleto,
                IdItem = _datalist.Count + 1,
                Adeudado = 0,
                Adicional2 = 0,
                BasicoUnit = valorBasicoDefault,
                Descuentos = 0,
                Descuentos2 = 0,
                Imponible = 0,
                ModoLiquidacion = _header.PeriodoQ,
                Shortname = shortname,
                NetoPagar = 0,
                NoImponible = 0,
                NAS = null,
                Observacion = txtDescripcion.Text,
                LogUserUpdate = null,
                LogDateUpdate = null,
                Cantidad = 0,
                LogDateCreado = DateTime.Now,
                LogUserCreado = GlobalApp.AppUsername
            };
            _datalist.Add(rec);
            ReindexAndSum();
            dgvData.DataSource = _datalist.OrderByDescending(c => c.IdItem).ToList();
        }
        private void rbFinal_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show($@"Se ha Seleccionado para este Ingreso el Concepto {MapConcepto()} .-",
                @"Seleccion de Concepto OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnAutoQ_Click(object sender, EventArgs e)
        {
            var lquincena = HrMasterManagement.GetEmployeeListQuincenal();
            foreach (var empl in lquincena)
            {
                AgregaEmpleado(empl.Shortname);
            }
        }
        private void btnAutoM_Click(object sender, EventArgs e)
        {
            var lmes = HrMasterManagement.GetEmployeeListMensual();
            foreach (var empl in lmes)
            {
                AgregaEmpleado(empl.Shortname);
            }
        }
        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;  //Header
            var dgv = (DataGridView)sender;
            var imponible = (decimal)dgv[__imponible.Name, e.RowIndex].Value;
            var noimpo = (decimal)dgv[__noimponible.Name, e.RowIndex].Value;
            var desc = (decimal)dgv[__descuento.Name, e.RowIndex].Value;
            var desc2 = (decimal)dgv[__descuento2.Name, e.RowIndex].Value;
            var adic = (decimal)dgv[__adicional.Name, e.RowIndex].Value;
            var valor = imponible + noimpo - desc - desc2 + adic;
            dgv[__netoPagar.Name, e.RowIndex].Value = valor;
            dgv[__adeudado.Name, e.RowIndex].Value = valor;
            ReindexAndSum();
        }
        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            e.Control.KeyPress -= new KeyPressEventHandler(CeldaCheck_KeyPress);

            if (dgv.CurrentCell.ColumnIndex == (decimal)dgv.Columns[__basico.Name].Index)
            {
                //Desired Column
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(CeldaCheck_KeyPress);
                }
            }

            if (dgv.CurrentCell.ColumnIndex == (decimal)dgv.Columns[__imponible.Name].Index)
            {
                //Desired Column
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(CeldaCheck_KeyPress);
                }
            }

            if (dgv.CurrentCell.ColumnIndex == (decimal)dgv.Columns[__noimponible.Name].Index)
            {
                //Desired Column
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(CeldaCheck_KeyPress);
                }
            }

            if (dgv.CurrentCell.ColumnIndex == (decimal)dgv.Columns[__descuento2.Name].Index)
            {
                //Desired Column
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(CeldaCheck_KeyPress);
                }
            }


            if (dgv.CurrentCell.ColumnIndex == (decimal)dgv.Columns[__descuento.Name].Index)
            {
                //Desired Column
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(CeldaCheck_KeyPress);
                }
            }


            if (dgv.CurrentCell.ColumnIndex == (decimal)dgv.Columns[__adicional.Name].Index)
            {
                //Desired Column
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(CeldaCheck_KeyPress);
                }
            }

            if (dgv.CurrentCell.ColumnIndex == (decimal)dgv.Columns[__Cantidad.Name].Index)
            {
                //Desired Column
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(CeldaCheck_KeyPress);
                }
            }
        }
        private void CeldaCheck_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, true, allowSignoMoneda: true);
        }
        private void dgvData_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            var value = $"{e.Value}";
            if (string.IsNullOrEmpty(value) || value == "\"\"")
                e.Value = _defaultValue;
            e.ParsingApplied = true;
        }
        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is int? && (int?)e.Value == _defaultValue)
                e.Value = defaultFormattedValue;
        }
        private void rbQ1_CheckedChanged(object sender, EventArgs e)
        {
            btnAutoM.Enabled = false;
            btnAutoQ.Enabled = false;

            if (rbQ1.Checked)
                btnAutoQ.Enabled = true;

            if (rbQ2.Checked)
            {
                btnAutoQ.Enabled = true;
                btnAutoM.Enabled = true;
            }

            if (rbNA.Enabled)
            {
                //no habilita ninguno
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!ValidaRegistroOKIngreso())
                return;

            var m = MessageBox.Show(@"Confirma el Ingreso del Registro SYJ", @"Confirmacion de Ingreso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (m == DialogResult.No)
                return;

            var idH = new SyJManagerNew().CreaHeader(_header.Fecha, _header.PeriodoConta, _header.PeriodoQ, _header.Concepto,
                txtDescripcion.Text, _header.LX, FormatAndConversions.CCurrencyADecimal(txtApagar.Text));
            txtSyjId.Text = idH.ToString();
            _idSyj = idH;

            var it = new SyJManagerNew().AddItemList(idH, _datalist);

            MessageBox.Show($@"Se han Ingresado Correctamente {it} Registros!", @"Ingreso de Registros de Pago",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtEstado.Text = SyJManagerNew.StatusSyJ.Registrado.ToString();

            btnConta.Enabled = true;
            btnIngresar.Enabled = false;

        }
        private void ContabilizaSyj()
        {
            if (MessageBox.Show(@"Confirma la Contabilizacion del Documento?", @"Confirmacion de Contabiliacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var X = new AsientoSyJ(_idSyj, "SYJ1").GeneraAsientoRegistroSyJ();
            txtNas.Text = X.IdDocu.ToString();
            if (X.IdDocu > 0)
            {
                MessageBox.Show(@"Se ha Contabilizado Correctamente el Documento", @"Operecion Completada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                new SyJManagerNew().UpdateStatusContabilizadoOk(_idSyj, X.IdDocu);
                _status = SyJManagerNew.StatusSyJ.Contabilizado;
                txtEstado.Text = _status.ToString();
                btnConta.Enabled = false;
                btnPay.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"No se ha podido Contabilizar!", @"Error en Creacion de Asiento", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            var f = new FrmHr12PagoSyJ(_idSyj);
            f.Show();
            this.Dispose();
        }
    }

}
