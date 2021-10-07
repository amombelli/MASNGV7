using System.Windows.Forms;

namespace Tecser.Business.MainApp
{
    public static class GlobalApp
    {
        public static string AppUsername { get; set; }
        public static string Tcode { get; set; }
        public static Form MainForm { get; set; }
        public static ModoApp Modo { get; set; }
        public static string CnnApp { get; set; }
        public static string CnnSec { get; set; }
        public static string AppVersion { get; set; }
        public const decimal MaxCosto = (decimal)999999;
    }

    public enum ModoApp
    {
        Produccion,
        Desarrollo,
        Testeo
    };
}
