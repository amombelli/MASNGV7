using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tecser.Business.Tools;
using Tecser.Business.Transactional.CO;
using TecserEF.Entity;

namespace MASngFE.Transactional.FI.CustomerNCD
{
    public partial class FrmCustomerNcdEditItem : Form
    {
        public FrmCustomerNcdEditItem(List<T0301_NCD_I> lst, int idItem, string tipoLx)
        {
            _list = lst;
            _idItem = idItem;
            _tipoLx = tipoLx;
            InitializeComponent();
        }
        //----------------------------------------------------------------------------------
        public List<T0301_NCD_I> _list = new List<T0301_NCD_I>();
        private readonly int _idItem;
        private readonly string _tipoLx;
        //----------------------------------------------------------------------------------
        private void FrmCustomerNcdEditItem_Load(object sender, EventArgs e)
        {
            var item = _list.Find(c => c.IDITEM == _idItem);
            txtIdItem.Text = _idItem.ToString();
            txtItem.Text = item.ITEM;
            txtDescripcionItem.Text = item.Descripcion;
            txtCantidad.Text = item.CANT.ToString("N2");
            txtPrecioUnitario.Text = item.PUNITARIO.ToString("C2");
            txtPrecioTotal.Text = item.PTOTAL.ToString("C2");
            ckIVA.Checked = item.IVA21;
            txtPrecioIva.Text = item.PIVA.ToString("C2");
            txtGL.Text = item.GL;
            txtGLDescription.Text = GLAccountManagement.GetGLDescriptionFromT135(item.GL);
            txtIdCheque.Text = item.IDCHE.ToString();
            if (_tipoLx == "L2")
            {
                ckIVA.Enabled = false;
                txtPrecioIva.Enabled = false;
                txtPrecioIva.Text = 0.ToString("C2");
            }
        }
        private void MapFormToItem()
        {
            var item = _list.Find(c => c.IDITEM == _idItem);
            item.CANT = Convert.ToDecimal(txtCantidad.Text);
            item.Descripcion = txtDescripcionItem.Text;
            item.PUNITARIO = FormatAndConversions.CCurrencyADecimal(txtPrecioUnitario.Text);
            item.PTOTAL = FormatAndConversions.CCurrencyADecimal(txtPrecioTotal.Text);
            item.IVA21 = ckIVA.Checked;
            item.PIVA = FormatAndConversions.CCurrencyADecimal(txtPrecioIva.Text);
            item.GL = txtGL.Text;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
            return;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MapFormToItem();
            this.Close();
            this.DialogResult = DialogResult.OK;
            return;
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormatAndConversions.SoloDecimalKeyPress(sender, e);
        }
        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            txtPrecioTotal.Text =
                (new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioUnitario.Text) *
                 Convert.ToDecimal(txtCantidad.Text)).ToString("C2");
            if (ckIVA.Checked)
            {
                txtPrecioIva.Text =
                    (new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioUnitario.Text) * (decimal)0.21)
                        .ToString("C2");
            }
            else
            {
                txtPrecioIva.Text = 0.ToString("C2");
            }
            txtCantidad.Text = Convert.ToDecimal(txtCantidad.Text).ToString("N2");
        }
        private void ckIVA_CheckedChanged(object sender, EventArgs e)
        {
            if (ckIVA.Checked)
            {
                txtPrecioIva.Text =
                    (new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioUnitario.Text) * (decimal)0.21)
                        .ToString("C2");
            }
            else
            {
                txtPrecioIva.Text = 0.ToString("C2");
            }
        }
        private void txtPrecioUnitario_Leave(object sender, EventArgs e)
        {
            txtPrecioTotal.Text =
               (new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioUnitario.Text) *
                Convert.ToDecimal(txtCantidad.Text)).ToString("C2");
            if (ckIVA.Checked)
            {
                txtPrecioIva.Text =
                    (new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioUnitario.Text) * (decimal)0.21)
                        .ToString("C2");
            }
            else
            {
                txtPrecioIva.Text = 0.ToString("C2");
            }

            txtPrecioUnitario.Text =
                new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioUnitario.Text).ToString("C2");
        }
        private void txtPrecioIva_Leave(object sender, EventArgs e)
        {
            txtPrecioIva.Text =
               new FormatAndConversions().GetCurrencyFormat_Decimal(txtPrecioIva.Text).ToString("C2");
        }
    }
}
