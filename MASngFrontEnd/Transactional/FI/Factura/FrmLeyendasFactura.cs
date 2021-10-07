using System;
using System.Windows.Forms;

namespace MASngFE.Transactional.FI.Factura
{
    public partial class FrmLeyendasFactura : Form
    {
        public FrmLeyendasFactura(int idFactura)
        {
            _idFactura = idFactura;
            InitializeComponent();
        }

        private readonly int _idFactura;
        public bool CkPreimpreso { get; private set; }
        public bool CkImprimirMora { get; private set; }
        public bool CkImprimirSaldoL2 { get; private set; }
        public string Observacion { get; private set; }


        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            CkPreimpreso = ckPreimpreso.Checked;
            CkImprimirMora = ckImprimirMensajeMora.Checked;
            CkImprimirSaldoL2 = ckSaldoTotalAdeudadoL2.Checked;
            Observacion = txtObservacionesAdicionalesImprimir.Text;
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }


        private void FrmLeyendasFactura_Load(object sender, EventArgs e)
        {

        }

        private void btnAbandonar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
