using System;
using System.Drawing;
using System.Windows.Forms;
using MASngFE._UserControls;

namespace MASngFE.MasterData.Customer_Master
{
    public partial class FrmMdc01CustomerSearch : Form
    {
        public FrmMdc01CustomerSearch(int modo, string funcion)
        {
            _modo = modo;
            _funcion = funcion;
            InitializeComponent();
        }
        public int ClienteSeleccionado { get; private set; }
        private readonly int _modo;
        private readonly string _funcion;
        private void FrmMDC01CustomerSearch_Load(object sender, EventArgs e)
        {
            uCustomerSearch1.InicializaUc(true, true, Color.LightGreen);
            dgvClientes.DataSource = uCustomerSearch1.T0006DgvBs;
           

            //Configura nombre del boton
            switch (_modo)
            {
                case 1:
                    __Accion.Text = "";
                    __Accion.Visible = false;
                    break;
                case 2:
                    __Accion.Visible = true;
                    __Accion.Text = "EDIT";
                    break;
                case 3:
                    __Accion.Visible = true;
                    __Accion.Text = "VER";
                    break;
                case 4:
                    __Accion.Visible = true;
                    __Accion.Text = "SEL";
                    break;
                default:
                    break;
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var miDgv = (DataGridView)sender;
            if (!(miDgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            ClienteSeleccionado = Convert.ToInt32(miDgv[iDCLIENTEDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            var idCliente = ClienteSeleccionado;
            var cellValue = miDgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (cellValue!="SEL")
                cellValue = "GO";
            switch (cellValue)
            {
                case "SEL":
                {
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                case "GO":
                    using (var f0 = new FrmMdc02BillTo(_modo, idCliente, "MD"))
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
