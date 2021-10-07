using System;
using System.Drawing;
using System.Windows.Forms;
using WebServicesAFIP;

namespace MASngFE.MasterData.Customer_Master
{
    public partial class FrmUt01ObtieneDatosPadronAFIP : Form
    {
        public FrmUt01ObtieneDatosPadronAFIP()
        {
            InitializeComponent();
        }
        public FrmUt01ObtieneDatosPadronAFIP(string numeroCuit, string funcion)
        {
            _numeroCuit = numeroCuit;
            _funcion = funcion;
            InitializeComponent();
        }

        //--------------------------------------------------------------
        private string _numeroCuit;
        private readonly string _funcion;
        public EstructuraPadronAfipA5 Estructura;
        //--------------------------------------------------------------

        private void FrmDatosPadronAfip_Load(object sender, EventArgs e)
        {
            AccionSegunFuncion();
        }


        private void AccionSegunFuncion()
        {
            switch (_funcion)
            {
                case "CMD":
                    AccionConsultaData();
                    break;
                default:
                    break;
            }
        }

        private void AccionConsultaData()
        {
            txtNumeroDocumento.Enabled = false;
            txtNumeroDocumento.Text = _numeroCuit;
            txtNumeroDocumento.BackColor = Color.LightGreen;
            txtValidacion.Text = @"VALIDO";
            btnPadron.Enabled = false;
            ConsultarPadron();

        }
        private void ConsultarPadron()
        {
            Estructura = new PadronAfipWsA5(ModoEjecucion.Produccion).ObtieneDatosPadronA5(txtNumeroDocumento.Text);

            //Estructura = new PadronAfipWs(ModoEjecucion.Produccion).ObtenerDatosPadron(txtNumeroDocumento.Text);
            txtRazonSocial.Text = Estructura.Denominacion;
            txtDireccionFiscal.Text = Estructura.Direccion;
            txtEstado.Text = Estructura.Estado;
            txtLocalidad.Text = Estructura.Localidad;
            txtProvincia.Text = Estructura.Provincia;
            txtCodigoPostal.Text = Estructura.CodPostal;
        }
        private void btnPadron_Click(object sender, EventArgs e)
        {


            ConsultarPadron();
        }
        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void btnMapear_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;

        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Ignore;
            return;
        }
    }
}
