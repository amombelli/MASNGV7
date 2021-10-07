using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.QM
{
    public class QmMasterIplan
    {

        public enum StatusMedicion
        {
            Indeterminado,
            Aprobado,
            NoAprobado
        }
        public static StatusMedicion MapTipoDatoFromText(string status)
        {
            if (string.IsNullOrEmpty(status))
                status = StatusMedicion.Indeterminado.ToString();
            if (status == "SinEvaluar")
                status = StatusMedicion.Indeterminado.ToString();

            try
            {
                return (StatusMedicion)Enum.Parse(typeof(StatusMedicion), status, true);
            }
            catch (Exception)
            {
                return StatusMedicion.Indeterminado;
                throw;
            }
        }

        public List<T0801_QMMasterIPHeader> GetListIPlan(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0801_QMMasterIPHeader.Where(c => c.ACTIVO.Value).OrderBy(c => c.IDPLAN).ToList();
                return db.T0801_QMMasterIPHeader.OrderBy(c => c.IDPLAN).ToList();

            }
        }

        /// <summary>
        /// Retorna True si el plan ya existe y False si no existe
        /// </summary>
        public static bool ValidaPlanExiste(string idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0801_QMMasterIPHeader.SingleOrDefault(c => c.IDPLAN.ToUpper().Equals(idPlan.ToUpper()));
                return x != null;
            }
        }

        public T0801_QMMasterIPHeader GetPlanHeader(string idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0801_QMMasterIPHeader.SingleOrDefault(c => c.IDPLAN == idPlan);
            }
        }

        public List<T0802_QMMasterIPDetail> GetPlanDetails(string idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lista = db.T0802_QMMasterIPDetail.Where(c => c.IDPLAN.Equals(idPlan)).ToList();
                return lista;
            }
        }

        public T0802_QMMasterIPDetail GetPlanDetailSpecific(string idPlan, string IdMetodoodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0802_QMMasterIPDetail.SingleOrDefault(c => c.IDPLAN.Equals(idPlan) && c.METODO == IdMetodoodo);
            }
        }

        public List<T0800_QMMetodosInspeccion> GetMetodosAvailableToAddToSpecificPlan(string idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var z = db.T0800_QMMetodosInspeccion.ToList();
                var metodosEnPlan = db.T0802_QMMasterIPDetail.Where(c => c.IDPLAN == idPlan).ToList();
                foreach (var metodo in metodosEnPlan)
                {
                    var ok = z.Find(c => c.IdMetodo == metodo.METODO);
                    z.Remove(ok);
                }
                return z;
            }
        }

        public bool AddMetodoToPlan(string idPlan, string IdMetodoodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0802_QMMasterIPDetail.SingleOrDefault(c => c.IDPLAN == idPlan && c.METODO == IdMetodoodo);
                if (h != null)
                    return false;

                var metodo = db.T0800_QMMetodosInspeccion.SingleOrDefault(c => c.IdMetodo == IdMetodoodo);
                var planMetodo = new T0802_QMMasterIPDetail()
                {
                    IDPLAN = idPlan,
                    METODO = IdMetodoodo,
                    ACTIVO = true,
                    Observacion = null,
                    ValorMax = "",
                    ValorMin = "",
                    ValorStd = "",
                };

                var dataType = QmMetodoDataType.MapTipoDatoFromText(metodo.ValorType);
                switch (dataType)
                {
                    case QmMetodoDataType.TipoDato.Decimal:
                        planMetodo.ValorMax = 0.ToString("F4");
                        planMetodo.ValorStd = 0.ToString("F4");
                        planMetodo.ValorMin = 0.ToString("F4");
                        break;
                    case QmMetodoDataType.TipoDato.Entero:
                        planMetodo.ValorMax = @"0";
                        planMetodo.ValorStd = @"0";
                        planMetodo.ValorMin = @"0";
                        break;
                    case QmMetodoDataType.TipoDato.Si_No:
                        planMetodo.ValorMax = QmMetodoDataType.VSiNo.Si.ToString();
                        planMetodo.ValorStd = QmMetodoDataType.VSiNo.Si.ToString();
                        planMetodo.ValorMin = QmMetodoDataType.VSiNo.Si.ToString();
                        break;
                    case QmMetodoDataType.TipoDato.Ok_Incorrecto:
                        planMetodo.ValorMax = QmMetodoDataType.VOkIncorrecto.Ok.ToString();
                        planMetodo.ValorStd = QmMetodoDataType.VOkIncorrecto.Ok.ToString();
                        planMetodo.ValorMin = QmMetodoDataType.VOkIncorrecto.Ok.ToString();
                        break;
                    case QmMetodoDataType.TipoDato.Aprobado_Rechazado:
                        planMetodo.ValorMax = QmMetodoDataType.VAprobadoRechazado.Aprobado.ToString();
                        planMetodo.ValorStd = QmMetodoDataType.VAprobadoRechazado.Aprobado.ToString();
                        planMetodo.ValorMin = QmMetodoDataType.VAprobadoRechazado.Aprobado.ToString();
                        break;
                    case QmMetodoDataType.TipoDato.TextoLibre:
                        planMetodo.ValorMax = "";
                        planMetodo.ValorStd = "";
                        planMetodo.ValorMin = "";
                        break;
                    case QmMetodoDataType.TipoDato.True_False:
                        planMetodo.ValorMax = QmMetodoDataType.VTrueFalse.Verdadero.ToString();
                        planMetodo.ValorStd = QmMetodoDataType.VTrueFalse.Verdadero.ToString();
                        planMetodo.ValorMin = QmMetodoDataType.VTrueFalse.Verdadero.ToString();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                db.T0802_QMMasterIPDetail.Add(planMetodo);
                return db.SaveChanges() > 0;
            }
        }

        public void CreateUpdatePlanHeader(T0801_QMMasterIPHeader planHeader)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var h = db.T0801_QMMasterIPHeader.SingleOrDefault(c => c.IDPLAN == planHeader.IDPLAN);
                if (h == null)
                {
                    db.T0801_QMMasterIPHeader.Add(planHeader);
                }
                else
                {
                    db.Entry(h).CurrentValues.SetValues(planHeader);
                }
                db.SaveChanges();
            }
        }

        public void UpdatePlanDetail(T0802_QMMasterIPDetail detalle)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0802_QMMasterIPDetail.SingleOrDefault(c =>
                    c.IDPLAN == detalle.IDPLAN && c.METODO == detalle.METODO);

                if (data == null)
                {
                    //el metodo no existe para el plan
                    db.T0802_QMMasterIPDetail.Add(detalle);
                }
                else
                {
                    db.Entry(data).CurrentValues.SetValues(detalle);
                }
                db.SaveChanges();
            }
        }

        public void DeleteMetodoPlan(string idPlan, string IdMetodoodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0802_QMMasterIPDetail.SingleOrDefault(c =>
                    c.IDPLAN == idPlan && c.METODO == IdMetodoodo);

                if (data == null) return;
                db.T0802_QMMasterIPDetail.Remove(data);
                db.SaveChanges();
            }
        }
        public List<string> GetMaterialesAsociadosPlan(string idPlan)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<string> materialList = db.T0010_MATERIALES.Where(c => c.IP == idPlan).Select(c => c.IDMATERIAL.ToString()).ToList();
                return materialList;
            }
        }
        public List<string> GetMaterialesNoAsociadosPlan()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                List<string> materialList = db.T0010_MATERIALES.Where(c => c.IP == null).Select(c => c.IDMATERIAL.ToString()).ToList();
                return materialList;
            }
        }
        public void AsociaMaterialAPlan(string idPlan, string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                data.IP = idPlan;
                db.SaveChanges();
            }
        }
        public void EliminaMaterialPlan(string idPlan, string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                data.IP = null;
                db.SaveChanges();
            }
        }

        public string GetPlanFromMaterial(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL == material);
                if (string.IsNullOrEmpty(data.IP))
                    return "NODEF";
                return data.IP;
            }
        }

    }
}
