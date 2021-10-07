namespace MASngFE.Forms.CustomerSearchBase
{
    partial class FrmMdc00CustomerSearchBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMdc00CustomerSearchBase));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.T0006Bs = new System.Windows.Forms.BindingSource(this.components);
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTaxId = new System.Windows.Forms.TextBox();
            this.txtTaxNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtTaxStatus = new System.Windows.Forms.TextBox();
            this.txtCustomerId6 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroClientesList = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckSoloActivos = new System.Windows.Forms.CheckBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.iDCLIENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clirsocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clifantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVODataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.T0006DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.uDataGridView1 = new MASngFE.Application.UDataGridView();
            this.Accion1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uDataGridView1)).BeginInit();
            this.SuspendLayout();
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
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.T0006Bs;
            this.cmbFantasia.DisplayMember = "cli_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(108, 9);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(341, 21);
            this.cmbFantasia.TabIndex = 0;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            this.cmbFantasia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbFantasia_KeyUp);
            // 
            // T0006Bs
            // 
            this.T0006Bs.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.T0006Bs;
            this.cmbRazonSocial.DisplayMember = "cli_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(108, 32);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(341, 21);
            this.cmbRazonSocial.TabIndex = 1;
            this.cmbRazonSocial.ValueMember = "IDCLIENTE";
            this.cmbRazonSocial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbRazonSocial_KeyUp);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TAX Data";
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
            // txtTaxNumber
            // 
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNumeroClientesList);
            this.panel1.Controls.Add(this.txtCustomerId6);
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.txtTaxNumber);
            this.panel1.Controls.Add(this.txtTaxStatus);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Controls.Add(this.txtTaxId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbTaxType);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 90);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Id6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Match";
            // 
            // txtNumeroClientesList
            // 
            this.txtNumeroClientesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.txtNumeroClientesList.Location = new System.Drawing.Point(493, 55);
            this.txtNumeroClientesList.Name = "txtNumeroClientesList";
            this.txtNumeroClientesList.Size = new System.Drawing.Size(30, 20);
            this.txtNumeroClientesList.TabIndex = 14;
            this.txtNumeroClientesList.TabStop = false;
            this.txtNumeroClientesList.Text = "4";
            this.txtNumeroClientesList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroClientesList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroClientesList_KeyPress);
            this.txtNumeroClientesList.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroClientesList_Validating);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ckSoloActivos);
            this.panel2.Location = new System.Drawing.Point(5, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 25);
            this.panel2.TabIndex = 96;
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
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AutoGenerateColumns = false;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCLIENTEDataGridViewTextBoxColumn,
            this.clirsocialDataGridViewTextBoxColumn,
            this.clifantasiaDataGridViewTextBoxColumn,
            this.aCTIVODataGridViewCheckBoxColumn,
            this.Accion});
            this.dgvClientes.DataSource = this.T0006DgvBs;
            this.dgvClientes.Location = new System.Drawing.Point(5, 124);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersWidth = 20;
            this.dgvClientes.Size = new System.Drawing.Size(575, 162);
            this.dgvClientes.TabIndex = 97;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // iDCLIENTEDataGridViewTextBoxColumn
            // 
            this.iDCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "IDCLIENTE";
            this.iDCLIENTEDataGridViewTextBoxColumn.HeaderText = "Id6";
            this.iDCLIENTEDataGridViewTextBoxColumn.Name = "iDCLIENTEDataGridViewTextBoxColumn";
            this.iDCLIENTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCLIENTEDataGridViewTextBoxColumn.Width = 40;
            // 
            // clirsocialDataGridViewTextBoxColumn
            // 
            this.clirsocialDataGridViewTextBoxColumn.DataPropertyName = "cli_rsocial";
            this.clirsocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clirsocialDataGridViewTextBoxColumn.Name = "clirsocialDataGridViewTextBoxColumn";
            this.clirsocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clirsocialDataGridViewTextBoxColumn.Width = 200;
            // 
            // clifantasiaDataGridViewTextBoxColumn
            // 
            this.clifantasiaDataGridViewTextBoxColumn.DataPropertyName = "cli_fantasia";
            this.clifantasiaDataGridViewTextBoxColumn.HeaderText = "Fantasia";
            this.clifantasiaDataGridViewTextBoxColumn.Name = "clifantasiaDataGridViewTextBoxColumn";
            this.clifantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clifantasiaDataGridViewTextBoxColumn.Width = 160;
            // 
            // aCTIVODataGridViewCheckBoxColumn
            // 
            this.aCTIVODataGridViewCheckBoxColumn.DataPropertyName = "ACTIVO";
            this.aCTIVODataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.aCTIVODataGridViewCheckBoxColumn.Name = "aCTIVODataGridViewCheckBoxColumn";
            this.aCTIVODataGridViewCheckBoxColumn.ReadOnly = true;
            this.aCTIVODataGridViewCheckBoxColumn.Width = 60;
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Accion";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Width = 60;
            // 
            // T0006DgvBs
            // 
            this.T0006DgvBs.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(603, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 40);
            this.btnSalir.TabIndex = 99;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // uDataGridView1
            // 
            this.uDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Accion1});
            this.uDataGridView1.DataSource = this.T0006DgvBs;
            this.uDataGridView1.Location = new System.Drawing.Point(5, 323);
            this.uDataGridView1.Name = "uDataGridView1";
            this.uDataGridView1.Size = new System.Drawing.Size(575, 365);
            this.uDataGridView1.TabIndex = 100;
            // 
            // Accion1
            // 
            this.Accion1.HeaderText = "Accion";
            this.Accion1.Name = "Accion1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IDCLIENTE";
            this.dataGridViewTextBoxColumn1.HeaderText = "IDCLIENTE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "cli_rsocial";
            this.dataGridViewTextBoxColumn2.HeaderText = "cli_rsocial";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "cli_fantasia";
            this.dataGridViewTextBoxColumn3.HeaderText = "cli_fantasia";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "ACTIVO";
            this.dataGridViewCheckBoxColumn1.HeaderText = "ACTIVO";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // FrmMdc00CustomerSearchBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 707);
            this.Controls.Add(this.uDataGridView1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMdc00CustomerSearchBase";
            this.Text = "MDC00 - Buscador de Clientes *Base*";
            this.Load += new System.EventHandler(this.FrmCustomerSearchBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006DgvBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTaxType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.MaskedTextBox txtTaxNumber;
        private System.Windows.Forms.TextBox txtTaxStatus;
        private System.Windows.Forms.TextBox txtCustomerId6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckSoloActivos;
        protected System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroClientesList;
        public System.Windows.Forms.BindingSource T0006Bs;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCLIENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clirsocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clifantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        public System.Windows.Forms.BindingSource T0006DgvBs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn Accion1;
        public Application.UDataGridView uDataGridView1;
    }
}