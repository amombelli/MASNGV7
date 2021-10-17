using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.HR;
using Tecser.Business.Transactional.SD;

namespace MASngFE.Transactional.SD.Remito
{
    public partial class FrmSD08ConfirmaPreparacionRemito : Form
    {
        private readonly int _idRemito;

        public FrmSD08ConfirmaPreparacionRemito(int idRemito)
        {
            _idRemito = idRemito;
            InitializeComponent();
        }

        private void BtnConfirmarP_Click(object sender, EventArgs e)
        {
            if (cboResponsablePrep.SelectedItem == null)
            {
                MessageBox.Show(@"Debe completar un responsable de preparacion", @"Responsable de Preparacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtCantidadBultos.Text))
            {
                MessageBox.Show(@"Debe Completar la cantidad de Bultos en la preparacion", @"Cantidad de Bultos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (new RemitoStatusManager().SetStatusHeaderPreparado(_idRemito, Convert.ToInt32(txtCantidadBultos.Text),
                cboResponsablePrep.SelectedItem.ToString(), txtComentarioPreparacion.Text))
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                MessageBox.Show(
                    @"NO SE HA PODIDO CONFIRMAR la preparacion porque alguno de los items no tienen lote asignado o continene algun error",
                    @"Error en preparacion del Remito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void BtnCancelarP_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void FrmSD08ConfirmaPreparacionRemito_Load(object sender, EventArgs e)
        {
            cboResponsablePrep.Items.AddRange(HrDisponibilidadYPermisos.DisponibleDespacho().ToArray());
            LoadData();
        }
        private void LoadData()
        {
            var data = new RemitoGeneracionImpresion().GetRemitoHeader(_idRemito);
            txtCantidadBultos.Text = data.CANTBULTOS.ToString();
            txtComentarioPreparacion.Text = data.COM_PREP;

            if (data.PREPAREDBY == null)
            {
                cboResponsablePrep.SelectedItem = null;
            }
            else
            {
                cboResponsablePrep.SelectedItem = data.PREPAREDBY;

            }

            var cliente = new CustomerManager().GetCustomerShipToData(data.CODCLIENTREGA);
            txtClienteDescripcion.Text = cliente.ClienteEntregaDesc;
            txtIdRemito.Text = _idRemito.ToString();
        }

        private void txtCantidadBultos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void cboResponsablePrep_Validating(object sender, CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedItem == null && !string.IsNullOrEmpty(combo.Text))
                e.Cancel = true;
        }
    }
}
