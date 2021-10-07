namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    partial class FrmFI32OpAddItemPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI32OpAddItemPago));
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAddItemPago = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumeroOP = new System.Windows.Forms.TextBox();
            this.cmbCuenta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.txtTipoCuenta = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.panelCheques = new System.Windows.Forms.Panel();
            this.cFechaAcreditacion = new TSControls.CtlFechaTs();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumeroCheque = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBancoDescripcion = new System.Windows.Forms.TextBox();
            this.txtNumBanco = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtImporteOrigen = new TSControls.CtlTextBox();
            this.rbTransferencia = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbEcheque = new System.Windows.Forms.RadioButton();
            this.rbCheque = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelCheques.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(445, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(93, 41);
            this.btnSalir.TabIndex = 60;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAddItemPago
            // 
            this.btnAddItemPago.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItemPago.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItemPago.Image")));
            this.btnAddItemPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItemPago.Location = new System.Drawing.Point(445, 46);
            this.btnAddItemPago.Name = "btnAddItemPago";
            this.btnAddItemPago.Size = new System.Drawing.Size(93, 41);
            this.btnAddItemPago.TabIndex = 61;
            this.btnAddItemPago.Text = "AGREGAR";
            this.btnAddItemPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItemPago.UseVisualStyleBackColor = true;
            this.btnAddItemPago.Click += new System.EventHandler(this.btnAddItemPago_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 14);
            this.label10.TabIndex = 125;
            this.label10.Text = "Orden Pago#";
            // 
            // txtNumeroOP
            // 
            this.txtNumeroOP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOP.Location = new System.Drawing.Point(90, 3);
            this.txtNumeroOP.Name = "txtNumeroOP";
            this.txtNumeroOP.ReadOnly = true;
            this.txtNumeroOP.Size = new System.Drawing.Size(87, 22);
            this.txtNumeroOP.TabIndex = 124;
            // 
            // cmbCuenta
            // 
            this.cmbCuenta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCuenta.FormattingEnabled = true;
            this.cmbCuenta.Location = new System.Drawing.Point(66, 4);
            this.cmbCuenta.Name = "cmbCuenta";
            this.cmbCuenta.Size = new System.Drawing.Size(219, 22);
            this.cmbCuenta.TabIndex = 123;
            this.cmbCuenta.SelectedIndexChanged += new System.EventHandler(this.cmbCuenta_SelectedIndexChanged);
            this.cmbCuenta.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCuenta_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 14);
            this.label3.TabIndex = 122;
            this.label3.Text = "Cuenta";
            // 
            // txtLX
            // 
            this.txtLX.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLX.Location = new System.Drawing.Point(394, 3);
            this.txtLX.Name = "txtLX";
            this.txtLX.ReadOnly = true;
            this.txtLX.Size = new System.Drawing.Size(26, 22);
            this.txtLX.TabIndex = 126;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 349);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 127;
            this.label1.Text = "IMPORTE A PAGAR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 130;
            this.label2.Text = "Moneda";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.Location = new System.Drawing.Point(66, 27);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(46, 22);
            this.txtMoneda.TabIndex = 129;
            // 
            // txtTipoCuenta
            // 
            this.txtTipoCuenta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCuenta.Location = new System.Drawing.Point(364, 4);
            this.txtTipoCuenta.Name = "txtTipoCuenta";
            this.txtTipoCuenta.ReadOnly = true;
            this.txtTipoCuenta.Size = new System.Drawing.Size(56, 22);
            this.txtTipoCuenta.TabIndex = 132;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtProveedor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtNumeroOP);
            this.panel1.Controls.Add(this.txtLX);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(7, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 52);
            this.panel1.TabIndex = 133;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(341, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 14);
            this.label5.TabIndex = 129;
            this.label5.Text = "Tipo OP";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.Location = new System.Drawing.Point(90, 26);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(330, 22);
            this.txtProveedor.TabIndex = 128;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 127;
            this.label4.Text = "Proveedor";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cmbCuenta);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtTipoCuenta);
            this.panel2.Controls.Add(this.txtMoneda);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(13, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 56);
            this.panel2.TabIndex = 134;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(307, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 14);
            this.label6.TabIndex = 133;
            this.label6.Text = "Acc Type";
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkBlue;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.SeaGreen;
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 376);
            this.LineaIzq.TabIndex = 190;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DarkBlue;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.SeaGreen;
            this.lineaArriba.Location = new System.Drawing.Point(2, 2);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(543, 3);
            this.lineaArriba.TabIndex = 189;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Maroon;
            this.label29.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label29.Location = new System.Drawing.Point(13, 65);
            this.label29.Margin = new System.Windows.Forms.Padding(0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(426, 17);
            this.label29.TabIndex = 191;
            this.label29.Text = "Seleccion de Cuenta";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelCheques
            // 
            this.panelCheques.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelCheques.Controls.Add(this.cFechaAcreditacion);
            this.panelCheques.Controls.Add(this.label11);
            this.panelCheques.Controls.Add(this.txtNumeroCheque);
            this.panelCheques.Controls.Add(this.label9);
            this.panelCheques.Controls.Add(this.txtBancoDescripcion);
            this.panelCheques.Controls.Add(this.txtNumBanco);
            this.panelCheques.Controls.Add(this.label7);
            this.panelCheques.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCheques.Location = new System.Drawing.Point(13, 258);
            this.panelCheques.Name = "panelCheques";
            this.panelCheques.Size = new System.Drawing.Size(426, 83);
            this.panelCheques.TabIndex = 136;
            // 
            // cFechaAcreditacion
            // 
            this.cFechaAcreditacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cFechaAcreditacion.BackColor = System.Drawing.SystemColors.Control;
            this.cFechaAcreditacion.CheckPeriodoFIAuto = false;
            this.cFechaAcreditacion.ColorFondoFecha = System.Drawing.Color.Empty;
            this.cFechaAcreditacion.ColorForeFecha = System.Drawing.Color.Empty;
            this.cFechaAcreditacion.FechaMaxima = null;
            this.cFechaAcreditacion.FechaMinima = null;
            this.cFechaAcreditacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cFechaAcreditacion.Location = new System.Drawing.Point(131, 50);
            this.cFechaAcreditacion.Margin = new System.Windows.Forms.Padding(0);
            this.cFechaAcreditacion.Name = "cFechaAcreditacion";
            this.cFechaAcreditacion.ObtieneTCAuto = false;
            this.cFechaAcreditacion.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Green;
            this.cFechaAcreditacion.Size = new System.Drawing.Size(97, 23);
            this.cFechaAcreditacion.TabIndex = 193;
            this.cFechaAcreditacion.ValidarRangoFecha = false;
            this.cFechaAcreditacion.Value = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 14);
            this.label11.TabIndex = 140;
            this.label11.Text = "Fecha Acreditacion";
            // 
            // txtNumeroCheque
            // 
            this.txtNumeroCheque.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroCheque.Location = new System.Drawing.Point(66, 29);
            this.txtNumeroCheque.MaxLength = 8;
            this.txtNumeroCheque.Name = "txtNumeroCheque";
            this.txtNumeroCheque.Size = new System.Drawing.Size(64, 22);
            this.txtNumeroCheque.TabIndex = 137;
            this.txtNumeroCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 14);
            this.label9.TabIndex = 138;
            this.label9.Text = "Numero";
            // 
            // txtBancoDescripcion
            // 
            this.txtBancoDescripcion.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBancoDescripcion.Location = new System.Drawing.Point(94, 6);
            this.txtBancoDescripcion.Name = "txtBancoDescripcion";
            this.txtBancoDescripcion.ReadOnly = true;
            this.txtBancoDescripcion.Size = new System.Drawing.Size(253, 22);
            this.txtBancoDescripcion.TabIndex = 136;
            // 
            // txtNumBanco
            // 
            this.txtNumBanco.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumBanco.Location = new System.Drawing.Point(66, 6);
            this.txtNumBanco.Name = "txtNumBanco";
            this.txtNumBanco.ReadOnly = true;
            this.txtNumBanco.Size = new System.Drawing.Size(27, 22);
            this.txtNumBanco.TabIndex = 134;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 14);
            this.label7.TabIndex = 135;
            this.label7.Text = "Banco";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Maroon;
            this.label8.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(13, 238);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(426, 17);
            this.label8.TabIndex = 192;
            this.label8.Text = "Datos del Cheque";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkBlue;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SeaGreen;
            this.label12.Location = new System.Drawing.Point(542, 2);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(3, 376);
            this.label12.TabIndex = 193;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkBlue;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.SeaGreen;
            this.label13.Location = new System.Drawing.Point(2, 377);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(543, 3);
            this.label13.TabIndex = 194;
            // 
            // txtImporteOrigen
            // 
            this.txtImporteOrigen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtImporteOrigen.BackColor = System.Drawing.Color.White;
            this.txtImporteOrigen.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteOrigen.Location = new System.Drawing.Point(144, 345);
            this.txtImporteOrigen.Margin = new System.Windows.Forms.Padding(0);
            this.txtImporteOrigen.Name = "txtImporteOrigen";
            this.txtImporteOrigen.SetAlineacion = TSControls.CtlTextBox.Alineacion.Derecha;
            this.txtImporteOrigen.SetDecimales = 2;
            this.txtImporteOrigen.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.txtImporteOrigen.Size = new System.Drawing.Size(108, 22);
            this.txtImporteOrigen.TabIndex = 196;
            this.txtImporteOrigen.ValorMaximo = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtImporteOrigen.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtImporteOrigen.XReadOnly = false;
            // 
            // rbTransferencia
            // 
            this.rbTransferencia.AutoSize = true;
            this.rbTransferencia.Location = new System.Drawing.Point(13, 12);
            this.rbTransferencia.Name = "rbTransferencia";
            this.rbTransferencia.Size = new System.Drawing.Size(177, 18);
            this.rbTransferencia.TabIndex = 197;
            this.rbTransferencia.TabStop = true;
            this.rbTransferencia.Text = "Transferencia desde Cuenta";
            this.rbTransferencia.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.rbEcheque);
            this.panel3.Controls.Add(this.rbCheque);
            this.panel3.Controls.Add(this.rbTransferencia);
            this.panel3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(13, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 90);
            this.panel3.TabIndex = 135;
            // 
            // rbEcheque
            // 
            this.rbEcheque.AutoSize = true;
            this.rbEcheque.Location = new System.Drawing.Point(13, 60);
            this.rbEcheque.Name = "rbEcheque";
            this.rbEcheque.Size = new System.Drawing.Size(120, 18);
            this.rbEcheque.TabIndex = 199;
            this.rbEcheque.TabStop = true;
            this.rbEcheque.Text = "Emision ECHEQUE";
            this.rbEcheque.UseVisualStyleBackColor = true;
            this.rbEcheque.CheckedChanged += new System.EventHandler(this.rbEcheque_CheckedChanged);
            // 
            // rbCheque
            // 
            this.rbCheque.AutoSize = true;
            this.rbCheque.Location = new System.Drawing.Point(13, 36);
            this.rbCheque.Name = "rbCheque";
            this.rbCheque.Size = new System.Drawing.Size(148, 18);
            this.rbCheque.TabIndex = 198;
            this.rbCheque.TabStop = true;
            this.rbCheque.Text = "Emision Cheque Fisico";
            this.rbCheque.UseVisualStyleBackColor = true;
            this.rbCheque.CheckedChanged += new System.EventHandler(this.rbEcheque_CheckedChanged);
            // 
            // FrmFI32OpAddItemPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(549, 384);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtImporteOrigen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAddItemPago);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panelCheques);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFI32OpAddItemPago";
            this.Text = "FI32 - Agregar CostItems de Pago a OP";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmOrdenPagoAddItemsPago_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelCheques.ResumeLayout(false);
            this.panelCheques.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAddItemPago;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumeroOP;
        private System.Windows.Forms.ComboBox cmbCuenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.TextBox txtTipoCuenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panelCheques;
        private System.Windows.Forms.TextBox txtNumeroCheque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBancoDescripcion;
        private System.Windows.Forms.TextBox txtNumBanco;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private TSControls.CtlFechaTs cFechaAcreditacion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private TSControls.CtlTextBox txtImporteOrigen;
        private System.Windows.Forms.RadioButton rbTransferencia;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbEcheque;
        private System.Windows.Forms.RadioButton rbCheque;
    }
}