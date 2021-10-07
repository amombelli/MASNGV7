namespace MASngFE._UserControls
{
    partial class UVendorSearch
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtVendorTypeDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVendorType = new System.Windows.Forms.ComboBox();
            this.T0014VendorTypeBs = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVendorId = new System.Windows.Forms.TextBox();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.T0005Bs = new System.Windows.Forms.BindingSource(this.components);
            this.txtTaxNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtTaxStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.txtTaxId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumberVendorList = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckSoloActivos = new System.Windows.Forms.CheckBox();
            this.T0005DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0014VendorTypeBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005Bs)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0005DgvBs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtVendorTypeDescription);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbVendorType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtVendorId);
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.txtTaxNumber);
            this.panel1.Controls.Add(this.txtTaxStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Controls.Add(this.txtTaxId);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbTaxType);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 108);
            this.panel1.TabIndex = 98;
            // 
            // txtVendorTypeDescription
            // 
            this.txtVendorTypeDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.txtVendorTypeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtVendorTypeDescription.Location = new System.Drawing.Point(225, 79);
            this.txtVendorTypeDescription.Name = "txtVendorTypeDescription";
            this.txtVendorTypeDescription.ReadOnly = true;
            this.txtVendorTypeDescription.Size = new System.Drawing.Size(226, 20);
            this.txtVendorTypeDescription.TabIndex = 18;
            this.txtVendorTypeDescription.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tipo Proveedor";
            // 
            // cmbVendorType
            // 
            this.cmbVendorType.DataSource = this.T0014VendorTypeBs;
            this.cmbVendorType.DisplayMember = "TIPOPROV";
            this.cmbVendorType.FormattingEnabled = true;
            this.cmbVendorType.Location = new System.Drawing.Point(111, 78);
            this.cmbVendorType.Name = "cmbVendorType";
            this.cmbVendorType.Size = new System.Drawing.Size(113, 22);
            this.cmbVendorType.TabIndex = 16;
            this.cmbVendorType.ValueMember = "TIPOPROV";
            this.cmbVendorType.SelectedIndexChanged += new System.EventHandler(this.cmbVendorType_SelectedIndexChanged);
            this.cmbVendorType.SelectionChangeCommitted += new System.EventHandler(this.cmbVendorType_SelectionChangeCommitted);
            this.cmbVendorType.Enter += new System.EventHandler(this.cmbVendorType_Enter);
            // 
            // T0014VendorTypeBs
            // 
            this.T0014VendorTypeBs.DataSource = typeof(TecserEF.Entity.T0014_TIPO_PROVEEDOR);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Vendor#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Fantasia";
            // 
            // txtVendorId
            // 
            this.txtVendorId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtVendorId.Location = new System.Drawing.Point(514, 9);
            this.txtVendorId.Name = "txtVendorId";
            this.txtVendorId.Size = new System.Drawing.Size(58, 20);
            this.txtVendorId.TabIndex = 2;
            this.txtVendorId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVendorId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVendorId_KeyPress);
            this.txtVendorId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVendorId_KeyUp);
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.T0005Bs;
            this.cmbFantasia.DisplayMember = "prov_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(111, 9);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(340, 22);
            this.cmbFantasia.TabIndex = 0;
            this.cmbFantasia.ValueMember = "id_prov";
            this.cmbFantasia.SelectionChangeCommitted += new System.EventHandler(this.cmbFantasia_SelectionChangeCommitted);
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbFantasia_TextUpdate);
            this.cmbFantasia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFantasia_KeyUp);
            // 
            // T0005Bs
            // 
            this.T0005Bs.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // txtTaxNumber
            // 
            this.txtTaxNumber.BeepOnError = true;
            this.txtTaxNumber.Cursor = System.Windows.Forms.Cursors.Cross;
            this.txtTaxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTaxNumber.Location = new System.Drawing.Point(225, 56);
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
            this.txtTaxStatus.Location = new System.Drawing.Point(334, 56);
            this.txtTaxStatus.Name = "txtTaxStatus";
            this.txtTaxStatus.ReadOnly = true;
            this.txtTaxStatus.Size = new System.Drawing.Size(117, 20);
            this.txtTaxStatus.TabIndex = 13;
            this.txtTaxStatus.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Razon Social";
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.T0005Bs;
            this.cmbRazonSocial.DisplayMember = "prov_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(111, 32);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(340, 22);
            this.cmbRazonSocial.TabIndex = 1;
            this.cmbRazonSocial.ValueMember = "id_prov";
            this.cmbRazonSocial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbRazonSocial_KeyUp);
            // 
            // txtTaxId
            // 
            this.txtTaxId.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTaxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtTaxId.Location = new System.Drawing.Point(193, 56);
            this.txtTaxId.Name = "txtTaxId";
            this.txtTaxId.ReadOnly = true;
            this.txtTaxId.Size = new System.Drawing.Size(31, 20);
            this.txtTaxId.TabIndex = 8;
            this.txtTaxId.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "TAX Data";
            // 
            // cmbTaxType
            // 
            this.cmbTaxType.FormattingEnabled = true;
            this.cmbTaxType.Items.AddRange(new object[] {
            "CUIT",
            "DNI",
            "NO INFO"});
            this.cmbTaxType.Location = new System.Drawing.Point(111, 55);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.Size = new System.Drawing.Size(81, 22);
            this.cmbTaxType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Match";
            // 
            // txtNumberVendorList
            // 
            this.txtNumberVendorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtNumberVendorList.Location = new System.Drawing.Point(542, 1);
            this.txtNumberVendorList.Name = "txtNumberVendorList";
            this.txtNumberVendorList.Size = new System.Drawing.Size(30, 20);
            this.txtNumberVendorList.TabIndex = 14;
            this.txtNumberVendorList.TabStop = false;
            this.txtNumberVendorList.Text = "4";
            this.txtNumberVendorList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumberVendorList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberVendorList_KeyPress);
            this.txtNumberVendorList.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumberVendorList_Validating);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ckSoloActivos);
            this.panel2.Controls.Add(this.txtNumberVendorList);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 24);
            this.panel2.TabIndex = 99;
            // 
            // ckSoloActivos
            // 
            this.ckSoloActivos.AutoSize = true;
            this.ckSoloActivos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloActivos.Location = new System.Drawing.Point(14, 3);
            this.ckSoloActivos.Name = "ckSoloActivos";
            this.ckSoloActivos.Size = new System.Drawing.Size(160, 18);
            this.ckSoloActivos.TabIndex = 94;
            this.ckSoloActivos.Text = "Solo Proveedores Activos";
            this.ckSoloActivos.UseVisualStyleBackColor = true;
            this.ckSoloActivos.CheckedChanged += new System.EventHandler(this.ckSoloActivos_CheckedChanged_1);
            // 
            // T0005DgvBs
            // 
            this.T0005DgvBs.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // UVendorSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UVendorSearch";
            this.Size = new System.Drawing.Size(578, 135);
            this.Load += new System.EventHandler(this.UVendorSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0014VendorTypeBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005Bs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0005DgvBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumberVendorList;
        private System.Windows.Forms.TextBox txtVendorId;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.MaskedTextBox txtTaxNumber;
        private System.Windows.Forms.TextBox txtTaxStatus;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTaxType;
        private System.Windows.Forms.TextBox txtVendorTypeDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVendorType;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckSoloActivos;
        private System.Windows.Forms.BindingSource T0005Bs;
        private System.Windows.Forms.BindingSource T0014VendorTypeBs;
        public System.Windows.Forms.BindingSource T0005DgvBs;
    }
}
