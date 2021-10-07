using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO.AsientoContable;

namespace MASngFE.Transactional.CO.GL
{
    public partial class FrmCO33DetalleAsiento : Form
    {
        private readonly int _asn;

        public FrmCO33DetalleAsiento(int asn)
        {
            _asn = asn;
            InitializeComponent();
        }

        private void FrmCO33DetalleAsiento_Load(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void PopulateData()
        {
            var h = new ManageFB01().RetornaHeader(_asn);
            var i = new ManageFB01().RetornaSegnmentos(_asn);

            txtNas.Text = _asn.ToString();
            txtFechaAsiento.Text = h.FECHA.Value.ToString("d");
            txtLx.Text = h.TIPO;
            txtMoneda.Text = h.MONE_ORI;
            txtPeriodo.Text = h.YEAR + h.MES;
            txtDescripcionAsiento.Text = h.HeaderText;
            txtTipoDoc.Text = h.DOCUTIPO;
            txtReferencia.Text = h.REFE;
            txtTC.Text = h.TC.ToString();
            txtFechaLog.Text = h.FechaOP.Value.ToString("f");
            txtUserLog.Text = h.LOG_USER;
            txtAsientoStatus.Text = h.ST;
            txtAsientoCheck.Text = h.CK.ToString();
            txtAsientoLink.Text = h.ALINK.ToString();
            txtAsientoCancel.Text = h.StatusCancel.ToString();
            txtNasX1.Text = h.NASX1.ToString();
            txtOrigen.Text = h.OR;

            t0602DOCUSBindingSource.DataSource = i;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
