using System;
using System.Windows.Forms;
using MASngFE.Transactional.MM.Orden_de_Compra;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.MM.Requisicin
{
    public partial class FrmMM56RcPendientePorProveedor : Form
    {
        private readonly int? _idOC;
        private readonly int? _idProv;
        private readonly int _modo;
        private FrmMM21DatosOC frmOcHeader;

        public FrmMM56RcPendientePorProveedor()
        {
            //modo 2 => desde OC sin proveedor seleccionado
            InitializeComponent();
            _modo = 2;
            _idOC = null;
            _idProv = null;
        }

        public FrmMM56RcPendientePorProveedor(FrmMM21DatosOC form, int idOC, int idProv)
        {
            //modo 1 => desde OC con proveedor
            _idOC = idOC;
            _idProv = idProv;
            _modo = 1;
            frmOcHeader = form;
            InitializeComponent();
        }
        private void rbProveedorAsignado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodasPendientes.Checked)
            {
                rcBiningSource.DataSource = new RcManagement().GetRcPendienteOCAll();
            }
            else if (rbProveedorAsignado.Checked)
            {
                rcBiningSource.DataSource = new RcManagement().GetRcPendienteOCConProveedor(_idProv);
            }
            else
            {
                //solo sin proveedor asignado
                rcBiningSource.DataSource = new RcManagement().GetRcPendienteOCSinProveedor();
            }
        }

        private void FrmMM56RcPendientePorProveedor_Load(object sender, EventArgs e)
        {
            switch (_modo)
            {
                case 1:
                    panel1.Visible = true;
                    panTexto.Visible = false;
                    rbProveedorAsignado.Checked = true;
                    txtOc.Text = _idOC.ToString();
                    var prov = new VendorManager().GetSpecificVendor(_idProv.Value).prov_rsocial;
                    txtProveedor.Text = prov.ToString();
                    break;
                case 2:
                    panel1.Visible = false;
                    panTexto.Visible = true;
                    rbTodasPendientes.Checked = true;
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListadoRc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idRc = Convert.ToInt32(datagridview[__idRC.Name, e.RowIndex].Value);
            var dataRC = new RcManagement().GetRequisicion(idRc);
            switch (cellValue)
            {
                case "ADD":
                    if (_modo == 1)
                    {
                        //modo 1 => desde OC con proveedor - solo permite el mismo proveedor
                        //o sin proveedor
                        if (dataRC.ProveedorElegido == null || dataRC.ProveedorElegido == _idProv)
                        {
                            var fx = frmOcHeader.Items.Find(c => c.IdRC == idRc);
                            if (fx != null)
                            {
                                MessageBox.Show(@"Esta RC# ya se encuentra agregada en la Orden de Compra",
                                    @"Item Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            this.Close();
                            using (var fd = new FrmMM22DetalleItemOC(frmOcHeader, idRc))
                            {
                                fd.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show(
                                @"Esta RC no se puede agregar a la OC# porque esta asignada a otro proveedor",
                                @"Accion No Valida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        //modo 2 => desde OC sin proveedor seleccionado
                        //solo permite agregar RC que tengan un proveedor asignado
                        if (dataRC.ProveedorElegido == null)
                        {
                            MessageBox.Show(
                                @"Esta RC no se puede agregar porque no tiene un proveedor seleccionado" +
                                Environment.NewLine + @"Elija Primero un proveedor en la OC y luego agreue la RC",
                                @"Accion no Permitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            using (var f = new FrmMM21DatosOC(dataRC.ProveedorElegido.Value, idRc, dataRC.Material, dataRC.KgRequeridos))
                            {
                                f.ShowDialog();
                            }
                        }
                    }
                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
    }
}
