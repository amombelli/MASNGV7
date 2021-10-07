using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.SuperMD;
using Tecser.Business.Tools;
using TecserEF.Entity.DataStructure;

namespace MASngFE.Forms.MaterialSearchBase
{
    public partial class FrmMaterialMasterSearchBase : Form
    {
        public FrmMaterialMasterSearchBase()
        {
            InitializeComponent();
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        private List<CompleteMaterialList.SimpleMaterialList> _materiales = new List<CompleteMaterialList.SimpleMaterialList>();

        //------------------------------------------------------------------------------------------------------------------------------------

        private void FrmMaterialMasterSearchBase_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                //do connection stuff here
                rbPrimario.Checked = true;
                ckSoloActivos.Checked = true;

                BsTipoMaterial.DataSource = new MaterialTypeManager().GetListMtype();
                cmbTipoMaterial.SelectedIndex = -1;

                _materiales.AddRange(new CompleteMaterialList().GetData(CompleteMaterialList.TablaFrom.Primario, GlobalApp.CnnApp, true));
                this.ckSoloActivos.CheckedChanged += new System.EventHandler(this.ckSoloActivos_CheckedChanged);
                this.rbPrimario.CheckedChanged += new System.EventHandler(this.rbPrimario_CheckedChanged);
                this.rbAKA.CheckedChanged += new System.EventHandler(this.rbPrimario_CheckedChanged);
                materialListBs.DataSource = _materiales;
            }
        }

        private void ckSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrimario.Checked)
            {
                _materiales.Clear();
                _materiales.AddRange(new CompleteMaterialList().GetData(CompleteMaterialList.TablaFrom.Primario, GlobalApp.CnnApp, ckSoloActivos.Checked));
            }
            else
            {
                //busqueda por AKA
                _materiales.Clear();
                _materiales.AddRange(new CompleteMaterialList().GetData(CompleteMaterialList.TablaFrom.AKA, GlobalApp.CnnApp,
                    ckSoloActivos.Checked));
            }
            Cursor.Current = Cursors.WaitCursor;
            materialListBs.DataSource = _materiales;
            materialListBs.ResetBindings(true);
            Cursor.Current = Cursors.Default;
        }

        private void rbPrimario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrimario.Checked)
            {
                _materiales.Clear();
                _materiales.AddRange(new CompleteMaterialList().GetData(CompleteMaterialList.TablaFrom.Primario, GlobalApp.CnnApp, ckSoloActivos.Checked));
            }
            else
            {
                //busqueda por AKA
                _materiales.Clear();
                _materiales.AddRange(new CompleteMaterialList().GetData(CompleteMaterialList.TablaFrom.AKA, GlobalApp.CnnApp,
                    ckSoloActivos.Checked));
            }

            Cursor.Current = Cursors.WaitCursor;
            materialListBs.DataSource = _materiales;
            materialListBs.ResetBindings(true);
            Cursor.Current = Cursors.Default;
        }

        private void cmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = rbBusqExacta.Checked && Validaciones.CheckCmb(cmbMaterial);

            if (cmbMaterial.SelectedValue == null)
            {
                txtDescripcionMaterial.Text = null;
                cmbTipoMaterial.SelectedIndex = -1;
            }

        }

        private void rbBusqExacta_CheckedChanged(object sender, EventArgs e)
        {
            cmbMaterial.SelectedIndex = -1;
        }

        private void cmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedIndex == -1)
            {
                txtDescripcionMaterial.Text = null;
            }
            else
            {
                var materialData = _materiales.Find(c => c.Item == cmbMaterial.SelectedValue.ToString());


                txtDescripcionMaterial.Text = materialData.Descripcion;
                cmbTipoMaterial.SelectedValue = materialData.Tipo;
            }
        }

        private void cmbTipoMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoMaterial.SelectedIndex == -1)
            {
                txtDescripcionTipoMaterial.Text = null;
            }
            else
            {
                txtDescripcionTipoMaterial.Text = cmbTipoMaterial.SelectedValue.ToString();
            }
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
