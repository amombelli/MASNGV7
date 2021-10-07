using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSControls
{
    public partial class TsButton1 : UserControl
    {
        public TsButton1()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        //[Bindable(true)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[System.ComponentModel.SettingsBindable(true)]
        public string Etiqueta
        {
            get => miLabel.Text;
            set => miLabel.Text = value;
        }

        public event EventHandler BotonClick;
        private bool _enabled = true;

        protected virtual void OnBotonClick()
        {
            BotonClick?.Invoke(this, EventArgs.Empty);
        }


        public Image ImagenFondo
        {
            get => miBoton.BackgroundImage;
            set => miBoton.BackgroundImage = value;
        }

        public Image ImagenIcono
        {
            get => miBoton.Image;
            set => miBoton.Image = value;
        }

        public new bool Enabled
        {
            get => miBoton.Enabled;
            set
            {
                _enabled = value;
                miBoton.Enabled = _enabled;
                if (value)
                {
                    panel.BackColor = ColorEnabled;
                    miLabel.BackColor = Color.LightGreen;
                }
                else
                {
                    panel.BackColor = ColorDisable;
                    miLabel.BackColor = Color.LightGray;
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (_enabled)
            {
                OnBotonClick();
            }
            else
            {
                MessageBox.Show(@"Esto boton no puede presionarse porque esta deshabilitado");
            }
        }

        private void TsButton1_Load(object sender, EventArgs e)
        {
            var x = (TsButton1) sender;
            Enabled = x.Enabled;
        }

        //AutoProperty --> igual que definir la propiedad
        public Color ColorEnabled { get; set; } = Color.LimeGreen;
        public Color ColorDisable { get; set; } = Color.DarkGray;
        public Color ColorFondo { get; set; } = Color.White;




        //private void CtlTextBox_SizeChanged(object sender, EventArgs e)
        //{
        //    base.Height = myTextBox.Height;
        //    myTextBox.Size = new Size(this.Width - 1, this.Height);
        //}
        //private void myTextBox_DoubleClick(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(myTextBox.Text))
        //    {
        //        //si esta vacio al hacer doble click no hace nada
        //    }
        //    else
        //    {
        //        //si esta completo al hacer doble click vacia
        //        myTextBox.Text = null;
        //    }
        //}

        private void TsButton1_SizeChanged(object sender, EventArgs e)
        {
            panel.Size = new Size(base.Width, base.Height-28);
            panel.Location = new Point(0, 0);
            panel2.Size = new Size(base.Width, base.Height - miBoton.Height-1);
            panel2.Location = new Point(0,panel.Height);
            miBoton.Size = new Size(base.Width - 8, base.Height - 34);
            miBoton.Location = new Point(4,3);
            miLabel.Size = new Size(this.Width-5, 24);
            miLabel.Location = new Point(1, 1);
            panel2.BackColor = panel.BackColor;
        }
    }
}
