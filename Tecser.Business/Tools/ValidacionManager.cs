using System.Drawing;
using System.Windows.Forms;

namespace Tecser.Business.Tools
{
    public class ValidacionManager
    {
        private readonly Form _fname;
        private readonly ErrorProvider _ep;
        private ToolTip _tp;

        public ValidacionManager(Form fname, ErrorProvider ep)
        {
            _fname = fname;
            _ep = ep;
            _resultadoValidacion = true;
        }

        public ValidacionManager(Form fname, ErrorProvider ep, ToolTip tp)
        {
            _fname = fname;
            _ep = ep;
            _tp = tp;
            _resultadoValidacion = true;
            _tp.AutoPopDelay = 5000;
            _tp.InitialDelay = 100;
            _tp.ReshowDelay = 500;
            _tp.ShowAlways = true;
            _tp.ToolTipIcon = ToolTipIcon.Warning;
            _tp.Active = true;
        }
        private bool _resultadoValidacion;
        public Color _colorResultado;

        public void ReseteaValidacion()
        {
            _resultadoValidacion = true;
            _colorResultado = Color.White;
        }

        public bool Valida(Control control, bool condicionIndeseable, string mensaje, bool aplicaColor)
        {
            var z = Valida(control, condicionIndeseable, mensaje);
            if (aplicaColor)
            {
                control.BackColor = _colorResultado;
            }
            return z;
        }
        public bool Valida(Control control, bool condicionIndeseable, string mensaje)
        {
            if (condicionIndeseable)
            {
                _ep.SetError(control, mensaje);
                _resultadoValidacion = false;
                _tp.IsBalloon = true;
                _tp.Active = true;
                _tp.SetToolTip(control, mensaje);
                _tp.ToolTipTitle = "Atencion Validacion";
                _colorResultado = Color.LightCoral;
                return false;
            }

            _ep.SetError(control, "");
            _tp.Active = false;
            _colorResultado = Color.LightGreen;
            return true;
        }

        public bool GetResultadoValidacion()
        {
            return _resultadoValidacion;
        }
    }
}
