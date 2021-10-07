using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using Tecser.Business.MasterData.Material_Master;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.PP;
using TecserEF.Entity;

namespace MASngFE.Transactional.PP
{
    public partial class FrmPP14AgregarMaterialPF : Form
    {

        /// <summary>
        /// Este Constructor lo uso cuando llamo desde PP10 
        /// </summary>
        public FrmPP14AgregarMaterialPF(int numeroOF, FrmPP10CierreOF frmPrevio, bool saveDb = true)
        {
            _numeroOF = numeroOF;
            _frm = frmPrevio;
            _saveDb = true;
            InitializeComponent();
        }
        public FrmPP14AgregarMaterialPF(int numeroOF)
        {
            _numeroOF = numeroOF;
            _frm = null;
            _saveDb = false;
            InitializeComponent();
        }

        //Este Consutrctor agrega el elemento a la lista - no guarda ningun dato en la DB
        //Y el formulario que llama luego hace all el manejo de insercion.
        public FrmPP14AgregarMaterialPF(int numeroOF, List<T0072_FORMULA_TEMP> lista)
        {
            _numeroOF = numeroOF;
            _frm = null;
            _saveDb = false;
            _lst = lista;
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------------
        private readonly int _numeroOF;
        private readonly FrmPP10CierreOF _frm;
        public List<T0072_FORMULA_TEMP> _lst = new List<T0072_FORMULA_TEMP>();
        private readonly bool _saveDb;
        //-------------------------------------------------------------------------------------------------------------------

        private void btnAgregarItemAdicional_Click(object sender, EventArgs e)
        {
            var fusionMaterial = false;
            bool recalculo;
            bool modificado;
            var iadded = _lst.Where(c => c.Added).Count();
            if (rbContainer.Checked)
            {
                if (cmbContainer.SelectedValue == null)
                {
                    MessageBox.Show(@"Debe Seleccionar un Insumo/Container valido", @"Datos Incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(txtContainerCantidad.Text))
                {
                    txtContainerCantidad.Text = 0.ToString();
                }

                if (Convert.ToDecimal(txtContainerCantidad.Text) <= 0)
                {
                    MessageBox.Show(@"Debe Seleccionar una cantidad valida de insumos/bolsas", @"Datos Incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var resp1 = MessageBox.Show($"Desea Agregar el container '{cmbContainer.SelectedValue.ToString()}?", @"Agregado de Insumos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp1 == DialogResult.No)
                    return;

                var tmpX = new T0072_FORMULA_TEMP
                {
                    MaterialExtra = false,
                    OF = _numeroOF,
                    Primario = cmbContainer.SelectedValue.ToString(),
                    Modificado = true,
                    CantidadBase = 0,
                    CantidadKG = Convert.ToDecimal(txtContainerCantidad.Text),
                    CantidadKGReal = Convert.ToDecimal(txtContainerCantidad.Text),
                    BatchNumber = null,
                    NForm = -1,
                    StatusStock = StatusStockDescuento.Unknown.ToString(),
                    Added = true,
                    Recalculo = false,
                    Repro = false,
                    CantidadPor = 0,
                    CantidadPorReal = 0,
                    idItemFormula = 800 + iadded,
                };
                if (_saveDb)
                    new OrdenFabricacionBOMManager().AddItemModificarFormula(tmpX);

                if (_frm != null)
                {
                    _frm._lstFormula.Add(tmpX);
                    _frm.RefrescaDgvCompleto();
                }
                _lst.Add(tmpX);
                cmbContainer.SelectedIndex = -1;
                txtContainerCantidad.Text = 0.ToString();
                return;
            }

            if (cmbPrimarioAdd.SelectedValue == null)
            {
                MessageBox.Show(@"Debe seleccionar un Material (Item) Valido", @"Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rbFijo.Checked)
            {
                if (string.IsNullOrEmpty(txtAddedKg.Text))
                {
                    txtAddedKg.Text = 0.ToString("N2");
                }

                if (Convert.ToDecimal(txtAddedKg.Text) == 0)
                {
                    MessageBox.Show(@"Debe completar el valor en KG del material a agregar", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                modificado = true;
                recalculo = true;
            }
            else if (rbProporcion.Checked)
            {
                //Proporcion
                if (string.IsNullOrEmpty(txtAddedProp.Text))
                {
                    txtAddedProp.Text = 0.ToString("P2");
                }

                if (FormatAndConversions.CPorcentajeADecimal(txtAddedProp.Text) == 0)
                {
                    MessageBox.Show(@"Debe completar el valor en % [0-100] del material a agregar", @"Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                modificado = true;
                recalculo = false;
            }
            else
            {
                //Fusion
                recalculo = true;
                modificado = true;
                fusionMaterial = true;
            }

            var resp = MessageBox.Show($"Desea Agregar a la formula el Material '{cmbPrimarioAdd.SelectedValue.ToString()}?", @"Agregado de CostItems a una Formula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;

            var tmp = new T0072_FORMULA_TEMP
            {
                MaterialExtra = !recalculo,
                OF = _numeroOF,
                Primario = cmbPrimarioAdd.SelectedValue.ToString(),
                Modificado = modificado,
                CantidadBase = 0,
                CantidadKGReal = 0,
                BatchNumber = null,
                NForm = -1,
                StatusStock = StatusStockDescuento.Unknown.ToString(),
                Added = true,
                Recalculo = recalculo,
                Repro = fusionMaterial,
                idItemFormula = 800 + iadded,
            };

            if (rbFijo.Checked || rbFusion.Checked)
            {
                tmp.CantidadPor = 0;
                tmp.CantidadKG = Convert.ToDecimal(txtAddedKg.Text);
                tmp.CantidadKGReal = tmp.CantidadKG;
            }
            else if (rbProporcion.Checked)
            {
                tmp.CantidadPor = FormatAndConversions.CPorcentajeADecimal(txtAddedProp.Text);
                //tmp.CantidadPorReal = FormatAndConversions.CPorcentajeADecimal(txtAddedProp.Text);
                tmp.CantidadKG = 0;
            }
            if (_saveDb)
                new OrdenFabricacionBOMManager().AddItemModificarFormula(tmp);

            if (_frm != null)
            {
                _frm._lstFormula.Add(tmp);
                _frm.RefrescaDgvCompleto();
            }
            _lst.Add(tmp);
            cmbPrimarioAdd.SelectedIndex = -1;
            txtAddedProp.Text = 0.ToString("P2");
            txtAddedKg.Text = 0.ToString("N2");

            if (_saveDb == false)
            {
                //En modo que no graba a la base de datos automaticamente cierra el form para que el 
                //formulario llamante haga all el manejo de los items
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (_saveDb == false)
            {
                //En modo que no graba a la base de datos automaticamente si se sale por exit manda un cancel
                //para que el formulario que recibe la info no haga nada
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        private void rbFijo_CheckedChanged(object sender, EventArgs e)
        {
            cmbPrimarioAdd.Visible = true;
            txtDescripcionMaterialAdd.Visible = true;
            cmbContainer.Visible = false;
            txtContainerDescription.Visible = false;
            txtContainerCantidad.Enabled = false;

            if (rbFijo.Checked)
            {
                txtAddedProp.Text = 0.ToString("P2");
                txtAddedProp.Enabled = false;
                txtAddedKg.Enabled = true;
                cmbPrimarioAdd.SelectedIndex = -1;
                cmbPrimarioAdd.Enabled = true;
            }
            else if (rbProporcion.Checked)
            {
                txtAddedKg.Text = 0.ToString("N2");
                txtAddedKg.Enabled = false;
                txtAddedProp.Enabled = true;
                cmbPrimarioAdd.SelectedIndex = -1;
                cmbPrimarioAdd.Enabled = true;
            }
            else if (rbFusion.Checked)
            {
                //Fusion de material
                cmbPrimarioAdd.SelectedValue = txtMaterialFabricado.Text;
                txtAddedProp.Text = 0.ToString("P2");
                txtAddedProp.Enabled = false;
                txtAddedKg.Enabled = true;
                cmbPrimarioAdd.Enabled = false;
            }
            else
            {
                //Fusion de material
                cmbPrimarioAdd.Visible = false;
                txtDescripcionMaterialAdd.Visible = false;
                cmbContainer.Visible = true;
                txtContainerDescription.Visible = true;
                txtAddedProp.Text = 0.ToString("P2");
                txtAddedProp.Enabled = false;
                txtAddedKg.Enabled = false;
                txtAddedKg.Text = 0.ToString("N2");
                txtContainerCantidad.Enabled = true;
                txtContainerCantidad.ReadOnly = false;
                cmbContainer.Enabled = true;
            }
        }

        private void txtAddedKg_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddedKg.Text))
                txtAddedKg.Text = 0.ToString("N2");
            txtAddedKg.Text = Convert.ToDecimal(txtAddedKg.Text).ToString("N2");
        }

        private void txtAddedProp_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddedProp.Text))
                txtAddedProp.Text = 0.ToString("P2");

            var valorPorc = FormatAndConversions.CPorcentajeADecimal(txtAddedProp.Text);
            if (valorPorc >= 1)
            {
                toolTip1.ToolTipTitle = "Valor sobrepasado (Expresado en %)";
                toolTip1.Show("El Valor a Agregar no debe sobrepasar el Maximo de 100%", txtAddedProp, txtAddedProp.Location, 5000);
                e.Cancel = true;
            }
            txtAddedProp.Text = valorPorc.ToString("P2");
        }

        private void txtContainerCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtContainerCantidad.Text))
                txtContainerCantidad.Text = 0.ToString("N2");
        }

        private void txtAddedKg_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }

        private void cmbPrimarioAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrimarioAdd.SelectedIndex == -1)
            {
                btnAgregarItemAdicional.Enabled = false;
                txtDescripcionMaterialAdd.Text = null;
            }
            else
            {
                var data = cmbPrimarioAdd.SelectedItem;
                var txt = data as T0010_MATERIALES;
                txtDescripcionMaterialAdd.Text = txt.MAT_DESC;
                btnAgregarItemAdicional.Enabled = true;
            }
        }

        private void cmbPrimarioAdd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPrimarioAdd.Text))
            {
                txtDescripcionMaterialAdd.Text = null;
                btnAgregarItemAdicional.Enabled = false;
                cmbPrimarioAdd.SelectedIndex = -1;
                return;
            }
            if (Validaciones.CheckCmb(cmbPrimarioAdd))
            {
                toolTip1.ToolTipTitle = "Datos Incorrectos";
                toolTip1.Show("Seleccione un Material Valido", cmbPrimarioAdd, cmbPrimarioAdd.Location, 5000);
                e.Cancel = true;
            }
            else
            {
                btnAgregarItemAdicional.Enabled = true;
            }
        }

        private void FrmPP14AgregarMaterialPF_Load(object sender, EventArgs e)
        {
            rbFijo.Checked = true;
            txtAddedProp.Text = 0.ToString("P2");
            txtAddedKg.Text = 0.ToString("N2");

            t0010ContainerBindingSource.DataSource = new ContainerManager().GetAllContainer(true);
            cmbContainer.SelectedIndex = -1;

            t0010MATERIALESBindingSource.DataSource = new MaterialMasterManager().GetCompleteListofMaterial();
            cmbPrimarioAdd.SelectedIndex = -1;

            var dataOF = PlanProduccionListManager.GetOFData(_numeroOF);
            txtNumeroOF.Text = _numeroOF.ToString();
            txtEstadoOF.Text = dataOF.STATUS;
            if (dataOF.KG_Fabricados == null)
                dataOF.KG_Fabricados = 0;

            txtCantidadKgIngresados.Text = dataOF.KG_Fabricados.ToString("N2");
            txtMaterialFabricado.Text = dataOF.MATERIAL;

        }

        private void cmbContainer_Validating(object sender, CancelEventArgs e)
        {
            if (cmbContainer.SelectedValue != null)
            {
                btnAgregarItemAdicional.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(cmbContainer.Text) == false)
                {
                    e.Cancel = true;
                    btnAgregarItemAdicional.Enabled = false;
                }
            }
        }

        private void cmbContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbContainer.SelectedIndex == -1)
            {
                txtContainerCantidad.Text = null;
                txtContainerDescription.Text = null;
            }
            else
            {
                var x = cmbContainer.SelectedItem;
                T0010_Container data = (T0010_Container)x;
                txtContainerDescription.Text = data.ContainerDescription;
            }
        }
    }
}
