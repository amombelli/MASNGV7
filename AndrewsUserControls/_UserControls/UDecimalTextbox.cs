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
    public partial class UDecimalTextbox : UserTextboxBase
    {
        public UDecimalTextbox()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(150, 134);
        }

        protected override void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, AllowBackSpace, AllowNegative, false);
        }

        protected override void txt_Validating(object sender, CancelEventArgs e)
        {
            ValueD = string.IsNullOrEmpty(base.txt.Text) ? 0 : FormatAndConversions.CCurrencyADecimal(txt.Text);

            if (ValueD < ValorMin)
            {
                e.Cancel = true;
                base.toolTip1.Show($"El Valor ingresado es menor al mínimo permitido ({ValorMin})", txt,
                    new Point(txt.Location.X + txt.Width, txt.Location.Y), 3000);
                toolTip1.ToolTipTitle = "Error en Valor";
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            }

            if (ValueD > ValorMax)
            {
                e.Cancel = true;
                toolTip1.ToolTipTitle = "Error en Valor";
                toolTip1.Show($"El Valor ingresado supera el maximo permitido ({ValorMax})", txt,
                    new Point(txt.Location.X + txt.Width, txt.Location.Y), 5000);
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
            }
            txt.Text = ValueD.ToString("N"+base.CantidadDecimales);
        }
        
        public override void Init(decimal valorMinimo, decimal valorMaximo, bool allowBackSp, bool allowSignoMenos,
            bool allowSignoMoneda=false,
            Color fc = default(Color),
            Color bc = default(Color), float tamanoLetra = 9,int cantidadDecimales=2)
        {
            base.ForeColor = fc;
            base.BackColor = bc;
            base.Font = new Font(base.Font.FontFamily, tamanoLetra);
            base.Text = 0.ToString("C2");
            base.ValueD = 0;
            ValorMin = valorMinimo;
            ValorMax = valorMaximo;
            base.AllowBackSpace = allowBackSp;
            base.AllowNegative = allowSignoMenos;
            base.AllowMoneda = allowSignoMoneda;
            base.CantidadDecimales = cantidadDecimales;
        }
    }
}

