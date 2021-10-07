using System;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.QM;
using TecserEF.Entity;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm13MasterIPlanDetalle : Form
    {
        public FrmQm13MasterIPlanDetalle(string idPlan, int modo = 2)
        {
            _idPlan = idPlan;
            _modo = modo;
            InitializeComponent();
        }

        public FrmQm13MasterIPlanDetalle(int modo)
        {
            _modo = modo;
            InitializeComponent();
        }

        //------------------------------------------------------------------------------
        private string _idPlan;

        private readonly int _modo;
        //------------------------------------------------------------------------------

        private void FrmQM03IPDef_Load(object sender, EventArgs e)
        {
            btnAddToMaterial.Enabled = false;
            btnCreaMasterIP.Enabled = false;
            btnUpdateMetodoPlan.Enabled = false;
            btnAddMetodo.Enabled = false;

            if (_modo >= 2)
            {
                //modo edicion
                LoadData();
                btnUpdateMetodoPlan.Enabled = true;
                btnAddMetodo.Enabled = true;
                btnAddToMaterial.Enabled = true;
                return;
            }
            else
            {
                //modo new Inspection Plan
                txtIPName.ReadOnly = false;
                txtIplanDescription.ReadOnly = false;
                btnCreaMasterIP.Enabled = true;
                panel2.Enabled = false;
            }
        }

        private void LoadData()
        {
            var qm = new QmMasterIplan();
            txtIPName.Text = _idPlan;
            var headerIP = new QmMasterIplan().GetPlanHeader(_idPlan);
            txtIplanDescription.Text = headerIP.DESCRIPCION;
            if (headerIP.ACTIVO == null)
                headerIP.ACTIVO = false;

            ckPlanActivo.Checked = headerIP.ACTIVO.Value;
            t0802CQIPDEFBindingSource.DataSource = qm.GetPlanDetails(_idPlan);
        }


        private T0801_QMMasterIPHeader MapIPlanHeader()
        {
            var h = new T0801_QMMasterIPHeader()
            {
                IDPLAN = txtIPName.Text,
                DESCRIPCION = txtIplanDescription.Text,
                ACTIVO = ckPlanActivo.Checked,
                FechaCreacion = DateTime.Today,
                LogUser = Environment.UserName
            };
            return h;
        }

        private void BtnSavePlan_Click(object sender, EventArgs e)
        {
            if (ValidarGrabaNewPlan())
            {
                var msg = MessageBox.Show($@"Confirma la creacion del Plan de Inspeccion {_idPlan}?",
                    @"Confirmacion de Creacion de MIP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msg == DialogResult.No)
                    return;

                new QmMasterIplan().CreateUpdatePlanHeader(MapIPlanHeader());

                MessageBox.Show(
                    @"El Plan se ha Creado Correctamente - Agregue los metodos de inspeccion correspondientes a su nuevo plan",
                    @"Datos Creados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAddMetodo.Enabled = true;
                btnCreaMasterIP.Enabled = false;
                txtIplanDescription.ReadOnly = true;
                txtIPName.ReadOnly = true;
                panel2.Enabled = true;
            }
        }

        private bool ValidarGrabaNewPlan()
        {
            if (string.IsNullOrEmpty(txtIPName.Text))
            {
                MessageBox.Show(@"Complete el nombre del Plan de Inspeccion", @"Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (string.IsNullOrEmpty(txtIplanDescription.Text))
            {
                MessageBox.Show(@"Complete una descripcion para Plan de Inspeccion", @"Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            if (QmMasterIplan.ValidaPlanExiste(txtIPName.Text) == true)
            {
                MessageBox.Show(@"El Nombre del Plan ya Existe", @"Datos Incorrectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return false;
            }

            return true;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvDefinicionIP_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                return;
            }

            var qm = new QmMasterIplan();
            var metodoSelected = dgv[dgv.Columns[mETODODataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value
                .ToString();
            txtIdMetodoodo.Text = metodoSelected;
            var metodoData = qm.GetPlanDetailSpecific(_idPlan, metodoSelected);
            txtMetodoDescripcion.Text = new QmMetodoInspeccion().GetMetodoData(txtIdMetodoodo.Text).Descripcion;
            txtValorMin.Text = metodoData.ValorMin;
            txtValorStd.Text = metodoData.ValorStd;
            txtValorMax.Text = metodoData.ValorMax;
            txtObservacionMetodoPlan.Text = metodoData.Observacion;
            var metodoMasterData = new QmMetodoInspeccion().GetMetodoData(metodoSelected);
            txtUnit1.Text = txtUnit2.Text = txtUnit3.Text = metodoMasterData.ValorUnit;
            txtTipo1.Text = txtTipo2.Text = txtTipo3.Text = metodoMasterData.ValorType;
            txtMetodoDescripcion.Text = metodoMasterData.Descripcion;
            txtDocumentacionMetodo.Text = metodoMasterData.Documentacion;
        }

        private void TxtValorMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTipo1.Text.ToUpper() == "INT")
            {
                FormatAndConversions.SoloEnteroKeyPress(sender, e);
            }
            else if (txtTipo1.Text.ToUpper() == "DECIMAL")
            {
                FormatAndConversions.SoloDecimalKeyPress(sender, e);
            }
            else
            {
                //es texto
            }
        }

        private void DgvDefinicionIP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var boton = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var metodo = datagridview[mETODODataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            switch (boton)
            {
                case "Eliminar":
                    var resp = MessageBox.Show(
                        $@"Confirma la eliminacion del Metodo {metodo} del Plan de Inspeccion Maestro {_idPlan}?",
                        @"Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resp == DialogResult.No)
                        return;

                    var qm = new QmMasterIplan();
                    qm.DeleteMetodoPlan(_idPlan, metodo);
                    t0802CQIPDEFBindingSource.DataSource = qm.GetPlanDetails(_idPlan);
                    dgvDefinicionIP.Refresh();

                    break;

                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void BtnAddMetodo_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmQm10ListadoMetodos(_idPlan, 4))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var qm = new QmMasterIplan();
                    t0802CQIPDEFBindingSource.DataSource = qm.GetPlanDetails(_idPlan);
                    dgvDefinicionIP.Refresh();
                }
            }
        }

        private void BtnUpdatePlan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdMetodoodo.Text))
            {
                MessageBox.Show(@"No hay metodo para actualizar", @"Error de Actualizacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            new QmMasterIplan().CreateUpdatePlanHeader(MapIPlanHeader()); //updaate descripcion/ck

            if (txtTipo1.Text.ToUpper() == "INT")
            {
                if (string.IsNullOrEmpty(txtValorMin.Text))
                    txtValorMin.Text = @"0";

                if (string.IsNullOrEmpty(txtValorStd.Text))
                    txtValorStd.Text = @"0";

                if (string.IsNullOrEmpty(txtValorMax.Text))
                    txtValorMax.Text = @"0";
            }
            else if (txtTipo1.Text.ToUpper() == "DECIMAL")
            {
                if (string.IsNullOrEmpty(txtValorMin.Text))
                    txtValorMin.Text = 0.ToString("F4");

                if (string.IsNullOrEmpty(txtValorStd.Text))
                    txtValorStd.Text = 0.ToString("F4");

                if (string.IsNullOrEmpty(txtValorMax.Text))
                    txtValorMax.Text = 0.ToString("F4");
            }
            else
            {
                //es texto
            }

            var data = new T0802_QMMasterIPDetail
            {
                IDPLAN = _idPlan,
                ACTIVO = true,
                METODO = txtIdMetodoodo.Text,
                Observacion = txtObservacionMetodoPlan.Text,
                ValorMax = txtValorMax.Text,
                ValorMin = txtValorMin.Text,
                ValorStd = txtValorStd.Text
            };
            var qm = new QmMasterIplan();
            qm.UpdatePlanDetail(data);
            t0802CQIPDEFBindingSource.DataSource = qm.GetPlanDetails(_idPlan);
            dgvDefinicionIP.Refresh();
        }

        private void BtnAddToMaterial_Click(object sender, EventArgs e)
        {
            using (var f0 = new FrmQm15AsignacionMaterialIp(_idPlan))
            {
                DialogResult dr = f0.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var qm = new QmMasterIplan();
                    t0802CQIPDEFBindingSource.DataSource = qm.GetPlanDetails(_idPlan).ConvertAll(x => new { Value = x });
                    dgvDefinicionIP.Refresh();
                }
            }
        }
    }
}
