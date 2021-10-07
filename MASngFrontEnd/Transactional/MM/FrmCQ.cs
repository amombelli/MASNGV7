using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using MASngFE.Transactional.QM;
using MASngFE.Transactional.WM;
using Tecser.Business.DataFix;
using Tecser.Business.MainApp;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.MM
{
    public partial class FrmCq : Form
    {
        public FrmCq()
        {
            InitializeComponent();
        }

        public FrmCq(string material)
        {
            InitializeComponent();
            _materialSearch = material;
        }

        //-----------------------------------------------------------------------------------------------
        private List<CqStockStructure> _completeMaterialList = new List<CqStockStructure>();
        private bool[] _ckStatus;
        private readonly List<string> _statusList = new List<string>();
        private bool _materialInicializado = false;
        private bool _slocInicializado = false;
        private string _materialSearch;
        private int? IdStockSeleccionado;
        private StockStatusManager.EstadoLote EstadoStockSeleccionado;
        //-----------------------------------------------------------------------------------------------
        private void FrmCQ_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            ConfiguracionInicial();
            StatusCheck();
            if (_materialSearch != null)
            {
                txtMaterialBuscar.Text = _materialSearch;
                ApplyFilters();
            }

            IdStockSeleccionado = null;
            txtIdStockSeleccionado.Text = null;
            dgvStockList.ClearSelection();

        }

        public FrmCq(int modo)
        {
            InitializeComponent();
        }
        private void ConfiguracionInicial()
        {
            rbPrimario.Checked = true;
            cmbMaterial.Visible = false;
            txtMaterialBuscar.Visible = true;

            _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
            dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
        }
        private List<string> CompletaStatusList(bool[] ckstatus)
        {
            _statusList.Clear();
            for (int i = 0; i < ckstatus.Length; i++)
            {
                if (ckstatus[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            _statusList.Add("LIBERADO");
                            break;
                        case 2:
                            _statusList.Add("COMPROMETIDO");
                            break;
                        case 3:
                            _statusList.Add("RESTRINGIDO");
                            break;
                        case 4:
                            _statusList.Add("FE");
                            break;
                        case 5:
                            _statusList.Add("RESERVAPF");
                            break;
                        case 6:
                            _statusList.Add("RESERVARE");
                            break;
                    }
                }

            }
            return _statusList;
        }
        private void ApplyFilters()
        {
            var filteredList = _completeMaterialList;
            CompletaStatusList(_ckStatus);
            var x = from of in filteredList
                    where _statusList.Contains(of.Estado.ToUpper())
                    orderby of.Material descending
                    select of;
            filteredList = x.ToList();

            if (!string.IsNullOrEmpty(txtMaterialBuscar.Text))
            {
                filteredList = filteredList.Where(c => c.Material.ToUpper().Contains(txtMaterialBuscar.Text.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(txtNumeroLote.Text))
            {
                filteredList = filteredList.Where(c => c.Lote.ToUpper().Contains(txtNumeroLote.Text.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(cmbSloc.Text))
            {
                filteredList =
                    filteredList.Where(c => c.SLOC.ToUpper() == cmbSloc.SelectedValue.ToString().ToUpper()).ToList();
            }

            dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(filteredList);
            txtKgSeleccionados.Text = filteredList.Sum(c => c.TotalKg).ToString("N2");
            txtLineasStock.Text = filteredList.Count(c => c.TotalKg > 0).ToString();
        }
        private void StatusCheck()
        {
            ckLiberado.Checked = true;
            ckComprometido.Checked = true;
            ckFE.Checked = true;
            ckReservaPF.Checked = true;
            ckReservaRE.Checked = true;
            ckRestringido.Checked = true;

            _ckStatus = new bool[6]
            {
                ckLiberado.Checked, ckComprometido.Checked, ckRestringido.Checked, ckFE.Checked, ckReservaPF.Checked,
                ckReservaRE.Checked
            };
        }

        #region botones

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
            dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
            ApplyFilters();
        }

        private void btnAllStatus_Click(object sender, EventArgs e)
        {
            ckLiberado.Checked = true;
            ckComprometido.Checked = true;
            ckFE.Checked = true;
            ckReservaPF.Checked = true;
            ckReservaRE.Checked = true;
            ckRestringido.Checked = true;

            _ckStatus = new bool[6]
            {
                ckLiberado.Checked, ckComprometido.Checked, ckRestringido.Checked, ckFE.Checked, ckReservaPF.Checked,
                ckReservaRE.Checked
            };
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            ckLiberado.Checked = false;
            ckComprometido.Checked = false;
            ckFE.Checked = false;
            ckReservaPF.Checked = false;
            ckReservaRE.Checked = false;
            ckRestringido.Checked = false;
            _ckStatus = new bool[6]
            {
                ckLiberado.Checked, ckComprometido.Checked, ckRestringido.Checked, ckFE.Checked, ckReservaPF.Checked,
                ckReservaRE.Checked
            };
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
            cmbMaterial.Text = null;
            txtMaterialBuscar.Text = null;
            cmbSloc.Text = null;
            txtNumeroLote.Text = null;
            txtPrimaryDescription.Text = @"TODOS LOS MATERIALES";
            txtSlocDescription.Text = @"TODAS LAS UBICACIONES";

            ApplyFilters();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void ckLiberado_CheckedChanged(object sender, EventArgs e)
        {
            _ckStatus = new bool[6]
            {
                ckLiberado.Checked, ckComprometido.Checked, ckRestringido.Checked, ckFE.Checked, ckReservaPF.Checked,
                ckReservaRE.Checked
            };

            ApplyFilters();
        }
        private void rbPrimario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrimario.Checked)
            {

            }
            else
            {
                MessageBox.Show(@"Por el momento esta habilitado solamente busqueda por primario",
                    @"Funcionalidad Reducida", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        #region Filtros
        private void txtMaterialBuscar_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void cmbMaterial_TextUpdate(object sender, EventArgs e)
        {
            txtMaterialBuscar.Text = cmbMaterial.Text;
        }
        private void txtNumeroLote_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void cmbSloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSloc.SelectedValue != null)
            {
                txtSlocDescription.Text = StorageLocationManager.GetSlocDescription(cmbSloc.SelectedValue.ToString());
                ApplyFilters();
            }
        }
        private void cmbSloc_TextUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSloc.Text))
            {
                txtSlocDescription.Text = @"TODAS LAS UBICACIONES";
                cmbSloc.Text = null;
                ApplyFilters();
            }
        }

        #endregion

        private void DgvStockList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtIdStockSeleccionado.Text = dgvStockList[0, e.RowIndex].Value.ToString();
            IdStockSeleccionado = Convert.ToInt32(dgvStockList[0, e.RowIndex].Value);
            EstadoStockSeleccionado =
                StockStatusManager.MapStatusFromText(dgvStockList[estadoDataGridViewTextBoxColumn.Name, e.RowIndex]
                    .Value.ToString());
        }
        private void dgvStockList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvStockList[e.ColumnIndex, e.RowIndex].Value.ToString();

                switch (cellValue)
                {
                    case "QM":
                        using (var f1 = new FrmQM40RestringeLote(Convert.ToInt32(dgvStockList[0, e.RowIndex].Value)))
                        {
                            DialogResult dr = f1.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
                                dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
                                ApplyFilters();
                            }
                        }
                        break;

                    case "ACCION":

                        using (var f0 = new FrmMm0Accion(1, Convert.ToInt32(dgvStockList[0, e.RowIndex].Value)))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
                                dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
                                ApplyFilters();
                            }
                        }
                        break;
                    case "MOVE":
                        using (var f0 = new FrmWm01MoveStock(Convert.ToInt32(dgvStockList[0, e.RowIndex].Value), "MM0"))
                        {
                            DialogResult dr = f0.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
                                dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
                                ApplyFilters();
                            }
                        }
                        break;

                    case "PRTN":
                        var f2 = new RpvOrdenFabricacion(Convert.ToInt32(dgvStockList[0, e.RowIndex].Value));
                        f2.Show();
                        break;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
        private void btnAltaNewLine_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmWM04AddStockLine())
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
                    dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
                    ApplyFilters();
                }
            }
        }
        private void cmbMaterial_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbMaterial.Text))
                txtMaterialBuscar.Text = null;

            if (_materialInicializado)
                return;

            reducedMaterialMasterBindingSource.DataSource = new ReducedMaterialMasterData().GetList(GlobalApp.CnnApp);
            _materialInicializado = true;
        }
        private void cmbMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtMaterialBuscar.Text = cmbMaterial.SelectedValue.ToString();
            ApplyFilters();

        }
        private void ckSoloConStock_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloConStock.Checked)
            {
                ckSoloConStock.BackColor = Color.GreenYellow;
                reducedMaterialMasterBindingSource.DataSource = new ReducedMaterialMasterData().GetList(GlobalApp.CnnApp);
                MessageBox.Show(@"Funcionalidad In-Progress", @"No realizado", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
            else
            {
                ckSoloConStock.BackColor = Color.Pink;
                reducedMaterialMasterBindingSource.DataSource = new ReducedMaterialMasterData().GetList(GlobalApp.CnnApp);
            }

        }
        private void ckBusquedaLibre_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBusquedaLibre.Checked)
            {
                ckBusquedaLibre.BackColor = Color.GreenYellow;
                txtMaterialBuscar.Visible = true;
                cmbMaterial.Visible = false;
            }
            else
            {
                ckBusquedaLibre.BackColor = Color.Pink;
                txtMaterialBuscar.Visible = false;
                cmbMaterial.Visible = true;
            }
        }
        private void cmbSloc_Enter(object sender, EventArgs e)
        {
            if (_slocInicializado)
                return;
            //t0028SLOCBindingSource.DataSource = new StorageLocationManager().ListOfLoc(true, txtPlanta.Text);
            cmbSloc.DataSource = new StorageLocationManager().ListOfLoc(true, txtPlanta.Text);

            _slocInicializado = true;
        }
        private void btnOptimizacionStock_Click(object sender, EventArgs e)
        {
            new StockOptimization().OptimizaStock();
        }
        private void btnFixRedondeo_Click(object sender, EventArgs e)
        {
            new FixStockRedondeo().FixRedondeoStock();
        }
        private void BtnUpdateLote_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmWm05UpdateLoteNumber(IdStockSeleccionado.Value, "CQ"))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
                    dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
                    ApplyFilters();
                }
            }
        }
        private void BtnAjusteStock_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmWM03ModificarKG(IdStockSeleccionado.Value, "CQ"))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
                    dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
                    ApplyFilters();
                }
            }
        }
        private void BtnLiberarLote_Click(object sender, EventArgs e)
        {
            //if (EstadoStockSeleccionado == StockStatusManager.EstadoLote.Liberado)
            //{
            //    MessageBox.Show(@"El Lote ya se encuentra Liberado", @"Error en Restriccion de Lote",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQLIBERA", true, false))
            //{
            //    MessageBox.Show(@"El Usuario no cuenta con permisos para la Liberacion de Lotes", @"Security Check Failed",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //using (var f0 = new FrmWM02ModificacionEstadoLote(IdStockSeleccionado.Value, "CQ",ModeAjusteEstado.Libera))
            //{
            //    DialogResult dr = f0.ShowDialog();
            //    if (dr == DialogResult.OK)
            //    {
            //        _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
            //        dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
            //        ApplyFilters();
            //    }
            //}


            ////Ejecucion de TCODE
            //var respuesta = MessageBox.Show(@"Confirma la modificacion del Estado a >> LIBERADO << - Esta transacion quedará logueada",
            //    @"Movimiento/Cambio de Stock",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (respuesta == DialogResult.No)
            //    return;

            //var x = new StockMovements();
            //var log40 = x.MoveEstado(_idstock, Convert.ToDecimal(txtKgCambiarEstado.Text),
            //    StockStatusManager.MapStatusFromText(cmbNewEstado.Text), "MM0");
            //if (log40 > 0)
            //    MessageBox.Show(@"Se ha realizado correctamente el Cambio de Estado del Material", @"Cambio de Estado",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void BtnRestringirLote_Click(object sender, EventArgs e)
        {
            //if (EstadoStockSeleccionado == StockStatusManager.EstadoLote.Restringido)
            //{
            //    MessageBox.Show(@"El Lote ya se encuentra restringido", @"Error en Restriccion de Lote",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQRESTRINGE", true, false))
            //{
            //    MessageBox.Show(@"El Usuario no cuenta con permisos para la Resrticcion de Lotes", @"Security Check Failed",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //using (var f0 = new FrmWM02ModificacionEstadoLote(IdStockSeleccionado.Value, "CQ", ModeAjusteEstado.Restringe))
            //{
            //    DialogResult dr = f0.ShowDialog();
            //    if (dr == DialogResult.OK)
            //    {
            //        _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
            //        dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
            //        ApplyFilters();
            //    }
            //}
        }
        private void BtnModificarEstado_Click(object sender, EventArgs e)
        {
            //if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQCHANGEESTADO", true, false))
            //{
            //    MessageBox.Show(@"El Usuario no cuenta con permisos para la Resrticcion de Lotes", @"Security Check Failed",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //using (var f0 = new FrmWM02ModificacionEstadoLote(IdStockSeleccionado.Value, "CQ", ModeAjusteEstado.Free))
            //{
            //    DialogResult dr = f0.ShowDialog();
            //    if (dr == DialogResult.OK)
            //    {
            //        _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp);
            //        dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
            //        ApplyFilters();
            //    }
            //}
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCompromiso_Click(object sender, EventArgs e)
        {
            var f = new FrmWm06LiberarCompromiso();
            f.Show();
        }

        private void btnRptStandBy_Click(object sender, EventArgs e)
        {
            var f = new RpvWmStandBy();
            f.Show();
        }

        private void btnReservaRe_Click(object sender, EventArgs e)
        {
            using (var f = new FrmWM07LiberarReservaRE(null))
            {
                f.ShowDialog();
            }
        }
    }
}
