using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    public class CqStockStructure
    {
        public int Idstock { get; set; }
        public string Material { get; set; }
        public string Estado { get; set; }
        public string Lote { get; set; }
        public string SLOC { get; set; }
        public string MaterialType { get; set; }
        public bool SLocDispoProd { get; set; }
        public bool EstadoDispoProd { get; set; }
        public decimal TotalKg { get; set; }
        public int? DocumentoReserva { get; set; }
        public string ClienteReserva { get; set; }
        public string EstadoReserva { get; set; }
        public int? IdOrdenVentaReserva { get; set; }
        public string MaterialOF { get; set; }
        public int? idRemito { get; set; }
    }

    public class CqStockDataManagement
    {
        public List<CqStockStructure> CompletaEstructuraReservaRe(string globalAppCnn)
        {
            using (var db = new TecserData(globalAppCnn))
            {
                var query = from stk in db.T0030_STOCK
                            where stk.Estado == "ReservaRE"
                            join remI in db.T0056_REMITO_I on new { A = stk.ReservaID ?? 0, B = stk.ReservaItem ?? 0 } equals new
                            { A = remI.IDREMITO, B = remI.IDITEM } into lx1
                            from l1 in lx1.DefaultIfEmpty()
                            select new CqStockStructure()
                            {
                                Idstock = stk.IDStock,
                                Material = stk.Material,
                                Estado = stk.Estado,
                                ClienteReserva = l1.T0055_REMITO_H.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                TotalKg = stk.Stock,
                                SLOC = stk.SLOC,
                                idRemito = l1.IDREMITO,
                                IdOrdenVentaReserva = stk.OV_Reserva,
                                Lote = stk.Batch,
                                EstadoReserva = l1.T0055_REMITO_H.StatusRemito
                            };
                //var lista = query.ToList();
                return query.ToList();

            }
        }
        public List<CqStockStructure> CompletaEstructuraStockCompleto(string globalAppCnn, string material = null)
        {
            using (var db = new TecserData(globalAppCnn))
            {
                if (string.IsNullOrEmpty(material))
                {
                    var query = from stk in db.T0030_STOCK
                                join pf in db.T0070_PLANPRODUCCION on stk.ReservaOF equals pf.IDPLAN into list1
                                from l1 in list1.DefaultIfEmpty()
                                join ovh in db.T0045_OV_HEADER on stk.OV_Reserva equals ovh.IDOV into list2
                                from l2 in list2.DefaultIfEmpty()
                                select new CqStockStructure()
                                {
                                    Idstock = stk.IDStock,
                                    Material = stk.Material,
                                    Estado = stk.Estado,
                                    Lote = stk.Batch,
                                    SLOC = stk.SLOC,
                                    TotalKg = stk.Stock,
                                    EstadoReserva = l1.STATUS,
                                    ClienteReserva = l2.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                    DocumentoReserva = stk.ReservaOF == 0 ? null : stk.ReservaOF,
                                    IdOrdenVentaReserva = stk.OV_Reserva == 0 ? null : stk.OV_Reserva,
                                    MaterialType = stk.T0010_MATERIALES.TIPO_MATERIAL,
                                    MaterialOF = l1.MATERIAL,
                                };
                    var lista = query.ToList();
                    return query.ToList();
                }
                else
                {
                    var query = from stk in db.T0030_STOCK
                                where stk.Material == material
                                join pf in db.T0070_PLANPRODUCCION on stk.ReservaOF equals pf.IDPLAN into list1
                                from l1 in list1.DefaultIfEmpty()
                                join ovh in db.T0045_OV_HEADER on stk.OV_Reserva equals ovh.IDOV into list2
                                from l2 in list2.DefaultIfEmpty()
                                select new CqStockStructure()
                                {
                                    Idstock = stk.IDStock,
                                    Material = stk.Material,
                                    Estado = stk.Estado,
                                    Lote = stk.Batch,
                                    SLOC = stk.SLOC,
                                    TotalKg = stk.Stock,
                                    EstadoReserva = l1.STATUS,
                                    ClienteReserva = l2.T0007_CLI_ENTREGA.T0006_MCLIENTES.cli_rsocial,
                                    DocumentoReserva = stk.ReservaOF == 0 ? null : stk.ReservaOF,
                                    IdOrdenVentaReserva = stk.OV_Reserva == 0 ? null : stk.OV_Reserva,
                                    MaterialType = stk.T0010_MATERIALES.TIPO_MATERIAL,
                                    MaterialOF = l1.MATERIAL,
                                };
                    var lista = query.ToList();
                    return query.ToList();
                }
            }
        }
    }
}