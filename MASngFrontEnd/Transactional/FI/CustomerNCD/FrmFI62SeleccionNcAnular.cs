using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI62SeleccionNcAnular : Form
    {
        private readonly int _idCliente;
        private readonly string _tipoLx;

        public FrmFI62SeleccionNcAnular(int idCliente, string tipoLx)
        {
            _idCliente = idCliente;
            _tipoLx = tipoLx;
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------
        public int? Id400Selected { private set; get; }
        public string TDOC { private set; get; }
        //--------------------------------------------------------------------------------------
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void btnSelectDocument_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show(@"Confirma la seleccion de esta Nota de Credito para Anular?",
                @"Confirmacion de Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                return;

            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }



        private void FrmFI62SeleccionNcAnular_Load(object sender, EventArgs e)
        {
            this.dgvListadoFacturas.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoNc_CellEnter);
            CompletaHeaderData();
            t0400FACTURAHBindingSource.DataSource = GetTabla400401.GetListaDocumentos(_idCliente, _tipoLx).Where(c => c.TIPO_DOC == "NC").ToList();
              
            dgvListadoFacturas.ClearSelection();
            this.dgvListadoFacturas.CellEnter +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoNc_CellEnter);
            Id400Selected = null;
        }
        
        private void CompletaHeaderData()
        {
            var clidata = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtRazonSocial.Text = clidata.cli_rsocial;
            txtFantasia.Text = clidata.cli_fantasia;
            txtId6.Text = _idCliente.ToString();
        }

        private void dgvListadoNc_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Id400Selected = Convert.ToInt32(dgvListadoFacturas[_idFactura_.Name,e.RowIndex].Value);
                txtNumeroDocumento.Text = dgvListadoFacturas[__numeroDocumento.Name, e.RowIndex].Value.ToString();
                TDOC = dgvListadoFacturas[__tipoDoc.Name, e.RowIndex].Value.ToString();
            }
            else
            {
                Id400Selected = null;
                TDOC = null;
            }
        }
    }
}
