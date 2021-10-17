using System;
using System.IO;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using WebServicesAFIP;

namespace Tecser.Business.Transactional.FI
{
    public class AfipQrCodeManager
    {
        public string DocumentoQr { get; private set; }

        public string GeneraCodigoQrFacturas(int idFactura, bool regenerarQr = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                TipoComprobante tipoC;
                string tipoAf;

                switch (d.TIPO_DOC)
                {
                    case "FA":
                        tipoC = TipoComprobante.Factura;
                        tipoAf = "001";
                        break;
                    case "ND":
                        tipoC = TipoComprobante.NotaDebito;
                        tipoAf = "002";
                        break;
                    case "NC":
                        tipoC = TipoComprobante.NotaCredito;
                        tipoAf = "003";
                        break;
                    default:
                        tipoC = TipoComprobante.NoDefinido;
                        tipoAf = "000";
                        return null;
                }

                var path = AppDomain.CurrentDomain.BaseDirectory + @"QR\";
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                var fileName = d.PV_AFIP.PadLeft(4, '0') + "- " + d.ND_AFIP.PadLeft(8, '0') + ".jpg";
                DocumentoQr = path + fileName;
                if (regenerarQr == false)
                {
                    if (!File.Exists(path + fileName))
                    {
                        return GeneraCodigoQR(d.FECHA.ToString("yyyy-MM-dd"), 30709669091, Convert.ToInt32(d.PV_AFIP), Convert.ToInt32(d.ND_AFIP), Convert.ToInt32(tipoAf), Convert.ToInt64(d.CAE), Convert.ToInt64(d.TotalFacturaB), "PES", (float)1.000, 80, Convert.ToInt64(d.CUIT));
                    }
                }
                else
                {
                    return GeneraCodigoQR(d.FECHA.ToString("yyyy-MM-dd"), 30709669091, Convert.ToInt32(d.PV_AFIP), Convert.ToInt32(d.ND_AFIP), Convert.ToInt32(tipoAf), Convert.ToInt64(d.CAE), Convert.ToInt64(d.TotalFacturaB), "PES", (float)1.000, 80, Convert.ToInt64(d.CUIT));
                }
            }
            return null;
        }

        public string GetCompleteFilename()
        {
            return DocumentoQr;
        }

        private string GeneraCodigoQR(string fecha, long cuit, int ptoVta, int nroCmp, int tipoCmp, long codAut, float importe, string moneda, float ctz, int tipo_doc_rec, long nro_doc_rec)
        {
            dynamic qr = Activator.CreateInstance(Type.GetTypeFromProgID("PyQR"));
            qr.Extension = "JPEG";  //Establecer tipo de imagen (PNG o JPEG):
            qr.archivo = DocumentoQr;
            string tipo_cod_aut = "E";
            object ver = 1;  //? 

            //fecha = "2020-10-13"
            //cuit = 30000000007#
            //pto_vta = 10
            //tipo_cmp = 1
            //nro_cmp = 94
            //importe = 12100
            //moneda = "DOL"
            //ctz = 65#
            //tipo_doc_rec = 80
            //nro_doc_rec = 20000000001#
            //tipo_cod_aut = "E"
            //cod_aut = 70417054367476#
            return qr.GenerarImagen(ver, fecha, cuit, ptoVta, tipoCmp, nroCmp, importe, moneda, ctz, tipo_doc_rec,
                nro_doc_rec, tipo_cod_aut, codAut);
        }
    }

}
