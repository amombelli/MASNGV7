using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI.Cobranza
{
    public class CobranzaTemporalManager
    {
        public enum StatusCobranzaTemporal
        {
            Inicial,
            Ingresada,
            Convertida,
            Cancelada
        }

        public int SaveNewHeader(int idCliente, string tipoLx, decimal importeRecibo, string numeroReciboProvisorio,
            DateTime fechaRecibo, string userIngreso, string cobrador, decimal tipoCambio, string moneda = "ARS",
            string comentario = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = new T1205_CobranzaConvertirHeader
                {
                    LX = tipoLx,
                    idCliente = idCliente,
                    NumeroReciboProvisorio = numeroReciboProvisorio,
                    Moneda = moneda,
                    FechaIngreso = fechaRecibo,
                    StatusRecibo = StatusCobranzaTemporal.Ingresada.ToString(),
                    ImporteRecibo = importeRecibo,
                    NumeroReciboInterno = null,
                    UserIngreso = userIngreso,
                    Observaciones = comentario,
                    Cobrador = cobrador,
                    Tc = tipoCambio,
                    ClienteRazonSocial = new CustomerManager().GetCustomerBillToData(idCliente).cli_rsocial,
                    idCobTemp = GetNewCobranzaId(),
                };

                db.T1205_CobranzaConvertirHeader.Add(data);
                return db.SaveChanges() > 0 ? data.idCobTemp : 0;
            }
        }
        public int SaveItems(int idCobTemporal, List<T1206_CobranzaConvertirItems> items)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                foreach (var i in items)
                {
                    i.idCobTem = idCobTemporal;
                }
                db.T1206_CobranzaConvertirItems.AddRange(items);
                return db.SaveChanges();
            }
        }
        private int GetNewCobranzaId()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (db.T1205_CobranzaConvertirHeader.Any())
                {
                    return db.T1205_CobranzaConvertirHeader.Max(c => c.idCobTemp) + 1;
                }
                else
                {
                    return 1;
                }

            }
        }

        public List<T1205_CobranzaConvertirHeader> GetListado(StatusCobranzaTemporal? status = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (status == null)
                {
                    return db.T1205_CobranzaConvertirHeader.OrderByDescending(c => c.idCobTemp)
                            .ToList();
                }
                else
                {
                    return
                        db.T1205_CobranzaConvertirHeader.Where(c => c.StatusRecibo == status.ToString())
                            .OrderByDescending(c => c.idCobTemp)
                            .ToList();
                }

            }
        }

        public T1205_CobranzaConvertirHeader GetSpecificHeader(int idCobTemporal)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T1205_CobranzaConvertirHeader.SingleOrDefault(c => c.idCobTemp == idCobTemporal);
            }
        }

        public List<T1206_CobranzaConvertirItems> GetItemsCobranzaTemporal(int idCobTemporal)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T1206_CobranzaConvertirItems.Where(c => c.idCobTem == idCobTemporal).ToList();
            }
        }


        public void UpdateTemporalAfterCobranzaIn(int idCobTemp, int idCobranza, string numeroRecibointerno)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T1205_CobranzaConvertirHeader.SingleOrDefault(c => c.idCobTemp == idCobTemp);
                data.idCobReal = idCobranza;
                data.StatusRecibo = StatusCobranzaTemporal.Convertida.ToString();
                data.ConvertidoFecha = DateTime.Now;
                data.ConvertidoUser = Environment.UserName;
                data.NumeroReciboInterno = numeroRecibointerno;
                db.SaveChanges();
            }
        }
    }
}
