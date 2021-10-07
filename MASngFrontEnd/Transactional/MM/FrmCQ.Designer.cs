namespace MASngFE.Transactional.MM
{
    partial class FrmCq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCq));
            this.dgvStockList = new System.Windows.Forms.DataGridView();
            this.Idstock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalKgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdOrdenVentaReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoReservaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialOF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCION = new System.Windows.Forms.DataGridViewButtonColumn();
            this.MOVE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.QM = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cqStockStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ckLiberado = new System.Windows.Forms.CheckBox();
            this.ckRestringido = new System.Windows.Forms.CheckBox();
            this.ckComprometido = new System.Windows.Forms.CheckBox();
            this.ckReservaPF = new System.Windows.Forms.CheckBox();
            this.ckReservaRE = new System.Windows.Forms.CheckBox();
            this.ckFE = new System.Windows.Forms.CheckBox();
            this.btnAllStatus = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNumeroLote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.reducedMaterialMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpSeleccionMaterial = new System.Windows.Forms.GroupBox();
            this.rbAka = new System.Windows.Forms.RadioButton();
            this.rbPrimario = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSloc = new System.Windows.Forms.ComboBox();
            this.t0028SLOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlanta = new System.Windows.Forms.TextBox();
            this.txtSlocDescription = new System.Windows.Forms.TextBox();
            this.txtPrimaryDescription = new System.Windows.Forms.TextBox();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKgSeleccionados = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLineasStock = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAltaNewLine = new System.Windows.Forms.Button();
            this.ckSoloConStock = new System.Windows.Forms.CheckBox();
            this.ckBusquedaLibre = new System.Windows.Forms.CheckBox();
            this.txtMaterialBuscar = new System.Windows.Forms.TextBox();
            this.btnOptimizacionStock = new System.Windows.Forms.Button();
            this.btnFixRedondeo = new System.Windows.Forms.Button();
            this.btnUpdateLote = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdStockSeleccionado = new System.Windows.Forms.TextBox();
            this.btnRestringirLote = new System.Windows.Forms.Button();
            this.btnAjusteStock = new System.Windows.Forms.Button();
            this.btnRptStandBy = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCompromiso = new System.Windows.Forms.Button();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.lineaDerecha = new System.Windows.Forms.Label();
            this.lineaAbajo = new System.Windows.Forms.Label();
            this.btnReservaRe = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cqStockStructureBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reducedMaterialMasterBindingSource)).BeginInit();
            this.grpSeleccionMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStockList
            // 
            this.dgvStockList.AllowUserToAddRows = false;
            this.dgvStockList.AllowUserToDeleteRows = false;
            this.dgvStockList.AutoGenerateColumns = false;
            this.dgvStockList.BackgroundColor = System.Drawing.Color.Black;
            this.dgvStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idstock,
            this.materialDataGridViewTextBoxColumn,
            this.MaterialType,
            this.loteDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.totalKgDataGridViewTextBoxColumn,
            this.sLOCDataGridViewTextBoxColumn,
            this.IdOrdenVentaReserva,
            this.clienteReservaDataGridViewTextBoxColumn,
            this.documentoReservaDataGridViewTextBoxColumn,
            this.estadoReservaDataGridViewTextBoxColumn,
            this.MaterialOF,
            this.ACCION,
            this.MOVE,
            this.QM});
            this.dgvStockList.DataSource = this.cqStockStructureBindingSource;
            this.dgvStockList.GridColor = System.Drawing.Color.Navy;
            this.dgvStockList.Location = new System.Drawing.Point(7, 109);
            this.dgvStockList.Name = "dgvStockList";
            this.dgvStockList.ReadOnly = true;
            this.dgvStockList.RowHeadersWidth = 20;
            this.dgvStockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockList.Size = new System.Drawing.Size(1123, 612);
            this.dgvStockList.TabIndex = 0;
            this.dgvStockList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockList_CellContentClick);
            this.dgvStockList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvStockList_CellEnter);
            // 
            // Idstock
            // 
            this.Idstock.DataPropertyName = "Idstock";
            this.Idstock.HeaderText = "Idstock";
            this.Idstock.Name = "Idstock";
            this.Idstock.ReadOnly = true;
            this.Idstock.Visible = false;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.materialDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MaterialType
            // 
            this.MaterialType.DataPropertyName = "MaterialType";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaterialType.DefaultCellStyle = dataGridViewCellStyle15;
            this.MaterialType.HeaderText = "TipoM";
            this.MaterialType.Name = "MaterialType";
            this.MaterialType.ReadOnly = true;
            this.MaterialType.Width = 50;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Navy;
            this.loteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            this.loteDataGridViewTextBoxColumn.Width = 80;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Width = 90;
            // 
            // totalKgDataGridViewTextBoxColumn
            // 
            this.totalKgDataGridViewTextBoxColumn.DataPropertyName = "TotalKg";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle18.Format = "N4";
            dataGridViewCellStyle18.NullValue = "0";
            this.totalKgDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle18;
            this.totalKgDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.totalKgDataGridViewTextBoxColumn.Name = "totalKgDataGridViewTextBoxColumn";
            this.totalKgDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalKgDataGridViewTextBoxColumn.ToolTipText = "Total de Kg en Stock";
            this.totalKgDataGridViewTextBoxColumn.Width = 80;
            // 
            // sLOCDataGridViewTextBoxColumn
            // 
            this.sLOCDataGridViewTextBoxColumn.DataPropertyName = "SLOC";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLOCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.sLOCDataGridViewTextBoxColumn.HeaderText = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.Name = "sLOCDataGridViewTextBoxColumn";
            this.sLOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sLOCDataGridViewTextBoxColumn.ToolTipText = "Ubicacion del Stock";
            this.sLOCDataGridViewTextBoxColumn.Width = 50;
            // 
            // IdOrdenVentaReserva
            // 
            this.IdOrdenVentaReserva.DataPropertyName = "IdOrdenVentaReserva";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Indigo;
            this.IdOrdenVentaReserva.DefaultCellStyle = dataGridViewCellStyle20;
            this.IdOrdenVentaReserva.HeaderText = "OV#";
            this.IdOrdenVentaReserva.Name = "IdOrdenVentaReserva";
            this.IdOrdenVentaReserva.ReadOnly = true;
            this.IdOrdenVentaReserva.Width = 60;
            // 
            // clienteReservaDataGridViewTextBoxColumn
            // 
            this.clienteReservaDataGridViewTextBoxColumn.DataPropertyName = "ClienteReserva";
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Indigo;
            this.clienteReservaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle21;
            this.clienteReservaDataGridViewTextBoxColumn.HeaderText = "Reservado Para";
            this.clienteReservaDataGridViewTextBoxColumn.Name = "clienteReservaDataGridViewTextBoxColumn";
            this.clienteReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteReservaDataGridViewTextBoxColumn.Width = 150;
            // 
            // documentoReservaDataGridViewTextBoxColumn
            // 
            this.documentoReservaDataGridViewTextBoxColumn.DataPropertyName = "DocumentoReserva";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Indigo;
            this.documentoReservaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle22;
            this.documentoReservaDataGridViewTextBoxColumn.HeaderText = "OF#";
            this.documentoReservaDataGridViewTextBoxColumn.Name = "documentoReservaDataGridViewTextBoxColumn";
            this.documentoReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.documentoReservaDataGridViewTextBoxColumn.ToolTipText = "Numero de Orden de Fabricacion Reservada";
            this.documentoReservaDataGridViewTextBoxColumn.Width = 60;
            // 
            // estadoReservaDataGridViewTextBoxColumn
            // 
            this.estadoReservaDataGridViewTextBoxColumn.DataPropertyName = "EstadoReserva";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Indigo;
            this.estadoReservaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle23;
            this.estadoReservaDataGridViewTextBoxColumn.HeaderText = "OF Status";
            this.estadoReservaDataGridViewTextBoxColumn.Name = "estadoReservaDataGridViewTextBoxColumn";
            this.estadoReservaDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoReservaDataGridViewTextBoxColumn.ToolTipText = "Estado de Orden de Fabricacion";
            this.estadoReservaDataGridViewTextBoxColumn.Width = 90;
            // 
            // MaterialOF
            // 
            this.MaterialOF.DataPropertyName = "MaterialOF";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Indigo;
            this.MaterialOF.DefaultCellStyle = dataGridViewCellStyle24;
            this.MaterialOF.HeaderText = "OF Material";
            this.MaterialOF.Name = "MaterialOF";
            this.MaterialOF.ReadOnly = true;
            this.MaterialOF.ToolTipText = "Reservado para Fabricar Material";
            this.MaterialOF.Width = 90;
            // 
            // ACCION
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.DarkBlue;
            this.ACCION.DefaultCellStyle = dataGridViewCellStyle25;
            this.ACCION.HeaderText = "ACCION";
            this.ACCION.Name = "ACCION";
            this.ACCION.ReadOnly = true;
            this.ACCION.Text = "ACCION";
            this.ACCION.UseColumnTextForButtonValue = true;
            this.ACCION.Width = 60;
            // 
            // MOVE
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Green;
            this.MOVE.DefaultCellStyle = dataGridViewCellStyle26;
            this.MOVE.HeaderText = "MOVE";
            this.MOVE.Name = "MOVE";
            this.MOVE.ReadOnly = true;
            this.MOVE.Text = "MOVE";
            this.MOVE.UseColumnTextForButtonValue = true;
            this.MOVE.Width = 50;
            // 
            // QM
            // 
            this.QM.HeaderText = "QM";
            this.QM.Name = "QM";
            this.QM.ReadOnly = true;
            this.QM.Text = "QM";
            this.QM.ToolTipText = "Restringe Material para ser Analizado";
            this.QM.UseColumnTextForButtonValue = true;
            this.QM.Width = 50;
            // 
            // cqStockStructureBindingSource
            // 
            this.cqStockStructureBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.CqStockStructure);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Purple;
            this.btnRefresh.Location = new System.Drawing.Point(1134, 128);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(104, 40);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh\r\nData";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ckLiberado
            // 
            this.ckLiberado.AutoSize = true;
            this.ckLiberado.Location = new System.Drawing.Point(3, 7);
            this.ckLiberado.Name = "ckLiberado";
            this.ckLiberado.Size = new System.Drawing.Size(71, 17);
            this.ckLiberado.TabIndex = 2;
            this.ckLiberado.Text = "LIBERADO";
            this.ckLiberado.UseVisualStyleBackColor = true;
            this.ckLiberado.CheckedChanged += new System.EventHandler(this.ckLiberado_CheckedChanged);
            // 
            // ckRestringido
            // 
            this.ckRestringido.AutoSize = true;
            this.ckRestringido.Location = new System.Drawing.Point(194, 7);
            this.ckRestringido.Name = "ckRestringido";
            this.ckRestringido.Size = new System.Drawing.Size(87, 17);
            this.ckRestringido.TabIndex = 3;
            this.ckRestringido.Text = "RESTRINGIDO";
            this.ckRestringido.UseVisualStyleBackColor = true;
            this.ckRestringido.CheckedChanged += new System.EventHandler(this.ckLiberado_CheckedChanged);
            // 
            // ckComprometido
            // 
            this.ckComprometido.AutoSize = true;
            this.ckComprometido.Location = new System.Drawing.Point(85, 7);
            this.ckComprometido.Name = "ckComprometido";
            this.ckComprometido.Size = new System.Drawing.Size(103, 17);
            this.ckComprometido.TabIndex = 4;
            this.ckComprometido.Text = "COMPROMETIDO";
            this.ckComprometido.UseVisualStyleBackColor = true;
            this.ckComprometido.CheckedChanged += new System.EventHandler(this.ckLiberado_CheckedChanged);
            // 
            // ckReservaPF
            // 
            this.ckReservaPF.AutoSize = true;
            this.ckReservaPF.Location = new System.Drawing.Point(85, 27);
            this.ckReservaPF.Name = "ckReservaPF";
            this.ckReservaPF.Size = new System.Drawing.Size(90, 17);
            this.ckReservaPF.TabIndex = 7;
            this.ckReservaPF.Text = "RESERVADA PF";
            this.ckReservaPF.UseVisualStyleBackColor = true;
            this.ckReservaPF.CheckedChanged += new System.EventHandler(this.ckLiberado_CheckedChanged);
            // 
            // ckReservaRE
            // 
            this.ckReservaRE.AutoSize = true;
            this.ckReservaRE.Location = new System.Drawing.Point(194, 27);
            this.ckReservaRE.Name = "ckReservaRE";
            this.ckReservaRE.Size = new System.Drawing.Size(77, 17);
            this.ckReservaRE.TabIndex = 6;
            this.ckReservaRE.Text = "RESERVA RE";
            this.ckReservaRE.UseVisualStyleBackColor = true;
            this.ckReservaRE.CheckedChanged += new System.EventHandler(this.ckLiberado_CheckedChanged);
            // 
            // ckFE
            // 
            this.ckFE.AutoSize = true;
            this.ckFE.Location = new System.Drawing.Point(3, 27);
            this.ckFE.Name = "ckFE";
            this.ckFE.Size = new System.Drawing.Size(36, 17);
            this.ckFE.TabIndex = 5;
            this.ckFE.Text = "FE";
            this.ckFE.UseVisualStyleBackColor = true;
            this.ckFE.CheckedChanged += new System.EventHandler(this.ckLiberado_CheckedChanged);
            // 
            // btnAllStatus
            // 
            this.btnAllStatus.Location = new System.Drawing.Point(287, 2);
            this.btnAllStatus.Name = "btnAllStatus";
            this.btnAllStatus.Size = new System.Drawing.Size(52, 22);
            this.btnAllStatus.TabIndex = 8;
            this.btnAllStatus.Text = "TODO";
            this.btnAllStatus.UseVisualStyleBackColor = true;
            this.btnAllStatus.Click += new System.EventHandler(this.btnAllStatus_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Location = new System.Drawing.Point(287, 23);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(52, 22);
            this.btnSelectNone.TabIndex = 9;
            this.btnSelectNone.Text = "NADA";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ckLiberado);
            this.panel1.Controls.Add(this.btnSelectNone);
            this.panel1.Controls.Add(this.ckRestringido);
            this.panel1.Controls.Add(this.btnAllStatus);
            this.panel1.Controls.Add(this.ckComprometido);
            this.panel1.Controls.Add(this.ckReservaPF);
            this.panel1.Controls.Add(this.ckFE);
            this.panel1.Controls.Add(this.ckReservaRE);
            this.panel1.Location = new System.Drawing.Point(743, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 50);
            this.panel1.TabIndex = 10;
            // 
            // txtNumeroLote
            // 
            this.txtNumeroLote.Location = new System.Drawing.Point(223, 54);
            this.txtNumeroLote.Name = "txtNumeroLote";
            this.txtNumeroLote.Size = new System.Drawing.Size(121, 21);
            this.txtNumeroLote.TabIndex = 11;
            this.txtNumeroLote.TextChanged += new System.EventHandler(this.txtNumeroLote_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "MATERIAL";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.DataSource = this.reducedMaterialMasterBindingSource;
            this.cmbMaterial.DisplayMember = "Primario";
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(223, 8);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(121, 21);
            this.cmbMaterial.TabIndex = 13;
            this.cmbMaterial.ValueMember = "Primario";
            this.cmbMaterial.SelectionChangeCommitted += new System.EventHandler(this.cmbMaterial_SelectionChangeCommitted);
            this.cmbMaterial.TextUpdate += new System.EventHandler(this.cmbMaterial_TextUpdate);
            this.cmbMaterial.Enter += new System.EventHandler(this.cmbMaterial_Enter);
            // 
            // reducedMaterialMasterBindingSource
            // 
            this.reducedMaterialMasterBindingSource.DataSource = typeof(TecserEF.Entity.DataStructure.ReducedMaterialMaster);
            // 
            // grpSeleccionMaterial
            // 
            this.grpSeleccionMaterial.Controls.Add(this.rbAka);
            this.grpSeleccionMaterial.Controls.Add(this.rbPrimario);
            this.grpSeleccionMaterial.Location = new System.Drawing.Point(12, 8);
            this.grpSeleccionMaterial.Name = "grpSeleccionMaterial";
            this.grpSeleccionMaterial.Size = new System.Drawing.Size(110, 64);
            this.grpSeleccionMaterial.TabIndex = 14;
            this.grpSeleccionMaterial.TabStop = false;
            this.grpSeleccionMaterial.Text = "Seleccion Material";
            // 
            // rbAka
            // 
            this.rbAka.AutoSize = true;
            this.rbAka.Location = new System.Drawing.Point(10, 39);
            this.rbAka.Name = "rbAka";
            this.rbAka.Size = new System.Drawing.Size(43, 17);
            this.rbAka.TabIndex = 1;
            this.rbAka.TabStop = true;
            this.rbAka.Text = "AKA";
            this.rbAka.UseVisualStyleBackColor = true;
            this.rbAka.CheckedChanged += new System.EventHandler(this.rbPrimario_CheckedChanged);
            // 
            // rbPrimario
            // 
            this.rbPrimario.AutoSize = true;
            this.rbPrimario.Location = new System.Drawing.Point(10, 18);
            this.rbPrimario.Name = "rbPrimario";
            this.rbPrimario.Size = new System.Drawing.Size(66, 17);
            this.rbPrimario.TabIndex = 0;
            this.rbPrimario.TabStop = true;
            this.rbPrimario.Text = "Primario";
            this.rbPrimario.UseVisualStyleBackColor = true;
            this.rbPrimario.CheckedChanged += new System.EventHandler(this.rbPrimario_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "NUMERO LOTE";
            // 
            // cmbSloc
            // 
            this.cmbSloc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSloc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSloc.DataSource = this.t0028SLOCBindingSource;
            this.cmbSloc.DisplayMember = "SLOC";
            this.cmbSloc.FormattingEnabled = true;
            this.cmbSloc.Location = new System.Drawing.Point(262, 31);
            this.cmbSloc.Name = "cmbSloc";
            this.cmbSloc.Size = new System.Drawing.Size(82, 21);
            this.cmbSloc.TabIndex = 19;
            this.cmbSloc.ValueMember = "SLOC";
            this.cmbSloc.SelectedIndexChanged += new System.EventHandler(this.cmbSloc_SelectedIndexChanged);
            this.cmbSloc.TextUpdate += new System.EventHandler(this.cmbSloc_TextUpdate);
            this.cmbSloc.Enter += new System.EventHandler(this.cmbSloc_Enter);
            // 
            // t0028SLOCBindingSource
            // 
            this.t0028SLOCBindingSource.DataSource = typeof(TecserEF.Entity.T0028_SLOC);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "UBICACION [SLOC]";
            // 
            // txtPlanta
            // 
            this.txtPlanta.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPlanta.Location = new System.Drawing.Point(223, 31);
            this.txtPlanta.Name = "txtPlanta";
            this.txtPlanta.ReadOnly = true;
            this.txtPlanta.Size = new System.Drawing.Size(37, 21);
            this.txtPlanta.TabIndex = 20;
            this.txtPlanta.Text = "CERR";
            this.txtPlanta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSlocDescription
            // 
            this.txtSlocDescription.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSlocDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.t0028SLOCBindingSource, "SLOC_DESC", true));
            this.txtSlocDescription.Location = new System.Drawing.Point(346, 31);
            this.txtSlocDescription.Name = "txtSlocDescription";
            this.txtSlocDescription.ReadOnly = true;
            this.txtSlocDescription.Size = new System.Drawing.Size(269, 21);
            this.txtSlocDescription.TabIndex = 21;
            // 
            // txtPrimaryDescription
            // 
            this.txtPrimaryDescription.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPrimaryDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.reducedMaterialMasterBindingSource, "Descripcion1", true));
            this.txtPrimaryDescription.Location = new System.Drawing.Point(346, 8);
            this.txtPrimaryDescription.Name = "txtPrimaryDescription";
            this.txtPrimaryDescription.ReadOnly = true;
            this.txtPrimaryDescription.Size = new System.Drawing.Size(269, 21);
            this.txtPrimaryDescription.TabIndex = 22;
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.ForeColor = System.Drawing.Color.Navy;
            this.btnResetFilters.Location = new System.Drawing.Point(1134, 87);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(104, 40);
            this.btnResetFilters.TabIndex = 23;
            this.btnResetFilters.Text = "RESET\r\nFILTER";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 14);
            this.label5.TabIndex = 25;
            this.label5.Text = "Kg Seleccion";
            // 
            // txtKgSeleccionados
            // 
            this.txtKgSeleccionados.BackColor = System.Drawing.Color.Gainsboro;
            this.txtKgSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKgSeleccionados.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgSeleccionados.ForeColor = System.Drawing.Color.Black;
            this.txtKgSeleccionados.Location = new System.Drawing.Point(77, 28);
            this.txtKgSeleccionados.Name = "txtKgSeleccionados";
            this.txtKgSeleccionados.ReadOnly = true;
            this.txtKgSeleccionados.Size = new System.Drawing.Size(75, 22);
            this.txtKgSeleccionados.TabIndex = 24;
            this.txtKgSeleccionados.Text = "0";
            this.txtKgSeleccionados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 14);
            this.label6.TabIndex = 27;
            this.label6.Text = "Seleccion #";
            // 
            // txtLineasStock
            // 
            this.txtLineasStock.BackColor = System.Drawing.Color.Gainsboro;
            this.txtLineasStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLineasStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineasStock.ForeColor = System.Drawing.Color.Black;
            this.txtLineasStock.Location = new System.Drawing.Point(77, 4);
            this.txtLineasStock.Name = "txtLineasStock";
            this.txtLineasStock.ReadOnly = true;
            this.txtLineasStock.Size = new System.Drawing.Size(75, 22);
            this.txtLineasStock.TabIndex = 26;
            this.txtLineasStock.Text = "0";
            this.txtLineasStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Purple;
            this.button1.Location = new System.Drawing.Point(1134, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 40);
            this.button1.TabIndex = 28;
            this.button1.Text = "Refresh\r\nData";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAltaNewLine
            // 
            this.btnAltaNewLine.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAltaNewLine.ForeColor = System.Drawing.Color.Navy;
            this.btnAltaNewLine.Image = ((System.Drawing.Image)(resources.GetObject("btnAltaNewLine.Image")));
            this.btnAltaNewLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltaNewLine.Location = new System.Drawing.Point(1134, 295);
            this.btnAltaNewLine.Name = "btnAltaNewLine";
            this.btnAltaNewLine.Size = new System.Drawing.Size(104, 40);
            this.btnAltaNewLine.TabIndex = 31;
            this.btnAltaNewLine.Text = "Alta Nuevo\r\nStock";
            this.btnAltaNewLine.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAltaNewLine.UseVisualStyleBackColor = true;
            this.btnAltaNewLine.Click += new System.EventHandler(this.btnAltaNewLine_Click);
            // 
            // ckSoloConStock
            // 
            this.ckSoloConStock.BackColor = System.Drawing.Color.Pink;
            this.ckSoloConStock.Location = new System.Drawing.Point(12, 88);
            this.ckSoloConStock.Name = "ckSoloConStock";
            this.ckSoloConStock.Size = new System.Drawing.Size(141, 17);
            this.ckSoloConStock.TabIndex = 10;
            this.ckSoloConStock.Text = "BUSCAR SOLO CON STOCK";
            this.ckSoloConStock.UseVisualStyleBackColor = false;
            this.ckSoloConStock.CheckedChanged += new System.EventHandler(this.ckSoloConStock_CheckedChanged);
            // 
            // ckBusquedaLibre
            // 
            this.ckBusquedaLibre.BackColor = System.Drawing.Color.LightGreen;
            this.ckBusquedaLibre.Checked = true;
            this.ckBusquedaLibre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBusquedaLibre.Location = new System.Drawing.Point(159, 88);
            this.ckBusquedaLibre.Name = "ckBusquedaLibre";
            this.ckBusquedaLibre.Size = new System.Drawing.Size(141, 17);
            this.ckBusquedaLibre.TabIndex = 32;
            this.ckBusquedaLibre.Text = "BUSQUEDA LIBRE";
            this.ckBusquedaLibre.UseVisualStyleBackColor = false;
            this.ckBusquedaLibre.CheckedChanged += new System.EventHandler(this.ckBusquedaLibre_CheckedChanged);
            // 
            // txtMaterialBuscar
            // 
            this.txtMaterialBuscar.BackColor = System.Drawing.Color.PaleGreen;
            this.txtMaterialBuscar.Location = new System.Drawing.Point(223, 8);
            this.txtMaterialBuscar.Name = "txtMaterialBuscar";
            this.txtMaterialBuscar.Size = new System.Drawing.Size(121, 21);
            this.txtMaterialBuscar.TabIndex = 33;
            this.txtMaterialBuscar.TextChanged += new System.EventHandler(this.txtMaterialBuscar_TextChanged);
            // 
            // btnOptimizacionStock
            // 
            this.btnOptimizacionStock.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptimizacionStock.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnOptimizacionStock.Location = new System.Drawing.Point(1134, 168);
            this.btnOptimizacionStock.Name = "btnOptimizacionStock";
            this.btnOptimizacionStock.Size = new System.Drawing.Size(104, 40);
            this.btnOptimizacionStock.TabIndex = 34;
            this.btnOptimizacionStock.Text = "OPTIMIZACION\r\nSTOCK";
            this.btnOptimizacionStock.UseVisualStyleBackColor = true;
            this.btnOptimizacionStock.Click += new System.EventHandler(this.btnOptimizacionStock_Click);
            // 
            // btnFixRedondeo
            // 
            this.btnFixRedondeo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFixRedondeo.ForeColor = System.Drawing.Color.Purple;
            this.btnFixRedondeo.Location = new System.Drawing.Point(1134, 47);
            this.btnFixRedondeo.Name = "btnFixRedondeo";
            this.btnFixRedondeo.Size = new System.Drawing.Size(104, 40);
            this.btnFixRedondeo.TabIndex = 35;
            this.btnFixRedondeo.Text = "FIX\r\nRedondeo";
            this.btnFixRedondeo.UseVisualStyleBackColor = true;
            this.btnFixRedondeo.Click += new System.EventHandler(this.btnFixRedondeo_Click);
            // 
            // btnUpdateLote
            // 
            this.btnUpdateLote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateLote.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateLote.Image")));
            this.btnUpdateLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateLote.Location = new System.Drawing.Point(1134, 377);
            this.btnUpdateLote.Name = "btnUpdateLote";
            this.btnUpdateLote.Size = new System.Drawing.Size(104, 40);
            this.btnUpdateLote.TabIndex = 36;
            this.btnUpdateLote.Text = "Modificar\r\nLOTE#";
            this.btnUpdateLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateLote.UseVisualStyleBackColor = true;
            this.btnUpdateLote.Click += new System.EventHandler(this.BtnUpdateLote_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(744, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "StockID #";
            // 
            // txtIdStockSeleccionado
            // 
            this.txtIdStockSeleccionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdStockSeleccionado.Location = new System.Drawing.Point(796, 60);
            this.txtIdStockSeleccionado.Name = "txtIdStockSeleccionado";
            this.txtIdStockSeleccionado.ReadOnly = true;
            this.txtIdStockSeleccionado.Size = new System.Drawing.Size(63, 21);
            this.txtIdStockSeleccionado.TabIndex = 38;
            this.txtIdStockSeleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRestringirLote
            // 
            this.btnRestringirLote.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestringirLote.Image = ((System.Drawing.Image)(resources.GetObject("btnRestringirLote.Image")));
            this.btnRestringirLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestringirLote.Location = new System.Drawing.Point(1134, 336);
            this.btnRestringirLote.Name = "btnRestringirLote";
            this.btnRestringirLote.Size = new System.Drawing.Size(104, 40);
            this.btnRestringirLote.TabIndex = 40;
            this.btnRestringirLote.Text = "Restringir\r\nLOTE";
            this.btnRestringirLote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestringirLote.UseVisualStyleBackColor = true;
            this.btnRestringirLote.Click += new System.EventHandler(this.BtnRestringirLote_Click);
            // 
            // btnAjusteStock
            // 
            this.btnAjusteStock.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjusteStock.Image = ((System.Drawing.Image)(resources.GetObject("btnAjusteStock.Image")));
            this.btnAjusteStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjusteStock.Location = new System.Drawing.Point(1134, 254);
            this.btnAjusteStock.Name = "btnAjusteStock";
            this.btnAjusteStock.Size = new System.Drawing.Size(104, 40);
            this.btnAjusteStock.TabIndex = 41;
            this.btnAjusteStock.Text = "Ajuste\r\nKG";
            this.btnAjusteStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAjusteStock.UseVisualStyleBackColor = true;
            this.btnAjusteStock.Click += new System.EventHandler(this.BtnAjusteStock_Click);
            // 
            // btnRptStandBy
            // 
            this.btnRptStandBy.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRptStandBy.Image = ((System.Drawing.Image)(resources.GetObject("btnRptStandBy.Image")));
            this.btnRptStandBy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRptStandBy.Location = new System.Drawing.Point(1134, 500);
            this.btnRptStandBy.Name = "btnRptStandBy";
            this.btnRptStandBy.Size = new System.Drawing.Size(104, 40);
            this.btnRptStandBy.TabIndex = 43;
            this.btnRptStandBy.Text = "VER\r\nStandBy";
            this.btnRptStandBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRptStandBy.UseVisualStyleBackColor = true;
            this.btnRptStandBy.Click += new System.EventHandler(this.btnRptStandBy_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1134, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 40);
            this.btnClose.TabIndex = 45;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCompromiso
            // 
            this.btnCompromiso.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompromiso.Image = ((System.Drawing.Image)(resources.GetObject("btnCompromiso.Image")));
            this.btnCompromiso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompromiso.Location = new System.Drawing.Point(1134, 418);
            this.btnCompromiso.Name = "btnCompromiso";
            this.btnCompromiso.Size = new System.Drawing.Size(104, 40);
            this.btnCompromiso.TabIndex = 42;
            this.btnCompromiso.Text = "Admin\r\nCompro";
            this.btnCompromiso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCompromiso.UseVisualStyleBackColor = true;
            this.btnCompromiso.UseWaitCursor = true;
            this.btnCompromiso.Click += new System.EventHandler(this.btnCompromiso_Click);
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
            this.LineaIzq.Size = new System.Drawing.Size(3, 724);
            this.LineaIzq.TabIndex = 161;
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
            this.lineaArriba.Size = new System.Drawing.Size(1241, 3);
            this.lineaArriba.TabIndex = 160;
            // 
            // lineaDerecha
            // 
            this.lineaDerecha.BackColor = System.Drawing.Color.MidnightBlue;
            this.lineaDerecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaDerecha.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaDerecha.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lineaDerecha.Location = new System.Drawing.Point(1240, 2);
            this.lineaDerecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaDerecha.Name = "lineaDerecha";
            this.lineaDerecha.Size = new System.Drawing.Size(3, 724);
            this.lineaDerecha.TabIndex = 163;
            // 
            // lineaAbajo
            // 
            this.lineaAbajo.BackColor = System.Drawing.Color.MidnightBlue;
            this.lineaAbajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaAbajo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaAbajo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lineaAbajo.Location = new System.Drawing.Point(2, 723);
            this.lineaAbajo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaAbajo.Name = "lineaAbajo";
            this.lineaAbajo.Size = new System.Drawing.Size(1241, 3);
            this.lineaAbajo.TabIndex = 162;
            // 
            // btnReservaRe
            // 
            this.btnReservaRe.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservaRe.Image = ((System.Drawing.Image)(resources.GetObject("btnReservaRe.Image")));
            this.btnReservaRe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservaRe.Location = new System.Drawing.Point(1134, 459);
            this.btnReservaRe.Name = "btnReservaRe";
            this.btnReservaRe.Size = new System.Drawing.Size(104, 40);
            this.btnReservaRe.TabIndex = 164;
            this.btnReservaRe.Text = "Admin\r\n ReservaRE";
            this.btnReservaRe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReservaRe.UseVisualStyleBackColor = true;
            this.btnReservaRe.UseWaitCursor = true;
            this.btnReservaRe.Click += new System.EventHandler(this.btnReservaRe_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtLineasStock);
            this.panel2.Controls.Add(this.txtKgSeleccionados);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(418, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 53);
            this.panel2.TabIndex = 165;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(154, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 14);
            this.label8.TabIndex = 29;
            this.label8.Text = "[Recs]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 14);
            this.label7.TabIndex = 28;
            this.label7.Text = "[Kg]";
            // 
            // FrmCq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1246, 728);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAltaNewLine);
            this.Controls.Add(this.btnReservaRe);
            this.Controls.Add(this.btnAjusteStock);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.lineaDerecha);
            this.Controls.Add(this.lineaAbajo);
            this.Controls.Add(this.btnCompromiso);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdateLote);
            this.Controls.Add(this.btnRptStandBy);
            this.Controls.Add(this.txtIdStockSeleccionado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFixRedondeo);
            this.Controls.Add(this.btnRestringirLote);
            this.Controls.Add(this.btnOptimizacionStock);
            this.Controls.Add(this.txtMaterialBuscar);
            this.Controls.Add(this.ckBusquedaLibre);
            this.Controls.Add(this.ckSoloConStock);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnResetFilters);
            this.Controls.Add(this.txtPrimaryDescription);
            this.Controls.Add(this.txtSlocDescription);
            this.Controls.Add(this.txtPlanta);
            this.Controls.Add(this.cmbSloc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpSeleccionMaterial);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumeroLote);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvStockList);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCq";
            this.Text = "WM00 - Stock General de Planta";
            this.Load += new System.EventHandler(this.FrmCQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cqStockStructureBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reducedMaterialMasterBindingSource)).EndInit();
            this.grpSeleccionMaterial.ResumeLayout(false);
            this.grpSeleccionMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStockList;
        private System.Windows.Forms.BindingSource cqStockStructureBindingSource;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox ckLiberado;
        private System.Windows.Forms.CheckBox ckRestringido;
        private System.Windows.Forms.CheckBox ckComprometido;
        private System.Windows.Forms.CheckBox ckReservaPF;
        private System.Windows.Forms.CheckBox ckReservaRE;
        private System.Windows.Forms.CheckBox ckFE;
        private System.Windows.Forms.Button btnAllStatus;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNumeroLote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.GroupBox grpSeleccionMaterial;
        private System.Windows.Forms.RadioButton rbAka;
        private System.Windows.Forms.RadioButton rbPrimario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSloc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlanta;
        private System.Windows.Forms.BindingSource t0028SLOCBindingSource;
        private System.Windows.Forms.TextBox txtSlocDescription;
        private System.Windows.Forms.TextBox txtPrimaryDescription;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKgSeleccionados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLineasStock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAltaNewLine;
        private System.Windows.Forms.BindingSource reducedMaterialMasterBindingSource;
        private System.Windows.Forms.CheckBox ckSoloConStock;
        private System.Windows.Forms.CheckBox ckBusquedaLibre;
        private System.Windows.Forms.TextBox txtMaterialBuscar;
        private System.Windows.Forms.Button btnOptimizacionStock;
        private System.Windows.Forms.Button btnFixRedondeo;
        private System.Windows.Forms.Button btnUpdateLote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdStockSeleccionado;
        private System.Windows.Forms.Button btnRestringirLote;
        private System.Windows.Forms.Button btnAjusteStock;
        private System.Windows.Forms.Button btnRptStandBy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCompromiso;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Label lineaDerecha;
        private System.Windows.Forms.Label lineaAbajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idstock;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialType;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalKgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrdenVentaReserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoReservaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialOF;
        private System.Windows.Forms.DataGridViewButtonColumn ACCION;
        private System.Windows.Forms.DataGridViewButtonColumn MOVE;
        private System.Windows.Forms.DataGridViewButtonColumn QM;
        private System.Windows.Forms.Button btnReservaRe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}