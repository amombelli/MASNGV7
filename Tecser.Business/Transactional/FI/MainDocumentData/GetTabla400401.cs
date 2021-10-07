using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public static class GetTabla400401
    {
        public static List<T0400_FACTURA_H> GetListaDocumentos(int idCliente, string tipoLX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0400_FACTURA_H.Where(c => c.Cliente == idCliente).OrderByDescending(c => c.IDFACTURA)
                    .ToList();
                if (tipoLX == null)
                    return x;
                return x.Where(c => c.TIPOFACT == tipoLX).ToList();
            }
        }

        public static T0400_FACTURA_H GetDatosFactura(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
            }
        }

        public static List<T0401_FACTURA_I> GetItemsDocumentoSeleccionado(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0401_FACTURA_I.Where(c => c.IDFactura == idFactura).ToList();
            }
        }
        
        public static T0401_FACTURA_I GetItemSeleccionado(int idFactura, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0401_FACTURA_I.SingleOrDefault(c => c.IDFactura == idFactura && c.IDITEM == idItem);
            }
        }


        public static List<T0300_NCD_H> GetListaDocumentosNCD(int idCliente, string tipoLX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0300_NCD_H.Where(c => c.IdCliente == idCliente).OrderByDescending(c => c.IDH)
                    .ToList();
                if (tipoLX == null)
                    return x;
                return x.Where(c => c.LX == tipoLX).ToList();
            }
        }

        public static T0300_NCD_H GetNCDHeader (int idH)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idH);
            }
        }
    }
}
