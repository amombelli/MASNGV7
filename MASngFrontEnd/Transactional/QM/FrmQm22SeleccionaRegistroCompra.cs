using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm22SeleccionaRegistroCompra : Form
    {
        public FrmQm22SeleccionaRegistroCompra(string material, string lote)
        {
            _material = material;
            _lote = lote;
            Id40 = null;
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------
        private readonly string _material;
        private readonly string _lote;
        public int? Id40;
        public string Vendor;
        public decimal KgSelected;
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void DgvSeleccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            Id40 = Convert.ToInt32(datagridview[id40DataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            Vendor = datagridview[supplierDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            KgSelected = Convert.ToDecimal(datagridview[kgDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "Select":
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
        private void FrmQm22SeleccionaRegistroCompra_Load(object sender, EventArgs e)
        {
            txtMaterial.Text = _material;
            txtLote.Text = _lote;
            qmLoteSupplierStructBindingSource.DataSource =
                new QmRegistroInspeccion().GetSupplierDataCompra(_material, _lote);
        }
    }
}
