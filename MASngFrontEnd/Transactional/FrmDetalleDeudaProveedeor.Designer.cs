namespace MASngFE.Transactional
{
    partial class FrmDetalleDeudaProveedeor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvListadoDocumentos = new System.Windows.Forms.DataGridView();
            this.t0203CTACTEPROVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGLAp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVendorType = new System.Windows.Forms.TextBox();
            this.cmbIdProveedor = new System.Windows.Forms.ComboBox();
            this.proveedoresBs = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoTax = new System.Windows.Forms.ComboBox();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.btnVerMaestro = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBusquedaAvanzada = new System.Windows.Forms.Button();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.txtNumeroTax = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTaxValido = new System.Windows.Forms.TextBox();
            this.txtCodigoTax = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSaldoTotal = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtSaldoL1 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSaldoL2 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.ckSoloDocumentosConSaldo = new System.Windows.Forms.CheckBox();
            this.iDCTACTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMDOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONEDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEORIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALDOFACTURADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zTERMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0203CTACTEPROVBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBs)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListadoDocumentos
            // 
            this.dgvListadoDocumentos.AllowUserToAddRows = false;
            this.dgvListadoDocumentos.AllowUserToDeleteRows = false;
            this.dgvListadoDocumentos.AutoGenerateColumns = false;
            this.dgvListadoDocumentos.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvListadoDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCTACTEDataGridViewTextBoxColumn,
            this.tDOCDataGridViewTextBoxColumn,
            this.nUMDOCDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.mONEDADataGridViewTextBoxColumn,
            this.iMPORTEORIDataGridViewTextBoxColumn,
            this.sALDOFACTURADataGridViewTextBoxColumn,
            this.zTERMDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.Detalle});
            this.dgvListadoDocumentos.DataSource = this.t0203CTACTEPROVBindingSource;
            this.dgvListadoDocumentos.Location = new System.Drawing.Point(2, 162);
            this.dgvListadoDocumentos.Name = "dgvListadoDocumentos";
            this.dgvListadoDocumentos.ReadOnly = true;
            this.dgvListadoDocumentos.Size = new System.Drawing.Size(672, 362);
            this.dgvListadoDocumentos.TabIndex = 0;
            this.dgvListadoDocumentos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoDocumentos_CellContentClick);
            // 
            // t0203CTACTEPROVBindingSource
            // 
            this.t0203CTACTEPROVBindingSource.DataSource = typeof(TecserEF.Entity.T0203_CTACTE_PROV);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(936, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 39);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtGLAp);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtVendorType);
            this.panel1.Controls.Add(this.cmbIdProveedor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbTipoTax);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Controls.Add(this.btnVerMaestro);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnBusquedaAvanzada);
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.txtNumeroTax);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTaxValido);
            this.panel1.Controls.Add(this.txtCodigoTax);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 110);
            this.panel1.TabIndex = 3;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tipo Vendor";
            // 
            // txtVendorType
            // 
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
            this.cmbIdProveedor.DataSource = this.proveedoresBs;
            this.cmbIdProveedor.DisplayMember = "id_prov";
            this.cmbIdProveedor.FormattingEnabled = true;
            this.cmbIdProveedor.Location = new System.Drawing.Point(403, 8);
            this.cmbIdProveedor.Name = "cmbIdProveedor";
            this.cmbIdProveedor.Size = new System.Drawing.Size(72, 21);
            this.cmbIdProveedor.TabIndex = 15;
            this.cmbIdProveedor.ValueMember = "id_prov";
            this.cmbIdProveedor.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            // 
            // proveedoresBs
            // 
            this.proveedoresBs.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Razon Social";
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
            this.cmbTipoTax.Location = new System.Drawing.Point(121, 52);
            this.cmbTipoTax.Name = "cmbTipoTax";
            this.cmbTipoTax.Size = new System.Drawing.Size(71, 21);
            this.cmbTipoTax.TabIndex = 14;
            this.cmbTipoTax.SelectedIndexChanged += new System.EventHandler(this.cmbTipoTax_SelectedIndexChanged);
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.proveedoresBs;
            this.cmbRazonSocial.DisplayMember = "prov_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(121, 8);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(281, 21);
            this.cmbRazonSocial.TabIndex = 3;
            this.cmbRazonSocial.ValueMember = "id_prov";
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            this.cmbRazonSocial.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            // 
            // btnVerMaestro
            // 
            this.btnVerMaestro.Location = new System.Drawing.Point(494, 38);
            this.btnVerMaestro.Name = "btnVerMaestro";
            this.btnVerMaestro.Size = new System.Drawing.Size(100, 35);
            this.btnVerMaestro.TabIndex = 13;
            this.btnVerMaestro.Text = "Maestro";
            this.btnVerMaestro.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre Fantasia";
            // 
            // btnBusquedaAvanzada
            // 
            this.btnBusquedaAvanzada.Location = new System.Drawing.Point(494, 5);
            this.btnBusquedaAvanzada.Name = "btnBusquedaAvanzada";
            this.btnBusquedaAvanzada.Size = new System.Drawing.Size(100, 35);
            this.btnBusquedaAvanzada.TabIndex = 12;
            this.btnBusquedaAvanzada.Text = "Busqueda Avanzada";
            this.btnBusquedaAvanzada.UseVisualStyleBackColor = true;
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.proveedoresBs;
            this.cmbFantasia.DisplayMember = "prov_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(121, 30);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(281, 21);
            this.cmbFantasia.TabIndex = 5;
            this.cmbFantasia.ValueMember = "id_prov";
            this.cmbFantasia.TextUpdate += new System.EventHandler(this.cmbRazonSocial_TextUpdate);
            // 
            // txtNumeroTax
            // 
            this.txtNumeroTax.BeepOnError = true;
            this.txtNumeroTax.Location = new System.Drawing.Point(234, 52);
            this.txtNumeroTax.Mask = "00-00000000-0";
            this.txtNumeroTax.Name = "txtNumeroTax";
            this.txtNumeroTax.ReadOnly = true;
            this.txtNumeroTax.Size = new System.Drawing.Size(88, 20);
            this.txtNumeroTax.TabIndex = 11;
            this.txtNumeroTax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNumeroTax.TextChanged += new System.EventHandler(this.txtNumeroTax_TextChanged);
            this.txtNumeroTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroTax_KeyUp);
            this.txtNumeroTax.Leave += new System.EventHandler(this.txtNumeroTax_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tax Number (TXID)";
            // 
            // txtTaxValido
            // 
            this.txtTaxValido.Location = new System.Drawing.Point(324, 52);
            this.txtTaxValido.Name = "txtTaxValido";
            this.txtTaxValido.Size = new System.Drawing.Size(78, 20);
            this.txtTaxValido.TabIndex = 9;
            this.txtTaxValido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCodigoTax
            // 
            this.txtCodigoTax.Location = new System.Drawing.Point(199, 52);
            this.txtCodigoTax.Name = "txtCodigoTax";
            this.txtCodigoTax.Size = new System.Drawing.Size(34, 20);
            this.txtCodigoTax.TabIndex = 8;
            this.txtCodigoTax.TextChanged += new System.EventHandler(this.txtCodigoTax_TextChanged);
            this.txtCodigoTax.Leave += new System.EventHandler(this.txtCodigoTax_Leave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtSaldoTotal);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.txtSaldoL1);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.txtSaldoL2);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Location = new System.Drawing.Point(611, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 110);
            this.panel2.TabIndex = 91;
            // 
            // txtSaldoTotal
            // 
            this.txtSaldoTotal.Location = new System.Drawing.Point(88, 73);
            this.txtSaldoTotal.Name = "txtSaldoTotal";
            this.txtSaldoTotal.ReadOnly = true;
            this.txtSaldoTotal.Size = new System.Drawing.Size(93, 20);
            this.txtSaldoTotal.TabIndex = 67;
            this.txtSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(12, 74);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(69, 15);
            this.label45.TabIndex = 68;
            this.label45.Text = "Saldo Total";
            // 
            // txtSaldoL1
            // 
            this.txtSaldoL1.Location = new System.Drawing.Point(88, 9);
            this.txtSaldoL1.Name = "txtSaldoL1";
            this.txtSaldoL1.ReadOnly = true;
            this.txtSaldoL1.Size = new System.Drawing.Size(93, 20);
            this.txtSaldoL1.TabIndex = 63;
            this.txtSaldoL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 15);
            this.label26.TabIndex = 64;
            this.label26.Text = "Saldo L1";
            // 
            // txtSaldoL2
            // 
            this.txtSaldoL2.Location = new System.Drawing.Point(88, 30);
            this.txtSaldoL2.Name = "txtSaldoL2";
            this.txtSaldoL2.ReadOnly = true;
            this.txtSaldoL2.Size = new System.Drawing.Size(93, 20);
            this.txtSaldoL2.TabIndex = 65;
            this.txtSaldoL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(12, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 15);
            this.label25.TabIndex = 66;
            this.label25.Text = "Saldo L2";
            // 
            // ckSoloDocumentosConSaldo
            // 
            this.ckSoloDocumentosConSaldo.AutoSize = true;
            this.ckSoloDocumentosConSaldo.Location = new System.Drawing.Point(5, 124);
            this.ckSoloDocumentosConSaldo.Name = "ckSoloDocumentosConSaldo";
            this.ckSoloDocumentosConSaldo.Size = new System.Drawing.Size(170, 17);
            this.ckSoloDocumentosConSaldo.TabIndex = 92;
            this.ckSoloDocumentosConSaldo.Text = "Solo Documentos con SALDO";
            this.ckSoloDocumentosConSaldo.UseVisualStyleBackColor = true;
            this.ckSoloDocumentosConSaldo.CheckedChanged += new System.EventHandler(this.ckSoloDocumentosConSaldo_CheckedChanged);
            // 
            // iDCTACTEDataGridViewTextBoxColumn
            // 
            this.iDCTACTEDataGridViewTextBoxColumn.DataPropertyName = "IDCTACTE";
            this.iDCTACTEDataGridViewTextBoxColumn.HeaderText = "IDCtaCte";
            this.iDCTACTEDataGridViewTextBoxColumn.Name = "iDCTACTEDataGridViewTextBoxColumn";
            this.iDCTACTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCTACTEDataGridViewTextBoxColumn.Width = 60;
            // 
            // tDOCDataGridViewTextBoxColumn
            // 
            this.tDOCDataGridViewTextBoxColumn.DataPropertyName = "TDOC";
            this.tDOCDataGridViewTextBoxColumn.HeaderText = "TDoc";
            this.tDOCDataGridViewTextBoxColumn.Name = "tDOCDataGridViewTextBoxColumn";
            this.tDOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tDOCDataGridViewTextBoxColumn.Width = 40;
            // 
            // nUMDOCDataGridViewTextBoxColumn
            // 
            this.nUMDOCDataGridViewTextBoxColumn.DataPropertyName = "NUMDOC";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nUMDOCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nUMDOCDataGridViewTextBoxColumn.HeaderText = "Numero Doc";
            this.nUMDOCDataGridViewTextBoxColumn.Name = "nUMDOCDataGridViewTextBoxColumn";
            this.nUMDOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 80;
            // 
            // mONEDADataGridViewTextBoxColumn
            // 
            this.mONEDADataGridViewTextBoxColumn.DataPropertyName = "MONEDA";
            this.mONEDADataGridViewTextBoxColumn.HeaderText = "Mon";
            this.mONEDADataGridViewTextBoxColumn.Name = "mONEDADataGridViewTextBoxColumn";
            this.mONEDADataGridViewTextBoxColumn.ReadOnly = true;
            this.mONEDADataGridViewTextBoxColumn.Width = 30;
            // 
            // iMPORTEORIDataGridViewTextBoxColumn
            // 
            this.iMPORTEORIDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE_ORI";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = "0";
            this.iMPORTEORIDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.iMPORTEORIDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.iMPORTEORIDataGridViewTextBoxColumn.Name = "iMPORTEORIDataGridViewTextBoxColumn";
            this.iMPORTEORIDataGridViewTextBoxColumn.ReadOnly = true;
            this.iMPORTEORIDataGridViewTextBoxColumn.Width = 80;
            // 
            // sALDOFACTURADataGridViewTextBoxColumn
            // 
            this.sALDOFACTURADataGridViewTextBoxColumn.DataPropertyName = "SALDOFACTURA";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = "0";
            this.sALDOFACTURADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.sALDOFACTURADataGridViewTextBoxColumn.HeaderText = "Saldo PP";
            this.sALDOFACTURADataGridViewTextBoxColumn.Name = "sALDOFACTURADataGridViewTextBoxColumn";
            this.sALDOFACTURADataGridViewTextBoxColumn.ReadOnly = true;
            this.sALDOFACTURADataGridViewTextBoxColumn.Width = 80;
            // 
            // zTERMDataGridViewTextBoxColumn
            // 
            this.zTERMDataGridViewTextBoxColumn.DataPropertyName = "ZTERM";
            this.zTERMDataGridViewTextBoxColumn.HeaderText = "Zterm";
            this.zTERMDataGridViewTextBoxColumn.Name = "zTERMDataGridViewTextBoxColumn";
            this.zTERMDataGridViewTextBoxColumn.ReadOnly = true;
            this.zTERMDataGridViewTextBoxColumn.Width = 50;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "Lx";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 30;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Text = "Detalle";
            this.Detalle.ToolTipText = "Ver documentos";
            this.Detalle.UseColumnTextForButtonValue = true;
            this.Detalle.Width = 70;
            // 
            // FrmDetalleDeudaProveedeor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 771);
            this.Controls.Add(this.ckSoloDocumentosConSaldo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvListadoDocumentos);
            this.Name = "FrmDetalleDeudaProveedeor";
            this.Text = "Detalle Deuda Proveedor *DD1";
            this.Load += new System.EventHandler(this.FrmDetalleDeudaProveedeor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0203CTACTEPROVBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListadoDocumentos;
        private System.Windows.Forms.BindingSource t0203CTACTEPROVBindingSource;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGLAp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVendorType;
        private System.Windows.Forms.ComboBox cmbIdProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoTax;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
        private System.Windows.Forms.Button btnVerMaestro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBusquedaAvanzada;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.MaskedTextBox txtNumeroTax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTaxValido;
        private System.Windows.Forms.TextBox txtCodigoTax;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSaldoTotal;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtSaldoL1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtSaldoL2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.BindingSource proveedoresBs;
        private System.Windows.Forms.CheckBox ckSoloDocumentosConSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCTACTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMDOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONEDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEORIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sALDOFACTURADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zTERMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Detalle;
    }
}