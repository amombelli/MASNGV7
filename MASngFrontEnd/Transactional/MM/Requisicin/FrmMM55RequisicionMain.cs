using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MASngFE.Transactional.MM.Orden_de_Compra;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.Transactional.MM;

namespace MASngFE.Transactional.MM.Requisicin
{
    public partial class FrmMM55RequisicionMain : Form
    {
        private int _idRc;
        private RcStatusManagement.Status _statusRc;
        public FrmMM55RequisicionMain()
        {
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("RC1", "RC1"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios", @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            InitializeComponent();
            this.cmbVendor.SelectedIndexChanged -= new System.EventHandler(this.cmbVendor_SelectedIndexChanged);
            this.ckOnlyAprovedVendors.CheckedChanged -= new System.EventHandler(this.ckOnlyAprovedVendors_CheckedChanged);

            txtFechaRc.Text = DateTime.Today.ToString("d");
            txtSolicitadoPor.Text = GlobalApp.AppUsername;
            txtStatusRc.Text = RcStatusManagement.Status.Inicial.ToString();
            txtNumeroOC.Text = null;
            _statusRc = RcStatusManagement.Status.Inicial;
            _idRc = 0;
            cmbVendor.DataSource = new VendorManager().GetListVendorByVendorType("DIRECTOS", true);
            ckOnlyAprovedVendors.Checked = true;
            cmbVendor.SelectedIndex = -1;
            this.cmbVendor.SelectedIndexChanged += new System.EventHandler(this.cmbVendor_SelectedIndexChanged);
            this.ckOnlyAprovedVendors.CheckedChanged += new System.EventHandler(this.ckOnlyAprovedVendors_CheckedChanged);

        }
        public FrmMM55RequisicionMain(int idRc)
        {
            _idRc = idRc;
            InitializeComponent();
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("RC3", "RC3"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios", @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
        private void AccionSegunStatus()
        {
            this.cmbVendor.SelectedIndexChanged -= new System.EventHandler(this.cmbVendor_SelectedIndexChanged);
            this.ckOnlyAprovedVendors.CheckedChanged -= new System.EventHandler(this.ckOnlyAprovedVendors_CheckedChanged);

            btnGenerarRc.Enabled = false;
            btnAutorizarRc.Enabled = false;
            btnCancelarRc.Enabled = false;
            btnVerOC.Enabled = false;
            btnNewOC.Enabled = false;
            btnAsignarProveedor.Enabled = false;
            btnDesAsignarVendor.Enabled = false;
            cmbMaterial.Enabled = false;
            cKgConteo.XReadOnly = true;
            cKgRequisicion.XReadOnly = true;
            txtComentarioRc.ReadOnly = true;
            txtComentarioRc.BackColor = Color.LightGray;
            txtComentarioOc.ReadOnly = true;
            txtComentarioOc.BackColor = Color.LightGray;
            ckOnlyAprovedVendors.Enabled = false;
            cmbVendor.Enabled = false;

            switch (_statusRc)
            {
                case RcStatusManagement.Status.Inicial:
                    btnGenerarRc.Enabled = true;
                    cmbMaterial.Enabled = true;
                    cKgRequisicion.XReadOnly = false;
                    ckConteo.Enabled = true;
                    cKgRequisicion.XReadOnly = false;
                    txtComentarioRc.ReadOnly = false;
                    txtComentarioRc.BackColor = Color.White;
                    break;
                case RcStatusManagement.Status.Cancelado:
                    break;
                case RcStatusManagement.Status.RCGenerada:
                    btnAutorizarRc.Enabled = true;
                    btnCancelarRc.Enabled = true;
                    txtComentarioOc.ReadOnly = false;
                    txtComentarioOc.BackColor = Color.White;
                    if (string.IsNullOrEmpty(txtVendorId.Text))
                    {
                        ckOnlyAprovedVendors.Enabled = true;
                        cmbVendor.Enabled = true;
                        btnDesAsignarVendor.Enabled = false;
                        btnAsignarProveedor.Enabled = true;
                    }
                    else
                    {
                        btnDesAsignarVendor.Enabled = true;
                        btnAsignarProveedor.Enabled = false;
                    }
                    cKgRequisicion.XReadOnly = false;

                    break;
                case RcStatusManagement.Status.Aprobado:
                    btnCancelarRc.Enabled = true;
                    btnNewOC.Enabled = true;
                    if (!string.IsNullOrEmpty(txtVendorId.Text))
                    {
                        btnDesAsignarVendor.Enabled = true;
                    }
                    else
                    {
                        btnAsignarProveedor.Enabled = true;
                    }


                    break;
                case RcStatusManagement.Status.OCGenerada:
                    btnVerOC.Enabled = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            this.cmbVendor.SelectedIndexChanged += new System.EventHandler(this.cmbVendor_SelectedIndexChanged);
            this.ckOnlyAprovedVendors.CheckedChanged += new System.EventHandler(this.ckOnlyAprovedVendors_CheckedChanged);

        }

        private void LoadRcData()
        {
            var dat = new RcManagement().GetRequisicion(_idRc);
            txtNumeroRc.Text = _idRc.ToString();
            txtStatusRc.Text = dat.StatusRc;
            _statusRc = RcStatusManagement.MapTextToStatus(dat.StatusRc);
            txtFechaRc.Text = dat.FechaRc.ToString("d");
            txtSolicitadoPor.Text = dat.UserRc;
            txtRcAprobada.Text = dat.AproboOC;
            txtFechaAprobacionRc.Text = dat.FechaAproboOC.ToString();

            cmbMaterial.SelectedItem = dat.Material;
            var matdata = new MaterialMasterManager().GetPrimarioInfo(dat.Material);
            txtMaterialDescripcion.Text = matdata.MAT_DESC;
            txtStockMinimo.Text = matdata.StockMinimo.ToString();
            txtKgStockAuto.Text = new StockAvilability().TotalStockInPlant(dat.Material).ToString("N2");

            if (dat.KgStockRevisado != null)
            {
                cKgConteo.SetValue = dat.KgStockRevisado.Value;
                ckConteo.Value = true;
            }
            else
            {
                cKgConteo.SetValue = 0;
                ckConteo.Value = false;
            }

            cKgRequisicion.SetValue = dat.KgRequeridos;
            txtComentarioRc.Text = dat.ComentarioRc;

            if (dat.ProveedorElegido != null)
            {
                ckOnlyAprovedVendors.Checked = false;
                cmbVendor.DataSource = new VendorManager().GetListVendorByVendorType("DIRECTOS", false);
                txtVendorId.Text = dat.ProveedorElegido.ToString();
                cmbVendor.SelectedValue = Convert.ToInt32(dat.ProveedorElegido.Value);
                //      cmbVendor.SelectedValue = 143;
            }

            if (dat.NumeroOC == null || dat.NumeroOC == 0)
            {
                //no existe OC aun
            }
            else
            {
                //carga datos de OC
                txtNumeroOC.Text = dat.NumeroOC.ToString();
                txtItemOC.Text = dat.ItemOC.ToString();
                var oc = new OrdenCompraManager().GetDataOcHeader(dat.NumeroOC.Value);
                txtStatusOC.Text = oc.STATUSOC;
                txtFechaOC.Text = oc.FECHAOC.Value.ToString("g");
                txtComentarioOc.Text = dat.CometarioOC;
            }
        }

        private void FrmMM55RequisicionMain_Load(object sender, EventArgs e)
        {
            this.cmbMaterial.SelectedIndexChanged -= new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            BindingSource bs = new BindingSource();
            bs.DataSource = MaterialMasterManager.GetCompraMaterialList(true);
            cmbMaterial.DataSource = bs;
            cmbMaterial.SelectedIndex = -1;

            if (_idRc > 0)
            {
                LoadRcData();
            }
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            AccionSegunStatus();
            //this.cmbVendor.SelectedIndexChanged += new System.EventHandler(this.cmbVendor_SelectedIndexChanged);
            //this.ckOnlyAprovedVendors.CheckedChanged += new System.EventHandler(this.ckOnlyAprovedVendors_CheckedChanged);

        }
        private void btnGenerarRc_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show(@"Debe completar el Material Requerido", @"Datos Incompletos", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (cKgRequisicion.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Debe proveer una sugerencia de Kg a Comprar", @"Datos Incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var resp = MessageBox.Show(@"Confirma la generacion de la Requisicion de Compra (RC)?",
                @"Confirmacion de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.No)
                return;

            decimal? kgconteo = null;
            if (ckConteo.Value == true)
            {
                kgconteo = cKgConteo.GetValueDecimal;
            }

            var idx = new RcManagement().CreateNewRc(cmbMaterial.SelectedValue.ToString(), kgconteo, cKgRequisicion.GetValueDecimal,
                txtComentarioRc.Text);

            txtNumeroRc.Text = idx.ToString();
            _statusRc = RcStatusManagement.Status.RCGenerada;
            txtStatusRc.Text = _statusRc.ToString();
            _idRc = idx;
            AccionSegunStatus();
            if (ckOnlyAprovedVendors.Checked && cmbVendor.Enabled)
            {
                cmbVendor.DataSource =
                    new VendorInfoRecordManager().GetVendorListForMaterial(cmbMaterial.SelectedValue.ToString());

            }

        }
        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtMaterialDescripcion.Text = null;
                txtKgStockAuto.Text = null;
                txtStockMinimo.Text = null;
                cKgConteo.SetValue = 0;

                return;
            }

            var matdata = new MaterialMasterManager().GetPrimarioInfo(cmbMaterial.SelectedValue.ToString());
            txtMaterialDescripcion.Text = matdata.MAT_DESC;
            txtStockMinimo.Text = matdata.StockMinimo.ToString();
            txtKgStockAuto.Text = new StockAvilability().AvailableStockForProduccion(matdata.IDMATERIAL, "CERR")
                .ToString("N2");

            if (ckOnlyAprovedVendors.Checked && cmbVendor.Enabled)
            {
                cmbVendor.DataSource =
                    new VendorInfoRecordManager().GetVendorListForMaterial(cmbMaterial.SelectedValue.ToString());
            }
        }
        private void cmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null && combo.Text != string.Empty)
                e.Cancel = true;
        }
        private void btnCancelarRc_Click(object sender, EventArgs e)
        {
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("RC1", "RCCANCELA"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para cancelar una RC", @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resp = MessageBox.Show(@"Confirma la cancelacion de esta RC?", @"Cancelar RC", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;

            new RcStatusManagement().SetCancelado(_idRc);
            txtStatusRc.Text = RcStatusManagement.Status.Cancelado.ToString();
            _statusRc = RcStatusManagement.Status.Cancelado;
            AccionSegunStatus();
        }
        private void btnAutorizarOC_Click(object sender, EventArgs e)
        {
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("RC1", "RCAPRUEBA"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para autorizar una RC", @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cKgRequisicion.GetValueDecimal <= 0)
            {
                MessageBox.Show(@"Para Aprobar una RC debe Establecer los KG a Comprar", @"Datos Incorectos", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int? vendorId;
            if (cmbVendor.SelectedValue == null)
            {
                var resp = MessageBox.Show(@"Confirma la Aprobacion de la RC sin asignacion de Proveedor?",
                    @"Proveedor No Seleccionado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;
                vendorId = null;
            }
            else
            {
                vendorId = Convert.ToInt32(cmbVendor.SelectedValue);
            }
            new RcStatusManagement().SetRcAprobada(_idRc, txtComentarioOc.Text, cKgRequisicion.GetValueDecimal, vendorId);

            MessageBox.Show($@"La Requisicion numero {_idRc} se ha Aprobado" + Environment.NewLine + @"Puede Generar la OC", @"RC Aprobada",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            _statusRc = RcStatusManagement.Status.Aprobado;
            txtStatusRc.Text = _statusRc.ToString();
            txtFechaAprobacionRc.Text = DateTime.Now.ToString("g");
            txtRcAprobada.Text = GlobalApp.AppUsername;
            AccionSegunStatus();
        }
        private void cmbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVendor.SelectedIndex == -1)
            {
                txtVendorId.Text = null;
                btnDesAsignarVendor.Enabled = false;
                return;
            }
            txtVendorId.Text = cmbVendor.SelectedValue.ToString();
            //new RcStatusManagement().AsignarVendor(_idRc, Convert.ToInt32(cmbVendor.SelectedValue));
            btnDesAsignarVendor.Enabled = true;
        }
        private void cmbVendor_Validating(object sender, CancelEventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedValue == null && combo.Text.Length != 0)
                e.Cancel = true;

            if (combo.Text.Length == 0)
                txtVendorId.Text = null;
        }
        private void ckOnlyAprovedVendors_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOnlyAprovedVendors.Checked)
            {
                if (cmbMaterial.SelectedValue == null)
                {
                    MessageBox.Show(@"Debe Seleccionar un Material", @"Material no disponible", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ckOnlyAprovedVendors.Checked = false;
                }
                else
                {
                    cmbVendor.DataSource =
                        new VendorInfoRecordManager().GetVendorListForMaterial(cmbMaterial.SelectedValue.ToString());
                }
            }
            else
            {
                cmbVendor.DataSource = new VendorManager().GetListVendorByVendorType("DIRECTOS", true);
            }
            cmbVendor.SelectedIndex = -1;
            new RcStatusManagement().AsignarVendor(_idRc, null);
        }
        private void btnNewOC_Click(object sender, EventArgs e)
        {
            //check permisos
            if (!Tecser.Business.Security.TsSecurityMng.CheckifRoleIsGrantedToRun("RC1", "OC1"))
            {
                MessageBox.Show(@"El Usuario no cuenta con los permisos necesarios para Crear una OC", @"Acceso no Aprobado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbVendor.SelectedValue == null)
            {
                MessageBox.Show(@"No se ha definido un proveedor en la requisicion" + Environment.NewLine + @"No se puede crear una OC en forma automatica sin Proveedor Seleccionado", @"Proveedor No Disponible",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new FrmMM21DatosOC(Convert.ToInt32(cmbVendor.SelectedValue), _idRc, cmbMaterial.SelectedValue.ToString(), cKgRequisicion.GetValueDecimal))
            {
                this.Close(); //cierra la OC
                f.ShowDialog();
            }
            LoadRcData();
            AccionSegunStatus();
        }
        private void cKgConteo_Validated(object sender, EventArgs e)
        {
            ckConteo.Value = cKgConteo.GetValueDecimal > 0;
        }
        private void btnAsignarProveedor_Click(object sender, EventArgs e)
        {
            cmbVendor.Enabled = true;
            ckOnlyAprovedVendors.Enabled = true;
            btnDesAsignarVendor.Enabled = true;
            btnAsignarProveedor.Enabled = false;
            if (cmbVendor.SelectedValue != null)
            {
                new RcStatusManagement().AsignarVendor(_idRc, Convert.ToInt32(cmbVendor.SelectedValue));
                MessageBox.Show(@"Proveedor Asignado Correctamente", @"RC Actualizada", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDesAsignarVenodr_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVendorId.Text))
            {
                new RcStatusManagement().AsignarVendor(_idRc, null);
                txtVendorId.Text = null;
                cmbVendor.SelectedIndex = -1;
                cmbVendor.Enabled = true;
                ckOnlyAprovedVendors.Enabled = true;
                btnAsignarProveedor.Enabled = true;
                btnDesAsignarVendor.Enabled = false;
                new RcStatusManagement().AsignarVendor(_idRc, Convert.ToInt32(cmbVendor.SelectedValue));
                MessageBox.Show(@"Proveedor DesAsignado Correctamente", @"RC Actualizada", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void btnVerOC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVendorId.Text))
            {
                MessageBox.Show(@"No Existe informacion de OC para visualizar", @"OC No Asignada", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                using (var f = new FrmMM21DatosOC(Convert.ToInt32(txtVendorId.Text), 3))
                {
                    f.ShowDialog();
                }
            }
        }
    }
}
