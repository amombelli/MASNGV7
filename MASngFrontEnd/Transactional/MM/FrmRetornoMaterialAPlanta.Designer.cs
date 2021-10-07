namespace MASngFE.Transactional.MM
{
    partial class FrmRetornoMaterialAPlanta
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
            this.t0006MCLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.cmbAprobadoPor = new System.Windows.Forms.ComboBox();
            this.t0028SLOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRecibidoPor = new System.Windows.Forms.ComboBox();
            this.t0011MATERIALESAKABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnImprimirRecepcion = new System.Windows.Forms.Button();
            this.txtMotivoDevolucion = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.grpMotivo = new System.Windows.Forms.GroupBox();
            this.rbOtro = new System.Windows.Forms.RadioButton();
            this.rbPedidoIncorrecto = new System.Windows.Forms.RadioButton();
            this.rbStockSobrante = new System.Windows.Forms.RadioButton();
            this.rbFE = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.txtIdH = new System.Windows.Forms.TextBox();
            this.ctlSemaforo1 = new TSControls.CtlSemaforo();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.cmbSloc = new System.Windows.Forms.ComboBox();
            this.cFechaRececpcion = new TSControls.CtlFechaTs();
            this.label7 = new System.Windows.Forms.Label();
            this.cSemLoteRecibidoOk = new TSControls.CtlSemaforo();
            this.txtNumeroLoteRecepcion = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cSemCantidadOk = new TSControls.CtlSemaforo();
            this.label26 = new System.Windows.Forms.Label();
            this.cSemMaterialOk = new TSControls.CtlSemaforo();
            this.cCantidadRtn = new TSControls.CtlTextBox();
            this.txtMaterialRecibido = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tsUcCustomerSearch11 = new MASngFE._0TSUserControls.TsUcCustomerSearch1();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0011MATERIALESAKABindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.grpMotivo.SuspendLayout();
            this.grp1.SuspendLayout();
            this.SuspendLayout();
            // 
            // t0006MCLIENTESBindingSource
            // 
            this.t0006MCLIENTESBindingSource.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(63, 452);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 15);
            this.label11.TabIndex = 107;
            this.label11.Text = "Operacion Aprobada Por";
            // 
            // cmbAprobadoPor
            // 
            this.cmbAprobadoPor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAprobadoPor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAprobadoPor.DisplayMember = "SHORTNA";
            this.cmbAprobadoPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAprobadoPor.FormattingEnabled = true;
            this.cmbAprobadoPor.Location = new System.Drawing.Point(212, 448);
            this.cmbAprobadoPor.Name = "cmbAprobadoPor";
            this.cmbAprobadoPor.Size = new System.Drawing.Size(158, 23);
            this.cmbAprobadoPor.TabIndex = 106;
            this.cmbAprobadoPor.Validating += new System.ComponentModel.CancelEventHandler(this.cmbRecibidoPor_Validating);
            // 
            // t0028SLOCBindingSource
            // 
            this.t0028SLOCBindingSource.DataSource = typeof(TecserEF.Entity.T0028_SLOC);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 426);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 15);
            this.label5.TabIndex = 99;
            this.label5.Text = "Responsable Recepcion Material";
            // 
            // cmbRecibidoPor
            // 
            this.cmbRecibidoPor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRecibidoPor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRecibidoPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecibidoPor.FormattingEnabled = true;
            this.cmbRecibidoPor.Location = new System.Drawing.Point(212, 422);
            this.cmbRecibidoPor.Name = "cmbRecibidoPor";
            this.cmbRecibidoPor.Size = new System.Drawing.Size(158, 23);
            this.cmbRecibidoPor.TabIndex = 98;
            this.cmbRecibidoPor.Validating += new System.ComponentModel.CancelEventHandler(this.cmbRecibidoPor_Validating);
            // 
            // t0011MATERIALESAKABindingSource
            // 
            this.t0011MATERIALESAKABindingSource.DataSource = typeof(TecserEF.Entity.T0011_MATERIALES_AKA);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(584, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 41);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(584, 50);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(100, 41);
            this.btnIngresar.TabIndex = 94;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnImprimirRecepcion
            // 
            this.btnImprimirRecepcion.Location = new System.Drawing.Point(584, 91);
            this.btnImprimirRecepcion.Name = "btnImprimirRecepcion";
            this.btnImprimirRecepcion.Size = new System.Drawing.Size(100, 41);
            this.btnImprimirRecepcion.TabIndex = 95;
            this.btnImprimirRecepcion.Text = "Imprimir Recepcion";
            this.btnImprimirRecepcion.UseVisualStyleBackColor = true;
            this.btnImprimirRecepcion.Click += new System.EventHandler(this.btnImprimirRecepcion_Click);
            // 
            // txtMotivoDevolucion
            // 
            this.txtMotivoDevolucion.BackColor = System.Drawing.SystemColors.Info;
            this.txtMotivoDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoDevolucion.Location = new System.Drawing.Point(5, 135);
            this.txtMotivoDevolucion.Multiline = true;
            this.txtMotivoDevolucion.Name = "txtMotivoDevolucion";
            this.txtMotivoDevolucion.Size = new System.Drawing.Size(375, 32);
            this.txtMotivoDevolucion.TabIndex = 109;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.grpMotivo);
            this.panel4.Controls.Add(this.txtMotivoDevolucion);
            this.panel4.Location = new System.Drawing.Point(7, 246);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(386, 172);
            this.panel4.TabIndex = 111;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 15);
            this.label12.TabIndex = 110;
            this.label12.Text = "Comentario Adicional  / Detalle";
            // 
            // grpMotivo
            // 
            this.grpMotivo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.grpMotivo.Controls.Add(this.rbOtro);
            this.grpMotivo.Controls.Add(this.rbPedidoIncorrecto);
            this.grpMotivo.Controls.Add(this.rbStockSobrante);
            this.grpMotivo.Controls.Add(this.rbFE);
            this.grpMotivo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMotivo.Location = new System.Drawing.Point(6, 4);
            this.grpMotivo.Name = "grpMotivo";
            this.grpMotivo.Size = new System.Drawing.Size(374, 108);
            this.grpMotivo.TabIndex = 110;
            this.grpMotivo.TabStop = false;
            // 
            // rbOtro
            // 
            this.rbOtro.AutoSize = true;
            this.rbOtro.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOtro.Location = new System.Drawing.Point(11, 82);
            this.rbOtro.Name = "rbOtro";
            this.rbOtro.Size = new System.Drawing.Size(179, 19);
            this.rbOtro.TabIndex = 4;
            this.rbOtro.TabStop = true;
            this.rbOtro.Text = "Otro (Especificar en Detalle)";
            this.rbOtro.UseVisualStyleBackColor = true;
            this.rbOtro.CheckedChanged += new System.EventHandler(this.rbOtro_CheckedChanged);
            // 
            // rbPedidoIncorrecto
            // 
            this.rbPedidoIncorrecto.AutoSize = true;
            this.rbPedidoIncorrecto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPedidoIncorrecto.Location = new System.Drawing.Point(11, 59);
            this.rbPedidoIncorrecto.Name = "rbPedidoIncorrecto";
            this.rbPedidoIncorrecto.Size = new System.Drawing.Size(360, 19);
            this.rbPedidoIncorrecto.TabIndex = 3;
            this.rbPedidoIncorrecto.TabStop = true;
            this.rbPedidoIncorrecto.Text = "Pedido Incorrecto/Error del Cliente (Devolucion Buen Estado)";
            this.rbPedidoIncorrecto.UseVisualStyleBackColor = true;
            this.rbPedidoIncorrecto.CheckedChanged += new System.EventHandler(this.rbOtro_CheckedChanged);
            // 
            // rbStockSobrante
            // 
            this.rbStockSobrante.AutoSize = true;
            this.rbStockSobrante.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStockSobrante.Location = new System.Drawing.Point(11, 13);
            this.rbStockSobrante.Name = "rbStockSobrante";
            this.rbStockSobrante.Size = new System.Drawing.Size(322, 19);
            this.rbStockSobrante.TabIndex = 1;
            this.rbStockSobrante.TabStop = true;
            this.rbStockSobrante.Text = "Stock Sobrante de Cliente (Devolucion en Buen Estado)";
            this.rbStockSobrante.UseVisualStyleBackColor = true;
            this.rbStockSobrante.CheckedChanged += new System.EventHandler(this.rbOtro_CheckedChanged);
            // 
            // rbFE
            // 
            this.rbFE.AutoSize = true;
            this.rbFE.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFE.Location = new System.Drawing.Point(11, 36);
            this.rbFE.Name = "rbFE";
            this.rbFE.Size = new System.Drawing.Size(283, 19);
            this.rbFE.TabIndex = 2;
            this.rbFE.TabStop = true;
            this.rbFE.Text = "Fuera de Especificacion del Material Entregado";
            this.rbFE.UseVisualStyleBackColor = true;
            this.rbFE.CheckedChanged += new System.EventHandler(this.rbOtro_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 223);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(256, 15);
            this.label16.TabIndex = 110;
            this.label16.Text = "Motivo Devolucion / Retorno Material a Planta";
            // 
            // txtIdH
            // 
            this.txtIdH.Location = new System.Drawing.Point(545, 9);
            this.txtIdH.Name = "txtIdH";
            this.txtIdH.ReadOnly = true;
            this.txtIdH.Size = new System.Drawing.Size(33, 20);
            this.txtIdH.TabIndex = 113;
            // 
            // ctlSemaforo1
            // 
            this.ctlSemaforo1.Location = new System.Drawing.Point(223, 114);
            this.ctlSemaforo1.Name = "ctlSemaforo1";
            this.ctlSemaforo1.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Rojo;
            this.ctlSemaforo1.Size = new System.Drawing.Size(23, 23);
            this.ctlSemaforo1.TabIndex = 115;
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.cmbSloc);
            this.grp1.Controls.Add(this.cFechaRececpcion);
            this.grp1.Controls.Add(this.label7);
            this.grp1.Controls.Add(this.cSemLoteRecibidoOk);
            this.grp1.Controls.Add(this.txtNumeroLoteRecepcion);
            this.grp1.Controls.Add(this.label28);
            this.grp1.Controls.Add(this.label9);
            this.grp1.Controls.Add(this.cSemCantidadOk);
            this.grp1.Controls.Add(this.label26);
            this.grp1.Controls.Add(this.cSemMaterialOk);
            this.grp1.Controls.Add(this.cCantidadRtn);
            this.grp1.Controls.Add(this.txtMaterialRecibido);
            this.grp1.Controls.Add(this.label25);
            this.grp1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp1.Location = new System.Drawing.Point(9, 100);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(500, 118);
            this.grp1.TabIndex = 117;
            this.grp1.TabStop = false;
            this.grp1.Text = "Identificacion Material";
            // 
            // cmbSloc
            // 
            this.cmbSloc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSloc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSloc.DataSource = this.t0028SLOCBindingSource;
            this.cmbSloc.DisplayMember = "SLOC";
            this.cmbSloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSloc.FormattingEnabled = true;
            this.cmbSloc.Location = new System.Drawing.Point(399, 88);
            this.cmbSloc.Name = "cmbSloc";
            this.cmbSloc.Size = new System.Drawing.Size(93, 23);
            this.cmbSloc.TabIndex = 329;
            this.cmbSloc.ValueMember = "SLOC";
            // 
            // cFechaRececpcion
            // 
            this.cFechaRececpcion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cFechaRececpcion.BackColor = System.Drawing.SystemColors.Control;
            this.cFechaRececpcion.CheckPeriodoFIAuto = false;
            this.cFechaRececpcion.ColorFondoFecha = System.Drawing.Color.Empty;
            this.cFechaRececpcion.ColorForeFecha = System.Drawing.Color.Empty;
            this.cFechaRececpcion.FechaMaxima = null;
            this.cFechaRececpcion.FechaMinima = null;
            this.cFechaRececpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cFechaRececpcion.Location = new System.Drawing.Point(121, 88);
            this.cFechaRececpcion.Margin = new System.Windows.Forms.Padding(0);
            this.cFechaRececpcion.Name = "cFechaRececpcion";
            this.cFechaRececpcion.ObtieneTCAuto = false;
            this.cFechaRececpcion.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Green;
            this.cFechaRececpcion.Size = new System.Drawing.Size(97, 23);
            this.cFechaRececpcion.TabIndex = 326;
            this.cFechaRececpcion.ValidarRangoFecha = false;
            this.cFechaRececpcion.Value = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(276, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 15);
            this.label7.TabIndex = 330;
            this.label7.Text = "Ubicacion en Planta";
            // 
            // cSemLoteRecibidoOk
            // 
            this.cSemLoteRecibidoOk.Location = new System.Drawing.Point(242, 62);
            this.cSemLoteRecibidoOk.Name = "cSemLoteRecibidoOk";
            this.cSemLoteRecibidoOk.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.cSemLoteRecibidoOk.Size = new System.Drawing.Size(23, 22);
            this.cSemLoteRecibidoOk.TabIndex = 322;
            // 
            // txtNumeroLoteRecepcion
            // 
            this.txtNumeroLoteRecepcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroLoteRecepcion.Location = new System.Drawing.Point(122, 65);
            this.txtNumeroLoteRecepcion.Name = "txtNumeroLoteRecepcion";
            this.txtNumeroLoteRecepcion.Size = new System.Drawing.Size(112, 21);
            this.txtNumeroLoteRecepcion.TabIndex = 321;
            this.txtNumeroLoteRecepcion.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroLoteRecepcion_Validating);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(34, 68);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(83, 15);
            this.label28.TabIndex = 320;
            this.label28.Text = "Lote Recibido";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.label9.TabIndex = 319;
            this.label9.Text = "Fecha Retorno";
            // 
            // cSemCantidadOk
            // 
            this.cSemCantidadOk.Location = new System.Drawing.Point(242, 40);
            this.cSemCantidadOk.Name = "cSemCantidadOk";
            this.cSemCantidadOk.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.cSemCantidadOk.Size = new System.Drawing.Size(23, 22);
            this.cSemCantidadOk.TabIndex = 318;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(33, 45);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(84, 15);
            this.label26.TabIndex = 317;
            this.label26.Text = "Cantidad RTN";
            // 
            // cSemMaterialOk
            // 
            this.cSemMaterialOk.Location = new System.Drawing.Point(242, 18);
            this.cSemMaterialOk.Name = "cSemMaterialOk";
            this.cSemMaterialOk.SetLights = TSControls.CtlSemaforo.ColoresSemaforo.Amarillo;
            this.cSemMaterialOk.Size = new System.Drawing.Size(23, 22);
            this.cSemMaterialOk.TabIndex = 118;
            // 
            // cCantidadRtn
            // 
            this.cCantidadRtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cCantidadRtn.BackColor = System.Drawing.Color.White;
            this.cCantidadRtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cCantidadRtn.Location = new System.Drawing.Point(122, 42);
            this.cCantidadRtn.Margin = new System.Windows.Forms.Padding(0);
            this.cCantidadRtn.Name = "cCantidadRtn";
            this.cCantidadRtn.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cCantidadRtn.SetDecimales = 2;
            this.cCantidadRtn.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.cCantidadRtn.Size = new System.Drawing.Size(112, 21);
            this.cCantidadRtn.TabIndex = 316;
            this.cCantidadRtn.ValorMaximo = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.cCantidadRtn.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cCantidadRtn.XReadOnly = false;
            this.cCantidadRtn.Validating += new System.ComponentModel.CancelEventHandler(this.cCantidadRtn_Validating);
            // 
            // txtMaterialRecibido
            // 
            this.txtMaterialRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialRecibido.Location = new System.Drawing.Point(122, 19);
            this.txtMaterialRecibido.Name = "txtMaterialRecibido";
            this.txtMaterialRecibido.Size = new System.Drawing.Size(112, 21);
            this.txtMaterialRecibido.TabIndex = 117;
            this.txtMaterialRecibido.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaterialRecibido_Validating);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(13, 22);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(104, 15);
            this.label25.TabIndex = 109;
            this.label25.Text = "Material Recibido";
            // 
            // tsUcCustomerSearch11
            // 
            this.tsUcCustomerSearch11.ClienteId = null;
            this.tsUcCustomerSearch11.Location = new System.Drawing.Point(6, 8);
            this.tsUcCustomerSearch11.Name = "tsUcCustomerSearch11";
            this.tsUcCustomerSearch11.Size = new System.Drawing.Size(537, 89);
            this.tsUcCustomerSearch11.TabIndex = 324;
            this.tsUcCustomerSearch11.ClienteModificado += new MASngFE._0TSUserControls.TsUcCustomerSearch1.ClienteModificadoEventHandler(this.tsUcCustomerSearch11_ClienteModificado);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.label1.Location = new System.Drawing.Point(376, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 15);
            this.label1.TabIndex = 111;
            this.label1.Text = "Verificacion de la devolucion del material (en planta)";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(807, 3);
            this.label2.TabIndex = 325;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(2, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(809, 3);
            this.label3.TabIndex = 326;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(2, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(3, 478);
            this.label4.TabIndex = 327;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Navy;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(808, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(3, 478);
            this.label6.TabIndex = 328;
            // 
            // FrmRetornoMaterialAPlanta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(813, 486);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tsUcCustomerSearch11);
            this.Controls.Add(this.cmbAprobadoPor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.grp1);
            this.Controls.Add(this.ctlSemaforo1);
            this.Controls.Add(this.txtIdH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbRecibidoPor);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnImprimirRecepcion);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmRetornoMaterialAPlanta";
            this.Text = "MM63 - Retorno de Material A Planta con Remito";
            this.Load += new System.EventHandler(this.FrmRetornoMaterialAPlanta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0028SLOCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0011MATERIALESAKABindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.grpMotivo.ResumeLayout(false);
            this.grpMotivo.PerformLayout();
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource t0006MCLIENTESBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbAprobadoPor;
        private System.Windows.Forms.BindingSource t0011MATERIALESAKABindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRecibidoPor;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnImprimirRecepcion;
        private System.Windows.Forms.TextBox txtMotivoDevolucion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.BindingSource t0028SLOCBindingSource;
        private System.Windows.Forms.RadioButton rbOtro;
        private System.Windows.Forms.RadioButton rbPedidoIncorrecto;
        private System.Windows.Forms.RadioButton rbFE;
        private System.Windows.Forms.RadioButton rbStockSobrante;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox grpMotivo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIdH;
        private TSControls.CtlSemaforo ctlSemaforo1;
        private System.Windows.Forms.GroupBox grp1;
        private System.Windows.Forms.TextBox txtMaterialRecibido;
        private System.Windows.Forms.Label label25;
        private TSControls.CtlSemaforo cSemCantidadOk;
        private System.Windows.Forms.Label label26;
        private TSControls.CtlSemaforo cSemMaterialOk;
        private TSControls.CtlTextBox cCantidadRtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumeroLoteRecepcion;
        private System.Windows.Forms.Label label28;
        private TSControls.CtlSemaforo cSemLoteRecibidoOk;
        private _0TSUserControls.TsUcCustomerSearch1 tsUcCustomerSearch11;
        private TSControls.CtlFechaTs cFechaRececpcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSloc;
        private System.Windows.Forms.Label label7;
    }
}