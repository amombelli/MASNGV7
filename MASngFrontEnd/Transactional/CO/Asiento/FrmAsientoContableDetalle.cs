using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO.AsientoContable;

namespace MASngFE.Transactional.CO.Asiento
{
    public partial class FrmAsientoContableDetalle : Form
    {
        public FrmAsientoContableDetalle(int numeroAsiento, int modo = 3)
        {
            _modo = modo;
            _numeroAsiento = numeroAsiento;
            InitializeComponent();
        }

        //--------------------------------------------------------------------------
        private readonly int _numeroAsiento;
        private readonly int _modo;
        //--------------------------------------------------------------------------


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AsientoContableDetalle_Load(object sender, EventArgs e)
        {
            LoadAsientoHeader();
        }


        private void LoadAsientoHeader()
        {
            var h = new ManageFB01().RetornaHeader(_numeroAsiento);
            txtAsn.Text = h.IDDOCU.ToString();
            txtTipoLx.Text = h.TIPO;
            txtFechaReal.Text = h.FechaOP.Value.ToString("D");
            txtUserLog.Text = h.LOG_USER;
            txtTipoDoc.Text = h.DOCUTIPO;
            txtNumeroDoc.Text = h.REFE;
            txtStatusAs.Text = h.ST;
            ckStatusCancel.Checked = h.StatusCancel.Value;
            ckConcilCk.Checked = h.CK.Value;
            txtAsientoLink.Text = h.ALINK.ToString();

            txtDescripcionAsiento.Text = h.HeaderText;
            txtFechaContable.Text = h.FECHA.Value.ToString("d");
            txtYYYY.Text = h.YEAR;
            txtMM.Text = h.MES;

            txtMoneda.Text = h.MONE_ORI;
            txtImporte.Text = h.TOT_ARS.Value.ToString("C2");

            t602Bs.DataSource = new ManageFB01().RetornaSegnmentos(_numeroAsiento);

        }
    }
}
