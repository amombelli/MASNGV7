using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.MM
{
    public class RcManagement
    {
        public T0068RequisicionCompra GetRequisicion(int idRc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0068RequisicionCompra.SingleOrDefault(c => c.idRc == idRc);
            }
        }
        public List<RcDataStructure> GetRcPendienteOCSinProveedor()
        {
            return GetRcCompleteList().Where(c => c.IdOC == null && c.IdProv == null && c.StatusRc == "Aprobado").ToList();
        }
        public List<RcDataStructure> GetRcPendienteOCConProveedor(int? idProveedor)
        {
            if (idProveedor == null)
                return GetRcCompleteList().Where(c => c.IdOC == null && c.IdProv != null && c.StatusRc == "Aprobado").ToList();
            return GetRcCompleteList().Where(c => c.IdOC == null && c.IdProv == idProveedor.Value && c.StatusRc == "Aprobado").ToList();
        }
        public List<RcDataStructure> GetRcPendienteOCAll()
        {
            return GetRcCompleteList().Where(c => c.IdOC == null && c.StatusRc == "Aprobado").ToList();
        }
        public List<RcDataStructure> GetRcCompleteList()
        {
            var rtn = new List<RcDataStructure>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = from rc in db.T0068RequisicionCompra
                           join oc in db.T0061_OCOMPRA_I on new { A = (int)rc.NumeroOC, B = (int)rc.ItemOC } equals new { A = oc.ORDENCOMPRA, B = oc.IDITEMCOMPRA }
                               into list1
                           from l1 in list1.DefaultIfEmpty()
                           join proveedor in db.T0005_MPROVEEDORES on rc.ProveedorElegido equals proveedor.id_prov
                               into list2
                           from l2 in list2.DefaultIfEmpty()
                           select new RcDataStructure()
                           {
                               IdRc = rc.idRc,
                               Material = rc.Material,
                               FechaRc = rc.FechaRc,
                               StatusRc = rc.StatusRc,
                               KgRC = rc.KgRequeridos,
                               KgAprodados = rc.KgRequeridos,
                               ObservacionItem = rc.ComentarioRc,
                               IdOC = l1.ORDENCOMPRA,
                               FechaOC = l1.T0060_OCOMPRA_H.FECHAOC,
                               StatusOC = l1.T0060_OCOMPRA_H.STATUSOC,
                               KgRecibidos = l1.CANTIDAD_RECIBIDA,
                               IdProv = rc.ProveedorElegido,
                               Proveedor = rc.ProveedorElegido != null ? l2.prov_rsocial : null
                           };
                return data.ToList();
            }
        }
        public int CreateNewRc(string material, decimal? kgConteo, decimal kgRequisicion, string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int idRc = 1;
                if (db.T0068RequisicionCompra.Any())
                {
                    idRc = db.T0068RequisicionCompra.Max(c => c.idRc) + 1;
                }

                var data = new T0068RequisicionCompra
                {
                    idRc = idRc,
                    ComentarioRc = comentario,
                    FechaRc = DateTime.Now,
                    KgRequeridos = kgRequisicion,
                    KgStockRevisado = kgConteo,
                    Material = material,
                    StatusRc = RcStatusManagement.Status.RCGenerada.ToString(),
                    UserRc = GlobalApp.AppUsername,
                };
                db.T0068RequisicionCompra.Add(data);
                if (db.SaveChanges() > 0) return idRc;
                return 0;
            }
        }
    }
}
