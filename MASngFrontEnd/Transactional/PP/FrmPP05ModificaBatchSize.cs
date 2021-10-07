using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP05ModificaBatchSize : Form
    {
        public FrmPP05ModificaBatchSize(int numeroOF, bool autoReserve)
        {
            InitializeComponent();
            _numeroOF = numeroOF;
            _autoReserve = autoReserve;
            BatchSize = 0;
            CantidadBatches = 1;
            KgFabricarNew = 0;
        }

        //------------------------------------------------------------------------------------  
        private readonly int _numeroOF;
        private readonly bool _autoReserve;
        public decimal BatchSize { get; private set; }
        public int CantidadBatches { get; private set; }
        public decimal KgFabricarNew { get; private set; }

        private List<T0072_FORMULA_TEMP> _lst = new List<T0072_FORMULA_TEMP>();
        const string Planta = "CERR";
        //------------------------------------------------------------------------------------
        private void FrmOrdenFabricaconModificaBatchSize_Load(object sender, EventArgs e)
        {
            var ofData = PlanProduccionListManager.GetOFData(_numeroOF);
            var formulaH = new BOMManager().GetFormulaHeader(Convert.ToInt32(ofData.Formula));

            txtNumeroOF.Text = _numeroOF.ToString();
            txtMaterialPrimario.Text = ofData.MATERIAL;
            txtNumeroFormula.Text = ofData.Formula.ToString();
            txtDescripcionFormula.Text = formulaH.DESC_FORMULA;
            txtKgPlanOri.Text = ofData.KG_FABRICAR_O.ToString("N2");

            KgFabricarNew = ofData.KG_FABRICAR;

            txtKgFabricarNew.Text = KgFabricarNew.ToString("N2");
            txtKgAFabricar.Text = KgFabricarNew.ToString("N2");

            if (ofData.CantidadBatches == 0 || ofData.CantidadBatches == null)
            {
                CantidadBatches = 1;
            }
            else
            {
                CantidadBatches = ofData.CantidadBatches.Value;
            }
            txtNumeroBatches.Text = CantidadBatches.ToString();
            lblCantidadBatches.Text = txtNumeroBatches.Text;
            txtTamañoBatch.Text = (KgFabricarNew / CantidadBatches).ToString("N2");
            //
            CantidadBatches = CantidadBatches;
            BatchSize = Convert.ToDecimal(txtTamañoBatch.Text);

            new StockBatchManagerOF().ActualizaStockDisponibleT0072(_numeroOF);
            RecalculaDatosDgvFormula();
            RecalculaFormulaAfterAddedItems();
            RecalculaDatosDgvPrint();
        }
        //DobleClick - Funcionalidad de Reemplazo de Formula
        private void dgvFormula_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                var materialP = dgvFormula[dgvFormula.Columns[__material.Name].Index, e.RowIndex].Value.ToString();
                var idItem =
                    Convert.ToInt32(dgvFormula[dgvFormula.Columns[__idItemFormula.Name].Index, e.RowIndex].Value);
                var kgReal = Convert.ToDecimal(dgvFormula[dgvFormula.Columns[__formPesada.Name].Index, e.RowIndex].Value);

                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    //HACIENDO CLICK EN ITEM --> REEMPLAZAR MATERIAL 
                    var numeroFormulas = new BOMManager().GetNumberOfBOM(materialP, true);

                    if (numeroFormulas == 0)
                    {
                        MessageBox.Show(@"No Existen BOM Activas para reemplazar este material",
                            @"Reemplazo Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    using (var f = new FrmPP06InterpolacionFormula(materialP, kgReal))
                    {
                        f.ShowDialog();
                        if (f.DialogResult == DialogResult.OK)
                        {
                            var lineaOri = _lst.Find(c => c.idItemFormula == idItem);
                            foreach (var item in f._lista.Where(c => c.idItemFormula != 999))
                            {
                                var itemAdd = new T0072_FORMULA_TEMP()
                                {
                                    Added = true,
                                    idItemFormula = _lst.Count + 1,
                                    Primario = item.Primario,
                                    CantidadBase = 0,
                                    CantidadPor = item.CantidadPor * lineaOri.CantidadPor,
                                    CantidadPorReal = item.CantidadPor * lineaOri.CantidadPor,
                                    CantidadKG = item.CantidadKGReal,
                                    CantidadKGReal = item.CantidadKGReal,
                                    OF = lineaOri.OF,
                                    Recalculo = false,
                                    Repro = false,
                                    NForm = item.NForm,
                                    STKLiberado = new StockList().GetKgStockDisponibleProduccion(item.Primario, Planta),
                                    STKTotal = StockList.GetKgStockTotalByMaterial(item.Primario, Planta),
                                };
                                _lst.Add(itemAdd);
                            }
                            //Manda a Cero a la linea que reemplazo
                            lineaOri.CantidadPor = 0;
                            lineaOri.CantidadPorReal = 0;
                            lineaOri.CantidadKG = 0;
                            lineaOri.CantidadKGReal = 0;
                            lineaOri.Recalculo = true;
                        }
                    }
                    RecalculaDatosDgvFormula(false);
                    RecalculaDatosDgvPrint();
                    return;
                }

                if (e.ColumnIndex == 6 && e.RowIndex >= 0)
                {
                    //ASIGNACION DE BATCH
                    decimal kg = (decimal)dgvFormula[__formPesada.Name, e.RowIndex].Value;
                    if (kg == 0)
                    {
                        MessageBox.Show(@"No se Puede Asignar un Lote a un material con 0 Kg.", @"Error en Kg",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var f2 = new FrmSeleccionBatch(materialP, kg, _numeroOF, idItem, "OF");
                    DialogResult dr = f2.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        //Se ha seleccionado un LOTE
                        var linea = _lst.Find(c => c.idItemFormula == idItem);
                        linea.BatchNumber = f2.LoteSeleccioando;
                        linea.idStockReservado = f2.IdStockSeleccionado;
                        RecalculaDatosDgvFormula(false);
                        RecalculaDatosDgvPrint();
                        //FormatoDgvPrint();
                    }
                }
            }
            else
            {

            }
        }
        private void dgvFormula_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string materialX = dgvFormula[0, e.RowIndex].Value.ToString();
            var idItem = (int)dgvFormula[__idItemFormula.Name, e.RowIndex].Value;
            txtIdItemSeleccionado.Text = idItem.ToString();

            if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                //Si hace click en celda batch
                if (dgvFormula[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    //Si el material es agregado/modificado
                    if ((bool)dgvFormula[4, e.RowIndex].Value == true || (bool)dgvFormula[5, e.RowIndex].Value)
                    {
                        DialogResult dialogResult = MessageBox.Show(@"Desea Remover el material Agregdo/Modificado?",
                            "OF", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (
                                new OrdenFabricacionBOMManager().RemoveMaterialModificadoOAgregadoDeOF(_numeroOF,
                                    (int)dgvFormula[9, e.RowIndex].Value) == false)
                            {
                                MessageBox.Show(@"Ocurrio algun error intentando remover el material seleccionado");
                            }
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                    }
                    else
                    {
                        //REMOCION DE BATCH SELECCIONADO
                        var dialogResult = MessageBox.Show(
                                @"Desea Remover el LOTE RESERVADO? (puede hacer doble click para asignar uno nuevo mas tarde)",
                                @"Liberacion de Lote Reservado", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.No)
                            return;

                        //Remueve el Item Reservado
                        var linea = _lst.Find(c => c.idItemFormula == idItem);
                        linea.BatchNumber = null;
                        linea.idStockReservado = null;
                        new StockBatchManagerOF().LiberacionLoteOrdenFabricacionIndividual(_numeroOF, idItem);
                        RecalculaDatosDgvFormula(false);
                        RecalculaDatosDgvPrint();
                        //dgvFormula[e.ColumnIndex, e.RowIndex].Value = null;
                    }
                }
            }
            else
            {
                //si hace click en cualquier celda (menos en batch)
                txtItemSeleccionado.Text =
                    dgvFormula[dgvFormula.Columns[__material.Name].Index, e.RowIndex].Value.ToString();
                txtKgItemFormula.Text = dgvFormula[3, e.RowIndex].Value.ToString();
                txtKgItemNuevo.Text = txtKgItemFormula.Text;
                if (string.IsNullOrEmpty(txtItemSeleccionado.Text) != true)
                    dgvStock.DataSource = new StockList().GetAllStockDispoProduccionStructura(txtItemSeleccionado.Text,
                        "CERR");
            }
        }

        private void RecalcFormAlCambiarKgFabricarFinal()
        {
            decimal totalFusionRepro = 0;
            decimal totalConRecalculo = 0;
            decimal totalKgSinRecalculo = 0;
#pragma warning disable CS0219 // The variable 'totalContainers' is assigned but its value is never used
            decimal totalContainers = 0;        //Materiales con 'B'
#pragma warning restore CS0219 // The variable 'totalContainers' is assigned but its value is never used
            decimal totalPorcentajeRecalculo = 0;
            decimal totalBase = 0;

            if (string.IsNullOrEmpty(txtKgFabricarNew.Text))
                txtKgFabricarNew.Text = 0.ToString("N2");

            var KgFinales = Convert.ToDecimal(txtKgFabricarNew.Text);
            var listaSinContainers = _lst.Where(c => c.Primario.ToUpper().StartsWith("B") == false).ToList();
            var ztotales = listaSinContainers.Find(c => c.idItemFormula == 999);
            listaSinContainers.Remove(ztotales);

            //Cheque Elementos Fusion/Repro
            var repro = listaSinContainers.Where(c => c.Repro && c.Added).ToList();
            if (repro.Count > 0)
            {
                foreach (var fx in repro)
                {
                    totalFusionRepro += (decimal)fx.CantidadKG;
                }
            }

            //Chequeo Elementos SIN RECALCULO
            var sinRecalculo = listaSinContainers.Where(c => c.Recalculo && c.Repro == false).ToList();
            if (sinRecalculo.Count > 0)
            {
                foreach (var srecx in sinRecalculo)
                {
                    totalKgSinRecalculo += (decimal)srecx.CantidadKG;
                }
            }

            //Chequeo Elementos Agregados con Recalculo de Formula
            var conRecalculo = listaSinContainers.Where(c => c.Recalculo == false).ToList();
            if (conRecalculo.Count > 0)
            {
                foreach (var rx in conRecalculo)
                {
                    totalConRecalculo += (decimal)rx.CantidadKG;
                    totalPorcentajeRecalculo += (decimal)rx.CantidadPor;
                }
            }

            //Recalcula cantidades segun la formua solo para los items con recalculo
            var nuevoKgCalculoFormula = KgFinales - totalFusionRepro - totalKgSinRecalculo;
            foreach (var item in conRecalculo)
            {
                if (totalPorcentajeRecalculo == 0)
                {
                    item.CantidadKGReal = 0;
                    item.CantidadKG = 0;
                }
                else
                {
                    var newPorcentaje = (decimal)item.CantidadPor.Value / totalPorcentajeRecalculo;
                    item.CantidadKGReal = decimal.Round(newPorcentaje * nuevoKgCalculoFormula, 4);
                    item.CantidadKG = decimal.Round(newPorcentaje * nuevoKgCalculoFormula, 4);
                }
            }


            var calculoBase = listaSinContainers.Where(c => c.Recalculo == false && c.Added == false).ToList();
            foreach (var item in calculoBase)
            {
                if (item.CantidadBase == null)
                    item.CantidadBase = 0;
                totalBase += item.CantidadBase.Value;
            }

            ////*** Calculo de Sumarizacion
            //decimal kgFormula = 0;
            //decimal kgFabricar = 0;
            //decimal porFormula = 0;
            //int i = 1;
            //foreach (var item in _lst.Where(c => c.idItemFormula != 999))
            //{
            //    kgFabricar += item.CantidadKG.Value;
            //    kgFormula += item.CantidadBase.Value;
            //    porFormula += item.CantidadPor.Value;
            //    item.idItemFormula = i; //Fix ID CostItems
            //    i++;
            //}

            //Actualizacion de Datos Sumarizados '999'
            var lineaTotales = _lst.Where(c => c.idItemFormula == 999).ToList();
            if (lineaTotales.Any() == false)
            {
                _lst.Add(new T0072_FORMULA_TEMP()
                {
                    idItemFormula = 999,
                    Primario = "TOTAL >>",
                    CantidadKG = Decimal.Round((KgFinales), 2),
                    CantidadBase = Decimal.Round(totalBase, 2),
                    CantidadPor = Decimal.Round(1, 2),
                });
            }
            else
            {
                lineaTotales[0].CantidadKG = Decimal.Round(KgFinales, 2);
                lineaTotales[0].CantidadBase = Decimal.Round(totalBase, 2);
                lineaTotales[0].CantidadPor = Decimal.Round(1, 2);
            }
            t0072FORMULATEMPBindingSource1.DataSource = _lst.OrderBy(c => c.idItemFormula).ToList();
            FormatoDgvFormula();
            dgvFormula.ClearSelection();
        }





        private void RecalculaDatosDgvFormula(bool reGetFormula = true)
        {
            if (reGetFormula)
                _lst = OrdenFabricacionBOMManager.GetFormulaOrdenFabricacion(_numeroOF);

            decimal totalFusionRepro = 0;
            decimal totalConRecalculo = 0;
            decimal totalKgSinRecalculo = 0;
            decimal totalContainers = 0;        //Materiales con 'B'
            decimal totalPorcentajeRecalculo = 0;
            decimal totalBase = 0;

            var listaContainer = _lst.Where(c => c.Primario.StartsWith("B")).ToList();
            foreach (var item in listaContainer)
            {
                if (item.CantidadKG == null)
                    item.CantidadKG = 0;
                totalContainers += item.CantidadKG.Value;
            }

            var listaSinContainers = _lst.Where(c => c.Primario.ToUpper().StartsWith("B") == false).ToList();
            var ztotales = listaSinContainers.Find(c => c.idItemFormula == 999);
            listaSinContainers.Remove(ztotales);
            //Cheque Elementos Fusion/Repro
            var repro = listaSinContainers.Where(c => c.Repro && c.Added).ToList();
            if (repro.Count > 0)
            {
                foreach (var fx in repro)
                {
                    totalFusionRepro += (decimal)fx.CantidadKG;
                }
            }

            //Chequeo Elementos SIN RECALCULO
            var sinRecalculo = listaSinContainers.Where(c => c.Recalculo && c.Repro == false).ToList();
            if (sinRecalculo.Count > 0)
            {
                foreach (var srecx in sinRecalculo)
                {
                    totalKgSinRecalculo += (decimal)srecx.CantidadKG;
                }
            }

            //Chequeo Elementos Agregados con Recalculo de Formula
            var conRecalculo = listaSinContainers.Where(c => c.Recalculo == false).ToList();
            if (conRecalculo.Count > 0)
            {
                foreach (var rx in conRecalculo)
                {
                    totalConRecalculo += (decimal)rx.CantidadKG;
                    totalPorcentajeRecalculo += (decimal)rx.CantidadPor;
                }
            }

            //Recalcula cantidades segun la formua solo para los items con recalculo
            var nuevoKgCalculoFormula = KgFabricarNew - totalFusionRepro - totalKgSinRecalculo;
            foreach (var item in conRecalculo)
            {
                if (totalPorcentajeRecalculo == 0)
                {
                    item.CantidadKGReal = 0;
                    item.CantidadKG = 0;
                }
                else
                {
                    var newPorcentaje = (decimal)item.CantidadPor.Value / totalPorcentajeRecalculo;
                    item.CantidadKGReal = decimal.Round(newPorcentaje * nuevoKgCalculoFormula, 4);
                    item.CantidadKG = decimal.Round(newPorcentaje * nuevoKgCalculoFormula, 4);
                }
            }


            var calculoBase = listaSinContainers.Where(c => c.Recalculo == false && c.Added == false).ToList();
            foreach (var item in calculoBase)
            {
                if (item.CantidadBase == null)
                    item.CantidadBase = 0;
                totalBase += item.CantidadBase.Value;
            }

            ////*** Calculo de Sumarizacion
            //decimal kgFormula = 0;
            //decimal kgFabricar = 0;
            //decimal porFormula = 0;
            //int i = 1;
            //foreach (var item in _lst.Where(c => c.idItemFormula != 999))
            //{
            //    kgFabricar += item.CantidadKG.Value;
            //    kgFormula += item.CantidadBase.Value;
            //    porFormula += item.CantidadPor.Value;
            //    item.idItemFormula = i; //Fix ID CostItems
            //    i++;
            //}

            //Actualizacion de Datos Sumarizados '999'
            var lineaTotales = _lst.Where(c => c.idItemFormula == 999).ToList();
            if (lineaTotales.Any() == false)
            {
                _lst.Add(new T0072_FORMULA_TEMP()
                {
                    idItemFormula = 999,
                    Primario = "TOTAL >>",
                    CantidadKG = Decimal.Round((KgFabricarNew - totalFusionRepro - totalKgSinRecalculo), 2),
                    CantidadBase = Decimal.Round(totalBase, 2),
                    CantidadPor = Decimal.Round(1, 2),
                });
            }
            else
            {
                lineaTotales[0].CantidadKG = Decimal.Round(KgFabricarNew, 2);
                lineaTotales[0].CantidadBase = Decimal.Round(totalBase, 2);
                lineaTotales[0].CantidadPor = Decimal.Round(1, 2);
            }
            t0072FORMULATEMPBindingSource1.DataSource = _lst.OrderBy(c => c.idItemFormula).ToList();
            FormatoDgvFormula();
            dgvFormula.ClearSelection();
        }
        private void RecalculaDatosDgvPrint()
        {
            new OrdenFabricacionBOMManager().ManageFormulaOfprint(_numeroOF, _lst, CantidadBatches, ckAgruparMP.Checked);
            FormatoDgvPrint();
            dgvFormulaImprimir.ClearSelection();
        }
        private void FormatoDgvFormula()
        {
            for (var i = 0; i < dgvFormula.Rows.Count; i++)
            {
                var idLinea = Convert.ToInt32(dgvFormula.Rows[i].Cells[__idItemFormula.Name].Value);
                if (idLinea < 999)
                {
                    //Si Item es Recalculo >
                    dgvFormula.Rows[i].Cells[__Recalculo.Name].Style.BackColor =
                        (bool)dgvFormula.Rows[i].Cells[__Recalculo.Name].Value == true ? Color.Red : Color.White;

                    //Si el Item fue Agregado Manualmente
                    dgvFormula.Rows[i].Cells[__Added.Name].Style.BackColor =
                        (bool)dgvFormula.Rows[i].Cells[__Added.Name].Value == true ? Color.MediumSeaGreen : Color.White;

                    //Si el Item es Fusion Material
                    dgvFormula.Rows[i].Cells[__Repro.Name].Style.BackColor =
                        (bool)dgvFormula.Rows[i].Cells[__Repro.Name].Value == true ? Color.MediumSeaGreen : Color.White;


                    //Si el Valor Pesada ==0
                    dgvFormula.Rows[i].Cells[__formPesada.Name].Style.BackColor =
                        Convert.ToDecimal(dgvFormula.Rows[i].Cells[__formPesada.Name].Value) == 0
                            ? Color.LightPink
                            : Color.White;


                    dgvFormula.Rows[i].Cells[__stkProduccion.Name].Style.BackColor =
                      Convert.ToDecimal(dgvFormula.Rows[i].Cells[__stkProduccion.Name].Value) == 0
                          ? Color.LightPink
                          : Color.LightGreen;


                    //Si es Container
                    if (dgvFormula.Rows[i].Cells[__material.Name].Value.ToString().StartsWith("B"))
                    {
                        dgvFormula.Rows[i].Cells[0].Style.BackColor = Color.Gold;
                        dgvFormula.Rows[i].Cells[1].Style.BackColor = Color.Gold;
                        dgvFormula.Rows[i].Cells[2].Style.BackColor = Color.Gold;
                        dgvFormula.Rows[i].Cells[3].Style.BackColor = Color.Gold;
                    }
                }
                else
                {
                    //Formato a Linea Footer de Total
                    for (var j = 0; j < dgvFormula.Columns.Count; j++)
                    {
                        dgvFormula.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        dgvFormula.Rows[i].Cells[j].Style.ForeColor = Color.DarkBlue;
                    }
                }
            }
        }
        private void FormatoDgvPrint()
        {
            var lstPrint = new OrdenFabricacionBOMManager().GetFormulaOrdenFabricacionPrint(_numeroOF);

            //Sumariza
            decimal kgPesada = 0;
            decimal porFormula = 0;
            var tieneTotal = false;

            foreach (var item in lstPrint)
            {
                kgPesada += item.CantidadKG.Value;
                porFormula += item.CantidadPor.Value;
                if (item.idItemFormula == 999)
                    tieneTotal = true;
            }

            if (!tieneTotal)
            {
                lstPrint.Add(new T0073_FORMULA_PRINT()
                {
                    Primario = "TOTAL x BATCH >>",
                    CantidadKG = Decimal.Round(kgPesada, 2),
                    DISP_UNIT = "KG",
                    CantidadPor = Decimal.Round(porFormula, 2),
                    idItemFormula = 999,
                });
            }
            else
            {
                var lineaTotal = lstPrint.Find(c => c.idItemFormula == 999);
                lineaTotal.DISP_VALUE = Decimal.Round(kgPesada, 2);
                lineaTotal.CantidadPor = Decimal.Round(porFormula, 2);
            }

            t0073FORMULAPRINTBindingSource1.DataSource = lstPrint;

            for (var i = 0; i < dgvFormulaImprimir.Rows.Count - 1; i++)
            {

                if (dgvFormulaImprimir.Rows[i].Cells[_1Unit.Name].Value.ToString() == "KG")
                {
                    dgvFormulaImprimir.Rows[i].Cells[_1Unit.Name].Style.BackColor = Color.LightBlue;
                }
                else
                {
                    dgvFormulaImprimir.Rows[i].Cells[_1Unit.Name].Style.BackColor = Color.LightGreen;
                }
            }

            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[0].Style.BackColor = Color.LightPink;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[0].Style.ForeColor = Color.Blue;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[1].Style.BackColor = Color.LightPink;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Blue;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[2].Style.BackColor = Color.LightPink;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[2].Style.ForeColor = Color.Blue;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[3].Style.BackColor = Color.LightPink;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[3].Style.ForeColor = Color.Blue;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[4].Style.BackColor = Color.LightPink;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[4].Style.ForeColor = Color.Blue;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[5].Style.BackColor = Color.LightPink;
            dgvFormulaImprimir.Rows[dgvFormulaImprimir.Rows.Count - 1].Cells[5].Style.ForeColor = Color.Blue;
            dgvFormulaImprimir.ClearSelection();

        }
        private void txtKgItemNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtKgItemNuevo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdItemSeleccionado.Text))
                return;

            var idItem = Convert.ToInt32(txtIdItemSeleccionado.Text);

            if (string.IsNullOrEmpty(txtKgItemNuevo.Text))
                txtKgItemNuevo.Text = 0.ToString("N2");

            var kgChange = Convert.ToDecimal(txtKgItemNuevo.Text);

            if (idItem == 999)
            {
                //Linea de Total
                if (kgChange > 0)
                {
                    txtKgAFabricar.Text = kgChange.ToString("N2");
                    txtKgFabricarNew.Text = txtKgAFabricar.Text;
                    RecalcFormAlCambiarKgFabricarFinal();
                    KgFabricarNew = kgChange;
                    //new OrdenFabricacionBOMManager().CalculaBatchSize(_numeroOF, decimal.Round(kgChange, 2));
                }
            }
            else
            {
                //Linea de Item
                var lx = _lst.Find(c => c.idItemFormula == idItem);
                lx.CantidadKGReal = kgChange;
                lx.CantidadKG = kgChange;
                if (kgChange == 0)
                {
                    MessageBox.Show(
                        @"Esta linea no sera considerada para ningun recalculo de formula. Para reconsiderar el recalculo coloque un valor cualquiera y luego modifique el total a fabricar",
                        @"Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (lx.Added == false)
                    {
                        //Si el material no fue agregado signfica que el recalculo siempre es '0/false' (normal)
                        //por lo tanto lo setea a '1' (sin recalculo)
                        lx.Recalculo = true;
                    }
                    else
                    {
                        //Si el material habia sido agregado manualmente y se le setea 0 Kg seria 
                        //conveniente eliminarlo. - 
                        MessageBox.Show(@"Elimine el material en vez de setear 0Kg");
                    }
                }
                else
                {
                    if (lx.Added == false)
                    {
                        //Si el material no fue agregado manualmente setea el recalculo a false (normal)
                        //por si antes habia sido modificado a true con kg=0
                        lx.Recalculo = false;
                    }
                }

                RecalculaFormulaAfterAddedItems(true);
                RecalculaDatosDgvFormula(false);
            }


            if (Convert.ToDecimal(txtTamañoBatch.Text) == 0)
            {
                //Si el tamaño del batch =0 >> Define 1 batch del total a fabricar
                CantidadBatches = 1;
                BatchSize = KgFabricarNew;
            }
            else
            {
                if (CantidadBatches <= 0)
                    CantidadBatches = 1;

                BatchSize = KgFabricarNew / CantidadBatches;
            }
            lblCantidadBatches.Text = CantidadBatches.ToString();
            txtTamañoBatch.Text = BatchSize.ToString("N2");
            txtNumeroBatches.Text = CantidadBatches.ToString("N0");
            txtKgAFabricar.Text = KgFabricarNew.ToString("N2");
            RecalculaDatosDgvPrint();
        }
        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvStock[e.ColumnIndex, e.RowIndex].Value.ToString();

                switch (cellValue)
                {
                    case "ES":


                        //MessageBox.Show(@"Este boton se encuentra momentaneamente fuera de servicio",
                        //     "Boton no programado aun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
                MessageBox.Show(cellValue.ToString());
            }
        }
        private void txtTamañoBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtNumeroBatches_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtNumeroBatches_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroBatches.Text))
            {
                txtNumeroBatches.Text = @"1";
            }
            CantidadBatches = Convert.ToInt32(txtNumeroBatches.Text);
            if (CantidadBatches <= 0)
            {
                toolTip1.ToolTipTitle = "Error en Cantidad de Batches";
                toolTip1.Show("La Cantidad de Batches a Fabricar debe ser mayor o igual a 1", txtNumeroBatches, txtNumeroBatches.Location, 5000);
                e.Cancel = true;
                return;
            }

            txtTamañoBatch.Text = (KgFabricarNew / CantidadBatches).ToString("N2");
            lblCantidadBatches.Text = txtNumeroBatches.Text;

            txtItemSeleccionado.Text = null;
            txtIdItemSeleccionado.Text = null;
            txtKgItemNuevo.Text = null;
            txtKgItemFormula.Text = null;
            new OrdenFabricacionBOMManager().ManageFormulaOfprint(_numeroOF, _lst, CantidadBatches, ckAgruparMP.Checked);
            FormatoDgvPrint();
        }
        private void txtTamañoBatch_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTamañoBatch.Text))
            {
                txtTamañoBatch.Text = @"1";
            }

            BatchSize = Convert.ToDecimal(txtTamañoBatch.Text);
            if (BatchSize <= 0)
            {
                toolTip1.ToolTipTitle = "Error en el Tamaño del Batch";
                toolTip1.Show("El Tamaño del Batch no puede ser menor o igual a 0Kg (Es el tamaño en Kg de cada 'Pesada'", txtNumeroBatches, txtNumeroBatches.Location, 5000);
                e.Cancel = true;
                return;
            }
            KgFabricarNew = BatchSize * CantidadBatches;

            txtKgAFabricar.Text = KgFabricarNew.ToString("N2");
            txtKgFabricarNew.Text = txtKgAFabricar.Text;
            RecalcFormAlCambiarKgFabricarFinal();





            //new OrdenFabricacionBOMManager().CalculaBatchSize(_numeroOF, KgFabricarNew, _autoReserve);
            //txtKgAFabricar.Text = KgFabricarNew.ToString("N2");
            //txtKgFabricarNew.Text = KgFabricarNew.ToString("N2");
            RecalculaDatosDgvFormula(false);

            txtItemSeleccionado.Text = null;
            txtIdItemSeleccionado.Text = null;
            txtKgItemNuevo.Text = null;
            txtKgItemFormula.Text = null;
            new OrdenFabricacionBOMManager().ManageFormulaOfprint(_numeroOF, _lst, CantidadBatches);
            FormatoDgvPrint();
        }

        #region Botones
        private void btnBorrarLotesAsignados_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Confirma que desea borrar la Asignacion de todos los LOTES reservados para esta OF?", @"Confirmacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            new ReservaStockOF().LiberaStockReservadoOF(_numeroOF, true);
            RecalculaDatosDgvFormula();
            FormatoDgvPrint();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            KgFabricarNew = Convert.ToDecimal(txtKgAFabricar.Text);
            CantidadBatches = Convert.ToInt32(txtNumeroBatches.Text);
            BatchSize = KgFabricarNew / CantidadBatches;

            new PlanProduccionManager().SetBatchSizeData(_numeroOF, KgFabricarNew, CantidadBatches);
            new OrdenFabricacionBOMManager().UpdateT0072(_numeroOF, _lst.Where(c => c.idItemFormula < 900).ToList());
            //actualizar la info a T0072


            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                @"Desea Cancelar las modificaciones realizadas?" + Environment.NewLine +
                @"Los Lotes Reservados o Liberados se encuentran actualizados", @"Cancelacion", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnRecalculaStockPlanta_Click(object sender, EventArgs e)
        {

            foreach (var item in _lst)
            {
                item.STKLiberado = new StockList().GetKgStockDisponibleProduccion(item.Primario, Planta);
                item.STKTotal = StockList.GetKgStockTotalByMaterial(item.Primario, Planta);
            }
            RecalculaDatosDgvFormula(false);
            RecalculaDatosDgvPrint();
        }
        private void btnAgregarMaterialExtra_Click(object sender, EventArgs e)
        {
            using (var f = new FrmPP14AgregarMaterialPF(_numeroOF, _lst))
            {
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    RecalculaFormulaAfterAddedItems();
                }
                else
                {
                    //remueve si hubo elemento agregado (item==800)
                    var lstX = _lst.Find(c => c.idItemFormula == 800);
                    _lst.Remove(lstX);
                }

                RecalculaDatosDgvFormula(false);
                RecalculaDatosDgvPrint();
                return;
            }
        }
        private void btnPrintPesada_Click(object sender, EventArgs e)
        {
            var resp =
                MessageBox.Show(
                    @"Antes de Imprimir la formula se guardarán los cambios de KG a Fabricar, Cantidad de Batches y Tamaño del Batch. Desea continuar?",
                    @"Desea Guardar los Datos?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            KgFabricarNew = Convert.ToDecimal(txtKgAFabricar.Text);
            CantidadBatches = Convert.ToInt32(txtNumeroBatches.Text);
            BatchSize = KgFabricarNew / CantidadBatches;

            new PlanProduccionManager().SetBatchSizeData(_numeroOF, KgFabricarNew, CantidadBatches);
            new OrdenFabricacionBOMManager().UpdateT0072(_numeroOF, _lst.Where(c => c.idItemFormula < 900).ToList());

            var f2 = new RpvOrdenFabricacion(_numeroOF);
            f2.Show();
        }

        #endregion

        private void ckAgruparMP_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAgruparMP.Checked)
            {

            }
            else
            {

            }
        }


        private void RecalculaFormulaAfterAddedItems(bool cantidadFabricarFija = false)
        {
            decimal totalFusionRepro = 0; //Total de KG Fusion/Repro para descontar de calculo de Formula
            decimal totalConRecalculo = 0;
            decimal totalKgSinRecalculo = 0;
#pragma warning disable CS0219 // The variable 'totalContainers' is assigned but its value is never used
            decimal totalContainers = 0;        //Materiales con 'B'
#pragma warning restore CS0219 // The variable 'totalContainers' is assigned but its value is never used
            decimal totalPorcentajeRecalculo = 0;

            //Elimina los containers (comienzan con B)
            var listaSinContainers = _lst.Where(c => c.Primario.ToUpper().StartsWith("B") == false).ToList();
            var ztotales = listaSinContainers.Find(c => c.idItemFormula == 999);
            //Elimina los totales (item 999)
            listaSinContainers.Remove(ztotales);
            //Chequea Elementos Fusion/Repro y sumariza KG
            var repro = listaSinContainers.Where(c => c.Repro && c.Added).ToList();
            if (repro.Count > 0)
            {
                foreach (var fx in repro)
                {
                    totalFusionRepro += (decimal)fx.CantidadKGReal;
                }
            }

            //Chequeo Elementos SIN RECALCULO
            var sinRecalculo = listaSinContainers.Where(c => c.Recalculo && c.Repro == false).ToList();
            if (sinRecalculo.Count > 0)
            {
                foreach (var srecx in sinRecalculo)
                {
                    totalKgSinRecalculo += (decimal)srecx.CantidadKGReal;
                }
            }

            //Chequeo Elementos Agregados con Recalculo de Formula
            var conRecalculo = listaSinContainers.Where(c => c.Recalculo == false).ToList();
            if (conRecalculo.Count > 0)
            {
                foreach (var rx in conRecalculo)
                {
                    totalConRecalculo += (decimal)rx.CantidadKGReal;
                    totalPorcentajeRecalculo += (decimal)rx.CantidadPor;
                }
            }

            decimal nuevoKgCalculoFormula = 0;

            if (cantidadFabricarFija)
            {
                nuevoKgCalculoFormula = totalConRecalculo;
                KgFabricarNew = nuevoKgCalculoFormula + totalFusionRepro + totalKgSinRecalculo;
            }
            else
            {
                nuevoKgCalculoFormula = KgFabricarNew - totalFusionRepro - totalKgSinRecalculo;
            }


            foreach (var item in conRecalculo)
            {
                if (totalPorcentajeRecalculo == 0)
                {
                    item.CantidadKGReal = 0;
                    item.CantidadKG = 0;
                }
                else
                {
                    if (item.CantidadKG == 0)
                    {

                    }
                    else
                    {
                        var newPorcentaje = (decimal)item.CantidadPor.Value / totalPorcentajeRecalculo;
                        item.CantidadKGReal = decimal.Round(newPorcentaje * nuevoKgCalculoFormula, 4);
                        item.CantidadKG = decimal.Round(newPorcentaje * nuevoKgCalculoFormula, 4);
                    }


                }
            }
            txtKgFabricarNew.Text = KgFabricarNew.ToString("N2");

        }

    }
}
