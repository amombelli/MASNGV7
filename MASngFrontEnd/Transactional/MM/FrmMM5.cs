using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Tools;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.MM
{
    public partial class FrmMM5 : Form
    {
        public FrmMM5()
        {
            InitializeComponent();
        }

        public FrmMM5(int modo)
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------------------------------------
        private List<MM5Structure> _data = new List<MM5Structure>();
        private Color _ckSelect = Color.LimeGreen;
        private Color _ckUnselect = Color.Orange;
        //------------------------------------------------------------------------------------------------------

        private void FrmTest_Load(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }

        private void ConfiguracionInicial()
        {
            cmbMaterial.DataSource = new MaterialMasterManager().GetCompleteListofMaterial();
            cmbMaterial.Text = null;
            dtpFechaDesde.Value = DateTime.Today.AddMonths(-6);
            //dtpFechaHasta.Value = DateTime.Today;
            //
            ckVerCambioEstado.Checked = true;
            ckVerMovimientosSLOC.Checked = true;
            ckIC.Checked = true;
            ckDescuentoMP.Checked = true;
            ckRetorno.Checked = true;
            ckAjusteStock.Checked = true;
            ckFabricadoTemp.Checked = true;
            ckFabricadoFinal.Checked = true;
            ckFacturacionRE.Checked = true;
            //
            ckVerCambioEstado.BackColor = _ckSelect;
            ckVerMovimientosSLOC.BackColor = _ckSelect;
            ckIC.BackColor = _ckSelect;
            ckDescuentoMP.BackColor = _ckSelect;
            ckRetorno.BackColor = _ckSelect;
            ckAjusteStock.BackColor = _ckSelect;
            ckFabricadoTemp.BackColor = _ckSelect;
            ckFabricadoFinal.BackColor = _ckSelect;
            ckFacturacionRE.BackColor = _ckSelect;
            //

            _data = new MM5Data().GetData(dtpFechaDesde.Value, dtpFechaHasta.Value, GlobalApp.CnnApp,
                Convert.ToInt32(100));
            txtRecordsInList.Text = _data.Count.ToString();

            mM5StructureBindingSource.DataSource = _data;
            dgvLista.DataSource = mM5StructureBindingSource.DataSource;
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
                return;
            GetData();

            ApplyFilters();
        }


        private void GetData()
        {
            if (string.IsNullOrEmpty(cmbMaterial.Text))
            {
                _data = new MM5Data().GetData(dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date, GlobalApp.CnnApp,
                   Convert.ToInt32(txtnumeroMaxRecords.Text));
            }
            else
            {
                _data = new MM5Data().GetData(dtpFechaDesde.Value, dtpFechaHasta.Value, GlobalApp.CnnApp,
                    Convert.ToInt32(txtnumeroMaxRecords.Text), cmbMaterial.SelectedValue.ToString());
            }
        }

        private void dtpFechaDesde_ValueChanged_1(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show(@"La fecha desde no puede ser mayor a la fecha hasta", @"Error en la fecha",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GetData();
            ApplyFilters();
        }

        private void dtpFechaHasta_ValueChanged_1(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show(@"La fecha desde no puede ser mayor a la fecha hasta", @"Error en la fecha",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GetData();
            ApplyFilters();
        }

        private void txtnumeroMaxRecords_TextChanged(object sender, EventArgs e)
        {
            GetData();
            ApplyFilters();
        }




        private void ApplyFilters()
        {
            var filteredList = _data;

            if (ckVerMovimientosSLOC.Checked == false)
            {
                filteredList = filteredList.Where(c => c.TD != "TX").ToList();
            }

            if (ckVerCambioEstado.Checked == false)
            {
                filteredList = filteredList.Where(c => c.TD != "CQ").ToList();
            }

            if (ckFacturacionRE.Checked == false)
            {
                filteredList = filteredList.Where(c => c.TD != "RE").ToList();
            }

            if (ckFabricadoFinal.Checked == false)
            {
                filteredList = filteredList.Where(c => c.TMov != 1).ToList();
                filteredList = filteredList.Where(c => c.TMov != 2).ToList();
            }

            if (ckFabricadoTemp.Checked == false)
            {
                filteredList = filteredList.Where(c => c.TMov != 503).ToList();
                filteredList = filteredList.Where(c => c.TMov != 504).ToList();
            }

            if (ckAjusteStock.Checked == false)
            {
                filteredList = filteredList.Where(c => c.TD != "AI").ToList();
                filteredList = filteredList.Where(c => c.TD != "AJ").ToList();
            }

            if (ckRetorno.Checked == false)
            {
                filteredList = filteredList.Where(c => c.TD != "RTN").ToList();
            }

            if (ckDescuentoMP.Checked == false)
            {
                filteredList = filteredList.Where(c => c.TMov != 10).ToList();
                filteredList = filteredList.Where(c => c.TMov != 11).ToList();
            }

            if (ckIC.Checked == false)
            {
                filteredList = filteredList.Where(c => c.TMov != 100).ToList();
                filteredList = filteredList.Where(c => c.TMov != 101).ToList();
            }

            dgvLista.DataSource = new MySortableBindingList<MM5Structure>(filteredList);
            txtRecordsInList.Text = filteredList.Count.ToString();
            txtKgSeleccionados.Text = filteredList.Sum(c => c.Cantidad).ToString("N2");
        }

        #region Ck
        private void ckVerMovimientosSLOC_CheckedChanged(object sender, EventArgs e)
        {
            ckVerMovimientosSLOC.BackColor = ckVerMovimientosSLOC.Checked ? _ckSelect : _ckUnselect;
            ApplyFilters();
        }

        private void ckVerCambioEstado_CheckedChanged(object sender, EventArgs e)
        {
            ckVerCambioEstado.BackColor = ckVerCambioEstado.Checked ? _ckSelect : _ckUnselect;
            ApplyFilters();
        }



        #endregion
        #region botones

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
        }

        private void btnResetFilters_Click(object sender, EventArgs e)
        {
        }


        #endregion

        private void ckIC_CheckedChanged(object sender, EventArgs e)
        {
            var x = (CheckBox)sender;
            x.BackColor = x.Checked ? _ckSelect : _ckUnselect;
            ApplyFilters();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ckVerCambioEstado.Checked = true;
            ckVerMovimientosSLOC.Checked = true;
            ckIC.Checked = true;
            ckDescuentoMP.Checked = true;
            ckRetorno.Checked = true;
            ckAjusteStock.Checked = true;
            ckFabricadoTemp.Checked = true;
            ckFabricadoFinal.Checked = true;
            ckFacturacionRE.Checked = true;
        }
        private void btnNone_Click(object sender, EventArgs e)
        {
            ckVerCambioEstado.Checked = false;
            ckVerMovimientosSLOC.Checked = false;
            ckIC.Checked = false;
            ckDescuentoMP.Checked = false;
            ckRetorno.Checked = false;
            ckAjusteStock.Checked = false;
            ckFabricadoTemp.Checked = false;
            ckFabricadoFinal.Checked = false;
            ckFacturacionRE.Checked = false;
        }
    }
}
