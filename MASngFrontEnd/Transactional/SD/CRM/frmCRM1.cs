using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using TecserEF.Entity.DataStructure.SD_CRM;

namespace MASngFE.Transactional.SD.CRM
{
    public partial class FrmCRM1 : Form
    {
        public FrmCRM1(int modo = 1)
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------
        private int _modo;
        private List<CRMSalesOrder> _completeList = new List<CRMSalesOrder>();
        private List<CRMSalesOrder> _filteredData = new List<CRMSalesOrder>();
        //----------------------------------------------------------------------------------------

        private void frmCRM1_Load(object sender, EventArgs e)
        {
            ConfiguracionInicial();
            DetectaModo();
            AccionSegunModo();
        }
        private void ConfiguracionInicial()
        {
            rbFecha.Checked = true;
            dtpFechaDesde.Value = DateTime.Today.AddYears(-1);
            cmbCodigoVenta.Enabled = false;
            cmbFantasia.Enabled = false;
            cmbRazonSocial.Enabled = false;

            ckProceso.Checked = true;
            ckCerrada.Checked = true;
            ckSinProcesar.Checked = true;
            ckCancelada.Checked = true;

            cmbCodigoVenta.DataSource = new MaterialMasterManager().GetCompleteListofAka(false);
            cmbFantasia.DataSource = new CustomerManager().GetCompleteListofBillTo(false);
            cmbRazonSocial.DataSource = new CustomerManager().GetCompleteListofBillTo(false);

            cmbCodigoVenta.SelectedIndex = -1;

            //GetNewData();
            // FilterData();
        }
        private void AccionSegunModo()
        {
            dgvCRMLista1Precio.Visible = false;
            dgvCrmListaCliente.Visible = false;
            dgvCrmListaProducto.Visible = false;
            switch (_modo)
            {
                case 1:
                    dgvCRMLista1Precio.Visible = true;
                    break;
                case 2:
                    dgvCrmListaProducto.Visible = true;
                    break;
                case 3:
                    dgvCrmListaCliente.Visible = true;
                    break;
            }
        }
        private void GetNewData()
        {
            switch (_modo)
            {
                case 1:
                    //fecha
                    _completeList = new CRMSalesOrderDataMng().GetData(dtpFechaDesde.Value, dtpFechaHasta.Value, GlobalApp.CnnApp,
                        Convert.ToInt32(txtTop.Text));
                    break;

                case 2:
                    //material
                    if (cmbCodigoVenta.SelectedValue == null)
                    {
                        _completeList.Clear();
                        _completeList = new CRMSalesOrderDataMng().GetData(dtpFechaDesde.Value, dtpFechaHasta.Value,
                            GlobalApp.CnnApp,
                            Convert.ToInt32(txtTop.Text), cmbCodigoVenta.Text);
                    }
                    else
                    {
                        _completeList = new CRMSalesOrderDataMng().GetData(dtpFechaDesde.Value, dtpFechaHasta.Value, GlobalApp.CnnApp,
                            Convert.ToInt32(txtTop.Text), cmbCodigoVenta.SelectedValue.ToString());
                    }
                    break;

                case 3:
                    //cliente
                    if (cmbRazonSocial.SelectedValue == null)
                    {
                        if (cmbCodigoVenta.SelectedValue != null)
                        {
                            MessageBox.Show(@"Debe Seleccionar un Cliente para continuar", @"Error de Datos",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _completeList.Clear();
                        return;
                    }

                    var idCliente6 = cmbRazonSocial.SelectedValue == null ? 0 : Convert.ToInt32(cmbRazonSocial.SelectedValue);
                    var producto = cmbCodigoVenta.SelectedValue == null ? null : cmbCodigoVenta.SelectedValue.ToString();

                    _completeList = new CRMSalesOrderDataMng().GetData(dtpFechaDesde.Value, dtpFechaHasta.Value, GlobalApp.CnnApp,
                        Convert.ToInt32(txtTop.Text), producto, idCliente6);

                    break;
            }

        }
        private void FilterData()
        {
            _filteredData = _completeList;
            if (_completeList.Count != 0)
            {
                _filteredData = _completeList;
                if (ckCancelada.Checked == false)
                {
                    _filteredData = _filteredData.Where(c => c.EstadoSO.ToUpper() != "CANCELADA").ToList();
                }

                if (ckCerrada.Checked == false)
                {
                    _filteredData = _filteredData.Where(c => c.EstadoSO.ToUpper() != "CERRADA").ToList();
                }

                if (ckProceso.Checked == false)
                {
                    _filteredData = _filteredData.Where(c => c.EstadoSO.ToUpper() != "PROCESO").ToList();
                }

                if (ckSinProcesar.Checked == false)
                {
                    _filteredData = _filteredData.Where(c => c.EstadoSO.ToUpper() != "EMITIDA").ToList();
                    _filteredData = _filteredData.Where(c => c.EstadoSO.ToUpper() != "INICIADA").ToList();
                }
            }

            txtCantidadItems.Text = _filteredData.Count.ToString();
            txtKgPedidos.Text = _filteredData.Sum(c => c.KgPedido).ToString("N2");
            txtKgPendientes.Text = _filteredData.Sum(c => c.KgRestante).ToString("N2");

            dgvCRMLista1Precio.DataSource = null;
            dgvCrmListaCliente.DataSource = null;
            dgvCrmListaProducto.DataSource = null;

            switch (_modo)
            {
                case 1:
                    //fecha
                    dgvCRMLista1Precio.DataSource = new MySortableBindingList<CRMSalesOrder>(_filteredData);
                    break;
                case 2:
                    //material
                    dgvCrmListaProducto.DataSource = new MySortableBindingList<CRMSalesOrder>(_filteredData);
                    break;
                case 3:
                    //Cliente
                    dgvCrmListaCliente.DataSource = new MySortableBindingList<CRMSalesOrder>(_filteredData);
                    break;
            }
        }
        private void rbCliente_CheckedChanged(object sender, EventArgs e)
        {
            DetectaModo();
        }
        private void DetectaModo()
        {
            cmbCodigoVenta.Enabled = false;
            cmbFantasia.Enabled = false;
            cmbRazonSocial.Enabled = false;
            cmbCodigoVenta.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            cmbRazonSocial.SelectedIndex = -1;

            if (rbCliente.Checked)
            {
                rbCliente.BackColor = Color.DodgerBlue;
                rbMaterial.BackColor = Color.LightSteelBlue;
                rbFecha.BackColor = Color.LightSteelBlue;
                _modo = 3;

                cmbFantasia.Enabled = true;
                cmbRazonSocial.Enabled = true;
                cmbCodigoVenta.Enabled = true;
            }
            else
            {
                if (rbMaterial.Checked)
                {
                    rbCliente.BackColor = Color.LightSteelBlue;
                    rbMaterial.BackColor = Color.DodgerBlue;
                    rbFecha.BackColor = Color.LightSteelBlue;
                    _modo = 2;

                    cmbCodigoVenta.Enabled = true;

                }
                else
                {
                    rbCliente.BackColor = Color.LightSteelBlue;
                    rbMaterial.BackColor = Color.LightSteelBlue;
                    rbFecha.BackColor = Color.DodgerBlue;
                    _modo = 1;
                }
            }
            AccionSegunModo();
            GetNewData();
            FilterData();
        }
        private void ckCancelada_CheckedChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFantasia.SelectedValue == null)
                return;

            cmbRazonSocial.SelectedValue = cmbFantasia.SelectedValue;
            GetNewData();
            FilterData();

        }
        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedValue == null)
                return;

            cmbFantasia.SelectedValue = cmbRazonSocial.SelectedValue;
        }
        private void cmbPrimario_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNewData();
            FilterData();
        }

        private void cmbCodigoVenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (cmbCodigoVenta.Text.Length >= 3)
            {
                GetNewData();
                FilterData();
            }
            else
            {
                if (string.IsNullOrEmpty(cmbCodigoVenta.Text))
                {
                    GetNewData();
                    FilterData();
                }
            }
        }
    }
}
