namespace MASngFE.Transactional.PP
{
    partial class FrmPP11SelectBatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPP11SelectBatch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMateriaPrima = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckSoloDisponible = new System.Windows.Forms.CheckBox();
            this.dgvStockDisponible = new System.Windows.Forms.DataGridView();
            this.t0030STOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltroLote = new System.Windows.Forms.TextBox();
            this.ckSoloStockMayorIgual = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumeroOF = new System.Windows.Forms.TextBox();
            this.txtMaterialOF = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtKgRequeridos = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSalirCancelarN = new System.Windows.Forms.Button();
            this.btnUninficarLotesN = new System.Windows.Forms.Button();
            this.btnMoverStockN = new System.Windows.Forms.Button();
            this.btnLiberarReservaN = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOFReservaSeleccion = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConfirmarN = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.cKgPendientes = new TSControls.CtlTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cKgUtilizar = new TSControls.CtlTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cKgSeleccionados = new TSControls.CtlTextBox();
            this.ctlAlarmClock1 = new TSControls.CtlAlarmClock();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLoteSeleccionado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ep1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cIconoKgOk = new TSControls.CtlIconos();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtMaterialSeleccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaterialOfReserva = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStatusOfReserva = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.@__idStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__lote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__Sloc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__reservaOF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSelect = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMateriaPrima
            // 
            this.txtMateriaPrima.BackColor = System.Drawing.SystemColors.Control;
            this.txtMateriaPrima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMateriaPrima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMateriaPrima.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMateriaPrima.Location = new System.Drawing.Point(101, 27);
            this.txtMateriaPrima.Name = "txtMateriaPrima";
            this.txtMateriaPrima.ReadOnly = true;
            this.txtMateriaPrima.Size = new System.Drawing.Size(117, 21);
            this.txtMateriaPrima.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "MP Requerida";
            // 
            // ckSoloDisponible
            // 
            this.ckSoloDisponible.AutoSize = true;
            this.ckSoloDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloDisponible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ckSoloDisponible.Location = new System.Drawing.Point(225, 17);
            this.ckSoloDisponible.Name = "ckSoloDisponible";
            this.ckSoloDisponible.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckSoloDisponible.Size = new System.Drawing.Size(354, 19);
            this.ckSoloDisponible.TabIndex = 2;
            this.ckSoloDisponible.Text = "Visualizar Solo Stock Habilitado para Descuento Produccion";
            this.ckSoloDisponible.UseVisualStyleBackColor = true;
            this.ckSoloDisponible.CheckedChanged += new System.EventHandler(this.ckSoloDisponible_CheckedChanged);
            // 
            // dgvStockDisponible
            // 
            this.dgvStockDisponible.AllowUserToAddRows = false;
            this.dgvStockDisponible.AllowUserToDeleteRows = false;
            this.dgvStockDisponible.AllowUserToOrderColumns = true;
            this.dgvStockDisponible.AutoGenerateColumns = false;
            this.dgvStockDisponible.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvStockDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockDisponible.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.@__idStock,
            this.@__Material,
            this.@__lote,
            this.@__stock,
            this.@__Estado,
            this.@__Sloc,
            this.@__reservaOF,
            this.BtnSelect});
            this.dgvStockDisponible.DataSource = this.t0030STOCKBindingSource;
            this.dgvStockDisponible.GridColor = System.Drawing.Color.DarkSlateBlue;
            this.dgvStockDisponible.Location = new System.Drawing.Point(12, 153);
            this.dgvStockDisponible.MultiSelect = false;
            this.dgvStockDisponible.Name = "dgvStockDisponible";
            this.dgvStockDisponible.ReadOnly = true;
            this.dgvStockDisponible.RowHeadersWidth = 30;
            this.dgvStockDisponible.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockDisponible.Size = new System.Drawing.Size(532, 258);
            this.dgvStockDisponible.TabIndex = 3;
            this.dgvStockDisponible.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockDisponible_CellEnter);
            // 
            // t0030STOCKBindingSource
            // 
            this.t0030STOCKBindingSource.DataSource = typeof(TecserEF.Entity.T0030_STOCK);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Lote #";
            // 
            // txtFiltroLote
            // 
            this.txtFiltroLote.BackColor = System.Drawing.Color.White;
            this.txtFiltroLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltroLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroLote.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtFiltroLote.Location = new System.Drawing.Point(55, 27);
            this.txtFiltroLote.Name = "txtFiltroLote";
            this.txtFiltroLote.Size = new System.Drawing.Size(85, 21);
            this.txtFiltroLote.TabIndex = 18;
            this.txtFiltroLote.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltroLote_KeyUp);
            // 
            // ckSoloStockMayorIgual
            // 
            this.ckSoloStockMayorIgual.AutoSize = true;
            this.ckSoloStockMayorIgual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckSoloStockMayorIgual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ckSoloStockMayorIgual.Location = new System.Drawing.Point(225, 38);
            this.ckSoloStockMayorIgual.Name = "ckSoloStockMayorIgual";
            this.ckSoloStockMayorIgual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckSoloStockMayorIgual.Size = new System.Drawing.Size(354, 19);
            this.ckSoloStockMayorIgual.TabIndex = 21;
            this.ckSoloStockMayorIgual.Text = "Visualizar Solo Lineas con Stock Mayor o Igual al Requerido";
            this.ckSoloStockMayorIgual.UseVisualStyleBackColor = true;
            this.ckSoloStockMayorIgual.CheckedChanged += new System.EventHandler(this.ckSoloStockMayorIgual_CheckedChanged);
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.MidnightBlue;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LineaIzq.Location = new System.Drawing.Point(3, 3);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 643);
            this.LineaIzq.TabIndex = 184;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DimGray;
            this.lineaArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lineaArriba.Location = new System.Drawing.Point(3, 3);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(877, 3);
            this.lineaArriba.TabIndex = 183;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.txtNumeroOF);
            this.panel5.Controls.Add(this.txtMaterialOF);
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(9, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(866, 53);
            this.panel5.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Material OF";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "OF #";
            // 
            // txtNumeroOF
            // 
            this.txtNumeroOF.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNumeroOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOF.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNumeroOF.Location = new System.Drawing.Point(83, 5);
            this.txtNumeroOF.Name = "txtNumeroOF";
            this.txtNumeroOF.ReadOnly = true;
            this.txtNumeroOF.Size = new System.Drawing.Size(60, 21);
            this.txtNumeroOF.TabIndex = 0;
            // 
            // txtMaterialOF
            // 
            this.txtMaterialOF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialOF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialOF.Location = new System.Drawing.Point(83, 27);
            this.txtMaterialOF.Name = "txtMaterialOF";
            this.txtMaterialOF.ReadOnly = true;
            this.txtMaterialOF.Size = new System.Drawing.Size(114, 21);
            this.txtMaterialOF.TabIndex = 5;
            this.txtMaterialOF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtKgRequeridos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMateriaPrima);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 77);
            this.groupBox1.TabIndex = 185;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Material A Descontar ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 3;
            this.label11.Text = "Cantidad [KG]";
            // 
            // txtKgRequeridos
            // 
            this.txtKgRequeridos.BackColor = System.Drawing.SystemColors.Control;
            this.txtKgRequeridos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKgRequeridos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgRequeridos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtKgRequeridos.Location = new System.Drawing.Point(101, 49);
            this.txtKgRequeridos.Name = "txtKgRequeridos";
            this.txtKgRequeridos.ReadOnly = true;
            this.txtKgRequeridos.Size = new System.Drawing.Size(71, 21);
            this.txtKgRequeridos.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkMagenta;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label12.Location = new System.Drawing.Point(9, 63);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(866, 3);
            this.label12.TabIndex = 186;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.ckSoloStockMayorIgual);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFiltroLote);
            this.groupBox2.Controls.Add(this.ckSoloDisponible);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(245, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 77);
            this.groupBox2.TabIndex = 186;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opciones de Busqueda";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkMagenta;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(9, 147);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(866, 3);
            this.label5.TabIndex = 187;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.btnUninficarLotesN);
            this.groupBox3.Controls.Add(this.btnMoverStockN);
            this.groupBox3.Controls.Add(this.ctlAlarmClock1);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(10, 566);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(534, 71);
            this.groupBox3.TabIndex = 187;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Otras Acciones Stock Seleccionado";
            // 
            // btnSalirCancelarN
            // 
            this.btnSalirCancelarN.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirCancelarN.Image = ((System.Drawing.Image)(resources.GetObject("btnSalirCancelarN.Image")));
            this.btnSalirCancelarN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalirCancelarN.Location = new System.Drawing.Point(761, 195);
            this.btnSalirCancelarN.Name = "btnSalirCancelarN";
            this.btnSalirCancelarN.Size = new System.Drawing.Size(100, 40);
            this.btnSalirCancelarN.TabIndex = 209;
            this.btnSalirCancelarN.Text = "Cancelar";
            this.btnSalirCancelarN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalirCancelarN.UseVisualStyleBackColor = true;
            this.btnSalirCancelarN.Click += new System.EventHandler(this.btnSalirCancelarN_Click);
            // 
            // btnUninficarLotesN
            // 
            this.btnUninficarLotesN.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUninficarLotesN.Image = ((System.Drawing.Image)(resources.GetObject("btnUninficarLotesN.Image")));
            this.btnUninficarLotesN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUninficarLotesN.Location = new System.Drawing.Point(122, 25);
            this.btnUninficarLotesN.Name = "btnUninficarLotesN";
            this.btnUninficarLotesN.Size = new System.Drawing.Size(100, 40);
            this.btnUninficarLotesN.TabIndex = 207;
            this.btnUninficarLotesN.Text = "Uniificar\r\nLotes";
            this.btnUninficarLotesN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUninficarLotesN.UseVisualStyleBackColor = true;
            this.btnUninficarLotesN.Click += new System.EventHandler(this.btnUninficarLotesN_Click);
            // 
            // btnMoverStockN
            // 
            this.btnMoverStockN.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoverStockN.Image = ((System.Drawing.Image)(resources.GetObject("btnMoverStockN.Image")));
            this.btnMoverStockN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoverStockN.Location = new System.Drawing.Point(21, 25);
            this.btnMoverStockN.Name = "btnMoverStockN";
            this.btnMoverStockN.Size = new System.Drawing.Size(100, 40);
            this.btnMoverStockN.TabIndex = 206;
            this.btnMoverStockN.Text = "Mover \r\nStock";
            this.btnMoverStockN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMoverStockN.UseVisualStyleBackColor = true;
            this.btnMoverStockN.Click += new System.EventHandler(this.btnMoverStockN_Click);
            // 
            // btnLiberarReservaN
            // 
            this.btnLiberarReservaN.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiberarReservaN.Image = ((System.Drawing.Image)(resources.GetObject("btnLiberarReservaN.Image")));
            this.btnLiberarReservaN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiberarReservaN.Location = new System.Drawing.Point(269, 98);
            this.btnLiberarReservaN.Name = "btnLiberarReservaN";
            this.btnLiberarReservaN.Size = new System.Drawing.Size(100, 40);
            this.btnLiberarReservaN.TabIndex = 205;
            this.btnLiberarReservaN.Text = "Liberar\r\nReserva";
            this.btnLiberarReservaN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLiberarReservaN.UseVisualStyleBackColor = true;
            this.btnLiberarReservaN.Click += new System.EventHandler(this.btnLiberarReservaN_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(47, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 15);
            this.label16.TabIndex = 30;
            this.label16.Text = "Reserva OF#";
            // 
            // txtOFReservaSeleccion
            // 
            this.txtOFReservaSeleccion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOFReservaSeleccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOFReservaSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOFReservaSeleccion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtOFReservaSeleccion.Location = new System.Drawing.Point(131, 75);
            this.txtOFReservaSeleccion.Name = "txtOFReservaSeleccion";
            this.txtOFReservaSeleccion.ReadOnly = true;
            this.txtOFReservaSeleccion.Size = new System.Drawing.Size(61, 21);
            this.txtOFReservaSeleccion.TabIndex = 29;
            this.txtOFReservaSeleccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox4.Controls.Add(this.cIconoKgOk);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.cKgPendientes);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.cKgUtilizar);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cKgSeleccionados);
            this.groupBox4.Location = new System.Drawing.Point(547, 153);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 117);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informacion KG";
            // 
            // btnConfirmarN
            // 
            this.btnConfirmarN.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarN.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmarN.Image")));
            this.btnConfirmarN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarN.Location = new System.Drawing.Point(761, 154);
            this.btnConfirmarN.Name = "btnConfirmarN";
            this.btnConfirmarN.Size = new System.Drawing.Size(100, 40);
            this.btnConfirmarN.TabIndex = 208;
            this.btnConfirmarN.Text = "Confirmar\r\nReserva";
            this.btnConfirmarN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarN.UseVisualStyleBackColor = true;
            this.btnConfirmarN.Click += new System.EventHandler(this.btnConfirmarN_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(28, 73);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 15);
            this.label15.TabIndex = 29;
            this.label15.Text = "Pendientes";
            // 
            // cKgPendientes
            // 
            this.cKgPendientes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cKgPendientes.BackColor = System.Drawing.SystemColors.Control;
            this.cKgPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cKgPendientes.ForeColor = System.Drawing.Color.Black;
            this.cKgPendientes.Location = new System.Drawing.Point(104, 70);
            this.cKgPendientes.Margin = new System.Windows.Forms.Padding(0);
            this.cKgPendientes.Name = "cKgPendientes";
            this.cKgPendientes.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cKgPendientes.SetDecimales = 2;
            this.cKgPendientes.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.cKgPendientes.Size = new System.Drawing.Size(73, 21);
            this.cKgPendientes.TabIndex = 30;
            this.cKgPendientes.ValorMaximo = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.cKgPendientes.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cKgPendientes.XReadOnly = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(21, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 15);
            this.label14.TabIndex = 27;
            this.label14.Text = "A Reservar";
            // 
            // cKgUtilizar
            // 
            this.cKgUtilizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cKgUtilizar.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cKgUtilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cKgUtilizar.ForeColor = System.Drawing.Color.Black;
            this.cKgUtilizar.Location = new System.Drawing.Point(104, 47);
            this.cKgUtilizar.Margin = new System.Windows.Forms.Padding(0);
            this.cKgUtilizar.Name = "cKgUtilizar";
            this.cKgUtilizar.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cKgUtilizar.SetDecimales = 2;
            this.cKgUtilizar.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.cKgUtilizar.Size = new System.Drawing.Size(73, 21);
            this.cKgUtilizar.TabIndex = 28;
            this.cKgUtilizar.ValorMaximo = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.cKgUtilizar.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cKgUtilizar.XReadOnly = true;
            this.cKgUtilizar.Validating += new System.ComponentModel.CancelEventHandler(this.cKgUtilizar_Validating);
            this.cKgUtilizar.Validated += new System.EventHandler(this.cKgUtilizar_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(36, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "Seleccion";
            // 
            // cKgSeleccionados
            // 
            this.cKgSeleccionados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cKgSeleccionados.BackColor = System.Drawing.SystemColors.Control;
            this.cKgSeleccionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cKgSeleccionados.ForeColor = System.Drawing.Color.Black;
            this.cKgSeleccionados.Location = new System.Drawing.Point(104, 24);
            this.cKgSeleccionados.Margin = new System.Windows.Forms.Padding(0);
            this.cKgSeleccionados.Name = "cKgSeleccionados";
            this.cKgSeleccionados.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cKgSeleccionados.SetDecimales = 2;
            this.cKgSeleccionados.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.cKgSeleccionados.Size = new System.Drawing.Size(73, 21);
            this.cKgSeleccionados.TabIndex = 26;
            this.cKgSeleccionados.ValorMaximo = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.cKgSeleccionados.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cKgSeleccionados.XReadOnly = true;
            // 
            // ctlAlarmClock1
            // 
            this.ctlAlarmClock1.AlarmSet = false;
            this.ctlAlarmClock1.AlarmTime = new System.DateTime(((long)(0)));
            this.ctlAlarmClock1.ClockBackColor = System.Drawing.Color.Empty;
            this.ctlAlarmClock1.ClockForeColor = System.Drawing.Color.Empty;
            this.ctlAlarmClock1.Location = new System.Drawing.Point(89, 153);
            this.ctlAlarmClock1.Name = "ctlAlarmClock1";
            this.ctlAlarmClock1.Size = new System.Drawing.Size(8, 8);
            this.ctlAlarmClock1.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(84, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "Lote #";
            // 
            // txtLoteSeleccionado
            // 
            this.txtLoteSeleccionado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLoteSeleccionado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoteSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoteSeleccionado.ForeColor = System.Drawing.Color.Crimson;
            this.txtLoteSeleccionado.Location = new System.Drawing.Point(131, 52);
            this.txtLoteSeleccionado.Name = "txtLoteSeleccionado";
            this.txtLoteSeleccionado.ReadOnly = true;
            this.txtLoteSeleccionado.Size = new System.Drawing.Size(130, 21);
            this.txtLoteSeleccionado.TabIndex = 22;
            this.txtLoteSeleccionado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DimGray;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label10.Location = new System.Drawing.Point(3, 643);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(877, 3);
            this.label10.TabIndex = 188;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.MidnightBlue;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label17.Location = new System.Drawing.Point(879, 3);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(3, 643);
            this.label17.TabIndex = 189;
            // 
            // ep1
            // 
            this.ep1.ContainerControl = this;
            // 
            // cIconoKgOk
            // 
            this.cIconoKgOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cIconoKgOk.IconLocation = TSControls.UbicacionIcono.Normal;
            this.cIconoKgOk.IconSize = TSControls.TamañoIcono.Chico;
            this.cIconoKgOk.Location = new System.Drawing.Point(183, 52);
            this.cIconoKgOk.Name = "cIconoKgOk";
            this.cIconoKgOk.Set = TSControls.CIconos.ExclamacionYellow;
            this.cIconoKgOk.Size = new System.Drawing.Size(16, 16);
            this.cIconoKgOk.TabIndex = 210;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtStatusOfReserva);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.btnLiberarReservaN);
            this.groupBox5.Controls.Add(this.txtMaterialOfReserva);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtMaterialSeleccion);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtLoteSeleccionado);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtOFReservaSeleccion);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Location = new System.Drawing.Point(13, 414);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(531, 149);
            this.groupBox5.TabIndex = 190;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datos de Reserva Existente";
            // 
            // txtMaterialSeleccion
            // 
            this.txtMaterialSeleccion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMaterialSeleccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialSeleccion.ForeColor = System.Drawing.Color.Crimson;
            this.txtMaterialSeleccion.Location = new System.Drawing.Point(131, 29);
            this.txtMaterialSeleccion.Name = "txtMaterialSeleccion";
            this.txtMaterialSeleccion.ReadOnly = true;
            this.txtMaterialSeleccion.Size = new System.Drawing.Size(130, 21);
            this.txtMaterialSeleccion.TabIndex = 31;
            this.txtMaterialSeleccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(73, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Material";
            // 
            // txtMaterialOfReserva
            // 
            this.txtMaterialOfReserva.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMaterialOfReserva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialOfReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialOfReserva.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtMaterialOfReserva.Location = new System.Drawing.Point(131, 98);
            this.txtMaterialOfReserva.Name = "txtMaterialOfReserva";
            this.txtMaterialOfReserva.ReadOnly = true;
            this.txtMaterialOfReserva.Size = new System.Drawing.Size(130, 21);
            this.txtMaterialOfReserva.TabIndex = 33;
            this.txtMaterialOfReserva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 34;
            this.label4.Text = "Material OF Reserva";
            // 
            // txtStatusOfReserva
            // 
            this.txtStatusOfReserva.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtStatusOfReserva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatusOfReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatusOfReserva.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtStatusOfReserva.Location = new System.Drawing.Point(131, 121);
            this.txtStatusOfReserva.Name = "txtStatusOfReserva";
            this.txtStatusOfReserva.ReadOnly = true;
            this.txtStatusOfReserva.Size = new System.Drawing.Size(130, 21);
            this.txtStatusOfReserva.TabIndex = 35;
            this.txtStatusOfReserva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(17, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 15);
            this.label9.TabIndex = 36;
            this.label9.Text = "Status OF Reserva";
            // 
            // __idStock
            // 
            this.@__idStock.DataPropertyName = "IDStock";
            this.@__idStock.HeaderText = "IDStock";
            this.@__idStock.Name = "__idStock";
            this.@__idStock.ReadOnly = true;
            this.@__idStock.Visible = false;
            this.@__idStock.Width = 30;
            // 
            // __Material
            // 
            this.@__Material.DataPropertyName = "Material";
            this.@__Material.HeaderText = "Material";
            this.@__Material.Name = "__Material";
            this.@__Material.ReadOnly = true;
            // 
            // __lote
            // 
            this.@__lote.DataPropertyName = "Batch";
            this.@__lote.HeaderText = "Lote #";
            this.@__lote.Name = "__lote";
            this.@__lote.ReadOnly = true;
            this.@__lote.Width = 110;
            // 
            // __stock
            // 
            this.@__stock.DataPropertyName = "Stock";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.@__stock.DefaultCellStyle = dataGridViewCellStyle1;
            this.@__stock.HeaderText = "KG";
            this.@__stock.Name = "__stock";
            this.@__stock.ReadOnly = true;
            this.@__stock.ToolTipText = "KG Stock Disponible";
            this.@__stock.Width = 70;
            // 
            // __Estado
            // 
            this.@__Estado.DataPropertyName = "Estado";
            this.@__Estado.HeaderText = "Estado";
            this.@__Estado.Name = "__Estado";
            this.@__Estado.ReadOnly = true;
            this.@__Estado.Width = 70;
            // 
            // __Sloc
            // 
            this.@__Sloc.DataPropertyName = "SLOC";
            this.@__Sloc.HeaderText = "Sloc";
            this.@__Sloc.Name = "__Sloc";
            this.@__Sloc.ReadOnly = true;
            this.@__Sloc.Width = 40;
            // 
            // __reservaOF
            // 
            this.@__reservaOF.DataPropertyName = "ReservaOF";
            this.@__reservaOF.HeaderText = "Reserva";
            this.@__reservaOF.Name = "__reservaOF";
            this.@__reservaOF.ReadOnly = true;
            this.@__reservaOF.ToolTipText = "Numero de OF# Reserva";
            this.@__reservaOF.Width = 70;
            // 
            // BtnSelect
            // 
            this.BtnSelect.HeaderText = "SELECT";
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.ReadOnly = true;
            this.BtnSelect.Text = "SELECT";
            this.BtnSelect.UseColumnTextForButtonValue = true;
            this.BtnSelect.Visible = false;
            this.BtnSelect.Width = 60;
            // 
            // FrmPP11SelectBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(885, 646);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnConfirmarN);
            this.Controls.Add(this.btnSalirCancelarN);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.dgvStockDisponible);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FrmPP11SelectBatch";
            this.Text = "PP11 - Seleccion de Lote - Cierre OF";
            this.Load += new System.EventHandler(this.FrmSeleccionBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0030STOCKBindingSource)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtMateriaPrima;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckSoloDisponible;
        private System.Windows.Forms.DataGridView dgvStockDisponible;
        private System.Windows.Forms.BindingSource t0030STOCKBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltroLote;
        private System.Windows.Forms.CheckBox ckSoloStockMayorIgual;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumeroOF;
        private System.Windows.Forms.TextBox txtMaterialOF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKgRequeridos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLoteSeleccionado;
        private TSControls.CtlAlarmClock ctlAlarmClock1;
        private TSControls.CtlTextBox cKgSeleccionados;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label15;
        private TSControls.CtlTextBox cKgPendientes;
        private System.Windows.Forms.Label label14;
        private TSControls.CtlTextBox cKgUtilizar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtOFReservaSeleccion;
        private System.Windows.Forms.Button btnLiberarReservaN;
        private System.Windows.Forms.Button btnUninficarLotesN;
        private System.Windows.Forms.Button btnMoverStockN;
        private System.Windows.Forms.Button btnConfirmarN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSalirCancelarN;
        private System.Windows.Forms.ErrorProvider ep1;
        private TSControls.CtlIconos cIconoKgOk;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtStatusOfReserva;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaterialOfReserva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaterialSeleccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn __idStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn __Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn __lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn __stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn __Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn __Sloc;
        private System.Windows.Forms.DataGridViewTextBoxColumn __reservaOF;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSelect;
    }
}