using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.SuperMD;
using Tecser.Business.Transactional.MM;
using TecserEF.Entity;

namespace MASngFE.Transactional.MM
{
    public partial class FrmAjusteStockSloc : Form
    {
        public FrmAjusteStockSloc()
        {
            InitializeComponent();
            btnAjustar.Enabled = false;
        }

        //------------------------------------------------------------------------------------
        private decimal KgAjustar = 0;


        //------------------------------------------------------------------------------------





        private void btnAjustar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComentarioAjuste.Text))
            {
                MessageBox.Show(@"Debe completar el motivo/descripcion del Ajuste", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var x = new TecserData(GlobalApp.CnnApp).T0030_STOCK.Where(c => c.SLOC.ToUpper().Equals(txtSloc.Text.ToUpper())).ToList();
            if (x.Count == 0)
            {
                MessageBox.Show(@"Se aborta la operacion porque no existen CostItems", @"Error Inesperado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resp = MessageBox.Show($"Confirma la baja de {x.Count} CostItems?", @"Baja de CostItems del Inventario",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;



            foreach (var item in x)
            {
                var z = new MmLog().LogMovimientoT40(item.Material, dtpFechaAjuste.Value, 202, "AIM",
                    txtNumeroDocumento.Text, item.Stock * -1, "ASM", item.SLOC, item.Estado, "E", "LX", item.Batch,
                    comentarioMovimiento: txtComentarioAjuste.Text);
                new StockManager().DeleteStockLine(item.IDStock);
            }
        }

        private void txtSloc_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox texto = (TextBox)sender;
            var existe = new Ubicaciones().IsSlocAvailable(texto.Text);
            if (existe)
            {
                txtSloc.BackColor = Color.GreenYellow;
                btnAjustar.Enabled = true;
                KgAjustar = new StockAvilability().TotalStockInSloc(txtSloc.Text.ToUpper());
                txtKgAjustar.Text = KgAjustar.ToString("N2");
            }
            else
            {
                txtSloc.BackColor = Color.OrangeRed;
                btnAjustar.Enabled = false;
                KgAjustar = 0;
                txtKgAjustar.Text = 0.ToString("N2");
            }
        }

        private void FrmAjusteStockSloc_Load(object sender, EventArgs e)
        {

        }

        private void txtComentarioAjuste_Leave(object sender, EventArgs e)
        {

        }

        private void txtNumeroDocumento_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroDocumento.Text))
                e.Cancel = true;

            var y =
                new TecserData(GlobalApp.CnnApp).T0040_MAT_MOVIMIENTOS.Where(
                    c => c.DOCUMENTO == txtNumeroDocumento.Text && c.TIPO_DOCUMENTO == "AIM").ToList();
            if (y.Count > 0)
            {
                txtNumeroDocumento.BackColor = Color.Orange;
                MessageBox.Show(@"El Numero de Documento ya Existe", @"Error en numero de documento",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                txtNumeroDocumento.BackColor = Color.GreenYellow;
            }
        }
    }
}

