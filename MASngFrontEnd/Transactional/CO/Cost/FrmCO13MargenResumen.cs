using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.CO.Costos;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO13MargenResumen : Form
    {
        public FrmCO13MargenResumen()
        {
            InitializeComponent();
        }

        private List<MargenOperacionR2Structure> _data;

        private void FrmCO13MargenResumen_Load(object sender, EventArgs e)
        {
            this.cmbVendedor.SelectedIndexChanged -= new System.EventHandler(this.cmbVendedor_SelectedIndexChanged);
            this.dtpRemitoDesde.ValueChanged -= new System.EventHandler(this.dtpRemitoDesde_ValueChanged);
            dtpRemitoDesde.Value = DateTime.Today.AddDays(-180);
            _data = MargenOperacionR2.GetMargenOPDataDgvComplete(GlobalApp.CnnApp, dtpRemitoDesde.Value);
            MargenBs.DataSource = _data.ToList();
            cmbTipo.DataSource = new MaterialTypeManager().GetListMtype(true);
            cmbVendedor.DataSource = new HumanResourcesManager().GetListAllActiveVendedor();
            cmbTipo.SelectedIndex = -1;
            cmbVendedor.SelectedIndex = -1;
            this.cmbVendedor.SelectedIndexChanged += new System.EventHandler(this.cmbVendedor_SelectedIndexChanged);
            this.dtpRemitoDesde.ValueChanged += new System.EventHandler(this.dtpRemitoDesde_ValueChanged);
            dgvData.DataSource = _data.ToList();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            int xIdRemito = Convert.ToInt32(datagridview[__idRemito.Name, e.RowIndex].Value);
            int xIdRemitoItem = Convert.ToInt32(datagridview[__idItemRemito.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "View":
                    using (var f0 = new FrmCO15DetalleMop(xIdRemitoItem, xIdRemito))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                        }
                    }
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void rbSoloCobrado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSoloCobrado.Checked)
            {

            }
            else
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicaFiltro();
        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicaFiltro();
        }

        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            AplicaFiltro();
        }

        private void AplicaFiltro()
        {
            var _xlista = new List<MargenOperacionR2Structure>(_data).OrderByDescending(c => c.FechaRemito.Value)
                .ToList();

            if (!string.IsNullOrEmpty(txtMaterial.Text))
            {
                _xlista = _xlista.Where(c => c.Material.Contains(txtMaterial.Text)).ToList();
            }

            if (cmbTipo.SelectedIndex != -1)
            {
                string tipo = cmbTipo.SelectedValue.ToString();
                _xlista = _xlista.Where(c => c.MType == tipo).ToList();
            }

            if (cmbVendedor.SelectedIndex != -1)
            {
                _xlista = _xlista.Where(c => c.Vendedor == cmbVendedor.SelectedValue.ToString()).ToList();
            }

            dgvData.DataSource = _xlista;
        }

        private void pboxReset_Click(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = -1;
            cmbVendedor.SelectedIndex = -1;
            txtMaterial.Text = null;
            dgvData.DataSource = _data;
        }

        private void dtpRemitoDesde_ValueChanged(object sender, EventArgs e)
        {
            _data = MargenOperacionR2.GetMargenOPDataDgvComplete(GlobalApp.CnnApp, dtpRemitoDesde.Value);
            MessageBox.Show(@"Se ha Actualizado la lista maestra aplicando el nuevo filtro de fecha remito",
                @"Lista Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AplicaFiltro();
            //dgvData.DataSource = _data;
        }

        private void btnRecomponer_Click(object sender, EventArgs e)
        {
            int a = 30328;
            int b = 30328;

            for (var i = a; i <= b; i++)
            {
                new MargenDocument().AddMargenDocumentAndMapCost(i);
            }

            //    //
            new MargenDocument().UpdateRemito_FacturaData(31358);
            new MargenDocument().UpdateStatusCobranza(31358);


            var f = new FrmCO13MargenResumen();
            f.Show();
        }



        private void btnAltaTest_Click(object sender, EventArgs e)
        {
            new MargenDocument().AddItemNotaCredito(2823);
        }



        private void rbVerNoIncluidos_Click(object sender, EventArgs e)
        {
            using (var x = new FrmCO16_MopSinRegistrar())
            {
                x.ShowDialog();
            }
        }

        private void rbDelete_Click(object sender, EventArgs e)
        {
            //aca abrir una interfaz - preguntar fecha desde - fecha hasta
            //mostrar y eliminanr
        }
    }
}
