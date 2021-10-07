namespace MASngFE.MasterData.BOM
{
    partial class FrmMDB06MassFormActivate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMDB06MassFormActivate));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.txtCantInactivas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantActivas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvListaFormulas = new System.Windows.Forms.DataGridView();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.ckSoloActivo = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMtype = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            this.ck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.componenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialFabricarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimoUsoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formulaActivaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bVerFormula = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbUltimoUso = new System.Windows.Forms.RadioButton();
            this.rmMaterial = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataBs)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFormulas)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataBs
            // 
            this.dataBs.DataSource = typeof(TecserEF.Entity.DataStructure.BOM.EstructuraMPenFormula);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(822, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 137;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // txtCantInactivas
            // 
            this.txtCantInactivas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantInactivas.Location = new System.Drawing.Point(177, 25);
            this.txtCantInactivas.Name = "txtCantInactivas";
            this.txtCantInactivas.ReadOnly = true;
            this.txtCantInactivas.Size = new System.Drawing.Size(50, 21);
            this.txtCantInactivas.TabIndex = 135;
            this.txtCantInactivas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 15);
            this.label3.TabIndex = 136;
            this.label3.Text = "Cantidad Formulas Inactivas";
            // 
            // txtCantActivas
            // 
            this.txtCantActivas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantActivas.Location = new System.Drawing.Point(177, 3);
            this.txtCantActivas.Name = "txtCantActivas";
            this.txtCantActivas.ReadOnly = true;
            this.txtCantActivas.Size = new System.Drawing.Size(50, 21);
            this.txtCantActivas.TabIndex = 134;
            this.txtCantActivas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 15);
            this.label2.TabIndex = 134;
            this.label2.Text = "Cantidad Formulas Activas";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCantInactivas);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtCantActivas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 53);
            this.panel2.TabIndex = 139;
            // 
            // dgvListaFormulas
            // 
            this.dgvListaFormulas.AllowUserToAddRows = false;
            this.dgvListaFormulas.AllowUserToDeleteRows = false;
            this.dgvListaFormulas.AutoGenerateColumns = false;
            this.dgvListaFormulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaFormulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ck,
            this.componenteDataGridViewTextBoxColumn,
            this.materialFabricarDataGridViewTextBoxColumn,
            this.descripcionFormulaDataGridViewTextBoxColumn,
            this.idFormulaDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.ultimoUsoDataGridViewTextBoxColumn,
            this.formulaActivaDataGridViewCheckBoxColumn,
            this.bVerFormula});
            this.dgvListaFormulas.DataSource = this.dataBs;
            this.dgvListaFormulas.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvListaFormulas.Location = new System.Drawing.Point(3, 120);
            this.dgvListaFormulas.Name = "dgvListaFormulas";
            this.dgvListaFormulas.RowHeadersWidth = 35;
            this.dgvListaFormulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaFormulas.Size = new System.Drawing.Size(755, 527);
            this.dgvListaFormulas.TabIndex = 138;
            this.dgvListaFormulas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaFormulas_CellContentClick);
            // 
            // txtOrigen
            // 
            this.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrigen.Location = new System.Drawing.Point(68, 28);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.ReadOnly = true;
            this.txtOrigen.Size = new System.Drawing.Size(57, 21);
            this.txtOrigen.TabIndex = 92;
            this.txtOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ckSoloActivo
            // 
            this.ckSoloActivo.AutoSize = true;
            this.ckSoloActivo.Location = new System.Drawing.Point(428, 32);
            this.ckSoloActivo.Name = "ckSoloActivo";
            this.ckSoloActivo.Size = new System.Drawing.Size(220, 19);
            this.ckSoloActivo.TabIndex = 133;
            this.ckSoloActivo.Text = "Sólo Versiones de Formulas Activas";
            this.ckSoloActivo.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 15);
            this.label14.TabIndex = 91;
            this.label14.Text = "Origen";
            // 
            // txtMtype
            // 
            this.txtMtype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMtype.Location = new System.Drawing.Point(591, 5);
            this.txtMtype.Name = "txtMtype";
            this.txtMtype.ReadOnly = true;
            this.txtMtype.Size = new System.Drawing.Size(57, 21);
            this.txtMtype.TabIndex = 90;
            this.txtMtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Location = new System.Drawing.Point(229, 5);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(360, 21);
            this.txtDescripcion.TabIndex = 89;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.BackColor = System.Drawing.Color.White;
            this.cmbMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(68, 5);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(159, 21);
            this.cmbMaterial.TabIndex = 88;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.CmbMaterial_SelectedIndexChanged);
            this.cmbMaterial.Leave += new System.EventHandler(this.CmbMaterial_Leave);
            this.cmbMaterial.Validating += new System.ComponentModel.CancelEventHandler(this.CmbMaterial_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "Material";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.txtOrigen);
            this.panel1.Controls.Add(this.ckSoloActivo);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtMtype);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.cmbMaterial);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 60);
            this.panel1.TabIndex = 136;
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDesactivar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesactivar.Image = ((System.Drawing.Image)(resources.GetObject("btnDesactivar.Image")));
            this.btnDesactivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesactivar.Location = new System.Drawing.Point(822, 160);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(100, 40);
            this.btnDesactivar.TabIndex = 140;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.BtnDesactivar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnActivar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.Image = ((System.Drawing.Image)(resources.GetObject("btnActivar.Image")));
            this.btnActivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivar.Location = new System.Drawing.Point(822, 120);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(100, 40);
            this.btnActivar.TabIndex = 141;
            this.btnActivar.Text = "Activar";
            this.btnActivar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.BtnActivar_Click);
            // 
            // ck
            // 
            this.ck.HeaderText = "Select";
            this.ck.Name = "ck";
            this.ck.ToolTipText = "Seleccione la version para Activar/Desactivar la formula";
            this.ck.Width = 50;
            // 
            // componenteDataGridViewTextBoxColumn
            // 
            this.componenteDataGridViewTextBoxColumn.DataPropertyName = "Componente";
            this.componenteDataGridViewTextBoxColumn.HeaderText = "Componente";
            this.componenteDataGridViewTextBoxColumn.Name = "componenteDataGridViewTextBoxColumn";
            this.componenteDataGridViewTextBoxColumn.Visible = false;
            // 
            // materialFabricarDataGridViewTextBoxColumn
            // 
            this.materialFabricarDataGridViewTextBoxColumn.DataPropertyName = "MaterialFabricar";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.materialFabricarDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.materialFabricarDataGridViewTextBoxColumn.HeaderText = "MaterialFabricar";
            this.materialFabricarDataGridViewTextBoxColumn.Name = "materialFabricarDataGridViewTextBoxColumn";
            this.materialFabricarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionFormulaDataGridViewTextBoxColumn
            // 
            this.descripcionFormulaDataGridViewTextBoxColumn.DataPropertyName = "DescripcionFormula";
            this.descripcionFormulaDataGridViewTextBoxColumn.HeaderText = "Descripcion Formula";
            this.descripcionFormulaDataGridViewTextBoxColumn.Name = "descripcionFormulaDataGridViewTextBoxColumn";
            this.descripcionFormulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionFormulaDataGridViewTextBoxColumn.Width = 250;
            // 
            // idFormulaDataGridViewTextBoxColumn
            // 
            this.idFormulaDataGridViewTextBoxColumn.DataPropertyName = "IdFormula";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idFormulaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.idFormulaDataGridViewTextBoxColumn.HeaderText = "Form#";
            this.idFormulaDataGridViewTextBoxColumn.Name = "idFormulaDataGridViewTextBoxColumn";
            this.idFormulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idFormulaDataGridViewTextBoxColumn.Width = 50;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.versionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.versionDataGridViewTextBoxColumn.HeaderText = "Ver.";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            this.versionDataGridViewTextBoxColumn.Width = 40;
            // 
            // ultimoUsoDataGridViewTextBoxColumn
            // 
            this.ultimoUsoDataGridViewTextBoxColumn.DataPropertyName = "UltimoUso";
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.ultimoUsoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.ultimoUsoDataGridViewTextBoxColumn.HeaderText = "UltimoUso";
            this.ultimoUsoDataGridViewTextBoxColumn.Name = "ultimoUsoDataGridViewTextBoxColumn";
            this.ultimoUsoDataGridViewTextBoxColumn.ReadOnly = true;
            this.ultimoUsoDataGridViewTextBoxColumn.Width = 85;
            // 
            // formulaActivaDataGridViewCheckBoxColumn
            // 
            this.formulaActivaDataGridViewCheckBoxColumn.DataPropertyName = "FormulaActiva";
            this.formulaActivaDataGridViewCheckBoxColumn.HeaderText = "Activa";
            this.formulaActivaDataGridViewCheckBoxColumn.Name = "formulaActivaDataGridViewCheckBoxColumn";
            this.formulaActivaDataGridViewCheckBoxColumn.ReadOnly = true;
            this.formulaActivaDataGridViewCheckBoxColumn.Width = 50;
            // 
            // bVerFormula
            // 
            this.bVerFormula.HeaderText = "Ver BOM";
            this.bVerFormula.Name = "bVerFormula";
            this.bVerFormula.Text = "VER";
            this.bVerFormula.ToolTipText = "Visualizar la Formula";
            this.bVerFormula.UseColumnTextForButtonValue = true;
            this.bVerFormula.Width = 70;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rmMaterial);
            this.groupBox1.Controls.Add(this.rbUltimoUso);
            this.groupBox1.Location = new System.Drawing.Point(664, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 63);
            this.groupBox1.TabIndex = 137;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ordenar Por:";
            // 
            // rbUltimoUso
            // 
            this.rbUltimoUso.AutoSize = true;
            this.rbUltimoUso.Location = new System.Drawing.Point(12, 20);
            this.rbUltimoUso.Name = "rbUltimoUso";
            this.rbUltimoUso.Size = new System.Drawing.Size(76, 17);
            this.rbUltimoUso.TabIndex = 0;
            this.rbUltimoUso.TabStop = true;
            this.rbUltimoUso.Text = "Ultimo Uso";
            this.rbUltimoUso.UseVisualStyleBackColor = true;
            this.rbUltimoUso.CheckedChanged += new System.EventHandler(this.RbUltimoUso_CheckedChanged);
            // 
            // rmMaterial
            // 
            this.rmMaterial.AutoSize = true;
            this.rmMaterial.Location = new System.Drawing.Point(12, 42);
            this.rmMaterial.Name = "rmMaterial";
            this.rmMaterial.Size = new System.Drawing.Size(103, 17);
            this.rmMaterial.TabIndex = 1;
            this.rmMaterial.TabStop = true;
            this.rmMaterial.Text = "Material Fabricar";
            this.rmMaterial.UseVisualStyleBackColor = true;
            this.rmMaterial.CheckedChanged += new System.EventHandler(this.RbUltimoUso_CheckedChanged);
            // 
            // FrmMDB06MassFormActivate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 765);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvListaFormulas);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMDB06MassFormActivate";
            this.Text = "MDB06 - Activacion/Desactivacion Masiva de Versiones";
            this.Load += new System.EventHandler(this.FrmMDB06MassFormActivate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataBs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFormulas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource dataBs;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtCantInactivas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantActivas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvListaFormulas;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.CheckBox ckSoloActivo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMtype;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ck;
        private System.Windows.Forms.DataGridViewTextBoxColumn componenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialFabricarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionFormulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFormulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimoUsoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn formulaActivaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn bVerFormula;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rmMaterial;
        private System.Windows.Forms.RadioButton rbUltimoUso;
    }
}