using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.FI;
using Tecser.Business.WebServices;

namespace MASngFE.Transactional.FI
{
    public partial class FrmCalculoRetenciones : Form
    {
        public FrmCalculoRetenciones(int numeroOP, int vendorId)
        {
            InitializeComponent();
            _numeroOP = numeroOP;
            _idVendor = vendorId;
        }

        private int _numeroOP;
        private int _idVendor;


        private void cmbConceptoRetGs_SelectedValueChanged(object sender, EventArgs e)
        {

            var data = new TaxDataManager().GetValorRetGanancias(Convert.ToInt32(cmbConceptoRetGs.SelectedValue));

            switch (cmbConceptoRetGs.SelectedValue.ToString())
            {
                case "78":

                    break;
                case "0":
                    break;
                case "94":
                    break;
                default:
                    MessageBox.Show("Categoria no mantenida", "Retencion Ganancias", MessageBoxButtons.OK);

                    break;
            }

            txtAlicuotaRetencionGS.Text = data.AlicRetencionInscripto.ToString();
            txtBaseImponibleGS.Text = data.BaseNoRetencion.ToString();
        }

        private void FrmCalculoRetenciones_Load(object sender, EventArgs e)
        {
            var data = new VendorManager().GetSpecificVendor(_idVendor);
            txtRazonSocial.Text = data.prov_rsocial;
            txtCuit.Text = data.NTAX1;
            txtIdProveddor.Text = _idVendor.ToString();
            txtNumeroOP.Text = _numeroOP.ToString();
            var dataOP = new OrdenPagoManageDatos().GetDatosHeaderFromDb();
            txtPeriodo.Text = dataOP.Periodo;
            txtFechaDesde.Text = new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(txtPeriodo.Text);
            txtFechaHasta.Text = new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(txtPeriodo.Text);

            var iibb = new PadronArba();
            iibb.Conectar(txtCuit.Text, txtFechaDesde.Text, txtFechaHasta.Text);
            txtAlicuotaRetencionIIBB.Text = iibb.AlRete.ToString();
            txtAlicuotaPercepcionIIBB.Text = iibb.AlPerc.ToString();


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdProveddor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
