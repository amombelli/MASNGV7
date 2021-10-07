namespace MASngFE.Transactional.MM.MMR
{
    partial class FrmMaterialMasterRename
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMaterialPrimario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.btnRenameMaterial = new System.Windows.Forms.Button();
            this.dgvListOfAka = new System.Windows.Forms.DataGridView();
            this.pRIMARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODVENTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mATDESC2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0011MATERIALESAKABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvListFormulasContain = new System.Windows.Forms.DataGridView();
            this.iDFORMULADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDMATERIALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCFORMULADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fORMVERSIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fORMFECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CHANGE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0020FORMULAHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnChangeHistoria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfAka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0011MATERIALESAKABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFormulasContain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0020FORMULAHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0010MATERIALESBindingSource, "MAT_DESC", true));
            this.txtDescripcion.Location = new System.Drawing.Point(265, 24);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(417, 22);
            this.txtDescripcion.TabIndex = 0;
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "MATERIAL";
            // 
            // cmbMaterialPrimario
            // 
            this.cmbMaterialPrimario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterialPrimario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterialPrimario.DataSource = this.t0010MATERIALESBindingSource;
            this.cmbMaterialPrimario.DisplayMember = "IDMATERIAL";
            this.cmbMaterialPrimario.FormattingEnabled = true;
            this.cmbMaterialPrimario.Location = new System.Drawing.Point(97, 24);
            this.cmbMaterialPrimario.Name = "cmbMaterialPrimario";
            this.cmbMaterialPrimario.Size = new System.Drawing.Size(162, 22);
            this.cmbMaterialPrimario.TabIndex = 2;
            this.cmbMaterialPrimario.ValueMember = "IDMATERIAL";
            this.cmbMaterialPrimario.SelectedIndexChanged += new System.EventHandler(this.cmbMaterialPrimario_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "NEW NAME";
            // 
            // txtNewName
            // 
            this.txtNewName.Location = new System.Drawing.Point(97, 49);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(162, 22);
            this.txtNewName.TabIndex = 4;
            this.txtNewName.Leave += new System.EventHandler(this.txtNewName_Leave);
            // 
            // btnRenameMaterial
            // 
            this.btnRenameMaterial.Location = new System.Drawing.Point(708, 24);
            this.btnRenameMaterial.Name = "btnRenameMaterial";
            this.btnRenameMaterial.Size = new System.Drawing.Size(100, 44);
            this.btnRenameMaterial.TabIndex = 5;
            this.btnRenameMaterial.Text = "Rename Material";
            this.btnRenameMaterial.UseVisualStyleBackColor = true;
            this.btnRenameMaterial.Click += new System.EventHandler(this.btnRenameMaterial_Click);
            // 
            // dgvListOfAka
            // 
            this.dgvListOfAka.AllowUserToAddRows = false;
            this.dgvListOfAka.AllowUserToDeleteRows = false;
            this.dgvListOfAka.AutoGenerateColumns = false;
            this.dgvListOfAka.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvListOfAka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListOfAka.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pRIMARIODataGridViewTextBoxColumn,
            this.cODVENTADataGridViewTextBoxColumn,
            this.mATDESC2DataGridViewTextBoxColumn});
            this.dgvListOfAka.DataSource = this.t0011MATERIALESAKABindingSource;
            this.dgvListOfAka.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvListOfAka.Location = new System.Drawing.Point(25, 90);
            this.dgvListOfAka.Name = "dgvListOfAka";
            this.dgvListOfAka.ReadOnly = true;
            this.dgvListOfAka.Size = new System.Drawing.Size(549, 150);
            this.dgvListOfAka.TabIndex = 6;
            // 
            // pRIMARIODataGridViewTextBoxColumn
            // 
            this.pRIMARIODataGridViewTextBoxColumn.DataPropertyName = "PRIMARIO";
            this.pRIMARIODataGridViewTextBoxColumn.HeaderText = "PRIMARIO";
            this.pRIMARIODataGridViewTextBoxColumn.Name = "pRIMARIODataGridViewTextBoxColumn";
            this.pRIMARIODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cODVENTADataGridViewTextBoxColumn
            // 
            this.cODVENTADataGridViewTextBoxColumn.DataPropertyName = "CODVENTA";
            this.cODVENTADataGridViewTextBoxColumn.HeaderText = "CODVENTA";
            this.cODVENTADataGridViewTextBoxColumn.Name = "cODVENTADataGridViewTextBoxColumn";
            this.cODVENTADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mATDESC2DataGridViewTextBoxColumn
            // 
            this.mATDESC2DataGridViewTextBoxColumn.DataPropertyName = "MAT_DESC2";
            this.mATDESC2DataGridViewTextBoxColumn.HeaderText = "DESCRIPCION MATERIAL";
            this.mATDESC2DataGridViewTextBoxColumn.Name = "mATDESC2DataGridViewTextBoxColumn";
            this.mATDESC2DataGridViewTextBoxColumn.ReadOnly = true;
            this.mATDESC2DataGridViewTextBoxColumn.Width = 300;
            // 
            // t0011MATERIALESAKABindingSource
            // 
            this.t0011MATERIALESAKABindingSource.DataSource = typeof(TecserEF.Entity.T0011_MATERIALES_AKA);
            // 
            // dgvListFormulasContain
            // 
            this.dgvListFormulasContain.AllowUserToAddRows = false;
            this.dgvListFormulasContain.AllowUserToDeleteRows = false;
            this.dgvListFormulasContain.AutoGenerateColumns = false;
            this.dgvListFormulasContain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListFormulasContain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDFORMULADataGridViewTextBoxColumn,
            this.iDMATERIALDataGridViewTextBoxColumn,
            this.dESCFORMULADataGridViewTextBoxColumn,
            this.fORMVERSIONDataGridViewTextBoxColumn,
            this.fORMFECHADataGridViewTextBoxColumn,
            this.aCTIVADataGridViewTextBoxColumn,
            this.CHANGE});
            this.dgvListFormulasContain.DataSource = this.t0020FORMULAHBindingSource;
            this.dgvListFormulasContain.Location = new System.Drawing.Point(25, 271);
            this.dgvListFormulasContain.Name = "dgvListFormulasContain";
            this.dgvListFormulasContain.ReadOnly = true;
            this.dgvListFormulasContain.Size = new System.Drawing.Size(692, 357);
            this.dgvListFormulasContain.TabIndex = 7;
            this.dgvListFormulasContain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListFormulasContain_CellContentClick);
            // 
            // iDFORMULADataGridViewTextBoxColumn
            // 
            this.iDFORMULADataGridViewTextBoxColumn.DataPropertyName = "ID_FORMULA";
            this.iDFORMULADataGridViewTextBoxColumn.HeaderText = "FORMID";
            this.iDFORMULADataGridViewTextBoxColumn.Name = "iDFORMULADataGridViewTextBoxColumn";
            this.iDFORMULADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDFORMULADataGridViewTextBoxColumn.Width = 50;
            // 
            // iDMATERIALDataGridViewTextBoxColumn
            // 
            this.iDMATERIALDataGridViewTextBoxColumn.DataPropertyName = "IDMATERIAL";
            this.iDMATERIALDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.iDMATERIALDataGridViewTextBoxColumn.Name = "iDMATERIALDataGridViewTextBoxColumn";
            this.iDMATERIALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dESCFORMULADataGridViewTextBoxColumn
            // 
            this.dESCFORMULADataGridViewTextBoxColumn.DataPropertyName = "DESC_FORMULA";
            this.dESCFORMULADataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.dESCFORMULADataGridViewTextBoxColumn.Name = "dESCFORMULADataGridViewTextBoxColumn";
            this.dESCFORMULADataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCFORMULADataGridViewTextBoxColumn.Width = 180;
            // 
            // fORMVERSIONDataGridViewTextBoxColumn
            // 
            this.fORMVERSIONDataGridViewTextBoxColumn.DataPropertyName = "FORM_VERSION";
            this.fORMVERSIONDataGridViewTextBoxColumn.HeaderText = "VERSION";
            this.fORMVERSIONDataGridViewTextBoxColumn.Name = "fORMVERSIONDataGridViewTextBoxColumn";
            this.fORMVERSIONDataGridViewTextBoxColumn.ReadOnly = true;
            this.fORMVERSIONDataGridViewTextBoxColumn.Width = 60;
            // 
            // fORMFECHADataGridViewTextBoxColumn
            // 
            this.fORMFECHADataGridViewTextBoxColumn.DataPropertyName = "FORM_FECHA";
            this.fORMFECHADataGridViewTextBoxColumn.HeaderText = "FECHA FORM";
            this.fORMFECHADataGridViewTextBoxColumn.Name = "fORMFECHADataGridViewTextBoxColumn";
            this.fORMFECHADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aCTIVADataGridViewTextBoxColumn
            // 
            this.aCTIVADataGridViewTextBoxColumn.DataPropertyName = "ACTIVA";
            this.aCTIVADataGridViewTextBoxColumn.HeaderText = "ACTIVA";
            this.aCTIVADataGridViewTextBoxColumn.Name = "aCTIVADataGridViewTextBoxColumn";
            this.aCTIVADataGridViewTextBoxColumn.ReadOnly = true;
            this.aCTIVADataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aCTIVADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aCTIVADataGridViewTextBoxColumn.Width = 50;
            // 
            // CHANGE
            // 
            this.CHANGE.HeaderText = "CHANGE";
            this.CHANGE.Name = "CHANGE";
            this.CHANGE.ReadOnly = true;
            this.CHANGE.Text = "CHANGE";
            this.CHANGE.ToolTipText = "Cambiar Materia Prima";
            this.CHANGE.UseColumnTextForButtonValue = true;
            this.CHANGE.Width = 60;
            // 
            // t0020FORMULAHBindingSource
            // 
            this.t0020FORMULAHBindingSource.DataSource = typeof(TecserEF.Entity.T0020_FORMULA_H);
            // 
            // btnChangeHistoria
            // 
            this.btnChangeHistoria.Location = new System.Drawing.Point(737, 271);
            this.btnChangeHistoria.Name = "btnChangeHistoria";
            this.btnChangeHistoria.Size = new System.Drawing.Size(100, 44);
            this.btnChangeHistoria.TabIndex = 8;
            this.btnChangeHistoria.Text = "Change Historia";
            this.btnChangeHistoria.UseVisualStyleBackColor = true;
            this.btnChangeHistoria.Click += new System.EventHandler(this.btnChangeHistoria_Click);
            // 
            // FrmMaterialMasterRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 759);
            this.Controls.Add(this.btnChangeHistoria);
            this.Controls.Add(this.dgvListFormulasContain);
            this.Controls.Add(this.dgvListOfAka);
            this.Controls.Add(this.btnRenameMaterial);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMaterialPrimario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMaterialMasterRename";
            this.Text = "MMR - MATERIAL MASTER RENAMING";
            this.Load += new System.EventHandler(this.FrmMaterialMasterRename_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfAka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0011MATERIALESAKABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListFormulasContain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0020FORMULAHBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMaterialPrimario;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewName;
        private System.Windows.Forms.Button btnRenameMaterial;
        private System.Windows.Forms.DataGridView dgvListOfAka;
        private System.Windows.Forms.BindingSource t0011MATERIALESAKABindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRIMARIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODVENTADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATDESC2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvListFormulasContain;
        private System.Windows.Forms.BindingSource t0020FORMULAHBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDFORMULADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDMATERIALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCFORMULADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fORMVERSIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fORMFECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn CHANGE;
        private System.Windows.Forms.Button btnChangeHistoria;
    }
}