using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using TecserSQL.Data.MasterData;

namespace MASngFE.Transactional.SD.Remito
{
    public partial class FrmSD12SeleccionBatchDespacho : Form
    {
        private readonly string _material;
        private readonly decimal _kgRequeridos;
        private decimal _kgSeleccion;


        public FrmSD12SeleccionBatchDespacho(string material, decimal kgRequeridos)
        {
            _material = material;
            _kgRequeridos = kgRequeridos;
            InitializeComponent();
        }

        public int? IdStockSeleccionado = null;
        public decimal KgSeleccionados;
        public string BatchSeleccionado;
        public string SlocSeleccionado;

        private void FrmSeleccionBatchDespacho_Load(object sender, EventArgs e)
        {
            txtCantidad.Text = _kgRequeridos.ToString("N2");
            txtMaterialRequerido.Text = _material;
            var mat = MaterialMasterManager.GetPrimario(_material);
            if (mat == "@")
            {
                MessageBox.Show(@"No se ha podido encontrar el codigo primario del material seleccionado",
                    @"Error en Material", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            txtPrimario.Text = mat == _material ? _material : mat;
            dgvStock.DataSource = new StockList().GetAllByMaterial_DisponibleDespacho(txtPrimario.Text, "CERR");
            dgvStock.ClearSelection();
            ctlKgDespachar.SetValue = 0;
            txtKGSeleccion.Text = @"0";
            txtKgMaximo.Text = @"0";
            txtIdStockSeleccionado.Text = null;
        }
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //si hace click en cualquier celda (menos en batch)
            if (e.RowIndex >= 0)
            {
                _kgSeleccion = Convert.ToDecimal(dgvStock[__kg.Name, e.RowIndex].Value);
                IdStockSeleccionado = Convert.ToInt32(dgvStock[__idstock.Name, e.RowIndex].Value);
                txtIdStockSeleccionado.Text = IdStockSeleccionado.ToString();
                SlocSeleccionado = dgvStock[__sloc.Name, e.RowIndex].Value.ToString();
                txtLote.Text = dgvStock[__lote.Name, e.RowIndex].Value.ToString();
                txtKGSeleccion.Text = _kgSeleccion.ToString("N2");
                if (_kgSeleccion > _kgRequeridos)
                {
                    txtKgMaximo.Text = _kgRequeridos.ToString("N2");
                    ctlKgDespachar.ValorMaximo = _kgRequeridos;
                    ctlKgDespachar.SetValue = _kgRequeridos;
                }
                else
                {
                    txtKgMaximo.Text = _kgSeleccion.ToString("N2");
                    ctlKgDespachar.ValorMaximo = _kgSeleccion;
                    ctlKgDespachar.SetValue = _kgSeleccion;
                }
            }
        }
        private void ckVerTodoStock_CheckedChanged(object sender, EventArgs e)
        {
            if (ckVerTodoStock.Checked == false)
            {
                btnSelect.Enabled = true;
                dgvStock.DataSource = new StockList().GetAllByMaterial_DisponibleDespacho(txtPrimario.Text, "CERR");
                dgvStock.ClearSelection();

            }
            else
            {
                btnSelect.Enabled = false;
                dgvStock.DataSource = new StockList().GetAllByMaterial(txtPrimario.Text);
                dgvStock.ClearSelection();

            }
        }
        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //esto es por si agregamos algun boton en el DGV
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            IdStockSeleccionado = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (IdStockSeleccionado == null)
            {
                MessageBox.Show(@"Debe Seleccionar una linea de Stock para Asignar Lote", @"Seleccion de Lote",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ctlKgDespachar.GetValueDecimal == 0 || ctlKgDespachar.GetValueDecimal > _kgRequeridos)
            {
                MessageBox.Show(@"Los Kg Seleccionandos no se corresponden al requerimiento de KG",
                    @"Error en Seleccion de KG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            KgSeleccionados = ctlKgDespachar.GetValueDecimal;
            BatchSeleccionado = txtLote.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
