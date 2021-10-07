using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.MM
{
    public partial class FrmMM67FasonExternoMain : Form
    {
        public FrmMM67FasonExternoMain()
        {
            InitializeComponent();
            txtStatus.Text = FasonExternoStatusManager.Status.Inicial.ToString();
            _idf = 0;
        }

        public FrmMM67FasonExternoMain(int idF)
        {
            _idf = idF;
            InitializeComponent();
        }

        private decimal _kgOriginal = 0;
        private int _idf;


        private void FrmMM67FasonExternoMain_Load(object sender, EventArgs e)
        {
            BindingSource bs1 = new BindingSource();
            BindingSource bs2 = new BindingSource();
            bs1.DataSource = new MaterialMasterManager().GetCompleteListMaterialAvailable();
            bs2.DataSource = new MaterialMasterManager().GetCompleteListMaterialAvailable();
            cmbMaterialEnviar.DataSource = bs1;
            cmbProductoRecibir.DataSource = bs2;
            cmbMaterialEnviar.SelectedIndex = -1;
            cmbProductoRecibir.SelectedIndex = -1;
            t0005MPROVEEDORESBindingSource.DataSource = new VendorManager().GetListVendorByVendorType("DIRECTOS", true);
            cmbProveedor.SelectedIndex = -1;
            if (_idf > 0)
            {
                //mapear datos de idF Existente
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (ValidaCompleto() == false)
                return;

            if (_idf == 0)
            {
                _idf = new FasonExternoMng().SaveData(MapScreen());
                //baja el stock
                new StockManager().TomaLineaStock(Convert.ToInt32(txtIdStock.Text), cKgEnviar.GetValueDecimal,
                    StockStatusManager.EstadoLote.Liberado);
                new MmLog().LogEnvioFason(Convert.ToInt32(txtIdStock.Text), cKgEnviar.GetValueDecimal,
                    txtNumeroRemito.Text, Convert.ToInt32(cmbProveedor.SelectedValue), "OFE", "Envio a Fason");
                new StockManager().DeleteStockLine(Convert.ToInt32(txtIdStock.Text));
                txtStatus.Text = FasonExternoStatusManager.Status.Generada.ToString();
                txtIdFE.Text = _idf.ToString();
                btnGenerar.Enabled = false;
                MessageBox.Show($@"Se ha Generado la Orden de Fason Externo numero {_idf}", @"OFE Generada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(@"Accion no permitida");
            }

        }

        private bool ValidaCompleto()
        {
            if (cmbMaterialEnviar.SelectedValue == null)
            {
                MessageBox.Show(@"Debe proveer el mateiral a enviar (MP)", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (string.IsNullOrEmpty(txtLoteSeleciconado.Text))
            {
                MessageBox.Show(@"Debe Seleccionar un Lote a Enviar", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (cKgEnviar.GetValueDecimal == 0)
            {
                MessageBox.Show(@"Debe Seleccionar una cantidad a Enviar", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (cmbProductoRecibir.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccioar el Codigo de Producto con el que será Re-Ingresado este material", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (cCantidadRecibir.GetValueDecimal == 0)
            {
                MessageBox.Show(@"Debe Seleccionar una cantidad Aproximada para Recibir", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (string.IsNullOrEmpty(txtNumeroRemito.Text))
            {
                MessageBox.Show(@"Debe Proveer un numero de Remito", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        private T0077_FASONEXT_H MapScreen()
        {
            var s = new T0077_FASONEXT_H()
            {
                IDF = _idf,
                Material = cmbMaterialEnviar.SelectedValue.ToString(),
                CantidadE = cKgEnviar.GetValueDecimal,
                FechaE = dtpFecha.Value,
                LoteE = txtLoteSeleciconado.Text,
                CantidadARecibir = cCantidadRecibir.GetValueDecimal,
                CantidadRecibida = 0,
                MaterialARecibir = cmbProductoRecibir.SelectedValue.ToString(),
                Proveedor = Convert.ToInt32(cmbProveedor.SelectedValue),
                ProveedorFason = Convert.ToInt32(cmbProveedor.SelectedValue),
                RemitoE = txtNumeroRemito.Text,
                StatusFason = ""
            };
            return s;
        }


        private void cmbMaterialEnviar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterialEnviar.SelectedIndex == -1)
            {
                t0030STOCKBindingSource.DataSource = null;
                return;
            }
            t0030STOCKBindingSource.DataSource = new StockManager().GetListaStockT0030(cmbMaterialEnviar.SelectedValue.ToString());
        }

        private void cmbProductoRecibir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductoRecibir.SelectedIndex == -1)
            {
                return;
            }
        }

        private void dgvListaMaterial_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                txtLoteSeleciconado.Text = null;
                cKgEnviar.SetValue = 0;
                cmbProveedor.SelectedIndex = -1;
                cmbProductoRecibir.SelectedIndex = -1;
                btnGenerar.Enabled = false;
                _kgOriginal = 0;
                return;
            }
            txtLoteSeleciconado.Text = dgv[batchDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            cKgEnviar.SetValue = Convert.ToDecimal(dgv[stockDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            txtSloc.Text = dgv[sLOCDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            _kgOriginal = Convert.ToDecimal(dgv[stockDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            txtIdStock.Text = dgv[iDStockDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
        }

        private void cKgEnviar_Validating(object sender, CancelEventArgs e)
        {
            var valor = (CtlTextBox)sender;
            if (cKgEnviar.GetValueDecimal > _kgOriginal)
            {
                MessageBox.Show(@"No se puede enviar una cantidad mayor a los Kg de la linea seleccionada", @"Datos Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
            }
        }

        private void cCantidadRecibir_Validating(object sender, CancelEventArgs e)
        {
            cDiferenciaPorc.SetValue = cCantidadRecibir.GetValueDecimal / cKgEnviar.GetValueDecimal;
        }

        private void txtNumeroRemito_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show(@"Complete correctamente el numero de Remito", @"Datos Incorrecto", MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (_idf > 0)
            {
                FasonExternoStatusManager.SetEnviada(_idf);
                txtStatus.Text = FasonExternoStatusManager.Status.Enviado.ToString();
            }
            else
            {
                MessageBox.Show(@"No se puede enviar una Orden de Fason Externo sin Generar", @"Datos Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_idf == 0)
            {
                MessageBox.Show(@"No se puede Cancelar una Orden de Fason Externo sin Generar", @"Datos Incorrectos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            var m = MessageBox.Show(@"Desea Cancelar esta Orden de Fason Externo?", @"Cancelacion de OFE",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (m == DialogResult.No)
                return;

            FasonExternoStatusManager.SetCancel(_idf);
            txtStatus.Text = FasonExternoStatusManager.Status.Cancelada.ToString();

        }
    }
}

