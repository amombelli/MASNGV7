using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQM40RestringeLote : Form
    {


        public FrmQM40RestringeLote(int idStock)
        {
            _idStock = idStock;
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------
        private readonly int _idStock;
        private decimal _kgMover;
        //------------------------------------------------------------------------------------

        private void FrmQM40RestringeLote_Load(object sender, EventArgs e)
        {
            MapeaDatosInicio();
        }

        private bool CheckSiPuedeRestringir()
        {
            //Solo se puede restringir desde estado Liberado o FE
            var matStatus = new StockStatusManager().MapeaStringToType(txtEstadoOriginal.Text);
            switch (matStatus)
            {
                case StockStatusManager.EstadoLote.Liberado:
                    return true;
                case StockStatusManager.EstadoLote.Restringido:
                    return false;
                case StockStatusManager.EstadoLote.FE:
                    return true;
                case StockStatusManager.EstadoLote.Comprometido:
                    return false;
                case StockStatusManager.EstadoLote.Reservado:
                    return false;
                case StockStatusManager.EstadoLote.ReservaPF:
                    return false;
                case StockStatusManager.EstadoLote.ReservaRE:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MapeaDatosInicio()
        {
            var stockData = StockManager.GetStockLine(_idStock);
            txtMaterial.Text = stockData.Material;
            txtEstadoOriginal.Text = stockData.Estado;
            txtSlocOriginal.Text = stockData.SLOC;
            txtNumeroLoteOriginal.Text = stockData.Batch;
            txtSeleccionKg.Text = stockData.Stock.ToString("N2");
            //_planta = stockData.T0028_SLOC.PLTN;
            txtDescripcionSlocOriginal.Text = stockData.T0028_SLOC.SLOC_DESC;
            txtKgAMover.Text = txtSeleccionKg.Text;
            txtIdStock.Text = _idStock.ToString();
            _kgMover = stockData.Stock;
            if (CheckSiPuedeRestringir() == false)
            {
                MessageBox.Show(@"El Estado del Lote no permite 'Restriccion' desde esta función",
                    @"Funcionalidad Invalida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnModificarEstado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show(@"Debe seleccionar motivo/justificacion para el cambio de estado", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var respuesta = MessageBox.Show(@"Confirma la modificacion del Estado del Lote?",
                @"Restricción de Lote para Evaluacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            //Cambio de Estado de Modo Restringido a FE o Modo Restringido a Liberado solo se puede hacer desde QM
            var idcounternew = new QmRegistroInspeccionH1H2().PasaStockAModoRestringido(
                Convert.ToInt32(txtIdStock.Text), txtMaterial.Text, txtNumeroLoteOriginal.Text, _kgMover,
                txtObservacion.Text);

            this.DialogResult = DialogResult.OK;
            return;
        }
        private void TxtKgAMover_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgAMover.Text))
            {
                txtKgAMover.Text = @"0";
            }
            _kgMover = Convert.ToDecimal(txtKgAMover.Text);

            if (_kgMover > Convert.ToDecimal(txtSeleccionKg.Text))
            {
                MessageBox.Show(@"Los KG a modificar el estado supera la seleccion maxima de KG", @"Error en Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }

            if (_kgMover <= 0)
            {
                MessageBox.Show(@"Debe seleccionar KG Validos", @"Error en Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        private void TxtKgAMover_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
    }
}
