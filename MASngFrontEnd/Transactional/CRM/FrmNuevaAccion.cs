using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;

namespace MASngFE.Transactional.CRM
{
    public partial class FrmNuevaAccion : Form
    {
        public FrmNuevaAccion(int idCliente)
        {
            InitializeComponent();
            _idCliente = idCliente;
        }

        private readonly int _idCliente;

        private void FrmNuevaAccion_Load(object sender, EventArgs e)
        {
            txtClienteRazonSocial.Text = new CustomerManager().GetCustomerBillToData(_idCliente).cli_rsocial;

        }

        private void grpSentidoContacto_Enter(object sender, EventArgs e)
        {

        }

        private void grpSentidoContacto_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton rb = sender as RadioButton;
            if (rb == null) return;
            if (rb.Checked)
            {
                // Only one radio button will be checked
                Console.WriteLine("Changed: " + rb.Name);
                MessageBox.Show(rb.Text);
                switch (rb.Name)
                {
                    case "rbACliente":
                        rb1.Text = @"Gestion Cobranza";
                        rb2.Text = @"ResumenConciliacionGeneral Saldo";
                        rb3.Text = @"Coordinar Retiro";
                        rb4.Text = @"Coordinar Entrega";
                        rb5.Text = @"Otro";
                        rb6.Text = @"";
                        rb7.Text = @"";

                        break;
                    case "rbDeCliente":
                        rb1.Text = @"Nuevo Pedido";
                        rb2.Text = @"Reclamo Calidad";
                        rb3.Text = @"Reclamo Entrega";
                        rb4.Text = @"Consulta Precio / Stock";
                        rb5.Text = @"Consulta x Entrega";
                        rb6.Text = @"ResumenConciliacionGeneral Saldo";
                        rb7.Text = @"Otro";

                        break;
                }
                var ck = grpMotivoContacto.Controls.OfType<RadioButton>();
                foreach (var item in ck)
                {
                    if (string.IsNullOrEmpty(item.Text) == true)
                    {
                        item.Visible = false;
                    }
                    else
                    {
                        item.Visible = true;
                    }
                }


            }




        }
    }
}
