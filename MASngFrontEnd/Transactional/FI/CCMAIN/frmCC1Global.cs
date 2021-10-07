using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI.CtaCte;

namespace MASngFE.Transactional.FI.CCMAIN
{
    public partial class frmCC1Global : Form
    {
        public frmCC1Global()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmCC1Global(CtaCteCustomerGlobal.Retorno data)
        {
            InitializeComponent();
            _data = data;
        }

        private CtaCteCustomerGlobal.Retorno _data;

        private void frmCC1Global_Load(object sender, EventArgs e)
        {
            lctacteError.Visible = false;
            lctacteOK.Visible = false;
            MapeaValoresTotales();
            //dgvDiferenciasCtaCte.DataSource = new Cc1Manager().GetAnalisisDiferenciaSaldo();

        }

        private void MapeaValoresTotales()
        {
            txtSaldoL1_201.Text = _data.SaldoGlobalL1_201.ToString("C2");
            txtSaldoL2_201.Text = _data.SaldoGlobalL2_201.ToString("C2");
            txtSaldoL1_202.Text = _data.SaldoGlobalL1_202.ToString("C2");
            txtSaldoL2_202.Text = _data.SaldoGlobalL2_202.ToString("C2");
            txtSaldoL1_208.Text = _data.SinImputarGlobalL1.ToString("C2");
            txtSaldoL2_208.Text = _data.SinImputarGlobalL2.ToString("C2");
            txtSaldoL1_207.Text = _data.ImporteL1_207.ToString("C2");
            txtSaldoL2_207.Text = _data.ImporteL2_207.ToString("C2");

            txtL1Dif201202.Text = (_data.SaldoGlobalL1_201 - _data.SaldoGlobalL1_202).ToString("C2");
            txtL2Dif201202.Text = (_data.SaldoGlobalL2_201 - _data.SaldoGlobalL2_202).ToString("C2");
            txtL1Dif201207.Text = (_data.SaldoGlobalL1_202 - _data.ImporteL1_207 + _data.SinImputarGlobalL1).ToString("C2");
            txtL2Dif201207.Text = (_data.SaldoGlobalL2_202 - _data.ImporteL2_207 + _data.SinImputarGlobalL2).ToString("C2");

            txtSaldo201Total.Text = (_data.SaldoGlobalL1_201 + _data.SaldoGlobalL2_201).ToString("C2");
            txtSaldo202Total.Text = (_data.SaldoGlobalL1_202 + _data.SaldoGlobalL2_202).ToString("C2");
            txtTotalSinImputar.Text = (_data.SinImputarGlobalL1 + _data.SinImputarGlobalL2).ToString("C2");
            txtSaldo207Total.Text = (_data.ImporteL1_207 + _data.ImporteL2_207).ToString("C2");
        }

        private void CheckCtaCteOK()
        {

            //            If Me.TDIF201L1 <> 0 Or Me.TDIF201L2 <> 0 Or Me.TDIF207L1 <> 0 Or Me.TDIF207L2 <> 0 Then
            //    MsgBox "ATENCION! EXISTE ALGUN ERROR EN LAS CUENTAS CORRIENTES!" & CHR(13) & _
            //    "NOTIFIQUE AL RESPONSABLE DE LAS CUENTAS CORRIENTES O AL ADMINISTRADOR DEL SISTEMA", vbCritical
            //End If
        }

        private void btnVerAnalisis_Click(object sender, EventArgs e)
        {
            dgvDiferenciasCtaCte.DataSource = new Cc1Manager().GetAnalisisDiferenciaSaldo();
        }
    }
}
