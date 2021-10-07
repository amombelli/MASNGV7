using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.MainDocumentData.Customer
{
    //Clase encargada de regenear remitos en forma automatica por refacturacion
    //2020.03.17
    public class ReRemision
    {


        public int GeneraRemitoHeaderFromCopyInvertLx(T0055_REMITO_H header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                header.IDREMITO = db.T0055_REMITO_H.Max(c => c.IDREMITO) + 1;
                header.FechaLog = DateTime.Today;
                header.UserLog = GlobalApp.AppUsername;
                db.T0055_REMITO_H.Add(header);
                if (db.SaveChanges() > 0)
                {
                    var d = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == header.IDREMITO);
                    d.StatusRemito = RemitoStatusManager.StatusHeader.Generado.ToString();
                    db.SaveChanges();
                    return header.IDREMITO;
                };
                return 0;
            }
        }
        public int GeneraRemitoItemsFromCopy(List<T0056_REMITO_I> items, int idRemitoNew)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var maxidRemitoItem = db.T0056_REMITO_I.Max(c => c.IDITEM) + 1;
                var header = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemitoNew);

                foreach (var item in items)
                {
                    item.IDITEM = maxidRemitoItem;
                    item.IDREMITO = idRemitoNew;
                    item.NUMREMITO = header.NUMREMITO;
                    maxidRemitoItem++;
                }
                db.T0056_REMITO_I.AddRange(items);
                return db.SaveChanges();
            }
        }

        public int GeneraRemitoItemsPrintFromCopy(List<T0057_REMITO_I_PRINT> itemsP, int idRemitoNew)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var maxidRemitoItem = db.T0057_REMITO_I_PRINT.Max(c => c.IDITEM) + 1;
                var header = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemitoNew);

                foreach (var item in itemsP)
                {
                    item.IDITEM = maxidRemitoItem;
                    item.IDREMITO = idRemitoNew;
                    item.NUMREMITO = header.NUMREMITO;
                    maxidRemitoItem++;
                }
                db.T0057_REMITO_I_PRINT.AddRange(itemsP);
                return db.SaveChanges();
            }
        }
    }
}
