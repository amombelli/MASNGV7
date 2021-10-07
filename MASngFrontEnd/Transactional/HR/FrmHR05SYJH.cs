using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.HR;
using TecserEF.Entity;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHR05SYJH : Form
    {
        public FrmHR05SYJH()
        {
            InitializeComponent();
        }

        private List<T0520_SYJItems> _listaItems = new List<T0520_SYJItems>();
        private DataGridViewRow RowDeleted;

        private void btnAddManual_Click(object sender, EventArgs e)
        {
            using (var f = new FrmHR06SYJAddManual())
            {
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //string custName = f.CustomerName;
                    //SaveToFile(custName);
                }
            }
        }

   
        private void FrmHR05SYJH_Load(object sender, EventArgs e)
        {
            cmbConceptos.DataSource = new SyjDataManager().GetConceptos();
        }

        private void dgvData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var miDgv = (DataGridView)sender;
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            if (miDgv.CurrentCell.ColumnIndex == (int)miDgv.Columns[valorUnitarioDataGridViewTextBoxColumn.Name].Index)
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (miDgv.CurrentCell.ColumnIndex == (int)miDgv.Columns[cantidadDataGridViewTextBoxColumn.Name].Index)
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (miDgv.CurrentCell.ColumnIndex == (int)miDgv.Columns[descuentoDataGridViewTextBoxColumn.Name].Index)
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e, false);
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var miDgv = (DataGridView)sender;
            if (miDgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var cellValue = miDgv[e.ColumnIndex, e.RowIndex].Value.ToString();
                //int numeroFormula = Convert.ToInt32(dgvFormulaList[dgvFormulaList.Columns["iDFORMULADataGridViewTextBoxColumn"].Index, e.RowIndex].Value);

                switch (cellValue)
                {
                    case "DEL":
                        {
                            //var iditem =
                            //    Convert.ToInt32(dgvCobranzaItems[lINEDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
                            //var x = _listaCob.Find(c => c.LINE == iditem);
                            //if (x == null)
                            //    return;

                            //_listaCob.Remove(x);
                            //RecalculaImporteRecibo();
                            ////UpdateListWithCalculosImportes();
                            ////CompletaFormateaDataGridView();
                            ////                    SumaImportes(ckAutoIVA21.Checked);
                            ////t0407RendicionFFIBindingSource.DataSource = _lItems.ToList();
                            ////                    //dgvDetalleItems.DataSource = t0404VENDORFACTIBindingSource.DataSource;
                        }
                        break;
                    default:
                        MessageBox.Show(@"Boton no manejado aun");
                        break;
                }
            }
        }

        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var miDgv = (DataGridView)sender;
            decimal unitario = Convert.ToDecimal(miDgv[miDgv.Columns[valorUnitarioDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value);
            decimal cantidad = Convert.ToDecimal(miDgv[miDgv.Columns[cantidadDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value);
            decimal descuento = Convert.ToDecimal(miDgv[miDgv.Columns[descuentoDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value);
            miDgv[miDgv.Columns[totalDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value =
                (unitario * cantidad) - descuento;





        }

        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var miDgv = (DataGridView)sender;
            var valor = Convert.ToDecimal(miDgv[miDgv.Columns[cantidadDataGridViewTextBoxColumn.Name].Index, e.RowIndex].Value);


        }

        private void dgvData_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {


        }

        private void dgvData_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            RowDeleted = e.Row;
            var idItem = Convert.ToInt32(RowDeleted.Cells[idItemDataGridViewTextBoxColumn.Name].Value);
            var borrar = _listaItems.Find(c => c.idItem == idItem);
            _listaItems.Remove(borrar);
        }
    }
}
