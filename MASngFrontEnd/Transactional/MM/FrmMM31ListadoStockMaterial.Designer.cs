namespace MASngFE.Transactional.MM
{
    partial class FrmMM31ListadoStockMaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.ckOcultarPerdido = new System.Windows.Forms.CheckBox();
            this.dgvStockList = new System.Windows.Forms.DataGridView();
            this.cqStockStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Idstock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalKgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdOrdenVentaReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialOF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cqStockStructureBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(909, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 41);
            this.btnSalir.TabIndex = 65;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.ckOcultarPerdido);
            this.panel1.Controls.Add(this.txtMaterial);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 49);
            this.panel1.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Material";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterial.Location = new System.Drawing.Point(67, 7);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(138, 20);
            this.txtMaterial.TabIndex = 1;
            // 
            // ckOcultarPerdido
            // 
            this.ckOcultarPerdido.AutoSize = true;
            this.ckOcultarPerdido.Location = new System.Drawing.Point(771, 6);
            this.ckOcultarPerdido.Name = "ckOcultarPerdido";
            this.ckOcultarPerdido.Size = new System.Drawing.Size(128, 19);
            this.ckOcultarPerdido.TabIndex = 2;
            this.ckOcultarPerdido.Text = "Ocultar Stock PERD";
            this.ckOcultarPerdido.UseVisualStyleBackColor = true;
            this.ckOcultarPerdido.CheckedChanged += new System.EventHandler(this.CkOcultarPerdido_CheckedChanged);
            // 
            // dgvStockList
            // 
            this.dgvStockList.AllowUserToAddRows = false;
            this.dgvStockList.AllowUserToDeleteRows = false;
            this.dgvStockList.AutoGenerateColumns = false;
            this.dgvStockList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idstock,
            this.materialDataGridViewTextBoxColumn,
            this.MaterialType,
            this.loteDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.totalKgDataGridViewTextBoxColumn,
            this.sLOCDataGridViewTextBoxColumn,
            this.IdOrdenVentaReserva,
            this.clienteReservaDataGridViewTextBoxColumn,
            this.documentoReservaDataGridViewTextBoxColumn,
            this.estadoReservaDataGridViewTextBoxColumn,
            this.MaterialOF});
            this.dgvStockList.DataSource = this.cqStockStructureBindingSource;
            this.dgvStockList.GridColor = System.Drawing.Color.Navy;
            this.dgvStockList.Location = new System.Drawing.Point(3, 55);
            this.dgvStockList.Name = "dgvStockList";
            this.dgvStockList.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockList.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvStockList.RowHeadersWidth = 20;
            this.dgvStockList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStockList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockList.Size = new System.Drawing.Size(1009, 670);
            this.dgvStockList.TabIndex = 67;
            // 
            // cqStockStructureBindingSource
            // 
            this.cqStockStructureBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.CqStockStructure);
            // 
            // Idstock
            // 
            this.Idstock.DataPropertyName = "Idstock";
            this.Idstock.HeaderText = "Idstock";
            this.Idstock.Name = "Idstock";
            this.Idstock.ReadOnly = true;
            this.Idstock.Visible = false;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.materialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MaterialType
            // 
            this.MaterialType.DataPropertyName = "MaterialType";
            this.MaterialType.HeaderText = "MType";
            this.MaterialType.Name = "MaterialType";
            this.MaterialType.ReadOnly = true;
            this.MaterialType.Width = 55;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            this.loteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote #";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado Mat";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalKgDataGridViewTextBoxColumn
            // 
            this.totalKgDataGridViewTextBoxColumn.DataPropertyName = "TotalKg";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.totalKgDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalKgDataGridViewTextBoxColumn.HeaderText = "KG Tot";
            this.totalKgDataGridViewTextBoxColumn.Name = "totalKgDataGridViewTextBoxColumn";
            this.totalKgDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalKgDataGridViewTextBoxColumn.Width = 80;
            // 
            // sLOCDataGridViewTextBoxColumn
            // 
            this.sLOCDataGridViewTextBoxColumn.DataPropertyName = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.HeaderText = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.Name = "sLOCDataGridViewTextBoxColumn";
            this.sLOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sLOCDataGridViewTextBoxColumn.Width = 50;
            // 
            // IdOrdenVentaReserva
            // 
            this.IdOrdenVentaReserva.DataPropertyName = "IdOrdenVentaReserva";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Indigo;
            this.IdOrdenVentaReserva.DefaultCellStyle = dataGridViewCellStyle5;
            this.IdOrdenVentaReserva.HeaderText = "NP #";
            this.IdOrdenVentaReserva.Name = "IdOrdenVentaReserva";
            this.IdOrdenVentaReserva.ReadOnly = true;
            this.IdOrdenVentaReserva.Width = 70;
            // 
            // clienteReservaDataGridViewTextBoxColumn
            // 
            this.clienteReservaDataGridViewTextBoxColumn.DataPropertyName = "ClienteReserva";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Indigo;
            this.clienteReservaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.clienteReservaDataGridViewTextBoxColumn.HeaderText = "Comprometido Para";
            this.clienteReservaDataGridViewTextBoxColumn.Name = "clienteReservaDataGridViewTextBoxColumn";
            this.clienteReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteReservaDataGridViewTextBoxColumn.Width = 150;
            // 
            // documentoReservaDataGridViewTextBoxColumn
            // 
            this.documentoReservaDataGridViewTextBoxColumn.DataPropertyName = "DocumentoReserva";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Indigo;
            this.documentoReservaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.documentoReservaDataGridViewTextBoxColumn.HeaderText = "OF #";
            this.documentoReservaDataGridViewTextBoxColumn.Name = "documentoReservaDataGridViewTextBoxColumn";
            this.documentoReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.documentoReservaDataGridViewTextBoxColumn.Width = 75;
            // 
            // estadoReservaDataGridViewTextBoxColumn
            // 
            this.estadoReservaDataGridViewTextBoxColumn.DataPropertyName = "EstadoReserva";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Indigo;
            this.estadoReservaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.estadoReservaDataGridViewTextBoxColumn.HeaderText = "OF Estado";
            this.estadoReservaDataGridViewTextBoxColumn.Name = "estadoReservaDataGridViewTextBoxColumn";
            this.estadoReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoReservaDataGridViewTextBoxColumn.Width = 90;
            // 
            // MaterialOF
            // 
            this.MaterialOF.DataPropertyName = "MaterialOF";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Indigo;
            this.MaterialOF.DefaultCellStyle = dataGridViewCellStyle9;
            this.MaterialOF.HeaderText = "OF Material";
            this.MaterialOF.Name = "MaterialOF";
            this.MaterialOF.ReadOnly = true;
            this.MaterialOF.Width = 110;
            // 
            // FrmMM31ListadoStockMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 742);
            this.Controls.Add(this.dgvStockList);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMM31ListadoStockMaterial";
            this.Text = "MM31 - Listado Stock Material";
            this.Load += new System.EventHandler(this.FrmMM31ListadoStockMaterial_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cqStockStructureBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckOcultarPerdido;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource cqStockStructureBindingSource;
        private System.Windows.Forms.DataGridView dgvStockList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idstock;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialType;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalKgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrdenVentaReserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialOF;
    }
}