using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.TOOLS;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCO37DetalleComprasDirectos : Form
    {
        private readonly string _periodo;
        private readonly string _lx;

        public FrmCO37DetalleComprasDirectos(string periodo, string lx)
        {
            _periodo = periodo;
            _lx = lx;
            InitializeComponent();
        }


        private void FrmCO37DetalleComprasDirectos_Load(object sender, EventArgs e)
        {
            dtpFechaInicial.Value = new PeriodoConversion().GetFechaPrimerDiaPeriodo(_periodo);
            dtpFechaFinal.Value = new PeriodoConversion().GetFechaUltimoDiaPeriodo(_periodo);
            switch (_lx)
            {
                case "L0":
                    ckL1.Checked = false;
                    ckL2.Checked = false;
                    break;
                case "L3":
                    ckL1.Checked = true;
                    ckL2.Checked = true;
                    break;
                case "L1":
                    ckL1.Checked = true;
                    ckL2.Checked = false;
                    break;
                default:
                    ckL2.Checked = true;
                    ckL1.Checked = false;
                    break;
            }
            dgvListadoDirectos.AutoGenerateColumns = false;
            var l1 = new CierreDetalleDirectos().GetListadoDirectos(_periodo, _lx).OrderBy(c => c.FechaConta).ToList();
            dgvListadoDirectos.DataSource = l1;
            //
            txtTotalInventario.Text = l1.Sum(c => c.PrecioTotal).ToString("C2");
            txtTotalKg.Text = l1.Sum(c => c.Cantidad).ToString("N2");
        }
    }
}
