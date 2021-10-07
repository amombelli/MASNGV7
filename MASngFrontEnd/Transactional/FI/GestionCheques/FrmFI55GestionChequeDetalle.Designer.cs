namespace MASngFE.Transactional.FI.GestionCheques
{
    partial class FrmFI55GestionChequeDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI55GestionChequeDetalle));
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnSetEntregado = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMotivoRechazo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFechaRechazo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFechaAcreditacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroCheque = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDiasBicicleta = new System.Windows.Forms.TextBox();
            this.txtFechaRecibido = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtClienteRazonSocial = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctlFechaEntrega = new TSControls.CtlFechaTs();
            this.txtDiasDemoraEntrega = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtImporteSaldoNd = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbEntregadoPor = new System.Windows.Forms.ComboBox();
            this.BsPersonal = new System.Windows.Forms.BindingSource(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.ctlEntregado = new TSControls.CtlCheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtImpoteNd = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDiasInactivos = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNumeroDoc = new System.Windows.Forms.TextBox();
            this.txtFechaNd = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTdoc = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnUnsetEntrega = new System.Windows.Forms.Button();
            this.btnFixID400 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(579, 27);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 39);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnSetEntregado
            // 
            this.btnSetEntregado.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetEntregado.Image = ((System.Drawing.Image)(resources.GetObject("btnSetEntregado.Image")));
            this.btnSetEntregado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetEntregado.Location = new System.Drawing.Point(434, 81);
            this.btnSetEntregado.Name = "btnSetEntregado";
            this.btnSetEntregado.Size = new System.Drawing.Size(100, 39);
            this.btnSetEntregado.TabIndex = 13;
            this.btnSetEntregado.Text = "Entrega\r\nCheque";
            this.btnSetEntregado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetEntregado.UseVisualStyleBackColor = true;
            this.btnSetEntregado.Click += new System.EventHandler(this.btnSetEntregado_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.txtMotivoRechazo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtFechaRechazo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtFechaAcreditacion);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtImporte);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNumeroCheque);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtBanco);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 100);
            this.panel1.TabIndex = 14;
            // 
            // txtMotivoRechazo
            // 
            this.txtMotivoRechazo.Location = new System.Drawing.Point(123, 71);
            this.txtMotivoRechazo.Name = "txtMotivoRechazo";
            this.txtMotivoRechazo.ReadOnly = true;
            this.txtMotivoRechazo.Size = new System.Drawing.Size(411, 21);
            this.txtMotivoRechazo.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Motivo Rechazo";
            // 
            // txtFechaRechazo
            // 
            this.txtFechaRechazo.Location = new System.Drawing.Point(408, 49);
            this.txtFechaRechazo.Name = "txtFechaRechazo";
            this.txtFechaRechazo.ReadOnly = true;
            this.txtFechaRechazo.Size = new System.Drawing.Size(126, 21);
            this.txtFechaRechazo.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(306, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Fecha Rechazo";
            // 
            // txtFechaAcreditacion
            // 
            this.txtFechaAcreditacion.Location = new System.Drawing.Point(123, 49);
            this.txtFechaAcreditacion.Name = "txtFechaAcreditacion";
            this.txtFechaAcreditacion.ReadOnly = true;
            this.txtFechaAcreditacion.Size = new System.Drawing.Size(118, 21);
            this.txtFechaAcreditacion.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Fecha Acreditacion";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(123, 27);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(118, 21);
            this.txtImporte.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Importe Cheque";
            // 
            // txtNumeroCheque
            // 
            this.txtNumeroCheque.Location = new System.Drawing.Point(486, 5);
            this.txtNumeroCheque.Name = "txtNumeroCheque";
            this.txtNumeroCheque.ReadOnly = true;
            this.txtNumeroCheque.Size = new System.Drawing.Size(48, 21);
            this.txtNumeroCheque.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Numero Cheque";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(123, 5);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.ReadOnly = true;
            this.txtBanco.Size = new System.Drawing.Size(161, 21);
            this.txtBanco.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Banco";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Datos del Cheque Rechazado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 14);
            this.label9.TabIndex = 17;
            this.label9.Text = "Datos del Cliente/Entrega";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtDiasBicicleta);
            this.panel2.Controls.Add(this.txtFechaRecibido);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtClienteRazonSocial);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 56);
            this.panel2.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(319, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 15);
            this.label14.TabIndex = 15;
            this.label14.Text = "Dias (Entregado - Rechazo)";
            // 
            // txtDiasBicicleta
            // 
            this.txtDiasBicicleta.Location = new System.Drawing.Point(481, 27);
            this.txtDiasBicicleta.Name = "txtDiasBicicleta";
            this.txtDiasBicicleta.ReadOnly = true;
            this.txtDiasBicicleta.Size = new System.Drawing.Size(51, 21);
            this.txtDiasBicicleta.TabIndex = 14;
            // 
            // txtFechaRecibido
            // 
            this.txtFechaRecibido.Location = new System.Drawing.Point(138, 27);
            this.txtFechaRecibido.Name = "txtFechaRecibido";
            this.txtFechaRecibido.ReadOnly = true;
            this.txtFechaRecibido.Size = new System.Drawing.Size(103, 21);
            this.txtFechaRecibido.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "Fecha Recibido";
            // 
            // txtClienteRazonSocial
            // 
            this.txtClienteRazonSocial.Location = new System.Drawing.Point(138, 5);
            this.txtClienteRazonSocial.Name = "txtClienteRazonSocial";
            this.txtClienteRazonSocial.ReadOnly = true;
            this.txtClienteRazonSocial.Size = new System.Drawing.Size(394, 21);
            this.txtClienteRazonSocial.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Cliente (Razon Social)";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(551, 1);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(128, 20);
            this.txtStatus.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(442, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "Estado Cheque";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(5, 220);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(194, 14);
            this.label17.TabIndex = 19;
            this.label17.Text = "Datos de Nota de Debito a Cliente";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.ctlFechaEntrega);
            this.panel3.Controls.Add(this.txtDiasDemoraEntrega);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.txtImporteSaldoNd);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.cmbEntregadoPor);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.ctlEntregado);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.btnSetEntregado);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.txtImpoteNd);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.txtDiasInactivos);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.txtNumeroDoc);
            this.panel3.Controls.Add(this.txtFechaNd);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.txtTdoc);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 237);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(543, 155);
            this.panel3.TabIndex = 18;
            // 
            // ctlFechaEntrega
            // 
            this.ctlFechaEntrega.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlFechaEntrega.CheckPeriodoFIAuto = false;
            this.ctlFechaEntrega.ColorFondoFecha = System.Drawing.Color.Empty;
            this.ctlFechaEntrega.ColorForeFecha = System.Drawing.Color.Empty;
            this.ctlFechaEntrega.FechaMaxima = null;
            this.ctlFechaEntrega.FechaMinima = null;
            this.ctlFechaEntrega.Location = new System.Drawing.Point(138, 102);
            this.ctlFechaEntrega.Name = "ctlFechaEntrega";
            this.ctlFechaEntrega.ObtieneTCAuto = false;
            this.ctlFechaEntrega.SetLights = TSControls.CtlFechaTs.ColoreSemaforo.Green;
            this.ctlFechaEntrega.Size = new System.Drawing.Size(146, 24);
            this.ctlFechaEntrega.TabIndex = 31;
            this.ctlFechaEntrega.ValidarRangoFecha = false;
            this.ctlFechaEntrega.Value = null;
            // 
            // txtDiasDemoraEntrega
            // 
            this.txtDiasDemoraEntrega.Location = new System.Drawing.Point(493, 126);
            this.txtDiasDemoraEntrega.Name = "txtDiasDemoraEntrega";
            this.txtDiasDemoraEntrega.ReadOnly = true;
            this.txtDiasDemoraEntrega.Size = new System.Drawing.Size(41, 21);
            this.txtDiasDemoraEntrega.TabIndex = 30;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(349, 129);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(126, 15);
            this.label27.TabIndex = 29;
            this.label27.Text = "Dias Demora Entrega";
            // 
            // txtImporteSaldoNd
            // 
            this.txtImporteSaldoNd.Location = new System.Drawing.Point(415, 49);
            this.txtImporteSaldoNd.Name = "txtImporteSaldoNd";
            this.txtImporteSaldoNd.ReadOnly = true;
            this.txtImporteSaldoNd.Size = new System.Drawing.Size(117, 21);
            this.txtImporteSaldoNd.TabIndex = 28;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(300, 52);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(107, 15);
            this.label26.TabIndex = 27;
            this.label26.Text = "Saldo Nota Debito";
            // 
            // cmbEntregadoPor
            // 
            this.cmbEntregadoPor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEntregadoPor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEntregadoPor.DataSource = this.BsPersonal;
            this.cmbEntregadoPor.DisplayMember = "SHORTNAME";
            this.cmbEntregadoPor.FormattingEnabled = true;
            this.cmbEntregadoPor.Location = new System.Drawing.Point(138, 126);
            this.cmbEntregadoPor.Name = "cmbEntregadoPor";
            this.cmbEntregadoPor.Size = new System.Drawing.Size(182, 23);
            this.cmbEntregadoPor.TabIndex = 26;
            this.cmbEntregadoPor.ValueMember = "SHORTNAME";
            // 
            // BsPersonal
            // 
            this.BsPersonal.DataSource = typeof(TecserEF.Entity.T0085_PERSONAL);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 129);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(86, 15);
            this.label25.TabIndex = 24;
            this.label25.Text = "Entregada Por";
            // 
            // ctlEntregado
            // 
            this.ctlEntregado.ColorChecked = System.Drawing.Color.LimeGreen;
            this.ctlEntregado.ColorUnChecked = System.Drawing.Color.IndianRed;
            this.ctlEntregado.LabelText = "Nota de Debito Entregada/Enviada a Cliente";
            this.ctlEntregado.Location = new System.Drawing.Point(9, 82);
            this.ctlEntregado.Name = "ctlEntregado";
            this.ctlEntregado.Size = new System.Drawing.Size(352, 16);
            this.ctlEntregado.TabIndex = 23;
            this.ctlEntregado.Value = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 107);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 15);
            this.label24.TabIndex = 21;
            this.label24.Text = "Fecha Entrega";
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Red;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(6, 73);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(528, 3);
            this.label23.TabIndex = 20;
            // 
            // txtImpoteNd
            // 
            this.txtImpoteNd.Location = new System.Drawing.Point(138, 49);
            this.txtImpoteNd.Name = "txtImpoteNd";
            this.txtImpoteNd.ReadOnly = true;
            this.txtImpoteNd.Size = new System.Drawing.Size(152, 21);
            this.txtImpoteNd.TabIndex = 20;
            this.txtImpoteNd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 52);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(117, 15);
            this.label22.TabIndex = 19;
            this.label22.Text = "Importe Nota Debito";
            // 
            // txtDiasInactivos
            // 
            this.txtDiasInactivos.Location = new System.Drawing.Point(415, 27);
            this.txtDiasInactivos.Name = "txtDiasInactivos";
            this.txtDiasInactivos.ReadOnly = true;
            this.txtDiasInactivos.Size = new System.Drawing.Size(41, 21);
            this.txtDiasInactivos.TabIndex = 18;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(300, 30);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 15);
            this.label21.TabIndex = 17;
            this.label21.Text = "Dias Inactivos";
            // 
            // txtNumeroDoc
            // 
            this.txtNumeroDoc.Location = new System.Drawing.Point(176, 5);
            this.txtNumeroDoc.Name = "txtNumeroDoc";
            this.txtNumeroDoc.ReadOnly = true;
            this.txtNumeroDoc.Size = new System.Drawing.Size(114, 21);
            this.txtNumeroDoc.TabIndex = 16;
            // 
            // txtFechaNd
            // 
            this.txtFechaNd.Location = new System.Drawing.Point(138, 27);
            this.txtFechaNd.Name = "txtFechaNd";
            this.txtFechaNd.ReadOnly = true;
            this.txtFechaNd.Size = new System.Drawing.Size(152, 21);
            this.txtFechaNd.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 15);
            this.label19.TabIndex = 6;
            this.label19.Text = "Fecha Nota Debito";
            // 
            // txtTdoc
            // 
            this.txtTdoc.Location = new System.Drawing.Point(138, 5);
            this.txtTdoc.Name = "txtTdoc";
            this.txtTdoc.ReadOnly = true;
            this.txtTdoc.Size = new System.Drawing.Size(37, 21);
            this.txtTdoc.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 15);
            this.label20.TabIndex = 2;
            this.label20.Text = "Numero ND";
            // 
            // btnUnsetEntrega
            // 
            this.btnUnsetEntrega.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnsetEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnUnsetEntrega.Image")));
            this.btnUnsetEntrega.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnsetEntrega.Location = new System.Drawing.Point(579, 318);
            this.btnUnsetEntrega.Name = "btnUnsetEntrega";
            this.btnUnsetEntrega.Size = new System.Drawing.Size(100, 39);
            this.btnUnsetEntrega.TabIndex = 31;
            this.btnUnsetEntrega.Text = "UNSET\r\nEntrega";
            this.btnUnsetEntrega.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUnsetEntrega.UseVisualStyleBackColor = true;
            this.btnUnsetEntrega.Click += new System.EventHandler(this.btnUnsetEntrega_Click);
            // 
            // btnFixID400
            // 
            this.btnFixID400.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFixID400.Image = ((System.Drawing.Image)(resources.GetObject("btnFixID400.Image")));
            this.btnFixID400.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFixID400.Location = new System.Drawing.Point(579, 243);
            this.btnFixID400.Name = "btnFixID400";
            this.btnFixID400.Size = new System.Drawing.Size(100, 39);
            this.btnFixID400.TabIndex = 32;
            this.btnFixID400.Text = "FIX\r\nIDT400";
            this.btnFixID400.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFixID400.UseVisualStyleBackColor = true;
            this.btnFixID400.Click += new System.EventHandler(this.btnFixID400_Click);
            // 
            // FrmFI55GestionChequeDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(694, 395);
            this.Controls.Add(this.btnFixID400);
            this.Controls.Add(this.btnUnsetEntrega);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Name = "FrmFI55GestionChequeDetalle";
            this.Text = "FI55 - Detalle de Cheque Rechazado";
            this.Load += new System.EventHandler(this.FrmFI55GestionChequeDetalle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsPersonal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnSetEntregado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMotivoRechazo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFechaRechazo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFechaAcreditacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumeroCheque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDiasBicicleta;
        private System.Windows.Forms.TextBox txtFechaRecibido;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtClienteRazonSocial;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtFechaNd;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTdoc;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtNumeroDoc;
        private System.Windows.Forms.TextBox txtDiasInactivos;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDiasDemoraEntrega;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtImporteSaldoNd;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbEntregadoPor;
        private System.Windows.Forms.Label label25;
        private TSControls.CtlCheckBox ctlEntregado;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtImpoteNd;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnUnsetEntrega;
        private System.Windows.Forms.BindingSource BsPersonal;
        private TSControls.CtlFechaTs ctlFechaEntrega;
        private System.Windows.Forms.Button btnFixID400;
    }
}