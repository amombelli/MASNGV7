using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CRM
{
    public class Gesco
    {
        public enum DireccionMensaje
        {
            ClienteEmpresa,
            EmpresaCliente,
            Interno,
        }
        public enum MotivoContacto
        {
            ReclamoPago,
            ReconfirmaFecha,
            CancelaPago,
            ConciliaCuenta,
            CondicionPago,
            ReclamaEnvioFactura,
            Otro
        }

        //--------------------------------------------------------------------------------------

        //---------------------------------------------------------------------------------------
        public string MapDireccionToString(DireccionMensaje direccion)
        {
            switch (direccion)
            {
                case DireccionMensaje.ClienteEmpresa:
                    return "C";
                case DireccionMensaje.EmpresaCliente:
                    return "E";
                case DireccionMensaje.Interno:
                    return "I";
                default:
                    throw new ArgumentOutOfRangeException(nameof(direccion), direccion, null);
            }
        }
        public DireccionMensaje MapDireccionMensajeFromString(string direccion)
        {
            switch (direccion)
            {
                case "C":
                    return DireccionMensaje.ClienteEmpresa;
                case "E":
                    return DireccionMensaje.EmpresaCliente;
                case "I":
                    return DireccionMensaje.Interno;
                default:
                    return DireccionMensaje.Interno;
            }
        }
        public T0230_GescoHeader CreateEmptyHeaderRecord(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                if (x == null)
                {
                    var t = new T0230_GescoHeader()
                    {
                        IdCliente = idCliente,
                        RequestConciliation = false,
                        RequestCall = false,
                        ConcilitaionClienteOk = false,
                        PagoConfirmado = false,
                        PagoCanceladoModificado = false,
                    };
                    db.T0230_GescoHeader.Add(t);
                    db.SaveChanges();
                    return db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                }
                return x;
            }
        }
        public bool RequestCallInternal(int idCliente, bool setCallRequest = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                if (x == null)
                {
                    CreateEmptyHeaderRecord(idCliente);
                    x = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                }

                if (setCallRequest)
                {
                    if (x.RequestCall == false)
                    {
                        x.RequestCall = true;
                        x.RequestCallDate = DateTime.Today;
                        x.RequestCallUser = GlobalApp.AppUsername;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //El Request ya estaba seteado - no se modifica nada
                        return false;
                    }
                }
                else
                {
                    if (x.RequestCall == false)
                    {
                        //El Request ya estaba unset - no se modifica nada
                        return false;
                    }
                    else
                    {
                        x.RequestCall = false;
                        x.RequestCallDate = null;
                        x.RequestCallUser = GlobalApp.AppUsername;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
        }
        public bool RequestConciliarCuenta(int idCliente, bool setConciliarRequest = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                if (x == null)
                {
                    CreateEmptyHeaderRecord(idCliente);
                    x = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                }

                if (setConciliarRequest)
                {
                    if (x.RequestConciliation == false)
                    {
                        x.RequestConciliation = true;
                        x.RequestCallDate = DateTime.Today;
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //El Request ya estaba seteado - no se modifica nada
                        return false;
                    }
                }
                else
                {
                    if (x.RequestConciliation == false)
                    {
                        //El Request ya estaba unset - no se modifica nada
                        return false;
                    }
                    else
                    {
                        x.RequestConciliation = false;
                        x.RequestConciliationDate = null;
                        db.SaveChanges();
                        return true;
                    }
                }
            }
        }
        public int AgregarRegistro(int idCliente, DateTime fechaRecord, string nombreContacto,
            string metodoContacto, DireccionMensaje origenMensaje, string mensajeEnviadoRecibo,
            DateTime? fechaPagoConfirmado, bool pagoCancelado, string mensajeCancelacion, DateTime? fechaNextCall,
            bool cuentaConciliadaOk, bool cuentaConDiferencias, string mensajeCobradorHeader,
            MotivoContacto motivoPrincipalContacto, bool pagoModificado, DateTime? FechaPagoNuevaUpdated)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                var pagoL = db.T0232_GescoPagosListos.SingleOrDefault(c => c.idCliente == idCliente);
                bool pagoConfirmadoPrevio;
                int idRecord = 1;

                //Detectamos si hay un pago confirmado previo (modificado o no)
                pagoConfirmadoPrevio = pagoL != null;

                if (db.T0231_GescoDetail.Any())
                {
                    idRecord = db.T0231_GescoDetail.Max(c => c.IdRecord) + 1;
                }

                var rec = new T0231_GescoDetail()
                {
                    IdCliente = idCliente,
                    IdRecord = idRecord,
                    FechaRegistro = fechaRecord,
                    MedioContacto = metodoContacto,
                    TipoMensajeECI = MapDireccionToString(origenMensaje),
                    MensajeIO = mensajeEnviadoRecibo,
                    ContactoCliente = nombreContacto,

                    CanceloPago = pagoCancelado,
                    CanceloMotivo = mensajeCancelacion,
                    FechaPagoModificada = pagoModificado,

                    CuentaConDiferencias = cuentaConDiferencias,
                    CuentaConciliadaOK = cuentaConciliadaOk,
                    MotivoPrincipalContacto = (int)motivoPrincipalContacto,
                    LogDate = DateTime.Now,
                    LogUser = GlobalApp.AppUsername
                };

                if (pagoConfirmadoPrevio)
                {
                    if (pagoCancelado)
                    {
                        //habia pago confirmado y se cancelo
                        rec.CompromisoPago = false;
                        rec.FechaCompromisoPago = null;
                        rec.CanceloPago = true;
                        rec.FechaPagoModificada = false;
                    }

                    if (pagoModificado)
                    {
                        //habia pago confirmado y se modifica la fecha
                        rec.CompromisoPago = true;
                        rec.FechaCompromisoPago = FechaPagoNuevaUpdated;
                        rec.CanceloPago = false;
                        rec.FechaPagoModificada = true;
                    }
                }
                else
                {
                    //No habia fecha de Pago
                    if (fechaPagoConfirmado != null)
                    {
                        //Confirma fecha de pago
                        rec.CompromisoPago = true;
                        rec.FechaCompromisoPago = fechaPagoConfirmado;
                        rec.CanceloPago = false;
                        rec.FechaPagoModificada = false;
                    }
                }

                if (rec.ProximaLlamadaFecha.HasValue)
                {
                    //Existe una fecha agendada.- 
                    if (rec.ProximaLlamadaFecha.Value <= fechaRecord)
                    {
                        //esta llamada se corresponde con la llamada agendada
                        //Blanquea llamada agendada
                        rec.AgendoProximaLlamada = false;
                        rec.ProximaLlamadaFecha = null;
                    }
                }

                if (fechaNextCall != null)
                {
                    //si hay una fecha agendada para proxima llamada
                    //la actualiza
                    rec.ProximaLlamadaFecha = fechaNextCall;
                    rec.AgendoProximaLlamada = true;
                }
                db.T0231_GescoDetail.Add(rec);
                db.SaveChanges();


                UpdateHeader(idCliente, fechaRecord, origenMensaje, fechaPagoConfirmado, pagoCancelado, fechaNextCall,
                    cuentaConciliadaOk, cuentaConDiferencias, mensajeCobradorHeader, FechaPagoNuevaUpdated);

                if (rec.CompromisoPago && fechaPagoConfirmado.HasValue)
                {
                    AddRecordToPagosListoTable(idCliente, idRecord, fechaPagoConfirmado.Value, pagoCancelado,
                        mensajeCobradorHeader, null, null, idRecord);
                }

                if (pagoModificado || pagoCancelado)
                {
                    CancelaModificaPagoListoTable(idCliente, FechaPagoNuevaUpdated);
                }

                return idRecord;
            }
        }

        private void CancelaModificaPagoListoTable(int idCliente, DateTime? fechaModificado)
        {
            //si fechamodificado == null > pago cancelado!
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0232_GescoPagosListos.SingleOrDefault(c => c.idCliente == idCliente);
                if (x == null) return;
                if (fechaModificado == null)
                {
                    x.PagoCancelado = true;
                    x.FechaModificada = false;
                    x.RetiroProgramado = null;
                    x.CobradorAsignado = null;
                }
                else
                {
                    x.PagoCancelado = false;
                    x.FechaPago = fechaModificado.Value;
                    x.FechaModificada = true;
                }
                db.SaveChanges();
            }
        }
        public void UpdateMensajeCobradorHeader(int idCliente, string mensajeHeader)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                x.MensajePago = mensajeHeader;

                var z = db.T0232_GescoPagosListos.SingleOrDefault(c => c.idCliente == idCliente);
                if (z != null)
                {
                    z.MensajeCobrador = mensajeHeader;
                }

                db.SaveChanges();
            }
        }

        private void UpdateHeader(int idCliente, DateTime fechaRecord, DireccionMensaje origenMensaje,
            DateTime? fechaPagoConfirmado, bool pagoCancelado, DateTime? fechaNextCall, bool cuentaConciliadaOk,
            bool cuentaConDiferencias, string mensajeCobradorHeader, DateTime? fechaPagoModificada)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                Debug.Assert(header != null, nameof(header) + " != null");


                //
                if (header.RequestConciliation)
                {
                    //se marca que la cuenta esta conciliada
                    if (cuentaConciliadaOk)
                    {
                        //existia el request y se concilio la cuenta
                        //se blanquea el request de conciliacion
                        header.RequestConciliation = false;
                        header.RequestConciliationDate = null;
                    }
                    //se completa fecha concilicacion
                    //conciliacion OK
                    header.ConciliationClienteOkDate = fechaRecord;
                    header.ConcilitaionClienteOk = true;
                }
                //
                if (cuentaConDiferencias)
                {
                    //El Usuario indico que la cuenta tiene diferencias
                    if (header.RequestConciliation == false)
                    {
                        header.RequestConciliation = true;
                        header.RequestConciliationDate = fechaRecord;
                        //header.ConciliationClienteOkDate >No actulizamos fecha para que quede logueado la ultima conciliacion
                        header.ConcilitaionClienteOk = false;
                    }
                }
                //
                if (header.RequestCall)
                {
                    if (origenMensaje != DireccionMensaje.Interno)
                    {
                        //Si el origen del mensaje es Interno el RequestCall
                        //se mantiene activo - sino lo blanquea
                        header.RequestCall = false;
                        header.RequestCallDate = null;
                        header.RequestCallUser = null;
                    }
                }
                //El Pago puede estar CANCELADO - Confirmado Nuevo - Modificado - Nada
                if (pagoCancelado)
                {
                    //Cancelando Pago
                    header.PagoConfirmado = false;
                    header.FechaPagoConfirmado = null;
                    header.PagoCanceladoModificado = true;
                }
                else
                {
                    //Se esta confirmando un Pago Nuevo
                    if (fechaPagoConfirmado != null)
                    {
                        header.PagoConfirmado = true;
                        header.FechaPagoConfirmado = fechaPagoConfirmado;
                        header.PagoCanceladoModificado = false;
                    }
                    else
                    {
                        //Se esta modificando una fecha de Pago Agendada
                        if (fechaPagoModificada != null)
                        {
                            if (header.FechaPagoConfirmado.HasValue == false)
                            {
                                //Se esta modificando una fecha pero no se tenia la fecha original?
                                //Error de integridad de datos >> agenda la fecha modificada.
                                header.PagoConfirmado = true;
                                header.FechaPagoConfirmado = fechaPagoModificada;
                                header.PagoCanceladoModificado = true;
                            }
                            else
                            {
                                if (header.FechaPagoConfirmado.Value != fechaPagoModificada.Value)
                                {
                                    //la nueva fecha confirmada es diferente a la anterior
                                    header.PagoConfirmado = true;
                                    header.FechaPagoConfirmado = fechaPagoModificada;
                                    header.PagoCanceladoModificado = true;
                                }
                                else
                                {
                                    //la fecha que se esta modificando coincide con la anterior
                                    //no hace nada
                                }
                            }
                        }
                    }
                }

                //Si el Origen del Mensaje es Interno no loguea el mensaje como Ultima llamada
                if (origenMensaje != DireccionMensaje.Interno)
                {
                    header.UltimaLlamadaFecha = fechaRecord;
                    header.UltimaLlamadaUser = GlobalApp.AppUsername;
                }

                if (fechaNextCall != null)
                {
                    header.NextCall = fechaNextCall;
                }

                header.MensajePago = mensajeCobradorHeader;
                db.SaveChanges();
            }
        }

        public T0230_GescoHeader GetHeader(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == idCliente);
                if (d != null)
                    return d;
                return CreateEmptyHeaderRecord(idCliente);
            }
        }
        public List<T0231_GescoDetail> DetalleLlamadas(int idCliente)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0231_GescoDetail.Where(c => c.IdCliente == idCliente).OrderByDescending(c => c.IdRecord)
                    .ToList();
            }
        }
        public T0231_GescoDetail VerLlamada(int idCliente, int idRecord)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0231_GescoDetail.SingleOrDefault(c => c.IdCliente == idCliente && c.IdRecord == idRecord);
            }
        }
        private void AddRecordToPagosListoTable(int idCliente, int idRecord, DateTime fechaPago, bool pagoCancelado,
            string mensajeCobrador, string cobradorAsignado, DateTime? fechaRetiroProgramado, int idInterno)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0232_GescoPagosListos;

                var cliente = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == idCliente);

                var pagoListo = db.T0232_GescoPagosListos.SingleOrDefault(c => c.idCliente == idCliente);
                if (pagoListo == null)
                {
                    //No existe ningun registro de pago listo
                    var rec = new T0232_GescoPagosListos()
                    {
                        idCliente = idCliente,
                        idRecord = idRecord,
                        LogDate = DateTime.Now,
                        LogUser = GlobalApp.AppUsername,
                        Telefono = cliente.TELEFONO_COB,
                        DiasHorarios = cliente.DIA_HORARIO_COBRO,
                        Direccion = cliente.DIRECCION_COBRO_ALT,
                        Direccion2 = "",
                        FechaPago = fechaPago,
                        PagoCancelado = pagoCancelado,
                        CobradorAsignado = cobradorAsignado,
                        MensajeCobrador = mensajeCobrador,
                        RetiroProgramado = fechaRetiroProgramado,
                        FechaModificada = false,
                        IdRecordPagoListo = idInterno,
                        IdRecordLastUpdate = null,
                    };
                    db.T0232_GescoPagosListos.Add(rec);
                }
                else
                {
                    pagoListo.LogDate = DateTime.Now;
                    pagoListo.LogUser = GlobalApp.AppUsername;
                    pagoListo.Telefono = cliente.TELEFONO_COB;
                    pagoListo.DiasHorarios = cliente.DIA_HORARIO_COBRO;
                    pagoListo.Direccion = cliente.DIRECCION_COBRO_ALT;
                    pagoListo.Direccion2 = "";
                    pagoListo.PagoCancelado = pagoCancelado;
                    pagoListo.CobradorAsignado = cobradorAsignado;
                    pagoListo.MensajeCobrador = mensajeCobrador;
                    pagoListo.RetiroProgramado = fechaRetiroProgramado;
                    pagoListo.FechaModificada = true;
                    pagoListo.FechaPago = fechaPago;
                    pagoListo.IdRecordLastUpdate = idInterno;
                }
                db.SaveChanges();
            }
        }
    }
}