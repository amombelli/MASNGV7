namespace MASngFE.Transactional.PP
{
    partial class FrmPP07SeleccionFormulaAFabricar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP07SeleccionFormulaAFabricar));
            this.BoMHeaderBs = new System.Windows.Forms.BindingSource(this.components);
            this.dgvFormulas = new System.Windows.Forms.DataGridView();
            this.iDFORMULADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCFORMULADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fORMVERSIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUsedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDetalleItems = new System.Windows.Forms.DataGridView();
            this.iDITEMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTEMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cANTIDADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cANTIDADPORCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uNIDADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoMItemsBs = new System.Windows.Forms.BindingSource(this.components);
            this.txtTotalCantidad = new System.Windows.Forms.TextBox();
            this.txtTotalCantidadPorc = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.ckSoloFormulasActivas = new System.Windows.Forms.CheckBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtNumeroOF = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectFormula1 = new System.Windows.Forms.Button();
            this.btnCancelar1 = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BoMHeaderBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoMItemsBs)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoMHeaderBs
            // 
            this.BoMHeaderBs.DataSource = typeof(TecserEF.Entity.T0020_FORMULA_H);
            // 
            // dgvFormulas
            // 
            this.dgvFormulas.AllowUserToAddRows = false;
            this.dgvFormulas.AllowUserToDeleteRows = false;
            this.dgvFormulas.AllowUserToResizeColumns = false;
            this.dgvFormulas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumAquamarine;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFormulas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFormulas.AutoGenerateColumns = false;
            this.dgvFormulas.BackgroundColor = System.Drawing.Color.White;
            this.dgvFormulas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFormulas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFormulas.ColumnHeadersHeight = 25;
            this.dgvFormulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFormulas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDFORMULADataGridViewTextBoxColumn,
            this.dESCFORMULADataGridViewTextBoxColumn,
            this.fORMVERSIONDataGridViewTextBoxColumn,
            this.lastUsedDataGridViewTextBoxColumn});
            this.dgvFormulas.DataSource = this.BoMHeaderBs;
            this.dgvFormulas.Location = new System.Drawing.Point(8, 87);
            this.dgvFormulas.MultiSelect = false;
            this.dgvFormulas.Name = "dgvFormulas";
            this.dgvFormulas.ReadOnly = true;
            this.dgvFormulas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvFormulas.RowHeadersWidth = 20;
            this.dgvFormulas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFormulas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFormulas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFormulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormulas.ShowCellErrors = false;
            this.dgvFormulas.Size = new System.Drawing.Size(480, 150);
            this.dgvFormulas.TabIndex = 9;
            this.dgvFormulas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulas_CellContentClick);
            this.dgvFormulas.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormulas_CellEnter);
            // 
            // iDFORMULADataGridViewTextBoxColumn
            // 
            this.iDFORMULADataGridViewTextBoxColumn.DataPropertyName = "ID_FORMULA";
            this.iDFORMULADataGridViewTextBoxColumn.HeaderText = "ID_FORMULA";
            this.iDFORMULADataGridViewTextBoxColumn.Name = "iDFORMULADataGridViewTextBoxColumn";
            this.iDFORMULADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDFORMULADataGridViewTextBoxColumn.Visible = false;
            // 
            // dESCFORMULADataGridViewTextBoxColumn
            // 
            this.dESCFORMULADataGridViewTextBoxColumn.DataPropertyName = "DESC_FORMULA";
            this.dESCFORMULADataGridViewTextBoxColumn.HeaderText = "DESCRIPCION";
            this.dESCFORMULADataGridViewTextBoxColumn.Name = "dESCFORMULADataGridViewTextBoxColumn";
            this.dESCFORMULADataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCFORMULADataGridViewTextBoxColumn.Width = 300;
            // 
            // fORMVERSIONDataGridViewTextBoxColumn
            // 
            this.fORMVERSIONDataGridViewTextBoxColumn.DataPropertyName = "FORM_VERSION";
            this.fORMVERSIONDataGridViewTextBoxColumn.HeaderText = "VERSION";
            this.fORMVERSIONDataGridViewTextBoxColumn.Name = "fORMVERSIONDataGridViewTextBoxColumn";
            this.fORMVERSIONDataGridViewTextBoxColumn.ReadOnly = true;
            this.fORMVERSIONDataGridViewTextBoxColumn.Width = 50;
            // 
            // lastUsedDataGridViewTextBoxColumn
            // 
            this.lastUsedDataGridViewTextBoxColumn.DataPropertyName = "LastUsed";
            this.lastUsedDataGridViewTextBoxColumn.HeaderText = "ULTIMO USO";
            this.lastUsedDataGridViewTextBoxColumn.Name = "lastUsedDataGridViewTextBoxColumn";
            this.lastUsedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgvDetalleItems
            // 
            this.dgvDetalleItems.AllowUserToAddRows = false;
            this.dgvDetalleItems.AllowUserToDeleteRows = false;
            this.dgvDetalleItems.AllowUserToOrderColumns = true;
            this.dgvDetalleItems.AllowUserToResizeColumns = false;
            this.dgvDetalleItems.AllowUserToResizeRows = false;
            this.dgvDetalleItems.AutoGenerateColumns = false;
            this.dgvDetalleItems.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDetalleItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalleItems.ColumnHeadersHeight = 20;
            this.dgvDetalleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDITEMDataGridViewTextBoxColumn,
            this.iTEMDataGridViewTextBoxColumn,
            this.cANTIDADDataGridViewTextBoxColumn,
            this.cANTIDADPORCDataGridViewTextBoxColumn,
            this.uNIDADDataGridViewTextBoxColumn});
            this.dgvDetalleItems.DataSource = this.BoMItemsBs;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleItems.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetalleItems.Location = new System.Drawing.Point(8, 260);
            this.dgvDetalleItems.MultiSelect = false;
            this.dgvDetalleItems.Name = "dgvDetalleItems";
            this.dgvDetalleItems.ReadOnly = true;
            this.dgvDetalleItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetalleItems.RowHeadersVisible = false;
            this.dgvDetalleItems.Size = new System.Drawing.Size(389, 212);
            this.dgvDetalleItems.TabIndex = 10;
            // 
            // iDITEMDataGridViewTextBoxColumn
            // 
            this.iDITEMDataGridViewTextBoxColumn.DataPropertyName = "ID_ITEM";
            this.iDITEMDataGridViewTextBoxColumn.HeaderText = "# Item";
            this.iDITEMDataGridViewTextBoxColumn.Name = "iDITEMDataGridViewTextBoxColumn";
            this.iDITEMDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDITEMDataGridViewTextBoxColumn.Width = 60;
            // 
            // iTEMDataGridViewTextBoxColumn
            // 
            this.iTEMDataGridViewTextBoxColumn.DataPropertyName = "ITEM";
            this.iTEMDataGridViewTextBoxColumn.HeaderText = "Material ";
            this.iTEMDataGridViewTextBoxColumn.Name = "iTEMDataGridViewTextBoxColumn";
            this.iTEMDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTEMDataGridViewTextBoxColumn.Width = 150;
            // 
            // cANTIDADDataGridViewTextBoxColumn
            // 
            this.cANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.cANTIDADDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.cANTIDADDataGridViewTextBoxColumn.HeaderText = "Cant KG";
            this.cANTIDADDataGridViewTextBoxColumn.Name = "cANTIDADDataGridViewTextBoxColumn";
            this.cANTIDADDataGridViewTextBoxColumn.ReadOnly = true;
            this.cANTIDADDataGridViewTextBoxColumn.Width = 60;
            // 
            // cANTIDADPORCDataGridViewTextBoxColumn
            // 
            this.cANTIDADPORCDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD_PORC";
            dataGridViewCellStyle6.Format = "P2";
            dataGridViewCellStyle6.NullValue = "0";
            this.cANTIDADPORCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.cANTIDADPORCDataGridViewTextBoxColumn.HeaderText = "Cant %";
            this.cANTIDADPORCDataGridViewTextBoxColumn.Name = "cANTIDADPORCDataGridViewTextBoxColumn";
            this.cANTIDADPORCDataGridViewTextBoxColumn.ReadOnly = true;
            this.cANTIDADPORCDataGridViewTextBoxColumn.Width = 60;
            // 
            // uNIDADDataGridViewTextBoxColumn
            // 
            this.uNIDADDataGridViewTextBoxColumn.DataPropertyName = "UNIDAD";
            this.uNIDADDataGridViewTextBoxColumn.HeaderText = "UoM";
            this.uNIDADDataGridViewTextBoxColumn.Name = "uNIDADDataGridViewTextBoxColumn";
            this.uNIDADDataGridViewTextBoxColumn.ReadOnly = true;
            this.uNIDADDataGridViewTextBoxColumn.Width = 50;
            // 
            // BoMItemsBs
            // 
            this.BoMItemsBs.DataSource = typeof(TecserEF.Entity.T0021_FORMULA_I);
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtTotalCantidad.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCantidad.Location = new System.Drawing.Point(214, 4);
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.ReadOnly = true;
            this.txtTotalCantidad.Size = new System.Drawing.Size(58, 21);
            this.txtTotalCantidad.TabIndex = 11;
            this.txtTotalCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalCantidadPorc
            // 
            this.txtTotalCantidadPorc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtTotalCantidadPorc.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCantidadPorc.Location = new System.Drawing.Point(272, 4);
            this.txtTotalCantidadPorc.Name = "txtTotalCantidadPorc";
            this.txtTotalCantidadPorc.ReadOnly = true;
            this.txtTotalCantidadPorc.Size = new System.Drawing.Size(58, 21);
            this.txtTotalCantidadPorc.TabIndex = 12;
            this.txtTotalCantidadPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.Controls.Add(this.label39);
            this.panel6.Controls.Add(this.ckSoloFormulasActivas);
            this.panel6.Controls.Add(this.label40);
            this.panel6.Controls.Add(this.txtNumeroOF);
            this.panel6.Controls.Add(this.txtMaterial);
            this.panel6.Location = new System.Drawing.Point(8, 8);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(603, 56);
            this.panel6.TabIndex = 56;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(7, 28);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(89, 20);
            this.label39.TabIndex = 2;
            this.label39.Text = "PRIMARIO";
            // 
            // ckSoloFormulasActivas
            // 
            this.ckSoloFormulasActivas.AutoSize = true;
            this.ckSoloFormulasActivas.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloFormulasActivas.Location = new System.Drawing.Point(436, 7);
            this.ckSoloFormulasActivas.Name = "ckSoloFormulasActivas";
            this.ckSoloFormulasActivas.Size = new System.Drawing.Size(164, 18);
            this.ckSoloFormulasActivas.TabIndex = 170;
            this.ckSoloFormulasActivas.Text = "Ver Solo Formulas Activas";
            this.ckSoloFormulasActivas.UseVisualStyleBackColor = true;
            this.ckSoloFormulasActivas.CheckedChanged += new System.EventHandler(this.ckSoloFormulasActivas_CheckedChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(52, 5);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(44, 20);
            this.label40.TabIndex = 1;
            this.label40.Text = "OF #";
            // 
            // txtNumeroOF
            // 
            this.txtNumeroOF.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNumeroOF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOF.ForeColor = System.Drawing.Color.Red;
            this.txtNumeroOF.Location = new System.Drawing.Point(102, 6);
            this.txtNumeroOF.Name = "txtNumeroOF";
            this.txtNumeroOF.ReadOnly = true;
            this.txtNumeroOF.Size = new System.Drawing.Size(69, 19);
            this.txtNumeroOF.TabIndex = 12;
            this.txtNumeroOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMaterial
            // 
            this.txtMaterial.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterial.Location = new System.Drawing.Point(102, 29);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(207, 19);
            this.txtMaterial.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Plum;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(9, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(479, 19);
            this.label15.TabIndex = 57;
            this.label15.Text = "Versiones de Formula Disponible";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Beige;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 19);
            this.label2.TabIndex = 58;
            this.label2.Text = "DETALLE DE FORMULA SELECCIONADA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.txtTotalCantidadPorc);
            this.panel1.Controls.Add(this.txtTotalCantidad);
            this.panel1.Location = new System.Drawing.Point(8, 474);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 29);
            this.panel1.TabIndex = 57;
            // 
            // btnSelectFormula1
            // 
            this.btnSelectFormula1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFormula1.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectFormula1.Image")));
            this.btnSelectFormula1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectFormula1.Location = new System.Drawing.Point(493, 153);
            this.btnSelectFormula1.Name = "btnSelectFormula1";
            this.btnSelectFormula1.Size = new System.Drawing.Size(118, 40);
            this.btnSelectFormula1.TabIndex = 168;
            this.btnSelectFormula1.Text = "SELECT\r\nFormula";
            this.btnSelectFormula1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectFormula1.UseVisualStyleBackColor = true;
            this.btnSelectFormula1.Click += new System.EventHandler(this.btnSelectFormula1_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar1.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar1.Image")));
            this.btnCancelar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar1.Location = new System.Drawing.Point(493, 67);
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Size = new System.Drawing.Size(118, 40);
            this.btnCancelar1.TabIndex = 169;
            this.btnCancelar1.Text = "Cancelar\r\nFormulacion";
            this.btnCancelar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar1.UseVisualStyleBackColor = true;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVolver.Location = new System.Drawing.Point(493, 110);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(118, 40);
            this.btnVolver.TabIndex = 171;
            this.btnVolver.Text = "Regresar";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.MidnightBlue;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 520);
            this.LineaIzq.TabIndex = 184;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DimGray;
            this.lineaArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lineaArriba.Location = new System.Drawing.Point(2, 2);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(616, 3);
            this.lineaArriba.TabIndex = 183;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(615, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 520);
            this.label1.TabIndex = 185;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(2, 519);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(616, 3);
            this.label3.TabIndex = 186;
            // 
            // FrmPP07SeleccionFormulaAFabricar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(620, 525);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCancelar1);
            this.Controls.Add(this.btnSelectFormula1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.dgvDetalleItems);
            this.Controls.Add(this.dgvFormulas);
            this.Name = "FrmPP07SeleccionFormulaAFabricar";
            this.Text = "PP07 - Seleccion de Formula a Fabricar (Formulacion Manual)";
            this.Load += new System.EventHandler(this.FrmPlanProduccionSeleccionFormula_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BoMHeaderBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormulas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoMItemsBs)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource BoMHeaderBs;
        private System.Windows.Forms.DataGridView dgvFormulas;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDFORMULADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCFORMULADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fORMVERSIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUsedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvDetalleItems;
        private System.Windows.Forms.BindingSource BoMItemsBs;
        private System.Windows.Forms.TextBox txtTotalCantidad;
        private System.Windows.Forms.TextBox txtTotalCantidadPorc;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtNumeroOF;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelectFormula1;
        private System.Windows.Forms.Button btnCancelar1;
        private System.Windows.Forms.CheckBox ckSoloFormulasActivas;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDITEMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTEMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cANTIDADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cANTIDADPORCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uNIDADDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}