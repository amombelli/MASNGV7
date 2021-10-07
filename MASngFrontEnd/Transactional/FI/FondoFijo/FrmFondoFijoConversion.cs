using System;
using System.Windows.Forms;
using MASngFE.Transactional.FI.Vendor.SinRemito;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.MainDocumentData.Vendor;

namespace MASngFE.Transactional.FI.FondoFijo
{
    public partial class FrmFondoFijoConversion : Form
    {
        public FrmFondoFijoConversion()
        {
            InitializeComponent();
        }

        private void cmbCuentaFF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuentaFF.SelectedIndex == -1)
            {
                t0406RendicionFFHBindingSource.DataSource = new RendicionFF().GetDataSourceAConvertir(null,
                    RendicionFF.StatusRendicion.Ingresado);
            }
            else
            {
                t0406RendicionFFHBindingSource.DataSource = new RendicionFF().GetDataSourceAConvertir(txtGlFondoFijo.Text,
                    RendicionFF.StatusRendicion.Ingresado);
            }
        }

        private void FrmFondoFijoConversion_Load(object sender, EventArgs e)
        {
            t0150CUENTASBindingSource.DataSource = new CuentasManager().GetListaCuentasFondoFijo();
            cmbCuentaFF.SelectedIndex = -1;


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListadoConversion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvListadoConversion[e.ColumnIndex, e.RowIndex].Value.ToString();
                //int numeroFormula = Convert.ToInt32(dgvFormulaList[dgvFormulaList.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "CONVERTIR":
                        {
                            var idRendicion = Convert.ToInt32(dgvListadoConversion[idRendicionDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                            var f = new FrmFI16VendorContaSinRemito(1, idRendicion);
                            f.Show();
                            break;
                        }
                    case "DEL":
                        {
                            var iditem = Convert.ToInt32(dgvListadoConversion[1, e.RowIndex].Value);
                            //var x = _lItems.Find(c => c.idItem == iditem);
                            //if (x == null)
                            //    return;

                            //_lItems.Remove(x);
                            //SumaImportes(ckAutoIVA21.Checked);
                            //t0407RendicionFFIBindingSource.DataSource = _lItems.ToList();
                            ////dgvDetalleItems.DataSource = t0404VENDORFACTIBindingSource.DataSource;
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
    }
}
