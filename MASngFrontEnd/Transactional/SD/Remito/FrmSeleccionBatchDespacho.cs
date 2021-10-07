using System;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.SD.Remito
{
    public partial class FrmSeleccionBatchDespacho : Form
    {
        public FrmSeleccionBatchDespacho(string material, decimal kgRequeridos)
        {
            InitializeComponent();
            txtKGRequerido.Text = kgRequeridos.ToString("N2");
            txtPrimario.Text = material;
        }

        public int? IdStockSeleccionado = null;
        public decimal KgSeleccionados;
        public string BatchSeleccionado;
        public string SlocSeleccionado;

        private void FrmSeleccionBatchDespacho_Load(object sender, EventArgs e)
        {
            SetDataSource();
        }
        private void SetDataSource()
        {
            dgvStock.DataSource = new StockList().GetAllByMaterial_DisponibleDespacho(txtPrimario.Text, "CERR");
            dgvStock.ClearSelection();
            txtKgADespachar.Text = 0.ToString("N2");
            txtIdStockSeleccionado.Text = null;
        }
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //si hace click en cualquier celda (menos en batch)
            if (e.RowIndex >= 0)
            {
                txtKGSeleccion.Text =
                    Convert.ToDecimal(dgvStock[dgvStock.Columns["kg_dgv"].Index, e.RowIndex].Value).ToString("N2");
                txtIdStockSeleccionado.Text =
                    dgvStock[dgvStock.Columns["idstock_dgv"].Index, e.RowIndex].Value.ToString();

                IdStockSeleccionado = Convert.ToInt32(dgvStock[dgvStock.Columns[idstock_dgv.Name].Index, e.RowIndex].Value);
                SlocSeleccionado =
                    dgvStock[dgvStock.Columns[sLOCDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();
                txtLote.Text = dgvStock[dgvStock.Columns["lote_dgv"].Index, e.RowIndex].Value.ToString();

                if (Convert.ToDecimal(dgvStock[dgvStock.Columns["kg_dgv"].Index, e.RowIndex].Value) >
                    Convert.ToDecimal(txtKGRequerido.Text))
                {
                    txtKgADespachar.Text = txtKGRequerido.Text;
                }
                else
                {
                    txtKgADespachar.Text =
                        Convert.ToDecimal(dgvStock[dgvStock.Columns["kg_dgv"].Index, e.RowIndex].Value).ToString("N2");
                }
            }
        }
        private void ckVerTodoStock_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVerTodoStock.Checked == false)
            {
                btnSeleccion.Enabled = true;
                dgvStock.DataSource = new StockList().GetAllByMaterial_DisponibleDespacho(txtPrimario.Text, "CERR");
                dgvStock.ClearSelection();

            }
            else
            {
                btnSeleccion.Enabled = false;
                dgvStock.DataSource = new StockList().GetAllByMaterial(txtPrimario.Text);
                dgvStock.ClearSelection();

            }
        }
        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void txtKgADespachar_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtKgADespachar_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtKgADespachar.Text) > Convert.ToDecimal(txtKGRequerido.Text) * (decimal)(1.20))
            {
                MessageBox.Show(@"La Cantidad seleccionada supera a la cantidad requerida segun la Orden de Venta y Excede la tolerancia [20%] Permitida" + Environment.NewLine + "En caso de ser correcta esta nueva cantidad modifique primero la Orden de Venta", @"Kg Seleccionados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtKgADespachar.Text = txtKGRequerido.Text;
            }
        }
        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdStockSeleccionado.Text))
            {
                MessageBox.Show(@"Debe Seleccionar una linea de Stock para Asignar Lote", @"Seleccion de Lote",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtKGSeleccion.Text = 0.ToString("N2");
                txtKgADespachar.Text = 0.ToString("N2");

                return;
            }

            if (Convert.ToDecimal(txtKgADespachar.Text) > 0)
            {
                KgSeleccionados = decimal.Round(Convert.ToDecimal(txtKgADespachar.Text), 2);
                IdStockSeleccionado = Convert.ToInt32(txtIdStockSeleccionado.Text);
                BatchSeleccionado = txtLote.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(@"La cantidad de Kg seleccionada debe ser mayor a cero y menor o igual a los Kg Requeridos por el cliente ",
                    @"Seleccion de Kg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            IdStockSeleccionado = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
