using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.FI.GestionCheques
{
    public partial class FrmCrh : Form
    {
        private enum AccionUbicacionCheque
        {
            EnCartera,
            EnProveedor,
            EnBanco,
            NoSeleccionado
        };

        public enum AccionCheque
        {
            NoSeleccionado,
            RetornoAClienteSr,

        };


        //Listado propiedades 
        private AccionUbicacionCheque _ubicacionCheque;
        private List<T0154_CHEQUES> _listaCheques = new List<T0154_CHEQUES>();
        private bool _runSelectedIndex = false;
        private T0154_CHEQUES _chequeSeleccionado = null;
        private int? _idChequeSeleccionado = null;
        private int? _idClienteSeleccionado = null;
        private int? _idProveedorSeleccionado = null;

        public FrmCrh()
        {
            InitializeComponent();
        }

        #region MyRegion

        private void btnOrigenBanco_Click(object sender, EventArgs e)
        {
            rb1Banco.Checked = true;
            btnOrigenBanco.BackColor = Color.LightGreen;
            btnOrigenEnCartera.BackColor = Color.White;
            btnOrigenVendor.BackColor = Color.White;
        }
        private void btnOrigenVendor_Click(object sender, EventArgs e)
        {
            rb1Proveedor.Checked = true;
            btnOrigenBanco.BackColor = Color.White;
            btnOrigenVendor.BackColor = Color.LightPink;
            btnOrigenEnCartera.BackColor = Color.White;
        }
        private void btnOrigenEnCartera_Click(object sender, EventArgs e)
        {
            rb1Cartera.Checked = true;
            btnOrigenBanco.BackColor = Color.White;
            btnOrigenVendor.BackColor = Color.White;
            btnOrigenEnCartera.BackColor = Color.LightPink;
        }
        private void rb1Origen_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (!rb.Checked) return; //deseleccion
            if (rb1Banco.Checked)
            {
                _ubicacionCheque = AccionUbicacionCheque.EnBanco;
            }
            else
            {
                if (rb1Cartera.Checked)
                {
                    _ubicacionCheque = AccionUbicacionCheque.EnCartera;
                }
                else
                {
                    if (rb1Proveedor.Checked)
                    {
                        _ubicacionCheque = AccionUbicacionCheque.EnProveedor;
                    }
                    else
                    {
                        _ubicacionCheque = AccionUbicacionCheque.NoSeleccionado;
                    }
                }
            }
            CambiaOrigen();
        }
        private void ResetSeccionChequeSeleccionado()
        {
            cIcono5SeleccionCheque.Set = CIconos.TrianguloNaranja;
            dgvListaCheques.ClearSelection();
            cChFechaAcreditacion.Value = null;
            cChFechaRecibido.Value = null;
            txtChBanco.Text = null;
            txtIdCheque.Text = null;
            _chequeSeleccionado = null;
            _idChequeSeleccionado = null;
            txtChCliente.Text = null;
            txtChLxRecibido.Text = null;
            _idClienteSeleccionado = null;
            cChImporte.SetValue = 0;
            txtChProveedor.Text = null;
            txtChLxEntregado.Text = null;
        }
        #endregion revisado

        private void PopulaDatosCheque()
        {
            if (_idChequeSeleccionado == null)
            {
                //reeemplazar por reset??
                MessageBox.Show(@"avisar si estoy aca");
                ResetSeccionChequeSeleccionado();
            }
            else
            {
                cChFechaAcreditacion.Value = _chequeSeleccionado.CHE_FECHA;
                txtChBanco.Text = _chequeSeleccionado.T0160_BANCOS.BCO_SHORTDESC;
                txtIdCheque.Text = _idChequeSeleccionado.Value.ToString();
                _idClienteSeleccionado = _chequeSeleccionado.IdClienteRecibido;
                cChFechaRecibido.Value = _chequeSeleccionado.FECHA_RECIBIDO;
                txtChCliente.Text = _chequeSeleccionado.CLIENTE;
                txtChLxRecibido.Text = _chequeSeleccionado.TIPO;
                cChImporte.SetValue = _chequeSeleccionado.IMPORTE.Value;

                if (_chequeSeleccionado.DISPONIBLE)
                {
                    //cheque en Cartera
                    txtChLxEntregado.Text = null;
                    txtChProveedor.Text = null;
                    txtGL1.Text = @"1.0.0.5";
                }
                else
                {
                    txtChLxEntregado.Text = _chequeSeleccionado.TIPOSAL;
                    if (_chequeSeleccionado.OP.StartsWith("REG"))
                    {
                        //Cheque Salio por REG
                        txtChProveedor.Text = @"Cuenta -" + _chequeSeleccionado.PROVEEDOR;
                        _idProveedorSeleccionado = null;
                        txtGL1.Text = new CuentasManager().GetGL(_chequeSeleccionado.PROVEEDOR);
                    }
                    else
                    {
                        //Cheque Salio por OP
                        txtChProveedor.Text = new VendorManager().GetSpecificVendor(_chequeSeleccionado.IdProveedorSalida.Value).prov_rsocial;
                        txtGL1.Text = new GLAccountManagement().GetApVendorGl(_idProveedorSeleccionado.Value);
                    }
                }
            }
            cIcono5SeleccionCheque.Set = CIconos.Tilde;
        }
        private void CambiaOrigen()
        {
            _runSelectedIndex = false;
            this.cmbFiltroOrigen.SelectedIndexChanged -= new System.EventHandler(this.cmbFiltroOrigen_SelectedIndexChanged);
            this.cmbFiltroOrigen.TextChanged -= new System.EventHandler(this.cmbFiltroOrigen_TextChanged);
            this.dgvListaCheques.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCheques_CellEnter);
            cIcono1Ubicacion.Set = CIconos.TrianguloNaranja;
            if (_listaCheques.Count > 0)
            {
                _listaCheques.Clear();
            }

            switch (_ubicacionCheque)
            {
                case AccionUbicacionCheque.EnCartera:
                    lfiltro1.Text = @"Seleccione Cliente";
                    cmbFiltroOrigen.DataSource = new CustomerManager().GetCompleteListofBillTo(true);
                    cmbFiltroOrigen.DisplayMember = "cli_rsocial";
                    cmbFiltroOrigen.ValueMember = "IDCLIENTE";
                    cmbFiltroOrigen.BackColor = Color.White;
                    cmbFiltroOrigen.ForeColor = Color.Navy;
                    cmbFiltroOrigen.SelectedIndex = -1;
                    //** Voy a traer a todos los cheques disponibles
                    _listaCheques = new ChequesManager().GetListChequesDisponibles();
                    break;
                case AccionUbicacionCheque.EnProveedor:
                    lfiltro1.Text = @"Filtre x Proveedor";
                    cmbFiltroOrigen.DataSource = new VendorManager().GetCompleteListVendors(true);
                    cmbFiltroOrigen.DisplayMember = "prov_rsocial";
                    cmbFiltroOrigen.ValueMember = "id_prov";
                    cmbFiltroOrigen.BackColor = Color.LightBlue;
                    cmbFiltroOrigen.ForeColor = Color.Navy;
                    cmbFiltroOrigen.SelectedIndex = -1;
                    break;
                case AccionUbicacionCheque.EnBanco:
                    lfiltro1.Text = @"Depositado Entidad";
                    //Cheques en Entidades/Banco
                    cmbFiltroOrigen.DataSource = new CuentasManager().GetListCuentasAvailableTransferencia()
                        .Where(c => c.CUENTA_TIPO == "TRANSF").ToList();
                    cmbFiltroOrigen.DisplayMember = "ID_CUENTA";
                    cmbFiltroOrigen.ValueMember = "ID_CUENTA";
                    cmbFiltroOrigen.BackColor = Color.LightGray;
                    cmbFiltroOrigen.ForeColor = Color.Navy;
                    cmbFiltroOrigen.Enabled = true;
                    cmbFiltroOrigen.SelectedIndex = -1;
                    break;
                case AccionUbicacionCheque.NoSeleccionado:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ResetSeccionChequeSeleccionado();
            this.cmbFiltroOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroOrigen_SelectedIndexChanged);
            this.cmbFiltroOrigen.TextChanged += new System.EventHandler(this.cmbFiltroOrigen_TextChanged);
            this.dgvListaCheques.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCheques_CellEnter);
            _runSelectedIndex = true;
            ChequeBs.DataSource = _listaCheques.ToList();
            dgvListaCheques.DataSource = _listaCheques.ToList();
            dgvListaCheques.ClearSelection();
        }
        private void cmbFiltroOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            const int diasCh = 365;

            if (_runSelectedIndex == false) return;
            if (cmbFiltroOrigen.SelectedIndex == -1)
            {
                MessageBox.Show(@"Avisar qeu llegue acá **SIndex**");
            }

            _idClienteSeleccionado = null;
            _idProveedorSeleccionado = null;
            txtGL1.Text = null;

            switch (_ubicacionCheque)
            {
                case AccionUbicacionCheque.EnCartera:
                    if (cmbFiltroOrigen.SelectedValue == null)
                    {
                        //opcion de todos los cheques
                        _idClienteSeleccionado = null;
                        //_listaCheques = new ChequesManager().GetListaChequesRecibidosCliente();
                    }
                    else
                    {
                        _idClienteSeleccionado = Convert.ToInt32(cmbFiltroOrigen.SelectedValue);
                        _listaCheques = new ChequesManager().GetListaChequesRecibidosCliente(_idClienteSeleccionado.Value, diasCh);
                    }
                    txtGL1.Text = @"1.0.0.5";  //Cheque GL 
                    break;
                case AccionUbicacionCheque.EnProveedor:
                    _idProveedorSeleccionado = Convert.ToInt32(cmbFiltroOrigen.SelectedValue);
                    _listaCheques = new ChequesManager().GetListaChequesEntregadosAProveedor(_idProveedorSeleccionado.Value);
                    txtGL1.Text = new GLAccountManagement().GetApVendorGl(Convert.ToInt32(cmbFiltroOrigen.SelectedValue));
                    break;
                case AccionUbicacionCheque.EnBanco:
                    _listaCheques = new ChequesManager().GetListChequesNoDisponibles(cmbFiltroOrigen.SelectedValue.ToString()).ToList();
                    txtGL1.Text = new CuentasManager().GetGL(cmbFiltroOrigen.SelectedValue.ToString());

                    break;
                case AccionUbicacionCheque.NoSeleccionado:
                    MessageBox.Show(@"No se ha seleccionado ninguna opcion de ubicacion de cheque",
                        @"Error en Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Esta seleccion no puede pasar.
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            CuentasBs.DataSource = _listaCheques;
            dgvListaCheques.DataSource = CuentasBs;
            dgvListaCheques.ClearSelection();
        }
        private void dgvListaCheques_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                ResetSeccionChequeSeleccionado();
                return;
            }

            var g = (DataGridView)sender;
            if (g.SelectedCells.Count != 0 && _listaCheques.Count > 0)
            {
                _idChequeSeleccionado = Convert.ToInt32(dgvListaCheques[dgvListaCheques.Columns["iDCHEQUEDataGridViewTextBoxColumn"].Index,
                        e.RowIndex].Value);
                _chequeSeleccionado = new ChequesManager().GetCheque(_idChequeSeleccionado.Value);
                PopulaDatosCheque();
            }
        }
        private void cmbFiltroOrigen_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbFiltroOrigen.Text) || _runSelectedIndex == false)
                return;
            this.dgvListaCheques.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCheques_CellEnter);
            _idClienteSeleccionado = null;
            _idProveedorSeleccionado = null;
            txtGL1.Text = null;
            switch (_ubicacionCheque)
            {
                case AccionUbicacionCheque.EnCartera:
                    //opcion de todos los cheques
                    _listaCheques = new ChequesManager().GetListChequesDisponibles();
                    txtGL1.Text = @"1.0.0.5";
                    break;
                case AccionUbicacionCheque.EnProveedor:
                    _listaCheques.Clear();
                    break;
                case AccionUbicacionCheque.EnBanco:
                    _listaCheques = new ChequesManager().GetListaChequesNoDisponiblesEnEntidadFinanciera().ToList();
                    break;
                case AccionUbicacionCheque.NoSeleccionado:
                    _listaCheques.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            dgvListaCheques.DataSource = _listaCheques;
            dgvListaCheques.ClearSelection();
            ResetSeccionChequeSeleccionado();
            this.dgvListaCheques.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCheques_CellEnter);
        }
        private void FrmCrh_Load(object sender, EventArgs e)
        {
            ChequeBs.DataSource = _listaCheques.ToList();
            dgvListaCheques.DataSource = ChequeBs;

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRegresarACliente_Click(object sender, EventArgs e)
        {
            var f = new FrmChr2(_idChequeSeleccionado.Value, AccionCheque.RetornoAClienteSr);
            f.ShowDialog();
        }
        private void btnAccion_Click(object sender, EventArgs e)
        {

        }
    }
}
