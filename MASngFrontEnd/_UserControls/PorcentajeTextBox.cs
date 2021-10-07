using System;
using System.Windows.Forms;
using Tecser.Business.Tools;

namespace MASngFE._UserControls
{
    public partial class PorcentajeTextBox : AwsTextBoxBase
    {
        public PorcentajeTextBox()
        {
            InitializeComponent();
            Leave += ControlLeave;
            AllowPorcentaje = true;
        }

        //Formato de Texto
        protected override void ControlLeave(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            ValueD = string.IsNullOrEmpty(txt.Text) ? 0 : FormatAndConversions.CPorcentajeADecimal(txt.Text);
            txt.Text = ValueD.ToString("P" + CantidadDecimales);
        }


    }
}
