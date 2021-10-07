namespace MASngFE.Transactional.FI
{
    partial class FrmTest1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatosCliente = new System.Windows.Forms.DataGridView();
            this.cli_fantasia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEFONO_COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDataCliente = new System.Windows.Forms.TabPage();
            this.tabDataCuentaCorriente = new System.Windows.Forms.TabPage();
            this.textRazonSocial1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFantasia = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tabNotas = new System.Windows.Forms.TabPage();
            this.btnNuevaNota = new System.Windows.Forms.Button();
            this.btnNuevaAccion = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccionFacturacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefonoVentas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelCobranza = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.T6BS = new System.Windows.Forms.BindingSource(this.components);
            this.iDCLIENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clirsocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUITDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionfacturacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direfactuLocalidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direfactuProvinciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cONTACTOVTADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMAILFACTUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCliente)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabDataCliente.SuspendLayout();
            this.tabNotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.T6BS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(119, 6);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(181, 20);
            this.txtRazonSocial.TabIndex = 0;
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar por Fantasia";
            // 
            // dgvDatosCliente
            // 
            this.dgvDatosCliente.AllowUserToAddRows = false;
            this.dgvDatosCliente.AllowUserToDeleteRows = false;
            this.dgvDatosCliente.AllowUserToResizeColumns = false;
            this.dgvDatosCliente.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvDatosCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDatosCliente.AutoGenerateColumns = false;
            this.dgvDatosCliente.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatosCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDatosCliente.ColumnHeadersHeight = 20;
            this.dgvDatosCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDatosCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCLIENTEDataGridViewTextBoxColumn,
            this.clirsocialDataGridViewTextBoxColumn,
            this.cli_fantasia,
            this.cUITDataGridViewTextBoxColumn,
            this.direccionfacturacionDataGridViewTextBoxColumn,
            this.direfactuLocalidadDataGridViewTextBoxColumn,
            this.direfactuProvinciaDataGridViewTextBoxColumn,
            this.telefonoVentaDataGridViewTextBoxColumn,
            this.cONTACTOVTADataGridViewTextBoxColumn,
            this.eMAILFACTUDataGridViewTextBoxColumn,
            this.TELEFONO_COB});
            this.dgvDatosCliente.DataSource = this.T6BS;
            this.dgvDatosCliente.Location = new System.Drawing.Point(15, 32);
            this.dgvDatosCliente.Name = "dgvDatosCliente";
            this.dgvDatosCliente.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatosCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Green;
            this.dgvDatosCliente.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDatosCliente.Size = new System.Drawing.Size(1044, 162);
            this.dgvDatosCliente.TabIndex = 2;
            this.dgvDatosCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosCliente_CellContentClick);
            // 
            // cli_fantasia
            // 
            this.cli_fantasia.DataPropertyName = "cli_fantasia";
            this.cli_fantasia.HeaderText = "Fantasia";
            this.cli_fantasia.Name = "cli_fantasia";
            this.cli_fantasia.ReadOnly = true;
            // 
            // TELEFONO_COB
            // 
            this.TELEFONO_COB.DataPropertyName = "TELEFONO_COB";
            this.TELEFONO_COB.HeaderText = "Tel. Cobranza";
            this.TELEFONO_COB.Name = "TELEFONO_COB";
            this.TELEFONO_COB.ReadOnly = true;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDataCliente);
            this.tabMain.Controls.Add(this.tabDataCuentaCorriente);
            this.tabMain.Controls.Add(this.tabNotas);
            this.tabMain.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(15, 200);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(748, 335);
            this.tabMain.TabIndex = 3;
            // 
            // tabDataCliente
            // 
            this.tabDataCliente.Controls.Add(this.button1);
            this.tabDataCliente.Controls.Add(this.label4);
            this.tabDataCliente.Controls.Add(this.txtDireccionFacturacion);
            this.tabDataCliente.Controls.Add(this.label6);
            this.tabDataCliente.Controls.Add(this.txtTelefonoVentas);
            this.tabDataCliente.Controls.Add(this.label7);
            this.tabDataCliente.Controls.Add(this.txtTelCobranza);
            this.tabDataCliente.Controls.Add(this.label5);
            this.tabDataCliente.Controls.Add(this.txtCUIT);
            this.tabDataCliente.Controls.Add(this.label3);
            this.tabDataCliente.Controls.Add(this.txtFantasia);
            this.tabDataCliente.Controls.Add(this.label2);
            this.tabDataCliente.Controls.Add(this.textRazonSocial1);
            this.tabDataCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tabDataCliente.Location = new System.Drawing.Point(4, 22);
            this.tabDataCliente.Name = "tabDataCliente";
            this.tabDataCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataCliente.Size = new System.Drawing.Size(740, 309);
            this.tabDataCliente.TabIndex = 0;
            this.tabDataCliente.Text = "Datos Cliente";
            this.tabDataCliente.UseVisualStyleBackColor = true;
            // 
            // tabDataCuentaCorriente
            // 
            this.tabDataCuentaCorriente.Location = new System.Drawing.Point(4, 22);
            this.tabDataCuentaCorriente.Name = "tabDataCuentaCorriente";
            this.tabDataCuentaCorriente.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataCuentaCorriente.Size = new System.Drawing.Size(740, 309);
            this.tabDataCuentaCorriente.TabIndex = 1;
            this.tabDataCuentaCorriente.Text = "Cuenta Corriente";
            this.tabDataCuentaCorriente.UseVisualStyleBackColor = true;
            // 
            // textRazonSocial1
            // 
            this.textRazonSocial1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T6BS, "cli_rsocial", true));
            this.textRazonSocial1.Location = new System.Drawing.Point(100, 16);
            this.textRazonSocial1.Name = "textRazonSocial1";
            this.textRazonSocial1.Size = new System.Drawing.Size(244, 21);
            this.textRazonSocial1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Razon Social";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fantasia";
            // 
            // txtFantasia
            // 
            this.txtFantasia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T6BS, "cli_fantasia", true));
            this.txtFantasia.Location = new System.Drawing.Point(100, 39);
            this.txtFantasia.Name = "txtFantasia";
            this.txtFantasia.Size = new System.Drawing.Size(244, 21);
            this.txtFantasia.TabIndex = 2;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1119, 74);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 36);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tabNotas
            // 
            this.tabNotas.Controls.Add(this.btnNuevaNota);
            this.tabNotas.Location = new System.Drawing.Point(4, 22);
            this.tabNotas.Name = "tabNotas";
            this.tabNotas.Size = new System.Drawing.Size(740, 309);
            this.tabNotas.TabIndex = 2;
            this.tabNotas.Text = "Notas Cliente";
            this.tabNotas.UseVisualStyleBackColor = true;
            // 
            // btnNuevaNota
            // 
            this.btnNuevaNota.Location = new System.Drawing.Point(652, 12);
            this.btnNuevaNota.Name = "btnNuevaNota";
            this.btnNuevaNota.Size = new System.Drawing.Size(75, 23);
            this.btnNuevaNota.TabIndex = 5;
            this.btnNuevaNota.Text = "Nueva Nota";
            this.btnNuevaNota.UseVisualStyleBackColor = true;
            // 
            // btnNuevaAccion
            // 
            this.btnNuevaAccion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaAccion.Location = new System.Drawing.Point(1119, 32);
            this.btnNuevaAccion.Name = "btnNuevaAccion";
            this.btnNuevaAccion.Size = new System.Drawing.Size(93, 36);
            this.btnNuevaAccion.TabIndex = 5;
            this.btnNuevaAccion.Text = "Nuevo\r\nAccion";
            this.btnNuevaAccion.UseVisualStyleBackColor = true;
            this.btnNuevaAccion.Click += new System.EventHandler(this.btnNuevaAccion_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "CUIT";
            // 
            // txtCUIT
            // 
            this.txtCUIT.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T6BS, "CUIT", true));
            this.txtCUIT.Location = new System.Drawing.Point(100, 62);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(244, 21);
            this.txtCUIT.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Direccion Facturacion";
            // 
            // txtDireccionFacturacion
            // 
            this.txtDireccionFacturacion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T6BS, "Direccion_facturacion", true));
            this.txtDireccionFacturacion.Location = new System.Drawing.Point(132, 131);
            this.txtDireccionFacturacion.Name = "txtDireccionFacturacion";
            this.txtDireccionFacturacion.Size = new System.Drawing.Size(212, 21);
            this.txtDireccionFacturacion.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tel Ventas";
            // 
            // txtTelefonoVentas
            // 
            this.txtTelefonoVentas.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T6BS, "Telefono_Venta", true));
            this.txtTelefonoVentas.Location = new System.Drawing.Point(100, 108);
            this.txtTelefonoVentas.Name = "txtTelefonoVentas";
            this.txtTelefonoVentas.Size = new System.Drawing.Size(244, 21);
            this.txtTelefonoVentas.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Tel. Cobranza";
            // 
            // txtTelCobranza
            // 
            this.txtTelCobranza.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.T6BS, "TELEFONO_COB", true));
            this.txtTelCobranza.Location = new System.Drawing.Point(100, 85);
            this.txtTelCobranza.Name = "txtTelCobranza";
            this.txtTelCobranza.Size = new System.Drawing.Size(244, 21);
            this.txtTelCobranza.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(364, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Ver Maestro";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // T6BS
            // 
            this.T6BS.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // iDCLIENTEDataGridViewTextBoxColumn
            // 
            this.iDCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "IDCLIENTE";
            this.iDCLIENTEDataGridViewTextBoxColumn.HeaderText = "ID6";
            this.iDCLIENTEDataGridViewTextBoxColumn.Name = "iDCLIENTEDataGridViewTextBoxColumn";
            this.iDCLIENTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCLIENTEDataGridViewTextBoxColumn.Visible = false;
            // 
            // clirsocialDataGridViewTextBoxColumn
            // 
            this.clirsocialDataGridViewTextBoxColumn.DataPropertyName = "cli_rsocial";
            this.clirsocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.clirsocialDataGridViewTextBoxColumn.Name = "clirsocialDataGridViewTextBoxColumn";
            this.clirsocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cUITDataGridViewTextBoxColumn
            // 
            this.cUITDataGridViewTextBoxColumn.DataPropertyName = "CUIT";
            this.cUITDataGridViewTextBoxColumn.FillWeight = 60F;
            this.cUITDataGridViewTextBoxColumn.HeaderText = "CUIT";
            this.cUITDataGridViewTextBoxColumn.Name = "cUITDataGridViewTextBoxColumn";
            this.cUITDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUITDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // direccionfacturacionDataGridViewTextBoxColumn
            // 
            this.direccionfacturacionDataGridViewTextBoxColumn.DataPropertyName = "Direccion_facturacion";
            this.direccionfacturacionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            this.direccionfacturacionDataGridViewTextBoxColumn.Name = "direccionfacturacionDataGridViewTextBoxColumn";
            this.direccionfacturacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direfactuLocalidadDataGridViewTextBoxColumn
            // 
            this.direfactuLocalidadDataGridViewTextBoxColumn.DataPropertyName = "Direfactu_Localidad";
            this.direfactuLocalidadDataGridViewTextBoxColumn.HeaderText = "Localidad";
            this.direfactuLocalidadDataGridViewTextBoxColumn.Name = "direfactuLocalidadDataGridViewTextBoxColumn";
            this.direfactuLocalidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // direfactuProvinciaDataGridViewTextBoxColumn
            // 
            this.direfactuProvinciaDataGridViewTextBoxColumn.DataPropertyName = "Direfactu_Provincia";
            this.direfactuProvinciaDataGridViewTextBoxColumn.HeaderText = "Provincia";
            this.direfactuProvinciaDataGridViewTextBoxColumn.Name = "direfactuProvinciaDataGridViewTextBoxColumn";
            this.direfactuProvinciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefonoVentaDataGridViewTextBoxColumn
            // 
            this.telefonoVentaDataGridViewTextBoxColumn.DataPropertyName = "Telefono_Venta";
            this.telefonoVentaDataGridViewTextBoxColumn.HeaderText = "Tel. Venta";
            this.telefonoVentaDataGridViewTextBoxColumn.Name = "telefonoVentaDataGridViewTextBoxColumn";
            this.telefonoVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cONTACTOVTADataGridViewTextBoxColumn
            // 
            this.cONTACTOVTADataGridViewTextBoxColumn.DataPropertyName = "CONTACTO_VTA";
            this.cONTACTOVTADataGridViewTextBoxColumn.HeaderText = "Contacto Venta";
            this.cONTACTOVTADataGridViewTextBoxColumn.Name = "cONTACTOVTADataGridViewTextBoxColumn";
            this.cONTACTOVTADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eMAILFACTUDataGridViewTextBoxColumn
            // 
            this.eMAILFACTUDataGridViewTextBoxColumn.DataPropertyName = "EMAIL_FACTU";
            this.eMAILFACTUDataGridViewTextBoxColumn.HeaderText = "Email Facturacion";
            this.eMAILFACTUDataGridViewTextBoxColumn.Name = "eMAILFACTUDataGridViewTextBoxColumn";
            this.eMAILFACTUDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmTest1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 547);
            this.Controls.Add(this.btnNuevaAccion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.dgvDatosCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRazonSocial);
            this.Name = "FrmTest1";
            this.Text = "Modulo CRM - Principal by Customer";
            this.Load += new System.EventHandler(this.FrmTest1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCliente)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabDataCliente.ResumeLayout(false);
            this.tabDataCliente.PerformLayout();
            this.tabNotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.T6BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.BindingSource T6BS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatosCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCLIENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clirsocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cli_fantasia;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUITDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionfacturacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direfactuLocalidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direfactuProvinciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cONTACTOVTADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMAILFACTUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEFONO_COB;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDataCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFantasia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRazonSocial1;
        private System.Windows.Forms.TabPage tabDataCuentaCorriente;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TabPage tabNotas;
        private System.Windows.Forms.Button btnNuevaNota;
        private System.Windows.Forms.Button btnNuevaAccion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccionFacturacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefonoVentas;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelCobranza;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCUIT;
    }
}