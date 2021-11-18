using System;
using System.Windows.Forms;
using Tecser.Business.Transactional.FI.TaxModule;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.TaxModule
{
    public partial class FrmFI13TaxConfig : Form
    {
        public FrmFI13TaxConfig()
        {
            InitializeComponent();
        }
        private bool _validacionOK;
        private int _modo;

        private void FrmFI13TaxConfig_Load(object sender, EventArgs e)
        {
            dgv1.DataSource = new TaxModuleManager().GetListaTax();
            BlankData();
            btnGrabar.Enabled = false;
            btnEdit.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void dgv1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            panelData.Enabled = false;
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex < 0)
            {
                txtIdTax.Text = null;
                txtDescripcion.Text = null;
                cAlicuota.SetValue = 0;
                ckCliente.Checked = false;
                ckProveedor.Checked = false;
                btnGrabar.Enabled = false;
                btnEdit.Enabled = false;
                btnNuevo.Enabled = true;
                return;
            }
            txtIdTax.Text = dgv[__idtax.Name, e.RowIndex].Value.ToString();
            txtDescripcion.Text = dgv[__descripcion.Name, e.RowIndex].Value.ToString();
            cAlicuota.SetValue = Convert.ToDecimal(dgv[__alicuota.Name, e.RowIndex].Value);
            var x = dgv[__modulo.Name, e.RowIndex].Value.ToString();
            if (x.Contains("P"))
                ckProveedor.Checked = true;
            if (x.Contains("C"))
                ckCliente.Checked = true;

            btnEdit.Enabled = true;
            btnGrabar.Enabled = false;
            btnNuevo.Enabled = true;

        }

        private void BlankData()
        {
            dgv1.ClearSelection();
            txtIdTax.Text = null;
            txtDescripcion.Text = null;
            cAlicuota.SetValue = 0;
            ckCliente.Checked = false;
            ckProveedor.Checked = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BlankData();
            panelData.Enabled = true;
            btnNuevo.Enabled = false;
            btnEdit.Enabled = false;
            btnGrabar.Enabled = true;
            _modo = 1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panelData.Enabled = true;
            btnNuevo.Enabled = true;
            btnEdit.Enabled = false;
            btnGrabar.Enabled = true;
            _modo = 2;

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidaOK() == false)
            {
                return;
            }

            var data1 = new T0016_TaxModuleDefinition()
            {
                IdTax = txtIdTax.Text.ToUpper(),
                Alicuota = cAlicuota.GetValueDecimal,
                TaxDescription = txtDescripcion.Text
            };
            string xx;
            if (ckCliente.Checked && ckProveedor.Checked)
            {
                xx = "CP";
            }
            else
            {
                if (ckCliente.Checked)
                {
                    xx = "C";
                }
                else
                {
                    xx = "P";
                }
            }
            data1.ModuloAplica = xx;
            new TaxModuleManager().SaveData(data1);
            _modo = 3;
            panelData.Enabled = false;
            btnNuevo.Enabled = true;
            btnGrabar.Enabled = false;
            btnEdit.Enabled = false;
            dgv1.DataSource = new TaxModuleManager().GetListaTax();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ValidaOK()
        {
            _validacionOK = true;
            xep(txtIdTax);
            xep(txtDescripcion);
            xep(cAlicuota);

            if (string.IsNullOrEmpty(txtIdTax.Text))
                xep(txtIdTax, "Debe proveer un identificador de TAX [20]");

            if (string.IsNullOrEmpty(txtDescripcion.Text))
                xep(txtDescripcion, "Debe proveer una Descripcion para el Impuesto");

            if (ckProveedor.Checked == false && ckCliente.Checked == false)
            {
                xep(ckCliente, "Debe Seleccionar algun modulo para asignar este impuesto");
                xep(ckProveedor, "Debe Seleccionar algun modulo para asignar este impuesto");
            }

            if (_modo == 1 && string.IsNullOrEmpty(txtIdTax.Text) == false)
            {
                var f = new TaxModuleManager().GetTaxId(txtIdTax.Text);
                if (f != null)
                {
                    xep(txtIdTax, "El Codigo de Impuesto esta repetido - Seleccionen uno diferente");
                }
            }
            return _validacionOK;
        }


        private void xep(Control ob, string error = null, bool consideraError = true)
        {
            ep.SetError(ob, string.IsNullOrEmpty(error) ? "" : error);
            if (consideraError)
            {
                if (!string.IsNullOrEmpty(error))
                    _validacionOK = false;
            }
        }
    }
}
