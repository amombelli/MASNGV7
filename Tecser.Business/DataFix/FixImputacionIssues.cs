using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class FixImputacionIssues
    {
        public void FixIdCtaCteT0208()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t208 = db.T0208_COB_NO_APLICADA.Where(c => c.IDCTACTE == null).ToList();
                if (t208.Count == 0)
                    return;
                var t201 = new T0201_CTACTE();

                foreach (var i in t208)
                {
                    var idx = i.IDRECIBO.ToString();
                    switch (i.TIPODOC)
                    {
                        case "NC":
                            t201 = db.T0201_CTACTE.SingleOrDefault(c => c.DOC_INTERNO == idx && c.TDOC == "NC");
                            //chequea que coincida el cliente y el importe 
                            if (t201?.IDCLI == i.CLIENTE)
                            {
                                if (Math.Abs(t201.SALDOFACTURA) == Math.Abs(i.MONTO.Value))
                                {
                                    i.IDCTACTE = t201.IDCTACTE;
                                    db.SaveChanges();
                                }
                                else
                                {
                                    // coincide el cliente pero no coincide el importe.
                                }
                            }
                            else
                            {
                                //busca por otro metodo
                                t201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDDOC == i.IDRECIBO.Value && c.DOC_INTERNO == i.NRECIBO);
                                if (t201?.IDCLI == i.CLIENTE)
                                {
                                    if (Math.Abs(t201.SALDOFACTURA) == Math.Abs(i.MONTO.Value))
                                    {
                                        i.IDCTACTE = t201.IDCTACTE;
                                        db.SaveChanges();
                                    }
                                }
                            }







                            break;
                        case "COB":
                            t201 = db.T0201_CTACTE.SingleOrDefault(c => c.DOC_INTERNO == idx && c.TDOC == "CO");
                            //chequea que coincida el cliente y el importe 
                            if (t201?.IDCLI == i.CLIENTE)
                            {
                                if (Math.Abs(t201.SALDOFACTURA) == Math.Abs(i.MONTO.Value))
                                {
                                    i.IDCTACTE = t201.IDCTACTE;
                                    db.SaveChanges();
                                }
                                else
                                {
                                    // coincide el cliente pero no coincide el importe.
                                }
                            }
                            else
                            {
                                //busca por otro metodo
                                t201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDDOC == i.IDRECIBO.Value && c.DOC_INTERNO == i.NRECIBO);
                                if (t201?.IDCLI == i.CLIENTE)
                                {
                                    if (Math.Abs(t201.SALDOFACTURA) == Math.Abs(i.MONTO.Value))
                                    {
                                        i.IDCTACTE = t201.IDCTACTE;
                                        db.SaveChanges();
                                    }
                                }
                            }



                            break;
                        case "AJ":
                            break;
                    }
                }
            }
        }

        private void Fix0()
        {

        }
    }
}



