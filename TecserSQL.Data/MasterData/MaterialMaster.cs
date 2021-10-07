using TecserEF.Entity;

namespace TecserSQL.Data.MasterData
{
    public class MaterialMaster
    {
        public MaterialMaster(TecserData context)
        {

        }

        //public List<T0011_MATERIALES_AKA> GetListMaterialToSell()
        //{
        //    using (var db = new TecserData(GlobalApp.CnnApp))
        //    {
        //        var query =
        //            db.T0011_MATERIALES_AKA.Where(c => c.T0012_TIPO_MATERIAL.DISPO_FA == true);
        //        return query.ToList();
        //    }
        //}

        //public List<T0010_MATERIALES> GetListMaterialAvailableToBuy()
        //{
        //    using (var db = new TecserData(GlobalApp.CnnApp))
        //    {
        //        return db.T0010_MATERIALES.Where(c => c.T0012_TIPO_MATERIAL.DISPO_OC == true).ToList();
        //    }
        //}

    }

}
