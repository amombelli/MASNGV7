using System;
using System.Windows.Forms;
using MASngFE._UserControls;
using MASngFE.Transactional.FI.CustomerNCD;

namespace MASngFE.Forms
{
    public partial class FrmTestUserControl : Form
    {
        public FrmTestUserControl()
        {
            InitializeComponent();
        }

        // UCheckbox1.ButtonClick += new FrmTestUserControl(UserControl_ButtonClick);

        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event 
            MessageBox.Show(@"Llegue arriba");
            var data = e.ToString();
            var y = (UCheckbox1)sender;
            var z = y.Text;
            //if (Settings.Default.CheckBox)
            //{
            //    MessageBox.Show(@"Chequeado!");

            //}
            //else
            //{
            //    MessageBox.Show(@"No Chequeado");
            //}

        }







        private void frmTestUserControl_Load(object sender, EventArgs e)
        {
            uCustomerSearch1.InicializaUc();
            dgvClientes.DataSource = uCustomerSearch1.T0006DgvBs;
            textBox1.Text = Properties.Settings.Default.AppVersion;
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var miDgv = (DataGridView)sender;
            if (!(miDgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var idCliente = Convert.ToInt32(miDgv[_idCliente.Name, e.RowIndex].Value);
            var cellValue = miDgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            switch (cellValue)
            {
                case "GO":
                    using (var f0 = new FrmFI40AjusteSaldoCliente(idCliente))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            //string custName = f0.CustomerName;
                            //SaveToFile(custName);
                        }
                    }

                    break;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }

        private void uck01_CheckBoxClick(object sender, EventArgs e)
        {
            var data = (UCheckbox1)sender;

            //if (
            //{
            //    MessageBox.Show(@"Chequeado!");
            //}
            //else
            //{
            //    MessageBox.Show(@"No Chequeado");
            //}
        }



        private void uck11_CheckBoxClick(object sender, EventArgs e)
        {
            var x = uck11.Value;
        }


        private void UserCTL_ButtonClick(object sender, EventArgs e)
        {
            var x = uck11.Value;
        }

        //UCheckbox1.CheckBoxClick;
        //  UserControl1.ButtonClick += new EventHandler(UserControl_ButtonClick);

    }
}
