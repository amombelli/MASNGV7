using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.HR
{
    /// <summary>
    /// Clase para manejo de Disponiblidad de Empleados en Combobox y Funcionalidades
    ///
    /// caducar esta funcion y passarla a HRComboManager
    /// Bajar la tabla T0087
    /// </summary>
    public static class HrDisponibilidadYPermisos
    {
        public static T0087_HHRR_DISPONIBILIDAD GetRegistroPermisosCompletos(string shortname)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0087_HHRR_DISPONIBILIDAD.SingleOrDefault(c =>
                    c.Shortname.ToUpper().Equals(shortname.ToUpper()));
            }
        }

        public static void SetRegistroPermiso(string shortname, bool venta, bool despacho, bool cq, bool operario,
            bool cobranza, bool ic, bool vendedor, bool autorizaSc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var rec = db.T0087_HHRR_DISPONIBILIDAD.SingleOrDefault(c =>
                    c.Shortname.ToUpper().Equals(shortname.ToUpper()));
                if (rec == null)
                {
                    var t = new T0087_HHRR_DISPONIBILIDAD()
                    {
                        AutorizaSinCargo = autorizaSc,
                        Cobranza = cobranza,
                        ControlCalidad = cq,
                        Despacho = despacho,
                        IngresoIC = ic,
                        Operario = operario,
                        Shortname = shortname,
                        Vendedor = vendedor,
                        Venta = venta
                    };
                    db.T0087_HHRR_DISPONIBILIDAD.Add(t);
                }
                else
                {
                    rec.AutorizaSinCargo = autorizaSc;
                    rec.Cobranza = cobranza;
                    rec.ControlCalidad = cq;
                    rec.Despacho = despacho;
                    rec.IngresoIC = ic;
                    rec.Operario = operario;
                    rec.Vendedor = vendedor;
                    rec.Venta = venta;
                }

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Disponible para ingreso de OV y/o operacion de ventas
        /// </summary>
        public static List<string> DisponibleVentas()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaEmpl = from x in db.T0087_HHRR_DISPONIBILIDAD
                    where x.T0085_HHRR_PERSONAL_BASIC.Activo == true && x.Venta
                    select x.Shortname;
                return listaEmpl.ToList();
            }
        }

        /// <summary>
        /// Disponible para operacion de verificacion de Despacho (control de mercaderia)
        /// </summary>
        public static List<string> DisponibleDespacho()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaEmpl = from x in db.T0087_HHRR_DISPONIBILIDAD
                    where x.T0085_HHRR_PERSONAL_BASIC.Activo == true && x.Despacho
                    select x.Shortname;
                return listaEmpl.ToList();
            }
        }

        public static List<string> DisponibleControlCq()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaEmpl = from x in db.T0087_HHRR_DISPONIBILIDAD
                    where x.T0085_HHRR_PERSONAL_BASIC.Activo == true && x.ControlCalidad
                    select x.Shortname;
                return listaEmpl.ToList();
            }
        }

        public static List<string> DisponibleOperario()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaEmpl = from x in db.T0087_HHRR_DISPONIBILIDAD
                    where x.T0085_HHRR_PERSONAL_BASIC.Activo == true && x.Operario
                    select x.Shortname;
                return listaEmpl.ToList();
            }
        }

        public static List<string> DisponibleCobranza()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaEmpl = from x in db.T0087_HHRR_DISPONIBILIDAD
                    where x.T0085_HHRR_PERSONAL_BASIC.Activo == true && x.Cobranza
                    select x.Shortname;
                return listaEmpl.ToList();
            }
        }

        public static List<string> DisponibleIngresoIc()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaEmpl = from x in db.T0087_HHRR_DISPONIBILIDAD
                    where x.T0085_HHRR_PERSONAL_BASIC.Activo == true && x.IngresoIC
                    select x.Shortname;
                return listaEmpl.ToList();
            }
        }

        public static List<string> DisponibleVendedor()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaEmpl = from x in db.T0087_HHRR_DISPONIBILIDAD
                    where x.T0085_HHRR_PERSONAL_BASIC.Activo == true && x.Operario
                    select x.Shortname;
                return listaEmpl.ToList();
            }
        }

        public static List<string> AutorizaSinCargo()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaEmpl = from x in db.T0087_HHRR_DISPONIBILIDAD
                    where x.T0085_HHRR_PERSONAL_BASIC.Activo == true && x.AutorizaSinCargo
                    select x.Shortname;
                return listaEmpl.ToList();
            }
        }

        public static List<string> ListadoCompletoEmpleados(bool soloActivos = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloActivos)
                {
                    var listaEmpl = from x in db.T0085_HHRR_PERSONAL_BASIC
                        where x.Activo == true
                        select x.Shortname;
                    return listaEmpl.ToList();
                }
                else
                {
                    var listaEmpl = from x in db.T0085_HHRR_PERSONAL_BASIC
                        select x.Shortname;
                    return listaEmpl.ToList();
                }
            }
        }
    }
}
