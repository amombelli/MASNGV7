using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData.Customer;

namespace MASngFE._0TSUserControls
{
    public partial class TsUcCustomerFreeSearch : Form
    {
        private ParametroBusqueda _param;
        private string _busqueda;
        private int _cantidadCaracteres;
        public int IdCliente { get; private set; }
        private readonly List<StxCustomerSimple> _dataList =
            new CustomerMng2().GetCustomerList(false, CustomerMng2.OrderBy1.RazonSocial).ToList();
        public enum ParametroBusqueda
        {
            RazonSocial,
            Fantasia,
            Cuit,
        };
        public TsUcCustomerFreeSearch(ParametroBusqueda param,string busqueda, int cantidadCaracteres)
        {
            _param = param;
            _busqueda = busqueda.ToUpper();
            _cantidadCaracteres = cantidadCaracteres;
            IdCliente = -1;
            InitializeComponent();
        }
        private void TsUcCustomerFreeSearch_Load(object sender, EventArgs e)
        {
            
            switch (_param)
            {
                case ParametroBusqueda.RazonSocial:
                    txtBusquedaRazon.Text = _busqueda;
                    stxCustomerSimpleBindingSource.DataSource = _dataList.Where(c => c.RazonSocial.ToUpper().Contains(_busqueda))
                        .OrderBy(c => c.RazonSocial).ToList();
                    dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    break;
                case ParametroBusqueda.Fantasia:
                    txtBusquedaFantasia.Text = _busqueda;
                    stxCustomerSimpleBindingSource.DataSource = _dataList.Where(c => c.Fantasia.ToUpper().Contains(_busqueda))
                        .OrderBy(c => c.Fantasia).ToList();
                    dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    break;
                case ParametroBusqueda.Cuit:
                    txtBusquedaCuit.Text = _busqueda;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            dgvData.ClearSelection();
        }
        private void txtBusquedaRazon_KeyUp(object sender, KeyEventArgs e)
        {
            var data = (TextBox) sender;

            if (data.Name == nameof(txtBusquedaFantasia))
            {
                txtBusquedaRazon.Text = null;
                txtBusquedaCuit.Text = null;
            }
            else
            {
                if (data.Name == nameof(txtBusquedaRazon))
                {
                    txtBusquedaFantasia.Text = null;
                    txtBusquedaCuit.Text = null;
                }
                else
                {
                    txtBusquedaFantasia.Text = null;
                    txtBusquedaRazon.Text = null;
                }
            }
            
            if (string.IsNullOrEmpty(data.Text))
            {
                stxCustomerSimpleBindingSource.DataSource = _dataList.OrderByDescending(c => c.IdCliente).ToList();
                return;
            }
            
           
            if (data.Text.Length >= _cantidadCaracteres)
            {
                _busqueda = data.Text.ToUpper();
                if (data.Name == nameof(txtBusquedaFantasia))
                {
                    stxCustomerSimpleBindingSource.DataSource = _dataList.Where(c => c.Fantasia.ToUpper().Contains(_busqueda))
                        .OrderBy(c => c.Fantasia).ToList();
                    
                    dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor =Color.White;
                    dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    if (data.Name == nameof(txtBusquedaRazon))
                    {
                        stxCustomerSimpleBindingSource.DataSource = _dataList
                            .Where(c => c.RazonSocial.ToUpper().Contains(_busqueda))
                            .OrderBy(c => c.RazonSocial).ToList();
                        dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                        dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                        dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        //busqueda por CUIT
                        stxCustomerSimpleBindingSource.DataSource = _dataList
                            .Where(c => c.Cuit.ToUpper().Contains(_busqueda))
                            .OrderBy(c => c.Cuit).ToList();
                        dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                        dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                        dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
                dgvData.ClearSelection();
            }
        }
        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView) sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "SEL":
                    IdCliente = Convert.ToInt32(dgv[idClienteDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
    }
}
