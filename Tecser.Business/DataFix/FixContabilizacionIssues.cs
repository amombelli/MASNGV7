using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;


namespace Tecser.Business.DataFix
{
    public class FixContabilizacionIssues
    {

        public List<T0400_FACTURA_H> GetDataSourceFacturasSinIdCtaCte(DateTime fechaDesde)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0400_FACTURA_H.Where(c => c.FECHA >= fechaDesde && (c.IdCtaCte == null || c.IdCtaCte == 0))
                        .ToList();
                return data;
            }
        }
        public void CompletaIdCtaCteTabla400(DateTime dateFrom)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r400 =
                    db.T0400_FACTURA_H.Where(c => c.FECHA >= dateFrom && (c.IdCtaCte == null || c.IdCtaCte == 0))
                        .ToList();

                if (r400.Count == 0)
                {
                    MessageBox.Show(@"Enhorabuena! todos los registros de cuenta corriente estan correctos!",
                        @"Fix Completa IdCtaCte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Existen registros que necesitan completarse la cuenta corriente

                foreach (var item in r400)
                {
                    //1.- DOC_INTERNO vs. IDACTURAX
                    var r201 = db.T0201_CTACTE.SingleOrDefault(c => c.DOC_INTERNO == item.IDFACTURAX.ToString());
                    if (r201 == null)
                    {
                        //2.- DOC_INTERNO vs. IDACTURA
                        r201 = db.T0201_CTACTE.SingleOrDefault(c => c.DOC_INTERNO == item.IDFACTURA.ToString());
                        if (r201 == null)
                        {
                            //NO HAY CORRESPONDENCIA Con ninguna IDFACTURAX o IDFACTURA >> id: " & R400!IDFACTURA    
                        }
                        else
                        {
                            if ((r201.IDCLI == item.Cliente) && (Math.Abs(r201.IMPORTE_ARS) == Math.Abs(item.TotalFacturaN)))
                            {
                                item.IdCtaCte = r201.IDCTACTE; //El registro se corresponde. Actualiza IdctaCte en T0400.
                            }
                            else
                            {
                                //ERROR >>Coincide por IDFACTURA pero no coincide CLIENTE / IDFACTURA
                            }

                        }
                    }
                    else
                    {
                        if ((r201.IDCLI == item.Cliente) && (Math.Abs(r201.IMPORTE_ARS) == Math.Abs(item.TotalFacturaN)))
                        {
                            item.IdCtaCte = r201.IDCTACTE; //El registro se corresponde. Actualiza IdctaCte en T0400.
                        }
                        else
                        {
                            //ERROR >>Coincide por IDFACTURA pero no coincide CLIENTE / IDFACTURA
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        public void AddFacturaT0201FromT0400(int idFactura)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == idFactura);
                if (r400 == null)
                    return;

                if (r400.IdCtaCte > 0)
                    return;









            }
        }
    }
}


//