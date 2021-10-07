using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO.GLSManagement;

namespace MASngFE.Transactional.CO.GL
{
    public partial class FrmCO20AbmGLAccounts : Form
    {
        private readonly int _modo;

        public FrmCO20AbmGLAccounts(int modo = 0)
        {
            _modo = modo;
            InitializeComponent();
        }
        private void SetModo()
        {
            switch (_modo)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        private void FrmCO20AbmGLAccounts_Load(object sender, EventArgs e)
        {
            SetModo();
            t0130GLL0BindingSource.DataSource = new GLAccountManager().GetAllLevel0();
            cmbGLLevel0.SelectedIndex = -1;
            cmbGl0Description.SelectedIndex = -1;
        }

        private void cmbGLLevel0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGLLevel0.SelectedIndex == -1)
            {
                cmbGl1Description.SelectedIndex = -1;
                return;
            }

            var gl0 = new GLAccountManager().GetLevel0(Convert.ToInt32(cmbGLLevel0.SelectedValue));
            ckGl1Pi.Checked = gl0.PI;
            ckGl0Activa.Value = true;
            txtGl0Map.Text = gl0.IDC2;

            t0131GLL1BindingSource.DataSource =
                new GLAccountManager().GetAllLevel1DefinedByPreviousLevel(
                    Convert.ToInt32(cmbGLLevel0.SelectedValue));

            cmbGLLevel1.SelectedIndex = -1;
            cmbGl1Description.SelectedIndex = -1;
            //
            t0132GLL2BindingSource.DataSource = null;
            t0133GLL3BindingSource.DataSource = null;
            t0134GLL4BindingSource.DataSource = null;
            //
        }

        private void cmbGl1Description_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void cmbGLLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGLLevel1.SelectedIndex == -1)
            {
                cmbGl1Description.SelectedIndex = -1;
                //clear selection
                ckGl1Pi.Checked = false;
                ckGl1Activa.Value = false;
                txtGl1Map.Text = null;
                t0132GLL2BindingSource.DataSource = null;
                return;
            }

            var gl1 = new GLAccountManager().GetLevel1(cmbGLLevel1.SelectedValue.ToString());
            if (gl1 == null)
            {
                return;
            }

            txtGl1Map.Text = gl1.IDC;
            ckGl1Pi.Checked = gl1.PI.Value;
            ckGl1Activa.Value = gl1.ACTIVO.Value;
            t0132GLL2BindingSource.DataSource = new GLAccountManager().GetAllLevel2DefinedByPreviousLevel(gl1.IDC);
            dgvL2.ClearSelection();
            ClearLevel2();
            t0133GLL3BindingSource.DataSource = null;
            t0134GLL4BindingSource.DataSource = null;
        }

        private void ClearLevel2()
        {
            dgvL2.ClearSelection();
            txtGl2.Text = null;
            txtGl2Descripcion.Text = null;
            txtGl2Documentacion.Text = null;
            ckGl2PI.Value = false;
            ckGl2Activa.Value = false;
            txtGl2Alter.Text = null;
        }
        private void ClearLevel3()
        {
            dgvL3.ClearSelection();
            txtGl3.Text = null;
            txtGl3Descripcion.Text = null;
            txtGl3Documentacion.Text = null;
            ckGl3PI.Value = false;
            ckGl3Activa.Value = false;
            txtGl3Alter.Text = null;
        }
        private void ClearLevel4()
        {
            dgvL4.ClearSelection();
            txtGl4.Text = null;
            txtGl4Descripcion.Text = null;
            txtGl4Documentacion.Text = null;
            ckGl4PI.Value = false;
            ckGl4Activa.Value = false;
            txtGl4Alter.Text = null;
        }

        private void cmbGl0Description_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvL2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                return;
            }

            var idL2 = dgv[GL2IDC.Name, e.RowIndex].Value.ToString();
            txtGl2.Text = idL2;
            var gl2 = new GLAccountManager().GetLevel2(idL2);
            txtGl2Descripcion.Text = gl2.CUENTA_D;
            txtGl2Documentacion.Text = gl2.DOCUMENTACION;
            ckGl2Activa.Value = gl2.ACTIVO.Value;
            ckGl2PI.Value = gl2.PI.Value;
            txtGl2Alter.Text = gl2.IDC2;
            //
            t0133GLL3BindingSource.DataSource = new GLAccountManager().GetAllLevel3DefinedByPreviousLevel(idL2);
            dgvL3.ClearSelection();
            t0134GLL4BindingSource.DataSource = null;
            ClearLevel3();
            ClearLevel4();
        }

        private void dgvL3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                return;
            }

            var idL3 = dgv[GL3IDC.Name, e.RowIndex].Value.ToString();
            txtGl3.Text = idL3;
            var gl3 = new GLAccountManager().GetLevel3(idL3);
            txtGl3Descripcion.Text = gl3.CUENTA_D;
            txtGl3Documentacion.Text = gl3.DOCUMENTACION;
            ckGl3Activa.Value = gl3.ACTIVO.Value;
            ckGl3PI.Value = gl3.PI.Value;
            txtGl3Alter.Text = gl3.IDC2;

            t0134GLL4BindingSource.DataSource = new GLAccountManager().GetAllLevel4DefinedByPreviousLevel(idL3);
            dgvL4.ClearSelection();
            ClearLevel4();
        }

        private void dgvL4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                return;
            }

            var idL4 = dgv[GL4IDC.Name, e.RowIndex].Value.ToString();
            txtGl4.Text = idL4;
            var gl4 = new GLAccountManager().GetLevel4(idL4);
            txtGl4Descripcion.Text = gl4.CUENTA_D;
            txtGl4Documentacion.Text = gl4.Documentacion;
            ckGl4Activa.Value = gl4.ACTIVO.Value;
            ckGl4PI.Value = gl4.PI.Value;
            txtGl4Alter.Text = gl4.IDC2;
        }

        private void btnNuevaContabilizacion_Click(object sender, EventArgs e)
        {
            new GLAccountManager().GenerateNewTree135();
            MessageBox.Show(@"finalice");
        }
    }
}
