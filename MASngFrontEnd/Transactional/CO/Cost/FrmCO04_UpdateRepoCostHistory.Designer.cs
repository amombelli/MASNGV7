namespace MASngFE.Transactional.CO.Cost
{
    partial class FrmCO04_UpdateRepoCostHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCO04_UpdateRepoCostHistory));
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.btnUpdateUC = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProveedorRs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKgCompra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechaCompra = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.xKgCompra = new TSControls.CtlTextBox();
            this.ctlAlarmClock1 = new TSControls.CtlAlarmClock();
            this.xPrecioU = new TSControls.CtlTextBox();
            this.xMoneda = new System.Windows.Forms.TextBox();
            this.txtTc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrecioA = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.xPrecioA = new TSControls.CtlTextBox();
            this.ckManualUpdate = new System.Windows.Forms.CheckBox();
            this.txtFechaUpdate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUserUpdate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnRegenerar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkOrchid;
            this.LineaIzq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LineaIzq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.Location = new System.Drawing.Point(2, 2);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 313);
            this.LineaIzq.TabIndex = 177;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DarkOrchid;
            this.lineaArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineaArriba.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.DarkBlue;
            this.lineaArriba.Location = new System.Drawing.Point(2, 2);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(673, 3);
            this.lineaArriba.TabIndex = 176;
            // 
            // btnUpdateUC
            // 
            this.btnUpdateUC.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUC.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateUC.Image")));
            this.btnUpdateUC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateUC.Location = new System.Drawing.Point(553, 74);
            this.btnUpdateUC.Name = "btnUpdateUC";
            this.btnUpdateUC.Size = new System.Drawing.Size(112, 43);
            this.btnUpdateUC.TabIndex = 179;
            this.btnUpdateUC.Text = "Actualizar\r\nHistorico";
            this.btnUpdateUC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateUC.UseVisualStyleBackColor = true;
            this.btnUpdateUC.Click += new System.EventHandler(this.btnUpdateUC_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::MASngFE.Properties.Resources.if_gnome_session_logout_30682;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(553, 31);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 43);
            this.btnExit.TabIndex = 178;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(104, 32);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(139, 22);
            this.txtMaterial.TabIndex = 180;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 14);
            this.label7.TabIndex = 181;
            this.label7.Text = "Material";
            // 
            // txtProveedorRs
            // 
            this.txtProveedorRs.Location = new System.Drawing.Point(104, 56);
            this.txtProveedorRs.Name = "txtProveedorRs";
            this.txtProveedorRs.ReadOnly = true;
            this.txtProveedorRs.Size = new System.Drawing.Size(364, 22);
            this.txtProveedorRs.TabIndex = 182;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 183;
            this.label1.Text = "Proveedor";
            // 
            // txtKgCompra
            // 
            this.txtKgCompra.Location = new System.Drawing.Point(104, 127);
            this.txtKgCompra.Name = "txtKgCompra";
            this.txtKgCompra.ReadOnly = true;
            this.txtKgCompra.Size = new System.Drawing.Size(88, 22);
            this.txtKgCompra.TabIndex = 186;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 187;
            this.label2.Text = "KG Compra";
            // 
            // txtFechaCompra
            // 
            this.txtFechaCompra.Location = new System.Drawing.Point(104, 80);
            this.txtFechaCompra.Name = "txtFechaCompra";
            this.txtFechaCompra.ReadOnly = true;
            this.txtFechaCompra.Size = new System.Drawing.Size(130, 22);
            this.txtFechaCompra.TabIndex = 184;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 185;
            this.label3.Text = "Fecha Compra";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Violet;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(655, 19);
            this.label6.TabIndex = 188;
            this.label6.Text = "Datos Contabilizacion Original";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMoneda
            // 
            this.txtMoneda.Location = new System.Drawing.Point(104, 151);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(44, 22);
            this.txtMoneda.TabIndex = 189;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 190;
            this.label4.Text = "Moneda";
            // 
            // txtPrecioU
            // 
            this.txtPrecioU.Location = new System.Drawing.Point(104, 175);
            this.txtPrecioU.Name = "txtPrecioU";
            this.txtPrecioU.ReadOnly = true;
            this.txtPrecioU.Size = new System.Drawing.Size(88, 22);
            this.txtPrecioU.TabIndex = 191;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 192;
            this.label5.Text = "Precio Unit U";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(196, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 19);
            this.label8.TabIndex = 193;
            this.label8.Text = "Datos Historicos";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Violet;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 19);
            this.label9.TabIndex = 194;
            this.label9.Text = "Datos Contabilizacion Original";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xKgCompra
            // 
            this.xKgCompra.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.xKgCompra.BackColor = System.Drawing.Color.White;
            this.xKgCompra.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xKgCompra.Location = new System.Drawing.Point(196, 127);
            this.xKgCompra.Margin = new System.Windows.Forms.Padding(0);
            this.xKgCompra.Name = "xKgCompra";
            this.xKgCompra.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.xKgCompra.SetDecimales = 2;
            this.xKgCompra.SetType = TSControls.CtlTextBox.TextBoxType.Decimal;
            this.xKgCompra.Size = new System.Drawing.Size(88, 22);
            this.xKgCompra.TabIndex = 195;
             this.xKgCompra.ValorMaximo = new decimal(new int[] {
            900000,
            0,
            0,
            0});
            this.xKgCompra.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.xKgCompra.XReadOnly = false;
            // 
            // ctlAlarmClock1
            // 
            this.ctlAlarmClock1.AlarmSet = false;
            this.ctlAlarmClock1.AlarmTime = new System.DateTime(((long)(0)));
            this.ctlAlarmClock1.ClockBackColor = System.Drawing.Color.Empty;
            this.ctlAlarmClock1.ClockForeColor = System.Drawing.Color.Empty;
            this.ctlAlarmClock1.Location = new System.Drawing.Point(258, 335);
            this.ctlAlarmClock1.Name = "ctlAlarmClock1";
            this.ctlAlarmClock1.Size = new System.Drawing.Size(8, 16);
            this.ctlAlarmClock1.TabIndex = 196;
            // 
            // xPrecioU
            // 
            this.xPrecioU.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.xPrecioU.BackColor = System.Drawing.Color.White;
            this.xPrecioU.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPrecioU.Location = new System.Drawing.Point(196, 175);
            this.xPrecioU.Margin = new System.Windows.Forms.Padding(0);
            this.xPrecioU.Name = "xPrecioU";
            this.xPrecioU.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.xPrecioU.SetDecimales = 3;
            this.xPrecioU.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.xPrecioU.Size = new System.Drawing.Size(88, 22);
            this.xPrecioU.TabIndex = 198;
             this.xPrecioU.ValorMaximo = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.xPrecioU.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.xPrecioU.XReadOnly = false;
            this.xPrecioU.Validated += new System.EventHandler(this.xPrecioU_Validated);
            // 
            // xMoneda
            // 
            this.xMoneda.Location = new System.Drawing.Point(196, 151);
            this.xMoneda.Name = "xMoneda";
            this.xMoneda.ReadOnly = true;
            this.xMoneda.Size = new System.Drawing.Size(47, 22);
            this.xMoneda.TabIndex = 199;
            // 
            // txtTc
            // 
            this.txtTc.Location = new System.Drawing.Point(270, 80);
            this.txtTc.Name = "txtTc";
            this.txtTc.ReadOnly = true;
            this.txtTc.Size = new System.Drawing.Size(51, 22);
            this.txtTc.TabIndex = 201;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(241, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 14);
            this.label10.TabIndex = 200;
            this.label10.Text = "T/C";
            // 
            // txtPrecioA
            // 
            this.txtPrecioA.Location = new System.Drawing.Point(104, 199);
            this.txtPrecioA.Name = "txtPrecioA";
            this.txtPrecioA.ReadOnly = true;
            this.txtPrecioA.Size = new System.Drawing.Size(88, 22);
            this.txtPrecioA.TabIndex = 202;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 14);
            this.label11.TabIndex = 203;
            this.label11.Text = "Precio Unit A";
            // 
            // xPrecioA
            // 
            this.xPrecioA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.xPrecioA.BackColor = System.Drawing.Color.White;
            this.xPrecioA.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPrecioA.Location = new System.Drawing.Point(196, 199);
            this.xPrecioA.Margin = new System.Windows.Forms.Padding(0);
            this.xPrecioA.Name = "xPrecioA";
            this.xPrecioA.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.xPrecioA.SetDecimales = 3;
            this.xPrecioA.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.xPrecioA.Size = new System.Drawing.Size(88, 22);
            this.xPrecioA.TabIndex = 204;
            this.xPrecioA.ValorMaximo = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.xPrecioA.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.xPrecioA.XReadOnly = false;
            this.xPrecioA.Validated += new System.EventHandler(this.xPrecioA_Validated);
            // 
            // ckManualUpdate
            // 
            this.ckManualUpdate.AutoSize = true;
            this.ckManualUpdate.Location = new System.Drawing.Point(337, 106);
            this.ckManualUpdate.Name = "ckManualUpdate";
            this.ckManualUpdate.Size = new System.Drawing.Size(144, 18);
            this.ckManualUpdate.TabIndex = 205;
            this.ckManualUpdate.Text = "Actualizacion Manual";
            this.ckManualUpdate.UseVisualStyleBackColor = true;
            // 
            // txtFechaUpdate
            // 
            this.txtFechaUpdate.Location = new System.Drawing.Point(108, 256);
            this.txtFechaUpdate.Name = "txtFechaUpdate";
            this.txtFechaUpdate.ReadOnly = true;
            this.txtFechaUpdate.Size = new System.Drawing.Size(176, 22);
            this.txtFechaUpdate.TabIndex = 206;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 260);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 14);
            this.label12.TabIndex = 207;
            this.label12.Text = "Fecha Update";
            // 
            // txtUserUpdate
            // 
            this.txtUserUpdate.Location = new System.Drawing.Point(108, 280);
            this.txtUserUpdate.Name = "txtUserUpdate";
            this.txtUserUpdate.ReadOnly = true;
            this.txtUserUpdate.Size = new System.Drawing.Size(176, 22);
            this.txtUserUpdate.TabIndex = 208;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 14);
            this.label13.TabIndex = 209;
            this.label13.Text = "User Update";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.DarkOrchid;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkBlue;
            this.label14.Location = new System.Drawing.Point(2, 312);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(673, 3);
            this.label14.TabIndex = 210;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.DarkOrchid;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(672, 2);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(3, 313);
            this.label15.TabIndex = 211;
            // 
            // btnRegenerar
            // 
            this.btnRegenerar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegenerar.Image")));
            this.btnRegenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegenerar.Location = new System.Drawing.Point(553, 117);
            this.btnRegenerar.Name = "btnRegenerar";
            this.btnRegenerar.Size = new System.Drawing.Size(112, 43);
            this.btnRegenerar.TabIndex = 212;
            this.btnRegenerar.Text = "Regenerar\r\nRegistro";
            this.btnRegenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegenerar.UseVisualStyleBackColor = true;
            this.btnRegenerar.Click += new System.EventHandler(this.btnRegenerar_Click);
            // 
            // FrmCO04_UpdateRepoCostHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(678, 318);
            this.Controls.Add(this.btnRegenerar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtUserUpdate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtFechaUpdate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ckManualUpdate);
            this.Controls.Add(this.xPrecioA);
            this.Controls.Add(this.txtPrecioA);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.xMoneda);
            this.Controls.Add(this.xPrecioU);
            this.Controls.Add(this.ctlAlarmClock1);
            this.Controls.Add(this.xKgCompra);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPrecioU);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMoneda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtKgCompra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFechaCompra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProveedorRs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnUpdateUC);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCO04_UpdateRepoCostHistory";
            this.Text = "CO04 - Modificacion de Costo de Reposicion Historico";
            this.Load += new System.EventHandler(this.FrmCO04_UpdateRepoCostHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Button btnUpdateUC;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProveedorRs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKgCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFechaCompra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecioU;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private TSControls.CtlTextBox xKgCompra;
        private TSControls.CtlAlarmClock ctlAlarmClock1;
        private TSControls.CtlTextBox xPrecioU;
        private System.Windows.Forms.TextBox xMoneda;
        private System.Windows.Forms.TextBox txtTc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrecioA;
        private System.Windows.Forms.Label label11;
        private TSControls.CtlTextBox xPrecioA;
        private System.Windows.Forms.CheckBox ckManualUpdate;
        private System.Windows.Forms.TextBox txtFechaUpdate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUserUpdate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnRegenerar;
    }
}