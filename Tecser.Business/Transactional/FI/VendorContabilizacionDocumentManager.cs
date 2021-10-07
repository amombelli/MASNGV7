using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    //Toda la interaccion con el submodulo de facturas de VENDORS
    //Tabla 403/404

    public class VendorContabilizacionDocumentManager
    {
        public int SetDocumentT403_Header(T0403_VENDOR_FACT_H h)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (h.IDINT <= 0)
                {
                    h.IDINT = db.T0403_VENDOR_FACT_H.Max(c => c.IDINT) + 1;
                }

                var provName = db.T0005_MPROVEEDORES.SingleOrDefault(c => c.id_prov == h.IDPROV).prov_rsocial;
                var r = provName.Length;
                if (r > 50)
                    provName = provName.Substring(0, 50);

                if (h.NFACTURA.Length > 13)
                    h.NFACTURA = h.NFACTURA.Substring(0, 13);

                h.IDPROV = h.IDPROV;
                h.PROVRS = provName;
                h.PRTAX1 = db.T0005_MPROVEEDORES.SingleOrDefault(c => c.id_prov == h.IDPROV).NTAX1;
                h.LOGDATE = DateTime.Now;
                h.LOGUSER = Environment.UserName;
                db.T0403_VENDOR_FACT_H.Add(h);
                if (db.SaveChanges() > 0)
                    return h.IDINT;
                return -1;
            }
        }
        public bool SetDocumentT0404_Items(int idInterno, List<T0404_VENDOR_FACT_I> i)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var l = db.T0404_VENDOR_FACT_I.Where(c => c.IDINT == idInterno).ToList();
                if (l.Count > 0)
                {
                    db.T0404_VENDOR_FACT_I.RemoveRange(l);
                    db.SaveChanges();
                }

                foreach (var lista in i)
                {
                    lista.IDINT = idInterno;
                    db.T0404_VENDOR_FACT_I.Add(lista);
                }
                db.SaveChanges();
            }
            return true;
        }
        public void UpdateIdCtaCte_NAS_T403(int idFactura403, int idCtaCte, int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == idFactura403);
                t.IDCTACTE = idCtaCte;
                t.NASIENTO = numeroAsiento;
                db.SaveChanges();
            }
        }


    }
}
