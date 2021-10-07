using System;
using System.Windows.Forms;
using Tecser.Business.Tools;

namespace MASngFE._UserControls
{
    public partial class CurrencyTextBox : AwsTextBoxBase
    {
        public CurrencyTextBox()
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
            txt.Text = ValueD.ToString("C" + CantidadDecimales);
        }

        private void CurrencyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!CheckDesign.InDesignMode())
            {
                var txt = (TextBox)sender;
                if (!txt.Focused)
                {
                    ValueD = string.IsNullOrEmpty(txt.Text) ? 0 : FormatAndConversions.CCurrencyADecimal(txt.Text);
                    txt.Text = ValueD.ToString("C" + CantidadDecimales);
                }
            }
        }
    }
}
