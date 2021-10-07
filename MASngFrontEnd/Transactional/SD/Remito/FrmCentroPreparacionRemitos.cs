using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.SD;
using Tecser.Business.Transactional.WM;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.SD.Remito
{
    public partial class FrmCentroPreparacionRemitos : Form
    {
        public FrmCentroPreparacionRemitos()
        {
            InitializeComponent();
            _ckStatus = new bool[8] { false, false, false, false, false, false, false, false };
        }

        //-----------------------------------------------------------------------------------------
        private bool[] _ckStatus;
        private List<T0056_REMITO_I> _listItems = new List<T0056_REMITO_I>();
        private List<RemitoHeaderStructureCF> _listHeader = new List<RemitoHeaderStructureCF>();
        private int? _idRemitoSeleccionado;
        private RemitoStatusManager.StatusHeader _statusRemitoSeleccionado;
        //-----------------------------------------------------------------------------------------
        private void dgvRemitoItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            ////Remueve item del Dgv si se presiona DEL
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //No hay boton de remover item - Se removera automaticamente all no este 'Despachado' 
                //var cellValue = dgvRemitoItem[e.ColumnIndex, e.RowIndex].Value.ToString();
                //switch (cellValue)
                //{
                //    case "QUITAR":
                //        int idStockSeleccionado =Convert.ToInt32(dgvRemitoItem[dgvRemitoItem.Columns["idstockreservado_dgv"].Index, e.RowIndex].Value);
                //        int iditem =(int) dgvRemitoItem[dgvRemitoItem.Columns["idremitoitem_dgv"].Index, e.RowIndex].Value;
                //        break;

                //    default:
                //        MessageBox.Show(@"Este Boton no se encuentra manejado aun",@"Funcionalidad Reducida",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //        break;
                //}
            }
            else
            {
                //**DOBLE-CLICK SOBRE NUMERO DE LOTE
                if (e.ColumnIndex == dgvRemitoItem.Columns[numlote_dgv.Name].Index && e.RowIndex >= 0)
                {
                    var materialPrimario = dgvRemitoItem[dgvRemitoItem.Columns[material_dgv.Name].Index, e.RowIndex].Value.ToString();
                    var kg = (decimal)dgvRemitoItem[dgvRemitoItem.Columns[kg_dgv.Name].Index, e.RowIndex].Value;
                    var idRemitoItem = (int)dgvRemitoItem[dgvRemitoItem.Columns[idremitoitem_dgv.Name].Index, e.RowIndex].Value;
                    var idRemito = (int)dgvRemitoItem[dgvRemitoItem.Columns[idremito1_dgv.Name].Index, e.RowIndex].Value;
                    var idStockSeleccionado = Convert.ToInt32(dgvRemitoItem[dgvRemitoItem.Columns[idstockreservado_dgv.Name].Index, e.RowIndex].Value);

                    if (idStockSeleccionado > 0)
                    {
                        //Libera el stock reservado para este remito y lo pasa a disponible
                        new CompromisoManager().FreeStockComprometidoByIdstock(idStockSeleccionado, false);
                    }

                    using (var f1 = new FrmSeleccionBatchDespacho(materialPrimario, kg))
                    {
                        DialogResult dr = f1.ShowDialog();
                        switch (dr)
                        {
                            case DialogResult.OK:

                                if (idStockSeleccionado > 0)
                                {
                                    MessageBox.Show(
                                        @"Se ha liberado el stock reservado con anterioridad y se ha asignado el NUEVO LOTE para este remito",
                                        @"Liberacion/Reasignacion Stock ReservadoOK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                var nuevoIdStockSeleccionado = f1.IdStockSeleccionado;
                                var kgSeleccioandos = (decimal)f1.KgSeleccionados;

                                new StockBatchManagerSD().ReservaStockRemito(nuevoIdStockSeleccionado.Value, kgSeleccioandos, idRemito, idRemitoItem);

                                if (kg > kgSeleccioandos)
                                {
                                    new RemitoItemManager().DuplicaRemitoItemDb(idRemito, idRemitoItem, kg - kgSeleccioandos);
                                    new RemitoItemManager().UpdateItemRemitoReservaLote(idRemito, idRemitoItem,
                                        nuevoIdStockSeleccionado.Value, kgSeleccioandos);
                                }
                                break;

                            case DialogResult.Cancel:
                                if (idStockSeleccionado > 0)
                                {
                                    MessageBox.Show(@"Se ha LIBERADO el lote de Stock reservado para este remito y NO SE HA ASIGNADO ningun lote",
                                        @"Liberacion Stock Reservado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    new CompromisoManager().FreeStockComprometidoByIdstock(idStockSeleccionado, true);
                                    new RemitoItemManager().UpdateItemRemitoReservaLote(idRemito, idRemitoItem, 0, kg);
                                }
                                break;

                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    new RemitoItemManager().ConsolidaItemsRemitoSinAsignar(_idRemitoSeleccionado.Value);
                    new RemitoStatusManager().RecheckStatusItemRemito(_idRemitoSeleccionado.Value);
                    UpdateDgvRemitoItemDataSource();
                    RecalculaKgRemito();
                }
                else
                {
                    MessageBox.Show(@"Para realizar alguna modificacion debe hacer doble-click en numero de Lote",
                        @"Funcionalidad no Encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void RecalculaKgRemito()
        {
            var retorno = new RemitoItemManager().CalculaKgRemito(_idRemitoSeleccionado.Value);
            txtKgRemito.Text = retorno.KgConLote.ToString("N2");
            txtKgTotales.Text = retorno.KgTotales.ToString("N2");
        }
        private void FrmCentroPreparacionFacturacion_Load(object sender, EventArgs e)
        {
            SetDefaultValues();
        }
        private void SetDefaultValues()
        {
            this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.ckInicial.CheckedChanged -= new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckPreparado.CheckedChanged -= new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckEnPreparacion.CheckedChanged -= new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckGenerado.CheckedChanged -= new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckImpreso.CheckedChanged -= new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckStandBy.CheckedChanged -= new System.EventHandler(this.ckInicial_CheckedChanged);
            this.dgvRemitoHeader.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemitoHeader_CellEnter);

            cmbRazonSocial.DataSource = new CustomerManager().GetCompleteListofBillTo().ToList();
            cmbRazonSocial.SelectedValue = -1;
            ckInicial.Checked = true;
            ckPreparado.Checked = true;
            ckEnPreparacion.Checked = true;
            ckGenerado.Checked = true;
            ckImpreso.Checked = false;
            ckStandBy.Checked = false;
            ckFacturado.Checked = true;
            ckSinFacturar.Checked = true;
            _idRemitoSeleccionado = null;
            UpdateDataSourceHeader();

            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.ckInicial.CheckedChanged += new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckPreparado.CheckedChanged += new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckEnPreparacion.CheckedChanged += new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckGenerado.CheckedChanged += new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckImpreso.CheckedChanged += new System.EventHandler(this.ckInicial_CheckedChanged);
            this.ckStandBy.CheckedChanged += new System.EventHandler(this.ckInicial_CheckedChanged);
            this.dgvRemitoHeader.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemitoHeader_CellEnter);
            UpdateDataSourceHeader(null);
        }
        private void UpdateDataSourceHeader(int? idRemito = null)
        {
            _ckStatus = new bool[6]
            {
                ckInicial.Checked, ckEnPreparacion.Checked, ckPreparado.Checked, ckGenerado.Checked, ckImpreso.Checked,
                ckStandBy.Checked
            };
            _listHeader = new CFRemitoManager().GetDataSourceCentroFacturacion(_ckStatus,
                Convert.ToInt32(txtMaxRecords.Text));
            remitoHeaderStructureCFBindingSource.DataSource = _listHeader.ToList();
            dgvRemitoHeader.DataSource = remitoHeaderStructureCFBindingSource.DataSource;
            SelectRowInDgvHeader(idRemito);
        }
        private void UpdateDgvRemitoItemDataSource()
        {
            dgvRemitoItem.DataSource = null;
            if (_idRemitoSeleccionado != null)
            {
                dgvRemitoItem.DataSource = new CFRemitoManager().GetDataSourceItem(_idRemitoSeleccionado.Value);
                dgvRemitoItem.ClearSelection();
            }

            for (var a = 0; a < dgvRemitoItem.Rows.Count; a++)
            {
                if ((string)dgvRemitoItem.Rows[a].Cells[sTATUSITEMDataGridViewTextBoxColumn.Name].Value ==
                    RemitoStatusManager.StatusItem.SinAsignar.ToString())
                {
                    dgvRemitoItem.Rows[a].Cells[sTATUSITEMDataGridViewTextBoxColumn.Name].Style.BackColor = Color.Khaki;
                }
                else
                {
                    if ((string)dgvRemitoItem.Rows[a].Cells[sTATUSITEMDataGridViewTextBoxColumn.Name].Value ==
                    RemitoStatusManager.StatusItem.ReservadoOK.ToString())
                    {
                        dgvRemitoItem.Rows[a].Cells[sTATUSITEMDataGridViewTextBoxColumn.Name].Style.BackColor = Color.Chartreuse;
                    }
                    else
                    {
                        if ((string)dgvRemitoItem.Rows[a].Cells[sTATUSITEMDataGridViewTextBoxColumn.Name].Value ==
                    RemitoStatusManager.StatusItem.Despachado.ToString())
                        {
                            dgvRemitoItem.Rows[a].Cells[sTATUSITEMDataGridViewTextBoxColumn.Name].Style.BackColor = Color.DeepSkyBlue;
                        }
                        else
                        {
                            if ((string)dgvRemitoItem.Rows[a].Cells[sTATUSITEMDataGridViewTextBoxColumn.Name].Value ==
                                RemitoStatusManager.StatusItem.Cancelado.ToString())
                            {
                                dgvRemitoItem.Rows[a].Cells[sTATUSITEMDataGridViewTextBoxColumn.Name].Style.BackColor =
                                    Color.DarkSalmon;
                            }
                            else
                            {
                                dgvRemitoItem.Rows[a].Cells[sTATUSITEMDataGridViewTextBoxColumn.Name].Style.BackColor =
                                    Color.DarkOrange;
                            }
                        }
                    }
                }
            }
        }
        private void dgvRemitoHeader_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            _idRemitoSeleccionado =
                Convert.ToInt32(dgvRemitoHeader[dgvRemitoHeader.Columns[idremito_dgv.Name].Index, e.RowIndex].Value);
            txtIdRemitoSelected.Text = _idRemitoSeleccionado.ToString();

            var statusRemitoSeleccionado =
                dgvRemitoHeader[dgvRemitoHeader.Columns[StatusRemitoDgv.Name].Index, e.RowIndex].Value.ToString();
            _statusRemitoSeleccionado = new RemitoStatusManager().MapStatusHeaderFromText(statusRemitoSeleccionado);
            SetButtonsStatus(_statusRemitoSeleccionado);

            btnVisualizarFactura.Enabled = Convert.ToBoolean(
                dgvRemitoHeader[dgvRemitoHeader.Columns[facturadoDataGridViewCheckBoxColumn.Name].Index, e.RowIndex]
                    .Value);
            new RemitoStatusManager().RecheckStatusItemRemito(_idRemitoSeleccionado.Value);
            UpdateDgvRemitoItemDataSource();
            RecalculaKgRemito();
        }
        private void dgvRemitoItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == dgvRemitoItem.Columns["_generarRemito"].Index && e.RowIndex >= 0)
            {
                int idRemitoItem =
                    (int)dgvRemitoItem[dgvRemitoItem.Columns["idremitoitem_dgv"].Index, e.RowIndex].Value;
                int idRemito = (int)dgvRemitoItem[dgvRemitoItem.Columns["idremito1_dgv"].Index, e.RowIndex].Value;
                int idStockSeleccionado =
                    Convert.ToInt32(dgvRemitoItem[dgvRemitoItem.Columns["idstockreservado_dgv"].Index, e.RowIndex].Value);
                decimal kgItem = (decimal)dgvRemitoItem[dgvRemitoItem.Columns["kg_dgv"].Index, e.RowIndex].Value;
                string statusItem =
                    dgvRemitoItem[dgvRemitoItem.Columns[sTATUSITEMDataGridViewTextBoxColumn.Name].Index, e.RowIndex]
                        .Value.ToString();

                DataGridViewCheckBoxCell generaRemitoCell = new DataGridViewCheckBoxCell();
                DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
                CheckboxColumn.TrueValue = true;
                CheckboxColumn.FalseValue = false;
                DataGridViewCheckBoxCell chk =
                    (DataGridViewCheckBoxCell)
                        dgvRemitoItem[dgvRemitoItem.Columns[_generarRemito.Name].Index, e.RowIndex];

                if (chk == null)
                {
                    chk.Value = chk.FalseValue;
                }
                switch ((bool)chk.Value)
                {
                    case true:
                        //El Item ESTA MARCADO y esta intentando DESMARCARLO solo permite esta accion si el estado era reservaOK.
                        if (statusItem == RemitoStatusManager.StatusItem.ReservadoOK.ToString())
                        {
                            var dr =
                                MessageBox.Show(
                                    @"ITEM Con LOTE ASIGNADO" + Environment.NewLine + Environment.NewLine +
                                    @"Confirma la liberacion de las Reservas de Stock y la NO inclusion del item en el Remito?",
                                    @"Liberacion de Item", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes)
                            {
                                MessageBox.Show(@"Se ha LIBERADO el stock reservado para este remito",
                                    @"Liberacion Stock ReservadoOK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                new CompromisoManager().FreeStockComprometidoByIdstock(idStockSeleccionado, true);
                                new RemitoItemManager().UpdateItemRemitoReservaLote(idRemito, idRemitoItem, 0, kgItem,
                                    true);
                                new RemitoItemManager().ConsolidaItemsRemitoSinAsignar(_idRemitoSeleccionado.Value);
                                new RemitoStatusManager().RecheckStatusItemRemito(_idRemitoSeleccionado.Value);
                                dgvRemitoItem.BeginEdit(true);
                                chk.Value = false;
                                dgvRemitoItem[dgvRemitoItem.Columns[_generarRemito.Name].Index, e.RowIndex].Value =
                                    chk.Value;
                                dgvRemitoItem.EndEdit();

                                new RemitoItemManager().ConsolidaItemsRemitoSinAsignar(_idRemitoSeleccionado.Value);
                                new RemitoStatusManager().RecheckStatusItemRemito(_idRemitoSeleccionado.Value);
                                UpdateDgvRemitoItemDataSource();
                                RecalculaKgRemito();
                            }
                            else if (dr == DialogResult.No)
                            {
                                chk.Value = chk.TrueValue;
                                dgvRemitoItem.BeginEdit(true);
                                chk.Value = true;
                                dgvRemitoItem[dgvRemitoItem.Columns[_generarRemito.Name].Index, e.RowIndex].Value =
                                    chk.Value;
                                dgvRemitoItem.EndEdit();
                            }
                        }
                        break;
                    case false:
                        //El Item no esta marcado y esta intentando marcarlo.- Esto se hace solo desde la asignacion de un LOTE
                        MessageBox.Show(
                            @"Para agregar un Item al Remito se debe asignar el Lote/Stock y automaticamente el item sera agregado",
                            @"Incluir un Item en un Remito", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        dgvRemitoItem.BeginEdit(true);
                        chk.Value = false;
                        dgvRemitoItem[dgvRemitoItem.Columns[_generarRemito.Name].Index, e.RowIndex].Value = chk.Value;
                        dgvRemitoItem.EndEdit();

                        break;
                    default:
                        MessageBox.Show(
                            @"Atencion el sistema no esta interpretando el valor de CHK. Notifique por favor", @"ALERTA",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
        private void SelectRowInDgvHeader(int? idRemitoSeleccionado = null)
        {
            if (idRemitoSeleccionado == null)
            {
                //dgvRemitoHeader.ClearSelection();
                //dgvRemitoItem.ClearSelection();
                return;
            }
            var seleccionado = false;
            var strIdRemito = idRemitoSeleccionado.ToString();

            if (idRemitoSeleccionado > 0)
            {
                foreach (DataGridViewRow row in dgvRemitoHeader.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(strIdRemito))
                    {
                        row.Selected = true;
                        _idRemitoSeleccionado = idRemitoSeleccionado;
                        _statusRemitoSeleccionado =
                            new RemitoStatusManager().MapStatusHeaderFromText(row.Cells[5].Value.ToString());
                        UpdateDgvRemitoItemDataSource();
                        seleccionado = true;
                        break;
                    }
                }
                if (seleccionado) return;
                _idRemitoSeleccionado = null;
                txtIdRemitoSelected.Text = null;
            }
        }

        //Modifica el check-uncheck de generar remito

        private void txtIdRemitoSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdRemitoSearch.Text))
            {
            }
            else
            {
            }
        }
        private void ckInicial_CheckedChanged(object sender, EventArgs e)
        {
            this.dgvRemitoHeader.CellEnter -=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemitoHeader_CellEnter);
            UpdateDataSourceHeader(_idRemitoSeleccionado);
            this.dgvRemitoHeader.CellEnter +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRemitoHeader_CellEnter);
        }
        private void ckSinFacturar_CheckedChanged(object sender, EventArgs e)
        {
            AplicaFiltro();
        }
        private void ckImpreso_CheckedChanged(object sender, EventArgs e)
        {
            _ckStatus = new bool[5]
           {
                ckInicial.Checked, ckEnPreparacion.Checked, ckPreparado.Checked, ckGenerado.Checked, ckImpreso.Checked,
           };

            remitoHeaderStructureCFBindingSource.DataSource =
                          new CFRemitoManager().GetDataSourceCentroFacturacion(_ckStatus, Convert.ToInt32(txtMaxRecords.Text));

        }
        private void AplicaFiltro()
        {

            var lista = _listHeader;
            if (cmbRazonSocial.SelectedIndex > -1)
            {
                lista = lista.Where(c => c.idClienteT6 == Convert.ToInt32(cmbRazonSocial.SelectedValue)).ToList();
            }

            if (ckFacturado.Checked && ckSinFacturar.Checked)
            {
                //Los 2 Activos - No filtra nada mas
            }
            else
            {
                if (ckFacturado.Checked)
                {
                    //Solo Facturado   
                    lista = lista.Where(c => c.Facturado).ToList();
                }
                else
                {
                    if (ckSinFacturar.Checked)
                    {
                        //Solo sin Facturar
                        lista = lista.Where(c => c.Facturado == false).ToList();
                    }
                    else
                    {
                        //Ninguno Marcado
                    }
                }
            }
            dgvRemitoHeader.DataSource = lista.ToList();
        }

        #region Accion de Botones
        private void SetButtonsStatus(RemitoStatusManager.StatusHeader status)
        {
            dgvRemitoItem.Enabled = false;
            btnCancelarRemitoInicial.Enabled = false;
            btnConfirmarPreparacion.Enabled = false;
            btnCancelarPreparacion.Enabled = false;
            btnImprimirPreparacion.Enabled = false;
            btnGenerarRemito.Enabled = false;
            btnVisaulizarRemito.Enabled = false;
            btnVisualizarFactura.Enabled = false;
            btnAgregarItems.Enabled = false;
            btnRemoverItems.Enabled = false;
            btnConsolidarItemsSinAsignar.Enabled = false;
            btnConsolidarItems.Enabled = false;

            switch (status)
            {
                case RemitoStatusManager.StatusHeader.EnPreparacion:
                    btnCancelarRemitoInicial.Enabled = true;
                    btnConfirmarPreparacion.Enabled = true;
                    btnImprimirPreparacion.Enabled = true;
                    dgvRemitoItem.Enabled = true;
                    break;
                case RemitoStatusManager.StatusHeader.Preparado:
                    btnCancelarPreparacion.Enabled = true;
                    btnGenerarRemito.Enabled = true;
                    break;
                case RemitoStatusManager.StatusHeader.Error:
                    break;
                case RemitoStatusManager.StatusHeader.Generado:
                    btnVisaulizarRemito.Enabled = true;
                    btnVisualizarFactura.Enabled = true;
                    break;
                case RemitoStatusManager.StatusHeader.Impreso:
                    btnVisaulizarRemito.Enabled = true;
                    btnVisualizarFactura.Enabled = true;
                    break;
                case RemitoStatusManager.StatusHeader.Cancelado:
                    btnVisaulizarRemito.Enabled = true;
                    break;
                case RemitoStatusManager.StatusHeader.Inicial:
                    btnConfirmarPreparacion.Enabled = true;
                    dgvRemitoItem.Enabled = true;
                    break;
                case RemitoStatusManager.StatusHeader.StandBy:
                    btnCancelarRemitoInicial.Enabled = false;
                    btnConfirmarPreparacion.Enabled = false;
                    btnCancelarPreparacion.Enabled = false;
                    btnImprimirPreparacion.Enabled = false;
                    btnGenerarRemito.Enabled = false;
                    btnVisaulizarRemito.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }

        private void btnConsolidarItems_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcion momentaneamente desactivada - Consolide dentro del Remito Generado",
                @"Funcion Desactivada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
#pragma warning disable CS0162 // Unreachable code detected
            new RemitoItemManager().ConsolidaItemsRemito(_idRemitoSeleccionado.Value);
#pragma warning restore CS0162 // Unreachable code detected
        }

        private void btnGenerarRemito_Click(object sender, EventArgs e)
        {
            if (RemitoStatusManager.AllowRemitoGenerarSegunEstado(_idRemitoSeleccionado.Value) == false)
            {
                MessageBox.Show(@"El ESTADO del Remito no permite ejecutar esta accion", @"Error al ejecutar Accion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RemitoStatusManager.AllowRemitoGenerarCheckL5(_idRemitoSeleccionado.Value) == false)
            {
                MessageBox.Show(
                    @"El Remito posee CostItems que se agregaran cuando se finalice el Remito L1 Asociado [L5]",
                    @"Falta Remito L5",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            new RemitoStatusManager().RecheckStatusItemRemito(_idRemitoSeleccionado.Value);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0056_REMITO_I.Where(c => c.IDREMITO == _idRemitoSeleccionado).ToList();
                if (items.Count == 0)
                {
                    MessageBox.Show(@"El Remito NO CONTIENE ITEMS para preparar",
                        @"Preparcion de Remitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var itemsError =
                    items.Where(c => c.STATUSITEM == RemitoStatusManager.StatusItem.Error.ToString()).ToList();
                if (itemsError.Count > 0)
                {
                    MessageBox.Show(
                        $"El Remito CONTIENE {itemsError.Count} ITEM/S EN ERROR. Debe solucionar este problema antes de continuar",
                        @"Error en Generacion de Remitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var itemsNoMarcados =
                    items.Where(
                        c =>
                            c.GENERAR_REMITO.Value == false &&
                            c.STATUSITEM == RemitoStatusManager.StatusItem.ReservadoOK.ToString()).ToList();
                if (itemsNoMarcados.Count > 0)
                {
                    MessageBox.Show(
                        $"El Remito CONTIENE {itemsNoMarcados.Count} ITEM/S con RESERVADO-OK de STOCK pero no está incluido en la GENERACION del Remito. Debe solucionar este problema antes de continuar",
                        @"Error en generacion de Remitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var itemsStatusSinAsignar = items.Where(
                    c =>
                        c.GENERAR_REMITO.Value == true &&
                        c.STATUSITEM == RemitoStatusManager.StatusItem.SinAsignar.ToString()).ToList();

                if (itemsStatusSinAsignar.Count > 0)
                {
                    MessageBox.Show(
                        $"El Remito CONTIENE {itemsStatusSinAsignar.Count} ITEM/S marcados para generar el remito pero con status SIN ASIGNAR. Debe solucionar este problema antes de continuar",
                        @"Error en Generacion de Remitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var dialogResult = MessageBox.Show(@"Confirma la generacion del Remito (BAJA DEL STOCK RESERVADO)?",
                @"Generacion del Remito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;

            var remitoGen = new ManageGeneracionRemitoFinal(_idRemitoSeleccionado.Value);

            if (!remitoGen.CheckIfIsOkToGenerate())
            {
                MessageBox.Show(
                    @"El Remito no se puede generar debido a que fallo la comprobacion de Completitud/Estado Correcto",
                    @"Chequeo de Completitud", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (remitoGen.AllItemsAreCheckedToGenerate() == false)
            {
                DialogResult dr =
                    MessageBox.Show(
                        @"El Remito tiene CostItems que no seran agregados al Remito Final. Desea Continuar?",
                        @"Preparacion del Remito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                    return;
            }

            //Generacion de Remito
            if (remitoGen.Generacion())
            {
                MessageBox.Show(
                    string.Format(
                        @"Se ha Generado Correctamente el Remito Temporal y se ha Actualizado el Stock en Planta"),
                    @"Generacion del Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _statusRemitoSeleccionado = RemitoStatusManager.StatusHeader.Generado;
            }
            else
            {
                MessageBox.Show(@"Upppsss algo Salio muy mal!", @"Error en Generacion de Remito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                _statusRemitoSeleccionado = RemitoStatusManager.StatusHeader.Error;
            }

            UpdateDataSourceHeader(_idRemitoSeleccionado.Value);
            UpdateDgvRemitoItemDataSource();
            SetButtonsStatus(_statusRemitoSeleccionado);

        }

        private void btnConfirmarPreparacion_Click(object sender, EventArgs e)
        {
            if (RemitoStatusManager.AllowRemitoPreparar(_idRemitoSeleccionado.Value) == false)
            {
                MessageBox.Show(@"El ESTADO DEL REMITO no permite ejecutar esta accion", @"Error al ejecutar Accion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RemitoStatusManager.AllowRemitoPrepararCheckStatusItem(_idRemitoSeleccionado.Value) == false)
            {
                MessageBox.Show(@"Existen CostItems SIN STOCK ASIGNADO con el Check de GENERAR REMITO.", @"Error al ejecutar Accion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var items = db.T0056_REMITO_I.Where(c => c.IDREMITO == _idRemitoSeleccionado).ToList();
                if (items.Count == 0)
                {
                    MessageBox.Show(@"El Remito NO CONTIENE ITEMS para preparar",
                        @"Preparcion de Remitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var itemsError = items.Where(c => c.STATUSITEM == RemitoStatusManager.StatusItem.Error.ToString()).ToList();
                if (itemsError.Count > 0)
                {
                    MessageBox.Show($"El Remito CONTIENE {itemsError.Count} ITEM/S EN ERROR. Debe solucionar este problema antes de continuar",
                        @"Error en Preparcion de Remitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var itemsNoMarcados = items.Where(c => c.GENERAR_REMITO.Value == false && c.STATUSITEM == RemitoStatusManager.StatusItem.ReservadoOK.ToString()).ToList();
                if (itemsNoMarcados.Count > 0)
                {
                    MessageBox.Show($"El Remito CONTIENE {itemsNoMarcados.Count} ITEM/S con RESERVA OK de STOCK pero no está incluido en la preparacion del Remito. Debe solucionar este problema antes de continuar",
                        @"Error en Preparcion de Remitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                var cantidadItems = items.Count;
                var cantidadItemsGenerarRemito = items.Where(c => c.GENERAR_REMITO.Value).ToList();

                if (cantidadItemsGenerarRemito.Count == 0)
                {
                    MessageBox.Show(@"El Remito NO CONTIENE ITEMS SELECCIONADOS para prearar.",
                        @"Preparcion de Remitos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var itemsSinGenerar = (cantidadItems - cantidadItemsGenerarRemito.Count);

                if (itemsSinGenerar > 0)
                {
                    var dr =
                        MessageBox.Show(
                            string.Format(@"ATENCION: El Remito contiene {0} items SIN MARCAR." + Environment.NewLine +
                                          @"Estos items no estaran disponibles en el remito. Desea Continuar?",
                                itemsSinGenerar),
                            @"Preparcion de Remitos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        using (var f = new FrmSD08ConfirmaPreparacionRemito(_idRemitoSeleccionado.Value))
                        {
                            DialogResult dr0 = f.ShowDialog();
                            if (dr0 == DialogResult.OK)
                            {
                                _statusRemitoSeleccionado = RemitoStatusManager.StatusHeader.Preparado;
                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Se ha cancelado la preparacion del Remito", @"Preparacion Cancelada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    using (var f = new FrmSD08ConfirmaPreparacionRemito(_idRemitoSeleccionado.Value))
                    {
                        DialogResult dr0 = f.ShowDialog();
                        if (dr0 == DialogResult.OK)
                        {
                            _statusRemitoSeleccionado = RemitoStatusManager.StatusHeader.Preparado;
                        }
                        else
                        {
                            btnGenerarRemito.Enabled = false;
                        }
                    }
                }
                UpdateDataSourceHeader(_idRemitoSeleccionado.Value);
                UpdateDgvRemitoItemDataSource();
                SetButtonsStatus(_statusRemitoSeleccionado);
                //btnConfirmarPreparacion.Enabled = false;
                //btnCancelarPreparacion.Enabled = true;
                //btnImprimirPreparacion.Enabled = false;
                //btnGenerarRemito.Enabled = true;
                //btnVisaulizarRemito.Enabled = false;
            }
        }

        private void btnCancelarPreparacion_Click(object sender, EventArgs e)
        {
            if (RemitoStatusManager.AllowRemitoDespreparar(_idRemitoSeleccionado.Value) == false)
            {
                MessageBox.Show(@"El Estado del Remito no permite ejecutar esta accion", @"Error al ejecutar Accion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dialogResult = MessageBox.Show(@"Confirma la colocacion del Remito en Modo En PREPARACION?",
                @"Preparacion del Remito", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                RemitoStatusManager.SetStatusHeaderEnPreparacion(_idRemitoSeleccionado.Value);
                UpdateDgvRemitoItemDataSource();
                UpdateDataSourceHeader(_idRemitoSeleccionado.Value);
                SetButtonsStatus(_statusRemitoSeleccionado);

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVisaulizarRemito_Click(object sender, EventArgs e)
        {
            if (_idRemitoSeleccionado == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Remito de la Lista para poder visualizarlo",
                    @"Datos No Seleccionados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            if (RemitoStatusManager.AllowRemitoVisualizar(_idRemitoSeleccionado.Value) == false)
            {
                MessageBox.Show(@"El Estado del Remito no permite ejecutar esta accion", @"Error al ejecutar Accion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var f = new FrmImpresionRemito(_idRemitoSeleccionado.Value);
            f.Show();
            this.Close();
        }

        private void btnImprimirPreparacion_Click(object sender, EventArgs e)
        {
            var f0 = new RpvPreparacionPedido(_idRemitoSeleccionado.Value);
            f0.Show();
        }

        private void btnCancelarRemitoInicial_Click(object sender, EventArgs e)
        {
            DialogResult drx;
            switch (_statusRemitoSeleccionado)
            {
                case RemitoStatusManager.StatusHeader.Inicial:
                    drx = MessageBox.Show(@"Confirma la cancelacion del REMITO Inicial?",
                        @"Cancelacion de Remito Inicial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (drx == DialogResult.No)
                        return;

                    if (new RemitoHeaderManager().EliminaRemito(_idRemitoSeleccionado.Value) == false)
                    {
                        MessageBox.Show(@"No se ha podido cancelar este remito", @"Error en Cancelacion de Remito",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(@"Se ha Eliminado este Remito correctamente", @"Cancelacion Exitosa",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                case RemitoStatusManager.StatusHeader.EnPreparacion:
                    drx = MessageBox.Show(@"Confirma la cancelacion del REMITO Inicial?",
                        @"Cancelacion de Remito Inicial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (drx == DialogResult.No)
                        return;

                    if (new RemitoHeaderManager().EliminaRemito(_idRemitoSeleccionado.Value) == false)
                    {
                        MessageBox.Show(@"No se ha podido cancelar este remito", @"Error en Cancelacion de Remito",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(@"Se ha Eliminado este Remito correctamente", @"Cancelacion Exitosa",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case RemitoStatusManager.StatusHeader.Preparado:
                    MessageBox.Show(@"Operacion no Autorizada -> Cancele Preparacion de Pedido",
                        @"Operacion no Autorizada", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                case RemitoStatusManager.StatusHeader.Error:
                    MessageBox.Show(@"Operacion no Autorizada", @"Operacion no Autorizada", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                case RemitoStatusManager.StatusHeader.Generado:
                    break;
                case RemitoStatusManager.StatusHeader.Impreso:
                    MessageBox.Show(@"Operacion no Autorizada", @"Operacion no Autorizada", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                case RemitoStatusManager.StatusHeader.Cancelado:
                    MessageBox.Show(@"Operacion no Autorizada", @"Operacion no Autorizada", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                case RemitoStatusManager.StatusHeader.StandBy:
                    MessageBox.Show(@"Operacion no Autorizada", @"Operacion no Autorizada", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            UpdateDataSourceHeader();
        }

        private void btnNingunEstado_Click(object sender, EventArgs e)
        {
            ckEnPreparacion.Checked = false;
            ckPreparado.Checked = false;
            ckInicial.Checked = false;
            ckGenerado.Checked = false;
            ckStandBy.Checked = false;
            ckImpreso.Checked = false;

            _ckStatus = new bool[6]
            {
                ckInicial.Checked, ckEnPreparacion.Checked, ckPreparado.Checked, ckGenerado.Checked, ckImpreso.Checked,
                ckStandBy.Checked
            };
        }

        private void btnAllEstados_Click(object sender, EventArgs e)
        {
            ckEnPreparacion.Checked = true;
            ckPreparado.Checked = true;
            ckInicial.Checked = true;
            ckGenerado.Checked = true;
            ckStandBy.Checked = true;
            ckImpreso.Checked = true;

            _ckStatus = new bool[6]
            {
                ckInicial.Checked, ckEnPreparacion.Checked, ckPreparado.Checked, ckGenerado.Checked, ckImpreso.Checked,
                ckStandBy.Checked
            };
        }

        private void btnVisualizarFactura_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            new RemitoItemManager().ConsolidaItemsRemitoSinAsignar(_idRemitoSeleccionado.Value);
            UpdateDgvRemitoItemDataSource();
        }




        #region ComboBox Seleccion cliente

        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)

                return;
            _listHeader = new CFRemitoManager().GetDataSourceCentroFacturacion(_ckStatus,
                Convert.ToInt32(txtMaxRecords.Text));
            AplicaFiltro();
        }

        private void cmbRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            //valida que el cliente este en la lista
            if (cmbRazonSocial.SelectedValue == null && cmbRazonSocial.Text != string.Empty)
                e.Cancel = true;
        }

        private void cmbRazonSocial_TextUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbRazonSocial.Text))
            {
                AplicaFiltro();
            }
        }

        #endregion

    }
}