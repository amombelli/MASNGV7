using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace MASngFE.Transactional.SD.Hoja_de_Ruta
{
    public partial class FrmAddRemitosRuta : Form
    {
        public FrmAddRemitosRuta(int idRuta)
        {
            _idRuta = idRuta;
            InitializeComponent();
        }
        public FrmAddRemitosRuta(int idRuta, int idItem)
        {
            _idRuta = idRuta;
            _idItem = idItem;
            InitializeComponent();
        }

        private readonly int _idItem;

        private readonly int _idRuta;
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtOrdenEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void btnAddRemito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdEntrega.Text))
            {
                MessageBox.Show(@"Debe seleccionar un remito para agregar a la ruta", @"Remito sin Seleccionar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var resp = MessageBox.Show(@"Desea agregar este remito a la Ruta?", @"Agregar Remito a Hoja de Ruta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;
            if (string.IsNullOrEmpty(txtOrdenEntrega.Text))
                txtOrdenEntrega.Text = @"0";

            var idGenerado = new GestorEntregas().AddRemitoToRuta(_idRuta, Convert.ToInt32(txtIdEntrega.Text), txtObservaciones.Text,
                ckEntregarMuestra.Checked, ckRetirarPago.Checked, Convert.ToInt32(txtOrdenEntrega.Text));

            if (idGenerado > 0)
            {
                MessageBox.Show(@"Se ha agregado correctamente el remito a la Ruta", @"Agregado Remito a Hoja de Ruta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                t0059ENTREGASBindingSource.DataSource = new GestorEntregas().GetListEntregasSinRutaAsignada();

            }

        }
        private void FrmAddRemitosRuta_Load(object sender, EventArgs e)
        {
            ConfigInitialData();
        }
        private void ConfigInitialData()
        {
            t0059ENTREGASBindingSource.DataSource = new GestorEntregas().GetListEntregasSinRutaAsignada();
            dgvRemitos.DataSource = t0059ENTREGASBindingSource;
            if (_idItem > 0)
            {
                MapDataRemitoEntrega();
            }
            else
            {
                btnAddRemito.Enabled = true;
                btnGuardarCambios.Enabled = false;

            }
        }
        private void MapDataRemitoEntrega()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0059_HOJARUTA_I.SingleOrDefault(c => c.IdRuta == _idRuta && c.IdItem == _idItem);
                if (data != null)
                {
                    txtOrdenEntrega.Text = data.OrdenEntrega.ToString();
                    txtObservaciones.Text = data.Observacion;
                    ckRetirarPago.Checked = data.RetiraPago;
                    ckEntregarMuestra.Checked = data.EntregaMuestra;
                    txtIdEntrega.Text = data.IdRuta.ToString();
                    txtRemitoSeleccionado.Text = data.NumeroRemito;
                    btnAddRemito.Enabled = false;
                    btnGuardarCambios.Enabled = true;

                }
            }
        }
        private void txtBuscarNumeroRemito_Leave(object sender, EventArgs e)
        {
            t0059ENTREGASBindingSource.DataSource = new GestorEntregas().GetListEntregasSinRutaAsignada();
        }
        private void dgvRemitos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = "idEntregasDataGridViewTextBoxColumn";
            txtIdEntrega.Text = dgvRemitos[dgvRemitos.Columns[columnName].Index, e.RowIndex].Value.ToString();

            columnName = "numeroRemitoDataGridViewTextBoxColumn";
            txtRemitoSeleccionado.Text = dgvRemitos[dgvRemitos.Columns[columnName].Index, e.RowIndex].Value.ToString();
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            new GestorEntregas().UpdateRemitoToRuta(_idRuta, _idItem, txtObservaciones.Text, ckEntregarMuestra.Checked,
                ckRetirarPago.Checked);

            this.Close();
            this.DialogResult = DialogResult.OK;


        }
        private void btnEliminarRemito_Click(object sender, EventArgs e)
        {
            new GestorEntregas().DeleteRemitoRuta(_idRuta, _idItem);

            this.Close();
            this.DialogResult = DialogResult.OK;
        }
        private void btnNoEntregado_Click(object sender, EventArgs e)
        {
            new HojaRutaStatusManager().SetItemNoEntegado(_idRuta, _idItem);
        }
        private void btnEntregadoOK_Click(object sender, EventArgs e)
        {
            new HojaRutaStatusManager().SetItemEntregado(_idRuta, _idItem);
        }
    }
}
