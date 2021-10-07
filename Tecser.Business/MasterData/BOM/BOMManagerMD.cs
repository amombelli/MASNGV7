using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.BOM
{
    //New Class BOM to manage checks-validations-lists
    //2018.11.20
    public class BOMManagerMD
    {


        /// <summary>
        /// Devuelve true si hay al menos una BOM de este primarioFormula
        /// </summary>
        public static bool CheckIfBOMExist(string primarioFormula)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var existe = db.T0020_FORMULA_H.Where(c => c.IDMATERIAL.ToUpper().Equals(primarioFormula.ToUpper())).ToList();
                return existe.Count != 0;
            }
        }


    }
}
