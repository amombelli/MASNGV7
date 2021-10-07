using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;

namespace MASngFE.MasterData.Customer_Master
{
    public partial class FrmMdc06CobranzaDataMaintain : Form
    {
        private readonly int _idCliente;

        public FrmMdc06CobranzaDataMaintain(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }

        private void FrmMdc06CobranzaDataMaintain_Load(object sender, EventArgs e)
        {
            var cust = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtRazonSocial.Text = cust.cli_rsocial;
            txtFantasia.Text = cust.cli_fantasia;
            txtContacto.Text = cust.CONTACTO_COB;
            txtTelefonoCob1.Text = cust.TELEFONO_COB;
            txtTelefonoCob2.Text = cust.TelefonoCobranza2;
            txtEmailCob.Text = cust.EMAIL_COBR;
            if (string.IsNullOrEmpty(cust.DIRECCION_COBRO_ALT))
            {
                ckDireccionFiscal.Checked = true;
                txtDireccionCob.Text = cust.Direccion_facturacion + @" " + cust.DireFactu_Num + @"/" + cust.Direfactu_Provincia + @"/" +
                                       cust.Direfactu_Localidad;
            }
            else
            {
                ckDireccionFiscal.Checked = false;
                txtDireccionCob.Text = cust.DIRECCION_COBRO_ALT;
            }
            txtDiasHorariosPago.Text = cust.DIA_HORARIO_COBRO;
        }

        private void cmbEditDatosCliente_Click(object sender, EventArgs e)
        {
            new CustomerManager().UpdateDatosCobranza(_idCliente, txtContacto.Text, txtTelefonoCob1.Text,
                txtTelefonoCob2.Text, txtEmailCob.Text, txtDireccionCob.Text, txtDiasHorariosPago.Text,
                ckDireccionFiscal.Checked);

            MessageBox.Show(@"Los Datos se han Actualizado Correctamente!", @"Datos de Cobranza Actualizados",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;

        }

        private void ckDireccionFiscal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDireccionFiscal.Checked)
            {
                var cust = new CustomerManager().GetCustomerBillToData(_idCliente);
                txtDireccionCob.Text = cust.Direccion_facturacion + @" " + cust.DireFactu_Num + @"/" + cust.Direfactu_Provincia + @"/" +
                                       cust.Direfactu_Localidad;
            }
            else
            {
                txtDireccionCob.Text = null;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
