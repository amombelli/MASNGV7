using System.IO;

namespace Tecser.Business.Tools
{
    public static class FileInUse
    {
        public static bool IsFileLocked(string pathfile)
        {
            //FileStream stream = null;


            try
            {
                Stream stream = new FileStream(pathfile, FileMode.Open);
                {
                    // File/Stream manipulating code here
                    if (stream != null)
                        stream.Close();
                }
            }
            catch
            {
                //check here why it failed and ask user to retry if the file is in use

                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
    }
}
