using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MASngFE.Transactional.SD.SalesOrder;
using Tecser.Business.MainApp;
using Tecser.Business.Tools;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Application
{
    public partial class FrmApp02ControlsInForms : Form
    {
        public FrmApp02ControlsInForms()
        {
            InitializeComponent();
        }

        private readonly List<RtnElementosSingle> _dataIgnorado = new List<RtnElementosSingle>();
        private readonly List<RtnElementosSingle> _dataNoManejado = new List<RtnElementosSingle>();

        private void button1_Click(object sender, EventArgs e)
        {
            var q = new FrmSD02SalesOrderMain(0);
            //var w = new ControlsInForm().GetAll(q, typeof(TextBox));
            //new ControlsInForm().GetTextBoxInForm(typeof(FrmSD02SalesOrderMain));

            var xxxx = new ControlesEnFormularios(q);
            var p = xxxx.GetListOfControls();
            rtnElmentControlManagedBindingSource.DataSource = p.ObjetosOK.ToList();
            txtNoManejados.Text = p.ObjetosNoManejados.Count.ToString();
            txtIgnorados.Text = p.ObjetosIgnorados.Count.ToString();
            _dataNoManejado.AddRange(p.ObjetosNoManejados);
            _dataIgnorado.AddRange(p.ObjetosIgnorados);
        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Form formX = null;
                if (string.IsNullOrEmpty(txtArg1.Text) && string.IsNullOrEmpty(txtArg2.Text))
                {
                    formX = Activator.CreateInstance(
                        Type.GetType(cmbNombreFormulario.SelectedValue.ToString())) as Form;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtArg1.Text))
                    {

                        formX = Activator.CreateInstance(
                            Type.GetType(cmbNombreFormulario.SelectedValue.ToString()), 1) as Form;
                    }
                }


                var xxxx = new ControlesEnFormularios(formX);
                var p = xxxx.GetListOfControls();
                rtnElmentControlManagedBindingSource.DataSource = p.ObjetosOK.ToList();
                txtNoManejados.Text = p.ObjetosNoManejados.Count.ToString();
                txtIgnorados.Text = p.ObjetosIgnorados.Count.ToString();
                _dataNoManejado.AddRange(p.ObjetosNoManejados);
                _dataIgnorado.AddRange(p.ObjetosIgnorados);
            }
            catch (System.MissingMethodException e1)
            {
                MessageBox.Show(e1.Message);
            }
            catch (IOException e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void cmbNombreFormulario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNombreFormulario.SelectedIndex == -1)
                return;

            if (cmbNombreFormulario.SelectedValue == null)
                return;

            var tcode = (FormsInProject.FormStructureReturn)cmbNombreFormulario.SelectedItem;

            var tx = new TcodeManager().GetTcodeDataFromFormName(tcode.Name, tcode.Namespace);
            if (tx != null)
            {
                txtTcode.Text = tx.TCode;
                txtCantidadParametros.Text = tx.NumberOfParameters.ToString();
                txtTcodeDescription.Text = tx.Description;
            }
        }

        private void FrmApp02ControlsInForms_Load(object sender, EventArgs e)
        {
            var lx = new FormsInProject().GetAllFormsInProject();
            cmbNombreFormulario.DataSource = lx;
            cmbNombreFormulario.DisplayMember = "Name";
            cmbNombreFormulario.ValueMember = "FullName";
            cmbNombreFormulario.SelectedIndex = -1;
            ConfiguraDgv2();
        }

        public void ConfiguraDgv2()
        {
            int cantidadColumnas = 2;
            dgvListaTexto.AutoGenerateColumns = false;
            dgvListaTexto.ColumnHeadersVisible = true;
            DataGridViewTextBoxColumn[] columna = new DataGridViewTextBoxColumn[cantidadColumnas];
            for (int i = 0; i < cantidadColumnas; i++)
            {
                columna[i] = new DataGridViewTextBoxColumn();
            }
            //Configuracion de Columnas
            columna[0].Name = "ControlName";
            columna[0].DataPropertyName = "ControlName";
            columna[0].ReadOnly = true;

            columna[1].Name = "ControlType";
            columna[1].DataPropertyName = "ControlType";
            columna[1].ReadOnly = true;

            //Agregado de Columnas
            dgvListaTexto.Columns.Add(columna[0]);
            dgvListaTexto.Columns[0].Width = 180;

            dgvListaTexto.Columns.Add(columna[1]);
            dgvListaTexto.Columns[0].Width = 70;
        }

        private void btnVerIgnorado_Click(object sender, EventArgs e)
        {
            dgvListaTexto.DataSource = _dataIgnorado.ToList();

            //.Select(arr => new { Controles = arr[0].ToString(),Tipo = arr[1].ToString()})
            //.ToList();
        }

        private void btnVerNoManejado_Click(object sender, EventArgs e)
        {
            dgvListaTexto.DataSource = _dataNoManejado.ToList();

            //.Select(arr => new { Controles = arr[0].ToString() ,Tipo=arr[1].ToString()})
            //.ToList();
        }
    }
}
