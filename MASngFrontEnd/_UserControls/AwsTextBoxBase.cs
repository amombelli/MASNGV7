using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
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
            TextChanged += TextChangedX;
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
        public decimal ValueD { get; protected set; }
        private bool _allowBackSpace = true;
        private bool _allowNegative = false;
        protected bool AllowPorcentaje = false;
        protected bool AllowMoneda = false;
        private decimal _valorMin = 0;
        private decimal _valorMax = 10000;
        protected int CantidadDecimales = 2;
        private bool _showToolTip = true;
        private bool ColorFormat = true;
        private Color _colorBad = Color.Red;
        private Color _colorGood = Color.LightGreen;
        private Color _defaultBackColor;
        private Color _defaultForeColor;
        //-----------------------------------------------------------------------------------------

        protected virtual void TextChangedX(object sender, EventArgs e)
        {
            //Se redefine en cada clase heredada
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected virtual void ControlLeave(object sender, EventArgs e)
        {
            //Se redefine en cada clase heredada
        }
        public void MiToolTip(string mensaje, int duracion = 2000)
        {
            this.toolTip1.IsBalloon = false;
            this.toolTip1.SetToolTip(this, "Atencion");
            this.toolTip1.Show(mensaje, this, duracion);
            this.toolTip1.ToolTipIcon = ToolTipIcon.Error;
        }
        private void myTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, _allowBackSpace, _allowNegative, AllowMoneda, AllowPorcentaje);
        }
        private void AwsCurrencyTextbox_Validating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            //ValueD = string.IsNullOrEmpty(txt.Text) ? 0 : FormatAndConversions.CCurrencyADecimal(txt.Text);

            if (txt.ReadOnly == false)
            {
                //La validacion la hace solo si el textbox no esta read-only
                if (ValueD < _valorMin)
                {
                    e.Cancel = true;
                    if (_showToolTip)
                    {
                        toolTip1.IsBalloon = true;
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
                        toolTip1.IsBalloon = true;
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
        }
        public virtual void Init(decimal minimoValor, decimal maximoValor, int cantidadDecimalesShow, bool allowBakcspace = true, bool showTooltip = true, bool validacionColores = true)
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
