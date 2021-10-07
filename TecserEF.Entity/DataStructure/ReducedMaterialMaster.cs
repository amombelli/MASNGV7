using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    public class ReducedMaterialMaster
    {
        public string Primario { get; set; }
        public string MType { get; set; }
        public bool Activo { get; set; }
        public string Descripcion1 { get; set; }
    }

    public class ReducedMaterialMasterData
    {
        public List<ReducedMaterialMaster> GetList(string globalAppCnn)
        {
            using (var db = new TecserData(globalAppCnn))
            {
                var query = from mm in db.T0010_MATERIALES
                            select new ReducedMaterialMaster()
                            {
                                Primario = mm.IDMATERIAL,
                                Activo = mm.ACTIVO,
                                Descripcion1 = mm.MAT_DESC,
                                MType = mm.TIPO_MATERIAL
                            };
                return query.ToList();
            }
        }
    }
}
