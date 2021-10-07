using System;
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
            TextChanged += TextChangedX;
        }



        //Formato de Texto
        protected override void ControlLeave(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            ValueD = string.IsNullOrEmpty(txt.Text) ? 0 : FormatAndConversions.CCurrencyADecimal(txt.Text);
            txt.Text = ValueD.ToString("N" + CantidadDecimales);
        }

        protected override void TextChangedX(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            if (!txt.Focused)
            {
                if (!CheckDesign.InDesignMode())
                {
                    ValueD = string.IsNullOrEmpty(txt.Text) ? 0 : FormatAndConversions.CCurrencyADecimal(txt.Text);
                    txt.Text = ValueD.ToString("N" + CantidadDecimales);
                }
            }
        }
    }
}
