using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class FixIdCtaCteT400
    {
        /// <summary>
        /// /Completa el campo IDCTACTE en T0400
        /// </summary>
        public void AddCtaCteIdInT0400()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dateX = DateTime.Today.AddDays(-250);
                var r400 =
                    db.T0400_FACTURA_H.Where((c => c.IdCtaCte == null || c.IdCtaCte == 0))
                        .Where(c => c.FECHA >= dateX).ToList();

                if (r400.Count == 0)
                    return; //no hay registros para actualizar

                foreach (var item in r400)
                {
                    //1.-Busco en T0201 x idFacturaX
                    var r201 = db.T0201_CTACTE.SingleOrDefault(c => c.DOC_INTERNO == item.IDFACTURAX.ToString());
                    if (r201 != null)
                    {
                        if ((r201.IDCLI == item.Cliente) &&
                            (Math.Abs(r201.IMPORTE_ARS) == Math.Abs(item.TotalFacturaN)))
                        {
                            item.IdCtaCte = r201.IDCTACTE;
                            MessageBox.Show(@"Se ha actualizado CtaCte #" + item.IdCtaCte, @"#FixA1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            db.SaveChanges();
                        }
                        else
                        {
                            //IdFacturaX coincide pero cliente e importe NO. -- Error
                            MessageBox.Show(@"Error en datos CtaCte");
                        }
                    }
                    else
                    {
                        //La condicion idFacturaX no se encontro - chequeamos contra IdFactura
                        var r201F = db.T0201_CTACTE.SingleOrDefault(c => c.DOC_INTERNO == item.IDFACTURA.ToString());
                        if (r201F == null)
                        {
                            //Tampoco se encontro condicion con IdFactura
                        }
                        else
                        {
                            //se encontro condicion con IdFactura
                            if ((r201F.IDCLI == item.Cliente) &&
                                (Math.Abs(r201F.IMPORTE_ARS) == Math.Abs(item.TotalFacturaN)))
                            {
                                item.IdCtaCte = r201F.IDCTACTE;
                                MessageBox.Show(@"Se ha actualizado CtaCte #" + item.IdCtaCte, @"#FixA1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                db.SaveChanges();
                            }
                            else
                            {
                                //IdFacturaX coincide pero cliente e importe NO. -- Error
                                MessageBox.Show(@"Error en datos CtaCte");
                            }
                        }
                    }
                }
            }
        }

        public void SetStatusFactura(decimal idFacturaX, DocumentFIStatusManager.StatusHeader status)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURAX == idFacturaX);
                r400.StatusFactura = status.ToString();
                db.SaveChanges();
            }
        }
    }
}
