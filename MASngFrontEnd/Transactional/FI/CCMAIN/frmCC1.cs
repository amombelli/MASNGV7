using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Transactional.FI.Cobranza;
using MASngFE.Transactional.FI.Factura;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.FI.CCMAIN
{
    public partial class frmCC1 : Form
    {
        public frmCC1()
        {
            InitializeComponent();
        }

        public frmCC1(int modo)
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------
        private List<Cc1DataStructure> _data = new List<Cc1DataStructure>();
        private CtaCteCustomerGlobal.Retorno _globalData;

        public List<Cc1DataStructure> Data
        {
            get { return _data; }

            set { _data = value; }
        }

        public CtaCteCustomerGlobal.Retorno GlobalData
        {
            get { return _globalData; }

            set { _globalData = value; }
        }

        //------------------------------------------------------------------------------------------
        private void ConfiguracionInicial()
        {
            cmbRazonSocial.DataSource = new CustomerManager().GetCompleteListofBillTo(false);
            cmbFantasia.DataSource = new CustomerManager().GetCompleteListofBillTo(false);
            rbL1L2.Checked = true;

            ckVerFacturacion.Checked = true;
            ckVerCobranza.Checked = true;
            ckVerAjuste.Checked = true;
            ckVerNC.Checked = true;
            ckVerND.Checked = true;
            ckVerSaldoPendiente.Checked = false;

            ckVerFacturacion.ForeColor = Color.ForestGreen;
            ckVerCobranza.ForeColor = Color.ForestGreen;
            ckVerAjuste.ForeColor = Color.ForestGreen;
            ckVerNC.ForeColor = Color.ForestGreen;
            ckVerND.ForeColor = Color.ForestGreen;
            ckVerSaldoPendiente.ForeColor = Color.Crimson;

            GetNewData();

            lctacteError.Visible = false;
            lctacteOK.Visible = false;

            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            txtIdCliente.Text = null;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCC1_Load(object sender, EventArgs e)
        {
            ConfiguracionInicial();
            ApplyFilters();

            GlobalData = new CtaCteCustomerGlobal().GetGlobalData();

            if (GlobalData.HayDiferenciaSaldos)
            {
                //lctacteError.Visible = true;
                MessageBox.Show(@"Hay Cuentas Corrientes que no se encuentran en estado correcto!",
                    @"Error en Cuenta Corriente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // lctacteOK.Visible = true;
            }
        }
        private void GetNewData()
        {
            int idc = 0;
            if (cmbRazonSocial.SelectedValue != null)
                idc = Convert.ToInt32(cmbRazonSocial.SelectedValue);

            Data = new Cc1Manager().GetCc1Data(idc);
        }
        private void ApplyFilters()
        {
            var lista = Data;

            if (!ckVerSaldoPendiente.Checked)
            {
                lista = lista.Where(c => c.SaldoPendiente != 0).ToList();
            }

            if (rbL1.Checked)
            {
                lista = lista.Where(c => c.LX == "L1").ToList();
            }

            if (rbL2.Checked)
            {
                lista = lista.Where(c => c.LX == "L2").ToList();
            }

            if (!ckVerFacturacion.Checked)
            {
                lista = lista.Where(c => c.Td != "FA").ToList();
                lista = lista.Where(c => c.Td != "R2").ToList();
            }

            if (!ckVerCobranza.Checked)
            {
                lista = lista.Where(c => c.Td != "CO").ToList();
            }

            if (!ckVerNC.Checked)
            {
                lista = lista.Where(c => c.Td != "NC").ToList();
            }

            if (!ckVerND.Checked)
            {
                lista = lista.Where(c => c.Td != "ND").ToList();
            }

            if (!ckVerAjuste.Checked)
            {
                lista = lista.Where(c => c.Td != "AJ").ToList();
                lista = lista.Where(c => c.Td != "NA").ToList();
            }

            dgvDataCliente.DataSource = lista;

            for (var a = 0; a < dgvDataCliente.Rows.Count; a++)
            {
                if ((string)dgvDataCliente.Rows[a].Cells[4].Value == "CO")
                {
                    dgvDataCliente.Rows[a].Cells[4].Style.BackColor = Color.LightGreen;
                }

                if ((string)dgvDataCliente.Rows[a].Cells[4].Value == "FA" ||
                    (string)dgvDataCliente.Rows[a].Cells[4].Value == "R2")
                {
                    dgvDataCliente.Rows[a].Cells[4].Style.BackColor = Color.Plum;
                }

                if ((string)dgvDataCliente.Rows[a].Cells[4].Value == "NC" ||
                    (string)dgvDataCliente.Rows[a].Cells[4].Value == "ND" ||
                    (string)dgvDataCliente.Rows[a].Cells[4].Value == "AJ")
                {
                    dgvDataCliente.Rows[a].Cells[4].Style.BackColor = Color.IndianRed;
                }

                if ((decimal)dgvDataCliente.Rows[a].Cells[8].Value == 0)
                {
                    dgvDataCliente.Rows[a].Cells[8].Style.BackColor = Color.Gainsboro;
                }
                else
                {
                    if ((decimal)dgvDataCliente.Rows[a].Cells[7].Value !=
                        (decimal)dgvDataCliente.Rows[a].Cells[8].Value)
                    {
                        dgvDataCliente.Rows[a].Cells[8].Style.BackColor = Color.MediumTurquoise;
                    }
                }
            }
        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbFantasia.SelectedIndex==-1)
            //    return;

            if (cmbFantasia.SelectedValue == null)
            {
                cmbFantasia.SelectedIndex = -1;
                cmbRazonSocial.SelectedIndex = -1;
                txtIdCliente.Text = null;
                return;
            }

            cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
            txtIdCliente.Text = cmbFantasia.SelectedValue.ToString();
            GetNewData();
            ApplyFilters();
            MapSaldosCustomer();
            MapCustomerData();
        }
        private void MapCustomerData()
        {
            if (string.IsNullOrEmpty(txtIdCliente.Text))
                return;

            var cli = new CustomerManager().GetCustomerBillToData(Convert.ToInt32(txtIdCliente.Text));
            ckBlockDespacho.Checked = cli.BLK_DELIVERY;
            ckInactivo.Checked = !cli.ACTIVO;
            ckblockPedido.Checked = cli.BLK_PEDIDO;
            txtZtermL1.Text = cli.ZTERML1;
            txtZtermL2.Text = cli.ZTERML2;
            txtLimiteCredito.Text = @"$" + cli.Limite_credito.ToString();
        }
        private void MapSaldosCustomer()
        {
            var cta = new CtaCteCustomerCc1(Convert.ToInt32(txtIdCliente.Text)).GetData();
            txtSaldoL1_201.Text = cta.SaldoL1_201.ToString("C2");
            txtSaldoL2_201.Text = cta.SaldoL2_201.ToString("C2");
            txtSaldoL1_202.Text = cta.SaldoL1_202.ToString("C2");
            txtSaldoL2_202.Text = cta.SaldoL2_202.ToString("C2");
            txtSaldoL1_207.Text = cta.ImporteL1_207.ToString("C2");
            txtSaldoL2_207.Text = cta.ImporteL2_207.ToString("C2");
            txtSaldoL1_208.Text = cta.SinImputarL1.ToString("C2");
            txtSaldoL2_208.Text = cta.SinImputarL2.ToString("C2");

            txtL1Dif201202.Text = (cta.SaldoL1_201 - cta.SaldoL1_202).ToString("C2");
            txtL2Dif201202.Text = (cta.SaldoL2_201 - cta.SaldoL2_202).ToString("C2");
            txtL1Dif201207.Text = (cta.SaldoL1_201 - cta.ImporteL1_207 + cta.SinImputarL1).ToString("C2");
            txtL2Dif201207.Text = (cta.SaldoL2_201 - cta.ImporteL2_207 + cta.SinImputarL2).ToString("C2");


            txtSaldoL1Ok.Text = txtSaldoL1_201.Text;
            txtSaldoL2Ok.Text = txtSaldoL2_201.Text;
            txtSaldoTotalOk.Text = (cta.SaldoL1_201 + cta.SaldoL2_201).ToString("C2");

            if (cta.HayDiferenciaSaldos)
            {
                lctacteOK.Visible = false;
                lctacteError.Visible = true;
            }
            else
            {
                lctacteOK.Visible = true;
                lctacteError.Visible = false;
            }
        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var x = cmbRazonSocial.SelectedIndex;
            //if (cmbRazonSocial.SelectedIndex ==-1)
            //    return;


            if (cmbRazonSocial.SelectedValue == null)
                return;

            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
            //txtIdCliente.Text = cmbRazonSocial.SelectedValue.ToString();
        }
        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
        }
        private void ckVerFacturacion_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            var ck = (CheckBox)sender;
            ck.ForeColor = ck.Checked ? Color.ForestGreen : Color.Crimson;
        }
        private void ckVerSaldoPendiente_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            var ck = (CheckBox)sender;
            ck.ForeColor = ck.Checked ? Color.ForestGreen : Color.Crimson;
        }
        private void rbL1L2_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void txtMaxRecords_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void btnGlobal_Click(object sender, EventArgs e)
        {
            var f = new frmCC1Global(GlobalData);
            f.Show();
        }

        private void dgvDataCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvDataCliente[e.ColumnIndex, e.RowIndex].Value.ToString();
                var idCtaCte =
                    Convert.ToInt32(
                        dgvDataCliente[dgvDataCliente.Columns[idCtaCteDataGridViewTextBoxColumn1.Name].Index,
                            e.RowIndex].Value);
                int idFactura400 = 0;
                var data400 = dgvDataCliente[dgvDataCliente.Columns[idFactura400DataGridViewTextBoxColumn.Name].Index,
                    e.RowIndex].Value;
                if (data400 != null)
                    idFactura400 = Convert.ToInt32(data400);

                switch (cellValue)
                {
                    case "VER":

                        var tipoDoc = dgvDataCliente[4, e.RowIndex].Value.ToString();
                        switch (tipoDoc)
                        {
                            case "CO":
                                var idCobranza = new CobranzaSearch().GetIdCobranzaFromIdCtaCte(idCtaCte);
                                if (idCobranza == 0)
                                {
                                    MessageBox.Show(@"Esta cobranza no se puede mostrasr * modelo anterior *",
                                        @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }

                                var f = new FrmDetalleCobranzaIngresada(idCobranza);
                                f.Show();
                                break;
                            case "FA":
                                if (idFactura400 == 0)
                                {
                                    MessageBox.Show(@"Este documento no se puede mostrar * Modelo Anterior *",
                                        @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }

                                var f1 = new FrmFI50DetalleDocumentoFI(idFactura400);
                                f1.Show();
                                break;
                            case "AJ":
                                break;
                            case "NC":
                                if (idFactura400 == 0)
                                {
                                    MessageBox.Show(@"Este documento no se puede mostrar * Modelo Anterior *",
                                        @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }

                                var f2 = new FrmFI50DetalleDocumentoFI(idFactura400);
                                f2.Show();
                                break;
                            case "ND":
                                if (idFactura400 == 0)
                                {
                                    MessageBox.Show(@"Este documento no se puede mostrar * Modelo Anterior *",
                                        @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }

                                var f3 = new FrmFI50DetalleDocumentoFI(idFactura400);
                                f3.Show();
                                break;
                        }

                        //using (var f0 = new FrmMm0Accion(1, Convert.ToInt32(dgvStockList[0, e.RowIndex].Value)))
                        //{
                        //    DialogResult dr = f0.ShowDialog();
                        //    if (dr == DialogResult.OK)
                        //    {
                        //        _completeMaterialList = new CqStockDataManagement().CompletaEstructuraStockCompleto();
                        //        dgvStockList.DataSource = new MySortableBindingList<CqStockStructure>(_completeMaterialList);
                        //        ApplyFilters();
                        //    }
                        //}
                        break;
                }
            }
        }
        private void cmbFantasia_TextUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFantasia.Text))
            {
                cmbRazonSocial.SelectedIndex = -1;
                txtIdCliente.Text = null;
                GetNewData();
                ApplyFilters();
            }
        }
        private void cmbRazonSocial_TextUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbRazonSocial.Text))
            {
                cmbFantasia.SelectedIndex = -1;
                txtIdCliente.Text = null;
                GetNewData();
                ApplyFilters();
            }
        }
    }
}
