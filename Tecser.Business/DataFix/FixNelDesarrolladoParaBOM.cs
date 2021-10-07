using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.DataFix
{
    public class FixNelDesarrolladoParaBOM
    {

        //El campo NEL y el campo DESARROLLADO PARA se movio a la tabla T0010
        //debido a que ambos no dependen de la alternativa sino del material

        public static bool Fix(string material)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var md = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(material.ToUpper()));
                if (md == null)
                    return false;

                if (md.NEL != null)
                    return false; //ya fue corregido
                int? NelAsignado = null;
                string DesarrolladoParaAsignado = null;
                int n;
                bool isNumeric;
                var bd = db.T0020_FORMULA_H.Where(c => c.IDMATERIAL.ToUpper().Equals(material.ToUpper())).OrderBy(c => c.ID_FORMULA).ToList();
                foreach (var it in bd)
                {
                    if (NelAsignado == null)
                    {
                        if (it.NEL != null)
                        {
                            isNumeric = int.TryParse(it.NEL, out n);
                            if (isNumeric)
                            {
                                NelAsignado = Convert.ToInt32(n);
                                DesarrolladoParaAsignado = it.DESARROLLADO;
                            }
                        }
                    }
                }
                md.NEL = NelAsignado;
                md.DesarrolladoPara = DesarrolladoParaAsignado;
                return db.SaveChanges() > 0;

            }
        }
    }
}
