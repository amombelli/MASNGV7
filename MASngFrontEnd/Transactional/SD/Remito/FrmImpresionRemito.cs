using System;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using MASngFE.Transactional.FI.Factura;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.Costos;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.SD;

namespace MASngFE.Transactional.SD.Remito
{
    public partial class FrmImpresionRemito : Form
    {
        public FrmImpresionRemito(int idRemito)
        {
            _idRemito = idRemito;
            _modo = 1;
            InitializeComponent();
        }

        public FrmImpresionRemito(int idRemito, int modo)
        {
            _modo = modo;
            _idRemito = idRemito;
            InitializeComponent();
        }

        private readonly int _idRemito;
        private readonly int _modo;
        private bool _remitoImpreso;
        private int? idFactura;

        private void ImpresionRemito_Load(object sender, EventArgs e)
        {
            InicializadData();
            LoadRemitoData();
            SetComportamientoSegunEstadoRemito();
        }
        private void InicializadData()
        {
            ckNumeroRemitoOK.Checked = false;
            ckRemitoImpreso.Checked = false;
            ckRemitoImpreso1.Checked = false;
            ckMetodoEntrega.Checked = false;
            ckFacturaContabilizada.Checked = false;

            ckNumeroRemitoOK.BackColor = Color.RosyBrown;
            ckRemitoImpreso.BackColor = Color.RosyBrown;
            ckRemitoImpreso1.BackColor = Color.RosyBrown;
            ckMetodoEntrega.BackColor = Color.RosyBrown;
            ckFacturaContabilizada.BackColor = Color.RosyBrown;

            _remitoImpreso = false;
        }
        private void SetComportamientoSegunEstadoRemito()
        {
            var statusRemito = new RemitoStatusManager().MapStatusHeaderFromText(txtEstadoRemito.Text);
            btnImprimir.Enabled = false;
            btnReimprimir.Enabled = false;
            btnFacturar.Enabled = false;
            btnCancelarRemito.Enabled = false;
            btnRetiraCliente.Enabled = false;
            btnRetiraCliente.Enabled = false;
            btnUpdateDireccionEntrega.Enabled = false;
            dgvItemRemitos.Enabled = false;
            ckSumarizado.Enabled = false;
            txtNumeroRemito.Enabled = false;
            dtpFechaRemito.Enabled = false;

            switch (statusRemito)
            {
                case RemitoStatusManager.StatusHeader.EnPreparacion:
                    MessageBox.Show(@"El Estado del Remito no Permite Visualizacion", @"Error en Estado de Remito",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                case RemitoStatusManager.StatusHeader.Preparado:
                    MessageBox.Show(@"El Estado del Remito no Permite Visualizacion", @"Error en Estado de Remito",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;

                case RemitoStatusManager.StatusHeader.Error:
                    MessageBox.Show(@"El Estado del Remito no Permite Visualizacion", @"Error en Estado de Remito",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;

                case RemitoStatusManager.StatusHeader.Generado:
                    GenerateNewRemitoNumber();
                    dgvItemRemitos.Enabled = true;
                    ckSumarizado.Enabled = true;
                    btnCancelarRemito.Enabled = true;
                    btnImprimir.Enabled = true;
                    btnRetiraCliente.Enabled = true;
                    btnEntregaTecser.Enabled = true;
                    txtNumeroRemito.Enabled = true;
                    dtpFechaRemito.Enabled = true;
                    btnUpdateDireccionEntrega.Enabled = true;
                    new RemitoGeneracionImpresion().SetDataRemitoPrintModoDetalle(_idRemito);
                    break;
                case RemitoStatusManager.StatusHeader.Impreso:
                    //
                    LoadExistingRemitoNumber();
                    btnReimprimir.Enabled = true;
                    btnFacturar.Enabled = true;
                    btnCancelarRemito.Enabled = true;
                    btnRetiraCliente.Enabled = true;
                    btnRetiraCliente.Enabled = true;
                    btnUpdateDireccionEntrega.Enabled = false;
                    break;
                case RemitoStatusManager.StatusHeader.Cancelado:
                    LoadExistingRemitoNumber();
                    break;
                case RemitoStatusManager.StatusHeader.Inicial:
                    MessageBox.Show(@"El Estado del Remito no Permite Visualizacion", @"Error en Estado de Remito",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
                case RemitoStatusManager.StatusHeader.StandBy:
                    MessageBox.Show(@"El Estado del Remito no Permite Visualizacion", @"Error en Estado de Remito",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
                default:
                    MessageBox.Show(@"El Estado del Remito no Permite Visualizacion", @"Error en Estado de Remito",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new ArgumentOutOfRangeException();
            }
            dgvItemRemitos.DataSource = new RemitoGeneracionImpresion().GetDataItemRemito(_idRemito);
        }
        private void LoadRemitoData()
        {
            var dataH = new RemitoGeneracionImpresion().GetRemitoHeader(_idRemito);
            txtIdRemito.Text = _idRemito.ToString();
            txtTipoRemito.Text = dataH.TIPO_REMITO;
            if (dataH.TIPO_REMITO == "L2")
                groupBox1.Enabled = false;

            dtpFechaRemito.Value = dataH.FECHA;
            ckRemitoImpreso.Checked = dataH.Impreso != null && dataH.Impreso;
            ckRemitoImpreso1.Checked = ckRemitoImpreso.Checked;

            txtNumeroRemito1.Text = ckRemitoImpreso1.Checked ? dataH.NUMREMITO : @"NO ASIGNADO";

            var statusRemito = new RemitoStatusManager().MapStatusHeaderFromText(dataH.StatusRemito);
            txtEstadoRemito.Text = statusRemito.ToString().ToUpper();
            txtNumeroRemitoCompleto.Text = dataH.NUMREMITO;

            txtNumeroBultos.Text = dataH.CANTBULTOS.ToString();
            txtObservacion.Text = dataH.OBSERVACION_REM;
            txtMontoAsegurado.Text = dataH.VALOR_DEC?.ToString("C2");

            txtLogDate.Text = dataH.FechaLog.ToString();
            txtLogUser.Text = dataH.UserLog.ToUpper();
            txtObservacionPreparacion.Text = dataH.COM_PREP;
            txtPreparadoPor.Text = dataH.PREPAREDBY;

            if (dataH.RLINK != null)
            {
                txtRlink.Text = dataH.RLINK.ToString();
                ckL5.Checked = true;
                var r5 = new RemitoGeneracionImpresion().GetRemitoHeader(Convert.ToInt32(dataH.RLINK));
                txtTipoRemitoL5.Text = r5.TIPO_REMITO.ToString();
                txtEstadoRemitoL5.Text = r5.StatusRemito;
                txtNumeroRemitoL5.Text = r5.NUMREMITO.ToString();
            }

            if (string.IsNullOrEmpty(txtNumeroRemitoCompleto.Text))
            {
                ckNumeroRemitoOK.Checked = false;
                ckNumeroRemitoOK.BackColor = Color.LightPink;
            }
            else
            {
                ckNumeroRemitoOK.Checked = true;
                ckNumeroRemitoOK.BackColor = Color.LimeGreen;
            }

            //*Map Data Cliente
            txtIdCliente7.Text = dataH.CODCLIENTREGA.ToString();
            var dataCliente7 = new CustomerManager().GetCustomerShipToData(dataH.CODCLIENTREGA);
            var idCliente6 = dataCliente7.IDCLIENTE;
            var dataCliente6 = new CustomerManager().GetCustomerBillToData(idCliente6);
            txtNombreClienteEntrega.Text = dataCliente7.ClienteEntregaDesc;
            txtNombreCliente6.Text = dataCliente6.cli_rsocial;
            //txtFiscalDireccion.Text = dataCliente6.Direccion_facturacion + " " + dataCliente6.DireFactu_Num;
            //txtFiscalLocalidad.Text = dataCliente6.Direfactu_Localidad;
            //txtFiscalProvincia.Text = dataCliente6.Direfactu_Provincia;
            //txtFiscalZip.Text = dataCliente6.ZIP;
            txtHorarioEntrega.Text = dataCliente7.EntregaHorarios;

            txtId6.Text = idCliente6.ToString();
            txtNumeroCuit.Text = dataCliente6.CUIT;
            //
            txtDireccionEntrega.Text = dataCliente7.Direccion_Entrega;
            txtLocalidadEntrega.Text = dataCliente7.DireEntre_Localidad;
            txtProvinciaEntrega.Text = dataCliente7.DireEntre_Provincia;
            txtZipEntrega.Text = dataCliente7.ZIP;
            //
            this.Text = @"SD10 - REMITO #" + txtNumeroRemitoCompleto.Text + @"  -" + dataCliente6.cli_rsocial;
            if (dataCliente7.TRANSPORTE_ID == null)
            {
                ckTransporte.Checked = false;
                ckTransporte.BackColor = Color.LightPink;
            }
            else
            {
                if (dataCliente7.TRANSPORTE_ID.Value > 0)
                {
                    ckTransporte.Checked = true;
                    txtIdTransporte.Text = dataCliente7.TRANSPORTE_ID.ToString();
                }
                else
                {
                    ckTransporte.BackColor = Color.LimeGreen;
                }
            }

            if (!string.IsNullOrEmpty(dataH.NUMFACTURA))
            {
                txtNumeroFactura.Text = dataH.NUMFACTURA;
                txtNumeroFactura.BackColor = Color.LimeGreen;
                btnCancelarRemito.Enabled = false;
            }

            if (dataH.Factura > 0)
            {
                //La factura esta contabilizada
                var dataFactura = new RemitoGeneracionImpresion().GetDataFacturaRemito(dataH.Factura.Value);
                ckFacturaContabilizada.Checked = true;
                ckFacturaContabilizada.BackColor = Color.LimeGreen;
                if (dataFactura.TIPOFACT == "L1")
                {
                    txtNumeroFactura.Text = dataFactura.PV_AFIP + @"-" + dataFactura.ND_AFIP;
                }
                else
                {
                    txtNumeroFactura.Text = dataFactura.Remito;
                }

                txtEstadoFactura.Text = dataFactura.StatusFactura;
                txtEstadoFactura.BackColor = Color.LimeGreen;
                idFactura = dataH.Factura;
            }
            else
            {
                //Factura no esta contabilizada
                txtNumeroFactura.Text = @"NO GENERADA";
                txtEstadoFactura.Text = DocumentFIStatusManager.StatusHeader.Pendiente.ToString().ToUpper();
                ckFacturaContabilizada.Checked = false;
                ckFacturaContabilizada.BackColor = Color.LightPink;
                idFactura = null;
            }
            _remitoImpreso = ckRemitoImpreso.Checked;
            if (_remitoImpreso == false)
                btnFacturar.Enabled = _remitoImpreso;

            lblAsignacionFlete.Text = new GestorEntregas().GetTipoEntregaAsignada(_idRemito).ToString();
        }
        private void GenerateNewRemitoNumber()
        {
            txtNumeroRemito.Visible = true;
            txtSucursalRemito.Visible = true;
            txtNumeroRemitoCompleto.Visible = false;
            txtNumeroRemito.Text = new RemitoGeneracionImpresion().DefineNumeroRemito(txtTipoRemito.Text);
            txtSucursalRemito.Text = new RemitoGeneracionImpresion().DefineSucursalRemito(txtTipoRemito.Text);
            txtNumeroRemitoCompleto.Text = txtSucursalRemito.Text + @"-" + txtNumeroRemito.Text;
        }
        private void LoadExistingRemitoNumber()
        {
            txtSucursalRemito.Visible = false;
            txtNumeroRemito.Visible = false;
            txtNumeroRemitoCompleto.Visible = true;
        }
        private void ckSumarizado_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSumarizado.Checked == true)
            {
                //en este modo NO permite modificacion
                new RemitoGeneracionImpresion().SetDataRemitoPrintModoSumarizado(_idRemito);
                dgvItemRemitos.DataSource = new RemitoGeneracionImpresion().GetDataItemRemito(_idRemito);
                dgvItemRemitos.ReadOnly = true;
                lblPermiteModificacion.Visible = false;
            }
            else
            {
                //en modo detalle permite modificacion
                new RemitoGeneracionImpresion().SetDataRemitoPrintModoDetalle(_idRemito);
                dgvItemRemitos.DataSource = new RemitoGeneracionImpresion().GetDataItemRemito(_idRemito);
                dgvItemRemitos.ReadOnly = false;
                lblPermiteModificacion.Visible = true;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvItemRemitos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int iditem = Convert.ToInt32(dgvItemRemitos[dgvItemRemitos.Columns["xiditem"].Index, e.RowIndex].Value);
                string descripcion = dgvItemRemitos[dgvItemRemitos.Columns["xdescripcion"].Index, e.RowIndex].Value.ToString();
                decimal kgdespachados = Convert.ToDecimal(dgvItemRemitos[dgvItemRemitos.Columns["xkgdespachados"].Index, e.RowIndex].Value);
                string lote = dgvItemRemitos[dgvItemRemitos.Columns["xlote"].Index, e.RowIndex].Value.ToString();
                new RemitoGeneracionImpresion().UpdateT0056FromT0057(_idRemito, iditem, descripcion, kgdespachados, lote);
                new RemitoGeneracionImpresion().SetDataRemitoPrintModoDetalle(_idRemito);
            }
            dgvItemRemitos.DataSource = new RemitoGeneracionImpresion().GetDataItemRemito(_idRemito); /***aca**/
        }
        private void txtNumeroRemito_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
        private void btnRetiraCliente_Click(object sender, EventArgs e)
        {
            new GestorEntregas().AsignaTipoEntregaARemito(_idRemito, TipoEntregaStatusManager.TipoEntrega.RetiraCliente, DateTime.Today);
            MessageBox.Show(@"El Remito se ha asignado a Retira Cliente", @"Metodo de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblAsignacionFlete.Text = new GestorEntregas().GetTipoEntregaAsignada(_idRemito).ToString();
            ckMetodoEntrega.Checked = true;
            ckMetodoEntrega.BackColor = Color.LightGreen;
        }
        private void btnEntregaTecser_Click(object sender, EventArgs e)
        {
            new GestorEntregas().AsignaTipoEntregaARemito(_idRemito, TipoEntregaStatusManager.TipoEntrega.EntregaSinCargo, DateTime.Today);
            MessageBox.Show(@"El Remito se ha asignado a Entrega Tecser", @"Metodo de Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblAsignacionFlete.Text = new GestorEntregas().GetTipoEntregaAsignada(_idRemito).ToString();
            ckMetodoEntrega.Checked = true;
            ckMetodoEntrega.BackColor = Color.LightGreen;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (ckRemitoImpreso.Checked)
            {
                MessageBox.Show(@"El Remito ya se encuentra IMPRESO" + Environment.NewLine + "" +
                                @"Puede Re-Imprimir desde la Opcion RE-IMPRESION", @"Impresion de Remito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (txtNumeroRemito.Text.Contains("X") || txtNumeroRemito.Text.Contains("x"))
            {
                MessageBox.Show(@"El Numero de Remito es Incorrecto.- Remueva X verificando primero que el numero del sistema coincide con el numero pre-impreso en el Remito", @"Numero de Remito Ya Impreso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ckNumeroRemitoOK.Checked = false;
                ckNumeroRemitoOK.BackColor = Color.LightPink;
                return;
            }
            if (txtNumeroRemito.Text.Contains("?"))
            {
                MessageBox.Show(@"El Numero de Remito es Incorrecto.- Remueva ? verificando el proximo numero que debiera ser utlizado.", @"Impresion de Remito",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ckNumeroRemitoOK.Checked = false;
                ckNumeroRemitoOK.BackColor = Color.LightPink;
                return;
            }

            if (txtNumeroRemito.Text.Contains("."))
            {
                var resp =
                    MessageBox.Show(
                        @"El Numero de Remito contiene un caracter utilizado usualmente para realizar un remito con un numero alterado. Desea Continuar?",
                        @"Numero de Remito Sospechoso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == DialogResult.No)
                    return;
            }


            var r = txtNumeroRemitoCompleto.Text;
            if (txtTipoRemito.Text == @"L1")
            {
                if (txtNumeroRemitoCompleto.Text.Length != 13)
                {
                    MessageBox.Show(@"El Numero de Remito es incorrecto.- Debe contener 8 caracteres '00000000'",
                        @"Impresion de Remito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (new RemitoGeneracionImpresion().CheckIfRemitoNumberExist(txtSucursalRemito.Text, txtNumeroRemito.Text,
                txtTipoRemito.Text))
            {
                MessageBox.Show(
                    @"El Numero de Remito se encuentra duplicado.- Verifique el numero e intente nuevamente",
                    @"Remito Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //2 grabar numero de remito en tabla  -- ok


            int numeroRemito;

            bool result = Int32.TryParse(txtNumeroRemito.Text, out numeroRemito);
            if (result)
            {
                new RemitoGeneracionImpresion().UpdateUltimoNumeroRemitoUtilizado(txtNumeroRemito.Text,
                    txtTipoRemito.Text);
            }
            else
            {
                MessageBox.Show(
                    @"Atencion, este numero de Remito no ha sido actualizado en el sistema como Ultimo Numero de Remito",
                    @"Ultimo numero de Remito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            new RemitoGeneracionImpresion().SetRemitoToStatusImpreso(_idRemito, txtNumeroRemitoCompleto.Text);
            new RemitoGeneracionImpresion().UpdateDatosFacturaRemito(_idRemito, true, null, 0, "ARS");
            ckRemitoImpreso.Checked = true;
            ckRemitoImpreso.BackColor = Color.LimeGreen;
            ckRemitoImpreso1.Checked = true;
            ckRemitoImpreso1.BackColor = Color.LimeGreen;
            ckNumeroRemitoOK.Checked = true;
            ckNumeroRemitoOK.BackColor = Color.LimeGreen;

            txtEstadoRemito.Text = RemitoStatusManager.StatusHeader.Impreso.ToString().ToUpper();
            _remitoImpreso = true;
            SetComportamientoSegunEstadoRemito();

            //Margen


            if (txtTipoRemito.Text == @"L1")
            {
                if (ckL5.Checked)
                {
                    new RemitoL5Manager().SetRemitoL2L5(_idRemito);
                    MessageBox.Show(@"Se ha GENERADO correctamente la parte L2 de este remito asociado.", @"REMITO L5 PREPARADO", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                var f = new RpvRemitoL1(_idRemito);
                f.Show();
            }
            else
            {
                if (ckL5.Checked)
                {
                    MessageBox.Show(@"No es necesario imprimir este REMITO sin Valorizar. Si desea Realmente Imprimir este Remito presione luego el botón Re-IMPRIMIR", @"REMITO L5 PREPARADO", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                var f = new RpvRemitoL2(_idRemito);
                f.Show();
            }
            new MargenDocument().AddMargenDocumentAndMapCost(_idRemito);
        }
        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            if (txtTipoRemito.Text == @"L1")
            {
                var f = new RpvRemitoL1(_idRemito);
                f.Show();
            }
            else
            {
                var f = new RpvRemitoL2(_idRemito);
                f.Show();
            }
        }
        private void btnCancelarRemito_Click(object sender, EventArgs e)
        {
            if (idFactura != null)
            {
                MessageBox.Show(
                    @"El Remito no se puede cancelar porque ya existe una Factura Asociada. Debe realizar nota de credito",
                    @"Funcionalidad No Permitida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            DialogResult dr = MessageBox.Show(@"Confirma la Cancelacion del Remito?", @"Cancelacion de Remito",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No)
                return;

            var resultado = new RemitoCancelacion(_idRemito).CancelacionCompletaRemito();
            if (resultado)
            {
                MessageBox.Show(@"Se ha Cancelado Correctamente el Remito!", @"Cancelacion de Remito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEstadoRemito.Text = RemitoStatusManager.StatusHeader.Cancelado.ToString().ToUpper();

                SetComportamientoSegunEstadoRemito();
            }
            else
            {
                MessageBox.Show(@"Error al Cancelar el Remito", @"Cancelacion de Remito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private bool ValidaGoToFacturar()
        {
            if (new GestorEntregas().GetTipoEntregaAsignada(_idRemito) ==
                TipoEntregaStatusManager.TipoEntrega.SinAsignar)
            {
                MessageBox.Show(@"Debe seleccionar un metodo de entrega para pasar a Facturacion", @"Metodo de Entrega",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (txtTipoRemito.Text == @"L1")
            {
                rbFacturaA.Checked = true; //Fix Momentaneo
                if (rbFacturaA.Checked == rbFacturaB.Checked)
                {
                    MessageBox.Show(@"Debe Seleccionar un tipo de Factura 'A' o 'B'", @"Tipo de Factura",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (ValidaGoToFacturar() == false)
                return;

            ManageDocumentType.TipoDocumento tipoDoc;
            if (txtTipoRemito.Text == @"L1")
            {
                if (rbFacturaA.Checked)
                {
                    tipoDoc = ManageDocumentType.TipoDocumento.FacturaVentaA;
                }
                else
                {
                    tipoDoc = ManageDocumentType.TipoDocumento.FacturaVentaB;
                }
            }
            else
            {
                tipoDoc = ManageDocumentType.TipoDocumento.FacturaVenta2;
            }

            var f2 = new FrmFI20MainDocument(1, _idRemito, tipoDoc);
            f2.Show();
        }
        private void txtNumeroRemito_Leave(object sender, EventArgs e)
        {
            if (new RemitoGeneracionImpresion().CheckIfRemitoNumberExist(txtSucursalRemito.Text, txtNumeroRemito.Text,
                txtTipoRemito.Text))
            {
                MessageBox.Show(@"El numero de Remito Seleccionado ya Existe", @"Remito Duplicado", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtNumeroRemitoCompleto.Text = txtSucursalRemito.Text + @"-" + txtNumeroRemito.Text;
                txtNumeroRemitoCompleto.BackColor = Color.Red;
                txtNumeroRemito.BackColor = Color.Red;
            }
            else
            {
                MessageBox.Show(@"El numero de Remito Seleccionado es CORRECTO", @"Remito OK", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (txtTipoRemito.Text == @"L1")
                {
                    txtNumeroRemitoCompleto.Text = txtSucursalRemito.Text + @"-" + txtNumeroRemito.Text.PadLeft(8, '0');
                }
                else
                {
                    txtNumeroRemitoCompleto.Text = txtSucursalRemito.Text + @"-" + txtNumeroRemito.Text;
                }

                txtNumeroRemitoCompleto.BackColor = Color.MediumSeaGreen;
                txtNumeroRemito.BackColor = Color.MediumSeaGreen;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcionalidad no realizada aun");
        }
        private void lblPermiteModificacion_Click(object sender, EventArgs e)
        {

        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}