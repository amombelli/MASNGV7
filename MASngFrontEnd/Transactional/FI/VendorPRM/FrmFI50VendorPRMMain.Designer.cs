namespace MASngFE.Transactional.FI.VendorPRM
{
    partial class FrmFI50VendorPRMMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI50VendorPRMMain));
            this.dgvListaFactura = new System.Windows.Forms.DataGridView();
            this.iDINTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pROVRSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tFACTURADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nFACTURADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nETODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tOTALIVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bRUTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cANTKGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALDOIMPAGODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t403Bs = new System.Windows.Forms.BindingSource(this.components);
            this.btnVendorDetail = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.uVendorSearch1 = new MASngFE._UserControls.UVendorSearch();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t403Bs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaFactura
            // 
            this.dgvListaFactura.AllowUserToAddRows = false;
            this.dgvListaFactura.AllowUserToDeleteRows = false;
            this.dgvListaFactura.AutoGenerateColumns = false;
            this.dgvListaFactura.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaFactura.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDINTDataGridViewTextBoxColumn,
            this.pROVRSDataGridViewTextBoxColumn,
            this.fECHADataGridViewTextBoxColumn,
            this.tFACTURADataGridViewTextBoxColumn,
            this.nFACTURADataGridViewTextBoxColumn,
            this.mONDataGridViewTextBoxColumn,
            this.tCDataGridViewTextBoxColumn,
            this.iMPORIDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.nETODataGridViewTextBoxColumn,
            this.tOTALIVADataGridViewTextBoxColumn,
            this.bRUTODataGridViewTextBoxColumn,
            this.cANTKGDataGridViewTextBoxColumn,
            this.sALDOIMPAGODataGridViewTextBoxColumn,
            this.statusDocumentoDataGridViewTextBoxColumn,
            this.btn});
            this.dgvListaFactura.DataSource = this.t403Bs;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListaFactura.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvListaFactura.GridColor = System.Drawing.Color.Navy;
            this.dgvListaFactura.Location = new System.Drawing.Point(13, 154);
            this.dgvListaFactura.Name = "dgvListaFactura";
            this.dgvListaFactura.ReadOnly = true;
            this.dgvListaFactura.RowHeadersWidth = 20;
            this.dgvListaFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaFactura.Size = new System.Drawing.Size(1103, 447);
            this.dgvListaFactura.TabIndex = 85;
            this.dgvListaFactura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaFactura_CellContentClick);
            // 
            // iDINTDataGridViewTextBoxColumn
            // 
            this.iDINTDataGridViewTextBoxColumn.DataPropertyName = "IDINT";
            this.iDINTDataGridViewTextBoxColumn.HeaderText = "IDINT";
            this.iDINTDataGridViewTextBoxColumn.Name = "iDINTDataGridViewTextBoxColumn";
            this.iDINTDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDINTDataGridViewTextBoxColumn.Visible = false;
            // 
            // pROVRSDataGridViewTextBoxColumn
            // 
            this.pROVRSDataGridViewTextBoxColumn.DataPropertyName = "PROVRS";
            this.pROVRSDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.pROVRSDataGridViewTextBoxColumn.Name = "pROVRSDataGridViewTextBoxColumn";
            this.pROVRSDataGridViewTextBoxColumn.ReadOnly = true;
            this.pROVRSDataGridViewTextBoxColumn.Width = 150;
            // 
            // fECHADataGridViewTextBoxColumn
            // 
            this.fECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fECHADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fECHADataGridViewTextBoxColumn.HeaderText = "Fecha Doc";
            this.fECHADataGridViewTextBoxColumn.Name = "fECHADataGridViewTextBoxColumn";
            this.fECHADataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHADataGridViewTextBoxColumn.Width = 80;
            // 
            // tFACTURADataGridViewTextBoxColumn
            // 
            this.tFACTURADataGridViewTextBoxColumn.DataPropertyName = "TFACTURA";
            this.tFACTURADataGridViewTextBoxColumn.HeaderText = "TD";
            this.tFACTURADataGridViewTextBoxColumn.Name = "tFACTURADataGridViewTextBoxColumn";
            this.tFACTURADataGridViewTextBoxColumn.ReadOnly = true;
            this.tFACTURADataGridViewTextBoxColumn.Width = 30;
            // 
            // nFACTURADataGridViewTextBoxColumn
            // 
            this.nFACTURADataGridViewTextBoxColumn.DataPropertyName = "NFACTURA";
            this.nFACTURADataGridViewTextBoxColumn.HeaderText = "Numero";
            this.nFACTURADataGridViewTextBoxColumn.Name = "nFACTURADataGridViewTextBoxColumn";
            this.nFACTURADataGridViewTextBoxColumn.ReadOnly = true;
            this.nFACTURADataGridViewTextBoxColumn.Width = 70;
            // 
            // mONDataGridViewTextBoxColumn
            // 
            this.mONDataGridViewTextBoxColumn.DataPropertyName = "MON";
            this.mONDataGridViewTextBoxColumn.HeaderText = "Mon";
            this.mONDataGridViewTextBoxColumn.Name = "mONDataGridViewTextBoxColumn";
            this.mONDataGridViewTextBoxColumn.ReadOnly = true;
            this.mONDataGridViewTextBoxColumn.Width = 35;
            // 
            // tCDataGridViewTextBoxColumn
            // 
            this.tCDataGridViewTextBoxColumn.DataPropertyName = "TC";
            this.tCDataGridViewTextBoxColumn.HeaderText = "TC";
            this.tCDataGridViewTextBoxColumn.Name = "tCDataGridViewTextBoxColumn";
            this.tCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tCDataGridViewTextBoxColumn.Width = 70;
            // 
            // iMPORIDataGridViewTextBoxColumn
            // 
            this.iMPORIDataGridViewTextBoxColumn.DataPropertyName = "IMPORI";
            dataGridViewCellStyle3.Format = "C2";
            this.iMPORIDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.iMPORIDataGridViewTextBoxColumn.HeaderText = "ImpMon";
            this.iMPORIDataGridViewTextBoxColumn.Name = "iMPORIDataGridViewTextBoxColumn";
            this.iMPORIDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "Lx";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 30;
            // 
            // nETODataGridViewTextBoxColumn
            // 
            this.nETODataGridViewTextBoxColumn.DataPropertyName = "NETO";
            dataGridViewCellStyle4.Format = "C2";
            this.nETODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.nETODataGridViewTextBoxColumn.HeaderText = "Bruto (I)";
            this.nETODataGridViewTextBoxColumn.Name = "nETODataGridViewTextBoxColumn";
            this.nETODataGridViewTextBoxColumn.ReadOnly = true;
            this.nETODataGridViewTextBoxColumn.Width = 80;
            // 
            // tOTALIVADataGridViewTextBoxColumn
            // 
            this.tOTALIVADataGridViewTextBoxColumn.DataPropertyName = "TOTALIVA";
            dataGridViewCellStyle5.Format = "C2";
            this.tOTALIVADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.tOTALIVADataGridViewTextBoxColumn.HeaderText = "Tot IVA";
            this.tOTALIVADataGridViewTextBoxColumn.Name = "tOTALIVADataGridViewTextBoxColumn";
            this.tOTALIVADataGridViewTextBoxColumn.ReadOnly = true;
            this.tOTALIVADataGridViewTextBoxColumn.Width = 80;
            // 
            // bRUTODataGridViewTextBoxColumn
            // 
            this.bRUTODataGridViewTextBoxColumn.DataPropertyName = "BRUTO";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle6.Format = "C2";
            this.bRUTODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.bRUTODataGridViewTextBoxColumn.HeaderText = "Neto (F)";
            this.bRUTODataGridViewTextBoxColumn.Name = "bRUTODataGridViewTextBoxColumn";
            this.bRUTODataGridViewTextBoxColumn.ReadOnly = true;
            this.bRUTODataGridViewTextBoxColumn.Width = 80;
            // 
            // cANTKGDataGridViewTextBoxColumn
            // 
            this.cANTKGDataGridViewTextBoxColumn.DataPropertyName = "CANTKG";
            dataGridViewCellStyle7.Format = "N1";
            this.cANTKGDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.cANTKGDataGridViewTextBoxColumn.HeaderText = "Kg";
            this.cANTKGDataGridViewTextBoxColumn.Name = "cANTKGDataGridViewTextBoxColumn";
            this.cANTKGDataGridViewTextBoxColumn.ReadOnly = true;
            this.cANTKGDataGridViewTextBoxColumn.Width = 60;
            // 
            // sALDOIMPAGODataGridViewTextBoxColumn
            // 
            this.sALDOIMPAGODataGridViewTextBoxColumn.DataPropertyName = "SALDOIMPAGO";
            dataGridViewCellStyle8.Format = "C2";
            this.sALDOIMPAGODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.sALDOIMPAGODataGridViewTextBoxColumn.HeaderText = "Saldo";
            this.sALDOIMPAGODataGridViewTextBoxColumn.Name = "sALDOIMPAGODataGridViewTextBoxColumn";
            this.sALDOIMPAGODataGridViewTextBoxColumn.ReadOnly = true;
            this.sALDOIMPAGODataGridViewTextBoxColumn.Width = 80;
            // 
            // statusDocumentoDataGridViewTextBoxColumn
            // 
            this.statusDocumentoDataGridViewTextBoxColumn.DataPropertyName = "StatusDocumento";
            this.statusDocumentoDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDocumentoDataGridViewTextBoxColumn.Name = "statusDocumentoDataGridViewTextBoxColumn";
            this.statusDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDocumentoDataGridViewTextBoxColumn.Width = 80;
            // 
            // btn
            // 
            this.btn.HeaderText = "Ver";
            this.btn.Name = "btn";
            this.btn.ReadOnly = true;
            this.btn.Text = "VER";
            this.btn.ToolTipText = "Visualizar detalle de Documento";
            this.btn.UseColumnTextForButtonValue = true;
            this.btn.Width = 40;
            // 
            // t403Bs
            // 
            this.t403Bs.DataSource = typeof(TecserEF.Entity.T0403_VENDOR_FACT_H);
            // 
            // btnVendorDetail
            // 
            this.btnVendorDetail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendorDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnVendorDetail.Image")));
            this.btnVendorDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVendorDetail.Location = new System.Drawing.Point(481, 61);
            this.btnVendorDetail.Name = "btnVendorDetail";
            this.btnVendorDetail.Size = new System.Drawing.Size(100, 40);
            this.btnVendorDetail.TabIndex = 84;
            this.btnVendorDetail.Text = "Detalle\r\nProveedor";
            this.btnVendorDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVendorDetail.UseVisualStyleBackColor = true;
            this.btnVendorDetail.Click += new System.EventHandler(this.BtnVendorDetail_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(1016, 52);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 80;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1016, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 82;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1016, 92);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 40);
            this.btnExport.TabIndex = 81;
            this.btnExport.Text = "Exportar";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // uVendorSearch1
            // 
            this.uVendorSearch1.Location = new System.Drawing.Point(13, 13);
            this.uVendorSearch1.Name = "uVendorSearch1";
            this.uVendorSearch1.Size = new System.Drawing.Size(578, 135);
            this.uVendorSearch1.TabIndex = 83;
            // 
            // FrmFI50VendorPRMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 613);
            this.Controls.Add(this.dgvListaFactura);
            this.Controls.Add(this.btnVendorDetail);
            this.Controls.Add(this.uVendorSearch1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Name = "FrmFI50VendorPRMMain";
            this.Text = "FI50 - Vendor Relationship Management";
            this.Load += new System.EventHandler(this.FrmFI50VendorPRMMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t403Bs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExport;
        private _UserControls.UVendorSearch uVendorSearch1;
        private System.Windows.Forms.Button btnVendorDetail;
        private System.Windows.Forms.DataGridView dgvListaFactura;
        private System.Windows.Forms.BindingSource t403Bs;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDINTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pROVRSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tFACTURADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nFACTURADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nETODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tOTALIVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bRUTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cANTKGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALDOIMPAGODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btn;
    }
}