namespace MASngFE.Transactional.MM
{
    partial class FrmOrdenCompraMain
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
            this.label12 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelefonoContacto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreContacto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaOC = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstadoOC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMonedaOC = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAgregarMaterial = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEmitirOC = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumeroOC = new System.Windows.Forms.TextBox();
            this.dgvItemsOC = new System.Windows.Forms.DataGridView();
            this.iDITEMCOMPRADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mATERIALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rEQUISICIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cANTIDADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cANTIDADRECIBIDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRECIOUNITARIOPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRECIOUNITARIODDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarioIOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OCItemBS = new System.Windows.Forms.BindingSource(this.components);
            this.txtTC = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnImprimirOC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OCItemBS)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 13);
            this.label12.TabIndex = 114;
            this.label12.Text = "PROVEEDOR [RAZON SOCIAL]";
            // 
            // txtProveedor
            // 
            this.txtProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProveedor.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtProveedor.Location = new System.Drawing.Point(153, 7);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(248, 21);
            this.txtProveedor.TabIndex = 113;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "DIRECCION";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.Control;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtDireccion.Location = new System.Drawing.Point(153, 29);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(378, 21);
            this.txtDireccion.TabIndex = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 118;
            this.label2.Text = "TELEFONO DE CONTACTO";
            // 
            // txtTelefonoContacto
            // 
            this.txtTelefonoContacto.BackColor = System.Drawing.SystemColors.Control;
            this.txtTelefonoContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefonoContacto.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtTelefonoContacto.Location = new System.Drawing.Point(153, 51);
            this.txtTelefonoContacto.Name = "txtTelefonoContacto";
            this.txtTelefonoContacto.ReadOnly = true;
            this.txtTelefonoContacto.Size = new System.Drawing.Size(133, 21);
            this.txtTelefonoContacto.TabIndex = 117;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 120;
            this.label3.Text = "NOMBRE DE CONTACTO";
            // 
            // txtNombreContacto
            // 
            this.txtNombreContacto.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombreContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreContacto.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtNombreContacto.Location = new System.Drawing.Point(153, 73);
            this.txtNombreContacto.Name = "txtNombreContacto";
            this.txtNombreContacto.ReadOnly = true;
            this.txtNombreContacto.Size = new System.Drawing.Size(133, 21);
            this.txtNombreContacto.TabIndex = 119;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 121;
            this.label4.Text = "FECHA ORDEN DE COMPRA";
            // 
            // dtpFechaOC
            // 
            this.dtpFechaOC.CalendarFont = new System.Drawing.Font("Calibri", 8.25F);
            this.dtpFechaOC.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.dtpFechaOC.Location = new System.Drawing.Point(153, 149);
            this.dtpFechaOC.Name = "dtpFechaOC";
            this.dtpFechaOC.Size = new System.Drawing.Size(212, 21);
            this.dtpFechaOC.TabIndex = 122;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(551, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 124;
            this.label5.Text = "ESTADO OC";
            // 
            // txtEstadoOC
            // 
            this.txtEstadoOC.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtEstadoOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstadoOC.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtEstadoOC.Location = new System.Drawing.Point(613, 7);
            this.txtEstadoOC.Name = "txtEstadoOC";
            this.txtEstadoOC.ReadOnly = true;
            this.txtEstadoOC.Size = new System.Drawing.Size(85, 21);
            this.txtEstadoOC.TabIndex = 123;
            this.txtEstadoOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(373, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 126;
            this.label6.Text = "MONEDA";
            // 
            // cmbMonedaOC
            // 
            this.cmbMonedaOC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMonedaOC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonedaOC.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.cmbMonedaOC.FormattingEnabled = true;
            this.cmbMonedaOC.Items.AddRange(new object[] {
            "ARS",
            "USD"});
            this.cmbMonedaOC.Location = new System.Drawing.Point(429, 150);
            this.cmbMonedaOC.Name = "cmbMonedaOC";
            this.cmbMonedaOC.Size = new System.Drawing.Size(65, 21);
            this.cmbMonedaOC.TabIndex = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(526, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 128;
            this.label7.Text = "TIPO CAMBIO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(526, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 130;
            this.label8.Text = "IMPORTE TOTAL";
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.BackColor = System.Drawing.Color.Silver;
            this.txtImporteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImporteTotal.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtImporteTotal.Location = new System.Drawing.Point(608, 98);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.ReadOnly = true;
            this.txtImporteTotal.Size = new System.Drawing.Size(85, 21);
            this.txtImporteTotal.TabIndex = 129;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(12, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 132;
            this.label9.Text = "EMAIL DE CONTACTO";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtEmail.Location = new System.Drawing.Point(153, 96);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(248, 21);
            this.txtEmail.TabIndex = 131;
            // 
            // btnAgregarMaterial
            // 
            this.btnAgregarMaterial.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnAgregarMaterial.Location = new System.Drawing.Point(508, 3);
            this.btnAgregarMaterial.Name = "btnAgregarMaterial";
            this.btnAgregarMaterial.Size = new System.Drawing.Size(76, 37);
            this.btnAgregarMaterial.TabIndex = 136;
            this.btnAgregarMaterial.Text = "AGREGAR MATERIAL";
            this.btnAgregarMaterial.UseVisualStyleBackColor = true;
            this.btnAgregarMaterial.Click += new System.EventHandler(this.btnAgregarMaterial_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnSalir.Location = new System.Drawing.Point(3, 154);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(77, 34);
            this.btnSalir.TabIndex = 137;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEmitirOC
            // 
            this.btnEmitirOC.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnEmitirOC.Location = new System.Drawing.Point(3, 16);
            this.btnEmitirOC.Name = "btnEmitirOC";
            this.btnEmitirOC.Size = new System.Drawing.Size(77, 34);
            this.btnEmitirOC.TabIndex = 138;
            this.btnEmitirOC.Text = "EMITIR OC";
            this.btnEmitirOC.UseVisualStyleBackColor = true;
            this.btnEmitirOC.Click += new System.EventHandler(this.btnEmitirOC_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnGuardar.Location = new System.Drawing.Point(3, 51);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(77, 34);
            this.btnGuardar.TabIndex = 139;
            this.btnGuardar.Text = "GUARDAR (SIN EMITIR)";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(407, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 141;
            this.label11.Text = "NUMERO OC";
            // 
            // txtNumeroOC
            // 
            this.txtNumeroOC.BackColor = System.Drawing.SystemColors.Control;
            this.txtNumeroOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroOC.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtNumeroOC.Location = new System.Drawing.Point(477, 7);
            this.txtNumeroOC.Name = "txtNumeroOC";
            this.txtNumeroOC.ReadOnly = true;
            this.txtNumeroOC.Size = new System.Drawing.Size(54, 21);
            this.txtNumeroOC.TabIndex = 140;
            this.txtNumeroOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvItemsOC
            // 
            this.dgvItemsOC.AllowUserToAddRows = false;
            this.dgvItemsOC.AllowUserToDeleteRows = false;
            this.dgvItemsOC.AllowUserToResizeColumns = false;
            this.dgvItemsOC.AllowUserToResizeRows = false;
            this.dgvItemsOC.AutoGenerateColumns = false;
            this.dgvItemsOC.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemsOC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemsOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsOC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDITEMCOMPRADataGridViewTextBoxColumn,
            this.mATERIALDataGridViewTextBoxColumn,
            this.rEQUISICIONDataGridViewTextBoxColumn,
            this.cANTIDADDataGridViewTextBoxColumn,
            this.cANTIDADRECIBIDADataGridViewTextBoxColumn,
            this.pRECIOUNITARIOPDataGridViewTextBoxColumn,
            this.pRECIOUNITARIODDataGridViewTextBoxColumn,
            this.statusItemDataGridViewTextBoxColumn,
            this.comentarioIOCDataGridViewTextBoxColumn,
            this.btnEdit});
            this.dgvItemsOC.DataSource = this.OCItemBS;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemsOC.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItemsOC.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvItemsOC.Location = new System.Drawing.Point(4, 195);
            this.dgvItemsOC.MultiSelect = false;
            this.dgvItemsOC.Name = "dgvItemsOC";
            this.dgvItemsOC.ReadOnly = true;
            this.dgvItemsOC.Size = new System.Drawing.Size(710, 150);
            this.dgvItemsOC.TabIndex = 142;
            this.dgvItemsOC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsOC_CellContentClick);
            // 
            // iDITEMCOMPRADataGridViewTextBoxColumn
            // 
            this.iDITEMCOMPRADataGridViewTextBoxColumn.DataPropertyName = "IDITEMCOMPRA";
            this.iDITEMCOMPRADataGridViewTextBoxColumn.HeaderText = "ITEM";
            this.iDITEMCOMPRADataGridViewTextBoxColumn.Name = "iDITEMCOMPRADataGridViewTextBoxColumn";
            this.iDITEMCOMPRADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDITEMCOMPRADataGridViewTextBoxColumn.Width = 50;
            // 
            // mATERIALDataGridViewTextBoxColumn
            // 
            this.mATERIALDataGridViewTextBoxColumn.DataPropertyName = "MATERIAL";
            this.mATERIALDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.mATERIALDataGridViewTextBoxColumn.Name = "mATERIALDataGridViewTextBoxColumn";
            this.mATERIALDataGridViewTextBoxColumn.ReadOnly = true;
            this.mATERIALDataGridViewTextBoxColumn.Width = 120;
            // 
            // rEQUISICIONDataGridViewTextBoxColumn
            // 
            this.rEQUISICIONDataGridViewTextBoxColumn.DataPropertyName = "REQUISICION";
            this.rEQUISICIONDataGridViewTextBoxColumn.HeaderText = "RC#";
            this.rEQUISICIONDataGridViewTextBoxColumn.Name = "rEQUISICIONDataGridViewTextBoxColumn";
            this.rEQUISICIONDataGridViewTextBoxColumn.ReadOnly = true;
            this.rEQUISICIONDataGridViewTextBoxColumn.Width = 45;
            // 
            // cANTIDADDataGridViewTextBoxColumn
            // 
            this.cANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD";
            this.cANTIDADDataGridViewTextBoxColumn.HeaderText = "KG PEDIDO";
            this.cANTIDADDataGridViewTextBoxColumn.Name = "cANTIDADDataGridViewTextBoxColumn";
            this.cANTIDADDataGridViewTextBoxColumn.ReadOnly = true;
            this.cANTIDADDataGridViewTextBoxColumn.Width = 55;
            // 
            // cANTIDADRECIBIDADataGridViewTextBoxColumn
            // 
            this.cANTIDADRECIBIDADataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD_RECIBIDA";
            this.cANTIDADRECIBIDADataGridViewTextBoxColumn.HeaderText = "KG RECIBIDO";
            this.cANTIDADRECIBIDADataGridViewTextBoxColumn.Name = "cANTIDADRECIBIDADataGridViewTextBoxColumn";
            this.cANTIDADRECIBIDADataGridViewTextBoxColumn.ReadOnly = true;
            this.cANTIDADRECIBIDADataGridViewTextBoxColumn.Width = 55;
            // 
            // pRECIOUNITARIOPDataGridViewTextBoxColumn
            // 
            this.pRECIOUNITARIOPDataGridViewTextBoxColumn.DataPropertyName = "PRECIO_UNITARIO_P";
            this.pRECIOUNITARIOPDataGridViewTextBoxColumn.HeaderText = "PRECIO [ARS]";
            this.pRECIOUNITARIOPDataGridViewTextBoxColumn.Name = "pRECIOUNITARIOPDataGridViewTextBoxColumn";
            this.pRECIOUNITARIOPDataGridViewTextBoxColumn.ReadOnly = true;
            this.pRECIOUNITARIOPDataGridViewTextBoxColumn.Width = 60;
            // 
            // pRECIOUNITARIODDataGridViewTextBoxColumn
            // 
            this.pRECIOUNITARIODDataGridViewTextBoxColumn.DataPropertyName = "PRECIO_UNITARIO_D";
            this.pRECIOUNITARIODDataGridViewTextBoxColumn.HeaderText = "PRECIO [USD]";
            this.pRECIOUNITARIODDataGridViewTextBoxColumn.Name = "pRECIOUNITARIODDataGridViewTextBoxColumn";
            this.pRECIOUNITARIODDataGridViewTextBoxColumn.ReadOnly = true;
            this.pRECIOUNITARIODDataGridViewTextBoxColumn.Width = 60;
            // 
            // statusItemDataGridViewTextBoxColumn
            // 
            this.statusItemDataGridViewTextBoxColumn.DataPropertyName = "StatusItem";
            this.statusItemDataGridViewTextBoxColumn.HeaderText = "Status Item";
            this.statusItemDataGridViewTextBoxColumn.Name = "statusItemDataGridViewTextBoxColumn";
            this.statusItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusItemDataGridViewTextBoxColumn.Width = 80;
            // 
            // comentarioIOCDataGridViewTextBoxColumn
            // 
            this.comentarioIOCDataGridViewTextBoxColumn.DataPropertyName = "ComentarioI_OC";
            this.comentarioIOCDataGridViewTextBoxColumn.HeaderText = "Comentario";
            this.comentarioIOCDataGridViewTextBoxColumn.Name = "comentarioIOCDataGridViewTextBoxColumn";
            this.comentarioIOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // btnEdit
            // 
            this.btnEdit.HeaderText = "EDIT";
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ReadOnly = true;
            this.btnEdit.Width = 40;
            // 
            // OCItemBS
            // 
            this.OCItemBS.DataSource = typeof(TecserEF.Entity.T0061_OCOMPRA_I);
            this.OCItemBS.CurrentChanged += new System.EventHandler(this.OCItemBS_CurrentChanged);
            // 
            // txtTC
            // 
            this.txtTC.BackColor = System.Drawing.Color.Silver;
            this.txtTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTC.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.txtTC.Location = new System.Drawing.Point(608, 75);
            this.txtTC.Name = "txtTC";
            this.txtTC.ReadOnly = true;
            this.txtTC.Size = new System.Drawing.Size(57, 21);
            this.txtTC.TabIndex = 143;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTC);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtImporteTotal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 132);
            this.panel1.TabIndex = 144;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnAgregarMaterial);
            this.panel2.Location = new System.Drawing.Point(4, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 48);
            this.panel2.TabIndex = 145;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnCancelar.Location = new System.Drawing.Point(3, 85);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 34);
            this.btnCancelar.TabIndex = 146;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnImprimirOC);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.btnEmitirOC);
            this.panel3.Controls.Add(this.btnSalir);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Location = new System.Drawing.Point(720, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(87, 210);
            this.panel3.TabIndex = 147;
            // 
            // btnImprimirOC
            // 
            this.btnImprimirOC.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnImprimirOC.Location = new System.Drawing.Point(3, 119);
            this.btnImprimirOC.Name = "btnImprimirOC";
            this.btnImprimirOC.Size = new System.Drawing.Size(77, 34);
            this.btnImprimirOC.TabIndex = 147;
            this.btnImprimirOC.Text = "IMPRIMIR";
            this.btnImprimirOC.UseVisualStyleBackColor = true;
            this.btnImprimirOC.Click += new System.EventHandler(this.btnImprimirOC_Click);
            // 
            // FrmOrdenCompraMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 358);
            this.Controls.Add(this.dgvItemsOC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNumeroOC);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbMonedaOC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEstadoOC);
            this.Controls.Add(this.dtpFechaOC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreContacto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTelefonoContacto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "FrmOrdenCompraMain";
            this.Text = "ORDEN DE COMPRA [MAIN]";
            this.Load += new System.EventHandler(this.FrmOrdenCompraMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OCItemBS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelefonoContacto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreContacto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaOC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstadoOC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMonedaOC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImporteTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAgregarMaterial;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEmitirOC;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumeroOC;
        private System.Windows.Forms.DataGridView dgvItemsOC;
        private System.Windows.Forms.BindingSource OCItemBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDITEMCOMPRADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATERIALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rEQUISICIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cANTIDADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cANTIDADRECIBIDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRECIOUNITARIOPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRECIOUNITARIODDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarioIOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnEdit;
        private System.Windows.Forms.TextBox txtTC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnImprimirOC;
    }
}