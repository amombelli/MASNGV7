using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.DataFix;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.HR;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP09IngresoTemporal : Form
    {
        public FrmPP09IngresoTemporal()
        {
            _numeroOF = -1;
            InitializeComponent();
        }

        public FrmPP09IngresoTemporal(int numeroOF)
        {
            _numeroOF = numeroOF;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------
        private int _numeroOF;
        private decimal _kgIngresar = 0;
        //-----------------------------------------------------------------------------------

        private void FrmIngresoProduccionTemporal_Load(object sender, EventArgs e)
        {
            //
            cmbOperador.Items.AddRange(HRComboManager.GetListaEmployee("PPOPERARIOPROD").ToArray());
            cmbOperador.SelectedIndex = -1;
            //
            t0032RECURSOSBindingSource.DataSource = new RecursosProduccion().GetListRecursosProduccion();
            cmbRecurso.SelectedIndex = -1;
            //
            t0028SLOCBindingSource.DataSource = new Ubicaciones().GetUbicacionesStockDisponibleProduccion("CERR");
            cmbSloc.SelectedValue = "STBY";
            //
            var estado = new StockEstadoManager();
            t0029ESTADOSTOCKBindingSource.DataSource = estado.GetListEstadoDisponibleEs();
            cmbEstadoLote.SelectedValue = estado.GetEstadoDefaultProduccion();

            if (_numeroOF < 0)
            {
                txtNumeroOF.ReadOnly = false;
                txtNumeroOF.BackColor = Color.White;
            }
            else
            {
                txtNumeroOF.Text = _numeroOF.ToString();
                txtNumeroOF.BackColor = Color.Gainsboro;
                txtNumeroOF.ReadOnly = true;
                CargaDatosOF();
                //
            }
        }
        private void CargaDatosOF()
        {
            var ofData = PlanProduccionListManager.GetOFData(_numeroOF);
            if (ofData != null)
            {
                txtMaterialEtiqueta.Text = ofData.MATETIQUETA;
                if (ofData.MATETIQUETA == ofData.MATERIAL)
                {
                    txtMaterialEtiqueta.ForeColor = Color.Black;
                    txtMaterialEtiqueta.BackColor = Color.Gainsboro;
                }
                else
                {
                    txtMaterialEtiqueta.ForeColor = Color.OrangeRed;
                    txtMaterialEtiqueta.BackColor = Color.Black;
                }

                txtMaterialFabricado.Text = ofData.MATERIAL;
                txtEstadoOF.Text = ofData.STATUS.ToUpper();

                if (ofData.FechaFabricacion != null)
                    dtpFechaIngresoProduccion.Value = ofData.FechaFabricacion.Value;

                txtKgingresados.Text = ofData.KG_Fabricados.ToString("N2");

                if (ofData.Operario != null)
                    cmbOperador.SelectedItem = ofData.Operario;

                if (ofData.RECURSO != null)
                    cmbRecurso.SelectedValue = ofData.RECURSO;

                txtNumeroLote.Text = string.IsNullOrEmpty(ofData.NumLote) ? _numeroOF.ToString() : ofData.NumLote;

                var kgt = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF);

                txtKgingresados.Text = kgt.ToString("N2");

                if (PFFixKgTemporales.FixKgTemporalesIngresados(_numeroOF, kgt) == true)
                {
                    MessageBox.Show(@"Se han corregido los KG Temporales ingresados en la OF",
                        @"Error en KG Ingresados Temporales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (ofData.STATUS.ToUpper() == "PROCESO" || ofData.STATUS.ToUpper() == "PLANEADO")
                {
                    btnIngresoTemporal.Enabled = true;
                    txtKgIngresar.Enabled = true;
                    txtKgIngresar.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show(
                        @"Para poder ingresar produccion temporal la orden debe estar planeada o en proceso",
                        @"Error en Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnIngresoTemporal.Enabled = false;
                    txtKgIngresar.Enabled = false;
                    txtKgIngresar.ReadOnly = true;
                }
                CargaDatosTemporalesIngresados();
                //Carga Datos Temporales Ingresados
            }
        }

        private void CargaDatosTemporalesIngresados()
        {
            t0040MATMOVIMIENTOSBindingSource.DataSource = new PlanProduccionManager().GetListMovimientosIngresoProduccion(_numeroOF).ToList();
        }
        private bool ValidaDatosCompletos()
        {
            var retorno = true;

            if (dtpFechaIngresoProduccion.Value.Date > DateTime.Today)
            {
                MessageBox.Show(@"La fecha de produccion no puede ser mayor a HOY", @"Error en Datos Ingresados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            if (dtpFechaIngresoProduccion.Value < DateTime.Today.AddDays(-15))
            {
                MessageBox.Show(@"La fecha de produccion  en un ingreso temporal no puede ser menor a 1 quincena",
                    @"Error en Datos Ingresados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            if (cmbRecurso.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar recurso de produccion", @"Error en Datos Ingresados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            if (cmbOperador.SelectedItem == null)
            {
                MessageBox.Show(@"Debe Seleccionar Operador a Cargo", @"Error en Datos Ingresados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            if (string.IsNullOrEmpty(txtNumeroLote.Text))
            {
                MessageBox.Show(@"Debe Seleccionar un numero de Lote (Sugerencia: Numero OF)",
                    @"Error en Datos Ingresados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            if (cmbEstadoLote.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Estado del Lote valido", @"Error en Datos Ingresados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            if (cmbSloc.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar una ubicacion para el ingreso de Stock (Sugerencia: STBY)",
                    @"Error en Datos Ingresados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            if (_kgIngresar <= 0)
            {
                MessageBox.Show(@"Debe Seleccionar KG Valido de Ingreso", @"Error en Datos Ingresados",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = false;
            }

            return retorno;
        }
        private void btnIngresoTemporal_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletos() == false)
                return;

            var msg = MessageBox.Show($"Confirma el Ingreso Temporal de {_kgIngresar} Kg?", @"Ingreso Temporal de KG",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            new IngresoStockProduccion().IngresoStockProductoFabricado(_numeroOF, dtpFechaIngresoProduccion.Value,
                _kgIngresar, txtNumeroLote.Text, cmbSloc.SelectedValue.ToString(),
                Convert.ToInt32(cmbRecurso.SelectedValue), cmbOperador.SelectedItem.ToString(),
                cmbEstadoLote.SelectedValue.ToString(), "EST", txtObservacionIngreso.Text,
                cantidadStops: 0, minutosStop: 0, numeroPasadas: 0, limpiezaCabezal: false, limpiezaCompleta: false);

            MessageBox.Show(@"Se ha ingresado correctamente el stock temporal indicado al sistema",
                @"Ingreso Stock Temporal",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            _kgIngresar = 0;
            txtKgIngresar.Text = _kgIngresar.ToString("N2");
            txtKgingresados.Text = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF).ToString("N2");
            PlanProduccionStatusManager.SetStatusEnProceso(_numeroOF);
            txtEstadoOF.Text = PlanProduccionStatusManager.StatusOf.Proceso.ToString();
            CargaDatosTemporalesIngresados();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtNumeroOF_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroOF.Text))
            {
                toolTip1.ToolTipTitle = "Datos Incompletos";
                toolTip1.Show("Debe Completar un numero de OF Valida en estado Planeado/Proceso", txtNumeroOF, txtNumeroOF.Location, 5000);
                return;
            }
            var newOfNumber = Convert.ToInt32(txtNumeroOF.Text);
            if (newOfNumber != _numeroOF)
            {
                _numeroOF = newOfNumber;
                CargaDatosOF();
            }
        }
        private void txtNumeroOF_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void cmbEstadoLote_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void txtKgIngresar_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtKgIngresar_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgIngresar.Text))
            {
                txtKgingresados.Text = 0.ToString("N2");
            }

            var data = Convert.ToDecimal(txtKgIngresar.Text);
            if (data < 0)
            {
                data = 0;
                txtKgIngresar.Text = 0.ToString("N2");
            }
            else
            {
                txtKgIngresar.Text = data.ToString("N2");
            }
            _kgIngresar = data;
        }
        private void btnAyer_Click(object sender, EventArgs e)
        {
            dtpFechaIngresoProduccion.Value = DateTime.Today.AddDays(-1);
        }


        //Para accion reversar ingreso de stock
        private void dgvDetalleIngreso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();

            //string primario = datagridview[datagridview.Columns["pRIMARIODataGridViewTextBoxColumn"].Index, e.RowIndex].Value.ToString();

            switch (cellValue)
            {
                case "Reversar":
                    var id40 = Convert.ToInt32(datagridview[__idmovimiento.Name, e.RowIndex].Value);
                    ManejoReversacionStockTemporal(id40);
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void ManejoReversacionStockTemporal(int id40)
        {
            if (MessageBox.Show(@"Confirma reversar este ingreso de stock?", @"Reversion de Ingreso",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var stkDelete = new PPReversionIngresoStock();
            stkDelete.ChecAvailabiltyReverseManufacturedMaterial(id40);
            if (stkDelete.Motivo == PPReversionIngresoStock.MotivoError.OK)
            {
                var resultadoOK = stkDelete.ReversarIngresoMaterialFabricado();
                if (resultadoOK)
                {
                    MessageBox.Show(@"Se ha revertido CORRECTAMENTE el stock seleccionado",
                        @"Reversion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        @"Ha ocurrido un error inesperado en la baja del stock. Tome nota del material y realice un CONTEO FISICO // Coteje MM5 e informe los resultados",
                        @"Error Inesperado PP09_1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(
                    $"El Stock no puede Reversarse debido al siguiente error >>> {stkDelete.Motivo.ToString()} <<<",
                    @"Imposible de Reversar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtKgingresados.Text = new PlanProduccionManager().GetKgProducidosDesdeT0040(_numeroOF).ToString("N2");
            CargaDatosTemporalesIngresados();
        }
    }



}
