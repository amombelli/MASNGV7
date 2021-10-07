using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmFI47ChangeCobranzaType : Form
    {
        public FrmFI47ChangeCobranzaType(int modo = 0)
        {
            InitializeComponent();
        }

        private List<T0006_MCLIENTES> _customerList = new List<T0006_MCLIENTES>();
        private void FrmChangeCobranzaType_Load(object sender, EventArgs e)
        {
            ConfiguraStart();
        }
        private void ConfiguraStart()
        {
            rbRazonSocial.Checked = true;
            _customerList = new CustomerManager().GetCompleteListofBillTo(false);

            cmbCliente.DataSource = _customerList;
            cmbCliente.ValueMember = "IDCLIENTE";
            cmbCliente.DisplayMember = "cli_rsocial";

            cmbNuevoCliente.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
            cmbNuevoCliente.ValueMember = "IDCLIENTE";
            cmbNuevoCliente.DisplayMember = "cli_rsocial";

            btnDesimputar.Enabled = false;
            btnExecute.Enabled = false;
            btnModificarCliente.Enabled = false;
            btnRevertirCobranza.Enabled = false;
            cmbNuevoCliente.Enabled = false;

        }

        private void dgvListaCobranzas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCobranza.Text = dgvListaCobranzas[0, e.RowIndex].Value.ToString();
            txtNumeroRecibo.Text = dgvListaCobranzas[3, e.RowIndex].Value.ToString();
            txtCuentaOriginal.Text = dgvListaCobranzas[4, e.RowIndex].Value.ToString();
            var idCobranza = Convert.ToInt32(dgvListaCobranzas[0, e.RowIndex].Value);

            var dataCobranza = new CobranzaManagerExt2(idCobranza);

            var dataCobranzaSeleccionado = dataCobranza.GetCobranza();
            var importeCobranza = (decimal)dataCobranzaSeleccionado.Monto;
            var importeSinImputar = dataCobranza.CheckMontoSinImputarPorRecibo(idCobranza);
            var importeImputado = dataCobranza.CheckMontoImputadoPorRecibo();
            txtIdCliente.Text = cmbCliente.SelectedValue.ToString();
            txtClienteOriginal.Text = cmbCliente.Text;

            txtMontoRecibo.Text = importeCobranza.ToString("N2");
            txtMontoSinImputar.Text = importeSinImputar.ToString("N2");
            txtMontoImputado.Text = importeImputado.ToString("N2");

            ckEstadoCorrecto.Checked = importeCobranza == (importeImputado + importeSinImputar);
            if (ckEstadoCorrecto.Checked)
            {
                ckEstadoCorrecto.BackColor = Color.LimeGreen;
            }
            else
            {
                ckEstadoCorrecto.BackColor = Color.Crimson;
                MessageBox.Show(@"Los importes [imputado/sin imputar] no estan correctos", @"Error en importes",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (importeImputado != 0)
            {
                ckCobranzaImputada.Checked = true;
                ckCobranzaImputada.BackColor = Color.Crimson;
                btnDesimputar.Enabled = true;
                btnRevertirCobranza.Enabled = false;
            }
            else
            {
                ckCobranzaImputada.Checked = false;
                ckCobranzaImputada.BackColor = Color.LimeGreen;
                btnDesimputar.Enabled = false;
                btnExecute.Enabled = true;
                btnModificarCliente.Enabled = true;
                cmbNuevoCliente.Enabled = true;
                btnRevertirCobranza.Enabled = true;
            }

            if (txtCuentaOriginal.Text == @"L1")
            {
                txtNuevoTipo.Text = @"L2";
            }
            else
            {
                txtNuevoTipo.Text = @"L1";
            }

            if (ChangeCobranzaType.CheckIfAllChequesAreAvailable(Convert.ToInt32(txtIdCobranza.Text)))
            {
                ckChequesDisponibles.Checked = true;
                ckChequesDisponibles.BackColor = Color.LimeGreen;
            }
            else
            {
                ckChequesDisponibles.Checked = false;
                ckChequesDisponibles.BackColor = Color.Crimson;
            }
            var idCob = Convert.ToInt32(dgvListaCobranzas[0, e.RowIndex].Value);
            var list = new TecserData(GlobalApp.CnnApp).T0206_COBRANZA_I.Where(c => c.IDCOB == idCob).ToList();
            dgvItemsCobranza.DataSource = list;

        }
        private void dgvListaCobranzas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cmbNuevoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbNuevoCliente.ValueMember))
            {
                txtIdNuevoCliente.Text = cmbNuevoCliente.SelectedValue.ToString();
                var cta = new CtaCteCustomer(Convert.ToInt32(txtIdNuevoCliente.Text));
                txtSaldoL1.Text = cta.GetResultadoCtaCte("L1").SaldoDetalle.ToString("C2");
                txtSaldoL2.Text = cta.GetResultadoCtaCte("L2").SaldoDetalle.ToString("C2");
            }
        }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbCliente.ValueMember))
                return;

            dgvListaCobranzas.DataSource =
                new CobranzaManagerBase(Convert.ToInt32(cmbCliente.SelectedValue), "L1").GetListCobranzasByCustomerId();

            txtidCliente0.Text = cmbCliente.SelectedValue.ToString();

            var ctcte = new CtaCteCustomer(Convert.ToInt32(cmbCliente.SelectedValue));
            var saldoL1 = ctcte.GetResultadoCtaCte("L1");
            var saldoL2 = ctcte.GetResultadoCtaCte("L2");

            txtSaldoL1Cliente.Text = saldoL1.SaldoDetalle.ToString("C2");
            txtSaldoL2Cliente.Text = saldoL2.SaldoDetalle.ToString("C2");
            txtSaldoL1Cliente.BackColor = saldoL1.SaldoColor;
            txtSaldoL2Cliente.BackColor = saldoL2.SaldoColor;

            if (!saldoL1.SaldoOK)
                MessageBox.Show(@"El SALDO L1 del Cliente esta incorrecto!", @"Saldo Incorrecto", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

            if (!saldoL2.SaldoOK)
                MessageBox.Show(@"El SALDO L2 del Cliente esta incorrecto!", @"Saldo Incorrecto", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);


        }
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            int newCustomerId = Convert.ToInt32(txtIdNuevoCliente.Text);
            if (newCustomerId == Convert.ToInt32(txtIdCliente.Text))
            {
                MessageBox.Show(@"El Cliente al que se le va a asignar la cobranza debe ser diferente al orginal",
                    @"Modifcacion de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ckCobranzaImputada.Checked)
            {
                MessageBox.Show(@"Para continuar, la cobranza debe estar desimputada",
                   @"Modifcacion de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            new ChangeCobranzaCustomer().ChangeCobranzaToAnotherCustomer(Convert.ToInt32(txtIdCobranza.Text), newCustomerId);

            MessageBox.Show(@"La Cobranza de ha modificado correctamante!",
               @"Modifcacion de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnRevertirCobranza_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                MessageBox.Show(@"Debe colocar un comentario / motivo de la reversion - cancalecion de cobranza",
                    @"Reversion de Cobranza", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resp = MessageBox.Show(@"Confirma reversion/cancelacion de Cobranza?", @"Reversion de Cobranza",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resp == DialogResult.No)
                return;

            var cob = new CobranzaManagerExt2(Convert.ToInt32(txtIdCobranza.Text));
            var rev = cob.CancelaCobranza(txtMotivo.Text);

            if (rev)
            {
                MessageBox.Show(@"Se ha cancelado correctamente la cobranza seleccionada", @"Cancelacion de Cobranza",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Ha ocurrido un error en la cancelacion de la cobranza", @"Cancelacion de Cobranza",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDesimputar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"Confirma que quiere desimputar esta cobranza?",
                @"Desimputacion de Cobranzas", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                new CobranzaManagerExt2(Convert.ToInt32(txtIdCobranza.Text)).DesimputaCobranza();
                MessageBox.Show(@"Cobranza Desimputada Correctamente", @"Desimputacion de Cobranzas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (ChangeCobranzaType.CheckCobranzaSinImputar(Convert.ToInt32(txtIdCobranza.Text)) == false)
            {
                MessageBox.Show(@"La Cobranza se encuentra IMPUTADA a facturas", @"Validacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (ChangeCobranzaType.CheckIfAllChequesAreAvailable(Convert.ToInt32(txtIdCobranza.Text)) == false)
            {
                DialogResult dialogResult = MessageBox.Show(@"La Cobranza contiene cheques que ya no estan disponibles. Desea Continuar? (Hacer un cambio manual)",
               @"Cambio de Tipo de Cobranzas", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    if (new ChangeCobranzaType().ChangeCobranza(Convert.ToInt32(txtIdCobranza.Text), txtCuentaOriginal.Text,
               txtNuevoTipo.Text))
                    {
                        MessageBox.Show(@"La Cobranza se ha cambiado SATISFACTORIAMENTE", @"Validacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else
            {
                if (new ChangeCobranzaType().ChangeCobranza(Convert.ToInt32(txtIdCobranza.Text), txtCuentaOriginal.Text,
               txtNuevoTipo.Text))
                {
                    MessageBox.Show(@"La Cobranza se ha cambiado SATISFACTORIAMENTE", @"Validacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }


        }

        private void rbRazonSocial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRazonSocial.Checked == true)
            {
                cmbCliente.DataSource = _customerList;
                cmbCliente.ValueMember = "IDCLIENTE";
                cmbCliente.DisplayMember = "cli_rsocial";
            }
            else
            {
                cmbCliente.DataSource = _customerList;
                cmbCliente.ValueMember = "IDCLIENTE";
                cmbCliente.DisplayMember = "cli_fantasia";
            }
        }
    }
}
