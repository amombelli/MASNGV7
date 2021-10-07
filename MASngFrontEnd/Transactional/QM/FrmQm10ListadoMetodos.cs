using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm10ListadoMetodos : Form
    {
        /// <summary>
        /// Constructor para agregar metodos a planes existentes
        /// </summary>
        public FrmQm10ListadoMetodos(string idPlan, int modo = 4)
        {
            _idPlan = idPlan;
            _modo = modo;
            InitializeComponent();
        }

        //------------------------------------------------------------------------------
        private readonly int _modo;
        private readonly string _idPlan;
        private string _metodoToAdd;
        //------------------------------------------------------------------------------


        //UNIDADES PARA METODOS
        //1. INT
        //2. DECIMAL
        //3. TEXT


        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void BtnSavePlan_Click(object sender, EventArgs e)
        {
            if (_metodoToAdd == null)
            {
                MessageBox.Show($@"No hay metodos disponibles para ser agregado al MASTER INSPECCTION PLAN",
                    @"Confirmacion de Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var msg = MessageBox.Show($@"Desea agregar el METODO : ** {_metodoToAdd} ** al PLAN > {_idPlan} < ?",
                @"Confirmacion de Agregado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.No)
                return;

            var resp = new QmMasterIplan().AddMetodoToPlan(_idPlan, _metodoToAdd);
            if (resp == true)
            {
                MessageBox.Show($@"El Metodo se ha agregado correctamente al Plan {_idPlan}", @"Alta de Metodo-Plan",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    $@"Ha Ocurrido un error al intentar dar de alta el Metodo {_metodoToAdd} al Plan Seleccionado",
                    @"Alta de Metodo-Plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmQm10ListadoMetodos_Load(object sender, EventArgs e)
        {
            var qm = new QmMasterIplan().GetPlanHeader(_idPlan);
            txtIPName.Text = _idPlan;
            txtIplanDescription.Text = qm.DESCRIPCION;
            ckPlanActivo.Checked = qm.ACTIVO.Value;

            switch (_modo)
            {
                case 4:
                    //Agregado de Metodos a un IPlan
                    t0800CQMETODOSBindingSource.DataSource = new QmMasterIplan()
                        .GetMetodosAvailableToAddToSpecificPlan(_idPlan).OrderBy(c => c.IdMetodo).ToList();
                    btnAddMetodoToPlan.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void DgvListadoMetodos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                _metodoToAdd = null;
                return;
            }
            _metodoToAdd = dgv[dgv.Columns[IdMetodoDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value.ToString();
        }

    }
}
