using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData.BOM;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP16DetallesOFCerrada : Form
    {
        public FrmPP16DetallesOFCerrada()
        {
            InitializeComponent();
            _numeroOF = 0;
        }

        public FrmPP16DetallesOFCerrada(int idplan)
        {
            InitializeComponent();
            _numeroOF = idplan;
        }

        //------------------------------------------------------------------------------------------------------
        private int _numeroOF;
        private List<T0040_MAT_MOVIMIENTOS> _listadoConsumoMP = new List<T0040_MAT_MOVIMIENTOS>();

        //------------------------------------------------------------------------------------------------------

        private void FrmOrdenFabricacionReversion_Load(object sender, EventArgs e)
        {
            LoadOFData();
        }

        private void LoadOFData()
        {
            var data = PlanProduccionListManager.GetOFData(_numeroOF);

            if (data != null && _numeroOF != 0)
            {
                _listadoConsumoMP = new PlanProduccionManager().GetListMovimientosMateriasPrimasConsumidasProduccion(_numeroOF).ToList();

                txtNumeroOF.Text = _numeroOF.ToString();
                txtEstadoOF.Text = data.STATUS.ToUpper();
                txtMaterialEtiqueta.Text = data.MATETIQUETA;
                txtMaterialFabricado.Text = data.MATERIAL;
                txtEstadoOF.Text = data.STATUS;
                txtKgPlanificados.Text = data.KG_FABRICAR.ToString();
                txtKgFabricados.Text = data.KG_Fabricados.ToString();

                var consumoMP = _listadoConsumoMP.Sum(c => c.CANTIDAD);
                txtConsumoMP.Text = consumoMP == null ? 0.ToString("N2") : Math.Abs(consumoMP.Value).ToString("N2");

                txtMermaProduccion.Text =
                    (Convert.ToDecimal(txtKgFabricados.Text) - Convert.ToDecimal(txtConsumoMP.Text)).ToString("N2");


                if (data.FPLAN != null)
                {
                    txtFechaPlanificacion.Text = data.FPLAN.Value.ToString("D");
                }
                else
                {
                    txtFechaPlanificacion.Text = @"Fecha NO Disponible";
                }

                if (data.LogDateIProd != null)
                {
                    txtFechaCierreFinalOF.Text = data.LogDateIProd.Value.ToString("D");
                    txtResponsableCierre.Text = data.LogUserIProd;
                }
                else
                {
                    txtFechaCierreFinalOF.Text = @"Fecha NO Disponible";
                    txtResponsableCierre.Text = null;
                }
                txtCancelMotivo.Text = data.CanceledReason;
                txtResponsableCancel.Text = data.CanceledUser;
                txtNumeroFormulaPlan.Text = data.Formula.ToString();
                dgvConsumoMP.DataSource = _listadoConsumoMP;

                SetDataSourceIngreso();
            }
            else
            {
                dgvIngresos.DataSource = null;
                MessageBox.Show(@"La Orden de Fabricacion es inexistente. No se puede continuar", @"Error en OF",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void CleanDetalleData()
        {
            txtId40.Text = null;
            txtHoraInicio.Text = null;
            txtHoraFin.Text = null;
            txtDuracionMinutos.Text = @"0";
            txtOperador.Text = null;
            txtRecursoShort.Text = null;
            txtRecursoDescripcion.Text = null;
            txtNumeroStops.Text = @"0";
            txtDuracionStops.Text = @"0";
            txtCantidadPasadas.Text = @"0";
            ckLimpiezaCabezal.Checked = false;
            ckLimpiezaCompleta.Checked = false;
            txtObservacionesStop.Text = null;
            txtFechaFabricacionReal.Text = null;
            txtFechaIngreso.Text = null;
            txtResponsableIngreso.Text = null;
        }
        private void LoadOFDetalleData(int id40)
        {
            txtId40.Text = id40.ToString();
            var i = new IngresoStockProduccion().GetDetalleIngresoProduccion(id40);
            if (i != null)
            {
                if (i.HORAI == null)
                {
                    txtHoraInicio.Text = @"08:00";
                }
                else
                {
                    var x = Convert.ToDateTime(i.HORAI);
                    txtHoraInicio.Text = x.ToString("t");
                }

                if (i.HORAF == null)
                {
                    txtHoraFin.Text = @"08:00";
                }
                else
                {
                    var x = Convert.ToDateTime(i.HORAF);
                    txtHoraFin.Text = x.ToString("t");
                }
                txtOperador.Text = i.OPERADOR;
                if (i.RECURSO_PROD != null)
                {
                    var rec = new RecursosProduccion().GetDetallesRecursoProduccion(i.RECURSO_PROD.Value);
                    txtRecursoShort.Text = rec.IdRecurso.ToString();
                    txtRecursoDescripcion.Text = rec.DescRecurso;
                }
                txtNumeroStops.Text = i.NUMSTOPS.ToString();
                txtDuracionStops.Text = i.TIEMPO_STOP.ToString();
                txtCantidadPasadas.Text = i.NUM_PASADAS.ToString();
                ckLimpiezaCabezal.Checked = i.LIM_CABEZAL.Value;
                ckLimpiezaCompleta.Checked = i.LIM_COMPLETA.Value;
                if (i.STOP_OBS != null)
                    txtObservacionesStop.Text = i.STOP_OBS.ToString();

                txtDuracionMinutos.Text =
                    FormatAndConversions.CalculaMinutosEntreDosHoras(txtHoraInicio.Text, txtHoraFin.Text);
            }

            var data40 = MmLog.GetT40Line(id40);
            txtObservacionesGenerales.Text = data40.COMENTARIO.ToString();
            txtFechaFabricacionReal.Text = data40.FECHAMOV.Value.ToString("D");
            txtFechaIngreso.Text = data40.LOG_DATE.Value.ToString("D");
            txtResponsableIngreso.Text = data40.LOG_USER;
        }
        private void SetDataSourceIngreso()
        {
            dgvIngresos.DataSource =
                new PlanProduccionManager().GetListMovimientosIngresoProduccion(_numeroOF).ToList();

            dgvIngresos.ClearSelection();
            CleanDetalleData();
        }
        private void SetDataSourceConsumoMP()
        {
            dgvConsumoMP.DataSource =
                new PlanProduccionManager().GetListMovimientosMateriasPrimasConsumidasProduccion(_numeroOF).ToList();
        }
        private void txtNumeroOF_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtNumeroOF_Leave(object sender, EventArgs e)
        {
            _numeroOF = string.IsNullOrEmpty(txtNumeroOF.Text) ? 0 : Convert.ToInt32(txtNumeroOF.Text);
            LoadOFData();
            AccionEstado();
        }
        private void AccionEstado()
        {
            var estado = PlanProduccionStatusManager.MapStatusOfFromText2(txtEstadoOF.Text);

            if (estado == PlanProduccionStatusManager.StatusOf.Cerrada)
            {
                btnRevertirConsumoMP.Enabled = true;
            }
            else
            {
                btnRevertirConsumoMP.Enabled = false;
            }
        }
        private void dgvIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                var id40 = Convert.ToInt32(dgvIngresos[0, e.RowIndex].Value);
                LoadOFDetalleData(id40);
            }


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    var cellValue = dgvIngresos[e.ColumnIndex, e.RowIndex].Value.ToString();
                    switch (cellValue)
                    {
                        case "REV":
                            if (txtEstadoOF.Text.ToUpper() == "CERRADA")
                            {
                                MessageBox.Show(
                                    @"ATENCION: Para revertir un ingreso temporal primero debe abrir la Orden de Fabricacion",
                                    @"No se puede revertir un ingreso de PT de una orden cerrada", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                            {
                                var dialogResult = MessageBox.Show(@"Confirma la reversion del ingreso SELECCIONADO?",
                                    @"Reversion Ingreso Temporal", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    ReversionIngresoTemporal(Convert.ToInt32(dgvIngresos[0, e.RowIndex].Value));
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    //***
                                }
                            }
                            break;

                        default:
                            MessageBox.Show(@"Boton no manejado aun");
                            break;
                    }
                }
            }
        }
        private void dgvIngresos_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnRevertirConsumoMP_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Confirma la reversion del ingreso de Materias Primas?",
                @"Reversion de Consumo de Materias Primas", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ReversionConsumoMP(_numeroOF);
            }
            else if (dialogResult == DialogResult.No)
            {
                //***
            }
        }

        private void ReversionConsumoMP(int numeroOF)
        {
            var result = new IngresoStockProduccion().ReversionConsumoMateriasPrimas(_numeroOF);
            if (result == true)
            {
                MessageBox.Show(@"Se ha revertido satisfactoriamente el consumo de MP", @"Reversion Consumo de MP",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadOFData();
                SetDataSourceIngreso();
            }
            else
            {
                MessageBox.Show(@"Ha ocurrido un error al revertir el consumo de MP",
                    @"Error en la Reversion del Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReversionIngresoTemporal(int id40)
        {
            var result = new IngresoStockProduccion().ReversionIngresoStock(id40, _numeroOF);
            if (result == true)
            {
                MessageBox.Show(@"Se ha revertido satisfactoriamente el ingreso seleccionado", @"Reversion Ingreso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetDataSourceIngreso();
            }
            else
            {
                MessageBox.Show(
                    @"Ha ocurrido un error al revertir el ingreso (el tipo de movimiento no permite reversion",
                    @"Error en la Reversion del Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnGenerarBOM_Click(object sender, EventArgs e)
        {
            DialogResult msg;
            if (rbSumarizadoMaterial.Checked)
            {
                msg = MessageBox.Show(@"Desea Ingresar esta formula como una nueva alternativa definitiva (SUMARIZANDO POR MATERIAL)?",
                    @"Ingreso de Formula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {

                msg = MessageBox.Show(@"Desea Ingresar esta formula como una nueva alternativa definitiva (DETALLE MATERIAL/LOTE)?",
                    @"Ingreso de Formula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (msg == DialogResult.No)
                return;

            var check = new BOMManager().FormulaExistente(txtMaterialFabricado.Text, MapItemsToStructure());
            if (check.Count > 0)
            {
                MessageBox.Show(
                    @"Atencion no se puede grabar la formula poruqe YA EXISTE una alternativa igual",
                    @"FORMULA EXISTENTE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                foreach (var item in check)
                {
                    MessageBox.Show($@"Valide la Siguiente Alternativa# {item.ToString()}", @"Alternativa Duplicada!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            using (var f0 = new FrmMdb02BomMainData(txtMaterialFabricado.Text, MapItemsToBOMStructure()))
            {
                f0.ShowDialog();
            }
        }

        //Mapea el ingreso de materia prima a la estructura de BOM
        private List<BomItemsStructure> MapItemsToBOMStructure()
        {
            var lst = new List<BomItemsStructure>();
            var listaCopia = new List<BomItemsStructure>();
            var idItem = 10;
            decimal kgBatch = 0;
            var i = 1;
            if (rbAperturaSegunIngreso.Checked)
            {
                foreach (var items in _listadoConsumoMP)
                {
                    var matx = MaterialMasterManager.GetSpecificPrimaryInformation(items.IDMATERIAL);
                    var item = new BomItemsStructure()
                    {
                        IdFormula = 0,
                        IdItem = idItem,
                        Item = items.IDMATERIAL,
                        Cantidad = Math.Abs(items.CANTIDAD.Value),
                        Explota = false,
                        ExplotaVersion = null,
                        CantidadPorcentaje = 0,
                        UoM = matx.UNIDAD,
                        Secuencia = i++,
                        DescripcionMaterial = matx.DescripcionFormulacion,
                        DescripcionLaboratorio = matx.DescripcionTecnicaLab,
                    };
                    kgBatch += kgBatch + Math.Abs(items.CANTIDAD.Value);
                    lst.Add(item);
                    idItem = idItem + 10;
                }
            }
            else
            {
                //Apertura Sumarizda - Sumariza primero en lista auxiliar
                foreach (var items in _listadoConsumoMP)
                {

                    var ix = lst.Find(c => c.Item == items.IDMATERIAL);
                    if (ix != null)
                    {
                        ix.Cantidad = ix.Cantidad + Math.Abs(items.CANTIDAD.Value);
                    }
                    else
                    {
                        //no encontro el item por lo que agrega a la lista copia
                        var matx = MaterialMasterManager.GetSpecificPrimaryInformation(items.IDMATERIAL);
                        var item = new BomItemsStructure()
                        {
                            IdFormula = 0,
                            IdItem = idItem,
                            Item = items.IDMATERIAL,
                            Cantidad = Math.Abs(items.CANTIDAD.Value),
                            Explota = false,
                            ExplotaVersion = null,
                            CantidadPorcentaje = 0,
                            UoM = matx.UNIDAD,
                            Secuencia = i++,
                            DescripcionMaterial = matx.DescripcionFormulacion,
                            DescripcionLaboratorio = matx.DescripcionTecnicaLab,
                        };
                        kgBatch = kgBatch + Math.Abs(items.CANTIDAD.Value);
                        lst.Add(item);
                        idItem = idItem + 10;
                    }
                }
            }
            //Asigna valor porcentual
            foreach (var item in lst)
            {
                item.CantidadPorcentaje = item.Cantidad / kgBatch;
            }
            return lst;

        }
        private List<T0021_FORMULA_I> MapItemsToStructure()
        {
            var lst = new List<T0021_FORMULA_I>();
            var listaCopia = new List<T0021_FORMULA_I>();
            var idItem = 0;
            decimal kgBatch = 0;
            var i = 1;
            if (rbAperturaSegunIngreso.Checked)
            {
                foreach (var items in _listadoConsumoMP)
                {
                    var item = new T0021_FORMULA_I()
                    {
                        FORMULA = 0,
                        ID_ITEM = idItem + 10,
                        ITEM = items.IDMATERIAL,
                        CANTIDAD = items.CANTIDAD,
                        Explota = false,
                        UNIDAD = MaterialMasterManager.GetSpecificPrimaryInformation(items.IDMATERIAL).UNIDAD,
                        CANTIDAD_PORC = 0,
                        Secuencia = i++,
                    };
                    kgBatch += items.CANTIDAD.Value;
                    lst.Add(item);
                }
            }
            else
            {
                //Apertura Sumarizda - Sumariza primero en lista auxiliar
                foreach (var items in _listadoConsumoMP)
                {
                    var ix = lst.Find(c => c.ITEM == items.IDMATERIAL);
                    if (ix != null)
                    {
                        ix.CANTIDAD = ix.CANTIDAD + items.CANTIDAD;
                    }
                    else
                    {
                        //no encontro el item por lo que agrega a la lista copia
                        var item = new T0021_FORMULA_I()
                        {
                            FORMULA = 0,
                            ID_ITEM = idItem + 10,
                            ITEM = items.IDMATERIAL,
                            CANTIDAD = Math.Abs(items.CANTIDAD.Value),
                            Explota = false,
                            UNIDAD = MaterialMasterManager.GetSpecificPrimaryInformation(items.IDMATERIAL).UNIDAD,
                            CANTIDAD_PORC = 0,
                            Secuencia = i++,
                        };
                        kgBatch = kgBatch + Math.Abs(items.CANTIDAD.Value);
                        lst.Add(item);
                    }
                }
            }
            //Asigna valor porcentual
            foreach (var item in lst)
            {
                item.CANTIDAD_PORC = item.CANTIDAD.Value / kgBatch;
            }
            return lst;
        }

        private void rbSumarizadoMaterial_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId40.Text))
            {
                MessageBox.Show(@"Para Modificar datos debe seleccionar una linea de detalle de Ingreso",
                    @"Falta Seleccion de Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var id40 = Convert.ToInt32(txtId40.Text);
            using (var f = new FrmPP17AddUpdateDetalleRecursosProduccion(id40, _numeroOF))
            {
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadOFDetalleData(id40);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtEstadoOF_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
