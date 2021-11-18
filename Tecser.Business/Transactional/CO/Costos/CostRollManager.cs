using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.Costos
{
    public class CostRollManager
    {
        //creacion de nuevo GUID
        public Guid NewHeader(string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id = Guid.NewGuid();

                //Desactiva la version Activa. Crea un nuevo header y lo setea en Activo
                var versionActiva = db.T0034_CostRollHeader.Where(c => c.VersionActiva).ToList();
                foreach (var va in versionActiva)
                {
                    va.VersionActiva = false;
                }
                var data = new T0034_CostRollHeader()
                {
                    idCostRoll = id,
                    VersionActiva = true,
                    FechaCostRoll = DateTime.Now,
                    UserRun = GlobalApp.AppUsername,
                    Machinerun = Environment.MachineName,
                    Comentario = comentario,
                    RunTimeCompras = 0,
                    RunTimeFabricado = 0,
                    RunTimeExplosion = 0,
                    UpdCompras = false,
                    UpdFabricado = false,
                    MPFinalizado = false,
                    PTFinalizado = false,
                    Temporal = true
                };
                db.T0034_CostRollHeader.Add(data);
                db.SaveChanges();

                //si se va a permitir almacenar mas de un CR temporal borrar por GUID y cambiar PK de la tabla
                db.Database.ExecuteSqlCommand("DELETE FROM T0035_CostRoll");
                CreaEstructuraNuevaT0035(id);
                PegaCostosMP_T0035();
                PegaCostosStd_T0035StdOld();

                return id;
            }
        }
        /// <summary>
        /// Elimina todos los datos de T0035 y Genera estructura nueva T0035 con todos los materiales que soportan cost-management
        /// </summary>
        public bool CreaEstructuraNuevaT0035(Guid guidId, bool onlyActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == guidId);
                if (header == null)
                {
                    return false;
                }

                decimal MaxCost = GlobalApp.MaxCosto;
                string user = GlobalApp.AppUsername;
                var fechaCostRoll = header.FechaCostRoll;
                var fechaAdded = DateTime.Now;

                db.Database.ExecuteSqlCommand("DELETE FROM T0035_CostRoll");

                //Alta Datos --> Estructura T0035 (Materiales Activos y que por tipo tienen controlCosto = true)
                var sqlnew =
                    "INSERT INTO T0035_CostRoll ( Material, MType, MOrigen, FCost, MonedaCosto, CostoRepoUsd, CostRepoDate, CostoCR, CostoCRDate, RecordAddedOn, RecordAddedBy, CostRollDate, ManualUpdated, CostRollId,CostoStandardOld) " +
                    "SELECT T0010_MATERIALES.IDMATERIAL, T0010_MATERIALES.TIPO_MATERIAL, T0010_MATERIALES.ORIGEN, T0010_MATERIALES.FORM_COSTO, T0010_MATERIALES.MonedaCosto, {0}, 1 / 1 / 1900 AS zCostoRepoDate,{0}, 1 / 1 / 1900 AS zCostoStdDate, {4}, {1}, {3}, 0 AS zManualUpdate, {2},{0} " +
                    "FROM T0010_MATERIALES INNER JOIN T0011_MaterialType ON T0010_MATERIALES.TIPO_MATERIAL = T0011_MaterialType.Mtype " +
                    "WHERE (T0010_MATERIALES.ACTIVO = 1 AND T0011_MaterialType.ControlCosto= 1)";
                db.Database.ExecuteSqlCommand(sqlnew, MaxCost, user, guidId, fechaCostRoll, fechaAdded);
                return true;
            }
        }
        /// <summary>
        /// revisado 2021.06.01
        /// Pega costo en T0035 desde T0036
        /// CostoRepoUSD = CostoUC
        /// CostoCR = CostoUC
        /// </summary>
        public void PegaCostosMP_T0035()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var sqlPegaCostoMP =
                    " UPDATE T0035_CostRoll SET " +
                    " T0035_costRoll.CostoRepoUsd = T0036_CostoReposicion.[CostoUCUsd]," +
                    " T0035_CostRoll.MonedaCosto = 'USD'," +
                    " T0035_CostRoll.CostRepoDate = T0036_CostoReposicion.[FechaUC], " +
                    " T0035_CostRoll.CostoCR = T0036_CostoReposicion.[CostoUCUsd] " +
                    " from T0035_CostRoll INNER JOIN T0036_CostoReposicion ON T0035_CostRoll.Material = T0036_CostoReposicion.Material";
                db.Database.ExecuteSqlCommand(sqlPegaCostoMP);
            }
        }
        /// <summary>
        /// Pega Costo STD de T0039 en T0035--> CostoStandardOld
        /// </summary>
        public void PegaCostosStd_T0035StdOld()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Pega costo standard--> costo standard old
                var sqlPegaCostoStd =
                    " UPDATE T0035_CostRoll SET " +
                    " T0035_costRoll.CostoStandardOld = T0039_CostoStandard.[CostoUsd]" +
                    //" T0035_CostRoll.CostStdDate  = T0039_CostoStandard.[FechaCosto] " +
                    " from T0035_CostRoll INNER JOIN T0039_CostoStandard ON T0035_CostRoll.Material = T0039_CostoStandard.Material";
                db.Database.ExecuteSqlCommand(sqlPegaCostoStd);
            }
        }
        public void UpdateCrCostManual(string material, decimal costo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0035_CostRoll.SingleOrDefault(c => c.Material == material);
                if (d.CostoRepoUsd != costo)
                {
                    d.CostoCR = costo;
                    d.CostoCRDate = DateTime.Now;
                    d.ManualUpdated = true;
                    db.SaveChanges();
                }
            }
        }

        public bool CheckComentarioExiste(string comentario)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0034_CostRollHeader.Where(c => c.Comentario == comentario);
                return x.Any();
            }
        }

        public void SetStandardMassive()
        {
            var tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Da de Alta todos los materiales de CR que no estan en STD Table
                var sqlStdToStdOld =
                    "INSERT INTO T0039_CostoStandard ( Material, Origen, MType, MonedaCosto, CostDetBy, FechaCosto,CostoUsd, CostoUsdOld, VarCostoUsd,DeltaUsd1,DeltaUsd2,CostoArs,CostoArsOld,VarCostoArs,FechaCostoOld,FechaCostRoll)" +
                    " SELECT T0035_CostRoll.Material, T0035_CostRoll.MOrigen, T0035_CostRoll.MType, 'USD','CR', T0035_CostRoll.CostRepoDate,T0035_CostRoll.CostoRepoUsd,999999,0,0,0,9999,9999,0,T0035_CostRoll.CostRepoDate,T0035_CostRoll.CostRollDate" +
                    " FROM T0035_CostRoll LEFT JOIN T0039_CostoStandard ON T0035_CostRoll.Material = T0039_CostoStandard.Material " +
                    " WHERE T0039_CostoStandard.Material Is Null; ";
                db.Database.ExecuteSqlCommand(sqlStdToStdOld);

                //Rota los costos
                var rotoCostos =
                    "UPDATE T0039_CostoStandard SET DeltaUsd2 = DeltaUsd1, CostoUsdOld =CostoUsd, CostoArsOld = CostoArsOld, FechaCostoOld = FechaCosto";
                db.Database.ExecuteSqlCommand(rotoCostos);

                //Actualiza Standard desde CR
                var updStd =
                    "UPDATE T0039_CostoStandard SET " +
                    "CostoUsd = T0035_CostRoll.CostoCR," +
                    "CostoArs = T0035_CostRoll.CostoCR/{2}," +
                    " UpdatedBy = {0}," +
                    " UpdatedOn = {1}," +
                    " ManualUpdated = T0035_CostRoll.ManualUpdated," +
                    " FechaCostRoll = T0035_CostRoll.CostRollDate" +
                    " from T0035_CostRoll LEFT JOIN T0039_CostoStandard ON T0035_CostRoll.Material = T0039_CostoStandard.Material";
                db.Database.ExecuteSqlCommand(updStd, GlobalApp.AppUsername, DateTime.Now, tc);

                var fixCostoCero = "UPDATE T0039_CostoStandard SET CostoUsd = 999999 WHERE CostoUsd=0";
                var CalculaDeltas = "UPDATE T0039_CostoStandard SET VarCostoUsd = (CostoUsd - CostoUsdOld), VarCostoArs =(CostoArs- CostoArsOld), DeltaUsd1 = (VarCostoUsd/CostoUsd)";
                db.Database.ExecuteSqlCommand(fixCostoCero);
                db.Database.ExecuteSqlCommand(CalculaDeltas);
                var h = GetCostRollHeaderActivo();
                h.StandardSet = true;
                db.SaveChanges();
            }
        }
        public T0035_CostRoll GetRegistroCostRoll(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0035_CostRoll.SingleOrDefault(c => c.Material == material);
            }
        }

        //Reemplaza el CostoUnitarioSTD por Costo Repo
        public void PegaCostosRepo_T0035CostoStd()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var sqlPegaCostoMP =
                    " UPDATE T0035_CostRoll SET " +
                    " T0035_costRoll.CostoCR = T0036_CostoReposicion.[CostoUCUsd]" +
                    " from T0035_CostRoll INNER JOIN T0036_CostoReposicion ON T0035_CostRoll.Material = T0036_CostoReposicion.Material";
                db.Database.ExecuteSqlCommand(sqlPegaCostoMP);
            }
        }
        public bool SetRevisionMPFinalizada(Guid guidId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == guidId);
                if (header == null)
                {
                    return false;
                }
                header.MPFinalizado = true;
                db.SaveChanges();
                return true;
            }
        }
        public bool SetRevisionMPOpen(Guid guidId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var header = db.T0034_CostRollHeader.SingleOrDefault(c => c.idCostRoll == guidId);
                if (header == null)
                {
                    return false;
                }
                header.MPFinalizado = false;
                db.SaveChanges();
                return true;
            }
        }
        public void AddRecordT0035(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matx = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                if (matx == null)
                    return;

                var versionActiva = db.T0034_CostRollHeader.Where(c => c.VersionActiva).ToList();
                if (versionActiva.Count != 1)
                    return;

                var m1 = db.T0035_CostRoll.SingleOrDefault(c => c.Material == material);
                if (m1 != null)
                    return;

                var r0 = new T0035_CostRoll
                {
                    Material = material,
                    CostoRepoUsd = (decimal)999999,
                    CostoStandardOld = (decimal)999999,
                    CostoCR = (decimal)999999,
                    CostoCRDate = DateTime.Now.AddYears(-5),
                    CostRepoDate = DateTime.Now.AddYears(-5),
                    MonedaCosto = "USD",
                    FCost = matx.FORM_COSTO ?? -1,
                    MOrigen = matx.ORIGEN,
                    MaterialComplex = 100,
                    MType = matx.TIPO_MATERIAL,
                    CostRollId = versionActiva[0].idCostRoll,
                    CostRollDate = DateTime.Today,
                    RecordAddedOn = DateTime.Now,
                    RecordAddedBy = GlobalApp.AppUsername,
                    ManualUpdated = false,
                    UpdatedAfterCR = false,
                };

                if (matx.ORIGEN == "FAB" && matx.FORM_COSTO != null)
                {
                    //es un material fabricado con FCOST se intenta costear en el momento
                    var mfg = new ACostoMfgNowUc(material);
                    r0.CostoRepoUsd = mfg.ValorUSD;
                    r0.CostoCR = mfg.ValorUSD;
                    r0.CostRepoDate = mfg.FechaCosto;
                    r0.CostoCRDate = mfg.FechaCosto;
                }
                else
                {
                    //es una materia prima - se ingresará el costo en el proximo cost-roll
                    //se debe modificar el costo directo en la tabla de costo std.
                }
                db.T0035_CostRoll.Add(r0);
                db.SaveChanges();
                AddRecordStd(material);
            }
        }
        public void AddRecordStd(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matx = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                if (matx == null)
                    return;

                var matstd = db.T0035_CostRoll.SingleOrDefault(c => c.Material == material);
                if (matstd == null)
                    return;

                var m1 = db.T0039_CostoStandard.SingleOrDefault(c => c.Material == material);
                if (m1 != null)
                    return;
                decimal tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
                var r0 = new T0039_CostoStandard
                {
                    Material = material,
                    MonedaCosto = "USD",
                    MType = matstd.MOrigen,
                    FechaCosto = matstd.CostoCRDate.Value,
                    Origen = matstd.MOrigen,
                    CostoUsd = matstd.CostoCR,
                    ManualUpdated = matstd.ManualUpdated,
                    FechaCostRoll = matstd.CostRollDate,
                    CostoArs = Math.Round(matstd.CostoRepoUsd / tc, 4),
                    CostDetBy = "CR",
                    UpdatedOn = DateTime.Today,
                    CostoUsdOld = matstd.CostoCR,
                    CostoArsOld = Math.Round(matstd.CostoRepoUsd / tc, 4),
                    VarCostoArs = 0,
                    VarCostoUsd = 0,
                    FechaCostoOld = matstd.CostoCRDate.Value,
                    UpdatedBy = "Application",
                    DeltaUsd1 = 0,
                    DeltaUsd2 = 0
                };
                db.T0039_CostoStandard.Add(r0);
                db.SaveChanges();
            }
        }
        public void UpdateStdCostManually(string material, decimal costoUsd)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var matx = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                if (matx == null)
                    return;

                var mcroll = db.T0035_CostRoll.SingleOrDefault(c => c.Material == material);
                if (mcroll == null)
                    return;

                var mstd = db.T0039_CostoStandard.SingleOrDefault(c => c.Material == material);
                if (mstd != null)
                    return;

                var costoAnt = mstd.CostoUsdOld;

                decimal tc = new ExchangeRateManager().GetExchangeRate(DateTime.Today);

                mstd.DeltaUsd2 = mstd.DeltaUsd1;
                mstd.CostoUsdOld = mstd.CostoUsd;
                mstd.CostoArsOld = mstd.CostoArs;
                mstd.CostoUsd = costoUsd;
                mstd.CostoArs = Math.Round((costoUsd / tc), 4);
                mstd.VarCostoUsd = costoUsd - mstd.CostoUsdOld;
                mstd.VarCostoArs = mstd.CostoArs - mstd.CostoArsOld;
                mstd.DeltaUsd1 = mstd.VarCostoUsd / costoUsd;
                db.SaveChanges();
            }
        }
        public T0034_CostRollHeader GetCostRollHeaderActivo()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva == true);
            }
        }

        //DE ACA A ABAJO NO REVISE


        /// <summary>
        /// Actualiza CR Cost despues de haber ejecutad un CR
        /// </summary>
        public void UpdateMfgCostAfterCrRun(string material, decimal nuevoCrMfgCost, bool manualUpdate, bool updateAfterCr)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var crActivo = db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva);
                var mfg = db.T0035_CostRoll.SingleOrDefault(c => c.Material == material && c.CostRollId == crActivo.idCostRoll);
                mfg.CostRepoDate = DateTime.Today;
                mfg.CostoRepoUsd = nuevoCrMfgCost;
                mfg.ManualUpdated = manualUpdate;
                mfg.UpdatedAfterCR = updateAfterCr;
                db.SaveChanges();
            }
        }

        private void AddFormulaExplotadaInicialPorfCost(int idFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                DateTime fechaInicial = DateTime.Today.AddYears(-5);
                var bomH = db.T0020_FORMULA_H.SingleOrDefault(c => c.ID_FORMULA == idFormula);
                var matH = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == bomH.IDMATERIAL);
                var bom = db.T0021_FORMULA_I.Where(c => c.FORMULA == idFormula).ToList();
                foreach (var ix in bom)
                {
                    var item = new T0037_CostRollExplosionL1()
                    {
                        ProductoFabricado = bomH.IDMATERIAL,
                        MaterialComponente = ix.ITEM,
                        FormulaID = idFormula,
                        MaterialID = ix.ID_ITEM,
                        OrigenComponente = ix.T0010_MATERIALES.ORIGEN,
                        FechaCosto = fechaInicial,
                        MonedaCosto = matH.MonedaCosto,
                        CostoStdArs = 0,
                        CostoStdUsd = 0,
                        ManualUpdRepo = false,
                        ManualUpdStd = false,
                        FlagRepo = "I",
                        FlagStd = "I",
                        MaterialActivo = matH.ACTIVO,
                        FormulaComplex = 0,
                        CostoStdArsProp = 0,
                        CostoRepoArsProp = 0,
                        CostoStdUsdProp = 0,
                        CostoRepoUsd = 0,
                        CostoRepoUsdProp = 0,
                        CostoRepoArs = 0,
                        Proporcion = ix.CANTIDAD_PORC.Value
                    };
                    db.T0037_CostRollExplosionL1.Add(item);
                    db.SaveChanges();
                }
                var tcr = db.T0035_CostRoll.SingleOrDefault(c => c.Material == matH.IDMATERIAL);
                tcr.FCost = idFormula;
                db.SaveChanges();
            }
        }
        public void RecalculateCostWithNewFCost(string materialFab, int? fCostNew)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var xplo = db.T0037_CostRollExplosionL1.Where(c => c.ProductoFabricado == materialFab).ToList();
                db.T0037_CostRollExplosionL1.RemoveRange(xplo);
                db.SaveChanges();
                if (fCostNew != null)
                {
                    AddFormulaExplotadaInicialPorfCost(fCostNew.Value);
                }
                var crh = db.T0034_CostRollHeader.SingleOrDefault(c => c.VersionActiva);
                crh.UpdFabricado = true;
                new CostRollExplosion().SetCostForManufacturedMaterial(crh.idCostRoll, materialFab);
            }
        }



    }
}