using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.TOOLS;

namespace TSControls
{
    public partial class CtlPeriodo : UserControl
    {
        public CtlPeriodo()
        {
            InitializeComponent();
        }

        //Declaracion de Variables
        private DateTime _fechaI;   //fecha inicial
        private DateTime _fechaF;   //fecha final
        private int _yearMinimo = DateTime.Today.AddYears(-2).Year;
        private int _yearMaximo = DateTime.Today.AddYears(2).Year;
        private string _periodo;    //periodo seleccionado
        public DateTime FechaInicio => _fechaI;
        public DateTime FechaFinal => _fechaF;
        public string Periodo
        {
            get => _periodo;
            set
            {
                _periodo = value;
                this.txtPeriodo.Text = value;
            }
        }

        public int? YearMinimo
        {
            get => _yearMinimo;
            set
            {
                if (value == null)
                {
                    _yearMinimo = DateTime.Today.AddYears(-2).Year;
                }
                else
                {
                    _yearMinimo = value.Value;
                }
            }
        }

        public int? YearMaximo
        {
            get => _yearMaximo;
            set
            {
                if (value == null)
                {
                    _yearMaximo = DateTime.Today.AddYears(2).Year;
                }
                else
                {
                    _yearMaximo = value.Value;
                }
            }
        }



        private void txtPeriodo_Validating(object sender, CancelEventArgs e)
        {
            if (txtPeriodo.Text.Length == 0)
            {
                _periodo = null;
                _fechaI = DateTime.Today;
                _fechaF = DateTime.Today;
                return;
            }

            if (txtPeriodo.Text.Length != 6)
            {
                toolTipX.ToolTipIcon = ToolTipIcon.Error;
                toolTipX.Show("Debe proveer un periodo valido en formato AAAA-MM", txtPeriodo, txtPeriodo.Width + 1, 0,
               1500);

                e.Cancel = true;
            }

            int year = Convert.ToInt32(txtPeriodo.Text.Substring(0, 4));
            int month = Convert.ToInt32(txtPeriodo.Text.Substring(4, 2));


            if (year < _yearMinimo || year > _yearMaximo)
            {
                toolTipX.ToolTipTitle = "Periodo Invalido";
                toolTipX.Show("Debe proveer un periodo valido en formato AAAA-MM - Año fuera de Rango", txtPeriodo, txtPeriodo.Width + 1, 0,
                    1500);
                e.Cancel = true;
                return;
            }

            if (month < 1 || month > 12)
            {
                toolTipX.ToolTipTitle = "Periodo Invalido";
                toolTipX.Show("Debe proveer un periodo valido en formato AAAA-MM - MES fuera de Rango", txtPeriodo, txtPeriodo.Width + 1, 0,
                    1500);
                e.Cancel = true;
                return;
            }

            _fechaI = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text);
            _fechaF = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text);
            _periodo = txtPeriodo.Text;
        }
        private void txtPeriodo_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            var posx = base.Location.X + txtPeriodo.Width;
            var posy = base.Location.Y;
            if (!e.IsValidInput)
            {
                toolTipX.ToolTipTitle = "Periodo Invalido";
                toolTipX.Show("Debe proveer un periodo valido en formato AAAA-MM", txtPeriodo, posx, posy,
                    1000);
                e.Cancel = true;
            }
            else
            {
                //Aca se puede hacer cualquier validacion adicional sobre restricciones de fechas 
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate < DateTime.Now)
                {
                    toolTipX.ToolTipTitle = "Periodo Invalido";
                    toolTipX.Show("La fecha es mayor a la de hoy", txtPeriodo, posx, posy,
                        1000);
                    e.Cancel = true;
                }
            }
        }
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                txtPeriodo.Font = value;
                base.Size = txtPeriodo.Size;
            }
        }

        private void CtlPeriodo_Resize(object sender, EventArgs e)
        {
            base.Size = txtPeriodo.Size;
        }

        private void txtPeriodo_DoubleClick(object sender, EventArgs e)
        {
            _periodo = DateTime.Today.Year.ToString() + @"-" + DateTime.Today.Month.ToString("D2");
            txtPeriodo.Text = DateTime.Today.Year.ToString() + @"-" + DateTime.Today.Month.ToString("D2");
        }
    }
}
