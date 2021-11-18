using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class DocumentFIStatusManager
    {
        public enum StatusHeader
        {
            //1.-Estado Pendiente cuando se graba automaticamente en la Tabla T0400
            //2.-Estado Registrada cuando ya entra al Formulario por primera vez.
            //3.-Al Contabilizar si es L2 >> Estado Aprobada -- Si es L1 pasa a estado PendienteCAE
            //4.-L1 al pedir CAE Aprobado >> Estado Aprobada.

            Pendiente, //solo en memoria
            Registrada, //datos en T400
            Contabilizada, //datos en ctacte
            Aprobada, //datos en ctacte + todo listo para enviar
            Impresa, //este estado eliminar!
            Cancelada,
            PendienteCAE //cae pendiente (solo L1)
        }

        public StatusHeader MapStatusHeaderFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                return StatusHeader.Registrada;

            //Mapeo to fix errores
            if (status.ToUpper().Equals("@@") || status.ToUpper().Equals("@@@"))
                return StatusHeader.Registrada;

            //Mapeo to fix errores porque algunas estan en Mayuscula
            if (status.ToUpper().Equals("APROBADA"))
                return StatusHeader.Aprobada;


            try
            {
                return (StatusHeader)Enum.Parse(typeof(StatusHeader), status, true);
            }
            catch (Exception)
            {
                return StatusHeader.Registrada;
                throw;
            }
        }


        public bool SetStatusPendiente(int idFactura)
        {
            string tipoDocumento = null;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (x != null)
                {
                    tipoDocumento = x.TIPO_DOC;
                    var it = db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura);
                    db.T0401_FACTURA_I.RemoveRange(it);
                    db.T0400_FACTURA_H.Remove(x);
                    db.SaveChanges();
                }

                if (tipoDocumento == "NC" || tipoDocumento == "ND" || tipoDocumento == "AI" || tipoDocumento == "DM" ||
                    tipoDocumento == "CM" || tipoDocumento == "CB" || tipoDocumento == "DB")
                {
                    var ncdData = db.T0300_NCD_H.FirstOrDefault(c => c.idFacturaT0400 == idFactura);

                    ncdData.TEMP = true;
                    var idh = ncdData.IDH;

                    var ncdItems = db.T0301_NCD_I.Where(c => c.IDH == idh).ToList();
                    foreach (var it in ncdItems)
                    {
                        // it. = true;
                    }

                    db.SaveChanges();
                }

                return true;
            }
        }

        public bool SetStatusRegistrado(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (x == null)
                    return false;

                x.StatusFactura = StatusHeader.Registrada.ToString();
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
    }
}