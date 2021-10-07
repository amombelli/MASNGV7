using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.VBTools;
using TecserEF.Entity;

namespace MASngFE.MasterData.Customer_Master
{
    public partial class FrmCustomerSearch : Form
    {
        public FrmCustomerSearch()
        {
            InitializeComponent();
        }

        public FrmCustomerSearch(int modo = 1, string funcion = "MD")
        {
            _funcion = funcion;
            _modo = modo;
            InitializeComponent();
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.TextChanged += new System.EventHandler(this.txtNumeroTax_TextChanged);
            this.txtNumeroTax.Leave += new System.EventHandler(this.txtNumeroTax_Leave);
            this.txtNumeroTax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T0006Bs, "CUIT", true));
            this.txtCodigoTax.TextChanged += new System.EventHandler(this.txtCodigoTax_TextChanged);
            this.txtCodigoTax.Leave += new System.EventHandler(this.txtCodigoTax_Leave);
            this.txtCodigoTax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T0006Bs, "TTAX", true));
            this.cmbTipoTax.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTax_SelectedIndexChanged);
            this.cmbId6.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);

            switch (_funcion)
            {
                case "MD":
                    switch (_modo)
                    {
                        case 1:
                            btnButton1.Visible = false;
                            break;
                        case 2:
                            btnButton1.Text = "EDITAR";
                            break;
                        case 3:
                            btnButton1.Text = "VER";
                            break;
                        default:
                            btnButton1.Text = "";
                            break;
                    }
                    break;
                case "??":
                    break;
                default:
                    btnButton1.Text = "";
                    break;

            }
        }

        //-----------------------------------------------------------------------------------------------
        private int? _id6;
        private List<T0006_MCLIENTES> _customerList = new List<T0006_MCLIENTES>();
        private int _matchNumber;
        private string _funcion;
        private readonly int _modo;
        //-----------------------------------------------------------------------------------------------

        #region funcionalidad Combos

        private void txtNumeroTax_KeyUp(object sender, KeyEventArgs e)
        {
            //cuando es tipo 80 y 11 caracteres lo valida
            if (txtNumeroTax.Text.Length == 11 && txtCodigoTax.Text == @"80")
            {
                ValidaCuitCorrecto();
            }
        }
        private void txtNumeroTax_TextChanged(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtNumeroTax_Leave(object sender, EventArgs e)
        {
            ValidaCuitCorrecto();
        }
        private void txtCodigoTax_TextChanged(object sender, EventArgs e)
        {
            cmbTipoTax.Text = txtCodigoTax.Text == @"80" ? @"CUIT" : @"NI";
        }
        private void txtCodigoTax_Leave(object sender, EventArgs e)
        {
        }
        private void cmbTipoTax_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoTax.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                if (cmbTipoTax.Text == @"CUIT")
                {
                    txtCodigoTax.Text = @"80";
                    txtNumeroTax.BackColor = Color.LightGoldenrodYellow;
                }
                else
                {
                    txtCodigoTax.Text = @"00";
                    txtNumeroTax.BackColor = Color.DarkGray;
                    txtNumeroTax.Text = @"00000000000";
                }
            }
        }
        private void cmbRazonSocial_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
            }
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                _id6 = null;
                return;
            }
            _id6 = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            //txtGLAp.Text = new GLAccountManagement().GetApVendorGl(_id6.Value);
            ValidaCuitCorrecto();

            var ctacte = new CtaCteCustomer(_id6.Value);
            //**Si hay campos de Saldos
            //txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            //txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            //txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            //txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;
            //txtSaldoTotal.Text =
            //    (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) +
            //     FormatAndConversions.CCurrencyADecimal(txtSaldoL2.Text)).ToString("C2");
        }
        private void ValidaCuitCorrecto()
        {
            if (txtNumeroTax.Text.Length == 11 && txtNumeroTax.Text != @"00000000000")
            {
                if (new CuitValidation().ValidarCuit(txtNumeroTax.Text) == true)
                {
                    txtTaxValido.Text = @"VALIDO";
                    txtTaxValido.BackColor = Color.LightGreen;
                }
                else
                {
                    txtTaxValido.Text = @"INVALIDO";
                    txtTaxValido.BackColor = Color.Crimson;
                }
            }
            else
            {
                txtTaxValido.Text = @"SIN VALIDAR";
                txtTaxValido.BackColor = Color.Orange;
            }
        }
        private void BlanqueaSeleccion()
        {
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbTipoTax.SelectedIndex = -1;
            cmbId6.SelectedIndex = -1;
            txtNumeroTax.Text = null;
            txtCodigoTax.Text = null;
            _id6 = null;
            t0006MCLIENTESBindingSource.DataSource = _customerList.ToList();
            ckSoloActivos.BackColor = Color.IndianRed;
        }

        #endregion


        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {

        }

        private void FrmCustomerSearch_Load(object sender, EventArgs e)
        {
            ckSoloActivos.Checked = false;
            _customerList = new CustomerManager().GetCompleteListofBillTo(ckSoloActivos.Checked);
            T0006Bs.DataSource = _customerList;
            t0006MCLIENTESBindingSource.DataSource = _customerList;
            txtMatchNumber.Text = @"3";
            _matchNumber = Convert.ToInt32(txtMatchNumber.Text);
        }

        private void cmbRazonSocial_TextUpdate_1(object sender, EventArgs e)
        {
            if (cmbRazonSocial.Text.Length >= _matchNumber)
            {
                t0006MCLIENTESBindingSource.DataSource = _customerList.Where(c => c.cli_rsocial.ToUpper().Contains(cmbRazonSocial.Text.ToUpper())).ToList();
            }
        }

        private void ckSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloActivos.Checked)
            {
                ckSoloActivos.BackColor = Color.LawnGreen;
            }
            else
            {
                ckSoloActivos.BackColor = Color.IndianRed;
            }
            _customerList = new CustomerManager().GetCompleteListofBillTo(ckSoloActivos.Checked);
            t0006MCLIENTESBindingSource.DataSource = _customerList;
            T0006Bs.DataSource = _customerList;
        }

        private void txtMatchNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void txtMatchNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatchNumber.Text))
            {
                txtMatchNumber.Text = @"0";
                _matchNumber = 0;
            }
            else
            {
                _matchNumber = Convert.ToInt32(txtMatchNumber.Text);
            }
        }

        private void cmbFantasia_TextUpdate(object sender, EventArgs e)
        {
            if (cmbRazonSocial.Text.Length >= _matchNumber)
            {
                t0006MCLIENTESBindingSource.DataSource = _customerList.Where(c => c.cli_fantasia.ToUpper().Contains(cmbFantasia.Text.ToUpper())).ToList();
            }
        }

        private void dgvListaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = senderGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
                var id6 =
                    Convert.ToInt32(
                        senderGrid[senderGrid.Columns[iDCLIENTEDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value);

                var xTcode = new TcodeManager();
                TcodeManager.TcodeResponse response;
                switch (cellValue)
                {
                    case "VER":
                        //visualizar master data (MD)
                        response = xTcode.ValidateTransactionBeforeRun("CL3");
                        if (response == TcodeManager.TcodeResponse.TxOK)
                        {
                            using (var f = new FrmMdc02BillTo(_modo, id6, _funcion))
                            {
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"Acceso no Autorizado para visualizar clientes", @"Access Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }
                        break;
                    case "EDITAR":
                        //editar master data (MD)
                        response = xTcode.ValidateTransactionBeforeRun("CL2");
                        if (response == TcodeManager.TcodeResponse.TxOK)
                        {
                            using (var f = new FrmMdc02BillTo(_modo, id6, _funcion))
                            {
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"Acceso no Autorizado para editar clientes", @"Access Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }
                        break;
                    case "":
                        //Boton vacio 
                        MessageBox.Show(@"El Boton no tiene ninguna funcionalidad en este modo", @"Accion no Reconocida",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

    }
}
