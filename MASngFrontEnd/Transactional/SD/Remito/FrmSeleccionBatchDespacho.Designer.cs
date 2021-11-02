namespace MASngFE.Transactional.SD.Remito
{
    partial class FrmSD12SeleccionBatchDespacho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSD12SeleccionBatchDespacho));
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.t0030StockBs = new System.Windows.Forms.BindingSource(this.components);
            this.txtPrimario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.txtKGSeleccion = new System.Windows.Forms.TextBox();
            this.ckVerTodoStock = new System.Windows.Forms.CheckBox();
            this.txtIdStockSeleccionado = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaterialRequerido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKgMaximo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ctlKgDespachar = new TSControls.CtlTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.@__idstock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__kg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__sloc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__reservadoOv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030StockBs)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AutoGenerateColumns = false;
            this.dgvStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__idstock,
            this.@__material,
            this.@__lote,
            this.@__kg,
            this.@__estado,
            this.@__sloc,
            this.@__reservadoOv});
            this.dgvStock.DataSource = this.t0030StockBs;
            this.dgvStock.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dgvStock.Location = new System.Drawing.Point(8, 89);
            this.dgvStock.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersWidth = 20;
            this.dgvStock.RowTemplate.Height = 24;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(533, 298);
            this.dgvStock.TabIndex = 0;
            this.dgvStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            this.dgvStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellContentClick);
            // 
            // t0030StockBs
            // 
            this.t0030StockBs.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // txtPrimario
            // 
            this.txtPrimario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPrimario.Location = new System.Drawing.Point(119, 29);
            this.txtPrimario.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrimario.Name = "txtPrimario";
            this.txtPrimario.ReadOnly = true;
            this.txtPrimario.Size = new System.Drawing.Size(142, 23);
            this.txtPrimario.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lote Seleccionado";
            // 
            // txtLote
            // 
            this.txtLote.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtLote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLote.Location = new System.Drawing.Point(127, 5);
            this.txtLote.Margin = new System.Windows.Forms.Padding(2);
            this.txtLote.Name = "txtLote";
            this.txtLote.ReadOnly = true;
            this.txtLote.Size = new System.Drawing.Size(142, 23);
            this.txtLote.TabIndex = 3;
            // 
            // txtKGSeleccion
            // 
            this.txtKGSeleccion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKGSeleccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKGSeleccion.Location = new System.Drawing.Point(127, 30);
            this.txtKGSeleccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtKGSeleccion.Name = "txtKGSeleccion";
            this.txtKGSeleccion.ReadOnly = true;
            this.txtKGSeleccion.Size = new System.Drawing.Size(89, 23);
            this.txtKGSeleccion.TabIndex = 7;
            this.txtKGSeleccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ckVerTodoStock
            // 
            this.ckVerTodoStock.AutoSize = true;
            this.ckVerTodoStock.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.ckVerTodoStock.Location = new System.Drawing.Point(338, 8);
            this.ckVerTodoStock.Margin = new System.Windows.Forms.Padding(2);
            this.ckVerTodoStock.Name = "ckVerTodoStock";
            this.ckVerTodoStock.Size = new System.Drawing.Size(114, 17);
            this.ckVerTodoStock.TabIndex = 11;
            this.ckVerTodoStock.Text = "VER TODO EL STOCK";
            this.ckVerTodoStock.UseVisualStyleBackColor = true;
            this.ckVerTodoStock.CheckedChanged += new System.EventHandler(this.ckVerTodoStock_CheckedChanged);
            // 
            // txtIdStockSeleccionado
            // 
            this.txtIdStockSeleccionado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdStockSeleccionado.Location = new System.Drawing.Point(468, 5);
            this.txtIdStockSeleccionado.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdStockSeleccionado.Name = "txtIdStockSeleccionado";
            this.txtIdStockSeleccionado.ReadOnly = true;
            this.txtIdStockSeleccionado.Size = new System.Drawing.Size(60, 23);
            this.txtIdStockSeleccionado.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtIdStockSeleccionado);
            this.panel1.Controls.Add(this.ctlKgDespachar);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtKgMaximo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLote);
            this.panel1.Controls.Add(this.txtKGSeleccion);
            this.panel1.Location = new System.Drawing.Point(8, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 107);
            this.panel1.TabIndex = 15;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(2, 2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(3, 497);
            this.label17.TabIndex = 275;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Crimson;
            this.label18.Location = new System.Drawing.Point(2, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(663, 3);
            this.label18.TabIndex = 274;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtCantidad);
            this.panel2.Controls.Add(this.txtMaterialRequerido);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtPrimario);
            this.panel2.Controls.Add(this.ckVerTodoStock);
            this.panel2.Location = new System.Drawing.Point(7, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 80);
            this.panel2.TabIndex = 276;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Material Requerido";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Material Primario";
            // 
            // txtMaterialRequerido
            // 
            this.txtMaterialRequerido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMaterialRequerido.Location = new System.Drawing.Point(119, 4);
            this.txtMaterialRequerido.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaterialRequerido.Name = "txtMaterialRequerido";
            this.txtMaterialRequerido.ReadOnly = true;
            this.txtMaterialRequerido.Size = new System.Drawing.Size(142, 23);
            this.txtMaterialRequerido.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "KG Requerido";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCantidad.Location = new System.Drawing.Point(119, 54);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.ReadOnly = true;
            this.txtCantidad.Size = new System.Drawing.Size(83, 23);
            this.txtCantidad.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kg Seleccion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(52, 59);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Kg Maximo";
            // 
            // txtKgMaximo
            // 
            this.txtKgMaximo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtKgMaximo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgMaximo.Location = new System.Drawing.Point(127, 55);
            this.txtKgMaximo.Margin = new System.Windows.Forms.Padding(2);
            this.txtKgMaximo.Name = "txtKgMaximo";
            this.txtKgMaximo.ReadOnly = true;
            this.txtKgMaximo.Size = new System.Drawing.Size(89, 23);
            this.txtKgMaximo.TabIndex = 9;
            this.txtKgMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(17, 83);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "Kg A Despachar";
            // 
            // ctlKgDespachar
            // 
            this.ctlKgDespachar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlKgDespachar.BackColor = System.Drawing.Color.White;
            this.ctlKgDespachar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlKgDespachar.Location = new System.Drawing.Point(127, 80);
            this.ctlKgDespachar.Margin = new System.Windows.Forms.Padding(0);
            this.ctlKgDespachar.Name = "ctlKgDespachar";
            this.ctlKgDespachar.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlKgDespachar.SetDecimales = 2;
            this.ctlKgDespachar.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.ctlKgDespachar.Size = new System.Drawing.Size(89, 21);
            this.ctlKgDespachar.TabIndex = 11;
            this.ctlKgDespachar.ValorMaximo = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.ctlKgDespachar.ValorMinimo = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ctlKgDespachar.XReadOnly = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(5, 496);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(660, 3);
            this.label3.TabIndex = 277;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(359, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "ID Stock Seleccion";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(662, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(3, 497);
            this.label5.TabIndex = 278;
            // 
            // __idstock
            // 
            this.@__idstock.DataPropertyName = "IDStock";
            this.@__idstock.HeaderText = "IDStock";
            this.@__idstock.Name = "__idstock";
            this.@__idstock.ReadOnly = true;
            this.@__idstock.Visible = false;
            // 
            // __material
            // 
            this.@__material.DataPropertyName = "Material";
            this.@__material.HeaderText = "MATERIAL";
            this.@__material.Name = "__material";
            this.@__material.ReadOnly = true;
            this.@__material.Width = 150;
            // 
            // __lote
            // 
            this.@__lote.DataPropertyName = "Batch";
            this.@__lote.HeaderText = "LOTE";
            this.@__lote.Name = "__lote";
            this.@__lote.ReadOnly = true;
            // 
            // __kg
            // 
            this.@__kg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.@__kg.DataPropertyName = "Stock";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.@__kg.DefaultCellStyle = dataGridViewCellStyle1;
            this.@__kg.HeaderText = "KG STK";
            this.@__kg.Name = "__kg";
            this.@__kg.ReadOnly = true;
            this.@__kg.Width = 68;
            // 
            // __estado
            // 
            this.@__estado.DataPropertyName = "Estado";
            this.@__estado.HeaderText = "ESTADO";
            this.@__estado.Name = "__estado";
            this.@__estado.ReadOnly = true;
            // 
            // __sloc
            // 
            this.@__sloc.DataPropertyName = "SLOC";
            this.@__sloc.HeaderText = "SLOC";
            this.@__sloc.Name = "__sloc";
            this.@__sloc.ReadOnly = true;
            this.@__sloc.Width = 80;
            // 
            // __reservadoOv
            // 
            this.@__reservadoOv.DataPropertyName = "OV_Reserva";
            this.@__reservadoOv.HeaderText = "RESERVA OV";
            this.@__reservadoOv.Name = "__reservadoOv";
            this.@__reservadoOv.ReadOnly = true;
            this.@__reservadoOv.Visible = false;
            this.@__reservadoOv.Width = 150;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(543, 7);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 45);
            this.btnClose.TabIndex = 279;
            this.btnClose.Text = "Salir";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(411, 58);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(117, 45);
            this.btnSelect.TabIndex = 280;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // FrmSD12SeleccionBatchDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(668, 502);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvStock);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmSD12SeleccionBatchDespacho";
            this.Text = "SD12 - Seleccion de Kg a Despachar y Lote#";
            this.Load += new System.EventHandler(this.FrmSeleccionBatchDespacho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030StockBs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.BindingSource t0030StockBs;
        private System.Windows.Forms.TextBox txtPrimario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.TextBox txtKGSeleccion;
        private System.Windows.Forms.CheckBox ckVerTodoStock;
        private System.Windows.Forms.TextBox txtIdStockSeleccionado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private TSControls.CtlTextBox ctlKgDespachar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtKgMaximo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtMaterialRequerido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn __idstock;
        private System.Windows.Forms.DataGridViewTextBoxColumn __material;
        private System.Windows.Forms.DataGridViewTextBoxColumn __lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn __kg;
        private System.Windows.Forms.DataGridViewTextBoxColumn __estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn __sloc;
        private System.Windows.Forms.DataGridViewTextBoxColumn __reservadoOv;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
    }
}