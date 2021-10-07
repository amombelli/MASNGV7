using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class FixCompletaIdT400EnTablaCheRechazado
    {
        public FixCompletaIdT400EnTablaCheRechazado()
        {

        }
        public void FixIdCtaCteOldRecordChr()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string iString = "2018-12-31";
                DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd", null);
                var record = db.T0156_CHEQUE_RECH.Where(c => c.IdNCT400 == 0 && c.FECHA_RE.Value < oDate).ToList();
                foreach (var x in record)
                {
                    x.IdNCT400 = -1;
                    db.SaveChanges();
                }
            }
        }

        public void FixCompletaChequeRechEntregado()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0156_CHEQUE_RECH.Where(c => c.IdNCT400 > 0 && c.ChequeEntregado == false).ToList();
                foreach (var i in data)
                {
                    var t400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == i.IdNCT400);
                    if (t400 == null)
                        return;

                    var id400 = t400.IDFACTURA;

                    var ctacte = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == t400.IdCtaCte.Value);
                    if (ctacte.SALDOFACTURA == 0)
                    {
                        i.ChequeEntregado = true;
                        i.EntregadoPor = "AMOMBELLI";
                        i.FechaEntregado = i.FECHA_RE.Value;
                        db.SaveChanges();
                    }
                }



                string iString = "2018-12-31";
                DateTime oDate = DateTime.ParseExact(iString, "yyyy-MM-dd", null);
                var record = db.T0156_CHEQUE_RECH.Where(c => c.IdNCT400 == 0 && c.FECHA_RE.Value < oDate).ToList();
                foreach (var x in record)
                {
                    x.IdNCT400 = -1;
                    db.SaveChanges();
                }
            }
        }

        public void AFixCompletaIdT400EnTablaCheRechazado(int idCheque = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var fecha0 = DateTime.Today.AddDays(-500);
                List<T0156_CHEQUE_RECH> z;
                if (idCheque == 0)
                {
                    z = db.T0156_CHEQUE_RECH.Where(c => c.IdNCT400 == 0 && c.LOG_DATE.Value < fecha0).ToList();
                }
                else
                {
                    z = db.T0156_CHEQUE_RECH.Where(c => c.IDCHEQUE == idCheque).ToList();
                }

                foreach (var z0 in z)
                {
                    var znd = db.T0300_NCD_H.SingleOrDefault(c =>
                        c.IdCliente == z0.IDCLIENTE && c.NDOC == z0.NC_NUM);
                    if (znd != null)
                    {
                        z0.IdNCT400 = znd.idFacturaT0400.Value;
                    }
                }
                MessageBox.Show($@"Finalizado! - Resuelto {db.SaveChanges().ToString()} registros");
            }
        }
    }
}
