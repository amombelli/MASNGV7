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
using Tecser.Business.SuperMD;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI40AddTransferToOp : Form
    {
        private readonly FI31OrdenPagoMainScreen _frm;
        private readonly string _cuenta;

        public FrmFI40AddTransferToOp(FI31OrdenPagoMainScreen frm, string cuenta)
        {
            _frm = frm;
            _cuenta = cuenta;
            InitializeComponent();
        }
        
        private void FrmFI40AddTransferToOp_Load(object sender, EventArgs e)
        {
            txtProveedor.Text = _frm.txtRazonSocial.Text;
            txtMoneda.Text = _frm.cmbMoneda.SelectedItem.ToString();
            this.cmbBancoEmisor.SelectedIndexChanged -= new System.EventHandler(this.cmbBancoEmisor_SelectedIndexChanged);
            cmbBancoEmisor.DataSource = new CuentasManager().GetListaCuentaAvailableEmiteCheque();
            if (string.IsNullOrEmpty(_cuenta))
            {
                cmbBancoEmisor.Enabled = true;
                cmbBancoEmisor.SelectedIndex = -1;
                this.cmbBancoEmisor.SelectedIndexChanged += new System.EventHandler(this.cmbBancoEmisor_SelectedIndexChanged);
            }
            else
            {
                this.cmbBancoEmisor.SelectedIndexChanged += new System.EventHandler(this.cmbBancoEmisor_SelectedIndexChanged);
                cmbBancoEmisor.SelectedValue = _cuenta;
                var data = (T0150_CUENTAS)cmbBancoEmisor.SelectedItem;
                txtGl.Text = data.GLMAP;
                txtIdBanco.Text = data.ID_CUENTA;
                cmbBancoEmisor.Enabled = false;
            }
            cmbBancoDestino.DataSource = new BankManager().GetBankList(true).OrderBy(c => c.BCO_SHORTDESC).ToList();
            cmbBancoDestino.SelectedIndex = -1;
          }

        private bool ValidaOk()
        {
            if (cmbBancoEmisor.SelectedValue == null)
            {
                MessageBox.Show(@"Complete el banco emisor", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbBancoDestino.SelectedValue == null)
            {
                MessageBox.Show(@"Complete el banco destino de la transferencia (Banco Proveedor)", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (ctlImporte.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Error en Importe a Transferir", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }


        private void btnAddItemPago_Click(object sender, EventArgs e)
        {
            if (ValidaOk() == false) return;
            string cuenta = ((T0150_CUENTAS)cmbBancoEmisor.SelectedItem).ID_CUENTA;
            _frm.AddTransferencia(cuenta, dtpFechaTransf.Value, txtNumeroOperacion.Text,ctlImporte.GetValueDecimal,cmbBancoDestino.SelectedValue.ToString());
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

        private void cmbBancoEmisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = (T0150_CUENTAS)cmbBancoEmisor.SelectedItem;
            txtGl.Text = data.GLMAP;
            txtIdBanco.Text = data.ID_CUENTA;
        }

    }
}
