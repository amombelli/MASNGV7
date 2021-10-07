using System;
using System.Windows.Forms;
using MASngFE.Transactional.MM;
using MASngFE.Transactional.SD.SalesOrder;
using Tecser.Business.Transactional.CRM;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmCRM08PendientePorProducto : Form
    {
        private readonly string _material;
        private readonly int _idClienteR6;

        public FrmCRM08PendientePorProducto()
        {
            InitializeComponent();
        }
        public FrmCRM08PendientePorProducto(string material)
        {
            _material = material;
            _idClienteR6 = -1;
            InitializeComponent();
        }
        public FrmCRM08PendientePorProducto(string material, int idClienteR6)
        {
            _material = material;
            _idClienteR6 = idClienteR6;
            InitializeComponent();
        }
        private void FrmCRM08PendientePorProducto_Load(object sender, EventArgs e)
        {
            txtMaterialPrimario.Text = _material;
            if (_idClienteR6 > 0)
            {
                estructuraPendientesBindingSource.DataSource =
                    new PendientesDespacho().GetPendienteDespachoMaterial(_material, _idClienteR6);
            }
            else
            {
                estructuraPendientesBindingSource.DataSource =
                    new PendientesDespacho().GetPendienteDespachoMaterial(_material);
            }

            txtKgPendiente.Text = new PendientesDespacho().KgPendienteDesapchoPrimario(_material).ToString("N2");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void txtKgPendiente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                    int valor = Convert.ToInt32(dgv[e.ColumnIndex, e.RowIndex].Value);
                    if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("NP2", "NP2"))
                    {
                        MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios", @"Acceso no Aprobado",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //this.Close();
                        return;
                    }

                    using (var f = new FrmSD02SalesOrderMain(2, valor))
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
        }

        private void btnVerStock_Click(object sender, EventArgs e)
        {
            using (var f = new FrmMM31ListadoStockMaterial(_material))
            {
                f.ShowDialog();
            }

        }
    }
}
