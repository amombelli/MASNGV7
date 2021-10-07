namespace MASngFE.Transactional.MM
{
    partial class FrmMM5
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tMovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recursoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oFProductDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oFStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mM5StructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRecordsInList = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.ckVerCambioEstado = new System.Windows.Forms.CheckBox();
            this.txtnumeroMaxRecords = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.ckVerMovimientosSLOC = new System.Windows.Forms.CheckBox();
            this.ckIC = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ckFacturacionRE = new System.Windows.Forms.CheckBox();
            this.ckFabricadoFinal = new System.Windows.Forms.CheckBox();
            this.ckFabricadoTemp = new System.Windows.Forms.CheckBox();
            this.ckAjusteStock = new System.Windows.Forms.CheckBox();
            this.ckRetorno = new System.Windows.Forms.CheckBox();
            this.ckDescuentoMP = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtKgSeleccionados = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mM5StructureBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.AutoGenerateColumns = false;
            this.dgvLista.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.tMovDataGridViewTextBoxColumn,
            this.tDDataGridViewTextBoxColumn,
            this.documentoDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.loteDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.sLocDataGridViewTextBoxColumn,
            this.lXDataGridViewTextBoxColumn,
            this.tCodeDataGridViewTextBoxColumn,
            this.comentarioDataGridViewTextBoxColumn,
            this.recursoDataGridViewTextBoxColumn,
            this.oFProductDataGridViewTextBoxColumn,
            this.oFStatusDataGridViewTextBoxColumn,
            this.clienteDescDataGridViewTextBoxColumn,
            this.proveedorDataGridViewTextBoxColumn,
            this.logUserDataGridViewTextBoxColumn,
            this.logDateDataGridViewTextBoxColumn});
            this.dgvLista.DataSource = this.mM5StructureBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLista.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvLista.GridColor = System.Drawing.Color.Black;
            this.dgvLista.Location = new System.Drawing.Point(3, 132);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvLista.RowHeadersWidth = 20;
            this.dgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLista.Size = new System.Drawing.Size(1478, 627);
            this.dgvLista.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID#";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 60;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "FECHA";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 80;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.materialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.materialDataGridViewTextBoxColumn.HeaderText = "MATERIAL";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tMovDataGridViewTextBoxColumn
            // 
            this.tMovDataGridViewTextBoxColumn.DataPropertyName = "TMov";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tMovDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.tMovDataGridViewTextBoxColumn.HeaderText = "MOV";
            this.tMovDataGridViewTextBoxColumn.Name = "tMovDataGridViewTextBoxColumn";
            this.tMovDataGridViewTextBoxColumn.ReadOnly = true;
            this.tMovDataGridViewTextBoxColumn.Width = 40;
            // 
            // tDDataGridViewTextBoxColumn
            // 
            this.tDDataGridViewTextBoxColumn.DataPropertyName = "TD";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.tDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.tDDataGridViewTextBoxColumn.HeaderText = "TD";
            this.tDDataGridViewTextBoxColumn.Name = "tDDataGridViewTextBoxColumn";
            this.tDDataGridViewTextBoxColumn.ReadOnly = true;
            this.tDDataGridViewTextBoxColumn.Width = 40;
            // 
            // documentoDataGridViewTextBoxColumn
            // 
            this.documentoDataGridViewTextBoxColumn.DataPropertyName = "Documento";
            this.documentoDataGridViewTextBoxColumn.HeaderText = "DOC#";
            this.documentoDataGridViewTextBoxColumn.Name = "documentoDataGridViewTextBoxColumn";
            this.documentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.documentoDataGridViewTextBoxColumn.Width = 70;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy;
            this.cantidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "CANT";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 60;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            this.loteDataGridViewTextBoxColumn.HeaderText = "LOTE #";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            this.loteDataGridViewTextBoxColumn.Width = 80;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "ESTADO";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Width = 80;
            // 
            // sLocDataGridViewTextBoxColumn
            // 
            this.sLocDataGridViewTextBoxColumn.DataPropertyName = "SLoc";
            this.sLocDataGridViewTextBoxColumn.HeaderText = "SLOC";
            this.sLocDataGridViewTextBoxColumn.Name = "sLocDataGridViewTextBoxColumn";
            this.sLocDataGridViewTextBoxColumn.ReadOnly = true;
            this.sLocDataGridViewTextBoxColumn.Width = 60;
            // 
            // lXDataGridViewTextBoxColumn
            // 
            this.lXDataGridViewTextBoxColumn.DataPropertyName = "LX";
            this.lXDataGridViewTextBoxColumn.HeaderText = "LX";
            this.lXDataGridViewTextBoxColumn.Name = "lXDataGridViewTextBoxColumn";
            this.lXDataGridViewTextBoxColumn.ReadOnly = true;
            this.lXDataGridViewTextBoxColumn.Width = 30;
            // 
            // tCodeDataGridViewTextBoxColumn
            // 
            this.tCodeDataGridViewTextBoxColumn.DataPropertyName = "TCode";
            this.tCodeDataGridViewTextBoxColumn.HeaderText = "TCODE";
            this.tCodeDataGridViewTextBoxColumn.Name = "tCodeDataGridViewTextBoxColumn";
            this.tCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tCodeDataGridViewTextBoxColumn.Width = 60;
            // 
            // comentarioDataGridViewTextBoxColumn
            // 
            this.comentarioDataGridViewTextBoxColumn.DataPropertyName = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.HeaderText = "OBSERVACION";
            this.comentarioDataGridViewTextBoxColumn.Name = "comentarioDataGridViewTextBoxColumn";
            this.comentarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.comentarioDataGridViewTextBoxColumn.Width = 130;
            // 
            // recursoDataGridViewTextBoxColumn
            // 
            this.recursoDataGridViewTextBoxColumn.DataPropertyName = "Recurso";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.recursoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.recursoDataGridViewTextBoxColumn.HeaderText = "REC";
            this.recursoDataGridViewTextBoxColumn.Name = "recursoDataGridViewTextBoxColumn";
            this.recursoDataGridViewTextBoxColumn.ReadOnly = true;
            this.recursoDataGridViewTextBoxColumn.Width = 50;
            // 
            // oFProductDataGridViewTextBoxColumn
            // 
            this.oFProductDataGridViewTextBoxColumn.DataPropertyName = "OFProduct";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.oFProductDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.oFProductDataGridViewTextBoxColumn.HeaderText = "OFMATERIAL";
            this.oFProductDataGridViewTextBoxColumn.Name = "oFProductDataGridViewTextBoxColumn";
            this.oFProductDataGridViewTextBoxColumn.ReadOnly = true;
            this.oFProductDataGridViewTextBoxColumn.Width = 102;
            // 
            // oFStatusDataGridViewTextBoxColumn
            // 
            this.oFStatusDataGridViewTextBoxColumn.DataPropertyName = "OFStatus";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.oFStatusDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.oFStatusDataGridViewTextBoxColumn.HeaderText = "OFSTATUS";
            this.oFStatusDataGridViewTextBoxColumn.Name = "oFStatusDataGridViewTextBoxColumn";
            this.oFStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.oFStatusDataGridViewTextBoxColumn.Width = 95;
            // 
            // clienteDescDataGridViewTextBoxColumn
            // 
            this.clienteDescDataGridViewTextBoxColumn.DataPropertyName = "ClienteDesc";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.MintCream;
            this.clienteDescDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.clienteDescDataGridViewTextBoxColumn.HeaderText = "CLIENTE";
            this.clienteDescDataGridViewTextBoxColumn.Name = "clienteDescDataGridViewTextBoxColumn";
            this.clienteDescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // proveedorDataGridViewTextBoxColumn
            // 
            this.proveedorDataGridViewTextBoxColumn.DataPropertyName = "Proveedor";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.proveedorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.proveedorDataGridViewTextBoxColumn.HeaderText = "PROVEEDOR";
            this.proveedorDataGridViewTextBoxColumn.Name = "proveedorDataGridViewTextBoxColumn";
            this.proveedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // logUserDataGridViewTextBoxColumn
            // 
            this.logUserDataGridViewTextBoxColumn.DataPropertyName = "LogUser";
            this.logUserDataGridViewTextBoxColumn.HeaderText = "USER";
            this.logUserDataGridViewTextBoxColumn.Name = "logUserDataGridViewTextBoxColumn";
            this.logUserDataGridViewTextBoxColumn.ReadOnly = true;
            this.logUserDataGridViewTextBoxColumn.Width = 70;
            // 
            // logDateDataGridViewTextBoxColumn
            // 
            this.logDateDataGridViewTextBoxColumn.DataPropertyName = "LogDate";
            this.logDateDataGridViewTextBoxColumn.HeaderText = "DATE";
            this.logDateDataGridViewTextBoxColumn.Name = "logDateDataGridViewTextBoxColumn";
            this.logDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.logDateDataGridViewTextBoxColumn.Width = 70;
            // 
            // mM5StructureBindingSource
            // 
            this.mM5StructureBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.MM5Structure);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "NUMERO LOTE";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(151, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(65, 20);
            this.textBox1.TabIndex = 29;
            this.textBox1.Text = "1000";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFechaDesde);
            this.panel1.Controls.Add(this.cmbMaterial);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFechaHasta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 81);
            this.panel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MATERIAL";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.CalendarTitleForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(92, 27);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(117, 20);
            this.dtpFechaDesde.TabIndex = 5;
            this.dtpFechaDesde.Leave += new System.EventHandler(this.dtpFechaDesde_ValueChanged_1);
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.DisplayMember = "IDMATERIAL";
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(92, 5);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(150, 21);
            this.cmbMaterial.TabIndex = 6;
            this.cmbMaterial.ValueMember = "IDMATERIAL";
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "DESDE";
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(92, 50);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(117, 20);
            this.dtpFechaHasta.TabIndex = 8;
            this.dtpFechaHasta.Leave += new System.EventHandler(this.dtpFechaHasta_ValueChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "HASTA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1088, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Registros en Lista";
            // 
            // txtRecordsInList
            // 
            this.txtRecordsInList.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRecordsInList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecordsInList.Location = new System.Drawing.Point(1212, 31);
            this.txtRecordsInList.Name = "txtRecordsInList";
            this.txtRecordsInList.ReadOnly = true;
            this.txtRecordsInList.Size = new System.Drawing.Size(65, 20);
            this.txtRecordsInList.TabIndex = 26;
            this.txtRecordsInList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1088, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Cantidad Max. Records";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Location = new System.Drawing.Point(1095, 57);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(111, 42);
            this.btnRefreshList.TabIndex = 24;
            this.btnRefreshList.Text = "REFRESH\r\nDATA";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(1210, 57);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(111, 42);
            this.btnResetFilters.TabIndex = 23;
            this.btnResetFilters.Text = "RESET\r\nFILTERS";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // ckVerCambioEstado
            // 
            this.ckVerCambioEstado.Location = new System.Drawing.Point(531, 76);
            this.ckVerCambioEstado.Name = "ckVerCambioEstado";
            this.ckVerCambioEstado.Size = new System.Drawing.Size(232, 19);
            this.ckVerCambioEstado.TabIndex = 22;
            this.ckVerCambioEstado.Text = "VER CAMBIOS DE ESTADO";
            this.ckVerCambioEstado.UseVisualStyleBackColor = true;
            this.ckVerCambioEstado.CheckedChanged += new System.EventHandler(this.ckVerCambioEstado_CheckedChanged);
            // 
            // txtnumeroMaxRecords
            // 
            this.txtnumeroMaxRecords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnumeroMaxRecords.Location = new System.Drawing.Point(1212, 7);
            this.txtnumeroMaxRecords.Name = "txtnumeroMaxRecords";
            this.txtnumeroMaxRecords.Size = new System.Drawing.Size(65, 20);
            this.txtnumeroMaxRecords.TabIndex = 21;
            this.txtnumeroMaxRecords.Text = "1000";
            this.txtnumeroMaxRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtnumeroMaxRecords.TextChanged += new System.EventHandler(this.txtnumeroMaxRecords_TextChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1372, 57);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(111, 42);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // ckVerMovimientosSLOC
            // 
            this.ckVerMovimientosSLOC.Location = new System.Drawing.Point(531, 53);
            this.ckVerMovimientosSLOC.Name = "ckVerMovimientosSLOC";
            this.ckVerMovimientosSLOC.Size = new System.Drawing.Size(232, 19);
            this.ckVerMovimientosSLOC.TabIndex = 19;
            this.ckVerMovimientosSLOC.Text = "VER TRANSFERENCIAS ENTRE SLOC";
            this.ckVerMovimientosSLOC.UseVisualStyleBackColor = true;
            this.ckVerMovimientosSLOC.CheckedChanged += new System.EventHandler(this.ckVerMovimientosSLOC_CheckedChanged);
            // 
            // ckIC
            // 
            this.ckIC.Location = new System.Drawing.Point(8, 5);
            this.ckIC.Name = "ckIC";
            this.ckIC.Size = new System.Drawing.Size(227, 19);
            this.ckIC.TabIndex = 31;
            this.ckIC.Text = "VER INGRESOS [IC]";
            this.ckIC.UseVisualStyleBackColor = true;
            this.ckIC.CheckedChanged += new System.EventHandler(this.ckIC_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.Controls.Add(this.btnNone);
            this.panel2.Controls.Add(this.btnAll);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.ckFacturacionRE);
            this.panel2.Controls.Add(this.ckFabricadoFinal);
            this.panel2.Controls.Add(this.ckFabricadoTemp);
            this.panel2.Controls.Add(this.ckAjusteStock);
            this.panel2.Controls.Add(this.ckRetorno);
            this.panel2.Controls.Add(this.ckDescuentoMP);
            this.panel2.Controls.Add(this.ckIC);
            this.panel2.Controls.Add(this.ckVerMovimientosSLOC);
            this.panel2.Controls.Add(this.ckVerCambioEstado);
            this.panel2.Location = new System.Drawing.Point(307, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 100);
            this.panel2.TabIndex = 32;
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(681, 8);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(63, 26);
            this.btnNone.TabIndex = 39;
            this.btnNone.Text = "NONE";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(612, 8);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(63, 26);
            this.btnAll.TabIndex = 33;
            this.btnAll.Text = "ALL";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(266, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(227, 19);
            this.checkBox1.TabIndex = 38;
            this.checkBox1.Text = "-";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ckFacturacionRE
            // 
            this.ckFacturacionRE.Location = new System.Drawing.Point(266, 52);
            this.ckFacturacionRE.Name = "ckFacturacionRE";
            this.ckFacturacionRE.Size = new System.Drawing.Size(227, 19);
            this.ckFacturacionRE.TabIndex = 37;
            this.ckFacturacionRE.Text = "VER FACTURACION [RE]";
            this.ckFacturacionRE.UseVisualStyleBackColor = true;
            this.ckFacturacionRE.CheckedChanged += new System.EventHandler(this.ckIC_CheckedChanged);
            // 
            // ckFabricadoFinal
            // 
            this.ckFabricadoFinal.Location = new System.Drawing.Point(266, 27);
            this.ckFabricadoFinal.Name = "ckFabricadoFinal";
            this.ckFabricadoFinal.Size = new System.Drawing.Size(227, 19);
            this.ckFabricadoFinal.TabIndex = 36;
            this.ckFabricadoFinal.Text = "VER INGRESOS FABRICADO [F]";
            this.ckFabricadoFinal.UseVisualStyleBackColor = true;
            this.ckFabricadoFinal.CheckedChanged += new System.EventHandler(this.ckIC_CheckedChanged);
            // 
            // ckFabricadoTemp
            // 
            this.ckFabricadoTemp.Location = new System.Drawing.Point(266, 5);
            this.ckFabricadoTemp.Name = "ckFabricadoTemp";
            this.ckFabricadoTemp.Size = new System.Drawing.Size(227, 19);
            this.ckFabricadoTemp.TabIndex = 35;
            this.ckFabricadoTemp.Text = "VER INGRESOS FABRICADO [T]";
            this.ckFabricadoTemp.UseVisualStyleBackColor = true;
            this.ckFabricadoTemp.CheckedChanged += new System.EventHandler(this.ckIC_CheckedChanged);
            // 
            // ckAjusteStock
            // 
            this.ckAjusteStock.Location = new System.Drawing.Point(8, 76);
            this.ckAjusteStock.Name = "ckAjusteStock";
            this.ckAjusteStock.Size = new System.Drawing.Size(227, 19);
            this.ckAjusteStock.TabIndex = 34;
            this.ckAjusteStock.Text = "VER AJUSTES DE STOCK AI]";
            this.ckAjusteStock.UseVisualStyleBackColor = true;
            this.ckAjusteStock.CheckedChanged += new System.EventHandler(this.ckIC_CheckedChanged);
            // 
            // ckRetorno
            // 
            this.ckRetorno.Location = new System.Drawing.Point(8, 52);
            this.ckRetorno.Name = "ckRetorno";
            this.ckRetorno.Size = new System.Drawing.Size(227, 19);
            this.ckRetorno.TabIndex = 33;
            this.ckRetorno.Text = "VER DEVOLUCIONES [RTN]";
            this.ckRetorno.UseVisualStyleBackColor = true;
            this.ckRetorno.CheckedChanged += new System.EventHandler(this.ckIC_CheckedChanged);
            // 
            // ckDescuentoMP
            // 
            this.ckDescuentoMP.Location = new System.Drawing.Point(8, 27);
            this.ckDescuentoMP.Name = "ckDescuentoMP";
            this.ckDescuentoMP.Size = new System.Drawing.Size(227, 19);
            this.ckDescuentoMP.TabIndex = 32;
            this.ckDescuentoMP.Text = "VER DESCUENTO MP [OF]";
            this.ckDescuentoMP.UseVisualStyleBackColor = true;
            this.ckDescuentoMP.CheckedChanged += new System.EventHandler(this.ckIC_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.PaleGreen;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(312, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "KG SELECCIONADOS";
            // 
            // txtKgSeleccionados
            // 
            this.txtKgSeleccionados.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtKgSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKgSeleccionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgSeleccionados.Location = new System.Drawing.Point(447, 107);
            this.txtKgSeleccionados.Name = "txtKgSeleccionados";
            this.txtKgSeleccionados.ReadOnly = true;
            this.txtKgSeleccionados.Size = new System.Drawing.Size(95, 21);
            this.txtKgSeleccionados.TabIndex = 33;
            this.txtKgSeleccionados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmMM5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 789);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtKgSeleccionados);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRecordsInList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.txtnumeroMaxRecords);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvLista);
            this.Name = "FrmMM5";
            this.Text = "MM05 - Movimientos de Materiales";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mM5StructureBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.BindingSource mM5StructureBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tMovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recursoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oFProductDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oFStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn logDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRecordsInList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.CheckBox ckVerCambioEstado;
        private System.Windows.Forms.TextBox txtnumeroMaxRecords;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox ckVerMovimientosSLOC;
        private System.Windows.Forms.CheckBox ckIC;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckAjusteStock;
        private System.Windows.Forms.CheckBox ckRetorno;
        private System.Windows.Forms.CheckBox ckDescuentoMP;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox ckFacturacionRE;
        private System.Windows.Forms.CheckBox ckFabricadoFinal;
        private System.Windows.Forms.CheckBox ckFabricadoTemp;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKgSeleccionados;
    }
}