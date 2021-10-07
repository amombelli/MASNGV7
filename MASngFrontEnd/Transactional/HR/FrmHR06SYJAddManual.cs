using System;
using System.Windows.Forms;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHR06SYJAddManual : Form
    {
        public FrmHR06SYJAddManual()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
    }
}
