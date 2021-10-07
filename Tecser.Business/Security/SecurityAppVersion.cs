using Tecser.Business.MainApp;
using Tecser.Business.Tools;

//Clase responsable de validar si la version puede correr
namespace Tecser.Business.Security
{

    public class SecurityAppVersion
    {
        private const int AppMinimumToRun = 2;
        private int GetAppMinimumToRun()
        {
            return AppMinimumToRun;
        }
        public bool IsAppVersionApprovedToRun()
        {
            try
            {
                var vMinima = (int)new ConfigurationKeyManager("FEVMIN").GetValueData();
                if (this.GetAppMinimumToRun() >= vMinima)
                    return true;
                return false;
            }

#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (System.InvalidCastException e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                throw new TipoDatoIncorrecto("El Tipo de datos no es correcto para determinar la version");
            }
        }
    }
}
