namespace MASngFE.FIX
{
    partial class FrmFixFacturaConta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnSearchMissing201 = new System.Windows.Forms.Button();
            this.dgvFacturasIssue = new System.Windows.Forms.DataGridView();
            this.t0400FACTURAHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvFacturasToFix = new System.Windows.Forms.DataGridView();
            this.btnFix = new System.Windows.Forms.DataGridViewButtonColumn();
            this.iDFACTURAXDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIdFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pVAFIPDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDAFIPDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODOCDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPOFACTDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHADataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rAZONSOCDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusFacturaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFacturaNDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCtaCteDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDFACTURADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pVAFIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nDAFIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPOFACTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rAZONSOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusFacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFacturaBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFacturaNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCtaCteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasIssue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0400FACTURAHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasToFix)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(983, 61);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(97, 41);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnSearchMissing201
            // 
            this.btnSearchMissing201.Location = new System.Drawing.Point(983, 20);
            this.btnSearchMissing201.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchMissing201.Name = "btnSearchMissing201";
            this.btnSearchMissing201.Size = new System.Drawing.Size(97, 41);
            this.btnSearchMissing201.TabIndex = 1;
            this.btnSearchMissing201.Text = "BUSCAR";
            this.btnSearchMissing201.UseVisualStyleBackColor = true;
            this.btnSearchMissing201.Click += new System.EventHandler(this.btnSearchMissing201_Click);
            // 
            // dgvFacturasIssue
            // 
            this.dgvFacturasIssue.AllowUserToAddRows = false;
            this.dgvFacturasIssue.AllowUserToDeleteRows = false;
            this.dgvFacturasIssue.AutoGenerateColumns = false;
            this.dgvFacturasIssue.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvFacturasIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasIssue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDFACTURADataGridViewTextBoxColumn,
            this.tIPODOCDataGridViewTextBoxColumn,
            this.pVAFIPDataGridViewTextBoxColumn,
            this.nDAFIPDataGridViewTextBoxColumn,
            this.tIPOFACTDataGridViewTextBoxColumn,
            this.fECHADataGridViewTextBoxColumn,
            this.rAZONSOCDataGridViewTextBoxColumn,
            this.statusFacturaDataGridViewTextBoxColumn,
            this.totalFacturaBDataGridViewTextBoxColumn,
            this.totalFacturaNDataGridViewTextBoxColumn,
            this.cAEDataGridViewTextBoxColumn,
            this.remitoDataGridViewTextBoxColumn,
            this.idCtaCteDataGridViewTextBoxColumn});
            this.dgvFacturasIssue.DataSource = this.t0400FACTURAHBindingSource;
            this.dgvFacturasIssue.Location = new System.Drawing.Point(16, 20);
            this.dgvFacturasIssue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvFacturasIssue.MultiSelect = false;
            this.dgvFacturasIssue.Name = "dgvFacturasIssue";
            this.dgvFacturasIssue.ReadOnly = true;
            this.dgvFacturasIssue.RowHeadersWidth = 25;
            this.dgvFacturasIssue.RowTemplate.Height = 24;
            this.dgvFacturasIssue.Size = new System.Drawing.Size(930, 245);
            this.dgvFacturasIssue.TabIndex = 2;
            // 
            // t0400FACTURAHBindingSource
            // 
            this.t0400FACTURAHBindingSource.DataSource = typeof(TecserEF.Entity.T0400_FACTURA_H);
            // 
            // dgvFacturasToFix
            // 
            this.dgvFacturasToFix.AllowUserToAddRows = false;
            this.dgvFacturasToFix.AllowUserToDeleteRows = false;
            this.dgvFacturasToFix.AutoGenerateColumns = false;
            this.dgvFacturasToFix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasToFix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnFix,
            this.iDFACTURAXDataGridViewTextBoxColumn1,
            this.dgvIdFactura,
            this.pVAFIPDataGridViewTextBoxColumn1,
            this.nDAFIPDataGridViewTextBoxColumn1,
            this.tIPODOCDataGridViewTextBoxColumn1,
            this.tIPOFACTDataGridViewTextBoxColumn1,
            this.fECHADataGridViewTextBoxColumn1,
            this.rAZONSOCDataGridViewTextBoxColumn1,
            this.statusFacturaDataGridViewTextBoxColumn1,
            this.totalFacturaNDataGridViewTextBoxColumn1,
            this.idCtaCteDataGridViewTextBoxColumn1});
            this.dgvFacturasToFix.DataSource = this.t0400FACTURAHBindingSource;
            this.dgvFacturasToFix.Location = new System.Drawing.Point(16, 280);
            this.dgvFacturasToFix.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvFacturasToFix.Name = "dgvFacturasToFix";
            this.dgvFacturasToFix.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFacturasToFix.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFacturasToFix.RowTemplate.Height = 24;
            this.dgvFacturasToFix.Size = new System.Drawing.Size(1085, 266);
            this.dgvFacturasToFix.TabIndex = 3;
            this.dgvFacturasToFix.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturasToFix_CellClick);
            this.dgvFacturasToFix.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturasToFix_CellContentClick);
            // 
            // btnFix
            // 
            this.btnFix.HeaderText = "FIX";
            this.btnFix.Name = "btnFix";
            this.btnFix.ReadOnly = true;
            this.btnFix.Text = "FIX";
            this.btnFix.UseColumnTextForButtonValue = true;
            this.btnFix.Width = 40;
            // 
            // iDFACTURAXDataGridViewTextBoxColumn1
            // 
            this.iDFACTURAXDataGridViewTextBoxColumn1.DataPropertyName = "IDFACTURAX";
            this.iDFACTURAXDataGridViewTextBoxColumn1.HeaderText = "IDFACTURAX";
            this.iDFACTURAXDataGridViewTextBoxColumn1.Name = "iDFACTURAXDataGridViewTextBoxColumn1";
            this.iDFACTURAXDataGridViewTextBoxColumn1.ReadOnly = true;
            this.iDFACTURAXDataGridViewTextBoxColumn1.Visible = false;
            // 
            // dgvIdFactura
            // 
            this.dgvIdFactura.DataPropertyName = "IDFACTURA";
            this.dgvIdFactura.HeaderText = "IDFACTURA";
            this.dgvIdFactura.Name = "dgvIdFactura";
            this.dgvIdFactura.ReadOnly = true;
            // 
            // pVAFIPDataGridViewTextBoxColumn1
            // 
            this.pVAFIPDataGridViewTextBoxColumn1.DataPropertyName = "PV_AFIP";
            this.pVAFIPDataGridViewTextBoxColumn1.HeaderText = "PV_AFIP";
            this.pVAFIPDataGridViewTextBoxColumn1.Name = "pVAFIPDataGridViewTextBoxColumn1";
            this.pVAFIPDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nDAFIPDataGridViewTextBoxColumn1
            // 
            this.nDAFIPDataGridViewTextBoxColumn1.DataPropertyName = "ND_AFIP";
            this.nDAFIPDataGridViewTextBoxColumn1.HeaderText = "ND_AFIP";
            this.nDAFIPDataGridViewTextBoxColumn1.Name = "nDAFIPDataGridViewTextBoxColumn1";
            this.nDAFIPDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tIPODOCDataGridViewTextBoxColumn1
            // 
            this.tIPODOCDataGridViewTextBoxColumn1.DataPropertyName = "TIPO_DOC";
            this.tIPODOCDataGridViewTextBoxColumn1.HeaderText = "TIPO_DOC";
            this.tIPODOCDataGridViewTextBoxColumn1.Name = "tIPODOCDataGridViewTextBoxColumn1";
            this.tIPODOCDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tIPOFACTDataGridViewTextBoxColumn1
            // 
            this.tIPOFACTDataGridViewTextBoxColumn1.DataPropertyName = "TIPOFACT";
            this.tIPOFACTDataGridViewTextBoxColumn1.HeaderText = "TIPOFACT";
            this.tIPOFACTDataGridViewTextBoxColumn1.Name = "tIPOFACTDataGridViewTextBoxColumn1";
            this.tIPOFACTDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // fECHADataGridViewTextBoxColumn1
            // 
            this.fECHADataGridViewTextBoxColumn1.DataPropertyName = "FECHA";
            this.fECHADataGridViewTextBoxColumn1.HeaderText = "FECHA";
            this.fECHADataGridViewTextBoxColumn1.Name = "fECHADataGridViewTextBoxColumn1";
            this.fECHADataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // rAZONSOCDataGridViewTextBoxColumn1
            // 
            this.rAZONSOCDataGridViewTextBoxColumn1.DataPropertyName = "RAZONSOC";
            this.rAZONSOCDataGridViewTextBoxColumn1.HeaderText = "RAZONSOC";
            this.rAZONSOCDataGridViewTextBoxColumn1.Name = "rAZONSOCDataGridViewTextBoxColumn1";
            this.rAZONSOCDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // statusFacturaDataGridViewTextBoxColumn1
            // 
            this.statusFacturaDataGridViewTextBoxColumn1.DataPropertyName = "StatusFactura";
            this.statusFacturaDataGridViewTextBoxColumn1.HeaderText = "StatusFactura";
            this.statusFacturaDataGridViewTextBoxColumn1.Name = "statusFacturaDataGridViewTextBoxColumn1";
            this.statusFacturaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // totalFacturaNDataGridViewTextBoxColumn1
            // 
            this.totalFacturaNDataGridViewTextBoxColumn1.DataPropertyName = "TotalFacturaN";
            this.totalFacturaNDataGridViewTextBoxColumn1.HeaderText = "TotalFacturaN";
            this.totalFacturaNDataGridViewTextBoxColumn1.Name = "totalFacturaNDataGridViewTextBoxColumn1";
            this.totalFacturaNDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // idCtaCteDataGridViewTextBoxColumn1
            // 
            this.idCtaCteDataGridViewTextBoxColumn1.DataPropertyName = "IdCtaCte";
            this.idCtaCteDataGridViewTextBoxColumn1.HeaderText = "IdCtaCte";
            this.idCtaCteDataGridViewTextBoxColumn1.Name = "idCtaCteDataGridViewTextBoxColumn1";
            this.idCtaCteDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // iDFACTURADataGridViewTextBoxColumn
            // 
            this.iDFACTURADataGridViewTextBoxColumn.DataPropertyName = "IDFACTURA";
            this.iDFACTURADataGridViewTextBoxColumn.HeaderText = "IDFACTURA";
            this.iDFACTURADataGridViewTextBoxColumn.Name = "iDFACTURADataGridViewTextBoxColumn";
            this.iDFACTURADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDFACTURADataGridViewTextBoxColumn.Width = 70;
            // 
            // tIPODOCDataGridViewTextBoxColumn
            // 
            this.tIPODOCDataGridViewTextBoxColumn.DataPropertyName = "TIPO_DOC";
            this.tIPODOCDataGridViewTextBoxColumn.HeaderText = "TD";
            this.tIPODOCDataGridViewTextBoxColumn.Name = "tIPODOCDataGridViewTextBoxColumn";
            this.tIPODOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODOCDataGridViewTextBoxColumn.Width = 35;
            // 
            // pVAFIPDataGridViewTextBoxColumn
            // 
            this.pVAFIPDataGridViewTextBoxColumn.DataPropertyName = "PV_AFIP";
            this.pVAFIPDataGridViewTextBoxColumn.HeaderText = "SUC.";
            this.pVAFIPDataGridViewTextBoxColumn.Name = "pVAFIPDataGridViewTextBoxColumn";
            this.pVAFIPDataGridViewTextBoxColumn.ReadOnly = true;
            this.pVAFIPDataGridViewTextBoxColumn.Width = 45;
            // 
            // nDAFIPDataGridViewTextBoxColumn
            // 
            this.nDAFIPDataGridViewTextBoxColumn.DataPropertyName = "ND_AFIP";
            this.nDAFIPDataGridViewTextBoxColumn.HeaderText = "NUMERO";
            this.nDAFIPDataGridViewTextBoxColumn.Name = "nDAFIPDataGridViewTextBoxColumn";
            this.nDAFIPDataGridViewTextBoxColumn.ReadOnly = true;
            this.nDAFIPDataGridViewTextBoxColumn.Width = 60;
            // 
            // tIPOFACTDataGridViewTextBoxColumn
            // 
            this.tIPOFACTDataGridViewTextBoxColumn.DataPropertyName = "TIPOFACT";
            this.tIPOFACTDataGridViewTextBoxColumn.HeaderText = "LX";
            this.tIPOFACTDataGridViewTextBoxColumn.Name = "tIPOFACTDataGridViewTextBoxColumn";
            this.tIPOFACTDataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPOFACTDataGridViewTextBoxColumn.Width = 30;
            // 
            // fECHADataGridViewTextBoxColumn
            // 
            this.fECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA";
            this.fECHADataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fECHADataGridViewTextBoxColumn.Name = "fECHADataGridViewTextBoxColumn";
            this.fECHADataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHADataGridViewTextBoxColumn.Width = 70;
            // 
            // rAZONSOCDataGridViewTextBoxColumn
            // 
            this.rAZONSOCDataGridViewTextBoxColumn.DataPropertyName = "RAZONSOC";
            this.rAZONSOCDataGridViewTextBoxColumn.HeaderText = "CLIENTE";
            this.rAZONSOCDataGridViewTextBoxColumn.Name = "rAZONSOCDataGridViewTextBoxColumn";
            this.rAZONSOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.rAZONSOCDataGridViewTextBoxColumn.Width = 120;
            // 
            // statusFacturaDataGridViewTextBoxColumn
            // 
            this.statusFacturaDataGridViewTextBoxColumn.DataPropertyName = "StatusFactura";
            this.statusFacturaDataGridViewTextBoxColumn.HeaderText = "StatusFactura";
            this.statusFacturaDataGridViewTextBoxColumn.Name = "statusFacturaDataGridViewTextBoxColumn";
            this.statusFacturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalFacturaBDataGridViewTextBoxColumn
            // 
            this.totalFacturaBDataGridViewTextBoxColumn.DataPropertyName = "TotalFacturaB";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.totalFacturaBDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.totalFacturaBDataGridViewTextBoxColumn.HeaderText = "BRUTO";
            this.totalFacturaBDataGridViewTextBoxColumn.Name = "totalFacturaBDataGridViewTextBoxColumn";
            this.totalFacturaBDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalFacturaBDataGridViewTextBoxColumn.Width = 70;
            // 
            // totalFacturaNDataGridViewTextBoxColumn
            // 
            this.totalFacturaNDataGridViewTextBoxColumn.DataPropertyName = "TotalFacturaN";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.totalFacturaNDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.totalFacturaNDataGridViewTextBoxColumn.HeaderText = "FINAL";
            this.totalFacturaNDataGridViewTextBoxColumn.Name = "totalFacturaNDataGridViewTextBoxColumn";
            this.totalFacturaNDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalFacturaNDataGridViewTextBoxColumn.Width = 70;
            // 
            // cAEDataGridViewTextBoxColumn
            // 
            this.cAEDataGridViewTextBoxColumn.DataPropertyName = "CAE";
            this.cAEDataGridViewTextBoxColumn.HeaderText = "CAE";
            this.cAEDataGridViewTextBoxColumn.Name = "cAEDataGridViewTextBoxColumn";
            this.cAEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remitoDataGridViewTextBoxColumn
            // 
            this.remitoDataGridViewTextBoxColumn.DataPropertyName = "Remito";
            this.remitoDataGridViewTextBoxColumn.HeaderText = "REMITO#";
            this.remitoDataGridViewTextBoxColumn.Name = "remitoDataGridViewTextBoxColumn";
            this.remitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.remitoDataGridViewTextBoxColumn.Width = 60;
            // 
            // idCtaCteDataGridViewTextBoxColumn
            // 
            this.idCtaCteDataGridViewTextBoxColumn.DataPropertyName = "IdCtaCte";
            this.idCtaCteDataGridViewTextBoxColumn.HeaderText = "IdCtaCte";
            this.idCtaCteDataGridViewTextBoxColumn.Name = "idCtaCteDataGridViewTextBoxColumn";
            this.idCtaCteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCtaCteDataGridViewTextBoxColumn.Width = 60;
            // 
            // FrmFixFacturaConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 603);
            this.Controls.Add(this.dgvFacturasToFix);
            this.Controls.Add(this.dgvFacturasIssue);
            this.Controls.Add(this.btnSearchMissing201);
            this.Controls.Add(this.btnSalir);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmFixFacturaConta";
            this.Text = "FIX FACTURA NO APARECE EN GESCO/CC1";
            this.Load += new System.EventHandler(this.FrmFixFacturaConta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasIssue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0400FACTURAHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasToFix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnSearchMissing201;
        private System.Windows.Forms.DataGridView dgvFacturasIssue;
        private System.Windows.Forms.BindingSource t0400FACTURAHBindingSource;
        private System.Windows.Forms.DataGridView dgvFacturasToFix;
        private System.Windows.Forms.DataGridViewButtonColumn btnFix;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDFACTURAXDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIdFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn pVAFIPDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDAFIPDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODOCDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPOFACTDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHADataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rAZONSOCDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusFacturaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFacturaNDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCtaCteDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDFACTURADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pVAFIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nDAFIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPOFACTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rAZONSOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusFacturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFacturaBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFacturaNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCtaCteDataGridViewTextBoxColumn;
    }
}