using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.MasterData.Vendor;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.MM.Ingreso_de_Stock
{
    public partial class FrmMM30IngresoStockOC : Form
    {
        public FrmMM30IngresoStockOC(int modo)
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------
        private int _idVendor;
        private bool _refreshCombo = false;
        private DateTime fechaRemito;
        private DateTime fechaEntrega;
        private string numeroRemito;
        private string resp;
        private int idFasonRecibir = 0;

        //---------------------------------------------------------------------------------

        private void FrmMM30IngresoStockOC_Load(object sender, EventArgs e)
        {
            dtpFechaRecepcion.MinDate = DateTime.Today.AddDays(-100);
            uDecKgRecibidos.Init(0, 50000, 2);
            cmbMaterial.DataSource = new MaterialTypeManager().GetListMaterialAvailableToBuy();
            cmbRazonSocial.DataSource = new VendorManager().GetListVendorsWithOrdenCompra();
            cmbRecibidoPor.DataSource = new HumanResourcesManager().GetListAllActivePermiteControlIc();
            cmbRecibidoPor.SelectedValue = "JFILARDO";
            cmbSloc.DataSource = new StorageLocationManager().ListOfLocAvailableToIC();
            //cmbSloc.SelectedIndex = -1;
            cmbRazonSocial.SelectedIndex = -1;
            cmbMaterial.SelectedIndex = -1;
            BlanqueaDatosSeleccion();
        }

        private void BlanqueaDatosSeleccion()
        {
            if (txtFechaRemitoReal.Fecha != null)
                fechaRemito = txtFechaRemitoReal.Fecha.Value;
            fechaEntrega = dtpFechaRecepcion.Value;
            numeroRemito = txtNumeroRemito.Text;
            resp = cmbRecibidoPor.SelectedValue.ToString();
            dgvDetalleOC.ClearSelection();
            txtNumeroOC.Text = null;
            txtFechaEmision.Text = null;
            txtEstadoOC.Text = null;
            txtMaterial.Text = null;
            txtStatusItemOC.Text = null;
            txtIdItemOC.Text = null;
            txtObservacion.Text = null;
            txtCantidadRecibida.Text = 0.ToString("N2");
            txtCantidadPedida.Text = 0.ToString("N2");
            txtCantidadPendiente.Text = 0.ToString("N2");
            txtPlaninspeccion.Text = null;
            //
            txtNumeroRemito.Text = null;
            uDecKgRecibidos.Text = 0.ToString("N2");
            txtLoteProveedor.Text = null;
            txtLoteTecser.Text = null;
            cmbSloc.SelectedIndex = -1;
            cmbStatus.SelectedValue = null;
            ckEntregaParcial.Checked = false;
            ckLiberarStock.Checked = false;
            ckReproceso.Checked = false;
            cmbStatus.SelectedItem = "Restringido";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRazonSocial.SelectedIndex == -1)
            {
                _idVendor = 0;
                txtIdVendor.Text = null;
                t0061OCOMPRAIBindingSource.DataSource = null;
                return;
            }
            _refreshCombo = true;
            _idVendor = Convert.ToInt32(cmbRazonSocial.SelectedValue);
            txtIdVendor.Text = _idVendor.ToString();
            t0061OCOMPRAIBindingSource.DataSource =
                new OrdenCompraManager().GetListItemsDisponiblesIngresoByVendor(_idVendor).ToList();
        }

        private void dgvDetalleOC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var numeroOC = Convert.ToInt32(datagridview[oRDENCOMPRADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            var numeroItem = Convert.ToInt32(datagridview[iDITEMCOMPRADataGridViewTextBoxColumn.Name, e.RowIndex].Value);

            switch (cellValue)
            {
                case "Ver":
                    using (var f0 = new FrmMM31DetalleIngresoStock(numeroOC, numeroItem))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                        }
                    }

                    break;


                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void dgvDetalleOC_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
                return;

            int numeroOC = Convert.ToInt32(dgv[oRDENCOMPRADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            txtNumeroOC.Text = numeroOC.ToString();
            var dataOC = new OrdenCompraManager().GetDataOcHeader(numeroOC);
            txtEstadoOC.Text = dataOC.STATUSOC;
            txtFechaEmision.Text = dataOC.FECHAOC.Value.ToString("d");
            //
            txtMaterial.Text = dgv[mATERIALDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            decimal cantPedida = Convert.ToDecimal(dgv[cANTIDADDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            decimal cantRecibida = dgv[cANTIDADRECIBIDADataGridViewTextBoxColumn.Name, e.RowIndex].Value == null
                ? 0
                : Convert.ToDecimal(dgv[cANTIDADRECIBIDADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            decimal cantPendiente = cantPedida - cantRecibida;
            txtCantidadPedida.Text = cantPedida.ToString("N2");
            txtCantidadRecibida.Text = cantRecibida.ToString("N2");
            txtCantidadPendiente.Text = cantPendiente.ToString("N2");
            txtStatusItemOC.Text = dgv[statusItemDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            txtIdItemOC.Text =
                Convert.ToInt32(dgv[iDITEMCOMPRADataGridViewTextBoxColumn.Name, e.RowIndex].Value).ToString();
            if (dgv[comentarioIOCDataGridViewTextBoxColumn.Name, e.RowIndex].Value != null)
                txtObservacion.Text = dgv[comentarioIOCDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();

            txtPlaninspeccion.Text = new QmMasterIplan().GetPlanFromMaterial(txtMaterial.Text);
            cmbStatus.SelectedValue = "Restringido";
            cmbStatus.Enabled = false;
            if (_refreshCombo == false)
            {
                var oc = new OrdenCompraManager().GetDataOcHeader(numeroOC);
                _idVendor = oc.PROVEEDOR.Value;
                this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
                cmbRazonSocial.Text = new VendorManager().GetSpecificVendor(_idVendor).prov_rsocial;
                this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
                txtIdVendor.Text = _idVendor.ToString();
            }

        }

        private bool ValidaDatosCompletoIngreso()
        {
            BlankEp(txtNumeroRemito);
            BlankEp(txtFechaRemitoReal);
            BlankEp(uDecKgRecibidos);
            BlankEp(cmbSloc);
            BlankEp(cmbStatus);
            BlankEp(txtLoteTecser);

            if (string.IsNullOrEmpty(txtNumeroOC.Text))
            {
                MessageBox.Show(@"Debe seleccionar una Orden de Compra",
                    @"Datos Incpompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }


            if (txtFechaRemitoReal.FechaOK == false)
            {
                MessageBox.Show(@"Debe completar la fecha REAL que figura en el remito entregado por el proveedor",
                    @"Error en Fecha", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (dtpFechaRecepcion.Value == dtpFechaRecepcion.MinDate)
            {
                MessageBox.Show(@"Debe completar la fecha correcta de Recepcion del Material", @"Error en Fecha de Recepcion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (dtpFechaRecepcion.Value >= DateTime.Today.AddDays(1))
            {
                MessageBox.Show(@"Error en la fecha de Recpecion del Material",
                    @"Error en Fecha de Recepcion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (dtpFechaRecepcion.Value < DateTime.Today.AddDays(-10))
            {
                MessageBox.Show(@"Error en la fecha de Recpecion del Material! - Excede Limite de tolerancia negativo",
                    @"Error en Fecha de Recepcion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (dtpFechaRecepcion.Value < DateTime.Today.AddDays(-3))
            {
                var msg =
                    MessageBox.Show(
                        @"La fecha de Ingreso es anterior al margen permitido default. Confirma que la fecha de ingreso es la correcta?",
                        @"Confirmacion de Fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msg == DialogResult.No)
                    return false;
            }

            if (!txtNumeroRemito.MaskFull)
            {
                MsgToolTip("Debe completar el numero de Remito", txtNumeroRemito);
                return false;
            }

            if (string.IsNullOrEmpty(txtNumeroRemito.Text))
            {
                MsgToolTip("Debe completar el numero de Remito", txtNumeroRemito);
                return false;
            }

            if (uDecKgRecibidos.ValueD <= 0)
            {
                MsgToolTip("Debe completar los Kg Reales Recibidos en Planta", uDecKgRecibidos, esBaloon: false);
                return false;
            }

            if (string.IsNullOrEmpty(txtLoteTecser.Text))
            {
                MsgToolTip("Debe completar un numero de LOTE y generar la etiqueta correspondiente", txtLoteTecser, esBaloon: false);
                return false;
            }

            if (cmbSloc.SelectedIndex == -1)
            {
                MsgToolTip("Debe completar la ubicacion en la que sera ingresado el material a planta", cmbSloc, esBaloon: false);
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MsgToolTip("Debe completar el estado con el que el material ingresa a planta", cmbStatus, esBaloon: false);
                return false;
            }
            return true;
        }
        private void btnIngresarStock_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletoIngreso() == false)
                return;

            var msg = MessageBox.Show(@"Confirma el Ingreso del Stock a Planta?", @"Ingreso de Nuevo Stock",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.No)
                return;

            //Desde Aca es el ingreso de Stock
            var iC = new IngresoStockManager(Convert.ToInt32(txtNumeroOC.Text), Convert.ToInt32(txtIdItemOC.Text));
            var id63 = iC.NewManageIngresoConOrdenCompra(dtpFechaRecepcion.Value, txtFechaRemitoReal.Fecha.Value, txtNumeroRemito.Text,
                cmbRecibidoPor.SelectedValue.ToString(), uDecKgRecibidos.ValueD, txtLoteProveedor.Text,
                txtLoteTecser.Text, cmbSloc.SelectedValue.ToString(),
                StockStatusManager.MapStatusFromText(cmbStatus.Text), ckEntregaParcial.Checked, ckReproceso.Checked,
                txtObservacion.Text);

            if (string.IsNullOrEmpty(txtObservacionIngreso.Text))
                txtObservacionIngreso.Text = @"Auto IC1 @" + txtFechaEmision.Text;

            new QmRegistroInspeccion().CreaRegistroInspeccionH(QmRegistroInspeccion.TipoRecord.A,
                txtMaterial.Text, txtPlaninspeccion.Text, txtLoteTecser.Text, Convert.ToDateTime(txtFechaEmision.Text),
                uDecKgRecibidos.ValueD, MaterialOrigenDataType.OrigenDt.CompradoNac, id63,
                cmbRazonSocial.Text, txtObservacionIngreso.Text, "RE", txtNumeroRemito.Text);

            if (id63 > 0)
            {
                MessageBox.Show($@"Se ha Ingresado correctamente el Stock Seleccionado con el siguiente ID# {id63}.",
                    @"Ingreso de Stock a Planta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BlanqueoData();
            }
        }
        private void BlanqueoData()
        {
            cmbMaterial.SelectedIndex = -1;
            txtNumeroOC.Text = null;
            txtNumeroOC.Text = null;
            txtFechaEmision.Text = null;
            txtEstadoOC.Text = null;
            txtStatusItemOC.Text = null;
            txtIdItemOC.Text = null;
            txtObservacion.Text = null;
            txtCantidadPedida.Text = 0.ToString("N2");
            txtCantidadRecibida.Text = 0.ToString("N2");
            txtCantidadPendiente.Text = 0.ToString("N2");

            txtMaterial.Text = null;
            txtFechaRemitoReal.Text = null;
            txtNumeroRemito.Text = null;
            cmbRecibidoPor.SelectedIndex = -1;
            txtObservacionIngreso.Text = null;
            uDecKgRecibidos.Text = 0.ToString("N2");
            txtLoteTecser.Text = null;
            txtLoteProveedor.Text = null;
            cmbSloc.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            ckEntregaParcial.Checked = false;
            ckLiberarStock.Checked = false;
            ckReproceso.Checked = false;
            dgvDetalleOC.ClearSelection();

        }
        private void BlankEp(Control control)
        {
            ep.SetError(control, "");
        }

        private void MsgToolTip(string mensaje, Control control, string titulo = "Error en los datos Ingreados", bool esBaloon = true, bool mostrarEp = true)
        {
            toolTip1.IsBalloon = esBaloon;
            toolTip1.BackColor = Color.Orange;
            toolTip1.ToolTipTitle = titulo;
            toolTip1.Show(mensaje, control, control.Location, 3000);
            ep.SetError(control, mostrarEp ? mensaje : "");
        }

        private void uDecKgRecibidos_Validating(object sender, CancelEventArgs e)
        {
            if (uDecKgRecibidos.ValueD > Convert.ToDecimal(txtCantidadPendiente.Text))
            {
                var resp = MessageBox.Show(
                    @"La Cantidad Recibida EXCEDE a la cantidad de KG Pendientes de Entrega/Solicitados. Desea Continuar de todas formas dejando el material en estado 'EXCEDIDO'?",
                    @"Exceso de Material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                {
                    ckEntregaParcial.Checked = false;
                    e.Cancel = true;
                }

            }
            else
            {
                if (uDecKgRecibidos.ValueD < Convert.ToDecimal(txtCantidadPendiente.Text))
                {
                    var resp = MessageBox.Show(
                        @"El Material recibido no completa la Orden de Compra. Desea dejar la OC abierta para un ingreso posterior?",
                        @"Entrega Parcial/INCOMPLETA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    ckEntregaParcial.Checked = resp == DialogResult.Yes;
                }
                else
                {
                    ckEntregaParcial.Checked = false;
                }

            }
        }

        private void btnDetalleProveedor_Click(object sender, EventArgs e)
        {
            if (_idVendor <= 0)
            {
                MessageBox.Show(@"Debe Seleccionar un Proveedor/Vendor para poder visualizar sus datos",
                    @"Seleccione un Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var f = new FrmMdv03VendorInfo(_idVendor);
            f.Show();

        }

        private void btnPendienteIngreso_Click(object sender, EventArgs e)
        {
            _refreshCombo = false;
            _idVendor = 0;
            t0061OCOMPRAIBindingSource.DataSource =
                new OrdenCompraManager().GetListaItemsPendienteEntrega();
        }

        private void btnCopyRemito_Click(object sender, EventArgs e)
        {
            dtpFechaRecepcion.Value = fechaEntrega;
            txtFechaRemitoReal.Text = fechaRemito.ToString();
            txtNumeroRemito.Text = numeroRemito;
            cmbRecibidoPor.SelectedValue = resp;
        }

        private void txtLoteTecser_Validating(object sender, CancelEventArgs e)
        {
            if (txtLoteTecser.Text.Length > 14)
            {
                MessageBox.Show(@"La Cantidad Maxima de Caracteres para este campo es de 14", @"Modifique el #Lote",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void ckLiberarStock_CheckedChanged(object sender, EventArgs e)
        {
            if (ckLiberarStock.Checked)
            {
                MessageBox.Show(
                    @"Atencion al Seleccionar esta opcion el STOCK ingresará en estado Liberado siendo el responsable del Control de Calidad el responsable del ingreso de Material a Planta [IC]. Si no esta seguro sobre el estado del material coloque el estado en 'Restringido'",
                    @"Liberacion Automatica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbStatus.SelectedItem = "Liberado";
            }
            else
            {
                cmbStatus.SelectedItem = "Restringido";
            }
        }

        private void ckProcesoFason_CheckedChanged(object sender, EventArgs e)
        {
            if (ckProcesoFason.Checked)
            {
                //aca abrir la pantalla de OFE en proceso!
                //al volver mapear los datos y retomar idFasonRecibir si es mayor a cero 
            }
        }
    }
}
