using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class FixAddFacturaT400InT201
    {
        /// <summary>
        /// Fix para agregar en T201 un registro borrado pero que esta disponible en T400.
        /// </summary>
        public void AddRecordFacturaIn201(int idctacte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t = db.T0400_FACTURA_H.SingleOrDefault(c => c.IdCtaCte == idctacte);
                var x = new T0201_CTACTE()
                {
                    CK = "!",
                    CTACTE = null,
                    IDCTACTE = idctacte,
                    TDOC = t.TIPO_DOC,
                    IDDOC = t.IDFACTURA,
                    DOC_INTERNO = t.IDFACTURAX.ToString(),
                    Fecha = t.FECHA,
                    ZTERM = null,
                    IDCLI = t.Cliente,
                    MONEDA = "ARS",
                    TC = t.TC,
                    IMPORTE_ORI = t.TotalFacturaN,
                    IMPORTE_ARS = t.TotalFacturaN,
                    SALDOFACTURA = t.TotalFacturaN,
                    LogDate = t.FechaLog,
                    LogUsuario = t.UserLog,
                    TIPO = t.TIPOFACT,
                    IDT1 = t.IDFACTURA,
                    IDT2 = t.IDFACTURAX,
                    DiasPImputacion = 0,
                    DiasPAcreditacion = null
                };
                if (t.TIPOFACT == "L1")
                {
                    x.NUMDOC = t.NumeroDoc;
                }
                else
                {
                    x.NUMDOC = t.Remito;
                }

                db.T0201_CTACTE.Add(x);
                db.SaveChanges();

            }
        }

        public void AddCobranzaIn201(int idCOB, int idctacte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var c = db.T0205_COBRANZA_H.SingleOrDefault(cx => cx.IDCOB == idCOB);
                var co = db.T0208_COB_NO_APLICADA.SingleOrDefault(cc => cc.IDRECIBO == idCOB);
                var x = new T0201_CTACTE()
                {
                    CK = "!",
                    CTACTE = null,
                    IDCTACTE = idctacte,
                    TDOC = "CO",
                    IDDOC = idCOB,
                    DOC_INTERNO = c.NRECIBO,
                    Fecha = c.FECHA,
                    ZTERM = null,
                    IDCLI = c.IdCliente.Value,
                    MONEDA = "ARS",
                    TC = c.TC,
                    LogDate = c.LogDate,
                    LogUsuario = c.LogUser,
                    TIPO = c.CUENTA,
                    IDT1 = c.IDCOB,
                    IDT2 = c.IDCOB,
                    DiasPImputacion = 0,
                    DiasPAcreditacion = null,
                    NUMDOC = c.NRECIBO
                };

                if (co == null)
                {
                    x.IMPORTE_ORI = c.Monto * -1;
                    x.IMPORTE_ARS = c.Monto * -1;
                    x.SALDOFACTURA = c.Monto * -1;
                }
                else
                {
                    x.IMPORTE_ORI = c.Monto * -1;
                    x.IMPORTE_ARS = c.Monto * -1;
                    x.SALDOFACTURA = co.MONTO.Value * -1;
                }
                db.T0201_CTACTE.Add(x);
                db.SaveChanges();
            }
        }
    }
}
