using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.FI
{
    //Clase utilizada para estadisticas del cheque al ingreso de una cobranza
    public class ChequesStats
    {
        public int TotalRecibidos { get; set; }
        public int TotalRechazados { get; set; }
        public int PendientesAcreditar { get; set; }
    }

    public class ChequesManager
    {

        /// <summary>
        /// Graba Cheque - Constructor Completo 
        /// </summary>
        public int AddNewCheque(string tipoLx, string numeroReciboIngreso, DateTime fechaRecibido,
            int idCliente, DateTime fechaAcreditacion, decimal importe, string numero, string numeroBanco,
            bool interior, string numeroCuit, string titular = null, string moneda = "ARS", string observacion = null,
            int idCobranza = 0, int idClienteRecibido = 0, string codigoPostal = null, bool eCheque = false, string echequeBco = null)
        {
            var ch = new T0154_CHEQUES()
            {
                IDCHEQUE = 0, //se asigna al grabar
                MONEDA = moneda,
                IMPORTE = importe,
                CHE_NUMERO = numero,
                CHE_BANCO = numeroBanco,
                CHE_INTERIOR = interior,
                CHE_FECHA = fechaAcreditacion,
                CHE_CUIT = numeroCuit,
                CHE_TITULAR = titular,
                CLIENTE = new CustomerManager().GetCustomerBillToData(idCliente).cli_fantasia,
                FECHA_RECIBIDO = fechaRecibido,
                FECHA_ENTREGADO = null,
                RECIBON = numeroReciboIngreso,
                PROVEEDOR = null,
                DISPONIBLE = true,
                OP = null,
                TIPO = tipoLx,
                TIPO_REC = tipoLx,
                OP_GN = null,
                CH_RECH = false,
                CH_IDR = null,
                CALIFICACION = null,
                COMENTARIO = observacion,
                ASENT = null,
                ASSAL = null,
                TIPOSAL = null,
                IdProveedorSalida = null,
                IdCobranza = idCobranza,
                CuentaTx = null,
                IdClienteRecibido = idClienteRecibido,
                CodigoPostal = codigoPostal,
                StatusCheque = "Pendiente",
                Acreditado = false,
                Echeque = eCheque,
                EchequeBancoGL = echequeBco
            };
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                ch.IDCHEQUE = db.T0154_CHEQUES.Max(c => c.IDCHEQUE) + 1;
                db.T0154_CHEQUES.Add(ch);
                if (db.SaveChanges() > 0)
                    return ch.IDCHEQUE;
                return 0;
            }
        }



        /// <summary>
        /// Funcion para listar cheques recibidos de clientes
        /// Para 'rechazo directo', 'devolucion' etc sin haber sido entregado a proveedor/despositado
        /// </summary>
        public List<T0154_CHEQUES> GetListaChequesRecibidosCliente(int idCliente, int diasDesdeAcreditacion = 180, bool disponible = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                diasDesdeAcreditacion *= -1;
                var fa = DateTime.Today.AddDays(diasDesdeAcreditacion);
                var ch = db.T0154_CHEQUES.Where(c => c.IdClienteRecibido == idCliente && c.CHE_FECHA > fa).OrderByDescending(c => c.CHE_FECHA).ToList();
                if (disponible)
                    return ch.Where(c => c.DISPONIBLE).ToList();
                return ch;
            }
        }

        public List<T0154_CHEQUES> GetListaChequesNoDisponiblesEnEntidadFinanciera()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0154_CHEQUES.Where(c => c.DISPONIBLE == false && c.OP.StartsWith("REG"))
                    .OrderByDescending(c => c.CHE_FECHA).ToList();
            }

        }

        public List<T0154_CHEQUES> GetListChequesNoDisponibles(string idCuenta = null, string soloTipo = null,
            int diasDesdeAcreditacion = 180)
        {
            diasDesdeAcreditacion *= -1;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (string.IsNullOrEmpty(idCuenta))
                {
                    if (string.IsNullOrEmpty(soloTipo))
                    {
                        var fa = DateTime.Today.AddDays(diasDesdeAcreditacion);
                        return
                            db.T0154_CHEQUES.Where(
                                    c =>
                                        c.DISPONIBLE == false &&
                                        c.CHE_FECHA > fa)
                                .OrderByDescending(c => c.CHE_FECHA)
                                .ToList();
                    }
                    else
                    {
                        if (soloTipo == "L1")
                        {
                            return
                                db.T0154_CHEQUES.Where(
                                        c =>
                                            c.DISPONIBLE == false && c.TIPOSAL == "L1" &&
                                            c.CHE_FECHA > DateTime.Today.AddDays(diasDesdeAcreditacion))
                                    .OrderByDescending(c => c.CHE_FECHA)
                                    .ToList();
                        }
                        else
                        {
                            return
                                db.T0154_CHEQUES.Where(
                                        c =>
                                            c.DISPONIBLE == false && c.TIPOSAL == "L2" &&
                                            c.CHE_FECHA > DateTime.Today.AddDays(diasDesdeAcreditacion))
                                    .OrderByDescending(c => c.CHE_FECHA)
                                    .ToList();
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(soloTipo))
                    {
                        var fa = DateTime.Today.AddDays(diasDesdeAcreditacion);
                        return
                            db.T0154_CHEQUES.Where(
                                    c =>
                                        c.PROVEEDOR == idCuenta &&
                                        c.DISPONIBLE == false &&
                                        c.CHE_FECHA > fa)
                                .OrderByDescending(c => c.CHE_FECHA)
                                .ToList();
                    }
                    else
                    {
                        if (soloTipo == "L1")
                        {
                            return
                                db.T0154_CHEQUES.Where(
                                        c =>
                                            c.PROVEEDOR == idCuenta &&
                                            c.DISPONIBLE == false && c.TIPOSAL == "L1" &&
                                            c.CHE_FECHA > DateTime.Today.AddDays(diasDesdeAcreditacion))
                                    .OrderByDescending(c => c.CHE_FECHA)
                                    .ToList();
                        }
                        else
                        {
                            return
                                db.T0154_CHEQUES.Where(
                                        c =>
                                            c.PROVEEDOR == idCuenta &&
                                            c.DISPONIBLE == false && c.TIPOSAL == "L2" &&
                                            c.CHE_FECHA > DateTime.Today.AddDays(diasDesdeAcreditacion))
                                    .OrderByDescending(c => c.CHE_FECHA)
                                    .ToList();
                        }
                    }
                }
            }
        }

        public List<T0154_CHEQUES> GetListChequesDisponibles(bool soloTipoSeleccionado = false,
            string tipoLxSeleccionado = "L1")
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloTipoSeleccionado)
                {
                    return
                        db.T0154_CHEQUES.Where(
                                c => c.DISPONIBLE == true &&
                                     c.TIPO.ToUpper().Equals(tipoLxSeleccionado.ToUpper()))
                            .OrderBy(c => c.CHE_FECHA)
                            .ToList();
                }
                else
                {
                    return db.T0154_CHEQUES.Where(c => c.DISPONIBLE == true).OrderBy(c => c.CHE_FECHA).ToList();
                }
            }
        }

        /// <summary>
        /// Devuelve si el cheque esta disponible
        /// </summary>
        public bool GetIfDisponible(int idCheque)
        {
            var data = new TecserData(GlobalApp.CnnApp).T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
            return data != null && data.DISPONIBLE;
        }

        public T0154_CHEQUES GetCheque(int idCheque)
        {
            return
                new TecserData(GlobalApp.CnnApp).T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
        }

        /// <summary>
        /// Maneja los filtros del frm de busqueda de cheques
        /// </summary>
        public List<TsChequesRechazados> GetListaChequesRechazados(bool soloNoEntregados = false, int diasMax = 500)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                DateTime fechaExec = DateTime.Today.AddDays(diasMax * -1);
                var result0 = from chr in db.T0156_CHEQUE_RECH
                              where chr.LOG_DATE.Value > fechaExec
                              //where chr.IdNCT400 !=0
                              join che in db.T0154_CHEQUES on new { Id = chr.IDCHEQUE } equals
                                  new { Id = che.IDCHEQUE }
                                  into list1

                              from l1 in list1.DefaultIfEmpty()
                              join t400 in db.T0400_FACTURA_H on chr.IdNCT400 equals t400.IDFACTURA
                                  into list2
                              from l2 in list2.DefaultIfEmpty()
                              join tcta201 in db.T0201_CTACTE on l2.IdCtaCte equals tcta201.IDCTACTE
                                  into list3
                              from l3 in list3.DefaultIfEmpty()
                              select new TsChequesRechazados()
                              {
                                  TipoLx = l1.TIPO,
                                  BancoShort = l1.T0160_BANCOS.BCO_SHORTDESC,
                                  ClienteRs = l1.CLIENTE,
                                  FechaAcreditacion = l1.CHE_FECHA,
                                  FechaRechazo = chr.FECHA_RE.Value,
                                  Idcheque = chr.IDCHEQUE,
                                  Numero = chr.NUMERO,
                                  Importe = chr.IMPORTE,
                                  MotivoRechazo = chr.MOTIVO_RE,
                                  NumeroNd = chr.NC_NUM,
                                  IdT400 = chr.IdNCT400,
                                  IdCtaCte = l3.IDCTACTE,
                                  SaldoNd = l3.SALDOFACTURA,
                                  Entregado = chr.ChequeEntregado,
                                  EntregadoPor = chr.EntregadoPor,
                                  FechaEntregado = chr.FechaEntregado
                              };
                var lresult0 = result0.OrderByDescending(c => c.FechaRechazo).ToList();

                if (soloNoEntregados)
                    return lresult0.Where(c => c.Entregado == false).ToList();
                return lresult0.ToList();

            }



        }

        /// <summary>
        /// Pasa el cheque a no disponible utilizado en una Orden de Pago
        /// </summary>
        public bool UtilizaChequeEnOrdenPago(int idcheque, int numeroOP, int numeroAsiento = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idcheque);
                if (data == null)
                    return false;

                var opData = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == numeroOP);
                if (opData == null)
                    return false;

                data.DISPONIBLE = false;
                data.FECHA_ENTREGADO = opData.OPFECHA;
                data.OP = "OP@" + numeroOP;
                data.TIPOSAL = opData.TIPO;
                data.PROVEEDOR = opData.PROV_ID.ToString();
                data.IdProveedorSalida = opData.PROV_ID;
                if (numeroAsiento != 0)
                    data.ASSAL = numeroAsiento;
                return db.SaveChanges() > 0;
            }
        }

        public bool SetNoDisponible_OP(int idcheque, int numeroOP, int numeroAsiento = 0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idcheque);
                if (data == null) return false;

                var opHeader = db.T0210_OrdenPagoHeader.SingleOrDefault(c => c.IdOP == numeroOP);
                if (opHeader == null) return false;
                //
                data.DISPONIBLE = false;
                data.FECHA_ENTREGADO = opHeader.Fecha;
                data.OP = "OP@" + numeroOP;
                data.TIPOSAL = opHeader.Lx;
                data.PROVEEDOR = opHeader.T0005_MPROVEEDORES.prov_rsocial;
                data.IdProveedorSalida = opHeader.IdProveedor;
                if (numeroAsiento != 0)
                    data.ASSAL = numeroAsiento;
                return db.SaveChanges() > 0;
                //
            }
        }


        public void UpdateNumeroAsientoSalidaCheque(int idCheque, int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                if (data == null)
                    throw new InvalidOperationException("No Existe el registro en T0154");
                data.ASSAL = numeroAsiento;
                db.SaveChanges();
            }
        }

        /// <returns></returns>
        public bool LiberaCheque(int idCheque, bool esReingreso = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                if (data == null)
                    throw new InvalidOperationException("No Existe el registro en T0154");

                data.DISPONIBLE = true;
                data.FECHA_ENTREGADO = null;
                data.OP = null;
                data.TIPOSAL = null;
                data.PROVEEDOR = null;
                data.IdProveedorSalida = null;
                data.ASSAL = null;
                data.Acreditado = false;
                if (esReingreso)
                {
                    if (string.IsNullOrEmpty(data.COMENTARIO))
                    {
                        data.COMENTARIO = "REING. " + data.OP + " " + DateTime.Today;
                    }
                    else
                    {
                        data.COMENTARIO = data.COMENTARIO + "@REING. " + data.OP + " " + DateTime.Today;
                    }
                }
                return db.SaveChanges() > 0;
            }
        }

        public bool UtilizaChequeEnReg(int idCheque, int idReg, int numeroAsiento)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                var reg = db.XREGISTER_H.SingleOrDefault(c => c.IDINT == idReg);

                ch.DISPONIBLE = false;
                ch.PROVEEDOR = reg.CUENTAD;
                ch.FECHA_ENTREGADO = reg.FECHA.Value;
                ch.OP = "REG@" + idReg.ToString();
                ch.ASSAL = numeroAsiento;
                ch.TIPOSAL = reg.TIPO;

                return db.SaveChanges() > 0;
            }
        }

        public List<T0154_CHEQUES> GetListaChequesEntregadosAProveedor(int idVendor, string tipoLx = null,
            bool soloNoRechazados = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloNoRechazados)
                {
                    if (tipoLx == null)
                        return
                            db.T0154_CHEQUES.Where(c => c.IdProveedorSalida == idVendor && c.CH_RECH == false)
                                .OrderByDescending(c => c.FECHA_ENTREGADO)
                                .ToList();
                    return
                        db.T0154_CHEQUES.Where(
                                c => c.IdProveedorSalida == idVendor && c.TIPO == tipoLx && c.CH_RECH == false)
                            .OrderByDescending(c => c.FECHA_ENTREGADO)
                            .ToList();
                }
                else
                {
                    if (tipoLx == null)
                        return
                            db.T0154_CHEQUES.Where(c => c.IdProveedorSalida == idVendor)
                                .OrderByDescending(c => c.FECHA_ENTREGADO)
                                .ToList();
                    return db.T0154_CHEQUES.Where(c => c.IdProveedorSalida == idVendor && c.TIPO == tipoLx)
                        .OrderByDescending(c => c.FECHA_ENTREGADO)
                        .ToList();
                }
            }
        }

        public List<T0154_CHEQUES> GetListaChequesPorCUIT(string numeroCuitFirmante, bool disponible = true,
            bool nodisponible = true, bool rechazado = true, bool noRechazado = true)
        {
            var lch = new List<T0154_CHEQUES>();
            //Indicador Seleccion Disponible
            //0 = nada
            //1=  solo disponible
            //2 = solo no disponible
            //3 = todos
            var seleccionDisponible = 0;
            if (disponible)
                seleccionDisponible = 1;

            if (nodisponible)
                seleccionDisponible = seleccionDisponible + 2;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ltemp = new List<T0154_CHEQUES>();
                switch (seleccionDisponible)
                {
                    case 1:
                        //Solo disponible
                        ltemp =
                            db.T0154_CHEQUES.Where(c => c.CHE_CUIT == numeroCuitFirmante && c.DISPONIBLE)
                                .ToList();
                        break;
                    case 2:
                        //Solo no disponible
                        ltemp =
                            db.T0154_CHEQUES.Where(c => c.CHE_CUIT == numeroCuitFirmante && c.DISPONIBLE == false)
                                .ToList();
                        break;
                    case 3:
                        //Disponible y No Disponible
                        ltemp = db.T0154_CHEQUES.Where(c => c.CHE_CUIT == numeroCuitFirmante).ToList();
                        break;
                    default:
                        break;
                }


                //Indicador Seleccion Rechazo-NoRechazo
                //0 = Todos
                //1= Solo Sin Rechazo
                //2= Solo Rechazado
                //3= Todos

                var seleccionRechazo = 0;
                if (noRechazado)
                    seleccionRechazo = 1;

                if (rechazado)
                    seleccionRechazo = seleccionRechazo + 2;

                switch (seleccionRechazo)
                {
                    case 1:
                        return ltemp.Where(c => c.CH_RECH == false).OrderByDescending(c => c.CHE_FECHA).ToList();
                    case 2:
                        return ltemp.Where(c => c.CH_RECH == true).OrderByDescending(c => c.CHE_FECHA).ToList();
                    default:
                        return ltemp.OrderByDescending(c => c.CHE_FECHA).ToList();
                }
            }
        }

        public List<T0154_CHEQUES> GetListaChequesNumeroCheque(string numeroCheque, bool disponible = true,
            bool nodisponible = true,
            int top = 100)
        {
            var lch = new List<T0154_CHEQUES>();
            //Indicador Seleccion Disponible
            //0 = nada
            //1=  solo disponible
            //2 = solo no disponible
            //3 = todos
            int seleccionDisponible = 0;
            if (disponible)
                seleccionDisponible = 1;

            if (nodisponible)
                seleccionDisponible = seleccionDisponible + 2;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ltemp = new List<T0154_CHEQUES>();
                switch (seleccionDisponible)
                {
                    case 1:
                        //Solo disponible
                        ltemp = db.T0154_CHEQUES.Where(c => c.CHE_NUMERO.Contains(numeroCheque) && c.DISPONIBLE)
                            .Take(top).ToList();
                        break;
                    case 2:
                        //Solo no disponible
                        ltemp = db.T0154_CHEQUES
                            .Where(c => c.CHE_NUMERO.Contains(numeroCheque) && c.DISPONIBLE == false).Take(top)
                            .ToList();
                        break;
                    case 3:
                        //Disponible y No Disponible
                        ltemp = db.T0154_CHEQUES.Where(c => c.CHE_NUMERO.Contains(numeroCheque)).Take(top).ToList();
                        break;
                    default:
                        break;
                }

                return ltemp.OrderByDescending(c => c.IDCHEQUE).ToList();
            }

        }

        /// <summary>
        /// Get Lista de cheque super generica L1, L2 o L3 para todo - 
        /// Si pone todos los clientes deberia definir Disponible o no Disponible para reducir lista o fecha acred
        /// </summary>
        /// <returns></returns>
        public List<T0154_CHEQUES> GetListaChequesGenerico01(int? idCliente = null, string tipoLx = "L3",
            bool disponible = true, bool nodisponible = true, int top = 1000, decimal importeDesde = 0,
            decimal importeHasta = 99999999, bool statusNoRechazado = true, bool statusRechazado = true)
        {
            var lch = new List<T0154_CHEQUES>();

            //Indicador Seleccion Disponible
            //0 = nada
            //1=  solo disponible
            //2 = solo no disponible
            //3 = todos
            int seleccionDisponible = 0;
            if (disponible)
                seleccionDisponible = 1;

            if (nodisponible)
                seleccionDisponible = seleccionDisponible + 2;


            //Indicador Seleccion Rechazo-NoRechazo
            //0 = Todos
            //1= Solo Sin Rechazo
            //2= Solo Rechazado
            //3= Todos

            int seleccionRechazo = 0;
            if (statusNoRechazado)
                seleccionRechazo = 1;

            if (statusRechazado)
                seleccionRechazo = seleccionRechazo + 2;



            if (tipoLx == "L0")
                return null;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ltemp = new List<T0154_CHEQUES>();
                if (idCliente == null)
                {
                    //todos los clientes
                    switch (tipoLx.ToUpper())
                    {
                        case "L1":
                            //Para tipo L1
                            switch (seleccionDisponible)
                            {
                                case 1:
                                    //Solo disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c => c.DISPONIBLE &&
                                                 c.TIPO_REC == "L1").Take(top).ToList();
                                    break;
                                case 2:
                                    //Solo no disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c => c.DISPONIBLE == false &&
                                                 c.TIPO_REC == "L1").Take(top).ToList();
                                    break;
                                case 3:
                                    //Disponible y No Disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c => c.TIPO_REC == "L1").Take(top).ToList();
                                    break;
                                default:
                                    break;
                            }

                            break;
                        case "L2":
                            //Para tipo L2
                            switch (seleccionDisponible)
                            {
                                case 1:
                                    //Solo disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c =>
                                                c.DISPONIBLE &&
                                                c.TIPO_REC == "L2").Take(top).ToList();
                                    break;
                                case 2:
                                    //Solo no disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c =>
                                                c.DISPONIBLE == false &&
                                                c.TIPO_REC == "L2").Take(top).ToList();
                                    break;
                                case 3:
                                    //Disponible y No Disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c => c.TIPO_REC == "L2").Take(top).ToList();
                                    break;
                                default:
                                    break;
                            }

                            break;

                        default:
                            //Para todos los tipos
                            switch (seleccionDisponible)
                            {
                                case 1:
                                    //Solo disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                                c => c.DISPONIBLE)
                                            .Take(top)
                                            .ToList();
                                    break;
                                case 2:
                                    //Solo no disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                                c =>
                                                    c.DISPONIBLE == false)
                                            .Take(top)
                                            .ToList();
                                    break;
                                case 3:
                                    //Disponible y No Disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Take(top).ToList();
                                    break;
                                default:
                                    break;
                            }

                            break;
                    }
                }
                else
                {
                    //Para un Cliente Seleccionado
                    switch (tipoLx.ToUpper())
                    {
                        case "L1":
                            //Para tipo L1
                            switch (seleccionDisponible)
                            {
                                case 1:
                                    //Solo disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c =>
                                                c.IdClienteRecibido == idCliente.Value && c.DISPONIBLE &&
                                                c.TIPO_REC == "L1").Take(top).ToList();
                                    break;
                                case 2:
                                    //Solo no disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c =>
                                                c.IdClienteRecibido == idCliente.Value && c.DISPONIBLE == false &&
                                                c.TIPO_REC == "L1").Take(top).ToList();
                                    break;
                                case 3:
                                    //Disponible y No Disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c =>
                                                c.IdClienteRecibido == idCliente.Value &&
                                                c.TIPO_REC == "L1").Take(top).ToList();
                                    break;
                                default:
                                    break;
                            }

                            break;
                        case "L2":
                            //Para tipo L2
                            switch (seleccionDisponible)
                            {
                                case 1:
                                    //Solo disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c =>
                                                c.IdClienteRecibido == idCliente.Value && c.DISPONIBLE &&
                                                c.TIPO_REC == "L2").Take(top).ToList();
                                    break;
                                case 2:
                                    //Solo no disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c =>
                                                c.IdClienteRecibido == idCliente.Value && c.DISPONIBLE == false &&
                                                c.TIPO_REC == "L2").Take(top).ToList();
                                    break;
                                case 3:
                                    //Disponible y No Disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c =>
                                                c.IdClienteRecibido == idCliente.Value &&
                                                c.TIPO_REC == "L2").Take(top).ToList();
                                    break;
                                default:
                                    break;
                            }

                            break;

                        default:
                            //Para todos los tipos
                            switch (seleccionDisponible)
                            {
                                case 1:
                                    //Solo disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                                c =>
                                                    c.IdClienteRecibido == idCliente.Value && c.DISPONIBLE)
                                            .Take(top)
                                            .ToList();
                                    break;
                                case 2:
                                    //Solo no disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                                c =>
                                                    c.IdClienteRecibido == idCliente.Value &&
                                                    c.DISPONIBLE == false)
                                            .Take(top)
                                            .ToList();
                                    break;
                                case 3:
                                    //Disponible y No Disponible
                                    ltemp =
                                        db.T0154_CHEQUES.Where(
                                            c =>
                                                c.IdClienteRecibido == idCliente.Value).Take(top).ToList();
                                    break;
                                default:
                                    break;
                            }

                            break;
                    }
                }

                ltemp.Where(c => c.IMPORTE.Value >= importeDesde && c.IMPORTE.Value < importeHasta).ToList();
                switch (seleccionRechazo)
                {
                    case 1:
                        //solo sin rechazo
                        return ltemp.Where(c => c.CH_RECH != true).ToList();
                    case 2:
                        //solo rechazado
                        return ltemp.Where(c => c.CH_RECH == true).ToList();
                    default:
                        return ltemp.ToList();
                }
            }
        }

        public List<TsCheques1> GetListaChequesFiltrada(string lx, bool verDisponible = true, bool verNoDisponible = false,
            string numeroCheque = "", int idCheque = -1, DateTime? menorIgualaFecha = null, bool verInterior = true, bool verNoInterior = true)
        {
            var idCh = idCheque;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (idCh > 0)
                {
                    //como se provee un IDCheque - Se sobreescribe cualquier filtrado
                }
                else
                {
                    if (verDisponible == verNoDisponible)
                    {
                        if (verDisponible == false)
                        {
                            return null; //es seleccion de no ver ninguno
                        }
                    }

                    if (lx == "L0")
                        return null;
                }

                List<TsCheques1> result = new List<TsCheques1>();
                if (verDisponible && verNoDisponible)
                {
                    result = db.T0154_CHEQUES.Join(db.T0160_BANCOS, che => che.CHE_BANCO, ban => ban.ID_BANCO,
                        (che, ban) => new TsCheques1()
                        {
                            Idcheque = che.IDCHEQUE,
                            Importe = che.IMPORTE.Value,
                            Numero = che.CHE_NUMERO,
                            BancoShort = ban.BCO_SHORTDESC,
                            ClienteRs = che.CLIENTE,
                            Disponible = che.DISPONIBLE,
                            Tipo = che.TIPO,
                            FechaAcreditacion = che.CHE_FECHA,
                            FechaRecibido = che.FECHA_RECIBIDO,
                            Comentario = che.COMENTARIO,
                            BancoId = che.CHE_BANCO,
                            Interior = che.CHE_INTERIOR.Value,
                            TipoSalida = che.TIPOSAL,
                            Rechazado = che.CH_RECH,
                            FechaEntregado = che.FECHA_ENTREGADO,
                            EntregadoA = che.PROVEEDOR,
                            DocumentoSalida = che.OP,
                            IsEcheque = che.Echeque
                        }).ToList();
                }
                else
                {
                    if (verDisponible)
                    {
                        result = db.T0154_CHEQUES.Where(c => c.DISPONIBLE).Join(db.T0160_BANCOS, che => che.CHE_BANCO,
                            ban => ban.ID_BANCO,
                            (che, ban) => new TsCheques1()
                            {
                                Idcheque = che.IDCHEQUE,
                                Importe = che.IMPORTE.Value,
                                Numero = che.CHE_NUMERO,
                                BancoShort = ban.BCO_SHORTDESC,
                                ClienteRs = che.CLIENTE,
                                Disponible = che.DISPONIBLE,
                                Tipo = che.TIPO,
                                FechaAcreditacion = che.CHE_FECHA,
                                FechaRecibido = che.FECHA_RECIBIDO,
                                Comentario = che.COMENTARIO,
                                BancoId = che.CHE_BANCO,
                                Interior = che.CHE_INTERIOR.Value,
                                TipoSalida = che.TIPOSAL,
                                Rechazado = che.CH_RECH,
                                FechaEntregado = che.FECHA_ENTREGADO,
                                EntregadoA = che.PROVEEDOR,
                                DocumentoSalida = che.OP,
                                IsEcheque = che.Echeque
                            }).ToList();
                    }
                    else
                    {
                        result = db.T0154_CHEQUES.Where(c => c.DISPONIBLE == false).Join(db.T0160_BANCOS,
                            che => che.CHE_BANCO, ban => ban.ID_BANCO,
                            (che, ban) => new TsCheques1()
                            {
                                Idcheque = che.IDCHEQUE,
                                Importe = che.IMPORTE.Value,
                                Numero = che.CHE_NUMERO,
                                BancoShort = ban.BCO_SHORTDESC,
                                ClienteRs = che.CLIENTE,
                                Disponible = che.DISPONIBLE,
                                Tipo = che.TIPO,
                                FechaAcreditacion = che.CHE_FECHA,
                                FechaRecibido = che.FECHA_RECIBIDO,
                                Comentario = che.COMENTARIO,
                                BancoId = che.CHE_BANCO,
                                Interior = che.CHE_INTERIOR.Value,
                                TipoSalida = che.TIPOSAL,
                                Rechazado = che.CH_RECH,
                                FechaEntregado = che.FECHA_ENTREGADO,
                                EntregadoA = che.PROVEEDOR,
                                DocumentoSalida = che.OP,
                                IsEcheque = che.Echeque
                            }).ToList();
                    }
                }
                
                if (idCh > 0)
                {
                    return result.Where(c => c.Idcheque == idCh).ToList();
                }
      
                //Se empiezan a aplicar todos los filtrados
                
                var r2 = result; //Filtrado x Numero de Cheque (contains)
                var r3 = result; //Filtrado Interior-NoInterior
                
                if (string.IsNullOrEmpty(numeroCheque))
                {
                    r2 = result.ToList();
                }
                else
                {
                    r2 = result.Where(c => c.Numero.Contains(numeroCheque)).ToList();
                }
                

                if (verInterior == verNoInterior)
                {
                    if (verInterior == false)
                    {
                        //debiera retornar nada porque no hay ninguno seleccionado
                        return null;
                    }
                    else
                    {
                        r3 = r2.ToList();
                    }
                }
                else
                {
                    if (verInterior)
                    {
                        r3 = r2.Where(c => c.Interior == true).ToList();
                    }
                    else
                    {
                        //es verNOINTERIOR
                        r3 = r2.Where(c => c.Interior == false).ToList();
                    }
                }

                if (lx == "L1")
                {
                    if (menorIgualaFecha == null)
                        return r3.Where(c => c.Tipo == "L1").OrderBy(c => c.FechaAcreditacion).ToList();
                    return r3.Where(c => c.Tipo == "L1" && c.FechaAcreditacion <= menorIgualaFecha)
                        .OrderBy(c => c.FechaAcreditacion).ToList();
                }
                else
                {
                    if (lx == "L2")
                    {
                        if (menorIgualaFecha == null)
                            return r3.Where(c => c.Tipo == "L2").OrderBy(c => c.FechaAcreditacion).ToList();
                        return r3.Where(c => c.Tipo == "L2" && c.FechaAcreditacion <= menorIgualaFecha)
                            .OrderBy(c => c.FechaAcreditacion).ToList();
                    }
                    else
                    {
                        if (menorIgualaFecha == null)
                            return r3.OrderBy(c => c.FechaAcreditacion).ToList();
                        return r3.Where(c => c.FechaAcreditacion <= menorIgualaFecha).OrderBy(c => c.FechaAcreditacion)
                            .ToList();
                    }
                }
            }
        }

        public ChequesStats GetChequeStats(string cuit, DateTime? fechaDesde = null)
        {
            if (fechaDesde == null)
                fechaDesde = DateTime.Today.AddDays(-365);

            var rtn = new ChequesStats()
            {
                PendientesAcreditar = 0,
                TotalRechazados = 0,
                TotalRecibidos = 0
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var chg = db.T0154_CHEQUES.Where(c => c.CHE_CUIT == cuit && c.CHE_FECHA >= fechaDesde).ToList();
                if (!chg.Any())
                    return rtn;

                rtn.PendientesAcreditar = chg.Count(c => c.Acreditado == false);
                rtn.TotalRechazados = chg.Count(c => c.CH_RECH == true);
                rtn.TotalRecibidos = chg.Count;
                return rtn;
            }
        }

        public void DesAcreditarCheque(int idCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                ch.Acreditado = false;
                ch.StatusCheque = "Pendiente";
                db.SaveChanges();
            }
        }
        public bool AcreditarCheque(int idCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var ch = db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque);
                if (ch.CH_RECH == true)
                {
                    //El Cheque esta rechazado - no se puede acreditar
                    return false;
                }
                ch.Acreditado = true;
                ch.StatusCheque = "Acreditado";
                db.SaveChanges();
                return true;
            }
        }
        public bool IsChequeAcreditado(int idCheque)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0154_CHEQUES.SingleOrDefault(c => c.IDCHEQUE == idCheque).Acreditado;
            }
        }
        public int AutoAcreditarCheques(int diasVencido = 180)
        {
            DateTime fechaMaximaCheque = DateTime.Today.AddDays(-diasVencido);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var chNoAcreditado = db.T0154_CHEQUES.Where(c =>
                    c.CHE_FECHA < fechaMaximaCheque && c.CH_RECH == false && c.Acreditado == false);
                foreach (var cheque in chNoAcreditado)
                {
                    cheque.Acreditado = true;
                    cheque.StatusCheque = "Acreditado@";
                }
                return db.SaveChanges();
            }
        }

        public List<TsCheques1> GetListaChequeRecibidoCliente(int idCliente, string lx, bool verDisponible = true, bool verNoDisponible = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (verDisponible == verNoDisponible)
                {
                    if (verDisponible == false)
                    {
                        //es seleccion de no ver ninguno
                        return null;
                    }
                }
                var result = db.T0154_CHEQUES.Where(c => c.IdClienteRecibido == idCliente).Join(db.T0160_BANCOS, che => che.CHE_BANCO, ban => ban.ID_BANCO,
                    (che, ban) => new TsCheques1()
                    {
                        Idcheque = che.IDCHEQUE,
                        Importe = che.IMPORTE.Value,
                        Numero = che.CHE_NUMERO,
                        BancoShort = ban.BCO_SHORTDESC,
                        ClienteRs = che.CLIENTE,
                        Disponible = che.DISPONIBLE,
                        Tipo = che.TIPO,
                        FechaAcreditacion = che.CHE_FECHA,
                        FechaRecibido = che.FECHA_RECIBIDO,
                        Comentario = che.COMENTARIO,
                        BancoId = che.CHE_BANCO,
                        Interior = che.CHE_INTERIOR.Value,
                        TipoSalida = che.TIPOSAL,
                        Rechazado = che.CH_RECH,
                        FechaEntregado = che.FECHA_ENTREGADO,
                        EntregadoA = che.PROVEEDOR,
                        DocumentoSalida = che.OP,
                        IsEcheque = che.Echeque
                    });

                if (verDisponible && verNoDisponible)
                {
                    return result.OrderByDescending(c => c.FechaAcreditacion).ToList(); //Retorna listado completo sin ningun filtrado
                }
                else
                {
                    if (verDisponible == true)
                    {
                        //Listado filtrado1 = Solo Disponible
                        return result.Where(c => c.Disponible == true).OrderByDescending(c => c.FechaAcreditacion).ToList();
                    }
                    else
                    {
                        //Listado filtrado1 = Solo NO Disponible
                        return result.Where(c => c.Disponible == false).OrderByDescending(c => c.FechaAcreditacion).ToList();
                    }
                }
            }
        }



    }
}

