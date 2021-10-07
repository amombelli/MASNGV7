using System;
using System.Diagnostics;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class FixOrdenPagoModelo2019
    {
        public void FixPdOPSignoErrado()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var z = db.T0203_CTACTE_PROV.Where(c => c.TDOC == "OP" && c.IMPORTE_ARS > 0).ToList();

                foreach (var i in z)
                {
                    Debug.Print($"Se modifico signo {i.TDOC} # {i.NUMDOC} -- importe ORI {i.IMPORTE_ORI}");
                    i.IMPORTE_ARS = i.IMPORTE_ARS * -1;
                    i.IMPORTE_ORI = i.IMPORTE_ORI * -1;
                }
                db.SaveChanges();

                z = db.T0203_CTACTE_PROV.Where(c => c.TDOC == "PD" && c.IMPORTE_ARS > 0).ToList();

                foreach (var i in z)
                {
                    Debug.Print($"Se modifico signo {i.TDOC} # {i.NUMDOC} -- importe ORI {i.IMPORTE_ORI}");
                    i.IMPORTE_ARS = i.IMPORTE_ARS * -1;
                    i.IMPORTE_ORI = i.IMPORTE_ORI * -1;
                }
                db.SaveChanges();
            }
        }

        public void FixAll()
        {
#pragma warning disable CS0168 // The variable 'importeOriginal' is declared but never used
            decimal importeOriginal;
#pragma warning restore CS0168 // The variable 'importeOriginal' is declared but never used
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Fix Importes Nulos e Importe Final OP
                var fechaX = DateTime.Today.AddDays(-500);
                var listaOP = db.T0210_OP_H.Where(c => c.OPFECHA > fechaX).ToList();
                foreach (var ix in listaOP)
                {
                    //if (ix.ImporteValores == null)
                    //    ix.ImporteValores = 0;

                    //if (ix.ImporteRetIIBB == null)
                    //    ix.ImporteRetIIBB = 0;

                    //if (ix.ImporteRetGS == null)
                    //    ix.ImporteRetGS = 0;

                    //if (ix.ImporteRetIVA == null)
                    //    ix.ImporteRetIVA = 0;

                    //if (ix.ImporteCreditos == null)
                    //    ix.ImporteCreditos = 0;

                    //var zimp = new OPImportesManagement(ix.IDOP);
                    //ix.ImporteValores = zimp.GetImporteTotalItemsPago_ExcluidoRetenciones() - zimp.GetImporteCreditos();

                    //importeOriginal = ix.IMP_OP.Value;
                    //ix.IMP_OP = ix.ImporteValores + ix.ImporteRetIIBB + ix.ImporteRetGS;

                    //if (importeOriginal != ix.IMP_OP.Value)
                    //{
                    //    Debug.Print($"Modifica OP{ix.IDOP} - importe original {importeOriginal} a importe nuevo {ix.IMP_OP}");
                    //}
                    //Add Subdiario si esta GENERADO/IMPRESO/FINALIZADO
                    if ((ix.OP_STATUS.ToUpper() == "IMPRESO" || ix.OP_STATUS.ToUpper() == "FINALIZADA" ||
                         ix.OP_STATUS.ToUpper() == "GENERADA"))
                    {
                        if (ix.ImporteRetIIBB > 0)
                        {
                            new SubdiarioCajaManager().WriteToDb("RIB", Convert.ToDateTime(ix.OPFECHA),
                              SubdiarioCajaManager.PC.Proveedor,
                              ix.PROV_ID, "OP", ix.IDOP.ToString(), "Orden Pago #" + ix.PROV_RS,
                              ix.MON_OP, 0, Convert.ToDecimal(ix.ImporteRetIIBB), ix.TIPO,
                              "OPX", ix.NAS.Value, new CuentasManager().GetGL("RIB"));
                            Debug.Print($"Se agrego en Subdiario para OP {ix.IDOP} RIB importe {ix.ImporteRetIIBB}");
                        }

                        if (ix.ImporteRetGS > 0)
                        {
                            new SubdiarioCajaManager().WriteToDb("RGA", Convert.ToDateTime(ix.OPFECHA),
                              SubdiarioCajaManager.PC.Proveedor,
                              ix.PROV_ID, "OP", ix.IDOP.ToString(), "Orden Pago #" + ix.PROV_RS,
                              ix.MON_OP, 0, Convert.ToDecimal(ix.ImporteRetGS), ix.TIPO,
                              "OPX", ix.NAS.Value, new CuentasManager().GetGL("RGA"));
                            Debug.Print($"Se agrego en Subdiario para OP {ix.IDOP} RGA importe {ix.ImporteRetGS}");
                        }
                    }
                    //var dataCtaCte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.TDOC == "OP" && c.NUMDOC == ix.IDOP.ToString());
                    //if (dataCtaCte != null)
                    //{
                    //    dataCtaCte.IMPORTE_ARS = ix.IMP_OP*-1;
                    //}
                    db.SaveChanges();
                }
            }
        }
    }
}
