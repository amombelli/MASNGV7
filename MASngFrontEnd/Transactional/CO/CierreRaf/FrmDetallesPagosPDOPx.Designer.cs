namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmDetallesPagosPDOPx
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.t203Bs = new System.Windows.Forms.BindingSource(this.components);
            this.iDCTACTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEORIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEARSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALDOFACTURADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t203Bs)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCTACTEDataGridViewTextBoxColumn,
            this.tDOCDataGridViewTextBoxColumn,
            this.nUMDOCDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.iMPORTEORIDataGridViewTextBoxColumn,
            this.iMPORTEARSDataGridViewTextBoxColumn,
            this.sALDOFACTURADataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.t203Bs;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(772, 616);
            this.dataGridView1.TabIndex = 0;
            // 
            // t203Bs
            // 
            this.t203Bs.DataSource = typeof(TecserEF.Entity.T0203_CTACTE_PROV);
            // 
            // iDCTACTEDataGridViewTextBoxColumn
            // 
            this.iDCTACTEDataGridViewTextBoxColumn.DataPropertyName = "IDCTACTE";
            this.iDCTACTEDataGridViewTextBoxColumn.HeaderText = "IDCTACTE";
            this.iDCTACTEDataGridViewTextBoxColumn.Name = "iDCTACTEDataGridViewTextBoxColumn";
            this.iDCTACTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tDOCDataGridViewTextBoxColumn
            // 
            this.tDOCDataGridViewTextBoxColumn.DataPropertyName = "TDOC";
            this.tDOCDataGridViewTextBoxColumn.HeaderText = "TDOC";
            this.tDOCDataGridViewTextBoxColumn.Name = "tDOCDataGridViewTextBoxColumn";
            this.tDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tDOCDataGridViewTextBoxColumn.Width = 40;
            // 
            // nUMDOCDataGridViewTextBoxColumn
            // 
            this.nUMDOCDataGridViewTextBoxColumn.DataPropertyName = "NUMDOC";
            this.nUMDOCDataGridViewTextBoxColumn.HeaderText = "NUMDOC";
            this.nUMDOCDataGridViewTextBoxColumn.Name = "nUMDOCDataGridViewTextBoxColumn";
            this.nUMDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.nUMDOCDataGridViewTextBoxColumn.Width = 80;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iMPORTEORIDataGridViewTextBoxColumn
            // 
            this.iMPORTEORIDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE_ORI";
            this.iMPORTEORIDataGridViewTextBoxColumn.HeaderText = "IMPORTE_ORI";
            this.iMPORTEORIDataGridViewTextBoxColumn.Name = "iMPORTEORIDataGridViewTextBoxColumn";
            this.iMPORTEORIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iMPORTEARSDataGridViewTextBoxColumn
            // 
            this.iMPORTEARSDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE_ARS";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "C2";
            this.iMPORTEARSDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.iMPORTEARSDataGridViewTextBoxColumn.HeaderText = "IMPORTE_ARS";
            this.iMPORTEARSDataGridViewTextBoxColumn.Name = "iMPORTEARSDataGridViewTextBoxColumn";
            this.iMPORTEARSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sALDOFACTURADataGridViewTextBoxColumn
            // 
            this.sALDOFACTURADataGridViewTextBoxColumn.DataPropertyName = "SALDOFACTURA";
            this.sALDOFACTURADataGridViewTextBoxColumn.HeaderText = "SALDOFACTURA";
            this.sALDOFACTURADataGridViewTextBoxColumn.Name = "sALDOFACTURADataGridViewTextBoxColumn";
            this.sALDOFACTURADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmDetallesPagosPDOPx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 759);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmDetallesPagosPDOPx";
            this.Text = "FrmDetallesPagosPDOPx";
            this.Load += new System.EventHandler(this.FrmDetallesPagosPDOPx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t203Bs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCTACTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEORIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEARSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALDOFACTURADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource t203Bs;
    }
}