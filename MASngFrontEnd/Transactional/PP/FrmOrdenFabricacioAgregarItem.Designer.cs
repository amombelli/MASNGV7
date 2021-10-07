namespace MASngFE.Transactional.PP
{
    partial class FrmOrdenFabricacioAgregarItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaterialFabricar = new System.Windows.Forms.TextBox();
            this.cmbListaMateriales = new System.Windows.Forms.ComboBox();
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStockDisponible = new System.Windows.Forms.DataGridView();
            this.iDStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KGTOADD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddMaterial = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0030STOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtNumeroFormula = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcionFormula = new System.Windows.Forms.TextBox();
            this.ckSoloFusion = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "MATERIAL A FABRICAR";
            // 
            // txtMaterialFabricar
            // 
            this.txtMaterialFabricar.Font = new System.Drawing.Font("Calibri", 9F);
            this.txtMaterialFabricar.Location = new System.Drawing.Point(139, 6);
            this.txtMaterialFabricar.Name = "txtMaterialFabricar";
            this.txtMaterialFabricar.ReadOnly = true;
            this.txtMaterialFabricar.Size = new System.Drawing.Size(120, 22);
            this.txtMaterialFabricar.TabIndex = 1;
            // 
            // cmbListaMateriales
            // 
            this.cmbListaMateriales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbListaMateriales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbListaMateriales.DataSource = this.t0010MATERIALESBindingSource;
            this.cmbListaMateriales.DisplayMember = "IDMATERIAL";
            this.cmbListaMateriales.Enabled = false;
            this.cmbListaMateriales.Font = new System.Drawing.Font("Calibri", 8F);
            this.cmbListaMateriales.FormattingEnabled = true;
            this.cmbListaMateriales.Location = new System.Drawing.Point(299, 61);
            this.cmbListaMateriales.Name = "cmbListaMateriales";
            this.cmbListaMateriales.Size = new System.Drawing.Size(124, 21);
            this.cmbListaMateriales.TabIndex = 2;
            this.cmbListaMateriales.ValueMember = "IDMATERIAL";
            this.cmbListaMateriales.SelectedIndexChanged += new System.EventHandler(this.cmbListaMateriales_SelectedIndexChanged);
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // dgvStockDisponible
            // 
            this.dgvStockDisponible.AllowUserToAddRows = false;
            this.dgvStockDisponible.AllowUserToDeleteRows = false;
            this.dgvStockDisponible.AllowUserToResizeColumns = false;
            this.dgvStockDisponible.AllowUserToResizeRows = false;
            this.dgvStockDisponible.AutoGenerateColumns = false;
            this.dgvStockDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockDisponible.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDStockDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.KGTOADD,
            this.btnAddMaterial});
            this.dgvStockDisponible.DataSource = this.t0030STOCKBindingSource;
            this.dgvStockDisponible.Location = new System.Drawing.Point(12, 96);
            this.dgvStockDisponible.MultiSelect = false;
            this.dgvStockDisponible.Name = "dgvStockDisponible";
            this.dgvStockDisponible.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvStockDisponible.RowHeadersWidth = 20;
            this.dgvStockDisponible.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockDisponible.Size = new System.Drawing.Size(527, 164);
            this.dgvStockDisponible.TabIndex = 3;
            this.dgvStockDisponible.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockDisponible_CellContentClick);
            // 
            // iDStockDataGridViewTextBoxColumn
            // 
            this.iDStockDataGridViewTextBoxColumn.DataPropertyName = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.HeaderText = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.Name = "iDStockDataGridViewTextBoxColumn";
            this.iDStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDStockDataGridViewTextBoxColumn.Visible = false;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            this.materialDataGridViewTextBoxColumn.Width = 150;
            // 
            // batchDataGridViewTextBoxColumn
            // 
            this.batchDataGridViewTextBoxColumn.DataPropertyName = "Batch";
            this.batchDataGridViewTextBoxColumn.HeaderText = "LOTE";
            this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
            this.batchDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchDataGridViewTextBoxColumn.Width = 80;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            this.stockDataGridViewTextBoxColumn.HeaderText = "KG";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockDataGridViewTextBoxColumn.Width = 60;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "ESTADO";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // KGTOADD
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Format = "n2";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.KGTOADD.DefaultCellStyle = dataGridViewCellStyle1;
            this.KGTOADD.HeaderText = "KG ADD";
            this.KGTOADD.Name = "KGTOADD";
            this.KGTOADD.Width = 70;
            // 
            // btnAddMaterial
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.btnAddMaterial.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnAddMaterial.HeaderText = "ADD";
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Text = "ADD";
            this.btnAddMaterial.ToolTipText = "Agregar Material al Plan";
            this.btnAddMaterial.UseColumnTextForButtonValue = true;
            this.btnAddMaterial.Width = 40;
            // 
            // t0030STOCKBindingSource
            // 
            this.t0030STOCKBindingSource.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(467, 30);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(72, 30);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "CANCELAR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtNumeroFormula
            // 
            this.txtNumeroFormula.Font = new System.Drawing.Font("Calibri", 9F);
            this.txtNumeroFormula.Location = new System.Drawing.Point(139, 30);
            this.txtNumeroFormula.Name = "txtNumeroFormula";
            this.txtNumeroFormula.ReadOnly = true;
            this.txtNumeroFormula.Size = new System.Drawing.Size(57, 22);
            this.txtNumeroFormula.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F);
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "NUMERO FORMULA";
            // 
            // txtDescripcionFormula
            // 
            this.txtDescripcionFormula.Font = new System.Drawing.Font("Calibri", 9F);
            this.txtDescripcionFormula.Location = new System.Drawing.Point(197, 30);
            this.txtDescripcionFormula.Name = "txtDescripcionFormula";
            this.txtDescripcionFormula.ReadOnly = true;
            this.txtDescripcionFormula.Size = new System.Drawing.Size(226, 22);
            this.txtDescripcionFormula.TabIndex = 7;
            // 
            // ckSoloFusion
            // 
            this.ckSoloFusion.AutoSize = true;
            this.ckSoloFusion.Checked = true;
            this.ckSoloFusion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSoloFusion.Enabled = false;
            this.ckSoloFusion.Font = new System.Drawing.Font("Calibri", 8F);
            this.ckSoloFusion.Location = new System.Drawing.Point(15, 63);
            this.ckSoloFusion.Name = "ckSoloFusion";
            this.ckSoloFusion.Size = new System.Drawing.Size(278, 17);
            this.ckSoloFusion.TabIndex = 8;
            this.ckSoloFusion.Text = "VER SOLO STOCK PARA FUSION/REPROCESO DE MATERIAL";
            this.ckSoloFusion.UseMnemonic = false;
            this.ckSoloFusion.UseVisualStyleBackColor = true;
            this.ckSoloFusion.CheckedChanged += new System.EventHandler(this.ckSoloFusion_CheckedChanged);
            // 
            // FrmOrdenFabricacioAgregarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 267);
            this.Controls.Add(this.ckSoloFusion);
            this.Controls.Add(this.txtDescripcionFormula);
            this.Controls.Add(this.txtNumeroFormula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvStockDisponible);
            this.Controls.Add(this.cmbListaMateriales);
            this.Controls.Add(this.txtMaterialFabricar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.Name = "FrmOrdenFabricacioAgregarItem";
            this.Text = "AGREGAR ITEM A ORDEN DE FABRICACION (FUSION DE MATERIAL)";
            this.Load += new System.EventHandler(this.FrmOrdenFabricacioAgregarItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaterialFabricar;
        private System.Windows.Forms.ComboBox cmbListaMateriales;
        private System.Windows.Forms.DataGridView dgvStockDisponible;
        private System.Windows.Forms.BindingSource t0030STOCKBindingSource;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtNumeroFormula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcionFormula;
        private System.Windows.Forms.CheckBox ckSoloFusion;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KGTOADD;
        private System.Windows.Forms.DataGridViewButtonColumn btnAddMaterial;
    }
}