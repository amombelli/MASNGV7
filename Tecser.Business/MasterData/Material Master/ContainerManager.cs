using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.MasterData.Material_Master
{
    public class ContainerManager
    {

        public List<T0010_Container> GetAllContainer(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0010_Container.Where(c => c.Activo).ToList();
                return db.T0010_Container.ToList();
            }
        }
        public string MaterialContainer(string codigoMaterial)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var esAka =
                    db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(codigoMaterial.ToUpper()));
                if (esAka != null)
                {
                    if (string.IsNullOrEmpty(esAka.Container))
                    {
                        return null;
                    }
                    else
                    {
                        return esAka.Container;
                    }
                }
                else
                {
                    var esPrimario =
                        db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(codigoMaterial.ToUpper()));
                    if (string.IsNullOrEmpty(esPrimario.MAT_GRP2))
                    {
                        return null;
                    }
                    else
                    {
                        return esPrimario.MAT_GRP2;
                    }
                }
            }
        }
        public int DeterminaCantidadContainers(string containerId, decimal cantidadFabricar)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0010_Container.SingleOrDefault(c => c.ContainerId == containerId);
                return Convert.ToInt32(Math.Ceiling(cantidadFabricar / data.Capacidad));
            }
        }

        public void SetContainerToMaterial(string codigoMaterial, string containerId)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var esAka =
                    db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(codigoMaterial.ToUpper()));
                if (esAka != null)
                {
                    esAka.Container = containerId;
                }
                else
                {
                    var esPrimario =
                        db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(codigoMaterial.ToUpper()));
                    if (esPrimario != null)
                        esPrimario.MAT_GRP2 = containerId;
                    return;
                }
                db.SaveChanges();
            }
        }
    }
}



