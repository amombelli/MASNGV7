using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Security;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.WM
{
    //revision 2019.04.16
    public partial class FrmWm01MoveStock : Form
    {
        public FrmWm01MoveStock(int idstock, string tcode, string planta = "CERR")
        {
            _idStock = idstock;
            _tcode = tcode;
            _planta = planta;
            InitializeComponent();
        }

        //--------------------------------------------------------------------------------------------------------
        private readonly int _idStock;
        private string _planta;
        private readonly string _tcode;
        //--------------------------------------------------------------------------------------------------------

        private void FrmChangeSloc_Load(object sender, EventArgs e)
        {
            ChequeaSecurity();
            ConfiguraInicial();
            MapeaDatosModo1();
        }
        private void ChequeaSecurity()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQSLOC", true, true))
            {
                this.Close();
            }
        }
        private void ConfiguraInicial()
        {
            t0028SLOCBindingSource.DataSource = new Ubicaciones().GetCompleteListSloCbyPlant(_planta);
            cmbNewSloc.SelectedIndex = -1;
        }
        private void MapeaDatosModo1()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stockData = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == _idStock);
                if (stockData == null)
                {
                    btnMoveStockSLOC.Enabled = false;
                }
                else
                {
                    txtMaterial.Text = stockData.Material;
                    txtEstadoOriginal.Text = stockData.Estado;
                    txtSlocOriginal.Text = stockData.SLOC;
                    txtNumeroLoteOriginal.Text = stockData.Batch;
                    txtSeleccionKg.Text = stockData.Stock.ToString("N4");
                    _planta = stockData.T0028_SLOC.PLTN;
                    txtDescripcionSlocOriginal.Text = stockData.T0028_SLOC.SLOC_DESC;
                    txtKgAMover.Text = txtSeleccionKg.Text;
                    ConfiguraInicial();
                }
            }
        }
        private void cmbNewSloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNewSloc.SelectedIndex == -1)
            {
                txtDescripcionNewSloc.Text = null;
                return;
            }
            var data = cmbNewSloc.SelectedItem;
            var x = (T0028_SLOC)data;
            txtDescripcionNewSloc.Text = x.SLOC_DESC;
        }

        #region Botones
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMoveStockSLOC_Click(object sender, EventArgs e)
        {
            if (cmbNewSloc.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar una Ubicacion Valida", @"Datos Incorrectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtKgAMover.Text))
            {
                MessageBox.Show(@"Debe Seleccionar los KG a Mover de Ubicacion", @"Datos Incorrectos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            if (Convert.ToDecimal(txtKgAMover.Text) == 0)
            {
                MessageBox.Show(@"Los KG a Mover no pueden ser 0 (CERO)", @"Datos Incorrectos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var x = new StockMovements();
            var log40 = x.MoveSloc(_idStock, Convert.ToDecimal(txtKgAMover.Text), cmbNewSloc.SelectedValue.ToString(),
                _tcode, true);

            if (log40 > 0)
            {
                MessageBox.Show(@"Se ha realizado correctamente el movimiento de materiales", @"Cambio de Ubicaciones",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtLogMovimiento.Text = log40.ToString();
                txtLogMovimiento.BackColor = Color.Yellow;

                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                MessageBox.Show(@"Ha ocurrido un error en el movimiento de materiales. Revise el resultado final!",
                    @"Cambio de Ubicaciones",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                this.DialogResult = DialogResult.Abort;
                return;
            }
        }

        #endregion

        private void txtKgAMover_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtKgAMover_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgAMover.Text))
                txtKgAMover.Text = 0.ToString("N4");

            decimal kgOriginal = Convert.ToDecimal(txtSeleccionKg.Text);
            decimal kgAMover = decimal.Round(Convert.ToDecimal(txtKgAMover.Text), 4);


            if (kgAMover > kgOriginal)
            {
                toolTip1.ToolTipTitle = "Error en la Seleccion de Kg";
                toolTip1.Show("El Maximo valor de Kg a Mover no puede superar la seleccion Original de Kg", txtKgAMover, txtKgAMover.Location, 3000);
                e.Cancel = true;
                return;
            }

            if (kgAMover == 0)
            {
                toolTip1.ToolTipTitle = "Error en la Seleccion de Kg";
                toolTip1.Show("El valor de Kg a Mover no puede ser CERO", txtKgAMover, txtKgAMover.Location, 3000);
                e.Cancel = false;
                return;
            }

            if (kgAMover < 0)
            {
                toolTip1.ToolTipTitle = "Error en la Seleccion de Kg";
                toolTip1.Show("El valor de Kg a Mover no puede ser inferior a CERO", txtKgAMover, txtKgAMover.Location, 3000);
                e.Cancel = true;
                return;
            }
        }
    }
}