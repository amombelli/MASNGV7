using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;

namespace Tecser.Business.SuperMD
{
    public class GlAccountStructureManager
    {
        public GlAccountStructureManager()
        {

        }
        /// <summary>
        /// Validar una estructura parcial para dar de alta solo el ultimo nivel
        /// </summary>
        public bool ValidaGLStructure(string glAccount)
        {
            string[] tokens = glAccount.Split('.');
            int nivel = 0;
            int cuenta0;
            int cuenta1;
            int cuenta2;
            int cuenta3;
            int cuenta4;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                foreach (var gl in tokens)
                {
                    switch (nivel)
                    {
                        case 0:
                            cuenta0 = Convert.ToInt32(tokens[0]);
                            var l0 = db.T0130_GLL0.SingleOrDefault(c => c.IDL0 == cuenta0);
                            if (l0 == null)
                                return false;
                            break;
                        case 1:
                            cuenta0 = Convert.ToInt32(tokens[0]);
                            cuenta1 = Convert.ToInt32(tokens[1]);
                            var l1 = db.T0131_GLL1.SingleOrDefault(c => c.IDL0 == cuenta0 && c.IDL1 == cuenta1);
                            if (l1 == null)
                                return false;
                            break;
                        case 2:
                            cuenta0 = Convert.ToInt32(tokens[0]);
                            cuenta1 = Convert.ToInt32(tokens[1]);
                            cuenta2 = Convert.ToInt32(tokens[2]);
                            var l2 =
                                db.T0132_GLL2.SingleOrDefault(
                                    c => c.IDL0 == cuenta0 && c.IDL1 == cuenta1 && c.IDL2 == cuenta2);
                            if (l2 == null)
                                return false;
                            break;
                        case 3:
                            cuenta0 = Convert.ToInt32(tokens[0]);
                            cuenta1 = Convert.ToInt32(tokens[1]);
                            cuenta2 = Convert.ToInt32(tokens[2]);
                            cuenta3 = Convert.ToInt32(tokens[3]);
                            var l3 =
                                db.T0133_GLL3.SingleOrDefault(
                                    c =>
                                        c.IDL0 == cuenta0 && c.IDL1 == cuenta1 && c.IDL2 == cuenta2 && c.IDL3 == cuenta3);
                            if (l3 == null)
                                return false;
                            break;
                        case 4:
                            cuenta0 = Convert.ToInt32(tokens[0]);
                            cuenta1 = Convert.ToInt32(tokens[1]);
                            cuenta2 = Convert.ToInt32(tokens[2]);
                            cuenta3 = Convert.ToInt32(tokens[3]);
                            cuenta4 = Convert.ToInt32(tokens[4]);
                            var l4 =
                                db.T0134_GLL4.SingleOrDefault(
                                    c =>
                                        c.IDL0 == cuenta0 && c.IDL1 == cuenta1 && c.IDL2 == cuenta2 && c.IDL3 == cuenta3 &&
                                        c.IDL4 == cuenta4);
                            if (l4 == null)
                                return false;
                            break;
                    }
                    nivel++;
                }
            }
            return true;
        }

        public bool CreateNewGLAccount(string glAccount, string descripcion)
        {
            string[] tokens = glAccount.Split('.');
            var niveles = tokens.GetUpperBound(0) + 1;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var glx = db.T0135_GLX.SingleOrDefault(c => c.GL.Equals(glAccount));
                if (glx != null)
                {
                    //La cuenta ya existe
                    return false;
                }
                else
                {
                    //valida la cuenta al nivel n-1 para validar la estructura esta OK
                    string cuentaValidar = null;
                    for (int i = 0; i < (niveles - 1); i++)
                    {
                        if (string.IsNullOrEmpty(cuentaValidar))
                        {
                            cuentaValidar = tokens[i];
                        }
                        else
                        {
                            cuentaValidar = cuentaValidar + "." + tokens[i];
                        }
                    }
                    if (ValidaGLStructure(cuentaValidar) == false)
                    {
                        return false;
                    }
                    else
                    {
                        //crear el ultimo nivel + GLX
                        CreaUltimoNivel(glAccount, descripcion, true);
                    }

                    //Crear la cuenta
                }
            }
            return true;
        }

        private bool CreaUltimoNivel(string glAccount, string descripcion, bool pi = false)
        {
            string[] tokens = glAccount.Split('.');
            var ultimoNivel = tokens.GetUpperBound(0);
            var glCrear = tokens[ultimoNivel];
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                switch (ultimoNivel)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        var l3 = new T0133_GLL3()
                        {
                            ACTIVO = true,
                            IDL0 = Convert.ToInt32(tokens[0]),
                            IDL1 = Convert.ToInt32(tokens[1]),
                            IDL2 = Convert.ToInt32(tokens[2]),
                            IDL3 = Convert.ToInt32(tokens[3]),
                            IDC = glAccount,
                            CUENTA_D = descripcion,
                            IDC2 = null, //cuenta raffone
                            PI = pi,
                            SM = false
                        };
                        var data = db.T0133_GLL3.Add(l3);
                        if (db.SaveChanges() == 0)
                            return false;
                        break;
                    case 4:
                        break;
                }
                var data135 = new T0135_GLX()
                {
                    ACTIVA = true,
                    GL = glAccount,
                    IDC2 = null,
                    GLDESC = descripcion,
                    GLX = glCrear,
                    IMPU_MANUAL = pi,
                    IMPU_N = true,
                    IMPU_S = false,
                    NIVEL = (ultimoNivel + 1).ToString(),
                    REVISION = true,
                };
                db.T0135_GLX.Add(data135);
                return db.SaveChanges() > 0;
            }
        }


        public List<T0130_GLL0> GetListLevel0()
        {
            return new Repository<T0130_GLL0>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        public List<T0131_GLL1> GetListLevel1()
        {
            return new Repository<T0131_GLL1>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        public List<T0132_GLL2> GetListLevel2()
        {
            return new Repository<T0132_GLL2>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        public List<T0133_GLL3> GetListLevel3()
        {
            return new Repository<T0133_GLL3>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        public List<T0134_GLL4> GetListLevel4()
        {
            return new Repository<T0134_GLL4>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        /// <summary>
        /// Lista completa de GL Aprobados para ser usados (permiten imputacion)
        /// Tabla 135
        /// </summary>
        /// <returns></returns>
        public List<T0135_GLX> GetCompleteListaGL()
        {
            return new Repository<T0135_GLX>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        /// <summary>
        /// Retorna el listado de todas las GL que contienen la palabra provista en su descripcion
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<T0135_GLX> GetDataContains(string text)
        {
            var data =
                new Repository<T0135_GLX>(new TecserData(GlobalApp.CnnApp)).GetAll()
                    .Where(c => c.GLDESC.ToLower().Contains(text.ToLower())).ToList();

            return data;

        }

        public string GetGLDescription(string cuentaGL)
        {
            var data = new Repository<T0135_GLX>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.GL.Trim() == cuentaGL);
            if (data == null)
                return "GL No Encontrada";
            return data.GLDESC;
        }
    }
}
