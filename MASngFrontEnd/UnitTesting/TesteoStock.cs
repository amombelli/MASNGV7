using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.MM;

namespace MASngFE.UnitTesting
{
    public partial class TesteoStock : Form
    {
        public TesteoStock()
        {
            InitializeComponent();
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvStock.DataSource = new StockManager().GetTotalStockByMaterial_ByEstado(cmbMaterial.Text);
            dgvTablaStock.DataSource = new StockManager().GetListaStockT0030(cmbMaterial.Text);
            txtKGStockDisponibleDespacho.Text = new StockAvilability().AvailableStockForDespacho(cmbMaterial.Text,
                "CERR").ToString();
            txtKGStockTotal.Text = new StockAvilability().TotalStockInPlant(cmbMaterial.Text,
    "CERR").ToString();

        }

        private void TesteoStock_Load(object sender, EventArgs e)
        {
            ConfigugraCombobox();
            dgvStock.DataSource = new StockManager().GetTotalStockByMaterial_ByEstado(null);
            dgvTablaStock.DataSource = new StockManager().GetListaStockT0030();
        }

        private void ConfigugraCombobox()
        {
            cmbMaterial.DataSource = new MaterialMasterManager().GetCompleteListofMaterial();
            cmbMaterial.ValueMember = "IDMATERIAL";
            cmbMaterial.DisplayMember = "IDMATERIAL";


        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dgvTablaStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var cellValue = dgvTablaStock[0, e.RowIndex];

            txtIdStock.Text = dgvTablaStock[0, e.RowIndex].Value.ToString();
            txtMaterial.Text = dgvTablaStock[1, e.RowIndex].Value.ToString();
            txtEstado.Text = dgvTablaStock[4, e.RowIndex].Value.ToString();
            txtKG.Text = dgvTablaStock[3, e.RowIndex].Value.ToString();

        }

        private void btnSplitStock_Click(object sender, EventArgs e)
        {
            var stockmng = new StockManager();
            stockmng.SplitStock((Convert.ToInt32(txtIdStock.Text)), Convert.ToDecimal(txtNewKG.Text));
        }

        private void btnOptimiza_Click(object sender, EventArgs e)
        {
            new StockManager().OptimizaStockLiberado(cmbMaterial.Text);
        }
    }
}
