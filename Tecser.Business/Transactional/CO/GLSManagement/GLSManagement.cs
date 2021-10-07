using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.TOOLS;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.GLSManagement
{
    public class RetornoDh
    {
        public string Periodo;
        public string TipoLx;
        public decimal Debe;
        public decimal Haber;
    }

    public class GLSManagement
    {

        public RetornoDh SaldoCuentaGL(string periodoI, string periodoF, string tipoLx, string cuentaGL)
        {
            RetornoDh rtn = new RetornoDh()
            {
                Periodo = null,
                TipoLx = tipoLx,
                Debe = 0,
                Haber = 0,
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                string periodoGet = periodoI;
                switch (tipoLx)
                {
                    case "L1":
                    case "L2":
                        while (Convert.ToInt32(periodoGet) <= Convert.ToInt32(periodoF))
                        {
                            var data = db.T0602_DOCU_S
                                .Select(i => new { i.PERIODO, i.GL, i.TIPO, i.DEBE, i.HABER })
                                .Where(c => c.PERIODO == periodoGet && c.GL == cuentaGL && c.TIPO == tipoLx).ToList();

                            if (data.Any())
                            {
                                rtn.Debe += data.Sum(c => c.DEBE.Value);
                                rtn.Haber += data.Sum(c => c.HABER.Value);
                            }

                            periodoGet = new PeriodoConversion().GetProximoPeriodo(periodoGet);
                        }
                        return rtn;
                    case "L3":
                        while (Convert.ToInt32(periodoGet) <= Convert.ToInt32(periodoF))
                        {
                            var data = db.T0602_DOCU_S
                                .Select(i => new { i.PERIODO, i.GL, i.TIPO, i.DEBE, i.HABER })
                                .Where(c => c.PERIODO == periodoGet && c.GL == cuentaGL).ToList();

                            if (data.Any())
                            {
                                rtn.Debe += data.Sum(c => c.DEBE.Value);
                                rtn.Haber += data.Sum(c => c.HABER.Value);
                            }
                            periodoGet = new PeriodoConversion().GetProximoPeriodo(periodoGet);
                        }
                        return rtn;

                }
            }
            return rtn;
        }
        public List<T0602_DOCU_S> VerDetalleMovimientoGL(string periodoI, string periodoF, string tipoLx, string GL,
            bool acumulaHijos)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lreturn = new List<T0602_DOCU_S>();
                var dataDb = new List<T0602_DOCU_S>();
                string periodoGet = periodoI;
                switch (tipoLx)
                {
                    case "L1":
                    case "L2":
                        while (Convert.ToInt32(periodoGet) <= Convert.ToInt32(periodoF))
                        {
                            if (!acumulaHijos)
                            {
                                dataDb = db.T0602_DOCU_S
                                    .Where(c => c.PERIODO == periodoGet && c.TIPO == tipoLx && c.GL == GL).ToList();
                            }
                            else
                            {
                                dataDb = db.T0602_DOCU_S
                                    .Where(c => c.PERIODO == periodoGet && c.TIPO == tipoLx && c.GL.StartsWith(GL))
                                    .ToList();
                            }
                            lreturn.AddRange(dataDb);
                            periodoGet = new PeriodoConversion().GetProximoPeriodo(periodoGet);
                        }
                        break;
                    case "L3":
                        while (Convert.ToInt32(periodoGet) <= Convert.ToInt32(periodoF))
                        {
                            if (!acumulaHijos)
                            {
                                dataDb = db.T0602_DOCU_S
                                    .Where(c => c.PERIODO == periodoGet && c.GL == GL).ToList();
                            }
                            else
                            {
                                dataDb = db.T0602_DOCU_S
                                    .Where(c => c.PERIODO == periodoGet && c.GL.StartsWith(GL))
                                    .ToList();
                            }
                            lreturn.AddRange(dataDb);
                            periodoGet = new PeriodoConversion().GetProximoPeriodo(periodoGet);
                        }
                        break;
                    default:
                        //Return everything
                        break;

                }

                return lreturn;
            }
        }

        private string[] glSplit;
        private string lx;


        private void AddTreeLevel0(string gl, string descripcionCuenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id = db.T0136_GLTREE.Any() == false ? 1 : db.T0136_GLTREE.Max(c => c.ID) + 1;
                var dataTree = new T0136_GLTREE()
                {
                    ID = id,
                    L0 = gl,
                    T0 = descripcionCuenta,
                    TipoLX = lx,
                    TreeLevel = 0,
                    GLAccount = gl,
                    GLDescripcion = descripcionCuenta
                };
                db.T0136_GLTREE.Add(dataTree);
                db.SaveChanges();
            }
        }
        private void AddTreeLevel1(string gl, string descripcionCuenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id = db.T0136_GLTREE.Any() == false ? 1 : db.T0136_GLTREE.Max(c => c.ID) + 1;
                var dataTree = new T0136_GLTREE()
                {
                    ID = id,
                    L1 = gl,
                    T1 = descripcionCuenta,
                    TipoLX = lx,
                    TreeLevel = 1,
                    GLAccount = gl,
                    GLDescripcion = descripcionCuenta
                };
                db.T0136_GLTREE.Add(dataTree);
                db.SaveChanges();
            }
        }
        private void AddTreeLevel2(string gl, string descripcionCuenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id = db.T0136_GLTREE.Any() == false ? 1 : db.T0136_GLTREE.Max(c => c.ID) + 1;
                var dataTree = new T0136_GLTREE()
                {
                    ID = id,
                    L2 = gl,
                    T2 = descripcionCuenta,
                    TipoLX = lx,
                    TreeLevel = 2,
                    GLAccount = gl,
                    GLDescripcion = descripcionCuenta
                };
                db.T0136_GLTREE.Add(dataTree);
                db.SaveChanges();
            }
        }
        private void AddTreeLevel3(string gl, string descripcionCuenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id = db.T0136_GLTREE.Any() == false ? 1 : db.T0136_GLTREE.Max(c => c.ID) + 1;
                var dataTree = new T0136_GLTREE()
                {
                    ID = id,
                    L3 = gl,
                    T3 = descripcionCuenta,
                    TipoLX = lx,
                    TreeLevel = 3,
                    GLAccount = gl,
                    GLDescripcion = descripcionCuenta
                };
                db.T0136_GLTREE.Add(dataTree);
                db.SaveChanges();
            }
        }
        private void AddTreeLevel4(string gl, string descripcionCuenta)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var id = db.T0136_GLTREE.Any() == false ? 1 : db.T0136_GLTREE.Max(c => c.ID) + 1;
                var dataTree = new T0136_GLTREE()
                {
                    ID = id,
                    L4 = gl,
                    T4 = descripcionCuenta,
                    TipoLX = lx,
                    TreeLevel = 4,
                    GLAccount = gl,
                    GLDescripcion = descripcionCuenta
                };
                db.T0136_GLTREE.Add(dataTree);
                db.SaveChanges();
            }
        }
        //
        private void AddRamaPadreLevel0()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var gl = glSplit[0];
                var dataL0 = db.T0130_GLL0.SingleOrDefault(c => c.IDC == gl);
                AddTreeLevel0(gl, dataL0.CUENTA_D);
            }
        }
        private void AddRamaPadreLevel1()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var glc = glSplit[0] + "." + glSplit[1];
                var dataL1 = db.T0131_GLL1.SingleOrDefault(c => c.IDC == glc);
                AddTreeLevel1(glc, dataL1.CUENTA_D);
            }
        }
        private void AddRamaPadreLevel2()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var glc = glSplit[0] + "." + glSplit[1] + "." + glSplit[2];
                var dataL = db.T0132_GLL2.SingleOrDefault(c => c.IDC == glc);
                AddTreeLevel2(glc, dataL.CUENTA_D);
            }
        }
        private void AddRamaPadreLevel3()
        {
            var glc = glSplit[0] + "." + glSplit[1] + "." + glSplit[2] + "." + glSplit[3];
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataL = db.T0133_GLL3.SingleOrDefault(c => c.IDC == glc);
                AddTreeLevel3(glc, dataL.CUENTA_D);
            }
        }
        private void AddRamaPadreLevel4()
        {
            var glc = glSplit[0] + "." + glSplit[1] + "." + glSplit[2] + "." + glSplit[3] + "." + glSplit[4];
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataL = db.T0134_GLL4.SingleOrDefault(c => c.IDC == glc);
                AddTreeLevel4(glc, dataL.CUENTA_D);
            }
        }
        //
        private void AddRamaHijosLevel1()
        {
            int l0 = Convert.ToInt32(glSplit[0]);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0131_GLL1.Where(c => c.IDL0 == l0).ToList();
                foreach (var data in d)
                {
                    AddTreeLevel1(data.IDC, data.CUENTA_D);
                    var dlev2 = db.T0132_GLL2.Where(c => c.IDL0 == l0 && c.IDL1 == data.IDL1).ToList();
                    foreach (var d02 in dlev2)
                    {
                        AddTreeLevel2(d02.IDC, d02.CUENTA_D);
                        var dlev3 = db.T0133_GLL3.Where(c => c.IDL0 == l0 && c.IDL1 == data.IDL1 && c.IDL2 == d02.IDL2).ToList();
                        foreach (var d00 in dlev3)
                        {
                            AddTreeLevel3(d00.IDC, d00.CUENTA_D);
                            var dlev4 = db.T0134_GLL4.Where(c => c.IDL0 == l0 && c.IDL1 == data.IDL1 && c.IDL2 == d02.IDL2 && c.IDL3 == d00.IDL3).ToList();
                            foreach (var dl4 in dlev4)
                            {
                                AddTreeLevel4(dl4.IDC, dl4.CUENTA_D);
                            }
                        }
                    }
                }
            }
        }
        private void AddRamaHijosLevel2()
        {
            int l0 = Convert.ToInt32(glSplit[0]);
            int l1 = Convert.ToInt32(glSplit[1]);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0132_GLL2.Where(c => c.IDL0 == l0 && c.IDL1 == l1).ToList();
                foreach (var data in d)
                {
                    AddTreeLevel2(data.IDC, data.CUENTA_D);
                    var dlev3 = db.T0133_GLL3.Where(c => c.IDL0 == l0 && c.IDL1 == l1 && c.IDL2 == data.IDL2).ToList();
                    foreach (var d00 in dlev3)
                    {
                        AddTreeLevel3(d00.IDC, d00.CUENTA_D);
                        var dlev4 = db.T0134_GLL4.Where(c => c.IDL0 == l0 && c.IDL1 == l1 && c.IDL2 == data.IDL2 && c.IDL3 == d00.IDL3).ToList();
                        foreach (var dl4 in dlev4)
                        {
                            AddTreeLevel4(dl4.IDC, dl4.CUENTA_D);
                        }
                    }
                }
            }
        }
        private void AddRamaHijosLevel3()
        {
            int l0 = Convert.ToInt32(glSplit[0]);
            int l1 = Convert.ToInt32(glSplit[1]);
            int l2 = Convert.ToInt32(glSplit[2]);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0133_GLL3.Where(c => c.IDL0 == l0 && c.IDL1 == l1 && c.IDL2 == l2).ToList();
                foreach (var data in d)
                {
                    AddTreeLevel3(data.IDC, data.CUENTA_D);
                    var d0 = db.T0134_GLL4
                        .Where(c => c.IDL0 == l0 && c.IDL1 == l1 && c.IDL2 == l2 && c.IDL3 == data.IDL3).ToList();
                    foreach (var d00 in d0)
                    {
                        AddTreeLevel4(d00.IDC, d00.CUENTA_D);
                    }
                }
            }
        }
        private void AddRamaHijosLevel4()
        {
            int l0 = Convert.ToInt32(glSplit[0]);
            int l1 = Convert.ToInt32(glSplit[1]);
            int l2 = Convert.ToInt32(glSplit[2]);
            int l3 = Convert.ToInt32(glSplit[3]);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var d = db.T0134_GLL4.Where(c => c.IDL0 == l0 && c.IDL1 == l1 && c.IDL2 == l2 && c.IDL3 == l3).ToList();
                foreach (var data in d)
                {
                    AddTreeLevel4(data.IDC, data.CUENTA_D);
                }
            }
        }


        private void PopulateTree(string periodoI, string periodoF)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var tree = db.T0136_GLTREE.OrderByDescending(c => c.ID).ToList();
                int levelAnterior = 0;
                decimal[] dAcumulado = { 0m, 0m, 0m, 0m, 0m };
                decimal[] hAcumulado = { 0m, 0m, 0m, 0m, 0m };
                //
                foreach (var d in tree)
                {
                    var saldo = SaldoCuentaGL(periodoI, periodoF, lx, d.GLAccount);
                    d.D0 = saldo.Debe;
                    d.H0 = saldo.Haber;
                    d.S0 = saldo.Debe - saldo.Haber;
                    dAcumulado[d.TreeLevel.Value] += saldo.Debe;
                    hAcumulado[d.TreeLevel.Value] += saldo.Haber;

                    if (d.TreeLevel < levelAnterior)
                    {
                        d.DACC = d.D0 + dAcumulado[levelAnterior];
                        d.HACC = d.H0 + hAcumulado[levelAnterior];

                        dAcumulado[d.TreeLevel.Value] += dAcumulado[levelAnterior];
                        hAcumulado[d.TreeLevel.Value] += hAcumulado[levelAnterior];
                        dAcumulado[levelAnterior] = 0m;
                        hAcumulado[levelAnterior] = 0m;

                    }
                    else
                    {
                        d.DACC = d.D0.Value;
                        d.HACC = d.H0.Value;
                    }
                    levelAnterior = d.TreeLevel.Value;
                    db.SaveChanges();
                }
            }

            MessageBox.Show(@"Termine");
        }
        public void Tree(string glCheck, string periodoInicial, string periodoFinal, string tipoLx)
        {
            lx = tipoLx;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //Remueve info existente
                var x = db.T0136_GLTREE.ToList();
                db.T0136_GLTREE.RemoveRange(x);
                db.SaveChanges();

                glSplit = glCheck.Split('.');
#pragma warning disable CS0168 // La variable 'gl0' se ha declarado pero nunca se usa
                string gl0;
#pragma warning restore CS0168 // La variable 'gl0' se ha declarado pero nunca se usa
#pragma warning disable CS0168 // La variable 'gl1' se ha declarado pero nunca se usa
                string gl1;
#pragma warning restore CS0168 // La variable 'gl1' se ha declarado pero nunca se usa
#pragma warning disable CS0168 // La variable 'gl2' se ha declarado pero nunca se usa
                string gl2;
#pragma warning restore CS0168 // La variable 'gl2' se ha declarado pero nunca se usa
#pragma warning disable CS0168 // La variable 'gl3' se ha declarado pero nunca se usa
                string gl3;
#pragma warning restore CS0168 // La variable 'gl3' se ha declarado pero nunca se usa
#pragma warning disable CS0168 // La variable 'gl4' se ha declarado pero nunca se usa
                string gl4;
#pragma warning restore CS0168 // La variable 'gl4' se ha declarado pero nunca se usa

                int levelInicial = glSplit.GetUpperBound(0);
#pragma warning disable CS0219 // La variable 'levelMax' está asignada pero su valor nunca se usa
                int levelMax = 4; //maximo nivel de la estructura en (base 0)
#pragma warning restore CS0219 // La variable 'levelMax' está asignada pero su valor nunca se usa
#pragma warning disable CS0168 // La variable 'glAdd' se ha declarado pero nunca se usa
                string glAdd;
#pragma warning restore CS0168 // La variable 'glAdd' se ha declarado pero nunca se usa
                string descripcionCuentaCheck;


                //Agrega las Ramas Padre (desde el GL que se consulta hacia arriba => Level 0)
                switch (levelInicial)
                {
                    case 0:
                        descripcionCuentaCheck = db.T0130_GLL0.SingleOrDefault(c => c.IDC == glCheck).CUENTA_D;
                        AddTreeLevel0(glCheck, descripcionCuentaCheck);
                        AddRamaHijosLevel1();
                        break;
                    case 1:
                        //ok
                        AddRamaPadreLevel0();
                        descripcionCuentaCheck = db.T0131_GLL1.SingleOrDefault(c => c.IDC == glCheck).CUENTA_D;
                        AddTreeLevel1(glCheck, descripcionCuentaCheck);
                        AddRamaHijosLevel2();
                        break;
                    case 2:
                        //ok
                        AddRamaPadreLevel0();
                        AddRamaPadreLevel1();
                        descripcionCuentaCheck = db.T0132_GLL2.SingleOrDefault(c => c.IDC == glCheck).CUENTA_D;
                        AddTreeLevel2(glCheck, descripcionCuentaCheck);
                        AddRamaHijosLevel3();
                        break;
                    case 3:
                        AddRamaPadreLevel0();
                        AddRamaPadreLevel1();
                        AddRamaPadreLevel2();
                        descripcionCuentaCheck = db.T0133_GLL3.SingleOrDefault(c => c.IDC == glCheck).CUENTA_D;
                        AddTreeLevel3(glCheck, descripcionCuentaCheck);
                        AddRamaHijosLevel4();
                        break;
                    case 4:
                        AddRamaPadreLevel0();
                        AddRamaPadreLevel1();
                        AddRamaPadreLevel2();
                        AddRamaPadreLevel3();
                        descripcionCuentaCheck = db.T0134_GLL4.SingleOrDefault(c => c.IDC == glCheck).CUENTA_D;
                        AddTreeLevel4(glCheck, descripcionCuentaCheck);
                        break;
                    default:
                        break;
                }
            }
            PopulateTree(periodoInicial, periodoFinal);
            MessageBox.Show(@"OK");
        }
        public List<T0136_GLTREE> GetTreeGenerated()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0136_GLTREE.OrderBy(c => c.ID).ToList();
            }
        }
    }
}
