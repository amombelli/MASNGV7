using System;
using System.Windows.Forms;

namespace TSControls
{
    public partial class CtlSemaforo : UserControl
    {
        public enum ColoresSemaforo
        {
            Rojo,
            Amarillo,
            Verde,
            Azul
        };

        public CtlSemaforo()
        {
            InitializeComponent();
            zYellow.Visible = false;
            zBlue.Visible = false;
            zGreen.Visible = false;
            zRed.Visible = false;
        }

        public ColoresSemaforo GetColorActivo { get; private set; }
        public ColoresSemaforo SetLights
        {
            get => GetColorActivo;
            set
            {
                GetColorActivo = value;
                SetSemaforo(GetColorActivo);
            }
        }

        private void SetSemaforo(ColoresSemaforo colorS)
        {
            zGreen.Visible = false;
            zRed.Visible = false;
            zYellow.Visible = false;
            zBlue.Visible = false;

            switch (colorS)
            {
                case ColoresSemaforo.Verde:
                    zGreen.Visible = true;
                    break;
                case ColoresSemaforo.Amarillo:
                    zYellow.Visible = true;
                    break;
                case ColoresSemaforo.Rojo:
                    zRed.Visible = true;
                    break;
                case ColoresSemaforo.Azul:
                    zBlue.Visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(colorS), colorS, null);
            }
        }
        private void CtlSemaforo_Load(object sender, EventArgs e)
        {

        }
    }
}
