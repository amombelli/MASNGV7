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
using TSControls;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCo37ConciliaEgresos : Form
    {
        private readonly string _periodo;
        private readonly string _lx;
        private List<ConciliaEgresos2> _lista;

        public FrmCo37ConciliaEgresos(string periodo, string lx)
        {
            _periodo = periodo;
            _lx = lx;
            InitializeComponent();
        }

        private void FrmCo37ConciliaEgresos_Load(object sender, EventArgs e)
        {
            txtPeriodo.Text = _periodo;
            txtLx.Text = _lx;

            _lista = new VendorEgresosConcilia().Conciliacion2(_periodo, _lx);
            AddTotalInDgv();
            dgvConcilia.DataSource = _lista.OrderBy(c=>c.fecha).ToList();
            FormatoDgv();

            if (_lista.Where(c => c.StatusOk == false).ToList().Any())
            {
                txtStatusConciliacion.Text =  @"F!";
                cIconoStatus.Set = CIconos.ExclamacionRed;
            }
            else
            {
                txtStatusConciliacion.Text = @"OK";
                cIconoStatus.Set = CIconos.Tilde;
            }
        }
        private void AddTotalInDgv()
        {
            var lineaTotal = new ConciliaEgresos2()
            {
                Documento = @"------------",
                CtaCte = false,
                Lx = _lx,
                RazonSocial = @"### Totales ###",
                Register = false,
                StatusOk = false,
                importeAcredDiferido = _lista.Sum(c => c.importeAcredDiferido),
                importeReg = _lista.Sum(c => c.importeReg),
                importeCtaCte = _lista.Sum(c => c.importeCtaCte),
                importePendAcred = _lista.Sum(c => c.importePendAcred),
                fecha = new PeriodoConversion().GetFechaUltimoDiaPeriodo(_periodo).AddDays(1)
            };
            _lista.Add(lineaTotal);
        }
        private void FormatoDgv()
        {
            for (var i = 0; i < dgvConcilia.Rows.Count; i++)
            {
                if (dgvConcilia.Rows[i].Cells[RazonSocial.Name].Value.ToString().Equals("### Totales ###"))
                {
                    //Row de totales
                    var ColorFondo = Color.LightSkyBlue;
                    var ColorTxt = Color.Navy;
                    dgvConcilia.Rows[i].Cells[fechaDataGridViewTextBoxColumn.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[Documento.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[CtaCte.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[Lx.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[RazonSocial.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[Register.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[StatusOk.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[importeAcredDiferidoDataGridViewTextBoxColumn.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[importeRegDataGridViewTextBoxColumn.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[importeCtaCteDataGridViewTextBoxColumn.Name].Style.BackColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[importePendAcredDataGridViewTextBoxColumn.Name].Style.BackColor = ColorFondo;
                    //
                    dgvConcilia.Rows[i].Cells[fechaDataGridViewTextBoxColumn.Name].Style.ForeColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[Documento.Name].Style.ForeColor = ColorTxt;
                    dgvConcilia.Rows[i].Cells[CtaCte.Name].Style.ForeColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[Lx.Name].Style.ForeColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[RazonSocial.Name].Style.ForeColor = ColorTxt;
                    dgvConcilia.Rows[i].Cells[Register.Name].Style.ForeColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[StatusOk.Name].Style.ForeColor = ColorFondo;
                    dgvConcilia.Rows[i].Cells[importeAcredDiferidoDataGridViewTextBoxColumn.Name].Style.ForeColor = ColorTxt;
                    dgvConcilia.Rows[i].Cells[importeRegDataGridViewTextBoxColumn.Name].Style.ForeColor = ColorTxt;
                    dgvConcilia.Rows[i].Cells[importeCtaCteDataGridViewTextBoxColumn.Name].Style.ForeColor = ColorTxt;
                    dgvConcilia.Rows[i].Cells[importePendAcredDataGridViewTextBoxColumn.Name].Style.ForeColor = ColorTxt;
                }
            }
            dgvConcilia.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
