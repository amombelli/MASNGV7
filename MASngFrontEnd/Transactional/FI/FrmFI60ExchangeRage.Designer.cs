namespace MASngFE.Transactional.FI
{
    partial class FrmFI60ExchangeRage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI60ExchangeRage));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cotizacionFactuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cotizacionFactuL2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cotizacionCobraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lUSERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.xRateBs = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panIdentificacionCliente = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.ctlXRateFactura2 = new TSControls.CtlTextBox();
            this.ctlXRateCobranza = new TSControls.CtlTextBox();
            this.ctlXRateFactura = new TSControls.CtlTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xRateBs)).BeginInit();
            this.panIdentificacionCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightCoral;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 556);
            this.label2.TabIndex = 142;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightCoral;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(633, 3);
            this.label3.TabIndex = 141;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(527, 53);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 143;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightCoral;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(632, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 556);
            this.label1.TabIndex = 144;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaDataGridViewTextBoxColumn,
            this.cotizacionFactuDataGridViewTextBoxColumn,
            this.cotizacionFactuL2DataGridViewTextBoxColumn,
            this.cotizacionCobraDataGridViewTextBoxColumn,
            this.lUSERDataGridViewTextBoxColumn,
            this.lDATEDataGridViewTextBoxColumn,
            this.Edit});
            this.dgvData.DataSource = this.xRateBs;
            this.dgvData.GridColor = System.Drawing.Color.Indigo;
            this.dgvData.Location = new System.Drawing.Point(6, 128);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 20;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(617, 427);
            this.dgvData.TabIndex = 145;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cotizacionFactuDataGridViewTextBoxColumn
            // 
            this.cotizacionFactuDataGridViewTextBoxColumn.DataPropertyName = "CotizacionFactu";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = "0";
            this.cotizacionFactuDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.cotizacionFactuDataGridViewTextBoxColumn.HeaderText = "TC Factu";
            this.cotizacionFactuDataGridViewTextBoxColumn.Name = "cotizacionFactuDataGridViewTextBoxColumn";
            this.cotizacionFactuDataGridViewTextBoxColumn.ReadOnly = true;
            this.cotizacionFactuDataGridViewTextBoxColumn.Width = 80;
            // 
            // cotizacionFactuL2DataGridViewTextBoxColumn
            // 
            this.cotizacionFactuL2DataGridViewTextBoxColumn.DataPropertyName = "CotizacionFactuL2";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = "0";
            this.cotizacionFactuL2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.cotizacionFactuL2DataGridViewTextBoxColumn.HeaderText = "TC Factu2";
            this.cotizacionFactuL2DataGridViewTextBoxColumn.Name = "cotizacionFactuL2DataGridViewTextBoxColumn";
            this.cotizacionFactuL2DataGridViewTextBoxColumn.ReadOnly = true;
            this.cotizacionFactuL2DataGridViewTextBoxColumn.Width = 80;
            // 
            // cotizacionCobraDataGridViewTextBoxColumn
            // 
            this.cotizacionCobraDataGridViewTextBoxColumn.DataPropertyName = "CotizacionCobra";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = "0";
            this.cotizacionCobraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.cotizacionCobraDataGridViewTextBoxColumn.HeaderText = "TC Cobra";
            this.cotizacionCobraDataGridViewTextBoxColumn.Name = "cotizacionCobraDataGridViewTextBoxColumn";
            this.cotizacionCobraDataGridViewTextBoxColumn.ReadOnly = true;
            this.cotizacionCobraDataGridViewTextBoxColumn.Width = 80;
            // 
            // lUSERDataGridViewTextBoxColumn
            // 
            this.lUSERDataGridViewTextBoxColumn.DataPropertyName = "LUSER";
            this.lUSERDataGridViewTextBoxColumn.HeaderText = "UserIn";
            this.lUSERDataGridViewTextBoxColumn.Name = "lUSERDataGridViewTextBoxColumn";
            this.lUSERDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lDATEDataGridViewTextBoxColumn
            // 
            this.lDATEDataGridViewTextBoxColumn.DataPropertyName = "LDATE";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "g";
            dataGridViewCellStyle10.NullValue = null;
            this.lDATEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.lDATEDataGridViewTextBoxColumn.HeaderText = "FechaIn";
            this.lDATEDataGridViewTextBoxColumn.Name = "lDATEDataGridViewTextBoxColumn";
            this.lDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.ToolTipText = "Editar TC Seleccionado";
            this.Edit.Width = 50;
            // 
            // xRateBs
            // 
            this.xRateBs.DataSource = typeof(TecserEF.Entity.T0102_EXCHANGE);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.PaleGreen;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(617, 20);
            this.label4.TabIndex = 162;
            this.label4.Text = "Informacion de Tipo de Cambio Historica";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightCoral;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 558);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(633, 3);
            this.label5.TabIndex = 163;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(527, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 164;
            this.btnAdd.Text = "Alta";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panIdentificacionCliente
            // 
            this.panIdentificacionCliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panIdentificacionCliente.Controls.Add(this.dtpFecha);
            this.panIdentificacionCliente.Controls.Add(this.ctlXRateFactura2);
            this.panIdentificacionCliente.Controls.Add(this.ctlXRateCobranza);
            this.panIdentificacionCliente.Controls.Add(this.ctlXRateFactura);
            this.panIdentificacionCliente.Controls.Add(this.label6);
            this.panIdentificacionCliente.Controls.Add(this.label13);
            this.panIdentificacionCliente.Controls.Add(this.label7);
            this.panIdentificacionCliente.Controls.Add(this.label20);
            this.panIdentificacionCliente.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panIdentificacionCliente.Location = new System.Drawing.Point(6, 6);
            this.panIdentificacionCliente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panIdentificacionCliente.Name = "panIdentificacionCliente";
            this.panIdentificacionCliente.Size = new System.Drawing.Size(380, 99);
            this.panIdentificacionCliente.TabIndex = 165;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dtpFecha.Location = new System.Drawing.Point(109, 3);
            this.dtpFecha.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(245, 23);
            this.dtpFecha.TabIndex = 13;
            this.dtpFecha.Value = new System.DateTime(2020, 6, 30, 16, 22, 39, 0);
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // ctlXRateFactura2
            // 
            this.ctlXRateFactura2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlXRateFactura2.BackColor = System.Drawing.Color.White;
            this.ctlXRateFactura2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlXRateFactura2.Location = new System.Drawing.Point(109, 50);
            this.ctlXRateFactura2.Margin = new System.Windows.Forms.Padding(0);
            this.ctlXRateFactura2.Name = "ctlXRateFactura2";
            this.ctlXRateFactura2.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlXRateFactura2.SetDecimales = 2;
            this.ctlXRateFactura2.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.ctlXRateFactura2.Size = new System.Drawing.Size(76, 22);
            this.ctlXRateFactura2.TabIndex = 12;
            this.ctlXRateFactura2.ValorMaximo = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ctlXRateFactura2.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlXRateFactura2.XReadOnly = false;
            // 
            // ctlXRateCobranza
            // 
            this.ctlXRateCobranza.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlXRateCobranza.BackColor = System.Drawing.Color.White;
            this.ctlXRateCobranza.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlXRateCobranza.Location = new System.Drawing.Point(109, 73);
            this.ctlXRateCobranza.Margin = new System.Windows.Forms.Padding(0);
            this.ctlXRateCobranza.Name = "ctlXRateCobranza";
            this.ctlXRateCobranza.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlXRateCobranza.SetDecimales = 2;
            this.ctlXRateCobranza.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.ctlXRateCobranza.Size = new System.Drawing.Size(76, 22);
            this.ctlXRateCobranza.TabIndex = 11;
              this.ctlXRateCobranza.ValorMaximo = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ctlXRateCobranza.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlXRateCobranza.XReadOnly = false;
            // 
            // ctlXRateFactura
            // 
            this.ctlXRateFactura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlXRateFactura.BackColor = System.Drawing.Color.White;
            this.ctlXRateFactura.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlXRateFactura.Location = new System.Drawing.Point(109, 27);
            this.ctlXRateFactura.Margin = new System.Windows.Forms.Padding(0);
            this.ctlXRateFactura.Name = "ctlXRateFactura";
            this.ctlXRateFactura.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlXRateFactura.SetDecimales = 2;
            this.ctlXRateFactura.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.ctlXRateFactura.Size = new System.Drawing.Size(76, 22);
            this.ctlXRateFactura.TabIndex = 10;
            this.ctlXRateFactura.ValorMaximo = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ctlXRateFactura.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlXRateFactura.XReadOnly = false;
            this.ctlXRateFactura.Validated += new System.EventHandler(this.ctlXRateFactura_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(13, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "XRate Cobranza";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(14, 54);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 14);
            this.label13.TabIndex = 8;
            this.label13.Text = "XRate Factura 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(23, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "XRate Factura";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DarkBlue;
            this.label20.Location = new System.Drawing.Point(7, 7);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(97, 14);
            this.label20.TabIndex = 6;
            this.label20.Text = "Fecha Cotizacion";
            // 
            // FrmFI60ExchangeRage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(639, 564);
            this.Controls.Add(this.panIdentificacionCliente);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "FrmFI60ExchangeRage";
            this.Text = "FI60 - Exchange Rate Manager";
            this.Load += new System.EventHandler(this.FrmFI60ExchangeRage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xRateBs)).EndInit();
            this.panIdentificacionCliente.ResumeLayout(false);
            this.panIdentificacionCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.BindingSource xRateBs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cotizacionFactuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cotizacionFactuL2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cotizacionCobraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lUSERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panIdentificacionCliente;
        private TSControls.CtlTextBox ctlXRateFactura2;
        private TSControls.CtlTextBox ctlXRateCobranza;
        private TSControls.CtlTextBox ctlXRateFactura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}