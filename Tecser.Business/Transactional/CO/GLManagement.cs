using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    public class GLAccountManagement
    {
        //2018.04.10 -- Listado de GL Accounts to MAP into T0137 - En general utilizado para 
        //cuenta de impuestos, retenciones, etc.
        //Al dar de alta un nuevo tipo de GLMap se debe agregar en el enum 
        //y ademas en el mapeo de GetGLAccount de abajo
        public enum GLAccount
        {
            RetencionIIBB,
            RetencionGS,
            RetencionIVA,
            PercepcionIIBB,
            PercepcionGS,
            PercepcionIVA,
            CompraImpuestoMunicipal,
            CompraImpuestoProvincial,
            CompraImpuestoInterno,
            CompraImpuestoOtros,
            CompraImpuestoNoGravado,
            IvaVenta21,
            IvaCompra21,
            IvaCompra10,
            IvaCompra27,
            CostoMercaderiaVendida,
            DescuentoVentas,
            AR,
            DescuentoCompras,
            AP,
            RedondeoVentas,
            RedondeoCompras
        };
        public static string GetGLAccount(GLAccount glAccount)
        {
            string valorMapping = null;
            switch (glAccount)
            {
                case GLAccount.RetencionIIBB:
                    valorMapping = "RETENCIONIIBB";
                    break;
                case GLAccount.RetencionGS:
                    valorMapping = "RETENCIONGS";
                    break;
                case GLAccount.PercepcionIIBB:
                    valorMapping = "PERCEPCIONIIBB";
                    break;
                case GLAccount.PercepcionGS:
                    valorMapping = "PERCEPCIONGS";
                    break;
                case GLAccount.IvaVenta21:
                    valorMapping = "IVAVENTA21";
                    break;
                case GLAccount.IvaCompra21:
                    valorMapping = "IVACOMPRA21";
                    break;
                case GLAccount.IvaCompra10:
                    valorMapping = "IVACOMPRA10";
                    break;
                case GLAccount.IvaCompra27:
                    valorMapping = "IVACOMPRA27";
                    break;
                case GLAccount.CostoMercaderiaVendida:
                    valorMapping = "CMV";
                    break;
                case GLAccount.DescuentoVentas:
                    valorMapping = "DESCUENTOVTA";
                    break;
                case GLAccount.AR:
                    valorMapping = "AR";
                    break;
                case GLAccount.PercepcionIVA:
                    valorMapping = "PERCEPCIONIVA";
                    break;
                case GLAccount.CompraImpuestoMunicipal:
                    valorMapping = "IMP_MUNI";
                    break;
                case GLAccount.CompraImpuestoProvincial:
                    valorMapping = "IMP_PROV";
                    break;
                case GLAccount.CompraImpuestoInterno:
                    valorMapping = "IMP_INT";
                    break;
                case GLAccount.CompraImpuestoOtros:
                    valorMapping = "IMP_OTR";
                    break;
                case GLAccount.CompraImpuestoNoGravado:
                    valorMapping = "IMP_NO_GRAV";
                    break;
                case GLAccount.DescuentoCompras:
                    valorMapping = "DESC_C";
                    break;
                case GLAccount.RetencionIVA:
                    valorMapping = "RETENCIONIVA";
                    break;
                case GLAccount.AP:
                    //Cuenta AP depende del VENDOR.-
                    valorMapping = "AP"; //ojo falta completar el AP en T0137!
                    MessageBox.Show(@"falta completar el AP GL en T0137");
                    break;
                case GLAccount.RedondeoVentas:
                    valorMapping = "REDONVTA";
                    break;
                case GLAccount.RedondeoCompras:
                    valorMapping = "REDONCOMPRA";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(glAccount), glAccount, null);
            }
            var data =
                new TecserData(GlobalApp.CnnApp).T0137_GL_MAPPING.SingleOrDefault(
                    c => c.CUENTA_GEN.ToUpper().Equals(valorMapping.ToUpper()));
            return data == null ? "0.0.0.0" : data.CUENTA_MAP;
        }
        public string GetApVendorGl(int idProveedor)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataProv = new VendorManager().GetSpecificVendor(idProveedor);
                if (dataProv.id_prov == -1)
                {
                    //El Vendor no existe
                    return "0.0.0.0";
                }
                if (string.IsNullOrEmpty(dataProv.GL) == false)
                {
                    //El vendor tiene un GL especifico
                    return dataProv.GL;
                }

                var dataProvType = VendorManager.GetDataVendorType(dataProv.TIPO);
                return dataProvType.TIPOPROV != "VendorNull" ? dataProvType.GL : "0.0.0.0";
            }
        }
        public static string GetGLInventarioMaterialMaster(string materialPrimarioOrAka)
        {
            string primario;
            string tipoAka;
#pragma warning disable CS0168 // The variable 'tipoPrimario' is declared but never used
            string tipoPrimario;
#pragma warning restore CS0168 // The variable 'tipoPrimario' is declared but never used

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var materialData = db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(materialPrimarioOrAka.ToUpper()));

                if (materialData != null)
                {
                    primario = materialData.PRIMARIO;
                    tipoAka = materialData.TIPO_MATERIAL;

                    var dataTipo = db.T0011_MaterialType.SingleOrDefault(c => c.Mtype.ToUpper().Equals(tipoAka.ToUpper()));
                    if (dataTipo == null)
                        return "0.0.0.0";
                    return dataTipo.GLInvetory;
                }
                else
                {
                    //el material presentado ya es un primario y no se encuentra en T0011 como CODVENTA
                    var dataPrimario = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(materialPrimarioOrAka.ToUpper()));

                    if (dataPrimario == null)
                    {
                        return "0.0.0.0"; //Error en el material no se encuentra! (no puede ser)
                    }

                    if (!string.IsNullOrEmpty(dataPrimario.GLI))
                    {
                        return dataPrimario.GLI;
                    }
                    else
                    {
                        var dataTipo = db.T0011_MaterialType.SingleOrDefault(c => c.Mtype.ToUpper().Equals(dataPrimario.TIPO_MATERIAL.ToUpper()));
                        if (dataTipo == null)
                            return "0.0.0.0";
                        return dataTipo.GLInvetory;
                    }
                }
            }
        }

        //Si el material se vende sale de T0011
        public static string GetGLVentaMaterialMaster(string materialPrimarioOrAka)
        {
            string primario;
            string tipoAka;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var aka = db.T0011_MATERIALES_AKA.SingleOrDefault(c => c.CODVENTA.ToUpper().Equals(materialPrimarioOrAka.ToUpper()));
                if (aka != null)
                {
                    primario = aka.PRIMARIO;
                    tipoAka = aka.TIPO_MATERIAL;
                    if (aka.GLV != null)
                        return aka.GLV;  //Regresa el GLV del material en T0011.

                    var dataTipo = db.T0011_MaterialType.SingleOrDefault(c => c.Mtype.ToUpper().Equals(tipoAka.ToUpper()));
                    if (dataTipo == null)
                        return "0.0.0.0";
                    return dataTipo.GLVentas;
                }
                else
                {
                    //el material presentado ya es un primario y no se encuentra en T0011 como CODVENTA
                    var dataPrimario = db.T0010_MATERIALES.SingleOrDefault(c => c.IDMATERIAL.ToUpper().Equals(materialPrimarioOrAka.ToUpper()));
                    if (dataPrimario == null)
                    {
                        return "0.0.0.0"; //Error en el material no se encuentra! (no puede ser)
                    }
                    if (dataPrimario.GL != null)
                        return dataPrimario.GL;

                    var dataTipo = db.T0011_MaterialType.SingleOrDefault(c => c.Mtype.ToUpper().Equals(dataPrimario.TIPO_MATERIAL.ToUpper()));
                    if (dataTipo == null)
                        return "0.0.0.0";
                    return dataTipo.GLVentas;
                }
            }
        }
        public static string GetGLDescriptionFromT135(string glAccount)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0135_GLX.SingleOrDefault(c => c.GL == glAccount);
                return data == null ? "Cuenta Inexistente" : data.GLDESC;
            }
        }
        public List<T0135_GLX> GetGLListPermiteImputacion()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0135_GLX.Where(c => c.IMPU_MANUAL.Value == true && c.ACTIVA.Value == true).ToList();
            }
        }

        public List<T0135_GLX> GetGLAllforGLS(bool soloActivo = true)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (soloActivo)
                    return db.T0135_GLX.Where(c => c.ACTIVA.Value == true).ToList();
                return db.T0135_GLX.ToList();
            }
        }




        public List<T0135_GLX> GetListGLInventario()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0135_GLX.Where(c => c.GL.StartsWith("1.0.4.")).ToList();
            }
        }

        public List<T0135_GLX> GetListGLImputacionVentas()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0135_GLX.Where((c => c.GL.StartsWith("4.1.1."))).ToList();
            }
        }

        public List<T0135_GLX> GetListGLImputacionCompras()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0135_GLX.Where((c => c.GL.StartsWith("5."))).ToList();
            }
        }

    }
}


