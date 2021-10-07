using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.MM.Ingreso_de_Stock
{
    public partial class FrmMM31DetalleIngresoStock : Form
    {
        public FrmMM31DetalleIngresoStock(int numeroOC, int idItem)
        {
            _numeroOC = numeroOC;
            _numeroItem = idItem;

            InitializeComponent();
            rbOc.Checked = true;

        }

        //------------------------------------------------------------------------------------
        private readonly int _numeroOC;
        private readonly int _numeroItem;
        //------------------------------------------------------------------------------------
        private void FrmMM31DetalleIngresoStock_Load(object sender, EventArgs e)
        {
            bMaterial.DataSource = new MaterialTypeManager().GetListMaterialAvailableToBuy();
            bProveedor.DataSource = new VendorManager().GetCompleteListVendors();
            bMaterial.SelectedIndex = -1;
            bProveedor.SelectedIndex = -1;
        }

        private void rbOc_CheckedChanged(object sender, EventArgs e)
        {
            bNumeroOC.Visible = false;
            bProveedor.Visible = false;
            bMaterial.Visible = false;
            var rb = (RadioButton)sender;
            var nombre = rb.Name;
            switch (nombre)
            {
                case "rbOc":
                    lbusqueda.Visible = true;
                    lbusqueda.Text = @"Numero OC";
                    bNumeroOC.Visible = true;
                    break;

                case "rbMaterial":
                    lbusqueda.Visible = true;
                    lbusqueda.Text = @"Material";
                    bMaterial.Visible = true;
                    break;
                case "rbSecuencia":
                    lbusqueda.Visible = false;
                    t0063ITEMSOCINGRESADOSBindingSource.DataSource = new IngresoStockManager().GetListIngresosSecuencia();
                    break;
                case "rbProveedor":
                    lbusqueda.Visible = true;
                    lbusqueda.Text = @"Proveedor";
                    bProveedor.Visible = true;
                    break;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bProveedor.SelectedIndex == -1)
            {

                return;
            }
            t0063ITEMSOCINGRESADOSBindingSource.DataSource =
                new IngresoStockManager().GetListIngresosProveedor(Convert.ToInt32(bProveedor.SelectedValue));

        }
        private void bMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bMaterial.SelectedIndex == -1)
            {

                return;
            }
            t0063ITEMSOCINGRESADOSBindingSource.DataSource =
              new IngresoStockManager().GetListIngresosMaterial(bMaterial.SelectedValue.ToString());

        }

        private void bNumeroOC_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void bNumeroOC_KeyUp(object sender, KeyEventArgs e)
        {
            t0063ITEMSOCINGRESADOSBindingSource.DataSource =
                new IngresoStockManager().GetListIngresosOCItem(Convert.ToInt32(bNumeroOC.Text), null).ToList();
        }
    }
}
