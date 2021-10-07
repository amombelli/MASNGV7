using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmSeleccionChequeRechazadoCliente : Form
    {
        public FrmSeleccionChequeRechazadoCliente(int idCliente, string tipoNd)
        {
            _idCliente = idCliente;
            _tipoLx = tipoNd;
            InitializeComponent();

        }

#pragma warning disable CS0169 // The field 'FrmSeleccionChequeRechazadoCliente._listaCheques' is never used
        private List<T0156_CHEQUE_RECH> _listaCheques;
#pragma warning restore CS0169 // The field 'FrmSeleccionChequeRechazadoCliente._listaCheques' is never used
        private readonly int _idCliente;
        private readonly string _tipoLx;
        public int? IdChequeSeleccionado;



        private void FrmSeleccionChequeRechazado_Load(object sender, EventArgs e)
        {
            CompletaData();
            new ChequeRechazadoManager().FixIdCliente();
            string tipo = null;
            if (ckSoloTipoSeleccionado.Checked)
                tipo = _tipoLx;


            t0156CHEQUERECHBindingSource.DataSource =
                new ChequeRechazadoManager().ListaChequeRechazadosSinNd(_idCliente, tipo).ToList();
        }

        private void CompletaData()
        {
            var clidata = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtRazonSocial.Text = clidata.cli_rsocial;
            txtFantasia.Text = clidata.cli_fantasia;
            txtId6.Text = _idCliente.ToString();
        }


        private void btnSeleccion_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtNumeroCheque_TextChanged(object sender, EventArgs e)
        {
            //txtId.Text = null;
            //dgvListaCheques.DataSource = new ChequesManager().GetListaChequesFiltrada(_lx, ckVerDisponible.Checked,
            //    ckVerNoDisponible.Checked, txtNumber.Text, txtId.Text);
        }

        private void dgvListadoCheques_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdChequeSeleccionado =
                    Convert.ToInt32(dgvListadoCheques[dgvListadoCheques.Columns["iDCHEQUEDataGridViewTextBoxColumn"].Index, e.RowIndex].Value);
            }
            else
            {
                IdChequeSeleccionado = null;
            }
        }
    }
}
