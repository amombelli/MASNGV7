using System;
using System.Windows.Forms;

namespace TSControls
{
    public partial class FrmUserInputTexto : Form
    {
        public FrmUserInputTexto(string textoPregunta, string tituloForm = "MasNG")
        {
            InitializeComponent();
            labelPregunta.Text = textoPregunta;
            this.Text = tituloForm;
        }

        public string resultado { get; private set; }

        private void FrmUserInput_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResultado.Text))
            {
                var x = MessageBox.Show(@"Continua sin Ingresar Datos?", @"Sin Ingreso de Datos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return;

                this.Close();
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            else
            {
                resultado = txtResultado.Text;
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
