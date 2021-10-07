using System;
using System.Windows.Forms;

namespace MASngFE._UserControls
{
    public partial class OtroTextbox : TextBox
    {
        public OtroTextbox()
        {
            InitializeComponent();
            KeyPress += textBox1_KeyPress;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
