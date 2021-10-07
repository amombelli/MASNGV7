using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Transactional.MM;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.MasterData.BOM;
using Tecser.Business.Security;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;

namespace MASngFE.MasterData.Material_Master
{
    public partial class FrmMasterDataSearchScreen : Form
    {
        public FrmMasterDataSearchScreen(int modo, string funcion)
        {
            _modo = modo;
            _funcion = funcion;
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------
        private readonly int _modo;
        private readonly string _funcion;
        //-------------------------------------------------------------------------------------------

        private void FrmMasterDataSearchScreen_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = new MaterialMasterManager().GetCompleteListMaterialAvailable().ToList();
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;
            HabilitaBotonesSegunPermisos();
        }

        private void HabilitaBotonesSegunPermisos()
        {
            //disabled all buttons
            btnDetalleBom.Enabled = false;
            btnEditMaterial.Enabled = false;
            btnDetalleMaterial.Enabled = false;
            btnInfoRecordClientes.Enabled = false;
            btnIrCQ.Enabled = false;
            btnPlanProduccion.Enabled = false;

            switch (_funcion)
            {
                case "MDSEARCH":
                    //acciona botones segun permisos
                    btnDetalleBom.Enabled = TsSecurityMng.CheckToEnableButton("FORM0");
                    btnEditMaterial.Enabled = TsSecurityMng.CheckToEnableButton("MM2");
                    btnDetalleMaterial.Enabled = TsSecurityMng.CheckToEnableButton("MM3");
                    btnInfoRecordClientes.Enabled = TsSecurityMng.CheckToEnableButton("CL4");
                    btnIrCQ.Enabled = TsSecurityMng.CheckToEnableButton("CQ0");
                    btnPlanProduccion.Enabled = TsSecurityMng.CheckToEnableButton("PF");
                    break;
                case "MM23":
                    //Edicion/Visualizacion de Materiales
                    if (_modo == 2)
                    {
                        btnEditMaterial.Enabled = true;
                    }
                    else
                    {
                        btnDetalleMaterial.Enabled = true;
                    }
                    break;
                default:
                    MessageBox.Show(@"La funcion configurada en TTransactions no se encuentra disponible",
                        @"Error en Config", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BlanqueaDatos()
        {
            txtDescripcionTipoMaterial.Text = null;
            txtTipoMaterial.Text = null;
            ckAKA.Checked = false;
            ckPrimario.Checked = false;
            txtCodigoPrimario.Text = null;
            txtCodigoAka.Text = null;
            txtTipoA.Text = null;
            txtTipoP.Text = null;
            txtDispoNP.Text = null;
            txtDispoNP.BackColor = Color.LightGray;
            txtDipoFab.Text = null;
            txtDipoFab.BackColor = Color.LightGray;
            txtTieneFormula.Text = null;
            txtTieneFormula.BackColor = Color.LightGray;
            txtDispoComprar.Text = null;
            txtDispoComprar.BackColor = Color.LightGray;
            txtRequiereFormula.Text = null;
            txtRequiereFormula.BackColor = Color.LightGray;
        }
        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbMaterial.SelectedIndex == -1)
            {
                BlanqueaDatos();
                return;
            }

            if (cmbMaterial.SelectedValue == null)
            {
                BlanqueaDatos();
                return;
            }

            var dataRtn = new MaterialMasterManager().BuscaMaterialSearch(cmbMaterial.SelectedValue.ToString());
            if (dataRtn.T0010)
            {
                ckPrimario.Checked = true;
                lblPrimario.BackColor = Color.GreenYellow;
            }
            else
            {
                ckPrimario.Checked = false;
                lblPrimario.BackColor = Color.Orange;
            }

            if (dataRtn.T0011)
            {
                ckAKA.Checked = true;
                lblAKA.BackColor = Color.GreenYellow;
            }
            else
            {
                ckAKA.Checked = false;
                lblAKA.BackColor = Color.Orange;
            }

            if (dataRtn.T0010)
            {
                txtTipoMaterial.Text = dataRtn.TipoT0010;
            }
            else
            {
                txtTipoMaterial.Text = dataRtn.TipoT0011;
            }
            var datosTipo = new MaterialTypeManager().GetMtype(txtTipoMaterial.Text);
            txtDescripcionTipoMaterial.Text = datosTipo.Descripcion;
            txtTipoA.Text = dataRtn.TipoT0011;
            txtTipoP.Text = dataRtn.TipoT0010;


            if (datosTipo.DispOrdenFabricacion)
            {
                txtRequiereFormula.Text = @"SI";
                txtRequiereFormula.BackColor = Color.GreenYellow;
                btnDetalleBom.Enabled = true;
            }
            else
            {
                txtRequiereFormula.Text = @"NO";
                txtRequiereFormula.BackColor = Color.Orange;
                btnDetalleBom.Enabled = false;

            }
            //
            if (datosTipo.DispSalesOrder)
            {
                txtDispoNP.Text = @"SI";
                txtDispoNP.BackColor = Color.GreenYellow;
                btnInfoRecordClientes.Enabled = true;
            }
            else
            {
                txtDispoNP.Text = @"NO";
                txtDispoNP.BackColor = Color.Orange;
                btnInfoRecordClientes.Enabled = false;
            }
            //
            if (datosTipo.DispOrdenFabricacion)
            {
                txtDipoFab.Text = @"SI";
                txtDipoFab.BackColor = Color.GreenYellow;
                btnPlanProduccion.Enabled = true;
            }
            else
            {
                txtDipoFab.Text = @"NO";
                txtDipoFab.BackColor = Color.Orange;
                btnPlanProduccion.Enabled = false;
            }
            //
            if (datosTipo.DispOrdenCompra)
            {
                txtDispoComprar.Text = @"SI";
                txtDispoComprar.BackColor = Color.GreenYellow;

            }
            else
            {
                txtDispoComprar.Text = @"NO";
                txtDispoComprar.BackColor = Color.Orange;
            }

            var hayFormula = BOMManagerMD.CheckIfBOMExist(cmbMaterial.SelectedValue.ToString());
            if (hayFormula)
            {
                txtTieneFormula.Text = @"SI";
                txtTieneFormula.BackColor = Color.GreenYellow;
            }
            else
            {
                txtTieneFormula.Text = @"NO";
                txtTieneFormula.BackColor = Color.Orange;
            }

            txtCodigoPrimario.Text = dataRtn.CodigPrimario;
            txtCodigoAka.Text = dataRtn.CodigoAKA;

            HabilitaBotonesSegunPermisos();



        }
        private void cmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Validaciones.CheckCmb(cmbMaterial);
        }
        private void btnDetalleMaterial_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Material para Visualizar Detlles", @"Visualizar/Editar Material",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (var f = new FrmMdm01MaterialMasterMain(3, txtCodigoPrimario.Text))
                {
                    f.ShowDialog();
                }
            }
        }
        private void btnIrCQ_Click(object sender, EventArgs e)
        {
            if (new TcodeManager().ValidateTransactionBeforeRun("CQ") == TcodeManager.TcodeResponse.TxOK)
            {
                using (var f = new FrmCq(cmbMaterial.SelectedValue.ToString()))
                {
                    f.ShowDialog();
                }
            }
        }
        private void btnPlanProduccion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"PROXIMAMENTE");
        }
        private void btnInfoRecordClientes_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"PROXIMAMENTE");
        }
        private void btnDetalleBom_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"PROXIMAMENTE");
        }
        private void btnEditMaterial_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show(@"Debe Seleccionar un Material para Visualizar Detlles", @"Visualizar/Editar Material",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (var f = new FrmMdm01MaterialMasterMain(2, txtCodigoPrimario.Text))
                {
                    f.ShowDialog();
                }
            }
        }
    }
}
