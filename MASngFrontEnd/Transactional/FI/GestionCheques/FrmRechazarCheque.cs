using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.FI.GestionCheques
{
    public partial class FrmRechazarCheque : Form
    {
        public FrmRechazarCheque(int modo = 0)
        {
            InitializeComponent();
            this.dgvListaCheques.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCheques_CellEnter);

        }
        private int? _idChequeSeleccionado;
        private int? _idCliente;
        private int? _proveedorSeleccionado;

        private List<T0154_CHEQUES> _ListaCheques = new List<T0154_CHEQUES>();
        private bool _runSelectedIndex = false;
        private bool _runRb = false;
        private bool _runPopulaCheque = false;

        private T0154_CHEQUES _chequeSeleccionado = new T0154_CHEQUES();
        private int _idTracker = -1;

        private AccionUbicacionCheque _ubicacionCheque;
        private AccionCliente _accionCliente;
        private AccionCheque _accionCheque;
        private AccionProveedor _accionProveedor;
        private Opcion _opcionAccion;
        private string _tipoLx;

        private enum AccionUbicacionCheque
        {
            EnCartera,
            EnProveedor,
            EnBanco,
            NoSeleccionado
        };
        private enum AccionCheque
        {
            ACarteraSR,
            AClienteSR,
            Rechazado,
            NoSeleccionado
        };
        private enum AccionCliente
        {
            GenerarNd,
            GenerarAj,
            NoSelecionado
        };
        private enum AccionProveedor
        {
            ConNd,
            SinNd,
            NoSelecionado
        };

        private enum Opcion
        {
            CuentaACarteraSR,
            CuentaAClienteCR,
            CarteraAClienteSR,
            ProveedorACarteraSR,
            ProveedorAClienteCR,
            NoSeleccionado
        }


        private void ResetAllSections()
        {
            ResetSeccionChequeSeleccionado();
            ResetSeccionNdProveedor();
            ResetSeccionRechazo();
            ResetSeccionNdACliente();
        }
        private void ResetSeccionChequeSeleccionado()
        {
            dgvListaCheques.ClearSelection();
            cFechaChequeAcreditacion.Value = null;
            cFechaChequeRecibido.Value = null;
            txtChBanco.Text = null;
            txtIdCheque.Text = null;
            _chequeSeleccionado = null;
            _idChequeSeleccionado = null;
            txtChCliente.Text = null;
            txtChLxRecibido.Text = null;
            cIcono5SeleccionCheque.Set = CIconos.TrianguloNaranja;
            _idCliente = null;
        }
        private void ResetSeccionNdProveedor()
        {
            txtProveedorRs.Text = null;
            txtTdocNdProveedor.Text = null;
            cFechaNdProveedor.Value = null;
            txtNumeroNdProveedor.Text = null;
            cIcono6DatosNdProveedor.Set = CIconos.TrianguloNaranja;
            _proveedorSeleccionado = null;
        }
        private void ResetSeccionRechazo()
        {
            dtpFechaRechazo.Value = DateTime.Today;
            txtMotivoRechazo.Text = null;
            cChImporte.SetValue = 0;
            cGastoRechazo.SetValue = 0;
            cIvaGastoRechazo.SetValue = 0;
            cImporteTotalRechazo.SetValue = 0;


        }
        private void ResetSeccionNdACliente()
        {
            dtpFechaNdACliente.Value = DateTime.Today;
            rbL1ACliente.Checked = false;
            rbL2ACliente.Checked = false;
            txtClienteRsND.Text = null;
            txtIdClienteNd.Text = null;
            txtNdcTdocCheque.Text = null;
            txtNdcNdocCheque.Text = null;
            txtNdcNdocGastos.Text = null;
            txtNdcTdocGastos.Text = null;
            cNdcImporteCheque.SetValue = 0;
            cNdcImporteGastos.SetValue = 0;
            cNdcImporteIva.SetValue = 0;
            cNdcImporteTotal.SetValue = 0;
            cIcono7DatosNDaCliente.Set = CIconos.TrianguloNaranja;
            txtNdcTextoGastos.Text = null;
            txtNdcTextoCheque.Text = null;


        }
        private void FrmRechazarCheque_Load(object sender, EventArgs e)
        {
            cDiasMaximos.SetValue = 200;
            ResetSeccionRechazo();
            ResetSeccionNdProveedor();
            ResetSeccionNdACliente();
            _runRb = true;
            rbEnCartera.Checked = true;
            _runPopulaCheque = true;
            this.dgvListaCheques.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCheques_CellEnter);
            ResetSeccionChequeSeleccionado();
        }

        //Seleccion de la Ubicacion del Cheque
        private void rbCartera_CheckedChanged(object sender, EventArgs e)
        {
            _runSelectedIndex = false;
            _runRb = false;
            //
            cIcono1Ubicacion.Set = CIconos.TrianguloNaranja;
            txtFilterChNum.Text = null;
            //reset cmb filtro
            cmbFiltroOrigen.DataSource = null;
            cmbFiltroOrigen.DisplayMember = null;
            cmbFiltroOrigen.ValueMember = null;
            lFiltroOrigen.Text = "";
            //Deshabilito Accion ND Proveedor
            rb2NDProveedor.Checked = false;
            rb2SinNdProveedor.Checked = false;
            rb2NDProveedor.AutoCheck = false;
            rb2SinNdProveedor.AutoCheck = false;
            cIcono2NDRecepcion.Set = CIconos.TrianguloNaranja;
            _accionProveedor = AccionProveedor.NoSelecionado;
            //Deshabilito Accion del Cheque
            rb3Rechazado.Checked = false;
            rb3SinRechazoACartera.Checked = false;
            rb3SinRechazoACliente.Checked = false;
            rb3Rechazado.AutoCheck = false;
            rb3SinRechazoACartera.AutoCheck = false;
            rb3SinRechazoACliente.AutoCheck = false;
            _accionCheque = AccionCheque.NoSeleccionado;
            cIcono3AccionCheque.Set = CIconos.TrianguloNaranja;
            //Deshabilito Accion Al Cliente
            rb4GenerarAX.Checked = false;
            rb4GenerarNd.Checked = false;
            rb4GenerarAX.AutoCheck = false;
            rb4GenerarNd.AutoCheck = false;
            _accionCliente = AccionCliente.NoSelecionado;
            cIcono4AccionACliente.Set = CIconos.TrianguloNaranja;
            //Listado de Cheques
            _ListaCheques = null;
            dgvListaCheques.DataSource = _ListaCheques;
            cIcono5SeleccionCheque.Set = CIconos.TrianguloNaranja;
            //
            ResetAllSections();
            lMotivo.Text = "Motivo Rechazo";
            //

            if (rbEnCartera.Checked)
            {
                //Cheques en Cartera / Disponibles
                _ubicacionCheque = AccionUbicacionCheque.EnCartera;
                lFiltroOrigen.Text = @"* Filtrado por Cliente *";
                cmbFiltroOrigen.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
                cmbFiltroOrigen.DisplayMember = "cli_rsocial";
                cmbFiltroOrigen.ValueMember = "IDCLIENTE";
                cmbFiltroOrigen.BackColor = Color.White;
                cmbFiltroOrigen.ForeColor = Color.Navy;
                cmbFiltroOrigen.Enabled = true;
                cmbFiltroOrigen.SelectedIndex = -1;
                //voy a traer a todos los cheques disponibles!
                _ListaCheques = new ChequesManager().GetListChequesDisponibles();
                dgvListaCheques.DataSource = _ListaCheques;
                dgvListaCheques.ClearSelection();
                //
                //_idChequeSeleccionado = null;
                //PopulaDatosCheque();
                _runSelectedIndex = true;
                _runRb = true;
                rb3SinRechazoACliente.Checked = true;
                lMotivo.Text = "Motivo Retorno";
                cIcono2NDRecepcion.Set = CIconos.Tilde;

            }
            else
            {
                if (rbDepositado.Checked)
                {
                    //Cheques en Entidades/Banco
                    _ubicacionCheque = AccionUbicacionCheque.EnBanco;
                    lFiltroOrigen.Text = @"Seleccion Entidad Deposito";
                    cmbFiltroOrigen.DataSource = new CuentasManager().GetListCuentasAvailableTransferencia()
                        .Where(c => c.CUENTA_TIPO == "TRANSF")
                        .ToList();
                    cmbFiltroOrigen.DisplayMember = "ID_CUENTA";
                    cmbFiltroOrigen.ValueMember = "ID_CUENTA";
                    cmbFiltroOrigen.BackColor = Color.LightGray;
                    cmbFiltroOrigen.ForeColor = Color.Navy;
                    cmbFiltroOrigen.Enabled = true;
                    cmbFiltroOrigen.SelectedIndex = -1;
                    //
                    _runSelectedIndex = true;
                    toolTip1.SetToolTip(rb3SinRechazoACliente, "El Cheque ha sido Rechazado por una Entidad Financiera");
                    toolTip1.SetToolTip(rb3SinRechazoACartera, "El Cheque ha sido depositado Antes de tiempo o por Error (Sin Rechazo)");
                    toolTip1.SetToolTip(rb3Rechazado, "El Cheque ha sido RECHAZADO");
                    //Permite las 3 opciones
                    _runRb = true;
                    rb3Rechazado.AutoCheck = true;
                    rb3SinRechazoACliente.AutoCheck = true;
                    rb3SinRechazoACartera.AutoCheck = true;
                    txtGL.Text = @"1.0.0.5"; //GL Aaccount de Cheques en Cartera.
                    cIcono1Ubicacion.Set = CIconos.Tilde;
                }
                else
                {
                    //Cheques entregados a Proveedores
                    _ubicacionCheque = AccionUbicacionCheque.EnProveedor;
                    lFiltroOrigen.Text = @"Seleccione el Proveedor";
                    cmbFiltroOrigen.DataSource = new VendorManager().GetCompleteListVendors(true);
                    cmbFiltroOrigen.DisplayMember = "prov_rsocial";
                    cmbFiltroOrigen.ValueMember = "id_prov";
                    cmbFiltroOrigen.BackColor = Color.LightBlue;
                    cmbFiltroOrigen.ForeColor = Color.Navy;
                    cmbFiltroOrigen.Enabled = true;
                    cmbFiltroOrigen.SelectedIndex = -1;
                    //
                    _runSelectedIndex = true;
                    rb3Rechazado.AutoCheck = true;
                    rb3SinRechazoACliente.AutoCheck = false;
                    rb3SinRechazoACartera.AutoCheck = true;
                    toolTip1.SetToolTip(rb3Rechazado, "El Cheque ha sido Rechazado por una Entidad Financiera/Defectos Formales");
                    toolTip1.SetToolTip(rb3SinRechazoACliente, "Esta accion no puede realizarse directamente- envie el cheque a Cartera");
                    toolTip1.SetToolTip(rb3SinRechazoACartera, "El Cheque No ha sido Aceptado por el Proveedor");

                    //Aun no permite enviar de proveedor a cliente en forma directa (envie a cartera primero)
                    _runRb = true;

                }
            }
            //
            txtGL.Text = null;
            btnRechazar.Enabled = EnableBotonRechazar();
        }
        //Selecicon de la Accion del Cheque
        private void rbRegresoACliente_CheckedChanged_1(object sender, EventArgs e)
        {
            _accionCheque = AccionCheque.NoSeleccionado;

            if (_ubicacionCheque == AccionUbicacionCheque.NoSeleccionado)
            {
                MessageBox.Show(@"Antes de Seleccionar la Accion con el Cheque debe seleccionar la Ubicacion del Mismo",
                    @"Accion no Valida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rb3SinRechazoACliente.Checked = false;
                rb3SinRechazoACartera.Checked = false;
                rb3Rechazado.Checked = false;
                rb4GenerarNd.Checked = false;
                rb4GenerarAX.Checked = false;
                rb4GenerarNd.AutoCheck = false;
                rb4GenerarAX.AutoCheck = false;
                return;
            }

            if (rb3SinRechazoACliente.Checked)
            {
                _accionCheque = AccionCheque.AClienteSR;
                _accionCliente = AccionCliente.NoSelecionado;
                rb4GenerarNd.AutoCheck = true;
                rb4GenerarAX.AutoCheck = true;
            }

            if (rb3SinRechazoACartera.Checked)
            {
                _accionCheque = AccionCheque.ACarteraSR;
                _accionCliente = AccionCliente.NoSelecionado;
                rb4GenerarNd.Checked = false;
                rb4GenerarAX.Checked = false;
                rb4GenerarNd.AutoCheck = false;
                rb4GenerarAX.AutoCheck = false;
                _accionCliente = AccionCliente.NoSelecionado;
            }

            if (rb3Rechazado.Checked)
            {
                _accionCheque = AccionCheque.Rechazado;
                _accionCliente = AccionCliente.NoSelecionado;
                rb4GenerarNd.AutoCheck = true;
                rb4GenerarAX.AutoCheck = true;
            }
            btnRechazar.Enabled = EnableBotonRechazar();
        }
        //Seleccion Accion Cliente
        private void rb1NDCLI_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void cmbFiltroOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_runSelectedIndex == false)
                return;

            if (cmbFiltroOrigen.SelectedIndex == -1)
            {
                MessageBox.Show(@"Avisar qeu llegue acá SI -1");
            }

            switch (_ubicacionCheque)
            {
                case AccionUbicacionCheque.EnCartera:
                    if (cmbFiltroOrigen.SelectedValue == null)
                    {
                        //opcion de todos los cheques
                        _ListaCheques = new ChequesManager().GetListaChequesRecibidosCliente(
                            Convert.ToInt32(cmbFiltroOrigen.SelectedValue), (int)cDiasMaximos.GetValueDecimal);
                    }
                    else
                    {
                        _ListaCheques = new ChequesManager().GetListaChequesRecibidosCliente(
                            Convert.ToInt32(cmbFiltroOrigen.SelectedValue), (int)cDiasMaximos.GetValueDecimal);
                    }
                    break;
                case AccionUbicacionCheque.EnProveedor:
                    _ListaCheques = new ChequesManager().GetListaChequesEntregadosAProveedor(
                        Convert.ToInt32(cmbFiltroOrigen.SelectedValue));
                    txtGL.Text = new GLAccountManagement().GetApVendorGl(Convert.ToInt32(cmbFiltroOrigen.SelectedValue));
                    break;
                case AccionUbicacionCheque.EnBanco:
                    _ListaCheques = new ChequesManager().GetListChequesNoDisponibles(cmbFiltroOrigen.SelectedValue.ToString()).ToList();
                    txtGL.Text = new CuentasManager().GetGL(cmbFiltroOrigen.SelectedValue.ToString());
                    break;
                case AccionUbicacionCheque.NoSeleccionado:
                    MessageBox.Show(@"No se ha seleccionado ninguna opcion de ubicacion de cheque",
                        @"Error en Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Esta seleccion no puede pasar.
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            btnRechazar.Enabled = false;
            dgvListaCheques.DataSource = _ListaCheques;
            dgvListaCheques.ClearSelection();
            ResetSeccionChequeSeleccionado();

            //PopulaDatosCheque();
        }

        //Al Ingreso del DGV
        private void dgvListaCheques_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                ResetSeccionChequeSeleccionado();
                return;
            }

            var g = (DataGridView)sender;
            if (g.SelectedCells.Count != 0)
            {
                _idChequeSeleccionado =
                    Convert.ToInt32(dgvListaCheques[dgvListaCheques.Columns["iDCHEQUEDataGridViewTextBoxColumn"].Index,
                        e.RowIndex].Value);
                _chequeSeleccionado = new ChequesManager().GetCheque(_idChequeSeleccionado.Value);
                PopulaDatosCheque();
            }
        }


        private void PopulaDatosCheque()
        {
            if (!_runPopulaCheque)
                return;

            if (_idChequeSeleccionado == null)
            {
                //reeemplazar por reset??
                MessageBox.Show(@"avisar si estoy aca");
                cFechaChequeAcreditacion.Value = DateTime.Today;
                txtIdCheque.Text = null;
                txtChBanco.Text = null;
                cChImporte.SetValue = 0;
                txtIdClienteNd.Text = null;
                txtClienteRsND.Text = null;
                dtpFechaNdACliente.Value = DateTime.Today;
                //
                txtMotivoRechazo.Text = null;
                dtpFechaRechazo.Value = DateTime.Today;
                cChImporte.SetValue = 0;
                cIvaGastoRechazo.SetValue = 0;
                cGastoRechazo.SetValue = 0;
                rbL1Rechazo.Checked = false;
                rbL2Rechazo.Checked = false;
                btnRechazar.Enabled = false;
                _proveedorSeleccionado = null;
                cIcono5SeleccionCheque.Set = CIconos.TrianguloNaranja;
            }
            else
            {
                cFechaChequeAcreditacion.Value = _chequeSeleccionado.CHE_FECHA;
                txtIdCheque.Text = _idChequeSeleccionado.Value.ToString();
                txtChBanco.Text = _chequeSeleccionado.T0160_BANCOS.BCO_SHORTDESC;
                cChImporte.SetValue = _chequeSeleccionado.IMPORTE.Value;
                _idCliente = _chequeSeleccionado.IdClienteRecibido;
                txtChCliente.Text = _chequeSeleccionado.CLIENTE;
                cFechaChequeRecibido.Value = _chequeSeleccionado.FECHA_RECIBIDO;
                txtChLxRecibido.Text = _chequeSeleccionado.TIPO;
                //
                txtMotivoRechazo.Text = null;
                dtpFechaRechazo.Value = DateTime.Today;
                cChImporte.SetValue = _chequeSeleccionado.IMPORTE.Value;
                cIvaGastoRechazo.SetValue = 0;
                cGastoRechazo.SetValue = 0;
                cImporteTotalRechazo.SetValue = cChImporte.GetValueDecimal;
                cIcono5SeleccionCheque.Set = CIconos.Tilde;
                //
                if (_accionCheque == AccionCheque.Rechazado)
                {
                    if (_chequeSeleccionado.TIPO != _chequeSeleccionado.TIPOSAL)
                    {
                        MessageBox.Show(@"Atencion el Tipo del Cheque es difrente (Recepcion-->Salida)",
                            @"Notificacion sobre Tipos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (_chequeSeleccionado.TIPOSAL == "L1")
                    {
                        rbL1Rechazo.Checked = true;
                        rbL2Rechazo.Checked = false;
                        _tipoLx = "L1";
                    }
                    else
                    {
                        rbL1Rechazo.Checked = false;
                        rbL2Rechazo.Checked = true;
                        _tipoLx = "L2";
                    }
                }

                //
            }
            btnRechazar.Enabled = EnableBotonRechazar();
        }

        //oo
        private bool EnableBotonRechazar()
        {
            bool rtn = true;
            if (_chequeSeleccionado == null || _idChequeSeleccionado == null)
            {
                cIcono5SeleccionCheque.Set = CIconos.TrianguloNaranja;
                rtn = false;
            }
            else
            {
                cIcono5SeleccionCheque.Set = CIconos.Tilde;
            }

            if (_ubicacionCheque == AccionUbicacionCheque.NoSeleccionado)
            {
                cIcono1Ubicacion.Set = CIconos.TrianguloNaranja;
                rtn = false;
            }
            else
            {
                cIcono1Ubicacion.Set = CIconos.Tilde;
            }

            if (_accionCheque == AccionCheque.NoSeleccionado)
            {
                cIcono3AccionCheque.Set = CIconos.TrianguloNaranja;
                rtn = false;
            }
            else
            {
                cIcono3AccionCheque.Set = CIconos.Tilde;
            }

            if (_accionCheque != AccionCheque.ACarteraSR)
            {
                if (_accionCliente == AccionCliente.NoSelecionado)
                {
                    cIcono4AccionACliente.Set = CIconos.TrianguloNaranja;
                    rtn = false;
                }
                else
                {
                    cIcono4AccionACliente.Set = CIconos.Tilde;
                }
            }
            else
            {
                cIcono4AccionACliente.Set = CIconos.Tilde;
            }

            if (cChImporte.GetValueDecimal == 0)
            {
                cIcono5SeleccionCheque.Set = CIconos.ExclamacionOrange;
                return false;
            }
            else
            {
                if (rtn == true)
                {
                    cIcono5SeleccionCheque.Set = CIconos.Corazon;
                }
            }

            if (_ubicacionCheque == AccionUbicacionCheque.EnProveedor)
            {
                if (_chequeSeleccionado.IdProveedorSalida == null)
                {
                    toolTip1.Show("Error en el Proveedor de Salida!", cmbFiltroOrigen, cmbFiltroOrigen.Width, 0, 1500);
                    _proveedorSeleccionado = null;
                    return false;
                }
                _proveedorSeleccionado = _chequeSeleccionado.IdProveedorSalida.Value;
            }
            return rtn;
        }
        private bool ValidaData()
        {

            if (_ubicacionCheque == AccionUbicacionCheque.NoSeleccionado)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Validar Ubicacion del Cheque", @"Error Inesperado",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (_accionCheque == AccionCheque.NoSeleccionado)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Validar la Accion del Cheque", @"Error Inesperado",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (_accionCliente == AccionCliente.NoSelecionado)
            {
                if (_accionCheque != AccionCheque.ACarteraSR)
                {
                    MessageBox.Show(@"No se puede continuar sin definir como accionar con el cliente", @"Error Inesperado",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }
            }

            if (_idChequeSeleccionado == null)
            {
                MessageBox.Show(@"Debe Seleccionar un cheque para Rechazar", @"Rechazo de Cheques", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (_accionCheque == AccionCheque.Rechazado && cGastoRechazo.GetValueDecimal == 0)
            {
                var q = MessageBox.Show(@"Confirma Gastos de Rechazo " + 0.ToString("C2") + @"?", @"Sin Gastos",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (q == DialogResult.No)
                    return false;
            }

            if (rbL1Rechazo.Checked == false && rbL2Rechazo.Checked == false)
            {
                MessageBox.Show(@"Debe Seleccionar Tipo L1/L2 donde se ajustará/aplicará el debito", @"Error Inesperado", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            _tipoLx = rbL1Rechazo.Checked ? "L1" : "L2";

            if (_accionCheque == AccionCheque.ACarteraSR)
            {
                if (cIvaGastoRechazo.GetValueDecimal != 0)
                {
                    MessageBox.Show(@"Operacion de Reingreso a Cartera no puede tener Gastos de Rechazo *IVA",
                        @"Operacion Inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (cGastoRechazo.GetValueDecimal != 0)
                {
                    MessageBox.Show(@"Operacion de Reingreso a Cartera no puede tener Gastos de Rechazo",
                        @"Operacion Inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (_accionCheque == AccionCheque.AClienteSR)
            {
                if (cGastoRechazo.GetValueDecimal != 0)
                {
                    //En General Devolucion debiera ir sin gastos
                    var q = MessageBox.Show(
                        @"Confirma Gastos Aplicacion de Gastos de Rechazo " +
                        cGastoRechazo.GetValueDecimal.ToString("C2") + @" ?",
                        @"Gastos de Rechazo en Devolucion de Valores",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (q == DialogResult.No)
                        return false;
                }
            }

            if (string.IsNullOrEmpty(txtMotivoRechazo.Text))
            {
                if (_accionCheque == AccionCheque.Rechazado)
                {
                    MessageBox.Show(@"Debe Completar el motivo del Rechazo", @"Rechazo de Cheques",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    MessageBox.Show(@"Debe Completar el motivo del Reingreso/Devolucion a Cliente", @"Rechazo de Cheques",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }

            string tipoR = null;
            if (rbL1Rechazo.Checked)
            {
                tipoR = @"L1";
            }

            if (rbL2Rechazo.Checked)
            {
                tipoR = @"L2";
            }

            if (_chequeSeleccionado.TIPO != tipoR)
            {
                var preg = MessageBox.Show(@"Confirma que el tipo de Ajuste L1/L2 es diferente al tipo con el que se recibió el cheque?",
                    @"Rechazo de Cheques", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (preg == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }



        /// <summary>
        /// P1-Salidad Banco
        /// </summary>
        /// <returns></returns>
        private void RegistraOperacionTracker()
        {
            string cuentaOrigen = null;
            string cuentaDestino = null;
            switch (_ubicacionCheque)
            {
                case AccionUbicacionCheque.EnCartera:
                    cuentaOrigen = _chequeSeleccionado.IdClienteRecibido.ToString();
                    break;
                case AccionUbicacionCheque.EnProveedor:
                    cuentaOrigen = _proveedorSeleccionado.ToString();
                    break;
                case AccionUbicacionCheque.EnBanco:
                    cuentaOrigen = _chequeSeleccionado.PROVEEDOR;
                    break;
                case AccionUbicacionCheque.NoSeleccionado:
                    //No llegara aca nunca
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _idTracker = new ChequeRechazadoManager().AddChrTracker(_idChequeSeleccionado.Value,
                _chequeSeleccionado.T0160_BANCOS.BCO_SHORTDESC, _chequeSeleccionado.IMPORTE.Value,
                _ubicacionCheque.ToString(), cuentaOrigen, _accionCheque.ToString(), cuentaDestino,
                _accionCliente.ToString(), txtMotivoRechazo.Text, "ND#");
            if (_idTracker < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Generar el Tracker del Cheque - Reintente Nuevamente",
                    @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new ChequeRechazadoManager().DeleteTracker(_idTracker);
                _idTracker = -1;
            }
        }
        private void P2SalidaBancoConRechazo()
        {
            var dataCheque = new ChequesManager().GetCheque(_idChequeSeleccionado.Value);
            string glAP_CyB;

            if (_ubicacionCheque == AccionUbicacionCheque.EnBanco)
            {
                glAP_CyB = new CuentasManager().GetGL(dataCheque.PROVEEDOR);
            }
            else
            {
                if (_ubicacionCheque == AccionUbicacionCheque.EnProveedor)
                {
                    glAP_CyB = new GLAccountManagement().GetApVendorGl(dataCheque.IdProveedorSalida.Value);
                }
                else
                {
                    //Situacion de Error
                    MessageBox.Show(@"Ha Ocurrido un Error en Ubicacion/Origen Cheque y la Operacion a Realizar",
                        @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    new ChequeRechazadoManager().DeleteTracker(_idTracker);
                    _idTracker = -1;
                    return;
                }
            }
            //Asiento Cheque Rechazado del Banco
            var AsientoRtn = new AsientoGenerico("CHR").CreaAsientoChequeRechazado(_idChequeSeleccionado.Value,
                txtMotivoRechazo.Text, glAP_CyB, dtpFechaRechazo.Value, cGastoRechazo.GetValueDecimal,
                cGastoRechazo.GetValueDecimal, _tipoLx);

            if (AsientoRtn.IdDocu < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Generar el Asiento Contable - Reintente Nuevamente",
                    @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new ChequeRechazadoManager().DeleteTracker(_idTracker);
                return;
            }
            new ChequeRechazadoManager().UpdateAsientoTracker(_idTracker, AsientoRtn.IdDocu);

            //Registro de Rechazo
            new ChequeRechazadoManager().AddChequeRechazado(_chequeSeleccionado.IDCHEQUE,
                dtpFechaRechazo.Value, txtMotivoRechazo.Text, _tipoLx, cGastoRechazo.GetValueDecimal, cIvaGastoRechazo.GetValueDecimal, "$$$%");
        }
        private void P3IngresoCarteraFromVendor()
        {
            //Asiento Reingreso de Cheque desde Banco 
            var AsientoRtn = new AsientoGenerico("CHR").AsientoReingresoACarteraSinNd(
                _idChequeSeleccionado.Value, _idTracker, txtMotivoRechazo.Text, _tipoLx, cGastoRechazo.GetValueDecimal,
                cIvaGastoRechazo.GetValueDecimal);

            if (AsientoRtn.IdDocu < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Generar el Asiento Contable - Reintente Nuevamente",
                    @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new ChequeRechazadoManager().DeleteTracker(_idTracker);
                _idTracker = -1;
                return;
            }
            new ChequeRechazadoManager().UpdateAsientoTracker(_idTracker, AsientoRtn.IdDocu);
            var glCheque = new CuentasManager().GetGL("CHE");
            //Registra Ingreso del Cheque (Subdiario IN)
            new RegisterManager().AddRegisterRecord("CHE", DateTime.Today, "CHR", _idTracker.ToString("00000000"),
                TipoEntidad.Proveedor, _chequeSeleccionado.IdProveedorSalida.Value, "REIN: " + txtMotivoRechazo.Text, "ARS",
                _chequeSeleccionado.IMPORTE.Value, 0, _idChequeSeleccionado.Value, _tipoLx, glCheque, AsientoRtn.IdDocu,
                "CHR", true, "Prov");

        }
        private void P1SalidaBancoACartera()
        {
            //Asiento Reingreso de Cheque
            var AsientoRtn = new AsientoGenerico("CHR").AsientoReingresoACarteraSinNd(
                _idChequeSeleccionado.Value, _idTracker, txtMotivoRechazo.Text, _tipoLx, cGastoRechazo.GetValueDecimal,
                cIvaGastoRechazo.GetValueDecimal);

            if (AsientoRtn.IdDocu < 1)
            {
                MessageBox.Show(@"Ha Ocurrido un Error al Generar el Asiento Contable - Reintente Nuevamente",
                    @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new ChequeRechazadoManager().DeleteTracker(_idTracker);
                _idTracker = -1;
                return;
            }

            new ChequeRechazadoManager().UpdateAsientoTracker(_idTracker, AsientoRtn.IdDocu);
            var dataTracker = new ChequeRechazadoManager().GetTracker(_idTracker);
            var cuentaO = dataTracker.CuentaOrigen;
            var glBanco = new CuentasManager().GetGL(cuentaO);
            var glCheque = new CuentasManager().GetGL("CHE");

            //Registra Salida del Cheque (Subdiario OUT)
            new RegisterManager().AddRegisterRecord(cuentaO, DateTime.Today, "CHR", dataTracker.DocumentoRef,
                TipoEntidad.Transferencia, 0, "REIN: " + txtMotivoRechazo.Text, "ARS", 0,
                _chequeSeleccionado.IMPORTE.Value, _idChequeSeleccionado.Value, _tipoLx, glBanco, AsientoRtn.IdDocu,
                "CHR", true, "CHE");

            //Registra Ingreso del Cheque (Subdiario IN)
            new RegisterManager().AddRegisterRecord("CHE", DateTime.Today, "CHR", dataTracker.DocumentoRef,
                TipoEntidad.Transferencia, 0, "REIN: " + txtMotivoRechazo.Text, "ARS",
                _chequeSeleccionado.IMPORTE.Value, 0, _idChequeSeleccionado.Value, _tipoLx, glCheque, AsientoRtn.IdDocu,
                "CHR", true, cuentaO);
        }

        private void AjusteCtaCteClienteAx()
        {
            string numeroDocumento = _idTracker.ToString("00000000");
            var ctaCtaCliente = new CtaCteCustomer(_chequeSeleccionado.IdClienteRecibido.Value);

            var idCtaCteXX = ctaCtaCliente.AddCtaCteDetalleRecord("AX", _tipoLx, dtpFechaRechazo.Value, numeroDocumento, "TK-",
                "ARS", cChImporte.GetValueDecimal, new ExchangeRateManager().GetExchangeRate(dtpFechaRechazo.Value),
                cChImporte.GetValueDecimal, idDocAlternativo: _idTracker);
            ctaCtaCliente.AddRecordDocumentT0207FromIdCtaCte(idCtaCteXX);
            ctaCtaCliente.UpdateSaldoCtaCteResumen(_tipoLx, cChImporte.GetValueDecimal, "ARS");
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (ValidaData() == false)
                return;

            decimal importeTotal = cChImporte.GetValueDecimal + cGastoRechazo.GetValueDecimal +
                                   cIvaGastoRechazo.GetValueDecimal;

            var resp = MessageBox.Show($@"Confirma el Rechazo del Cheque Banco {txtChBanco.Text} por: " +
                                       Environment.NewLine +
                                       $@"Importe Cheque=  {cChImporte.GetValueDecimal.ToString("C2")} " +
                                       Environment.NewLine +
                                       $@"Importe Gastos=  {cGastoRechazo.GetValueDecimal.ToString("C2")} " +
                                       Environment.NewLine +
                                       $@"Importe Iva=  {cIvaGastoRechazo.GetValueDecimal.ToString("C2")} " +
                                       Environment.NewLine +
                                       $@"Importe Operacion Total=  {importeTotal.ToString("C2")} ",
                @"Confirmacion de Operacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;
            //------------------------------------------------------------------------------------------------

            decimal xrate = new ExchangeRateManager().GetExchangeRate(DateTime.Today);
            AsientoBase.IdentificacionAsiento AsientoRtn = new AsientoBase.IdentificacionAsiento();
            TipoEntidad tipoEntidad = TipoEntidad.Proveedor;

            //------------------------------------------------------------------------------------------------

            RegistraOperacionTracker();
            if (_idTracker < 1)
                return;

            string documentoReferencia = _idTracker.ToString("00000000");
            switch (_accionCheque)
            {
                case AccionCheque.ACarteraSR:
                    //C21 (Reingreso desde Banco sin Rechazo)
                    P1SalidaBancoACartera();
                    if (new ChequesManager().LiberaCheque(_idChequeSeleccionado.Value, true))
                    {
                        MessageBox.Show(@"Se ha Reingresado el Cheque a la Cartera.", @"Operacion Exitosa - Cheque Disponible",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //B21 (De Proveedor SIN Rechazo) //Puede ser con o sin ND Proveedor
                    //Implementando --
                    P3IngresoCarteraFromVendor();




                    break;
                case AccionCheque.AClienteSR:
                    //A1 (Regreso a Cliente desde Cartera S/R)
                    //B11 (Regreso a Cliente desde Proveedor S/R)
                    //C11 (Regreso a Cliente desde Banco S/R)
                    break;
                case AccionCheque.Rechazado:
                    //B11 (Regreso a Cliente desde Proveedor con Rechazo)
                    //FALTA

                    //C11 (Regreso a Cliente desde Banco con Rechazo)
                    P2SalidaBancoConRechazo();
                    switch (_accionCliente)
                    {
                        case AccionCliente.GenerarNd:
                            //Opcion Anterior tomoa hacer rechazo desde T158
                            break;
                        case AccionCliente.GenerarAj:
                            AjusteCtaCteClienteAx();
                            if (new ChequesManager().LiberaCheque(_idChequeSeleccionado.Value, true))
                            {
                                MessageBox.Show(@"Se ha Reingresado el Cheque a la Cartera.",
                                    @"Operacion Exitosa - Cheque Disponible",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        case AccionCliente.NoSelecionado:
                            //Esta opcion no es valida
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }


                    break;
                case AccionCheque.NoSeleccionado:
                    //Operacion no valida
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }



            //switch (_accionCheque)
            //{
            //    case AccionCheque.ReingresarCartera:


            //        if (_accionCliente == AccionCliente.NoSelecionado)
            //        {
            //            //Accion de Regreso a Cartera SinND
            //            AsientoRtn = new AsientoGenerico("CHR").AsientoReingresoACarteraSinNd(
            //                _idChequeSeleccionado.Value,
            //                idTracker, txtMotivoRechazo.Text, _tipoLx, cImporteGastos.GetValueDecimal,
            //                cIvaGastos.GetValueDecimal);
            //        }
            //        else
            //        {
            //            //Opcion 2 para reingreso a Cartera es con ND-Proveedor (No Aceptado por X Motivo)
            //            //Pero Proveedor entrego ND.-
            //        }

            //        if (AsientoRtn.IdDocu < 1)
            //        {
            //            MessageBox.Show(@"Ha Ocurrido un Error al Generar el Asiento Contable - Reintente Nuevamente",
            //                @"Error en Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //            new ChequeRechazadoManager().DeleteTracker(idTracker);
            //            return;
            //        }

            //        new ChequeRechazadoManager().UpdateAsientoTracker(idTracker, AsientoRtn.IdDocu);

            //        if (_ubicacionCheque == AccionUbicacionCheque.EnBanco)
            //        {
            //            var glBanco = new CuentasManager().GetGL(_chequeSeleccionado.PROVEEDOR);
            //            tipoEntidad = TipoEntidad.Transferencia;
            //            //Register Saca Banco
            //            new RegisterManager().AddRegisterRecord("CHE", DateTime.Today, "CHR", documentoReferencia,
            //                tipoEntidad, _proveedorSeleccionado.Value, "REIN: " + txtMotivoRechazo.Text, "ARS", 0,
            //                _chequeSeleccionado.IMPORTE.Value,
            //                _idChequeSeleccionado.Value, _tipoLx, glBanco, AsientoRtn.IdDocu, "CHR", true);
            //        }

            //        if (_ubicacionCheque == AccionUbicacionCheque.EnProveedor)
            //        {
            //            tipoEntidad = TipoEntidad.Proveedor;
            //            idProveedor = _chequeSeleccionado.IdProveedorSalida.Value;

            //            //Actualiza CtaCte Proveedores con un documento XX
            //            var ctacte = new CtaCteVendor(_proveedorSeleccionado.Value);
            //            var idCtaCte = ctacte.AddCtaCteDetalleRecord("AX", _tipoLx, DateTime.Today,
            //                documentoReferencia, "CHR-" + documentoReferencia, "ARS", importeTotal, xrate,
            //                importeTotal);
            //            if (idCtaCte > 0)
            //            {
            //                //txtIdCtaCte.Text = idCtaCte.ToString();
            //                ctacte.UpdateSaldoCtaCteResumen(_tipoLx, importeTotal);
            //            }
            //        }

            //        //Register Salida
            //        new RegisterManager().AddRegisterRecord("CHE", DateTime.Today, "CHR", documentoReferencia,
            //            tipoEntidad, idProveedor, "REIN: " + txtMotivoRechazo.Text, "ARS",
            //            _chequeSeleccionado.IMPORTE.Value, 0,
            //            _idChequeSeleccionado.Value, _tipoLx, "1.0.0.5", AsientoRtn.IdDocu, "CHR", true);

            //        if (new ChequesManager().LiberaCheque(_idChequeSeleccionado.Value, true))
            //        {
            //            MessageBox.Show(@"Se ha Reingresado el Cheque satisfactoriamente.", @"Operacion Exitosa",
            //                MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }

            //        break;
            //    case AccionCheque.DevolverCliente:
            //        //Opcion de Devolver a Cliente SIN RECHAZO.

            //        break;
            //    case AccionCheque.Rechazado:
            //        break;
            //    case AccionCheque.NoSeleccionado:
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}

            //var chrmng = new ChequeRechazadoManager();
            //chrmng.AddChequeRechazado(_idChequeSeleccionado.Value, dtpFechaRechazo.Value,
            //    txtMotivoRechazo.Text.ToUpper(),tipoRechazo);

            //chrmng.SetChequeRechazadoTablaCheque(_idChequeSeleccionado.Value, txtMotivoRechazo.Text.ToUpper());

            //var asiento = new AsientoGenerico("CHR").CreaAsientoChequeRechazado(_idChequeSeleccionado.Value,
            //    txtMotivoRechazo.Text, txtGL.Text, dtpFechaRechazo.Value, cImporteGastos.GetValueDecimal, cIvaGastos.GetValueDecimal);

            //chrmng.CompleteNumeroAsientoRechazo(_idChequeSeleccionado.Value, asiento.IdDocu);

            //if (asiento.IdDocu > 0)
            //{
            //    MessageBox.Show(@"Se ha generado correctamente el Rechazo Seleccionado", @"Rechazo Correcto",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtNumeroAsiento.Text = asiento.IdDocu.ToString();
            //}

            //MessageBox.Show(@"Se ha Rechazado el Cheque Correctamente - Recuerde hacer la ND correspondiente", @"CHR-OK",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);

            //limpieza datos
            dgvListaCheques.ClearSelection();
            _idChequeSeleccionado = null;
            PopulaDatosCheque();
        }

        private void AsientoContableReingresoCartera()
        {

        }
        private void DisponibleNDCliente()
        {

        }
        private void ReingresoACartera()
        {

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilterChNum.Text))
            {
                ChequeBs.DataSource =
                    _ListaCheques.Where(c => c.CHE_NUMERO == txtFilterChNum.Text).ToList();
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ChequeBs.DataSource = _ListaCheques.ToList();
        }
        private void rbL1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbL1Rechazo.Checked)
            {

            }
            else
            {
                if (cIvaGastoRechazo.GetValueDecimal != 0)
                {
                    toolTip1.SetToolTip(cIvaGastoRechazo, "En Cuenta L2 no puede haber IVA");
                    toolTip1.Show("Se paso el Valor a 0", this, 1500);
                    cIvaGastoRechazo.SetValue = 0;
                }
            }
        }
        private void cIvaGastos_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (rbL2Rechazo.Checked)
            {
                if (cIvaGastoRechazo.GetValueDecimal != 0)
                {
                    toolTip1.SetToolTip(cIvaGastoRechazo, "En Cuenta L2 no puede haber IVA");
                    toolTip1.Show("Se paso el Valor a 0", this, 1500);
                    cIvaGastoRechazo.SetValue = 0;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbFiltroOrigen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbFiltroOrigen.SelectedValue == null)
            {
                _runSelectedIndex = false;
                _ListaCheques = new ChequesManager().GetListChequesDisponibles();
                dgvListaCheques.DataSource = _ListaCheques;
                dgvListaCheques.ClearSelection();
                ResetSeccionChequeSeleccionado();
            }
        }
        private void rb4AccionAlCliente_CheckedChanged(object sender, EventArgs e)
        {
            _accionCliente = AccionCliente.NoSelecionado;
            cIcono4AccionACliente.Set = CIconos.TrianguloNaranja;
            if (_accionCheque == AccionCheque.NoSeleccionado)
            {
                MessageBox.Show(@"Antes de Seleccionar la Accion con el Cliente debe seleccionar la Accion Cheque (Devolver o Reingresar)",
                    @"Accion no Valida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rb3SinRechazoACliente.Checked = false;
                rb3SinRechazoACartera.Checked = false;
                return;
            }

            if (rb4GenerarNd.Checked)
            {
                _accionCliente = AccionCliente.GenerarNd;
                cIcono4AccionACliente.Set = CIconos.Tilde;
                l8TextoNdACliente.Text = @"Datos Nota Debito a Cliente";
            }
            else
            {
                if (rb4GenerarAX.Checked)
                {
                    _accionCliente = AccionCliente.GenerarAj;
                    cIcono4AccionACliente.Set = CIconos.Tilde;
                    l8TextoNdACliente.Text = @"Datos Documento Ajuste a Cliente";
                }
                else
                {
                    _accionCliente = AccionCliente.NoSelecionado;
                }
            }
            btnRechazar.Enabled = EnableBotonRechazar();
        }
    }
}