using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MASngFE._UserControls
{
    public partial class UCheckbox1 : UserControl
    {
        public UCheckbox1()
        {
            InitializeComponent();
        }
        public bool value { get; private set; }
        public event EventHandler ButtonClick;
        public event EventHandler CheckBoxClick;
        
        private void ck_CheckedChanged(object sender, EventArgs e)
        {
            ck.BackColor = ck.Checked ? Color.MediumSeaGreen : Color.LightSalmon;
            value = ck.Checked;
            Properties.Settings.Default.CheckBox = ck.Checked;
            if (this.CheckBoxClick != null)
               this.CheckBoxClick(this, e);

            //bubble the event up to the parent
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }

        
    }
}
