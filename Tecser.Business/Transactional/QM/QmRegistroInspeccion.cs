using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace Tecser.Business.Transactional.QM
{
    public class QmRegistroInspeccion
    {
        public enum TipoRecord
        {
            M,
            A,
            F
        };

        public void CreaRegistroInspeccionH(TipoRecord tipoRecord, string material, string idPlan, string lote,
            DateTime fechaLote,
            decimal kgLote, MaterialOrigenDataType.OrigenDt origen, int? id63IdPf, string vendorName = "MOMBELLI",
            string comentarioH1 = null, string docId = null, string docNumber = null)
        {
            var x = new MaterialMasterManager();
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var idRec = 1;
                if (db.T0805_QMIRecordH1.Any())
                {
                    idRec = db.T0805_QMIRecordH1.Max(c => c.IdIRec);
                    idRec++;
                }

                if (string.IsNullOrEmpty(idPlan))
                    idPlan = "NODEF";

                var data = new T0805_QMIRecordH1()
                {
                    IdIRec = idRec,
                    Material = material,
                    IdPlan = idPlan,
                    Lote = lote,
                    FechaLote = fechaLote,
                    InspeccionOK = false,
                    EstadoPlanGeneral = QmInspectionStatus.StatusIRecord.SinIniciar.ToString(),
                    LogUser = Environment.UserName,
                    LogDate = DateTime.Today,
                    ComentarioH1 = comentarioH1,
                    Origen = MaterialOrigenDataType.RetornaLetraFromDataType(origen),
                    KGTotalBatch = kgLote,
                    IdOrigen = id63IdPf,
                    IdOrigenTexto = vendorName,
                    TipoRecord = tipoRecord.ToString(),
                    DocID = docId,
                    DocNumber = docNumber
                };
                db.T0805_QMIRecordH1.Add(data);
                var st = db.SaveChanges();

                var dataH2 = new T0806_QMIRecordH2()
                {
                    ComentarioH2 = "IRecord Normal",
                    EstadoInspeccion = QmInspectionStatus.StatusIRecord.SinIniciar.ToString(),
                    IdPlan = idPlan,
                    IdRec = idRec,
                    IdCounter = 10,
                    PlanEditado = false,
                    Material = material,
                    LogUser = Environment.UserName,
                    LogDate = DateTime.Today,
                    ResponsableCQ = Environment.UserName,
                    KGInspeccion = kgLote,
                    FechaCierre = null,
                    FechaInspeccion = DateTime.Today,
                    AprobadoDudoso = false,
                    AprobadoOk = false,
                    Lote = lote + @"/1"
                };
                db.T0806_QMIRecordH2.Add(dataH2);
                var st2 = db.SaveChanges();

                var metodosPlan = db.T0802_QMMasterIPDetail.Where(c => c.IDPLAN == idPlan).ToList();
                int valorCounter = 0;
                foreach (var met in metodosPlan)
                {
                    valorCounter += 1;
                    var dataDet = new T0807QMIDetail()
                    {
                        Material = material,
                        IdPlan = idPlan,
                        IdRec = idRec,
                        IdCounterH2 = dataH2.IdCounter,
                        CQAprobado = false,
                        FechaLog = DateTime.Today,
                        UserLog = Environment.UserName,
                        MetodoAdded = false,
                        KGInspeccion = dataH2.KGInspeccion,
                        IdCounterDetail = valorCounter,
                        FechaResultado = null,
                        Resultado = QmMetodoInspeccion.Resultado.SinEvaluar.ToString(),
                        Metodo = met.METODO,
                        ComentarioDetail = met.Observacion,
                        ValorMedido = null,
                        ValorMin = met.ValorMin,
                        ValorStd = met.ValorStd,
                        ValorMax = met.ValorMax
                    };
                    db.T0807QMIDetail.Add(dataDet);
                    db.SaveChanges();
                }
            }
        }

        public void AddMetodoToInspectionRecord(int inspRecord, int idCounterH2, string metodo, bool MetodoAdded)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataH2 = db.T0806_QMIRecordH2.SingleOrDefault(c => c.IdRec == inspRecord && c.IdCounter == idCounterH2);
                var met = db.T0800_QMMetodosInspeccion.SingleOrDefault(c => c.IdMetodo == metodo);
                var metodosX = db.T0807QMIDetail.Where(c => c.IdRec == inspRecord && c.IdCounterH2 == idCounterH2)
                    .ToList();
                int valorCounter = 10;
                if (metodosX.Any())
                {
                    valorCounter = metodosX.Max(c => c.IdCounterDetail) + 10;
                }

                var dataDet = new T0807QMIDetail()
                {
                    Material = dataH2.Material,
                    IdPlan = dataH2.IdPlan,
                    IdRec = inspRecord,
                    IdCounterH2 = idCounterH2,
                    CQAprobado = false,
                    FechaLog = DateTime.Today,
                    UserLog = Environment.UserName,
                    MetodoAdded = MetodoAdded,
                    KGInspeccion = dataH2.KGInspeccion,
                    IdCounterDetail = valorCounter,
                    FechaResultado = null,
                    Resultado = QmMetodoInspeccion.Resultado.SinEvaluar.ToString(),
                    Metodo = met.IdMetodo,
                    ComentarioDetail = met.Documentacion,
                    ValorMedido = null,
                    ValorMin = null,
                    ValorStd = null,
                    ValorMax = null,

                };
                db.T0807QMIDetail.Add(dataDet);

                if (MetodoAdded)
                {
                    var h2 = db.T0806_QMIRecordH2.SingleOrDefault(c => c.IdRec == inspRecord && c.IdCounter == idCounterH2);
                    h2.PlanEditado = true;
                }
                db.SaveChanges();
            }

        }
        public int SplitRegistroH2(int idRecord, int counterOri, decimal kgNuevoRegistro, string comentarioH2 = null)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataH0 = db.T0805_QMIRecordH1.SingleOrDefault(c => c.IdIRec == idRecord);
                var dataH1 = db.T0806_QMIRecordH2.SingleOrDefault(c => c.IdRec == idRecord && c.IdCounter == counterOri);

                //En Regisro Original Actualiza KG
                if (kgNuevoRegistro == dataH1.KGInspeccion)
                {
                    dataH1.AprobadoDudoso = false;
                    dataH1.AprobadoOk = false;
                    dataH1.EstadoInspeccion = QmInspectionStatus.StatusIRecord.Cancelado.ToString();
                    dataH1.ComentarioH2 = "Cancelado/ReEvaluacion";
                }
                else
                {
                    dataH1.KGInspeccion -= kgNuevoRegistro;
                    if (string.IsNullOrEmpty(dataH1.ComentarioH2))
                    {
                        dataH1.ComentarioH2 = "IRecord Normal/Original";
                    }
                }

                //Crea Regisro nuevo con la Cantidad
                var cantH2 = db.T0806_QMIRecordH2.Where(c => c.IdRec == idRecord).ToList();
                int nuevoCounter = cantH2.Count;
                var newLote = dataH0.Lote + @"/" + (cantH2.Count + 1).ToString();

                var dataH2 = new T0806_QMIRecordH2()
                {
                    ComentarioH2 = comentarioH2,
                    EstadoInspeccion = QmInspectionStatus.StatusIRecord.SinIniciar.ToString(),
                    IdPlan = dataH1.IdPlan,
                    IdRec = dataH1.IdRec,
                    IdCounter = (cantH2.Count * 10) + 10,
                    PlanEditado = false,
                    Material = dataH1.Material,
                    LogUser = Environment.UserName,
                    LogDate = DateTime.Today,
                    ResponsableCQ = dataH1.ResponsableCQ,
                    KGInspeccion = kgNuevoRegistro,
                    FechaCierre = null,
                    FechaInspeccion = DateTime.Today,
                    AprobadoDudoso = false,
                    AprobadoOk = false,
                    Lote = newLote,
                };
                db.T0806_QMIRecordH2.Add(dataH2);
                var st2 = db.SaveChanges();

                var metodosPlan = db.T0802_QMMasterIPDetail.Where(c => c.IDPLAN == dataH2.IdPlan).ToList();
                int valorCounter = 0;
                foreach (var met in metodosPlan)
                {
                    valorCounter++;
                    var dataDet = new T0807QMIDetail()
                    {
                        Material = dataH2.Material,
                        IdPlan = dataH2.IdPlan,
                        IdRec = dataH2.IdRec,
                        IdCounterH2 = dataH2.IdCounter,
                        CQAprobado = false,
                        FechaLog = DateTime.Today,
                        UserLog = Environment.UserName,
                        MetodoAdded = false,
                        KGInspeccion = dataH2.KGInspeccion,
                        IdCounterDetail = valorCounter,
                        FechaResultado = null,
                        Resultado = QmMetodoInspeccion.Resultado.SinEvaluar.ToString(),
                        Metodo = met.METODO,
                        ComentarioDetail = met.Observacion,
                        ValorMedido = null,
                        ValorMin = met.ValorMin,
                        ValorStd = met.ValorStd,
                        ValorMax = met.ValorMax
                    };
                    db.T0807QMIDetail.Add(dataDet);
                    db.SaveChanges();
                }
                return dataH2.IdCounter;
            }
        }
        public int BuscaRecordCompra(string material, string lote)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id63 = db.T0040_MAT_MOVIMIENTOS.Where(c =>
                        c.IDMATERIAL == material && c.TIPOMOVIMIENTO == 100 && c.BATCH.ToUpper().Equals(lote.ToUpper()))
                    .ToList();

                if (id63.Count == 0)
                    return -1;

                if (id63.Count > 1)
                    return -2;

                return id63[0].IDMOVIMIENTO;



            }
        }

        /// <summary>
        /// Retorna el IDPLAN (T70) o -1 si no existe o -2 si hay mas de un record
        /// </summary>
        public int BuscaRecordFabricacion(string material, string lote)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id70 = db.T0070_PLANPRODUCCION.Where(c =>
                    c.MATERIAL == material && c.NumLote.ToUpper().Equals(lote.ToUpper())).ToList();

                if (id70.Count == 0)
                    return -1;

                if (id70.Count > 1)
                    return -2;
                return id70[0].IDPLAN;
            }
        }
        public List<QmLoteSupplierStruct> GetSupplierDataCompra(string material, string lote)
        {

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var query = from h in db.T0040_MAT_MOVIMIENTOS
                            where (h.IDMATERIAL == material && h.BATCH.ToUpper().Equals(lote.ToUpper()) &&
                                   h.TIPOMOVIMIENTO == 100)
                            join i in db.T0005_MPROVEEDORES on h.IDPRO equals i.id_prov
                            select new QmLoteSupplierStruct()
                            {
                                Material = h.IDMATERIAL,
                                Lote = h.BATCH,
                                FechaMov = h.FECHAMOV.Value,
                                Id40 = h.IDMOVIMIENTO,
                                StatusIn = h.BATCHST,
                                Supplier = i.prov_rsocial,
                                Id2 = h.XIDNUM.Value,
                                Kg = h.CANTIDAD.Value
                            };
                return query.OrderByDescending(c => c.FechaMov).ToList();

            }
        }
        public List<T0807QMIDetail> GetDetalleMetodosInInspectionRecord(int idR, int counterH2)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0807QMIDetail.Where(c => c.IdRec == idR && c.IdCounterH2 == counterH2)
                    .OrderBy(c => c.IdCounterDetail).ToList();
            }
        }
        public T0807QMIDetail GetSpecificMetodoInInspectionRecord(int idR, int counterH2, int counterDetail)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0807QMIDetail.SingleOrDefault(c => c.IdRec == idR && c.IdCounterH2 == counterH2 && c.IdCounterDetail == counterDetail);
            }
        }
        public bool ActualizaResultadoDetalleMetodo(int idR, int counterH2, int counterDetail, string resultado, string estado, bool cqOk, string responsableInspeccion, string observaciones)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var detalle = db.T0807QMIDetail.SingleOrDefault(c =>
                    c.IdRec == idR && c.IdCounterH2 == counterH2 && c.IdCounterDetail == counterDetail);

                detalle.ValorMedido = resultado;
                detalle.FechaResultado = DateTime.Today;
                detalle.Resultado = estado;
                detalle.CQAprobado = cqOk;
                detalle.UserLog = responsableInspeccion;
                detalle.ComentarioDetail = observaciones;

                return db.SaveChanges() > 0;
            }
        }

        public void DeleteMetodoFromInspectionRecord(int idR, int counterH2, int counterDetail)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var detalle = db.T0807QMIDetail.SingleOrDefault(c =>
                    c.IdRec == idR && c.IdCounterH2 == counterH2 && c.IdCounterDetail == counterDetail);

                db.T0807QMIDetail.Remove(detalle);

                var h2 = db.T0806_QMIRecordH2.SingleOrDefault(c => c.IdRec == idR && c.IdCounter == counterH2);
                h2.PlanEditado = true;
                db.SaveChanges();
            }
        }


        public void UpdateValorMinimoManual(int idR, int counterH2, int counterDetail, string valor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var detalle = db.T0807QMIDetail.SingleOrDefault(c =>
                    c.IdRec == idR && c.IdCounterH2 == counterH2 && c.IdCounterDetail == counterDetail);
                detalle.ValorMin = valor;
                db.SaveChanges();
            }
        }
        public void UpdateValorMaximoManual(int idR, int counterH2, int counterDetail, string valor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var detalle = db.T0807QMIDetail.SingleOrDefault(c =>
                    c.IdRec == idR && c.IdCounterH2 == counterH2 && c.IdCounterDetail == counterDetail);
                detalle.ValorMax = valor;
                db.SaveChanges();
            }
        }
        public void UpdateValorStandardManual(int idR, int counterH2, int counterDetail, string valor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var detalle = db.T0807QMIDetail.SingleOrDefault(c =>
                    c.IdRec == idR && c.IdCounterH2 == counterH2 && c.IdCounterDetail == counterDetail);
                detalle.ValorStd = valor;
                db.SaveChanges();
            }
        }




        public QmInspectionStatus.StatusIRecord AutoEvaluate(int idR, int counterH2)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                bool noTerminado = false;
                int noTerminadoCounter = 0;
                bool aprobado = true;

                var detalle = db.T0807QMIDetail.Where(c => c.IdRec == idR && c.IdCounterH2 == counterH2).ToList();
                foreach (var det in detalle)
                {
                    var resultadoMedicion = QmMasterIplan.MapTipoDatoFromText(det.Resultado);
                    if (resultadoMedicion == QmMasterIplan.StatusMedicion.Indeterminado)
                    {
                        noTerminado = true;
                        noTerminadoCounter++;
                    }

                    if (resultadoMedicion == QmMasterIplan.StatusMedicion.NoAprobado)
                    {
                        aprobado = false;
                    }
                }

                if (noTerminadoCounter == detalle.Count)
                    return QmInspectionStatus.StatusIRecord.SinIniciar;

                if (noTerminado)
                    return QmInspectionStatus.StatusIRecord.Comenzado;

                if (aprobado)
                    return QmInspectionStatus.StatusIRecord.Aprobado;

                if (!aprobado)
                    return QmInspectionStatus.StatusIRecord.Rechazado;

                return QmInspectionStatus.StatusIRecord.SinIniciar;
            }
        }
    }
}
