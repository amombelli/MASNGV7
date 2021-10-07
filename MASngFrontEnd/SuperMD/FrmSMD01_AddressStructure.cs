using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tecser.Business.SuperMD;

namespace MASngFE.SuperMD
{


    public partial class FrmSMD01_AddressStructure : Form
    {
        private int _idLocation;
        private string _pais;
        private string _provincia;
        private string _partido;
        private string _localidad;
        private string _codigoPostal;
        private string _zona;
        private readonly int _modo;

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_NCPAINT = 0x85;
            if (m.Msg == WM_NCPAINT)
            {
                IntPtr hdc = GetWindowDC(m.HWnd);
                if ((int)hdc != 0)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 4800, 23));
                    g.Flush();
                    ReleaseDC(m.HWnd, hdc);
                }
            }
        }


        public FrmSMD01_AddressStructure()
        {
            InitializeComponent();
            _modo = 0;
        }

        public FrmSMD01_AddressStructure(int idLocation)
        {
            _idLocation = idLocation;
            InitializeComponent();
            _modo = 1;
        }

        public FrmSMD01_AddressStructure(string pais, string provincia, string partido, string localidad,
            string codigoPostal, string zona)
        {
            _pais = pais;
            _provincia = provincia;
            _partido = partido;
            _localidad = localidad;
            _codigoPostal = codigoPostal;
            _zona = zona;
            _modo = 2;
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------------
        public NewAddressManager Address = new NewAddressManager();
        private Color colorNoDef = Color.Yellow;
        private Color colorOk = Color.LightGreen;
        private Color colorNo = Color.IndianRed;
        private Color colorInicial = Color.LightBlue;
        //-----------------------------------------------------------------------------------------------

        private void FrmSMD01_AddressStructure_Load(object sender, EventArgs e)
        {
            ckSoloEstructuraValida.Checked = true;
            txtFPais.Text = @"AR";
            txtFPaisDescripcion.Text = @"ARGENTINA";
            provinciaBs.DataSource = Address.GetlistadoProvincias();
            //cmbFProvincia.SelectedIndex = -1;
            //txtFProvinciaId.BackColor = colorInicial;
            txtFLocalidadId.BackColor = colorInicial;
            txtFPartidoId.BackColor = colorInicial;
            SeteaProperitesComboboxAddress();  //Activa los selectedIndex
            switch (_modo)
            {
                case 0:
                    break;
                case 1:
                    //cmbFProvincia.SelectedIndex = -1;
                    //txtFProvinciaId.BackColor = colorInicial;
                    break;
                case 2:
                    LoadData();
                    break;
            }
        }

        private void LoadData()
        {
            //----------------------------------------------------------------
            txtFZip.Text = _codigoPostal;
            txtZona.Text = _zona;
            //----------------------------------------------------------------
            if (_pais == null)
            {
                _pais = "AR";
                txtFPaisDescripcion.Text = @"ARGENTINA";
            }
            txtFPais.Text = _pais;

            var idProvincia = -1;
            var idPartido = -1;

            if (_provincia != null)
            {
                idProvincia = Address.ExisteEstaProvincia(_pais, _provincia);
                if (idProvincia == -1)
                {
                    txtFProvinciaId.Text = null;
                    txtFProvinciaId.BackColor = colorNoDef;
                    cmbFProvincia.Text = _provincia;
                }
                else
                {
                    txtFProvinciaId.Text = idProvincia.ToString();
                    Address.SetProvinciaSeleccionada(idProvincia, _provincia);
                    provinciaBs.DataSource = Address.GetlistadoProvincias();
                    this.cmbFProvincia.SelectedIndexChanged -= new System.EventHandler(this.cmbFProvincia_SelectedIndexChanged);
                    cmbFProvincia.SelectedValue = idProvincia;
                    txtFProvinciaId.BackColor = colorOk;
                    this.cmbFProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbFProvincia_SelectedIndexChanged);
                }
            }
            else
            {
                txtFProvinciaId.BackColor = colorNo;
            }

            if (_partido != null)
            {
                idPartido = Address.ExisteEstePartido(idProvincia, _partido);
                if (idPartido == -1)
                {
                    txtFPartidoId.Text = null;
                    txtFPartidoId.BackColor = colorNo;
                    partidoBs.DataSource = Address.GetListadoPartido();
                    this.cmbFPartido.SelectedIndexChanged -= new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
                    cmbFPartido.Text = _partido;
                    this.cmbFPartido.SelectedIndexChanged += new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
                }
                else
                {
                    txtFPartidoId.Text = idPartido.ToString();
                    Address.SetPartidoSeleccionado(idPartido, _partido);
                    partidoBs.DataSource = Address.GetListadoPartido();
                    this.cmbFPartido.SelectedIndexChanged -= new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
                    cmbFPartido.SelectedValue = idPartido;
                    txtFPartidoId.BackColor = colorOk;
                    this.cmbFPartido.SelectedIndexChanged += new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
                }
            }



            if (_localidad != null)
            {
                var idLocalidad = Address.ExisteEstaLocalidad(_localidad.ToUpper());
                if (idLocalidad == -1)
                {
                    txtFLocalidadId.Text = null;
                    txtFLocalidadId.BackColor = colorNo;
                    this.cmbFLocalidad.SelectedIndexChanged -= new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);
                    LocalidadBs.DataSource = Address.GetListadoLocalidades();
                    cmbFLocalidad.SelectedIndex = -1;
                    this.cmbFLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);
                }
                else
                {
                    txtFLocalidadId.Text = idLocalidad.ToString();
                    Address.SetLocalidadSeleccionada(idLocalidad, _localidad);
                    LocalidadBs.DataSource = Address.GetListadoLocalidades();
                    this.cmbFLocalidad.SelectedIndexChanged -= new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);
                    cmbFLocalidad.SelectedValue = idLocalidad;
                    txtFLocalidadId.BackColor = colorOk;
                    this.cmbFLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);

                    if (idPartido == -1)
                    {
                        //intenta ver si al verificar la localidad encontro un partido
                        var xIdPartido = Address.GetIdPartidoSeleccionado();
                        if (xIdPartido == null)
                        {
                            // no encontro nada.- 
                        }
                        else
                        {
                            partidoBs.DataSource = Address.GetListadoPartido();
                            txtFPartidoId.Text = xIdPartido.Value.ToString();
                            Address.SetPartidoSeleccionado(idPartido, _partido);
                            txtFPartidoId.BackColor = colorOk;
                            cmbFPartido.BackColor = colorOk;
                            cmbFPartido.SelectedValue = xIdPartido.Value;
                        }
                    }
                }
            }
            else
            {
                txtFLocalidadId.Text = null;
                txtFLocalidadId.BackColor = colorNoDef;
                this.cmbFLocalidad.SelectedIndexChanged -= new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);
                LocalidadBs.DataSource = Address.GetListadoLocalidades();
                cmbFLocalidad.SelectedValue = -1;
                this.cmbFLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);

            }
        }
        private void btnUtilizar_Click(object sender, EventArgs e)
        {
            if (ckSoloEstructuraValida.Checked)
            {

            }
            else
            {
                //Si no es mandatorio que la estructura sea valida
                //remapea los valores de TEXT.-
                Address.SetValoresSinValidar(txtFPais.Text, cmbFProvincia.Text, cmbFPartido.Text, cmbFLocalidad.Text);
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
        private void btnNewStruct_Click(object sender, EventArgs e)
        {

        }
        private void SeteaProperitesComboboxAddress()
        {
            //private void cmbFProvincia_SelectedIndexChanged(object sender, EventArgs e)
            this.cmbFProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbFProvincia_SelectedIndexChanged);
            this.cmbFProvincia.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFProvincia_Validating);

            this.cmbFPartido.SelectedIndexChanged += new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
            this.cmbFPartido.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFPartido_Validating);
            this.cmbFPartido.Enter += new System.EventHandler(this.cmbFPartido_Enter);

            this.cmbFLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);
            this.cmbFLocalidad.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFLocalidad_Validating);
            this.cmbFLocalidad.Enter += new System.EventHandler(this.cmbFLocalidad_Enter);
        }
        private void cmbFProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFProvincia.SelectedIndex == -1)
            {
                Address.SetProvinciaSeleccionada(null, null);
                txtFProvinciaId.BackColor = colorNo;
                txtFProvinciaId.Text = null;
            }
            else
            {
                Address.SetProvinciaSeleccionada(Convert.ToInt32(cmbFProvincia.SelectedValue), cmbFProvincia.Text);
                txtFProvinciaId.Text = cmbFProvincia.SelectedValue.ToString();
                txtFProvinciaId.BackColor = colorOk;
            }

            partidoBs.DataSource = Address.GetListadoPartido();
            LocalidadBs.DataSource = Address.GetListadoLocalidades();
            //anular la ejecucion aca
            this.cmbFPartido.SelectedIndexChanged -= new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
            this.cmbFLocalidad.SelectedIndexChanged -= new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);
            cmbFPartido.SelectedIndex = -1;
            cmbFLocalidad.SelectedIndex = -1;
            this.cmbFPartido.SelectedIndexChanged += new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
            this.cmbFLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);

        }
        private void cmbFPartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFPartido.SelectedIndex == -1)
            {
                Address.SetPartidoSeleccionado(null, null);
                txtFPartidoId.BackColor = colorNo;
                txtFPartidoId.Text = null;
                return;
            }

            Address.SetPartidoSeleccionado(Convert.ToInt32(cmbFPartido.SelectedValue), cmbFPartido.Text);
            LocalidadBs.DataSource = Address.GetListadoLocalidades();
            cmbFLocalidad.SelectedIndex = -1;
            txtFPartidoId.Text = cmbFPartido.SelectedValue.ToString();
            txtFPartidoId.BackColor = colorOk;
            txtFLocalidadId.Text = null;
            txtFLocalidadId.BackColor = colorNo;
        }
        private void cmbFLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFLocalidad.SelectedIndex == -1)
            {
                Address.SetLocalidadSeleccionada(null, null);
                return;
            }

            Address.SetLocalidadSeleccionada(Convert.ToInt32(cmbFLocalidad.SelectedValue), cmbFLocalidad.Text);
            txtFLocalidadId.Text = cmbFLocalidad.SelectedValue.ToString();
            txtFLocalidadId.BackColor = colorOk;

            if (cmbFPartido.SelectedValue == null)
            {
                txtFPartidoId.Text = Address.GetIdPartidoSeleccionado().ToString();
                this.cmbFPartido.SelectedIndexChanged -= new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
                this.cmbFLocalidad.SelectedIndexChanged -= new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);
                this.cmbFLocalidad.SelectedIndexChanged -= new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);
                this.cmbFPartido.SelectedIndexChanged -= new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
                cmbFPartido.SelectedValue = Address.GetIdPartidoSeleccionado();
                //txtFPartidoId.Text = cmbFPartido.SelectedValue.ToString();
                //txtFPartidoId.BackColor = colorOk;
                this.cmbFPartido.SelectedIndexChanged += new System.EventHandler(this.cmbFPartido_SelectedIndexChanged);
                this.cmbFLocalidad.SelectedIndexChanged += new System.EventHandler(this.cmbFLocalidad_SelectedIndexChanged);
                txtFPartidoId.BackColor = colorOk;
            }
        }

        private void cmbFProvincia_Validating(object sender, CancelEventArgs e)
        {
            if (cmbFProvincia.SelectedValue == null)
            {
                Address.SetProvinciaSeleccionada(null, null);
                partidoBs.DataSource = Address.GetListadoPartido();
                LocalidadBs.DataSource = Address.GetListadoLocalidades();
                cmbFPartido.SelectedIndex = -1;
                cmbFLocalidad.SelectedIndex = -1;
                toolTip1.ToolTipTitle = "Sin Datos en Partido";
                toolTip1.Show("Seleccione una Provincia para desplegar los datos de Partido", cmbFPartido,
                    cmbFPartido.Location, 5000);
                txtFProvinciaId.Text = null;
                txtFPartidoId.Text = null;
                txtFLocalidadId.Text = null;

                txtFProvinciaId.BackColor = colorNo;
                txtFPartidoId.BackColor = colorNo;
                txtFLocalidadId.BackColor = colorNo;
            }
        }
        //Si borra el dato del Partido
        private void cmbFPartido_Validating(object sender, CancelEventArgs e)
        {
            if (cmbFPartido.SelectedValue == null)
            {
                Address.SetPartidoSeleccionado(null, null);
                LocalidadBs.DataSource = Address.GetListadoLocalidades();
                cmbFLocalidad.SelectedIndex = -1;
                txtFPartidoId.Text = null;
                txtFLocalidadId.Text = null;
                txtFPartidoId.BackColor = colorNo;
                txtFLocalidadId.BackColor = colorNo;
                return;
            }
        }
        private void cmbFLocalidad_Validating(object sender, CancelEventArgs e)
        {
            if (cmbFLocalidad.SelectedValue == null)
            {
                txtFLocalidadId.Text = null;
                txtFLocalidadId.BackColor = colorNo;
            }
        }

        private void cmbFPartido_Enter(object sender, EventArgs e)
        {
            if (partidoBs.Count == 0)
            {
                toolTip1.ToolTipTitle = "Sin Datos en Partido";
                toolTip1.Show("Seleccione una Provincia para desplegar los datos de Partido", cmbFPartido,
                    cmbFPartido.Location, 5000);
            }
        }
        private void cmbFLocalidad_Enter(object sender, EventArgs e)
        {
            if (LocalidadBs.Count == 0)
            {
                toolTip1.ToolTipTitle = "Sin Datos en Localidad";
                toolTip1.Show("Seleccione una Provincia para desplegar los datos de Localidad", cmbFLocalidad,
                    cmbFLocalidad.Location, 5000);
            }
        }

    }
}
