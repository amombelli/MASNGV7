using System;
using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    public class MM5Structure
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Material { get; set; }
        public int TMov { get; set; }
        public string TD { get; set; }
        public string Documento { get; set; }
        public decimal Cantidad { get; set; }
        public string Lote { get; set; }
        public string Estado { get; set; }
        public string SLoc { get; set; }
        public string LX { get; set; }
        public string TCode { get; set; }
        public string Comentario { get; set; }
        public string OFProduct { get; set; }
        public string OFStatus { get; set; }
        public string ClienteDesc { get; set; }
        public string Proveedor { get; set; }
        public string LogUser { get; set; }
        public DateTime LogDate { get; set; }
        public string Recurso { get; set; }
    }

    public class MM5Data
    {
        public List<MM5Structure> GetData(DateTime fechaD, DateTime fechaH, string globalAppCnn, int maxRecords = 1000,
            string material = null)
        {
            using (var db = new TecserData(globalAppCnn))
            {
                if (string.IsNullOrEmpty(material))
                {
                    var query = from t40 in db.T0040_MAT_MOVIMIENTOS
                                where t40.FECHAMOV >= fechaD && t40.FECHAMOV <= fechaH
                                join pf in db.T0070_PLANPRODUCCION
                                    on new { Id = t40.DOCUMENTO, tdoc = t40.TIPO_DOCUMENTO } equals
                                    new { Id = pf.IDPLAN.ToString(), tdoc = pf.TDOC }
                                    into list1
                                from l1 in list1.DefaultIfEmpty()
                                join t6 in db.T0006_MCLIENTES on t40.IDCLI equals t6.IDCLIENTE
                                    into list2
                                from l2 in list2.DefaultIfEmpty()
                                join p1 in db.T0005_MPROVEEDORES on t40.IDPRO equals p1.id_prov
                                    into list3
                                from l3 in list3.DefaultIfEmpty()
                                join r1 in db.T0032_RECURSOS on t40.RECURSO equals r1.IdRecurso
                                    into list4
                                from l4 in list4.DefaultIfEmpty()
                                select new MM5Structure()
                                {
                                    Id = t40.IDMOVIMIENTO,
                                    Cantidad = t40.CANTIDAD.Value,
                                    Material = t40.IDMATERIAL,
                                    TMov = t40.TIPOMOVIMIENTO.Value,
                                    TD = t40.TIPO_DOCUMENTO,
                                    Documento = t40.DOCUMENTO,
                                    OFStatus = l1.STATUS,
                                    OFProduct = l1.MATERIAL,
                                    LX = t40.TIPO,
                                    Fecha = t40.FECHAMOV ?? t40.LOG_DATE.Value,
                                    SLoc = t40.SLOC,
                                    ClienteDesc = l2.cli_rsocial,
                                    Proveedor = l3.prov_rsocial,
                                    TCode = t40.TCODE,
                                    LogDate = t40.LOG_DATE.Value,
                                    Estado = t40.BATCHST,
                                    LogUser = t40.LOG_USER,
                                    Lote = t40.BATCH,
                                    Comentario = t40.COMENTARIO,
                                    Recurso = l4.NombreRecurso
                                };
                    return query.OrderByDescending(c => c.Fecha).ThenByDescending(d => d.Id).Take(maxRecords).ToList();
                }
                else
                {
                    var query =
                        from t40 in
                            db.T0040_MAT_MOVIMIENTOS.Where(
                                c =>
                                    c.IDMATERIAL.ToUpper().Equals(material.ToUpper()) && c.FECHAMOV >= fechaD &&
                                    c.FECHAMOV <= fechaH)
                        join pf in db.T0070_PLANPRODUCCION
                            on new { Id = t40.DOCUMENTO, tdoc = t40.TIPO_DOCUMENTO } equals
                            new { Id = pf.IDPLAN.ToString(), tdoc = pf.TDOC }
                            into list1
                        from l1 in list1.DefaultIfEmpty()
                        join t6 in db.T0006_MCLIENTES on t40.IDCLI equals t6.IDCLIENTE
                           into list2
                        from l2 in list2.DefaultIfEmpty()
                        join p1 in db.T0005_MPROVEEDORES on t40.IDPRO equals p1.id_prov
                            into list3
                        from l3 in list3.DefaultIfEmpty()
                        join r1 in db.T0032_RECURSOS on t40.RECURSO equals r1.IdRecurso
                            into list4
                        from l4 in list4.DefaultIfEmpty()
                        select new MM5Structure()
                        {
                            Id = t40.IDMOVIMIENTO,
                            Cantidad = t40.CANTIDAD.Value,
                            Material = t40.IDMATERIAL,
                            TMov = t40.TIPOMOVIMIENTO.Value,
                            TD = t40.TIPO_DOCUMENTO,
                            Documento = t40.DOCUMENTO,
                            OFStatus = l1.STATUS,
                            OFProduct = l1.MATERIAL,
                            LX = t40.TIPO,
                            Fecha = t40.FECHAMOV ?? t40.LOG_DATE.Value,
                            SLoc = t40.SLOC,
                            ClienteDesc = l2.cli_rsocial,
                            Proveedor = l3.prov_rsocial,
                            TCode = t40.TCODE,
                            LogDate = t40.LOG_DATE.Value,
                            Estado = t40.BATCHST,
                            LogUser = t40.LOG_USER,
                            Lote = t40.BATCH,
                            Comentario = t40.COMENTARIO,
                            Recurso = l4.NombreRecurso
                        };
                    return query.OrderByDescending(c => c.Fecha).ThenByDescending(d => d.Id).Take(maxRecords).ToList();
                }
            }
        }


        public List<MM5Structure> GetDataOriginal(DateTime fechaD, DateTime fechaH, string globalAppCnn, int maxRecords = 1000,
    string material = null)
        {
            using (var db = new TecserData(globalAppCnn))
            {
                if (string.IsNullOrEmpty(material))
                {
                    var query = from t40 in db.T0040_MAT_MOVIMIENTOS
                                where t40.FECHAMOV >= fechaD && t40.FECHAMOV <= fechaH
                                join pf in db.T0070_PLANPRODUCCION
                                    on new { Id = t40.DOCUMENTO, tdoc = t40.TIPO_DOCUMENTO } equals
                                    new { Id = pf.IDPLAN.ToString(), tdoc = pf.TDOC }
                                    into list1
                                from l1 in list1.DefaultIfEmpty()
                                join t7 in db.T0007_CLI_ENTREGA on t40.IDCLI equals t7.ID_CLI_ENTREGA
                                    into list2
                                from l2 in list2.DefaultIfEmpty()
                                join p1 in db.T0005_MPROVEEDORES on t40.IDPRO equals p1.id_prov
                                    into list3
                                from l3 in list3.DefaultIfEmpty()
                                join r1 in db.T0032_RECURSOS on t40.RECURSO equals r1.IdRecurso
                                    into list4
                                from l4 in list4.DefaultIfEmpty()
                                select new MM5Structure()
                                {
                                    Id = t40.IDMOVIMIENTO,
                                    Cantidad = t40.CANTIDAD.Value,
                                    Material = t40.IDMATERIAL,
                                    TMov = t40.TIPOMOVIMIENTO.Value,
                                    TD = t40.TIPO_DOCUMENTO,
                                    Documento = t40.DOCUMENTO,
                                    OFStatus = l1.STATUS,
                                    OFProduct = l1.MATERIAL,
                                    LX = t40.TIPO,
                                    Fecha = t40.FECHAMOV ?? t40.LOG_DATE.Value,
                                    SLoc = t40.SLOC,
                                    ClienteDesc = l2.T0006_MCLIENTES.cli_rsocial,
                                    Proveedor = l3.prov_rsocial,
                                    TCode = t40.TCODE,
                                    LogDate = t40.LOG_DATE.Value,
                                    Estado = t40.BATCHST,
                                    LogUser = t40.LOG_USER,
                                    Lote = t40.BATCH,
                                    Comentario = t40.COMENTARIO,
                                    Recurso = l4.NombreRecurso
                                };
                    return query.OrderByDescending(c => c.Fecha).ThenByDescending(d => d.Id).Take(maxRecords).ToList();
                }
                else
                {
                    var query =
                        from t40 in
                            db.T0040_MAT_MOVIMIENTOS.Where(
                                c =>
                                    c.IDMATERIAL.ToUpper().Equals(material.ToUpper()) && c.FECHAMOV >= fechaD &&
                                    c.FECHAMOV <= fechaH)
                        join pf in db.T0070_PLANPRODUCCION
                            on new { Id = t40.DOCUMENTO, tdoc = t40.TIPO_DOCUMENTO } equals
                            new { Id = pf.IDPLAN.ToString(), tdoc = pf.TDOC }
                            into list1
                        from l1 in list1.DefaultIfEmpty()
                        join t7 in db.T0007_CLI_ENTREGA on t40.IDCLI equals t7.ID_CLI_ENTREGA
                            into list2
                        from l2 in list2.DefaultIfEmpty()
                        join p1 in db.T0005_MPROVEEDORES on t40.IDPRO equals p1.id_prov
                            into list3
                        from l3 in list3.DefaultIfEmpty()
                        join r1 in db.T0032_RECURSOS on t40.RECURSO equals r1.IdRecurso
                            into list4
                        from l4 in list4.DefaultIfEmpty()
                        select new MM5Structure()
                        {
                            Id = t40.IDMOVIMIENTO,
                            Cantidad = t40.CANTIDAD.Value,
                            Material = t40.IDMATERIAL,
                            TMov = t40.TIPOMOVIMIENTO.Value,
                            TD = t40.TIPO_DOCUMENTO,
                            Documento = t40.DOCUMENTO,
                            OFStatus = l1.STATUS,
                            OFProduct = l1.MATERIAL,
                            LX = t40.TIPO,
                            Fecha = t40.FECHAMOV ?? t40.LOG_DATE.Value,
                            SLoc = t40.SLOC,
                            ClienteDesc = l2.T0006_MCLIENTES.cli_rsocial,
                            Proveedor = l3.prov_rsocial,
                            TCode = t40.TCODE,
                            LogDate = t40.LOG_DATE.Value,
                            Estado = t40.BATCHST,
                            LogUser = t40.LOG_USER,
                            Lote = t40.BATCH,
                            Comentario = t40.COMENTARIO,
                            Recurso = l4.NombreRecurso
                        };
                    return query.OrderByDescending(c => c.Fecha).ThenByDescending(d => d.Id).Take(maxRecords).ToList();
                }
            }
        }
    }
}


