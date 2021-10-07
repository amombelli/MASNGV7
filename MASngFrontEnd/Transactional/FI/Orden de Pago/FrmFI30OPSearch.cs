using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.OrdenPago;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI30OPSearch : Form
    {
        public FrmFI30OPSearch()
        {
            InitializeComponent();
        }
        public FrmFI30OPSearch(int modo)
        {
            InitializeComponent();
            _modo = modo;
        }

        private readonly int _modo;
        private void FrmOrdenPagoSearch_Load(object sender, EventArgs e)
        {
            switch (_modo)
            {
                case 0:
                    btnNuevo.Enabled = true;
                    btnExit.Enabled = true;
                    break;
                case 1:
                    btnNuevo.Enabled = true;

                    break;
                case 2:
                    btnNuevo.Enabled = false;
                    break;
                case 3:
                    btnNuevo.Enabled = false;
                    break;
                default:
                    //Modo prueba default = 0 
                    btnNuevo.Enabled = true;
                    break;
            }

            cmbRazonSocial.ValueMember = "id_prov";
            cmbRazonSocial.DisplayMember = "prov_rsocial";

            cmbFantasia.ValueMember = "id_prov";
            cmbFantasia.DisplayMember = "PROV_FANTASIA";

            cmbIdVendor.ValueMember = "id_prov";
            cmbIdVendor.DisplayMember = "ID_PROV";

            cmbRazonSocial.DataSource = new VendorManager().GetCompleteListVendors(true);
            cmbFantasia.DataSource = new VendorManager().GetCompleteListVendors(true);
            cmbIdVendor.DataSource = new VendorManager().GetCompleteListVendors(true);
            cmbRazonSocial.SelectedValue = -1;
            cmbFantasia.SelectedValue = -1;
            cmbIdVendor.SelectedValue = -1;
            dgvOPLista.DataSource = new OrdenPagoFilter().GetOrdenPagoList(null);
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                btnNuevo.Enabled = false;
                btnDetalleDeuda.Enabled = false;
                return;
            }
            btnNuevo.Enabled = true;
            btnDetalleDeuda.Enabled = true;
            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
            cmbIdVendor.SelectedValue = cmbRazonSocial.SelectedValue;

            if (string.IsNullOrEmpty(cmbEstadoOP.Text))
            {
                dgvOPLista.DataSource =
                    new OrdenPagoFilter().GetOrdenPagoList(Convert.ToInt32(cmbRazonSocial.SelectedValue), null);
            }
            else
            {
                dgvOPLista.DataSource =
                    new OrdenPagoFilter().GetOrdenPagoList(Convert.ToInt32(cmbRazonSocial.SelectedValue),
                        cmbEstadoOP.Text);
            }
            this.txtNumeroOP.TextChanged -= new System.EventHandler(this.txtNumeroOP_TextChanged);
            txtNumeroOP.Text = null;
            this.txtNumeroOP.TextChanged += new System.EventHandler(this.txtNumeroOP_TextChanged);
            var vendor = new VendorAccountManager();
            txtSaldoL1.Text = vendor.GetSaldoL1(Convert.ToInt32(cmbIdVendor.SelectedValue)).ToString("C2");
            txtSaldoL2.Text = vendor.GetSaldoL2(Convert.ToInt32(cmbIdVendor.SelectedValue)).ToString("C2");
            txtSaldoL1.BackColor = vendor.ColorSaldoL1;
            txtSaldoL2.BackColor = vendor.ColorSaldoL2;

            txtSaldoTotalL1.Text = vendor.GetSaldoL1FromT0203(Convert.ToInt32(cmbIdVendor.SelectedValue)).ToString("C2");
            txtSaldoTotalL2.Text = vendor.GetSaldoL2FromT0203(Convert.ToInt32(cmbIdVendor.SelectedValue)).ToString("C2");
        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFantasia.SelectedIndex == -1)
                return;

            cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
            cmbIdVendor.SelectedValue = cmbFantasia.SelectedValue;
        }
        private void cmbIdVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdVendor.SelectedIndex == -1)
                return;

            cmbRazonSocial.SelectedValue = cmbIdVendor.SelectedValue;
            cmbFantasia.SelectedValue = cmbIdVendor.SelectedValue;
        }
        private void cmbEstadoOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string estado = null;

            if (!String.IsNullOrEmpty(cmbEstadoOP.Text))
            {
                estado = cmbEstadoOP.Text;
            }

            if (cmbRazonSocial.SelectedIndex == -1)
            {
                dgvOPLista.DataSource = new OrdenPagoFilter().GetOrdenPagoList(null, estado);
            }
            else
            {
                dgvOPLista.DataSource =
                    new OrdenPagoFilter().GetOrdenPagoList(Convert.ToInt32(cmbRazonSocial.SelectedValue), estado);
            }
            this.txtNumeroOP.TextChanged -= new System.EventHandler(this.txtNumeroOP_TextChanged);
            txtNumeroOP.Text = null;
            this.txtNumeroOP.TextChanged += new System.EventHandler(this.txtNumeroOP_TextChanged);
        }
        private void txtNumeroOP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroOP.Text) != true)
                dgvOPLista.DataSource = new OrdenPagoFilter().GetOrdenPagoByNumber(Convert.ToInt32(txtNumeroOP.Text));

            this.txtNumeroOP.TextChanged -= new System.EventHandler(this.txtNumeroOP_TextChanged);
            this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);


            cmbRazonSocial.Text = null;
            cmbFantasia.Text = null;
            cmbEstadoOP.Text = null;
            cmbIdVendor.Text = null;
            cmbEstadoOP.Text = null;

            this.txtNumeroOP.TextChanged += new System.EventHandler(this.txtNumeroOP_TextChanged);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);

        }
        private void btnLimpiaDatos_Click(object sender, EventArgs e)
        {
            cmbRazonSocial.Text = null;
            cmbIdVendor.Text = null;
            cmbFantasia.Text = null;
            txtNumeroOP.Text = null;
            cmbEstadoOP.Text = null;
            txtSaldoL1.Text = null;
            txtSaldoL2.Text = null;
            dgvOPLista.DataSource = new OrdenPagoFilter().GetAllOPList();
        }
        private void dgvOPLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvOPLista[e.ColumnIndex, e.RowIndex].Value.ToString();
                switch (cellValue)
                {
                    case "DETALLE":
                        {
                            var idOP = Convert.ToInt32(dgvOPLista[0, e.RowIndex].Value);
                            var f2 = new FrmFI31OPMainScreen(idOP);
                            f2.Show();
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                MessageBox.Show(@"Seleccione un Proveedor para generar Orden de Pago", @"Validacion de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var f2 = new FrmFI31OPMainScreen((int)cmbRazonSocial.SelectedValue, 1);
            f2.Show();

        }
        private void cmbEstadoOP_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbEstadoOP.Text))
            {
                if (cmbRazonSocial.SelectedIndex == -1)
                {
                    dgvOPLista.DataSource =
                   new OrdenPagoFilter().GetOrdenPagoList(null, null);

                }
                else
                {
                    dgvOPLista.DataSource =
                   new OrdenPagoFilter().GetOrdenPagoList(Convert.ToInt32(cmbRazonSocial.SelectedValue), null);

                }
            }
            //si no es vacio ya fue filtrado!
        }
        private void ckSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            cmbRazonSocial.DataSource = new VendorManager().GetCompleteListVendors(ckSoloActivos.Checked);
            cmbFantasia.DataSource = new VendorManager().GetCompleteListVendors(ckSoloActivos.Checked);
            cmbIdVendor.DataSource = new VendorManager().GetCompleteListVendors(ckSoloActivos.Checked);
            cmbRazonSocial.SelectedValue = -1;
            cmbFantasia.SelectedValue = -1;
            cmbIdVendor.SelectedValue = -1;
            dgvOPLista.DataSource = new OrdenPagoFilter().GetOrdenPagoList(null);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDetalleDeuda_Click_1(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedValue != null)
            {
                var f = new FrmDetalleDeudaProveedeor(Convert.ToInt32(cmbRazonSocial.SelectedValue));
                f.Show();
            }
        }

        private void BtnFix_Click(object sender, EventArgs e)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var lop = db.T0210_OP_H.Where(c => c.DiasPPFacturas == null).OrderByDescending(c => c.OPFECHA).Take(100).ToList();
                foreach (var i in lop)
                {
                    i.DiasPPFacturas = new EstadisticasPagoOP().DiasPagoFactura(i.IDOP);
                    i.DiasPPItemsPago = new EstadisticasPagoOP().DiasPPItemsPagoDesdeFechaOP(i.IDOP);
                    db.SaveChanges();
                }
            }

            MessageBox.Show(@"FIX DiasPP Finalizado");
        }
    }
}






