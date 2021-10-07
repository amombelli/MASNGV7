using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Tecser.Business.Tools
{
    public static class Validaciones
    {
        /// <summary>
        /// Esta funcion va en el e.cancel del validation de un combo box
        /// </summary>
        public static bool CheckCmb(ComboBox cmb)
        {
            return cmb.SelectedValue == null && cmb.Text != string.Empty;
        }

        /// <summary>
        /// Usado cuando el combobox tiene valores tipeados fijos y no un bs
        /// Usar e.cancel = Validaciones.CheckComboBoxFixedItems(sender) en el validation
        /// </summary>
        public static void CheckComboBoxFixedItems(object sender, CancelEventArgs e, ErrorProvider ep = null, string mensaje = null)
        {
            //var cmb= (ComboBox) sender;
            //return cmb.SelectedItem == null && cmb.Text != String.Empty;

            var cmb = (ComboBox)sender;
            var validacion = cmb.SelectedItem == null && cmb.Text != String.Empty;
            e.Cancel = validacion;

            if (mensaje == null)
            {
                mensaje = "Debe proveer un valor correcto para este campo";
            }
            if (ep != null)
            {
                if (validacion)
                {
                    ep.SetError(cmb, mensaje);
                }
                else
                {
                    ep.SetError(cmb, "");
                }
            }
        }

        public static bool SetErrorErrorPrivider(Control ctrl, ErrorProvider ep, string mensaje = "Debe proveer un valor correcto para este campo")
        {
            ep.SetError(ctrl, mensaje);
            return false;
        }

        public static void BlanqueaEp(Control ctrl, ErrorProvider ep)
        {
            ep.SetError(ctrl, "");
        }

    }
}
