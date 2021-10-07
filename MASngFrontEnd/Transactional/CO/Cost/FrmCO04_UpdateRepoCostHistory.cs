using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO.Costos;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO04_UpdateRepoCostHistory : Form
    {
        private readonly int _idF;
        private readonly int _idI;

        public FrmCO04_UpdateRepoCostHistory(int idF, int idI)
        {
            _idF = idF;
            _idI = idI;
            InitializeComponent();
        }

        private void FrmCO04_UpdateRepoCostHistory_Load(object sender, EventArgs e)
        {
            CargaData();
        }

        private void CargaData()
        {
            var obj = new RepoHistoryManager();
            var c = obj.GetRecordConta(_idF, _idI);
            var cH = obj.GetRecordContaH(_idF);
            var h = obj.GetRecordHistoria(_idF, _idI);
            txtMaterial.Text = h.Material;
            txtProveedorRs.Text = h.VendorRS;
            txtFechaCompra.Text = cH.FECHA.ToString("d");
            txtTc.Text = cH.TC.ToString("n2");
            txtKgCompra.Text = c.CANT == null ? "0.00" : c.CANT.Value.ToString("N2");
            txtMoneda.Text = c.MonedaItemProveedor;
            txtPrecioU.Text = c.PUNIT_USD == null ? 0.ToString("C3") : c.PUNIT_USD.Value.ToString("C3");
            txtPrecioA.Text = c.PUNIT_ARS == null ? 0.ToString("C3") : c.PUNIT_ARS.Value.ToString("C3");

            ckManualUpdate.Checked = h.UpdateManual;
            xKgCompra.SetValue = h.KG;
            xMoneda.Text = h.Moneda;
            xPrecioU.SetValue = h.PrecioUsd;
            xPrecioA.SetValue = h.PrecioArs;
            txtFechaUpdate.Text = h.UpdateFecha?.ToString("g");
            txtUserUpdate.Text = h.UpdateUser;
        }

        private void btnRegenerar_Click(object sender, EventArgs e)
        {
            new RepoHistoryManager().RegeneraRecordManual(_idF, _idI);
            CargaData();
        }

        private void btnUpdateUC_Click(object sender, EventArgs e)
        {
            new RepoHistoryManager().UpdateManualData(_idF, _idI, xKgCompra.GetValueDecimal, xPrecioU.GetValueDecimal, xPrecioA.GetValueDecimal);
            CargaData();
        }

        private void xPrecioU_Validated(object sender, EventArgs e)
        {
            xPrecioA.SetValue = xPrecioU.GetValueDecimal * Convert.ToDecimal(txtTc.Text);
        }

        private void xPrecioA_Validated(object sender, EventArgs e)
        {
            xPrecioU.SetValue = xPrecioA.GetValueDecimal / Convert.ToDecimal(txtTc.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
    }
}
