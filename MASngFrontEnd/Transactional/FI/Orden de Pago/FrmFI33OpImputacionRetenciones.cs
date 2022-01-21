using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.OrdenPago;
using Tecser.Business.WebServices;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI33OpImputacionRetenciones : Form
    {
        public FrmFI33OpImputacionRetenciones(FrmFI31OPMainScreen frm, int numeroOP)
        {
            _f = frm;
            _numeroOP = numeroOP;
            InitializeComponent();
        }

        private readonly int _numeroOP;
        private readonly FrmFI31OPMainScreen _f;



        private void ConfiguraControles()
        {
            dgvRetencionesFacturas.DataSource = t0405FACTURASRETENCIONESBindingSource;
            t0405FACTURASRETENCIONESBindingSource.DataSource = new MngRetencionesFacturasProv().GetAllRetencionesFromOP(_numeroOP).ToList();
            btnUpdate.Enabled = false;
            btnGetAlicuota.Enabled = false;
        }


        //Revisado OK ----
        private T0405_FACTURAS_RETENCIONES _data = new T0405_FACTURAS_RETENCIONES();

        private void FrmImputacionRetenciones_Load(object sender, EventArgs e)
        {
            ConfiguraControles();
            MapeaDatosOPHeaderToForm();
        }
        private void MapeaDatosOPHeaderToForm()
        {
            txtNumeroOP.Text = _numeroOP.ToString();
            var header = new OrdenPagoManageDatos(_numeroOP).GetDatosHeaderFromDb();
            txtVendorDescripction.Text = header.PROV_RS;
            txtVendorId.Text = header.PROV_ID.ToString();
            txtCUIT.Text = header.PROV_CUIT;
            txtPeriodo.Text = new PeriodoConversion().GetPeriodo(header.OPFECHA);
        }


        private void dgvRetencionesFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView) sender;
            //if (e.RowIndex >= 0)
            //{
            //    var valor = dgvRetencionesFacturas[7, e.RowIndex].Value;
            //    _data = new MngRetencionesFacturasProv().GetSpecificRecordT0405(_numeroOP, Convert.ToInt32(valor));
            //    if (_data == null)
            //    {
            //        MessageBox.Show(
            //            @"Se ha encontrado un error . se esperaba que el registro existiese en la tabla T0405", @"Error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    MapDataDbForm(_data);
            //}
        }


        private void MapDataDbForm(T0405_FACTURAS_RETENCIONES data)
        {
            var f = new FormatAndConversions();
            txtIDFactura.Text = data.IDFacturaProveedor.ToString();
            txtPeriodo.Text = data.PeriodoOP;
            txtBaseImponibleDocumento.Text = data.BaseImponibleDocumento.Value.ToString("C2");
            txtIIBBARetener.Text = data.RetIIBBARetener.Value.ToString("C2");
            txtAlicRetencionIIBB.Text = data.RetIIBBAlicuota.ToString();
            txtAlicuotaGanancias.Text = data.RetGSAlicuota.ToString();
            txtCertificadoExentoGanancias.Text = data.RetGSCertificado;
            txtConceptoGSid.Text = data.RetGsConcepto;
            txtBaseImponibleGanancias.Text = data.RetGSBase.Value.ToString("C2");
            txtRetencionGanancias.Text = data.RetGSARetener.Value.ToString("C2");
            txtBaseCalucloGS.Text = data.RetGSBaseCalculo.Value.ToString("C2");

            btnGetAlicuota.Enabled = true;
            btnUpdate.Enabled = true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new MngRetencionesFacturasProv().UpdateImporteRetencionesFacturaSeleccionada(_numeroOP,
                Convert.ToInt32(txtIDFactura.Text),
                new FormatAndConversions().GetCurrencyFormat_Decimal(txtBaseImponibleDocumento.Text),
                FormatAndConversions.CPorcentajeADecimal(txtAlicRetencionIIBB.Text),
                new FormatAndConversions().GetCurrencyFormat_Decimal(txtIIBBARetener.Text),
                FormatAndConversions.CPorcentajeADecimal(txtAlicuotaGanancias.Text),
                new FormatAndConversions().GetCurrencyFormat_Decimal(txtRetencionGanancias.Text),
                new FormatAndConversions().GetCurrencyFormat_Decimal(txtBaseCalucloGS.Text), true);

            t0405FACTURASRETENCIONESBindingSource.DataSource = new MngRetencionesFacturasProv().GetAllRetencionesFromOP(_numeroOP).ToList();
            new OPImputaFacturas(_numeroOP).ImputaFacturasOP();  //added on 2019.01.04
            _f.RecalculaTotalesOP();
            _f.RefreshDgvFacturasEnOP();
        }
        private void btnGetAlicuota_Click(object sender, EventArgs e)
        {
            string fechaDesde = new PeriodoConversion().GetPrimerDiaPeriodoYyyymmdd(txtPeriodo.Text);
            string fechaHasta = new PeriodoConversion().GetUltimoDiaPeriodoYyyymmdd(txtPeriodo.Text);
            try
            {
                var iibb = new PadronArba();
                iibb.Conectar(txtCUIT.Text, fechaDesde, fechaHasta);
                txtAlicRetencionIIBB.Text = iibb.AlRete.ToString("p2");
                decimal coef;
                if (string.IsNullOrEmpty(txtCoeficienteCM05.Text))
                {
                    coef = (decimal)0.00;
                }
                else
                {
                    coef = Convert.ToDecimal(txtCoeficienteCM05.Text);
                }

                txtIIBBARetener.Text =
                    new Retenciones().CalculoRetencionIIBB(Convert.ToDecimal(iibb.AlRete), coef,
                        new FormatAndConversions().GetCurrencyFormat_Decimal(txtBaseImponibleDocumento.Text))
                        .ToString("C2");

            }
            catch (Exception)
            {

                MessageBox.Show(@"Ha ocurrido un error al conectarse con ARBA");
                //throw new Exception("Error al conectarse con ARBA");
            }

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRetenciones_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmAgregaFacturaRetencion(_numeroOP))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    t0405FACTURASRETENCIONESBindingSource.DataSource = new MngRetencionesFacturasProv().GetAllRetencionesFromOP(_numeroOP).ToList();

                    _f.RecalculaTotalesOP();
                    _f.RefreshDgvFacturasEnOP();
                }
            }

        }

        private void dgvRetencionesFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                var valor = dgvRetencionesFacturas[7, e.RowIndex].Value;
                _data = new MngRetencionesFacturasProv().GetSpecificRecordT0405(_numeroOP, Convert.ToInt32(valor));
                if (_data == null)
                {
                    MessageBox.Show(
                        @"Se ha encontrado un error . se esperaba que el registro existiese en la tabla T0405", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MapDataDbForm(_data);
            }
        }
    }
}
