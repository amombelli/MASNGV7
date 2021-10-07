using System;
using System.Windows.Forms;
using MASngFE.MasterData.Vendor;
using MASngFE.Transactional.MM.Requisicin;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.MM.Orden_de_Compra
{
    public partial class FrmMM20BuscadorOC : Form
    {
        public FrmMM20BuscadorOC(int modo = 1)
        {
            _modo = modo;
            InitializeComponent();
        }

        //---------------------------------------------------------------------------
        private readonly int _modo;
        //---------------------------------------------------------------------------

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMM20OrdenCompraMain_Load(object sender, EventArgs e)
        {
            uVendorSearch1.InicializaUc();
            T0005DgvBs.DataSource = uVendorSearch1.T0005DgvBs;

            switch (_modo)
            {
                case 1:
                    break;
                case 2:
                    dgvVendorListNewOC.Enabled = false;
                    break;
                case 3:
                    dgvVendorListNewOC.Enabled = false;
                    break;
                default:
                    return;
            }


        }
        private void dgvVendorList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var activo = Convert.ToBoolean(datagridview[aCTIVODataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            var razonSocial = datagridview[provrsocialDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
            var idVendor = Convert.ToInt32(datagridview[idprovDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "Nueva":
                    if (!activo)
                    {
                        MessageBox.Show(
                            @"No se puede crear una OC para un proveedor que no se encuentra Activo en el Sistema",
                            @"Proveedor Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var resp = MessageBox.Show($"Desea Crear una nueva Orden de Compra para {razonSocial} ?",
                        @"Generacion de Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resp == DialogResult.No)
                        return;

                    var f = new FrmMM21DatosOC(idVendor);
                    f.Show();
                    this.Close();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
        private void dgvVendorList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                return;
            }
            var idVendor = Convert.ToInt32(dgv[idprovDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            //T0060OCBs.DataSource = new OrdenCompraManager().GetListofOrdenCompraByVendor(idVendor);
            OCCompletoBs.DataSource = new OrdenCompraManager().GetListOCCompletaCompletoByVendor(idVendor);
        }
        private void btnVerUltimasOC_Click(object sender, EventArgs e)
        {
            //T0060OCBs.DataSource = new OrdenCompraManager().GerListOC();
            OCCompletoBs.DataSource = new OrdenCompraManager().GetListOCCompletaCompleto();
        }
        private void dgvOrdenCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var numeroOC = Convert.ToInt32(datagridview[iDORDENCOMPRADataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            var estadoOC = datagridview[sTATUSOCDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();

            switch (cellValue)
            {
                case "VER":
                    var fx = new FrmMM21DatosOC(numeroOC, 3);
                    fx.Show();
                    this.Close();
                    break;
                case "EDIT":
                    if (_modo == 3)
                    {
                        MessageBox.Show(@"La Edicion de OC no se encuentra disponible en la Transaccion OC3 Utilizada",
                            @"Funcionalidad NO Autorizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var fx1 = new FrmMM21DatosOC(numeroOC, 2);
                    fx1.Show();
                    this.Close();
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
        private void btnDetalleProveedor_Click(object sender, EventArgs e)
        {
            if (uVendorSearch1.VendorId == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Proveedor (Vendor) para poder visualizar sus datos de contacto",
                    @"Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            using (var f = new FrmMdv03VendorInfo(uVendorSearch1.VendorId.Value))
            {
                f.ShowDialog();
            }
        }

        private void btnInforRecord_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Funcionalidad no implementada AUN");
        }

        private void ordenCompraDgvCompleteoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnVerRC_Click(object sender, EventArgs e)
        {
            using (var f = new FrmMM56RcPendientePorProveedor())
            {
                f.ShowDialog();
            }
        }
    }
}



