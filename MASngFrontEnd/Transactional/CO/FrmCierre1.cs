using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO
{
    public partial class FrmCierre1 : Form
    {
        public FrmCierre1(int modo = -1)
        {
            InitializeComponent();
        }


        //-------------------------------------------------------------------------------------------------
        private string _tipoLx;
        //-------------------------------------------------------------------------------------------------

        private void FrmCierre1_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtPeriodo.Text = new PeriodoConversion().GetPeriodo(Convert.ToDateTime(txtFecha.Text));
            txtFechaDesde.Text = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text).ToShortDateString();
            txtFechaHasta.Text = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text).ToShortDateString();
            ckL1.Checked = true;
            ckL2.Checked = false;
            ckIncluirFA.Checked = true;
            ckIncluirND.Checked = true;
            ckIncluirNC.Checked = true;
            ckIncluirAJ.Checked = false;


        }

        private void txtPeriodo_Validating(object sender, CancelEventArgs e)
        {
            txtFechaDesde.Text = new PeriodoConversion().GetFechaPrimerDiaPeriodo(txtPeriodo.Text).ToString("d");
            txtFechaHasta.Text = new PeriodoConversion().GetFechaUltimoDiaPeriodo(txtPeriodo.Text).ToString("d");
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (_tipoLx == "L0")
            {
                MessageBox.Show(@"Debe completar L1/L2 para continuar", @"Error en LX", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var concilGral = new ConciliaGeneral().ResultadoCuentasGeneral(txtPeriodo.Text, _tipoLx,
                ckIncluirFA.Checked, ckIncluirNC.Checked, ckIncluirND.Checked, ckIncluirAJ.Checked);


            txtImporteCobGral.Text = concilGral.importeCob201.ToString("c2");
            txtImporteFactuGral.Text = concilGral.ImporteFa201.ToString("c2");
            txtImporteCobGral205.Text = concilGral.ImporteCob205.ToString("c2");
            txtImporteFactGral400.Text = concilGral.ImporteFa400.ToString("c2");
            txtImporteFA.Text = concilGral.ImporteFa.ToString("C2");
            txtImporteNC.Text = concilGral.ImporteNc.ToString("C2");
            txtImporteND.Text = concilGral.ImporteNd.ToString("C2");
            txtimporteAJ.Text = concilGral.ImporteAj.ToString("C2");
            if (concilGral.ImporteAj == 0)
            {
                labelNoAjuste.Visible = false;
            }
            else
            {
                labelNoAjuste.Visible = true;
            }

            if (concilGral.importeCob201 == concilGral.ImporteCob205)
            {
                txtImporteCobGral.BackColor = Color.GreenYellow;
            }
            else
            {
                txtImporteCobGral.BackColor = Color.LightPink;
            }

            if (concilGral.ImporteFa400 == (concilGral.ImporteFa201 - concilGral.ImporteAj))
            {
                txtImporteFactuGral.BackColor = Color.GreenYellow;
            }
            else
            {
                txtImporteFactuGral.BackColor = Color.Orange;
            }


            var z = new ConciliaGeneral().ConciliaDesde(txtPeriodo.Text, Convert.ToInt32(txtCantidadPeriodos.Text),
                _tipoLx, ckIncluirFA.Checked, ckIncluirNC.Checked, ckIncluirND.Checked, ckIncluirAJ.Checked);
            retornoConciliacionBs.DataSource = z;
        }


        private void dgvResumenData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                var cellValue = dgvResumenData[e.ColumnIndex, e.RowIndex].Value.ToString();
                var columnaNombre = dgvResumenData.Columns[e.ColumnIndex].Name;
                var cellPeriodo = dgvResumenData[0, e.RowIndex].Value.ToString();

                switch (columnaNombre)
                {
                    case "factu400DataGridViewTextBoxColumn":
                        using (var f = new FrmDetalleDocumentos(cellPeriodo, _tipoLx, "T400"))
                        {
                            f.ShowDialog();
                        }
                        break;
                    default:
                        break;
                }
            }

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            //    e.RowIndex >= 0)
            //{
            //    var cellValue = dgvInfoAKA[e.ColumnIndex, e.RowIndex].Value.ToString();

            //    string primario = dgvInfoAKA[dgvInfoAKA.Columns["pRIMARIODataGridViewTextBoxColumn"].Index, e.RowIndex].Value.ToString();
            //    string aka = dgvInfoAKA[dgvInfoAKA.Columns["cODVENTADataGridViewTextBoxColumn"].Index, e.RowIndex].Value.ToString();

            //    switch (cellValue)
            //    {
            //        case "DETALLE":
            //            using (var f0 = new FrmMaterialMasterAKA(primario, _modo, aka))
            //            {
            //                DialogResult dr = f0.ShowDialog();
            //                if (dr == DialogResult.OK)
            //                {
            //                    //string custName = f0.CustomerName;
            //                    //SaveToFile(custName);
            //                }
            //            }

            //            break;


            //        default:
            //            MessageBox.Show(@"Boton no manejado aun");
            //            break;
            //    }
            //}
        }
        private void ckL1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL1.Checked)
            {
                _tipoLx = ckL2.Checked ? "L3" : "L1";
            }
            else
            {
                _tipoLx = ckL2.Checked ? "L2" : "L0";
            }
        }
        private void ckL2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckL2.Checked)
            {
                _tipoLx = ckL1.Checked ? "L3" : "L2";
            }
            else
            {
                _tipoLx = ckL1.Checked ? "L1" : "L0";
            }
        }
        private void txtPeriodo_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                toolTip1.ToolTipTitle = "Invalid Date";
                toolTip1.Show("The data you supplied must be a valid date in the format mm/dd/yyyy.", txtPeriodo, 0, -20,
                    5000);
            }
            else
            {
                //Now that the type has passed basic type validation, enforce more specific type rules.
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate < DateTime.Now)
                {
                    toolTip1.ToolTipTitle = "Invalid Date";
                    toolTip1.Show("The date in this field must be greater than today's date.", txtPeriodo, 0, -20, 5000);
                    e.Cancel = true;
                }
            }
        }
        private void txtCantidadPeriodos_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }
    }
}
