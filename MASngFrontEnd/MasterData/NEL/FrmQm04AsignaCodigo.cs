using System;
using System.Windows.Forms;
using Tecser.Business.MasterData;

namespace MASngFE.MasterData.NEL
{
    public partial class FrmQm04AsignaCodigo : Form
    {

        public FrmQm04AsignaCodigo(int numeroNel, NelManager.TipoCodigo tipoCod)
        {
            _tipoCod = tipoCod;
            _nel = numeroNel;
            InitializeComponent();
        }

        //------------------------------------------------------------
        private readonly int _nel;
        private readonly NelManager.TipoCodigo _tipoCod;
        public string CodigoAsignado;
        //------------------------------------------------------------

        private void FrmAsignaCodigo_Load(object sender, EventArgs e)
        {
            txtNel.Text = _nel.ToString();
            switch (_tipoCod)
            {
                case NelManager.TipoCodigo.Provisorio:
                    this.Text = @"Asignacion de Codigo Provisorio";
                    label32.Text = @"COD.PROVISORIO";


                    break;
                case NelManager.TipoCodigo.Definitivo:
                    label32.Text = @"COD.DEFINITIVO";
                    this.Text = @"Asignacion de Codigo Definitivo";

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool ValidaCodigoAsignado()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show(@"Debe proveer un valor de material", @"Validacion Incompleta", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (_tipoCod == NelManager.TipoCodigo.Definitivo)
            {
                //if (string.IsNullOrEmpty(txtAprobadoPor.Text))
                //{
                //    MessageBox.Show(@"Debe confirmar el nombre de la persona/cliente que aprobo el material",
                //        @"Validacion Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}
            }

            return true;
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidaCodigoAsignado())
                return;
            CodigoAsignado = txtCodigo.Text;
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
    }
}
