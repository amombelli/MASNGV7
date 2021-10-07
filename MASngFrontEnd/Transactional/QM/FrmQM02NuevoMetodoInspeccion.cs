using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.Transactional.QM;
using TecserEF.Entity;

namespace MASngFE.Transactional.QM
{
    public partial class FrmQm02NuevoMetodoInspeccion : Form
    {
        //Nuevo metodo de inspeccion
        public FrmQm02NuevoMetodoInspeccion()
        {
            _modo = 1;
            InitializeComponent();
        }

        //Edicion-Visualizacion de Metodo de Inspeccion
        public FrmQm02NuevoMetodoInspeccion(string metodo, int modo)
        {
            _metodo = metodo;
            _modo = modo;
            InitializeComponent();
        }

        //----------------------------------------------------------
        private readonly int _modo;
        private string _metodo;
        //----------------------------------------------------------

        private void FrmQM02NuevoMetodoInspeccion_Load(object sender, EventArgs e)
        {
            btnAddMetodo.Enabled = false;
            btnUpdateMetodo.Enabled = false;

            uckActivo.SetLabel("Metodo ACTIVO");
            if (_modo == 1)
            {
                txtMetodoId.ReadOnly = false;
                uckActivo.SetValor(true);
                btnAddMetodo.Enabled = true;

            }
            else
            {
                var data = new QmMetodoInspeccion().GetMetodoData(_metodo);
                if (data == null)
                {
                    MessageBox.Show(@"Error en la obtencion del metodo", @"Error de Datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                txtMetodoId.Text = _metodo;
                txtMetodoDescription.Text = data.Descripcion;
                txtUnit.Text = data.ValorUnit;
                cmbDataType.SelectedItem = data.ValorType;
                txtDocumentacion.Text = data.Documentacion;
                txtMetodoId.ReadOnly = true;
                uckActivo.SetValor(data.Activo);
                if (_modo == 3)
                {
                    panel1.Enabled = false;
                    panel2.Enabled = false;
                }
                else
                {
                    btnUpdateMetodo.Enabled = true;
                }
            }
        }
        private bool ValidaDatosCompletos()
        {
            if (string.IsNullOrEmpty(txtMetodoId.Text))
            {
                MessageBox.Show(@"El Metodo no puede estar incompleto", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            _metodo = txtMetodoId.Text;

            if (string.IsNullOrEmpty(txtMetodoDescription.Text))
            {
                MessageBox.Show(@"La descripcion del metodo no puede estar incompleta", @"Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                txtUnit.Text = @"NoDEF";
            }


            if (cmbDataType.SelectedItem == null)
            {
                MessageBox.Show(@"Debe completar el Tipo de Dato (DataType)", @"Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private T0800_QMMetodosInspeccion MapData()
        {
            var metodoData = new T0800_QMMetodosInspeccion()
            {
                IdMetodo = _metodo,
                Activo = uckActivo.Value,
                Descripcion = txtMetodoDescription.Text,
                Documentacion = txtDocumentacion.Text,
                ValorType = cmbDataType.SelectedItem.ToString(),
                ValorUnit = txtUnit.Text,
            };
            return metodoData;
        }
        private void BtnAddMetodo_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletos())
            {
                var resp = new QmMetodoInspeccion().CreateAndUpdateMetodoInspeccion(MapData());
                if (resp == true)
                {
                    MessageBox.Show(@"El Metodo de Inspeccion se ha creado correctamente!", @"Creacion Correcta",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show(@"Ha Ocurrido un error al Grabar el Metodo de Inspeccion. Reviso los Datos y vuelvalo a Intentar", @"Creacion Correcta",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void BtnUpdateMetodo_Click(object sender, EventArgs e)
        {
            if (ValidaDatosCompletos())
            {
                var resp = new QmMetodoInspeccion().CreateAndUpdateMetodoInspeccion(MapData());
                if (resp == true)
                {
                    MessageBox.Show(@"El Metodo de Inspeccion se ha Actualizado correctamente!", @"Creacion Correcta",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                else
                {
                    MessageBox.Show(@"Ha Ocurrido un error al Actualizar el Metodo de Inspeccion. Reviso los Datos y vuelvalo a Intentar", @"Creacion Correcta",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void TxtMetodoId_Validating(object sender, CancelEventArgs e)
        {
            if (_modo == 1)
            {
                if (txtMetodoId.Text.Length > 10)
                {
                    MessageBox.Show(@"El Metodo ID no puede superar los 10 caracteres", @"Error en Longitud",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;

                }

                var q = new QmMetodoInspeccion().GetMetodoData(txtMetodoId.Text);
                if (q != null)
                {
                    MessageBox.Show(@"El Metodo ID Ya Existe - Debe crear un metodo diferente", @"Error en Longitud",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }


    }
}
