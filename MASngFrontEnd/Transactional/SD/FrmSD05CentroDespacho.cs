using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Transactional.CRM;
using MASngFE.Transactional.MM;
using MASngFE.Transactional.SD.SalesOrder;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.SD;
using TecserEF.Entity.DataStructure;
using TradeGrid;

namespace MASngFE.Transactional.SD
{
    public partial class FrmSD05CentroDespacho : Form
    {
        public FrmSD05CentroDespacho()
        {
            InitializeComponent();
        }

        private List<CDStructure> _listaCDCompleta;
        private List<CDStructure> _listaFiltrada;
        private string _filterModo;


        private void FrmSD05CentroDespacho_Load(object sender, EventArgs e)
        {
            this.rb3.CheckedChanged -= new System.EventHandler(this.rb3_CheckedChanged);
            this.contains.CheckedChanged -= new System.EventHandler(this.rbFinish_CheckedChanged);

            Cursor.Current = Cursors.WaitCursor;

            _listaCDCompleta = new CDListManager().GetListPendientesDespachoCliente(null);
            contains.Checked = true;
            rbAll.Checked = true;
            FiltraListaLevel1();

            Cursor.Current = Cursors.Default;

            this.rb3.CheckedChanged += new System.EventHandler(this.rb3_CheckedChanged);
            this.contains.CheckedChanged += new System.EventHandler(this.rbFinish_CheckedChanged);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FiltraListaLevel1()
        {
            _listaFiltrada = _listaCDCompleta;
            if (!string.IsNullOrEmpty(txtFilterMaterial.Text))
            {
                switch (_filterModo)
                {
                    case "contains":
                        _listaFiltrada = _listaFiltrada.Where(c => c.Primario.ToUpper().Contains(txtFilterMaterial.Text.ToUpper())).ToList();
                        break;
                    case "starts":
                        _listaFiltrada = _listaFiltrada.Where(c => c.Primario.ToUpper().StartsWith(txtFilterMaterial.Text.ToUpper())).ToList();
                        break;
                    case "ends":
                        _listaFiltrada = _listaFiltrada.Where(c => c.Primario.ToUpper().EndsWith(txtFilterMaterial.Text.ToUpper())).ToList();
                        break;
                    default:
                        _listaFiltrada = _listaFiltrada.Where(c => c.Primario.ToUpper().Contains(txtFilterMaterial.Text.ToUpper())).ToList();
                        break;
                }
            }

            if (!string.IsNullOrEmpty(txtFilterCliente.Text))
            {
                switch (_filterModo)
                {
                    case "contains":
                        _listaFiltrada = _listaFiltrada.Where(c => c.RazonSocialC7.ToUpper().Contains(txtFilterCliente.Text.ToUpper())).ToList();
                        break;
                    case "starts":
                        _listaFiltrada = _listaFiltrada.Where(c => c.RazonSocialC7.ToUpper().StartsWith(txtFilterCliente.Text.ToUpper())).ToList();
                        break;
                    case "ends":
                        _listaFiltrada = _listaFiltrada.Where(c => c.RazonSocialC7.ToUpper().EndsWith(txtFilterCliente.Text.ToUpper())).ToList();
                        break;
                    default:
                        _listaFiltrada = _listaFiltrada.Where(c => c.RazonSocialC7.ToUpper().Contains(txtFilterCliente.Text.ToUpper())).ToList();
                        break;
                }
            }
            dgvOrdenVenta.DataSource = new MySortableBindingList<CDStructure>(_listaFiltrada);
            AplicaIconosDgv();
        }

        private void AplicaIconosDgv()
        {
            decimal Kg = 0;
            foreach (DataGridViewRow row in dgvOrdenVenta.Rows)
            {
                var value1 = Convert.ToInt32(row.Cells[StatusStock.Name].Value);
                ((ImageAndTextCell)dgvOrdenVenta.Rows[row.Index].Cells[__StatusStockImg.Name]).Image = (Image)imList.Images[value1];
                ((ImageAndTextCell)dgvOrdenVenta.Rows[row.Index].Cells[__StatusStockImg.Name]).Value = value1;
                dgvOrdenVenta.Rows[row.Index].Cells[StatusStockImg.Name].Value = imList.Images[value1];
                //
                string statusPedido = row.Cells[StatusPedido.Name].Value.ToString();
                switch (statusPedido)
                {
                    case "Incompleto":
                        ((ImageAndTextCell)dgvOrdenVenta.Rows[row.Index].Cells[_StatusPedidoImg.Name]).Image = (Image)imList.Images[1];
                        break;
                    case "CompletoOK":
                        ((ImageAndTextCell)dgvOrdenVenta.Rows[row.Index].Cells[_StatusPedidoImg.Name]).Image = (Image)imList.Images[4];
                        break;
                    case "CompletoP":
                        ((ImageAndTextCell)dgvOrdenVenta.Rows[row.Index].Cells[_StatusPedidoImg.Name]).Image = (Image)imList.Images[2];
                        break;
                    case "Nulo":
                        ((ImageAndTextCell)dgvOrdenVenta.Rows[row.Index].Cells[_StatusPedidoImg.Name]).Image = (Image)imList.Images[0];
                        break;
                }
                Kg += (decimal)row.Cells[kgPendientesDataGridViewTextBoxColumn.Name].Value;
            }

            txtKgPendienteEntrega.Text = Kg.ToString("N2");
        }



        private void dgvOrdenVenta_Sorted(object sender, EventArgs e)
        {
            AplicaIconosDgv();
        }

        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            this.rb3.CheckedChanged -= new System.EventHandler(this.rb3_CheckedChanged);
            this.contains.CheckedChanged -= new System.EventHandler(this.rbFinish_CheckedChanged);

            txtFilterMaterial.Text = null;
            txtFilterCliente.Text = null;
            contains.Checked = true;
            rbAll.Checked = true;
            FiltraListaLevel1();

            this.rb3.CheckedChanged += new System.EventHandler(this.rb3_CheckedChanged);
            this.contains.CheckedChanged += new System.EventHandler(this.rbFinish_CheckedChanged);
        }


        private void rb3_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked == false) return;
            var listaFiltro2 = _listaFiltrada;

            switch (rb.Name)
            {
                case "rbAll":

                    break;
                case "rb1":
                    //con stock total o parcial
                    listaFiltro2 = listaFiltro2.Where(c => c.StatusStock != "0").ToList();
                    break;
                case "rb2":
                    //linea con stock completo
                    listaFiltro2 = listaFiltro2.Where(c => c.StatusStock == "2" || c.StatusStock == "3").ToList();
                    break;
                case "rb3":
                    //pedido completo
                    listaFiltro2 = listaFiltro2.Where(c => c.StatusPedido.Contains("Completo")).ToList();
                    break;
            }
            dgvOrdenVenta.DataSource = new MySortableBindingList<CDStructure>(listaFiltro2);
            AplicaIconosDgv();

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FiltraListaLevel1();
        }

        private void rbFinish_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            _filterModo = rb.Name;
            if (string.IsNullOrEmpty(txtFilterCliente.Text) && string.IsNullOrEmpty(txtFilterMaterial.Text))
                return;

            FiltraListaLevel1();
        }

        private void txtFilterMaterial_Validated(object sender, EventArgs e)
        {
            FiltraListaLevel1();
        }

        private void dgvOrdenVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrdenVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (e.RowIndex == -1)
                return;

            var cell = dgv.Columns[e.ColumnIndex].Name;
            var cellIndex = dgv.Columns[e.ColumnIndex].Index;
            switch (cell)
            {
                case "__ov":
                    //mostrar detalle de OV:
                    int valorOv = Convert.ToInt32(dgv[e.ColumnIndex, e.RowIndex].Value);
                    if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("NP2", "NP2"))
                    {
                        MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios", @"Acceso no Aprobado",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //this.Close();
                        return;
                    }

                    using (var f = new FrmSD02SalesOrderMain(2, valorOv))
                    {
                        f.ShowDialog();
                    }
                    break;
                case "__material":
                    string valor = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
                    using (var f = new FrmCRM08PendientePorProducto(valor))
                    {
                        f.ShowDialog();
                    }
                    break;
                case "__stockPlanta":
                    //mostrar stock de planta
                    string valor1 = dgv[__material.Index, e.RowIndex].Value.ToString();
                    using (var f = new FrmMM31ListadoStockMaterial(valor1))
                    {
                        f.ShowDialog();
                    }
                    break;
                default:
                    MessageBox.Show(
                        @"Esta celda no tiene una accion definida al hacer dobleclick. Si requiere de alguna funcionalidad no dude en solicitarlo",
                        @"Accion No Definida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }


            //var numeroCeldaStatus = dgvPF.Columns["StatusColumn"].Index;

            //if (e.RowIndex >= 0)
            //{
            //    var statusOrdenFabricacion = PlanProduccionStatusManager.MapStatusOfFromText2(dgvPF[numeroCeldaStatus, e.RowIndex].Value.ToString());
            //    int idPlan = Convert.ToInt32(dgvPF[0, e.RowIndex].Value);

            //    switch (cell.ToUpper())
            //    {
            //        case "MATERIALDATAGRIDVIEWTEXTBOXCOLUMN":
            //            var stk = new StockAvilability();
            //            var material = dgvPF[columnName: "mATERIALDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
            //            labelSeleccion.Text = material.ToString();
            //            // Set cursor as hourglass
            //            Cursor.Current = Cursors.WaitCursor;
            //            double stockTotal = stk.TotalStockInPlant(material);
            //            double stockDisponible = stk.AvailableStockForDespacho(material);
            //            decimal pendienteEntrega = new PendientesDespacho().KgPendienteDesapchoPrimario(material);
            //            if (stockTotal > 0)
            //            {
            //                txtStockTotal.ForeColor = Color.Crimson;
            //                txtStockTotal.BackColor = Color.Pink;
            //            }
            //            else
            //            {
            //                txtStockTotal.ForeColor = Color.Black;
            //                txtStockTotal.BackColor = Color.LightGray;
            //            }

            //            if (stockDisponible > 0)
            //            {
            //                txtStockDisponible.ForeColor = Color.Crimson;
            //                txtStockDisponible.BackColor = Color.Pink;
            //            }
            //            else
            //            {
            //                txtStockDisponible.ForeColor = Color.Black;
            //                txtStockDisponible.BackColor = Color.LightGray;
            //            }

            //            if (pendienteEntrega > 0)
            //            {
            //                txtTPendiente.ForeColor = Color.Crimson;
            //                txtTPendiente.BackColor = Color.Pink;
            //            }
            //            else
            //            {
            //                txtTPendiente.ForeColor = Color.Black;
            //                txtTPendiente.BackColor = Color.LightGray;
            //            }
            //            txtStockTotal.Text = stockTotal.ToString("N2");
            //            txtStockDisponible.Text = stockDisponible.ToString("N2");
            //            txtStockPendienteEntrega.Text = pendienteEntrega.ToString("N2");
            //            Cursor.Current = Cursors.Default;
            //            break;

            //        case "STATUSCOLUMN":
            //            AccionBoton(Convert.ToInt32(dgvPF[0, e.RowIndex].Value), statusOrdenFabricacion);
            //            break;
            //        case "KGFABRICARDATAGRIDVIEWTEXTBOXCOLUMN":
            //            if (statusOrdenFabricacion == PlanProduccionStatusManager.StatusOf.Pendiente ||
            //                statusOrdenFabricacion == PlanProduccionStatusManager.StatusOf.StandBy)
            //            {
            //                if (TsSecurityMng.CheckToEnableButton("PPCAMBIAKG"))
            //                {
            //                    using (var form1 = new FrmPP18UpdateKgFabricar(idPlan))
            //                    {
            //                        var resx = form1.ShowDialog();
            //                        if (resx == DialogResult.OK)
            //                        {
            //                            AplicaFiltros();
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show(
            //                        @"El Usuario no cuenta con los permisos suficientes para modificar los KG a Fabricar",
            //                        @"Permisos Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show(
            //                    @"Para utilizar esta funcion la orden de fabricacion debe estar en estado Pendiente o StandBy",
            //                    @"No Disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            break;
            //        default:
            //            MessageBox.Show(
            //                @"Esta Celda no realiza ninguna funcion al hacer doble click. Para planear haga doble click en STATUS",
            //                @"Boton no programado aun", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            break;
            //    }
            // }
        }
    }
}
