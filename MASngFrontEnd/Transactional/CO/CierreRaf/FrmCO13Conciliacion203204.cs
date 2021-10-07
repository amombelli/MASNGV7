using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.Transactional.Cierre;

namespace MASngFE.Transactional.CO.CierreRaf
{
    public partial class FrmCO13Conciliacion203204 : Form
    {
        public FrmCO13Conciliacion203204()
        {
            InitializeComponent();
        }

        private ConciliacionSaldoVendor203Vs204 _x = new ConciliacionSaldoVendor203Vs204();
        private List<StructureConcil203> _lista = new List<StructureConcil203>();
        private void FrmCO13Conciliacion203204_Load(object sender, EventArgs e)
        {
            _x = new ConciliacionSaldoVendor203Vs204();
            rb203.Checked = true;
            _lista = _x.CheckDiferenciasOrigen203();

            structureConcil203BindingSource.DataSource = _lista.OrderByDescending(c => c.Saldo203);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb203_CheckedChanged(object sender, EventArgs e)
        {
            if (rb203.Checked)
            {
                structureConcil203BindingSource.DataSource = _x.CheckDiferenciasOrigen203();
            }
            else
            {
                structureConcil203BindingSource.DataSource = _x.CheckDiferenciasOrigen204();
            }
        }

        private void ckSoloDiferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloDiferencia.Checked)
            {
                structureConcil203BindingSource.DataSource = _lista.Where(c => c.Diferencia != 0).OrderByDescending(c => c.Saldo203).ToList();
            }
            else
            {
                structureConcil203BindingSource.DataSource = _lista.OrderByDescending(c => c.Saldo203).ToList();
            }
        }
    }
}
