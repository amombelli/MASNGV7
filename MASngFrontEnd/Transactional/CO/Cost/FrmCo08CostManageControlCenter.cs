using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO.Costos;
using TecserEF.Entity;
using TSControls;

namespace MASngFE.Transactional.CO.Cost
{


    /// <summary>
    /// CO08 - Interfaz Centro de Control de Costos
    /// </summary>
    public partial class FrmCo08CostManageControlCenter : Form
    {
        public FrmCo08CostManageControlCenter()
        {
            InitializeComponent();
        }
        
        private Guid? _costRollId = null;
        private T0034_CostRollHeader _crHeader;
        private void FrmCO08_CostManageControlCenter_Load(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        private void UpdateStatus()
        {
            if (_costRollId == null)
            {
                //Carga el Ultimo Cost Roll Generado
                _crHeader = new CostRollManager().GetCostRollHeaderActivo();
                _costRollId = _crHeader.idCostRoll;
                txtGuidActivo.Text = _crHeader.idCostRoll.ToString();
                txtFecha.Text = _crHeader.FechaCostRoll.ToString("g");
                txtUser.Text = _crHeader.UserRun;
                ctlRevisionMP.SetLights = _crHeader.MPFinalizado
                    ? CtlSemaforo.ColoresSemaforo.Verde
                    : CtlSemaforo.ColoresSemaforo.Rojo;
                ctlRevisionPT.SetLights = _crHeader.PTFinalizado
                    ? CtlSemaforo.ColoresSemaforo.Verde
                    : CtlSemaforo.ColoresSemaforo.Rojo;
                ctlRevisionStandard.SetLights = _crHeader.StandardSet
                    ? CtlSemaforo.ColoresSemaforo.Verde
                    : CtlSemaforo.ColoresSemaforo.Rojo;
                txtCostRollDescripcion.Text = _crHeader.Comentario;
            }
            else
            {
                //Funcion para proveer datos de un CostsRoll diferente desde pantalla de seleccion
                //No Implementado
            }
            btnSetAsStandard.Enabled = true;
        }
        
        #region Botones
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCostoRepoMP_Click(object sender, EventArgs e)
        {
            new FrmCO09RevisionCostoMP().Show();
        }
        private void btnRepoMfg_Click(object sender, EventArgs e)
        {
            var f1 = new FrmCO10RevisionCostoFabricado();
            f1.Show();
        }
        private void btnCreateNewCostRoll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCostRollDescripcion.Text))
            {
                MessageBox.Show(@"Confirme una Descripcion para Identificar este Cost-Roll", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var q = MessageBox.Show(
                @"Confirma la creacion de un nuevo modelo de costos? (CR) - Se eliminaran los costos activos en proceso y se regenerará toda la estructura nuevamente",
                @"Confirmacion de Ejecucion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (q == DialogResult.No)
                return;

            if (new CostRollManager().CheckComentarioExiste(txtCostRollDescripcion.Text))
            {
                MessageBox.Show(@"Debe definir una Descripcion Diferente para Identificar este Cost-Roll", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            _costRollId = new CostRollManager().NewHeader(txtCostRollDescripcion.Text);
            txtGuidActivo.Text = _costRollId.ToString();
            txtGuidActivo.BackColor = Color.LightGreen;
            txtFecha.Text = DateTime.Now.ToString("g");

            MessageBox.Show(@"Se ha generado nuevamente una estructura de Cost-Roll", @"CR En Proceso OK",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnCreateNewCostRoll.Enabled = true;
            btnRepoMP.Enabled = true;
            btnRepoMfg.Enabled = false;
            btnSetAsStandard.Enabled = false;
            UpdateStatus();
        }
        private void btnSetAsStandard_Click(object sender, EventArgs e)
        {
            new CostRollManager().SetStandardMassive();
        }
        private void btnVerStandard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcion no definida aun");
        }



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}