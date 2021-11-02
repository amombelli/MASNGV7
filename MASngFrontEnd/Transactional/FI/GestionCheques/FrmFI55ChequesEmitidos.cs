using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.GestionCheques
{
    public partial class FrmFI55ChequesEmitidos : Form
    {
        public FrmFI55ChequesEmitidos()
        {
            InitializeComponent();
        }

        private List<T0159_CHEQUES_EMITIDOS> _lista;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFI55ChequesEmitidos_Load(object sender, EventArgs e)
        {
            new GestionChequesEmitidos().ActualizaVencidoYProximo();
            _lista = new GestionChequesEmitidos().GetListaChequesEmitidos(false);
            ckSoloPendientes.Checked = true;
            dgvData.ClearSelection();
            ImportesSumarizados();
        }

        private void ckSoloPendientes_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloPendientes.Checked)
            {
                dgvData.DataSource = _lista.Where(c => c.PendienteAcreditacion).ToList();
                rbProximos5Dias.AutoCheck = true;
                rbAcreditacionVencida.AutoCheck = true;
                rbTodosPendientes.AutoCheck = true;
            }
            else
            {
                //muestra todos los cheques (incluidos los acreditados)
                dgvData.DataSource = _lista;
                rbProximos5Dias.Checked = false;
                rbAcreditacionVencida.Checked = false;
                rbTodosPendientes.Checked = false;
                rbProximos5Dias.AutoCheck = false;
                rbAcreditacionVencida.AutoCheck = false;
                rbTodosPendientes.AutoCheck = false;
            }
        }

        private void ImportesSumarizados()
        {
            DateTime fechaHoy = DateTime.Today;
            DateTime fecha5Dias = DateTime.Today.AddDays(5);

            var i1 = _lista.Where(c => c.FechaAcreditacion < fechaHoy && c.PendienteAcreditacion).ToList();
            txtImporteAcreditacionVencida.Text = i1.Any() ? i1.Sum(c => c.ImporteCheque).ToString("C2") : 0.ToString("C2");

            i1 = _lista.Where(c =>
                    c.FechaAcreditacion >= fechaHoy && c.FechaAcreditacion <= fecha5Dias && c.PendienteAcreditacion)
                .ToList();
            txtImporteVencido5dias.Text = i1.Any() ? i1.Sum(c => c.ImporteCheque).ToString("C2") : 0.ToString("C2");

            i1 = _lista.Where(c => c.PendienteAcreditacion).ToList();
            txtImporteEmitidoPendiente.Text = i1.Any() ? i1.Sum(c => c.ImporteCheque).ToString("C2") : 0.ToString("C2");
        }


        private void rbAcreditacionVencida_CheckedChanged(object sender, EventArgs e)
        {
            var r = (RadioButton)sender;
            if (r.Checked == false)
                return;

            DateTime fechaHoy = DateTime.Today;
            DateTime fecha5Dias = DateTime.Today.AddDays(5);

            if (rbAcreditacionVencida.Checked)
            {
                dgvData.DataSource = _lista.Where(c => c.PendienteAcreditacion && c.FechaAcreditacion < fechaHoy)
                    .OrderBy(c => c.FechaAcreditacion).ToList();
            }
            else
            {
                if (rbProximos5Dias.Checked)
                {
                    dgvData.DataSource = _lista.Where(c => c.PendienteAcreditacion && c.FechaAcreditacion >= fechaHoy && c.FechaAcreditacion <= fecha5Dias).OrderBy(c => c.FechaAcreditacion).ToList();
                }
                else
                {
                    dgvData.DataSource = _lista.Where(c => c.PendienteAcreditacion).OrderBy(c => c.FechaAcreditacion).ToList();
                    //Ver todos los pendientes de acreditar
                }
            }
            ImportesSumarizados();
        }

        private void MapDataChequeSeleccionado(int idRecord)
        {
            if (idRecord == 0)
            {
                txtIdRegistro.Text = null;
                txtVendorId.Text = null;
                txtStatus.Text = @"--------";
                txtBanco.Text = null;
                txtProveedor.Text = null;
                txtNumeroOp.Text = null;
                txtNumeroCheque.Text = null;
                txtImporte.Text = 0.ToString("C2");
                txtFechaEmision.Text = null;
                txtFechaAcreditacion.Text = null;
                dtpFechaAcreditacionConfirmada.Visible = false;
                lfechaNoConfirmada.Visible = true;
                btnCancelarAcreditacion.Enabled = false;
                btnAcreditar.Enabled = false;
            }
            else
            {
                var r = new GestionChequesEmitidos().GetChequeEmitido(idRecord);
                //
                txtVendorId.Text = r.Proveedor.ToString();
                txtIdRegistro.Text = idRecord.ToString();
                txtStatus.Text = r.Status;
                txtBanco.Text = r.BancoChequeShort;
                txtProveedor.Text = new VendorManager().GetSpecificVendor(r.Proveedor).prov_rsocial;
                txtNumeroOp.Text = r.OrdenPagoNumero.ToString();
                txtNumeroCheque.Text = r.NumeroCheque;
                txtImporte.Text = r.ImporteCheque.ToString("C2");
                txtFechaEmision.Text = r.FechaEmision.ToString("d");
                txtFechaAcreditacion.Text = r.FechaAcreditacion.ToString("d");
                if (r.PendienteAcreditacion)
                {
                    if (r.FechaAcreditacion > DateTime.Today)
                    {
                        dtpFechaAcreditacionConfirmada.Visible = false;
                        lfechaNoConfirmada.Visible = true;
                        btnCancelarAcreditacion.Enabled = false;
                        btnAcreditar.Enabled = false;
                        btnAcreditar.Enabled = false;
                        btnCancelarAcreditacion.Enabled = false;
                    }
                    else
                    {
                        dtpFechaAcreditacionConfirmada.Visible = true;
                        lfechaNoConfirmada.Visible = false;
                        btnCancelarAcreditacion.Enabled = false;
                        btnAcreditar.Enabled = true;
                        btnCancelarAcreditacion.Enabled = false;
                        btnAcreditar.Enabled = true;
                    }
                }
                else
                {
                    if (r.FechaAcreditacionReal != null)
                    {
                        dtpFechaAcreditacionConfirmada.Value = r.FechaAcreditacionReal.Value;
                    }
                    else
                    {
                        dtpFechaAcreditacionConfirmada.Visible = false;
                        lfechaNoConfirmada.Visible = true;
                        //sera cancelado? o algo?
                    }

                    btnCancelarAcreditacion.Enabled = true;
                    btnAcreditar.Enabled = false;
                }
            }

        }

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                MapDataChequeSeleccionado(0);
            }
            else
            {
                int idRecord = Convert.ToInt32(dgv[_idRecord.Name, e.RowIndex].Value);
                MapDataChequeSeleccionado(idRecord);
            }
        }

        private void btnAcreditar_Click(object sender, EventArgs e)
        {
            if (dtpFechaAcreditacionConfirmada.Value < Convert.ToDateTime(txtFechaAcreditacion.Text))
            {
                MessageBox.Show(
                    @"La fecha de Acreditacion real es Incorrecta porque el cheque aun no esta en Fecha de acreditacion",
                    @"Revise la Fecha de Acreditacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRegistro = Convert.ToInt32(txtIdRegistro.Text);

            new GestionChequesEmitidos().SetChequeAcreditado(Convert.ToInt32(txtIdRegistro.Text), dtpFechaAcreditacionConfirmada.Value);
            dgvData.Refresh();
            MapDataChequeSeleccionado(idRegistro);

            var numeroAsiento = new AsientoOrdenPago(Convert.ToInt32(txtNumeroOp.Text), "ACH").AsientoAcreditacionCheque(txtBanco.Text, FormatAndConversions.CCurrencyADecimal(txtImporte.Text),
                dtpFechaAcreditacionConfirmada.Value, Convert.ToInt32(txtIdRegistro.Text));

            //Se Registra en REG el debito en el banco
            var idXreg=new SubdiarioCajaManager().WriteToDb(txtBanco.Text, dtpFechaAcreditacionConfirmada.Value,
                SubdiarioCajaManager.PC.Proveedor, Convert.ToInt32(txtVendorId.Text), "OP", txtNumeroOp.Text,
                @"Acreditacion Cheque", "ARS", 0, FormatAndConversions.CCurrencyADecimal(txtImporte.Text), "L1", "ACH", numeroAsiento.IdDocu,
                new CuentasManager().GetGL(txtBanco.Text),idCheque:idRegistro,chequeEmitidoPropio:true);
            //Update T159 con datos post-Acreditacion
            GestionChequesEmitidos.Update159AfterAcreditacion(idRegistro,idXreg,numeroAsiento.IdDocu);
        }

        private void btnCancelarAcreditacion_Click(object sender, EventArgs e)
        {
            new GestionChequesEmitidos().SetChequReversaAcreditacion(Convert.ToInt32(txtIdRegistro.Text));
            dgvData.Refresh();
            MapDataChequeSeleccionado(Convert.ToInt32(txtIdRegistro.Text));

            var numeroAsiento = new AsientoOrdenPago(Convert.ToInt32(txtNumeroOp.Text), "ACH").AsientoDesAcreditacionCheque(txtBanco.Text, FormatAndConversions.CCurrencyADecimal(txtImporte.Text),
                DateTime.Today, Convert.ToInt32(txtIdRegistro.Text));

            //Se Registra en REG el credito en el banco
            new SubdiarioCajaManager().WriteToDb(txtBanco.Text, dtpFechaAcreditacionConfirmada.Value,
                SubdiarioCajaManager.PC.Proveedor, Convert.ToInt32(txtVendorId.Text), "OP", txtNumeroOp.Text,
                @"Reversal - Acreditacion Cheque", "ARS", FormatAndConversions.CCurrencyADecimal(txtImporte.Text), 0, "L1", "ACH", numeroAsiento.IdDocu,
                new CuentasManager().GetGL(txtBanco.Text));
        }
    }
}
