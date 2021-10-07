using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class RcStatusManagement
    {
        public enum Status
        {
            Inicial,
            Cancelado,
            Aprobado,
            RCGenerada,
            OCGenerada
        }
        public static Status MapTextToStatus(string status)
        {
            if (String.IsNullOrEmpty(status))
                return Status.Inicial;
            try
            {
                return (Status)Enum.Parse(typeof(Status), status, true);
            }
            catch (Exception)
            {
                return Status.Inicial;
                throw;
            }
        }

        public void SetCancelado(int idRc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == idRc);
                d.StatusRc = Status.Cancelado.ToString();
                d.AproboOC = null;
                d.FechaAproboOC = null;
                db.SaveChanges();
            }
        }

        public void SetRcAprobada(int idRc, string comentarioOC, decimal kgComprar, int? vendorId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == idRc);
                d.StatusRc = Status.Aprobado.ToString();
                d.AproboOC = GlobalApp.AppUsername;
                d.FechaAproboOC = DateTime.Now;
                d.CometarioOC = comentarioOC;
                d.ProveedorElegido = vendorId;
                d.KgRequeridos = kgComprar;
                db.SaveChanges();
            }
        }

        public void AsignarVendor(int idRc, int? vendorId)
        {
            if (idRc == 0)
                return;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == idRc);
                if (vendorId == null)
                {
                    d.ProveedorElegido = null;
                }
                else
                {
                    d.ProveedorElegido = vendorId.Value;
                }
                db.SaveChanges();
            }
        }

        public void SetOCGenerada(int idRc, int numeroOC, int iditemOc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == idRc);
                d.StatusRc = Status.OCGenerada.ToString();
                d.NumeroOC = numeroOC;
                d.ItemOC = iditemOc;
                db.SaveChanges();

            }
        }

    }
}
