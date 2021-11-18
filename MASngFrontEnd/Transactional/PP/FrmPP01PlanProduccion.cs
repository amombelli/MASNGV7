using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using MASngFE.Transactional.CRM;
using MASngFE.Transactional.MM;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CRM;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using Tecser.Business.Transactional.PP.MRP;
using TecserEF.Entity;
using TradeGrid;

namespace MASngFE.Transactional.PP
{
    /// <summary>
    /// DATAgridview poner icono para aprobado/no aprobado
    /// Hacer impresion batch
    /// poner flag impreso  - no impreso
    /// </summary>
    public partial class FrmPP01PlanProduccion : Form
    {
        public FrmPP01PlanProduccion()
        {
            InitializeComponent();
            _ckStatus = new bool[9] { false, false, false, false, false, false, false, false, false };
        }
        public FrmPP01PlanProduccion(int modo = 0)
        {
            InitializeComponent();
            this.dgvPF.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellValueChanged);
            _ckStatus = new bool[9] { false, false, false, false, false, false, false, false, false };
        }

        //-------------------------------------------------------------------------------------------------
        private bool[] _ckStatus;
        private List<T0070_PLANPRODUCCION> _data;
        private bool _evento1 = false;
        private int? _numeroOfSeleccion;
        private PlanProduccionStatusManager.StatusOf _statusOfSeleccion;
        private bool _permiteModificarKg = false;
        private bool _permiteAutorizar = false;
        private bool _ofAutorizada = false;

        //-------------------------------------------------------------------------------------------------

        private void MapStatus(bool pendiente, bool formulado, bool planeado, bool proceso, bool cerrado, bool cancelado,
            bool standby, bool error, bool finalizado)
        {
            _ckStatus = new bool[9]
            {
                pendiente, formulado, planeado, proceso, cerrado, cancelado, standby, error, finalizado
            };
        }
        private void FrmPlanProduccion_Load(object sender, EventArgs e)
        {
            //Perfil Planner
            //this.dgvPF.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellEnter);
            ckPendiente.Checked = true;
            ckFormulado.Checked = true;
            ckPlaneado.Checked = true;
            ckProceso.Checked = true;
            ckStandBy.Checked = true;
            dtp1.Checked = false;
            rbKg.Checked = true;
            MapStatus(ckPendiente.Checked, ckFormulado.Checked, ckPlaneado.Checked, ckProceso.Checked, ckCerrado.Checked,
                ckCancelado.Checked, ckStandBy.Checked, ckError.Checked, ckFinalizado.Checked);
            AplicaFiltros();
            _permiteModificarKg = TsSecurityMng.CheckToEnableButton("PPCAMBIAKG");
            _permiteAutorizar = TsSecurityMng.CheckToEnableButton("PPAPRUEBA");
        }

        //Manejo de Click en Botones Dgv
        private void dgvPF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var botonX = dgvPF[e.ColumnIndex, e.RowIndex].Value.ToString();

                switch (botonX)
                {
                    case "ES":
                        _numeroOfSeleccion = Convert.ToInt32(dgvPF[__idplan.Name, e.RowIndex].Value);
                        var f = new FrmPP10CierreOF(_numeroOfSeleccion.Value);
                        f.Show();
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
        //Manejo de Doble-Click en celdas DGV
        //Material => Stock y MRP Data
        //Status => Detalle OF
        private void dgvPF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                this.dgvPF.Sort(this.dgvPF.Columns[__status.Name], ListSortDirection.Ascending);
                return;
            }
            var cell = dgvPF.Columns[e.ColumnIndex].Name;

            if (e.RowIndex >= 0)
            {
                var statOF = PlanProduccionStatusManager.MapStatusOfFromText2(dgvPF[__status.Name, e.RowIndex].Value.ToString());
                _numeroOfSeleccion = Convert.ToInt32(dgvPF[__idplan.Name, e.RowIndex].Value);
                string material = dgvPF[__material.Name, e.RowIndex].Value.ToString();
                switch (cell)
                {
                    case nameof(__material):
                        var stk = new StockAvilability();
                        // Set cursor as hourglass
                        Cursor.Current = Cursors.WaitCursor;
                        double stockTotal = stk.TotalStockInPlant(material);
                        double stockDisponible = stk.AvailableStockForDespacho(material);
                        CalculaMRPData(true);
                        if (stockTotal > 0)
                        {
                            txtStockTotal.ForeColor = Color.DarkBlue;
                            txtStockTotal.BackColor = Color.Pink;
                        }
                        else
                        {
                            txtStockTotal.ForeColor = Color.Black;
                            txtStockTotal.BackColor = Color.LightGray;
                        }

                        if (stockDisponible > 0)
                        {
                            txtStockDisponible.ForeColor = Color.DarkBlue;
                            txtStockDisponible.BackColor = Color.Pink;
                        }
                        else
                        {
                            txtStockDisponible.ForeColor = Color.Black;
                            txtStockDisponible.BackColor = Color.LightGray;
                        }

                        //Asignacion de Valores
                        txtStockTotal.Text = stockTotal.ToString("N2");
                        txtStockDisponible.Text = stockDisponible.ToString("N2");
                        Cursor.Current = Cursors.Default;
                        break;

                    case nameof(__status):
                        AccionDetalleOF();
                        break;
                    case nameof(__kgFabricar):
                        if (statOF == PlanProduccionStatusManager.StatusOf.Pendiente ||
                            statOF == PlanProduccionStatusManager.StatusOf.StandBy)
                        {
                            if (TsSecurityMng.CheckToEnableButton("PPCAMBIAKG"))
                            {
                                using (var form1 = new FrmPP18UpdateKgFabricar(_numeroOfSeleccion.Value))
                                {
                                    var resx = form1.ShowDialog();
                                    if (resx == DialogResult.OK)
                                    {
                                        AplicaFiltros();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show(
                                    @"El Usuario no cuenta con los permisos suficientes para modificar los KG a Fabricar",
                                    @"Permisos Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                @"Para utilizar esta funcion la orden de fabricacion debe estar en estado Pendiente o StandBy",
                                @"No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    default:
                        MessageBox.Show(
                            @"Esta Celda no realiza ninguna funcion al hacer doble click. Para planear haga doble click en STATUS",
                            @"Boton no programado aun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void AccionDetalleOF()
        {
            using (var f2 = new FrmPP02PlanificacionOF(_numeroOfSeleccion.Value, rckAutoFormulacion.Checked))
            {
                f2.ShowDialog();
            }
            AplicaFiltros();
        }

        //Modificacion de observaciones!
        //Al hacer click en DGV - Si columna es Observaciones - Acitva el evento cellvalue change
        private void dgvPF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPF.SelectedRows.Count != 1)
                return;
            if (e.ColumnIndex < 0)
                return;

            var cell = dgvPF.Columns[e.ColumnIndex].Name;
            switch (cell)
            {
                case nameof(__observaciones):
                    if (_evento1 == false)
                    {
                        this.dgvPF.CellValueChanged +=
                            new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellValueChanged);
                        _evento1 = true;
                    }
                    break;
                default:
                    if (_evento1)
                    {
                        this.dgvPF.CellValueChanged -=
                            new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellValueChanged);
                        _evento1 = false;
                    }
                    break;
            }
        }
        //Al Modificar Observacion en Dgv
        private void dgvPF_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            //estamos en columna observaciones
            if (dgv.Columns[__observaciones.Name].Index == e.ColumnIndex)
            {
                string observaciones = null;
                var obs = dgv[__observaciones.Name, e.RowIndex].Value;
                if (obs != null)
                {
                    observaciones = obs.ToString();
                }
                int idOF = Convert.ToInt32(dgv[__idplan.Name, e.RowIndex].Value);
                new PlanProduccionManager().UpdateComentarioPF(idOF, observaciones);
                this.dgvPF.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellValueChanged);
                _evento1 = false;
            }


            //    if (dgvPF[dgvPF.Columns["obsPlanDataGridViewTextBoxColumn"].Index, e.RowIndex].Value == null)
            //    {
            //        observaciones = null;
            //    }
            //    else
            //    {
            //        observaciones = dgvPF[dgvPF.Columns["obsPlanDataGridViewTextBoxColumn"].Index, e.RowIndex].Value
            //            .ToString();
            //    }





            //    return;
            //}

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            //    e.RowIndex >= 0)
            //{
            //    var cellValue = dgvPF[e.ColumnIndex, e.RowIndex].Value.ToString();

            //    switch (cellValue)
            //    {
            //        case "ES":
            //            var f = new FrmPP10CierreOF(Convert.ToInt32(dgvPF[0, e.RowIndex].Value));
            //            f.Show();
            //            break;
            //        default:
            //            MessageBox.Show(@"Boton no manejado aun");
            //            break;
            //    }
            //}



            //var d = 


            //if (dgvPF[])

            //string observaciones = null;
            //if (dgvPF[dgvPF.Columns["obsPlanDataGridViewTextBoxColumn"].Index, e.RowIndex].Value == null)
            //{
            //    observaciones = null;
            //}
            //else
            //{
            //    observaciones = dgvPF[dgvPF.Columns["obsPlanDataGridViewTextBoxColumn"].Index, e.RowIndex].Value
            //        .ToString();
            //}

            //new PlanProduccionManager().UpdateComentarioPF(Convert.ToInt32(dgvPF[0, e.RowIndex].Value), observaciones);
            //this.dgvPF.CellValueChanged -=
            //    new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellValueChanged);
        }
        private void CopyAlltoClipboard()
        {
            dgvPF.SelectAll();
            DataObject dataObj = dgvPF.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        #region Filtros

        //FILTROS
        private void AplicaConteo()
        {
            decimal pendiente = 0;
            decimal proceso = 0;
            decimal planeado = 0;
            decimal formulado = 0;
            decimal error = 0;
            decimal standby = 0;
            decimal cancelado = 0;
            decimal finalizado = 0;
            if (_data == null) return;
            foreach (var i in _data.ToList())
            {
                if (rbKg.Checked)
                {
                    switch (i.STATUS.ToUpper())
                    {
                        case "PENDIENTE":
                            pendiente += i.KG_FABRICAR;
                            break;
                        case "PROCESO":
                            proceso += i.KG_Fabricados;
                            break;
                        case "PLANEADO":
                            planeado += i.KG_FABRICAR;
                            break;
                        case "FORMULADO":
                            formulado += i.KG_FABRICAR;
                            break;
                        case "ERROR":
                            error += i.KG_FABRICAR;
                            break;
                        case "STANDBY":
                            standby += i.KG_FABRICAR;
                            break;
                        case "CANCELADO":
                            cancelado += i.KG_FABRICAR;
                            break;
                        case "FINALIZADO":
                            finalizado += i.KG_Fabricados;
                            break;
                    }
                }
                else
                {
                    switch (i.STATUS.ToUpper())
                    {
                        case "PENDIENTE":
                            pendiente++;
                            break;
                        case "PROCESO":
                            proceso++;
                            break;
                        case "PLANEADO":
                            planeado++;
                            break;
                        case "FORMULADO":
                            formulado++;
                            break;
                        case "ERROR":
                            error++;
                            break;
                        case "STANDBY":
                            standby++;
                            break;
                        case "CANCELADO":
                            cancelado++;
                            break;
                        case "FINALIZADO":
                            finalizado++;
                            break;
                    }
                }
            }
            r1pendiente.TextBoxText = pendiente.ToString();
            r1proceso.TextBoxText = proceso.ToString();
            r1planeado.TextBoxText = planeado.ToString();
            r1formulado.TextBoxText = formulado.ToString();
            r1error.TextBoxText = error.ToString();
            r1standby.TextBoxText = standby.ToString();
            r1cancelado.TextBoxText = cancelado.ToString();
            r1finalizado.TextBoxText = finalizado.ToString();
        }
        private void AplicaFiltros()
        {
            //this.dgvPF.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellEnter);
            var material = txtFiltroMaterial.Text;
            var numeroOF = string.IsNullOrEmpty(txtFiltroOF.Text) ? 0 : Convert.ToInt32(txtFiltroOF.Text);
            var idRecurso = string.IsNullOrEmpty(txtFiltroRecursoProd.Text) ? -1 : Convert.ToInt32(txtFiltroRecursoProd.Text);
            var maxRecords = string.IsNullOrEmpty(rtxtMaxRecords.TextBoxText) ? 0 : Convert.ToInt32(rtxtMaxRecords.TextBoxText);
            DateTime? fechaplan = null;
            if (dtp1.Checked != false)
            {
                fechaplan = dtp1.Value;
            }
            _data = new PlanProduccionListManager().GetListPFPorEstado2(_ckStatus, material, numeroOF, maxRecords, idRecurso, fechaplan);
            dgvPF.DataSource = new MySortableBindingList<T0070_PLANPRODUCCION>(_data);
            txtStockTotal.Text = 0.ToString("N2");
            txtStockDisponible.Text = 0.ToString("N2");
            txtMrpPendienteEntrega.Text = null;
            AplicaConteo();
            AplifcaFormatoIconoDgv();
            //this.dgvPF.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPF_CellEnter);

        }
        private void DesactivaBotonesAccionOF()
        {
            //rbtnVerTodo.Enabled = true;
            //rbtnVerNada.Enabled = true;
            //rbtnPlannerProfile.Enabled = true;
            //rbtnAlterProfile.Enabled=true;
            //rbtnNuevaOF.Enabled = true;
            //rbtnExportExcel.Enabled = true;

            rbtnAutorizarOF.Enabled = false;
            rbtNoAutorizarOF.Enabled = false;
            rbtModifcarKgOF.Enabled = false;
            rbtnFormular.Enabled = false;
            rbtnPlanificar.Enabled = false;
            rbCancelarOF.Enabled = false;
            rbtnIngresarTemporal.Enabled = false;
            rbtnCerrarOF.Enabled = false;
            rbVerIngresoRealizado.Enabled = false;
            rbtnImprimir.Enabled = false;
            //
            txtMaterialSeleccionado.Text = null;
            txtOFSeleccionada.Text = null;
            txtClienteSeleccionado.Text = null;
            txtKgFabricarSeleccionado.Text = null;
            txtOvSeleccionado.Text = null;
            _numeroOfSeleccion = null;
            _statusOfSeleccion = PlanProduccionStatusManager.StatusOf.Error;
            _ofAutorizada = false;
        }
        private void ckPendiente_CheckedChanged(object sender, EventArgs e)
        {
            _ckStatus = new bool[9]
            {
                ckPendiente.Checked, ckFormulado.Checked, ckPlaneado.Checked, ckProceso.Checked, ckCerrado.Checked,
                ckCancelado.Checked, ckStandBy.Checked, ckError.Checked,ckFinalizado.Checked
            };
            AplicaFiltros();
        }


        //--- BOTONES de Filtro

        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!dtp1.Checked)
            {
                MessageBox.Show(@"El Filtrado por Fecha se encuentra deshabilitado", @"Atencion", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            AplicaFiltros();
        }
        private void rbKg_CheckedChanged(object sender, EventArgs e)
        {
            AplicaConteo();
        }
        private void rbtnNuevaOF_Click(object sender, EventArgs e)
        {
            using (var form = new FrmPP03AltaOFManual())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    AplicaFiltros();
                }
            }
        }
        private void rbtnVerTodo_Click(object sender, EventArgs e)
        {
            ckPendiente.Checked = true;
            ckFormulado.Checked = true;
            ckPlaneado.Checked = true;
            ckProceso.Checked = true;
            ckCerrado.Checked = true;
            ckCancelado.Checked = true;
            ckStandBy.Checked = true;
            ckError.Checked = true;
            ckFinalizado.Checked = true;
            _ckStatus = new bool[9]
            {
                true,true,true,true,true,true,true,true,true
            };
            AplicaFiltros();
        }
        private void rbtnVerNada_Click(object sender, EventArgs e)
        {
            ckPendiente.Checked = false;
            ckFormulado.Checked = false;
            ckPlaneado.Checked = false;
            ckProceso.Checked = false;
            ckCerrado.Checked = false;
            ckCancelado.Checked = false;
            ckStandBy.Checked = false;
            ckError.Checked = false;
            ckFinalizado.Checked = false;

            _ckStatus = new bool[9]
            {
                false, false, false, false, false, false, false, false, false
            };
            AplicaFiltros();
        }
        private void rbtnPlannerProfile_Click(object sender, EventArgs e)
        {
            ckCerrado.Checked = false;
            ckCancelado.Checked = false;
            ckError.Checked = false;
            ckFinalizado.Checked = false;
            ckPendiente.Checked = true;
            ckFormulado.Checked = true;
            ckPlaneado.Checked = true;
            ckProceso.Checked = true;
            ckStandBy.Checked = true;

            _ckStatus = new bool[9]
            {
                ckPendiente.Checked, ckFormulado.Checked, ckPlaneado.Checked, ckProceso.Checked, ckCerrado.Checked,
                ckCancelado.Checked, ckStandBy.Checked, ckError.Checked,ckFinalizado.Checked
            };
            AplicaFiltros();
        }
        private void rtxtMaxRecords_TextBoxValidating(object sender, EventArgs e)
        {
            var isNumeric = int.TryParse(rtxtMaxRecords.TextBoxText, out int n);
            if (!isNumeric)
            {
                MessageBox.Show(@"Debe ingresar un numero Maximo de Registros a Visualizar", @"Informacion No Numerica",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtxtMaxRecords.TextBoxText = "200";
            }
        }
        private void rtxtMaxRecords_TextBoxValidated(object sender, EventArgs e)
        {
            AplicaFiltros();
        }
        private void rbtnExportExcel_Click(object sender, EventArgs e)
        {
            CopyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range cr = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            cr.Select();
            xlWorkSheet.PasteSpecial(cr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

        }
        private void rbtnIngresarTemporal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOFSeleccionada.Text))
            {
                MessageBox.Show(@"Debe seleccionanr una OF de la grilla para realizar esta acción",
                    @"Accion no Permitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var x = Convert.ToInt32(txtOFSeleccionada.Text);
            var f = new FrmPP09IngresoTemporal(x);
            f.Show();
        }
        private void rbtnCerrarOF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOFSeleccionada.Text))
            {
                MessageBox.Show(@"Seleccione una OF# y luego presione el botón Cerrar OF", @"OF# No Seleccionada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var f = new FrmPP10CierreOF(Convert.ToInt32(txtOFSeleccionada.Text));
            f.Show();
        }
        private void rbtnImprimir_Click(object sender, EventArgs e)
        {
            if (rckImprimirSoloDescripcionMp.Checked)
            {
                MessageBox.Show(@"Esta opcion aun no esta disponible. Pruebe en la proxima version");
                return;
            }

            if (string.IsNullOrEmpty(txtOFSeleccionada.Text))
            {
                MessageBox.Show(@"Seleccione una OF# y luego presione el botón imprimir", @"OF# No Seleccionada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var f2 = new RpvImprimirOFNew(Convert.ToInt32(txtOFSeleccionada.Text));
            f2.Show();
        }
        private void rbtnPlanificar_Click(object sender, EventArgs e)
        {
            using (var f2 = new FrmPP02PlanificacionOF(_numeroOfSeleccion.Value, rckAutoFormulacion.Checked))
            {
                f2.ShowDialog();
            }
            AplicaFiltros();
        }
        private void rbtnAlterProfile_Click(object sender, EventArgs e)
        {
            ckPendiente.Checked = false;
            ckFormulado.Checked = false;
            ckPlaneado.Checked = false;
            ckProceso.Checked = false;
            ckCerrado.Checked = true;
            ckCancelado.Checked = false;
            ckStandBy.Checked = false;
            ckError.Checked = false;
            ckFinalizado.Checked = true;

            _ckStatus = new bool[9]
            {
                ckPendiente.Checked, ckFormulado.Checked, ckPlaneado.Checked, ckProceso.Checked, ckCerrado.Checked,
                ckCancelado.Checked, ckStandBy.Checked, ckError.Checked,ckFinalizado.Checked
            };
        }
        private void AplifcaFormatoIconoDgv()
        {
            foreach (DataGridViewRow row in dgvPF.Rows)
            {
                bool aprob = Convert.ToBoolean(row.Cells[__AprobadoFabricarBool.Name].Value);
                if (aprob)
                {
                    ((ImageAndTextCell)dgvPF.Rows[row.Index].Cells[__aprImg.Name]).Image = (Image)imList.Images[4];
                }
            }

        }
        private void txtFiltroOF_TextChanged(object sender, EventArgs e)
        {
            AplicaFiltros();
        }
        private void txtFiltroOF_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void dgvPF_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                txtMaterialSeleccionado.Text = null;
                txtOFSeleccionada.Text = null;
                txtClienteSeleccionado.Text = null;
                txtKgFabricarSeleccionado.Text = null;
                txtOvSeleccionado.Text = null;
                _numeroOfSeleccion = null;
                _statusOfSeleccion = PlanProduccionStatusManager.StatusOf.Error;
                _ofAutorizada = false;
                return;
            }
            _numeroOfSeleccion = Convert.ToInt32(dgv[__idplan.Name, e.RowIndex].Value);
            txtMaterialSeleccionado.Text = dgv[__material.Name, e.RowIndex].Value.ToString();
            txtOFSeleccionada.Text = dgv[__idplan.Name, e.RowIndex].Value.ToString();
            txtClienteSeleccionado.Text = dgv[__cliente.Name, e.RowIndex].Value == null ? @"No Disponinble" : dgv[__cliente.Name, e.RowIndex].Value.ToString();
            txtOvSeleccionado.Text = dgv[__ov.Name, e.RowIndex].Value == null ? null : dgv[__ov.Name, e.RowIndex].Value.ToString();
            txtKgFabricarSeleccionado.Text = dgv[__kgFabricar.Name, e.RowIndex].Value.ToString();
            CalculaMRPData(ckCalculoMrp.Checked);
            _statusOfSeleccion = PlanProduccionStatusManager.MapStatusOfFromText2(dgvPF[__status.Name, e.RowIndex].Value.ToString());
            txtStatusOF.Text = _statusOfSeleccion.ToString();
            _ofAutorizada = Convert.ToBoolean(dgv[__AprobadoFabricarBool.Name, e.RowIndex].Value);
            HabilitaBotonesSegunEstadoOF();
        }
        private void CalculaMRPData(bool calcular)
        {
            Color b1 = Color.LightGreen;
            Color f1 = Color.DarkBlue;
            Color br = Color.LightGray; //backcolor reset
            if (!calcular)
            {
                //MRP-CRM Data Reset
                txtDespachadoU30.Text = null;
                txtFabricadoU30.Text = null;
                txtConsumidoU30.Text = null;
                txtClientesLlevanMaterial.Text = null;
                txtMrpPendienteEntrega.Text = null;
                txtMrpNumeroClientes.Text = null;
                txtUltimaFabricacion.Text = null;
                txtDespachadoU30.BackColor = Color.LightGray;
                txtFabricadoU30.BackColor = Color.LightGray;
                txtConsumidoU30.BackColor = Color.LightGray;
                txtClientesLlevanMaterial.BackColor = Color.LightGray;
                txtMrpPendienteEntrega.BackColor = Color.LightGray;
                txtMrpNumeroClientes.BackColor = Color.LightGray;
                txtUltimaFabricacion.BackColor = Color.LightGray;
            }
            else
            {
                var r = new MRPConsumoMaterialStats(txtMaterialSeleccionado.Text);
                r.CalculoDeConsumo();
                txtDespachadoU30.Text = r.KgDespachados.ToString("N0");
                txtFabricadoU30.Text = r.KgFabricados.ToString("N0");
                txtConsumidoU30.Text = r.KgConsumidos.ToString("N0");
                //
                if (r.KgDespachados != 0)
                {
                    txtDespachadoU30.ForeColor = f1;
                    txtDespachadoU30.BackColor = b1;
                }
                else
                {
                    txtDespachadoU30.BackColor = br;
                }

                if (r.KgFabricados != 0)
                {
                    txtFabricadoU30.ForeColor = f1;
                    txtFabricadoU30.BackColor = b1;
                }
                else
                {
                    txtFabricadoU30.BackColor = br;
                }

                if (r.KgConsumidos != 0)
                {
                    txtConsumidoU30.ForeColor = f1;
                    txtConsumidoU30.BackColor = b1;
                }
                else
                {
                    txtConsumidoU30.BackColor = br;
                }
                //CRM - Despachos y Pedidos
                var crmDespachos = new PendientesDespacho();
                crmDespachos.GetPendienteDespachoMaterial(txtMaterialSeleccionado.Text);
                txtMrpPendienteEntrega.Text = crmDespachos.KgPendientesDespacho.ToString("N1");
                txtMrpNumeroClientes.Text = crmDespachos.CantidadRegistros.ToString("N0");
                txtUltimaFabricacion.Text = new PlanProduccionManager().GetUltimaFabricacion(txtMaterialSeleccionado.Text).ToString();
                //
                if (crmDespachos.KgPendientesDespacho != 0)
                {
                    txtMrpPendienteEntrega.ForeColor = f1;
                    txtMrpPendienteEntrega.BackColor = b1;
                }
                else
                {
                    txtMrpPendienteEntrega.BackColor = br;
                }

                if (crmDespachos.CantidadRegistros != 0)
                {
                    txtMrpNumeroClientes.ForeColor = f1;
                    txtMrpNumeroClientes.BackColor = b1;
                }
                else
                {
                    txtMrpNumeroClientes.BackColor = br;
                }

                var z = new MrpCrmStats(txtMaterialSeleccionado.Text);
                z.EstadisticasDespachoMaterial(1, 90);
                txtClientesLlevanMaterial.Text = z.CantidadClientes.ToString("N0");

                if (z.CantidadClientes != 0)
                {
                    txtClientesLlevanMaterial.ForeColor = f1;
                    txtClientesLlevanMaterial.BackColor = b1;
                }
                else
                {
                    txtClientesLlevanMaterial.BackColor = br;
                }
            }
        }
        private void rbtnVerStockCq_Click(object sender, EventArgs e)
        {
            var f0 = new FrmCq();
            f0.Show();
        }
        private void txtMrpPendienteEntrega_DoubleClick_1(object sender, EventArgs e)
        {
            //mostrar listado de pendientes de entrega!

            if (string.IsNullOrEmpty(txtMrpPendienteEntrega.Text))
            {
                MessageBox.Show(@"No hay informacion para visualizar", @"Datos no disponibles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                decimal kg = Convert.ToDecimal(txtKgFabricarSeleccionado.Text);
                if (kg > 0)
                {
                    using (var f = new FrmCRM08PendientePorProducto(txtMaterialSeleccionado.Text))
                    {
                        f.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show(@"No hay informacion para visualizar", @"Datos no disponibles", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }

        }
        private void dDespachado_Click(object sender, EventArgs e)
        {
            var f = new FrmPP19MRP1Consumos(txtMaterialSeleccionado.Text);
            f.ShowDialog();
        }
        private void HabilitaBotonesSegunEstadoOF()
        {
            rbtnFormular.Enabled = false;
            rbtModifcarKgOF.Enabled = false;
            rbtnPlanificar.Enabled = false;
            rbCancelarOF.Enabled = false;
            rbtnIngresarTemporal.Enabled = false;
            rbtnCerrarOF.Enabled = false;
            rbVerIngresoRealizado.Enabled = false;
            rbtnImprimir.Enabled = false;
            rbtnAutorizarOF.Enabled = false;
            rbtNoAutorizarOF.Enabled = false;
            switch (_statusOfSeleccion)
            {
                case PlanProduccionStatusManager.StatusOf.Pendiente:
                    rbtnPlanificar.Enabled = true;
                    rbCancelarOF.Enabled = true;
                    rbtModifcarKgOF.Enabled = _permiteModificarKg;
                    if (_permiteAutorizar)
                    {
                        if (_ofAutorizada)
                        {
                            rbtNoAutorizarOF.Enabled = true;
                        }
                        else
                        {
                            rbtnAutorizarOF.Enabled = true;
                        }
                    }
                    rbtnFormular.Enabled = true;

                    break;
                case PlanProduccionStatusManager.StatusOf.Formulada:
                    rbtnPlanificar.Enabled = true;
                    rbCancelarOF.Enabled = true;
                    if (_ofAutorizada)
                    {
                        rbtNoAutorizarOF.Enabled = true;
                    }
                    else
                    {
                        rbtnAutorizarOF.Enabled = true;
                    }
                    break;
                case PlanProduccionStatusManager.StatusOf.Planeado:
                    rbtnIngresarTemporal.Enabled = true;
                    rbtnCerrarOF.Enabled = true;
                    rbtnImprimir.Enabled = true;
                    break;
                case PlanProduccionStatusManager.StatusOf.Proceso:
                    rbtnIngresarTemporal.Enabled = true;
                    rbtnCerrarOF.Enabled = true;
                    rbtnImprimir.Enabled = true;
                    break;
                case PlanProduccionStatusManager.StatusOf.Cerrada:
                    rbVerIngresoRealizado.Enabled = true;
                    rbtnImprimir.Enabled = true;
                    break;
                case PlanProduccionStatusManager.StatusOf.Cancelada:
                    break;
                case PlanProduccionStatusManager.StatusOf.StandBy:
                    rbtnPlanificar.Enabled = true;
                    rbCancelarOF.Enabled = true;
                    rbtModifcarKgOF.Enabled = _permiteModificarKg;
                    rbtnFormular.Enabled = true;
                    break;
                case PlanProduccionStatusManager.StatusOf.Error:
                    break;
                case PlanProduccionStatusManager.StatusOf.Finalizada:
                    rbVerIngresoRealizado.Enabled = true;
                    rbtnImprimir.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_statusOfSeleccion), _statusOfSeleccion, null);
            }
        }
        private void rbCancelarOF_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcionalidad en Progreso - Prueba en la proxima version", @"Proximamente!");

        }
        private void rbVerIngresoRealizado_Click(object sender, EventArgs e)
        {
            var f = new FrmPP16DetallesOFCerrada(_numeroOfSeleccion.Value);
            f.Show();
            this.Close();
        }
        private void rbtModifcarKgOF_Click(object sender, EventArgs e)
        {
            if (TsSecurityMng.CheckToEnableButton("PPCAMBIAKG"))
            {
                using (var form1 = new FrmPP18UpdateKgFabricar(_numeroOfSeleccion.Value))
                {
                    var resx = form1.ShowDialog();
                    if (resx == DialogResult.OK)
                    {
                        AplicaFiltros();
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    @"El Usuario no cuenta con los permisos suficientes para modificar los KG a Fabricar",
                    @"Permisos Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void rbtnFormular_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Se generará una pantalla para formular sin ingresar a la pantalla", @"Proximamente!");
        }
        private void rbtnAutorizarOF_Click(object sender, EventArgs e)
        {
            new AprobacionPlanificar().AprobarOF(_numeroOfSeleccion.Value, "PF1");
            MessageBox.Show(@"Se a Autorizado Correctamente la Orden de Fabricacion", @"Aprobacion de Planeacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            AplicaFiltros();
        }
        private void rbtNoAutorizarOF_Click(object sender, EventArgs e)
        {
            new AprobacionPlanificar().DesaprobarOF(_numeroOfSeleccion.Value, "PF1");
            MessageBox.Show(@"Se a DESAPROBADO la autorizacion para Fabricar esta Orden", @"Aprobacion de Planeacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            AplicaFiltros();
        }
    }
}

