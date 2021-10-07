using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData.Customer_Master;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using TecserEF.Entity.DataStructure;

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

        //-------------------------------------------------------------------------------
        private readonly int _modo;
        private int? _idClienteSelect;
        private List<DsSalesOrderList> _soList = new List<DsSalesOrderList>();
        //-------------------------------------------------------------------------------
        private void FrmSalesOrderSearch_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //Cuando Activo la linea de abajo da error al cargar el componente
                //T0006Bs.DataSource = new CustomerManager().GetCompleteListofBillTo(tsckSoloActivo.Value);
                //BlanqueaSeleccion();
                ConfiguraDefaultValues();
            }

        }

        private void ConfiguraDefaultValues()
        {
            //UnBindCombobox();
            //cmbClienteT6.ValueMember = "IDCLIENTE";
            //cmbClienteT6.DisplayMember = "CLI_RSOCIAL";
            //cmbClienteT6.DataSource = new CustomerManager().GetCompleteListofBillTo(ckClienteActivo.Checked).ToList();
            //cmbClienteT6.Text = "";

            //txtIDT6.ValueMember = "IDCLIENTE";
            //txtIDT6.DisplayMember = "IDCLIENTE";
            //txtIDT6.DataSource= new CustomerManager().GetCompleteListofBillTo(ckClienteActivo.Checked).ToList();
            //txtIDT6.Text = "";

            //txtSalesOrderNumberSearch.Text = null;

            ////default values
            //rbRazon.Checked = true;
            //ckClienteActivo.Checked = true;
            //dgvListadoSO.DataSource = null;
            //btnClose.Enabled = true;
            //btnNuevaSO.Enabled = false;
            //btnVerCliente.Enabled = false;
            //ckClienteActivo.Enabled = false;
            //SalesOrderBs.DataSource = _soList;
            //dgvListadoSO.DataSource = SalesOrderBs;

            //BindCombobox();

            switch (_modo)
            {
                case 1:
                    btnNuevaSO.Enabled = true;
                    break;

                case 2:
                    dgvListadoSO.Enabled = true;
                    break;
                case 3:
                    break;
                default:

                    break;

            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnViewAll_Click(object sender, EventArgs e)
        {
            tsUcCustomerSearch11.ClienteId = null;
            _soList = new DsSalesOrderList().GetAllData(GlobalApp.CnnApp);
            SalesOrderBs.DataSource = _soList;
        }
        private void txtSalesOrderNumberSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtSalesOrderNumberSearch_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtSalesOrderNumberSearch.Text))
            //{
            //    SalesOrderBs.DataSource = _soList;
            //}
            //else
            //{
            //    var salesSearch = Convert.ToInt32(txtSalesOrderNumberSearch.Text);
            //    SalesOrderBs.DataSource = _soList.Where(c => c.SO == salesSearch).ToList();
            //}
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
        private void btnNewSalesOrder_Click(object sender, EventArgs e)
        {


        }


        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsUcCustomerSearch11_ClienteModificado(object source, _0TSUserControls.TsCustomerSearchEventArgs args)
        {
            _idClienteSelect = tsUcCustomerSearch11.ClienteId;
            if (tsUcCustomerSearch11.ClienteId == null)
            {
                SalesOrderBs.DataSource = new DsSalesOrderList().GetAllData(GlobalApp.CnnApp).OrderByDescending(c => c.SO).ToList();
            }
            else
            {
                SalesOrderBs.DataSource = new DsSalesOrderList().GetByCustomer(_idClienteSelect.Value, GlobalApp.CnnApp)
                    .OrderByDescending(c => c.SO).ToList();
            }
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
    }
}
