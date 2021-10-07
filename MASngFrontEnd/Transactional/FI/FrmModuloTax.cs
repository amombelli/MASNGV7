using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.TOOLS;

namespace MASngFE.Transactional.FI
{
    public partial class FrmModuloTax : Form
    {
        public FrmModuloTax()
        {
            InitializeComponent();
        }


        private bool _esCliente;
        private int _idPC;


        public FrmModuloTax(bool esCliente, int idpc)
        {
            _esCliente = esCliente;
            _idPC = idpc;
            InitializeComponent();
        }
        private void FrmModuloTax_Load(object sender, EventArgs e)
        {
            mapeoData_Form();
        }

        private void btnConectarPadron_Click(object sender, EventArgs e)
        {

        }

        #region mapeoData-Form

        private void mapeoData_Form()
        {
            if (_esCliente == true)
            {
                txtPC.Text = "CLIENTE";
                var data = new CustomerManager().GetCustomerBillToData(_idPC);
                txtCUIT.Text = data.CUIT;
                txtRazonSocial.Text = data.cli_rsocial;
                cmbTaxType.DisplayMember = "TaxDescription";
                cmbTaxType.ValueMember = "TAXID";
                cmbTaxType.DataSource = new TaxDataManager().GetListaTaxRetPer("C");

            }
            else
            {
                txtPC.Text = "PROVEEDOR";
                var data = new VendorManager().GetSpecificVendor(_idPC);
                txtCUIT.Text = data.NTAX1;
                txtRazonSocial.Text = data.prov_rsocial;
                cmbTaxType.DisplayMember = "TaxDescription";
                cmbTaxType.ValueMember = "TAXID";
                cmbTaxType.DataSource = new TaxDataManager().GetListaTaxRetPer("P");
            }
            txtIdPC.Text = _idPC.ToString();
            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtPeriodo.Text = new PeriodoConversion().GetPeriodo(Convert.ToDateTime(txtFecha.Text));
            txtFechaDesde.Text = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text).ToShortDateString();
            txtFechaHasta.Text = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text).ToShortDateString();
        }
        #endregion




        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTaxType_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cmbTaxType.SelectedValue.ToString())
            {
                case "COEFCM05":
                    btnConectarPadron.Enabled = false;
                    break;
                case "PER_GS":
                    btnConectarPadron.Enabled = false;
                    break;
                case "PER_IB_BS":
                    btnConectarPadron.Enabled = true;
                    break;
                case "RET_GS":
                    btnConectarPadron.Enabled = false;
                    break;
                case "RET_IB_BS":
                    btnConectarPadron.Enabled = true;
                    break;
            }







        }

        #region mapeoForm-Data

        #endregion
    }
}
