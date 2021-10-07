using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MASngFE._UserControls
{
    public partial class FechaControlBase : System.Windows.Forms.MaskedTextBox
    {
        public FechaControlBase()
        {
            InitializeComponent();
            MaskInputRejected += FechaTextBox_MaskInputRejected;
            TypeValidationCompleted += FechaTextBox_TypeValidationCompleted;
            _fechaMinima = DateTime.Today.AddYears(-1);
            _fechaMaxima = DateTime.Today.AddYears(1);
        }

        //----------------------------------------------------------------------------------------------
        public DateTime? Fecha { get; protected set; }
        public bool FechaOK { get; protected set; }
        private DateTime _fechaMinima;
        private DateTime _fechaMaxima;


        //----------------------------------------------------------------------------------------------


        /// <summary>
        /// Si la fecha minima/maxima es null se setea +/- 1 año
        /// </summary>
        public void InitControl(DateTime? FechaMinima, DateTime? FechaMaxima, bool isBallon = true)
        {
            _fechaMinima = FechaMinima ?? DateTime.Today.AddYears(-1);
            _fechaMaxima = FechaMaxima ?? DateTime.Today.AddYears(1);
            this.myToolTip.IsBalloon = isBallon;
            this.myToolTip.ToolTipIcon = ToolTipIcon.Error;
        }


        private void FechaTextBox_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            var myTextBox = (MaskedTextBox)sender;
            myTextBox.BackColor = Color.OrangeRed;
            Fecha = null;
            myToolTip.ToolTipTitle = "Formato Incorrecto";
            myToolTip.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA",
                myTextBox,
                myTextBox.Location, 5000);
        }

        private void FechaTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            var myTextBox = (MaskedTextBox)sender;
            DateTime dt;
            if (DateTime.TryParseExact(myTextBox.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out dt))
            {
                //valid date
                myTextBox.BackColor = Color.GreenYellow;
                Fecha = dt;
            }
            else
            {
                //invalid date
                myToolTip.ToolTipTitle = "Ingreso de Datos Incorrectos";
                myToolTip.Show("Los datos ingresados no corresponden a una fecha valida [DD/MM/AAAA]",
                    myTextBox,
                    myTextBox.Location, 5000);

                myTextBox.BackColor = Color.OrangeRed;
                Fecha = null;
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void MiToolTip(string mensaje, int duracion = 2000, bool ballon = false)
        {
            this.myToolTip.IsBalloon = false;
            this.myToolTip.SetToolTip(this, "Atencion");
            this.myToolTip.Show(mensaje, this, duracion);
            this.myToolTip.ToolTipIcon = ToolTipIcon.Error;
        }

        private void FechaControlBase_KeyUp(object sender, KeyEventArgs e)
        {
            FechaOK = false;
            var ctrl = (MaskedTextBox)sender;
            var loc = (FechaControlBase)sender;

            if (ctrl.MaskFull)
            {
                ValidaMascara(ctrl);
            }
            else
            {
                this.Fecha = null;
                ctrl.BackColor = Color.LightSalmon;
            }
        }

        private void ValidaMascara(MaskedTextBox sender)
        {
            var myTextBox = sender;
            DateTime dt;
            if (DateTime.TryParseExact(myTextBox.Text, "d/M/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                Fecha = dt;
                if (dt >= _fechaMinima && dt < _fechaMaxima)
                {
                    FechaOK = true;
                    myTextBox.BackColor = Color.LightGreen;
                }
                else
                {
                    FechaOK = false;
                    myTextBox.BackColor = Color.Pink;
                    Point location = myTextBox.PointToScreen(Point.Empty);
                    this.myToolTip.ToolTipTitle = "Fecha Invalida";
                    this.myToolTip.Show($"La fecha ingresada debe estar comprendida entre {_fechaMinima.ToString("d")} y {_fechaMaxima.ToString("d")}", myTextBox, myTextBox.Location, 3000);
                    this.myToolTip.ToolTipIcon = ToolTipIcon.Warning;
                    myToolTip.IsBalloon = true;
                }

            }
            else
            {
                //invalid date
                myToolTip.ToolTipTitle = "Ingreso de Datos Incorrectos";
                myToolTip.Show("Los datos ingresados no corresponden a una fecha valida [DD/MM/AAAA]",
                    myTextBox,
                    myTextBox.Location, 5000);

                myTextBox.BackColor = Color.OrangeRed;
                Fecha = null;
                FechaOK = false;

            }
        }
    }
}
