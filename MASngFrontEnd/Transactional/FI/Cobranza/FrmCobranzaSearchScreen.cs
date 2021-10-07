using System;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.MasterData;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI.CtaCte;
using Tecser.Business.VBTools;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmCobranzaSearchScreen : Form
    {
        public FrmCobranzaSearchScreen(int modo = 0)
        {
            InitializeComponent();
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.TextChanged += new System.EventHandler(this.txtNumeroTax_TextChanged);
            this.txtNumeroTax.DragLeave += new System.EventHandler(this.txtNumeroTax_Leave);
            this.txtCodigoTax.TextChanged += new System.EventHandler(this.txtCodigoTax_TextChanged);
            this.txtCodigoTax.Leave += new System.EventHandler(this.txtCodigoTax_Leave);
            this.cmbTipoTax.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTax_SelectedIndexChanged);
            this.cmbId6.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.txtNumeroTax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0006MCLIENTESBindingSource,
                "CUIT", true));
            this.txtCodigoTax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0006MCLIENTESBindingSource,
                "TTAX", true));
        }

        private int? _id6;
        //-------------------------    Funcionalidad de Combos ------------------------------------

        #region Funcionalidad de Combos

        //1.-Definir Variable private int? _id6;
        //2.-Agregar Binding
        // NumeroTax (keyUP/TextChanged/Leave)
        // CodigoTax (TextChanged/Leave)
        //2.-Atencion cmbRazonSocial_TextUpdate asignado a 3 Combos

        ///**Funcionalidad validacion / CUIT
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
                //BlanqueaSeleccion();
                _id6 = null;
                return;
            }
            _id6 = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            //txtGLAp.Text = new GLAccountManagement().GetApVendorGl(_id6.Value);
            ValidaCuitCorrecto();

            var ctacte = new CtaCteCustomer(_id6.Value);
            txtSaldoL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtSaldoL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            txtSaldoL1.BackColor = ctacte.GetResultadoCtaCte("L1").SaldoColor;
            txtSaldoL2.BackColor = ctacte.GetResultadoCtaCte("L2").SaldoColor;
            txtSaldoTotal.Text =
                (FormatAndConversions.CCurrencyADecimal(txtSaldoL1.Text) +
                 FormatAndConversions.CCurrencyADecimal(txtSaldoL2.Text)).ToString("C2");
            //t0205COBRANZAHBindingSource.DataSource = new CobranzaSearch().GetListaCobranzas(_id6);
            cobranzaHeaderSerachBindingSource.DataSource = new CobranzaHeaderSerach().GetData(_id6, GlobalApp.CnnApp);
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
            //  }
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
            cobranzaHeaderSerachBindingSource.DataSource = new CobranzaHeaderSerach().GetData(_id6, GlobalApp.CnnApp);
        }

        //Fin Funcionalidad Combobox!

        #endregion



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaCobranza_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"no realizado aun.");
        }

        private void FrmCobranzaSearchScreen_Load(object sender, EventArgs e)
        {
            t0006MCLIENTESBindingSource.DataSource = new CustomerManager().GetCompleteListofBillTo();
            cobranzaHeaderSerachBindingSource.DataSource = new CobranzaHeaderSerach().GetData(_id6, GlobalApp.CnnApp);
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;

        }

        private void btnBusquedaAvanzada_Click(object sender, EventArgs e)
        {
            var f = new FrmBusquedaAvanzadaCliente();
            f.ShowDialog();
        }

        private void dgvListadoCobranzas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    var cellValue = dgvListadoCobranzas[e.ColumnIndex, e.RowIndex].Value.ToString();
                    int idCobranza =
                        Convert.ToInt32(
                            dgvListadoCobranzas[
                                dgvListadoCobranzas.Columns[iDCOBDataGridViewTextBoxColumn.Name].Index, e.RowIndex]
                                .Value);

                    switch (cellValue)
                    {
                        case "VER":
                            using (var f0 = new FrmDetalleCobranzaIngresada(idCobranza))
                            {
                                DialogResult dr = f0.ShowDialog();
                                if (dr == DialogResult.OK)
                                {
                                    //string custName = f0.CustomerName;
                                    //SaveToFile(custName);
                                }
                            }

                            break;

                        case "ENVIAR":
                            MessageBox.Show(@"Funcion no realizada aun");
                            break;
                        default:
                            MessageBox.Show(@"Boton no manejado aun");
                            break;
                    }

                }
            }
        }
    }
}
