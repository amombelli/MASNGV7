namespace MASngFE.Transactional.MM.Orden_de_Compra
{
    partial class FrmMM20BuscadorOC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMM20BuscadorOC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVendorListNewOC = new System.Windows.Forms.DataGridView();
            this.dgvOrdenCompra = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVerRC = new System.Windows.Forms.Button();
            this.btnDetalleProveedor = new System.Windows.Forms.Button();
            this.btnInforRecord = new System.Windows.Forms.Button();
            this.btnVerUltimasOC = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.iDORDENCOMPRADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROVEEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHAOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTATUSOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fECHARECIBIDODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONEDAOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VER = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EDIT = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OCCompletoBs = new System.Windows.Forms.BindingSource(this.components);
            this.idprovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provrsocialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provfantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCTIVODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.T0005DgvBs = new System.Windows.Forms.BindingSource(this.components);
            this.T0060OCBs = new System.Windows.Forms.BindingSource(this.components);
            this.uVendorSearch1 = new MASngFE._UserControls.UVendorSearch();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorListNewOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OCCompletoBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005DgvBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0060OCBs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVendorListNewOC
            // 
            this.dgvVendorListNewOC.AllowUserToAddRows = false;
            this.dgvVendorListNewOC.AllowUserToDeleteRows = false;
            this.dgvVendorListNewOC.AutoGenerateColumns = false;
            this.dgvVendorListNewOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorListNewOC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idprovDataGridViewTextBoxColumn,
            this.provrsocialDataGridViewTextBoxColumn,
            this.provfantasiaDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.aCTIVODataGridViewTextBoxColumn,
            this.Accion});
            this.dgvVendorListNewOC.DataSource = this.T0005DgvBs;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVendorListNewOC.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVendorListNewOC.GridColor = System.Drawing.Color.Navy;
            this.dgvVendorListNewOC.Location = new System.Drawing.Point(8, 142);
            this.dgvVendorListNewOC.Name = "dgvVendorListNewOC";
            this.dgvVendorListNewOC.ReadOnly = true;
            this.dgvVendorListNewOC.RowHeadersWidth = 20;
            this.dgvVendorListNewOC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendorListNewOC.Size = new System.Drawing.Size(645, 195);
            this.dgvVendorListNewOC.TabIndex = 78;
            this.dgvVendorListNewOC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendorList_CellContentClick);
            this.dgvVendorListNewOC.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendorList_CellEnter);
            // 
            // dgvOrdenCompra
            // 
            this.dgvOrdenCompra.AllowUserToAddRows = false;
            this.dgvOrdenCompra.AllowUserToDeleteRows = false;
            this.dgvOrdenCompra.AutoGenerateColumns = false;
            this.dgvOrdenCompra.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvOrdenCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDORDENCOMPRADataGridViewTextBoxColumn,
            this.Column1,
            this.PROVEEDOR,
            this.fECHAOCDataGridViewTextBoxColumn,
            this.sTATUSOCDataGridViewTextBoxColumn,
            this.fECHARECIBIDODataGridViewTextBoxColumn,
            this.mONEDAOCDataGridViewTextBoxColumn,
            this.totalOCDataGridViewTextBoxColumn,
            this.observacionOCDataGridViewTextBoxColumn,
            this.VER,
            this.EDIT});
            this.dgvOrdenCompra.DataSource = this.OCCompletoBs;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrdenCompra.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrdenCompra.GridColor = System.Drawing.Color.Indigo;
            this.dgvOrdenCompra.Location = new System.Drawing.Point(8, 359);
            this.dgvOrdenCompra.Name = "dgvOrdenCompra";
            this.dgvOrdenCompra.ReadOnly = true;
            this.dgvOrdenCompra.RowHeadersWidth = 20;
            this.dgvOrdenCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenCompra.Size = new System.Drawing.Size(832, 367);
            this.dgvOrdenCompra.TabIndex = 79;
            this.dgvOrdenCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenCompra_CellContentClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(8, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(832, 19);
            this.label1.TabIndex = 80;
            this.label1.Text = "LISTADO DE ORDENES DE COMPRA EMITIDAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.IndianRed;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 727);
            this.LineaIzq.TabIndex = 167;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.IndianRed;
            this.lineaArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.Location = new System.Drawing.Point(2, 2);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(843, 3);
            this.lineaArriba.TabIndex = 166;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.IndianRed;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(842, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 727);
            this.label2.TabIndex = 169;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.IndianRed;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 729);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(843, 3);
            this.label3.TabIndex = 170;
            // 
            // btnVerRC
            // 
            this.btnVerRC.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerRC.Image = ((System.Drawing.Image)(resources.GetObject("btnVerRC.Image")));
            this.btnVerRC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerRC.Location = new System.Drawing.Point(740, 183);
            this.btnVerRC.Name = "btnVerRC";
            this.btnVerRC.Size = new System.Drawing.Size(100, 40);
            this.btnVerRC.TabIndex = 168;
            this.btnVerRC.Text = "RC\r\nPendiente";
            this.btnVerRC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerRC.UseVisualStyleBackColor = true;
            this.btnVerRC.Click += new System.EventHandler(this.btnVerRC_Click);
            // 
            // btnDetalleProveedor
            // 
            this.btnDetalleProveedor.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleProveedor.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleProveedor.Image")));
            this.btnDetalleProveedor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleProveedor.Location = new System.Drawing.Point(740, 45);
            this.btnDetalleProveedor.Name = "btnDetalleProveedor";
            this.btnDetalleProveedor.Size = new System.Drawing.Size(100, 40);
            this.btnDetalleProveedor.TabIndex = 82;
            this.btnDetalleProveedor.Text = "Detalle\r\nProveedor";
            this.btnDetalleProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleProveedor.UseVisualStyleBackColor = true;
            this.btnDetalleProveedor.Click += new System.EventHandler(this.btnDetalleProveedor_Click);
            // 
            // btnInforRecord
            // 
            this.btnInforRecord.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInforRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnInforRecord.Image")));
            this.btnInforRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInforRecord.Location = new System.Drawing.Point(740, 125);
            this.btnInforRecord.Name = "btnInforRecord";
            this.btnInforRecord.Size = new System.Drawing.Size(100, 40);
            this.btnInforRecord.TabIndex = 81;
            this.btnInforRecord.Text = "Info\r\nRecord";
            this.btnInforRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInforRecord.UseVisualStyleBackColor = true;
            this.btnInforRecord.Click += new System.EventHandler(this.btnInforRecord_Click);
            // 
            // btnVerUltimasOC
            // 
            this.btnVerUltimasOC.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerUltimasOC.Image = global::MASngFE.Properties.Resources.seo;
            this.btnVerUltimasOC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerUltimasOC.Location = new System.Drawing.Point(740, 85);
            this.btnVerUltimasOC.Name = "btnVerUltimasOC";
            this.btnVerUltimasOC.Size = new System.Drawing.Size(100, 40);
            this.btnVerUltimasOC.TabIndex = 76;
            this.btnVerUltimasOC.Text = "Ultimas\r\nOC";
            this.btnVerUltimasOC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerUltimasOC.UseVisualStyleBackColor = true;
            this.btnVerUltimasOC.Click += new System.EventHandler(this.btnVerUltimasOC_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(740, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 75;
            this.btnCancelar.Text = "SALIR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Nueva";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "Nueva";
            this.dataGridViewButtonColumn1.ToolTipText = "Genera una nueva Orden de Compra";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 50;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Ver";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Text = "VER";
            this.dataGridViewButtonColumn2.ToolTipText = "Visualizar una Orden de Compra";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn2.Width = 40;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "Edit";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.ReadOnly = true;
            this.dataGridViewButtonColumn3.Text = "EDIT";
            this.dataGridViewButtonColumn3.ToolTipText = "Editar Orden de Compra";
            this.dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn3.Width = 40;
            // 
            // iDORDENCOMPRADataGridViewTextBoxColumn
            // 
            this.iDORDENCOMPRADataGridViewTextBoxColumn.DataPropertyName = "IDORDENCOMPRA";
            this.iDORDENCOMPRADataGridViewTextBoxColumn.HeaderText = "OC";
            this.iDORDENCOMPRADataGridViewTextBoxColumn.Name = "iDORDENCOMPRADataGridViewTextBoxColumn";
            this.iDORDENCOMPRADataGridViewTextBoxColumn.ReadOnly = true;
            this.iDORDENCOMPRADataGridViewTextBoxColumn.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RazonSocial";
            this.Column1.HeaderText = "Razon Social";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 180;
            // 
            // PROVEEDOR
            // 
            this.PROVEEDOR.DataPropertyName = "PROVEEDOR";
            this.PROVEEDOR.HeaderText = "Proveedor RS";
            this.PROVEEDOR.Name = "PROVEEDOR";
            this.PROVEEDOR.ReadOnly = true;
            this.PROVEEDOR.Visible = false;
            this.PROVEEDOR.Width = 120;
            // 
            // fECHAOCDataGridViewTextBoxColumn
            // 
            this.fECHAOCDataGridViewTextBoxColumn.DataPropertyName = "FECHAOC";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fECHAOCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fECHAOCDataGridViewTextBoxColumn.HeaderText = "Fecha OC";
            this.fECHAOCDataGridViewTextBoxColumn.Name = "fECHAOCDataGridViewTextBoxColumn";
            this.fECHAOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHAOCDataGridViewTextBoxColumn.Width = 80;
            // 
            // sTATUSOCDataGridViewTextBoxColumn
            // 
            this.sTATUSOCDataGridViewTextBoxColumn.DataPropertyName = "STATUSOC";
            this.sTATUSOCDataGridViewTextBoxColumn.HeaderText = "Status OC";
            this.sTATUSOCDataGridViewTextBoxColumn.Name = "sTATUSOCDataGridViewTextBoxColumn";
            this.sTATUSOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fECHARECIBIDODataGridViewTextBoxColumn
            // 
            this.fECHARECIBIDODataGridViewTextBoxColumn.DataPropertyName = "FECHA_RECIBIDO";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.fECHARECIBIDODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fECHARECIBIDODataGridViewTextBoxColumn.HeaderText = "CierreOC";
            this.fECHARECIBIDODataGridViewTextBoxColumn.Name = "fECHARECIBIDODataGridViewTextBoxColumn";
            this.fECHARECIBIDODataGridViewTextBoxColumn.ReadOnly = true;
            this.fECHARECIBIDODataGridViewTextBoxColumn.Width = 80;
            // 
            // mONEDAOCDataGridViewTextBoxColumn
            // 
            this.mONEDAOCDataGridViewTextBoxColumn.DataPropertyName = "MONEDAOC";
            this.mONEDAOCDataGridViewTextBoxColumn.HeaderText = "Mon";
            this.mONEDAOCDataGridViewTextBoxColumn.Name = "mONEDAOCDataGridViewTextBoxColumn";
            this.mONEDAOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.mONEDAOCDataGridViewTextBoxColumn.Width = 40;
            // 
            // totalOCDataGridViewTextBoxColumn
            // 
            this.totalOCDataGridViewTextBoxColumn.DataPropertyName = "TotalOC";
            dataGridViewCellStyle4.Format = "C2";
            this.totalOCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.totalOCDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalOCDataGridViewTextBoxColumn.Name = "totalOCDataGridViewTextBoxColumn";
            this.totalOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalOCDataGridViewTextBoxColumn.Width = 70;
            // 
            // observacionOCDataGridViewTextBoxColumn
            // 
            this.observacionOCDataGridViewTextBoxColumn.DataPropertyName = "ObservacionOC";
            this.observacionOCDataGridViewTextBoxColumn.HeaderText = "Observacion";
            this.observacionOCDataGridViewTextBoxColumn.Name = "observacionOCDataGridViewTextBoxColumn";
            this.observacionOCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // VER
            // 
            this.VER.HeaderText = "Ver";
            this.VER.Name = "VER";
            this.VER.ReadOnly = true;
            this.VER.Text = "VER";
            this.VER.ToolTipText = "Visualizar una Orden de Compra";
            this.VER.UseColumnTextForButtonValue = true;
            this.VER.Width = 40;
            // 
            // EDIT
            // 
            this.EDIT.HeaderText = "Edit";
            this.EDIT.Name = "EDIT";
            this.EDIT.ReadOnly = true;
            this.EDIT.Text = "EDIT";
            this.EDIT.ToolTipText = "Editar Orden de Compra";
            this.EDIT.UseColumnTextForButtonValue = true;
            this.EDIT.Width = 40;
            // 
            // OCCompletoBs
            // 
            this.OCCompletoBs.DataSource = typeof(TecserEF.Entity.DataStructure.OrdenCompraDgvCompleteo);
            // 
            // idprovDataGridViewTextBoxColumn
            // 
            this.idprovDataGridViewTextBoxColumn.DataPropertyName = "id_prov";
            this.idprovDataGridViewTextBoxColumn.HeaderText = "Prov#";
            this.idprovDataGridViewTextBoxColumn.Name = "idprovDataGridViewTextBoxColumn";
            this.idprovDataGridViewTextBoxColumn.ReadOnly = true;
            this.idprovDataGridViewTextBoxColumn.Width = 60;
            // 
            // provrsocialDataGridViewTextBoxColumn
            // 
            this.provrsocialDataGridViewTextBoxColumn.DataPropertyName = "prov_rsocial";
            this.provrsocialDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.provrsocialDataGridViewTextBoxColumn.Name = "provrsocialDataGridViewTextBoxColumn";
            this.provrsocialDataGridViewTextBoxColumn.ReadOnly = true;
            this.provrsocialDataGridViewTextBoxColumn.Width = 180;
            // 
            // provfantasiaDataGridViewTextBoxColumn
            // 
            this.provfantasiaDataGridViewTextBoxColumn.DataPropertyName = "prov_fantasia";
            this.provfantasiaDataGridViewTextBoxColumn.HeaderText = "Nombre Fantasia";
            this.provfantasiaDataGridViewTextBoxColumn.Name = "provfantasiaDataGridViewTextBoxColumn";
            this.provfantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.provfantasiaDataGridViewTextBoxColumn.Width = 130;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.Width = 70;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.telefonoDataGridViewTextBoxColumn.Width = 80;
            // 
            // aCTIVODataGridViewTextBoxColumn
            // 
            this.aCTIVODataGridViewTextBoxColumn.DataPropertyName = "ACTIVO";
            this.aCTIVODataGridViewTextBoxColumn.HeaderText = "ACT";
            this.aCTIVODataGridViewTextBoxColumn.Name = "aCTIVODataGridViewTextBoxColumn";
            this.aCTIVODataGridViewTextBoxColumn.ReadOnly = true;
            this.aCTIVODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.aCTIVODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.aCTIVODataGridViewTextBoxColumn.Width = 35;
            // 
            // Accion
            // 
            this.Accion.HeaderText = "Nueva";
            this.Accion.Name = "Accion";
            this.Accion.ReadOnly = true;
            this.Accion.Text = "Nueva";
            this.Accion.ToolTipText = "Genera una nueva Orden de Compra";
            this.Accion.UseColumnTextForButtonValue = true;
            this.Accion.Width = 50;
            // 
            // T0005DgvBs
            // 
            this.T0005DgvBs.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // T0060OCBs
            // 
            this.T0060OCBs.DataSource = typeof(TecserEF.Entity.T0060_OCOMPRA_H);
            // 
            // uVendorSearch1
            // 
            this.uVendorSearch1.Location = new System.Drawing.Point(8, 7);
            this.uVendorSearch1.Name = "uVendorSearch1";
            this.uVendorSearch1.Size = new System.Drawing.Size(578, 135);
            this.uVendorSearch1.TabIndex = 0;
            // 
            // FrmMM20BuscadorOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 735);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVerRC);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.btnDetalleProveedor);
            this.Controls.Add(this.btnInforRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOrdenCompra);
            this.Controls.Add(this.dgvVendorListNewOC);
            this.Controls.Add(this.btnVerUltimasOC);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.uVendorSearch1);
            this.Name = "FrmMM20BuscadorOC";
            this.Text = "MM20 Orden de Compra [SearchMain Screen]";
            this.Load += new System.EventHandler(this.FrmMM20OrdenCompraMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorListNewOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OCCompletoBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0005DgvBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T0060OCBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private _UserControls.UVendorSearch uVendorSearch1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVerUltimasOC;
        private System.Windows.Forms.DataGridView dgvVendorListNewOC;
        private System.Windows.Forms.BindingSource T0005DgvBs;
        private System.Windows.Forms.DataGridView dgvOrdenCompra;
        private System.Windows.Forms.BindingSource T0060OCBs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInforRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provrsocialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provfantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aCTIVODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Accion;
        private System.Windows.Forms.Button btnDetalleProveedor;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Button btnVerRC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource OCCompletoBs;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDORDENCOMPRADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROVEEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHAOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTATUSOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fECHARECIBIDODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONEDAOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn VER;
        private System.Windows.Forms.DataGridViewButtonColumn EDIT;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
    }
}