using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO;

namespace TSControls
{
    public partial class CtlFechaTs : UserControl
    {
        public CtlFechaTs()
        {
            InitializeComponent();
            TC = null;
            PeriodoFIOpen = false;
        }


        private DateTime? Fecha { get; set; }
        public decimal? TC { get; private set; }
        public bool PeriodoFIOpen { get; private set; }
        public bool ValidarRangoFecha { get; set; }

        private Color _backColorFecha;
        private Color _foreColorFecha;
        private ColoreSemaforo _colorSemaforo;
        public DateTime? FechaMinima { get; set; }
        public DateTime? FechaMaxima { get; set; }
        public enum ColoreSemaforo
        {
            Green,
            Yellow,
            Red
        };

        //Propiedades Accesibles
        public ColoreSemaforo SetLights
        {
            get => _colorSemaforo;
            set
            {
                _colorSemaforo = value;
                SetSemaforo(_colorSemaforo);
            }
        }
        public Color ColorFondoFecha
        {
            get => _backColorFecha;
            set
            {
                _backColorFecha = value;
                mskFecha1.BackColor = _backColorFecha;
            }
        }
        public Color ColorForeFecha
        {
            get => _foreColorFecha;
            set
            {
                _foreColorFecha = value;
                mskFecha1.ForeColor = _foreColorFecha;
            }
        }

        public DateTime? Value
        {
            get => Fecha;
            set
            {
                Fecha = value;
                if (value != null)
                {
                    mskFecha1.Text = CompletaFechaToFechaMask(Fecha.Value);
                }
                else
                {
                    mskFecha1.Text = null;
                }
            }
        }

        public bool ObtieneTCAuto { get; set; }
        public bool CheckPeriodoFIAuto { get; set; }
   

        private bool CheckPeriodoFIisOpen()
        {
            if (Fecha == null) return false;
            var pOpen = new PeriodoAvailability().CheckPeriodoOpenFI(Fecha.Value);
            return pOpen;
        }
        private void ctlFechaControl_Load(object sender, EventArgs e)
        {
            zGreen.Visible = false;
            zRed.Visible = false;
            zYellow.Visible = false;
            ObtieneTCAuto = false;
            CheckPeriodoFIAuto = false;
            ValidarRangoFecha = false;
        }
        private void SetSemaforo(ColoreSemaforo colorS)
        {
            zGreen.Visible = false;
            zRed.Visible = false;
            zYellow.Visible = false;
            _colorSemaforo = colorS;

            switch (colorS)
            {
                case ColoreSemaforo.Green:
                    zGreen.Visible = true;
                    break;
                case ColoreSemaforo.Yellow:
                    zYellow.Visible = true;
                    break;
                case ColoreSemaforo.Red:
                    zRed.Visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(colorS), colorS, null);
            }
        }
        
        private void mskFecha1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Fecha = null;
            TC = null;
            PeriodoFIOpen = false;
            SetSemaforo(ColoreSemaforo.Red);
            toolTipX.ToolTipTitle = "Ingreso de Datos Incorrectos";
            toolTipX.Show("Verifique el Ingreso de una fecha en formato DD/MM/AAAA", mskFecha1, mskFecha1.Location, 1600);
        }
        private void mskFecha1_DoubleClick(object sender, EventArgs e)
        {
            Fecha = DateTime.Today;
            mskFecha1.Text = CompletaFechaToFechaMask(Fecha.Value);

            SetSemaforo(ColoreSemaforo.Green);
            if (CheckPeriodoFIAuto == true)
                CheckPeriodoFIisOpen();
        }
        private string CompletaFechaToFechaMask(DateTime fecha)
        {
            return fecha.Day.ToString("D2") + fecha.Month.ToString("D2") +
                   fecha.Year.ToString("D4");
        }
        private void mskFecha1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParseExact(mskFecha1.Text,
                "d/M/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                //Fecha Valida
                Fecha = dt;
                SetSemaforo(ColoreSemaforo.Green);
                if (CheckPeriodoFIAuto)
                    CheckPeriodoFIisOpen();

                if (ObtieneTCAuto)
                    TC = new ExchangeRateManager().GetExchangeRate(Fecha.Value);
            }
            else
            {
                //invalid date
                toolTipX.ToolTipTitle = "Ingreso de Datos Incorrectos";
                toolTipX.Show("Verifique el Ingreso de una fecha en formato DD/MM/AAAA",
                    mskFecha1,
                    mskFecha1.Location, 3000);
                Fecha = null;
                SetSemaforo(ColoreSemaforo.Red);
                PeriodoFIOpen = false;
                TC = null;
                mskFecha1.Text = null;
            }
        }
        private void mskFecha1_Validating(object sender, CancelEventArgs e)
        {
            if (ValidarRangoFecha == false)
                return;
            if (mskFecha1.MaskCompleted && Fecha != null)
            {
                if (FechaMinima == null)
                {
                    if (FechaMaxima == null)
                    {
                        //no valida ninguna fecha
                    }
                    else
                    {
                        //validar que la fecha ingresada sea menor o igual a la fecha maxima
                        if (Fecha > FechaMaxima)
                        {
                            SetSemaforo(ColoreSemaforo.Yellow);
                            toolTipX.ToolTipTitle = "Rango de Fechas Invalido";
                            toolTipX.Show("La Fecha Ingresada no cumple con las limitaciones definidas. Fuera de Rango",
                                mskFecha1, mskFecha1.Location, 1600);
                            e.Cancel = true;
                        }
                    }
                }
                else
                {
                    if (FechaMaxima == null)
                    {
                        //validar que la fecha ingresada sea mayor o igual a la fecha minima
                        if (Fecha < FechaMinima)
                        {
                            SetSemaforo(ColoreSemaforo.Yellow);
                            toolTipX.ToolTipTitle = "Rango de Fechas Invalido";
                            toolTipX.Show("La Fecha Ingresada no cumple con las limitaciones definidas. Fuera de Rango",
                                mskFecha1, mskFecha1.Location, 1600);
                            e.Cancel = true;
                        }

                    }
                    else
                    {
                        //validar que la fecha ingreada sea mayor o igual a la fecha minima 
                        //y que sea menor o igual a la fecha maxima
                        if (Fecha >= FechaMinima && Fecha <= FechaMaxima)
                        {

                        }
                        else
                        {
                            SetSemaforo(ColoreSemaforo.Yellow);
                            toolTipX.ToolTipTitle = "Rango de Fechas Invalido";
                            toolTipX.Show("La Fecha Ingresada no cumple con las limitaciones definidas. Fuera de Rango",
                                mskFecha1, mskFecha1.Location, 1600);
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                mskFecha1.Font = value;
                mskFecha1.Location = new Point(1, 1);
                zRed.Size = new Size(22,22);
                zYellow.Size = new Size(22, 22);
                zGreen.Size = new Size(22, 22);
                if (mskFecha1.Height < 21)
                {
                    base.Size = new Size(base.Width, 21);
                }
                else
                {
                    base.Size = new Size(mskFecha1.Width +zRed.Width+5,mskFecha1.Height+2);
                }

                int altura = (base.Height/2)-11;
                if (altura < 0)
                    altura = 0;
                zYellow.Location = new Point(mskFecha1.Width + 3,altura);
                zRed.Location = new Point(mskFecha1.Width + 3, altura);
                zGreen.Location = new Point(mskFecha1.Width + 3, altura);
            }
        }

        private void CtlFechaTs_Resize(object sender, EventArgs e)
        {
            if (mskFecha1.Height < 21)
            {
                base.Size = new Size(base.Width, 21);
            }
            else
            {
                zRed.Size = new Size(22, 22);
                zYellow.Size = new Size(22, 22);
                zGreen.Size = new Size(22, 22);
                if (base.BorderStyle == BorderStyle.None)
                {
                    base.Size = new Size(mskFecha1.Width + zRed.Width + 5, mskFecha1.Height + 2);
                }
                else
                {
                    base.Size = new Size(mskFecha1.Width + zRed.Width + 5, mskFecha1.Height + 4);
                }
            }
        }
    }
}
