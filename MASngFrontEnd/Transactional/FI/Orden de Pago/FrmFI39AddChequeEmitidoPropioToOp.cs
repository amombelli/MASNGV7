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
        public FrmFI39AddChequeEmitidoPropioToOp(string razonSocial, string monedaOP)
        {
            txtProveedor.Text = razonSocial;
            txtMoneda.Text = monedaOP;
            InitializeComponent();
        }

        public decimal Importe { get; private set; }

        private void btnAddItemPago_Click(object sender, EventArgs e)
        {


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
            this.cmbBancoEmisor.SelectedIndexChanged -= new System.EventHandler(this.cmbBancoEmisor_SelectedIndexChanged);
            cmbBancoEmisor.DataSource = new CuentasManager().GetListaCuentaAvailableEmiteCheque();
            cmbBancoEmisor.SelectedIndex = -1;
            this.cmbBancoEmisor.SelectedIndexChanged += new System.EventHandler(this.cmbBancoEmisor_SelectedIndexChanged);


        }

        private void cmbBancoEmisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = (T0150_CUENTAS) cmbBancoEmisor.SelectedValue;
            txtGl.Text = data.GLMAP;
        }
    }
}
