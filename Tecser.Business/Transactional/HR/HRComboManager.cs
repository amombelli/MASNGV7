using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.HR
{

    /// <summary>
    /// Manejo de los combos y nombres disponibles
    /// </summary>
    public class HRComboManager
    {
        public void Addfuncion(string funcion, string descripcion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0091_HHRR_COMBOCODE.SingleOrDefault(c => c.ComboCode.ToUpper().Equals(funcion.ToUpper()));
                if (x == null)
                {
                    var t = new T0091_HHRR_COMBOCODE
                    {
                        ComboCode = funcion.ToUpper(),
                        DescripcionPermiso = descripcion,
                    };
                    db.T0091_HHRR_COMBOCODE.Add(t);
                    db.SaveChanges();
                }
                else
                {
                    x.DescripcionPermiso = descripcion;
                    db.SaveChanges();
                }
            }
        }
        public static void DeleteAsignacion(string shortname, string funcion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0092_HHRR_COMBOASSIGN.SingleOrDefault(c =>
                    c.Shortname.ToUpper()
                        .Equals(shortname.ToUpper()) && c.ComboCode.ToUpper().Equals(funcion.ToUpper()));

                if (x != null)
                {
                    db.T0092_HHRR_COMBOASSIGN.Remove(x);
                    db.SaveChanges();
                }
            }
        }
        public void AddAsignacion(string shortname, string funcion,bool valor=true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0092_HHRR_COMBOASSIGN.SingleOrDefault(c =>
                    c.Shortname.ToUpper()
                        .Equals(shortname.ToUpper()) && c.ComboCode.ToUpper().Equals(funcion.ToUpper()));

                if (x == null)
                {
                    var t = new T0092_HHRR_COMBOASSIGN()
                    {
                        Shortname = shortname.ToUpper(),
                        ComboCode = funcion.ToUpper(),
                        Valor = valor
                    };
                    db.T0092_HHRR_COMBOASSIGN.Add(t);
                    db.SaveChanges();
                }
                else
                {
                    x.Valor = valor;
                    db.SaveChanges();
                }
            }
        }
        public static List<string> GetListaEmployee(string funcion,bool valor=true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var listaEmpl = from x in db.T0092_HHRR_COMBOASSIGN
                    where x.T0085_HHRR_PERSONAL_BASIC.Activo == true && x.Valor == valor &&
                          x.ComboCode == funcion.ToUpper()
                    select x.Shortname;
                return listaEmpl.ToList();
            }
        }
        public static List<T0091_HHRR_COMBOCODE> GetListaFuncionesCombo()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0091_HHRR_COMBOCODE.ToList();
            }
        }
        public static bool ExisteFuncion(string funcion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0091_HHRR_COMBOCODE.SingleOrDefault(c => c.ComboCode.ToUpper() == funcion.ToUpper());
                return r!=null;
            }
        }
        public static bool ExisteAsignacion(string funcion, string empleado)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var r = db.T0092_HHRR_COMBOASSIGN.SingleOrDefault(c =>
                    c.ComboCode.ToUpper().Equals(funcion.ToUpper()) &&
                    c.Shortname.ToUpper().Equals(empleado.ToUpper()));
                if (r == null)
                    return false;
                return true;
            }
        }
        public static List<T0092_HHRR_COMBOASSIGN> GetListaAsignacionesPorFuncion(string funcion)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0092_HHRR_COMBOASSIGN.Where(c => c.ComboCode == funcion).ToList();
            }
        }
    }
}
