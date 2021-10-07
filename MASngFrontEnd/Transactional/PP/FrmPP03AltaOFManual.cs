using System;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.PP;
using Tecser.Business.Transactional.SD;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP03AltaOFManual : Form
    {
        public FrmPP03AltaOFManual()
        {
            InitializeComponent();
        }

        private void txtKgFabricar_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private bool ValidaDatosCompletos()
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Completar el Material a Fabricar", @"Error en Datos de Planificacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(txtKgFabricar.Text))
            {
                MessageBox.Show(@"Debe Completar los Kg a Fabricar", @"Error en Datos de Planificacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbMotivo.SelectedText == null)
            {
                MessageBox.Show(@"Debe Completar el Motivo de Fabricacion", @"Error en Datos de Planificacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtpFechaCompromiso.Value < DateTime.Today.AddDays(-5))
            {
                MessageBox.Show(@"La fecha de Compromiso no puede ser menor a 5 dias anteriores",
                    @"Error en Datos de Planificacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbMotivo.SelectedItem == null)
            {
                MessageBox.Show(@"Debe ingresar un motivo para la planificacion manual",
                    @"Error en Datos de Planificacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            switch (cmbMotivo.SelectedItem.ToString())
            {
                case "STOCK":
                    break;
                case "VENTA":
                    if (string.IsNullOrEmpty(txtNumeroOV.Text))
                    {
                        MessageBox.Show(@"Si ingresa una OF Manual para una Venta debe ingresar el numero de OV#",
                            @"Error en Datos de Planificacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (txtNumeroOV.Text == @"0")
                    {
                        MessageBox.Show(@"Si ingresa una OF Manual para una Venta debe ingresar el numero de OV#",
                            @"Error en Datos de Planificacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (String.IsNullOrEmpty(txtNombreCliente.Text))
                    {
                        MessageBox.Show(@"El numero de Orden de Fabricacion no corresponde a ningun cliente",
                            @"Error en Datos de Planificacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;

                case "MUESTRA":
                    if (Convert.ToDecimal(txtKgFabricar.Text) > 25)
                    {
                        MessageBox.Show(@"La cantidad de Kg supera el maximo permitido para muestras",
                            @"Error en Datos de Planificacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    break;

                default:
                    break;

            }

            return true;
        }
        private void FrmAltaOrdenFabricacion_Load(object sender, EventArgs e)
        {
            cmbMaterial.DataSource = new MaterialTypeManager().GetListMaterialsTobeManufacture();
            txtUsuario.Text = GlobalApp.AppUsername;
            txtFechaLog.Text = DateTime.Now.ToString("g");
            cmbMaterial.Text = null;
            txtDescripcion.Text = null;
            //


            //
            //ckAprobado.Checked = TsSecurityMng.CheckToEnableButton("PPAPRUEBA");
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue != null)
            {
                var matinfo = MaterialMasterManager.GetSpecificPrimaryInformation(cmbMaterial.SelectedValue.ToString());
                txtDescripcion.Text = matinfo.MAT_DESC;
                txtMtype.Text = matinfo.TIPO_MATERIAL;
            }
        }

        private void cmbMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMotivo.SelectedItem.ToString())
            {
                case "STOCK":
                    txtNumeroOV.Enabled = false;
                    txtNombreCliente.Enabled = false;
                    txtNumeroOV.Text = null;
                    txtNombreCliente.Text = null;
                    break;
                case "VENTA":
                    txtNumeroOV.Enabled = true;
                    txtNombreCliente.Enabled = true;
                    txtNumeroOV.Text = null;
                    txtNombreCliente.Text = null;
                    break;
                case "MUESTRA":
                    txtNumeroOV.Enabled = false;
                    txtNombreCliente.Enabled = false;
                    txtNumeroOV.Text = null;
                    txtNombreCliente.Text = null;
                    break;
                default:
                    break;
            }
        }

        private void cmbMaterial_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbMaterial);
        }

        private void btnAddOF_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletos() == false)
                return;

            if (ckAprobado.Checked == false)
            {
                var r = MessageBox.Show(
                    @"La Orden de Fabricacion NO esta Aprobada para Fabricar. Desea Ingresarla en estado NO AUTORIZADA?",
                    @"Atencion OF no aprobada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    return;
            }

            var result = MessageBox.Show(@"Confirma el Alta de nueva Orden de Fabricacion?", @"Confirmacion Alta Orden de Fabricacion Manual", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                PlanProduccionManager.MotivoFabricacion motivoF;
                switch (cmbMotivo.Text)
                {
                    case "STOCK":
                        motivoF = PlanProduccionManager.MotivoFabricacion.Stock;
                        break;
                    case "VENTA":
                        motivoF = PlanProduccionManager.MotivoFabricacion.OrdenVenta;
                        break;
                    case "MUESTRA":
                        motivoF = PlanProduccionManager.MotivoFabricacion.Muestra;
                        break;
                    default:
                        motivoF = PlanProduccionManager.MotivoFabricacion.Stock;
                        break;

                }

                if (string.IsNullOrEmpty(txtNumeroOV.Text))
                    txtNumeroOV.Text = @"0";

                var ofn = new PlanProduccionManager().AddPlanProduccion(cmbMaterial.SelectedValue.ToString(),
                    cmbMaterial.SelectedValue.ToString(), Convert.ToDecimal(txtKgFabricar.Text),
                    Convert.ToInt32(txtNumeroOV.Text), dtpFechaCompromiso.Value, txtComentario.Text, txtPlanta.Text, motivoF,
                    txtNombreCliente.Text, false, true, ckAprobado.Checked);

                if (ofn > 0)
                {
                    MessageBox.Show(string.Format(@"Se creado correctamente la Orden de Fabricacion # {0}", ofn),
                        @"Ingreso de Orden de Fabricacion Mannual",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show(@"Ha Ocurrido un error al generar la OF Manual", @"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else
            {
                //...
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtKgFabricar_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtKgFabricar.Text))
                txtKgFabricar.Text = 0.ToString("N2");
        }

        private void txtNumeroOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void txtNumeroOV_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumeroOV.Text))
            {
                var x = new SalesOrderDataManager().GetDataHeaderFromDb(Convert.ToInt32(txtNumeroOV.Text));
                if (x == null)
                {
                    toolTip1.ToolTipTitle = "Dato Invalido";
                    toolTip1.Show("El numero de OV/SO No es Valido", txtNumeroOV, txtNumeroOV.Location, 5000);
                    e.Cancel = true;
                }
                else
                {
                    txtNombreCliente.Text =
                        new CustomerManager().GetCustomerShipToData(x.CLIENTE.Value).T0006_MCLIENTES.cli_rsocial;
                }
            }
        }

        private void ckAprobado_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAprobado.Checked)
            {
                MessageBox.Show(
                    @"La Orden de Fabricacion se está ingresando en modo APROBADO. Utilice este modo solo cuando haya obtenido una autorizacion previa",
                    @"ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
