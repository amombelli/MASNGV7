using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Tecser.Business.Tools
{
    public class FormatAndConversions
    {
        private bool KeyEnteredIsValid(string key)
        {
            Regex regex;
            regex = new Regex("[^0-9]+$"); //regex that matches disallowed text
            return regex.IsMatch(key);
        }


        /// <summary>
        /// Pasa a formato decimal un Texto Porcentaje
        /// </summary>
        public static decimal CPorcentajeADecimal(string value)
        {
            if (string.IsNullOrEmpty(value))
                value = @"0";

            if (value.StartsWith("%"))
            {
                value = value.Remove(0, 1);
            }

            if (value.EndsWith("%"))
            {
                value = value.Substring(0, value.Length - 1);
            }
            return Convert.ToDecimal(value) / 100;
        }

        //Pasa a decimal un formato $
        public decimal GetCurrencyFormat_Decimal(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return 0;

            if (value.StartsWith("$"))
            {
                value = value.Remove(0, 1);
            }

            value = value.Trim();

            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            string decimalSeparator = ci.NumberFormat.CurrencyDecimalSeparator;
            if (string.IsNullOrEmpty(value))
                return 0;

            return Decimal.Parse(value, NumberStyles.Currency);
        }

        /// <summary>
        /// Convierte a decimal un textbox que tiene el signo $ adelante
        /// </summary>
        public static decimal CCurrencyADecimal(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return 0;

            int signo = 1;
            if (value.Contains("-"))
            {
                signo = -1;
            }

            if (value.StartsWith("$"))
            {
                value = value.Remove(0, 1);
            }
            else if (value.EndsWith("$"))
            {
                value = value.Substring(0, value.Length - 1);
            }
            else if (value.StartsWith("ARS") || value.StartsWith("USD"))
            {
                value = value.Remove(0, 3);
            }
            else if (value.StartsWith("ARS ") || value.StartsWith("USD "))
            {
                value = value.Remove(0, 4);
            }

            if (value.Contains("$"))
            {
                var z = value.IndexOf("$");
                var z1 = value.Remove(0, z);
                value = z1;
            }
            value = value.Trim();
            var xvalor = Decimal.Parse(value, NumberStyles.Currency);
            return Math.Abs(xvalor) * signo;
        }
        public static decimal CCurrencyADecimal(TextBox textboxName)
        {
            var value = textboxName.Text;
            return CCurrencyADecimal(value);
        }


        /// <summary>
        /// Solo acepta numero decimal (con punto) y backspace
        /// Esta funcion se llama desde el evento keyPRess >> new FormatAndConversions().SoloDecimalKeyPress(sender, e);
        /// </summary>
        public static void SoloDecimalKeyPress(object sender, KeyPressEventArgs e, bool allowBackspace = true,
            bool allowSignoMenos = false, bool allowSignoMoneda = false, bool allowPorcentaje = false)
        {
            var cc = Thread.CurrentThread.CurrentCulture;
            var control = (TextBox)sender;

            if (allowBackspace && e.KeyChar == ('\b'))
            {
                return;
            }


            //Si es % solo puede ser el primer caracter o el ultimo caracter (siempre y cuando este permitido) y solo puede existir uno
            if (e.KeyChar == 37)
            {
                if (allowPorcentaje == false)
                {
                    e.Handled = true;
                    return;
                }

                if (string.IsNullOrEmpty(control.Text))
                    return; //si es % y es el primer caracter % lo permite 

                if (control.Text.Contains("%"))
                {
                    e.Handled = true; //solo puede haber uno
                    return;
                }

                return;

            }

            if (allowPorcentaje)
            {
                //si permite porcentaje tiene que fijarse que no este en el medio
                if (control.Text.Contains("%"))
                {
                    if (control.Text.StartsWith("%"))
                    {

                    }
                    else
                    {
                        //Tiene un porcentaje y NO arranca con porcentaje por lo tanto no puede seguir con nada!
                        e.Handled = true;
                        return;
                    }
                }
            }


            //** Control de Separador Decimal **

            if (string.IsNullOrEmpty(control.Text) && (e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator))
            {
                //El Separador decimal no puede ser el primer caracter
                e.Handled = true;
                return;
            }

            if (control.Text.Contains(".") && e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
            {
                //Solo se permite un '.'
                e.Handled = true;
                return;
            }

            //*No se permite separador de miles para no confundir
            if (e.KeyChar.ToString() == cc.NumberFormat.NumberGroupSeparator)
            {
                e.Handled = true;
                return;
            }

            //Permite o no Backspace
            if (e.KeyChar == 8)
            {
                if (allowBackspace)
                {
                    return;
                }

                e.Handled = true;
                return;
            }

            if (e.KeyChar == 32)
            {
                e.Handled = true;
                return;
            }

            if (control.Text.Length == 1)
            {
                //Controla que el segundo caracter no sea un '.' si el primero es un menos
                if (control.Text == cc.NumberFormat.NegativeSign)
                {
                    if (e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }

            if (e.KeyChar.ToString() == cc.NumberFormat.NegativeSign)
            {
                if (!allowSignoMenos)
                {
                    e.Handled = true;
                    return;
                }
                if (!string.IsNullOrEmpty(control.Text))
                {
                    //El signo menos solo puede ser el primer caracter
                    e.Handled = true;
                    return;
                }
                return;
            }

            if (e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
            {
                //A esta altura ya esta chequeado que es el unico separador decimal y que no viene despues de un -
                return;
            }


            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                return;
            }
            e.Handled = true;
        }

        //Esta hay que reemplazarla por String.("C2")
        public string SetCurrency(string texto)
        {
            Double value;
            texto = texto.Replace("$", "").TrimStart('0');
            if (Double.TryParse(texto, out value))
                return String.Format(CultureInfo.CurrentCulture, "{0:C2}", value);
            return "$0.00";
        }


        //Esta hay que reemplazarla por String.("C2")
        public string SetCurrency(decimal? numero)
        {

            if (numero != null)
                return String.Format(CultureInfo.CurrentCulture, "{0:C2}", numero);
            return "$0.00";
        }

        //esto hay que reemplezarlo por el CCurrencyADecimal!
        public decimal GetDecimal(string texto)
        {

            if (texto.StartsWith("$"))
            {
                texto = texto.Remove(0, 1);
            }

            if (texto.StartsWith("ARS") || texto.StartsWith("USD"))
            {
                texto = texto.Remove(0, 3);
            }

            if (texto.StartsWith("ARS ") || texto.StartsWith("USD "))
            {
                texto = texto.Remove(0, 4);
            }

            if (string.IsNullOrEmpty(texto))
                return 0;
            return Decimal.Parse(texto, NumberStyles.Currency);
        }

        public bool EsNumero(string numero)
        {
            Decimal value;
            return Decimal.TryParse(numero, out value);
        }

        private bool TextisValid(string text)
        {
            Regex money = new Regex(@"^\$(\d{1,3}(\,\d{3})*|(\d+))(\.\d{2})?$");
            return money.IsMatch(text);
        }

        /// <summary>
        /// Solo acepta numero entero y backspace
        /// Esta funcion se llama desde el evento keyPRess >> new FormatAndConversions().SoloDecimalKeyPress(sender, e);
        /// </summary>
        public static void SoloEnteroKeyPress(object sender, KeyPressEventArgs e)
        {
            var cc = Thread.CurrentThread.CurrentCulture;
            var control = (TextBox)sender;

            if (e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
            {
                e.Handled = true;
                return;
            }


            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 127)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Define un numero decimal en el format STRING de acuerdo a las funciones de AFIP (independientes a la config. regional)
        /// </summary>
        public static string DefineFormatoNumericoAFIP(decimal? value)
        {
            decimal valor;
            if (value == null)
            {
                valor = (decimal)0.00;
            }
            else
            {
                valor = (decimal)value;
            }
            return valor.ToString("0.00", CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Para usar en MaskedTextBox en metdo validating 
        /// Valida que el formato sea 00:00 (24hs)
        /// e.Cancel = FormatAndConversions.ValidaFormatoHora(sender);
        /// </summary>
        public static bool ValidaFormatoHora(object sender)
        {
            //Validacion de Formato 00:00
            var data = (MaskedTextBox)sender;
            string valor = data.Text.Replace(":", "").Trim();
            bool cancelx;

            if (valor.Length == 0)
                //permite salir dejando en blanco
                return false;

            var partes = data.Text.Split(':');
            if (partes.Length != 2)
            {
                //si no tiene el formato HH:MM no deja salir del masked
                return true;
            }

            cancelx = false;
            for (var ix = 0; ix < partes.Length; ix++)
            {
                int valorEntero;
                if (int.TryParse(partes[ix], out valorEntero))
                {
                    switch (ix)
                    {
                        case 0:
                            if (!(valorEntero <= 23 && valorEntero >= 0))
                            {
                                cancelx = true;
                            }
                            break;
                        case 1:
                            if (!(valorEntero <= 59 && valorEntero >= 0))
                            {
                                cancelx = true;
                            }
                            break;
                        default:
                            cancelx = true;
                            break;
                    }
                }
                else
                {
                    return true;
                }
            }
            return cancelx;
        }

        /// <summary>
        ///Retorna la cantidad de minutos entre 2 horas. - Usar con ValidaFormatoHora en el 
        ///evento validating del masked
        /// </summary>
        public static string CalculaMinutosEntreDosHoras(string hInicio, string hFin)
        {
            if (string.IsNullOrEmpty(hInicio) || string.IsNullOrEmpty(hFin))
            {
                return "0";
                //no se hace ningun calculo porque alguno de los dos esta vacio
            }
            DateTime horaInicio = Convert.ToDateTime(hInicio);
            DateTime horaFinal = Convert.ToDateTime(hFin);

            // A la hora final le restamos la hora de inicio
            TimeSpan diferencia = horaFinal.Subtract(horaInicio);
            var diferenciaMinutos = diferencia.TotalMinutes;
            return diferenciaMinutos.ToString(CultureInfo.CurrentCulture);
        }
    }

}

