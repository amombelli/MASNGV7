using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.OrdenPago
{
    public class EstadisticasPagoOP
    {
        /// <summary>
        /// Deterima el prmedio en dias entre la OP y las Factuas Incluidas en la OP.
        /// Si hay una sola factura es la diferencia de dias entre OP y Factura
        /// </summary>

        public int DiasPagoFactura(int idOP, bool saveToTable = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var opH = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == idOP);
                var fechaOP = opH.OPFECHA.Value;
                var opF = db.T0213_OP_FACT.Where(c => c.IDOP == idOP).ToList();
                decimal importeAcum = 0;
                decimal importePonde = 0;
                int resultado = 0;

                foreach (var fact in opF)
                {
                    var dataCtaCte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == fact.IdCtaCte.Value);
                    var fechaFactura = dataCtaCte.Fecha.Value;
                    var ts = fechaOP - fechaFactura;
                    var diasFactura = (int)ts.TotalDays;
                    importeAcum += dataCtaCte.IMPORTE_ARS.Value;
                    importePonde += (diasFactura * dataCtaCte.IMPORTE_ARS.Value);
                }

                if (importeAcum == 0)
                {
                    resultado = 0;
                }
                else
                {
                    resultado = (int)Math.Ceiling(importePonde / importeAcum);
                }

                if (saveToTable)
                {
                    opH.DiasPPFacturas = resultado;
                    db.SaveChanges();
                }
                return resultado;
            }
        }

        /// <summary>
        /// Determina el plazo de los items de pago.
        /// Considera CHEQUES, ARS, USD, SAN, ICBC, GAL, OPCRED
        /// </summary>
        public int DiasPPItemsPagoDesdeFechaOP(int idOP, bool saveToTable = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ip = db.T0212_OP_ITEM.Where(x => x.IDOP == idOP).ToList();
                if (ip.Count == 0)
                    return 99999999;

                var opH = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == idOP);
                var fechaOP = opH.OPFECHA.Value;
                decimal importeAcum = 0;
                decimal importePonde = 0;
                int resultado = 0;

                foreach (var ipi in ip)
                {
                    var diasPago = 0;
                    TimeSpan ts;
                    switch (ipi.CUENTA_O)
                    {
                        case "CHE":

                            ts = (ipi.ChequeFecha.Value - fechaOP);
                            diasPago = (int)Math.Ceiling(ts.TotalDays);
                            if (diasPago < 0)
                                diasPago = 0;

                            importeAcum += ipi.IMPORTE_OP.Value;
                            importePonde += (ipi.IMPORTE_OP.Value * diasPago);
                            break;
                        case "OPCRED":
                            string x = ipi.CH_NUM;
                            var z = x.Substring(3);
                            var numeroOPCred = (Convert.ToInt32(z));
                            var fechaOpCred = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == numeroOPCred).OPFECHA.Value;

                            ts = (fechaOP - fechaOpCred);
                            diasPago = (int)ts.TotalDays;  //aca si tiene sentido que sea negativo

                            importeAcum += ipi.IMPORTE_OP.Value;
                            importePonde += (ipi.IMPORTE_OP.Value * diasPago);
                            break;
                        default:
                            //ahora se contempla que desde cuentas de banco se emitan cheques y echeques
                            if (ipi.ChequeFecha == null)
                            {
                                diasPago = 0;
                            }
                            else
                            {
                                ts = (ipi.ChequeFecha.Value - fechaOP);
                                diasPago = (int)Math.Ceiling(ts.TotalDays);
                                if (diasPago < 0)
                                    diasPago = 0;
                            }
                            importeAcum += ipi.IMPORTE_OP.Value;
                            importePonde += (ipi.IMPORTE_OP.Value * diasPago);
                            break;


                            //case "ARS":
                            //    diasPago = 0;
                            //    importeAcum += ipi.IMPORTE_OP.Value;
                            //    importePonde += (ipi.IMPORTE_OP.Value * diasPago);
                            //    break;
                            //case "SAN":
                            //    diasPago = 0;
                            //    importeAcum += ipi.IMPORTE_OP.Value;
                            //    importePonde += (ipi.IMPORTE_OP.Value * diasPago);
                            //    break;
                            //case "ICBC":
                            //    diasPago = 0;
                            //    importeAcum += ipi.IMPORTE_OP.Value;
                            //    importePonde += (ipi.IMPORTE_OP.Value * diasPago);
                            //    break;
                            //case "GAL":
                            //    diasPago = 0;
                            //    importeAcum += ipi.IMPORTE_OP.Value;
                            //    importePonde += (ipi.IMPORTE_OP.Value * diasPago);
                            //    break;



                    }
                }

                if (importeAcum == 0)
                {
                    resultado = 0;
                }
                else
                {
                    resultado = (int)Math.Ceiling(importePonde / importeAcum);
                }

                if (saveToTable)
                {
                    opH.DiasPPItemsPago = resultado;
                    db.SaveChanges();
                }
                return resultado;
            }
        }

        public int GetDiasPagoFactura(int idOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var opH = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == idOP);
                if (opH.DiasPPFacturas == null)
                    return 9999;
                return opH.DiasPPFacturas.Value;
            }
        }

        public int GetDiasItemsPago(int idOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var opH = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == idOP);
                if (opH.DiasPPItemsPago == null)
                    return 9999;
                return opH.DiasPPItemsPago.Value;
            }
        }

        public int GetDiasPagoFacturaFromIdCtaCte(int idCtaCteOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ctacte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCteOP);
                var numeroOP = ctacte.IDDOC;
                var opH = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == numeroOP.Value);
                if (opH.DiasPPFacturas == null)
                    return 9999;
                return opH.DiasPPFacturas.Value;
            }
        }

        public int GetDiasItemsPagoFromIdCtaCte(int idCtaCteOP)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                var ctacte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCteOP);
                var numeroOP = ctacte.IDDOC;
                var opH = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == numeroOP.Value);
                if (opH.DiasPPItemsPago == null)
                    return 9999;
                return opH.DiasPPItemsPago.Value;
            }
        }

    }
}
