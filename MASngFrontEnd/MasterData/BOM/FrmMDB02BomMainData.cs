using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.DataFix;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.MasterData.BOM;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace MASngFE.MasterData.BOM
{
    //Por una decision de diseño se movio el campo 'NEL' y el campo 'DESARROLLADO PARA' a la tabla materiales (T0010)
    //ya que las alternativas de las formulas no seran linkeadas a un NEL o a un cliente especifico para 
    //evitar versiones diferentes de un material para diferentes clientes.
    //todo Remover campo DESARROLLADO, NEL, COLOR de tabla T0020
    //

    public partial class FrmMdb02BomMainData : Form
    {
        //Constructor para CREACION de nueva BOM
        public FrmMdb02BomMainData(string materialFabricar)
        {
            _modo = 1;
            _idFormula = 0;
            _materialFabricar = materialFabricar;
            InitializeComponent();
            txtAlternativaFormula.Text = GetNextAlternativeLetter();
        }

        //Constructor para modo es para 2.3
        public FrmMdb02BomMainData(int modo, int idFormula = 0)
        {
            _modo = modo == 0 ? 2 : modo;
            _idFormula = idFormula;
            _materialFabricar = null;
            InitializeComponent();
        }

        //Nuevo Constructor para creacion automatica de formula MODO=4
        public FrmMdb02BomMainData(string materialFabricar, List<BomItemsStructure> items)
        {
            _modo = 4;
            _idFormula = 0;
            _materialFabricar = materialFabricar;
            _formulaItems = items;
            InitializeComponent();
        }
        //---------------------------------------------------------------------------------------------------------
        private int _modo;
        private int _idFormula;
        private string _materialFabricar;
        private List<T0010_MATERIALES> _listaMP = new List<T0010_MATERIALES>();
#pragma warning disable CS0414 // The field 'FrmMdb02BomMainData._formulaIsOK' is assigned but its value is never used
        private bool _formulaIsOK = false;
#pragma warning restore CS0414 // The field 'FrmMdb02BomMainData._formulaIsOK' is assigned but its value is never used
        private List<T0020_FORMULA_H> _listaFormulas = new List<T0020_FORMULA_H>();
        private string _versionFormulaOri;
        private List<BomItemsStructure> _formulaItems = new List<BomItemsStructure>(); //Para Modo=4

        //---------------------------------------------------------------------------------------------------------
        private void FrmBomMain_Load(object sender, EventArgs e)
        {
            txtModo.Text = _modo.ToString();
            if (_materialFabricar == null)
            {
                MapBomHeaderData();
            }

            if (FixNelDesarrolladoParaBOM.Fix(_materialFabricar))
            {
                MessageBox.Show(
                    @"Debido a un cambio de diseño la informacion de NEL y DESARROLLADO PARA ya no depende de la formula sino que esta linkeada al material para evitar versiones dependientes de un cliente. Esta modificacion se ha podido realizar correctamente en forma automatica",
                    @"Fix Automatico de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadMasterDataInfo();
            ConfiguraBotonesAnteriorProximo();
            ConfiguraInitialData();
            ConfiguraSegunModo();
        }
        private void MapBomHeaderData()
        {
            var bd = new BOMManager().GetFormulaHeader(_idFormula);
            txtNumeroFormula.Text = bd.ID_FORMULA.ToString();
            _materialFabricar = bd.IDMATERIAL;
            txtCantidadAltarnativasTotales.Text = new BOMManager().GetNumberOfBOM(_materialFabricar, false).ToString();
            txtAlternativasActivas.Text = new BOMManager().GetNumberOfBOM(_materialFabricar, true).ToString();
            txtAlternativaFormula.Text = bd.FORM_VERSION;
            txtEstadoFormula.Text = bd.STATUS;
            if (bd.ACTIVA == null)
                bd.ACTIVA = false;

            ckActiva.Checked = bd.ACTIVA.Value;
            ckFlagForDeletion.Checked = bd.F4D;
            if (ckFlagForDeletion.Checked)
            {
                MessageBox.Show(@"Atencion la formula esta marcada para ser elminada", @"Formula Flagged for Deletion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ckFlagForDeletion.BackColor = Color.OrangeRed;
            }
            txtDescripcionFormula.Text = bd.DESC_FORMULA;
            txtDureza.Text = bd.Dureza.ToString();
            txtIndicacionesFabricacion.Text = bd.IndicacionFabricacion;
            txtMezclado.Text = bd.TiempoMezclado.ToString();

            if (string.IsNullOrEmpty(bd.USER))
                bd.USER = GlobalApp.AppUsername + @"*";

            if (bd.FORM_FECHA == null)
            {
                bd.FORM_FECHA = DateTime.Today;
                txtLogFechaCreacion.Text = bd.USER + @"*";
                MessageBox.Show(
                    @"Atencion se ha completado automaticamente la fecha de creacion a 'HOY' debido a que esta informacion no estaba presente",
                    @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtLogUserCreacion.Text = bd.USER;
            }
            txtLogFechaCreacion.Text = bd.FORM_FECHA.Value.ToString("g");

            if (bd.LastUsed != null)
                txtUltimaUtilizacion.Text = bd.LastUsed.Value.ToString("g");

            txtPlanInspeccion.Text = bd.PlanInspeccion;
            txtMasterRecipe.Text = bd.MasterRecipe;
            txtNotasQA.Text = bd.NotasQA;

            ckActiva.BackColor = ckActiva.Checked ? Color.GreenYellow : Color.OrangeRed;
            labelFormulaActiva.BackColor = ckActiva.Checked ? Color.GreenYellow : Color.OrangeRed;

            if (bd.FControlFecha != null)
            {
                txtFechaValidacion.Text = bd.FControlFecha.Value.ToString("d");
            }
            if (bd.FControloda == null)
                bd.FControloda = false;

            ckFormulaValidada.Checked = bd.FControloda.Value;
            txtResponValidacion.Text = bd.FControlResp;

            txtLogUserUpdate.Text = bd.LogUpdatedBy;
            if (bd.FORM_MODIF != null)
                txtLogFechaUpdate.Text = bd.FORM_MODIF.Value.ToString("g");

        }
        private void LoadMasterDataInfo()
        {
            var md = new MaterialMasterManager().GetPrimarioInfo(_materialFabricar);
            txtPrimario.Text = md.IDMATERIAL;
            txtColor.Text = md.COLOR;
            txtBase.Text = md.COMPUESTO_BASE;
            txtDescripcionTecnica.Text = md.DescripcionTecnicaLab;
            txtTipoMaterial.Text = md.TIPO_MATERIAL;
            var mt = new MaterialTypeManager().GetMtype(md.TIPO_MATERIAL);
            txtDescripcionTipo.Text = mt.Descripcion;
            if (md.NEL != null)
            {
                txtNEL.Text = md.NEL.ToString();
                txtNEL.BackColor = Color.LightGreen;
                txtNEL.ReadOnly = true;
            }
            else
            {
                txtNEL.ReadOnly = false;
            }
            txtDesarrolladoPara.Text = md.DesarrolladoPara;
            _listaFormulas = new BOMManager().GetListFormulasFromMaterial(_materialFabricar, false);

        }
        private void ConfiguraBotonesAnteriorProximo()
        {
            btnFormProxima.Enabled = false;
            btnFormulaPrevia.Enabled = false;

            if (_modo == 1)
                return;

            if (_modo == 4)
                return;

            if (_modo == 5)
                return;


            if (_listaFormulas.Count == 0)
                return;

            var index0 = _listaFormulas.FindIndex(c => c.ID_FORMULA == _idFormula);
            if (index0 > 0)
                btnFormulaPrevia.Enabled = true;

            if (index0 < (_listaFormulas.Count - 1))
                btnFormProxima.Enabled = true;

        }
        private void ConfiguraInitialData()
        {

        }
        private void ConfiguraSegunModo()
        {
            REMOVE.Visible = true;
            btnGuardar.Enabled = false;
            panelDatosFormula.Enabled = true;
            switch (_modo)
            {
                case 1:
                    _listaMP = new MaterialMasterManager().GetCompleteListofMaterial(true).ToList();
                    bindingSource1.DataSource = _listaMP;
                    btnGuardar.Enabled = true;
                    ConfiguraComboDgv();
                    break;
                case 2:
                    _listaMP = new MaterialMasterManager().GetCompleteListofMaterial(true).ToList();
                    bindingSource1.DataSource = _listaMP;
                    btnGuardar.Enabled = true;

                    bomItemsStructureBindingSource.DataSource = new BomItemStructure().GetFormulaItems(_idFormula);
                    LoadFormulaData();
                    break;
                case 3:

                    bomItemsStructureBindingSource.DataSource = new BomItemStructure().GetFormulaItems(_idFormula);
                    LoadFormulaData();
                    dgvFormulaItems.AllowUserToAddRows = false;
                    dgvFormulaItems.ReadOnly = true;
                    REMOVE.Visible = false;
                    panelDatosFormula.Enabled = false;
                    break;
                case 4:
                    //se comporta en principio como modo=1
                    _listaMP = new MaterialMasterManager().GetCompleteListofMaterial(true).ToList();
                    bindingSource1.DataSource = _listaMP;
                    bomItemsStructureBindingSource.DataSource = _formulaItems;
                    LoadFormulaData();
                    btnGuardar.Enabled = true;
                    btnFlag4Deletion.Enabled = false;
                    btnAddNewAlternative.Enabled = false;
                    BtnDuplicarBom.Enabled = false;
                    ConfiguraComboDgv();
                    break;
                case 5:
                    //se comporta en principio como modo=1
                    _listaMP = new MaterialMasterManager().GetCompleteListofMaterial(true).ToList();
                    bindingSource1.DataSource = _listaMP;
                    btnGuardar.Enabled = true;
                    ConfiguraComboDgv();
                    break;
            }
        }
        private void LoadFormulaData()
        {
            decimal qty = 0;
            decimal por = 0;
            foreach (DataGridViewRow row in dgvFormulaItems.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    //if (decimal.TryParse(row.Cells[3].Value.ToString(), out result))
                    {
                        //row.Cells[4].Value = result / qty; //Coloca el %
                        //por += Convert.ToDecimal(row.Cells[4].Value);
                        qty += Convert.ToDecimal(row.Cells[3].Value);
                        por += Convert.ToDecimal(row.Cells[4].Value);
                    }
                }
            }
            txtZPorcentaje.Text = por.ToString("P2");
            txtZCantidad.Text = qty.ToString("N3");
            txtZCantidad.BackColor = Color.GreenYellow;
            txtZPorcentaje.BackColor = Color.GreenYellow;
            _formulaIsOK = true;
        }

        private void dgvFormulaItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvFormulaItems[e.ColumnIndex, e.RowIndex].Value.ToString();
                switch (cellValue)
                {
                    case "BORRAR":
                        var respuesta = MessageBox.Show(@"Desea remover este item de la formula?", @"Remover Item",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (respuesta == DialogResult.Yes)
                            dgvFormulaItems.Rows.RemoveAt(e.RowIndex);
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private bool ValidaDataHeaderIsComplete()
        {
            if (ckFlagForDeletion.Checked)
            {
                MessageBox.Show(@"No puede guardarse cambios de una formula marcada para borrado",
                    @"Formula Marcada para borrado", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            txtAlternativaFormula.ReadOnly = true;
            ep.Clear();
            if (string.IsNullOrEmpty(txtAlternativaFormula.Text))
            {
                txtAlternativaFormula.Text = GetNextAlternativeLetter();
                txtAlternativaFormula.ReadOnly = false;
            }

            if (string.IsNullOrEmpty(txtDescripcionFormula.Text))
            {
                MessageBox.Show(
                    @"Debe proveer una descripcion que identifique a esta version de formula. Si es la primer version puede colocarse - 'Formula Standard'",
                    @"Descripcion Formula Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ep.SetError(txtDescripcionFormula, "Este campo no puede estar vacio");
                return false;
            }
            return true;
        }
        private string GetNextAlternativeLetter()
        {
            int unicode = 65; //[A]
            var act = new BOMManager().GetNumberOfBOM(_materialFabricar);
            int f = unicode + act;
            char character = (char)f;
            return character.ToString();
        }
        private T0020_FORMULA_H MapHeaderToStructure()
        {
            //Se movio desarrollado para > material
            //Se elimina color

            if (string.IsNullOrEmpty(txtDureza.Text))
                txtDureza.Text = 0.ToString();

            if (string.IsNullOrEmpty(txtMezclado.Text))
                txtMezclado.Text = 0.ToString();


            var dh = new T0020_FORMULA_H()
            {
                ID_FORMULA = _idFormula,
                ACTIVA = ckActiva.Checked,
                BATCH_SIZE = Convert.ToDecimal(txtZCantidad.Text),
                DESC_FORMULA = txtDescripcionFormula.Text,
                IDMATERIAL = _materialFabricar,
                FORM_VERSION = txtAlternativaFormula.Text,
                STATUS = txtEstadoFormula.Text,
                PlanInspeccion = txtPlanInspeccion.Text,
                NotasQA = txtNotasQA.Text,
                MasterRecipe = txtMasterRecipe.Text,
                Dureza = Convert.ToInt32(txtDureza.Text),
                TiempoMezclado = Convert.ToInt32(txtMezclado.Text),
                IndicacionFabricacion = txtIndicacionesFabricacion.Text,
                FControloda = ckFormulaValidada.Checked,
                LogUpdatedBy = txtLogUserUpdate.Text,
                USER = txtLogUserCreacion.Text,
                FControlResp = txtResponValidacion.Text,
            };

            if (string.IsNullOrEmpty(txtLogFechaCreacion.Text) == false)
                dh.FORM_FECHA = Convert.ToDateTime(txtLogFechaCreacion.Text);

            if (string.IsNullOrEmpty(txtLogFechaUpdate.Text) == false)
                dh.FORM_MODIF = Convert.ToDateTime(txtLogFechaUpdate.Text);

            if (string.IsNullOrEmpty(txtUltimaUtilizacion.Text) == false)
                dh.LastUsed = Convert.ToDateTime(txtUltimaUtilizacion.Text);

            if (string.IsNullOrEmpty(txtFechaValidacion.Text) == false)
                dh.FControlFecha = Convert.ToDateTime(txtFechaValidacion.Text);
            return dh;
        }
        private List<T0021_FORMULA_I> MapItemsToStructure()
        {
            var lst = new List<T0021_FORMULA_I>();
            foreach (DataGridViewRow row in dgvFormulaItems.Rows)
            {
                if ((row.Cells[0].Value) != null)
                {
                    var item = new T0021_FORMULA_I
                    {
                        FORMULA = _idFormula,
                        ID_ITEM = Convert.ToInt32(row.Cells[0].Value),
                        ITEM = row.Cells[1].Value.ToString(),
                        CANTIDAD = Convert.ToDecimal(row.Cells[3].Value),
                        CANTIDAD_PORC = Convert.ToDecimal(row.Cells[4].Value)
                    };
                    if (row.Cells[5].Value != null)
                    {
                        item.UNIDAD = row.Cells[5].Value.ToString();
                    }

                    if (row.Cells[6].Value != null)
                    {
                        item.Secuencia = Convert.ToInt32(row.Cells[6].Value);
                    }

                    lst.Add(item);
                }
            }
            return lst;
        }
        private void dgvFormulaItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }
        private void ConfiguraComboDgv()
        {
            // Add the events to listen for
            //dgvFormulaItems.CellValueChanged += new DataGridViewCellEventHandler(dgvFormulaItems_CellValueChanged);
            //  dgvFormulaItems.CurrentCellDirtyStateChanged +=new EventHandler(dgvFormulaItems_CurrentCellDirtyStateChanged);
        }
        private void CompletaDatosAfterMPUpdate()
        {
            decimal qty = 0;
#pragma warning disable CS0219 // The variable 'por' is assigned but its value is never used
            decimal por = 0;
#pragma warning restore CS0219 // The variable 'por' is assigned but its value is never used
            int iditem = 0;
            decimal result;
            foreach (DataGridViewRow row in dgvFormulaItems.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    if (decimal.TryParse(row.Cells[3].Value.ToString(), out result))
                    {
                        if (result <= 0)
                        {
                            row.Cells[3].Style.BackColor = Color.OrangeRed;
                        }
                        else
                        {
                            qty += Convert.ToDecimal(row.Cells[3].Value);
                            row.Cells[3].Style.BackColor = Color.GreenYellow;
                            {
                                if (row.Cells[0].Value == null)
                                {
                                    row.Cells[0].Value = 0;
                                }

                                //if (Convert.ToInt32(row.Cells[0].Value) ==0)
                                iditem = iditem + 10;
                                row.Cells[0].Value = iditem;
                            }
                        }
                    }
                    else
                    {
                        row.Cells[3].Style.BackColor = Color.OrangeRed;
                    }
                }
                else
                {
                    row.Cells[3].Style.BackColor = Color.OrangeRed;
                }
            }
            txtZCantidad.Text = qty.ToString("N3");
            if (qty > 0)
            {
                foreach (DataGridViewRow row in dgvFormulaItems.Rows)
                {
                    if (row.Cells[3].Value != null)
                    {
                        if (decimal.TryParse(row.Cells[3].Value.ToString(), out result))
                        {
                            row.Cells[4].Value = result / qty;
                        }
                    }
                }
            }
        }
        private bool CheckMateriaPrimaIsValid(string mp)
        {
            return _listaMP.Find(c => c.IDMATERIAL.ToUpper().Equals(mp.ToUpper())) != null;
        }
        private bool CheckQuantityIsValid(string qty)
        {
            return true;
        }
        private void dgvFormulaItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // My combobox column is the second one so I hard coded a 1, flavor to taste
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgvFormulaItems.Rows[e.RowIndex].Cells[1];
            if (cb.Value != null)
            {
                // do stuff

                var currentcell = dgvFormulaItems.CurrentCellAddress;
                //var sendingCB = sender as DataGridViewComboBoxEditingControl;
                DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)dgvFormulaItems.Rows[currentcell.Y].Cells[2];
                cel.Value = new MaterialMasterManager().GetPrimarioInfo(cb.Value.ToString()).MAT_DESC;

                dgvFormulaItems.Invalidate();
            }
        }
        private void dgvFormulaItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFormulaItems.CurrentCell.ColumnIndex == 3)
            {
                CompletaDatosAfterMPUpdate();
            }

            if (dgvFormulaItems.CurrentCell.ColumnIndex == 1 && _modo != 3)
            {
                if (dgvFormulaItems.CurrentCell.Value == null)
                    return;

                var currentcell = dgvFormulaItems.CurrentCellAddress;
                var primario = dgvFormulaItems[dgvFormulaItems.Columns[1].Index, e.RowIndex].Value;
                var x = _listaMP.Find(c => c.IDMATERIAL.ToUpper().Equals(primario.ToString().ToUpper()));
                if (x != null)
                {
                    dgvFormulaItems.Rows[currentcell.Y].Cells[currentcell.X].Style.BackColor = Color.LightGreen;
                    dgvFormulaItems.Rows[currentcell.Y].Cells[currentcell.X].Value =
                        dgvFormulaItems.Rows[currentcell.Y].Cells[currentcell.X].Value.ToString().ToUpper();
                    DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)dgvFormulaItems.Rows[currentcell.Y].Cells[2];
                    cel.Value = new MaterialMasterManager().GetPrimarioInfo(primario.ToString()).MAT_DESC;

                    var celUoM = (DataGridViewTextBoxCell)dgvFormulaItems.Rows[currentcell.Y].Cells[5];
                    celUoM.Value = new MaterialMasterManager().GetPrimarioInfo(primario.ToString()).UNIDAD;
                }
                else
                {
                    dgvFormulaItems.Rows[currentcell.Y].Cells[currentcell.X].Style.BackColor = Color.Red;
                    var respuesta = MessageBox.Show(
                        @"El Material ingresado no se ha podido validar" + Environment.NewLine +
                        @"Desea abrir la interfaz para seleccion de material?", @"Ingreso de Materia Prima",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        decimal qty = 0;
                        if (dgvFormulaItems[dgvFormulaItems.Columns[3].Index, e.RowIndex].Value != null)
                        {
                            qty = Convert.ToDecimal(dgvFormulaItems[dgvFormulaItems.Columns[3].Index, e.RowIndex].Value);
                        }

                        using (var f0 = new FrmBOMMaterialSelector(_modo, null, qty))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                //dgvFormulaItems.EditMode = DataGridViewEditMode.EditProgrammatically;
                                var materialCel = (DataGridViewTextBoxCell)dgvFormulaItems.Rows[currentcell.Y].Cells[1];
                                materialCel.Value = f0.Material;
                                //
                                var cel = (DataGridViewTextBoxCell)dgvFormulaItems.Rows[currentcell.Y].Cells[2];
                                cel.Value = new MaterialMasterManager().GetPrimarioInfo(materialCel.Value.ToString()).MAT_DESC;
                                //
                                var celUoM = (DataGridViewTextBoxCell)dgvFormulaItems.Rows[currentcell.Y].Cells[5];
                                celUoM.Value = new MaterialMasterManager().GetPrimarioInfo(materialCel.Value.ToString()).UNIDAD;
                                //
                                dgvFormulaItems.Rows[currentcell.Y].Cells[currentcell.X].Style.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }
        }
        private void dgvFormulaItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvFormulaItems.CurrentCell.ColumnIndex == 1 && _modo < 3)
            //{
            //    var currentcell = dgvFormulaItems.CurrentCellAddress;
            //    var primario = dgvFormulaItems[dgvFormulaItems.Columns[1].Index, e.RowIndex].Value == null ? null : dgvFormulaItems[dgvFormulaItems.Columns[1].Index, e.RowIndex].Value.ToString();
            //    decimal qty = 0;
            //    using (var f0 = new FrmBOMMaterialSelector(_modo,primario,qty))
            //    {
            //        DialogResult dr = f0.ShowDialog();
            //        if (dr == DialogResult.OK)
            //        {
            //            dgvFormulaItems.EditMode = DataGridViewEditMode.EditProgrammatically;
            //            DataGridViewTextBoxCell materialCel = (DataGridViewTextBoxCell)dgvFormulaItems.Rows[currentcell.Y].Cells[1];
            //            materialCel.Value = f0.Material;

            //            DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)dgvFormulaItems.Rows[currentcell.Y].Cells[2];
            //            cel.Value = new MaterialMasterManager().GetPrimarioInfo(materialCel.Value.ToString()).MAT_DESC;
            //            dgvFormulaItems.EndEdit();


            //            DataGridViewRow row = (DataGridViewRow) dgvFormulaItems.Rows[currentcell.Y].Clone();
            //            row.Cells[1].Value = f0.Material;
            //            row.Cells[2].Value = new MaterialMasterManager().GetPrimarioInfo(materialCel.Value.ToString()).MAT_DESC;
            //            //row.Cells["Column6"].Value = 50.2;
            //            dgvFormulaItems.Rows.Add(row);



            //            dgvFormulaItems.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
            //            dgvFormulaItems.AllowUserToAddRows = true;
            //            dgvFormulaItems.FirstDisplayedScrollingRowIndex = e.RowIndex;


            //        }
            //        else
            //        {

            //        }
            //    }



            //}
        }
        private void ckActiva_CheckedChanged(object sender, EventArgs e)
        {
            ckActiva.BackColor = ckActiva.Checked ? Color.GreenYellow : Color.OrangeRed;
            labelFormulaActiva.BackColor = ckActiva.Checked ? Color.GreenYellow : Color.OrangeRed;
        }

        //Botones
        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnFormulaPrevia_Click(object sender, EventArgs e)
        {
            var index0 = _listaFormulas.FindIndex(c => c.ID_FORMULA == _idFormula);
            var idnewFormula = _listaFormulas[index0 - 1];
            _idFormula = idnewFormula.ID_FORMULA;
            MapBomHeaderData();
            LoadFormulaData();
            ConfiguraBotonesAnteriorProximo();


        }
        private void btnFormProxima_Click(object sender, EventArgs e)
        {
            var index0 = _listaFormulas.FindIndex(c => c.ID_FORMULA == _idFormula);
            var idnewFormula = _listaFormulas[index0 + 1];
            _idFormula = idnewFormula.ID_FORMULA;
            MapBomHeaderData();
            LoadFormulaData();
            ConfiguraBotonesAnteriorProximo();
        }
        private void btnImprimirFormula_Click(object sender, EventArgs e)
        {
            var f = new RpvBOM(_idFormula);
            f.Show();
        }
        private void btnAddNewAlternative_Click(object sender, EventArgs e)
        {
            int unicode = 65; //[A]
            char character = (char)unicode;
            string text = character.ToString();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaDataHeaderIsComplete() == false)
                return;

            if (ValidarFormulaIsOk() == true)
            {
                if (_idFormula == 0)
                {
                    //Se esta creando una nueva ALTERNATIVA
                    var resp = MessageBox.Show($@"Confirma la CREACION de una NUEVA Alternativa #{txtAlternativaFormula.Text}?",
                        @"NUEVA ALTERNATIVA/VERSION DE FORMULA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.No)
                        return;

                    var check = new BOMManager().FormulaExistente(_materialFabricar, MapItemsToStructure());
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
                }
                else
                {
                    //Se esta modificando una ALTERNATIVA EXISTENTE
                    var resp = MessageBox.Show($@"Confirma la Modificacion/Actualizacion de la Alternativa #{txtAlternativaFormula.Text}?",
                        @"MODIFICACION DE FORMULA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.No)
                        return;

                    var flag = false;
                    var check = new BOMManager().FormulaExistente(_materialFabricar, MapItemsToStructure());
                    if (check != null)
                    {
                        foreach (var item in check)
                        {
                            if (item != _idFormula)
                            {
                                MessageBox.Show($@"Valide la Siguiente Alternativa# {item.ToString()} ya que la misma es duplicada a esta alternativa. No se pueden grabar los cambios!",
                                    @"Alternativa Duplicada!",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                flag = true;
                            }
                        }

                        if (flag == true)
                            return;

                        if (ckFormulaValidada.Checked)
                        {
                            MessageBox.Show(
                                @"Se ha eliminado la 'Validacion de Formula' debido al cambio realizado en la misma. Una vez aprobado el resultado 'Re-Valide' la formula nuevamente",
                                @"CANCELACION DE REVALIDACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var res = new BOMCreateUpdateManager().CleanBomRevalidation(_idFormula);
                            ckFormulaValidada.Checked = false;
                            txtFechaValidacion.Text = null;
                            txtResponValidacion.Text = null;
                            ckFormulaValidada.BackColor = Color.OrangeRed;
                        }
                    }
                }

                var bomHeader = MapHeaderToStructure();
                var result = new BOMCreateUpdateManager().CreateOrUpdateBOMHeader(bomHeader);
                if (result < 0)
                {
                    //Ocurrio algun error
                }
                else
                {
                    if (result == 0)
                    {
                        //No se actualizo header
                        MessageBox.Show(@"No se han encontrado datos para actualizar el Header de la Formula",
                            @"Actualizacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //Se creo header
                        if (_idFormula == 0)
                        {
                            MessageBox.Show(@"Se ha creado correctamente la NUEVA FORMULA/ALTERNATIVA",
                                @"Creacion Existosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(@"Se ha Actualizado correctamente la Alternativa de Formula",
                                @"Actualizacion Existosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _idFormula = result;
                        txtNumeroFormula.Text = result.ToString();
                        btnGuardar.Enabled = false;
                    }
                    var resultItems = new BOMCreateUpdateManager().CreateOrUpdateBOMItems(MapItemsToStructure());
                }
            }
            else
            {
                MessageBox.Show(
                    @"La Formula contiene errores (Ver datos en Rojo) que deben corregirse antes de continuar",
                    @"Formula Con Errores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void BtnValidarFormula_Click(object sender, EventArgs e)
        {
            var rx = MessageBox.Show(
                @"Desea VALIDAR esta formula? (Se completara responsable y fecha de hoy como fecha de VALIDACION)",
                @"Revalidacion de Formula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rx == DialogResult.No)
                return;

            var res = new BOMCreateUpdateManager().RevalidateBom(_idFormula);
            if (res)
            {
                MessageBox.Show(@"La Formula ha sido marcada como Re-Validada!", @"Revalidacion OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ckFormulaValidada.Checked = true;
                ckFormulaValidada.BackColor = Color.Green;
                txtResponValidacion.Text = Environment.UserName;
                txtFechaValidacion.Text = DateTime.Now.ToString("g");
            }
            else
            {
                MessageBox.Show(@"Error en la Re-Validacion de Formula!", @"Revalidacion Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnCleanRevalidation_Click(object sender, EventArgs e)
        {
            var rx = MessageBox.Show(
                @"Desea marcar la formula como NO VALIDADA?",
                @"Limpieza de Revalidacion de Formula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rx == DialogResult.No)
                return;

            var res = new BOMCreateUpdateManager().CleanBomRevalidation(_idFormula);
            if (res)
            {
                ckFormulaValidada.Checked = false;
                ckFormulaValidada.BackColor = Color.OrangeRed;
                txtFechaValidacion.Text = null;
                txtResponValidacion.Text = null;
                MessageBox.Show(@"La Formula ha sido marcada como NO Re-Validada!", @"Limpieza de Revalidacion OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Error en la Limpieza de Re-Validacion de Formula!", @"Limpieza de Revalidacion Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnDuplicarBom_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show(
                @"Desea generar una version nueva de esta formula (se copia tal cual para ser modificada)",
                @"Duplicacion de Formula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            PreparaDuplicacionFormula();
        }
        private void btnFlag4Deletion_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                @"Confirma el marcado de esta version para borrado definitivo? La formula ya no podrá ser ni utilizada ni reactivada",
                @"Borrado Definitivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;

            new BOMCreateUpdateManager(_idFormula).FlagForDeletion(_idFormula);
            ckFormulaValidada.Checked = false;
            ckActiva.Checked = false;
            ckFlagForDeletion.Checked = true;
            MessageBox.Show(@"La Formula ha sido marcada para borrado definitivo", "Formula flagged for deletion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGuardar.Enabled = false;
            //


        }


        //Validaciones
        private void txtDureza_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtMezclado_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private bool ValidarFormulaIsOk()
        {
            decimal qty = 0;
            decimal por = 0;
            decimal result;
            _formulaIsOK = false;
            txtZCantidad.BackColor = Color.OrangeRed;
            txtZPorcentaje.BackColor = Color.OrangeRed;

            dgvFormulaItems.AllowUserToAddRows = false;
            foreach (DataGridViewRow row in dgvFormulaItems.Rows)
            {
                //Valida codigo de MP y Cantiades sean correctas y >0
                if (row.Cells[1].Value == null)
                {
                    row.Cells[1].Style.BackColor = Color.OrangeRed;
                    return false;
                }
                else
                {
                    if (CheckMateriaPrimaIsValid(row.Cells[1].Value.ToString()))
                    {
                        row.Cells[1].Style.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        row.Cells[1].Style.BackColor = Color.OrangeRed;
                        return false;
                    }
                }
                //Valida cantidades numericas o >0
                if (row.Cells[3].Value == null)
                {
                    row.Cells[3].Style.BackColor = Color.OrangeRed;
                    return false;
                }

                if (decimal.TryParse(row.Cells[3].Value.ToString(), out result))
                {
                    if (result <= 0)
                    {
                        row.Cells[3].Style.BackColor = Color.OrangeRed;
                        return false;
                    }
                    else
                    {
                        qty += Convert.ToDecimal(row.Cells[3].Value);
                        row.Cells[3].Style.BackColor = Color.GreenYellow;
                    }
                }
                else
                {
                    row.Cells[3].Style.BackColor = Color.OrangeRed;
                    return false;
                }
            }

            foreach (DataGridViewRow row in dgvFormulaItems.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    if (decimal.TryParse(row.Cells[3].Value.ToString(), out result))
                    {
                        row.Cells[4].Value = result / qty; //Coloca el %
                        por += Convert.ToDecimal(row.Cells[4].Value);
                    }
                }
            }
            txtZPorcentaje.Text = por.ToString("P2");
            txtZCantidad.Text = qty.ToString("N3");
            txtZCantidad.BackColor = Color.GreenYellow;
            txtZPorcentaje.BackColor = Color.GreenYellow;
            _formulaIsOK = true;
            return true;
        }
        private void txtAlternativaFormula_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtAlternativaFormula_DoubleClick(object sender, EventArgs e)
        {
            if (_modo < 3)
            {
                txtAlternativaFormula.ReadOnly = false;
                _versionFormulaOri = txtAlternativaFormula.Text;
            }
        }
        private void txtAlternativaFormula_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtAlternativaFormula.Text != _versionFormulaOri)
            {
                if (new BOMCreateUpdateManager(_idFormula).CheckAlternativeAlreadyExist(_materialFabricar,
                    txtAlternativaFormula.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show(@"La Alternativa Ingresada ya Existe", @"Alternativa Existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void PreparaDuplicacionFormula()
        {
            _modo = 5;
            _idFormula = 0;
            txtModo.Text = "5";
            txtNumeroFormula.Text = null;
            txtAlternativaFormula.Text = GetNextAlternativeLetter();
            ckActiva.Checked = true;
            txtUltimaUtilizacion.Text = null;
            txtDescripcionFormula.Text = null;
            txtDureza.Text = null;
            txtIndicacionesFabricacion.Text = null;
            txtMezclado.Text = null;

            txtPlanInspeccion.Text = null;
            txtMasterRecipe.Text = null;
            txtBatchSizeStd.Text = null;
            txtNotasQA.Text = null;
            ckFormulaValidada.Checked = false;
            txtFechaValidacion.Text = null;
            txtResponValidacion.Text = null;

            btnAddNewAlternative.Enabled = false;
            btnFormulaPrevia.Enabled = false;
            btnFormProxima.Enabled = false;

            txtLogFechaCreacion.Text = null;
            txtLogFechaUpdate.Text = null;
            txtLogUserCreacion.Text = null;
            txtLogUserUpdate.Text = null;
            txtFormulaOK.Text = null;


        }


    }
}
