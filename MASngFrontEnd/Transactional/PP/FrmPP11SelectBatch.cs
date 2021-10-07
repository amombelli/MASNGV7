using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Transactional.WM;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP11SelectBatch : Form
    {
        public FrmPP11SelectBatch(string material, decimal kgRequeridosOF, int numeroOF, bool onlyKgMayorARequerido)
        {
            InitializeComponent();
            _kgRequeridosOF = kgRequeridosOF;
            _numeroOF = numeroOF;
            _onlyKgMayorReq = onlyKgMayorARequerido;
            txtMateriaPrima.Text = material;
        }

        //------------------------------------------------------------------------------------------------
        private readonly decimal _kgRequeridosOF;

        //private decimal _kgPendientesSeleccion;
        //private decimal _kgLineaSeleccionada;
        private readonly bool _onlyKgMayorReq;
        private readonly int _numeroOF;
        private int _numeroOFReservadaLiberar = 0;
        private List<T0030_STOCK> _stockList = new List<T0030_STOCK>();
        

        public decimal KgSeleccionados  {get;private set;} 
        public int IdstockSeleccionado { get;private set; }
        
        //------------------------------------------------------------------------------------------------
        private void FrmSeleccionBatch_Load(object sender, EventArgs e)
        {
            txtNumeroOF.Text = _numeroOF.ToString();
            var xplan = PlanProduccionListManager.GetOFData(_numeroOF);
            txtMaterialOF.Text = xplan.MATERIAL;
            txtKgRequeridos.Text = _kgRequeridosOF.ToString("N2");

            this.dgvStockDisponible.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockDisponible_CellEnter);

            if (_onlyKgMayorReq)
            {
                ckSoloStockMayorIgual.Checked = true;
                ckSoloStockMayorIgual.AutoCheck = false;
                cKgUtilizar.XReadOnly = true;
                cKgUtilizar.BackColor= Color.LightGray;
                cKgUtilizar.ForeColor= Color.Black;
            }
            else
            {
                ckSoloStockMayorIgual.Checked = false;
                ckSoloStockMayorIgual.AutoCheck = true;
                cKgUtilizar.XReadOnly = false;
                cKgUtilizar.BackColor = Color.White;
                cKgUtilizar.ForeColor= Color.Navy;
                
            }
            this.dgvStockDisponible.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockDisponible_CellEnter);
            ckSoloDisponible.Checked = true;
        }
        private void dgvStockDisponible_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStockDisponible.SelectedCells.Count == 0)
            {
                //deshabilitar todos los botenes
                btnLiberarReservaN.Enabled = false;
                btnMoverStockN.Enabled = false;
                btnUninficarLotesN.Enabled = false;
                btnConfirmarN.Enabled = false;
                IdstockSeleccionado = -1;
                KgSeleccionados = 0;
                return;
            }

            IdstockSeleccionado = Convert.ToInt32(dgvStockDisponible[__idStock.Name, e.RowIndex].Value);
            btnMoverStockN.Enabled = true;
            btnUninficarLotesN.Enabled = true;
            //
            var ofReservaSeleccion = dgvStockDisponible[__reservaOF.Name, e.RowIndex].Value;
            var kgSeleccion = Convert.ToDecimal(dgvStockDisponible[__stock.Name, e.RowIndex].Value);
            cKgSeleccionados.SetValue = kgSeleccion;

            if (ofReservaSeleccion == null)
            {
                txtOFReservaSeleccion.Text = null;
                if (kgSeleccion > 0)
                {
                    btnConfirmarN.Enabled = true;
                }
                txtMaterialSeleccion.Text = dgvStockDisponible[__Material.Name, e.RowIndex].Value.ToString();
                txtLoteSeleccionado.Text = dgvStockDisponible[__lote.Name, e.RowIndex].Value.ToString();
                txtOFReservaSeleccion.Text = null;
                txtMaterialOfReserva.Text = null;
                txtStatusOfReserva.Text = null;

                btnMoverStockN.Enabled = true;
            }
            else
            {
                btnLiberarReservaN.Enabled = true;
                btnMoverStockN.Enabled = false;
                txtOFReservaSeleccion.Text = ofReservaSeleccion.ToString();
                txtMaterialSeleccion.Text = dgvStockDisponible[__Material.Name, e.RowIndex].Value.ToString();
                txtLoteSeleccionado.Text = dgvStockDisponible[__lote.Name, e.RowIndex].Value.ToString();
                txtOFReservaSeleccion.Text = ofReservaSeleccion.ToString();
                var xplan = PlanProduccionListManager.GetOFData(Convert.ToInt32(txtLoteSeleccionado.Text));
                txtMaterialOfReserva.Text = xplan.MATERIAL;
                txtStatusOfReserva.Text = xplan.STATUS;
            }

            
            if (kgSeleccion > _kgRequeridosOF)
            {
                cKgUtilizar.SetValue = _kgRequeridosOF;
                cKgPendientes.SetValue = 0;
                KgSeleccionados = _kgRequeridosOF;
                cIconoKgOk.Set = CIconos.Tilde;
            }
            else
            {
                if (kgSeleccion == 0)
                {
                    btnConfirmarN.Enabled = false;
                    cIconoKgOk.Set = CIconos.Rojo;
                    cKgUtilizar.SetValue = kgSeleccion;
                    cKgPendientes.SetValue = _kgRequeridosOF;
                    btnMoverStockN.Enabled = false;
                }
                else
                {
                    cKgUtilizar.SetValue = kgSeleccion;
                    cKgPendientes.SetValue = _kgRequeridosOF - kgSeleccion;
                    KgSeleccionados = kgSeleccion;
                    btnMoverStockN.Enabled = true;
                    cIconoKgOk.Set = CIconos.Verde;
                }
            }
        }
        private void ckSoloDisponible_CheckedChanged(object sender, EventArgs e)
        {
            ckSoloDisponible.BackColor = ckSoloDisponible.Checked ? Color.DarkSeaGreen : Color.Pink;
            RefrescaDataGridNew(true);
        }
        private void ckSoloStockMayorIgual_CheckedChanged(object sender, EventArgs e)
        {
            ckSoloStockMayorIgual.BackColor = ckSoloStockMayorIgual.Checked ? Color.DarkSeaGreen : Color.Pink;
            RefrescaDataGridNew(true);

        }
        private void RefrescaDataGridNew(bool getNewList = false)
        {
            if (getNewList)
            {
                //trae de nuevo el listado de materiales
                _stockList = ckSoloDisponible.Checked
                    ? new StockList().GetAllByMaterial_DisponibleProduccion(txtMateriaPrima.Text).ToList()
                    : new StockList().GetAllByMaterial(txtMateriaPrima.Text).ToList();
            }

            t0030STOCKBindingSource.DataSource = ckSoloStockMayorIgual.Checked
                ? _stockList.Where(c => c.Stock >= _kgRequeridosOF).ToList()
                : _stockList;
        }
        private void txtFiltroLote_KeyUp(object sender, KeyEventArgs e)
        {
            t0030STOCKBindingSource.DataSource =
                _stockList.Where(c => c.Batch.ToUpper().Contains(txtFiltroLote.Text.ToUpper())).ToList();
        }
        private void btnMoverStockN_Click(object sender, EventArgs e)
        {
            if (IdstockSeleccionado == 0)
            {
                MessageBox.Show(@"Debe Seleccionar una Linea de Stock", @"Error en Seleccion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var f2 = new FrmWm01MoveStock(IdstockSeleccionado, "OF");
            f2.ShowDialog();
            RefrescaDataGridNew(true);
        }
        private void btnUninficarLotesN_Click(object sender, EventArgs e)
        {
            new StockManager().OptimizaStockLiberado(txtMateriaPrima.Text);
            RefrescaDataGridNew(true);
        }
        private void btnConfirmarN_Click(object sender, EventArgs e)
        {
            if (cKgUtilizar.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Los Kg a utilizar deben ser mayor a 0.00 Kg", @"Atencion con la Seleccion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnSalirCancelarN_Click(object sender, EventArgs e)
        {
            IdstockSeleccionado = 0;
            KgSeleccionados = 0;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnLiberarReservaN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOFReservaSeleccion.Text))
            {
                MessageBox.Show(@"No se puede liberar ninguna reserva", @"Stock No tiene Reserva", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            int numeroOFReserva = Convert.ToInt32(txtOFReservaSeleccion.Text);
            if (numeroOFReserva == 0)
            {
                MessageBox.Show(
                    @"Esta Accion no se puede realizar porque la linea de stock no esta reservada para ninguna OF",
                    @"Accion Invalida", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (numeroOFReserva == _numeroOF)
            {
                //libera lote... boton fuera
                MessageBox.Show(@"El Lotes previamente seleccionado será liberado!", @"Liberacion de Reserva de Lote",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Abort;
                this.Close();

                //se debe liberar al salir de esta pantalla ?! 
            }
            else
            {
                var dialogResult = MessageBox.Show($@"Confirma la liberacion de LOTE# {txtLoteSeleccionado.Text} Reservado para OF# {numeroOFReserva}?",
                        @"Liberacion de Lote Reservado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    new ReservaStockOF().LiberaStockReservadoOF(txtMateriaPrima.Text, _numeroOFReservadaLiberar);
                    RefrescaDataGridNew(true);
                }
                else
                {
                    MessageBox.Show(@"Se ha cancelado la operacion", @"Operacion cancelada por el Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void cKgUtilizar_Validated(object sender, EventArgs e)
        {
            if (cKgSeleccionados.GetValueDecimal >= cKgUtilizar.GetValueDecimal)
            {
                cKgPendientes.SetValue = 0;
            }
            else
            {
                cKgPendientes.SetValue = _kgRequeridosOF - cKgUtilizar.GetValueDecimal;
            }
            KgSeleccionados = cKgUtilizar.GetValueDecimal;
            cIconoKgOk.Set = CIconos.Tilde;
        }
        private void cKgUtilizar_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cKgUtilizar.GetValueDecimal > _kgRequeridosOF)
            {
                ep1.SetError(cKgUtilizar,"La Cantidad no puede superar al Maximo Requerido");
                e.Cancel = true;
                return;
            }
            ep1.SetError(cKgUtilizar,"");

        }
    }
}







                   

