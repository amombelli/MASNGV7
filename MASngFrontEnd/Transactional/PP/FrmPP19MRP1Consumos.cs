using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.CRM;
using Tecser.Business.Transactional.PP.MRP;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP19MRP1Consumos : Form
    {
        private readonly string _material;

        public FrmPP19MRP1Consumos(string material)
        {
            _material = material;
            InitializeComponent();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lineaArriba_Click(object sender, EventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LineaIzq_Click(object sender, EventArgs e)
        {

        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void estructuraPendientesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void FrmPP19MRP1Consumos_Load(object sender, EventArgs e)
        {
            txtMaterialPrimario.Text = _material;
            Calcula();
        }



        private void Calcula()
        {
            var r = new MRPConsumoMaterialStats(_material);
            r.CalculoDeConsumo();
            cConsumo30.SetValue = r.KgConsumidos;
            cFabricacion30.SetValue = r.KgFabricados;
            cDespacho30.SetValue = r.KgDespachados;
            cRetorno30.SetValue = r.KgRetornados;
            //
            r.CalculoDeConsumo(60);
            cconsumo60.SetValue = r.KgConsumidos / 2;
            cFabricacion60.SetValue = r.KgFabricados / 2;
            cDespacho60.SetValue = r.KgDespachados / 2;
            cRetorno60.SetValue = r.KgRetornados / 2;
            //
            r.CalculoDeConsumo(180);
            cconsumo180.SetValue = r.KgConsumidos / 6;
            cFabricacion180.SetValue = r.KgFabricados / 6;
            cDespacho180.SetValue = r.KgDespachados / 6;
            cRetorno180.SetValue = r.KgRetornados / 6;
            //

            //CRM - Despachos y Pedidos
            var crmDespachos = new PendientesDespacho();
            crmDespachos.GetPendienteDespachoMaterial(_material);
            //txtMrpPendienteEntrega.Text = crmDespachos.KgPendientesDespacho.ToString("N1");
            //txtMrpNumeroClientes.Text = crmDespachos.CantidadRegistros.ToString("N0");
            //txtUltimaFabricacion.Text = new PlanProduccionManager().GetUltimaFabricacion(txtMaterialSeleccionado.Text).ToString();
            ////
            //if (crmDespachos.KgPendientesDespacho != 0)
            //{
            //    txtMrpPendienteEntrega.ForeColor = f1;
            //    txtMrpPendienteEntrega.BackColor = b1;
            //}
            //else
            //{
            //    txtMrpPendienteEntrega.BackColor = br;
            //}

            //if (crmDespachos.CantidadRegistros != 0)
            //{
            //    txtMrpNumeroClientes.ForeColor = f1;
            //    txtMrpNumeroClientes.BackColor = b1;
            //}
            //else
            //{
            //    txtMrpNumeroClientes.BackColor = br;
            //}

            //var z = new MrpCrmStats(txtMaterialSeleccionado.Text);
            //z.EstadisticasDespachoMaterial(1, 90);
            //txtClientesLlevanMaterial.Text = z.CantidadClientes.ToString("N0");

            //if (z.CantidadClientes != 0)
            //{
            //    txtClientesLlevanMaterial.ForeColor = f1;
            //    txtClientesLlevanMaterial.BackColor = b1;
            //}
            //else
            //{
            //    txtClientesLlevanMaterial.BackColor = br;
            //}
        }
    }
}

