using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public class FasonExternoStatusManager
    {
        public enum Status
        {
            Inicial,
            Generada,
            Enviado,
            RecibidoP,
            Cerrado,
            Cancelada
        };

        public static Status MapStatusItemFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = Status.Inicial.ToString();

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


        public static void SetCancel(int idF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var f = db.T0077_FASONEXT_H.SingleOrDefault(c => c.IDF == idF);
                f.StatusFason = Status.Cancelada.ToString();
                new StockManager().AddNewStock_withLogT40(f.Material, f.LoteE, f.CantidadE,
                    StockStatusManager.EstadoLote.Restringido, "0000", DateTime.Today,
                    MmLog.TipoMovimiento.RecepcionFason, f.RemitoE, "OFE", "LX",
                    comentarioMovimiento: "Cancel Fason");
                db.SaveChanges();
            }
        }

        public static void SetEnviada(int idF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var f = db.T0077_FASONEXT_H.SingleOrDefault(c => c.IDF == idF);
                f.StatusFason = Status.Enviado.ToString();
                db.SaveChanges();
            }
        }

        public void SetRecibidoParcial(int idF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var f = db.T0077_FASONEXT_H.SingleOrDefault(c => c.IDF == idF);
                f.StatusFason = Status.RecibidoP.ToString();
                db.SaveChanges();
            }
        }
        public void SetCerrada(int idF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var f = db.T0077_FASONEXT_H.SingleOrDefault(c => c.IDF == idF);
                f.StatusFason = Status.Cerrado.ToString();
                db.SaveChanges();
            }
        }

        public void SetGenerada(int idF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var f = db.T0077_FASONEXT_H.SingleOrDefault(c => c.IDF == idF);
                f.StatusFason = Status.Generada.ToString();
                db.SaveChanges();
            }
        }

    }
}
