using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.HR;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHR07AnticiposLoad : Form
    {
        public FrmHR07AnticiposLoad()
        {
            InitializeComponent();
        }

        private List<EstructuraAdelanto> _listaItems = new List<EstructuraAdelanto>();


        private void FrmHR07AnticiposLoad_Load(object sender, EventArgs e)
        {
            t0085PERSONALBindingSource.DataSource = new HumanResourcesManager().GetListEmployees(true);
            t0518ConceptosHRBindingSource.DataSource = new SyjDataManager().GetConceptoAdelanto();
            cmbConceptos.Enabled = false;
            btnEnviar.Enabled = false;
            txtCompromisoPago.Text = @"DTO MENSUAL/Q2";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ctlFechaTs1.Value == null)
            {
                MessageBox.Show(@"Debe Completar la Fecha de Solicitud", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (cmbConceptos.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe Completar el Concepto", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (cmbEmpleado.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe Completar el Empleado Solicitante", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtCompromisoPago.Text))
            {
                MessageBox.Show(@"Debe Completar el Compromiso de Pago indicando como se compromente a devolver el dinero Solicitado", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (ctlImporte.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Debe Completar el Importe Solicitado", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var data = new EstructuraAdelanto()
            {

                Id = _listaItems.Count + 1,
                Concepto = cmbConceptos.SelectedValue.ToString(),
                EmpleadoShort = cmbEmpleado.SelectedValue.ToString(),
                ImporteSolicitado = ctlImporte.GetValueDecimal,
                Comentario = "",
                FechaSolicitud = ctlFechaTs1.Value.Value,
                CompromisoPago = txtCompromisoPago.Text
            };

            _listaItems.Add(data);
            estructuraAdelantoBindingSource.DataSource = _listaItems.ToList();

            cmbEmpleado.SelectedIndex = -1;
            txtCompromisoPago.Text = null;
            btnEnviar.Enabled = true;

            {
                cmbEmpleado.SelectedIndex = -1;
                ctlImporte.SetValue = 0;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Confirma el Ingreso de La Solicitud en Pantalla", @"Confirmacion de Ingreso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (var item in _listaItems)
            {
                new ManejoAdelantos().GrabaNuevaSolicitud(item.EmpleadoShort, item.ImporteSolicitado, ctlFechaTs1.Value.Value,
                    item.CompromisoPago, item.Comentario);
            }
        }

        private void cmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConceptos.SelectedIndex == -1)
                return;

            if (cmbConceptos.SelectedValue.ToString() == "ADELANTO")
            {
                txtCompromisoPago.Text = @"DTO MENSUAL/Q2";
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
