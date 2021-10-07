namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmDetalle203
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
            this.dgvLista203 = new System.Windows.Forms.DataGridView();
            this.t203Bs = new System.Windows.Forms.BindingSource(this.components);
            this.iDCTACTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dOCINTERNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zTERMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDPROVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONEDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEORIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEARSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALDOFACTURADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zOPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFacturaXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista203)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t203Bs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLista203
            // 
            this.dgvLista203.AllowUserToAddRows = false;
            this.dgvLista203.AllowUserToDeleteRows = false;
            this.dgvLista203.AutoGenerateColumns = false;
            this.dgvLista203.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista203.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCTACTEDataGridViewTextBoxColumn,
            this.tDOCDataGridViewTextBoxColumn,
            this.dOCINTERNODataGridViewTextBoxColumn,
            this.nUMDOCDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.zTERMDataGridViewTextBoxColumn,
            this.iDPROVDataGridViewTextBoxColumn,
            this.mONEDADataGridViewTextBoxColumn,
            this.tCDataGridViewTextBoxColumn,
            this.iMPORTEORIDataGridViewTextBoxColumn,
            this.iMPORTEARSDataGridViewTextBoxColumn,
            this.sALDOFACTURADataGridViewTextBoxColumn,
            this.logDateDataGridViewTextBoxColumn,
            this.logUsuarioDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.zOPDataGridViewTextBoxColumn,
            this.idFacturaXDataGridViewTextBoxColumn,
            this.iDDOCDataGridViewTextBoxColumn});
            this.dgvLista203.DataSource = this.t203Bs;
            this.dgvLista203.Location = new System.Drawing.Point(13, 211);
            this.dgvLista203.Name = "dgvLista203";
            this.dgvLista203.ReadOnly = true;
            this.dgvLista203.Size = new System.Drawing.Size(1131, 430);
            this.dgvLista203.TabIndex = 0;
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
            // 
            // dOCINTERNODataGridViewTextBoxColumn
            // 
            this.dOCINTERNODataGridViewTextBoxColumn.DataPropertyName = "DOC_INTERNO";
            this.dOCINTERNODataGridViewTextBoxColumn.HeaderText = "DOC_INTERNO";
            this.dOCINTERNODataGridViewTextBoxColumn.Name = "dOCINTERNODataGridViewTextBoxColumn";
            this.dOCINTERNODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nUMDOCDataGridViewTextBoxColumn
            // 
            this.nUMDOCDataGridViewTextBoxColumn.DataPropertyName = "NUMDOC";
            this.nUMDOCDataGridViewTextBoxColumn.HeaderText = "NUMDOC";
            this.nUMDOCDataGridViewTextBoxColumn.Name = "nUMDOCDataGridViewTextBoxColumn";
            this.nUMDOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zTERMDataGridViewTextBoxColumn
            // 
            this.zTERMDataGridViewTextBoxColumn.DataPropertyName = "ZTERM";
            this.zTERMDataGridViewTextBoxColumn.HeaderText = "ZTERM";
            this.zTERMDataGridViewTextBoxColumn.Name = "zTERMDataGridViewTextBoxColumn";
            this.zTERMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDPROVDataGridViewTextBoxColumn
            // 
            this.iDPROVDataGridViewTextBoxColumn.DataPropertyName = "IDPROV";
            this.iDPROVDataGridViewTextBoxColumn.HeaderText = "IDPROV";
            this.iDPROVDataGridViewTextBoxColumn.Name = "iDPROVDataGridViewTextBoxColumn";
            this.iDPROVDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mONEDADataGridViewTextBoxColumn
            // 
            this.mONEDADataGridViewTextBoxColumn.DataPropertyName = "MONEDA";
            this.mONEDADataGridViewTextBoxColumn.HeaderText = "MONEDA";
            this.mONEDADataGridViewTextBoxColumn.Name = "mONEDADataGridViewTextBoxColumn";
            this.mONEDADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tCDataGridViewTextBoxColumn
            // 
            this.tCDataGridViewTextBoxColumn.DataPropertyName = "TC";
            this.tCDataGridViewTextBoxColumn.HeaderText = "TC";
            this.tCDataGridViewTextBoxColumn.Name = "tCDataGridViewTextBoxColumn";
            this.tCDataGridViewTextBoxColumn.ReadOnly = true;
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
            // logDateDataGridViewTextBoxColumn
            // 
            this.logDateDataGridViewTextBoxColumn.DataPropertyName = "LogDate";
            this.logDateDataGridViewTextBoxColumn.HeaderText = "LogDate";
            this.logDateDataGridViewTextBoxColumn.Name = "logDateDataGridViewTextBoxColumn";
            this.logDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logUsuarioDataGridViewTextBoxColumn
            // 
            this.logUsuarioDataGridViewTextBoxColumn.DataPropertyName = "LogUsuario";
            this.logUsuarioDataGridViewTextBoxColumn.HeaderText = "LogUsuario";
            this.logUsuarioDataGridViewTextBoxColumn.Name = "logUsuarioDataGridViewTextBoxColumn";
            this.logUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zOPDataGridViewTextBoxColumn
            // 
            this.zOPDataGridViewTextBoxColumn.DataPropertyName = "ZOP";
            this.zOPDataGridViewTextBoxColumn.HeaderText = "ZOP";
            this.zOPDataGridViewTextBoxColumn.Name = "zOPDataGridViewTextBoxColumn";
            this.zOPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idFacturaXDataGridViewTextBoxColumn
            // 
            this.idFacturaXDataGridViewTextBoxColumn.DataPropertyName = "IdFacturaX";
            this.idFacturaXDataGridViewTextBoxColumn.HeaderText = "IdFacturaX";
            this.idFacturaXDataGridViewTextBoxColumn.Name = "idFacturaXDataGridViewTextBoxColumn";
            this.idFacturaXDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDDOCDataGridViewTextBoxColumn
            // 
            this.iDDOCDataGridViewTextBoxColumn.DataPropertyName = "IDDOC";
            this.iDDOCDataGridViewTextBoxColumn.HeaderText = "IDDOC";
            this.iDDOCDataGridViewTextBoxColumn.Name = "iDDOCDataGridViewTextBoxColumn";
            this.iDDOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmDetalle203
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 757);
            this.Controls.Add(this.dgvLista203);
            this.Name = "FrmDetalle203";
            this.Text = "FrmDetalle203";
            this.Load += new System.EventHandler(this.FrmDetalle203_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista203)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t203Bs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLista203;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCTACTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dOCINTERNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zTERMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDPROVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONEDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEORIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEARSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALDOFACTURADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logUsuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zOPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFacturaXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource t203Bs;
    }
}