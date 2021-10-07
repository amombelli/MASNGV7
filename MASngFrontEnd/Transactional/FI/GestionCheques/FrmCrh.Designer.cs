namespace MASngFE.Transactional.FI.GestionCheques
{
    partial class FrmCrh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrh));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOrigenBanco = new System.Windows.Forms.Button();
            this.btnOrigenVendor = new System.Windows.Forms.Button();
            this.btnOrigenEnCartera = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtGL1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilterChNum = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lfiltro1 = new System.Windows.Forms.Label();
            this.cmbFiltroOrigen = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb1Cartera = new System.Windows.Forms.RadioButton();
            this.rb1Proveedor = new System.Windows.Forms.RadioButton();
            this.rb1Banco = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cIcono1Ubicacion = new TSControls.CtlIconos();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvListaCheques = new System.Windows.Forms.DataGridView();
            this.iDCHEQUEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHENUMERODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mONEDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPORTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHE_FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHEBANCODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLIENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHRECHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cOMENTARIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClienteRecibidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaTxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeBs = new System.Windows.Forms.BindingSource(this.components);
            this.label32 = new System.Windows.Forms.Label();
            this.txtChLxRecibido = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtChCliente = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChBanco = new System.Windows.Forms.TextBox();
            this.txtIdCheque = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtChLxEntregado = new System.Windows.Forms.TextBox();
            this.txtChProveedor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cChImporte = new TSControls.CtlTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cChFechaRecibido = new TSControls.CtlFechaTs();
            this.cIcono5SeleccionCheque = new TSControls.CtlIconos();
            this.cChFechaAcreditacion = new TSControls.CtlFechaTs();
            this.lTituloListado = new System.Windows.Forms.Label();
            this.btnRegresarACliente = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAccion = new System.Windows.Forms.Button();
            this.CuentasBs = new System.Windows.Forms.BindingSource(this.components);
            this.ProveedoresBs = new System.Windows.Forms.BindingSource(this.components);
            this.ClientesBs = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChequeBs)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuentasBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedoresBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesBs)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Crimson;
            this.label16.Location = new System.Drawing.Point(1071, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(3, 704);
            this.label16.TabIndex = 182;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Crimson;
            this.label17.Location = new System.Drawing.Point(2, 2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(3, 707);
            this.label17.TabIndex = 181;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Crimson;
            this.label18.Location = new System.Drawing.Point(2, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(1072, 3);
            this.label18.TabIndex = 180;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(2, 709);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1072, 3);
            this.label1.TabIndex = 186;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnOrigenBanco);
            this.panel1.Controls.Add(this.btnOrigenVendor);
            this.panel1.Controls.Add(this.btnOrigenEnCartera);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 135);
            this.panel1.TabIndex = 187;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(194, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 15);
            this.label11.TabIndex = 245;
            this.label11.Text = "DISPONIBLE";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(99, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 15);
            this.label9.TabIndex = 244;
            this.label9.Text = "PROVEEDOR";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(4, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 243;
            this.label7.Text = "DEPOSITADO";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOrigenBanco
            // 
            this.btnOrigenBanco.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOrigenBanco.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOrigenBanco.BackgroundImage")));
            this.btnOrigenBanco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOrigenBanco.Location = new System.Drawing.Point(4, 2);
            this.btnOrigenBanco.Name = "btnOrigenBanco";
            this.btnOrigenBanco.Size = new System.Drawing.Size(94, 110);
            this.btnOrigenBanco.TabIndex = 183;
            this.btnOrigenBanco.UseVisualStyleBackColor = false;
            this.btnOrigenBanco.Click += new System.EventHandler(this.btnOrigenBanco_Click);
            // 
            // btnOrigenVendor
            // 
            this.btnOrigenVendor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOrigenVendor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOrigenVendor.BackgroundImage")));
            this.btnOrigenVendor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOrigenVendor.Location = new System.Drawing.Point(99, 2);
            this.btnOrigenVendor.Name = "btnOrigenVendor";
            this.btnOrigenVendor.Size = new System.Drawing.Size(94, 110);
            this.btnOrigenVendor.TabIndex = 185;
            this.btnOrigenVendor.UseVisualStyleBackColor = false;
            this.btnOrigenVendor.Click += new System.EventHandler(this.btnOrigenVendor_Click);
            // 
            // btnOrigenEnCartera
            // 
            this.btnOrigenEnCartera.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOrigenEnCartera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOrigenEnCartera.BackgroundImage")));
            this.btnOrigenEnCartera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOrigenEnCartera.Location = new System.Drawing.Point(194, 2);
            this.btnOrigenEnCartera.Name = "btnOrigenEnCartera";
            this.btnOrigenEnCartera.Size = new System.Drawing.Size(94, 110);
            this.btnOrigenEnCartera.TabIndex = 184;
            this.btnOrigenEnCartera.UseVisualStyleBackColor = false;
            this.btnOrigenEnCartera.Click += new System.EventHandler(this.btnOrigenEnCartera_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtGL1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtFilterChNum);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.lfiltro1);
            this.panel2.Controls.Add(this.cmbFiltroOrigen);
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(9, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 28);
            this.panel2.TabIndex = 188;
            // 
            // txtGL1
            // 
            this.txtGL1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGL1.ForeColor = System.Drawing.Color.Navy;
            this.txtGL1.Location = new System.Drawing.Point(630, 3);
            this.txtGL1.Name = "txtGL1";
            this.txtGL1.ReadOnly = true;
            this.txtGL1.Size = new System.Drawing.Size(54, 21);
            this.txtGL1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "GL1";
            // 
            // txtFilterChNum
            // 
            this.txtFilterChNum.BackColor = System.Drawing.Color.White;
            this.txtFilterChNum.ForeColor = System.Drawing.Color.Navy;
            this.txtFilterChNum.Location = new System.Drawing.Point(533, 3);
            this.txtFilterChNum.Name = "txtFilterChNum";
            this.txtFilterChNum.Size = new System.Drawing.Size(54, 21);
            this.txtFilterChNum.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(429, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 15);
            this.label15.TabIndex = 17;
            this.label15.Text = "Numero Cheque";
            // 
            // lfiltro1
            // 
            this.lfiltro1.AutoSize = true;
            this.lfiltro1.Location = new System.Drawing.Point(8, 6);
            this.lfiltro1.Name = "lfiltro1";
            this.lfiltro1.Size = new System.Drawing.Size(70, 15);
            this.lfiltro1.TabIndex = 1;
            this.lfiltro1.Text = "ltextoFiltro1";
            // 
            // cmbFiltroOrigen
            // 
            this.cmbFiltroOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFiltroOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFiltroOrigen.FormattingEnabled = true;
            this.cmbFiltroOrigen.Location = new System.Drawing.Point(153, 2);
            this.cmbFiltroOrigen.Name = "cmbFiltroOrigen";
            this.cmbFiltroOrigen.Size = new System.Drawing.Size(270, 23);
            this.cmbFiltroOrigen.TabIndex = 0;
            this.cmbFiltroOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroOrigen_SelectedIndexChanged);
            this.cmbFiltroOrigen.TextChanged += new System.EventHandler(this.cmbFiltroOrigen_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.rb1Cartera);
            this.groupBox1.Controls.Add(this.rb1Proveedor);
            this.groupBox1.Controls.Add(this.rb1Banco);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 101);
            this.groupBox1.TabIndex = 189;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Origen Seleccionado";
            // 
            // rb1Cartera
            // 
            this.rb1Cartera.AutoSize = true;
            this.rb1Cartera.Location = new System.Drawing.Point(7, 78);
            this.rb1Cartera.Name = "rb1Cartera";
            this.rb1Cartera.Size = new System.Drawing.Size(139, 19);
            this.rb1Cartera.TabIndex = 2;
            this.rb1Cartera.TabStop = true;
            this.rb1Cartera.Text = "Cartera [Disponibles]";
            this.rb1Cartera.UseVisualStyleBackColor = true;
            this.rb1Cartera.CheckedChanged += new System.EventHandler(this.rb1Origen_CheckedChanged);
            // 
            // rb1Proveedor
            // 
            this.rb1Proveedor.AutoSize = true;
            this.rb1Proveedor.Location = new System.Drawing.Point(7, 53);
            this.rb1Proveedor.Name = "rb1Proveedor";
            this.rb1Proveedor.Size = new System.Drawing.Size(115, 19);
            this.rb1Proveedor.TabIndex = 1;
            this.rb1Proveedor.TabStop = true;
            this.rb1Proveedor.Text = "Proveedor [OPX]";
            this.rb1Proveedor.UseVisualStyleBackColor = true;
            this.rb1Proveedor.CheckedChanged += new System.EventHandler(this.rb1Origen_CheckedChanged);
            // 
            // rb1Banco
            // 
            this.rb1Banco.AutoSize = true;
            this.rb1Banco.Location = new System.Drawing.Point(7, 26);
            this.rb1Banco.Name = "rb1Banco";
            this.rb1Banco.Size = new System.Drawing.Size(128, 19);
            this.rb1Banco.TabIndex = 0;
            this.rb1Banco.TabStop = true;
            this.rb1Banco.Text = "Entidad Financiera";
            this.rb1Banco.UseVisualStyleBackColor = true;
            this.rb1Banco.CheckedChanged += new System.EventHandler(this.rb1Origen_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cIcono1Ubicacion);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(307, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 113);
            this.panel3.TabIndex = 190;
            // 
            // cIcono1Ubicacion
            // 
            this.cIcono1Ubicacion.BackColor = System.Drawing.Color.Gainsboro;
            this.cIcono1Ubicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cIcono1Ubicacion.IconLocation = TSControls.UbicacionIcono.Normal;
            this.cIcono1Ubicacion.IconSize = TSControls.TamañoIcono.Chico;
            this.cIcono1Ubicacion.Location = new System.Drawing.Point(242, 10);
            this.cIcono1Ubicacion.Name = "cIcono1Ubicacion";
            this.cIcono1Ubicacion.Set = TSControls.CIconos.TrianguloNaranja;
            this.cIcono1Ubicacion.Size = new System.Drawing.Size(17, 18);
            this.cIcono1Ubicacion.TabIndex = 192;
            // 
            // dgvListaCheques
            // 
            this.dgvListaCheques.AllowUserToAddRows = false;
            this.dgvListaCheques.AllowUserToDeleteRows = false;
            this.dgvListaCheques.AutoGenerateColumns = false;
            this.dgvListaCheques.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListaCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDCHEQUEDataGridViewTextBoxColumn,
            this.cHENUMERODataGridViewTextBoxColumn,
            this.mONEDADataGridViewTextBoxColumn,
            this.iMPORTEDataGridViewTextBoxColumn,
            this.CHE_FECHA,
            this.cHEBANCODataGridViewTextBoxColumn,
            this.cLIENTEDataGridViewTextBoxColumn,
            this.tIPODataGridViewTextBoxColumn,
            this.cHRECHDataGridViewTextBoxColumn,
            this.cOMENTARIODataGridViewTextBoxColumn,
            this.idClienteRecibidoDataGridViewTextBoxColumn,
            this.cuentaTxDataGridViewTextBoxColumn});
            this.dgvListaCheques.DataSource = this.ChequeBs;
            this.dgvListaCheques.GridColor = System.Drawing.Color.Black;
            this.dgvListaCheques.Location = new System.Drawing.Point(9, 195);
            this.dgvListaCheques.MultiSelect = false;
            this.dgvListaCheques.Name = "dgvListaCheques";
            this.dgvListaCheques.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListaCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvListaCheques.RowHeadersWidth = 20;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListaCheques.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvListaCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCheques.Size = new System.Drawing.Size(692, 338);
            this.dgvListaCheques.TabIndex = 191;
            this.dgvListaCheques.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaCheques_CellEnter);
            // 
            // iDCHEQUEDataGridViewTextBoxColumn
            // 
            this.iDCHEQUEDataGridViewTextBoxColumn.DataPropertyName = "IDCHEQUE";
            this.iDCHEQUEDataGridViewTextBoxColumn.HeaderText = "IDCHE";
            this.iDCHEQUEDataGridViewTextBoxColumn.Name = "iDCHEQUEDataGridViewTextBoxColumn";
            this.iDCHEQUEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDCHEQUEDataGridViewTextBoxColumn.Visible = false;
            this.iDCHEQUEDataGridViewTextBoxColumn.Width = 60;
            // 
            // cHENUMERODataGridViewTextBoxColumn
            // 
            this.cHENUMERODataGridViewTextBoxColumn.DataPropertyName = "CHE_NUMERO";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cHENUMERODataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cHENUMERODataGridViewTextBoxColumn.HeaderText = "CH #";
            this.cHENUMERODataGridViewTextBoxColumn.Name = "cHENUMERODataGridViewTextBoxColumn";
            this.cHENUMERODataGridViewTextBoxColumn.ReadOnly = true;
            this.cHENUMERODataGridViewTextBoxColumn.ToolTipText = "Numero de Cheque";
            this.cHENUMERODataGridViewTextBoxColumn.Width = 60;
            // 
            // mONEDADataGridViewTextBoxColumn
            // 
            this.mONEDADataGridViewTextBoxColumn.DataPropertyName = "MONEDA";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mONEDADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.mONEDADataGridViewTextBoxColumn.HeaderText = "Mon";
            this.mONEDADataGridViewTextBoxColumn.Name = "mONEDADataGridViewTextBoxColumn";
            this.mONEDADataGridViewTextBoxColumn.ReadOnly = true;
            this.mONEDADataGridViewTextBoxColumn.Width = 50;
            // 
            // iMPORTEDataGridViewTextBoxColumn
            // 
            this.iMPORTEDataGridViewTextBoxColumn.DataPropertyName = "IMPORTE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle4.Format = "C2";
            this.iMPORTEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.iMPORTEDataGridViewTextBoxColumn.HeaderText = "Importe";
            this.iMPORTEDataGridViewTextBoxColumn.Name = "iMPORTEDataGridViewTextBoxColumn";
            this.iMPORTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iMPORTEDataGridViewTextBoxColumn.Width = 90;
            // 
            // CHE_FECHA
            // 
            this.CHE_FECHA.DataPropertyName = "CHE_FECHA";
            this.CHE_FECHA.HeaderText = "FechaAcred";
            this.CHE_FECHA.Name = "CHE_FECHA";
            this.CHE_FECHA.ReadOnly = true;
            this.CHE_FECHA.ToolTipText = "Fecha de Acreditacion del Cheque";
            this.CHE_FECHA.Width = 90;
            // 
            // cHEBANCODataGridViewTextBoxColumn
            // 
            this.cHEBANCODataGridViewTextBoxColumn.DataPropertyName = "CHE_BANCO";
            this.cHEBANCODataGridViewTextBoxColumn.HeaderText = "Bco";
            this.cHEBANCODataGridViewTextBoxColumn.Name = "cHEBANCODataGridViewTextBoxColumn";
            this.cHEBANCODataGridViewTextBoxColumn.ReadOnly = true;
            this.cHEBANCODataGridViewTextBoxColumn.Width = 50;
            // 
            // cLIENTEDataGridViewTextBoxColumn
            // 
            this.cLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CLIENTE";
            this.cLIENTEDataGridViewTextBoxColumn.HeaderText = "Recibido De";
            this.cLIENTEDataGridViewTextBoxColumn.Name = "cLIENTEDataGridViewTextBoxColumn";
            this.cLIENTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cLIENTEDataGridViewTextBoxColumn.ToolTipText = "Cliente que Entrego el Cheque";
            this.cLIENTEDataGridViewTextBoxColumn.Width = 160;
            // 
            // tIPODataGridViewTextBoxColumn
            // 
            this.tIPODataGridViewTextBoxColumn.DataPropertyName = "TIPO";
            this.tIPODataGridViewTextBoxColumn.HeaderText = "LX";
            this.tIPODataGridViewTextBoxColumn.Name = "tIPODataGridViewTextBoxColumn";
            this.tIPODataGridViewTextBoxColumn.ReadOnly = true;
            this.tIPODataGridViewTextBoxColumn.ToolTipText = "Tipo del Cheque";
            this.tIPODataGridViewTextBoxColumn.Width = 35;
            // 
            // cHRECHDataGridViewTextBoxColumn
            // 
            this.cHRECHDataGridViewTextBoxColumn.DataPropertyName = "CH_RECH";
            this.cHRECHDataGridViewTextBoxColumn.HeaderText = "CHR";
            this.cHRECHDataGridViewTextBoxColumn.Name = "cHRECHDataGridViewTextBoxColumn";
            this.cHRECHDataGridViewTextBoxColumn.ReadOnly = true;
            this.cHRECHDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cHRECHDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cHRECHDataGridViewTextBoxColumn.ToolTipText = "Flag de Cheque Rechazado";
            this.cHRECHDataGridViewTextBoxColumn.Width = 40;
            // 
            // cOMENTARIODataGridViewTextBoxColumn
            // 
            this.cOMENTARIODataGridViewTextBoxColumn.DataPropertyName = "COMENTARIO";
            this.cOMENTARIODataGridViewTextBoxColumn.HeaderText = "Observacion";
            this.cOMENTARIODataGridViewTextBoxColumn.Name = "cOMENTARIODataGridViewTextBoxColumn";
            this.cOMENTARIODataGridViewTextBoxColumn.ReadOnly = true;
            this.cOMENTARIODataGridViewTextBoxColumn.Width = 80;
            // 
            // idClienteRecibidoDataGridViewTextBoxColumn
            // 
            this.idClienteRecibidoDataGridViewTextBoxColumn.DataPropertyName = "IdClienteRecibido";
            this.idClienteRecibidoDataGridViewTextBoxColumn.HeaderText = "IDCLI";
            this.idClienteRecibidoDataGridViewTextBoxColumn.Name = "idClienteRecibidoDataGridViewTextBoxColumn";
            this.idClienteRecibidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteRecibidoDataGridViewTextBoxColumn.Visible = false;
            this.idClienteRecibidoDataGridViewTextBoxColumn.Width = 60;
            // 
            // cuentaTxDataGridViewTextBoxColumn
            // 
            this.cuentaTxDataGridViewTextBoxColumn.DataPropertyName = "CuentaTx";
            this.cuentaTxDataGridViewTextBoxColumn.HeaderText = "CuentaTx";
            this.cuentaTxDataGridViewTextBoxColumn.Name = "cuentaTxDataGridViewTextBoxColumn";
            this.cuentaTxDataGridViewTextBoxColumn.ReadOnly = true;
            this.cuentaTxDataGridViewTextBoxColumn.Visible = false;
            this.cuentaTxDataGridViewTextBoxColumn.Width = 80;
            // 
            // ChequeBs
            // 
            this.ChequeBs.AllowNew = false;
            this.ChequeBs.DataSource = typeof(TecserEF.Entity.T0154_CHEQUES);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(616, 32);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(35, 15);
            this.label32.TabIndex = 232;
            this.label32.Text = "Lx IN";
            // 
            // txtChLxRecibido
            // 
            this.txtChLxRecibido.Location = new System.Drawing.Point(656, 29);
            this.txtChLxRecibido.Name = "txtChLxRecibido";
            this.txtChLxRecibido.ReadOnly = true;
            this.txtChLxRecibido.Size = new System.Drawing.Size(30, 21);
            this.txtChLxRecibido.TabIndex = 231;
            this.txtChLxRecibido.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(33, 32);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(93, 15);
            this.label26.TabIndex = 230;
            this.label26.Text = "Fecha Recibido";
            // 
            // txtChCliente
            // 
            this.txtChCliente.ForeColor = System.Drawing.Color.Navy;
            this.txtChCliente.Location = new System.Drawing.Point(315, 29);
            this.txtChCliente.Name = "txtChCliente";
            this.txtChCliente.ReadOnly = true;
            this.txtChCliente.Size = new System.Drawing.Size(281, 21);
            this.txtChCliente.TabIndex = 229;
            this.txtChCliente.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(250, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 15);
            this.label13.TabIndex = 228;
            this.label13.Text = "Cliente IN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 226;
            this.label8.Text = "Banco";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(548, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 223;
            this.label5.Text = "Ch ID";
            // 
            // txtChBanco
            // 
            this.txtChBanco.Location = new System.Drawing.Point(315, 7);
            this.txtChBanco.Name = "txtChBanco";
            this.txtChBanco.ReadOnly = true;
            this.txtChBanco.Size = new System.Drawing.Size(227, 21);
            this.txtChBanco.TabIndex = 224;
            this.txtChBanco.TabStop = false;
            // 
            // txtIdCheque
            // 
            this.txtIdCheque.Location = new System.Drawing.Point(596, 7);
            this.txtIdCheque.Name = "txtIdCheque";
            this.txtIdCheque.ReadOnly = true;
            this.txtIdCheque.Size = new System.Drawing.Size(60, 21);
            this.txtIdCheque.TabIndex = 222;
            this.txtIdCheque.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 15);
            this.label10.TabIndex = 225;
            this.label10.Text = "Fecha Acreditacion";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtChLxEntregado);
            this.panel4.Controls.Add(this.txtChProveedor);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.cChImporte);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.cChFechaRecibido);
            this.panel4.Controls.Add(this.cIcono5SeleccionCheque);
            this.panel4.Controls.Add(this.cChFechaAcreditacion);
            this.panel4.Controls.Add(this.txtIdCheque);
            this.panel4.Controls.Add(this.label32);
            this.panel4.Controls.Add(this.txtChBanco);
            this.panel4.Controls.Add(this.txtChLxRecibido);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label26);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtChCliente);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Location = new System.Drawing.Point(9, 531);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(692, 79);
            this.panel4.TabIndex = 235;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(603, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 242;
            this.label6.Text = "Lx OUT";
            // 
            // txtChLxEntregado
            // 
            this.txtChLxEntregado.Location = new System.Drawing.Point(656, 52);
            this.txtChLxEntregado.Name = "txtChLxEntregado";
            this.txtChLxEntregado.ReadOnly = true;
            this.txtChLxEntregado.Size = new System.Drawing.Size(30, 21);
            this.txtChLxEntregado.TabIndex = 241;
            this.txtChLxEntregado.TabStop = false;
            // 
            // txtChProveedor
            // 
            this.txtChProveedor.ForeColor = System.Drawing.Color.Navy;
            this.txtChProveedor.Location = new System.Drawing.Point(315, 52);
            this.txtChProveedor.Name = "txtChProveedor";
            this.txtChProveedor.ReadOnly = true;
            this.txtChProveedor.Size = new System.Drawing.Size(281, 21);
            this.txtChProveedor.TabIndex = 240;
            this.txtChProveedor.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 239;
            this.label3.Text = "Salida Por";
            // 
            // cChImporte
            // 
            this.cChImporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cChImporte.BackColor = System.Drawing.Color.LightBlue;
            this.cChImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cChImporte.ForeColor = System.Drawing.Color.Navy;
            this.cChImporte.Location = new System.Drawing.Point(136, 52);
            this.cChImporte.Margin = new System.Windows.Forms.Padding(0);
            this.cChImporte.Name = "cChImporte";
            this.cChImporte.SetAlineacion = TSControls.CtlTextBox.Alineacion.Derecha;
            this.cChImporte.SetDecimales = 2;
            this.cChImporte.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.cChImporte.Size = new System.Drawing.Size(92, 21);
            this.cChImporte.TabIndex = 238;
            this.cChImporte.ValorMaximo = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.cChImporte.ValorMinimo = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.cChImporte.XReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 237;
            this.label4.Text = "Importe Cheque";
            // 
            // cChFechaRecibido
            // 
            this.cChFechaRecibido.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cChFechaRecibido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cChFechaRecibido.CheckPeriodoFIAuto = false;
            this.cChFechaRecibido.ColorFondoFecha = System.Drawing.Color.Empty;
            this.cChFechaRecibido.ColorForeFecha = System.Drawing.Color.Empty;
            this.cChFechaRecibido.Enabled = false;
            this.cChFechaRecibido.FechaMaxima = null;
            this.cChFechaRecibido.FechaMinima = null;
            this.cChFechaRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cChFechaRecibido.Location = new System.Drawing.Point(136, 28);
            this.cChFechaRecibido.Margin = new System.Windows.Forms.Padding(0);
            this.cChFechaRecibido.Name = "cChFechaRecibido";
            this.cChFechaRecibido.ObtieneTCAuto = false;
            this.cChFechaRecibido.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Green;
            this.cChFechaRecibido.Size = new System.Drawing.Size(97, 23);
            this.cChFechaRecibido.TabIndex = 234;
            this.cChFechaRecibido.ValidarRangoFecha = false;
            this.cChFechaRecibido.Value = null;
            // 
            // cIcono5SeleccionCheque
            // 
            this.cIcono5SeleccionCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cIcono5SeleccionCheque.IconLocation = TSControls.UbicacionIcono.Normal;
            this.cIcono5SeleccionCheque.IconSize = TSControls.TamañoIcono.Chico;
            this.cIcono5SeleccionCheque.Location = new System.Drawing.Point(665, 9);
            this.cIcono5SeleccionCheque.Name = "cIcono5SeleccionCheque";
            this.cIcono5SeleccionCheque.Set = TSControls.CIconos.TrianguloNaranja;
            this.cIcono5SeleccionCheque.Size = new System.Drawing.Size(16, 16);
            this.cIcono5SeleccionCheque.TabIndex = 227;
            // 
            // cChFechaAcreditacion
            // 
            this.cChFechaAcreditacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cChFechaAcreditacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cChFechaAcreditacion.CheckPeriodoFIAuto = false;
            this.cChFechaAcreditacion.ColorFondoFecha = System.Drawing.Color.Empty;
            this.cChFechaAcreditacion.ColorForeFecha = System.Drawing.Color.Empty;
            this.cChFechaAcreditacion.Enabled = false;
            this.cChFechaAcreditacion.FechaMaxima = null;
            this.cChFechaAcreditacion.FechaMinima = null;
            this.cChFechaAcreditacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cChFechaAcreditacion.Location = new System.Drawing.Point(136, 5);
            this.cChFechaAcreditacion.Margin = new System.Windows.Forms.Padding(0);
            this.cChFechaAcreditacion.Name = "cChFechaAcreditacion";
            this.cChFechaAcreditacion.ObtieneTCAuto = false;
            this.cChFechaAcreditacion.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Green;
            this.cChFechaAcreditacion.Size = new System.Drawing.Size(97, 23);
            this.cChFechaAcreditacion.TabIndex = 233;
            this.cChFechaAcreditacion.ValidarRangoFecha = false;
            this.cChFechaAcreditacion.Value = null;
            // 
            // lTituloListado
            // 
            this.lTituloListado.BackColor = System.Drawing.Color.White;
            this.lTituloListado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lTituloListado.ForeColor = System.Drawing.Color.Navy;
            this.lTituloListado.Location = new System.Drawing.Point(9, 175);
            this.lTituloListado.Name = "lTituloListado";
            this.lTituloListado.Size = new System.Drawing.Size(692, 19);
            this.lTituloListado.TabIndex = 246;
            this.lTituloListado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegresarACliente
            // 
            this.btnRegresarACliente.Image = ((System.Drawing.Image)(resources.GetObject("btnRegresarACliente.Image")));
            this.btnRegresarACliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresarACliente.Location = new System.Drawing.Point(601, 613);
            this.btnRegresarACliente.Name = "btnRegresarACliente";
            this.btnRegresarACliente.Size = new System.Drawing.Size(100, 42);
            this.btnRegresarACliente.TabIndex = 247;
            this.btnRegresarACliente.Text = "Devolver";
            this.btnRegresarACliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegresarACliente.UseVisualStyleBackColor = true;
            this.btnRegresarACliente.Click += new System.EventHandler(this.btnRegresarACliente_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(601, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 42);
            this.btnExit.TabIndex = 197;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAccion
            // 
            this.btnAccion.Image = ((System.Drawing.Image)(resources.GetObject("btnAccion.Image")));
            this.btnAccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccion.Location = new System.Drawing.Point(501, 613);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(100, 42);
            this.btnAccion.TabIndex = 217;
            this.btnAccion.Text = "Rechazar";
            this.btnAccion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccion.UseVisualStyleBackColor = true;
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // CuentasBs
            // 
            this.CuentasBs.DataSource = typeof(TecserEF.Entity.T0150_CUENTAS);
            // 
            // ProveedoresBs
            // 
            this.ProveedoresBs.DataSource = typeof(TecserEF.Entity.T0005_MPROVEEDORES);
            // 
            // ClientesBs
            // 
            this.ClientesBs.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // FrmCrh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 721);
            this.Controls.Add(this.btnRegresarACliente);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAccion);
            this.Controls.Add(this.lTituloListado);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dgvListaCheques);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCrh";
            this.Text = "FrmCrh";
            this.Load += new System.EventHandler(this.FrmCrh_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChequeBs)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CuentasBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProveedoresBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesBs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnOrigenBanco;
        private System.Windows.Forms.Button btnOrigenEnCartera;
        private System.Windows.Forms.Button btnOrigenVendor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lfiltro1;
        private System.Windows.Forms.ComboBox cmbFiltroOrigen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb1Cartera;
        private System.Windows.Forms.RadioButton rb1Proveedor;
        private System.Windows.Forms.RadioButton rb1Banco;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource CuentasBs;
        private System.Windows.Forms.BindingSource ChequeBs;
        private System.Windows.Forms.BindingSource ProveedoresBs;
        private System.Windows.Forms.BindingSource ClientesBs;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgvListaCheques;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDCHEQUEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHENUMERODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mONEDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPORTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHE_FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHEBANCODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLIENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cHRECHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMENTARIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteRecibidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuentaTxDataGridViewTextBoxColumn;
        private TSControls.CtlIconos cIcono1Ubicacion;
        private TSControls.CtlFechaTs cChFechaRecibido;
        private TSControls.CtlFechaTs cChFechaAcreditacion;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtChLxRecibido;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtChCliente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChBanco;
        private System.Windows.Forms.TextBox txtIdCheque;
        private System.Windows.Forms.Label label10;
        private TSControls.CtlIconos cIcono5SeleccionCheque;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtGL1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilterChNum;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtChLxEntregado;
        private System.Windows.Forms.TextBox txtChProveedor;
        private System.Windows.Forms.Label label3;
        private TSControls.CtlTextBox cChImporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lTituloListado;
        private System.Windows.Forms.Button btnAccion;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRegresarACliente;
    }
}