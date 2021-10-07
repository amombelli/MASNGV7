using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.OrdenPago;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI32OpAddItemPago : Form
    {
        public FrmFI32OpAddItemPago(FrmFI31OPMainScreen frm, int numeroOP, string tipoLx)
        {
            InitializeComponent();
            _numeroOP = numeroOP;
            txtLX.Text = tipoLx;
            _f = frm;
        }

        private readonly int _numeroOP;
        private readonly FrmFI31OPMainScreen _f;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }


        private void ConfiguraCmb()
        {
            cmbCuenta.ValueMember = "ID_CUENTA";
            cmbCuenta.DisplayMember = "CUENTA_DESC";
            cmbCuenta.DataSource = new CuentasManager().GetListCuentasAvailableOP();
            cmbCuenta.SelectedIndex = -1;
            panelCheques.Enabled = false;
        }

        private void FrmOrdenPagoAddItemsPago_Load(object sender, EventArgs e)
        {
            txtNumeroOP.Text = _numeroOP.ToString();
            var opHeader = new OrdenPagoManageDatos(_numeroOP).Header;
            txtProveedor.Text = opHeader.PROV_RS;
            ConfiguraCmb();
        }

        private void btnAddItemPago_Click(object sender, EventArgs e)
        {
            bool transferencia = false;
            if (txtImporteOrigen.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Debe proveer el Importe a Agregar en OP", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (rbCheque.Checked || rbEcheque.Checked)
            {
                if (string.IsNullOrEmpty(txtNumeroCheque.Text))
                {
                    MessageBox.Show(@"Debe completar el numero de Cheque/E-Cheque", @"Datos Incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cFechaAcreditacion.Value == null)
                {
                    MessageBox.Show(@"Debe completar la Fecha de Acreditacion del Cheque/E-Cheque", @"Datos Incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //utlilizo -5 como indicador de cheque propio emitido por tecser
                if (rbEcheque.Checked)
                    transferencia = true;
                new OrdenPagoManageDatos(_numeroOP).AddItemPago(cmbCuenta.SelectedValue.ToString(),
                    txtImporteOrigen.GetValueDecimal, fechaAcreditacionEmitido: cFechaAcreditacion.Value,
                    numeroChequeEmitido: txtNumeroCheque.Text, esTransferenciaDesdeCuenta: transferencia, idCheque: -5);

                //aca esta la emision de cheques

            }
            else
            {
                //no se trata de emision de cheques propios
                new OrdenPagoManageDatos(_numeroOP).AddItemPago(cmbCuenta.SelectedValue.ToString(),
                    txtImporteOrigen.GetValueDecimal, esTransferenciaDesdeCuenta: rbTransferencia.Checked);
            }
            new OPImputaFacturas(_numeroOP).ImputaFacturasOP();
            _f.RefreshDgvItemsdePago();
            _f.RecalculaTotalesOP();
            ResetInfo();
            cmbCuenta.SelectedIndex = -1;
        }

        private void ResetInfo()
        {
            rbTransferencia.Enabled = false;
            rbCheque.Enabled = false;
            rbEcheque.Enabled = false;
            panelCheques.Enabled = false;
            rbEcheque.Checked = false;
            rbTransferencia.Checked = false;
            rbCheque.Checked = false;
            txtNumBanco.Text = null;
            txtBancoDescripcion.Text = null;
            txtNumeroCheque.Text = null;
            cFechaAcreditacion.Value = null;
            txtImporteOrigen.SetValue = 0;

        }

        private void cmbCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetInfo();
            var data = (T0150_CUENTAS)cmbCuenta.SelectedItem;
            if (data == null)
            {
                //borra valores mapeo cuenta
                txtTipoCuenta.Text = null;
                txtMoneda.Text = null;
            }
            else
            {
                //hay una cuenta ingresada
                txtTipoCuenta.Text = data.CUENTA_TIPO;
                txtMoneda.Text = data.CUENTA_MONEDA;
                if (data.TRANSFERENCIA)
                {
                    rbTransferencia.Enabled = true;
                    rbTransferencia.Checked = true;
                }

                if (data.EmiteCheque)
                {
                    rbEcheque.Enabled = true;
                    rbCheque.Enabled = true;
                }
            }
            switch (txtTipoCuenta.Text)
            {
                case "CHEQUE":
                    btnAddItemPago.Enabled = false;
                    using (var f2 = new FrmFI34BusquedaCheques(_f, txtLX.Text, "OP", Convert.ToInt32(txtNumeroOP.Text)))
                    {
                        f2.ShowDialog();
                        this.Close();
                    }
                    break;
                default:
                    btnAddItemPago.Enabled = true;
                    break;
            }
        }

        private void cmbCuenta_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbCuenta);
        }

        private void rbEcheque_CheckedChanged(object sender, EventArgs e)
        {
            var control = (RadioButton)sender;
            if (control.Checked)
            {
                panelCheques.Enabled = true;
                var bankValue = cmbCuenta.SelectedValue.ToString().Substring(0, 3);
                //switch (cmbCuenta.SelectedValue.ToString())
                //{
                //    case "ICBC":
                //        txtNumBanco.Text = bancos.ID_BANCO;
                //        txtBancoDescripcion.Text = bancos.BCO_SHORTDESC;
                //        break;
                //    case "SAN":
                //        txtNumBanco.Text = bancos.ID_BANCO;
                //        txtBancoDescripcion.Text = bancos.BCO_SHORTDESC;
                //        break;
                //    case "GAL":
                //        txtNumBanco.Text = bancos.ID_BANCO;
                //        txtBancoDescripcion.Text = bancos.BCO_SHORTDESC;
                //        break;
                //}
                var bancos = new BankManager().GetBankDataNombreCuenta(bankValue);
                txtNumBanco.Text = bancos.ID_BANCO;
                txtBancoDescripcion.Text = bancos.BCO_SHORTDESC;
            }
            else
            {
                panelCheques.Enabled = false;
                txtNumBanco.Text = null;
                txtBancoDescripcion.Text = null;
                txtNumBanco.Text = null;
            }
        }
    }
}
