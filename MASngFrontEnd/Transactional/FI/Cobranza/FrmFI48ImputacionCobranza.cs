using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.Cobranza;
using Tecser.Business.Transactional.FI.CtaCte;
using TSControls;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmFI48ImputacionCobranza : Form
    {
        public FrmFI48ImputacionCobranza()
        {
            _idCliente = null;
            InitializeComponent();
        }

        private readonly ImputacionAuxiliarGetData _impuD = new ImputacionAuxiliarGetData();
        private CobranzaImputacionManagerNew _impu;
        private int? _idCliente;
        private bool _modoClienteSeleccionado = false;
        private int? _idCobranzaSeleccionada;
        private int? _idCtaCte207Seleccion;
        private int _idSplitSeleccion;
        private bool _dgv1Leave;
        private bool _dgv2Leave;


        private void FrmFI48ImputacionCobranza_Load(object sender, EventArgs e)
        {
            this.dgvCobranzas.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);
            dgvCobranzas.DataSource = _impuD.GetListaCobranzasSinImputar();
            dgvCobranzas.ClearSelection();
            this.dgvCobranzas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);
            t006Bs.DataSource = new CustomerManager().GetCompleteListofBillTo();
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            ResetInfo();
            ResetInfoImputacion(); //Panel 3
        }


        private void rcheckSoloSaldosPendientes_CheckBoxCheckChanged(object sender, EventArgs e)
        {

        }

        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmbRazonSocial_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = (ComboBox)sender;
            if (cmb.SelectedValue == null)
            {
                _idCliente = null;
                txtIdCliente.Text = null;
                _modoClienteSeleccionado = false;
                //blanquear datos y resetear _impuD;
                return;
            }

            _idCliente = Convert.ToInt32(cmb.SelectedValue);
            _modoClienteSeleccionado = true;
            cmodoSeleccionCliente.Set = CIconos.Tilde;
            //
            this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.dgvCobranzas.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);
            //
            cmbFantasia.SelectedValue = cmb.SelectedValue;
            cmbRazonSocial.SelectedValue = cmb.SelectedValue;
            txtIdCliente.Text = _idCliente.ToString();
            _impuD.SetCliente(_idCliente);
            _impuD.SetLx(null);
            dgvCobranzas.DataSource = _impuD.GetListaCobranzasSinImputar();
            dgvDocumentosAImputar.DataSource = _impuD.GetListaDocumentosSinImputar();
            var cli = new CustomerManager().GetCustomerBillToData(_idCliente.Value);
            var ctacte = new CtaCteCustomer(_idCliente.Value);
            txtDeudaL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
            txtDeudaL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
            //GetPanel1Data();
            txtCreditoL1.Text = _impuD.CreditoSinImputarL1.ToString("C2");
            txtCreditoL2.Text = _impuD.CreditoSinImputarL2.ToString("C2");
            txtSaldoPendienteImputacion.Text = _impuD.FacturaSinImputarSeleccion.ToString("C2");
            txtCreditoL1.BackColor = Color.LightSteelBlue;
            txtCreditoL2.BackColor = Color.LightSteelBlue;
            dgvDocumentosAImputar.ClearSelection();
            dgvCobranzas.ClearSelection();
            //refrescar datos p1 y stats
            ResetInfo();
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.dgvCobranzas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);
        }

        private void dgvCobranzas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_dgv1Leave == false)
            {
                _dgv1Leave = true;
                return;
            }

            var dgv = (DataGridView)sender;
            this.dgvCobranzas.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);
            //reset de iconos 


            //Seleccionar una cobranza
            if (e.RowIndex >= 0)
            {
                var z = Convert.ToInt32(dgv[__1IdCob.Name, e.RowIndex].Value);
                _idCobranzaSeleccionada = Convert.ToInt32(dgv[__1IdCob.Name, e.RowIndex].Value);
                var dataCob = _impuD.SetSeleccionRegistro208(_idCobranzaSeleccionada);
                if (_modoClienteSeleccionado == false)
                {
                    cmodoSeleccionCliente.Set = CIconos.Rojo;
                    this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
                    this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
                    _idCliente = dataCob.CLIENTE.Value;
                    cmbFantasia.SelectedValue = _idCliente;
                    cmbRazonSocial.SelectedValue = _idCliente;
                    txtIdCliente.Text = _idCliente.ToString();
                    ResetInfo();
                    _impuD.SetCliente(_idCliente);

                    var cli = new CustomerManager().GetCustomerBillToData(_idCliente.Value);
                    var ctacte = new CtaCteCustomer(_idCliente.Value);
                    txtDeudaL1.Text = ctacte.GetResultadoCtaCte("L1").SaldoResumen.ToString("C2");
                    txtDeudaL2.Text = ctacte.GetResultadoCtaCte("L2").SaldoResumen.ToString("C2");
                    txtCreditoL1.Text = _impuD.CreditoSinImputarL1.ToString("C2");
                    txtCreditoL2.Text = _impuD.CreditoSinImputarL2.ToString("C2");
                    cmbRazonSocial.Text = cli.cli_rsocial;
                    //refrescar datos p1 y stats
                    this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
                    this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);

                }
                else
                {
                    //modo cobranza por cliente 
                    cmodoSeleccionCliente.Set = CIconos.Verde;
                }

                this.dgvDocumentosAImputar.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosAImputar_CellEnter);
                dgvDocumentosAImputar.DataSource = _impuD.GetListaDocumentosSinImputar();
                dgvDocumentosAImputar.ClearSelection();
                _idCtaCte207Seleccion = null;
                this.dgvDocumentosAImputar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosAImputar_CellEnter);
                txtSaldoPendienteImputacion.Text = _impuD.FacturaSinImputarSeleccion.ToString("C2");
                if (_impuD._lx == ImputacionAuxiliarGetData.LX.L1)
                {
                    txtCreditoL1.BackColor = Color.LightGreen;
                    txtCreditoL2.BackColor = Color.DarkGray;
                }
                else
                {
                    if (_impuD._lx == ImputacionAuxiliarGetData.LX.L2)
                    {
                        txtCreditoL1.BackColor = Color.DarkGray;
                        txtCreditoL2.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        txtCreditoL1.BackColor = Color.DarkGray;
                        txtCreditoL2.BackColor = Color.DarkGray;
                    }
                }
                this.cImporteMaximoImputar.Validating -= new System.ComponentModel.CancelEventHandler(this.cImporteMaximoImputar_Validating);
                cImporteMaximoImputar.SetValue = dataCob.MONTO.Value; //seleccion de maximo posible
                cImporteSobrante.SetValue = 0;
                this.cImporteMaximoImputar.Validating += new System.ComponentModel.CancelEventHandler(this.cImporteMaximoImputar_Validating);
            }
            else
            {
                _idCobranzaSeleccionada = null;
                _impuD.SetSeleccionRegistro208(null);
                _impuD.SetCliente(null);
                ResetInfo();
            }
            this.dgvCobranzas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);
        }

        private void GetPanel1Data()
        {
            dgvCobranzas.DataSource = _impuD.GetListaCobranzasSinImputar();
        }

        private void dgvDocumentosAImputar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Seleccion de Cobranza - Panel 1
            if (_dgv2Leave == false)
            {
                _dgv2Leave = true;
                ResetInfoImputacion();
                return;
            }
            var dgv = (DataGridView)sender;
            this.dgvDocumentosAImputar.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosAImputar_CellEnter);
            if (e.RowIndex >= 0)
            {
                _idCtaCte207Seleccion = Convert.ToInt32(dgv[__2Idctacte.Name, e.RowIndex].Value);
                _idSplitSeleccion = Convert.ToInt32(dgv[__2Split.Name, e.RowIndex].Value);
                decimal montoPendiente = Convert.ToDecimal(dgv[__2MontoPendiente.Name, e.RowIndex].Value);

                this.cImporteMaximoImputar.Validating -= new System.ComponentModel.CancelEventHandler(this.cImporteMaximoImputar_Validating);
                if (_impuD.SaldoImputarMax > montoPendiente)
                {
                    //modifica el importe a Imputar al Maximo posible -- deshabilita el chequeo
                    cImporteMaximoImputar.SetValue = montoPendiente;
                    cImporteSobrante.SetValue = _impuD.SaldoImputarMax - montoPendiente;
                }
                else
                {
                    cImporteMaximoImputar.SetValue = _impuD.SaldoImputarMax;
                    cImporteSobrante.SetValue = 0;
                }
                this.cImporteMaximoImputar.Validating += new System.ComponentModel.CancelEventHandler(this.cImporteMaximoImputar_Validating);
                _impu = new CobranzaImputacionManagerNew(_impuD.idCobSeleccion.Value, _idCtaCte207Seleccion.Value, _idSplitSeleccion, cImporteMaximoImputar.GetValueDecimal);
                MapIconosAfterSelectFactura();  //Mapea Iconos 

                if (_impu.OK207_400)
                {
                    if (string.IsNullOrEmpty(_impu.DataFacturaSeleccionada.NumeroDoc))
                    {
                        txtNumeroFacturaSeleccionada.Text =
                            _impu.DataFacturaSeleccionada.PV_AFIP + @"-" + _impu.DataFacturaSeleccionada.ND_AFIP;
                    }
                    else
                    {
                        txtNumeroFacturaSeleccionada.Text = _impu.DataFacturaSeleccionada.NumeroDoc;
                    }

                    txtFechaFacturaSeleccionada.Text = _impu.DataFacturaSeleccionada.FECHA.ToString("d");
                    cImporteTotalFacturaSeleccionada.SetValue = _impu.DataFacturaSeleccionada.TotalFacturaN;
                    cImportePendienteImputacionSeleccionada.SetValue = _impu.ImportePendienteImputar;
                    cImporteIIBBSeleccionandaPendiente.SetValue = _impu.ImportePendienteIibb;
                }
                else
                {
                    txtNumeroFacturaSeleccionada.Text = null;
                    txtFechaFacturaSeleccionada.Text = null;
                    cImporteTotalFacturaSeleccionada.SetValue = 0;
                    cImportePendienteImputacionSeleccionada.SetValue = 0;
                    cImporteIIBBSeleccionandaPendiente.SetValue = 0;
                }
            }
            else
            {
                //row <0
                btnImputar.Enabled = false;
            }
            this.dgvDocumentosAImputar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosAImputar_CellEnter);
        }
        private void cImporteMaximoImputar_Validating(object sender, CancelEventArgs e)
        {
            var valorNew = cImporteMaximoImputar.GetValueDecimal;
            if (valorNew == 0 && _idCobranzaSeleccionada == null)
            {
                cImporteMaximoImputar.SetValue = -_impuD.SaldoImputarMax * -1;
                cImporteSobrante.SetValue = 0;
                cIconOk208.Set = CIconos.Equis;
                e.Cancel = false;
                return;
            }

            if (_idCtaCte207Seleccion == null)
            {
                MessageBox.Show(@"Para modificar el valor a Imputar debe primero seleccionar una factura",
                    @"Imputacion de Facturas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cImporteMaximoImputar.SetValue = -_impuD.SaldoImputarMax * -1;
                cImporteSobrante.SetValue = 0;
                cIconOk208.Set = CIconos.Equis;
                return;
            }

            if (valorNew <= 0)
            {
                MessageBox.Show(@"El Valor a Imputar debe ser Mayor a Cero y Menor al Importe de la Cobranza Seleccionada",
                    @"Error en Seleccion de Valor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
            if (valorNew > _impuD.SaldoImputarMax)
            {
                MessageBox.Show(@"El Valor no puede superar el importe de la cobranza seleccionada",
                    @"Error en Seleccion de Valor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }

            if (valorNew < cImporteIIBBSeleccionandaPendiente.GetValueDecimal)
            {
                MessageBox.Show(@"El Valor no puede ser inferior al Saldo de IIBB",
                    @"Error en Seleccion de Valor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                cIconOkImpuIIBB.Set = CIconos.Rojo;
                return;
            }
            cImporteSobrante.SetValue = _impuD.SaldoImputarMax - valorNew;
            cIconOk208.Set = CIconos.Corazon;
            cIconOkImpuIIBB.Set = CIconos.Verde;
        }
        private void btnImputar_Click(object sender, EventArgs e)
        {
            _impu.Imputar();
            if (_impu.ResultadoImputacion)
            {
                c3IconResultadoImputacion.Set = CIconos.Tilde;
                btnImputar.Enabled = false;
                c3IconSeImputoPercepcion.Set = _impu.OKImpuIIBB ? CIconos.Verde : CIconos.Rojo;
                c3DiasPPValorCobranza.SetValue = _impu.DiasCobranza;
                c3DiasPPCobranzaFactura.SetValue = _impu.DiasImputacion;
                c3ImporteImputado.SetValue = _impu.ImporteAImputar;
            }
            else
            {
                c3IconResultadoImputacion.Set = CIconos.ExclamacionRed;
                btnImputar.Enabled = false;
                c3IconSeImputoPercepcion.Set = CIconos.Rojo;
                c3DiasPPValorCobranza.SetValue = 0;
                c3DiasPPCobranzaFactura.SetValue = 0;
                c3ImporteImputado.SetValue = 0;
            }
            _impuD.ClearSelecciones();
            ResetInfo();
            RefrescarDataAfterImputacion();
        }
        private void cImporteMaximoImputar_Validated(object sender, EventArgs e)
        {
            if (_idCobranzaSeleccionada == null || _idCtaCte207Seleccion == null)
            {
                MessageBox.Show("");
                ResetInfo();
                return;
            }
            _impu = new CobranzaImputacionManagerNew(_idCobranzaSeleccionada.Value, _idCtaCte207Seleccion.Value, _idSplitSeleccion, cImporteMaximoImputar.GetValueDecimal);
            MapIconosAfterSelectFactura();
        }
        private void ResetInfoImputacion()
        {
            c3IconResultadoImputacion.Set = CIconos.Amarillo;
            c3IconSeImputoPercepcion.Set = CIconos.Amarillo;
            c3DiasPPCobranzaFactura.SetValue = 0;
            c3DiasPPValorCobranza.SetValue = 0;
            c3ImporteImputado.SetValue = 0;
        }
        private void ResetInfo()
        {
            cIconOk208.Set = CIconos.Amarillo;

            //
            cIconOkImporteSplits.Set = CIconos.Amarillo;
            cIconOkSumaImputadoNoImputado.Set = CIconos.Amarillo;
            cIconOk207.Set = CIconos.Amarillo;
            cIconOk207_400.Set = CIconos.Amarillo;
            cIconOkImpuIIBB.Set = CIconos.Amarillo;
            cIconErrorDataIibbNoRegistrada.Set = CIconos.Amarillo;
            cIconoOkImpuFinal.Set = CIconos.Amarillo;
            //
            txtNumeroFacturaSeleccionada.Text = null;
            txtFechaFacturaSeleccionada.Text = null;
            cImporteTotalFacturaSeleccionada.SetValue = 0;
            cImportePendienteImputacionSeleccionada.SetValue = 0;
            cImporteIIBBSeleccionandaPendiente.SetValue = 0;
            //
            btnImputar.Enabled = false;
        }

        private void MapIconosAfterSelectFactura()
        {
            cIconOk208.Set = _impu.OK208 ? CIconos.Verde : CIconos.TrianguloNaranja;
            cIconOkImporteSplits.Set = _impu.OKImporteSplits ? CIconos.Verde : CIconos.TrianguloNaranja;
            cIconOkSumaImputadoNoImputado.Set = _impu.OKSumaImputadoNoImputado ? CIconos.Verde : CIconos.TrianguloNaranja;
            cIconOk207.Set = _impu.OK207 ? CIconos.Verde : CIconos.TrianguloNaranja;
            cIconOk207_400.Set = _impu.OK207_400 ? CIconos.Verde : CIconos.TrianguloNaranja;
            //
            cIconOkImpuIIBB.Set = _impu.OKImpuIIBB ? CIconos.Verde : CIconos.TrianguloNaranja;
            cIconErrorDataIibbNoRegistrada.Set = !_impu.ErrorDataIIBBnoRegistrada ? CIconos.Verde : CIconos.TrianguloNaranja;
            if (_impu.ErrorDataIIBBnoRegistrada)
            {
                MessageBox.Show(
                    @"Atencion la informacion de IIBB en T402 no se encuentra. Notifique a Andres que esta factura no tiene datos de IIBB",
                    @"Error en Registro de T402", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            cIconoOkImpuFinal.Set = _impu.OKImpuFinal ? CIconos.Verde : CIconos.TrianguloNaranja;
            btnImputar.Enabled = _impu.OKImpuFinal;
        }



        private void MapIconos()
        {
            cIconOk208.Set = CIconos.TrianguloNaranja;
            cIconOkImpuIIBB.Set = CIconos.TrianguloNaranja;
            cIconOkImporteSplits.Set = CIconos.TrianguloNaranja;
            cIconoOkImpuFinal.Set = CIconos.TrianguloNaranja;
        }

        private void RefrescarDataAfterImputacion()
        {
            this.dgvCobranzas.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);
            this.dgvDocumentosAImputar.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosAImputar_CellEnter);
            _idCtaCte207Seleccion = null;
            _idCobranzaSeleccionada = null;
            dgvDocumentosAImputar.DataSource = null;
            txtSaldoPendienteImputacion.Text = 0.ToString("C2");
            if (_modoClienteSeleccionado)
            {
                //Cliente Seleccionado
                _impuD.SetCliente(_idCliente, false);
                _impuD.SetLx(null, true);
                dgvCobranzas.DataSource = _impuD.GetListaCobranzasSinImputar();
                dgvCobranzas.ClearSelection();
                txtCreditoL1.Text = _impuD.CreditoSinImputarL1.ToString("C2");
                txtCreditoL2.Text = _impuD.CreditoSinImputarL2.ToString("C2");
                txtCreditoL1.BackColor = Color.LightSteelBlue;
                txtCreditoL2.BackColor = Color.LightSteelBlue;
            }
            else
            {
                //obtiene cobranzas de nuevo
                _impuD.SetCliente(null, false);
                _impuD.SetLx(null, true);
                dgvCobranzas.DataSource = _impuD.GetListaCobranzasSinImputar();
                dgvCobranzas.ClearSelection();
                txtCreditoL1.Text = 0.ToString("C2");
                txtCreditoL2.Text = 0.ToString("C2");
                txtCreditoL1.BackColor = Color.LightSteelBlue;
                txtCreditoL2.BackColor = Color.LightSteelBlue;
                txtDeudaL1.Text = 0.ToString("C2");
                txtDeudaL2.Text = 0.ToString("C2");

            }
            //Reset Seleccion Factura
            txtNumeroFacturaSeleccionada.Text = null;
            txtFechaFacturaSeleccionada.Text = null;
            cImporteTotalFacturaSeleccionada.SetValue = 0;
            cImportePendienteImputacionSeleccionada.SetValue = 0;
            cImporteIIBBSeleccionandaPendiente.SetValue = 0;
            cIconOk207_400.Set = CIconos.Amarillo;
            txtSaldoPendienteImputacion.Text = 0.ToString("C2");
            cImporteMaximoImputar.SetValue = 0;
            cImporteSobrante.SetValue = 0;
            //
            this.dgvCobranzas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCobranzas_CellEnter);
            this.dgvDocumentosAImputar.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocumentosAImputar_CellEnter);
        }

        private void dgvCobranzas_Leave(object sender, EventArgs e)
        {
            _dgv1Leave = false;
        }
        private void dgvDocumentosAImputar_Leave(object sender, EventArgs e)
        {
            _dgv2Leave = false;
        }
    }
}
