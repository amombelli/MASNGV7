using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable
{
    public class AsientoCopia
    {

        //todo: borrar en header ZTERM


        /// <summary>
        ///  Crea un asiento de anulacion con un contradocumento invertiendo valores Debe y Haber
        ///  tipoDocumentoXX = "ND"
        /// </summary>
        public AsientoNumeracion.ReturnNumeracion GeneraAsientoInverso(int numeroAsiento, DateTime fechaAsiento, string tipoDocumentoXx,
            string numeroDocumento, string observacionAsiento,string tcode, string prefijoSegText="*")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == numeroAsiento);
                AsientoNumeracion.TipoLx lx;
                if (h.TIPO == "L1")
                {
                    lx = AsientoNumeracion.TipoLx.L1;
                }
                else
                {
                    lx = AsientoNumeracion.TipoLx.L2;
                }

                var rtn = new AsientoNumeracion().GetNextNumeroAsiento(lx, fechaAsiento);
                //Header
                var x = new T0601_DOCU_H()
                {
                    IDDOCU = rtn.IdDocu,
                    FECHA = fechaAsiento,
                    MONE_ORI = h.MONE_ORI,
                    TC = h.TC,
                    MES = fechaAsiento.Month.ToString("D2"),
                    YEAR = fechaAsiento.Year.ToString("D4"),
                    HeaderText = observacionAsiento,
                    DOCUTIPO = tipoDocumentoXx,
                    REFE = numeroDocumento,
                    TIPO = h.TIPO,
                    TOT_ORI = h.TOT_ORI,
                    TOT_ARS = h.TOT_ARS,
                    LOG_USER = GlobalApp.AppUsername,
                    FECHA_HOY = DateTime.Now,
                    ST = "AAA",
                    CK = true,
                    ALINK = numeroAsiento,
                    RE = false,
                    ID = "-",
                    FechaOP = DateTime.Now,
                    StatusCancel = false,
                    NASX1 = rtn.Nasx1,
                    NASX2 = rtn.Nasx2
                };
                db.T0601_DOCU_H.Add(x);
                db.SaveChanges();
                //Items
                //todo: eliminar CUENTA, IMPROTE_ORI, IMPORTE_ARS, CC, 
                var items = db.T0602_DOCU_S.Where(c => c.IDDOCU == numeroAsiento).ToList();
                foreach (var i in items)
                {
                    var s = new T0602_DOCU_S()
                    {
                        IDDOCU = x.IDDOCU,
                        IDSEG = i.IDSEG,
                        MES = x.MES,
                        YEAR = x.YEAR,
                        TC = x.TC,
                        IMPORTE_ORI = i.IMPORTE_ORI,
                        IMPORTE_ARS = i.IMPORTE_ARS,
                        SEGTEXT = prefijoSegText + i.SEGTEXT,
                        SEGTEXT2 = i.SEGTEXT2,
                        DOCUTIPO = tipoDocumentoXx,
                        REFE = numeroDocumento,
                        CLIENTE = i.CLIENTE,
                        PROV = i.PROV,
                        LOG_USER = GlobalApp.AppUsername,
                        FECHA_HOY = DateTime.Now,
                        DEBE = i.HABER,
                        HABER = i.DEBE,
                        GL = i.GL,
                        CK=true,
                        PERIODO = new PeriodoConversion().GetPeriodo(fechaAsiento),
                        TIPO = i.TIPO,
                        TCODE =tcode,
                        GLL3 =i.GLL3,
                        ALINK = numeroAsiento,
                        CLIPROV_DESC = i.CLIPROV_DESC,
                        MATERIAL = i.MATERIAL,
                        NASX1 = rtn.Nasx1,
                        NASX2 = rtn.Nasx2,
                        HORA_OP = DateTime.Now,
                    };
                    s.DC = i.DC == "Debe" ? "Haber" : "Debe";
                    if (i.KGMAT != null)
                    {
                        s.KGMAT = Convert.ToDecimal(i.KGMAT) * 1;
                    }

                    db.T0602_DOCU_S.Add(s);
                    db.SaveChanges();
                }
                return rtn;
            }
        }
    }
}
