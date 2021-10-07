using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    public class ControlAddressManager
    {
        public struct ResultadoValidacionAddress
        {
            public int IdLocalidad;
            public bool ExistePais;
            public bool ExisteProvincia;
            public bool ExistePartido;
            public bool ExisteLocalidad;
        }
        public struct InfoAddress
        {
            public int IdLocalidad;
            public string Localidad;
            public string Partido;
            public string Provincia;
            public string Pais;
        }


        public List<String> GetListaPaises()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0008_REGION.Select(c => c.Pais).Distinct().ToList();
            }
        }

        public List<String> GetListaProvincias(string pais)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0008_REGION.Where(c => c.Pais.ToUpper().Equals(pais.ToUpper())).Select(c => c.Region)
                    .ToList();
            }
        }

        public List<T0008_REGION> GetProvincia(string pais)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0008_REGION.Where(c => c.Pais.ToUpper().Equals(pais.ToUpper())).ToList();
            }
        }
        public List<T0010_PARTIDO> GetPartido(int idProvincia)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0010_PARTIDO.Where(c => c.IdProvincia == idProvincia).ToList();
            }
        }
        public List<T0010_LOCALIDAD> GetLocalidad(int idPartido)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0010_LOCALIDAD.Where(c => c.IdPartido == idPartido).ToList();
            }
        }
        public List<T0010_LOCALIDAD> GetLocalidad_Provincia(int idProvincia)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0010_LOCALIDAD.Where(c => c.T0010_PARTIDO.IdProvincia == idProvincia).ToList();
            }
        }

        public static bool CheckExistePais(string pais)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0008_REGION.Where(c => c.Pais.ToUpper().Equals(pais.ToUpper())).ToList();
                return x.Any();
            }
        }

        /// <summary>
        /// Si Existe un Provincia retorno el ID, - Si Existen varias Retorna 0 - Si No Existe retorna -1;
        /// </summary>
        public static int CheckExisteProvincia(string pais, string provincia)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0008_REGION.Where(c =>
                    c.Pais.ToUpper().Equals(pais.ToUpper()) && c.Region.ToUpper().Equals(provincia.ToUpper())).ToList();
                if (x.Any())
                {
                    return x.Count == 1 ? x[0].Id : 0;
                }
                else
                {
                    return -1;
                }
            }
        }


        /// <summary>
        /// Partido retorno ID . - Si retorna -1 no existe - Si retorna 0 >> hay muchas (error)
        /// </summary>
        public static int CheckExistePartido(int idProvincia, string partido)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0010_PARTIDO
                    .Where(c => c.IdProvincia == idProvincia && c.Partido.ToUpper().Equals(partido.ToUpper())).ToList();
                if (x.Any())
                    return x.Count == 1 ? x[0].Id : 0;
                return -1;
            }
        }
        public static int CheckExisteLocalidadPartido(int idPartido, string localidad)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0010_LOCALIDAD
                    .Where(c => c.IdPartido == idPartido && c.Localidad.ToUpper().Equals(localidad.ToUpper())).ToList();
                if (x.Any())
                {
                    return x.Count == 1 ? x[0].Id : 0;
                }
                else
                {
                    return -1;
                }
            }
        }
        public static int CheckExisteLocalidadProvincia(int idProvincia, string localidad)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0010_LOCALIDAD.Where(c =>
                        c.T0010_PARTIDO.IdProvincia == idProvincia && c.Localidad.ToUpper().Equals(localidad.ToUpper()))
                    .ToList();
                if (x.Any())
                {
                    return x.Count == 1 ? x[0].Id : 0;
                }
                else
                {
                    return -1;
                }
            }
        }


        /// <summary>
        /// Chequea si para el pais ingresado la provincia existe
        /// </summary>
        public bool CheckProvincia_pais(string pais, string provincia)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x = db.T0008_REGION.Where(c =>
                        c.Pais.ToUpper().Equals(pais.ToUpper()) && (c.Region.ToUpper().Equals(provincia.ToUpper())))
                    .ToList();
                return x.Any();
            }
        }

        /// <summary>
        /// Si Retorna IdLocalidad >0 significa que hay una unica Localidad Encontrada para los datos seleccionados.
        /// </summary>
        public ResultadoValidacionAddress CheckDataExiste(string pais, string provincia, string partido,
            string localidad)
        {
            //retorno default all negativo.-
            var rx = new ResultadoValidacionAddress()
            {
                IdLocalidad = -1,
                ExisteLocalidad = false,
                ExistePais = false,
                ExisteProvincia = false,
                ExistePartido = false
            };

            if (string.IsNullOrEmpty(pais))
                pais = @"AR";

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                //El Pais Existe si hay al menos alguna provincia para el valor PAIS ingresado.- 
                var provinciaPais = db.T0008_REGION.Where(c =>
                        c.Pais.ToUpper().Equals(pais.ToUpper()) && (c.Region.ToUpper().Equals(provincia.ToUpper())))
                    .ToList();
                if (provinciaPais.Any())
                    rx.ExistePais = true;

                var provinciaOk = provinciaPais.SingleOrDefault(c => c.Region.ToUpper().Equals(provincia.ToUpper()));
                if (provinciaOk == null)
                {
                    //La Provincia No Existe. 
                    //Si la provincia no existe el resto de la info ya la pasa como no existente
                    //Finalizando la validacion.-
                    rx.ExisteProvincia = false;
                }
                else
                {
                    //La Provincia Existe
                    rx.ExisteProvincia = true;

                    //--> Chequea Partido Validao para esa Provincia
                    if (string.IsNullOrEmpty(partido))
                    {
                        //Si no se informa Partido - Validamos igual Localidad
                        rx.ExistePartido = false;

                        if (!string.IsNullOrEmpty(localidad))
                        {
                            //no se informo partido pero hay una localidad Informada -
                            //Chequea si existe alguna localidad para esa provincia (desestima partido)- 
                            var localidadOK = db.T0010_LOCALIDAD.Where(c =>
                                c.Localidad.ToUpper().TrimEnd().Equals(localidad.ToUpper()) &&
                                c.T0010_PARTIDO.IdProvincia == provinciaOk.Id).ToList();

                            //Retorna True si al menos hay una localidad valida sin importar el partido pero si la provincia.
                            rx.ExisteLocalidad = localidadOK.Any();
                        }
                        else
                        {
                            //No se ha informado Partido Ni Localidad;
                            rx.ExisteLocalidad = false;
                        }
                    }
                    else
                    {
                        //Se ha informado Partido --> Validamos
                        var partidoOk = db.T0010_PARTIDO.SingleOrDefault(c =>
                            c.IdProvincia == provinciaOk.Id && c.Partido.ToUpper().Equals(partido.ToUpper()));
                        if (partidoOk == null)
                        {
                            //No Existe ese partido para la provincia seleccionada
                            rx.ExistePartido = false;

                            if (!string.IsNullOrEmpty(localidad))
                            {
                                //El Partido es Invalido pero como se provee Localidad chequeamos igual la localdidad dependiendo solo de la provincia.
                                //PARTIDO Incorrecto pero hay una localidad Informada -
                                //Chequea si existe alguna localidad para esa provincia (desestima partido)- 
                                var localidadOK = db.T0010_LOCALIDAD.Where(c =>
                                    c.Localidad.ToUpper().Equals(localidad.ToUpper()) &&
                                    c.T0010_PARTIDO.IdProvincia == provinciaOk.Id).ToList();
                                //Retorna True si al menos hay una localidad valida sin importar el partido pero si la provincia.
                                rx.ExisteLocalidad = localidadOK.Any();
                                if (localidadOK.Count == 1)
                                {
                                    rx.IdLocalidad = localidadOK[0].Id;
                                }
                                else
                                {
                                    rx.IdLocalidad = -1;
                                }
                            }
                        }
                        else
                        {
                            //Partido Existente para el partido
                            rx.ExistePartido = true;
                            if (string.IsNullOrEmpty(localidad))
                            {
                                rx.ExisteLocalidad = false;
                                rx.IdLocalidad = -1;
                            }
                            else
                            {
                                var localidadOk = db.T0010_LOCALIDAD.SingleOrDefault(c =>
                                    c.IdPartido == partidoOk.Id && c.Localidad.ToUpper().Equals(localidad.ToUpper()));
                                if (localidadOk == null)
                                {
                                    rx.ExisteLocalidad = false;
                                    rx.IdLocalidad = -1;
                                }
                                else
                                {
                                    rx.ExisteLocalidad = true;
                                    rx.IdLocalidad = localidadOk.Id;
                                }
                            }
                        }
                    }
                }
            }

            return rx;
        }

        public InfoAddress LoadFromIdLocalidad(int idLocalidad)
        {
            var r1 = new InfoAddress()
            {
                IdLocalidad = idLocalidad,
                Localidad = string.Empty,
                Partido = string.Empty,
                Provincia = string.Empty,
                Pais = string.Empty
            };

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var Localidad = db.T0010_LOCALIDAD.SingleOrDefault(c => c.Id == idLocalidad);
                if (Localidad != null)
                {
                    r1.Localidad = Localidad.Localidad;
                    var Partido = db.T0010_PARTIDO.SingleOrDefault(c => c.Id == Localidad.IdPartido);
                    if (Partido != null)
                    {
                        r1.Partido = Partido.Partido;
                        var Provincia = db.T0008_REGION.SingleOrDefault(c => c.Id == Partido.IdProvincia);
                        if (Provincia != null)
                        {
                            r1.Provincia = Provincia.Region;
                            r1.Pais = Provincia.Pais;
                        }
                    }
                }
            }
            return r1;
        }
    }
}
