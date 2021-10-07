using System;
using System.Windows.Forms;

namespace MASngFE._UserControls
{
    public partial class USemaforo4 : UserControl
    {
        public USemaforo4()
        {
            InitializeComponent();
            green.Visible = false;
            yellow.Visible = false;
            blue.Visible = false;
            red.Visible = false;
        }

        public enum Colores
        {
            Red,
            Green,
            Blue,
            Yellow,
            Apagado,
        };

        public void SetColor(Colores color)
        {
            green.Visible = false;
            yellow.Visible = false;
            blue.Visible = false;
            red.Visible = false;

            switch (color)
            {
                case Colores.Red:
                    red.Visible = true;
                    break;
                case Colores.Green:
                    green.Visible = true;
                    break;
                case Colores.Blue:
                    blue.Visible = true;
                    break;
                case Colores.Yellow:
                    yellow.Visible = true;
                    break;
                case Colores.Apagado:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }

        private void blue_Click(object sender, EventArgs e)
        {

        }

        private void yellow_Click(object sender, EventArgs e)
        {

        }

        private void green_Click(object sender, EventArgs e)
        {

        }

        private void red_Click(object sender, EventArgs e)
        {

        }
    }
}
