using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.HR;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP17AddUpdateDetalleRecursosProduccion : Form
    {
        private readonly int _id40;
        private readonly int _of;
        public FrmPP17AddUpdateDetalleRecursosProduccion(int id40, int of)
        {
            _id40 = id40;
            _of = of;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void btnModificarDetalle_Click(object sender, EventArgs e)
        {
            if (!ValidacionSaveOk())
                return;

            var rpt = new IngresoStockProduccion().SetDetalleIngresoProduccion(_id40, MapeaT42ScreenToStructure(),
                txtObservacionesIngreso.Text);

            if (rpt > 0)
            {
                MessageBox.Show(@"Se ha Actualizado Correctamente la informacion", @"Actualizacion de Datos Exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }
        }

        private T0042_PRODUCCION_DET MapeaT42ScreenToStructure()
        {
            var stx = new T0042_PRODUCCION_DET()
            {
                RECURSO_PROD = Convert.ToInt32(cmbRecursoProduccion.SelectedValue),
                OPERADOR = cmbOperador.SelectedItem.ToString(),
                FECHA = dtpFechaFabricacion.Value,
                HORAI = Convert.ToDateTime(txtHoraInicio.Text),
                HORAF = Convert.ToDateTime(txtHoraFin.Text),
                TIEMPO_STOP = Convert.ToInt32(txtDuracionStops.Text),
                NUMSTOPS = Convert.ToInt32(txtNumeroStops.Text),
                LIM_CABEZAL = ckLimpiezaCabezal.Checked,
                NUM_PASADAS = Convert.ToInt32(txtCantidadPasadas.Text),
                MATERIAL = txtMaterialFabricado.Text,
                ID40 = _id40,
                IDMOV = 0,
                LIM_COMPLETA = ckLimpiezaCompleta.Checked,
                STOP_OBS = txtObservacionesStop.Text
            };
            return stx;
        }

        private bool ValidacionSaveOk()
        {
            if (cmbRecursoProduccion.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe Completar el Recursos de Produccion", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (cmbOperador.SelectedItem == null)
            {
                MessageBox.Show(@"Debe Completar el Operador", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (dtpFechaFabricacion.Value > Convert.ToDateTime(txtFechaIngreso.Text))
            {
                MessageBox.Show(@"La Fecha de Fabricacion Real no puede ser posterior a la fecha de Posteo del Registro", @"Datos Incompletos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtDuracionMinutos.Text))
            {
                txtDuracionMinutos.Text = @"0";
            }

            if (Convert.ToInt32(txtDuracionMinutos.Text) < 0)
            {
                MessageBox.Show(@"La Duracion de Minutos es Incorrecta", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtNumeroStops.Text))
                txtNumeroStops.Text = @"0";

            if (string.IsNullOrEmpty(txtDuracionStops.Text))
                txtDuracionStops.Text = @"0";

            if (string.IsNullOrEmpty(txtCantidadPasadas.Text))
                txtCantidadPasadas.Text = @"0";

            if (ckLimpiezaCabezal.Checked != true)
                ckLimpiezaCabezal.Checked = false;

            if (ckLimpiezaCompleta.Checked != true)
                ckLimpiezaCompleta.Checked = false;


            return true;
        }

        private void FrmPP17AddUpdateDetalleRecursosProduccion_Load(object sender, EventArgs e)
        {
            //Data Generica OF
            txtId40.Text = _id40.ToString();
            var data70 = PlanProduccionListManager.GetOFData(_of);
            txtEstadoOF.Text = data70.STATUS;
            txtMaterialFabricado.Text = data70.MATERIAL;
            txtNumeroOF.Text = _of.ToString();

            //Set Combobox
            cmbOperador.Items.AddRange(HrDisponibilidadYPermisos.DisponibleOperario().ToArray());
            cmbOperador.SelectedIndex = -1;


            //cmbOperador.DataSource = new HumanResourcesManager().GetListAllActiveOperario(); ;
            //cmbOperador.SelectedIndex = -1;

            cmbRecursoProduccion.DataSource = new RecursosProduccion().GetListRecursosProduccion();
            cmbRecursoProduccion.SelectedIndex = -1;

            LoadOfDetalleData();
        }
        private void LoadOfDetalleData()
        {
            //data generica T40
            var data40 = MmLog.GetT40Line(_id40);
            txtObservacionesIngreso.Text = data40.COMENTARIO.ToString();
            dtpFechaFabricacion.Text = data40.FECHAMOV.Value.ToString("D");
            txtFechaIngreso.Text = data40.LOG_DATE.Value.ToString("D");
            txtResponsableIngreso.Text = data40.LOG_USER;
            txtKgIngresados.Text = data40.CANTIDAD.Value.ToString("N1");

            //data detalle T0042
            var i = new IngresoStockProduccion().GetDetalleIngresoProduccion(_id40);
            cmbOperador.SelectedItem = i.OPERADOR;
            cmbRecursoProduccion.SelectedValue = i.RECURSO_PROD.Value;

            if (i.HORAI == null)
            {
                txtHoraInicio.Text = @"08:00";
            }
            else
            {
                var x = Convert.ToDateTime(i.HORAI);
                txtHoraInicio.Text = x.ToString("t");
            }

            if (i.HORAF == null)
            {
                txtHoraFin.Text = @"08:00";
            }
            else
            {
                var x = Convert.ToDateTime(i.HORAF);
                txtHoraFin.Text = x.ToString("t");
            }

            txtNumeroStops.Text = i.NUMSTOPS.ToString();
            txtDuracionStops.Text = i.TIEMPO_STOP.ToString();
            txtCantidadPasadas.Text = i.NUM_PASADAS.ToString();
            ckLimpiezaCabezal.Checked = i.LIM_CABEZAL.Value;
            ckLimpiezaCompleta.Checked = i.LIM_COMPLETA.Value;
            if (i.STOP_OBS != null)
                txtObservacionesStop.Text = i.STOP_OBS.ToString();
            txtDuracionMinutos.Text =
                FormatAndConversions.CalculaMinutosEntreDosHoras(txtHoraInicio.Text, txtHoraFin.Text);
        }

        private void txtDuracionMinutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void txtHoraInicio_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = FormatAndConversions.ValidaFormatoHora(sender);
        }

        private void txtHoraFin_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = FormatAndConversions.ValidaFormatoHora(sender);
        }

        private void txtHoraInicio_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtHoraInicio_Validated(object sender, EventArgs e)
        {
            txtDuracionMinutos.Text =
                FormatAndConversions.CalculaMinutosEntreDosHoras(txtHoraInicio.Text, txtHoraFin.Text);
        }
    }
}
