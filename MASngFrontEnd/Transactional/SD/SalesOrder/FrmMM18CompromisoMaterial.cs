using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.WM;

namespace MASngFE.Transactional.SD.SalesOrder
{
    public partial class FrmMM18CompromisoMaterial : Form
    {
        public FrmMM18CompromisoMaterial(int salesOrder, int idItemSalesOrder, string materialAKA, decimal kgPedidos)
        {
            _idSalesOrder = salesOrder;
            _idItemSalesOrder = idItemSalesOrder;
            _materialAKA = materialAKA;
            _materialPrimario = new MaterialMasterManager().GetPrimarioFromAka(materialAKA);
            _kgPedidos = kgPedidos;
            InitializeComponent();
            btnComprometer.Enabled = true;
            _modo = 1;
        }

        public FrmMM18CompromisoMaterial(string materialAKA)
        {
            _materialAKA = materialAKA;
            _materialPrimario = new MaterialMasterManager().GetPrimarioFromAka(materialAKA);
            InitializeComponent();
            btnComprometer.Enabled = false;
            _modo = 2;
        }

        private readonly int _modo;
        private readonly int _idSalesOrder;
        private readonly int _idItemSalesOrder;
        private readonly string _materialAKA;
        private readonly string _materialPrimario;
        private readonly decimal _kgPedidos;
        private int? _idStockSeleccionado = null;
        private StockStatusManager.EstadoLote? _estadoSeleccionado = null;
        private decimal _kgSeleccionados;
        public decimal KgReservados { get; private set; }

        private void FrmCompromisoMaterial_Load(object sender, EventArgs e)
        {
            this.dgvListaMateriales.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaMateriales_CellEnter);
            txtMaterial.Text = _materialAKA;
            txtSalesOrderNumber.Text = _idSalesOrder.ToString();
            txtKgSolicitiados.Text = _kgPedidos.ToString("N2");
            ckOnlyAvailable.Checked = true;
            dgvListaMateriales.DataSource = new StockList().GetAllByMaterial_DisponibleDespacho(_materialPrimario);
            //btnComprometer.Enabled = true;
            dgvListaMateriales.ClearSelection();
            txtKgComprometer.Text = 0.ToString("N2");
            this.dgvListaMateriales.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaMateriales_CellEnter);
        }

        private void dgvListaMateriales_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            _idStockSeleccionado = Convert.ToInt32(dgvListaMateriales[dgvListaMateriales.Columns["iDStockDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            _kgSeleccionados = Convert.ToDecimal(dgvListaMateriales[dgvListaMateriales.Columns["stockDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            txtKgComprometer.Text = _kgSeleccionados >= _kgPedidos ? _kgPedidos.ToString("N2") : _kgSeleccionados.ToString("N2");
            _estadoSeleccionado =
                StockStatusManager.MapStatusFromText(dgvListaMateriales[dgvListaMateriales.Columns["estadoDataGridViewTextBoxColumn"].Index, e.RowIndex]
                    .Value.ToString());
        }
        private void txtKgComprometer_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtKgComprometer_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgComprometer.Text))
            {
                KgReservados = 0;
                txtKgComprometer.Text = KgReservados.ToString("N2");
                return;
            }

            if (Convert.ToDecimal(txtKgComprometer.Text) > _kgSeleccionados)
            {
                MessageBox.Show(@"Los Kg indicados a comprometer sobrepasan el stock seleccionado",
                    @"Error en Seleccion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                KgReservados = 0;
                txtKgComprometer.Text = 0.ToString("N2");
                return;
            }

            if (Convert.ToDecimal(txtKgComprometer.Text) > _kgPedidos)
            {
                MessageBox.Show(@"Los Kg indicados a comprometer sobrepasan los Kg Solicitados por el Cliente",
                    @"Error en Seleccion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                KgReservados = 0;
                txtKgComprometer.Text = 0.ToString("N2");
                return;
            }
            KgReservados = Convert.ToDecimal(txtKgComprometer.Text);
        }
        private void btnComprometer_Click(object sender, EventArgs e)
        {
            if (_idStockSeleccionado == null)
            {
                MessageBox.Show(@"No se ha seleccionado una linea de Stock para comprometer",
                    @"Error en Seleccion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtKgComprometer.Text))
                txtKgComprometer.Text = 0.ToString("N2");

            KgReservados = Convert.ToDecimal(txtKgComprometer.Text);
            if (KgReservados <= 0)
            {
                MessageBox.Show(@"No se ha definido KG para Reservar Stock [Comprometer]",
                    @"Error en KG a Comprometer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dr = MessageBox.Show(@"Confirma la reserva de stock?", @"Reserva de Stock", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;

            //Reservar Stock para OV
            new CompromisoManager().ComprometeStock(_idStockSeleccionado.Value, Convert.ToDecimal(txtKgComprometer.Text), _idSalesOrder, _idItemSalesOrder);
            KgReservados = new CompromisoManager().GetKgComprometidosPorSalesOrder(_idSalesOrder, _idItemSalesOrder);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void ckOnlyAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOnlyAvailable.Checked)
            {
                dgvListaMateriales.DataSource = new StockList().GetAllByMaterial_DisponibleDespacho(_materialPrimario);
                if (_modo == 1)
                    btnComprometer.Enabled = true;
            }
            else
            {
                dgvListaMateriales.DataSource = new StockList().GetAllByMaterial(_materialPrimario);
                btnComprometer.Enabled = false;
            }
        }

        private void btnLiberarCompromiso_Click(object sender, EventArgs e)
        {
            if (_estadoSeleccionado == null)
            {
                MessageBox.Show(@"Debe Seleccionar una linea de stock para Liberar el Compromiso",
                    @"Error en Seleccion de Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_estadoSeleccionado)
            {
                case StockStatusManager.EstadoLote.Liberado:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.Restringido:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.FE:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.Comprometido:
                    if (MessageBox.Show(@"Confirma la liberacion de la linea de stock comprometida?", @"Liberar Stock Comprometido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        new CompromisoManager().FreeStockComprometidoByIdstock(_idStockSeleccionado.Value, true);
                        MessageBox.Show(@"Stock Liberado", @"Liberacion de Stock Comprometido", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    break;
                case StockStatusManager.EstadoLote.Reservado:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.ReservaPF:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case StockStatusManager.EstadoLote.ReservaRE:
                    MessageBox.Show(@"El Estado del lote seleccionado no permite esta acción!", @"Accion no permitida",
                      MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            KgReservados = new CompromisoManager().GetKgComprometidosPorSalesOrder(_idSalesOrder, _idItemSalesOrder);
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
