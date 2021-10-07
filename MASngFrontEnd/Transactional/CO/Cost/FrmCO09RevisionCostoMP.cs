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
    public partial class FrmCO09RevisionCostoMP : Form
    {
        public FrmCO09RevisionCostoMP()
        {
            InitializeComponent();
        }

        private List<StxCrReposicion> _data;
        private Guid _guid;
        private T0034_CostRollHeader _crHeader;

        private void FrmCO09_RevisionCostoMP_Load(object sender, EventArgs e)
        {
            _crHeader = new CostRollManager().GetCostRollHeaderActivo();
            _guid = _crHeader.idCostRoll;
            txtGuid.Text = _crHeader.idCostRoll.ToString();
            txtFecha.Text = _crHeader.FechaCostRoll.ToString("g");
            _data = new CostRollRevisionMP().GetListMPRevision(true);
            RevisionMpBs.DataSource = _data.ToList();
            RefrescaBotones();
        }

        private void RefrescaBotones()
        {
            ckMpRevisionOk.Checked = _crHeader.MPFinalizado;
            ckPtFinalizado.Checked = _crHeader.PTFinalizado;
            if (_crHeader.MPFinalizado)
            {
                btnFinalizarRevisionMp.Enabled = false;
                //si se encuentra finalizdo el PT no permite re-abrir MP Revision
                btnAbrirRevision.Enabled = !_crHeader.PTFinalizado;
            }
            else
            {
                //la revision de MP aun no esta finalizada
                btnFinalizarRevisionMp.Enabled = true;
                btnAbrirRevision.Enabled = false;
                btnRegenearaCostosMP.Enabled = true;
            }
        }

        private void btnRegenearaCostosMP_Click(object sender, EventArgs e)
        {
            var m = MessageBox.Show(@"Confirma la Regeneracion de costos de MP (Sobreescribe los costos de Repo con los ultimos de UC",
                @"Regeneracion de Costos MP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (m == DialogResult.No)
                return;
            new CostRollManager().PegaCostosMP_T0035();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckDiferenciaCosto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDiferenciaCosto.Checked)
            {
                RevisionMpBs.DataSource = _data.Where(c => c.VarRepoStdUsd != 0).ToList();
            }
            else
            {
                RevisionMpBs.DataSource = _data.ToList();
            }
        }
        private void btnFinalizarRevisionMp_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(@"Confirma la finalizacion de revision de costo de MP?", @"Revision MP Finalizada",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            new CostRollManager().SetRevisionMPFinalizada(_guid);
            RefrescaBotones();
        }
        private void btnAbrirRevision_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(@"Confirma la Apertura de revision de costo de MP?", @"Revision MP En Proceso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;
            new CostRollManager().SetRevisionMPOpen(_guid);
            RefrescaBotones();
        }
        private void dgvRepoRevison_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //ir a ver el costo UC
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var material = Convert.ToString(datagridview[materialDataGridViewTextBoxColumn1.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "REPO":
                    using (var f0 = new FrmCO02_Reposicion(material))
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

        private void dgvRepoRevison_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;  //Header
            var dgv = (DataGridView)sender;
            if (dgv.CurrentCell.ColumnIndex == (int)dgv.Columns[__stdNew.Name].Index)
            {
                //actualizar acá el costo CR.- 
                string material = dgv[materialDataGridViewTextBoxColumn1.Name, e.RowIndex].Value.ToString();
                new CostRollManager().UpdateCrCostManual(material,
                    (Convert.ToDecimal(dgv[__stdNew.Name, e.RowIndex].Value)));
            }
        }


        //Validacion de Formato de Celda en DGV
        private void dgvRepoRevison_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            e.Control.KeyPress -= new KeyPressEventHandler(FormatoCelda_KeyPress);
            if (dgv.CurrentCell.ColumnIndex == (int)dgv.Columns[__stdNew.Name].Index)
            {
                //Celda deseada
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(FormatoCelda_KeyPress);
                }
            }
        }

        private void FormatoCelda_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, true, false, false, false);
        }
    }
}
