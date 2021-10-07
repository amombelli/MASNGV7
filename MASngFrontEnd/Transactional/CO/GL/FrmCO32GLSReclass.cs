using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.CO;
using Tecser.Business.Transactional.CO.AsientoContable;

namespace MASngFE.Transactional.CO.GL
{
    public partial class FrmCO32GLSReclass : Form
    {
        private readonly int _nas;
        private readonly int _idseg;

        public FrmCO32GLSReclass(int nas, int idseg)
        {
            _nas = nas;
            _idseg = idseg;
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCO32GLSReclass_Load(object sender, EventArgs e)
        {
            t0135GLXBindingSource.DataSource = new GLAccountManagement().GetGLAllforGLS();
            txtAsiento.Text = _nas.ToString();
            txtSegmento.Text = _idseg.ToString();

            LoadData();
        }

        private void LoadData()
        {
            var dataAsiento = new ManageFB01().RetornaHeader(_idseg);
            var dataSegmento = new ManageFB01().GetSegmento(_nas, _idseg);
            txtGLOri.Text = dataSegmento.GL;
            txtGlOriDescripcion.Text = GLAccountManagement.GetGLDescriptionFromT135(dataSegmento.GL);

            txtValorDebe.Text = dataSegmento.DEBE.Value.ToString("C2");
            txtValorHaber.Text = dataSegmento.HABER.Value.ToString("C2");
            cmbGLAccount.SelectedIndex = -1;

        }

        private void btnUpdateGL_Click(object sender, EventArgs e)
        {
            if (cmbGLAccount.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar una GL Account Valida", @"Datos Incorrectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;

            }
            new ManageFB01().UpdateGL_Segmento(_nas, _idseg, cmbGLAccount.SelectedValue.ToString());
            MessageBox.Show(@"Los Datos han sido modificados correctamente", @"Datos Modificados", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            LoadData();
        }

        private void btnDetalleAsiento_Click(object sender, EventArgs e)
        {
            var f = new FrmCO33DetalleAsiento(_nas);
            f.Show();
        }
    }
}
