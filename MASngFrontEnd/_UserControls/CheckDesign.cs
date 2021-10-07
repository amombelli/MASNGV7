namespace MASngFE._UserControls
{
    public static class CheckDesign
    {
        public static bool InDesignMode()
        {
            try
            {
                return System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
            }
            catch
            {
                return false;
            }
        }
    }
}
