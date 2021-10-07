using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    public class ChangeCobranzaType
    {
        public ChangeCobranzaType()
        {
        }

#pragma warning disable CS0169 // The field 'ChangeCobranzaType._dataH' is never used
        private T0205_COBRANZA_H _dataH;
#pragma warning restore CS0169 // The field 'ChangeCobranzaType._dataH' is never used
#pragma warning disable CS0169 // The field 'ChangeCobranzaType._idCobranza' is never used
        private int _idCobranza;
#pragma warning restore CS0169 // The field 'ChangeCobranzaType._idCobranza' is never used


        /// <summary>
        /// Main function to Change Cobranza from La to Lb
        /// </summary>
        public bool ChangeCobranza(int idCobranza, string tipoOriginal, string tipoNuevo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Update tipo en CobranzaH
                var cob = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCobranza);
                cob.CUENTA = tipoNuevo;
                var importeCobranza = Convert.ToDecimal(cob.Monto);
                var idCliente = (int)cob.IdCliente;
                string moneda = cob.MON;
                string numeroRecibo = cob.NRECIBO;
                decimal TC = cob.TC;
                //Update tipo en T0201
                var t201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDT2 == idCobranza && c.TDOC == "CO");
                t201.TIPO = tipoNuevo;

                db.SaveChanges();

                if (ChangeSaldoCtaCteFromLaToLb(idCliente, moneda, importeCobranza, tipoOriginal, tipoNuevo, TC))
                {
                    ChangeChequeTypeFromLaToLb(idCobranza, tipoNuevo);
                    new AsientoContableManager().ChangeAsientoCobranzaType(numeroRecibo, tipoNuevo);
                    UpdateCobranzaSinImputarType(idCobranza, tipoNuevo);
                }
            }
            return true;
        }
        private void UpdateCobranzaSinImputarType(int idCobranza, string nuevoTipo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0208_COB_NO_APLICADA.SingleOrDefault(c => c.IDRECIBO == idCobranza);
                if (data != null)
                {
                    data.TIPOCUENTA = nuevoTipo;
                    db.SaveChanges();
                }
            }
        }
        public static bool CheckCobranzaSinImputar(int idCobranza)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0207_SPLITFACTURAS.Where(c => c.NRECIBO == idCobranza.ToString()).ToList();
                if (data.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private bool DesimputaCobranzaFactura(int idCobranza)
        {
            return true;
        }
        public static bool CheckIfAllChequesAreAvailable(int idCobranza)
        {
            bool allChequesAreDisponible = true;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var numeroRecibo = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCobranza).NRECIBO;
                var listaChequesRecibo = db.T0154_CHEQUES.Where(c => c.RECIBON.Equals(numeroRecibo)).ToList();
                foreach (var ch in listaChequesRecibo)
                {
                    if (ch.DISPONIBLE == false)
                    {
                        allChequesAreDisponible = false;
                    }
                }
            }
            return allChequesAreDisponible;
        }
        public bool ChangeChequeTypeFromLaToLb(int idCobranza, string nuevoTipo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var numeroRecibo = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCobranza).NRECIBO;
                var listaChequesRecibo = db.T0154_CHEQUES.Where(c => c.RECIBON.Equals(numeroRecibo)).ToList();
                foreach (var ch in listaChequesRecibo)
                {
                    ch.TIPO = nuevoTipo;
                    ch.COMENTARIO = ch.COMENTARIO + " COB_CHG_TYPE";
                }
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }
        private bool ChangeSaldoCtaCteFromLaToLb(int idCliente, string moneda, decimal importeCobranza,
            string tipoOriginal, string tipoNuevo, decimal exchangeRate)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //var registroL1 = new CustomerCtaCte(idCliente, "L1");
                //var registroL2 = new CustomerCtaCte(idCliente, "L2");


                var cta = new CtaCteCustomer(idCliente);


                if (tipoOriginal == "L1")
                {
                    //L1 > L2
                    cta.UpdateSaldoCtaCteResumen("L1", importeCobranza, "ARS", exchangeRate);
                    cta.UpdateSaldoCtaCteResumen("L2", importeCobranza * -1, "ARS", exchangeRate);
                    //registroL1.UpdateImporteCtaCte(moneda, importeCobranza, exchangeRate);
                    //registroL2.UpdateImporteCtaCte(moneda, importeCobranza*-1, exchangeRate);
                }
                else
                {
                    //L2 > L1
                    cta.UpdateSaldoCtaCteResumen("L2", importeCobranza, "ARS", exchangeRate);
                    cta.UpdateSaldoCtaCteResumen("L1", importeCobranza * -1, "ARS", exchangeRate);
                    //registroL2.UpdateImporteCtaCte(moneda, importeCobranza, exchangeRate);
                    //registroL1.UpdateImporteCtaCte(moneda, importeCobranza*-1, exchangeRate);
                }

                return db.SaveChanges() > 1;
            }
        }





    }
}
