using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.NewUserControls
{
    public partial class CtlAddress : UserControl
    {
        public bool AllowEditSources { get; set; }
        public bool AllowFreeText { get; set; }
        public int Modo { get; set; }

        public ControlAddressManager.ResultadoValidacionAddress CargaControl(int idLocalidad)
        {
            var r1 = _c.LoadFromIdLocalidad(idLocalidad);
            return CargaControl(r1.Pais, r1.Provincia, r1.Partido, r1.Localidad);
        }
        public ControlAddressManager.ResultadoValidacionAddress CargaControl(string pais, string provincia, string partido, string localidad)
        {
            txtPais.Text = pais;
            cmbProvincia.Text = provincia;
            cmbPartido.Text = partido;
            cmbLocalidad.Text = localidad;
            iconPais.Set = CIconos.Equis;
            iconProvincia.Set = CIconos.Equis;
            iconPartido.Set = CIconos.Equis;
            iconLocalidad.Set = CIconos.Equis;

            var rx = _c.CheckDataExiste(pais, provincia, partido, localidad);
            if (rx.ExistePais)
                iconPais.Set = CIconos.Tilde;

            if (rx.ExisteProvincia)
                iconProvincia.Set = CIconos.Tilde;

            if (rx.ExistePartido)
            {
                iconPartido.Set = CIconos.Tilde;
                if (rx.ExisteLocalidad)
                {
                    iconLocalidad.Set = CIconos.Tilde;
                }
            }
            else
            {
                //no existe partido pero si localidad
                if (rx.ExisteLocalidad)
                {
                    iconLocalidad.Set = CIconos.LamparitaGreen;
                    tt.SetToolTip(cmbLocalidad, "");
                    tt.Show("La Localidad Existe pero el Partido es Incorrecto/Incompleto", cmbLocalidad, cmbLocalidad.Width, 0, 1200);
                }
            }
            return rx;
        }
        public ControlAddressManager.InfoAddress GetData()
        {
            return new ControlAddressManager.InfoAddress()
            {
                IdLocalidad = _idLocalidad,
                Pais = txtPais.Text,
                Partido = cmbPartido.Text,
                Provincia = cmbProvincia.Text,
                Localidad = cmbLocalidad.Text
            };
        }

        public bool AllowLocalidadProvincia { get; set; } = true;
        private string _pais;
        private List<T0008_REGION> _provincias = new List<T0008_REGION>();
        private List<T0010_PARTIDO> _partidos = new List<T0010_PARTIDO>();
        private List<T0010_LOCALIDAD> _localidades = new List<T0010_LOCALIDAD>();
        private ControlAddressManager _c = new ControlAddressManager();
        private int _idLocalidad = -1;

        private bool siprov = false;
        private bool sipart = false;
        private bool siloca = false;

        public CtlAddress()
        {
            InitializeComponent();
        }


        private void CtlAddress_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;
            //valor por defecto
            //al ingresar si o si se deebe completar la provincia.
            if (_idLocalidad != -1)
                CargaDesdeLocaldiad();

            txtPais.Text = @"AR";
            _pais = @"AR";
            iconPais.Set = CIconos.Tilde;
            PopulaProvincias();
        }
        private void PopulaProvincias()
        {
            _provincias = _c.GetProvincia(_pais);
            if (!_provincias.Any())
            {
                //no tengo ninguna provincia en la lista
                iconProvincia.Set = CIconos.ExclamacionRed;
                cmbProvincia.Enabled = false;
            }
            else
            {
                //al menos hay algun valor en la lista
                //popula lista.-
                iconProvincia.Set = CIconos.LamparitaGreen;
                cmbProvincia.Enabled = true;
                siprov = false;
                cmbProvincia.DataSource = _provincias;
                cmbProvincia.SelectedIndex = -1;
                //
                sipart = false;
                cmbPartido.SelectedItem = -1;
                cmbPartido.Enabled = false;
                iconPartido.Set = CIconos.Equis;
                //
                siloca = false;
                cmbLocalidad.SelectedIndex = -1;
                cmbLocalidad.Enabled = false;
                iconLocalidad.Set = CIconos.Equis;
            }
            siprov = true;
        }
        private void PopulaPartido()
        {
            if (cmbProvincia.SelectedValue == null)
            {
                //Provincia => vacio
                //_partidos = null;
                //_localidades = null;
                sipart = true;
                cmbPartido.SelectedIndex = -1;
                cmbLocalidad.SelectedIndex = -1;
                return;
            }
            _partidos = _c.GetPartido(Convert.ToInt32(cmbProvincia.SelectedValue));
            if (!_partidos.Any())
            {
                //no tengo ningun partido en la lista
                iconPartido.Set = CIconos.ExclamacionRed;
                cmbPartido.Enabled = false;
                cmbLocalidad.Enabled = false;
            }
            else
            {
                //al menos hay algun valor en la lista
                //popula lista.-
                iconPartido.Set = CIconos.LamparitaGreen;
                cmbPartido.Enabled = true;
                sipart = false;
                cmbPartido.DataSource = _partidos;
                cmbPartido.SelectedIndex = -1;
                //
                siloca = false;
                cmbLocalidad.SelectedIndex = -1;
                cmbLocalidad.Enabled = false;
                iconLocalidad.Set = CIconos.Equis;
            }
            sipart = true;
        }
        private void PopulaPartidoLocalidad()
        {
            //funcion para popular el combo de partido desde 
            //una localidad seleccioanda.- 
            if (cmbLocalidad.SelectedValue == null)
            {
                return;
            }

            if (!_partidos.Any())
            {
                //No hay partidos en la lista. - Esto no debiera haber pasado.
                return;
            }
            var localidad = (T0010_LOCALIDAD)cmbLocalidad.SelectedItem;
            sipart = true;
            cmbPartido.SelectedValue = localidad.IdPartido;
            cmbLocalidad.SelectedValue = localidad.Id;
        }
        private void PopulaLocalidades()
        {
            if (cmbPartido.SelectedValue == null)
            {
                _localidades = _c.GetLocalidad_Provincia(Convert.ToInt32(cmbProvincia.SelectedValue));
            }
            else
            {
                _localidades = _c.GetLocalidad(Convert.ToInt32(cmbPartido.SelectedValue));
            }

            if (!_localidades.Any())
            {
                //no tengo ninguna localidad en la lista
                iconLocalidad.Set = CIconos.ExclamacionRed;
                cmbLocalidad.Enabled = false;
            }
            else
            {
                //al menos hay algun valor en la lista
                //popula lista.-
                iconLocalidad.Set = CIconos.LamparitaGreen;
                cmbLocalidad.Enabled = true;
                siloca = false;
                cmbLocalidad.DataSource = _localidades;
                cmbLocalidad.SelectedIndex = -1;
            }
            siloca = true;
        }
        private void CargaDesdeLocaldiad()
        {
            //funcion para cargar y configurar desde localdiad.
        }
        private void txtPais_TextChanged(object sender, EventArgs e)
        {
            if (txtPais.Text.Length == 2)
            {
                _pais = txtPais.Text;
                PopulaProvincias();
                //_provincias = _c.GetProvincia(txtPais.Text);
                //cmbProvincia.DataSource = _provincias;
                //cmbProvincia.SelectedIndex = -1;
                //if (_provincias.Any())
                //{
                //    iconProvincia.Set = CIconos.Information;
                //}
                //else
                //{
                //    iconProvincia.Set = CIconos.ExclamacionOrange;
                //}
            }
            else
            {
                //aun no hay un país valido seleccionado
                cmbProvincia.Enabled = false;
                cmbPartido.Enabled = false;
                cmbLocalidad.Enabled = false;
                iconProvincia.Set = CIconos.ExclamacionOrange;
                iconPartido.Set = CIconos.ExclamacionOrange;
                iconLocalidad.Set = CIconos.ExclamacionOrange;
            }
        }
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (siprov == false)
                return;


            if (cmbProvincia.SelectedIndex == -1 || cmbProvincia.Text == null)
            {
                //al no tener provincia seleccionada no permite seleccionar
                //nada mas
                //creo que nunca va a llegar aca?
                cmbPartido.SelectedIndex = -1;
                cmbLocalidad.SelectedItem = -1;
                cmbPartido.Enabled = false;
                cmbLocalidad.Enabled = false;
                iconLocalidad.Set = CIconos.TrianguloNaranja;
                iconPartido.Set = CIconos.TrianguloNaranja;
            }
            else
            {
                //hemos seleccionado una provincia
                iconProvincia.Set = CIconos.Tilde;
                PopulaPartido();
                if (AllowLocalidadProvincia)
                {
                    PopulaLocalidades();
                }
            }
        }
        private void cmbPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sipart == false)
                return;

            if (cmbPartido.SelectedIndex == -1)
            {
                //al no tener partido seleccionado no permite seleccionar
                //nada mas
                //cmbLocalidad.DataSource = null;
                //cmbPartido.DataSource = null;
                siloca = false;
                cmbLocalidad.SelectedIndex = -1;
                siloca = true;
                iconLocalidad.Set = CIconos.TrianguloNaranja;
                iconPartido.Set = CIconos.TrianguloNaranja;
                cmbPartido.Enabled = false;
                cmbLocalidad.Enabled = false;
            }
            else
            {
                //hemos seleccionado un partido
                iconPartido.Set = CIconos.Tilde;
                PopulaLocalidades();
            }


        }
        private void cmbLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (siloca == false)
                return;

            if (cmbLocalidad.SelectedIndex == -1)
            {
                _idLocalidad = -1;
                if (_localidades.Any())
                {
                    iconLocalidad.Set = CIconos.LamparitaGreen;
                }
                else
                {
                    iconLocalidad.Set = CIconos.TrianguloNaranja;
                }
            }
            else
            {
                iconLocalidad.Set = CIconos.Tilde;
                _idLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);
                if (cmbPartido.SelectedValue == null)
                {
                    PopulaPartidoLocalidad();
                }
            }
        }
        private void cmbProvincia_Validating(object sender, CancelEventArgs e)
        {
            var r = Validaciones.CheckCmb(cmbProvincia);
            e.Cancel = r;
            if (r)
            {
                tt.Show("Debe Seleccionar un Provincia de la Lista", cmbProvincia, cmbProvincia.Width, 0, 1200);
            }
            else
            {
                if (string.IsNullOrEmpty(cmbProvincia.Text))
                {
                    cmbPartido.SelectedIndex = -1;
                    cmbLocalidad.SelectedItem = -1;
                    cmbPartido.Enabled = false;
                    cmbLocalidad.Enabled = false;
                    iconLocalidad.Set = CIconos.TrianguloNaranja;
                    iconPartido.Set = CIconos.TrianguloNaranja;
                }
            }
        }
        private void cmbPartido_Validating(object sender, CancelEventArgs e)
        {
            var r = Validaciones.CheckCmb(cmbPartido);
            e.Cancel = r;
            if (r)
            {
                tt.Show("Debe Seleccionar un Partido de la Lista", cmbPartido, cmbPartido.Width, 0, 1200);
            }

            if (string.IsNullOrEmpty(cmbPartido.Text))
            {
                //elimine el partido - 
                cmbPartido.SelectedIndex = -1;
                cmbLocalidad.SelectedIndex = -1;
                PopulaPartido();
                if (AllowLocalidadProvincia)
                {
                    PopulaLocalidades();
                }
                //if (_partidos.Any())
                //{
                //    iconPartido.Set = CIconos.LamparitaGreen;
                //}
                //else
                //{
                //    iconPartido.Set = CIconos.TrianguloNaranja;
                //}

                //if (_localidades.Any())
                //{
                //    iconLocalidad.Set = CIconos.LamparitaGreen;
                //}
                //else
                //{
                //    iconLocalidad.Set = CIconos.TrianguloNaranja;
                //}


            }
        }
        private void cmbLocalidad_Validating(object sender, CancelEventArgs e)
        {
            var r = Validaciones.CheckCmb(cmbLocalidad);
            e.Cancel = r;
            if (r)
            {
                tt.Show("Debe Seleccionar una Localidad de la Lista", cmbLocalidad, cmbLocalidad.Width, 0, 1200);
            }
            if (string.IsNullOrEmpty(cmbLocalidad.Text))
            {
                cmbLocalidad.SelectedIndex = -1;
                _idLocalidad = -1;
                if (_localidades.Any())
                {
                    iconLocalidad.Set = CIconos.LamparitaGreen;
                }
                else
                {
                    iconLocalidad.Set = CIconos.TrianguloNaranja;
                }
            }
        }
        private void txtPais_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (AllowFreeText)
                using (var f = new _frmABMAdressControl())
                {
                    f.ShowDialog();
                }
        }
    }
}
