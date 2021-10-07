namespace MASngFE.Transactional.CO.CierreRaf
{
    partial class FrmDetalleEgresosREG
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
            this.dgvDetallesEgresos = new System.Windows.Forms.DataGridView();
            this.regBs = new System.Windows.Forms.BindingSource(this.components);
            this.iDTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xMESDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xYEARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xTransfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logFechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHBCODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHFECDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nASDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesEgresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regBs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetallesEgresos
            // 
            this.dgvDetallesEgresos.AllowUserToAddRows = false;
            this.dgvDetallesEgresos.AllowUserToDeleteRows = false;
            this.dgvDetallesEgresos.AutoGenerateColumns = false;
            this.dgvDetallesEgresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesEgresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDTDataGridViewTextBoxColumn,
            this.iDCDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.xMESDataGridViewTextBoxColumn,
            this.xYEARDataGridViewTextBoxColumn,
            this.tdocDataGridViewTextBoxColumn,
            this.refDataGridViewTextBoxColumn,
            this.pCDataGridViewTextBoxColumn,
            this.pCIDDataGridViewTextBoxColumn,
            this.entidadDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.cCostoDataGridViewTextBoxColumn,
            this.xTransfDataGridViewTextBoxColumn,
            this.monedaDataGridViewTextBoxColumn,
            this.montoIDataGridViewTextBoxColumn,
            this.montoEDataGridViewTextBoxColumn,
            this.logUserDataGridViewTextBoxColumn,
            this.logFechaDataGridViewTextBoxColumn,
            this.sTDataGridViewTextBoxColumn,
            this.cHBCODataGridViewTextBoxColumn,
            this.cHFECDataGridViewTextBoxColumn,
            this.cHIDDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.cCDataGridViewTextBoxColumn,
            this.nASDataGridViewTextBoxColumn,
            this.tCODEDataGridViewTextBoxColumn});
            this.dgvDetallesEgresos.DataSource = this.regBs;
            this.dgvDetallesEgresos.Location = new System.Drawing.Point(25, 208);
            this.dgvDetallesEgresos.Name = "dgvDetallesEgresos";
            this.dgvDetallesEgresos.ReadOnly = true;
            this.dgvDetallesEgresos.Size = new System.Drawing.Size(769, 460);
            this.dgvDetallesEgresos.TabIndex = 0;
            // 
            // regBs
            // 
            this.regBs.DataSource = typeof(TecserEF.Entity.XREGISTER);
            // 
            // iDTDataGridViewTextBoxColumn
            // 
            this.iDTDataGridViewTextBoxColumn.DataPropertyName = "IDT";
            this.iDTDataGridViewTextBoxColumn.HeaderText = "IDT";
            this.iDTDataGridViewTextBoxColumn.Name = "iDTDataGridViewTextBoxColumn";
            this.iDTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDCDataGridViewTextBoxColumn
            // 
            this.iDCDataGridViewTextBoxColumn.DataPropertyName = "IDC";
            this.iDCDataGridViewTextBoxColumn.HeaderText = "IDC";
            this.iDCDataGridViewTextBoxColumn.Name = "iDCDataGridViewTextBoxColumn";
            this.iDCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xMESDataGridViewTextBoxColumn
            // 
            this.xMESDataGridViewTextBoxColumn.DataPropertyName = "XMES";
            this.xMESDataGridViewTextBoxColumn.HeaderText = "XMES";
            this.xMESDataGridViewTextBoxColumn.Name = "xMESDataGridViewTextBoxColumn";
            this.xMESDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xYEARDataGridViewTextBoxColumn
            // 
            this.xYEARDataGridViewTextBoxColumn.DataPropertyName = "XYEAR";
            this.xYEARDataGridViewTextBoxColumn.HeaderText = "XYEAR";
            this.xYEARDataGridViewTextBoxColumn.Name = "xYEARDataGridViewTextBoxColumn";
            this.xYEARDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tdocDataGridViewTextBoxColumn
            // 
            this.tdocDataGridViewTextBoxColumn.DataPropertyName = "Tdoc";
            this.tdocDataGridViewTextBoxColumn.HeaderText = "Tdoc";
            this.tdocDataGridViewTextBoxColumn.Name = "tdocDataGridViewTextBoxColumn";
            this.tdocDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // refDataGridViewTextBoxColumn
            // 
            this.refDataGridViewTextBoxColumn.DataPropertyName = "Ref";
            this.refDataGridViewTextBoxColumn.HeaderText = "Ref";
            this.refDataGridViewTextBoxColumn.Name = "refDataGridViewTextBoxColumn";
            this.refDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pCDataGridViewTextBoxColumn
            // 
            this.pCDataGridViewTextBoxColumn.DataPropertyName = "PC";
            this.pCDataGridViewTextBoxColumn.HeaderText = "PC";
            this.pCDataGridViewTextBoxColumn.Name = "pCDataGridViewTextBoxColumn";
            this.pCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pCIDDataGridViewTextBoxColumn
            // 
            this.pCIDDataGridViewTextBoxColumn.DataPropertyName = "PCID";
            this.pCIDDataGridViewTextBoxColumn.HeaderText = "PCID";
            this.pCIDDataGridViewTextBoxColumn.Name = "pCIDDataGridViewTextBoxColumn";
            this.pCIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // entidadDataGridViewTextBoxColumn
            // 
            this.entidadDataGridViewTextBoxColumn.DataPropertyName = "Entidad";
            this.entidadDataGridViewTextBoxColumn.HeaderText = "Entidad";
            this.entidadDataGridViewTextBoxColumn.Name = "entidadDataGridViewTextBoxColumn";
            this.entidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cCostoDataGridViewTextBoxColumn
            // 
            this.cCostoDataGridViewTextBoxColumn.DataPropertyName = "CCosto";
            this.cCostoDataGridViewTextBoxColumn.HeaderText = "CCosto";
            this.cCostoDataGridViewTextBoxColumn.Name = "cCostoDataGridViewTextBoxColumn";
            this.cCostoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xTransfDataGridViewTextBoxColumn
            // 
            this.xTransfDataGridViewTextBoxColumn.DataPropertyName = "XTransf";
            this.xTransfDataGridViewTextBoxColumn.HeaderText = "XTransf";
            this.xTransfDataGridViewTextBoxColumn.Name = "xTransfDataGridViewTextBoxColumn";
            this.xTransfDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // monedaDataGridViewTextBoxColumn
            // 
            this.monedaDataGridViewTextBoxColumn.DataPropertyName = "Moneda";
            this.monedaDataGridViewTextBoxColumn.HeaderText = "Moneda";
            this.monedaDataGridViewTextBoxColumn.Name = "monedaDataGridViewTextBoxColumn";
            this.monedaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoIDataGridViewTextBoxColumn
            // 
            this.montoIDataGridViewTextBoxColumn.DataPropertyName = "Monto_I";
            this.montoIDataGridViewTextBoxColumn.HeaderText = "Monto_I";
            this.montoIDataGridViewTextBoxColumn.Name = "montoIDataGridViewTextBoxColumn";
            this.montoIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoEDataGridViewTextBoxColumn
            // 
            this.montoEDataGridViewTextBoxColumn.DataPropertyName = "Monto_E";
            this.montoEDataGridViewTextBoxColumn.HeaderText = "Monto_E";
            this.montoEDataGridViewTextBoxColumn.Name = "montoEDataGridViewTextBoxColumn";
            this.montoEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logUserDataGridViewTextBoxColumn
            // 
            this.logUserDataGridViewTextBoxColumn.DataPropertyName = "LogUser";
            this.logUserDataGridViewTextBoxColumn.HeaderText = "LogUser";
            this.logUserDataGridViewTextBoxColumn.Name = "logUserDataGridViewTextBoxColumn";
            this.logUserDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logFechaDataGridViewTextBoxColumn
            // 
            this.logFechaDataGridViewTextBoxColumn.DataPropertyName = "LogFecha";
            this.logFechaDataGridViewTextBoxColumn.HeaderText = "LogFecha";
            this.logFechaDataGridViewTextBoxColumn.Name = "logFechaDataGridViewTextBoxColumn";
            this.logFechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sTDataGridViewTextBoxColumn
            // 
            this.sTDataGridViewTextBoxColumn.DataPropertyName = "ST";
            this.sTDataGridViewTextBoxColumn.HeaderText = "ST";
            this.sTDataGridViewTextBoxColumn.Name = "sTDataGridViewTextBoxColumn";
            this.sTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHBCODataGridViewTextBoxColumn
            // 
            this.cHBCODataGridViewTextBoxColumn.DataPropertyName = "CH_BCO";
            this.cHBCODataGridViewTextBoxColumn.HeaderText = "CH_BCO";
            this.cHBCODataGridViewTextBoxColumn.Name = "cHBCODataGridViewTextBoxColumn";
            this.cHBCODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHFECDataGridViewTextBoxColumn
            // 
            this.cHFECDataGridViewTextBoxColumn.DataPropertyName = "CH_FEC";
            this.cHFECDataGridViewTextBoxColumn.HeaderText = "CH_FEC";
            this.cHFECDataGridViewTextBoxColumn.Name = "cHFECDataGridViewTextBoxColumn";
            this.cHFECDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cHIDDataGridViewTextBoxColumn
            // 
            this.cHIDDataGridViewTextBoxColumn.DataPropertyName = "CH_ID";
            this.cHIDDataGridViewTextBoxColumn.HeaderText = "CH_ID";
            this.cHIDDataGridViewTextBoxColumn.Name = "cHIDDataGridViewTextBoxColumn";
            this.cHIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "TIPO";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cCDataGridViewTextBoxColumn
            // 
            this.cCDataGridViewTextBoxColumn.DataPropertyName = "CC";
            this.cCDataGridViewTextBoxColumn.HeaderText = "CC";
            this.cCDataGridViewTextBoxColumn.Name = "cCDataGridViewTextBoxColumn";
            this.cCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nASDataGridViewTextBoxColumn
            // 
            this.nASDataGridViewTextBoxColumn.DataPropertyName = "NAS";
            this.nASDataGridViewTextBoxColumn.HeaderText = "NAS";
            this.nASDataGridViewTextBoxColumn.Name = "nASDataGridViewTextBoxColumn";
            this.nASDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tCODEDataGridViewTextBoxColumn
            // 
            this.tCODEDataGridViewTextBoxColumn.DataPropertyName = "TCODE";
            this.tCODEDataGridViewTextBoxColumn.HeaderText = "TCODE";
            this.tCODEDataGridViewTextBoxColumn.Name = "tCODEDataGridViewTextBoxColumn";
            this.tCODEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmDetalleEgresosREG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 696);
            this.Controls.Add(this.dgvDetallesEgresos);
            this.Name = "FrmDetalleEgresosREG";
            this.Text = "FrmDetalleEgresosREG";
            this.Load += new System.EventHandler(this.FrmDetalleEgresosREG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesEgresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetallesEgresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xMESDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xYEARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xTransfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logFechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHBCODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHFECDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nASDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource regBs;
    }
}