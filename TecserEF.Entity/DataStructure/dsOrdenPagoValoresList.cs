using System;
using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    public class DsOrdenPagoValoresList
    {
        public int IdOP { get; set; }
        public string Cuenta { get; set; }
        public string Moneda { get; set; }
        public decimal Importe { get; set; }
        public string ChNum { get; set; }
        public string BancoShort { get; set; }
        public string BancoId { get; set; }
        public int? chId { get; set; }
        public DateTime? FechaAcred { get; set; }
        public bool EsTransferencia { get; set; }

        public List<DsOrdenPagoValoresList> GetValoresOP(int idOP, string globalConnection)
        {
            using (var db = new TecserData(globalConnection))
            {
                var data = (from h in db.T0212_OP_ITEM
                            where h.IDOP == idOP
                            select new DsOrdenPagoValoresList()
                            {
                                IdOP = idOP,
                                Importe = h.IMPORTE,
                                Moneda = h.MON,
                                Cuenta = h.CUENTA_O,
                                BancoId = h.CH_BCO,
                                ChNum = h.CH_NUM,
                                chId = h.CH_ID,
                                BancoShort = "",
                                FechaAcred = h.ChequeFecha,
                                EsTransferencia = h.CK_FIN != null && h.CK_FIN,
                            }).ToList();

                foreach (var it in data)
                {
                    if (!string.IsNullOrEmpty(it.BancoId))
                    {
                        var dx = db.T0160_BANCOS.SingleOrDefault(c => c.ID_BANCO == it.BancoId);
                        if (dx != null)
                            it.BancoShort = dx.BCO_SHORTDESC;
                    }
                }
                return data.ToList();
            }
        }
    }
}
