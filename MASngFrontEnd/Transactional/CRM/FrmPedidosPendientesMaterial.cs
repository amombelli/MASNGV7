using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.SD;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmPedidosPendientesMaterial : Form
    {


        public FrmPedidosPendientesMaterial()
        {
            InitializeComponent();
        }

        private void FrmPedidosPendientesMaterial_Load(object sender, EventArgs e)
        {
            cmbCodigoVenta.DataSource = new MaterialTypeManager().GetMtypeForAkaProducts();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCodigoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCodigoVenta.SelectedValue?.ToString()))
                return;

            dgvListMaterial.DataSource = new SalesOrderDataList().GetData(cmbCodigoVenta.SelectedValue.ToString()).ToList();
        }
    }
}
