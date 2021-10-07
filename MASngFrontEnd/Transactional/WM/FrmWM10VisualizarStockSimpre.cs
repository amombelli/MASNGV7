using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.WM
{
    public partial class FrmWM10VisualizarStockSimpre : Form
    {
        private readonly string _material;
        private List<CqStockStructure> _completeMaterialList = new List<CqStockStructure>();

        public FrmWM10VisualizarStockSimpre(string material)
        {
            _material = material;
            InitializeComponent();
        }

        private void FrmWM10VisualizarStockSimpre_Load(object sender, EventArgs e)
        {
            _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp, _material);
            dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
