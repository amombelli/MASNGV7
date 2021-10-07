using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.HR;

namespace MASngFE.Transactional.HR
{
    public partial class FrmHR09DetalleRegistroAdelanto : Form
    {
        private readonly int _idAd;

        public FrmHR09DetalleRegistroAdelanto(int idAd)
        {
            _idAd = idAd;
            InitializeComponent();
        }

        private void FrmHR09DetalleRegistroAdelanto_Load(object sender, EventArgs e)
        {

            var dataAd = new ManejoAdelantos().GetAdelanto(_idAd);
            txtIdAdelanto.Text = _idAd.ToString();
            txtEmpleado.Text = dataAd.Shortname;
            txtImporteAdeudado.Text = dataAd.MontoAdeudado.ToString("C2");

            txtImporteSolicitado.Text = dataAd.MontoSolicitado.ToString("C2");
            txtCompromisoDePago.Text = dataAd.AcuerdoDePago;

            txtImporteAdelantar.Init(0, dataAd.MontoSolicitado, false, false, false);
            if (dataAd.MontoAbonado > 0)
            {
                txtImporteAdelantar.Enabled = false;
                btnAbonar.Enabled = false;
                cmbCuenta.Enabled = false;
            }
            t0150CUENTASBindingSource.DataSource = new CuentasManager().GetListaCuentasAvailableForContar();
        }

        private void btnAbonar_Click(object sender, EventArgs e)
        {



            btnAbonar.Enabled = false;
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {

        }
    }
}
