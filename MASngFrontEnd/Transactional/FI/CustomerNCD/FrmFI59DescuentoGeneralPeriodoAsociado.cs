using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI59DescuentoGeneralPeriodoAsociado : Form
    {
        public FrmFI59DescuentoGeneralPeriodoAsociado(CustomerNc znc, CustomerNc.MotivoNotaCredito motivo)
        {
            var h = znc.GetHeader();
            _nc = znc;
            _tc = h.TC;
            _motivo = motivo;
            _idCliente = h.Cliente;
            _tipoLx = h.TIPOFACT;
            fechaDoc = h.FECHA;
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------
        private CustomerNc _nc;
        private readonly int _idCliente;
        private readonly string _tipoLx;
        private readonly CustomerNc.MotivoNotaCredito _motivo;
        private readonly decimal _tc;
        private readonly DateTime fechaDoc;
        public DateTime? FechaAplicaDesde { get; private set; }
        public DateTime? FechaAplicaHasta { get; private set; }


        //----------------------------------------------------------------------------------------
        private void FrmSeleccionMaterialNcd_Load(object sender, EventArgs e)
        {
            cTc.SetValue = _tc;
            txtMonedaDocumento.Text = @"ARS";
            txtId6.Text = _idCliente.ToString();
            txtLx.Text = _tipoLx;
            var cli = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtRazonSocial.Text = cli.cli_rsocial;
            txtMotivo.Text = _motivo.ToString();
            cFechaDocumento.Value = fechaDoc;
        }

        //Botones
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
        private void tdAddButton_BotonClick(object sender, EventArgs e)
        {
            if (c1DescuentoPeso.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"No se genera diferencia para generar una NC", @"Sin Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcionItemNC.Text))
            {
                MessageBox.Show(@"Debe completar un texto", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (cTc.GetValueDecimal == 0)
            {
                MessageBox.Show(@"Error en Tipo de Cambio", @"Sin Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (cFechaDesde.Value == null)
            {
                MessageBox.Show(@"Debe completar la fecha desde donde aplica el descuento",
                    @"Error en Fecha Comprobante Asociado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cFechaHasta.Value == null)
            {
                MessageBox.Show(@"Debe completar la fecha hasta donde aplica el descuento",
                    @"Error en Fecha Comprobante Asociado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Alta del Item
            //Opcion1 - Cantidad Positiva - Importe U negativo
            var xiva = Math.Abs(cIva.GetValueDecimal) > 0;
            _nc.AddItems("DESCGRAL", txtDescripcionItemNC.Text, Math.Abs(c1DescuentoPeso.GetValueDecimal) * -1, "4.1.3", xiva, 1, "ARS");
            _nc.SetTotalesInHeaderFromItems();
            _nc.SetPeriodoAsociado(cFechaDesde.Value.Value, cFechaHasta.Value.Value);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }


        private void cFechaDesde_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cFechaHasta.Value != null)
            {
                if (cFechaDesde.Value > cFechaHasta.Value)
                {
                    MessageBox.Show(@"La Fecha Desde no puede ser mayor a la fecha Hasta", @"Error en Fecha",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }
        private void cFechaHasta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cFechaDesde.Value != null)
            {
                if (cFechaHasta.Value < cFechaDesde.Value)
                {
                    MessageBox.Show(@"La Fecha Hasta no puede ser mayor a la fecha Desde", @"Error en Fecha",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }
        private void txtMonedaDocumento_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtMonedaDocumento.Text == @"USD")
            {
                e.Cancel = false;
                return;
            }

            if (txtMonedaDocumento.Text == @"ARS")
            {
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }
        private void cFechaDocumento_Validated(object sender, EventArgs e)
        {
            cTc.SetValue = new ExchangeRateManager().GetExchangeRate(cFechaDocumento.Value.Value);
        }
        private void c1DescuentoPeso_Validated(object sender, EventArgs e)
        {
            cBruto.SetValue = c1DescuentoPeso.GetValueDecimal * -1;
            cDescuento.SetValue = 0;
            cSubtotal.SetValue = cBruto.GetValueDecimal;

            if (txtLx.Text == @"L1")
            {
                cImponible.SetValue = cBruto.GetValueDecimal;
                cIva.SetValue = Math.Round(cBruto.GetValueDecimal * (decimal)0.21, 2);
                cPercepcionIIBB.SetValue = 0; //todo: reemplaar por ARBA().getAlicuota
            }
            else
            {
                cImponible.SetValue = 0;
                cIva.SetValue = 0;
                cPercepcionIIBB.SetValue = 0;
            }
            cTotalFinal.SetValue = cSubtotal.GetValueDecimal + cIva.GetValueDecimal + cPercepcionIIBB.GetValueDecimal;
        }

        private void cAImporteNetoBase_Validated(object sender, EventArgs e)
        {
            caImporteDescuentoNeto.SetValue = cAImporteNetoBase.GetValueDecimal * cAPorcentaje.GetValueDecimal;
            if (_tipoLx == "L1")
            {
                cAImporteDescuentoBruto.SetValue = caImporteDescuentoNeto.GetValueDecimal / (decimal)1.21;
            }
            else
            {
                cAImporteDescuentoBruto.SetValue = caImporteDescuentoNeto.GetValueDecimal;
            }
        }
    }
}
