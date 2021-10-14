using System;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.Transactional.MM
{
    public class MmLog
    {
        //Movimientos mapean en Tabla80
        //Todos los tipos de movimiento van ingresados en T0080 
        //completando con el tipo documento genera
        public enum TipoMovimiento
        {
            IngresoStockProduccion = 1,
            ReversionIngresoStockProduccion = 2,
            DevolucionClienteGeneral = 5,
            DevolucionClienteFE = 6,
            DevolucionClienteStkSobrante = 7,
            ConsumoMP = 10,
            ReversionConsumoMP = 11,
            EgresoVentaConOV = 50,
            ReversionEgresoVentaConOV = 51,
            IngresoStockIc = 100,
            ReversionIc = 101,
            IngresoStockProduccionTemporal = 503,
            ReversionIngresoStockProduccionTemporal = 504,
            TransferenciaBodegaOut = 500,
            TransferenciaBodegaIn = 501,
            EstadoOriginal = 200,
            EstadoNuevo = 201,
            CambioLoteOriginal = 204,
            CambioLoteNuevo = 205,
            AjusteInventarioMas = 206,
            AjusteInventarioMenos = 207,
            ProcesoPurga = 508,
            EnvioFason = 20,
            RecepcionFason = 21
        };

        public static string TipoDocumentoFromTipoMovimiento(TipoMovimiento tipoMov)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                int z0 = Convert.ToInt32(tipoMov);
                var z = db.T0080_TIPO_MOVIMIENTOS.Single(c => c.IDMOVIMIENTO == z0);
                return z.DocumentoGenera;
            }
        }
        public static T0042_PRODUCCION_DET GetT0042Line(int id40)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0042_PRODUCCION_DET.SingleOrDefault(c => c.ID40.Value == id40);
            }
        }
        public static T0040_MAT_MOVIMIENTOS GetT40Line(int id40)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0040_MAT_MOVIMIENTOS.SingleOrDefault(c => c.IDMOVIMIENTO == id40);
            }
        }
        public static void UpdateTipoLx(int id40, string tipoLX)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0040_MAT_MOVIMIENTOS.SingleOrDefault(c => c.IDMOVIMIENTO == id40);
                data.TIPO = tipoLX;
                db.SaveChanges();
            }
        }
        private static int GetNextId42()
        {
            return new TecserData(GlobalApp.CnnApp).T0042_PRODUCCION_DET.Max(c => c.IDMOV) + 1;
        }

        /// <summary>
        /// Loguea en tabla 42 cuando es una produccion/ingreso de produccion
        /// </summary>
        /// <returns>Si se pudo loguear correcto, retorna numero ID42, si no retorna 0</returns>
        public int LogMovimientoDetalladoT42(int id40, string operadorShortname, DateTime? horaInicio,
            DateTime? horaFinal, int tiempoStopMinutos, int numeroStops, int cantidadPasadas,
            bool limpiezaCabezal = false, bool limpiezaCompleta = false, string observaciones = null)
        {
            var x = new T0042_PRODUCCION_DET();
            var data40 =
                new Repository<T0040_MAT_MOVIMIENTOS>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.IDMOVIMIENTO == id40);
            if (data40 != null)
            {
                x.IDMOV = GetNextId42();
                x.MATERIAL = data40.IDMATERIAL;
                x.TIPOMOV = data40.TIPOMOVIMIENTO;
                x.OF = Convert.ToInt32(data40.DOCUMENTO);
                x.OFS = "1";
                x.LOTE = data40.BATCH;
                x.KG = data40.CANTIDAD;
                x.FECHA = data40.FECHAMOV;
                if (horaInicio.HasValue)
                    x.HORAI = horaInicio;

                if (horaFinal.HasValue)
                    x.HORAF = horaFinal;

                x.RECURSO_PROD = data40.RECURSO;
                x.NUMSTOPS = numeroStops;
                x.NUM_PASADAS = cantidadPasadas;
                x.LIM_CABEZAL = false;
                x.LIM_COMPLETA = false;
                x.TIEMPO_STOP = tiempoStopMinutos;
                x.STOP_OBS = observaciones;
                x.OPERADOR = operadorShortname;
                x.NUM_PASADAS = cantidadPasadas;
                x.ID40 = id40;
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    db.T0042_PRODUCCION_DET.Add(x);
                    if (db.SaveChanges() > 0)
                        return x.IDMOV;
                    return 0;
                }
            }
            return 0;
        }

        public int LogEnvioFason(int idstockOriginal, decimal kgEnviar, string remitoNumero, int idProveedorFason,
            string tcode, string comentario = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkori = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstockOriginal);
                if (stkori == null)
                    throw new InvalidOperationException("StockLine no encontrada");

                var logOut = LogMovimientoT40(stkori.Material, DateTime.Today,
                    Convert.ToInt32(TipoMovimiento.EnvioFason),
                    "OFE", remitoNumero, kgEnviar * -1, tcode, stkori.SLOC, stkori.Estado, "E", "LX", stkori.Batch,
                    idPro: idProveedorFason);
                return logOut;
            }
        }

        public int LogMMChangeSLOC(int idstockOriginal, decimal kgMover, string oldSloc, string newSloc, string tcode, string comentario = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkori = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstockOriginal);
                if (stkori == null)
                    throw new InvalidOperationException("StockLine no encontrada");

                var logOut = LogMovimientoT40(stkori.Material, DateTime.Today,
                    Convert.ToInt32(TipoMovimiento.TransferenciaBodegaOut),
                    "TX", "0", kgMover * -1, tcode, oldSloc, stkori.Estado, "T", "LX", stkori.Batch);


                var logIn = LogMovimientoT40(stkori.Material, DateTime.Today,
                    Convert.ToInt32(TipoMovimiento.TransferenciaBodegaIn), "TX", "0", kgMover, tcode, newSloc,
                    stkori.Estado, "T", "LX", stkori.Batch, comentarioMovimiento: comentario);

                return logIn;
            }
        }
        public int LogMMChangeEstado(int idstockOriginal, decimal kgCambioEstado, string oldEstado, string newEstado, string tcode, int? idClienteCompromiso = null, int? idReservaOF = null, string comentario = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkori = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstockOriginal);
                if (stkori == null)
                    throw new InvalidOperationException("StockLine no encontrada");

                var logOut = LogMovimientoT40(stkori.Material, DateTime.Today,
                    Convert.ToInt32(TipoMovimiento.EstadoOriginal),
                    "CQ", "0", kgCambioEstado * -1, tcode, stkori.SLOC, oldEstado, "T", "LX", stkori.Batch);


                var logIn = LogMovimientoT40(stkori.Material, DateTime.Today,
                    Convert.ToInt32(TipoMovimiento.EstadoNuevo), "CQ", "0", kgCambioEstado, tcode, stkori.SLOC,
                    newEstado, "T", "LX", stkori.Batch, comentarioMovimiento: comentario);

                return logIn;
            }
        }
        public int LogMMChangeLoteNumber(int idstockOriginal, decimal kgModificado, string oldLote, string newLote, string tcode, int? idClienteCompromiso = null, int? idReservaOF = null, string comentario = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkori = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstockOriginal);
                if (stkori == null)
                    throw new InvalidOperationException("StockLine no encontrada");

                var logOut = LogMovimientoT40(stkori.Material, DateTime.Today,
                    Convert.ToInt32(TipoMovimiento.CambioLoteOriginal),
                    "CQ", "0", kgModificado * -1, tcode, stkori.SLOC, stkori.Estado, "T", "LX", oldLote);


                var logIn = LogMovimientoT40(stkori.Material, DateTime.Today,
                    Convert.ToInt32(TipoMovimiento.CambioLoteNuevo), "CQ", "0", kgModificado, tcode, stkori.SLOC,
                    stkori.Estado, "T", "LX", newLote, comentarioMovimiento: comentario);

                return logIn;
            }
        }

        public int LogMMAjusteKgStock(int idstockOriginal, decimal kgModificado, string tcode,
            int? idClienteCompromiso = null, int? idReservaOF = null, string comentario = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stkori = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == idstockOriginal);
                if (stkori == null)
                    throw new InvalidOperationException("StockLine no encontrada");

                var tipoMovimiento = kgModificado > 0
                    ? TipoMovimiento.AjusteInventarioMas
                    : TipoMovimiento.AjusteInventarioMenos;

                var logOut = LogMovimientoT40(stkori.Material, DateTime.Today,
                    Convert.ToInt32(tipoMovimiento), "AI", "ASN", kgModificado, tcode, stkori.SLOC, stkori.Estado, "T",
                    "LX", stkori.Batch, comentarioMovimiento: comentario);
                return logOut;
            }
        }

        public int LogMMAltaNewStockLine(int idstock, string material, string lote, string estado, string sloc,
            decimal kg, string tcode, string comentario = null)
        {
            var tipoMovimiento = TipoMovimiento.AjusteInventarioMas;

            var logOut = LogMovimientoT40(material, DateTime.Today,
                Convert.ToInt32(tipoMovimiento), "AI", "ASN" + idstock, kg, tcode, sloc, estado, "T", "LX", lote,
                comentarioMovimiento: comentario);
            return logOut;
        }
        public int LogMMCancelacionRemito(int idRemito, int idItem)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0056_REMITO_I.SingleOrDefault(c => c.IDREMITO == idRemito && c.IDITEM == idItem);
                var h = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == idRemito);

                int idClienteT6 = h.T0007_CLI_ENTREGA.IDCLIENTE;
                var tipoMovimiento = TipoMovimiento.ReversionEgresoVentaConOV;

                var logOut = LogMovimientoT40(x.MATERIAL, DateTime.Today, Convert.ToInt32(tipoMovimiento), "RZ",
                    x.NUMREMITO, x.KGDESPACHADOS, "CANR", x.SLOC,
                    StockStatusManager.EstadoLote.Liberado.ToString(), "I", h.TIPO_REMITO, x.BATCH,
                    idCli: idClienteT6, comentarioMovimiento: "Cancelacion de Remito", refTableName: "T0055_REMITO_I",
                    refIdnum: x.IDITEM, glVta: x.GLV);

                return logOut;

            }
        }
        public int LogMMAltaNewStockDevolucion(MotivoDevolucion.Motivo motivo, int idHeaderDev,StockStatusManager.EstadoLote estado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0360_RTN.SingleOrDefault(c => c.IDX == idHeaderDev);
                if (x == null)
                {
                    return 0;
                }

                var tipoMovimiento = TipoMovimiento.DevolucionClienteGeneral; //(5)
                switch (motivo)
                {
                    case MotivoDevolucion.Motivo.ErrorAdmnistrativo:
                        break;
                    case MotivoDevolucion.Motivo.SobranteCliente:
                        break;
                    case MotivoDevolucion.Motivo.FE:
                        break;
                    case MotivoDevolucion.Motivo.PedidoIncorrecto:
                        break;
                    case MotivoDevolucion.Motivo.Otro:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(motivo), motivo, null);
                }

                var logOut = LogMovimientoT40(x.MATERIAL, x.FECHA, Convert.ToInt32(tipoMovimiento), "RTN",
                    idHeaderDev.ToString(), x.KG, "RTN1", "LAB1",estado.ToString(), "I", "LX", x.LOTE, idCli: x.IDCLI,
                    comentarioMovimiento: x.COMENTARIO, refTableName: "T0360_RTN", refIdnum: idHeaderDev);
                return logOut;
            }
        }


        /// <summary>
        /// Loguea movimiento en Tabla 40.-
        /// </summary>
        /// <returns>
        /// retorna el ID creado en tabla 40
        /// </returns>
        public int LogMovimientoT40(string material, DateTime fechaMovimiento, int tipoMovimiento, string tipoDocumento, string numeroDocumento, decimal cantidadKg, string tCode, string sLoc, string batchStatus, String iet, string tipoLx, string numeroLote = null, int recursoProduccion = 0, int idCli = 0, int idPro = 0, string comentarioMovimiento = null, string refTableName = null, int refIdnum = 0, string refIdTxt = null, string txt1 = null, string glVta = null, int nasX1 = 0, int nasX2 = 0)
        {
            var x = new T0040_MAT_MOVIMIENTOS();
            if (sLoc == null)
                sLoc = "STBY";
            x.IDMOVIMIENTO = GetNextId40();
            x.IDMATERIAL = material;
            x.FECHAMOV = fechaMovimiento;
            x.TIPOMOVIMIENTO = tipoMovimiento;
            if (string.IsNullOrEmpty(tipoDocumento) == true)
            {
                x.TIPO_DOCUMENTO = new TecserData(GlobalApp.CnnApp).T0080_TIPO_MOVIMIENTOS.SingleOrDefault(c => c.IDMOVIMIENTO == tipoMovimiento).DocumentoGenera.Trim();
            }
            else
            {
                x.TIPO_DOCUMENTO = tipoDocumento;
            }

            x.DOCUMENTO = numeroDocumento;
            x.CANTIDAD = cantidadKg;
            x.BATCH = numeroLote;
            x.LOG_USER = Environment.UserName;
            x.LOG_DATE = DateTime.Now;
            x.COMENTARIO = comentarioMovimiento;
            x.TIPO = tipoLx;
            x.IET = iet;
            x.PERIODO = new PeriodoConversion().GetPeriodo(fechaMovimiento);
            x.TCODE = tCode;
            x.SLOC = sLoc;
            x.BATCHST = batchStatus;
            x.IDCLI = idCli;
            x.IDPRO = idPro;
            x.XTABLA = refTableName;
            x.XIDTXT = refIdTxt;
            x.XIDNUM = refIdnum;
            x.RECURSO = recursoProduccion;
            x.TXT1 = txt1;
            x.GLVTA = glVta;
            x.NAS1 = nasX1;
            x.NAS2 = nasX2;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                db.T0040_MAT_MOVIMIENTOS.Add(x);
                if (db.SaveChanges() > 0)
                    return x.IDMOVIMIENTO;
                return 0;
            }
        }
        public bool ReversionLogIngresoStock(int id40)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d40 = db.T0040_MAT_MOVIMIENTOS.SingleOrDefault(c => c.IDMOVIMIENTO == id40);
                if (d40 != null)
                {
                    if (d40.TIPOMOVIMIENTO == 2 || d40.TIPOMOVIMIENTO == 504)
                        return false; //No se puede revertir una reversion

                    if (d40.TIPOMOVIMIENTO == 1 || d40.TIPOMOVIMIENTO == 503)
                    {
                        var new40 = new MmLog().LogMovimientoT40(d40.IDMATERIAL, DateTime.Today, d40.TIPOMOVIMIENTO.Value + 1, d40.TIPO_DOCUMENTO, d40.DOCUMENTO, d40.CANTIDAD.Value * -1, "ESR", d40.SLOC, d40.BATCHST, "E", "LX", d40.BATCH, d40.RECURSO.Value, 0, 0, "Reversion movimiento ID#" + id40.ToString(), "T0040_MOVIMIENTOS", id40);

                        if (new40 > 0)
                        {
                            //logueo correcto en T0040 + Cambio de movimiento IET a R==Reversi0n de movimiento
                            d40.IET = @"R";
                            var d40new = db.T0040_MAT_MOVIMIENTOS.SingleOrDefault(c => c.IDMOVIMIENTO == new40);
                            d40new.IET = @"R";
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false; //tipo de movimiento no permitido para revertir
                }
                return false;
            }
        }

        /// <summary>
        /// Solamente Loguea la reversion de MP - Es usado unicamente cuando en medio de un cierre de OF encuentra que un 
        /// Stock ya no corresponde y entonces cancela. En este momento solo habia logueado, asi que lo que hace es 'revertir el Log' 
        /// </summary>
        public void RevierteLogDescuentoMP(int numeroOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var log = new MmLog();
                int tipoMovimientoRevert = Convert.ToInt32(MmLog.TipoMovimiento.ConsumoMP);
                string OFnumero = numeroOF.ToString();



                var dataLogueada =
                    db.T0040_MAT_MOVIMIENTOS.Where(
                        c =>
                            c.TIPOMOVIMIENTO == tipoMovimientoRevert && c.TIPO_DOCUMENTO == "OF" &&
                            c.DOCUMENTO == OFnumero).ToList();
                foreach (var item in dataLogueada)
                {
                    item.COMENTARIO = "Este descuento ha sido revertido por error en OF";
                    item.TIPO_DOCUMENTO = "OF@"; //Para que no aparezca en los consumos de MP?
                    //
                    log.LogMovimientoT40(item.IDMATERIAL, item.FECHAMOV.Value,
                        Convert.ToInt32(MmLog.TipoMovimiento.ReversionConsumoMP), "OF@", OFnumero, item.CANTIDAD.Value * -1,
                        "ES", item.SLOC, item.BATCHST, "I", "LX", item.BATCH);
                }
                db.SaveChanges();
            }
        }
        public bool ReversionLogConsumoMateriasPrimas(int numeroOF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var numOF = numeroOF.ToString();
                var d = db.T0040_MAT_MOVIMIENTOS.Where(c => c.DOCUMENTO == numOF && c.TIPO_DOCUMENTO == "OF" && (c.TIPOMOVIMIENTO == (int)TipoMovimiento.ConsumoMP)).ToList();

                var pf = db.T0070_PLANPRODUCCION.SingleOrDefault(c => c.IDPLAN == numeroOF);
                if (pf == null)
                    return false;

                foreach (var ix in d)
                {
                    //Cambio el documento original en T0040 a OF@ para que no aparezcan en los dgv de consumo
                    ix.TIPO_DOCUMENTO = "OF@";
                    ix.COMENTARIO = "Reversion Consumo MP";


                    //logueo correcto en T0040
                    var id40 = new StockManager().AddNewStock_withLogT40(ix.IDMATERIAL, ix.BATCH, ix.CANTIDAD.Value * -1, StockStatusManager.EstadoLote.Liberado, ix.SLOC, DateTime.Today, TipoMovimiento.ReversionConsumoMP, ix.DOCUMENTO, "OF", "LX", comentarioMovimiento: "Reversion consumo MP - ID40@" + ix.IDMOVIMIENTO, documentoStock: "OF", nombreTablaReferencia: "T0040_MAT_MOVIMIENTOS", referenciaNumerica: ix.IDMOVIMIENTO);

                    if (id40 > 0)
                    {
                        //Sumo correcto el consumo al stock + Log Correcto
                    }
                    else
                    {
                        //Ha ocurrido algun error en T0040 - Abort
                        return false;
                    }
                }

                pf.STATUS = "Proceso";
                pf.ObsPlan = "#OF.REV @" + pf.ObsPlan;

                if (db.SaveChanges() > 0)
                    return true;
                return false;


                //var new40 = new MmLog().LogMovimientoT40(ix.IDMATERIAL, DateTime.Today,
                //    (int) TipoMovimiento.ReversionConsumoMP, "OF", numOF, ix.CANTIDAD.Value*-1, "OFR", ix.SLOC,
                //    "Liberado", "I", "TipoLX", ix.BATCH, ix.RECURSO.Value, 0, 0, "Reversion ID40@" + ix.IDMOVIMIENTO,
                //    "T0040_MAT_MOVIMIENTOS", ix.IDMOVIMIENTO);
            }
        }
        private static int GetNextId40()
        {
            return new TecserData(GlobalApp.CnnApp).T0040_MAT_MOVIMIENTOS.Max(c => c.IDMOVIMIENTO) + 1;
        }
        public void UpdateIngresoTemporal(int id40, DateTime fechaIngreso, int idRecursoProduccion, string operario, string comentarioIngreso)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d40 = db.T0040_MAT_MOVIMIENTOS.SingleOrDefault(c => c.IDMOVIMIENTO == id40);
                if (d40 != null)
                {
                    d40.FECHAMOV = fechaIngreso;
                    d40.RECURSO = idRecursoProduccion;
                    d40.LOG_DATE = DateTime.Today;
                    d40.LOG_USER = Environment.UserName;
                    d40.COMENTARIO = comentarioIngreso;
                }
                var d42 = db.T0042_PRODUCCION_DET.SingleOrDefault(c => c.ID40 == id40);
                if (d42 != null)
                {
                    d42.OPERADOR = operario;
                    d42.FECHA = fechaIngreso;
                    d42.RECURSO_PROD = idRecursoProduccion;
                }
                db.SaveChanges();
            }

        }
    }
}
