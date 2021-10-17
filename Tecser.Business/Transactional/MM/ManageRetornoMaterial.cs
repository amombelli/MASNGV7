using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.MM
{
    public static class MotivoDevolucion
    {
        public enum Motivo
        {
            ErrorAdmnistrativo,
            SobranteCliente,
            FE,
            PedidoIncorrecto,
            Otro
        };
        public static Motivo MapStatusFromText(string status)
        {
            if (String.IsNullOrEmpty(status))
                return MotivoDevolucion.Motivo.Otro;

            //Mapeo to fix errores
            if (status.ToUpper().Equals("@@") || status.ToUpper().Equals("@@@"))
                return MotivoDevolucion.Motivo.Otro;

            try
            {
                return (Motivo)Enum.Parse(typeof(Motivo), status, true);
            }
            catch (Exception)
            {
                return MotivoDevolucion.Motivo.Otro;
                throw;
            }
        }
    }
    public class ManageRetornoMaterial
    {
        public struct RetornoDevolucion
        {
            public int id360;
            public int id40;
        }

        public T0360_RTN GetRegistroRetorno(int idRetorno)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0360_RTN.SingleOrDefault(c => c.IDX == idRetorno);
            }
        }

        public RetornoDevolucion GestionDevolucion(DateTime fechaDev, int idCliente, MotivoDevolucion.Motivo motivo,
            string material, string lote, decimal kg, string ubicacionMaterial, string recibio, string observacion,
            string lxMovimiento, string aprobadoPor,
            StockStatusManager.EstadoLote estadoLote = StockStatusManager.EstadoLote.Restringido)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var t = new T0360_RTN()
                {
                    IDX = db.T0360_RTN.Max(c => c.IDX) + 1,
                    FECHA = fechaDev,
                    IDCLI = idCliente,
                    CLIENTE = new CustomerManager().GetCustomerBillToData(idCliente).cli_rsocial,
                    TIPO_MOV = lxMovimiento,
                    MOTIVO = motivo.ToString(),
                    MATERIAL = material,
                    LOTE = lote,
                    KG = kg,
                    UBICACION = ubicacionMaterial,
                    RECIBIO = recibio,
                    COMENTARIO = observacion,
                    LogCreadoPor = GlobalApp.AppUsername,
                    LogCreadoEn = DateTime.Today,
                    AprobadoPor = aprobadoPor,
                    COMERCIAL = null,
                    KgNC = null,
                    NASIENTO = null,
                    NID40 = null,
                    NumeroNC = null,
                };
                db.T0360_RTN.Add(t);
                var r = db.SaveChanges();
                if (r > 0)
                {
                    new StockABM().AltaNewStockLine(material, lote, Math.Abs(kg), estadoLote, ubicacionMaterial, "RTN1", false,
                        observacion);
                    var id40 = new MmLog().LogMMAltaNewStockDevolucion(motivo, t.IDX, estadoLote);
                    var data = db.T0360_RTN.SingleOrDefault(c => c.IDX == t.IDX);
                    data.NID40 = id40;
                    db.SaveChanges();
                    return new RetornoDevolucion()
                    {
                        id40 = id40,
                        id360 = t.IDX
                    };
                }
                return new RetornoDevolucion() { id360 = -1, id40 = -1 };
            }
        }


        public void UpdateId40(int idH, int id40)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0360_RTN.SingleOrDefault(c => c.IDX == idH);
                data.NID40 = id40;
                db.SaveChanges();
            }
        }
        public int GuardaRtn(T0360_RTN data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (data.IDX == 0)
                {
                    data.IDX = db.T0360_RTN.Max(c => c.IDX) + 1;
                    data.LogCreadoEn = DateTime.Now;
                    data.LogCreadoPor = GlobalApp.AppUsername;
                    db.T0360_RTN.Add(data);
                    return db.SaveChanges() > 0 ? data.IDX : 0;
                }
                else
                {
                    var x = db.T0360_RTN.SingleOrDefault(c => c.IDX == data.IDX);
                    if (x == null) return -1;
                    x.COMENTARIO = data.COMENTARIO;
                    //remapear ?
                    return db.SaveChanges();
                }
            }
        }

        public List<T0360_RTN> GetDevolucionesFromCustomer(int idCliente, bool soloPendienteNc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloPendienteNc)
                    return db.T0360_RTN.Where(c => c.IDCLI == idCliente && c.NumeroNC == null).ToList();
                return db.T0360_RTN.Where(c => c.IDCLI == idCliente).ToList();
            }
        }

        public List<T0401_FACTURA_I> GetUltimasComprasClienteMaterialReturn(string material, string lote, int idCliente, int top)
        {
            List<T0401_FACTURA_I> rtn = new List<T0401_FACTURA_I>();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0056_REMITO_I.Where(c =>
                    c.MATERIAL == material && c.BATCH == lote && c.T0055_REMITO_H.T0007_CLI_ENTREGA.IDCLIENTE == idCliente).ToList();
                foreach (var lst in x)
                {
                    var z = db.T0401_FACTURA_I.Where(c => c.IDFactura == lst.T0055_REMITO_H.Factura && c.ITEM == material).ToList();
                    if (z.Any())
                        rtn.AddRange(z);
                }
                return rtn;
            }
        }

        public void UpdateNumeroNc(int idRetorno, string numeroNc, decimal kg)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0360_RTN.SingleOrDefault(c => c.IDX == idRetorno);
                if (data == null)
                    return;

                data.NumeroNC = numeroNc;
                if (data.KgNC > 0)
                {
                    data.KgNC += kg;
                }
                else
                {
                    data.KgNC = kg;
                }
                db.SaveChanges();
            }
        }

        public void UpdateRegistroRtnAfterNotaCredito(int idRtn, int idNC, decimal kgNotaCredito)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rtn = db.T0360_RTN.SingleOrDefault(c => c.IDX == idRtn);
                if (rtn == null) return;
                var nc = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == idNC);
                if (nc == null) return;

                if (nc.idFacturaAsociada != null)
                {
                    var factuOriginal = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == nc.idFacturaAsociada.Value);
                    rtn.COMERCIAL = "Despacho " + factuOriginal.TIPO_DOC + "#" + factuOriginal.NumeroDoc;
                }
                else
                {
                    rtn.COMERCIAL = "No se ha Identificado factura despacho";
                }
                rtn.NumeroNC = nc.NDOC;
                rtn.KgNC = kgNotaCredito;
                db.SaveChanges();
            }
        }
    }
}
