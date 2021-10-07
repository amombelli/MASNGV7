using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.QM;
using TecserEF.Entity;

namespace MASngFE.Transactional.WM
{
    public enum ModeAjusteEstado
    {
        Free,
        Libera,
        Restringe
    }
    public partial class FrmWM02ModificacionEstadoLote : Form
    {
        public FrmWM02ModificacionEstadoLote(int idstock, string tcode, ModeAjusteEstado modo, string planta = "CERR")
        {
            _idStock = idstock;
            _tcode = tcode;
            _planta = planta;
            _modo = modo;
            InitializeComponent();
        }
        //--------------------------------------------------------------------------------------------------------
        private readonly int _idStock;
        private string _planta;
        private readonly string _tcode;
        private readonly ModeAjusteEstado _modo;
        private string RoleCheck;
        private decimal KgMover;
        //--------------------------------------------------------------------------------------------------------

        private void FrmWM02ModificacionEstadoLote_Load(object sender, EventArgs e)
        {
            MapeaDatosModo1();
            switch (_modo)
            {
                case ModeAjusteEstado.Free:
                    this.Text = @"WM02 - Modificacion de Estado de Lote";
                    RoleCheck = "CQCHANGEESTADO";
                    this.cmbEstadoNuevo.SelectedIndexChanged += new System.EventHandler(this.CmbEstadoNuevo_SelectedIndexChanged);
                    break;
                case ModeAjusteEstado.Libera:
                    this.Text = @"WM02 - Liberacion de Lote";
                    RoleCheck = "CQLIBERA";
                    cmbEstadoNuevo.SelectedItem = "Liberado";
                    cmbEstadoNuevo.Enabled = false;
                    break;
                case ModeAjusteEstado.Restringe:
                    this.Text = @"WM02 - Restriccion de Lote";
                    RoleCheck = "CQRESTRINGE";
                    cmbEstadoNuevo.SelectedItem = "Restringido";
                    cmbEstadoNuevo.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MapeaDatosModo1()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var stockData = db.T0030_STOCK.SingleOrDefault(c => c.IDStock == _idStock);
                if (stockData == null)
                {
                    btnModificarEstado.Enabled = false;
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
                    KgMover = stockData.Stock;
                }
            }
        }
        private void BtnModificarEstado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show(@"Debe seleccionar motivo/justificacion para el cambio de estado", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_modo == ModeAjusteEstado.Restringe)
            {
                //Pasa a Modo Restringido
                //Cambio de Estado de Modo Restringido a FE o Modo Restringido a Liberado solo se puede hacer desde QM
                var idcounternew = new QmRegistroInspeccionH1H2().PasaStockAModoRestringido(
                    Convert.ToInt32(txtIdStock.Text), txtMaterial.Text, txtNumeroLoteOriginal.Text, KgMover,
                    txtObservacion.Text);
                return;
            }

            var respuesta = MessageBox.Show(@"Confirma la modificacion del Estado del Lote?",
                @"Movimiento/Cambio de Stock",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;





            var x = new StockMovements();
            var log40 = x.MoveEstado(_idStock, KgMover, StockStatusManager.MapStatusFromText(cmbEstadoNuevo.Text),
                "MM0", comentario: txtObservacion.Text);
            if (log40 > 0)
                MessageBox.Show(@"Se ha realizado correctamente el Cambio de Estado del Material", @"Cambio de Estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TxtKgAMover_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void CmbEstadoNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StockStatusManager.MapStatusFromText(txtEstadoOriginal.Text) ==
                StockStatusManager.MapStatusFromText(cmbEstadoNuevo.SelectedItem.ToString()))
            {
                MessageBox.Show(@"El Nuevo Estado es igual al Estado Anterior", @"Error en Seleccion de Estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnModificarEstado.Enabled = false;
            }
            else
            {
                btnModificarEstado.Enabled = true;
            }

        }

        private void TxtKgAMover_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgAMover.Text))
            {
                txtKgAMover.Text = @"0";
            }
            KgMover = Convert.ToDecimal(txtKgAMover.Text);

            if (KgMover > Convert.ToDecimal(txtSeleccionKg.Text))
            {
                MessageBox.Show(@"Los KG a modificar el estado supera la seleccion maxima de KG", @"Error en Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

            if (KgMover <= 0)
            {
                MessageBox.Show(@"Debe seleccionar KG Validos", @"Error en Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }


        }
    }
}
