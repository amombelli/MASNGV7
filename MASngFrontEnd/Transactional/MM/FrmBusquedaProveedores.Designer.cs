namespace MASngFE.Transactional.MM
{
    partial class FrmBusquedaProveedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.t0005MPROVEEDORESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckSoloActivo = new System.Windows.Forms.CheckBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDetalleOC = new System.Windows.Forms.DataGridView();
            this.OCHeaderBS = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGLAp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVendorType = new System.Windows.Forms.TextBox();
            this.cmbIdProveedor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoTax = new System.Windows.Forms.ComboBox();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.btnVerMaestro = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBusquedaAvanzada = new System.Windows.Forms.Button();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.txtNumeroTax = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTaxValido = new System.Windows.Forms.TextBox();
            this.txtCodigoTax = new System.Windows.Forms.TextBox();
            this.ckSoloPermitidos = new System.Windows.Forms.CheckBox();
            this.iDORDENCOMPRADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pROVEEDORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHAOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATUSOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONEDAOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVisualizar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.t0005MPROVEEDORESBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OCHeaderBS)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // t0005MPROVEEDORESBindingSource
            // 
            this.t0005MPROVEEDORESBindingSource.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // ckSoloActivo
            // 
            this.ckSoloActivo.AutoSize = true;
            this.ckSoloActivo.Checked = true;
            this.ckSoloActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSoloActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloActivo.ForeColor = System.Drawing.Color.DarkGreen;
            this.ckSoloActivo.Location = new System.Drawing.Point(538, 84);
            this.ckSoloActivo.Name = "ckSoloActivo";
            this.ckSoloActivo.Size = new System.Drawing.Size(91, 19);
            this.ckSoloActivo.TabIndex = 113;
            this.ckSoloActivo.Text = "Solo Activos";
            this.ckSoloActivo.UseVisualStyleBackColor = true;
            this.ckSoloActivo.CheckedChanged += new System.EventHandler(this.ckSoloActivo_CheckedChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(4, 81);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(103, 39);
            this.btnSalir.TabIndex = 114;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(4, 3);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(103, 39);
            this.btn1.TabIndex = 119;
            this.btn1.Text = "Nueva OC";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(4, 42);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(103, 39);
            this.btn2.TabIndex = 120;
            this.btn2.Text = "Ver InfoRecord";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Controls.Add(this.btn2);
            this.panel1.Location = new System.Drawing.Point(662, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(112, 128);
            this.panel1.TabIndex = 121;
            // 
            // dgvDetalleOC
            // 
            this.dgvDetalleOC.AllowUserToAddRows = false;
            this.dgvDetalleOC.AllowUserToDeleteRows = false;
            this.dgvDetalleOC.AllowUserToResizeColumns = false;
            this.dgvDetalleOC.AllowUserToResizeRows = false;
            this.dgvDetalleOC.AutoGenerateColumns = false;
            this.dgvDetalleOC.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleOC.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetalleOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleOC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDORDENCOMPRADataGridViewTextBoxColumn,
            this.pROVEEDORDataGridViewTextBoxColumn,
            this.fECHAOCDataGridViewTextBoxColumn,
            this.sTATUSOCDataGridViewTextBoxColumn,
            this.mONEDAOCDataGridViewTextBoxColumn,
            this.totalOCDataGridViewTextBoxColumn,
            this.tCDataGridViewTextBoxColumn,
            this.btnVisualizar});
            this.dgvDetalleOC.DataSource = this.OCHeaderBS;
            this.dgvDetalleOC.Location = new System.Drawing.Point(2, 132);
            this.dgvDetalleOC.MultiSelect = false;
            this.dgvDetalleOC.Name = "dgvDetalleOC";
            this.dgvDetalleOC.ReadOnly = true;
            this.dgvDetalleOC.RowHeadersWidth = 20;
            this.dgvDetalleOC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleOC.Size = new System.Drawing.Size(580, 369);
            this.dgvDetalleOC.TabIndex = 123;
            this.dgvDetalleOC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleOC_CellContentClick);
            // 
            // OCHeaderBS
            // 
            this.OCHeaderBS.DataSource = typeof(TecserEF.Entity.T0060_OCOMPRA_H);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ckSoloPermitidos);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtGLAp);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtVendorType);
            this.panel3.Controls.Add(this.cmbIdProveedor);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cmbTipoTax);
            this.panel3.Controls.Add(this.cmbRazonSocial);
            this.panel3.Controls.Add(this.btnVerMaestro);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.ckSoloActivo);
            this.panel3.Controls.Add(this.btnBusquedaAvanzada);
            this.panel3.Controls.Add(this.cmbFantasia);
            this.panel3.Controls.Add(this.txtNumeroTax);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.txtTaxValido);
            this.panel3.Controls.Add(this.txtCodigoTax);
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(659, 128);
            this.panel3.TabIndex = 124;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "G/L AP";
            // 
            // txtGLAp
            // 
            this.txtGLAp.Location = new System.Drawing.Point(324, 84);
            this.txtGLAp.Name = "txtGLAp";
            this.txtGLAp.ReadOnly = true;
            this.txtGLAp.Size = new System.Drawing.Size(78, 20);
            this.txtGLAp.TabIndex = 21;
            this.txtGLAp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(9, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 3);
            this.label7.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "TIPO VENDOR";
            // 
            // txtVendorType
            // 
            this.txtVendorType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0005MPROVEEDORESBindingSource, "TIPO", true));
            this.txtVendorType.Location = new System.Drawing.Point(121, 84);
            this.txtVendorType.Name = "txtVendorType";
            this.txtVendorType.ReadOnly = true;
            this.txtVendorType.Size = new System.Drawing.Size(110, 20);
            this.txtVendorType.TabIndex = 17;
            this.txtVendorType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbIdProveedor
            // 
            this.cmbIdProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbIdProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIdProveedor.DataSource = this.t0005MPROVEEDORESBindingSource;
            this.cmbIdProveedor.DisplayMember = "id_prov";
            this.cmbIdProveedor.FormattingEnabled = true;
            this.cmbIdProveedor.Location = new System.Drawing.Point(406, 8);
            this.cmbIdProveedor.Name = "cmbIdProveedor";
            this.cmbIdProveedor.Size = new System.Drawing.Size(72, 21);
            this.cmbIdProveedor.TabIndex = 15;
            this.cmbIdProveedor.ValueMember = "id_prov";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "RAZON SOCIAL";
            // 
            // cmbTipoTax
            // 
            this.cmbTipoTax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoTax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoTax.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbTipoTax.FormattingEnabled = true;
            this.cmbTipoTax.Items.AddRange(new object[] {
            "CUIT",
            "NI"});
            this.cmbTipoTax.Location = new System.Drawing.Point(121, 54);
            this.cmbTipoTax.Name = "cmbTipoTax";
            this.cmbTipoTax.Size = new System.Drawing.Size(71, 21);
            this.cmbTipoTax.TabIndex = 14;
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.t0005MPROVEEDORESBindingSource;
            this.cmbRazonSocial.DisplayMember = "prov_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(121, 8);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(281, 21);
            this.cmbRazonSocial.TabIndex = 3;
            this.cmbRazonSocial.ValueMember = "id_prov";
            // 
            // btnVerMaestro
            // 
            this.btnVerMaestro.Location = new System.Drawing.Point(550, 42);
            this.btnVerMaestro.Name = "btnVerMaestro";
            this.btnVerMaestro.Size = new System.Drawing.Size(103, 39);
            this.btnVerMaestro.TabIndex = 13;
            this.btnVerMaestro.Text = "Maestro";
            this.btnVerMaestro.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "NOMBRE FANTASIA";
            // 
            // btnBusquedaAvanzada
            // 
            this.btnBusquedaAvanzada.Location = new System.Drawing.Point(550, 3);
            this.btnBusquedaAvanzada.Name = "btnBusquedaAvanzada";
            this.btnBusquedaAvanzada.Size = new System.Drawing.Size(103, 39);
            this.btnBusquedaAvanzada.TabIndex = 12;
            this.btnBusquedaAvanzada.Text = "Busqueda Avanzada";
            this.btnBusquedaAvanzada.UseVisualStyleBackColor = true;
            this.btnBusquedaAvanzada.Click += new System.EventHandler(this.btnBusquedaAvanzada_Click);
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.t0005MPROVEEDORESBindingSource;
            this.cmbFantasia.DisplayMember = "prov_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(121, 31);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(281, 21);
            this.cmbFantasia.TabIndex = 5;
            this.cmbFantasia.ValueMember = "id_prov";
            this.cmbFantasia.Validating += new System.ComponentModel.CancelEventHandler(this.cmbFantasia_Validating);
            // 
            // txtNumeroTax
            // 
            this.txtNumeroTax.BeepOnError = true;
            this.txtNumeroTax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0005MPROVEEDORESBindingSource, "NTAX1", true));
            this.txtNumeroTax.Location = new System.Drawing.Point(234, 55);
            this.txtNumeroTax.Mask = "00-00000000-0";
            this.txtNumeroTax.Name = "txtNumeroTax";
            this.txtNumeroTax.ReadOnly = true;
            this.txtNumeroTax.Size = new System.Drawing.Size(88, 20);
            this.txtNumeroTax.TabIndex = 11;
            this.txtNumeroTax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "TAX NUMBER";
            // 
            // txtTaxValido
            // 
            this.txtTaxValido.Location = new System.Drawing.Point(324, 55);
            this.txtTaxValido.Name = "txtTaxValido";
            this.txtTaxValido.Size = new System.Drawing.Size(78, 20);
            this.txtTaxValido.TabIndex = 9;
            this.txtTaxValido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCodigoTax
            // 
            this.txtCodigoTax.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0005MPROVEEDORESBindingSource, "TTAX1", true));
            this.txtCodigoTax.Location = new System.Drawing.Point(197, 55);
            this.txtCodigoTax.Name = "txtCodigoTax";
            this.txtCodigoTax.Size = new System.Drawing.Size(34, 20);
            this.txtCodigoTax.TabIndex = 8;
            // 
            // ckSoloPermitidos
            // 
            this.ckSoloPermitidos.AutoSize = true;
            this.ckSoloPermitidos.Checked = true;
            this.ckSoloPermitidos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSoloPermitidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloPermitidos.ForeColor = System.Drawing.Color.DarkGreen;
            this.ckSoloPermitidos.Location = new System.Drawing.Point(538, 104);
            this.ckSoloPermitidos.Name = "ckSoloPermitidos";
            this.ckSoloPermitidos.Size = new System.Drawing.Size(113, 19);
            this.ckSoloPermitidos.TabIndex = 114;
            this.ckSoloPermitidos.Text = "Solo Permitidos";
            this.ckSoloPermitidos.UseVisualStyleBackColor = true;
            this.ckSoloPermitidos.CheckedChanged += new System.EventHandler(this.ckSoloPermitidos_CheckedChanged);
            // 
            // iDORDENCOMPRADataGridViewTextBoxColumn
            // 
            this.iDORDENCOMPRADataGridViewTextBoxColumn.DataPropertyName = "IDORDENCOMPRA";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.iDORDENCOMPRADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.iDORDENCOMPRADataGridViewTextBoxColumn.HeaderText = "# OC";
            this.iDORDENCOMPRADataGridViewTextBoxColumn.Name = "iDORDENCOMPRADataGridViewTextBoxColumn";
            this.iDORDENCOMPRADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDORDENCOMPRADataGridViewTextBoxColumn.Width = 60;
            // 
            // pROVEEDORDataGridViewTextBoxColumn
            // 
            this.pROVEEDORDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.pROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "PROVEEDOR";
            this.pROVEEDORDataGridViewTextBoxColumn.HeaderText = "PROVEEDOR";
            this.pROVEEDORDataGridViewTextBoxColumn.Name = "pROVEEDORDataGridViewTextBoxColumn";
            this.pROVEEDORDataGridViewTextBoxColumn.ReadOnly = true;
            this.pROVEEDORDataGridViewTextBoxColumn.Visible = false;
            // 
            // fECHAOCDataGridViewTextBoxColumn
            // 
            this.fECHAOCDataGridViewTextBoxColumn.DataPropertyName = "FECHAOC";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.fECHAOCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.fECHAOCDataGridViewTextBoxColumn.HeaderText = "FECHA OC";
            this.fECHAOCDataGridViewTextBoxColumn.Name = "fECHAOCDataGridViewTextBoxColumn";
            this.fECHAOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHAOCDataGridViewTextBoxColumn.Width = 110;
            // 
            // sTATUSOCDataGridViewTextBoxColumn
            // 
            this.sTATUSOCDataGridViewTextBoxColumn.DataPropertyName = "STATUSOC";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sTATUSOCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.sTATUSOCDataGridViewTextBoxColumn.HeaderText = "STATUS OC";
            this.sTATUSOCDataGridViewTextBoxColumn.Name = "sTATUSOCDataGridViewTextBoxColumn";
            this.sTATUSOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mONEDAOCDataGridViewTextBoxColumn
            // 
            this.mONEDAOCDataGridViewTextBoxColumn.DataPropertyName = "MONEDAOC";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mONEDAOCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.mONEDAOCDataGridViewTextBoxColumn.HeaderText = "MON";
            this.mONEDAOCDataGridViewTextBoxColumn.Name = "mONEDAOCDataGridViewTextBoxColumn";
            this.mONEDAOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.mONEDAOCDataGridViewTextBoxColumn.Width = 45;
            // 
            // totalOCDataGridViewTextBoxColumn
            // 
            this.totalOCDataGridViewTextBoxColumn.DataPropertyName = "TotalOC";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.NullValue = "0";
            this.totalOCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.totalOCDataGridViewTextBoxColumn.HeaderText = "TOTAL OC";
            this.totalOCDataGridViewTextBoxColumn.Name = "totalOCDataGridViewTextBoxColumn";
            this.totalOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tCDataGridViewTextBoxColumn
            // 
            this.tCDataGridViewTextBoxColumn.DataPropertyName = "TC";
            this.tCDataGridViewTextBoxColumn.HeaderText = "TC";
            this.tCDataGridViewTextBoxColumn.Name = "tCDataGridViewTextBoxColumn";
            this.tCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tCDataGridViewTextBoxColumn.Width = 45;
            // 
            // btnVisualizar
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.DefaultCellStyle = dataGridViewCellStyle12;
            this.btnVisualizar.HeaderText = "ACCION";
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.ReadOnly = true;
            this.btnVisualizar.Text = "EDIT";
            this.btnVisualizar.ToolTipText = "Editar/Visualizar OC";
            this.btnVisualizar.UseColumnTextForButtonValue = true;
            this.btnVisualizar.Width = 50;
            // 
            // FrmBusquedaProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(777, 503);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvDetalleOC);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmBusquedaProveedores";
            this.Text = "PO MENU - MENU DE ORDEN DE COMPRA";
            this.Load += new System.EventHandler(this.FrmBusquedaProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0005MPROVEEDORESBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OCHeaderBS)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox ckSoloActivo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDetalleOC;
        private System.Windows.Forms.BindingSource OCHeaderBS;
        private System.Windows.Forms.BindingSource t0005MPROVEEDORESBindingSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGLAp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVendorType;
        private System.Windows.Forms.ComboBox cmbIdProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoTax;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.Button btnVerMaestro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBusquedaAvanzada;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.MaskedTextBox txtNumeroTax;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTaxValido;
        private System.Windows.Forms.TextBox txtCodigoTax;
        private System.Windows.Forms.CheckBox ckSoloPermitidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDORDENCOMPRADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pROVEEDORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHAOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTATUSOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONEDAOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnVisualizar;
    }
}