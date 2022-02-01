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
    public partial class FrmCO34DetalleComprasMP : Form
    {
        private readonly string _periodo;
        private readonly string _lx;

        public FrmCO34DetalleComprasMP(string periodo, string lx)
        {
            _periodo = periodo;
            _lx = lx;
            InitializeComponent();
        }

        private void FrmCO34DetalleComprasMP_Load(object sender, EventArgs e)
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
            dgvListaCompras.AutoGenerateColumns = false;
            var l1 = new ComprasGastosMensual().GetListadoCompras(_periodo, _lx).OrderBy(c => c.Fecha).ToList();
            dgvListaCompras.DataSource = l1;
            //
            txtBruto.Text = l1.Sum(c => c.IBruto).ToString("C2");
            txtNeto.Text = l1.Sum(c => c.InetoFinal).ToString("C2");
            txtTotalIva.Text = l1.Sum(c => c.IivaTotal).ToString("C2");
            txtCantidad.Text = l1.Sum(c => c.TotalKg).ToString("C2");
            txtPercGanancias.Text = l1.Sum(c => c.IpercGs).ToString("C2");
            txtPercIVA.Text = l1.Sum(c => c.IpercIva).ToString("C2");

        }


    }
}
