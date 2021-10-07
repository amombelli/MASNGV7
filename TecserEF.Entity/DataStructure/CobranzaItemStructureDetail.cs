using System;
using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    public class CobranzaItemStructureDetail
    {
        public int IdCob { get; set; }
        public int IdItem { get; set; }
        public string Cuenta { get; set; }
        public string CuentaDetail { get; set; }
        public string Banco { get; set; }
        public DateTime? FechaAcred { get; set; }
        public string ChequeNum { get; set; }
        public string Moneda { get; set; }
        public decimal Importe { get; set; }
    }

    public class FillCobranzaItemStructureDetaill
    {
        public List<CobranzaItemStructureDetail> FillData(int idCob, string globalAppCnn)
        {
            using (var db = new TecserData(globalAppCnn))
            {
                var query = from cobItem in db.T0206_COBRANZA_I
                            where cobItem.IDCOB == idCob
                            join bancos in db.T0160_BANCOS
                                on new { Id = cobItem.CHEQUE_BANCO } equals
                                new { Id = bancos.ID_BANCO }
                                into list1
                            from l1 in list1.DefaultIfEmpty()
                            join cuentas in db.T0150_CUENTAS on cobItem.CUENTA equals cuentas.ID_CUENTA
                                into list2
                            from l2 in list2.DefaultIfEmpty()
                            select new CobranzaItemStructureDetail()
                            {
                                IdItem = cobItem.LINE,
                                IdCob = cobItem.IDCOB,
                                Banco = l1.BCO_SHORTDESC,
                                ChequeNum = cobItem.CHEQUE_NUMERO,
                                Cuenta = cobItem.CUENTA,
                                CuentaDetail = l2.CUENTA_DESC,
                                FechaAcred = cobItem.CHEQUE_FECHA,
                                Importe = cobItem.IMP_ITEM,
                                Moneda = cobItem.MON_ITEM
                            };
                return query.OrderBy(c => c.IdItem).ToList();
            }
        }
    }
}
