using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MASngFE.Forms.CustomerSearchBase
{
    public partial class FrmCustomerSearchTest : Form
    {
        public FrmCustomerSearchTest()
        {
            InitializeComponent();
        }

        private void tsUcCustomer31_ClienteModificado(object source, _0TSUserControls.CustomerSearchUcV3Args args)
        {
            if (args.ClienteId > 0)
            {
                MessageBox.Show($@"Se selecciono el cliente {args.RazonSocial}");
            }
        }

        private void FrmCustomerSearchTest_Load(object sender, EventArgs e)
        {
            tsUcCustomer31.ClienteId = 364;
        }
    }
}
