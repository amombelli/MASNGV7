using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.VendorNCD
{
    public partial class FrmFI82SeleccionChequeRechazadoVendor : Form
    {
        public FrmFI82SeleccionChequeRechazadoVendor(int idVendor, string tipoNd)
        {
            _idVendor = idVendor;
            _tipoLx = tipoNd;
            InitializeComponent();
        }

        //---------------------------------------------------------------------
        private readonly int _idVendor;
        private readonly string _tipoLx;
        public int? _idChequeSeleccionado = null;
        public string MotivoChequeRechazado = null;
        public decimal GastosCheque = 0;
        public decimal IVAGastosCheque = 0;
        public DateTime FechaRechazo;
        private List<T0154_CHEQUES> _chList = new List<T0154_CHEQUES>();
        //---------------------------------------------------------------------
        private void FrmSeleccionChequeRechazadoVendor_Load(object sender, EventArgs e)
        {
            CompletaData();
            string tipo = null;
            if (ckSoloTipoSeleccionado.Checked)
                tipo = _tipoLx;
            _chList = new ChequesManager().GetListaChequesEntregadosAProveedor(_idVendor);
            t0154CHEQUESBindingSource.DataSource = _chList.ToList();
            txtNumeroCheque.ReadOnly = false;
            txtGastos.Text = 0.ToString("C2");
            txtMotivoRechazo.Text = null;
            txtIva.Text = 0.ToString("C2");
            txtImporte.Text = 0.ToString("C2");

            if (_tipoLx == "L1")
            {
                ckAplicaIVA.Enabled = true;
                ckAplicaIVA.Checked = false;
            }
            else
            {
                ckAplicaIVA.Enabled = false;
                ckAplicaIVA.Checked = false;
            }


        }

        private void CompletaData()
        {
            var vendorData = new VendorManager().GetSpecificVendor(_idVendor);
            txtRazonSocial.Text = vendorData.prov_rsocial;
            txtFantasia.Text = vendorData.prov_fantasia;
            txtIdVendor.Text = _idVendor.ToString();
        }





        private void dgvListaChequesProveeedor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _idChequeSeleccionado = Convert.ToInt32(dgvListaChequesProveeedor[dgvListaChequesProveeedor.Columns["iDCHEQUEDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            }
            else
            {
                _idChequeSeleccionado = null;
            }

            if (_idChequeSeleccionado != null)
            {
                txtIdCheque.Text = _idChequeSeleccionado.ToString();
                var chdata = new ChequesManager().GetCheque(_idChequeSeleccionado.Value);
                txtImporte.Text = chdata.IMPORTE.Value.ToString("C2");
                txtImporteCh.Text = chdata.IMPORTE.Value.ToString("C2");
                dtpFechaCheque.Value = chdata.CHE_FECHA;
                dtpFechaRecibido.Value = chdata.FECHA_RECIBIDO;

                if (chdata.IdClienteRecibido == null)
                {
                    MessageBox.Show(@"Aplicando el Fix del IdCliente", @"Fix Id Cliente", MessageBoxButtons.OK,
                        MessageBoxIcon.Information); //todo remover este fix algun dia
                    //new FixIdClienteTablaCheque().FixIdCliente(_idChequeSeleccionado.Value);
                    chdata = new ChequesManager().GetCheque(_idChequeSeleccionado.Value);
                }

                txtidCliente.Text = chdata.IdClienteRecibido.ToString();
                txtClienteRazonSocial.Text = chdata.CLIENTE;
                txtBanco.Text = chdata.T0160_BANCOS.BCO_SHORTDESC;
            }



        }

        private void btnSeleccion_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (ValidaData() == false)
                return;

            GastosCheque = FormatAndConversions.CCurrencyADecimal(txtGastos.Text);
            IVAGastosCheque = FormatAndConversions.CCurrencyADecimal(txtIva.Text);
            MotivoChequeRechazado = txtMotivoRechazo.Text;

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private bool ValidaData()
        {
            if (_idChequeSeleccionado == null)
            {
                MessageBox.Show(@"Debe Seleccionar un cheque para Rechazar", @"Rechazo de Cheques", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (FormatAndConversions.CCurrencyADecimal(txtGastos.Text) == 0)
            {
                var preg = MessageBox.Show(@"Confirma el ingreso del cheque rechazado con Gastos $0.00?",
                    @"Rechazo de Cheques", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (preg == DialogResult.No)
                {
                    return false;
                }
            }


            if (string.IsNullOrEmpty(txtMotivoRechazo.Text))
            {
                MessageBox.Show(@"Debe Completar el motivo del Rechazo", @"Rechazo de Cheques", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void txtGastos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);

        }
        private void txtGastos_Leave(object sender, EventArgs e)
        {
            var data = (TextBox)sender;
            if (string.IsNullOrEmpty(data.Text))
            {
                data.Text = 0.ToString("C2");
                return;
            }
            decimal valor = FormatAndConversions.CCurrencyADecimal(data);
            data.Text = valor.ToString("C2");
        }

        private void ckAplicaIVA_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAplicaIVA.Checked)
            {
                txtIva.Text = (FormatAndConversions.CCurrencyADecimal(txtGastos.Text) * (decimal)0.21).ToString("C2");

            }
            else
            {
                txtIva.Text = 0.ToString("C2");
            }
        }

        private void txtNumeroCheque_Leave(object sender, EventArgs e)
        {
            _chList = _chList.Where(c => c.CHE_NUMERO == txtNumeroCheque.Text).ToList();
            t0154CHEQUESBindingSource.DataSource = _chList.ToList();
        }
    }
}
