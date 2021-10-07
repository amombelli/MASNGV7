namespace MASngFE.MasterData.BOM
{
    partial class FrmMdb01BomSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFormulaList = new System.Windows.Forms.DataGridView();
            this.t0020FORMULAHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbMaterialFormula = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewFormula = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlternativasDispo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcionTecnica = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iDFORMULADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDMATERIALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCFORMULADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fORMVERSIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sTATUSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUsedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCION = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0020_Combo = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulaList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0020FORMULAHBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0020_Combo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFormulaList
            // 
            this.dgvFormulaList.AllowUserToAddRows = false;
            this.dgvFormulaList.AllowUserToDeleteRows = false;
            this.dgvFormulaList.AutoGenerateColumns = false;
            this.dgvFormulaList.BackgroundColor = System.Drawing.Color.White;
            this.dgvFormulaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormulaList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDFORMULADataGridViewTextBoxColumn,
            this.iDMATERIALDataGridViewTextBoxColumn,
            this.dESCFORMULADataGridViewTextBoxColumn,
            this.fORMVERSIONDataGridViewTextBoxColumn,
            this.aCTIVADataGridViewTextBoxColumn,
            this.sTATUSDataGridViewTextBoxColumn,
            this.lastUsedDataGridViewTextBoxColumn,
            this.ACCION});
            this.dgvFormulaList.DataSource = this.t0020FORMULAHBindingSource;
            this.dgvFormulaList.GridColor = System.Drawing.Color.SeaGreen;
            this.dgvFormulaList.Location = new System.Drawing.Point(4, 137);
            this.dgvFormulaList.Name = "dgvFormulaList";
            this.dgvFormulaList.ReadOnly = true;
            this.dgvFormulaList.RowHeadersWidth = 25;
            this.dgvFormulaList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormulaList.Size = new System.Drawing.Size(584, 218);
            this.dgvFormulaList.TabIndex = 1;
            this.dgvFormulaList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaList_CellContentClick);
            // 
            // t0020FORMULAHBindingSource
            // 
            this.t0020FORMULAHBindingSource.DataSource = typeof(TecserEF.Entity.T0020_FORMULA_H);
            // 
            // cmbMaterialFormula
            // 
            this.cmbMaterialFormula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterialFormula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterialFormula.DataSource = this.t0020_Combo;
            this.cmbMaterialFormula.DisplayMember = "IDMATERIAL";
            this.cmbMaterialFormula.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.cmbMaterialFormula.FormattingEnabled = true;
            this.cmbMaterialFormula.Location = new System.Drawing.Point(148, 6);
            this.cmbMaterialFormula.Name = "cmbMaterialFormula";
            this.cmbMaterialFormula.Size = new System.Drawing.Size(147, 21);
            this.cmbMaterialFormula.TabIndex = 2;
            this.cmbMaterialFormula.ValueMember = "IDMATERIAL";
            this.cmbMaterialFormula.SelectedIndexChanged += new System.EventHandler(this.cmbMaterialFormula_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "MATERIAL [PRIMARIO]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "ALTERNATIVAS DISPONIBLES";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbMaterialFormula);
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 34);
            this.panel1.TabIndex = 7;
            // 
            // btnNewFormula
            // 
            this.btnNewFormula.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFormula.Location = new System.Drawing.Point(6, 5);
            this.btnNewFormula.Name = "btnNewFormula";
            this.btnNewFormula.Size = new System.Drawing.Size(100, 40);
            this.btnNewFormula.TabIndex = 26;
            this.btnNewFormula.Text = "CREAR\r\nBOM";
            this.btnNewFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewFormula.UseVisualStyleBackColor = true;
            this.btnNewFormula.Click += new System.EventHandler(this.btnNewFormula_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(6, 45);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtAlternativasDispo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDescripcionTecnica);
            this.panel2.Location = new System.Drawing.Point(4, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(441, 60);
            this.panel2.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "ALTERNATIVAS DISP";
            // 
            // txtAlternativasDispo
            // 
            this.txtAlternativasDispo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlternativasDispo.Location = new System.Drawing.Point(148, 30);
            this.txtAlternativasDispo.Name = "txtAlternativasDispo";
            this.txtAlternativasDispo.ReadOnly = true;
            this.txtAlternativasDispo.Size = new System.Drawing.Size(30, 21);
            this.txtAlternativasDispo.TabIndex = 5;
            this.txtAlternativasDispo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "DESCRIPCION [TECNICA/LAB]";
            // 
            // txtDescripcionTecnica
            // 
            this.txtDescripcionTecnica.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionTecnica.Location = new System.Drawing.Point(148, 7);
            this.txtDescripcionTecnica.Name = "txtDescripcionTecnica";
            this.txtDescripcionTecnica.ReadOnly = true;
            this.txtDescripcionTecnica.Size = new System.Drawing.Size(285, 21);
            this.txtDescripcionTecnica.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnNewFormula);
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Location = new System.Drawing.Point(617, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 90);
            this.panel3.TabIndex = 29;
            // 
            // iDFORMULADataGridViewTextBoxColumn
            // 
            this.iDFORMULADataGridViewTextBoxColumn.DataPropertyName = "ID_FORMULA";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.iDFORMULADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.iDFORMULADataGridViewTextBoxColumn.HeaderText = "FORM#";
            this.iDFORMULADataGridViewTextBoxColumn.Name = "iDFORMULADataGridViewTextBoxColumn";
            this.iDFORMULADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDFORMULADataGridViewTextBoxColumn.ToolTipText = "Numero de Formula (Identificacion(";
            this.iDFORMULADataGridViewTextBoxColumn.Width = 60;
            // 
            // iDMATERIALDataGridViewTextBoxColumn
            // 
            this.iDMATERIALDataGridViewTextBoxColumn.DataPropertyName = "IDMATERIAL";
            this.iDMATERIALDataGridViewTextBoxColumn.HeaderText = "IDMATERIAL";
            this.iDMATERIALDataGridViewTextBoxColumn.Name = "iDMATERIALDataGridViewTextBoxColumn";
            this.iDMATERIALDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDMATERIALDataGridViewTextBoxColumn.Visible = false;
            // 
            // dESCFORMULADataGridViewTextBoxColumn
            // 
            this.dESCFORMULADataGridViewTextBoxColumn.DataPropertyName = "DESC_FORMULA";
            this.dESCFORMULADataGridViewTextBoxColumn.HeaderText = "DESCRIPCION FORMULA";
            this.dESCFORMULADataGridViewTextBoxColumn.Name = "dESCFORMULADataGridViewTextBoxColumn";
            this.dESCFORMULADataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCFORMULADataGridViewTextBoxColumn.Width = 180;
            // 
            // fORMVERSIONDataGridViewTextBoxColumn
            // 
            this.fORMVERSIONDataGridViewTextBoxColumn.DataPropertyName = "FORM_VERSION";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fORMVERSIONDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fORMVERSIONDataGridViewTextBoxColumn.HeaderText = "ALT#";
            this.fORMVERSIONDataGridViewTextBoxColumn.Name = "fORMVERSIONDataGridViewTextBoxColumn";
            this.fORMVERSIONDataGridViewTextBoxColumn.ReadOnly = true;
            this.fORMVERSIONDataGridViewTextBoxColumn.ToolTipText = "Numero de Alternativa de Formula";
            this.fORMVERSIONDataGridViewTextBoxColumn.Width = 35;
            // 
            // aCTIVADataGridViewTextBoxColumn
            // 
            this.aCTIVADataGridViewTextBoxColumn.DataPropertyName = "ACTIVA";
            this.aCTIVADataGridViewTextBoxColumn.FillWeight = 50F;
            this.aCTIVADataGridViewTextBoxColumn.HeaderText = "ACT";
            this.aCTIVADataGridViewTextBoxColumn.Name = "aCTIVADataGridViewTextBoxColumn";
            this.aCTIVADataGridViewTextBoxColumn.ReadOnly = true;
            this.aCTIVADataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aCTIVADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aCTIVADataGridViewTextBoxColumn.Width = 40;
            // 
            // sTATUSDataGridViewTextBoxColumn
            // 
            this.sTATUSDataGridViewTextBoxColumn.DataPropertyName = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn.HeaderText = "STATUS";
            this.sTATUSDataGridViewTextBoxColumn.Name = "sTATUSDataGridViewTextBoxColumn";
            this.sTATUSDataGridViewTextBoxColumn.ReadOnly = true;
            this.sTATUSDataGridViewTextBoxColumn.Width = 60;
            // 
            // lastUsedDataGridViewTextBoxColumn
            // 
            this.lastUsedDataGridViewTextBoxColumn.DataPropertyName = "LastUsed";
            this.lastUsedDataGridViewTextBoxColumn.HeaderText = "ULTIMO USO";
            this.lastUsedDataGridViewTextBoxColumn.Name = "lastUsedDataGridViewTextBoxColumn";
            this.lastUsedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ACCION
            // 
            this.ACCION.HeaderText = "ACCION";
            this.ACCION.Name = "ACCION";
            this.ACCION.ReadOnly = true;
            this.ACCION.Text = "DETALLE";
            this.ACCION.ToolTipText = "Ver o Editar la Formula";
            this.ACCION.UseColumnTextForButtonValue = true;
            this.ACCION.Width = 60;
            // 
            // t0020_Combo
            // 
            this.t0020_Combo.DataSource = typeof(TecserEF.Entity.T0020_FORMULA_H);
            // 
            // FrmMdb01BomSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 359);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvFormulaList);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMdb01BomSearch";
            this.Text = "MDB01 Busqueda de Formulas [BOM Search]";
            this.Load += new System.EventHandler(this.FrmBOMSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulaList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0020FORMULAHBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.t0020_Combo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFormulaList;
        private System.Windows.Forms.ComboBox cmbMaterialFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource t0020FORMULAHBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewFormula;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlternativasDispo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcionTecnica;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDFORMULADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDMATERIALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCFORMULADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fORMVERSIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTATUSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUsedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ACCION;
        private System.Windows.Forms.BindingSource t0020_Combo;
    }
}