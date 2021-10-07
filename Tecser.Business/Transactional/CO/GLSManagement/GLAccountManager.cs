using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.GLSManagement
{
    public class GLAccountManager
    {

        //---------------------------------------------------------------------------------------------------
        // Level 0
        //---------------------------------------------------------------------------------------------------
        public List<T0130_GLL0> GetAllLevel0(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0130_GLL0.ToList();
                return db.T0130_GLL0.ToList();
            }
        }
        public T0130_GLL0 GetLevel0(int l0)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0130_GLL0.SingleOrDefault(c => c.IDL0 == l0);
            }
        }
        public void UpdateLevel0(T0130_GLL0 header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0130_GLL0.SingleOrDefault(c => c.IDL0 == header.IDL0);
                db.Entry(data).CurrentValues.SetValues(header);
                db.SaveChanges();
            }
        }

        //---------------------------------------------------------------------------------------------------
        // Level 1
        //---------------------------------------------------------------------------------------------------
        public List<T0131_GLL1> GetAllLevel1(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0131_GLL1.Where(c => c.ACTIVO.Value).ToList();
                return db.T0131_GLL1.ToList();
            }
        }
        public List<T0131_GLL1> GetAllLevel1DefinedByPreviousLevel(int idLevel0, bool onlyActive = false)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0131_GLL1.Where(c => c.IDL0 == idLevel0 && c.ACTIVO.Value).ToList();
                return db.T0131_GLL1.Where(c => c.IDL0 == idLevel0).ToList();
            }
        }
        public T0131_GLL1 GetLevel1(string idc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0131_GLL1.SingleOrDefault(c => c.IDC == idc);
            }
        }
        public void UpdateLevel1(T0131_GLL1 header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0131_GLL1.SingleOrDefault(c => c.IDC == header.IDC);
                db.Entry(data).CurrentValues.SetValues(header);
                db.SaveChanges();
            }
        }

        //---------------------------------------------------------------------------------------------------
        // Level 2
        //---------------------------------------------------------------------------------------------------
        public List<T0132_GLL2> GetAllLevel2(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0132_GLL2.Where(c => c.ACTIVO.Value).ToList();
                return db.T0132_GLL2.ToList();
            }
        }
        public List<T0132_GLL2> GetAllLevel2DefinedByPreviousLevel(string idcPreviousLevel, bool onlyActive = false)
        {
            string idcx = idcPreviousLevel + '.';
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0132_GLL2.Where(c => c.IDC.StartsWith(idcx) && c.ACTIVO.Value).ToList();
                return db.T0132_GLL2.Where(c => c.IDC.StartsWith(idcx)).ToList();
            }
        }
        public T0132_GLL2 GetLevel2(string idc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0132_GLL2.SingleOrDefault(c => c.IDC == idc);
            }
        }
        public void UpdateLevel2(T0132_GLL2 header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0132_GLL2.SingleOrDefault(c => c.IDC == header.IDC);
                db.Entry(data).CurrentValues.SetValues(header);
                db.SaveChanges();
            }
        }

        //---------------------------------------------------------------------------------------------------
        // Level 3
        //---------------------------------------------------------------------------------------------------
        public List<T0133_GLL3> GetAllLevel3(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0133_GLL3.Where(c => c.ACTIVO.Value).ToList();
                return db.T0133_GLL3.ToList();
            }
        }
        public List<T0133_GLL3> GetAllLevel3DefinedByPreviousLevel(string idcPreviousLevel, bool onlyActive = false)
        {
            string idcx = idcPreviousLevel + '.';
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0133_GLL3.Where(c => c.IDC.StartsWith(idcx) && c.ACTIVO.Value).ToList();
                return db.T0133_GLL3.Where(c => c.IDC.StartsWith(idcx)).ToList();
            }
        }
        public T0133_GLL3 GetLevel3(string idc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0133_GLL3.SingleOrDefault(c => c.IDC == idc);
            }
        }
        public void UpdateLevel3(T0133_GLL3 header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0133_GLL3.SingleOrDefault(c => c.IDC == header.IDC);
                db.Entry(data).CurrentValues.SetValues(header);
                db.SaveChanges();
            }
        }

        //---------------------------------------------------------------------------------------------------
        // Level 4
        //---------------------------------------------------------------------------------------------------
        public List<T0134_GLL4> GetAllLevel4(bool onlyActive = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0134_GLL4.Where(c => c.ACTIVO.Value).ToList();
                return db.T0134_GLL4.ToList();
            }
        }
        public List<T0134_GLL4> GetAllLevel4DefinedByPreviousLevel(string idcPreviousLevel, bool onlyActive = false)
        {
            string idcx = idcPreviousLevel + '.';
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (onlyActive)
                    return db.T0134_GLL4.Where(c => c.IDC.StartsWith(idcx) && c.ACTIVO.Value).ToList();
                return db.T0134_GLL4.Where(c => c.IDC.StartsWith(idcx)).ToList();
            }
        }
        public T0134_GLL4 GetLevel4(string idc)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0134_GLL4.SingleOrDefault(c => c.IDC == idc);
            }
        }
        public void UpdateLevel4(T0134_GLL4 header)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0134_GLL4.SingleOrDefault(c => c.IDC == header.IDC);
                db.Entry(data).CurrentValues.SetValues(header);
                db.SaveChanges();
            }
        }


        private void AddRecordT135(string gl, string descripcion, bool imputaS, bool imputaN,
            bool cuentaActiva, bool imputaManual, string mapeoAlternativo, bool revision)
        {
            string[] glz = gl.Split('.');
            int gllevel = glz.GetUpperBound(0);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = new T0135_GLX()
                {
                    IDC2 = mapeoAlternativo,
                    GL = gl,
                    NIVEL = gllevel.ToString(),
                    ACTIVA = cuentaActiva,
                    GLDESC = descripcion,
                    GLX = glz[gllevel],
                    IMPU_MANUAL = imputaManual,
                    IMPU_N = imputaN,
                    IMPU_S = imputaS,
                    REVISION = revision,
                };
                db.T0135_GLX.Add(data);
                db.SaveChanges();
            }
        }

        public void GenerateNewTree135()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {

                //Nivel4
                var level = db.T0134_GLL4.ToList();
                var t135 = db.T0135_GLX.Where(c => c.NIVEL == "4").ToList();

                //clear revision en all T135 table
                t135.Select(c => { c.REVISION = false; return c; }).ToList();
                db.SaveChanges();
                foreach (var d in level)
                {
                    var d135 = db.T0135_GLX.SingleOrDefault(c => c.GL == d.IDC);
                    if (d135 == null)
                    {
                        AddRecordT135(d.IDC, d.CUENTA_D, false, false, d.ACTIVO.Value, d.PI.Value, d.IDC2, true);
                    }
                    else
                    {
                        d135.IDC2 = d.IDC2;
                        d135.ACTIVA = d.ACTIVO;
                        d135.GLDESC = d.CUENTA_D;
                        d135.IMPU_MANUAL = d.PI.Value;
                        d135.REVISION = true;
                        db.SaveChanges();
                    }
                }

                //Nivel3
                var level3 = db.T0133_GLL3.ToList();
                t135 = db.T0135_GLX.Where(c => c.NIVEL == "3").ToList();

                //clear revision en all T135 table
                t135.Select(c => { c.REVISION = false; return c; }).ToList();
                db.SaveChanges();
                foreach (var d in level3)
                {
                    var d135 = db.T0135_GLX.SingleOrDefault(c => c.GL == d.IDC);
                    if (d135 == null)
                    {
                        AddRecordT135(d.IDC, d.CUENTA_D, false, false, d.ACTIVO.Value, d.PI.Value, d.IDC2, true);
                    }
                    else
                    {
                        d135.IDC2 = d.IDC2;
                        d135.ACTIVA = d.ACTIVO;
                        d135.GLDESC = d.CUENTA_D;
                        d135.IMPU_MANUAL = d.PI.Value;
                        d135.REVISION = true;
                        db.SaveChanges();
                    }
                }

                //Nivel2
                var level2 = db.T0132_GLL2.ToList();
                t135 = db.T0135_GLX.Where(c => c.NIVEL == "2").ToList();

                //clear revision en all T135 table
                t135.Select(c => { c.REVISION = false; return c; }).ToList();
                db.SaveChanges();
                foreach (var d in level2)
                {
                    var d135 = db.T0135_GLX.SingleOrDefault(c => c.GL == d.IDC);
                    if (d135 == null)
                    {
                        AddRecordT135(d.IDC, d.CUENTA_D, false, false, d.ACTIVO.Value, d.PI.Value, d.IDC2, true);
                    }
                    else
                    {
                        d135.IDC2 = d.IDC2;
                        d135.ACTIVA = d.ACTIVO;
                        d135.GLDESC = d.CUENTA_D;
                        d135.IMPU_MANUAL = d.PI.Value;
                        d135.REVISION = true;
                        db.SaveChanges();
                    }
                }

                //Nivel1
                var level1 = db.T0131_GLL1.ToList();
                t135 = db.T0135_GLX.Where(c => c.NIVEL == "1").ToList();

                //clear revision en all T135 table
                t135.Select(c => { c.REVISION = false; return c; }).ToList();
                db.SaveChanges();
                foreach (var d in level1)
                {
                    var d135 = db.T0135_GLX.SingleOrDefault(c => c.GL == d.IDC);
                    if (d135 == null)
                    {
                        AddRecordT135(d.IDC, d.CUENTA_D, false, false, d.ACTIVO.Value, d.PI.Value, d.IDC2, true);
                    }
                    else
                    {
                        d135.IDC2 = d.IDC2;
                        d135.ACTIVA = d.ACTIVO;
                        d135.GLDESC = d.CUENTA_D;
                        d135.IMPU_MANUAL = d.PI.Value;
                        d135.REVISION = true;
                        db.SaveChanges();
                    }
                }


                //Nivel0
                var level0 = db.T0130_GLL0.ToList();
                t135 = db.T0135_GLX.Where(c => c.NIVEL == "0").ToList();

                //clear revision en all T135 table
                t135.Select(c => { c.REVISION = false; return c; }).ToList();
                db.SaveChanges();
                foreach (var d in level0)
                {
                    var d135 = db.T0135_GLX.SingleOrDefault(c => c.GL == d.IDC);
                    if (d135 == null)
                    {
                        AddRecordT135(d.IDC, d.CUENTA_D, false, false, true, false, d.IDC2, true);
                    }
                    else
                    {
                        d135.IDC2 = d.IDC2;
                        d135.ACTIVA = true;
                        d135.GLDESC = d.CUENTA_D;
                        d135.IMPU_MANUAL = false;
                        d135.REVISION = true;
                        db.SaveChanges();
                    }
                }



            }
        }
    }


}
