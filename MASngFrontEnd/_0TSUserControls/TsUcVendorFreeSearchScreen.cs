using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.MasterData.Vendor_Master;

namespace MASngFE._0TSUserControls
{
    public partial class TsUcVendorFreeSearchScreen : Form
    {
        public TsUcVendorFreeSearchScreen(ParametroBusquedaVendor param, string busqueda, int cantidadCaracteres)
        {
            _param = param;
            _busqueda = busqueda.ToUpper();
            _cantidadCaracteres = cantidadCaracteres;
            IdVendor = -1;
            InitializeComponent();
        }

        private ParametroBusquedaVendor _param;
        private string _busqueda;
        private int _cantidadCaracteres;
        public int IdVendor { get; private set; }
        private readonly List<StxVendnorSimple> _dataList = new VendorMng2().GetVendorList(false, VendorMng2.OrderBy1.RazonSocial).ToList();
        public enum ParametroBusquedaVendor
        {
            RazonSocial,
            Fantasia,
            Cuit,
            Tipo,
            All
        };

        private void TsUcVendorFreeSearchScreen_Load(object sender, EventArgs e)
        {
            this.cmbTipoProveedor.SelectedIndexChanged -= new System.EventHandler(this.cmbTipoProveedor_SelectedIndexChanged);
            cmbTipoProveedor.DataSource = new VendorManager().GetVendorTypeList(true);
            cmbTipoProveedor.SelectedIndex = -1;
;            this.cmbTipoProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbTipoProveedor_SelectedIndexChanged);

            switch (_param)
            {
                case ParametroBusquedaVendor.RazonSocial:
                    txtBusquedaRazon.Text = _busqueda;
                    StxVendorSimpleBs.DataSource = _dataList.Where(c => c.RazonSocial.ToUpper().Contains(_busqueda))
                        .OrderBy(c => c.RazonSocial).ToList();
                    dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[vendorTypeDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    break;
                case ParametroBusquedaVendor.Fantasia:
                    txtBusquedaFantasia.Text = _busqueda;
                    StxVendorSimpleBs.DataSource = _dataList.Where(c => c.Fantasia.ToUpper().Contains(_busqueda))
                        .OrderBy(c => c.Fantasia).ToList();
                    dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgvData.Columns[vendorTypeDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    break;
                case ParametroBusquedaVendor.Cuit:
                    txtBusquedaCuit.Text = _busqueda;
                    StxVendorSimpleBs.DataSource = _dataList.Where(c => c.Cuit.ToUpper().Contains(_busqueda))
                        .OrderBy(c => c.Cuit).ToList();
                    dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[vendorTypeDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White; 
                    dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    break;
                case ParametroBusquedaVendor.Tipo:
                    //esta busqueda no viene desde el load.-
                    break;
                case ParametroBusquedaVendor.All:
                    StxVendorSimpleBs.DataSource = _dataList.OrderBy(c => c.RazonSocial).ToList();
                    dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[vendorTypeDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            dgvData.ClearSelection();
        }

        private void txtBusquedaRazon_KeyUp(object sender, KeyEventArgs e)
        {
            var data = (TextBox)sender;
            if (data.Name == nameof(txtBusquedaFantasia))
            {
                txtBusquedaRazon.Text = null;
                txtBusquedaCuit.Text = null;
                cmbTipoProveedor.SelectedIndex = -1;
            }
            else
            {
                if (data.Name == nameof(txtBusquedaRazon))
                {
                    txtBusquedaFantasia.Text = null;
                    txtBusquedaCuit.Text = null;
                    cmbTipoProveedor.SelectedIndex = -1;
                }
                else
                {
                    txtBusquedaFantasia.Text = null;
                    txtBusquedaRazon.Text = null;
                    cmbTipoProveedor.SelectedIndex = -1;
                }
            }

            if (string.IsNullOrEmpty(data.Text))
            {
                StxVendorSimpleBs.DataSource = _dataList.OrderByDescending(c => c.VendorId).ToList();
                return;
            }


            if (data.Text.Length >= _cantidadCaracteres)
            {
                _busqueda = data.Text.ToUpper();
                if (data.Name == nameof(txtBusquedaFantasia))
                {
                    StxVendorSimpleBs.DataSource = _dataList.Where(c => c.Fantasia.ToUpper().Contains(_busqueda))
                        .OrderBy(c => c.Fantasia).ToList();

                    dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    dgvData.Columns[vendorTypeDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    if (data.Name == nameof(txtBusquedaRazon))
                    {
                        StxVendorSimpleBs.DataSource = _dataList.Where(c => c.RazonSocial.ToUpper().Contains(_busqueda))
                            .OrderBy(c => c.RazonSocial).ToList();
                        dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                        dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                        dgvData.Columns[vendorTypeDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                        dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        StxVendorSimpleBs.DataSource = _dataList.Where(c => c.Cuit.ToUpper().Contains(_busqueda))
                            .OrderBy(c => c.Cuit).ToList();
                        dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                        dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                        dgvData.Columns[vendorTypeDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                        dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
                dgvData.ClearSelection();
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var cellValue = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "SEL":
                    IdVendor = Convert.ToInt32(dgv[vendorIdDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }

        }

        private void cmbTipoProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //busqueda por tipo
            if (cmbTipoProveedor.SelectedIndex !=-1)
            {
                txtBusquedaRazon.Text = null;
                txtBusquedaFantasia.Text = null;
                txtBusquedaCuit.Text = null;
                _busqueda = cmbTipoProveedor.SelectedValue.ToString();
                _param = ParametroBusquedaVendor.Tipo;
                StxVendorSimpleBs.DataSource = _dataList.Where(c => c.VendorType==(_busqueda))
                    .OrderBy(c => c.RazonSocial).ToList();
                dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                dgvData.Columns[vendorTypeDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightBlue;
                dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void cmbTipoProveedor_TextUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbTipoProveedor.Text))
            {
                dgvData.Columns[razonSocialDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.LightGray;
                dgvData.Columns[fantasiaDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                dgvData.Columns[vendorTypeDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                dgvData.Columns[cuitDataGridViewTextBoxColumn.Index].DefaultCellStyle.BackColor = Color.White;
                StxVendorSimpleBs.DataSource = _dataList.OrderBy(c => c.RazonSocial).ToList();
            }
        }
    }
}
