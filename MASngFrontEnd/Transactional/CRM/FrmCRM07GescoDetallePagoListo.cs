using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CRM;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmCRM07GescoDetallePagoListo : Form
    {
        private readonly int _idRecord;

        public FrmCRM07GescoDetallePagoListo(int idRecord)
        {
            _idRecord = idRecord;
            InitializeComponent();
        }

        private void FrmCRM07GescoDetallePagoListo_Load(object sender, EventArgs e)
        {

        }


        private void CompletaDatos()
        {
            var pl = new GescoPagoListo().GetDataRecord(_idRecord);
            var cust = new CustomerManager().GetCustomerBillToData(pl.idCliente);
            txtRazonSocial.Text = cust.cli_rsocial;
            txtFantasia.Text = cust.cli_fantasia;
            txtDireccionFiscal.Text = cust.Direccion_facturacion;
            txtProvincia.Text = cust.Direfactu_Provincia;
            txtLocalidad.Text = cust.Direfactu_Localidad;

            txtFechaConfirmada.Text = pl.FechaPago.ToString("d");
            if (pl.FechaModificada == null)
                pl.FechaModificada = false;

            ckFModificada.Checked = pl.FechaModificada.Value;
            txtDireccion.Text = pl.Direccion;

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
