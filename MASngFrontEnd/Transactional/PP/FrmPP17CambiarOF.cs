using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.PP;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP17CambiarOF : Form
    {
        public FrmPP17CambiarOF()
        {
            InitializeComponent();
        }

        public int OFSeleccionada { get; private set; }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void FrmPP17CambiarOF_Load(object sender, EventArgs e)
        {
            dgv.DataSource = PlanProduccionListManager.GetOFListPlaneadaFinalizada();
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dg = (DataGridView)sender;
            if (!(dg.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var boton = dg[e.ColumnIndex, e.RowIndex].Value.ToString();
            switch (boton)
            {
                case "Cerrar":
                    OFSeleccionada = Convert.ToInt32(dg[__numeroOF.Name, e.RowIndex].Value);
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                default:
                    MessageBox.Show(@"Boton no manejado aun");
                    break;
            }
        }
    }
}
