using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tecser.Business.MasterData.Vendor_Master;
using TSControls;

namespace MASngFE._0TSUserControls
{
    public partial class TsUcVendorSelector : UserControl
    {
        public delegate void ClienteModificadoEventHandler(object source, VendorSearchUcArgs args);
        public event ClienteModificadoEventHandler VendorUpdated;
        private int? _idVendor;
        private Color _colorLineaContorno = Color.Navy;
        private Color _colorFondoControl = Color.White;
        public int? VendorId
        {
            get => _idVendor;
            set
            {
                _idVendor = value;
                if (value == null || value < 1)
                {
                    cmbRazonSocial.SelectedIndex = -1;
                }
                else
                {
                    cmbRazonSocial.SelectedValue = value;
                }
            }
        }
        public TsUcVendorSelector()
        {
            InitializeComponent();
        }
        private void TsUcVendorSelector_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.ckBusquedaLibre.CheckedChanged -= new System.EventHandler(this.ckBusquedaLibre_CheckedChanged);
                //
                ctlVendorOk.Set = CIconos.Equis;
                ckSoloClientesActivos.Checked = true;
                ckBusquedaLibre.Checked = false;
                txtChar.SetValue = 4;
                cmbRazonSocial.SelectedIndex = -1;
                cmbFantasia.SelectedIndex = -1;
                ctlVendorOk.Set = CIconos.Equis;
                //
                this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
                this.ckBusquedaLibre.CheckedChanged += new System.EventHandler(this.ckBusquedaLibre_CheckedChanged);
            }

            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {

            }
        }
        private void OnVendorUpdated()
        {
            if (VendorUpdated == null) return;
            if (_idVendor < 1)
            {
                VendorUpdated(this, new VendorSearchUcArgs()
                {
                    VendorId = -1,
                    RazonSocial = null,
                    Fantasia = null,
                    Cuit = null,
                    Tipo = null,
                });
            }
            else
            {
                VendorUpdated(this, new VendorSearchUcArgs()
                {
                    VendorId = _idVendor,
                    RazonSocial = cmbRazonSocial.Text,
                    Fantasia = cmbFantasia.Text,
                    Cuit = txtCuit.Text,
                    Tipo = txtVendorType.Text,
                });
            }
        }
        private void cmbFantasia_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null)
            {
                BlanqueaVendor();
                ctlVendorOk.Set = CIconos.Equis;
            }
            else
            {
                var data = (StxVendnorSimple)combo.SelectedItem;
                VendorId = Convert.ToInt32(combo.SelectedValue);
                txtVendorId.SetValue = VendorId.Value;
                cmbRazonSocial.SelectedValue = VendorId;
                cmbFantasia.SelectedValue = VendorId;
                txtCuit.Text = data.Cuit;
                txtVendorType.Text = data.VendorType;
                OnVendorUpdated();
                ctlVendorOk.Set = CIconos.Verde;
            }
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
        }
        private void BlanqueaVendor()
        {
            this.cmbFantasia.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.SelectedIndexChanged -= new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            VendorId = -1;
            cmbRazonSocial.SelectedIndex = -1;
            cmbFantasia.SelectedIndex = -1;
            txtVendorId.SetValue = 0;
            txtVendorId.Text = null;
            txtCuit.Text = null;
            OnVendorUpdated();

            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
        }
        private void cmbFantasia_TextUpdate(object sender, EventArgs e)
        {
            var data = (ComboBox)sender;
            if (string.IsNullOrEmpty(data.Text))
            {
                BlanqueaVendor();
            }
            else
            {
                if (ckBusquedaLibre.Checked)
                {
                    if (data.Text.Length > (int)txtChar.GetValueDecimal && data.SelectedValue == null)
                    {
                        var parametroBusqueda = TsUcVendorFreeSearchScreen.ParametroBusquedaVendor.RazonSocial;
                        if (data.Name == nameof(cmbFantasia))
                        {
                            parametroBusqueda = TsUcVendorFreeSearchScreen.ParametroBusquedaVendor.Fantasia;
                        }
                        else
                        {
                            if (data.Name == nameof(cmbRazonSocial))
                            {
                                parametroBusqueda = TsUcVendorFreeSearchScreen.ParametroBusquedaVendor.RazonSocial;
                            }
                            else
                            {
                                //CUIT va desde TextBox-TextUpdate
                            }
                        }
                        using (var f = new TsUcVendorFreeSearchScreen(parametroBusqueda, data.Text, (int)txtChar.GetValueDecimal))
                        {
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                VendorId = f.IdVendor;
                                if (VendorId < 1)
                                {
                                    BlanqueaVendor();
                                }
                                else
                                {
                                    cmbRazonSocial.SelectedValue = VendorId;
                                }
                            }
                            else
                            {
                                //no se selecciono nada
                                BlanqueaVendor();
                                ctlVendorOk.Set = CIconos.Equis;
                            }
                        }
                    }
                }
            }
        }
        private void ckSoloClientesActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSoloClientesActivos.Checked)
            {
                ckSoloClientesActivos.ForeColor = Color.DarkGreen;
            }
            else
            {
                ckSoloClientesActivos.ForeColor = Color.DarkBlue;
            }

            var data = new VendorMng2().GetVendorList(ckSoloClientesActivos.Checked, VendorMng2.OrderBy1.RazonSocial);
            VendorBs.DataSource = data;
            cmbFantasia.DataSource = data.OrderBy(c => c.Fantasia).ToList();
        }
        private void ckBusquedaLibre_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBusquedaLibre.Checked)
            {
                cmbRazonSocial.AutoCompleteMode = AutoCompleteMode.None;
                cmbFantasia.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
            else
            {
                cmbRazonSocial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbFantasia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }
        private void btnFree_Click(object sender, EventArgs e)
        {
            using (var f = new TsUcVendorFreeSearchScreen(TsUcVendorFreeSearchScreen.ParametroBusquedaVendor.All,"", (int)txtChar.GetValueDecimal))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    VendorId = f.IdVendor;
                    if (VendorId < 1)
                    {
                        BlanqueaVendor();
                    }
                    else
                    {
                        cmbRazonSocial.SelectedValue = VendorId;
                    }
                }
                else
                {
                    //no se selecciono nada
                    BlanqueaVendor();
                    ctlVendorOk.Set = CIconos.Equis;
                }
            }
        }
        private void TsUcVendorSelector_Resize(object sender, EventArgs e)
        {
            if (this.Height != 91)
            {
                this.Height = 91;
            }

            if (this.Width < 577)
            {
                this.Width = 577;
            }
            lineUp.Size = new Size(this.Width, 2);
            lineDown.Size = new Size(this.Width, 2);
            lineD.Location = new Point(this.Width - 2, 0);
        }
    }
    public class VendorSearchUcArgs : EventArgs
    {
        public int? VendorId;
        public string RazonSocial;
        public string Fantasia;
        public string Cuit;
        public string Tipo;
    }
}
