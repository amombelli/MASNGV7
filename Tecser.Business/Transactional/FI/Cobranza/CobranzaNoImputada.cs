using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    /// <summary>
    /// Manejo Tabla 208
    /// </summary>
    public class CobranzaNoImputada
    {
        /// <summary>
        /// Alta de Registro SIN Imputar en Tabla T0208
        /// Si se pasa monto sin Imputar = null se toma automaticamente el ABS del SaldoAdeudado (Recomendado)
        /// </summary>
        public int AddSinImputarRecord(int idCtaCteCobOrNc, decimal? montoSinImputar = null)
        {
            //todo: hay que reemplazar en T0201 IDT2 enviar para una NC/ND/AJ el IDH300 en vez de IDFacturaX!
            //
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dCtaCte = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCteCobOrNc);
                if (dCtaCte == null)
                    return -1;

                string tipoDocumentoOrigen = null;
                int idRecibo = 0;
                int? idNCD = null;
                string numeroDoc = null;
                decimal Importe;


                switch (dCtaCte.TDOC)
                {
                    case "CO":
                        tipoDocumentoOrigen = "COB";
                        numeroDoc = dCtaCte.DOC_INTERNO;
                        idNCD = null;
                        idRecibo = dCtaCte.IDT2.Value;
                        break;
                    case "NC":
                    case "CM":
                        tipoDocumentoOrigen = "NCD";
                        var data300 = db.T0300_NCD_H.SingleOrDefault(c => c.idCtaCte == idCtaCteCobOrNc);
                        if (data300 == null)
                            return -1;
                        idRecibo = data300.IDH;
                        idNCD = data300.IDH;
                        numeroDoc = data300.NDOC;
                        break;
                    case "AJ":
                        idRecibo = dCtaCte.IDT2.Value;
                        numeroDoc = dCtaCte.NUMDOC;
                        idNCD = dCtaCte.IDT2.Value;
                        break;
                    default:
                        return -1;
                }

                Importe = montoSinImputar == null ? Math.Abs(dCtaCte.SALDOFACTURA) : montoSinImputar.Value;
                var t208 = new T0208_COB_NO_APLICADA
                {
                    ID = db.T0208_COB_NO_APLICADA.Max(c => c.ID) + 1,
                    CLIENTE = dCtaCte.IDCLI,
                    FECHA = dCtaCte.Fecha,
                    IDRECIBO = idRecibo,
                    IDNCD = idNCD,
                    NRECIBO = numeroDoc,
                    MONEDA = dCtaCte.MONEDA,
                    MONTO = Importe,
                    TIPOCUENTA = dCtaCte.TIPO,
                    TIPODOC = tipoDocumentoOrigen,
                    IDCTACTE = idCtaCteCobOrNc
                };
                db.T0208_COB_NO_APLICADA.Add(t208);
                return db.SaveChanges() > 0 ? t208.ID : 0;
            }
        }
    }
}
