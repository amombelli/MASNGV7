using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Tecser.Business.Tools
{
    public class ControlsInForm
    {
        public void GetTextBoxInForm(Type formFullName)
        {
            Form form = (Form)Activator.CreateInstance(formFullName);
            Type type = typeof(TextBox);
            var controls = form.Controls.Cast<Control>();
            foreach (Control control in form.Controls)
            {
                Debug.Print(control.Name);
            }
        }

        public void GetAll(Control formName)
        {
            Type type = typeof(TextBox);
            var controls = formName.Controls.Cast<Control>();
            var p = controls.ToList();

            //    var  p1=controls.SelectMany(ctrl => GetAll(ctrl)).Concat(controls).Where(c => c.GetType() == type);



            //var z = formName.Controls.Cast<Control>();
            //var y = z.SelectMany(x => GetAll(x));

            //foreach (Control control in formName.Controls)
            //{


            //    if (control is TextBox)
            //        // You can check any other property here and do what you want
            //        // for example:
            //        if ((control as TextBox).Text == string.Empty)
            //            ;//Action
            //}

            //foreach (Control control in formName.Controls)
            //{
            //    var controls =control.Controls.Cast<Control>();

            //    return control

            //        SelectMany(x => GetAll(x, type)).Concat(controls)
            //        .Where(c => c.GetType() == type);
            //}
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                .Concat(controls)
                .Where(c => c.GetType() == type);
        }
    }
}
