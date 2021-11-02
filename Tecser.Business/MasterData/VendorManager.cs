using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.MasterData
{
    public class VendorManager
    {

        private int NextVendorID()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var max1 = db.T0005_MPROVEEDORES.Where(c => c.id_prov < 10000).Max(c => c.id_prov);
                return max1 + 1;
            }
        }

        public static string  GetVendorRazonSocial(int idVendor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0005_MPROVEEDORES.SingleOrDefault(c => c.id_prov == idVendor).prov_rsocial;
            }
        }


        public List<T0014_TIPO_PROVEEDOR> GetVendorTypeList(bool soloActivo = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloActivo)
                    return db.T0014_TIPO_PROVEEDOR.Where(c => c.Activo == true).ToList();
                return db.T0014_TIPO_PROVEEDOR.ToList();
            }
        }
        public static T0014_TIPO_PROVEEDOR GetDataVendorType(string vendorType)
        {
            var data = new TecserData(GlobalApp.CnnApp).T0014_TIPO_PROVEEDOR.SingleOrDefault(c => c.TIPOPROV.Equals(vendorType));
            if (data == null)
            {
                var datanull = new T0014_TIPO_PROVEEDOR
                {
                    TIPOPROV = "VendorNull"
                };
                return datanull;
            }
            else
            {
                return data;
            }
        }
        public List<T0005_MPROVEEDORES> GetCompleteListVendors(bool soloActivo = false)
        {
            if (soloActivo != true)
            {
                return new Repository<T0005_MPROVEEDORES>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
            }
            else
            {
                return
                    new Repository<T0005_MPROVEEDORES>(new TecserData(GlobalApp.CnnApp)).GetAll().Where(c => c.ACTIVO == true).ToList();
            }
        }
        /// <summary>
        /// Retorna lista de proveedores con filtro activo/disponibles para OC
        /// </summary>
        /// <returns></returns>
        public List<T0005_MPROVEEDORES> GetCompleteVendorList(bool onlyActive = false, bool onlyAllowedForOC = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyAllowedForOC)
                {
                    if (onlyActive)
                    {
                        //todos los vendors activos que pueden tener OC
                        return db.T0005_MPROVEEDORES.Where(c => c.T0014_TIPO_PROVEEDOR.DISPO_OC && c.ACTIVO.Value).ToList();
                    }
                    else
                    {
                        //todos los vendors que pueden tener OC
                        return db.T0005_MPROVEEDORES.Where(c => c.T0014_TIPO_PROVEEDOR.DISPO_OC).ToList();
                    }
                }
                else
                {
                    if (onlyActive)
                    {
                        //todos los vendors activos
                        return db.T0005_MPROVEEDORES.Where(c => c.ACTIVO.Value).ToList();
                    }
                    else
                    {
                        //todos los vendors
                        return db.T0005_MPROVEEDORES.ToList();
                    }
                }
            }
        }
        public T0005_MPROVEEDORES GetSpecificVendor(int idVendor)
        {
            var data = new Repository<T0005_MPROVEEDORES>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.id_prov == idVendor);
            if (data == null)
            {
                var vendornull = new T0005_MPROVEEDORES
                {
                    id_prov = -1,
                    prov_rsocial = "No Encontrado"

                };
                return vendornull;
            }
            return data;
        }
        public T0005_MPROVEEDORES GetSpecificVendor(string numeroCuit)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var vendor = db.T0005_MPROVEEDORES.Where(c => c.NTAX1 == numeroCuit && c.ACTIVO.Value).ToList();
                if (vendor.Count == 1)
                    return vendor[0];
                return null;
            }
        }
        public void SaveContactInfo(int idVendor, string contactName, string telefono1, string telefono2,
            string emailPedido)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var vm = db.T0005_MPROVEEDORES.SingleOrDefault(c => c.id_prov == idVendor);
                if (vm == null)
                    return;

                vm.Contacto = contactName;
                vm.Telefono = telefono1;
                vm.Fax = telefono2;
                vm.EMAIL = emailPedido;
                db.SaveChanges();
            }
        }


        /// <summary>
        /// 
        /// Retorna -1 si no pudo encontrar el tipo
        /// </summary>
        /// <param name="tipoProveedor"></param>
        /// <returns></returns>
        private int GetFirstId(string tipoProveedor)
        {
            var data =
                new TecserData(GlobalApp.CnnApp).T0014_TIPO_PROVEEDOR.SingleOrDefault(
                    c => c.TIPOPROV.Trim().ToUpper().Equals(tipoProveedor));
            if (data == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(data.RangoIDProveedor) + 1;
            }
        }

        private int GetNextIdProveedor(string tipoProveedor)
        {
            var data =
                new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.FirstOrDefault(c => c.TIPO.Trim().ToUpper().Equals(tipoProveedor));
            if (data == null)
            {
                var newNumero = GetFirstId(tipoProveedor);
                return newNumero;
            }
            else
            {
                var newNumero =
                    new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Where(
                        c => c.TIPO.Trim().ToUpper().Equals(tipoProveedor.ToUpper()))
                        .Max(c => c.id_prov) + 1;

                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    while (db.T0005_MPROVEEDORES.SingleOrDefault(c => c.id_prov == newNumero) != null)
                    {
                        newNumero++;
                    }
                }

                return newNumero;
            }

        }

        public bool CheckIfCuitExist(string ntax)
        {
            return new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Any(c => c.NTAX1.Equals(ntax));
        }

        /// <summary>
        /// Crea un nuevo vendor o Guarda los cambios segun corresponda
        /// </summary>
        /// <param name="p"></param>
        /// <returns>
        /// -1 error
        /// 0 actualizo correcto
        /// >0 Id Vendor Creado
        /// </returns>
        public int GuardaCambiosVendor(T0005_MPROVEEDORES p)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (p.id_prov <= 0)
                {
                    p.id_prov = NextVendorID();
                    //p.id_prov = GetNextIdProveedor(p.TIPO);
                    if (p.id_prov < 1)
                        return -1;

                    p.Ultimo_Movimiento = null;
                    p.LOG_USER = GlobalApp.AppUsername;
                    p.Fecha_Ingreso = DateTime.Today;
                    p.LOG_DATE = DateTime.Now;
                    db.T0005_MPROVEEDORES.Add(p);
                    if (db.SaveChanges() > 0)
                        return p.id_prov;
                    return -1;
                }
                else
                {
                    //El proveedor supuestamente existe
                    var data = db.T0005_MPROVEEDORES.SingleOrDefault(c => c.id_prov == p.id_prov);
                    if (data == null)
                    {
                        //El proveedor que supuestamente existia - NO EXISTE
                        return -1;
                    }
                    else
                    {
                        p.LOG_USER = GlobalApp.AppUsername;
                        p.LOG_DATE = DateTime.Now;
                        db.Entry(data).CurrentValues.SetValues(p);
                        if (db.SaveChanges() > 0)
                            return 0;
                        return -1;
                    }
                }
            }
        }


        public int GetZterm(int idProveedor, string lx) //todo: colocar ztermL1 y ztermL2 en proveedor
        {
            var data = GetSpecificVendor(idProveedor);
            if (data == null)
                return 0;
            if (lx == "L1")
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }
        public List<T0005_MPROVEEDORES> GetListVendorsWithOrdenCompra()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0005_MPROVEEDORES.Where(
                        c =>
                            c.T0060_OCOMPRA_H.Any(
                                d =>
                                    d.STATUSOC.ToUpper() ==
                                    OrdenCompraStatusManager.StatusHeader.Emitida.ToString().ToUpper() ||
                                    d.STATUSOC.ToUpper() ==
                                    OrdenCompraStatusManager.StatusHeader.Proceso.ToString().ToUpper())).ToList();
            }
        }
        public List<T0005_MPROVEEDORES> GetListVendorByVendorType(string vendorType, bool soloActive = false)
        {
            if (soloActive != true)
                return
                    new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Where(
                        c => c.T0014_TIPO_PROVEEDOR.TIPOPROV.ToUpper().Equals(vendorType.ToUpper())).ToList();
            {
                var data =
                    new TecserData(GlobalApp.CnnApp).T0005_MPROVEEDORES.Where(
                        c =>
                            c.T0014_TIPO_PROVEEDOR.TIPOPROV.ToUpper().Equals(vendorType.ToUpper()) &&
                            c.ACTIVO.Value == true).ToList();

                return data;
            }
        }
        public List<T0066_ITEMS_PROVEEDOR_OC> GetListItemsProveedor(int idProveedor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0066_ITEMS_PROVEEDOR_OC.Where(c => c.PROVEEDOR == idProveedor).ToList();
            }
        }
        public List<T0005_MPROVEEDORES> GetListVendorPendienteContabilizacionRemito()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return
                    db.T0005_MPROVEEDORES.Where(c => c.T0063_ITEMS_OC_INGRESADOS.Any(d => d.CONTA.Value == false))
                        .ToList();
            }
        }

    }

}
