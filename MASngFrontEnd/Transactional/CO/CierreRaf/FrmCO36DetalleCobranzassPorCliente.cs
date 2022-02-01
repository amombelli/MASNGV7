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
    public partial class FrmCO36DetalleCobranzassPorCliente : Form
    {
        private readonly string _periodo;
        private readonly string _lx;

        public FrmCO36DetalleCobranzassPorCliente(string periodo, string lx)
        {
            _periodo = periodo;
            _lx = lx;
            InitializeComponent();
        }

        private void FrmCO36DetalleCobranzassPorCliente_Load(object sender, EventArgs e)
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
            dgvListaCobranzas.AutoGenerateColumns = false;
            var l1 = new CierreCobranzas().GetCobranzasxCliente(_periodo, _lx).OrderByDescending(c => c.Cobrado).ToList();
            dgvListaCobranzas.DataSource = l1;
            //
            txtTotalCobrado.Text = l1.Sum(c => c.Cobrado).ToString("C2");
            txtCantidadRegistros.Text = l1.Sum(c => c.CantidadRegistros).ToString("N0");
        }
    }
}
