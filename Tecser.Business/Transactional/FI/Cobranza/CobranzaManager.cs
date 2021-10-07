using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    /// <summary>
    /// 2018.04.08 - Manejo del sub-modulo de cobranza (creacion)
    /// Creacion datos tabla 205.206
    /// </summary>
    public class CobranzaManagerBase
    {
        /// <summary>
        /// Cobranza existente
        /// </summary>
        protected CobranzaManagerBase(int idCobranza)
        {
            IdCobranza = idCobranza;
            LoadHeaderData();
            LoadItemsData();
            TipoDocumentoSistema = @"CO";
        }

        /// <summary>
        /// Usado para nueva cobranza
        /// </summary>
        public CobranzaManagerBase(int idCliente, string tipoLx)
        {
            IdCliente = idCliente;
            TipoLx = tipoLx;
        }


        //-----------------------------------------------------------
        protected int IdCliente { get; private set; }
        protected int IdCobranza;
        protected string TipoLx;
        protected T0205_COBRANZA_H CobH;
        protected List<T0206_COBRANZA_I> ItemList = new List<T0206_COBRANZA_I>();
        protected readonly string TipoDocumentoSistema;

        public struct Resultado
        {
            public int IdCobranza { get; set; }
            public int NumeroItems { get; set; }
        }


        //-----------------------------------------------------------
        private void LoadHeaderData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                CobH = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == IdCobranza);
                if (CobH == null)
                    throw new InvalidOperationException("No Existe el registro en T0205*COBRANZA");

                TipoLx = CobH.CUENTA;
                IdCliente = (int)CobH.IdCliente;
            }
        }
        private void LoadItemsData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                ItemList = db.T0206_COBRANZA_I.Where(c => c.IDCOB == IdCobranza).ToList();
            }
        }
        public void SetCobranzaHeader(string numeroReciboInterno, string numeroReciboOficial, string numeroReciboProvisorio, DateTime fechaCobranza, string moneda, decimal importe, decimal exchangeRate, string comentario, int diasPp)
        {
            var c = new T0205_COBRANZA_H()
            {
                //IDCOB setear al grabar.
                IdCliente = IdCliente,
                NRECIBO = numeroReciboInterno,
                CUENTA = TipoLx,
                MON = moneda,
                FECHA = fechaCobranza,
                Monto = importe,
                ReciboDesc = comentario,
                LogUser = GlobalApp.AppUsername,
                LogDate = DateTime.Now,
                CCK = false,
                NRECIPROVI = numeroReciboProvisorio,
                IMPRESO = false,
                TC = exchangeRate,
                DOC_CANCELADO = false,
                DOC_DESIMPUTADO = false,
                NASIENTO_R = null,
                NASIENTO_C = null,
                DIAS_PP = diasPp,
                NASIENTO = null,
                NRECIBOOFI = numeroReciboOficial
            };
            CobH = c;
        }
        public void AddCobranzaItem(string cuenta, string moneda, decimal importeItem, decimal importeItemRecibo, decimal exchangeRateItem, string comentarioItem = null)
        {
            var i = new T0206_COBRANZA_I()
            {
                //IDCOB al guardar
                //LINE al guardar
                NRECIBO = CobH.NRECIBO,
                CUENTA = cuenta,
                MON_ITEM = moneda,
                IMP_ITEM = importeItem,
                TC_ITEM = exchangeRateItem,
                MON_RECIBO = CobH.MON,
                IMP_RECIBO = importeItemRecibo,
                //CHEQUE_NUMERO
                //CHEQUE_BANCO
                //CHEQUE_INTERIOR
                //CHEQUE_TITULAR
                //CHEQUE_CUIT
                //CHEQUE_FECHA
                COMENTARIO = comentarioItem,
                ITEM_IMPUTADO = false,
                ITEM_TEMP = true,
                IDCH = null,
            };
            ItemList.Add(i);
        }
        public void AddCobranzaItemCheque(int idcheque, decimal importeItemRecibo, decimal exchangeRateItem, string comentarioItem = null)
        {
            var chequeData = new ChequesManager().GetCheque(idcheque);
            var i = new T0206_COBRANZA_I()
            {
                //IDCOB al guardar
                //LINE al guardar
                NRECIBO = CobH.NRECIBO,
                CUENTA = "CHE",
                MON_ITEM = chequeData.MONEDA,
                IMP_ITEM = chequeData.IMPORTE.Value,
                TC_ITEM = exchangeRateItem,
                MON_RECIBO = CobH.MON,
                IMP_RECIBO = importeItemRecibo,
                CHEQUE_NUMERO = chequeData.CHE_NUMERO,
                CHEQUE_BANCO = chequeData.CHE_BANCO,
                CHEQUE_INTERIOR = chequeData.CHE_INTERIOR.ToString(),
                CHEQUE_TITULAR = chequeData.CHE_TITULAR,
                CHEQUE_CUIT = chequeData.CHE_CUIT,
                CHEQUE_FECHA = chequeData.CHE_FECHA,
                COMENTARIO = comentarioItem,
                ITEM_IMPUTADO = false,
                ITEM_TEMP = true,
                IDCH = idcheque,
            };
            ItemList.Add(i);
        }
        public bool CheckIfReciboInternoExist(string numeroRecibo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0205_COBRANZA_H.SingleOrDefault(c => c.NRECIBO.ToUpper().Equals(numeroRecibo.ToUpper()));
                return data == null;
            }
        }
        private void SetIdCob(int idCobranza)
        {
            IdCobranza = idCobranza;
            LoadHeaderData();
        }
        public Resultado GrabaCobranza()
        {
            var resultado = new Resultado();

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                CobH.IDCOB = db.T0205_COBRANZA_H.Max(c => c.IDCOB) + 1;
                db.T0205_COBRANZA_H.Add(CobH);
                if (db.SaveChanges() == 0)
                {
                    resultado.IdCobranza = -1;
                    return resultado;
                }
                int numeroItem = 0;
                foreach (var i in ItemList)
                {
                    if (i != null)
                    {

                        if (i.CHEQUE_INTERIOR == true.ToString())
                        {
                            i.CHEQUE_INTERIOR = "YES";
                        }
                        else
                        {
                            i.CHEQUE_INTERIOR = "NO";
                        }

                        numeroItem++;
                        i.IDCOB = CobH.IDCOB;
                        i.LINE = numeroItem;
                        if (string.IsNullOrEmpty(i.COMENTARIO))
                            i.COMENTARIO = "";
                        db.T0206_COBRANZA_I.Add(i);
                        //        db.SaveChanges();
                    }
                }
                if (db.SaveChanges() == numeroItem)
                {
                    resultado.IdCobranza = CobH.IDCOB;
                    resultado.NumeroItems = numeroItem;
                }
                return resultado;
            }
        }
        public List<T0205_COBRANZA_H> GetListCobranzasByCustomerId()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0205_COBRANZA_H.Where(c => c.IdCliente == this.IdCliente).OrderByDescending(c => c.IDCOB).ToList();
            }
        }
        public T0205_COBRANZA_H GetCobranza()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == IdCobranza);
            }
        }
        public decimal CheckMontoImputadoPorRecibo(int idCobranza)
        {
            string nRecibo = idCobranza.ToString().Trim();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0207_SPLITFACTURAS.Where(c => c.NRECIBO == nRecibo).Sum(c => c.MontoImputado);
                if (data == null)
                    return 0;
                return (decimal)data;
            }
        }
        public decimal CheckMontoSinImputarPorRecibo(int idCobranza)
        {
            string nRecibo = idCobranza.ToString().Trim();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0208_COB_NO_APLICADA.Where(c => c.IDRECIBO == idCobranza).Sum(c => c.MONTO);
                if (data == null)
                    return 0;
                return (decimal)data;
            }
        }
        private void DesimputaFacturaCobranza(int idCtaCte, decimal importeDesimputar)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var factura = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                factura.SALDOFACTURA += importeDesimputar;
                db.SaveChanges();
            }
        }
        public void DesimputaCobranza()
        {
            string nRecibo = IdCobranza.ToString().Trim();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var montoImputado = CheckMontoImputadoPorRecibo(IdCobranza);
                if (montoImputado > 0)
                {
                    var lst207 = db.T0207_SPLITFACTURAS.Where(c => c.NRECIBO == nRecibo).ToList();
                    decimal importeDesimputado = 0;
                    foreach (var it in lst207)
                    {
                        DesimputaFacturaCobranza(it.IDCTACTE, it.MontoImputado);
                        importeDesimputado += it.MontoImputado;
                        it.MontoImputado = 0;
                        it.NRECIBO = null;
                        it.PFECHA = null;
                        db.SaveChanges();
                    }

                    string sIdCob = IdCobranza.ToString();
                    var cobi = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == IdCobranza);

                    var desimputaCobranza =
                        db.T0201_CTACTE.SingleOrDefault(c => c.IDT2 == IdCobranza && c.TDOC == "CO");
                    desimputaCobranza.SALDOFACTURA = cobi.Monto * -1;


                    var data208 = db.T0208_COB_NO_APLICADA.FirstOrDefault(c => c.IDRECIBO == IdCobranza);
                    if (data208 != null)
                    {
                        data208.MONTO += montoImputado; //Actualiza registro T208
                    }
                    else
                    {
                        //Toda la cobranza estaba imputada x lo que no habia registro en T0208.-
                        var maxId = db.T0208_COB_NO_APLICADA.Max(c => c.ID);
                        var t208 = new T0208_COB_NO_APLICADA
                        {
                            CLIENTE = cobi.IdCliente,
                            FECHA = cobi.FECHA,
                            ID = maxId + 1,
                            IDRECIBO = IdCobranza,
                            MONEDA = cobi.MON,
                            MONTO = cobi.Monto,
                            TIPOCUENTA = cobi.CUENTA,
                            TIPODOC = "COB",
                            IDCTACTE = desimputaCobranza.IDCTACTE,
                            NRECIBO = cobi.NRECIBO,
                        };
                        db.T0208_COB_NO_APLICADA.Add(t208); //Crea registro T208
                    }
                    db.SaveChanges();
                }
                else
                {
                    //Toda la cobranza esta sin imputar.-
                }
            }
        }

    }
}
