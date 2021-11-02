using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData.Customer_Master;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using TecserEF.Entity.DataStructure;
using TSControls;

namespace MASngFE.Transactional.SD.SalesOrder
{
    public partial class FrmSD01SalesOrderSearch : Form
    {
        public FrmSD01SalesOrderSearch()
        {
            InitializeComponent();
        }

        public FrmSD01SalesOrderSearch(int modo)
        {
            _modo = modo;
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------------------------
        private readonly int _modo;
        private int? _idClienteSelect;
        private List<DsSalesOrderList> _soCompleteList = new List<DsSalesOrderList>();
        private int maxValue;
        //-----------------------------------------------------------------------------------------------------
        private void FrmSalesOrderSearch_Load(object sender, EventArgs e)
        {
            maxValue = 1000;
            cmax.SetValue = maxValue;
            _soCompleteList = new DsSalesOrderList().GetAllData(GlobalApp.CnnApp,maxValue); //GetComplete List
            dgvListadoSO.DataSource = _soCompleteList;
            dgvListadoSO.ClearSelection();
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                ConfiguraDefaultValues();
            }
        }
        private void ConfiguraDefaultValues()
        {
            switch (_modo)
            {
                case 1:
                    dgvListadoSO.Enabled = true; //por simplicidad permitimos editar el dgv en modo1
                    btnNuevaSO.Enabled = true;
                    break;
                case 2:
                    dgvListadoSO.Enabled = true;
                    btnNuevaSO.Enabled = true;
                    break;
                case 3:
                    btnNuevaSO.Enabled = false;
                    break;
                default:

                    break;
            }
        }
        private void dgvListadoSO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var idSalesOrder = Convert.ToInt32(dgvListadoSO[dgvListadoSO.Columns[0].Index, e.RowIndex].Value);
            switch (senderGrid.CurrentCell.Value.ToString())
            {
                case "View":
                    var f0 = new FrmSD02SalesOrderMain(3, idSalesOrder);
                    f0.Show();
                    this.Close();
                    break;
                case "Edit":
                    if (_modo == 3)
                    {
                        MessageBox.Show(@"Este modo no está disponible en esta transaccion", @"Modo no disponible",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    var f1 = new FrmSD02SalesOrderMain(2, idSalesOrder);
                    f1.Show();
                    this.Close();
                    break;
                default:
                    MessageBox.Show(@"Este boton no se encuentra manejado", @"Aplicacion en desarrollo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btnNuevaSO_Click(object sender, EventArgs e)
        {
            if (_idClienteSelect == null)
            {
                MessageBox.Show(@"Para crear una nueva Sales Order (SO) debe seleccionar el cliente",
                    @"Creacion de nueva Sales Order / Orden de Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (new CustomerManager().IsActivo(_idClienteSelect.Value) == false)
            {
                MessageBox.Show(@"No se puede crear una nueva SO para este cliente porque se encuentra INACTIVO",
                    @"Cliente Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var f0 = new FrmSD02SalesOrderMain(_idClienteSelect.Value);
            f0.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnVerCliente_Click(object sender, EventArgs e)
        {
            if (_idClienteSelect == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Cliente para Visualizar", @"Cliente NO Seleccionado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new FrmMdc02BillTo(3, _idClienteSelect.Value, "MD"))
            {
                f.ShowDialog();
            }
        }
        private void CustomerFilter_ClienteModificado(object source, _0TSUserControls.CustomerSearchUcV3Args args)
        {
            if (CustomerFilter.ClienteId < 1 || CustomerFilter.ClienteId==null)
            {
                //select all
                _idClienteSelect = -1;
                dgvListadoSO.DataSource = _soCompleteList.OrderByDescending(c=>c.SO).ToList();
                btnNuevaSO.Enabled = false;
            }
            else
            {
                _idClienteSelect = CustomerFilter.ClienteId;
                dgvListadoSO.DataSource = new DsSalesOrderList().GetByCustomer(_idClienteSelect.Value, GlobalApp.CnnApp)
                        .OrderByDescending(c => c.SO).ToList();
                dgvListadoSO.ClearSelection();
                if (_modo < 2)
                {
                    btnNuevaSO.Enabled = true;
                }
            }
            txtNumeroOv.Text = null;
        }
        private void cmax_Validated(object sender, EventArgs e)
        {
            maxValue = (int) cmax.GetValueDecimal;
            cmax.SetValue = maxValue;
            _soCompleteList = new DsSalesOrderList().GetAllData(GlobalApp.CnnApp, maxValue); //GetComplete List
            CustomerFilter.ClienteId = 0;
            dgvListadoSO.DataSource = _soCompleteList;
            dgvListadoSO.ClearSelection();
        }
        private void txtNumeroOv_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender,e);
        }
        private void txtNumeroOv_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroOv.Text))
            {
                dgvListadoSO.DataSource = _soCompleteList.OrderByDescending(c => c.SO).ToList();
                return;
            }
            int numero = Convert.ToInt32(txtNumeroOv.Text);
            if (numero >1)
            {
                dgvListadoSO.DataSource = _soCompleteList.Where(c => c.SO == numero).OrderByDescending(c => c.SO).ToList();
            }
            else
            {
                dgvListadoSO.DataSource = _soCompleteList.OrderByDescending(c => c.SO).ToList();
            }
        }
    }
}
