using System;
using System.Drawing;
using System.Windows.Forms;

namespace MASngFE._UserControls
{
    public partial class UCheckbox1 : UserControl
    {
        public UCheckbox1()
        {
            InitializeComponent();
        }
        public bool Value { get; private set; }
        public event EventHandler ButtonClick;
        public event EventHandler CheckBoxClick;

        private void ck_CheckedChanged(object sender, EventArgs e)
        {
            ck.BackColor = ck.Checked ? Color.MediumSeaGreen : Color.LightSalmon;
            Value = ck.Checked;
            // Properties.Settings.Default.CheckBox = ck.Checked;
            if (this.CheckBoxClick != null)
                this.CheckBoxClick(this, e);

            //bubble the event up to the parent
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }

        public void SetValor(bool valor)
        {
            ck.Checked = valor;
        }

        public void SetLabel(string valor)
        {
            ck.Text = valor;
        }


    }
}
