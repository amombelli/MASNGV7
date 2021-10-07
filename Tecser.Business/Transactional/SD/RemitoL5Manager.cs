using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class RemitoL5Manager
    {
        public void SetRemitoL2L5(int idRemitoL1L5)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r1H = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemitoL1L5);
                if (r1H == null)
                {
                    throw new InvalidOperationException("No Existe el registro * IDREMITO L1.L5");
                }

                var r2H = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == r1H.RLINK);
                if (r2H == null)
                {
                    throw new InvalidOperationException("No Existe el registro * IDREMITO L2.L5 Asociado");
                }
                var r1I = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemitoL1L5).ToList();
                var r2I = db.T0056_REMITO_I.Where(c => c.IDREMITO == r1H.RLINK).ToList();

                db.T0056_REMITO_I.RemoveRange(r2I);
                db.SaveChanges();

                foreach (var i in r1I.Where(c => c.RLINK == r1H.RLINK))
                {
                    AddItemL5(i);
                }
                r2H.StatusRemito = RemitoStatusManager.StatusHeader.Generado.ToString().ToUpper();
                r2H.Impreso = false;
                db.SaveChanges();
            }
        }
        private void AddItemL5(T0056_REMITO_I item)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r2H = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == item.RLINK);
                var ovI =
                    db.T0046_OV_ITEM.SingleOrDefault(c => c.IDOV == item.IDOV.Value && c.IDITEM == item.IDOVITEM.Value);
                var ix = new T0056_REMITO_I()
                {
                    IDREMITO = item.RLINK.Value,
                    GENERAR_REMITO = item.GENERAR_REMITO,
                    IDITEM = item.IDITEM,
                    NUMREMITO = r2H.NUMREMITO,
                    MATERIAL = item.MATERIAL,
                    MATERIALAKA = item.MATERIALAKA,
                    DESC_REMITO = db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA == item.MATERIALAKA).MAT_DESC2,
                    KGINI = 0,
                    KGDESPACHADOS = 0,
                    KGDESPACHADOS_R = item.KGDESPACHADOS_R,
                    STATUSITEM = RemitoStatusManager.StatusItem.Confirmado.ToString(),
                    MONEDA = ovI.MonedaCotiz,
                    PRECIOU = ovI.PRECIO2,
                    PRECIOT = ovI.PRECIO2 * item.KGDESPACHADOS_R,
                    PRECIOU_USD = 0,
                    PRECIOT_USD = 0,
                    PRECIOU_ARS = 0,
                    PRECIOT_ARS = 0,
                    TC_FACTU = item.TC_FACTU,
                    IDOV = item.IDOV,
                    IDOVITEM = item.IDOVITEM,
                    BATCH = item.BATCH,
                    BATCH_REMITO = item.BATCH_REMITO,
                    KG_PENDIENTES = 0,
                    STOCK_COMPRO = false,
                    RLINK = item.IDREMITO,
                    VISIBLE_RE = item.VISIBLE_RE,
                    VISIBLE_FA = item.VISIBLE_FA,
                    IVA21 = false,
                    GL = item.GL,
                    GLV = item.GLV,
                    LX = "L2",
                    L5 = true,
                    idStockComprometido = null,
                    SLOC = null,
                };
                db.T0056_REMITO_I.Add(ix);
                db.SaveChanges();

            }
        }
    }
}
