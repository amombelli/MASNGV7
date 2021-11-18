using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI63SeleccionDevolucionChequeACliente : Form
    {
        private readonly int _idCliente;
        private CustomerNd _nd;
        private readonly int _motivo; //1 = Rechazo - 2=Devolucion
        private readonly string _lx;
        public int? IdChequeSeleccionado { get; private set; }
        public decimal GastoRechazo { get; private set; }
        public decimal GastoFinanciero { get; private set; }
        public decimal IvaGastoRechazo { get; private set; }
        public bool _documentoAdicional { get; private set; }
        public CustomerNd ND2;
        public FrmFI63SeleccionDevolucionChequeACliente(CustomerNd nd, int motivo, string lx)
        {
            _nd = nd;
            _idCliente = nd.GetHeader().Cliente;
            _lx = nd.GetHeader().TIPOFACT;
            _motivo = motivo;
            InitializeComponent();
        }
        private void FrmFI63SeleccionDevolucionChequeACliente_Load(object sender, EventArgs e)
        {
            //private readonly int _motivo; //1 = Rechazo - 2=Devolucion
            _documentoAdicional = false;
            if (_motivo == 1)
            {
                //Rechazo
                dgvChequesRechazados.Visible = true;
                dgvChequesCartera.Visible = false;
                ChequeRechazadoBs.DataSource = new ChequeRechazadoManager().ListaChequeRechazados(_idCliente, _lx).ToList();
            }
            else
            {
                //Devolucion
                dgvChequesRechazados.Visible = false;
                dgvChequesCartera.Visible = true;
                ChequeCarteraBs.DataSource = new ChequesManager().GetListaChequesRecibidosCliente(_idCliente)
                    .Where(c => c.TIPO_REC == _lx).ToList();
            }

            if (_lx == "L1")
            {
                ckIva1.Checked = true;
                ckIva2.Checked = true;
                ckIva1.AutoCheck = false;
                ckIva2.AutoCheck = true;  //dejamos poder meter un gasto sin IVA por las dudas
                cAClientesIva.XReadOnly = false; //lo dejamos como workarround
            }
            else
            {
                ckIva1.Checked = false;
                ckIva2.Checked = false;
                ckIva1.AutoCheck = false;
                ckIva2.AutoCheck = false;
                cAClientesIva.XReadOnly = true;
            }
        }
        private void dgvChequesRechazados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            IdChequeSeleccionado = null;
            if (e.RowIndex < 0) return;

            int idCheque = Convert.ToInt32(dgv[_idChequeRechazado.Name, e.RowIndex].Value);
            IdChequeSeleccionado = idCheque;
            PopulaDatosChequeSeleccionado(idCheque);
            PopulaDatosDelRechazo(idCheque);
        }
        private void dgvChequesCartera_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            IdChequeSeleccionado = null;
            if (e.RowIndex < 0) return;

            int idCheque = Convert.ToInt32(dgv[_idChequeCartera.Name, e.RowIndex].Value);
            IdChequeSeleccionado = idCheque;
            PopulaDatosChequeSeleccionado(idCheque);
            PopulaDevolucion();
        }
        private void PopulaDatosChequeSeleccionado(int idCheque)
        {
            var x = new ChequesManager().GetCheque(idCheque);
            if (x != null)
            {
                cFechaChequeAcreditacion.Value = x.CHE_FECHA;
                txtIdCheque.Text = idCheque.ToString();
                txtChBanco.Text = x.T0160_BANCOS.BCO_SHORTDESC;
                txtChCliente.Text = x.CLIENTE;
                cFechaChequeRecibido.Value = x.FECHA_RECIBIDO;
                txtChLxRecibido.Text = x.TIPO_REC;
                cChImporte.SetValue = x.IMPORTE.Value;
                txtChNumero.Text = x.CHE_NUMERO;
            }
            else
            {
                IdChequeSeleccionado = null;
                cFechaChequeAcreditacion.Value = DateTime.Today;
                txtIdCheque.Text = null;
                txtChBanco.Text = null;
                txtChCliente.Text = null;
                cFechaChequeRecibido.Value = null;
                txtChLxRecibido.Text = null;
                cChImporte.SetValue = 0;
                txtChNumero.Text = null;
            }
        }
        private void PopulaDevolucion()
        {
            //blanquea gastos del Rechazo
            btnRechazar.Text = @"Devolver";
            pRechazo.Enabled = false;
            dtpFechaRechazo.Value = DateTime.Today;
            txtMotivoRechazo.Text = null;
            cGastoRechazo.SetValue = 0;
            cIvaGastoRechazo.SetValue = 0;
            cImporteTotalRechazo.SetValue = 0;
            //
            //Datos a Facturar-Cliente >> Copia del Rechazo
            txtAClientesMotivo.Text = null;
            txtAClientesMotivo.BackColor = Color.LightBlue;
            cAClientesGastos.SetValue = 0;
            txtAClientesGastosDescripcion.Text = null;
            cAClienteGastoFinanciero.SetValue = 0;
            txtAClienteDescripcionGsFinanciero.Text = null;

            cAClientesImporteTotal.SetValue = cAClientesIva.GetValueDecimal + cChImporte.GetValueDecimal +
                                              cAClientesGastos.GetValueDecimal +
                                              cAClienteGastoFinanciero.GetValueDecimal;

        }

        private void PopulaDatosDelRechazo(int idCheque)
        {
            btnRechazar.Text = @"Rechazar";
            var r = new ChequeRechazadoManager().GetRegistroChequeRech(idCheque);
            dtpFechaRechazo.Value = r.FECHA_RE.Value;
            txtMotivoRechazo.Text = @"Rec. CH#" + txtChNumero.Text + @" Motivo: " + r.MOTIVO_RE;
            cGastoRechazo.SetValue = r.GastosOrigen;
            cIvaGastoRechazo.SetValue = r.IVAGastosOrigen;
            cImporteTotalRechazo.SetValue = r.IMPORTE + r.GastosOrigen + r.IVAGastosOrigen;
            //
            //Datos a Facturar-Cliente >> Copia del Rechazo
            txtAClientesMotivo.Text = txtMotivoRechazo.Text;
            txtAClientesMotivo.BackColor = Color.LightGray;
            cAClientesGastos.SetValue = cGastoRechazo.GetValueDecimal;
            txtAClientesGastosDescripcion.Text = @"Gastos Bancarios";
            cAClienteGastoFinanciero.SetValue = 0;
            txtAClienteDescripcionGsFinanciero.Text = @"Gastos Financieros";

            if (_lx == "L2")
            {
                ckIva1.AutoCheck = false;
                ckIva2.AutoCheck = false;
                cAClientesIva.SetValue = 0;
                cAClientesIva.XReadOnly = true;
            }
            else
            {
                ckIva1.AutoCheck = true;
                ckIva2.AutoCheck = true;
                cAClientesIva.SetValue = 0;
                cAClientesIva.XReadOnly = false;
            }

            cAClientesImporteTotal.SetValue = cAClientesIva.GetValueDecimal + cChImporte.GetValueDecimal +
                                              cAClientesGastos.GetValueDecimal +
                                              cAClienteGastoFinanciero.GetValueDecimal;
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (ValidaOkRechzar() == false) return;

            _nd.AddItems("CHRECH", txtAClientesMotivo.Text, cChImporte.GetValueDecimal, "1.0.0.8", false);
            if (_documentoAdicional)
            {
                var datand = _nd.GetHeader();
                ND2 = new CustomerNd(CustomerNd.MotivoNotaDebito.ChequeRechazado);
                ND2.CreaHeader(ManageDocumentType.TipoDocumento.NotaDebitoVentaA, _idCliente, "L1",
                    datand.FECHA, datand.TC, "0E", datand.GLAR, true, "X");
                if (cAClientesGastos.GetValueDecimal > 0)
                {
                    ND2.AddItems("GSBAN", txtAClientesGastosDescripcion.Text, cAClientesGastos.GetValueDecimal,
                        txtGlGastos.Text, ckIva1.Checked);
                }

                if (cAClienteGastoFinanciero.GetValueDecimal > 0)
                {
                    if (ckIva2.Checked == true)
                    {
                        ND2.AddItems("GSFIN", txtAClienteDescripcionGsFinanciero.Text,
                            cAClienteGastoFinanciero.GetValueDecimal, txtGlFinanciero.Text, ckIva2.Checked);
                    }
                    else
                    {
                        _nd.AddItems("GSFIN", txtAClienteDescripcionGsFinanciero.Text,
                            cAClienteGastoFinanciero.GetValueDecimal, txtGlFinanciero.Text, ckIva2.Checked);
                    }
                }
                ND2.SetTotalesInHeaderFromItems();
                ND2.SetPeriodoAsociado(dtpFechaRechazo.Value, dtpFechaRechazo.Value);
            }
            else
            {
                if (cAClientesGastos.GetValueDecimal > 0)
                    _nd.AddItems("GSBAN", txtAClientesGastosDescripcion.Text, cAClientesGastos.GetValueDecimal,
                        txtGlGastos.Text, ckIva1.Checked);
                if (cAClienteGastoFinanciero.GetValueDecimal > 0)
                    _nd.AddItems("GSFIN", txtAClienteDescripcionGsFinanciero.Text,
                        cAClienteGastoFinanciero.GetValueDecimal, txtGlFinanciero.Text, ckIva2.Checked);
            }
            _nd.SetTotalesInHeaderFromItems();
            _nd.SetPeriodoAsociado(cFechaChequeAcreditacion.Value.Value, cFechaChequeAcreditacion.Value.Value);
            GastoRechazo = cAClientesGastos.GetValueDecimal + cAClienteGastoFinanciero.GetValueDecimal;
            IvaGastoRechazo = cAClientesIva.GetValueDecimal;

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;

        }
        private bool ValidaOkRechzar()
        {
            if (IdChequeSeleccionado == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Cheque de la lista", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtAClientesMotivo.Text))
            {
                MessageBox.Show(@"Debe completar el Texto - Motivo Devolucion", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cAClientesImporteTotal.GetValueDecimal == 0)
            {
                MessageBox.Show(@"Error en el Importe del Cheque", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (_lx == "L1")
            {
                if (cAClientesIva.GetValueDecimal > 0)
                {
                    var r = MessageBox.Show(@"Se va a Generar un Documento Interno por el Cheque Rechazado y una Nota de Debito 'A' por los Gastos+IVA", @"Confirmacion de Documento Adicional", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.No)
                        return false;
                    _documentoAdicional = true;
                }
            }
            else
            {
                //en L2 
                if (ckIva1.Checked == true || ckIva2.Checked == true || cAClientesIva.GetValueDecimal > 0)
                {
                    MessageBox.Show(@"En un Documento L2 - No puede existir IVA", @"Error en Impuestos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void ckIva2_CheckedChanged(object sender, EventArgs e)
        {
            decimal valorIva = 0;
            if (ckIva1.Checked)
                valorIva = cAClientesGastos.GetValueDecimal * (decimal)0.21;

            if (ckIva2.Checked)
                valorIva += cAClienteGastoFinanciero.GetValueDecimal * (decimal)0.21;
            cAClientesIva.SetValue = valorIva;
            cAClientesIva.XReadOnly = true;

            cAClientesImporteTotal.SetValue = cAClientesIva.GetValueDecimal + cChImporte.GetValueDecimal +
                                              cAClientesGastos.GetValueDecimal +
                                              cAClienteGastoFinanciero.GetValueDecimal;

        }
        private void cAClientesGastos_Validated(object sender, EventArgs e)
        {
            decimal valorIva = 0;
            if (ckIva1.Checked)
                valorIva = cAClientesGastos.GetValueDecimal * (decimal)0.21;

            if (ckIva2.Checked)
                valorIva += cAClienteGastoFinanciero.GetValueDecimal * (decimal)0.21;
            cAClientesIva.SetValue = valorIva;
            cAClientesIva.XReadOnly = true;

            cAClientesImporteTotal.SetValue = cAClientesIva.GetValueDecimal + cChImporte.GetValueDecimal +
                                              cAClientesGastos.GetValueDecimal +
                                              cAClienteGastoFinanciero.GetValueDecimal;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
