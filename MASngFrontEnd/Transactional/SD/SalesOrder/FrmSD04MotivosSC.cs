using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.HR;

namespace MASngFE.Transactional.SD.SalesOrder
{
    public partial class FrmSD04MotivosSc : Form
    {
        public enum MotivoSc
        {
            Muestra,
            Reproceso,
            BonificacionEspecial,
            Cambio,
            NoAplica,
        };

        public FrmSD04MotivosSc(int idOv, int idItem, string material, int idCliente)
        {
            InitializeComponent();
            txtSalesOrder.Text = idOv.ToString();
            txtItem.Text = idItem.ToString();
            txtMaterial.Text = material;
            _idCliente = idCliente;
        }
        //
        private readonly int _idCliente;
        public MotivoSc Motivo;
        public string Autorizo;
        //
        private void FrmSD04MotivosSC_Load(object sender, EventArgs e)
        {
            var cliente = new CustomerManager().GetCustomerBillToData(_idCliente).cli_rsocial;
            txtCliente.Text = cliente;
            cmbAutorizo.Items.AddRange(HrDisponibilidadYPermisos.AutorizaSinCargo().ToArray());
            rbMuestraSinCargo.Checked = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void cmbAutorizo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAutorizo.SelectedIndex == -1)
            {
                Autorizo = null;
                return;
            }
            Autorizo = cmbAutorizo.SelectedItem.ToString();
        }
    }
}
