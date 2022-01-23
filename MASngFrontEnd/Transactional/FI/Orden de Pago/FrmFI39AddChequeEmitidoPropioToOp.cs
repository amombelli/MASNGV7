using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI39AddChequeEmitidoPropioToOp : Form
    {
        private readonly FI31OrdenPagoMainScreen _frm;
        private readonly int _tipoCheque;
        public decimal Importe { get; private set; }

        public FrmFI39AddChequeEmitidoPropioToOp(FI31OrdenPagoMainScreen frm, int tipoCheque)
        {
            _frm = frm;
            _tipoCheque = tipoCheque;
            InitializeComponent();
        }
     
        private bool ValidaOk()
        {
            if (cmbBancoEmisor.SelectedValue == null)
            {
                MessageBox.Show(@"Complete el banco emisor", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (dtpFechaAcreditacion.Value < DateTime.Today)
            {
                var x = MessageBox.Show(@"Confirma que la fecha de Acreditacion es anterior a la fecha de hoy?",
                    @"Confirmacion fecha de Acreditacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return false;
            }

            if (dtpFechaAcreditacion.Value > DateTime.Today.AddDays(300))
            {
                var x = MessageBox.Show(@"Confirma que la fecha de Acreditacion es mayor a 300 dias?",
                    @"Confirmacion fecha de Acreditacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return false;
            }

            if (cNumeroCheque.GetValueDecimal == 0)
            {
                MessageBox.Show(@"Complete el Numero de Cheque", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (ctlImporteCheque.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Error en Importe del Cheque", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (rbChequeFisico.Checked == false && rbEcheque.Checked == false)
            {
                MessageBox.Show(@"Seleccione Cheque Fisico o E-Cheque", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void btnAddItemPago_Click(object sender, EventArgs e)
        {
            if (ValidaOk() == false) return;
            bool esEcheque = false;
            if (rbEcheque.Checked)
                esEcheque = true;

            string cuenta = ((T0150_CUENTAS) cmbBancoEmisor.SelectedItem).ID_CUENTA;
            _frm.AddChequeEmitido(cuenta,dtpFechaAcreditacion.Value,cNumeroCheque.GetValueDecimal.ToString(),esEcheque,ctlImporteCheque.GetValueDecimal);
            Importe = ctlImporteCheque.GetValueDecimal;
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void FrmFI39AddChequeEmitidoPropioToOp_Load(object sender, EventArgs e)
        {
            txtProveedor.Text = _frm.txtRazonSocial.Text;
            txtMoneda.Text = _frm.cmbMoneda.SelectedItem.ToString();

            if (_tipoCheque == 1)
            {
                rbChequeFisico.Checked = true;
                grbTipoCheque.Enabled = false;
            }
            else
            {
                if (_tipoCheque == 2)
                {
                    rbEcheque.Checked = true;
                    grbTipoCheque.Enabled = false;
                }
                else
                {
                    grbTipoCheque.Enabled = true;
                }
            }
            this.cmbBancoEmisor.SelectedIndexChanged -= new System.EventHandler(this.cmbBancoEmisor_SelectedIndexChanged);
            cmbBancoEmisor.DataSource = new CuentasManager().GetListaCuentaAvailableEmiteCheque();
            cmbBancoEmisor.SelectedIndex = -1;
            this.cmbBancoEmisor.SelectedIndexChanged += new System.EventHandler(this.cmbBancoEmisor_SelectedIndexChanged);
        }

        private void cmbBancoEmisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = (T0150_CUENTAS) cmbBancoEmisor.SelectedItem;
            txtGl.Text = data.GLMAP;
        }
    }
}
