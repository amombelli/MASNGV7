using System.Collections.Generic;
using System.Linq;

namespace TecserEF.Entity.DataStructure
{
    public class CompleteMaterialList
    {
        public enum TablaFrom
        {
            Primario,
            AKA
        };

        public class SimpleMaterialList
        {
            public string Item { get; set; }
            public string Tipo { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionTec { get; set; }
            public string Tabla { get; set; }
            public bool Activo { get; set; }
        }

        public List<SimpleMaterialList> GetData(TablaFrom tabla, string globalAppCnn, bool soloActivo = false)
        {
            using (var db = new TecserData(globalAppCnn))
            {
                if (tabla == TablaFrom.Primario)
                {
                    var xdata = from data in db.T0010_MATERIALES
                                select new SimpleMaterialList()
                                {
                                    Descripcion = data.DescripcionFormulacion,
                                    Item = data.IDMATERIAL,
                                    Tabla = "T0010",
                                    Tipo = data.TIPO_MATERIAL,
                                    Activo = data.ACTIVO,
                                    DescripcionTec = data.DescripcionTecnicaLab

                                };
                    if (soloActivo)
                        return xdata.Where(c => c.Activo).ToList();
                    return xdata.ToList();
                }
                else
                {
                    var xdata = from data in db.T0011_MATERIALES_AKA
                                select new SimpleMaterialList()
                                {
                                    Descripcion = data.MAT_DESC2,
                                    Item = data.CODVENTA,
                                    Tabla = "T0011",
                                    Tipo = data.TIPO_MATERIAL,
                                    Activo = data.ACTIVO,
                                    DescripcionTec = data.MAT_DESC2
                                };
                    if (soloActivo)
                        return xdata.Where(c => c.Activo).ToList();
                    return xdata.ToList();
                }
            }
        }
    }
}
