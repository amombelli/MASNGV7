using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.Transactional.FI.Customers;

namespace MASngFE.FIX
{
    public partial class FrmMergeCustomersData : Form
    {
        public FrmMergeCustomersData()
        {
            InitializeComponent();
        }

        private int _id6Mantener;
        private int _id6Caducar;

        private void FrmMergeCustomersData_Load(object sender, EventArgs e)
        {
            cmbClienteMantener.ValueMember = "IDCLIENTE";
            cmbClienteCaducar.DataSource = new CustomerManager().GetCompleteListofBillTo(true).ToList();
            cmbClienteMantener.DataSource = new CustomerManager().GetCompleteListofBillTo(false).ToList();
        }
        private void cmbClienteMantener_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId6Mantener.Text = cmbClienteMantener.SelectedValue.ToString();
            _id6Mantener = Convert.ToInt32(cmbClienteMantener.SelectedValue);
            if (_id6Mantener > 0)
            {
                CompletaDatosMantener();
            }
        }
        private void cmbClienteCaducar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId6Caducar.Text = cmbClienteCaducar.SelectedValue.ToString();
            _id6Caducar = Convert.ToInt32(cmbClienteCaducar.SelectedValue);
            if (_id6Caducar > 0)
            {
                CompletaDatosCaducar();
            }
        }
        private void CompletaDatosMantener()
        {
            txtShiptosMantener.Text = new CustomerManager().GetNumberofShipTos(_id6Mantener, true).ToString();
            //txtSaldoL1Mantener.Text = new CustomerCtaCteSaldos(_id6Mantener).SaldoL1.ToString("N2");
            //txtSaldoL2Mantener.Text = new CustomerCtaCteSaldos(_id6Mantener).SaldoL2.ToString("N2");
            txtSaldoSinImputarMantener.Text = new ManageSinImputar(_id6Mantener).GetSaldosSinImputar().ToString("N2");

            var ctaCte = new CtaCteCustomer(_id6Mantener);
            var saldoL1 = ctaCte.GetResultadoCtaCte("L1");
            var saldoL2 = ctaCte.GetResultadoCtaCte("L2");
            txtSaldoL1Mantener.Text = saldoL1.SaldoDetalle.ToString("N2");
            txtSaldoL2Mantener.Text = saldoL2.SaldoDetalle.ToString("N2");
            txtSaldoL1Mantener.BackColor = saldoL1.SaldoColor;
            txtSaldoL2Mantener.BackColor = saldoL2.SaldoColor;
        }
        private void CompletaDatosCaducar()
        {
            txtShiptosCadudcar.Text = new CustomerManager().GetNumberofShipTos(_id6Caducar, true).ToString();
            //txtSaldoL1Caducar.Text = new CustomerCtaCteSaldos(_id6Caducar).SaldoL1.ToString("N2");
            //txtSaldoL2Caducar.Text = new CustomerCtaCteSaldos(_id6Caducar).SaldoL2.ToString("N2");
            txtSaldoSinImputarCaducar.Text = new ManageSinImputar(_id6Caducar).GetSaldosSinImputar().ToString("N2");

            var ctaCte = new CtaCteCustomer(_id6Caducar);
            var saldoL1 = ctaCte.GetResultadoCtaCte("L1");
            var saldoL2 = ctaCte.GetResultadoCtaCte("L2");
            txtSaldoL1Caducar.Text = saldoL1.SaldoDetalle.ToString("N2");
            txtSaldoL2Caducar.Text = saldoL2.SaldoDetalle.ToString("N2");
            txtSaldoL1Caducar.BackColor = saldoL1.SaldoColor;
            txtSaldoL2Caducar.BackColor = saldoL2.SaldoColor;

        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show(@"Confirma la ejecucion del Merge de acuerdo a los datos?",
                @"Merge de Cuentas de Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.No)
                return;

            var data = new MergeClientes(_id6Caducar, _id6Mantener);
            ckT0201.Checked = data.Merge201();
            ckT0202L1.Checked = data.Merge202("L1");
            ckT0202L2.Checked = data.Merge202("L2");
            ckT0207.Checked = data.Merge207();
            ckT0208.Checked = data.Merge208();
            ckCobranzas.Checked = data.MergeCobranzas();
            ckCheques.Checked = data.MergeCheques();
            ckRemitos.Checked = data.MergeRemitos();
            ckOrdenVenta.Checked = data.MergeOrdenVenta();
            ckTabla40.Checked = data.MergeT40();
            ckTabla601.Checked = data.MergeAsientos();
            ckFacturas.Checked = data.MergeFacturas();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
