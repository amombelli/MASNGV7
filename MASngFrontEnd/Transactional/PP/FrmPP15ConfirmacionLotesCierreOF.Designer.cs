namespace MASngFE.Transactional.PP
{
    partial class FrmPP15ConfirmacionLotesCierreOF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP15ConfirmacionLotesCierreOF));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFormulaDescontar = new System.Windows.Forms.DataGridView();
            this.t0072FORMULATEMPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.t0030STOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtNumeroOF = new System.Windows.Forms.TextBox();
            this.txtMaterialFabricado = new System.Windows.Forms.TextBox();
            this.txtMaterialEtiqueta = new System.Windows.Forms.TextBox();
            this.btnCancelarDescuento = new System.Windows.Forms.Button();
            this.btnConfirmarDescuento = new System.Windows.Forms.Button();
            this.t0010ContainerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.btnVerReservasStock = new System.Windows.Forms.Button();
            this.ckVerSoloStockDescuento = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtTotalInsumos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalMerma = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalMPConsumida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalKgFabricados = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.@__material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__kg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__statusstock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idStockReservadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__added = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulaDescontar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072FORMULATEMPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010ContainerBindingSource)).BeginInit();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFormulaDescontar
            // 
            this.dgvFormulaDescontar.AllowUserToAddRows = false;
            this.dgvFormulaDescontar.AllowUserToDeleteRows = false;
            this.dgvFormulaDescontar.AutoGenerateColumns = false;
            this.dgvFormulaDescontar.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFormulaDescontar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFormulaDescontar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormulaDescontar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__material,
            this.@__kg,
            this.batchNumberDataGridViewTextBoxColumn,
            this.@__statusstock,
            this.idStockReservadoDataGridViewTextBoxColumn,
            this.@__added});
            this.dgvFormulaDescontar.DataSource = this.t0072FORMULATEMPBindingSource;
            this.dgvFormulaDescontar.GridColor = System.Drawing.Color.Gray;
            this.dgvFormulaDescontar.Location = new System.Drawing.Point(10, 93);
            this.dgvFormulaDescontar.MultiSelect = false;
            this.dgvFormulaDescontar.Name = "dgvFormulaDescontar";
            this.dgvFormulaDescontar.ReadOnly = true;
            this.dgvFormulaDescontar.RowHeadersWidth = 20;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFormulaDescontar.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFormulaDescontar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormulaDescontar.Size = new System.Drawing.Size(526, 359);
            this.dgvFormulaDescontar.TabIndex = 3;
            this.dgvFormulaDescontar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulaDescontar_CellContentClick);
            // 
            // t0072FORMULATEMPBindingSource
            // 
            this.t0072FORMULATEMPBindingSource.DataSource = typeof(TecserEF.Entity.T0072_FORMULA_TEMP);
            // 
            // t0030STOCKBindingSource
            // 
            this.t0030STOCKBindingSource.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label30);
            this.panel6.Controls.Add(this.label29);
            this.panel6.Controls.Add(this.txtNumeroOF);
            this.panel6.Controls.Add(this.txtMaterialFabricado);
            this.panel6.Controls.Add(this.txtMaterialEtiqueta);
            this.panel6.Location = new System.Drawing.Point(10, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(526, 69);
            this.panel6.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "ETIQUETA";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(177, 10);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(89, 20);
            this.label30.TabIndex = 2;
            this.label30.Text = "PRIMARIO";
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
            // btnCancelarDescuento
            // 
            this.btnCancelarDescuento.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnCancelarDescuento.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnCancelarDescuento.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarDescuento.Image")));
            this.btnCancelarDescuento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarDescuento.Location = new System.Drawing.Point(426, 504);
            this.btnCancelarDescuento.Name = "btnCancelarDescuento";
            this.btnCancelarDescuento.Size = new System.Drawing.Size(100, 40);
            this.btnCancelarDescuento.TabIndex = 31;
            this.btnCancelarDescuento.Text = "CANCELAR\r\nDescuento";
            this.btnCancelarDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarDescuento.UseVisualStyleBackColor = true;
            this.btnCancelarDescuento.Click += new System.EventHandler(this.btnCancelarDescuento_Click);
            // 
            // btnConfirmarDescuento
            // 
            this.btnConfirmarDescuento.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnConfirmarDescuento.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnConfirmarDescuento.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmarDescuento.Image")));
            this.btnConfirmarDescuento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarDescuento.Location = new System.Drawing.Point(426, 463);
            this.btnConfirmarDescuento.Name = "btnConfirmarDescuento";
            this.btnConfirmarDescuento.Size = new System.Drawing.Size(100, 40);
            this.btnConfirmarDescuento.TabIndex = 15;
            this.btnConfirmarDescuento.Text = "CONFIRMAR\r\nDescuento";
            this.btnConfirmarDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarDescuento.UseVisualStyleBackColor = true;
            this.btnConfirmarDescuento.Click += new System.EventHandler(this.btnConfirmarDescuento_Click);
            // 
            // t0010ContainerBindingSource
            // 
            this.t0010ContainerBindingSource.DataSource = typeof(TecserEF.Entity.T0010_Container);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(10, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(526, 18);
            this.label6.TabIndex = 41;
            this.label6.Text = "CONFIRMACION DE MATERIA PRIMA-LOTE A DESCONTAR";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVerReservasStock
            // 
            this.btnVerReservasStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerReservasStock.Image = ((System.Drawing.Image)(resources.GetObject("btnVerReservasStock.Image")));
            this.btnVerReservasStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerReservasStock.Location = new System.Drawing.Point(426, 545);
            this.btnVerReservasStock.Name = "btnVerReservasStock";
            this.btnVerReservasStock.Size = new System.Drawing.Size(100, 40);
            this.btnVerReservasStock.TabIndex = 88;
            this.btnVerReservasStock.Text = "Ver\r\nReservas";
            this.btnVerReservasStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerReservasStock.UseVisualStyleBackColor = true;
            // 
            // ckVerSoloStockDescuento
            // 
            this.ckVerSoloStockDescuento.AutoSize = true;
            this.ckVerSoloStockDescuento.Location = new System.Drawing.Point(10, 574);
            this.ckVerSoloStockDescuento.Name = "ckVerSoloStockDescuento";
            this.ckVerSoloStockDescuento.Size = new System.Drawing.Size(228, 17);
            this.ckVerSoloStockDescuento.TabIndex = 89;
            this.ckVerSoloStockDescuento.Text = "VER SOLO STOCK A DESCONTAR (LINEAS > 0Kg)";
            this.ckVerSoloStockDescuento.UseVisualStyleBackColor = true;
            this.ckVerSoloStockDescuento.CheckedChanged += new System.EventHandler(this.ckVerSoloStockDescuento_CheckedChanged);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel10.Controls.Add(this.txtTotalInsumos);
            this.panel10.Controls.Add(this.label8);
            this.panel10.Controls.Add(this.txtTotalMerma);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Controls.Add(this.txtTotalMPConsumida);
            this.panel10.Controls.Add(this.label2);
            this.panel10.Controls.Add(this.txtTotalKgFabricados);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Location = new System.Drawing.Point(10, 459);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(249, 109);
            this.panel10.TabIndex = 90;
            // 
            // txtTotalInsumos
            // 
            this.txtTotalInsumos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTotalInsumos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalInsumos.ForeColor = System.Drawing.Color.Crimson;
            this.txtTotalInsumos.Location = new System.Drawing.Point(122, 79);
            this.txtTotalInsumos.Name = "txtTotalInsumos";
            this.txtTotalInsumos.ReadOnly = true;
            this.txtTotalInsumos.Size = new System.Drawing.Size(64, 21);
            this.txtTotalInsumos.TabIndex = 82;
            this.txtTotalInsumos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 81;
            this.label8.Text = "Total Insumos ";
            // 
            // txtTotalMerma
            // 
            this.txtTotalMerma.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTotalMerma.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMerma.ForeColor = System.Drawing.Color.Crimson;
            this.txtTotalMerma.Location = new System.Drawing.Point(122, 48);
            this.txtTotalMerma.Name = "txtTotalMerma";
            this.txtTotalMerma.ReadOnly = true;
            this.txtTotalMerma.Size = new System.Drawing.Size(64, 21);
            this.txtTotalMerma.TabIndex = 80;
            this.txtTotalMerma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 79;
            this.label7.Text = "Total Merma %";
            // 
            // txtTotalMPConsumida
            // 
            this.txtTotalMPConsumida.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTotalMPConsumida.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMPConsumida.ForeColor = System.Drawing.Color.Crimson;
            this.txtTotalMPConsumida.Location = new System.Drawing.Point(122, 26);
            this.txtTotalMPConsumida.Name = "txtTotalMPConsumida";
            this.txtTotalMPConsumida.ReadOnly = true;
            this.txtTotalMPConsumida.Size = new System.Drawing.Size(64, 21);
            this.txtTotalMPConsumida.TabIndex = 78;
            this.txtTotalMPConsumida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 77;
            this.label2.Text = "Total MP Consumida";
            // 
            // txtTotalKgFabricados
            // 
            this.txtTotalKgFabricados.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTotalKgFabricados.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalKgFabricados.ForeColor = System.Drawing.Color.Crimson;
            this.txtTotalKgFabricados.Location = new System.Drawing.Point(122, 4);
            this.txtTotalKgFabricados.Name = "txtTotalKgFabricados";
            this.txtTotalKgFabricados.ReadOnly = true;
            this.txtTotalKgFabricados.Size = new System.Drawing.Size(64, 21);
            this.txtTotalKgFabricados.TabIndex = 76;
            this.txtTotalKgFabricados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Total KG Fabricados";
            // 
            // __material
            // 
            this.@__material.DataPropertyName = "Primario";
            this.@__material.HeaderText = "Material";
            this.@__material.Name = "__material";
            this.@__material.ReadOnly = true;
            this.@__material.Width = 120;
            // 
            // __kg
            // 
            this.@__kg.DataPropertyName = "CantidadKGReal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Format = "N2";
            this.@__kg.DefaultCellStyle = dataGridViewCellStyle2;
            this.@__kg.HeaderText = "Kg";
            this.@__kg.Name = "__kg";
            this.@__kg.ReadOnly = true;
            this.@__kg.Width = 60;
            // 
            // batchNumberDataGridViewTextBoxColumn
            // 
            this.batchNumberDataGridViewTextBoxColumn.DataPropertyName = "BatchNumber";
            this.batchNumberDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.batchNumberDataGridViewTextBoxColumn.Name = "batchNumberDataGridViewTextBoxColumn";
            this.batchNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // __statusstock
            // 
            this.@__statusstock.DataPropertyName = "StatusStock";
            this.@__statusstock.HeaderText = "Status Stock";
            this.@__statusstock.Name = "__statusstock";
            this.@__statusstock.ReadOnly = true;
            // 
            // idStockReservadoDataGridViewTextBoxColumn
            // 
            this.idStockReservadoDataGridViewTextBoxColumn.DataPropertyName = "idStockReservado";
            this.idStockReservadoDataGridViewTextBoxColumn.HeaderText = "IdStock";
            this.idStockReservadoDataGridViewTextBoxColumn.Name = "idStockReservadoDataGridViewTextBoxColumn";
            this.idStockReservadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idStockReservadoDataGridViewTextBoxColumn.Width = 50;
            // 
            // __added
            // 
            this.@__added.DataPropertyName = "Added";
            this.@__added.HeaderText = "Added";
            this.@__added.Name = "__added";
            this.@__added.ReadOnly = true;
            this.@__added.Width = 60;
            // 
            // FrmPP15ConfirmacionLotesCierreOF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 593);
            this.ControlBox = false;
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.ckVerSoloStockDescuento);
            this.Controls.Add(this.btnVerReservasStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.dgvFormulaDescontar);
            this.Controls.Add(this.btnConfirmarDescuento);
            this.Controls.Add(this.btnCancelarDescuento);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPP15ConfirmacionLotesCierreOF";
            this.Text = "PP15 - Confirmacion de Lotes P/Cierre OF";
            this.Load += new System.EventHandler(this.FrmConfirmacionDescuentoStockOF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulaDescontar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072FORMULATEMPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010ContainerBindingSource)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFormulaDescontar;
        private System.Windows.Forms.BindingSource t0072FORMULATEMPBindingSource;
        private System.Windows.Forms.BindingSource t0030STOCKBindingSource;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtNumeroOF;
        private System.Windows.Forms.TextBox txtMaterialFabricado;
        private System.Windows.Forms.TextBox txtMaterialEtiqueta;
        private System.Windows.Forms.Button btnCancelarDescuento;
        private System.Windows.Forms.Button btnConfirmarDescuento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource t0010ContainerBindingSource;
        private System.Windows.Forms.Button btnVerReservasStock;
        private System.Windows.Forms.CheckBox ckVerSoloStockDescuento;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txtTotalInsumos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalMerma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalMPConsumida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalKgFabricados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn __material;
        private System.Windows.Forms.DataGridViewTextBoxColumn __kg;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn __statusstock;
        private System.Windows.Forms.DataGridViewTextBoxColumn idStockReservadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn __added;
    }
}