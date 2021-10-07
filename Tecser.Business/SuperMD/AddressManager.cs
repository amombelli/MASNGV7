using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;
using TecserSQL.Data.GenericRepo;
using TecserSQL.Data.SuperMD;

namespace Tecser.Business.SuperMD
{
    public class AddressManager
    {
        private string _selectedCountry;
        private int _idSelectedProvincia;
        private int _idSelectedPartido;
        private int _idSelectedLocalidad;

        public List<T0008_REGION> DatasourceRegion = new List<T0008_REGION>();
        public List<T0010_PARTIDO> DataSourcePartido = new List<T0010_PARTIDO>();
        public List<T0010_LOCALIDAD> DatasourceLocalidad = new List<T0010_LOCALIDAD>();


        public enum AddressCombo
        {
            Pais,
            Provincia,
            Partido,
            Localidad
        };

        public AddressManager(string country = "AR")
        {
            _selectedCountry = country;
            DatasourceRegion = CompleteListRegions_Country();
            DataSourcePartido = CompleteListPartidos();
            DatasourceLocalidad = CompleteListLocalidad();
            _idSelectedPartido = 0;
            _idSelectedLocalidad = 0;
            _idSelectedProvincia = 1;
        }

        private List<T0008_REGION> CompleteListRegions_Country()
        {
            return new Repository<T0008_REGION>(new TecserData(GlobalApp.CnnApp)).Find(c => c.Pais.Equals(_selectedCountry)).ToList();
        }

        public List<T0010_PARTIDO> CompleteListPartidos_Region(int idProvincia)
        {
            return new Repository<T0010_PARTIDO>(new TecserData(GlobalApp.CnnApp)).Find(c => c.IdProvincia == idProvincia).ToList();
        }

        public List<T0010_LOCALIDAD> CompleteListLocalidad_Partido(int idPartido)
        {
            return new Repository<T0010_LOCALIDAD>(new TecserData(GlobalApp.CnnApp)).Find(c => c.IdPartido == idPartido).ToList();
        }

        //private List<T0010_LOCALIDAD> CompleteListLocalidad_Region()
        //{
        //    //return  new Address(new TecserData(GlobalApp.CnnApp)).GetListLocalidad_Provincia(_idSelectedProvincia)
        //   // _DatasourceLocalidad = x.ToList();
        //} 

        public List<T0008_REGION> CompleteListRegions()
        {
            return new Repository<T0008_REGION>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        public List<T0010_PARTIDO> CompleteListPartidos()
        {
            return new Repository<T0010_PARTIDO>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }

        public List<T0010_LOCALIDAD> CompleteListLocalidad()
        {
            return new Repository<T0010_LOCALIDAD>(new TecserData(GlobalApp.CnnApp)).GetAll().ToList();
        }



        public void SetRegion(int idRegion)
        {
            _idSelectedProvincia = idRegion;
            _idSelectedPartido = 0;
            _idSelectedLocalidad = 0;

            DataSourcePartido = PopulateDatasourcePartido_Region(_idSelectedProvincia);
            DatasourceLocalidad = PopulateDatasourceLocalidad_Region(_idSelectedProvincia);
        }


        public void SetPartido(int idPartido)
        {
            _idSelectedPartido = idPartido;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var xpartido = db.T0010_PARTIDO.SingleOrDefault(c => c.Id == _idSelectedPartido);
                if (xpartido == null)
                    return;

                _idSelectedProvincia = xpartido.IdProvincia;

                var xcountry = db.T0008_REGION.SingleOrDefault(c => c.Id == _idSelectedProvincia);
                if (xcountry == null)
                    return;

                _selectedCountry = xcountry.Pais;

                _idSelectedLocalidad = 0;
                DatasourceLocalidad = PopulateDatasourceLocalidad_Partido(_idSelectedPartido);
            }
        }


        public void SetLocalidad(int idLocalidad)
        {
            _idSelectedLocalidad = idLocalidad;

            var data =
                new Repository<T0010_LOCALIDAD>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.Id == _idSelectedLocalidad);
            _idSelectedPartido = data != null ? data.IdPartido : 0;

            var dataProv =
                new Repository<T0010_PARTIDO>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.Id == _idSelectedPartido);
            _idSelectedProvincia = dataProv != null ? dataProv.IdProvincia : 0;

            var dataPais =
                new Repository<T0008_REGION>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(c => c.Id == _idSelectedProvincia);
            _selectedCountry = dataPais != null ? dataPais.Pais : "AR";
        }

        private List<T0010_PARTIDO> PopulateDatasourcePartido_Region(int idProvincia)
        {
            return new Repository<T0010_PARTIDO>(new TecserData(GlobalApp.CnnApp)).Find(c => c.IdProvincia == idProvincia).ToList();
        }

        private List<T0010_LOCALIDAD> PopulateDatasourceLocalidad_Region(int idProvincia)
        {
            var data = new Address(GlobalApp.CnnApp).GetAllLocalidadesFromSelectedProvincia(idProvincia);
            return data.ToList();
        }

        private List<T0010_LOCALIDAD> PopulateDatasourceLocalidad_Partido(int idPartido)
        {
            var data =
                new Repository<T0010_LOCALIDAD>(new TecserData(GlobalApp.CnnApp)).Find(c => c.IdPartido == idPartido).ToList();
            return data;
        }

        public int GetSelectedRegion()
        {
            return _idSelectedProvincia;
        }
        public int GetSelectedPartido()
        {
            return _idSelectedPartido;
        }
        public int GetSelectedLocalidad()
        {
            return _idSelectedLocalidad;
        }


        public int GetIdProvincia(string provincia)
        {
            var db =
                new Repository<T0008_REGION>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                    c => c.Region.ToLower().Equals(provincia.ToLower()));
            return db == null ? 0 : db.Id;
        }
        public int GetIdPartido(int idProvincia, string partido)
        {
            var db =
                new Repository<T0010_PARTIDO>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                    c => c.IdProvincia == idProvincia && c.Partido.ToLower().Equals(partido.ToLower()));
            return db == null ? 0 : db.Id;
        }
        public int GetIdLocalidad(int idPartido, string localidad)
        {
            var db =
                new Repository<T0010_LOCALIDAD>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                    c => c.IdPartido == idPartido && c.Localidad.Trim().ToLower().Equals(localidad.ToLower()));
            return db == null ? 0 : db.Id;
        }


        public Color[] CheckDatosCorrectos(string pais = "AR", string provincia = "", string partido = "", string localidad = "")
        {

            var color = new Color[4];
            var idProvincia = GetIdProvincia(provincia);
            var idPartido = GetIdPartido(idProvincia, partido);
            var idLocalidad = GetIdLocalidad(idPartido, localidad);


            if (idProvincia == 0)
            {
                color[1] = Color.Red;
                var x =
                    new Repository<T0010_PARTIDO>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                        c => c.Partido.Trim().ToLower().Equals(partido.ToLower()));
                idPartido = x == null ? 0 : x.Id;
                if (idPartido == 0)
                {
                    color[2] = Color.Red;
                }
                else
                {
                    color[2] = Color.Yellow;
                    var tmpPart =
                        new Repository<T0010_LOCALIDAD>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                            c => c.Localidad.Trim().ToLower().Equals(localidad.ToLower()));
                    idLocalidad = tmpPart == null ? 0 : tmpPart.Id;
                    if (idLocalidad == 0)
                    {
                        color[3] = Color.Red;
                    }
                    else
                    {
                        color[3] = Color.Yellow;
                    }
                }
            }
            else
            {
                //La Provincia se encontro!
                color[1] = Color.Green;
                if (idPartido == 0)
                {
                    color[2] = Color.Red;
                    var tmpPart =
                        new Repository<T0010_LOCALIDAD>(new TecserData(GlobalApp.CnnApp)).SingleOrDefault(
                            c => c.Localidad.Trim().ToLower().Equals(localidad.ToLower()));
                    idLocalidad = tmpPart == null ? 0 : tmpPart.Id;
                    if (idLocalidad == 0)
                    {
                        color[3] = Color.Red;
                    }
                    else
                    {
                        color[3] = Color.Yellow;
                    }
                }
                else
                {
                    //El Partido se encontro!
                    color[2] = Color.Green;
                    if (idLocalidad != 0)
                    {
                        color[3] = Color.Green;
                    }
                    else
                    {
                        color[3] = Color.Red;
                    }
                }
            }
            return color;

        }
    }
}
