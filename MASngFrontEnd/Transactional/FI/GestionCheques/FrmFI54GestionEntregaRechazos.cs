using System;
using System.Windows.Forms;
using MASngFE._0TSUserControls;
using Tecser.Business.Transactional.FI;

namespace MASngFE.Transactional.FI.GestionCheques
{
    public partial class FrmFI54GestionEntregaRechazos : Form
    {
        public FrmFI54GestionEntregaRechazos()
        {
            InitializeComponent();
        }

        private int? _idClienteSelect;

        private void FrmFI54GestionEntregaRechazos_Load(object sender, EventArgs e)
        {
            ckNoEntregados.Value = true;
        }

        private void ConfigInitData()
        {
            //bsClientes.DataSource = new CustomerManager().GetCompleteListofBillTo();
            bsChequesRech.DataSource = new ChequesManager().GetListaChequesRechazados(ckNoEntregados.Value);
        }

        private void tsUcCustomerSearch11_ClienteModificado(object source, TsCustomerSearchEventArgs args)
        {
            MessageBox.Show($@"Se modificado el cliente - El cliente es: {args.RazonSocial}");
        }

        private void dgvChequesRech_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var datagridview = (DataGridView)sender;
            if (!(datagridview.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var cellValue = datagridview[e.ColumnIndex, e.RowIndex].Value.ToString();
            var idCheque = Convert.ToInt32(datagridview[idchequeDataGridViewTextBoxColumn.Name, e.RowIndex].Value);
            switch (cellValue)
            {
                case "Detalle":
                    using (var f0 = new FrmFI55GestionChequeDetalle(idCheque))
                    {
                        DialogResult dr = f0.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            bsChequesRech.DataSource = new ChequesManager().GetListaChequesRechazados(ckNoEntregados.Value);
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



        private void ckNoEntregados_CheckedChanged(object sender, EventArgs e)
        {
            bsChequesRech.DataSource = new ChequesManager().GetListaChequesRechazados(ckNoEntregados.Value);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
