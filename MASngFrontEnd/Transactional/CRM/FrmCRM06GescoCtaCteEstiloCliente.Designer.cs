namespace MASngFE.Transactional.CRM
{
    partial class FrmCRM06GescoCtaCteEstiloCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCRM06GescoCtaCteEstiloCliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.tCustomerBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDias = new TSControls.CtlTextBox();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtCondicionPagoL2 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtCondicionPagoL1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtLimiteCredito = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtSaldoTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSaldoL2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSaldoL1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckL2 = new System.Windows.Forms.CheckBox();
            this.ckL1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.ctaCteCliSaldoAcumuladoStxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldoAccDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeUSDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tCustomerBs)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctaCteCliSaldoAcumuladoStxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnEjecutar.Image")));
            this.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEjecutar.Location = new System.Drawing.Point(688, 49);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(107, 45);
            this.btnEjecutar.TabIndex = 152;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(688, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 45);
            this.btnClose.TabIndex = 151;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(687, 95);
            this.btnReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(107, 45);
            this.btnReport.TabIndex = 153;
            this.btnReport.Text = "Reporte";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tCustomerBs
            // 
            this.tCustomerBs.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.txtDias);
            this.panel2.Controls.Add(this.dtpFechaDesde);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.txtCondicionPagoL2);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.txtCondicionPagoL1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmbCliente);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox11);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.txtIdCliente);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(479, 98);
            this.panel2.TabIndex = 156;
            // 
            // txtDias
            // 
            this.txtDias.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtDias.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDias.Location = new System.Drawing.Point(417, 49);
            this.txtDias.Name = "txtDias";
            this.txtDias.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.txtDias.SetDecimales = 0;
            this.txtDias.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.txtDias.Size = new System.Drawing.Size(50, 20);
            this.txtDias.TabIndex = 158;
              this.txtDias.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtDias.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.txtDias.XReadOnly = false;
            this.txtDias.Validated += new System.EventHandler(this.txtDias_Validated);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(142, 49);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(273, 22);
            this.dtpFechaDesde.TabIndex = 159;
            this.dtpFechaDesde.Validated += new System.EventHandler(this.dtpFechaDesde_Validated);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DataSource = this.tCustomerBs;
            this.comboBox1.DisplayMember = "cli_fantasia";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(142, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(273, 22);
            this.comboBox1.TabIndex = 158;
            this.comboBox1.ValueMember = "IDCLIENTE";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(205, 76);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(18, 14);
            this.label27.TabIndex = 156;
            this.label27.Text = "L2";
            // 
            // txtCondicionPagoL2
            // 
            this.txtCondicionPagoL2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCondicionPagoL2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCondicionPagoL2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondicionPagoL2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCondicionPagoL2.Location = new System.Drawing.Point(228, 72);
            this.txtCondicionPagoL2.Name = "txtCondicionPagoL2";
            this.txtCondicionPagoL2.ReadOnly = true;
            this.txtCondicionPagoL2.Size = new System.Drawing.Size(50, 22);
            this.txtCondicionPagoL2.TabIndex = 155;
            this.txtCondicionPagoL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(9, 76);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(121, 14);
            this.label26.TabIndex = 154;
            this.label26.Text = "Condicion de Pago L1";
            // 
            // txtCondicionPagoL1
            // 
            this.txtCondicionPagoL1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCondicionPagoL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCondicionPagoL1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondicionPagoL1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCondicionPagoL1.Location = new System.Drawing.Point(142, 72);
            this.txtCondicionPagoL1.Name = "txtCondicionPagoL1";
            this.txtCondicionPagoL1.ReadOnly = true;
            this.txtCondicionPagoL1.Size = new System.Drawing.Size(50, 22);
            this.txtCondicionPagoL1.TabIndex = 153;
            this.txtCondicionPagoL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 14);
            this.label5.TabIndex = 146;
            this.label5.Text = "Resumen Desde";
            // 
            // cmbCliente
            // 
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.DataSource = this.tCustomerBs;
            this.cmbCliente.DisplayMember = "cli_rsocial";
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(142, 3);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(273, 22);
            this.cmbCliente.TabIndex = 145;
            this.cmbCliente.ValueMember = "IDCLIENTE";
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 14);
            this.label2.TabIndex = 144;
            this.label2.Text = "Cliente (Razon Social)";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(-172, 50);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(70, 22);
            this.textBox11.TabIndex = 93;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(-250, 54);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 14);
            this.label25.TabIndex = 44;
            this.label25.Text = "Numero RC";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtIdCliente.ForeColor = System.Drawing.Color.Navy;
            this.txtIdCliente.Location = new System.Drawing.Point(417, 3);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(50, 22);
            this.txtIdCliente.TabIndex = 108;
            this.txtIdCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 94;
            this.label3.Text = "Cliente (Fantasia)";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.txtLimiteCredito);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.txtSaldoTotal);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtSaldoL2);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtSaldoL1);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(482, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(187, 98);
            this.panel3.TabIndex = 157;
            // 
            // txtLimiteCredito
            // 
            this.txtLimiteCredito.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtLimiteCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLimiteCredito.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLimiteCredito.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtLimiteCredito.Location = new System.Drawing.Point(84, 72);
            this.txtLimiteCredito.Name = "txtLimiteCredito";
            this.txtLimiteCredito.ReadOnly = true;
            this.txtLimiteCredito.Size = new System.Drawing.Size(99, 22);
            this.txtLimiteCredito.TabIndex = 158;
            this.txtLimiteCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(9, 76);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(68, 14);
            this.label28.TabIndex = 159;
            this.label28.Text = "Lim.Credito";
            // 
            // txtSaldoTotal
            // 
            this.txtSaldoTotal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSaldoTotal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSaldoTotal.Location = new System.Drawing.Point(84, 49);
            this.txtSaldoTotal.Name = "txtSaldoTotal";
            this.txtSaldoTotal.ReadOnly = true;
            this.txtSaldoTotal.Size = new System.Drawing.Size(99, 22);
            this.txtSaldoTotal.TabIndex = 152;
            this.txtSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 14);
            this.label6.TabIndex = 151;
            this.label6.Text = "Deuda Total";
            // 
            // txtSaldoL2
            // 
            this.txtSaldoL2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSaldoL2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSaldoL2.Location = new System.Drawing.Point(84, 26);
            this.txtSaldoL2.Name = "txtSaldoL2";
            this.txtSaldoL2.ReadOnly = true;
            this.txtSaldoL2.Size = new System.Drawing.Size(99, 22);
            this.txtSaldoL2.TabIndex = 150;
            this.txtSaldoL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 14);
            this.label13.TabIndex = 144;
            this.label13.Text = "Deuda L1";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(-172, 50);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(70, 22);
            this.textBox5.TabIndex = 93;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(-250, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 14);
            this.label14.TabIndex = 44;
            this.label14.Text = "Numero RC";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 14);
            this.label16.TabIndex = 94;
            this.label16.Text = "Deuda L2";
            // 
            // txtSaldoL1
            // 
            this.txtSaldoL1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSaldoL1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSaldoL1.Location = new System.Drawing.Point(84, 3);
            this.txtSaldoL1.Name = "txtSaldoL1";
            this.txtSaldoL1.ReadOnly = true;
            this.txtSaldoL1.Size = new System.Drawing.Size(99, 22);
            this.txtSaldoL1.TabIndex = 118;
            this.txtSaldoL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.ckL2);
            this.panel1.Controls.Add(this.ckL1);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 29);
            this.panel1.TabIndex = 160;
            // 
            // ckL2
            // 
            this.ckL2.AutoSize = true;
            this.ckL2.Location = new System.Drawing.Point(75, 6);
            this.ckL2.Name = "ckL2";
            this.ckL2.Size = new System.Drawing.Size(37, 18);
            this.ckL2.TabIndex = 162;
            this.ckL2.Text = "L2";
            this.ckL2.UseVisualStyleBackColor = true;
            this.ckL2.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            // 
            // ckL1
            // 
            this.ckL1.AutoSize = true;
            this.ckL1.Location = new System.Drawing.Point(12, 6);
            this.ckL1.Name = "ckL1";
            this.ckL1.Size = new System.Drawing.Size(37, 18);
            this.ckL1.TabIndex = 161;
            this.ckL1.Text = "L1";
            this.ckL1.UseVisualStyleBackColor = true;
            this.ckL1.CheckedChanged += new System.EventHandler(this.ckL1_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(-172, 50);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(70, 22);
            this.textBox4.TabIndex = 93;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-250, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 14);
            this.label8.TabIndex = 44;
            this.label8.Text = "Numero RC";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRegDataGridViewTextBoxColumn,
            this.fechaDocDataGridViewTextBoxColumn,
            this.tipoDocDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.monDataGridViewTextBoxColumn,
            this.tCDataGridViewTextBoxColumn,
            this.importeDataGridViewTextBoxColumn,
            this.saldoAccDataGridViewTextBoxColumn,
            this.importeUSDDataGridViewTextBoxColumn,
            this.lxDataGridViewTextBoxColumn});
            this.dgvData.DataSource = this.ctaCteCliSaldoAcumuladoStxBindingSource;
            this.dgvData.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvData.Location = new System.Drawing.Point(1, 132);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 20;
            this.dgvData.Size = new System.Drawing.Size(668, 483);
            this.dgvData.TabIndex = 161;
            // 
            // ctaCteCliSaldoAcumuladoStxBindingSource
            // 
            this.ctaCteCliSaldoAcumuladoStxBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.CtaCteCliSaldoAcumuladoStx);
            // 
            // idRegDataGridViewTextBoxColumn
            // 
            this.idRegDataGridViewTextBoxColumn.DataPropertyName = "IdReg";
            this.idRegDataGridViewTextBoxColumn.HeaderText = "#";
            this.idRegDataGridViewTextBoxColumn.Name = "idRegDataGridViewTextBoxColumn";
            this.idRegDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRegDataGridViewTextBoxColumn.Width = 60;
            // 
            // fechaDocDataGridViewTextBoxColumn
            // 
            this.fechaDocDataGridViewTextBoxColumn.DataPropertyName = "FechaDoc";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.fechaDocDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fechaDocDataGridViewTextBoxColumn.HeaderText = "Fecha Doc";
            this.fechaDocDataGridViewTextBoxColumn.Name = "fechaDocDataGridViewTextBoxColumn";
            this.fechaDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDocDataGridViewTextBoxColumn.ToolTipText = "Fecha del Documento";
            this.fechaDocDataGridViewTextBoxColumn.Width = 90;
            // 
            // tipoDocDataGridViewTextBoxColumn
            // 
            this.tipoDocDataGridViewTextBoxColumn.DataPropertyName = "TipoDoc";
            this.tipoDocDataGridViewTextBoxColumn.HeaderText = "TDoc";
            this.tipoDocDataGridViewTextBoxColumn.Name = "tipoDocDataGridViewTextBoxColumn";
            this.tipoDocDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoDocDataGridViewTextBoxColumn.Width = 45;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "Numero";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // monDataGridViewTextBoxColumn
            // 
            this.monDataGridViewTextBoxColumn.DataPropertyName = "Mon";
            this.monDataGridViewTextBoxColumn.HeaderText = "Mon";
            this.monDataGridViewTextBoxColumn.Name = "monDataGridViewTextBoxColumn";
            this.monDataGridViewTextBoxColumn.ReadOnly = true;
            this.monDataGridViewTextBoxColumn.Width = 40;
            // 
            // tCDataGridViewTextBoxColumn
            // 
            this.tCDataGridViewTextBoxColumn.DataPropertyName = "TC";
            this.tCDataGridViewTextBoxColumn.HeaderText = "TC";
            this.tCDataGridViewTextBoxColumn.Name = "tCDataGridViewTextBoxColumn";
            this.tCDataGridViewTextBoxColumn.ReadOnly = true;
            this.tCDataGridViewTextBoxColumn.Width = 40;
            // 
            // importeDataGridViewTextBoxColumn
            // 
            this.importeDataGridViewTextBoxColumn.DataPropertyName = "Importe";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            this.importeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.importeDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.importeDataGridViewTextBoxColumn.Name = "importeDataGridViewTextBoxColumn";
            this.importeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // saldoAccDataGridViewTextBoxColumn
            // 
            this.saldoAccDataGridViewTextBoxColumn.DataPropertyName = "SaldoAcc";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.Format = "C2";
            this.saldoAccDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.saldoAccDataGridViewTextBoxColumn.HeaderText = "Cta Cte";
            this.saldoAccDataGridViewTextBoxColumn.Name = "saldoAccDataGridViewTextBoxColumn";
            this.saldoAccDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // importeUSDDataGridViewTextBoxColumn
            // 
            this.importeUSDDataGridViewTextBoxColumn.DataPropertyName = "ImporteUSD";
            dataGridViewCellStyle8.Format = "C2";
            this.importeUSDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.importeUSDDataGridViewTextBoxColumn.HeaderText = "ImporteUSD";
            this.importeUSDDataGridViewTextBoxColumn.Name = "importeUSDDataGridViewTextBoxColumn";
            this.importeUSDDataGridViewTextBoxColumn.ReadOnly = true;
            this.importeUSDDataGridViewTextBoxColumn.Visible = false;
            this.importeUSDDataGridViewTextBoxColumn.Width = 70;
            // 
            // lxDataGridViewTextBoxColumn
            // 
            this.lxDataGridViewTextBoxColumn.DataPropertyName = "Lx";
            this.lxDataGridViewTextBoxColumn.HeaderText = "Lx";
            this.lxDataGridViewTextBoxColumn.Name = "lxDataGridViewTextBoxColumn";
            this.lxDataGridViewTextBoxColumn.ReadOnly = true;
            this.lxDataGridViewTextBoxColumn.Width = 30;
            // 
            // FrmCRM06GescoCtaCteEstiloCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 620);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.btnClose);
            this.Name = "FrmCRM06GescoCtaCteEstiloCliente";
            this.Text = "CRM06 - Detalle de Cuenta Corriente [Estilo Cliente]";
            this.Load += new System.EventHandler(this.FrmCRM06GescoCtaCteEstiloCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tCustomerBs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctaCteCliSaldoAcumuladoStxBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.BindingSource tCustomerBs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtCondicionPagoL2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtCondicionPagoL1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtLimiteCredito;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtSaldoTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSaldoL2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSaldoL1;
        private TSControls.CtlTextBox txtDias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckL2;
        private System.Windows.Forms.CheckBox ckL1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.BindingSource ctaCteCliSaldoAcumuladoStxBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRegDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldoAccDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeUSDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lxDataGridViewTextBoxColumn;
    }
}