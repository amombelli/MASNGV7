using System;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.MasterData.Customer_Master;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional;
using Tecser.Business.Transactional.CRM;
using Tecser.Business.Transactional.FI.CtaCte;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmCRM03GescoMain : Form
    {
        private int _idCliente;
        private readonly int _modo;

        public FrmCRM03GescoMain()
        {
            _modo = 1;
            InitializeComponent();
        }

        public FrmCRM03GescoMain(int modo, int idCliente)
        {
            _idCliente = idCliente;
            _modo = modo;
            InitializeComponent();
        }

        private void cmbEditDatosCliente_Click(object sender, EventArgs e)
        {
            using (var f = new FrmMdc06CobranzaDataMaintain(_idCliente))
            {
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    CompletaDatosCustomer();
                }
            }
        }



        private void CompletaHeaderData()
        {
            var z = new Gesco().GetHeader(_idCliente);
            ckCustomerCallRequest.Checked = z.RequestCall;
            ckConciliarCuenta.Checked = z.RequestConciliation;
            txtMensajeInternoH.Text = z.MensajeInterno;
            txtMensajePago.Text = z.MensajePago;
            ckPagoConfirmado.Checked = z.PagoConfirmado;
            if (z.FechaPagoConfirmado != null)
            {
                txtPagoConfirmadoDate.Text = z.FechaPagoConfirmado.Value.ToString("d");
            }
            else
            {
                txtPagoConfirmadoDate.Text = null;
            }

            if (z.UltimaLlamadaFecha != null)
            {
                DateTime oldDate = z.UltimaLlamadaFecha.Value;
                DateTime newDate = DateTime.Today;
                TimeSpan ts = newDate - oldDate;
                int differenceInDays = ts.Days;
                txtDiasUltimaLlamada.Text = differenceInDays.ToString();
                txtUltimaLlamada.Text = z.UltimaLlamadaFecha.Value.ToString("d");
            }

            ckPagoCanceladoModificado.Checked = z.PagoCanceladoModificado;
            if (z.PagoCanceladoModificado)
            {
                ckPagoCanceladoModificado.BackColor = Color.LightPink;
            }
            else
            {
                ckPagoCanceladoModificado.BackColor = Color.Transparent;
            }

            if (z.NextCall.HasValue)
            {
                DateTime oldDate = DateTime.Today;
                DateTime newDate = z.NextCall.Value;
                TimeSpan ts = newDate - oldDate;
                int differenceInDays = ts.Days;

                txtProximaLlamada.Text = z.NextCall.Value.ToString("d");
                txtProximaLlamadaDays.Text = differenceInDays.ToString();
                if (differenceInDays > 0)
                {
                    txtProximaLlamadaDays.BackColor = Color.LightBlue;
                }
                else
                {
                    txtProximaLlamada.BackColor = Color.LightPink;
                }
            }
            else
            {
                txtProximaLlamada.Text = @"No Asign.-";
                txtProximaLlamadaDays.Text = null;
                txtProximaLlamadaDays.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void RefrescaInfo()
        {
            CompletaHeaderData();
            RegistroLlamadaBs.DataSource = new Gesco().DetalleLlamadas(_idCliente);
            CtaCteBs.DataSource =
                new CtaCteCustomer(_idCliente).GetListaMovimientosCtaCte(ckVerL1.Checked, ckVerL2.Checked, ckSoloConSaldo.Checked);

        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                return;
            }

            _idCliente = Convert.ToInt32(cmbCliente.SelectedValue);
            txtIdCliente.Text = _idCliente.ToString();
            CompletaDatosCustomer();
            RefrescaInfo();
        }

        private void FrmCRM03GescoMain_Load(object sender, EventArgs e)
        {
            //el modo esta pensado para mandar listas ordenadas por x motivo
            tCustomerBs.DataSource = new CustomerManager().GetCompleteListofBillTo();
            if (_modo == 1)
            {
                //modo 1 = busqueda normal

                cmbCliente.SelectedIndex = -1;
            }
            else
            {
                cmbCliente.SelectedValue = _idCliente;
            }

            ckVerL1.Checked = true;
            ckVerL2.Checked = true;
            ckSoloConSaldo.Checked = true;
        }

        private void CompletaDatosCustomer()
        {
            var cust = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtTelefonoCobranza.Text = cust.TELEFONO_COB;
            txtDiasHorarioPago.Text = cust.DIA_HORARIO_COBRO;
            txtContactoPagoAProveedores.Text = cust.CONTACTO_COB;
            txtCondicionPagoL1.Text = cust.ZTERML1;
            txtCondicionPagoL2.Text = cust.ZTERML2;
            var ctacte = new CtaCteCustomer(_idCliente);
            var saldoL1 = ctacte.GetResultadoCtaCte("L1");
            txtSaldoL1.Text = saldoL1.SaldoResumen.ToString("C2");
            txtSaldoL1.BackColor = saldoL1.SaldoColor;
            var saldoL2 = ctacte.GetResultadoCtaCte("L2");
            txtSaldoL2.Text = saldoL2.SaldoResumen.ToString("C2");
            txtSaldoL2.BackColor = saldoL2.SaldoColor;
            txtSaldoTotal.Text = (saldoL1.SaldoResumen + saldoL2.SaldoResumen).ToString("C2");
            txtSaldoSinImputar.Text = (saldoL1.SaldoSinImputar + saldoL2.SaldoSinImputar).ToString("C2");
            txtEmailPaP.Text = cust.EMAIL_COBR;
            if (cust.Limite_credito == null)
            {
                txtLimiteCredito.Text = null;
                txtLimiteCredito.BackColor = Color.LightGoldenrodYellow;
            }
            else
            {
                txtLimiteCredito.Text = cust.Limite_credito.Value.ToString("C2");
                if ((saldoL1.SaldoSinImputar + saldoL2.SaldoSinImputar) >
                    (Convert.ToDecimal(cust.Limite_credito.Value)))
                {
                    txtLimiteCredito.BackColor = Color.LightPink;
                }
                else
                {
                    txtLimiteCredito.BackColor = Color.LightGreen;
                }
            }

            ckClienteBloqueadoEntrega.Checked = cust.BLK_DELIVERY;
            ckClienteBloqueadoPedido.Checked = cust.BLK_PEDIDO;


        }

        private void btnNuevaLlamada_Click(object sender, EventArgs e)
        {
            if (_idCliente == 0)
            {
                MessageBox.Show(@"Debe Seleccionar un Cliente para ingresar detalles",
                    @"Seleccione un Cliente para continuar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            using (var f = new FrmCRM04GescoCall(_idCliente))
            {
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var idRec = f.IdRegistro;
                    RefrescaInfo();
                }
            }
        }

        private void btnEliminarMsgInterno_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show(
                @"Desea Remover el Mensaje Interno?. Se enviará un correo al originante avisando que el mensaje ha sido removido",
                @"Mensaje Interno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            new CRMMensajeInterno().RemoveMessage(_idCliente, true);
            txtMensajeInternoH.Text = null;
        }

        private void txtMensajePago_TextChanged(object sender, EventArgs e)
        {

        }

        private void ckVerL1_CheckedChanged(object sender, EventArgs e)
        {
            if (_idCliente > 0)
            {
                CtaCteBs.DataSource =
                    new CtaCteCustomer(_idCliente).GetListaMovimientosCtaCte(ckVerL1.Checked, ckVerL2.Checked,
                        ckSoloConSaldo.Checked);
            }
        }

        private void btnPagoListo_Click(object sender, EventArgs e)
        {
            using (var f = new FrmCRM05GescoPagosListos())
            {
                f.ShowDialog();
            }
        }

        private void dgvMovimientosCtaCte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idCtaCte = Convert.ToInt32(datagridview[iDCTACTEDataGridViewTextBoxColumn.Name, e.RowIndex].Value);

            switch (cellValue)
            {
                case "Ver":
                    var TipoDoc = new CtaCteCustomer(_idCliente).GetRegistro201(idCtaCte).TDOC;
                    if (TipoDoc == "CO")
                    {
                        //Es una Cobranza
                        //using (var f0 = new FrmMaterialMasterAKA(primario, _modo, aka))
                        //{
                        //    DialogResult dr = f0.ShowDialog();
                        //    if (dr == DialogResult.OK)
                        //    {
                        //        //string custName = f0.CustomerName;
                        //        //SaveToFile(custName);
                        //    }
                        //}

                        break;
                    }
                    else
                    {
                        //using (var f0 = new FrmMaterialMasterAKA(primario, _modo, aka))
                        //{
                        //    DialogResult dr = f0.ShowDialog();
                        //    if (dr == DialogResult.OK)
                        //    {
                        //        //string custName = f0.CustomerName;
                        //        //SaveToFile(custName);
                        //    }
                        //}

                        break;
                    }
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void dgvRegistroLlamadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idRecord = Convert.ToInt32(datagridview[idRecordDataGridViewTextBoxColumn.Name, e.RowIndex].Value);

            switch (cellValue)
            {
                case "Ver":
                    using (var f0 = new FrmCRM04GescoCall(_idCliente, idRecord))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                        }
                    }

                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
