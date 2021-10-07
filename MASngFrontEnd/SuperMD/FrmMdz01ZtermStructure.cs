using System;
using System.Windows.Forms;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using TecserEF.Entity;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MASngFE.SuperMD
{
    public partial class FrmMdz01ZtermStructure : Form
    {
        public FrmMdz01ZtermStructure(int modo = 0)
        {
            _modo = modo;
            InitializeComponent();
        }

        public FrmMdz01ZtermStructure(int modo, string condicion)
        {
            _modo = modo;
            Condicion = condicion;
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------
        private readonly int _modo; //modo=1,2,3 MD ; modo=5 Select Zterm
        public string Condicion { get; private set; }
        //----------------------------------------------------------------------------------


        private void FrmAddressStructure_Load(object sender, EventArgs e)
        {
            //Configuracion combobox
            t0019ZTERMBindingSource.DataSource = new ZtermManager().GetCompleteListOfZterms();
            cmbZterm.SelectedIndex = -1;
            txtDescripcion.Text = null;
            txtDiasCobranza.Text = null;
            txtDiasValores.Text = null;
            txtDiasTotalesPagoDocumento.Text = null;
            ckActivo.Checked = false;
            //
            btnNew.Enabled = false;
            btnSelect.Enabled = false;
            btnUpdateSave.Enabled = false;
            txtZtermId.Visible = false;
            switch (_modo)
            {
                case 1:
                    btnUpdateSave.Enabled = true;
                    cmbZterm.Visible = false;
                    txtZtermId.Visible = true;
                    break;

                case 2:
                    btnUpdateSave.Enabled = true;
                    break;

                case 3:

                    break;


                case 5:
                    //modo seleccion
                    btnSelect.Enabled = true;
                    break;
                default:
                    MessageBox.Show(@"Modo no definido", @"Condicion no desarrollada", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }
        private bool ValidacionDatos()
        {
            if (_modo == 1)
            {
                if (string.IsNullOrEmpty(txtZtermId.Text))
                {
                    MessageBox.Show(@"Debe Seleccionar una condicion de Pago", @"Datos Incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (cmbZterm.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe Seleccionar una condicion de Pago", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show(@"Debe Completar una Descripcion de los dias de Pago", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtDiasValores.Text))
            {
                MessageBox.Show(@"Debe Seleccionar dias maximos de valores hasta su acreditacion", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtDiasCobranza.Text))
            {
                MessageBox.Show(@"Debe Seleccionar los dias desde la factura al pago", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cmbZterm.DropDownStyle = ComboBoxStyle.DropDown;
            cmbZterm.Text = "";
            txtDiasCobranza.Text = "";
            txtDescripcion.Text = "";
            txtDiasValores.Text = "";
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(cmbLocalidad.Text) != true)
            //{
            //    var f2 = new FrmCustomerDetailData(2, (int) cmbLocalidad.SelectedValue);
            //    {
            //    }
            //    ;
            //    f2.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Complete el Cliente que desea Modificar", "Validacion de Datos", MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //}
        }
        private T0019_ZTERM MapForm_StructureT0019(T0019_ZTERM structure)
        {
            structure.ACTIVO = ckActivo.Checked;
            structure.ZTERMDESC = txtDescripcion.Text;
            structure.ZTERMDIASCOB = Convert.ToInt32(txtDiasCobranza.Text);
            structure.ZTERMDIASPPM = Convert.ToInt32(txtDiasValores.Text);
            structure.ZTERM = cmbZterm.Text;
            return structure;
        }
        private void cmbZterm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbZterm.SelectedIndex == -1)
            {
                return;
            }
            var data = new ZtermManager().GetSpecificZtermData(cmbZterm.SelectedValue.ToString());
            txtDescripcion.Text = data.ZTERMDESC;
            txtDiasCobranza.Text = data.ZTERMDIASCOB.ToString();
            txtDiasValores.Text = data.ZTERMDIASPPM.ToString();
            txtDiasTotalesPagoDocumento.Text = (data.ZTERMDIASCOB + data.ZTERMDIASPPM).ToString();
            ckActivo.Checked = data.ACTIVO;
            Condicion = cmbZterm.SelectedValue.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (ValidacionDatos() == false)
                return;
        }

        private T0019_ZTERM MapScreenToStructure()
        {
            var data = new T0019_ZTERM()
            {
                ACTIVO = ckActivo.Checked,
                ZTERM = Condicion,
                ZTERMDIASPPM = Convert.ToInt32(txtDiasValores.Text),
                ZTERMDIASCOB = Convert.ToInt32(txtDiasCobranza.Text),
                ZTERMDESC = txtDescripcion.Text
            };
            return data;
        }

        private void btnUpdateSave_Click(object sender, EventArgs e)
        {
            if (ValidacionDatos() == false)
                return;

            var x = new ZtermManager().GuardaZterm(MapScreenToStructure());



        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbZterm.SelectedIndex == -1)
            {
                MessageBox.Show(@"Debe seleccionar una condicion de pago", @"Condicion no Seleccionada",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Condicion = cmbZterm.SelectedValue.ToString();
            this.Close();
            this.DialogResult = DialogResult.OK;
        }


        private void txtDiasCobranza_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloEnteroKeyPress(sender, e);
        }

        private void txtZtermId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtZtermId.Text))
            {
                MessageBox.Show(@"Debe Seleccionar una Condicion de Pago", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                e.Cancel = true;
            }

            if (new ZtermManager().GetSpecificZtermData(txtDescripcion.Text, true) != null)
            {
                MessageBox.Show(@"La Condicion de Pago Ingresada ya Existe", @"Datos Ya Existentes!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            Condicion = txtZtermId.Text;
        }

        private void txtDiasCobranza_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDiasCobranza.Text))
                txtDiasCobranza.Text = "0";

            if (string.IsNullOrEmpty(txtDiasValores.Text))
                txtDiasValores.Text = "0";

            txtDiasTotalesPagoDocumento.Text =
                (Convert.ToInt32(txtDiasCobranza.Text) + Convert.ToInt32(txtDiasValores.Text)).ToString();

        }
    }
}
