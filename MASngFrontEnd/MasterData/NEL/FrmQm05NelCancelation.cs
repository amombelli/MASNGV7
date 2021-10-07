using System;
using System.Windows.Forms;

namespace MASngFE.MasterData.NEL
{
    public partial class FrmQm05NelCancelation : Form
    {
        public FrmQm05NelCancelation(int nel)
        {
            _nel = nel;
            InitializeComponent();
        }

        private readonly int _nel;
        public string MotivoCancelacion;


        private void FrmNelCancelation_Load(object sender, EventArgs e)
        {
            txtNel.Text = _nel.ToString();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotivoCancelacion.Text))
            {
                MessageBox.Show(@"Debe Indicar el Motivo de Cancelacion",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MotivoCancelacion = txtMotivoCancelacion.Text;
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
