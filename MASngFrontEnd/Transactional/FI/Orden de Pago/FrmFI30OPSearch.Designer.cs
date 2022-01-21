namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    partial class FrmFI30OPSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI30OPSearch));
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEstadoOP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroOP = new System.Windows.Forms.TextBox();
            this.txtSaldoL1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSaldoL2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvOPLista = new System.Windows.Forms.DataGridView();
            this.iDOPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPFECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pROVRSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPOPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteValores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPSTATUSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasPPFacturas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasPPItemsPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.t0210OPHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckAlicuotaIIBB = new System.Windows.Forms.CheckBox();
            this.txtSaldoTotalL2 = new System.Windows.Forms.TextBox();
            this.txtSaldoTotalL1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDetalleDeuda = new System.Windows.Forms.Button();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ctlTextBox1 = new TSControls.CtlTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.tsUcVendorSelector1 = new MASngFE._0TSUserControls.TsUcVendorSelector();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0210OPHBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Estado";
            // 
            // cmbEstadoOP
            // 
            this.cmbEstadoOP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstadoOP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstadoOP.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbEstadoOP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstadoOP.ForeColor = System.Drawing.Color.Blue;
            this.cmbEstadoOP.FormattingEnabled = true;
            this.cmbEstadoOP.Items.AddRange(new object[] {
            "INICIAL",
            "PROCESO",
            "GENERADA",
            "FINALIZADA",
            "CANCELADA"});
            this.cmbEstadoOP.Location = new System.Drawing.Point(86, 3);
            this.cmbEstadoOP.Name = "cmbEstadoOP";
            this.cmbEstadoOP.Size = new System.Drawing.Size(119, 23);
            this.cmbEstadoOP.TabIndex = 28;
            this.cmbEstadoOP.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoOP_SelectedIndexChanged);
            this.cmbEstadoOP.Leave += new System.EventHandler(this.cmbEstadoOP_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Numero Op";
            // 
            // txtNumeroOP
            // 
            this.txtNumeroOP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOP.Location = new System.Drawing.Point(86, 28);
            this.txtNumeroOP.Name = "txtNumeroOP";
            this.txtNumeroOP.Size = new System.Drawing.Size(119, 23);
            this.txtNumeroOP.TabIndex = 31;
            this.txtNumeroOP.TextChanged += new System.EventHandler(this.txtNumeroOP_TextChanged);
            // 
            // txtSaldoL1
            // 
            this.txtSaldoL1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoL1.Location = new System.Drawing.Point(65, 3);
            this.txtSaldoL1.Name = "txtSaldoL1";
            this.txtSaldoL1.Size = new System.Drawing.Size(100, 23);
            this.txtSaldoL1.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "Saldo L1";
            // 
            // txtSaldoL2
            // 
            this.txtSaldoL2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoL2.Location = new System.Drawing.Point(65, 27);
            this.txtSaldoL2.Name = "txtSaldoL2";
            this.txtSaldoL2.Size = new System.Drawing.Size(100, 23);
            this.txtSaldoL2.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "Saldo L2";
            // 
            // dgvOPLista
            // 
            this.dgvOPLista.AllowUserToAddRows = false;
            this.dgvOPLista.AllowUserToDeleteRows = false;
            this.dgvOPLista.AutoGenerateColumns = false;
            this.dgvOPLista.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOPLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOPLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOPLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDOPDataGridViewTextBoxColumn,
            this.oPFECHADataGridViewTextBoxColumn,
            this.pROVRSDataGridViewTextBoxColumn,
            this.iMPOPDataGridViewTextBoxColumn,
            this.ImporteValores,
            this.oPSTATUSDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.DiasPPFacturas,
            this.DiasPPItemsPago,
            this.Detalle});
            this.dgvOPLista.DataSource = this.t0210OPHBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOPLista.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOPLista.GridColor = System.Drawing.Color.DarkBlue;
            this.dgvOPLista.Location = new System.Drawing.Point(7, 161);
            this.dgvOPLista.MultiSelect = false;
            this.dgvOPLista.Name = "dgvOPLista";
            this.dgvOPLista.ReadOnly = true;
            this.dgvOPLista.RowHeadersWidth = 20;
            this.dgvOPLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOPLista.Size = new System.Drawing.Size(908, 564);
            this.dgvOPLista.TabIndex = 37;
            this.dgvOPLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOPLista_CellContentClick);
            // 
            // iDOPDataGridViewTextBoxColumn
            // 
            this.iDOPDataGridViewTextBoxColumn.DataPropertyName = "IDOP";
            this.iDOPDataGridViewTextBoxColumn.HeaderText = "NumeroOP";
            this.iDOPDataGridViewTextBoxColumn.Name = "iDOPDataGridViewTextBoxColumn";
            this.iDOPDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDOPDataGridViewTextBoxColumn.ToolTipText = "Numero de Orden de Pago";
            this.iDOPDataGridViewTextBoxColumn.Width = 80;
            // 
            // oPFECHADataGridViewTextBoxColumn
            // 
            this.oPFECHADataGridViewTextBoxColumn.DataPropertyName = "OPFECHA";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle2.NullValue = null;
            this.oPFECHADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.oPFECHADataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.oPFECHADataGridViewTextBoxColumn.Name = "oPFECHADataGridViewTextBoxColumn";
            this.oPFECHADataGridViewTextBoxColumn.ReadOnly = true;
            this.oPFECHADataGridViewTextBoxColumn.ToolTipText = "Fecha de Orden de Pago";
            // 
            // pROVRSDataGridViewTextBoxColumn
            // 
            this.pROVRSDataGridViewTextBoxColumn.DataPropertyName = "PROV_RS";
            this.pROVRSDataGridViewTextBoxColumn.HeaderText = "Razon Social";
            this.pROVRSDataGridViewTextBoxColumn.Name = "pROVRSDataGridViewTextBoxColumn";
            this.pROVRSDataGridViewTextBoxColumn.ReadOnly = true;
            this.pROVRSDataGridViewTextBoxColumn.ToolTipText = "Razon Social Proveedor";
            this.pROVRSDataGridViewTextBoxColumn.Width = 200;
            // 
            // iMPOPDataGridViewTextBoxColumn
            // 
            this.iMPOPDataGridViewTextBoxColumn.DataPropertyName = "IMP_OP";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.Format = "C2";
            this.iMPOPDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.iMPOPDataGridViewTextBoxColumn.HeaderText = "ImporteOP";
            this.iMPOPDataGridViewTextBoxColumn.Name = "iMPOPDataGridViewTextBoxColumn";
            this.iMPOPDataGridViewTextBoxColumn.ReadOnly = true;
            this.iMPOPDataGridViewTextBoxColumn.ToolTipText = "Importe Total de Orden de Pago";
            this.iMPOPDataGridViewTextBoxColumn.Width = 90;
            // 
            // ImporteValores
            // 
            this.ImporteValores.DataPropertyName = "ImporteValores";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Format = "C2";
            this.ImporteValores.DefaultCellStyle = dataGridViewCellStyle4;
            this.ImporteValores.HeaderText = "ImporteVA";
            this.ImporteValores.Name = "ImporteValores";
            this.ImporteValores.ReadOnly = true;
            this.ImporteValores.ToolTipText = "Importe de Valores de Orden de Pago";
            this.ImporteValores.Width = 90;
            // 
            // oPSTATUSDataGridViewTextBoxColumn
            // 
            this.oPSTATUSDataGridViewTextBoxColumn.DataPropertyName = "OP_STATUS";
            this.oPSTATUSDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.oPSTATUSDataGridViewTextBoxColumn.Name = "oPSTATUSDataGridViewTextBoxColumn";
            this.oPSTATUSDataGridViewTextBoxColumn.ReadOnly = true;
            this.oPSTATUSDataGridViewTextBoxColumn.ToolTipText = "Estado de la Orden de Pago";
            this.oPSTATUSDataGridViewTextBoxColumn.Width = 80;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "LX";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.ToolTipText = "Tipo de Orden de Pago";
            this.tIPODataGridViewTextBoxColumn.Width = 25;
            // 
            // DiasPPFacturas
            // 
            this.DiasPPFacturas.DataPropertyName = "DiasPPFacturas";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DiasPPFacturas.DefaultCellStyle = dataGridViewCellStyle5;
            this.DiasPPFacturas.HeaderText = "DiasFA";
            this.DiasPPFacturas.Name = "DiasPPFacturas";
            this.DiasPPFacturas.ReadOnly = true;
            this.DiasPPFacturas.ToolTipText = "Dias Facturas a OP";
            this.DiasPPFacturas.Width = 50;
            // 
            // DiasPPItemsPago
            // 
            this.DiasPPItemsPago.DataPropertyName = "DiasPPItemsPago";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DiasPPItemsPago.DefaultCellStyle = dataGridViewCellStyle6;
            this.DiasPPItemsPago.HeaderText = "DiasVA";
            this.DiasPPItemsPago.Name = "DiasPPItemsPago";
            this.DiasPPItemsPago.ReadOnly = true;
            this.DiasPPItemsPago.ToolTipText = "Dias de Valores Ingresados";
            this.DiasPPItemsPago.Width = 50;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Text = "DETALLE";
            this.Detalle.ToolTipText = "Ver o Editar Orden de Pago";
            this.Detalle.UseColumnTextForButtonValue = true;
            this.Detalle.Width = 80;
            // 
            // t0210OPHBindingSource
            // 
            this.t0210OPHBindingSource.DataSource = typeof(TecserEF.Entity.T0210_OP_H);
            // 
            // ckAlicuotaIIBB
            // 
            this.ckAlicuotaIIBB.BackColor = System.Drawing.Color.Khaki;
            this.ckAlicuotaIIBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAlicuotaIIBB.Location = new System.Drawing.Point(9, 729);
            this.ckAlicuotaIIBB.Name = "ckAlicuotaIIBB";
            this.ckAlicuotaIIBB.Size = new System.Drawing.Size(1043, 19);
            this.ckAlicuotaIIBB.TabIndex = 38;
            this.ckAlicuotaIIBB.Text = "Conexión IIBB - Alicuota";
            this.ckAlicuotaIIBB.UseVisualStyleBackColor = false;
            // 
            // txtSaldoTotalL2
            // 
            this.txtSaldoTotalL2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoTotalL2.Location = new System.Drawing.Point(167, 27);
            this.txtSaldoTotalL2.Name = "txtSaldoTotalL2";
            this.txtSaldoTotalL2.Size = new System.Drawing.Size(100, 23);
            this.txtSaldoTotalL2.TabIndex = 44;
            // 
            // txtSaldoTotalL1
            // 
            this.txtSaldoTotalL1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoTotalL1.Location = new System.Drawing.Point(167, 3);
            this.txtSaldoTotalL1.Name = "txtSaldoTotalL1";
            this.txtSaldoTotalL1.Size = new System.Drawing.Size(100, 23);
            this.txtSaldoTotalL1.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbEstadoOP);
            this.panel1.Controls.Add(this.txtNumeroOP);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(7, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 57);
            this.panel1.TabIndex = 45;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtSaldoTotalL1);
            this.panel2.Controls.Add(this.btnDetalleDeuda);
            this.panel2.Controls.Add(this.txtSaldoTotalL2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtSaldoL1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtSaldoL2);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(226, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(689, 57);
            this.panel2.TabIndex = 46;
            // 
            // btnDetalleDeuda
            // 
            this.btnDetalleDeuda.BackColor = System.Drawing.Color.Thistle;
            this.btnDetalleDeuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalleDeuda.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleDeuda.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalleDeuda.Image")));
            this.btnDetalleDeuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleDeuda.Location = new System.Drawing.Point(271, 3);
            this.btnDetalleDeuda.Name = "btnDetalleDeuda";
            this.btnDetalleDeuda.Size = new System.Drawing.Size(111, 48);
            this.btnDetalleDeuda.TabIndex = 50;
            this.btnDetalleDeuda.Text = "Detalle\r\nDeuda";
            this.btnDetalleDeuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleDeuda.UseVisualStyleBackColor = false;
            this.btnDetalleDeuda.Click += new System.EventHandler(this.btnDetalleDeuda_Click_1);
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkBlue;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.SeaGreen;
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 753);
            this.LineaIzq.TabIndex = 194;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DarkBlue;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.SeaGreen;
            this.lineaArriba.Location = new System.Drawing.Point(2, 2);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(1058, 3);
            this.lineaArriba.TabIndex = 193;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkBlue;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SeaGreen;
            this.label7.Location = new System.Drawing.Point(1057, 2);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(3, 753);
            this.label7.TabIndex = 195;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkBlue;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SeaGreen;
            this.label8.Location = new System.Drawing.Point(2, 752);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1058, 3);
            this.label8.TabIndex = 196;
            // 
            // ctlTextBox1
            // 
            this.ctlTextBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlTextBox1.Location = new System.Drawing.Point(943, 381);
            this.ctlTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.ctlTextBox1.Name = "ctlTextBox1";
            this.ctlTextBox1.SeparadorDecimal = false;
            this.ctlTextBox1.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlTextBox1.SetDecimales = 0;
            this.ctlTextBox1.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.ctlTextBox1.Size = new System.Drawing.Size(106, 21);
            this.ctlTextBox1.TabIndex = 201;
            this.ctlTextBox1.ValorMaximo = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.ctlTextBox1.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlTextBox1.XReadOnly = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(924, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 48);
            this.button3.TabIndex = 202;
            this.button3.Text = "Detalle\r\nImputacion";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(921, 549);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(128, 48);
            this.btnLoad.TabIndex = 200;
            this.btnLoad.Text = "LoadOP";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(921, 483);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 48);
            this.button2.TabIndex = 199;
            this.button2.Text = "Detalle DOCPP";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(921, 603);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 48);
            this.button1.TabIndex = 198;
            this.button1.Text = "Nueva\r\nOP";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MASngFE.Properties.Resources.mombelli_01;
            this.pictureBox1.Location = new System.Drawing.Point(615, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // btnFix
            // 
            this.btnFix.Enabled = false;
            this.btnFix.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnFix.Image = ((System.Drawing.Image)(resources.GetObject("btnFix.Image")));
            this.btnFix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFix.Location = new System.Drawing.Point(923, 651);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(128, 48);
            this.btnFix.TabIndex = 50;
            this.btnFix.Text = "FIX";
            this.btnFix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.BtnFix_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(923, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 48);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(923, 62);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(128, 48);
            this.btnNuevo.TabIndex = 22;
            this.btnNuevo.Text = "Nueva\r\nOP";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // tsUcVendorSelector1
            // 
            this.tsUcVendorSelector1.BackColor = System.Drawing.Color.White;
            this.tsUcVendorSelector1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsUcVendorSelector1.Location = new System.Drawing.Point(7, 7);
            this.tsUcVendorSelector1.Name = "tsUcVendorSelector1";
            this.tsUcVendorSelector1.Size = new System.Drawing.Size(602, 91);
            this.tsUcVendorSelector1.TabIndex = 197;
            this.tsUcVendorSelector1.VendorId = null;
            this.tsUcVendorSelector1.VendorUpdated += new MASngFE._0TSUserControls.TsUcVendorSelector.ClienteModificadoEventHandler(this.tsUcVendorSelector1_VendorUpdated);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(923, 305);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 48);
            this.button4.TabIndex = 203;
            this.button4.Text = "Detalle\r\nImputacionxx";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FrmFI30OPSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1063, 757);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ctlTextBox1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tsUcVendorSelector1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.ckAlicuotaIIBB);
            this.Controls.Add(this.dgvOPLista);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.panel1);
            this.Name = "FrmFI30OPSearch";
            this.Text = "FI30 - Buscador de Ordenes de Pago";
            this.Load += new System.EventHandler(this.FrmOrdenPagoSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0210OPHBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstadoOP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroOP;
        private System.Windows.Forms.TextBox txtSaldoL1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaldoL2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvOPLista;
        private System.Windows.Forms.CheckBox ckAlicuotaIIBB;
        private System.Windows.Forms.TextBox txtSaldoTotalL2;
        private System.Windows.Forms.TextBox txtSaldoTotalL1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource t0210OPHBindingSource;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDetalleDeuda;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDOPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPFECHADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pROVRSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPOPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImporteValores;
        private System.Windows.Forms.DataGridViewTextBoxColumn oPSTATUSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasPPFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasPPItemsPago;
        private _0TSUserControls.TsUcVendorSelector tsUcVendorSelector1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnLoad;
        private TSControls.CtlTextBox ctlTextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}