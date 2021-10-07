namespace MASngFE.Transactional.PP
{
    partial class FrmPP30CalculoBOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP30CalculoBOM));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ckSoloFormulaActiva = new System.Windows.Forms.CheckBox();
            this.txtUltimaUtilizacion = new System.Windows.Forms.TextBox();
            this.cmbFormulas = new System.Windows.Forms.ComboBox();
            this.t0020Bs = new System.Windows.Forms.BindingSource(this.components);
            this.label39 = new System.Windows.Forms.Label();
            this.txtNumeroFormula = new System.Windows.Forms.TextBox();
            this.txtMaterialPrimario = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnImprimirFormula = new System.Windows.Forms.Button();
            this.dgvFormula = new System.Windows.Forms.DataGridView();
            this.idItemFormulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__cantidadPor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__kgReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__porcentajeReal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__Added = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.@__Recalculo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.t0072Bs = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtKg = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAddedKg = new System.Windows.Forms.TextBox();
            this.txtAddedProp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregarItemAdicional = new System.Windows.Forms.Button();
            this.txtDescripcionMaterialAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbProporcion = new System.Windows.Forms.RadioButton();
            this.rbFijo = new System.Windows.Forms.RadioButton();
            this.cmbPrimarioAdd = new System.Windows.Forms.ComboBox();
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnUtilizarReemplazo = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0020Bs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072Bs)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.Controls.Add(this.ckSoloFormulaActiva);
            this.panel6.Controls.Add(this.txtUltimaUtilizacion);
            this.panel6.Controls.Add(this.cmbFormulas);
            this.panel6.Controls.Add(this.label39);
            this.panel6.Controls.Add(this.txtNumeroFormula);
            this.panel6.Controls.Add(this.txtMaterialPrimario);
            this.panel6.Controls.Add(this.label38);
            this.panel6.Location = new System.Drawing.Point(2, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(635, 64);
            this.panel6.TabIndex = 56;
            // 
            // ckSoloFormulaActiva
            // 
            this.ckSoloFormulaActiva.AutoSize = true;
            this.ckSoloFormulaActiva.Location = new System.Drawing.Point(460, 8);
            this.ckSoloFormulaActiva.Name = "ckSoloFormulaActiva";
            this.ckSoloFormulaActiva.Size = new System.Drawing.Size(165, 17);
            this.ckSoloFormulaActiva.TabIndex = 24;
            this.ckSoloFormulaActiva.Text = "SOLO FORMULAS ACTIVAS";
            this.ckSoloFormulaActiva.UseVisualStyleBackColor = true;
            // 
            // txtUltimaUtilizacion
            // 
            this.txtUltimaUtilizacion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtUltimaUtilizacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUltimaUtilizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUltimaUtilizacion.Location = new System.Drawing.Point(450, 32);
            this.txtUltimaUtilizacion.Name = "txtUltimaUtilizacion";
            this.txtUltimaUtilizacion.ReadOnly = true;
            this.txtUltimaUtilizacion.Size = new System.Drawing.Size(175, 19);
            this.txtUltimaUtilizacion.TabIndex = 58;
            this.txtUltimaUtilizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbFormulas
            // 
            this.cmbFormulas.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbFormulas.DataSource = this.t0020Bs;
            this.cmbFormulas.DisplayMember = "DESC_FORMULA";
            this.cmbFormulas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFormulas.FormattingEnabled = true;
            this.cmbFormulas.Location = new System.Drawing.Point(104, 31);
            this.cmbFormulas.Name = "cmbFormulas";
            this.cmbFormulas.Size = new System.Drawing.Size(269, 21);
            this.cmbFormulas.TabIndex = 57;
            this.cmbFormulas.ValueMember = "ID_FORMULA";
            this.cmbFormulas.SelectedIndexChanged += new System.EventHandler(this.cmbFormulas_SelectedIndexChanged);
            // 
            // t0020Bs
            // 
            this.t0020Bs.DataSource = typeof(TecserEF.Entity.T0020_FORMULA_H);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(9, 6);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(89, 20);
            this.label39.TabIndex = 2;
            this.label39.Text = "PRIMARIO";
            // 
            // txtNumeroFormula
            // 
            this.txtNumeroFormula.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNumeroFormula.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroFormula.Location = new System.Drawing.Point(376, 32);
            this.txtNumeroFormula.Name = "txtNumeroFormula";
            this.txtNumeroFormula.ReadOnly = true;
            this.txtNumeroFormula.Size = new System.Drawing.Size(70, 19);
            this.txtNumeroFormula.TabIndex = 23;
            this.txtNumeroFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaterialPrimario
            // 
            this.txtMaterialPrimario.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaterialPrimario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterialPrimario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialPrimario.Location = new System.Drawing.Point(104, 7);
            this.txtMaterialPrimario.Name = "txtMaterialPrimario";
            this.txtMaterialPrimario.ReadOnly = true;
            this.txtMaterialPrimario.Size = new System.Drawing.Size(207, 19);
            this.txtMaterialPrimario.TabIndex = 1;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(9, 29);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 20);
            this.label38.TabIndex = 6;
            this.label38.Text = "FORM#";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(514, 112);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 58;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnImprimirFormula
            // 
            this.btnImprimirFormula.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.btnImprimirFormula.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirFormula.Image")));
            this.btnImprimirFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirFormula.Location = new System.Drawing.Point(514, 153);
            this.btnImprimirFormula.Name = "btnImprimirFormula";
            this.btnImprimirFormula.Size = new System.Drawing.Size(100, 40);
            this.btnImprimirFormula.TabIndex = 57;
            this.btnImprimirFormula.Text = "IMPRIMIR FORMULA";
            this.btnImprimirFormula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimirFormula.UseVisualStyleBackColor = true;
            this.btnImprimirFormula.Click += new System.EventHandler(this.btnImprimirFormula_Click);
            // 
            // dgvFormula
            // 
            this.dgvFormula.AllowUserToAddRows = false;
            this.dgvFormula.AllowUserToDeleteRows = false;
            this.dgvFormula.AutoGenerateColumns = false;
            this.dgvFormula.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormula.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItemFormulaDataGridViewTextBoxColumn,
            this.primarioDataGridViewTextBoxColumn,
            this.@__cantidadPor,
            this.@__kgReal,
            this.@__porcentajeReal,
            this.@__Added,
            this.@__Recalculo});
            this.dgvFormula.DataSource = this.t0072Bs;
            this.dgvFormula.Location = new System.Drawing.Point(2, 112);
            this.dgvFormula.Name = "dgvFormula";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFormula.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFormula.RowHeadersWidth = 30;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFormula.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFormula.Size = new System.Drawing.Size(444, 302);
            this.dgvFormula.TabIndex = 59;
            this.dgvFormula.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormula_CellEndEdit);
            this.dgvFormula.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvFormula_EditingControlShowing);
            // 
            // idItemFormulaDataGridViewTextBoxColumn
            // 
            this.idItemFormulaDataGridViewTextBoxColumn.DataPropertyName = "idItemFormula";
            this.idItemFormulaDataGridViewTextBoxColumn.HeaderText = "#";
            this.idItemFormulaDataGridViewTextBoxColumn.Name = "idItemFormulaDataGridViewTextBoxColumn";
            this.idItemFormulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idItemFormulaDataGridViewTextBoxColumn.Width = 30;
            // 
            // primarioDataGridViewTextBoxColumn
            // 
            this.primarioDataGridViewTextBoxColumn.DataPropertyName = "Primario";
            this.primarioDataGridViewTextBoxColumn.HeaderText = "Primario";
            this.primarioDataGridViewTextBoxColumn.Name = "primarioDataGridViewTextBoxColumn";
            this.primarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.primarioDataGridViewTextBoxColumn.Width = 120;
            // 
            // __cantidadPor
            // 
            this.@__cantidadPor.DataPropertyName = "CantidadPor";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "P2";
            dataGridViewCellStyle1.NullValue = "0";
            this.@__cantidadPor.DefaultCellStyle = dataGridViewCellStyle1;
            this.@__cantidadPor.HeaderText = "Base%";
            this.@__cantidadPor.Name = "__cantidadPor";
            this.@__cantidadPor.ReadOnly = true;
            this.@__cantidadPor.Width = 50;
            // 
            // __kgReal
            // 
            this.@__kgReal.DataPropertyName = "CantidadKGReal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.@__kgReal.DefaultCellStyle = dataGridViewCellStyle2;
            this.@__kgReal.HeaderText = "FormKg";
            this.@__kgReal.Name = "__kgReal";
            this.@__kgReal.Width = 60;
            // 
            // __porcentajeReal
            // 
            this.@__porcentajeReal.DataPropertyName = "CantidadPorReal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "P2";
            dataGridViewCellStyle3.NullValue = "0";
            this.@__porcentajeReal.DefaultCellStyle = dataGridViewCellStyle3;
            this.@__porcentajeReal.HeaderText = "%Real";
            this.@__porcentajeReal.Name = "__porcentajeReal";
            this.@__porcentajeReal.ReadOnly = true;
            this.@__porcentajeReal.Width = 60;
            // 
            // __Added
            // 
            this.@__Added.DataPropertyName = "Added";
            this.@__Added.HeaderText = "[+]";
            this.@__Added.Name = "__Added";
            this.@__Added.ReadOnly = true;
            this.@__Added.Width = 30;
            // 
            // __Recalculo
            // 
            this.@__Recalculo.DataPropertyName = "Recalculo";
            this.@__Recalculo.HeaderText = "[!]";
            this.@__Recalculo.Name = "__Recalculo";
            this.@__Recalculo.ReadOnly = true;
            this.@__Recalculo.Width = 30;
            // 
            // t0072Bs
            // 
            this.t0072Bs.DataSource = typeof(TecserEF.Entity.T0072_FORMULA_TEMP);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "KG Totales";
            // 
            // txtKg
            // 
            this.txtKg.BackColor = System.Drawing.Color.White;
            this.txtKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKg.Location = new System.Drawing.Point(107, 76);
            this.txtKg.Name = "txtKg";
            this.txtKg.Size = new System.Drawing.Size(75, 26);
            this.txtKg.TabIndex = 59;
            this.txtKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKg_KeyPress);
            this.txtKg.Leave += new System.EventHandler(this.txtKg_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtAddedKg);
            this.panel2.Controls.Add(this.txtAddedProp);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(285, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 62);
            this.panel2.TabIndex = 97;
            // 
            // txtAddedKg
            // 
            this.txtAddedKg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddedKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddedKg.ForeColor = System.Drawing.Color.Black;
            this.txtAddedKg.Location = new System.Drawing.Point(78, 7);
            this.txtAddedKg.Name = "txtAddedKg";
            this.txtAddedKg.Size = new System.Drawing.Size(60, 21);
            this.txtAddedKg.TabIndex = 80;
            this.txtAddedKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddedKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddedKg_KeyPress);
            // 
            // txtAddedProp
            // 
            this.txtAddedProp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddedProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddedProp.ForeColor = System.Drawing.Color.Black;
            this.txtAddedProp.Location = new System.Drawing.Point(78, 30);
            this.txtAddedProp.Name = "txtAddedProp";
            this.txtAddedProp.Size = new System.Drawing.Size(60, 21);
            this.txtAddedProp.TabIndex = 83;
            this.txtAddedProp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddedProp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddedKg_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 85;
            this.label6.Text = "KG";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 14);
            this.label7.TabIndex = 86;
            this.label7.Text = "% Formula";
            // 
            // btnAgregarItemAdicional
            // 
            this.btnAgregarItemAdicional.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarItemAdicional.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarItemAdicional.Image")));
            this.btnAgregarItemAdicional.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarItemAdicional.Location = new System.Drawing.Point(512, 67);
            this.btnAgregarItemAdicional.Name = "btnAgregarItemAdicional";
            this.btnAgregarItemAdicional.Size = new System.Drawing.Size(100, 40);
            this.btnAgregarItemAdicional.TabIndex = 96;
            this.btnAgregarItemAdicional.Text = "Agregar\r\nITEM";
            this.btnAgregarItemAdicional.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarItemAdicional.UseVisualStyleBackColor = true;
            this.btnAgregarItemAdicional.Click += new System.EventHandler(this.btnAgregarItemAdicional_Click);
            // 
            // txtDescripcionMaterialAdd
            // 
            this.txtDescripcionMaterialAdd.BackColor = System.Drawing.Color.LightGray;
            this.txtDescripcionMaterialAdd.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionMaterialAdd.ForeColor = System.Drawing.Color.Navy;
            this.txtDescripcionMaterialAdd.Location = new System.Drawing.Point(256, 12);
            this.txtDescripcionMaterialAdd.Name = "txtDescripcionMaterialAdd";
            this.txtDescripcionMaterialAdd.ReadOnly = true;
            this.txtDescripcionMaterialAdd.Size = new System.Drawing.Size(363, 21);
            this.txtDescripcionMaterialAdd.TabIndex = 92;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 95;
            this.label5.Text = "ITEM >>>>>";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Controls.Add(this.rbProporcion);
            this.groupBox1.Controls.Add(this.rbFijo);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 79);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modo";
            // 
            // rbProporcion
            // 
            this.rbProporcion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rbProporcion.Location = new System.Drawing.Point(7, 42);
            this.rbProporcion.Name = "rbProporcion";
            this.rbProporcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbProporcion.Size = new System.Drawing.Size(234, 21);
            this.rbProporcion.TabIndex = 1;
            this.rbProporcion.TabStop = true;
            this.rbProporcion.Text = "Valor Porcentual [%] - Con Recalculo";
            this.rbProporcion.UseVisualStyleBackColor = false;
            this.rbProporcion.CheckedChanged += new System.EventHandler(this.rbFijo_CheckedChanged);
            // 
            // rbFijo
            // 
            this.rbFijo.BackColor = System.Drawing.Color.LemonChiffon;
            this.rbFijo.Location = new System.Drawing.Point(7, 17);
            this.rbFijo.Name = "rbFijo";
            this.rbFijo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbFijo.Size = new System.Drawing.Size(234, 21);
            this.rbFijo.TabIndex = 0;
            this.rbFijo.TabStop = true;
            this.rbFijo.Text = "Valor Fijo - Sin Recalculo";
            this.rbFijo.UseVisualStyleBackColor = false;
            this.rbFijo.CheckedChanged += new System.EventHandler(this.rbFijo_CheckedChanged);
            // 
            // cmbPrimarioAdd
            // 
            this.cmbPrimarioAdd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPrimarioAdd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPrimarioAdd.DataSource = this.t0010MATERIALESBindingSource;
            this.cmbPrimarioAdd.DisplayMember = "IDMATERIAL";
            this.cmbPrimarioAdd.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrimarioAdd.FormattingEnabled = true;
            this.cmbPrimarioAdd.Location = new System.Drawing.Point(74, 12);
            this.cmbPrimarioAdd.Name = "cmbPrimarioAdd";
            this.cmbPrimarioAdd.Size = new System.Drawing.Size(176, 21);
            this.cmbPrimarioAdd.TabIndex = 90;
            this.cmbPrimarioAdd.ValueMember = "IDMATERIAL";
            this.cmbPrimarioAdd.SelectedIndexChanged += new System.EventHandler(this.cmbPrimarioAdd_SelectedIndexChanged);
            this.cmbPrimarioAdd.Enter += new System.EventHandler(this.cmbPrimarioAdd_Enter);
            this.cmbPrimarioAdd.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPrimarioAdd_Validating);
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btnAgregarItemAdicional);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cmbPrimarioAdd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtDescripcionMaterialAdd);
            this.panel1.Location = new System.Drawing.Point(2, 416);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 144);
            this.panel1.TabIndex = 98;
            // 
            // btnUtilizarReemplazo
            // 
            this.btnUtilizarReemplazo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtilizarReemplazo.Image = ((System.Drawing.Image)(resources.GetObject("btnUtilizarReemplazo.Image")));
            this.btnUtilizarReemplazo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilizarReemplazo.Location = new System.Drawing.Point(514, 194);
            this.btnUtilizarReemplazo.Name = "btnUtilizarReemplazo";
            this.btnUtilizarReemplazo.Size = new System.Drawing.Size(100, 40);
            this.btnUtilizarReemplazo.TabIndex = 99;
            this.btnUtilizarReemplazo.Text = "Utilizar\r\nReemplazo";
            this.btnUtilizarReemplazo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUtilizarReemplazo.UseVisualStyleBackColor = true;
            this.btnUtilizarReemplazo.Click += new System.EventHandler(this.btnUtilizarReemplazo_Click);
            // 
            // FrmPP30CalculoBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 591);
            this.Controls.Add(this.btnUtilizarReemplazo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKg);
            this.Controls.Add(this.dgvFormula);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnImprimirFormula);
            this.Controls.Add(this.panel6);
            this.Name = "FrmPP30CalculoBOM";
            this.Text = "PP06 Calculo Formulacion";
            this.Load += new System.EventHandler(this.FrmPP06CalculoInterpolacionFormulaKg_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0020Bs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0072Bs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbFormulas;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtNumeroFormula;
        private System.Windows.Forms.TextBox txtMaterialPrimario;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.CheckBox ckSoloFormulaActiva;
        private System.Windows.Forms.TextBox txtUltimaUtilizacion;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnImprimirFormula;
        private System.Windows.Forms.DataGridView dgvFormula;
        private System.Windows.Forms.BindingSource t0072Bs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKg;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemFormulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn __cantidadPor;
        private System.Windows.Forms.DataGridViewTextBoxColumn __kgReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn __porcentajeReal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn __Added;
        private System.Windows.Forms.DataGridViewCheckBoxColumn __Recalculo;
        private System.Windows.Forms.BindingSource t0020Bs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtAddedKg;
        private System.Windows.Forms.TextBox txtAddedProp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgregarItemAdicional;
        private System.Windows.Forms.TextBox txtDescripcionMaterialAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbProporcion;
        private System.Windows.Forms.RadioButton rbFijo;
        private System.Windows.Forms.ComboBox cmbPrimarioAdd;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnUtilizarReemplazo;
    }
}