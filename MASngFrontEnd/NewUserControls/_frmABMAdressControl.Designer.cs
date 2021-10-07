namespace MASngFE.NewUserControls
{
    partial class _frmABMAdressControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_frmABMAdressControl));
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPartido = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.ckAutoValidar = new System.Windows.Forms.CheckBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAlta = new System.Windows.Forms.Button();
            this.iconLocalidad = new TSControls.CtlIconos();
            this.iconPais = new TSControls.CtlIconos();
            this.iconProvincia = new TSControls.CtlIconos();
            this.iconPartido = new TSControls.CtlIconos();
            this.tvAddress = new System.Windows.Forms.TreeView();
            this.localidadBs = new System.Windows.Forms.BindingSource(this.components);
            this.partidoBs = new System.Windows.Forms.BindingSource(this.components);
            this.provinciaBs = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSugerencias = new System.Windows.Forms.DataGridView();
            this.idProvinciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPartiadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLocalidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provinciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ep1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidoBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugerencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressStructureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).BeginInit();
            this.SuspendLayout();
            // 
            // tt
            // 
            this.tt.AutoPopDelay = 1500;
            this.tt.InitialDelay = 500;
            this.tt.ReshowDelay = 100;
            this.tt.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.tt.ToolTipTitle = "Datos Incorrectos";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Crimson;
            this.label6.Location = new System.Drawing.Point(5, 644);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(731, 3);
            this.label6.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Pais";
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(91, 6);
            this.txtPais.MaxLength = 2;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(28, 21);
            this.txtPais.TabIndex = 18;
            this.txtPais.Text = "AR";
            this.txtPais.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPais.TextChanged += new System.EventHandler(this.txtPais_TextChanged);
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(91, 28);
            this.txtProvincia.MaxLength = 50;
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(154, 21);
            this.txtProvincia.TabIndex = 177;
            this.txtProvincia.TextChanged += new System.EventHandler(this.txtProvincia_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 178;
            this.label9.Text = "Provincia";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 15);
            this.label10.TabIndex = 180;
            this.label10.Text = "Partido";
            // 
            // txtPartido
            // 
            this.txtPartido.Location = new System.Drawing.Point(91, 50);
            this.txtPartido.MaxLength = 50;
            this.txtPartido.Name = "txtPartido";
            this.txtPartido.Size = new System.Drawing.Size(154, 21);
            this.txtPartido.TabIndex = 179;
            this.txtPartido.TextChanged += new System.EventHandler(this.txtPartido_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 15);
            this.label11.TabIndex = 182;
            this.label11.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(91, 72);
            this.txtLocalidad.MaxLength = 50;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(256, 21);
            this.txtLocalidad.TabIndex = 181;
            this.txtLocalidad.TextChanged += new System.EventHandler(this.txtLocalidad_TextChanged);
            // 
            // ckAutoValidar
            // 
            this.ckAutoValidar.AutoSize = true;
            this.ckAutoValidar.Location = new System.Drawing.Point(782, 322);
            this.ckAutoValidar.Name = "ckAutoValidar";
            this.ckAutoValidar.Size = new System.Drawing.Size(91, 19);
            this.ckAutoValidar.TabIndex = 183;
            this.ckAutoValidar.Text = "Auto Validar";
            this.ckAutoValidar.UseVisualStyleBackColor = true;
            // 
            // btnValidar
            // 
            this.btnValidar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValidar.Location = new System.Drawing.Point(812, 6);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(100, 42);
            this.btnValidar.TabIndex = 184;
            this.btnValidar.Text = "Validar";
            this.btnValidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValidar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAlta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPais);
            this.panel1.Controls.Add(this.iconLocalidad);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.iconPais);
            this.panel1.Controls.Add(this.txtLocalidad);
            this.panel1.Controls.Add(this.iconProvincia);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.iconPartido);
            this.panel1.Controls.Add(this.txtPartido);
            this.panel1.Controls.Add(this.txtProvincia);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(9, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 101);
            this.panel1.TabIndex = 185;
            // 
            // btnAlta
            // 
            this.btnAlta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.Image = ((System.Drawing.Image)(resources.GetObject("btnAlta.Image")));
            this.btnAlta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlta.Location = new System.Drawing.Point(328, 2);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(100, 42);
            this.btnAlta.TabIndex = 188;
            this.btnAlta.Text = "Alta";
            this.btnAlta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // iconLocalidad
            // 
            this.iconLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconLocalidad.IconLocation = TSControls.UbicacionIcono.Normal;
            this.iconLocalidad.IconSize = TSControls.TamañoIcono.Chico;
            this.iconLocalidad.Location = new System.Drawing.Point(71, 73);
            this.iconLocalidad.Name = "iconLocalidad";
            this.iconLocalidad.Set = TSControls.CIconos.ExclamacionYellow;
            this.iconLocalidad.Size = new System.Drawing.Size(16, 18);
            this.iconLocalidad.TabIndex = 32;
            // 
            // iconPais
            // 
            this.iconPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconPais.IconLocation = TSControls.UbicacionIcono.Normal;
            this.iconPais.IconSize = TSControls.TamañoIcono.Chico;
            this.iconPais.Location = new System.Drawing.Point(71, 7);
            this.iconPais.Name = "iconPais";
            this.iconPais.Set = TSControls.CIconos.ExclamacionYellow;
            this.iconPais.Size = new System.Drawing.Size(16, 18);
            this.iconPais.TabIndex = 29;
            // 
            // iconProvincia
            // 
            this.iconProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconProvincia.IconLocation = TSControls.UbicacionIcono.Normal;
            this.iconProvincia.IconSize = TSControls.TamañoIcono.Chico;
            this.iconProvincia.Location = new System.Drawing.Point(71, 29);
            this.iconProvincia.Name = "iconProvincia";
            this.iconProvincia.Set = TSControls.CIconos.ExclamacionYellow;
            this.iconProvincia.Size = new System.Drawing.Size(16, 18);
            this.iconProvincia.TabIndex = 30;
            // 
            // iconPartido
            // 
            this.iconPartido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconPartido.IconLocation = TSControls.UbicacionIcono.Normal;
            this.iconPartido.IconSize = TSControls.TamañoIcono.Chico;
            this.iconPartido.Location = new System.Drawing.Point(71, 51);
            this.iconPartido.Name = "iconPartido";
            this.iconPartido.Set = TSControls.CIconos.ExclamacionYellow;
            this.iconPartido.Size = new System.Drawing.Size(16, 18);
            this.iconPartido.TabIndex = 31;
            // 
            // tvAddress
            // 
            this.tvAddress.Location = new System.Drawing.Point(9, 112);
            this.tvAddress.Name = "tvAddress";
            this.tvAddress.Size = new System.Drawing.Size(434, 526);
            this.tvAddress.TabIndex = 186;
            // 
            // localidadBs
            // 
            this.localidadBs.DataSource = typeof(TecserEF.Entity.T0010_LOCALIDAD);
            // 
            // partidoBs
            // 
            this.partidoBs.DataSource = typeof(TecserEF.Entity.T0010_PARTIDO);
            // 
            // provinciaBs
            // 
            this.provinciaBs.DataSource = typeof(TecserEF.Entity.T0008_REGION);
            // 
            // dgvSugerencias
            // 
            this.dgvSugerencias.AllowUserToAddRows = false;
            this.dgvSugerencias.AllowUserToDeleteRows = false;
            this.dgvSugerencias.AutoGenerateColumns = false;
            this.dgvSugerencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSugerencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProvinciaDataGridViewTextBoxColumn,
            this.idPartiadoDataGridViewTextBoxColumn,
            this.idLocalidadDataGridViewTextBoxColumn,
            this.paisDataGridViewTextBoxColumn,
            this.provinciaDataGridViewTextBoxColumn,
            this.partidoDataGridViewTextBoxColumn,
            this.localidadDataGridViewTextBoxColumn});
            this.dgvSugerencias.DataSource = this.addressStructureBindingSource;
            this.dgvSugerencias.Location = new System.Drawing.Point(450, 115);
            this.dgvSugerencias.Name = "dgvSugerencias";
            this.dgvSugerencias.ReadOnly = true;
            this.dgvSugerencias.RowHeadersWidth = 20;
            this.dgvSugerencias.Size = new System.Drawing.Size(444, 150);
            this.dgvSugerencias.TabIndex = 187;
            // 
            // idProvinciaDataGridViewTextBoxColumn
            // 
            this.idProvinciaDataGridViewTextBoxColumn.DataPropertyName = "IdProvincia";
            this.idProvinciaDataGridViewTextBoxColumn.HeaderText = "IdPr";
            this.idProvinciaDataGridViewTextBoxColumn.Name = "idProvinciaDataGridViewTextBoxColumn";
            this.idProvinciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idProvinciaDataGridViewTextBoxColumn.Width = 30;
            // 
            // idPartiadoDataGridViewTextBoxColumn
            // 
            this.idPartiadoDataGridViewTextBoxColumn.DataPropertyName = "IdPartiado";
            this.idPartiadoDataGridViewTextBoxColumn.HeaderText = "IdPa";
            this.idPartiadoDataGridViewTextBoxColumn.Name = "idPartiadoDataGridViewTextBoxColumn";
            this.idPartiadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPartiadoDataGridViewTextBoxColumn.Width = 30;
            // 
            // idLocalidadDataGridViewTextBoxColumn
            // 
            this.idLocalidadDataGridViewTextBoxColumn.DataPropertyName = "IdLocalidad";
            this.idLocalidadDataGridViewTextBoxColumn.HeaderText = "IdLo";
            this.idLocalidadDataGridViewTextBoxColumn.Name = "idLocalidadDataGridViewTextBoxColumn";
            this.idLocalidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.idLocalidadDataGridViewTextBoxColumn.Width = 30;
            // 
            // paisDataGridViewTextBoxColumn
            // 
            this.paisDataGridViewTextBoxColumn.DataPropertyName = "Pais";
            this.paisDataGridViewTextBoxColumn.HeaderText = "Pais";
            this.paisDataGridViewTextBoxColumn.Name = "paisDataGridViewTextBoxColumn";
            this.paisDataGridViewTextBoxColumn.ReadOnly = true;
            this.paisDataGridViewTextBoxColumn.Width = 50;
            // 
            // provinciaDataGridViewTextBoxColumn
            // 
            this.provinciaDataGridViewTextBoxColumn.DataPropertyName = "Provincia";
            this.provinciaDataGridViewTextBoxColumn.HeaderText = "Provincia";
            this.provinciaDataGridViewTextBoxColumn.Name = "provinciaDataGridViewTextBoxColumn";
            this.provinciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // partidoDataGridViewTextBoxColumn
            // 
            this.partidoDataGridViewTextBoxColumn.DataPropertyName = "Partido";
            this.partidoDataGridViewTextBoxColumn.HeaderText = "Partido";
            this.partidoDataGridViewTextBoxColumn.Name = "partidoDataGridViewTextBoxColumn";
            this.partidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localidadDataGridViewTextBoxColumn
            // 
            this.localidadDataGridViewTextBoxColumn.DataPropertyName = "Localidad";
            this.localidadDataGridViewTextBoxColumn.HeaderText = "Localidad";
            this.localidadDataGridViewTextBoxColumn.Name = "localidadDataGridViewTextBoxColumn";
            this.localidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressStructureBindingSource
            // 
            this.addressStructureBindingSource.DataSource = typeof(TecserEF.Entity.AddressStructure);
            // 
            // ep1
            // 
            this.ep1.ContainerControl = this;
            // 
            // _frmABMAdressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 653);
            this.Controls.Add(this.dgvSugerencias);
            this.Controls.Add(this.tvAddress);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.ckAutoValidar);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "_frmABMAdressControl";
            this.Text = "UC02 - ABM Address ";
            this.Load += new System.EventHandler(this._frmABMAdressControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localidadBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partidoBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinciaBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugerencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressStructureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tt;
        private TSControls.CtlIconos iconPartido;
        private TSControls.CtlIconos iconProvincia;
        private TSControls.CtlIconos iconPais;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource localidadBs;
        private TSControls.CtlIconos iconLocalidad;
        private System.Windows.Forms.BindingSource partidoBs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.BindingSource provinciaBs;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPartido;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.CheckBox ckAutoValidar;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvAddress;
        private System.Windows.Forms.DataGridView dgvSugerencias;
        private System.Windows.Forms.BindingSource addressStructureBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProvinciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPartiadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLocalidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provinciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.ErrorProvider ep1;
    }
}