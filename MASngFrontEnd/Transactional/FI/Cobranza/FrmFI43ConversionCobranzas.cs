using System;
using System.Windows.Forms;
using MASngFE.Reports.ReportManager;
using Tecser.Business.Transactional.FI.Cobranza;

namespace MASngFE.Transactional.FI.Cobranza
{
    public partial class FrmFI43ConversionCobranzas : Form
    {
        public FrmFI43ConversionCobranzas()
        {
            InitializeComponent();
        }

        private void FrmConversionCobranzas_Load(object sender, EventArgs e)
        {
            SetInitialData();
        }

        private void SetInitialData()
        {
            t1205CobranzaConvertirHeaderBindingSource.DataSource = new CobranzaTemporalManager().GetListado(CobranzaTemporalManager.StatusCobranzaTemporal.Ingresada);
        }

        private void dgvListadoCobranzas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = dgvListadoCobranzas[e.ColumnIndex, e.RowIndex].Value.ToString();
                switch (cellValue)
                {
                    case "CONTA":
                        {
                            var idCobTemporal =
                                Convert.ToInt32(
                                    dgvListadoCobranzas[idCobTempDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                            var f = new FrmIngresoCobranza(2, idCobTemporal);
                            f.Show();
                            break;
                        }

                    case "PRINT":
                        {
                            var idCobTemporal =
                                Convert.ToInt32(
                                    dgvListadoCobranzas[idCobTempDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                            var f = new RpvReciboTemporal(idCobTemporal);
                            f.Show();
                            break;
                        }
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckViewAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckViewAll.Checked)
            {
                t1205CobranzaConvertirHeaderBindingSource.DataSource = new CobranzaTemporalManager().GetListado();
            }
            else
            {
                t1205CobranzaConvertirHeaderBindingSource.DataSource = new CobranzaTemporalManager().GetListado(CobranzaTemporalManager.StatusCobranzaTemporal.Ingresada);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
