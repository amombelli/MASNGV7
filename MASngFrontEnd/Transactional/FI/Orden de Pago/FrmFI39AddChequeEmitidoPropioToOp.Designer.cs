namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    partial class FrmFI39AddChequeEmitidoPropioToOp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI39AddChequeEmitidoPropioToOp));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.ctlImporteCheque = new TSControls.CtlTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grbTipoCheque = new System.Windows.Forms.GroupBox();
            this.rbEcheque = new System.Windows.Forms.RadioButton();
            this.rbChequeFisico = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.cNumeroCheque = new TSControls.CtlTextBox();
            this.dtpFechaAcreditacion = new System.Windows.Forms.DateTimePicker();
            this.cmbBancoEmisor = new System.Windows.Forms.ComboBox();
            this.t0150CUENTASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGl = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAddItemPago = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grbTipoCheque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(490, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(63, 25);
            this.textBox1.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(392, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 131;
            this.label3.Text = "Moneda OP";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.Location = new System.Drawing.Point(107, 5);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(446, 25);
            this.txtProveedor.TabIndex = 128;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 127;
            this.label4.Text = "Proveedor";
            // 
            // txtMoneda
            // 
            this.txtMoneda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.Location = new System.Drawing.Point(107, 35);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(63, 25);
            this.txtMoneda.TabIndex = 129;
            // 
            // ctlImporteCheque
            // 
            this.ctlImporteCheque.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlImporteCheque.BackColor = System.Drawing.Color.White;
            this.ctlImporteCheque.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlImporteCheque.Location = new System.Drawing.Point(128, 86);
            this.ctlImporteCheque.Margin = new System.Windows.Forms.Padding(0);
            this.ctlImporteCheque.Name = "ctlImporteCheque";
            this.ctlImporteCheque.SeparadorDecimal = true;
            this.ctlImporteCheque.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlImporteCheque.SetDecimales = 2;
            this.ctlImporteCheque.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.ctlImporteCheque.Size = new System.Drawing.Size(97, 25);
            this.ctlImporteCheque.TabIndex = 201;
            this.ctlImporteCheque.ValorMaximo = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ctlImporteCheque.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlImporteCheque.XReadOnly = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 129;
            this.label1.Text = "Moneda OP";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtProveedor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMoneda);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 70);
            this.panel1.TabIndex = 208;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkBlue;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SeaGreen;
            this.label12.Location = new System.Drawing.Point(577, 3);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(3, 287);
            this.label12.TabIndex = 206;
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkBlue;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.SeaGreen;
            this.LineaIzq.Location = new System.Drawing.Point(4, 3);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 287);
            this.LineaIzq.TabIndex = 205;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DarkBlue;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.SeaGreen;
            this.lineaArriba.Location = new System.Drawing.Point(4, 3);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(576, 3);
            this.lineaArriba.TabIndex = 204;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkBlue;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.SeaGreen;
            this.label13.Location = new System.Drawing.Point(4, 287);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(576, 3);
            this.label13.TabIndex = 207;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.GhostWhite;
            this.panel3.Controls.Add(this.txtGl);
            this.panel3.Controls.Add(this.grbTipoCheque);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.cNumeroCheque);
            this.panel3.Controls.Add(this.dtpFechaAcreditacion);
            this.panel3.Controls.Add(this.cmbBancoEmisor);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.ctlImporteCheque);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(11, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(414, 202);
            this.panel3.TabIndex = 210;
            // 
            // grbTipoCheque
            // 
            this.grbTipoCheque.Controls.Add(this.rbEcheque);
            this.grbTipoCheque.Controls.Add(this.rbChequeFisico);
            this.grbTipoCheque.Location = new System.Drawing.Point(134, 115);
            this.grbTipoCheque.Name = "grbTipoCheque";
            this.grbTipoCheque.Size = new System.Drawing.Size(250, 82);
            this.grbTipoCheque.TabIndex = 212;
            this.grbTipoCheque.TabStop = false;
            this.grbTipoCheque.Text = "Tipo de Cheque";
            // 
            // rbEcheque
            // 
            this.rbEcheque.AutoSize = true;
            this.rbEcheque.Location = new System.Drawing.Point(12, 48);
            this.rbEcheque.Name = "rbEcheque";
            this.rbEcheque.Size = new System.Drawing.Size(206, 21);
            this.rbEcheque.TabIndex = 1;
            this.rbEcheque.TabStop = true;
            this.rbEcheque.Text = "Cheque Electronico [E-Cheque]";
            this.rbEcheque.UseVisualStyleBackColor = true;
            // 
            // rbChequeFisico
            // 
            this.rbChequeFisico.AutoSize = true;
            this.rbChequeFisico.Location = new System.Drawing.Point(12, 23);
            this.rbChequeFisico.Name = "rbChequeFisico";
            this.rbChequeFisico.Size = new System.Drawing.Size(106, 21);
            this.rbChequeFisico.TabIndex = 0;
            this.rbChequeFisico.TabStop = true;
            this.rbChequeFisico.Text = "Cheque Fisico";
            this.rbChequeFisico.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 17);
            this.label14.TabIndex = 204;
            this.label14.Text = "Importe Cheque";
            // 
            // cNumeroCheque
            // 
            this.cNumeroCheque.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cNumeroCheque.BackColor = System.Drawing.Color.White;
            this.cNumeroCheque.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cNumeroCheque.Location = new System.Drawing.Point(128, 59);
            this.cNumeroCheque.Margin = new System.Windows.Forms.Padding(0);
            this.cNumeroCheque.Name = "cNumeroCheque";
            this.cNumeroCheque.SeparadorDecimal = false;
            this.cNumeroCheque.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.cNumeroCheque.SetDecimales = 0;
            this.cNumeroCheque.SetType = TSControls.CtlTextBox.TextBoxType.Entero;
            this.cNumeroCheque.Size = new System.Drawing.Size(65, 25);
            this.cNumeroCheque.TabIndex = 203;
            this.cNumeroCheque.ValorMaximo = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.cNumeroCheque.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.cNumeroCheque.XReadOnly = false;
            // 
            // dtpFechaAcreditacion
            // 
            this.dtpFechaAcreditacion.Location = new System.Drawing.Point(128, 32);
            this.dtpFechaAcreditacion.Name = "dtpFechaAcreditacion";
            this.dtpFechaAcreditacion.Size = new System.Drawing.Size(267, 25);
            this.dtpFechaAcreditacion.TabIndex = 202;
            // 
            // cmbBancoEmisor
            // 
            this.cmbBancoEmisor.DataSource = this.t0150CUENTASBindingSource;
            this.cmbBancoEmisor.DisplayMember = "ID_CUENTA";
            this.cmbBancoEmisor.FormattingEnabled = true;
            this.cmbBancoEmisor.Location = new System.Drawing.Point(128, 5);
            this.cmbBancoEmisor.Name = "cmbBancoEmisor";
            this.cmbBancoEmisor.Size = new System.Drawing.Size(192, 25);
            this.cmbBancoEmisor.TabIndex = 201;
            this.cmbBancoEmisor.ValueMember = "CUENTA_DESC";
            this.cmbBancoEmisor.SelectedIndexChanged += new System.EventHandler(this.cmbBancoEmisor_SelectedIndexChanged);
            // 
            // t0150CUENTASBindingSource
            // 
            this.t0150CUENTASBindingSource.DataSource = typeof(TecserEF.Entity.T0150_CUENTAS);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 17);
            this.label9.TabIndex = 131;
            this.label9.Text = "Fecha Acreditacion";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 17);
            this.label10.TabIndex = 200;
            this.label10.Text = "Numero Cheque";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(37, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 127;
            this.label11.Text = "Banco Emisor";
            // 
            // txtGl
            // 
            this.txtGl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGl.Location = new System.Drawing.Point(322, 5);
            this.txtGl.Name = "txtGl";
            this.txtGl.ReadOnly = true;
            this.txtGl.Size = new System.Drawing.Size(73, 25);
            this.txtGl.TabIndex = 206;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(431, 138);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 55);
            this.btnCancelar.TabIndex = 211;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAddItemPago
            // 
            this.btnAddItemPago.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItemPago.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItemPago.Image")));
            this.btnAddItemPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddItemPago.Location = new System.Drawing.Point(431, 83);
            this.btnAddItemPago.Name = "btnAddItemPago";
            this.btnAddItemPago.Size = new System.Drawing.Size(138, 55);
            this.btnAddItemPago.TabIndex = 210;
            this.btnAddItemPago.Text = "AGREGAR";
            this.btnAddItemPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItemPago.UseVisualStyleBackColor = true;
            this.btnAddItemPago.Click += new System.EventHandler(this.btnAddItemPago_Click);
            // 
            // FrmFI39AddChequeEmitidoPropioToOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 294);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAddItemPago);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Controls.Add(this.label13);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFI39AddChequeEmitidoPropioToOp";
            this.Text = "FI39 - Emision de Cheque Propio";
            this.Load += new System.EventHandler(this.FrmFI39AddChequeEmitidoPropioToOp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grbTipoCheque.ResumeLayout(false);
            this.grbTipoCheque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMoneda;
        private TSControls.CtlTextBox ctlImporteCheque;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAddItemPago;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grbTipoCheque;
        private System.Windows.Forms.RadioButton rbEcheque;
        private System.Windows.Forms.RadioButton rbChequeFisico;
        private System.Windows.Forms.Label label14;
        private TSControls.CtlTextBox cNumeroCheque;
        private System.Windows.Forms.DateTimePicker dtpFechaAcreditacion;
        private System.Windows.Forms.ComboBox cmbBancoEmisor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGl;
        private System.Windows.Forms.BindingSource t0150CUENTASBindingSource;
    }
}