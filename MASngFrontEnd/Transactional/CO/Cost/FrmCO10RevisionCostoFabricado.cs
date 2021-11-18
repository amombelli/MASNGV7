using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO.Costos;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure.Costos;

namespace MASngFE.Transactional.CO.Cost
{
    public partial class FrmCO10RevisionCostoFabricado : Form
    {
        public FrmCO10RevisionCostoFabricado()
        {
            InitializeComponent();
        }

        private List<StxCrManufactura> lstData1;
        private Guid _guid;
        private T0034_CostRollHeader _crHeader;

        private void FrmCO10_RevisionCostoFabricado_Load(object sender, EventArgs e)
        {
            _crHeader = new CostRollManager().GetCostRollHeaderActivo();
            _guid = _crHeader.idCostRoll;
            txtGuidActivo.Text = _crHeader.idCostRoll.ToString();
            txtFechaExec.Text = _crHeader.FechaCostRoll.ToString("g");
            txtUser.Text = _crHeader.UserRun;
            lstData1 = new CostRollRevisionFabricado().GetListPTRevision();
            stxCrManufacturaBindingSource.DataSource = lstData1;
            ckPtFinalizado.Checked = _crHeader.PTFinalizado;
            ckRevisionOk.Checked = _crHeader.MPFinalizado;
            RefrescaBotones();
        }
        private void RefrescaBotones()
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var material = Convert.ToString(datagridview[materialDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "View":
                    using (var f0 = new FrmCO11_ViewCostRollManufacturedDetail(material))
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


        private void btnVerAll_Click(object sender, EventArgs e)
        {
            txtMaterial.Text = null;
            txtTipo.Text = null;
            txtMinimo.Text = 0.ToString("C3");
            txtMaximo.Text = 999999.ToString("C3");
            //t0035CostRollBs.DataSource = lstData.ToList();
            stxCrManufacturaBindingSource.DataSource = lstData1.ToList();
        }

        private void txtMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            //var lst = lstData;
            var lst1 = lstData1;

            lst1 = lstData1.Where(c => c.Material.Contains(txtMaterial.Text)).ToList();

            if (!string.IsNullOrEmpty(txtTipo.Text))
                lst1 = lst1.Where(c => c.Tipo.Contains(txtTipo.Text)).ToList();

            if (string.IsNullOrEmpty(txtMinimo.Text))
                txtMinimo.Text = 0.ToString("C3");

            if (string.IsNullOrEmpty(txtMaximo.Text))
                txtMinimo.Text = 999999.ToString("C3");

            lst1 = lst1.Where(c =>
                c.RepoUsd >= FormatAndConversions.CCurrencyADecimal(txtMinimo.Text) &&
                c.RepoUsd <= FormatAndConversions.CCurrencyADecimal(txtMaximo.Text)).ToList();

            //t0035CostRollBs.DataSource = lst.ToList();
            stxCrManufacturaBindingSource.DataSource = lstData1.ToList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRunExplosion_Click(object sender, EventArgs e)
        {
            var q = MessageBox.Show(@"Desea regenerar nuevamente toda la estructura de formulas-subformulas?",
                @"Re-Explotacion de Formulas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (q == DialogResult.No)
                return;



        }

        private void FormatoCelda_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, true, false, false, false);
        }

        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            e.Control.KeyPress -= new KeyPressEventHandler(FormatoCelda_KeyPress);
            if (dgv.CurrentCell.ColumnIndex == (int)dgv.Columns[__StdNew.Name].Index)
            {
                //Celda deseada
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(FormatoCelda_KeyPress);
                }
            }
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;  //Header
            var dgv = (DataGridView)sender;
            if (dgv.CurrentCell.ColumnIndex == (int)dgv.Columns[__StdNew.Name].Index)
            {
                //actualizar acá el costo CR.- 
                string material = dgv[materialDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
                new CostRollManager().UpdateCrCostManual(material,
                    (Convert.ToDecimal(dgv[__StdNew.Name, e.RowIndex].Value)));
            }
        }


        /// <summary>
        /// Revision 2021.06.01
        /// </summary>
        private void btnXplod_Click(object sender, EventArgs e)
        {
            var m = MessageBox.Show(
                @"Desea recalcular todos los costos de Manufactura (esta operacion puede demorar unos minutos)",
                @"Explosion de Formulas y Costeo Masivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (m == DialogResult.No)
                return;
            DateTime inicio = DateTime.Now;
            new AcostoMfgCr().GetCostXplodAll();
            DateTime final = DateTime.Now;
            TimeSpan duracion = final - inicio;
            double segundosTotales = duracion.TotalSeconds;
            MessageBox.Show($@"La Operacion de Calculo ha finalizado en {segundosTotales} segundos", @"Operacion Correcta");
        }
    }
}
