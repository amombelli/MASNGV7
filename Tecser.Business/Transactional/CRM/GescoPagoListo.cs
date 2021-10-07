using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.CRM
{
    public struct PagoListoStruct
    {
        public bool PlistoRetirado { get; set; }
    };


    public class GescoPagoListo
    {
        public List<DsGescoPagoListo> GetAllData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from data in db.T0232_GescoPagosListos
                            join cl in db.T0006_MCLIENTES on data.idCliente equals cl.IDCLIENTE
                            orderby data.FechaPago
                            select new DsGescoPagoListo()
                            {
                                RazonSocial = cl.cli_rsocial,
                                idCliente = data.idCliente,
                                CobradorAsignado = data.CobradorAsignado,
                                DiasHorarios = data.DiasHorarios,
                                Direccion = data.Direccion,
                                FechaModificada = data.FechaModificada,
                                FechaPago = data.FechaPago,
                                LogDate = data.LogDate,
                                LogUser = data.LogUser,
                                IdRecordLastUpdate = data.IdRecordLastUpdate,
                                IdRecordPagoListo = data.IdRecordPagoListo,
                                RetiroProgramado = data.RetiroProgramado,
                                Telefono = data.Telefono,
                                PagoCancelado = data.PagoCancelado,
                                Direccion2 = data.Direccion2,
                                MensajeCobrador = data.MensajeCobrador,
                                idRecord = data.idRecord
                            };
                return query.OrderByDescending(c => c.FechaPago).ToList();
            }
        }
        public T0232_GescoPagosListos GetDataRecord(int idRecord)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0232_GescoPagosListos.SingleOrDefault(c => c.idRecord == idRecord);
            }
        }
        public T0232_GescoPagosListos GetRegistroPL(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0232_GescoPagosListos.SingleOrDefault(c => c.idCliente == idCliente);
            }
        }
        //Setea unicamente la fecha de la ultima cobranza en GESCO Header
        public static void SetFechaUltimaCobranza(int idCliente, DateTime fechaCobranza, string lx)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente) ??
                        new Gesco().CreateEmptyHeaderRecord(idCliente);

                h.UltimoPagoDate = fechaCobranza;
                db.SaveChanges();

                var h2 = db.T0202_CTACTESALDOS.SingleOrDefault(c => c.IDCLIENTE == idCliente && c.CUENTATIPO == lx);
                if (h2 == null)
                    return;
                h2.UPAGO = fechaCobranza;
                db.SaveChanges();
            }
        }
        public PagoListoStruct SetPagoRegistrado(int idCliente, int idCobranza)
        {
            var rtn = new PagoListoStruct();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                var cob = db.T0205_COBRANZA_H.SingleOrDefault(c => c.IDCOB == idCobranza);

                //Header
                rtn.PlistoRetirado =
                    h.PagoConfirmado; //puede ser que el PL no haya estado seteado => igual loguea el estado
                h.PagoConfirmado = false;
                h.FechaPagoConfirmado = null;
                h.MensajePago = null;
                h.PagoCanceladoModificado = false;
                h.UltimoPagoDate = cob.FECHA;
                //PL Table
                var pl = db.T0232_GescoPagosListos.SingleOrDefault(c => c.idCliente == idCliente);
                if (pl != null)
                    db.T0232_GescoPagosListos.Remove(pl);
                db.SaveChanges();
            }
            return rtn;
        }
    }
}
