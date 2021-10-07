using System;
using System.Drawing;
using System.Windows.Forms;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmDetalle403 : Form
    {
        public FrmDetalle403(string periodo, string tipoLx)
        {
            _periodo = periodo;
            _tipoLx = tipoLx;
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------
        private readonly string _periodo;
        private readonly string _tipoLx;

        private void FrmDetalle403_Load(object sender, EventArgs e)
        {
            t403Bs.DataSource = new VendorConcil().GetListaFacturasIngresadasT403(_periodo, _tipoLx);
            t203Bs.DataSource = new VendorConcil().GetLista203NotIn403(_periodo, _tipoLx);

            var lista203 = new VendorConcil().GetListaFacturasIngresadasT203(_periodo, _tipoLx);
            foreach (DataGridViewRow row in dgvT403.Rows)
            {
                int idCtaCte = Convert.ToInt32(row.Cells[idCtaCte1dgv.Name].Value);
                var itemX = lista203.Find(c => c.IDCTACTE == idCtaCte);
                if (itemX == null)
                {
                    row.Cells[iDINTDataGridViewTextBoxColumn.Name].Style.BackColor = Color.Orange;
                }
                else
                {
                    if (itemX.IMPORTE_ARS != Convert.ToDecimal(row.Cells[nETODataGridViewTextBoxColumn.Name].Value))
                    {
                        row.Cells[iDINTDataGridViewTextBoxColumn.Name].Style.BackColor = Color.IndianRed;
                    }
                }

                //int quantity;
                //if (int.TryParse(row.Cells[columnIndex].Value.ToString(), out quantity))
                //{
                //    if (quantity < 20)
                //        row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.Red;
                //    if (quantity < 10)
                //        row.Cells[columnIndex].Style.BackColor = System.Drawing.Color.Orange;
                //}
                //  }
            }
        }

        private void dgvT403_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
