namespace MASngFE.Transactional.FI.GESCO
{
    partial class FrmGestionCreditosClientesSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNumeroShiptos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbId6 = new System.Windows.Forms.ComboBox();
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
            this.t0006MCLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.T0006Bs = new System.Windows.Forms.BindingSource(this.components);
            this.dgvListaClientes = new System.Windows.Forms.DataGridView();
            this.iDCLIENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clirsocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clifantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUITDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionfacturacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direfactuLocalidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVODataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnButton1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckSoloActivos = new System.Windows.Forms.CheckBox();
            this.txtMatchNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClientes)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtNumeroShiptos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbId6);
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
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 110);
            this.panel1.TabIndex = 93;
            this.panel1.UseWaitCursor = true;
            // 
            // txtNumeroShiptos
            // 
            this.txtNumeroShiptos.Location = new System.Drawing.Point(121, 84);
            this.txtNumeroShiptos.Name = "txtNumeroShiptos";
            this.txtNumeroShiptos.Size = new System.Drawing.Size(34, 20);
            this.txtNumeroShiptos.TabIndex = 21;
            this.txtNumeroShiptos.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "CANTIDAD SHIPTOS";
            this.label4.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Navy;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(9, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 3);
            this.label7.TabIndex = 19;
            this.label7.UseWaitCursor = true;
            // 
            // cmbId6
            // 
            this.cmbId6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbId6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbId6.DataSource = this.T0006Bs;
            this.cmbId6.DisplayMember = "IDCLIENTE";
            this.cmbId6.FormattingEnabled = true;
            this.cmbId6.Location = new System.Drawing.Point(406, 8);
            this.cmbId6.Name = "cmbId6";
            this.cmbId6.Size = new System.Drawing.Size(72, 21);
            this.cmbId6.TabIndex = 15;
            this.cmbId6.UseWaitCursor = true;
            this.cmbId6.ValueMember = "IDCLIENTE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "RAZON SOCIAL";
            this.label1.UseWaitCursor = true;
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
            this.cmbTipoTax.UseWaitCursor = true;
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DataSource = this.T0006Bs;
            this.cmbRazonSocial.DisplayMember = "cli_rsocial";
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.Location = new System.Drawing.Point(121, 8);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(281, 21);
            this.cmbRazonSocial.TabIndex = 3;
            this.cmbRazonSocial.UseWaitCursor = true;
            this.cmbRazonSocial.ValueMember = "IDCLIENTE";
            // 
            // btnVerMaestro
            // 
            this.btnVerMaestro.Location = new System.Drawing.Point(494, 41);
            this.btnVerMaestro.Name = "btnVerMaestro";
            this.btnVerMaestro.Size = new System.Drawing.Size(100, 35);
            this.btnVerMaestro.TabIndex = 13;
            this.btnVerMaestro.Text = "Maestro";
            this.btnVerMaestro.UseVisualStyleBackColor = true;
            this.btnVerMaestro.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "NOMBRE FANTASIA";
            this.label2.UseWaitCursor = true;
            // 
            // btnBusquedaAvanzada
            // 
            this.btnBusquedaAvanzada.Location = new System.Drawing.Point(494, 5);
            this.btnBusquedaAvanzada.Name = "btnBusquedaAvanzada";
            this.btnBusquedaAvanzada.Size = new System.Drawing.Size(100, 35);
            this.btnBusquedaAvanzada.TabIndex = 12;
            this.btnBusquedaAvanzada.Text = "Busqueda Avanzada";
            this.btnBusquedaAvanzada.UseVisualStyleBackColor = true;
            this.btnBusquedaAvanzada.UseWaitCursor = true;
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.DataSource = this.T0006Bs;
            this.cmbFantasia.DisplayMember = "cli_fantasia";
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(121, 31);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(281, 21);
            this.cmbFantasia.TabIndex = 5;
            this.cmbFantasia.UseWaitCursor = true;
            this.cmbFantasia.ValueMember = "IDCLIENTE";
            // 
            // txtNumeroTax
            // 
            this.txtNumeroTax.BeepOnError = true;
            this.txtNumeroTax.Location = new System.Drawing.Point(234, 54);
            this.txtNumeroTax.Mask = "00-00000000-0";
            this.txtNumeroTax.Name = "txtNumeroTax";
            this.txtNumeroTax.ReadOnly = true;
            this.txtNumeroTax.Size = new System.Drawing.Size(88, 20);
            this.txtNumeroTax.TabIndex = 11;
            this.txtNumeroTax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNumeroTax.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "TAX NUMBER";
            this.label3.UseWaitCursor = true;
            // 
            // txtTaxValido
            // 
            this.txtTaxValido.Location = new System.Drawing.Point(324, 54);
            this.txtTaxValido.Name = "txtTaxValido";
            this.txtTaxValido.Size = new System.Drawing.Size(78, 20);
            this.txtTaxValido.TabIndex = 9;
            this.txtTaxValido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTaxValido.UseWaitCursor = true;
            // 
            // txtCodigoTax
            // 
            this.txtCodigoTax.Location = new System.Drawing.Point(197, 54);
            this.txtCodigoTax.Name = "txtCodigoTax";
            this.txtCodigoTax.Size = new System.Drawing.Size(34, 20);
            this.txtCodigoTax.TabIndex = 8;
            this.txtCodigoTax.UseWaitCursor = true;
            // 
            // t0006MCLIENTESBindingSource
            // 
            this.t0006MCLIENTESBindingSource.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // T0006Bs
            // 
            this.T0006Bs.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // dgvListaClientes
            // 
            this.dgvListaClientes.AllowUserToAddRows = false;
            this.dgvListaClientes.AllowUserToDeleteRows = false;
            this.dgvListaClientes.AutoGenerateColumns = false;
            this.dgvListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCLIENTEDataGridViewTextBoxColumn,
            this.clirsocialDataGridViewTextBoxColumn,
            this.clifantasiaDataGridViewTextBoxColumn,
            this.cUITDataGridViewTextBoxColumn,
            this.direccionfacturacionDataGridViewTextBoxColumn,
            this.direfactuLocalidadDataGridViewTextBoxColumn,
            this.telefonoVentaDataGridViewTextBoxColumn,
            this.aCTIVODataGridViewCheckBoxColumn,
            this.btnButton1});
            this.dgvListaClientes.DataSource = this.t0006MCLIENTESBindingSource;
            this.dgvListaClientes.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvListaClientes.Location = new System.Drawing.Point(2, 118);
            this.dgvListaClientes.Name = "dgvListaClientes";
            this.dgvListaClientes.ReadOnly = true;
            this.dgvListaClientes.RowHeadersWidth = 20;
            this.dgvListaClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvListaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaClientes.Size = new System.Drawing.Size(997, 495);
            this.dgvListaClientes.TabIndex = 94;
            this.dgvListaClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaClientes_CellContentClick);
            // 
            // iDCLIENTEDataGridViewTextBoxColumn
            // 
            this.iDCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "IDCLIENTE";
            this.iDCLIENTEDataGridViewTextBoxColumn.HeaderText = "IDC";
            this.iDCLIENTEDataGridViewTextBoxColumn.Name = "iDCLIENTEDataGridViewTextBoxColumn";
            this.iDCLIENTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCLIENTEDataGridViewTextBoxColumn.Width = 35;
            // 
            // clirsocialDataGridViewTextBoxColumn
            // 
            this.clirsocialDataGridViewTextBoxColumn.DataPropertyName = "cli_rsocial";
            this.clirsocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clirsocialDataGridViewTextBoxColumn.Name = "clirsocialDataGridViewTextBoxColumn";
            this.clirsocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.clirsocialDataGridViewTextBoxColumn.Width = 180;
            // 
            // clifantasiaDataGridViewTextBoxColumn
            // 
            this.clifantasiaDataGridViewTextBoxColumn.DataPropertyName = "cli_fantasia";
            this.clifantasiaDataGridViewTextBoxColumn.HeaderText = "Nombre Fantasia";
            this.clifantasiaDataGridViewTextBoxColumn.Name = "clifantasiaDataGridViewTextBoxColumn";
            this.clifantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clifantasiaDataGridViewTextBoxColumn.Width = 200;
            // 
            // cUITDataGridViewTextBoxColumn
            // 
            this.cUITDataGridViewTextBoxColumn.DataPropertyName = "CUIT";
            this.cUITDataGridViewTextBoxColumn.HeaderText = "CUIT";
            this.cUITDataGridViewTextBoxColumn.Name = "cUITDataGridViewTextBoxColumn";
            this.cUITDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUITDataGridViewTextBoxColumn.Width = 70;
            // 
            // direccionfacturacionDataGridViewTextBoxColumn
            // 
            this.direccionfacturacionDataGridViewTextBoxColumn.DataPropertyName = "Direccion_facturacion";
            this.direccionfacturacionDataGridViewTextBoxColumn.HeaderText = "Direccion Fiscal";
            this.direccionfacturacionDataGridViewTextBoxColumn.Name = "direccionfacturacionDataGridViewTextBoxColumn";
            this.direccionfacturacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.direccionfacturacionDataGridViewTextBoxColumn.Width = 180;
            // 
            // direfactuLocalidadDataGridViewTextBoxColumn
            // 
            this.direfactuLocalidadDataGridViewTextBoxColumn.DataPropertyName = "Direfactu_Localidad";
            this.direfactuLocalidadDataGridViewTextBoxColumn.HeaderText = "Localidad";
            this.direfactuLocalidadDataGridViewTextBoxColumn.Name = "direfactuLocalidadDataGridViewTextBoxColumn";
            this.direfactuLocalidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoVentaDataGridViewTextBoxColumn
            // 
            this.telefonoVentaDataGridViewTextBoxColumn.DataPropertyName = "Telefono_Venta";
            this.telefonoVentaDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoVentaDataGridViewTextBoxColumn.Name = "telefonoVentaDataGridViewTextBoxColumn";
            this.telefonoVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aCTIVODataGridViewCheckBoxColumn
            // 
            this.aCTIVODataGridViewCheckBoxColumn.DataPropertyName = "ACTIVO";
            this.aCTIVODataGridViewCheckBoxColumn.HeaderText = "ACTIVO";
            this.aCTIVODataGridViewCheckBoxColumn.Name = "aCTIVODataGridViewCheckBoxColumn";
            this.aCTIVODataGridViewCheckBoxColumn.ReadOnly = true;
            this.aCTIVODataGridViewCheckBoxColumn.Width = 50;
            // 
            // btnButton1
            // 
            this.btnButton1.HeaderText = "ACCION";
            this.btnButton1.Name = "btnButton1";
            this.btnButton1.ReadOnly = true;
            this.btnButton1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnButton1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnButton1.Text = "ACCION";
            this.btnButton1.ToolTipText = "Ejecutar la Accion seleccionada con este Cliente";
            this.btnButton1.UseColumnTextForButtonValue = true;
            this.btnButton1.Width = 50;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ckSoloActivos);
            this.panel2.Controls.Add(this.txtMatchNumber);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(607, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 110);
            this.panel2.TabIndex = 96;
            // 
            // ckSoloActivos
            // 
            this.ckSoloActivos.AutoSize = true;
            this.ckSoloActivos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloActivos.Location = new System.Drawing.Point(14, 10);
            this.ckSoloActivos.Name = "ckSoloActivos";
            this.ckSoloActivos.Size = new System.Drawing.Size(150, 18);
            this.ckSoloActivos.TabIndex = 94;
            this.ckSoloActivos.Text = "SOLO CLIENTES ACTIVOS";
            this.ckSoloActivos.UseVisualStyleBackColor = true;
            // 
            // txtMatchNumber
            // 
            this.txtMatchNumber.Location = new System.Drawing.Point(84, 30);
            this.txtMatchNumber.Name = "txtMatchNumber";
            this.txtMatchNumber.Size = new System.Drawing.Size(34, 20);
            this.txtMatchNumber.TabIndex = 23;
            this.txtMatchNumber.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "MATCH >= #";
            this.label5.UseWaitCursor = true;
            // 
            // FrmGestionCreditosClientesSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 690);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvListaClientes);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGestionCreditosClientesSearch";
            this.Text = "CCL - GESTION DE CONTROL LIMITES Y RIESGOS DE CLIENTES";
            this.Load += new System.EventHandler(this.FrmGestionCreditosClientesSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0006Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaClientes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNumeroShiptos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbId6;
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
        private System.Windows.Forms.BindingSource t0006MCLIENTESBindingSource;
        private System.Windows.Forms.BindingSource T0006Bs;
        private System.Windows.Forms.DataGridView dgvListaClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCLIENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clirsocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clifantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUITDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionfacturacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direfactuLocalidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckSoloActivos;
        private System.Windows.Forms.TextBox txtMatchNumber;
        private System.Windows.Forms.Label label5;
    }
}