using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.SuperMD
{
    public class NewAddressManager
    {
        private readonly Color _colorOK = Color.MediumSeaGreen;
        private readonly Color _colorNo = Color.IndianRed;
        private readonly Color _colorIndef = Color.LightBlue;

        public NewAddressManager()
        {
            _dx = new EstructuraSeleccionada()
            {
                IdProvincia = null,
                IdLocalidad = null,
                IdPartido = null,
                Pais = "AR",
                Partido = null,
                Provincia = null,
                Localidad = null,
                ColorPais = _colorIndef,
                ColorProvincia = _colorIndef,
                ColorPartido = _colorIndef,
                ColorLocalidad = _colorIndef
            };
        }
        public struct EstructuraSeleccionada
        {
            public string Pais { get; set; }
            public string Provincia { get; set; }
            public string Partido { get; set; }
            public string Localidad { get; set; }
            public int? IdProvincia { get; set; }
            public int? IdPartido { get; set; }
            public int? IdLocalidad { get; set; }
            public Color ColorPais { get; set; }
            public Color ColorProvincia { get; set; }
            public Color ColorPartido { get; set; }
            public Color ColorLocalidad { get; set; }
        }

        //-------------------------------------------------------------------------------
        private EstructuraSeleccionada _dx;
        private List<T0008_REGION> _provincias = new List<T0008_REGION>();
        private List<T0010_PARTIDO> _partidos = new List<T0010_PARTIDO>();
        private List<T0010_LOCALIDAD> _localidades = new List<T0010_LOCALIDAD>();
        //-------------------------------------------------------------------------------

        public void ValidacionDatosString()
        {

        }

        /// <summary>
        /// Setea los valores sin validar contra la estrucutra
        /// </summary>
        public void SetValoresSinValidar(string pais, string provincia, string partido, string localidad)
        {
            _dx.Pais = pais;
            _dx.Provincia = provincia;
            _dx.Partido = partido;
            _dx.Localidad = localidad;

            var idProvincia = ExisteEstaProvincia(pais, provincia);
            if (idProvincia == -1)
            {
                //la provincia no existe - el resto se setea pero lo paso indeterminado
                _dx.ColorProvincia = _colorNo;
                _dx.ColorPartido = _colorIndef;
                _dx.ColorLocalidad = _colorIndef;
                _dx.IdLocalidad = null;
                _dx.IdPartido = null;
                _dx.IdProvincia = null;
            }
            else
            {
                _dx.IdProvincia = idProvincia;
                _dx.ColorProvincia = _colorOK;
                //como la provincia existe pasamos a chequear partido
                var idPartido = ExisteEstePartido(idProvincia, partido);
                if (idPartido == -1)
                {
                    _dx.IdPartido = null;
                    //El Partido no existe
                    if (string.IsNullOrEmpty(partido))
                    {
                        //la localidad podria ser valida - la chequeo
                        var idlocalidad = ExisteEstaLocalidad(localidad);
                        if (idlocalidad == -1)
                        {
                            _dx.ColorLocalidad = _colorIndef;
                            _dx.IdLocalidad = null;
                        }
                        else
                        {
                            _dx.ColorLocalidad = _colorOK;
                            _dx.IdLocalidad = idlocalidad;

                        }
                    }
                    else
                    {
                        //si el partido es cualquier cosa 
                        //no determina localidad
                    }
                }
                else
                {
                    //el partido existe
                    _dx.ColorPartido = _colorOK;
                    _dx.IdPartido = idPartido;
                    var idlocalidad = ExisteEstaLocalidad(localidad);
                    if (idlocalidad == -1)
                    {
                        _dx.ColorLocalidad = _colorNo;
                        _dx.IdLocalidad = null;
                    }
                    else
                    {
                        _dx.ColorLocalidad = _colorOK;
                        _dx.IdLocalidad = idlocalidad;
                    }
                }
            }
        }
        public EstructuraSeleccionada GetSeleccion()
        {
            return _dx;
        }
        public List<T0008_REGION> GetlistadoProvincias()
        {
            if (_dx.Pais == null)
                _dx.Pais = @"AR";
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _provincias = db.T0008_REGION.Where(c => c.Pais == _dx.Pais.ToUpper()).ToList();
                return _provincias;
            }
        }
        /// <summary>
        /// Si no tiene provincia seleccionada NO aparaecen los partidos
        /// </summary>
        public List<T0010_PARTIDO> GetListadoPartido()
        {
            if (_dx.IdProvincia == null)
                return null;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _partidos = db.T0010_PARTIDO.Where(c => c.IdProvincia == _dx.IdProvincia.Value).ToList();
                return _partidos;
            }
        }
        /// <summary>
        /// Las localidades aparecen solo con provincia o con provincia-partido
        /// </summary>
        public List<T0010_LOCALIDAD> GetListadoLocalidades()
        {
            if (_dx.IdProvincia == null)
                return null;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (_dx.IdPartido == null)
                {
                    //aparecen todas las localidades de la provincia seleccionada
                    return db.T0010_LOCALIDAD.Where(c => c.T0010_PARTIDO.IdProvincia == _dx.IdProvincia.Value).ToList();
                }
                else
                {
                    //aparecen solo las localidades del partido seleccionado
                    return db.T0010_LOCALIDAD.Where(c => c.IdPartido == _dx.IdPartido.Value).ToList();
                }
            }
        }
        public void SetPaisSeleccionado(string pais)
        {
            _dx.Pais = pais ?? "AR";
            _dx.ColorPais = _dx.Pais == null ? _colorNo : _colorOK;
        }
        public void SetProvinciaSeleccionada(int? idProvincia, string provincia)
        {
            if (_dx.IdProvincia == idProvincia)
                return; //no hubo ningun cambio

            _dx.IdProvincia = idProvincia;
            _dx.Provincia = provincia;
            _dx.ColorProvincia = _dx.IdProvincia == null ? _colorNo : _colorOK;
            if (idProvincia == null)
            {
                //pone todos los datos restantes en null
                _dx.IdPartido = null;
                _dx.Partido = null;
                _dx.IdLocalidad = null;
                _dx.Localidad = null;
                _dx.ColorPartido = _colorNo;
                _dx.ColorLocalidad = _colorNo;
                _partidos = null;
                _localidades = null;
            }
        }
        public void SetPartidoSeleccionado(int? idPartido, string partido)
        {
            if (_dx.IdPartido == idPartido)
                return;
            _dx.IdPartido = idPartido;
            _dx.Partido = partido;
            _dx.ColorPartido = _dx.IdPartido == null ? _colorNo : _colorOK;
            if (idPartido == null)
            {
                _dx.IdLocalidad = null;
                _dx.Localidad = null;
                _dx.ColorLocalidad = _colorNo;
            }
        }
        public void SetLocalidadSeleccionada(int? idLocalidad, string localidad)
        {
            _dx.IdLocalidad = idLocalidad;
            _dx.Localidad = localidad;
            _dx.ColorLocalidad = _dx.IdLocalidad == null ? _colorNo : _colorOK;
            if (idLocalidad == null)
                return;

            if (_dx.IdPartido != null)
            {
                return;
            }
            //Set setea localidad pero no tiene partido - se obtiene automaticamente
            //Se usa color indefinido si no se encuentra
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var xpartido = db.T0010_LOCALIDAD.SingleOrDefault(c => c.Id == idLocalidad.Value);
                if (xpartido == null)
                {
                    _dx.IdPartido = null;
                    _dx.Partido = null;
                }
                else
                {
                    _dx.IdPartido = xpartido.IdPartido;
                    _dx.Partido = xpartido.T0010_PARTIDO.Partido;
                }
                _dx.ColorPartido = _dx.IdPartido == null ? _colorIndef : _colorOK;
            }
        }

        /// <summary>
        /// Dado un IdLocalidad - Obtiene toda la estructura completa
        /// </summary>
        public void SetAllFromLocalidad(int idLocalidad)
        {
            _dx.Provincia = null;
            _dx.IdPartido = null;
            _dx.IdLocalidad = null;
            _dx.Provincia = null;
            _dx.Partido = null;
            _dx.Localidad = null;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var idL = db.T0010_LOCALIDAD.SingleOrDefault(c => c.Id == idLocalidad);
                if (idL == null)
                    return;
                _dx.IdLocalidad = idLocalidad;
                _dx.Localidad = idL.Localidad;
                _dx.ColorLocalidad = _dx.IdLocalidad == null ? _colorNo : _colorOK;

                var idPartido = db.T0010_PARTIDO.SingleOrDefault(c => c.Id == idL.IdPartido);
                if (idPartido == null)
                {
                    _dx.IdLocalidad = null;
                    _dx.Localidad = null;
                    _dx.ColorLocalidad = _dx.IdLocalidad == null ? _colorNo : _colorOK;
                    _dx.ColorPartido = _dx.IdLocalidad == null ? _colorNo : _colorOK;
                    return;
                }
                _dx.IdPartido = idPartido.Id;
                _dx.Partido = idPartido.Partido;

                var idProvincia = db.T0008_REGION.SingleOrDefault(c => c.Id == idPartido.IdProvincia);
                if (idProvincia == null)
                {
                    _dx.IdLocalidad = null;
                    _dx.IdPartido = null;
                    _dx.Localidad = null;
                    _dx.Partido = null;
                }

                _dx.IdProvincia = idProvincia.Id;
                _dx.Provincia = idProvincia.Region;
                _dx.Pais = idProvincia.Pais;
            }
        }

        public int? GetIdPartidoSeleccionado()
        {
            return _dx.IdPartido;
        }

        public int ExisteEstaProvincia(string pais, string provincia)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0008_REGION.Where(
                        c => c.Pais.ToUpper().Equals(pais.ToUpper()) && c.Region.ToUpper().Equals(provincia.ToUpper()))
                        .ToList();

                if (data.Count != 1)
                    return -1;
                return data[0].Id;
            }
        }
        public int ExisteEstePartido(int idProvincia, string partido)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data =
                    db.T0010_PARTIDO.Where(
                        c => c.IdProvincia == idProvincia && c.Partido.ToUpper().Equals(partido.ToUpper())).ToList();

                if (data.Count != 1)
                    return -1;
                return data[0].Id;
            }
        }
        public int ExisteEstaLocalidad(string localidad)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (_dx.IdPartido != null)
                {
                    //Hay un partido seleccionado -> busca la localidad de ese partido
                    var data =
                        db.T0010_LOCALIDAD.Where(
                            c => c.IdPartido == _dx.IdPartido.Value && c.Localidad.ToUpper().Equals(localidad)).ToList();
                    if (data.Count != 1)
                    {
                        //SetLocalidadSeleccionada(null,null); 
                        return -1;
                    }
                    else
                    {
                        //SetLocalidadSeleccionada(data[0].Id,data[0].Localidad);
                        //return _dx.IdLocalidad.Value;
                        return data[0].Id;
                    }
                }
                else
                {
                    //no hay un partido seleccionado --> busca una localidad 
                    var data =
                        db.T0010_LOCALIDAD.Where(c => c.Localidad.ToUpper().Equals(localidad)).ToList();

                    if (data.Count != 1)
                    {
                        //SetLocalidadSeleccionada(null,null);
                        return -1;
                    }
                    else
                    {
                        //SetLocalidadSeleccionada(data[0].Id, data[0].Localidad); //asigna tambien un partido
                        return data[0].Id;
                    }
                }
            }
        }



    }
}
