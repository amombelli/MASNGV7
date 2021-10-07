using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.MM.MRPController;
using TecserEF.Entity.DataStructure.MRP;

namespace MASngFE.Transactional.MM.MRP
{
    public partial class FrmMRP02 : Form
    {
        public FrmMRP02()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------
        List<MRP1Struct> _dataCruda = new List<MRP1Struct>();
        //-------------------------------------------------------------------------------------------------

        private void FrmMRP02_Load(object sender, EventArgs e)
        {
            ckFormulado.Checked = true;
            ckPlaneado.Checked = true;
            ckProceso.Checked = true;
            ckStandBy.Checked = true;
        }

        private void BtnRunAll_Click(object sender, EventArgs e)
        {
            dgvMRPCompleto.ClearSelection();
            _dataCruda.Clear();
            Cursor.Current = Cursors.WaitCursor;
            _dataCruda = new MRPManager().DoAll(ckFormulado.Checked, ckProceso.Checked, ckPlaneado.Checked,
                ckStandBy.Checked);
            dgvMRPCompleto.DataSource = new MySortableBindingList<MRP1Struct>(_dataCruda);
            //MrpCompletoBs.DataSource = _dataCruda;
            Cursor.Current = Cursors.Default;







            MessageBox.Show(@"Se ha finalizado correctamente la explosion de MP Necesarias", @"MRP1 Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMPConsolidaList_Click(object sender, EventArgs e)
        {
            if (_dataCruda.Count == 0)
            {
                MessageBox.Show(@"No Existen Datos para procesar (Ejecute DO All)", @"Sin Datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            var listaMP = new MRPManager().SumarizaMPConsumption(_dataCruda);
            var f = new FrmMRP03(listaMP);
            f.Show();
        }
    }
}
