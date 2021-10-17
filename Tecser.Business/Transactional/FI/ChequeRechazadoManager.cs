using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{
    public class SaldoRechazoSinLevantar
    {
        public decimal SaldoChEntregado { get; set; }
        public decimal SaldoChNoEntregado { get; set; }
        public decimal SaldoChSinNotaDebito { get; set; }
    }

    public class ChequeRechazadoManager
    {

        /// <summary>
        /// Actualizacion de Datos de ND en T0156
        /// </summary>
        public bool UpdateAfterContabilizacionNd(int idcheque, int numeroAsiento, int idT400, string numeroND)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t = db.T0156_CHEQUE_RECH.SingleOrDefault(c => c.IDCHEQUE == idcheque);
                if (t == null)
                    return false;
                t.AS_NC = numeroAsiento;
                t.IdNCT400 = idT400;
                t.NC_NUM = numeroND;
                db.SaveChanges();
                return true;
            }
        }

        public void AddChequeRechazado(int idCheque, DateTime fechaRechazo, string motivoRechazo,
            string tipoLxRechazo = null, decimal gastos = 0, decimal ivaGastos = 0, string origenRechazo = "")
        {
            var ch = new ChequesManager().GetCheque(idCheque);

            if (ch.IdClienteRecibido == null)
                new ChequeRechazadoManager().FixIdCliente();
            var c = new T0156_CHEQUE_RECH()
            {
                IMPORTE = ch.IMPORTE.Value,
                BANCO_SN = ch.T0160_BANCOS.BCO_SHORTDESC,
                IDCLIENTE = ch.IdClienteRecibido.Value,
                CLIENTERS = ch.CLIENTE,
                FECHA_CH = ch.CHE_FECHA,
                FECHA_RE = fechaRechazo,
                IDCHEQUE = idCheque,
                LOG_DATE = DateTime.Today,
                LOG_USER = Environment.UserName,
                MOTIVO_RE = motivoRechazo,
                NUMERO = ch.CHE_NUMERO,
                TIPO = tipoLxRechazo == null ? ch.TIPO : tipoLxRechazo,
                AS_NC = null,
                AS_RECH = null,
                NC_NUM = null,
                ChequeEntregado = false,
                EntregadoPor = null,
                FechaEntregado = null,
                IdNCT400 = -1,
                GastosOrigen = gastos,
                IVAGastosOrigen = ivaGastos,
                OrigenRechazo = origenRechazo,
            };
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                db.T0156_CHEQUE_RECH.Add(c);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Solo permite remover si no tiene hecha una nc al cliente
        /// </summary>
        public bool RemoveChequeRechazado(int idCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0156_CHEQUE_RECH.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                if (ch == null) return false;

                if (string.IsNullOrEmpty(ch.NC_NUM))
                    db.T0156_CHEQUE_RECH.Remove(ch);

                return db.SaveChanges() > 0;
            }
        }

        public void FixIdCliente()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaToFix = db.T0156_CHEQUE_RECH.Where(c => c.IDCLIENTE == null).ToList();
                foreach (var item in listaToFix)
                {
                    var clienteName = item.CLIENTERS;
                    var idc = db.T0006_MCLIENTES.Where(c => c.cli_rsocial == clienteName).ToList();
                    if (idc.Count == 1)
                    {
                        item.IDCLIENTE = idc[0].IDCLIENTE;
                    }
                    else
                    {
                        var idf = db.T0006_MCLIENTES.Where(c => c.cli_fantasia == clienteName).ToList();
                        if (idf.Count == 1)
                        {
                            item.IDCLIENTE = idf[0].IDCLIENTE;
                        }
                        else
                        {
                            //no se actualiza porque no hay match con 1
                        }
                    }
                }

                db.SaveChanges();
            }
        }

        public bool SetChequeRechazadoTablaCheque(int idCheque, string motivoRechazo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                if (ch == null)
                    return false;
                ch.CH_RECH = true;
                ch.COMENTARIO = " " + motivoRechazo;
                ch.Acreditado = false;
                ch.StatusCheque = "Rechazado";
                db.SaveChanges();
            }

            return true;
        }

        public List<T0156_CHEQUE_RECH> ListaChequeRechazados(int? idCliente = null, string tipoLx = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<T0156_CHEQUE_RECH> resultado = new List<T0156_CHEQUE_RECH>();
                if (idCliente == null)
                {
                    resultado =
                        db.T0156_CHEQUE_RECH.OrderByDescending(c => c.FECHA_RE).ToList();
                }
                else
                {
                    resultado =
                        db.T0156_CHEQUE_RECH.Where(c => c.IDCLIENTE == idCliente)
                            .OrderByDescending(c => c.FECHA_RE)
                            .ToList();
                }

                if (tipoLx == null)
                    return resultado;
                return resultado.Where(c => c.TIPO == tipoLx).ToList();
            }
        }
        public List<T0156_CHEQUE_RECH> ListaChequeRechazadosSinNd(int? idCliente = null, string tipoLx = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<T0156_CHEQUE_RECH> resultado = new List<T0156_CHEQUE_RECH>();
                if (idCliente == null)
                {
                    resultado =
                        db.T0156_CHEQUE_RECH.Where(c => c.NC_NUM == null).OrderByDescending(c => c.FECHA_RE).ToList();
                }
                else
                {
                    resultado =
                        db.T0156_CHEQUE_RECH.Where(c => c.IDCLIENTE == idCliente && c.NC_NUM == null)
                            .OrderByDescending(c => c.FECHA_RE)
                            .ToList();
                }

                if (tipoLx == null)
                    return resultado;
                return resultado.Where(c => c.TIPO == tipoLx).ToList();
            }
        }
        public void CompleteChrDataAfterContabilizacionNotaDebito(int idcheque, int numeroAsiento, string numeroND)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var chdata = db.T0156_CHEQUE_RECH.SingleOrDefault(c => c.IDCHEQUE == idcheque);
                if (chdata == null)
                    return;
                chdata.AS_NC = numeroAsiento;
                chdata.NC_NUM = numeroND;
                db.SaveChanges();
            }
        }
        public void CompleteNumeroDocumentoCompletoAfterCAE(int idcheque, string numeroDocumento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var chdata = db.T0156_CHEQUE_RECH.SingleOrDefault(c => c.IDCHEQUE == idcheque);
                if (chdata == null)
                    return;
                chdata.NC_NUM = numeroDocumento;
                db.SaveChanges();
            }
        }
        public void CompleteNumeroAsientoRechazo(int idcheque, int numeroAsientoRechazo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0156_CHEQUE_RECH.SingleOrDefault(c => c.IDCHEQUE == idcheque);
                ch.AS_RECH = numeroAsientoRechazo;
                db.SaveChanges();
            }
        }
        public List<int> GetListaChequesRechazadosEnNotaDebito(int idH)
        {
            List<int> lch = new List<int>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var litems = db.T0301_NCD_I.Where(c => c.IDH == idH).ToList();
                foreach (var i in litems)
                {
                    if (i.IDCHE > 0)
                    {
                        lch.Add(i.IDCHE.Value);
                    }
                }
            }

            return lch;
        }
        public T0156_CHEQUE_RECH GetRegistroChequeRech(int idCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0156_CHEQUE_RECH.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                return ch;
            }
        }
        public void SetRechazoEntregado(int idCheque, DateTime fechaEntrega, string entregadoPor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0156_CHEQUE_RECH.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                data.EntregadoPor = entregadoPor;
                data.ChequeEntregado = true;
                data.FechaEntregado = fechaEntrega;
                db.SaveChanges();
            }
        }
        public void UnSetRechazoEntregado(int idCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0156_CHEQUE_RECH.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                data.EntregadoPor = null;
                data.ChequeEntregado = false;
                data.FechaEntregado = null;
                db.SaveChanges();

            }
        }
        public int CantidadChequesSinEntregarCliente(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0156_CHEQUE_RECH.Where(c => c.ChequeEntregado == false && c.IDCLIENTE == idCliente)
                    .ToList();
                return (data.Count);
            }
        }
        public SaldoRechazoSinLevantar SaldoChequeRechazadoSinLevantar(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rtn = new SaldoRechazoSinLevantar
                {
                    SaldoChEntregado = 0,
                    SaldoChNoEntregado = 0,
                    SaldoChSinNotaDebito = 0
                };

                var data = db.T0156_CHEQUE_RECH.Where(c => c.ChequeEntregado == false && c.IDCLIENTE == idCliente)
                    .ToList();
                foreach (var ix in data)
                {
                    if (ix.IdNCT400 == 0)
                    {
                        rtn.SaldoChSinNotaDebito = rtn.SaldoChSinNotaDebito + ix.IMPORTE;
                    }
                    else
                    {
                        var t400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == ix.IdNCT400);
                        if (t400 == null)
                        {
                            rtn.SaldoChSinNotaDebito += ix.IMPORTE;
                        }
                        else
                        {
                            var ctacte = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == t400.IdCtaCte.Value);
                            if (ix.ChequeEntregado)
                            {
                                rtn.SaldoChEntregado += ctacte.SALDOFACTURA;
                            }
                            else
                            {
                                rtn.SaldoChNoEntregado += ctacte.SALDOFACTURA;
                            }
                        }
                    }
                }

                return rtn;
            }
        }

        public int AddChrTracker(int idCheque, string chBanco, decimal chImporte, string origenCheque, string cuentaOrigen,
            string accionCheque, string cuentaDestino, string accionCliente, string motivo, string numeroNd, int numeroAsiento = -1)
        {

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int id1 = 1;
                var x = db.T0158_CHRTRACKER.OrderByDescending(c => c.Id).FirstOrDefault();
                if (x != null)
                {
                    id1 = x.Id + 1;
                }

                string fmt = "00000000";

                var t = new T0158_CHRTRACKER()
                {
                    Id = id1,
                    Origen = origenCheque,
                    Fecha = DateTime.Now,
                    AccionCheque = accionCheque,
                    AccionCliente = accionCliente,
                    AsientoChr = numeroAsiento,
                    ChequeBco = chBanco,
                    ChequeId = idCheque,
                    ChequeImporte = chImporte,
                    DocumentoRef = id1.ToString(fmt),
                    Usuario = GlobalApp.AppUsername,
                    Motivo = motivo,
                    CuentaOrigen = cuentaOrigen,
                    CuentaDestino = cuentaDestino,
                    IDND = null,
                    NDNumero = numeroNd,
                };
                db.T0158_CHRTRACKER.Add(t);
                if (db.SaveChanges() > 0)
                    return id1;
                return -1;
            }
        }


        public void DeleteTracker(int idTracker)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0158_CHRTRACKER.SingleOrDefault(c => c.Id == idTracker);
                db.T0158_CHRTRACKER.Remove(x);
                db.SaveChanges();
            }
        }

        public bool UpdateAsientoTracker(int idTracker, int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0158_CHRTRACKER.SingleOrDefault(c => c.Id == idTracker);
                x.AsientoChr = numeroAsiento;
                return db.SaveChanges() > 0;
            }
        }

        public T0158_CHRTRACKER GetTracker(int idTracker)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0158_CHRTRACKER.SingleOrDefault(c => c.Id == idTracker);
            }
        }

        public List<T0158_CHRTRACKER> GetTrackerList(int? idCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idCheque != null)
                    return db.T0158_CHRTRACKER.Where(c => c.ChequeId == idCheque.Value).OrderByDescending(c => c.Id)
                        .ToList();
                return db.T0158_CHRTRACKER.OrderByDescending(c => c.Id).ToList();
            }
        }
    }
}