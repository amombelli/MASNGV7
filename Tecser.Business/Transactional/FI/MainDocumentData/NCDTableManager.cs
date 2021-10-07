using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData
{
    public class NcdTableManager
    {
        public List<T0300_NCD_H> GetCompleteNCDList()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0300_NCD_H.OrderByDescending(c => c.IDH);
                return x.ToList();
            }
        }
        public List<T0301_NCD_I> GetItemList(int idh)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0301_NCD_I.Where(c => c.IDH == idh).ToList();
            }
        }
        public int GetIdFacturaFromNcd(int idNcd)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idNcd);
                if (x == null)
                    return 0;

                var idFactura = x.idFacturaT0400;
                return idFactura ?? 0;
            }
        }
        public int GetIdNCDFromIdFactura(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == idFactura);
                if (x == null)
                    return 0;
                return x.IDH;
            }
        }
        public T0300_NCD_H GetNCDHData(int idH)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idH);
            }
        }
        public void RemoveNcdTableData(int idh)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var itemData = db.T0301_NCD_I.Where(c => c.IDH == idh).ToList();
                db.T0301_NCD_I.RemoveRange(itemData);
                db.SaveChanges();
                var h = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idh);
                db.T0300_NCD_H.Remove(h);
                db.SaveChanges();
            }
        }
        public void UpdateDataAfterConta(int idh, string numeroDocumento, int idctacte, decimal idFacturaX, int nas)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idh);
                header.NDOC = numeroDocumento;
                header.idCtaCte = idctacte;
                header.ASIENTO = nas;
                header.idFacturaX = idFacturaX;
                db.SaveChanges();
                var itemList = db.T0301_NCD_I.Where(c => c.IDH == idh).ToList();
                foreach (var i in itemList)
                {
                    i.NDOC = numeroDocumento;
                }
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Funcion que Actualiza en Submodulo NCD el numero del documento generado si es L1 despues del CAE
        /// Parametro de ingreso = IDFactura
        /// </summary>
        public void UpdateOnlyDocumentNumberFromIdFactura(int idFactura, string numeroDocumentoCompleto)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == idFactura);
                header.NDOC = numeroDocumentoCompleto;
                db.SaveChanges();

                var itemList = db.T0301_NCD_I.Where(c => c.IDH == header.IDH).ToList();
                foreach (var i in itemList)
                {
                    i.NDOC = numeroDocumentoCompleto;
                    if (i.ITEM == "CHRECH" && i.IDCHE != null)
                    {
                        //actualizar en T0156
                        new ChequeRechazadoManager().CompleteNumeroDocumentoCompletoAfterCAE(i.IDCHE.Value,
                            numeroDocumentoCompleto);
                    }
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Funcion que Actualiza en Submodulo NCD el numero del documento generado si es L1 despues del CAE
        /// Parametro de ingreso = IDH
        /// </summary>

        public void UpdateOnlyDocumentNumber(int idh, string numeroDocumentoCompleto)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idh);
                header.NDOC = numeroDocumentoCompleto;
                db.SaveChanges();
                var itemList = db.T0301_NCD_I.Where(c => c.IDH == idh).ToList();
                foreach (var i in itemList)
                {
                    i.NDOC = numeroDocumentoCompleto;
                    if (i.ITEM == "CHRECH" && i.IDCHE != null)
                    {
                        //actualizar en T0156
                        new ChequeRechazadoManager().CompleteNumeroDocumentoCompletoAfterCAE(i.IDCHE.Value, numeroDocumentoCompleto);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
