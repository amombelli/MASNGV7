using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.Material_Master
{
    public class MMR
    {
        public bool ChecknewNameIsValid(string newMaterial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(newMaterial.ToUpper()));
                if (x != null)
                    return false;

                var aka =
                    db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(newMaterial.ToUpper()));
                if (aka != null)
                    return false;
                return true;
            }
        }


        //public bool RenamePrimario(string codigoPrimario, string nuevoCodigoPrimario)
        //{
        //    using (var db = new TecserData(GlobalApp.CnnApp))
        //    {
        //        var prim = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper() == codigoPrimario.ToUpper());
        //        if (prim == null)
        //            return false;

        //        var aka = db.T0011_MATERIALES_AKA.SingleOrDefault(c=>c)

        //        prim.IDMATERIAL
        //    }

        //}


    }
}
