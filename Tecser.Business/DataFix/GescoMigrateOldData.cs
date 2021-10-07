using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class GescoMigrateOldData
    {
        public void FixMigrateDate()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var zx0 = db.T0230_GescoHeader.Where(c => c.PagoConfirmado).ToList();
                DateTime otraFecha = DateTime.Today.AddDays(-40);
                var dataDetail = db.T0231_GescoDetail.Where(c => c.CompromisoPago && c.PagoIngresado == null && c.FechaCompromisoPago.Value > otraFecha).ToList();

                //SELECT * FROM T0231_GescoDetail WHERE CompromisoPago='True' and PagoIngresado is null and FechaCompromisoPago > convert(datetime,'2020-03-01') ORDER BY IdRecord DESC

                foreach (var item in zx0)
                {
                    var z1 = db.T0231_GescoDetail.Where(c =>
                        c.IdCliente == item.IdCliente && c.CompromisoPago == true && c.PagoIngresado == null).ToList();

                    var zlistz = new T0231_GescoDetail();

                    if (z1.Count > 1)
                    {
                        zlistz = z1.SingleOrDefault(c => c.FechaCompromisoPago > otraFecha);
                    }
                    else
                    {
                        zlistz = z1[0];
                    }



                    var cust1 = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == item.IdCliente);

                    var pl = new T0232_GescoPagosListos()
                    {
                        idCliente = item.IdCliente,
                        CobradorAsignado = null,
                        DiasHorarios = cust1.DIA_HORARIO_COBRO,
                        Direccion = cust1.DIRECCION_COBRO_ALT,
                        Direccion2 = null,
                        FechaModificada = false,
                        FechaPago = item.FechaPagoConfirmado.Value,
                        LogUser = item.UltimaLlamadaUser, //lo completamos desde recorrido items
                        LogDate = DateTime.Now, //lo actulizare desde recorrido items
                        PagoCancelado = false,
                        Telefono = cust1.TELEFONO_COB,
                        RetiroProgramado = null,
                        MensajeCobrador = item.MensajePago,
                        idRecord = zlistz.IdRecord,
                        IdRecordPagoListo = zlistz.IdRecord,
                        IdRecordLastUpdate = null,
                    };

                    db.T0232_GescoPagosListos.Add(pl);
                    db.SaveChanges();



                }



                foreach (var ipl in zx0)
                {
                    //agrega record in tabla pagos
                    {
                        var cust = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == ipl.IdCliente);
                        var xxc = db.T0231_GescoDetail
                            .Where(c => c.IdCliente == ipl.IdCliente && c.CompromisoPago == true)
                            .OrderBy(c => c.IdRecord).ToList();

                        int irecordz = 1;
                        var pl = new T0232_GescoPagosListos()
                        {
                            idCliente = ipl.IdCliente,
                            CobradorAsignado = null,
                            DiasHorarios = cust.DIA_HORARIO_COBRO,
                            Direccion = cust.DIRECCION_COBRO_ALT,
                            Direccion2 = null,
                            FechaModificada = false,
                            FechaPago = ipl.FechaPagoConfirmado.Value,
                            LogUser = ipl.UltimaLlamadaUser, //lo completamos desde recorrido items
                            LogDate = DateTime.Now, //lo actulizare desde recorrido items
                            PagoCancelado = false,
                            Telefono = cust.TELEFONO_COB,
                            RetiroProgramado = null,
                            MensajeCobrador = ipl.MensajePago,
                            idRecord = xxc[0].IdRecord,
                            IdRecordPagoListo = xxc[0].IdRecord,
                            IdRecordLastUpdate = null,
                        };
                        irecordz++;
                        db.T0232_GescoPagosListos.Add(pl);
                        db.SaveChanges();
                        ipl.MensajeInterno = null;
                        ipl.RequestConciliation = false;
                        db.SaveChanges();
                    }
                }
            }

            ;
        }


        public void MigraData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                ////Crea Headers
                //var hold = db.TAUX_G3.OrderByDescending(c => c.ULTIMALL).ToList();
                //int irec = 1;
#pragma warning disable CS0219 // La variable 'conta' está asignada pero su valor nunca se usa
                int conta = 1;
#pragma warning restore CS0219 // La variable 'conta' está asignada pero su valor nunca se usa
                //foreach (var itemHeader in hold)
                //{
                //    var hnew = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == itemHeader.IDCLI);
                //    if (hnew == null)
                //    {
                //        //crea header
                //        var cust = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == itemHeader.IDCLI);
                //        if (cust == null)
                //        {
                //            MessageBox.Show($@"El Cliente {itemHeader.IDCLI} no Existe");
                //        }
                //        else
                //        {
                //            var h = new T0230_GescoHeader()
                //            {
                //                IdCliente = itemHeader.IDCLI,
                //                FechaPagoConfirmado = itemHeader.PasarACobrarFecha,
                //                NextCall = itemHeader.LlamarNuevo,

                //                MensajePago = itemHeader.MSGCOBRAR,
                //                ConciliationClienteOkDate = null,
                //                ConcilitaionClienteOk = false,
                //                PagoCanceladoModificado = false,
                //                MensajeInterno = null,
                //                RequestConciliation = false,
                //                RequestConciliationDate = null,
                //                RequestCall = false,
                //                RequestCallUser = null,
                //                RequestCallDate = null,
                //                UltimaLlamadaUser = null, //lo actualizare desde el recorrido de items
                //                UltimaLlamadaFecha = null,
                //            };
                //            if (itemHeader.PasarACobrarFecha.HasValue)
                //            {
                //                h.PagoConfirmado = true;
                //            }

                //            db.T0230_GescoHeader.Add(h);
                //            db.SaveChanges();
                //            //finalizamos los headers
                //        }
                //    }
                //}

                //var r0 = db.TAUX_G2.Where(c=>c.IDR <1489).OrderByDescending(c => c.IDR).ToList();
                //var isHeaderNew = false;
                //int irec = 29201; //20601
                //foreach (var item in r0)
                //{
                //    var head = db.T0230_GescoHeader.SingleOrDefault(c => c.IdCliente == item.IDCLI);
                //    if (head.UltimaLlamadaFecha == null)
                //    {
                //        head.UltimaLlamadaFecha = item.FECHA.Value;
                //        head.UltimaLlamadaUser = item.LOG_USER;
                //        isHeaderNew = true;
                //    }
                //    else
                //    {
                //        isHeaderNew = false;
                //    }
                //    var ix = new T0231_GescoDetail()
                //    {
                //        IdCliente = item.IDCLI,
                //        IdRecord = irec,
                //        CanceloMotivo = null,
                //        CanceloPago = false,
                //        CuentaConDiferencias = false,
                //        CuentaConciliadaOK = false,
                //        MedioContacto = "TELEFONO",
                //        MotivoPrincipalContacto = 0,
                //        PagoIngresado = null,
                //        FechaRegistro = item.FECHA.Value,
                //        ContactoCliente = null,
                //        LogDate = item.LOG_DATE.Value,
                //        LogUser = item.LOG_USER,
                //        MensajeIO = item.MENSAJE,
                //        TipoMensajeECI = "E",
                //        //de aca en adelante se actuliza segun registro
                //        FechaPagoModificada = false,
                //        PagoIngresadoId = null,
                //        CompromisoPago = false,
                //        AgendoProximaLlamada = false,
                //        ProximaLlamadaFecha = null,
                //        FechaCompromisoPago = null,
                //    };

                //    if (item.CONTACTO == null)
                //    {
                //        ix.ContactoCliente = null;
                //    }
                //    else
                //    {
                //        if (item.CONTACTO.Length >= 20)
                //        {
                //            ix.ContactoCliente = item.CONTACTO.Substring(0, 19);
                //        }
                //        else
                //        {
                //            ix.ContactoCliente = item.CONTACTO;
                //        }
                //    }

                //    if (item.PAGOLISTO)
                //    {
                //        ix.FechaCompromisoPago = item.PAGOLISTADATE;
                //        ix.CompromisoPago = true;
                //        if (!head.RequestConciliation)
                //        {
                //            head.RequestConciliation = true; //flag
                //            head.MensajeInterno = item.IDR.ToString(); //para agendar el IDR;
                //        }
                //    }

                //    if (item.LLAMARN.HasValue)
                //    {
                //        ix.ProximaLlamadaFecha = item.LLAMARN.Value;
                //        ix.AgendoProximaLlamada = true;
                //        if (!head.RequestCall)
                //        {
                //            //uso este flag para agendo proxima llamada
                //            head.RequestCall = true; //al final pasarlo a false!
                //            head.NextCall = item.LLAMARN;
                //        }
                //    }
                //    db.T0231_GescoDetail.Add(ix);
                //    if (conta == 200)
                //    {
                //        db.SaveChanges();
                //        conta = 0;
                //    }
                //    conta++;
                //    irec++;
                //};
                //db.SaveChanges();
                //
                MessageBox.Show(@"Finalizada la creacion de headers", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                var zx0 = db.T0230_GescoHeader.Where(c => c.PagoConfirmado).ToList();
                foreach (var ipl in zx0)
                {
                    //agrega record in tabla pagos
                    {
                        var cust = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == ipl.IdCliente);
                        var xxc = db.T0231_GescoDetail
                            .Where(c => c.IdCliente == ipl.IdCliente && c.CompromisoPago == true)
                            .OrderBy(c => c.IdRecord).ToList();

                        int irecordz = 1;
                        var pl = new T0232_GescoPagosListos()
                        {
                            idCliente = ipl.IdCliente,
                            CobradorAsignado = null,
                            DiasHorarios = cust.DIA_HORARIO_COBRO,
                            Direccion = cust.DIRECCION_COBRO_ALT,
                            Direccion2 = null,
                            FechaModificada = false,
                            FechaPago = ipl.FechaPagoConfirmado.Value,
                            LogUser = ipl.UltimaLlamadaUser, //lo completamos desde recorrido items
                            LogDate = DateTime.Now, //lo actulizare desde recorrido items
                            PagoCancelado = false,
                            Telefono = cust.TELEFONO_COB,
                            RetiroProgramado = null,
                            MensajeCobrador = ipl.MensajePago,
                            idRecord = xxc[0].IdRecord,
                            IdRecordPagoListo = xxc[0].IdRecord,
                            IdRecordLastUpdate = null,
                        };
                        irecordz++;
                        db.T0232_GescoPagosListos.Add(pl);
                        db.SaveChanges();
                        ipl.MensajeInterno = null;
                        ipl.RequestConciliation = false;
                        db.SaveChanges();
                    }
                };
            }
            /*
             *    var zx0 = db.T0230_GescoHeader.Where(c => c.PagoConfirmado).ToList();
                foreach (var ipl in   zx0)
                {
                    //agrega record in tabla pagos
                    {
                        var cust = db.T0006_MCLIENTES.SingleOrDefault(c => c.IDCLIENTE == ipl.IdCliente);
                        var pl = new T0232_GescoPagosListos()
                        {
                            idCliente = ipl.IdCliente,
                            CobradorAsignado = null,
                            DiasHorarios = cust.DIA_HORARIO_COBRO,
                            Direccion = cust.DIRECCION_COBRO_ALT,
                            Direccion2 = null,
                            FechaModificada = false,
                            FechaPago = ipl.FechaPagoConfirmado.Value,
                            LogUser = "", //lo completamos desde recorrido items
                            LogDate = DateTime.Now, //lo actulizare desde recorrido items
                            PagoCancelado = false,
                            Telefono = cust.TELEFONO_COB,
                            RetiroProgramado = null,
                            MensajeCobrador = ipl.MensajePago,
                            idRecord = irec,
                            IdRecordPagoListo = Convert.ToInt32(ipl.MensajeInterno),
                            IdRecordLastUpdate = null
                        };
                        db.T0232_GescoPagosListos.Add(pl);
                        ipl.MensajeInterno = null;
                        ipl.RequestConciliation = false;
                        db.SaveChanges();
                    }
                    irec++;
                } ;
             */
        }
    }
}
