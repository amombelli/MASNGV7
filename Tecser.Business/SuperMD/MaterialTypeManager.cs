using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    /// <summary>
    /// Nueva clase referida a un tipo de material
    /// </summary>
    public class MaterialTypeManager
    {
        public List<T0011_MaterialType> GetListMtype(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0011_MaterialType.Where(c => c.Activo).ToList();
                return db.T0011_MaterialType.ToList();
            }
        }
        public T0011_MaterialType GetMtype(string tipoMaterial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0011_MaterialType.SingleOrDefault(c => c.Mtype == tipoMaterial);
            }
        }
        public int SaveMaterialTypeData(T0011_MaterialType data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataDb =
                    db.T0011_MaterialType.SingleOrDefault(c => c.Mtype.ToUpper().Equals(data.Mtype.ToUpper()));
                if (dataDb == null)
                {
                    db.T0011_MaterialType.Add(data);
                }
                else
                {
                    db.Entry(dataDb).CurrentValues.SetValues(data);
                }
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// Lista de materiales disponibles a la venta
        /// </summary>
        public List<T0011_MaterialType> GetMtypeForAkaProducts(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0011_MaterialType.Where(c => c.DispSalesOrder && c.Activo).ToList();
                return db.T0011_MaterialType.Where(c => c.DispSalesOrder).ToList();
            }
        }
        /// <summary>
        /// Lista todos los materiales que PUEDEN tener una BOM => OF
        /// </summary>
        public List<string> GetListMaterialsTobeManufacture()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0010_MATERIALES.Where(c => c.T0011_MaterialType.DispOrdenFabricacion)
                    .Select(c => c.IDMATERIAL).ToList();
            }
        }
        public List<T0010_MATERIALES> GetListMaterialAvailableAsBOMComponenet(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0010_MATERIALES.Where(c => c.ACTIVO == true && c.T0011_MaterialType.DispBOMItem).ToList();
                return db.T0010_MATERIALES.Where(c => c.T0011_MaterialType.DispBOMItem).ToList();
            }
        }
        public List<T0010_MATERIALES> GetListMaterialAvailableToBuy(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0010_MATERIALES.Where(c => c.T0011_MaterialType.DispOrdenCompra && c.ACTIVO).ToList();
                return db.T0010_MATERIALES.Where(c => c.T0011_MaterialType.DispOrdenCompra).ToList();
            }
        }

        public void GetMaterialesDisponibleVenta()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
        }
        public void GetMaterialsDisponibleCompra()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

            }
        }




    }
}
