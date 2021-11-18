using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFi64DevolucionChequeCliente : Form
    {
        private readonly int _idCliente;
        private CustomerNd _nd;
        public CustomerNd NdGastosL1;
        private readonly string _lx;
        public int? IdChequeSeleccionado { get; private set; }
        public bool _documentoAdicional { get; private set; }
        private bool _flagChequeAdded = false; // flag interno para confirmar
        private bool _flagGastosAdded = false; // flag interno para confirmar 

        public FrmFi64DevolucionChequeCliente(CustomerNd nd)
        {
            _nd = nd;
            var h = nd.GetHeader();
            _idCliente = h.Cliente;
            _lx = h.TIPOFACT;
            InitializeComponent();
        }

        private void FrmFi64DevolucionChequeCliente_Load(object sender, EventArgs e)
        {
            ChequeCarteraBs.DataSource = new ChequesManager().GetListaChequeRecibidoCliente(_idCliente, _lx, true, false);
            dgvChequesCartera.ClearSelection();
            BlanqueaDatosCheque();
            ckTextoStandard.Checked = true;
            btnDevolverCheque.Enabled = true;
            btnAddGastos.Enabled = false;
            btnConfirmarRetorno.Enabled = false;
        }
        private void dgvChequesCartera_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            IdChequeSeleccionado = null;
            if (e.RowIndex < 0) return;

            int idCheque = Convert.ToInt32(dgv[_idChequeCartera.Name, e.RowIndex].Value);
            IdChequeSeleccionado = idCheque;
            PopulaDatosChequeSeleccionado();
        }
        private void BlanqueaDatosCheque()
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
            if (ckTextoStandard.Checked)
                txtMotivo.Text = null;
        }
        private void PopulaDatosChequeSeleccionado()
        {
            if (IdChequeSeleccionado == null)
            {
                BlanqueaDatosCheque();
                return;
            }
            var x = new ChequesManager().GetCheque(IdChequeSeleccionado.Value);
            if (x != null)
            {
                cFechaChequeAcreditacion.Value = x.CHE_FECHA;
                txtIdCheque.Text = IdChequeSeleccionado.Value.ToString();
                txtChBanco.Text = x.T0160_BANCOS.BCO_SHORTDESC;
                txtChCliente.Text = x.CLIENTE;
                cFechaChequeRecibido.Value = x.FECHA_RECIBIDO;
                txtChLxRecibido.Text = x.TIPO_REC;
                cChImporte.SetValue = x.IMPORTE.Value;
                txtChNumero.Text = x.CHE_NUMERO;
                if (ckTextoStandard.Checked)
                    txtMotivo.Text = $@"Devolucion Cheque Banco: {txtChBanco.Text} #{txtChNumero.Text}";
            }
            else
            {
                BlanqueaDatosCheque();
            }
        }

        private bool ValidaOkRechzar()
        {
            if (_flagChequeAdded)
            {
                MessageBox.Show(
                    @"No se puede agregar el cheque a la nota de debito porque ya existe un documento agregado",
                    @"Error Interno en Seleccion Cheque", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

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
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
        private void btnAddGastos_Click(object sender, EventArgs e)
        {
            if (_flagChequeAdded == false)
            {
                MessageBox.Show(
                    @"Para agregar gastos internos de rechazo/devolucion debe primero agregar el cheque a la nota de debito",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //todo: llamar aca a la funcion para abrir FIgastos
            if (_lx == "L1")
            {
                //Los gastos tienen que ser en Nota de Debito con IVA
                var datand = _nd.GetHeader();
                NdGastosL1 = new CustomerNd(CustomerNd.MotivoNotaDebito.ChequeRechazado);
                NdGastosL1.CreaHeader(ManageDocumentType.TipoDocumento.NotaDebitoVentaA, _idCliente, "L1",
                    datand.FECHA, datand.TC, "0E", datand.GLAR, true, "X");
                using (var f0 = new FrmFI65GastosFinancieros(NdGastosL1, CustomerNd.MotivoNotaDebito.ChequeSinRechazo))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        _documentoAdicional = true;
                    }
                    else
                    {
                        MessageBox.Show(@"No se han Agregado Gastos de Gestion", @"Cancelacion de Gastos", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        _documentoAdicional = false;
                    }
                }
            }
            else
            {
                //Los gastos se agregan al documento X 
                _documentoAdicional = false;
                using (var f0 = new FrmFI65GastosFinancieros(_nd, CustomerNd.MotivoNotaDebito.ChequeSinRechazo))
                {
                    DialogResult dr = f0.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        //
                    }
                    else
                    {
                        MessageBox.Show(@"No se han Agregado Gastos de Gestion", @"Cancelacion de Gastos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                    }
                }
            }
        }
        private void btnDevolverCheque_Click(object sender, EventArgs e)
        {
            if (ValidaOkRechzar() == false) return;
            _nd.AddItems("CHRECH", txtAClientesMotivo.Text, cChImporte.GetValueDecimal, "1.0.0.8", false);
            _flagChequeAdded = true;

            btnDevolverCheque.Enabled = false;
            btnAddGastos.Enabled = true;
            btnConfirmarRetorno.Enabled = true;
        }
        private void btnConfirmarRetorno_Click(object sender, EventArgs e)
        {
            if (_flagChequeAdded == false)
            {
                MessageBox.Show(
                    @"No se puede confirmar el retorno por que el cheque no se ha agregado a la Nota de Debito",
                    @"Error en seleccion de datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void ckTextoStandard_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTextoStandard.Checked)
            {
                txtMotivo.ReadOnly = true;
                if (IdChequeSeleccionado != null)
                {
                    txtMotivo.Text = $@"Devolucion Cheque Banco: {txtChBanco.Text} #{txtChNumero.Text}";
                }
                else
                {
                    txtMotivo.Text = null;
                }
            }
            else
            {
                txtMotivo.ReadOnly = false;
                txtMotivo.Text = null;
            }
        }


    }
}
