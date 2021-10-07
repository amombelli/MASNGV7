using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Tecser.Business.Tools;

namespace TSControls
{

    /// <summary>
    /// Control TextBox con Formato
    /// Fecha Validacion 2021.04.13
    /// </summary>
    public partial class CtlTextBox : UserControl
    {
        public enum TextBoxType
        {
            Moneda,
            Decimal,
            Entero,
            Porcentaje
        };
        public enum Alineacion
        {
            Izquierda,
            Centro,
            Derecha
        };
        public CtlTextBox()
        {
            InitializeComponent();
        }
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                myTextBox.ForeColor = value;
            }
        }
        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                myTextBox.BackColor = value;
            }
        }
        public override Font Font
        {
            //cuando se modifica el font --> Resize
            get => base.Font;
            set
            {
                base.Font = value;
                myTextBox.Font = value;
                myTextBox.Location = new Point(0,0);
                base.Height = myTextBox.Height;
                myTextBox.Size = new Size(this.Width-1, this.Height);
            }
        }
        private void CtlTextBox_Resize(object sender, EventArgs e)
        {
            myTextBox.Size = new Size(this.Width, this.Height);
        }
        public decimal SetValue 
        {
            set
            {
                _valor = value;
                switch (_tipo)
                {
                    case TextBoxType.Moneda:
                        myTextBox.Text = value.ToString("C" + _cantidadDecimales);
                        break;
                    case TextBoxType.Decimal:
                        myTextBox.Text = value.ToString("N" + _cantidadDecimales);
                        break;
                    case TextBoxType.Entero:
                        myTextBox.Text = value.ToString("N0");
                        break;
                    case TextBoxType.Porcentaje:
                        myTextBox.Text = value.ToString("P" + _cantidadDecimales);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        //-----------------------------------------------------------------------------------------
        private TextBoxType _tipo;
        private decimal _valorMin = decimal.MinValue;
        private decimal _valorMax = decimal.MaxValue;
        private decimal _valor;
        private int _cantidadDecimales = 0;
        private bool _allowBackspace;
        private bool _allowNegativo;
        private bool _locked;
        private Alineacion _textAlign = Alineacion.Centro;
        public decimal GetValueDecimal => _valor;
        
        //Propiedades Accesibles
        
        public Alineacion SetAlineacion
        {
            get => _textAlign;
            set
            {
                _textAlign = value;
                switch (value)
                {
                    case Alineacion.Izquierda:
                        myTextBox.TextAlign = HorizontalAlignment.Left;
                        break;
                    case Alineacion.Centro:
                        myTextBox.TextAlign = HorizontalAlignment.Center;
                        break;
                    case Alineacion.Derecha:
                        myTextBox.TextAlign = HorizontalAlignment.Right;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }
        public decimal ValorMinimo
        {
            get => _valorMin;
            set
            {
                _valorMin = value;
                _allowNegativo = _valorMin < 0;
            }
        }
        public decimal ValorMaximo
        {
            get => _valorMax;
            set
            {
                _valorMax = value;
                _allowNegativo = _valorMax < 0;
            }

        }
        public int SetDecimales
        {
            get => _cantidadDecimales;
            set
            {
                if (_cantidadDecimales < 0)
                {
                    _cantidadDecimales = 0;
                }
                else
                {
                    _cantidadDecimales = value;
                }
            }
        }
        public TextBoxType SetType
        {
            get => _tipo;
            set
            {
                _tipo = value;
                ConfiguraTipo();
            }
        }
        public bool XReadOnly
        {
            get => _locked;
            set
            {
                _locked = value;
                myTextBox.ReadOnly = value;
            }
        }
        private void ConfiguraTipo()
        {
            switch (_tipo)
            {
                case TextBoxType.Moneda:
                    _allowBackspace = true;
                    break;
                case TextBoxType.Decimal:
                    _allowBackspace = true;
                    break;
                case TextBoxType.Entero:
                    _allowBackspace = true;
                    _cantidadDecimales = 0;
                    break;
                case TextBoxType.Porcentaje:
                    _allowBackspace = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void CtlTextBox_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(myTextBox.Text))
            {
                this.SetValue = 0;
            }
        }
        private void myTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (SetType)
            {
                case TextBoxType.Moneda:
                    FormatAndConversions.SoloDecimalKeyPress(sender, e, _allowBackspace, _allowNegativo, true, false);
                    break;
                case TextBoxType.Decimal:
                    FormatAndConversions.SoloDecimalKeyPress(sender, e, _allowBackspace, _allowNegativo, false, false);
                    break;
                case TextBoxType.Entero:
                    FormatAndConversions.SoloEnteroKeyPress(sender, e);
                    break;
                case TextBoxType.Porcentaje:
                    FormatAndConversions.SoloDecimalKeyPress(sender, e, _allowBackspace, _allowNegativo, false, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void myTextBox_Validating(object sender, CancelEventArgs e)
        {
            var txt = (TextBox)sender;
            if (string.IsNullOrEmpty(txt.Text))
                txt.Text = 0.ToString();
            switch (_tipo)
            {
                case TextBoxType.Moneda:
                    _valor = FormatAndConversions.CCurrencyADecimal(txt.Text);
                    txt.Text = _valor.ToString("C" + _cantidadDecimales);
                    break;
                case TextBoxType.Decimal:
                    _valor = Convert.ToDecimal(txt.Text);
                    txt.Text = _valor.ToString("N" + _cantidadDecimales);
                    break;
                case TextBoxType.Entero:
                    _valor = Convert.ToDecimal(txt.Text);
                    txt.Text = _valor.ToString("N0");
                    break;
                case TextBoxType.Porcentaje:
                    _valor = FormatAndConversions.CPorcentajeADecimal(txt.Text);
                    txt.Text = _valor.ToString("P" + _cantidadDecimales);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_valor < _valorMin)
            {
                toolTip1.ToolTipTitle = "Valor fuera de Rango [-]";
                toolTip1.Show("El Valor Ingresado no cumple con las condiciones definidas",
                    txt, txt.Location, 1000);
                e.Cancel = true;
            }

            if (_valor > _valorMax)
            {
                toolTip1.ToolTipTitle = "Valor fuera de Rango [+]";
                toolTip1.Show("El Valor Ingresado no cumple con las condiciones definidas",
                    txt, txt.Location, 1000);
                e.Cancel = true;
            }
        }
        private void CtlTextBox_SizeChanged(object sender, EventArgs e)
        {
            base.Height = myTextBox.Height;
            myTextBox.Size = new Size(this.Width - 1, this.Height);
        }
        private void myTextBox_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(myTextBox.Text))
            {
                //si esta vacio al hacer doble click no hace nada
            }
            else
            {
                //si esta completo al hacer doble click vacia
                myTextBox.Text = null;
            }
        }
    }
}
