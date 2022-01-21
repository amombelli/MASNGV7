using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSControls
{
    public partial class CtlDisplayNumbers2 : UserControl
    {
        public CtlDisplayNumbers2()
        {
            InitializeComponent();
        }

        private TextBoxType _tipoFormato;
        private decimal _valor;
        private bool isIconVisible;
        private int _cantidadDecimales;
        private Alineacion _textAlign = Alineacion.Centro;
        public decimal GetValueDecimal => _valor;
        public enum TextBoxType
        {
            Moneda,
            Decimal,
            Porcentaje
        }
        public enum Alineacion
        {
            Izquierda,
            Derecha,
            Centro
        }
        public override Color ForeColor
        {
            get => myTextBox.ForeColor;
            set => myTextBox.ForeColor = value;
        }
        public override Color BackColor
        {
            get => myTextBox.BackColor;
            set
            {
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
                myTextBox.Location = new Point(3, 3);
                this.Height = myTextBox.Height + 6;
                if (DisplayIcon == false)
                {
                    myTextBox.Size = new Size(this.Width, this.Height);
                }
                else
                {
                    myTextBox.Location = new Point(3, 3);
                    myTextBox.Width = this.Width - 22;
                    cIcon.Location = new Point(myTextBox.Width + 3, 3);
                }
            }
        }
        public Alineacion TextAlign
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
        public int NumberDecimals
        {
            get => _cantidadDecimales;
            set => _cantidadDecimales = _cantidadDecimales < 0 ? 0 : value;
        }
        public TextBoxType SetDisplayType
        {
            get => _tipoFormato;
            set => _tipoFormato = value;
        }
        public decimal DisplayValue
        {
            set
            {
                _valor = value;
                switch (_tipoFormato)
                {
                    case TextBoxType.Moneda:
                        myTextBox.Text = value.ToString("C" + _cantidadDecimales);
                        break;
                    case TextBoxType.Decimal:
                        myTextBox.Text = value.ToString("N" + _cantidadDecimales);
                        break;
                    case TextBoxType.Porcentaje:
                        myTextBox.Text = value.ToString("P" + _cantidadDecimales);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            get => _valor;
        }
        public bool DisplayIcon
        {
            set
            {
                if (value == true)
                {
                    isIconVisible = true;
                    cIcon.Visible = true;
                    myTextBox.Width = base.Width - 22;
                    cIcon.Location = new Point(myTextBox.Width + 3, 3);
                }
                else
                {
                    isIconVisible = false;
                    cIcon.Visible = false;
                    myTextBox.Width = base.Width;
                }
            }
            get => isIconVisible;
        }
        public CIconos SetIcon
        {
            get => cIcon.Get;
            set => cIcon.Set = value;
        }
        private void CtlDisplayNumbers2_Load(object sender, EventArgs e)
        {
            cIcon.IconSize = TamañoIcono.Chico;
            if (DisplayIcon)
            {
                cIcon.Visible = true;
            }
            else
            {
                cIcon.Visible = false;
            }
        }
        private void CtlDisplayNumbers2_Resize(object sender, EventArgs e)
        {
            this.Height = myTextBox.Height+6;
            if (DisplayIcon == false)
            {
                myTextBox.Size = new Size(this.Width, this.Height);
            }
            else
            {
                myTextBox.Location=new Point(3,3);
                myTextBox.Width = this.Width - 22;
                cIcon.Location = new Point(myTextBox.Width + 3, 3);
            }
        }
    }
}
