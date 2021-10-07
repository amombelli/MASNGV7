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
    public partial class UCurrencyTextBox : UserTextboxBase
    {
        public UCurrencyTextBox()
        {
            InitializeComponent();
        }

        protected override void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, AllowBackSpace, AllowNegative, AllowMoneda);
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
                toolTip1.Show($"El Valor ingresado supera el maximo permitido ({ValorMax}  - Ubicacion {txt.Location})", txt,txt.Location,5000);
                toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                

                var pnt = PointToClient(Cursor.Position);
//pnt.X += 10 ' Give a little offset
//pnt.Y += 10 ' so tooltip will look neat
//toolTip.Show(text, control, pnt)
            }


            txt.Text = ValueD.ToString("C"+CantidadDecimales);
        }

        private void UCurrencyTextBox_Load(object sender, EventArgs e)
        {

        }

        public override void Init(decimal valorMinimo, decimal valorMaximo, bool allowBackSp, bool allowSignoMenos,
            bool allowSignoMoneda,Color fc = default(Color),Color bc = default(Color), float tamanoLetra = 9,int cantidadDecimales=2)
        {
            txt.ForeColor = fc;
            txt.BackColor = bc;
            //txt.Font = new Font(base.Font.FontFamily, tamanoLetra);
            base.Text = 0.ToString("C2");
            base.ValueD = 0;
            base.ValorMin = valorMinimo;
            base.ValorMax = valorMaximo;
            base.AllowBackSpace = allowBackSp;
            base.AllowNegative = allowSignoMenos;
            base.AllowMoneda = allowSignoMoneda;
            base.CantidadDecimales = cantidadDecimales;
            //txt.AutoSize = true;
            //this.Size = new Size(txt.Width, txt.Height);

        }
    }
}

