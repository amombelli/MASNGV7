
namespace MASngFE.Transactional.FI.Orden_de_Pago
{
    partial class FrmFI40AddTransferToOp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFI40AddTransferToOp));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ctlImporte = new TSControls.CtlTextBox();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LineaIzq = new System.Windows.Forms.Label();
            this.lineaArriba = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAddItemPago = new System.Windows.Forms.Button();
            this.txtGl = new System.Windows.Forms.TextBox();
            this.cmbBancoEmisor = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIdBanco = new System.Windows.Forms.TextBox();
            this.dtpFechaTransf = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumeroOperacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbBancoDestino = new System.Windows.Forms.ComboBox();
            this.t0160BANCOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.t0150CUENTASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0160BANCOSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(420, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(55, 25);
            this.textBox1.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(336, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 131;
            this.label3.Text = "Moneda OP";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.Location = new System.Drawing.Point(92, 4);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.ReadOnly = true;
            this.txtProveedor.Size = new System.Drawing.Size(383, 25);
            this.txtProveedor.TabIndex = 128;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 127;
            this.label4.Text = "Proveedor";
            // 
            // ctlImporte
            // 
            this.ctlImporte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlImporte.BackColor = System.Drawing.Color.White;
            this.ctlImporte.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlImporte.Location = new System.Drawing.Point(111, 173);
            this.ctlImporte.Margin = new System.Windows.Forms.Padding(0);
            this.ctlImporte.Name = "ctlImporte";
            this.ctlImporte.SeparadorDecimal = true;
            this.ctlImporte.SetAlineacion = TSControls.CtlTextBox.Alineacion.Centro;
            this.ctlImporte.SetDecimales = 2;
            this.ctlImporte.SetType = TSControls.CtlTextBox.TextBoxType.Moneda;
            this.ctlImporte.Size = new System.Drawing.Size(121, 25);
            this.ctlImporte.TabIndex = 201;
            this.ctlImporte.ValorMaximo = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.ctlImporte.ValorMinimo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ctlImporte.XReadOnly = false;
            // 
            // txtMoneda
            // 
            this.txtMoneda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.Location = new System.Drawing.Point(92, 30);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.ReadOnly = true;
            this.txtMoneda.Size = new System.Drawing.Size(55, 25);
            this.txtMoneda.TabIndex = 129;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 34);
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
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 61);
            this.panel1.TabIndex = 208;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DarkBlue;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.SeaGreen;
            this.label13.Location = new System.Drawing.Point(5, 201);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(494, 3);
            this.label13.TabIndex = 207;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkBlue;
            this.label12.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SeaGreen;
            this.label12.Location = new System.Drawing.Point(496, 3);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(3, 198);
            this.label12.TabIndex = 206;
            // 
            // LineaIzq
            // 
            this.LineaIzq.BackColor = System.Drawing.Color.DarkBlue;
            this.LineaIzq.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineaIzq.ForeColor = System.Drawing.Color.SeaGreen;
            this.LineaIzq.Location = new System.Drawing.Point(5, 3);
            this.LineaIzq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LineaIzq.Name = "LineaIzq";
            this.LineaIzq.Size = new System.Drawing.Size(3, 198);
            this.LineaIzq.TabIndex = 205;
            // 
            // lineaArriba
            // 
            this.lineaArriba.BackColor = System.Drawing.Color.DarkBlue;
            this.lineaArriba.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineaArriba.ForeColor = System.Drawing.Color.SeaGreen;
            this.lineaArriba.Location = new System.Drawing.Point(5, 3);
            this.lineaArriba.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lineaArriba.Name = "lineaArriba";
            this.lineaArriba.Size = new System.Drawing.Size(494, 3);
            this.lineaArriba.TabIndex = 204;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 200;
            this.label2.Text = "Importe";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(395, 146);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 48);
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
            this.btnAddItemPago.Location = new System.Drawing.Point(395, 98);
            this.btnAddItemPago.Name = "btnAddItemPago";
            this.btnAddItemPago.Size = new System.Drawing.Size(96, 48);
            this.btnAddItemPago.TabIndex = 210;
            this.btnAddItemPago.Text = "AGREGAR";
            this.btnAddItemPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddItemPago.UseVisualStyleBackColor = true;
            this.btnAddItemPago.Click += new System.EventHandler(this.btnAddItemPago_Click);
            // 
            // txtGl
            // 
            this.txtGl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGl.Location = new System.Drawing.Point(396, 72);
            this.txtGl.Name = "txtGl";
            this.txtGl.ReadOnly = true;
            this.txtGl.Size = new System.Drawing.Size(95, 23);
            this.txtGl.TabIndex = 214;
            // 
            // cmbBancoEmisor
            // 
            this.cmbBancoEmisor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBancoEmisor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBancoEmisor.DataSource = this.t0150CUENTASBindingSource;
            this.cmbBancoEmisor.DisplayMember = "CUENTA_DESC";
            this.cmbBancoEmisor.FormattingEnabled = true;
            this.cmbBancoEmisor.Location = new System.Drawing.Point(111, 72);
            this.cmbBancoEmisor.Name = "cmbBancoEmisor";
            this.cmbBancoEmisor.Size = new System.Drawing.Size(218, 23);
            this.cmbBancoEmisor.TabIndex = 213;
            this.cmbBancoEmisor.ValueMember = "ID_CUENTA";
            this.cmbBancoEmisor.SelectedIndexChanged += new System.EventHandler(this.cmbBancoEmisor_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 212;
            this.label11.Text = "Banco Origen";
            // 
            // txtIdBanco
            // 
            this.txtIdBanco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdBanco.Location = new System.Drawing.Point(332, 72);
            this.txtIdBanco.Name = "txtIdBanco";
            this.txtIdBanco.ReadOnly = true;
            this.txtIdBanco.Size = new System.Drawing.Size(62, 23);
            this.txtIdBanco.TabIndex = 215;
            // 
            // dtpFechaTransf
            // 
            this.dtpFechaTransf.Location = new System.Drawing.Point(111, 98);
            this.dtpFechaTransf.Name = "dtpFechaTransf";
            this.dtpFechaTransf.Size = new System.Drawing.Size(218, 23);
            this.dtpFechaTransf.TabIndex = 217;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 216;
            this.label9.Text = "Fecha Transf";
            // 
            // txtNumeroOperacion
            // 
            this.txtNumeroOperacion.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNumeroOperacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOperacion.Location = new System.Drawing.Point(111, 123);
            this.txtNumeroOperacion.MaxLength = 6;
            this.txtNumeroOperacion.Name = "txtNumeroOperacion";
            this.txtNumeroOperacion.Size = new System.Drawing.Size(62, 23);
            this.txtNumeroOperacion.TabIndex = 132;
            this.txtNumeroOperacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 133;
            this.label5.Text = "Operacion #";
            // 
            // cmbBancoDestino
            // 
            this.cmbBancoDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBancoDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBancoDestino.DataSource = this.t0160BANCOSBindingSource;
            this.cmbBancoDestino.DisplayMember = "BCO_SHORTDESC";
            this.cmbBancoDestino.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBancoDestino.FormattingEnabled = true;
            this.cmbBancoDestino.Location = new System.Drawing.Point(111, 148);
            this.cmbBancoDestino.Name = "cmbBancoDestino";
            this.cmbBancoDestino.Size = new System.Drawing.Size(218, 23);
            this.cmbBancoDestino.TabIndex = 219;
            this.cmbBancoDestino.ValueMember = "BCO_SHORTDESC";
            // 
            // t0160BANCOSBindingSource
            // 
            this.t0160BANCOSBindingSource.DataSource = typeof(TecserEF.Entity.T0160_BANCOS);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 218;
            this.label6.Text = "Banco Destino";

            // 
            // t0150CUENTASBindingSource
            // 
            this.t0150CUENTASBindingSource.DataSource = typeof(TecserEF.Entity.T0150_CUENTAS);
            // 
            // FrmFI40AddTransferToOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 208);
            this.Controls.Add(this.cmbBancoDestino);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumeroOperacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpFechaTransf);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIdBanco);
            this.Controls.Add(this.txtGl);
            this.Controls.Add(this.cmbBancoEmisor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.ctlImporte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddItemPago);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.LineaIzq);
            this.Controls.Add(this.lineaArriba);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFI40AddTransferToOp";
            this.Text = "FI40 - Pago por Transferencia ";
            this.Load += new System.EventHandler(this.FrmFI40AddTransferToOp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.t0160BANCOSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t0150CUENTASBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddItemPago;
        private TSControls.CtlTextBox ctlImporte;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LineaIzq;
        private System.Windows.Forms.Label lineaArriba;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGl;
        private System.Windows.Forms.ComboBox cmbBancoEmisor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIdBanco;
        private System.Windows.Forms.DateTimePicker dtpFechaTransf;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumeroOperacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbBancoDestino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource t0160BANCOSBindingSource;
        private System.Windows.Forms.BindingSource t0150CUENTASBindingSource;
    }
}