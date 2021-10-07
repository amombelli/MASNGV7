using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MASngFE._UserControls
{
    public partial class FechaTextBoxBase : MaskedTextBox
    {
        protected FechaTextBoxBase()
        {
            InitializeComponent();
            MaskInputRejected += FechaTextBox_MaskInputRejected;
            TypeValidationCompleted += FechaTextBox_TypeValidationCompleted;
        }
        public DateTime? FechaDocumento { get; protected set; }
        private void FechaTextBox_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            myTextBox.BackColor = Color.OrangeRed;
            FechaDocumento = null;
            myToolTip.ToolTipTitle = "Formato Incorrecto";
            myToolTip.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA",
                myTextBox,
                myTextBox.Location, 5000);
        }
        private void FechaTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParseExact(myTextBox.Text, "d/M/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt))
            {
                //valid date
                myTextBox.BackColor = Color.GreenYellow;
                FechaDocumento = dt;
            }
            else
            {
                //invalid date
                myToolTip.ToolTipTitle = "Ingreso de Datos Incorrectos";
                myToolTip.Show("Los datos ingresados no son correctos!(verifique que sea exacto una fecha DD/MM/AAAA",
                    myTextBox,
                    myTextBox.Location, 5000);

                myTextBox.BackColor = Color.OrangeRed;
                FechaDocumento = null;
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void MiToolTip(string mensaje, int duracion = 2000)
        {
            this.myToolTip.IsBalloon = false;
            this.myToolTip.SetToolTip(this, "Atencion");
            this.myToolTip.Show(mensaje, this, duracion);
            this.myToolTip.ToolTipIcon = ToolTipIcon.Error;
        }
    }
}
