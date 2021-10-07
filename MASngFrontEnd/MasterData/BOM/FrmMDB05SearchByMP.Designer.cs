namespace MASngFE.MasterData.BOM
{
    partial class FrmMDB05SearchByMP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMtype = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.ckSoloActivo = new System.Windows.Forms.CheckBox();
            this.dgvListaFormulas = new System.Windows.Forms.DataGridView();
            this.componenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialFabricarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimoUsoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formulaActivaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bVerFormula = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantActivas = new System.Windows.Forms.TextBox();
            this.txtCantInactivas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFormulas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBs)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 60);
            this.panel1.TabIndex = 89;
            // 
            // txtOrigen
            // 
            this.txtOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrigen.Location = new System.Drawing.Point(68, 30);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.ReadOnly = true;
            this.txtOrigen.Size = new System.Drawing.Size(57, 21);
            this.txtOrigen.TabIndex = 92;
            this.txtOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 15);
            this.label14.TabIndex = 91;
            this.label14.Text = "Origen";
            // 
            // txtMtype
            // 
            this.txtMtype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMtype.Location = new System.Drawing.Point(591, 7);
            this.txtMtype.Name = "txtMtype";
            this.txtMtype.ReadOnly = true;
            this.txtMtype.Size = new System.Drawing.Size(57, 21);
            this.txtMtype.TabIndex = 90;
            this.txtMtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Location = new System.Drawing.Point(229, 7);
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
            this.cmbMaterial.Location = new System.Drawing.Point(68, 7);
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
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 87;
            this.label1.Text = "Material";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(663, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 132;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // ckSoloActivo
            // 
            this.ckSoloActivo.AutoSize = true;
            this.ckSoloActivo.Location = new System.Drawing.Point(428, 34);
            this.ckSoloActivo.Name = "ckSoloActivo";
            this.ckSoloActivo.Size = new System.Drawing.Size(220, 19);
            this.ckSoloActivo.TabIndex = 133;
            this.ckSoloActivo.Text = "Sólo Versiones de Formulas Activas";
            this.ckSoloActivo.UseVisualStyleBackColor = true;
            // 
            // dgvListaFormulas
            // 
            this.dgvListaFormulas.AllowUserToAddRows = false;
            this.dgvListaFormulas.AllowUserToDeleteRows = false;
            this.dgvListaFormulas.AutoGenerateColumns = false;
            this.dgvListaFormulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaFormulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvListaFormulas.Location = new System.Drawing.Point(2, 119);
            this.dgvListaFormulas.Name = "dgvListaFormulas";
            this.dgvListaFormulas.ReadOnly = true;
            this.dgvListaFormulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaFormulas.Size = new System.Drawing.Size(755, 527);
            this.dgvListaFormulas.TabIndex = 134;
            this.dgvListaFormulas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaFormulas_CellContentClick);
            // 
            // componenteDataGridViewTextBoxColumn
            // 
            this.componenteDataGridViewTextBoxColumn.DataPropertyName = "Componente";
            this.componenteDataGridViewTextBoxColumn.HeaderText = "Componente";
            this.componenteDataGridViewTextBoxColumn.Name = "componenteDataGridViewTextBoxColumn";
            this.componenteDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.bVerFormula.ReadOnly = true;
            this.bVerFormula.Text = "VER";
            this.bVerFormula.ToolTipText = "Visualizar la Formula";
            this.bVerFormula.UseColumnTextForButtonValue = true;
            this.bVerFormula.Width = 70;
            // 
            // dataBs
            // 
            this.dataBs.DataSource = typeof(TecserEF.Entity.DataStructure.BOM.EstructuraMPenFormula);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCantInactivas);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtCantActivas);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(2, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 53);
            this.panel2.TabIndex = 135;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 15);
            this.label2.TabIndex = 134;
            this.label2.Text = "Cantidad Formulas Activas";
            // 
            // txtCantActivas
            // 
            this.txtCantActivas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantActivas.Location = new System.Drawing.Point(177, 5);
            this.txtCantActivas.Name = "txtCantActivas";
            this.txtCantActivas.ReadOnly = true;
            this.txtCantActivas.Size = new System.Drawing.Size(50, 21);
            this.txtCantActivas.TabIndex = 134;
            this.txtCantActivas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantInactivas
            // 
            this.txtCantInactivas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantInactivas.Location = new System.Drawing.Point(177, 27);
            this.txtCantInactivas.Name = "txtCantInactivas";
            this.txtCantInactivas.ReadOnly = true;
            this.txtCantInactivas.Size = new System.Drawing.Size(50, 21);
            this.txtCantInactivas.TabIndex = 135;
            this.txtCantInactivas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 15);
            this.label3.TabIndex = 136;
            this.label3.Text = "Cantidad Formulas Inactivas";
            // 
            // FrmMDB05SearchByMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 649);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvListaFormulas);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMDB05SearchByMP";
            this.Text = "MDB05 - Busqueda por Componente";
            this.Load += new System.EventHandler(this.FrmMDB05SearchByMP_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFormulas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMtype;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox ckSoloActivo;
        private System.Windows.Forms.DataGridView dgvListaFormulas;
        private System.Windows.Forms.BindingSource dataBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn componenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialFabricarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionFormulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFormulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimoUsoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn formulaActivaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn bVerFormula;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCantInactivas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantActivas;
        private System.Windows.Forms.Label label2;
    }
}