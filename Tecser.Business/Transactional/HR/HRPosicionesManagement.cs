using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.HR
{

    //Clase para el manejo de Posiciones de HHRR
    public class HrPosicionesManagement
    {
        public static List<T0086_HHRR_POSICIONES> GetPosiciones(bool soloActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloActivo)
                    return db.T0086_HHRR_POSICIONES.Where(c => c.Activo).ToList();
                return db.T0086_HHRR_POSICIONES.ToList();
            }
        }

        public static T0086_HHRR_POSICIONES GetPosicion(int idPos)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0086_HHRR_POSICIONES.SingleOrDefault(c => c.IDPOSICION == idPos);
            }
        }

        public int CreateUpdatePosicion(T0086_HHRR_POSICIONES pos)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (pos.IDPOSICION == -1)
                {
                    //creacion de posicion
                    if (db.T0086_HHRR_POSICIONES.Any())
                    {
                        pos.IDPOSICION = db.T0086_HHRR_POSICIONES.Max(c => c.IDPOSICION) + 1;
                    }
                    else
                    {
                        pos.IDPOSICION = 1;
                    }
                    db.T0086_HHRR_POSICIONES.Add(pos);
                    db.SaveChanges();
                }
                else
                {
                    var existingData = db.T0086_HHRR_POSICIONES.SingleOrDefault(c => c.IDPOSICION == pos.IDPOSICION);
                    db.Entry(existingData).CurrentValues.SetValues(pos);
                    db.SaveChanges();
                }
                return pos.IDPOSICION;
            }
        }


    }
}
