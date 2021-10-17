using System;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.FI.MainDocumentData;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFi53SeleccionFacturaAnular : Form
    {
        public FrmFi53SeleccionFacturaAnular(int idCliente, string tipoLx)
        {
            _idCliente = idCliente;
            _tipoLx = tipoLx;
            InitializeComponent();
        }

        private readonly int _idCliente;
        private readonly string _tipoLx;
        //-------------------------------------------------------------------------------------
        public int? Id400Selected { private set; get; }
        public string TDoc { private set; get; }
        public string NumeroFacturaAnula { private set; get; }
        public bool ReingresarStock { private set; get; }
        public int idRemitoAsociado { private set; get; }
        //--------------------------------------------------------------------------------------

        private void FrmSeleccionAnulaFactura_Load(object sender, EventArgs e)
        {
            this.dgvListadoFacturas.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoFacturas_CellEnter);
            CompletaHeaderData();
            t0400FACTURAHBindingSource.DataSource = GetTabla400401.GetListaDocumentos(_idCliente, _tipoLx)
                .Where(c => c.TIPO_DOC != "NC").ToList();
            dgvListadoFacturas.ClearSelection();
            this.dgvListadoFacturas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoFacturas_CellEnter);

            idRemitoAsociado = 0;
            ReingresarStock = false;
            NumeroFacturaAnula = null;
            Id400Selected = null;
        }
        private void CompletaHeaderData()
        {
            var clidata = new CustomerManager().GetCustomerBillToData(_idCliente);
            txtRazonSocial.Text = clidata.cli_rsocial;
            txtFantasia.Text = clidata.cli_fantasia;
            txtId6.Text = _idCliente.ToString();
        }
        private void dgvListadoFacturas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Id400Selected = Convert.ToInt32(dgvListadoFacturas[__idFactura.Name, e.RowIndex].Value);
                if (dgvListadoFacturas[__numeroDocumento.Name, e.RowIndex].Value == null && dgvListadoFacturas[remitoDataGridViewTextBoxColumn.Name, e.RowIndex].Value == null)
                {
                    NumeroFacturaAnula = null;
                }
                else
                {
                    if (dgvListadoFacturas[__numeroDocumento.Name, e.RowIndex].Value == null)
                    {
                        NumeroFacturaAnula = dgvListadoFacturas[remitoDataGridViewTextBoxColumn.Name, e.RowIndex].Value.ToString();
                    }
                    else
                    {
                        NumeroFacturaAnula = dgvListadoFacturas[__numeroDocumento.Name, e.RowIndex].Value.ToString();
                    }

                    TDoc = dgvListadoFacturas[__Tdoc.Name, e.RowIndex].Value.ToString();
                    var idRemito = dgvListadoFacturas[__idRemito.Name, e.RowIndex].Value;
                    if (idRemito == null)
                    {
                        rbReingresoStock.Checked = false;
                        rbReingresoStock.AutoCheck = false;
                        idRemitoAsociado = 0;
                    }
                    else
                    {
                        rbReingresoStock.AutoCheck = true;
                        idRemitoAsociado = Convert.ToInt32(idRemito);
                    }
                }
                txtNumeroDocumento.Text = NumeroFacturaAnula;
                dgvFactuItems.DataSource = new CustomerInvoice("NCDX", Id400Selected.Value).GetItemData();
            }
            else
            {
                Id400Selected = null;
                NumeroFacturaAnula = null;
                TDoc = null;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
        private void btnSelectDocument_Click(object sender, EventArgs e)
        {
            if (rbReingresoStock.Checked == false && rbSinReingresoStock.Checked == false)
            {
                MessageBox.Show(@"Debe Seleccionar una opcion" + Environment.NewLine +
                                @"REINGRESAR Stock o" + Environment.NewLine +
                                @"NO REINGRESAR STOCK", @"Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ReingresarStock = rbReingresoStock.Checked;


            if (Id400Selected == null)
            {
                MessageBox.Show(@"No se ha seleccionado ningun documento - No se puede continuar",
                    @"Error en seleccion de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void rbReingresoStock_CheckedChanged(object sender, EventArgs e)
        {
            ReingresarStock = rbReingresoStock.Checked;
        }
    }
}
