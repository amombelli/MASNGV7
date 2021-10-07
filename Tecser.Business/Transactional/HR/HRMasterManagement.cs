using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.SuperMD;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.HR
{

    /// <summary>
    /// Nueva Clase de Manejo de Datos Basicos de Recursos Humanos/Personal
    /// 2021.03.20
    /// </summary>
    public class HrMasterManagement
    {
        public static string GetEmployeeShortname(int glEmployee)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var e = db.T0085_HHRR_PERSONAL_BASIC.SingleOrDefault(c =>
                    c.GLSubfix == glEmployee);
                if (e == null)
                    return "EMPLOYEE??";
                return e.Shortname;
            }
        }
        public static T0085_HHRR_PERSONAL_BASIC GetBasicData(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0085_HHRR_PERSONAL_BASIC.SingleOrDefault(c =>
                    c.Shortname.ToUpper().Equals(shortname.ToUpper()));
            }
        }
        public static List<T0085_HHRR_PERSONAL_BASIC> GetBasicDataList(bool onlyActive = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0085_HHRR_PERSONAL_BASIC.Where(c =>
                        c.Activo).ToList();
                return db.T0085_HHRR_PERSONAL_BASIC.ToList();
            }
        }
        public static bool ExisteShortname(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0085_HHRR_PERSONAL_BASIC.SingleOrDefault(c =>
                    c.Shortname.ToUpper().Equals(shortname.ToUpper())) != null;
            }
        }
        public static bool ExisteGL(int glSubfix)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0085_HHRR_PERSONAL_BASIC.SingleOrDefault(c =>
                    c.GLSubfix == glSubfix) != null;
            }
        }
        public static int? EmpleadoGl(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var empl = db.T0085_HHRR_PERSONAL_BASIC.SingleOrDefault(c =>
                     c.Shortname.ToUpper().Equals(shortname.ToUpper()));
                return empl?.GLSubfix;
            }
        }
        public static string EmpleadoGlap(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var empl = db.T0085_HHRR_PERSONAL_BASIC.SingleOrDefault(c =>
                    c.Shortname.ToUpper().Equals(shortname.ToUpper()));
                if (empl == null)
                    return "0.0.0.0";
                return string.IsNullOrEmpty(empl.GLAP) ? "0.0.0.0" : empl.GLAP;
            }
        }
        public void SaveBasicData(T0085_HHRR_PERSONAL_BASIC data)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data1 = db.T0085_HHRR_PERSONAL_BASIC.SingleOrDefault(c =>
                    c.Shortname.ToUpper().Equals(data.Shortname.ToUpper()));
                if (data1 == null)
                {
                    db.T0085_HHRR_PERSONAL_BASIC.Add(data);
                    db.SaveChanges();
                }
                else
                {
                    //modificacion de empleado
                    data1.Nombre = data.Nombre;
                    data1.Apellidos = data.Apellidos;
                    data1.LegajoRaf = data.LegajoRaf;
                    data1.GLSubfix = data.GLSubfix;
                    data1.Activo = data.Activo;
                    data1.Documento = data.Documento;
                    data1.CUIL = data.CUIL;
                    data1.BitQuincena = data.BitQuincena;
                    data1.BitMensual = data.BitMensual;
                    data1.VendorId = data.VendorId;
                    data1.PosicionID = data.PosicionID;
                    data1.GLAP = data.GLAP;
                    data1.SumaExtra = data.SumaExtra;
                    data1.Foto = data.Foto;
                    db.SaveChanges();
                }
            }
        }
        public static bool CreateGLAccountsForEmployees(string shortnameEmpleado, string glPrefijo, string descripcion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var empl = db.T0085_HHRR_PERSONAL_BASIC.SingleOrDefault(c =>
                    c.Shortname.ToUpper().Equals(shortnameEmpleado.ToUpper()));
                if (empl == null)
                    return false;

                new GlAccountStructureManager().CreateNewGLAccount(glPrefijo, descripcion);
                return true;

            }
        }

        /// <summary>
        /// Para Payment tiene que tener activo el GLSubfix
        /// </summary>
        public List<T0085_HHRR_PERSONAL_BASIC> GetEmployeeListForSyJ(bool onlyActivo)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActivo)
                {
                    return db.T0085_HHRR_PERSONAL_BASIC.Where(c => c.Activo && c.GLSubfix != null).ToList();
                }

                return db.T0085_HHRR_PERSONAL_BASIC.Where(c => c.GLSubfix != null).ToList();
            }
        }
        public static List<T0085_HHRR_PERSONAL_BASIC> GetEmployeeListQuincenal(bool onlyActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActivo)
                {
                    return db.T0085_HHRR_PERSONAL_BASIC.Where(c => c.Activo && c.GLSubfix != null && c.BitQuincena).ToList();
                }

                return db.T0085_HHRR_PERSONAL_BASIC.Where(c => c.GLSubfix != null && c.BitQuincena).ToList();
            }
        }
        public static List<T0085_HHRR_PERSONAL_BASIC> GetEmployeeListMensual(bool onlyActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActivo)
                {
                    return db.T0085_HHRR_PERSONAL_BASIC.Where(c => c.Activo && c.GLSubfix != null && c.BitMensual).ToList();
                }

                return db.T0085_HHRR_PERSONAL_BASIC.Where(c => c.GLSubfix != null && c.BitMensual).ToList();
            }
        }

        public static T0088_HHRR_DatosPersonales GetDatosPersonales(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0088_HHRR_DatosPersonales.SingleOrDefault(c => c.Shortname == shortname);
            }
        }

        public static void UpdateCreateDatosPersonales(string shortname, string bancoShortname, string numeroCuenta, string calle, string barrio, string localidad, string codigoPostal, string email, DateTime? fechaNacimiento, string telefono1, string telefono2)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0088_HHRR_DatosPersonales.SingleOrDefault(c => c.Shortname == shortname);
                if (r == null)
                {
                    var t = new T0088_HHRR_DatosPersonales()
                    {
                        Shortname = shortname,
                        Banco = bancoShortname,
                        Cuenta = numeroCuenta,
                        DireccionBarrio = barrio,
                        DireccionCalle = calle,
                        DireccionCodPostal = codigoPostal,
                        DireccionLocalidad = localidad,
                        EmailPersonal = email,
                        FechaNacimiento = fechaNacimiento,
                        Telefono1 = telefono1,
                        Telefono2 = telefono2
                    };
                    db.T0088_HHRR_DatosPersonales.Add(t);
                    db.SaveChanges();
                }
                else
                {
                    r.Banco = bancoShortname;
                    r.Cuenta = numeroCuenta;
                    r.DireccionBarrio = barrio;
                    r.DireccionCalle = calle;
                    r.DireccionCodPostal = codigoPostal;
                    r.DireccionLocalidad = localidad;
                    r.EmailPersonal = email;
                    r.FechaNacimiento = fechaNacimiento;
                    r.Telefono1 = telefono1;
                    r.Telefono2 = telefono2;
                    db.SaveChanges();
                }
            }
        }
    }
}
