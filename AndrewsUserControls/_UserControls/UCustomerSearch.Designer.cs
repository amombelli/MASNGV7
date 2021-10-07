namespace MASngFE._UserControls
{
    partial class UCustomerSearch
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckSoloActivos = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumeroClientesList = new System.Windows.Forms.TextBox();
            this.txtCustomerId6 = new System.Windows.Forms.TextBox();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.T0006Bs = new System.Windows.Forms.BindingSource(this.components);
            this.txtTaxNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtTaxStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.txtTaxId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.T0006DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ckSoloActivos);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 25);
            this.panel2.TabIndex = 98;
            // 
            // ckSoloActivos
            // 
            this.ckSoloActivos.AutoSize = true;
            this.ckSoloActivos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloActivos.Location = new System.Drawing.Point(14, 3);
            this.ckSoloActivos.Name = "ckSoloActivos";
            this.ckSoloActivos.Size = new System.Drawing.Size(138, 18);
            this.ckSoloActivos.TabIndex = 94;
            this.ckSoloActivos.Text = "Solo Clientes Activos";
            this.ckSoloActivos.UseVisualStyleBackColor = true;
            this.ckSoloActivos.CheckedChanged += new System.EventHandler(this.ckSoloActivos_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNumeroClientesList);
            this.panel1.Controls.Add(this.txtCustomerId6);
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
            this.panel1.Size = new System.Drawing.Size(577, 90);
            this.panel1.TabIndex = 97;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Id6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Match";
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
            // txtNumeroClientesList
            // 
            this.txtNumeroClientesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtNumeroClientesList.Location = new System.Drawing.Point(493, 56);
            this.txtNumeroClientesList.Name = "txtNumeroClientesList";
            this.txtNumeroClientesList.Size = new System.Drawing.Size(30, 20);
            this.txtNumeroClientesList.TabIndex = 14;
            this.txtNumeroClientesList.TabStop = false;
            this.txtNumeroClientesList.Text = "4";
            this.txtNumeroClientesList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroClientesList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroClientesList_KeyPress);
            this.txtNumeroClientesList.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroClientesList_Validating);
            // 
            // txtCustomerId6
            // 
            this.txtCustomerId6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtCustomerId6.Location = new System.Drawing.Point(478, 9);
            this.txtCustomerId6.Name = "txtCustomerId6";
            this.txtCustomerId6.Size = new System.Drawing.Size(45, 20);
            this.txtCustomerId6.TabIndex = 2;
            this.txtCustomerId6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustomerId6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerId6_KeyPress);
            this.txtCustomerId6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerId6_KeyUp);
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.T0006Bs;
            this.cmbFantasia.DisplayMember = "cli_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(111, 9);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(340, 22);
            this.cmbFantasia.TabIndex = 0;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            this.cmbFantasia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFantasia_KeyUp);
            // 
            // T0006Bs
            // 
            this.T0006Bs.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
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
            this.txtTaxStatus.Size = new System.Drawing.Size(115, 20);
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
            this.cmbRazonSocial.DataSource = this.T0006Bs;
            this.cmbRazonSocial.DisplayMember = "cli_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(111, 32);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(340, 22);
            this.cmbRazonSocial.TabIndex = 1;
            this.cmbRazonSocial.ValueMember = "IDCLIENTE";
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
            // T0006DgvBs
            // 
            this.T0006DgvBs.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // UCustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UCustomerSearch";
            this.Size = new System.Drawing.Size(577, 117);
            this.Load += new System.EventHandler(this.UCustomerSearch_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckSoloActivos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroClientesList;
        private System.Windows.Forms.TextBox txtCustomerId6;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.MaskedTextBox txtTaxNumber;
        private System.Windows.Forms.TextBox txtTaxStatus;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTaxType;
        public System.Windows.Forms.BindingSource T0006DgvBs;
        public System.Windows.Forms.BindingSource T0006Bs;
    }
}
