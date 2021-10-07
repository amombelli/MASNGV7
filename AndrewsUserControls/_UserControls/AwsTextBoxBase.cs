using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Tecser.Business.Tools;

namespace MASngFE._UserControls
{
    public partial class AwsTextBoxBase : TextBox
    {
        protected AwsTextBoxBase()
        {
            InitializeComponent();
            KeyPress += myTextBox_KeyPress;
            Validating += AwsCurrencyTextbox_Validating;
            Leave += ControlLeave;
            Validated += AwsTextBoxBase_Validated;
            _defaultBackColor = this.BackColor;
            _defaultForeColor = this.ForeColor;
        }

        public sealed override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        public sealed override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }

        private void AwsTextBoxBase_Validated(object sender, EventArgs e)
        {
            if (ColorFormat)
            {
                var txt = (TextBox)sender;
                txt.BackColor = _colorGood;
                txt.ForeColor = _defaultForeColor;
            }
                return;
           
        }

        //-----------------------------------------------------------------------------------------
        public decimal ValueD { protected set; get; }

        private bool _allowBackSpace=true;
        private bool _allowNegative=false;
        protected bool AllowPorcentaje = false;
        protected bool AllowMoneda=false;
        private decimal _valorMin = 0;
        private decimal _valorMax = 10000;
        protected int CantidadDecimales= 2;
        private bool _showToolTip = true;
        private bool ColorFormat = true;
        private Color _colorBad = Color.Red;
        private Color _colorGood = Color.LightGreen;
        private Color _defaultBackColor;
        private Color _defaultForeColor;
        //-----------------------------------------------------------------------------------------

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected virtual void ControlLeave(object sender, EventArgs e)
        {
            //var txt = (TextBox)sender;
            //ValueD = string.IsNullOrEmpty(txt.Text) ? 0 : FormatAndConversions.CCurrencyADecimal(txt.Text);
            //txt.Text = ValueD.ToString("C"+CantidadDecimales);
        }
        private void myTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, _allowBackSpace, _allowNegative, AllowMoneda,AllowPorcentaje);
        }
        private void AwsCurrencyTextbox_Validating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox) sender;
            //ValueD = string.IsNullOrEmpty(txt.Text) ? 0 : FormatAndConversions.CCurrencyADecimal(txt.Text);

            if (ValueD < _valorMin)
            {
                e.Cancel = true;
                if (_showToolTip)
                {
                    toolTip1.ToolTipTitle = "Valor Incorrecto";
                    toolTip1.Show($"El Valor es menor al minimo permitido ({_valorMin})", txt, 5000);
                    toolTip1.SetToolTip(myTextBox, "??");
                    toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                }

                if (ColorFormat)
                {
                    txt.ForeColor = _colorBad;
                    txt.BackColor = _defaultBackColor;
                }
            }

            if (ValueD > _valorMax)
            {
                e.Cancel = true;
                if (_showToolTip)
                {
                    toolTip1.ToolTipTitle = "Valor Incorrecto";
                    toolTip1.Show($"El Valor ingresado supera el maximo permitido ({_valorMax})", txt, 5000);
                    toolTip1.SetToolTip(myTextBox, "??");
                    toolTip1.ToolTipIcon = ToolTipIcon.Warning;
                }

                if (ColorFormat)
                {
                    txt.ForeColor = _colorBad;
                    txt.BackColor = _defaultBackColor;
                }
            }
        }
        public virtual void Init(decimal minimoValor,decimal maximoValor,int cantidadDecimalesShow,bool allowBakcspace=true,bool showTooltip=true,bool validacionColores=true)
        {
            _valorMin = minimoValor;
            _valorMax = maximoValor;
            if (_valorMin < 0)
                _allowNegative = true;
            CantidadDecimales = cantidadDecimalesShow;
            _allowBackSpace = allowBakcspace;
            _showToolTip = showTooltip;
            ColorFormat = validacionColores;
        }
    }
}
