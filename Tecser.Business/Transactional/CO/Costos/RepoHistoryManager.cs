using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class RepoHistoryManager
    {
        public int PopulateTable(string material, int topData = 30, bool replaceAll = false)
        {
            //Listado de Compras T0404 - Que no estan en Tabla
            var ListaNo = new List<int>();
            int maximoId = 0;
            int records = 0;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (db.T0039_REPOHISTORY.Any())
                {
                    maximoId = db.T0039_REPOHISTORY.Max(c => c.Id);
                }

                if (replaceAll)
                {
                    var recordDelete = db.T0039_REPOHISTORY.Where(c => c.Material == material).ToList();
                    db.T0039_REPOHISTORY.RemoveRange(recordDelete);
                    db.SaveChanges();
                }
                var fechaX = new DateTime(2020, 08, 01);
                var x1 = from d404 in db.T0404_VENDOR_FACT_I.Where(c => c.ITEM_DESC == material)
                        .OrderByDescending(c => c.T0403_VENDOR_FACT_H.FECHA).Take(topData)
                         join histo in db.T0039_REPOHISTORY
                             on new { X1 = d404.IDINT, X2 = d404.IDIT } equals
                             new { X1 = histo.IdFactura.Value, X2 = histo.IdItem } into t1
                         from histo in t1.DefaultIfEmpty()
                         select new
                         {
                             idA = d404.IDINT,
                             idB = d404.IDIT,
                             idH = histo == null ? -1 : histo.IdFactura.Value
                         };
                foreach (var idF in x1.Where(c => c.idH == -1).ToList())
                {
                    var a = db.T0404_VENDOR_FACT_I.Where(c =>
                        c.IDINT == idF.idA && c.IDIT == idF.idB && c.ITEM_DESC == material);
                    foreach (var x in a)
                    {
                        var t = new T0039_REPOHISTORY()
                        {
                            Material = x.ITEM_DESC,
                            IdFactura = x.IDINT,
                            Moneda = x.MONEDA,
                            FechaFactura = x.T0403_VENDOR_FACT_H.FECHA,
                            Id = ++maximoId,
                            IdItem = x.IDIT,
                            KG = x.CANT ?? 1,
                            VisibleRepo = true,
                            UpdateManual = false,
                            VendorId = x.T0403_VENDOR_FACT_H.IDPROV,
                            VendorRS = x.T0403_VENDOR_FACT_H.PROVRS,
                            PrecioArs = x.PUNIT_ARS.Value,
                            PrecioUsd = x.PUNIT_USD.Value,
                            UpdateUser = null,
                            UpdateFecha = null
                        };
                        db.T0039_REPOHISTORY.Add(t);
                    }
                    db.SaveChanges();
                    records++;
                }
            }
            return records;
        }


        /// <summary>
        /// Alta en T0039_REPOHISTORY al contabilizar
        /// </summary>
        public void AddManualRecord(int idf)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == idf);
                var items = db.T0404_VENDOR_FACT_I.Where(c => c.IDINT == idf).ToList();
                var maximoId = db.T0039_REPOHISTORY.Any() == false ? 0 : db.T0039_REPOHISTORY.Max(c => c.Id);
                foreach (var x in items)
                {
                    var t = new T0039_REPOHISTORY()
                    {
                        Material = x.ITEM_DESC,
                        IdFactura = x.IDINT,
                        Moneda = x.MONEDA,
                        FechaFactura = header.FECHA,
                        Id = ++maximoId,
                        IdItem = x.IDIT,
                        KG = x.CANT ?? 1,
                        VisibleRepo = true,
                        UpdateManual = false,
                        VendorId = header.IDPROV,
                        VendorRS = header.PROVRS,
                        PrecioArs = x.PUNIT_ARS.Value,
                        PrecioUsd = x.PUNIT_USD.Value,
                        UpdateUser = null,
                        UpdateFecha = null
                    };
                    db.T0039_REPOHISTORY.Add(t);
                }
                db.SaveChanges();
            }
        }
        public T0039_REPOHISTORY GetDataLastPurchase(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0039_REPOHISTORY.Where(c => c.Material == material).OrderByDescending(c => c.FechaFactura)
                    .Take(1);
                return r.FirstOrDefault();
            }
        }
        public List<T0039_REPOHISTORY> GetData(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0039_REPOHISTORY.Where(c => c.Material == material).OrderByDescending(c => c.FechaFactura)
                    .ToList();
            }
        }
        public T0404_VENDOR_FACT_I GetRecordConta(int idF, int idI)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0404_VENDOR_FACT_I.SingleOrDefault(c => c.IDINT == idF && c.IDIT == idI);
            }
        }
        public T0403_VENDOR_FACT_H GetRecordContaH(int idF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0403_VENDOR_FACT_H.SingleOrDefault(c => c.IDINT == idF);
            }
        }
        public T0039_REPOHISTORY GetRecordHistoria(int idF, int idI)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0039_REPOHISTORY.SingleOrDefault(c => c.IdFactura == idF && c.IdItem == idI);
            }
        }
        public void RegeneraRecordManual(int idF, int idI)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rh = db.T0039_REPOHISTORY.SingleOrDefault(c => c.IdFactura == idF && c.IdItem == idI);
                if (rh == null)
                    return;
                var material = rh.Material;
                db.T0039_REPOHISTORY.Remove(rh);
                db.SaveChanges();
                PopulateTable(material);
            }
        }
        public void UpdateManualData(int idF, int idI, decimal kgCompra, decimal precioU, decimal precioA)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                bool upd = false;
                var rh = db.T0039_REPOHISTORY.SingleOrDefault(c => c.IdFactura == idF && c.IdItem == idI);
                if (rh.KG != kgCompra)
                {
                    upd = true;
                }

                if (rh.Moneda == @"USD")
                {
                    if (rh.PrecioUsd != precioU)
                    {
                        upd = true;
                    }
                }
                else
                {
                    if (rh.PrecioArs != precioA)
                    {
                        upd = true;
                    }
                }

                rh.KG = kgCompra;
                rh.PrecioArs = precioA;
                rh.PrecioUsd = precioU;
                if (upd)
                {
                    rh.UpdateManual = true;
                    rh.UpdateFecha = DateTime.Now;
                    rh.UpdateUser = GlobalApp.AppUsername;
                }

                db.SaveChanges();
            }
        }
    }
}