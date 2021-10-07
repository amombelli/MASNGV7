namespace MASngFE.Transactional.PP
{
    partial class FrmPP09IngresoTemporal
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
            this.btnIngresoTemporal = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtNumeroOF = new System.Windows.Forms.TextBox();
            this.txtMaterialFabricado = new System.Windows.Forms.TextBox();
            this.txtKgingresados = new System.Windows.Forms.TextBox();
            this.txtEstadoOF = new System.Windows.Forms.TextBox();
            this.txtMaterialEtiqueta = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKgIngresar = new System.Windows.Forms.TextBox();
            this.btnAyer = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroLote = new System.Windows.Forms.TextBox();
            this.cmbEstadoLote = new System.Windows.Forms.ComboBox();
            this.t0029ESTADOSTOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbRecurso = new System.Windows.Forms.ComboBox();
            this.t0032RECURSOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.cmbSloc = new System.Windows.Forms.ComboBox();
            this.t0028SLOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaIngresoProduccion = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtObservacionIngreso = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDetalleIngreso = new System.Windows.Forms.DataGridView();
            this.@__idmovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHAMOVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPOMOVIMIENTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODOCUMENTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cANTIDADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bATCHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rECURSODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOGUSERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lOGDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMENTARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvBtnReversar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0040MATMOVIMIENTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0029ESTADOSTOCKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0032RECURSOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleIngreso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0040MATMOVIMIENTOSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIngresoTemporal
            // 
            this.btnIngresoTemporal.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresoTemporal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresoTemporal.Location = new System.Drawing.Point(726, 282);
            this.btnIngresoTemporal.Name = "btnIngresoTemporal";
            this.btnIngresoTemporal.Size = new System.Drawing.Size(100, 40);
            this.btnIngresoTemporal.TabIndex = 40;
            this.btnIngresoTemporal.Text = "Ingreso\r\nSTOCK";
            this.btnIngresoTemporal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresoTemporal.UseVisualStyleBackColor = true;
            this.btnIngresoTemporal.Click += new System.EventHandler(this.btnIngresoTemporal_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(726, 324);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 39;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label30);
            this.panel6.Controls.Add(this.label29);
            this.panel6.Controls.Add(this.txtNumeroOF);
            this.panel6.Controls.Add(this.txtMaterialFabricado);
            this.panel6.Controls.Add(this.txtKgingresados);
            this.panel6.Controls.Add(this.txtEstadoOF);
            this.panel6.Controls.Add(this.txtMaterialEtiqueta);
            this.panel6.Location = new System.Drawing.Point(4, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(822, 69);
            this.panel6.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(573, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "KG INGRESADOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "ETIQUETA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(573, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "ESTADO";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(177, 10);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(94, 20);
            this.label30.TabIndex = 2;
            this.label30.Text = "MATERIAL ";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(16, 10);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(44, 20);
            this.label29.TabIndex = 1;
            this.label29.Text = "OF #";
            // 
            // txtNumeroOF
            // 
            this.txtNumeroOF.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNumeroOF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOF.Location = new System.Drawing.Point(66, 11);
            this.txtNumeroOF.Name = "txtNumeroOF";
            this.txtNumeroOF.Size = new System.Drawing.Size(101, 19);
            this.txtNumeroOF.TabIndex = 0;
            this.txtNumeroOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumeroOF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroOF_KeyPress);
            this.txtNumeroOF.Leave += new System.EventHandler(this.txtNumeroOF_Leave);
            // 
            // txtMaterialFabricado
            // 
            this.txtMaterialFabricado.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMaterialFabricado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialFabricado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialFabricado.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaterialFabricado.Location = new System.Drawing.Point(271, 11);
            this.txtMaterialFabricado.Name = "txtMaterialFabricado";
            this.txtMaterialFabricado.ReadOnly = true;
            this.txtMaterialFabricado.Size = new System.Drawing.Size(234, 19);
            this.txtMaterialFabricado.TabIndex = 5;
            this.txtMaterialFabricado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKgingresados
            // 
            this.txtKgingresados.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.txtKgingresados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKgingresados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgingresados.ForeColor = System.Drawing.Color.Crimson;
            this.txtKgingresados.Location = new System.Drawing.Point(722, 36);
            this.txtKgingresados.Name = "txtKgingresados";
            this.txtKgingresados.ReadOnly = true;
            this.txtKgingresados.Size = new System.Drawing.Size(90, 19);
            this.txtKgingresados.TabIndex = 19;
            this.txtKgingresados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEstadoOF
            // 
            this.txtEstadoOF.BackColor = System.Drawing.Color.Gainsboro;
            this.txtEstadoOF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstadoOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstadoOF.Location = new System.Drawing.Point(677, 10);
            this.txtEstadoOF.Name = "txtEstadoOF";
            this.txtEstadoOF.ReadOnly = true;
            this.txtEstadoOF.Size = new System.Drawing.Size(135, 19);
            this.txtEstadoOF.TabIndex = 11;
            this.txtEstadoOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaterialEtiqueta
            // 
            this.txtMaterialEtiqueta.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMaterialEtiqueta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialEtiqueta.Location = new System.Drawing.Point(271, 36);
            this.txtMaterialEtiqueta.Name = "txtMaterialEtiqueta";
            this.txtMaterialEtiqueta.ReadOnly = true;
            this.txtMaterialEtiqueta.Size = new System.Drawing.Size(234, 19);
            this.txtMaterialEtiqueta.TabIndex = 7;
            this.txtMaterialEtiqueta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LavenderBlush;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.OrangeRed;
            this.label11.Location = new System.Drawing.Point(4, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(272, 18);
            this.label11.TabIndex = 43;
            this.label11.Text = "DATOS DE LA PRODUCCION REAL";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtKgIngresar);
            this.panel2.Controls.Add(this.btnAyer);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtNumeroLote);
            this.panel2.Controls.Add(this.cmbEstadoLote);
            this.panel2.Controls.Add(this.cmbRecurso);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.cmbOperador);
            this.panel2.Controls.Add(this.cmbSloc);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.dtpFechaIngresoProduccion);
            this.panel2.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.panel2.Location = new System.Drawing.Point(4, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 164);
            this.panel2.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Ivory;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 14);
            this.label3.TabIndex = 30;
            this.label3.Text = "KG a INGRESAR";
            // 
            // txtKgIngresar
            // 
            this.txtKgIngresar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgIngresar.ForeColor = System.Drawing.Color.Crimson;
            this.txtKgIngresar.Location = new System.Drawing.Point(123, 136);
            this.txtKgIngresar.Name = "txtKgIngresar";
            this.txtKgIngresar.ReadOnly = true;
            this.txtKgIngresar.Size = new System.Drawing.Size(83, 21);
            this.txtKgIngresar.TabIndex = 29;
            this.txtKgIngresar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKgIngresar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKgIngresar_KeyPress);
            this.txtKgIngresar.Validating += new System.ComponentModel.CancelEventHandler(this.txtKgIngresar_Validating);
            // 
            // btnAyer
            // 
            this.btnAyer.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnAyer.Location = new System.Drawing.Point(223, 3);
            this.btnAyer.Name = "btnAyer";
            this.btnAyer.Size = new System.Drawing.Size(39, 21);
            this.btnAyer.TabIndex = 24;
            this.btnAyer.Text = "AYER";
            this.btnAyer.UseVisualStyleBackColor = true;
            this.btnAyer.Click += new System.EventHandler(this.btnAyer_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Ivory;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(46, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 14);
            this.label14.TabIndex = 28;
            this.label14.Text = "Estado LOTE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Ivory;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 14);
            this.label8.TabIndex = 21;
            this.label8.Text = "Recurso Produccion";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Ivory;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(40, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 14);
            this.label13.TabIndex = 23;
            this.label13.Text = "Numero LOTE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Ivory;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Fecha Produccion";
            // 
            // txtNumeroLote
            // 
            this.txtNumeroLote.BackColor = System.Drawing.Color.White;
            this.txtNumeroLote.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroLote.ForeColor = System.Drawing.Color.Crimson;
            this.txtNumeroLote.Location = new System.Drawing.Point(123, 69);
            this.txtNumeroLote.Name = "txtNumeroLote";
            this.txtNumeroLote.ReadOnly = true;
            this.txtNumeroLote.Size = new System.Drawing.Size(83, 21);
            this.txtNumeroLote.TabIndex = 0;
            this.txtNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbEstadoLote
            // 
            this.cmbEstadoLote.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstadoLote.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstadoLote.BackColor = System.Drawing.Color.White;
            this.cmbEstadoLote.DataSource = this.t0029ESTADOSTOCKBindingSource;
            this.cmbEstadoLote.DisplayMember = "ESTADO";
            this.cmbEstadoLote.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstadoLote.FormattingEnabled = true;
            this.cmbEstadoLote.Location = new System.Drawing.Point(123, 91);
            this.cmbEstadoLote.Name = "cmbEstadoLote";
            this.cmbEstadoLote.Size = new System.Drawing.Size(139, 21);
            this.cmbEstadoLote.TabIndex = 1;
            this.cmbEstadoLote.ValueMember = "ESTADO";
            this.cmbEstadoLote.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoLote_SelectedIndexChanged);
            // 
            // t0029ESTADOSTOCKBindingSource
            // 
            this.t0029ESTADOSTOCKBindingSource.DataSource = typeof(TecserEF.Entity.T0029_ESTADO_STOCK);
            // 
            // cmbRecurso
            // 
            this.cmbRecurso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRecurso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRecurso.BackColor = System.Drawing.Color.White;
            this.cmbRecurso.DataSource = this.t0032RECURSOSBindingSource;
            this.cmbRecurso.DisplayMember = "NombreRecurso";
            this.cmbRecurso.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecurso.FormattingEnabled = true;
            this.cmbRecurso.Location = new System.Drawing.Point(123, 25);
            this.cmbRecurso.Name = "cmbRecurso";
            this.cmbRecurso.Size = new System.Drawing.Size(139, 21);
            this.cmbRecurso.TabIndex = 1;
            this.cmbRecurso.ValueMember = "IdRecurso";
            // 
            // t0032RECURSOSBindingSource
            // 
            this.t0032RECURSOSBindingSource.DataSource = typeof(TecserEF.Entity.T0032_RECURSOS);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Ivory;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(36, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 14);
            this.label15.TabIndex = 26;
            this.label15.Text = "Ubicacion STK";
            // 
            // cmbOperador
            // 
            this.cmbOperador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbOperador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOperador.BackColor = System.Drawing.Color.White;
            this.cmbOperador.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Location = new System.Drawing.Point(123, 47);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.Size = new System.Drawing.Size(139, 21);
            this.cmbOperador.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmbOperador, "Seleccionen el Operador Responsnable de esta produccion");
            // 
            // cmbSloc
            // 
            this.cmbSloc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSloc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSloc.BackColor = System.Drawing.Color.White;
            this.cmbSloc.DataSource = this.t0028SLOCBindingSource;
            this.cmbSloc.DisplayMember = "SLOC";
            this.cmbSloc.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSloc.FormattingEnabled = true;
            this.cmbSloc.Location = new System.Drawing.Point(123, 113);
            this.cmbSloc.Name = "cmbSloc";
            this.cmbSloc.Size = new System.Drawing.Size(83, 21);
            this.cmbSloc.TabIndex = 2;
            this.cmbSloc.ValueMember = "SLOC";
            // 
            // t0028SLOCBindingSource
            // 
            this.t0028SLOCBindingSource.DataSource = typeof(TecserEF.Entity.T0028_SLOC);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Ivory;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(60, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "Operador";
            // 
            // dtpFechaIngresoProduccion
            // 
            this.dtpFechaIngresoProduccion.CalendarFont = new System.Drawing.Font("Calibri", 8.25F);
            this.dtpFechaIngresoProduccion.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.dtpFechaIngresoProduccion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngresoProduccion.Location = new System.Drawing.Point(123, 3);
            this.dtpFechaIngresoProduccion.Name = "dtpFechaIngresoProduccion";
            this.dtpFechaIngresoProduccion.Size = new System.Drawing.Size(98, 21);
            this.dtpFechaIngresoProduccion.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(301, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 14);
            this.label5.TabIndex = 32;
            this.label5.Text = "Observacion de Ingreso";
            // 
            // txtObservacionIngreso
            // 
            this.txtObservacionIngreso.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtObservacionIngreso.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacionIngreso.ForeColor = System.Drawing.Color.Black;
            this.txtObservacionIngreso.Location = new System.Drawing.Point(304, 112);
            this.txtObservacionIngreso.Multiline = true;
            this.txtObservacionIngreso.Name = "txtObservacionIngreso";
            this.txtObservacionIngreso.ReadOnly = true;
            this.txtObservacionIngreso.Size = new System.Drawing.Size(206, 74);
            this.txtObservacionIngreso.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.dgvDetalleIngreso);
            this.panel1.Location = new System.Drawing.Point(4, 282);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 184);
            this.panel1.TabIndex = 44;
            // 
            // dgvDetalleIngreso
            // 
            this.dgvDetalleIngreso.AllowUserToAddRows = false;
            this.dgvDetalleIngreso.AllowUserToDeleteRows = false;
            this.dgvDetalleIngreso.AutoGenerateColumns = false;
            this.dgvDetalleIngreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleIngreso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__idmovimiento,
            this.fECHAMOVDataGridViewTextBoxColumn,
            this.tIPOMOVIMIENTODataGridViewTextBoxColumn,
            this.tIPODOCUMENTODataGridViewTextBoxColumn,
            this.cANTIDADDataGridViewTextBoxColumn,
            this.bATCHDataGridViewTextBoxColumn,
            this.rECURSODataGridViewTextBoxColumn,
            this.lOGUSERDataGridViewTextBoxColumn,
            this.lOGDATEDataGridViewTextBoxColumn,
            this.cOMENTARIODataGridViewTextBoxColumn,
            this.dgvBtnReversar});
            this.dgvDetalleIngreso.DataSource = this.t0040MATMOVIMIENTOSBindingSource;
            this.dgvDetalleIngreso.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDetalleIngreso.Location = new System.Drawing.Point(4, 6);
            this.dgvDetalleIngreso.Name = "dgvDetalleIngreso";
            this.dgvDetalleIngreso.ReadOnly = true;
            this.dgvDetalleIngreso.RowHeadersWidth = 15;
            this.dgvDetalleIngreso.Size = new System.Drawing.Size(711, 174);
            this.dgvDetalleIngreso.TabIndex = 0;
            this.dgvDetalleIngreso.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleIngreso_CellContentClick);
            // 
            // __idmovimiento
            // 
            this.@__idmovimiento.DataPropertyName = "IDMOVIMIENTO";
            this.@__idmovimiento.HeaderText = "IdMov";
            this.@__idmovimiento.Name = "__idmovimiento";
            this.@__idmovimiento.ReadOnly = true;
            this.@__idmovimiento.Visible = false;
            this.@__idmovimiento.Width = 40;
            // 
            // fECHAMOVDataGridViewTextBoxColumn
            // 
            this.fECHAMOVDataGridViewTextBoxColumn.DataPropertyName = "FECHAMOV";
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.fECHAMOVDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.fECHAMOVDataGridViewTextBoxColumn.HeaderText = "FechaProd";
            this.fECHAMOVDataGridViewTextBoxColumn.Name = "fECHAMOVDataGridViewTextBoxColumn";
            this.fECHAMOVDataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHAMOVDataGridViewTextBoxColumn.Width = 70;
            // 
            // tIPOMOVIMIENTODataGridViewTextBoxColumn
            // 
            this.tIPOMOVIMIENTODataGridViewTextBoxColumn.DataPropertyName = "TIPOMOVIMIENTO";
            this.tIPOMOVIMIENTODataGridViewTextBoxColumn.HeaderText = "Mov";
            this.tIPOMOVIMIENTODataGridViewTextBoxColumn.Name = "tIPOMOVIMIENTODataGridViewTextBoxColumn";
            this.tIPOMOVIMIENTODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPOMOVIMIENTODataGridViewTextBoxColumn.Width = 35;
            // 
            // tIPODOCUMENTODataGridViewTextBoxColumn
            // 
            this.tIPODOCUMENTODataGridViewTextBoxColumn.DataPropertyName = "TIPO_DOCUMENTO";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tIPODOCUMENTODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.tIPODOCUMENTODataGridViewTextBoxColumn.HeaderText = "TD";
            this.tIPODOCUMENTODataGridViewTextBoxColumn.Name = "tIPODOCUMENTODataGridViewTextBoxColumn";
            this.tIPODOCUMENTODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODOCUMENTODataGridViewTextBoxColumn.Width = 30;
            // 
            // cANTIDADDataGridViewTextBoxColumn
            // 
            this.cANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.cANTIDADDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.cANTIDADDataGridViewTextBoxColumn.HeaderText = "KG In";
            this.cANTIDADDataGridViewTextBoxColumn.Name = "cANTIDADDataGridViewTextBoxColumn";
            this.cANTIDADDataGridViewTextBoxColumn.ReadOnly = true;
            this.cANTIDADDataGridViewTextBoxColumn.Width = 65;
            // 
            // bATCHDataGridViewTextBoxColumn
            // 
            this.bATCHDataGridViewTextBoxColumn.DataPropertyName = "BATCH";
            this.bATCHDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.bATCHDataGridViewTextBoxColumn.Name = "bATCHDataGridViewTextBoxColumn";
            this.bATCHDataGridViewTextBoxColumn.ReadOnly = true;
            this.bATCHDataGridViewTextBoxColumn.Width = 80;
            // 
            // rECURSODataGridViewTextBoxColumn
            // 
            this.rECURSODataGridViewTextBoxColumn.DataPropertyName = "RECURSO";
            this.rECURSODataGridViewTextBoxColumn.HeaderText = "Rec#";
            this.rECURSODataGridViewTextBoxColumn.Name = "rECURSODataGridViewTextBoxColumn";
            this.rECURSODataGridViewTextBoxColumn.ReadOnly = true;
            this.rECURSODataGridViewTextBoxColumn.Width = 40;
            // 
            // lOGUSERDataGridViewTextBoxColumn
            // 
            this.lOGUSERDataGridViewTextBoxColumn.DataPropertyName = "LOG_USER";
            this.lOGUSERDataGridViewTextBoxColumn.HeaderText = "UserIN";
            this.lOGUSERDataGridViewTextBoxColumn.Name = "lOGUSERDataGridViewTextBoxColumn";
            this.lOGUSERDataGridViewTextBoxColumn.ReadOnly = true;
            this.lOGUSERDataGridViewTextBoxColumn.Width = 70;
            // 
            // lOGDATEDataGridViewTextBoxColumn
            // 
            this.lOGDATEDataGridViewTextBoxColumn.DataPropertyName = "LOG_DATE";
            dataGridViewCellStyle8.Format = "g";
            dataGridViewCellStyle8.NullValue = null;
            this.lOGDATEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.lOGDATEDataGridViewTextBoxColumn.HeaderText = "FechaIN";
            this.lOGDATEDataGridViewTextBoxColumn.Name = "lOGDATEDataGridViewTextBoxColumn";
            this.lOGDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.lOGDATEDataGridViewTextBoxColumn.Width = 95;
            // 
            // cOMENTARIODataGridViewTextBoxColumn
            // 
            this.cOMENTARIODataGridViewTextBoxColumn.DataPropertyName = "COMENTARIO";
            this.cOMENTARIODataGridViewTextBoxColumn.HeaderText = "Observacion";
            this.cOMENTARIODataGridViewTextBoxColumn.Name = "cOMENTARIODataGridViewTextBoxColumn";
            this.cOMENTARIODataGridViewTextBoxColumn.ReadOnly = true;
            this.cOMENTARIODataGridViewTextBoxColumn.Width = 135;
            // 
            // dgvBtnReversar
            // 
            this.dgvBtnReversar.HeaderText = "Reversar";
            this.dgvBtnReversar.Name = "dgvBtnReversar";
            this.dgvBtnReversar.ReadOnly = true;
            this.dgvBtnReversar.Text = "Reversar";
            this.dgvBtnReversar.ToolTipText = "Reversar el Ingreso Temporal";
            this.dgvBtnReversar.UseColumnTextForButtonValue = true;
            this.dgvBtnReversar.Width = 60;
            // 
            // t0040MATMOVIMIENTOSBindingSource
            // 
            this.t0040MATMOVIMIENTOSBindingSource.DataSource = typeof(TecserEF.Entity.T0040_MAT_MOVIMIENTOS);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Purple;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Tomato;
            this.label9.Location = new System.Drawing.Point(4, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(822, 18);
            this.label9.TabIndex = 45;
            this.label9.Text = "DETALLE DE INGRESOS DE PRODUCCION";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPP09IngresoTemporal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 473);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtObservacionIngreso);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.btnIngresoTemporal);
            this.Controls.Add(this.btnExit);
            this.Name = "FrmPP09IngresoTemporal";
            this.Text = "PP09 * INGRESO PRODUCCION TEMPORAL";
            this.Load += new System.EventHandler(this.FrmIngresoProduccionTemporal_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0029ESTADOSTOCKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0032RECURSOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleIngreso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0040MATMOVIMIENTOSBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresoTemporal;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtNumeroOF;
        private System.Windows.Forms.TextBox txtMaterialFabricado;
        private System.Windows.Forms.TextBox txtKgingresados;
        private System.Windows.Forms.TextBox txtEstadoOF;
        private System.Windows.Forms.TextBox txtMaterialEtiqueta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKgIngresar;
        private System.Windows.Forms.Button btnAyer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroLote;
        private System.Windows.Forms.ComboBox cmbEstadoLote;
        private System.Windows.Forms.ComboBox cmbRecurso;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbOperador;
        private System.Windows.Forms.ComboBox cmbSloc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaIngresoProduccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtObservacionIngreso;
        private System.Windows.Forms.BindingSource t0032RECURSOSBindingSource;
        private System.Windows.Forms.BindingSource t0028SLOCBindingSource;
        private System.Windows.Forms.BindingSource t0029ESTADOSTOCKBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDetalleIngreso;
        private System.Windows.Forms.BindingSource t0040MATMOVIMIENTOSBindingSource;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn __idmovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHAMOVDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPOMOVIMIENTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODOCUMENTODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cANTIDADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bATCHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rECURSODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOGUSERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lOGDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMENTARIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn dgvBtnReversar;
    }
}