using System;
using System.Drawing;
using System.Windows.Forms;

namespace TSControls
{
    //Control de Iconos
    //Fecha de Validacion 2021.04.13

    public enum CIconos
    {
        ExclamacionYellow,
        ExclamacionRed,
        Information,
        LamparitaGreen,
        TrianguloNaranja,
        Mas,
        Tilde,
        Equis,
        CuadradoBordo,
        Corazon,
        Estrella,
        ExclamacionOrange,
        Azul,
        Amarillo,
        Verde,
        Rojo
    };
    public enum TamañoIcono
    {
        Chico,
        Mediano,
        Grande
    }
    public enum UbicacionIcono
    {
        Normal,
        Center,
        Zoom,
    }
    public partial class CtlIconos : UserControl
    {
        public CtlIconos()
        {
            InitializeComponent();
        }

        private CIconos _iconoSeleccionado;
        private TamañoIcono _iconoSize = TamañoIcono.Chico;
        private UbicacionIcono _iconLocation = UbicacionIcono.Normal;
        public CIconos Get
        {
            get => _iconoSeleccionado;
        }
        public CIconos Set
        {
            get => _iconoSeleccionado;
            set
            {
                Setx(value);
                _iconoSeleccionado = value;
            }
        }
        public PictureBox GetImg(CIconos icono)
        {
            switch (icono)
            {
                case CIconos.ExclamacionYellow:
                    return pexclaAmarillo;

                case CIconos.ExclamacionRed:
                    return pexclaRojo;

                case CIconos.Information:
                    return pinformation;

                case CIconos.LamparitaGreen:
                    return plamparita;
                case CIconos.TrianguloNaranja:
                    return ptriangulonaranja;

                case CIconos.Mas:
                    return pmas;

                case CIconos.Tilde:
                    return ptilde;

                case CIconos.Equis:
                    return pequisRoja;

                case CIconos.CuadradoBordo:
                    return pcuadrado;

                case CIconos.Corazon:
                    return pcorazon;

                case CIconos.Estrella:
                    return pestrella;

                case CIconos.ExclamacionOrange:
                    return pexclaNaranja;

                case CIconos.Azul:
                    return zBlue;

                case CIconos.Amarillo:
                    return zYellow;

                case CIconos.Verde:
                    return zGreen;

                case CIconos.Rojo:
                    return zRed;

                default:
                    return pcorazon;
                    throw new ArgumentOutOfRangeException(nameof(icono), icono, null);
            }
        }
        public UbicacionIcono IconLocation
        {
            get => _iconLocation;
            set
            {
                _iconLocation = value;
                var x = GetImg(_iconoSeleccionado);
                switch (value)
                {
                    case UbicacionIcono.Normal:
                        x.SizeMode = PictureBoxSizeMode.Normal;
                        break;
                    case UbicacionIcono.Center:
                        x.SizeMode = PictureBoxSizeMode.CenterImage;
                        break;
                    case UbicacionIcono.Zoom:
                        x.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }
        public TamañoIcono IconSize
        {
            get => _iconoSize;
            set
            {
                var x = GetImg(_iconoSeleccionado);
                _iconoSize = value;
                switch (value)
                {
                    case TamañoIcono.Chico:
                        x.Size = new Size(16, 16);
                        base.Size = x.Size;
                        break;
                    case TamañoIcono.Mediano:
                        x.Size = new Size(20, 20);
                        base.Size = x.Size;
                        break;
                    case TamañoIcono.Grande:
                        x.Size = new Size(30, 30);
                        base.Size = x.Size;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }
        private void OcultaTodos()
        {
            pexclaAmarillo.Visible = false;
            pexclaRojo.Visible = false;
            pinformation.Visible = false;
            plamparita.Visible = false;
            ptriangulonaranja.Visible = false;
            pmas.Visible = false;
            ptilde.Visible = false;
            pequisRoja.Visible = false;
            pcuadrado.Visible = false;
            pcorazon.Visible = false;
            pestrella.Visible = false;
            pexclaNaranja.Visible = false;
            zBlue.Visible = false;
            zYellow.Visible = false;
            zGreen.Visible = false;
            zRed.Visible = false;
        }
        private void Setx(CIconos img)
        {
            OcultaTodos();
            switch (img)
            {
                case CIconos.ExclamacionYellow:
                    pexclaAmarillo.Visible = true;
                    break;
                case CIconos.ExclamacionRed:
                    pexclaRojo.Visible = true;
                    break;
                case CIconos.Information:
                    pinformation.Visible = true;
                    break;
                case CIconos.LamparitaGreen:
                    plamparita.Visible = true;
                    break;
                case CIconos.TrianguloNaranja:
                    ptriangulonaranja.Visible = true;
                    break;
                case CIconos.Mas:
                    pmas.Visible = true;
                    break;
                case CIconos.Tilde:
                    ptilde.Visible = true;
                    break;
                case CIconos.Equis:
                    pequisRoja.Visible = true;
                    break;
                case CIconos.CuadradoBordo:
                    pcuadrado.Visible = true;
                    break;
                case CIconos.Corazon:
                    pcorazon.Visible = true;
                    break;
                case CIconos.Estrella:
                    pestrella.Visible = true;
                    break;
                case CIconos.ExclamacionOrange:
                    pexclaNaranja.Visible = true;
                    break;
                case CIconos.Azul:
                    zBlue.Visible = true;
                    break;
                case CIconos.Amarillo:
                    zYellow.Visible = true;
                    break;
                case CIconos.Verde:
                    zGreen.Visible = true;
                    break;
                case CIconos.Rojo:
                    zRed.Visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(img), img, null);
            }
        }
    }
}
