using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.MM
{
    public partial class FrmMM31ListadoStockMaterial : Form
    {
        public FrmMM31ListadoStockMaterial(string material)
        {
            this._material = material;
            InitializeComponent();
        }

        private readonly string _material;
        private List<CqStockStructure> _completeMaterialList = new List<CqStockStructure>();
        private void FrmMM31ListadoStockMaterial_Load(object sender, EventArgs e)
        {
            ckOcultarPerdido.Checked = false;
            txtMaterial.Text = _material;
            _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto(GlobalApp.CnnApp, _material);
            var filteredList = _completeMaterialList;
            dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(filteredList);
        }

        private void CkOcultarPerdido_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOcultarPerdido.Checked)
            {
                var filteredList = _completeMaterialList.Where(c => c.SLOC.Contains("PER") == false);
                dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(filteredList);
            }
            else
            {
                dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
