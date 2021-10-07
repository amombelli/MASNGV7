using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Security;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.WM
{
    public partial class FrmWM03ModificarKG : Form
    {
        public FrmWM03ModificarKG(int idstock, string tcode, string planta = "CERR")
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
        private decimal _kgOri;

        const string RoleCheck = "CQADDKG";
        //--------------------------------------------------------------------------------------------------------

        private void FrmWM03ModificarKG_Load(object sender, EventArgs e)
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

        private void ConfiguraInicial()
        {
            //No hay nada para configurar
        }

        private void MapeaDatosModo1()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stockData = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == _idStock);
                if (stockData == null)
                {
                    btnAjusteStock.Enabled = false;
                }
                else
                {
                    txtMaterial.Text = stockData.Material;
                    txtEstadoOriginal.Text = stockData.Estado;
                    txtSlocOriginal.Text = stockData.SLOC;
                    txtNumeroLoteOriginal.Text = stockData.Batch;
                    txtSeleccionKg.Text = stockData.Stock.ToString("N2");
                    _kgOri = stockData.Stock;
                    _planta = stockData.T0028_SLOC.PLTN;
                    txtDescripcionSlocOriginal.Text = stockData.T0028_SLOC.SLOC_DESC;
                    txtKgFinales.Text = txtSeleccionKg.Text;
                    txtIdStock.Text = _idStock.ToString();
                    ConfiguraInicial();
                }
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

        private void BtnAjusteStock_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtKgAjuste.Text) == 0)
            {
                MessageBox.Show(@"Debe completar los KG Finales/KgAjuste",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show(@"Debe completar un comentario/observacion para el LOG del movimiento",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal KgAjuste = Convert.ToDecimal(txtKgAjuste.Text);

            DialogResult respuesta;
            if (KgAjuste > 0)
            {
                respuesta =
                    MessageBox.Show(
                        @"Confirma el AJUSTE de los KG Seleccionados?" + Environment.NewLine + Environment.NewLine +
                        @"Este movimiento generara un asiento de ajuste contable de $ imputado a la diferencia positiva de stock",
                        @"Ajuste Positivo de Stock",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                respuesta =
                    MessageBox.Show(
                        @"Confirma el AJUSTE de los KG Seleccionados?" + Environment.NewLine + Environment.NewLine +
                        @"Este movimiento generara un asiento de ajuste contable de $ imputado a la perdida de diferencia de stock",
                        @"Ajuste Negativo de Stock",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (respuesta == DialogResult.No)
                return;

            var asiento = new AsientoAjusteStock("MM0").Ajuste(txtMaterial.Text, KgAjuste, txtObservacion.Text);

            if (asiento.IdDocu > 0)
            {
                txtNumeroAsiento.Text = asiento.IdDocu.ToString();

                var x = new StockMovements();
                var log40 = x.AjusteKgStock(_idStock, Convert.ToDecimal(txtKgFinales.Text), "MM0", true,
                    txtObservacion.Text);
                if (log40 > 0)
                    MessageBox.Show(
                        @"Se ha realizado correctamente el AJUSTE DE STOCK. Tome nota del asiento generado y reportelo.",
                        @"AJUSTE DE STOCK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    @"Ha ocurrido un error al generar el asiento contable de Ajuste de Stock y no se ha realizado el ajuste de stock",
                    @"Error en Ajuste de Stock", MessageBoxButtons.OK);
            }

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void TxtKgAMover_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgFinales.Text))
                txtKgFinales.Text = "0";

            decimal kgFinales = Convert.ToDecimal(txtKgFinales.Text);
            decimal kgAjuste = kgFinales - _kgOri;
            txtKgAjuste.Text = kgAjuste.ToString("N2");

            if (kgAjuste > 0)
            {
                if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQADDKG", true, true))
                {
                    MessageBox.Show(@"El Usuario no tiene permisos para realizar ajustes de stock positivos",
                        @"Security Check Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
            else if (kgAjuste < 0)
            {
                if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQDELKG", true, true))
                {
                    MessageBox.Show(@"El Usuario no tiene permisos para realizar ajustes de stock NEGATIVOS",
                        @"Security Check Failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show(@"No se puede realizar un Ajuste de CERO Kg", @"Error en Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
    }
}
