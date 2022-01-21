using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI.OrdenPago;

namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    public partial class FrmFI38DetalleImputacionPorDocumento : Form
    {
        public FrmFI38DetalleImputacionPorDocumento()
        {
            InitializeComponent();
        }

        private void ctlTextBox1_Validated(object sender, EventArgs e)
        {
            var xx = new OrdenPagoDetalleImputacion();
            dataGridView1.DataSource =
                xx.GetImputacionPorFactura(Convert.ToInt32(ctlTextBox1.GetValueDecimal)).ToList();
        }
    }
}
