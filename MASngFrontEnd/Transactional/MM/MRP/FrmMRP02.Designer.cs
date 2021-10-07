namespace MASngFE.Transactional.MM.MRP
{
    partial class FrmMRP02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMRP02));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMRPCompleto = new System.Windows.Forms.DataGridView();
            this.btnMPConsolidaList = new System.Windows.Forms.Button();
            this.btnRunAll = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ckProceso = new System.Windows.Forms.CheckBox();
            this.ckPlaneado = new System.Windows.Forms.CheckBox();
            this.ckStandBy = new System.Windows.Forms.CheckBox();
            this.ckFormulado = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MrpCompletoBs = new System.Windows.Forms.BindingSource(this.components);
            this.materialMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantRequiredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenFabDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusOFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialFabDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgFabDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockLiberadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteAsignadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockReservado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMRPCompleto)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MrpCompletoBs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMRPCompleto
            // 
            this.dgvMRPCompleto.AllowUserToAddRows = false;
            this.dgvMRPCompleto.AllowUserToDeleteRows = false;
            this.dgvMRPCompleto.AllowUserToOrderColumns = true;
            this.dgvMRPCompleto.AutoGenerateColumns = false;
            this.dgvMRPCompleto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMRPCompleto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materialMPDataGridViewTextBoxColumn,
            this.cantRequiredDataGridViewTextBoxColumn,
            this.ordenFabDataGridViewTextBoxColumn,
            this.statusOFDataGridViewTextBoxColumn,
            this.materialFabDataGridViewTextBoxColumn,
            this.kgFabDataGridViewTextBoxColumn,
            this.stockLiberadoDataGridViewTextBoxColumn,
            this.stockTotalDataGridViewTextBoxColumn,
            this.stockStatusDataGridViewTextBoxColumn,
            this.loteAsignadoDataGridViewTextBoxColumn,
            this.StockReservado});
            this.dgvMRPCompleto.DataSource = this.MrpCompletoBs;
            this.dgvMRPCompleto.GridColor = System.Drawing.Color.SeaGreen;
            this.dgvMRPCompleto.Location = new System.Drawing.Point(3, 84);
            this.dgvMRPCompleto.Name = "dgvMRPCompleto";
            this.dgvMRPCompleto.ReadOnly = true;
            this.dgvMRPCompleto.RowHeadersWidth = 20;
            this.dgvMRPCompleto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMRPCompleto.Size = new System.Drawing.Size(962, 762);
            this.dgvMRPCompleto.TabIndex = 62;
            // 
            // btnMPConsolidaList
            // 
            this.btnMPConsolidaList.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMPConsolidaList.Image = ((System.Drawing.Image)(resources.GetObject("btnMPConsolidaList.Image")));
            this.btnMPConsolidaList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMPConsolidaList.Location = new System.Drawing.Point(103, 5);
            this.btnMPConsolidaList.Name = "btnMPConsolidaList";
            this.btnMPConsolidaList.Size = new System.Drawing.Size(93, 41);
            this.btnMPConsolidaList.TabIndex = 64;
            this.btnMPConsolidaList.Text = "Lista MP";
            this.btnMPConsolidaList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMPConsolidaList.UseVisualStyleBackColor = true;
            this.btnMPConsolidaList.Click += new System.EventHandler(this.BtnMPConsolidaList_Click);
            // 
            // btnRunAll
            // 
            this.btnRunAll.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunAll.Image = ((System.Drawing.Image)(resources.GetObject("btnRunAll.Image")));
            this.btnRunAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunAll.Location = new System.Drawing.Point(4, 5);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(93, 41);
            this.btnRunAll.TabIndex = 63;
            this.btnRunAll.Text = "RUN All";
            this.btnRunAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunAll.UseVisualStyleBackColor = true;
            this.btnRunAll.Click += new System.EventHandler(this.BtnRunAll_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(872, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 41);
            this.btnSalir.TabIndex = 61;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // ckProceso
            // 
            this.ckProceso.AutoSize = true;
            this.ckProceso.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckProceso.Location = new System.Drawing.Point(6, 8);
            this.ckProceso.Name = "ckProceso";
            this.ckProceso.Size = new System.Drawing.Size(64, 17);
            this.ckProceso.TabIndex = 65;
            this.ckProceso.Text = "Proceso";
            this.ckProceso.UseVisualStyleBackColor = true;
            // 
            // ckPlaneado
            // 
            this.ckPlaneado.AutoSize = true;
            this.ckPlaneado.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckPlaneado.Location = new System.Drawing.Point(79, 8);
            this.ckPlaneado.Name = "ckPlaneado";
            this.ckPlaneado.Size = new System.Drawing.Size(69, 17);
            this.ckPlaneado.TabIndex = 66;
            this.ckPlaneado.Text = "Planeado";
            this.ckPlaneado.UseVisualStyleBackColor = true;
            // 
            // ckStandBy
            // 
            this.ckStandBy.AutoSize = true;
            this.ckStandBy.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckStandBy.Location = new System.Drawing.Point(237, 8);
            this.ckStandBy.Name = "ckStandBy";
            this.ckStandBy.Size = new System.Drawing.Size(65, 17);
            this.ckStandBy.TabIndex = 68;
            this.ckStandBy.Text = "StandBy";
            this.ckStandBy.UseVisualStyleBackColor = true;
            // 
            // ckFormulado
            // 
            this.ckFormulado.AutoSize = true;
            this.ckFormulado.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckFormulado.Location = new System.Drawing.Point(154, 8);
            this.ckFormulado.Name = "ckFormulado";
            this.ckFormulado.Size = new System.Drawing.Size(76, 17);
            this.ckFormulado.TabIndex = 67;
            this.ckFormulado.Text = "Formulado";
            this.ckFormulado.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.ckProceso);
            this.panel1.Controls.Add(this.ckStandBy);
            this.panel1.Controls.Add(this.ckPlaneado);
            this.panel1.Controls.Add(this.ckFormulado);
            this.panel1.Location = new System.Drawing.Point(3, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 31);
            this.panel1.TabIndex = 69;
            // 
            // MrpCompletoBs
            // 
            this.MrpCompletoBs.DataSource = typeof(TecserEF.Entity.DataStructure.MRP.MRP1Struct);
            // 
            // materialMPDataGridViewTextBoxColumn
            // 
            this.materialMPDataGridViewTextBoxColumn.DataPropertyName = "MaterialMP";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.materialMPDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.materialMPDataGridViewTextBoxColumn.HeaderText = "MaterialMP";
            this.materialMPDataGridViewTextBoxColumn.Name = "materialMPDataGridViewTextBoxColumn";
            this.materialMPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantRequiredDataGridViewTextBoxColumn
            // 
            this.cantRequiredDataGridViewTextBoxColumn.DataPropertyName = "CantRequired";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "N2";
            this.cantRequiredDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantRequiredDataGridViewTextBoxColumn.HeaderText = "KG Req";
            this.cantRequiredDataGridViewTextBoxColumn.Name = "cantRequiredDataGridViewTextBoxColumn";
            this.cantRequiredDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantRequiredDataGridViewTextBoxColumn.ToolTipText = "KG Requeridos de Materia Prima";
            this.cantRequiredDataGridViewTextBoxColumn.Width = 70;
            // 
            // ordenFabDataGridViewTextBoxColumn
            // 
            this.ordenFabDataGridViewTextBoxColumn.DataPropertyName = "OrdenFab";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ordenFabDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ordenFabDataGridViewTextBoxColumn.HeaderText = "OrdenFab";
            this.ordenFabDataGridViewTextBoxColumn.Name = "ordenFabDataGridViewTextBoxColumn";
            this.ordenFabDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordenFabDataGridViewTextBoxColumn.Width = 60;
            // 
            // statusOFDataGridViewTextBoxColumn
            // 
            this.statusOFDataGridViewTextBoxColumn.DataPropertyName = "StatusOF";
            this.statusOFDataGridViewTextBoxColumn.HeaderText = "StatusOF";
            this.statusOFDataGridViewTextBoxColumn.Name = "statusOFDataGridViewTextBoxColumn";
            this.statusOFDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusOFDataGridViewTextBoxColumn.Width = 80;
            // 
            // materialFabDataGridViewTextBoxColumn
            // 
            this.materialFabDataGridViewTextBoxColumn.DataPropertyName = "MaterialFab";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.materialFabDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.materialFabDataGridViewTextBoxColumn.HeaderText = "MaterialFab";
            this.materialFabDataGridViewTextBoxColumn.Name = "materialFabDataGridViewTextBoxColumn";
            this.materialFabDataGridViewTextBoxColumn.ReadOnly = true;
            this.materialFabDataGridViewTextBoxColumn.Width = 120;
            // 
            // kgFabDataGridViewTextBoxColumn
            // 
            this.kgFabDataGridViewTextBoxColumn.DataPropertyName = "KgFab";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Format = "N2";
            this.kgFabDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.kgFabDataGridViewTextBoxColumn.HeaderText = "KgFab";
            this.kgFabDataGridViewTextBoxColumn.Name = "kgFabDataGridViewTextBoxColumn";
            this.kgFabDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgFabDataGridViewTextBoxColumn.Width = 70;
            // 
            // stockLiberadoDataGridViewTextBoxColumn
            // 
            this.stockLiberadoDataGridViewTextBoxColumn.DataPropertyName = "StockDispProd";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.stockLiberadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.stockLiberadoDataGridViewTextBoxColumn.HeaderText = "Stk DP";
            this.stockLiberadoDataGridViewTextBoxColumn.Name = "stockLiberadoDataGridViewTextBoxColumn";
            this.stockLiberadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockLiberadoDataGridViewTextBoxColumn.Width = 70;
            // 
            // stockTotalDataGridViewTextBoxColumn
            // 
            this.stockTotalDataGridViewTextBoxColumn.DataPropertyName = "StockTotal";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Format = "N2";
            this.stockTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.stockTotalDataGridViewTextBoxColumn.HeaderText = "Stk TOT";
            this.stockTotalDataGridViewTextBoxColumn.Name = "stockTotalDataGridViewTextBoxColumn";
            this.stockTotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockTotalDataGridViewTextBoxColumn.Width = 75;
            // 
            // stockStatusDataGridViewTextBoxColumn
            // 
            this.stockStatusDataGridViewTextBoxColumn.DataPropertyName = "StockStatus";
            dataGridViewCellStyle8.Format = "N2";
            this.stockStatusDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.stockStatusDataGridViewTextBoxColumn.HeaderText = "StockStatus";
            this.stockStatusDataGridViewTextBoxColumn.Name = "stockStatusDataGridViewTextBoxColumn";
            this.stockStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // loteAsignadoDataGridViewTextBoxColumn
            // 
            this.loteAsignadoDataGridViewTextBoxColumn.DataPropertyName = "LoteAsignado";
            this.loteAsignadoDataGridViewTextBoxColumn.HeaderText = "LoteAsignado";
            this.loteAsignadoDataGridViewTextBoxColumn.Name = "loteAsignadoDataGridViewTextBoxColumn";
            this.loteAsignadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StockReservado
            // 
            this.StockReservado.DataPropertyName = "StockReservado";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.StockReservado.DefaultCellStyle = dataGridViewCellStyle9;
            this.StockReservado.HeaderText = "Stk RE";
            this.StockReservado.Name = "StockReservado";
            this.StockReservado.ReadOnly = true;
            this.StockReservado.Width = 70;
            // 
            // FrmMRP02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 849);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMPConsolidaList);
            this.Controls.Add(this.btnRunAll);
            this.Controls.Add(this.dgvMRPCompleto);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmMRP02";
            this.Text = "MRP02 - Main Data";
            this.Load += new System.EventHandler(this.FrmMRP02_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMRPCompleto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MrpCompletoBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvMRPCompleto;
        private System.Windows.Forms.BindingSource MrpCompletoBs;
        private System.Windows.Forms.Button btnRunAll;
        private System.Windows.Forms.Button btnMPConsolidaList;
        private System.Windows.Forms.CheckBox ckProceso;
        private System.Windows.Forms.CheckBox ckPlaneado;
        private System.Windows.Forms.CheckBox ckStandBy;
        private System.Windows.Forms.CheckBox ckFormulado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantRequiredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenFabDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusOFDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialFabDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgFabDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockLiberadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteAsignadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockReservado;
    }
}