using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.PP.BOM;
using TecserEF.Entity;

namespace MASngFE.Transactional.MM.MMR
{
    public partial class FrmMaterialMasterRename : Form
    {
        public FrmMaterialMasterRename()
        {
            InitializeComponent();
        }

        private bool _allowed = false;

        private void FrmMaterialMasterRename_Load(object sender, EventArgs e)
        {
            InitialConfig();
        }

        public void startFunction()
        {
            if (_allowed)
            {
                txtNewName.BackColor = Color.GreenYellow;
            }
            else
            {
                txtNewName.BackColor = Color.DarkOrange;
            }
        }



        public void InitialConfig()
        {
            t0010MATERIALESBindingSource.DataSource = new MaterialMasterManager().GetCompleteListofMaterial();

        }

        private void btnRenameMaterial_Click(object sender, EventArgs e)
        {

        }
        private void txtNewName_Leave(object sender, EventArgs e)
        {
            if (txtNewName.Text.Length == 0)
            {
                _allowed = false;
            }

            var mmr = new Tecser.Business.MasterData.Material_Master.MMR();
            _allowed = mmr.ChecknewNameIsValid(txtNewName.Text);

            dgvListOfAka.DataSource = new MaterialMasterManager().GetListOfAvailableAkaFromPrimario(txtNewName.Text);

            startFunction();
        }
        private void cmbMaterialPrimario_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvListFormulasContain.DataSource =
                new BOMUtilities().GetMaterialsManufacturedWithRawMaterial(cmbMaterialPrimario.SelectedValue.ToString());
        }

        private void dgvListFormulasContain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var cellValue = dgvListFormulasContain[e.ColumnIndex, e.RowIndex].Value.ToString();

                int idFormula = Convert.ToInt32(dgvListFormulasContain[dgvListFormulasContain.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "CHANGE":

                        if (string.IsNullOrEmpty(txtNewName.Text))
                            MessageBox.Show(@"Debe proveer un codigo de reemplazo", @"Codigo de Reemplazo");

                        new BOMUtilities().RenameBomItem(idFormula, cmbMaterialPrimario.SelectedValue.ToString(),
                            txtNewName.Text);

                        break;



                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }

            }
        }

        private void btnChangeHistoria_Click(object sender, EventArgs e)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var x =
                    db.T0072_FORMULA_TEMP.Where(c => c.Primario.Equals(cmbMaterialPrimario.SelectedValue.ToString()))
                        .Select(c => c.NForm)
                        .Distinct();

                foreach (var i in x)
                {
                    new BOMUtilities().RenameBomItemHistory(i, cmbMaterialPrimario.SelectedValue.ToString(),
                        txtNewName.Text);
                }

            }
        }
    }
}
