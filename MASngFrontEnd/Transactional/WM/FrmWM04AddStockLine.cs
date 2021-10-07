using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Security;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.AsientoContable.Modules;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.WM
{
    public partial class FrmWM04AddStockLine : Form
    {
        public FrmWM04AddStockLine()
        {
            InitializeComponent();
        }

        private void FrmAddNewStockLine_Load(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }
        private void ConfiguracionInicial()
        {
            if (TsSecurityMng.CheckifRoleIsGrantedToRun("CQ", "CQADDITEM") == false)
            {
                MessageBox.Show(@"Usuario No Habilitado para Realizar esta Operacion", @"Security Alert", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                this.Close();
            }

            cmbPrimario.DataSource = new MaterialMasterManager().GetCompleteListofMaterial(true);
            cmbUbicacion.DataSource = new StorageLocationManager().ListOfLoc(true);
            btnAddNew.Enabled = false;
            cmbPrimario.SelectedIndex = -1;
            cmbUbicacion.SelectedIndex = -1;
            txtUser.Text = Environment.UserName;
            txtPermiso.Text = @"CQADDITEM";

        }
        private bool DataCompleta()
        {
            if (cmbPrimario.SelectedValue == null)
            {
                MessageBox.Show(@"El Codigo Primario no puede estar vacio!", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (cmbUbicacion.SelectedValue == null)
            {
                MessageBox.Show(@"La Ubicacion de Ingreso no puede estar vacia!", @"Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(cmbEstado.Text))
            {
                MessageBox.Show(@"El Estado del Stock no puede estar Incompleto", @"Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (String.IsNullOrEmpty(txtLote.Text))
            {
                MessageBox.Show(@"El Lote no puede estar Incompleto", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToDecimal(txtCantidad.Text) <= 0)
            {
                MessageBox.Show(@"La Cantidad es Incorrecta", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                MessageBox.Show(@"Debe Completar un motivo de Alta", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }



        private void btnAltaStock_Click(object sender, EventArgs e)
        {
            if (DataCompleta() == false)
                return;

            var idstk = new StockABM().AltaNewStockLine(cmbPrimario.SelectedValue.ToString(), txtLote.Text,
                Convert.ToDecimal(txtCantidad.Text), new StockStatusManager().MapeaStringToType(cmbEstado.Text),
                cmbUbicacion.SelectedValue.ToString(), "CQ", true, txtMotivo.Text);

            if (idstk > 0)
            {
                var asiento = new AsientoAjusteStock("CQ").Ajuste(cmbPrimario.SelectedValue.ToString(),
                    Convert.ToDecimal(txtCantidad.Text), txtMotivo.Text);

                MessageBox.Show(@"Se ha dado de alta correctamente el nuevo Stock", @"Alta Nuevo Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                txtCantidad.Text = 0.ToString();
            }

            decimal cant = Convert.ToDecimal(txtCantidad.Text);
            txtCantidad.Text = cant.ToString("N2");

            if (cant <= 0)
            {
                MessageBox.Show(@"La Cantidad a Ingresar debe ser MAYOR a CERO", @"Error en Cantidad",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                btnAddNew.Enabled = false;
            }
            else
            {
                btnAddNew.Enabled = true;
            }
        }

        private void TxtCantidad_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            if (DataCompleta() == false)
                return;

            var idstk = new StockABM().AltaNewStockLine(cmbPrimario.SelectedValue.ToString(), txtLote.Text,
                Convert.ToDecimal(txtCantidad.Text), new StockStatusManager().MapeaStringToType(cmbEstado.Text),
                cmbUbicacion.SelectedValue.ToString(), "CQ", true, txtMotivo.Text);

            if (idstk > 0)
            {
                var asiento = new AsientoAjusteStock("CQ").Ajuste(cmbPrimario.SelectedValue.ToString(),
                    Convert.ToDecimal(txtCantidad.Text), txtMotivo.Text);

                MessageBox.Show(@"Se ha dado de alta correctamente el nuevo Stock", @"Alta Nuevo Stock",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
