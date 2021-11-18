using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCo36ConciliaDiferenciasEgresos : Form
    {
        private readonly string _periodo;
        private readonly string _lx;

        public FrmCo36ConciliaDiferenciasEgresos(string periodo, string lx)
        {
            _periodo = periodo;
            _lx = lx;
            InitializeComponent();
        }

        private void FrmCo36ConciliaDiferenciasEgresos_Load(object sender, EventArgs e)
        {
            dgvListaConcilia1.DataSource = new VendorEgresosConcilia().ProcesaRegEnCc(_periodo, _lx).ToList();
        }
    }
}
