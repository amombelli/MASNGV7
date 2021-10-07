using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.CtaCte;
using TSControls;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmFI72AjusteRedondeo : Form
    {
        private readonly CustomerAjustes _aj;
        private readonly int _idCliente;
        private readonly string _lx;
        public string MotivoAjuste { private set; get; }
        public FrmFI72AjusteRedondeo(CustomerAjustes aj, CustomerAjustes.MotivoAjustes xmotivo)
        {
            _aj = aj;
            var h = aj.GetHeader();
            _idCliente = h.Cliente;
            _lx = h.TIPOFACT;
            InitializeComponent();
            txtRazonSocial.Text = h.RAZONSOC;
            txtId6.Text = h.Cliente.ToString();
            txtMotivo.Text = xmotivo.ToString();
            txtLx.Text = _lx;
            txtTipoDocumento.Text = h.TIPO_DOC;
        }
        
        private void FrmFI72AjusteRedondeo_Load(object sender, EventArgs e)
        {
            cSaldoActual.SetValue = new CtaCteCustomer(_idCliente).GetResultadoCtaCte(_lx).SaldoResumen;
            cSaldoNuevo.SetValue = cSaldoActual.GetValueDecimal;
            cImporteAjuste.SetValue = 0;
            ctlIconos1.Set = CIconos.ExclamacionOrange;
        }

        private void btnRedondeo_Click(object sender, EventArgs e)
        {
            if (cImporteAjuste.GetValueDecimal == 0)
            {
                MessageBox.Show(@"El Importe de Ajuste no puede ser igual a cero", @"Error en Importe de Ajuste",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtMotivoAjuste.Text))
            {
                MessageBox.Show(@"Debe proveer una descripcion/motivo por el que se realiza el ajuste",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtTextoAuto400.Text))
            {
                MessageBox.Show(@"Debe proveer el Texto para T400- Documento",
                    @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MotivoAjuste = txtMotivoAjuste.Text;
            _aj.AddItems("ZAJCC", txtTextoAuto400.Text, cImporteAjuste.GetValueDecimal, "7.1.1", false,1);
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void cSaldoNuevo_Validated(object sender, EventArgs e)
        {
            decimal ajuste = cSaldoNuevo.GetValueDecimal - cSaldoActual.GetValueDecimal;
            cImporteAjuste.SetValue = ajuste;
            if (ajuste == 0)
            {
                ctlIconos1.Set = CIconos.ExclamacionOrange;
                btnRedondeo.Enabled = false;
            }
            else if (ajuste > 0)
            {
                ctlIconos1.Set = CIconos.CuadradoBordo;
                btnRedondeo.Enabled = true;
                txtTextoAuto400.Text = @"Ajuste CC Redondeo (A Favor Mombelli)";
                lxHelp.Text = @"Ajuste Positivo = Cargo a Cliente => Factura/ND";
            }
            else
            {
                ctlIconos1.Set = CIconos.TrianguloNaranja;
                btnRedondeo.Enabled = true;
                txtTextoAuto400.Text = @"Ajuste CC Redondeo (A Favor Cliente)";
                lxHelp.Text = @"Ajuste Negativo = Simil Cobranza => NC (Perdida Mombelli)";
            }
        }
    }
}
