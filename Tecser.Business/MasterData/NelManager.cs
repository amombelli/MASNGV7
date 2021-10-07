using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData
{
    public class NelManager
    {
        public enum Status
        {
            Inicial,
            Ingresado,
            Proceso,
            CodigoProv,
            Waiting,
            Cancelado,
            Rechazado,
            Aprobado,
            Finalizado
        }

        private readonly List<string> _statusList = new List<string>();
        public enum TipoCodigo
        {
            Provisorio,
            Definitivo
        }
        public static Status MapTextToStatus(string status)
        {
            if (String.IsNullOrEmpty(status))
                return Status.Inicial;
            if (status.ToUpper().Equals("") || status.ToUpper().Equals(""))
                return Status.Inicial;
            try
            {
                return (Status)Enum.Parse(typeof(Status), status, true);
            }
            catch (Exception)
            {
                return Status.Inicial;
                throw;
            }
        }
        public static bool GetIfNelExist(int nel)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0099_NELS.SingleOrDefault(c => c.NEL == nel);
                return x != null;
            }
        }
        public static int GetNextNel()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (db.T0099_NELS.ToList().Count == 0)
                    return 1;
                return db.T0099_NELS.Max(c => c.NEL) + 1;
            }
        }
        public bool SaveUpdateNelData(T0099_NELS data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var neldb = db.T0099_NELS.SingleOrDefault(c => c.NEL == data.NEL);
                if (neldb == null)
                {
                    db.T0099_NELS.Add(data);
                    return db.SaveChanges() > 0;
                }
                else
                {

                    if (data.Foto1 == null)
                        data.Foto1 = neldb.Foto1;

                    if (data.Foto2 == null)
                        data.Foto2 = neldb.Foto2;
                    db.Entry(neldb).CurrentValues.SetValues(data);
                    return db.SaveChanges() > 0;
                }
            }
        }
        public T0099_NELS GetData(int nel)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0099_NELS.SingleOrDefault(c => c.NEL == nel);
            }
        }
        public List<T0099_NELS> GetNelList()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0099_NELS.OrderByDescending(c => c.NEL).ToList();
            }
        }
        public List<T0099_NELS> GetDataList(int nel)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0099_NELS.Where(c => c.NEL == nel).ToList();
            }
        }
        public static void UpdateEstado(int nel, NelManager.Status estado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0099_NELS.SingleOrDefault(c => c.NEL == nel);
                data.EstadoDesarrollo = estado.ToString();
                db.SaveChanges();
            }
        }
        public static void SetEstadoFinalizado(int nel, string aprobadoPor, string codigoAsignado, DateTime fechaAprobacion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0099_NELS.SingleOrDefault(c => c.NEL == nel);
                data.EstadoDesarrollo = NelManager.Status.Finalizado.ToString();
                data.AprobadoPor = aprobadoPor;
                data.CodigoDefinitivo = codigoAsignado;
                data.FechaAprobacionCliente = fechaAprobacion;
                db.SaveChanges();
            }
        }
        public int SetNelProgress(int nel, NelManager.Status estado, string mensaje, string codigoAsignado = null,
            int? secuencia = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (secuencia == null)
                {
                    var data = new T0099_NELUPDATE()
                    {
                        NEL = nel,
                        Estado = estado.ToString(),
                        UserUpdate = GlobalApp.AppUsername,
                        FechaUpdate = DateTime.Now,
                        ComentarioAvance = mensaje,
                        NELSEQ = GetNextSecuencia(nel)
                    };
                    db.T0099_NELUPDATE.Add(data);
                    db.SaveChanges();
                    return data.NELSEQ;
                }
                else
                {
                    var data0 = db.T0099_NELUPDATE.SingleOrDefault(c => c.NEL == nel && c.NELSEQ == secuencia);
                    if (data0 == null)
                        return 0;

                    data0.Estado = estado.ToString();
                    data0.ComentarioAvance = mensaje;
                    data0.FechaUpdate = DateTime.Now;
                    data0.UserUpdate = GlobalApp.AppUsername;
                    db.SaveChanges();
                    return data0.NELSEQ;
                }
            }
        }
        private int GetNextSecuencia(int nel)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0099_NELUPDATE.Where(c => c.NEL == nel).ToList();
                return x.Count + 1;
            }
        }
        public List<T0099_NELUPDATE> GetListOfUpdate(int nel)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0099_NELUPDATE.Where(c => c.NEL == nel).ToList();
            }
        }
        public T0099_NELUPDATE GetUpdateData(int nel, int seq)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0099_NELUPDATE.SingleOrDefault(c => c.NEL == nel && c.NELSEQ == seq);
            }
        }
        private List<string> CompletaStatusList(bool[] ckstatus)
        {
            _statusList.Clear();
            for (int i = 0; i < ckstatus.Length; i++)
            {
                if (ckstatus[i])
                {
                    switch (i + 1)
                    {
                        case 1:
                            _statusList.Add(Status.Ingresado.ToString());
                            break;
                        case 2:
                            _statusList.Add(Status.Proceso.ToString());
                            break;
                        case 3:
                            _statusList.Add(Status.CodigoProv.ToString());
                            break;
                        case 4:
                            _statusList.Add(Status.Waiting.ToString());
                            break;
                        case 5:
                            _statusList.Add(Status.Aprobado.ToString());
                            break;
                        case 6:
                            _statusList.Add(Status.Rechazado.ToString());
                            break;
                        case 7:
                            _statusList.Add(Status.Cancelado.ToString());
                            break;
                        case 8:
                            _statusList.Add(Status.Finalizado.ToString());
                            break;
                        default:
                            _statusList.Add("");
                            break;
                    }
                }

            }
            return _statusList;
        }
        public List<T0099_NELS> GetListSegunEstado(bool[] ckstatus, int top = 100)
        {
            var statusList = new NelManager().CompletaStatusList(ckstatus);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataX = (from nel in db.T0099_NELS
                             where statusList.Contains(nel.EstadoDesarrollo)
                             orderby nel.NEL descending
                             select nel).Take(top).ToList();
                return dataX;
            }
        }
        public T0099_NELS GetInfoFromCodigoDefinitivo(string codigoDef)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0099_NELS.SingleOrDefault(c => c.CodigoDefinitivo.ToUpper().Equals(codigoDef.ToUpper()));
                return x ?? null;
            }
        }
    }
}
