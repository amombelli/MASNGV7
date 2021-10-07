namespace MASngFE.Forms.VendorSearchBase
{
    partial class FrmVendorSearchBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVendorSearchBase));
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvVendor = new System.Windows.Forms.DataGridView();
            this.ckSoloActivos = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumberVendorList = new System.Windows.Forms.TextBox();
            this.txtVendorId = new System.Windows.Forms.TextBox();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.txtTaxNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtTaxStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.txtTaxId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.T0005Bs = new System.Windows.Forms.BindingSource(this.components);
            this.T0005DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.idprovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provrsocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provfantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTAX1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nTAX1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipoProveedor = new System.Windows.Forms.ComboBox();
            this.t0014TIPOPROVEEDORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtTipoProveedorDescripcion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0005Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005DgvBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0014TIPOPROVEEDORBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(596, 7);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
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
            this.dgvVendor.Location = new System.Drawing.Point(6, 149);
            this.dgvVendor.Name = "dgvVendor";
            this.dgvVendor.ReadOnly = true;
            this.dgvVendor.RowHeadersWidth = 20;
            this.dgvVendor.Size = new System.Drawing.Size(690, 315);
            this.dgvVendor.TabIndex = 1;
            // 
            // ckSoloActivos
            // 
            this.ckSoloActivos.AutoSize = true;
            this.ckSoloActivos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloActivos.Location = new System.Drawing.Point(14, 3);
            this.ckSoloActivos.Name = "ckSoloActivos";
            this.ckSoloActivos.Size = new System.Drawing.Size(160, 18);
            this.ckSoloActivos.TabIndex = 0;
            this.ckSoloActivos.Text = "Solo Proveedores Activos";
            this.ckSoloActivos.UseVisualStyleBackColor = true;
            this.ckSoloActivos.CheckedChanged += new System.EventHandler(this.ckSoloActivos_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ckSoloActivos);
            this.panel2.Controls.Add(this.txtNumberVendorList);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(6, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 25);
            this.panel2.TabIndex = 101;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTipoProveedorDescripcion);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbTipoProveedor);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtVendorId);
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.txtTaxNumber);
            this.panel1.Controls.Add(this.txtTaxStatus);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Controls.Add(this.txtTaxId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbTaxType);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 111);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Vendor #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Match";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Fantasia";
            // 
            // txtNumberVendorList
            // 
            this.txtNumberVendorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtNumberVendorList.Location = new System.Drawing.Point(540, 1);
            this.txtNumberVendorList.Name = "txtNumberVendorList";
            this.txtNumberVendorList.Size = new System.Drawing.Size(30, 20);
            this.txtNumberVendorList.TabIndex = 14;
            this.txtNumberVendorList.TabStop = false;
            this.txtNumberVendorList.Text = "4";
            this.txtNumberVendorList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumberVendorList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroClientesList_KeyPress);
            this.txtNumberVendorList.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroClientesList_Validating);
            // 
            // txtVendorId
            // 
            this.txtVendorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtVendorId.Location = new System.Drawing.Point(509, 9);
            this.txtVendorId.Name = "txtVendorId";
            this.txtVendorId.Size = new System.Drawing.Size(49, 20);
            this.txtVendorId.TabIndex = 2;
            this.txtVendorId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerId6_KeyPress);
            this.txtVendorId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerId6_KeyUp);
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.BackColor = System.Drawing.Color.White;
            this.cmbFantasia.DataSource = this.T0005Bs;
            this.cmbFantasia.DisplayMember = "prov_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(108, 9);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(341, 21);
            this.cmbFantasia.TabIndex = 0;
            this.cmbFantasia.ValueMember = "id_prov";
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            this.cmbFantasia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFantasia_KeyUp);
            // 
            // txtTaxNumber
            // 
            this.txtTaxNumber.BackColor = System.Drawing.Color.White;
            this.txtTaxNumber.BeepOnError = true;
            this.txtTaxNumber.Cursor = System.Windows.Forms.Cursors.Cross;
            this.txtTaxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTaxNumber.Location = new System.Drawing.Point(225, 55);
            this.txtTaxNumber.Mask = "00-00000000-0";
            this.txtTaxNumber.Name = "txtTaxNumber";
            this.txtTaxNumber.Size = new System.Drawing.Size(108, 20);
            this.txtTaxNumber.TabIndex = 4;
            this.txtTaxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTaxNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtTaxStatus
            // 
            this.txtTaxStatus.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTaxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTaxStatus.Location = new System.Drawing.Point(334, 55);
            this.txtTaxStatus.Name = "txtTaxStatus";
            this.txtTaxStatus.ReadOnly = true;
            this.txtTaxStatus.Size = new System.Drawing.Size(115, 20);
            this.txtTaxStatus.TabIndex = 13;
            this.txtTaxStatus.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Razon Social";
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.BackColor = System.Drawing.Color.White;
            this.cmbRazonSocial.DataSource = this.T0005Bs;
            this.cmbRazonSocial.DisplayMember = "prov_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(108, 32);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(341, 21);
            this.cmbRazonSocial.TabIndex = 1;
            this.cmbRazonSocial.ValueMember = "id_prov";
            this.cmbRazonSocial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbRazonSocial_KeyUp);
            // 
            // txtTaxId
            // 
            this.txtTaxId.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTaxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTaxId.Location = new System.Drawing.Point(193, 55);
            this.txtTaxId.Name = "txtTaxId";
            this.txtTaxId.ReadOnly = true;
            this.txtTaxId.Size = new System.Drawing.Size(31, 20);
            this.txtTaxId.TabIndex = 8;
            this.txtTaxId.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TAX Data";
            // 
            // cmbTaxType
            // 
            this.cmbTaxType.FormattingEnabled = true;
            this.cmbTaxType.Items.AddRange(new object[] {
            "CUIT",
            "DNI",
            "NO INFO"});
            this.cmbTaxType.Location = new System.Drawing.Point(108, 55);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.Size = new System.Drawing.Size(82, 21);
            this.cmbTaxType.TabIndex = 3;
            // 
            // T0005Bs
            // 
            this.T0005Bs.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // T0005DgvBs
            // 
            this.T0005DgvBs.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
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
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Width = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tipo Proveedor";
            // 
            // cmbTipoProveedor
            // 
            this.cmbTipoProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoProveedor.BackColor = System.Drawing.Color.White;
            this.cmbTipoProveedor.DataSource = this.t0014TIPOPROVEEDORBindingSource;
            this.cmbTipoProveedor.DisplayMember = "TIPOPROV";
            this.cmbTipoProveedor.FormattingEnabled = true;
            this.cmbTipoProveedor.Location = new System.Drawing.Point(108, 78);
            this.cmbTipoProveedor.Name = "cmbTipoProveedor";
            this.cmbTipoProveedor.Size = new System.Drawing.Size(116, 21);
            this.cmbTipoProveedor.TabIndex = 16;
            this.cmbTipoProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbTipoProveedor_SelectedIndexChanged);
            // 
            // t0014TIPOPROVEEDORBindingSource
            // 
            this.t0014TIPOPROVEEDORBindingSource.DataSource = typeof(TecserEF.Entity.T0014_TIPO_PROVEEDOR);
            // 
            // txtTipoProveedorDescripcion
            // 
            this.txtTipoProveedorDescripcion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTipoProveedorDescripcion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0014TIPOPROVEEDORBindingSource, "TIPOPROV_DESC", true));
            this.txtTipoProveedorDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTipoProveedorDescripcion.Location = new System.Drawing.Point(225, 78);
            this.txtTipoProveedorDescripcion.Name = "txtTipoProveedorDescripcion";
            this.txtTipoProveedorDescripcion.ReadOnly = true;
            this.txtTipoProveedorDescripcion.Size = new System.Drawing.Size(224, 20);
            this.txtTipoProveedorDescripcion.TabIndex = 18;
            this.txtTipoProveedorDescripcion.TabStop = false;
            // 
            // FrmVendorSearchBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(703, 469);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvVendor);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmVendorSearchBase";
            this.Text = "FrmVendorSearchBase";
            this.Load += new System.EventHandler(this.FrmVendorSearchBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0005Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005DgvBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0014TIPOPROVEEDORBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvVendor;
        private System.Windows.Forms.CheckBox ckSoloActivos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumberVendorList;
        private System.Windows.Forms.TextBox txtVendorId;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.MaskedTextBox txtTaxNumber;
        private System.Windows.Forms.TextBox txtTaxStatus;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTaxType;
        private System.Windows.Forms.BindingSource T0005DgvBs;
        private System.Windows.Forms.BindingSource T0005Bs;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provrsocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provfantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTAX1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nTAX1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.TextBox txtTipoProveedorDescripcion;
        private System.Windows.Forms.BindingSource t0014TIPOPROVEEDORBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoProveedor;
    }
}