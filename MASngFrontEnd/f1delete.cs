using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSControls;

namespace MASngFE
{
    public partial class f1delete : Form
    {
        public f1delete()
        {
            InitializeComponent();
        }

        private void f1delete_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ctlAddress1.CargaControl("AR","Buenos Aires","","Lomas del Mirador ");
            ctlIconos1.Set = CIconos.Estrella;
            MessageBox.Show(ctlPeriodo1.FechaFinal.ToLongDateString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ctlAddress1.CargaControl("AR", "Buenos Aires", "", "Lomas del Mirador");
        }
    }
}
