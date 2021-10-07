using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class TransferenciaEntreCuentasManager
    {
        public int SetTransactionHeader(XREGISTER_H h)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (h.IDINT > 0)
                {
                    var data = db.XREGISTER_H.SingleOrDefault(c => c.IDINT == h.IDINT);
                    if (data == null)
                        return 0;
                    else
                    {
                        db.Entry(data).CurrentValues.SetValues(h);
                        if (db.SaveChanges() > 0)
                            return 1;
                        return 0;
                    }
                }
                else
                {
                    h.IDINT = db.XREGISTER_H.Max(c => c.IDINT) + 1;
                    db.XREGISTER_H.Add(h);
                    if (db.SaveChanges() > 0)
                        return h.IDINT;
                    return -1;
                }
            }
        }
        public int UpdateTransactionItems(List<XREGISTER_I> items)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int idReg = items[0].IDINT;
                var data = db.XREGISTER_I.Where(c => c.IDINT == idReg).ToList();
                if (data.Count > 0)
                {
                    db.XREGISTER_I.RemoveRange(data);
                    db.SaveChanges();
                }
                db.XREGISTER_I.AddRange(items);
                return db.SaveChanges();
            }
        }
        public void SetOperacionContabilizada(int idReg, int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.XREGISTER_H.SingleOrDefault(c => c.IDINT == idReg);
                x.CONTABILIZADO = true;
                x.NASIENTO = numeroAsiento;
                db.SaveChanges();

                var items = db.XREGISTER_I.Where(c => c.IDINT == idReg).ToList();
                foreach (var it in items)
                {
                    it.CONTABILIZADO = true;
                }
                db.SaveChanges();
            }
        }
        public string GenerateNumeroOperacion(string lx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string nuevo = null;
                if (lx == "L1")
                {
                    var data = db.XREGISTER_H.Where(c => c.TIPO == "L1").Max(c => c.REFNUM);
                    var i = Convert.ToInt64(data.Substring(5)) + 1;
                    nuevo = "0001-" + i.ToString().PadLeft(8, '0');
                }
                else
                {
                    var data = db.XREGISTER_H.Where(c => c.TIPO == "L2").Max(c => c.REFNUM);
                    var i = Convert.ToInt64(data.Substring(5)) + 1;
                    nuevo = "0002-" + i.ToString().PadLeft(8, '0');
                }
                return nuevo;
            }
        }
        public IList GetListOfItems(int idReg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var query = from i in db.XREGISTER_I
                            join ch in db.T0154_CHEQUES on i.CHID equals ch.IDCHEQUE into joinDeptEmp
                            from ch in joinDeptEmp.DefaultIfEmpty()
                            where i.IDINT == idReg
                            select new
                            {
                                IDITEM = i.IDITEM,
                                CUENTA_O = i.CUENTA_O,
                                CUENTA_D = i.CUENTA_D,
                                CH = i.CH,
                                CHID = i.CHID,
                                CUENTA = i.CUENTA,
                                MONEDA = i.MONEDA,
                                IMPORTE_O = i.IMPORTE_O,
                                IMPORTE_ARS = i.IMPORTE_ARS,
                                CONTABILIZADO = i.CONTABILIZADO,
                                GLO = i.GLO,
                                GLD = i.GLD,
                                IMPORTE_D = i.IMPORTE_D,
                                CHTIPO = ch != null ? ch.TIPO : null,
                                CHEQUE_FECHA = ch != null ? ch.CHE_FECHA : DateTime.Today,
                                CHEQUE_BANCO = ch != null ? ch.T0160_BANCOS.BCO_SHORTDESC : null,
                                CHEQUE_NUMERO = ch != null ? ch.CHE_NUMERO : null
                            };
                return query.ToList();
            }
        }

        public XREGISTER_H GetHeaderTransferencia(int idReg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.XREGISTER_H.SingleOrDefault(c => c.IDINT == idReg);
            }
        }
    }
}
