using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.Cierre;
using Tecser.Business.Transactional.FI;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Transactional.Cierre
{
    public partial class FrmCO32ChequesCarteraCierre : Form
    {
        private  DateTime _fechaI;
        private  DateTime _fechaF;
        private  string _tipoLx;
        private List<TsCheques1> _listaCheques = new List<TsCheques1>();

        public FrmCO32ChequesCarteraCierre(DateTime fechaI, DateTime fechaF, string tipoLx)
        {
            _fechaI = fechaI;
            _fechaF = fechaF;
            _tipoLx = tipoLx;
            InitializeComponent();
        }

        private void FrmFI72ChequesEnCartera_Load(object sender, System.EventArgs e)
        {
            dtpFechaInicial.Value = _fechaI;
            dtpFechaFinal.Value = _fechaF;
            switch (_tipoLx)
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
            dgvListaCheques.AutoGenerateColumns = false;
            //dgvListaCheques.DataSource = new StockCheques().GetAvailableOnDate(_fechaF, _tipoLx).ToList();
            var ret = new ChequesManager().ListaChequesStockCierre(_fechaF, _tipoLx).ToList();
            dgvListaCheques.DataSource = ret.ToList();
            txtSaldoCarteraCierre.Text = ret.Sum(c => c.Importe).ToString("C2");
            txtRegistroCierre.Text = ret.Count.ToString();
        }
    }
}
