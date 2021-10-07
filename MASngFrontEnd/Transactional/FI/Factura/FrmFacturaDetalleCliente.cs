using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;

namespace MASngFE.Transactional.FI.Factura
{
    public partial class FrmFacturaDetalleCliente : Form
    {
        public FrmFacturaDetalleCliente(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }

        private readonly int _idCliente;
        private void FrmFacturaDetalleCliente_Load(object sender, EventArgs e)
        {
            var data = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtCUIT.Text = data.CUIT;
            txtCodigoPostal.Text = data.ZIP;
            txtDireccionFiscal.Text = data.Direccion_facturacion;
            txtEmailFacturacion.Text = data.EMAIL_FACTU;
            txtFantasia.Text = data.cli_fantasia;
            txtIdCliente.Text = _idCliente.ToString();
            txtLimiteCredito.Text = data.Limite_credito.Value.ToString("C2");
            txtLocalidad.Text = data.Direfactu_Localidad;
            txtProvincia.Text = data.Direfactu_Provincia;
            txtZtermL1.Text = data.ZTERML1;
            txtZtermL2.Text = data.ZTERML2;
            ckClienteActivo.Checked = data.ACTIVO;
            ckBlkDespacho.Checked = data.BLK_DELIVERY;
            ckBlkPedido.Checked = data.BLK_PEDIDO;
            txtZtermL1Desc.Text = new ZtermManager().GetDescripcionZTerm(data.ZTERML1);
            txtZtermL2Desc.Text = new ZtermManager().GetDescripcionZTerm(data.ZTERML2);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
    }
}
