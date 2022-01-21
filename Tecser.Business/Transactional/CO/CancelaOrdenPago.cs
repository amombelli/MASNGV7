using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    public class CancelaOrdenPago
    {
        public CancelaOrdenPago(int idOrdenPago)
        {
            _idOP = idOrdenPago;
        }
        private readonly int _idOP;

        public bool Cancela()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var opH = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _idOP);
                if (opH == null)
                    return false;

                var idProveedor = opH.PROV_ID;
                var importeOrdenPago = opH.IMP_OP.Value;
                var numeroAsiento = opH.NAS.Value;


                opH.OP_STATUS = OrdenPagoStatus.StatusOP.Cancelada.ToString();
                db.SaveChanges(); //Cancela Header OP

                var resultadoNewAsiento = new AsientoOrdenPago(_idOP, "OPZ").ReversaAsiento(numeroAsiento);

                var idCtaCte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.TDOC == "OP" && c.NUMDOC == _idOP.ToString());
                var CtaCte = new CtaCteVendor(idProveedor);

                if (idCtaCte.IMPORTE_ARS == null)
                    idCtaCte.IMPORTE_ARS = idCtaCte.IMPORTE_ORI;

                var idCtaCteOPZ = CtaCte.AddCtaCteDetalleRecord("OPZ", idCtaCte.TIPO, DateTime.Today,
                    idCtaCte.NUMDOC,
                    "ASN" + resultadoNewAsiento.IdDocu, opH.MON_OP, idCtaCte.IMPORTE_ORI * -1, opH.TC.Value,
                    (decimal)idCtaCte.SALDOFACTURA * -1, idCtaCte.IMPORTE_ARS * -1);

                var z1 = CtaCte.UpdateSaldoCtaCteResumen(idCtaCte.TIPO, idCtaCte.IMPORTE_ORI * -1);
                var resultado = CtaCte.GetResultadoCtaCte(idCtaCte.TIPO);
                idCtaCte.ZOP = false;
                db.SaveChanges();

                DesimputaFacturas();
                RemuevaFacturasdeRetenciones();
                ReversaItemsPago(resultadoNewAsiento.IdDocu);
            }

            return true;
        }

        private void RemuevaFacturasdeRetenciones()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ret = db.T0405_FACTURAS_RETENCIONES.Where(c => c.NumeroOP == _idOP).ToList();
                db.T0405_FACTURAS_RETENCIONES.RemoveRange(ret);
                db.SaveChanges();
            }
        }

        private void DesimputaFacturas()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var op = db.T0213_OP_FACT.Where(c => c.IDOP == _idOP).ToList();
                foreach (var i in op)
                {
                    var cta = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == i.IdCtaCte);
                    cta.SALDOFACTURA = cta.SALDOFACTURA + i.FACT_IMPUTADO;
                    i.CK_FIN = false;
                }
                db.SaveChanges();
            }
        }

        private void ReversaItemsPago(int nas)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var tipoLx = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _idOP).TIPO;
                var op = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP).ToList();
                foreach (var i in op)
                {
                    if (i.CH_CK)
                    {
                        var ch = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == i.CH_ID.Value);
                        ch.DISPONIBLE = true;
                        ch.OP = null;
                        ch.PROVEEDOR = null;
                        ch.TIPOSAL = null;
                        ch.FECHA_ENTREGADO = null;
                        ch.ASSAL = null;
                        ch.COMENTARIO += "Rev.OP#" + _idOP;
                        db.SaveChanges();
                        new RegisterManager().AddRegisterRecord(i.CUENTA_O, DateTime.Today, "ROP", _idOP.ToString(),
                            TipoEntidad.Proveedor, i.PROVEEDOR.Value, "OP Reversal", i.MON, i.IMPORTE, 0, i.CH_ID.Value,
                            tipoLx, new CuentasManager().GetGL(i.CUENTA_O), nas, "OPX");
                    }
                    else
                    {
                        new RegisterManager().AddRegisterRecord(i.CUENTA_O, DateTime.Today, "ROP", _idOP.ToString(),
                            TipoEntidad.Proveedor, i.PROVEEDOR.Value, "OP Reversal", i.MON, i.IMPORTE, 0, 0,
                            tipoLx, new CuentasManager().GetGL(i.CUENTA_O), nas, "OPX");
                    }
                }
            }
        }
    }
}
