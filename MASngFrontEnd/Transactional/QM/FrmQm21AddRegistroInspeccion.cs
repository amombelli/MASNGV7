using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.MM;
using Tecser.Business.Transactional.QM;
using TecserEF.Entity;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm21AddRegistroInspeccion : Form
    {
        public FrmQm21AddRegistroInspeccion()
        {
            InitializeComponent();
        }

        //-----------------------------------------------------------------------------------
        private decimal _maxKgLote;
        private DateTime _fechaLote = DateTime.Today;
        private int? _id63idPf;

        //-----------------------------------------------------------------------------------
        private void FrmQm21AddRegistroInspeccion_Load(object sender, EventArgs e)
        {
            cmbMaterial.DataSource = new MaterialMasterManager().GetCompleteListofMaterial(true);
            cmbMaterial.SelectedIndex = -1;
            utxtKg.Init(0, 10000, 1);
            cmbPlanInspeccion.DataSource = new QmMasterIplan().GetListIPlan();
            cmbPlanInspeccion.SelectedIndex = -1;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbPlanInspeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlanInspeccion.SelectedIndex == -1)
            {
                txtPlanInspeccionDesc.Text = null;
                return;
            }
            var plan = (T0801_QMMasterIPHeader)cmbPlanInspeccion.SelectedItem;
            txtPlanInspeccionDesc.Text = plan.DESCRIPCION;
        }
        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtMaterialDesc.Text = null;
                txtOrigen.Text = null;
                txtOrigenDesc.Text = null;
                return;
            }
            var mat = (T0010_MATERIALES)cmbMaterial.SelectedItem;
            txtMaterialDesc.Text = mat.DescripcionTecnicaLab;
            txtOrigen.Text = mat.ORIGEN;
            txtOrigenDesc.Text = MaterialOrigenDataType.RetornaTypeFromLetraMaterialMaster(mat.ORIGEN).ToString();
            if (!string.IsNullOrEmpty(mat.IP))
                cmbPlanInspeccion.SelectedValue = mat.IP;
        }

        private void TxtLote_Validating(object sender, CancelEventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show(@"Debe completar primero el Material", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLote.Text = null;
                return;
            }

            if (string.IsNullOrEmpty(txtLote.Text))
                return;

            var origen = MaterialOrigenDataType.RetornaTypeFromLetraMaterialMaster(txtOrigen.Text);
            switch (origen)
            {
                case MaterialOrigenDataType.OrigenDt.Fabricado:
                    //
                    IdentificaRecord70();
                    break;
                case MaterialOrigenDataType.OrigenDt.CompradoNac:
                    //
                    IdentificaRecord63();
                    break;
                case MaterialOrigenDataType.OrigenDt.Importado:
                    //
                    IdentificaRecord63();
                    break;
                case MaterialOrigenDataType.OrigenDt.AmbosFab:
                    //
                    IdentificaRecord70();
                    break;
                case MaterialOrigenDataType.OrigenDt.AmbosComp:
                    //
                    IdentificaRecord63();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void IdentificaRecord63()
        {
            int? id40 = null;
            var r = new QmRegistroInspeccion().BuscaRecordCompra(cmbMaterial.SelectedValue.ToString(), txtLote.Text);
            switch (r)
            {
                case -1:
                    MessageBox.Show(@"No Existe informacion sobre el lote que ha seleccionado", @"Lote Inexistente",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtLote.Text = null;
                    return;
                case -2:
                    using (var f = new FrmQm22SeleccionaRegistroCompra(cmbMaterial.SelectedValue.ToString(), txtLote.Text))
                    {
                        DialogResult dr = f.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            id40 = f.Id40;
                            txtVendorDescripcion.Text = f.Vendor;
                            _maxKgLote = f.KgSelected;
                            utxtKg.Text = _maxKgLote.ToString();
                        }
                        else
                        {
                            MessageBox.Show(@"No ha seleccionado ningun registro relacionado", @"Lote Sin Seleccion",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtLote.Text = null;
                            utxtKg.Text = "0";
                            txtSystemId.Text = null;
                            txtVendorDescripcion.Text = null;
                        }
                    }
                    break;
                default:
                    id40 = r;
                    txtSystemId.Text = r.ToString();
                    var idvendor = MmLog.GetT40Line(r).IDPRO;
                    utxtKg.Text = MmLog.GetT40Line(r).CANTIDAD.ToString();
                    if (idvendor != null)
                        txtVendorDescripcion.Text = new VendorManager().GetSpecificVendor(Convert.ToInt32(idvendor)).prov_rsocial;
                    break;

            }

            if (id40 == null)
            {
                txtSystemId.Text = null;
            }
            else
            {
                txtSystemId.Text = id40.Value.ToString();
            }
        }

        private void IdentificaRecord70()
        {
            var r = new QmRegistroInspeccion().BuscaRecordFabricacion(cmbMaterial.SelectedValue.ToString(), txtLote.Text);
        }

        private bool ValidaOkToAdd()
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe completar el Material para continuar", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (cmbPlanInspeccion.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe completar el Plan de Inspeccion para continuar", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (string.IsNullOrEmpty(txtLote.Text))
            {
                MessageBox.Show(@"Debe completar el Numero de Lote para continuar", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (utxtKg.ValueD <= 0)
            {
                MessageBox.Show(@"Debe completar la Cantidad [KG] para continuar", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            if (utxtKg.ValueD > _maxKgLote)
            {
                var x = MessageBox.Show(@"La Cantida supera a los Kg Ingresados/Fabricados. Confirma esta cantidad?",
                    @"Confirmacion de Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (x == DialogResult.No)
                    return false;
            }

            if (string.IsNullOrEmpty(txtComentarioH1.Text))
            {
                MessageBox.Show(@"Debe completar Motivo o Comentario del Registro de Inspeccion Manual", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }



            return true;
        }


        private void BtnCrearIRecord_Click(object sender, EventArgs e)
        {
            if (!ValidaOkToAdd())
                return;

            var xOrigen = MaterialOrigenDataType.RetornaTypeFromDataTypeText(txtOrigenDesc.Text);

            new QmRegistroInspeccion().CreaRegistroInspeccionH(QmRegistroInspeccion.TipoRecord.M,
                cmbMaterial.SelectedValue.ToString(), cmbPlanInspeccion.SelectedValue.ToString(), txtLote.Text,
                _fechaLote, utxtKg.ValueD, xOrigen, _id63idPf, txtVendorDescripcion.Text, txtComentarioH1.Text);
        }
    }
}
