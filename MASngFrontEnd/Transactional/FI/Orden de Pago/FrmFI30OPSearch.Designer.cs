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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI30OPSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFantasia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRazonSocial = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEstadoOP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroOP = new System.Windows.Forms.TextBox();
            this.txtSaldoL1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSaldoL2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvOPLista = new System.Windows.Forms.DataGridView();
            this.t0210OPHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ckAlicuotaIIBB = new System.Windows.Forms.CheckBox();
            this.cmbIdVendor = new System.Windows.Forms.ComboBox();
            this.btnLimpiaDatos = new System.Windows.Forms.Button();
            this.txtSaldoTotalL2 = new System.Windows.Forms.TextBox();
            this.txtSaldoTotalL1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckSoloActivos = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDetalleDeuda = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.iDOPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPFECHADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pROVRSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPOPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImporteValores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPSTATUSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DiasPPFacturas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasPPItemsPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOPLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0210OPHBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Fantasia";
            // 
            // cmbFantasia
            // 
            this.cmbFantasia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFantasia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFantasia.FormattingEnabled = true;
            this.cmbFantasia.Location = new System.Drawing.Point(113, 27);
            this.cmbFantasia.Name = "cmbFantasia";
            this.cmbFantasia.Size = new System.Drawing.Size(189, 21);
            this.cmbFantasia.TabIndex = 25;
            this.cmbFantasia.SelectedIndexChanged += new System.EventHandler(this.cmbFantasia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Razon Social";
            // 
            // cmbRazonSocial
            // 
            this.cmbRazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRazonSocial.DropDownHeight = 50;
            this.cmbRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRazonSocial.FormattingEnabled = true;
            this.cmbRazonSocial.IntegralHeight = false;
            this.cmbRazonSocial.Location = new System.Drawing.Point(113, 5);
            this.cmbRazonSocial.Name = "cmbRazonSocial";
            this.cmbRazonSocial.Size = new System.Drawing.Size(189, 21);
            this.cmbRazonSocial.TabIndex = 23;
            this.cmbRazonSocial.SelectedIndexChanged += new System.EventHandler(this.cmbRazonSocial_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Estado";
            // 
            // cmbEstadoOP
            // 
            this.cmbEstadoOP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstadoOP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstadoOP.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbEstadoOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstadoOP.ForeColor = System.Drawing.Color.Blue;
            this.cmbEstadoOP.FormattingEnabled = true;
            this.cmbEstadoOP.Items.AddRange(new object[] {
            "INICIAL",
            "PROCESO",
            "GENERADA",
            "FINALIZADA",
            "CANCELADA"});
            this.cmbEstadoOP.Location = new System.Drawing.Point(113, 49);
            this.cmbEstadoOP.Name = "cmbEstadoOP";
            this.cmbEstadoOP.Size = new System.Drawing.Size(119, 21);
            this.cmbEstadoOP.TabIndex = 28;
            this.cmbEstadoOP.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoOP_SelectedIndexChanged);
            this.cmbEstadoOP.Leave += new System.EventHandler(this.cmbEstadoOP_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Numero Op";
            // 
            // txtNumeroOP
            // 
            this.txtNumeroOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOP.Location = new System.Drawing.Point(113, 71);
            this.txtNumeroOP.Name = "txtNumeroOP";
            this.txtNumeroOP.Size = new System.Drawing.Size(119, 20);
            this.txtNumeroOP.TabIndex = 31;
            this.txtNumeroOP.TextChanged += new System.EventHandler(this.txtNumeroOP_TextChanged);
            // 
            // txtSaldoL1
            // 
            this.txtSaldoL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoL1.Location = new System.Drawing.Point(113, 1);
            this.txtSaldoL1.Name = "txtSaldoL1";
            this.txtSaldoL1.Size = new System.Drawing.Size(86, 20);
            this.txtSaldoL1.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "Saldo L1";
            // 
            // txtSaldoL2
            // 
            this.txtSaldoL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoL2.Location = new System.Drawing.Point(113, 22);
            this.txtSaldoL2.Name = "txtSaldoL2";
            this.txtSaldoL2.Size = new System.Drawing.Size(86, 20);
            this.txtSaldoL2.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
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
            this.Detalle,
            this.DiasPPFacturas,
            this.DiasPPItemsPago});
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
            this.dgvOPLista.Location = new System.Drawing.Point(8, 154);
            this.dgvOPLista.MultiSelect = false;
            this.dgvOPLista.Name = "dgvOPLista";
            this.dgvOPLista.ReadOnly = true;
            this.dgvOPLista.RowHeadersWidth = 20;
            this.dgvOPLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOPLista.Size = new System.Drawing.Size(935, 435);
            this.dgvOPLista.TabIndex = 37;
            this.dgvOPLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOPLista_CellContentClick);
            // 
            // t0210OPHBindingSource
            // 
            this.t0210OPHBindingSource.DataSource = typeof(TecserEF.Entity.T0210_OP_H);
            // 
            // ckAlicuotaIIBB
            // 
            this.ckAlicuotaIIBB.BackColor = System.Drawing.Color.Khaki;
            this.ckAlicuotaIIBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckAlicuotaIIBB.Location = new System.Drawing.Point(16, 594);
            this.ckAlicuotaIIBB.Name = "ckAlicuotaIIBB";
            this.ckAlicuotaIIBB.Size = new System.Drawing.Size(302, 19);
            this.ckAlicuotaIIBB.TabIndex = 38;
            this.ckAlicuotaIIBB.Text = "Conexión IIBB - Alicuota";
            this.ckAlicuotaIIBB.UseVisualStyleBackColor = false;
            // 
            // cmbIdVendor
            // 
            this.cmbIdVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbIdVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbIdVendor.DropDownHeight = 50;
            this.cmbIdVendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdVendor.FormattingEnabled = true;
            this.cmbIdVendor.IntegralHeight = false;
            this.cmbIdVendor.Location = new System.Drawing.Point(303, 5);
            this.cmbIdVendor.Name = "cmbIdVendor";
            this.cmbIdVendor.Size = new System.Drawing.Size(86, 21);
            this.cmbIdVendor.TabIndex = 41;
            this.cmbIdVendor.SelectedIndexChanged += new System.EventHandler(this.cmbIdVendor_SelectedIndexChanged);
            // 
            // btnLimpiaDatos
            // 
            this.btnLimpiaDatos.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiaDatos.Location = new System.Drawing.Point(390, 4);
            this.btnLimpiaDatos.Name = "btnLimpiaDatos";
            this.btnLimpiaDatos.Size = new System.Drawing.Size(80, 22);
            this.btnLimpiaDatos.TabIndex = 42;
            this.btnLimpiaDatos.Text = "Limpia Datos";
            this.btnLimpiaDatos.UseVisualStyleBackColor = true;
            this.btnLimpiaDatos.Click += new System.EventHandler(this.btnLimpiaDatos_Click);
            // 
            // txtSaldoTotalL2
            // 
            this.txtSaldoTotalL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoTotalL2.Location = new System.Drawing.Point(201, 22);
            this.txtSaldoTotalL2.Name = "txtSaldoTotalL2";
            this.txtSaldoTotalL2.Size = new System.Drawing.Size(86, 20);
            this.txtSaldoTotalL2.TabIndex = 44;
            // 
            // txtSaldoTotalL1
            // 
            this.txtSaldoTotalL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoTotalL1.Location = new System.Drawing.Point(201, 1);
            this.txtSaldoTotalL1.Name = "txtSaldoTotalL1";
            this.txtSaldoTotalL1.Size = new System.Drawing.Size(86, 20);
            this.txtSaldoTotalL1.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLimpiaDatos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbIdVendor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbRazonSocial);
            this.panel1.Controls.Add(this.cmbFantasia);
            this.panel1.Controls.Add(this.cmbEstadoOP);
            this.panel1.Controls.Add(this.txtNumeroOP);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 97);
            this.panel1.TabIndex = 45;
            // 
            // ckSoloActivos
            // 
            this.ckSoloActivos.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ckSoloActivos.Checked = true;
            this.ckSoloActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSoloActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloActivos.Location = new System.Drawing.Point(16, 616);
            this.ckSoloActivos.Name = "ckSoloActivos";
            this.ckSoloActivos.Size = new System.Drawing.Size(302, 19);
            this.ckSoloActivos.TabIndex = 48;
            this.ckSoloActivos.Text = "Ver Sólo Proveedores Activos";
            this.ckSoloActivos.UseVisualStyleBackColor = false;
            this.ckSoloActivos.CheckedChanged += new System.EventHandler(this.ckSoloActivos_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtSaldoTotalL1);
            this.panel2.Controls.Add(this.btnDetalleDeuda);
            this.panel2.Controls.Add(this.txtSaldoTotalL2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtSaldoL1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtSaldoL2);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(8, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 46);
            this.panel2.TabIndex = 46;
            // 
            // btnDetalleDeuda
            // 
            this.btnDetalleDeuda.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleDeuda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalleDeuda.Location = new System.Drawing.Point(349, 1);
            this.btnDetalleDeuda.Name = "btnDetalleDeuda";
            this.btnDetalleDeuda.Size = new System.Drawing.Size(121, 40);
            this.btnDetalleDeuda.TabIndex = 50;
            this.btnDetalleDeuda.Text = "Composicion\r\nde Deuda";
            this.btnDetalleDeuda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleDeuda.UseVisualStyleBackColor = true;
            this.btnDetalleDeuda.Click += new System.EventHandler(this.btnDetalleDeuda_Click_1);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(949, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "SALIR";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnNuevo.Image = global::MASngFE.Properties.Resources.invoice;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(949, 48);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 40);
            this.btnNuevo.TabIndex = 22;
            this.btnNuevo.Text = "Nueva\r\nOP";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnFix
            // 
            this.btnFix.Enabled = false;
            this.btnFix.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnFix.Image = ((System.Drawing.Image)(resources.GetObject("btnFix.Image")));
            this.btnFix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFix.Location = new System.Drawing.Point(949, 88);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(100, 40);
            this.btnFix.TabIndex = 50;
            this.btnFix.Text = "FIX";
            this.btnFix.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.BtnFix_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MASngFE.Properties.Resources.mombelli_01;
            this.pictureBox1.Location = new System.Drawing.Point(595, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkBlue;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.SeaGreen;
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 639);
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
            this.label7.Size = new System.Drawing.Size(3, 639);
            this.label7.TabIndex = 195;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkBlue;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SeaGreen;
            this.label8.Location = new System.Drawing.Point(2, 638);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1058, 3);
            this.label8.TabIndex = 196;
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
            // FrmFI30OPSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1063, 644);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.ckSoloActivos);
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

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFantasia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRazonSocial;
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
        private System.Windows.Forms.ComboBox cmbIdVendor;
        private System.Windows.Forms.Button btnLimpiaDatos;
        private System.Windows.Forms.TextBox txtSaldoTotalL2;
        private System.Windows.Forms.TextBox txtSaldoTotalL1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource t0210OPHBindingSource;
        private System.Windows.Forms.CheckBox ckSoloActivos;
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
    }
}