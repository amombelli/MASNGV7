namespace MASngFE.Transactional.FI.ContabilizacioFactura.SinRemito
{
    partial class FrmInfoRecordContaR
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
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.iTEMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRECIOUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rECUERDAPRECIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gLPATHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOGDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOGUSERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0066ITEMSPROVEEDOROCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0066ITEMSPROVEEDOROCBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AutoGenerateColumns = false;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iTEMDataGridViewTextBoxColumn,
            this.mONDataGridViewTextBoxColumn,
            this.pRECIOUDataGridViewTextBoxColumn,
            this.gLDataGridViewTextBoxColumn,
            this.rECUERDAPRECIODataGridViewTextBoxColumn,
            this.gLPATHDataGridViewTextBoxColumn,
            this.lOGDATEDataGridViewTextBoxColumn,
            this.lOGUSERDataGridViewTextBoxColumn});
            this.dgvItems.DataSource = this.t0066ITEMSPROVEEDOROCBindingSource;
            this.dgvItems.Location = new System.Drawing.Point(12, 29);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Size = new System.Drawing.Size(900, 206);
            this.dgvItems.TabIndex = 0;
            // 
            // iTEMDataGridViewTextBoxColumn
            // 
            this.iTEMDataGridViewTextBoxColumn.DataPropertyName = "ITEM";
            this.iTEMDataGridViewTextBoxColumn.HeaderText = "ITEM";
            this.iTEMDataGridViewTextBoxColumn.Name = "iTEMDataGridViewTextBoxColumn";
            this.iTEMDataGridViewTextBoxColumn.Width = 200;
            // 
            // mONDataGridViewTextBoxColumn
            // 
            this.mONDataGridViewTextBoxColumn.DataPropertyName = "MON";
            this.mONDataGridViewTextBoxColumn.HeaderText = "MON";
            this.mONDataGridViewTextBoxColumn.Name = "mONDataGridViewTextBoxColumn";
            this.mONDataGridViewTextBoxColumn.Width = 40;
            // 
            // pRECIOUDataGridViewTextBoxColumn
            // 
            this.pRECIOUDataGridViewTextBoxColumn.DataPropertyName = "PRECIO_U";
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.pRECIOUDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.pRECIOUDataGridViewTextBoxColumn.HeaderText = "PRECIO U";
            this.pRECIOUDataGridViewTextBoxColumn.Name = "pRECIOUDataGridViewTextBoxColumn";
            // 
            // gLDataGridViewTextBoxColumn
            // 
            this.gLDataGridViewTextBoxColumn.DataPropertyName = "GL";
            this.gLDataGridViewTextBoxColumn.HeaderText = "GL";
            this.gLDataGridViewTextBoxColumn.Name = "gLDataGridViewTextBoxColumn";
            this.gLDataGridViewTextBoxColumn.Width = 80;
            // 
            // rECUERDAPRECIODataGridViewTextBoxColumn
            // 
            this.rECUERDAPRECIODataGridViewTextBoxColumn.DataPropertyName = "RECUERDA_PRECIO";
            this.rECUERDAPRECIODataGridViewTextBoxColumn.HeaderText = "RPRECIO";
            this.rECUERDAPRECIODataGridViewTextBoxColumn.Name = "rECUERDAPRECIODataGridViewTextBoxColumn";
            this.rECUERDAPRECIODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.rECUERDAPRECIODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.rECUERDAPRECIODataGridViewTextBoxColumn.ToolTipText = "Recuerda Precio";
            this.rECUERDAPRECIODataGridViewTextBoxColumn.Width = 80;
            // 
            // gLPATHDataGridViewTextBoxColumn
            // 
            this.gLPATHDataGridViewTextBoxColumn.DataPropertyName = "GLPATH";
            this.gLPATHDataGridViewTextBoxColumn.HeaderText = "GLPATH";
            this.gLPATHDataGridViewTextBoxColumn.Name = "gLPATHDataGridViewTextBoxColumn";
            this.gLPATHDataGridViewTextBoxColumn.Width = 80;
            // 
            // lOGDATEDataGridViewTextBoxColumn
            // 
            this.lOGDATEDataGridViewTextBoxColumn.DataPropertyName = "LOGDATE";
            this.lOGDATEDataGridViewTextBoxColumn.HeaderText = "LOGDATE";
            this.lOGDATEDataGridViewTextBoxColumn.Name = "lOGDATEDataGridViewTextBoxColumn";
            // 
            // lOGUSERDataGridViewTextBoxColumn
            // 
            this.lOGUSERDataGridViewTextBoxColumn.DataPropertyName = "LOGUSER";
            this.lOGUSERDataGridViewTextBoxColumn.HeaderText = "LOGUSER";
            this.lOGUSERDataGridViewTextBoxColumn.Name = "lOGUSERDataGridViewTextBoxColumn";
            // 
            // t0066ITEMSPROVEEDOROCBindingSource
            // 
            this.t0066ITEMSPROVEEDOROCBindingSource.DataSource = typeof(TecserEF.Entity.T0066_ITEMS_PROVEEDOR_OC);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(918, 29);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(85, 35);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmInfoRecordContaR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 290);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvItems);
            this.Name = "FrmInfoRecordContaR";
            this.Text = "FI21 - Detalle de Inforecord [CONTAR]";
            this.Load += new System.EventHandler(this.FrmInfoRecordContaR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0066ITEMSPROVEEDOROCBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.BindingSource t0066ITEMSPROVEEDOROCBindingSource;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTEMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRECIOUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rECUERDAPRECIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gLPATHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOGDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOGUSERDataGridViewTextBoxColumn;
    }
}