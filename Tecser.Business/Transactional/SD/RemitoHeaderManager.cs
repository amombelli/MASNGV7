using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.SD
{
    public class RemitoHeaderManager
    {
        public int GeneraRemitoHeader(string numeroRemitoTemp, string tipoLX, int clienteT7, bool esL5)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = new T0055_REMITO_H();
                header.IDREMITO = db.T0055_REMITO_H.Max(c => c.IDREMITO) + 1;

                if (esL5 && tipoLX == "L2")
                {
                    var mystring = "X" + header.IDREMITO;
                    header.NUMREMITO = mystring.Substring(Math.Max(0, mystring.Length - 8));
                    header.StatusRemito = RemitoStatusManager.StatusHeader.StandBy.ToString();
                }
                else
                {
                    var mystring = "T" + header.IDREMITO;
                    header.NUMREMITO = mystring.Substring(Math.Max(0, mystring.Length - 8));
                    header.StatusRemito = "EN PREPARACION";
                }

                header.TIPO_REMITO = tipoLX;
                header.FECHA = DateTime.Today;
                header.CODCLIENTREGA = clienteT7;

                header.Impreso = false;
                header.UserLog = Environment.UserName;
                header.FechaLog = DateTime.Today;
                header.FACTPEND = true;

                db.T0055_REMITO_H.Add(header);
                return db.SaveChanges() == 1 ? header.IDREMITO : 0;
            }
        }
        public void UpdateRlink(int idRemito, int rlink)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (h == null)
                    return;
                h.RLINK = rlink;
                db.SaveChanges();

                h = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == rlink);
                if (h == null)
                    return;

                h.RLINK = idRemito;
                db.SaveChanges();

            }
        }
        public void UpdateIdFacturaAsociada(int idRemito, int idFactura, string numeroFactura = null, bool facturaPendiente = true)
        {
            if (idRemito == 0)
                return;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);

                header.Factura = idFactura;
                header.NUMFACTURA = numeroFactura;
                header.FACTPEND = facturaPendiente;
                db.SaveChanges();

            }
        }
        public bool EliminaRemito(int idRemito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var hR = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);
                if (hR.RLINK > 0 && hR.TIPO_REMITO == "L2")
                {
                    return false;
                    //este remito no se puede cancelar.-
                }

                var it = db.T0056_REMITO_I.Where(c => c.IDREMITO == idRemito).ToList();

                foreach (var i in it)
                {
                    var stk = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == i.idStockComprometido.Value);
                    if (stk != null)
                    {
                        //libera el stock reservado
                        stk.ReservaID = null;
                        stk.Despacho = null;
                        stk.Estado = stk.EstadoAnteriorReserva;
                        stk.EstadoAnteriorReserva = null;
                    }
                }

                if (hR.TIPO_REMITO == "L1" && hR.RLINK > 0)
                {
                    var hrlx = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == hR.RLINK);
                    if (hrlx != null)
                    {
                        db.T0055_REMITO_H.Remove(hrlx);
                        //remueve el remito L2 linkeado.-
                    }
                }
                db.T0056_REMITO_I.RemoveRange(it);
                db.T0055_REMITO_H.Remove(hR);
                db.SaveChanges();
                return true;
            }
        }

        public void CancelaRemito()
        {

        }

    }
}
