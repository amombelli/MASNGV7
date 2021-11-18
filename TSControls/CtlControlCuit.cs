using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.VBTools;

namespace TSControls
{

    /// <summary>
    /// Control CUIT 2021.04.12
    /// </summary>
    public partial class CtlControlCuit : UserControl
    {
        public CtlControlCuit()
        {
            InitializeComponent();
        }

        public Color FondoOK = Color.LightGreen;
        public Color FondoBad = Color.LightPink;
        public Color ForeOK = Color.Navy;
        public Color ForeBad = Color.Red;

        public bool ResultadoValidacion { private set; get; }  //Resultado de validacion
        public string CUIT { private set; get; } //Valor CUIT ingresao
        public bool ZdoValidation { get; set; } //Ejecuta o no la validacion de CUIT
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                myMsk.ForeColor = value;
            }
        }
        public override Color BackColor
        {
            get => base.BackColor;
            set
            {
                base.BackColor = value;
                myMsk.BackColor = value;
            }
        }
        public string Value
        {
            private get => CUIT;
            set
            {
                CUIT = value;
                myMsk.Text = value;
                if (string.IsNullOrEmpty(Value))
                {
                    CUIT = null;
                    ResultadoValidacion = false;
                }
                else
                {
                    if (ZdoValidation)
                    {
                        if (CUIT == @"00-00000000-0")
                        {
                            ResultadoValidacion = false;
                            ctlSemaforo.SetLights = CtlSemaforo.ColoresSemaforo.Azul;
                        }
                        else
                        {
                            ValidacionCuitIngresado();
                        }
                    }
                    else
                    {
                        ResultadoValidacion = false;
                        ctlSemaforo.SetLights = CtlSemaforo.ColoresSemaforo.Azul;
                    }
                }
            }

        }
        private void ValidacionCuitIngresado()
        {
            if (CUIT.Length == 13 && CUIT != @"00-00000000-0")
            {
                ResultadoValidacion = new CuitValidation().ValidarCuit(CUIT);
                if (ResultadoValidacion)
                {
                    myMsk.BackColor = FondoOK;
                    myMsk.ForeColor = ForeOK;
                    ctlSemaforo.SetLights = CtlSemaforo.ColoresSemaforo.Verde;
                }
                else
                {
                    myMsk.BackColor = FondoBad;
                    myMsk.ForeColor = ForeBad;
                    ctlSemaforo.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                }
            }
            else
            {
                myMsk.BackColor = base.BackColor;
                myMsk.ForeColor = base.ForeColor;
                ctlSemaforo.SetLights = CtlSemaforo.ColoresSemaforo.Amarillo;
            }
        }
        private void myMsk_TextChanged(object sender, EventArgs e)
        {
            var m = (MaskedTextBox)sender;
            Value = m.Text;
        }
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                myMsk.Font = value;
                ctlSemaforo.Size = new Size(23, 23);
                myMsk.Location = new Point(1, 1);
                if (myMsk.Height < 20)
                {
                    base.Size = new Size(base.Width, 24);
                }
                else
                {
                    base.Size = new Size(myMsk.Width + 28, myMsk.Height + 2);
                }
                int altmedia = base.Height / 2;
                int locsem = altmedia - 12;
                if (locsem < 0)
                {
                    ctlSemaforo.Location = new Point(myMsk.Width + 3, 0);
                }
                else
                {
                    ctlSemaforo.Location = new Point(myMsk.Width + 3, locsem);
                }
            }
        }
        private void myMsk_DoubleClick(object sender, EventArgs e)
        {
            if (!myMsk.MaskCompleted)
            {
                myMsk.Text = @"00-00000000-0";
            }
            else
            {
                myMsk.Text = null;
            }
        }
        private void myMsk_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ZdoValidation)
            {
                if (myMsk.Text == @"00-00000000-0")
                {
                    tt.ToolTipTitle = @"Se ha ingresado un CUIT Generico";
                    tt.ToolTipIcon = ToolTipIcon.Info;
                    tt.Show(@"No se pudo validar el CUIT Ingresado", this, base.Width, 0, 1200);
                    e.Cancel = false;
                }
                else
                {
                    if (ResultadoValidacion)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        tt.ToolTipIcon = ToolTipIcon.Error;
                        tt.ToolTipTitle = @"El Numero de CUIT es Invalido";
                        tt.Show(@"No se pudo validar el CUIT Ingresado", this, base.Width, 0, 1200);
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
