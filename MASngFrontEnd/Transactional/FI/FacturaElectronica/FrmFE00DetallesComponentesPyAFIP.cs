using System;
using System.Windows.Forms;
using WebServicesAFIP;

namespace MASngFE.Transactional.FI.FacturaElectronica
{
    public partial class FrmFE00DetallesComponentesPyAFIP : Form
    {
        public FrmFE00DetallesComponentesPyAFIP(int modo = 0)
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------
        private ModoEjecucion _modo;
        private WsaaManagement _wsa;
        //------------------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWSAA_Click(object sender, EventArgs e)
        {
            _modo = ckProduccion.Checked ? ModoEjecucion.Produccion : ModoEjecucion.Testeo;
            _wsa = new WsaaManagement(_modo, "wsfe");
            txtWsaaVersion.Text = _wsa.WsaaVersion;
            txtWsaaInstallPath.Text = _wsa.WsaaInstallDir;
            txtServer.Text = _wsa._serverWsaa;
            txtToken.Text = _wsa.Token;
            txtServicio.Text = @"wsfe";
            txtExpira.Text = _wsa.Expira;
            txtGenerado.Text = _wsa.Generado;
            txtTicketReusado.Text = _wsa.TicketReusado.ToString();
        }

        private void ckProduccion_CheckedChanged(object sender, EventArgs e)
        {
            _modo = ckProduccion.Checked ? ModoEjecucion.Produccion : ModoEjecucion.Testeo;
        }

        private void btnWSFEv1_Click(object sender, EventArgs e)
        {
            var fe = new FacturaElectronicaWs(_modo);
            fe.SoloConnectToCheck(_wsa);
            txtwsfeVer.Text = fe.Version;
            txtwsfeInstall.Text = fe.InstallDir;
            txtwsfeServer.Text = fe.ServerWsfe;
        }
    }
}
