using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI.OrdenPago;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI36Retenciones : Form
    {
        private readonly OrdenPagoCreateNew.TipoRetencion _tipoRet;
        public decimal Importe { get; private set; }
        public decimal BaseImpo { get; private set; }
        public decimal Alicuota { get; private set; }
        public string gL { get; private set; }

        private readonly int _modo;
        
        public FrmFI36Retenciones(string tipoRetencion, decimal baseImponible, decimal alicuota, decimal importeRetencion, string Gl)
        {
            _modo = 2;
            switch (tipoRetencion)
            {
                case "RIB":
                    _tipoRet = OrdenPagoCreateNew.TipoRetencion.Arba;
                    break;
                case "RGA":
                    _tipoRet = OrdenPagoCreateNew.TipoRetencion.Ganancias;
                    break;
            }
            BaseImpo = baseImponible;
            Alicuota = alicuota;
            Importe = importeRetencion;
            gL = Gl;
            InitializeComponent();
        }

        public FrmFI36Retenciones(OrdenPagoCreateNew.TipoRetencion tipoRet)
        {
            _modo = 1;
            _tipoRet = tipoRet;
            InitializeComponent();
        }

        private void FrmFI36Retenciones_Load(object sender, EventArgs e)
        {
            switch (_tipoRet)
            {
                case OrdenPagoCreateNew.TipoRetencion.Ganancias:
                    cmbTipoRetencion.SelectedItem = "Ganancias [AFIP]";
                    break;
                case OrdenPagoCreateNew.TipoRetencion.Arba:
                    cmbTipoRetencion.SelectedItem = "IIBB [ARBA]";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_modo == 2)
            {
                cmbTipoRetencion.Enabled = false;
                btnAddRetencion.Visible = false;
                btnConfirmar.Visible = true;
                txtGLItem.Text = gL;
                ctlBaseImponible.SetValue = BaseImpo;
                ctlAlicuota.SetValue = Alicuota;
                ctlImporteRetencion.SetValue = Importe;
            }
            else
            {
                btnAddRetencion.Visible = true;
                btnConfirmar.Visible = false;
            }
        }
        
        private void btnAddRetencion_Click(object sender, EventArgs e)
        {
            if (cmbTipoRetencion.SelectedItem == null)
            {
                MessageBox.Show(@"Seleccione el tipo de Retencion a Agregar", @"Error en tipo de Retencion",
                    MessageBoxButtons.OK);
                return;
            }

            if (ctlImporteRetencion.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"El Importe de la Retencion es Incorrecto", @"Revise Importe Retencion",
                    MessageBoxButtons.OK);
                return;
            }
            Importe = ctlImporteRetencion.GetValueDecimal;
            BaseImpo = ctlBaseImponible.GetValueDecimal;
            Alicuota = ctlAlicuota.GetValueDecimal;
            this.Close();
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ctlImporteRetencion.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"El Importe de la Retencion es Incorrecto", @"Revise Importe Retencion",
                    MessageBoxButtons.OK);
                return;
            }
            Importe = ctlImporteRetencion.GetValueDecimal;
            BaseImpo = ctlBaseImponible.GetValueDecimal;
            Alicuota = ctlAlicuota.GetValueDecimal;
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
    }
}
