using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    //Nueva extension de Cobranza Manager 
    public class CobranzaManagerExt2 : CobranzaManagerBase
    {
        public CobranzaManagerExt2(int idCobranza) : base(idCobranza)
        {
        }
        public void UpdateCobranzaHeaderNas(int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var cob = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == IdCobranza);
                cob.NASIENTO = numeroAsiento;
                CobH.NASIENTO = numeroAsiento;
                db.SaveChanges();
            }
        }
        public void RegistraCobranzaEnRegister()
        {
            var fantasia = new CustomerManager().GetCustomerBillToData(CobH.IdCliente.Value).cli_fantasia;
            foreach (var i in ItemList)
            {
                var glCuenta = new CuentasManager().GetGL(i.CUENTA);
                if (i.CUENTA != "CHE")
                {
                    i.IDCH = 0;
                    i.CHEQUE_FECHA = null;
                }
                if (CobH.NASIENTO == null)
                    CobH.NASIENTO = 0;

                new RegisterManager().AddRegisterRecord(i.CUENTA, CobH.FECHA, "RC", CobH.NRECIBO, TipoEntidad.Cliente,
                    CobH.IdCliente.Value, "RECIBO - " + fantasia, i.MON_ITEM, i.IMP_ITEM, 0, i.IDCH.Value,
                    CobH.CUENTA, glCuenta, CobH.NASIENTO.Value, "COBI");
            }
        }


        /// <summary>
        /// Alta de Cobranza en T0201
        /// </summary>
        /// <returns></returns>
        public int AddRegistrosUpdateSaldosCteCte()
        {
            //todo: arreglar aca! 
            var numeroCobranza = (3000000 + IdCobranza).ToString(); //No se usa para nada
            var importeOri = CobH.Monto * -1;
            var importeARS = CobH.MON == "ARS" ? importeOri : Math.Round(importeOri * CobH.TC, 2);

            var ctaCte = new CtaCteCustomer(CobH.IdCliente.Value);
            var idCtaCte = ctaCte.AddCtaCteDetalleRecord(TipoDocumentoSistema, CobH.CUENTA,
                CobH.FECHA, CobH.NRECIBO, CobH.NRECIBO, CobH.MON, importeOri, CobH.TC, importeARS,
                importeARS, IdCobranza,CobH.IDCOB);
            ctaCte.UpdateSaldoCtaCteResumen(CobH.CUENTA, importeOri, CobH.MON, CobH.TC);
            return idCtaCte;
        }
        public int SetCobranzaNoImputada(int idctacte)
        {
            return new CobranzaNoImputada().AddSinImputarRecord(idctacte);
            //todo revisar si lo de arriba funciona! sino descomentar lo de abajo y anular arriba! 2021.05.27
            //var ctacte = new CtaCteCustomer(CobH.IdCliente.Value);
            //return ctacte.AddSinImputarRecord(CobH.FECHA, IdCobranza, CobH.MON, CobH.Monto, CobH.CUENTA,
            //    "COB", CobH.NRECIBO, idctacte);
        }
        public decimal CheckMontoImputadoPorRecibo()
        {
            string nRecibo = IdCobranza.ToString().Trim();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0207_SPLITFACTURAS.Where(c => c.NRECIBO == nRecibo).ToList();
                if (data.Count  ==0)
                    return 0;
                return data.Sum(c => c.MontoImputado);
            }
        }
        public bool CancelaCobranza(string motivoCancelacion)
        {
            string tcode = "COBC";
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //atencion en la busqueda de t201 que no queda claro si es contra doc_interno o contra iddoc!
                var t201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDT2 == IdCobranza && c.TDOC == "CO");
                var cob = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == IdCobranza);
                var sinImputar =
                    db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.IDRECIBO == IdCobranza && c.TIPODOC == "COB");

                if (t201 == null)
                    return false;

                if (cob == null)
                    return false;

                if (t201.IMPORTE_ORI != t201.SALDOFACTURA)
                    return false;

                var itemsCob = db.T0206_COBRANZA_I.Where(c => c.IDCOB == IdCobranza).ToList();
                foreach (var i in itemsCob)
                {
                    if (i.CUENTA == "CHE")
                    {
                        var dispo = new ChequesManager().GetIfDisponible(i.IDCH.Value);
                        if (!dispo)
                            return false;
                    }
                }

                //Comienza reversion de datos

                var importeRevertir = t201.IMPORTE_ORI;
                var moneda = t201.MONEDA;
                var tipoLx = t201.TIPO;
                var idCliente = t201.IDCLI;

                var ctaCte = new CtaCteCustomer(idCliente);
                ctaCte.UpdateSaldoCtaCteResumen(tipoLx, importeRevertir * -1, moneda);

                t201.TDOC = "NA";
                t201.IMPORTE_ARS = 0;
                t201.IMPORTE_ORI = 0;
                t201.SALDOFACTURA = 0;
                t201.CK = false.ToString();
                t201.IDT1 = null;
                t201.IDT2 = IdCobranza;


                //db.T0201_CTACTE.Remove(t201);

                cob.DOC_CANCELADO = true;
                cob.ReciboDesc += cob.ReciboDesc + "*" + motivoCancelacion;

                var asientoOri = cob.NASIENTO;
                var asientoCancel = new AsientoGenerico(tcode).ReversaAsiento(asientoOri.Value);

                if (asientoCancel.IdDocu > 0)
                {
                    cob.NASIENTO_C = asientoCancel.IdDocu;
                }

                foreach (var i in itemsCob)
                {
                    var gl = new CuentasManager().GetGL(i.CUENTA);
                    if (i.CUENTA == "CHE")
                    {
                        var ch = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == i.IDCH);
                        if (ch != null)
                            db.T0154_CHEQUES.Remove(ch);
                        new RegisterManager().AddRegisterRecord(i.CUENTA, DateTime.Now, "CAN", IdCobranza.ToString(), TipoEntidad.Cliente, idCliente, motivoCancelacion, i.MON_ITEM, 0, i.IMP_ITEM, i.IDCH.Value, tipoLx, gl, asientoCancel.IdDocu, tcode);
                    }
                    else
                    {
                        new RegisterManager().AddRegisterRecord(i.CUENTA, DateTime.Now, "CAN", IdCobranza.ToString(), TipoEntidad.Cliente, idCliente, motivoCancelacion, i.MON_ITEM, 0, i.IMP_ITEM, 0, tipoLx, gl, asientoCancel.IdDocu, tcode);
                    }
                }

                if (sinImputar != null)
                    db.T0208_COB_NO_APLICADA.Remove(sinImputar);

                db.SaveChanges();
            }
            return true;
        }
    }
}
