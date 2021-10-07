using MASngFE.Properties;

namespace MASngFE.Application
{
    public static class AppVersionManager
    {
        public static string GetAppVersion()
        {
            return Settings.Default.AppVersion;
        }

        public static void SetAppVersion(string newAppVersion)
        {
            Settings.Default.AppVersion = newAppVersion;
            Settings.Default.Save();
        }
    }
}
