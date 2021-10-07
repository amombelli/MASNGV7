using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.QM;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm33SplitRegistroInspeccion : Form
    {


        public FrmQm33SplitRegistroInspeccion(int idR, int counter)
        {
            _idR = idR;
            _idCounter = counter;
            InitializeComponent();
        }

        private readonly int _idR;
        private readonly int _idCounter;

        private void FrmQm33SplitRegistroInspeccion_Load(object sender, EventArgs e)
        {
            txtIdCounter.Text = _idCounter.ToString();
            txtRi.Text = _idR.ToString();

            var dataH2 = new QmRegistroInspeccionH1H2().GetRegistroH2(_idR, _idCounter);
            txtPlanName.Text = dataH2.IdPlan;
            txtIplanDescription.Text = new QmMasterIplan().GetPlanHeader(dataH2.IdPlan).DESCRIPCION;
            ckPlanEditado.Checked = dataH2.PlanEditado;
            txtMaterial.Text = dataH2.Material;
            var dataH1 = new QmRegistroInspeccionH1H2().GetRegistroH1(_idR);
            txtLote.Text = dataH2.Lote;
            txtLotePadre.Text = dataH1.Lote;

            uKgInspeccion.Init(0, dataH2.KGInspeccion, true, false, false);
            txtKgOri.Text = dataH2.KGInspeccion.ToString("N2");
            uKgInspeccion.Text = dataH2.KGInspeccion.ToString("N2");
            txtKgSplit.Text = 0.ToString("N2");

        }

        private void UKgInspeccion_Validated(object sender, EventArgs e)
        {
            decimal kgOri = Convert.ToDecimal(txtKgOri.Text);
            txtKgSplit.Text = (kgOri - uKgInspeccion.ValueD).ToString("N2");
        }

        private void BtnSplit_Click(object sender, EventArgs e)
        {
            var kgSplit = Convert.ToDecimal(txtKgSplit.Text);
            if (kgSplit > 0)
            {
                var resp = MessageBox.Show($@"Confirma la creacion de un nuevo Registro de Inspeccion de {kgSplit} Kg?",
                    @"Confirmacion de IRecord Split", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == DialogResult.No)
                    return;

                var idStk = new StockManager().GetLoteRestringido(txtMaterial.Text, txtLote.Text,
                    Convert.ToDecimal(txtKgOri.Text));
                if (idStk <= 0)
                {
                    MessageBox.Show(
                        @"Ha Ocurrido un Error - No se puede hacer el SPLIT del Stock porque no hay identifacion del mismo",
                        @"Error en Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var idx = new StockManager().SplitStock(idStk, uKgInspeccion.ValueD);
                var idH2 = new QmRegistroInspeccion().SplitRegistroH2(_idR, _idCounter, kgSplit, txtObservacionH2.Text);
                var h2 = new QmRegistroInspeccionH1H2().GetRegistroH2(_idR, idH2);
                new StockManager().ChangeNumeroLote(idx, h2.Lote, txtObservacionH2.Text);
                this.Close();
                this.DialogResult = DialogResult.OK;
                return;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }

        private void UKgInspeccion_Validating(object sender, CancelEventArgs e)
        {
            if (uKgInspeccion.ValueD == 0)
            {
                MessageBox.Show(@"Los Kg del Registro Actual no pueden ser 0 Kg", @"Seleccion Invalida",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
    }
}
