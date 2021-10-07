namespace MASngFE.Application
{
    partial class FrmTest0
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
            this.dgvVendor = new System.Windows.Forms.DataGridView();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idprovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provrsocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provfantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTAX1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTAX1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T0005DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.uVendorSearch2 = new MASngFE._UserControls.UVendorSearch();
            this.uCustomerSearch1 = new MASngFE._UserControls.UCustomerSearch();
           ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005DgvBs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVendor
            // 
            this.dgvVendor.AllowUserToAddRows = false;
            this.dgvVendor.AllowUserToDeleteRows = false;
            this.dgvVendor.AutoGenerateColumns = false;
            this.dgvVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idprovDataGridViewTextBoxColumn,
            this.provrsocialDataGridViewTextBoxColumn,
            this.provfantasiaDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.tTAX1DataGridViewTextBoxColumn,
            this.nTAX1DataGridViewTextBoxColumn,
            this.Accion});
            this.dgvVendor.DataSource = this.T0005DgvBs;
            this.dgvVendor.Location = new System.Drawing.Point(11, 276);
            this.dgvVendor.Name = "dgvVendor";
            this.dgvVendor.ReadOnly = true;
            this.dgvVendor.RowHeadersWidth = 20;
            this.dgvVendor.Size = new System.Drawing.Size(690, 315);
            this.dgvVendor.TabIndex = 2;
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Width = 60;
            // 
            // idprovDataGridViewTextBoxColumn
            // 
            this.idprovDataGridViewTextBoxColumn.DataPropertyName = "id_prov";
            this.idprovDataGridViewTextBoxColumn.HeaderText = "# Prov";
            this.idprovDataGridViewTextBoxColumn.Name = "idprovDataGridViewTextBoxColumn";
            this.idprovDataGridViewTextBoxColumn.ReadOnly = true;
            this.idprovDataGridViewTextBoxColumn.Width = 70;
            // 
            // provrsocialDataGridViewTextBoxColumn
            // 
            this.provrsocialDataGridViewTextBoxColumn.DataPropertyName = "prov_rsocial";
            this.provrsocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.provrsocialDataGridViewTextBoxColumn.Name = "provrsocialDataGridViewTextBoxColumn";
            this.provrsocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.provrsocialDataGridViewTextBoxColumn.Width = 150;
            // 
            // provfantasiaDataGridViewTextBoxColumn
            // 
            this.provfantasiaDataGridViewTextBoxColumn.DataPropertyName = "prov_fantasia";
            this.provfantasiaDataGridViewTextBoxColumn.HeaderText = "Fantasia";
            this.provfantasiaDataGridViewTextBoxColumn.Name = "provfantasiaDataGridViewTextBoxColumn";
            this.provfantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 60;
            // 
            // tTAX1DataGridViewTextBoxColumn
            // 
            this.tTAX1DataGridViewTextBoxColumn.DataPropertyName = "TTAX1";
            this.tTAX1DataGridViewTextBoxColumn.HeaderText = "TTAX1";
            this.tTAX1DataGridViewTextBoxColumn.Name = "tTAX1DataGridViewTextBoxColumn";
            this.tTAX1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nTAX1DataGridViewTextBoxColumn
            // 
            this.nTAX1DataGridViewTextBoxColumn.DataPropertyName = "NTAX1";
            this.nTAX1DataGridViewTextBoxColumn.HeaderText = "NTAX1";
            this.nTAX1DataGridViewTextBoxColumn.Name = "nTAX1DataGridViewTextBoxColumn";
            this.nTAX1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // T0005DgvBs
            // 
            this.T0005DgvBs.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // uVendorSearch2
            // 
            this.uVendorSearch2.Location = new System.Drawing.Point(11, 135);
            this.uVendorSearch2.Name = "uVendorSearch2";
            this.uVendorSearch2.Size = new System.Drawing.Size(578, 135);
            this.uVendorSearch2.TabIndex = 1;
            // 
            // uCustomerSearch1
            // 
            this.uCustomerSearch1.Location = new System.Drawing.Point(12, 12);
            this.uCustomerSearch1.Name = "uCustomerSearch1";
            this.uCustomerSearch1.Size = new System.Drawing.Size(577, 117);
            this.uCustomerSearch1.TabIndex = 0;
            // 
            // uMaterialSearch1
            // 

            // 
            // FrmTest0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 599);

            this.Controls.Add(this.dgvVendor);
            this.Controls.Add(this.uVendorSearch2);
            this.Controls.Add(this.uCustomerSearch1);
            this.Name = "FrmTest0";
            this.Text = "FrmTest0";
            this.Load += new System.EventHandler(this.FrmTest0_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005DgvBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private _UserControls.UCustomerSearch uCustomerSearch1;
#pragma warning disable CS0169 // The field 'FrmTest0.uVendorSearch1' is never used
        private _UserControls.UVendorSearch uVendorSearch1;
#pragma warning restore CS0169 // The field 'FrmTest0.uVendorSearch1' is never used
#pragma warning disable CS0169 // The field 'FrmTest0.userTextboxBase1' is never used
        private _UserControls.UserTextboxBase userTextboxBase1;
#pragma warning restore CS0169 // The field 'FrmTest0.userTextboxBase1' is never used
#pragma warning disable CS0169 // The field 'FrmTest0.userTextboxBase2' is never used
        private _UserControls.UserTextboxBase userTextboxBase2;
#pragma warning restore CS0169 // The field 'FrmTest0.userTextboxBase2' is never used
#pragma warning disable CS0169 // The field 'FrmTest0.userTextboxBase3' is never used
        private _UserControls.UserTextboxBase userTextboxBase3;
#pragma warning restore CS0169 // The field 'FrmTest0.userTextboxBase3' is never used
        private _UserControls.UVendorSearch uVendorSearch2;
        private System.Windows.Forms.BindingSource T0005DgvBs;
        private System.Windows.Forms.DataGridView dgvVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provrsocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provfantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTAX1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTAX1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;

    }
}