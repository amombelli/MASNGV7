using System;
using System.Drawing;
using System.Windows.Forms;

namespace TSControls
{
    public partial class CtlClock : UserControl
    {
        //-------------------------------------------------------------------------
        public CtlClock()
        {
            InitializeComponent();
        }

        //Variables Privadads de Almacenamiento
        private Color colFColor;
        private Color colBColor;

        // Declares the name and type of the property.
        public Color ClockBackColor
        {
            // Retrieves the value of the private variable colBColor.
            get
            {
                return colBColor;
            }
            // Stores the selected value in the private variable colBColor, and
            // updates the background color of the label control lblDisplay.
            set
            {
                colBColor = value;
                lblDisplay.BackColor = colBColor;
            }
        }
        // Provides a similar set of instructions for the foreground color.
        public Color ClockForeColor
        {
            get
            {
                return colFColor;
            }
            set
            {
                colFColor = value;
                lblDisplay.ForeColor = colFColor;
            }
        }



        private void ctlClock_Load(object sender, EventArgs e)
        {

        }

        protected virtual void timer1_Tick(object sender, EventArgs e)
        {
            // Causes the label to display the current time.
            lblDisplay.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
