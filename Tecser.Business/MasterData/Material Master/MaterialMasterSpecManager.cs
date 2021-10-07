using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.Material_Master
{
    public class MaterialMasterSpecManager
    {

        public T0009_MATERIALSPEC LoadSpecData(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0009_MATERIALSPEC.SingleOrDefault(c => c.IdMaterial == material.ToUpper());
            }
        }

        public bool SaveSpecData(T0009_MATERIALSPEC data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                data.IdMaterial = data.IdMaterial.ToUpper();
                var mat = db.T0009_MATERIALSPEC.SingleOrDefault(c => c.IdMaterial == data.IdMaterial);
                if (mat == null)
                {
                    db.T0009_MATERIALSPEC.Add(data);
                }
                else
                {
                    db.Entry(mat).CurrentValues.SetValues(data);
                }
                return db.SaveChanges() > 0;
            }
        }

    }
}
