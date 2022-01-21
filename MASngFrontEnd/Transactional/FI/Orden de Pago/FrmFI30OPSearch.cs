using System;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
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

            dgvOPLista.DataSource = new OrdenPagoFilter().GetOrdenPagoList(null);
        }
 
        private void cmbEstadoOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string estado = null;

            if (!String.IsNullOrEmpty(cmbEstadoOP.Text))
            {
                estado = cmbEstadoOP.Text;
            }
            if (tsUcVendorSelector1.VendorId == null || tsUcVendorSelector1.VendorId.Value < 1)
            {
                dgvOPLista.DataSource = new OrdenPagoFilter().GetOrdenPagoList(null, estado);
            }
            else
            {
                dgvOPLista.DataSource =
                    new OrdenPagoFilter().GetOrdenPagoList(tsUcVendorSelector1.VendorId.Value, estado);
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
            tsUcVendorSelector1.VendorId = -1;

        }
        private void btnLimpiaDatos_Click(object sender, EventArgs e)
        {
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
            if (tsUcVendorSelector1.VendorId ==null || tsUcVendorSelector1.VendorId.Value<1)
            {
                MessageBox.Show(@"Seleccione un Proveedor para generar Orden de Pago", @"Validacion de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var f2 = new FrmFI31OPMainScreen(tsUcVendorSelector1.VendorId.Value, 1);
            f2.Show();

        }
        private void cmbEstadoOP_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbEstadoOP.Text))
            {
                if (tsUcVendorSelector1.VendorId==null || tsUcVendorSelector1.VendorId.Value<1)
                {
                    dgvOPLista.DataSource =
                   new OrdenPagoFilter().GetOrdenPagoList(null, null);

                }
                else
                {
                    dgvOPLista.DataSource =
                   new OrdenPagoFilter().GetOrdenPagoList(tsUcVendorSelector1.VendorId.Value, null);

                }
            }
            //si no es vacio ya fue filtrado!
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDetalleDeuda_Click_1(object sender, EventArgs e)
        {
            if (tsUcVendorSelector1.VendorId == null || tsUcVendorSelector1.VendorId == -1)
            {
                MessageBox.Show(@"Debe seleccionar un proveedor para visualizar su detalle de deuda",
                    @"Proveedor no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var f = new FrmFI33DocumentosPendientesPago(tsUcVendorSelector1.VendorId.Value,0);
            f.Show();
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

        private void tsUcVendorSelector1_VendorUpdated(object source, _0TSUserControls.VendorSearchUcArgs args)
        {
            if (args.VendorId == null)
            {
                btnNuevo.Enabled = false;
                btnDetalleDeuda.Enabled = false;
                return;
            }
            btnNuevo.Enabled = true;
            btnDetalleDeuda.Enabled = true;
            dgvOPLista.DataSource = new OrdenPagoFilter().GetOrdenPagoList(args.VendorId.Value,
                string.IsNullOrEmpty(cmbEstadoOP.Text) ? null : cmbEstadoOP.Text);

            this.txtNumeroOP.TextChanged -= new System.EventHandler(this.txtNumeroOP_TextChanged);
            txtNumeroOP.Text = null;
            this.txtNumeroOP.TextChanged += new System.EventHandler(this.txtNumeroOP_TextChanged);
            var vendor = new VendorAccountManager();
            txtSaldoL1.Text = vendor.GetSaldoL1(args.VendorId.Value).ToString("C2");
            txtSaldoL2.Text = vendor.GetSaldoL2(args.VendorId.Value).ToString("C2");
            txtSaldoL1.BackColor = vendor.ColorSaldoL1;
            txtSaldoL2.BackColor = vendor.ColorSaldoL2;
            txtSaldoTotalL1.Text = vendor.GetSaldoL1FromT0203(args.VendorId.Value).ToString("C2");
            txtSaldoTotalL2.Text = vendor.GetSaldoL2FromT0203(args.VendorId.Value).ToString("C2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tsUcVendorSelector1.VendorId == null)
            {
                MessageBox.Show(@"seleccione vendor");
                return;
            }
            var f = new FI31OrdenPagoMainScreen(tsUcVendorSelector1.VendorId.Value);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tsUcVendorSelector1.VendorId == null)
            {
                MessageBox.Show(@"seleccione vendor");
                return;
            }
            
            var f = new FrmFI33DocumentosPendientesPago(tsUcVendorSelector1.VendorId.Value,0);
            f.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var f = new FI31OrdenPagoMainScreen((int) ctlTextBox1.GetValueDecimal, 2);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new RvpOrdenPagoPrint(400001077);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new FrmFI38DetalleImputacionPorDocumento();
            f.Show();
        }
    }
}






