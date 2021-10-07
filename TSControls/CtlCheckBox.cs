using System;
using System.Drawing;
using System.Windows.Forms;

namespace TSControls
{
    public partial class CtlCheckBox : UserControl
    {
        public CtlCheckBox()
        {
            InitializeComponent();
        }

        private Color _bkColorChecked = Color.LimeGreen;
        private Color _bkColorUnchecked = Color.IndianRed;
#pragma warning disable CS0414 // El campo 'CtlCheckBox._controlInicializado' está asignado pero su valor nunca se usa
        private bool _controlInicializado = false;
#pragma warning restore CS0414 // El campo 'CtlCheckBox._controlInicializado' está asignado pero su valor nunca se usa

        //------------------------------------------------------------------------------
        public Color ColorChecked
        {
            get => _bkColorChecked;
            set
            {
                _bkColorChecked = value;
                UpdateColor();
            }
        }
        public Color ColorUnChecked
        {
            get => _bkColorUnchecked;
            set
            {
                _bkColorUnchecked = value;
                UpdateColor();
            }
        }
        public bool Value
        {
            get => miCk.Checked;
            set
            {
                miCk.Checked = value;
                miCk.BackColor = value == true ? _bkColorChecked : _bkColorUnchecked;
            }
        }
        public string LabelText
        {
            get => miCk.Text;
            set => miCk.Text = value;
        }
        //-------------------------------------------------------------------------------

        public event System.EventHandler CheckedChanged;

        private void UpdateColor()
        {
            miCk.BackColor = miCk.Checked ? _bkColorChecked : _bkColorUnchecked;
        }
        private void CtlCheckBox_SizeChanged(object sender, EventArgs e)
        {
            miCk.Size = new Size(this.Width, this.Height);
        }
        private void miCk_CheckedChanged(object sender, EventArgs e)
        {
            this.Value = Value; //llama a la propiedad SET
            Cursor.Current = Cursors.WaitCursor;
            CheckedChanged?.Invoke(sender, e);
            Cursor.Current = Cursors.Default;
        }

    }
}
