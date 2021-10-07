namespace MASngFE.FIX
{
    partial class FrmMergeCustomersData
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
            this.txtId6Caducar = new System.Windows.Forms.TextBox();
            this.cmbClienteCaducar = new System.Windows.Forms.ComboBox();
            this.t0006MCLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClienteMantener = new System.Windows.Forms.ComboBox();
            this.txtId6Mantener = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShiptosMantener = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShiptosCadudcar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSaldoL2Caducar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSaldoL1Caducar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSaldoL2Mantener = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSaldoL1Mantener = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSaldoSinImputarMantener = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSaldoSinImputarCaducar = new System.Windows.Forms.TextBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckT0201 = new System.Windows.Forms.CheckBox();
            this.ckT0207 = new System.Windows.Forms.CheckBox();
            this.ckT0202L1 = new System.Windows.Forms.CheckBox();
            this.ckT0208 = new System.Windows.Forms.CheckBox();
            this.ckT0202L2 = new System.Windows.Forms.CheckBox();
            this.ckCobranzas = new System.Windows.Forms.CheckBox();
            this.ckCheques = new System.Windows.Forms.CheckBox();
            this.ckRemitos = new System.Windows.Forms.CheckBox();
            this.ckOrdenVenta = new System.Windows.Forms.CheckBox();
            this.ckTabla601 = new System.Windows.Forms.CheckBox();
            this.ckTabla40 = new System.Windows.Forms.CheckBox();
            this.ckFacturas = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId6Caducar
            // 
            this.txtId6Caducar.Location = new System.Drawing.Point(129, 35);
            this.txtId6Caducar.Name = "txtId6Caducar";
            this.txtId6Caducar.Size = new System.Drawing.Size(52, 22);
            this.txtId6Caducar.TabIndex = 0;
            // 
            // cmbClienteCaducar
            // 
            this.cmbClienteCaducar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClienteCaducar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClienteCaducar.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbClienteCaducar.DisplayMember = "cli_fantasia";
            this.cmbClienteCaducar.FormattingEnabled = true;
            this.cmbClienteCaducar.Location = new System.Drawing.Point(187, 35);
            this.cmbClienteCaducar.Name = "cmbClienteCaducar";
            this.cmbClienteCaducar.Size = new System.Drawing.Size(284, 22);
            this.cmbClienteCaducar.TabIndex = 1;
            this.cmbClienteCaducar.ValueMember = "IDCLIENTE";
            this.cmbClienteCaducar.SelectedIndexChanged += new System.EventHandler(this.cmbClienteCaducar_SelectedIndexChanged);
            // 
            // t0006MCLIENTESBindingSource
            // 
            this.t0006MCLIENTESBindingSource.DataSource = typeof(TecserEF.Entity.T0006_MCLIENTES);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "CLIENTE CADUCAR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SpringGreen;
            this.label2.Location = new System.Drawing.Point(570, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "CLIENTE MANTENER";
            // 
            // cmbClienteMantener
            // 
            this.cmbClienteMantener.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClienteMantener.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClienteMantener.DataSource = this.t0006MCLIENTESBindingSource;
            this.cmbClienteMantener.DisplayMember = "cli_fantasia";
            this.cmbClienteMantener.FormattingEnabled = true;
            this.cmbClienteMantener.Location = new System.Drawing.Point(745, 35);
            this.cmbClienteMantener.Name = "cmbClienteMantener";
            this.cmbClienteMantener.Size = new System.Drawing.Size(284, 22);
            this.cmbClienteMantener.TabIndex = 4;
            this.cmbClienteMantener.ValueMember = "IDCLIENTE";
            this.cmbClienteMantener.SelectedIndexChanged += new System.EventHandler(this.cmbClienteMantener_SelectedIndexChanged);
            // 
            // txtId6Mantener
            // 
            this.txtId6Mantener.Location = new System.Drawing.Point(687, 35);
            this.txtId6Mantener.Name = "txtId6Mantener";
            this.txtId6Mantener.Size = new System.Drawing.Size(52, 22);
            this.txtId6Mantener.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "CANT SHIPTO";
            // 
            // txtShiptosMantener
            // 
            this.txtShiptosMantener.Location = new System.Drawing.Point(687, 82);
            this.txtShiptosMantener.Name = "txtShiptosMantener";
            this.txtShiptosMantener.Size = new System.Drawing.Size(52, 22);
            this.txtShiptosMantener.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "CANT SHIPTO";
            // 
            // txtShiptosCadudcar
            // 
            this.txtShiptosCadudcar.Location = new System.Drawing.Point(127, 87);
            this.txtShiptosCadudcar.Name = "txtShiptosCadudcar";
            this.txtShiptosCadudcar.Size = new System.Drawing.Size(52, 22);
            this.txtShiptosCadudcar.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(5, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1042, 10);
            this.label5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "SALDO L2";
            // 
            // txtSaldoL2Caducar
            // 
            this.txtSaldoL2Caducar.Location = new System.Drawing.Point(127, 136);
            this.txtSaldoL2Caducar.Name = "txtSaldoL2Caducar";
            this.txtSaldoL2Caducar.Size = new System.Drawing.Size(88, 22);
            this.txtSaldoL2Caducar.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "SALDO L1";
            // 
            // txtSaldoL1Caducar
            // 
            this.txtSaldoL1Caducar.Location = new System.Drawing.Point(127, 112);
            this.txtSaldoL1Caducar.Name = "txtSaldoL1Caducar";
            this.txtSaldoL1Caducar.Size = new System.Drawing.Size(88, 22);
            this.txtSaldoL1Caducar.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Crimson;
            this.label8.Location = new System.Drawing.Point(168, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = "CLIENTE CADUCAR";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label9.Location = new System.Drawing.Point(719, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "CLIENTE MANTENER";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(598, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 14);
            this.label10.TabIndex = 24;
            this.label10.Text = "SALDO L2";
            // 
            // txtSaldoL2Mantener
            // 
            this.txtSaldoL2Mantener.Location = new System.Drawing.Point(687, 131);
            this.txtSaldoL2Mantener.Name = "txtSaldoL2Mantener";
            this.txtSaldoL2Mantener.Size = new System.Drawing.Size(88, 22);
            this.txtSaldoL2Mantener.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(598, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 14);
            this.label11.TabIndex = 22;
            this.label11.Text = "SALDO L1";
            // 
            // txtSaldoL1Mantener
            // 
            this.txtSaldoL1Mantener.Location = new System.Drawing.Point(687, 107);
            this.txtSaldoL1Mantener.Name = "txtSaldoL1Mantener";
            this.txtSaldoL1Mantener.Size = new System.Drawing.Size(88, 22);
            this.txtSaldoL1Mantener.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(598, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 14);
            this.label12.TabIndex = 28;
            this.label12.Text = "SIN IMPUTAR";
            // 
            // txtSaldoSinImputarMantener
            // 
            this.txtSaldoSinImputarMantener.Location = new System.Drawing.Point(687, 155);
            this.txtSaldoSinImputarMantener.Name = "txtSaldoSinImputarMantener";
            this.txtSaldoSinImputarMantener.Size = new System.Drawing.Size(88, 22);
            this.txtSaldoSinImputarMantener.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 14);
            this.label13.TabIndex = 26;
            this.label13.Text = "SIN IMPUTAR";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSaldoSinImputarCaducar
            // 
            this.txtSaldoSinImputarCaducar.Location = new System.Drawing.Point(127, 160);
            this.txtSaldoSinImputarCaducar.Name = "txtSaldoSinImputarCaducar";
            this.txtSaldoSinImputarCaducar.Size = new System.Drawing.Size(88, 22);
            this.txtSaldoSinImputarCaducar.TabIndex = 25;
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(948, 260);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(99, 38);
            this.btnMerge.TabIndex = 29;
            this.btnMerge.Text = "MERGE";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(5, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 210);
            this.panel1.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(560, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 210);
            this.panel2.TabIndex = 31;
            // 
            // ckT0201
            // 
            this.ckT0201.AutoSize = true;
            this.ckT0201.Location = new System.Drawing.Point(29, 271);
            this.ckT0201.Name = "ckT0201";
            this.ckT0201.Size = new System.Drawing.Size(247, 18);
            this.ckT0201.TabIndex = 32;
            this.ckT0201.Text = "TABLA T0201 (CUENTA CORRIENTE DETALLE)";
            this.ckT0201.UseVisualStyleBackColor = true;
            // 
            // ckT0207
            // 
            this.ckT0207.AutoSize = true;
            this.ckT0207.Location = new System.Drawing.Point(29, 344);
            this.ckT0207.Name = "ckT0207";
            this.ckT0207.Size = new System.Drawing.Size(229, 18);
            this.ckT0207.TabIndex = 33;
            this.ckT0207.Text = "TABLA T0207 (DETALLE DE IMPUTACION)";
            this.ckT0207.UseVisualStyleBackColor = true;
            // 
            // ckT0202L1
            // 
            this.ckT0202L1.AutoSize = true;
            this.ckT0202L1.Location = new System.Drawing.Point(29, 295);
            this.ckT0202L1.Name = "ckT0202L1";
            this.ckT0202L1.Size = new System.Drawing.Size(266, 18);
            this.ckT0202L1.TabIndex = 34;
            this.ckT0202L1.Text = "TABLA T0202 (CUENTA CORRIENTE GENERAL) L1";
            this.ckT0202L1.UseVisualStyleBackColor = true;
            // 
            // ckT0208
            // 
            this.ckT0208.AutoSize = true;
            this.ckT0208.Location = new System.Drawing.Point(29, 368);
            this.ckT0208.Name = "ckT0208";
            this.ckT0208.Size = new System.Drawing.Size(294, 18);
            this.ckT0208.TabIndex = 35;
            this.ckT0208.Text = "TABLA T0208 (SALDOS PENDIENTES DE IMPUTACION)";
            this.ckT0208.UseVisualStyleBackColor = true;
            // 
            // ckT0202L2
            // 
            this.ckT0202L2.AutoSize = true;
            this.ckT0202L2.Location = new System.Drawing.Point(29, 319);
            this.ckT0202L2.Name = "ckT0202L2";
            this.ckT0202L2.Size = new System.Drawing.Size(266, 18);
            this.ckT0202L2.TabIndex = 36;
            this.ckT0202L2.Text = "TABLA T0202 (CUENTA CORRIENTE GENERAL) L2";
            this.ckT0202L2.UseVisualStyleBackColor = true;
            // 
            // ckCobranzas
            // 
            this.ckCobranzas.AutoSize = true;
            this.ckCobranzas.Location = new System.Drawing.Point(29, 392);
            this.ckCobranzas.Name = "ckCobranzas";
            this.ckCobranzas.Size = new System.Drawing.Size(139, 18);
            this.ckCobranzas.TabIndex = 37;
            this.ckCobranzas.Text = "TABLA DE COBRANZAS";
            this.ckCobranzas.UseVisualStyleBackColor = true;
            // 
            // ckCheques
            // 
            this.ckCheques.AutoSize = true;
            this.ckCheques.Location = new System.Drawing.Point(29, 416);
            this.ckCheques.Name = "ckCheques";
            this.ckCheques.Size = new System.Drawing.Size(74, 18);
            this.ckCheques.TabIndex = 38;
            this.ckCheques.Text = "CHEQUES";
            this.ckCheques.UseVisualStyleBackColor = true;
            // 
            // ckRemitos
            // 
            this.ckRemitos.AutoSize = true;
            this.ckRemitos.Location = new System.Drawing.Point(29, 440);
            this.ckRemitos.Name = "ckRemitos";
            this.ckRemitos.Size = new System.Drawing.Size(73, 18);
            this.ckRemitos.TabIndex = 39;
            this.ckRemitos.Text = "REMITOS";
            this.ckRemitos.UseVisualStyleBackColor = true;
            // 
            // ckOrdenVenta
            // 
            this.ckOrdenVenta.AutoSize = true;
            this.ckOrdenVenta.Location = new System.Drawing.Point(29, 466);
            this.ckOrdenVenta.Name = "ckOrdenVenta";
            this.ckOrdenVenta.Size = new System.Drawing.Size(116, 18);
            this.ckOrdenVenta.TabIndex = 40;
            this.ckOrdenVenta.Text = "ORDEN DE VENTA";
            this.ckOrdenVenta.UseVisualStyleBackColor = true;
            // 
            // ckTabla601
            // 
            this.ckTabla601.AutoSize = true;
            this.ckTabla601.Location = new System.Drawing.Point(452, 295);
            this.ckTabla601.Name = "ckTabla601";
            this.ckTabla601.Size = new System.Drawing.Size(167, 18);
            this.ckTabla601.TabIndex = 42;
            this.ckTabla601.Text = "TABLAS ASIENTOS (601.602)";
            this.ckTabla601.UseVisualStyleBackColor = true;
            // 
            // ckTabla40
            // 
            this.ckTabla40.AutoSize = true;
            this.ckTabla40.Location = new System.Drawing.Point(452, 271);
            this.ckTabla40.Name = "ckTabla40";
            this.ckTabla40.Size = new System.Drawing.Size(158, 18);
            this.ckTabla40.TabIndex = 41;
            this.ckTabla40.Text = "TABLA MOVIMIENTOS T40";
            this.ckTabla40.UseVisualStyleBackColor = true;
            // 
            // ckFacturas
            // 
            this.ckFacturas.AutoSize = true;
            this.ckFacturas.Location = new System.Drawing.Point(452, 319);
            this.ckFacturas.Name = "ckFacturas";
            this.ckFacturas.Size = new System.Drawing.Size(78, 18);
            this.ckFacturas.TabIndex = 43;
            this.ckFacturas.Text = "FACTURAS";
            this.ckFacturas.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(948, 304);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 38);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "SALIR";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmMergeCustomersData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 496);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ckFacturas);
            this.Controls.Add(this.ckTabla601);
            this.Controls.Add(this.ckTabla40);
            this.Controls.Add(this.ckOrdenVenta);
            this.Controls.Add(this.ckRemitos);
            this.Controls.Add(this.ckCheques);
            this.Controls.Add(this.ckCobranzas);
            this.Controls.Add(this.ckT0202L2);
            this.Controls.Add(this.ckT0208);
            this.Controls.Add(this.ckT0202L1);
            this.Controls.Add(this.ckT0207);
            this.Controls.Add(this.ckT0201);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSaldoSinImputarMantener);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSaldoSinImputarCaducar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSaldoL2Mantener);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSaldoL1Mantener);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSaldoL2Caducar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSaldoL1Caducar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtShiptosMantener);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtShiptosCadudcar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClienteMantener);
            this.Controls.Add(this.txtId6Mantener);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClienteCaducar);
            this.Controls.Add(this.txtId6Caducar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMergeCustomersData";
            this.Text = "MERGE CUENTAS CORRIENTES DE CLIENTES";
            this.Load += new System.EventHandler(this.FrmMergeCustomersData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t0006MCLIENTESBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId6Caducar;
        private System.Windows.Forms.ComboBox cmbClienteCaducar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClienteMantener;
        private System.Windows.Forms.TextBox txtId6Mantener;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShiptosMantener;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShiptosCadudcar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSaldoL2Caducar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSaldoL1Caducar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSaldoL2Mantener;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSaldoL1Mantener;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSaldoSinImputarMantener;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSaldoSinImputarCaducar;
        private System.Windows.Forms.BindingSource t0006MCLIENTESBindingSource;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckT0201;
        private System.Windows.Forms.CheckBox ckT0207;
        private System.Windows.Forms.CheckBox ckT0202L1;
        private System.Windows.Forms.CheckBox ckT0208;
        private System.Windows.Forms.CheckBox ckT0202L2;
        private System.Windows.Forms.CheckBox ckCobranzas;
        private System.Windows.Forms.CheckBox ckCheques;
        private System.Windows.Forms.CheckBox ckRemitos;
        private System.Windows.Forms.CheckBox ckOrdenVenta;
        private System.Windows.Forms.CheckBox ckTabla601;
        private System.Windows.Forms.CheckBox ckTabla40;
        private System.Windows.Forms.CheckBox ckFacturas;
        private System.Windows.Forms.Button btnClose;
    }
}