using System;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;

namespace MASngFE.MasterData.NEL
{
    public partial class FrmQm03NelAddProgress : Form
    {
        public FrmQm03NelAddProgress(int modo, int nel)
        {
            //creacion de nuevo avance
            _modo = modo;
            _nel = nel;
            _seq = null;
            var mainData = new NelManager().GetData(_nel);
            _estado = NelManager.MapTextToStatus(mainData.EstadoDesarrollo);
            InitializeComponent();
        }

        public FrmQm03NelAddProgress(int modo, int nel, int secuencia)
        {
            //edicion o visualizacion de avance
            _modo = modo;
            _nel = nel;
            _seq = secuencia;
            InitializeComponent();
        }

        //-----------------------------------------------------
        private readonly int _modo;
        private readonly int _nel;
        private readonly int? _seq;
        private NelManager.Status _estado;
        //-----------------------------------------------------

        private void FrmNelAddProgress_Load(object sender, EventArgs e)
        {
            CompleteHeaderData();

            if (_seq != null)
                LoadExistingData();

            if (_modo == 3)
                btnGrabar.Enabled = false;
        }

        private void CompleteHeaderData()
        {
            txtNel.Text = _nel.ToString();
            txtNelSecuencia.Text = _seq.ToString();
            txtUser.Text = GlobalApp.AppUsername;
            txtStatus.Text = _estado.ToString();
        }


        private void LoadExistingData()
        {
            var data = new NelManager().GetUpdateData(_nel, _seq.Value);

            txtStatus.Text = data.Estado;
            dtpFecha.Value = data.FechaUpdate;
            txtUser.Text = data.UserUpdate;
            _estado = NelManager.MapTextToStatus(data.Estado);
            txtAvance.Text = data.ComentarioAvance;
        }

        private bool ValidaOkToSave()
        {
            if (string.IsNullOrEmpty(txtAvance.Text))
            {
                MessageBox.Show(@"Debe completar un texto de avance", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidaOkToSave())
                return;

            new NelManager().SetNelProgress(_nel, _estado, txtAvance.Text);
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
