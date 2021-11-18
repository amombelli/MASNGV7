using System;
using System.Drawing;
using System.Windows.Forms;
using WebServicesAFIP;

namespace MASngFE.Forms
{
    public partial class FrmAPP04_DatosPadron : Form
    {
        private readonly string _numeroDocumento;
        private readonly string _tipodocumento;
        public EstructuraPadronAfipA5 cn { get; private set; }
        public int IdLocalidad { get; private set; }
        public FrmAPP04_DatosPadron(string numeroDocumento, string tipodocumento = "80")
        {
            _numeroDocumento = numeroDocumento;
            _tipodocumento = tipodocumento;
            InitializeComponent();
        }

        private void btnAutoComplete_Click(object sender, EventArgs e)
        {
            var dire = ctlAddress1.GetData();
            IdLocalidad = dire.IdLocalidad;
            if (IdLocalidad < 1)
            {
                var r = MessageBox.Show(@"Desea continuar sin mapear la localidad en el recuadro rojo?",
                    @"Datos de Direccion no validados correctamente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return;
            }

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void FrmAPP04_DatosPadron_Load(object sender, EventArgs e)
        {
            mtxtNumeroDocumento.Text = _numeroDocumento;
            txtTipoDocumento.Text = _tipodocumento;

            if (string.IsNullOrEmpty(mtxtNumeroDocumento.Text))
            {
                MessageBox.Show(@"Debe completar el numero de CUIT para poder obtener la info desde el WebServices",
                    @"WebService AFIP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtTipoDocumento.Text != @"80")
            {
                MessageBox.Show(@"Esta funcionalidad funciona unicamente para CUIT validados",
                    @"WebService AFIP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var r = MessageBox.Show(@"Desea obtener los datos del proveedor desde el Padron AFIP?", @"WebService AFIP",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No) return;

            Cursor.Current = Cursors.WaitCursor;
            cn = new PadronAfipWsA5(ModoEjecucion.Produccion).ObtieneDatosPadronA5(_numeroDocumento);
            if (string.IsNullOrEmpty(cn.Denominacion))
            {
                MessageBox.Show(
                    $@"No se pudieron obetner datos del CUIT {mtxtNumeroDocumento.Text} en forma automatica",
                    @"Error en Info Retornada", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (cn.Estado != "ACTIVO")
            {
                MessageBox.Show(@"El CUIT del proveedor se encuentra INACTIVO en AFIP", @"Atencion Proveedor INACTIVO",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            txtRazonSocial.Text = cn.Denominacion;
            txtRazonSocial.ForeColor = Color.Red;

            txtDireccion.Text = cn.Direccion;
            txtDireccion.ForeColor = Color.Red;
            txtCodigoPostal.Text = cn.CodPostal;
            txtCodigoPostal.ForeColor = Color.Red;
            ctlAddress1.CargaControl("AR", cn.Provincia, "", cn.Localidad);
            if (cn.TipoDocumento == 80)
            {
                cmbTipoDocumento.SelectedItem = "CUIT";
                txtCondicionIVA.Text = @"RI";
                txtCondicionIVA.ForeColor = Color.Red;
            }

            txtprovincia.Text = cn.Provincia;
            txtLocalidad.Text = cn.Localidad;

            txtactmonotributo.Text = cn.ActividadMonotributo.ToString();
            txtEmpleador.Text = cn.Empleador;
            txtIva.Text = cn.IVA;
            txtMonotributo.Text = cn.Monotributo;
            txtPersona.Text = cn.TipoPersona;
            txtTipoDocumento.Text = cn.TipoDocumento.ToString();
            Cursor.Current = Cursors.Default;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
