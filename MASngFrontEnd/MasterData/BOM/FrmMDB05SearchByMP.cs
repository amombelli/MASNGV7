using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.PP.BOM;
using TecserEF.Entity.DataStructure.BOM;

namespace MASngFE.MasterData.BOM
{
    public partial class FrmMDB05SearchByMP : Form
    {
        public FrmMDB05SearchByMP()
        {
            InitializeComponent();
        }
        private List<EstructuraMPenFormula> _data = new List<EstructuraMPenFormula>();
        private string _material;

        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {

                txtCantActivas.Text = @"0";
                txtCantInactivas.Text = @"0";
                return;
            }

            _material = cmbMaterial.SelectedValue.ToString();
            var matData = MaterialMasterManager.GetSpecificPrimaryInformation(_material);
            txtDescripcion.Text = matData.MAT_DESC;
            txtOrigen.Text = matData.ORIGEN;
            txtMtype.Text = matData.TIPO_MATERIAL;
            _data = new BOMUtilities().GetBOMContieneMateriaPrima(_material, false).OrderByDescending(c => c.UltimoUso).ToList();
            dataBs.DataSource = _data;
            txtCantActivas.Text = _data.Count(c => c.FormulaActiva).ToString();
            txtCantInactivas.Text = _data.Count(c => c.FormulaActiva == false).ToString();
        }

        private void CmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbMaterial);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMDB05SearchByMP_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = new MaterialMasterManager().GetCompleteListMaterialAvailable();
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;



        }

        private void DgvListaFormulas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idForm = Convert.ToInt32(datagridview[idFormulaDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "VER":
                    using (var f0 = new FrmMdb02BomMainData(2, idForm))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                        }
                    }

                    break;


                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void CmbMaterial_Leave(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtDescripcion.Text = null;
                txtCantActivas.Text = 0.ToString();
                txtCantInactivas.Text = 0.ToString();
                txtMtype.Text = null;
                txtOrigen.Text = null;
                dataBs.DataSource = null;
            }
        }
    }
}
