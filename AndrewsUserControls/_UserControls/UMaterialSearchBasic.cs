using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace MASngFE._UserControls
{
    public partial class UMaterialSearchBasic : UserControl
    {
        public UMaterialSearchBasic()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------------------------------------
        public string PrimarioSeleccionado;
        public List<T0010_MATERIALES> ListaPrimario = new List<T0010_MATERIALES>();
        public List<T0011_MATERIALES_AKA> ListaAKA = new List<T0011_MATERIALES_AKA>();
        //---------------------------------------------------------------------------------------------------

        public void InicializaUc(bool ckHabilitado = true, bool ckValue = false, Color colorPanel = default(Color))
        {
            ckSoloActivos.Enabled = ckHabilitado;
            ckSoloActivos.Checked = ckValue;
            ListaPrimario = new MaterialMasterManager().GetCompleteListofMaterial(ckSoloActivos.Checked);
            ListaAKA = new MaterialMasterManager().GetCompleteListofAka(ckSoloActivos.Checked);

            T0010MatBs.DataSource = ListaPrimario;
            T0011AKABs.DataSource = ListaAKA;
            T0012TipoBs.DataSource = new TecserData().T0012_TIPO_MATERIAL.ToList();
                      
            BlanqueaSeleccion();
            //panel1.BackColor = colorPanel;
        }

        private void BlanqueaSeleccion()
        {
            txtPrimarioDesc.Text = null;
            txtTipoPrimario.Text = null;
            txtAkaDescription.Text = null;
            txtTipoAka.Text = null;
            
        }

        private void cmbPrimario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivaSelecterdIndex(false);
            if (cmbPrimario.SelectedIndex == -1)
            {
                cmbAka.SelectedIndex = -1;
                T0010Dgv.DataSource = ListaPrimario.Where(c => c.IDMATERIAL == null).ToList();
                PrimarioSeleccionado = null;
                txtTipoPrimario.Text = null;
                ActivaSelecterdIndex(true);
                return;
            }
            //
            PrimarioSeleccionado = cmbPrimario.SelectedValue.ToString();
            cmbAka.SelectedValue = cmbPrimario.SelectedValue;
            T0010Dgv.DataSource = ListaPrimario.Where(c => c.IDMATERIAL == PrimarioSeleccionado).ToList();
            var data = (T0010_MATERIALES)cmbPrimario.SelectedItem;
            txtPrimarioDesc.Text = data.MAT_DESC;
            txtTipoPrimario.Text = data.TIPO_MATERIAL;

            var dataA = (T0011_MATERIALES_AKA)cmbAka.SelectedItem;
            if (dataA == null)
            {
                txtAkaDescription.Text = null;
                txtTipoAka.Text = null;
            }
            else
            {
                txtAkaDescription.Text = dataA.MAT_DESC2;
                txtTipoAka.Text = dataA.TIPO_MATERIAL;
            }
            cmbTipo.SelectedValue = data.TIPO_MATERIAL;
            var dataT = (T0012_TIPO_MATERIAL)cmbTipo.SelectedItem;
            txtTipoDescription.Text = dataT.DESCRIPCION;
            ActivaSelecterdIndex(true);
        }
        private void cmbAka_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivaSelecterdIndex(false);
            if (cmbAka.SelectedIndex == -1)
            {
                txtAkaDescription.Text = null;
                txtTipoAka.Text = null;
                cmbTipo.SelectedIndex = -1;
                cmbPrimario.SelectedIndex = -1;
                txtTipoPrimario.Text = null;
                txtPrimarioDesc.Text = null;
                T0010Dgv.DataSource = ListaPrimario.Where(c => c.IDMATERIAL == null).ToList();
                PrimarioSeleccionado = null;
                ActivaSelecterdIndex(true);
                return;
            }
            //
            var dataA = (T0011_MATERIALES_AKA)cmbAka.SelectedItem;
            txtAkaDescription.Text = dataA.MAT_DESC2;
            txtTipoAka.Text = dataA.TIPO_MATERIAL;

            cmbPrimario.SelectedValue = dataA.PRIMARIO;
            PrimarioSeleccionado = dataA.PRIMARIO;
            T0010Dgv.DataSource = ListaPrimario.Where(c => c.IDMATERIAL == PrimarioSeleccionado).ToList();

            var dataP = (T0010_MATERIALES) cmbPrimario.SelectedItem;
            txtPrimarioDesc.Text = dataP.MAT_DESC;
            txtTipoPrimario.Text = dataP.TIPO_MATERIAL;

            cmbTipo.SelectedValue = dataP.TIPO_MATERIAL;
            var dataT = (T0012_TIPO_MATERIAL) cmbTipo.SelectedItem;
            txtTipoDescription.Text = dataT.DESCRIPCION;

            ActivaSelecterdIndex(true);
        }
        private void ActivaSelecterdIndex(bool activa)
        {
            if (activa)
            {
                this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
                this.cmbPrimario.SelectedIndexChanged += new System.EventHandler(this.cmbPrimario_SelectedIndexChanged);
                this.cmbAka.SelectedIndexChanged += new System.EventHandler(this.cmbAka_SelectedIndexChanged);
            }
            else
            {
                this.cmbTipo.SelectedIndexChanged -= new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
                this.cmbPrimario.SelectedIndexChanged -= new System.EventHandler(this.cmbPrimario_SelectedIndexChanged);
                this.cmbAka.SelectedIndexChanged -= new System.EventHandler(this.cmbAka_SelectedIndexChanged);
            }
        }
        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivaSelecterdIndex(false);
            if (cmbTipo.SelectedIndex == -1)
            {
                T0010Dgv.DataSource = ListaPrimario.Where(c => c.IDMATERIAL == null).ToList();
            }
            else
            {
                cmbPrimario.SelectedIndex = -1;
                cmbAka.SelectedIndex = -1;
                txtPrimarioDesc.Text = null;
                txtAkaDescription.Text = null;
                txtTipoPrimario.Text = null;
                txtTipoAka.Text = null;
                T0010Dgv.DataSource =
                    ListaPrimario.Where(c => c.TIPO_MATERIAL == cmbTipo.SelectedValue.ToString()).ToList();

                var dataT = (T0012_TIPO_MATERIAL)cmbTipo.SelectedItem;
                txtTipoDescription.Text = dataT.DESCRIPCION;

            }
            ActivaSelecterdIndex(true);
        }
        private void ckSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            ListaPrimario = new MaterialMasterManager().GetCompleteListofMaterial(ckSoloActivos.Checked);
            ListaAKA = new MaterialMasterManager().GetCompleteListofAka(ckSoloActivos.Checked); 
        }
        private void cmbPrimario_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
            }
        }
        private void cmbPrimario_KeyUp(object sender, KeyEventArgs e)
       {
            if (cmbPrimario.SelectedIndex == -1)
            {
                PrimarioSeleccionado = null;
                T0010Dgv.DataSource = ListaPrimario.Where(c => c.IDMATERIAL.Contains(cmbPrimario.Text)).ToList();
                BlanqueaSeleccion();
            }
        }

        private void cmbAka_TextUpdate(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (string.IsNullOrEmpty(combo.Text))
            {
                BlanqueaSeleccion();
            }
        }

        private void cmbAka_KeyUp(object sender, KeyEventArgs e)
        {
            //if (cmbAka.SelectedIndex == -1)
            //{
            //    PrimarioSeleccionado = null;
            //    T0010Dgv.DataSource = ListaPrimario.Where(c => c.IDMATERIAL.Contains(cmbPrimario.Text)).ToList();
            //    BlanqueaSeleccion();
            //}
        }
    }
}