using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CRM;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmCRM02GescoSelect : Form
    {
        public FrmCRM02GescoSelect()
        {
            InitializeComponent();
        }

        private List<GescoStructure> _list = new List<GescoStructure>();
        private bool _getInactivos = false;

        private void FrmCRM02GescoSelect_Load(object sender, EventArgs e)
        {
            this.rbTodo.CheckedChanged -= new System.EventHandler(this.rbTodo_CheckedChanged);

            Cursor.Current = Cursors.WaitCursor;
            ckIncluirInactivos.Checked = false;
            ckIncluirBloqueados.Checked = false;
            _list = new GescoListManager().PopulateGescoList(false);
            ltexto1.Visible = false;
            rbDeuda.Checked = false;
            rbFavor.Checked = false;
            rbTodo.Checked = false;
            ctlDeuda.SetValue = 100;
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            Cursor.Current = Cursors.Default;
            AplicaFiltros();
        }

        private void AplicaFiltros()
        {
            //aplica filtros sobre _list
            var data = new List<GescoStructure>(_list);
            if (rbTodo.Checked == false && rbDeuda.Checked == false && rbFavor.Checked == false)
            {
                //aplica segun filtro de $
                data = data.Where(c => c.SaldoTotal > ctlDeuda.GetValueDecimal).OrderByDescending(c => c.SaldoTotal)
                    .ToList();
            }
            else
            {
                if (rbTodo.Checked)
                {
                    data = _list;
                }
                else
                {
                    if (rbFavor.Checked)
                    {
                        data = data.Where(c => c.SaldoTotal < 0).OrderBy(c => c.SaldoTotal).ToList();
                    }
                    else
                    {
                        data = data.Where(c => c.SaldoTotal > 0).OrderByDescending(c => c.SaldoTotal).ToList();
                    }
                }
            }

            if (ckIncluirInactivos.Checked == false)
            {
                data = data.Where(c => c.ClienteActivo == true).ToList();
            }

            if (ckIncluirBloqueados.Checked == false)
            {
                data = data.Where(c => c.ClienteBloqueado == false).ToList();
            }
            dgvListadoGesco.DataSource = new MySortableBindingList<GescoStructure>(data);
            txtCantidadClientesVisual.Text = data.Count.ToString();
            txtSaldoTotalVisual.Text = data.Sum(c => c.SaldoTotal).ToString("C2");
        }

        //private void rbCallRequest_CheckedChanged(object sender, EventArgs e)
        //{
        //    var rb = (RadioButton) sender;
        //    switch (rb.Name)
        //    {
        //        case "rbCallRequest":
        //            gescoStructureBindingSource.DataSource= _list.Where(c => c.CallRequest);
        //            break;
        //        case "rbConciliacionRequest":
        //            gescoStructureBindingSource.DataSource = _list.Where(c => c.ConciliarCtaRequest);
        //            break;
        //        case "rbDocumentosImpagos":
        //            gescoStructureBindingSource.DataSource = _list.OrderByDescending(c => c.DocumentosImpagos);
        //            break;
        //        case "rbLimiteExcedido":
        //            gescoStructureBindingSource.DataSource = _list.Where(c =>c.LimiteCredito !=null && ( c.LimiteCredito < c.SaldoTotal))
        //                .OrderByDescending(c => c.LimiteCredito.Value);
        //            break;
        //        case "rbMayorDeuda":
        //            gescoStructureBindingSource.DataSource = _list.OrderByDescending(c => c.SaldoTotal);
        //            break;
        //        case "rbProximaLlamada":
        //            gescoStructureBindingSource.DataSource = _list.Where(c => c.ProximaLlamada != null).OrderByDescending(c => c.ProximaLlamada.Value);
        //            break;
        //    }
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListadoGesco_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idCliente = Convert.ToInt32(datagridview[idClienteDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "VER":
                    var f0 = new FrmCRM03GescoMain(2, idCliente);
                    f0.Show();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            var rbx = (RadioButton)sender;
            if (rbx.Checked == false)
                return;
            ltexto1.Visible = true;
            ctlDeuda.SetValue = 0;
            AplicaFiltros();
        }

        private void ctlDeuda_Validated(object sender, EventArgs e)
        {
            this.rbTodo.CheckedChanged -= new System.EventHandler(this.rbTodo_CheckedChanged);
            ltexto1.Visible = false;
            rbTodo.Checked = false;
            rbDeuda.Checked = false;
            rbFavor.Checked = false;
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            AplicaFiltros();
        }

        private void ckIncluirBloqueados_CheckedChanged(object sender, EventArgs e)
        {
            if (_getInactivos == false && ckIncluirInactivos.Checked)
            {
                _getInactivos = true;
                Cursor.Current = Cursors.WaitCursor;
                _list = new GescoListManager().PopulateGescoList(false);
                Cursor.Current = Cursors.Default;
            }
            AplicaFiltros();
        }
    }
}
