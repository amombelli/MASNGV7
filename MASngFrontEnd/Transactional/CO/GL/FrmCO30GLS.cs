using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.GLSManagement;
using TecserEF.Entity;

namespace MASngFE.Transactional.CO.GL
{
    public partial class FrmCO30GLS : Form
    {
        public FrmCO30GLS()
        {
            InitializeComponent();
        }
        private string _tipoLx;

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCO30GLS_Load(object sender, EventArgs e)
        {
            t0135GLXBindingSource.DataSource = new GLAccountManagement().GetGLAllforGLS();
            ctlPeridoDesde.Periodo = new PeriodoConversion().GetYearYyyy(DateTime.Today) + new PeriodoConversion().GetMesMm(DateTime.Today);
            ctlPeriodoHasta.Periodo = new PeriodoConversion().GetYearYyyy(DateTime.Today) + new PeriodoConversion().GetMesMm(DateTime.Today);
        }


        private void SetLx()
        {
            if (ckL1.Checked)
            {
                if (ckL2.Checked)
                {
                    _tipoLx = "L3";
                }
                else
                {
                    _tipoLx = "L1";
                }
            }
            else
            {
                if (ckL2.Checked)
                {
                    _tipoLx = "L2";
                }
                else
                {
                    MessageBox.Show(@"Debe seleccionar al menos un tipo LX", @"Datos Incompletos", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    return;
                }
            }
        }

        private void btnVerDetalleMovimientosGL_Click(object sender, EventArgs e)
        {
            SetLx();


            if (cmbGLAccount.SelectedItem == null)
            {
                MessageBox.Show(@"Debe seleccionar al menos una cuenta contable", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            List<T0602_DOCU_S> lista = new GLSManagement().VerDetalleMovimientoGL(ctlPeridoDesde.Periodo,
                ctlPeriodoHasta.Periodo, _tipoLx, cmbGLAccount.SelectedValue.ToString(), ckAcumulaHijos.Checked);

            t0602DOCUSBindingSource.DataSource = lista;
            decimal totalDebe = lista.Sum(c => c.DEBE.Value);
            decimal totalHaber = lista.Sum(c => c.HABER.Value);
            txtSaldoDebe.Text = totalDebe.ToString("C2");
            txtSaldoHaber.Text = totalHaber.ToString("C2");
            txtSaldoCuenta.Text = (totalDebe - totalHaber).ToString("C2");
            txtSaldoCuenta.ForeColor = totalDebe > totalHaber ? Color.DarkBlue : Color.MediumVioletRed;
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            SetLx();
            new GLSManagement().Tree(cmbGLAccount.Text, ctlPeridoDesde.Periodo, ctlPeriodoHasta.Periodo, _tipoLx);

            var f = new FrmCO31GLS_TreeResults();
            f.Show();

        }

        private void dgvGLS_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn) || e.RowIndex < 0) return;

            if (e.ColumnIndex != 0)
                return;

            //var asiento = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var asiento = Convert.ToInt32(datagridview[iDDOCUDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            var segmento = Convert.ToInt32(datagridview[IDSEG.Name, e.RowIndex].Value);
            var f = new FrmCO32GLSReclass(asiento, segmento);
            f.Show();
        }
    }
}
