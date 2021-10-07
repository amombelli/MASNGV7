using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Tools
{
    public class ControlesEnFormularios
    {
        private readonly Control _container;
        private readonly bool _ignoraButton;
        private readonly bool _ignoraCheckBox;
        private readonly bool _ignoraTextBox;
        private readonly bool _ignoraComboBox;
        private readonly bool _ignoraLabel;
        private readonly bool _ignoraDateTimePicker;
        private readonly bool _ignorePictureBox;
        private readonly bool _ignoreMaskedTextBox;
        private readonly bool _ignoreDataGridView;
        private readonly bool _ignoraPanel;

        public ControlesEnFormularios(Control container, bool ignoraButton = true, bool ignoraCk = false,
            bool ignoraTextBox = false, bool ignoraCombo = false, bool ignoraLabel = true,
            bool ignoraDateTimePicker = false, bool ignorePictureBox = true, bool ignoreMaskedTextBox = false,
            bool ignoreDataGridView = true, bool ignoraPanel = true)
        {
            _container = container;
            _ignoraButton = ignoraButton;
            _ignoraCheckBox = ignoraCk;
            _ignoraTextBox = ignoraTextBox;
            _ignoraComboBox = ignoraCombo;
            _ignoraLabel = ignoraLabel;
            _ignoraDateTimePicker = ignoraDateTimePicker;
            _ignorePictureBox = ignorePictureBox;
            _ignoreMaskedTextBox = ignoreMaskedTextBox;
            _ignoreDataGridView = ignoreDataGridView;
            _ignoraPanel = ignoraPanel;
        }


        //Form form = (Form)Activator.CreateInstance(formFullName);
        //Type type = typeof(TextBox);

        public RtnListControlInForm GetListOfControls()
        {
            var rtx = new RtnListControlInForm
            {
                ObjetosNoManejados = new List<RtnElementosSingle>(),
                ObjetosIgnorados = new List<RtnElementosSingle>(),
                ObjetosOK = new List<RtnElmentControlManaged>()
            };
            try
            {
                foreach (Control ctrl in _container.Controls)
                {
                    //Debug.Print("## Analizamos >> " + ctrl.Name);
                    rtx = (GetControl(ctrl, rtx, _container.Name));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return rtx;
        }

        private RtnListControlInForm GetControl(Control ctrl, RtnListControlInForm lx, string containerPadre)
        {
            bool CheckIn = true;
            switch (ctrl.GetType().Name)
            {
                case "TextBox":
                    if (_ignoraTextBox)
                    {
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    }
                    else
                    {
                        var p = new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            Control = ctrl.Name,
                            MapAction = ctrl.Name + @".Text=",
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        };
                        lx.ObjetosOK.Add(p);
                        //Console.WriteLine(ctrl.Name + @".Text=");
                    }

                    break;
                case "ComboBox":
                    if (_ignoraComboBox)
                    {
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    }
                    else
                    {
                        lx.ObjetosOK.Add(new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            MapAction = ctrl.Name + ".SelectedValue=",
                            Control = ctrl.Name,
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        });
                    }

                    break;
                case "CheckBox":
                    if (_ignoraCheckBox)
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    else
                    {
                        lx.ObjetosOK.Add(new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            MapAction = ctrl.Name + ".Checked=",
                            Control = ctrl.Name,
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        });
                        //Console.WriteLine(ctrl.Name + @".Checked=");
                    }

                    break;
                case "DateTimePicker":
                    if (_ignoraDateTimePicker)
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    else
                    {
                        lx.ObjetosOK.Add(new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            MapAction = ctrl.Name + ".Value=",
                            Control = ctrl.Name,
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        });
                    }

                    //Console.WriteLine(ctrl.Name + @".Value=");
                    break;
                case "Label":
                    if (_ignoraLabel)
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    else
                    {
                        lx.ObjetosOK.Add(new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            MapAction = ctrl.Name + ".Text=",
                            Control = ctrl.Name,
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        });
                        //Console.WriteLine(ctrl.Name + @".Label=");  
                    }

                    break;
                case "Button":
                    if (_ignoraButton)
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    else
                    {
                        lx.ObjetosOK.Add(new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            MapAction = ctrl.Name + ".Enabled=",
                            Control = ctrl.Name,
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        });
                    }

                    //Console.WriteLine(ctrl.Name + @".Enabled=");
                    break;
                case "Panel":
                    if (_ignoraPanel)
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    else
                    {
                        lx.ObjetosOK.Add(new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            MapAction = ctrl.Name + ".??=",
                            Control = ctrl.Name,
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        });
                    }

                    break;
                case "PictureBox":
                    if (_ignorePictureBox)
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    else
                    {
                        lx.ObjetosOK.Add(new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            MapAction = ctrl.Name + ".??=",
                            Control = ctrl.Name,
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        });
                    }

                    break;
                case "MaskedTextBox":
                    if (_ignoreMaskedTextBox)
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    else
                    {
                        lx.ObjetosOK.Add(new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            MapAction = ctrl.Name + ".Text=",
                            Control = ctrl.Name,
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        });
                    }

                    break;
                case "DataGridView":
                    if (_ignoreDataGridView)
                        lx.ObjetosIgnorados.Add(new RtnElementosSingle
                        {
                            ControlName = ctrl.Name,
                            ControlType = ctrl.GetType().Name
                        });
                    else
                    {
                        lx.ObjetosOK.Add(new RtnElmentControlManaged
                        {
                            Type = ctrl.GetType().Name,
                            MapAction = ctrl.Name + ".Enabled=",
                            Control = ctrl.Name,
                            Container = containerPadre,
                            TabValue = ctrl.TabIndex,
                        });
                    }
                    CheckIn = false; //No chequear dentro de un DataGridview porque trae propiedades no manejables
                    break;
                default:
                    lx.ObjetosNoManejados.Add(new RtnElementosSingle
                    {
                        ControlName = ctrl.Name,
                        ControlType = ctrl.GetType().Name
                    });
                    CheckIn = false;
                    break;
            }

            if (ctrl.Controls.Count > 0)
            {
                if (CheckIn)
                {
                    //Debug.Print("## Inside ## "+ ctrl.Name);
                    var lockControl = new ControlesEnFormularios(ctrl, _ignoraButton, _ignoraComboBox, _ignoraTextBox,
                        _ignoraComboBox, _ignoraLabel, _ignoraDateTimePicker);
                    var xx = lockControl.GetListOfControls();
                    lx.ObjetosNoManejados.AddRange(xx.ObjetosNoManejados);
                    lx.ObjetosIgnorados.AddRange(xx.ObjetosIgnorados);
                    lx.ObjetosOK.AddRange(xx.ObjetosOK);
                }
            }

            return lx;
        }
    }
}

