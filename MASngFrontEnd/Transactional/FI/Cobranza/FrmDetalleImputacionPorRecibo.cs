using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.Cobranza;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmFi103DetalleImpuXRecibo : Form
    {
        public FrmFi103DetalleImpuXRecibo(int idCobranza)
        {
            _idCob = idCobranza;
            InitializeComponent();
        }
        //--------------------------------------------------------------
        private readonly int _idCob;

        //--------------------------------------------------------------

        private void FrmDetalleImputacionPagoFactura_Load(object sender, EventArgs e)
        {
            t0207SPLITFACTURASBindingSource.DataSource = new CobranzaUtils().GetListaImputacionPorRecibo(_idCob);
            LoadHeaderData();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadHeaderData()
        {
            var cobH = new CobranzaSearch().GetCobranzaHeader(_idCob);
            var cli = new CustomerManager().GetCustomerBillToData(cobH.IdCliente.Value);
            var ctacte = new CobranzaUtils().GetT0201FromCobranza(_idCob);
            if (ctacte != null)
            {
                txtMontoPendienteImputacion.Text = Math.Abs(ctacte.SALDOFACTURA).ToString("C2");
                if (ctacte.SALDOFACTURA == 0)
                {
                    //ckCobranzaImputada.Checked = true;
                    //ckCobranzaImputada.BackColor = Color.GreenYellow;
                    //btnImputarCobranza.Enabled = false;
                    txtMontoPendienteImputacion.BackColor = Color.GreenYellow;
                }
                else
                {
                    //ckCobranzaImputada.Checked = false;
                    //ckCobranzaImputada.BackColor = Color.Orange;
                    //btnImputarCobranza.Enabled = true;
                    txtMontoPendienteImputacion.BackColor = Color.OrangeRed;
                }
            }
            else
            {
                //ckCobranzaImputada.BackColor = Color.Pink;
                //txtMontoPendienteImputacion.Text = @"Error!";
            }
            txtRazonSocial.Text = cli.cli_rsocial;
            txtFantasia.Text = cli.cli_fantasia;
            txtId6.Text = cli.IDCLIENTE.ToString();
            txtIdCob.Text = _idCob.ToString();
            txtFecha.Text = cobH.FECHA.ToString("d");
            txtImporte.Text = cobH.Monto.ToString("C2");
            txtMoneda.Text = cobH.MON;
            txtMoneda1.Text = txtMoneda2.Text = txtMoneda.Text;
            txtReciboInterno.Text = cobH.NRECIBO;
            txtReciboOficial.Text = cobH.NRECIBOOFI;
            txtTotalImputado.Text = (cobH.Monto + ctacte.SALDOFACTURA).ToString("C2");
            txtLx.Text = cobH.CUENTA;
            txtDiasPP.Text = cobH.DIAS_PP.ToString();
            txtTCRecibo.Text = cobH.TC.ToString("N2");
            if (cobH.MON == "USD")
            {
                txtUSDRecibo.Text = cobH.Monto.ToString("c2");
            }
            else
            {
                if (cobH.TC != 0)
                {
                    txtUSDRecibo.Text = Math.Round(cobH.Monto / cobH.TC, 2).ToString("c2");
                }
            }
            CalculaPorcentajeApplicacion();
        }

        private void CalculaPorcentajeApplicacion()
        {
            //Define formato para resaltar
            //DataGridViewCellStyle highlightStyle = new DataGridViewCellStyle
            //{
            //    //ForeColor = Color.Red,
            //    BackColor = Color.DarkKhaki,
            //    //Font = new Font(dgvLista.Font, FontStyle.Bold)
            //    Format = "P2",
            //    NullValue = 0,
            //};

            foreach (DataGridViewRow row in dgvLista.Rows)
            {
                // Calculate total cost.
                decimal porcentajeAppl =
                    Math.Round(((decimal)row.Cells[__MontoImputado.Name].Value /
                    (decimal)row.Cells[__ImporteDocumento.Name].Value), 4);

                // Display the value.
                row.Cells[__aplicadoPorcentaje.Name].Value = porcentajeAppl;

                // Highlight the cell if the vcalue is big.
                if (porcentajeAppl == 1)
                {
                    row.Cells[__aplicadoPorcentaje.Name].Style.BackColor = Color.LightBlue;
                }
            }
        }

        private void btnDesimputar_Click(object sender, EventArgs e)
        {
            var p = MessageBox.Show(
                @"Confirma la Desimputacion completa de este recibo a los documentos que se muestran abajo?",
                @"Consulta de Desimputacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (p == DialogResult.No)
                return;

            var x = new CobranzaDesimputa();
            x.DesimputarCobranzaCompleta(_idCob);

        }
    }
}
