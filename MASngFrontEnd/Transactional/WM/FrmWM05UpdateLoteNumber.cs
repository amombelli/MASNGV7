using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.WM
{
    public partial class FrmWm05UpdateLoteNumber : Form
    {
        public FrmWm05UpdateLoteNumber(int idstock, string tcode, string planta = "CERR")
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

        const string RoleCheck = "CQLOTEUPD";
        //--------------------------------------------------------------------------------------------------------

        private void FrmWm05UpdateLoteNumber_Load(object sender, EventArgs e)
        {
            ChequeaSecurity();
            ConfiguraInicial();
            MapeaDatosModo1();
        }

        private void ChequeaSecurity()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", RoleCheck, true, true))
            {
                this.Close();
            }
        }
        private void MapeaDatosModo1()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stockData = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == _idStock);
                if (stockData == null)
                {
                    btnUpdateLote.Enabled = false;
                }
                else
                {
                    txtMaterial.Text = stockData.Material;
                    txtEstadoOriginal.Text = stockData.Estado;
                    txtSlocOriginal.Text = stockData.SLOC;
                    txtNumeroLoteOriginal.Text = stockData.Batch;
                    txtSeleccionKg.Text = stockData.Stock.ToString("N2");
                    _planta = stockData.T0028_SLOC.PLTN;
                    txtDescripcionSlocOriginal.Text = stockData.T0028_SLOC.SLOC_DESC;
                    txtKgAMover.Text = txtSeleccionKg.Text;
                    txtIdStock.Text = _idStock.ToString();
                    ConfiguraInicial();
                }
            }
        }
        private void ConfiguraInicial()
        {
            //No hay nada para configurar
        }

        private void TxtKgAMover_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgAMover.Text))
            {
                txtKgAMover.Text = @"0";
            }

            decimal valor = Convert.ToDecimal(txtKgAMover.Text);
            decimal valorOri = Convert.ToDecimal(txtSeleccionKg.Text);
            if (valor > valorOri)
            {
                MessageBox.Show(@"El Valor a modificar no puede superar la seleccion de KG", @"Error en Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

            if (valor == 0)
            {
                MessageBox.Show(@"El Valor a modificar no puede ser CERO", @"Error en Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

        }
        private void TxtKgAMover_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdateLote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoteNuevo.Text))
            {
                MessageBox.Show(@"El numero de lote no puede estar vacio", @"Datos Incorrectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show(
                    @"Debe colocar un motivo por el cual es necesario modificar un numero de lote ya existente",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var respuesta = MessageBox.Show(@"Confirma La MODIFICACION LOTE#?",
                @"Movimiento/Cambio de Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            var x = new StockMovements();
            var log40 = x.ChangeLote(_idStock, Convert.ToDecimal(txtKgAMover.Text),
                txtLoteNuevo.Text, "MM0");
            if (log40 > 0)
                MessageBox.Show(@"Se ha realizado correctamente el Cambio de LOTE del MATERIAL", @"Cambio de LOTE",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void TxtLoteNuevo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoteNuevo.Text))
            {
                MessageBox.Show(@"El Lote no puede estar vacio", @"Datos Incorrectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Cancel = true;
            }

            if (txtLoteNuevo.Text == txtNumeroLoteOriginal.Text)
            {
                MessageBox.Show(@"El Lote Nuevo no puede ser igual al lote existente", @"Datos Incorrectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Cancel = true;
            }

            if (txtLoteNuevo.TextLength > 15)
            {
                MessageBox.Show(@"El Lote no puede superar los 15 caracteres", @"Datos Incorrectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
