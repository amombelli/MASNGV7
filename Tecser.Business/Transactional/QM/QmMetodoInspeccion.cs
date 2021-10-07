using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.QM
{
    public class QmMetodoInspeccion
    {
        public enum Resultado
        {
            Aprobado,
            Incorrecto,
            Evaluacion,
            SinEvaluar,
            Cancelado
        };

        public static Resultado MapFromText(string resultado)
        {
            if (String.IsNullOrEmpty(resultado))
                return Resultado.SinEvaluar;
            try
            {
                return (Resultado)Enum.Parse(typeof(QmInspectionStatus.StatusIRecord), resultado, true);
            }
            catch (Exception)
            {
                return Resultado.SinEvaluar;
                throw;
            }
        }



        public bool CreateAndUpdateMetodoInspeccion(T0800_QMMetodosInspeccion metodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var m = db.T0800_QMMetodosInspeccion.SingleOrDefault(c => c.IdMetodo == metodo.IdMetodo);
                if (m != null)
                {
                    db.Entry(m).CurrentValues.SetValues(metodo);
                    db.SaveChanges();
                    return true;
                }

                db.T0800_QMMetodosInspeccion.Add(metodo);
                return db.SaveChanges() > 0;
            }
        }
        public List<T0800_QMMetodosInspeccion> GetMetodosList()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0800_QMMetodosInspeccion.ToList();
            }
        }
        public T0800_QMMetodosInspeccion GetMetodoData(string IdMetodoodo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0800_QMMetodosInspeccion.SingleOrDefault(c => c.IdMetodo == IdMetodoodo);
            }
        }
    }
}
