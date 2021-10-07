using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional
{
    public partial class FrmMm0Accion : Form
    {
        public FrmMm0Accion(int modo, int idstock)
        {
            _idstock = idstock;
            _modo = modo;
            InitializeComponent();
        }

        private readonly int _idstock;
        private readonly int _modo;

        #region Botones

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        #endregion

        private void FrmMm0Accion_Load(object sender, EventArgs e)
        {
            LoadInitialData();
            panelMoverSloc.Visible = false;
        }
        private void LoadInitialData()
        {
            var stk = StockManager.GetStockLine(_idstock);
            if (stk == null)
                throw new Exception("Invalid Stock Line *T0030* idStock no existe");

            var mmdata = new MaterialMasterManager().GetPrimarioInfo(stk.Material);

            txtPrimario.Text = stk.Material;
            txtEstado.Text = stk.Estado;
            txtKgSeleccionados.Text = stk.Stock.ToString();
            txtSloc.Text = stk.SLOC;
            txtMaterialType.Text = mmdata.TIPO_MATERIAL;
            txtDescripcionInterna.Text = mmdata.MAT_DESC;
            txtNumeroLote.Text = stk.Batch;

            btnAjustarStock.Enabled = true;
            btnCambiarEstado.Enabled = true;
            btnCambiarLote.Enabled = true;
            btnAjustarStock.Enabled = true;

            txtUser.Text = Environment.UserName;
            //
            panelAjusteKg.Visible = false;
            panelCambiarEstado.Visible = false;
            panelModificarLote.Visible = false;
            panelMoverSloc.Visible = false;
            //
        }





        #region movimientoStock
        private void ConfiguraAccionMoverUbicacion()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQSLOC"))
                return;

            lblAccion0.Text = @"MOVIMIENTO DE UBICACION";
            lblAccion1.Text = @"USUARIO HABILITDO - CQSLOC";
            panelMoverSloc.Visible = true;
            panelModificarLote.Visible = false;
            panelCambiarEstado.Visible = false;
            panelAjusteKg.Visible = false;
            t0028SLOCBindingSource.DataSource = new StorageLocationManager().ListOfLoc();
            cmbNewSloc.DataSource = t0028SLOCBindingSource;
        }
        private void brnMoverUbicacion_Click(object sender, EventArgs e)
        {
            ConfiguraAccionMoverUbicacion();
        }
        private void txtCantidadMover_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtCantidadMover_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidadMover.Text))
                txtCantidadMover.Text = 0.ToString("N2");
            if (Convert.ToDecimal(txtCantidadMover.Text) > Convert.ToDecimal(txtKgSeleccionados.Text))
            {
                MessageBox.Show(@"La cantidad a mover supera la cantidad seleccionada", @"Error en Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidadMover.Text = txtKgSeleccionados.Text;
            }
        }
        private void btnMoverASloc_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show(@"Confirma el movimiento de Stock entre ubicaciones?",
                @"Movimiento de Stock",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            var x = new StockMovements();
            var log40 = x.MoveSloc(_idstock, Convert.ToDecimal(txtCantidadMover.Text),
                cmbNewSloc.SelectedValue.ToString(), "MM0");
            if (log40 > 0)
                MessageBox.Show(@"Se ha realizado correctamente el movimiento de materiales", @"Cambio de Ubicaciones",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region CambiarEstado
        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            ConfiguraAccionCambiarEstadoLote();
        }
        private void txtKgCambiarEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtKgCambiarEstado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgCambiarEstado.Text))
                txtKgCambiarEstado.Text = 0.ToString("N2");
            if (Convert.ToDecimal(txtKgCambiarEstado.Text) > Convert.ToDecimal(txtKgSeleccionados.Text))
            {
                MessageBox.Show(@"La cantidad a Cambiar de Estado supera la cantidad seleccionada", @"Error en Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKgCambiarEstado.Text = txtKgSeleccionados.Text;
            }
        }
        private void ConfiguraAccionCambiarEstadoLote()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQESTCHNG"))
                return;

            lblAccion0.Text = @"CAMBIO DE ESTADO LOTE - LAB";
            lblAccion1.Text = @"USUARIO HABILITADO - CQESTCHNG";
            panelMoverSloc.Visible = false;
            panelCambiarEstado.Visible = true;
            panelModificarLote.Visible = false;
            panelAjusteKg.Visible = false;
            txtKgCambiarEstado.Text = txtKgSeleccionados.Text;
            var estadoActual = StockStatusManager.MapStatusFromText(txtEstado.Text);
            switch (estadoActual)
            {
                case StockStatusManager.EstadoLote.Liberado:
                    cmbNewEstado.Items.Add("RESTRINGIDO");
                    cmbNewEstado.Items.Add("FE");
                    break;
                case StockStatusManager.EstadoLote.Restringido:
                    cmbNewEstado.Items.Add("LIBERADO");
                    cmbNewEstado.Items.Add("FE");
                    break;
                case StockStatusManager.EstadoLote.FE:
                    cmbNewEstado.Items.Add("LIBERADO");
                    cmbNewEstado.Items.Add("RESTRINGIDO");
                    break;
                case StockStatusManager.EstadoLote.Comprometido:
                    MessageBox.Show(@"El estado del stock no permite cambiar su estado mediante esta funcion",
                        @"Cambio de eStado Invalido", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                case StockStatusManager.EstadoLote.Reservado:
                    MessageBox.Show(@"El estado del stock no permite cambiar su estado mediante esta funcion",
                        @"Cambio de eStado Invalido", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                case StockStatusManager.EstadoLote.ReservaPF:
                    MessageBox.Show(@"El estado del stock no permite cambiar su estado mediante esta funcion",
                        @"Cambio de eStado Invalido", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                case StockStatusManager.EstadoLote.ReservaRE:
                    MessageBox.Show(@"El estado del stock no permite cambiar su estado mediante esta funcion",
                        @"Cambio de eStado Invalido", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void btnMoverEstado_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show(@"Confirma el Cambio de Estado?",
              @"Movimiento/Cambio de Stock",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            var x = new StockMovements();
            var log40 = x.MoveEstado(_idstock, Convert.ToDecimal(txtKgCambiarEstado.Text),
                StockStatusManager.MapStatusFromText(cmbNewEstado.Text), "MM0");
            if (log40 > 0)
                MessageBox.Show(@"Se ha realizado correctamente el Cambio de Estado del Material", @"Cambio de Estado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region CambiarLote
        private void btnCambiarLote_Click(object sender, EventArgs e)
        {
            ConfiguraAccionModificarLote();
        }
        private void txtKgCambiarLote_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgCambiarLote.Text))
                txtKgCambiarLote.Text = 0.ToString("N2");
            if (Convert.ToDecimal(txtKgCambiarLote.Text) > Convert.ToDecimal(txtKgSeleccionados.Text))
            {
                MessageBox.Show(@"La cantidad a Cambiar de LOTE supera la cantidad seleccionada", @"Error en Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKgCambiarLote.Text = txtKgSeleccionados.Text;
            }
        }
        private void txtKgCambiarLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void ConfiguraAccionModificarLote()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQLOTECHNG"))
                return;

            lblAccion0.Text = @"CAMBIO DE NUMERO DE LOTE - SUP";
            lblAccion1.Text = @"USUARIO HABILITADO - CQLOTECHNG";
            panelAjusteKg.Visible = false;
            panelCambiarEstado.Visible = false;
            panelModificarLote.Visible = true;
            panelMoverSloc.Visible = false;
            txtKgCambiarLote.Text = txtKgSeleccionados.Text;
        }
        private void btnModificarLote_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show(@"Debe completar un comentario/observacion para el LOG del movimiento",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var respuesta = MessageBox.Show(@"Confirma La MODIFICACION DEL NUMERO DE LOTE?",
                        @"Movimiento/Cambio de Stock",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            var x = new StockMovements();
            var log40 = x.ChangeLote(_idstock, Convert.ToDecimal(txtKgCambiarLote.Text),
                txtNuevoNumeroLote.Text, "MM0");
            if (log40 > 0)
                MessageBox.Show(@"Se ha realizado correctamente el Cambio de LOTE del MATERIAL", @"Cambio de LOTE",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region AjusteStock 

        private void btnAjustarStock_Click(object sender, EventArgs e)
        {
            ConfiguraAccionAjusteStock();
        }

        private void txtKgFinalesStock_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgFinalesStock.Text))
                txtKgFinalesStock.Text = 0.ToString("N2");

            decimal kgStock = Convert.ToDecimal(txtKgFinalesStock.Text);

            if (kgStock < 0)
            {
                MessageBox.Show(@"El nuevo valor de Kg del material no puede ser menor a CERO kg!", @"Error en Ajuste",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var kgAjuste = kgStock - Convert.ToDecimal(txtKgSeleccionados.Text);
            if (kgAjuste == 0)
            {
                MessageBox.Show(@"El VALOR del AJUSTE no puede ser CERO", @"Error en Ajuste",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtKgAjuste.Text = kgAjuste.ToString("N2");
            if (kgAjuste > 0)
            {
                //ajuste +
            }
            else
            {
                //ajuste -
            }
        }

        private void txtKgFinalesStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void ConfiguraAccionAjusteStock()
        {
            if (!TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQSTKAJUSTE"))
                return;

            lblAccion0.Text = @"AJUSTE DE STOCK - SUP";
            lblAccion1.Text = @"USUARIO HABILITADO - CQSTKAJUSTE";
            panelMoverSloc.Visible = false;
            panelCambiarEstado.Visible = false;
            panelModificarLote.Visible = false;
            panelAjusteKg.Visible = true;
            txtKgCambiarLote.Text = txtKgSeleccionados.Text;
        }

        private void btnAjustarKgStock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show(@"Debe completar un comentario/observacion para el LOG del movimiento",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var respuesta =
                MessageBox.Show(
                    @"Confirma el AJUSTE de los KG Seleccionados?" + Environment.NewLine + Environment.NewLine +
                    @"Este movimiento generara un asiento de ajuste contable de $ imputado a la perdida de diferencia de stock",
                    @"Movimiento/Cambio de Stock",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
                return;

            var asiento = new AsientoAjusteStock("MM0").Ajuste(txtPrimario.Text, Convert.ToDecimal(txtKgAjuste.Text),
                txtObservacion.Text);

            if (asiento.IdDocu > 0)
            {
                txtNumeroAsiento.Text = asiento.IdDocu.ToString();

                var x = new StockMovements();
                var log40 = x.AjusteKgStock(_idstock, Convert.ToDecimal(txtKgFinalesStock.Text), "MM0", true,
                    txtObservacion.Text);
                if (log40 > 0)
                    MessageBox.Show(
                        @"Se ha realizado correctamente el AJUSTE DE STOCK. Tome nota del asiento generado y reportelo.",
                        @"AJUSTE DE STOCK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    @"Ha ocurrido un error al generar el asiento contable de Ajuste de Stock y no se ha realizado el ajuste de stock",
                    @"Error en Ajuste de Stock", MessageBoxButtons.OK);
            }
        }




        #endregion

        private void btnComprometerMaterial_Click(object sender, EventArgs e)
        {

        }

        private void btnLiberarCompromiso_Click(object sender, EventArgs e)
        {

        }
    }
}
