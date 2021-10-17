using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.HR;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;
using TSControls;
using TextBox = System.Windows.Forms.TextBox;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP10CierreOF : Form
    {
        public FrmPP10CierreOF(int numeroOF)
        {
            InitializeComponent();
            _numeroOF = numeroOF;
        }

        //--------------------------------------------------------------------------------------------------------------------------------
        private int _numeroOF;
        private PlanProduccionStatusManager.StatusOf _statusOf;
        private T0070_PLANPRODUCCION _dataOf;
        public List<T0072_FORMULA_TEMP> _lstFormula = new List<T0072_FORMULA_TEMP>();

        //Variables suma dentro del DGV al recorrer 
        private decimal _xKgMpTotal = 0;
        private decimal _xPorcentajeFormula = 0;
        private decimal _xKgMpBatch = 0;
        private bool _materialConB = false;
        private bool _completarConsumoMP = false;
        private bool _flagRequiereRecalculo;
        private bool _stockDisponibleLineas;
        private readonly decimal margenVariacionMP = (decimal)0.05; //5% CONFIGURACION
        private readonly decimal mermaMaxima = (decimal)0.1; //10% CONFIGURACION

        //--------------------------------------------------------------------------------------------------------------------------------

        private List<T0072_FORMULA_TEMP> _lstDescuentoStock = new List<T0072_FORMULA_TEMP>();
#pragma warning disable CS0414 // The field 'FrmPP10CierreOF._listaAdded' is assigned but its value is never used
        private bool _listaAdded = false; //Utilizado para la reserva de batches en descuento de stock
#pragma warning restore CS0414 // The field 'FrmPP10CierreOF._listaAdded' is assigned but its value is never used
        //--------------------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Esta funciona refresca completamente el DGV (lista MP)
        /// Calcula los KG MP a descontar y Calcula Linea Total
        /// Formato de celdas / colores
        /// </summary>
        public void RefrescaDgvCompleto()
        {
            dgv.DataSource = null;
            var lstTmp = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);
            _xKgMpTotal = 0;
            _xKgMpBatch = 0;
            _xPorcentajeFormula = 0;
            decimal sumaKgCantidadFormula = 0;
            var batchQty = (int)cCantidadBatches.GetValueDecimal;
            _materialConB = false;
            foreach (var item in lstTmp)
            {
                if (item.Primario.StartsWith("B"))
                {
                    //No Toma en cuenta informacion de containers/insumos
                    _materialConB = true;
                }
                else
                {
                    //Solo considera materiales que no comienzan con 'B'
                    if (item.CantidadKGReal != null) _xKgMpTotal += item.CantidadKGReal.Value;
                    if (item.CantidadKG != null) sumaKgCantidadFormula += item.CantidadKG.Value;
                    if (item.CantidadPor != null) _xPorcentajeFormula += item.CantidadPor.Value;
                }
            }

            //Agrega linea de totales en DGV
            lstTmp.Add(new T0072_FORMULA_TEMP()
            {
                Primario = "Linea de Totales >>",
                CantidadKGReal = Decimal.Round(_xKgMpTotal, 2),
                CantidadKG = Decimal.Round(sumaKgCantidadFormula, 2),
                CantidadPor = Decimal.Round(_xPorcentajeFormula, 2),
            });

            dgv.DataSource = lstTmp;
            for (var i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Rows[dgv.Rows.Count - 1].Cells[i].Style.BackColor = Color.Blue;
                dgv.Rows[dgv.Rows.Count - 1].Cells[i].Style.ForeColor = Color.White;
            }

            //Recalcula celda KG-Batch
            for (var i = 0; i < dgv.Rows.Count - 1; i++)
            {
                decimal kgTotal = Convert.ToDecimal(dgv[__kgReal.Name, i].Value);
                decimal lineaKgBatch = Math.Round(kgTotal / batchQty, 2);
                _xKgMpBatch += lineaKgBatch; //abajo llamó
                dgv[__kgBatch.Name, i].Value = lineaKgBatch;


                if (Convert.ToDecimal(dgv[__stockLiberado.Name, i].Value) >= kgTotal)
                {
                    dgv[__stockLiberado.Name, i].Style.ForeColor = Color.DarkGreen;
                }
                else
                {
                    dgv[__stockLiberado.Name, i].Style.ForeColor = Color.Red;
                }


                dgv.Rows[i].Cells[__recalculo.Index].Style.BackColor =
                    (bool)dgv.Rows[i].Cells[__recalculo.Index].Value == true ? Color.LightCoral : Color.White;

                if ((bool)dgv.Rows[i].Cells[__added.Name].Value == true)
                {
                    dgv.Rows[i].Cells[__added.Name].Style.BackColor = Color.MediumSeaGreen;
                    dgv.Rows[i].Cells[__added.Name].Style.ForeColor = Color.Blue;
                }
                else
                {
                    dgv.Rows[i].Cells[__added.Name].Style.BackColor = Color.White;
                }

                if ((bool)dgv.Rows[i].Cells[__repro.Name].Value == true)
                {
                    dgv.Rows[i].Cells[__repro.Name].Style.BackColor = Color.MediumSeaGreen;
                    dgv.Rows[i].Cells[__repro.Name].Style.ForeColor = Color.Blue;
                }
                else
                {
                    dgv.Rows[i].Cells[__repro.Name].Style.BackColor = Color.White;
                }

                //Formato Celda KG-Real
                var celdaKg = dgv[__kgReal.Name, i];
                var celdaKgBatch = dgv[__kgBatch.Name, i];

                if (Convert.ToDecimal(celdaKg.Value) == 0)
                {
                    celdaKg.Style.ForeColor = Color.Red;
                    celdaKg.Style.BackColor = Color.LightPink;
                    celdaKgBatch.Style.ForeColor = Color.Red;
                    celdaKgBatch.Style.BackColor = Color.LightPink;
                }
                else
                {
                    celdaKg.Style.ForeColor = Color.MidnightBlue;
                    celdaKg.Style.BackColor = Color.Snow;
                    celdaKgBatch.Style.ForeColor = Color.MidnightBlue;
                    celdaKgBatch.Style.BackColor = Color.Snow;
                }

                //Formato Celda Formula %
                var celdaPorc = dgv[__cantidadKg.Name, i];
                if (Convert.ToDecimal(celdaPorc.Value) == 0)
                {
                    celdaPorc.Style.BackColor = Color.LightGray;
                    celdaPorc.Style.ForeColor = Color.Black;
                }
                else
                {
                    if (Convert.ToDecimal(celdaKg.Value) == 0)
                    {
                        celdaPorc.Style.BackColor = Color.Orange;
                        celdaPorc.Style.ForeColor = Color.Black;
                    }
                    else
                    {
                        //normal
                        celdaPorc.Style.BackColor = Color.Gainsboro;
                        celdaPorc.Style.ForeColor = Color.Black;
                    }
                }

                if (dgv[__Lote.Name, i].Value == null)
                {
                    dgv[__Lote.Name, i].Style.BackColor = Color.LightGray;
                }
                else
                {
                    dgv[__Lote.Name, i].Style.BackColor = Color.White;
                }


                //Si es Container
                if (dgv[__material.Name, i].Value.ToString().StartsWith("B"))
                {
                    dgv[__material.Name, i].Style.BackColor = Color.Gold;
                }

                //Chequeo de Status de Stock
                var statusLineaString = dgv[__StatusStock.Name, i].Value.ToString();
                var statusLineaType = ProductionPlanningStockManager.MapStatusOfFromText(statusLineaString);
                var celda = dgv[__StatusStock.Name, i].Style;
                switch (statusLineaType)
                {
                    case StatusStockDescuento.StockOK:
                        celda.BackColor = Color.LightGreen;
                        celda.ForeColor = Color.Black;
                        break;
                    case StatusStockDescuento.SinStock:
                        celda.BackColor = Color.LightGray;
                        celda.ForeColor = Color.Red;
                        break;
                    case StatusStockDescuento.Confirmado:
                        celda.BackColor = Color.MediumSeaGreen;
                        celda.ForeColor = Color.MidnightBlue;
                        break;
                    case StatusStockDescuento.Unknown:
                        celda.BackColor = Color.Red;
                        celda.ForeColor = Color.Orange;
                        break;
                    case StatusStockDescuento.Error:
                        celda.BackColor = Color.Red;
                        celda.ForeColor = Color.White;
                        break;
                    default:
                        dgv[__StatusStock.Name, i].Value = StatusStockDescuento.Unknown;
                        celda.BackColor = Color.Red;
                        celda.ForeColor = Color.White;
                        throw new ArgumentOutOfRangeException();
                }
            }

            dgv[__kgBatch.Name, dgv.Rows.Count - 1].Value = _xKgMpBatch;
            iNumeroBatch.Set = cCantidadBatches.GetValueDecimal > 0 ? CIconos.Tilde : CIconos.ExclamacionRed;
            if (_completarConsumoMP)
            {
                cConsumoMPxBatch.SetValue = _xKgMpBatch;
                cConsumoTotalMP.SetValue = _xKgMpTotal;
                iMpTotal.Set = _xKgMpTotal > 0 ? CIconos.Tilde : CIconos.ExclamacionRed;
                iMpXBatch.Set = _xKgMpBatch > 0 ? CIconos.Tilde : CIconos.ExclamacionRed;
                iKgFabricados.Set = cKgTotalFabricados.GetValueDecimal > 0 ? CIconos.Tilde : CIconos.ExclamacionYellow;
                if (cKgTotalFabricados.GetValueDecimal > 0)
                {
                    var merma = _xKgMpTotal - cKgTotalFabricados.GetValueDecimal;
                    cKgMermaTotal.SetValue = merma;
                    cMermaPorcentaje.SetValue = merma / _xKgMpTotal;
                    if (cMermaPorcentaje.GetValueDecimal > mermaMaxima)
                    {
                        iMermaOk.Set = CIconos.ExclamacionRed;
                        _flagRequiereRecalculo = true;
                    }
                    else
                    {
                        iMermaOk.Set = CIconos.Tilde;
                        _flagRequiereRecalculo = false;
                    }
                }
                _completarConsumoMP = false;
            }
            else
            {
                iMpTotal.Set = CIconos.Amarillo;
                iMpXBatch.Set = CIconos.Amarillo;
                iKgFabricados.Set = CIconos.Amarillo;
            }
            decimal ingresoTemporal = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF, true);
            cKgingresadosTemporal.SetValue = ingresoTemporal;
            cStockAIngresarAhora.SetValue = cKgTotalFabricados.GetValueDecimal - cKgingresadosTemporal.GetValueDecimal;
            iconContainer.Set = _materialConB ? CIconos.Verde : CIconos.Rojo;
            iconRecalculo.Set = _flagRequiereRecalculo ? CIconos.Rojo : CIconos.Verde;
            iconStatusDescuentoMPok.Set = _stockDisponibleLineas ? CIconos.Verde : CIconos.Rojo;
        }

        private void FrmIngresoProduccion_Load(object sender, EventArgs e)
        {
            _completarConsumoMP = true;
            ConfiguraCombobox();
            CargaDatosOF();
            HabilitaBotonesSegunEstado();
            _completarConsumoMP = false;

        }
        private void ConfiguraCombobox()
        {
            cmbOperador.Items.AddRange(HRComboManager.GetListaEmployee("PPOPERARIOPROD").ToArray());
            cmbOperador.SelectedIndex = -1;
            //
            cmbRecurso.ValueMember = "idrecurso";
            cmbRecurso.DisplayMember = "nombrerecurso";
            cmbRecurso.DataSource = new RecursosProduccion().GetListRecursosProduccion();
            //
            cmbSloc.DataSource = new Ubicaciones().GetUbicacionesStockDisponibleProduccion("CERR");
            cmbSloc.DisplayMember = "SLOC_DESC";
            cmbSloc.ValueMember = "SLOC";
            cmbSloc.SelectedValue = "STBY";
            //
            var estado = new StockEstadoManager();
            cmbEstadoLote.DataSource = estado.GetListEstadoDisponibleEs();
            cmbEstadoLote.DisplayMember = "ESTADO";
            cmbEstadoLote.ValueMember = "ESTADO";
            cmbEstadoLote.SelectedValue = estado.GetEstadoDefaultProduccion();
            //
        }
        private void CargaDatosOF()
        {
            _dataOf = PlanProduccionListManager.GetOFData(_numeroOF);
            if (_dataOf == null)
            {
                MessageBox.Show(
                    @"No Existen datos para la OF Seleccionada" + Environment.NewLine + @"No se puede Continuar con la carga de la OF",
                    @"Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            txtNumeroOF.Text = _numeroOF.ToString();
            txtMaterialFabricado.Text = _dataOf.MATERIAL;
            cIconMaterial.Set = _dataOf.MATERIAL == _dataOf.MATETIQUETA ? CIconos.Tilde : CIconos.ExclamacionYellow;
            _statusOf = PlanProduccionStatusManager.MapStatusOfFromText2(_dataOf.STATUS);
            txtEstadoOF.Text = _dataOf.STATUS;

            if (_dataOf.FPLAN == null) _dataOf.FPLAN = DateTime.Today;
            if (_dataOf.FechaFabricacion == null) _dataOf.FechaFabricacion = DateTime.Today;

            dtpFechaPlanificacion.Value = _dataOf.FPLAN.Value;
            dtpFechaIngresoProduccion.Value = _dataOf.FechaFabricacion.Value;
            txtKgPlanificados.Text = _dataOf.KG_FABRICAR.ToString("N1");

            decimal ingresoTemporal = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF, true);
            decimal ingresoTotal = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF);
            if (ingresoTotal != ingresoTemporal)
            {
                MessageBox.Show(@"Existe una diferencia de KG de Ingreso entro [Temporal y Total]", @"Atencion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cKgingresadosTemporal.SetValue = ingresoTotal;
            if (string.IsNullOrEmpty(_dataOf.Operario))
            {
                SetEp(cmbOperador, "Debe Ingresar Operador");
            }
            else
            {
                cmbOperador.SelectedItem = _dataOf.Operario;
                SetEp(cmbOperador);
            }

            if (_dataOf.RECURSO == null)
            {
                SetEp(cmbRecurso, "Debe Ingresar Recurso Produccion");
            }
            else
            {
                cmbOperador.SelectedValue = _dataOf.RECURSO;
                SetEp(cmbRecurso);
            }

            if (string.IsNullOrEmpty(_dataOf.NumLote))
                _dataOf.NumLote = _numeroOF.ToString();

            txtNumeroLote.Text = _dataOf.NumLote;
            txtContainer.Text = _dataOf.Env01;

            if (_dataOf.CantidadBatches == null)
                _dataOf.CantidadBatches = 1;

            cCantidadBatches.SetValue = _dataOf.CantidadBatches.Value;
            //_lstFormula = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF).ToList();

            if (_dataOf.CalculoMP <= 0)
            {
                //recalcula mp
                new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF, _dataOf.KG_FABRICAR);
                new PlanProduccionManager().SetKgRecalculo(_numeroOF, _dataOf.KG_FABRICAR);
                RefrescaDisponibilidadStockOF(-1, true);
            }
            else
            {
                RefrescaDisponibilidadStockOF(-1, true);
            }

            iconContainer.Set = _materialConB ? CIconos.Verde : CIconos.Rojo;
            iconRecalculo.Set = _flagRequiereRecalculo ? CIconos.Rojo : CIconos.Verde;
            iconStatusDescuentoMPok.Set = _stockDisponibleLineas ? CIconos.Verde : CIconos.Rojo;
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
        }
        private void SetEp(Control c, string error = "")
        {
            ep.SetError(c, error);
        }
        private void HabilitaBotonesSegunEstado()
        {
            //aca deshabilitar todos los botones
            dtpFechaIngresoProduccion.Enabled = false;
            cmbRecurso.Enabled = false;
            cmbOperador.Enabled = false;
            txtNumeroLote.ReadOnly = true;
            cmbEstadoLote.Enabled = false;
            cmbSloc.Enabled = false;
            txtContainer.ReadOnly = true;
            //
            cCantidadBatches.XReadOnly = true;
            cConsumoTotalMP.XReadOnly = true;
            cKgTotalFabricados.XReadOnly = true;
            //
            rbCambiarOF.Enabled = true;
            rbSetProceso.Enabled = false;
            rbSetStandBy.Enabled = false;
            rbtnVerReservas.Enabled = false;
            rbVerIngresoTemporal.Enabled = false;
            rbIngresarTemporal.Enabled = false;
            rbRecalculoBatch.Enabled = false;
            rbRecalculoFabricadoTotal.Enabled = false;
            rbtnRecalcularGrilla.Enabled = false;
            rbCerrarOF.Enabled = false;
            rbAgregarComplementoCierre.Enabled = false;
            rbAddMaterial.Enabled = false;

            switch (_statusOf)
            {
                case PlanProduccionStatusManager.StatusOf.Pendiente:
                    MessageBox.Show(
                        @"La Orden de Fabricacion se encuentra en estado PENDIENTE - Debe planificarla primero",
                        @"Orden Fabricacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case PlanProduccionStatusManager.StatusOf.Formulada:
                    MessageBox.Show(
                        @"La Orden de Fabricacion se encuentra en estado FORMULADA - Debe planificarla primero",
                        @"Orden Fabricacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case PlanProduccionStatusManager.StatusOf.Planeado:
                    //
                    dtpFechaIngresoProduccion.Enabled = true;
                    cmbRecurso.Enabled = true;
                    cmbOperador.Enabled = true;
                    cmbEstadoLote.Enabled = true;
                    cmbSloc.Enabled = true;
                    cCantidadBatches.XReadOnly = false;
                    cConsumoTotalMP.XReadOnly = false;
                    cKgTotalFabricados.XReadOnly = false;
                    //
                    rbSetProceso.Enabled = true;
                    rbSetStandBy.Enabled = true;
                    rbtnVerReservas.Enabled = true;
                    if (cKgingresadosTemporal.GetValueDecimal > 0)
                        rbVerIngresoTemporal.Enabled = true;

                    rbIngresarTemporal.Enabled = true;
                    rbRecalculoBatch.Enabled = true;
                    rbRecalculoFabricadoTotal.Enabled = true;
                    rbtnRecalcularGrilla.Enabled = true;
                    rbCerrarOF.Enabled = true;
                    rbAgregarComplementoCierre.Enabled = true;
                    rbAddMaterial.Enabled = true;


                    break;
                case PlanProduccionStatusManager.StatusOf.Proceso:
                    dtpFechaIngresoProduccion.Enabled = true;
                    cmbRecurso.Enabled = true;
                    cmbOperador.Enabled = true;
                    cmbEstadoLote.Enabled = true;
                    cmbSloc.Enabled = true;
                    cCantidadBatches.XReadOnly = false;
                    cConsumoTotalMP.XReadOnly = false;
                    cKgTotalFabricados.XReadOnly = false;
                    //
                    rbSetProceso.Enabled = false;
                    rbSetStandBy.Enabled = true;
                    rbtnVerReservas.Enabled = true;
                    if (cKgingresadosTemporal.GetValueDecimal > 0)
                        rbVerIngresoTemporal.Enabled = true;

                    rbIngresarTemporal.Enabled = true;
                    rbRecalculoBatch.Enabled = true;
                    rbRecalculoFabricadoTotal.Enabled = true;
                    rbtnRecalcularGrilla.Enabled = true;
                    rbCerrarOF.Enabled = true;
                    rbAgregarComplementoCierre.Enabled = true;
                    rbAddMaterial.Enabled = true;

                    break;
                case PlanProduccionStatusManager.StatusOf.Cerrada:
                    //vamos a la pantalla de OF Cerrada .
                    var f = new FrmPP16DetallesOFCerrada(_numeroOF);
                    f.Show();
                    this.Close();
                    break;
                case PlanProduccionStatusManager.StatusOf.Cancelada:
                    MessageBox.Show(
                        @"La Orden de Fabricacion se encuentra en estado CANCELADA - Debe planificarla primero",
                        @"Orden Fabricacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
                case PlanProduccionStatusManager.StatusOf.StandBy:
                    rbSetProceso.Enabled = true;
                    break;
                case PlanProduccionStatusManager.StatusOf.Error:
                    MessageBox.Show(
                        @"La Orden de Fabricacion se encuentra en estado ERROR - Debe planificarla primero",
                        @"Orden Fabricacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
                case PlanProduccionStatusManager.StatusOf.Finalizada:
                    //vamos a la pantalla de OF Cerrada .
                    var f1 = new FrmPP16DetallesOFCerrada(_numeroOF);
                    f1.Show();
                    this.Close();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private bool ValidaCompletitudIngresoDefinitivo()
        {
            bool resp = true;
            bool validacion1;
            SetEp(cmbOperador);
            SetEp(cmbSloc);
            SetEp(cmbRecurso);
            SetEp(txtNumeroLote);
            SetEp(cmbEstadoLote);
            SetEp(dtpFechaIngresoProduccion);
            //
            SetEp(cCantidadBatches);
            SetEp(cConsumoTotalMP);
            SetEp(cKgTotalFabricados);
            SetEp(cMermaPorcentaje);
            //
            //obtenenr de nuevo los kg temporales
            decimal ingresoTemporal = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF, true);
            cKgingresadosTemporal.SetValue = ingresoTemporal;
            cStockAIngresarAhora.SetValue = cKgTotalFabricados.GetValueDecimal - cKgingresadosTemporal.GetValueDecimal;
            if (ingresoTemporal != cKgingresadosTemporal.GetValueDecimal)
            {
                var x = MessageBox.Show(@"Atencion: Los KG Temporales han cambiado desde que se cargo esta pantalla" + Environment.NewLine + "Desea Continuar con el cierre?",
                    @"Modificacion de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return false;
            }

            if (cmbOperador.SelectedItem == null)
            {
                SetEp(cmbOperador, "Debe seleccionar un Operador");
                resp = false;
            }

            if (cmbSloc.SelectedValue == null)
            {
                SetEp(cmbSloc, "Debe seleccionar ubicacion para Stock a Ingresar");
                resp = false;
            }

            if (cmbRecurso.SelectedValue == null)
            {
                SetEp(cmbRecurso, "Debe Seleccionar Recurso Utilizado para Producir");
                return false;
            }

            if (string.IsNullOrEmpty(txtNumeroLote.Text))
            {
                SetEp(txtNumeroLote, "Debe completar un numero de Lote");
                resp = false;
            }

            if (cmbEstadoLote.SelectedValue == null)
            {
                SetEp(cmbEstadoLote, "Debe seleccionar un estado de Lote Valido");
                resp = false;
            }

            if (dtpFechaIngresoProduccion.Value > DateTime.Today)
            {
                SetEp(dtpFechaIngresoProduccion, "La fecha de Produccion es Invalida");
                resp = false;
            }

            if (dtpFechaIngresoProduccion.Value.AddDays(10) <= DateTime.Today)
            {
                DialogResult dialogResult = MessageBox.Show(
                    @"Confirma que la fecha de ingreso es correcta?", @"Confirma fecha de Ingreso [<10 Dias]",
                    MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    SetEp(dtpFechaIngresoProduccion, "La fecha de Produccion no ha sido confirmada");
                    resp = false;
                }

                return false;
            }

            if (resp)
            {
                validacion1 = true;
                ciconoValidacion1.Set = CIconos.Verde;
            }
            else
            {
                validacion1 = false;
                ciconoValidacion1.Set = CIconos.Rojo;
                return false;
            }

            //
            if (cCantidadBatches.GetValueDecimal > 0 && cCantidadBatches.GetValueDecimal < 100)
            {
                iNumeroBatch.Set = CIconos.Tilde;
            }
            else
            {
                iNumeroBatch.Set = CIconos.ExclamacionRed;
                SetEp(cCantidadBatches, "La cantidad de Batches no puede ser 0");
                resp = false;
            }

            if (cKgTotalFabricados.GetValueDecimal <= 0)
            {
                SetEp(cKgTotalFabricados, "Debe completar los KG a Ingresar");
                resp = false;
                return false;
            }
            else
            {
                if (cKgTotalFabricados.GetValueDecimal < cKgingresadosTemporal.GetValueDecimal)
                {
                    SetEp(cKgTotalFabricados, "Los Kg Fabricados son menor a los KG Temporales ya Ingresados");
                    resp = false;
                }
            }

            if (_flagRequiereRecalculo)
            {
                SetEp(cMermaPorcentaje, "Se necesita recalcular el consumo de MP en la grilla para poder continuar");
                resp = false;
            }


            RefrescaDisponibilidadStockOF(-1, false);
            if (_stockDisponibleLineas == false)
            {
                MessageBox.Show(
                    @"No se puede continuar porque hay items que no tienen stock disponible O se encuentra en estado Desconocido (Unknown)!",
                    @"Validacion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }


            //Validacion de KG a Fabricar
            //1 mayor a cero
            //2 mayor= a temporal
            //3 validar merma // a- mayor= a cero y menor a tolerancia


            return true;
        }
        private void txtNumeroLote_DoubleClick(object sender, EventArgs e)
        {
            txtNumeroLote.ReadOnly = false;
        }

        /// <summary>
        /// Identifica automaticamente si existe un unico lote para descontar. Sino abre el form para 
        /// seleccionar lote
        /// </summary>
        /// <returns></returns>
        private int IdentificaStockDescuento(int numeroOF, string material, decimal kg)
        {
            decimal kgDescontar = kg;
            int idstockSeleccionado =
                new IngresoStockProduccion().IdentificaUnicoLoteAutomaticoOF(numeroOF, material, kg);

            if (idstockSeleccionado > 0)
            {
                //encontro un lote - lo asigna y lo devuelve
                new ReservaStockOF().ReservarStockOF(idstockSeleccionado, numeroOF, kgDescontar);
                return idstockSeleccionado;
            }
            else
            {
                //no encontro un lote - abre el form para la seleccion del mismo
                using (var f0 = new FrmPP11SelectBatch(material, kgDescontar, numeroOF, false))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        var idstock = f0.IdstockSeleccionado;
                        var stockfound = StockManager.GetStockLine(idstock);
                        var kgSeleccionado = decimal.Round(f0.KgSeleccionados, 2);
                        var kgRestante = decimal.Round((kgDescontar - kgSeleccionado), 2);

                        if (stockfound.Stock == kgSeleccionado)
                        {
                            //Toma linea entera
                            new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                            if (kgRestante > 0)
                            {
                                var item = new T0072_FORMULA_TEMP
                                {
                                    CantidadKGReal = kgRestante,
                                    Primario = material,
                                    idItemFormula = _lstDescuentoStock.Count + 1,
                                    BatchNumber = null,
                                    StatusStock = null,
                                    OF = _numeroOF,
                                    idStockReservado = null
                                };
                                _lstDescuentoStock.Add(item);
                                _listaAdded = true;
                            }
                        }
                        else if (decimal.Round((decimal)stockfound.Stock, 2) > kgSeleccionado)
                        {
                            //Hace split en stock
                            new StockManager().SplitStock(idstock, kgSeleccionado);
                            new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                            if (kgDescontar > kgSeleccionado)
                            {
                                //Hace split en listatemporal
                                new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                                var item = new T0072_FORMULA_TEMP
                                {
                                    CantidadKGReal = kgRestante,
                                    Primario = material,
                                    idItemFormula = _lstDescuentoStock.Count + 1,
                                    BatchNumber = null,
                                    StatusStock = null,
                                    OF = _numeroOF,
                                    idStockReservado = null
                                };
                                _lstDescuentoStock.Add(item);
                                _listaAdded = true;
                            }
                        }
                        else
                        {
                            //Agrega linea a descontar en listatemporal
                            new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                            var item = new T0072_FORMULA_TEMP
                            {
                                CantidadKGReal = kgRestante,
                                Primario = material,
                                idItemFormula = _lstDescuentoStock.Count + 1,
                                BatchNumber = null,
                                StatusStock = null,
                                OF = _numeroOF,
                                idStockReservado = null
                            };
                            _lstDescuentoStock.Add(item);
                            _listaAdded = true;
                        }

                        return idstock;
                    }

                    //Cancelo la seleccion!
                    return -1;
                }
            }
        }
        /// <summary>
        /// Vuelve a chequear disponiblidad de stock y refresaca el DGV.
        /// Devuelve false si algo de lo que estaba reservado ya no lo esta
        /// </summary>
        private void RefrescaDisponibilidadStockOF(int numeroLinea = -1, bool asignaColoresDgv = false)
        {
            //Llamar con asignaColoresDgv False solo para confirmar que esta ok antes de ingresasr
            _stockDisponibleLineas = new ProductionPlanningStockManager(_numeroOF).SetAndCheckStatusStockMateriasPrimasOF(numeroLinea);
            if (asignaColoresDgv)
            {
                RefrescaDgvCompleto();
            }
        }

        /// <summary>
        /// Remueve el stock reservado + Ingreso del stock + Log
        /// </summary>
        /// <returns></returns>
        private bool IngresoFinalProduccion_Log()
        {
            var log = new MmLog();
            bool resultadoDescuento = true;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int idstock;
                for (var a = 0; a < _lstDescuentoStock.Count - 1; a++)
                {
                    if (_lstDescuentoStock[a].CantidadKGReal > 0)
                    {
                        idstock = _lstDescuentoStock[a].idStockReservado.Value;
                        var resultStock = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstock);
                        if (resultStock != null)
                        {
                            if (resultStock.Material != _lstDescuentoStock[a].Primario)
                            {
                                //No coinciden los datos de la linea reservada
                                resultadoDescuento = false;
                            }
                            else
                            {
                                if (Math.Round(resultStock.Stock, 1) !=
                                    Math.Round(_lstDescuentoStock[a].CantidadKGReal.Value, 1))
                                {
                                    //No coinciden los Kg de la linea reservada
                                    resultadoDescuento = false;
                                }
                                else
                                {
                                    log.LogMovimientoT40(_lstDescuentoStock[a].Primario,
                                        dtpFechaIngresoProduccion.Value,
                                        Convert.ToInt32(MmLog.TipoMovimiento.ConsumoMP), "OF", _numeroOF.ToString(),
                                        resultStock.Stock * -1, "ES", resultStock.SLOC, resultStock.Estado, "E", "LX",
                                        resultStock.Batch);
                                    db.T0030_STOCK.Remove(resultStock);
                                }
                            }
                        }
                        else
                        {
                            //La linea de stock reservada ya no se encuentra disponible
                            resultadoDescuento = false;
                        }
                    }
                }

                if (resultadoDescuento == false)
                {
                    //Revierte all LOG descuento MP
                    log.RevierteLogDescuentoMP(_numeroOF);
                    return false;
                }

                //Continua con el descuento
                db.SaveChanges();

                //Define cuantos Kg tiene que ingresar ahora
                var kgFabricados = cKgTotalFabricados.GetValueDecimal;
                var kgYaIngresados = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF);
                var kgAIngresarAHORA = kgFabricados - kgYaIngresados;

                if (kgAIngresarAHORA > 0)
                {
                    new IngresoStockProduccion().IngresoStockProductoFabricado(_numeroOF,
                        dtpFechaIngresoProduccion.Value, kgAIngresarAHORA, txtNumeroLote.Text,
                        cmbSloc.SelectedValue.ToString(), Convert.ToInt32(cmbRecurso.SelectedValue),
                        cmbOperador.SelectedItem.ToString(), cmbEstadoLote.SelectedValue.ToString(), "ES",
                        txtObservacionIngreso.Text, tipoMovimiento: MmLog.TipoMovimiento.IngresoStockProduccion);

                    //Abajo esta el ingreso completo- pero removi los adicionales de cantidad de paradas, etc...

                    //new IngresoStockProduccion().IngresoStockProductoFabricado(_numeroOF,
                    //    dtpFechaIngresoProduccion.Value, kgAIngresar, txtNumeroLote.Text,
                    //    cmbSloc.SelectedValue.ToString(), Convert.ToInt32(cmbRecurso.SelectedValue),
                    //    cmbOperador.SelectedValue.ToString(), cmbEstadoLote.SelectedValue.ToString(), "ES",
                    //    txtObservacionIngreso.Text, cantidadStops: Convert.ToInt32(txtCantidadParadas.Text),
                    //    minutosStop: Convert.ToInt32(txtMinutosParados.Text),
                    //    numeroPasadas: Convert.ToInt32(txtNumeroPasadas.Text),
                    //    limpiezaCabezal: ckLimpiezaCabezal.Checked, limpiezaCompleta: ckLimpiezaCompleta.Checked,
                    //    tipoMovimiento: MmLog.TipoMovimiento.IngresoStockProduccion);
                }


                return true;
            }
        }

        private void BlanqueaDatosAfterProductionIn()
        {
            txtNumeroOF.Text = null;
            txtEstadoOF.Text = null;
            txtMaterialFabricado.Text = null;

            txtKgPlanificados.Text = null;
            //txtKgTotalMP.Text = null;
            //txtKgIngresoTemporal.Text = null;
            cKgingresadosTemporal.SetValue = 0;
            cKgTotalFabricados.SetValue = 0;
            //cmbEstadoLote.Text = null;
            cmbRecurso.Text = null;
            cmbOperador.Text = null;
            txtNumeroLote.Text = null;
            //cmbSloc.Text = null;
            //dgvIngresoTemporal.DataSource = null;
            //dgvIngresoTemporal.DataSource = null;
            //btnIngresoProduccionTemporal.Enabled = false;

        }

        //Asigna lotes para las materias primas que no tienen el status de CONFIRMADO
        private bool AsignacionFinaldeLotes()
        {
            RefrescaDisponibilidadStockOF();
            if (_stockDisponibleLineas == false)
            {
                MessageBox.Show(
                    @"ATENCION: No se puede continuar porque EXISTEN ITEMS que no tienen stock disponible O se encuentran en estado Desconocido (Unknown)!",
                    @"Error en la Validacion de STOCK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            var statusOKDescontar = true; //True significa que todos los items se puede descontar
#pragma warning disable CS0219 // The variable 'kgADescontar' is assigned but its value is never used
            decimal kgADescontar = 0; //Son los Kg que tiene que descontar del material
#pragma warning restore CS0219 // The variable 'kgADescontar' is assigned but its value is never used


            _lstDescuentoStock = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);
            //Lista temoporal donde asignara los batches a descontar 
            _listaAdded = false; //Flag que indica si se agrego algun item en la lista (x split)

            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = false;
                var lstLocal = new List<T0072_FORMULA_TEMP>(_lstDescuentoStock); //para poder refrescar el DgV


                //Primero pone la lista en estado StockOK para items ==0 (no descontara items)
                foreach (var item0 in lstLocal.Where(c => c.CantidadKGReal == 0))
                {
                    item0.StatusStock = StatusStockDescuento.StockOK.ToString();
                }

                //Recorre la lista de punta a punta - si el item no tiene estado asigna UNKNOWN
                //Y recorre actuando sobre items que no estan en estado CONFIRMADO.
                foreach (var item in lstLocal.Where(c => c.CantidadKGReal > 0))
                {
                    if (String.IsNullOrEmpty(item.StatusStock))
                        item.StatusStock = StatusStockDescuento.Unknown.ToString();

                    if (item.StatusStock == StatusStockDescuento.Confirmado.ToString())
                    {
                        //Si el status es "Confirmado" ya esta listo para descontar - no hay que hacer
                        statusOKDescontar = true;
                    }
                    else
                    {
                        var idstk = IdentificaStockDescuento(_numeroOF, item.Primario, item.CantidadKGReal.Value);
                        if (idstk > 0)
                        {
                            var stkfound = StockManager.GetStockLine(idstk);
                            item.BatchNumber = stkfound.Batch;
                            item.idStockReservado = idstk;
                            item.StatusStock = StatusStockDescuento.Confirmado.ToString();
                            item.CantidadKGReal = stkfound.Stock;
                            keepGoing = true;
                        }
                        else
                        {
                            //Si devuelve -1 es porque se cancelo la seleccion.
                            statusOKDescontar = false;
                            item.StatusStock = null;
                        }
                    }
                }
            }

            if (statusOKDescontar == true)
            {
                //Abre la pantalle de confirmacion de lotes
                using (var f1 = new FrmPP15ConfirmacionLotesCierreOF(_numeroOF, _lstDescuentoStock, cKgTotalFabricados.GetValueDecimal, cStockAIngresarAhora.GetValueDecimal))
                {
                    DialogResult dr = f1.ShowDialog();
                    switch (dr)
                    {
                        case DialogResult.None:
                            return false;
                        case DialogResult.OK:
                            //_kgMPUsadaReal = f1.TotalKgMPUsada;
                            return true;
                        case DialogResult.Cancel:
                            new ReservaStockOF().LiberaStockReservadoOF(_numeroOF, true);
                            MessageBox.Show(
                                @"Se ha CANCELADO el ingreso de Stock y Liberado todos los Lotes comprometidos para esta OF",
                                @"Ingreso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    @"No se puede continuar con el proceso porque existen materias primas sin seleccion de LOTE o con Stock Inexistente",
                    @"Ingreso de Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }


        //Al Aceptar el valor de KG Modificadods
        private void dgvFormulaIngreso_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; //Header
            this.dgv.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
            decimal kgReal = 0;
            decimal kgBatch = 0;
            var cantidadBatch = cCantidadBatches.GetValueDecimal;

            //modificacion de columnas KG-Batch o KG-Real
            if (e.ColumnIndex == (int)dgv.Columns[__kgBatch.Name].Index)
            {
                //modificando columna KG-Batch
                kgBatch = Convert.ToDecimal(dgv[__kgBatch.Name, e.RowIndex].Value);
                kgReal = Math.Round(kgBatch * cCantidadBatches.GetValueDecimal, 2);
            }
            else
            {
                if (e.ColumnIndex == (int)dgv.Columns[__kgReal.Name].Index)
                {
                    //modificando columna KG-Real
                    kgReal = Convert.ToDecimal(dgv[__kgReal.Name, e.RowIndex].Value);
                    kgBatch = Math.Round((kgReal / cCantidadBatches.GetValueDecimal), 3);
                    dgv[__kgBatch.Name, e.RowIndex].Value = kgBatch;
                }
            }

            bool manualAdded = (bool)dgv[dgv.Columns[__added.Name].Index, e.RowIndex].Value;
            var iditem = Convert.ToInt32(dgv[__idItemFormula.Name, e.RowIndex].Value);
            if (kgReal == 0)
            {
                if (manualAdded == false)
                {
                    MessageBox.Show(
                        @"Este Item ya no sera tenido en cuenta para el recalculo de formula." + Environment.NewLine +
                        @"Para Incluirlo nuevamente en el recalculo automatico coloque un valor cualquiera diferente a CERO",
                        @"Atencion sobre Recalculo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new OrdenFabricacionBOMManager().UpdateKgReal(_numeroOF, iditem, kgReal, true);
                }
                else
                {
                    new OrdenFabricacionBOMManager().UpdateKgReal(_numeroOF, iditem, kgReal, false);
                }
            }
            else
            {
                if (manualAdded == false)
                {
                    new OrdenFabricacionBOMManager().UpdateKgReal(_numeroOF, iditem, kgReal, false);
                }
                else
                {
                    new OrdenFabricacionBOMManager().UpdateKgReal(_numeroOF, iditem, kgReal, true);
                }
            }
            RefrescaDisponibilidadStockOF(-1, true);
            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
        }
        // Asegurarse que el dato en el DGV sera del tipo autorizado para celda KG Real y KG Batch
        private void dgvFormulaIngreso_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgv.CurrentCell.ColumnIndex == (int)dgv.Columns[__kgReal.Name].Index)
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (dgv.CurrentCell.ColumnIndex == (int)dgv.Columns[__kgBatch.Name].Index)
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, false);
        }
        private void dgvFormulaIngreso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var myDgv = (DataGridView)sender;

            if (e.ColumnIndex == myDgv.Columns[__Lote.Name].Index && e.RowIndex >= 0)
            {
                //**Column LOTE
                decimal qkg = Convert.ToDecimal(myDgv[__kgReal.Name, e.RowIndex].Value);
                string qmaterial = myDgv[__material.Name, e.RowIndex].Value.ToString();

                if (qkg <= 0)
                {
                    MessageBox.Show(@"Para Seleccionar un Lote los KG del componente deben ser Mayor a 0.00 KG.",
                        @"Seleccion Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string lotePrevio = null;
                if (myDgv[myDgv.Columns[__Lote.Name].Index, e.RowIndex].Value != null)
                {
                    lotePrevio = myDgv[myDgv.Columns[__Lote.Name].Index, e.RowIndex].Value.ToString();
                }


                //En esta etapa solo dejaremos seleccionar un lote cuando pueda asignarse por completo
                var f2 = new FrmPP11SelectBatch(qmaterial, qkg, _numeroOF, true);
                var dr = f2.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //Nuevo lote asignado
                    var idstock = f2.IdstockSeleccionado;
                    var stockfound = StockManager.GetStockLine(idstock);
                    decimal kgSeleccionado = f2.KgSeleccionados;





                    //if (string.IsNullOrEmpty(lotePrevio) == false)
                    //{
                    //    var y = new ReservaStockOF().LiberaStockReservadoOF(qmaterial, _numeroOF, lotePrevio);
                    //    MessageBox.Show(
                    //        $@"Se ha liberado el lote# {lotePrevio} Anteriormente seleccionado" + Environment.NewLine +
                    //        $@"Total de lineas liberadas # {y}", @"Lote Liberado", MessageBoxButtons.OK,
                    //        MessageBoxIcon.Information);
                    //}

                    if (string.IsNullOrEmpty(lotePrevio) == false)
                    {
                        var y = new ReservaStockOF().LiberaStockReservadoOF(qmaterial, _numeroOF, lotePrevio);
                    }

                    if (stockfound.Stock == kgSeleccionado)
                    {
                        //Toma linea entera
                        new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                    }
                    else
                    {
                        //Hace split en stock
                        new StockManager().SplitStock(idstock, kgSeleccionado);
                        new ReservaStockOF().ReservarStockOF(idstock, _numeroOF, kgSeleccionado);
                    }


                    //    MessageBox.Show(
                    //        $@"Se ha liberado el lote# {lotePrevio} Anteriormente seleccionado" + Environment.NewLine +
                    //        $@"Total de lineas liberadas # {y}", @"Lote Liberado", MessageBoxButtons.OK,
                    //        MessageBoxIcon.Information);
                    //}

                    var kgPendientesDescuento = decimal.Round(qkg - kgSeleccionado, 2);
                    if (kgPendientesDescuento > 0)
                    {
                        //Esta opcion esta deshabilitada pero funcionaria para seleccionar stock menor al maximo
                        //Por decision de diseño no permitimos en esta instancia
                        var item = new T0072_FORMULA_TEMP
                        {
                            CantidadKGReal = kgPendientesDescuento,
                            Primario = qmaterial,
                            idItemFormula = _lstDescuentoStock.Count + 1,
                            BatchNumber = null,
                            StatusStock = null,
                            OF = _numeroOF,
                            idStockReservado = null
                        };
                        _lstDescuentoStock.Add(item);
                        _listaAdded = true;
                    }

                    new StockBatchManagerOF().AsignaLoteReservadoMateriaPrimaEnOF(_numeroOF,
                        Convert.ToInt32(dgv[__idItemFormula.Name, e.RowIndex].Value), idstock);
                }
                else if (dr == DialogResult.Abort)
                {
                    //Libera el lote 
                    new StockBatchManagerOF().LiberacionLoteOrdenFabricacionIndividual(_numeroOF,
                        Convert.ToInt32(dgv[__idItemFormula.Name, e.RowIndex].Value));
                }
                else
                {
                    MessageBox.Show(@"Se ha Cancelado la Selección/Liberación del Lote Asignado",
                        @"Seleccion de Lote Cancelada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.dgv.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
                RefrescaDisponibilidadStockOF(-1, true);
                //RefrescaDgvCompleto();
                this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
            }
        }

        #region Botones

        private void btnIngresoTemporal_Click(object sender, EventArgs e)
        {
            var f = new FrmPP09IngresoTemporal(_numeroOF);
            f.Show();
        }
        private void btnAyer_Click(object sender, EventArgs e)
        {
            dtpFechaIngresoProduccion.Value = DateTime.Today.AddDays(-1);
        }
        private void btnCancelarIngresoKg_Click(object sender, EventArgs e)
        {
            var f = new FrmPP16DetallesOFCerrada(_numeroOF);
            f.Show();
            this.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            RefrescaDisponibilidadStockOF(-1, true);
        }
        private void btnVerReservasStock_Click(object sender, EventArgs e)
        {
            var f = new FrmPP13VisualizarStockReservadoPF(_numeroOF);
            f.ShowDialog();
        }

        #endregion


        private void cmbOperador_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedItem == null && !string.IsNullOrEmpty(combo.Text))
                e.Cancel = true;
        }

        private void ResetStatus()
        {
            //aca hacer un reset por status?!
        }


        private void btnIngresoProduccionTemporal_Click(object sender, EventArgs e)
        {
            //if (ValidaCompletitudIngresoTemporal() == false)
            //    return;

            //DialogResult dialogResult = MessageBox.Show(string.Format(@"Confirma el ingreso en forma TEMPORAL (Sin descuento de Stock) de {0} KG?", txtKgIngresoTemporal.Text), @"Ingreso de Stock", MessageBoxButtons.YesNo);

            //if (dialogResult == DialogResult.Yes)
            //{
            //    if (string.IsNullOrEmpty(txtCantidadParadas.Text))
            //        txtCantidadParadas.Text = @"0";

            //    if (string.IsNullOrEmpty(txtMinutosParados.Text))
            //        txtMinutosParados.Text = @"0";

            //    if (string.IsNullOrEmpty(txtNumeroPasadas.Text))
            //        txtNumeroPasadas.Text = @"0";

            //    if (string.IsNullOrEmpty(txtCantidadParadas.Text))
            //        txtCantidadParadas.Text = @"0";

            //    new IngresoStockProduccion().IngresoStockProductoFabricado(_numeroOF, dtpFechaIngresoProduccion.Value, Convert.ToDecimal(txtKgIngresoTemporal.Text), txtNumeroLote.Text, cmbSloc.SelectedValue.ToString(), Convert.ToInt32(cmbRecurso.SelectedValue), cmbOperador.SelectedValue.ToString(), cmbEstadoLote.SelectedValue.ToString(), "ES", txtObservacionIngreso.Text, cantidadStops: Convert.ToInt32(txtCantidadParadas.Text), minutosStop: Convert.ToInt32(txtMinutosParados.Text), numeroPasadas: Convert.ToInt32(txtNumeroPasadas.Text), limpiezaCabezal: ckLimpiezaCabezal.Checked, limpiezaCompleta: ckLimpiezaCompleta.Checked);

            //    MessageBox.Show(@"Se ha ingresado correctamente el stock temporal indicado", "Ingreso Stock Temporal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    SetDataSourceIngresoTemporal();

            //    CargaDatosOF();
            //    AccionStatus();
            //}
            //else if (dialogResult == DialogResult.No)
            //{
            //    return;
            //}
        }
        private void ValidarMP()
        {
            //if (string.IsNullOrEmpty(txtRecalculoFormula.Text))
            //{
            //    txtRecalculoFormula.Text = 0.ToString("N2");
            //    toolTip1.ToolTipTitle = "Error en la Seleccion de Kg";
            //    toolTip1.Show("La Cantidad de Kg para el recalculo de MP debe ser mayor a 0 Kg.", txtRecalculoFormula, txtRecalculoFormula.Location, 5000);
            //    e.Cancel = false;
            //    return;
            //}

            //var kgRecalculoMP = Convert.ToDecimal(txtRecalculoFormula.Text);

            //if (kgRecalculoMP < 0)
            //{
            //    toolTip1.ToolTipTitle = "Error en la Seleccion de Kg";
            //    toolTip1.Show("La materia prima calculada debe ser MAYOR a 0 Kg.", txtRecalculoFormula, txtRecalculoFormula.Location, 5000);
            //    e.Cancel = true;
            //    return;
            //}

            //if (kgRecalculoMP < (_kgIngresadosTemporal - _kgIngresadosTemporal * margenVariacionMP))
            //{
            //    toolTip1.ToolTipTitle = "Error en la Seleccion de Kg";
            //    toolTip1.Show("La materia prima calculada es menor a los Kg ya ingresados en forma TEMPORAL", txtRecalculoFormula, txtRecalculoFormula.Location, 5000);
            //    e.Cancel = true;
            //    return;
            //}

            //var dr = MessageBox.Show($"Confirma el recalculo automatico de formula para {kgRecalculoMP} Kg?", @"Recalculo Automatico de Formula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.No)
            //{
            //    _kgMPRecalculoFormula = kgRecalculoMP;
            //    RefrescaEstadisticasProduccion();

            //    toolTip1.ToolTipTitle = "Atencion!";
            //    toolTip1.ToolTipIcon = ToolTipIcon.Info;
            //    toolTip1.Show("La grilla del consumo de materias primas no se ha recalculado en forma automatica debido a su eleccion. Si el total ya ingresado individualmente en cada materia prima coincide, el proceso estara correcto para continuar", txtRecalculoFormula, txtRecalculoFormula.Location, 6000);
            //    return;
            //}

            //new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF, kgRecalculoMP);
            //new PlanProduccionManager().SetKgRecalculo(_numeroOF, kgRecalculoMP);
            //_kgMPRecalculoFormula = kgRecalculoMP;
            //RefrescaDgvCompleto();
            //e.Cancel = false;
        }




        private void cKgTotalFabricados_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetEp(cKgTotalFabricados);
            SetEp(cConsumoMPxBatch);
            SetEp(cConsumoTotalMP);

            if (cKgTotalFabricados.GetValueDecimal == 0)
            {
                SetEp(cKgTotalFabricados, "Debe completar el valor de KG Total Fabricados");
                iKgFabricados.Set = CIconos.ExclamacionYellow;
                return;
            }

            if (cKgTotalFabricados.GetValueDecimal < cKgingresadosTemporal.GetValueDecimal)
            {
                SetEp(cKgTotalFabricados, "Los KG fabricados son menores a los KG Temporales ya Ingresados");
                iKgFabricados.Set = CIconos.ExclamacionRed;
                e.Cancel = true;
            }

            if (cConsumoTotalMP.GetValueDecimal < cKgTotalFabricados.GetValueDecimal)
            {
                //Se fabrican mas Kg que la MP utilizada -- Merma Negativa
                var resp = MessageBox.Show(
                    $@"Los KG Fabricados son mayores que los KG de MP Utilizada y esto no puede ocurrir" +
                    Environment.NewLine +
                    $@"Desea Recalcular AHORA el consumo de MP utilizando como base total MP => {cKgTotalFabricados} (total fabricdo)?",
                    @"Merma Negativa no Admisible",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                {
                    //poner un flag que necesita recalculo.-
                    //merma negativa - no admisible
                    SetEp(cKgTotalFabricados, "No pueden fabricarse mas KG de la Materia Prima Consumida");
                    iKgFabricados.Set = CIconos.Rojo;
                    iMermaOk.Set = CIconos.Rojo;
                    e.Cancel = true;
                }
                else
                {
                    //recalcular aca en DGV.- 
                    SetEp(cConsumoTotalMP);
                    SetEp(cConsumoMPxBatch);
                    cConsumoTotalMP.SetValue = cKgTotalFabricados.GetValueDecimal;
                    cConsumoMPxBatch.SetValue =
                        Math.Round(cKgTotalFabricados.GetValueDecimal / cCantidadBatches.GetValueDecimal, 2);
                    iNumeroBatch.Set = CIconos.Tilde;
                    iMpTotal.Set = CIconos.Tilde;
                    iMpXBatch.Set = CIconos.Tilde;
                    iMermaOk.Set = CIconos.Tilde;
                    cMermaPorcentaje.SetValue = 0;
                    new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF,
                        cKgTotalFabricados.GetValueDecimal);
                    new PlanProduccionManager().SetKgRecalculo(_numeroOF, cKgTotalFabricados.GetValueDecimal);
                    RefrescaDgvCompleto();
                }

                return;
            }

            if (cConsumoTotalMP.GetValueDecimal > 0)
            {
                decimal mermaKg = (cConsumoTotalMP.GetValueDecimal - cKgTotalFabricados.GetValueDecimal);
                decimal mermaPor = mermaKg / cConsumoTotalMP.GetValueDecimal;
                if (mermaPor > mermaMaxima)
                {
                    //Excede tolerancia
                    var resp = MessageBox.Show(
                        $@"La Merma calculada no admite este Ingreso sin recalcular las MP - Merma calculada: {mermaPor.ToString("P2")}" +
                        Environment.NewLine +
                        $@"Desea Recalcular el consumo de MP Ahora (utilizanndo como base {cKgTotalFabricados.GetValueDecimal} Kg.)?",
                        @"Recalculo Sugerido",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.No)
                    {
                        //poner un flag que necesita recalculo.-
                        _flagRequiereRecalculo = true;
                        iMpXBatch.Set = CIconos.Rojo;
                        iMpTotal.Set = CIconos.Rojo;
                        SetEp(cConsumoTotalMP, "La Merma generada requiere recalculo");
                        cMermaPorcentaje.SetValue = mermaPor;
                        iMermaOk.Set = CIconos.Rojo;
                    }
                    else
                    {
                        //recalcular aca en DGV.- 
                        new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF,
                            cKgTotalFabricados.GetValueDecimal);
                        new PlanProduccionManager().SetKgRecalculo(_numeroOF, cKgTotalFabricados.GetValueDecimal);
                        RefrescaDgvCompleto();
                        mermaKg = (cConsumoTotalMP.GetValueDecimal - cKgTotalFabricados.GetValueDecimal);
                        mermaPor = mermaKg / cConsumoTotalMP.GetValueDecimal;
                        cMermaPorcentaje.SetValue = mermaPor;
                        iMermaOk.Set = CIconos.Tilde;
                        SetEp(cConsumoTotalMP);
                        SetEp(cConsumoMPxBatch);
                    }
                }
                else
                {
                    //no excede tolerancia --
                    cMermaPorcentaje.SetValue = mermaPor;
                    iKgFabricados.Set = CIconos.Tilde;
                    iMpTotal.Set = CIconos.Tilde;
                    iMpXBatch.Set = CIconos.Tilde;
                    if (cKgTotalFabricados.GetValueDecimal == cConsumoTotalMP.GetValueDecimal)
                    {
                        //merma =0
                        iKgFabricados.Set = CIconos.Tilde;
                        iMpTotal.Set = CIconos.Tilde;
                        iMpXBatch.Set = CIconos.Tilde;
                        iMermaOk.Set = CIconos.Tilde;
                    }
                    else
                    {
                        //hay diferencia pero esta OK
                        iMermaOk.Set = CIconos.Azul;
                    }
                }
            }

            cStockAIngresarAhora.SetValue = cKgTotalFabricados.GetValueDecimal - cKgingresadosTemporal.GetValueDecimal;

            //if (_kgTotalCierreOF == 0)
            //{
            //    //escapatoria
            //    toolTip1.ToolTipTitle = "Kg Incorrectos";
            //    //toolTip1.Show("Los Kg a Ingresar no pueden ser 0 - Corrija y Recalcule para continuar...", txtKgingresados, txtKgingresados.Location, 5000);545454
            //    e.Cancel = false;
            //    return;
            //}

            //if (_kgTotalCierreOF < 0)
            //{
            //    toolTip1.ToolTipTitle = "Kg Incorrectos";
            //    //toolTip1.Show("Los Kg a Ingresar no pueden ser Menor a 0Kg", txtKgingresados, txtKgingresados.Location, 5000);54545
            //    e.Cancel = true;
            //    return;
            //}

            ////_kgIngresadosTemporal = Convert.ToDecimal(txtKgingresados.Text);545454
            //_kgAIngresar = _kgTotalCierreOF - _kgIngresadosTemporal;


            //if (_kgAIngresar < 0)
            //{
            //    MessageBox.Show(@"Los Totales Fabricados para cerrar esta OF son menores a la sumatoria de Kg Temporales ya Ingresados",
            //        @"Ingreso de Produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    e.Cancel = true;
            //    return;
            //}

            //if (Math.Round(_kgMPUsadaReal, 1) < Math.Round(_kgTotalCierreOF, 1))
            //{
            //    MessageBox.Show(
            //        @"Los KG Totales Fabricados generan MERMA NEGATIVA (Se usa menos MP y magicamente aparecen mas KG???",
            //        @"Error en Calculo de Utilizacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    e.Cancel = true;
            //    return;
            //}

            //if (_kgMPUsadaReal > (_kgTotalCierreOF + (_kgTotalCierreOF * mermaMaxima)))
            //{
            //    MessageBox.Show(
            //        @"Los Kg Fabricados sobrepasan el límite máximo autorizado de Merma para ingreso de produccion",
            //        @"Ingreso de Produccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    e.Cancel = true;
            //    return;
            //}
            //RefrescaEstadisticasProduccion();


        }
        private void cConsumoTotalMP_Validated(object sender, EventArgs e)
        {
            if (cKgTotalFabricados.GetValueDecimal != 0)
            {
                var mermaKg = cConsumoTotalMP.GetValueDecimal - cKgTotalFabricados.GetValueDecimal;
                cMermaPorcentaje.SetValue = mermaKg / cConsumoTotalMP.GetValueDecimal;
                if (cMermaPorcentaje.GetValueDecimal > mermaMaxima)
                {
                    iMermaOk.Set = CIconos.Rojo;
                }
                else
                {
                    iMermaOk.Set = CIconos.Azul;
                }
            }
            else
            {
                //aun non se ha completado los KG Maximo
                iMermaOk.Set = CIconos.ExclamacionYellow;
                cMermaPorcentaje.SetValue = 0;
            }

            var variacionRecalculo = cConsumoTotalMP.GetValueDecimal - _xKgMpTotal;
            var porcentajeRecalculo = variacionRecalculo / cConsumoTotalMP.GetValueDecimal;
            if (porcentajeRecalculo > margenVariacionMP)
            {
                var resp = MessageBox.Show(
                    @"El Cambio de Materia Prima Total Utilizada  Requiere recalcular la grilla de descuento de MP" +
                    Environment.NewLine + @"Desea realizar el recalculo ahora?", @"Recalculo Necesario",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                {
                    iMpTotal.Set = CIconos.ExclamacionYellow;
                    iMpXBatch.Set = CIconos.ExclamacionYellow;
                    _flagRequiereRecalculo = true;
                }
                else
                {
                    //Recalculo de MP en Grilla
                    new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF, cConsumoTotalMP.GetValueDecimal);
                    new PlanProduccionManager().SetKgRecalculo(_numeroOF, cConsumoTotalMP.GetValueDecimal);
                    this.dgv.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
                    RefrescaDisponibilidadStockOF(-1, true);
                    this.dgv.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
                    SetEp(cConsumoTotalMP);
                    SetEp(cConsumoMPxBatch);
                    _flagRequiereRecalculo = false;
                }
            }
        }
        private void cCantidadBatches_Validated(object sender, EventArgs e)
        {
            //al validar la cantidad de batches
            if (cConsumoMPxBatch.GetValueDecimal > 0)
            {
                //Tiene valor de consumo de MPxB -> Calcula MP Total
                cConsumoTotalMP.SetValue = Math.Round(cConsumoMPxBatch.GetValueDecimal * cCantidadBatches.GetValueDecimal, 2);
                cKgTotalFabricados.SetValue = 0;
                cMermaPorcentaje.SetValue = 0;
                cStockAIngresarAhora.SetValue = 0;

                iNumeroBatch.Set = CIconos.Tilde;
                iMpXBatch.Set = CIconos.Tilde;
                iKgFabricados.Set = CIconos.ExclamacionYellow;
                iMermaOk.Set = CIconos.ExclamacionYellow;

                var desfasajeMP = cConsumoTotalMP.GetValueDecimal - _xKgMpTotal;
                if (desfasajeMP != 0)
                {
                    var resp = MessageBox.Show(
                        @"El Cambio de Batches Requiere recalcular la grilla de descuento de MP" +
                        Environment.NewLine + @"Desea realizar el recalculo ahora?", @"Recalculo Necesario",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.No)
                    {
                        iMpTotal.Set = CIconos.ExclamacionYellow;
                        iMpXBatch.Set = CIconos.ExclamacionYellow;
                        _flagRequiereRecalculo = true;
                    }
                    else
                    {
                        //Recalculo de MP en Grilla
                        new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF, cConsumoTotalMP.GetValueDecimal);
                        new PlanProduccionManager().SetKgRecalculo(_numeroOF, cConsumoTotalMP.GetValueDecimal);
                        this.dgv.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
                        _completarConsumoMP = true;
                        RefrescaDisponibilidadStockOF(-1, true);
                        this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
                        SetEp(cConsumoTotalMP);
                        SetEp(cConsumoMPxBatch);
                        _flagRequiereRecalculo = false;
                    }
                }
            }
            else
            {
                //El consumo de mp por batch es 0.- 

            }

        }
        private void cConsumoMPxBatch_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            iMpXBatch.Set = CIconos.ExclamacionOrange;
            decimal totalMP = cConsumoMPxBatch.GetValueDecimal * cCantidadBatches.GetValueDecimal;

            if (totalMP == 0)
            {
                SetEp(cConsumoMPxBatch, "El Total de Kg no puede ser 0");
                e.Cancel = true;
                return;
            }

            if (totalMP < cKgingresadosTemporal.GetValueDecimal)
            {
                SetEp(cConsumoMPxBatch, "Consumo de MP no puede ser menor a los KG Temporales ya Ingresados");
                e.Cancel = true;
            }

            if (totalMP < cKgingresadosTemporal.GetValueDecimal)
            {
                SetEp(cConsumoMPxBatch, "Consumo de MP no puede ser menor a los KG Temporales ya Ingresados");
                e.Cancel = true;
            }

            if (totalMP < cKgTotalFabricados.GetValueDecimal)
            {
                SetEp(cConsumoMPxBatch, "Consumo de MP no puede ser menor a los KG a Ingresar");
                e.Cancel = true;
            }

            iMpTotal.Set = CIconos.Tilde;
        }
        private void cConsumoTotalMP_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            iMpTotal.Set = CIconos.ExclamacionOrange;
            if (cConsumoTotalMP.GetValueDecimal == 0)
            {
                SetEp(cConsumoTotalMP, "El Total de Kg no puede ser 0");
                e.Cancel = true;
                return;
            }

            if (cConsumoTotalMP.GetValueDecimal < cKgingresadosTemporal.GetValueDecimal)
            {
                SetEp(cConsumoTotalMP, "Consumo de MP no puede ser menor a los KG Temporales ya Ingresados");
                e.Cancel = true;
                return;
            }

            if (cConsumoTotalMP.GetValueDecimal < cKgTotalFabricados.GetValueDecimal)
            {
                SetEp(cConsumoTotalMP, "Consumo de MP no puede ser menor a los KG a Ingresar");
                e.Cancel = true;
                return;
            }

            if (cCantidadBatches.GetValueDecimal == 0) cCantidadBatches.SetValue = 1;
            iNumeroBatch.Set = CIconos.Tilde;
            cConsumoMPxBatch.SetValue =
                Math.Round(cConsumoTotalMP.GetValueDecimal / cCantidadBatches.GetValueDecimal, 2);
            iMpXBatch.Set = CIconos.Tilde;
            iMpTotal.Set = CIconos.ExclamacionYellow;
        }



        private void rbRecalculoBatch_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                @"Esta acción redistribuira el total de MP en sus componenetes utilizando la formula" +
                Environment.NewLine +
                @"Desea Continuar?", @"Recalculo de Formula", MessageBoxButtons.YesNo);
            if (resp == DialogResult.No)
                return;

            new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF, cConsumoTotalMP.GetValueDecimal);
            new PlanProduccionManager().SetKgRecalculo(_numeroOF, cConsumoTotalMP.GetValueDecimal);
            RefrescaDgvCompleto();
            cMermaPorcentaje.SetValue = 0;
            iMermaOk.Set = CIconos.ExclamacionYellow;
            SetEp(cConsumoTotalMP);
            SetEp(cConsumoMPxBatch);
            cKgTotalFabricados.SetValue = 0;
            iKgFabricados.Set = CIconos.ExclamacionYellow;
        }
        private void rbRecalculoFabricadoTotal_Click(object sender, EventArgs e)
        {
            if (cKgTotalFabricados.GetValueDecimal == 0)
            {
                MessageBox.Show(@"No se puede recalcular consumo de MP porque el Total KG Fabricado aun es 0",
                    @"Operacion No Realizada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            new OrdenFabricacionBOMManager().RecalculaMateriaPrimaFormula(_numeroOF,
                cKgTotalFabricados.GetValueDecimal);
            new PlanProduccionManager().SetKgRecalculo(_numeroOF, cKgTotalFabricados.GetValueDecimal);
            RefrescaDgvCompleto();
            cMermaPorcentaje.SetValue = 0;
            iMermaOk.Set = CIconos.Tilde;
            SetEp(cConsumoTotalMP);
            SetEp(cConsumoMPxBatch);
        }
        private void rbCerrarOF_Click(object sender, EventArgs e)
        {
            if (ValidaCompletitudIngresoDefinitivo() == false)
                return;
            var msg =
                MessageBox.Show(
                    @"Cierre Definitivo:" + Environment.NewLine +
                    $@"Se ingresará en este momento  {cStockAIngresarAhora.GetValueDecimal} KG" + Environment.NewLine +
                    $@"Y Se cerrara la OF por un Total de {cKgTotalFabricados.GetValueDecimal} KG",
                    $@"Confirma el Cierre de OF# {_numeroOF}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No) return;

            if (AsignacionFinaldeLotes())
            {
                if (IngresoFinalProduccion_Log())
                {
                    PlanProduccionStatusManager.SetStatusCerrado(_numeroOF, (int)cCantidadBatches.GetValueDecimal);
                    new OrdenFabricacionBOMManager().RecalculaPorcentajeRealUtilizado(_numeroOF, cConsumoTotalMP.GetValueDecimal);

                    if (rb2Si.Checked)
                    {
                        //Creacion automatica de nueva OF# por diferencia
                        var x = new PlanProduccionManager().AddPlanProduccion(txtMaterialFabricado.Text,
                            _dataOf.MATETIQUETA, cKgDiferenciaPlanIngreso.GetValueDecimal, 0,
                            DateTime.Today.AddDays(2), "Auto. x Diferencia Kg s/OF#" + _numeroOF, "CERR",
                            PlanProduccionManager.MotivoFabricacion.Stock, null, false, false, false);
                        if (x > 0)
                        {
                            MessageBox.Show($@"Se ha agregado automaticamente la OF# {x} al plan de produccion",
                                @"Auto-Planning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(
                                $@"Ha Ocurrido un error al agregar la OF Automatica al plan de produccion" +
                                Environment.NewLine + @"Debera generar la OF en forma manual",
                                @"Auto-Planning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (rb1Si.Checked)
                    {
                        //Ingreso de Merma -->
                        MessageBox.Show(
                            @"La funcionalidad de agregado automatico de purga aun no se encuentra desarrollada.- Consulte nuevamente en un tiempo. Gracias",
                            @"Funcion no desarrollada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    rbCerrarOF.Enabled = false;
                    new ReservaStockOF().LiberaStockReservadoOF(_numeroOF, false);  //Libera stock que pueda haber llegado a quedar "tomado"
                    new BOMManager().SetUltimoUso(_dataOf.Formula.Value, dtpFechaIngresoProduccion.Value); //Actualiza Ultimo USO

                    MessageBox.Show(@"Se ha CERRADO correctamente la Orden de Fabricacion", @"Cierre Exitoso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dtpFechaIngresoProduccion.Enabled = false;
                    cmbRecurso.Enabled = false;
                    cmbOperador.Enabled = false;
                    txtNumeroLote.ReadOnly = true;
                    cmbEstadoLote.Enabled = false;
                    cmbSloc.Enabled = false;
                    cKgTotalFabricados.XReadOnly = true;
                    cCantidadBatches.XReadOnly = true;
                    cConsumoTotalMP.XReadOnly = true;
                    _flagRequiereRecalculo = true;
                }
                else
                {
                    MessageBox.Show(
                        @"Por un error en la reserva de Materias Primas se ha cancelado el Ingreso/Cierre de la Orden de Fabricacion",
                        @"Cierre FALLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                RefrescaDisponibilidadStockOF(-1, true);
            }
        }
        private void rbAgregarComplementoCierre_Click(object sender, EventArgs e)
        {
            //abrir panntalla para cargar datos extensivos de cierre
            //todo: dessarrollar esta pantalla
            MessageBox.Show(@"Pantalla en desarrollo");

        }
        private void rbAddMaterial_Click(object sender, EventArgs e)
        {
            var f = new FrmPP14AgregarMaterialPF(_numeroOF, this);
            f.ShowDialog();
        }
        private void rbIngresarTemporal_Click(object sender, EventArgs e)
        {
            var f = new FrmPP09IngresoTemporal(_numeroOF);
            f.Show();
            //ojo recalcular
        }
        private void rbtnVerReservas_Click(object sender, EventArgs e)
        {
            var f = new FrmPP13VisualizarStockReservadoPF(_numeroOF);
            f.ShowDialog();
        }
        private void rbtnRecalcularGrilla_Click(object sender, EventArgs e)
        {
            this.dgv.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
            RefrescaDisponibilidadStockOF(-1, true);
            this.dgv.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaIngreso_CellValueChanged);
        }
        private void rbSetStandBy_Click(object sender, EventArgs e)
        {
            PlanProduccionStatusManager.SetStatusEnProceso(_numeroOF);
            ResetStatus();
        }
        private void rbSetProceso_Click(object sender, EventArgs e)
        {
            PlanProduccionStatusManager.SetStatusEnProceso(_numeroOF);
            ResetStatus();
        }
        private void rbVerIngresoTemporal_Click(object sender, EventArgs e)
        {
            if (cKgingresadosTemporal.GetValueDecimal == 0)
            {
                MessageBox.Show(
                    @"No Se puede Ver el detalle del Ingreso Temporal porque esta OF no tiene Ingresos Temporales",
                    @"Temporales Inexistentes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var f = new FrmPP12DetalleIngresoTemporal(_numeroOF);
            f.ShowDialog();
        }
        private void rbCambiarOF_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmPP17CambiarOF())
            {
                if (f0.ShowDialog() == DialogResult.OK)
                {
                    _numeroOF = f0.OFSeleccionada;
                    CargaDatosOF();
                }
            }
        }


        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cKgTotalFabricados_Validated(object sender, EventArgs e)
        {
            cStockAIngresarAhora.SetValue = cKgTotalFabricados.GetValueDecimal - cKgingresadosTemporal.GetValueDecimal;
        }
    }
}
