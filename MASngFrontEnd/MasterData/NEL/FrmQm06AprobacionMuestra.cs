using System;
using System.Windows.Forms;

namespace MASngFE.MasterData.NEL
{
    public partial class FrmQm06AprobacionMuestra : Form
    {
        public FrmQm06AprobacionMuestra(int numeroNel)
        {
            _nel = numeroNel;
            InitializeComponent();
        }

        //------------------------------------------------------------
        private readonly int _nel;
        public string AprobadoPor;
        public DateTime FechaAprobacion;
        //------------------------------------------------------------

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAprobadoPor.Text))
            {
                MessageBox.Show(@"Debe proveer el nombre del contacto que aprobo y/o medio de aprobacion",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AprobadoPor = txtAprobadoPor.Text;
            FechaAprobacion = dtpFechaAprobacion.Value;
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
        private void FrmAprobacionMuestra_Load(object sender, EventArgs e)
        {
            txtNel.Text = _nel.ToString();
        }
    }
}
