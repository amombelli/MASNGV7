namespace MASngFE.Transactional.MM.MRP
{
    partial class FrmMRP03
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMRPCompleto = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.mRP2Bs = new System.Windows.Forms.BindingSource(this.components);
            this.materialMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantRequiredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockLiberadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalComprometidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaHoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMRPCompleto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRP2Bs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMRPCompleto
            // 
            this.dgvMRPCompleto.AllowUserToAddRows = false;
            this.dgvMRPCompleto.AllowUserToDeleteRows = false;
            this.dgvMRPCompleto.AutoGenerateColumns = false;
            this.dgvMRPCompleto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMRPCompleto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.materialMPDataGridViewTextBoxColumn,
            this.cantRequiredDataGridViewTextBoxColumn,
            this.stockLiberadoDataGridViewTextBoxColumn,
            this.totalComprometidoDataGridViewTextBoxColumn,
            this.StockTotal,
            this.fechaHoraDataGridViewTextBoxColumn,
            this.Detalle});
            this.dgvMRPCompleto.DataSource = this.mRP2Bs;
            this.dgvMRPCompleto.GridColor = System.Drawing.Color.SeaGreen;
            this.dgvMRPCompleto.Location = new System.Drawing.Point(5, 46);
            this.dgvMRPCompleto.Name = "dgvMRPCompleto";
            this.dgvMRPCompleto.ReadOnly = true;
            this.dgvMRPCompleto.RowHeadersWidth = 20;
            this.dgvMRPCompleto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMRPCompleto.Size = new System.Drawing.Size(613, 606);
            this.dgvMRPCompleto.TabIndex = 63;
            this.dgvMRPCompleto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvMRPCompleto_CellContentClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(525, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 41);
            this.btnSalir.TabIndex = 64;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // mRP2Bs
            // 
            this.mRP2Bs.DataSource = typeof(TecserEF.Entity.DataStructure.MRP.MRP2Struct);
            // 
            // materialMPDataGridViewTextBoxColumn
            // 
            this.materialMPDataGridViewTextBoxColumn.DataPropertyName = "MaterialMP";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.materialMPDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.materialMPDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialMPDataGridViewTextBoxColumn.Name = "materialMPDataGridViewTextBoxColumn";
            this.materialMPDataGridViewTextBoxColumn.ReadOnly = true;
            this.materialMPDataGridViewTextBoxColumn.ToolTipText = "Materia Prima";
            // 
            // cantRequiredDataGridViewTextBoxColumn
            // 
            this.cantRequiredDataGridViewTextBoxColumn.DataPropertyName = "CantRequired";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle8.Format = "N2";
            this.cantRequiredDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.cantRequiredDataGridViewTextBoxColumn.HeaderText = "Requerido";
            this.cantRequiredDataGridViewTextBoxColumn.Name = "cantRequiredDataGridViewTextBoxColumn";
            this.cantRequiredDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantRequiredDataGridViewTextBoxColumn.ToolTipText = "KG Requerido por Ordenes de Fabricacion";
            this.cantRequiredDataGridViewTextBoxColumn.Width = 70;
            // 
            // stockLiberadoDataGridViewTextBoxColumn
            // 
            this.stockLiberadoDataGridViewTextBoxColumn.DataPropertyName = "StockDispProd";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Format = "N2";
            this.stockLiberadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.stockLiberadoDataGridViewTextBoxColumn.HeaderText = "Stk DP";
            this.stockLiberadoDataGridViewTextBoxColumn.Name = "stockLiberadoDataGridViewTextBoxColumn";
            this.stockLiberadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockLiberadoDataGridViewTextBoxColumn.ToolTipText = "Stock Disponible para Produccion";
            this.stockLiberadoDataGridViewTextBoxColumn.Width = 70;
            // 
            // totalComprometidoDataGridViewTextBoxColumn
            // 
            this.totalComprometidoDataGridViewTextBoxColumn.DataPropertyName = "StockReservado";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle10.Format = "N2";
            this.totalComprometidoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.totalComprometidoDataGridViewTextBoxColumn.HeaderText = "Stk RE";
            this.totalComprometidoDataGridViewTextBoxColumn.Name = "totalComprometidoDataGridViewTextBoxColumn";
            this.totalComprometidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalComprometidoDataGridViewTextBoxColumn.ToolTipText = "Stock Reservado";
            this.totalComprometidoDataGridViewTextBoxColumn.Width = 70;
            // 
            // StockTotal
            // 
            this.StockTotal.DataPropertyName = "StockTotal";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.Format = "N2";
            this.StockTotal.DefaultCellStyle = dataGridViewCellStyle11;
            this.StockTotal.HeaderText = "Stk Total";
            this.StockTotal.Name = "StockTotal";
            this.StockTotal.ReadOnly = true;
            this.StockTotal.Width = 80;
            // 
            // fechaHoraDataGridViewTextBoxColumn
            // 
            this.fechaHoraDataGridViewTextBoxColumn.DataPropertyName = "FechaHora";
            dataGridViewCellStyle12.Format = "g";
            dataGridViewCellStyle12.NullValue = null;
            this.fechaHoraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.fechaHoraDataGridViewTextBoxColumn.HeaderText = "FechaHora";
            this.fechaHoraDataGridViewTextBoxColumn.Name = "fechaHoraDataGridViewTextBoxColumn";
            this.fechaHoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaHoraDataGridViewTextBoxColumn.Width = 120;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Text = "Detalle";
            this.Detalle.ToolTipText = "Ver Detalle de Stock";
            this.Detalle.UseColumnTextForButtonValue = true;
            this.Detalle.Width = 60;
            // 
            // FrmMRP03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 678);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvMRPCompleto);
            this.Name = "FrmMRP03";
            this.Text = "MRP03 - Listado de Materias Primas";
            this.Load += new System.EventHandler(this.FrmMRP03_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMRPCompleto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRP2Bs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMRPCompleto;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.BindingSource mRP2Bs;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantRequiredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockLiberadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalComprometidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaHoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Detalle;
    }
}