using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tecser.Business.Tools
{
    public class ReadOnlyFormControl
    {
        private readonly bool _value;
        private readonly Control _container;
        private readonly bool _fondoDisabled;
        private Color _controlColor;

        public bool IgnoraButton = true;
        public bool IgnoraCheckBox;
        public bool IgnoraTextBox;
        public bool IgnoraComboBox;
        public bool IgnoraLabel = true;
        public bool IgnoraDateTimePicker;


        //public ReadOnlyFormControl(bool value, System.Windows.Forms.Control container, bool fondoDisabled=false)
        //{
        //    _value = value; //true bloquea el control
        //    _container = container;
        //    _fondoDisabled = fondoDisabled; //El fondo queda disbled sino queda del mismo color que estaba antes
        //}

        /// <summary>
        /// Funcion para bloquear los controles de un panel?
        /// </summary>

        public ReadOnlyFormControl(bool value, Control container, bool fondoDisabled = false,
            bool ignoraButton = true, bool ignoraCk = false, bool ignoraTextBox = false, bool ignoraCombo = false,
            bool ignoraLabel = true, bool ignoraDateTimePicker = false)
        {
            _value = value; //true bloquea el control
            _container = container;
            _fondoDisabled = fondoDisabled; //El fondo queda disbled sino queda del mismo color que estaba antes
            IgnoraButton = ignoraButton;
            IgnoraCheckBox = ignoraCk;
            IgnoraTextBox = ignoraTextBox;
            IgnoraComboBox = ignoraCombo;
            IgnoraLabel = ignoraLabel;
            IgnoraDateTimePicker = ignoraDateTimePicker;
        }

        public void LockOrUnlockControlsInContainer()
        {
            try
            {
                foreach (Control ctrl in _container.Controls)
                {
                    LockControl(ctrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LockControl(Control ctrl)
        {
            switch (ctrl.GetType().Name)
            {
                case "TextBox":
                    if (IgnoraTextBox == false)
                    {
                        _controlColor = ctrl.BackColor;
                        ((TextBox)ctrl).ReadOnly = _value;
                        if (_fondoDisabled == false)
                        {
                            ctrl.BackColor = _controlColor;
                        }
                    }
                    break;
                case "ComboBox":
                    if (IgnoraComboBox == false)
                    {
                        _controlColor = ctrl.BackColor;
                        ((ComboBox)ctrl).Enabled = !_value;
                        if (_fondoDisabled == false)
                        {
                            ctrl.BackColor = _controlColor;
                        }
                    }
                    break;
                case "CheckBox":
                    if (IgnoraCheckBox == false)
                    {
                        _controlColor = ctrl.BackColor;
                        ((CheckBox)ctrl).Enabled = !_value;
                        if (_fondoDisabled == false)
                        {
                            ctrl.BackColor = _controlColor;
                        }
                    }
                    break;
                case "DateTimePicker":
                    if (IgnoraDateTimePicker == false)
                    {
                        _controlColor = ctrl.BackColor;
                        ((DateTimePicker)ctrl).Enabled = !_value;
                        if (_fondoDisabled == false)
                        {
                            ctrl.BackColor = _controlColor;
                        }
                    }
                    break;
                case "Label":
                    if (IgnoraLabel == false)
                    {
                        _controlColor = ctrl.BackColor;
                        ((Label)ctrl).Enabled = !_value;
                        if (_fondoDisabled == false)
                        {
                            ctrl.BackColor = _controlColor;
                        }
                    }
                    break;
                case "Button":
                    if (IgnoraButton == false)
                    {
                        _controlColor = ctrl.BackColor;
                        ((Button)ctrl).Enabled = !_value;
                        if (_fondoDisabled == false)
                        {
                            ctrl.BackColor = _controlColor;
                        }
                    }
                    break;


                default:
                    Console.WriteLine("Tipo de datos {0} no manejado", ctrl.GetType().Name);
                    break;
            }

            if (ctrl.Controls.Count > 0)
            {
                var lockControl = new ReadOnlyFormControl(_value, ctrl, _fondoDisabled, IgnoraButton, IgnoraComboBox,
                    IgnoraTextBox, IgnoraComboBox, IgnoraLabel, IgnoraDateTimePicker);
                lockControl.LockOrUnlockControlsInContainer();
            }
        }
    }
}

