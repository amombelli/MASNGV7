namespace MASngFE.Transactional.MM
{
    partial class FrmMM67FasonExternoMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMM67FasonExternoMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMaterialEnviar = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNumeroRemito = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.t0010MATERIALESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdFE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListaMaterial = new System.Windows.Forms.DataGridView();
            this.iDStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLOCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t0030STOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtIdStock = new System.Windows.Forms.TextBox();
            this.cDiferenciaPorc = new TSControls.CtlTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cCantidadRecibir = new TSControls.CtlTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSloc = new System.Windows.Forms.TextBox();
            this.cKgEnviar = new TSControls.CtlTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.t0005MPROVEEDORESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtLoteSeleciconado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProductoRecibir = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0005MPROVEEDORESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(538, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 48);
            this.btnClose.TabIndex = 161;
            this.btnClose.Text = "SALIR";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 163;
            this.label1.Text = "Producto [Enviar]";
            // 
            // cmbMaterialEnviar
            // 
            this.cmbMaterialEnviar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMaterialEnviar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterialEnviar.FormattingEnabled = true;
            this.cmbMaterialEnviar.Location = new System.Drawing.Point(119, 5);
            this.cmbMaterialEnviar.Name = "cmbMaterialEnviar";
            this.cmbMaterialEnviar.Size = new System.Drawing.Size(146, 23);
            this.cmbMaterialEnviar.TabIndex = 162;
            this.cmbMaterialEnviar.SelectedIndexChanged += new System.EventHandler(this.cmbMaterialEnviar_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.txtNumeroRemito);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbMaterialEnviar);
            this.panel1.Location = new System.Drawing.Point(17, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 57);
            this.panel1.TabIndex = 164;
            // 
            // txtNumeroRemito
            // 
            this.txtNumeroRemito.BeepOnError = true;
            this.txtNumeroRemito.Location = new System.Drawing.Point(119, 29);
            this.txtNumeroRemito.Mask = "0000-00000000";
            this.txtNumeroRemito.Name = "txtNumeroRemito";
            this.txtNumeroRemito.Size = new System.Drawing.Size(100, 21);
            this.txtNumeroRemito.TabIndex = 184;
            this.txtNumeroRemito.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtNumeroRemito_MaskInputRejected);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 15);
            this.label14.TabIndex = 183;
            this.label14.Text = "Remito #";
            // 
            // t0010MATERIALESBindingSource
            // 
            this.t0010MATERIALESBindingSource.DataSource = typeof(TecserEF.Entity.T0010_MATERIALES);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtStatus);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpFecha);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtIdFE);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(17, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 52);
            this.panel2.TabIndex = 165;
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(270, 4);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(109, 21);
            this.txtStatus.TabIndex = 171;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 170;
            this.label4.Text = "Estado";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(119, 26);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(260, 21);
            this.dtpFecha.TabIndex = 169;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 167;
            this.label3.Text = "Fecha Orden";
            // 
            // txtIdFE
            // 
            this.txtIdFE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdFE.Location = new System.Drawing.Point(119, 4);
            this.txtIdFE.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdFE.Name = "txtIdFE";
            this.txtIdFE.ReadOnly = true;
            this.txtIdFE.Size = new System.Drawing.Size(43, 21);
            this.txtIdFE.TabIndex = 166;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 163;
            this.label2.Text = "Orden Proceso FE";
            // 
            // dgvListaMaterial
            // 
            this.dgvListaMaterial.AllowUserToAddRows = false;
            this.dgvListaMaterial.AllowUserToDeleteRows = false;
            this.dgvListaMaterial.AutoGenerateColumns = false;
            this.dgvListaMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDStockDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.batchDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.sLOCDataGridViewTextBoxColumn});
            this.dgvListaMaterial.DataSource = this.t0030STOCKBindingSource;
            this.dgvListaMaterial.Location = new System.Drawing.Point(17, 130);
            this.dgvListaMaterial.MultiSelect = false;
            this.dgvListaMaterial.Name = "dgvListaMaterial";
            this.dgvListaMaterial.ReadOnly = true;
            this.dgvListaMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaMaterial.Size = new System.Drawing.Size(478, 183);
            this.dgvListaMaterial.TabIndex = 169;
            this.dgvListaMaterial.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaMaterial_CellEnter);
            // 
            // iDStockDataGridViewTextBoxColumn
            // 
            this.iDStockDataGridViewTextBoxColumn.DataPropertyName = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.HeaderText = "IDStock";
            this.iDStockDataGridViewTextBoxColumn.Name = "iDStockDataGridViewTextBoxColumn";
            this.iDStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDStockDataGridViewTextBoxColumn.Visible = false;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // batchDataGridViewTextBoxColumn
            // 
            this.batchDataGridViewTextBoxColumn.DataPropertyName = "Batch";
            this.batchDataGridViewTextBoxColumn.HeaderText = "Lote #";
            this.batchDataGridViewTextBoxColumn.Name = "batchDataGridViewTextBoxColumn";
            this.batchDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchDataGridViewTextBoxColumn.ToolTipText = "Numero de Lote";
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Format = "N2";
            this.stockDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.stockDataGridViewTextBoxColumn.HeaderText = "Stock";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            this.stockDataGridViewTextBoxColumn.ToolTipText = "Kg Stock";
            this.stockDataGridViewTextBoxColumn.Width = 80;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.ToolTipText = "Estado del Material";
            // 
            // sLOCDataGridViewTextBoxColumn
            // 
            this.sLOCDataGridViewTextBoxColumn.DataPropertyName = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.HeaderText = "SLOC";
            this.sLOCDataGridViewTextBoxColumn.Name = "sLOCDataGridViewTextBoxColumn";
            this.sLOCDataGridViewTextBoxColumn.ReadOnly = true;
            this.sLOCDataGridViewTextBoxColumn.Width = 50;
            // 
            // t0030STOCKBindingSource
            // 
            this.t0030STOCKBindingSource.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtIdStock);
            this.panel3.Controls.Add(this.cDiferenciaPorc);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.cCantidadRecibir);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.txtSloc);
            this.panel3.Controls.Add(this.cKgEnviar);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cmbProveedor);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtLoteSeleciconado);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cmbProductoRecibir);
            this.panel3.Location = new System.Drawing.Point(17, 316);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 127);
            this.panel3.TabIndex = 165;
            // 
            // txtIdStock
            // 
            this.txtIdStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdStock.Location = new System.Drawing.Point(419, 29);
            this.txtIdStock.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdStock.Name = "txtIdStock";
            this.txtIdStock.ReadOnly = true;
            this.txtIdStock.Size = new System.Drawing.Size(53, 21);
            this.txtIdStock.TabIndex = 183;
            // 
            // cDiferenciaPorc
            // 
            this.cDiferenciaPorc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cDiferenciaPorc.BackColor = System.Drawing.Color.Gainsboro;
            this.cDiferenciaPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cDiferenciaPorc.Location = new System.Drawing.Point(301, 102);
            this.cDiferenciaPorc.Margin = new System.Windows.Forms.Padding(0);
            this.cDiferenciaPorc.Name = "cDiferenciaPorc";
            this.cDiferenciaPorc.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cDiferenciaPorc.SetDecimales = 2;
            this.cDiferenciaPorc.SetType = TSControls.CtlTextBox.TextBoxType.Porcentaje;
            this.cDiferenciaPorc.Size = new System.Drawing.Size(78, 21);
            this.cDiferenciaPorc.TabIndex = 182;
            this.cDiferenciaPorc.ValorMaximo = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.cDiferenciaPorc.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cDiferenciaPorc.XReadOnly = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(225, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 15);
            this.label13.TabIndex = 181;
            this.label13.Text = "Diferencia %";
            // 
            // cCantidadRecibir
            // 
            this.cCantidadRecibir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cCantidadRecibir.BackColor = System.Drawing.Color.White;
            this.cCantidadRecibir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cCantidadRecibir.Location = new System.Drawing.Point(127, 102);
            this.cCantidadRecibir.Margin = new System.Windows.Forms.Padding(0);
            this.cCantidadRecibir.Name = "cCantidadRecibir";
            this.cCantidadRecibir.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cCantidadRecibir.SetDecimales = 2;
            this.cCantidadRecibir.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.cCantidadRecibir.Size = new System.Drawing.Size(71, 21);
            this.cCantidadRecibir.TabIndex = 180;
             this.cCantidadRecibir.ValorMaximo = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.cCantidadRecibir.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cCantidadRecibir.XReadOnly = false;
            this.cCantidadRecibir.Validating += new System.ComponentModel.CancelEventHandler(this.cCantidadRecibir_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 15);
            this.label12.TabIndex = 179;
            this.label12.Text = "Cantidad A Recibir";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(376, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 15);
            this.label21.TabIndex = 178;
            this.label21.Text = "SLOC";
            // 
            // txtSloc
            // 
            this.txtSloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSloc.Location = new System.Drawing.Point(419, 6);
            this.txtSloc.Margin = new System.Windows.Forms.Padding(2);
            this.txtSloc.Name = "txtSloc";
            this.txtSloc.ReadOnly = true;
            this.txtSloc.Size = new System.Drawing.Size(53, 21);
            this.txtSloc.TabIndex = 177;
            // 
            // cKgEnviar
            // 
            this.cKgEnviar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cKgEnviar.BackColor = System.Drawing.Color.White;
            this.cKgEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cKgEnviar.Location = new System.Drawing.Point(127, 29);
            this.cKgEnviar.Margin = new System.Windows.Forms.Padding(0);
            this.cKgEnviar.Name = "cKgEnviar";
            this.cKgEnviar.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cKgEnviar.SetDecimales = 2;
            this.cKgEnviar.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.cKgEnviar.Size = new System.Drawing.Size(71, 21);
            this.cKgEnviar.TabIndex = 175;
            this.cKgEnviar.ValorMaximo = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.cKgEnviar.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cKgEnviar.XReadOnly = false;
            this.cKgEnviar.Validating += new System.ComponentModel.CancelEventHandler(this.cKgEnviar_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 15);
            this.label8.TabIndex = 176;
            this.label8.Text = "Proveedor Fason";
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DataSource = this.t0005MPROVEEDORESBindingSource;
            this.cmbProveedor.DisplayMember = "prov_rsocial";
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(127, 52);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(345, 23);
            this.cmbProveedor.TabIndex = 175;
            this.cmbProveedor.ValueMember = "id_prov";
            // 
            // t0005MPROVEEDORESBindingSource
            // 
            this.t0005MPROVEEDORESBindingSource.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 173;
            this.label7.Text = "KG a Enviar";
            // 
            // txtLoteSeleciconado
            // 
            this.txtLoteSeleciconado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteSeleciconado.Location = new System.Drawing.Point(127, 6);
            this.txtLoteSeleciconado.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoteSeleciconado.Name = "txtLoteSeleciconado";
            this.txtLoteSeleciconado.ReadOnly = true;
            this.txtLoteSeleciconado.Size = new System.Drawing.Size(109, 21);
            this.txtLoteSeleciconado.TabIndex = 172;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 15);
            this.label6.TabIndex = 164;
            this.label6.Text = "Lote Seleccionado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 15);
            this.label5.TabIndex = 163;
            this.label5.Text = "Producto A Recibir";
            // 
            // cmbProductoRecibir
            // 
            this.cmbProductoRecibir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbProductoRecibir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProductoRecibir.DisplayMember = "IDMATERIAL";
            this.cmbProductoRecibir.FormattingEnabled = true;
            this.cmbProductoRecibir.Location = new System.Drawing.Point(127, 77);
            this.cmbProductoRecibir.Name = "cmbProductoRecibir";
            this.cmbProductoRecibir.Size = new System.Drawing.Size(164, 23);
            this.cmbProductoRecibir.TabIndex = 162;
            this.cmbProductoRecibir.ValueMember = "IDMATERIAL";
            this.cmbProductoRecibir.SelectedIndexChanged += new System.EventHandler(this.cmbProductoRecibir_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Maroon;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(2, 2);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(646, 4);
            this.label9.TabIndex = 170;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Maroon;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(2, 450);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(646, 4);
            this.label10.TabIndex = 171;
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.Maroon;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 451);
            this.LineaIzq.TabIndex = 172;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Maroon;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(644, 3);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(3, 450);
            this.label11.TabIndex = 173;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(538, 57);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(103, 48);
            this.btnGenerar.TabIndex = 174;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(538, 105);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 48);
            this.btnCancelar.TabIndex = 175;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(538, 154);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(103, 48);
            this.btnEnviar.TabIndex = 180;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(379, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 15);
            this.label15.TabIndex = 184;
            this.label15.Text = "IDStk";
            // 
            // FrmMM67FasonExternoMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 456);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvListaMaterial);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMM67FasonExternoMain";
            this.Text = "MM67 - Fason Externo";
            this.Load += new System.EventHandler(this.FrmMM67FasonExternoMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0010MATERIALESBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0005MPROVEEDORESBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMaterialEnviar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource t0010MATERIALESBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdFE;
        private System.Windows.Forms.DataGridView dgvListaMaterial;
        private System.Windows.Forms.BindingSource t0030STOCKBindingSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.BindingSource t0005MPROVEEDORESBindingSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLoteSeleciconado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProductoRecibir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnGenerar;
        private TSControls.CtlTextBox cKgEnviar;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLOCDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSloc;
        private TSControls.CtlTextBox cCantidadRecibir;
        private System.Windows.Forms.Label label12;
        private TSControls.CtlTextBox cDiferenciaPorc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtNumeroRemito;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtIdStock;
        private System.Windows.Forms.Label label15;
    }
}