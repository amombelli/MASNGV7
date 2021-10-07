using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP04CancelaOF : Form
    {
        public FrmPP04CancelaOF(int numeroOF)
        {
            _numeroOF = numeroOF;
            InitializeComponent();
            txtNumeroOF.Text = _numeroOF.ToString();
        }

        private readonly int _numeroOF;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Confirma que desea CANCELAR la Orden de Fabricacion?",
                @"Cancelar Orden Fabricacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(txtMotivoCancel.Text))
                {
                    MessageBox.Show(@"Debe indicar un motivo para cancelar la orden de Fabricacion", @"Revise los datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PlanProduccionStatusManager.SetStatusCancel(_numeroOF, txtMotivoCancel.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        private void FrmOrdenFabricacionCancela_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
