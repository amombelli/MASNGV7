using System;
using System.IO;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using TecserEF.Entity;
using WebServicesAFIP;

namespace Tecser.Business.Transactional.FI
{
    public class CodigoBarrasAfip
    {
        public string GeneraCodigoBarras(int idFactura, bool generaSiExiste = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                TipoComprobante tipoC;
                switch (d.TIPO_DOC)
                {
                    case "FA":
                        tipoC = TipoComprobante.Factura;
                        break;
                    case "ND":
                        tipoC = TipoComprobante.NotaDebito;
                        break;
                    case "NC":
                        tipoC = TipoComprobante.NotaCredito;
                        break;
                    default:
                        return null;
                }
                var suc = d.PV_AFIP;
                var path = AppDomain.CurrentDomain.BaseDirectory + @"Barras\" + suc + d.ND_AFIP;
                var fechaVenYyyymmdd = d.CAE_VTO.Value.ToString("yyyyMMdd");

                if (generaSiExiste == false)
                {
                    if (!File.Exists(path + ".jpg"))
                        GeneraCodigoBarras("30709669091", tipoC, suc, d.CAE, fechaVenYyyymmdd, path);
                }
                else
                {
                    GeneraCodigoBarras("30709669091", tipoC, suc, d.CAE, fechaVenYyyymmdd, path);
                }
                return path;
            }
        }
        public void GeneraCodigoBarras(string cuit, TipoComprobante tipoComprobante, string puntoVentaChar4, string caeChar14, string vencimientoCAEYYYYMMDD, string pathFilename)
        {
            //CUIT Emisor factura (11)
            //Punto Venta (4)
            //CAE (14)
            //Fecha Venc CAE (8)
            //Digito Verificador (1)
            string tipoC;
            switch (tipoComprobante)
            {
                case TipoComprobante.Factura:
                    tipoC = "01";
                    break;
                case TipoComprobante.NotaDebito:
                    tipoC = "02";
                    break;
                case TipoComprobante.NotaCredito:
                    tipoC = "03";
                    break;
                case TipoComprobante.Recibo:
                    tipoC = "04";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipoComprobante), tipoComprobante, null);
            }

            //Ejemplo info >> 30709669091 02  4001   61203034739042    20110529
            dynamic pyI25 = Activator.CreateInstance(Type.GetTypeFromProgID("PyI25"));
            string barras = cuit + tipoC + puntoVentaChar4 + caeChar14 + vencimientoCAEYYYYMMDD;
            barras = barras + pyI25.DigitoVerificadorModulo10(barras); //Agrega digito verificador

            //
            if (!Directory.Exists(Path.GetDirectoryName(pathFilename)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pathFilename));
            }
            //

            if (FileInUse.IsFileLocked(pathFilename + ".png"))

                if (File.Exists(pathFilename + ".png"))
                    File.Delete(pathFilename + ".png");


            if (File.Exists(pathFilename + ".jpg"))
                File.Delete(pathFilename + ".jpg");


            //Imagen PNG - Aspecto 1x para visualizar pantalla o email
            var screen = pyI25.GenerarImagen(barras, pathFilename + ".png");
            //Imagen JPG - Aspecto 3x mas ancho para imprimir o incrustar
            var print = pyI25.GenerarImagen(barras, pathFilename + ".jpg", 9, 0, 90, "JPEG");
        }
    }
}
