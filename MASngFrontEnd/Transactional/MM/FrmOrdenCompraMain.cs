using System;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.MM
{
    public partial class FrmOrdenCompraMain : Form
    {
        public FrmOrdenCompraMain(int modo, int idProveedor, int numeroOC = 0)
        {
            InitializeComponent();
            _modo = modo;
            _numeroOC = numeroOC;
            _idProveedor = idProveedor;
        }

        private int _modo;
        private int _numeroOC;
        private int _idProveedor;
        public T0060_OCOMPRA_H Header = new T0060_OCOMPRA_H();

        private void CargaDatosProveedor()
        {
            var data = new VendorManager().GetSpecificVendor(_idProveedor);
            txtProveedor.Text = data.prov_rsocial;
            txtDireccion.Text = data.Direccion + @" - " + data.Dire_Localidad;
            txtNombreContacto.Text = data.Contacto;
            txtTelefonoContacto.Text = data.Telefono;
            txtEmail.Text = data.EMAIL;
        }

        private void AccionSegunEstadoOC()
        {
            //var och = oc.GetDataOcHeader(_numeroOC);

            switch (OrdenCompraStatusManager.MapStatusHeaderFromText(txtEstadoOC.Text))
            {
                case OrdenCompraStatusManager.StatusHeader.Inicial:
                    btnAgregarMaterial.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnEmitirOC.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnSalir.Enabled = true;
                    dtpFechaOC.Enabled = true;
                    cmbMonedaOC.Enabled = true;
                    break;
                case OrdenCompraStatusManager.StatusHeader.Emitida:
                    btnAgregarMaterial.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnEmitirOC.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnSalir.Enabled = true;
                    dtpFechaOC.Enabled = false;
                    cmbMonedaOC.Enabled = false;
                    break;
                case OrdenCompraStatusManager.StatusHeader.Proceso:
                    btnAgregarMaterial.Enabled = true;
                    btnCancelar.Enabled = true;
                    btnEmitirOC.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnSalir.Enabled = true;
                    dtpFechaOC.Enabled = false;
                    cmbMonedaOC.Enabled = false;
                    break;
                case OrdenCompraStatusManager.StatusHeader.Cerrada:
                    btnAgregarMaterial.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEmitirOC.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnSalir.Enabled = true;
                    dtpFechaOC.Enabled = false;
                    cmbMonedaOC.Enabled = false;
                    break;
                case OrdenCompraStatusManager.StatusHeader.Cancelada:
                    btnAgregarMaterial.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEmitirOC.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnSalir.Enabled = true;
                    dtpFechaOC.Enabled = false;
                    cmbMonedaOC.Enabled = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private OrdenCompraManager _oc = new OrdenCompraManager();
        private void FrmOrdenCompraMain_Load(object sender, EventArgs e)
        {
            CargaDatosProveedor();

            switch (_modo)
            {
                case 1:
                    txtEstadoOC.Text = OrdenCompraStatusManager.StatusItem.Inicial.ToString();
                    txtEstadoOC.BackColor = Color.Yellow;
                    cmbMonedaOC.SelectedIndex = 0; //ARS
                    txtTC.Text = new ExchangeRateManager().GetExchangeRate(dtpFechaOC.Value).ToString();

                    break;

                case 2:
                    //Dependiendo el estado de la OC
                    CargaDatosHeaderOC();
                    AccionSegunEstadoOC(); //Setea botones segun estado OC
                    OCItemBS.DataSource = new OrdenCompraManager().GetListItemsOC(_numeroOC);
                    break;
                case 3:
                    CargaDatosHeaderOC();
                    //Siempre read only
                    btnAgregarMaterial.Enabled = false;
                    btnCancelar.Enabled = false;
                    btnEmitirOC.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnSalir.Enabled = true;
                    OCItemBS.DataSource = new OrdenCompraManager().GetListItemsOC(_numeroOC);
                    break;
                default:
                    break;
            }
        }
        private void CargaDatosHeaderOC()
        {
            var och = _oc.GetDataOcHeader(_numeroOC);
            txtNumeroOC.Text = _numeroOC.ToString();
            txtEstadoOC.Text = och.STATUSOC;
            cmbMonedaOC.Text = och.MONEDAOC;
            txtImporteTotal.Text = new FormatAndConversions().SetCurrency(och.TotalOC);
            dtpFechaOC.Value = och.FECHAOC.Value;
            txtTC.Text = och.TC.ToString();
        }

        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            var statusOC = OrdenCompraStatusManager.MapStatusHeaderFromText(txtEstadoOC.Text);
            if (statusOC == OrdenCompraStatusManager.StatusHeader.Inicial)
            {
                InicializarOC();
                if (_numeroOC <= 1)
                {
                    MessageBox.Show(@"Ocurrio un error al Inicializar la OC", @"Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var f2 = new FrmOrdenCompraDetalleItem(_numeroOC, 0, 1);
            f2.ShowDialog();
            OCItemBS.DataSource = new OrdenCompraManager().GetListItemsOC(_numeroOC);
        }

        public void InicializarOC()
        {
            if (ValidaDatosCompletosInicializar() == true)
            {
                txtEstadoOC.Text = OrdenCompraStatusManager.StatusHeader.Proceso.ToString();
                txtEstadoOC.BackColor = Color.DarkSeaGreen;
                Header.STATUSOC = "Proceso";
                Header.FECHAOC = dtpFechaOC.Value;
                //Header.FECHA_RECIBIDO = null;
                Header.MONEDAOC = cmbMonedaOC.Text;
                Header.PROVEEDOR = _idProveedor;
                Header.TC = Convert.ToDecimal(txtTC.Text);
                Header.TotalOC = 0;
                Header.IDORDENCOMPRA = _oc.InicializaOC(Header);
                _numeroOC = Header.IDORDENCOMPRA;
                txtNumeroOC.Text = _numeroOC.ToString();
            }
        }

        private bool ValidaDatosCompletosInicializar()
        {
            if (dtpFechaOC.Value < DateTime.Today.AddDays(-5))
            {
                MessageBox.Show(@"La Fecha de la Orden de Compra NO PUEDE ser mas antigua que 5 dias de la fecha actual", @"Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void dgvItemsOC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                switch (senderGrid.Columns[e.ColumnIndex].Name)
                {
                    case "btnEdit":
                        int modoItem;
                        var cellValue = dgvItemsOC[0, e.RowIndex];
                        if (_modo < 3)
                        {
                            modoItem = 2;
                        }
                        else
                        {
                            modoItem = 3;
                        }
                        var f2 = new FrmOrdenCompraDetalleItem(_numeroOC, Convert.ToInt32(cellValue.Value), modoItem);
                        f2.ShowDialog();
                        OCItemBS.DataSource = new OrdenCompraManager().GetListItemsOC(_numeroOC);

                        break;
                    default:
                        break;
                }
#pragma warning disable CS0219 // The variable 'a' is assigned but its value is never used
                var a = 1;
#pragma warning restore CS0219 // The variable 'a' is assigned but its value is never used
                var x = senderGrid.Columns[e.ColumnIndex].Name;

                //TODO - Button Clicked - Execute Code Here
            }
        }

        private void OCItemBS_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimirOC_Click(object sender, EventArgs e)
        {
            var f2 = new RpvOrdenCompra(_numeroOC);
            f2.Show();
        }

        private void btnEmitirOC_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("Confirma la Emision de Orden de Compra?", @"Emision OC", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                new OrdenCompraStatusManager().SetStatusHeaderToEmitida(_numeroOC);
                MessageBox.Show(@"Se ha Emitido la Orden de Compra - Recuerde enviarla al proveedor", @"Emision OC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEmitirOC.Enabled = false;
                btnImprimirOC.Enabled = true;
                CargaDatosHeaderOC();
            }
            else
            {
                return;
            }
        }
    }
}
