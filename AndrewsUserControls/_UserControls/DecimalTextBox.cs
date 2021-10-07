using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Tools;

namespace MASngFE._UserControls
{
    public partial class DecimalTextBox : AwsTextBoxBase
    {
        public DecimalTextBox()
        {
            InitializeComponent();
            Leave += ControlLeave;
            AllowMoneda = true;
        }

        //Formato de Texto
        protected override void ControlLeave(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            ValueD = string.IsNullOrEmpty(txt.Text) ? 0 : FormatAndConversions.CCurrencyADecimal(txt.Text);
            txt.Text = ValueD.ToString("N" + CantidadDecimales);
        }
    }
}
