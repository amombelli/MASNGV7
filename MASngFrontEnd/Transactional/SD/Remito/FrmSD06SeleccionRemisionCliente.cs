using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using MASngFE.Transactional.SD.SalesOrder;
using MASngFE.Transactional.WM;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.SD;
using Tecser.Business.Transactional.WM;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.SD.Remito
{

    public partial class FrmSD06SeleccionRemisionCliente : Form
    {
        public FrmSD06SeleccionRemisionCliente()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------
        private List<T0056_REMITO_I> _itemList = new List<T0056_REMITO_I>();
        private string _idNumeroRemito = Guid.NewGuid().ToString();
        //-------------------------------------------------------------------------------------------------------------
        private void FrmSeleccionRemisionCliente_Load(object sender, EventArgs e)
        {
            ConfiguraCombobox();
            SetDefaultValues();
            if (new CompromisoManager().CheckIfExistReservaRE(null))
            {
                semRemTemp.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                MessageBox.Show(
                    @"Existe Stock en Estado 'ReservaRE'. Verifique si existe otra instancia de preparacion activa. Caso cotrario intente liberar el stock Reservado",
                    @"Stock Reservado Temporal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //btnVerReservaRE.Enabled = true;
            }
            else
            {
                semRemTemp.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                //btnVerReservaRE.Enabled = false;
            }
        }
        private void ConfiguraCombobox()
        {
            cmbFantasia.ValueMember = "IDCLIENTE";
            cmbFantasia.DisplayMember = "CLI_FANTASIA";

            cmbRazonSocial.ValueMember = "IDCLIENTE";
            cmbRazonSocial.DisplayMember = "CLI_RSOCIAL";

            var customers = new CustomerManager();
            cmbRazonSocial.DataSource = customers.GetCompleteListofBillTo(false);
            cmbFantasia.DataSource = customers.GetCompleteListofBillTo(false);
            cmbFantasia.SelectedIndex = -1;
            cmbRazonSocial.SelectedIndex = -1;
        }
        private void SetDefaultValues()
        {
            ckSoloStock.Checked = true;
            ckImpresionAutmaticaPreparacion.Checked = true;
            txtId6.Text = null;
            txtId7.Text = null;
            btnCancelarAsignacion.Enabled = false;
            btnConsolidarItems.Enabled = false;
            btnEnviarPreparacion.Enabled = false;
            btnSalir.Enabled = true;
        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFantasia.SelectedIndex > 0)
            {
                cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
                txtId6.Text = cmbFantasia.SelectedValue.ToString();
            }
            else
            {
                txtId6.Text = null;
                cmbRazonSocial.SelectedIndex = -1;
            }
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex > 0)
            {
                cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
                txtId6.Text = cmbRazonSocial.SelectedValue.ToString();
                cdStructureBs.DataSource =
                    new CDListManager().GetListPendientesDespachoCliente(Convert.ToInt32(txtId6.Text));
            }
        }
        private void dgvOrdenVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Mueve items al dgv de remito si se presion el boton ADD
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvOrdenVenta[e.ColumnIndex, e.RowIndex].Value.ToString();
                var id7 = dgvOrdenVenta[dgvOrdenVenta.Columns["idCliente7"].Index, e.RowIndex].Value.ToString();
                var idOv = Convert.ToInt32(dgvOrdenVenta[dgvOrdenVenta.Columns["xidov"].Index, e.RowIndex].Value);
                var idItem = Convert.ToInt32(dgvOrdenVenta[dgvOrdenVenta.Columns["xiditem"].Index, e.RowIndex].Value);
                var id6 = new CustomerManager().GetId6FromCustomerT7(Convert.ToInt32(id7));

                switch (cellValue)
                {
                    case "ADD":
                        if (string.IsNullOrEmpty(txtId7.Text))
                        {
                            //agrega directamente el item al remito ya que es el primer item del remito
                            txtId7.Text = id7;
                            if (cmbFantasia.SelectedIndex == -1)
                            {
                                //se agregdo desde la interfaz de view-all completa datos
                                cmbFantasia.SelectedValue = id6;
                            }
                        }
                        else
                        {
                            if (id7 != txtId7.Text)
                            {
                                //chequea si corresponde agregar >> el idcliente 7 no puede ser diferente
                                MessageBox.Show(
                                    @"El Cliente de entrega es diferente al primer cliente de entrega seleccionado",
                                    @"Error en Seleccion de Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        AgregaItemRemitoListaMemoria(idOv, idItem);
                        ChequeaItemLista();
                        btnViewAll.Enabled = false;
                        break;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private bool ValidaItemNotPreviouslyAdded(int idOv, int idOvItem)
        {
            if (_itemList.Find(c => c.IDOV == idOv && c.IDOVITEM == idOvItem) == null) return true;
            MessageBox.Show(@"El item ya ha sido agregado al remito en proceso", @"Error en Seleccion de Item",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void AgregaItemRemitoListaMemoria(int idOv, int idOvItem)
        {
            if (ValidaItemNotPreviouslyAdded(idOv, idOvItem) == false) return;

            //Genera desde el item OV un nuevo Item Remito con los datos para ser agregado a la lista.-
            var reItemToAdd = AddNewItemToRemitoListFromOrdenVenta(idOv, idOvItem);

            //Toma el Item que esta intentando agregar y asigna un Lote comprometido en caso que haya.
            //Si no encuentra en lote deja null.-
            //Retorna una lista con 1 o mas items que es el Item Original con split si fue necesario al asingar el stock 
            var lstItemToAdd = new StockBatchManageRE().AsignaLoteComprometido(reItemToAdd);

            for (var i = 0; i < lstItemToAdd.Count; i++)
            {
                if (string.IsNullOrEmpty(lstItemToAdd[i].BATCH) == false)
                {
                    //Si tiene un batch asignado lo agrega a la lista para visualizar
                    _itemList.Add(lstItemToAdd[i]);
                }
                else
                {
                    if (ckAsignaLoteAutomaticamente.Checked == true)
                    {
                        var lstLoteAsignado = new StockBatchManageRE().ManageAsignaLoteLiberado(lstItemToAdd[i]);
                        for (var z = 0; z < lstLoteAsignado.Count; z++)
                        {
                            //tenga o no tenga batch lo agrega a la lista!
                            _itemList.Add(lstLoteAsignado[z]);
                        }
                    }
                }
            }
            AsignaStatusItemsRemitoListaMemoria();
            RefrescaDataSourceRemitos();
        }

        private void AgregaItemRemitoListaMemoriaORI(int idOv, int idOvItem)
        {
            if (_itemList.Find(c => c.IDOV == idOv && c.IDOVITEM == idOvItem) != null)
            {
                MessageBox.Show(@"El item ya ha sido agregado al remito en proceso", @"Error en Seleccion de Item",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Genera un nuevo Item con los datos para ser agregado a la lista.-
            var item = AddNewItemToRemitoListFromOrdenVenta(idOv, idOvItem);

            //Manejo de lote comprometido
            var itemBatch = new StockBatchManageRE().AsignaLoteComprometido(item);
            if (string.IsNullOrEmpty(itemBatch[0].BATCH) == false)
            {
                item.idStockComprometido = itemBatch[0].idStockComprometido;
                item.KGDESPACHADOS = itemBatch[0].KGDESPACHADOS;
                item.BATCH = itemBatch[0].BATCH;
                if (itemBatch.Count > 1)
                {
                    for (int i = 1; i < itemBatch.Count; i++)
                    {
                        _itemList.Add(itemBatch[i]);
                    }
                }
            }
            else
            {
                if (ckAsignaLoteAutomaticamente.Checked)
                {
                    var itemBatch0 = new StockBatchManageRE().ManageAsignaLoteLiberado(item);
                    item.KGDESPACHADOS = itemBatch0[0].KGDESPACHADOS;
                    item.BATCH = itemBatch0[0].BATCH;

                    item.idStockComprometido = itemBatch0[0].idStockComprometido;
                    item.SLOC = itemBatch0[0].SLOC;
                    if (itemBatch0.Count > 1)
                    {
                        for (int i = 1; i < itemBatch0.Count; i++)
                        {
                            _itemList.Add(itemBatch0[i]);
                        }
                    }
                }
            }
            _itemList.Add(item);
            AsignaStatusItemsRemitoListaMemoria();
            RefrescaDataSourceRemitos();
        }

        private void AsignaStatusItemsRemitoListaMemoria()
        {
            double StockLiberado = 0;
            double StockTotal = 0;
            int i = 0;

            foreach (var xitem in _itemList)
            {
                xitem.IDITEM = ++i;
                if (xitem.idStockComprometido != null)
                {
                    xitem.STATUSITEM = RemitoStatusManager.StatusStockMemoria.Reservado.ToString();
                    xitem.GENERAR_REMITO = true;
                }
                else
                {
                    StockLiberado = new StockAvilability().AvailableStockForDespacho(xitem.MATERIAL, "CERR");
                    StockTotal = new StockAvilability().TotalStockInPlant(xitem.MATERIAL);
                    if (StockTotal > 0)
                    {
                        if (xitem.KGDESPACHADOS <= (decimal)StockLiberado)
                        {
                            xitem.STATUSITEM = RemitoStatusManager.StatusStockMemoria.StockOK.ToString();
                            xitem.GENERAR_REMITO = true;
                        }
                        else
                        {
                            xitem.STATUSITEM = RemitoStatusManager.StatusStockMemoria.StockBlock.ToString();
                            xitem.GENERAR_REMITO = true;
                        }
                    }
                    else
                    {
                        xitem.STATUSITEM = RemitoStatusManager.StatusStockMemoria.SinStock.ToString();
                        xitem.GENERAR_REMITO = false;
                    }
                }
            }
        }
        private void AddLineaTotal()
        {
            decimal kgRemito = (decimal)0.00;
            decimal kgConLote = (decimal)0.00;

            foreach (var item in _itemList)
            {
                kgRemito += item.KGDESPACHADOS;
                if (item.STATUSITEM != "UNKNOWN")
                    kgConLote += item.KGDESPACHADOS;
            }

            txtKgLoteAsignado.Text = kgConLote.ToString("N2");
            txtKGAgregadosRemito.Text = kgRemito.ToString("N2");
            txtIdRemitoTemporal.Text = _idNumeroRemito;
        }
        private void RemoveLineaTotal()
        {
            var footer = _itemList.Find(c => c.MATERIALAKA == ">>>>> TOTAL KG A DESPACHAR >>>");
            if (footer != null)
            {
                _itemList.Remove(footer);
                for (var i = 0; i < dgvRemitos.Columns.Count; i++)
                {
                    dgvRemitos.Rows[dgvRemitos.Rows.Count - 1].Cells[i].Style.BackColor = DefaultBackColor;
                    dgvRemitos.Rows[dgvRemitos.Rows.Count - 1].Cells[i].Style.ForeColor = DefaultForeColor;
                }
            }
        }
        private void RefrescaDataSourceRemitos()
        {
            RemoveLineaTotal();
            dgvRemitos.DataSource = null;
            ConsolidaItemsEnMemoria(); //En Memoria
            AsignaStatusItemsRemitoListaMemoria();
            dgvRemitos.DataSource = _itemList;
            AddLineaTotal();
        }
        private T0056_REMITO_I AddNewItemToRemitoListFromRemitoList(int idList, decimal newKg)
        {
            var item = new T0056_REMITO_I();
            var elemento = _itemList.Find(c => c.IDITEM == idList);

            item.NUMREMITO = _idNumeroRemito;
            item.IDITEM = _itemList.Count + 1;
            item.IDOV = elemento.IDOV;
            item.IDOVITEM = elemento.IDOVITEM;
            item.MATERIAL = elemento.MATERIAL;
            item.MATERIALAKA = elemento.MATERIALAKA;
            item.KGINI = elemento.KGINI;
            item.KGDESPACHADOS = newKg;
            item.KGDESPACHADOS_R = newKg;
            item.KG_PENDIENTES = new StockList().GetKgStockDisponibleDespacho(item.MATERIAL, "CERR");
            item.MATERIAL = elemento.MATERIAL;
            item.L5 = elemento.L5;
            item.LX = elemento.LX;
            item.DESC_REMITO = elemento.DESC_REMITO;
            return item;
        }
        private T0056_REMITO_I AddNewItemToRemitoListFromOrdenVenta(int idOV, int idOVItem)
        {
            RemoveLineaTotal();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == idOV && c.IDITEM == idOVItem);
                var item = new T0056_REMITO_I
                {
                    NUMREMITO = _idNumeroRemito,
                    IDITEM = _itemList.Count + 1,
                    IDOV = idOV,
                    IDOVITEM = idOVItem,
                    MATERIAL = data.materialPrimario,
                    MATERIALAKA = data.Material,
                    KGINI = data.Cantidad - data.KGStockDespachados,
                };
                item.KGDESPACHADOS = item.KGINI;
                item.KGDESPACHADOS_R = item.KGINI;
                item.KG_PENDIENTES = new StockList().GetKgStockDisponibleDespacho(item.MATERIAL, "CERR");
                item.MATERIAL = data.materialPrimario;

                if (data.KGStockDespachados == null)
                    data.KGStockDespachados = 0;

                if (data.MODO == "L5")
                {
                    item.L5 = true;
                    item.LX = "L1";
                    item.DESC_REMITO = new MaterialMasterManager().GetSpecificAkaInformation(data.Material).MAT_DESC_L5;
                }
                else
                {
                    item.L5 = false;
                    item.LX = data.MODO;
                    item.DESC_REMITO = new MaterialMasterManager().GetSpecificAkaInformation(data.Material).MAT_DESC2;
                }
                return item;
            }
        }
        private void ChequeaItemLista()
        {
            if (_itemList.Count == 0)
            {
                //La lista ya no contiene items. - Permite comenzar de nuevo
                cmbFantasia.Enabled = true;
                cmbRazonSocial.Enabled = true;
                txtId7.Text = null;
                txtId6.Text = null;

                btnCancelarAsignacion.Enabled = false;
                btnConsolidarItems.Enabled = false;
                btnEnviarPreparacion.Enabled = false;
                btnSalir.Enabled = true;
                btnViewAll.Enabled = true;
            }
            else
            {
                //La lista contiene items - No permite ciertas acciones
                cmbFantasia.Enabled = false;
                cmbRazonSocial.Enabled = false;
                btnCancelarAsignacion.Enabled = true;
                btnConsolidarItems.Enabled = true;
                btnEnviarPreparacion.Enabled = true;
                // btnSalir.Enabled = false;
            }
        }

        private void dgvRemitos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex < 0)
            {
                MessageBox.Show(@"Realizar DobleClick en este lugar NO realiza ninguna accion",
                    @"Funcionalidad No Existente", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //Remueve item del Dgv si se presiona DEL
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvRemitos[e.ColumnIndex, e.RowIndex].Value.ToString();
                switch (cellValue)
                {
                    case "QUITAR":
                        int idStockSeleccionado = Convert.ToInt32(dgvRemitos[dgvRemitos.Columns["idStockComprometido"].Index, e.RowIndex].Value);
                        int iditem = (int)dgvRemitos[dgvRemitos.Columns[iditem_dgv.Name].Index, e.RowIndex].Value;
                        RemoveItemRemitoMemoria(iditem);
                        ChequeaItemLista();
                        //MessageBox.Show(@"Se ha removido el material del remito",@"Material Removido",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        break;

                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
            else
            {

                if (e.ColumnIndex == dgvRemitos.Columns["numlote_dgv"].Index && e.RowIndex >= 0)
                {
                    //--- Manejo de Asignacion/Liberacion de Lote ---
                    string materialX = dgvRemitos[dgvRemitos.Columns["material_dgv"].Index, e.RowIndex].Value.ToString();
                    decimal kg = (decimal)dgvRemitos[dgvRemitos.Columns["kg_dgv"].Index, e.RowIndex].Value;

                    if (dgvRemitos[dgvRemitos.Columns["numlote_dgv"].Index, e.RowIndex].Value == null)
                    {
#pragma warning disable CS0219 // The variable 'loteSeleccionado' is assigned but its value is never used
                        string loteSeleccionado = null;
#pragma warning restore CS0219 // The variable 'loteSeleccionado' is assigned but its value is never used
                    }
                    else
                    {
                        string loteSeleccionado =
                            dgvRemitos[dgvRemitos.Columns["numlote_dgv"].Index, e.RowIndex].Value.ToString();
                    }


                    int iditem = (int)dgvRemitos[dgvRemitos.Columns[iditem_dgv.Name].Index, e.RowIndex].Value;
                    int idStockSeleccionado =
                        Convert.ToInt32(dgvRemitos[dgvRemitos.Columns[idStockComprometido.Name].Index, e.RowIndex].Value);
                    RemoveLineaTotal();
                    using (var f1 = new FrmSeleccionBatchDespacho(materialX, kg))
                    {
                        DialogResult dr = f1.ShowDialog();
                        switch (dr)
                        {
                            case DialogResult.OK:

                                if (idStockSeleccionado > 0)
                                {
                                    MessageBox.Show(
                                        @"Se ha liberado el stock reservado  con anterioridad y se ha asignado el nuevo lote para este remito",
                                        @"Liberacion Stock ReservadoOK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    new CompromisoManager().FreeStockComprometidoByIdstock(idStockSeleccionado, true);
                                }

#pragma warning disable CS1690 // Accessing a member on 'FrmSeleccionBatchDespacho.IdStockSeleccionado' may cause a runtime exception because it is a field of a marshal-by-reference class
                                var idstk = f1.IdStockSeleccionado.Value;
#pragma warning restore CS1690 // Accessing a member on 'FrmSeleccionBatchDespacho.IdStockSeleccionado' may cause a runtime exception because it is a field of a marshal-by-reference class
                                var kgsel = (decimal)f1.KgSeleccionados;
                                var itemList = _itemList.Find(c => c.IDITEM == iditem);
                                new StockBatchManagerSD().ReservaStockRemitoByRemitoGUID(idstk, kgsel, _idNumeroRemito, itemList.IDOV.Value, itemList.IDOVITEM.Value);

                                if (kg > kgsel)
                                {
                                    var newItem = AddNewItemToRemitoListFromRemitoList(iditem, kg - kgsel);
                                    _itemList.Add(newItem);
                                }
                                itemList.KGDESPACHADOS = kgsel;
                                itemList.BATCH = f1.BatchSeleccionado;
                                itemList.idStockComprometido = idstk;
                                itemList.STATUSITEM = RemitoStatusManager.StatusStockMemoria.Reservado.ToString();
                                itemList.SLOC = f1.SlocSeleccionado;
                                RefrescaDataSourceRemitos();
                                break;

                            case DialogResult.Cancel:
                                if (idStockSeleccionado > 0)
                                {
                                    MessageBox.Show(@"Se ha liberado el stock reservado para este remito",
                                        @"Liberacion Stock ReservadoOK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    new CompromisoManager().FreeStockComprometidoByIdstock(idStockSeleccionado, false);
                                    var itemList0 = _itemList.Find(c => c.IDITEM == iditem);
                                    itemList0.BATCH = null;
                                    itemList0.BATCH_REMITO = null;
                                    itemList0.SLOC = null;
                                    itemList0.idStockComprometido = null;
                                    itemList0.STATUSITEM = RemitoStatusManager.StatusStockMemoria.SinValidar.ToString();
                                    RefrescaDataSourceRemitos();
                                    idStockSeleccionado = 0;
                                }
                                break;

                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }
        }
        private void RemoveItemRemitoMemoria(int idItemRemito)
        {
            var item = _itemList.Find(c => c.IDITEM == idItemRemito);
            if (item.idStockComprometido != null)
            {
                new CompromisoManager().FreeStockComprometidoByIdstock(item.idStockComprometido.Value, false);
            }
            _itemList.Remove(item);
            RefrescaDataSourceRemitos();
        }

        private void ConsolidaItemsEnMemoria()
        {
            var newList = new List<T0056_REMITO_I>();
            var listaDb = _itemList.FindAll(c => c.BATCH != null).ToList();
            foreach (var item in _itemList.Where(c => c.BATCH == null))
            {
                var lista =
                    _itemList.FindAll(
                        c =>
                            c.MATERIALAKA == item.MATERIALAKA && c.BATCH == item.BATCH && c.IDOV == item.IDOV &&
                            c.IDOVITEM == item.IDOVITEM && item.RLINK != 999).ToList();

                if (lista.Count > 0)
                {
                    decimal kg = 0;
                    for (var i = 0; i < lista.Count; i++)
                    {
                        kg += lista[i].KGDESPACHADOS;
                        lista[i].RLINK = 999;
                    }
                    lista[0].KGDESPACHADOS = kg;
                    newList.Add(lista[0]);
                }

            }

            foreach (var item in newList)
            {
                item.RLINK = 0;
            }


            _itemList = newList;
            _itemList.AddRange(listaDb);
        }

        private void OptmizaListaItemsRemitoNew(List<T0030_STOCK> listaStockReservaDb)
        {
            var newList = new List<T0056_REMITO_I>();

            foreach (var stk in listaStockReservaDb)
            {
                var lista =
                    _itemList.FindAll(
                        c =>
                            c.MATERIAL == stk.Material && c.BATCH == stk.Batch && c.IDOV == stk.OV_Reserva &&
                            c.IDOVITEM == stk.ReservaItem).ToList();

                for (var i = 0; i < lista.Count; i++)
                {
                    if (i == 0)
                    {
                        lista[0].KGDESPACHADOS = stk.Stock;
                        lista[0].idStockComprometido = stk.IDStock;
                        lista[0].KGDESPACHADOS_R = stk.Stock;
                    }
                    else
                    {
                        lista.Remove(lista[i]);
                    }
                }
                newList.Add(lista[0]);
            }

            foreach (var item in _itemList)
            {
                if (item.idStockComprometido == null)
                {
                    newList.Add(item);
                }
            }

            foreach (var item in newList)
            {
                item.RLINK = 0;
            }
            _itemList = newList;
        }
        private void btnConsolidarItems_Click(object sender, EventArgs e)
        {
            //optimiza stock en Db
            ConsolidaItemsStockDb();

        }
        private void BlanqueaForm()
        {
            //La lista ya no contiene items. - Permite comenzar de nuevo
            cmbFantasia.Enabled = true;
            cmbRazonSocial.Enabled = true;
            cmbFantasia.SelectedIndex = -1;
            cmbRazonSocial.SelectedIndex = -1;
            txtId7.Text = null;
            txtId6.Text = null;
            _itemList.Clear();
            dgvOrdenVenta.DataSource = null;
            dgvRemitos.DataSource = null;
            btnCancelarAsignacion.Enabled = false;
            btnConsolidarItems.Enabled = false;
            btnEnviarPreparacion.Enabled = false;
            btnSalir.Enabled = true;
            txtIdRemitoTemporal.Text = null;
            txtKGAgregadosRemito.Text = 0.ToString("n2");
            txtKgLoteAsignado.Text = 0.ToString("n2");
            cdStructureBs.DataSource = null;
            dgvOrdenVenta.DataSource = cdStructureBs;
            dgvRemitos.DataSource = itemRemitoBs;
            _idNumeroRemito = Guid.NewGuid().ToString();
        }
        private void btnEnviarPreparacion_Click(object sender, EventArgs e)
        {
            if (new CustomerManager().CustomerBloqueadoDelivery(Convert.ToInt32(txtId6.Text)))
            {
                MessageBox.Show(
                    @"El Cliente se encuentra BLOQUEADO para DESPACHO. No se puede despachar hasta no haber solucionado su situacion administrativa",
                    @"Cliente Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_itemList.Count == 0)
            {
                MessageBox.Show(
                    @"No se puede enviar a preparacion un Remito sin CostItems" + Environment.NewLine +
                    @"Por favor este mas atento", @"No hay items en el remito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dr = MessageBox.Show(@"Confirma el envio de esta orden a preparacion?",
                       @"Preparacion de Remito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            //La lista tiene items - chequea si todos los items tiene stock asignado
            //Pero si no tiene stock asignado de todas formas permite generar la asignacion
            //por si aparece en la preparacion o se carga en posterior.- 
            foreach (var item in _itemList)
            {
                if (new RemitoItemManager().SetItemPreparacion(item) == false)
                {
                    dr = MessageBox.Show(
                        string.Format(
                            "El Item >{0}< con KG a Despachar = {1} Kg. No contiene un numero de LOTE ASIGNADO" +
                            Environment.NewLine + "Desea Incluirlo de todas formas en Preparacion?", item.MATERIALAKA,
                            item.KGDESPACHADOS.ToString("N2")), @"Item sin LOTE ASIGNADO", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (dr == DialogResult.Yes)
                    {
                        item.GENERAR_REMITO = true;
                    }
                    else
                    {
                        item.GENERAR_REMITO = false;
                    }
                }
            }

            var headerList = new ManageCreacionRemitoInicial().CreacionRemitosSegunTipoSO(_itemList, _idNumeroRemito,
                Convert.ToInt32(txtId7.Text));

            _itemList.Clear();
            btnEnviarPreparacion.Enabled = false;
            var cantidadRemitosPreparar = 0;
            foreach (var item in headerList)
            {
                if (item.L5 == true && item.LX == "L2")
                {
                    //este remito no lo presenta para preparar
                }
                else
                {
                    if (new RemitoItemManager().CantidadItemsRemito(item.IdRemito) > 0)
                    {
                        cantidadRemitosPreparar++;
                        if (ckImpresionAutmaticaPreparacion.Checked)
                        {
                            var f0 = new RpvPreparacionPedido(item.IdRemito);
                            f0.Show();
                        }
                    }
                }
            }
            var dialogResult =
                MessageBox.Show(string.Format("Se han generado {0} Remitos para preparar." + Environment.NewLine + "Desea ir al Centro de Preparacion de Remitos ahora?", cantidadRemitosPreparar),
                        @"Prepracion de Remitos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dialogResult == DialogResult.Yes)
            {
                var f2 = new FrmCentroPreparacionRemitos();
                f2.Show();
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.BlanqueaForm();
            }
        }
        private bool CheckRemitosEnvioPreparacion()
        {
            bool isOK = true;
            return isOK;
        }
        private void btnCancelarAsignacion_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(@"Cancelar la Asignacion eliminara cualquier asingacion de stocks. Desea Continuar?",
                    @"CANCELAR ASIGNACION DE ITEMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            else
            {
                new StockBatchManagerSD().LiberaStockReservadoRemitoGUID(_idNumeroRemito);
                dgvRemitos.DataSource = null;
                _itemList.Clear();

                //La lista ya no contiene items. - Permite comenzar de nuevo
                cmbFantasia.Enabled = true;
                cmbRazonSocial.Enabled = true;
                txtId7.Text = null;
                txtId6.Text = null;
                btnCancelarAsignacion.Enabled = false;
                btnConsolidarItems.Enabled = false;
                btnEnviarPreparacion.Enabled = false;
                btnSalir.Enabled = true;
            }
        }
        private void FrmSeleccionRemisionCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            EliminarRemitoReservado();
        }
        private void EliminarRemitoReservado()
        {
            if (_idNumeroRemito != null)
                new StockBatchManageRE().LiberaStockEnReservaRE(new Guid(_idNumeroRemito));
        }
        private void btnConsolidaItemsMemoria_Click(object sender, EventArgs e)
        {
            ConsolidaItemsEnMemoria();
            RefrescaDataSourceRemitos();
        }
        private void ConsolidaItemsStockDb()
        {
            var lstStk = new StockBatchManageRE().OptimizaLineasStockRemitoDb(new Guid(_idNumeroRemito));
            OptmizaListaItemsRemitoNew(lstStk);
            AsignaStatusItemsRemitoListaMemoria();
            RefrescaDataSourceRemitos();
        }

        private void cmbFantasia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbFantasia);
        }

        private void cmbRazonSocial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbFantasia);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_itemList.Count > 0)
            {
                var r = MessageBox.Show(@"Confirma salir de la preparacion eliminando los datos de preparacion?",
                    @"Confirmacion de Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                {
                    return;
                }
                else
                {
                    EliminarRemitoReservado();
                }
            }
            this.Close();
        }
        private void btnNuevaSO_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId6.Text))
            {
                MessageBox.Show(@"Debe seleccionar un cliente para poder continuar", @"datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            var resp = MessageBox.Show(@"Confirma que desea crear una nueva Sales Order (Orden de Venta)?",
                @"Creacion de SO", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;



            var f0 = new FrmSD02SalesOrderMain(Convert.ToInt32(txtId6.Text));
            f0.Show();
        }
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            cdStructureBs.DataSource =
                new CDListManager().GetListPendientesDespachoCliente(null);
            cmbFantasia.SelectedIndex = -1;
        }
        private void btnVerReservaRE_Click(object sender, EventArgs e)
        {
            using (var f = new FrmWM07LiberarReservaRE(_idNumeroRemito))
            {
                f.ShowDialog();
            }
        }
    }
}
