using System.Drawing;
using System.IO;

namespace Tecser.Business.MainApp
{
    public class ImageManager
    {

        public byte[] ConvertFiltoByte(string filePath)
        {
            byte[] data = null;
            var fileInfo = new FileInfo(filePath);
            var numberOfBytes = fileInfo.Length;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var bynaryReader = new BinaryReader(fileStream);
            data = bynaryReader.ReadBytes((int)numberOfBytes);
            return data;
        }

        public Image ConvertByteToImage(byte[] imagen)
        {
            if (imagen == null)
                return null;
            Image foto;
            using (MemoryStream ms = new MemoryStream(imagen, 0, imagen.Length))
            {
                ms.Write(imagen, 0, imagen.Length);
                foto = Image.FromStream(ms, true);
            }

            return foto;

        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }



    }
}
