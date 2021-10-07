using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TecserEF.Entity.DataStructure.MRP;

namespace MASngFE.Transactional.MM.MRP
{
    public partial class FrmMRP03 : Form
    {
        public FrmMRP03(List<MRP2Struct> data)
        {
            _lista = data;
            InitializeComponent();

        }

        private List<MRP2Struct> _lista;

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMRP03_Load(object sender, EventArgs e)
        {
            mRP2Bs.DataSource = _lista;
        }

        private void DgvMRPCompleto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var material = datagridview[materialMPDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "Detalle":
                    using (var f0 = new FrmMM31ListadoStockMaterial(material))
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
    }
}
