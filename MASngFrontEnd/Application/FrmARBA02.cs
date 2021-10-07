using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using TecserEF.Entity;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Application
{
    public partial class FrmArba02 : Form
    {
        public FrmArba02()
        {
            InitializeComponent();
        }

        private void FrmArba02_Load(object sender, EventArgs e)
        {
            ckSoloPendientePresentacion.Checked = true;
        }
        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show(@"Revise las fechas porque estan incorrectas", @"Error en Seleccion de Fechas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaHasta.Value < dtpFechaDesde.Value)
            {
                MessageBox.Show(@"Revise las fechas porque estan incorrectas", @"Error en Seleccion de Fechas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCheck1_Click(object sender, EventArgs e)
        {
            var lx = new ManagePercepcionArbaData().GetData1(dtpFechaDesde.Value, dtpFechaHasta.Value,
                GlobalApp.CnnApp, ckSoloPendientePresentacion.Checked).ToList();
            percepcionBs.DataSource = lx;
        }

        private void btnUpdPresentado_Click(object sender, EventArgs e)
        {
            var xl = new ExcelImport(true);
            if (xl.Data.Rows.Count == 0)
            {
                MessageBox.Show(@"No se han Importado Datos", @"Archivo Inexistente o Vacio", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var resp = MessageBox.Show(@"Desea visualizar la informacion importada?", @"Visualizacion de Importacion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                using (var fx = new FrmArba03ListadoPresentacionesRaffone(xl.Data))
                {
                    fx.ShowDialog();
                }
            }

            int cantidadRecords = xl.Data.Rows.Count;

            resp = MessageBox.Show(@"Desea Realizar la Actualizacion de Presentacion en Sistema?", @"Actualizacion de Datos",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            UpdatePresentado(xl.Data);
        }

        private void UpdatePresentado(DataTable data)
        {
            if (data.Columns.Contains("N_EMIS") == false)
            {
                MessageBox.Show(@"Error en el formato del Archivo Importado", @"Error de Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //var u = data.Rows[1]["N_EMIS"].ToString();
            var iRow = 0;
            var dataUpdated = 0;
            do
            {
                string suc = data.Rows[iRow]["N_SUC"].ToString().PadLeft(4, '0');
                string docu = data.Rows[iRow]["N_EMIS"].ToString().PadLeft(8, '0');
                string doc = suc + "-" + docu;
                using (var db = new TecserData(GlobalApp.CnnApp))
                {
                    var dPer = db.T0402_FACTURA_PERCEP.SingleOrDefault(c => c.NumFactura == doc);
                    if (dPer != null)
                    {
                        dPer.Informado = true;
                    }
                    dataUpdated += db.SaveChanges();
                }
                iRow++;
            } while (iRow < data.Rows.Count);
            MessageBox.Show($"Se han Actualizado {dataUpdated} Registros en el Sistema", @"Fin de Operacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopyToClipboardWithHeaders(DataGridView dgv)
        {
            //Copy to clipboard
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DataObject dataObj = dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void toolStrip1_Click(object sender, EventArgs e)
        {

            CopyToClipboardWithHeaders(dgvListadoPerc);
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            dgvListadoPerc.SelectAll();
            CopyToClipboardWithHeaders(dgvListadoPerc);
        }
    }
}
