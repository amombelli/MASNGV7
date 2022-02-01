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
    public partial class FRMCO35DetalleGastosIndirectos : Form
    {
        private readonly string _periodo;
        private readonly string _lx;

        public FRMCO35DetalleGastosIndirectos(string periodo, string lx)
        {
            _periodo = periodo;
            _lx = lx;
            InitializeComponent();
        }

        private void FRMCO35DetalleGastosIndirectos_Load(object sender, EventArgs e)
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
            //dgvListaVentas.AutoGenerateColumns = false;
            //var l1 = new VentasMensual().GetListadoVentasMensual(_periodo, _lx).OrderBy(c => c.Fecha).ToList();
            //dgvListaVentas.DataSource = l1;
            //txtImporteBruto.Text = l1.Sum(c => c.ImporteBruto).ToString("C2");
            //txtImporteIva.Text = l1.Sum(c => c.ImporteIva21).ToString("C2");
            //txtImporteNeto.Text = l1.Sum(c => c.ImporteNeto).ToString("C2");
            //txtKgVendidos.Text = l1.Sum(c => c.KgVendidos).ToString("N2");
        }
    }
}
