using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MASngFE.MasterData.Customer_Master;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.ContaFromDocuments;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Customers;
using Tecser.Business.VBTools;
using TSControls;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.CustomerNCD
{

    public partial class FrmFI71AjustesFI : Form
    {

        private CustomerAjustes _aj1;
        private CustomerAjustes _aj2;
        private bool _existeDocumentoSecundario = false; //Defualt NO
        private ModoEjecucion _modoAfip;
        private int _idCliente;
        private CustomerAjustes.MotivoAjustes _motivoAjuste;
        private Lx _lx;

        private ManageDocumentType.TipoDocumento
            _tipoDocumento = ManageDocumentType.TipoDocumento.NoDefinido; //ajuste contable?

        private ManageDocumentType.TipoDocumento _tipoDocumento2 = ManageDocumentType.TipoDocumento.NoDefinido;
        private DocumentFIStatusManager.StatusHeader _statusDocumento = DocumentFIStatusManager.StatusHeader.Pendiente;
        private DocumentFIStatusManager.StatusHeader _statusDocumento2 = DocumentFIStatusManager.StatusHeader.Pendiente;
        private int _idRetorno = -1; //ID de Retorno de la seleccion de documento
        private enum Lx
        {
            L1,
            L2,
            NoSeleccionado
        };
        
        public FrmFI71AjustesFI()
        {
            InitializeComponent();
        }

        private void FrmFI71AjustesFI_Load(object sender, EventArgs e)
        {
            MapCustomerData();
            _lx = Lx.NoSeleccionado;
            txtStatusDoc1.Text = _statusDocumento.ToString();
            rPanelContabilizacion.Enabled = false;
            rPanelRegistracion.Enabled = false;
            rbMainRibbon.ActiveTab = rTabCliente;
            cTc.SetValue = new ExchangeRateManager().GetExchangeRate(dtpFechaDocumento.Value);
        }

        private void MapCustomerData()
        {
            if (_idCliente == -1)
            {
                txtRazonSocial.Text = null;
                txtCuit.Text = null;
                cCuitOk.SetLights = CtlSemaforo.ColoresSemaforo.Rojo;
                txtIva.Text = @"Responsable Inscripto";
                txtProvincia.Text = null;
                txtVendedor.Text = null;
                return;
            }

            var c = new CustomerManager().GetCustomerBillToData(_idCliente);
            if (c != null)
            {
                txtRazonSocial.Text = c.cli_rsocial;
                txtCuit.Text = c.CUIT;

                var x = new CuitValidation().ValidarCuit(c.CUIT);
                cCuitOk.SetLights = x ? CtlSemaforo.ColoresSemaforo.Verde : CtlSemaforo.ColoresSemaforo.Rojo;
                txtIva.Text = @"Responsable Inscripto";
                txtProvincia.Text = c.Direfactu_Provincia;
                var c2 = c.T0007_CLI_ENTREGA.FirstOrDefault(d => d.Activo);
                if (c2 != null)
                {
                    txtVendedor.Text = c2.Vendedor;
                }
            }
        }

        #region BotonosRibbon

        private void rbtnL1_Click(object sender, EventArgs e)
        {
            if (_idCliente < 1)
            {
                MessageBox.Show(@"Debe Seleccionar el Cliente antes de Continuar", @"Seleecion Incompleta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _lx = Lx.L1;
            txtLx.Text = @"L1";
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add("Ajuste Contable");
            cmbTipoDocumento.SelectedItem = "Ajuste Contable";
            rPanelTipoLx.Text = @"TIPO L1";
        }

        private void rbtnL2_Click(object sender, EventArgs e)
        {
            if (_idCliente < 1)
            {
                MessageBox.Show(@"Debe Seleccionar el Cliente antes de Continuar", @"Seleecion Incompleta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _lx = Lx.L2;
            txtLx.Text = @"L2";
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add("Ajuste Contable");
            cmbTipoDocumento.SelectedItem = "Ajuste Contable";
            rPanelTipoLx.Text = @"TIPO L2";
        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lx == Lx.NoSeleccionado)
            {
                txtTdoc.Text = null;
                MessageBox.Show(@"Debe seleccionar el tipo de operacion", @"Falta Tipo LX", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (cmbTipoDocumento.SelectedIndex == -1)
            {
                txtTdoc.Text = null;
                return;
            }

            switch (cmbTipoDocumento.SelectedItem.ToString())
            {
                case "Ajuste Contable":
                    _tipoDocumento = ManageDocumentType.TipoDocumento.AjusteContable;
                    txtTdoc.Text = @"AJ";
                    break;
            }
        }

        private void rbtnSeleccionCliente_Click(object sender, EventArgs e)
        {
            if (_statusDocumento != DocumentFIStatusManager.StatusHeader.Pendiente)
            {
                MessageBox.Show(@"El Estado del documento ya no permite la modificacion del Cliente",
                    @"Error en Modificacion de Cliente");
                return;
            }

            using (var f0 = new FrmMdc01CustomerSearch(4, ""))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK || DialogResult == DialogResult.None)
                {
                    _idCliente = f0.ClienteSeleccionado;
                }
                else
                {
                    MessageBox.Show(@"Se ha cancelado la seleccion del cliente", @"Cliente No Seleccionado",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _idCliente = -1;
                }

                MapCustomerData();
            }
        }

        private void rbtDetalleCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Este boton aun no se encuentra activo", @"Funcion en Desarrollo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void rbtnRedondeo_Click(object sender, EventArgs e)
        {
            _motivoAjuste = CustomerAjustes.MotivoAjustes.RedondeoCuenta;
            RedirigeAccionDespuesPresionarBoton();
        }

        private void rbtnNoReclamable_Click(object sender, EventArgs e)
        {

        }

        private void rbtnIncobrables_Click(object sender, EventArgs e)
        {

        }

        private void rbtTraspasoClientes_Click(object sender, EventArgs e)
        {

        }

        private void rbtTraspasoTipos_Click(object sender, EventArgs e)
        {
            _motivoAjuste = CustomerAjustes.MotivoAjustes.TraspasoTipo;
            RedirigeAccionDespuesPresionarBoton();
        }

        private void rbtnRegistrar_Click(object sender, EventArgs e)
        {
            if (!OkRegistrar())
                return;

            rTabDocumento.Enabled = false;
            _aj1.Registrar(txtMotivoGeneralDocumento.Text); //registracion documento
            MapHeaderDocumento1();

            if (_existeDocumentoSecundario)
            {
                _aj2.Registrar(txtSDescripcionInterna2.Text);
                MapHeaderDocumento2();
                MessageBox.Show(@"Se ha Registrado Correctamente el Documento IDFactura" + _aj1.GetId400().ToString() +
                                Environment.NewLine +
                                @"Se ha Registrado Correctamente el Documento IDFactura" + _aj2.GetId400().ToString(),
                    @"Registracion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Se ha Registrado Correctamente el Documento IDFactura" + _aj1.GetId400().ToString(),
                    @"Registracion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            rbtnRegistrar.Enabled = false;
            rbtnUnregistrar.Enabled = true;
            rPanelContabilizacion.Enabled = true;
            rbtnSolicitarCae.Enabled = false;
            rbtnContabilizar.Enabled = true;
            txtMotivoGeneralDocumento.Enabled = false;
        }

        private void rbtnUnregistrar_Click(object sender, EventArgs e)
        {

        }

        private void rbtnContabilizar_Click(object sender, EventArgs e)
        {
            //ver si se puede contabilizar
            if (_aj1.GetId400() < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error y no se puede contabilizar el Documento #1",
                    @"Error al Intentar Contabilizar - No Existe ID en T400", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (_existeDocumentoSecundario && _aj2.GetId400() < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error y no se puede contabilizar el Documento #2",
                    @"Error al Intentar Contabilizar - No Existe ID en T400", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            
            {
                //aca se contabiliza de acuerdo al motivo
                //Si no -> va accion general de contabilizacion
            }

            var zz = new ContaClienteAjusteL2(_aj1.GetId400(), _idCliente);
            zz.ContabilizaCompletaAjusteRedondeo();
            txtIdCtaCte1.Text = zz.IdCtaCte.ToString();
            txtNas1.Text = zz.RtnAsiento.IdDocu.ToString();
            var gestionStatus = new GestionT400Status(_aj1.GetId400());
            _statusDocumento = gestionStatus.SetContabilizada(zz.IdCtaCte, zz.RtnAsiento.IdDocu, zz.RtnAsiento.Nasx1);
            
            //Contabilizacion de segundo documento /Contradocumento []
            if (_existeDocumentoSecundario)
            {
                var zz2 = new ContaClienteAjusteL2( _aj2.GetId400(), _idCliente, txtTipoDocumento2.Text);
                zz2.ContabilizaCompletaAjusteRedondeo();
                txtNas2.Text = zz2.RtnAsiento.IdDocu.ToString();
                txtIdCtaCte2.Text = zz2.IdCtaCte.ToString();
                var gestionStatus2 = new GestionT400Status(_aj2.GetId400());
                _statusDocumento2 = gestionStatus2.SetContabilizada(zz2.IdCtaCte, zz2.RtnAsiento.IdDocu, zz2.RtnAsiento.Nasx1);
            }
            

            //aca van acciones POST-Contabilizacion
            {
                //Si Existen Acciones van aca
            }

            //if (_motivoDebito == CustomerNd.MotivoNotaDebito.AnulaDocumento)
            //{
            //    //*** Motivo ND Anulacion completa de Nota de Credito
            //    var zz = new ContaClienteNotaDebitoL2(_nd.GetId400(), _idCliente, txtTdoc.Text);
            //    zz.ContabilizacionAnulaDocumentoCompleto();
            //    txtIdCtaCte1.Text = zz.IdCtaCte.ToString();
            //    txtNas1.Text = zz.RtnAsiento.IdDocu.ToString();
            //    var gestionStatus = new GestionT400Status(_nd.GetId400());
            //    if (_lx == Lx.L1 && _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA)
            //    {
            //        //Si es ND --> va a Pendiente CAE
            //        _statusDocumento = gestionStatus.SetContabilizada(zz.IdCtaCte, zz.RtnAsiento.IdDocu, zz.RtnAsiento.Nasx1);
            //        _statusDocumento = gestionStatus.SetPendienteCae();
            //    }
            //    else
            //    {
            //        //Si es DX --> va a Contabilizada
            //        _statusDocumento = gestionStatus.SetContabilizada(zz.IdCtaCte, zz.RtnAsiento.IdDocu, zz.RtnAsiento.Nasx1);
            //    }

            //}
            //else
            //{
            //    //*** Motivo Cheque Rechazado
            //    //Pueden existir 2 documentos[Si tiene Gastos/IVA] *Doc1 => Cheque
            //    var zz1 = new ContaClienteNotaDebitoL2(_nd.GetId400(), _idCliente, txtTdoc.Text);
            //    zz1.ContabilizaCompletoHeaderND();
            //    txtIdCtaCte1.Text = zz1.IdCtaCte.ToString();
            //    txtNas1.Text = zz1.RtnAsiento.IdDocu.ToString();
            //    var gestionStatus = new GestionT400Status(_nd.GetId400());
            //    if (_lx == Lx.L1 && _tipoDocumento == ManageDocumentType.TipoDocumento.NotaDebitoVentaA)
            //    {
            //        //Si es ND --> va a Pendiente CAE
            //        _statusDocumento = gestionStatus.SetContabilizada(zz1.IdCtaCte, zz1.RtnAsiento.IdDocu, zz1.RtnAsiento.Nasx1);
            //        _statusDocumento = gestionStatus.SetPendienteCae();
            //    }
            //    else
            //    {
            //        //Si es DX --> va a Contabilizada
            //        _statusDocumento = gestionStatus.SetContabilizada(zz1.IdCtaCte, zz1.RtnAsiento.IdDocu, zz1.RtnAsiento.Nasx1);
            //        //Update en Tabla T0156-Rechazo
            //        new ChequeRechazadoManager().UpdateAfterContabilizacionNd(_idRetorno, Convert.ToInt32(txtNas1.Text),
            //            _nd.GetId400(), txtNumeroDocumento.Text);
            //    }

            //    //Contabilizacion de segundo documento [Siempre Gastos]
            //    if (_existeDocumentoSecundario)
            //    {
            //        var zz2 = new ContaClienteNotaDebitoL2(_nd2.GetId400(), _idCliente, txtTipoDocumento2.Text);
            //        zz2.ContabilizaCompletoHeaderND();
            //        txtNas2.Text = zz2.RtnAsiento.IdDocu.ToString();
            //        txtIdCtaCte2.Text = zz2.IdCtaCte.ToString();
            //        var gestionStatus2 = new GestionT400Status(_nd2.GetId400());
            //        if (_lx == Lx.L1 && txtTipoDocumento2.Text == @"ND")
            //        {
            //            _statusDocumento2 = gestionStatus2.SetContabilizada(zz2.IdCtaCte, zz2.RtnAsiento.IdDocu,
            //                zz2.RtnAsiento.Nasx1);
            //            _statusDocumento2 = gestionStatus2.SetPendienteCae();
            //        }
            //        else
            //        {
            //            _statusDocumento2 = gestionStatus2.SetContabilizada(zz2.IdCtaCte, zz2.RtnAsiento.IdDocu,
            //                zz2.RtnAsiento.Nasx1);
            //        }
            //    }
            SetScreenStatus();
        }
    
        private void rbtnSolicitarCae_Click(object sender, EventArgs e)
        {

        }

        #endregion
        #region Acciones Ajuste
        private void RedirigeAccionDespuesPresionarBoton()
        {
            //Los botones de accion redirigen a esta funcion -- Valida -- Activa Ribbon 
            //Redirige a Accion Especifica segun el motivo/boton presionado
            if (_lx == Lx.NoSeleccionado)
            {
                MessageBox.Show(
                    @"Debe Seleccionar el tipo de Operacion (L1/L2) antes de seleccionar el Motivo General de la Nota de Debito",
                    @"Falta Seleccion Tipo OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _motivoAjuste = CustomerAjustes.MotivoAjustes.SinMotivo;
                return;
            }

            string autorizado = "NO-Autorizado";
            if (rbCmdAutorizado.SelectedItem != null) autorizado = rbCmdAutorizado.SelectedItem.Text;
            txtTipoDocumento.Text = _motivoAjuste.ToString();
            rbMainRibbon.ActiveTab = rTabContabilizacion;
            rPanelRegistracion.Enabled = true;
            rbtnUnregistrar.Enabled = false;
            rPanelTipoDoc.Enabled = false;
            
            switch (_motivoAjuste)
            {
                case CustomerAjustes.MotivoAjustes.SinMotivo:

                    break;
                case CustomerAjustes.MotivoAjustes.TraspasoCliente:
                    FxTraspasoEntreClientes();
                    break;
                case CustomerAjustes.MotivoAjustes.TraspasoTipo:
                    FxTraspasoEntreTiposLx();
                    break;
                case CustomerAjustes.MotivoAjustes.RedondeoCuenta:
                    FxRedondeo();
                    break;
                case CustomerAjustes.MotivoAjustes.PerdidaIncobrable:
                    FxIncobrables();
                    break;
                case CustomerAjustes.MotivoAjustes.PerdidaGestion:
                    FxNoReclamable();
                    break;
                case CustomerAjustes.MotivoAjustes.CobranzaFicticia:
                    FxNoReclamable(); //??
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void FxRedondeo()
        {
            tabFi2.Visible = false;
            string autorizado = "NO-Autorizado";
            if (rbCmdAutorizado.SelectedItem != null) autorizado = rbCmdAutorizado.SelectedItem.Text;
            _aj1 = new CustomerAjustes(_motivoAjuste);
            _aj1.CreaHeader(_tipoDocumento, _idCliente, _lx.ToString(), dtpFechaDocumento.Value, cTc.GetValueDecimal, "0E", "0.0.0.0", false, autorizado);
            using (var f0 = new FrmFI72AjusteRedondeo(_aj1, _motivoAjuste))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    txtMotivoGeneralDocumento.Text = f0.MotivoAjuste;
                    txtMotivoGeneralDocumento.BackColor = Color.LightGreen;
                    txtCondicionVenta.Text = @"0E - Pago Contraentrega Documento";
                    dgv400.DataSource = _aj1.GetItems();
                    MapTotalesFactura400(_aj1.GetTotalesFromHeader());
                    MapHeaderDocumento1();
                }
                else
                {
                    _aj1 = null;
                    MessageBox.Show(@"Se Anulo el Ajuste por Redondeo", @"Anulacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }
        }
        private void FxNoReclamable()
        {
        }
        private void FxIncobrables()
        {
        }
        private void FxTraspasoEntreClientes() { }

        private void FxTraspasoEntreTiposLx()
        {
            //se pasa el saldo pendiente entre tipos L1 --> L2 y viceversa
            tabFi2.Visible = true;
            tabFi2.Text = @"ContraDocumento";
            string autorizado = "NO-Autorizado";
            if (rbCmdAutorizado.SelectedItem != null) autorizado = rbCmdAutorizado.SelectedItem.Text;
            _aj1 = new CustomerAjustes(_motivoAjuste);
            _aj2=  new CustomerAjustes(_motivoAjuste);
           
            using (var f0 = new FrmFI75AjusteEntreCuentasLx(_aj1,_aj2,_idCliente,dtpFechaDocumento.Value,autorizado))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    txtMotivoGeneralDocumento.Text = f0.MotivoDescripcionAjuste;
                    txtMotivoGeneralDocumento.BackColor = Color.LightGreen;
                    txtCondicionVenta.Text = @"0E - Pago Contraentrega Documento";
                    dgv400.DataSource = _aj1.GetItems();
                    MapTotalesFactura400(_aj1.GetTotalesFromHeader());
                    MapHeaderDocumento1();
                    _existeDocumentoSecundario = true;
                    dgvNotaDebitoGastos.DataSource = _aj2.GetItems();
                    MapTotalesFactura400_Gastos(_aj2.GetTotalesFromHeader());
                    MapHeaderDocumento2();
                    txtSDescripcionInterna2.Text = @"Contradocumento Ajuste de Saldo entre tipos";

                }
                else
                {
                    _aj1 = null;
                    MessageBox.Show(@"Se Anulo el Ajuste por Redondeo", @"Anulacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }


        }

        #endregion

        
        private void MapTotalesFactura400(TotalesCustomerFi total)
        {
            if (!total.OK)
            {
                MessageBox.Show(@"Error en calculo de Totales");
            }

            cBruto.SetValue = total.Bruto;
            cDescuento.SetValue = total.Descuento;
            cSubtotal.SetValue = total.Subtotal;
            cImponible.SetValue = total.BaseImponible;
            cIva.SetValue = total.Iva21;
            cPercepcionIIBB.SetValue = total.IIBB;
            cTotalFinal.SetValue = total.TotalFinal;
        }
        private void MapTotalesFactura400_Gastos(TotalesCustomerFi total)
        {
            if (!total.OK)
            {
                MessageBox.Show(@"Error en calculo de Totales");
            }

            cBrutoGastos.SetValue = total.Bruto;
            cDescuentoGasto.SetValue = total.Descuento;
            cSubtotalGasto.SetValue = total.Subtotal;
            cImponibleGasto.SetValue = total.BaseImponible;
            cIvaGasto.SetValue = total.Iva21;
            cIibbGasto.SetValue = total.IIBB;
            cNetoGasto.SetValue = total.TotalFinal;
        }
        private void MapHeaderDocumento2()
        {
            var h2 = _aj2.GetHeader();
            txtTipoDocumento2.Text = h2.TIPO_DOC;
            txtnumeroDoc2.Text = h2.NumeroDoc;
            txtStatusDoc2.Text = h2.StatusFactura;
            txtId400Gasto.Text = _aj2.Id400.ToString();
            //
            txtIdNcd2.Text = _aj2.Id300.ToString();
            //
            var h3 = _aj2.GetHeader300();
            txtSNumeroDoc2.Text = h3.NDOC;
            txtSIdNcd2.Text = h3.IDH.ToString();
            txtSDescripcionInterna2.Text = h3.COMENTARIO;
            txtSFechaRegistro2.Text = h3.FECHA.ToString("d");
            txtSImporteArs2.Text = h3.ImporteARS.ToString("C2");
            txtSImporteUsd2.Text = h3.ImporteUSD.ToString("C2");
            txtSPeriodoDesde2.Text = h3.PeriodoAjusteDesde.ToString();
            txtSPeriodoHasta2.Text = h3.PeriodoAjusteHasta.ToString();
            txtSIdFacturaAsociada2.Text = _aj2.NumeroDocumentoAsociado;
            txtSLx2.Text = h3.LX;
        }
        private void MapHeaderDocumento1()
        {
            var h = _aj1.GetHeader();
            txtId400.Text = _aj1.Id400.ToString();
            txtStatusDoc1.Text = h.StatusFactura;
            txtNumeroDocumento.Text = h.NumeroDoc;
            //
            var h3 = _aj1.GetHeader300();
            txtSNumeroDoc1.Text = h3.NDOC;
            txtSIdNcd1.Text = h3.IDH.ToString();
            txtSDescripcionInternar1.Text = h3.COMENTARIO;
            txtSFechaRegistro1.Text = h3.FECHA.ToString("d");
            txtSImporteArs1.Text = h3.ImporteARS.ToString("C2");
            txtSImporteUsd1.Text = h3.ImporteUSD.ToString("C2");
            txtSPeriodoDesde1.Text = h3.PeriodoAjusteDesde.ToString();
            txtSPeriodoHasta1.Text = h3.PeriodoAjusteHasta.ToString();
            txtSIdFacturaAsociada1.Text = _aj1.NumeroDocumentoAsociado;
            txtSLx1.Text = h3.LX;
        }
        
        //todo:revisar y mejoar esta funcion
        private void SetScreenStatus()
        {
            rPanelRegistracion.Enabled = false;
            rPanelContabilizacion.Enabled = false;
            rbtnContabilizar.Enabled = false;
            rbtnSolicitarCae.Enabled = false;
            txtStatusDoc1.Text = _statusDocumento.ToString();
            txtStatusDoc2.Text = _statusDocumento2.ToString();
            switch (_statusDocumento)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    break;
                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    //esta lista par ser impresa
                    break;
                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    //esta lista para ser impresa
                    txtStatusDoc1.BackColor = Color.LightGreen;
                    break;
                case DocumentFIStatusManager.StatusHeader.Impresa:
                    break;
                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    break;
                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    txtStatusDoc1.BackColor = Color.LightCoral;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (_statusDocumento2)
            {
                case DocumentFIStatusManager.StatusHeader.Pendiente:
                    break;
                case DocumentFIStatusManager.StatusHeader.Registrada:
                    break;
                case DocumentFIStatusManager.StatusHeader.Contabilizada:
                    //esta lista par ser impresa
                    break;
                case DocumentFIStatusManager.StatusHeader.Aprobada:
                    //esta lista para ser impresa
                    txtStatusDoc2.BackColor = Color.LightGreen;
                    break;
                case DocumentFIStatusManager.StatusHeader.Impresa:
                    break;
                case DocumentFIStatusManager.StatusHeader.Cancelada:
                    break;
                case DocumentFIStatusManager.StatusHeader.PendienteCAE:
                    txtStatusDoc2.BackColor = Color.LightCoral;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_statusDocumento2 == DocumentFIStatusManager.StatusHeader.PendienteCAE ||
                _statusDocumento == DocumentFIStatusManager.StatusHeader.PendienteCAE)
            {
                rPanelContabilizacion.Enabled = true;
                rbtnSolicitarCae.Enabled = true;
            }
        }
        private void SolicitaCaeCompletaData(int posicionDocumento, int iddoc, int? idDocAnula, DateTime? fechaD, DateTime? fechaH)
        {
            var fe = new FacturacionElectronicaTecser(_modoAfip);
            var resultado = idDocAnula != null
                ? fe.SolicitudCAEFromT0400(iddoc, idDocAnula, null, null)
                : fe.SolicitudCAEFromT0400(iddoc, null, fechaD, fechaH);

            if (resultado.Resultado == "A")
            {
                if (posicionDocumento == 1)
                {
                    txtCae1.Text = resultado.CAE;
                    txtVencimientoCae1.Text = resultado.VencimientoCAE.ToString("d");
                    txtNumeroDocumento.Text = resultado.NumeroDocumentoOtorgadoCompleto;
                    txtNumeroDoc1.Text = resultado.NumeroDocumentoOtorgadoCompleto;
                    fe.UpdateDataAfterDocumentNumberGetFromAFIP(iddoc, resultado.PuntoVenta, resultado.ComprobanteHasta, resultado.CAE,
                        resultado.VencimientoCAE, Convert.ToInt32(txtNas1.Text));
                    _statusDocumento = DocumentFIStatusManager.StatusHeader.Aprobada;

                    //Acciones Post-Cae Aprobado 

                   // End Acciones
                }
                else
                {
                    txtCae2.Text = resultado.CAE;
                    txtVencimientoCae2.Text = resultado.VencimientoCAE.ToString("d");
                    txtnumeroDoc2.Text = resultado.NumeroDocumentoOtorgadoCompleto;
                    fe.UpdateDataAfterDocumentNumberGetFromAFIP(iddoc, resultado.PuntoVenta, resultado.ComprobanteHasta, resultado.CAE,
                        resultado.VencimientoCAE, Convert.ToInt32(txtNas2.Text));
                    _statusDocumento2 = DocumentFIStatusManager.StatusHeader.Aprobada;
                }

                //Chequea si hay que ingresar Percepcion IIBB
                if (posicionDocumento == 1)
                {
                    var xdoc = _aj1.GetHeader();
                    if (xdoc.TotalIIBB > 0)
                    {
                        new PercepcionesManager().AddFacturaPercepcion(iddoc);
                    }
                }
                else
                {
                    var xdoc = _aj2.GetHeader();
                    if (xdoc.TotalIIBB > 0)
                    {
                        new PercepcionesManager().AddFacturaPercepcion(iddoc);
                    }
                }
                var st = new GestionT400Status(iddoc);
                st.SetAprobadaCae(resultado.CAE, resultado.VencimientoCAE, resultado.PuntoVenta, resultado.ComprobanteHasta);
                SetScreenStatus();
            }
            else
            {
                MessageBox.Show(@"Ha Ocurrido un error al solicitar el CAE", @"Error en SOLICITUD DE CAE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //todo:revisar y mejorar esta funcion
        private bool OkRegistrar()
        {
            if (_tipoDocumento == ManageDocumentType.TipoDocumento.NoDefinido)
            {
                MessageBox.Show(@"No se ha definido aun un tipo de documento a Registrar", @"Documento Incompleto",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtMotivoGeneralDocumento.Text))
            {
                MessageBox.Show(@"Debe completar el motivo por el que se está generando el documento (interno)",
                    @"Fata Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tt.Show("Complete este Dato", txtMotivoGeneralDocumento, 700);
                return false;
            }
            tt.Show("", txtMotivoGeneralDocumento);
            return true;
        }
    }
}
